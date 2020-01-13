
Public Class dlgTrnSelectItemChild
    Private DSN As String
    Private detilLine As Integer
    Private budget_code As Decimal
    Private budget_view As String
    Private channel As String
    Private advance_currency As Decimal
    Private user_strukturunit As Decimal
    Private advance_epsend As String
    Private advance_epsstart As String
    Private advance_id As String
    Private advancedetil_line As Integer


    '''Private rettbl As DataTable = clsDataset.CreateTblTrnAdvanceItemDetil()
    Private retObj As Object
    Private tbl_TrnAdvanceItemDetils As DataTable = clsDataset.CreateTblTrnAdvanceItemDetil()
    Private tbl_TrnAdvanceItemDetils2 As DataTable = clsDataset.CreateTblTrnAdvanceItemDetil()
    Private tbl_TrnAdvanceItemDetil_temps As DataTable = clsDataset.CreateTblTrnAdvanceItemDetil()

    Private tbl_Trnrequestdetil_type As DataTable = New DataTable
    Private tbl_MstCurrencyDetil As DataTable = clsDataset.CreateTblMstCurrency()
    Private tbl_Advancedetileps As DataTable = clsDataset.CreateTblTrnAdvanceItemDetilEps()
    Private tbl_TrnAdvance_Temp As DataTable = clsDataset.CreateTblTrnAdvance()
    Private motherTbl As DataTable = clsDataset.CreateTblTrnAdvanceItemDetil()

    Private tbl_trnAdvancedetileps As DataTable = New DataTable
    Private tbl_trnAdvancedetileps_temp As DataTable = clsDataset.CreateTblTrnAdvanceItemDetilEps()

    Private CloseButtonIsPressed As Boolean
    Private bma_approve As Integer

    Private criteria_budgetdetil As String = String.Empty

    Friend Class SelectEpsDialogReturn
        Private m_budgetdetil_line As Integer
        Private m_Advancedetil_line As Integer
        Private m_budget_name As String
        Private m_budgetdetil_eps As Decimal
        Private m_epsstart As Decimal
        Private m_epsend As Decimal

        Public Property budgetdetil_line() As Integer
            Get
                Return m_budgetdetil_line
            End Get
            Set(ByVal value As Integer)
                m_budgetdetil_line = value
            End Set
        End Property

        Public Property advancedetil_line() As Integer
            Get
                Return m_Advancedetil_line
            End Get
            Set(ByVal value As Integer)
                m_Advancedetil_line = value
            End Set

        End Property
        Public Property budget_name() As String
            Get
                Return m_budget_name
            End Get
            Set(ByVal value As String)
                m_budget_name = value
            End Set
        End Property

        Public Property budgetdetil_eps() As Decimal
            Get
                Return m_budgetdetil_eps
            End Get
            Set(ByVal value As Decimal)
                m_budgetdetil_eps = value
            End Set
        End Property

        Public Property epsstart() As Decimal
            Get
                Return m_epsstart
            End Get
            Set(ByVal value As Decimal)
                m_epsstart = value
            End Set
        End Property

        Public Property epsend() As Decimal
            Get
                Return m_epsend
            End Get
            Set(ByVal value As Decimal)
                m_epsend = value
            End Set
        End Property
    End Class

    Public Shadows Function OpenDialog(ByVal _USERSTRUKTURUNIT As Decimal, ByVal approve_user As Integer, ByVal approve_bma As Integer, ByVal id As String, ByVal owner As System.Windows.Forms.IWin32Window) As Object
        ''''Dim row_index As Integer
        Dim row_type As DataRow
        Dim oDataFiller As New clsDataFiller(Me.DSN)

        Try
            Me.btn_unbudget.Visible = False
            tbl_Trnrequestdetil_type.Clear()
            tbl_Trnrequestdetil_type.Columns.Add(New DataColumn("value_type", GetType(System.Decimal)))
            tbl_Trnrequestdetil_type.Columns.Add(New DataColumn("display_type", GetType(System.String)))

            If tbl_Trnrequestdetil_type.Columns("display_type") IsNot Nothing Then
                row_type = tbl_Trnrequestdetil_type.NewRow
                row_type.Item("value_type") = 1
                row_type.Item("display_type") = "Item"
                tbl_Trnrequestdetil_type.Rows.InsertAt(row_type, 0)

                row_type = tbl_Trnrequestdetil_type.NewRow
                row_type.Item("value_type") = 0
                row_type.Item("display_type") = "Description"
                tbl_Trnrequestdetil_type.Rows.InsertAt(row_type, 1)
            End If

            Me.FormatDgvTrnAdvanceItemDetil(Me.DgvAdvanceItemDetil)
            Me.DgvAdvanceItemDetil.DataSource = Me.tbl_TrnAdvanceItemDetils

            tbl_TrnAdvanceItemDetils2 = Me.tbl_TrnAdvanceItemDetils.Copy

            Me.tbl_TrnAdvanceItemDetils.DefaultView.RowFilter = " advancedetil_line = " & advancedetil_line

            If Me.DgvAdvanceItemDetil.Rows.Count > 0 Then
                'Me.DgvAdvanceItemDetil.Rows(0).Cells("outstanding_budget").Value = Me.tbl_TrnAdvanceItemDetils.Rows(0).Item("amount_budget") - Me.tbl_TrnAdvanceItemDetils.Rows(0).Item("amount_idrreal")
                'Me.DgvAdvanceItemDetil.Rows(0).Cells("outstanding_budget").Value = clsUtil.IsDbNull(Me.tbl_TrnAdvanceItemDetils.Rows(0).Item("amount_budget"), 0) - clsUtil.IsDbNull(Me.tbl_TrnAdvanceItemDetils.Rows(0).Item("amount_subtotal"), 0)
                'Dim u As Integer
                'Dim r As Integer

                'For u = 0 To Me.tbl_TrnAdvanceItemDetils.Rows.Count - 1
                '    For r = 0 To Me.DgvAdvanceItemDetil.Rows.Count - 1
                '        If Me.tbl_TrnAdvanceItemDetils.Rows(u).Item("advancedetil_line") = Me.DgvAdvanceItemDetil.Rows(r).Cells("advancedetil_line").Value Then
                '            If approve_bma = 1 Then
                '                Me.DgvAdvanceItemDetil.Rows(0).Cells("outstanding_budget").Value = clsUtil.IsDbNull(Me.tbl_TrnAdvanceItemDetils.Rows(0).Item("outstanding_approved"), 0)
                '                Me.DgvAdvanceItemDetil.Rows(0).Cells("outstanding_approved").Value = clsUtil.IsDbNull(Me.tbl_TrnAdvanceItemDetils.Rows(0).Item("outstanding_approved"), 0)
                '            Else
                '                Me.DgvAdvanceItemDetil.Rows(0).Cells("outstanding_budget").Value = clsUtil.IsDbNull(Me.tbl_TrnAdvanceItemDetils.Rows(0).Item("amount_budget"), 0) - (clsUtil.IsDbNull(Me.tbl_TrnAdvanceItemDetils.Rows(0).Item("amount_idrreal"), 0) - (clsUtil.IsDbNull(Me.tbl_TrnAdvanceItemDetils.Rows(0).Item("advancedetil_discount"), 0) * clsUtil.IsDbNull(Me.tbl_TrnAdvanceItemDetils.Rows(0).Item("advancedetil_foreignrate"), 0))) - clsUtil.IsDbNull(Me.tbl_TrnAdvanceItemDetils.Rows(0).Item("amount_approvebma"), 0) + clsUtil.IsDbNull(Me.tbl_TrnAdvanceItemDetils.Rows(0).Item("budget_accum"), 0)
                '                Me.DgvAdvanceItemDetil.Rows(0).Cells("outstanding_approved").Value = Me.DgvAdvanceItemDetil.Rows(0).Cells("outstanding_budget").Value
                '            End If
                '        End If
                '    Next
                'Next

                If approve_bma = 1 Then
                    Me.DgvAdvanceItemDetil.Rows(0).Cells("outstanding_budget").Value = clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(0).Cells("outstanding_approved").Value, 0)
                    Me.DgvAdvanceItemDetil.Rows(0).Cells("outstanding_approved").Value = clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(0).Cells("outstanding_approved").Value, 0)
                    'Else
                    '    Me.DgvAdvanceItemDetil.Rows(0).Cells("outstanding_budget").Value = clsUtil.IsDbNull(Me.tbl_TrnAdvanceItemDetils.Rows(0).Item("amount_budget"), 0) - (clsUtil.IsDbNull(Me.tbl_TrnAdvanceItemDetils.Rows(0).Item("amount_idrreal"), 0) - (clsUtil.IsDbNull(Me.tbl_TrnAdvanceItemDetils.Rows(0).Item("advancedetil_discount"), 0) * clsUtil.IsDbNull(Me.tbl_TrnAdvanceItemDetils.Rows(0).Item("advancedetil_foreignrate"), 0))) - clsUtil.IsDbNull(Me.tbl_TrnAdvanceItemDetils.Rows(0).Item("amount_approvebma"), 0) + clsUtil.IsDbNull(Me.tbl_TrnAdvanceItemDetils.Rows(0).Item("budget_accum"), 0)
                    '    Me.DgvAdvanceItemDetil.Rows(0).Cells("outstanding_approved").Value = Me.DgvAdvanceItemDetil.Rows(0).Cells("outstanding_budget").Value
                End If

            End If

            Me.bma_approve = approve_bma

            If id <> String.Empty Then
                If _USERSTRUKTURUNIT = 5559 And approve_bma = 1 Then

                    Me.addBudgetDetil.Enabled = False
                    Me.btn_unbudget.Enabled = False
                    Me.btnOK.Enabled = False

                    Me.DgvAdvanceItemDetil.AllowUserToDeleteRows = False

                ElseIf _USERSTRUKTURUNIT <> 5559 And approve_user = 1 And (approve_bma = 0 Or approve_bma = 1) Then

                    Me.addBudgetDetil.Enabled = False
                    Me.btnOK.Enabled = False
                    Me.btn_unbudget.Enabled = False
                    Me.DgvAdvanceItemDetil.AllowUserToDeleteRows = False

                Else
                    Me.addBudgetDetil.Enabled = True
                    Me.btnOK.Enabled = True
                    Me.btn_unbudget.Enabled = True
                    Me.DgvAdvanceItemDetil.AllowUserToDeleteRows = True

                End If

                'Tidak ada ID / New
            Else
                If _USERSTRUKTURUNIT = 5559 And approve_user = 1 And approve_bma = 1 Then

                    Me.addBudgetDetil.Enabled = False
                    Me.btn_unbudget.Enabled = False
                    Me.btnOK.Enabled = False
                    Me.DgvAdvanceItemDetil.AllowUserToDeleteRows = False


                ElseIf _USERSTRUKTURUNIT = 5559 And (approve_user = 0 Or approve_user = 1) And approve_bma = 0 Then

                    Me.addBudgetDetil.Enabled = True
                    Me.btn_unbudget.Enabled = True
                    Me.btnOK.Enabled = True
                    Me.DgvAdvanceItemDetil.AllowUserToDeleteRows = True


                ElseIf _USERSTRUKTURUNIT <> 5559 And approve_user = 1 And (approve_bma = 0 Or approve_bma = 1) Then

                    Me.addBudgetDetil.Enabled = False
                    Me.btn_unbudget.Enabled = False
                    Me.btnOK.Enabled = False
                    Me.DgvAdvanceItemDetil.AllowUserToDeleteRows = False

                Else
                    Me.addBudgetDetil.Enabled = True
                    Me.btn_unbudget.Enabled = True
                    Me.btnOK.Enabled = True
                    Me.DgvAdvanceItemDetil.AllowUserToDeleteRows = True

                End If
            End If

            ''''Me.uiTransaksiAdvanceRequest_OutstandingBudget()
            Me.uiTransaksiAdvanceRequest_OutstandingBudget2()
            Me.HitungTotalAmount()

        Catch ex As Exception
        End Try

        MyBase.ShowDialog(owner)

        If Me.CloseButtonIsPressed Then
            Return Me.retObj
        Else
            Return Nothing
        End If
    End Function

    Public Sub New(ByVal strDSN As String, ByVal tbl_TrnAdvanceItemDetils As DataTable, ByVal detilLine As Integer, _
        ByVal tbl_MstCurrencyDetil As DataTable, ByVal budget_code As Decimal, ByVal budget_view As String, _
        ByVal channel As String, ByVal advance_currency As Decimal, ByVal user_strukturunit As Decimal, _
        ByVal tbl_Advancedetileps As DataTable, ByVal tbl_TrnAdvance_Temp As DataTable, ByVal advance_epsend As String, _
        ByVal advance_epsstart As String, ByVal advance_id As String, ByVal advancedetil_line As Integer)
        Me.DSN = strDSN
        Me.tbl_TrnAdvanceItemDetils = tbl_TrnAdvanceItemDetils
        Me.tbl_TrnAdvanceItemDetil_temps = Me.tbl_TrnAdvanceItemDetils.Copy
        Me.tbl_TrnAdvanceItemDetil_temps.Clear()
        Me.detilLine = detilLine
        Me.tbl_MstCurrencyDetil = tbl_MstCurrencyDetil
        Me.budget_code = budget_code
        Me.budget_view = budget_view
        Me.channel = channel
        Me.advance_currency = advance_currency
        Me.user_strukturunit = user_strukturunit
        Me.tbl_Advancedetileps = tbl_Advancedetileps
        Me.tbl_TrnAdvance_Temp = tbl_TrnAdvance_Temp
        Me.advance_epsend = advance_epsend
        Me.advance_epsstart = advance_epsstart
        Me.advance_id = advance_id
        Me.advancedetil_line = advancedetil_line
        ''''Me.tbl_TrnAdvanceItemDetils.Columns.Add(New DataColumn("outstanding_budget", GetType(System.Decimal)))
        ''''Me.tbl_TrnAdvanceItemDetils.Columns("outstanding_budget").DefaultValue = 0

        ''''        If Me.DgvAdvanceItemDetil.Rows.Count > 0 Then
        ''''            Dim s As Integer
        ''''            Dim outstanding As Decimal

        ''''            For s = 0 To Me.tbl_TrnAdvanceItemDetils.Rows.Count - 1
        ''''                outstanding = Me.tbl_TrnAdvanceItemDetils.Rows(s).Item("amount_budget") - Me.tbl_TrnAdvanceItemDetils.Rows(s).Item("amount_idrreal")

        ''''me.tbl_TrnAdvanceItemDetils.Rows.Add(
        ''''            Next
        ''''        End If
        InitializeComponent()
    End Sub

    Private Function FormatDgvTrnAdvanceItemDetil(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        ' formating DgvTrnAdvanceItemDetil

        '''''Dim i As Integer
        Dim cAdvanceDetil_type As New System.Windows.Forms.DataGridViewComboBoxColumn
        Dim cAdvance_id As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAdvanceDetil_line As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBudgetDetil_line As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBudget_name As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cCurrency_id As New System.Windows.Forms.DataGridViewComboBoxColumn
        Dim cBudgetdetil_eps As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cButton_eps As New System.Windows.Forms.DataGridViewButtonColumn
        Dim cBudgetdetil_days As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cChannel_id As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cStrukturunit_id As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAmount_bgt As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAmount_advancebgt As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBudget_id As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cButton_budget_id As New System.Windows.Forms.DataGridViewButtonColumn
        Dim cBudgetdetil_id As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBudgetdetil_name As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cButton_budgetdetil_id As New System.Windows.Forms.DataGridViewButtonColumn
        Dim cAcc_id As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAcc_name As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cVQ_amount As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOutstanding_budget As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOutstanding_approved As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAdvancedetil_foreignrate As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAmount_idrreal As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBudget_accum As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cApproved_bma As New System.Windows.Forms.DataGridViewTextBoxColumn

        Dim cPph_persen As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cPph_amount As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cPpn_persen As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cPpn_amount As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cDiscount As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAmount_subtotal As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAmount_subtotalforeign As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cPpn_no As New System.Windows.Forms.DataGridViewTextBoxColumn

        Dim cAmount_intercompany As New System.Windows.Forms.DataGridViewTextBoxColumn

        Dim cBudget_accumRequest As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAmount_bpj As New System.Windows.Forms.DataGridViewTextBoxColumn

        cAdvanceDetil_type.Name = "advancedetil_type"
        cAdvanceDetil_type.HeaderText = "Type"
        cAdvanceDetil_type.DataPropertyName = "advancedetil_type"

        If tbl_Trnrequestdetil_type.Columns("display_type") IsNot Nothing Then
            cAdvanceDetil_type.DataSource = Me.tbl_Trnrequestdetil_type
            cAdvanceDetil_type.ValueMember = "value_type"
            cAdvanceDetil_type.DisplayMember = "display_type"
        End If

        cAdvanceDetil_type.DisplayStyleForCurrentCellOnly = True
        cAdvanceDetil_type.Width = 100
        cAdvanceDetil_type.Frozen = False
        cAdvanceDetil_type.Visible = False
        cAdvanceDetil_type.ReadOnly = True
        cAdvanceDetil_type.DefaultCellStyle.BackColor = Color.Gainsboro

        cAdvance_id.Name = "advance_id"
        cAdvance_id.HeaderText = "Advance ID"
        cAdvance_id.DataPropertyName = "advance_id"
        cAdvance_id.Width = 100
        cAdvance_id.Visible = False
        cAdvance_id.ReadOnly = True
        cAdvance_id.DefaultCellStyle.BackColor = Color.LightGray

        cAdvanceDetil_line.Name = "advancedetil_line"
        cAdvanceDetil_line.HeaderText = "Line"
        cAdvanceDetil_line.DataPropertyName = "advancedetil_line"
        cAdvanceDetil_line.Width = 40
        cAdvanceDetil_line.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cAdvanceDetil_line.Visible = True
        cAdvanceDetil_line.ReadOnly = True
        cAdvanceDetil_line.DefaultCellStyle.BackColor = Color.LightGray

        cBudgetDetil_line.Name = "budgetdetil_line"
        cBudgetDetil_line.HeaderText = "Budget Line"
        cBudgetDetil_line.DataPropertyName = "budgetdetil_line"
        cBudgetDetil_line.Width = 60
        cBudgetDetil_line.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cBudgetDetil_line.Visible = True
        cBudgetDetil_line.ReadOnly = True
        cBudgetDetil_line.DefaultCellStyle.BackColor = Color.LightGray

        cCurrency_id.Name = "currency_id"
        cCurrency_id.HeaderText = "Currency"
        cCurrency_id.DataPropertyName = "currency_id"
        cCurrency_id.Width = 125
        cCurrency_id.ValueMember = "currency_id"
        cCurrency_id.DisplayMember = "currency_shortname"
        cCurrency_id.DataSource = Me.tbl_MstCurrencyDetil
        cCurrency_id.DisplayStyleForCurrentCellOnly = True
        cCurrency_id.Visible = True
        cCurrency_id.ReadOnly = True
        cCurrency_id.DefaultCellStyle.BackColor = Color.LightGray

        cBudgetdetil_eps.Name = "budgetdetil_eps"
        cBudgetdetil_eps.HeaderText = "Eps."
        cBudgetdetil_eps.DataPropertyName = "budgetdetil_eps"
        cBudgetdetil_eps.Width = 80
        cBudgetdetil_eps.Visible = True
        cBudgetdetil_eps.ReadOnly = True
        cBudgetdetil_eps.DefaultCellStyle.BackColor = Color.LightGray

        cButton_eps.Name = "select_eps"
        cButton_eps.HeaderText = ""
        cButton_eps.Text = "..."
        cButton_eps.UseColumnTextForButtonValue = True
        cButton_eps.CellTemplate.Style.BackColor = Color.LightGray
        cButton_eps.Width = 30
        cButton_eps.DividerWidth = 3
        cButton_eps.Visible = True
        cButton_eps.ReadOnly = False

        cBudgetdetil_days.Name = "budgetdetil_days"
        cBudgetdetil_days.HeaderText = "Days"
        cBudgetdetil_days.DataPropertyName = "budgetdetil_days"
        cBudgetdetil_days.Width = 40
        cBudgetdetil_days.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cBudgetdetil_days.Visible = False
        cBudgetdetil_days.ReadOnly = False

        cAcc_id.Name = "acc_id"
        cAcc_id.HeaderText = "Account ID"
        cAcc_id.DataPropertyName = "acc_id"
        cAcc_id.Width = 100
        cAcc_id.Visible = True
        cAcc_id.ReadOnly = True
        cAcc_id.DefaultCellStyle.BackColor = Color.LightGray

        cAcc_name.Name = "account"
        cAcc_name.HeaderText = "Account"
        cAcc_name.DataPropertyName = "account"
        cAcc_name.Width = 100
        cAcc_name.Visible = True
        cAcc_name.ReadOnly = True
        cAcc_name.DefaultCellStyle.BackColor = Color.LightGray

        cChannel_id.Name = "channel_id"
        cChannel_id.HeaderText = "channel_id"
        cChannel_id.DataPropertyName = "channel_id"
        cChannel_id.Width = 100
        cChannel_id.Visible = False
        cChannel_id.ReadOnly = False

        cStrukturunit_id.Name = "strukturunit_id"
        cStrukturunit_id.HeaderText = "strukturunit_id"
        cStrukturunit_id.DataPropertyName = "strukturunit_id"
        cStrukturunit_id.Width = 100
        cStrukturunit_id.Visible = False
        cStrukturunit_id.ReadOnly = False

        cAmount_bgt.Name = "amount_budget"
        cAmount_bgt.HeaderText = "Budget Amount"
        cAmount_bgt.DataPropertyName = "amount_budget"
        cAmount_bgt.Width = 125
        cAmount_bgt.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cAmount_bgt.DefaultCellStyle.Format = "#,##0.00"
        cAmount_bgt.Visible = True
        cAmount_bgt.ReadOnly = True
        cAmount_bgt.DefaultCellStyle.BackColor = Color.LightGray

        'cAmount_advancebgt.Name = "amount_advance"
        'cAmount_advancebgt.HeaderText = "Amount"
        'cAmount_advancebgt.DataPropertyName = "amount_advance"
        'cAmount_advancebgt.Width = 125
        'cAmount_advancebgt.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'cAmount_advancebgt.DefaultCellStyle.Format = "#,##0.00"
        'cAmount_advancebgt.Visible = True
        'cAmount_advancebgt.ReadOnly = False

        cAmount_advancebgt.Name = "amount_advance"
        cAmount_advancebgt.HeaderText = "Amount"
        cAmount_advancebgt.DataPropertyName = "amount_advance"
        cAmount_advancebgt.Width = 125
        cAmount_advancebgt.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cAmount_advancebgt.DefaultCellStyle.Format = "#,##0.00"
        cAmount_advancebgt.Visible = True
        cAmount_advancebgt.ReadOnly = False

        cBudget_id.Name = "budget_id"
        cBudget_id.HeaderText = "ID"
        cBudget_id.DataPropertyName = "budget_id"
        cBudget_id.Width = 100
        cBudget_id.Visible = False
        cBudget_id.ReadOnly = True

        cBudget_name.Name = "budget_name"
        cBudget_name.HeaderText = "Budget Name"
        cBudget_name.DataPropertyName = "budget_name"
        cBudget_name.Width = 200
        cBudget_name.Visible = True
        cBudget_name.ReadOnly = True
        cBudget_name.DefaultCellStyle.BackColor = Color.LightGray

        cButton_budget_id.Name = "select_budget_header"
        cButton_budget_id.HeaderText = ""
        cButton_budget_id.Text = "..."
        cButton_budget_id.UseColumnTextForButtonValue = True
        cButton_budget_id.CellTemplate.Style.BackColor = Color.LightGray
        cButton_budget_id.Width = 30
        cButton_budget_id.DividerWidth = 3
        cButton_budget_id.Visible = False
        cButton_budget_id.ReadOnly = False

        cButton_budgetdetil_id.Name = "select_budget_detil"
        cButton_budgetdetil_id.HeaderText = ""
        cButton_budgetdetil_id.Text = "..."
        cButton_budgetdetil_id.UseColumnTextForButtonValue = True
        cButton_budgetdetil_id.CellTemplate.Style.BackColor = Color.LightGray
        cButton_budgetdetil_id.Width = 30
        cButton_budgetdetil_id.DividerWidth = 3
        cButton_budgetdetil_id.Visible = False
        cButton_budgetdetil_id.ReadOnly = False

        cBudgetdetil_name.Name = "budgetdetil_name"
        cBudgetdetil_name.HeaderText = "Budget Detil Name"
        cBudgetdetil_name.DataPropertyName = "budgetdetil_name"
        cBudgetdetil_name.Visible = True
        cBudgetdetil_name.Width = 200
        cBudgetdetil_name.ReadOnly = True
        cBudgetdetil_name.DefaultCellStyle.BackColor = Color.LightGray

        cBudgetdetil_id.Name = "budgetdetil_id"
        cBudgetdetil_id.HeaderText = "Code"
        cBudgetdetil_id.DataPropertyName = "budgetdetil_id"
        cBudgetdetil_id.Width = 100
        cBudgetdetil_id.Visible = True
        cBudgetdetil_id.ReadOnly = True
        cBudgetdetil_id.DefaultCellStyle.BackColor = Color.LightGray

        cVQ_amount.Name = "vq_amount"
        cVQ_amount.HeaderText = "Advance Accum."
        cVQ_amount.DataPropertyName = "vq_amount"
        cVQ_amount.Width = 125
        cVQ_amount.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cVQ_amount.DefaultCellStyle.Format = "#,##0.00"
        cVQ_amount.Visible = False
        cVQ_amount.ReadOnly = True

        cOutstanding_budget.Name = "outstanding_budget"
        cOutstanding_budget.HeaderText = "Budget Outstand."
        cOutstanding_budget.DataPropertyName = "outstanding_budget"
        cOutstanding_budget.Width = 125
        cOutstanding_budget.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cOutstanding_budget.DefaultCellStyle.Format = "#,##0.00"
        cOutstanding_budget.Visible = True
        cOutstanding_budget.ReadOnly = True
        cOutstanding_budget.DefaultCellStyle.BackColor = Color.LightGray

        cOutstanding_approved.Name = "outstanding_approved"
        cOutstanding_approved.HeaderText = "Budget Outstand."
        cOutstanding_approved.DataPropertyName = "outstanding_approved"
        cOutstanding_approved.Width = 125
        cOutstanding_approved.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cOutstanding_approved.DefaultCellStyle.Format = "#,##0.00"
        cOutstanding_approved.Visible = False
        cOutstanding_approved.ReadOnly = True
        cOutstanding_approved.DefaultCellStyle.BackColor = Color.LightGray

        cAdvancedetil_foreignrate.Name = "advancedetil_foreignrate"
        cAdvancedetil_foreignrate.HeaderText = "Rate"
        cAdvancedetil_foreignrate.DataPropertyName = "advancedetil_foreignrate"
        cAdvancedetil_foreignrate.Width = 125
        cAdvancedetil_foreignrate.Visible = True
        cAdvancedetil_foreignrate.ReadOnly = False
        cAdvancedetil_foreignrate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cAdvancedetil_foreignrate.DefaultCellStyle.Format = "#,##0.00"
        cAdvancedetil_foreignrate.DefaultCellStyle.BackColor = Color.LightGray

        cAmount_idrreal.Name = "amount_idrreal"
        cAmount_idrreal.HeaderText = "Amount IDR"
        cAmount_idrreal.DataPropertyName = "amount_idrreal"
        cAmount_idrreal.Width = 125
        cAmount_idrreal.Visible = True
        cAmount_idrreal.ReadOnly = True
        cAmount_idrreal.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cAmount_idrreal.DefaultCellStyle.Format = "#,##0.00"
        cAmount_idrreal.DefaultCellStyle.BackColor = Color.LightGray

        cBudget_accum.Name = "budget_accum"
        cBudget_accum.HeaderText = "Budget Accum"
        cBudget_accum.DataPropertyName = "budget_accum"
        cBudget_accum.Width = 125
        cBudget_accum.Visible = True
        cBudget_accum.ReadOnly = True
        cBudget_accum.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cBudget_accum.DefaultCellStyle.Format = "#,##0.00"
        cBudget_accum.DefaultCellStyle.BackColor = Color.LightGray

        cApproved_bma.Name = "amount_approvebma"
        cApproved_bma.HeaderText = "Amount Approve BMA"
        cApproved_bma.DataPropertyName = "amount_approvebma"
        cApproved_bma.Width = 150
        cApproved_bma.Visible = True
        cApproved_bma.ReadOnly = True
        cApproved_bma.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cApproved_bma.DefaultCellStyle.Format = "#,##0.00"
        cApproved_bma.DefaultCellStyle.BackColor = Color.LightGray
        cApproved_bma.SortMode = DataGridViewColumnSortMode.NotSortable

        cPph_persen.Name = "pph_persen"
        cPph_persen.HeaderText = "Pph(%)"
        cPph_persen.DataPropertyName = "pph_persen"
        cPph_persen.Width = 50
        cPph_persen.DefaultCellStyle.Format = "#,##0.00"
        cPph_persen.Visible = True
        cPph_persen.ReadOnly = False
        cPph_persen.DefaultCellStyle.BackColor = Color.Gainsboro
        cPph_persen.SortMode = DataGridViewColumnSortMode.NotSortable

        cPph_amount.Name = "pph_amount"
        cPph_amount.HeaderText = "Pph Amount"
        cPph_amount.DataPropertyName = "pph_amount"
        cPph_amount.Width = 120
        cPph_amount.DefaultCellStyle.Format = "#,##0.00"
        cPph_amount.Visible = True
        cPph_amount.ReadOnly = True
        cPph_amount.DefaultCellStyle.BackColor = Color.Gainsboro
        cPph_amount.SortMode = DataGridViewColumnSortMode.NotSortable

        cPpn_persen.Name = "ppn_persen"
        cPpn_persen.HeaderText = "Ppn(%)"
        cPpn_persen.DataPropertyName = "ppn_persen"
        cPpn_persen.Width = 50
        cPpn_persen.DefaultCellStyle.Format = "#,##0.00"
        cPpn_persen.Visible = True
        cPpn_persen.ReadOnly = False
        cPpn_persen.DefaultCellStyle.BackColor = Color.Gainsboro
        cPpn_persen.SortMode = DataGridViewColumnSortMode.NotSortable

        cPpn_amount.Name = "ppn_amount"
        cPpn_amount.HeaderText = "Ppn Amount"
        cPpn_amount.DataPropertyName = "ppn_amount"
        cPpn_amount.Width = 120
        cPpn_amount.DefaultCellStyle.Format = "#,##0.00"
        cPpn_amount.Visible = True
        cPpn_amount.ReadOnly = True
        cPpn_amount.DefaultCellStyle.BackColor = Color.Gainsboro
        cPpn_amount.SortMode = DataGridViewColumnSortMode.NotSortable

        cPpn_no.Name = "faktur_id"
        cPpn_no.HeaderText = "Ppn No."
        cPpn_no.DataPropertyName = "faktur_id"
        cPpn_no.Width = 120
        cPpn_no.Visible = True
        cPpn_no.ReadOnly = False
        cPpn_no.SortMode = DataGridViewColumnSortMode.NotSortable

        cDiscount.Name = "advancedetil_discount"
        cDiscount.HeaderText = "Discount"
        cDiscount.DataPropertyName = "advancedetil_discount"
        cDiscount.Width = 120
        cDiscount.DefaultCellStyle.Format = "#,##0.00"
        cDiscount.Visible = True
        cDiscount.ReadOnly = False
        cDiscount.DefaultCellStyle.BackColor = Color.Gainsboro
        cDiscount.SortMode = DataGridViewColumnSortMode.NotSortable

        cAmount_subtotal.Name = "amount_subtotal"
        cAmount_subtotal.HeaderText = "Subtotal"
        cAmount_subtotal.DataPropertyName = "amount_subtotal"
        cAmount_subtotal.Width = 120
        cAmount_subtotal.DefaultCellStyle.Format = "#,##0.00"
        cAmount_subtotal.Visible = True
        cAmount_subtotal.ReadOnly = True
        cAmount_subtotal.DefaultCellStyle.BackColor = Color.Gainsboro
        cAmount_subtotal.SortMode = DataGridViewColumnSortMode.NotSortable

        cAmount_subtotalforeign.Name = "amount_subtotalforeign"
        cAmount_subtotalforeign.HeaderText = "Subtotal Foreign"
        cAmount_subtotalforeign.DataPropertyName = "amount_subtotalforeign"
        cAmount_subtotalforeign.Width = 120
        cAmount_subtotalforeign.DefaultCellStyle.Format = "#,##0.00"
        cAmount_subtotalforeign.Visible = False
        cAmount_subtotalforeign.ReadOnly = True
        cAmount_subtotalforeign.DefaultCellStyle.BackColor = Color.Gainsboro
        cAmount_subtotalforeign.SortMode = DataGridViewColumnSortMode.NotSortable

        cAmount_intercompany.Name = "amount_intercompany"
        cAmount_intercompany.HeaderText = "Amount Inter Company"
        cAmount_intercompany.DataPropertyName = "amount_intercompany"
        cAmount_intercompany.Width = 130
        cAmount_intercompany.Visible = True
        cAmount_intercompany.ReadOnly = False
        cAmount_intercompany.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cAmount_intercompany.DefaultCellStyle.Format = "#,##0.00"
        cAmount_intercompany.SortMode = DataGridViewColumnSortMode.NotSortable

        cBudget_accumRequest.Name = "budget_accumRequest"
        cBudget_accumRequest.HeaderText = "budget_accumRequest"
        cBudget_accumRequest.DataPropertyName = "budget_accumRequest"
        cBudget_accumRequest.Width = 130
        cBudget_accumRequest.Visible = False
        cBudget_accumRequest.ReadOnly = False
        cBudget_accumRequest.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cBudget_accumRequest.DefaultCellStyle.Format = "#,##0.00"
        cBudget_accumRequest.SortMode = DataGridViewColumnSortMode.NotSortable

        cAmount_bpj.Name = "amount_bpj"
        cAmount_bpj.HeaderText = "amount_bpj"
        cAmount_bpj.DataPropertyName = "amount_bpj"
        cAmount_bpj.Width = 130
        cAmount_bpj.Visible = False
        cAmount_bpj.ReadOnly = False
        cAmount_bpj.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cAmount_bpj.DefaultCellStyle.Format = "#,##0.00"
        cAmount_bpj.SortMode = DataGridViewColumnSortMode.NotSortable

        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
            {cAdvance_id, _
            cAdvanceDetil_line, cBudgetDetil_line, cAdvanceDetil_type, cBudgetdetil_id, cBudget_id, _
            cBudget_name, cButton_budget_id, cBudgetdetil_eps, cButton_eps, _
            cBudgetdetil_name, cButton_budgetdetil_id, _
            cAcc_name, cCurrency_id, cAmount_bgt, cBudget_accum, cApproved_bma, _
            cVQ_amount, _
            cAmount_advancebgt, cAdvancedetil_foreignrate, cAmount_idrreal, cAmount_intercompany, _
            cDiscount, cPph_persen, cPph_amount, cPpn_persen, cPpn_amount, cPpn_no, _
            cAmount_subtotal, cAmount_subtotalforeign, cOutstanding_budget, cOutstanding_approved, _
             cBudgetdetil_days, _
            cChannel_id, _
            cStrukturunit_id, cAcc_id, cBudget_accumRequest, cAmount_bpj})
        objDgv.AutoGenerateColumns = False

        ''''For i = 0 To objDgv.Columns.Count - 1
        ''''    objDgv.Columns(i).ReadOnly = True
        ''''    objDgv.Columns(i).DefaultCellStyle.BackColor = Color.Gainsboro
        ''''Next
        ''''objDgv.DefaultCellStyle.BackColor = Color.Gainsboro
        objDgv.AllowUserToAddRows = False
        objDgv.AllowUserToDeleteRows = True
    End Function

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click

        Dim thisRetObj As Collection = New Collection

        thisRetObj.Add(tbl_Advancedetileps.Copy(), "tblAdvanceEps")
        ''''thisRetObj.Add(tbl_trnAdvancedetileps_temp.Copy(), "tblAdvanceEps")
        retObj = thisRetObj

        Me.CloseButtonIsPressed = True
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub addBudgetDetil_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles addBudgetDetil.Click
        Dim l As Integer
        Dim line As Integer
        Dim retTbl As DataTable = clsDataset.CreateTblTrnBudgetdetilWithAmount_new 'clsDataset.CreateTblTrnBudgetDetil()
        ''''Dim dlg As New dlgSelectBudgetDetil(Me.DSN)
        Dim dlg As New dlgSelectBudgetDetil2(Me.DSN)
        Dim budget_id, budgetdetil_id As Integer
        Dim tbl_currency As DataTable
        Dim tbl_exrate As DataTable
        Dim oDataFiller As New clsDataFiller(Me.DSN)
        Dim tbl_advance_bma As New DataTable
        Dim amount_advance, advancedetil_foreignrate As Decimal
        Dim total_idr, advancedetil_discount As Decimal
        Dim pph_persen, ppn_persen, pph_amount, ppn_amount As Decimal
        Dim amount_intercompany As Decimal
        Dim tbl_amount_st As New DataTable

        Dim total_foreign As Decimal
        Dim pph_amountforeign As Decimal
        Dim ppn_amountforeign As Decimal

        Dim tbl_budget_accumRequest As New DataTable
        Dim tbl_Amount_bpj As New DataTable

        Try
            If Me.budget_code <> 0 Then
                budget_id = Me.budget_code
                budgetdetil_id = 0 'clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("budgetdetil_id").Value, 0)
                retTbl.Clear()
                Me.Cursor = Cursors.WaitCursor


                If Me.user_strukturunit = 3501 Then
                    Dim j As Integer
                    Dim criteria2 As String = String.Empty

                    If Me.DgvAdvanceItemDetil.Rows.Count > 0 Then
                        For j = 0 To Me.DgvAdvanceItemDetil.Rows.Count - 1
                            If criteria2 = String.Empty Then
                                criteria2 = Me.DgvAdvanceItemDetil.Rows(j).Cells("budgetdetil_id").Value
                            Else
                                criteria2 &= ", " & Me.DgvAdvanceItemDetil.Rows(j).Cells("budgetdetil_id").Value
                            End If
                        Next
                        Me.criteria_budgetdetil = "budgetdetil_id NOT IN (" & criteria2 & ")"
                    Else
                        Me.criteria_budgetdetil = String.Empty
                    End If

                End If

                retTbl = dlg.OpenDialog(budget_id, budgetdetil_id, Me.advance_epsstart, Me.advance_epsend, Me.tbl_Advancedetileps, Me.criteria_budgetdetil, Me)

                Me.Cursor = Cursors.Arrow

                If retTbl IsNot Nothing Then
                    Me.Cursor = Cursors.WaitCursor

                    Dim g As Integer

                    Dim tbl_advancedetil_temp As DataTable
                    Dim tbl_advancedetil_temp2 As DataTable

                    For g = 0 To retTbl.Rows.Count - 1

                        tbl_advancedetil_temp = Me.tbl_TrnAdvanceItemDetils.Copy
                        tbl_advancedetil_temp.DefaultView.Sort = "budgetdetil_line"
                        tbl_advancedetil_temp2 = tbl_advancedetil_temp.DefaultView.ToTable

                        Me.tbl_TrnAdvanceItemDetils.Rows.Add()

                        If tbl_TrnAdvanceItemDetils.Rows.Count > 1 Then
                            If Me.tbl_TrnAdvanceItemDetils.Rows(Me.tbl_TrnAdvanceItemDetils.Rows.Count - 2).RowState <> DataRowState.Deleted Then
                                'ini awal
                                'Me.tbl_TrnAdvanceItemDetils.Rows(Me.tbl_TrnAdvanceItemDetils.Rows.Count - 1).Item("budgetdetil_line") = Me.tbl_TrnAdvanceItemDetils.Rows(Me.tbl_TrnAdvanceItemDetils.Rows.Count - 2).Item("budgetdetil_line") + 10
                                Me.tbl_TrnAdvanceItemDetils.Rows(Me.tbl_TrnAdvanceItemDetils.Rows.Count - 1).Item("budgetdetil_line") = tbl_advancedetil_temp2.Rows(tbl_advancedetil_temp2.Rows.Count - 1).Item("budgetdetil_line") + 10
                            Else
                                'ini awal
                                'Me.tbl_TrnAdvanceItemDetils.Rows(Me.tbl_TrnAdvanceItemDetils.Rows.Count - 1).Item("budgetdetil_line") = Me.tbl_TrnAdvanceItemDetils.Rows(Me.tbl_TrnAdvanceItemDetils.Rows.Count - 1).Item("budgetdetil_line") '+ 10

                                If tbl_advancedetil_temp2.Rows.Count > 0 Then
                                    Me.tbl_TrnAdvanceItemDetils.Rows(Me.tbl_TrnAdvanceItemDetils.Rows.Count - 1).Item("budgetdetil_line") = tbl_advancedetil_temp2.Rows(tbl_advancedetil_temp2.Rows.Count - 1).Item("budgetdetil_line") '+ 10
                                Else
                                    Me.tbl_TrnAdvanceItemDetils.Rows(Me.tbl_TrnAdvanceItemDetils.Rows.Count - 1).Item("budgetdetil_line") = Me.tbl_TrnAdvanceItemDetils.Rows(Me.tbl_TrnAdvanceItemDetils.Rows.Count - 1).Item("budgetdetil_line") '+ 10
                                End If

                            End If
                        Else
                            'ini awal
                            Me.tbl_TrnAdvanceItemDetils.Rows(Me.tbl_TrnAdvanceItemDetils.Rows.Count - 1).Item("budgetdetil_line") = Me.tbl_TrnAdvanceItemDetils.Rows(Me.tbl_TrnAdvanceItemDetils.Rows.Count - 1).Item("budgetdetil_line")
                            'Me.tbl_TrnAdvanceItemDetils.Rows(Me.tbl_TrnAdvanceItemDetils.Rows.Count - 1).Item("budgetdetil_line") = tbl_advancedetil_temp2.Rows(tbl_advancedetil_temp2.Rows.Count - 1).Item("budgetdetil_line")
                        End If
                        line = Me.tbl_TrnAdvanceItemDetils.Rows(Me.tbl_TrnAdvanceItemDetils.Rows.Count - 1).Item("budgetdetil_line")

                        'If retTbl.Rows(g).Item("eps_start") <> 0 Then
                        '    Me.generate_eps2(line, retTbl.Rows(g).Item("eps_start"))
                        'End If

                        If Me.tbl_TrnAdvanceItemDetils.Rows.Count > 0 Then
                            For l = 0 To Me.tbl_TrnAdvanceItemDetils.Rows.Count - 1
                                If Me.tbl_TrnAdvanceItemDetils.Rows(l).RowState <> DataRowState.Deleted Then
                                    If Me.tbl_TrnAdvanceItemDetils.Rows(l).Item("budgetdetil_line") = line Then
                                        If retTbl.Rows.Count <> 0 Then
                                            Me.tbl_TrnAdvanceItemDetils.Rows(l).Item("advancedetil_line") = detilLine
                                            Me.tbl_TrnAdvanceItemDetils.Rows(l).Item("budgetdetil_id") = retTbl.Rows(g).Item("budgetdetil_id")
                                            Me.tbl_TrnAdvanceItemDetils.Rows(l).Item("budgetdetil_name") = retTbl.Rows(g).Item("budgetdetil_desc")
                                            Me.tbl_TrnAdvanceItemDetils.Rows(l).Item("amount_budget") = retTbl.Rows(g).Item("budgetdetil_amount")
                                            Me.tbl_TrnAdvanceItemDetils.Rows(l).Item("amount_advance") = retTbl.Rows(g).Item("outstanding_budget")
                                            Me.tbl_TrnAdvanceItemDetils.Rows(l).Item("acc_id") = retTbl.Rows(g).Item("account_oth")
                                            Me.tbl_TrnAdvanceItemDetils.Rows(l).Item("currency_id") = Me.advance_currency
                                            Me.tbl_TrnAdvanceItemDetils.Rows(l).Item("budget_name") = Me.budget_view
                                            Me.tbl_TrnAdvanceItemDetils.Rows(l).Item("budget_id") = Me.budget_code
                                            Me.tbl_TrnAdvanceItemDetils.Rows(l).Item("strukturunit_id") = Me.user_strukturunit
                                            Me.tbl_TrnAdvanceItemDetils.Rows(l).Item("channel_id") = Me.channel
                                            Me.tbl_TrnAdvanceItemDetils.Rows(l).Item("advance_id") = ""
                                            Me.tbl_TrnAdvanceItemDetils.Rows(l).Item("account") = retTbl.Rows(g).Item("account")

                                            Me.tbl_TrnAdvanceItemDetils.Rows(l).Item("amount_bpj") = Math.Round(retTbl.Rows(g).Item("amount_bpj"), 0, MidpointRounding.AwayFromZero)
                                            Me.tbl_TrnAdvanceItemDetils.Rows(l).Item("budget_accum") = Math.Round(retTbl.Rows(g).Item("amount_st"), 0, MidpointRounding.AwayFromZero)

                                            Try
                                                If retTbl.Rows(g).Item("eps_start") = 0 Then
                                                    Me.tbl_TrnAdvanceItemDetils.Rows(l).Item("budgetdetil_eps") = ""
                                                Else
                                                    Me.tbl_TrnAdvanceItemDetils.Rows(l).Item("budgetdetil_eps") = "Eps. " & retTbl.Rows(g).Item("eps_start")
                                                    Me.generate_eps(line, retTbl.Rows(g).Item("eps_start"))
                                                End If
                                            Catch ex As Exception
                                            End Try

                                            Try
                                                tbl_advance_bma.Clear()

                                                oDataFiller.DataFillAmountAdvance(tbl_advance_bma, "vq_TrnAdvanceItemDetil_AppBma", budget_id, Me.tbl_TrnAdvanceItemDetils.Rows(l).Item("budgetdetil_id"))
                                                If tbl_advance_bma.Rows.Count > 0 Then
                                                    Me.tbl_TrnAdvanceItemDetils.Rows(l).Item("amount_approvebma") = clsUtil.IsDbNull(tbl_advance_bma.Rows(0)("amount_bma_approved"), 0)
                                                Else
                                                    Me.tbl_TrnAdvanceItemDetils.Rows(l).Item("amount_approvebma") = clsUtil.IsDbNull(tbl_advance_bma.Columns("amount_bma_approved").DefaultValue, 0)
                                                End If

                                            Catch ex As Exception
                                                MsgBox("Test 4" & ex.Message)
                                            End Try


                                            Try
                                                'tbl_amount_st.Clear()

                                                'oDataFiller.DataFillAmountAdvance(tbl_amount_st, "vq_TrnAdvanceItemDetil_AmountST2", budget_id, Me.tbl_TrnAdvanceItemDetils.Rows(l).Item("budgetdetil_id"))
                                                'If tbl_amount_st.Rows.Count > 0 Then
                                                '    Me.tbl_TrnAdvanceItemDetils.Rows(l).Item("budget_accum") = clsUtil.IsDbNull(tbl_amount_st.Rows(0)("budget_accum"), 0)
                                                'Else
                                                '    Me.tbl_TrnAdvanceItemDetils.Rows(l).Item("budget_accum") = clsUtil.IsDbNull(tbl_amount_st.Columns("budget_accum").DefaultValue, 0)
                                                'End If
                                            Catch ex As Exception
                                                MsgBox("Test 5" & ex.Message)
                                            End Try

                                            Try

                                                tbl_budget_accumRequest.Clear()

                                                oDataFiller.DataFillAmountAdvance(tbl_budget_accumRequest, "vq_f_TrnOrderdetil_AmountSummmary", budget_id, Me.tbl_TrnAdvanceItemDetils.Rows(l).Item("budgetdetil_id"))
                                                If tbl_budget_accumRequest.Rows.Count > 0 Then

                                                    Me.tbl_TrnAdvanceItemDetils.Rows(l).Item("budget_accumRequest") = clsUtil.IsDbNull(tbl_budget_accumRequest.Rows(0)("budget_accumRequest"), 0)
                                                Else

                                                    Me.tbl_TrnAdvanceItemDetils.Rows(l).Item("budget_accumRequest") = clsUtil.IsDbNull(tbl_budget_accumRequest.Columns("budget_accumRequest").DefaultValue, 0)
                                                End If

                                            Catch ex As Exception
                                                MsgBox("Test 6" & ex.Message)
                                            End Try


                                            Try
                                                'tbl_Amount_bpj.Clear()

                                                'oDataFiller.DataFillAmountAdvance(tbl_Amount_bpj, "vq_TrnAdvanceItemDetil_AmountBPJ", budget_id, Me.tbl_TrnAdvanceItemDetils.Rows(l).Item("budgetdetil_id"))
                                                'If tbl_budget_accumRequest.Rows.Count > 0 Then
                                                '    Me.tbl_TrnAdvanceItemDetils.Rows(l).Item("amount_bpj") = clsUtil.IsDbNull(tbl_Amount_bpj.Rows(0)("amount_bpj"), 0)
                                                'Else
                                                '    Me.tbl_TrnAdvanceItemDetils.Rows(l).Item("amount_bpj") = clsUtil.IsDbNull(tbl_Amount_bpj.Columns("amount_bpj").DefaultValue, 0)
                                                'End If
                                            Catch ex As Exception
                                                MsgBox("Test 6" & ex.Message)
                                            End Try


                                            Try
                                                tbl_currency = New DataTable
                                                oDataFiller.DataFill(tbl_currency, "ms_MstCurrency_Select", String.Format("currency_id = {0}", Me.advance_currency))

                                                tbl_exrate = New DataTable
                                                If Me.advance_currency <> 0 Then
                                                    oDataFiller.DataFill(tbl_exrate, "pr_MstXRate_Select", String.Format("exrate_currency = '{0}'", tbl_currency.Rows(0).Item("currency_shortname")))
                                                End If
                                                Try
                                                    If tbl_exrate.Rows.Count > 0 Then
                                                        Me.tbl_TrnAdvanceItemDetils.Rows(l).Item("advancedetil_foreignrate") = tbl_exrate.Rows(0)("exrate_mid")
                                                    Else
                                                        Me.tbl_TrnAdvanceItemDetils.Rows(l).Item("advancedetil_foreignrate") = 0
                                                    End If
                                                Catch ex As Exception
                                                End Try
                                            Catch ex As Exception

                                            End Try

                                            amount_advance = clsUtil.IsDbNull(Me.tbl_TrnAdvanceItemDetils.Rows(l).Item("amount_advance"), 0)
                                            advancedetil_foreignrate = clsUtil.IsDbNull(Me.tbl_TrnAdvanceItemDetils.Rows(l).Item("advancedetil_foreignrate"), 0)
                                            advancedetil_discount = clsUtil.IsDbNull(Me.tbl_TrnAdvanceItemDetils.Rows(l).Item("advancedetil_discount"), 0)
                                            pph_persen = clsUtil.IsDbNull(Me.tbl_TrnAdvanceItemDetils.Rows(l).Item("pph_persen"), 0)
                                            ppn_persen = clsUtil.IsDbNull(Me.tbl_TrnAdvanceItemDetils.Rows(l).Item("ppn_persen"), 0)
                                            amount_intercompany = clsUtil.IsDbNull(Me.tbl_TrnAdvanceItemDetils.Rows(l).Item("amount_intercompany"), 0)

                                            total_idr = Math.Round((((amount_advance * advancedetil_foreignrate) + (amount_intercompany * advancedetil_foreignrate)) - (advancedetil_discount * advancedetil_foreignrate)), 2, MidpointRounding.AwayFromZero) ''''Math.Round(((amount_advance * advancedetil_foreignrate) - (advancedetil_discount * advancedetil_foreignrate)), 2, MidpointRounding.AwayFromZero)
                                            'pph_amount = Math.Round((Math.Round(((amount_advance - advancedetil_discount) * (pph_persen / 100)), 2, MidpointRounding.AwayFromZero) * advancedetil_foreignrate), 2, MidpointRounding.AwayFromZero) '(total_idr * (pph_persen / 100))
                                            'ppn_amount = Math.Round((Math.Round(((amount_advance - advancedetil_discount) * (ppn_persen / 100)), 2, MidpointRounding.AwayFromZero) * advancedetil_foreignrate), 2, MidpointRounding.AwayFromZero) '(total_idr * (ppn_persen / 100))

                                            Dim accum_advanceinter As Decimal
                                            accum_advanceinter = (amount_advance + amount_intercompany)

                                            pph_amount = Math.Round((Math.Round(((accum_advanceinter - advancedetil_discount) * (pph_persen / 100)), 2, MidpointRounding.AwayFromZero) * advancedetil_foreignrate), 2, MidpointRounding.AwayFromZero) '(total_idr * (pph_persen / 100))
                                            ppn_amount = Math.Round((Math.Round(((accum_advanceinter - advancedetil_discount) * (ppn_persen / 100)), 2, MidpointRounding.AwayFromZero) * advancedetil_foreignrate), 2, MidpointRounding.AwayFromZero) '(total_idr * (ppn_persen / 100))

                                            total_foreign = Math.Round((((amount_advance) + (amount_intercompany)) - (advancedetil_discount)), 2, MidpointRounding.AwayFromZero)
                                            'pph_amountforeign = Math.Round((Math.Round(((amount_advance - advancedetil_discount) * (pph_persen / 100)), 2, MidpointRounding.AwayFromZero)), 2, MidpointRounding.AwayFromZero) '(total_idr * (pph_persen / 100))
                                            'ppn_amountforeign = Math.Round((Math.Round(((amount_advance - advancedetil_discount) * (ppn_persen / 100)), 2, MidpointRounding.AwayFromZero)), 2, MidpointRounding.AwayFromZero) '(total_idr * (ppn_persen / 100))

                                            pph_amountforeign = Math.Round((Math.Round(((accum_advanceinter - advancedetil_discount) * (pph_persen / 100)), 2, MidpointRounding.AwayFromZero)), 2, MidpointRounding.AwayFromZero) '(total_idr * (pph_persen / 100))
                                            ppn_amountforeign = Math.Round((Math.Round(((accum_advanceinter - advancedetil_discount) * (ppn_persen / 100)), 2, MidpointRounding.AwayFromZero)), 2, MidpointRounding.AwayFromZero) '(total_idr * (ppn_persen / 100))

                                            'Me.tbl_TrnAdvanceItemDetils.Rows(l).Item("amount_idrreal") = clsUtil.IsDbNull(Me.tbl_TrnAdvanceItemDetils.Rows(l).Item("amount_advance"), 0) * clsUtil.IsDbNull(Me.tbl_TrnAdvanceItemDetils.Rows(l).Item("advancedetil_foreignrate"), 0)
                                            Me.tbl_TrnAdvanceItemDetils.Rows(l).Item("amount_idrreal") = Math.Round((amount_advance * advancedetil_foreignrate), 2, MidpointRounding.AwayFromZero)
                                            Me.tbl_TrnAdvanceItemDetils.Rows(l).Item("amount_subtotal") = Math.Round((total_idr - pph_amount + ppn_amount), 2, MidpointRounding.AwayFromZero)

                                            'If Me.tbl_TrnAdvanceItemDetils.Rows(l).Item("currency_id") = 1 Then
                                            '    Me.tbl_TrnAdvanceItemDetils.Rows(l).Item("amount_subtotalforeign") = Math.Round((total_foreign - pph_amountforeign + ppn_amountforeign), 0, MidpointRounding.AwayFromZero)
                                            'Else
                                            Me.tbl_TrnAdvanceItemDetils.Rows(l).Item("amount_subtotalforeign") = Math.Round((total_foreign - pph_amountforeign + ppn_amountforeign), 2, MidpointRounding.AwayFromZero)
                                            'End If


                                            ' ''Me.uiTransaksiAdvanceRequest_OutstandingBudget2(l)
                                        End If
                                    End If
                                End If
                            Next
                        End If
                    Next
                Else
                    Exit Sub
                End If
                Me.Cursor = Cursors.Arrow
            Else
                Dim ErrorMessage As String = ""
                Dim ErrorFound As Boolean = False

                'tambahan baru 01/06/2009
            End If
        Catch ex As Exception
        End Try

        Dim a As Integer
        Dim amount As Decimal
        Dim amount_foreignreal As Decimal

        For a = 0 To Me.DgvAdvanceItemDetil.Rows.Count - 1
            'amount += clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(a).Cells("amount_idrreal").Value, 0)
            If clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(a).Cells("currency_id").Value, 0) = 1 Then
                amount += Math.Round(clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(a).Cells("amount_subtotal").Value, 0), 0, MidpointRounding.AwayFromZero)
                amount_foreignreal += Math.Round(clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(a).Cells("amount_advance").Value, 0), 0, MidpointRounding.AwayFromZero)
            Else
                amount += Math.Round(clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(a).Cells("amount_subtotal").Value, 0), 2, MidpointRounding.AwayFromZero)
                amount_foreignreal += Math.Round(clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(a).Cells("amount_advance").Value, 0), 2, MidpointRounding.AwayFromZero)
            End If
            
        Next

        Me.obj_total_amount.Text = Format(amount, "#,##0.00")

        '''' 03-01-2011 Me.uiTransaksiAdvanceRequest_OutstandingBudget()
        Me.uiTransaksiAdvanceRequest_OutstandingBudget2()

    End Sub

    Private Sub DgvAdvanceItemDetil_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvAdvanceItemDetil.CellClick
        If e.RowIndex >= 0 Then
            Select Case e.ColumnIndex
                Case Me.DgvAdvanceItemDetil.Columns("select_budget_detil").Index
                    If Me.DgvAdvanceItemDetil.Rows(e.RowIndex).Cells("advancedetil_type").Value = 1 And Me.DgvAdvanceItemDetil.Rows(e.RowIndex).Cells("select_budget_detil").ReadOnly = False Then
                        Dim retTbl As DataTable = clsDataset.CreateTblTrnBudgetDetil()
                        Dim dlg As New dlgSelectBudgetDetil(Me.DSN)
                        Dim budget_id, budgetdetil_id As Integer

                        budget_id = clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(e.RowIndex).Cells("budget_id").Value, 0)
                        budgetdetil_id = clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(e.RowIndex).Cells("budgetdetil_id").Value, 0)
                        retTbl.Clear()
                        Me.Cursor = Cursors.WaitCursor
                        retTbl = dlg.OpenDialog(budget_id, budgetdetil_id, Me)
                        Me.Cursor = Cursors.Arrow

                        If retTbl IsNot Nothing Then
                            If retTbl.Rows.Count <> 0 Then
                                Me.DgvAdvanceItemDetil.Rows(e.RowIndex).Cells("budgetdetil_id").Value = retTbl.Rows(0).Item("budgetdetil_id")
                                Me.DgvAdvanceItemDetil.Rows(e.RowIndex).Cells("budgetdetil_name").Value = retTbl.Rows(0).Item("budgetdetil_desc")
                                Me.DgvAdvanceItemDetil.Rows(e.RowIndex).Cells("amount_budget").Value = retTbl.Rows(0).Item("budgetdetil_amount")
                                Me.DgvAdvanceItemDetil.Rows(e.RowIndex).Cells("acc_id").Value = retTbl.Rows(0).Item("account")
                            End If
                        End If

                        Dim a As Integer
                        Dim amount As Decimal

                        For a = 0 To Me.DgvAdvanceItemDetil.Rows.Count - 1
                            amount += Me.DgvAdvanceItemDetil.Rows(a).Cells("amount_advance").Value
                        Next


                        '''''Else
                        '''''    If Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("advancedetil_ordered").Value = 0 And Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("advancedetil_approvedbma").Value = 0 And Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("advancedetil_approvedproc").Value = 0 Then

                        '''''        Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("select_budget_detil").ReadOnly = False

                        '''''        '''Dim retTbl As DataTable = clsDataset.CreateTblTrnBudgetDetil()
                        '''''        '''Dim dlg As New dlgSelectBudgetDetil(Me.DSN)
                        '''''        Dim budget_id, budgetdetil_id As Decimal

                        '''''        budget_id = clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("budget_id").Value, 0)
                        '''''        budgetdetil_id = clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("budgetdetil_id").Value, 0)
                        '''''        '''retTbl.Clear()
                        '''''        Me.Cursor = Cursors.WaitCursor
                        '''''        '''retTbl = dlg.OpenDialog(budget_id, budgetdetil_id, Me)
                        '''''        Me.Cursor = Cursors.Arrow

                        '''''        '''If retTbl IsNot Nothing Then
                        '''''        '''    If retTbl.Rows.Count <> 0 Then
                        '''''        '''        Me.Dgvitembudgetdetil.Rows(e.RowIndex).Cells("budgetdetil_id").Value = retTbl.Rows(0).Item("budgetdetil_id")
                        '''''        '''    End If
                        '''''        '''End If
                        '''''End If
                    End If

                Case Me.DgvAdvanceItemDetil.Columns("select_eps").Index
                    Dim obj As SelectEpsDialogReturn
                    Dim budgetdetil_line As Integer = Me.DgvAdvanceItemDetil.Rows(e.RowIndex).Cells("budgetdetil_line").Value
                    Dim budget_name As String = clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(e.RowIndex).Cells("budget_name").Value, "")
                    Dim advancedetil_line As Integer = Me.DgvAdvanceItemDetil.Rows(0).Cells("advancedetil_line").Value

                    obj = Me.dlgTrnAdvance_Open(Me.tbl_Advancedetileps, budgetdetil_line, budget_name, advancedetil_line)

                    If obj IsNot Nothing Then
                        If obj.budgetdetil_eps > 0 Then
                            Me.DgvAdvanceItemDetil.Rows(e.RowIndex).Cells("budgetdetil_eps").Value = "Eps. " & obj.budgetdetil_eps
                        Else
                            Me.DgvAdvanceItemDetil.Rows(e.RowIndex).Cells("budgetdetil_eps").Value = ""

                        End If
                    End If

                    Me.tbl_Advancedetileps.DefaultView.RowFilter = "checked=1"
                    Me.tbl_Advancedetileps.DefaultView.Sort = "budgetdetil_line"

            End Select
        End If
    End Sub

    Private Function dlgTrnAdvance_Open(ByRef tbl_Advancedetileps As DataTable, ByRef budgetdetil_line As Integer, ByRef budget_name As String, ByRef advancedetil_line As Integer) As SelectEpsDialogReturn
        Dim frmSelectEps As dlgTrnAdvance_SelectEps = New dlgTrnAdvance_SelectEps()
        Dim obj As SelectEpsDialogReturn
        Dim epsstart As Integer
        Dim epsend As Integer

        frmSelectEps.ShowInTaskbar = False
        frmSelectEps.StartPosition = FormStartPosition.CenterParent
        ''''frmSelectEps.FormBorderStyle = FormBorderStyle.FixedDialog
        frmSelectEps.MinimizeBox = False
        frmSelectEps.MaximizeBox = False

        If Me.tbl_TrnAdvance_Temp.Rows.Count > 0 Then
            epsstart = Me.tbl_TrnAdvance_Temp.Rows(0).Item("advance_epsstart")
            epsend = Me.tbl_TrnAdvance_Temp.Rows(0).Item("advance_epsend")
        Else
            epsstart = Me.advance_epsstart
            epsend = Me.advance_epsend
        End If

        obj = frmSelectEps.OpenDialog(Me.tbl_Advancedetileps, epsstart, epsend, budgetdetil_line, budget_name, advancedetil_line, Me)
        If obj IsNot Nothing Then
            Me.advance_epsstart = obj.epsstart
            Me.advance_epsend = obj.epsend
        End If

        Dim tblChanges As DataTable = Me.tbl_Advancedetileps.GetChanges()
        If tblChanges IsNot Nothing Then
        End If

        Return obj

    End Function

    Private Sub DgvAdvanceItemDetil_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DgvAdvanceItemDetil.CellFormatting
        If Me.DgvAdvanceItemDetil.Rows(e.RowIndex).Cells("outstanding_budget").Value < 0 Then
            If Me.DgvAdvanceItemDetil.Rows(e.RowIndex).Cells(e.ColumnIndex).ReadOnly = True Then
                Me.DgvAdvanceItemDetil.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = Color.MistyRose
            Else
                Me.DgvAdvanceItemDetil.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = Color.LavenderBlush
            End If
        Else
            If Me.DgvAdvanceItemDetil.Rows(e.RowIndex).Cells(e.ColumnIndex).ReadOnly = True Then
                Me.DgvAdvanceItemDetil.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = Color.LightGray
            Else
                Me.DgvAdvanceItemDetil.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = Color.White
            End If
        End If
    End Sub

    Private Sub DgvAdvanceItemDetil_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvAdvanceItemDetil.CellValueChanged
        Dim amount, amount_foreignreal As Decimal
        Dim a As Integer


        Select Case e.ColumnIndex
            Case Me.DgvAdvanceItemDetil.Columns("amount_advance").Index
                ''''uiTransaksiAdvanceRequest_OutstandingBudget()

                'uiTransaksiAdvanceRequest_OutstandingBudget_CellValueChanges()
                uiTransaksiAdvanceRequest_OutstandingBudget_CellValueChanges2(e.RowIndex)

                'amount_advance = clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(e.RowIndex).Cells("amount_advance").Value, 0)
                'advancedetil_foreignrate = clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(e.RowIndex).Cells("advancedetil_foreignrate").Value, 0)
                'advancedetil_discount = clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(e.RowIndex).Cells("advancedetil_discount").Value, 0)
                'pph_persen = clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(e.RowIndex).Cells("pph_persen").Value, 0)
                'ppn_persen = clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(e.RowIndex).Cells("ppn_persen").Value, 0)

                'total_idr = ((amount_advance * advancedetil_foreignrate) - (advancedetil_discount * advancedetil_foreignrate))
                'pph_amount = (total_idr * (pph_persen / 100))
                'ppn_amount = (total_idr * (ppn_persen / 100))

                ''Me.DgvAdvanceItemDetil.Rows(e.RowIndex).Cells("amount_idrreal").Value = clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(e.RowIndex).Cells("amount_advance").Value, 0) * clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(e.RowIndex).Cells("advancedetil_foreignrate").Value, 0)
                'Me.DgvAdvanceItemDetil.Rows(e.RowIndex).Cells("amount_idrreal").Value = total_idr - pph_amount + ppn_amount

                For a = 0 To Me.DgvAdvanceItemDetil.Rows.Count - 1
                    'amount += clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(a).Cells("amount_idrreal").Value, 0)
                    amount += clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(a).Cells("amount_subtotal").Value, 0)
                    amount_foreignreal += clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(a).Cells("amount_advance").Value, 0)
                Next
                Me.obj_total_amount.Text = Format(amount, "#,##0.00")

            Case Me.DgvAdvanceItemDetil.Columns("currency_id").Index
                'Me.DgvAdvanceItemDetil.Rows(e.RowIndex).Cells("amount_idrreal").Value = clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(e.RowIndex).Cells("amount_advance").Value, 0) * clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(e.RowIndex).Cells("advancedetil_foreignrate").Value, 0)

                uiTransaksiAdvanceRequest_OutstandingBudget_CellValueChanges2(e.RowIndex)

                'amount_advance = clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(e.RowIndex).Cells("amount_advance").Value, 0)
                'advancedetil_foreignrate = clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(e.RowIndex).Cells("advancedetil_foreignrate").Value, 0)
                'advancedetil_discount = clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(e.RowIndex).Cells("advancedetil_discount").Value, 0)
                'pph_persen = clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(e.RowIndex).Cells("pph_persen").Value, 0)
                'ppn_persen = clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(e.RowIndex).Cells("ppn_persen").Value, 0)

                'total_idr = ((amount_advance * advancedetil_foreignrate) - (advancedetil_discount * advancedetil_foreignrate))
                'pph_amount = (total_idr * (pph_persen / 100))
                'ppn_amount = (total_idr * (ppn_persen / 100))

                'Me.DgvAdvanceItemDetil.Rows(e.RowIndex).Cells("amount_idrreal").Value = total_idr - pph_amount + ppn_amount

                For a = 0 To Me.DgvAdvanceItemDetil.Rows.Count - 1
                    'amount += clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(a).Cells("amount_idrreal").Value, 0)
                    amount += clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(a).Cells("amount_subtotal").Value, 0)
                    amount_foreignreal += clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(a).Cells("amount_advance").Value, 0)
                Next
                Me.obj_total_amount.Text = Format(amount, "#,##0.00")


            Case Me.DgvAdvanceItemDetil.Columns("advancedetil_discount").Index
                uiTransaksiAdvanceRequest_OutstandingBudget_CellValueChanges2(e.RowIndex)

                'amount_advance = clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(e.RowIndex).Cells("amount_advance").Value, 0)
                'advancedetil_foreignrate = clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(e.RowIndex).Cells("advancedetil_foreignrate").Value, 0)
                'advancedetil_discount = clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(e.RowIndex).Cells("advancedetil_discount").Value, 0)
                'pph_persen = clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(e.RowIndex).Cells("pph_persen").Value, 0)
                'ppn_persen = clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(e.RowIndex).Cells("ppn_persen").Value, 0)

                'total_idr = ((amount_advance * advancedetil_foreignrate) - (advancedetil_discount * advancedetil_foreignrate))
                'pph_amount = (total_idr * (pph_persen / 100))
                'ppn_amount = (total_idr * (ppn_persen / 100))

                'Me.DgvAdvanceItemDetil.Rows(e.RowIndex).Cells("amount_idrreal").Value = total_idr - pph_amount + ppn_amount

                For a = 0 To Me.DgvAdvanceItemDetil.Rows.Count - 1
                    'amount += clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(a).Cells("amount_idrreal").Value, 0)
                    amount += clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(a).Cells("amount_subtotal").Value, 0)
                    amount_foreignreal += clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(a).Cells("amount_advance").Value, 0)
                Next

                Me.obj_total_amount.Text = Format(amount, "#,##0.00")

            Case Me.DgvAdvanceItemDetil.Columns("pph_persen").Index
                uiTransaksiAdvanceRequest_OutstandingBudget_CellValueChanges2(e.RowIndex)

                'amount_advance = clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(e.RowIndex).Cells("amount_advance").Value, 0)
                'advancedetil_foreignrate = clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(e.RowIndex).Cells("advancedetil_foreignrate").Value, 0)
                'advancedetil_discount = clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(e.RowIndex).Cells("advancedetil_discount").Value, 0)
                'pph_persen = clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(e.RowIndex).Cells("pph_persen").Value, 0)
                'ppn_persen = clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(e.RowIndex).Cells("ppn_persen").Value, 0)

                'total_idr = ((amount_advance * advancedetil_foreignrate) - (advancedetil_discount * advancedetil_foreignrate))
                'pph_amount = (total_idr * (pph_persen / 100))
                'ppn_amount = (total_idr * (ppn_persen / 100))

                'Me.DgvAdvanceItemDetil.Rows(e.RowIndex).Cells("pph_amount").Value = pph_amount
                'Me.DgvAdvanceItemDetil.Rows(e.RowIndex).Cells("amount_idrreal").Value = total_idr - pph_amount + ppn_amount

                For a = 0 To Me.DgvAdvanceItemDetil.Rows.Count - 1
                    'amount += clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(a).Cells("amount_idrreal").Value, 0)
                    amount += clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(a).Cells("amount_subtotal").Value, 0)
                    amount_foreignreal += clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(a).Cells("amount_advance").Value, 0)
                Next

                Me.obj_total_amount.Text = Format(amount, "#,##0.00")

            Case Me.DgvAdvanceItemDetil.Columns("ppn_persen").Index
                uiTransaksiAdvanceRequest_OutstandingBudget_CellValueChanges2(e.RowIndex)

                'amount_advance = clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(e.RowIndex).Cells("amount_advance").Value, 0)
                'advancedetil_foreignrate = clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(e.RowIndex).Cells("advancedetil_foreignrate").Value, 0)
                'advancedetil_discount = clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(e.RowIndex).Cells("advancedetil_discount").Value, 0)
                'pph_persen = clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(e.RowIndex).Cells("pph_persen").Value, 0)
                'ppn_persen = clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(e.RowIndex).Cells("ppn_persen").Value, 0)

                'total_idr = ((amount_advance * advancedetil_foreignrate) - (advancedetil_discount * advancedetil_foreignrate))
                'pph_amount = (total_idr * (pph_persen / 100))
                'ppn_amount = (total_idr * (ppn_persen / 100))

                'Me.DgvAdvanceItemDetil.Rows(e.RowIndex).Cells("ppn_amount").Value = ppn_amount
                'Me.DgvAdvanceItemDetil.Rows(e.RowIndex).Cells("amount_idrreal").Value = total_idr - pph_amount + ppn_amount

                For a = 0 To Me.DgvAdvanceItemDetil.Rows.Count - 1
                    'amount += clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(a).Cells("amount_idrreal").Value, 0)
                    amount += clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(a).Cells("amount_subtotal").Value, 0)
                    amount_foreignreal += clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(a).Cells("amount_advance").Value, 0)
                Next

                Me.obj_total_amount.Text = Format(amount, "#,##0.00")

            Case Me.DgvAdvanceItemDetil.Columns("amount_intercompany").Index
                uiTransaksiAdvanceRequest_OutstandingBudget_CellValueChanges2(e.RowIndex)
                For a = 0 To Me.DgvAdvanceItemDetil.Rows.Count - 1
                    'amount += clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(a).Cells("amount_idrreal").Value, 0)
                    amount += clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(a).Cells("amount_subtotal").Value, 0)
                    amount_foreignreal += clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(a).Cells("amount_advance").Value, 0)
                Next
                Me.obj_total_amount.Text = Format(amount, "#,##0.00")


            Case Me.DgvAdvanceItemDetil.Columns("advancedetil_foreignrate").Index
                Me.uiTransaksiAdvanceRequest_OutstandingBudget_CellValueChanges2(e.RowIndex)
                For a = 0 To Me.DgvAdvanceItemDetil.Rows.Count - 1
                    amount += clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(a).Cells("amount_subtotal").Value, 0)
                    amount_foreignreal += clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(a).Cells("amount_advance").Value, 0)
                Next
                Me.obj_total_amount.Text = Format(amount, "#,##0.00")
        End Select




        ''''uiTransaksiAdvanceRequest_OutstandingBudget()
    End Sub

    Private Function uiTransaksiAdvanceRequest_OutstandingBudget() As Boolean
        Dim b As Integer
        Dim amount_budget As Decimal
        Dim amount_idrreal As Decimal
        Dim outstanding_budget, rate, budget_accum, amount_approvebma As Decimal
        Dim tbl_amount_st As New DataTable
        Dim budget_id, budgetdetil_id As Decimal
        Dim oDataFiller As New clsDataFiller(Me.DSN)
        Dim amount_advance, advancedetil_foreignrate, advancedetil_discount As Decimal
        Dim total_idr As Decimal
        Dim pph_persen, ppn_persen, pph_amount, ppn_amount As Decimal
        Dim amount_subtotal As Decimal
        Dim amount_intercompany As Decimal

        Dim total_foreign As Decimal
        Dim pph_amountforeign As Decimal
        Dim ppn_amountforeign As Decimal
        Dim amount_subtotalforeign As Decimal

        Dim budget_accumRequest As Decimal

        Me.DgvAdvanceItemDetil.EndEdit()

        For b = 0 To Me.DgvAdvanceItemDetil.Rows.Count - 1
            'Me.DgvItemBudgetDetil.Rows(b).Cells("outstanding_budget").Value = clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(b).Cells("amount_budget").Value, 0) - clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(b).Cells("amount_idrreal").Value, 0)
            amount_budget = clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(b).Cells("amount_budget").Value, 0)
            rate = clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(b).Cells("advancedetil_foreignrate").Value, 0)
            'amount_idrreal = clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(b).Cells("amount_advance").Value, 0) * clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(b).Cells("advancedetil_foreignrate").Value, 0)

            amount_advance = Math.Round(clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(b).Cells("amount_advance").Value, 0), 2, MidpointRounding.AwayFromZero)
            advancedetil_foreignrate = clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(b).Cells("advancedetil_foreignrate").Value, 0)
            advancedetil_discount = Math.Round(clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(b).Cells("advancedetil_discount").Value, 0), 2, MidpointRounding.AwayFromZero)
            pph_persen = clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(b).Cells("pph_persen").Value, 0)
            ppn_persen = clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(b).Cells("ppn_persen").Value, 0)

            If clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(b).Cells("currency_id").Value, 0) = 1 Then
                amount_intercompany = Math.Round(clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(b).Cells("amount_intercompany").Value, 0), 0, MidpointRounding.AwayFromZero)
            Else
                amount_intercompany = Math.Round(clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(b).Cells("amount_intercompany").Value, 0), 2, MidpointRounding.AwayFromZero)
            End If

            total_idr = Math.Round((((amount_advance * advancedetil_foreignrate) + (amount_intercompany * advancedetil_foreignrate) - (advancedetil_discount * advancedetil_foreignrate))), 0, MidpointRounding.AwayFromZero)
            ''''Math.Round(((Math.Round((amount_advance * advancedetil_foreignrate), 0) + Math.Round((amount_intercompany * advancedetil_foreignrate), 0) - Math.Round((advancedetil_discount * advancedetil_foreignrate), 0))), 0, MidpointRounding.AwayFromZero)

            '' ''total_idr = Math.Round((((amount_advance * advancedetil_foreignrate) + (amount_intercompany * advancedetil_foreignrate)) - (advancedetil_discount * advancedetil_foreignrate)), 2, MidpointRounding.AwayFromZero) ''''Math.Round(((amount_advance * advancedetil_foreignrate) - (advancedetil_discount * advancedetil_foreignrate)), 2, MidpointRounding.AwayFromZero)
            'pph_amount = Math.Round((((amount_advance - advancedetil_discount) * (pph_persen / 100)) * advancedetil_foreignrate), 0, MidpointRounding.AwayFromZero)
            'ppn_amount = Math.Round((((amount_advance - advancedetil_discount) * (ppn_persen / 100)) * advancedetil_foreignrate), 0, MidpointRounding.AwayFromZero)

            Dim accum_advanceinter As Decimal
            accum_advanceinter = (amount_advance + amount_intercompany)

            pph_amount = Math.Round((((accum_advanceinter - advancedetil_discount) * (pph_persen / 100)) * advancedetil_foreignrate), 0, MidpointRounding.AwayFromZero)
            ppn_amount = Math.Round((((accum_advanceinter - advancedetil_discount) * (ppn_persen / 100)) * advancedetil_foreignrate), 0, MidpointRounding.AwayFromZero)

            amount_idrreal = Math.Round((amount_advance * advancedetil_foreignrate), 0, MidpointRounding.AwayFromZero)
            amount_subtotal = Math.Round((total_idr - pph_amount + ppn_amount), 0, MidpointRounding.AwayFromZero)

            total_foreign = Math.Round((((amount_advance) + (amount_intercompany)) - (advancedetil_discount)), 2, MidpointRounding.AwayFromZero)
            ''''Math.Round(((amount_advance * advancedetil_foreignrate) - (advancedetil_discount * advancedetil_foreignrate)), 2, MidpointRounding.AwayFromZero)
            'pph_amountforeign = Math.Round((((amount_advance - advancedetil_discount) * (pph_persen / 100))), 2, MidpointRounding.AwayFromZero)
            'ppn_amountforeign = Math.Round((((amount_advance - advancedetil_discount) * (ppn_persen / 100))), 2, MidpointRounding.AwayFromZero)

            pph_amountforeign = Math.Round((((accum_advanceinter - advancedetil_discount) * (pph_persen / 100))), 2, MidpointRounding.AwayFromZero)
            ppn_amountforeign = Math.Round((((accum_advanceinter - advancedetil_discount) * (ppn_persen / 100))), 2, MidpointRounding.AwayFromZero)

            'If Me.DgvAdvanceItemDetil.Rows(b).Cells("currency_id").Value = 1 Then
            '    amount_subtotalforeign = Math.Round((total_foreign - pph_amountforeign + ppn_amountforeign), 0, MidpointRounding.AwayFromZero)
            'Else
            amount_subtotalforeign = Math.Round((total_foreign - pph_amountforeign + ppn_amountforeign), 2, MidpointRounding.AwayFromZero)
            'End If


            Me.DgvAdvanceItemDetil.Rows(b).Cells("pph_amount").Value = pph_amount
            Me.DgvAdvanceItemDetil.Rows(b).Cells("ppn_amount").Value = ppn_amount

            Me.DgvAdvanceItemDetil.Rows(b).Cells("amount_idrreal").Value = amount_idrreal
            Me.DgvAdvanceItemDetil.Rows(b).Cells("amount_subtotal").Value = amount_subtotal
            Me.DgvAdvanceItemDetil.Rows(b).Cells("amount_subtotalforeign").Value = amount_subtotalforeign

            budget_id = clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(b).Cells("budget_id").Value, 0)
            budgetdetil_id = clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(b).Cells("budgetdetil_id").Value, 0)

            Try
                'tbl_advance_bma = New DataTable
                'tbl_advance_bma.Clear()
                'oDataFiller.DataFillAmountAdvance(tbl_advance_bma, "vq_TrnAdvanceItemDetil_ApprovedBma", budget_id, budgetdetil_id)
                'If tbl_advance_bma.Rows.Count > 0 Then
                '    Me.DgvAdvanceItemDetil.Rows(b).Cells("amount_approvebma").Value = clsUtil.IsDbNull(tbl_advance_bma.Rows(0)("amount_bma_approved"), 0)
                'Else
                '    Me.DgvAdvanceItemDetil.Rows(b).Cells("amount_approvebma").Value = clsUtil.IsDbNull(tbl_advance_bma.Columns("amount_bma_approved").DefaultValue, 0)
                'End If

                amount_approvebma = clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(b).Cells("amount_approvebma").Value, 0)

            Catch ex As Exception
                MsgBox("Test 4" & ex.Message)
            End Try

            Try
                'tbl_amount_st.Clear()

                'oDataFiller.DataFillAmountAdvance(tbl_amount_st, "vq_TrnAdvanceItemDetil_AmountST", budget_id, budgetdetil_id)
                'If tbl_amount_st.Rows.Count > 0 Then
                '    Me.DgvAdvanceItemDetil.Rows(b).Cells("budget_accum").Value = clsUtil.IsDbNull(tbl_amount_st.Rows(0)("budget_accum"), 0)
                'Else
                '    Me.DgvAdvanceItemDetil.Rows(b).Cells("budget_accum").Value = clsUtil.IsDbNull(tbl_amount_st.Columns("budget_accum").DefaultValue, 0)
                'End If
            Catch ex As Exception
                MsgBox("Test 5" & ex.Message)
            End Try

            budget_accum = clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(b).Cells("budget_accum").Value, 0)

            budget_accumRequest = clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(b).Cells("budget_accumRequest").Value, 0)

            'outstanding_budget = amount_budget - amount_idrreal - amount_approvebma + budget_accum
            ''''outstanding_budget = amount_budget - (amount_idrreal - (advancedetil_discount * advancedetil_foreignrate)) - amount_approvebma + budget_accum 'amount_budget - amount_subtotal - amount_approvebma + budget_accum

            ''''baru tgl 26-08-2010
            outstanding_budget = Math.Round((amount_budget - (amount_idrreal - (advancedetil_discount * advancedetil_foreignrate)) - amount_approvebma - budget_accumRequest + budget_accum), 0, MidpointRounding.AwayFromZero)
            ''''amount_budget - (amount_idrreal - Math.Round((advancedetil_discount * advancedetil_foreignrate), 0)) - amount_approvebma - budget_accumRequest + budget_accum 
            'amount_budget - amount_subtotal - amount_approvebma + budget_accum


            If Me.bma_approve = 1 Then
                Me.DgvAdvanceItemDetil.Rows(b).Cells("outstanding_budget").Value = Me.DgvAdvanceItemDetil.Rows(b).Cells("outstanding_approved").Value 'Me.tbl_TrnAdvanceItemDetils.Rows(u).Item("outstanding_approved")
                Me.DgvAdvanceItemDetil.Rows(b).Cells("outstanding_approved").Value = Me.DgvAdvanceItemDetil.Rows(b).Cells("outstanding_approved").Value 'Me.tbl_TrnAdvanceItemDetils.Rows(u).Item("outstanding_approved")
            Else
                Me.DgvAdvanceItemDetil.Rows(b).Cells("outstanding_budget").Value = outstanding_budget
                Me.DgvAdvanceItemDetil.Rows(b).Cells("outstanding_approved").Value = outstanding_budget
            End If
        Next

    End Function

    Private Function uiTransaksiAdvanceRequest_OutstandingBudget2() As Boolean
        Dim b As Integer
        Dim amount_budget As Decimal
        Dim amount_idrreal As Decimal
        Dim outstanding_budget, rate, budget_accum, amount_approvebma As Decimal
        Dim tbl_amount_st As New DataTable
        Dim budget_id, budgetdetil_id As Decimal
        Dim oDataFiller As New clsDataFiller(Me.DSN)
        Dim amount_advance, advancedetil_foreignrate, advancedetil_discount As Decimal
        Dim total_idr As Decimal
        Dim pph_persen, ppn_persen, pph_amount, ppn_amount As Decimal
        Dim amount_subtotal As Decimal
        Dim amount_intercompany As Decimal

        Dim total_foreign As Decimal
        Dim pph_amountforeign As Decimal
        Dim ppn_amountforeign As Decimal
        Dim amount_subtotalforeign As Decimal

        Dim budget_accumRequest As Decimal
        Dim amount_bpj As Decimal

        Me.DgvAdvanceItemDetil.EndEdit()

        For b = 0 To Me.DgvAdvanceItemDetil.Rows.Count - 1

            rate = clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(b).Cells("advancedetil_foreignrate").Value, 0)
            
            advancedetil_foreignrate = clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(b).Cells("advancedetil_foreignrate").Value, 0)
            advancedetil_discount = Math.Round(clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(b).Cells("advancedetil_discount").Value, 0), 2, MidpointRounding.AwayFromZero)
            pph_persen = clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(b).Cells("pph_persen").Value, 0)
            ppn_persen = clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(b).Cells("ppn_persen").Value, 0)

            If clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(b).Cells("currency_id").Value, 0) = 1 Then
                amount_intercompany = Math.Round(clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(b).Cells("amount_intercompany").Value, 0), 0, MidpointRounding.AwayFromZero)
                amount_advance = Math.Round(clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(b).Cells("amount_advance").Value, 0), 0, MidpointRounding.AwayFromZero)
            Else
                amount_intercompany = Math.Round(clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(b).Cells("amount_intercompany").Value, 0), 2, MidpointRounding.AwayFromZero)
                amount_advance = Math.Round(clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(b).Cells("amount_advance").Value, 0), 2, MidpointRounding.AwayFromZero)
            End If

            total_idr = Math.Round((((amount_advance * advancedetil_foreignrate) + (amount_intercompany * advancedetil_foreignrate) - (advancedetil_discount * advancedetil_foreignrate))), 0, MidpointRounding.AwayFromZero)
            'pph_amount = Math.Round((((amount_advance - advancedetil_discount) * (pph_persen / 100)) * advancedetil_foreignrate), 0, MidpointRounding.AwayFromZero)
            'ppn_amount = Math.Round((((amount_advance - advancedetil_discount) * (ppn_persen / 100)) * advancedetil_foreignrate), 0, MidpointRounding.AwayFromZero)

            Dim accum_advanceinter As Decimal
            accum_advanceinter = (amount_advance + amount_intercompany)

            pph_amount = Math.Round((((accum_advanceinter - advancedetil_discount) * (pph_persen / 100)) * advancedetil_foreignrate), 0, MidpointRounding.AwayFromZero)
            ppn_amount = Math.Round((((accum_advanceinter - advancedetil_discount) * (ppn_persen / 100)) * advancedetil_foreignrate), 0, MidpointRounding.AwayFromZero)

            amount_idrreal = Math.Round((amount_advance * advancedetil_foreignrate), 0, MidpointRounding.AwayFromZero)
            amount_subtotal = Math.Round((total_idr - pph_amount + ppn_amount), 0, MidpointRounding.AwayFromZero)

            total_foreign = Math.Round((((amount_advance) + (amount_intercompany)) - (advancedetil_discount)), 2, MidpointRounding.AwayFromZero)
            'pph_amountforeign = Math.Round((((amount_advance - advancedetil_discount) * (pph_persen / 100))), 2, MidpointRounding.AwayFromZero)
            'ppn_amountforeign = Math.Round((((amount_advance - advancedetil_discount) * (ppn_persen / 100))), 2, MidpointRounding.AwayFromZero)
            
            pph_amountforeign = Math.Round((((accum_advanceinter - advancedetil_discount) * (pph_persen / 100))), 2, MidpointRounding.AwayFromZero)
            ppn_amountforeign = Math.Round((((accum_advanceinter - advancedetil_discount) * (ppn_persen / 100))), 2, MidpointRounding.AwayFromZero)

            'If Me.DgvAdvanceItemDetil.Rows(b).Cells("currency_id").Value = 1 Then
            '    amount_subtotalforeign = Math.Round((total_foreign - pph_amountforeign + ppn_amountforeign), 0, MidpointRounding.AwayFromZero)
            'Else
            amount_subtotalforeign = Math.Round((total_foreign - pph_amountforeign + ppn_amountforeign), 2, MidpointRounding.AwayFromZero)
            'End If


            Me.DgvAdvanceItemDetil.Rows(b).Cells("pph_amount").Value = pph_amount
            Me.DgvAdvanceItemDetil.Rows(b).Cells("ppn_amount").Value = ppn_amount

            Me.DgvAdvanceItemDetil.Rows(b).Cells("amount_idrreal").Value = amount_idrreal
            Me.DgvAdvanceItemDetil.Rows(b).Cells("amount_subtotal").Value = amount_subtotal
            Me.DgvAdvanceItemDetil.Rows(b).Cells("amount_subtotalforeign").Value = amount_subtotalforeign

            budget_id = clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(b).Cells("budget_id").Value, 0)
            budgetdetil_id = clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(b).Cells("budgetdetil_id").Value, 0)

            Try

            Catch ex As Exception
                MsgBox("Test 4" & ex.Message)
            End Try

            Try

            Catch ex As Exception
                MsgBox("Test 5" & ex.Message)
            End Try

            amount_budget = clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(b).Cells("amount_budget").Value, 0)
            amount_approvebma = Math.Round(clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(b).Cells("amount_approvebma").Value, 0), 0, MidpointRounding.AwayFromZero)
            budget_accum = Math.Round(clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(b).Cells("budget_accum").Value, 0), 0, MidpointRounding.AwayFromZero)
            budget_accumRequest = Math.Round(clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(b).Cells("budget_accumRequest").Value, 0), 0, MidpointRounding.AwayFromZero)
            amount_bpj = Math.Round(clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(b).Cells("amount_bpj").Value, 0), 0, MidpointRounding.AwayFromZero)

            ''''baru tgl 26-08-2010
            outstanding_budget = Math.Round((amount_budget - (amount_idrreal - (advancedetil_discount * advancedetil_foreignrate)) - amount_approvebma - budget_accumRequest - amount_bpj + budget_accum), 0, MidpointRounding.AwayFromZero)


            If Me.bma_approve = 1 Then
                Me.DgvAdvanceItemDetil.Rows(b).Cells("outstanding_budget").Value = Me.DgvAdvanceItemDetil.Rows(b).Cells("outstanding_approved").Value 'Me.tbl_TrnAdvanceItemDetils.Rows(u).Item("outstanding_approved")
                Me.DgvAdvanceItemDetil.Rows(b).Cells("outstanding_approved").Value = Me.DgvAdvanceItemDetil.Rows(b).Cells("outstanding_approved").Value 'Me.tbl_TrnAdvanceItemDetils.Rows(u).Item("outstanding_approved")
            Else
                Me.DgvAdvanceItemDetil.Rows(b).Cells("outstanding_budget").Value = outstanding_budget
                Me.DgvAdvanceItemDetil.Rows(b).Cells("outstanding_approved").Value = outstanding_budget
            End If
        Next

    End Function

    Private Function uiTransaksiAdvanceRequest_OutstandingBudget2(ByVal b As Integer) As Boolean
        ''''Dim b As Integer
        Dim amount_budget As Decimal
        Dim amount_idrreal As Decimal
        Dim outstanding_budget, rate, budget_accum, amount_approvebma As Decimal
        Dim tbl_amount_st As New DataTable
        Dim budget_id, budgetdetil_id As Decimal
        Dim oDataFiller As New clsDataFiller(Me.DSN)
        Dim amount_advance, advancedetil_foreignrate, advancedetil_discount As Decimal
        Dim total_idr As Decimal
        Dim pph_persen, ppn_persen, pph_amount, ppn_amount As Decimal
        Dim amount_subtotal As Decimal
        Dim amount_intercompany As Decimal

        Dim total_foreign As Decimal
        Dim pph_amountforeign As Decimal
        Dim ppn_amountforeign As Decimal
        Dim amount_subtotalforeign As Decimal

        Dim budget_accumRequest As Decimal
        Dim amount_bpj As Decimal

        Me.DgvAdvanceItemDetil.EndEdit()

        ''''For b = 0 To Me.DgvAdvanceItemDetil.Rows.Count - 1

        rate = clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(b).Cells("advancedetil_foreignrate").Value, 0)

        advancedetil_foreignrate = clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(b).Cells("advancedetil_foreignrate").Value, 0)
        advancedetil_discount = Math.Round(clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(b).Cells("advancedetil_discount").Value, 0), 2, MidpointRounding.AwayFromZero)
        pph_persen = clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(b).Cells("pph_persen").Value, 0)
        ppn_persen = clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(b).Cells("ppn_persen").Value, 0)

        If clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(b).Cells("currency_id").Value, 0) = 1 Then
            amount_intercompany = Math.Round(clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(b).Cells("amount_intercompany").Value, 0), 0, MidpointRounding.AwayFromZero)
            amount_advance = Math.Round(clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(b).Cells("amount_advance").Value, 0), 0, MidpointRounding.AwayFromZero)
        Else
            amount_intercompany = Math.Round(clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(b).Cells("amount_intercompany").Value, 0), 2, MidpointRounding.AwayFromZero)
            amount_advance = Math.Round(clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(b).Cells("amount_advance").Value, 0), 2, MidpointRounding.AwayFromZero)
        End If

        total_idr = Math.Round((((amount_advance * advancedetil_foreignrate) + (amount_intercompany * advancedetil_foreignrate) - (advancedetil_discount * advancedetil_foreignrate))), 0, MidpointRounding.AwayFromZero)
        'pph_amount = Math.Round((((amount_advance - advancedetil_discount) * (pph_persen / 100)) * advancedetil_foreignrate), 0, MidpointRounding.AwayFromZero)
        'ppn_amount = Math.Round((((amount_advance - advancedetil_discount) * (ppn_persen / 100)) * advancedetil_foreignrate), 0, MidpointRounding.AwayFromZero)

        Dim accum_advanceinter As Decimal
        accum_advanceinter = (amount_advance + amount_intercompany)

        pph_amount = Math.Round((((accum_advanceinter - advancedetil_discount) * (pph_persen / 100)) * advancedetil_foreignrate), 0, MidpointRounding.AwayFromZero)
        ppn_amount = Math.Round((((accum_advanceinter - advancedetil_discount) * (ppn_persen / 100)) * advancedetil_foreignrate), 0, MidpointRounding.AwayFromZero)

        amount_idrreal = Math.Round((amount_advance * advancedetil_foreignrate), 0, MidpointRounding.AwayFromZero)
        amount_subtotal = Math.Round((total_idr - pph_amount + ppn_amount), 0, MidpointRounding.AwayFromZero)

        total_foreign = Math.Round((((amount_advance) + (amount_intercompany)) - (advancedetil_discount)), 2, MidpointRounding.AwayFromZero)
        'pph_amountforeign = Math.Round((((amount_advance - advancedetil_discount) * (pph_persen / 100))), 2, MidpointRounding.AwayFromZero)
        'ppn_amountforeign = Math.Round((((amount_advance - advancedetil_discount) * (ppn_persen / 100))), 2, MidpointRounding.AwayFromZero)

        pph_amountforeign = Math.Round((((accum_advanceinter - advancedetil_discount) * (pph_persen / 100))), 2, MidpointRounding.AwayFromZero)
        ppn_amountforeign = Math.Round((((accum_advanceinter - advancedetil_discount) * (ppn_persen / 100))), 2, MidpointRounding.AwayFromZero)

        'If Me.DgvAdvanceItemDetil.Rows(b).Cells("currency_id").Value = 1 Then
        '    amount_subtotalforeign = Math.Round((total_foreign - pph_amountforeign + ppn_amountforeign), 0, MidpointRounding.AwayFromZero)
        'Else
        amount_subtotalforeign = Math.Round((total_foreign - pph_amountforeign + ppn_amountforeign), 2, MidpointRounding.AwayFromZero)
        'End If

        Me.DgvAdvanceItemDetil.Rows(b).Cells("pph_amount").Value = pph_amount
        Me.DgvAdvanceItemDetil.Rows(b).Cells("ppn_amount").Value = ppn_amount

        Me.DgvAdvanceItemDetil.Rows(b).Cells("amount_idrreal").Value = amount_idrreal
        Me.DgvAdvanceItemDetil.Rows(b).Cells("amount_subtotal").Value = amount_subtotal
        Me.DgvAdvanceItemDetil.Rows(b).Cells("amount_subtotalforeign").Value = amount_subtotalforeign

        budget_id = clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(b).Cells("budget_id").Value, 0)
        budgetdetil_id = clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(b).Cells("budgetdetil_id").Value, 0)

        Try

        Catch ex As Exception
            MsgBox("Test 4" & ex.Message)
        End Try

        Try

        Catch ex As Exception
            MsgBox("Test 5" & ex.Message)
        End Try

        amount_budget = clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(b).Cells("amount_budget").Value, 0)
        amount_approvebma = Math.Round(clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(b).Cells("amount_approvebma").Value, 0), 0, MidpointRounding.AwayFromZero)
        budget_accum = Math.Round(clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(b).Cells("budget_accum").Value, 0), 0, MidpointRounding.AwayFromZero)
        budget_accumRequest = Math.Round(clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(b).Cells("budget_accumRequest").Value, 0), 0, MidpointRounding.AwayFromZero)
        amount_bpj = Math.Round(clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(b).Cells("amount_bpj").Value, 0), 0, MidpointRounding.AwayFromZero)

        ''''baru tgl 26-08-2010
        outstanding_budget = Math.Round((amount_budget - (amount_idrreal - (advancedetil_discount * advancedetil_foreignrate)) - amount_approvebma - budget_accumRequest - amount_bpj + budget_accum), 0, MidpointRounding.AwayFromZero)


        If Me.bma_approve = 1 Then
            Me.DgvAdvanceItemDetil.Rows(b).Cells("outstanding_budget").Value = Me.DgvAdvanceItemDetil.Rows(b).Cells("outstanding_approved").Value 'Me.tbl_TrnAdvanceItemDetils.Rows(u).Item("outstanding_approved")
            Me.DgvAdvanceItemDetil.Rows(b).Cells("outstanding_approved").Value = Me.DgvAdvanceItemDetil.Rows(b).Cells("outstanding_approved").Value 'Me.tbl_TrnAdvanceItemDetils.Rows(u).Item("outstanding_approved")
        Else
            Me.DgvAdvanceItemDetil.Rows(b).Cells("outstanding_budget").Value = outstanding_budget
            Me.DgvAdvanceItemDetil.Rows(b).Cells("outstanding_approved").Value = outstanding_budget
        End If
        ''''Next

    End Function

    Private Function uiTransaksiAdvanceRequest_OutstandingBudget_CellValueChanges() As Boolean
        Dim b As Integer
        Dim amount_budget As Decimal
        Dim amount_idrreal As Decimal
        Dim outstanding_budget, rate, budget_accum, amount_approvebma As Decimal
        Dim tbl_advance_bma As New DataTable
        Dim tbl_amount_st As New DataTable
        Dim budget_id, budgetdetil_id As Decimal
        Dim oDataFiller As New clsDataFiller(Me.DSN)

        Dim amount_advance, advancedetil_foreignrate, advancedetil_discount As Decimal
        Dim total_idr As Decimal
        Dim pph_persen, ppn_persen, pph_amount, ppn_amount As Decimal
        Dim amount_subtotal As Decimal
        Dim amount_intercompany As Decimal

        Dim total_foreign As Decimal
        Dim pph_amountforeign As Decimal
        Dim ppn_amountforeign As Decimal
        Dim amount_subtotalforeign As Decimal

        Dim budget_accumRequest As Decimal

        Me.DgvAdvanceItemDetil.EndEdit()

        For b = 0 To Me.DgvAdvanceItemDetil.Rows.Count - 1
            'Me.DgvItemBudgetDetil.Rows(b).Cells("outstanding_budget").Value = clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(b).Cells("amount_budget").Value, 0) - clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(b).Cells("amount_idrreal").Value, 0)
            amount_budget = clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(b).Cells("amount_budget").Value, 0)
            rate = Me.DgvAdvanceItemDetil.Rows(b).Cells("advancedetil_foreignrate").Value()

            'amount_idrreal = clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(b).Cells("amount_advance").Value, 0) * clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(b).Cells("advancedetil_foreignrate").Value, 0)

            amount_advance = Math.Round(clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(b).Cells("amount_advance").Value, 0), 2, MidpointRounding.AwayFromZero)
            advancedetil_foreignrate = clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(b).Cells("advancedetil_foreignrate").Value, 0)
            advancedetil_discount = Math.Round(clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(b).Cells("advancedetil_discount").Value, 0), 2, MidpointRounding.AwayFromZero)
            pph_persen = clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(b).Cells("pph_persen").Value, 0)
            ppn_persen = clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(b).Cells("ppn_persen").Value, 0)

            If clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(b).Cells("currency_id").Value, 0) = 1 Then
                amount_intercompany = Math.Round(clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(b).Cells("amount_intercompany").Value, 0), 0, MidpointRounding.AwayFromZero)
            Else
                amount_intercompany = Math.Round(clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(b).Cells("amount_intercompany").Value, 0), 2, MidpointRounding.AwayFromZero)
            End If

            total_idr = Math.Round((((amount_advance * advancedetil_foreignrate) + (amount_intercompany * advancedetil_foreignrate)) - (advancedetil_discount * advancedetil_foreignrate)), 0, MidpointRounding.AwayFromZero)
            ''''Math.Round(((Math.Round((amount_advance * advancedetil_foreignrate), 0) + Math.Round((amount_intercompany * advancedetil_foreignrate), 0)) - Math.Round((advancedetil_discount * advancedetil_foreignrate), 0)), 0, MidpointRounding.AwayFromZero)
            ''''Math.Round(((amount_advance * advancedetil_foreignrate) - (advancedetil_discount * advancedetil_foreignrate)), 2, MidpointRounding.AwayFromZero)
            'pph_amount = Math.Round((((amount_advance - advancedetil_discount) * (pph_persen / 100)) * advancedetil_foreignrate), 0, MidpointRounding.AwayFromZero)
            'ppn_amount = Math.Round((((amount_advance - advancedetil_discount) * (ppn_persen / 100)) * advancedetil_foreignrate), 0, MidpointRounding.AwayFromZero)

            Dim accum_advanceinter As Decimal
            accum_advanceinter = (amount_advance + amount_intercompany)

            pph_amount = Math.Round((((accum_advanceinter - advancedetil_discount) * (pph_persen / 100)) * advancedetil_foreignrate), 0, MidpointRounding.AwayFromZero)
            ppn_amount = Math.Round((((accum_advanceinter - advancedetil_discount) * (ppn_persen / 100)) * advancedetil_foreignrate), 0, MidpointRounding.AwayFromZero)

            amount_idrreal = Math.Round((amount_advance * advancedetil_foreignrate), 0, MidpointRounding.AwayFromZero)
            amount_subtotal = Math.Round((total_idr - pph_amount + ppn_amount), 0, MidpointRounding.AwayFromZero)

            total_foreign = Math.Round((((amount_advance) + (amount_intercompany)) - (advancedetil_discount)), 2, MidpointRounding.AwayFromZero)
            ''''Math.Round(((amount_advance * advancedetil_foreignrate) - (advancedetil_discount * advancedetil_foreignrate)), 2, MidpointRounding.AwayFromZero)

            'pph_amountforeign = Math.Round((((amount_advance - advancedetil_discount) * (pph_persen / 100))), 2, MidpointRounding.AwayFromZero)
            'ppn_amountforeign = Math.Round((((amount_advance - advancedetil_discount) * (ppn_persen / 100))), 2, MidpointRounding.AwayFromZero)

            pph_amountforeign = Math.Round((((accum_advanceinter - advancedetil_discount) * (pph_persen / 100))), 2, MidpointRounding.AwayFromZero)
            ppn_amountforeign = Math.Round((((accum_advanceinter - advancedetil_discount) * (ppn_persen / 100))), 2, MidpointRounding.AwayFromZero)

            ''''Math.Round((Math.Round(((amount_advance - advancedetil_discount) * (ppn_persen / 100)), 2, MidpointRounding.AwayFromZero)), 2, MidpointRounding.AwayFromZero)
            '(total_idr * (ppn_persen / 100))

            'If Me.DgvAdvanceItemDetil.Rows(b).Cells("currency_id").Value = 1 Then
            '    amount_subtotalforeign = Math.Round((total_foreign - pph_amountforeign + ppn_amountforeign), 0, MidpointRounding.AwayFromZero)
            'Else
            amount_subtotalforeign = Math.Round((total_foreign - pph_amountforeign + ppn_amountforeign), 2, MidpointRounding.AwayFromZero)
            'End If


            budget_id = clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(b).Cells("budget_id").Value, 0)
            budgetdetil_id = clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(b).Cells("budgetdetil_id").Value, 0)

            Me.DgvAdvanceItemDetil.Rows(b).Cells("pph_amount").Value = pph_amount
            Me.DgvAdvanceItemDetil.Rows(b).Cells("ppn_amount").Value = ppn_amount
            Me.DgvAdvanceItemDetil.Rows(b).Cells("amount_idrreal").Value = amount_idrreal
            Me.DgvAdvanceItemDetil.Rows(b).Cells("amount_subtotal").Value = amount_subtotal
            Me.DgvAdvanceItemDetil.Rows(b).Cells("amount_subtotalforeign").Value = amount_subtotalforeign

            Try
                amount_approvebma = clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(b).Cells("amount_approvebma").Value, 0)

            Catch ex As Exception
                MsgBox("Test 1" & ex.Message & vbCrLf & "uiTransaksiAdvanceRequest_OutstandingBudget_CellValueChanges")
            End Try

            Try
                budget_accum = clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(b).Cells("budget_accum").Value, 0)
                budget_accumRequest = clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(b).Cells("budget_accumRequest").Value, 0)
            Catch ex As Exception
                MsgBox("Test 2" & ex.Message & vbCrLf & "uiTransaksiAdvanceRequest_OutstandingBudget_CellValueChanges")
            End Try

            'outstanding_budget = amount_budget - amount_idrreal - amount_approvebma + budget_accum
            ''''outstanding_budget = amount_budget - (amount_idrreal - (advancedetil_discount * advancedetil_foreignrate)) - amount_approvebma + budget_accum 'amount_budget - amount_subtotal - amount_approvebma + budget_accum

            ''''baru tgl 26-08-2010
            outstanding_budget = Math.Round((amount_budget - (amount_idrreal - (advancedetil_discount * advancedetil_foreignrate)) - amount_approvebma - budget_accumRequest + budget_accum), 0, MidpointRounding.AwayFromZero)
            ''''amount_budget - (amount_idrreal - Math.Round((advancedetil_discount * advancedetil_foreignrate), 0)) - amount_approvebma - budget_accumRequest + budget_accum

            Me.DgvAdvanceItemDetil.Rows(b).Cells("outstanding_budget").Value = outstanding_budget
            Me.DgvAdvanceItemDetil.Rows(b).Cells("outstanding_approved").Value = outstanding_budget
        Next
    End Function

    Private Function uiTransaksiAdvanceRequest_OutstandingBudget_CellValueChanges2(ByVal row_index As Integer) As Boolean
        Dim amount_budget As Decimal
        Dim amount_idrreal As Decimal
        Dim outstanding_budget, rate, budget_accum, amount_approvebma As Decimal
        Dim tbl_advance_bma As New DataTable
        Dim tbl_amount_st As New DataTable
        Dim budget_id, budgetdetil_id As Decimal
        Dim oDataFiller As New clsDataFiller(Me.DSN)

        Dim amount_advance, advancedetil_foreignrate, advancedetil_discount As Decimal
        Dim total_idr As Decimal
        Dim pph_persen, ppn_persen, pph_amount, ppn_amount As Decimal
        Dim amount_subtotal As Decimal
        Dim amount_intercompany As Decimal

        Dim total_foreign As Decimal
        Dim pph_amountforeign As Decimal
        Dim ppn_amountforeign As Decimal
        Dim amount_subtotalforeign As Decimal

        Dim budget_accumRequest As Decimal

        Me.DgvAdvanceItemDetil.EndEdit()

        'For b = 0 To Me.DgvAdvanceItemDetil.Rows.Count - 1
        'Me.DgvItemBudgetDetil.Rows(b).Cells("outstanding_budget").Value = clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(b).Cells("amount_budget").Value, 0) - clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(b).Cells("amount_idrreal").Value, 0)
        amount_budget = clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(row_index).Cells("amount_budget").Value, 0)
        rate = Me.DgvAdvanceItemDetil.Rows(row_index).Cells("advancedetil_foreignrate").Value()

        'amount_idrreal = clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(row_index).Cells("amount_advance").Value, 0) * clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(b).Cells("advancedetil_foreignrate").Value, 0)

        amount_advance = Math.Round(clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(row_index).Cells("amount_advance").Value, 0), 2, MidpointRounding.AwayFromZero)
        advancedetil_foreignrate = clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(row_index).Cells("advancedetil_foreignrate").Value, 0)
        advancedetil_discount = Math.Round(clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(row_index).Cells("advancedetil_discount").Value, 0), 2, MidpointRounding.AwayFromZero)
        pph_persen = clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(row_index).Cells("pph_persen").Value, 0)
        ppn_persen = clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(row_index).Cells("ppn_persen").Value, 0)

        If clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(row_index).Cells("currency_id").Value, 0) = 1 Then
            amount_intercompany = Math.Round(clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(row_index).Cells("amount_intercompany").Value, 0), 0, MidpointRounding.AwayFromZero)
        Else
            amount_intercompany = Math.Round(clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(row_index).Cells("amount_intercompany").Value, 0), 2, MidpointRounding.AwayFromZero)
        End If

        '' ''total_idr = Math.Round((((amount_advance * advancedetil_foreignrate) + (amount_intercompany * advancedetil_foreignrate)) - (advancedetil_discount * advancedetil_foreignrate)), 2, MidpointRounding.AwayFromZero) ''''Math.Round(((amount_advance * advancedetil_foreignrate) - (advancedetil_discount * advancedetil_foreignrate)), 2, MidpointRounding.AwayFromZero)
        total_idr = Math.Round((((amount_advance * advancedetil_foreignrate) + (amount_intercompany * advancedetil_foreignrate)) - (advancedetil_discount * advancedetil_foreignrate)), 0, MidpointRounding.AwayFromZero)
        ''''Math.Round(((Math.Round((amount_advance * advancedetil_foreignrate), 0) + Math.Round((amount_intercompany * advancedetil_foreignrate), 0)) - Math.Round((advancedetil_discount * advancedetil_foreignrate), 0)), 0, MidpointRounding.AwayFromZero)
        'pph_amount = Math.Round((((amount_advance - advancedetil_discount) * (pph_persen / 100)) * advancedetil_foreignrate), 0, MidpointRounding.AwayFromZero)
        'ppn_amount = Math.Round((((amount_advance - advancedetil_discount) * (ppn_persen / 100)) * advancedetil_foreignrate), 0, MidpointRounding.AwayFromZero)

        Dim accum_advanceinter As Decimal
        accum_advanceinter = (amount_advance + amount_intercompany)

        pph_amount = Math.Round((((accum_advanceinter - advancedetil_discount) * (pph_persen / 100)) * advancedetil_foreignrate), 0, MidpointRounding.AwayFromZero)
        ppn_amount = Math.Round((((accum_advanceinter - advancedetil_discount) * (ppn_persen / 100)) * advancedetil_foreignrate), 0, MidpointRounding.AwayFromZero)

        amount_idrreal = Math.Round((amount_advance * advancedetil_foreignrate), 0, MidpointRounding.AwayFromZero)
        amount_subtotal = Math.Round((total_idr - pph_amount + ppn_amount), 0, MidpointRounding.AwayFromZero)

        total_foreign = Math.Round((((amount_advance) + (amount_intercompany)) - (advancedetil_discount)), 2, MidpointRounding.AwayFromZero)
        'pph_amountforeign = Math.Round((((amount_advance - advancedetil_discount) * (pph_persen / 100))), 2, MidpointRounding.AwayFromZero)
        'ppn_amountforeign = Math.Round((((amount_advance - advancedetil_discount) * (ppn_persen / 100))), 2, MidpointRounding.AwayFromZero)

        pph_amountforeign = Math.Round((((accum_advanceinter - advancedetil_discount) * (pph_persen / 100))), 2, MidpointRounding.AwayFromZero)
        ppn_amountforeign = Math.Round((((accum_advanceinter - advancedetil_discount) * (ppn_persen / 100))), 2, MidpointRounding.AwayFromZero)

        'If Me.DgvAdvanceItemDetil.Rows(row_index).Cells("currency_id").Value = 1 Then
        '    amount_subtotalforeign = Math.Round((total_foreign - pph_amountforeign + ppn_amountforeign), 0, MidpointRounding.AwayFromZero)
        'Else
        amount_subtotalforeign = Math.Round((total_foreign - pph_amountforeign + ppn_amountforeign), 2, MidpointRounding.AwayFromZero)
        'End If

        budget_id = clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(row_index).Cells("budget_id").Value, 0)
        budgetdetil_id = clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(row_index).Cells("budgetdetil_id").Value, 0)

        Me.DgvAdvanceItemDetil.Rows(row_index).Cells("pph_amount").Value = pph_amount
        Me.DgvAdvanceItemDetil.Rows(row_index).Cells("ppn_amount").Value = ppn_amount

        'Me.DgvAdvanceItemDetil.Rows(row_index).Cells("amount_idrreal").Value = amount_idrreal
        Me.DgvAdvanceItemDetil.Rows(row_index).Cells("amount_idrreal").Value = amount_idrreal
        Me.DgvAdvanceItemDetil.Rows(row_index).Cells("amount_subtotal").Value = amount_subtotal
        Me.DgvAdvanceItemDetil.Rows(row_index).Cells("amount_subtotalforeign").Value = amount_subtotalforeign

        Try
            amount_approvebma = clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(row_index).Cells("amount_approvebma").Value, 0)

        Catch ex As Exception
            MsgBox("Test 1" & ex.Message & vbCrLf & "uiTransaksiAdvanceRequest_OutstandingBudget_CellValueChanges")
        End Try

        Try
            budget_accum = clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(row_index).Cells("budget_accum").Value, 0)
            budget_accumRequest = clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(row_index).Cells("budget_accumRequest").Value, 0)
        Catch ex As Exception
            MsgBox("Test 2" & ex.Message & vbCrLf & "uiTransaksiAdvanceRequest_OutstandingBudget_CellValueChanges")
        End Try

        'outstanding_budget = amount_budget - amount_idrreal - amount_approvebma + budget_accum
        ''''outstanding_budget = amount_budget - (amount_idrreal - (advancedetil_discount * advancedetil_foreignrate)) - amount_approvebma + budget_accum 'amount_budget - amount_subtotal - amount_approvebma + budget_accum

        '''' baru tgl 26-08-2010
        outstanding_budget = Math.Round((amount_budget - (amount_idrreal - (advancedetil_discount * advancedetil_foreignrate)) - amount_approvebma - budget_accumRequest + budget_accum), 0, MidpointRounding.AwayFromZero)
        ''''amount_budget - (amount_idrreal - Math.Round((advancedetil_discount * advancedetil_foreignrate), 0)) - amount_approvebma - budget_accumRequest + budget_accum 
        'amount_budget - amount_subtotal - amount_approvebma + budget_accum

        Me.DgvAdvanceItemDetil.Rows(row_index).Cells("outstanding_budget").Value = outstanding_budget
        Me.DgvAdvanceItemDetil.Rows(row_index).Cells("outstanding_approved").Value = outstanding_budget
        'Next
    End Function

    Private Function uiTransaksiAdvanceRequest_OutstandingBudget_CellValueChanges3(ByVal row_index As Integer) As Boolean
        Dim amount_budget As Decimal
        Dim amount_idrreal As Decimal
        Dim outstanding_budget, rate, budget_accum, amount_approvebma As Decimal
        Dim tbl_advance_bma As New DataTable
        Dim tbl_amount_st As New DataTable
        Dim budget_id, budgetdetil_id As Decimal
        Dim oDataFiller As New clsDataFiller(Me.DSN)

        Dim amount_advance, advancedetil_foreignrate, advancedetil_discount As Decimal
        Dim total_idr As Decimal
        Dim pph_persen, ppn_persen, pph_amount, ppn_amount As Decimal
        Dim amount_subtotal As Decimal
        Dim amount_intercompany As Decimal

        Dim total_foreign As Decimal
        Dim pph_amountforeign As Decimal
        Dim ppn_amountforeign As Decimal
        Dim amount_subtotalforeign As Decimal

        Dim budget_accumRequest As Decimal
        Dim amount_bpj As Decimal

        Me.DgvAdvanceItemDetil.EndEdit()

        rate = Me.DgvAdvanceItemDetil.Rows(row_index).Cells("advancedetil_foreignrate").Value()

        advancedetil_foreignrate = clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(row_index).Cells("advancedetil_foreignrate").Value, 0)
        advancedetil_discount = Math.Round(clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(row_index).Cells("advancedetil_discount").Value, 0), 2, MidpointRounding.AwayFromZero)
        pph_persen = clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(row_index).Cells("pph_persen").Value, 0)
        ppn_persen = clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(row_index).Cells("ppn_persen").Value, 0)

        If clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(row_index).Cells("currency_id").Value, 0) = 1 Then
            amount_intercompany = Math.Round(clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(row_index).Cells("amount_intercompany").Value, 0), 0, MidpointRounding.AwayFromZero)
            amount_advance = Math.Round(clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(row_index).Cells("amount_advance").Value, 0), 0, MidpointRounding.AwayFromZero)
        Else
            amount_intercompany = Math.Round(clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(row_index).Cells("amount_intercompany").Value, 0), 2, MidpointRounding.AwayFromZero)
            amount_advance = Math.Round(clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(row_index).Cells("amount_advance").Value, 0), 2, MidpointRounding.AwayFromZero)
        End If

        total_idr = Math.Round((((amount_advance * advancedetil_foreignrate) + (amount_intercompany * advancedetil_foreignrate)) - (advancedetil_discount * advancedetil_foreignrate)), 0, MidpointRounding.AwayFromZero)
        'pph_amount = Math.Round((((amount_advance - advancedetil_discount) * (pph_persen / 100)) * advancedetil_foreignrate), 0, MidpointRounding.AwayFromZero)
        'ppn_amount = Math.Round((((amount_advance - advancedetil_discount) * (ppn_persen / 100)) * advancedetil_foreignrate), 0, MidpointRounding.AwayFromZero)

        Dim accum_advanceinter As Decimal
        accum_advanceinter = (amount_advance + amount_intercompany)

        pph_amount = Math.Round((((accum_advanceinter - advancedetil_discount) * (pph_persen / 100)) * advancedetil_foreignrate), 0, MidpointRounding.AwayFromZero)
        ppn_amount = Math.Round((((accum_advanceinter - advancedetil_discount) * (ppn_persen / 100)) * advancedetil_foreignrate), 0, MidpointRounding.AwayFromZero)

        amount_idrreal = Math.Round((amount_advance * advancedetil_foreignrate), 0, MidpointRounding.AwayFromZero)
        amount_subtotal = Math.Round((total_idr - pph_amount + ppn_amount), 0, MidpointRounding.AwayFromZero)

        total_foreign = Math.Round((((amount_advance) + (amount_intercompany)) - (advancedetil_discount)), 2, MidpointRounding.AwayFromZero)
        'pph_amountforeign = Math.Round((((amount_advance - advancedetil_discount) * (pph_persen / 100))), 2, MidpointRounding.AwayFromZero)
        'ppn_amountforeign = Math.Round((((amount_advance - advancedetil_discount) * (ppn_persen / 100))), 2, MidpointRounding.AwayFromZero)

        pph_amountforeign = Math.Round((((accum_advanceinter - advancedetil_discount) * (pph_persen / 100))), 2, MidpointRounding.AwayFromZero)
        ppn_amountforeign = Math.Round((((accum_advanceinter - advancedetil_discount) * (ppn_persen / 100))), 2, MidpointRounding.AwayFromZero)

        'If Me.DgvAdvanceItemDetil.Rows(row_index).Cells("currency_id").Value = 1 Then
        '    amount_subtotalforeign = Math.Round((total_foreign - pph_amountforeign + ppn_amountforeign), 0, MidpointRounding.AwayFromZero)
        'Else
        amount_subtotalforeign = Math.Round((total_foreign - pph_amountforeign + ppn_amountforeign), 2, MidpointRounding.AwayFromZero)
        'End If

        budget_id = clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(row_index).Cells("budget_id").Value, 0)
        budgetdetil_id = clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(row_index).Cells("budgetdetil_id").Value, 0)

        Me.DgvAdvanceItemDetil.Rows(row_index).Cells("pph_amount").Value = pph_amount
        Me.DgvAdvanceItemDetil.Rows(row_index).Cells("ppn_amount").Value = ppn_amount

        Me.DgvAdvanceItemDetil.Rows(row_index).Cells("amount_idrreal").Value = amount_idrreal
        Me.DgvAdvanceItemDetil.Rows(row_index).Cells("amount_subtotal").Value = amount_subtotal
        Me.DgvAdvanceItemDetil.Rows(row_index).Cells("amount_subtotalforeign").Value = amount_subtotalforeign

        Try


        Catch ex As Exception
            MsgBox("Test 1" & ex.Message & vbCrLf & "uiTransaksiAdvanceRequest_OutstandingBudget_CellValueChanges")
        End Try

        Try
            amount_budget = clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(row_index).Cells("amount_budget").Value, 0)
            amount_approvebma = Math.Round(clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(row_index).Cells("amount_approvebma").Value, 0), 0, MidpointRounding.AwayFromZero)
            budget_accum = Math.Round(clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(row_index).Cells("budget_accum").Value, 0), 0, MidpointRounding.AwayFromZero)
            budget_accumRequest = Math.Round(clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(row_index).Cells("budget_accumRequest").Value, 0), 0, MidpointRounding.AwayFromZero)
            amount_bpj = Math.Round(clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(row_index).Cells("amount_bpj").Value, 0), 0, MidpointRounding.AwayFromZero)
        Catch ex As Exception
            MsgBox("Test 2" & ex.Message & vbCrLf & "uiTransaksiAdvanceRequest_OutstandingBudget_CellValueChanges")
        End Try

        '''' baru tgl 26-08-2010
        outstanding_budget = Math.Round((amount_budget - (amount_idrreal - (advancedetil_discount * advancedetil_foreignrate)) - amount_approvebma - budget_accumRequest - amount_bpj + budget_accum), 0, MidpointRounding.AwayFromZero)

        Me.DgvAdvanceItemDetil.Rows(row_index).Cells("outstanding_budget").Value = outstanding_budget
        Me.DgvAdvanceItemDetil.Rows(row_index).Cells("outstanding_approved").Value = outstanding_budget

    End Function

    Private Sub CopyItemToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyItemToolStripMenuItem.Click
        copy_induk_child()
    End Sub

    Private Sub copy_induk_child()
        Dim tbl_TrnAdvanceItemDetil_temps As DataTable = New DataTable
        Dim criteria As String = String.Empty
        Dim row_Array() As DataRow
        Dim row_temps As DataRow
        Dim rowIndex, colIndex As Integer
        Dim columnName As String
        Dim oDataFiller As clsDataFiller = New clsDataFiller(Me.DSN)

        'Untuk ngecek ini data dari tabel atau dataset
        Dim criterias As String = String.Empty
        Dim tabel_temps As New DataTable
        'Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Try
            tabel_temps.Clear()
            oDataFiller.DataFill(tabel_temps, "vq_TrnAdvanceItemDetil_Selects", String.Format("b.advance_id = '{0}' AND a.budgetdetil_line = {1} ", advance_id, Me.DgvAdvanceItemDetil.Rows(Me.DgvAdvanceItemDetil.CurrentRow.Index).Cells("budgetdetil_line").Value))
        Catch ex As Exception
        End Try

        Dim tbl_temporaryInduk As DataTable = New DataTable
        Dim tbl_temporaryChild As DataTable = New DataTable

        tbl_TrnAdvanceItemDetil_temps.Clear()
        tbl_TrnAdvanceItemDetil_temps = Me.tbl_TrnAdvanceItemDetils.GetChanges()

        tbl_temporaryInduk.Clear()
        If tabel_temps.Rows.Count > 0 Then
            tbl_temporaryInduk = tbl_TrnAdvanceItemDetils
        ElseIf tbl_TrnAdvanceItemDetil_temps IsNot Nothing Then
            tbl_temporaryInduk = tbl_TrnAdvanceItemDetil_temps
        Else
            Exit Sub
        End If

        'Buat masukkin data Mother(induk na)
        If tbl_temporaryInduk.Rows.Count > 0 Then
            criteria = String.Format("budgetdetil_line = {0}", Me.DgvAdvanceItemDetil.Rows(Me.DgvAdvanceItemDetil.CurrentRow.Index).Cells("budgetdetil_line").Value)
            row_Array = tbl_temporaryInduk.Select(criteria)

            motherTbl.Clear()
            For rowIndex = 0 To row_Array.Length - 1
                row_temps = motherTbl.NewRow
                For colIndex = 0 To tbl_temporaryInduk.Columns.Count - 1
                    Try
                        columnName = tbl_temporaryInduk.Columns(colIndex).ColumnName
                        If columnName = "budgetdetil_line" Then
                            If Me.tbl_TrnAdvanceItemDetils.Rows(Me.tbl_TrnAdvanceItemDetils.Rows.Count - 1).RowState = DataRowState.Deleted Then
                                row_temps(columnName) = Me.tbl_TrnAdvanceItemDetils.Rows(Me.tbl_TrnAdvanceItemDetils.Rows.Count - 2).Item("budgetdetil_line") + 20
                            Else
                                row_temps(columnName) = Me.tbl_TrnAdvanceItemDetils.Rows(Me.tbl_TrnAdvanceItemDetils.Rows.Count - 1).Item("budgetdetil_line") + 10
                            End If
                        ElseIf columnName = "budgetdetil_eps" Then
                            row_temps(columnName) = ""
                        Else
                            row_temps(columnName) = row_Array(rowIndex).Item(colIndex)
                        End If
                    Catch ex As Exception
                    End Try
                Next
                motherTbl.Rows.Add(row_temps)
            Next
            Me.tbl_TrnAdvanceItemDetils.Merge(motherTbl, False)
        End If
    End Sub

    Private Sub DgvAdvanceItemDetil_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim click As DataGridView.HitTestInfo = Me.DgvAdvanceItemDetil.HitTest(e.X, e.Y)
            If click.Type = Windows.Forms.DataGrid.HitTestType.Cell Then
                Me.DgvAdvanceItemDetil.CurrentCell = Me.DgvAdvanceItemDetil.Rows(click.RowIndex).Cells(click.ColumnIndex)
            End If
        End If
    End Sub

    Private Sub generate_eps(ByVal line As Integer, ByVal eps_check As Integer)
        Dim i, a As Integer
        Dim rowFilter As String
        Dim rows() As DataRow
        Dim newrow As DataRow
        Dim myeps As Integer = Me.advance_epsstart
        Dim budget_line As Integer = 0

        Me.tbl_Advancedetileps.Columns("advancedetil_line").DefaultValue = advancedetil_line
        Me.tbl_Advancedetileps.Columns("budgetdetil_line").DefaultValue = line
        ''''Me.tbl_Advancedetileps.Columns("budgetdetiluse_line").DefaultValue = DBNull.Value
        ''''Me.tbl_Advancedetileps.Columns("budgetdetiluse_line").AutoIncrement = True
        ''''Me.tbl_Advancedetileps.Columns("budgetdetiluse_line").AutoIncrementSeed = 10
        ''''Me.tbl_Advancedetileps.Columns("budgetdetiluse_line").AutoIncrementStep = 10

        'cek apakah tanggal ini di line ybs sudah ada
        For a = Me.advance_epsstart To Me.advance_epsend
            rowFilter = String.Format("budgetdetil_line={0} and budgetdetil_eps='{1}'", line, a)
            rows = Me.tbl_Advancedetileps.Select(rowFilter)
            If rows.Length = 0 Then
                newrow = Me.tbl_Advancedetileps.NewRow()
                If eps_check = a Then
                    newrow("checked") = 1
                    newrow("budgetdetil_eps") = a 'myeps
                    newrow("budget_name") = Me.budget_view
                    newrow("budgetdetiluse_line") = (budget_line + 1) * 10
                End If
                Me.tbl_Advancedetileps.Rows.Add(newrow)
                budget_line += 1
                ''''Else
                ''''    Exit For
            End If
        Next
        'End While

        'potong tanggal sebelum Me.obj_Order_usagedatestart.Value
        rowFilter = String.Format("budgetdetil_line={0} and budgetdetil_eps<'{1}'", line, Me.advance_epsstart)
        rows = Me.tbl_Advancedetileps.Select(rowFilter)
        For i = 0 To rows.Length - 1
            Me.tbl_Advancedetileps.Rows.Remove(rows(i))
        Next

        'potong tanggal setelah Me.obj_Order_usagedateend.Value
        rowFilter = String.Format("budgetdetil_line={0} and budgetdetil_eps>'{1}'", line, Me.advance_epsend)
        rows = Me.tbl_Advancedetileps.Select(rowFilter)
        For i = 0 To rows.Length - 1
            Me.tbl_Advancedetileps.Rows.Remove(rows(i))
        Next
    End Sub

    Private Sub generate_eps2(ByVal line As Integer, ByVal eps_check As Integer)
        Dim i, a As Integer
        Dim rowFilter As String
        Dim rows() As DataRow
        Dim newrow As DataRow
        Dim myeps As Integer = Me.advance_epsstart
        Dim budget_line As Integer = 0

        Me.tbl_trnAdvancedetileps_temp.Columns("advancedetil_line").DefaultValue = advancedetil_line
        Me.tbl_trnAdvancedetileps_temp.Columns("budgetdetil_line").DefaultValue = line
        
        'cek apakah tanggal ini di line ybs sudah ada
        For a = Me.advance_epsstart To Me.advance_epsend
            rowFilter = String.Format("budgetdetil_line={0} and budgetdetil_eps='{1}'", line, a)
            rows = Me.tbl_trnAdvancedetileps_temp.Select(rowFilter)
            If rows.Length = 0 Then
                newrow = Me.tbl_trnAdvancedetileps_temp.NewRow()
                If eps_check = a Then
                    newrow("checked") = 1
                    newrow("budgetdetil_eps") = a 'myeps
                    newrow("budget_name") = Me.budget_view
                    newrow("budgetdetiluse_line") = (budget_line + 1) * 10
                End If
                Me.tbl_trnAdvancedetileps_temp.Rows.Add(newrow)
                budget_line += 1
                ''''Else
                ''''    Exit For
            End If
        Next
        'End While

        'potong tanggal sebelum Me.obj_Order_usagedatestart.Value
        rowFilter = String.Format("budgetdetil_line={0} and budgetdetil_eps<'{1}'", line, Me.advance_epsstart)
        rows = Me.tbl_trnAdvancedetileps_temp.Select(rowFilter)
        For i = 0 To rows.Length - 1
            Me.tbl_trnAdvancedetileps_temp.Rows.Remove(rows(i))
        Next

        'potong tanggal setelah Me.obj_Order_usagedateend.Value
        rowFilter = String.Format("budgetdetil_line={0} and budgetdetil_eps>'{1}'", line, Me.advance_epsend)
        rows = Me.tbl_trnAdvancedetileps_temp.Select(rowFilter)
        For i = 0 To rows.Length - 1
            Me.tbl_trnAdvancedetileps_temp.Rows.Remove(rows(i))
        Next
    End Sub

    Private Sub HitungTotalAmount()
        Dim g As Integer
        Dim amount_idrreal As Decimal
        Dim amount_subtotal As Decimal

        If Me.DgvAdvanceItemDetil.Rows.Count > 0 Then
            For g = 0 To Me.DgvAdvanceItemDetil.Rows.Count - 1
                amount_idrreal += clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(g).Cells("amount_idrreal").Value, 0)
                amount_subtotal += clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(g).Cells("amount_subtotal").Value, 0)
            Next

            'Me.obj_total_amount.Text = Format(amount_idrreal, "#,##0.00")
            Me.obj_total_amount.Text = Format(amount_subtotal, "#,##0.00")
        Else
            amount_idrreal = 0
            amount_subtotal = 0
            'Me.obj_total_amount.Text = Format(amount_idrreal, "#,##0.00")
            Me.obj_total_amount.Text = Format(amount_subtotal, "#,##0.00")

        End If

    End Sub

    Private Sub btn_unbudget_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_unbudget.Click
        Dim l As Integer
        Dim line As Integer
        Dim budget_id, budgetdetil_id As Integer
        Dim tbl_currency As DataTable
        Dim tbl_exrate As DataTable
        Dim oDataFiller As New clsDataFiller(Me.DSN)
        Dim tbl_advance_bma As New DataTable
        Dim amount_advance, advancedetil_foreignrate As Decimal
        Dim total_idr, advancedetil_discount As Decimal
        Dim pph_persen, ppn_persen, pph_amount, ppn_amount As Decimal
        Dim amount_intercompany As Decimal

        Dim total_foreign As Decimal
        Dim pph_amountforeign As Decimal
        Dim ppn_amountforeign As Decimal
        Dim amount_subtotalforeign As Decimal

        Dim tbl_budget_accumRequest As New DataTable

        Try
            If Me.budget_code <> 0 Then
                budget_id = Me.budget_code
                budgetdetil_id = 0 'clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("budgetdetil_id").Value, 0)

                Me.Cursor = Cursors.WaitCursor

                Me.tbl_TrnAdvanceItemDetils.Rows.Add()
                If tbl_TrnAdvanceItemDetils.Rows.Count > 1 Then
                    If Me.tbl_TrnAdvanceItemDetils.Rows(Me.tbl_TrnAdvanceItemDetils.Rows.Count - 2).RowState <> DataRowState.Deleted Then
                        Me.tbl_TrnAdvanceItemDetils.Rows(Me.tbl_TrnAdvanceItemDetils.Rows.Count - 1).Item("budgetdetil_line") = Me.tbl_TrnAdvanceItemDetils.Rows(Me.tbl_TrnAdvanceItemDetils.Rows.Count - 2).Item("budgetdetil_line") + 10
                    Else
                        Me.tbl_TrnAdvanceItemDetils.Rows(Me.tbl_TrnAdvanceItemDetils.Rows.Count - 1).Item("budgetdetil_line") = Me.tbl_TrnAdvanceItemDetils.Rows(Me.tbl_TrnAdvanceItemDetils.Rows.Count - 1).Item("budgetdetil_line") '+ 10
                    End If
                Else
                    Me.tbl_TrnAdvanceItemDetils.Rows(Me.tbl_TrnAdvanceItemDetils.Rows.Count - 1).Item("budgetdetil_line") = Me.tbl_TrnAdvanceItemDetils.Rows(Me.tbl_TrnAdvanceItemDetils.Rows.Count - 1).Item("budgetdetil_line")
                End If
                line = Me.tbl_TrnAdvanceItemDetils.Rows(Me.tbl_TrnAdvanceItemDetils.Rows.Count - 1).Item("budgetdetil_line")

                If Me.tbl_TrnAdvanceItemDetils.Rows.Count > 0 Then
                    For l = 0 To Me.tbl_TrnAdvanceItemDetils.Rows.Count - 1
                        If Me.tbl_TrnAdvanceItemDetils.Rows(l).RowState <> DataRowState.Deleted Then
                            If Me.tbl_TrnAdvanceItemDetils.Rows(l).Item("budgetdetil_line") = line Then

                                Me.tbl_TrnAdvanceItemDetils.Rows(l).Item("advancedetil_line") = detilLine
                                Me.tbl_TrnAdvanceItemDetils.Rows(l).Item("budgetdetil_id") = budgetdetil_id
                                Me.tbl_TrnAdvanceItemDetils.Rows(l).Item("budgetdetil_name") = "not define"
                                Me.tbl_TrnAdvanceItemDetils.Rows(l).Item("amount_budget") = 0
                                Me.tbl_TrnAdvanceItemDetils.Rows(l).Item("amount_advance") = 0
                                Me.tbl_TrnAdvanceItemDetils.Rows(l).Item("acc_id") = ""
                                Me.tbl_TrnAdvanceItemDetils.Rows(l).Item("currency_id") = Me.advance_currency
                                Me.tbl_TrnAdvanceItemDetils.Rows(l).Item("budget_name") = Me.budget_view
                                Me.tbl_TrnAdvanceItemDetils.Rows(l).Item("budget_id") = Me.budget_code
                                Me.tbl_TrnAdvanceItemDetils.Rows(l).Item("strukturunit_id") = Me.user_strukturunit
                                Me.tbl_TrnAdvanceItemDetils.Rows(l).Item("channel_id") = Me.channel
                                Me.tbl_TrnAdvanceItemDetils.Rows(l).Item("advance_id") = ""
                                Me.tbl_TrnAdvanceItemDetils.Rows(l).Item("account") = String.Empty

                                Try
                                    Me.tbl_TrnAdvanceItemDetils.Rows(l).Item("budgetdetil_eps") = ""
                                Catch ex As Exception
                                End Try

                                Try
                                    tbl_advance_bma.Clear()

                                    oDataFiller.DataFillAmountAdvance(tbl_advance_bma, "vq_TrnAdvanceItemDetil_AppBma", budget_id, Me.tbl_TrnAdvanceItemDetils.Rows(l).Item("budgetdetil_id"))
                                    If tbl_advance_bma.Rows.Count > 0 Then
                                        Me.tbl_TrnAdvanceItemDetils.Rows(l).Item("amount_approvebma") = clsUtil.IsDbNull(tbl_advance_bma.Rows(0)("amount_bma_approved"), 0)
                                    Else
                                        Me.tbl_TrnAdvanceItemDetils.Rows(l).Item("amount_approvebma") = clsUtil.IsDbNull(tbl_advance_bma.Columns("amount_bma_approved").DefaultValue, 0)
                                    End If
                                Catch ex As Exception
                                    MsgBox("Test 4" & ex.Message)
                                End Try


                                Try
                                    tbl_budget_accumRequest.Clear()

                                    oDataFiller.DataFillAmountAdvance(tbl_budget_accumRequest, "vq_f_TrnOrderdetil_AmountSummmary", budget_id, Me.tbl_TrnAdvanceItemDetils.Rows(l).Item("budgetdetil_id"))
                                    If tbl_budget_accumRequest.Rows.Count > 0 Then
                                        Me.tbl_TrnAdvanceItemDetils.Rows(l).Item("budget_accumRequest") = clsUtil.IsDbNull(tbl_budget_accumRequest.Rows(0)("budget_accumRequest"), 0)
                                    Else
                                        Me.tbl_TrnAdvanceItemDetils.Rows(l).Item("budget_accumRequest") = clsUtil.IsDbNull(tbl_budget_accumRequest.Columns("budget_accumRequest").DefaultValue, 0)
                                    End If
                                Catch ex As Exception
                                    MsgBox("Test 6" & ex.Message)
                                End Try

                                Try
                                    tbl_currency = New DataTable
                                    oDataFiller.DataFill(tbl_currency, "ms_MstCurrency_Select", String.Format("currency_id = {0}", Me.advance_currency))

                                    tbl_exrate = New DataTable
                                    If Me.advance_currency <> 0 Then
                                        oDataFiller.DataFill(tbl_exrate, "pr_MstXRate_Select", String.Format("exrate_currency = '{0}'", tbl_currency.Rows(0).Item("currency_shortname")))
                                    End If
                                    Try
                                        If tbl_exrate.Rows.Count > 0 Then
                                            Me.tbl_TrnAdvanceItemDetils.Rows(l).Item("advancedetil_foreignrate") = tbl_exrate.Rows(0)("exrate_mid")
                                        Else
                                            Me.tbl_TrnAdvanceItemDetils.Rows(l).Item("advancedetil_foreignrate") = 0
                                        End If
                                    Catch ex As Exception
                                    End Try
                                Catch ex As Exception

                                End Try

                                amount_advance = clsUtil.IsDbNull(Me.tbl_TrnAdvanceItemDetils.Rows(l).Item("amount_advance"), 0)
                                advancedetil_foreignrate = clsUtil.IsDbNull(Me.tbl_TrnAdvanceItemDetils.Rows(l).Item("advancedetil_foreignrate"), 0)
                                advancedetil_discount = clsUtil.IsDbNull(Me.tbl_TrnAdvanceItemDetils.Rows(l).Item("advancedetil_discount"), 0)
                                pph_persen = clsUtil.IsDbNull(Me.tbl_TrnAdvanceItemDetils.Rows(l).Item("pph_persen"), 0)
                                ppn_persen = clsUtil.IsDbNull(Me.tbl_TrnAdvanceItemDetils.Rows(l).Item("ppn_persen"), 0)
                                amount_intercompany = clsUtil.IsDbNull(Me.tbl_TrnAdvanceItemDetils.Rows(l).Item("amount_intercompany"), 0)

                                total_idr = Math.Round((((amount_advance * advancedetil_foreignrate) + (amount_intercompany * advancedetil_foreignrate)) - (advancedetil_discount * advancedetil_foreignrate)), 2, MidpointRounding.AwayFromZero) ''''Math.Round(((amount_advance * advancedetil_foreignrate) - (advancedetil_discount * advancedetil_foreignrate)), 2, MidpointRounding.AwayFromZero)
                                'pph_amount = Math.Round((Math.Round(((amount_advance - advancedetil_discount) * (pph_persen / 100)), 2, MidpointRounding.AwayFromZero) * advancedetil_foreignrate), 2, MidpointRounding.AwayFromZero) '(total_idr * (pph_persen / 100))
                                'ppn_amount = Math.Round((Math.Round(((amount_advance - advancedetil_discount) * (ppn_persen / 100)), 2, MidpointRounding.AwayFromZero) * advancedetil_foreignrate), 2, MidpointRounding.AwayFromZero) '(total_idr * (ppn_persen / 100))

                                Dim accum_advanceinter As Decimal
                                accum_advanceinter = (amount_advance + amount_intercompany)

                                pph_amount = Math.Round((Math.Round(((accum_advanceinter - advancedetil_discount) * (pph_persen / 100)), 2, MidpointRounding.AwayFromZero) * advancedetil_foreignrate), 2, MidpointRounding.AwayFromZero) '(total_idr * (pph_persen / 100))
                                ppn_amount = Math.Round((Math.Round(((accum_advanceinter - advancedetil_discount) * (ppn_persen / 100)), 2, MidpointRounding.AwayFromZero) * advancedetil_foreignrate), 2, MidpointRounding.AwayFromZero) '(total_idr * (ppn_persen / 100))

                                'Me.tbl_TrnAdvanceItemDetils.Rows(l).Item("amount_idrreal") = clsUtil.IsDbNull(Me.tbl_TrnAdvanceItemDetils.Rows(l).Item("amount_advance"), 0) * clsUtil.IsDbNull(Me.tbl_TrnAdvanceItemDetils.Rows(l).Item("advancedetil_foreignrate"), 0)
                                Me.tbl_TrnAdvanceItemDetils.Rows(l).Item("amount_idrreal") = Math.Round((amount_advance * advancedetil_foreignrate), 2, MidpointRounding.AwayFromZero)
                                Me.tbl_TrnAdvanceItemDetils.Rows(l).Item("amount_subtotal") = Math.Round((total_idr - pph_amount + ppn_amount), 2, MidpointRounding.AwayFromZero)


                                total_foreign = Math.Round((((amount_advance) + (amount_intercompany)) - (advancedetil_discount)), 2, MidpointRounding.AwayFromZero)
                                'pph_amountforeign = Math.Round((Math.Round(((amount_advance - advancedetil_discount) * (pph_persen / 100)), 2, MidpointRounding.AwayFromZero)), 2, MidpointRounding.AwayFromZero) '(total_idr * (pph_persen / 100))
                                'ppn_amountforeign = Math.Round((Math.Round(((amount_advance - advancedetil_discount) * (ppn_persen / 100)), 2, MidpointRounding.AwayFromZero)), 2, MidpointRounding.AwayFromZero) '(total_idr * (ppn_persen / 100))

                                pph_amountforeign = Math.Round((Math.Round(((accum_advanceinter - advancedetil_discount) * (pph_persen / 100)), 2, MidpointRounding.AwayFromZero)), 2, MidpointRounding.AwayFromZero) '(total_idr * (pph_persen / 100))
                                ppn_amountforeign = Math.Round((Math.Round(((accum_advanceinter - advancedetil_discount) * (ppn_persen / 100)), 2, MidpointRounding.AwayFromZero)), 2, MidpointRounding.AwayFromZero) '(total_idr * (ppn_persen / 100))

                                'If Me.tbl_TrnAdvanceItemDetils.Rows(l).Item("currency_id") = 1 Then
                                '    amount_subtotalforeign = Math.Round((total_foreign - pph_amountforeign + ppn_amountforeign), 0, MidpointRounding.AwayFromZero)
                                'Else
                                amount_subtotalforeign = Math.Round((total_foreign - pph_amountforeign + ppn_amountforeign), 2, MidpointRounding.AwayFromZero)
                                'End If

                                Me.tbl_TrnAdvanceItemDetils.Rows(l).Item("amount_subtotalforeign") = amount_subtotalforeign


                            End If
                        End If
                    Next
                End If

            Else
                Dim ErrorMessage As String = ""
                Dim ErrorFound As Boolean = False


            End If
        Catch ex As Exception
        End Try

        Dim a As Integer
        Dim amount As Decimal
        Dim amount_foreignreal As Decimal

        For a = 0 To Me.DgvAdvanceItemDetil.Rows.Count - 1
            'amount += clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(a).Cells("amount_idrreal").Value, 0)
            amount += Math.Round(clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(a).Cells("amount_subtotal").Value, 0), 0, MidpointRounding.AwayFromZero)
            amount_foreignreal += Math.Round(clsUtil.IsDbNull(Me.DgvAdvanceItemDetil.Rows(a).Cells("amount_advance").Value, 0), 2, MidpointRounding.AwayFromZero)
        Next

        Me.obj_total_amount.Text = Format(amount, "#,##0.00")

        uiTransaksiAdvanceRequest_OutstandingBudget()

        Me.Cursor = Cursors.Arrow
    End Sub
End Class
