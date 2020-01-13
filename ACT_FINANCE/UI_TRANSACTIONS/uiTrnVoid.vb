Public Class uiTrnVoid
    Private Const mUiName As String = "Transaksi Void"
    Private Const SHOW_SAVE_CONFIRMATION As Boolean = True

    Private Event FormBeforeOpenRow(ByRef id As Object)
    Private Event FormAfterOpenRow(ByRef id As Object)
    Private Event FormBeforeSave(ByRef id As Object)
    Private Event FormAfterSave(ByRef id As Object, ByVal result As FormSaveResult)
    Private Event FormBeforeNew()
    Private Event FormBeforeDelete(ByRef id As Object)
    Private Event FormAfterDelete(ByRef id As Object)
    Private m_streams As IList(Of System.IO.Stream)
    Private m_currentPageIndex As Integer
    Private FILTER_QUERY_MODE As Boolean
    Private DATA_ISLOCKED As Boolean

    Private objFormError As Windows.Forms.ErrorProvider = New Windows.Forms.ErrorProvider

    Private objPrintDetil As DataSource.clsRptVoid
    Private objDatalistDetil As ArrayList

    Private tbl_TrnVoid As DataTable = clsDataset.CreateTblTrnVoid()
    Private tbl_TrnVoid_Temp As DataTable = clsDataset.CreateTblTrnVoid()
    Private tbl_TrnVoidAdvance As DataTable = clsDataset.CreateTblTrnVoidAdvance()
    Private tbl_TrnVoidAdvanceDetil As DataTable = clsDataset.CreateTblJurnalPVDetilReference()
    Private tbl_print As DataTable = New DataTable
    Friend WithEvents btnApprove As ToolStripButton = New ToolStripButton
    Friend WithEvents btnDisApprove As ToolStripButton = New ToolStripButton
    Friend WithEvents btnPost As ToolStripButton = New ToolStripButton
    Friend WithEvents btnUnPost As ToolStripButton = New ToolStripButton

    Private strchannel_id As String
    Private sptchannel_address As String

    Private sptchannel_domainname As String
    Private sptChannel_nameReport As String

#Region " Window Parameter "
    ' TODO: Buat variabel untuk menampung parameter window 
    Private _CHANNEL As String = "TAS"
    Private _JURNALTYPE As String = "VT"
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
        Me.uiTrnVoid_NewData()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnNew_Click()
    End Function

    Public Overrides Function btnLoad_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnVoid_Retrieve()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnLoad_Click()
    End Function

    Public Overrides Function btnSave_Click() As Boolean
        If Me.uiTrnVoid_FormError() Then
            Return True
        End If
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnVoid_Save()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnSave_Click()
    End Function

    Public Overrides Function btnPrint_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnVoid_Print()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnPrint_Click()
    End Function
    Public Overrides Function btnPrintPreview_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnVoid_PrintPreview()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnPrint_Click()
    End Function

    Public Overrides Function btnDel_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnVoid_Delete()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnDel_Click()
    End Function

    Public Overrides Function btnFirst_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnVoid_First()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnFirst_Click()
    End Function

    Public Overrides Function btnPrev_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnVoid_Prev()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnPrev_Click()
    End Function

    Public Overrides Function btnNext_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnVoid_Next()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnNext_Click()
    End Function

    Public Overrides Function btnLast_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnVoid_Last()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnLast_Click()
    End Function


#End Region

#Region " Layout & Init UI "

    Private Function FormatDgvTrnVoid(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        ' Format DgvTrnVoid Columns 
        Dim cVoid_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cVoid_date As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cCreated_by As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cCreated_dt As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cModified_by As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cModified_dt As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cApproved_by As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cApproved_dt As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cPosted_by As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cPosted_dt As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cChannel As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cVoid_jurnaltype As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cVoid_approved As System.Windows.Forms.DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Dim cVoid_posted As System.Windows.Forms.DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn

        cVoid_id.Name = "void_id"
        cVoid_id.HeaderText = "Void ID"
        cVoid_id.DataPropertyName = "void_id"
        cVoid_id.Width = 100
        cVoid_id.Visible = True
        cVoid_id.ReadOnly = False

        cVoid_date.Name = "void_date"
        cVoid_date.HeaderText = "Void Date"
        cVoid_date.DataPropertyName = "void_date"
        cVoid_date.Width = 100
        cVoid_date.Visible = True
        cVoid_date.ReadOnly = False

        cCreated_by.Name = "created_by"
        cCreated_by.HeaderText = "Created By"
        cCreated_by.DataPropertyName = "created_by"
        cCreated_by.Width = 100
        cCreated_by.Visible = True
        cCreated_by.ReadOnly = False

        cCreated_dt.Name = "created_dt"
        cCreated_dt.HeaderText = "Created Date"
        cCreated_dt.DataPropertyName = "created_dt"
        cCreated_dt.Width = 100
        cCreated_dt.Visible = True
        cCreated_dt.ReadOnly = False

        cModified_by.Name = "modified_by"
        cModified_by.HeaderText = "Modified By"
        cModified_by.DataPropertyName = "modified_by"
        cModified_by.Width = 100
        cModified_by.Visible = True
        cModified_by.ReadOnly = False

        cModified_dt.Name = "modified_dt"
        cModified_dt.HeaderText = "Modified Date"
        cModified_dt.DataPropertyName = "modified_dt"
        cModified_dt.Width = 100
        cModified_dt.Visible = True
        cModified_dt.ReadOnly = False

        cApproved_by.Name = "approved_by"
        cApproved_by.HeaderText = "Approved By"
        cApproved_by.DataPropertyName = "approved_by"
        cApproved_by.Width = 100
        cApproved_by.Visible = True
        cApproved_by.ReadOnly = False

        cApproved_dt.Name = "approved_dt"
        cApproved_dt.HeaderText = "Approved Date"
        cApproved_dt.DataPropertyName = "approved_dt"
        cApproved_dt.Width = 100
        cApproved_dt.Visible = True
        cApproved_dt.ReadOnly = False

        cPosted_by.Name = "posted_by"
        cPosted_by.HeaderText = "Posted By"
        cPosted_by.DataPropertyName = "posted_by"
        cPosted_by.Width = 100
        cPosted_by.Visible = True
        cPosted_by.ReadOnly = False

        cPosted_dt.Name = "posted_dt"
        cPosted_dt.HeaderText = "Posted Date"
        cPosted_dt.DataPropertyName = "posted_dt"
        cPosted_dt.Width = 100
        cPosted_dt.Visible = True
        cPosted_dt.ReadOnly = False

        cChannel.Name = "channel_id"
        cChannel.HeaderText = "channel_id"
        cChannel.DataPropertyName = "channel_id"
        cChannel.Width = 100
        cChannel.Visible = False
        cChannel.ReadOnly = False

        cVoid_jurnaltype.Name = "void_jurnaltype"
        cVoid_jurnaltype.HeaderText = "void_jurnaltype"
        cVoid_jurnaltype.DataPropertyName = "void_jurnaltype"
        cVoid_jurnaltype.Width = 100
        cVoid_jurnaltype.Visible = False
        cVoid_jurnaltype.ReadOnly = False

        cVoid_approved.Name = "void_approved"
        cVoid_approved.HeaderText = "void_approved"
        cVoid_approved.DataPropertyName = "void_approved"
        cVoid_approved.Width = 100
        cVoid_approved.Visible = False
        cVoid_approved.ReadOnly = False

        cVoid_posted.Name = "void_posted"
        cVoid_posted.HeaderText = "void_posted"
        cVoid_posted.DataPropertyName = "void_posted"
        cVoid_posted.Width = 100
        cVoid_posted.Visible = False
        cVoid_posted.ReadOnly = False


        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
        {cVoid_id, cVoid_date, cCreated_by, cCreated_dt, cModified_by, cModified_dt, cApproved_by, cApproved_dt, cPosted_by, cPosted_dt, cChannel, cVoid_jurnaltype, cVoid_approved, cVoid_posted})



        ' DgvTrnVoid Behaviours: 
        objDgv.AllowUserToAddRows = False
        objDgv.AllowUserToDeleteRows = False
        objDgv.AllowUserToResizeRows = False
        objDgv.ReadOnly = True
        objDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect

    End Function


    Private Function InitLayoutUI() As Boolean

        Me.ftabMain.Anchor = AnchorStyles.Bottom
        Me.ftabMain.Anchor += AnchorStyles.Top
        Me.ftabMain.Anchor += AnchorStyles.Right
        Me.ftabMain.Anchor += AnchorStyles.Left

        Me.ftabMain.TabPages.Item(1).BackColor = Color.Gainsboro
        Me.PnlDfSearch.Dock = DockStyle.Top
        Me.PnlDfSearch.Visible = False
        Me.PnlDfMain.Dock = DockStyle.Fill
        Me.DgvTrnVoid.Dock = DockStyle.Fill

        Me.FormatDgvTrnVoid(Me.DgvTrnVoid)
        Me.FormatDgvTrnVoidAdvance(Me.DgvTrnVoidAdvance)
        Me.FormatDgvTrnVoidAdvanceDetil(Me.dgvTrnVoidAdvanceDetail)

    End Function

    Private Function BindingStop() As Boolean
        'stop binding
        Me.obj_Void_id.DataBindings.Clear()
        Me.obj_Void_date.DataBindings.Clear()
        Me.obj_Created_by.DataBindings.Clear()
        Me.obj_Created_dt.DataBindings.Clear()
        Me.obj_Modified_by.DataBindings.Clear()
        Me.obj_Modified_dt.DataBindings.Clear()
        Me.obj_Approved_by.DataBindings.Clear()
        Me.obj_Approved_dt.DataBindings.Clear()
        Me.obj_Posted_by.DataBindings.Clear()
        Me.obj_Posted_dt.DataBindings.Clear()
        Return True
    End Function

    Private Function BindingStart() As Boolean
        'start binding
        Me.obj_Void_id.DataBindings.Add(New Binding("Text", Me.tbl_TrnVoid_Temp, "void_id"))
        Me.obj_Void_date.DataBindings.Add(New Binding("Text", Me.tbl_TrnVoid_Temp, "void_date"))
        Me.obj_Created_by.DataBindings.Add(New Binding("Text", Me.tbl_TrnVoid_Temp, "created_by"))
        Me.obj_Created_dt.DataBindings.Add(New Binding("Text", Me.tbl_TrnVoid_Temp, "created_dt"))
        Me.obj_Modified_by.DataBindings.Add(New Binding("Text", Me.tbl_TrnVoid_Temp, "modified_by"))
        Me.obj_Modified_dt.DataBindings.Add(New Binding("Text", Me.tbl_TrnVoid_Temp, "modified_dt"))
        Me.obj_Approved_by.DataBindings.Add(New Binding("Text", Me.tbl_TrnVoid_Temp, "approved_by"))
        Me.obj_Approved_dt.DataBindings.Add(New Binding("Text", Me.tbl_TrnVoid_Temp, "approved_dt"))
        Me.obj_Posted_by.DataBindings.Add(New Binding("Text", Me.tbl_TrnVoid_Temp, "posted_by"))
        Me.obj_Posted_dt.DataBindings.Add(New Binding("Text", Me.tbl_TrnVoid_Temp, "posted_dt"))
        Return True
    End Function

    Private Function FormatDgvTrnVoidAdvance(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean

        Dim cVoid_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cVoid_line As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRef As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekanan As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnal_descr As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAmount As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn

        cVoid_id.Name = "void_id"
        cVoid_id.HeaderText = "void_id"
        cVoid_id.DataPropertyName = "void_id"
        cVoid_id.Width = 100
        cVoid_id.Visible = False
        cVoid_id.ReadOnly = True

        cVoid_line.Name = "void_line"
        cVoid_line.HeaderText = "Line"
        cVoid_line.DataPropertyName = "void_line"
        cVoid_line.Width = 100
        cVoid_line.Visible = True
        cVoid_line.ReadOnly = True

        cRef.Name = "ref"
        cRef.HeaderText = "Ref"
        cRef.DataPropertyName = "ref"
        cRef.Width = 100
        cRef.Visible = True
        cRef.ReadOnly = False

        cRekanan.Name = "rekanan"
        cRekanan.HeaderText = "Rekanan"
        cRekanan.DataPropertyName = "rekanan"
        cRekanan.Width = 100
        cRekanan.Visible = True
        cRekanan.ReadOnly = False

        cJurnal_descr.Name = "jurnal_descr"
        cJurnal_descr.HeaderText = "Description"
        cJurnal_descr.DataPropertyName = "jurnal_descr"
        cJurnal_descr.Width = 100
        cJurnal_descr.Visible = True
        cJurnal_descr.ReadOnly = False

        cAmount.Name = "amount"
        cAmount.HeaderText = "Amount"
        cAmount.DataPropertyName = "amount"
        cAmount.Width = 100
        cAmount.Visible = True
        cAmount.ReadOnly = False

        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
        {cVoid_id, cVoid_line, cRef, cRekanan, cJurnal_descr, cAmount})

        objDgv.ReadOnly = True
        objDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        objDgv.AllowUserToAddRows = False

    End Function

    Private Function FormatDgvTrnVoidAdvanceDetil(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean

        Dim cJurnal_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnaldetil_line As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekanan_name As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnaldetil_descr As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnaldetil_idr As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnalbilyet_no As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRef_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRef_line As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn

        cJurnal_id.Name = "jurnal_id"
        cJurnal_id.HeaderText = "Jurnal ID"
        cJurnal_id.DataPropertyName = "jurnal_id"
        cJurnal_id.Width = 100
        cJurnal_id.Visible = True
        cJurnal_id.ReadOnly = False

        cJurnaldetil_line.Name = "jurnaldetil_line"
        cJurnaldetil_line.HeaderText = "Detil Line"
        cJurnaldetil_line.DataPropertyName = "jurnaldetil_line"
        cJurnaldetil_line.Width = 100
        cJurnaldetil_line.Visible = True
        cJurnaldetil_line.ReadOnly = False

        cRekanan_name.Name = "rekanan_name"
        cRekanan_name.HeaderText = "Rekanan"
        cRekanan_name.DataPropertyName = "rekanan_name"
        cRekanan_name.Width = 100
        cRekanan_name.Visible = True
        cRekanan_name.ReadOnly = False

        cJurnaldetil_descr.Name = "jurnaldetil_descr"
        cJurnaldetil_descr.HeaderText = "Description"
        cJurnaldetil_descr.DataPropertyName = "jurnaldetil_descr"
        cJurnaldetil_descr.Width = 100
        cJurnaldetil_descr.Visible = True
        cJurnaldetil_descr.ReadOnly = False

        cJurnaldetil_idr.Name = "jurnaldetil_idr"
        cJurnaldetil_idr.HeaderText = "Amount"
        cJurnaldetil_idr.DataPropertyName = "jurnaldetil_idr"
        cJurnaldetil_idr.Width = 100
        cJurnaldetil_idr.Visible = True
        cJurnaldetil_idr.ReadOnly = False

        cJurnalbilyet_no.Name = "jurnalbilyet_no"
        cJurnalbilyet_no.HeaderText = "Bilyet No"
        cJurnalbilyet_no.DataPropertyName = "jurnalbilyet_no"
        cJurnalbilyet_no.Width = 100
        cJurnalbilyet_no.Visible = True
        cJurnalbilyet_no.ReadOnly = False

        cRef_id.Name = "ref_id"
        cRef_id.HeaderText = "ref_id"
        cRef_id.DataPropertyName = "ref_id"
        cRef_id.Width = 100
        cRef_id.Visible = False
        cRef_id.ReadOnly = False

        cRef_line.Name = "ref_line"
        cRef_line.HeaderText = "ref_line"
        cRef_line.DataPropertyName = "ref_line"
        cRef_line.Width = 100
        cRef_line.Visible = False
        cRef_line.ReadOnly = False

        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
        {cJurnal_id, cJurnaldetil_line, cRekanan_name, cJurnaldetil_descr, cJurnaldetil_idr, cJurnalbilyet_no, cRef_id, cRef_line})

        objDgv.AllowUserToDeleteRows = False
        objDgv.AllowUserToAddRows = False
        objDgv.ReadOnly = True
        objDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect

    End Function

#End Region

#Region " Dialoged Control "
    Private Function DialogOpen_Reference_Advance_PV()
        Dim dlg As dlgTrnJurnal_PV_Select_VQ = New dlgTrnJurnal_PV_Select_VQ(Me.DSN)
        Dim x As clsDataFiller = New clsDataFiller(Me.DSN)
        Dim result As Object
        Dim data As Collection
        Dim tbl_adv_mst As DataTable
        Dim tbl_adv_dtl As DataTable
        Dim row As DataRow
        Dim columnName As String

        result = dlg.OpenDialog(Me, Me._CHANNEL, x)
        If result IsNot Nothing Then
            data = CType(result, Collection)
            'add advance reference
            tbl_adv_mst = CType(data.Item("mst"), DataTable)
            For i As Integer = 0 To tbl_adv_mst.DefaultView.Count - 1
                row = Me.tbl_TrnVoidAdvance.NewRow()
                For col As Integer = 2 To Me.tbl_TrnVoidAdvance.Columns.Count - 1
                    columnName = Me.tbl_TrnVoidAdvance.Columns(col).ColumnName
                    row(columnName) = tbl_adv_mst.Rows(i).Item(columnName)
                Next
                Me.tbl_TrnVoidAdvance.Rows.Add(row)
            Next

            'add advance detil reference
            tbl_adv_dtl = CType(data.Item("dtl"), DataTable)
            For i As Integer = 0 To tbl_adv_dtl.DefaultView.Count - 1
                row = Me.tbl_TrnVoidAdvanceDetil.NewRow()
                For col As Integer = 0 To Me.tbl_TrnVoidAdvanceDetil.Columns.Count - 1
                    columnName = Me.tbl_TrnVoidAdvanceDetil.Columns(col).ColumnName
                    row(columnName) = tbl_adv_dtl.Rows(i).Item(columnName)
                Next
                Me.tbl_TrnVoidAdvanceDetil.Rows.Add(row)
            Next
        End If

        Return True

    End Function
#End Region

#Region " User Defined Function "

    Private Function uiTrnVoid_NewData() As Boolean
        'new data
        RaiseEvent FormBeforeNew()

        ' TODO: Set Default Value for tbl_TrnVoid_Temp
        Me.tbl_TrnVoid_Temp.Clear()


        ' TODO: Set Default Value for tbl_TrnVoidAdvance
        Me.tbl_TrnVoidAdvance.Clear()
        Me.tbl_TrnVoidAdvance = clsDataset.CreateTblTrnVoidAdvance()
        Me.tbl_TrnVoidAdvance.Columns("void_id").DefaultValue = 0
        Me.tbl_TrnVoidAdvance.Columns("void_line").DefaultValue = DBNull.Value
        Me.tbl_TrnVoidAdvance.Columns("void_line").AutoIncrement = True
        Me.tbl_TrnVoidAdvance.Columns("void_line").AutoIncrementSeed = 10
        Me.tbl_TrnVoidAdvance.Columns("void_line").AutoIncrementStep = 10
        Me.DgvTrnVoidAdvance.DataSource = Me.tbl_TrnVoidAdvance

        Me.tbl_TrnVoidAdvanceDetil.Clear()
        Me.tbl_TrnVoidAdvanceDetil = clsDataset.CreateTblJurnalPVDetilReference()
        Me.dgvTrnVoidAdvanceDetail.DataSource = Me.tbl_TrnVoidAdvanceDetil

        Me.BindingContext(Me.tbl_TrnVoid_Temp).EndCurrentEdit()
        Try
            Me.BindingContext(Me.tbl_TrnVoid_Temp).AddNew()
        Catch ex As Exception
            MessageBox.Show(ex.Source)
        End Try

        Me.btnPost.Visible = False
        Me.btnUnPost.Visible = False
        Me.btnApprove.Visible = False
        Me.btnDisApprove.Visible = False
        Me.DgvTrnVoidAdvance.AllowUserToDeleteRows = True
        Me.btnLoadAdvance.Enabled = True
        Me.tbtnSave.Enabled = True
        Me.tbtnDel.Enabled = True
    End Function

    Private Function uiTrnVoid_Retrieve() As Boolean
        'retrieve data
        Dim criteria As String = String.Format(" channel_id = '{0}'", Me._CHANNEL)

        If Me.chk_voidid_search.Checked = True Then
            If criteria <> String.Empty Then
                criteria = criteria & String.Format(" AND void_id = '{0}'", Me.obj_voidid_search.Text)
            End If
        End If

        If Me.chk_status_search.Checked = True Then
            If Me.obj_status_search.SelectedIndex = 0 Then
                If criteria <> String.Empty Then
                    criteria = criteria & String.Format(" AND void_posted = '0' AND void_approved = '1' ")
                End If
            Else
                If criteria <> String.Empty Then
                    criteria = criteria & String.Format(" AND void_posted = '1' AND void_approved = '1' ")
                End If
            End If

        End If
        ''
        'criteria = criteria

        Me.tbl_TrnVoid.Clear()
        Try
            Me.DataFill(Me.tbl_TrnVoid, "act_TrnVoid_Select", criteria)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Function

    Private Function uiTrnVoid_Save() As Boolean
        'save data
        Dim tbl_TrnVoid_Temp_Changes As DataTable
        Dim tbl_TrnVoidAdvance_Changes As DataTable
        Dim success As Boolean
        Dim void_id As Object = New Object
        Dim i As Integer = 0
        Dim MasterDataState As System.Data.DataRowState
        Dim result As FormSaveResult

        Me.Cursor = Cursors.WaitCursor
        RaiseEvent FormBeforeSave(void_id)

        Me.BindingContext(Me.tbl_TrnVoid_Temp).EndCurrentEdit()

        Me.DgvTrnVoidAdvance.EndEdit()
        Me.BindingContext(Me.tbl_TrnVoidAdvance).EndCurrentEdit()
        tbl_TrnVoidAdvance_Changes = Me.tbl_TrnVoidAdvance.GetChanges()
        If tbl_TrnVoidAdvance_Changes IsNot Nothing Then
            If Me.tbl_TrnVoid_Temp.Rows(0).RowState <> DataRowState.Added Then
                Me.obj_Modified_by.Text = Me.UserName
                Me.obj_Modified_dt.Text = Now()
            End If
        End If

        Me.BindingContext(Me.tbl_TrnVoid_Temp).EndCurrentEdit()
        If Me.tbl_TrnVoid_Temp.Rows(0).Item("approved_by") = "" Then
            Me.tbl_TrnVoid_Temp.Rows(0).Item("approved_dt") = DBNull.Value
        End If
        If Me.tbl_TrnVoid_Temp.Rows(0).Item("posted_by") = "" Then
            Me.tbl_TrnVoid_Temp.Rows(0).Item("posted_dt") = DBNull.Value
        End If
        tbl_TrnVoid_Temp_Changes = Me.tbl_TrnVoid_Temp.GetChanges()

        If tbl_TrnVoid_Temp_Changes IsNot Nothing Or tbl_TrnVoidAdvance_Changes IsNot Nothing Then

            Try

                MasterDataState = tbl_TrnVoid_Temp.Rows(0).RowState
                void_id = tbl_TrnVoid_Temp.Rows(0).Item("void_id")

                If tbl_TrnVoid_Temp_Changes IsNot Nothing Then
                    success = Me.uiTrnVoid_SaveMaster(void_id, tbl_TrnVoid_Temp_Changes, MasterDataState)
                    If Not success Then Throw New Exception("Error: Saving Master Data at Me.uiTrnVoid_SaveMaster(tbl_TrnVoid_Temp_Changes)")
                    Me.tbl_TrnVoid_Temp.AcceptChanges()
                End If

                If tbl_TrnVoidAdvance_Changes IsNot Nothing Then
                    For i = 0 To Me.tbl_TrnVoidAdvance.Rows.Count - 1
                        If Me.tbl_TrnVoidAdvance.Rows(i).RowState = DataRowState.Added Then
                            Me.tbl_TrnVoidAdvance.Rows(i).Item("void_id") = void_id
                        End If
                    Next
                    success = Me.uiTrnVoid_SaveDetil(void_id, tbl_TrnVoidAdvance_Changes, MasterDataState)
                    If Not success Then Throw New Exception("Error: Save Detil Data at Me.uiTrnVoid_SaveDetil(tbl_TrnVoidAdvance_Changes)")
                    Me.tbl_TrnVoidAdvance.AcceptChanges()
                End If

                result = FormSaveResult.SaveSuccess
                If SHOW_SAVE_CONFIRMATION Then
                    MessageBox.Show("Data Saved", mUiName, MessageBoxButtons.OK, MessageBoxIcon.Information)
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

        RaiseEvent FormAfterSave(void_id, result)
        Me.Cursor = Cursors.Arrow

    End Function

    Private Function uiTrnVoid_SaveMaster(ByRef void_id As Object, ByVal objTbl As DataTable, ByVal MasterDataState As System.Data.DataRowState) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbCmdInsert As OleDb.OleDbCommand
        Dim dbCmdUpdate As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter
        Dim curpos As Integer

        ' Save data: transaksi_void
        dbCmdInsert = New OleDb.OleDbCommand("act_TrnVoid_Insert", dbConn)
        dbCmdInsert.CommandType = CommandType.StoredProcedure
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@void_id", System.Data.OleDb.OleDbType.VarWChar, 24, "void_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@void_date", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "void_date"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@created_by", System.Data.OleDb.OleDbType.VarWChar, 100))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@created_dt", System.Data.OleDb.OleDbType.DBTimeStamp, 4))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@modified_by", System.Data.OleDb.OleDbType.VarWChar, 100))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@modified_dt", System.Data.OleDb.OleDbType.DBTimeStamp, 4))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@approved_by", System.Data.OleDb.OleDbType.VarWChar, 100))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@approved_dt", System.Data.OleDb.OleDbType.DBTimeStamp, 4))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@posted_by", System.Data.OleDb.OleDbType.VarWChar, 100))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@posted_dt", System.Data.OleDb.OleDbType.DBTimeStamp, 4))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 30))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@void_jurnaltype", System.Data.OleDb.OleDbType.VarWChar, 4))
        dbCmdInsert.Parameters("@created_by").Value = Me.UserName
        dbCmdInsert.Parameters("@created_dt").Value = Now()
        dbCmdInsert.Parameters("@modified_by").Value = String.Empty
        dbCmdInsert.Parameters("@modified_dt").Value = DBNull.Value
        dbCmdInsert.Parameters("@approved_by").Value = String.Empty
        dbCmdInsert.Parameters("@approved_dt").Value = DBNull.Value
        dbCmdInsert.Parameters("@posted_by").Value = String.Empty
        dbCmdInsert.Parameters("@posted_dt").Value = DBNull.Value
        dbCmdInsert.Parameters("@channel_id").Value = Me._CHANNEL
        dbCmdInsert.Parameters("@void_jurnaltype").Value = Me._JURNALTYPE


        dbCmdUpdate = New OleDb.OleDbCommand("act_TrnVoid_Update", dbConn)
        dbCmdUpdate.CommandType = CommandType.StoredProcedure
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@void_id", System.Data.OleDb.OleDbType.VarWChar, 24, "void_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@void_date", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "void_date"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@created_by", System.Data.OleDb.OleDbType.VarWChar, 100, "created_by"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@created_dt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "created_dt"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@modified_by", System.Data.OleDb.OleDbType.VarWChar, 100, "modified_by"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@modified_dt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "modified_dt"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@approved_by", System.Data.OleDb.OleDbType.VarWChar, 100, "approved_by"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@approved_dt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "approved_dt"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@posted_by", System.Data.OleDb.OleDbType.VarWChar, 100, "posted_by"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@posted_dt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "posted_dt"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 30))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@void_jurnaltype", System.Data.OleDb.OleDbType.VarWChar, 4))
        dbCmdUpdate.Parameters("@channel_id").Value = Me._CHANNEL
        dbCmdUpdate.Parameters("@void_jurnaltype").Value = Me._JURNALTYPE

        dbDA = New OleDb.OleDbDataAdapter
        dbDA.UpdateCommand = dbCmdUpdate
        dbDA.InsertCommand = dbCmdInsert

        Dim cookie As Byte() = Nothing

        Try
            dbConn.Open()
            clsApplicationRole.SetAppRole(dbConn, cookie)
            dbDA.Update(objTbl)

            void_id = objTbl.Rows(0).Item("void_id")
            Me.tbl_TrnVoid_Temp.Clear()
            Me.tbl_TrnVoid_Temp.Merge(objTbl)

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
            Me.tbl_TrnVoid.Merge(objTbl)
            Me.uiTrnVoid_Retrieve()
        ElseIf MasterDataState = DataRowState.Modified Then
            curpos = Me.BindingContext(Me.tbl_TrnVoid).Position
            Me.tbl_TrnVoid.Rows.RemoveAt(curpos)
            Me.tbl_TrnVoid.Merge(objTbl)
            Me.uiTrnVoid_Retrieve()
        End If

        Me.BindingContext(Me.tbl_TrnVoid).Position = Me.BindingContext(Me.tbl_TrnVoid).Count

        Return True
    End Function

    Private Function uiTrnVoid_SaveDetil(ByRef void_id As Object, ByVal objTbl As DataTable, ByVal MasterDataState As System.Data.DataRowState) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbCmdInsert As OleDb.OleDbCommand
        Dim dbCmdUpdate As OleDb.OleDbCommand
        Dim dbCmdDelete As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        ' Save data: transaksi_voiddetil
        dbCmdInsert = New OleDb.OleDbCommand("act_TrnVoiddetil_Insert", dbConn)
        dbCmdInsert.CommandType = CommandType.StoredProcedure
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@void_id", System.Data.OleDb.OleDbType.VarWChar, 24))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@void_line", System.Data.OleDb.OleDbType.Integer, 4, "void_line"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_id", System.Data.OleDb.OleDbType.VarWChar, 24, "ref"))
        dbCmdInsert.Parameters("@void_id").Value = void_id

        dbCmdUpdate = New OleDb.OleDbCommand("act_TrnVoiddetil_Update", dbConn)
        dbCmdUpdate.CommandType = CommandType.StoredProcedure
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@void_id", System.Data.OleDb.OleDbType.VarWChar, 24))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@void_line", System.Data.OleDb.OleDbType.Integer, 4, "void_line"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_id", System.Data.OleDb.OleDbType.VarWChar, 24, "ref"))
        dbCmdUpdate.Parameters("@void_id").Value = void_id

        dbCmdDelete = New OleDb.OleDbCommand("act_TrnVoiddetil_Delete", dbConn)
        dbCmdDelete.CommandType = CommandType.StoredProcedure
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@void_id", System.Data.OleDb.OleDbType.VarWChar, 24))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@void_line", System.Data.OleDb.OleDbType.Integer, 4, "void_line"))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_id", System.Data.OleDb.OleDbType.VarWChar, 24, "ref"))
        dbCmdDelete.Parameters("@void_id").Value = void_id

        dbDA = New OleDb.OleDbDataAdapter
        dbDA.UpdateCommand = dbCmdUpdate
        dbDA.InsertCommand = dbCmdInsert
        dbDA.DeleteCommand = dbCmdDelete

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

        Return True
    End Function

    Private Function uiTrnVoid_Print() As Boolean
        'print data
        If Me.DgvTrnVoid.SelectedRows.Count <= 0 Then
            MsgBox("Belum ada data yang dipilih")
            Exit Function
        End If

        'Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim oDataFiller As New clsDataFiller(Me.DSN)
        Dim void_id As String
        Dim criteria As String = String.Empty
        void_id = DgvTrnVoid.CurrentRow.Cells("void_id").Value

        Me.tbl_print.Clear()

        criteria = "  void_id = '" & void_id & "'"
        oDataFiller.DataFill(Me.tbl_print, "act_TrnVoid_Advance_SelectForPrint", criteria)

        If Me.tbl_print.Rows.Count = 0 Then
            MsgBox("No data")
            Exit Function
        End If

        Dim objRdsH As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Dim objReportH As Microsoft.Reporting.WinForms.LocalReport = New Microsoft.Reporting.WinForms.LocalReport
        Dim objRdsD As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Dim objReportD As Microsoft.Reporting.WinForms.LocalReport = New Microsoft.Reporting.WinForms.LocalReport
        Dim objDatalistHeader As ArrayList = New ArrayList()
        Dim objReportViewer As Microsoft.Reporting.WinForms.ReportViewer = New Microsoft.Reporting.WinForms.ReportViewer

        objDatalistHeader = Me.GenerateDataDetail()

        'Dim parRptImageURL As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("imageURL", Me.SptServer)

        '============ tambahan by ari prasasti <parameter global> 20 April 2012
        Dim dt As DataTable = New DataTable

        dt.Clear()

        clsUtil.DataFill(Me.DSN, dt, "act_select_channel", " channel_id = '" & Me._CHANNEL & "' ")

        'fill variabel global
        Dim fileUrl As String = CStr(dt.Rows(0).Item("channel_domainname"))

        '---------------tambahan buat insosys baru 2012-- 19 April 2012---------------
        fileUrl = fileUrl.Replace("\", "/")
        fileUrl = "file:///" & fileUrl & "/services/live/solutions/images/" & Me._CHANNEL & ".jpg"
        '---------------------------------------------------------------

        Dim parRptImageURL As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("imageURL", fileUrl)

        '===end tambahan

        Dim parRptChannel_namereport As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("channel_name", Me.sptChannel_nameReport)
        Dim parRptChannel_address As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("channel_address", Me.sptchannel_address)
        Dim parRptChannel_ID As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("channel_id", Me.strchannel_id)

        objRdsH.Name = "ACT_FINANCE_DataSource_clsRptVoid"

        objRdsH.Value = objDatalistHeader


        objReportH.ReportEmbeddedResource = "ACT_FINANCE.RptVoid.rdlc"
        objReportH.DataSources.Add(objRdsH)



        objReportH.EnableExternalImages = True

        objReportH.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter() {parRptImageURL, parRptChannel_namereport, parRptChannel_address, parRptChannel_ID})
        'AddHandler objReportH.SubreportProcessing, AddressOf SubreportProcessing
        Export(objReportH)

        m_currentPageIndex = 0
        Print()
    End Function
    Private Function uiTrnVoid_PrintPreview() As Boolean
        'printpreview data
        If Me.DgvTrnVoid.SelectedRows.Count <= 0 Then
            MsgBox("Belum ada data yang dipilih")
            Exit Function
        End If

        Dim void_id As String
        void_id = DgvTrnVoid.CurrentRow.Cells("void_id").Value

        Dim frmPrintVoid As dlgRptVoid = New dlgRptVoid(Me.DSN, Me.SptServer, void_id, Me._CHANNEL)
        Dim criteria As String = String.Empty

        frmPrintVoid.ShowInTaskbar = False
        frmPrintVoid.StartPosition = FormStartPosition.CenterParent

        criteria = "  void_id = '" & void_id & "'"

        frmPrintVoid.ShowInTaskbar = False
        frmPrintVoid.StartPosition = FormStartPosition.CenterParent
        frmPrintVoid.ShowDialog(Me)
    End Function

    Private Sub Export(ByVal report As Microsoft.Reporting.WinForms.LocalReport)
        Dim deviceInfo As String = _
          "<DeviceInfo>" & _
        "  <OutputFormat>EMF</OutputFormat>" & _
        "  <PageWidth>8.5in</PageWidth>" & _
        "  <PageHeight>11 in</PageHeight>" & _
        "  <MarginTop>0.2in</MarginTop>" & _
        "  <MarginLeft>0.2in</MarginLeft>" & _
        "  <MarginRight>0.3in</MarginRight>" & _
        "  <MarginBottom>0.3in</MarginBottom>" & _
        "</DeviceInfo>"
        Dim warnings() As Microsoft.Reporting.WinForms.Warning = Nothing
        m_streams = New List(Of System.IO.Stream)()
        'Try
        report.Render("Image", deviceInfo, AddressOf CreateStream, warnings)

        Dim stream As System.IO.Stream
        For Each stream In m_streams
            stream.Position = 0
        Next

        'Catch ex As Exception
        'MsgBox("Cannot print the document directly. " & ex.Message & vbCrLf & vbCrLf & _
        ' "                                   Please use the PrintPreview metode.")

        'End Try
    End Sub

    'Private Function CreateStream(ByVal name As String, _
    '   ByVal fileNameExtension As String, _
    '   ByVal encoding As System.Text.Encoding, ByVal mimeType As String, _
    '   ByVal willSeek As Boolean) As System.IO.Stream
    '    Dim stream As System.IO.Stream = _
    '        New System.IO.FileStream("..\..\" + _
    '         name + "." + fileNameExtension, System.IO.FileMode.Create)
    '    m_streams.Add(stream)
    '    Return stream
    'End Function

    Private Function CreateStream(ByVal name As String, _
       ByVal fileNameExtension As String, _
       ByVal encoding As System.Text.Encoding, ByVal mimeType As String, _
       ByVal willSeek As Boolean) As System.IO.Stream
        Dim stream As System.IO.Stream = _
            New System.IO.FileStream(AppDomain.CurrentDomain.BaseDirectory & "Temp\" + _
             name + "." + fileNameExtension, System.IO.FileMode.Create)
        m_streams.Add(stream)
        Return stream
    End Function
    Private Sub Print()
        'Const printerName As String = _
        '"Microsoft Office Document Image Writer" '"\\print-programmi\HP LaserJet 2300 Subtitle" '

        Dim printerName As String = ""
        'Dim dlgPrint As New PrintDialog()
        Dim aPrinterSettings As New System.Drawing.Printing.PrinterSettings

        printerName = aPrinterSettings.PrinterName

        'If dlgPrint.ShowDialog = DialogResult.OK Then
        '    printerName = dlgPrint.PrinterSettings.PrinterName
        'End If

        If m_streams Is Nothing Or m_streams.Count = 0 Then
            Return
        End If

        Dim printDoc As New System.Drawing.Printing.PrintDocument()
        printDoc.PrinterSettings.PrinterName = printerName
        If Not printDoc.PrinterSettings.IsValid Then
            Dim msg As String = String.Format( _
                "Can't find printer ""{0}"".", printerName)
            Console.WriteLine(msg)
            Return
        End If
        AddHandler printDoc.PrintPage, AddressOf PrintPage

        printDoc.Print()
        m_streams.Clear()

    End Sub
    Private Sub PrintPage(ByVal sender As Object, _
    ByVal ev As System.Drawing.Printing.PrintPageEventArgs)
        Dim pageImage As New System.Drawing.Imaging.Metafile(m_streams(m_currentPageIndex))
        ev.Graphics.DrawImage(pageImage, ev.PageBounds)

        m_currentPageIndex += 1
        ev.HasMorePages = (m_currentPageIndex < m_streams.Count)
    End Sub
    Private Function GenerateDataDetail() As ArrayList
        Dim i As Integer

        Dim objDatalistHeader As ArrayList = New ArrayList()
        For i = 0 To Me.tbl_print.Rows.Count - 1
            objPrintDetil = New DataSource.clsRptVoid(Me.DSN)
            With objPrintDetil
                .circulation_id = clsUtil.IsDbNull(Me.tbl_print.Rows(i).Item("circulation_id"), String.Empty)
                .circulation_ref = clsUtil.IsDbNull(Me.tbl_print.Rows(i).Item("ref"), String.Empty)
                .rekanan_name = clsUtil.IsDbNull(Me.tbl_print.Rows(i).Item("rekanan"), String.Empty)
                .descr = clsUtil.IsDbNull(Me.tbl_print.Rows(i).Item("jurnal_descr"), String.Empty)
                .bilyet = clsUtil.IsDbNull(Me.tbl_print.Rows(i).Item("bilyet"), String.Empty)
                .amount_sum = clsUtil.IsDbNull(Me.tbl_print.Rows(i).Item("amount_sum"), String.Empty)
                .channel_id = clsUtil.IsDbNull(Me.tbl_print.Rows(i).Item("channel_id"), String.Empty)
                .void_id = clsUtil.IsDbNull(Me.tbl_print.Rows(i).Item("void_id"), String.Empty)
                .createdate = clsUtil.IsDbNull(Me.tbl_print.Rows(i).Item("createdate"), String.Empty)

                Me.strchannel_id = .channel_id
                Me.sptChannel_nameReport = .channel_namereport
                Me.sptchannel_address = .channel_address

            End With
            objDatalistHeader.Add(objPrintDetil)
        Next

        Return objDatalistHeader
    End Function
    Private Function uiTrnVoid_Delete() As Boolean
        Dim res As String = ""
        Dim void_id As Object = New Object

        Me.Cursor = Cursors.WaitCursor
        RaiseEvent FormBeforeDelete(void_id)

        Me.Cursor = Cursors.WaitCursor
        If Me.DgvTrnVoid.CurrentRow IsNot Nothing Then

            res = MessageBox.Show("Are you sure want to delete data ?", mUiName, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If res = DialogResult.Yes Then
                Me.uiTrnVoid_DeleteRow(Me.DgvTrnVoid.CurrentRow.Index)
            End If

        End If

        RaiseEvent FormAfterDelete(void_id)
        Me.Cursor = Cursors.Arrow

    End Function

    Private Function uiTrnVoid_DeleteRow(ByVal rowIndex As Integer) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbCmdDelete As OleDb.OleDbCommand
        Dim void_id As String
        Dim NewRowIndex As Integer

        void_id = Me.DgvTrnVoid.Rows(rowIndex).Cells("void_id").Value

        dbCmdDelete = New OleDb.OleDbCommand("cp_TrnVoid_Delete", dbConn)
        dbCmdDelete.CommandType = CommandType.StoredProcedure
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@void_id", System.Data.OleDb.OleDbType.VarWChar, 24))
        dbCmdDelete.Parameters("@void_id").Value = void_id
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@void_date", System.Data.OleDb.OleDbType.DBTimeStamp, 4))
        dbCmdDelete.Parameters("@void_date").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@created_by", System.Data.OleDb.OleDbType.VarWChar, 100))
        dbCmdDelete.Parameters("@created_by").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@created_dt", System.Data.OleDb.OleDbType.DBTimeStamp, 4))
        dbCmdDelete.Parameters("@created_dt").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@modified_by", System.Data.OleDb.OleDbType.VarWChar, 100))
        dbCmdDelete.Parameters("@modified_by").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@modified_dt", System.Data.OleDb.OleDbType.DBTimeStamp, 4))
        dbCmdDelete.Parameters("@modified_dt").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@approved_by", System.Data.OleDb.OleDbType.VarWChar, 100))
        dbCmdDelete.Parameters("@approved_by").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@approved_dt", System.Data.OleDb.OleDbType.DBTimeStamp, 4))
        dbCmdDelete.Parameters("@approved_dt").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@posted_by", System.Data.OleDb.OleDbType.VarWChar, 100))
        dbCmdDelete.Parameters("@posted_by").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@posted_dt", System.Data.OleDb.OleDbType.DBTimeStamp, 4))
        dbCmdDelete.Parameters("@posted_dt").Value = DBNull.Value

        Dim cookie As Byte() = Nothing

        Try
            dbConn.Open()
            clsApplicationRole.SetAppRole(dbConn, cookie)
            dbCmdDelete.ExecuteNonQuery()

            If Me.DgvTrnVoid.Rows.Count > 1 Then
                If rowIndex = 0 Then
                    NewRowIndex = rowIndex + 1
                    Me.uiTrnVoid_OpenRow(NewRowIndex)
                    Me.tbl_TrnVoid.Rows.RemoveAt(rowIndex)
                ElseIf rowIndex = Me.DgvTrnVoid.Rows.Count - 1 Then
                    NewRowIndex = rowIndex - 1
                    Me.uiTrnVoid_OpenRow(NewRowIndex)
                    Me.tbl_TrnVoid.Rows.RemoveAt(rowIndex)
                Else
                    Me.tbl_TrnVoid.Rows.RemoveAt(rowIndex)
                    Me.uiTrnVoid_OpenRow(rowIndex)
                End If
            Else
                Me.tbl_TrnVoid_Temp.Clear()
                Me.tbl_TrnVoid.Rows.RemoveAt(rowIndex)
            End If

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

    Private Function uiTrnVoid_OpenRow(ByVal rowIndex As Integer) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim void_id As String

        void_id = Me.DgvTrnVoid.Rows(rowIndex).Cells("void_id").Value

        Me.Cursor = Cursors.WaitCursor
        RaiseEvent FormBeforeOpenRow(void_id)

        Dim cookie As Byte() = Nothing

        Try
            dbConn.Open()
            clsApplicationRole.SetAppRole(dbConn, cookie)
            Me.uiTrnVoid_OpenRowMaster(void_id, dbConn)
            Me.uiTrnVoid_OpenRowDetil(void_id, dbConn)
        Catch ex As Exception
            MessageBox.Show(ex.Message, mUiName & ": uiTrnVoid_OpenRow()", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            clsApplicationRole.UnsetAppRole(dbConn, cookie)
            dbConn.Close()
        End Try

        RaiseEvent FormAfterOpenRow(void_id)
        Me.Cursor = Cursors.Arrow

        Return True

    End Function

    Private Function uiTrnVoid_OpenRowMaster(ByVal void_id As String, ByVal dbConn As OleDb.OleDbConnection) As Boolean
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        dbCmd = New OleDb.OleDbCommand("act_TrnVoid_Select", dbConn)
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@Criteria").Value = String.Format("void_id='{0}'", void_id)
        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)
        Me.tbl_TrnVoid_Temp.Clear()

        Try
            Me.BindingStop()
            dbDA.Fill(Me.tbl_TrnVoid_Temp)
            Me.BindingStart()
        Catch ex As Exception
            Throw New Exception(mUiName & ": uiTrnVoid_OpenRowMaster()" & vbCrLf & ex.Message)
        End Try

    End Function

    Private Function uiTrnVoid_OpenRowDetil(ByVal void_id As String, ByVal dbConn As OleDb.OleDbConnection) As Boolean
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        dbCmd = New OleDb.OleDbCommand("act_TrnVoid_Advance_Select", dbConn)
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@Criteria").Value = String.Format("void_id='{0}'", void_id)
        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)
        Me.tbl_TrnVoidAdvance.Clear()

        Me.tbl_TrnVoidAdvance = clsDataset.CreateTblTrnVoidAdvance()
        Me.tbl_TrnVoidAdvance.Columns("void_id").DefaultValue = void_id
        Me.tbl_TrnVoidAdvance.Columns("void_line").DefaultValue = DBNull.Value
        Me.tbl_TrnVoidAdvance.Columns("void_line").AutoIncrement = True
        Me.tbl_TrnVoidAdvance.Columns("void_line").AutoIncrementSeed = 10
        Me.tbl_TrnVoidAdvance.Columns("void_line").AutoIncrementStep = 10

        Try
            dbDA.Fill(Me.tbl_TrnVoidAdvance)
            Me.DgvTrnVoidAdvance.DataSource = Me.tbl_TrnVoidAdvance
            Me.uiTrnVoid_OpenRowDetilAdvance(Me.tbl_TrnVoidAdvance, dbConn)
        Catch ex As Exception
            Throw New Exception(mUiName & ": uiTrnVoid_OpenRowDetil()" & vbCrLf & ex.Message)
        End Try

    End Function

    Private Function uiTrnVoid_OpenRowDetilAdvance(ByVal tbl As DataTable, ByVal dbconn As OleDb.OleDbConnection) As Boolean
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter
        Dim tbl_temp As DataTable = clsDataset.CreateTblJurnalPVDetilReference()
        Dim i As Integer

        Me.tbl_TrnVoidAdvanceDetil.Clear()
        For i = 0 To tbl.DefaultView.Count - 1
            dbCmd = New OleDb.OleDbCommand("act_TrnVoid_PV_Detil_Select", dbconn)
            dbCmd.Parameters.Add("@ID", OleDb.OleDbType.VarWChar, 12)
            dbCmd.Parameters("@ID").Value = String.Format("{0}", tbl.Rows(i).Item("ref"))
            dbCmd.CommandType = CommandType.StoredProcedure
            dbDA = New OleDb.OleDbDataAdapter(dbCmd)
            tbl_temp.Clear()

            Try
                dbDA.Fill(tbl_temp)
                Me.tbl_TrnVoidAdvanceDetil.Merge(tbl_temp)
            Catch ex As Exception
                Throw New Exception(mUiName & ": uiTrnVoid_OpenRowDetilAdvance()" & vbCrLf & ex.Message)
            End Try
        Next
        Me.dgvTrnVoidAdvanceDetail.DataSource = Me.tbl_TrnVoidAdvanceDetil
        Return True
    End Function

    Private Function uiTrnVoid_First() As Boolean
        'goto first record found
        Dim move As Boolean
        Dim Message As String = "Data has been changed. " & vbCrLf & "Save data changes before move to first record ?"
        Dim iTab As Integer = Me.ftabMain.SelectedIndex

        If iTab = 1 Then
            If Me.DATA_ISLOCKED Then
                move = True
            Else
                move = Me.uiTrnVoid_ConfirmSaveBeforeMove(Message)
            End If
        Else
            move = True
        End If

        If move Then
            Me.DgvTrnVoid.CurrentCell = Me.DgvTrnVoid(1, 0)
            Me.uiTrnVoid_RefreshPosition()
        End If
    End Function

    Private Function uiTrnVoid_Prev() As Boolean
        'goto previous record found
        Dim move As Boolean
        Dim Message As String = "Data has been changed. " & vbCrLf & "Save data changes before move to previous record ?"
        Dim iTab As Integer = Me.ftabMain.SelectedIndex

        If iTab = 1 Then
            If Me.DATA_ISLOCKED Then
                move = True
            Else
                move = Me.uiTrnVoid_ConfirmSaveBeforeMove(Message)
            End If
        Else
            move = True
        End If

        If move Then
            If Me.DgvTrnVoid.CurrentCell.RowIndex > 0 Then
                Me.DgvTrnVoid.CurrentCell = Me.DgvTrnVoid(1, DgvTrnVoid.CurrentCell.RowIndex - 1)
                Me.uiTrnVoid_RefreshPosition()
            End If
        End If
    End Function

    Private Function uiTrnVoid_Next() As Boolean
        'goto next record found
        Dim move As Boolean
        Dim Message As String = "Data has been changed. " & vbCrLf & "Save data changes before move to next record ?"
        Dim iTab As Integer = Me.ftabMain.SelectedIndex

        If iTab = 1 Then
            If Me.DATA_ISLOCKED Then
                move = True
            Else
                move = Me.uiTrnVoid_ConfirmSaveBeforeMove(Message)
            End If
        Else
            move = True
        End If

        If move Then
            If Me.DgvTrnVoid.CurrentCell.RowIndex < Me.DgvTrnVoid.Rows.Count - 1 Then
                Me.DgvTrnVoid.CurrentCell = Me.DgvTrnVoid(1, DgvTrnVoid.CurrentCell.RowIndex + 1)
                Me.uiTrnVoid_RefreshPosition()
            End If
        End If
    End Function

    Private Function uiTrnVoid_Last() As Boolean
        'goto last record found
        Dim move As Boolean
        Dim Message As String = "Data has been changed. " & vbCrLf & "Save data changes before move to next record ?"
        Dim iTab As Integer = Me.ftabMain.SelectedIndex

        If iTab = 1 Then
            If Me.DATA_ISLOCKED Then
                move = True
            Else
                move = Me.uiTrnVoid_ConfirmSaveBeforeMove(Message)
            End If
        Else
            move = True
        End If

        If move Then
            Me.DgvTrnVoid.CurrentCell = Me.DgvTrnVoid(1, Me.DgvTrnVoid.Rows.Count - 1)
            Me.uiTrnVoid_RefreshPosition()
        End If
    End Function

    Private Function uiTrnVoid_RefreshPosition() As Boolean
        'refresh position
        Dim iTab As Integer = Me.ftabMain.SelectedIndex
        If iTab = 1 Then uiTrnVoid_OpenRow(Me.DgvTrnVoid.CurrentRow.Index)
    End Function

    Private Function uiTrnVoid_ConfirmSaveBeforeMove(ByVal Message As String) As Boolean
        'confirm saving data changes before move
        Dim tbl_TrnVoid_Temp_Changes As DataTable
        Dim tbl_TrnVoidAdvance_Changes As DataTable
        Dim res As System.Windows.Forms.DialogResult
        Dim success As Boolean
        Dim i As Integer = 0
        Dim MasterDataState As System.Data.DataRowState
        Dim void_id As Object = New Object
        Dim move As Boolean = False
        Dim result As FormSaveResult


        If Me.DgvTrnVoid.CurrentCell IsNot Nothing Then

            Me.BindingContext(Me.tbl_TrnVoid_Temp).EndCurrentEdit()
            tbl_TrnVoid_Temp_Changes = Me.tbl_TrnVoid_Temp.GetChanges()

            Me.DgvTrnVoidAdvance.EndEdit()
            Me.BindingContext(Me.tbl_TrnVoidAdvance).EndCurrentEdit()
            tbl_TrnVoidAdvance_Changes = Me.tbl_TrnVoidAdvance.GetChanges()

            If tbl_TrnVoid_Temp_Changes IsNot Nothing Or tbl_TrnVoidAdvance_Changes IsNot Nothing Then

                res = MessageBox.Show(Message, mUiName, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                Select Case res
                    Case DialogResult.Yes

                        RaiseEvent FormBeforeSave(void_id)

                        Try

                            If tbl_TrnVoid_Temp_Changes IsNot Nothing Then
                                success = Me.uiTrnVoid_SaveMaster(void_id, tbl_TrnVoid_Temp_Changes, MasterDataState)
                                If Not success Then Throw New Exception("Cannot Save Master Data")
                                Me.tbl_TrnVoid_Temp.AcceptChanges()
                            End If

                            If tbl_TrnVoidAdvance_Changes IsNot Nothing Then
                                For i = 0 To Me.tbl_TrnVoidAdvance.Rows.Count - 1
                                    If Me.tbl_TrnVoidAdvance.Rows(i).RowState = DataRowState.Added Then
                                        Me.tbl_TrnVoidAdvance.Rows(i).Item("void_id") = void_id
                                    End If
                                Next
                                success = Me.uiTrnVoid_SaveDetil(void_id, tbl_TrnVoidAdvance_Changes, MasterDataState)
                                If Not success Then Throw New Exception("Cannot Save Detil Data")
                                Me.tbl_TrnVoidAdvance.AcceptChanges()
                            End If

                            result = FormSaveResult.SaveSuccess
                            If SHOW_SAVE_CONFIRMATION Then
                                MessageBox.Show("Data Saved", mUiName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                            End If

                        Catch ex As Exception
                            result = FormSaveResult.SaveError
                            MessageBox.Show(ex.Message & vbCrLf & "Data Cannot Be Saved", mUiName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try

                        RaiseEvent FormAfterSave(void_id, result)

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

    Private Function uiTrnVoid_FormError() As Boolean
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
    Private Function uiTrnVoid_CheckValid() As Boolean
        Try
            ' TODO: Cek Error disini
            ' objFormError.SetError()
            If Me.tbl_TrnVoidAdvance.DefaultView.Count = 0 Then
                Throw New Exception("Pilih referensi advance yang akan di approve")
            End If

            If Me.obj_Void_id.Text = "" Or Me.tbl_TrnVoid_Temp.Rows(0).Item("void_id") = "" Then
                Throw New Exception("Data harus disave terlebih dahulu baru bisa approve")
            End If
            ' Throw New Exception("Error")
        Catch ex As Exception
            MessageBox.Show(ex.Message, mUiName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return True
        End Try
        Return False
    End Function
#End Region

    Public Sub Form_Load(ByVal sender As Object)
        Dim objParameters As Collection = New Collection

        If Me.Browser IsNot Nothing Then
            objParameters = Me.GetParameterCollection(Me.Parameter)
            Me._CHANNEL = Me.GetValueFromParameter(objParameters, "CHANNEL")
            Me._JURNALTYPE = Me.GetValueFromParameter(objParameters, "JURNALTYPE")
        End If

        If (Me.Browser IsNot Nothing And MyBase.Name = _Name) Or (Me.Browser Is Nothing And Application.ProductName <> _ProductName) Then
            Me.InitLayoutUI()
            Me.DgvTrnVoid.DataSource = Me.tbl_TrnVoid

            Me.BindingStop()
            Me.BindingStart()

            Me.uiTrnVoid_NewData()

            Me.tbtnSave.Enabled = False
            Me.tbtnDel.Enabled = False
            Me.tbtnLoad.Enabled = True
            Me.tbtnQuery.Enabled = True

            Me.btnApprove.Text = "Approve"
            Me.btnApprove.Name = "btnApprove"
            Me.btnDisApprove.Text = "DisApprove"
            Me.btnDisApprove.Name = "btnDisApprove"
            Me.btnApprove.Visible = False
            Me.btnApprove.Font = New Font(Me.btnApprove.Font, FontStyle.Bold)
            Me.btnDisApprove.Visible = False
            Me.btnDisApprove.Font = New Font(Me.btnDisApprove.Font, FontStyle.Bold)
            Me.ToolStrip1.Items.Add(Me.btnApprove)
            Me.ToolStrip1.Items.Add(Me.btnDisApprove)

            Me.btnPost.Text = "Posting"
            Me.btnPost.Name = "btnPost"
            Me.btnUnPost.Text = "UnPosting"
            Me.btnUnPost.Name = "btnUnPost"
            Me.btnPost.Visible = False
            Me.btnPost.Font = New Font(Me.btnPost.Font, FontStyle.Bold)
            Me.btnUnPost.Visible = False
            Me.btnUnPost.Font = New Font(Me.btnUnPost.Font, FontStyle.Bold)
            Me.ToolStrip1.Items.Add(Me.btnPost)
            'Me.ToolStrip1.Items.Add(Me.btnUnPost)
        End If
    End Sub

    Private Sub uiTrnVoid_FormAfterOpenRow(ByRef id As Object) Handles Me.FormAfterOpenRow

    End Sub

    Private Sub uiTrnVoid_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

                Me.btnApprove.Visible = False
                Me.btnDisApprove.Visible = False
                Me.btnPost.Visible = False
                Me.btnUnPost.Visible = False

            Case 1
                Me.tbtnLoad.Enabled = False
                Me.tbtnQuery.Enabled = False
                Me.ftabMain.TabPages.Item(0).BackColor = Color.Gainsboro
                Me.ftabMain.TabPages.Item(1).BackColor = Color.White
                If Me.DgvTrnVoid.Rows.Count > 0 Then
                    If Me.DgvTrnVoid.Item("void_posted", Me.DgvTrnVoid.CurrentRow.Index).Value = True Then
                        Me.btnPost.Visible = False
                        'Me.btnUnPost.Visible = False
                        Me.btnApprove.Visible = False
                        Me.btnDisApprove.Visible = False
                        Me.DgvTrnVoidAdvance.AllowUserToDeleteRows = False
                        Me.btnLoadAdvance.Enabled = False
                        Me.tbtnSave.Enabled = False
                        Me.tbtnDel.Enabled = False
                    Else
                        If Me.DgvTrnVoid.Item("void_approved", Me.DgvTrnVoid.CurrentRow.Index).Value = True Then 'sudah di approve
                            Me.btnPost.Visible = True
                            'Me.btnUnPost.Visible = False
                            Me.btnApprove.Visible = False
                            Me.btnDisApprove.Visible = True
                            Me.DgvTrnVoidAdvance.AllowUserToDeleteRows = False
                            Me.btnLoadAdvance.Enabled = False
                            Me.tbtnSave.Enabled = False
                            Me.tbtnDel.Enabled = False
                        Else
                            Me.btnPost.Visible = False
                            'Me.btnUnPost.Visible = False
                            Me.btnApprove.Visible = True
                            Me.btnDisApprove.Visible = False
                            Me.DgvTrnVoidAdvance.AllowUserToDeleteRows = True
                            Me.btnLoadAdvance.Enabled = True
                            Me.tbtnSave.Enabled = True
                            Me.tbtnDel.Enabled = True
                        End If
                    End If
                End If

                If Me.DgvTrnVoid.CurrentRow IsNot Nothing Then
                    Me.uiTrnVoid_OpenRow(Me.DgvTrnVoid.CurrentRow.Index)
                Else
                    Me.uiTrnVoid_NewData()
                End If
        End Select
    End Sub

    Private Sub DgvTrnVoid_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvTrnVoid.CellDoubleClick
        If e.ColumnIndex < 0 Or e.RowIndex < 0 Then
            Exit Sub
        End If
        If Me.DgvTrnVoid.CurrentRow IsNot Nothing Then
            Me.ftabMain.SelectedIndex = 1
        End If
    End Sub

    Private Sub btnLoadAdvance_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadAdvance.Click
        Me.DialogOpen_Reference_Advance_PV()
    End Sub

    Private Function AdvanceDetailRowDelete(ByVal id As String)
        Dim row As DataRow
        If id <> "" And Me.tbl_TrnVoidAdvanceDetil.DefaultView.Count > 0 Then
            For Each row In Me.tbl_TrnVoidAdvanceDetil.Rows
                If row.RowState <> DataRowState.Deleted Then
                    If row.Item("jurnal_id") = id Then
                        row.Delete()
                        Me.AdvanceDetailRowDelete(id)
                        Exit For
                    End If
                End If
            Next
        End If
        Return True
    End Function

    Private Sub DgvTrnVoidAdvance_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles DgvTrnVoidAdvance.UserDeletingRow
        Me.AdvanceDetailRowDelete(e.Row.Cells("ref").Value)
    End Sub

    Private Sub btnApprove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApprove.Click, btnDisApprove.Click, btnPost.Click, btnUnPost.Click
        System.Windows.Forms.Cursor.Current = Cursors.WaitCursor
        If Me.uiTrnVoid_CheckValid() Then
            System.Windows.Forms.Cursor.Current = Cursors.Default
            Exit Sub
        End If

        Dim btn As ToolStripButton = sender
        Dim dbconn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbcmd As OleDb.OleDbCommand
        Dim id As String = Me.obj_Void_id.Text

        Select Case btn.Name
            Case "btnApprove"
                dbcmd = New OleDb.OleDbCommand("act_TrnVoid_Approve", dbconn)
                dbcmd.Parameters.Add("@id", OleDb.OleDbType.VarChar, 12)
                dbcmd.Parameters.Add("@by", OleDb.OleDbType.VarChar)
                dbcmd.Parameters.Add("@dt", OleDb.OleDbType.DBDate)
                dbcmd.Parameters("@id").Value = id
                dbcmd.Parameters("@by").Value = Me.UserName
                dbcmd.Parameters("@dt").Value = Now()
                dbcmd.CommandType = CommandType.StoredProcedure

                Dim cookie As Byte() = Nothing

                Try
                    dbconn.Open()
                    clsApplicationRole.SetAppRole(dbconn, cookie)
                    dbcmd.ExecuteNonQuery()
                    Me.tbtnSave.Enabled = False
                    Me.tbtnDel.Enabled = False
                    Me.btnApprove.Visible = False
                    Me.btnDisApprove.Visible = True
                    Me.btnPost.Visible = True
                    Me.btnUnPost.Visible = False
                    Me.DgvTrnVoidAdvance.AllowUserToDeleteRows = False
                    Me.btnLoadAdvance.Enabled = False
                    Me.DgvTrnVoid.Item("void_approved", Me.DgvTrnVoid.CurrentRow.Index).Value = True
                Catch ex As Data.OleDb.OleDbException
                    MessageBox.Show(ex.Message, "OLE DB Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "OLE DB Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Finally
                    MessageBox.Show("Void has been successfully approved", "Approving Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.obj_Approved_by.Text = Me.UserName
                    Me.obj_Approved_dt.Text = Now()
                    Me.uiTrnVoid_Save()
                    clsApplicationRole.UnsetAppRole(dbconn, cookie)
                    dbconn.Close()
                    Me.DgvTrnVoid.Refresh()
                End Try

            Case "btnDisApprove"
                dbcmd = New OleDb.OleDbCommand("act_TrnVoid_Disapprove", dbconn)
                dbcmd.Parameters.Add("@id", OleDb.OleDbType.VarChar, 12)
                dbcmd.Parameters.Add("@by", OleDb.OleDbType.VarChar)
                dbcmd.Parameters.Add("@dt", OleDb.OleDbType.DBDate)
                dbcmd.Parameters("@id").Value = id
                dbcmd.Parameters("@by").Value = Me.UserName
                dbcmd.Parameters("@dt").Value = Now()
                dbcmd.CommandType = CommandType.StoredProcedure

                Dim cookie As Byte() = Nothing

                Try
                    dbconn.Open()
                    clsApplicationRole.SetAppRole(dbconn, cookie)
                    dbcmd.ExecuteNonQuery()
                    Me.tbtnSave.Enabled = True
                    Me.tbtnDel.Enabled = True
                    Me.btnApprove.Visible = True
                    Me.btnDisApprove.Visible = False
                    Me.btnPost.Visible = False
                    Me.btnUnPost.Visible = False
                    Me.DgvTrnVoidAdvance.AllowUserToDeleteRows = True
                    Me.btnLoadAdvance.Enabled = True
                    Me.DgvTrnVoid.Item("void_approved", Me.DgvTrnVoid.CurrentRow.Index).Value = False

                Catch ex As Data.OleDb.OleDbException
                    MessageBox.Show(ex.Message, "OLE DB Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "OLE DB Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Finally
                    MessageBox.Show("Void has been successfully disapproved", "Disapproving Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.obj_Approved_by.Text = String.Empty
                    Me.obj_Approved_dt.Text = String.Empty
                    Me.uiTrnVoid_Save()
                    clsApplicationRole.UnsetAppRole(dbconn, cookie)
                    dbconn.Close()
                    Me.DgvTrnVoid.Refresh()
                End Try

            Case "btnPost"
                Dim tanya As String = MsgBox("Are you sure to post this void ?", MsgBoxStyle.YesNo, "Confirmation")

                If tanya = MsgBoxResult.Yes Then
                    dbcmd = New OleDb.OleDbCommand("act_TrnVoid_Post", dbconn)
                    dbcmd.Parameters.Add("@id", OleDb.OleDbType.VarChar, 12)
                    dbcmd.Parameters.Add("@by", OleDb.OleDbType.VarChar)
                    dbcmd.Parameters.Add("@dt", OleDb.OleDbType.DBDate)
                    dbcmd.Parameters("@id").Value = id
                    dbcmd.Parameters("@by").Value = Me.UserName
                    dbcmd.Parameters("@dt").Value = Now()
                    dbcmd.CommandType = CommandType.StoredProcedure

                    Dim cookie As Byte() = Nothing

                    Try
                        dbconn.Open()
                        clsApplicationRole.SetAppRole(dbconn, cookie)
                        dbcmd.ExecuteNonQuery()
                        Me.btnApprove.Visible = False
                        Me.btnDisApprove.Visible = False
                        Me.btnPost.Visible = False
                        Me.btnUnPost.Visible = False
                        Me.DgvTrnVoid.Item("void_posted", Me.DgvTrnVoid.CurrentRow.Index).Value = True
                    Catch ex As Data.OleDb.OleDbException
                        MessageBox.Show(ex.Message, "OLE DB Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Catch ex As Exception
                        MessageBox.Show(ex.Message, "OLE DB Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Finally
                        MessageBox.Show("Void has been successfully posted", "Posting Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.obj_Posted_by.Text = Me.UserName
                        Me.obj_Posted_dt.Text = Now()
                        Me.uiTrnVoid_Save()
                        clsApplicationRole.UnsetAppRole(dbconn, cookie)
                        dbconn.Close()
                        Me.DgvTrnVoid.Refresh()
                    End Try
                Else
                    Exit Sub
                End If

            Case "btnUnPost"
                '============= VOID TIDAK BOLEH DIUNPOST BAHAYA !, TANYA SEJAK KAPAN ? , JAWABNYA SEJAK ZAMAN FIRAUN MAEN GUNDU TITIK ============
                'dbcmd = New OleDb.OleDbCommand("act_TrnVoid_UnPost", dbconn)
                'dbcmd.Parameters.Add("@id", OleDb.OleDbType.VarChar, 12)
                'dbcmd.Parameters("@id").Value = id
                'dbcmd.CommandType = CommandType.StoredProcedure

                'Try
                '    dbconn.Open()
                '    dbcmd.ExecuteNonQuery()
                '    Me.btnApprove.Visible = False
                '    Me.btnDisApprove.Visible = True
                '    Me.btnPost.Visible = True
                '    Me.btnUnPost.Visible = False
                '    Me.DgvTrnVoid.Item("void_posted", Me.DgvTrnVoid.CurrentRow.Index).Value = False
                'Catch ex As Data.OleDb.OleDbException
                '    MessageBox.Show(ex.Message, "OLE DB Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                'Catch ex As Exception
                '    MessageBox.Show(ex.Message, "OLE DB Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                'Finally
                '    MessageBox.Show("Void has been successfully unposted", "UnPosting Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                '    Me.obj_Posted_by.Text = String.Empty
                '    Me.obj_Posted_dt.Text = String.Empty
                '    Me.uiTrnVoid_Save()
                '    dbconn.Close()
                '    Me.DgvTrnVoid.Refresh()
                'End Try

        End Select
    End Sub

    Private Sub DgvTrnVoid_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DgvTrnVoid.CellFormatting
        Dim approved As Boolean
        Dim posted As Boolean
        Dim obj As DataGridView = sender
        Dim objRow As System.Windows.Forms.DataGridViewRow = obj.Rows(e.RowIndex)
        Try
            posted = CBool(objRow.Cells("void_posted").Value)
            If posted Then
                objRow.DefaultCellStyle.BackColor = Color.CornflowerBlue
                objRow.DefaultCellStyle.SelectionBackColor = Color.CornflowerBlue
                objRow.DefaultCellStyle.SelectionForeColor = Color.White
            Else
                approved = CBool(objRow.Cells("void_approved").Value)
                If approved Then
                    objRow.DefaultCellStyle.BackColor = Color.DarkMagenta
                    objRow.DefaultCellStyle.SelectionBackColor = Color.DarkMagenta
                Else
                    objRow.DefaultCellStyle.BackColor = Color.White
                End If
            End If

        Catch ex As Exception
        End Try
    End Sub

End Class