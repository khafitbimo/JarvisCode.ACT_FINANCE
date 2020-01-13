'================================================== 
' Yanuar Andriyana Putra
' TransTV
' Created Date: 10/17/2010 10:54 AM

Public Class dlgRptJurnal_PV
    Private Const mUiName As String = "dlgTrnJurnalPV"
    Private DSN As String
    Private channel_id As String
    Private jurnal_id As String

    Private tbl_Print As DataTable = clsDataset.CreateTblTrnJurnal()
    Private tbl_PrintDetil As DataTable = clsDataset.CreateTblTrnJurnaldetil()
    Private objPrintHeader As DataSource.clsRptJurnalPV_Header
    Private objPrintDetil As DataSource.clsRptJurnalPV_Detil
    Private objDatalistDetil As ArrayList

    Private parCurrency_Name As String
    Private parRekanan_Name As String
    Private parJurnal_Desc As String
    Private parCreate_Date As String
    Private parBudget_name As String
    Private parAmountRate As Decimal = 0

    Private sptServer As String
    Private strchannel_id As String
    Private id As String
    Private curr As String
    Private sptChannel_nameReport As String
    Private sptChannel_address As String

    Private AmountIdrNew As Decimal = 0
    Private AmountForeignNew As Decimal = 0

    Private Function GenerateReport() As Boolean

        Dim objRdsH As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Dim objReportH As Microsoft.Reporting.WinForms.LocalReport = New Microsoft.Reporting.WinForms.LocalReport
        Dim objRdsD As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Dim objReportD As Microsoft.Reporting.WinForms.LocalReport = New Microsoft.Reporting.WinForms.LocalReport
        Dim objDatalistHeader As ArrayList = New ArrayList()
        Dim objReportViewer As Microsoft.Reporting.WinForms.ReportViewer = New Microsoft.Reporting.WinForms.ReportViewer

        objDatalistHeader = Me.GenerateDataHeader()

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

        Dim parRptChannelID As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("channelID", Me.strchannel_id)
        Dim parRptChannel_namereport As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("channelName", Me.sptChannel_nameReport)
        Dim parRptChannel_address As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("channelAddress", Me.sptChannel_address)
        Dim parRptID As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("id", Me.id)
        Dim parRptAmountIdr As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("amountidr", Me.AmountIdrNew)
        Dim parRptAmountForeign As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("amountforeign", Me.AmountForeignNew)
        Dim parRptCreateDate As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("createDate", Me.parCreate_Date)
        Dim parRptRekananName As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("rekananName", Me.parRekanan_Name)
        Dim parRptBudgetName As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("budgetName", Me.parBudget_name) 'Me.parBudget_name
        Dim parRptJurnalDescr As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("jurnalDescr", Me.parJurnal_Desc)
        Dim parRptCurrencyName As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("currencyName", Me.parCurrency_Name)
        Dim parRptAmountRate As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("amountRate", Me.parAmountRate)


        objRdsH.Name = "ACT_FINANCE_DataSource_clsRptJurnalPV_Header"
        objRdsH.Value = objDatalistHeader

        If Me.tbl_Print.Rows(0).Item("jurnal_source") = "PV-ListAdvance" Or Me.tbl_Print.Rows(0).Item("jurnal_source") = "PV-ListAdvanceOrder" Or Me.tbl_Print.Rows(0).Item("jurnal_source") = "PV-ListAdvanceTravel" Then
            objReportH.ReportEmbeddedResource = "ACT_FINANCE.rptPV_HeaderListAdvance.rdlc"
        ElseIf Me.tbl_Print.Rows(0).Item("jurnal_source") = "PV-ListAP" Then
            objReportH.ReportEmbeddedResource = "ACT_FINANCE.rptPV_HeaderListAP.rdlc"
        ElseIf Me.tbl_Print.Rows(0).Item("jurnal_source") = "PV-ListST" Then
            objReportH.ReportEmbeddedResource = "ACT_FINANCE.rptPV_HeaderListAP.rdlc"
        ElseIf Me.tbl_Print.Rows(0).Item("jurnal_source") = "PV-Manual" Then
            objReportH.ReportEmbeddedResource = "ACT_FINANCE.rptPV_HeaderManual.rdlc"
        ElseIf Me.tbl_Print.Rows(0).Item("jurnal_source") = "PV-ListTax" Then
            objReportH.ReportEmbeddedResource = "ACT_FINANCE.rptPV_Tax_Header.rdlc"
        End If

        objReportH.DataSources.Add(objRdsH)

        AddHandler objReportViewer.LocalReport.SubreportProcessing, AddressOf SubreportProcessing
        objReportViewer.Name = "Reportviewer1"
        objReportViewer.LocalReport.ReportEmbeddedResource = objReportH.ReportEmbeddedResource
        objReportViewer.LocalReport.EnableExternalImages = True

        objReportViewer.LocalReport.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter() {parRptImageURL, _
            parRptChannelID, parRptChannel_namereport, parRptChannel_address, parRptID, _
            parRptAmountIdr, parRptAmountForeign, parRptCreateDate, parRptRekananName, parRptBudgetName, _
            parRptJurnalDescr, parRptCurrencyName, parRptAmountRate})

        objReportViewer.LocalReport.DataSources.Clear()
        objReportViewer.LocalReport.DataSources.Add(objRdsH)
        objReportViewer.RefreshReport()

        Me.SuspendLayout()

        Me.Controls.Remove(Me.ReportViewer1)

        Me.ReportViewer1 = Nothing
        Me.ReportViewer1 = objReportViewer
        Me.ReportViewer1.LocalReport.EnableExternalImages = True

        Me.Controls.Add(Me.ReportViewer1)
        Me.ResumeLayout()
        Me.ReportViewer1.Dock = DockStyle.Fill
    End Function

    Private Function GenerateDataHeader() As ArrayList
        Dim objDatalistHeader As ArrayList = New ArrayList()
        Dim oDataFiller As New clsDataFiller(Me.DSN)

        objPrintHeader = New DataSource.clsRptJurnalPV_Header(Me.DSN)
        With objPrintHeader

            .jurnal_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("jurnal_id"), String.Empty)
            .curr = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("currency_name"), String.Empty)
            Me.parCurrency_Name = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("currency_name"), String.Empty)
            Me.parRekanan_Name = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("rekanan_name"), String.Empty)
            Me.parJurnal_Desc = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("jurnal_descr"), String.Empty)
            Me.parCreate_Date = clsUtil.IsDbNull(Format(Me.tbl_Print.Rows(0).Item("created_dt"), "dd-MM-yyyy"), String.Empty)
            Me.parBudget_name = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("budget_name"), String.Empty)
            Me.parAmountRate = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("currency_rate"), 0)
            .channel_id = Me.channel_id

            Me.strchannel_id = .channel_id
            Me.sptChannel_nameReport = .channel_namereport
            Me.sptChannel_address = .channel_address
            Me.id = .jurnal_id
            Me.curr = .curr

            GenerateDataDetail()
        End With
        objDatalistHeader.Add(objPrintHeader)

        Return objDatalistHeader
    End Function
    Private Function GenerateDataDetail() As ArrayList

        Dim i As Integer
        Dim IdrAmount, foreignAmount As Decimal

        '== ari
        Dim dt_accref1 As DataTable = New DataTable
        Dim dt_accref2 As DataTable = New DataTable
        Dim dt_accref3 As DataTable = New DataTable
        Dim dt_accref4 As DataTable = New DataTable
        dt_accref1.Clear()
        dt_accref2.Clear()
        dt_accref3.Clear()
        dt_accref4.Clear()
        clsUtil.DataFill(Me.DSN, dt_accref1, "act_selectAccRef_Detil", "accref_id = 3101") '8500011
        clsUtil.DataFill(Me.DSN, dt_accref2, "act_selectAccRef_Detil", "accref_id = 5801") '1950420
        clsUtil.DataFill(Me.DSN, dt_accref3, "act_selectAccRef_Detil", "accref_id = 5901") '1950430  	 
        clsUtil.DataFill(Me.DSN, dt_accref4, "act_selectAccRef_Detil", "accref_id = 5701") '1950920
        Dim akun1 As String = dt_accref1.Rows(0).Item(0)
        Dim akun2 As String = dt_accref2.Rows(0).Item(0)
        Dim akun3 As String = dt_accref3.Rows(0).Item(0)
        Dim akun4 As String = dt_accref4.Rows(0).Item(0)
        '==

        objDatalistDetil = New ArrayList()
        Me.AmountIdrNew = 0
        Me.AmountForeignNew = 0
        IdrAmount = 0
        foreignAmount = 0
        For i = 0 To Me.tbl_PrintDetil.Rows.Count - 1
            objPrintDetil = New DataSource.clsRptJurnalPV_Detil(Me.DSN)

            With objPrintDetil
                .account_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("acc_id"), 0)
                .jurnal_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("jurnal_id"), String.Empty)
                .DescriptionDetil = Trim(clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("jurnaldetil_descr"), String.Empty))
                .Detil_dk = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("jurnaldetil_dk"), String.Empty)
                If .Detil_dk = "D" Then
                    .bilyet_reqs = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("ref_id"), String.Empty)
                    .date_create = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("entry_date"), "")
                Else
                    .bilyet_reqs = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("jurnal_bilyet"), String.Empty)
                    .date_create = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("entry_date"), String.Empty)
                    .bank_acc = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("bankacc_name"), String.Empty)
                    .type = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("paymenttype_name"), String.Empty)
                End If

                .curr = Me.curr
                .rate = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("jurnaldetil_foreignrate"), 0)
                If .account_id = akun1 Then
                    .foreign = 0
                Else
                    .foreign = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("jurnaldetil_foreign"), 0)
                End If

                If .account_id <> "0" And .account_id <> akun2 And .account_id <> akun3 And .account_id <> akun4 Then
                    If .Detil_dk = "K" Then
                        .idr = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("jurnaldetil_idr"), 0)
                        If .idr <= 0 And .foreign <= 0 Then
                            IdrAmount = .idr * -1
                            foreignAmount = .foreign * -1
                        End If
                        Me.AmountIdrNew += IdrAmount
                        Me.AmountForeignNew += foreignAmount
                    Else
                        .idr = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("jurnaldetil_idr"), 0)
                    End If
                Else
                    .idr = 0
                    .foreign = 0
                End If

                If .idr <= 0 Then
                    .idr = .idr * -1
                End If
                If .foreign <= 0 Then
                    .foreign = .foreign * -1
                End If
            End With
            objDatalistDetil.Add(objPrintDetil)
        Next

        Return objDatalistDetil
    End Function
    Private Sub dlgRptJurnalPV_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim oDataFiller As New clsDataFiller(Me.DSN)

        oDataFiller.DataFill(Me.tbl_Print, "act_RptJurnalPV_SelectHeader", String.Format(" jurnal_id = '{0}'", Me.jurnal_id), Me.channel_id)
        oDataFiller.DataFill(Me.tbl_PrintDetil, "act_RptJurnalPV_SelectDetil", String.Format(" jurnal_id = '{0}'", Me.jurnal_id))

        If Me.tbl_Print.Rows.Count = 0 Then
            MsgBox("No data")
            Me.Close()
            Exit Sub
        End If

        Me.GenerateReport()

        Me.ReportViewer1.RefreshReport()

    End Sub

    Public Sub SubreportProcessing(ByVal sender As Object, ByVal e As Microsoft.Reporting.WinForms.SubreportProcessingEventArgs)
        e.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("ACT_FINANCE_DataSource_clsRptJurnalPV_Detil", objDatalistDetil))
    End Sub

    Public Sub New(ByVal strDSN As String, ByVal sptServer As String, _
                    ByVal jurnal_id As String, ByVal channel_id As String)

        Me.DSN = strDSN
        Me.sptServer = sptServer
        Me.jurnal_id = jurnal_id
        Me.channel_id = channel_id

        InitializeComponent()
    End Sub
End Class