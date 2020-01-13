' Ari Prasasti
' Created Date: 6/29/2012 1:16:20 PM
' 
Imports Microsoft.Win32

Public Class uiRptBankTransfer

#Region "Parameter"
    Private Const mUiName As String = "uiRptBankTransfer"
    Private Const SHOW_SAVE_CONFIRMATION As Boolean = True

    Private Event FormBeforeOpenRow(ByRef id As Object)
    Private Event FormAfterOpenRow(ByRef id As Object)
    Private Event FormBeforeSave(ByRef id As Object)
    Private Event FormAfterSave(ByRef id As Object, ByVal result As FormSaveResult)
    Private Event FormBeforeNew()
    Private Event FormBeforeDelete(ByRef id As Object)
    Private Event FormAfterDelete(ByRef id As Object)

    Private FILTER_QUERY_MODE As Boolean
    Private DATA_ISLOCKED As Boolean

    Private objFormError As Windows.Forms.ErrorProvider = New Windows.Forms.ErrorProvider

    Private tbl_TrnBankTransfer As DataTable = clsDataset.CreateTblTrnBanktransfer2()

    Private tbl_MstSlipFormat As DataTable = clsDataset.CreateTblMstSlipformatCombo()
    Private tbl_MstCurrency As DataTable = clsDataset.CreateTblMstCurrencyCombo()
    Private tbl_MstCurrencysrch As DataTable = clsDataset.CreateTblMstCurrencyCombo()
    Private tbl_MstPaymentType As DataTable = clsDataset.CreateTblMstPaymenttypeCombo()
    Private tbl_MstPurposeFund As DataTable = clsDataset.CreateTblMstPurposefundCombo()
    Private tbl_MstShow As DataTable = clsDataset.CreateTblMstShowCombo
    Private tbl_MstChannelBank As DataTable = clsDataset.CreateTblMstChannelBank()
    Private tbl_listRekening As DataTable = clsDataset.CreateTblTrnContract()
    Private tbl_artist As DataTable = clsDataset.CreateTblMstArtis()
    Private tbl_MstBankacc As DataTable = clsDataset.CreateTblMstBankAccCombo()
    Private WithEvents btnExcel As System.Windows.Forms.ToolStripButton = New System.Windows.Forms.ToolStripButton()

    Private tbl_MstUserSearch As DataTable = clsDataset.CreateTblMstUserCombo()
    Private tbl_srch_show As DataTable = clsDataset.CreateTblMstShowCombo()
    Private rowExcel As Integer = 0
    Private rowCount As Integer = 0
    Private dlgProses As DlgProses

#End Region

#Region " Window Parameter "
    Private _CHANNEL As String = "TTV"
    Private _CHANNEL_CANBE_CHANGED As Boolean = False
    Private _CHANNEL_CANBE_BROWSED As Boolean = False
    Private _PEMBAYARAN_HONOR As Boolean = True
    Private _PEMBAYARAN_TAGIHAN As Boolean = False
    Private _TRANSFER As Boolean = True
    Private _MANUAL As Boolean = False
    Private _slipformat_id As String = "SF070022" 'String.Empty
    Private _purposefund_id As Byte = 0
    Private _paymenttype_id As Byte = 1
    Private _SelectCriteria As String = String.Empty
    Private _rekananartistype_id = 0
    Private _default_bi_idr = 0
    Private _debit_rekening_id = 0
    Private _REGIONAL_CURRENCY = "IDR" 'String.Empty
    ' TODO: Buat variabel untuk menampung parameter window 

#End Region

#Region " Overrides "

    Public Overrides Function btnQuery_Click() As Boolean
        Me.PnlDfSearch.Visible = Not Me.PnlDfSearch.Visible
        If Me.PnlDfSearch.Visible Then
            FILTER_QUERY_MODE = True
            Me.tbtnQuery.CheckState = CheckState.Checked
        Else
            FILTER_QUERY_MODE = False
            Me.tbtnQuery.CheckState = CheckState.Unchecked
        End If
        Return MyBase.btnQuery_Click()
    End Function

    Public Overrides Function btnLoad_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiRptBankTransfer_Retrieve()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnLoad_Click()
    End Function

    Public Overrides Function btnFirst_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiRptBankTransfer_First()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnFirst_Click()
    End Function

    Public Overrides Function btnPrev_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiRptBankTransfer_Prev()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnPrev_Click()
    End Function

    Public Overrides Function btnNext_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiRptBankTransfer_Next()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnNext_Click()
    End Function

    Public Overrides Function btnLast_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiRptBankTransfer_Last()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnLast_Click()
    End Function

    Public Overrides Function btnPrint_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnBanktransfer_Print()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnPrint_Click()
    End Function

    Private Sub btnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Click
        If Me.tbl_TrnBankTransfer.Rows.Count = 0 Then
            MsgBox("Tidak Ada Data Untuk Di Export Ke EXCEL", MsgBoxStyle.Critical, mUiName)
            Exit Sub
        End If

        Call excel()

        'Dim clsExcelFromDgv As New clsExcelFromDgv
        'Try

        '    Me.Cursor = Cursors.WaitCursor

        '    clsExcelFromDgv.openExcelReport(Me.DgvTrnBanktransfer, False, True)



        'Catch ex As Exception
        '    MsgBox(ex.Message, MsgBoxStyle.Critical, "Report Transfer")
        'Finally
        '    Me.Cursor = Cursors.Arrow
        'End Try
    End Sub

#End Region

#Region " Layout & Init UI "

    Private Function FormatDgvTrnBanktransfer(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        ' Format DgvTrnBanktransfer Columns 
        Dim cBanktransfer_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnal_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnaldetil_line As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBanktransfer_dt As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cSlipformat_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekanan_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekananbank_line As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBanktransfer_rekening As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cPurposefund_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cPaymenttype_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cPaymenttype_id2 As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBanktransfer_pembayaranrek As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBanktransfer_idr As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBanktransfer_foreign As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBanktransfer_foreignrate As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cCurrency_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBanktransfer_bi_idr As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBanktransfer_bi_foreign As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBanktransfer_message As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cChannel_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBanktransfer_isdisabled As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBanktransfer_invoice As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
       
        Dim cProject_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn 
        Dim cBanktransfer_episode As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cChannelbank_line As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBanktransfer_create_by As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBanktransfer_create_date As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTotalTrf As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekanan As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekening_debit As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBank_debit As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAccount_bank_debit As New System.Windows.Forms.DataGridViewTextBoxColumn

        cBanktransfer_id.Name = "ID Transfer"
        cBanktransfer_id.HeaderText = "ID Transfer"
        cBanktransfer_id.DataPropertyName = "ID Transfer"
        cBanktransfer_id.Width = 130
        cBanktransfer_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cBanktransfer_id.Visible = True
        cBanktransfer_id.ReadOnly = True
        cBanktransfer_id.DefaultCellStyle.BackColor = Color.Gainsboro


        cJurnal_id.Name = "ID Jurnal"
        cJurnal_id.HeaderText = "ID Jurnal"
        cJurnal_id.DataPropertyName = "ID Jurnal"
        cJurnal_id.Width = 100
        cJurnal_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cJurnal_id.Visible = True
        cJurnal_id.ReadOnly = True

        cJurnaldetil_line.Name = "jurnaldetil_line"
        cJurnaldetil_line.HeaderText = "jurnaldetil_line"
        cJurnaldetil_line.DataPropertyName = "jurnaldetil_line"
        cJurnaldetil_line.Width = 100
        cJurnaldetil_line.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cJurnaldetil_line.Visible = False
        cJurnaldetil_line.ReadOnly = False

        cBanktransfer_dt.Name = "Transfer Date"
        cBanktransfer_dt.HeaderText = "Transfer Date"
        cBanktransfer_dt.DataPropertyName = "Transfer Date"
        cBanktransfer_dt.Width = 100
        cBanktransfer_dt.Visible = True
        cBanktransfer_dt.ReadOnly = True
        cBanktransfer_dt.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet

        cSlipformat_id.Name = "Penggunaan Dana"
        cSlipformat_id.HeaderText = "Penggunaan Dana"
        cSlipformat_id.DataPropertyName = "Penggunaan Dana"
        cSlipformat_id.Width = 180
        cSlipformat_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cSlipformat_id.Visible = True
        cSlipformat_id.ReadOnly = True


        cRekanan_id.Name = "Rekanan Name Report"
        cRekanan_id.HeaderText = "Rekanan Name Report"
        cRekanan_id.DataPropertyName = "Rekanan Name Report"
        cRekanan_id.Width = 140
        cRekanan_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cRekanan_id.Visible = True
        cRekanan_id.ReadOnly = True

        cRekanan.Name = "rekanan_id"
        cRekanan.HeaderText = "ID Rekanan"
        cRekanan.DataPropertyName = "rekanan_id"
        cRekanan.Width = 140
        cRekanan.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cRekanan.Visible = True
        cRekanan.ReadOnly = True

        cRekananbank_line.Name = "rekananbank_line"
        cRekananbank_line.HeaderText = "Bank Line"
        cRekananbank_line.DataPropertyName = "rekananbank_line"
        cRekananbank_line.Width = 100
        cRekananbank_line.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cRekananbank_line.Visible = False
        cRekananbank_line.ReadOnly = False

        cBanktransfer_rekening.Name = "Receive Rekening"
        cBanktransfer_rekening.HeaderText = "Receive Rekening"
        cBanktransfer_rekening.DataPropertyName = "Receive Rekening"
        cBanktransfer_rekening.Width = 150
        cBanktransfer_rekening.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cBanktransfer_rekening.Visible = True
        cBanktransfer_rekening.ReadOnly = True

        cPurposefund_id.Name = "Pengg. Dana"
        cPurposefund_id.HeaderText = "Pengg. Dana"
        cPurposefund_id.DataPropertyName = "Pengg. Dana"
        cPurposefund_id.Width = 130 
        cPurposefund_id.Visible = True
        cPurposefund_id.ReadOnly = True 

        cPaymenttype_id.Name = "Payment Type"
        cPaymenttype_id.HeaderText = "Payment Type"
        cPaymenttype_id.DataPropertyName = "Payment Type"
        cPaymenttype_id.Width = 100
        cPaymenttype_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cPaymenttype_id.Visible = True
        cPaymenttype_id.ReadOnly = True

        cPaymenttype_id2.Name = "Paymenttype_id"
        cPaymenttype_id2.HeaderText = "Paymenttype_id"
        cPaymenttype_id2.DataPropertyName = "Paymenttype_id"
        cPaymenttype_id2.Width = 100
        cPaymenttype_id2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cPaymenttype_id2.Visible = False
        cPaymenttype_id2.ReadOnly = True

        cBanktransfer_pembayaranrek.Name = "Receive Bank"
        cBanktransfer_pembayaranrek.HeaderText = "Receive Bank"
        cBanktransfer_pembayaranrek.DataPropertyName = "Receive Bank"
        cBanktransfer_pembayaranrek.Width = 150
        cBanktransfer_pembayaranrek.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cBanktransfer_pembayaranrek.Visible = True
        cBanktransfer_pembayaranrek.ReadOnly = True

        cBanktransfer_idr.Name = "banktransfer_idr"
        cBanktransfer_idr.HeaderText = "Amount IDR"
        cBanktransfer_idr.DataPropertyName = "banktransfer_idr"
        cBanktransfer_idr.Width = 100
        cBanktransfer_idr.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cBanktransfer_idr.Visible = True
        cBanktransfer_idr.ReadOnly = True
        cBanktransfer_idr.DefaultCellStyle.Format = "#,##0"
        cBanktransfer_idr.DefaultCellStyle.BackColor = Color.Gainsboro

        cBanktransfer_foreign.Name = "banktransfer_foreign"
        cBanktransfer_foreign.HeaderText = "Amount"
        cBanktransfer_foreign.DataPropertyName = "banktransfer_foreign"
        cBanktransfer_foreign.Width = 100
        cBanktransfer_foreign.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cBanktransfer_foreign.Visible = True
        cBanktransfer_foreign.ReadOnly = False
        cBanktransfer_foreign.DefaultCellStyle.Format = "#,##0.00"

        cBanktransfer_foreignrate.Name = "banktransfer_foreignrate"
        cBanktransfer_foreignrate.HeaderText = "Rate"
        cBanktransfer_foreignrate.DataPropertyName = "banktransfer_foreignrate"
        cBanktransfer_foreignrate.Width = 100
        cBanktransfer_foreignrate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cBanktransfer_foreignrate.Visible = True
        cBanktransfer_foreignrate.ReadOnly = True
        cBanktransfer_foreignrate.DefaultCellStyle.Format = "#,##0.00"
        cBanktransfer_foreignrate.DefaultCellStyle.BackColor = Color.Gainsboro


        cCurrency_id.Name = "Curr"
        cCurrency_id.HeaderText = "Curr"
        cCurrency_id.DataPropertyName = "Curr"
        cCurrency_id.Width = 100 
        cCurrency_id.Visible = True
        cCurrency_id.ReadOnly = True 


        cBanktransfer_bi_idr.Name = "banktransfer_bi_idr"
        cBanktransfer_bi_idr.HeaderText = "Trans. Amount IDR"
        cBanktransfer_bi_idr.DataPropertyName = "banktransfer_bi_idr"
        cBanktransfer_bi_idr.Width = 130
        cBanktransfer_bi_idr.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cBanktransfer_bi_idr.Visible = True
        cBanktransfer_bi_idr.ReadOnly = True
        cBanktransfer_bi_idr.DefaultCellStyle.Format = "#,##0"
        cBanktransfer_bi_idr.DefaultCellStyle.BackColor = Color.Gainsboro 


        cBanktransfer_bi_foreign.Name = "banktransfer_bi_foreign"
        cBanktransfer_bi_foreign.HeaderText = "Trans. Amount"
        cBanktransfer_bi_foreign.DataPropertyName = "banktransfer_bi_foreign"
        cBanktransfer_bi_foreign.Width = 115
        cBanktransfer_bi_foreign.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cBanktransfer_bi_foreign.Visible = True
        cBanktransfer_bi_foreign.ReadOnly = False
        cBanktransfer_bi_foreign.DefaultCellStyle.Format = "#,##0.00"

        cTotalTrf.Name = "Total Transfer"
        cTotalTrf.HeaderText = "Total Transfer"
        cTotalTrf.DataPropertyName = "Total Transfer"
        cTotalTrf.Width = 115
        cTotalTrf.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cTotalTrf.Visible = True
        cTotalTrf.ReadOnly = False
        cTotalTrf.DefaultCellStyle.Format = "#,##0.00"

        cBanktransfer_message.Name = "Receive By"
        cBanktransfer_message.HeaderText = "Received By"
        cBanktransfer_message.DataPropertyName = "Receive By"
        cBanktransfer_message.Width = 100
        cBanktransfer_message.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cBanktransfer_message.Visible = True
        cBanktransfer_message.ReadOnly = False
        cBanktransfer_message.DefaultCellStyle.BackColor = Color.Gainsboro

        cChannel_id.Name = "channel_id"
        cChannel_id.HeaderText = "channel_id"
        cChannel_id.DataPropertyName = "channel_id"
        cChannel_id.Width = 100
        cChannel_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cChannel_id.Visible = False
        cChannel_id.ReadOnly = False

        cBanktransfer_isdisabled.Name = "banktransfer_isdisabled"
        cBanktransfer_isdisabled.HeaderText = "banktransfer_isdisabled"
        cBanktransfer_isdisabled.DataPropertyName = "banktransfer_isdisabled"
        cBanktransfer_isdisabled.Width = 100
        cBanktransfer_isdisabled.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cBanktransfer_isdisabled.Visible = False
        cBanktransfer_isdisabled.ReadOnly = False

        cBanktransfer_invoice.Name = "Invoice"
        cBanktransfer_invoice.HeaderText = "Invoice" '"Received By"
        cBanktransfer_invoice.DataPropertyName = "Invoice"
        cBanktransfer_invoice.Width = 100
        cBanktransfer_invoice.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cBanktransfer_invoice.Visible = True
        cBanktransfer_invoice.ReadOnly = False
        cBanktransfer_invoice.DefaultCellStyle.BackColor = Color.White

        cProject_id.Name = "project"
        cProject_id.HeaderText = "Project"
        cProject_id.DataPropertyName = "project"
        cProject_id.Width = 150
        cProject_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cProject_id.Visible = True
        cProject_id.ReadOnly = True 

        cBanktransfer_episode.Name = "Eps"
        cBanktransfer_episode.HeaderText = "Eps"
        cBanktransfer_episode.DataPropertyName = "Eps"
        cBanktransfer_episode.Width = 50
        cBanktransfer_episode.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cBanktransfer_episode.Visible = True
        cBanktransfer_episode.ReadOnly = True
        cBanktransfer_episode.DefaultCellStyle.BackColor = Color.Gainsboro

        cChannelbank_line.Name = "channelbank_line"
        cChannelbank_line.HeaderText = "Bank Line Channel"
        cChannelbank_line.DataPropertyName = "channelbank_line"
        cChannelbank_line.Width = 100
        cChannelbank_line.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cChannelbank_line.Visible = False
        cChannelbank_line.ReadOnly = False

        cBanktransfer_create_by.Name = "Create By"
        cBanktransfer_create_by.HeaderText = "Create By"
        cBanktransfer_create_by.DataPropertyName = "Create By"
        cBanktransfer_create_by.Width = 150
        cBanktransfer_create_by.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cBanktransfer_create_by.Visible = True
        cBanktransfer_create_by.ReadOnly = True
        cBanktransfer_create_by.DefaultCellStyle.BackColor = Color.Gainsboro

        cBanktransfer_create_date.Name = "Create Date"
        cBanktransfer_create_date.HeaderText = "Create Date"
        cBanktransfer_create_date.DataPropertyName = "Create Date"
        cBanktransfer_create_date.Width = 150
        cBanktransfer_create_date.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cBanktransfer_create_date.Visible = True
        cBanktransfer_create_date.ReadOnly = True
        cBanktransfer_create_date.DefaultCellStyle.BackColor = Color.Gainsboro


        cRekening_debit.Name = "rekening_debit"
        cRekening_debit.HeaderText = "Rekening Debit"
        cRekening_debit.DataPropertyName = "rekening_debit"
        cRekening_debit.Width = 120
        cRekening_debit.Visible = True
        cRekening_debit.ReadOnly = True
        cRekening_debit.DefaultCellStyle.BackColor = Color.Gainsboro

        cBank_debit.Name = "bank_debit"
        cBank_debit.HeaderText = "Bank Debit"
        cBank_debit.DataPropertyName = "bank_debit"
        cBank_debit.Width = 100
        cBank_debit.Visible = True
        cBank_debit.ReadOnly = True
        cBank_debit.DefaultCellStyle.BackColor = Color.Gainsboro

        cAccount_bank_debit.Name = "account_bank_debit"
        cAccount_bank_debit.HeaderText = "Account Bank Debit"
        cAccount_bank_debit.DataPropertyName = "account_bank_debit"
        cAccount_bank_debit.Width = 140
        cAccount_bank_debit.Visible = True
        cAccount_bank_debit.ReadOnly = True
        cAccount_bank_debit.DefaultCellStyle.BackColor = Color.Gainsboro

        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
        {cBanktransfer_id, cJurnal_id, cJurnaldetil_line, cBanktransfer_dt, _
          cBanktransfer_invoice, cBanktransfer_message, cBanktransfer_rekening, cBanktransfer_pembayaranrek, _
        cRekananbank_line, cRekanan, cRekanan_id, cProject_id, cBanktransfer_episode, cPaymenttype_id2, cPaymenttype_id, cSlipformat_id, cPurposefund_id, _
        cCurrency_id, cBanktransfer_foreign, cBanktransfer_foreignrate, cBanktransfer_idr, cBanktransfer_bi_foreign, cBanktransfer_bi_idr, _
          cTotalTrf, _
        cChannelbank_line, cChannel_id, cBanktransfer_isdisabled, cBanktransfer_create_by, cBanktransfer_create_date, _
        cRekening_debit, cBank_debit, cAccount_bank_debit})
        objDgv.AutoGenerateColumns = False
        objDgv.AllowUserToAddRows = False
        objDgv.AllowUserToDeleteRows = False

    End Function

    Private Function InitLayoutUI() As Boolean

        Me.ftabMain.Anchor = AnchorStyles.Bottom
        Me.ftabMain.Anchor += AnchorStyles.Top
        Me.ftabMain.Anchor += AnchorStyles.Right
        Me.ftabMain.Anchor += AnchorStyles.Left

        Me.PnlDfSearch.Dock = DockStyle.Top
        Me.PnlDfSearch.Visible = False
        Me.PnlDfMain.Dock = DockStyle.Fill
        Me.DgvTrnBanktransfer.Dock = DockStyle.Fill

        Me.FormatDgvTrnBanktransfer(Me.DgvTrnBanktransfer)


        Me.btnExcel.Name = "btnExcel"
        Me.btnExcel.Image = My.Resources.excel_icon.ToBitmap
        Me.btnExcel.ToolTipText = "Export To Excel"
        Me.btnExcel.Visible = True

    End Function


#End Region

#Region " User Defined Function "

    Private Function uiRptBankTransfer_Retrieve() As Boolean
        'retrieve data
        Dim criteria As String = ""

        ' TODO: Parse Criteria using clsProc.RefParser()

        If Me.obj_srch_date.Checked = True Then
            criteria = String.Format("[Transfer Date] between '{0}' and '{1}' ", Format(Me.dtTime1.Value.Date, "yyyy-MM-dd 00:00:00"), Format(Me.dtTime2.Value.Date, "yyyy-MM-dd 00:00:00"))
        End If

        If Me.chk_jurnal.Checked = True Then
            If criteria = "" Then
                criteria = clsUtil.RefParser("[ID Jurnal]", Me.obj_srch_jurnal)
            Else
                criteria = criteria + clsUtil.RefParser("[ID Jurnal]", Me.obj_srch_jurnal)
            End If
        End If

        If Me.chk_curr.Checked = True Then
            If criteria = "" Then
                criteria = String.Format("Curr ='{0}'", Me.obj_srch_curr.SelectedValue)
            Else
                criteria = criteria + String.Format("Curr = '{0}'", Me.obj_srch_curr.SelectedValue)
            End If
        End If

        If Me.chk_srch_createby.Checked = True Then
            If criteria = "" Then
                criteria = String.Format("[Create By] ='{0}'", Me.cbo_screateBySearch.SelectedValue)
            Else
                criteria = criteria + String.Format("[Create By] ='{0}'", Me.cbo_screateBySearch.SelectedValue)
            End If
        End If

        If Me.chk_srch_Program.Checked = True Then
            If criteria = "" Then
                criteria = String.Format("Project ='{0}' ", Me.cbo_srch_program.SelectedValue)
            Else
                criteria = criteria + String.Format("Project ='{0}' ", Me.cbo_srch_program.SelectedValue)
            End If
        End If

        If Me.chk_srch_episode.Checked = True Then
            If criteria = "" Then
                criteria = String.Format("eps='{0}' ", Me.obj_srch_eps.Text)
            Else
                criteria = criteria + String.Format("eps='{0}' ", Me.obj_srch_eps.Text)
            End If
        End If
        Me.tbl_TrnBankTransfer.Clear()
        Try 
            Me.DataFill(tbl_TrnBankTransfer, "cp_TrnBanktransfer_Select_2", "TTV", "", criteria)
            Me.DgvTrnBanktransfer.DataSource = Me.tbl_TrnBankTransfer
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Function

    Private Function uiRptBankTransfer_First() As Boolean
        'goto first record found
        Dim move As Boolean
        Dim Message As String = "Data has been changed. " & vbCrLf & "Save data changes before move to first record ?"
        Dim iTab As Integer = Me.ftabMain.SelectedIndex

        If iTab = 1 Then
            If Me.DATA_ISLOCKED Then
                move = True
            Else
                move = False
            End If
        Else
            move = True
        End If

        If move Then
            Me.DgvTrnBanktransfer.CurrentCell = Me.DgvTrnBanktransfer(1, 0)
        End If
    End Function

    Private Function uiRptBankTransfer_Prev() As Boolean
        'goto previous record found
        Dim move As Boolean
        Dim Message As String = "Data has been changed. " & vbCrLf & "Save data changes before move to previous record ?"
        Dim iTab As Integer = Me.ftabMain.SelectedIndex

        If iTab = 1 Then
            If Me.DATA_ISLOCKED Then
                move = True
            Else
                move = False
            End If
        Else
            move = True
        End If

        If move Then
            If Me.DgvTrnBanktransfer.CurrentCell.RowIndex > 0 Then
                Me.DgvTrnBanktransfer.CurrentCell = Me.DgvTrnBanktransfer(1, DgvTrnBanktransfer.CurrentCell.RowIndex - 1)
            End If
        End If
    End Function

    Private Function uiRptBankTransfer_Next() As Boolean
        'goto next record found
        Dim move As Boolean
        Dim Message As String = "Data has been changed. " & vbCrLf & "Save data changes before move to next record ?"
        Dim iTab As Integer = Me.ftabMain.SelectedIndex

        If iTab = 1 Then
            If Me.DATA_ISLOCKED Then
                move = True
            Else
                move = False
            End If
        Else
            move = True
        End If

        If move Then
            If Me.DgvTrnBanktransfer.CurrentCell.RowIndex < Me.DgvTrnBanktransfer.Rows.Count - 1 Then
                Me.DgvTrnBanktransfer.CurrentCell = Me.DgvTrnBanktransfer(1, DgvTrnBanktransfer.CurrentCell.RowIndex + 1)
            End If
        End If
    End Function

    Private Function uiRptBankTransfer_Last() As Boolean
        'goto last record found
        Dim move As Boolean
        Dim Message As String = "Data has been changed. " & vbCrLf & "Save data changes before move to next record ?"
        Dim iTab As Integer = Me.ftabMain.SelectedIndex

        If iTab = 1 Then
            If Me.DATA_ISLOCKED Then
                move = True
            Else
                move = False
            End If
        Else
            move = True
        End If

        If move Then
            Me.DgvTrnBanktransfer.CurrentCell = Me.DgvTrnBanktransfer(1, Me.DgvTrnBanktransfer.Rows.Count - 1)
        End If
    End Function

    Private Function uiRptBankTransfer_FormError() As Boolean
        Try
            ' TODO: Cek Error disini
            ' objFormError.SetError()

            ' Throw New Exception("Error")
        Catch ex As Exception
            MessageBox.Show(ex.Message, mUiName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return True
        End Try
        Return False
    End Function

    Private Function uiTrnBanktransfer_Print() As Boolean
        Dim t As Integer
        Dim banktransfer_id As String
        Dim terbilang As String
        Dim jmlDikirim As Double
        Dim strMessage, strMessage2 As String
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbCmd_header As OleDb.OleDbCommand
        Dim dbDA_header As OleDb.OleDbDataAdapter
        Dim tblOrderPrintForm As New DataTable

        dbCmd_header = New OleDb.OleDbCommand("cp_RptBankTransfer_2", dbConn)
        dbCmd_header.Parameters.Add("@banktransfer_id", Data.OleDb.OleDbType.VarChar)
        dbCmd_header.Parameters.Add("@terbilang", Data.OleDb.OleDbType.VarChar)
        dbCmd_header.Parameters.Add("@message", Data.OleDb.OleDbType.VarChar)
        dbCmd_header.Parameters.Add("@message2", Data.OleDb.OleDbType.VarChar)
        dbCmd_header.Parameters.Add("@paymenttype_id", Data.OleDb.OleDbType.Integer)

        dbCmd_header.CommandType = CommandType.StoredProcedure
        dbDA_header = New OleDb.OleDbDataAdapter(dbCmd_header)

        tblOrderPrintForm.Clear()

        Dim cookie As Byte() = Nothing

        Select Case Me.ftabMain.SelectedTab.Name
            Case ftabMain_List.Name
                Try
                    dbConn.Open()
                    clsApplicationRole.SetAppRole(dbConn, cookie)
                    For t = 0 To Me.DgvTrnBanktransfer.SelectedRows.Count - 1
                        banktransfer_id = Me.DgvTrnBanktransfer.SelectedRows(t).Cells("ID Transfer").Value
                        dbDA_header.SelectCommand.Parameters("@banktransfer_id").Value = banktransfer_id
                        jmlDikirim = Me.DgvTrnBanktransfer.SelectedRows(t).Cells("banktransfer_idr").Value - Me.DgvTrnBanktransfer.SelectedRows(t).Cells("banktransfer_bi_idr").Value
                        terbilang = clsUtil.Terbilang(jmlDikirim)
                        dbDA_header.SelectCommand.Parameters("@terbilang").Value = "# " + Trim(terbilang) + " rupiah #"

                        strMessage = String.Empty
                        strMessage2 = String.Empty

                        If Me.DgvTrnBanktransfer.SelectedRows(t).Cells("Eps").Value.ToString <> "" Then
                            Me._PEMBAYARAN_HONOR = True
                            Me._PEMBAYARAN_TAGIHAN = False
                            Me._MANUAL = False
                        ElseIf Me.DgvTrnBanktransfer.SelectedRows(t).Cells("Invoice").Value <> "" Then
                            Me._PEMBAYARAN_TAGIHAN = True
                            Me._MANUAL = False
                            Me._PEMBAYARAN_HONOR = False
                        Else
                            Me._MANUAL = True
                            Me._PEMBAYARAN_HONOR = False
                            Me._PEMBAYARAN_TAGIHAN = False
                        End If

                        dbDA_header.SelectCommand.Parameters("@message").Value = strMessage

                        If _PEMBAYARAN_HONOR Then
                            Dim strEpsTemp As String = String.Empty
                            strEpsTemp = IIf(Mid(Me.DgvTrnBanktransfer.SelectedRows(t).Cells("eps").Value.ToString, 1, 1) = "#", Mid(Me.DgvTrnBanktransfer.SelectedRows(t).Cells("eps").Value.ToString, 2, Me.DgvTrnBanktransfer.SelectedRows(t).Cells("eps").Value.ToString.Length - 1), Me.DgvTrnBanktransfer.SelectedRows(t).Cells("eps").Value.ToString)
                            strMessage = String.Format("Pbyrn honor {0} ", Me.DgvTrnBanktransfer.SelectedRows(t).Cells("Rekanan Name Report").FormattedValue.ToString.ToUpper)
                            strMessage2 = String.Format("u/ program {0} #{1}", Me.DgvTrnBanktransfer.SelectedRows(t).Cells("Project").FormattedValue.ToString, strEpsTemp)
                            dbDA_header.SelectCommand.Parameters("@message").Value = strMessage
                            dbDA_header.SelectCommand.Parameters("@message2").Value = strMessage2
                        End If

                        If _PEMBAYARAN_TAGIHAN Then
                            strMessage = "Pbyrn tagihan"
                            strMessage2 = String.Format("u/ no invoice : {0}", Me.DgvTrnBanktransfer.SelectedRows(t).Cells("Invoice").Value)
                            dbDA_header.SelectCommand.Parameters("@message").Value = strMessage
                            dbDA_header.SelectCommand.Parameters("@message2").Value = ""
                        End If

                        If _MANUAL Then
                            Dim cek As String = ""
                            For i As Integer = 0 To tbl_artist.Rows.Count - 1
                                If tbl_artist.Rows(i).Item("code") = Me.DgvTrnBanktransfer.SelectedRows(t).Cells("rekanan_id").Value Then
                                    cek = tbl_artist.Rows(i).Item("name").ToString
                                    cek = cek.ToUpper.Trim
                                End If
                            Next

                            If cek <> "" Then
                                strMessage = "Pbyrn " + cek + " a/n "
                                strMessage2 = Me.DgvTrnBanktransfer.SelectedRows(t).Cells("Receive By").Value.ToString.Trim
                                dbDA_header.SelectCommand.Parameters("@message").Value = strMessage
                                dbDA_header.SelectCommand.Parameters("@message2").Value = strMessage2
                            Else
                                strMessage = String.Format("Pbyrn {0}", Me.DgvTrnBanktransfer.SelectedRows(t).Cells("Receive By").Value)
                                dbDA_header.SelectCommand.Parameters("@message").Value = strMessage
                                dbDA_header.SelectCommand.Parameters("@message2").Value = ""
                            End If
                        End If

                        dbDA_header.SelectCommand.Parameters("@paymenttype_id").Value = Me.DgvTrnBanktransfer.SelectedRows(t).Cells("paymenttype_id").Value
                        dbDA_header.Fill(tblOrderPrintForm)
                    Next
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Bank Transfer")
                Finally
                    clsApplicationRole.UnsetAppRole(dbConn, cookie)
                    dbConn.Close()
                End Try
        End Select

        If tblOrderPrintForm.Rows.Count > 0 Then
            Dim printerName As String
            Dim UserRoot As String = "HKEY_CURRENT_USER"
            Dim Subkey As String = "Software\SlipBank"
            Dim KeyName As String = UserRoot & "\" & Subkey

            printerName = Registry.GetValue(KeyName, "Printer Dot Matrix", String.Empty)

            Dim oDotMat As New clsDotMat(Me.DSN, printerName)
            oDotMat.TblToPrint = tblOrderPrintForm
            oDotMat.Print()
            'PrintCekBG()
        Else
            MessageBox.Show("nothing to print")
        End If
    End Function
#End Region

#Region "Function"

    Public Sub Form_Load(ByVal sender As Object)
        Dim objParameters As Collection = New Collection

        'TODO: - Extract Parameter
        '      - Assign parameter
        If Me.Browser IsNot Nothing Then
            objParameters = Me.GetParameterCollection(Me.Parameter)
        End If

        If (Me.Browser IsNot Nothing And MyBase.Name = _Name) Or (Me.Browser Is Nothing And Application.ProductName <> _ProductName) Then
            'Fill Combobox
            'dan fungsi2 startup lainnya.... 
            Me.InitLayoutUI()
            Me.tbtnSave.Enabled = False
            Me.tbtnDel.Enabled = False
            Me.tbtnLoad.Enabled = True
            Me.tbtnQuery.Enabled = True

            Me.DataFill(Me.tbl_artist, "ms_MstArtis_Select_2", " ")
            Me.DataFill(Me.tbl_MstCurrency, "ms_MstCurrencyCombo_Select", " currency_active = 1")
            Me.DataFill(Me.tbl_MstShow, "ms_MstShowCombo_select", "")
            Me.ComboFill(Me.obj_srch_curr, "currency_shortname", "currency_shortname", tbl_MstCurrencysrch, "ms_MstCurrencyCombo_Select", " currency_active = 1")

            Me.tbl_MstShow.Rows.Add(0).Item("show_title") = " "
            Me.tbl_artist.Rows.Add(0).Item("code") = " "

            Me.DataFill(Me.tbl_MstBankacc, "ms_MstBankaccCombo_Select", "")
            Me.tbl_MstBankacc.DefaultView.Sort = "bankacc_reportname"

            Me.DataFill(Me.tbl_MstPaymentType, "cp_MstPaymenttype_Select", "")
            Me.tbl_MstPaymentType.DefaultView.Sort = "paymenttype_name"

            Me.DataFill(Me.tbl_MstSlipFormat, "ms_MstSlipformatCombo_Select", "")
            Me.tbl_MstSlipFormat.DefaultView.Sort = "slipformat_name"

            Me.DataFill(Me.tbl_MstPurposeFund, "ms_MstPurposeFundCombo_Select", "")
            Me.tbl_MstPurposeFund.DefaultView.Sort = "purposefund_name"
            'Me.DataFill(Me.tbl_TrnBankTransfer, "cp_TrnBanktransfer_Select", "", Me._CHANNEL)

            Me.ComboFill(Me.cbo_screateBySearch, "username", "user_fullname", Me.tbl_MstUserSearch, "ms_MstUserInsosysCombo_Select", " user_isdisabled = 0")
            Me.tbl_MstUserSearch.DefaultView.Sort = "user_fullname"

            Me.ComboFill(Me.cbo_srch_program, "show_title", "show_title", Me.tbl_srch_show, "ms_MstShowCombo_select", " show_active = 1")
            Me.tbl_srch_show.DefaultView.Sort = "show_title"


        End If
    End Sub

    Private Sub uiRptBankTransfer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Me.IsDevelopment = True Then Me.Form_Load(sender)

    End Sub

    Private Sub ftabMain_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ftabMain.SelectedIndexChanged

        Select Case ftabMain.SelectedIndex
            Case 0
                Me.tbtnSave.Enabled = False
                Me.tbtnDel.Enabled = False
                Me.tbtnLoad.Enabled = True
                Me.tbtnQuery.Enabled = True
                Me.ftabMain.TabPages.Item(0).BackColor = Color.White
                Me.ftabMain.TabPages.Item(1).BackColor = Color.Gainsboro
        End Select
    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.ToolStrip1.Items.Add(Me.btnExcel)
    End Sub
 

#End Region

    Private Sub obj_srch_date_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles obj_srch_date.CheckedChanged
        If obj_srch_date.Checked = True Then
            Me.dtTime1.Enabled = True
            Me.dtTime2.Enabled = True
        Else
            Me.dtTime1.Enabled = False
            Me.dtTime2.Enabled = False
        End If
    End Sub

    Private Sub chk_jurnal_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_jurnal.CheckedChanged
        If chk_jurnal.Checked = True Then
            Me.obj_srch_jurnal.Enabled = True
        Else
            Me.obj_srch_jurnal.Enabled = False
        End If
    End Sub

    Private Sub chk_curr_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_curr.CheckedChanged
        If chk_curr.Checked = True Then
            Me.obj_srch_curr.Enabled = True
        Else
            Me.obj_srch_curr.Enabled = False
        End If
    End Sub

    Private Sub chk_srch_createby_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_srch_createby.CheckedChanged
        If chk_srch_createby.Checked = True Then
            Me.cbo_screateBySearch.Enabled = True
        Else
            Me.cbo_screateBySearch.Enabled = False
        End If
    End Sub

    Private Sub chk_srch_Program_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_srch_Program.CheckedChanged
        If Me.chk_srch_Program.Checked = True Then
            Me.cbo_srch_program.Enabled = True
        Else
            Me.cbo_srch_program.Enabled = False
        End If
    End Sub

    Private Sub chk_srch_episode_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_srch_episode.CheckedChanged
        If Me.chk_srch_episode.Checked = True Then
            Me.obj_srch_eps.Enabled = True
        Else
            Me.obj_srch_eps.Enabled = False
        End If
    End Sub

    Private Sub excel()

        Using xl As New clsExcel() : AddHandler xl.AfterInsert, AddressOf Excel_AfterInsert
            Dim col As New List(Of String)
            'xl.RowFirst = 10
            'xl.ColumnFirst = 1

            For Each c As DataColumn In Me.tbl_TrnBankTransfer.Columns
                col.Add(c.ColumnName)
            Next

            xl.MyColumns = col
            xl.MyTable = Me.tbl_TrnBankTransfer

            Me.rowExcel = 0
            Me.dlgProses = New DlgProses

            Me.dlgProses.Show()
            Me.dlgProses.PBProses.Maximum = xl.MyTable.Rows.Count
            Me.dlgProses.PBProses.Value = 0
            Application.DoEvents()

            Me.rowCount = xl.MyTable.Rows.Count

            xl.Execute()
            xl.ExcelApplication.Visible = True

            Me.tbl_TrnBankTransfer.DefaultView.RowFilter = ""
            Me.tbl_TrnBankTransfer.DefaultView.RowFilter = ""

            Me.dlgProses.Close()


        End Using
    End Sub
    Private Sub Excel_AfterInsert(ByVal row As DataRow)
        rowExcel += 1
        Me.dlgProses.lblProgress.Text = "Saving " & rowExcel & " of " & Me.rowCount & " records"
        Me.dlgProses.PBProses.Value = Me.rowExcel
        Application.DoEvents()
    End Sub

End Class