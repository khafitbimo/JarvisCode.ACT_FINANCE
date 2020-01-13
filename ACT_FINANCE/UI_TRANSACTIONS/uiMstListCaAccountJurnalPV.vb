Imports System.ComponentModel


Public Class uiMstListCaAccountJurnalPV
    Private Const mUiName As String = "List CA Account Journal PV"
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
    Private isLoadComboInLoadData As Boolean = False

    Friend WithEvents btnExcel As ToolStripButton = New ToolStripButton

    Private objFormError As Windows.Forms.ErrorProvider = New Windows.Forms.ErrorProvider

    Private objPrintDetil As DataSource.clsRptVoid
    Private objDatalistDetil As ArrayList
    Private label_thread As String

    'object for message when excel exporting
    Private filtering As Boolean

    Private tbl_MstAcc_ca As DataTable = clsDataset.CreateTblMstAccountCaCombo()
    Private tbl_MstChannelSearch As DataTable = clsDataset.CreateTblMstChannelCombo()
    Private tbl_MstRekanan As DataTable = clsDataset.CreateTblMstRekananCombo()
    Private tbl_TrnBudget As DataTable = clsDataset.CreateTblMstBudgetCombo()
    Private tbl_MstPeriodeSearch As DataTable = clsDataset.CreateTblMstPeriodeCombo()

    Private tbl_ListCaAccountJurnalPV As DataTable = clsDataset.CreateTblListCaAccountJurnalPV()


#Region " Window Parameter "
    ' TODO: Buat variabel untuk menampung parameter window 
    Private _CHANNEL As String = "TAS"
    Private _CHANNEL_CANBE_CHANGED As Boolean = False
    Private _CHANNEL_CANBE_BROWSED As Boolean = False
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

    End Function

    Public Overrides Function btnLoad_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiMstListCaAccountJurnalPV_Retrieve()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnLoad_Click()
    End Function

    Public Overrides Function btnSave_Click() As Boolean

    End Function

    Public Overrides Function btnPrint_Click() As Boolean

    End Function

    Public Overrides Function btnPrintPreview_Click() As Boolean

    End Function

    Public Overrides Function btnDel_Click() As Boolean

    End Function

    Public Overrides Function btnFirst_Click() As Boolean

    End Function

    Public Overrides Function btnPrev_Click() As Boolean

    End Function

    Public Overrides Function btnNext_Click() As Boolean

    End Function

    Public Overrides Function btnLast_Click() As Boolean

    End Function


#End Region

#Region " Layout & Init UI "

    Private Function FormatDgvListCaAccount(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        ' Format DgvTrnVoid Columns 
        Dim cChannel_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTglBookdate As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnal_ID As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnal_Desc As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAccCa_ID As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAccCa_Desc As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cPeriode_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cPeriode_name As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekanan_ID As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekanan_Name As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnalID_ref As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBudget_ID As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBudget_Name As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn

        cChannel_id.Name = "channel_id"
        cChannel_id.HeaderText = "Channel ID"
        cChannel_id.DataPropertyName = "channel_id"
        cChannel_id.Width = 100
        cChannel_id.Visible = False
        cChannel_id.ReadOnly = False

        cTglBookdate.Name = "jurnal_bookdate"
        cTglBookdate.HeaderText = "Bookdate"
        cTglBookdate.DataPropertyName = "jurnal_bookdate"
        cTglBookdate.Width = 100
        cTglBookdate.Visible = True
        cTglBookdate.ReadOnly = False

        cJurnal_ID.Name = "jurnal_id"
        cJurnal_ID.HeaderText = "Jurnal ID"
        cJurnal_ID.DataPropertyName = "jurnal_id"
        cJurnal_ID.Width = 100
        cJurnal_ID.Visible = True
        cJurnal_ID.ReadOnly = False

        cJurnal_Desc.Name = "jurnaldetil_descr"
        cJurnal_Desc.HeaderText = "Desc."
        cJurnal_Desc.DataPropertyName = "jurnaldetil_descr"
        cJurnal_Desc.Width = 250
        cJurnal_Desc.Visible = True
        cJurnal_Desc.ReadOnly = False

        cAccCa_ID.Name = "acc_ca_id"
        cAccCa_ID.HeaderText = "Acc ca id"
        cAccCa_ID.DataPropertyName = "acc_ca_id"
        cAccCa_ID.Width = 100
        cAccCa_ID.Visible = True
        cAccCa_ID.ReadOnly = False

        cAccCa_Desc.Name = "acc_ca_descr"
        cAccCa_Desc.HeaderText = "Acc Ca Name"
        cAccCa_Desc.DataPropertyName = "acc_ca_descr"
        cAccCa_Desc.Width = 150
        cAccCa_Desc.Visible = True
        cAccCa_Desc.ReadOnly = False

        cPeriode_id.Name = "periode_id"
        cPeriode_id.HeaderText = "Period"
        cPeriode_id.DataPropertyName = "periode_id"
        cPeriode_id.Width = 100
        cPeriode_id.Visible = False
        cPeriode_id.ReadOnly = False

        cPeriode_name.Name = "periode_name"
        cPeriode_name.HeaderText = "Period"
        cPeriode_name.DataPropertyName = "periode_name"
        cPeriode_name.Width = 100
        cPeriode_name.Visible = True
        cPeriode_name.ReadOnly = True


        cRekanan_ID.Name = "rekanan_id"
        cRekanan_ID.HeaderText = "Rekanan ID"
        cRekanan_ID.DataPropertyName = "rekanan_id"
        cRekanan_ID.Width = 100
        cRekanan_ID.Visible = True
        cRekanan_ID.ReadOnly = False

        cRekanan_Name.Name = "rekanan_name"
        cRekanan_Name.HeaderText = "Partner"
        cRekanan_Name.DataPropertyName = "rekanan_name"
        cRekanan_Name.Width = 150
        cRekanan_Name.Visible = True
        cRekanan_Name.ReadOnly = False

        cJurnalID_ref.Name = "jurnal_id_ref"
        cJurnalID_ref.HeaderText = "Ref ID"
        cJurnalID_ref.DataPropertyName = "jurnal_id_ref"
        cJurnalID_ref.Width = 100
        cJurnalID_ref.Visible = True
        cJurnalID_ref.ReadOnly = False

        cBudget_ID.Name = "budget_id"
        cBudget_ID.HeaderText = "Budget Id"
        cBudget_ID.DataPropertyName = "budget_id"
        cBudget_ID.Width = 100
        cBudget_ID.Visible = True
        cBudget_ID.ReadOnly = False

        cBudget_Name.Name = "budget_name"
        cBudget_Name.HeaderText = "Budget Name"
        cBudget_Name.DataPropertyName = "budget_name"
        cBudget_Name.Width = 250
        cBudget_Name.Visible = True
        cBudget_Name.ReadOnly = False



        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
        {cChannel_id, cTglBookdate, cJurnal_ID, cJurnal_Desc, cAccCa_ID, cAccCa_Desc, cPeriode_id, cPeriode_name, cRekanan_ID, cRekanan_Name, cJurnalID_ref, cBudget_ID, cBudget_Name})



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
        Me.DgvListCaAccount_JournalPv.Dock = DockStyle.Fill

        Me.FormatDgvListCaAccount(Me.DgvListCaAccount_JournalPv)

    End Function


#End Region


#Region " User Defined Function "

    Private Function uiMstListCaAccountJurnalPV_NewData() As Boolean
        'new data

    End Function

    Private Function uiMstListCaAccountJurnalPV_Retrieve() As Boolean
        'retrieve data
        Dim txtSearchCriteria As String = ""
        Dim txtSQLSearch As String = String.Format(" channel_id = '{0}'", Me._CHANNEL)
        Dim criteria As String = ""

        Me.filtering = False
        If Me.chkSearchJurnalID.Checked Then
            txtSearchCriteria = clsUtil.RefParser("jurnal_id", Me.txtSearchJurnalID)
            If txtSQLSearch = "" Then
                txtSQLSearch = " (" & txtSearchCriteria & ") "
            Else
                txtSQLSearch = txtSQLSearch & " AND " & " (" & txtSearchCriteria & ") "
            End If
            Me.filtering = True
        End If

        If Me.chkSearchRekanan.Checked Then
            If txtSQLSearch = "" Then
                txtSQLSearch = String.Format(" rekanan_id = '{0}' ", txtSearchRekananID.Text)
            Else
                txtSQLSearch = txtSQLSearch & " AND " & String.Format(" rekanan_id = '{0}' ", txtSearchRekananID.Text)
            End If
            Me.filtering = True
        End If

        If Me.chkSearchAccCa.Checked Then
            If txtSQLSearch = "" Then
                txtSQLSearch = String.Format(" acc_ca_id = '{0}' ", obj_Acc_ca_id.SelectedValue)
            Else
                txtSQLSearch = txtSQLSearch & " AND " & String.Format(" acc_ca_id = '{0}' ", obj_Acc_ca_id.SelectedValue)
            End If
            Me.filtering = True
        End If

        If Me.chkBudgetId.Checked Then
            If txtSQLSearch = "" Then
                txtSQLSearch = String.Format(" budget_id = '{0}' ", obj_Budget_id.SelectedValue)
            Else
                txtSQLSearch = txtSQLSearch & " AND " & String.Format(" budget_id = '{0}' ", obj_Budget_id.SelectedValue)
            End If
            Me.filtering = True
        End If

        If Me.chkSearchPeriode.Checked Then
            If txtSQLSearch = "" Then
                txtSQLSearch = String.Format(" periode_id = '{0}' ", cbo_periodeSearch.SelectedValue)
            Else
                txtSQLSearch = txtSQLSearch & " AND " & String.Format(" periode_id = '{0}' ", cbo_periodeSearch.SelectedValue)
            End If
            Me.filtering = True
        End If

        If Me.chkSrcRefid.Checked Then
            txtSearchCriteria = clsUtil.RefParser("jurnal_id_ref", Me.obj_srcRefID)
            If txtSQLSearch = "" Then
                txtSQLSearch = " (" & txtSearchCriteria & ") "
            Else
                txtSQLSearch = txtSQLSearch & " AND " & " (" & txtSearchCriteria & ") "
            End If
            Me.filtering = True
        End If

        criteria = txtSQLSearch
        Me.tbl_ListCaAccountJurnalPV.Clear()
        Try
            Me.DataFill(Me.tbl_ListCaAccountJurnalPV, "Trn_ListCaAccount_JournalPv", criteria)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Function

    Private Function uiMstListCaAccountJurnalPV_Save() As Boolean
        'save data

    End Function

    Private Function uiMstListCaAccount_exportToExcel() As Boolean

        If Me.tbl_ListCaAccountJurnalPV.Rows.Count - 1 > 65534 Then
            MessageBox.Show("The row number is exceed the limit of maximum Ms-Excel`s row.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else

            Dim ColumnIndex As Integer = 0
            Dim RowIndex As Integer = 0
            Dim xl As Excel.Application = New Excel.Application
            Dim xlBook As Excel.Workbook = xl.Workbooks.Add
            Dim xlWorksheet As Excel.Worksheet = CType(xlBook.Worksheets(1), Excel.Worksheet)

            xl.Visible = False

            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

            Try
                xlWorksheet.Cells(1, 1).Value = "Jurnal ID"
                xlWorksheet.Cells(1, 2).Value = "Bookdate"
                xlWorksheet.Cells(1, 3).Value = "Desc."
                xlWorksheet.Cells(1, 4).Value = "Ca Account"
                xlWorksheet.Cells(1, 5).Value = "Partner"
                xlWorksheet.Cells(1, 6).Value = "Jurnal Ref ID"
                xlWorksheet.Cells(1, 7).Value = "Budget"

                For Each row As System.Data.DataRow In Me.tbl_ListCaAccountJurnalPV.Rows
                    RowIndex = RowIndex + 1
                    ColumnIndex = 0

                    If Mid(row.Item("jurnal_id").ToString, 1, 1) = "=" Then xlWorksheet.Cells(RowIndex + 1, 1).Value = "'" & row.Item("jurnal_id").ToString Else xlWorksheet.Cells(RowIndex + 1, 1).Value = row.Item("jurnal_id").ToString

                    If Mid(row.Item("jurnal_bookdate").ToString, 1, 1) = "=" Then xlWorksheet.Cells(RowIndex + 1, 2).Value = "'" & row.Item("jurnal_bookdate").ToString Else xlWorksheet.Cells(RowIndex + 1, 2).Value = row.Item("jurnal_bookdate").ToString


                    If Mid(row.Item("jurnaldetil_descr").ToString, 1, 1) = "=" Then xlWorksheet.Cells(RowIndex + 1, 3).Value = "'" & row.Item("jurnaldetil_descr").ToString Else xlWorksheet.Cells(RowIndex + 1, 3).Value = row.Item("jurnaldetil_descr").ToString

                    If Mid(row.Item("acc_ca_descr").ToString, 1, 1) = "=" Then xlWorksheet.Cells(RowIndex + 1, 4).Value = "'" & row.Item("acc_ca_descr").ToString Else xlWorksheet.Cells(RowIndex + 1, 4).Value = row.Item("acc_ca_descr").ToString

                    If Mid(row.Item("rekanan_name").ToString, 1, 1) = "=" Then xlWorksheet.Cells(RowIndex + 1, 4).Value = "'" & row.Item("rekanan_name").ToString Else xlWorksheet.Cells(RowIndex + 1, 4).Value = row.Item("rekanan_name").ToString

                    If Mid(row.Item("jurnal_id_ref").ToString, 1, 1) = "=" Then xlWorksheet.Cells(RowIndex + 1, 6).Value = "'" & row.Item("jurnal_id_ref").ToString Else xlWorksheet.Cells(RowIndex + 1, 6).Value = row.Item("jurnal_id_ref").ToString

                    If Mid(row.Item("budget_name").ToString, 1, 1) = "=" Then xlWorksheet.Cells(RowIndex + 1, 7).Value = "'" & row.Item("budget_name").ToString Else xlWorksheet.Cells(RowIndex + 1, 7).Value = row.Item("budget_name").ToString

                Next
                MessageBox.Show("Export Complete", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                xl.Visible = True
            Catch ex As Exception
                MessageBox.Show("Error" & vbCrLf & ex.Message)
            End Try
        End If


    End Function

#End Region

    Public Sub Form_Load(ByVal sender As Object)
        Dim objParameters As Collection = New Collection

        'TODO: - Extract Parameter
        '      - Assign parameter
        If Me.Browser IsNot Nothing Then
            objParameters = Me.GetParameterCollection(Me.Parameter)
            Me._CHANNEL = Me.GetValueFromParameter(objParameters, "CHANNEL")
        End If

        If (Me.Browser IsNot Nothing And MyBase.Name = _Name) Or (Me.Browser Is Nothing And Application.ProductName <> _ProductName) Then
            'Fill Combobox
            'dan fungsi2 startup lainnya....
            Me.InitLayoutUI()

            Me.DgvListCaAccount_JournalPv.DataSource = Me.tbl_ListCaAccountJurnalPV

            Me.uiMstListCaAccountJurnalPV_LoadComboBox()

            Me.uiMstListCaAccountJurnalPV_NewData()
            Me.chkSearchChannel.Checked = Not Me._CHANNEL_CANBE_CHANGED
            Me.chkSearchChannel.Enabled = Me._CHANNEL_CANBE_BROWSED
            Me.cboSearchChannel.Enabled = Me._CHANNEL_CANBE_BROWSED
            Me.cboSearchChannel.SelectedValue = Me._CHANNEL

            For Each tsItem As ToolStripItem In Me.ToolStrip1.Items
                If tsItem.Name = "tbtnQuery" Or tsItem.Name = "tbtnLoad" Or tsItem.Name = "btnExcel" Then
                    tsItem.Enabled = True
                Else
                    tsItem.Enabled = False
                End If
            Next

            Me.btnExcel.Text = "Export Excel"
            Me.btnExcel.Name = "btnExcel"
            Me.btnExcel.Visible = True
            Me.btnExcel.Font = New Font(Me.btnExcel.Font, FontStyle.Bold)
            Me.ToolStrip1.Items.Add(Me.btnExcel)

            Me.Panel1.Visible = False
        End If
    End Sub

    Private Sub uiMstListCaAccountJurnalPV_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Me.IsDevelopment = True Then Me.Form_Load(sender)
    End Sub

    Private Sub btnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Click
        Dim res As String = ""
        Me.Cursor = Cursors.WaitCursor
        If Me.tbl_ListCaAccountJurnalPV.Rows.Count <= 0 Then
            MessageBox.Show("Cannot export empty table.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            If Not Me.filtering Then
                res = MessageBox.Show("Are you sure want to export data without filter ?", mUiName, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If res = DialogResult.Yes Then
                    'uiMstListCaAccount_exportToExcel()
                    uiTrnJurnal_PV_Advance_isBackgroudWorker()
                End If
            Else
                'uiMstListCaAccount_exportToExcel()
                uiTrnJurnal_PV_Advance_isBackgroudWorker()
            End If

        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub uiMstListCaAccountJurnalPV_LoadComboBox()
        If Me.isLoadComboInLoadData = False Then

            Me.ComboFill(Me.cboSearchChannel, "channel_id", "channel_name", Me.tbl_MstChannelSearch, "ms_MstChannelCombo_Select", " channel_id = '" & Me._CHANNEL & "' ")
            Me.tbl_MstChannelSearch.DefaultView.Sort = "channel_name"


            Me.ComboFillDec(Me.obj_Acc_ca_id, "acc_ca_id", "acc_ca_shortname", tbl_MstAcc_ca, "ms_MstAccountCaCombo_Select", "  acc_ca_type = 2  ")
            Me.tbl_MstAcc_ca.DefaultView.Sort = "acc_ca_shortname"

            Me.ComboFill(Me.cbo_periodeSearch, "periode_id", "periode_name", Me.tbl_MstPeriodeSearch, "ms_MstPeriodeCombo_Select", " channel_id = '" & Me._CHANNEL & "' ")
            Me.tbl_MstPeriodeSearch.DefaultView.Sort = "periode_name"

            Me.DataFill(Me.tbl_MstRekanan, "ms_MstRekanan_Select2", " rekanan_active = 1 ", Me._CHANNEL)

            Me.ComboFillDec(Me.obj_Budget_id, "budget_id", "budget_nameshort", Me.tbl_TrnBudget, "ms_MstBudgetCombo_Select", " budget_isactive = 1")

            Me.isLoadComboInLoadData = True
        End If
    End Sub

    Private Sub btn_Rekanan_Click(sender As Object, e As EventArgs) Handles btn_Rekanan.Click
        Dim dlg As dlgSearch = New dlgSearch()
        Dim retData As Collection
        Dim retObj As Object
        Dim rekanan_id As Decimal

        retObj = dlg.OpenDialog(Me, Me.tbl_MstRekanan, "rekanan")
        If retObj IsNot Nothing Then
            retData = CType(retObj, Collection)
            rekanan_id = CType(retData.Item("retId"), Decimal)
            Me.txtSearchRekananID.Text = rekanan_id
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Dim BG_Worker As BackgroundWorker = CType(sender, BackgroundWorker)
        If BG_Worker.CancellationPending Then
            e.Cancel = True
        Else
            Me.uiMstListCaAccount_exportingExcel_withProgress(BG_Worker)
        End If

    End Sub
    Private Sub BackgroundWorker1_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        obj_ProgressBar_backGroundWorker.Value = e.ProgressPercentage
        Me.lblLoading.Text = "Please Wait... Exporting Row " & Me.label_thread & " of " & tbl_ListCaAccountJurnalPV.Rows.Count.ToString
    End Sub
    Private Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        'Untuk Finishing BackgroundWorker
        Me.obj_ProgressBar_backGroundWorker.Visible = False
        Me.lblLoading.Visible = False
        Me.Panel1.Visible = False

        For Each tsItem As ToolStripItem In Me.ToolStrip1.Items
            If tsItem.Name = "tbtnQuery" Or tsItem.Name = "tbtnLoad" Or tsItem.Name = "btnExcel" Then
                tsItem.Enabled = True
            Else
                tsItem.Enabled = False
            End If
        Next

        Me.Cursor = Cursors.Arrow

    End Sub

    Private Sub uiMstListCaAccount_exportingExcel_withProgress(ByVal worker As BackgroundWorker)
        worker.WorkerReportsProgress = True

        If Me.tbl_ListCaAccountJurnalPV.Rows.Count - 1 > 65534 Then
            MessageBox.Show("The row number is exceed the limit of maximum Ms-Excel`s row.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else

            Dim ColumnIndex As Integer = 0
            Dim RowIndex As Integer = 0
            Dim xl As Excel.Application = New Excel.Application
            Dim xlBook As Excel.Workbook = xl.Workbooks.Add
            Dim xlWorksheet As Excel.Worksheet = CType(xlBook.Worksheets(1), Excel.Worksheet)

            xl.Visible = False


            Try
                xlWorksheet.Cells(1, 1).Value = "Jurnal ID"
                xlWorksheet.Cells(1, 2).Value = "Bookdate"
                xlWorksheet.Cells(1, 3).Value = "Desc."
                xlWorksheet.Cells(1, 4).Value = "Ca Account"
                xlWorksheet.Cells(1, 5).Value = "Partner"
                xlWorksheet.Cells(1, 6).Value = "Jurnal Ref ID"
                xlWorksheet.Cells(1, 7).Value = "Budget"

                For Each row As System.Data.DataRow In Me.tbl_ListCaAccountJurnalPV.Rows
                    RowIndex = RowIndex + 1
                    Me.label_thread = RowIndex.ToString
                    worker.ReportProgress((RowIndex / tbl_ListCaAccountJurnalPV.Rows.Count) * 100)
                    ColumnIndex = 0

                    If Mid(row.Item("jurnal_id").ToString, 1, 1) = "=" Then xlWorksheet.Cells(RowIndex + 1, 1).Value = "'" & row.Item("jurnal_id").ToString Else xlWorksheet.Cells(RowIndex + 1, 1).Value = row.Item("jurnal_id").ToString

                    If Mid(row.Item("jurnal_bookdate").ToString, 1, 1) = "=" Then xlWorksheet.Cells(RowIndex + 1, 2).Value = "'" & CDate(row.Item("jurnal_bookdate")).ToString("dd/MM/yyyy") Else xlWorksheet.Cells(RowIndex + 1, 2).Value = CDate(row.Item("jurnal_bookdate")).ToString("dd/MM/yyyy")

                    If Mid(row.Item("jurnaldetil_descr").ToString, 1, 1) = "=" Then xlWorksheet.Cells(RowIndex + 1, 3).Value = "'" & row.Item("jurnaldetil_descr").ToString Else xlWorksheet.Cells(RowIndex + 1, 3).Value = row.Item("jurnaldetil_descr").ToString

                    If Mid(row.Item("acc_ca_descr").ToString, 1, 1) = "=" Then xlWorksheet.Cells(RowIndex + 1, 4).Value = "'" & row.Item("acc_ca_descr").ToString Else xlWorksheet.Cells(RowIndex + 1, 4).Value = row.Item("acc_ca_descr").ToString

                    If Mid(row.Item("rekanan_name").ToString, 1, 1) = "=" Then xlWorksheet.Cells(RowIndex + 1, 5).Value = "'" & row.Item("rekanan_name").ToString Else xlWorksheet.Cells(RowIndex + 1, 5).Value = row.Item("rekanan_name").ToString

                    If Mid(row.Item("jurnal_id_ref").ToString, 1, 1) = "=" Then xlWorksheet.Cells(RowIndex + 1, 6).Value = "'" & row.Item("jurnal_id_ref").ToString Else xlWorksheet.Cells(RowIndex + 1, 6).Value = row.Item("jurnal_id_ref").ToString

                    If Mid(row.Item("budget_name").ToString, 1, 1) = "=" Then xlWorksheet.Cells(RowIndex + 1, 7).Value = "'" & row.Item("budget_name").ToString Else xlWorksheet.Cells(RowIndex + 1, 7).Value = row.Item("budget_name").ToString

                Next
                MessageBox.Show("Export Complete", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                xl.Visible = True
            Catch ex As Exception
                MessageBox.Show("Error" & vbCrLf & ex.Message)
            End Try
        End If

        worker.ReportProgress(100)

    End Sub

    Private Sub uiTrnJurnal_PV_Advance_isBackgroudWorker()

        Me.Panel1.Visible = True
        Me.obj_ProgressBar_backGroundWorker.Value = 0
        Me.obj_ProgressBar_backGroundWorker.Visible = True
        Me.lblLoading.Visible = True

        For Each tsItem As ToolStripItem In Me.ToolStrip1.Items
            tsItem.Enabled = False
        Next

        If Me.BackgroundWorker1.IsBusy Then
            Me.BackgroundWorker1.Dispose()
            Me.BackgroundWorker1.CancelAsync()
            BackgroundWorker1.RunWorkerAsync()
        Else
            Me.BackgroundWorker1.RunWorkerAsync()
        End If
    End Sub
End Class