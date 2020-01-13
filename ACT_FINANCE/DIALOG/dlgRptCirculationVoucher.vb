Public Class dlgRptCirculationVoucher
    Private DSN As String
    Private sptServer As String
    Private tbl_Print As DataTable = clsDataset.CreateTblTrnCirculationvoucher
    Private tbl_PrintDetil As DataTable = clsDataset.CreateTblTrnCirculationvoucherdetil
    Private criteria As String
    Private objDatalistDetil As ArrayList
    Private strChannel As String
    Private strChannel_id As String
    Private strChannel_nameReport As String
    Private strChannel_address As String
    Private strCirculation_id As String
    Private strCirculation_date As DateTime
    Private strRevisi As String
    Private strDescr As String
    Private parTotal_amount As Decimal
    Private parTotal_foreign As Decimal
    Private channel_id As String

    Private Sub dlgRptCirculationVoucher_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter
        Dim dtFiller As clsDataFiller = New clsDataFiller(Me.DSN)

        dtFiller.DataFill(Me.tbl_Print, "act_TrnCirculationvoucher_Select", "circulation_id = '" & strCirculation_id & "'", Me.strChannel)

        dbCmd = New OleDb.OleDbCommand("act_TrnCirculationDetilPrint_select", dbConn)
        dbCmd.Parameters.Add("@channel_id", Data.OleDb.OleDbType.VarWChar)
        dbCmd.Parameters("@channel_id").Value = strChannel
        dbCmd.Parameters.Add("@circulation_id", Data.OleDb.OleDbType.VarWChar)
        dbCmd.Parameters("@circulation_id").Value = strCirculation_id
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarWChar)
        dbCmd.Parameters("@Criteria").Value = " circulationdetil_appdireksi = 0"

        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)
        Me.tbl_PrintDetil.Clear()

        Dim cookie As Byte() = Nothing

        Try
            dbConn.Open()
            clsApplicationRole.SetAppRole(dbConn, cookie)
            Try
                dbDA.Fill(Me.tbl_PrintDetil)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "dlgRptCirculationVoucher_Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

            Dim ssql As String
            Dim tbl_temps As DataTable = New DataTable
            ssql = String.Format("SELECT SUM(circulationdetil_amount) AS total_amount , SUM(circulationdetil_foreign) AS total_foreign FROM FRM.E_FRM.dbo.transaksi_circulationvoucherdetil WHERE circulation_id = '{0}' AND circulationdetil_canceled = 0", strCirculation_id)

            Try
                dbDA = New OleDb.OleDbDataAdapter(ssql, dbConn)
                tbl_temps.Clear()

                dbConn.Open()
                clsApplicationRole.SetAppRole(dbConn, cookie)
                dbDA.Fill(tbl_temps)

                If tbl_temps.Rows.Count > 0 Then
                    Me.parTotal_amount = tbl_temps.Rows(0).Item("total_amount")
                    Me.parTotal_foreign = tbl_temps.Rows(0).Item("total_foreign")
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            GenerateReport()
            Me.rvCirculationVaucher.RefreshReport()
        Catch ex As Exception
        Finally
            clsApplicationRole.UnsetAppRole(dbConn, cookie)
            dbConn.Close()
        End Try


    End Sub

    Private Function GenerateReport() As Boolean
        Dim objRdsH As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Dim objReportH As Microsoft.Reporting.WinForms.LocalReport = New Microsoft.Reporting.WinForms.LocalReport
        Dim objRdsD As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Dim objReportD As Microsoft.Reporting.WinForms.LocalReport = New Microsoft.Reporting.WinForms.LocalReport
        Dim objDatalistHeader As ArrayList = New ArrayList()
        Dim objReportViewer As Microsoft.Reporting.WinForms.ReportViewer = New Microsoft.Reporting.WinForms.ReportViewer
        'Dim parRptImageURL As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("imageURL", Me.sptServer)

        '============ tambahan by ari prasasti <parameter global> 20 April 2012
        Dim dt As DataTable = New DataTable

        dt.Clear()

        clsUtil.DataFill(Me.DSN, dt, "act_select_channel", " channel_id = '" & Me.channel_id & "' ")

        'fill variabel global
        Dim fileUrl As String = CStr(dt.Rows(0).Item("channel_domainname"))

        '---------------tambahan buat insosys baru 2012-- 19 April 2012---------------
        fileUrl = fileUrl.Replace("\", "/")
        fileUrl = "file:///" & fileUrl & "/services/live/solutions/images/" & Me.channel_id & ".jpg"
        '---------------------------------------------------------------

        Dim parRptImageURL As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("imageURL", fileUrl)

        '===end tambahan
        Dim parRptTotalAmount As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("total_amount", Format(Me.parTotal_amount, "#,##0"))
        Dim parRptTotalForeign As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("total_foreign", Format(Me.parTotal_foreign, "#,##0.00"))

        ' Me.tbl_Print.Clear()
        'Me.DataFill(tbl_Print, "act_TrnCirculationvoucher_Select", "circulation_id = '" & Me.DgvTrnCirculationvoucher.SelectedRows.Item(i).Cells("circulation_id").Value & "'", Me._CHANNEL)


        objDatalistHeader = Me.GenerateDataHeader()

        Dim parRptChannelID As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("channelID", Me.strChannel_id)
        Dim parRptChannel_namereport As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("channelName", Me.strChannel_nameReport)
        Dim parRptChannel_address As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("channelAddress", Me.strChannel_address)
        Dim parRptCirculation_id As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("circulation_id", Me.strCirculation_id)
        Dim parRptCirculation_date As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("circulation_date", Me.strCirculation_date)
        Dim parRptRevisi As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("revisi", Me.strRevisi)
        Dim parRptDescr As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("descr", Me.strDescr)

        objRdsH.Name = "ACT_FINANCE_DataSource_clsRptCirculationVoucher"
        objRdsH.Value = objDatalistHeader
        objReportH.ReportEmbeddedResource = "ACT_FINANCE.rptCirculationVoucher.rdlc"
        objReportH.DataSources.Add(objRdsH)

        AddHandler objReportViewer.LocalReport.SubreportProcessing, AddressOf SubreportProcessing

        objReportViewer.Name = "rvCirculationVaucher"
        objReportViewer.LocalReport.ReportEmbeddedResource = objReportH.ReportEmbeddedResource
        objReportViewer.LocalReport.EnableExternalImages = True
        objReportViewer.LocalReport.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter() {parRptImageURL, parRptChannelID, parRptChannel_namereport, _
                parRptChannel_address, parRptCirculation_id, parRptCirculation_date, parRptRevisi, parRptDescr, _
                parRptTotalAmount, parRptTotalForeign})

        objReportViewer.LocalReport.DataSources.Clear()
        objReportViewer.LocalReport.DataSources.Add(objRdsH)
        objReportViewer.RefreshReport()

        Me.SuspendLayout()
        Me.Controls.Remove(Me.rvCirculationVaucher)

        Me.rvCirculationVaucher = Nothing
        Me.rvCirculationVaucher = objReportViewer
        Me.rvCirculationVaucher.LocalReport.EnableExternalImages = True

        Me.Controls.Add(Me.rvCirculationVaucher)
        Me.ResumeLayout()
        Me.rvCirculationVaucher.Dock = DockStyle.Fill
    End Function
    Private Function GenerateDataHeader() As ArrayList
        Dim objPrintHeader As DataSource.clsRptCirculationVoucher
        Dim objDatalistHeader As ArrayList = New ArrayList()
        Dim i As Integer

        For i = 0 To Me.tbl_Print.Rows.Count - 1
            GenerateDataDetail()
            objPrintHeader = New DataSource.clsRptCirculationVoucher(Me.DSN)
            With objPrintHeader
                .circulation_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("circulation_id").ToString, String.Empty)
                .circulation_senddt = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("circulation_senddt"), Now())
                .circulation_sendto = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("circulation_sendto"), 0)
                .circulation_foreign = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("circulation_foreign"), 0)
                .circulation_amount = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("circulation_amount"), 0)
                .circulation_descr = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("circulation_descr").ToString, String.Empty)
                .jurnaltype_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("jurnaltype_id").ToString, String.Empty)
                .channel_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("channel_id").ToString, String.Empty)
                .circulation_appuser = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("circulation_appuser"), 0)
                .circulation_appuserby = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("circulation_appuserby").ToString, String.Empty)
                .circulation_appuserdt = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("circulation_appuserdt"), Now())
                .circulation_status = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("circulation_status").ToString, String.Empty)
                .circulation_totalrevisi = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("circulation_totalrevisi"), 0)
                .entry_by = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("entry_by").ToString, String.Empty)
                .entry_dt = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("entry_dt"), Now())
                .modify_by = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("modify_by").ToString, String.Empty)
                .modify_dt = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("modify_dt"), Now())

                Me.strChannel_id = .channel_id
                Me.strChannel_nameReport = .channel_namereport
                Me.strChannel_address = .channel_address
                Me.strCirculation_date = .circulation_senddt
                Me.strRevisi = .circulation_status & "-" & .circulation_totalrevisi
                Me.strDescr = .circulation_descr


            End With
            objDatalistHeader.Add(objPrintHeader)
        Next

        Return objDatalistHeader
    End Function
    Private Sub GenerateDataDetail()
        Dim objDetil As DataSource.clsRptCirculationVoucherDetil
        Dim i As Integer

        objDatalistDetil = New ArrayList()
        For i = 0 To Me.tbl_PrintDetil.Rows.Count - 1
            objDetil = New DataSource.clsRptCirculationVoucherDetil(Me.DSN)
            With objDetil
                .circulation_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("circulation_id").ToString, String.Empty)
                .circulationdetil_line = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("circulationdetil_line"), 0)
                .circulationdetil_reference = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("circulationdetil_reference").ToString, String.Empty)
                .circulationdetil_bilyet = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("circulationdetil_bilyet").ToString, String.Empty)
                .circulationdetil_rekanan = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("circulationdetil_rekanan"), 0)
                .circulationdetil_descr = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("circulationdetil_descr").ToString, String.Empty)
                .currency_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("currency_id"), 0)
                .circulationdetil_foreign = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("circulationdetil_foreign"), 0)
                .circulationdetil_rate = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("circulationdetil_rate"), 0)
                .circulationdetil_amount = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("circulationdetil_amount"), 0)
                .channel_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("channel_id").ToString, String.Empty)
                .circulationdetil_appdireksi = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("circulationdetil_appdireksi"), 0)
                .circulationdetil_appdireksi_by = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("circulationdetil_appdireksi_by").ToString, String.Empty)
                .circulationdetil_appdireksi_dt = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("circulationdetil_appdireksi_dt"), Now())
                .circulationdetil_appbayar = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("circulationdetil_appbayar"), 0)
                .circulationdetil_appbayar_by = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("circulationdetil_appbayar_by").ToString, String.Empty)
                .circulationdetil_appbayar_dt = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("circulationdetil_appbayar_dt"), Now())
                .circulationdetil_appbankcair = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("circulationdetil_appbankcair"), 0)
                .circulationdetil_appbankcair_by = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("circulationdetil_appbankcair_by").ToString, String.Empty)
                .circulationdetil_appbankcair_dt = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("circulationdetil_appbankcair_dt"), Now())
                .circulationdetil_canceled = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("circulationdetil_canceled"), 0)
                .circulationdetil_canceledby = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("circulationdetil_canceledby").ToString, String.Empty)
                .circulationdetil_canceleddt = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("circulationdetil_canceleddt"), Now())
                .entry_by = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("entry_by").ToString, String.Empty)
                .entry_dt = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("entry_dt"), Now())
                .modify_by = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("modify_by").ToString, String.Empty)
                .modify_dt = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("modify_dt"), Now())
                .amount_ref_foreign = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("amount_ref_foreign"), clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("circulationdetil_foreign"), 0))
                If .currname = "IDR" Then
                    .amount_ref_idr = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("amount_ref_idr"), clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("circulationdetil_amount"), 0))
                Else
                    .amount_ref_idr = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("amount_ref_foreign_print"), clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("circulationdetil_amount"), 0))

                End If
               
                .jurnal_id_ref = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("jurnal_id_ref"), String.Empty)
                .currref = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("curr_ref"), String.Empty)
                .currname = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("curr_name"), String.Empty)
                .descref = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("desc_ref"), String.Empty)
                .paymenttype = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("paymenttype"), String.Empty)
            End With
            objDatalistDetil.Add(objDetil)
        Next
    End Sub
    Public Sub SubreportProcessing(ByVal sender As Object, ByVal e As Microsoft.Reporting.WinForms.SubreportProcessingEventArgs)
        e.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("ACT_FINANCE_DataSource_clsRptCirculationVoucherDetil", objDatalistDetil))
    End Sub

    Public Sub New(ByVal strDSN As String, ByVal sptServer As String, ByVal circulation_id As String, _
                    ByVal channel_id As String)
        DSN = strDSN
        Me.sptServer = sptServer
        Me.strCirculation_id = circulation_id
        Me.strChannel = channel_id
        Me.channel_id = channel_id
        InitializeComponent()
    End Sub
End Class

