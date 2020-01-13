'Ari Prasasti

Public Class dlgTrnJurnal_PV_Select_AdvanceOrder

    Private mDSN As String
    Private retObj As Object

    Private mChannel_id As String
    Private myOwner As System.Windows.Forms.IWin32Window

    Private tbl_TrnJurnalVQ As DataTable = CreateTblTrnJurnalDetilAPListVQ()
    Private tbl_TrnJurnalVQSelect As DataTable = CreateTblTrnJurnalDetilAPListVQ()

    Private tbl_MstRekananGrid As DataTable = clsDataset.CreateTblMstRekananCombo

    Private SelectedCurr As String = ""
    Private SelectedRekanan As String = ""
    Private tbl_exception As DataTable = New DataTable


#Region " Properties "

    Public ReadOnly Property DSN() As String
        Get
            Return mDSN
        End Get
    End Property
#End Region

#Region " Constructor & Default Function"
    Public Sub New(ByVal dsn As String, _
                ByVal tbl_MstRekananGrid As DataTable)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.mDSN = dsn

        Me.tbl_MstRekananGrid = tbl_MstRekananGrid.Copy

    End Sub
    Public Shadows Function OpenDialog(ByVal owner As System.Windows.Forms.IWin32Window, _
                ByVal channel_id As String) As Object

        Me.mChannel_id = channel_id
        Me.obj_Channel_id.Text = Me.mChannel_id
        'Me.tbl_exception = tbl_exception
        Me.myOwner = owner
        MyBase.ShowDialog(owner)
        Return retObj
    End Function
#End Region

#Region " UI Layout & Format "
    Function CreateTblTrnJurnalDetil() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("jurnal_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("jurnaldetil_line", GetType(System.Int64)))
        tbl.Columns.Add(New DataColumn("jurnaldetil_dk", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("jurnaldetil_descr", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("rekanan_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("rekanan_name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("acc_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("currency_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("currency_name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("jurnaldetil_foreign", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("jurnaldetil_foreignrate", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("jurnaldetil_idr", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("channel_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("strukturunit_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("strukturunit_name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("ref_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("ref_line", GetType(System.Int64)))
        tbl.Columns.Add(New DataColumn("region_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("branch_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("budget_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("budget_name", GetType(System.String)))

        tbl.Columns.Add(New DataColumn("advance_descr", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("amount_foreign", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("rate", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("amount_idr", GetType(System.Decimal)))

        '-------------------------------
        'Default Value: 
        tbl.Columns("jurnal_id").DefaultValue = ""
        tbl.Columns("jurnaldetil_line").DefaultValue = 0
        tbl.Columns("jurnaldetil_dk").DefaultValue = ""
        tbl.Columns("jurnaldetil_descr").DefaultValue = ""
        tbl.Columns("rekanan_id").DefaultValue = 0
        tbl.Columns("rekanan_name").DefaultValue = ""
        tbl.Columns("acc_id").DefaultValue = "0"
        tbl.Columns("currency_id").DefaultValue = 0
        tbl.Columns("currency_name").DefaultValue = ""
        tbl.Columns("jurnaldetil_foreign").DefaultValue = 0
        tbl.Columns("jurnaldetil_foreignrate").DefaultValue = 0
        tbl.Columns("jurnaldetil_idr").DefaultValue = 0
        tbl.Columns("channel_id").DefaultValue = ""
        tbl.Columns("strukturunit_id").DefaultValue = 0
        tbl.Columns("strukturunit_name").DefaultValue = ""
        tbl.Columns("ref_id").DefaultValue = ""
        tbl.Columns("ref_line").DefaultValue = 0
        tbl.Columns("region_id").DefaultValue = 0
        tbl.Columns("branch_id").DefaultValue = 0
        tbl.Columns("budget_id").DefaultValue = 0
        tbl.Columns("budget_name").DefaultValue = ""

        tbl.Columns("advance_descr").DefaultValue = String.Empty
        tbl.Columns("amount_foreign").DefaultValue = 0
        tbl.Columns("rate").DefaultValue = 0
        tbl.Columns("amount_idr").DefaultValue = 0
        Return tbl

    End Function
    Function CreateTblTrnJurnalDetilAPListVQ() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("jurnal_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("jurnaldetil_check", GetType(System.Boolean)))
        tbl.Columns.Add(New DataColumn("jurnal_bookdate", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("jurnal_duedate", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("jurnaldetil_line", GetType(System.Int64)))
        tbl.Columns.Add(New DataColumn("budgetdetil_line", GetType(System.Int64)))
        tbl.Columns.Add(New DataColumn("jurnaldetil_descr", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("jurnaldetil_idr", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("jurnaldetil_foreign", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("jurnaldetil_rate", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("jurnaldetil_receive", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("jurnaldetil_receive_foreign", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("jurnaldetil_foreignrate", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("jurnaldetil_idr_outstanding", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("jurnaldetil_foreign_outstanding", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("currency_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("acc_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("rekanan_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("channel_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("jurnal_isposted", GetType(System.Boolean)))
        tbl.Columns.Add(New DataColumn("rekanan_name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("currency_name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("acc_name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("strukturunit_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("strukturunit_name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("budget_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("budget_name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("budgetdetil_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("budgetdetil_name", GetType(System.String)))

        tbl.Columns.Add(New DataColumn("pph", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("ppn", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("disc", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("advance_descr", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("faktur_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("amount_intercompany", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("amount_intercompany_idrreal", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("amount_foreign", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("rate", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("amount_idr", GetType(System.Decimal)))

        '-------------------------------
        'Default Value: 
        tbl.Columns("jurnal_id").DefaultValue = ""
        tbl.Columns("jurnaldetil_check").DefaultValue = False
        tbl.Columns("jurnal_bookdate").DefaultValue = Now.Date
        tbl.Columns("jurnal_duedate").DefaultValue = Now.Date
        tbl.Columns("jurnaldetil_line").DefaultValue = 0
        tbl.Columns("budgetdetil_line").DefaultValue = 0
        tbl.Columns("jurnaldetil_descr").DefaultValue = ""
        tbl.Columns("jurnaldetil_idr").DefaultValue = 0
        tbl.Columns("jurnaldetil_foreign").DefaultValue = 0
        tbl.Columns("jurnaldetil_rate").DefaultValue = 0
        tbl.Columns("jurnaldetil_receive").DefaultValue = 0
        tbl.Columns("jurnaldetil_receive_foreign").DefaultValue = 0
        tbl.Columns("jurnaldetil_foreignrate").DefaultValue = 0
        tbl.Columns("jurnaldetil_idr_outstanding").DefaultValue = 0
        tbl.Columns("jurnaldetil_foreign_outstanding").DefaultValue = 0
        tbl.Columns("currency_id").DefaultValue = ""
        tbl.Columns("acc_id").DefaultValue = "0"
        tbl.Columns("rekanan_id").DefaultValue = 0
        tbl.Columns("channel_id").DefaultValue = ""
        tbl.Columns("jurnal_isposted").DefaultValue = 0
        tbl.Columns("rekanan_name").DefaultValue = ""
        tbl.Columns("currency_name").DefaultValue = ""
        tbl.Columns("acc_name").DefaultValue = ""
        tbl.Columns("strukturunit_id").DefaultValue = 0
        tbl.Columns("strukturunit_name").DefaultValue = ""
        tbl.Columns("budget_id").DefaultValue = 0
        tbl.Columns("budget_name").DefaultValue = ""
        tbl.Columns("budgetdetil_id").DefaultValue = 0
        tbl.Columns("budgetdetil_name").DefaultValue = ""

        tbl.Columns("pph").DefaultValue = 0
        tbl.Columns("ppn").DefaultValue = 0
        tbl.Columns("disc").DefaultValue = 0
        tbl.Columns("advance_descr").DefaultValue = String.Empty
        tbl.Columns("faktur_id").DefaultValue = String.Empty
        tbl.Columns("amount_intercompany").DefaultValue = 0
        tbl.Columns("amount_intercompany_idrreal").DefaultValue = 0
        tbl.Columns("amount_foreign").DefaultValue = 0
        tbl.Columns("rate").DefaultValue = 0
        tbl.Columns("amount_idr").DefaultValue = 0
        Return tbl
    End Function
    Private Function FormatDgvTrnJurnalDetilPVListVQ(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        Dim cJurnal_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnaldetil_check As System.Windows.Forms.DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Dim cJurnal_bookdate As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnal_duedate As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnaldetil_line As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBudgetdetil_line As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnaldetil_descr As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnaldetil_idr As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnaldetil_foreign As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnaldetil_rate As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnaldetil_receive As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnaldetil_receive_foreign As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnaldetil_idr_outstanding As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnaldetil_foreign_outstanding As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnaldetil_receive_foreignrate As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cCurrency_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAcc_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekanan_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cChannel_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekanan_name As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cCurrency_name As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAcc_name As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cPPh As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cPPn As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cDisc As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn

        cJurnaldetil_check.Name = "jurnaldetil_check"
        cJurnaldetil_check.HeaderText = "Pilih"
        cJurnaldetil_check.DataPropertyName = "jurnaldetil_check"
        cJurnaldetil_check.Width = 40
        cJurnaldetil_check.Visible = True
        cJurnaldetil_check.ReadOnly = False

        cJurnal_id.Name = "jurnal_id"
        cJurnal_id.HeaderText = "ID"
        cJurnal_id.DataPropertyName = "jurnal_id"
        cJurnal_id.Width = 90
        cJurnal_id.Visible = True
        cJurnal_id.ReadOnly = True
        'cJurnal_id.DefaultCellStyle.BackColor = Color.Gainsboro

        cJurnal_bookdate.Name = "jurnal_bookdate"
        cJurnal_bookdate.HeaderText = "Book Date"
        cJurnal_bookdate.DataPropertyName = "jurnal_bookdate"
        cJurnal_bookdate.Width = 85
        cJurnal_bookdate.Visible = False
        cJurnal_bookdate.ReadOnly = True
        cJurnal_bookdate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        cJurnal_bookdate.DefaultCellStyle.Format = "dd/MM/yyyy"
        'cJurnal_bookdate.DefaultCellStyle.BackColor = Color.Gainsboro

        cJurnal_duedate.Name = "jurnal_duedate"
        cJurnal_duedate.HeaderText = "Due Date"
        cJurnal_duedate.DataPropertyName = "jurnal_duedate"
        cJurnal_duedate.Width = 85
        cJurnal_duedate.Visible = False
        cJurnal_duedate.ReadOnly = True
        cJurnal_duedate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        cJurnal_duedate.DefaultCellStyle.Format = "dd/MM/yyyy"

        cJurnaldetil_line.Name = "jurnaldetil_line"
        cJurnaldetil_line.HeaderText = "Line"
        cJurnaldetil_line.DataPropertyName = "jurnaldetil_line"
        cJurnaldetil_line.Width = 40
        cJurnaldetil_line.Visible = True
        cJurnaldetil_line.ReadOnly = True
        'cJurnaldetil_line.DefaultCellStyle.BackColor = Color.Gainsboro

        cBudgetdetil_line.Name = "budgetdetil_line"
        cBudgetdetil_line.HeaderText = "Budget Line"
        cBudgetdetil_line.DataPropertyName = "budgetdetil_line"
        cBudgetdetil_line.Width = 60
        cBudgetdetil_line.Visible = False
        cBudgetdetil_line.ReadOnly = True

        cJurnaldetil_descr.Name = "jurnaldetil_descr"
        cJurnaldetil_descr.HeaderText = "Descr"
        cJurnaldetil_descr.DataPropertyName = "jurnaldetil_descr"
        cJurnaldetil_descr.Width = 150
        cJurnaldetil_descr.Visible = True
        cJurnaldetil_descr.ReadOnly = True
        'cJurnaldetil_descr.DefaultCellStyle.BackColor = Color.Gainsboro

        cJurnaldetil_idr.Name = "jurnaldetil_idr"
        cJurnaldetil_idr.HeaderText = "Amount"
        cJurnaldetil_idr.DataPropertyName = "jurnaldetil_idr"
        cJurnaldetil_idr.Width = 100
        cJurnaldetil_idr.Visible = False
        cJurnaldetil_idr.ReadOnly = True
        cJurnaldetil_idr.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cJurnaldetil_idr.DefaultCellStyle.Format = "#,##0.00"
        'cJurnaldetil_idr.DefaultCellStyle.BackColor = Color.Gainsboro

        cJurnaldetil_foreign.Name = "jurnaldetil_foreign"
        cJurnaldetil_foreign.HeaderText = "Amount Foreign"
        cJurnaldetil_foreign.DataPropertyName = "jurnaldetil_foreign"
        cJurnaldetil_foreign.Width = 100
        cJurnaldetil_foreign.Visible = False
        cJurnaldetil_foreign.ReadOnly = True
        cJurnaldetil_foreign.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cJurnaldetil_foreign.DefaultCellStyle.Format = "#,##0.00"
        'cJurnaldetil_foreign.DefaultCellStyle.BackColor = Color.Gainsboro

        cJurnaldetil_rate.Name = "jurnaldetil_rate"
        cJurnaldetil_rate.HeaderText = "Rate"
        cJurnaldetil_rate.DataPropertyName = "jurnaldetil_rate"
        cJurnaldetil_rate.Width = 100
        cJurnaldetil_rate.Visible = True
        cJurnaldetil_rate.ReadOnly = True
        cJurnaldetil_rate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cJurnaldetil_rate.DefaultCellStyle.Format = "#,##0.00"
        'cJurnaldetil_rate.DefaultCellStyle.BackColor = Color.Gainsboro

        cJurnaldetil_receive.Name = "jurnaldetil_receive"
        cJurnaldetil_receive.HeaderText = "Receive"
        cJurnaldetil_receive.DataPropertyName = "jurnaldetil_receive"
        cJurnaldetil_receive.Width = 100
        cJurnaldetil_receive.Visible = False
        cJurnaldetil_receive.ReadOnly = True
        cJurnaldetil_receive.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cJurnaldetil_receive.DefaultCellStyle.Format = "#,##0.00"
        'cJurnaldetil_receive.DefaultCellStyle.BackColor = Color.Gainsboro

        cJurnaldetil_receive_foreign.Name = "jurnaldetil_receive_foreign"
        cJurnaldetil_receive_foreign.HeaderText = "Receive Foreign"
        cJurnaldetil_receive_foreign.DataPropertyName = "jurnaldetil_receive_foreign"
        cJurnaldetil_receive_foreign.Width = 100
        cJurnaldetil_receive_foreign.Visible = False
        cJurnaldetil_receive_foreign.ReadOnly = True
        cJurnaldetil_receive_foreign.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cJurnaldetil_receive_foreign.DefaultCellStyle.Format = "#,##0.00"
        'cJurnaldetil_receive_foreign.DefaultCellStyle.BackColor = Color.Gainsboro

        cJurnaldetil_idr_outstanding.Name = "jurnaldetil_idr_outstanding"
        cJurnaldetil_idr_outstanding.HeaderText = "Remain IDR"
        cJurnaldetil_idr_outstanding.DataPropertyName = "jurnaldetil_idr_outstanding"
        cJurnaldetil_idr_outstanding.Width = 125
        cJurnaldetil_idr_outstanding.Visible = True
        cJurnaldetil_idr_outstanding.ReadOnly = True
        cJurnaldetil_idr_outstanding.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cJurnaldetil_idr_outstanding.DefaultCellStyle.Format = "#,##0.00"
        'cJurnaldetil_idr_outstanding.DefaultCellStyle.BackColor = Color.Gainsboro

        cJurnaldetil_foreign_outstanding.Name = "jurnaldetil_foreign_outstanding"
        cJurnaldetil_foreign_outstanding.HeaderText = "Remain Foreign"
        cJurnaldetil_foreign_outstanding.DataPropertyName = "jurnaldetil_foreign_outstanding"
        cJurnaldetil_foreign_outstanding.Width = 125
        cJurnaldetil_foreign_outstanding.Visible = True
        cJurnaldetil_foreign_outstanding.ReadOnly = True
        cJurnaldetil_foreign_outstanding.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cJurnaldetil_foreign_outstanding.DefaultCellStyle.Format = "#,##0.00"
        'cJurnaldetil_foreign_outstanding.DefaultCellStyle.BackColor = Color.Gainsboro

        cJurnaldetil_receive_foreignrate.Name = "jurnaldetil_receive_foreignrate"
        cJurnaldetil_receive_foreignrate.HeaderText = "Receive Rate"
        cJurnaldetil_receive_foreignrate.DataPropertyName = "jurnaldetil_receive_foreignrate"
        cJurnaldetil_receive_foreignrate.Width = 100
        cJurnaldetil_receive_foreignrate.Visible = False
        cJurnaldetil_receive_foreignrate.ReadOnly = True
        cJurnaldetil_receive_foreignrate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cJurnaldetil_receive_foreignrate.DefaultCellStyle.Format = "#,##0.00"
        'cJurnaldetil_receive_foreignrate.DefaultCellStyle.BackColor = Color.Gainsboro

        cCurrency_id.Name = "currency_id"
        cCurrency_id.HeaderText = "Currency"
        cCurrency_id.DataPropertyName = "currency_id"
        cCurrency_id.Width = 75
        cCurrency_id.Visible = False
        cCurrency_id.ReadOnly = True

        cAcc_id.Name = "acc_id"
        cAcc_id.HeaderText = "Account"
        cAcc_id.DataPropertyName = "acc_id"
        cAcc_id.Width = 100
        cAcc_id.Visible = False
        cAcc_id.ReadOnly = True

        cRekanan_id.Name = "rekanan_id"
        cRekanan_id.HeaderText = "Rekanan"
        cRekanan_id.DataPropertyName = "rekanan_id"
        cRekanan_id.Width = 150
        cRekanan_id.Visible = False
        cRekanan_id.ReadOnly = True

        cChannel_id.Name = "channel_id"
        cChannel_id.HeaderText = "Channel"
        cChannel_id.DataPropertyName = "channel_id"
        cChannel_id.Width = 75
        cChannel_id.Visible = True
        cChannel_id.ReadOnly = True
        'cChannel_id.DefaultCellStyle.BackColor = Color.Gainsboro]

        cRekanan_name.Name = "rekanan_name"
        cRekanan_name.HeaderText = "Rekanan"
        cRekanan_name.DataPropertyName = "rekanan_name"
        cRekanan_name.Width = 150
        cRekanan_name.Visible = True
        cRekanan_name.ReadOnly = True
        'cRekanan_name.DefaultCellStyle.BackColor = Color.Gainsboro

        cCurrency_name.Name = "currency_name"
        cCurrency_name.HeaderText = "Currency"
        cCurrency_name.DataPropertyName = "currency_name"
        cCurrency_name.Width = 75
        cCurrency_name.Visible = True
        cCurrency_name.ReadOnly = True
        'cCurrency_name.DefaultCellStyle.BackColor = Color.Gainsboro

        cAcc_name.Name = "acc_name"
        cAcc_name.HeaderText = "Account"
        cAcc_name.DataPropertyName = "acc_name"
        cAcc_name.Width = 150
        cAcc_name.Visible = False
        cAcc_name.ReadOnly = True
        'cAcc_name.DefaultCellStyle.BackColor = Color.Gainsboro

        cPPh.Name = "pph"
        cPPh.HeaderText = "PPh %"
        cPPh.DataPropertyName = "pph"
        cPPh.Width = 150
        cPPh.Visible = False
        cPPh.ReadOnly = True

        cPPn.Name = "ppn"
        cPPn.HeaderText = "PPn %"
        cPPn.DataPropertyName = "ppn"
        cPPn.Width = 150
        cPPn.Visible = False
        cPPn.ReadOnly = True

        cDisc.Name = "disc"
        cDisc.HeaderText = "Disc"
        cDisc.DataPropertyName = "disc"
        cDisc.Width = 150
        cDisc.Visible = False
        cDisc.ReadOnly = True


        objDgv.AutoGenerateColumns = False

        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
        {cJurnaldetil_check, cJurnal_id, cJurnaldetil_line, cBudgetdetil_line, cJurnaldetil_descr, cJurnal_bookdate, _
        cJurnal_duedate, cAcc_id, cAcc_name, _
        cCurrency_name, cCurrency_id, cJurnaldetil_foreign_outstanding, cJurnaldetil_rate, _
        cJurnaldetil_idr_outstanding, cJurnaldetil_receive, cJurnaldetil_idr, _
        cJurnaldetil_receive_foreign, cJurnaldetil_foreign, _
        cJurnaldetil_receive_foreignrate, cRekanan_id, cRekanan_name, cChannel_id, _
        cPPh, cPPn, cDisc})


        objDgv.AllowUserToAddRows = False
        objDgv.AllowUserToDeleteRows = False
        objDgv.AllowUserToResizeRows = False
        'objDgv.ReadOnly = True
        objDgv.SelectionMode = DataGridViewSelectionMode.CellSelect
        objDgv.MultiSelect = False
        objDgv.Columns("jurnaldetil_line").Frozen = True

    End Function
#End Region

#Region " User defined function "
    Private Function dlgTrnJurnalDetilSelect_Load(ByVal channel_id As String) As Boolean
        Me.Cursor = Cursors.WaitCursor
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter
        Dim criteria = ""
        Dim jurnal As String = ""
        Dim rekanan As String = ""

        Dim txtSearchCriteria As String = ""
        Dim txtSQLSearch As String = String.Empty

        If Me.chkSearchSource.Checked = True Then
            txtSQLSearch = txtSQLSearch & " LEFT(C.advance_id, 2) = 'VQ' "
        End If

        If Me.chkSearchJurnalID.Checked Then
            txtSearchCriteria = clsUtil.RefParser("C.advance_id", Me.obj_jurnal_id)
            jurnal = Me.obj_jurnal_id.Text
            If txtSQLSearch = "" Then
                txtSQLSearch = " (" & txtSearchCriteria & ") "
            Else
                txtSQLSearch = txtSQLSearch & " AND " & " (" & txtSearchCriteria & ") "
            End If
        End If

        '-- Rekanan Search    
        If Me.chkRekanan.Checked Then
            txtSearchCriteria = String.Format(" rekanan_id = '{0}' ", Me.obj_Rekanan_id.Text)
            rekanan = Me.obj_Rekanan_id.Text
            If txtSQLSearch = "" Then
                txtSQLSearch = " (" & txtSearchCriteria & ") "
            Else
                txtSQLSearch = txtSQLSearch & " AND " & " (" & txtSearchCriteria & ") "
            End If
        End If
        '--END 

        criteria = txtSQLSearch

        dbCmd = New OleDb.OleDbCommand("act_TrnJurnaldetil_PV_Select_Advance_Order", dbConn)
        dbCmd.Parameters.Add("@channel_id", Data.OleDb.OleDbType.VarWChar)
        dbCmd.Parameters("@channel_id").Value = channel_id
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarWChar)
        dbCmd.Parameters("@Criteria").Value = criteria
        dbCmd.Parameters.Add("@jurnal_id", Data.OleDb.OleDbType.VarWChar)
        dbCmd.Parameters("@jurnal_id").Value = jurnal
        dbCmd.Parameters.Add("@rekanan", Data.OleDb.OleDbType.VarWChar)
        dbCmd.Parameters("@rekanan").Value = rekanan
        dbCmd.CommandTimeout = 600

        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)
        Me.tbl_TrnJurnalVQ.Clear()

        Dim cookie As Byte() = Nothing

        Try
            dbConn.Open()
            clsApplicationRole.SetAppRole(dbConn, cookie)
            dbDA.Fill(Me.tbl_TrnJurnalVQ)

            '=====Handle ketarik 2x sebelum save 20131010 kokoh sakti====
            If Me.tbl_exception.Rows.Count <> 0 Then
                Dim rows As DataRow()

                Dim ref As String
                Dim line As Integer

                For Each row As DataRow In Me.tbl_exception.Rows
                    If row.RowState <> DataRowState.Deleted Then
                        ref = row.Item("ref")
                        line = row.Item("line")
                        rows = Me.tbl_TrnJurnalVQ.Select(String.Format("jurnal_id = '{0}' and jurnaldetil_line = {1}", ref, line))

                        If rows.Length > 0 Then
                            rows(0).Delete()
                        End If
                    End If
                Next

                Me.tbl_TrnJurnalVQ.AcceptChanges()
            End If
            '==============================================================

            Me.DgvDetil.DataSource = Me.tbl_TrnJurnalVQ
        Catch ex As Exception
            MessageBox.Show(ex.Message, "dlgTrnJurnalSelect" & ": dlgTrnJurnalDetilSelect_LoadDetil()", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            clsApplicationRole.UnsetAppRole(dbConn, cookie)
            dbConn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Function
#End Region

    Private Sub dlgTrnJurnal_PV_Select_Advance_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Cursor = Cursors.WaitCursor
        Me.FormatDgvTrnJurnalDetilPVListVQ(Me.DgvDetil)
        Me.DgvDetil.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Me.DgvDetil.DataSource = Me.tbl_TrnJurnalVQ

        Me.obj_jurnal_id.Enabled = False
        Me.chkRekanan.Checked = False
        Me.obj_Rekanan_id.Enabled = False

        Me.obj_Source.Items.Add("Advance")
        Me.obj_Source.SelectedItem = "Advance"
        Me.obj_Source.Enabled = False

        Me.Cursor = Cursors.Arrow

    End Sub

    '=============================Button================================================================================================================================================================
    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Me.dlgTrnJurnalDetilSelect_Load("NTV")
        Me.DgvDetil.DataSource = Me.tbl_TrnJurnalVQ
    End Sub
    Private Sub btnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelect.Click
        Dim tblH As DataTable = clsDataset.CreateTblTrnJurnal()
        Dim tblDetil As DataTable = CreateTblTrnJurnalDetil()
        Dim row As DataRow
        Dim Descr As String = ""
        Dim thisRetObj As Collection = New Collection

        Dim tbl_TrnJurnalVQSelect As DataTable = CreateTblTrnJurnalDetilAPListVQ()
        Dim i As Integer

        If Me.dlgTrnJurnalPV_Select_VQ_verify() = False Then
            Exit Sub
        End If

        tbl_TrnJurnalVQSelect.Clear()
        tbl_TrnJurnalVQSelect = Me.tbl_TrnJurnalVQ.Copy()
        tbl_TrnJurnalVQSelect.DefaultView.RowFilter = "jurnaldetil_check = 'True'"

        If Me.DgvDetil.CurrentRow IsNot Nothing Then
            If tbl_TrnJurnalVQSelect.DefaultView.Count > 0 Then
                For i = 0 To tbl_TrnJurnalVQSelect.DefaultView.Count - 1
                    row = tblH.NewRow()
                    row.Item("currency_id") = clsUtil.IsDbNull(Me.tbl_TrnJurnalVQSelect.Rows(i).Item("currency_id"), 0)
                    row.Item("rekanan_id") = clsUtil.IsDbNull(Me.tbl_TrnJurnalVQSelect.Rows(i).Item("rekanan_id"), 0)
                    row.Item("rekanan_name") = clsUtil.IsDbNull(Me.tbl_TrnJurnalVQSelect.Rows(i).Item("rekanan_name"), "-- PILIH --")
                    row.Item("budget_id") = clsUtil.IsDbNull(Me.tbl_TrnJurnalVQSelect.Rows(i).Item("budget_id"), 0)
                    row.Item("budget_name") = clsUtil.IsDbNull(Me.tbl_TrnJurnalVQSelect.Rows(i).Item("budget_name"), "-- PILIH --")
                    row.Item("currency_rate") = clsUtil.IsDbNull(Me.tbl_TrnJurnalVQSelect.Rows(i).Item("jurnaldetil_rate"), 0)
                    row.Item("jurnal_descr") = clsUtil.IsDbNull(Me.tbl_TrnJurnalVQSelect.Rows(i).Item("advance_descr"), String.Empty)
                    row.Item("strukturunit_id") = clsUtil.IsDbNull(Me.tbl_TrnJurnalVQSelect.Rows(i).Item("strukturunit_id"), 0)
                    tblH.Rows.Add(row)

                    row = tblDetil.NewRow()
                    row.Item("jurnal_id") = clsUtil.IsDbNull(Me.tbl_TrnJurnalVQSelect.Rows(i).Item("jurnal_id"), String.Empty)
                    row.Item("acc_id") = clsUtil.IsDbNull(Me.tbl_TrnJurnalVQSelect.Rows(i).Item("acc_id"), String.Empty)
                    row.Item("channel_id") = clsUtil.IsDbNull(Me.tbl_TrnJurnalVQSelect.Rows(i).Item("channel_id"), String.Empty)
                    row.Item("jurnaldetil_descr") = clsUtil.IsDbNull(Me.tbl_TrnJurnalVQSelect.Rows(i).Item("jurnaldetil_descr"), String.Empty)
                    row.Item("jurnaldetil_idr") = clsUtil.IsDbNull(Me.tbl_TrnJurnalVQSelect.Rows(i).Item("jurnaldetil_idr"), 0)
                    row.Item("jurnaldetil_foreign") = clsUtil.IsDbNull(Me.tbl_TrnJurnalVQSelect.Rows(i).Item("jurnaldetil_foreign"), 0)
                    row.Item("jurnaldetil_foreignrate") = clsUtil.IsDbNull(Me.tbl_TrnJurnalVQSelect.Rows(i).Item("jurnaldetil_rate"), 0)
                    row.Item("currency_id") = clsUtil.IsDbNull(Me.tbl_TrnJurnalVQSelect.Rows(i).Item("currency_id"), 0)
                    row.Item("currency_name") = clsUtil.IsDbNull(Me.tbl_TrnJurnalVQSelect.Rows(i).Item("currency_name"), String.Empty)
                    row.Item("ref_id") = clsUtil.IsDbNull(Me.tbl_TrnJurnalVQSelect.Rows(i).Item("jurnal_id"), String.Empty)
                    row.Item("ref_line") = clsUtil.IsDbNull(Me.tbl_TrnJurnalVQSelect.Rows(i).Item("jurnaldetil_line"), 0)
                    row.Item("ref_budgetline") = clsUtil.IsDbNull(Me.tbl_TrnJurnalVQSelect.Rows(i).Item("budgetdetil_line"), 0)
                    row.Item("budget_id") = clsUtil.IsDbNull(Me.tbl_TrnJurnalVQSelect.Rows(i).Item("budget_id"), 0)
                    row.Item("budget_name") = clsUtil.IsDbNull(Me.tbl_TrnJurnalVQSelect.Rows(i).Item("budget_name"), String.Empty)
                    row.Item("budgetdetil_id") = clsUtil.IsDbNull(Me.tbl_TrnJurnalVQSelect.Rows(i).Item("budgetdetil_id"), 0)
                    row.Item("budgetdetil_name") = clsUtil.IsDbNull(Me.tbl_TrnJurnalVQSelect.Rows(i).Item("budgetdetil_name"), String.Empty)
                    row.Item("rekanan_id") = clsUtil.IsDbNull(Me.tbl_TrnJurnalVQSelect.Rows(i).Item("rekanan_id"), 0)
                    row.Item("rekanan_name") = clsUtil.IsDbNull(Me.tbl_TrnJurnalVQSelect.Rows(i).Item("rekanan_name"), String.Empty)
                    row.Item("strukturunit_id") = clsUtil.IsDbNull(Me.tbl_TrnJurnalVQSelect.Rows(i).Item("strukturunit_id"), 0)
                    row.Item("strukturunit_name") = clsUtil.IsDbNull(Me.tbl_TrnJurnalVQSelect.Rows(i).Item("strukturunit_name"), String.Empty)
                    row.Item("pph") = clsUtil.IsDbNull(Me.tbl_TrnJurnalVQSelect.Rows(i).Item("pph"), 0)
                    row.Item("ppn") = clsUtil.IsDbNull(Me.tbl_TrnJurnalVQSelect.Rows(i).Item("ppn"), 0)
                    row.Item("disc") = clsUtil.IsDbNull(Me.tbl_TrnJurnalVQSelect.Rows(i).Item("disc"), 0)
                    row.Item("advance_descr") = clsUtil.IsDbNull(Me.tbl_TrnJurnalVQSelect.Rows(i).Item("advance_descr"), String.Empty)
                    row.Item("faktur_id") = clsUtil.IsDbNull(Me.tbl_TrnJurnalVQSelect.Rows(i).Item("faktur_id"), String.Empty)
                    row.Item("amount_intercompany") = clsUtil.IsDbNull(Me.tbl_TrnJurnalVQSelect.Rows(i).Item("amount_intercompany"), 0)
                    row.Item("amount_intercompany_idrreal") = clsUtil.IsDbNull(Me.tbl_TrnJurnalVQSelect.Rows(i).Item("amount_intercompany_idrreal"), 0)
                    row.Item("amount_idr") = clsUtil.IsDbNull(-Me.tbl_TrnJurnalVQSelect.Rows(i).Item("jurnaldetil_idr"), 0)
                    row.Item("amount_foreign") = clsUtil.IsDbNull(-Me.tbl_TrnJurnalVQSelect.DefaultView.Item(i).Item("jurnaldetil_foreign"), 0)
                    row.Item("rate") = clsUtil.IsDbNull(Me.tbl_TrnJurnalVQSelect.DefaultView.Item(i).Item("jurnaldetil_rate"), 0)
                    tblDetil.Rows.Add(row)

                Next

                thisRetObj.Add(tblH.Copy(), "tblH")
                thisRetObj.Add(tblDetil.Copy(), "tblJDetil")
                retObj = thisRetObj

                Me.Close()
            End If
        End If
    End Sub
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.retObj = Nothing
        Me.Close()
    End Sub

    Private Sub chkRekanan_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkRekanan.CheckedChanged
        If Me.chkRekanan.Checked = True Then
            Me.obj_Rekanan_id.Enabled = True
        Else
            Me.obj_Rekanan_id.Enabled = False
        End If
    End Sub
    Private Sub chkSearchJurnalID_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSearchJurnalID.CheckedChanged
        If Me.chkSearchJurnalID.Checked = True Then
            Me.obj_jurnal_id.Enabled = True
        Else
            Me.obj_jurnal_id.Enabled = False
        End If
    End Sub
    Private Sub DgvDetil_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DgvDetil.CellFormatting

        Dim Selected As Boolean
        Dim obj As DataGridView = sender
        Dim objRow As System.Windows.Forms.DataGridViewRow = obj.Rows(e.RowIndex)
        Try
            Selected = CBool(objRow.Cells("jurnaldetil_check").Value)
            If Selected Then
                objRow.DefaultCellStyle.BackColor = Color.LightBlue
            Else
                objRow.DefaultCellStyle.BackColor = Color.White
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Function dlgTrnJurnalPV_Select_VQ_verify()
        Dim i As Integer
        Dim tbl_TrnJurnaldetilTemp As DataTable = CreateTblTrnJurnalDetilAPListVQ()
        Dim cekCurr As String = ""
        Dim cekRekanan As String = ""

        tbl_TrnJurnaldetilTemp.Clear()
        tbl_TrnJurnaldetilTemp = Me.tbl_TrnJurnalVQ.Copy()
        tbl_TrnJurnaldetilTemp.DefaultView.RowFilter = "jurnaldetil_check = 'True'"

        If tbl_TrnJurnaldetilTemp.DefaultView.Count > 0 Then
            For i = 0 To tbl_TrnJurnaldetilTemp.DefaultView.Count - 1
                If cekCurr = "" Then
                    cekCurr = tbl_TrnJurnaldetilTemp.DefaultView.Item(i).Item("currency_id").ToString
                    Me.SelectedCurr = cekCurr
                Else
                    If cekCurr <> tbl_TrnJurnaldetilTemp.DefaultView.Item(i).Item("currency_id").ToString Then
                        MessageBox.Show("Currency tidak boleh berbeda", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Return False
                        Exit Function
                    End If
                End If

                If cekRekanan = "" Then
                    cekRekanan = tbl_TrnJurnaldetilTemp.DefaultView.Item(i).Item("rekanan_id").ToString
                    Me.SelectedRekanan = cekRekanan
                Else
                    If cekRekanan <> tbl_TrnJurnaldetilTemp.DefaultView.Item(i).Item("rekanan_id").ToString Then
                        MessageBox.Show("Rekanan tidak boleh berbeda", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Return False
                        Exit Function
                    End If
                End If
            Next
        End If

        Return True

    End Function

    Private Sub btn_Rekanan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Rekanan.Click
        Dim dlg As dlgSearch = New dlgSearch()
        Dim retData As Collection
        Dim retObj As Object
        Dim rekanan_id As Decimal

        retObj = dlg.OpenDialog(Me, Me.tbl_MstRekananGrid, "rekanan")
        If retObj IsNot Nothing Then
            retData = CType(retObj, Collection)
            rekanan_id = CType(retData.Item("retId"), Decimal)
            Me.obj_Rekanan_id.Text = rekanan_id
        End If
    End Sub


End Class

'Trash Code Temp
'dari event btn_Add diatas

'row = tblH.NewRow()
'row.Item("currency_id") = tbl_TrnJurnal_temp.DefaultView.Item(i).Item("currency_id")
'row.Item("jurnal_descr") = tbl_TrnJurnal_temp.DefaultView.Item(i).Item("advance_descr")
'row.Item("rekanan_id") = tbl_TrnJurnal_temp.DefaultView.Item(i).Item("rekanan_id")
'row.Item("budget_id") = tbl_TrnJurnal_temp.DefaultView.Item(i).Item("budget_id")
'row.Item("currency_rate") = tbl_TrnJurnal_temp.DefaultView.Item(i).Item("jurnaldetil_rate")
'tblH.Rows.Add(row)

'row = tblDetil.NewRow()
'row.Item("jurnal_id") = tbl_TrnJurnal_temp.DefaultView.Item(i).Item("jurnal_id")
'row.Item("channel_id") = tbl_TrnJurnal_temp.DefaultView.Item(i).Item("channel_id")
'row.Item("jurnaldetil_descr") = tbl_TrnJurnal_temp.DefaultView.Item(i).Item("jurnaldetil_descr")
'row.Item("jurnaldetil_idr") = tbl_TrnJurnal_temp.DefaultView.Item(i).Item("jurnaldetil_idr_outstanding")
'row.Item("jurnaldetil_foreign") = tbl_TrnJurnal_temp.DefaultView.Item(i).Item("jurnaldetil_foreign_outstanding")
'row.Item("jurnaldetil_foreignrate") = tbl_TrnJurnal_temp.DefaultView.Item(i).Item("jurnaldetil_rate")
'row.Item("currency_id") = tbl_TrnJurnal_temp.DefaultView.Item(i).Item("currency_id")
'row.Item("currency_name") = tbl_TrnJurnal_temp.DefaultView.Item(i).Item("currency_name")
'row.Item("ref_id") = tbl_TrnJurnal_temp.DefaultView.Item(i).Item("jurnal_id")
'row.Item("ref_line") = tbl_TrnJurnal_temp.DefaultView.Item(i).Item("jurnaldetil_line")
'row.Item("rekanan_id") = tbl_TrnJurnal_temp.DefaultView.Item(i).Item("rekanan_id")
'row.Item("rekanan_name") = tbl_TrnJurnal_temp.DefaultView.Item(i).Item("rekanan_name")
'row.Item("strukturunit_id") = tbl_TrnJurnal_temp.DefaultView.Item(i).Item("strukturunit_id")
'row.Item("strukturunit_name") = tbl_TrnJurnal_temp.DefaultView.Item(i).Item("strukturunit_name")
'row.Item("advance_descr") = tbl_TrnJurnal_temp.DefaultView.Item(i).Item("advance_descr")
'row.Item("amount_idr") = String.Format("{0:#,##0}", CDec(-tbl_TrnJurnal_temp.DefaultView.Item(i).Item("jurnaldetil_idr")))
'row.Item("amount_foreign") = String.Format("{0:#,##0.00}", CDec(-tbl_TrnJurnal_temp.DefaultView.Item(i).Item("jurnaldetil_foreign")))
'row.Item("rate") = String.Format("{0:#,##0}", CDec(tbl_TrnJurnal_temp.DefaultView.Item(i).Item("jurnaldetil_rate")))
'row.Item("budget_id") = String.Format("{0:#,##0}", CDec(tbl_TrnJurnal_temp.DefaultView.Item(i).Item("budget_id")))
'row.Item("budget_name") = tbl_TrnJurnal_temp.DefaultView.Item(i).Item("budget_name")

'tblDetil.Rows.Add(row)

' dataset trash
'Function CreateTblTrnJurnalDetilPVListVQ() As DataTable
'    Dim tbl As DataTable = New DataTable

'    tbl.Columns.Clear()
'    tbl.Columns.Add(New DataColumn("jurnal_id", GetType(System.String)))
'    tbl.Columns.Add(New DataColumn("jurnaldetil_check", GetType(System.Boolean)))
'    tbl.Columns.Add(New DataColumn("jurnal_bookdate", GetType(System.DateTime)))
'    tbl.Columns.Add(New DataColumn("jurnal_duedate", GetType(System.DateTime)))
'    tbl.Columns.Add(New DataColumn("jurnaldetil_line", GetType(System.Int64)))
'    tbl.Columns.Add(New DataColumn("budgetdetil_line", GetType(System.Int64)))
'    tbl.Columns.Add(New DataColumn("jurnaldetil_descr", GetType(System.String)))
'    tbl.Columns.Add(New DataColumn("jurnaldetil_idr", GetType(System.Decimal)))
'    tbl.Columns.Add(New DataColumn("jurnaldetil_foreign", GetType(System.Decimal)))
'    tbl.Columns.Add(New DataColumn("jurnaldetil_rate", GetType(System.Decimal)))
'    tbl.Columns.Add(New DataColumn("jurnaldetil_receive", GetType(System.Decimal)))
'    tbl.Columns.Add(New DataColumn("jurnaldetil_receive_foreign", GetType(System.Decimal)))
'    tbl.Columns.Add(New DataColumn("jurnaldetil_foreignrate", GetType(System.Decimal)))
'    tbl.Columns.Add(New DataColumn("jurnaldetil_idr_outstanding", GetType(System.Decimal)))
'    tbl.Columns.Add(New DataColumn("jurnaldetil_foreign_outstanding", GetType(System.Decimal)))
'    tbl.Columns.Add(New DataColumn("currency_id", GetType(System.String)))
'    tbl.Columns.Add(New DataColumn("acc_id", GetType(System.String)))
'    tbl.Columns.Add(New DataColumn("rekanan_id", GetType(System.Decimal)))
'    tbl.Columns.Add(New DataColumn("channel_id", GetType(System.String)))
'    tbl.Columns.Add(New DataColumn("jurnal_isposted", GetType(System.Boolean)))
'    tbl.Columns.Add(New DataColumn("rekanan_name", GetType(System.String)))
'    tbl.Columns.Add(New DataColumn("currency_name", GetType(System.String)))
'    tbl.Columns.Add(New DataColumn("acc_name", GetType(System.String)))
'    tbl.Columns.Add(New DataColumn("strukturunit_id", GetType(System.Decimal)))
'    tbl.Columns.Add(New DataColumn("strukturunit_name", GetType(System.String)))
'    tbl.Columns.Add(New DataColumn("budget_id", GetType(System.Decimal)))
'    tbl.Columns.Add(New DataColumn("budget_name", GetType(System.String)))
'    tbl.Columns.Add(New DataColumn("budgetdetil_id", GetType(System.Decimal)))
'    tbl.Columns.Add(New DataColumn("budgetdetil_name", GetType(System.String)))



'    '-------------------------------
'    'Default Value: 
'    tbl.Columns("jurnal_id").DefaultValue = ""
'    tbl.Columns("jurnaldetil_check").DefaultValue = False
'    tbl.Columns("jurnal_bookdate").DefaultValue = Now.Date
'    tbl.Columns("jurnal_duedate").DefaultValue = Now.Date
'    tbl.Columns("jurnaldetil_line").DefaultValue = 0
'    tbl.Columns("budgetdetil_line").DefaultValue = 0
'    tbl.Columns("jurnaldetil_descr").DefaultValue = ""
'    tbl.Columns("jurnaldetil_idr").DefaultValue = 0
'    tbl.Columns("jurnaldetil_foreign").DefaultValue = 0
'    tbl.Columns("jurnaldetil_rate").DefaultValue = 0
'    tbl.Columns("jurnaldetil_receive").DefaultValue = 0
'    tbl.Columns("jurnaldetil_receive_foreign").DefaultValue = 0
'    tbl.Columns("jurnaldetil_foreignrate").DefaultValue = 0
'    tbl.Columns("jurnaldetil_idr_outstanding").DefaultValue = 0
'    tbl.Columns("jurnaldetil_foreign_outstanding").DefaultValue = 0
'    tbl.Columns("currency_id").DefaultValue = ""
'    tbl.Columns("acc_id").DefaultValue = "0"
'    tbl.Columns("rekanan_id").DefaultValue = 0
'    tbl.Columns("channel_id").DefaultValue = ""
'    tbl.Columns("jurnal_isposted").DefaultValue = 0
'    tbl.Columns("rekanan_name").DefaultValue = ""
'    tbl.Columns("currency_name").DefaultValue = ""
'    tbl.Columns("acc_name").DefaultValue = ""
'    tbl.Columns("strukturunit_id").DefaultValue = 0
'    tbl.Columns("strukturunit_name").DefaultValue = ""
'    tbl.Columns("budget_id").DefaultValue = 0
'    tbl.Columns("budget_name").DefaultValue = ""
'    tbl.Columns("budgetdetil_id").DefaultValue = 0
'    tbl.Columns("budgetdetil_name").DefaultValue = ""

'    Return tbl
'End Function