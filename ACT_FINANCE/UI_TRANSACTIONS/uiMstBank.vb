'================================================== 
' Created Date: 4/20/2011 1:53:32 PM
'================================================== 
Public Class uiMstBank
    Private Const mUiName As String = "Master_Bank"
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

    Private tbl_MstBank As DataTable = clsDataset.CreateTblMstBank()
    Private tbl_MstBank_Temp As DataTable = clsDataset.CreateTblMstBank()
    Private tbl_MstBankacc As DataTable = clsDataset.CreateTblMstBankacc()
    Private tbl_MstBankacc_Temp As DataTable = clsDataset.CreateTblMstBankacc()
    Private tbl_MstBankacccontact As DataTable = clsDataset.CreateTblMstBankacccontact()
    Private tbl_MstBankacccontact_Temp As DataTable = clsDataset.CreateTblMstBankacccontact()

#Region " Window Parameter "
    ' TODO: Buat variabel untuk menampung parameter window 
    Private _CHANNEL As String = "TAS"
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
        Me.Master_Bank_NewData()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnNew_Click()
    End Function

    Public Overrides Function btnLoad_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.Master_Bank_Retrieve()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnLoad_Click()
    End Function

    Public Overrides Function btnSave_Click() As Boolean
        If Me.Master_Bank_FormError() Then
            Return True
        End If
        Me.Cursor = Cursors.WaitCursor
        Me.Master_Bank_Save()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnSave_Click()
    End Function

    Public Overrides Function btnPrint_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.Master_Bank_Print()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnPrint_Click()
    End Function

    Public Overrides Function btnDel_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.Master_Bank_Delete()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnDel_Click()
    End Function

    Public Overrides Function btnFirst_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.Master_Bank_First()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnFirst_Click()
    End Function

    Public Overrides Function btnPrev_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.Master_Bank_Prev()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnPrev_Click()
    End Function

    Public Overrides Function btnNext_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.Master_Bank_Next()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnNext_Click()
    End Function

    Public Overrides Function btnLast_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.Master_Bank_Last()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnLast_Click()
    End Function

#End Region

#Region " Layout & Init UI "

    Private Function FormatDgvMstBank(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        ' Format DgvMstBank Columns 
        Dim cBank_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBank_name As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBank_active As System.Windows.Forms.DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn

        cBank_id.Name = "bank_id"
        cBank_id.HeaderText = "Bank ID"
        cBank_id.DataPropertyName = "bank_id"
        cBank_id.Width = 100
        cBank_id.Visible = True
        cBank_id.ReadOnly = False

        cBank_name.Name = "bank_name"
        cBank_name.HeaderText = "Bank Name"
        cBank_name.DataPropertyName = "bank_name"
        cBank_name.Width = 100
        cBank_name.Visible = True
        cBank_name.ReadOnly = False

        cBank_active.Name = "bank_active"
        cBank_active.HeaderText = "Active"
        cBank_active.DataPropertyName = "bank_active"
        cBank_active.Width = 100
        cBank_active.Visible = True
        cBank_active.ReadOnly = False

        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
        {cBank_id, cBank_name, cBank_active})



        ' DgvMstBank Behaviours: 
        objDgv.AllowUserToAddRows = False
        objDgv.AllowUserToDeleteRows = False
        objDgv.AllowUserToResizeRows = False
        objDgv.ReadOnly = True
        objDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect

    End Function

    Private Function FormatDgvMstBankacc(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean

        Dim cBankacc_channel_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBankacc_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBankacc_ac As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBankacc_name As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBankacc_bank As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cCurrency_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBankacc_descr As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBankacc_telp As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBankacc_fax As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBankacc_branch As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBankacc_address1 As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBankacc_address2 As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBankacc_active As System.Windows.Forms.DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Dim cBankacc_account As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBankacc_account_name As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBankacc_createdt As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBankacc_createby As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBankacc_reportname As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBankacc_formbg As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBankacc_formcek As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBankacc_formtrf As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBankacc_formset As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn

        cBankacc_channel_id.Name = "channel_id"
        cBankacc_channel_id.HeaderText = "Channel ID"
        cBankacc_channel_id.DataPropertyName = "channel_id"
        cBankacc_channel_id.Width = 75
        cBankacc_channel_id.Visible = False
        cBankacc_channel_id.ReadOnly = False

        cBankacc_id.Name = "bankacc_id"
        cBankacc_id.HeaderText = "Acc ID"
        cBankacc_id.DataPropertyName = "bankacc_id"
        cBankacc_id.Width = 75
        cBankacc_id.Visible = True
        cBankacc_id.ReadOnly = False

        cBankacc_ac.Name = "bankacc_ac"
        cBankacc_ac.HeaderText = "Bank Account"
        cBankacc_ac.DataPropertyName = "bankacc_ac"
        cBankacc_ac.Width = 100
        cBankacc_ac.Visible = True
        cBankacc_ac.ReadOnly = False

        cBankacc_name.Name = "bankacc_name"
        cBankacc_name.HeaderText = "Acc Name"
        cBankacc_name.DataPropertyName = "bankacc_name"
        cBankacc_name.Width = 100
        cBankacc_name.Visible = True
        cBankacc_name.ReadOnly = False

        cBankacc_bank.Name = "bankacc_bank"
        cBankacc_bank.HeaderText = "Acc Bank"
        cBankacc_bank.DataPropertyName = "bankacc_bank"
        cBankacc_bank.Width = 100
        cBankacc_bank.Visible = False
        cBankacc_bank.ReadOnly = False

        cCurrency_id.Name = "currency_id"
        cCurrency_id.HeaderText = "Currency ID"
        cCurrency_id.DataPropertyName = "currency_id"
        cCurrency_id.Width = 100
        cCurrency_id.Visible = True
        cCurrency_id.ReadOnly = False

        cBankacc_descr.Name = "bankacc_descr"
        cBankacc_descr.HeaderText = "Acc Descr"
        cBankacc_descr.DataPropertyName = "bankacc_descr"
        cBankacc_descr.Width = 100
        cBankacc_descr.Visible = True
        cBankacc_descr.ReadOnly = False

        cBankacc_telp.Name = "bankacc_telp"
        cBankacc_telp.HeaderText = "Acc Tlp"
        cBankacc_telp.DataPropertyName = "bankacc_telp"
        cBankacc_telp.Width = 100
        cBankacc_telp.Visible = True
        cBankacc_telp.ReadOnly = False

        cBankacc_fax.Name = "bankacc_fax"
        cBankacc_fax.HeaderText = "Acc Fax"
        cBankacc_fax.DataPropertyName = "bankacc_fax"
        cBankacc_fax.Width = 100
        cBankacc_fax.Visible = True
        cBankacc_fax.ReadOnly = False

        cBankacc_branch.Name = "bankacc_branch"
        cBankacc_branch.HeaderText = "Acc Branch"
        cBankacc_branch.DataPropertyName = "bankacc_branch"
        cBankacc_branch.Width = 100
        cBankacc_branch.Visible = True
        cBankacc_branch.ReadOnly = False

        cBankacc_address1.Name = "bankacc_address1"
        cBankacc_address1.HeaderText = "Address 1"
        cBankacc_address1.DataPropertyName = "bankacc_address1"
        cBankacc_address1.Width = 100
        cBankacc_address1.Visible = True
        cBankacc_address1.ReadOnly = False

        cBankacc_address2.Name = "bankacc_address2"
        cBankacc_address2.HeaderText = "Address 2"
        cBankacc_address2.DataPropertyName = "bankacc_address2"
        cBankacc_address2.Width = 100
        cBankacc_address2.Visible = True
        cBankacc_address2.ReadOnly = False

        cBankacc_active.Name = "bankacc_active"
        cBankacc_active.HeaderText = "Active"
        cBankacc_active.DataPropertyName = "bankacc_active"
        cBankacc_active.Width = 100
        cBankacc_active.Visible = True
        cBankacc_active.ReadOnly = True

        cBankacc_account.Name = "bankacc_account"
        cBankacc_account.HeaderText = "Acc Account"
        cBankacc_account.DataPropertyName = "bankacc_account"
        cBankacc_account.Width = 100
        cBankacc_account.Visible = True
        cBankacc_account.ReadOnly = False

        cBankacc_account_name.Name = "bankacc_account_name"
        cBankacc_account_name.HeaderText = "Acc Account Name"
        cBankacc_account_name.DataPropertyName = "acc_name"
        cBankacc_account_name.Width = 150
        cBankacc_account_name.Visible = True
        cBankacc_account_name.ReadOnly = False

        cBankacc_createdt.Name = "bankacc_createdt"
        cBankacc_createdt.HeaderText = "Acc Create Date"
        cBankacc_createdt.DataPropertyName = "bankacc_createdt"
        cBankacc_createdt.Width = 150
        cBankacc_createdt.Visible = True
        cBankacc_createdt.ReadOnly = False

        cBankacc_createby.Name = "bankacc_createby"
        cBankacc_createby.HeaderText = "Acc Create By"
        cBankacc_createby.DataPropertyName = "bankacc_createby"
        cBankacc_createby.Width = 100
        cBankacc_createby.Visible = True
        cBankacc_createby.ReadOnly = False

        cBankacc_reportname.Name = "bankacc_reportname"
        cBankacc_reportname.HeaderText = "Acc Report Name"
        cBankacc_reportname.DataPropertyName = "bankacc_reportname"
        cBankacc_reportname.Width = 150
        cBankacc_reportname.Visible = True
        cBankacc_reportname.ReadOnly = False

        cBankacc_formbg.Name = "bankacc_formbg"
        cBankacc_formbg.HeaderText = "Acc Form BG"
        cBankacc_formbg.DataPropertyName = "bankacc_formbg"
        cBankacc_formbg.Width = 100
        cBankacc_formbg.Visible = True
        cBankacc_formbg.ReadOnly = False

        cBankacc_formcek.Name = "bankacc_formcek"
        cBankacc_formcek.HeaderText = "Acc Form Cek"
        cBankacc_formcek.DataPropertyName = "bankacc_formcek"
        cBankacc_formcek.Width = 150
        cBankacc_formcek.Visible = True
        cBankacc_formcek.ReadOnly = False

        cBankacc_formtrf.Name = "bankacc_formtrf"
        cBankacc_formtrf.HeaderText = "Acc Form RTF"
        cBankacc_formtrf.DataPropertyName = "bankacc_formtrf"
        cBankacc_formtrf.Width = 150
        cBankacc_formtrf.Visible = True
        cBankacc_formtrf.ReadOnly = False

        cBankacc_formset.Name = "bankacc_formset"
        cBankacc_formset.HeaderText = "Acc Form SET"
        cBankacc_formset.DataPropertyName = "bankacc_formset"
        cBankacc_formset.Width = 150
        cBankacc_formset.Visible = True
        cBankacc_formset.ReadOnly = False

        DgvMstBankacc.Columns.Clear()
        DgvMstBankacc.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
        {cBankacc_channel_id, cBankacc_id, cBankacc_ac, cBankacc_name, cBankacc_bank, cCurrency_id, _
        cBankacc_descr, cBankacc_telp, cBankacc_fax, cBankacc_branch, cBankacc_address1, _
        cBankacc_address2, cBankacc_active, cBankacc_account, cBankacc_account_name, cBankacc_createdt, cBankacc_createby, _
        cBankacc_reportname, cBankacc_formbg, cBankacc_formcek, cBankacc_formtrf, cBankacc_formset})

        ' DgvMstBank Behaviours: 
        objDgv.AllowUserToAddRows = False
        objDgv.AllowUserToDeleteRows = False
        objDgv.AllowUserToResizeRows = False
        objDgv.ReadOnly = True
        objDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect

    End Function

    Private Function FormatDgvMstBankacccontact(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        ' Format DgvMstBankacccontact Columns 
        Dim cBankcontact_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBankcontact_line As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBankcontact_shortname As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBankcontact_position As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBankcontact_telp As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBankcontact_fax As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBankcontact_address1 As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBankcontact_address2 As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn

        cBankcontact_id.Name = "bankcontact_id"
        cBankcontact_id.HeaderText = "bankcontact_id"
        cBankcontact_id.DataPropertyName = "bankcontact_id"
        cBankcontact_id.Width = 100
        cBankcontact_id.Visible = False
        cBankcontact_id.ReadOnly = False

        cBankcontact_line.Name = "bankcontact_line"
        cBankcontact_line.HeaderText = "LINE"
        cBankcontact_line.DataPropertyName = "bankcontact_line"
        cBankcontact_line.Width = 100
        cBankcontact_line.Visible = False
        cBankcontact_line.ReadOnly = False

        cBankcontact_shortname.Name = "bankcontact_shortname"
        cBankcontact_shortname.HeaderText = "Contact Shortname"
        cBankcontact_shortname.DataPropertyName = "bankcontact_shortname"
        cBankcontact_shortname.Width = 150
        cBankcontact_shortname.Visible = True
        cBankcontact_shortname.ReadOnly = False

        cBankcontact_position.Name = "bankcontact_position"
        cBankcontact_position.HeaderText = "Contact Position"
        cBankcontact_position.DataPropertyName = "bankcontact_position"
        cBankcontact_position.Width = 150
        cBankcontact_position.Visible = True
        cBankcontact_position.ReadOnly = False

        cBankcontact_telp.Name = "bankcontact_telp"
        cBankcontact_telp.HeaderText = "Contact Tlp"
        cBankcontact_telp.DataPropertyName = "bankcontact_telp"
        cBankcontact_telp.Width = 100
        cBankcontact_telp.Visible = True
        cBankcontact_telp.ReadOnly = False

        cBankcontact_fax.Name = "bankcontact_fax"
        cBankcontact_fax.HeaderText = "Contact Fax"
        cBankcontact_fax.DataPropertyName = "bankcontact_fax"
        cBankcontact_fax.Width = 100
        cBankcontact_fax.Visible = True
        cBankcontact_fax.ReadOnly = False

        cBankcontact_address1.Name = "bankcontact_address1"
        cBankcontact_address1.HeaderText = "Address 1"
        cBankcontact_address1.DataPropertyName = "bankcontact_address1"
        cBankcontact_address1.Width = 100
        cBankcontact_address1.Visible = True
        cBankcontact_address1.ReadOnly = False

        cBankcontact_address2.Name = "bankcontact_address2"
        cBankcontact_address2.HeaderText = "Address 2"
        cBankcontact_address2.DataPropertyName = "bankcontact_address2"
        cBankcontact_address2.Width = 100
        cBankcontact_address2.Visible = True
        cBankcontact_address2.ReadOnly = False

        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
        {cBankcontact_id, cBankcontact_line, cBankcontact_shortname, cBankcontact_position, _
        cBankcontact_telp, cBankcontact_fax, cBankcontact_address1, cBankcontact_address2})



        ' DgvMstBankacccontact Behaviours: 
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
        Me.DgvMstBank.Dock = DockStyle.Fill

        Me.FormatDgvMstBank(Me.DgvMstBank)
        Me.FormatDgvMstBankacc(Me.DgvMstBankacc)
        Me.FormatDgvMstBankacccontact(Me.DgvMstBankacccontact)

    End Function

    Private Function BindingStop() As Boolean
        'stop binding
        Me.obj_Bank_id.DataBindings.Clear()
        Me.obj_Bank_name.DataBindings.Clear()
        Me.obj_Bank_active.DataBindings.Clear()
        Return True
    End Function

    Private Function BindingStart() As Boolean
        'start binding
        Me.obj_Bank_id.DataBindings.Add(New Binding("Text", Me.tbl_MstBank_Temp, "bank_id"))
        Me.obj_Bank_name.DataBindings.Add(New Binding("Text", Me.tbl_MstBank_Temp, "bank_name"))
        Me.obj_Bank_active.DataBindings.Add(New Binding("Checked", Me.tbl_MstBank_Temp, "bank_active"))
        Return True
    End Function

#End Region

#Region " Dialoged Control "
#End Region

#Region " User Defined Function "

    Private Function Master_Bank_NewData() As Boolean
        RaiseEvent FormBeforeNew()
        Me.BindingContext(Me.tbl_MstBank_Temp).EndCurrentEdit()
        tbl_MstBankacc_Temp.Clear()
        tbl_MstBankacccontact_Temp.Clear()
        Try
            Me.BindingContext(Me.tbl_MstBank_Temp).AddNew()
        Catch ex As Exception
            MessageBox.Show(ex.Source)
        End Try
    End Function

    Private Function Master_Bank_Retrieve() As Boolean
        Dim criteria As String = String.Empty
        Dim c(2) As String
        Dim idBank As String = CStr(txtIDBank.Text)
        Dim NmBank As String = CStr(txtNameBank.Text)
        Dim nols As Integer = 0
        Dim satoe As Integer = 1

        If chkIDbank.Checked = True Then
            c(0) = "bank_id = " & Trim(idBank)
        End If

        If chkNameBank.Checked = True Then
            c(2) = "bank_name LIKE '%" & Trim(NmBank) & "%' "
        End If

        If chkNotActive.Checked Then
            c(1) = "bank_active = " & nols
        Else
            c(1) = "bank_active = " & satoe
        End If

        Dim e As Boolean = False

        For i As Integer = 0 To c.Length - 1
            If c(i) <> String.Empty Then
                If e = False Then
                    criteria = c(i)
                    e = True
                Else
                    criteria = criteria & " and " & c(i)
                End If
            End If
        Next

        Me.tbl_MstBank.Clear()
        Try
            Me.DataFill(Me.tbl_MstBank, "ms_MstBank_Select", criteria)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Function

    Private Function Master_Bank_Save() As Boolean
        Dim tbl_MstBank_Temp_Changes As DataTable
        Dim tbl_MstBankacc_Temp_Changes As DataTable
        Dim tbl_MstBankacccontact_Temp_Changes As DataTable
        Dim success As Boolean
        Dim bank_id As Object = New Object
        Dim i As Integer = 0
        Dim MasterDataState As System.Data.DataRowState
        Dim result As FormSaveResult

        Me.Cursor = Cursors.WaitCursor
        RaiseEvent FormBeforeSave(bank_id)

        '1
        Me.BindingContext(Me.tbl_MstBank_Temp).EndCurrentEdit()
        tbl_MstBank_Temp_Changes = Me.tbl_MstBank_Temp.GetChanges()

        '2
        Me.BindingContext(Me.tbl_MstBankacc_Temp).EndCurrentEdit()
        tbl_MstBankacc_Temp_Changes = Me.tbl_MstBankacc_Temp.GetChanges()

        '3
        Me.BindingContext(Me.tbl_MstBankacccontact_Temp).EndCurrentEdit()
        tbl_MstBankacccontact_Temp_Changes = Me.tbl_MstBankacccontact_Temp.GetChanges()

        If tbl_MstBank_Temp_Changes IsNot Nothing Or tbl_MstBankacc_Temp_Changes IsNot Nothing Or tbl_MstBankacccontact_Temp_Changes IsNot Nothing Then

            Try

                MasterDataState = tbl_MstBank_Temp.Rows(0).RowState
                bank_id = tbl_MstBank_Temp.Rows(0).Item("bank_id")

                If tbl_MstBank_Temp_Changes IsNot Nothing Then
                    success = Me.Master_Bank_SaveMaster(bank_id, tbl_MstBank_Temp_Changes, MasterDataState)
                    If Not success Then Throw New Exception("Error: Saving Master Data at Me.Master_Bank_SaveMaster(tbl_MstBank_Temp_Changes)")
                    Me.tbl_MstBank_Temp.AcceptChanges()
                End If

                If tbl_MstBankacc_Temp_Changes IsNot Nothing Then
                    success = Me.Master_BankAccount_SaveMaster(bank_id, tbl_MstBankacc_Temp_Changes, MasterDataState)
                    If Not success Then Throw New Exception("Error: Saving Master Data at Me.Master_BankAccount_SaveMaster(tbl_MstBankacc_Temp_Changes)")
                    Me.tbl_MstBankacc_Temp.AcceptChanges()
                End If

                If tbl_MstBankacccontact_Temp_Changes IsNot Nothing Then
                    success = Me.mstContact_SaveMaster(bank_id, tbl_MstBankacccontact_Temp_Changes, MasterDataState)
                    If Not success Then Throw New Exception("Error: Saving Master Data at Me.mstContact_SaveMaster(tbl_MstBankacccontact_Temp_Changes)")
                    Me.tbl_MstBankacccontact_Temp.AcceptChanges()
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

        RaiseEvent FormAfterSave(bank_id, result)
        Me.Cursor = Cursors.Arrow
    End Function

    Private Function Master_Bank_SaveMaster(ByRef bank_id As Object, ByVal objTbl As DataTable, ByVal MasterDataState As System.Data.DataRowState) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbCmdInsert As OleDb.OleDbCommand
        Dim dbCmdUpdate As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter
        Dim curpos As Integer

        ' Save data: master_bank
        dbCmdInsert = New OleDb.OleDbCommand("ms_MstBank_Insert", dbConn)
        dbCmdInsert.CommandType = CommandType.StoredProcedure
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bank_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(3, Byte), CType(0, Byte), "bank_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bank_name", System.Data.OleDb.OleDbType.VarWChar, 100, "bank_name"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bank_active", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(1, Byte), CType(0, Byte), "bank_active", System.Data.DataRowVersion.Current, Nothing))

        dbCmdUpdate = New OleDb.OleDbCommand("ms_MstBank_Update", dbConn)
        dbCmdUpdate.CommandType = CommandType.StoredProcedure
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bank_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(3, Byte), CType(0, Byte), "bank_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bank_name", System.Data.OleDb.OleDbType.VarWChar, 100, "bank_name"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bank_active", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(1, Byte), CType(0, Byte), "bank_active", System.Data.DataRowVersion.Current, Nothing))

        dbDA = New OleDb.OleDbDataAdapter
        dbDA.UpdateCommand = dbCmdUpdate
        dbDA.InsertCommand = dbCmdInsert


        Dim cookie As Byte() = Nothing

        Try
            dbConn.Open()
            clsApplicationRole.SetAppRole(dbConn, cookie)
            dbDA.Update(objTbl)

            bank_id = objTbl.Rows(0).Item("bank_id")
            Me.tbl_MstBank_Temp.Clear()
            Me.tbl_MstBank_Temp.Merge(objTbl)

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
            Me.tbl_MstBank.Merge(objTbl)
        ElseIf MasterDataState = DataRowState.Modified Then
            curpos = Me.BindingContext(Me.tbl_MstBank).Position
            Me.tbl_MstBank.Rows.RemoveAt(curpos)
            Me.tbl_MstBank.Merge(objTbl)
        End If

        Me.BindingContext(Me.tbl_MstBank).Position = Me.BindingContext(Me.tbl_MstBank).Count

        Return True
    End Function

    Private Function Master_BankAccount_SaveMaster(ByRef bank_id As Object, ByVal objTbl As DataTable, ByVal MasterDataState As System.Data.DataRowState) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbCmdInsert As OleDb.OleDbCommand
        Dim dbCmdUpdate As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter
        'Dim curpos As Integer

        ' Save data: master_bankacc
        dbCmdInsert = New OleDb.OleDbCommand("ms_MstBankacc_Insert", dbConn)
        dbCmdInsert.CommandType = CommandType.StoredProcedure
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 100, "channel_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bankacc_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(3, Byte), CType(0, Byte), "bankacc_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bankacc_ac", System.Data.OleDb.OleDbType.Decimal, 20, "bankacc_ac"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bankacc_name", System.Data.OleDb.OleDbType.VarWChar, 100, "bankacc_name"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bankacc_bank", System.Data.OleDb.OleDbType.Decimal, 5)).Value = bank_id
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@currency_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(3, Byte), CType(0, Byte), "currency_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bankacc_descr", System.Data.OleDb.OleDbType.VarWChar, 400, "bankacc_descr"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bankacc_telp", System.Data.OleDb.OleDbType.VarWChar, 100, "bankacc_telp"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bankacc_fax", System.Data.OleDb.OleDbType.VarWChar, 100, "bankacc_fax"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bankacc_branch", System.Data.OleDb.OleDbType.VarWChar, 200, "bankacc_branch"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bankacc_address1", System.Data.OleDb.OleDbType.VarWChar, 200, "bankacc_address1"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bankacc_address2", System.Data.OleDb.OleDbType.VarWChar, 200, "bankacc_address2"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bankacc_active", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(1, Byte), CType(0, Byte), "bankacc_active", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bankacc_account", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(7, Byte), CType(0, Byte), "bankacc_account", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bankacc_createdt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "bankacc_createdt"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bankacc_createby", System.Data.OleDb.OleDbType.VarWChar, 100, "bankacc_createby"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bankacc_reportname", System.Data.OleDb.OleDbType.VarWChar, 100, "bankacc_reportname"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bankacc_formbg", System.Data.OleDb.OleDbType.VarWChar, 100, "bankacc_formbg"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bankacc_formcek", System.Data.OleDb.OleDbType.VarWChar, 100, "bankacc_formcek"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bankacc_formtrf", System.Data.OleDb.OleDbType.VarWChar, 100, "bankacc_formtrf"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bankacc_formset", System.Data.OleDb.OleDbType.VarWChar, 100, "bankacc_formset"))

        dbCmdUpdate = New OleDb.OleDbCommand("ms_MstBankacc_Update", dbConn)
        dbCmdUpdate.CommandType = CommandType.StoredProcedure
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 100, "channel_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bankacc_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(3, Byte), CType(0, Byte), "bankacc_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bankacc_ac", System.Data.OleDb.OleDbType.Decimal, 20, "bankacc_ac"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bankacc_name", System.Data.OleDb.OleDbType.VarWChar, 100, "bankacc_name"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bankacc_bank", System.Data.OleDb.OleDbType.Decimal, 5)).Value = bank_id
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@currency_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(3, Byte), CType(0, Byte), "currency_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bankacc_descr", System.Data.OleDb.OleDbType.VarWChar, 400, "bankacc_descr"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bankacc_telp", System.Data.OleDb.OleDbType.VarWChar, 100, "bankacc_telp"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bankacc_fax", System.Data.OleDb.OleDbType.VarWChar, 100, "bankacc_fax"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bankacc_branch", System.Data.OleDb.OleDbType.VarWChar, 200, "bankacc_branch"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bankacc_address1", System.Data.OleDb.OleDbType.VarWChar, 200, "bankacc_address1"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bankacc_address2", System.Data.OleDb.OleDbType.VarWChar, 200, "bankacc_address2"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bankacc_active", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(1, Byte), CType(0, Byte), "bankacc_active", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bankacc_account", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(7, Byte), CType(0, Byte), "bankacc_account", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bankacc_createdt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "bankacc_createdt"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bankacc_createby", System.Data.OleDb.OleDbType.VarWChar, 100, "bankacc_createby"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bankacc_reportname", System.Data.OleDb.OleDbType.VarWChar, 100, "bankacc_reportname"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bankacc_formbg", System.Data.OleDb.OleDbType.VarWChar, 100, "bankacc_formbg"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bankacc_formcek", System.Data.OleDb.OleDbType.VarWChar, 100, "bankacc_formcek"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bankacc_formtrf", System.Data.OleDb.OleDbType.VarWChar, 100, "bankacc_formtrf"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bankacc_formset", System.Data.OleDb.OleDbType.VarWChar, 100, "bankacc_formset"))


        dbDA = New OleDb.OleDbDataAdapter
        dbDA.UpdateCommand = dbCmdUpdate
        dbDA.InsertCommand = dbCmdInsert


        Dim cookie As Byte() = Nothing

        Try
            dbConn.Open()
            clsApplicationRole.SetAppRole(dbConn, cookie)
            dbDA.Update(objTbl)

            Me.tbl_MstBankacc_Temp.Clear()
            Me.tbl_MstBankacc_Temp.Merge(objTbl)
            Me.Master_BankAccount_OpenRowMaster(bank_id, dbConn)

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


        'If MasterDataState = DataRowState.Added Then
        '    Me.tbl_MstBankacc.Merge(objTbl)
        'ElseIf MasterDataState = DataRowState.Modified Then
        '    curpos = Me.BindingContext(Me.tbl_MstBankacc).Position
        '    Me.tbl_MstBankacc.Rows.RemoveAt(curpos)
        '    Me.tbl_MstBankacc.Merge(objTbl)
        'End If

        Me.BindingContext(Me.tbl_MstBankacc).Position = Me.BindingContext(Me.tbl_MstBankacc).Count

        Return True
    End Function

    Private Function mstContact_SaveMaster(ByRef bank_id As Object, ByVal objTbl As DataTable, ByVal MasterDataState As System.Data.DataRowState) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbCmdInsert As OleDb.OleDbCommand
        Dim dbCmdUpdate As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter
        'Dim curpos As Integer

        ' Save data: master_bankacccontact
        dbCmdInsert = New OleDb.OleDbCommand("ms_MstBankacccontact_Insert", dbConn)
        dbCmdInsert.CommandType = CommandType.StoredProcedure

        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 100, "channel_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bankcontact_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(3, Byte), CType(0, Byte), "bankcontact_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bankcontact_line", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(3, Byte), CType(0, Byte), "bankcontact_line", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bankcontact_shortname", System.Data.OleDb.OleDbType.VarWChar, 100, "bankcontact_shortname"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bankcontact_position", System.Data.OleDb.OleDbType.VarWChar, 100, "bankcontact_position"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bankcontact_telp", System.Data.OleDb.OleDbType.VarWChar, 100, "bankcontact_telp"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bankcontact_fax", System.Data.OleDb.OleDbType.VarWChar, 100, "bankcontact_fax"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bankcontact_address1", System.Data.OleDb.OleDbType.VarWChar, 200, "bankcontact_address1"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bankcontact_address2", System.Data.OleDb.OleDbType.VarWChar, 200, "bankcontact_address2"))


        dbCmdUpdate = New OleDb.OleDbCommand("ms_MstBankacccontact_Update", dbConn)
        dbCmdUpdate.CommandType = CommandType.StoredProcedure
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 100, "channel_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bankcontact_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(3, Byte), CType(0, Byte), "bankcontact_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bankcontact_line", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(3, Byte), CType(0, Byte), "bankcontact_line", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bankcontact_shortname", System.Data.OleDb.OleDbType.VarWChar, 100, "bankcontact_shortname"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bankcontact_position", System.Data.OleDb.OleDbType.VarWChar, 100, "bankcontact_position"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bankcontact_telp", System.Data.OleDb.OleDbType.VarWChar, 100, "bankcontact_telp"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bankcontact_fax", System.Data.OleDb.OleDbType.VarWChar, 100, "bankcontact_fax"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bankcontact_address1", System.Data.OleDb.OleDbType.VarWChar, 200, "bankcontact_address1"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bankcontact_address2", System.Data.OleDb.OleDbType.VarWChar, 200, "bankcontact_address2"))


        dbDA = New OleDb.OleDbDataAdapter
        dbDA.UpdateCommand = dbCmdUpdate
        dbDA.InsertCommand = dbCmdInsert

        Dim cookie As Byte() = Nothing

        Try
            dbConn.Open()
            clsApplicationRole.SetAppRole(dbConn, cookie)
            dbDA.Update(objTbl)

            Me.tbl_MstBankacccontact_Temp.Clear()
            Me.tbl_MstBankacccontact_Temp.Merge(objTbl)

            Me.master_contact_OpenRowMaster(bank_id, dbConn)

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


        'If MasterDataState = DataRowState.Added Then
        '    Me.tbl_MstBankacccontact.Merge(objTbl)
        'ElseIf MasterDataState = DataRowState.Modified Then
        '    curpos = Me.BindingContext(Me.tbl_MstBankacccontact).Position
        '    Me.tbl_MstBankacccontact.Rows.RemoveAt(curpos)
        '    Me.tbl_MstBankacccontact.Merge(objTbl)
        'End If

        Me.BindingContext(Me.tbl_MstBankacccontact).Position = Me.BindingContext(Me.tbl_MstBankacccontact).Count

        Return True
    End Function

    Private Function Master_BankAccount_Print() As Boolean
        'print data
    End Function

    Private Function Master_Bank_Print() As Boolean
        'print data
    End Function

    Private Function Master_Bank_Delete() As Boolean
        Dim res As String = ""
        Dim bank_id As Object = New Object

        Me.Cursor = Cursors.WaitCursor
        RaiseEvent FormBeforeDelete(bank_id)

        Me.Cursor = Cursors.WaitCursor
        If Me.DgvMstBank.CurrentRow IsNot Nothing Then

            res = MessageBox.Show("Are you sure want to delete data ?", mUiName, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If res = DialogResult.Yes Then
                Me.Master_Bank_DeleteRow(Me.DgvMstBank.CurrentRow.Index)
            End If

        End If

        RaiseEvent FormAfterDelete(bank_id)
        Me.Cursor = Cursors.Arrow

    End Function

    Private Function Master_Bank_DeleteRow(ByVal rowIndex As Integer) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbCmdDelete As OleDb.OleDbCommand
        Dim bank_id As String
        Dim NewRowIndex As Integer

        bank_id = Me.DgvMstBank.Rows(rowIndex).Cells("bank_id").Value

        dbCmdDelete = New OleDb.OleDbCommand("ms_MstBank_Delete", dbConn)
        dbCmdDelete.CommandType = CommandType.StoredProcedure
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bank_id", System.Data.OleDb.OleDbType.Decimal, 5))
        dbCmdDelete.Parameters("@bank_id").Value = bank_id
        'dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bank_name", System.Data.OleDb.OleDbType.VarWChar, 100))
        'dbCmdDelete.Parameters("@bank_name").Value = DBNULL.value
        'dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bank_active", System.Data.OleDb.OleDbType.Decimal, 5))
        'dbCmdDelete.Parameters("@bank_active").Value = DBNULL.value


        Dim cookie As Byte() = Nothing

        Try
            dbConn.Open()
            clsApplicationRole.SetAppRole(dbConn, cookie)
            dbCmdDelete.ExecuteNonQuery()

            If Me.DgvMstBank.Rows.Count > 1 Then

                If rowIndex = 0 Then
                    NewRowIndex = rowIndex + 1
                    Me.Master_Bank_OpenRow(NewRowIndex)
                    Me.tbl_MstBank.Rows.RemoveAt(rowIndex)
                ElseIf rowIndex = Me.DgvMstBank.Rows.Count - 1 Then
                    NewRowIndex = rowIndex - 1
                    Me.Master_Bank_OpenRow(NewRowIndex)
                    Me.tbl_MstBank.Rows.RemoveAt(rowIndex)
                Else
                    Me.tbl_MstBank.Rows.RemoveAt(rowIndex)
                    Me.Master_Bank_OpenRow(rowIndex)
                End If

            Else

                Me.tbl_MstBank_Temp.Clear()
                Me.tbl_MstBank.Rows.RemoveAt(rowIndex)

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

    Private Function Master_BankAccount_DeleteRow(ByVal bankacc_id As Integer) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbCmdDelete As OleDb.OleDbCommand

        dbCmdDelete = New OleDb.OleDbCommand("ms_MstBankacc_Delete", dbConn)
        dbCmdDelete.CommandType = CommandType.StoredProcedure
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bankacc_id", System.Data.OleDb.OleDbType.Decimal, 5))
        dbCmdDelete.Parameters("@bankacc_id").Value = bankacc_id


        Dim cookie As Byte() = Nothing

        Try
            dbConn.Open()
            clsApplicationRole.SetAppRole(dbConn, cookie)
            dbCmdDelete.ExecuteNonQuery()

            If Me.DgvMstBankacc.Rows.Count <> 0 Then
                MsgBox("Success", MsgBoxStyle.Information, "Notification")
                Dim bank_id As Integer = DgvMstBankacc.SelectedRows.Item(0).Cells("bankacc_bank").Value
                Master_BankAccount_OpenRowMaster(bank_id, dbConn)
            Else

                MsgBox("Error", MsgBoxStyle.Critical)
                Exit Try
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

    Private Function Master_Bank_OpenRow(ByVal rowIndex As Integer) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim bank_id As String

        bank_id = Me.DgvMstBank.Rows(rowIndex).Cells("bank_id").Value

        Me.Cursor = Cursors.WaitCursor
        RaiseEvent FormBeforeOpenRow(bank_id)


        Dim cookie As Byte() = Nothing

        Try
            dbConn.Open()
            clsApplicationRole.SetAppRole(dbConn, cookie)
            Me.Master_Bank_OpenRowMaster(bank_id, dbConn)
            Me.Master_BankAccount_OpenRowMaster(bank_id, dbConn)
            Me.master_contact_OpenRowMaster(bank_id, dbConn)

        Catch ex As Exception
            MessageBox.Show(ex.Message, mUiName & ": Master_Bank_OpenRow()", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            clsApplicationRole.UnsetAppRole(dbConn, cookie)
            dbConn.Close()
        End Try

        RaiseEvent FormAfterOpenRow(bank_id)
        Me.Cursor = Cursors.Arrow

        Return True

    End Function

    Private Function Master_Bank_OpenRowMaster(ByVal bank_id As String, ByVal dbConn As OleDb.OleDbConnection) As Boolean
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        dbCmd = New OleDb.OleDbCommand("ms_MstBank_Select", dbConn)
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@Criteria").Value = String.Format("bank_id='{0}'", bank_id)
        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)
        Me.tbl_MstBank_Temp.Clear()

        Try
            Me.BindingStop()
            dbDA.Fill(Me.tbl_MstBank_Temp)
            Me.BindingStart()
        Catch ex As Exception
            Throw New Exception(mUiName & ": Master_Bank_OpenRowMaster()" & vbCrLf & ex.Message)
        End Try

    End Function

    Private Function Master_BankAccount_OpenRowMaster(ByVal bank_id As String, ByVal dbConn As OleDb.OleDbConnection) As Boolean
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        dbCmd = New OleDb.OleDbCommand("ms_MstBankacc_Select", dbConn)
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@Criteria").Value = String.Format("channel_id = '{0}' AND bankacc_bank='{1}'", Me._CHANNEL, bank_id)
        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)
        Me.tbl_MstBankacc_Temp.Clear()




        Try

            dbDA.Fill(Me.tbl_MstBankacc_Temp)
            DgvMstBankacc.DataSource = tbl_MstBankacc_Temp
            FormatDgvMstBankacc(DgvMstBankacc)

        Catch ex As Exception
            Throw New Exception(mUiName & ": Master_BankAccount_OpenRowMaster()" & vbCrLf & ex.Message)
        End Try

    End Function

    Private Function master_contact_OpenRowMaster(ByVal bank_id As String, ByVal dbConn As OleDb.OleDbConnection) As Boolean
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        dbCmd = New OleDb.OleDbCommand("ms_MstBankacccontact_Select", dbConn)
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@Criteria").Value = String.Format("channel_id = '{0}' AND bankcontact_id='{1}'", Me._CHANNEL, bank_id)
        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)
        Me.tbl_MstBankacccontact_Temp.Clear()

        'Gets or sets the default value for the column when you are creating new rows.
        tbl_MstBankacccontact_Temp.Columns("bankcontact_line").DefaultValue = DBNull.Value
        tbl_MstBankacccontact_Temp.Columns("bankcontact_line").AutoIncrement = True
        'set parameter untuk value yg akan di auto di mulai dari 1,2,3dst..
        tbl_MstBankacccontact_Temp.Columns("bankcontact_line").AutoIncrementSeed = 1
        'set parameter kelipatan untuk value yang akan di auto di mulai dari 1,11,21,32,dst..jika param = 10
        tbl_MstBankacccontact_Temp.Columns("bankcontact_line").AutoIncrementStep = 1


        Try

            dbDA.Fill(Me.tbl_MstBankacccontact_Temp)
            DgvMstBankacccontact.DataSource = tbl_MstBankacccontact_Temp
            FormatDgvMstBankacccontact(DgvMstBankacccontact)

        Catch ex As Exception
            Throw New Exception(mUiName & ": master_contact_OpenRowMaster()" & vbCrLf & ex.Message)
        End Try

    End Function

    Private Function Master_Bank_First() As Boolean
        'goto first record found
        Dim move As Boolean
        Dim Message As String = "Data has been changed. " & vbCrLf & "Save data changes before move to first record ?"
        Dim iTab As Integer = Me.ftabMain.SelectedIndex

        If iTab = 1 Then
            If Me.DATA_ISLOCKED Then
                move = True
            Else
                move = Me.Master_Bank_ConfirmSaveBeforeMove(Message)
            End If
        Else
            move = True
        End If

        If move Then
            Me.DgvMstBank.CurrentCell = Me.DgvMstBank(1, 0)
            Me.Master_Bank_RefreshPosition()
        End If
    End Function

    Private Function Master_Bank_Prev() As Boolean
        'goto previous record found
        Dim move As Boolean
        Dim Message As String = "Data has been changed. " & vbCrLf & "Save data changes before move to previous record ?"
        Dim iTab As Integer = Me.ftabMain.SelectedIndex

        If iTab = 1 Then
            If Me.DATA_ISLOCKED Then
                move = True
            Else
                move = Me.Master_Bank_ConfirmSaveBeforeMove(Message)
            End If
        Else
            move = True
        End If

        If move Then
            If Me.DgvMstBank.CurrentCell.RowIndex > 0 Then
                Me.DgvMstBank.CurrentCell = Me.DgvMstBank(1, DgvMstBank.CurrentCell.RowIndex - 1)
                Me.Master_Bank_RefreshPosition()
            End If
        End If
    End Function

    Private Function Master_Bank_Next() As Boolean
        'goto next record found
        Dim move As Boolean
        Dim Message As String = "Data has been changed. " & vbCrLf & "Save data changes before move to next record ?"
        Dim iTab As Integer = Me.ftabMain.SelectedIndex

        If iTab = 1 Then
            If Me.DATA_ISLOCKED Then
                move = True
            Else
                move = Me.Master_Bank_ConfirmSaveBeforeMove(Message)
            End If
        Else
            move = True
        End If

        If move Then
            If Me.DgvMstBank.CurrentCell.RowIndex < Me.DgvMstBank.Rows.Count - 1 Then
                Me.DgvMstBank.CurrentCell = Me.DgvMstBank(1, DgvMstBank.CurrentCell.RowIndex + 1)
                Me.Master_Bank_RefreshPosition()
            End If
        End If
    End Function

    Private Function Master_Bank_Last() As Boolean
        'goto last record found
        Dim move As Boolean
        Dim Message As String = "Data has been changed. " & vbCrLf & "Save data changes before move to next record ?"
        Dim iTab As Integer = Me.ftabMain.SelectedIndex

        If iTab = 1 Then
            If Me.DATA_ISLOCKED Then
                move = True
            Else
                move = Me.Master_Bank_ConfirmSaveBeforeMove(Message)
            End If
        Else
            move = True
        End If

        If move Then
            Me.DgvMstBank.CurrentCell = Me.DgvMstBank(1, Me.DgvMstBank.Rows.Count - 1)
            Me.Master_Bank_RefreshPosition()
        End If
    End Function

    Private Function Master_Bank_RefreshPosition() As Boolean
        'refresh position
        Dim iTab As Integer = Me.ftabMain.SelectedIndex
        If iTab = 1 Then Master_Bank_OpenRow(Me.DgvMstBank.CurrentRow.Index)
    End Function

    Private Function Master_Bank_ConfirmSaveBeforeMove(ByVal Message As String) As Boolean
        'confirm saving data changes before move
        Dim tbl_MstBank_Temp_Changes As DataTable
        Dim res As System.Windows.Forms.DialogResult
        Dim success As Boolean
        Dim i As Integer = 0
        Dim MasterDataState As System.Data.DataRowState
        Dim bank_id As Object = New Object
        Dim move As Boolean = False
        Dim result As FormSaveResult


        If Me.DgvMstBank.CurrentCell IsNot Nothing Then

            Me.BindingContext(Me.tbl_MstBank_Temp).EndCurrentEdit()
            tbl_MstBank_Temp_Changes = Me.tbl_MstBank_Temp.GetChanges()

            If tbl_MstBank_Temp_Changes IsNot Nothing Then

                res = MessageBox.Show(Message, mUiName, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                Select Case res
                    Case DialogResult.Yes

                        RaiseEvent FormBeforeSave(bank_id)

                        Try

                            If tbl_MstBank_Temp_Changes IsNot Nothing Then
                                success = Me.Master_Bank_SaveMaster(bank_id, tbl_MstBank_Temp_Changes, MasterDataState)
                                If Not success Then Throw New Exception("Cannot Save Master Data")
                                Me.tbl_MstBank_Temp.AcceptChanges()
                            End If

                            result = FormSaveResult.SaveSuccess
                            If SHOW_SAVE_CONFIRMATION Then
                                MessageBox.Show("Data Saved", mUiName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                            End If

                        Catch ex As Exception
                            result = FormSaveResult.SaveError
                            MessageBox.Show(ex.Message & vbCrLf & "Data Cannot Be Saved", mUiName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try

                        RaiseEvent FormAfterSave(bank_id, result)

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

    Private Function Master_Bank_FormError() As Boolean
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

            Me.DgvMstBank.DataSource = Me.tbl_MstBank
            Me.BindingStop()
            Me.BindingStart()

            Me.Master_Bank_NewData()

            Me.tbtnSave.Enabled = False
            Me.tbtnDel.Enabled = False
            Me.tbtnLoad.Enabled = True
            Me.tbtnQuery.Enabled = True

        End If
    End Sub

    Private Sub uiMstBank_FormBeforeNew() Handles Me.FormBeforeNew
        Me.tbtnDel.Enabled = False
    End Sub

    Private Sub Master_Bank_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

            Case 1
                Me.tbtnSave.Enabled = True
                Me.tbtnDel.Enabled = True
                Me.tbtnLoad.Enabled = False
                Me.tbtnQuery.Enabled = False
                Me.ftabMain.TabPages.Item(0).BackColor = Color.Gainsboro
                Me.ftabMain.TabPages.Item(1).BackColor = Color.White

                If Me.DgvMstBank.CurrentRow IsNot Nothing Then
                    Me.Master_Bank_OpenRow(Me.DgvMstBank.CurrentRow.Index)
                Else
                    Me.Master_Bank_NewData()
                End If


        End Select
    End Sub

    Private Sub DgvMstBank_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvMstBank.CellDoubleClick
        If e.ColumnIndex < 0 Or e.RowIndex < 0 Then
            Exit Sub
        End If
        If Me.DgvMstBank.CurrentRow IsNot Nothing Then
            Me.ftabMain.SelectedIndex = 1
        End If
    End Sub

    Private Sub chkIDbank_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkIDbank.CheckedChanged
        txtIDBank.Enabled = Not txtIDBank.Enabled
    End Sub

    Private Sub chkNameBank_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkNameBank.CheckedChanged
        txtNameBank.Enabled = Not txtNameBank.Enabled
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim dlg As New dlgAccount(DSN, Me._CHANNEL)
        Try

            If dlg.ShowDialog = DialogResult.OK Then

                Dim row As DataRow = Me.tbl_MstBankacc_Temp.NewRow

                'row.Item("bankacc_id") = dlg.txtAccIdDlg.Text
                row.Item("channel_id") = Me._CHANNEL
                row.Item("bankacc_ac") = dlg.txtAcc.Text
                row.Item("bankacc_name") = dlg.txtAccName.Text
                row.Item("bankacc_bank") = obj_Bank_id.Text
                row.Item("bankacc_account") = dlg.cmbAccount.SelectedValue

                row.Item("currency_id") = dlg.cmbCurrency.SelectedValue
                row.Item("bankacc_descr") = dlg.txtDescr.Text
                row.Item("bankacc_telp") = dlg.txtTlp.Text
                row.Item("bankacc_fax") = dlg.txtFax.Text
                row.Item("bankacc_branch") = dlg.txtBranch.Text
                row.Item("bankacc_address1") = dlg.txtAddr1.Text
                row.Item("bankacc_address2") = dlg.txtAddr2.Text
                row.Item("bankacc_active") = dlg.chkActive.Checked

                '--

                row.Item("bankacc_createdt") = Date.Now
                row.Item("bankacc_createby") = Me.UserName
                row.Item("bankacc_reportname") = dlg.txtReportName.Text
                row.Item("bankacc_formbg") = dlg.txtFormBG.Text
                row.Item("bankacc_formcek") = dlg.txtFormCek.Text
                row.Item("bankacc_formtrf") = dlg.txtFormTrf.Text
                row.Item("bankacc_formset") = dlg.txtFormSet.Text

                Me.tbl_MstBankacc_Temp.Rows.Add(row)
                Dim rows As DataRow = CType(Me.DgvMstBankacc.CurrentRow.DataBoundItem, DataRowView).Row


            End If

        Catch ex As Exception
            Throw New Exception(mUiName & ": max(AddAccount)" & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub DgvMstBankacc_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvMstBankacc.CellDoubleClick

        If e.RowIndex > -1 And e.ColumnIndex > -1 Then
            Dim dlg As New dlgAccount(DSN, Me._CHANNEL)
            Dim row As DataRow = CType(Me.DgvMstBankacc.CurrentRow.DataBoundItem, DataRowView).Row

            dlg.txtAcc.Text = row.Item("bankacc_ac")
            dlg.txtAccName.Text = row.Item("bankacc_name")
            dlg.txtDescr.Text = row.Item("bankacc_descr").ToString
            dlg.txtTlp.Text = row.Item("bankacc_telp").ToString
            dlg.txtFax.Text = row.Item("bankacc_fax").ToString
            dlg.txtBranch.Text = row.Item("bankacc_branch").ToString
            dlg.txtAddr1.Text = row.Item("bankacc_address1").ToString
            dlg.txtAddr2.Text = row.Item("bankacc_address2").ToString
            dlg.chkActive.Checked = row.Item("bankacc_active")
            dlg.kalendar.Value = row.Item("bankacc_createdt").ToString
            dlg.txtDate.Text = dlg.kalendar.Value
            dlg.txtCreateBy.Text = row.Item("bankacc_createby").ToString
            dlg.txtReportName.Text = row.Item("bankacc_reportname").ToString
            dlg.txtFormBG.Text = row.Item("bankacc_formbg").ToString
            dlg.txtFormCek.Text = row.Item("bankacc_formcek").ToString
            dlg.txtFormTrf.Text = row.Item("bankacc_formtrf").ToString
            dlg.txtFormSet.Text = row.Item("bankacc_formset").ToString

            ''--Special Paramater
            dlg.txtIdCurrencyforCombo.Text = row.Item("currency_id")
            dlg.txtAccountforCombo.Text = row.Item("bankacc_account")


            If dlg.ShowDialog = DialogResult.OK Then
                row.Item("channel_id") = Me._CHANNEL
                row.Item("bankacc_ac") = dlg.txtAcc.Text
                row.Item("bankacc_name") = dlg.txtAccName.Text
                row.Item("bankacc_bank") = obj_Bank_id.Text
                row.Item("bankacc_account") = dlg.cmbAccount.SelectedValue

                row.Item("currency_id") = dlg.cmbCurrency.SelectedValue
                row.Item("bankacc_descr") = dlg.txtDescr.Text
                row.Item("bankacc_telp") = dlg.txtTlp.Text
                row.Item("bankacc_fax") = dlg.txtFax.Text
                row.Item("bankacc_branch") = dlg.txtBranch.Text
                row.Item("bankacc_address1") = dlg.txtAddr1.Text
                row.Item("bankacc_address2") = dlg.txtAddr2.Text
                row.Item("bankacc_active") = dlg.chkActive.Checked

                '--

                row.Item("bankacc_createdt") = dlg.kalendar.Value
                row.Item("bankacc_createby") = Me.UserName
                row.Item("bankacc_reportname") = dlg.txtReportName.Text
                row.Item("bankacc_formbg") = dlg.txtFormBG.Text
                row.Item("bankacc_formcek") = dlg.txtFormCek.Text
                row.Item("bankacc_formtrf") = dlg.txtFormTrf.Text
                row.Item("bankacc_formset") = dlg.txtFormSet.Text
            End If
        End If

    End Sub


    Private Sub DgvMstBankacc_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DgvMstBankacc.CellFormatting
        'Dim i As Integer
        Dim Fnd As String

        'For i = 0 To DgvMstBankacc.Rows.Count - 1
        'Fnd = tbl_MstBankacc_Temp.Rows(e.RowIndex).Item("bankacc_active")
        Fnd = DgvMstBankacc.Rows(e.RowIndex).Cells("bankacc_active").Value

        If Fnd = False Then
            DgvMstBankacc.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Red

        End If
        'Next

    End Sub

    Private Sub DgvMstBankacccontact_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvMstBankacccontact.CellDoubleClick

        Dim dlg As New dlgContact(DSN)
        Dim row As DataRow = CType(Me.DgvMstBankacccontact.CurrentRow.DataBoundItem, DataRowView).Row

        dlg.shortname.Text = row.Item("bankcontact_shortname")
        dlg.position.Text = row.Item("bankcontact_position")
        dlg.tlp.Text = row.Item("bankcontact_telp").ToString
        dlg.fax.Text = row.Item("bankcontact_fax").ToString
        dlg.addr1.Text = row.Item("bankcontact_address1").ToString
        dlg.addr2.Text = row.Item("bankcontact_address2").ToString
        dlg.idBankForContact.Text = obj_Bank_id.Text
        obj_Bank_id.Text = row.Item("bankcontact_id").ToString
        If dlg.ShowDialog = DialogResult.OK Then

            row.Item("channel_id") = Me._CHANNEL
            row.Item("bankcontact_shortname") = dlg.shortname.Text
            row.Item("bankcontact_position") = dlg.position.Text
            row.Item("bankcontact_telp") = dlg.tlp.Text
            row.Item("bankcontact_fax") = dlg.fax.Text
            row.Item("bankcontact_address1") = dlg.addr1.Text
            row.Item("bankcontact_address2") = dlg.addr2.Text
            row.Item("bankcontact_id") = obj_Bank_id.Text

        End If


    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim dlg As New dlgContact(DSN)

        Try
            If dlg.ShowDialog = DialogResult.OK Then
                Dim row As DataRow = Me.tbl_MstBankacccontact_Temp.NewRow

                row.Item("channel_id") = Me._CHANNEL
                row.Item("bankcontact_shortname") = dlg.shortname.Text
                row.Item("bankcontact_position") = dlg.position.Text
                row.Item("bankcontact_telp") = dlg.tlp.Text
                row.Item("bankcontact_fax") = dlg.fax.Text
                row.Item("bankcontact_address1") = dlg.addr1.Text
                row.Item("bankcontact_address2") = dlg.addr2.Text
                row.Item("bankcontact_id") = obj_Bank_id.Text

                Me.tbl_MstBankacccontact_Temp.Rows.Add(row)
                Dim rows As DataRow = CType(Me.DgvMstBankacccontact.CurrentRow.DataBoundItem, DataRowView).Row
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        Dim bankacc_id As Integer



        'MsgBox(id_acc)
        If DgvMstBankacc.Rows.Count > 0 Then
            bankacc_id = DgvMstBankacc.SelectedRows.Item(0).Cells("bankacc_id").Value
            Me.Master_BankAccount_DeleteRow(bankacc_id)
        Else
            MsgBox("Data Empty", MsgBoxStyle.Information)
        End If


    End Sub

    Private Sub DgvMstBank_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DgvMstBank.CellFormatting
        Dim col As String

        col = DgvMstBank.Rows(e.RowIndex).Cells("bank_active").Value
        If col = False Then
            DgvMstBank.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Red
        End If
    End Sub
End Class