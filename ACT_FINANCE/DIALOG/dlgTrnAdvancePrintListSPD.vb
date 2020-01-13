Imports System.Windows.Forms
Public Class dlgTrnAdvancePrintListSPD
    Private criteria As String
    Private DSN As String
    Private channel_id As String
    Private advance_id As String

    Private tbl_TrnAdvance As DataTable = clsDataset.CreateTblTrnAdvance()
    Private tbl_TrnAdvanceDetil As DataTable = clsDataset.CreateTblTrnAdvancedetil()
    Private tbl_TrnAdvanceItemDetil As DataTable = clsDataset.CreateTblTrnAdvanceItemDetil()
    Private tbl_PrintAdvanceListOrderDetil As DataTable = clsDataset.CreateTblTrnPrintAdvanceListOrder()
    Private objPrintHeader As DataSource.ClsRptAdvanceHeader
    Private objPrintDetil As DataSource.ClsRptAdvanceDetil
    Private objDatalistDetil As ArrayList

    Private sptServer As String
    Private strchannel_id As String
    Private ref As String
    Private total_amount As Decimal
    Private id As String

    Private sptchannel_domainname As String
    Private sptChannel_nameReport As String
    Private sptChannel_address As String
    Private sptChannel_telp1 As String
    Private adv_req As Decimal
    Private sptDomain As String
    Private budget_id As Decimal

    Private approved1_by As String
    Private approved2_by As String
    Private approved3_by As String
    Private approved4_by As String
    Private approved5_by As String
    Private approved6_by As String
    Private approved7_by As String

    Private titleapp1 As String
    Private titleapp2 As String
    Private titleapp3 As String
    Private titleapp4 As String
    Private titleapp5 As String
    Private titleapp6 As String
    Private titleapp7 As String

    Private sptChannel_fax As String

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Function GenerateDataHeader() As ArrayList
        Dim objDatalistHeader As ArrayList = New ArrayList()
        Dim oDataFiller As New clsDataFiller(Me.DSN)

        Dim tbl_approved As DataTable = New DataTable

        Dim criteria2 As String

        Dim i As Integer

        objPrintHeader = New DataSource.ClsRptAdvanceHeader(Me.DSN)

        With objPrintHeader
            criteria2 = String.Format("advance_id='{0}'", Me.tbl_TrnAdvance.Rows(0).Item("advance_id"))

            .ref_no = clsUtil.IsDbNull(Me.tbl_TrnAdvance.Rows(i).Item("advance_id"), String.Empty)
            .Advance_Descr = clsUtil.IsDbNull(Me.tbl_TrnAdvance.Rows(i).Item("advance_descr"), String.Empty)
            .request_date = clsUtil.IsDbNull(Me.tbl_TrnAdvance.Rows(i).Item("advance_entrydt"), String.Empty)
            .request_by = clsUtil.IsDbNull(Me.tbl_TrnAdvance.Rows(i).Item("advance_usedby"), String.Empty)
            .payment_to = clsUtil.IsDbNull(Me.tbl_TrnAdvance.Rows(i).Item("advance_userpic"), String.Empty)
            .payment_address = clsUtil.IsDbNull(Me.tbl_TrnAdvance.Rows(i).Item("advance_prepareloc"), String.Empty)
            .Budget_id = clsUtil.IsDbNull(Me.tbl_TrnAdvance.Rows(i).Item("budget_id"), 0)
            .channel_id = clsUtil.IsDbNull(Me.tbl_TrnAdvance.Rows(i).Item("channel_id"), String.Empty)
            '.adv_req = clsUtil.IsDbNull(Me.tbl_TrnAdvance.Rows(i).Item("advance_idrreal"), String.Empty)
            .eps_start = clsUtil.IsDbNull(Me.tbl_TrnAdvance.Rows(i).Item("advance_epsstart"), String.Empty)
            .eps_end = clsUtil.IsDbNull(Me.tbl_TrnAdvance.Rows(i).Item("advance_epsend"), String.Empty)

            .Department = clsUtil.IsDbNull(Me.tbl_TrnAdvance.Rows(i).Item("strukturunit_name"), String.Empty)
            .Program = clsUtil.IsDbNull(Me.tbl_TrnAdvance.Rows(i).Item("budget_name"), String.Empty)
            .currency_name = clsUtil.IsDbNull(Me.tbl_TrnAdvance.Rows(i).Item("currency_shortname"), String.Empty)
            .Budget_name = clsUtil.IsDbNull(Me.tbl_TrnAdvance.Rows(i).Item("budget_name"), String.Empty)
            .budget_amount = clsUtil.IsDbNull(Me.tbl_TrnAdvance.Rows(i).Item("budget_amount"), String.Empty)

            .rekanan_id = clsUtil.IsDbNull(Me.tbl_TrnAdvance.Rows(i).Item("rekanan_name"), String.Empty)
            .Payment_type = clsUtil.IsDbNull(Me.tbl_TrnAdvance.Rows(i).Item("paymenttype_name"), String.Empty)
            .Payment_date = clsUtil.IsDbNull(Me.tbl_TrnAdvance.Rows(i).Item("advance_preparedt"), String.Empty)

            tbl_approved.Clear()
            tbl_approved = Me.getApprovedFromTravel(clsUtil.IsDbNull(Me.tbl_TrnAdvance.Rows(i).Item("advance_id"), String.Empty))

            Me.approved1_by = clsUtil.IsDbNull(tbl_approved.Rows(0).Item("approved1_by"), "")
            Me.approved2_by = clsUtil.IsDbNull(tbl_approved.Rows(0).Item("approved2_by"), "")
            Me.approved3_by = clsUtil.IsDbNull(tbl_approved.Rows(0).Item("approved3_by"), "")
            Me.approved4_by = clsUtil.IsDbNull(tbl_approved.Rows(0).Item("approved4_by"), "")
            Me.approved5_by = clsUtil.IsDbNull(tbl_approved.Rows(0).Item("approved5_by"), "")
            Me.approved6_by = clsUtil.IsDbNull(tbl_approved.Rows(0).Item("approved6_by"), "")
            Me.approved7_by = clsUtil.IsDbNull(tbl_approved.Rows(0).Item("approved7_by"), "")
            Me.titleapp1 = clsUtil.IsDbNull(tbl_approved.Rows(0).Item("titleapp1"), "")
            Me.titleapp2 = clsUtil.IsDbNull(tbl_approved.Rows(0).Item("titleapp2"), "")
            Me.titleapp3 = clsUtil.IsDbNull(tbl_approved.Rows(0).Item("titleapp3"), "")
            Me.titleapp4 = clsUtil.IsDbNull(tbl_approved.Rows(0).Item("titleapp4"), "")
            Me.titleapp5 = clsUtil.IsDbNull(tbl_approved.Rows(0).Item("titleapp5"), "")
            Me.titleapp6 = clsUtil.IsDbNull(tbl_approved.Rows(0).Item("titleapp6"), "")
            Me.titleapp7 = clsUtil.IsDbNull(tbl_approved.Rows(0).Item("titleapp7"), "")

            Me.id = .ref_no
            Me.total_amount = .adv_req
            Me.strchannel_id = .channel_id
            Me.sptChannel_nameReport = .channel_namereport
            Me.sptChannel_address = .channel_address
            Me.sptDomain = .domain_name
            Me.sptChannel_telp1 = .channel_telp1
            Me.sptChannel_fax = .channel_fax


            oDataFiller.DataFill(Me.tbl_TrnAdvanceDetil, "vq_TrnAdvanceDetil_Select", criteria2)
            ''''vq_TrnAdvanceDetilListOrder_Select()
            GenerateDataDetail()

            .adv_req = Me.adv_req
            .balance = .budget_amount - .adv_req
        End With
        objDatalistHeader.Add(objPrintHeader)

        Return objDatalistHeader
    End Function

    Private Function GenerateDataDetail() As ArrayList
        'Dim objDatalistDetil As ArrayList = New ArrayList()
        Dim oDataFiller As New clsDataFiller(Me.DSN)
        Dim tbl_departement_temp As DataTable = New DataTable
        Dim tbl_program_temp As DataTable = New DataTable
        Dim tbl_currency As DataTable = New DataTable
        Dim tbl_budget As DataTable = New DataTable
        Dim amount_real, pph_amount, ppn_amount, subtotal, total_pphamount, total_ppnamount, total_subtotal, total_discount As Decimal
        Dim amount_intercompay As Decimal
        Dim i, k As Integer
        Dim no As Integer = 1
        Dim pph_persen, ppn_persen, amount_advance, advancedetil_discount, advancedetil_foreignrate As Decimal
        Dim budget_amountdetail As Decimal
        Dim Budget_amountforeign As Decimal
        Dim currency As Decimal
        Dim total_discountAdv As Decimal = 0

        objDatalistDetil = New ArrayList()


        For i = 0 To Me.tbl_TrnAdvanceDetil.Rows.Count - 1
            objPrintDetil = New DataSource.ClsRptAdvanceDetil(Me.DSN)

            With objPrintDetil
                .no = no
                .descr = clsUtil.IsDbNull(Me.tbl_TrnAdvanceDetil.Rows(i).Item("advancedetil_descr"), String.Empty)
                .budget_amountdetail = clsUtil.IsDbNull(Me.tbl_TrnAdvanceDetil.Rows(i).Item("advancedetil_idrreal"), 0)
                .Budget_amountforeign = clsUtil.IsDbNull(Me.tbl_TrnAdvanceDetil.Rows(i).Item("advancedetil_foreignreal"), 0)
                .rate = clsUtil.IsDbNull(Me.tbl_TrnAdvanceDetil.Rows(i).Item("advancedetil_foreignrate"), 0)
                .currency = clsUtil.IsDbNull(Me.tbl_TrnAdvanceDetil.Rows(i).Item("currency_id"), 0)
                .total_amount = Me.total_amount
                .amount_intercompany = clsUtil.IsDbNull(Me.tbl_TrnAdvanceDetil.Rows(i).Item("amount_intercompany_sum"), 0)
                amount_intercompay = .amount_intercompany

                If clsUtil.IsDbNull(Me.tbl_TrnAdvanceDetil.Rows(i).Item("advancedetil_type"), String.Empty) = 1 Then
                    total_pphamount = 0
                    total_ppnamount = 0
                    total_subtotal = 0
                    total_discount = 0

                    ''''Me.tbl_TrnAdvanceItemDetil.Clear()
                    ''''oDataFiller.DataFill(Me.tbl_TrnAdvanceItemDetil, "vq_TrnAdvanceItemDetil_Selects", String.Format("a.advance_id='{0}' and a.advancedetil_line={1}", Me.tbl_TrnAdvanceDetil.Rows(i).Item("advance_id"), Me.tbl_TrnAdvanceDetil.Rows(i).Item("advancedetil_line")))
                    Me.tbl_PrintAdvanceListOrderDetil.Clear()
                    oDataFiller.DataFill(Me.tbl_PrintAdvanceListOrderDetil, "vq_TrnPrintAdvanceListOrder_Select", String.Format("advance_id='{0}' and advancedetil_line={1}", Me.tbl_TrnAdvanceDetil.Rows(i).Item("advance_id"), Me.tbl_TrnAdvanceDetil.Rows(i).Item("advancedetil_line")))

                    For k = 0 To Me.tbl_PrintAdvanceListOrderDetil.Rows.Count - 1

                        If Mid(clsUtil.IsDbNull(Me.tbl_PrintAdvanceListOrderDetil.Rows(k).Item("order_id"), ""), 1, 2) = "RO" Then
                            advancedetil_discount = clsUtil.IsDbNull(Me.tbl_PrintAdvanceListOrderDetil.Rows(k).Item("advancedetil_discount"), 0)
                        Else
                            If clsUtil.IsDbNull(Me.tbl_PrintAdvanceListOrderDetil.Rows(k).Item("advancedetil_discount"), 0) = (clsUtil.IsDbNull(Me.tbl_PrintAdvanceListOrderDetil.Rows(k).Item("orderdetil_discount"), 0) * clsUtil.IsDbNull(Me.tbl_PrintAdvanceListOrderDetil.Rows(k).Item("orderdetil_qty"), 0)) Then
                                advancedetil_discount = Math.Round(clsUtil.IsDbNull(Me.tbl_PrintAdvanceListOrderDetil.Rows(k).Item("advancedetil_discount"), 0), 0, MidpointRounding.ToEven)
                            Else
                                If Me.tbl_PrintAdvanceListOrderDetil.Rows(k).Item("advancedetil_foreignrate") = 1 Then
                                    advancedetil_discount = Math.Round((Math.Round(clsUtil.IsDbNull(Me.tbl_PrintAdvanceListOrderDetil.Rows(k).Item("advancedetil_discount"), 0), 2) * Me.tbl_PrintAdvanceListOrderDetil.Rows(k).Item("orderdetil_qty")), 2, MidpointRounding.AwayFromZero)
                                Else
                                    advancedetil_discount = Math.Round((Math.Round(clsUtil.IsDbNull(Me.tbl_PrintAdvanceListOrderDetil.Rows(k).Item("advancedetil_discount"), 0), 2) * Me.tbl_PrintAdvanceListOrderDetil.Rows(k).Item("orderdetil_qty")), 2, MidpointRounding.AwayFromZero) '(clsUtil.IsDbNull(Me.tbl_PrintAdvanceListOrderDetil.Rows(k).Item("advancedetil_discount"), 0) * clsUtil.IsDbNull(Me.tbl_PrintAdvanceListOrderDetil.Rows(k).Item("orderdetil_qty"), 0))
                                End If

                            End If
                        End If

                        amount_real = (clsUtil.IsDbNull(Me.tbl_PrintAdvanceListOrderDetil.Rows(k).Item("amount_advance"), 0) _
                       * clsUtil.IsDbNull(Me.tbl_PrintAdvanceListOrderDetil.Rows(k).Item("advancedetil_foreignrate"), 0)) _
                       - (advancedetil_discount * _
                       clsUtil.IsDbNull(Me.tbl_PrintAdvanceListOrderDetil.Rows(k).Item("advancedetil_foreignrate"), 0))

                        pph_persen = clsUtil.IsDbNull(Me.tbl_PrintAdvanceListOrderDetil.Rows(k).Item("pph_persen"), 0)
                        ppn_persen = clsUtil.IsDbNull(Me.tbl_PrintAdvanceListOrderDetil.Rows(k).Item("ppn_persen"), 0)
                        amount_advance = clsUtil.IsDbNull(Me.tbl_PrintAdvanceListOrderDetil.Rows(k).Item("amount_advance"), 0)
                        ''''advancedetil_discount = clsUtil.IsDbNull(Me.tbl_PrintAdvanceListOrderDetil.Rows(k).Item("advancedetil_discount"), 0)
                        advancedetil_foreignrate = clsUtil.IsDbNull(Me.tbl_PrintAdvanceListOrderDetil.Rows(k).Item("advancedetil_foreignrate"), 0)
                        pph_amount = Math.Round((((amount_advance - advancedetil_discount) * (pph_persen / 100)) * advancedetil_foreignrate), 2, MidpointRounding.AwayFromZero)
                        ppn_amount = Math.Round((((amount_advance - advancedetil_discount) * (ppn_persen / 100)) * advancedetil_foreignrate), 2, MidpointRounding.AwayFromZero)

                        subtotal = clsUtil.IsDbNull(Me.tbl_PrintAdvanceListOrderDetil.Rows(k).Item("amount_subtotal"), 0) ''''(amount_real + amount_intercompay) + ppn_amount - pph_amount
                        total_pphamount += pph_amount
                        total_ppnamount += ppn_amount
                        total_subtotal += subtotal
                        total_discount += advancedetil_discount ''''clsUtil.IsDbNull(Me.tbl_PrintAdvanceListOrderDetil.Rows(k).Item("advancedetil_discount"), 0)

                        total_discountAdv += advancedetil_discount
                    Next

                    budget_amountdetail += .budget_amountdetail
                    Budget_amountforeign += .Budget_amountforeign

                    currency = .currency

                    'If .currency <> 1 Then
                    '    'PARAM REPORT
                    '    total_pphamount = total_pphamount / .rate
                    '    total_ppnamount = total_ppnamount / .rate
                    '    'total_discount = total_discount / .rate
                    '    total_subtotal = Math.Round((total_subtotal / .rate), 2)
                    '    'Me.adv_req = (.Budget_amountforeign - total_discount) * advancedetil_foreignrate

                    'Else
                    '    'Me.adv_req = (.budget_amountdetail - total_discount)
                    'End If

                ElseIf clsUtil.IsDbNull(Me.tbl_TrnAdvanceDetil.Rows(i).Item("advancedetil_type"), String.Empty) = 0 Then
                    total_pphamount = 0
                    total_ppnamount = 0
                    total_subtotal = 0
                    total_discount = 0
                End If

                .total_discount = total_discount
                .total_pphamount = total_pphamount
                .total_ppnamount = total_ppnamount
                .total_subtotal = total_subtotal

                no = no + 1

            End With
            objDatalistDetil.Add(objPrintDetil)
        Next

        If currency <> 1 Then
            Me.adv_req = (Budget_amountforeign - total_discountAdv) * advancedetil_foreignrate
        Else
            Me.adv_req = (budget_amountdetail - total_discountAdv)
        End If

        Return objDatalistDetil
    End Function

    Private Sub dlgTrnAdvancePrint_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim oDataFiller As New clsDataFiller(Me.DSN)
        ' Dim top As Integer = 0

        Me.tbl_TrnAdvance.Clear()
        Me.tbl_TrnAdvanceDetil.Clear()

        oDataFiller.DataFill(Me.tbl_TrnAdvance, "vq_RptAdvance_Select", criteria)


        If Me.tbl_TrnAdvance.Rows.Count = 0 Then
            MsgBox("No data")
            Me.Close()
        End If

        GenerateReport()
        Me.ReportViewer1.RefreshReport()

    End Sub

    Public Function SetIDCriteria(ByVal str As String) As Boolean
        Me.criteria = str
    End Function

    Private Function GenerateReport() As Boolean
        Dim objRdsH As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Dim objReportH As Microsoft.Reporting.WinForms.LocalReport = New Microsoft.Reporting.WinForms.LocalReport
        Dim objRdsD As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Dim objReportD As Microsoft.Reporting.WinForms.LocalReport = New Microsoft.Reporting.WinForms.LocalReport
        Dim objDatalistHeader As ArrayList = New ArrayList()
        Dim objReportViewer As Microsoft.Reporting.WinForms.ReportViewer = New Microsoft.Reporting.WinForms.ReportViewer
        Dim realization As Decimal = Me.GetRealization(Me.budget_id)

        objDatalistHeader = Me.GenerateDataHeader()
        Dim parRptImageURL As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("imageURL", Me.sptServer)
        Dim parRptChannelID As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("channelID", Me.strchannel_id)
        Dim parRptChannel_namereport As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("channelName", Me.sptChannel_nameReport)
        Dim parRptChannel_address As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("channelAddress", Me.sptChannel_address)
        Dim parRptID As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("id", Me.id)
        Dim parRptDomain As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("p_domain_name", Me.sptDomain)
        Dim parRptRealization As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("p_realization", realization)

        Dim parRptApproved1By As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("p_approved1by", approved1_by)
        Dim parRptApproved2By As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("p_approved2by", approved2_by)
        Dim parRptApproved3By As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("p_approved3by", approved3_by)
        Dim parRptApproved4By As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("p_approved4by", approved4_by)
        Dim parRptApproved5By As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("p_approved5by", approved5_by)
        Dim parRptApproved6By As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("p_approved6by", approved6_by)
        Dim parRptApproved7By As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("p_approved7by", approved7_by)

        Dim parRptTitleApp1 As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("p_titleapp1", titleapp1)
        Dim parRptTitleApp2 As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("p_titleapp2", titleapp2)
        Dim parRptTitleApp3 As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("p_titleapp3", titleapp3)
        Dim parRptTitleApp4 As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("p_titleapp4", titleapp4)
        Dim parRptTitleApp5 As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("p_titleapp5", titleapp5)
        Dim parRptTitleApp6 As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("p_titleapp6", titleapp6)
        Dim parRptTitleApp7 As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("p_titleapp7", titleapp7)

        'Dim parRptChannel_telp1 As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("p_channel_telp1", Me.sptChannel_telp1)
        'Dim parRptChannel_fax As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("p_channel_tax", Me.sptChannel_fax)
        '
        objRdsH.Name = "ACTFINANCE_DataSource_ClsRptAdvanceHeader"
        objRdsH.Value = objDatalistHeader
        '
        'objReportH.ReportEmbeddedResource = "NewAdvance.rptAdvancePrint_HeaderListOrder2.rdlc"
        objReportH.ReportEmbeddedResource = "ACT_FINANCE.rptAdvancePrint_HeaderListSPD.rdlc"
        objReportH.DataSources.Add(objRdsH)

        AddHandler objReportViewer.LocalReport.SubreportProcessing, AddressOf SubreportProcessing
        objReportViewer.Name = "Reportviewer1"
        objReportViewer.LocalReport.ReportEmbeddedResource = objReportH.ReportEmbeddedResource
        objReportViewer.LocalReport.EnableExternalImages = True
        Try
            objReportViewer.LocalReport.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter() _
                                                  {parRptImageURL, parRptChannelID, parRptChannel_namereport, parRptChannel_address, parRptID, _
                                                   parRptDomain, parRptRealization, parRptApproved1By, parRptApproved2By, parRptTitleApp1, _
                                                   parRptTitleApp2, parRptTitleApp3, parRptApproved3By, parRptTitleApp4, _
                                                   parRptTitleApp5, parRptTitleApp6, parRptApproved4By, parRptApproved5By, parRptApproved6By, parRptTitleApp7, parRptApproved7By}) ', parRptChannel_telp1, parRptChannel_fax})
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        ''
        objReportViewer.LocalReport.DataSources.Clear()
        objReportViewer.LocalReport.DataSources.Add(objRdsH)
        objReportViewer.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
        objReportViewer.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.Percent
        objReportViewer.ZoomPercent = 100
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

    'buat narik budget
    Public Function DataFillLimit1(ByRef datatable As DataTable, ByVal procedure As String, ByVal channel_id As String, ByVal criteria As String) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        dbCmd = New OleDb.OleDbCommand(procedure, dbConn)
        If channel_id <> "" Then
            dbCmd.Parameters.Add("@channel_id", Data.OleDb.OleDbType.VarChar)
            dbCmd.Parameters("@channel_id").Value = channel_id
        End If
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@Criteria").Value = criteria

        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)

        Dim cookie As Byte() = Nothing

        Try
            dbConn.Open()
            clsApplicationRole.SetAppRole(dbConn, cookie)
            dbDA.Fill(datatable)
        Catch ex As Exception
            Throw ex
        Finally
            clsApplicationRole.UnsetAppRole(dbConn, cookie)
            dbConn.Close()
        End Try

        Return True

    End Function

    Public Sub SubreportProcessing(ByVal sender As Object, ByVal e As Microsoft.Reporting.WinForms.SubreportProcessingEventArgs)
        e.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("ACTFINANCE_DataSource_ClsRptAdvanceDetil", objDatalistDetil))
    End Sub

    Public Sub New(ByVal strDSN As String, ByVal sptServer As String, _
                    ByVal advance_id As String, ByVal channel_id As String, ByVal budget_id As Decimal)

        Me.DSN = strDSN
        Me.sptServer = sptServer
        Me.advance_id = advance_id
        Me.channel_id = channel_id
        Me.budget_id = budget_id

        InitializeComponent()
    End Sub

    Private Function GetRealization(ByVal budget_id As String) As Decimal
        Dim dbConn As New OleDb.OleDbConnection(Me.DSN)
        Dim cmd As OleDb.OleDbCommand
        Dim res As Decimal
        Dim cookie As Byte() = Nothing

        Try
            dbConn.Open()
            clsApplicationRole.SetAppRole(dbConn, cookie)

            cmd = New OleDb.OleDbCommand("vq_RptBudgetRealization", dbConn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@channel_id", OleDb.OleDbType.VarWChar, 10).Value = Me.channel_id
            cmd.Parameters.Add("@budget_id", OleDb.OleDbType.Numeric, 8).Value = budget_id

            res = cmd.ExecuteScalar()

            Return res
        Catch ex As Exception
            Throw ex
        Finally
            If dbConn.State = ConnectionState.Open Then
                clsApplicationRole.UnsetAppRole(dbConn, cookie)
                dbConn.Close()
            End If
        End Try
    End Function

    Private Function getApprovedFromTravel(ByVal _advance_id As String) As DataTable
        Dim tbl As DataTable = New DataTable


        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter



        dbCmd = New OleDb.OleDbCommand("vq_TrnAdvanceListSPD_SelectApprove_Report", dbConn)

        dbCmd.Parameters.Add("@advance_id", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@advance_id").Value = _advance_id
        dbCmd.CommandType = CommandType.StoredProcedure
        dbCmd.CommandTimeout = 0

        dbDA = New OleDb.OleDbDataAdapter(dbCmd)
        Dim cookie As Byte() = Nothing


        Try
            tbl.Clear()
            dbConn.Open()
            clsApplicationRole.SetAppRole(dbConn, cookie)
            dbDA.Fill(tbl)
        Catch ex As Exception
            Throw ex
        Finally
            clsApplicationRole.UnsetAppRole(dbConn, cookie)
            dbConn.Close()
        End Try

        Return tbl
    End Function

    Public Shared Function CreateTblTrnPrintAdvanceListOrder() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("advance_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("advancedetil_line", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("budgetdetil_line", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("order_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("orderdetil_qty", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("amount_advance", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("advancedetil_foreignrate", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("advancedetil_discount", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("pph_persen", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("ppn_persen", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("amount_subtotal", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("amount_intercompany", GetType(System.Decimal)))

        tbl.Columns("advance_id").DefaultValue = String.Empty
        tbl.Columns("advancedetil_line").DefaultValue = 0
        tbl.Columns("budgetdetil_line").DefaultValue = 0
        tbl.Columns("order_id").DefaultValue = String.Empty
        tbl.Columns("orderdetil_qty").DefaultValue = 0
        tbl.Columns("amount_advance").DefaultValue = 0
        tbl.Columns("advancedetil_foreignrate").DefaultValue = 0
        tbl.Columns("advancedetil_discount").DefaultValue = 0
        tbl.Columns("pph_persen").DefaultValue = 0
        tbl.Columns("ppn_persen").DefaultValue = 0
        tbl.Columns("amount_subtotal").DefaultValue = 0
        tbl.Columns("amount_intercompany").DefaultValue = 0

        Return tbl
    End Function
End Class
