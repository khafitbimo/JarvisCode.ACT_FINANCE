Imports DevExpress.XtraTreeList
Imports DevExpress.XtraTreeList.Nodes
Imports DevExpress.XtraTreeList.Columns

Public Class uiMstAcc
    Private Const SHOW_SAVE_CONFIRMATION As Boolean = True
    Private Const mUiName As String = "Master Acc Ca"

    Private Event FormBeforeOpenRow(ByRef id As Object)
    Private Event FormAfterOpenRow(ByRef id As Object)
    Private Event FormBeforeSave(ByRef id As Object)
    Private Event FormAfterSave(ByRef id As Object, ByVal result As FormSaveResult)
    Private Event FormBeforeNew()
    Private Event FormBeforeDelete(ByRef id As Object)
    Private Event FormAfterDelete(ByRef id As Object)
    Private FILTER_QUERY_MODE As Boolean
    Private DATA_ISLOCKED As Boolean

    Private isLoadComboInLoadData As Boolean = False
    Private dt_default_channel As DataTable = New DataTable
    Private clsDataFill As clsDataFiller
    Private clsMstAcc As clsMstAccCa
    Private tblAccCa_combo As DataTable = clsDataset.CreateTblMstAccountCaCombo
    Private tblMstAccCa As DataTable = clsDataset.CreateTblMstAccCa
    Private tblMstAccCa_temp As DataTable = clsDataset.CreateTblMstAccCa
    Private tblMstAcc_edit As DataTable = clsDataset.CreateTblMstAccCa
    Private acc_index, action, acc_ca_id As String


#Region " Window Parameter "
    ' TODO: Buat variabel untuk menampung parameter window 
    Private _CHANNEL As String = "TAS"
    Private _CHANNEL_CANBE_CHANGED As Boolean = False
    Private _CHANNEL_CANBE_BROWSED As Boolean = False
#End Region

#Region " Overrides "
    Public Overrides Function btnLoad_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiMstAccCa_Retrieve()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnLoad_Click()
    End Function

    Public Overrides Function btnDel_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.Master_AccCa_Delete()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnDel_Click()
    End Function

    Public Overrides Function btnSave_Click() As Boolean
        If Me.Master_Acc_Ca_FormError() Then
            Return True
        End If
        Me.Cursor = Cursors.WaitCursor
        Me.uiMstAccCa_Save()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnSave_Click()
    End Function

    Public Overrides Function btnNew_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.action = "new"
        If Me.ftabMain.SelectedIndex = 0 Then
            Me.ftabMain.SelectedIndex = 1
        End If
        Me.Master_Acc_NewData()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnNew_Click()
    End Function

#End Region

#Region " Layout & Init UI "
    Private Function InitLayoutUI() As Boolean

        Me.ftabMain.Anchor = AnchorStyles.Bottom
        Me.ftabMain.Anchor += AnchorStyles.Top
        Me.ftabMain.Anchor += AnchorStyles.Right
        Me.ftabMain.Anchor += AnchorStyles.Left

        'Me.PnlDfSearch.Dock = DockStyle.Top
        'Me.PnlDfSearch.Visible = False
        Me.PnlDfMain.Dock = DockStyle.Fill

    End Function
#End Region

#Region " User Defined Function "


    Private Function uiMstAccCa_Retrieve() As Boolean
        'retrieve data

        Dim criteria As String = " acc_ca_active = 1 "
        Me.tblMstAccCa.Clear()
        Try
            Me.DataFill(Me.tblMstAccCa, "ms_MstAcc_ca_Select", criteria)
            tList_mst_acc.KeyFieldName = "acc_ca_id"
            tList_mst_acc.ParentFieldName = "acc_ca_mother"
            tList_mst_acc.DataSource = Me.tblMstAccCa
            tList_mst_acc.ExpandAll()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Function

    Private Function Master_Acc_OpenRow(ByVal acc_ca_id As String) As Boolean
        BindingStop()
        tblMstAccCa_temp.Clear()

        If action = "child" Then
            Me.Master_AccCa_OpenRowAddChild(acc_ca_id)
        ElseIf action = "new" Then
            Me.BindingContext(Me.tblMstAccCa_temp).AddNew()
            BindingStart()
        Else
            Me.Master_AccCa_OpenRowEdit(acc_ca_id)
        End If
    End Function

    Private Function Master_Acc_NewData() As Boolean
        RaiseEvent FormBeforeNew()

        Me.BindingContext(Me.tblMstAccCa_temp).EndCurrentEdit()
        Try
            'Me.BindingContext(Me.tblMstAccCa_temp).AddNew()
        Catch ex As Exception
            MessageBox.Show(ex.Source)
        End Try
    End Function

    Private Function BindingStop() As Boolean
        'stop binding
        Me.txtAcc_ca_Id.DataBindings.Clear()
        Me.txtAccName.DataBindings.Clear()
        Me.txtShort.DataBindings.Clear()
        Me.txtIndex.DataBindings.Clear()
        Me.cbParent.DataBindings.Clear()

        Return True
    End Function

    Private Function BindingStart() As Boolean
        'start binding
        Me.txtAcc_ca_Id.DataBindings.Add(New Binding("Text", Me.tblMstAccCa_temp, "acc_ca_id"))
        Me.txtAccName.DataBindings.Add(New Binding("Text", Me.tblMstAccCa_temp, "acc_ca_name"))
        Me.txtShort.DataBindings.Add(New Binding("Text", Me.tblMstAccCa_temp, "acc_ca_shortname"))
        Me.txtIndex.DataBindings.Add(New Binding("Text", Me.tblMstAccCa_temp, "acc_ca_idx"))
        Me.cbParent.DataBindings.Add(New Binding("selectedValue", Me.tblMstAccCa_temp, "acc_ca_mother"))
        Return True
    End Function

    Private Function uiMstAccCa_Save() As Boolean
        Dim tbl_MstAccCa_tempchange As DataTable
        Dim acc_ca_id As Object = New Object
        Dim success As Boolean
        Dim i As Integer = 0
        Dim MasterDataState As System.Data.DataRowState
        Dim result As FormSaveResult
        Me.Cursor = Cursors.WaitCursor

        Me.BindingContext(Me.tblMstAccCa_temp).EndCurrentEdit()
        tbl_MstAccCa_tempchange = Me.tblMstAccCa_temp.GetChanges()

        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbTrans As OleDb.OleDbTransaction


        Dim cookie As Byte() = Nothing


        If tbl_MstAccCa_tempchange IsNot Nothing Then
            dbConn.Open()
            dbTrans = dbConn.BeginTransaction()
            clsApplicationRole.SetAppRole(dbConn, dbTrans, cookie)
            Try
                MasterDataState = Me.tblMstAccCa_temp.Rows(0).RowState

                If tbl_MstAccCa_tempchange IsNot Nothing Then

                    success = Me.Master_AccCa_SaveMaster(acc_ca_id, tbl_MstAccCa_tempchange, MasterDataState, dbConn, dbTrans)
                    If Not success Then Throw New Exception("Error: Saving Master Data at Me.Master_AccCa_SaveMaster(tbl_MstAccCa_Temp_Changes)")
                    If Me.acc_ca_id <> "" Then
                        clsMstAcc.ChangeAcc_Type(Me.acc_ca_id, dbConn, dbTrans)
                    End If
                    dbTrans.Commit()
                    Me.tblMstAccCa_temp.AcceptChanges()
                End If

                result = FormSaveResult.SaveSuccess
                If SHOW_SAVE_CONFIRMATION Then
                    MessageBox.Show("Data Saved", mUiName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

            Catch ex As Exception
                result = FormSaveResult.SaveError
                MessageBox.Show("Data Cannot Be Saved" & vbCrLf & ex.Message, mUiName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                dbTrans.Rollback()
            Finally
                clsApplicationRole.UnsetAppRole(dbConn, dbTrans, cookie)
                dbConn.Close()
            End Try

        End If
        RaiseEvent FormAfterSave(acc_ca_id, result)
        Me.Cursor = Cursors.Arrow
    End Function

    Private Function Master_AccCa_Delete() As Boolean
        Dim res As String = ""
        Dim acc_ca_id As Object = New Object

        Me.Cursor = Cursors.WaitCursor
        RaiseEvent FormBeforeDelete(acc_ca_id)

        Me.Cursor = Cursors.WaitCursor
        If Me.tList_mst_acc.FocusedColumn IsNot Nothing Then

            res = MessageBox.Show("Are you sure want to delete data ?", mUiName, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If res = DialogResult.Yes Then
                Me.Master_Acc_ca_Delete(tList_mst_acc.FocusedNode("acc_ca_id").ToString)
            End If

        End If

        RaiseEvent FormAfterDelete(acc_ca_id)
        Me.Cursor = Cursors.Arrow

    End Function

    Private Function Master_Acc_ca_Delete(ByVal acc_ca_id As String) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbCmdDelete As OleDb.OleDbCommand


        dbCmdDelete = New OleDb.OleDbCommand("ms_MstAcc_ca_notActive", dbConn)
        dbCmdDelete.CommandType = CommandType.StoredProcedure
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@acc_ca_id", System.Data.OleDb.OleDbType.VarWChar, 7))
        dbCmdDelete.Parameters("@acc_ca_id").Value = acc_ca_id

        Dim cookie As Byte() = Nothing

        Try
            dbConn.Open()
            clsApplicationRole.SetAppRole(dbConn, cookie)
            dbCmdDelete.ExecuteNonQuery()
            uiMstAccCa_Retrieve()
            ftabMain.SelectedIndex = 0
        Catch ex As OleDb.OleDbException
            MessageBox.Show(ex.Message, "OLE DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Function
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Exit Function
        Finally
            clsApplicationRole.UnsetAppRole(dbConn, cookie)
            dbConn.Close()
        End Try
    End Function

    Private Function Master_Acc_Ca_FormError() As Boolean
        Try
            ' TODO: Cek Error disini
            Me.txtAccName.Focus()
            Dim length As Integer = txtAcc_ca_Id.Text.Length
            If length < 7 Then
                Throw New Exception("Length of acc ca id <> 7")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, mUiName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtAcc_ca_Id.Focus()
            Return True
        End Try
        Return False
    End Function

    Private Function Master_AccCa_SaveMaster(ByVal acc_ca_id As Object, ByVal objTbl As DataTable, ByVal MasterDataState As System.Data.DataRowState, ByVal dbConn As OleDb.OleDbConnection, ByVal dbTrans As OleDb.OleDbTransaction) As Boolean

        Dim dbCmdInsert As OleDb.OleDbCommand
        Dim dbCmdUpdate As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter
        Dim curpos As Integer

        dbCmdInsert = New OleDb.OleDbCommand("ms_MstAcc_ca_Insert", dbConn, dbTrans)
        dbCmdInsert.CommandType = CommandType.StoredProcedure
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@acc_ca_id", System.Data.OleDb.OleDbType.Integer, 7, "acc_ca_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@acc_ca_name", System.Data.OleDb.OleDbType.VarWChar, 100, "acc_ca_name"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@acc_ca_shortname", System.Data.OleDb.OleDbType.VarWChar, 100, "acc_ca_shortname"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@acc_ca_type", 2))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@acc_ca_mother", System.Data.OleDb.OleDbType.Integer, 7, "acc_ca_mother"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@acc_ca_idx", System.Data.OleDb.OleDbType.VarWChar, 70, "acc_ca_idx"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@acc_ca_active", System.Data.OleDb.OleDbType.Integer, 1, "acc_ca_active"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@acc_ca_entry_dt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "acc_ca_entry_dt"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@acc_ca_entry_by", System.Data.OleDb.OleDbType.Integer, 4, "acc_ca_entry_by"))

        dbCmdUpdate = New OleDb.OleDbCommand("ms_MstAcc_ca_Update", dbConn, dbTrans)
        dbCmdUpdate.CommandType = CommandType.StoredProcedure
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@acc_ca_id", System.Data.OleDb.OleDbType.Integer, 7, "acc_ca_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@acc_ca_name", System.Data.OleDb.OleDbType.VarWChar, 100, "acc_ca_name"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@acc_ca_shortname", System.Data.OleDb.OleDbType.VarWChar, 100, "acc_ca_shortname"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@acc_ca_type", System.Data.OleDb.OleDbType.Integer, 2, "acc_ca_type"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@acc_ca_mother", System.Data.OleDb.OleDbType.Integer, 7, "acc_ca_mother"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@acc_ca_idx", System.Data.OleDb.OleDbType.VarWChar, 70, "acc_ca_idx"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@acc_ca_active", System.Data.OleDb.OleDbType.Integer, 1, "acc_ca_active"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@acc_ca_entry_dt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "acc_ca_entry_dt"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@acc_ca_entry_by", System.Data.OleDb.OleDbType.Integer, 4, "acc_ca_entry_by"))


        dbDA = New OleDb.OleDbDataAdapter
        dbDA.UpdateCommand = dbCmdUpdate
        dbDA.InsertCommand = dbCmdInsert


        Try
            dbDA.Update(objTbl)

            acc_ca_id = objTbl.Rows(0).Item("acc_ca_id")
            Me.tblMstAccCa_temp.Clear()
            Me.tblMstAccCa_temp.Merge(objTbl)

        Catch ex As OleDb.OleDbException
            MessageBox.Show(ex.Message, "OLE DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return False
        End Try


        If MasterDataState = DataRowState.Added Then
            Me.tblMstAccCa.Merge(objTbl)
        ElseIf MasterDataState = DataRowState.Modified Then
            curpos = Me.BindingContext(Me.tblMstAccCa).Position
            Me.tblMstAccCa.Rows.RemoveAt(curpos)
            Me.tblMstAccCa.Merge(objTbl)
        End If

        Me.BindingContext(Me.tblMstAccCa).Position = Me.BindingContext(Me.tblMstAccCa).Count

        Return True
    End Function

    Private Function add_child() As Boolean
        Me.action = "child"
        Me.acc_ca_id = tList_mst_acc.FocusedNode("acc_ca_id").ToString
        ftabMain.SelectedIndex = 1
    End Function

    Private Function edit() As Boolean
        Me.action = "edit"
        Me.acc_ca_id = tList_mst_acc.FocusedNode("acc_ca_id").ToString
        ftabMain.SelectedIndex = 1
    End Function

#End Region

    Public Sub Form_Load(ByVal sender As Object)
        Me.clsDataFill = New clsDataFiller(DSN)
        Me.clsMstAcc = New clsMstAccCa(DSN)
        Me.clsDataFill.ComboFillacc_ca(cbParent, "acc_ca_id", "acc_ca_shortname", tblAccCa_combo, "ms_MstAcc_ca_Select", "")
        Dim objParameters As Collection = New Collection

        If Me.Browser IsNot Nothing Then
            objParameters = Me.GetParameterCollection(Me.Parameter)
            Me._CHANNEL = Me.GetValueFromParameter(objParameters, "CHANNEL")
            Me._CHANNEL_CANBE_CHANGED = False
            Me._CHANNEL_CANBE_BROWSED = False
        End If

        If (Me.Browser IsNot Nothing And MyBase.Name = _Name) Or (Me.Browser Is Nothing And Application.ProductName <> _ProductName) Then

            Me.InitLayoutUI()

            Me.BindingStop()
            Me.BindingStart()

            Me.Master_Acc_NewData()

            Me.tbtnSave.Enabled = False
            Me.tbtnDel.Enabled = False
            Me.tbtnLoad.Enabled = True

            'visible
            Me.tbtnNew.Visible = False
            Me.tbtnQuery.Visible = False
            Me.tbtnPrint.Visible = False
            Me.tbtnPrintPreview.Visible = False
            Me.tbtnNext.Visible = False
            Me.tbtnPrev.Visible = False
            Me.tbtnLast.Visible = False
            Me.tbtnFirst.Visible = False
            Me.tbtnRefresh.Visible = False
            Me.ToolStripSeparator1.Visible = False
            Me.ToolStripSeparator2.Visible = False
            Me.ToolStripSeparator3.Visible = False
            Me.ToolStripSeparator4.Visible = False
        End If
    End Sub

    Private Sub uiMstAcc_FormAfterSave(ByRef id As Object, result As uiBase.FormSaveResult) Handles Me.FormAfterSave
        tbtnDel.Enabled = True
        txtAcc_ca_Id.ReadOnly = True
    End Sub

    Private Sub uiMstAcc_FormBeforeNew() Handles Me.FormBeforeNew
        Me.tbtnDel.Enabled = False
        Me.acc_index = ""
        txtAcc_ca_Id.ReadOnly = False
    End Sub

    Private Sub uiMstAccCa_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Me.IsDevelopment = True Then Me.Form_Load(sender)
    End Sub

    Private Sub tl_mst_acc_MouseDown(sender As Object, e As MouseEventArgs) Handles tList_mst_acc.MouseDown
        Dim ht As TreeListHitInfo = tList_mst_acc.CalcHitInfo(New Point(e.X, e.Y))
        tList_mst_acc.FocusedNode = ht.Node
    End Sub

    Private Sub treeCompany_ShowTreeListMenu(ByVal sender As System.Object, ByVal e As DevExpress.XtraTreeList.PopupMenuShowingEventArgs) Handles tList_mst_acc.PopupMenuShowing
        e.Menu.Items.Add(New DevExpress.Utils.Menu.DXMenuItem("Add Root", AddressOf btnNew_Click))
        e.Menu.Items.Add(New DevExpress.Utils.Menu.DXMenuItem("Add Child", AddressOf add_child))
        e.Menu.Items.Add(New DevExpress.Utils.Menu.DXMenuItem("Edit", AddressOf edit))
    End Sub

    Private Sub ftabMain_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ftabMain.SelectedIndexChanged
        Select Case ftabMain.SelectedIndex
            Case 0
                Me.tbtnSave.Enabled = False
                Me.tbtnDel.Enabled = False
                Me.tbtnLoad.Enabled = True
                Me.ftabMain.TabPages.Item(0).BackColor = Color.White
                Me.ftabMain.TabPages.Item(1).BackColor = Color.Gainsboro

            Case 1
                Me.tbtnSave.Enabled = True
                Me.tbtnDel.Enabled = True
                Me.tbtnLoad.Enabled = False
                Me.ftabMain.TabPages.Item(0).BackColor = Color.Gainsboro
                Me.ftabMain.TabPages.Item(1).BackColor = Color.White

                If Me.tList_mst_acc.FocusedNode IsNot Nothing Then
                    Me.Master_Acc_OpenRow(tList_mst_acc.FocusedNode("acc_ca_id").ToString)
                Else
                    Me.Master_Acc_NewData()
                End If


        End Select
    End Sub

    Private Sub txtAcc_ca_Id_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAcc_ca_Id.KeyPress
        Dim tombol As Integer = Asc(e.KeyChar)
        If Not (((tombol >= 48) And (tombol <= 57)) Or (tombol = 8)) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtAcc_TextChanged(sender As Object, e As EventArgs) Handles txtAcc_ca_Id.TextChanged
        If acc_index <> "" Then
            txtIndex.Text = acc_index + txtAcc_ca_Id.Text
        End If
    End Sub

    Private Function Master_AccCa_OpenRowAddChild(ByVal acc_ca_id As String) As Boolean
        tbtnDel.Enabled = False
        txtAcc_ca_Id.ReadOnly = False
        Me.BindingContext(Me.tblMstAccCa_temp).AddNew()
        BindingStart()
        cbParent.SelectedValue = acc_ca_id
        Me.clsMstAcc.Retrieve(Me.tblMstAcc_edit, "acc_ca_id = '" + acc_ca_id + "'")
        Me.acc_index = IIf(Me.tblMstAcc_edit.Rows(0).Item("acc_ca_mother").ToString = "", Me.tblMstAcc_edit.Rows(0).Item("acc_ca_id").ToString, Me.tblMstAcc_edit.Rows(0).Item("acc_ca_idx").ToString)
    End Function
    
    Private Function Master_AccCa_OpenRowEdit(ByVal acc_ca_id As String) As Boolean
        Me.tbtnDel.Enabled = True
        txtAcc_ca_Id.ReadOnly = True
        Me.clsMstAcc.Retrieve(Me.tblMstAccCa_temp, "acc_ca_id = '" + acc_ca_id + "'")
        BindingStart()
        If Me.tblMstAccCa_temp.Rows(0).Item("acc_ca_idx").ToString = "" Then
            cbParent.SelectedIndex = -1
            Me.acc_index = ""
        Else
            Me.acc_index = Strings.Left(Me.tblMstAccCa_temp.Rows(0).Item("acc_ca_idx"), Len(Me.tblMstAccCa_temp.Rows(0).Item("acc_ca_idx")) - Len(Trim(txtAcc_ca_Id.Text)))
        End If
    End Function

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Try
            Dim saveFileDialog1 As New SaveFileDialog()
            saveFileDialog1.Filter = "Excel Files (*.xlsx*)|*.xlsx"

            If saveFileDialog1.ShowDialog() = DialogResult.OK Then
                Me.tList_mst_acc.ExportToXlsx(saveFileDialog1.FileName)
            End If

            MsgBox("Export data done !")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class