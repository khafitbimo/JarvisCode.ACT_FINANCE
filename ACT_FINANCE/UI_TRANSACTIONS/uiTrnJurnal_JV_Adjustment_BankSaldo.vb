Imports Microsoft.Win32
Imports System.Threading
Imports System.ComponentModel
'Imports System.Data.DataSetExtensions

Public Class uiTrnJurnal_JV_Adjustment_BankSaldo
    Private Const mUiName As String = "Transaksi Jurnal JV Adjustment Bank Saldo"
    Private Const SHOW_SAVE_CONFIRMATION As Boolean = True

    Private Const ConstMyJurnalType As String = "JV"
    Private ConstMyJurnalSource As String = clsSource.JVAdjBankSaldo

    Private Event FormBeforeOpenRow(ByRef id As Object)
    Private Event FormAfterOpenRow(ByRef id As Object)
    Private Event FormBeforeSave(ByRef id As Object)
    Private Event FormAfterSave(ByRef id As Object, ByVal result As FormSaveResult)
    Private Event FormBeforeNew()
    Private Event FormBeforeDelete(ByRef id As Object)
    Private Event FormAfterDelete(ByRef id As Object)

    Private DATA_ISLOCKED As Boolean
    Private DATADETIL_OPENED As Boolean
    Private objFormError As Windows.Forms.ErrorProvider = New Windows.Forms.ErrorProvider

    'Table For Transaction
    Private tbl_TrnJurnal As DataTable = clsDataset.CreateTblTrnJurnal()
    Private tbl_TrnJurnal_Temp As DataTable = clsDataset.CreateTblTrnJurnal()
    Private tbl_TrnJurnaldetil_Debit As DataTable = clsDataset.CreateTblTrnJurnaldetilBilyet()
    Private tbl_TrnJurnaldetil_Credit As DataTable = clsDataset.CreateTblTrnJurnaldetilBilyet()
    Private tbl_TrnJurnalResponse As DataTable = clsDataset.CreateTblTrnJurnalreference()

    'Table For Master
    Private tbl_MstAcc_ca As DataTable = clsDataset.CreateTblMstAccountCaCombo()
    Private tbl_MstChannel As DataTable = clsDataset.CreateTblMstChannelCombo()
    Private tbl_MstCurrency As DataTable = clsDataset.CreateTblMstCurrencyCombo()
    Private tbl_MstPeriode As DataTable = clsDataset.CreateTblMstPeriodeCombo()
    Private tbl_MstRekanan As DataTable = clsDataset.CreateTblMstRekananCombo()
    Private tbl_TrnBudget As DataTable = clsDataset.CreateTblMstBudgetCombo()

    'Table For Search
    Private tbl_MstChannelSearch As DataTable = clsDataset.CreateTblMstChannelCombo()
    Private tbl_MstPeriodeSearch As DataTable = clsDataset.CreateTblMstPeriodeCombo()
    Private tbl_MstUserSearch As DataTable = clsDataset.CreateTblMstUserCombo()

    'Table For DatagridView
    Private tbl_MstAccGrid As DataTable = clsDataset.CreateTblMstAccountCombo()
    Private tbl_MstBankacc As DataTable = clsDataset.CreateTblMstBankAccCombo()
    Private tbl_MstCurrencyGrid As DataTable = clsDataset.CreateTblMstCurrencyCombo()
    Private tbl_MstPaymentTypeGrid As DataTable = clsDataset.CreateTblMstPaymenttypeCombo()
    Private tbl_MstPurposeFund As DataTable = clsDataset.CreateTblMstPurposefund()
    Private tbl_MstRekananGrid As DataTable = clsDataset.CreateTblMstRekananCombo()
    Private tbl_MstSlipFormat As DataTable = clsDataset.CreateTblMstSlipformat()
    Private tbl_MstStrukturunitGrid As DataTable = clsDataset.CreateTblMstStrukturunitCombo()
    Private tbl_TrnBudgetdetilGrid As DataTable = clsDataset.CreateTblMstBudgetdetilCombo()
    Private tbl_TrnBudgetGrid As DataTable = clsDataset.CreateTblMstBudgetCombo()


    Private tbl_MstShow As DataTable = clsDataset.CreateTblMstShow

    'Variable For BackgroundWorker
    Private isBackgroundWorker As Boolean = False
    Private isBackGroundWorker_isWork As Boolean = False
    Private isLoadComboInLoadData As Boolean = False
    Private label_thread As String

    'Variable For Additional Button
    Friend WithEvents btnPost As ToolStripButton = New ToolStripButton
    Friend WithEvents btnUnPost As ToolStripButton = New ToolStripButton
    Friend WithEvents btnCopyJurnal As ToolStripButton = New ToolStripButton

    'Variable For print
    Private tbl_Print As DataTable = clsDataset.CreateTblTrnJurnal
    Private tbl_PrintDetil As DataTable = clsDataset.CreateTblTrnJurnaldetil
    Private objPrintHeader As DataSource.clsRptJurnal_Header
    Private objPrintDetil As DataSource.clsRptJurnal_Detil

    Private objPrintHeaderPayment As DataSource.clsRptJurnalPV_Header
    Private objPrintDetilPayment As DataSource.clsRptJurnalPV_Detil

    Private m_streams As IList(Of System.IO.Stream)
    Private m_currentPageIndex As Integer
    Private objDatalistDetil As ArrayList

    Private parJurnal_id As String
    Private parJurnalType_id As String
    Private parJurnal_Source As String
    Private parJurnal_BookDate As String
    Private parPeriode_Name As String
    Private parCurrency_Name As String
    Private parJurnal_AmountForeign As String
    Private parRekanan_Name As String
    Private parJurnal_Desc As String

    Private strchannel_id As String
    Private sptChannel_nameReport As String
    Private sptChannel_address As String
    Private id As String
    Private p_date As Date
    Private curr As String
    Private isPrint As String

    Private AmountIdrNew As Decimal = 0
    Private AmountForeignNew As Decimal = 0
    Private parCreate_Date As String
    Private parBudget_name As String
    Private parAmountRate As Decimal = 0

    'variabled additional
    Private isNewButton As Boolean = False
    Private akunKerugianSelisihKursPajak As String
    Private akunKeuntunganSelisihKursPajak As String
    Private akun8009990 As String
    Private akun8509990 As String
    Private akunKerugianSelisihKurs As String
    Private akunKeuntunganSelisihKurs As String

    Private channel_number As String

#Region " Window Parameter "
    Private _CHANNEL As String = "TAS"
    Private _CHANNEL_CANBE_CHANGED As Boolean = False
    Private _CHANNEL_CANBE_BROWSED As Boolean = False

    ' TODO: Buat variabel untuk menampung parameter window 
    Private _SOURCE As String = ConstMyJurnalSource
    Private _USER_TYPE As String = "SPV" 'SPV 'STAFF 
#End Region

#Region " Additional Overrides "
    Private Sub btn_Rekanan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Rekanan.Click
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

    Private Sub btnPost_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPost.Click, btnUnPost.Click
        System.Windows.Forms.Cursor.Current = Cursors.WaitCursor
        If Me.uiTrnJurnal_JV_Manual_FormError() Then
            System.Windows.Forms.Cursor.Current = Cursors.Default
            Exit Sub
        End If
        Dim obj As ToolStripButton = sender
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbCmd As OleDb.OleDbCommand
        Dim UnSuccessfully_alert As String = String.Empty
        Dim tbl_TrnJurnalReference_temps As DataTable = New DataTable
        Dim k As Integer
        Dim cookie As Byte() = Nothing

        If obj.Name = "btnPost" Then
            dbCmd = New OleDb.OleDbCommand("act_TrnJurnal_Posting", dbConn)
            dbCmd.CommandType = CommandType.StoredProcedure
            dbCmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_id", System.Data.OleDb.OleDbType.VarWChar, 4000))
            dbCmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_postby", System.Data.OleDb.OleDbType.VarWChar, 32))
            dbCmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("@posting_method", System.Data.OleDb.OleDbType.VarWChar, 32))
            dbCmd.Parameters("@jurnal_id").Value = String.Format(" jurnal_id = '{0}'", Me.obj_Jurnal_id.Text)
            dbCmd.Parameters("@jurnal_postby").Value = Me.UserName
            dbCmd.Parameters("@posting_method").Value = "POSTING"

            Try
                dbConn.Open()
                clsApplicationRole.SetAppRole(dbConn, cookie)
                dbCmd.ExecuteNonQuery()
                Me.obj_Jurnal_isposted.Checked = True
                Me.tbtnSave.Enabled = Not Me.obj_Jurnal_isposted.Checked
                Me.tbtnDel.Enabled = Not Me.obj_Jurnal_isposted.Checked
                Me.btnPost.Visible = Not Me.obj_Jurnal_isposted.Checked
                Me.btnUnPost.Visible = Me.obj_Jurnal_isposted.Checked
                Me.DgvTrnJurnal.Item("jurnal_isposted", Me.DgvTrnJurnal.CurrentRow.Index).Value = True

                Me.btnUpload.Enabled = False

            Catch ex As Data.OleDb.OleDbException
                MessageBox.Show(ex.Message, "OLE DB Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "OLE DB Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Finally
                clsApplicationRole.UnsetAppRole(dbConn, cookie)
                dbConn.Close()
            End Try

        Else
            Dim a As String = Me.UserName
            'MsgBox(a)
            'Me.UserName = Me.UserName
            'Dim a As String = clsUtil.IsDbNull(Me.DgvTrnJurnal.Rows(Me.DgvTrnJurnal.CurrentRow.Index).Cells("jurnal_ispostedby").Value, String.Empty)
            tbl_TrnJurnalReference_temps.Clear()
            If Me.UserName = clsUtil.IsDbNull(Me.DgvTrnJurnal.Rows(Me.DgvTrnJurnal.CurrentRow.Index).Cells("jurnal_ispostedby").Value, String.Empty) Then
                Me.DataFill(tbl_TrnJurnalReference_temps, "act_TrnJurnalResponse_Select", Me.DgvTrnJurnal.Rows(Me.DgvTrnJurnal.CurrentRow.Index).Cells("jurnal_id").Value, Me._CHANNEL)
                If tbl_TrnJurnalReference_temps.Rows.Count > 0 Then
                    For k = 0 To tbl_TrnJurnalReference_temps.Rows.Count - 1
                        If UnSuccessfully_alert = String.Empty Or k = 0 Then
                            UnSuccessfully_alert = UnSuccessfully_alert & Me.DgvTrnJurnal.Rows(Me.DgvTrnJurnal.CurrentRow.Index).Cells("jurnal_id").Value & " Have response " & tbl_TrnJurnalReference_temps.Rows(k).Item("ref")
                        Else
                            UnSuccessfully_alert = UnSuccessfully_alert & ", " & Me.DgvTrnJurnal.Rows(Me.DgvTrnJurnal.CurrentRow.Index).Cells("jurnal_id").Value
                        End If
                    Next
                    MsgBox(UnSuccessfully_alert)
                    Exit Sub
                End If
            Else
                MsgBox("Access Denied")
                Exit Sub
            End If
            dbCmd = New OleDb.OleDbCommand("act_TrnJurnal_Posting", dbConn)
            dbCmd.CommandType = CommandType.StoredProcedure
            dbCmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_id", System.Data.OleDb.OleDbType.VarWChar, 4000))
            dbCmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_postby", System.Data.OleDb.OleDbType.VarWChar, 32))
            dbCmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("@posting_method", System.Data.OleDb.OleDbType.VarWChar, 32))
            dbCmd.Parameters("@jurnal_id").Value = String.Format(" jurnal_id = '{0}'", Me.obj_Jurnal_id.Text)
            dbCmd.Parameters("@jurnal_postby").Value = Me.UserName
            dbCmd.Parameters("@posting_method").Value = "UNPOSTING"

            Try
                dbConn.Open()
                clsApplicationRole.SetAppRole(dbConn, cookie)

                dbCmd.ExecuteNonQuery()
                Me.obj_Jurnal_isposted.Checked = False
                Me.tbtnSave.Enabled = Not Me.obj_Jurnal_isposted.Checked
                Me.tbtnDel.Enabled = Not Me.obj_Jurnal_isposted.Checked
                Me.btnPost.Visible = Not Me.obj_Jurnal_isposted.Checked
                Me.btnUnPost.Visible = Me.obj_Jurnal_isposted.Checked
                Me.DgvTrnJurnal.Item("jurnal_isposted", Me.DgvTrnJurnal.CurrentRow.Index).Value = False

                Me.btnUpload.Enabled = True

            Catch ex As Data.OleDb.OleDbException
                MessageBox.Show(ex.Message, "OLE DB Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "OLE DB Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Finally
                clsApplicationRole.UnsetAppRole(dbConn, cookie)
                dbConn.Close()
            End Try
        End If
        System.Windows.Forms.Cursor.Current = Cursors.Default
    End Sub

    Private Sub btnCopyJurnal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopyJurnal.Click
        System.Windows.Forms.Cursor.Current = Cursors.WaitCursor
        Dim row As DataRow
        Dim i, col As Integer
        Dim columnName As String
        Dim tbl_TrnJurnal_Copy As DataTable
        Dim tbl_TrnJurnaldetil_Debit_Copy As DataTable
        Dim tbl_TrnJurnaldetil_Credit_Copy As DataTable

        tbl_TrnJurnal_Copy = Me.tbl_TrnJurnal_Temp.Copy
        tbl_TrnJurnaldetil_Credit_Copy = Me.tbl_TrnJurnaldetil_Credit.Copy
        tbl_TrnJurnaldetil_Debit_Copy = Me.tbl_TrnJurnaldetil_Debit.Copy

        Me.uiTrnJurnal_JV_Manual_NewData()
        Me.tbl_TrnJurnal_Temp.Clear()
        Me.BindingStop()

        'Extract to Header
        For i = 0 To tbl_TrnJurnal_Copy.Rows.Count - 1
            row = Me.tbl_TrnJurnal_Temp.NewRow
            For col = 0 To tbl_TrnJurnal_Copy.Columns.Count - 1
                columnName = tbl_TrnJurnal_Copy.Columns(col).ColumnName
                If columnName = "jurnal_id" Or columnName = "jurnal_ispostedby" Or columnName = "jurnal_iscreatedby" Or columnName = "modified_by" Then
                    row(columnName) = String.Empty
                ElseIf columnName = "jurnal_isposted" Or columnName = "jurnal_iscreated" Then
                    row(columnName) = 0
                ElseIf columnName = "jurnal_isposteddate" Or columnName = "jurnal_iscreatedate" Then
                    row(columnName) = DBNull.Value
                ElseIf columnName = "created_by" Then
                    row(columnName) = Me.UserName
                ElseIf columnName = "created_dt" Or columnName = "modified_dt" Then
                    row(columnName) = Now
                Else
                    row(columnName) = tbl_TrnJurnal_Copy.Rows(i).Item(columnName)
                End If
            Next
            Me.tbl_TrnJurnal_Temp.Rows.Add(row)
        Next
        Me.BindingStart()


        For i = 0 To tbl_TrnJurnaldetil_Debit_Copy.Rows.Count - 1
            row = Me.tbl_TrnJurnaldetil_Debit.NewRow
            For col = 0 To tbl_TrnJurnaldetil_Debit_Copy.Columns.Count - 1
                columnName = tbl_TrnJurnaldetil_Debit_Copy.Columns(col).ColumnName
                If columnName = "jurnal_id" Then
                    row(columnName) = String.Empty
                Else
                    row(columnName) = tbl_TrnJurnaldetil_Debit_Copy.Rows(i).Item(columnName)
                End If
            Next
            Me.tbl_TrnJurnaldetil_Debit.Rows.Add(row)
        Next

        For i = 0 To tbl_TrnJurnaldetil_Credit_Copy.Rows.Count - 1
            row = Me.tbl_TrnJurnaldetil_Credit.NewRow
            For col = 0 To tbl_TrnJurnaldetil_Credit_Copy.Columns.Count - 1
                columnName = tbl_TrnJurnaldetil_Credit_Copy.Columns(col).ColumnName
                If columnName = "jurnal_id" Then
                    row(columnName) = String.Empty
                Else
                    row(columnName) = tbl_TrnJurnaldetil_Credit_Copy.Rows(i).Item(columnName)
                End If
            Next
            Me.tbl_TrnJurnaldetil_Credit.Rows.Add(row)
        Next

        Me.tbtnSave.Enabled = True
        System.Windows.Forms.Cursor.Current = Cursors.Default
    End Sub
#End Region

#Region " Overrides "

    Public Overrides Function btnQuery_Click() As Boolean
        Me.PnlDfSearch.Visible = Not Me.PnlDfSearch.Visible
        If Me.PnlDfSearch.Visible Then
            Me.tbtnQuery.CheckState = CheckState.Checked
        Else
            Me.tbtnQuery.CheckState = CheckState.Unchecked
        End If
        Return MyBase.btnQuery_Click()
    End Function

    Public Overrides Function btnNew_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        If Me.ftabMain.SelectedIndex = 0 Then
            Me.isNewButton = True
            Me.ftabMain.SelectedIndex = 1
            Me.isNewButton = False
            Me.uiTrnJurnal_JV_Manual_NewData()
            Me.obj_Currency_id.SelectedValue = 1

        Else
            Dim Message As String = "Data has been changed. " & vbCrLf & " Are you sure want to new data ?"
            Dim tbl_TrnJurnal_Temp_Changes As DataTable
            Dim tbl_TrnJurnaldetil_Debit_Changes As DataTable
            Dim tbl_TrnJurnaldetil_Credit_Changes As DataTable
            Dim res As System.Windows.Forms.DialogResult

            If Me.DgvTrnJurnal.CurrentCell IsNot Nothing Then

                Me.BindingContext(Me.tbl_TrnJurnal_Temp).EndCurrentEdit()
                tbl_TrnJurnal_Temp_Changes = Me.tbl_TrnJurnal_Temp.GetChanges()

                Me.DgvTrnJurnaldetil_Debit.EndEdit()
                Me.BindingContext(Me.tbl_TrnJurnaldetil_Debit).EndCurrentEdit()
                tbl_TrnJurnaldetil_Debit_Changes = Me.tbl_TrnJurnaldetil_Debit.GetChanges()

                Me.DgvTrnJurnaldetil_Credit.EndEdit()
                Me.BindingContext(Me.tbl_TrnJurnaldetil_Credit).EndCurrentEdit()
                tbl_TrnJurnaldetil_Credit_Changes = Me.tbl_TrnJurnaldetil_Credit.GetChanges()

                If tbl_TrnJurnal_Temp_Changes IsNot Nothing Or tbl_TrnJurnaldetil_Debit_Changes IsNot Nothing Or tbl_TrnJurnaldetil_Credit_Changes IsNot Nothing Then
                    res = MessageBox.Show(Message, "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    Select Case res
                        Case DialogResult.Yes
                            Me.uiTrnJurnal_JV_Manual_NewData()
                            Me.obj_Currency_id.SelectedValue = 1
                            Me.tbtnDel.Enabled = True
                            Me.tbtnSave.Enabled = True
                    End Select
                Else
                    Me.uiTrnJurnal_JV_Manual_NewData()
                    Me.obj_Currency_id.SelectedValue = 1
                    Me.tbtnDel.Enabled = True
                    Me.tbtnSave.Enabled = True
                End If
            Else
                Me.BindingContext(Me.tbl_TrnJurnal_Temp).EndCurrentEdit()
                tbl_TrnJurnal_Temp_Changes = Me.tbl_TrnJurnal_Temp.GetChanges()

                Me.DgvTrnJurnaldetil_Debit.EndEdit()
                Me.BindingContext(Me.tbl_TrnJurnaldetil_Debit).EndCurrentEdit()
                tbl_TrnJurnaldetil_Debit_Changes = Me.tbl_TrnJurnaldetil_Debit.GetChanges()

                Me.DgvTrnJurnaldetil_Credit.EndEdit()
                Me.BindingContext(Me.tbl_TrnJurnaldetil_Credit).EndCurrentEdit()
                tbl_TrnJurnaldetil_Credit_Changes = Me.tbl_TrnJurnaldetil_Credit.GetChanges()

                If tbl_TrnJurnal_Temp_Changes IsNot Nothing Or tbl_TrnJurnaldetil_Debit_Changes IsNot Nothing Or tbl_TrnJurnaldetil_Credit_Changes IsNot Nothing Then
                    res = MessageBox.Show(Message, mUiName, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    Select Case res
                        Case DialogResult.Yes
                            Me.uiTrnJurnal_JV_Manual_NewData()
                            Me.obj_Currency_id.SelectedValue = 1
                            Me.tbtnDel.Enabled = True
                            Me.tbtnSave.Enabled = True
                    End Select
                End If
            End If
        End If

        Me.Cursor = Cursors.Arrow
        Return MyBase.btnNew_Click()
    End Function

    Public Overrides Function btnLoad_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnJurnal_JV_Manual_Retrieve()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnLoad_Click()
    End Function

    Public Overrides Function btnSave_Click() As Boolean
        If Me.uiTrnJurnal_JV_Manual_FormError() Then
            Return True
        End If
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnJurnal_JV_Manual_Save()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnSave_Click()
    End Function

    Public Overrides Function btnPrint_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnJurnal_JV_Manual_Print()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnPrint_Click()
    End Function

    Public Overrides Function btnPrintPreview_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnJurnal_JV_Manual_PrintPreview()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnPrintPreview_Click()
    End Function

    Public Overrides Function btnDel_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Dim message As String = String.Empty
        Dim i As Integer
        If clsUtil.IsDbNull(Me.DgvTrnJurnal.Rows(Me.DgvTrnJurnal.CurrentRow.Index).Cells("created_by").Value, String.Empty) <> Me.UserName Then
            MsgBox("Access Denied")
        ElseIf clsUtil.IsDbNull(Me.DgvTrnJurnal.Rows(Me.DgvTrnJurnal.CurrentRow.Index).Cells("jurnal_isposted").Value, 0) = 1 Then
            MsgBox(" Data sudah diposting!!! Jadi Unposting dulu ya")
        ElseIf Me.DgvTrnJurnalResponse.Rows.Count > 0 Then
            For i = 0 To Me.DgvTrnJurnalResponse.Rows.Count - 1
                If message = String.Empty Then
                    message = Me.DgvTrnJurnalResponse.Rows(i).Cells("ref").Value & "(" & Me.DgvTrnJurnalResponse.Rows(i).Cells("line").Value & ")"
                Else
                    message &= ", " & Me.DgvTrnJurnalResponse.Rows(i).Cells("ref").Value & "(" & Me.DgvTrnJurnalResponse.Rows(i).Cells("line").Value & ")"
                End If
            Next
            message = " Data sudah dibuat jurnal di " & message
            MsgBox(message)
        Else
            Me.uiTrnJurnal_JV_Manual_Delete()
        End If
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnDel_Click()
    End Function

    Public Overrides Function btnFirst_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnJurnal_JV_Manual_First()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnFirst_Click()
    End Function

    Public Overrides Function btnPrev_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnJurnal_JV_Manual_Prev()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnPrev_Click()
    End Function

    Public Overrides Function btnNext_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnJurnal_JV_Manual_Next()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnNext_Click()
    End Function

    Public Overrides Function btnLast_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnJurnal_JV_Manual_Last()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnLast_Click()
    End Function
#End Region
    '==
#Region " Layout & Init UI "

    Private Function FormatDgvTrnJurnal(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        ' Format DgvTrnJurnal Columns 
        Dim cJurnal_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnal_bookdate As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnal_duedate As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnal_billdate As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnal_descr As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnal_invoice_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnal_invoice_descr As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnal_source As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnaltype_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekanan_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cPeriode_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cChannel_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBudget_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cCurrency_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cCurrency_rate As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cStrukturunit_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAcc_ca_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRegion_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBranch_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnal_iscreated As System.Windows.Forms.DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Dim cJurnal_iscreatedby As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnal_iscreatedate As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnal_isposted As System.Windows.Forms.DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Dim cJurnal_ispostedby As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnal_isposteddate As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnal_isdisabled As System.Windows.Forms.DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Dim cJurnal_isdisabledby As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnal_isdisableddt As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cCreated_by As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cCreated_dt As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cModified_by As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cModified_dt As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn

        'Tambahan
        Dim cJurnal_amountidr As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnal_amountforeign As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekanan_name As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cCurrency_name As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cPeriode_name As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn

        cJurnal_id.Name = "jurnal_id"
        cJurnal_id.HeaderText = "Jurnal ID"
        cJurnal_id.DataPropertyName = "jurnal_id"
        cJurnal_id.Width = 100
        cJurnal_id.Visible = True
        cJurnal_id.ReadOnly = False

        cJurnal_bookdate.Name = "jurnal_bookdate"
        cJurnal_bookdate.HeaderText = "Book Date"
        cJurnal_bookdate.DataPropertyName = "jurnal_bookdate"
        cJurnal_bookdate.Width = 100
        cJurnal_bookdate.Visible = True
        cJurnal_bookdate.ReadOnly = False

        cJurnal_duedate.Name = "jurnal_duedate"
        cJurnal_duedate.HeaderText = "Due Date"
        cJurnal_duedate.DataPropertyName = "jurnal_duedate"
        cJurnal_duedate.Width = 100
        cJurnal_duedate.Visible = False
        cJurnal_duedate.ReadOnly = False

        cJurnal_billdate.Name = "jurnal_billdate"
        cJurnal_billdate.HeaderText = "Bill Date"
        cJurnal_billdate.DataPropertyName = "jurnal_billdate"
        cJurnal_billdate.Width = 100
        cJurnal_billdate.Visible = False
        cJurnal_billdate.ReadOnly = False

        cJurnal_descr.Name = "jurnal_descr"
        cJurnal_descr.HeaderText = "Description"
        cJurnal_descr.DataPropertyName = "jurnal_descr"
        cJurnal_descr.Width = 150
        cJurnal_descr.Visible = True
        cJurnal_descr.ReadOnly = False

        cJurnal_invoice_id.Name = "jurnal_invoice_id"
        cJurnal_invoice_id.HeaderText = "Tax ID"
        cJurnal_invoice_id.DataPropertyName = "jurnal_invoice_id"
        cJurnal_invoice_id.Width = 100
        cJurnal_invoice_id.Visible = False
        cJurnal_invoice_id.ReadOnly = False

        cJurnal_invoice_descr.Name = "jurnal_invoice_descr"
        cJurnal_invoice_descr.HeaderText = "Invoice Descr."
        cJurnal_invoice_descr.DataPropertyName = "jurnal_invoice_descr"
        cJurnal_invoice_descr.Width = 100
        cJurnal_invoice_descr.Visible = False
        cJurnal_invoice_descr.ReadOnly = False

        cJurnal_source.Name = "jurnal_source"
        cJurnal_source.HeaderText = "Source"
        cJurnal_source.DataPropertyName = "jurnal_source"
        cJurnal_source.Width = 100
        cJurnal_source.Visible = True
        cJurnal_source.ReadOnly = False

        cJurnaltype_id.Name = "jurnaltype_id"
        cJurnaltype_id.HeaderText = "Type"
        cJurnaltype_id.DataPropertyName = "jurnaltype_id"
        cJurnaltype_id.Width = 100
        cJurnaltype_id.Visible = False
        cJurnaltype_id.ReadOnly = False

        cRekanan_id.Name = "rekanan_id"
        cRekanan_id.HeaderText = "Partner"
        cRekanan_id.DataPropertyName = "rekanan_id"
        cRekanan_id.Width = 150
        cRekanan_id.Visible = False
        cRekanan_id.ReadOnly = False

        cPeriode_id.Name = "periode_id"
        cPeriode_id.HeaderText = "Period"
        cPeriode_id.DataPropertyName = "periode_id"
        cPeriode_id.Width = 100
        cPeriode_id.Visible = False
        cPeriode_id.ReadOnly = False

        cChannel_id.Name = "channel_id"
        cChannel_id.HeaderText = "Company"
        cChannel_id.DataPropertyName = "channel_id"
        cChannel_id.Width = 100
        cChannel_id.Visible = True
        cChannel_id.ReadOnly = False

        cBudget_id.Name = "budget_id"
        cBudget_id.HeaderText = "Budget"
        cBudget_id.DataPropertyName = "budget_id"
        cBudget_id.Width = 100
        cBudget_id.Visible = False
        cBudget_id.ReadOnly = False

        cCurrency_id.Name = "currency_id"
        cCurrency_id.HeaderText = "Curr."
        cCurrency_id.DataPropertyName = "currency_id"
        cCurrency_id.Width = 100
        cCurrency_id.Visible = False
        cCurrency_id.ReadOnly = False

        cCurrency_rate.Name = "currency_rate"
        cCurrency_rate.HeaderText = "Rate"
        cCurrency_rate.DataPropertyName = "currency_rate"
        cCurrency_rate.Width = 100
        cCurrency_rate.Visible = True
        cCurrency_rate.ReadOnly = False

        cStrukturunit_id.Name = "strukturunit_id"
        cStrukturunit_id.HeaderText = "Department"
        cStrukturunit_id.DataPropertyName = "strukturunit_id"
        cStrukturunit_id.Width = 100
        cStrukturunit_id.Visible = False
        cStrukturunit_id.ReadOnly = False

        cAcc_ca_id.Name = "acc_ca_id"
        cAcc_ca_id.HeaderText = "Account Ca ID"
        cAcc_ca_id.DataPropertyName = "acc_ca_id"
        cAcc_ca_id.Width = 100
        cAcc_ca_id.Visible = False
        cAcc_ca_id.ReadOnly = False

        cRegion_id.Name = "region_id"
        cRegion_id.HeaderText = "region_id"
        cRegion_id.DataPropertyName = "region_id"
        cRegion_id.Width = 100
        cRegion_id.Visible = False
        cRegion_id.ReadOnly = False

        cBranch_id.Name = "branch_id"
        cBranch_id.HeaderText = "branch_id"
        cBranch_id.DataPropertyName = "branch_id"
        cBranch_id.Width = 100
        cBranch_id.Visible = False
        cBranch_id.ReadOnly = False

        cJurnal_iscreated.Name = "jurnal_iscreated"
        cJurnal_iscreated.HeaderText = "Created"
        cJurnal_iscreated.DataPropertyName = "jurnal_iscreated"
        cJurnal_iscreated.Width = 100
        cJurnal_iscreated.Visible = True
        cJurnal_iscreated.ReadOnly = False

        cJurnal_iscreatedby.Name = "jurnal_iscreatedby"
        cJurnal_iscreatedby.HeaderText = "Jurnal Created By"
        cJurnal_iscreatedby.DataPropertyName = "jurnal_iscreatedby"
        cJurnal_iscreatedby.Width = 130
        cJurnal_iscreatedby.Visible = True
        cJurnal_iscreatedby.ReadOnly = False

        cJurnal_iscreatedate.Name = "jurnal_iscreatedate"
        cJurnal_iscreatedate.HeaderText = "Jurnal Create Date"
        cJurnal_iscreatedate.DataPropertyName = "jurnal_iscreatedate"
        cJurnal_iscreatedate.Width = 130
        cJurnal_iscreatedate.Visible = True
        cJurnal_iscreatedate.ReadOnly = False

        cJurnal_isposted.Name = "jurnal_isposted"
        cJurnal_isposted.HeaderText = "Posted"
        cJurnal_isposted.DataPropertyName = "jurnal_isposted"
        cJurnal_isposted.Width = 100
        cJurnal_isposted.Visible = True
        cJurnal_isposted.ReadOnly = False

        cJurnal_ispostedby.Name = "jurnal_ispostedby"
        cJurnal_ispostedby.HeaderText = "Posted by"
        cJurnal_ispostedby.DataPropertyName = "jurnal_ispostedby"
        cJurnal_ispostedby.Width = 100
        cJurnal_ispostedby.Visible = True
        cJurnal_ispostedby.ReadOnly = False

        cJurnal_isposteddate.Name = "jurnal_isposteddate"
        cJurnal_isposteddate.HeaderText = "Posted Date"
        cJurnal_isposteddate.DataPropertyName = "jurnal_isposteddate"
        cJurnal_isposteddate.Width = 100
        cJurnal_isposteddate.Visible = True
        cJurnal_isposteddate.ReadOnly = False

        cJurnal_isdisabled.Name = "jurnal_isdisabled"
        cJurnal_isdisabled.HeaderText = "jurnal_isdisabled"
        cJurnal_isdisabled.DataPropertyName = "jurnal_isdisabled"
        cJurnal_isdisabled.Width = 100
        cJurnal_isdisabled.Visible = False
        cJurnal_isdisabled.ReadOnly = False

        cJurnal_isdisabledby.Name = "jurnal_isdisabledby"
        cJurnal_isdisabledby.HeaderText = "jurnal_isdisabledby"
        cJurnal_isdisabledby.DataPropertyName = "jurnal_isdisabledby"
        cJurnal_isdisabledby.Width = 100
        cJurnal_isdisabledby.Visible = False
        cJurnal_isdisabledby.ReadOnly = False

        cJurnal_isdisableddt.Name = "jurnal_isdisableddt"
        cJurnal_isdisableddt.HeaderText = "jurnal_isdisableddt"
        cJurnal_isdisableddt.DataPropertyName = "jurnal_isdisableddt"
        cJurnal_isdisableddt.Width = 100
        cJurnal_isdisableddt.Visible = False
        cJurnal_isdisableddt.ReadOnly = False

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
        cModified_dt.Width = 110
        cModified_dt.Visible = True
        cModified_dt.ReadOnly = False

        'Tambahan


        cJurnal_amountidr.Name = "jurnal_amountidr"
        cJurnal_amountidr.HeaderText = "Amount (IDR)"
        cJurnal_amountidr.DataPropertyName = "jurnal_amountidr"
        cJurnal_amountidr.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cJurnal_amountidr.DefaultCellStyle.Format = "#,##0"
        cJurnal_amountidr.Width = 120
        cJurnal_amountidr.Visible = True
        cJurnal_amountidr.ReadOnly = True

        cJurnal_amountforeign.Name = "jurnal_amountforeign"
        cJurnal_amountforeign.HeaderText = "Amount"
        cJurnal_amountforeign.DataPropertyName = "jurnal_amountforeign"
        cJurnal_amountforeign.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cJurnal_amountforeign.DefaultCellStyle.Format = "#,##0.00"
        cJurnal_amountforeign.Width = 120
        cJurnal_amountforeign.Visible = True
        cJurnal_amountforeign.ReadOnly = True

        cRekanan_name.Name = "rekanan_name"
        cRekanan_name.HeaderText = "Partner"
        cRekanan_name.DataPropertyName = "rekanan_name"
        cRekanan_name.Width = 150
        cRekanan_name.Visible = True
        cRekanan_name.ReadOnly = True

        cCurrency_name.Name = "currency_name"
        cCurrency_name.HeaderText = "Currency"
        cCurrency_name.DataPropertyName = "currency_name"
        cCurrency_name.Width = 70
        cCurrency_name.Visible = True
        cCurrency_name.ReadOnly = True

        cPeriode_name.Name = "periode_name"
        cPeriode_name.HeaderText = "Period"
        cPeriode_name.DataPropertyName = "periode_name"
        cPeriode_name.Width = 100
        cPeriode_name.Visible = True
        cPeriode_name.ReadOnly = True

        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
        {cJurnal_id, cJurnal_bookdate, cJurnal_duedate, cJurnal_billdate, cJurnal_descr, cRekanan_name, cRekanan_id, _
         cJurnal_invoice_id, cJurnal_invoice_descr, cCurrency_name, cJurnal_amountforeign, _
         cCurrency_rate, cJurnal_amountidr, cJurnal_iscreated, _
         cJurnal_iscreatedby, cJurnal_iscreatedate, cJurnal_isposted, cJurnal_ispostedby, _
         cJurnal_isposteddate, cJurnal_source, cJurnaltype_id, _
         cPeriode_id, cPeriode_name, cChannel_id, cBudget_id, cCurrency_id, _
         cStrukturunit_id, cAcc_ca_id, cRegion_id, cBranch_id, cJurnal_isdisabled, cJurnal_isdisabledby, cJurnal_isdisableddt, _
         cCreated_by, cCreated_dt, cModified_by, cModified_dt})


        ' DgvTrnJurnal Behaviours: 
        objDgv.AllowUserToAddRows = False
        objDgv.AllowUserToDeleteRows = False
        objDgv.AllowUserToResizeRows = False
        objDgv.AutoGenerateColumns = False
        objDgv.ReadOnly = True
        objDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        objDgv.Columns("jurnal_id").Frozen = True
    End Function

    Private Function FormatDgvTrnJurnaldetil_Credit(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        ' formating DgvTrnJurnaldetil
        Dim cJurnal_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnaldetil_line As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnaldetil_dk As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnaldetil_descr As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekanan_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekanan_name As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekanan_button As System.Windows.Forms.DataGridViewButtonColumn = New System.Windows.Forms.DataGridViewButtonColumn
        Dim cAcc_id As System.Windows.Forms.DataGridViewComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn
        Dim cAcc_no As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cCurrency_id As System.Windows.Forms.DataGridViewComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn
        Dim cJurnaldetil_foreign As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnaldetil_foreignrate As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnaldetil_idr As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cChannel_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cStrukturunit_id As System.Windows.Forms.DataGridViewComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn
        Dim cRef_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRef_line As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRef_budgetline As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRegion_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBranch_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBudget_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBudget_name As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBudget_button As System.Windows.Forms.DataGridViewButtonColumn = New System.Windows.Forms.DataGridViewButtonColumn
        Dim cBudgetdetil_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBudgetdetil_name As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBudgetdetil_button As System.Windows.Forms.DataGridViewButtonColumn = New System.Windows.Forms.DataGridViewButtonColumn

        ''Kolom tambahan
        Dim cPaymenttype_id As System.Windows.Forms.DataGridViewComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn
        Dim cBank_id As System.Windows.Forms.DataGridViewComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn
        Dim cJurnaldetil_bilyetno As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnaldetil_bilyetdate As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnaldetil_bilyetdateefective As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnaldetil_bilyetperson As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnaldetil_bilyetpic As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cCAacc_id As System.Windows.Forms.DataGridViewComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn
        Dim cCAacc_nm As System.Windows.Forms.DataGridViewComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn

        cJurnal_id.Name = "jurnal_id"
        cJurnal_id.HeaderText = "jurnal_id"
        cJurnal_id.DataPropertyName = "jurnal_id"
        cJurnal_id.Width = 100
        cJurnal_id.Visible = False
        cJurnal_id.ReadOnly = False

        cJurnaldetil_line.Name = "jurnaldetil_line"
        cJurnaldetil_line.HeaderText = "Line"
        cJurnaldetil_line.DataPropertyName = "jurnaldetil_line"
        cJurnaldetil_line.Width = 35
        cJurnaldetil_line.Visible = True
        cJurnaldetil_line.ReadOnly = True
        cJurnaldetil_line.DefaultCellStyle.BackColor = Color.LightYellow

        cJurnaldetil_dk.Name = "jurnaldetil_dk"
        cJurnaldetil_dk.HeaderText = "jurnaldetil_dk"
        cJurnaldetil_dk.DataPropertyName = "jurnaldetil_dk"
        cJurnaldetil_dk.Width = 100
        cJurnaldetil_dk.Visible = False
        cJurnaldetil_dk.ReadOnly = False

        cJurnaldetil_descr.Name = "jurnaldetil_descr"
        cJurnaldetil_descr.HeaderText = "Description"
        cJurnaldetil_descr.DataPropertyName = "jurnaldetil_descr"
        cJurnaldetil_descr.Width = 200
        cJurnaldetil_descr.Visible = True
        cJurnaldetil_descr.ReadOnly = False

        cRekanan_id.Name = "rekanan_id"
        cRekanan_id.HeaderText = "Vendor ID"
        cRekanan_id.DataPropertyName = "rekanan_id"
        cRekanan_id.Width = 85
        cRekanan_id.Visible = True
        cRekanan_id.ReadOnly = True
        cRekanan_id.DefaultCellStyle.BackColor = Color.LightYellow

        cRekanan_name.Name = "rekanan_name"
        cRekanan_name.HeaderText = "Vendor Name"
        cRekanan_name.DataPropertyName = "rekanan_name"
        cRekanan_name.Width = 150
        cRekanan_name.Visible = True
        cRekanan_name.ReadOnly = True
        cRekanan_name.DefaultCellStyle.BackColor = Color.LightYellow

        cRekanan_button.Name = "select_rekanan"
        cRekanan_button.HeaderText = ""
        cRekanan_button.Text = "..."
        cRekanan_button.UseColumnTextForButtonValue = True
        cRekanan_button.CellTemplate.Style.BackColor = Color.LightGray
        cRekanan_button.Width = 30
        cRekanan_button.DividerWidth = 3
        cRekanan_button.Visible = True
        cRekanan_button.ReadOnly = False

        cAcc_id.Name = "acc_id"
        cAcc_id.HeaderText = "Account"
        cAcc_id.DataPropertyName = "acc_id"
        cAcc_id.Width = 150
        cAcc_id.Visible = True
        cAcc_id.ReadOnly = False
        cAcc_id.DataSource = Me.tbl_MstAccGrid
        cAcc_id.DisplayMember = "acc_name"
        cAcc_id.ValueMember = "acc_id"
        cAcc_id.DisplayStyleForCurrentCellOnly = True

        cAcc_no.Name = "acc_id"
        cAcc_no.HeaderText = "COA"
        cAcc_no.DataPropertyName = "acc_id"
        cAcc_no.Width = 60
        cAcc_no.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cAcc_no.Visible = True
        cAcc_no.ReadOnly = False

        cCurrency_id.Name = "currency_id"
        cCurrency_id.HeaderText = "Curr."
        cCurrency_id.DataPropertyName = "currency_id"
        cCurrency_id.Width = 55
        cCurrency_id.Visible = True
        cCurrency_id.ReadOnly = True
        cCurrency_id.DefaultCellStyle.BackColor = Color.LightYellow
        cCurrency_id.DataSource = Me.tbl_MstCurrencyGrid
        cCurrency_id.DisplayMember = "currency_shortname"
        cCurrency_id.ValueMember = "currency_id"
        cCurrency_id.DisplayStyleForCurrentCellOnly = True

        cJurnaldetil_foreign.Name = "jurnaldetil_foreign"
        cJurnaldetil_foreign.HeaderText = "Amount"
        cJurnaldetil_foreign.DataPropertyName = "jurnaldetil_foreign"
        cJurnaldetil_foreign.Width = 125
        cJurnaldetil_foreign.Visible = True
        cJurnaldetil_foreign.ReadOnly = False
        cJurnaldetil_foreign.DefaultCellStyle.Format = "#,##0.00"
        cJurnaldetil_foreign.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        cJurnaldetil_foreignrate.Name = "jurnaldetil_foreignrate"
        cJurnaldetil_foreignrate.HeaderText = "Rate"
        cJurnaldetil_foreignrate.DataPropertyName = "jurnaldetil_foreignrate"
        cJurnaldetil_foreignrate.Width = 70
        cJurnaldetil_foreignrate.Visible = True
        cJurnaldetil_foreignrate.ReadOnly = False
        cJurnaldetil_foreignrate.DefaultCellStyle.Format = "#,##0.00"
        cJurnaldetil_foreignrate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        cJurnaldetil_idr.Name = "jurnaldetil_idr"
        cJurnaldetil_idr.HeaderText = "Amount (IDR)"
        cJurnaldetil_idr.DataPropertyName = "jurnaldetil_idr"
        cJurnaldetil_idr.Width = 125
        cJurnaldetil_idr.Visible = True
        cJurnaldetil_idr.ReadOnly = True
        cJurnaldetil_idr.DefaultCellStyle.Format = "#,##0"
        cJurnaldetil_idr.DefaultCellStyle.BackColor = Color.LightYellow
        cJurnaldetil_idr.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        cChannel_id.Name = "channel_id"
        cChannel_id.HeaderText = "channel_id"
        cChannel_id.DataPropertyName = "channel_id"
        cChannel_id.Width = 100
        cChannel_id.Visible = False
        cChannel_id.ReadOnly = False

        cStrukturunit_id.Name = "strukturunit_id"
        cStrukturunit_id.HeaderText = "Department"
        cStrukturunit_id.DataPropertyName = "strukturunit_id"
        cStrukturunit_id.Width = 150
        cStrukturunit_id.Visible = True
        cStrukturunit_id.ReadOnly = False
        cStrukturunit_id.DataSource = Me.tbl_MstStrukturunitGrid
        cStrukturunit_id.DisplayMember = "strukturunit_name"
        cStrukturunit_id.ValueMember = "strukturunit_id"
        cStrukturunit_id.DisplayStyleForCurrentCellOnly = True

        cRef_id.Name = "ref_id"
        cRef_id.HeaderText = "Ref ID"
        cRef_id.DataPropertyName = "ref_id"
        cRef_id.Width = 100
        cRef_id.Visible = False
        cRef_id.ReadOnly = True
        cRef_id.DefaultCellStyle.BackColor = Color.LightYellow

        cRef_line.Name = "ref_line"
        cRef_line.HeaderText = "Ref.Ln"
        cRef_line.DataPropertyName = "ref_line"
        cRef_line.Width = 50
        cRef_line.Visible = False
        cRef_line.ReadOnly = True
        cRef_line.DefaultCellStyle.BackColor = Color.LightYellow

        cRef_budgetline.Name = "ref_budgetline"
        cRef_budgetline.HeaderText = "Ref.BudgetLn"
        cRef_budgetline.DataPropertyName = "ref_budgetline"
        cRef_budgetline.Width = 80
        cRef_budgetline.Visible = False
        cRef_budgetline.ReadOnly = True
        cRef_budgetline.DefaultCellStyle.BackColor = Color.LightYellow

        cRegion_id.Name = "region_id"
        cRegion_id.HeaderText = "region_id"
        cRegion_id.DataPropertyName = "region_id"
        cRegion_id.Width = 100
        cRegion_id.Visible = False
        cRegion_id.ReadOnly = False

        cBranch_id.Name = "branch_id"
        cBranch_id.HeaderText = "branch_id"
        cBranch_id.DataPropertyName = "branch_id"
        cBranch_id.Width = 100
        cBranch_id.Visible = False
        cBranch_id.ReadOnly = False

        cBudget_id.Name = "budget_id"
        cBudget_id.HeaderText = "Budget ID"
        cBudget_id.DataPropertyName = "budget_id"
        cBudget_id.Width = 85
        cBudget_id.Visible = True
        cBudget_id.ReadOnly = False
        cBudget_id.DefaultCellStyle.BackColor = Color.LightYellow

        cBudget_name.Name = "budget_name"
        cBudget_name.HeaderText = "Budget Name"
        cBudget_name.DataPropertyName = "budget_name"
        cBudget_name.Width = 150
        cBudget_name.Visible = True
        cBudget_name.ReadOnly = True
        cBudget_name.DefaultCellStyle.BackColor = Color.LightYellow

        cBudget_button.Name = "select_budget"
        cBudget_button.HeaderText = ""
        cBudget_button.Text = "..."
        cBudget_button.UseColumnTextForButtonValue = True
        cBudget_button.CellTemplate.Style.BackColor = Color.LightGray
        cBudget_button.Width = 30
        cBudget_button.DividerWidth = 3
        cBudget_button.Visible = True
        cBudget_button.ReadOnly = False


        cBudgetdetil_id.Name = "budgetdetil_id"
        cBudgetdetil_id.HeaderText = "Budget Detil ID"
        cBudgetdetil_id.DataPropertyName = "budgetdetil_id"
        cBudgetdetil_id.Width = 110
        cBudgetdetil_id.Visible = True
        cBudgetdetil_id.ReadOnly = False
        cBudgetdetil_id.DefaultCellStyle.BackColor = Color.LightYellow

        cBudgetdetil_name.Name = "budgetdetil_name"
        cBudgetdetil_name.HeaderText = "Budget Detil Name"
        cBudgetdetil_name.DataPropertyName = "budgetdetil_name"
        cBudgetdetil_name.Width = 150
        cBudgetdetil_name.Visible = True
        cBudgetdetil_name.ReadOnly = True
        cBudgetdetil_name.DefaultCellStyle.BackColor = Color.LightYellow

        cBudgetdetil_button.Name = "select_budget_detil"
        cBudgetdetil_button.HeaderText = ""
        cBudgetdetil_button.Text = "..."
        cBudgetdetil_button.UseColumnTextForButtonValue = True
        cBudgetdetil_button.CellTemplate.Style.BackColor = Color.LightGray
        cBudgetdetil_button.Width = 30
        cBudgetdetil_button.DividerWidth = 3
        cBudgetdetil_button.Visible = True
        cBudgetdetil_button.ReadOnly = False

        ' ''Kolom tambahan
        cPaymenttype_id.Name = "paymenttype_id"
        cPaymenttype_id.HeaderText = "Payment Type"
        cPaymenttype_id.DataPropertyName = "paymenttype_id"
        cPaymenttype_id.Width = 100
        cPaymenttype_id.Visible = True
        cPaymenttype_id.ReadOnly = False
        cPaymenttype_id.DataSource = Me.tbl_MstPaymentTypeGrid
        cPaymenttype_id.ValueMember = "paymenttype_id"
        cPaymenttype_id.DisplayMember = "paymenttype_name"
        cPaymenttype_id.DisplayStyleForCurrentCellOnly = True

        cBank_id.Name = "jurnalbilyet_bank"
        cBank_id.HeaderText = "Bank"
        cBank_id.DataPropertyName = "jurnalbilyet_bank"
        cBank_id.Width = 100
        cBank_id.Visible = True
        cBank_id.ReadOnly = False
        cBank_id.DisplayMember = "bankacc_reportname"
        cBank_id.ValueMember = "bankacc_id"
        cBank_id.DataSource = Me.tbl_MstBankacc
        cBank_id.DisplayStyleForCurrentCellOnly = True

        cJurnaldetil_bilyetno.Name = "jurnalbilyet_no"
        cJurnaldetil_bilyetno.HeaderText = "No Bilyet"
        cJurnaldetil_bilyetno.DataPropertyName = "jurnalbilyet_no"
        cJurnaldetil_bilyetno.Width = 100
        cJurnaldetil_bilyetno.Visible = False
        cJurnaldetil_bilyetno.ReadOnly = False

        cJurnaldetil_bilyetdate.Name = "jurnalbilyet_date"
        cJurnaldetil_bilyetdate.HeaderText = "Tgl Bilyet"
        cJurnaldetil_bilyetdate.DataPropertyName = "jurnalbilyet_date"
        cJurnaldetil_bilyetdate.Width = 100
        cJurnaldetil_bilyetdate.Visible = False
        cJurnaldetil_bilyetdate.ReadOnly = False
        cJurnaldetil_bilyetdate.DefaultCellStyle.Format = "dd/MM/yyyy"

        cJurnaldetil_bilyetdateefective.Name = "jurnalbilyet_dateeffective"
        cJurnaldetil_bilyetdateefective.HeaderText = "Tgl Efektif"
        cJurnaldetil_bilyetdateefective.DataPropertyName = "jurnalbilyet_dateeffective"
        cJurnaldetil_bilyetdateefective.Width = 100
        cJurnaldetil_bilyetdateefective.Visible = False
        cJurnaldetil_bilyetdateefective.ReadOnly = False
        cJurnaldetil_bilyetdateefective.DefaultCellStyle.Format = "dd/MM/yyyy"

        cJurnaldetil_bilyetperson.Name = "jurnalbilyet_receiveperson"
        cJurnaldetil_bilyetperson.HeaderText = "Received By"
        cJurnaldetil_bilyetperson.DataPropertyName = "jurnalbilyet_receiveperson"
        cJurnaldetil_bilyetperson.Width = 150
        cJurnaldetil_bilyetperson.Visible = False
        cJurnaldetil_bilyetperson.ReadOnly = False

        cJurnaldetil_bilyetpic.Name = "jurnalbilyet_pic"
        cJurnaldetil_bilyetpic.HeaderText = "Penanggung Jawab"
        cJurnaldetil_bilyetpic.DataPropertyName = "jurnalbilyet_pic"
        cJurnaldetil_bilyetpic.Width = 100
        cJurnaldetil_bilyetpic.Visible = False
        cJurnaldetil_bilyetpic.ReadOnly = False

        cCAacc_id.Name = "region_id"
        cCAacc_id.HeaderText = "Acc CA ID"
        cCAacc_id.DataPropertyName = "region_id"
        cCAacc_id.Width = 80
        cCAacc_id.Visible = True
        cCAacc_id.ReadOnly = False
        cCAacc_id.DataSource = Me.tbl_MstAcc_ca
        cCAacc_id.DisplayMember = "acc_ca_id"
        cCAacc_id.ValueMember = "acc_ca_id"
        cCAacc_id.DisplayStyleForCurrentCellOnly = True

        cCAacc_nm.Name = "acc_ca_name"
        cCAacc_nm.HeaderText = "Acc CA Name"
        cCAacc_nm.DataPropertyName = "region_id"
        cCAacc_nm.Width = 200
        cCAacc_nm.Visible = True
        cCAacc_nm.ReadOnly = False
        cCAacc_nm.DataSource = Me.tbl_MstAcc_ca
        cCAacc_nm.DisplayMember = "acc_ca_shortname"
        cCAacc_nm.ValueMember = "acc_ca_id"
        cCAacc_nm.DisplayStyleForCurrentCellOnly = True


        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
        {cJurnaldetil_line, cAcc_id, cAcc_no, cJurnaldetil_descr, cRef_id, _
         cCurrency_id, cJurnaldetil_foreign, cJurnaldetil_foreignrate, cJurnaldetil_idr, _
         cRekanan_id, cRekanan_name, cRekanan_button, cJurnal_id, cJurnaldetil_dk, _
         cChannel_id, _
         cRef_line, cRef_budgetline, cRegion_id, cBranch_id, _
         cBudget_id, cBudget_name, cBudget_button, _
         cBudgetdetil_id, cBudgetdetil_name, cBudgetdetil_button, cStrukturunit_id, _
         cPaymenttype_id, cBank_id, cJurnaldetil_bilyetno, cJurnaldetil_bilyetdate, _
         cJurnaldetil_bilyetdateefective, cJurnaldetil_bilyetperson, cJurnaldetil_bilyetpic, cCAacc_id, cCAacc_nm})

        objDgv.AutoGenerateColumns = False
        objDgv.AllowUserToAddRows = True
        objDgv.AllowUserToDeleteRows = True
        objDgv.Columns("acc_id").Frozen = True
    End Function

    Private Function FormatDgvTrnJurnaldetil_Debit(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        ' formating DgvTrnJurnaldetil
        Dim cJurnal_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnaldetil_line As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnaldetil_dk As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnaldetil_descr As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekanan_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekanan_name As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekanan_button As System.Windows.Forms.DataGridViewButtonColumn = New System.Windows.Forms.DataGridViewButtonColumn
        Dim cAcc_id As System.Windows.Forms.DataGridViewComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn
        Dim cAcc_no As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cCurrency_id As System.Windows.Forms.DataGridViewComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn
        Dim cJurnaldetil_foreign As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnaldetil_foreignrate As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnaldetil_idr As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cChannel_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cStrukturunit_id As System.Windows.Forms.DataGridViewComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn
        Dim cRef_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRef_line As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRef_budgetline As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRegion_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBranch_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBudget_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBudget_name As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBudget_button As System.Windows.Forms.DataGridViewButtonColumn = New System.Windows.Forms.DataGridViewButtonColumn
        Dim cBudgetdetil_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBudgetdetil_name As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBudgetdetil_button As System.Windows.Forms.DataGridViewButtonColumn = New System.Windows.Forms.DataGridViewButtonColumn

        ''Kolom tambahan
        Dim cPaymenttype_id As System.Windows.Forms.DataGridViewComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn
        Dim cBank_id As System.Windows.Forms.DataGridViewComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn
        Dim cJurnaldetil_bilyetno As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnaldetil_bilyetdate As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnaldetil_bilyetdateefective As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnaldetil_bilyetperson As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnaldetil_bilyetpic As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cCAacc_id As System.Windows.Forms.DataGridViewComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn
        Dim cCAacc_nm As System.Windows.Forms.DataGridViewComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn

        cJurnal_id.Name = "jurnal_id"
        cJurnal_id.HeaderText = "jurnal_id"
        cJurnal_id.DataPropertyName = "jurnal_id"
        cJurnal_id.Width = 100
        cJurnal_id.Visible = False
        cJurnal_id.ReadOnly = False

        cJurnaldetil_line.Name = "jurnaldetil_line"
        cJurnaldetil_line.HeaderText = "Line"
        cJurnaldetil_line.DataPropertyName = "jurnaldetil_line"
        cJurnaldetil_line.Width = 35
        cJurnaldetil_line.Visible = True
        cJurnaldetil_line.ReadOnly = True
        cJurnaldetil_line.DefaultCellStyle.BackColor = Color.LightYellow

        cJurnaldetil_dk.Name = "jurnaldetil_dk"
        cJurnaldetil_dk.HeaderText = "jurnaldetil_dk"
        cJurnaldetil_dk.DataPropertyName = "jurnaldetil_dk"
        cJurnaldetil_dk.Width = 100
        cJurnaldetil_dk.Visible = False
        cJurnaldetil_dk.ReadOnly = False

        cJurnaldetil_descr.Name = "jurnaldetil_descr"
        cJurnaldetil_descr.HeaderText = "Description"
        cJurnaldetil_descr.DataPropertyName = "jurnaldetil_descr"
        cJurnaldetil_descr.Width = 200
        cJurnaldetil_descr.Visible = True
        cJurnaldetil_descr.ReadOnly = False

        cRekanan_id.Name = "rekanan_id"
        cRekanan_id.HeaderText = "Vendor ID"
        cRekanan_id.DataPropertyName = "rekanan_id"
        cRekanan_id.Width = 85
        cRekanan_id.Visible = True
        cRekanan_id.ReadOnly = True
        cRekanan_id.DefaultCellStyle.BackColor = Color.LightYellow
        cRekanan_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        cRekanan_name.Name = "rekanan_name"
        cRekanan_name.HeaderText = "Vendor Name"
        cRekanan_name.DataPropertyName = "rekanan_name"
        cRekanan_name.Width = 150
        cRekanan_name.Visible = True
        cRekanan_name.ReadOnly = True
        cRekanan_name.DefaultCellStyle.BackColor = Color.LightYellow

        cRekanan_button.Name = "select_rekanan"
        cRekanan_button.HeaderText = ""
        cRekanan_button.Text = "..."
        cRekanan_button.UseColumnTextForButtonValue = True
        cRekanan_button.CellTemplate.Style.BackColor = Color.LightGray
        cRekanan_button.Width = 30
        cRekanan_button.DividerWidth = 3
        cRekanan_button.Visible = True
        cRekanan_button.ReadOnly = False

        cAcc_id.Name = "acc_id"
        cAcc_id.HeaderText = "Account"
        cAcc_id.DataPropertyName = "acc_id"
        cAcc_id.Width = 150
        cAcc_id.Visible = True
        cAcc_id.ReadOnly = False
        cAcc_id.DataSource = Me.tbl_MstAccGrid
        cAcc_id.DisplayMember = "acc_name"
        cAcc_id.ValueMember = "acc_id"
        cAcc_id.DisplayStyleForCurrentCellOnly = True

        cAcc_no.Name = "acc_id"
        cAcc_no.HeaderText = "COA"
        cAcc_no.DataPropertyName = "acc_id"
        cAcc_no.Width = 60
        cAcc_no.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cAcc_no.Visible = True
        cAcc_no.ReadOnly = False

        cCurrency_id.Name = "currency_id"
        cCurrency_id.HeaderText = "Curr."
        cCurrency_id.DataPropertyName = "currency_id"
        cCurrency_id.Width = 55
        cCurrency_id.Visible = True
        cCurrency_id.ReadOnly = True
        cCurrency_id.DefaultCellStyle.BackColor = Color.LightYellow
        cCurrency_id.DataSource = Me.tbl_MstCurrencyGrid
        cCurrency_id.DisplayMember = "currency_shortname"
        cCurrency_id.ValueMember = "currency_id"
        cCurrency_id.DisplayStyleForCurrentCellOnly = True

        cJurnaldetil_foreign.Name = "jurnaldetil_foreign"
        cJurnaldetil_foreign.HeaderText = "Amount"
        cJurnaldetil_foreign.DataPropertyName = "jurnaldetil_foreign"
        cJurnaldetil_foreign.Width = 125
        cJurnaldetil_foreign.Visible = True
        cJurnaldetil_foreign.ReadOnly = False
        cJurnaldetil_foreign.DefaultCellStyle.Format = "#,##0.00"
        cJurnaldetil_foreign.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        cJurnaldetil_foreignrate.Name = "jurnaldetil_foreignrate"
        cJurnaldetil_foreignrate.HeaderText = "Rate"
        cJurnaldetil_foreignrate.DataPropertyName = "jurnaldetil_foreignrate"
        cJurnaldetil_foreignrate.Width = 70
        cJurnaldetil_foreignrate.Visible = True
        cJurnaldetil_foreignrate.ReadOnly = False
        cJurnaldetil_foreignrate.DefaultCellStyle.Format = "#,##0.00"
        cJurnaldetil_foreignrate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        cJurnaldetil_idr.Name = "jurnaldetil_idr"
        cJurnaldetil_idr.HeaderText = "Amount (IDR)"
        cJurnaldetil_idr.DataPropertyName = "jurnaldetil_idr"
        cJurnaldetil_idr.Width = 125
        cJurnaldetil_idr.Visible = True
        cJurnaldetil_idr.ReadOnly = True
        cJurnaldetil_idr.DefaultCellStyle.Format = "#,##0"
        cJurnaldetil_idr.DefaultCellStyle.BackColor = Color.LightYellow
        cJurnaldetil_idr.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        cChannel_id.Name = "channel_id"
        cChannel_id.HeaderText = "channel_id"
        cChannel_id.DataPropertyName = "channel_id"
        cChannel_id.Width = 100
        cChannel_id.Visible = False
        cChannel_id.ReadOnly = False

        cStrukturunit_id.Name = "strukturunit_id"
        cStrukturunit_id.HeaderText = "Department"
        cStrukturunit_id.DataPropertyName = "strukturunit_id"
        cStrukturunit_id.Width = 150
        cStrukturunit_id.Visible = True
        cStrukturunit_id.ReadOnly = False
        cStrukturunit_id.DataSource = Me.tbl_MstStrukturunitGrid
        cStrukturunit_id.DisplayMember = "strukturunit_name"
        cStrukturunit_id.ValueMember = "strukturunit_id"
        cStrukturunit_id.DisplayStyleForCurrentCellOnly = True

        cRef_id.Name = "ref_id"
        cRef_id.HeaderText = "Ref ID"
        cRef_id.DataPropertyName = "ref_id"
        cRef_id.Width = 100
        cRef_id.Visible = False
        cRef_id.ReadOnly = True
        cRef_id.DefaultCellStyle.BackColor = Color.LightYellow

        cRef_line.Name = "ref_line"
        cRef_line.HeaderText = "Ref.Ln"
        cRef_line.DataPropertyName = "ref_line"
        cRef_line.Width = 50
        cRef_line.Visible = False
        cRef_line.ReadOnly = True
        cRef_line.DefaultCellStyle.BackColor = Color.LightYellow

        cRef_budgetline.Name = "ref_budgetline"
        cRef_budgetline.HeaderText = "Ref.BudgetLn"
        cRef_budgetline.DataPropertyName = "ref_budgetline"
        cRef_budgetline.Width = 80
        cRef_budgetline.Visible = False
        cRef_budgetline.ReadOnly = True
        cRef_budgetline.DefaultCellStyle.BackColor = Color.LightYellow

        cRegion_id.Name = "region_id"
        cRegion_id.HeaderText = "region_id"
        cRegion_id.DataPropertyName = "region_id"
        cRegion_id.Width = 100
        cRegion_id.Visible = False
        cRegion_id.ReadOnly = False

        cBranch_id.Name = "branch_id"
        cBranch_id.HeaderText = "branch_id"
        cBranch_id.DataPropertyName = "branch_id"
        cBranch_id.Width = 100
        cBranch_id.Visible = False
        cBranch_id.ReadOnly = False

        cBudget_id.Name = "budget_id"
        cBudget_id.HeaderText = "Budget ID"
        cBudget_id.DataPropertyName = "budget_id"
        cBudget_id.Width = 85
        cBudget_id.Visible = True
        cBudget_id.ReadOnly = False
        cBudget_id.DefaultCellStyle.BackColor = Color.LightYellow

        cBudget_name.Name = "budget_name"
        cBudget_name.HeaderText = "Budget Name"
        cBudget_name.DataPropertyName = "budget_name"
        cBudget_name.Width = 150
        cBudget_name.Visible = True
        cBudget_name.ReadOnly = True
        cBudget_name.DefaultCellStyle.BackColor = Color.LightYellow

        cBudget_button.Name = "select_budget"
        cBudget_button.HeaderText = ""
        cBudget_button.Text = "..."
        cBudget_button.UseColumnTextForButtonValue = True
        cBudget_button.CellTemplate.Style.BackColor = Color.LightGray
        cBudget_button.Width = 30
        cBudget_button.DividerWidth = 3
        cBudget_button.Visible = True
        cBudget_button.ReadOnly = False


        cBudgetdetil_id.Name = "budgetdetil_id"
        cBudgetdetil_id.HeaderText = "Budget Detil ID"
        cBudgetdetil_id.DataPropertyName = "budgetdetil_id"
        cBudgetdetil_id.Width = 110
        cBudgetdetil_id.Visible = True
        cBudgetdetil_id.ReadOnly = False
        cBudgetdetil_id.DefaultCellStyle.BackColor = Color.LightYellow

        cBudgetdetil_name.Name = "budgetdetil_name"
        cBudgetdetil_name.HeaderText = "Budget Detil Name"
        cBudgetdetil_name.DataPropertyName = "budgetdetil_name"
        cBudgetdetil_name.Width = 150
        cBudgetdetil_name.Visible = True
        cBudgetdetil_name.ReadOnly = True
        cBudgetdetil_name.DefaultCellStyle.BackColor = Color.LightYellow

        cBudgetdetil_button.Name = "select_budget_detil"
        cBudgetdetil_button.HeaderText = ""
        cBudgetdetil_button.Text = "..."
        cBudgetdetil_button.UseColumnTextForButtonValue = True
        cBudgetdetil_button.CellTemplate.Style.BackColor = Color.LightGray
        cBudgetdetil_button.Width = 30
        cBudgetdetil_button.DividerWidth = 3
        cBudgetdetil_button.Visible = True
        cBudgetdetil_button.ReadOnly = False

        ' ''Kolom tambahan
        cPaymenttype_id.Name = "paymenttype_id"
        cPaymenttype_id.HeaderText = "Payment Type"
        cPaymenttype_id.DataPropertyName = "paymenttype_id"
        cPaymenttype_id.Width = 100
        cPaymenttype_id.Visible = True
        cPaymenttype_id.ReadOnly = False
        cPaymenttype_id.DataSource = Me.tbl_MstPaymentTypeGrid
        cPaymenttype_id.ValueMember = "paymenttype_id"
        cPaymenttype_id.DisplayMember = "paymenttype_name"
        cPaymenttype_id.DisplayStyleForCurrentCellOnly = True

        cBank_id.Name = "jurnalbilyet_bank"
        cBank_id.HeaderText = "Bank"
        cBank_id.DataPropertyName = "jurnalbilyet_bank"
        cBank_id.Width = 100
        cBank_id.Visible = True
        cBank_id.ReadOnly = False
        cBank_id.DisplayMember = "bankacc_reportname"
        cBank_id.ValueMember = "bankacc_id"
        cBank_id.DataSource = Me.tbl_MstBankacc
        cBank_id.DisplayStyleForCurrentCellOnly = True

        cJurnaldetil_bilyetno.Name = "jurnalbilyet_no"
        cJurnaldetil_bilyetno.HeaderText = "No Bilyet"
        cJurnaldetil_bilyetno.DataPropertyName = "jurnalbilyet_no"
        cJurnaldetil_bilyetno.Width = 100
        cJurnaldetil_bilyetno.Visible = False
        cJurnaldetil_bilyetno.ReadOnly = False

        cJurnaldetil_bilyetdate.Name = "jurnalbilyet_date"
        cJurnaldetil_bilyetdate.HeaderText = "Tgl Bilyet"
        cJurnaldetil_bilyetdate.DataPropertyName = "jurnalbilyet_date"
        cJurnaldetil_bilyetdate.Width = 100
        cJurnaldetil_bilyetdate.Visible = False
        cJurnaldetil_bilyetdate.ReadOnly = False
        cJurnaldetil_bilyetdate.DefaultCellStyle.Format = "dd/MM/yyyy"

        cJurnaldetil_bilyetdateefective.Name = "jurnalbilyet_dateeffective"
        cJurnaldetil_bilyetdateefective.HeaderText = "Tgl Efektif"
        cJurnaldetil_bilyetdateefective.DataPropertyName = "jurnalbilyet_dateeffective"
        cJurnaldetil_bilyetdateefective.Width = 100
        cJurnaldetil_bilyetdateefective.Visible = False
        cJurnaldetil_bilyetdateefective.ReadOnly = False
        cJurnaldetil_bilyetdateefective.DefaultCellStyle.Format = "dd/MM/yyyy"

        cJurnaldetil_bilyetperson.Name = "jurnalbilyet_receiveperson"
        cJurnaldetil_bilyetperson.HeaderText = "Received By"
        cJurnaldetil_bilyetperson.DataPropertyName = "jurnalbilyet_receiveperson"
        cJurnaldetil_bilyetperson.Width = 150
        cJurnaldetil_bilyetperson.Visible = False
        cJurnaldetil_bilyetperson.ReadOnly = False

        cJurnaldetil_bilyetpic.Name = "jurnalbilyet_pic"
        cJurnaldetil_bilyetpic.HeaderText = "Penanggung Jawab"
        cJurnaldetil_bilyetpic.DataPropertyName = "jurnalbilyet_pic"
        cJurnaldetil_bilyetpic.Width = 100
        cJurnaldetil_bilyetpic.Visible = False
        cJurnaldetil_bilyetpic.ReadOnly = False

        cCAacc_id.Name = "region_id"
        cCAacc_id.HeaderText = "Acc CA ID"
        cCAacc_id.DataPropertyName = "region_id"
        cCAacc_id.Width = 80
        cCAacc_id.Visible = True
        cCAacc_id.ReadOnly = False
        cCAacc_id.DataSource = Me.tbl_MstAcc_ca
        cCAacc_id.DisplayMember = "acc_ca_id"
        cCAacc_id.ValueMember = "acc_ca_id"
        cCAacc_id.DisplayStyleForCurrentCellOnly = True

        cCAacc_nm.Name = "acc_ca_name"
        cCAacc_nm.HeaderText = "Acc CA Name"
        cCAacc_nm.DataPropertyName = "region_id"
        cCAacc_nm.Width = 200
        cCAacc_nm.Visible = True
        cCAacc_nm.ReadOnly = False
        cCAacc_nm.DataSource = Me.tbl_MstAcc_ca
        cCAacc_nm.DisplayMember = "acc_ca_shortname"
        cCAacc_nm.ValueMember = "acc_ca_id"
        cCAacc_nm.DisplayStyleForCurrentCellOnly = True

        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
        {cJurnaldetil_line, cAcc_id, cAcc_no, cJurnaldetil_descr, cRef_id, _
         cCurrency_id, cJurnaldetil_foreign, cJurnaldetil_foreignrate, cJurnaldetil_idr, _
         cRekanan_id, cRekanan_name, cRekanan_button, cJurnal_id, cJurnaldetil_dk, _
         cChannel_id, _
           cRef_line, cRef_budgetline, cRegion_id, cBranch_id, _
         cBudget_id, cBudget_name, cBudget_button, _
         cBudgetdetil_id, cBudgetdetil_name, cBudgetdetil_button, cStrukturunit_id, _
         cPaymenttype_id, cBank_id, cJurnaldetil_bilyetno, cJurnaldetil_bilyetdate, _
         cJurnaldetil_bilyetdateefective, cJurnaldetil_bilyetperson, cJurnaldetil_bilyetpic, cCAacc_id, cCAacc_nm})

        objDgv.AutoGenerateColumns = False
        objDgv.AllowUserToAddRows = True
        objDgv.AllowUserToDeleteRows = True
        objDgv.Columns("acc_id").Frozen = True
    End Function

    Private Function FormatDgvTrnJurnalresponse(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean

        Dim cJurnal_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnal_line As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBook_date As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnal_descr As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekanan_name As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cCurrency_name As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnal_foreign As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnal_foreignrate As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnal_idr As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cChannel_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn

        cJurnal_id.Name = "ref"
        cJurnal_id.HeaderText = "Ref"
        cJurnal_id.DataPropertyName = "ref"
        cJurnal_id.Width = 100
        cJurnal_id.Visible = True
        cJurnal_id.ReadOnly = True

        cJurnal_line.Name = "line"
        cJurnal_line.HeaderText = "Line"
        cJurnal_line.DataPropertyName = "line"
        cJurnal_line.Width = 50
        cJurnal_line.Visible = True
        cJurnal_line.ReadOnly = True


        cBook_date.Name = "book_date"
        cBook_date.HeaderText = "Book Date"
        cBook_date.DataPropertyName = "book_date"
        cBook_date.Width = 100
        cBook_date.Visible = True
        cBook_date.ReadOnly = True

        cJurnal_descr.Name = "descr"
        cJurnal_descr.HeaderText = "Descr"
        cJurnal_descr.DataPropertyName = "descr"
        cJurnal_descr.Width = 100
        cJurnal_descr.MaxInputLength = 255
        cJurnal_descr.Visible = True
        cJurnal_descr.ReadOnly = True

        cRekanan_name.Name = "rekanan_name"
        cRekanan_name.HeaderText = "Partner"
        cRekanan_name.DataPropertyName = "rekanan_name"
        cRekanan_name.Width = 200
        cRekanan_name.Visible = True
        cRekanan_name.ReadOnly = True

        cCurrency_name.Name = "currency_name"
        cCurrency_name.HeaderText = "Curr."
        cCurrency_name.DataPropertyName = "currency_name"
        cCurrency_name.Width = 75
        cCurrency_name.MaxInputLength = 255
        cCurrency_name.Visible = True
        cCurrency_name.ReadOnly = True

        cJurnal_foreign.Name = "amount_foreign"
        cJurnal_foreign.HeaderText = "Foreign"
        cJurnal_foreign.DataPropertyName = "amount_foreign"
        cJurnal_foreign.Width = 100
        cJurnal_foreign.Visible = True
        cJurnal_foreign.ReadOnly = True
        cJurnal_foreign.DefaultCellStyle.Format = "#,##0.00"
        cJurnal_foreign.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        cJurnal_foreignrate.Name = "rate"
        cJurnal_foreignrate.HeaderText = "Rate"
        cJurnal_foreignrate.DataPropertyName = "rate"
        cJurnal_foreignrate.Width = 75
        cJurnal_foreignrate.Visible = True
        cJurnal_foreignrate.ReadOnly = True
        cJurnal_foreignrate.DefaultCellStyle.Format = "#,##0.00"
        cJurnal_foreignrate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        cJurnal_idr.Name = "amount_idr"
        cJurnal_idr.HeaderText = "Amount"
        cJurnal_idr.DataPropertyName = "amount_idr"
        cJurnal_idr.Width = 100
        cJurnal_idr.Visible = True
        cJurnal_idr.ReadOnly = True
        cJurnal_idr.DefaultCellStyle.Format = "#,##0"
        cJurnal_idr.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        cChannel_id.Name = "channel_id"
        cChannel_id.HeaderText = "Company"
        cChannel_id.DataPropertyName = "channel_id"
        cChannel_id.Width = 100
        cChannel_id.Visible = True
        cChannel_id.ReadOnly = True


        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
        {cJurnal_id, cJurnal_line, cBook_date, cJurnal_descr, cCurrency_name, _
        cJurnal_foreign, cJurnal_foreignrate, cJurnal_idr, cRekanan_name, cChannel_id})

        ' DgvTrnJurnal Behaviours: 
        objDgv.AutoGenerateColumns = False
        objDgv.AllowUserToAddRows = False
        objDgv.AllowUserToDeleteRows = False
        objDgv.AllowUserToResizeRows = False
        objDgv.ReadOnly = False
        objDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        objDgv.Columns("line").Frozen = True
    End Function

    Private Function InitLayoutUI() As Boolean

        Me.ftabMain.Anchor = AnchorStyles.Bottom
        Me.ftabMain.Anchor += AnchorStyles.Top
        Me.ftabMain.Anchor += AnchorStyles.Right
        Me.ftabMain.Anchor += AnchorStyles.Left

        Me.fTabDataDetil.Anchor = AnchorStyles.Bottom
        Me.fTabDataDetil.Anchor += AnchorStyles.Top
        Me.fTabDataDetil.Anchor += AnchorStyles.Right
        Me.fTabDataDetil.Anchor += AnchorStyles.Left

        Me.PnlDfSearch.Dock = DockStyle.Top
        Me.PnlDfSearch.Visible = False
        Me.PnlDfMain.Dock = DockStyle.Fill
        Me.DgvTrnJurnal.Dock = DockStyle.Fill
        Me.DgvTrnJurnaldetil_Debit.Dock = DockStyle.Fill
        Me.DgvTrnJurnaldetil_Credit.Dock = DockStyle.Fill
        Me.DgvTrnJurnalResponse.Dock = DockStyle.Fill

        Me.FormatDgvTrnJurnal(Me.DgvTrnJurnal)
        Me.FormatDgvTrnJurnalresponse(Me.DgvTrnJurnalResponse)
    End Function

    Private Function BindingStop() As Boolean
        'stop binding
        Me.obj_Jurnal_id.DataBindings.Clear()
        Me.obj_Jurnal_bookdate.DataBindings.Clear()
        Me.obj_Jurnal_duedate.DataBindings.Clear()
        Me.obj_Jurnal_billdate.DataBindings.Clear()
        Me.obj_Jurnal_descr.DataBindings.Clear()
        Me.obj_Jurnal_invoice_id.DataBindings.Clear()
        Me.obj_Jurnal_invoice_descr.DataBindings.Clear()
        Me.obj_Jurnal_source.DataBindings.Clear()
        Me.obj_Jurnaltype_id.DataBindings.Clear()
        Me.obj_Rekanan_id.DataBindings.Clear()
        Me.obj_Periode_id.DataBindings.Clear()
        Me.obj_Channel_id.DataBindings.Clear()

        Me.obj_Budget_id.DataBindings.Clear()
        Me.obj_Budget_name.DataBindings.Clear()

        Me.obj_Currency_id.DataBindings.Clear()
        Me.obj_Currency_rate.DataBindings.Clear()
        Me.obj_Strukturunit_id.DataBindings.Clear()
        Me.obj_Acc_ca_id.DataBindings.Clear()
        Me.obj_Region_id.DataBindings.Clear()
        Me.obj_Branch_id.DataBindings.Clear()
        Me.obj_Jurnal_iscreated.DataBindings.Clear()
        Me.obj_Jurnal_iscreatedby.DataBindings.Clear()
        Me.obj_Jurnal_iscreatedate.DataBindings.Clear()
        Me.obj_Jurnal_isposted.DataBindings.Clear()
        Me.obj_Jurnal_ispostedby.DataBindings.Clear()
        Me.obj_Jurnal_isposteddate.DataBindings.Clear()
        Me.obj_Jurnal_isdisabled.DataBindings.Clear()
        Me.obj_Jurnal_isdisabledby.DataBindings.Clear()
        Me.obj_Jurnal_isdisableddt.DataBindings.Clear()
        Me.obj_Created_by.DataBindings.Clear()
        Me.obj_Created_dt.DataBindings.Clear()
        Me.obj_Modified_by.DataBindings.Clear()
        Me.obj_Modified_dt.DataBindings.Clear()


        ' For Search Box
        Me.txtSearchJurnalID.DataBindings.Clear()
        Me.cbo_periodeSearch.DataBindings.Clear()
        Me.txtSearchSource.DataBindings.Clear()
        Me.cbo_createBySearch.DataBindings.Clear()
        Me.txtSearchAdv.DataBindings.Clear()
        Me.txtSearchRekananID.DataBindings.Clear()
        Return True
    End Function

    Private Function BindingStart() As Boolean
        'start binding
        Me.obj_Jurnal_id.DataBindings.Add(New Binding("Text", Me.tbl_TrnJurnal_Temp, "jurnal_id"))
        Me.obj_Jurnal_bookdate.DataBindings.Add(New Binding("Text", Me.tbl_TrnJurnal_Temp, "jurnal_bookdate"))
        Me.obj_Jurnal_duedate.DataBindings.Add(New Binding("Text", Me.tbl_TrnJurnal_Temp, "jurnal_duedate"))
        Me.obj_Jurnal_billdate.DataBindings.Add(New Binding("Text", Me.tbl_TrnJurnal_Temp, "jurnal_billdate"))
        Me.obj_Jurnal_descr.DataBindings.Add(New Binding("Text", Me.tbl_TrnJurnal_Temp, "jurnal_descr"))
        Me.obj_Jurnal_invoice_id.DataBindings.Add(New Binding("Text", Me.tbl_TrnJurnal_Temp, "jurnal_invoice_id"))
        Me.obj_Jurnal_invoice_descr.DataBindings.Add(New Binding("Text", Me.tbl_TrnJurnal_Temp, "jurnal_invoice_descr"))
        Me.obj_Jurnal_source.DataBindings.Add(New Binding("Text", Me.tbl_TrnJurnal_Temp, "jurnal_source"))
        Me.obj_Jurnaltype_id.DataBindings.Add(New Binding("Text", Me.tbl_TrnJurnal_Temp, "jurnaltype_id"))
        Me.obj_Rekanan_id.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnJurnal_Temp, "rekanan_id", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))
        Me.obj_Periode_id.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnJurnal_Temp, "periode_id"))
        Me.obj_Channel_id.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnJurnal_Temp, "channel_id"))
        Me.obj_Budget_id.DataBindings.Add(New Binding("Text", Me.tbl_TrnJurnal_Temp, "budget_id"))
        Me.obj_Budget_name.DataBindings.Add(New Binding("Text", Me.tbl_TrnJurnal_Temp, "budget_name"))
        Me.obj_Currency_id.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnJurnal_Temp, "currency_id", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))
        Me.obj_Currency_rate.DataBindings.Add(New Binding("Text", Me.tbl_TrnJurnal_Temp, "currency_rate", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))
        Me.obj_Strukturunit_id.DataBindings.Add(New Binding("Text", Me.tbl_TrnJurnal_Temp, "strukturunit_id", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))
        Me.obj_Acc_ca_id.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnJurnal_Temp, "acc_ca_id", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))
        Me.obj_Region_id.DataBindings.Add(New Binding("Text", Me.tbl_TrnJurnal_Temp, "region_id", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))
        Me.obj_Branch_id.DataBindings.Add(New Binding("Text", Me.tbl_TrnJurnal_Temp, "branch_id", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))
        Me.obj_Jurnal_iscreated.DataBindings.Add(New Binding("Checked", Me.tbl_TrnJurnal_Temp, "jurnal_iscreated"))
        Me.obj_Jurnal_iscreatedby.DataBindings.Add(New Binding("Text", Me.tbl_TrnJurnal_Temp, "jurnal_iscreatedby"))
        Me.obj_Jurnal_iscreatedate.DataBindings.Add(New Binding("Text", Me.tbl_TrnJurnal_Temp, "jurnal_iscreatedate"))
        Me.obj_Jurnal_isposted.DataBindings.Add(New Binding("Checked", Me.tbl_TrnJurnal_Temp, "jurnal_isposted"))
        Me.obj_Jurnal_ispostedby.DataBindings.Add(New Binding("Text", Me.tbl_TrnJurnal_Temp, "jurnal_ispostedby"))
        Me.obj_Jurnal_isposteddate.DataBindings.Add(New Binding("Text", Me.tbl_TrnJurnal_Temp, "jurnal_isposteddate"))
        Me.obj_Jurnal_isdisabled.DataBindings.Add(New Binding("Checked", Me.tbl_TrnJurnal_Temp, "jurnal_isdisabled"))
        Me.obj_Jurnal_isdisabledby.DataBindings.Add(New Binding("Text", Me.tbl_TrnJurnal_Temp, "jurnal_isdisabledby"))
        Me.obj_Jurnal_isdisableddt.DataBindings.Add(New Binding("Text", Me.tbl_TrnJurnal_Temp, "jurnal_isdisableddt"))
        Me.obj_Created_by.DataBindings.Add(New Binding("Text", Me.tbl_TrnJurnal_Temp, "created_by"))
        Me.obj_Created_dt.DataBindings.Add(New Binding("Text", Me.tbl_TrnJurnal_Temp, "created_dt"))
        Me.obj_Modified_by.DataBindings.Add(New Binding("Text", Me.tbl_TrnJurnal_Temp, "modified_by"))
        Me.obj_Modified_dt.DataBindings.Add(New Binding("Text", Me.tbl_TrnJurnal_Temp, "modified_dt"))

        ' For Search box
        Me.txtSearchJurnalID.DataBindings.Add((New Binding("Enabled", Me.chkSearchJurnalID, "Checked")))
        Me.cbo_periodeSearch.DataBindings.Add((New Binding("Enabled", Me.chkSearchPeriode, "Checked")))
        Me.txtSearchSource.DataBindings.Add((New Binding("Enabled", Me.chkSearchSource, "Checked")))
        Me.cbo_createBySearch.DataBindings.Add((New Binding("Enabled", Me.chkSearchCreateBy, "Checked")))
        Me.txtSearchAdv.DataBindings.Add((New Binding("Enabled", Me.chkSearchAdv, "Checked")))
        Me.txtSearchRekananID.DataBindings.Add((New Binding("Enabled", Me.chkSearchRekanan, "Checked")))

        Return True
    End Function

#End Region

#Region " User Defined Function "

    Private Function uiTrnJurnal_JV_Manual_NewData() As Boolean
        'new data
        RaiseEvent FormBeforeNew()

        '=======Add PTS 20131227=======Tambahan untuk dapat default periode by date now=========
        Dim periodedefault As String
        periodedefault = Me.channel_number & String.Format("{0:yyMM}", Now)
        '======================================================================================

        ' TODO: Set Default Value for tbl_TrnJurnal_Temp
        Me.tbl_TrnJurnal_Temp.Clear()
        Me.tbl_TrnJurnal_Temp.Columns("jurnaltype_id").DefaultValue = ConstMyJurnalType
        Me.tbl_TrnJurnal_Temp.Columns("jurnal_source").DefaultValue = Me._SOURCE
        Me.tbl_TrnJurnal_Temp.Columns("currency_rate").DefaultValue = 1
        Me.tbl_TrnJurnal_Temp.Columns("periode_id").DefaultValue = periodedefault 'String.Format("{0:yyMM}", Now)
        Me.tbl_TrnJurnal_Temp.Columns("channel_id").DefaultValue = Me._CHANNEL
        Me.tbl_TrnJurnal_Temp.Columns("currency_id").DefaultValue = 1

        ' TODO: Set Default Value for tbl_TrnJurnaldetil_Debit
        Me.tbl_TrnJurnaldetil_Debit.Clear()
        Me.tbl_TrnJurnaldetil_Debit = clsDataset.CreateTblTrnJurnaldetilBilyet()
        Me.tbl_TrnJurnaldetil_Debit.Columns("jurnal_id").DefaultValue = 0
        Me.tbl_TrnJurnaldetil_Debit.Columns("jurnaldetil_line").DefaultValue = DBNull.Value
        Me.tbl_TrnJurnaldetil_Debit.Columns("jurnaldetil_line").AutoIncrement = True
        Me.tbl_TrnJurnaldetil_Debit.Columns("jurnaldetil_line").AutoIncrementSeed = 10
        Me.tbl_TrnJurnaldetil_Debit.Columns("jurnaldetil_line").AutoIncrementStep = 10
        Me.tbl_TrnJurnaldetil_Debit.Columns("currency_id").DefaultValue = 1
        Me.tbl_TrnJurnaldetil_Debit.Columns("jurnaldetil_foreignrate").DefaultValue = 1
        Me.tbl_TrnJurnaldetil_Debit.Columns("channel_id").DefaultValue = Me._CHANNEL
        Me.tbl_TrnJurnaldetil_Debit.Columns("jurnaldetil_dk").DefaultValue = "D"
        Me.DgvTrnJurnaldetil_Debit.DataSource = Me.tbl_TrnJurnaldetil_Debit

        ' TODO: Set Default Value for tbl_TrnJurnaldetil_Credit
        Me.tbl_TrnJurnaldetil_Credit.Clear()
        Me.tbl_TrnJurnaldetil_Credit = clsDataset.CreateTblTrnJurnaldetilBilyet()
        Me.tbl_TrnJurnaldetil_Credit.Columns("jurnal_id").DefaultValue = 0
        Me.tbl_TrnJurnaldetil_Credit.Columns("jurnaldetil_line").DefaultValue = DBNull.Value
        Me.tbl_TrnJurnaldetil_Credit.Columns("jurnaldetil_line").AutoIncrement = True
        Me.tbl_TrnJurnaldetil_Credit.Columns("jurnaldetil_line").AutoIncrementSeed = 15
        Me.tbl_TrnJurnaldetil_Credit.Columns("jurnaldetil_line").AutoIncrementStep = 10
        Me.tbl_TrnJurnaldetil_Credit.Columns("currency_id").DefaultValue = 1
        Me.tbl_TrnJurnaldetil_Credit.Columns("jurnaldetil_foreignrate").DefaultValue = 1
        Me.tbl_TrnJurnaldetil_Credit.Columns("channel_id").DefaultValue = Me._CHANNEL
        Me.tbl_TrnJurnaldetil_Credit.Columns("jurnaldetil_dk").DefaultValue = "K"
        Me.DgvTrnJurnaldetil_Credit.DataSource = Me.tbl_TrnJurnaldetil_Credit

        'TODO: Set Default Value for tbl_JurnalResponse
        Me.tbl_TrnJurnalResponse.Clear()
        Me.tbl_TrnJurnalResponse = clsDataset.CreateTblTrnJurnalreference()
        Me.DgvTrnJurnalResponse.DataSource = Me.tbl_TrnJurnalResponse

        Me.BindingContext(Me.tbl_TrnJurnal_Temp).EndCurrentEdit()
        Try
            Me.BindingContext(Me.tbl_TrnJurnal_Temp).AddNew()
        Catch ex As Exception
            MessageBox.Show(ex.Source)
        End Try

        'patch visibility di bagian jdw_pembayaran
        'fungsi format untuk kolom ini di atas gak jalan, jadi di-patch dari sini
        Me.DgvTrnJurnaldetil_Credit.Columns("jurnal_id").Visible = False
        Me.DgvTrnJurnaldetil_Debit.Columns("jurnal_id").Visible = False

        DATADETIL_OPENED = False
    End Function

    Private Function uiTrnJurnal_JV_Manual_Retrieve() As Boolean
        'retrieve data 
        ' TODO: Parse Criteria using clsProc.RefParser()
        'retrieve data
        Dim criteria As String = ""
        Dim txtSearchCriteria As String = ""
        Dim txtSQLSearch As String = ""
        Dim Limit As Integer

        ' TODO: Parse Criteria using clsProc.RefParser()
        txtSQLSearch = String.Format(" A.jurnaltype_id='{0}' AND A.jurnal_isdisabled = 0 ", ConstMyJurnalType)

        'If Me.FILTER_QUERY_MODE Then
        '-- JurnalID
        If Me.chkSearchJurnalID.Checked Then
            txtSearchCriteria = clsUtil.RefParser("jurnal_id", Me.txtSearchJurnalID)
            If txtSQLSearch = "" Then
                txtSQLSearch = " (" & txtSearchCriteria & ") "
            Else
                txtSQLSearch = txtSQLSearch & " AND " & " (" & txtSearchCriteria & ") "
            End If
        End If
        '-- END JurnalID

        '-- Rekanan ID
        If Me.chkSearchRekanan.Checked Then
            txtSearchCriteria = clsUtil.RefParser(" rekanan_id", Me.txtSearchRekananID)
            If txtSQLSearch = "" Then
                txtSQLSearch = " (" & txtSearchCriteria & ") "
            Else
                txtSQLSearch = txtSQLSearch & " AND " & " (" & txtSearchCriteria & ") "
            End If
        End If
        '-- END Rekanan ID

        '-- Periode
        If Me.chkSearchPeriode.Checked Then
            txtSearchCriteria = String.Format(" periode_id = '{0}' ", Me.cbo_periodeSearch.SelectedValue)
            If txtSQLSearch = "" Then
                txtSQLSearch = " (" & txtSearchCriteria & ") "
            Else
                txtSQLSearch = txtSQLSearch & " AND " & " (" & txtSearchCriteria & ") "
            End If
        End If
        'END Periode

        '-- Source
        If Me.chkSearchSource.Checked Then
            txtSearchCriteria = String.Format(" jurnal_source = '{0}' ", Me.txtSearchSource.Text)
            If txtSQLSearch = "" Then
                txtSQLSearch = " (" & txtSearchCriteria & ") "
            Else
                txtSQLSearch = txtSQLSearch & " AND " & " (" & txtSearchCriteria & ") "
            End If
        End If
        'END Source

        '-- Create By
        If Me.chkSearchCreateBy.Checked Then
            txtSearchCriteria = String.Format(" created_by = '{0}' ", Me.cbo_createBySearch.SelectedValue)
            If txtSQLSearch = "" Then
                txtSQLSearch = " (" & txtSearchCriteria & ") "
            Else
                txtSQLSearch = txtSQLSearch & " AND " & " (" & txtSearchCriteria & ") "
            End If
        End If
        'END Create By

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

        'End If

        If Me.chkLimit.Checked Then
            Try
                Limit = CInt(Me.txtLimit.Text)
            Catch ex As Exception
                MessageBox.Show("Batasan hanya bisa diisi bilangan bulat. Misalnya 1 s/d 1000" & vbCrLf & ex.Message, mUiName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            Limit = 0
        End If

        criteria = txtSQLSearch

        Me.tbl_TrnJurnal.Clear()
        Try
            Me.DataFillLimit(Me.tbl_TrnJurnal, "act_TrnJurnalWithAmount_Select", criteria, Limit, Me.cboSearchChannel.SelectedValue)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Function

    Private Function uiTrnJurnal_JV_Manual_Save() As Boolean
        'save data
        Dim tbl_TrnJurnal_Temp_Changes As DataTable
        Dim tbl_TrnJurnaldetil_Debit_Changes As DataTable
        Dim tbl_TrnJurnaldetil_Credit_Changes As DataTable


        Dim success As Boolean
        Dim jurnal_id As Object = New Object
        Dim i As Integer = 0
        Dim MasterDataState As System.Data.DataRowState
        Dim result As FormSaveResult

        Me.Cursor = Cursors.WaitCursor
        RaiseEvent FormBeforeSave(jurnal_id)

        Me.BindingContext(Me.tbl_TrnJurnal_Temp).EndCurrentEdit()

        Me.DgvTrnJurnaldetil_Debit.EndEdit()
        Me.BindingContext(Me.tbl_TrnJurnaldetil_Debit).EndCurrentEdit()

        tbl_TrnJurnaldetil_Debit_Changes = Me.tbl_TrnJurnaldetil_Debit.GetChanges()
        If tbl_TrnJurnaldetil_Debit_Changes IsNot Nothing Then
            If Me.tbl_TrnJurnal_Temp.Rows(0).RowState <> DataRowState.Added Then
                Me.obj_Modified_by.Text = Me.UserName
                Me.obj_Modified_dt.Text = Now()
            End If
        End If

        Me.DgvTrnJurnaldetil_Credit.EndEdit()
        Me.BindingContext(Me.tbl_TrnJurnaldetil_Credit).EndCurrentEdit()
        tbl_TrnJurnaldetil_Credit_Changes = Me.tbl_TrnJurnaldetil_Credit.GetChanges()
        If tbl_TrnJurnaldetil_Credit_Changes IsNot Nothing Then
            If Me.tbl_TrnJurnal_Temp.Rows(0).RowState <> DataRowState.Added Then
                Me.obj_Modified_by.Text = Me.UserName
                Me.obj_Modified_dt.Text = Now()
            End If
        End If


        Me.BindingContext(Me.tbl_TrnJurnal_Temp).EndCurrentEdit()
        tbl_TrnJurnal_Temp_Changes = Me.tbl_TrnJurnal_Temp.GetChanges()


        If tbl_TrnJurnal_Temp_Changes IsNot Nothing Or tbl_TrnJurnaldetil_Debit_Changes IsNot Nothing Or tbl_TrnJurnaldetil_Credit_Changes IsNot Nothing Then

            Try

                MasterDataState = tbl_TrnJurnal_Temp.Rows(0).RowState
                jurnal_id = tbl_TrnJurnal_Temp.Rows(0).Item("jurnal_id")

                If tbl_TrnJurnal_Temp_Changes IsNot Nothing Then
                    success = Me.uiTrnJurnal_JV_Manual_SaveMaster(jurnal_id, tbl_TrnJurnal_Temp_Changes, MasterDataState)
                    If Not success Then Throw New Exception("Error: Saving Master Data at Me.uiTrnJurnal_JV_Manual_SaveMaster(tbl_TrnJurnal_Temp_Changes)")
                    Me.tbl_TrnJurnal_Temp.AcceptChanges()
                End If

                If tbl_TrnJurnaldetil_Debit_Changes IsNot Nothing Then
                    For i = 0 To Me.tbl_TrnJurnaldetil_Debit.Rows.Count - 1
                        If Me.tbl_TrnJurnaldetil_Debit.Rows(i).RowState = DataRowState.Added Then
                            Me.tbl_TrnJurnaldetil_Debit.Rows(i).Item("jurnal_id") = jurnal_id
                        End If
                    Next
                    success = Me.uiTrnJurnal_JV_Manual_SaveDetilDebit(jurnal_id, tbl_TrnJurnaldetil_Debit_Changes, MasterDataState)
                    If Not success Then Throw New Exception("Error: Save Detil Data at Me.uiTrnJurnal_JV_Manual_SaveDetil(tbl_TrnJurnaldetil_Debit_Changes)")
                    Me.tbl_TrnJurnaldetil_Debit.AcceptChanges()
                End If

                If tbl_TrnJurnaldetil_Credit_Changes IsNot Nothing Then
                    For i = 0 To Me.tbl_TrnJurnaldetil_Credit.Rows.Count - 1
                        If Me.tbl_TrnJurnaldetil_Credit.Rows(i).RowState = DataRowState.Added Then
                            Me.tbl_TrnJurnaldetil_Credit.Rows(i).Item("jurnal_id") = jurnal_id
                        End If
                    Next
                    Me.uiTrnJurnal_JV_Manual_TblDetilInverse(tbl_TrnJurnaldetil_Credit_Changes)
                    success = Me.uiTrnJurnal_JV_Manual_SaveDetilCredit(jurnal_id, tbl_TrnJurnaldetil_Credit_Changes, MasterDataState)
                    If Not success Then Throw New Exception("Error: Save Detil Data at Me.uiTrnJurnal_JV_Manual_SaveDetil(tbl_TrnJurnaldetil_Credit_Changes)")
                    Me.tbl_TrnJurnaldetil_Credit.AcceptChanges()
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

        RaiseEvent FormAfterSave(jurnal_id, result)
        Me.Cursor = Cursors.Arrow

    End Function

    Private Function uiTrnJurnal_JV_Manual_SaveMaster(ByRef jurnal_id As Object, ByVal objTbl As DataTable, ByVal MasterDataState As System.Data.DataRowState) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbCmdInsert As OleDb.OleDbCommand
        Dim dbCmdUpdate As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter
        Dim cookie As Byte() = Nothing

        ' Save data: transaksi_jurnal
        dbCmdInsert = New OleDb.OleDbCommand("act_TrnJurnal_Insert", dbConn)
        dbCmdInsert.CommandType = CommandType.StoredProcedure
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_id", System.Data.OleDb.OleDbType.VarWChar, 24, "jurnal_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_bookdate", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "jurnal_bookdate"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_duedate", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "jurnal_duedate"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_billdate", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "jurnal_billdate"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_descr", System.Data.OleDb.OleDbType.VarWChar, 4000, "jurnal_descr"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_invoice_id", System.Data.OleDb.OleDbType.VarWChar, 40, "jurnal_invoice_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_invoice_descr", System.Data.OleDb.OleDbType.VarWChar, 4000, "jurnal_invoice_descr"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_source", System.Data.OleDb.OleDbType.VarWChar, 60, "jurnal_source"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnaltype_id", System.Data.OleDb.OleDbType.VarWChar, 4, "jurnaltype_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@rekanan_id", System.Data.OleDb.OleDbType.Decimal, 8, System.Data.ParameterDirection.Input, False, CType(8, Byte), CType(0, Byte), "rekanan_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@periode_id", System.Data.OleDb.OleDbType.VarWChar, 8, "periode_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20, "channel_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@budget_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(8, Byte), CType(0, Byte), "budget_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@currency_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(3, Byte), CType(0, Byte), "currency_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@currency_rate", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "currency_rate", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@strukturunit_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(6, Byte), CType(0, Byte), "strukturunit_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@acc_ca_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(7, Byte), CType(0, Byte), "acc_ca_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@region_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(7, Byte), CType(0, Byte), "region_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@branch_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(7, Byte), CType(0, Byte), "branch_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advertiser_id", System.Data.OleDb.OleDbType.Decimal, 5))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@brand_id", System.Data.OleDb.OleDbType.Decimal, 5))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@ae_id", System.Data.OleDb.OleDbType.Decimal, 5))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_iscreated", System.Data.OleDb.OleDbType.Boolean, 1))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_iscreatedby", System.Data.OleDb.OleDbType.VarWChar, 100))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_iscreatedate", System.Data.OleDb.OleDbType.DBTimeStamp, 8))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_isposted", System.Data.OleDb.OleDbType.Boolean, 1, "jurnal_isposted"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_ispostedby", System.Data.OleDb.OleDbType.VarWChar, 100))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_isposteddate", System.Data.OleDb.OleDbType.DBTimeStamp, 8))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_isdisabled", System.Data.OleDb.OleDbType.Boolean, 1, "jurnal_isdisabled"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_isdisabledby", System.Data.OleDb.OleDbType.VarWChar, 32))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_isdisableddt", System.Data.OleDb.OleDbType.DBTimeStamp, 4))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@created_by", System.Data.OleDb.OleDbType.VarWChar, 100))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@created_dt", System.Data.OleDb.OleDbType.DBTimeStamp, 4))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@modified_by", System.Data.OleDb.OleDbType.VarWChar, 100))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@modified_dt", System.Data.OleDb.OleDbType.DBTimeStamp, 4))
        dbCmdInsert.Parameters("@created_by").Value = Me.UserName
        dbCmdInsert.Parameters("@created_dt").Value = Now()
        dbCmdInsert.Parameters("@modified_by").Value = String.Empty
        dbCmdInsert.Parameters("@modified_dt").Value = DBNull.Value
        dbCmdInsert.Parameters("@jurnal_iscreated").Value = 1
        dbCmdInsert.Parameters("@jurnal_iscreatedby").Value = Me.UserName
        dbCmdInsert.Parameters("@jurnal_iscreatedate").Value = Now()
        dbCmdInsert.Parameters("@jurnal_ispostedby").Value = String.Empty
        dbCmdInsert.Parameters("@jurnal_isposteddate").Value = DBNull.Value
        dbCmdInsert.Parameters("@jurnal_isdisabledby").Value = String.Empty
        dbCmdInsert.Parameters("@jurnal_isdisableddt").Value = DBNull.Value
        dbCmdInsert.Parameters("@advertiser_id").Value = 0
        dbCmdInsert.Parameters("@brand_id").Value = 0
        dbCmdInsert.Parameters("@ae_id").Value = 0

        dbCmdUpdate = New OleDb.OleDbCommand("act_TrnJurnal_Update", dbConn)
        dbCmdUpdate.CommandType = CommandType.StoredProcedure
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_id", System.Data.OleDb.OleDbType.VarWChar, 24, "jurnal_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_bookdate", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "jurnal_bookdate"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_duedate", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "jurnal_duedate"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_billdate", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "jurnal_billdate"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_descr", System.Data.OleDb.OleDbType.VarWChar, 4000, "jurnal_descr"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_invoice_id", System.Data.OleDb.OleDbType.VarWChar, 40, "jurnal_invoice_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_invoice_descr", System.Data.OleDb.OleDbType.VarWChar, 4000, "jurnal_invoice_descr"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_source", System.Data.OleDb.OleDbType.VarWChar, 60, "jurnal_source"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnaltype_id", System.Data.OleDb.OleDbType.VarWChar, 4, "jurnaltype_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@rekanan_id", System.Data.OleDb.OleDbType.Decimal, 8, System.Data.ParameterDirection.Input, False, CType(8, Byte), CType(0, Byte), "rekanan_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@periode_id", System.Data.OleDb.OleDbType.VarWChar, 8, "periode_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20, "channel_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@budget_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(8, Byte), CType(0, Byte), "budget_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@currency_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(3, Byte), CType(0, Byte), "currency_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@currency_rate", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "currency_rate", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@strukturunit_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(6, Byte), CType(0, Byte), "strukturunit_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@acc_ca_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(7, Byte), CType(0, Byte), "acc_ca_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@region_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(7, Byte), CType(0, Byte), "region_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@branch_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(7, Byte), CType(0, Byte), "branch_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advertiser_id", System.Data.OleDb.OleDbType.Decimal, 5))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@brand_id", System.Data.OleDb.OleDbType.Decimal, 5))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@ae_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(7, Byte), CType(0, Byte), "branch_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_iscreated", System.Data.OleDb.OleDbType.Boolean, 1, "jurnal_iscreated"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_iscreatedby", System.Data.OleDb.OleDbType.VarWChar, 100, "jurnal_iscreatedby"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_iscreatedate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "jurnal_iscreatedate"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_isposted", System.Data.OleDb.OleDbType.Boolean, 1, "jurnal_isposted"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_ispostedby", System.Data.OleDb.OleDbType.VarWChar, 100))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_isposteddate", System.Data.OleDb.OleDbType.DBTimeStamp, 8))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_isdisabled", System.Data.OleDb.OleDbType.Boolean, 1, "jurnal_isdisabled"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_isdisabledby", System.Data.OleDb.OleDbType.VarWChar, 32))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_isdisableddt", System.Data.OleDb.OleDbType.DBTimeStamp, 4))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@created_by", System.Data.OleDb.OleDbType.VarWChar, 100, "created_by"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@created_dt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "created_dt"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@modified_by", System.Data.OleDb.OleDbType.VarWChar, 100))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@modified_dt", System.Data.OleDb.OleDbType.DBTimeStamp, 4))
        dbCmdUpdate.Parameters("@modified_by").Value = Me.UserName
        dbCmdUpdate.Parameters("@modified_dt").Value = Now()
        dbCmdUpdate.Parameters("@jurnal_ispostedby").Value = String.Empty
        dbCmdUpdate.Parameters("@jurnal_isposteddate").Value = DBNull.Value
        dbCmdUpdate.Parameters("@jurnal_isdisabledby").Value = String.Empty
        dbCmdUpdate.Parameters("@jurnal_isdisableddt").Value = DBNull.Value
        dbCmdUpdate.Parameters("@advertiser_id").Value = 0
        dbCmdUpdate.Parameters("@brand_id").Value = 0
        dbCmdUpdate.Parameters("@ae_id").Value = 0

        dbDA = New OleDb.OleDbDataAdapter
        dbDA.UpdateCommand = dbCmdUpdate
        dbDA.InsertCommand = dbCmdInsert


        Try
            dbConn.Open()
            clsApplicationRole.SetAppRole(dbConn, cookie)
            dbDA.Update(objTbl)

            jurnal_id = objTbl.Rows(0).Item("jurnal_id")
            Me.tbl_TrnJurnal_Temp.Clear()
            Me.tbl_TrnJurnal_Temp.Merge(objTbl)

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
            Me.tbl_TrnJurnal.Merge(objTbl)
            Me.uiTrnJurnal_JV_Manual_Retrieve()
            Me.BindingContext(Me.tbl_TrnJurnal).Position = 0
            ' ''ElseIf MasterDataState = DataRowState.Modified Then
            ' ''    curpos = Me.BindingContext(Me.tbl_TrnJurnal).Position
            ' ''    Me.tbl_TrnJurnal.Rows.RemoveAt(curpos)
            ' ''    Me.tbl_TrnJurnal.Merge(objTbl)
        End If

        ' ''Me.BindingContext(Me.tbl_TrnJurnal).Position = Me.BindingContext(Me.tbl_TrnJurnal).Count

        Return True
    End Function

    Private Function uiTrnJurnal_JV_Manual_SaveDetilDebit(ByRef jurnal_id As Object, ByVal objTbl As DataTable, ByVal MasterDataState As System.Data.DataRowState) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbCmdInsert As OleDb.OleDbCommand
        Dim dbCmdUpdate As OleDb.OleDbCommand
        Dim dbCmdDelete As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter
        Dim cookie As Byte() = Nothing

        ' Save data: Transaksi_jurnaldetil
        dbCmdInsert = New OleDb.OleDbCommand("act_TrnJurnaldetilbilyet_Insert", dbConn)
        dbCmdInsert.CommandType = CommandType.StoredProcedure
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_id", System.Data.OleDb.OleDbType.VarWChar, 24))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnaldetil_line", System.Data.OleDb.OleDbType.Integer, 4, "jurnaldetil_line"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnaldetil_dk", System.Data.OleDb.OleDbType.VarWChar, 2))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnaldetil_descr", System.Data.OleDb.OleDbType.VarWChar, 4000, "jurnaldetil_descr"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@rekanan_id", System.Data.OleDb.OleDbType.Decimal, 8, System.Data.ParameterDirection.Input, False, CType(8, Byte), CType(0, Byte), "rekanan_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@rekanan_name", System.Data.OleDb.OleDbType.VarWChar, 200, "rekanan_name"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@acc_id", System.Data.OleDb.OleDbType.VarWChar, 14, "acc_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@currency_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(3, Byte), CType(0, Byte), "currency_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnaldetil_foreign", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "jurnaldetil_foreign", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnaldetil_foreignrate", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "jurnaldetil_foreignrate", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnaldetil_idr", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "jurnaldetil_idr", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@strukturunit_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(6, Byte), CType(0, Byte), "strukturunit_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@ref_id", System.Data.OleDb.OleDbType.VarWChar, 24, "ref_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@ref_line", System.Data.OleDb.OleDbType.Integer, 4, "ref_line"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@ref_budgetline", System.Data.OleDb.OleDbType.Integer, 4, "ref_budgetline"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@region_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(7, Byte), CType(0, Byte), "region_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@branch_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(7, Byte), CType(0, Byte), "branch_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@budget_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(8, Byte), CType(0, Byte), "budget_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@budget_name", System.Data.OleDb.OleDbType.VarWChar, 100, "budget_name"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@budgetdetil_id", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(12, Byte), CType(0, Byte), "budgetdetil_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@budgetdetil_name", System.Data.OleDb.OleDbType.VarWChar, 200, "budgetdetil_name"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@username", System.Data.OleDb.OleDbType.VarWChar, 32))

        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnalbilyet_no", System.Data.OleDb.OleDbType.VarWChar, 60, "jurnalbilyet_no"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnalbilyet_date", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "jurnalbilyet_date"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnalbilyet_dateeffective", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "jurnalbilyet_dateeffective"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnalbilyet_receiveperson", System.Data.OleDb.OleDbType.VarWChar, 60, "jurnalbilyet_receiveperson"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnalbilyet_bank", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(3, Byte), CType(0, Byte), "jurnalbilyet_bank", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnalbilyet_pic", System.Data.OleDb.OleDbType.VarWChar, 50, "jurnalbilyet_pic"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@paymenttype_id", System.Data.OleDb.OleDbType.VarWChar, 6, "paymenttype_id"))

        dbCmdInsert.Parameters("@jurnal_id").Value = jurnal_id
        dbCmdInsert.Parameters("@jurnaldetil_dk").Value = "D"
        dbCmdInsert.Parameters("@username").Value = Me.UserName
        dbCmdInsert.Parameters("@channel_id").Value = Me._CHANNEL


        dbCmdUpdate = New OleDb.OleDbCommand("act_TrnJurnaldetilbilyet_Update", dbConn)
        dbCmdUpdate.CommandType = CommandType.StoredProcedure
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_id", System.Data.OleDb.OleDbType.VarWChar, 24))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnaldetil_line", System.Data.OleDb.OleDbType.Integer, 4, "jurnaldetil_line"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnaldetil_dk", System.Data.OleDb.OleDbType.VarWChar, 2))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnaldetil_descr", System.Data.OleDb.OleDbType.VarWChar, 4000, "jurnaldetil_descr"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@rekanan_id", System.Data.OleDb.OleDbType.Decimal, 8, System.Data.ParameterDirection.Input, False, CType(8, Byte), CType(0, Byte), "rekanan_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@rekanan_name", System.Data.OleDb.OleDbType.VarWChar, 200, "rekanan_name"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@acc_id", System.Data.OleDb.OleDbType.VarWChar, 14, "acc_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@currency_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(3, Byte), CType(0, Byte), "currency_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnaldetil_foreign", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "jurnaldetil_foreign", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnaldetil_foreignrate", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "jurnaldetil_foreignrate", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnaldetil_idr", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "jurnaldetil_idr", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20, "channel_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@strukturunit_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(6, Byte), CType(0, Byte), "strukturunit_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@ref_id", System.Data.OleDb.OleDbType.VarWChar, 24, "ref_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@ref_line", System.Data.OleDb.OleDbType.Integer, 4, "ref_line"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@ref_budgetline", System.Data.OleDb.OleDbType.Integer, 4, "ref_budgetline"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@region_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(7, Byte), CType(0, Byte), "region_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@branch_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(7, Byte), CType(0, Byte), "branch_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@budget_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(8, Byte), CType(0, Byte), "budget_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@budget_name", System.Data.OleDb.OleDbType.VarWChar, 100, "budget_name"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@budgetdetil_id", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(12, Byte), CType(0, Byte), "budgetdetil_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@budgetdetil_name", System.Data.OleDb.OleDbType.VarWChar, 200, "budgetdetil_name"))

        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnalbilyet_no", System.Data.OleDb.OleDbType.VarWChar, 60, "jurnalbilyet_no"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnalbilyet_date", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "jurnalbilyet_date"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnalbilyet_dateeffective", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "jurnalbilyet_dateeffective"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnalbilyet_receiveperson", System.Data.OleDb.OleDbType.VarWChar, 60, "jurnalbilyet_receiveperson"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnalbilyet_bank", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(3, Byte), CType(0, Byte), "jurnalbilyet_bank", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnalbilyet_pic", System.Data.OleDb.OleDbType.VarWChar, 50, "jurnalbilyet_pic"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@paymenttype_id", System.Data.OleDb.OleDbType.VarWChar, 6, "paymenttype_id"))

        dbCmdUpdate.Parameters("@jurnal_id").Value = jurnal_id
        dbCmdUpdate.Parameters("@jurnaldetil_dk").Value = "D"

        dbCmdDelete = New OleDb.OleDbCommand("act_TrnJurnaldetil_Delete", dbConn)
        dbCmdDelete.CommandType = CommandType.StoredProcedure
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_id", System.Data.OleDb.OleDbType.VarWChar, 24))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnaldetil_line", System.Data.OleDb.OleDbType.Integer, 4, "jurnaldetil_line"))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnaldetil_dk", System.Data.OleDb.OleDbType.VarWChar, 2, "jurnaldetil_dk"))
        dbCmdDelete.Parameters("@jurnal_id").Value = jurnal_id


        dbDA = New OleDb.OleDbDataAdapter
        dbDA.UpdateCommand = dbCmdUpdate
        dbDA.InsertCommand = dbCmdInsert
        dbDA.DeleteCommand = dbCmdDelete


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

    Private Function uiTrnJurnal_JV_Manual_SaveDetilCredit(ByRef jurnal_id As Object, ByVal objTbl As DataTable, ByVal MasterDataState As System.Data.DataRowState) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbCmdInsert As OleDb.OleDbCommand
        Dim dbCmdUpdate As OleDb.OleDbCommand
        Dim dbCmdDelete As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter
        Dim cookie As Byte() = Nothing

        ' Save data: Transaksi_jurnaldetil
        dbCmdInsert = New OleDb.OleDbCommand("act_TrnJurnaldetilbilyet_Insert", dbConn)
        dbCmdInsert.CommandType = CommandType.StoredProcedure
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_id", System.Data.OleDb.OleDbType.VarWChar, 24))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnaldetil_line", System.Data.OleDb.OleDbType.Integer, 4, "jurnaldetil_line"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnaldetil_dk", System.Data.OleDb.OleDbType.VarWChar, 2))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnaldetil_descr", System.Data.OleDb.OleDbType.VarWChar, 4000, "jurnaldetil_descr"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@rekanan_id", System.Data.OleDb.OleDbType.Decimal, 8, System.Data.ParameterDirection.Input, False, CType(8, Byte), CType(0, Byte), "rekanan_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@rekanan_name", System.Data.OleDb.OleDbType.VarWChar, 200, "rekanan_name"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@acc_id", System.Data.OleDb.OleDbType.VarWChar, 14, "acc_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@currency_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(3, Byte), CType(0, Byte), "currency_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnaldetil_foreign", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "jurnaldetil_foreign", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnaldetil_foreignrate", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "jurnaldetil_foreignrate", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnaldetil_idr", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "jurnaldetil_idr", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@strukturunit_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(6, Byte), CType(0, Byte), "strukturunit_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@ref_id", System.Data.OleDb.OleDbType.VarWChar, 24, "ref_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@ref_line", System.Data.OleDb.OleDbType.Integer, 4, "ref_line"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@ref_budgetline", System.Data.OleDb.OleDbType.Integer, 4, "ref_budgetline"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@region_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(7, Byte), CType(0, Byte), "region_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@branch_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(7, Byte), CType(0, Byte), "branch_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@budget_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(8, Byte), CType(0, Byte), "budget_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@budget_name", System.Data.OleDb.OleDbType.VarWChar, 100, "budget_name"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@budgetdetil_id", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(12, Byte), CType(0, Byte), "budgetdetil_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@budgetdetil_name", System.Data.OleDb.OleDbType.VarWChar, 200, "budgetdetil_name"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@username", System.Data.OleDb.OleDbType.VarWChar, 32))

        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnalbilyet_no", System.Data.OleDb.OleDbType.VarWChar, 60, "jurnalbilyet_no"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnalbilyet_date", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "jurnalbilyet_date"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnalbilyet_dateeffective", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "jurnalbilyet_dateeffective"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnalbilyet_receiveperson", System.Data.OleDb.OleDbType.VarWChar, 60, "jurnalbilyet_receiveperson"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnalbilyet_bank", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(3, Byte), CType(0, Byte), "jurnalbilyet_bank", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnalbilyet_pic", System.Data.OleDb.OleDbType.VarWChar, 50, "jurnalbilyet_pic"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@paymenttype_id", System.Data.OleDb.OleDbType.VarWChar, 6, "paymenttype_id"))

        dbCmdInsert.Parameters("@jurnal_id").Value = jurnal_id
        dbCmdInsert.Parameters("@jurnaldetil_dk").Value = "K"
        dbCmdInsert.Parameters("@username").Value = Me.UserName
        dbCmdInsert.Parameters("@channel_id").Value = Me._CHANNEL


        dbCmdUpdate = New OleDb.OleDbCommand("act_TrnJurnaldetilbilyet_Update", dbConn)
        dbCmdUpdate.CommandType = CommandType.StoredProcedure
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_id", System.Data.OleDb.OleDbType.VarWChar, 24))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnaldetil_line", System.Data.OleDb.OleDbType.Integer, 4, "jurnaldetil_line"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnaldetil_dk", System.Data.OleDb.OleDbType.VarWChar, 2))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnaldetil_descr", System.Data.OleDb.OleDbType.VarWChar, 4000, "jurnaldetil_descr"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@rekanan_id", System.Data.OleDb.OleDbType.Decimal, 8, System.Data.ParameterDirection.Input, False, CType(8, Byte), CType(0, Byte), "rekanan_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@rekanan_name", System.Data.OleDb.OleDbType.VarWChar, 200, "rekanan_name"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@acc_id", System.Data.OleDb.OleDbType.VarWChar, 14, "acc_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@currency_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(3, Byte), CType(0, Byte), "currency_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnaldetil_foreign", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "jurnaldetil_foreign", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnaldetil_foreignrate", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "jurnaldetil_foreignrate", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnaldetil_idr", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "jurnaldetil_idr", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20, "channel_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@strukturunit_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(6, Byte), CType(0, Byte), "strukturunit_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@ref_id", System.Data.OleDb.OleDbType.VarWChar, 24, "ref_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@ref_line", System.Data.OleDb.OleDbType.Integer, 4, "ref_line"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@ref_budgetline", System.Data.OleDb.OleDbType.Integer, 4, "ref_budgetline"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@region_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(7, Byte), CType(0, Byte), "region_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@branch_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(7, Byte), CType(0, Byte), "branch_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@budget_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(8, Byte), CType(0, Byte), "budget_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@budget_name", System.Data.OleDb.OleDbType.VarWChar, 100, "budget_name"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@budgetdetil_id", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(12, Byte), CType(0, Byte), "budgetdetil_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@budgetdetil_name", System.Data.OleDb.OleDbType.VarWChar, 200, "budgetdetil_name"))

        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnalbilyet_no", System.Data.OleDb.OleDbType.VarWChar, 60, "jurnalbilyet_no"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnalbilyet_date", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "jurnalbilyet_date"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnalbilyet_dateeffective", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "jurnalbilyet_dateeffective"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnalbilyet_receiveperson", System.Data.OleDb.OleDbType.VarWChar, 60, "jurnalbilyet_receiveperson"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnalbilyet_bank", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(3, Byte), CType(0, Byte), "jurnalbilyet_bank", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnalbilyet_pic", System.Data.OleDb.OleDbType.VarWChar, 50, "jurnalbilyet_pic"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@paymenttype_id", System.Data.OleDb.OleDbType.VarWChar, 6, "paymenttype_id"))

        dbCmdUpdate.Parameters("@jurnal_id").Value = jurnal_id
        dbCmdUpdate.Parameters("@jurnaldetil_dk").Value = "K"


        dbCmdDelete = New OleDb.OleDbCommand("act_TrnJurnaldetilbilyet_Delete", dbConn)
        dbCmdDelete.CommandType = CommandType.StoredProcedure
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_id", System.Data.OleDb.OleDbType.VarWChar, 24))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnaldetil_line", System.Data.OleDb.OleDbType.Integer, 4, "jurnaldetil_line"))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnaldetil_dk", System.Data.OleDb.OleDbType.VarWChar, 2, "jurnaldetil_dk"))
        dbCmdDelete.Parameters("@jurnal_id").Value = jurnal_id


        dbDA = New OleDb.OleDbDataAdapter
        dbDA.UpdateCommand = dbCmdUpdate
        dbDA.InsertCommand = dbCmdInsert
        dbDA.DeleteCommand = dbCmdDelete

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

    Private Function uiTrnJurnal_JV_Manual_SaveReference(ByRef jurnal_id As Object, ByVal objTbl As DataTable, ByVal MasterDataState As System.Data.DataRowState) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbCmdInsert As OleDb.OleDbCommand
        Dim dbCmdDelete As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter
        Dim cookie As Byte() = Nothing

        ' Save data: transaksi_jurnaldetil
        dbCmdInsert = New OleDb.OleDbCommand("act_TrnJurnalreference_Insert", dbConn)
        dbCmdInsert.CommandType = CommandType.StoredProcedure
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_id", System.Data.OleDb.OleDbType.VarWChar, 24))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnaldetil_line", System.Data.OleDb.OleDbType.Integer, 4, "jurnaldetil_line"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_id_ref", System.Data.OleDb.OleDbType.VarWChar, 24, "ref"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_id_refline", System.Data.OleDb.OleDbType.Integer, 4, "line"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_id_budgetline", System.Data.OleDb.OleDbType.Integer, 4, "budget_line"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@referencetype", System.Data.OleDb.OleDbType.VarWChar, 30))
        dbCmdInsert.Parameters("@jurnal_id").Value = jurnal_id
        dbCmdInsert.Parameters("@referencetype").Value = "RECEIPT"

        dbCmdDelete = New OleDb.OleDbCommand("act_TrnJurnalreference_Delete", dbConn)
        dbCmdDelete.CommandType = CommandType.StoredProcedure
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_id", System.Data.OleDb.OleDbType.VarWChar, 24))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnaldetil_line", System.Data.OleDb.OleDbType.Integer, 4, "jurnaldetil_line"))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_id_ref", System.Data.OleDb.OleDbType.VarWChar, 24, "ref"))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_id_refline", System.Data.OleDb.OleDbType.Integer, 4, "line"))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_id_budgetline", System.Data.OleDb.OleDbType.Integer, 4, "budget_line"))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@referencetype", System.Data.OleDb.OleDbType.VarWChar, 30))
        dbCmdDelete.Parameters("@jurnal_id").Value = jurnal_id
        dbCmdDelete.Parameters("@referencetype").Value = "RECEIPT"

        dbDA = New OleDb.OleDbDataAdapter
        dbDA.InsertCommand = dbCmdInsert
        dbDA.DeleteCommand = dbCmdDelete


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

    Private Function uiTrnJurnal_JV_Manual_Delete() As Boolean
        Dim res As String = ""
        Dim jurnal_id As Object = New Object

        Me.Cursor = Cursors.WaitCursor
        RaiseEvent FormBeforeDelete(jurnal_id)

        Me.Cursor = Cursors.WaitCursor
        If Me.DgvTrnJurnal.CurrentRow IsNot Nothing Then

            res = MessageBox.Show("Are you sure want to delete data ?", mUiName, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If res = DialogResult.Yes Then
                Me.uiTrnJurnal_JV_Manual_DeleteRow(Me.DgvTrnJurnal.CurrentRow.Index)
            End If

        End If

        RaiseEvent FormAfterDelete(jurnal_id)
        Me.Cursor = Cursors.Arrow

    End Function

    Private Function uiTrnJurnal_JV_Manual_DeleteRow(ByVal rowIndex As Integer) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbCmdDelete As OleDb.OleDbCommand
        Dim jurnal_id As String
        Dim NewRowIndex As Integer
        Dim cookie As Byte() = Nothing

        jurnal_id = Me.DgvTrnJurnal.Rows(rowIndex).Cells("jurnal_id").Value

        dbCmdDelete = New OleDb.OleDbCommand("act_TrnJurnal_Disabled", dbConn)
        dbCmdDelete.CommandType = CommandType.StoredProcedure
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_id", System.Data.OleDb.OleDbType.VarWChar, 24))
        dbCmdDelete.Parameters("@jurnal_id").Value = jurnal_id
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_isdisabledby", System.Data.OleDb.OleDbType.VarWChar, 32))
        dbCmdDelete.Parameters("@jurnal_isdisabledby").Value = Me.UserName
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_isdisableddt", System.Data.OleDb.OleDbType.DBTimeStamp, 4))
        dbCmdDelete.Parameters("@jurnal_isdisableddt").Value = Now.Date

        Try
            dbConn.Open()
            clsApplicationRole.SetAppRole(dbConn, cookie)
            dbCmdDelete.ExecuteNonQuery()

            If Me.DgvTrnJurnal.Rows.Count > 1 Then
                If rowIndex = 0 Then
                    NewRowIndex = rowIndex + 1
                    Me.uiTrnJurnal_JV_Manual_OpenRow(NewRowIndex)
                ElseIf rowIndex = Me.DgvTrnJurnal.Rows.Count - 1 Then
                    NewRowIndex = rowIndex - 1
                    Me.uiTrnJurnal_JV_Manual_OpenRow(NewRowIndex)
                Else
                    Me.uiTrnJurnal_JV_Manual_OpenRow(rowIndex)
                End If
            Else
                Me.tbl_TrnJurnal_Temp.Clear()
                Me.uiTrnJurnal_JV_Manual_NewData()
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

    Private Function uiTrnJurnal_JV_Manual_OpenRow(ByVal rowIndex As Integer) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim jurnal_id As String
        Dim channel_id As String
        Dim cookie As Byte() = Nothing

        jurnal_id = Me.DgvTrnJurnal.Rows(rowIndex).Cells("jurnal_id").Value
        channel_id = Me.DgvTrnJurnal.Rows(rowIndex).Cells("channel_id").Value

        Me.Cursor = Cursors.WaitCursor
        RaiseEvent FormBeforeOpenRow(jurnal_id)

        Try
            dbConn.Open()
            clsApplicationRole.SetAppRole(dbConn, cookie)
            Me.uiTrnJurnal_JV_Manual_OpenRowMaster(channel_id, jurnal_id, dbConn)
            Me.uiTrnJurnal_JV_Manual_OpenRowDetilDebit(channel_id, jurnal_id, dbConn)
            Me.uiTrnJurnal_JV_Manual_OpenRowDetilCredit(channel_id, jurnal_id, dbConn)
            Me.uiTrnJurnal_JV_Manual_OpenRowResponse(channel_id, jurnal_id, dbConn)

            If Me._USER_TYPE = "SPV" Then
                If Me.DgvTrnJurnal.Rows(Me.DgvTrnJurnal.CurrentRow.Index).Cells("jurnal_isposted").Value = True Then
                    Me.btnPost.Visible = False
                    Me.btnUnPost.Visible = True
                Else
                    Me.btnPost.Visible = True
                    Me.btnUnPost.Visible = False
                End If
            Else
                Me.btnPost.Visible = False
                Me.btnUnPost.Visible = False
            End If

            If Me.DgvTrnJurnal.Rows(Me.DgvTrnJurnal.CurrentRow.Index).Cells("jurnal_isposted").Value = True Then
                Me.btnUpload.Enabled = False
            Else
                Me.btnUpload.Enabled = True
            End If

            Me.btnCopyJurnal.Visible = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, mUiName & ": uiTrnJurnal_JV_Manual_OpenRow()", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            clsApplicationRole.UnsetAppRole(dbConn, cookie)
            dbConn.Close()
        End Try

        RaiseEvent FormAfterOpenRow(jurnal_id)

        Me.DgvTrnJurnaldetil_Credit.Columns("jurnal_id").Visible = False
        Me.DgvTrnJurnaldetil_Debit.Columns("jurnal_id").Visible = False

        For r As Integer = 0 To Me.DgvTrnJurnaldetil_Credit.Rows.Count - 1
            If (Me.DgvTrnJurnaldetil_Credit.Rows(r).Cells("acc_id").Value <> akunKerugianSelisihKursPajak) And (Me.DgvTrnJurnaldetil_Credit.Rows(r).Cells("acc_id").Value <> akunKeuntunganSelisihKursPajak) And _
                   (Me.DgvTrnJurnaldetil_Credit.Rows(r).Cells("acc_id").Value <> akunKerugianSelisihKurs) And (Me.DgvTrnJurnaldetil_Credit.Rows(r).Cells("acc_id").Value <> akunKeuntunganSelisihKurs) Then
                Me.DgvTrnJurnaldetil_Credit.Rows(r).Cells("jurnaldetil_foreign").ReadOnly = False
                Me.DgvTrnJurnaldetil_Credit.Rows(r).Cells("jurnaldetil_foreign").Style.BackColor = Color.White
                Me.DgvTrnJurnaldetil_Credit.Rows(r).Cells("jurnaldetil_foreignrate").ReadOnly = False
                Me.DgvTrnJurnaldetil_Credit.Rows(r).Cells("jurnaldetil_foreignrate").Style.BackColor = Color.White
                Me.DgvTrnJurnaldetil_Credit.Rows(r).Cells("jurnaldetil_idr").ReadOnly = True
                Me.DgvTrnJurnaldetil_Credit.Rows(r).Cells("jurnaldetil_idr").Style.BackColor = Color.LightYellow
            Else
                Me.DgvTrnJurnaldetil_Credit.Rows(r).Cells("jurnaldetil_foreign").ReadOnly = True
                Me.DgvTrnJurnaldetil_Credit.Rows(r).Cells("jurnaldetil_foreign").Style.BackColor = Color.LightYellow
                Me.DgvTrnJurnaldetil_Credit.Rows(r).Cells("jurnaldetil_foreignrate").ReadOnly = True
                Me.DgvTrnJurnaldetil_Credit.Rows(r).Cells("jurnaldetil_foreignrate").Style.BackColor = Color.LightYellow
                Me.DgvTrnJurnaldetil_Credit.Rows(r).Cells("jurnaldetil_idr").ReadOnly = False
                Me.DgvTrnJurnaldetil_Credit.Rows(r).Cells("jurnaldetil_idr").Style.BackColor = Color.White
            End If
        Next

        For r As Integer = 0 To Me.DgvTrnJurnaldetil_Debit.Rows.Count - 1
            If (Me.DgvTrnJurnaldetil_Debit.Rows(r).Cells("acc_id").Value <> akunKerugianSelisihKursPajak) And (Me.DgvTrnJurnaldetil_Debit.Rows(r).Cells("acc_id").Value <> akunKeuntunganSelisihKursPajak) And _
                  (Me.DgvTrnJurnaldetil_Debit.Rows(r).Cells("acc_id").Value <> akunKerugianSelisihKurs) And (Me.DgvTrnJurnaldetil_Debit.Rows(r).Cells("acc_id").Value <> akunKeuntunganSelisihKurs) Then
                Me.DgvTrnJurnaldetil_Debit.Rows(r).Cells("jurnaldetil_foreign").ReadOnly = False
                Me.DgvTrnJurnaldetil_Debit.Rows(r).Cells("jurnaldetil_foreign").Style.BackColor = Color.White
                Me.DgvTrnJurnaldetil_Debit.Rows(r).Cells("jurnaldetil_foreignrate").ReadOnly = False
                Me.DgvTrnJurnaldetil_Debit.Rows(r).Cells("jurnaldetil_foreignrate").Style.BackColor = Color.White
                Me.DgvTrnJurnaldetil_Debit.Rows(r).Cells("jurnaldetil_idr").ReadOnly = True
                Me.DgvTrnJurnaldetil_Debit.Rows(r).Cells("jurnaldetil_idr").Style.BackColor = Color.LightYellow
            Else
                Me.DgvTrnJurnaldetil_Debit.Rows(r).Cells("jurnaldetil_foreign").ReadOnly = True
                Me.DgvTrnJurnaldetil_Debit.Rows(r).Cells("jurnaldetil_foreign").Style.BackColor = Color.LightYellow
                Me.DgvTrnJurnaldetil_Debit.Rows(r).Cells("jurnaldetil_foreignrate").ReadOnly = True
                Me.DgvTrnJurnaldetil_Debit.Rows(r).Cells("jurnaldetil_foreignrate").Style.BackColor = Color.LightYellow
                Me.DgvTrnJurnaldetil_Debit.Rows(r).Cells("jurnaldetil_idr").ReadOnly = False
                Me.DgvTrnJurnaldetil_Debit.Rows(r).Cells("jurnaldetil_idr").Style.BackColor = Color.White
            End If
        Next


        Me.Cursor = Cursors.Arrow

        Return True

    End Function

    Private Function uiTrnJurnal_JV_Manual_OpenRowMaster(ByVal channel_id As String, ByVal jurnal_id As String, ByVal dbConn As OleDb.OleDbConnection) As Boolean
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        dbCmd = New OleDb.OleDbCommand("act_TrnJurnal_Select", dbConn)
        dbCmd.Parameters.Add("@channel_id", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@channel_id").Value = channel_id
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@Criteria").Value = String.Format("jurnal_id='{0}'", jurnal_id)
        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)
        Me.tbl_TrnJurnal_Temp.Clear()

        Try
            Me.BindingStop()
            dbDA.Fill(Me.tbl_TrnJurnal_Temp)
            Me.BindingStart()
        Catch ex As Exception
            Throw New Exception(mUiName & ": uiTrnJurnal_JV_Manual_OpenRowMaster()" & vbCrLf & ex.Message)
        End Try

    End Function

    Private Function uiTrnJurnal_JV_Manual_OpenRowDetilCredit(ByVal channel_id As String, ByVal jurnal_id As String, ByVal dbConn As OleDb.OleDbConnection) As Boolean
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        dbCmd = New OleDb.OleDbCommand("act_TrnJurnaldetilbilyet_Select", dbConn)
        dbCmd.Parameters.Add("@channel_id", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@channel_id").Value = channel_id
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@Criteria").Value = String.Format("A.jurnal_id = '{0}' AND A.jurnaldetil_dk = 'K'", jurnal_id)
        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)

        Me.tbl_TrnJurnaldetil_Credit.Clear()
        'Me.tbl_TrnJurnaldetil_Credit = clsDataset.CreateTblTrnJurnaldetil()
        Me.tbl_TrnJurnaldetil_Credit = clsDataset.CreateTblTrnJurnaldetilBilyet()
        Me.tbl_TrnJurnaldetil_Credit.Columns("jurnal_id").DefaultValue = jurnal_id
        Me.tbl_TrnJurnaldetil_Credit.Columns("jurnaldetil_line").DefaultValue = DBNull.Value
        Me.tbl_TrnJurnaldetil_Credit.Columns("jurnaldetil_line").AutoIncrement = True
        Me.tbl_TrnJurnaldetil_Credit.Columns("jurnaldetil_line").AutoIncrementSeed = 15
        Me.tbl_TrnJurnaldetil_Credit.Columns("jurnaldetil_line").AutoIncrementStep = 10
        Me.tbl_TrnJurnaldetil_Credit.Columns("currency_id").DefaultValue = 1
        Me.tbl_TrnJurnaldetil_Credit.Columns("jurnaldetil_foreignrate").DefaultValue = 1
        Me.tbl_TrnJurnaldetil_Credit.Columns("channel_id").DefaultValue = Me._CHANNEL
        Me.tbl_TrnJurnaldetil_Credit.Columns("jurnaldetil_dk").DefaultValue = "K"
        Me.tbl_TrnJurnaldetil_Credit.Columns("paymenttype_id").DefaultValue = "0"
        Me.tbl_TrnJurnaldetil_Credit.Columns("jurnalbilyet_bank").DefaultValue = 0

        Try
            dbDA.Fill(Me.tbl_TrnJurnaldetil_Credit)
            Me.uiTrnJurnal_JV_Manual_TblDetilInverse(Me.tbl_TrnJurnaldetil_Credit)
            Me.DgvTrnJurnaldetil_Credit.DataSource = Me.tbl_TrnJurnaldetil_Credit
        Catch ex As Exception
            Throw New Exception(mUiName & ": uiTrnJurnal_JV_Manual_OpenRowDetilDebit()" & vbCrLf & ex.Message)
        End Try

    End Function

    Private Function uiTrnJurnal_JV_Manual_OpenRowDetilDebit(ByVal channel_id As String, ByVal jurnal_id As String, ByVal dbConn As OleDb.OleDbConnection) As Boolean
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        dbCmd = New OleDb.OleDbCommand("act_TrnJurnaldetilbilyet_Select", dbConn)
        dbCmd.Parameters.Add("@channel_id", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@channel_id").Value = channel_id
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@Criteria").Value = String.Format("A.jurnal_id = '{0}' AND A.jurnaldetil_dk = 'D'", jurnal_id)
        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)

        Me.tbl_TrnJurnaldetil_Debit.Clear()
        Me.tbl_TrnJurnaldetil_Debit = clsDataset.CreateTblTrnJurnaldetilBilyet()
        Me.tbl_TrnJurnaldetil_Debit.Columns("jurnal_id").DefaultValue = jurnal_id
        Me.tbl_TrnJurnaldetil_Debit.Columns("jurnaldetil_line").DefaultValue = DBNull.Value
        Me.tbl_TrnJurnaldetil_Debit.Columns("jurnaldetil_line").AutoIncrement = True
        Me.tbl_TrnJurnaldetil_Debit.Columns("jurnaldetil_line").AutoIncrementSeed = 10
        Me.tbl_TrnJurnaldetil_Debit.Columns("jurnaldetil_line").AutoIncrementStep = 10
        Me.tbl_TrnJurnaldetil_Debit.Columns("currency_id").DefaultValue = 1
        Me.tbl_TrnJurnaldetil_Debit.Columns("jurnaldetil_foreignrate").DefaultValue = 1
        Me.tbl_TrnJurnaldetil_Debit.Columns("channel_id").DefaultValue = Me._CHANNEL
        Me.tbl_TrnJurnaldetil_Debit.Columns("jurnaldetil_dk").DefaultValue = "D"
        Me.tbl_TrnJurnaldetil_Debit.Columns("paymenttype_id").DefaultValue = "0"
        Me.tbl_TrnJurnaldetil_Debit.Columns("jurnalbilyet_bank").DefaultValue = 0

        Try
            dbDA.Fill(Me.tbl_TrnJurnaldetil_Debit)
            Me.DgvTrnJurnaldetil_Debit.DataSource = Me.tbl_TrnJurnaldetil_Debit

        Catch ex As Exception
            Throw New Exception(mUiName & ": uiTrnJurnal_JV_Manual_OpenRowDetilDebit()" & vbCrLf & ex.Message)
        End Try

    End Function

    Private Function uiTrnJurnal_JV_Manual_OpenRowResponse(ByVal channel_id As String, ByVal jurnal_id As String, ByVal dbConn As OleDb.OleDbConnection) As Boolean
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        dbCmd = New OleDb.OleDbCommand("act_TrnJurnalResponse_Select", dbConn)
        dbCmd.Parameters.Add("@channel_id", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@channel_id").Value = channel_id
        dbCmd.Parameters.Add("@jurnal_id", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@jurnal_id").Value = jurnal_id
        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)

        Try
            Me.tbl_TrnJurnalResponse.Clear()
            dbDA.Fill(Me.tbl_TrnJurnalResponse)
            Me.DgvTrnJurnalResponse.DataSource = Me.tbl_TrnJurnalResponse
        Catch ex As Exception
            Throw New Exception(mUiName & ": uiTrnJurnal_OpenRowResponse()" & vbCrLf & ex.Message)
        End Try

    End Function

    Private Function uiTrnJurnal_JV_Manual_First() As Boolean
        'goto first record found
        Dim move As Boolean
        Dim Message As String = "Data has been changed. " & vbCrLf & "Save data changes before move to first record ?"
        Dim iTab As Integer = Me.ftabMain.SelectedIndex

        If iTab = 1 Then
            If Me.DATA_ISLOCKED Then
                move = True
            Else
                move = Me.uiTrnJurnal_JV_Manual_ConfirmSaveBeforeMove(Message)
            End If
        Else
            move = True
        End If

        If move Then
            Try
                Me.DgvTrnJurnal.CurrentCell = Me.DgvTrnJurnal(0, Me.DgvTrnJurnal.Rows.Count - 1)
                Me.uiTrnJurnal_JV_Manual_RefreshPosition()
            Catch ex As Exception
            End Try
        End If
    End Function

    Private Function uiTrnJurnal_JV_Manual_Prev() As Boolean
        'goto previous record found
        Dim move As Boolean
        Dim Message As String = "Data has been changed. " & vbCrLf & "Save data changes before move to previous record ?"
        Dim iTab As Integer = Me.ftabMain.SelectedIndex

        If iTab = 1 Then
            If Me.DATA_ISLOCKED Then
                move = True
            Else
                move = Me.uiTrnJurnal_JV_Manual_ConfirmSaveBeforeMove(Message)
            End If
        Else
            move = True
        End If

        If move Then
            Try
                If Me.DgvTrnJurnal.CurrentCell.RowIndex < Me.DgvTrnJurnal.Rows.Count - 1 Then
                    Me.DgvTrnJurnal.CurrentCell = Me.DgvTrnJurnal(0, DgvTrnJurnal.CurrentCell.RowIndex + 1)
                    Me.uiTrnJurnal_JV_Manual_RefreshPosition()
                End If
            Catch ex As Exception
            End Try
        End If
    End Function

    Private Function uiTrnJurnal_JV_Manual_Next() As Boolean
        'goto next record found
        Dim move As Boolean
        Dim Message As String = "Data has been changed. " & vbCrLf & "Save data changes before move to next record ?"
        Dim iTab As Integer = Me.ftabMain.SelectedIndex

        If iTab = 1 Then
            If Me.DATA_ISLOCKED Then
                move = True
            Else
                move = Me.uiTrnJurnal_JV_Manual_ConfirmSaveBeforeMove(Message)
            End If
        Else
            move = True
        End If

        If move Then
            Try

                If Me.DgvTrnJurnal.CurrentCell.RowIndex > 0 Then
                    Me.DgvTrnJurnal.CurrentCell = Me.DgvTrnJurnal(0, DgvTrnJurnal.CurrentCell.RowIndex - 1)
                    Me.uiTrnJurnal_JV_Manual_RefreshPosition()
                End If
            Catch ex As Exception
            End Try
        End If
    End Function

    Private Function uiTrnJurnal_JV_Manual_Last() As Boolean
        'goto last record found
        Dim move As Boolean
        Dim Message As String = "Data has been changed. " & vbCrLf & "Save data changes before move to next record ?"
        Dim iTab As Integer = Me.ftabMain.SelectedIndex

        If iTab = 1 Then
            If Me.DATA_ISLOCKED Then
                move = True
            Else
                move = Me.uiTrnJurnal_JV_Manual_ConfirmSaveBeforeMove(Message)
            End If
        Else
            move = True
        End If

        If move Then

            Try
                If move Then
                    Me.DgvTrnJurnal.CurrentCell = Me.DgvTrnJurnal(0, 0)
                    Me.uiTrnJurnal_JV_Manual_RefreshPosition()
                End If
            Catch ex As Exception
            End Try
        End If
    End Function

    Private Function uiTrnJurnal_JV_Manual_RefreshPosition() As Boolean
        'refresh position
        Dim iTab As Integer = Me.ftabMain.SelectedIndex
        If iTab = 1 Then uiTrnJurnal_JV_Manual_OpenRow(Me.DgvTrnJurnal.CurrentRow.Index)
    End Function

    Private Function uiTrnJurnal_JV_Manual_ConfirmSaveBeforeMove(ByVal Message As String) As Boolean
        'confirm saving data changes before move
        Dim tbl_TrnJurnal_Temp_Changes As DataTable
        Dim tbl_TrnJurnaldetil_Debit_Changes As DataTable
        Dim tbl_TrnJurnaldetil_Credit_Changes As DataTable
        Dim res As System.Windows.Forms.DialogResult
        Dim success As Boolean
        Dim i As Integer = 0
        Dim MasterDataState As System.Data.DataRowState
        Dim jurnal_id As Object = New Object
        Dim move As Boolean = False
        Dim result As FormSaveResult


        If Me.DgvTrnJurnal.CurrentCell IsNot Nothing Then

            Me.BindingContext(Me.tbl_TrnJurnal_Temp).EndCurrentEdit()

            Me.DgvTrnJurnaldetil_Debit.EndEdit()
            Me.BindingContext(Me.tbl_TrnJurnaldetil_Debit).EndCurrentEdit()
            tbl_TrnJurnaldetil_Debit_Changes = Me.tbl_TrnJurnaldetil_Debit.GetChanges()
            If tbl_TrnJurnaldetil_Debit_Changes IsNot Nothing Then
                If Me.tbl_TrnJurnal_Temp.Rows(0).RowState <> DataRowState.Added Then
                    Me.obj_Modified_by.Text = Me.UserName
                    Me.obj_Modified_dt.Text = Now()
                End If
            End If

            Me.DgvTrnJurnaldetil_Credit.EndEdit()
            Me.BindingContext(Me.tbl_TrnJurnaldetil_Credit).EndCurrentEdit()
            tbl_TrnJurnaldetil_Credit_Changes = Me.tbl_TrnJurnaldetil_Credit.GetChanges()
            If tbl_TrnJurnaldetil_Credit_Changes IsNot Nothing Then
                If Me.tbl_TrnJurnal_Temp.Rows(0).RowState <> DataRowState.Added Then
                    Me.obj_Modified_by.Text = Me.UserName
                    Me.obj_Modified_dt.Text = Now()
                End If
            End If

            Me.BindingContext(Me.tbl_TrnJurnal_Temp).EndCurrentEdit()
            tbl_TrnJurnal_Temp_Changes = Me.tbl_TrnJurnal_Temp.GetChanges()


            If tbl_TrnJurnal_Temp_Changes IsNot Nothing Or tbl_TrnJurnaldetil_Debit_Changes IsNot Nothing Or tbl_TrnJurnaldetil_Credit_Changes IsNot Nothing Then

                res = MessageBox.Show(Message, mUiName, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                Select Case res
                    Case DialogResult.Yes

                        RaiseEvent FormBeforeSave(jurnal_id)

                        Try

                            MasterDataState = tbl_TrnJurnal_Temp.Rows(0).RowState
                            jurnal_id = tbl_TrnJurnal_Temp.Rows(0).Item("jurnal_id")

                            If tbl_TrnJurnal_Temp_Changes IsNot Nothing Then
                                success = Me.uiTrnJurnal_JV_Manual_SaveMaster(jurnal_id, tbl_TrnJurnal_Temp_Changes, MasterDataState)
                                If Not success Then Throw New Exception("Error: Saving Master Data at Me.uiTrnJurnal_JV_Manual_SaveMaster(tbl_TrnJurnal_Temp_Changes)")
                                Me.tbl_TrnJurnal_Temp.AcceptChanges()
                            End If

                            If tbl_TrnJurnaldetil_Debit_Changes IsNot Nothing Then
                                For i = 0 To Me.tbl_TrnJurnaldetil_Debit.Rows.Count - 1
                                    If Me.tbl_TrnJurnaldetil_Debit.Rows(i).RowState = DataRowState.Added Then
                                        Me.tbl_TrnJurnaldetil_Debit.Rows(i).Item("jurnal_id") = jurnal_id
                                    End If
                                Next
                                success = Me.uiTrnJurnal_JV_Manual_SaveDetilDebit(jurnal_id, tbl_TrnJurnaldetil_Debit_Changes, MasterDataState)
                                If Not success Then Throw New Exception("Error: Save Detil Data at Me.uiTrnJurnal_JV_Manual_SaveDetil(tbl_TrnJurnaldetil_Debit_Changes)")
                                Me.tbl_TrnJurnaldetil_Debit.AcceptChanges()
                            End If

                            If tbl_TrnJurnaldetil_Credit_Changes IsNot Nothing Then
                                For i = 0 To Me.tbl_TrnJurnaldetil_Credit.Rows.Count - 1
                                    If Me.tbl_TrnJurnaldetil_Credit.Rows(i).RowState = DataRowState.Added Then
                                        Me.tbl_TrnJurnaldetil_Credit.Rows(i).Item("jurnal_id") = jurnal_id
                                    End If
                                Next
                                Me.uiTrnJurnal_JV_Manual_TblDetilInverse(tbl_TrnJurnaldetil_Credit_Changes)
                                success = Me.uiTrnJurnal_JV_Manual_SaveDetilCredit(jurnal_id, tbl_TrnJurnaldetil_Credit_Changes, MasterDataState)
                                If Not success Then Throw New Exception("Error: Save Detil Data at Me.uiTrnJurnal_JV_Manual_SaveDetil(tbl_TrnJurnaldetil_Credit_Changes)")
                                Me.tbl_TrnJurnaldetil_Debit.AcceptChanges()
                            End If

                            result = FormSaveResult.SaveSuccess
                            If SHOW_SAVE_CONFIRMATION Then
                                MessageBox.Show("Data Saved", mUiName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                            End If

                        Catch ex As Exception
                            result = FormSaveResult.SaveError
                            MessageBox.Show(ex.Message & vbCrLf & "Data Cannot Be Saved", mUiName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try

                        RaiseEvent FormAfterSave(jurnal_id, result)

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

    Private Function uiTrnJurnal_JV_Manual_FormError() As Boolean
        Dim message As String = ""
        Try
            ' TODO: Cek Error disini
            ' objFormError.SetError()

            'cek periode sudah diisi
            If Me.obj_Periode_id.SelectedValue = "0" Then
                message = "Period not yet filled"
                Me.objFormError.SetError(Me.obj_Periode_id, message)
                Throw New Exception(message)
            Else
                Me.objFormError.SetError(Me.obj_Periode_id, "")
            End If

            'cek rekanan
            If Me.obj_Rekanan_id.SelectedValue = "0" Then
                message = "Rekanan not yet filled"
                Me.objFormError.SetError(Me.obj_Rekanan_id, message)
                Throw New Exception(message)
            Else
                Me.objFormError.SetError(Me.obj_Rekanan_id, "")
            End If

            'cek book date dan tanggal periode
            Dim dr() As DataRow = Me.tbl_MstPeriode.Select(String.Format("periode_id='{0}'", Me.obj_Periode_id.SelectedValue))
            Dim tgl_start As Date = dr(0).Item("periode_datestart")
            Dim tgl_end As Date = dr(0).Item("periode_dateend")
            Dim tgl As Date = CDate(Me.obj_Jurnal_bookdate.Value).Date

            If dr(0).Item("periode_isclosed") = True Then
                Me.objFormError.SetError(Me.obj_Periode_id, "period has closed! Please contact your administrator for open this period")
                Throw New Exception("period has closed!! Please contact your administrator for open this period")
            Else
                Me.objFormError.SetError(Me.obj_Periode_id, "")
            End If

            If tgl >= tgl_start And tgl <= tgl_end Then
                Me.objFormError.SetError(Me.obj_Periode_id, "")
                Me.objFormError.SetError(Me.obj_Jurnal_bookdate, "")
            Else
                message = "Bookdate does not match with the Period!!"
                Me.objFormError.SetError(Me.obj_Periode_id, message)
                Me.objFormError.SetError(Me.obj_Jurnal_bookdate, message)
                Throw New Exception(message)
            End If

            If Me._USER_TYPE <> "FINANCE" Then

                'cek balance
                ' Tambahan pengecekan balance 20151105 Ari MDP2
                '=======================================================================================
                '==== ari 20151105 =====================================================================
                For r As Integer = 0 To Me.DgvTrnJurnaldetil_Debit.Rows.Count - 1
                    Me.uiTrnJurnal_JV_Manual_RowCalcIDR(Me.DgvTrnJurnaldetil_Debit, Me.DgvTrnJurnaldetil_Debit.Rows(r).Cells("jurnaldetil_idr"), Me.DgvTrnJurnaldetil_Debit.Rows(r).Cells("jurnaldetil_foreign"), Me.DgvTrnJurnaldetil_Debit.Rows(r).Cells("jurnaldetil_foreignrate"))
                Next

                For r As Integer = 0 To Me.DgvTrnJurnaldetil_Credit.Rows.Count - 1
                    Me.uiTrnJurnal_JV_Manual_RowCalcIDR(Me.DgvTrnJurnaldetil_Credit, Me.DgvTrnJurnaldetil_Credit.Rows(r).Cells("jurnaldetil_idr"), Me.DgvTrnJurnaldetil_Credit.Rows(r).Cells("jurnaldetil_foreign"), Me.DgvTrnJurnaldetil_Credit.Rows(r).Cells("jurnaldetil_foreignrate"))
                Next
                '=========================================================================================

                'cek balance
                Dim selisih, jumlah As Decimal
                Me.DgvTrnJurnaldetil_Debit.EndEdit()
                Me.DgvTrnJurnaldetil_Credit.EndEdit()
                Me.uiTrnJurnal_JV_Manual_RowCalculate(Me.DgvTrnJurnaldetil_Debit, Me.DgvTrnJurnaldetil_Credit, selisih, jumlah)
                If selisih <> 0 Then
                    Me.obj_Selisih.Text = String.Format("{0:#,##0}", selisih)
                    Me.obj_Jumlah.Text = String.Format("{0:#,##0}", jumlah)
                    message = "Debit and credit isn't balance!!"
                    Me.objFormError.SetError(Me.obj_Selisih, message)
                    Throw New Exception(message)
                Else
                    Me.objFormError.SetError(Me.obj_Selisih, "")
                End If

                Me.DgvTrnJurnaldetil_Debit.EndEdit()
                Me.DgvTrnJurnaldetil_Credit.EndEdit()
                Me.uiTrnJurnal_JV_Manual_RowCalculateForeign(Me.DgvTrnJurnaldetil_Debit, Me.DgvTrnJurnaldetil_Credit, selisih, jumlah)
                If selisih <> 0 Then
                    Me.obj_Selisih_Foreign.Text = String.Format("{0:#,##0.00}", selisih)
                    Me.obj_Jumlah_Foreign.Text = String.Format("{0:#,##0.00}", jumlah)
                    message = "Debit and credit foreign isn't balance!!"
                    Me.objFormError.SetError(Me.obj_Selisih_Foreign, message)
                    Throw New Exception(message)
                Else
                    Me.objFormError.SetError(Me.obj_Selisih_Foreign, "")
                End If
            End If

            'cek isi cell di detil Debet
            Dim i As Integer
            Dim cell_acc_id, cell_rekanan_id As DataGridViewCell
            Dim dgv_error, row_error As Boolean
            Me.DgvTrnJurnaldetil_Debit.AllowUserToAddRows = False
            Dim table_account As DataTable = New DataTable
            table_account = Me.tbl_MstAccGrid.Copy

            For i = 0 To Me.DgvTrnJurnaldetil_Debit.Rows.Count - 1
                row_error = False
                message = "Account not yet filled"
                cell_acc_id = Me.DgvTrnJurnaldetil_Debit.Rows(i).Cells("acc_id")
                If cell_acc_id.Value IsNot DBNull.Value Then
                    table_account.DefaultView.RowFilter = String.Format(" acc_id = {0} ", cell_acc_id.Value)

                    If table_account.DefaultView.Count > 0 Then
                        If cell_acc_id.Value = "0" Then
                            cell_acc_id.ErrorText = message
                            row_error = True
                        Else
                            cell_acc_id.ErrorText = ""
                        End If
                    Else
                        cell_acc_id.ErrorText = message
                        row_error = True
                    End If

                Else
                    cell_acc_id.ErrorText = message
                    row_error = True
                End If

                message = "Rekanan not yet filled"
                cell_rekanan_id = Me.DgvTrnJurnaldetil_Debit.Rows(i).Cells("rekanan_id")
                If cell_rekanan_id.Value IsNot DBNull.Value Then
                    If cell_rekanan_id.Value = 0 Then
                        cell_rekanan_id.ErrorText = message
                        row_error = True
                    Else
                        cell_rekanan_id.ErrorText = ""
                    End If
                Else
                    cell_rekanan_id.ErrorText = message
                    row_error = True
                End If


                If row_error Then
                    dgv_error = True
                    Me.DgvTrnJurnaldetil_Debit.Rows(i).DefaultCellStyle.BackColor = Color.Coral
                Else
                    Me.DgvTrnJurnaldetil_Debit.Rows(i).DefaultCellStyle.BackColor = Color.White
                End If

            Next

            'cek isi cell di detil Kredit
            Dim j As Integer
            Dim cell_acc_id1, cell_rekanan_id1 As DataGridViewCell
            Dim row_error1 As Boolean
            Me.DgvTrnJurnaldetil_Credit.AllowUserToAddRows = False
            For j = 0 To Me.DgvTrnJurnaldetil_Credit.Rows.Count - 1
                row_error1 = False
                message = "Account not yet filled"
                cell_acc_id1 = Me.DgvTrnJurnaldetil_Credit.Rows(j).Cells("acc_id")
                If cell_acc_id1.Value IsNot DBNull.Value Then
                    If cell_acc_id1.Value = "0" Then
                        cell_acc_id1.ErrorText = message
                        row_error1 = True
                    Else
                        cell_acc_id1.ErrorText = ""
                    End If
                Else
                    cell_acc_id1.ErrorText = message
                    row_error1 = True
                End If

                message = "Rekanan not yet filled"
                cell_rekanan_id1 = Me.DgvTrnJurnaldetil_Credit.Rows(j).Cells("rekanan_id")
                If cell_rekanan_id1.Value IsNot DBNull.Value Then
                    If cell_rekanan_id1.Value = 0 Then
                        cell_rekanan_id1.ErrorText = message
                        row_error1 = True
                    Else
                        cell_rekanan_id1.ErrorText = ""
                    End If
                Else
                    cell_rekanan_id1.ErrorText = message
                    row_error1 = True
                End If

                If row_error1 Then
                    dgv_error = True
                    Me.DgvTrnJurnaldetil_Credit.Rows(j).DefaultCellStyle.BackColor = Color.Coral
                Else
                    Me.DgvTrnJurnaldetil_Credit.Rows(j).DefaultCellStyle.BackColor = Color.White
                End If

            Next

            Me.DgvTrnJurnaldetil_Debit.AllowUserToAddRows = True
            Me.DgvTrnJurnaldetil_Credit.AllowUserToAddRows = True

            If dgv_error Then
                Throw New Exception("Data have not yet filled!")
            End If
            ' Throw New Exception("Error")
        Catch ex As Exception
            MessageBox.Show(ex.Message, mUiName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return True
        End Try
        Return False
    End Function

#End Region

    Private Sub uiTrnJurnal_JV_Manual_FormAfterOpenRow(ByRef id As Object) Handles Me.FormAfterOpenRow
        Dim selisih_idr, jumlah_idr, selisih_foreign, jumlah_foreign As Decimal

        Me.uiTrnJurnal_JV_Manual_RowCalculate(Me.DgvTrnJurnaldetil_Debit, Me.DgvTrnJurnaldetil_Credit, selisih_idr, jumlah_idr)
        Me.uiTrnJurnal_JV_Manual_RowCalculateForeign(Me.DgvTrnJurnaldetil_Debit, Me.DgvTrnJurnaldetil_Credit, selisih_foreign, jumlah_foreign)

        DATADETIL_OPENED = True

        'set default value dari DgvJurnaldetil
        ' ''Me.uiTrnJurnal_SetDefaultValueOfJurnaldetil_Debit(Me.obj_Strukturunit_id, "strukturunit_id")
        Me.uiTrnJurnal_JV_Manual_SetDefaultValueOfJurnaldetil_Debit(Me.obj_Rekanan_id, "rekanan_id")
        Me.tbl_TrnJurnaldetil_Debit.Columns("rekanan_name").DefaultValue = Me.obj_Rekanan_id.Text
        Me.uiTrnJurnal_JV_Manual_SetDefaultValueOfJurnaldetil_Debit(Me.obj_Currency_id, "currency_id")
        Me.tbl_TrnJurnaldetil_Debit.Columns("jurnaldetil_descr").DefaultValue = Me.obj_Jurnal_descr.Text
        Me.tbl_TrnJurnaldetil_Debit.Columns("jurnaldetil_foreignrate").DefaultValue = Me.obj_Currency_rate.Text

        Me.uiTrnJurnal_JV_Manual_SetDefaultValueOfJurnaldetil_Credit(Me.obj_Currency_id, "currency_id")
        Me.uiTrnJurnal_JV_Manual_SetDefaultValueOfJurnaldetil_Credit(Me.obj_Rekanan_id, "rekanan_id")
        Me.tbl_TrnJurnaldetil_Credit.Columns("rekanan_name").DefaultValue = Me.obj_Rekanan_id.Text
        Me.tbl_TrnJurnaldetil_Credit.Columns("jurnaldetil_foreignrate").DefaultValue = Me.obj_Currency_rate.Text

        Me.DgvTrnJurnaldetil_Credit.Columns("jurnal_id").Visible = False
        Me.DgvTrnJurnaldetil_Debit.Columns("jurnal_id").Visible = False

        ' Cek apakah masih bisa edit data
        ' kriteria locking
        ' - jurnaltype di data tidak sama dengan jurnaltype form ini
        ' - jurnal sudah diposting
        ' - jurnal sudah di response oleh jurnal lain
        Me.DATA_ISLOCKED = Me.uiTrnJurnal_JV_Manual_DataIsLocked()
        If Me.DATA_ISLOCKED = True Then
            Me.tbtnSave.Enabled = False
            Me.tbtnDel.Enabled = False
            Me.tbtnPrint.Enabled = True
            Me.tbtnPrintPreview.Enabled = True
        Else
            Me.tbtnSave.Enabled = True
            Me.tbtnDel.Enabled = True
            Me.tbtnPrint.Enabled = True
            Me.tbtnPrintPreview.Enabled = True
        End If

        Me.tbl_TrnJurnal_Temp.AcceptChanges()
        Me.tbl_TrnJurnaldetil_Debit.AcceptChanges()
        Me.tbl_TrnJurnaldetil_Credit.AcceptChanges()

        Me.obj_Selisih.Text = String.Format("{0:#,##0}", selisih_idr)
        Me.obj_Jumlah.Text = String.Format("{0:#,##0}", jumlah_idr)
        Me.obj_Selisih_Foreign.Text = String.Format("{0:#,##0.00}", selisih_foreign)
        Me.obj_Jumlah_Foreign.Text = String.Format("{0:#,##0.00}", jumlah_foreign)

    End Sub

    Private Sub uiTrnJurnal_JV_Manual_FormAfterSave(ByRef id As Object, ByVal result As uiBase.FormSaveResult) Handles Me.FormAfterSave
        Dim selisih, jumlah As Decimal
        Me.uiTrnJurnal_JV_Manual_RowCalculate(Me.DgvTrnJurnaldetil_Debit, Me.DgvTrnJurnaldetil_Credit, selisih, jumlah)
        Me.obj_Selisih.Text = String.Format("{0:#,##0}", selisih)
        Me.obj_Jumlah.Text = String.Format("{0:#,##0}", jumlah)

        Me.uiTrnJurnal_JV_Manual_RowCalculateForeign(Me.DgvTrnJurnaldetil_Debit, Me.DgvTrnJurnaldetil_Credit, selisih, jumlah)
        Me.obj_Selisih_Foreign.Text = String.Format("{0:#,##0.00}", selisih)
        Me.obj_Jumlah_Foreign.Text = String.Format("{0:#,##0.00}", jumlah)

        Me.DATA_ISLOCKED = Me.uiTrnJurnal_JV_Manual_DataIsLocked()
        If Me.DATA_ISLOCKED = True Then
            Me.tbtnSave.Enabled = False
            Me.tbtnDel.Enabled = False
            Me.tbtnPrint.Enabled = True
            Me.tbtnPrintPreview.Enabled = True
        Else
            Me.tbtnSave.Enabled = True
            Me.tbtnDel.Enabled = True
            Me.tbtnPrint.Enabled = True
            Me.tbtnPrintPreview.Enabled = True
        End If
    End Sub

    Private Sub uiTrnJurnal_JV_Manual_FormBeforeNew() Handles Me.FormBeforeNew
        Me.objFormError.Clear()
        Me.DATA_ISLOCKED = False
        Me.tbtnDel.Enabled = False
        Me.tbtnPrint.Enabled = False
        Me.tbtnPrintPreview.Enabled = False
        Me.btnUpload.Enabled = True
    End Sub

    Private Sub uiTrnJurnal_JV_Manual_FormBeforeOpenRow(ByRef id As Object) Handles Me.FormBeforeOpenRow
        DATADETIL_OPENED = False
    End Sub

    Private Sub uiTrnJurnal_JV_Manual_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Me.Isdevelopment = True Then Me.Form_Load(sender)
    End Sub

    Public Sub Form_Load(ByVal sender As Object)

        Dim objParameters As Collection = New Collection

        'TODO: - Extract Parameter
        '      - Assign parameter
        If Me.Browser IsNot Nothing Then
            objParameters = Me.GetParameterCollection(Me.Parameter)
            Me._CHANNEL = Me.GetValueFromParameter(objParameters, "CHANNEL")
            Me._CHANNEL_CANBE_CHANGED = False 'Me.GetBolValueFromParameter(objParameters, "CHANNELCHANGED")
            Me._CHANNEL_CANBE_BROWSED = False 'Me.GetBolValueFromParameter(objParameters, "CHANNELBROWSED")
            Me._SOURCE = Me.GetValueFromParameter(objParameters, "SOURCE")
            Me._USER_TYPE = Me.GetValueFromParameter(objParameters, "USERTYPE")
        End If

        'Me.DSN = clsUtil.GetDSN


        If (Me.Browser IsNot Nothing And MyBase.Name = _Name) Or (Me.Browser Is Nothing And Application.ProductName <> _ProductName) Then
            Me.DgvTrnJurnal.DataSource = Me.tbl_TrnJurnal
            'Fill Combobox
            'dan fungsi2 startup lainnya....
            Me.uiTrnJurnal_JV_Manual_isBackgroudWorker()
            Me.uiTrnJurnal_JV_Manual_LoadComboBox()
            Me.InitLayoutUI()

            Me.BindingStop()
            Me.BindingStart()

            Me.uiTrnJurnal_JV_Manual_NewData()

            For Each tsItem As ToolStripItem In Me.ToolStrip1.Items
                If tsItem.GetType.ToString = "System.Windows.Forms.ToolStripSeparator" Then
                    tsItem.Enabled = True
                Else
                    tsItem.Enabled = False
                End If
            Next

            Me.chkSearchChannel.Checked = Not Me._CHANNEL_CANBE_CHANGED
            Me.chkSearchChannel.Enabled = Me._CHANNEL_CANBE_BROWSED
            Me.cboSearchChannel.Enabled = Me._CHANNEL_CANBE_BROWSED
            Me.cboSearchChannel.SelectedValue = Me._CHANNEL
            Me.txtSearchSource.ReadOnly = True
            Me.chkSearchSource.Checked = True
            Me.chkSearchSource.Enabled = False

            Me.btnPost.Text = "Posting"
            Me.btnPost.Name = "btnPost"
            Me.btnUnPost.Text = "UnPosting"
            Me.btnUnPost.Name = "btnUnPost"
            Me.btnCopyJurnal.Text = "Copy Jurnal"
            Me.btnCopyJurnal.Name = "btnCopyJurnal"
            Me.btnPost.Visible = False
            Me.btnUnPost.Visible = False
            Me.btnCopyJurnal.Visible = False
            Me.ToolStrip1.Items.Add(Me.btnPost)
            Me.ToolStrip1.Items.Add(Me.btnUnPost)
            Me.ToolStrip1.Items.Add(Me.btnCopyJurnal)
        End If
    End Sub

    Private Sub ftabMain_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ftabMain.SelectedIndexChanged
        Select Case ftabMain.SelectedIndex
            Case 0
                Me.tbtnSave.Enabled = False
                Me.tbtnDel.Enabled = False
                Me.tbtnLoad.Enabled = True
                Me.tbtnQuery.Enabled = True
                Me.ftabMain.TabPages.Item(0).BackColor = Color.Lavender
                Me.ftabMain.TabPages.Item(1).BackColor = Color.White
                Me.btnPost.Visible = False
                Me.btnUnPost.Visible = False
                Me.btnCopyJurnal.Visible = False
                Me.objFormError.Clear()
            Case 1
                Me.tbtnSave.Enabled = True
                Me.tbtnDel.Enabled = True
                Me.tbtnLoad.Enabled = False
                Me.tbtnQuery.Enabled = False
                Me.ftabMain.TabPages.Item(0).BackColor = Color.White
                Me.ftabMain.TabPages.Item(1).BackColor = Color.Lavender

                Me.fTabDataDetil.SelectedIndex = 3
                Me.fTabDataDetil.SelectedIndex = 1
                If Me._USER_TYPE = "SPV" Then
                    Me.btnPost.Visible = True
                Else
                    Me.btnPost.Visible = False
                End If
                Me.btnCopyJurnal.Visible = True
                If Me.isNewButton = True Then
                    Me.uiTrnJurnal_JV_Manual_NewData()
                Else
                    If Me.DgvTrnJurnal.CurrentRow IsNot Nothing Then
                        Me.uiTrnJurnal_JV_Manual_OpenRow(Me.DgvTrnJurnal.CurrentRow.Index)
                    Else
                        Me.uiTrnJurnal_JV_Manual_NewData()
                    End If
                End If
                Me.fTabDataDetil.SelectedIndex = 0
        End Select
    End Sub

    Private Sub fTabDataDetil_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles fTabDataDetil.SelectedIndexChanged
        Dim i, activetab As Byte

        For i = 0 To (Me.fTabDataDetil.TabCount - 1)
            Me.fTabDataDetil.TabPages.Item(i).BackColor = Color.LavenderBlush
        Next
        activetab = Me.fTabDataDetil.SelectedIndex
        Me.fTabDataDetil.TabPages.Item(activetab).BackColor = Color.White
    End Sub

#Region "Event On Dgv Header"
    Private Sub DgvTrnJurnal_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvTrnJurnal.CellDoubleClick
        If e.ColumnIndex < 0 Or e.RowIndex < 0 Then
            Exit Sub
        End If
        If Me.DgvTrnJurnal.CurrentRow IsNot Nothing Then
            Me.ftabMain.SelectedIndex = 1
        End If
    End Sub

    Private Sub DgvTrnJurnal_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DgvTrnJurnal.CellFormatting
        Dim posted As Integer
        Dim obj As DataGridView = sender
        Dim objRow As System.Windows.Forms.DataGridViewRow = obj.Rows(e.RowIndex)
        Try
            posted = CType(objRow.Cells("jurnal_isposted").Value, Integer)
            If posted Then
                objRow.DefaultCellStyle.BackColor = Color.Thistle
            Else
                objRow.DefaultCellStyle.BackColor = Color.White
            End If
        Catch ex As Exception
        End Try
    End Sub
#End Region

#Region "Event On Dgv Credit"
    Private Sub DgvTrnJurnaldetil_Credit_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvTrnJurnaldetil_Credit.CellClick
        If e.RowIndex >= 0 Then
            Select Case e.ColumnIndex
                Case Me.DgvTrnJurnaldetil_Credit.Columns("select_budget").Index
                    Dim dlg As dlgSearch = New dlgSearch()
                    Dim retData As Collection
                    Dim retObj As Object
                    Dim budget_id As Decimal
                    Dim budget_name As String

                    retObj = dlg.OpenDialog(Me, Me.tbl_TrnBudgetGrid, "budget")
                    If retObj IsNot Nothing Then
                        retData = CType(retObj, Collection)
                        budget_id = CType(retData.Item("retId"), Decimal)
                        budget_name = CType(retData.Item("retName"), String)
                        Me.DgvTrnJurnaldetil_Credit.Rows(e.RowIndex).Cells("budget_id").Value = budget_id
                        Me.DgvTrnJurnaldetil_Credit.Rows(e.RowIndex).Cells("budget_name").Value = budget_name
                    End If

                Case Me.DgvTrnJurnaldetil_Credit.Columns("select_budget_detil").Index
                    Dim dlg As dlgSearch = New dlgSearch()
                    Dim retData As Collection
                    Dim retObj As Object
                    Dim budgetdetil_id As Decimal
                    Dim budgetdetil_name As String

                    Me.tbl_TrnBudgetdetilGrid.DefaultView.RowFilter = String.Format(" budget_id = '{0}'", Me.DgvTrnJurnaldetil_Credit.Rows(e.RowIndex).Cells("budget_id").Value)
                    retObj = dlg.OpenDialog(Me, Me.tbl_TrnBudgetdetilGrid.DefaultView.ToTable, "budgetdetil")
                    If retObj IsNot Nothing Then
                        retData = CType(retObj, Collection)
                        budgetdetil_id = CType(retData.Item("retId"), Decimal)
                        budgetdetil_name = CType(retData.Item("retName"), String)
                        Me.DgvTrnJurnaldetil_Credit.Rows(e.RowIndex).Cells("budgetdetil_id").Value = budgetdetil_id
                        Me.DgvTrnJurnaldetil_Credit.Rows(e.RowIndex).Cells("budgetdetil_name").Value = budgetdetil_name
                    End If
                Case Me.DgvTrnJurnaldetil_Debit.Columns("select_rekanan").Index
                    Dim dlg As dlgSearch = New dlgSearch()
                    Dim retData As Collection
                    Dim retObj As Object
                    Dim rekanan_id As Decimal
                    Dim rekanan_name As String

                    retObj = dlg.OpenDialog(Me, Me.tbl_MstRekananGrid, "rekanan")
                    If retObj IsNot Nothing Then
                        retData = CType(retObj, Collection)
                        rekanan_id = CType(retData.Item("retId"), Decimal)
                        rekanan_name = CType(retData.Item("retName"), String)
                        Me.DgvTrnJurnaldetil_Credit.Rows(e.RowIndex).Cells("rekanan_id").Value = rekanan_id
                        Me.DgvTrnJurnaldetil_Credit.Rows(e.RowIndex).Cells("rekanan_name").Value = rekanan_name
                    End If
            End Select
        End If
    End Sub

    Private Sub DgvTrnJurnaldetil_Credit_CellValidated(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvTrnJurnaldetil_Credit.CellValidated
        Dim obj As DataGridView = sender
        Dim selisih, jumlah As Decimal
        Dim colName As String = obj.Columns(e.ColumnIndex).Name
        Dim table_acc_bank As DataTable = New DataTable

        If obj.Rows(e.RowIndex).IsNewRow = True Then
            Exit Sub
        End If

        If colName = "jurnaldetil_foreign" Or colName = "jurnaldetil_foreignrate" Then
            If obj.Rows(e.RowIndex).Cells("currency_id").Value = 1 Then
                Me.uiTrnJurnal_JV_Manual_RowCalculateForeignIDR(Me.DgvTrnJurnaldetil_Debit, Me.DgvTrnJurnaldetil_Credit, selisih, jumlah)
                If colName = "jurnaldetil_foreign" Then
                    obj.Rows(e.RowIndex).Cells("jurnaldetil_foreign").Value = Math.Round(obj.Rows(e.RowIndex).Cells("jurnaldetil_foreign").Value, 0, MidpointRounding.AwayFromZero)
                End If
            Else
                Me.uiTrnJurnal_JV_Manual_RowCalculateForeign(Me.DgvTrnJurnaldetil_Debit, Me.DgvTrnJurnaldetil_Credit, selisih, jumlah)
            End If
            Me.obj_Selisih_Foreign.Text = String.Format("{0:#,##0.00}", selisih)
            Me.obj_Jumlah_Foreign.Text = String.Format("{0:#,##0.00}", jumlah)
            If obj.Rows(e.RowIndex).Cells("acc_id").Value <> akunKeuntunganSelisihKursPajak Then
                Me.uiTrnJurnal_JV_Manual_RowCalcIDR(obj, obj.Rows(e.RowIndex).Cells("jurnaldetil_idr"), obj.Rows(e.RowIndex).Cells("jurnaldetil_foreign"), obj.Rows(e.RowIndex).Cells("jurnaldetil_foreignrate"))
            End If
        End If

        If obj.Columns(e.ColumnIndex).Name = "jurnaldetil_idr" Then
            Me.uiTrnJurnal_JV_Manual_RowCalculate(Me.DgvTrnJurnaldetil_Debit, Me.DgvTrnJurnaldetil_Credit, selisih, jumlah)
            Me.obj_Selisih.Text = String.Format("{0:#,##0}", selisih)
            Me.obj_Jumlah.Text = String.Format("{0:#,##0}", jumlah)
        End If

    End Sub

    Private Sub DgvTrnJurnaldetil_Credit_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvTrnJurnaldetil_Credit.CellValueChanged
        Dim obj As DataGridView = sender
        Dim selisih, jumlah As Decimal
        Dim colName As String = obj.Columns(e.ColumnIndex).Name
        Dim table_acc_bank As DataTable = New DataTable

        If colName = "jurnaldetil_foreign" Or colName = "jurnaldetil_foreignrate" Then
            If obj.Rows(e.RowIndex).Cells("currency_id").Value = 1 Then
                Me.uiTrnJurnal_JV_Manual_RowCalculateForeignIDR(Me.DgvTrnJurnaldetil_Debit, Me.DgvTrnJurnaldetil_Credit, selisih, jumlah)
            Else
                Me.uiTrnJurnal_JV_Manual_RowCalculateForeign(Me.DgvTrnJurnaldetil_Debit, Me.DgvTrnJurnaldetil_Credit, selisih, jumlah)
            End If
            Me.obj_Selisih_Foreign.Text = String.Format("{0:#,##0.00}", selisih)
            Me.obj_Jumlah_Foreign.Text = String.Format("{0:#,##0.00}", jumlah)
            If obj.Rows(e.RowIndex).Cells("acc_id").Value <> akunKeuntunganSelisihKursPajak Then
                Me.uiTrnJurnal_JV_Manual_RowCalcIDR(obj, obj.Rows(e.RowIndex).Cells("jurnaldetil_idr"), obj.Rows(e.RowIndex).Cells("jurnaldetil_foreign"), obj.Rows(e.RowIndex).Cells("jurnaldetil_foreignrate"))
            End If
        End If

        If obj.Columns(e.ColumnIndex).Name = "jurnaldetil_idr" Then
            Me.uiTrnJurnal_JV_Manual_RowCalculate(Me.DgvTrnJurnaldetil_Debit, Me.DgvTrnJurnaldetil_Credit, selisih, jumlah)
            Me.obj_Selisih.Text = String.Format("{0:#,##0}", selisih)
            Me.obj_Jumlah.Text = String.Format("{0:#,##0}", jumlah)
        End If
        If obj.Columns(e.ColumnIndex).Name = "budget_id" Then
            Try
                obj.Rows(e.RowIndex).Cells("budget_name").Value = clsUtil.GetDataFromDatatable(Me.tbl_TrnBudgetGrid, "budget_id", "budget_name", obj.Rows(e.RowIndex).Cells("budget_id").Value)
            Catch ex As Exception

            End Try
        End If

        If obj.Columns(e.ColumnIndex).Name = "budgetdetil_id" Then
            Try
                obj.Rows(e.RowIndex).Cells("budgetdetil_name").Value = clsUtil.GetDataFromDatatable(Me.tbl_TrnBudgetdetilGrid, "budgetdetil_id", "budgetdetil_desc", obj.Rows(e.RowIndex).Cells("budgetdetil_id").Value)
            Catch ex As Exception

            End Try
        End If

        If obj.Columns(e.ColumnIndex).Name = "acc_id" Then
            Try
                If (obj.Rows(e.RowIndex).Cells("acc_id").Value <> akunKerugianSelisihKursPajak) And (obj.Rows(e.RowIndex).Cells("acc_id").Value <> akunKeuntunganSelisihKursPajak) And _
                     (obj.Rows(e.RowIndex).Cells("acc_id").Value <> akunKerugianSelisihKurs) And (obj.Rows(e.RowIndex).Cells("acc_id").Value <> akunKeuntunganSelisihKurs) Then

                    obj.Rows(e.RowIndex).Cells("jurnaldetil_foreign").Value = 0
                    obj.Rows(e.RowIndex).Cells("jurnaldetil_foreign").ReadOnly = False
                    obj.Rows(e.RowIndex).Cells("jurnaldetil_foreign").Style.BackColor = Color.White
                    obj.Rows(e.RowIndex).Cells("jurnaldetil_foreignrate").Value = 0
                    obj.Rows(e.RowIndex).Cells("jurnaldetil_foreignrate").ReadOnly = False
                    obj.Rows(e.RowIndex).Cells("jurnaldetil_foreignrate").Style.BackColor = Color.White
                    obj.Rows(e.RowIndex).Cells("jurnaldetil_idr").ReadOnly = True
                    obj.Rows(e.RowIndex).Cells("jurnaldetil_idr").Style.BackColor = Color.LightYellow
                Else
                    obj.Rows(e.RowIndex).Cells("jurnaldetil_foreign").Value = 0
                    obj.Rows(e.RowIndex).Cells("jurnaldetil_foreign").ReadOnly = True
                    obj.Rows(e.RowIndex).Cells("jurnaldetil_foreign").Style.BackColor = Color.LightYellow
                    obj.Rows(e.RowIndex).Cells("jurnaldetil_foreignrate").Value = 0
                    obj.Rows(e.RowIndex).Cells("jurnaldetil_foreignrate").ReadOnly = True
                    obj.Rows(e.RowIndex).Cells("jurnaldetil_foreignrate").Style.BackColor = Color.LightYellow
                    obj.Rows(e.RowIndex).Cells("jurnaldetil_idr").ReadOnly = False
                    obj.Rows(e.RowIndex).Cells("jurnaldetil_idr").Style.BackColor = Color.White
                End If
            Catch ex As Exception

            End Try
        End If

    End Sub

    Private Sub DgvTrnJurnaldetil_Credit_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DgvTrnJurnaldetil_Credit.EditingControlShowing
        Dim combo As ComboBox
        If e.Control.GetType.Name = GetType(DataGridViewComboBoxEditingControl).Name Then
            combo = CType(e.Control, ComboBox)
            combo.DropDownStyle = ComboBoxStyle.DropDown
            combo.AutoCompleteSource = AutoCompleteSource.ListItems
            combo.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        End If
    End Sub

    Private Sub DgvTrnJurnaldetil_Credit_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles DgvTrnJurnaldetil_Credit.RowsRemoved
        Dim obj As DataGridView = sender
        Dim selisih, jumlah As Decimal
        If Me.ftabMain.SelectedIndex = 1 And Me.fTabDataDetil.SelectedIndex = 0 And DATADETIL_OPENED = True Then
            Me.uiTrnJurnal_JV_Manual_RowCalculate(Me.DgvTrnJurnaldetil_Debit, Me.DgvTrnJurnaldetil_Credit, selisih, jumlah)
            Me.obj_Selisih.Text = String.Format("{0:#,##0}", selisih)
            Me.obj_Jumlah.Text = String.Format("{0:#,##0}", jumlah)

            If Me.obj_Currency_id.SelectedValue = 1 Then
                Me.uiTrnJurnal_JV_Manual_RowCalculateForeignIDR(Me.DgvTrnJurnaldetil_Debit, Me.DgvTrnJurnaldetil_Credit, selisih, jumlah)
            Else
                Me.uiTrnJurnal_JV_Manual_RowCalculateForeign(Me.DgvTrnJurnaldetil_Debit, Me.DgvTrnJurnaldetil_Credit, selisih, jumlah)
            End If

            Me.obj_Selisih_Foreign.Text = String.Format("{0:#,##0.00}", selisih)
            Me.obj_Jumlah_Foreign.Text = String.Format("{0:#,##0.00}", jumlah)

        End If
    End Sub

    Private Sub DgvTrnJurnaldetil_Credit_UserDeletedRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles DgvTrnJurnaldetil_Credit.UserDeletedRow
        Dim obj As DataGridView = sender
        Dim selisih, jumlah As Decimal
        Me.uiTrnJurnal_JV_Manual_RowCalculate(Me.DgvTrnJurnaldetil_Debit, Me.DgvTrnJurnaldetil_Credit, selisih, jumlah)
        Me.obj_Selisih.Text = String.Format("{0:#,##0}", selisih)
        Me.obj_Jumlah.Text = String.Format("{0:#,##0}", jumlah)

        If Me.obj_Currency_id.SelectedValue = 1 Then
            Me.uiTrnJurnal_JV_Manual_RowCalculateForeignIDR(Me.DgvTrnJurnaldetil_Debit, Me.DgvTrnJurnaldetil_Credit, selisih, jumlah)
        Else
            Me.uiTrnJurnal_JV_Manual_RowCalculateForeign(Me.DgvTrnJurnaldetil_Debit, Me.DgvTrnJurnaldetil_Credit, selisih, jumlah)
        End If

        Me.obj_Selisih_Foreign.Text = String.Format("{0:#,##0.00}", selisih)
        Me.obj_Jumlah_Foreign.Text = String.Format("{0:#,##0.00}", jumlah)

    End Sub
#End Region

#Region "Event On Dgv Debit"
    Private Sub DgvTrnJurnaldetil_Debit_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvTrnJurnaldetil_Debit.CellClick
        If e.RowIndex >= 0 Then
            Select Case e.ColumnIndex
                Case Me.DgvTrnJurnaldetil_Debit.Columns("select_budget").Index
                    Dim dlg As dlgSearch = New dlgSearch()
                    Dim retData As Collection
                    Dim retObj As Object
                    Dim budget_id As Decimal
                    Dim budget_name As String

                    retObj = dlg.OpenDialog(Me, Me.tbl_TrnBudgetGrid, "budget")
                    If retObj IsNot Nothing Then
                        retData = CType(retObj, Collection)
                        budget_id = CType(retData.Item("retId"), Decimal)
                        budget_name = CType(retData.Item("retName"), String)
                        Me.DgvTrnJurnaldetil_Debit.Rows(e.RowIndex).Cells("budget_id").Value = budget_id
                        Me.DgvTrnJurnaldetil_Debit.Rows(e.RowIndex).Cells("budget_name").Value = budget_name
                    End If

                Case Me.DgvTrnJurnaldetil_Debit.Columns("select_budget_detil").Index
                    Dim dlg As dlgSearch = New dlgSearch()
                    Dim retData As Collection
                    Dim retObj As Object
                    Dim budgetdetil_id As Decimal
                    Dim budgetdetil_name As String

                    Me.tbl_TrnBudgetdetilGrid.DefaultView.RowFilter = String.Format(" budget_id = '{0}'", Me.DgvTrnJurnaldetil_Debit.Rows(e.RowIndex).Cells("budget_id").Value)
                    retObj = dlg.OpenDialog(Me, Me.tbl_TrnBudgetdetilGrid.DefaultView.ToTable, "budgetdetil")
                    If retObj IsNot Nothing Then
                        retData = CType(retObj, Collection)
                        budgetdetil_id = CType(retData.Item("retId"), Decimal)
                        budgetdetil_name = CType(retData.Item("retName"), String)
                        Me.DgvTrnJurnaldetil_Debit.Rows(e.RowIndex).Cells("budgetdetil_id").Value = budgetdetil_id
                        Me.DgvTrnJurnaldetil_Debit.Rows(e.RowIndex).Cells("budgetdetil_name").Value = budgetdetil_name
                    End If
                Case Me.DgvTrnJurnaldetil_Debit.Columns("select_rekanan").Index
                    Dim dlg As dlgSearch = New dlgSearch()
                    Dim retData As Collection
                    Dim retObj As Object
                    Dim rekanan_id As Decimal
                    Dim rekanan_name As String

                    retObj = dlg.OpenDialog(Me, Me.tbl_MstRekananGrid, "rekanan")
                    If retObj IsNot Nothing Then
                        retData = CType(retObj, Collection)
                        rekanan_id = CType(retData.Item("retId"), Decimal)
                        rekanan_name = CType(retData.Item("retName"), String)
                        Me.DgvTrnJurnaldetil_Debit.Rows(e.RowIndex).Cells("rekanan_id").Value = rekanan_id
                        Me.DgvTrnJurnaldetil_Debit.Rows(e.RowIndex).Cells("rekanan_name").Value = rekanan_name
                    End If
            End Select
        End If
    End Sub

    Private Sub DgvTrnJurnaldetil_Debit_CellValidated(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvTrnJurnaldetil_Debit.CellValidated
        Dim obj As DataGridView = sender
        Dim selisih, jumlah As Decimal
        Dim colName As String = obj.Columns(e.ColumnIndex).Name

        If obj.Rows(e.RowIndex).IsNewRow = True Then
            Exit Sub
        End If


        If colName = "jurnaldetil_foreign" Or colName = "jurnaldetil_foreignrate" Then
            If obj.Rows(e.RowIndex).Cells("currency_id").Value = 1 Then
                Me.uiTrnJurnal_JV_Manual_RowCalculateForeignIDR(Me.DgvTrnJurnaldetil_Debit, Me.DgvTrnJurnaldetil_Credit, selisih, jumlah)
                If colName = "jurnaldetil_foreign" Then
                    obj.Rows(e.RowIndex).Cells("jurnaldetil_foreign").Value = Math.Round(obj.Rows(e.RowIndex).Cells("jurnaldetil_foreign").Value, 0, MidpointRounding.AwayFromZero)
                End If
            Else
                Me.uiTrnJurnal_JV_Manual_RowCalculateForeign(Me.DgvTrnJurnaldetil_Debit, Me.DgvTrnJurnaldetil_Credit, selisih, jumlah)
            End If
            Me.obj_Selisih_Foreign.Text = String.Format("{0:#,##0.00}", selisih)
            Me.obj_Jumlah_Foreign.Text = String.Format("{0:#,##0.00}", jumlah)

            Me.uiTrnJurnal_JV_Manual_RowCalcIDR(obj, obj.Rows(e.RowIndex).Cells("jurnaldetil_idr"), obj.Rows(e.RowIndex).Cells("jurnaldetil_foreign"), obj.Rows(e.RowIndex).Cells("jurnaldetil_foreignrate"))
        End If

        If obj.Columns(e.ColumnIndex).Name = "jurnaldetil_idr" Then
            Me.uiTrnJurnal_JV_Manual_RowCalculate(Me.DgvTrnJurnaldetil_Debit, Me.DgvTrnJurnaldetil_Credit, selisih, jumlah)
            Me.obj_Selisih.Text = String.Format("{0:#,##0}", selisih)
            Me.obj_Jumlah.Text = String.Format("{0:#,##0}", jumlah)
        End If
    End Sub

    Private Sub DgvTrnJurnaldetil_Debit_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvTrnJurnaldetil_Debit.CellValueChanged
        Dim obj As DataGridView = sender
        Dim selisih, jumlah As Decimal
        Dim colName As String = obj.Columns(e.ColumnIndex).Name

        If colName = "jurnaldetil_foreign" Or colName = "jurnaldetil_foreignrate" Then
            If obj.Rows(e.RowIndex).Cells("currency_id").Value = 1 Then
                Me.uiTrnJurnal_JV_Manual_RowCalculateForeignIDR(Me.DgvTrnJurnaldetil_Debit, Me.DgvTrnJurnaldetil_Credit, selisih, jumlah)
            Else
                Me.uiTrnJurnal_JV_Manual_RowCalculateForeign(Me.DgvTrnJurnaldetil_Debit, Me.DgvTrnJurnaldetil_Credit, selisih, jumlah)
            End If
            Me.obj_Selisih_Foreign.Text = String.Format("{0:#,##0.00}", selisih)
            Me.obj_Jumlah_Foreign.Text = String.Format("{0:#,##0.00}", jumlah)

            Me.uiTrnJurnal_JV_Manual_RowCalcIDR(obj, obj.Rows(e.RowIndex).Cells("jurnaldetil_idr"), obj.Rows(e.RowIndex).Cells("jurnaldetil_foreign"), obj.Rows(e.RowIndex).Cells("jurnaldetil_foreignrate"))
        End If

        If obj.Columns(e.ColumnIndex).Name = "jurnaldetil_idr" Then
            Me.uiTrnJurnal_JV_Manual_RowCalculate(Me.DgvTrnJurnaldetil_Debit, Me.DgvTrnJurnaldetil_Credit, selisih, jumlah)
            Me.obj_Selisih.Text = String.Format("{0:#,##0}", selisih)
            Me.obj_Jumlah.Text = String.Format("{0:#,##0}", jumlah)
        End If

        If obj.Columns(e.ColumnIndex).Name = "budget_id" Then
            Try
                obj.Rows(e.RowIndex).Cells("budget_name").Value = clsUtil.GetDataFromDatatable(Me.tbl_TrnBudgetGrid, "budget_id", "budget_name", obj.Rows(e.RowIndex).Cells("budget_id").Value)
            Catch ex As Exception

            End Try
        End If

        If obj.Columns(e.ColumnIndex).Name = "budgetdetil_id" Then
            Try
                obj.Rows(e.RowIndex).Cells("budgetdetil_name").Value = clsUtil.GetDataFromDatatable(Me.tbl_TrnBudgetdetilGrid, "budgetdetil_id", "budgetdetil_desc", obj.Rows(e.RowIndex).Cells("budgetdetil_id").Value)
            Catch ex As Exception

            End Try
        End If

        If obj.Columns(e.ColumnIndex).Name = "acc_id" Then
            Try
                If (obj.Rows(e.RowIndex).Cells("acc_id").Value <> akunKerugianSelisihKursPajak) And (obj.Rows(e.RowIndex).Cells("acc_id").Value <> akunKeuntunganSelisihKursPajak) And _
                     (obj.Rows(e.RowIndex).Cells("acc_id").Value <> akunKerugianSelisihKurs) And (obj.Rows(e.RowIndex).Cells("acc_id").Value <> akunKeuntunganSelisihKurs) Then

                    obj.Rows(e.RowIndex).Cells("jurnaldetil_foreign").Value = 0
                    obj.Rows(e.RowIndex).Cells("jurnaldetil_foreign").ReadOnly = False
                    obj.Rows(e.RowIndex).Cells("jurnaldetil_foreign").Style.BackColor = Color.White
                    obj.Rows(e.RowIndex).Cells("jurnaldetil_foreignrate").Value = 0
                    obj.Rows(e.RowIndex).Cells("jurnaldetil_foreignrate").ReadOnly = False
                    obj.Rows(e.RowIndex).Cells("jurnaldetil_foreignrate").Style.BackColor = Color.White
                    obj.Rows(e.RowIndex).Cells("jurnaldetil_idr").ReadOnly = True
                    obj.Rows(e.RowIndex).Cells("jurnaldetil_idr").Style.BackColor = Color.LightYellow
                Else
                    obj.Rows(e.RowIndex).Cells("jurnaldetil_foreign").Value = 0
                    obj.Rows(e.RowIndex).Cells("jurnaldetil_foreign").ReadOnly = True
                    obj.Rows(e.RowIndex).Cells("jurnaldetil_foreign").Style.BackColor = Color.LightYellow
                    obj.Rows(e.RowIndex).Cells("jurnaldetil_foreignrate").Value = 0
                    obj.Rows(e.RowIndex).Cells("jurnaldetil_foreignrate").ReadOnly = True
                    obj.Rows(e.RowIndex).Cells("jurnaldetil_foreignrate").Style.BackColor = Color.LightYellow
                    obj.Rows(e.RowIndex).Cells("jurnaldetil_idr").ReadOnly = False
                    obj.Rows(e.RowIndex).Cells("jurnaldetil_idr").Style.BackColor = Color.White
                End If
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub DgvTrnJurnaldetil_Debit_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DgvTrnJurnaldetil_Debit.EditingControlShowing
        Dim combo As ComboBox
        If e.Control.GetType.Name = GetType(DataGridViewComboBoxEditingControl).Name Then
            combo = CType(e.Control, ComboBox)
            combo.DropDownStyle = ComboBoxStyle.DropDown
            combo.AutoCompleteSource = AutoCompleteSource.ListItems
            combo.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        End If
    End Sub

    Private Sub DgvTrnJurnaldetil_Debit_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles DgvTrnJurnaldetil_Debit.RowsRemoved
        Dim obj As DataGridView = sender
        Dim selisih, jumlah As Decimal
        If Me.ftabMain.SelectedIndex = 1 And Me.fTabDataDetil.SelectedIndex = 0 And DATADETIL_OPENED = True Then
            Me.uiTrnJurnal_JV_Manual_RowCalculate(Me.DgvTrnJurnaldetil_Debit, Me.DgvTrnJurnaldetil_Credit, selisih, jumlah)
            Me.obj_Selisih.Text = String.Format("{0:#,##0}", selisih)
            Me.obj_Jumlah.Text = String.Format("{0:#,##0}", jumlah)

            If Me.obj_Currency_id.SelectedValue = 1 Then
                Me.uiTrnJurnal_JV_Manual_RowCalculateForeignIDR(Me.DgvTrnJurnaldetil_Debit, Me.DgvTrnJurnaldetil_Credit, selisih, jumlah)
            Else
                Me.uiTrnJurnal_JV_Manual_RowCalculateForeign(Me.DgvTrnJurnaldetil_Debit, Me.DgvTrnJurnaldetil_Credit, selisih, jumlah)
            End If
            Me.obj_Selisih_Foreign.Text = String.Format("{0:#,##0.00}", selisih)
            Me.obj_Jumlah_Foreign.Text = String.Format("{0:#,##0.00}", jumlah)
        End If
    End Sub

    Private Sub DgvTrnJurnaldetil_Debit_UserDeletedRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles DgvTrnJurnaldetil_Debit.UserDeletedRow
        Dim obj As DataGridView = sender
        Dim selisih, jumlah As Decimal
        Me.uiTrnJurnal_JV_Manual_RowCalculate(Me.DgvTrnJurnaldetil_Debit, Me.DgvTrnJurnaldetil_Credit, selisih, jumlah)
        Me.obj_Selisih.Text = String.Format("{0:#,##0}", selisih)
        Me.obj_Jumlah.Text = String.Format("{0:#,##0}", jumlah)
        If Me.obj_Currency_id.SelectedValue = 1 Then
            Me.uiTrnJurnal_JV_Manual_RowCalculateForeignIDR(Me.DgvTrnJurnaldetil_Debit, Me.DgvTrnJurnaldetil_Credit, selisih, jumlah)
        Else
            Me.uiTrnJurnal_JV_Manual_RowCalculateForeign(Me.DgvTrnJurnaldetil_Debit, Me.DgvTrnJurnaldetil_Credit, selisih, jumlah)
        End If
        Me.obj_Selisih_Foreign.Text = String.Format("{0:#,##0.00}", selisih)
        Me.obj_Jumlah_Foreign.Text = String.Format("{0:#,##0.00}", jumlah)
    End Sub

    Private Sub DgvTrnJurnaldetil_Debit_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles DgvTrnJurnaldetil_Debit.UserDeletingRow
        Dim obj As DataGridView = sender
        Dim selisih, jumlah As Decimal

        If e.Row.Index < 0 Then Exit Sub

        Me.uiTrnJurnal_JV_Manual_RowCalculate(Me.DgvTrnJurnaldetil_Debit, Me.DgvTrnJurnaldetil_Credit, selisih, jumlah)
        Me.obj_Selisih.Text = String.Format("{0:#,##0}", selisih)
        Me.obj_Jumlah.Text = String.Format("{0:#,##0}", jumlah)

        If Me.obj_Currency_id.SelectedValue = 1 Then
            Me.uiTrnJurnal_JV_Manual_RowCalculateForeignIDR(Me.DgvTrnJurnaldetil_Debit, Me.DgvTrnJurnaldetil_Credit, selisih, jumlah)
        Else
            Me.uiTrnJurnal_JV_Manual_RowCalculateForeign(Me.DgvTrnJurnaldetil_Debit, Me.DgvTrnJurnaldetil_Credit, selisih, jumlah)
        End If
        Me.obj_Selisih_Foreign.Text = String.Format("{0:#,##0.00}", selisih)
        Me.obj_Jumlah_Foreign.Text = String.Format("{0:#,##0.00}", jumlah)

    End Sub
#End Region

#Region " Print "
    Private Function uiTrnJurnal_JV_Manual_Print() As Boolean
        Dim i As Integer

        If Me.DgvTrnJurnal.SelectedRows.Count <= 0 Then
            MsgBox("Belum ada data yang dipilih")
            Exit Function
        End If

        For i = 0 To Me.DgvTrnJurnal.SelectedRows.Count - 1
            Dim objRdsH As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
            Dim objReportH As Microsoft.Reporting.WinForms.LocalReport = New Microsoft.Reporting.WinForms.LocalReport
            Dim objRdsD As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
            Dim objReportD As Microsoft.Reporting.WinForms.LocalReport = New Microsoft.Reporting.WinForms.LocalReport
            Dim objDatalistHeader As ArrayList = New ArrayList()
            Dim objReportViewer As Microsoft.Reporting.WinForms.ReportViewer = New Microsoft.Reporting.WinForms.ReportViewer

            Me.tbl_Print.Clear()
            Me.DataFill(Me.tbl_Print, "act_RptJurnal_SelectHeader", String.Format("jurnal_id = '{0}' AND channel_id = '{1}'", Me.DgvTrnJurnal.SelectedRows.Item(i).Cells("jurnal_id").Value, Me.DgvTrnJurnal.SelectedRows.Item(i).Cells("channel_id").Value))

            'Dim parRptImageURL As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("imageURL", Me.SptServer & "/Solutions/images/" & Me._CHANNEL & ".jpg")
            '============ tambahan by ari prasasti <parameter global> 20 April 2012
            Dim dt As DataTable = New DataTable

            dt.Clear()

            clsUtil.DataFill(Me.DSN, dt, "act_select_channel", String.Format(" channel_id = '{0}'", Me._CHANNEL))

            'fill variabel global
            Dim fileUrl As String = CStr(dt.Rows(0).Item("channel_domainname"))

            '---------------tambahan buat insosys baru 2012-- 19 April 2012---------------
            fileUrl = fileUrl.Replace("\", "/")
            fileUrl = "file:///" & fileUrl & "/services/live/solutions/images/" & Me._CHANNEL & ".jpg"
            '---------------------------------------------------------------

            Dim parRptImageURL As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("imageURL", fileUrl)

            '===end tambahan
            Dim parRptChannel_namereport As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("channel_name", CStr(Me.tbl_Print.Rows(0).Item("channel_name")))
            Dim parRptChannel_address As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("channel_address", CStr(Me.tbl_Print.Rows(0).Item("channel_address")))

            objDatalistHeader = Me.GenerateDataHeader(Me.DgvTrnJurnal.SelectedRows.Item(i).Cells("jurnal_id").Value, Me.DgvTrnJurnal.SelectedRows.Item(i).Cells("channel_id").Value)

            Dim parRptJurnalID As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("jurnal_id", parJurnal_id)
            Dim parRptJurnalTypeID As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("jurnaltype_id", Me.parJurnalType_id)
            Dim parRptJurnal_Source As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("jurnal_source", Me.parJurnal_Source)
            Dim parRptJurnal_BookDate As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("jurnal_bookdate", Me.parJurnal_BookDate)
            Dim parRptPeriodeName As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("periode_name", Me.parPeriode_Name)
            Dim parRptCurrencyName As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("currency_name", Me.parCurrency_Name)
            Dim parRptJurnal_AmountForeign As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("jurnal_amountforeign", Me.parJurnal_AmountForeign)
            Dim parRptRekananName As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("rekanan_name", Me.parRekanan_Name)
            Dim parRptJurnal_Desc As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("jurnal_descr", Me.parJurnal_Desc)

            objRdsH.Name = "NEWACT_AP_DataSource_clsRptJurnal_Header"
            objRdsH.Value = objDatalistHeader

            objReportH.ReportEmbeddedResource = "NEWACT_AP.rptJurnal_OC_Header.rdlc"
            objReportH.DataSources.Add(objRdsH)
            objReportH.EnableExternalImages = True

            objReportH.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter() {parRptImageURL, parRptChannel_namereport, parRptChannel_address, parRptJurnalID, _
            parRptJurnalTypeID, parRptJurnal_Source, parRptJurnal_BookDate, parRptPeriodeName, _
            parRptCurrencyName, parRptCurrencyName, parRptJurnal_AmountForeign, parRptRekananName, _
            parRptJurnal_Desc})

            AddHandler objReportH.SubreportProcessing, AddressOf SubreportProcessing

            Using report As New clsQuickPrint(objReportH)
                report.Print()
            End Using

            'Export(objReportH)
            'm_currentPageIndex = 0
            'Print()
        Next
    End Function

    Private Function GenerateDataHeader(ByVal jurnal_id_temp As String, ByVal channel_id_temp As String) As ArrayList
        Dim objDatalistHeader As ArrayList = New ArrayList()
        Dim oDataFiller As New clsDataFiller(Me.DSN)

        objPrintHeader = New DataSource.clsRptJurnal_Header()
        With objPrintHeader
            .jurnal_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("jurnal_id"), String.Empty)
            Me.parJurnal_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("jurnal_id"), String.Empty)
            Me.parJurnalType_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("jurnaltype_id"), String.Empty)
            Me.parJurnal_Source = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("jurnal_source"), String.Empty)
            Me.parJurnal_BookDate = clsUtil.IsDbNull(Format(Me.tbl_Print.Rows(0).Item("jurnal_bookdate"), "dd/MMM/yyyy"), Now.Date)
            Me.parPeriode_Name = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("periode_name"), String.Empty)
            Me.parJurnal_Desc = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("jurnal_descr"), String.Empty)
            Me.parRekanan_Name = clsUtil.IsDbNull(Trim(Me.tbl_Print.Rows(0).Item("rekanan_name")), String.Empty)
            Me.parCurrency_Name = clsUtil.IsDbNull(Trim(Me.tbl_Print.Rows(0).Item("currency_name")), String.Empty)
            Me.parJurnal_AmountForeign = clsUtil.IsDbNull(Format(Me.tbl_Print.Rows(0).Item("jurnal_amountforeign"), "#,##0"), 0)
            .jurnal_createby = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("created_by_name"), String.Empty)
            .jurnal_createdate = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("jurnal_iscreatedate"), Now.Date)
            .jurnal_postby = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("post_by_name"), String.Empty)
            Me.tbl_PrintDetil.Clear()
            Me.DataFill(Me.tbl_PrintDetil, "act_RptJurnal_SelectDetil", String.Format("jurnal_id='{0}' AND channel_id = '{1}' ORDER BY A.jurnaldetil_foreign DESC", jurnal_id_temp, channel_id_temp))
            GenerateDataDetail()
        End With
        objDatalistHeader.Add(objPrintHeader)

        Return objDatalistHeader
    End Function

    Private Function GenerateDataDetail() As ArrayList
        'Dim i As Integer

        'objDatalistDetil = New ArrayList()
        'For i = 0 To Me.tbl_PrintDetil.Rows.Count - 1
        '    objPrintDetil = New DataSource.clsRptJurnal_Detil(Me.DSN)
        '    With objPrintDetil
        '        .jurnal_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("jurnal_id"), String.Empty)
        '        .acc_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("acc_id"), String.Empty)
        '        .acc_name = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("acc_name"), String.Empty)
        '        .rekanan_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("rekanan_id"), String.Empty)
        '        .rekanan_name = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("rekanan_name"), String.Empty)
        '        .jurnaldetil_descr = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("jurnaldetil_descr"), String.Empty)
        '        .ref_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("ref_id"), String.Empty)
        '        If .acc_id = akun8002000 Or .acc_id = akun8500015 Then
        '            .jurnaldetil_foreignrate = 0
        '        Else
        '            .jurnaldetil_foreignrate = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("jurnaldetil_foreignrate"), 0)
        '        End If
        '        .jurnaldetil_foreign = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("jurnaldetil_foreign"), 0)
        '        .jurnaldetil_idr = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("jurnaldetil_idr"), 0)

        '    End With
        '    objDatalistDetil.Add(objPrintDetil)
        'Next
        'Return objDatalistDetil
        Dim i As Integer
        '== ari
        Dim dt_accref1 As DataTable = New DataTable
        Dim dt_accref2 As DataTable = New DataTable
        dt_accref1.Clear()
        dt_accref2.Clear()
        Me.DataFill(dt_accref1, "act_selectAccRef_Detil", "accref_id = 3201") 'akun8500015
        Me.DataFill(dt_accref2, "act_selectAccRef_Detil", "accref_id = 3202") 'akun8002000 
        Dim akun1 As String = dt_accref1.Rows(0).Item(0)
        Dim akun2 As String = dt_accref1.Rows(0).Item(0)
        '==eger
        objDatalistDetil = New ArrayList()
        For i = 0 To Me.tbl_PrintDetil.Rows.Count - 1
            objPrintDetil = New DataSource.clsRptJurnal_Detil(Me.DSN)
            With objPrintDetil
                .jurnal_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("jurnal_id"), String.Empty)
                .acc_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("acc_id"), String.Empty)
                .acc_name = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("acc_name"), String.Empty)
                .rekanan_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("rekanan_id"), String.Empty)
                .rekanan_name = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("rekanan_name"), String.Empty)
                .jurnaldetil_descr = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("jurnaldetil_descr"), String.Empty)
                .ref_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("ref_id"), String.Empty)
                If .acc_id = akun2 Or .acc_id = akun1 Then
                    .jurnaldetil_foreignrate = 0
                Else
                    .jurnaldetil_foreignrate = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("jurnaldetil_foreignrate"), 0)
                End If
                .jurnaldetil_foreign = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("jurnaldetil_foreign"), 0)
                .jurnaldetil_idr = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("jurnaldetil_idr"), 0)

            End With
            objDatalistDetil.Add(objPrintDetil)
        Next
        Return objDatalistDetil
    End Function

    Private Sub Export(ByVal report As Microsoft.Reporting.WinForms.LocalReport)

        Dim deviceInfo As String = _
          "<DeviceInfo>" & _
        "  <OutputFormat>EMF</OutputFormat>" & _
        "  <PageWidth>8.27in</PageWidth>" & _
        "  <PageHeight>11.69in</PageHeight>" & _
        "  <MarginTop>0.2in</MarginTop>" & _
        "  <MarginLeft>0.1in</MarginLeft>" & _
        "  <MarginRight>0.1in</MarginRight>" & _
        "  <MarginBottom>0.2in</MarginBottom>" & _
        "</DeviceInfo>"
        Dim warnings() As Microsoft.Reporting.WinForms.Warning = Nothing
        m_streams = New List(Of System.IO.Stream)()
        'Try
        report.Render("Image", deviceInfo, AddressOf CreateStream, warnings)

        Dim stream As System.IO.Stream
        For Each stream In m_streams
            stream.Position = 0
        Next
    End Sub

    Private Function CreateStream _
      (ByVal name As String, ByVal fileNameExtension As String, ByVal encoding As System.Text.Encoding, ByVal mimeType As String, ByVal willSeek As Boolean) _
      As System.IO.Stream
        Dim stream As System.IO.Stream = New System.IO.FileStream(AppDomain.CurrentDomain.BaseDirectory & "Temp\" & name & "." & Date.Now.Second & "." & fileNameExtension, System.IO.FileMode.Create)

        m_streams.Add(stream)

        Return stream
    End Function

    Private Sub PrintPage(ByVal sender As Object, ByVal ev As System.Drawing.Printing.PrintPageEventArgs)
        Dim pageImage As New System.Drawing.Imaging.Metafile(m_streams(m_currentPageIndex))

        ev.Graphics.DrawImage(pageImage, ev.PageBounds)
        m_currentPageIndex += 1
        ev.HasMorePages = (m_currentPageIndex < m_streams.Count)
    End Sub

    Private Sub Print()
        Dim printDoc As New System.Drawing.Printing.PrintDocument()
        Dim printSet As New System.Drawing.Printing.PrinterSettings
        ' ''Const printerName As String = "Microsoft Office Document Image Writer"
        Dim printerName As String = printSet.PrinterName

        If m_streams Is Nothing Or m_streams.Count = 0 Then
            Return
        End If
        printDoc.PrinterSettings.PrinterName = printerName
        If Not printDoc.PrinterSettings.IsValid Then
            Dim msg As String = String.Format("Can't find printer ""{0}"".", printerName)
            Console.WriteLine(msg)
            Return
        End If
        AddHandler printDoc.PrintPage, AddressOf PrintPage
        printDoc.Print()
    End Sub

    Public Sub SubreportProcessing(ByVal sender As Object, ByVal e As Microsoft.Reporting.WinForms.SubreportProcessingEventArgs)
        e.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("NEWACT_AP_DataSource_clsRptJurnal_Detil", objDatalistDetil))
    End Sub

    Private Function uiTrnJurnal_JV_Manual_PrintPreview() As Boolean
        If Me.DgvTrnJurnal.Rows.Count <= 0 Then
            MsgBox("Belum ada data yang dipilih")
            Exit Function
        End If

        Dim i As Integer

        For i = 0 To Me.DgvTrnJurnal.SelectedRows.Count - 1
            Dim frmPrint As dlgRptJurnal = New dlgRptJurnal(Me.DSN, Me.SptServer, Me.DgvTrnJurnal.SelectedRows.Item(i).Cells("jurnal_id").Value, Me.DgvTrnJurnal.SelectedRows.Item(i).Cells("channel_id").Value)

            frmPrint.ShowInTaskbar = False
            frmPrint.StartPosition = FormStartPosition.CenterParent
            frmPrint.ShowDialog(Me)
        Next


    End Function
#End Region

#Region "mencoba tuning (yanuar)"

#Region " Untuk BackgroundWorker"
    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Dim BG_Worker As BackgroundWorker = CType(sender, BackgroundWorker)
        If BG_Worker.CancellationPending Then
            e.Cancel = True
        Else
            Me.uiTrnJurnal_JV_Manual_CollectionData_with_BackgroundWorker(BG_Worker)
        End If
    End Sub

    Private Sub BackgroundWorker1_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        obj_ProgressBar_backGroundWorker.Value = e.ProgressPercentage
        Me.lblLoading.Text = "Please Wait... Loading data " & Me.label_thread & "..."
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        'Untuk Finishing BackgroundWorker
        Me.obj_ProgressBar_backGroundWorker.Visible = False
        Me.lblLoading.Visible = False
        Me.Panel1.Visible = False

        Me.FormatDgvTrnJurnaldetil_Debit(Me.DgvTrnJurnaldetil_Debit)
        Me.FormatDgvTrnJurnaldetil_Credit(Me.DgvTrnJurnaldetil_Credit)

        For Each tsItem As ToolStripItem In Me.ToolStrip1.Items
            If tsItem.GetType.ToString = "System.Windows.Forms.ToolStripSeparator" Or (tsItem.Name = "tbtnSave") Or (tsItem.Name = "tbtnDel") _
                Or (tsItem.Name = "tbtnRefresh") Then
                tsItem.Enabled = False
            Else
                tsItem.Enabled = True
            End If
        Next

        Me.Cursor = Cursors.Arrow

    End Sub

    Public Sub uiTrnJurnal_JV_Manual_newBackgroundWorker()
        Me.BackgroundWorker1 = New BackgroundWorker
        BackgroundWorker1.RunWorkerAsync()
    End Sub

    Private Sub uiTrnJurnal_JV_Manual_CollectionData_with_BackgroundWorker(ByVal worker As BackgroundWorker)
        worker.WorkerReportsProgress = True


        Me.label_thread = "Budget"
        worker.ReportProgress(0)
        'Me.DataFill(Me.tbl_TrnBudgetGrid, "ms_MstBudgetCombo_Select", " budget_isactive = 1")
        Me.DataFillForComboDec("budget_id", "budget_nameshort", Me.tbl_TrnBudget, "ms_MstBudgetCombo_Select", " budget_isactive = 1 AND channel_id = '" & Me._CHANNEL & "' ")
        Me.tbl_TrnBudgetGrid = Me.tbl_TrnBudget.Copy
        Me.tbl_TrnBudgetGrid.DefaultView.Sort = "budget_nameshort"

        Me.label_thread = "Currency"
        worker.ReportProgress(25)
        Me.ComboFillDec(Me.obj_Currency_id, "currency_id", "currency_shortname", Me.tbl_MstCurrency, "ms_MstCurrencyCombo_Select", " currency_active = 1")
        Me.tbl_MstCurrencyGrid = Me.tbl_MstCurrency.Copy()
        Me.tbl_MstCurrency.DefaultView.Sort = "currency_shortname"
        Me.tbl_MstCurrencyGrid.DefaultView.Sort = "currency_shortname"

        Me.label_thread = "Struktur Unit"
        worker.ReportProgress(30)
        Me.DataFillForComboDec("strukturunit_id", "strukturunit_name", Me.tbl_MstStrukturunitGrid, "ms_MstStrukturunitCombo_Select", " strukturunit_active = 1 ")
        Me.tbl_MstStrukturunitGrid.DefaultView.Sort = "strukturunit_name"

        Me.label_thread = "Partner"
        worker.ReportProgress(50)

        '===========================REMARK PTS 20131217======================
        'Me.ComboFillDec(Me.obj_Rekanan_id, "rekanan_id", "rekanan_name", Me.tbl_MstRekanan, "ms_MstRekananCombo_Select", " rekanan_active = 1 ")
        '====================================================================
        '================================================MODIFIED PTS 20131217=================================================
        Me.ComboFillDec(Me.obj_Rekanan_id, "rekanan_id", "rekanan_name", Me.tbl_MstRekanan, "ms_MstRekanan_Select2", " rekanan_active = 1 ", Me._CHANNEL)
        '======================================================================================================================

        Me.tbl_MstRekananGrid = Me.tbl_MstRekanan.Copy()
        Me.tbl_MstRekanan.DefaultView.Sort = "rekanan_name"
        Me.tbl_MstRekananGrid.DefaultView.Sort = "rekanan_name"

        Me.label_thread = "Budget Detil"
        worker.ReportProgress(75)
        Me.DataFillForComboDec("budgetdetil_id", "budgetdetil_desc", Me.tbl_TrnBudgetdetilGrid, "ms_MstBudgetdetilCombo_Select", "")
        Me.tbl_TrnBudgetdetilGrid.DefaultView.Sort = "budgetdetil_desc"

        '====================tambahan PTS 20131227======================
        Me.label_thread = "Channel Number"
        worker.ReportProgress(85)
        Dim tbl_MstChannelnumber As New DataTable
        tbl_MstChannelnumber.Clear()
        Me.DataFill(tbl_MstChannelnumber, "ms_MstChannel_Select", " channel_id = '" & Me._CHANNEL & "' ")

        Me.channel_number = tbl_MstChannelnumber.Rows(0).Item("channel_number").ToString
        '==================================================================

        worker.ReportProgress(100)

        '== ari
        Dim dt_accref1 As DataTable = New DataTable
        Dim dt_accref2 As DataTable = New DataTable
        Dim dt_accref3 As DataTable = New DataTable
        Dim dt_accref4 As DataTable = New DataTable
        Dim dt_accref5 As DataTable = New DataTable
        Dim dt_accref6 As DataTable = New DataTable

        dt_accref1.Clear()
        dt_accref2.Clear()
        dt_accref3.Clear()
        dt_accref4.Clear()
        dt_accref5.Clear()
        dt_accref6.Clear()

        Me.DataFill(dt_accref1, "act_selectAccRef_Detil", "accref_id = 3201") ' akunKerugianSelisihKursPajak
        Me.DataFill(dt_accref2, "act_selectAccRef_Detil", "accref_id = 3202") ' akunKeuntungaSelisihKursPajak

        Me.DataFill(dt_accref3, "act_selectAccRef_Detil", "accref_id = 3301") 'akun8009990 
        Me.DataFill(dt_accref4, "act_selectAccRef_Detil", "accref_id = 3302") 'akun8509990

        Me.DataFill(dt_accref5, "act_selectAccRef_Detil", "accref_id = 3101 ") 'akunKerugianSelisihKurs 
        Me.DataFill(dt_accref6, "act_selectAccRef_Detil", "accref_id = 3102 ") 'akunKeuntunganSelisihKurs



        akunKerugianSelisihKursPajak = dt_accref1.Rows(0).Item(0)
        akunKeuntunganSelisihKursPajak = dt_accref2.Rows(0).Item(0)

        akun8009990 = dt_accref3.Rows(0).Item(0)
        akun8509990 = dt_accref4.Rows(0).Item(0)

        akunKerugianSelisihKurs = dt_accref5.Rows(0).Item(0)
        akunKeuntunganSelisihKurs = dt_accref6.Rows(0).Item(0)
        '==

    End Sub

    Private Sub uiTrnJurnal_JV_Manual_isBackgroudWorker()
        Me.Cursor = Cursors.WaitCursor
        If Me.isBackGroundWorker_isWork = False Then
            Me.isBackGroundWorker_isWork = True
            If Me.isBackgroundWorker = False Then

                Me.Panel1.Visible = True
                Me.obj_ProgressBar_backGroundWorker.Value = 0
                Me.obj_ProgressBar_backGroundWorker.Visible = True
                Me.lblLoading.Visible = True

                If Me.BackgroundWorker1.IsBusy Then
                    Me.BackgroundWorker1.Dispose()
                    Me.uiTrnJurnal_JV_Manual_newBackgroundWorker()
                Else
                    Me.BackgroundWorker1.RunWorkerAsync()
                End If
                Me.isBackgroundWorker = True
            End If
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub uiTrnJurnal_JV_Manual_LoadComboBox()
        If Me.isLoadComboInLoadData = False Then

            Me.ComboFill(Me.cboSearchChannel, "channel_id", "channel_name", Me.tbl_MstChannelSearch, "ms_MstChannelCombo_Select", " channel_id = '" & Me._CHANNEL & "' ")
            Me.tbl_MstChannelSearch.DefaultView.Sort = "channel_name"
            Dim channel As Boolean
            Me.tbl_MstChannel = tbl_MstChannelSearch.Copy
            channel = ComboFillFromDataTable(Me.obj_Channel_id, "channel_id", "channel_name", Me.tbl_MstChannel)
            Me.tbl_MstChannel.DefaultView.Sort = "channel_name"

            Me.ComboFill(Me.cbo_periodeSearch, "periode_id", "periode_name", Me.tbl_MstPeriodeSearch, "ms_MstPeriodeCombo_Select", String.Format(" channel_id = '{0}'", Me._CHANNEL))
            Me.tbl_MstPeriodeSearch.DefaultView.Sort = "periode_name"
            Dim periode As Boolean
            Me.tbl_MstPeriode = tbl_MstPeriodeSearch.Copy
            periode = ComboFillFromDataTable(Me.obj_Periode_id, "periode_id", "periode_name", Me.tbl_MstPeriode)
            Me.tbl_MstPeriode.DefaultView.Sort = "periode_name"

            Me.ComboFill(Me.cbo_createBySearch, "username", "user_fullname", Me.tbl_MstUserSearch, "ms_MstUserInsosysCombo_Select", " user_isdisabled = 0")
            Me.tbl_MstUserSearch.DefaultView.Sort = "user_fullname"

            Me.DataFillForCombo("acc_id", "acc_name", Me.tbl_MstAccGrid, "ms_MstAccountCombo_Select", " acc_isdisabled = 0 ")
            Me.tbl_MstAccGrid.DefaultView.Sort = "acc_name"

            Me.ComboFillDec(Me.obj_Acc_ca_id, "acc_ca_id", "acc_ca_shortname", tbl_MstAcc_ca, "ms_MstAccountCaCombo_Select", "")
            Me.tbl_MstAcc_ca.DefaultView.Sort = "acc_ca_shortname"

            Me.DataFillForComboDec("bankacc_id", "bankacc_reportname", Me.tbl_MstBankacc, "ms_MstBankaccCombo_Select", "")
            Me.tbl_MstBankacc.DefaultView.Sort = "bankacc_reportname"

            Me.DataFill(Me.tbl_MstPaymentTypeGrid, "cp_MstPaymenttype_Select", "")
            Me.tbl_MstPaymentTypeGrid.DefaultView.Sort = "paymenttype_name"

            Me.DataFillForCombo("slipformat_id", "slipformat_name", Me.tbl_MstSlipFormat, "ms_MstSlipformatCombo_Select", "")
            Me.tbl_MstSlipFormat.DefaultView.Sort = "slipformat_name"

            Me.DataFillForCombo("purposefund_id", "purposefund_name", Me.tbl_MstPurposeFund, "ms_MstPurposeFundCombo_Select", "")
            Me.tbl_MstPurposeFund.DefaultView.Sort = "purposefund_name"

            Me.DataFillForCombo("show_id", "show_title", Me.tbl_MstShow, "ms_MstShow_Select", " channel_id = '" & Me._CHANNEL & "' ")
            Me.tbl_MstShow.DefaultView.Sort = "show_title"

            Me.DataFill(Me.tbl_MstPaymentTypeGrid, "cp_MstPaymenttype_Select", "")
            Me.tbl_MstPaymentTypeGrid.DefaultView.Sort = "paymenttype_name"

            Me.DataFillForComboDec("bankacc_id", "bankacc_reportname", Me.tbl_MstBankacc, "ms_MstBankaccCombo_Select", " channel_id = '" & Me._CHANNEL & "' ")
            Me.tbl_MstBankacc.DefaultView.Sort = "bankacc_reportname"


            Me.ComboFillDec(Me.obj_Acc_ca_id, "acc_ca_id", "acc_ca_shortname", tbl_MstAcc_ca, "ms_MstAccountCaCombo_Select", "  acc_ca_type = 2  ")
            Me.tbl_MstAcc_ca.DefaultView.Sort = "acc_ca_shortname"

            Me.txtSearchSource.Text = Me._SOURCE
            Me.isLoadComboInLoadData = True
        End If
    End Sub
#End Region

#End Region

    Private Function uiTrnJurnal_JV_Manual_RowCalculate(ByVal dgv_D As DataGridView, ByVal dgv_K As DataGridView, ByRef selisih As Decimal, ByRef jumlah As Decimal) As Boolean
        Dim i As Integer
        Dim value As Decimal
        Dim cellIDR As DataGridViewCell
        Dim dgv As DataGridView
        Dim jumlah_D, jumlah_K As Decimal


        selisih = 0
        jumlah = 0

        dgv = dgv_D
        For i = 0 To dgv.Rows.Count - 1
            cellIDR = dgv.Rows(i).Cells("jurnaldetil_idr")
            If cellIDR IsNot Nothing Then
                If cellIDR.Value Is DBNull.Value Then
                    value = 0
                Else
                    value = Math.Round(cellIDR.Value, 0, MidpointRounding.AwayFromZero)
                End If
            Else
                value = 0
            End If

            jumlah_D += value

        Next

        dgv = dgv_K
        For i = 0 To dgv.Rows.Count - 1
            cellIDR = dgv.Rows(i).Cells("jurnaldetil_idr")
            If cellIDR IsNot Nothing Then
                If cellIDR.Value Is DBNull.Value Then
                    value = 0
                Else
                    value = Math.Round(cellIDR.Value, 0, MidpointRounding.AwayFromZero)
                End If
            Else
                value = 0
            End If

            jumlah_K += value

        Next

        jumlah = Math.Round(jumlah_D, 0, MidpointRounding.AwayFromZero)
        selisih = Math.Round(jumlah_D - jumlah_K, 0, MidpointRounding.AwayFromZero)

        Me.obj_amountDebitIdr.Text = Format(jumlah_D, "#,##0")
        Me.obj_amountCreditIdr.Text = Format(jumlah_K, "#,##0")

    End Function

    Private Function uiTrnJurnal_JV_Manual_RowCalculateForeign(ByVal dgv_D As DataGridView, ByVal dgv_K As DataGridView, ByRef selisih As Decimal, ByRef jumlah As Decimal) As Boolean
        Dim i As Integer
        Dim value As Decimal
        Dim cellForeign As DataGridViewCell
        Dim dgv As DataGridView
        Dim jumlah_D, jumlah_K As Decimal

        selisih = 0
        jumlah = 0

        dgv = dgv_D
        For i = 0 To dgv.Rows.Count - 1
            cellForeign = dgv.Rows(i).Cells("jurnaldetil_foreign")
            If cellForeign IsNot Nothing Then
                If cellForeign.Value Is DBNull.Value Then
                    value = 0
                Else
                    value = Math.Round(cellForeign.Value, 2, MidpointRounding.AwayFromZero)
                End If
            Else
                value = 0
            End If

            jumlah_D += value

        Next

        dgv = dgv_K
        For i = 0 To dgv.Rows.Count - 1
            cellForeign = dgv.Rows(i).Cells("jurnaldetil_foreign")
            If cellForeign IsNot Nothing Then
                If cellForeign.Value Is DBNull.Value Then
                    value = 0
                Else
                    value = Math.Round(cellForeign.Value, 2, MidpointRounding.AwayFromZero)
                End If
            Else
                value = 0
            End If

            jumlah_K += value

        Next

        jumlah = Math.Round(jumlah_D, 2, MidpointRounding.AwayFromZero)
        selisih = Math.Round(jumlah_D - jumlah_K, 2, MidpointRounding.AwayFromZero)

        Me.obj_amountDebit.Text = Format(jumlah_D, "#,##0.00")
        Me.obj_amountCredit.Text = Format(jumlah_K, "#,##0.00")
    End Function

    Private Function uiTrnJurnal_JV_Manual_RowCalculateForeignIDR(ByVal dgv_D As DataGridView, ByVal dgv_K As DataGridView, ByRef selisih As Decimal, ByRef jumlah As Decimal) As Boolean
        Dim i As Integer
        Dim value As Decimal
        Dim cellForeign As DataGridViewCell
        Dim dgv As DataGridView
        Dim jumlah_D, jumlah_K As Decimal

        selisih = 0
        jumlah = 0

        dgv = dgv_D
        For i = 0 To dgv.Rows.Count - 1
            cellForeign = dgv.Rows(i).Cells("jurnaldetil_foreign")
            If cellForeign IsNot Nothing Then
                If cellForeign.Value Is DBNull.Value Then
                    value = 0
                Else
                    value = Math.Round(cellForeign.Value, 0, MidpointRounding.AwayFromZero)
                End If
            Else
                value = 0
            End If

            jumlah_D += value

        Next

        dgv = dgv_K
        For i = 0 To dgv.Rows.Count - 1
            cellForeign = dgv.Rows(i).Cells("jurnaldetil_foreign")
            If cellForeign IsNot Nothing Then
                If cellForeign.Value Is DBNull.Value Then
                    value = 0
                Else
                    value = Math.Round(cellForeign.Value, 0, MidpointRounding.AwayFromZero)
                End If
            Else
                value = 0
            End If

            jumlah_K += value

        Next

        jumlah = Math.Round(jumlah_D, 0, MidpointRounding.AwayFromZero)
        selisih = Math.Round(jumlah_D - jumlah_K, 0, MidpointRounding.AwayFromZero)

        Me.obj_amountDebit.Text = Format(jumlah_D, "#,##0")
        Me.obj_amountCredit.Text = Format(jumlah_K, "#,##0")
    End Function

    Private Function uiTrnJurnal_JV_Manual_RowCalcIDR(ByVal dgv As DataGridView, ByVal cellIDR As DataGridViewCell, ByVal cellForeign As DataGridViewCell, ByVal cellRate As DataGridViewCell) As Boolean
        Dim TotalperRow As Decimal
        '===================
        If (dgv.CurrentRow.Cells("acc_id").Value <> akunKerugianSelisihKursPajak) And (dgv.CurrentRow.Cells("acc_id").Value <> akunKeuntunganSelisihKursPajak) _
            And (dgv.CurrentRow.Cells("acc_id").Value <> akunKerugianSelisihKurs) And (dgv.CurrentRow.Cells("acc_id").Value <> akunKeuntunganSelisihKurs) Then
            ' 20151105 ARI MDP2 Untuk akun Keuntungan atau Kerugian Selisih Kurs tidak termasuk
            TotalperRow = Math.Round(clsUtil.IsDbNull(cellForeign.Value, 0), 2, MidpointRounding.AwayFromZero) * Math.Round(clsUtil.IsDbNull(cellRate.Value, 0), 2, MidpointRounding.AwayFromZero)
            Try
                cellIDR.Value = Math.Round(TotalperRow, 0, MidpointRounding.AwayFromZero) 'String.Format("{0:#,##0.00}", TotalperRow)    TotalperRow.ToString("{0:#,##0.00}")
                ' ''cellIDR.Value = Math.Round(cellIDR.Value, 0)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "uiTrnJurnal_RowCalcIDR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
        '===================


    End Function

    Private Function uiTrnJurnal_JV_Manual_TblDetilInverse(ByVal tbl As DataTable) As Boolean
        Dim i As Integer
        For i = 0 To tbl.Rows.Count - 1
            If tbl.Rows(i).RowState <> DataRowState.Deleted Then
                tbl.Rows(i).Item("jurnaldetil_idr") = -tbl.Rows(i).Item("jurnaldetil_idr")
                tbl.Rows(i).Item("jurnaldetil_foreign") = -tbl.Rows(i).Item("jurnaldetil_foreign")
            End If
        Next
        Return True
    End Function

    Private Function uiTrnJurnal_JV_Manual_SetDefaultValueOfJurnaldetil_Debit(ByVal sender As System.Object, ByVal columnname As String) As Boolean
        Dim id As String
        Dim cbo As ComboBox = sender
        Try
            If cbo.SelectedValue IsNot Nothing Then
                id = cbo.SelectedValue.ToString
                If id <> "System.Data.DataRowView" Then
                    Me.tbl_TrnJurnaldetil_Debit.Columns(columnname).DefaultValue = cbo.SelectedValue
                End If
            End If
        Catch ex As Exception
        End Try

        Return True

    End Function

    Private Function uiTrnJurnal_JV_Manual_SetDefaultValueOfJurnaldetil_Credit(ByVal sender As System.Object, ByVal columnname As String) As Boolean
        Dim id As String
        Dim cbo As ComboBox = sender
        Try
            If cbo.SelectedValue IsNot Nothing Then
                id = cbo.SelectedValue.ToString
                If id <> "System.Data.DataRowView" Then
                    Me.tbl_TrnJurnaldetil_Credit.Columns(columnname).DefaultValue = cbo.SelectedValue
                End If
            End If
        Catch ex As Exception
        End Try

        Return True

    End Function

    Private Function uiTrnJurnal_JV_Manual_DataIsLocked() As Boolean
        If Me.isNewButton = False Then
            If Me.obj_Jurnaltype_id.Text <> ConstMyJurnalType Or Me.obj_Jurnal_source.Text <> Me._SOURCE _
                                    Or Me.obj_Jurnal_isposted.Checked Or Me.DgvTrnJurnalResponse.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If
        Else
            Return False
        End If
    End Function

    Private Sub obj_Jumlah_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles obj_Jumlah.TextChanged
        Dim obj As TextBox = sender
        obj.ForeColor = Color.Blue
    End Sub

    Private Sub obj_Jumlah_Foreign_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles obj_Jumlah_Foreign.TextChanged
        Dim obj As TextBox = sender
        obj.ForeColor = Color.Blue
    End Sub

    Private Sub obj_Selisih_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles obj_Selisih.TextChanged
        Dim obj As TextBox = sender
        Dim selisih As Decimal = obj.Text

        If selisih = 0 Then
            obj.BackColor = Color.PaleGreen
            obj.ForeColor = Color.Green
        Else
            obj.BackColor = Color.LightCoral
            obj.ForeColor = Color.Black
        End If
    End Sub

    Private Sub obj_Selisih_Foreign_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles obj_Selisih_Foreign.TextChanged
        Dim obj As TextBox = sender
        Dim selisih As Decimal = obj.Text

        If selisih = 0 Then
            obj.BackColor = Color.PaleGreen
            obj.ForeColor = Color.Green
        Else
            obj.BackColor = Color.LightCoral
            obj.ForeColor = Color.Black
        End If
    End Sub

    Private Sub obj_Jurnal_descr_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles obj_Jurnal_descr.Validated
        Dim obj As TextBox = sender
        Me.tbl_TrnJurnaldetil_Debit.Columns("jurnaldetil_descr").DefaultValue = obj.Text
        Me.tbl_TrnJurnaldetil_Credit.Columns("jurnaldetil_descr").DefaultValue = obj.Text
    End Sub

    Private Sub obj_Currency_rate_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles obj_Currency_rate.Validated
        Dim obj As TextBox = sender
        '  Dim i As Integer

        For Each viewRow As DataGridViewRow In Me.DgvTrnJurnaldetil_Debit.Rows
            If viewRow.IsNewRow = False Then
                viewRow.Cells("jurnaldetil_foreignrate").Value = CDec(Me.obj_Currency_rate.Text)
            End If
        Next

        For Each viewRow As DataGridViewRow In Me.DgvTrnJurnaldetil_Credit.Rows
            If viewRow.IsNewRow = False Then
                viewRow.Cells("jurnaldetil_foreignrate").Value = CDec(Me.obj_Currency_rate.Text)
            End If
        Next
        'For i = 0 To Me.DgvTrnJurnaldetil_Debit.Rows.Count - 1
        '    Me.DgvTrnJurnaldetil_Debit.Rows(i).Cells("jurnaldetil_foreignrate").Value = CDec(Me.obj_Currency_rate.Text)
        'Next

        'For i = 0 To Me.DgvTrnJurnaldetil_Credit.Rows.Count - 1
        '    Me.DgvTrnJurnaldetil_Credit.Rows(i).Cells("jurnaldetil_foreignrate").Value = CDec(Me.obj_Currency_rate.Text)
        'Next

        Me.tbl_TrnJurnaldetil_Debit.Columns("jurnaldetil_foreignrate").DefaultValue = obj.Text
        Me.tbl_TrnJurnaldetil_Credit.Columns("jurnaldetil_foreignrate").DefaultValue = obj.Text
    End Sub

    Private Sub obj_Rekanan_id_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles obj_Rekanan_id.Validated
        Dim cbo As ComboBox = sender
        Dim i As Integer

        For i = 0 To Me.DgvTrnJurnaldetil_Debit.Rows.Count - 1
            Me.DgvTrnJurnaldetil_Debit.Rows(i).Cells("rekanan_id").Value = cbo.SelectedValue
            Me.DgvTrnJurnaldetil_Debit.Rows(i).Cells("rekanan_name").Value = cbo.Text
        Next

        For i = 0 To Me.DgvTrnJurnaldetil_Credit.Rows.Count - 1
            Me.DgvTrnJurnaldetil_Credit.Rows(i).Cells("rekanan_id").Value = cbo.SelectedValue
            Me.DgvTrnJurnaldetil_Credit.Rows(i).Cells("rekanan_name").Value = cbo.Text
        Next

        Me.uiTrnJurnal_JV_Manual_SetDefaultValueOfJurnaldetil_Debit(sender, cbo.ValueMember)
        Me.uiTrnJurnal_JV_Manual_SetDefaultValueOfJurnaldetil_Credit(sender, cbo.ValueMember)
        Me.tbl_TrnJurnaldetil_Debit.Columns("rekanan_name").DefaultValue = cbo.Text
        Me.tbl_TrnJurnaldetil_Credit.Columns("rekanan_name").DefaultValue = cbo.Text
    End Sub

    Private Sub obj_Currency_id_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles obj_Currency_id.SelectedIndexChanged

        Try

            Dim id As Decimal
            Dim cbo As ComboBox = sender

            Dim i, k As Integer
            Dim tbl_exrate As DataTable
            Dim curr_name As String = String.Empty

            curr_name = Me.obj_Currency_id.Text
            id = cbo.SelectedValue

            tbl_exrate = New DataTable
            tbl_exrate.Clear()
            If id <> 0 Then
                Me.DataFill(tbl_exrate, "pr_MstXRate_Select", String.Format("exrate_currency = '{0}'", curr_name))

                If tbl_exrate.Rows.Count > 0 Then
                    Me.obj_Currency_rate.Text = tbl_exrate.Rows(0)("exrate_mid")
                Else
                    Me.obj_Currency_rate.Text = 0
                End If
            End If

            If Me.DgvTrnJurnaldetil_Debit.Rows.Count = 1 Then
                For i = 0 To Me.DgvTrnJurnaldetil_Debit.Rows.Count - 1
                    Me.DgvTrnJurnaldetil_Debit.Rows(i).Cells("currency_id").Value = id
                    Me.DgvTrnJurnaldetil_Debit.Rows(i).Cells("jurnaldetil_foreignrate").Value = CDec(Me.obj_Currency_rate.Text)
                Next
            Else
                For i = 0 To Me.DgvTrnJurnaldetil_Debit.Rows.Count - 2
                    Me.DgvTrnJurnaldetil_Debit.Rows(i).Cells("currency_id").Value = id
                    Me.DgvTrnJurnaldetil_Debit.Rows(i).Cells("jurnaldetil_foreignrate").Value = CDec(Me.obj_Currency_rate.Text)
                Next
            End If

            If Me.DgvTrnJurnaldetil_Credit.Rows.Count = 1 Then
                For k = 0 To Me.DgvTrnJurnaldetil_Credit.Rows.Count - 1
                    Me.DgvTrnJurnaldetil_Credit.Rows(k).Cells("currency_id").Value = id
                    Me.DgvTrnJurnaldetil_Credit.Rows(k).Cells("jurnaldetil_foreignrate").Value = CDec(Me.obj_Currency_rate.Text)
                Next
            Else
                For k = 0 To Me.DgvTrnJurnaldetil_Credit.Rows.Count - 2
                    Me.DgvTrnJurnaldetil_Credit.Rows(k).Cells("currency_id").Value = id
                    Me.DgvTrnJurnaldetil_Credit.Rows(k).Cells("jurnaldetil_foreignrate").Value = CDec(Me.obj_Currency_rate.Text)
                Next
            End If


            Me.tbl_TrnJurnaldetil_Debit.Columns("jurnaldetil_foreignrate").DefaultValue = CDec(Me.obj_Currency_rate.Text)
            Me.tbl_TrnJurnaldetil_Credit.Columns("jurnaldetil_foreignrate").DefaultValue = CDec(Me.obj_Currency_rate.Text)
            Me.tbl_TrnJurnaldetil_Debit.Columns("currency_id").DefaultValue = Me.obj_Currency_id.SelectedValue
            Me.tbl_TrnJurnaldetil_Credit.Columns("currency_id").DefaultValue = Me.obj_Currency_id.SelectedValue

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btn_Budget_Header_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Budget_Header.Click
        Dim dlg As dlgSearch = New dlgSearch()
        Dim retData As Collection
        Dim retObj As Object
        Dim budget_id As Decimal
        Dim budget_name As String

        retObj = dlg.OpenDialog(Me, Me.tbl_TrnBudget, "budget")
        If retObj IsNot Nothing Then
            retData = CType(retObj, Collection)
            budget_id = CType(retData.Item("retId"), Decimal)
            budget_name = CType(retData.Item("retName"), String)
            Me.obj_Budget_id.Text = budget_id
            Me.obj_Budget_name.Text = budget_name


            Me.tbl_TrnJurnaldetil_Debit.Columns("budget_id").DefaultValue = Me.obj_Budget_id.Text
            Me.tbl_TrnJurnaldetil_Debit.Columns("budget_name").DefaultValue = Me.obj_Budget_name.Text
            Me.tbl_TrnJurnaldetil_Credit.Columns("budget_id").DefaultValue = Me.obj_Budget_id.Text
            Me.tbl_TrnJurnaldetil_Credit.Columns("budget_name").DefaultValue = Me.obj_Budget_name.Text
        End If
    End Sub

#Region "Import XLS Function"
    Private Sub btnUpload_Click(sender As Object, e As EventArgs) Handles btnUpload.Click
        OpenFileDialog1.Filter = "Files Excel |*.xls|Files Excel 2007 - Up |*.xlsx"
        OpenFileDialog1.CheckFileExists = True
        OpenFileDialog1.FilterIndex = 2
        OpenFileDialog1.FileName = ""

        If Me.OpenFileDialog1.ShowDialog = DialogResult.OK Then
            Dim cPathExcel As String
            cPathExcel = OpenFileDialog1.FileName
            ImportToDetail1(cPathExcel)
        End If
    End Sub

    Public Function ImportToDetail1(ByVal PrmPathExcelFile As String) As Boolean
        Dim MyConnection As System.Data.OleDb.OleDbConnection
        Dim DataTempAll As DataTable
        'coba
        'Dim row_credit As DataRow '= tbl_TrnJurnaldetil_Credit.NewRow
        'Dim row_debit As DataRow '= tbl_TrnJurnaldetil_Debit.NewRow

        Dim i As Integer = 0
        Dim jurnal_id As String = Trim(obj_Jurnal_id.Text)
        Dim MasterDataState As System.Data.DataRowState
        Dim budget_id, rekanan_id, budgetdetil_id As Decimal
        Dim rekanan_name, budget_name, budgetdetil_name As String
        ' Dim selisih As Decimal
        Dim cookie As Byte() = Nothing

        Try
            Dim MyCommand As System.Data.OleDb.OleDbDataAdapter
            Dim connstring As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & PrmPathExcelFile & ";Extended Properties=""Excel 12.0;HDR=YES;IMEX=1""" 'may need to use different MS provider and lower OLEDB for .xls files (Microsoft.Jet.OLEDB4.0...Excel 8.0) kind of sketchy though
            MyConnection = New System.Data.OleDb.OleDbConnection(connstring) 'create a new data connection to Excel data source
            MyCommand = New System.Data.OleDb.OleDbDataAdapter("select * from [sheet1$]", MyConnection) 'query the sheet - select all data in columns A:F
            MyCommand.TableMappings.Add("Table", "Test1") 'map data selection as table
            Dim DtSet1 As DataSet = New System.Data.DataSet 'create new data set

            MyConnection.Open()
            'clsApplicationRole.SetAppRole(MyConnection, cookie)
            MyCommand.Fill(DtSet1) 'fill data set with table
            DataTempAll = DtSet1.Tables(0) 'Copy to DataTable
            'clsApplicationRole.UnsetAppRole(MyConnection, cookie)
            MyConnection.Close()

            If jurnal_id <> "" Then
                MasterDataState = tbl_TrnJurnal_Temp.Rows(0).RowState
                Me.tbl_TrnJurnaldetil_Credit.AcceptChanges()
                If Me.tbl_TrnJurnaldetil_Credit.Rows.Count > 0 Then
                    For n As Integer = 0 To Me.tbl_TrnJurnaldetil_Credit.Rows.Count - 1
                        Me.tbl_TrnJurnaldetil_Credit.Rows(n).Delete()
                    Next
                End If
                Me.tbl_TrnJurnaldetil_Debit.AcceptChanges()
                If Me.tbl_TrnJurnaldetil_Debit.Rows.Count > 0 Then
                    For n As Integer = 0 To Me.tbl_TrnJurnaldetil_Debit.Rows.Count - 1
                        Me.tbl_TrnJurnaldetil_Debit.Rows(n).Delete()
                    Next
                End If
            End If

            Dim dtRow() As DataRow

            DataTempAll = DataTempAll.Select("detil = 'D' or detil ='K'").CopyToDataTable()
            For i = 0 To DataTempAll.Rows.Count - 1


                ''coba
                'rekanan_id = 0
                'rekanan_name = ""
                'budget_id = 0
                'budget_name = ""
                'budgetdetil_id = 0
                'budgetdetil_name = ""

                '----------------------------------------------------------------------------------------------------------------------------------------------------------
                rekanan_id = clsUtil.IsDbNull(DataTempAll.Rows(i).Item("rekanan_id"), 0)
                If rekanan_id = 0 Then
                    rekanan_name = ""
                Else
                    dtRow = Me.tbl_MstRekanan.Select("rekanan_id = '" & DataTempAll.Rows(i).Item("rekanan_id") & "'")
                    rekanan_name = ""
                    For n As Integer = 0 To (dtRow.Length - 1)
                        rekanan_name = dtRow(n)("rekanan_name").ToString
                    Next

                    'rekanan_name = Me.tbl_MstRekanan.Select("rekanan_id = '" & DataTempAll.Rows(i).Item("rekanan_id") & "'")(0).Item("rekanan_name")
                End If

                '----------------------------------------------------------------------------------------------------------------------------------------------------------
                budget_id = clsUtil.IsDbNull(DataTempAll.Rows(i).Item("budget_id"), 0)
                If budget_id = 0 Then
                    budget_name = ""
                Else
                    dtRow = Me.tbl_TrnBudgetGrid.Select("budget_id = '" & DataTempAll.Rows(i).Item("budget_id") & "'")
                    budget_name = ""
                    For n As Integer = 0 To (dtRow.Length - 1)
                        budget_name = dtRow(n)("budget_name").ToString
                    Next

                    ' budget_name = Me.tbl_TrnBudgetGrid.Select("budget_id = '" & DataTempAll.Rows(i).Item("budget_id") & "'")(0).Item("budget_name")
                End If

                '----------------------------------------------------------------------------------------------------------------------------------------------------------
                budgetdetil_id = clsUtil.IsDbNull(DataTempAll.Rows(i).Item("budgetdetil_id"), 0)
                If budgetdetil_id = 0 Then
                    budgetdetil_name = ""
                Else
                    dtRow = Me.tbl_TrnBudgetdetilGrid.Select("budgetdetil_id = '" & DataTempAll.Rows(i).Item("budgetdetil_id") & "'")
                    budgetdetil_name = ""
                    For n As Integer = 0 To (dtRow.Length - 1)
                        budgetdetil_name = dtRow(n)("budgetdetil_desc").ToString
                    Next

                    ' budgetdetil_name = Me.tbl_TrnBudgetdetilGrid.Select("budgetdetil_id = '" & DataTempAll.Rows(i).Item("budgetdetil_id") & "'")(0).Item("budgetdetil_desc")
                End If
                '----------------------------------------------------------------------------------------------------------------------------------------------------------
                If DataTempAll.Rows(i).Item("detil") = "K" Then
                    Me.BindingContext(Me.tbl_TrnJurnaldetil_Credit).AddNew()
                    DgvTrnJurnaldetil_Credit.Rows(DgvTrnJurnaldetil_Credit.CurrentCell.RowIndex).Cells("jurnaldetil_descr").Value = DataTempAll.Rows(i).Item("desc")
                    DgvTrnJurnaldetil_Credit.Rows(DgvTrnJurnaldetil_Credit.CurrentCell.RowIndex).Cells("acc_id").Value = DataTempAll.Rows(i).Item("acc_id")
                    DgvTrnJurnaldetil_Credit.Rows(DgvTrnJurnaldetil_Credit.CurrentCell.RowIndex).Cells("currency_id").Value = DataTempAll.Rows(i).Item("currency_id")
                    DgvTrnJurnaldetil_Credit.Rows(DgvTrnJurnaldetil_Credit.CurrentCell.RowIndex).Cells("jurnaldetil_foreign").Value = DataTempAll.Rows(i).Item("amount")
                    DgvTrnJurnaldetil_Credit.Rows(DgvTrnJurnaldetil_Credit.CurrentCell.RowIndex).Cells("jurnaldetil_foreignrate").Value = DataTempAll.Rows(i).Item("rate")
                    DgvTrnJurnaldetil_Credit.Rows(DgvTrnJurnaldetil_Credit.CurrentCell.RowIndex).Cells("rekanan_id").Value = rekanan_id
                    DgvTrnJurnaldetil_Credit.Rows(DgvTrnJurnaldetil_Credit.CurrentCell.RowIndex).Cells("rekanan_name").Value = rekanan_name
                    DgvTrnJurnaldetil_Credit.Rows(DgvTrnJurnaldetil_Credit.CurrentCell.RowIndex).Cells("budget_id").Value = budget_id
                    DgvTrnJurnaldetil_Credit.Rows(DgvTrnJurnaldetil_Credit.CurrentCell.RowIndex).Cells("budget_name").Value = budget_name
                    DgvTrnJurnaldetil_Credit.Rows(DgvTrnJurnaldetil_Credit.CurrentCell.RowIndex).Cells("budgetdetil_id").Value = budgetdetil_id
                    DgvTrnJurnaldetil_Credit.Rows(DgvTrnJurnaldetil_Credit.CurrentCell.RowIndex).Cells("budgetdetil_name").Value = budgetdetil_name
                    DgvTrnJurnaldetil_Credit.Rows(DgvTrnJurnaldetil_Credit.CurrentCell.RowIndex).Cells("strukturunit_id").Value = DataTempAll.Rows(i).Item("strukturunit_id")
                End If

                If DataTempAll.Rows(i).Item("detil") = "D" Then
                    Me.BindingContext(Me.tbl_TrnJurnaldetil_Debit).AddNew()
                    DgvTrnJurnaldetil_Debit.Rows(DgvTrnJurnaldetil_Debit.CurrentCell.RowIndex).Cells("jurnaldetil_descr").Value = DataTempAll.Rows(i).Item("desc")
                    DgvTrnJurnaldetil_Debit.Rows(DgvTrnJurnaldetil_Debit.CurrentCell.RowIndex).Cells("acc_id").Value = DataTempAll.Rows(i).Item("acc_id")
                    DgvTrnJurnaldetil_Debit.Rows(DgvTrnJurnaldetil_Debit.CurrentCell.RowIndex).Cells("currency_id").Value = DataTempAll.Rows(i).Item("currency_id")
                    DgvTrnJurnaldetil_Debit.Rows(DgvTrnJurnaldetil_Debit.CurrentCell.RowIndex).Cells("jurnaldetil_foreign").Value = DataTempAll.Rows(i).Item("amount")
                    DgvTrnJurnaldetil_Debit.Rows(DgvTrnJurnaldetil_Debit.CurrentCell.RowIndex).Cells("jurnaldetil_foreignrate").Value = DataTempAll.Rows(i).Item("rate")
                    DgvTrnJurnaldetil_Debit.Rows(DgvTrnJurnaldetil_Debit.CurrentCell.RowIndex).Cells("rekanan_id").Value = rekanan_id
                    DgvTrnJurnaldetil_Debit.Rows(DgvTrnJurnaldetil_Debit.CurrentCell.RowIndex).Cells("rekanan_name").Value = rekanan_name
                    DgvTrnJurnaldetil_Debit.Rows(DgvTrnJurnaldetil_Debit.CurrentCell.RowIndex).Cells("budget_id").Value = budget_id
                    DgvTrnJurnaldetil_Debit.Rows(DgvTrnJurnaldetil_Debit.CurrentCell.RowIndex).Cells("budget_name").Value = budget_name
                    DgvTrnJurnaldetil_Debit.Rows(DgvTrnJurnaldetil_Debit.CurrentCell.RowIndex).Cells("budgetdetil_id").Value = budgetdetil_id
                    DgvTrnJurnaldetil_Debit.Rows(DgvTrnJurnaldetil_Debit.CurrentCell.RowIndex).Cells("budgetdetil_name").Value = budgetdetil_name
                    DgvTrnJurnaldetil_Debit.Rows(DgvTrnJurnaldetil_Debit.CurrentCell.RowIndex).Cells("strukturunit_id").Value = DataTempAll.Rows(i).Item("strukturunit_id")
                End If

                'If DataTempAll.Rows(i).Item("detil") = "K" Then
                '    row_credit = tbl_TrnJurnaldetil_Credit.NewRow
                '    row_credit("jurnaldetil_descr") = DataTempAll.Rows(i).Item("desc")
                '    row_credit("acc_id") = DataTempAll.Rows(i).Item("acc_id")
                '    row_credit("currency_id") = DataTempAll.Rows(i).Item("currency_id")
                '    row_credit("jurnaldetil_foreign") = DataTempAll.Rows(i).Item("amount")
                '    row_credit("jurnaldetil_foreignrate") = DataTempAll.Rows(i).Item("rate")
                '    row_credit("rekanan_id") = rekanan_id
                '    row_credit("rekanan_name") = rekanan_name
                '    row_credit("budget_id") = budget_id
                '    row_credit("budget_name") = budget_name
                '    row_credit("budgetdetil_id") = budgetdetil_id
                '    row_credit("budgetdetil_name") = budgetdetil_name
                '    row_credit("strukturunit_id") = DataTempAll.Rows(i).Item("strukturunit_id")
                '    tbl_TrnJurnaldetil_Credit.Rows.Add(row_credit)
                'End If

                'If DataTempAll.Rows(i).Item("detil") = "D" Then
                '    row_debit = tbl_TrnJurnaldetil_Debit.NewRow
                '    row_debit("jurnaldetil_descr") = DataTempAll.Rows(i).Item("desc")
                '    row_debit("acc_id") = DataTempAll.Rows(i).Item("acc_id")
                '    row_debit("currency_id") = DataTempAll.Rows(i).Item("currency_id")
                '    row_debit("jurnaldetil_foreign") = DataTempAll.Rows(i).Item("amount")
                '    row_debit("jurnaldetil_foreignrate") = DataTempAll.Rows(i).Item("rate")
                '    row_debit("rekanan_id") = rekanan_id
                '    row_debit("rekanan_name") = rekanan_name
                '    row_debit("budget_id") = budget_id
                '    row_debit("budget_name") = budget_name
                '    row_debit("budgetdetil_id") = budgetdetil_id
                '    row_debit("budgetdetil_name") = budgetdetil_name
                '    row_debit("strukturunit_id") = DataTempAll.Rows(i).Item("strukturunit_id")
                '    tbl_TrnJurnaldetil_Debit.Rows.Add(row_debit)
                'End If
            Next
            'MsgBox("oke")
            'Me.uiTrnJurnal_JV_Manual_RowCalculateForeignIDR(Me.DgvTrnJurnaldetil_Debit, Me.DgvTrnJurnaldetil_Credit, selisih, jumlah)
        Catch exc As OleDb.OleDbException
            If exc.ErrorCode.ToString = "-2147467259" Then
                MessageBox.Show("Ubah Nama Sheet1 dengan 'Sheet1'", "Renaming Sheet1", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                MessageBox.Show("There was a problem loading this database. Please contact an administrator if the problem continues." & vbNewLine & vbNewLine & "Error: " & exc.Message)
            End If
        Catch exc As Exception
            MsgBox(exc.ToString)
        Finally
            Cursor = Cursors.Default
        End Try
    End Function

    Public Function ImportToDetail2(ByVal PrmPathExcelFile As String) As Boolean
        Dim MyConnection As System.Data.OleDb.OleDbConnection
        Dim DataTempAll As DataTable

        'Dim row_credit As DataRow
        'Dim row_debit As DataRow

        Dim i As Integer = 0
        Dim jurnal_id As String = Trim(obj_Jurnal_id.Text)
        Dim MasterDataState As System.Data.DataRowState
        Dim budget_id, rekanan_id, budgetdetil_id As Decimal
        Dim rekanan_name, budget_name, budgetdetil_name As String
        Dim cookie As Byte() = Nothing

        'Dim selisih As Decimal
        Try
            Dim MyCommand As System.Data.OleDb.OleDbDataAdapter
            Dim connstring As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & PrmPathExcelFile & ";Extended Properties=""Excel 12.0;HDR=YES;IMEX=1""" 'may need to use different MS provider and lower OLEDB for .xls files (Microsoft.Jet.OLEDB4.0...Excel 8.0) kind of sketchy though
            MyConnection = New System.Data.OleDb.OleDbConnection(connstring) 'create a new data connection to Excel data source
            MyCommand = New System.Data.OleDb.OleDbDataAdapter("select * from [sheet1$]", MyConnection) 'query the sheet - select all data in columns A:F
            MyCommand.TableMappings.Add("Table", "Test1") 'map data selection as table
            Dim DtSet1 As DataSet = New System.Data.DataSet 'create new data set
            MyConnection.Open()
            'clsApplicationRole.SetAppRole(MyConnection, cookie)
            MyCommand.Fill(DtSet1) 'fill data set with table
            DataTempAll = DtSet1.Tables(0) 'Copy to DataTable

            'clsApplicationRole.UnsetAppRole(MyConnection, cookie)
            MyConnection.Close()

            If jurnal_id <> "" Then
                MasterDataState = tbl_TrnJurnal_Temp.Rows(0).RowState
                Me.tbl_TrnJurnaldetil_Credit.AcceptChanges()
                If Me.tbl_TrnJurnaldetil_Credit.Rows.Count > 0 Then
                    For n As Integer = 0 To Me.tbl_TrnJurnaldetil_Credit.Rows.Count - 1
                        Me.tbl_TrnJurnaldetil_Credit.Rows(n).Delete()
                    Next
                End If
                Me.tbl_TrnJurnaldetil_Debit.AcceptChanges()
                If Me.tbl_TrnJurnaldetil_Debit.Rows.Count > 0 Then
                    For n As Integer = 0 To Me.tbl_TrnJurnaldetil_Debit.Rows.Count - 1
                        Me.tbl_TrnJurnaldetil_Debit.Rows(n).Delete()
                    Next
                End If
            End If

            Dim dtRow() As DataRow

            DataTempAll = DataTempAll.Select("detil = 'D' or detil ='K'").CopyToDataTable()
            For i = 0 To DataTempAll.Rows.Count - 1

                '----------------------------------------------------------------------------------------------------------------------------------------------------------
                rekanan_id = clsUtil.IsDbNull(DataTempAll.Rows(i).Item("rekanan_id"), 0)
                If rekanan_id = 0 Then
                    rekanan_name = ""
                Else
                    dtRow = Me.tbl_MstRekanan.Select("rekanan_id = '" & DataTempAll.Rows(i).Item("rekanan_id") & "'")
                    rekanan_name = ""
                    For n As Integer = 0 To (dtRow.Length - 1)
                        rekanan_name = dtRow(n)("rekanan_name").ToString
                    Next

                End If

                '----------------------------------------------------------------------------------------------------------------------------------------------------------
                budget_id = clsUtil.IsDbNull(DataTempAll.Rows(i).Item("budget_id"), 0)
                If budget_id = 0 Then
                    budget_name = ""
                Else
                    dtRow = Me.tbl_TrnBudgetGrid.Select("budget_id = '" & DataTempAll.Rows(i).Item("budget_id") & "'")
                    budget_name = ""
                    For n As Integer = 0 To (dtRow.Length - 1)
                        budget_name = dtRow(n)("budget_name").ToString
                    Next

                End If

                '----------------------------------------------------------------------------------------------------------------------------------------------------------
                budgetdetil_id = clsUtil.IsDbNull(DataTempAll.Rows(i).Item("budgetdetil_id"), 0)
                If budgetdetil_id = 0 Then
                    budgetdetil_name = ""
                Else
                    dtRow = Me.tbl_TrnBudgetdetilGrid.Select("budgetdetil_id = '" & DataTempAll.Rows(i).Item("budgetdetil_id") & "'")
                    budgetdetil_name = ""
                    For n As Integer = 0 To (dtRow.Length - 1)
                        budgetdetil_name = dtRow(n)("budgetdetil_desc").ToString
                    Next

                End If
                '----------------------------------------------------------------------------------------------------------------------------------------------------------
                If DataTempAll.Rows(i).Item("detil") = "K" Then
                    Me.BindingContext(Me.tbl_TrnJurnaldetil_Credit).AddNew()
                    DgvTrnJurnaldetil_Credit.Rows(DgvTrnJurnaldetil_Credit.CurrentCell.RowIndex).Cells("jurnaldetil_descr").Value = DataTempAll.Rows(i).Item("desc")
                    DgvTrnJurnaldetil_Credit.Rows(DgvTrnJurnaldetil_Credit.CurrentCell.RowIndex).Cells("acc_id").Value = DataTempAll.Rows(i).Item("acc_id")
                    DgvTrnJurnaldetil_Credit.Rows(DgvTrnJurnaldetil_Credit.CurrentCell.RowIndex).Cells("currency_id").Value = DataTempAll.Rows(i).Item("currency_id")
                    DgvTrnJurnaldetil_Credit.Rows(DgvTrnJurnaldetil_Credit.CurrentCell.RowIndex).Cells("jurnaldetil_foreign").Value = DataTempAll.Rows(i).Item("amount")
                    DgvTrnJurnaldetil_Credit.Rows(DgvTrnJurnaldetil_Credit.CurrentCell.RowIndex).Cells("jurnaldetil_foreignrate").Value = DataTempAll.Rows(i).Item("rate")
                    DgvTrnJurnaldetil_Credit.Rows(DgvTrnJurnaldetil_Credit.CurrentCell.RowIndex).Cells("jurnaldetil_idr").Value = DataTempAll.Rows(i).Item("amount_idr")
                    DgvTrnJurnaldetil_Credit.Rows(DgvTrnJurnaldetil_Credit.CurrentCell.RowIndex).Cells("rekanan_id").Value = rekanan_id
                    DgvTrnJurnaldetil_Credit.Rows(DgvTrnJurnaldetil_Credit.CurrentCell.RowIndex).Cells("rekanan_name").Value = rekanan_name
                    DgvTrnJurnaldetil_Credit.Rows(DgvTrnJurnaldetil_Credit.CurrentCell.RowIndex).Cells("budget_id").Value = budget_id
                    DgvTrnJurnaldetil_Credit.Rows(DgvTrnJurnaldetil_Credit.CurrentCell.RowIndex).Cells("budget_name").Value = budget_name
                    DgvTrnJurnaldetil_Credit.Rows(DgvTrnJurnaldetil_Credit.CurrentCell.RowIndex).Cells("budgetdetil_id").Value = budgetdetil_id
                    DgvTrnJurnaldetil_Credit.Rows(DgvTrnJurnaldetil_Credit.CurrentCell.RowIndex).Cells("budgetdetil_name").Value = budgetdetil_name
                    DgvTrnJurnaldetil_Credit.Rows(DgvTrnJurnaldetil_Credit.CurrentCell.RowIndex).Cells("strukturunit_id").Value = DataTempAll.Rows(i).Item("strukturunit_id")
                    DgvTrnJurnaldetil_Credit.Rows(DgvTrnJurnaldetil_Credit.CurrentCell.RowIndex).Cells("ref_id").Value = DataTempAll.Rows(i).Item("ref_id")
                    DgvTrnJurnaldetil_Credit.Rows(DgvTrnJurnaldetil_Credit.CurrentCell.RowIndex).Cells("ref_line").Value = DataTempAll.Rows(i).Item("ref_line")
                End If

                If DataTempAll.Rows(i).Item("detil") = "D" Then
                    Me.BindingContext(Me.tbl_TrnJurnaldetil_Debit).AddNew()
                    DgvTrnJurnaldetil_Debit.Rows(DgvTrnJurnaldetil_Debit.CurrentCell.RowIndex).Cells("jurnaldetil_descr").Value = DataTempAll.Rows(i).Item("desc")
                    DgvTrnJurnaldetil_Debit.Rows(DgvTrnJurnaldetil_Debit.CurrentCell.RowIndex).Cells("acc_id").Value = DataTempAll.Rows(i).Item("acc_id")
                    DgvTrnJurnaldetil_Debit.Rows(DgvTrnJurnaldetil_Debit.CurrentCell.RowIndex).Cells("currency_id").Value = DataTempAll.Rows(i).Item("currency_id")
                    DgvTrnJurnaldetil_Debit.Rows(DgvTrnJurnaldetil_Debit.CurrentCell.RowIndex).Cells("jurnaldetil_foreign").Value = DataTempAll.Rows(i).Item("amount")
                    DgvTrnJurnaldetil_Debit.Rows(DgvTrnJurnaldetil_Debit.CurrentCell.RowIndex).Cells("jurnaldetil_foreignrate").Value = DataTempAll.Rows(i).Item("rate")
                    DgvTrnJurnaldetil_Debit.Rows(DgvTrnJurnaldetil_Debit.CurrentCell.RowIndex).Cells("jurnaldetil_idr").Value = DataTempAll.Rows(i).Item("amount_idr")
                    DgvTrnJurnaldetil_Debit.Rows(DgvTrnJurnaldetil_Debit.CurrentCell.RowIndex).Cells("rekanan_id").Value = rekanan_id
                    DgvTrnJurnaldetil_Debit.Rows(DgvTrnJurnaldetil_Debit.CurrentCell.RowIndex).Cells("rekanan_name").Value = rekanan_name
                    DgvTrnJurnaldetil_Debit.Rows(DgvTrnJurnaldetil_Debit.CurrentCell.RowIndex).Cells("budget_id").Value = budget_id
                    DgvTrnJurnaldetil_Debit.Rows(DgvTrnJurnaldetil_Debit.CurrentCell.RowIndex).Cells("budget_name").Value = budget_name
                    DgvTrnJurnaldetil_Debit.Rows(DgvTrnJurnaldetil_Debit.CurrentCell.RowIndex).Cells("budgetdetil_id").Value = budgetdetil_id
                    DgvTrnJurnaldetil_Debit.Rows(DgvTrnJurnaldetil_Debit.CurrentCell.RowIndex).Cells("budgetdetil_name").Value = budgetdetil_name
                    DgvTrnJurnaldetil_Debit.Rows(DgvTrnJurnaldetil_Debit.CurrentCell.RowIndex).Cells("strukturunit_id").Value = DataTempAll.Rows(i).Item("strukturunit_id")
                    DgvTrnJurnaldetil_Debit.Rows(DgvTrnJurnaldetil_Debit.CurrentCell.RowIndex).Cells("ref_id").Value = DataTempAll.Rows(i).Item("ref_id")
                    DgvTrnJurnaldetil_Debit.Rows(DgvTrnJurnaldetil_Debit.CurrentCell.RowIndex).Cells("ref_line").Value = DataTempAll.Rows(i).Item("ref_line")
                End If

            Next

        Catch exc As OleDb.OleDbException
            If exc.ErrorCode.ToString = "-2147467259" Then
                MessageBox.Show("Ubah Nama Sheet1 dengan 'Sheet1'", "Renaming Sheet1", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                MessageBox.Show("There was a problem loading this database. Please contact an administrator if the problem continues." & vbNewLine & vbNewLine & "Error: " & exc.Message)
            End If
        Catch exc As Exception
            MsgBox(exc.ToString)
        Finally
            Cursor = Cursors.Default
        End Try
    End Function
#End Region

#Region "Template Import XLS"
    Private Sub btnTemplateXLS_Click(sender As Object, e As EventArgs) Handles btnTemplateXLS.Click
        Me.TemplateXLS1()
        'Me.TemplateXLS2()
    End Sub

    Private Sub TemplateXLS1()
        Dim dtTemplateExcel As New DataTable
        dtTemplateExcel.Columns.Add("detil")
        dtTemplateExcel.Columns.Add("desc")
        dtTemplateExcel.Columns.Add("acc_id")
        dtTemplateExcel.Columns.Add("currency_id")
        dtTemplateExcel.Columns.Add("amount")
        dtTemplateExcel.Columns.Add("rate")
        dtTemplateExcel.Columns.Add("rekanan_id")
        dtTemplateExcel.Columns.Add("budget_id")
        dtTemplateExcel.Columns.Add("budgetdetil_id")
        dtTemplateExcel.Columns.Add("strukturunit_id")

        Dim path As String
        path = System.IO.Path.GetTempPath + "TemplateJV_XLS.xlsx"

        Me.ExportToExcel(dtTemplateExcel, path)
    End Sub

    Private Sub TemplateXLS2()
        Dim dtTemplateExcel As New DataTable
        dtTemplateExcel.Columns.Add("detil")
        dtTemplateExcel.Columns.Add("desc")
        dtTemplateExcel.Columns.Add("acc_id")
        dtTemplateExcel.Columns.Add("currency_id")
        dtTemplateExcel.Columns.Add("amount")
        dtTemplateExcel.Columns.Add("rate")
        dtTemplateExcel.Columns.Add("amount_idr")
        dtTemplateExcel.Columns.Add("rekanan_id")
        dtTemplateExcel.Columns.Add("budget_id")
        dtTemplateExcel.Columns.Add("budgetdetil_id")
        dtTemplateExcel.Columns.Add("strukturunit_id")
        dtTemplateExcel.Columns.Add("ref_id")
        dtTemplateExcel.Columns.Add("ref_line")


        Dim path As String
        path = System.IO.Path.GetTempPath + "TemplateJV_XLS.xlsx"

        Me.ExportToExcel(dtTemplateExcel, path)
    End Sub
#End Region

#Region "Export To Excel"
    Private Sub ExportToExcel(ByVal dtTemp As DataTable, ByVal filepath As String)
        Dim _excel As New Excel.Application
        Dim wBook As Excel.Workbook
        Dim wSheet As Excel.Worksheet

        Dim strFileName As String = filepath

        wBook = _excel.Workbooks.Add()
        wSheet = wBook.ActiveSheet()

        Dim dt As System.Data.DataTable = dtTemp
        Dim dc As System.Data.DataColumn
        Dim dr As System.Data.DataRow
        Dim colIndex As Integer = 0
        Dim rowIndex As Integer = 0

        For Each dc In dt.Columns
            colIndex = colIndex + 1
            wSheet.Cells(1, colIndex) = dc.ColumnName
        Next

        For Each dr In dt.Rows
            rowIndex = rowIndex + 1
            colIndex = 0
            For Each dc In dt.Columns
                colIndex = colIndex + 1
                wSheet.Cells(rowIndex + 1, colIndex) = dr(dc.ColumnName)
            Next
        Next
        _excel.Application.Visible = True
        wSheet.Columns.AutoFit()
        GC.Collect()
    End Sub
#End Region

    Private Sub obj_Periode_id_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles obj_Periode_id.SelectionChangeCommitted
        Dim periode As String
        periode = Me.obj_Periode_id.SelectedValue.ToString.Substring(Me.obj_Periode_id.SelectedValue.ToString.Length - 2)
        Dim rows() As DataRow = Me.tbl_MstPeriode.Select(" periode_id = " & Me.obj_Periode_id.SelectedValue.ToString)
        If periode > 12 Then
            Me.obj_Jurnal_bookdate.Enabled = False
            If rows.Length > 0 Then
                Me.obj_Jurnal_bookdate.Value = rows(0).Item("periode_dateend")
                Me.obj_Jurnal_duedate.Value = rows(0).Item("periode_dateend")
                Me.obj_Jurnal_billdate.Value = rows(0).Item("periode_dateend")
            End If
        Else
            Me.obj_Jurnal_bookdate.Enabled = True
        End If
    End Sub

End Class