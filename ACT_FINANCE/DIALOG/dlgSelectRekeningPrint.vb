Imports System.Windows.Forms

Public Class dlgSelectRekeningPrint
    Private DSN As String
    Private tbl_rekening As DataTable = New DataTable
    Private line As Integer
    Private acc_id As Decimal
    Private currency_id As Decimal
    Private rate As Decimal
    Private amount As Decimal
    Private amountIDR As Decimal
    Private paymenttype As Integer
    Private bank As String
    Private Tgl_Bilyet As Date

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Public Sub New(ByVal DSN As String, ByVal tbl_rekening As DataTable, _
                   ByVal line As Integer, ByVal acc_id As Integer, _
                   ByVal currency_id As Integer, ByVal rate As Decimal, _
                   ByVal amount As Decimal, ByVal amountIDR As Decimal, _
                   ByVal paymenttype As Integer, ByVal bank As String, ByVal Tgl_Bilyet As Date)
        Me.DSN = DSN
        Me.tbl_rekening = tbl_rekening
        Me.line = line
        Me.acc_id = acc_id
        Me.currency_id = currency_id
        Me.rate = rate
        Me.amount = amount
        Me.amountIDR = amountIDR
        Me.paymenttype = paymenttype
        Me.bank = bank
        Me.Tgl_Bilyet = Tgl_Bilyet
        Me.tbl_rekening = tbl_rekening.Copy

        InitializeComponent()
    End Sub

    Private Sub dlgSelectRekeningPrint_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.dgvRekening.DataSource = Me.tbl_rekening
        Me.FormatDgvRekening(Me.dgvRekening)
        Me.dtpTglBilyet.Value = Me.Tgl_Bilyet
        Me.dtpTglPrint.Value = Now.Date
        Me.obj_KotaPrint.Text = "Jakarta"
    End Sub

    Private Function FormatDgvRekening(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        Dim cBanktranfer_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnal_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnaldetil_line As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekanan_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekananbank_line As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBanktransfer_rekening As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cPaymenttype_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cPaymenttype_name As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBanktransfer_pembayaranrek As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBanktransfer_message As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cChannel_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnalbilyet_receiveperson As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnalbilyet_receiverekening As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnalbilyet_receivebank As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnalbilyet_receiveaccountname As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekening_debit As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBank_debit As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAccount_bank_debit As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn

        cBanktranfer_id.Name = "banktransfer_id"
        cBanktranfer_id.HeaderText = "banktransfer_id"
        cBanktranfer_id.DataPropertyName = "banktransfer_id"
        cBanktranfer_id.Width = 100
        cBanktranfer_id.Visible = False
        cBanktranfer_id.ReadOnly = False

        cJurnal_id.Name = "jurnal_id"
        cJurnal_id.HeaderText = "jurnal_id"
        cJurnal_id.DataPropertyName = "jurnal_id"
        cJurnal_id.Width = 100
        cJurnal_id.Visible = False
        cJurnal_id.ReadOnly = False

        cJurnaldetil_line.Name = "jurnaldetil_line"
        cJurnaldetil_line.HeaderText = "jurnaldetil_line"
        cJurnaldetil_line.DataPropertyName = "jurnaldetil_line"
        cJurnaldetil_line.Width = 100
        cJurnaldetil_line.Visible = False
        cJurnaldetil_line.ReadOnly = False

        cRekanan_id.Name = "rekanan_id"
        cRekanan_id.HeaderText = "rekanan_id"
        cRekanan_id.DataPropertyName = "rekanan_id"
        cRekanan_id.Width = 100
        cRekanan_id.Visible = False
        cRekanan_id.ReadOnly = False

        cRekananbank_line.Name = "rekananbank_line"
        cRekananbank_line.HeaderText = "rekananbank_line"
        cRekananbank_line.DataPropertyName = "rekananbank_line"
        cRekananbank_line.Width = 100
        cRekananbank_line.Visible = False
        cRekananbank_line.ReadOnly = False

        cBanktransfer_rekening.Name = "banktransfer_rekening"
        cBanktransfer_rekening.HeaderText = "Rekening"
        cBanktransfer_rekening.DataPropertyName = "banktransfer_rekening"
        cBanktransfer_rekening.Width = 100
        cBanktransfer_rekening.Visible = True
        cBanktransfer_rekening.ReadOnly = False

        cPaymenttype_id.Name = "paymenttype_id"
        cPaymenttype_id.HeaderText = "paymenttype_id"
        cPaymenttype_id.DataPropertyName = "paymenttype_id"
        cPaymenttype_id.Width = 100
        cPaymenttype_id.Visible = False
        cPaymenttype_id.ReadOnly = False

        cPaymenttype_name.Name = "paymenttype_name"
        cPaymenttype_name.HeaderText = "paymenttype_name"
        cPaymenttype_name.DataPropertyName = "paymenttype_name"
        cPaymenttype_name.Width = 100
        cPaymenttype_name.Visible = False
        cPaymenttype_name.ReadOnly = False

        cBanktransfer_pembayaranrek.Name = "banktransfer_pembayaranrek"
        cBanktransfer_pembayaranrek.HeaderText = "Bank"
        cBanktransfer_pembayaranrek.DataPropertyName = "banktransfer_pembayaranrek"
        cBanktransfer_pembayaranrek.Width = 100
        cBanktransfer_pembayaranrek.Visible = True
        cBanktransfer_pembayaranrek.ReadOnly = False

        cBanktransfer_message.Name = "banktransfer_message"
        cBanktransfer_message.HeaderText = "Received By"
        cBanktransfer_message.DataPropertyName = "banktransfer_message"
        cBanktransfer_message.Width = 100
        cBanktransfer_message.Visible = True
        cBanktransfer_message.ReadOnly = False

        cChannel_id.Name = "channel_id"
        cChannel_id.HeaderText = "channel_id"
        cChannel_id.DataPropertyName = "channel_id"
        cChannel_id.Width = 100
        cChannel_id.Visible = False
        cChannel_id.ReadOnly = False

        cJurnalbilyet_receiveperson.Name = "jurnalbilyet_receiveperson"
        cJurnalbilyet_receiveperson.HeaderText = "jurnalbilyet_receiveperson"
        cJurnalbilyet_receiveperson.DataPropertyName = "jurnalbilyet_receiveperson"
        cJurnalbilyet_receiveperson.Width = 100
        cJurnalbilyet_receiveperson.Visible = False
        cJurnalbilyet_receiveperson.ReadOnly = False

        cJurnalbilyet_receiverekening.Name = "jurnalbilyet_receiverekening"
        cJurnalbilyet_receiverekening.HeaderText = "jurnalbilyet_receiverekening"
        cJurnalbilyet_receiverekening.DataPropertyName = "jurnalbilyet_receiverekening"
        cJurnalbilyet_receiverekening.Width = 100
        cJurnalbilyet_receiverekening.Visible = False
        cJurnalbilyet_receiverekening.ReadOnly = False

        cJurnalbilyet_receivebank.Name = "jurnalbilyet_receivebank"
        cJurnalbilyet_receivebank.HeaderText = "jurnalbilyet_receivebank"
        cJurnalbilyet_receivebank.DataPropertyName = "jurnalbilyet_receivebank"
        cJurnalbilyet_receivebank.Width = 100
        cJurnalbilyet_receivebank.Visible = False
        cJurnalbilyet_receivebank.ReadOnly = False

        cJurnalbilyet_receiveaccountname.Name = "jurnalbilyet_receiveaccountname"
        cJurnalbilyet_receiveaccountname.HeaderText = "jurnalbilyet_receiveaccountname"
        cJurnalbilyet_receiveaccountname.DataPropertyName = "jurnalbilyet_receiveaccountname"
        cJurnalbilyet_receiveaccountname.Width = 100
        cJurnalbilyet_receiveaccountname.Visible = False
        cJurnalbilyet_receiveaccountname.ReadOnly = False

        cRekening_debit.Name = "rekening_debit"
        cRekening_debit.HeaderText = "rekening_debit"
        cRekening_debit.DataPropertyName = "rekening_debit"
        cRekening_debit.Width = 100
        cRekening_debit.Visible = False
        cRekening_debit.ReadOnly = False

        cBank_debit.Name = "bank_debit"
        cBank_debit.HeaderText = "bank_debit"
        cBank_debit.DataPropertyName = "bank_debit"
        cBank_debit.Width = 100
        cBank_debit.Visible = False
        cBank_debit.ReadOnly = False

        cAccount_bank_debit.Name = "account_bank_debit"
        cAccount_bank_debit.HeaderText = "account_bank_debit"
        cAccount_bank_debit.DataPropertyName = "account_bank_debit"
        cAccount_bank_debit.Width = 100
        cAccount_bank_debit.Visible = False
        cAccount_bank_debit.ReadOnly = False

        objDgv.Columns.Clear()
        objDgv.ReadOnly = True
        objDgv.AllowUserToAddRows = False
        objDgv.AllowUserToDeleteRows = False
        objDgv.RowHeadersVisible = False
        objDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
        {cBanktranfer_id, cJurnal_id, cJurnaldetil_line, cRekanan_id, cRekananbank_line, cPaymenttype_id, cBanktransfer_message, cBanktransfer_pembayaranrek, cBanktransfer_rekening, cChannel_id, cJurnalbilyet_receiveperson, cJurnalbilyet_receiverekening, cJurnalbilyet_receivebank, cJurnalbilyet_receiveaccountname, cRekening_debit, cBank_debit, cAccount_bank_debit})
    End Function

    Private Sub dgvRekening_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvRekening.CellClick
        Dim dgv As DataGridView = DirectCast(sender, DataGridView)
        Me.txtRekananName.Text = dgv.Rows(e.RowIndex).Cells("banktransfer_message").Value.ToString
        Me.txtAccNumber.Text = dgv.Rows(e.RowIndex).Cells("jurnalbilyet_receiverekening").Value.ToString
        Me.txtBankName.Text = dgv.Rows(e.RowIndex).Cells("jurnalbilyet_receivebank").Value.ToString
    End Sub
End Class
