'Last Edited by Ari Prasasti
'12 januari 2012
'Menambahkan proses background worker untuk proses load data
'TRANS TV 

Imports System.Windows.Forms

Public Class dlgTrnCirculationSelectPV

    Private CloseButtonIsPressed As Boolean
    Private dsn As String
    Private channel_id As String
    Private ref_id As String

    Private tbl_TrnCirculation As DataTable = CreateTblTrnJurnal()
    Private tbl_TrnCirculation_temp As DataTable = CreateTblTrnJurnal()

    Private tbl_TrnTrnCirculationSelect As DataTable = CreateTblTrnJurnal()
    Private rettbl As DataTable = CreateTblTrnJurnal()
    Private title As String

#Region " Properties "
    Public Sub New(ByVal strDSN As String, ByVal channel_id As String, ByVal ref_id As String)
        Me.dsn = strDSN
        Me.channel_id = channel_id
        Me.ref_id = ref_id
        InitializeComponent()
    End Sub
#End Region

#Region " Constructor & Default Function"
    Public Shadows Function OpenDialog(ByVal owner As System.Windows.Forms.IWin32Window) As DataTable
        Me.ProgressBar1.Show()
        Me.BackgroundWorker1.RunWorkerAsync()
        Timer1.Enabled = True

        'Dim oDataFiller As New clsDataFiller(dsn)
        'Dim criteria As String = String.Empty
        'Dim tbl_setup As DataTable = New DataTable
        'Dim tbl_periode As DataTable = New DataTable
        'Dim tbl_userDefault As DataTable = New DataTable


        'Try
        '    Me.tbl_TrnCirculation.Clear()

        '    criteria = String.Format(" LEFT(A.jurnal_id,2) = 'PV' AND  A.jurnal_id NOT IN (SELECT circulationdetil_reference FROM transaksi_circulationvoucherdetil WHERE circulationdetil_canceled = 0) ")
        '    oDataFiller.DataFill(Me.tbl_TrnCirculation, "act_TrnCirculationVoucher_Select_PV", criteria, Me.channel_id)
        '    If Me.ref_id <> String.Empty Then
        '        Me.tbl_TrnCirculation.DefaultView.RowFilter = String.Format(" jurnal_id NOT IN {0} ", Me.ref_id)
        '    End If


        '    Me.DgvListPV.DataSource = Me.tbl_TrnCirculation
        '    Me.DgvSelect.DataSource = Me.tbl_TrnTrnCirculationSelect
        '    Me.FormatDgvTrnJurnal(Me.DgvListPV)
        '    Me.FormatDgvTrnJurnalDetilSelect(Me.DgvSelect)


        'Catch ex As Exception
        'End Try

        

        MyBase.ShowDialog(owner)

        If Me.CloseButtonIsPressed Then
            Return Me.rettbl
        Else
            Return Nothing
        End If
    End Function
#End Region

#Region " UI Layout & Format "
    Function CreateTblTrnJurnal() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("jurnal_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("jurnaldetil_check", GetType(System.Boolean)))
        tbl.Columns.Add(New DataColumn("currency_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("currency_name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("jurnal_descr", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("currency_rate", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("jurnal_amountidr", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("jurnal_amountforeign", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("bilyet", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("payment", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("rekanan_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("rekanan_name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("jurnal_iscreatedate", GetType(System.DateTime)))

        tbl.Columns("jurnal_id").DefaultValue = String.Empty
        tbl.Columns("jurnaldetil_check").DefaultValue = False
        tbl.Columns("currency_id").DefaultValue = 0
        tbl.Columns("currency_name").DefaultValue = String.Empty
        tbl.Columns("jurnal_descr").DefaultValue = String.Empty
        tbl.Columns("currency_rate").DefaultValue = 0
        tbl.Columns("jurnal_amountidr").DefaultValue = 0
        tbl.Columns("jurnal_amountforeign").DefaultValue = 0
        tbl.Columns("bilyet").DefaultValue = String.Empty
        tbl.Columns("payment").DefaultValue = String.Empty
        tbl.Columns("rekanan_id").DefaultValue = 0
        tbl.Columns("rekanan_name").DefaultValue = String.Empty
        tbl.Columns("jurnal_iscreatedate").DefaultValue = Now()

        Return tbl
    End Function
    Private Function FormatDgvTrnJurnal(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        ' Format  Columns 
        Dim cJurnaldetil_check As System.Windows.Forms.DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Dim cJurnal_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cCurrency_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cCurrency_name As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnal_descr As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cCurrency_rate As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnal_amountidr As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnal_amountforeign As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBilyet As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cPayment As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekanan_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekanan_name As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnal_iscreatedate As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn

        cJurnaldetil_check.Name = "jurnaldetil_check"
        cJurnaldetil_check.HeaderText = "Pilih"
        cJurnaldetil_check.DataPropertyName = "jurnaldetil_check"
        cJurnaldetil_check.Width = 40
        cJurnaldetil_check.Visible = False
        cJurnaldetil_check.ReadOnly = False

        cJurnal_id.Name = "jurnal_id"
        cJurnal_id.HeaderText = "Jurnal ID"
        cJurnal_id.DataPropertyName = "jurnal_id"
        cJurnal_id.Width = 100
        cJurnal_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cJurnal_id.Visible = True
        cJurnal_id.ReadOnly = False

        cCurrency_id.Name = "currency_id"
        cCurrency_id.HeaderText = "Curr."
        cCurrency_id.DataPropertyName = "currency_id"
        cCurrency_id.Width = 55
        cCurrency_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cCurrency_id.Visible = False
        cCurrency_id.ReadOnly = False

        cCurrency_name.Name = "currency_name"
        cCurrency_name.HeaderText = "Curr."
        cCurrency_name.DataPropertyName = "currency_name"
        cCurrency_name.Width = 55
        cCurrency_name.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cCurrency_name.Visible = True
        cCurrency_name.ReadOnly = False

        cJurnal_descr.Name = "jurnal_descr"
        cJurnal_descr.HeaderText = "Descr"
        cJurnal_descr.DataPropertyName = "jurnal_descr"
        cJurnal_descr.Width = 150
        cJurnal_descr.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cJurnal_descr.Visible = True
        cJurnal_descr.ReadOnly = False

        cCurrency_rate.Name = "currency_rate"
        cCurrency_rate.HeaderText = "Rate"
        cCurrency_rate.DataPropertyName = "currency_rate"
        cCurrency_rate.Width = 75
        cCurrency_rate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cCurrency_rate.Visible = True
        cCurrency_rate.ReadOnly = False

        cJurnal_amountidr.Name = "jurnal_amountidr"
        cJurnal_amountidr.HeaderText = "Amount (IDR)"
        cJurnal_amountidr.DataPropertyName = "jurnal_amountidr"
        cJurnal_amountidr.Width = 125
        cJurnal_amountidr.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cJurnal_amountidr.Visible = True
        cJurnal_amountidr.ReadOnly = False
        cJurnal_amountidr.DefaultCellStyle.Format = "#,##0"

        cJurnal_amountforeign.Name = "jurnal_amountforeign"
        cJurnal_amountforeign.HeaderText = "Amount"
        cJurnal_amountforeign.DataPropertyName = "jurnal_amountforeign"
        cJurnal_amountforeign.Width = 125
        cJurnal_amountforeign.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cJurnal_amountforeign.Visible = True
        cJurnal_amountforeign.ReadOnly = False
        cJurnal_amountforeign.DefaultCellStyle.Format = "#,##0"

        cBilyet.Name = "bilyet"
        cBilyet.HeaderText = "Bilyet"
        cBilyet.DataPropertyName = "bilyet"
        cBilyet.Width = 100
        cBilyet.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cBilyet.Visible = True
        cBilyet.ReadOnly = False

        cPayment.Name = "payment"
        cPayment.HeaderText = "Payment"
        cPayment.DataPropertyName = "payment"
        cPayment.Width = 100
        cPayment.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cPayment.Visible = True
        cPayment.ReadOnly = False

        cRekanan_id.Name = "rekanan_id"
        cRekanan_id.HeaderText = "Partner"
        cRekanan_id.DataPropertyName = "rekanan_id"
        cRekanan_id.Width = 150
        cRekanan_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cRekanan_id.Visible = False
        cRekanan_id.ReadOnly = False

        cRekanan_name.Name = "rekanan_name"
        cRekanan_name.HeaderText = "Partner"
        cRekanan_name.DataPropertyName = "rekanan_name"
        cRekanan_name.Width = 150
        cRekanan_name.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cRekanan_name.Visible = True
        cRekanan_name.ReadOnly = False

        cJurnal_iscreatedate.Name = "jurnal_iscreatedate"
        cJurnal_iscreatedate.HeaderText = "Create Date"
        cJurnal_iscreatedate.DataPropertyName = "jurnal_iscreatedate"
        cJurnal_iscreatedate.Width = 100
        cJurnal_iscreatedate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cJurnal_iscreatedate.Visible = True
        cJurnal_iscreatedate.ReadOnly = False
        cJurnal_iscreatedate.DefaultCellStyle.Format = "dd/MM/yyyy"

        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
        {cJurnaldetil_check, cJurnal_id, cRekanan_name, cCurrency_id, cCurrency_name, _
        cJurnal_amountforeign, cCurrency_rate, cJurnal_amountidr, cJurnal_descr, cBilyet, cPayment, cRekanan_id, cJurnal_iscreatedate})

        objDgv.AutoGenerateColumns = False
        objDgv.AllowUserToAddRows = False
        objDgv.AllowUserToDeleteRows = False
        objDgv.ReadOnly = True
        objDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        objDgv.Columns("jurnal_id").Frozen = True

    End Function
    Private Function FormatDgvTrnJurnalDetilSelect(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        Dim cJurnal_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        
        cJurnal_id.Name = "jurnal_id"
        cJurnal_id.HeaderText = "ID"
        cJurnal_id.DataPropertyName = "jurnal_id"
        cJurnal_id.Width = 90
        cJurnal_id.Visible = True
        cJurnal_id.ReadOnly = True

     
        objDgv.AutoGenerateColumns = False

        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
        {cJurnal_id})


        objDgv.AllowUserToAddRows = False
        objDgv.AllowUserToDeleteRows = True
        objDgv.AllowUserToResizeRows = False
        ' ''objDgv.ReadOnly = True
        objDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        objDgv.MultiSelect = True

    End Function
#End Region

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Dim obj As Button = sender
        Dim row As DataRow
        Dim maxRow As Integer = DgvListPV.RowCount

        If Me.DgvListPV.Rows.Count > 0 Then

            maxRow = Me.DgvListPV.RowCount - 1

            Dim rowInt As Integer = 0

            Dim thisRetObj As Collection = New Collection
            Dim i As Integer
            Dim col As Integer
            Dim columnName As String

            For i = 0 To Me.tbl_TrnCirculation.Rows.Count - 1
                If clsUtil.IsDbNull(Me.tbl_TrnCirculation.Rows(i).Item("jurnaldetil_check"), False) = True Then
                    row = Me.tbl_TrnCirculation_temp.NewRow
                    For col = 0 To tbl_TrnCirculation.Columns.Count - 1
                        columnName = tbl_TrnCirculation.Columns(col).ColumnName
                        If columnName <> "jurnaldetil_check" Then
                            row(columnName) = Me.tbl_TrnCirculation.Rows(i).Item(columnName)
                        End If
                    Next
                    Me.tbl_TrnCirculation_temp.Rows.Add(row)
                End If
            Next
            rettbl = Me.tbl_TrnCirculation_temp

            Me.CloseButtonIsPressed = True
        Else
            Me.CloseButtonIsPressed = False
        End If
        ' Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub obj_search_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles obj_search.TextChanged
        Dim filter As String = String.Empty

        Try
            If Me.ref_id = String.Empty Then
                filter = String.Format("jurnal_id LIKE '%{0}%'", Me.obj_search.Text)
            Else
                filter = String.Format("jurnal_id LIKE '%{0}%' AND jurnal_id NOT IN {1}", Me.obj_search.Text, Me.ref_id)
            End If
            If Me.obj_search.Text = String.Empty Then
                filter = String.Format(" jurnal_id NOT IN {0}", Me.ref_id)
            End If

            Me.tbl_TrnCirculation.DefaultView.RowFilter = filter
        Catch ex As Exception
        End Try

    End Sub

    Private Sub DgvListPV_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvListPV.CellDoubleClick
        If e.ColumnIndex < 0 Or e.RowIndex < 0 Then
            Exit Sub
        End If
        If Me.DgvListPV.CurrentRow IsNot Nothing Then
            If clsUtil.IsDbNull(Me.DgvListPV.Rows(e.RowIndex).Cells("jurnaldetil_check").Value, False) = False Then
                Dim row As DataRow
                Dim i, col As Integer
                Dim columnName As String

                If Me.tbl_TrnCirculation.DefaultView.Count > 0 Then
                    For i = 0 To Me.tbl_TrnCirculation.Rows.Count - 1
                        If Me.tbl_TrnCirculation.Rows(i).Item("jurnal_id") = Me.DgvListPV.Rows(e.RowIndex).Cells("jurnal_id").Value Then
                            Me.tbl_TrnCirculation.Rows(i).Item("jurnaldetil_check") = True
                            row = Me.tbl_TrnTrnCirculationSelect.NewRow()
                            For col = 0 To Me.tbl_TrnCirculation.Columns.Count - 1
                                columnName = Me.tbl_TrnCirculation.Columns(col).ColumnName
                                row(columnName) = Me.tbl_TrnCirculation.Rows(i).Item(columnName)
                            Next
                            Me.tbl_TrnTrnCirculationSelect.Rows.Add(row)

                            Exit For
                        End If
                    Next
                End If
            Else
                MsgBox("udah ada di list")
            End If
        End If
    End Sub

    Private Sub DgvSelect_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles DgvSelect.UserDeletingRow
        Dim x As Integer
        If e.Row.Index < 0 Then Exit Sub

        '=======================================================================================
        For x = 0 To Me.DgvSelect.SelectedRows.Count - 1
            Dim refId As String = Me.DgvSelect.SelectedRows.Item(x).Cells("jurnal_id").Value
            Dim ref As String = String.Empty

            Dim jml As Integer = 0
            For i As Integer = 0 To Me.DgvSelect.Rows.Count - 1
                If Me.DgvSelect.Item("jurnal_id", i).Value = refId Then
                    jml = jml + 1
                End If
            Next

            If jml = 1 Then

                For i As Integer = 0 To Me.DgvListPV.Rows.Count - 1
                    ref = Me.DgvListPV.Item("jurnal_id", i).Value
                    If refId = ref Then
                        Me.DgvListPV.Rows(i).Cells("jurnaldetil_check").Value = False
                        Me.DgvListPV.Rows(i).DefaultCellStyle.BackColor = Color.White
                        Exit For
                    End If
                Next
            End If
        Next
        '====================================================================================

    End Sub

    Private Sub DgvListPV_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DgvListPV.CellFormatting

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

    Private Sub BackgroundWorker1_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Dim oDataFiller As New clsDataFiller(dsn)
        Dim criteria As String = String.Empty
        Dim tbl_setup As DataTable = New DataTable
        Dim tbl_periode As DataTable = New DataTable
        Dim tbl_userDefault As DataTable = New DataTable

        Try
            Me.tbl_TrnCirculation.Clear()
            criteria = String.Format(" LEFT(A.jurnal_id,2) = 'PV' AND  A.jurnal_id NOT IN (SELECT circulationdetil_reference FROM transaksi_circulationvoucherdetil WHERE circulationdetil_canceled = 0) ")
            oDataFiller.DataFill(Me.tbl_TrnCirculation, "act_TrnCirculationVoucher_Select_PV", criteria, Me.channel_id)
            If Me.ref_id <> String.Empty Then
                Me.tbl_TrnCirculation.DefaultView.RowFilter = String.Format(" jurnal_id NOT IN {0} ", Me.ref_id)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        ProgressBar1.Hide()
        Me.lblLoading.Hide()

        Me.DgvListPV.DataSource = Me.tbl_TrnCirculation
        Me.DgvSelect.DataSource = Me.tbl_TrnTrnCirculationSelect

        Me.FormatDgvTrnJurnal(Me.DgvListPV)
        Me.FormatDgvTrnJurnalDetilSelect(Me.DgvSelect)
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Dim iStr As Integer = 1
        ProgressBar1.Value += iStr

        If ProgressBar1.Value = 100 Then
            If Me.tbl_TrnCirculation.Rows.Count > 0 Then
                ProgressBar1.Value = 0
                ProgressBar1.Hide()
                Me.lblLoading.Text = "Please Wait..."

                Timer1.Enabled = False
                Exit Sub
            Else
                ProgressBar1.Value = 0
            End If
        End If
    End Sub
End Class



