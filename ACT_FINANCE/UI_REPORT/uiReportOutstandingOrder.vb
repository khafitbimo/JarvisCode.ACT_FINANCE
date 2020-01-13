Imports System
Imports System.Windows.Forms
Imports System.Drawing.Imaging

Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraPrinting


Public Class uiReportOutstandingOrder
    Private objTbl_OutstandingOrder As DataTable = New DataTable
    Private objDatalistDetil As ArrayList = New ArrayList

#Region " Window Parameter "
    ' TODO: Buat variabel untuk menampung parameter window 
    Private _CHANNEL As String = "TAS"
#End Region

    Private Sub btnLoadData_Click(sender As Object, e As EventArgs) Handles btnLoadData.Click
        Me.Cursor = Cursors.WaitCursor
        Dim cookie As Byte() = Nothing

        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSNFrm)
        Dim dbCmd As OleDb.OleDbCommand = Nothing
        Dim dbDA As OleDb.OleDbDataAdapter = Nothing

        Dim rptRdlcName As String = String.Empty
        Dim rptDataSourceName As String = String.Empty
        Dim rptProcedureName As String = String.Empty

        Dim objOutstandingOrder As DataSource.clsRptOutstandingOrder
        Dim datalist As ArrayList = New ArrayList

        rptRdlcName = "ACT_FINANCE.rptOutstandingOrder.rdlc"
        rptDataSourceName = "ACT_FINANCE_DataSource_clsRptOutstandingOrder"
        rptProcedureName = "act_outstanding_order"

        dbCmd = New OleDb.OleDbCommand(rptProcedureName, dbConn)
        dbCmd.Parameters.Add("@channel_id", OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@channel_id").Value = Me._CHANNEL
        dbCmd.Parameters.Add("@start_date", OleDb.OleDbType.Date)
        dbCmd.Parameters("@start_date").Value = Me.deDate1.EditValue
        dbCmd.Parameters.Add("@end_date", OleDb.OleDbType.Date)
        dbCmd.Parameters("@end_date").Value = Me.deDate2.EditValue


        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)

        Try
            Me.GridControl1.DataSource = Nothing
            dbConn.Open()
            clsApplicationRole.SetAppRole(dbConn, cookie)
            dbDA.Fill(Me.objTbl_OutstandingOrder)
            Me.GridControl1.DataSource = Me.objTbl_OutstandingOrder

            'If Me.ReportViewer1.Visible = True Then
            '    Me.objDatalistDetil.Clear()

            '    For i As Integer = 0 To Me.objTbl_OutstandingOrder.Rows.Count - 1
            '        objOutstandingOrder = New DataSource.clsRptOutstandingOrder(Me.DSNFrm)

            '        With objOutstandingOrder
            '            .no = (i + 1).ToString
            '            .order_id = Me.objTbl_OutstandingOrder.Rows(i).Item("order_id")
            '            .strukturunit_name = Me.objTbl_OutstandingOrder.Rows(i).Item("strukturunit_name")
            '            .order_descr = Me.objTbl_OutstandingOrder.Rows(i).Item("order_descr")
            '            .amount_order = Me.objTbl_OutstandingOrder.Rows(i).Item("amount_order")
            '            .rv_status = Me.objTbl_OutstandingOrder.Rows(i).Item("rv_status")
            '            .pv_advance = Me.objTbl_OutstandingOrder.Rows(i).Item("pv_advance")
            '            .amount_pv_advance = Me.objTbl_OutstandingOrder.Rows(i).Item("amount_pv_advance")
            '            .pv_ap = Me.objTbl_OutstandingOrder.Rows(i).Item("pv_ap")
            '            .amount_pv_ap = Me.objTbl_OutstandingOrder.Rows(i).Item("amount_pv_ap")
            '            .outstanding = Me.objTbl_OutstandingOrder.Rows(i).Item("outstanding")
            '        End With

            '        objDatalistDetil.Add(objOutstandingOrder)
            '    Next

            '    Dim dt As DataTable = New DataTable
            '    dt.Clear()
            '    clsUtil.DataFill(Me.DSNFrm, dt, "act_select_channel", " channel_id = '" & Me._CHANNEL & "'")
            '    Dim fileUrl As String = CStr(dt.Rows(0).Item("channel_domainname"))
            '    Dim channelID As String = CStr(dt.Rows(0).Item("channel_id"))
            '    Dim channelName As String = CStr(dt.Rows(0).Item("channel_namereport"))
            '    Dim channelAddress As String = CStr(dt.Rows(0).Item("channel_address"))
            '    fileUrl = fileUrl.Replace("\", "/")
            '    fileUrl = "file:///" & fileUrl & "/services/live/solutions/images/" & Me._CHANNEL & ".jpg"

            '    Dim objRds As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
            '    Dim objReport As Microsoft.Reporting.WinForms.LocalReport = New Microsoft.Reporting.WinForms.LocalReport
            '    Dim objReportViewer As Microsoft.Reporting.WinForms.ReportViewer = New Microsoft.Reporting.WinForms.ReportViewer

            '    Dim ParURLImage As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("parImageURL", fileUrl)
            '    'Dim ParChannelID As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("parChannelID", channelName)
            '    Dim ParChannelName As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("parChannelName", channelName)
            '    Dim ParChannelAddress As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("parChannelAddress", channelAddress)
            '    Dim ParPeriode As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("parPeriode", CDate(Me.deDate1.EditValue).ToString("dd MMMM yyyy") & " s/d " & CDate(Me.deDate2.EditValue).ToString("dd MMMM yyyy"))

            '    objRds.Name = rptDataSourceName
            '    objRds.Value = objDatalistDetil
            '    objReport.ReportEmbeddedResource = rptRdlcName
            '    objReport.DataSources.Clear()
            '    objReport.DataSources.Add(objRds)
            '    objReport.EnableExternalImages = True

            '    objReportViewer.Name = "ReportViewer1"
            '    objReportViewer.LocalReport.ReportEmbeddedResource = objReport.ReportEmbeddedResource
            '    objReportViewer.LocalReport.EnableExternalImages = True
            '    AddHandler objReportViewer.LocalReport.SubreportProcessing, AddressOf SubreportProcessing

            '    objReportViewer.LocalReport.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter() {ParURLImage, ParChannelName, ParChannelAddress, ParPeriode})
            '    objReportViewer.LocalReport.DataSources.Clear()
            '    objReportViewer.LocalReport.DataSources.Add(objRds)
            '    objReportViewer.RefreshReport()

            '    Me.PanelControl2.SuspendLayout()
            '    Me.PanelControl2.Controls.Remove(Me.ReportViewer1)
            '    Me.ReportViewer1 = Nothing
            '    Me.ReportViewer1 = objReportViewer

            '    Me.PanelControl2.Controls.Add(Me.ReportViewer1)
            '    Me.ReportViewer1.Dock = DockStyle.Fill
            '    Me.PanelControl2.ResumeLayout()
            'End If
        Catch ex As Exception
            MsgBox("[Error] btnLoadData_Click : " + Chr(13) + ex.Message, MsgBoxStyle.Critical, "Report Outstanding Order")
        Finally
            clsApplicationRole.UnsetAppRole(dbConn, cookie)
            dbConn.Close()
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub uiReportOutstandingOrder_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.deDate1.EditValue = Now
        Me.deDate2.EditValue = Now
    End Sub

    Public Sub SubreportProcessing(ByVal sender As Object, ByVal e As Microsoft.Reporting.WinForms.SubreportProcessingEventArgs)
        e.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", objDatalistDetil))
    End Sub

    Private Sub btnExportXLS_Click(sender As Object, e As EventArgs) Handles btnExportXLS.Click
        Try
            Dim saveFileDialog1 As New SaveFileDialog()
            saveFileDialog1.Filter = "Excel File|*.xlsx"
            saveFileDialog1.Title = "Save an Excel File"
            saveFileDialog1.ShowDialog()

            If saveFileDialog1.FileName <> "" Then
                Me.GridControl1.ExportToXlsx(saveFileDialog1.FileName)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub
End Class
