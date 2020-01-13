Public Class uiMstCaReport

    Private Const mUiName As String = "uiMstCaReport"
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

    Private tbl_MstCaReport As DataTable = clsDataset.CreateTblMstCa()
    Private tbl_MstCaReport_Temp As DataTable = clsDataset.CreateTblMstCa()
    Private tbl_MstCaReport_detil As DataTable = clsDataset.CreateTblMstCa_detil()
    Private tbl_MstAcc_ca As DataTable = clsDataset.CreateTblMstAccCa()
    Private tbl_MstCaReportType As DataTable = clsDataset.CreateTblMstCaType()
    Private tbl_MstChannelSearch As DataTable = clsDataset.CreateTblMstChannelCombo()
    Private code_temp As String = ""
    Private row_temp As String = ""


#Region " Window Parameter "
    ' TODO: Buat variabel untuk menampung parameter window 
    Private _CHANNEL As String = "TAS"
    Private _CHANNEL_CANBE_CHANGED As Boolean = False
    Private _CHANNEL_CANBE_BROWSED As Boolean = False
#End Region

#Region " Window Dataset "


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

    Public Overrides Function btnNew_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        If Me.ftabMain.SelectedIndex = 0 Then
            Me.ftabMain.SelectedIndex = 1
        End If
        Me.uiMstCaReport_NewData()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnNew_Click()
    End Function

    Public Overrides Function btnLoad_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiMstCaReport_Retrieve()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnLoad_Click()
    End Function

    Public Overrides Function btnSave_Click() As Boolean
        If Me.uiMstCaReport_FormError() Then
            Return True
        End If
        Me.Cursor = Cursors.WaitCursor
        Me.uiMstCaReport_Save()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnSave_Click()
    End Function


    Public Overrides Function btnPrint_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiMstCaReport_Print()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnPrint_Click()
    End Function

    Public Overrides Function btnDel_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        'Me.uiMstCaReport_Delete()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnDel_Click()
    End Function

    Public Overrides Function btnFirst_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiMstCaReport_First()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnFirst_Click()
    End Function

    Public Overrides Function btnPrev_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiMstCaReport_Prev()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnPrev_Click()
    End Function

    Public Overrides Function btnNext_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiMstCaReport_Next()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnNext_Click()
    End Function

    Public Overrides Function btnLast_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiMstCaReport_Last()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnLast_Click()
    End Function


#End Region

#Region " Layout & Init UI "

    Private Function FormatDgvMstCa(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        ' Format DgvMstGl Columns 
        Dim cCode As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRow As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cSeq As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cDescr As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRemark As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cFbold As System.Windows.Forms.DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Dim cFline As System.Windows.Forms.DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Dim cFitalic As System.Windows.Forms.DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Dim cFprint As System.Windows.Forms.DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Dim cFsaldo As System.Windows.Forms.DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Dim cCode_group As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cChannel As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn

        cCode.Name = "code"
        cCode.HeaderText = "Code"
        cCode.DataPropertyName = "code"
        cCode.Width = 35
        cCode.Visible = True
        cCode.ReadOnly = False

        cRow.Name = "row"
        cRow.HeaderText = "Row"
        cRow.DataPropertyName = "row"
        cRow.Width = 35
        cRow.Visible = True
        cRow.ReadOnly = False

        cSeq.Name = "seq"
        cSeq.HeaderText = "Seq."
        cSeq.DataPropertyName = "seq"
        cSeq.Width = 35
        cSeq.Visible = False
        cSeq.ReadOnly = False

        cDescr.Name = "descr"
        cDescr.HeaderText = "Descr"
        cDescr.DataPropertyName = "descr"
        cDescr.Width = 350
        cDescr.Visible = True
        cDescr.ReadOnly = False

        cRemark.Name = "remark"
        cRemark.HeaderText = "Remark"
        cRemark.DataPropertyName = "remark"
        cRemark.Width = 50
        cRemark.Visible = True
        cRemark.ReadOnly = False

        cFbold.Name = "fbold"
        cFbold.HeaderText = "Bold"
        cFbold.DataPropertyName = "fbold"
        cFbold.Width = 35
        cFbold.Visible = True
        cFbold.ReadOnly = False

        cFline.Name = "fline"
        cFline.HeaderText = "Line"
        cFline.DataPropertyName = "fline"
        cFline.Width = 35
        cFline.Visible = True
        cFline.ReadOnly = False

        cFitalic.Name = "fitalic"
        cFitalic.HeaderText = "Italic"
        cFitalic.DataPropertyName = "fitalic"
        cFitalic.Width = 35
        cFitalic.Visible = True
        cFitalic.ReadOnly = False

        cFprint.Name = "fprint"
        cFprint.HeaderText = "Print"
        cFprint.DataPropertyName = "fprint"
        cFprint.Width = 35
        cFprint.Visible = True
        cFprint.ReadOnly = False

        cFsaldo.Name = "fsaldo"
        cFsaldo.HeaderText = "Saldo"
        cFsaldo.DataPropertyName = "fsaldo"
        cFsaldo.Width = 35
        cFsaldo.Visible = True
        cFsaldo.ReadOnly = False

        cCode_group.Name = "code_group"
        cCode_group.HeaderText = "Group Code"
        cCode_group.DataPropertyName = "code_group"
        cCode_group.Width = 90
        cCode_group.Visible = True
        cCode_group.ReadOnly = False

        cChannel.Name = "channel_id"
        cChannel.HeaderText = "Channel ID"
        cChannel.DataPropertyName = "channel_id"
        cChannel.Width = 35
        cChannel.Visible = False
        cChannel.ReadOnly = False

        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
        {cChannel, cCode, cRow, cSeq, cDescr, cRemark, cFbold, cFline, cFitalic, cFprint, cFsaldo, cCode_group})



        ' DgvMstGl Behaviours: 
        objDgv.AllowUserToAddRows = False
        objDgv.AllowUserToDeleteRows = False
        objDgv.AllowUserToResizeRows = False
        objDgv.AllowUserToOrderColumns = False
        objDgv.ReadOnly = False
        objDgv.SelectionMode = DataGridViewSelectionMode.CellSelect

    End Function

    Private Function FormatDgvMstCa_detil(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        ' formating DgvMstGl detil
        Dim cCode As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRow As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cLine As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cDescr As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAc_start As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAc_end As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cSign As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cYtd As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAC_start_button As System.Windows.Forms.DataGridViewButtonColumn = New System.Windows.Forms.DataGridViewButtonColumn
        Dim cAC_end_button As System.Windows.Forms.DataGridViewButtonColumn = New System.Windows.Forms.DataGridViewButtonColumn

        cCode.Name = "code"
        cCode.HeaderText = "Code"
        cCode.DataPropertyName = "code"
        cCode.Width = 35
        cCode.Visible = True
        cCode.ReadOnly = False
        cCode.Frozen = True

        cRow.Name = "row"
        cRow.HeaderText = "Row"
        cRow.DataPropertyName = "row"
        cRow.Width = 35
        cRow.Visible = True
        cRow.ReadOnly = False
        cRow.Frozen = True

        cLine.Name = "line"
        cLine.HeaderText = "Line"
        cLine.DataPropertyName = "line"
        cLine.Width = 35
        cLine.Visible = True
        cLine.ReadOnly = False
        cLine.Frozen = True

        cDescr.Name = "descr"
        cDescr.HeaderText = "Descr"
        cDescr.DataPropertyName = "descr"
        cDescr.Width = 200
        cDescr.Visible = True
        cDescr.ReadOnly = False
        cDescr.Frozen = True

        cAc_start.Name = "ac_start"
        cAc_start.HeaderText = "Acc.Start"
        cAc_start.DataPropertyName = "ac_start"
        cAc_start.Width = 90
        cAc_start.Visible = True
        cAc_start.ReadOnly = False
        'cAc_start.ValueMember = "acc_id"
        'cAc_start.DisplayMember = "acc_id"
        'cAc_start.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox
        'cAc_start.DisplayStyleForCurrentCellOnly = True
        'cAc_start.AutoComplete = True
        'cAc_start.DataSource = Me.tbl_MstAcc
        cAC_start_button.Name = "ac start button"
        cAC_start_button.HeaderText = ""
        cAC_start_button.Text = "..."
        cAC_start_button.UseColumnTextForButtonValue = True
        cAC_start_button.CellTemplate.Style.BackColor = Color.LightGray
        cAC_start_button.Width = 30
        cAC_start_button.DividerWidth = 3
        cAC_start_button.Visible = True
        cAC_start_button.ReadOnly = False

        cAc_end.Name = "ac_end"
        cAc_end.HeaderText = "Acc.End"
        cAc_end.DataPropertyName = "ac_end"
        cAc_end.Width = 100
        cAc_end.Visible = 90
        cAc_end.ReadOnly = False
        'cAc_end.ValueMember = "acc_id"
        'cAc_end.DisplayMember = "acc_id"
        'cAc_end.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox
        'cAc_end.DisplayStyleForCurrentCellOnly = True
        'cAc_end.AutoComplete = True
        'cAc_end.DataSource = Me.tbl_MstAcc

        cAC_end_button.Name = "ac end button"
        cAC_end_button.HeaderText = ""
        cAC_end_button.Text = "..."
        cAC_end_button.UseColumnTextForButtonValue = True
        cAC_end_button.CellTemplate.Style.BackColor = Color.LightGray
        cAC_end_button.Width = 30
        cAC_end_button.DividerWidth = 3
        cAC_end_button.Visible = True
        cAC_end_button.ReadOnly = False

        cSign.Name = "sign"
        cSign.HeaderText = "sign"
        cSign.DataPropertyName = "sign"
        cSign.Width = 35
        cSign.Visible = True
        cSign.ReadOnly = False

        cYtd.Name = "ytd"
        cYtd.HeaderText = "ytd"
        cYtd.DataPropertyName = "ytd"
        cYtd.Width = 35
        cYtd.Visible = True
        cYtd.ReadOnly = False

        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
        {cCode, cRow, cLine, cDescr, cAc_start, cAC_start_button, cAc_end, cAC_end_button, cSign, cYtd})

        objDgv.AutoGenerateColumns = False
        objDgv.AllowUserToAddRows = False
        objDgv.AllowUserToDeleteRows = False
        ' objDgv.Columns("acc_id").Frozen = True

    End Function

    Private Function InitLayoutUI() As Boolean

        Me.ftabMain.Anchor = AnchorStyles.Bottom
        Me.ftabMain.Anchor += AnchorStyles.Top
        Me.ftabMain.Anchor += AnchorStyles.Right
        Me.ftabMain.Anchor += AnchorStyles.Left

        Me.ftabMain.TabPages.Item(1).BackColor = Color.Gainsboro
        Me.PnlDfSearch.Dock = DockStyle.Top
        Me.PnlDfSearch.Visible = True
        Me.PnlDfMain.Dock = DockStyle.Fill
        Me.DgvCaReport.Dock = DockStyle.Fill

        Me.FormatDgvMstCa(Me.DgvCaReport)
        Me.FormatDgvMstCa_detil(Me.DgvMstCaReport_detil)

    End Function

    Private Function uiMstCaReport_LoadComboBox() As Boolean

        Me.ComboFill(Me.cboSearchChannel, "channel_id", "channel_id", Me.tbl_MstChannelSearch, "ms_MstChannelCombo_Select", " channel_id = '" & Me._CHANNEL & "' ")
        Me.tbl_MstChannelSearch.DefaultView.Sort = "channel_name"
        Me.ComboFill(Me.cbo_typereport, "Code", "Name", Me.tbl_MstCaReportType, "cp_MstCaReportType_Select", "")
        Me.tbl_MstCaReportType.DefaultView.Sort = "code"
    End Function

    Private Function BindingStop() As Boolean
        'stop binding
        Me.obj_Code.DataBindings.Clear()
        Me.obj_Row.DataBindings.Clear()
        'Me.obj_Seq.DataBindings.clear()
        Me.obj_Descr.DataBindings.Clear()
        Me.obj_groupCode.DataBindings.Clear()
        Me.obj_Remark.DataBindings.Clear()
        'Me.obj_Fbold.DataBindings.clear()
        ' Me.obj_Fline.DataBindings.clear()
        ' Me.obj_Fitalic.DataBindings.clear()
        Return True
    End Function

    Private Function BindingStart() As Boolean
        'start binding
        Me.obj_Code.DataBindings.Add(New Binding("Text", Me.tbl_MstCaReport_Temp, "code", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##"))
        Me.obj_Row.DataBindings.Add(New Binding("Text", Me.tbl_MstCaReport_Temp, "row", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##"))
        ' Me.obj_Seq.DataBindings.Add(New Binding("Text", Me.tbl_MstGl_Temp, "seq", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))
        Me.obj_Descr.DataBindings.Add(New Binding("Text", Me.tbl_MstCaReport_Temp, "descr"))
        Me.obj_groupCode.DataBindings.Add(New Binding("Text", Me.tbl_MstCaReport_Temp, "code_group"))
        Me.obj_Remark.DataBindings.Add(New Binding("Text", Me.tbl_MstCaReport_Temp, "remark"))
        '  Me.obj_Fbold.DataBindings.Add(New Binding("Text", Me.tbl_MstGl_Temp, "fbold", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))
        '  Me.obj_Fline.DataBindings.Add(New Binding("Text", Me.tbl_MstGl_Temp, "fline", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))
        '  Me.obj_Fitalic.DataBindings.Add(New Binding("Text", Me.tbl_MstGl_Temp, "fitalic", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))
        Return True
    End Function

#End Region

#Region " Dialoged Control "
#End Region


#Region " User Defined Function "

    Private Function uiMstCaReport_NewData() As Boolean
        ''new data
        'RaiseEvent FormBeforeNew()

        '' TODO: Set Default Value for tbl_MstGl_Temp
        'Me.tbl_MstGl_Temp.Clear()


        '' TODO: Set Default Value for tbl_MstGl
        'Me.tbl_MstGl.Clear()
        'Me.tbl_MstGl = clsDataset.CreateTblMstGl()
        'Me.tbl_MstGl.Columns("code").DefaultValue = 0
        ''Me.tbl_MstGl.Columns("").DefaultValue = DBNull.Value
        ''Me.tbl_MstGl.Columns("").AutoIncrement = True
        ''Me.tbl_MstGl.Columns("").AutoIncrementSeed = 10
        ''Me.tbl_MstGl.Columns("").AutoIncrementStep = 10
        'Me.DgvMstGl.DataSource = Me.tbl_MstGl


        'Me.BindingContext(Me.tbl_MstGl_Temp).EndCurrentEdit()
        'Try
        '    Me.BindingContext(Me.tbl_MstGl_Temp).AddNew()
        'Catch ex As Exception
        '    MessageBox.Show(ex.Source)
        'End Try

    End Function

    Private Function uiMstCaReport_Retrieve() As Boolean
        'retrieve data
        Dim criteria As String = ""

        ' TODO: Parse Criteria using clsProc.RefParser()

        criteria = String.Format(" channel_id = '{0}' AND code='{1}'", Me.cboSearchChannel.SelectedValue, Me.cbo_typereport.SelectedValue)
        Me.tbl_MstCaReport.Clear()
        Try
            Me.DataFill(Me.tbl_MstCaReport, "cp_MstCaReport_Select", criteria)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Function

    Private Function uiMstCaReport_Save() As Boolean
        'save data
        Dim tbl_MstCaReport_Changes As DataTable
        Dim tbl_MstCaReportdetil_Changes As DataTable
        Dim success As Boolean
        Dim code As Object = New Object
        Dim row As Object = New Object
        Dim seq As Object = New Object
        Dim i As Integer = 0
        Dim MasterDataState As System.Data.DataRowState
        Dim result As FormSaveResult

        Me.Cursor = Cursors.WaitCursor
        RaiseEvent FormBeforeSave(code)
        Me.DgvCaReport.EndEdit()
        Me.BindingContext(Me.tbl_MstCaReport).EndCurrentEdit()
        tbl_MstCaReport_Changes = Me.tbl_MstCaReport.GetChanges()

        Me.DgvMstCaReport_detil.EndEdit()
        Me.BindingContext(Me.tbl_MstCaReport_detil).EndCurrentEdit()
        tbl_MstCaReportdetil_Changes = Me.tbl_MstCaReport_detil.GetChanges()

        If tbl_MstCaReport_Changes IsNot Nothing Or tbl_MstCaReportdetil_Changes IsNot Nothing Then

            Try

                MasterDataState = tbl_MstCaReport.Rows(0).RowState
                code = tbl_MstCaReport.Rows(0).Item("code")
                'row = tbl_MstGl.Rows(0).Item("row")
                ' seq = tbl_MstGl.Rows(0).Item("seq")

                If tbl_MstCaReport_Changes IsNot Nothing Then
                    success = Me.uiMstCaReport_SaveMaster(code, row, seq, tbl_MstCaReport_Changes, MasterDataState)
                    If Not success Then Throw New Exception("Error: Saving Master Data at Me.uiMstCaReport_SaveMaster(tbl_MstAcReport_Temp_Changes)")
                    Me.tbl_MstCaReport_Temp.AcceptChanges()
                End If

                If tbl_MstCaReportdetil_Changes IsNot Nothing Then
                    For i = 0 To Me.tbl_MstCaReport_detil.Rows.Count - 1
                        If Me.tbl_MstCaReport_detil.Rows(i).RowState = DataRowState.Added Then
                            Me.tbl_MstCaReport_detil.Rows(i).Item("code") = code
                            'Me.tbl_MstGl_detil.Rows(i).Item("row") = row
                        End If
                    Next
                    success = Me.uiMstCaReport_SaveDetil(code, row, tbl_MstCaReportdetil_Changes, MasterDataState)
                    If Not success Then Throw New Exception("Error: Save Detil Data at Me.uiMstCaReport_SaveDetil(tbl_MstAcReport_Changes)")
                    Me.tbl_MstCaReport_detil.AcceptChanges()
                End If

                result = FormSaveResult.SaveSuccess
                If SHOW_SAVE_CONFIRMATION Then
                    MessageBox.Show("Data Saved", mUiName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.uiMstCaReport_Retrieve()
                End If

            Catch ex As Exception
                result = FormSaveResult.SaveError
                MessageBox.Show("Data Cannot Be Saved" & vbCrLf & ex.Message, mUiName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        Else
            result = FormSaveResult.Nochanges
            If SHOW_SAVE_CONFIRMATION Then
                MessageBox.Show("All changes has been saved", mUiName, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If

        RaiseEvent FormAfterSave(code, result)
        Me.Cursor = Cursors.Arrow

    End Function

    Private Function uiMstCaReport_SaveMaster(ByRef code As Object, ByRef row As Object, ByRef seq As Object, ByVal objTbl As DataTable, ByVal MasterDataState As System.Data.DataRowState) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbCmdInsert As OleDb.OleDbCommand
        Dim dbCmdUpdate As OleDb.OleDbCommand
        'Dim dbCmdDelete As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter
        Dim curpos As Integer

        ' Save data: master_gl_report_row
        dbCmdInsert = New OleDb.OleDbCommand("cp_MstCaReport_Insert", dbConn)
        dbCmdInsert.CommandType = CommandType.StoredProcedure
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@code", System.Data.OleDb.OleDbType.Decimal, 5))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@row", System.Data.OleDb.OleDbType.Decimal, 5, "row"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@seq", System.Data.OleDb.OleDbType.Decimal, 5, "seq"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@descr", System.Data.OleDb.OleDbType.VarWChar, 100, "descr"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@remark", System.Data.OleDb.OleDbType.VarWChar, 50, "remark"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@fbold", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(1, Byte), CType(0, Byte), "fbold", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@fline", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(1, Byte), CType(0, Byte), "fline", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@fitalic", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(1, Byte), CType(0, Byte), "fitalic", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@fprint", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(1, Byte), CType(0, Byte), "fprint", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@fsaldo", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(1, Byte), CType(0, Byte), "fsaldo", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@code_group", System.Data.OleDb.OleDbType.VarWChar, 9, "code_group"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 4, "channel_id"))
        dbCmdInsert.Parameters("@code").Value = code
        'dbCmdInsert.Parameters("@row").Value = row 
        'dbCmdInsert.Parameters("@seq").Value = seq

        dbCmdUpdate = New OleDb.OleDbCommand("cp_MstCaReport_Update", dbConn)
        dbCmdUpdate.CommandType = CommandType.StoredProcedure
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@code", System.Data.OleDb.OleDbType.Decimal, 5))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@row", System.Data.OleDb.OleDbType.Decimal, 5, "row"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@seq", System.Data.OleDb.OleDbType.Decimal, 9, "seq"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@descr", System.Data.OleDb.OleDbType.VarWChar, 100, "descr"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@remark", System.Data.OleDb.OleDbType.VarWChar, 50, "remark"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@fbold", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(1, Byte), CType(0, Byte), "fbold", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@fline", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(1, Byte), CType(0, Byte), "fline", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@fitalic", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(1, Byte), CType(0, Byte), "fitalic", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@fprint", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(1, Byte), CType(0, Byte), "fprint", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@fsaldo", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(1, Byte), CType(0, Byte), "fsaldo", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@code_group", System.Data.OleDb.OleDbType.VarWChar, 50, "code_group"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 4, "channel_id"))
        dbCmdUpdate.Parameters("@code").Value = code
        'dbCmdUpdate.Parameters("@row").Value = row
        'dbCmdUpdate.Parameters("@seq").Value = seq

        'dbCmdDelete = New OleDb.OleDbCommand("cp_MstGl_Delete", dbConn)
        'dbCmdDelete.CommandType = CommandType.StoredProcedure
        'dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@code", System.Data.OleDb.OleDbType.Decimal, 5))
        'dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@row", System.Data.OleDb.OleDbType.Decimal, 5, "row"))
        'dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@seq", System.Data.OleDb.OleDbType.Decimal, 9, "seq"))
        'dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@descr", System.Data.OleDb.OleDbType.VarWChar, 100, "descr"))
        'dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@remark", System.Data.OleDb.OleDbType.VarWChar, 50, "remark"))
        'dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@fbold", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(1, Byte), CType(0, Byte), "fbold", System.Data.DataRowVersion.Current, Nothing))
        'dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@fline", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(1, Byte), CType(0, Byte), "fline", System.Data.DataRowVersion.Current, Nothing))
        'dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@fitalic", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(1, Byte), CType(0, Byte), "fitalic", System.Data.DataRowVersion.Current, Nothing))
        'dbCmdDelete.Parameters("@code").Value = code
        'dbCmdDelete.Parameters("@row").Value = row
        'dbCmdDelete.Parameters("@seq").Value = seq

        dbDA = New OleDb.OleDbDataAdapter
        dbDA.UpdateCommand = dbCmdUpdate
        dbDA.InsertCommand = dbCmdInsert
        'dbDA.DeleteCommand = dbCmdDelete


        Dim cookie As Byte() = Nothing

        Try
            dbConn.Open()
            clsApplicationRole.SetAppRole(dbConn, cookie)
            dbDA.Update(objTbl)

            code = objTbl.Rows(0).Item("code")
            Me.tbl_MstCaReport.Clear()
            Me.tbl_MstCaReport.Merge(objTbl)

        Catch ex As Data.OleDb.OleDbException
            MessageBox.Show(ex.Message, "OLE DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return False
        Finally
            clsApplicationRole.UnsetAppRole(dbConn, cookie)
            dbConn.Close()
        End Try


        If MasterDataState = DataRowState.Added Then
            Me.tbl_MstCaReport.Merge(objTbl)
        ElseIf MasterDataState = DataRowState.Modified Then
            curpos = Me.BindingContext(Me.tbl_MstCaReport).Position
            Me.tbl_MstCaReport.Rows.RemoveAt(curpos)
            Me.tbl_MstCaReport.Merge(objTbl)
        End If

        Me.BindingContext(Me.tbl_MstCaReport).Position = Me.BindingContext(Me.tbl_MstCaReport).Count

        Return True
    End Function

    Private Function uiMstCaReport_SaveDetil(ByRef code As Object, ByRef row As Object, ByVal objTbl As DataTable, ByVal MasterDataState As System.Data.DataRowState) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbCmdInsert As OleDb.OleDbCommand
        Dim dbCmdUpdate As OleDb.OleDbCommand
        'Dim dbCmdDelete As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter
        Dim curpos As Integer

        dbCmdInsert = New OleDb.OleDbCommand("cp_MstCaReportdetil_Insert", dbConn)
        dbCmdInsert.CommandType = CommandType.StoredProcedure
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@code", System.Data.OleDb.OleDbType.Decimal, 5))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@row", System.Data.OleDb.OleDbType.Decimal, 5, "row"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@line", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(4, Byte), CType(0, Byte), "line", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@descr", System.Data.OleDb.OleDbType.VarWChar, 50, "descr"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@ac_start", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(7, Byte), CType(0, Byte), "ac_start", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@ac_end", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(7, Byte), CType(0, Byte), "ac_end", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@sign", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(1, Byte), CType(0, Byte), "sign", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@ytd", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(1, Byte), CType(0, Byte), "ytd", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters("@code").Value = code

        dbCmdUpdate = New OleDb.OleDbCommand("cp_MstCaReportDetil_Update", dbConn)
        dbCmdUpdate.CommandType = CommandType.StoredProcedure
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@code", System.Data.OleDb.OleDbType.Decimal, 5))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@row", System.Data.OleDb.OleDbType.Decimal, 5, "row"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@line", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(4, Byte), CType(0, Byte), "line", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@descr", System.Data.OleDb.OleDbType.VarWChar, 50, "descr"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@ac_start", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(7, Byte), CType(0, Byte), "ac_start", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@ac_end", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(7, Byte), CType(0, Byte), "ac_end", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@sign", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(1, Byte), CType(0, Byte), "sign", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@ytd", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(1, Byte), CType(0, Byte), "ytd", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters("@code").Value = code

        dbDA = New OleDb.OleDbDataAdapter
        dbDA.UpdateCommand = dbCmdUpdate
        dbDA.InsertCommand = dbCmdInsert

        Dim cookie As Byte() = Nothing

        Try
            dbConn.Open()
            clsApplicationRole.SetAppRole(dbConn, cookie)
            dbDA.Update(objTbl)

        Catch ex As Data.OleDb.OleDbException
            MessageBox.Show(ex.Message, "OLE DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return False
        Finally
            clsApplicationRole.UnsetAppRole(dbConn, cookie)
            dbConn.Close()
        End Try

        If MasterDataState = DataRowState.Added Then
            Me.tbl_MstCaReport_detil.Merge(objTbl)
        ElseIf MasterDataState = DataRowState.Modified Then
            curpos = Me.BindingContext(Me.tbl_MstCaReport_detil).Position
            Me.tbl_MstCaReport_detil.Rows.RemoveAt(curpos)
            Me.tbl_MstCaReport_detil.Merge(objTbl)
        End If

        Me.BindingContext(Me.tbl_MstCaReport).Position = Me.BindingContext(Me.tbl_MstCaReport).Count
        Return True
    End Function

    Private Function uiMstCaReport_Print() As Boolean
        'print data
    End Function

    'Private Function uiMstCaReport_Delete() As Boolean
    '    Dim res As String = ""
    '    Dim code As Object = New Object

    '    Me.Cursor = Cursors.WaitCursor
    '    RaiseEvent FormBeforeDelete(code)

    '    Me.Cursor = Cursors.WaitCursor
    '    If Me.DgvMstGl_detil.CurrentRow IsNot Nothing Then

    '        res = MessageBox.Show("Are you sure want to delete data ?", mUiName, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
    '        If res = DialogResult.Yes Then
    '            Me.uiMstCaReport_DeleteRow(Me.DgvMstGl_detil.CurrentRow.Index)
    '        End If

    '    End If

    '    RaiseEvent FormAfterDelete(code)
    '    Me.Cursor = Cursors.Arrow

    'End Function


    Private Function uiMstCaReport_OpenRow(ByVal rowIndex As Integer) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim code As String
        Dim row As String

        code = Me.DgvCaReport.Rows(rowIndex).Cells("code").Value
        row = Me.DgvCaReport.Rows(rowIndex).Cells("row").Value

        Me.Cursor = Cursors.WaitCursor
        RaiseEvent FormBeforeOpenRow(code)


        Dim cookie As Byte() = Nothing

        Try
            dbConn.Open()
            clsApplicationRole.SetAppRole(dbConn, cookie)
            Me.uiMstCaReport_OpenRowMaster(code, row, dbConn)
            Me.uiMstCaReport_OpenRowDetil(code, row, dbConn)
        Catch ex As Exception
            MessageBox.Show(ex.Message, mUiName & ": uiMstCaReport_OpenRow()", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            clsApplicationRole.UnsetAppRole(dbConn, cookie)
            dbConn.Close()
        End Try

        RaiseEvent FormAfterOpenRow(code)
        Me.Cursor = Cursors.Arrow
        Return True

    End Function

    Private Function uiMstCaReport_OpenRowMaster(ByVal code As String, ByVal row As String, ByVal dbConn As OleDb.OleDbConnection) As Boolean
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        dbCmd = New OleDb.OleDbCommand("cp_MstCaReport_Select", dbConn)
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@Criteria").Value = String.Format("code='{0}' and row ='{1}'", code, row)
        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)
        Me.tbl_MstCaReport_Temp.Clear()

        Try
            Me.BindingStop()
            dbDA.Fill(Me.tbl_MstCaReport_Temp)
            Me.BindingStart()
        Catch ex As Exception
            Throw New Exception(mUiName & ": uiMstCaReport_OpenRowMaster()" & vbCrLf & ex.Message)
        End Try

    End Function

    Private Function uiMstCaReport_OpenRowDetil(ByVal code As String, ByVal row As String, ByVal dbConn As OleDb.OleDbConnection) As Boolean
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        dbCmd = New OleDb.OleDbCommand("cp_MstCaReportDetil_Select", dbConn)
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@Criteria").Value = String.Format("code='{0}' and row ='{1}'", code, row)
        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)
        Me.tbl_MstCaReport_detil.Clear()

        'Me.tbl_MstGl_detil = clsDataset.CreateTblMstGl_detil()
        Me.tbl_MstCaReport_detil.Columns("line").DefaultValue = DBNull.Value
        Me.tbl_MstCaReport_detil.Columns("line").AutoIncrement = True
        Me.tbl_MstCaReport_detil.Columns("line").AutoIncrementSeed = 10
        Me.tbl_MstCaReport_detil.Columns("line").AutoIncrementStep = 10

        Me.tbl_MstCaReport_detil.Columns("code").DefaultValue = code
        Me.tbl_MstCaReport_detil.Columns("row").DefaultValue = row
        Me.tbl_MstCaReport_detil.Columns("sign").DefaultValue = 1
        Me.tbl_MstCaReport_detil.Columns("ytd").DefaultValue = 1
        'Me.code_temp = code
        'Me.row_temp = row


        Try
            dbDA.Fill(Me.tbl_MstCaReport_detil)
            Me.DgvMstCaReport_detil.DataSource = Me.tbl_MstCaReport_detil
        Catch ex As Exception
            Throw New Exception(mUiName & ": uiMstCaReport_OpenRowDetil()" & vbCrLf & ex.Message)
        End Try

    End Function

    Private Function uiMstCaReport_First() As Boolean
        'goto first record found
        Dim move As Boolean
        Dim Message As String = "Data has been changed. " & vbCrLf & "Save data changes before move to first record ?"
        Dim iTab As Integer = Me.ftabMain.SelectedIndex

        If iTab = 1 Then
            If Me.DATA_ISLOCKED Then
                move = True
            Else
                move = Me.uiMstCaReport_ConfirmSaveBeforeMove(Message)
            End If
        Else
            move = True
        End If

        If move Then
            Me.DgvCaReport.CurrentCell = Me.DgvCaReport(1, 0)
            Me.uiMstCaReport_RefreshPosition()
        End If
    End Function

    Private Function uiMstCaReport_Prev() As Boolean
        'goto previous record found
        Dim move As Boolean
        Dim Message As String = "Data has been changed. " & vbCrLf & "Save data changes before move to previous record ?"
        Dim iTab As Integer = Me.ftabMain.SelectedIndex

        If iTab = 1 Then
            If Me.DATA_ISLOCKED Then
                move = True
            Else
                move = Me.uiMstCaReport_ConfirmSaveBeforeMove(Message)
            End If
        Else
            move = True
        End If

        If move Then
            If Me.DgvCaReport.CurrentCell.RowIndex > 0 Then
                Me.DgvCaReport.CurrentCell = Me.DgvCaReport(1, DgvCaReport.CurrentCell.RowIndex - 1)
                Me.uiMstCaReport_RefreshPosition()
            End If
        End If
    End Function

    Private Function uiMstCaReport_Next() As Boolean
        'goto next record found
        Dim move As Boolean
        Dim Message As String = "Data has been changed. " & vbCrLf & "Save data changes before move to next record ?"
        Dim iTab As Integer = Me.ftabMain.SelectedIndex

        If iTab = 1 Then
            If Me.DATA_ISLOCKED Then
                move = True
            Else
                move = Me.uiMstCaReport_ConfirmSaveBeforeMove(Message)
            End If
        Else
            move = True
        End If

        If move Then
            If Me.DgvCaReport.CurrentCell.RowIndex < Me.DgvCaReport.Rows.Count - 1 Then
                Me.DgvCaReport.CurrentCell = Me.DgvCaReport(1, DgvCaReport.CurrentCell.RowIndex + 1)
                Me.uiMstCaReport_RefreshPosition()
            End If
        End If
    End Function

    Private Function uiMstCaReport_Last() As Boolean
        'goto last record found
        Dim move As Boolean
        Dim Message As String = "Data has been changed. " & vbCrLf & "Save data changes before move to next record ?"
        Dim iTab As Integer = Me.ftabMain.SelectedIndex

        If iTab = 1 Then
            If Me.DATA_ISLOCKED Then
                move = True
            Else
                move = Me.uiMstCaReport_ConfirmSaveBeforeMove(Message)
            End If
        Else
            move = True
        End If

        If move Then
            Me.DgvCaReport.CurrentCell = Me.DgvCaReport(1, Me.DgvCaReport.Rows.Count - 1)
            Me.uiMstCaReport_RefreshPosition()
        End If
    End Function

    Private Function uiMstCaReport_RefreshPosition() As Boolean
        'refresh position
        Dim iTab As Integer = Me.ftabMain.SelectedIndex
        If iTab = 1 Then uiMstCaReport_OpenRow(Me.DgvCaReport.CurrentRow.Index)
    End Function

    Private Function uiMstCaReport_ConfirmSaveBeforeMove(ByVal Message As String) As Boolean
        'confirm saving data changes before move
        Dim tbl_MstGl_Temp_Changes As DataTable
        Dim tbl_MstGldetil_Changes As DataTable
        Dim res As System.Windows.Forms.DialogResult
        Dim success As Boolean
        Dim i As Integer = 0
        Dim MasterDataState As System.Data.DataRowState
        Dim code As Object = New Object
        Dim row As Object = New Object
        Dim move As Boolean = False
        Dim result As FormSaveResult


        If Me.DgvCaReport.CurrentCell IsNot Nothing Then

            Me.BindingContext(Me.tbl_MstCaReport_Temp).EndCurrentEdit()
            tbl_MstGl_Temp_Changes = Me.tbl_MstCaReport_Temp.GetChanges()

            Me.DgvCaReport.EndEdit()
            Me.BindingContext(Me.tbl_MstCaReport_detil).EndCurrentEdit()
            tbl_MstGldetil_Changes = Me.tbl_MstCaReport_detil.GetChanges()

            If tbl_MstGl_Temp_Changes IsNot Nothing Or tbl_MstGldetil_Changes IsNot Nothing Then

                res = MessageBox.Show(Message, mUiName, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                Select Case res
                    Case DialogResult.Yes

                        RaiseEvent FormBeforeSave(code)

                        Try

                            'If tbl_MstGl_Temp_Changes IsNot Nothing Then
                            '    success = Me.uiMstCaReport_SaveMaster(code, tbl_MstGl_Temp_Changes, MasterDataState)
                            '    If Not success Then Throw New Exception("Cannot Save Master Data")
                            '    Me.tbl_MstGl_Temp.AcceptChanges()
                            'End If

                            If tbl_MstGldetil_Changes IsNot Nothing Then
                                For i = 0 To Me.tbl_MstCaReport_detil.Rows.Count - 1
                                    If Me.tbl_MstCaReport_detil.Rows(i).RowState = DataRowState.Added Then
                                        Me.tbl_MstCaReport_detil.Rows(i).Item("code") = code
                                        Me.tbl_MstCaReport_detil.Rows(i).Item("row") = row
                                    End If
                                Next
                                success = Me.uiMstCaReport_SaveDetil(code, row, tbl_MstGldetil_Changes, MasterDataState)
                                If Not success Then Throw New Exception("Cannot Save Detil Data")
                                Me.tbl_MstCaReport.AcceptChanges()
                            End If

                            result = FormSaveResult.SaveSuccess
                            If SHOW_SAVE_CONFIRMATION Then
                                MessageBox.Show("Data Saved", mUiName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                            End If

                        Catch ex As Exception
                            result = FormSaveResult.SaveError
                            MessageBox.Show(ex.Message & vbCrLf & "Data Cannot Be Saved", mUiName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try

                        RaiseEvent FormAfterSave(code, result)

                    Case DialogResult.No
                        move = True
                    Case DialogResult.Cancel
                        move = False
                End Select
            Else
                move = True
            End If

        End If

        Return move

    End Function

    Private Function uiMstCaReport_FormError() As Boolean
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

#End Region

    Private Sub uiMstCaReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Me.IsDevelopment = True Then Me.Form_Load(sender)
    End Sub

    Public Sub Form_Load(ByVal sender As Object)
        Dim objParameters As Collection = New Collection


        'TODO: - Extract Parameter
        '      - Assign parameter
        If Me.Browser IsNot Nothing Then
            objParameters = Me.GetParameterCollection(Me.Parameter)
        End If

        Me.InitLayoutUI()

        Me.DgvCaReport.DataSource = Me.tbl_MstCaReport
        If (Me.Browser IsNot Nothing And MyBase.Name = _Name) Or (Me.Browser Is Nothing And Application.ProductName <> _ProductName) Then
            'Fill Combobox
            'dan fungsi2 startup lainnya....
            Me.uiMstCaReport_LoadComboBox()
            Me.cboSearchChannel.Enabled = Me._CHANNEL_CANBE_BROWSED
            Me.cboSearchChannel.SelectedValue = Me._CHANNEL
            Me.DataFillForCombo("acc_ca_id", "acc_ca_name", Me.tbl_MstAcc_ca, "ms_MstAcc_ca_Select", " acc_ca_active = 1 ")
            Me.tbl_MstAcc_ca.DefaultView.Sort = "acc_ca_name"
        End If

        Me.BindingStop()
        Me.BindingStart()

        Me.uiMstCaReport_NewData()
        Me.tbtnNew.Enabled = False
        Me.tbtnSave.Enabled = True
        Me.tbtnDel.Enabled = False
        Me.tbtnLoad.Enabled = True
        Me.tbtnQuery.Enabled = True
        Me.tbtnPrint.Visible = False
        Me.tbtnPrintPreview.Visible = False
        Me.tbtnNew.Visible = False
        Me.tbtnPrintPreview.Visible = False
        Me.tbtnDel.Visible = False
        Me.ToolStripSeparator1.Visible = False
        Me.ToolStripSeparator2.Visible = False
        Me.ToolStripSeparator4.Visible = False
    End Sub

    Private Sub ftabMain_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ftabMain.SelectedIndexChanged

        Select Case ftabMain.SelectedIndex
            Case 0
                Me.tbtnSave.Enabled = True
                Me.tbtnDel.Enabled = False
                Me.tbtnLoad.Enabled = True
                Me.tbtnQuery.Enabled = True
                Me.btn_add.Visible = True
                Me.btn_del.Visible = True
                Me.btn_adddetail.Visible = False
                Me.btn_deldetail.Visible = False
                Me.ftabMain.TabPages.Item(0).BackColor = Color.White
                Me.ftabMain.TabPages.Item(1).BackColor = Color.Gainsboro

            Case 1
                Me.tbtnSave.Enabled = True
                Me.tbtnDel.Enabled = False
                Me.tbtnLoad.Enabled = False
                Me.tbtnQuery.Enabled = False
                Me.btn_add.Visible = False
                Me.btn_del.Visible = False
                Me.btn_adddetail.Visible = True
                Me.btn_deldetail.Visible = True
                Me.ftabMain.TabPages.Item(0).BackColor = Color.Gainsboro
                Me.ftabMain.TabPages.Item(1).BackColor = Color.White

                If Me.DgvCaReport.CurrentRow IsNot Nothing Then
                    Me.uiMstCaReport_OpenRow(Me.DgvCaReport.CurrentRow.Index)
                Else
                    Me.uiMstCaReport_NewData()
                End If


        End Select
    End Sub

    Private Sub DgvMstGl_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvCaReport.CellDoubleClick
        'If e.ColumnIndex < 0 Or e.RowIndex < 0 Then
        '    Exit Sub
        'End If
        'If Me.DgvMstGl.CurrentRow IsNot Nothing Then
        '    Me.ftabMain.SelectedIndex = 1
        'End If
    End Sub

    Private Sub DgvMstGl_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DgvCaReport.CellFormatting
        'System.Drawing.FontStyle.Underline), System.Drawing.FontStyle
        Dim objRow As System.Windows.Forms.DataGridViewRow = DgvCaReport.Rows(e.RowIndex)
        Dim fbold_fline_fitalic As New System.Drawing.Font("Microsoft Sans Serif", 8.25, CType(((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic) _
                       ), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Dim fbold_fline As New System.Drawing.Font("Microsoft Sans Serif", 8.25, CType(((System.Drawing.FontStyle.Bold) _
                        ), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Dim fbold As New System.Drawing.Font("Microsoft Sans Serif", 8.25, CType(((System.Drawing.FontStyle.Bold) _
                        ), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Dim fline As New System.Drawing.Font("Microsoft Sans Serif", 8.25, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Dim fitalic As New System.Drawing.Font("Microsoft Sans Serif", 8.25, CType(( _
                             System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Dim fbold_fitalic As New System.Drawing.Font("Microsoft Sans Serif", 8.25, CType(((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic) _
                              ), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Dim fline_fitalic As New System.Drawing.Font("Microsoft Sans Serif", 8.25, CType(((System.Drawing.FontStyle.Italic) _
                                     ), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))

        If objRow.Cells("fbold").Value = 1 And objRow.Cells("fline").Value = 1 And objRow.Cells("fitalic").Value = 1 Then
            objRow.DefaultCellStyle.Font = fbold_fline_fitalic
        ElseIf objRow.Cells("fbold").Value = 1 And objRow.Cells("fline").Value = 1 And objRow.Cells("fitalic").Value = 0 Then
            objRow.DefaultCellStyle.Font = fbold_fline
        ElseIf objRow.Cells("fbold").Value = 1 And objRow.Cells("fline").Value = 0 And objRow.Cells("fitalic").Value = 0 Then
            objRow.DefaultCellStyle.Font = fbold
        ElseIf objRow.Cells("fline").Value = 1 And objRow.Cells("fbold").Value = 0 And objRow.Cells("fitalic").Value = 0 Then
            objRow.DefaultCellStyle.Font = fline
        ElseIf objRow.Cells("fitalic").Value = 1 And objRow.Cells("fline").Value = 0 And objRow.Cells("fbold").Value = 0 Then
            objRow.DefaultCellStyle.Font = fitalic
        ElseIf objRow.Cells("fbold").Value = 1 And objRow.Cells("fline").Value = 0 And objRow.Cells("fitalic").Value = 1 Then
            objRow.DefaultCellStyle.Font = fbold_fitalic
        ElseIf objRow.Cells("fline").Value = 1 And objRow.Cells("fbold").Value = 0 And objRow.Cells("fitalic").Value = 1 Then
            objRow.DefaultCellStyle.Font = fline_fitalic
        End If
    End Sub

    Private Sub btn_add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_add.Click
        If Me.DgvCaReport.RowCount > 0 Then
            RaiseEvent FormBeforeNew()

            ' TODO: Set Default Value for tbl_MstGl_Temp
            ' Me.tbl_MstGl_Temp.Clear()


            ' TODO: Set Default Value for tbl_MstGl
            'Me.tbl_MstGl.Clear()
            'Me.tbl_MstGl = clsDataset.CreateTblMstGl()
            Me.tbl_MstCaReport.Columns("code").DefaultValue = Me.DgvCaReport.Rows(0).Cells("code").Value
            Me.tbl_MstCaReport.Columns("channel_id").DefaultValue = Me.DgvCaReport.Rows(0).Cells("channel_id").Value
            'Me.tbl_MstGl.Columns("row").DefaultValue = Me.DgvMstGl.Rows(Me.DgvMstGl.RowCount - 1).Cells("row").Value
            'Me.tbl_MstGl.Columns("row").AutoIncrement = True
            'Me.tbl_MstGl.Columns("row").AutoIncrementSeed = 1
            '  'Me.tbl_MstGl.Columns("row").AutoIncrementStep = 1
            '  Me.DgvMstGl.DataSource = Me.tbl_MstGl


            'Me.BindingContext(Me.tbl_MstGl).EndCurrentEdit()
            'Try
            '    Me.BindingContext(Me.tbl_MstGl).AddNew()
            'Catch ex As Exception
            '    MessageBox.Show(ex.Source)
            'End Try

            Dim dv As New DataView
            Dim tbl_MstCa_cache As DataTable = clsDataset.CreateTblMstCa

            tbl_MstCa_cache.Clear()
            tbl_MstCa_cache = Me.tbl_MstCaReport.Copy
            dv = tbl_MstCa_cache.DefaultView
            dv.Sort = "row DESC"


            Me.tbl_MstCaReport.Rows.Add()
            Me.tbl_MstCaReport.Rows(Me.tbl_MstCaReport.Rows.Count - 1).Item("row") = dv.Item(0).Item("row") + 1
            Me.tbl_MstCaReport.Rows(Me.tbl_MstCaReport.Rows.Count - 1).Item("seq") = dv.Item(0).Item("row") + 1

            Me.DgvCaReport.DataSource = Me.tbl_MstCaReport
            For Each dgvCol As DataGridViewColumn In Me.DgvCaReport.Columns

                dgvCol.SortMode = DataGridViewColumnSortMode.NotSortable

            Next
            DgvCaReport.Rows(DgvCaReport.Rows.Count - 1).Cells(2).Selected = True
        End If
    End Sub

    Private Sub btn_del_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_del.Click
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbTrans As OleDb.OleDbTransaction
        Dim res As String = ""
        Dim code As Object = New Object

        Me.Cursor = Cursors.WaitCursor
        RaiseEvent FormBeforeDelete(code)

        Me.Cursor = Cursors.WaitCursor
        If Me.DgvCaReport.CurrentRow IsNot Nothing Then

            res = MessageBox.Show("Are you sure want to delete data and detail data ?", mUiName, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            Dim cookie As Byte() = Nothing

            If res = DialogResult.Yes Then
                dbConn.Open()
                dbTrans = dbConn.BeginTransaction()
                clsApplicationRole.SetAppRole(dbConn, dbTrans, cookie)
                Try
                    Me.uiMstCaReport_DeleteRow(Me.DgvCaReport.CurrentRow.Index, dbConn, dbTrans)
                    dbTrans.Commit()
                Catch ex As Data.OleDb.OleDbException
                    dbTrans.Rollback()
                    MessageBox.Show(ex.Message, "OLE DB Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "OLE DB Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    dbTrans.Rollback()
                Finally
                    clsApplicationRole.UnsetAppRole(dbConn, dbTrans, cookie)
                    dbConn.Close()
                End Try
            End If
        End If

        RaiseEvent FormAfterDelete(code)
        Me.Cursor = Cursors.Arrow

    End Sub

    Private Function uiMstCaReport_DeleteRow(ByVal rowIndex As Integer, ByVal dbconn As OleDb.OleDbConnection, ByVal dbtrans As OleDb.OleDbTransaction) As Boolean
        Dim code, row, seq As String
        Dim NewRowIndex As Integer

        code = Me.DgvCaReport.Rows(rowIndex).Cells("code").Value
        row = Me.DgvCaReport.Rows(rowIndex).Cells("row").Value
        seq = Me.DgvCaReport.Rows(rowIndex).Cells("seq").Value

        Try

            uiMstCaHeader_Delete(code, row, seq, dbconn, dbtrans)
            uiMstCaHeaderDetil_Delete(code, row, dbconn, dbtrans)

            If Me.DgvCaReport.Rows.Count > 1 Then
                If rowIndex = 0 Then
                    NewRowIndex = rowIndex + 1
                    'Me.uiMstCaReport_OpenRow(NewRowIndex)
                    Me.tbl_MstCaReport.Rows.RemoveAt(rowIndex)
                ElseIf rowIndex = Me.DgvCaReport.Rows.Count - 1 Then
                    NewRowIndex = rowIndex - 1
                    'Me.uiMstCaReport_OpenRow(NewRowIndex)
                    Me.tbl_MstCaReport.Rows.RemoveAt(rowIndex)
                Else
                    Me.tbl_MstCaReport.Rows.RemoveAt(rowIndex)
                    'Me.uiMstCaReport_OpenRow(rowIndex)
                End If
            Else
                Me.tbl_MstCaReport_Temp.Clear()
                Me.tbl_MstCaReport.Rows.RemoveAt(rowIndex)
            End If
        Catch ex As Exception
            Throw ex
            Exit Function
        End Try
    End Function

    Public Sub uiMstCaHeader_Delete(ByVal code As String, ByVal row As String, ByVal seq As String, ByVal dbConn As OleDb.OleDbConnection, _
                       ByVal dbTrans As OleDb.OleDbTransaction)
        Dim cmd As OleDb.OleDbCommand

        Try
            cmd = New OleDb.OleDbCommand("cp_MstCaReport_Delete", dbConn, dbTrans)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@code", code)
            cmd.Parameters.AddWithValue("@row", row)
            cmd.Parameters.AddWithValue("@seq", seq)
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub uiMstCaHeaderDetil_Delete(ByVal code As String, ByVal row As String, ByVal dbConn As OleDb.OleDbConnection, _
                       ByVal dbTrans As OleDb.OleDbTransaction)
        Dim cmd As OleDb.OleDbCommand

        Try
            cmd = New OleDb.OleDbCommand("cp_MstCaReportHeaderDetil_Delete", dbConn, dbTrans)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@code", code)
            cmd.Parameters.AddWithValue("@row", row)
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function uiMstCaReport_DeleteRowDetail(ByVal rowIndex As Integer) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbCmdDelete As OleDb.OleDbCommand
        Dim code, row, line As String

        code = Me.DgvMstCaReport_detil.Rows(rowIndex).Cells("code").Value
        row = Me.DgvMstCaReport_detil.Rows(rowIndex).Cells("row").Value
        line = Me.DgvMstCaReport_detil.Rows(rowIndex).Cells("line").Value

        dbCmdDelete = New OleDb.OleDbCommand("cp_MstCaReportdetil_Delete", dbConn)
        dbCmdDelete.CommandType = CommandType.StoredProcedure
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@code", System.Data.OleDb.OleDbType.Decimal, 5))
        dbCmdDelete.Parameters("@code").Value = code
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@row", System.Data.OleDb.OleDbType.Decimal, 5))
        dbCmdDelete.Parameters("@row").Value = row
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@line", System.Data.OleDb.OleDbType.Decimal, 9))
        dbCmdDelete.Parameters("@line").Value = line

        Dim cookie As Byte() = Nothing

        Try
            dbConn.Open()
            clsApplicationRole.SetAppRole(dbConn, cookie)
            dbCmdDelete.ExecuteNonQuery()
            Me.tbl_MstCaReport_detil.Rows.RemoveAt(rowIndex)
        Catch ex As Data.OleDb.OleDbException
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

    Private Sub DgvMstCaReport_detil_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvMstCaReport_detil.CellClick
        If e.RowIndex >= 0 Then
            Select Case e.ColumnIndex
                Case Me.DgvMstCaReport_detil.Columns("ac start button").Index
                    Dim dlg As dlgSearch_Acc_Ca = New dlgSearch_Acc_Ca()
                    Dim retData As Collection
                    Dim retObj As Object
                    Dim acc_id As Decimal
                    ' Dim budget_name As String

                    retObj = dlg.OpenDialog(Me, Me.tbl_MstAcc_ca, "account_ca")
                    If retObj IsNot Nothing Then
                        retData = CType(retObj, Collection)
                        acc_id = CType(retData.Item(1), Decimal)
                        'budget_name = CType(retData.Item("retName"), String)
                        Me.DgvMstCaReport_detil.Rows(e.RowIndex).Cells("ac_start").Value = acc_id
                        'Me.DgvTrnJurnaldetil_Debit.Rows(e.RowIndex).Cells("budget_name").Value = budget_name
                    End If
                Case Me.DgvMstCaReport_detil.Columns("ac end button").Index
                    Dim dlg As dlgSearch_Acc_Ca = New dlgSearch_Acc_Ca()
                    Dim retData As Collection
                    Dim retObj As Object
                    Dim acc_id As Decimal
                    ' Dim budget_name As String

                    retObj = dlg.OpenDialog(Me, Me.tbl_MstAcc_ca, "account_ca")
                    If retObj IsNot Nothing Then
                        retData = CType(retObj, Collection)
                        acc_id = CType(retData.Item(1), Decimal)
                        ' budget_name = CType(retData.Item("retName"), String)
                        Me.DgvMstCaReport_detil.Rows(e.RowIndex).Cells("ac_end").Value = acc_id
                        'Me.DgvTrnJurnaldetil_Debit.Rows(e.RowIndex).Cells("budget_name").Value = budget_name
                    End If

                    'Case Me.DgvTrnJurnaldetil_Debit.Columns("select_budget_detil").Index
                    '    Dim dlg As dlgSearch = New dlgSearch()
                    '    Dim retData As Collection
                    '    Dim retObj As Object
                    '    Dim budgetdetil_id As Decimal
                    '    Dim budgetdetil_name As String

                    '    Me.tbl_TrnBudgetdetilGrid.DefaultView.RowFilter = String.Format(" budget_id = '{0}'", Me.DgvTrnJurnaldetil_Debit.Rows(e.RowIndex).Cells("budget_id").Value)
                    '    retObj = dlg.OpenDialog(Me, Me.tbl_TrnBudgetdetilGrid.DefaultView.ToTable, "budgetdetil")
                    '    If retObj IsNot Nothing Then
                    '        retData = CType(retObj, Collection)
                    '        budgetdetil_id = CType(retData.Item("retId"), Decimal)
                    '        budgetdetil_name = CType(retData.Item("retName"), String)
                    '        Me.DgvTrnJurnaldetil_Debit.Rows(e.RowIndex).Cells("budgetdetil_id").Value = budgetdetil_id
                    '        Me.DgvTrnJurnaldetil_Debit.Rows(e.RowIndex).Cells("budgetdetil_name").Value = budgetdetil_name
                    '    End If
                    'Case Me.DgvTrnJurnaldetil_Debit.Columns("select_rekanan").Index
                    '    Dim dlg As dlgSearch = New dlgSearch()
                    '    Dim retData As Collection
                    '    Dim retObj As Object
                    '    Dim rekanan_id As Decimal
                    '    Dim rekanan_name As String

                    '    retObj = dlg.OpenDialog(Me, Me.tbl_MstRekananGrid, "rekanan")
                    '    If retObj IsNot Nothing Then
                    '        retData = CType(retObj, Collection)
                    '        rekanan_id = CType(retData.Item("retId"), Decimal)
                    '        rekanan_name = CType(retData.Item("retName"), String)
                    '        Me.DgvTrnJurnaldetil_Debit.Rows(e.RowIndex).Cells("rekanan_id").Value = rekanan_id
                    '        Me.DgvTrnJurnaldetil_Debit.Rows(e.RowIndex).Cells("rekanan_name").Value = rekanan_name
                    '    End If
            End Select
        End If
    End Sub

    Private Sub DgvMstCaReport_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvCaReport.CellValueChanged
        If e.RowIndex >= 0 Then
            Select Case e.ColumnIndex
                Case Me.DgvCaReport.Columns("fbold").Index
                    If Not IsDBNull(Me.DgvCaReport.Rows(e.RowIndex).Cells("fbold").Value) Then
                        If Me.DgvCaReport.Rows(e.RowIndex).Cells("fbold").Value = True Then
                            Me.DgvCaReport.Rows(e.RowIndex).Cells("fbold").Value = 1
                        End If
                    Else
                        Me.DgvCaReport.Rows(e.RowIndex).Cells("fbold").Value = 0
                    End If
                Case Me.DgvCaReport.Columns("fitalic").Index
                    If Not IsDBNull(Me.DgvCaReport.Rows(e.RowIndex).Cells("fitalic").Value) Then
                        If Me.DgvCaReport.Rows(e.RowIndex).Cells("fitalic").Value = True Then
                            Me.DgvCaReport.Rows(e.RowIndex).Cells("fitalic").Value = 1
                        End If
                    Else
                        Me.DgvCaReport.Rows(e.RowIndex).Cells("fitalic").Value = 0
                    End If

                Case Me.DgvCaReport.Columns("fline").Index
                    If Not IsDBNull(Me.DgvCaReport.Rows(e.RowIndex).Cells("fline").Value) Then
                        If Me.DgvCaReport.Rows(e.RowIndex).Cells("fline").Value = True Then
                            Me.DgvCaReport.Rows(e.RowIndex).Cells("fline").Value = 1
                        End If
                    Else
                        Me.DgvCaReport.Rows(e.RowIndex).Cells("fline").Value = 0
                    End If
            End Select
        End If
    End Sub

    Private Sub btn_adddetail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_adddetail.Click
        Me.tbl_MstCaReport_detil.Rows.Add()
    End Sub

    Private Sub btn_deldetail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_deldetail.Click
        Dim res As String = ""
        Dim code As Object = New Object

        Me.Cursor = Cursors.WaitCursor
        RaiseEvent FormBeforeDelete(code)

        Me.Cursor = Cursors.WaitCursor
        If Me.DgvMstCaReport_detil.CurrentRow IsNot Nothing Then

            res = MessageBox.Show("Are you sure want to delete data ?", mUiName, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If res = DialogResult.Yes Then
                Me.uiMstCaReport_DeleteRowDetail(Me.DgvMstCaReport_detil.CurrentRow.Index)
            End If

        End If

        RaiseEvent FormAfterDelete(code)
        Me.Cursor = Cursors.Arrow
    End Sub
End Class