''Ari Prasasti
''Trans TV
''27 06 2012

Imports System.Windows.Forms

Public Class dlgContractChoice
    Private DSN As String
    Private tbl_listrek As DataTable = clsDataset.CreateTblTrnContract()
    Private tbl_TrnBankTransfer As DataTable = clsDataset.CreateTblTrnBanktransfer()
    Private myOwner As System.Windows.Forms.IWin32Window
    Private retObj As Object
    Private channel As String
    Private user_name As String
    Private tbl_MstChannelBank As DataTable = clsDataset.CreateTblMstChannelBank()
#Region "Format DGV"
    Private Function FormatDgvDetil(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        Dim cbank_name As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim ccheck As System.Windows.Forms.DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Dim cshow_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cepisode As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim ccurrency_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim ccontract_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cbank_receivedby As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cbank_account As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cbank_amountidr As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cbank_foreignrate As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cbank_foreign As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cbank_transferidr As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cArtist As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cbank_transferforeign As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cpv_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cpv_line As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cpv_amount As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim ccurr_name As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn


        ccheck.Name = "check"
        ccheck.HeaderText = "Pilih"
        ccheck.DataPropertyName = "check"
        ccheck.Width = 40
        ccheck.Visible = True
        ccheck.ReadOnly = False

        cbank_name.Name = "bank_name"
        cbank_name.HeaderText = "Bank"
        cbank_name.DataPropertyName = "bank_name"
        cbank_name.Width = 90
        cbank_name.Visible = True
        cbank_name.ReadOnly = True
        'cJurnal_id.DefaultCellStyle.BackColor = Color.Gainsboro

        cshow_id.Name = "show_id"
        cshow_id.HeaderText = "Show ID"
        cshow_id.DataPropertyName = "show_id"
        cshow_id.Width = 85
        cshow_id.Visible = True
        cshow_id.ReadOnly = True

        cepisode.Name = "episode"
        cepisode.HeaderText = "Episode"
        cepisode.DataPropertyName = "episode"
        cepisode.Width = 85
        cepisode.Visible = True
        cepisode.ReadOnly = True

        ccurrency_id.Name = "currency_id"
        ccurrency_id.HeaderText = "Curr ID"
        ccurrency_id.DataPropertyName = "currency_id"
        ccurrency_id.Width = 40
        ccurrency_id.Visible = False
        ccurrency_id.ReadOnly = True 

        ccurr_name.Name = "currency_name"
        ccurr_name.HeaderText = "Curr"
        ccurr_name.DataPropertyName = "currency_name"
        ccurr_name.Width = 40
        ccurr_name.Visible = True
        ccurr_name.ReadOnly = True

        ccontract_id.Name = "contract_id"
        ccontract_id.HeaderText = "Contract."
        ccontract_id.DataPropertyName = "contract_id"
        ccontract_id.Width = 60
        ccontract_id.Visible = True
        ccontract_id.ReadOnly = True

        cbank_receivedby.Name = "bank_receivedby"
        cbank_receivedby.HeaderText = "Bank Received By"
        cbank_receivedby.DataPropertyName = "bank_receivedby"
        cbank_receivedby.Width = 170
        cbank_receivedby.Visible = True
        cbank_receivedby.ReadOnly = True

        cpv_line.Name = "pv_line"
        cpv_line.HeaderText = "PV line"
        cpv_line.DataPropertyName = "pv_line"
        cpv_line.Width = 60
        cpv_line.Visible = True
        cpv_line.ReadOnly = True 

        cbank_account.Name = "bank_account"
        cbank_account.HeaderText = "Bank Acc."
        cbank_account.DataPropertyName = "bank_account"
        cbank_account.Width = 100
        cbank_account.Visible = True
        cbank_account.ReadOnly = True 

        cbank_amountidr.Name = "bank_amountidr"
        cbank_amountidr.HeaderText = "Amount IDR"
        cbank_amountidr.DataPropertyName = "bank_amountidr"
        cbank_amountidr.Width = 100
        cbank_amountidr.Visible = True
        cbank_amountidr.ReadOnly = True
        cbank_amountidr.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cbank_amountidr.DefaultCellStyle.Format = "#,##0.00"

        cbank_foreignrate.Name = "bank_foreignrate"
        cbank_foreignrate.HeaderText = "Bank Rate"
        cbank_foreignrate.DataPropertyName = "bank_foreignrate"
        cbank_foreignrate.Width = 100
        cbank_foreignrate.Visible = True
        cbank_foreignrate.ReadOnly = True
        'cbank_foreignrate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'cbank_foreignrate.DefaultCellStyle.Format = "#,##0.00"

        cbank_foreign.Name = "bank_amountforeign"
        cbank_foreign.HeaderText = "Bank Foreign"
        cbank_foreign.DataPropertyName = "bank_amountforeign"
        cbank_foreign.Width = 125
        cbank_foreign.Visible = True
        cbank_foreign.ReadOnly = True
        cbank_foreign.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cbank_foreign.DefaultCellStyle.Format = "#,##0.00"

        cbank_transferidr.Name = "bank_transferidr"
        cbank_transferidr.HeaderText = "Bank Trf IDR"
        cbank_transferidr.DataPropertyName = "bank_transferidr"
        cbank_transferidr.Width = 125
        cbank_transferidr.Visible = True
        cbank_transferidr.ReadOnly = True
        cbank_transferidr.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cbank_transferidr.DefaultCellStyle.Format = "#,##0.00"

        cArtist.Name = "Artist"
        cArtist.HeaderText = "Artist"
        cArtist.DataPropertyName = "Artist"
        cArtist.Width = 80
        cArtist.Visible = True
        cArtist.ReadOnly = True
        'cJurnaldetil_receive_foreignrate.DefaultCellStyle.BackColor = Color.Gainsboro

        cbank_transferforeign.Name = "bank_transferforeign"
        cbank_transferforeign.HeaderText = "Bank Trf Foreign"
        cbank_transferforeign.DataPropertyName = "bank_transferforeign"
        cbank_transferforeign.Width = 75
        cbank_transferforeign.Visible = True
        cbank_transferforeign.ReadOnly = True
        cbank_transferforeign.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cbank_transferforeign.DefaultCellStyle.Format = "#,##0.00"

        cpv_id.Name = "pv_id"
        cpv_id.HeaderText = "PV ID"
        cpv_id.DataPropertyName = "pv_id"
        cpv_id.Width = 100
        cpv_id.Visible = True
        cpv_id.ReadOnly = True

        cpv_amount.Name = "pv_amount"
        cpv_amount.HeaderText = "PV Amount"
        cpv_amount.DataPropertyName = "pv_amount"
        cpv_amount.Width = 150
        cpv_amount.Visible = True
        cpv_amount.ReadOnly = True
        cpv_amount.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cpv_amount.DefaultCellStyle.Format = "#,##0.00"


        objDgv.AutoGenerateColumns = False

        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
        {ccheck, ccontract_id, cbank_name, cbank_account, cbank_receivedby, ccurrency_id, ccurr_name, cbank_amountidr, _
        cbank_foreignrate, cbank_foreign, cshow_id, cepisode, cArtist, cpv_id, cpv_line, _
         cbank_transferforeign, cbank_transferidr, cpv_amount})


        objDgv.AllowUserToAddRows = False
        objDgv.AllowUserToDeleteRows = False
        objDgv.AllowUserToResizeRows = False
        'objDgv.ReadOnly = True
        objDgv.SelectionMode = DataGridViewSelectionMode.CellSelect
        objDgv.MultiSelect = False
        'objDgv.Columns("jurnaldetil_line").Frozen = True

    End Function
#End Region
    Public Sub New(ByVal strDSN As String, ByVal tbl_listrek As DataTable, ByVal channel As String, ByVal user_name As String)
        InitializeComponent()
        Me.DSN = strDSN
        Me.tbl_listrek = tbl_listrek
        Me.channel = channel
        Me.user_name = user_name
    End Sub
    Public Shadows Function OpenDialog(ByVal owner As System.Windows.Forms.IWin32Window) As Object
        Me.myOwner = owner
        MyBase.ShowDialog(owner)
        Return retObj
    End Function 
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ok.Click
        Dim obj As Button = sender
        Dim row As DataRow
        Dim oDataFiller As New clsDataFiller(Me.DSN)

        If obj.Name = "btn_ok" Then
            Dim tbl_trnBank_Temp As DataTable = clsDataset.CreateTblTrnBanktransfer()

            Me.tbl_TrnBankTransfer.Clear()
            'tbl_trnBank_Temp.Clear()
            tbl_trnBank_Temp = Me.tbl_listrek.Copy()
            tbl_trnBank_Temp.DefaultView.RowFilter = "check = 'True'"

            If Me.dgvContract.CurrentRow IsNot Nothing Then
                If tbl_trnBank_Temp.DefaultView.Count > 0 Then
                    For i As Integer = 0 To tbl_trnBank_Temp.Rows.Count - 1

                        If clsUtil.IsDbNull(tbl_trnBank_Temp.Rows(i).Item("check"), "False") = "True" Then
                            row = Me.tbl_TrnBankTransfer.NewRow

                            row.Item("jurnal_id") = tbl_trnBank_Temp.Rows(i).Item("pv_id")
                            row.Item("jurnaldetil_line") = tbl_trnBank_Temp.Rows(i).Item("pv_line")
                            row.Item("banktransfer_dt") = (Now.AddDays(+5).Date) 'default date
                            row.Item("slipformat_id") = "SF070022"
                            row.Item("rekanan_id") = tbl_trnBank_Temp.Rows(i).Item("item_id")
                            row.Item("rekananbank_line") = 0
                            row.Item("banktransfer_rekening") = tbl_trnBank_Temp.Rows(i).Item("bank_account")
                            row.Item("purposefund_id") = 1

                            If clsUtil.IsDbNull(row.Item("paymenttype_id"), 0) = "4" Then
                                'row.Item("channelbank_line") = 1
                                Me.tbl_MstChannelBank.Clear()
                                oDataFiller.DataFill(Me.tbl_MstChannelBank, "ms_MstChannelBank_Select", String.Format("channel_id = '{0}' AND channelbank_line = {1} ", Me.channel, tbl_trnBank_Temp.Rows(i).Item("currency_id")))
                                If Me.tbl_MstChannelBank.Rows.Count > 0 Then
                                    row.Item("rekening_debit") = Me.tbl_MstChannelBank.Rows(0).Item("channelbank_rekening")
                                    row.Item("bank_debit") = Me.tbl_MstChannelBank.Rows(0).Item("channelbank_name")
                                    row.Item("account_bank_debit") = Me.tbl_MstChannelBank.Rows(0).Item("channelbank_accountname")
                                Else
                                    row.Item("rekening_debit") = String.Empty
                                    row.Item("bank_debit") = String.Empty
                                    row.Item("account_bank_debit") = String.Empty
                                End If
                            Else
                                row.Item("channelbank_line") = 0
                                row.Item("rekening_debit") = String.Empty
                                row.Item("bank_debit") = String.Empty
                                row.Item("account_bank_debit") = String.Empty
                            End If
                            row.Item("banktransfer_pembayaranrek") = tbl_trnBank_Temp.Rows(i).Item("bank_name")

                            'CType(1.0, Decimal)
                            row.Item("currency_id") = tbl_trnBank_Temp.Rows(i).Item("currency_id")

                            row.Item("channel_id") = Me.channel
                            row.Item("banktransfer_isdisabled") = 0
                            row.Item("banktransfer_invoice") = ""
                            row.Item("banktransfer_message") = tbl_trnBank_Temp.Rows(i).Item("bank_receivedby")
                            row.Item("banktransfer_episode1") = 0
                            row.Item("banktransfer_episode2") = 0
                            row.Item("project_id") = tbl_trnBank_Temp.Rows(i).Item("show_id")
                            row.Item("rekananartis_id") = 0
                            row.Item("banktransfer_episode") = ""
                            row.Item("channelbank_line") = 1
                            row.Item("banktransfer_create_by") = Me.user_name
                            row.Item("banktransfer_create_date") = Date.Now.Date
                            '---
                            'If tbl_trnBank_Temp.Rows(0).Item("bank_name").ToString.Trim = "Bank Mega" Then

                            '    row.Item("banktransfer_idr") = tbl_trnBank_Temp.Rows(i).Item("bank_amountidr")
                            '    row.Item("banktransfer_foreign") = tbl_trnBank_Temp.Rows(i).Item("bank_amountforeign")
                            '    row.Item("banktransfer_foreignrate") = tbl_trnBank_Temp.Rows(i).Item("bank_foreignrate")
                            '    row.Item("banktransfer_bi_idr") = tbl_trnBank_Temp.Rows(i).Item("bank_transferidr") '5000
                            '    row.Item("banktransfer_bi_foreign") = tbl_trnBank_Temp.Rows(i).Item("bank_transferforeign") '5000

                            'End If

                            row.Item("banktransfer_idr") = tbl_trnBank_Temp.Rows(i).Item("bank_amountidr")
                            row.Item("banktransfer_foreign") = tbl_trnBank_Temp.Rows(i).Item("bank_amountforeign")
                            row.Item("banktransfer_foreignrate") = tbl_trnBank_Temp.Rows(i).Item("bank_foreignrate")
                            row.Item("banktransfer_bi_idr") = tbl_trnBank_Temp.Rows(i).Item("bank_transferidr") '5000
                            row.Item("banktransfer_bi_foreign") = tbl_trnBank_Temp.Rows(i).Item("bank_transferforeign") '5000 
                            'row.Item("banktransfer_bi_foreign") = 5000
                            'row.Item("banktransfer_bi_idr") = 5000
                            '---
                            row.Item("jurnalbilyet_receiveperson") = Me.user_name 'retTbl.Rows(0).Item("jurnalbilyet_receiveperson") 'retTbl.Rows(0).Item("penerima_name")
                            If clsUtil.IsDbNull(tbl_trnBank_Temp.Rows(i).Item("bank_account"), "") <> "" Then
                                row.Item("paymenttype_id") = 4
                            Else
                                row.Item("paymenttype_id") = 1
                            End If

                            row.Item("jurnalbilyet_receiverekening") = tbl_trnBank_Temp.Rows(i).Item("bank_account")
                            row.Item("jurnalbilyet_receivebank") = tbl_trnBank_Temp.Rows(i).Item("bank_name")
                            row.Item("jurnalbilyet_receiveaccountname") = tbl_trnBank_Temp.Rows(i).Item("bank_receivedby")
                            row.Item("banktransfer_episode") = tbl_trnBank_Temp.Rows(i).Item("episode")
                            Me.tbl_TrnBankTransfer.Rows.Add(row)
                        End If


                    Next
                End If
            End If
        End If

        Me.retObj = Me.tbl_TrnBankTransfer
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancel.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub dlgContractChoice_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.FormatDgvDetil(dgvContract)
        Me.dgvContract.DataSource = tbl_listrek
    End Sub
End Class
