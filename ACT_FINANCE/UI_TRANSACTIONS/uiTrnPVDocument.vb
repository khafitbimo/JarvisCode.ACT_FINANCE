
Public Class uiTrnPVDocument
    Private Const mUiName As String = "Transaksi PV Document"

    Private Event FormBeforeOpenRow(ByRef id As Object)
    Private Event FormAfterOpenRow(ByRef id As Object)
    Private Event FormBeforeSave(ByRef id As Object)
    Private Event FormAfterSave(ByRef id As Object, ByVal result As FormSaveResult)
    Private Event FormBeforeNew()
    Private Event FormBeforeDelete(ByRef id As Object)
    Private Event FormAfterDelete(ByRef id As Object)
    Private FILTER_QUERY_MODE As Boolean
    Private DATA_ISLOCKED As Boolean

    'Table For Search
    Private tbl_MstChannelSearch As DataTable = clsDataset.CreateTblMstChannelCombo()

    Private isLoadComboInLoadData As Boolean = False
    Private dt_default_channel As DataTable = New DataTable
    Private tbl_TrnPVDocument As New DataTable


#Region " Window Parameter "
    ' TODO: Buat variabel untuk menampung parameter window 
    Private _CHANNEL As String = "NTV"
    Private _CHANNEL_CANBE_CHANGED As Boolean = False
    Private _CHANNEL_CANBE_BROWSED As Boolean = False
#End Region

    Public Sub defaultChannel()
        Me.DataFill(dt_default_channel, "act_select_channel_reference_default", "channel_default = 1 and channel_id = '" & Me._CHANNEL & "' ")
    End Sub

#Region " Overrides "
    Public Overrides Function btnLoad_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnPVDocument_Retrieve()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnLoad_Click()
    End Function

    Public Overrides Function btnQuery_Click() As Boolean
        Me.PnlDfSearch.Visible = Not Me.PnlDfSearch.Visible
        If Me.PnlDfSearch.Visible Then
            Me.tbtnQuery.CheckState = CheckState.Checked
        Else
            Me.tbtnQuery.CheckState = CheckState.Unchecked
        End If
        Return MyBase.btnQuery_Click()
    End Function

    Public Overrides Function btnPrint_Click() As Boolean
        'Me.Cursor = Cursors.WaitCursor
        ''Me.uiTrnPVDocument_Print()
        'Me.Cursor = Cursors.Arrow
        'Return MyBase.btnPrint_Click()
    End Function

    Public Overrides Function btnPrintPreview_Click() As Boolean
        'Me.Cursor = Cursors.WaitCursor
        ''Me.uiTrnPVDocument_PrintPreview()
        'Me.Cursor = Cursors.Arrow
        'Return MyBase.btnPrint_Click()
    End Function
#End Region

#Region " Layout & Init UI "
    Private Function FormatDgvTrnPVDocument(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        ' Format DgvTrnVoid Columns 
        Dim cChannel_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnal_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cDoc_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cDoc_status As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cPost_by As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cPost_dt As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cUnpost_by As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cUnpost_dt As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cVoid_by As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cVoid_dt As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn

        cChannel_id.Name = "channel_id"
        cChannel_id.HeaderText = "Company"
        cChannel_id.DataPropertyName = "channel_id"
        cChannel_id.Width = 100
        cChannel_id.Visible = False
        cChannel_id.ReadOnly = True

        cJurnal_id.Name = "jurnal_id"
        cJurnal_id.HeaderText = "Jurnal ID"
        cJurnal_id.DataPropertyName = "jurnal_id"
        cJurnal_id.Width = 100
        cJurnal_id.Visible = True
        cJurnal_id.ReadOnly = False

        cDoc_id.Name = "doc_id"
        cDoc_id.HeaderText = "Document ID"
        cDoc_id.DataPropertyName = "doc_id"
        cDoc_id.Width = 100
        cDoc_id.Visible = True
        cDoc_id.ReadOnly = False

        cDoc_status.Name = "doc_status"
        cDoc_status.HeaderText = "Document Status"
        cDoc_status.DataPropertyName = "doc_status"
        cDoc_status.Width = 120
        cDoc_status.Visible = True
        cDoc_status.ReadOnly = False

        cPost_by.Name = "post_by"
        cPost_by.HeaderText = "Posted By"
        cPost_by.DataPropertyName = "post_by"
        cPost_by.Width = 100
        cPost_by.Visible = True
        cPost_by.ReadOnly = False

        cPost_dt.Name = "post_dt"
        cPost_dt.HeaderText = "Posted Date"
        cPost_dt.DataPropertyName = "post_dt"
        cPost_dt.Width = 100
        cPost_dt.Visible = True
        cPost_dt.ReadOnly = False

        cUnpost_by.Name = "unpost_by"
        cUnpost_by.HeaderText = "Unposted By"
        cUnpost_by.DataPropertyName = "unpost_by"
        cUnpost_by.Width = 100
        cUnpost_by.Visible = True
        cUnpost_by.ReadOnly = False

        cUnpost_dt.Name = "unpost_dt"
        cUnpost_dt.HeaderText = "Unposted Date"
        cUnpost_dt.DataPropertyName = "unpost_dt"
        cUnpost_dt.Width = 120
        cUnpost_dt.Visible = True
        cUnpost_dt.ReadOnly = False

        cVoid_by.Name = "void_by"
        cVoid_by.HeaderText = "Void By"
        cVoid_by.DataPropertyName = "void_by"
        cVoid_by.Width = 100
        cVoid_by.Visible = True
        cVoid_by.ReadOnly = False

        cVoid_dt.Name = "void_dt"
        cVoid_dt.HeaderText = "Void Date"
        cVoid_dt.DataPropertyName = "void_dt"
        cVoid_dt.Width = 100
        cVoid_dt.Visible = True
        cVoid_dt.ReadOnly = False



        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
        {cChannel_id, cJurnal_id, cDoc_id, cDoc_status, cPost_by, cPost_dt, cUnpost_by, cUnpost_dt, cVoid_by, cVoid_dt})



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

        Me.PnlDfSearch.Dock = DockStyle.Top
        Me.PnlDfSearch.Visible = False
        Me.PnlDfMain.Dock = DockStyle.Fill

        Me.FormatDgvTrnPVDocument(Me.DgvTrnPVDocument)

    End Function

    Private Sub uiTrnJurnal_PV_List_AP_LoadComboBox()
        If Me.isLoadComboInLoadData = False Then

            Me.ComboFill(Me.cboSearchChannel, "channel_id", "channel_name", Me.tbl_MstChannelSearch, "ms_MstChannelCombo_Select", " channel_id = '" & Me._CHANNEL & "' ")
            Me.tbl_MstChannelSearch.DefaultView.Sort = "channel_name"

            Me.isLoadComboInLoadData = True
        End If
    End Sub
#End Region

#Region " User Defined Function "
    Private Function uiTrnPVDocument_Retrieve() As Boolean
        'retrieve data
        Dim criteria As String = ""
        Dim txtSearchCriteria As String = ""
        Dim txtSQLSearch As String = "channel_id = '" & Me._CHANNEL & "'"


        'If Me.FILTER_QUERY_MODE Then
        '-- JurnalID
        If Me.chkType.Checked Then
            txtSearchCriteria = "jurnal_id like'%" + cbSearchType.Text + "%'"
            If txtSQLSearch = "" Then
                txtSQLSearch = txtSearchCriteria
            Else
                txtSQLSearch = txtSQLSearch & " AND " & txtSearchCriteria
            End If
        End If

        If Me.chkSearchJurnalID.Checked Then
            txtSearchCriteria = clsUtil.RefParser("jurnal_id", Me.txtSearchJurnalID)
            If txtSQLSearch = "" Then
                txtSQLSearch = txtSearchCriteria
            Else
                txtSQLSearch = txtSQLSearch & " AND " & txtSearchCriteria
            End If
        End If

        If Me.chkSearchDocId.Checked Then
            txtSearchCriteria = clsUtil.RefParser("doc_id", Me.txtSearchDocId)
            If txtSQLSearch = "" Then
                txtSQLSearch = txtSearchCriteria
            Else
                txtSQLSearch = txtSQLSearch & " AND " & txtSearchCriteria
            End If
        End If

        If Me.chkSearchDocStatus.Checked Then
            txtSearchCriteria = " doc_status = '" & cboSearchDocStatus.SelectedText & "' "
            If txtSQLSearch = "" Then
                txtSQLSearch = txtSearchCriteria
            Else
                txtSQLSearch = txtSQLSearch & " AND " & txtSearchCriteria
            End If
        End If

        criteria = txtSQLSearch

        Me.tbl_TrnPVDocument.Clear()
        Try
            Me.DataFill(Me.tbl_TrnPVDocument, "act_TrnJurnalDocument_Select", criteria)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Function
#End Region

    Public Sub Form_Load(ByVal sender As Object)
        Dim objParameters As Collection = New Collection

        'TODO: - Extract Parameter
        '      - Assign parameter
        If Me.Browser IsNot Nothing Then
            objParameters = Me.GetParameterCollection(Me.Parameter)
            Me._CHANNEL = Me.GetValueFromParameter(objParameters, "CHANNEL") 'Me.GetValueFromParameter(objParameters, "CHANNEL")
            Me._CHANNEL_CANBE_CHANGED = False 'Me.GetBolValueFromParameter(objParameters, "CHANNELCHANGED")
            Me._CHANNEL_CANBE_BROWSED = False 'Me.GetBolValueFromParameter(objParameters, "CHANNELBROWSED")
        End If

        If (Me.Browser IsNot Nothing And MyBase.Name = _Name) Or (Me.Browser Is Nothing And Application.ProductName <> _ProductName) Then
            'Fill Combobox
            'dan fungsi2 startup lainnya....
            Me.InitLayoutUI()
            Me.uiTrnJurnal_PV_List_AP_LoadComboBox()

            Me.DgvTrnPVDocument.DataSource = Me.tbl_TrnPVDocument
            Me.chkSearchChannel.Checked = Not Me._CHANNEL_CANBE_CHANGED
            Me.chkSearchChannel.Enabled = Me._CHANNEL_CANBE_BROWSED
            Me.cboSearchChannel.Enabled = Me._CHANNEL_CANBE_BROWSED
            Me.cboSearchChannel.SelectedValue = Me._CHANNEL

            Me.tbtnNew.Enabled = False
            Me.tbtnSave.Enabled = False
            Me.tbtnDel.Enabled = False
            Me.tbtnLoad.Enabled = True
            Me.tbtnQuery.Enabled = True
            Me.tbtnNext.Visible = False
            Me.tbtnPrev.Visible = False
            Me.tbtnLast.Visible = False
            Me.tbtnFirst.Visible = False
            Me.ToolStripSeparator4.Visible = False
        End If
    End Sub

    Private Sub uiTrnVoid_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Me.IsDevelopment = True Then Me.Form_Load(sender)
    End Sub

    Private Sub chkSearchDocId_CheckedChanged(sender As Object, e As EventArgs) Handles chkSearchDocId.CheckedChanged
        If chkSearchDocId.Checked = True Then
            txtSearchDocId.Enabled = True
        Else
            txtSearchDocId.Enabled = False
        End If
    End Sub

    Private Sub chkSearchDocStatus_CheckedChanged(sender As Object, e As EventArgs) Handles chkSearchDocStatus.CheckedChanged
        If chkSearchDocStatus.Checked = True Then
            cboSearchDocStatus.Enabled = True
        Else
            cboSearchDocStatus.Enabled = False
        End If

    End Sub

    Private Sub chkType_CheckedChanged(sender As Object, e As EventArgs) Handles chkType.CheckedChanged
        If chkType.Checked = True Then
            cbSearchType.Enabled = True
        Else
            cbSearchType.Enabled = False
        End If
    End Sub
End Class