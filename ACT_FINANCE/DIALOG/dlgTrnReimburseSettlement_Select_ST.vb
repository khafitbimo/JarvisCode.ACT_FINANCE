
Public Class dlgTrnReimburseSettlement_Select_ST

    Private mDSN As String
    Private retObj As Object

    Private mChannel_id As String
    Private objError As ErrorProvider = New ErrorProvider
    Private SOURCE As String
    Private rekanan_id As Decimal

    Private myOwner As System.Windows.Forms.IWin32Window

    Private tbl_TrnJurnalST As DataTable = CreateTblTrnJurnalDetilBQListST()

    Private tbl_MstRekananGrid As DataTable = clsDataset.CreateTblMstrekananCombo
    Private tbl_MstAccGrid As DataTable = clsDataset.CreateTblMstAccountCombo

    Private SelectedCurr As String = ""
    Private SelectedRekanan As String = ""

#Region " Properties "
    Public ReadOnly Property DSN() As String
        Get
            Return mDSN
        End Get
    End Property
#End Region

#Region " Constructor & Default Function"

    Public Sub New(ByVal dsn As String, ByVal rekanan_id As Decimal, _
                ByVal tbl_MstRekananGrid As DataTable, ByVal tbl_MstAccGrid As DataTable)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.mDSN = dsn
        Me.rekanan_id = rekanan_id

        Me.tbl_MstRekananGrid = tbl_MstRekananGrid.Copy
        Me.tbl_MstAccGrid = tbl_MstAccGrid.Copy
    End Sub
    Public Shadows Function OpenDialog(ByVal owner As System.Windows.Forms.IWin32Window, _
                ByVal channel_id As String, Optional ByVal _SOURCE As String = "") As Object

        mChannel_id = channel_id
        Me.obj_Channel_id.Text = channel_id
        Me.SOURCE = _SOURCE

        Me.myOwner = owner
        MyBase.ShowDialog(owner)
        Return retObj
    End Function

#End Region

#Region " UI Layout & Format "

    Function CreateTblTrnJurnalDetilBQListST() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("jurnal_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("jurnaldetil_check", GetType(System.Boolean)))
        tbl.Columns.Add(New DataColumn("jurnal_bookdate", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("jurnal_duedate", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("jurnaldetil_line", GetType(System.Int64)))
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
        tbl.Columns.Add(New DataColumn("jurnal_descr", GetType(System.String)))


        '-------------------------------
        'Default Value: 
        tbl.Columns("jurnal_id").DefaultValue = ""
        tbl.Columns("jurnaldetil_check").DefaultValue = False
        tbl.Columns("jurnal_bookdate").DefaultValue = Now.Date
        tbl.Columns("jurnal_duedate").DefaultValue = Now.Date
        tbl.Columns("jurnaldetil_line").DefaultValue = 0
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
        tbl.Columns("jurnal_descr").DefaultValue = ""


        Return tbl
    End Function
    Private Function FormatDgvTrnJurnalDetilBQListST(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        ' formating DgvTrnJurnaldetil Columns
        Dim cJurnal_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnaldetil_check As System.Windows.Forms.DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Dim cJurnal_bookdate As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnal_duedate As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnaldetil_line As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
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
        Dim cJurnal_descr As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn


        cJurnaldetil_check.Name = "jurnaldetil_check"
        cJurnaldetil_check.HeaderText = "Pilih"
        cJurnaldetil_check.DataPropertyName = "jurnaldetil_check"
        cJurnaldetil_check.Width = 30
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
        cJurnal_bookdate.Visible = True
        cJurnal_bookdate.ReadOnly = True
        cJurnal_bookdate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        cJurnal_bookdate.DefaultCellStyle.Format = "dd/MM/yyyy"
        'cJurnal_bookdate.DefaultCellStyle.BackColor = Color.Gainsboro

        cJurnal_duedate.Name = "jurnal_duedate"
        cJurnal_duedate.HeaderText = "Due Date"
        cJurnal_duedate.DataPropertyName = "jurnal_duedate"
        cJurnal_duedate.Width = 85
        cJurnal_duedate.Visible = True
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

        cJurnaldetil_descr.Name = "jurnaldetil_descr"
        cJurnaldetil_descr.HeaderText = "Descr"
        cJurnaldetil_descr.DataPropertyName = "jurnaldetil_descr"
        cJurnaldetil_descr.Width = 100
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
        cJurnaldetil_rate.Visible = False
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
        cRekanan_id.Width = 100
        cRekanan_id.Visible = False
        cRekanan_id.ReadOnly = True

        cChannel_id.Name = "channel_id"
        cChannel_id.HeaderText = "Channel"
        cChannel_id.DataPropertyName = "channel_id"
        cChannel_id.Width = 75
        cChannel_id.Visible = True
        cChannel_id.ReadOnly = True

        cRekanan_name.Name = "rekanan_name"
        cRekanan_name.HeaderText = "Rekanan"
        cRekanan_name.DataPropertyName = "rekanan_name"
        cRekanan_name.Width = 75
        cRekanan_name.Visible = True
        cRekanan_name.ReadOnly = True

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
        cAcc_name.Width = 75
        cAcc_name.Visible = True
        cAcc_name.ReadOnly = True

        cJurnal_descr.Name = "jurnal_descr"
        cJurnal_descr.HeaderText = "jurnal_descr"
        cJurnal_descr.DataPropertyName = "jurnal_descr"
        cJurnal_descr.Width = 100
        cJurnal_descr.Visible = True
        cJurnal_descr.ReadOnly = True


        objDgv.AutoGenerateColumns = False
        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
        {cJurnaldetil_check, cJurnal_id, cJurnaldetil_line, _
         cJurnaldetil_idr_outstanding, cJurnaldetil_receive, cJurnaldetil_idr, _
         cJurnaldetil_foreign_outstanding, cJurnaldetil_receive_foreign, cJurnaldetil_foreign, cJurnaldetil_rate, _
         cJurnaldetil_receive_foreignrate, cJurnaldetil_descr, cCurrency_id, cCurrency_name, cRekanan_id, cRekanan_name, _
         cChannel_id, cJurnal_duedate, cJurnal_bookdate, cAcc_id, cAcc_name, cJurnal_descr})
        objDgv.Columns("jurnaldetil_line").Frozen = True

        objDgv.AllowUserToAddRows = False
        objDgv.AllowUserToDeleteRows = False
        objDgv.AllowUserToResizeRows = False
        objDgv.SelectionMode = DataGridViewSelectionMode.CellSelect
        objDgv.MultiSelect = False


    End Function

#End Region

#Region " User defined function "

    Private Function getSetting(ByVal setting_id As String) As String
        Dim frmOwner As uiBase = CType(Me.myOwner, uiBase)
        Return frmOwner.getSetting(setting_id)
    End Function

    Private Function dlgTrnJurnalDetilSelect_Load(ByVal channel_id As String) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter
        Dim criteria = ""

        Dim txtSearchCriteria As String = ""
        Dim txtSQLSearch As String = String.Empty

        If Me.chkSearchSource.Checked = True Then
            txtSQLSearch = txtSQLSearch & String.Format(" LEFT(A.jurnal_id, 2) = '{0}'", Me.obj_Source.SelectedItem)
        End If

        If Me.chkSearchJurnalID.Checked Then
            txtSearchCriteria = clsUtil.RefParser("jurnal_id", Me.obj_jurnal_id)
            If txtSQLSearch = "" Then
                txtSQLSearch = " (" & txtSearchCriteria & ") "
            Else
                txtSQLSearch = txtSQLSearch & " AND " & " (" & txtSearchCriteria & ") "
            End If
        End If

        '-- Rekanan Search    
        If Me.chkRekanan.Checked Then
            txtSearchCriteria = String.Format(" rekanan_id = '{0}' ", Me.obj_Rekanan_id.Text)
            If txtSQLSearch = "" Then
                txtSQLSearch = " (" & txtSearchCriteria & ") "
            Else
                txtSQLSearch = txtSQLSearch & " AND " & " (" & txtSearchCriteria & ") "
            End If
        End If
        '--END 

        '-- Account Search    
        If Me.chkAccount.Checked Then

            txtSearchCriteria = String.Format(" acc_id = '{0}' ", Me.obj_Acc_H.Text)
            If txtSQLSearch = "" Then
                txtSQLSearch = " (" & txtSearchCriteria & ") "
            Else
                txtSQLSearch = txtSQLSearch & " AND " & " (" & txtSearchCriteria & ") "
            End If
        End If
        '--END 

        '-- Advance Search
        If Me.chkSearchAdv.Checked Then
            If Trim(Me.txtSearchAdv.Text) <> "" Then
                txtSearchCriteria = " " & Me.txtSearchAdv.Text & " "
                If txtSQLSearch = "" Then
                    txtSQLSearch = " (" & txtSearchCriteria & ") "
                Else
                    txtSQLSearch = txtSQLSearch & " AND " & " (" & txtSearchCriteria & ") "
                End If
            End If
        End If
        'END Advance Search


        criteria = txtSQLSearch

        dbCmd = New OleDb.OleDbCommand("cp_TrnJurnaldetil_SelectSTForBQ", dbConn)
        dbCmd.Parameters.Add("@channel_id", Data.OleDb.OleDbType.VarWChar)
        dbCmd.Parameters("@channel_id").Value = channel_id
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarWChar)
        dbCmd.Parameters("@Criteria").Value = criteria

        dbCmd.CommandType = CommandType.StoredProcedure
        dbCmd.CommandTimeout = 0
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)
        Me.tbl_TrnJurnalST.Clear()
        Dim cookie As Byte() = Nothing

        Try
            dbConn.Open()
            clsApplicationRole.SetAppRole(dbConn, cookie)
            dbDA.Fill(Me.tbl_TrnJurnalST)

            Me.DgvDetil.DataSource = Me.tbl_TrnJurnalST
        Catch ex As Exception
            MessageBox.Show(ex.Message, "dlgTrnJurnalSelect" & ": dlgTrnJurnalDetilSelect_LoadDetil()", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            clsApplicationRole.UnsetAppRole(dbConn, cookie)
            dbConn.Close()
        End Try
    End Function

#End Region

    Private Sub dlgTrnJurnal_BQ_Select_ST_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.Cursor = Cursors.WaitCursor
        Me.FormatDgvTrnJurnalDetilBQListST(Me.DgvDetil)
        Me.DgvDetil.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Me.DgvDetil.DataSource = Me.tbl_TrnJurnalST

        Me.txtSearchAdv.Enabled = False
        Me.obj_Acc_H.Enabled = False
        Me.obj_jurnal_id.Enabled = False
        Me.chkRekanan.Checked = False
        Me.obj_Rekanan_id.Enabled = False

        Me.obj_Source.Items.Add("ST")
        Me.obj_Source.SelectedItem = "ST"
        Me.obj_Source.Enabled = False
        Me.Text = "Reimburse Settlement - List ST"

        Me.Cursor = Cursors.Arrow

    End Sub

    '=============================Button================================================================================================================================================================
    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click

        Me.dlgTrnJurnalDetilSelect_Load(Me.getSetting("channel_id"))
        Me.DgvDetil.DataSource = Me.tbl_TrnJurnalST

    End Sub

    Private Sub btnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelect.Click
        Dim tblRef As DataTable = clsDataset.CreateTblJurnalReferencePVselectAP()
        Dim tblH As DataTable = clsDataset.CreateTblTrnJurnaldetil()
        Dim tblJDetil As DataTable = clsDataset.CreateTblTrnJurnaldetil()

        Dim tblAdvanceHeader As DataTable = clsDataset.CreateTblTrnAdvance()
        Dim tblAdvanceDetil As DataTable = clsDataset.CreateTblTrnAdvancedetil()
        Dim tblAdvance_itemDetil As DataTable = clsDataset.CreateTblTrnAdvanceItemDetil()

        Dim row As DataRow
        Dim Descr As String = ""
        Dim thisRetObj As Collection = New Collection
        Dim tbl_TrnJurnalSales_1 As DataTable = CreateTblTrnJurnalDetilBQListST()
        Dim i As Integer

        If Me.dlgTrnJurnalPV_Select_AP_verify() = False Then
            Exit Sub
        End If

        tbl_TrnJurnalSales_1.Clear()
        tbl_TrnJurnalSales_1 = Me.tbl_TrnJurnalST.Copy()
        tbl_TrnJurnalSales_1.DefaultView.RowFilter = "jurnaldetil_check = 'True'"


        If Me.DgvDetil.CurrentRow IsNot Nothing Then
            If tbl_TrnJurnalSales_1.DefaultView.Count > 0 Then
                For i = 0 To tbl_TrnJurnalSales_1.DefaultView.Count - 1

                    row = tblRef.NewRow()
                    row.Item("ref") = tbl_TrnJurnalSales_1.DefaultView.Item(i).Item("jurnal_id")
                    row.Item("line") = tbl_TrnJurnalSales_1.DefaultView.Item(i).Item("jurnaldetil_line")
                    row.Item("bookdate") = tbl_TrnJurnalSales_1.DefaultView.Item(i).Item("jurnal_bookdate")
                    row.Item("descr") = tbl_TrnJurnalSales_1.DefaultView.Item(i).Item("jurnaldetil_descr")
                    row.Item("idr") = String.Format("{0:#,##0}", CDec(tbl_TrnJurnalSales_1.DefaultView.Item(i).Item("jurnaldetil_idr_outstanding")))
                    row.Item("foreigns") = String.Format("{0:#,##0.00}", CDec(tbl_TrnJurnalSales_1.DefaultView.Item(i).Item("jurnaldetil_foreign_outstanding")))
                    row.Item("channel_id") = tbl_TrnJurnalSales_1.DefaultView.Item(i).Item("channel_id")
                    row.Item("rekanan_id") = tbl_TrnJurnalSales_1.DefaultView.Item(i).Item("rekanan_id")
                    row.Item("rekanan_name") = tbl_TrnJurnalSales_1.DefaultView.Item(i).Item("rekanan_name")
                    row.Item("jurnal_duedate") = tbl_TrnJurnalSales_1.DefaultView.Item(i).Item("jurnal_duedate")
                    tblRef.Rows.Add(row)

                    row = tblAdvanceHeader.NewRow()
                    row.Item("budget_id") = 0
                    row.Item("currency_id") = tbl_TrnJurnalSales_1.DefaultView.Item(i).Item("currency_id")
                    row.Item("rekanan_id") = tbl_TrnJurnalSales_1.DefaultView.Item(i).Item("rekanan_id")
                    row.Item("advance_descr") = tbl_TrnJurnalSales_1.DefaultView.Item(i).Item("jurnal_descr")

                    tblAdvanceHeader.Rows.Add(row)

                    row = tblAdvanceDetil.NewRow()
                    row.Item("advance_id") = tbl_TrnJurnalSales_1.DefaultView.Item(i).Item("jurnal_id")
                    row.Item("advancedetil_line") = tbl_TrnJurnalSales_1.DefaultView.Item(i).Item("jurnaldetil_line")
                    row.Item("currency_id") = tbl_TrnJurnalSales_1.DefaultView.Item(i).Item("currency_id")
                    row.Item("advancedetil_foreignrate") = tbl_TrnJurnalSales_1.DefaultView.Item(i).Item("jurnaldetil_rate")
                    tblAdvanceDetil.Rows.Add(row)

                    row = tblAdvance_itemDetil.NewRow()
                    row.Item("advance_requestid") = tbl_TrnJurnalSales_1.DefaultView.Item(i).Item("jurnal_id")
                    row.Item("advance_requestid_line") = tbl_TrnJurnalSales_1.DefaultView.Item(i).Item("jurnaldetil_line")

                    If tbl_TrnJurnalSales_1.DefaultView.Item(i).Item("currency_id") = 1 Then
                        row.Item("amount_advance") = tbl_TrnJurnalSales_1.DefaultView.Item(i).Item("jurnaldetil_idr_outstanding")
                    Else
                        row.Item("amount_advance") = tbl_TrnJurnalSales_1.DefaultView.Item(i).Item("jurnaldetil_foreign_outstanding")
                    End If

                    row.Item("amount_idrreal") = tbl_TrnJurnalSales_1.DefaultView.Item(i).Item("jurnaldetil_idr_outstanding")
                    row.Item("advancedetil_foreignrate") = tbl_TrnJurnalSales_1.DefaultView.Item(i).Item("jurnaldetil_rate")
                    row.Item("channel_id") = tbl_TrnJurnalSales_1.DefaultView.Item(i).Item("channel_id")
                    row.Item("budget_id") = 0
                    row.Item("budget_name") = ""
                    row.Item("budgetdetil_id") = 0
                    row.Item("budgetdetil_name") = ""
                    row.Item("budgetdetil_eps") = 0
                    row.Item("acc_id") = tbl_TrnJurnalSales_1.DefaultView.Item(i).Item("acc_id")
                    row.Item("currency_id") = tbl_TrnJurnalSales_1.DefaultView.Item(i).Item("currency_id")
                    tblAdvance_itemDetil.Rows.Add(row)

                Next

                thisRetObj.Add(tblRef.Copy(), "tblRef")
                thisRetObj.Add(tblAdvanceHeader.Copy(), "tblAdvanceHeader")
                thisRetObj.Add(tblAdvanceDetil.Copy(), "tblAdvanceDetil")
                thisRetObj.Add(tblAdvance_itemDetil.Copy(), "tblAdvanceItemDetil")

                retObj = thisRetObj

                Me.Close()
            End If
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.retObj = Nothing
        Me.Close()
    End Sub

    '==================================Link Button==============================================================================================================================================================================
    Private Sub LinkCheck1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkCheck1.LinkClicked
        Dim i As Integer

        For i = 0 To Me.tbl_TrnJurnalST.Rows.Count - 1
            Me.tbl_TrnJurnalST.Rows(i).Item("jurnaldetil_check") = True
        Next
        Me.DgvDetil.DataSource = Me.tbl_TrnJurnalST
    End Sub

    Private Sub LinkClear1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkClear1.LinkClicked
        Dim i As Integer

        For i = 0 To Me.tbl_TrnJurnalST.Rows.Count - 1
            Me.tbl_TrnJurnalST.Rows(i).Item("jurnaldetil_check") = False
        Next
        Me.DgvDetil.DataSource = Me.tbl_TrnJurnalST
    End Sub

    '===========================================================================================================================================================================================================================

    Private Sub lnkClear_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkClear.LinkClicked
        Me.txtSearchAdv.Text = ""

    End Sub

    Private Sub lnkQueryBuilder_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkQueryBuilder.LinkClicked
        Dim dlg As dlgQueryBuilder = New dlgQueryBuilder
        Dim retString As String

        dlg.ShowInTaskbar = False
        dlg.StartPosition = FormStartPosition.CenterParent
        dlg.Init(Me.txtSearchAdv.Text, Me.tbl_TrnJurnalST.Clone)
        retString = dlg.OpenDialog(Me)

        Me.txtSearchAdv.Text = retString

    End Sub

    Private Sub chkSearchAdv_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSearchAdv.CheckedChanged
        If Me.chkSearchAdv.Checked = True Then
            Me.txtSearchAdv.Enabled = True
        Else
            Me.txtSearchAdv.Enabled = False
        End If
    End Sub

    Private Sub chkSearchJurnalID_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSearchJurnalID.CheckedChanged
        If Me.chkSearchJurnalID.Checked = True Then
            Me.obj_jurnal_id.Enabled = True
        Else
            Me.obj_jurnal_id.Enabled = False
        End If
    End Sub

    Private Sub DgvSales_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs)
        Dim obj As DataGridView = sender
        Dim objRow As System.Windows.Forms.DataGridViewRow = obj.Rows(e.RowIndex)

        Try
            objRow.Cells("jurnaldetil_receive").Style.BackColor = Color.White
            objRow.Cells("jurnaldetil_receive_foreign").Style.BackColor = Color.White
        Catch ex As Exception
        End Try
    End Sub

    Private Sub DgvDetil_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs)

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

    Private Function dlgTrnJurnalPV_Select_AP_verify() As Boolean
        Dim i As Integer
        Dim tbl_TrnJurnalSales_1 As DataTable = CreateTblTrnJurnalDetilBQListST()
        Dim tbl_TrnJurnaldetil_1 As DataTable = CreateTblTrnJurnalDetilBQListST()
        Dim cekCurr As String = ""
        Dim cekRekanan As String = ""
        Dim cekAccount As String = ""

        tbl_TrnJurnaldetil_1.Clear()
        tbl_TrnJurnaldetil_1 = Me.tbl_TrnJurnalST.Copy()
        tbl_TrnJurnaldetil_1.DefaultView.RowFilter = "jurnaldetil_check = 'True'"


        If tbl_TrnJurnaldetil_1.DefaultView.Count > 0 Then
            For i = 0 To tbl_TrnJurnaldetil_1.DefaultView.Count - 1
                If cekCurr = "" Then
                    cekCurr = tbl_TrnJurnaldetil_1.DefaultView.Item(i).Item("currency_id").ToString
                    Me.SelectedCurr = cekCurr
                Else
                    If cekCurr <> tbl_TrnJurnaldetil_1.DefaultView.Item(i).Item("currency_id").ToString Then
                        MessageBox.Show("Currency tidak boleh berbeda", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Function
                    End If
                End If

                If cekRekanan = "" Then
                    cekRekanan = tbl_TrnJurnaldetil_1.DefaultView.Item(i).Item("rekanan_id").ToString
                    Me.SelectedRekanan = cekRekanan
                Else
                    If cekRekanan <> tbl_TrnJurnaldetil_1.DefaultView.Item(i).Item("rekanan_id").ToString Then
                        MessageBox.Show("Rekanan tidak boleh berbeda", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Function
                    End If
                End If
            Next
        End If
        Return True
    End Function

    Private Sub btn_Rekanan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Rekanan.Click
        '' ''Dim rekanan_id As String
        '' ''Dim dlg As dlgSearch = New dlgSearch()
        '' ''retObj = dlg.OpenDialog(Me, Me.tbl_MstRekananGrid, "rekanan")
        '' ''rekanan_id = retObj

        '' ''If rekanan_id IsNot Nothing Then
        '' ''    Me.obj_Rekanan_id.Text = rekanan_id
        '' ''End If

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

    Private Sub btn_Account_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Account.Click
        '' ''Dim account_id As String
        '' ''Dim dlg As dlgSearch = New dlgSearch()
        '' ''retObj = dlg.OpenDialog(Me, Me.tbl_MstAccGrid, "account")
        '' ''account_id = retObj

        '' ''If account_id IsNot Nothing Then
        '' ''    Me.obj_Acc_H.Text = account_id
        '' ''End If

        Dim dlg As dlgSearch = New dlgSearch()
        Dim retData As Collection
        Dim retObj As Object
        Dim account_id As Decimal

        retObj = dlg.OpenDialog(Me, Me.tbl_MstAccGrid, "account")
        If retObj IsNot Nothing Then
            retData = CType(retObj, Collection)
            account_id = CType(retData.Item("retId"), Decimal)
            Me.obj_Acc_H.Text = account_id
        End If
    End Sub

    Private Sub chkRekanan_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkRekanan.CheckedChanged
        If Me.chkRekanan.Checked = True Then
            Me.obj_Rekanan_id.Enabled = True
        Else
            Me.obj_Rekanan_id.Enabled = False
        End If
    End Sub

    Private Sub chkAccount_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkAccount.CheckedChanged
        If Me.chkAccount.Checked = True Then
            Me.obj_Acc_H.Enabled = True
        Else
            Me.obj_Acc_H.Enabled = False
        End If
    End Sub
End Class
