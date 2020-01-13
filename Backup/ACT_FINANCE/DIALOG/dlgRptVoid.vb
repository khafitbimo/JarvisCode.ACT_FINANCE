'================================================== 
' Yanuar Andriyana Putra
' TransTV
' Created Date: 9/21/2010 9:01 AM

Public Class dlgRptVoid

    Private DSN As String
    Private void_id As String
    Private SptServer As String
    Private channel_id As String

    Private parJurnalType_id As String
    Private parJurnal_Source As String
    Private parJurnal_BookDate As String
    Private parPeriode_Name As String
    Private parCurrency_Name As String
    Private parJurnal_AmountForeign As String
    Private parRekanan_Name As String
    Private parJurnal_Desc As String

    Private sptchannel_domainname As String
    Private sptChannel_nameReport As String
    Private sptChannel_address As String
    Private sptChannel_telp1 As String
    Private strchannel_id As String
    Private objPrintDetil As DataSource.clsRptVoid
    Private objDatalistDetil As ArrayList

    Private tbl_TrnPrint As DataTable = New DataTable
    Private tbl_TrnPrintDetil As DataTable = clsDataset.CreateTblTrnJurnaldetil()


#Region " Constructor "

    Public Sub New(ByVal strDSN As String, ByVal sptServer As String, _
                    ByVal void_id As String, ByVal channel_id As String)
        Me.DSN = strDSN
        Me.SptServer = sptServer
        Me.void_id = void_id
        Me.channel_id = channel_id

        InitializeComponent()
    End Sub

#End Region

    Private Function GenerateReport() As Boolean

        Dim objRdsH As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Dim objReportH As Microsoft.Reporting.WinForms.LocalReport = New Microsoft.Reporting.WinForms.LocalReport
        Dim objRdsD As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Dim objReportD As Microsoft.Reporting.WinForms.LocalReport = New Microsoft.Reporting.WinForms.LocalReport
        Dim objDatalistHeader As ArrayList = New ArrayList()
        Dim objReportViewer As Microsoft.Reporting.WinForms.ReportViewer = New Microsoft.Reporting.WinForms.ReportViewer

      
        objDatalistHeader = Me.GenerateDataDetail()

        'Dim parRptImageURL As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("imageURL", Me.SptServer)

        '============ tambahan by ari prasasti <parameter global> 20 April 2012
        Dim dt As DataTable = New DataTable

        dt.Clear()

        clsUtil.DataFill(Me.DSN, dt, "act_select_channel", Me.channel_id)

        'fill variabel global
        Dim fileUrl As String = CStr(dt.Rows(0).Item("channel_domainname"))

        '---------------tambahan buat insosys baru 2012-- 19 April 2012---------------
        fileUrl = fileUrl.Replace("\", "/")
        fileUrl = "file:///" & fileUrl & "/services/live/solutions/images/" & Me.channel_id & ".jpg"
        '---------------------------------------------------------------

        Dim parRptImageURL As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("imageURL", fileUrl)

        '===end tambahan
        Dim parRptChannel_namereport As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("channel_name", Me.sptChannel_nameReport)
        Dim parRptChannel_address As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("channel_address", Me.sptChannel_address)
        Dim parRptChannel_ID As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("channel_id", Me.strchannel_id)

        'Dim parRptJurnalTypeID As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("jurnaltype_id", Me.parJurnalType_id)
        'Dim parRptJurnal_Source As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("jurnal_source", Me.parJurnal_Source)
        'Dim parRptJurnal_BookDate As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("jurnal_bookdate", Me.parJurnal_BookDate)
        'Dim parRptPeriodeName As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("periode_name", Me.parPeriode_Name)
        'Dim parRptCurrencyName As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("currency_name", Me.parCurrency_Name)
        'Dim parRptJurnal_AmountForeign As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("jurnal_amountforeign", Me.parJurnal_AmountForeign)
        'Dim parRptRekananName As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("rekanan_name", Me.parRekanan_Name)
        'Dim parRptJurnal_Desc As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("jurnal_descr", Me.parJurnal_Desc)

        objRdsH.Name = "ACT_FINANCE_DataSource_clsRptVoid"
        objRdsH.Value = objDatalistHeader

        'If Me.tbl_TrnPrint.Rows(0).Item("jurnal_source") = "PV-ListAdvance" Then
        objReportH.ReportEmbeddedResource = "ACT_FINANCE.RptVoid.rdlc"
        'ElseIf Me.tbl_TrnPrint.Rows(0).Item("jurnal_source") = "PV-ListAP" Then
        ' objReportH.ReportEmbeddedResource = "ACT_FINANCE.rptJurnal_PV_ListAP_Header.rdlc"
        ' ElseIf Me.tbl_TrnPrint.Rows(0).Item("jurnal_source") = "PV-Manual" Then
        ' objReportH.ReportEmbeddedResource = "ACT_FINANCE.rptJurnal_PV_Manual_Header.rdlc"
        'ElseIf Me.tbl_TrnPrint.Rows(0).Item("jurnal_source") = "PV-ListTax" Then
        'objReportH.ReportEmbeddedResource = "ACT_FINANCE.rptJurnal_PV_Tax_Header.rdlc"

        ' End If

        objReportH.DataSources.Add(objRdsH)
        'AddHandler objReportViewer.LocalReport.SubreportProcessing, AddressOf SubreportProcessing
        objReportViewer.LocalReport.ReportEmbeddedResource = objReportH.ReportEmbeddedResource
        objReportViewer.Name = "ReportViewer1"
        objReportViewer.LocalReport.EnableExternalImages = True
        objReportViewer.LocalReport.DataSources.Clear()
        objReportViewer.LocalReport.DataSources.Add(objRdsH)
        objReportViewer.LocalReport.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter() {parRptImageURL, parRptChannel_namereport, parRptChannel_address, parRptChannel_ID})

        objReportViewer.RefreshReport()
        Me.SuspendLayout()
        Me.Controls.Remove(Me.ReportViewer1)
        Me.ReportViewer1 = Nothing
        Me.ReportViewer1 = objReportViewer
        Me.Controls.Add(Me.ReportViewer1)
        Me.ResumeLayout()
        Me.ReportViewer1.Dock = DockStyle.Fill

    End Function
    Private Function GenerateDataHeader() As ArrayList
        Dim objDatalistHeader As ArrayList = New ArrayList()
        'Dim objPrintHeader As DataSource.clsRptJurnal_Header

        'objPrintHeader = New DataSource.clsRptJurnal_Header
        'With objPrintHeader
        '    .jurnal_id = clsUtil.IsDbNull(Me.tbl_TrnPrint.Rows(0).Item("jurnal_id"), String.Empty)
        '    Me.parJurnalType_id = clsUtil.IsDbNull(Me.tbl_TrnPrint.Rows(0).Item("jurnaltype_id"), String.Empty)
        '    Me.parJurnal_Source = clsUtil.IsDbNull(Me.tbl_TrnPrint.Rows(0).Item("jurnal_source"), String.Empty)
        '    Me.parJurnal_BookDate = clsUtil.IsDbNull(Format(Me.tbl_TrnPrint.Rows(0).Item("jurnal_bookdate"), "dd/MMM/yyyy"), Now.Date)
        '    Me.parPeriode_Name = clsUtil.IsDbNull(Me.tbl_TrnPrint.Rows(0).Item("periode_name"), String.Empty)
        '    Me.parJurnal_Desc = clsUtil.IsDbNull(Me.tbl_TrnPrint.Rows(0).Item("jurnal_descr"), String.Empty)
        '    Me.parRekanan_Name = Trim(clsUtil.IsDbNull(Me.tbl_TrnPrint.Rows(0).Item("rekanan_name"), String.Empty))
        '    Me.parCurrency_Name = clsUtil.IsDbNull(Trim(Me.tbl_TrnPrint.Rows(0).Item("currency_name")), String.Empty)
        '    Me.parJurnal_AmountForeign = clsUtil.IsDbNull(Format(Me.tbl_TrnPrint.Rows(0).Item("jurnal_amountforeign"), "#,##0"), 0)
        '    .jurnal_createby = clsUtil.IsDbNull(Me.tbl_TrnPrint.Rows(0).Item("created_by_name"), String.Empty)
        '    .jurnal_createdate = clsUtil.IsDbNull(Me.tbl_TrnPrint.Rows(0).Item("jurnal_iscreatedate"), Now.Date)
        '    .jurnal_postby = clsUtil.IsDbNull(Me.tbl_TrnPrint.Rows(0).Item("post_by_name"), String.Empty)

        Me.GenerateDataDetail()
        'End With
        'objDatalistHeader.Add(objPrintHeader)

        Return objDatalistHeader
    End Function
    Private Function GenerateDataDetail() As ArrayList
        Dim i As Integer

        Dim objDatalistHeader As ArrayList = New ArrayList()
        For i = 0 To Me.tbl_TrnPrint.Rows.Count - 1
            objPrintDetil = New DataSource.clsRptVoid(Me.DSN)
            With objPrintDetil
                .circulation_id = clsUtil.IsDbNull(Me.tbl_TrnPrint.Rows(i).Item("circulation_id"), String.Empty)
                .circulation_ref = clsUtil.IsDbNull(Me.tbl_TrnPrint.Rows(i).Item("ref"), String.Empty)
                .rekanan_name = clsUtil.IsDbNull(Me.tbl_TrnPrint.Rows(i).Item("rekanan"), String.Empty)
                .descr = clsUtil.IsDbNull(Me.tbl_TrnPrint.Rows(i).Item("jurnal_descr"), String.Empty)
                .bilyet = clsUtil.IsDbNull(Me.tbl_TrnPrint.Rows(i).Item("bilyet"), String.Empty)
                .amount_sum = clsUtil.IsDbNull(Me.tbl_TrnPrint.Rows(i).Item("amount_sum"), String.Empty)
                .channel_id = clsUtil.IsDbNull(Me.tbl_TrnPrint.Rows(i).Item("channel_id"), String.Empty)
                .void_id = clsUtil.IsDbNull(Me.tbl_TrnPrint.Rows(i).Item("void_id"), String.Empty)
                .createdate = clsUtil.IsDbNull(Me.tbl_TrnPrint.Rows(i).Item("createdate"), String.Empty)

                Me.strchannel_id = .channel_id
                Me.sptChannel_nameReport = .channel_namereport
                Me.sptChannel_address = .channel_address

            End With
            objDatalistHeader.Add(objPrintDetil)
        Next

        Return objDatalistHeader
    End Function

    'Public Sub SubreportProcessing(ByVal sender As Object, ByVal e As Microsoft.Reporting.WinForms.SubreportProcessingEventArgs)
    '    e.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("ACT_FINANCE_DataSource_clsRptJurnal_Detil", objDatalistDetil))
    'End Sub

    Private Sub dlgTrnJurnalPrint_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim oDataFiller As New clsDataFiller(Me.DSN)

        Me.tbl_TrnPrint.Clear()
        Me.tbl_TrnPrintDetil.Clear()

        oDataFiller.DataFill(Me.tbl_TrnPrint, "act_TrnVoid_Advance_SelectForPrint", String.Format("void_id='{0}'", Me.void_id))
        'oDataFiller.DataFill(Me.tbl_TrnPrintDetil, "act_RptJurnal_SelectDetil", String.Format("jurnal_id='{0}' AND channel_id = '{1}' ORDER BY A.jurnaldetil_foreign DESC", Me.void_id, Me.channel_id))

        If Me.tbl_TrnPrint.Rows.Count = 0 Then
            MsgBox("No data")
            Me.Close()
        End If

        Me.GenerateReport()
        Me.ReportViewer1.RefreshReport()
    End Sub
End Class
