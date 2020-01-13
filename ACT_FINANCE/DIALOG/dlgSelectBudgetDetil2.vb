Public Class dlgSelectBudgetDetil2
    Private DSN As String
    Private tbl_TrnBudgetDetil As DataTable = clsDataset.CreateTblTrnBudgetdetilWithAmount_new 'clsDataset.CreateTblTrnBudgetdetilWithAmount()
    Private tbl_trnBudgetDetil_temp As DataTable = clsDataset.CreateTblTrnBudgetDetil()
    Private retTbl As DataTable = clsDataset.CreateTblTrnBudgetdetilWithAmount_new 'clsDataset.CreateTblTrnBudgetDetil()
    Private tbl_MstCurrencyDetil_bgt As DataTable = clsDataset.CreateTblMstCurrency()
    Private tbl_DetilWithAmount As DataTable = clsDataset.CreateTblTrnBudgetdetilWithAmount_new 'clsDataset.CreateTblTrnBudgetdetilWithAmount()
    Private CloseButtonIsPressed As Boolean
    Private advance_epsstart, advance_epsend As Decimal
    Private tbl_Advancedetileps As DataTable
    Private tbl_trnAdvancedetileps As DataTable = New DataTable

    Private criteria_budgetdetil As String
    Private objFormError As Windows.Forms.ErrorProvider = New Windows.Forms.ErrorProvider

#Region " Layout & Init UI "

    'Private Function FormatDgvTrnBudgetDetil(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
    '    Dim cSelect As System.Windows.Forms.DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
    '    Dim cBudgetdetil_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
    '    Dim cBudgetdetil_line As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
    '    Dim cBudget_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
    '    Dim cBudgetdetil_tgl As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
    '    Dim cAcc_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
    '    Dim cProjectacc_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
    '    Dim cBudgetdetil_desc As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
    '    Dim cBudgetdetil_amount As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
    '    Dim cCurrency_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
    '    Dim cBudgetdetil_valas As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
    '    Dim cBudgetdetil_comp As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
    '    Dim cBudgetdetil_rate As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
    '    Dim cBudgetdetil_eps As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
    '    Dim cBudgetdetil_unit As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
    '    Dim cBudgetdetil_days As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
    '    Dim cBudgetdetil_amountprop As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
    '    Dim cBudgetdetil_valasprop As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
    '    Dim cBudgetdetil_amountrev As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
    '    Dim cBudgetdetil_valasrev As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
    '    Dim cBudgetdetil_amountpaid As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
    '    Dim cBudgetdetil_valaspaid As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
    '    Dim cBudgetdetil_amountreq As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
    '    Dim cBudgetdetil_valasreq As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
    '    Dim cOutStanding_bgt As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
    '    Dim cCurrency_idbgt As System.Windows.Forms.DataGridViewComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn
    '    Dim cAccumulation_bgt As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
    '    Dim cBudget_name As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
    '    Dim cRequestdetil_idrreal As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn

    '    Dim cParent As New System.Windows.Forms.DataGridViewTextBoxColumn

    '    cSelect.Name = "select"
    '    cSelect.HeaderText = "Select"
    '    cSelect.DataPropertyName = "budgetdetil_select"
    '    cSelect.Width = 50
    '    cSelect.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    '    cSelect.Visible = True
    '    cSelect.ReadOnly = False

    '    cBudgetdetil_id.Name = "budgetdetil_id"
    '    cBudgetdetil_id.HeaderText = "Code"
    '    cBudgetdetil_id.DataPropertyName = "budgetdetil_id"
    '    cBudgetdetil_id.Width = 67
    '    cBudgetdetil_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
    '    cBudgetdetil_id.Visible = True
    '    cBudgetdetil_id.ReadOnly = True

    '    cBudgetdetil_line.Name = "budgetdetil_line"
    '    cBudgetdetil_line.HeaderText = "Line"
    '    cBudgetdetil_line.DataPropertyName = "budgetdetil_line"
    '    cBudgetdetil_line.Width = 100
    '    cBudgetdetil_line.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
    '    cBudgetdetil_line.Visible = False
    '    cBudgetdetil_line.ReadOnly = True

    '    cBudget_id.Name = "budget_id"
    '    cBudget_id.HeaderText = "Budget ID"
    '    cBudget_id.DataPropertyName = "budget_id"
    '    cBudget_id.Width = 100
    '    cBudget_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
    '    cBudget_id.Visible = False
    '    cBudget_id.ReadOnly = True

    '    cBudgetdetil_tgl.Name = "budgetdetil_tgl"
    '    cBudgetdetil_tgl.HeaderText = "Date"
    '    cBudgetdetil_tgl.DataPropertyName = "budgetdetil_tgl"
    '    cBudgetdetil_tgl.Width = 100
    '    cBudgetdetil_tgl.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
    '    cBudgetdetil_tgl.DefaultCellStyle.Format = "dd/MM/yyyy"
    '    cBudgetdetil_tgl.Visible = False
    '    cBudgetdetil_tgl.ReadOnly = True

    '    cAcc_id.Name = "acc_id"
    '    cAcc_id.HeaderText = "Account ID"
    '    cAcc_id.DataPropertyName = "acc_id"
    '    cAcc_id.Width = 100
    '    cAcc_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
    '    cAcc_id.Visible = False
    '    cAcc_id.ReadOnly = True

    '    cProjectacc_id.Name = "projectacc_id"
    '    cProjectacc_id.HeaderText = "Project Account ID"
    '    cProjectacc_id.DataPropertyName = "projectacc_id"
    '    cProjectacc_id.Width = 100
    '    cProjectacc_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
    '    cProjectacc_id.DefaultCellStyle.Format = "dd/MM/yyyy"
    '    cProjectacc_id.Visible = False
    '    cProjectacc_id.ReadOnly = True

    '    cBudgetdetil_desc.Name = "budgetdetil_desc"
    '    cBudgetdetil_desc.HeaderText = "Name"
    '    cBudgetdetil_desc.DataPropertyName = "budgetdetil_desc"
    '    cBudgetdetil_desc.Width = 220
    '    cBudgetdetil_desc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
    '    cBudgetdetil_desc.Visible = True
    '    cBudgetdetil_desc.ReadOnly = True

    '    cBudgetdetil_amount.Name = "budgetdetil_amount"
    '    cBudgetdetil_amount.HeaderText = "Amount"
    '    cBudgetdetil_amount.DataPropertyName = "budgetdetil_amount"
    '    cBudgetdetil_amount.Width = 100
    '    cBudgetdetil_amount.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    '    cBudgetdetil_amount.DefaultCellStyle.Format = "#,###,##0.00"
    '    cBudgetdetil_amount.Visible = False
    '    cBudgetdetil_amount.ReadOnly = True

    '    cCurrency_id.Name = "currency_id"
    '    cCurrency_id.HeaderText = "Currency ID"
    '    cCurrency_id.DataPropertyName = "currency_id"
    '    cCurrency_id.Width = 100
    '    cCurrency_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
    '    cCurrency_id.Visible = False
    '    cCurrency_id.ReadOnly = True

    '    cBudgetdetil_valas.Name = "budgetdetil_valas"
    '    cBudgetdetil_valas.HeaderText = "Valas"
    '    cBudgetdetil_valas.DataPropertyName = "budgetdetil_valas"
    '    cBudgetdetil_valas.Width = 100
    '    cBudgetdetil_valas.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    '    cBudgetdetil_valas.DefaultCellStyle.Format = "#,###,##0.00"
    '    cBudgetdetil_valas.Visible = False
    '    cBudgetdetil_valas.ReadOnly = True

    '    cBudgetdetil_comp.Name = "budgetdetil_comp"
    '    cBudgetdetil_comp.HeaderText = "Comp"
    '    cBudgetdetil_comp.DataPropertyName = "budgetdetil_comp"
    '    cBudgetdetil_comp.Width = 100
    '    cBudgetdetil_comp.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    '    cBudgetdetil_comp.DefaultCellStyle.Format = "#,###,##0.00"
    '    cBudgetdetil_comp.Visible = False
    '    cBudgetdetil_comp.ReadOnly = True

    '    cBudgetdetil_rate.Name = "budgetdetil_rate"
    '    cBudgetdetil_rate.HeaderText = "Rate"
    '    cBudgetdetil_rate.DataPropertyName = "budgetdetil_rate"
    '    cBudgetdetil_rate.Width = 100
    '    cBudgetdetil_rate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    '    cBudgetdetil_rate.DefaultCellStyle.Format = "#,###,##0.00"
    '    cBudgetdetil_rate.Visible = False
    '    cBudgetdetil_rate.ReadOnly = True

    '    cBudgetdetil_eps.Name = "budgetdetil_eps"
    '    cBudgetdetil_eps.HeaderText = "Episode"
    '    cBudgetdetil_eps.DataPropertyName = "budgetdetil_eps"
    '    cBudgetdetil_eps.Width = 100
    '    cBudgetdetil_eps.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    '    cBudgetdetil_eps.DefaultCellStyle.Format = "#,###,##0"
    '    cBudgetdetil_eps.Visible = False
    '    cBudgetdetil_eps.ReadOnly = True

    '    cBudgetdetil_unit.Name = "budgetdetil_unit"
    '    cBudgetdetil_unit.HeaderText = "Unit"
    '    cBudgetdetil_unit.DataPropertyName = "budgetdetil_unit"
    '    cBudgetdetil_unit.Width = 100
    '    cBudgetdetil_unit.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    '    cBudgetdetil_unit.DefaultCellStyle.Format = "#,###,##0"
    '    cBudgetdetil_unit.Visible = False
    '    cBudgetdetil_unit.ReadOnly = True

    '    cBudgetdetil_days.Name = "budgetdetil_days"
    '    cBudgetdetil_days.HeaderText = "Days"
    '    cBudgetdetil_days.DataPropertyName = "budgetdetil_days"
    '    cBudgetdetil_days.Width = 100
    '    cBudgetdetil_days.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    '    cBudgetdetil_days.DefaultCellStyle.Format = "#,###,##0"
    '    cBudgetdetil_days.Visible = False
    '    cBudgetdetil_days.ReadOnly = True

    '    cBudgetdetil_amountprop.Name = "budgetdetil_amountprop"
    '    cBudgetdetil_amountprop.HeaderText = "Amount Prop"
    '    cBudgetdetil_amountprop.DataPropertyName = "budgetdetil_amountprop"
    '    cBudgetdetil_amountprop.Width = 100
    '    cBudgetdetil_amountprop.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    '    cBudgetdetil_amountprop.DefaultCellStyle.Format = "#,###,##0.00"
    '    cBudgetdetil_amountprop.Visible = False
    '    cBudgetdetil_amountprop.ReadOnly = True

    '    cBudgetdetil_valasprop.Name = "budgetdetil_valasprop"
    '    cBudgetdetil_valasprop.HeaderText = "Valas Prop"
    '    cBudgetdetil_valasprop.DataPropertyName = "budgetdetil_valasprop"
    '    cBudgetdetil_valasprop.Width = 100
    '    cBudgetdetil_valasprop.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    '    cBudgetdetil_valasprop.DefaultCellStyle.Format = "#,###,##0.00"
    '    cBudgetdetil_valasprop.Visible = False
    '    cBudgetdetil_valasprop.ReadOnly = True

    '    cBudgetdetil_amountrev.Name = "budgetdetil_amountrev"
    '    cBudgetdetil_amountrev.HeaderText = "Amount Rev"
    '    cBudgetdetil_amountrev.DataPropertyName = "budgetdetil_amountrev"
    '    cBudgetdetil_amountrev.Width = 100
    '    cBudgetdetil_amountrev.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    '    cBudgetdetil_amountrev.DefaultCellStyle.Format = "#,###,##0.00"
    '    cBudgetdetil_amountrev.Visible = False
    '    cBudgetdetil_amountrev.ReadOnly = True

    '    cBudgetdetil_valasrev.Name = "budgetdetil_valasrev"
    '    cBudgetdetil_valasrev.HeaderText = "Valas Rev"
    '    cBudgetdetil_valasrev.DataPropertyName = "budgetdetil_valasrev"
    '    cBudgetdetil_valasrev.Width = 100
    '    cBudgetdetil_valasrev.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    '    cBudgetdetil_valasrev.DefaultCellStyle.Format = "#,###,##0.00"
    '    cBudgetdetil_valasrev.Visible = False
    '    cBudgetdetil_valasrev.ReadOnly = True

    '    cBudgetdetil_amountpaid.Name = "budgetdetil_amountpaid"
    '    cBudgetdetil_amountpaid.HeaderText = "Amount Paid"
    '    cBudgetdetil_amountpaid.DataPropertyName = "budgetdetil_amountpaid"
    '    cBudgetdetil_amountpaid.Width = 100
    '    cBudgetdetil_amountpaid.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    '    cBudgetdetil_amountpaid.DefaultCellStyle.Format = "#,###,##0.00"
    '    cBudgetdetil_amountpaid.Visible = False
    '    cBudgetdetil_amountpaid.ReadOnly = True

    '    cBudgetdetil_valaspaid.Name = "budgetdetil_valaspaid"
    '    cBudgetdetil_valaspaid.HeaderText = "Valas Paid"
    '    cBudgetdetil_valaspaid.DataPropertyName = "budgetdetil_valaspaid"
    '    cBudgetdetil_valaspaid.Width = 100
    '    cBudgetdetil_valaspaid.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    '    cBudgetdetil_valaspaid.DefaultCellStyle.Format = "#,###,##0.00"
    '    cBudgetdetil_valaspaid.Visible = False
    '    cBudgetdetil_valaspaid.ReadOnly = True

    '    cBudgetdetil_amountreq.Name = "budgetdetil_amountreq"
    '    cBudgetdetil_amountreq.HeaderText = "Amount Req"
    '    cBudgetdetil_amountreq.DataPropertyName = "budgetdetil_amountreq"
    '    cBudgetdetil_amountreq.Width = 100
    '    cBudgetdetil_amountreq.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    '    cBudgetdetil_amountreq.DefaultCellStyle.Format = "#,###,##0.00"
    '    cBudgetdetil_amountreq.Visible = False
    '    cBudgetdetil_amountreq.ReadOnly = True

    '    cBudgetdetil_valasreq.Name = "budgetdetil_valasreq"
    '    cBudgetdetil_valasreq.HeaderText = "Valas Req"
    '    cBudgetdetil_valasreq.DataPropertyName = "budgetdetil_valasreq"
    '    cBudgetdetil_valasreq.Width = 100
    '    cBudgetdetil_valasreq.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    '    cBudgetdetil_valasreq.DefaultCellStyle.Format = "#,###,##0.00"
    '    cBudgetdetil_valasreq.Visible = False
    '    cBudgetdetil_valasreq.ReadOnly = True

    '    cOutStanding_bgt.Name = "outstanding_budget"
    '    cOutStanding_bgt.HeaderText = "Budget Outstand."
    '    cOutStanding_bgt.DataPropertyName = "outstanding_budget"
    '    cOutStanding_bgt.Width = 125
    '    cOutStanding_bgt.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    '    cOutStanding_bgt.DefaultCellStyle.Format = "#,##0.00"
    '    cOutStanding_bgt.Visible = True
    '    cOutStanding_bgt.ReadOnly = True

    '    cCurrency_idbgt.Name = "currency_budget"
    '    cCurrency_idbgt.HeaderText = "Budget Currency"
    '    cCurrency_idbgt.Width = 125
    '    cCurrency_idbgt.ValueMember = "currency_id"
    '    cCurrency_idbgt.DisplayMember = "currency_shortname"
    '    cCurrency_idbgt.DataSource = Me.tbl_MstCurrencyDetil_bgt
    '    cCurrency_idbgt.DisplayStyleForCurrentCellOnly = True
    '    cCurrency_idbgt.Visible = False
    '    cCurrency_idbgt.ReadOnly = False

    '    cAccumulation_bgt.Name = "accumulation_budget"
    '    cAccumulation_bgt.HeaderText = "Budget Accum."
    '    cAccumulation_bgt.Width = 125
    '    cAccumulation_bgt.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    '    cAccumulation_bgt.DefaultCellStyle.Format = "#,##0.00"
    '    cAccumulation_bgt.Visible = False
    '    cAccumulation_bgt.ReadOnly = False

    '    cBudget_name.Name = "budget_name"
    '    cBudget_name.HeaderText = "Budget Header"
    '    cBudget_name.Width = 200
    '    cBudget_name.Visible = False
    '    cBudget_name.ReadOnly = False

    '    cRequestdetil_idrreal.Name = "requestdetil_idrreal"
    '    cRequestdetil_idrreal.HeaderText = "Subtotal"
    '    cRequestdetil_idrreal.DataPropertyName = "requestdetil_idrreal"
    '    cRequestdetil_idrreal.Width = 125
    '    cRequestdetil_idrreal.Visible = False
    '    cRequestdetil_idrreal.ReadOnly = False
    '    cRequestdetil_idrreal.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    '    cRequestdetil_idrreal.DefaultCellStyle.Format = "#,##0.00"

    '    cParent.Name = "projectacc_fsname"
    '    cParent.HeaderText = "Parent"
    '    cParent.DataPropertyName = "projectacc_fsname"
    '    cParent.Width = 200
    '    cParent.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
    '    cParent.Visible = True
    '    cParent.ReadOnly = True

    '    objDgv.Columns.Clear()
    '    objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
    '    {cSelect, cBudgetdetil_id, cBudgetdetil_line, cBudget_id, cBudgetdetil_tgl, _
    '    cAcc_id, cProjectacc_id, cParent, cBudgetdetil_desc, cBudgetdetil_amount, cCurrency_id, _
    '    cBudgetdetil_valas, cBudgetdetil_comp, cBudgetdetil_rate, cBudgetdetil_eps, _
    '    cBudgetdetil_unit, cBudgetdetil_days, cBudgetdetil_amountprop, _
    '    cBudgetdetil_valasprop, cBudgetdetil_amountrev, cBudgetdetil_valasrev, _
    '    cBudgetdetil_amountpaid, cBudgetdetil_valaspaid, cBudgetdetil_amountreq, _
    '    cBudgetdetil_valasreq, cOutStanding_bgt, cCurrency_idbgt, cAccumulation_bgt, _
    '    cBudget_name, cRequestdetil_idrreal})

    '    objDgv.AutoGenerateColumns = False
    '    objDgv.AllowUserToAddRows = False
    '    objDgv.AllowUserToDeleteRows = False
    '    objDgv.AllowUserToResizeColumns = True
    '    objDgv.AllowUserToOrderColumns = False
    'End Function

    Private Function FormatDgv(ByRef objDgv As DataGridView) As Boolean
        Dim cSelect As New DataGridViewCheckBoxColumn
        Dim cBudget_id As New DataGridViewTextBoxColumn
        Dim cBudgetdetil_id As New DataGridViewTextBoxColumn
        Dim cBudgetdetil_line As New DataGridViewTextBoxColumn
        Dim cProjectacc_id As New DataGridViewTextBoxColumn
        Dim cAccount_oth As New DataGridViewTextBoxColumn
        Dim cAccount As New DataGridViewTextBoxColumn
        Dim cBudgetdetil_desc As New DataGridViewTextBoxColumn
        Dim cBudgetdetil_amount As New DataGridViewTextBoxColumn
        Dim cOrderdetil_idr As New DataGridViewTextBoxColumn
        Dim cBudgetdetil_amountpasosys As New DataGridViewTextBoxColumn
        Dim cBudgetdetil_amountreq As New DataGridViewTextBoxColumn
        Dim cAmount_bpj As New DataGridViewTextBoxColumn
        Dim cAmount_st As New DataGridViewTextBoxColumn
        Dim cProjectacc_mother As New DataGridViewTextBoxColumn
        Dim cProjectacc_fsname As New DataGridViewTextBoxColumn
        Dim cOutStanding_bgt As New DataGridViewTextBoxColumn

        cSelect.Name = "select"
        cSelect.HeaderText = "Select"
        cSelect.DataPropertyName = "budgetdetil_select"
        cSelect.Width = 50
        cSelect.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        cSelect.Visible = True
        cSelect.ReadOnly = False

        cBudget_id.Name = "budget_id"
        cBudget_id.HeaderText = "budget_id"
        cBudget_id.DataPropertyName = "budget_id"
        cBudget_id.Width = 100
        cBudget_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cBudget_id.Visible = True
        cBudget_id.ReadOnly = True

        cBudgetdetil_id.Name = "budgetdetil_id"
        cBudgetdetil_id.HeaderText = "Code"
        cBudgetdetil_id.DataPropertyName = "budgetdetil_id"
        cBudgetdetil_id.Width = 67
        cBudgetdetil_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cBudgetdetil_id.Visible = True
        cBudgetdetil_id.ReadOnly = True

        cBudgetdetil_line.Name = "budgetdetil_line"
        cBudgetdetil_line.HeaderText = "Line"
        cBudgetdetil_line.DataPropertyName = "budgetdetil_line"
        cBudgetdetil_line.Width = 100
        cBudgetdetil_line.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cBudgetdetil_line.Visible = False
        cBudgetdetil_line.ReadOnly = True

        cProjectacc_id.Name = "projectacc_id"
        cProjectacc_id.HeaderText = "projectacc_id"
        cProjectacc_id.DataPropertyName = "projectacc_id"
        cProjectacc_id.Width = 100
        cProjectacc_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cProjectacc_id.Visible = False
        cProjectacc_id.ReadOnly = True

        cAccount_oth.Name = "account_oth"
        cAccount_oth.HeaderText = "account_oth"
        cAccount_oth.DataPropertyName = "account_oth"
        cAccount_oth.Width = 100
        cAccount_oth.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cAccount_oth.Visible = False
        cAccount_oth.ReadOnly = True

        cAccount.Name = "account"
        cAccount.HeaderText = "account"
        cAccount.DataPropertyName = "account"
        cAccount.Width = 100
        cAccount.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cAccount.Visible = False
        cAccount.ReadOnly = True

        cBudgetdetil_desc.Name = "budgetdetil_desc"
        cBudgetdetil_desc.HeaderText = "Name"
        cBudgetdetil_desc.DataPropertyName = "budgetdetil_desc"
        cBudgetdetil_desc.Width = 220
        cBudgetdetil_desc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cBudgetdetil_desc.Visible = True
        cBudgetdetil_desc.ReadOnly = True

        cBudgetdetil_amount.Name = "budgetdetil_amount"
        cBudgetdetil_amount.HeaderText = "Amount"
        cBudgetdetil_amount.DataPropertyName = "budgetdetil_amount"
        cBudgetdetil_amount.Width = 100
        cBudgetdetil_amount.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cBudgetdetil_amount.Visible = False
        cBudgetdetil_amount.ReadOnly = True

        cOrderdetil_idr.Name = "orderdetil_idr"
        cOrderdetil_idr.HeaderText = "orderdetil_idr"
        cOrderdetil_idr.DataPropertyName = "orderdetil_idr"
        cOrderdetil_idr.Width = 100
        cOrderdetil_idr.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cOrderdetil_idr.Visible = False
        cOrderdetil_idr.ReadOnly = True

        cBudgetdetil_amountpasosys.Name = "budgetdetil_amountpasosys"
        cBudgetdetil_amountpasosys.HeaderText = "budgetdetil_amountpasosys"
        cBudgetdetil_amountpasosys.DataPropertyName = "budgetdetil_amountpasosys"
        cBudgetdetil_amountpasosys.Width = 100
        cBudgetdetil_amountpasosys.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cBudgetdetil_amountpasosys.Visible = False
        cBudgetdetil_amountpasosys.ReadOnly = True

        cBudgetdetil_amountreq.Name = "budgetdetil_amountreq"
        cBudgetdetil_amountreq.HeaderText = "budgetdetil_amountreq"
        cBudgetdetil_amountreq.DataPropertyName = "budgetdetil_amountreq"
        cBudgetdetil_amountreq.Width = 100
        cBudgetdetil_amountreq.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cBudgetdetil_amountreq.Visible = False
        cBudgetdetil_amountreq.ReadOnly = True

        cAmount_bpj.Name = "amount_bpj"
        cAmount_bpj.HeaderText = "amount_bpj"
        cAmount_bpj.DataPropertyName = "amount_bpj"
        cAmount_bpj.Width = 100
        cAmount_bpj.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cAmount_bpj.Visible = False
        cAmount_bpj.ReadOnly = True

        cAmount_st.Name = "amount_st"
        cAmount_st.HeaderText = "amount_st"
        cAmount_st.DataPropertyName = "amount_st"
        cAmount_st.Width = 100
        cAmount_st.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cAmount_st.Visible = False
        cAmount_st.ReadOnly = True

        cProjectacc_mother.Name = "projectacc_mother"
        cProjectacc_mother.HeaderText = "projectacc_mother"
        cProjectacc_mother.DataPropertyName = "projectacc_mother"
        cProjectacc_mother.Width = 100
        cProjectacc_mother.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cProjectacc_mother.Visible = False
        cProjectacc_mother.ReadOnly = True

        cProjectacc_fsname.Name = "projectacc_fsname"
        cProjectacc_fsname.HeaderText = "Parent"
        cProjectacc_fsname.DataPropertyName = "projectacc_fsname"
        cProjectacc_fsname.Width = 200
        cProjectacc_fsname.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cProjectacc_fsname.Visible = True
        cProjectacc_fsname.ReadOnly = True

        cOutStanding_bgt.Name = "outstanding_budget"
        cOutStanding_bgt.HeaderText = "Budget Outstand."
        cOutStanding_bgt.DataPropertyName = "outstanding_budget"
        cOutStanding_bgt.Width = 125
        cOutStanding_bgt.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cOutStanding_bgt.DefaultCellStyle.Format = "#,##0.00"
        cOutStanding_bgt.Visible = True
        cOutStanding_bgt.ReadOnly = True

        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New DataGridViewColumn() _
        {cSelect, cBudget_id, cBudgetdetil_id, cBudgetdetil_line, _
        cProjectacc_id, cAccount_oth, cAccount, _
        cBudgetdetil_desc, cBudgetdetil_amount, _
        cOrderdetil_idr, cBudgetdetil_amountpasosys, _
        cBudgetdetil_amountreq, cAmount_bpj, cAmount_st, _
        cProjectacc_mother, cProjectacc_fsname, cOutStanding_bgt})
        objDgv.AutoGenerateColumns = False
        objDgv.AllowUserToAddRows = False
        objDgv.AllowUserToDeleteRows = False
    End Function

#End Region

#Region " Opener "

    Public Shadows Function OpenDialog(ByVal budget_id As Decimal, ByVal budgetdetil_id As Decimal, _
    ByVal advance_epsstart As Decimal, ByVal advance_epsend As Decimal, _
    ByVal tbl_Advancedetileps_temps As DataTable, _
    ByVal criteria_budgetdetil As String, ByVal owner As System.Windows.Forms.IWin32Window) As Object
        Dim oDataFiller As clsDataFiller = New clsDataFiller(Me.DSN)
        Dim isExist As Boolean = False
        Dim criteria As String = String.Format("tbd.budget_id = {0}", budget_id)
        Dim tbl_srchType As New DataTable
        Dim row_srchType As DataRow

        Me.advance_epsstart = advance_epsstart
        Me.advance_epsend = advance_epsend

        Me.tbl_Advancedetileps = New DataTable
        Me.tbl_Advancedetileps.Clear()

        Me.tbl_Advancedetileps = tbl_Advancedetileps_temps.Copy
        'Dim tbl_sum As DataTable = clsDataset.CreateTblBudgetSum()
        'Dim tbl_detil As DataTable = clsDataset.CreateTblTrnBudgetDetil()
        'Dim budgetdetil_id As Decimal

        'tbl_TrnBudgetDetil.Clear()
        'oDataFiller.DataFill(Me.tbl_TrnBudgetDetil, "pr_TrnBudgetDetil_Select", criteria)
        'Me.DgvTrnBudgetDetil.DataSource = Me.tbl_TrnBudgetDetil
        'Me.FormatDgvTrnBudgetDetil(Me.DgvTrnBudgetDetil)

        Me.tbl_DetilWithAmount.Clear()
        ''''oDataFiller.DataFill(Me.tbl_DetilWithAmount, "vq_TrnBudgetDetilWithAmount_Select", criteria)
        oDataFiller.DataFill(Me.tbl_DetilWithAmount, "vq_TrnBudgetDetilWithAmount_Select2", criteria)

        Me.tbl_DetilWithAmount.DefaultView.RowFilter = criteria_budgetdetil
        Me.criteria_budgetdetil = criteria_budgetdetil

        'tambahan
        'oDataFiller.DataFill(tbl_DetilWithAmount, "cq_Test_AmountOutstanding_Select", criteria)
        'baru

        Me.InitLayoutUI()

        Dim r As Integer
        Dim outstand As Decimal
        Dim amount_budget, amount_request, amount_order, amount_advance, amount_bpj, amount_st As Decimal

        For r = 0 To Me.DgvTrnBudgetDetil.Rows.Count - 1
            amount_budget = clsUtil.IsDbNull(Me.DgvTrnBudgetDetil.Rows(r).Cells("budgetdetil_amount").Value, 0)
            amount_request = clsUtil.IsDbNull(Me.DgvTrnBudgetDetil.Rows(r).Cells("budgetdetil_amountreq").Value, 0)
            amount_order = clsUtil.IsDbNull(Me.DgvTrnBudgetDetil.Rows(r).Cells("orderdetil_idr").Value, 0)
            amount_advance = clsUtil.IsDbNull(Me.DgvTrnBudgetDetil.Rows(r).Cells("budgetdetil_amountpasosys").Value, 0)
            amount_bpj = clsUtil.IsDbNull(Me.DgvTrnBudgetDetil.Rows(r).Cells("amount_bpj").Value, 0)
            amount_st = clsUtil.IsDbNull(Me.DgvTrnBudgetDetil.Rows(r).Cells("amount_st").Value, 0)

            outstand = amount_budget - amount_request - amount_order - amount_advance - amount_bpj + amount_st
            Me.DgvTrnBudgetDetil.Rows(r).Cells("outstanding_budget").Value = outstand

        Next

        'Dim rowIndex As Integer
        'tbl_TrnBudgetDetil.Columns.Add("outstanding_budget", GetType(System.Decimal))
        'tbl_TrnBudgetDetil.Columns("outstanding_budget").DefaultValue = 0
        'tbl_DetilWithAmount.Columns.Add(New DataColumn("budgetdetil_select", GetType(System.Boolean)))
        'tbl_DetilWithAmount.Columns("budgetdetil_select").DefaultValue = False
        'tbl_DetilWithAmount.Columns.Add(New DataColumn("budgetdetil_select", GetType(System.Boolean)))
        'tbl_DetilWithAmount.Columns("budgetdetil_select").DefaultValue = False

        'Dim rowIndex As Integer
        'For rowIndex = 0 To Me.tbl_DetilWithAmount.Rows.Count - 1
        '    If Me.tbl_DetilWithAmount.Rows(rowIndex).Item("budgetdetil_id") = budgetdetil_id Then
        '        Me.tbl_DetilWithAmount.Rows(rowIndex).Item("budgetdetil_select") = True
        '        Exit For
        '    End If
        'Next


        'For rowIndex = 0 To Me.DgvTrnBudgetDetil.Rows.Count - 1
        '    Try
        '        tbl_detil.Clear()
        '        budgetdetil_id = clsUtil.IsDbNull(Me.DgvTrnBudgetDetil.Rows(rowIndex).Cells("budgetdetil_id").Value, 0)
        '        oDataFiller.DataFill(tbl_detil, "pr_TrnBudgetDetil_Select", String.Format("budgetdetil_id = {0}", budgetdetil_id))
        '        If tbl_detil.Rows.Count > 0 Then
        '            Me.DgvTrnBudgetDetil.Rows(rowIndex).Cells("budgetdetil_desc").Value = tbl_detil.Rows(0)("budgetdetil_desc")
        '            Me.DgvTrnBudgetDetil.Rows(rowIndex).Cells("currency_budget").Value = tbl_detil.Rows(0)("currency_id")
        '            Me.DgvTrnBudgetDetil.Rows(rowIndex).Cells("budgetdetil_amount").Value = tbl_detil.Rows(0)("budgetdetil_amount")
        '            Me.DgvTrnBudgetDetil.Rows(rowIndex).Cells("budgetdetil_valas").Value = tbl_detil.Rows(0)("budgetdetil_valas")
        '        Else
        '            Me.DgvTrnBudgetDetil.Rows(rowIndex).Cells("budgetdetil_desc").Value = tbl_detil.Columns("budgetdetil_desc").DefaultValue
        '            Me.DgvTrnBudgetDetil.Rows(rowIndex).Cells("currency_budget").Value = tbl_detil.Columns("currency_id").DefaultValue
        '            Me.DgvTrnBudgetDetil.Rows(rowIndex).Cells("budgetdetil_amount").Value = tbl_detil.Columns("budgetdetil_amount").DefaultValue
        '            Me.DgvTrnBudgetDetil.Rows(rowIndex).Cells("budgetdetil_valas").Value = tbl_detil.Columns("budgetdetil_valas").DefaultValue
        '        End If
        '    Catch ex As Exception
        '        MsgBox("1. " & ex.Message)
        '        Return False
        '    End Try

        '    'Try
        '    '    tbl_sum.Clear()
        '    '    oDataFiller.DataFillBudgetdetilAmount(tbl_sum, "pr_TrnOrderdetil_AmtSum", budget_id, budgetdetil_id)
        '    '    If tbl_sum.Rows.Count > 0 Then
        '    '        Me.DgvTrnBudgetDetil.Rows(rowIndex).Cells("accumulation_budget").Value = tbl_sum.Rows(0)("amount_sum")
        '    '    Else
        '    '        Me.DgvTrnBudgetDetil.Rows(rowIndex).Cells("accumulation_budget").Value = tbl_sum.Columns("amount_sum").DefaultValue
        '    '    End If
        '    'Catch ex As Exception
        '    '    MsgBox("3. " & ex.Message)
        '    '    Return False
        '    'End Try

        '    'Me.DgvTrnBudgetDetil.Rows(rowIndex).Cells("outstanding_budget").Value = Me.tbl_TrnBudgetDetil.Rows(rowIndex).Item("budgetdetil_amount") - Me.DgvTrnBudgetDetil.Rows(rowIndex).Cells("accumulation_budget").Value
        'Next


        tbl_srchType.Columns.Clear()
        tbl_srchType.Columns.Add(New DataColumn("value", GetType(System.String)))
        tbl_srchType.Columns.Add(New DataColumn("display", GetType(System.String)))
        tbl_srchType.Columns("value").DefaultValue = "budgetdetil_id"
        tbl_srchType.Columns("display").DefaultValue = String.Empty

        row_srchType = tbl_srchType.NewRow
        row_srchType("value") = "budgetdetil_id"
        row_srchType("display") = "Code"
        tbl_srchType.Rows.Add(row_srchType)

        row_srchType = tbl_srchType.NewRow
        row_srchType("value") = "budgetdetil_desc"
        row_srchType("display") = "Name"
        tbl_srchType.Rows.Add(row_srchType)

        Me.obj_search_type.DataSource = tbl_srchType
        Me.obj_search_type.ValueMember = "value"
        Me.obj_search_type.DisplayMember = "display"

        MyBase.ShowDialog(owner)
        Me.Cursor = Cursors.Arrow

        If Me.CloseButtonIsPressed Then
            retTbl.DefaultView.Sort = "budgetdetil_id"
            Return retTbl
        Else
            Return Nothing
        End If
    End Function

#End Region

    Public Sub New(ByVal strDSN As String)
        InitializeComponent()
        Me.DSN = strDSN
    End Sub

    Private Sub btn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click, btnCancel.Click
        Dim obj As Button = sender

        If obj.Name = "btnOK" Then
            Dim row As DataRow
            Dim thisRetObj As Collection = New Collection
            Dim rowIndex, colIndex As Integer
            Dim columnName As String
            Dim oDataFiller As clsDataFiller = New clsDataFiller(Me.DSN)
            Dim jml_eps As Integer = 0
            Dim row_eps As Integer = 0

            retTbl.Clear()

            jml_eps = (Me.obj_eps_end.Text - Me.obj_eps_start.Text)

            If Me.obj_check_eps.Checked = True Then
                For row_eps = 0 To jml_eps
                    For rowIndex = 0 To Me.tbl_DetilWithAmount.Rows.Count - 1
                        If clsUtil.IsDbNull(Me.tbl_DetilWithAmount.Rows(rowIndex).Item("budgetdetil_select"), False) = True Then
                            row = retTbl.NewRow
                            For colIndex = 0 To Me.tbl_DetilWithAmount.Columns.Count - 1
                                Try
                                    columnName = Me.tbl_DetilWithAmount.Columns(colIndex).ColumnName
                                    If columnName = "eps_start" Then
                                        row(columnName) = CInt(Me.obj_eps_start.Text) + row_eps
                                    Else
                                        row(columnName) = Me.tbl_DetilWithAmount.Rows(rowIndex).Item(columnName)
                                    End If
                                Catch ex As Exception
                                End Try
                            Next
                            Me.retTbl.Rows.Add(row)
                            ''''Exit For
                        End If
                    Next
                Next

            Else
                For rowIndex = 0 To Me.tbl_DetilWithAmount.Rows.Count - 1
                    If clsUtil.IsDbNull(Me.tbl_DetilWithAmount.Rows(rowIndex).Item("budgetdetil_select"), False) = True Then
                        row = retTbl.NewRow
                        For colIndex = 0 To Me.tbl_DetilWithAmount.Columns.Count - 1
                            Try
                                columnName = Me.tbl_DetilWithAmount.Columns(colIndex).ColumnName
                                row(columnName) = Me.tbl_DetilWithAmount.Rows(rowIndex).Item(columnName)
                            Catch ex As Exception
                            End Try
                        Next
                        Me.retTbl.Rows.Add(row)
                        ''''Exit For
                    End If
                Next
            End If

            Me.CloseButtonIsPressed = True
        Else
            Me.CloseButtonIsPressed = False
        End If
        Me.Close()
    End Sub

    Private Sub obj_search_Changed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles obj_search_text.TextChanged, obj_search_type.SelectedValueChanged
        Dim filter As String = String.Empty

        Try
            Select Case Me.obj_search_type.SelectedValue
                Case "budgetdetil_id"
                    filter = String.Format("budgetdetil_id = {0}", Me.obj_search_text.Text)
                Case "budgetdetil_desc"
                    filter = String.Format("budgetdetil_desc LIKE '%{0}%'", Me.obj_search_text.Text)
                Case Else
                    filter = String.Empty
            End Select

            If criteria_budgetdetil <> String.Empty Then
                If Me.obj_search_text.Text = String.Empty Then
                    filter = criteria_budgetdetil
                Else
                    filter = criteria_budgetdetil & " AND " & filter
                End If
            Else
                If Me.obj_search_text.Text = String.Empty Then
                    filter = String.Empty
                End If
            End If
            Me.tbl_DetilWithAmount.DefaultView.RowFilter = filter
        Catch ex As Exception
        End Try
    End Sub

    Private Sub DgvTrnBudgetDetil_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DgvTrnBudgetDetil.CellFormatting
        Dim selected As Boolean
        Dim objRow As System.Windows.Forms.DataGridViewRow = DgvTrnBudgetDetil.Rows(e.RowIndex)

        Try
            selected = CBool(objRow.Cells("select").Value)
            If selected Then
                objRow.DefaultCellStyle.BackColor = Color.Lavender
            Else
                objRow.DefaultCellStyle.BackColor = Color.White
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Function InitLayoutUI() As Boolean
        Try
            Me.DgvTrnBudgetDetil.DataSource = Me.tbl_DetilWithAmount.DefaultView
            ''''Me.FormatDgvTrnBudgetDetil(Me.DgvTrnBudgetDetil)
            Me.FormatDgv(Me.DgvTrnBudgetDetil)

            Me.obj_eps_start.Text = Me.advance_epsstart
            Me.obj_eps_end.Text = Me.advance_epsend
            'Me.chkItemDescr.Checked = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "InitLayoutUI Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try

        Return True
    End Function

    Private Sub obj_eps_start_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles obj_eps_start.Validated
        Dim ErrorMessage As String = ""
        Dim ErrorFound As Boolean = False

        Dim eps_maks As Integer

        eps_maks = advance_epsend

        ''''If Me.obj_eps_start.Text > eps_maks Then
        ''''    ErrorMessage = "Eps. Start tidak boleh lebih dari " & eps_maks
        ''''    Me.objFormError.SetError(Me.obj_eps_start, ErrorMessage)
        ''''    ''''Throw New Exception(ErrorMessage)
        ''''    MsgBox(ErrorMessage)
        If (Me.obj_eps_start.Text > eps_maks) Or (Me.obj_eps_start.Text > Me.obj_eps_end.Text) Then
            ErrorMessage = "Eps. Start tidak boleh lebih dari " & eps_maks & vbCrLf & "                     atau                        " _
            & vbCrLf _
            & "Eps. Start tidak boleh lebih dari Eps. End"
            Me.objFormError.SetError(Me.obj_eps_start, ErrorMessage)
            ''''Throw New Exception(ErrorMessage)
            MsgBox(ErrorMessage)
        Else
            Me.objFormError.SetError(Me.obj_eps_start, "")
        End If

        ''''If (Me.obj_eps_end.Text > eps_maks) Or (Me.obj_eps_start.Text > Me.obj_eps_end.Text) Then
        ''''    ErrorMessage = "Eps. End tidak boleh lebih dari " & eps_maks & vbCrLf & "                     atau                        " _
        ''''    & vbCrLf _
        ''''    & "Eps. End tidak boleh lebih dari Eps. End"
        ''''    Me.objFormError.SetError(Me.obj_eps_end, ErrorMessage)
        ''''    ''''Throw New Exception(ErrorMessage)
        ''''    MsgBox(ErrorMessage)
        ''''Else
        ''''    Me.objFormError.SetError(Me.obj_eps_end, "")
        ''''End If

    End Sub

    Private Sub obj_eps_end_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles obj_eps_end.Validated
        Dim ErrorMessage As String = ""
        Dim ErrorFound As Boolean = False

        Dim eps_maks As Integer

        eps_maks = advance_epsend

        If (Me.obj_eps_end.Text > eps_maks) Or (Me.obj_eps_start.Text > Me.obj_eps_end.Text) Then
            ErrorMessage = "Eps. End tidak boleh lebih dari " & eps_maks & vbCrLf & "                     atau                        " _
            & vbCrLf _
            & "Eps. Start tidak boleh lebih dari Eps. End"
            Me.objFormError.SetError(Me.obj_eps_end, ErrorMessage)
            ''''Throw New Exception(ErrorMessage)
            MsgBox(ErrorMessage)
        Else
            Me.objFormError.SetError(Me.obj_eps_end, "")
        End If

        ''''If (Me.obj_eps_start.Text > eps_maks) Or (Me.obj_eps_start.Text > Me.obj_eps_end.Text) Then
        ''''    ErrorMessage = "Eps. Start tidak boleh lebih dari " & eps_maks & vbCrLf & "                     atau                        " _
        ''''    & vbCrLf _
        ''''    & "Eps. Start tidak boleh lebih dari Eps. End"
        ''''    Me.objFormError.SetError(Me.obj_eps_end, ErrorMessage)
        ''''    ''''Throw New Exception(ErrorMessage)
        ''''    MsgBox(ErrorMessage)
        ''''Else
        ''''    Me.objFormError.SetError(Me.obj_eps_end, "")
        ''''End If
    End Sub

    Private Sub obj_check_eps_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles obj_check_eps.CheckedChanged
        If Me.obj_check_eps.Checked = True Then
            Me.obj_eps_start.Enabled = True
            Me.obj_eps_end.Enabled = True
        Else
            Me.obj_eps_start.Enabled = False
            Me.obj_eps_end.Enabled = False
        End If
    End Sub


End Class