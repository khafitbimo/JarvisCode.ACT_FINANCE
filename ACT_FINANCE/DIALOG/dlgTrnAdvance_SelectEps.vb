Public Class dlgTrnAdvance_SelectEps
    Dim CloseButtonIsPressed As Boolean
    Dim retObj As dlgTrnSelectItemChild.SelectEpsDialogReturn = New dlgTrnSelectItemChild.SelectEpsDialogReturn()
    '''Dim retObj As uiAdvanceRequest.SelectEpsDialogReturn = New uiAdvanceRequest.SelectEpsDialogReturn()

    Private tbl_trnAdvancedetileps As DataTable = clsDataset.CreateTblTrnAdvanceItemDetilEps
    Private type_id As String
    Private advancedetil_line As Integer

#Region " UI and Layout "

    Private Function FormatDgvTrnOrderdetiluse(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean

        Dim cAdvance_id As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAdvancedetil_line As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBudgetdetil_line As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cChecked As New System.Windows.Forms.DataGridViewCheckBoxColumn
        Dim cBudgetdetil_eps As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBudget_name As New System.Windows.Forms.DataGridViewTextBoxColumn

        cAdvance_id.Name = "advance_id"
        cAdvance_id.HeaderText = "advance_id"
        cAdvance_id.DataPropertyName = "advance_id"
        cAdvance_id.Width = 100
        cAdvance_id.Visible = False
        cAdvance_id.ReadOnly = True

        cBudgetdetil_line.Name = "budgetdetil_line"
        cBudgetdetil_line.HeaderText = "Line"
        cBudgetdetil_line.DataPropertyName = "budgetdetil_line"
        cBudgetdetil_line.Width = 100
        cBudgetdetil_line.Visible = True
        cBudgetdetil_line.ReadOnly = True

        cAdvancedetil_line.Name = "advancedetil_line"
        cAdvancedetil_line.HeaderText = "Line"
        cAdvancedetil_line.DataPropertyName = "advancedetil_line"
        cAdvancedetil_line.Width = 30
        cAdvancedetil_line.Visible = False
        cAdvancedetil_line.ReadOnly = True

        cChecked.Name = "checked"
        cChecked.HeaderText = "Select"
        cChecked.DataPropertyName = "checked"
        cChecked.Width = 60
        cChecked.Visible = True
        cChecked.ReadOnly = False

        cBudgetdetil_eps.Name = "budgetdetil_eps"
        cBudgetdetil_eps.HeaderText = "Eps."
        cBudgetdetil_eps.DataPropertyName = "budgetdetil_eps"
        cBudgetdetil_eps.Width = 100
        cBudgetdetil_eps.Visible = True
        cBudgetdetil_eps.ReadOnly = True

        cBudget_name.Name = "budget_name"
        cBudget_name.HeaderText = "Description"
        cBudget_name.DataPropertyName = "budget_name"
        cBudget_name.Width = 100
        cBudget_name.Visible = True
        cBudget_name.ReadOnly = True

        objDgv.AllowUserToAddRows = False
        objDgv.AllowUserToDeleteRows = False
        objDgv.AutoGenerateColumns = False
        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
        { _
            cAdvance_id, _
            cChecked, _
            cBudgetdetil_line, _
            cAdvancedetil_line, _
            cBudgetdetil_eps, _
            cBudget_name})
    End Function

#End Region

#Region " Opener "

    Public Shadows Function OpenDialog(ByRef tblAdvancedetileps As DataTable, _
    ByRef eps_start As Integer, ByRef eps_end As Integer, _
    ByRef budgetdetil_line As Integer, ByRef budget_name As String, ByRef advancedetil_line As Integer, _
    ByVal owner As System.Windows.Forms.IWin32Window) As Object

        Me.tbl_trnAdvancedetileps.Merge(tblAdvancedetileps, True)

        Me.retObj.budget_name = budget_name
        Me.retObj.budgetdetil_line = budgetdetil_line
        Me.retObj.epsstart = eps_start
        Me.retObj.epsend = eps_end
        Me.retObj.advancedetil_line = advancedetil_line

        MyBase.ShowDialog(owner)

        If Me.CloseButtonIsPressed Then
            tblAdvancedetileps = Me.tbl_trnAdvancedetileps
            Return retObj
        Else
            Return Nothing
        End If
    End Function

#End Region

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click, btnCancel.Click
        Dim obj As Button = sender

        If obj.Name = "btnOK" Then
            Me.CloseButtonIsPressed = True

            Dim eps As Decimal = 0
            Dim rowFilter As String
            Dim rows() As DataRow
            Dim j As Integer
            If Me.tbl_trnAdvancedetileps IsNot Nothing Then
                rowFilter = String.Format("budgetdetil_line={0}", Me.retObj.budgetdetil_line)
                rows = Me.tbl_trnAdvancedetileps.Select(rowFilter)
                For j = 0 To rows.Length - 1
                    If clsUtil.IsDbNull(rows(j).Item("checked"), 0) Then
                        eps = rows(j).Item("budgetdetil_eps")
                    End If
                Next
            End If

            Me.retObj.budgetdetil_eps = eps

        Else
            Me.CloseButtonIsPressed = False
        End If

        Me.Close()

    End Sub

    Private Sub dlgTrnAdvance_SelectEps_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        clsUtil.SetLocalization()

        Me.obj_Advancedetil_line.DataBindings.Clear()
        Me.obj_Budget_name.Clear()

        Me.obj_Advancedetil_line.DataBindings.Add(New Binding("Text", Me.retObj, "budgetdetil_line"))
        Me.obj_Budget_name.DataBindings.Add(New Binding("Text", Me.retObj, "budget_name"))
        Me.obj_eps_start.DataBindings.Add(New Binding("Text", Me.retObj, "epsstart")) ', True, DataSourceUpdateMode.OnPropertyChanged, Now(), "dd/MM/yyyy"))
        Me.obj_eps_end.DataBindings.Add(New Binding("Text", Me.retObj, "epsend")) ', True, DataSourceUpdateMode.OnPropertyChanged, Now(), "dd/MM/yyyy"))
        Me.tbl_trnAdvancedetileps.Columns("advancedetil_line").DefaultValue = retObj.advancedetil_line
        Me.tbl_trnAdvancedetileps.Columns("budgetdetil_line").DefaultValue = retObj.budgetdetil_line

        Me.tbl_trnAdvancedetileps.Columns("budgetdetiluse_line").DefaultValue = DBNull.Value
        Me.tbl_trnAdvancedetileps.Columns("budgetdetiluse_line").AutoIncrement = True
        Me.tbl_trnAdvancedetileps.Columns("budgetdetiluse_line").AutoIncrementSeed = 10
        Me.tbl_trnAdvancedetileps.Columns("budgetdetiluse_line").AutoIncrementStep = 10

        Me.FormatDgvTrnOrderdetiluse(Me.DgvOrderdetiluse)
        Me.DgvOrderdetiluse.DataSource = Me.tbl_trnAdvancedetileps

        Me.tbl_trnAdvancedetileps.DefaultView.RowFilter = String.Format("budgetdetil_line={0}", retObj.budgetdetil_line)
        Me.tbl_trnAdvancedetileps.DefaultView.Sort = "budgetdetil_eps"

        Me.btnGenerate_Click(Me, New System.EventArgs)

    End Sub

    Private Sub btnGenerate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerate.Click
        Dim i, a As Integer
        Dim rowFilter As String
        Dim rows() As DataRow
        Dim newrow As DataRow
        Dim myeps As Integer = Me.obj_eps_start.Text


        'cek apakah tanggal ini di line ybs sudah ada
        For a = Me.obj_eps_start.Text To Me.obj_eps_end.Text
            rowFilter = String.Format("budgetdetil_line={0} and budgetdetil_eps='{1}'", retObj.budgetdetil_line, a)
            rows = Me.tbl_trnAdvancedetileps.Select(rowFilter)
            If rows.Length = 0 Then
                newrow = Me.tbl_trnAdvancedetileps.NewRow()
                newrow("budgetdetil_eps") = a 'myeps
                newrow("budget_name") = retObj.budget_name
                Me.tbl_trnAdvancedetileps.Rows.Add(newrow)
                ''''Else
                ''''    Exit For
            End If
        Next
        'End While

        'potong tanggal sebelum Me.obj_Order_usagedatestart.Value
        rowFilter = String.Format("budgetdetil_line={0} and budgetdetil_eps<'{1}'", retObj.budgetdetil_line, Me.obj_eps_start.Text)
        rows = Me.tbl_trnAdvancedetileps.Select(rowFilter)
        For i = 0 To rows.Length - 1
            Me.tbl_trnAdvancedetileps.Rows.Remove(rows(i))
        Next

        'potong tanggal setelah Me.obj_Order_usagedateend.Value
        rowFilter = String.Format("budgetdetil_line={0} and budgetdetil_eps>'{1}'", retObj.budgetdetil_line, Me.obj_eps_end.Text)
        rows = Me.tbl_trnAdvancedetileps.Select(rowFilter)
        For i = 0 To rows.Length - 1
            Me.tbl_trnAdvancedetileps.Rows.Remove(rows(i))
        Next

    End Sub

    Private Sub DgvOrderdetiluse_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DgvOrderdetiluse.CellFormatting
        Dim used As Boolean
        Dim obj As DataGridView = sender
        Dim objRow As System.Windows.Forms.DataGridViewRow = obj.Rows(e.RowIndex)

        Try
            used = CType(objRow.Cells("checked").Value, Boolean)
            If used Then
                objRow.DefaultCellStyle.BackColor = Color.LavenderBlush
                objRow.Cells("budgetdetil_eps").Style.BackColor = Color.LightPink
            Else
                objRow.DefaultCellStyle.BackColor = Color.White
                objRow.Cells("budgetdetil_eps").Style.BackColor = Color.Gainsboro
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub DgvOrderdetiluse_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvOrderdetiluse.CellClick
        If e.ColumnIndex = 1 Then
            Dim i As Integer

            For i = 0 To Me.DgvOrderdetiluse.Rows.Count - 1
                If i <> e.RowIndex Then
                    Me.DgvOrderdetiluse.Rows(i).Cells("checked").Value = False
                End If
            Next
        End If
    End Sub
End Class