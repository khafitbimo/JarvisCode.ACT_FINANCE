' Created Date: 10/15/2010 1:52 PM
Imports Microsoft.Win32
Imports System.Threading
Imports System.ComponentModel
Public Class uiTrnJurnal_PV_AdvanceTravel
    Implements ILocking
    Private Const mUiName As String = "Transaksi Jurnal PV Advance (List SPD)"
    Private Const SHOW_SAVE_CONFIRMATION As Boolean = True

    Private Const ConstMyJurnalType As String = "PV"
    Private ConstMyJurnalSource As String = clsSource.PVListTravel

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
    Private tbl_TrnJurnaldetil_Debit As DataTable = clsDataset.CreateTblTrnJurnaldetil()
    Private tbl_TrnJurnaldetil_Credit As DataTable = clsDataset.CreateTblTrnJurnaldetilBilyet()
    Private tbl_TrnJurnalReference As DataTable = clsDataset.CreateTblTrnJurnalreferencePayable()
    Private tbl_TrnJurnalResponse As DataTable = clsDataset.CreateTblTrnJurnalreference()
    Private tbl_TrnBankTransfer As DataTable = clsDataset.CreateTblTrnBanktransfer()
    Private tbl_TrnBankTransferGrid As DataTable = clsDataset.CreateTblTrnBanktransfer2()
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
    Private tbl_MstPurposeFund As DataTable = clsDataset.CreateTblMstPurposefundCombo()
    Private tbl_MstRekananGrid As DataTable = clsDataset.CreateTblMstRekananCombo()
    Private tbl_MstSlipFormat As DataTable = clsDataset.CreateTblMstSlipformatCombo()
    Private tbl_MstStrukturunitGrid As DataTable = clsDataset.CreateTblMstStrukturunitCombo()
    Private tbl_TrnBudgetdetilGrid As DataTable = clsDataset.CreateTblMstBudgetdetilCombo()
    Private tbl_TrnBudgetGrid As DataTable = clsDataset.CreateTblMstBudgetCombo()

    Private tbl_MstShow As DataTable = clsDataset.CreateTblMstShowCombo

    Private tbl_TrnAdvance As DataTable = clsDataset.CreateTblTrnAdvance()
    Private tbl_TrnAdvanceDetil As DataTable = clsDataset.CreateTblTrnAdvancedetil()
    Private tbl_TrnAdvanceItemDetil As DataTable = clsDataset.CreateTblTrnAdvanceItemDetil()
    Private tbl_PrintAdvanceListOrderDetil As DataTable = clsDataset.CreateTblTrnPrintAdvanceListOrder()

    'variable for jurnal document
    Private tbl_trnJurnalDocument As DataTable = clsDataset.CreateTblTrnJurnalDocument

    '====ADD PTS 20130711====
    Private tbl_TrnContract As DataTable = clsDataset.CreateTblTrnContract()
    '========================

    'variable for jurnal detil invoice
    Private tbl_trnJurnalRefTandaTerima As DataTable = clsDataset.CreateTblJurnalInvoice

    'Variable For BackgroundWorker
    Private isBackgroundWorker As Boolean = False
    Private isBackGroundWorker_isWork As Boolean = False
    Private isLoadComboInLoadData As Boolean = False
    Private label_thread As String

    'Variable For Additional Button
    Friend WithEvents btnPost As ToolStripButton = New ToolStripButton
    Friend WithEvents btnUnPost As ToolStripButton = New ToolStripButton

    'Variable For print
    Private tbl_Print As DataTable = clsDataset.CreateTblTrnJurnal
    Private tbl_PrintDetil As DataTable = clsDataset.CreateTblTrnJurnaldetil
    Private objPrintHeader As DataSource.clsRptJurnal_Header
    Private objPrintDetil As DataSource.clsRptJurnal_Detil
    Private objPrintHeaderAdvance As DataSource.ClsRptAdvanceHeader
    Private objPrintDetilAdvance As DataSource.ClsRptAdvanceDetil

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

    'tambahan by ari 26 maret 2012
    Private tbl_TrnBankentrydetil As DataTable = clsDataset.CreateTblTrnBankentrydetilReference() 'clsDataset.CreateTblTrnBankentrydetil()
    Private tbl_Payment_type As DataTable = New DataTable
    Private akun8002000 As String
    Private akun8009990 As String
    Private akun8500015 As String
    Private akun8509990 As String
    Private akun8001000 As String
    Private akun8500011 As String

    Private channel_number As String

    '==== ADD PTS 20150528 =======
    Friend WithEvents btnSettingPrinterGiro As ToolStripButton = New ToolStripButton
    '=============================

    '========UNTUK DI DEBIT===========================================
    Private akunBiayaLainLainKerugianSelisihKurs As Integer = 7102110
    Private akunBiayaLainlainKerugianSelisihKursPajak As Integer = 7102120

    '========UNTUK DI KREDIT =========================================
    Private akunKeuntunganLainlainSelisihKurs As Integer = 7202110
    Private akunKeuntunganLainlainSelisihKursPajak As Integer = 7202120


    Private ref As String
    Private total_amount As Decimal
    Private sptchannel_domainname As String

    Private sptChannel_telp1 As String
    Private adv_req As Decimal
    Private sptDomain As String
    Private budget_id As Decimal

    Private approved1_by As String
    Private approved2_by As String
    Private approved3_by As String
    Private approved4_by As String
    Private approved5_by As String
    Private approved6_by As String
    Private approved7_by As String

    Private titleapp1 As String
    Private titleapp2 As String
    Private titleapp3 As String
    Private titleapp4 As String
    Private titleapp5 As String
    Private titleapp6 As String
    Private titleapp7 As String
    Private sptChannel_fax As String
    Private locking As clsLockingTransaction

#Region " Window Parameter "
    Private _CHANNEL As String = "TAS"
    Private _CHANNEL_CANBE_CHANGED As Boolean = False
    Private _CHANNEL_CANBE_BROWSED As Boolean = False

    ' TODO: Buat variabel untuk menampung parameter window 
    Private _SOURCE As String = ConstMyJurnalSource
    Private _USER_TYPE As String = "STAFF" '"STAFF" ' 

    'prodtype_budget
    '1	Production	Production
    '2	News	News
    '3	Join	Join
    '4	Others	Others
    '5	Innovation	Innovation
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

        '===================== NANYA DULU ==========================
        Dim obj As ToolStripButton = sender
        Dim stringnanya As String = ""
        If obj.Name = "btnPost" Then
            stringnanya = Me.tanya_date_sebelum_posting()
            If stringnanya <> "" Then
                Dim nanya As String = MsgBox(stringnanya, MsgBoxStyle.YesNo, "Posting Confirm !")
                If nanya = MsgBoxResult.No Then
                    Exit Sub
                End If
            End If
        End If
        '===========================================================

        System.Windows.Forms.Cursor.Current = Cursors.WaitCursor
        If Me.uiTrnJurnal_PV_Advance_FormError() Then
            System.Windows.Forms.Cursor.Current = Cursors.Default
            Exit Sub
        End If

        'Dim obj As ToolStripButton = sender
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbCmd As OleDb.OleDbCommand
        Dim UnSuccessfully_alert As String = String.Empty
        Dim tbl_TrnJurnalReference_temps As DataTable = New DataTable
        'Dim k As Integer

        If obj.Name = "btnPost" Then

            ''---------- Cek ada perubahan header/debet/credit atau tidak -----------'' 
            Dim tbl_TrnJurnal_Changes_Post As DataTable
            Dim tbl_TrnJurnaldetil_Debit_Changes_Post As DataTable
            Dim tbl_TrnJurnaldetil_Credit_Changes_Post As DataTable

            Me.BindingContext(Me.tbl_TrnJurnal_Temp).EndCurrentEdit()
            tbl_TrnJurnal_Changes_Post = Me.tbl_TrnJurnal_Temp.GetChanges()
            Me.BindingContext(Me.tbl_TrnJurnal_Temp).EndCurrentEdit()

            Me.DgvTrnJurnaldetil_Debit.EndEdit()
            Me.BindingContext(Me.tbl_TrnJurnaldetil_Debit).EndCurrentEdit()
            tbl_TrnJurnaldetil_Debit_Changes_Post = Me.tbl_TrnJurnaldetil_Debit.GetChanges()

            Me.DgvTrnJurnaldetil_Credit.EndEdit()
            Me.BindingContext(Me.tbl_TrnJurnaldetil_Credit).EndCurrentEdit()
            tbl_TrnJurnaldetil_Credit_Changes_Post = Me.tbl_TrnJurnaldetil_Credit.GetChanges

            If tbl_TrnJurnal_Changes_Post IsNot Nothing _
                Or tbl_TrnJurnaldetil_Credit_Changes_Post IsNot Nothing _
                Or tbl_TrnJurnaldetil_Debit_Changes_Post IsNot Nothing Then

                ''---save dulu jika ada perubahan
                Me.uiTrnJurnal_PV_Advance_Save()

            End If
            ''---------- End -----------'' 

            ''----- Cek Balance Tabel Jurnal ------

            ' cek balance posting
            If Me._USER_TYPE = "SPV" Then
                Dim message As String = ""
                If Me.obj_Jurnal_id.Text <> "" Then
                    Dim tbl_Unbalance As DataTable = New DataTable
                    tbl_Unbalance.Clear()
                    Me.DataFill(tbl_Unbalance, "jurnal_UnBalance_A", Me.obj_Jurnal_id.Text)

                    If tbl_Unbalance.Rows.Count > 0 Then
                        Me.obj_Selisih.Text = String.Format("{0:#,##0}", tbl_Unbalance.Rows(0).Item("amount_idr"))
                        Me.obj_Selisih_Foreign.Text = String.Format("{0:#,##0}", tbl_Unbalance.Rows(0).Item("amount_foreign"))
                        message = "Debit and credit isn't balance!!"
                        Me.objFormError.SetError(Me.obj_Selisih, message)
                        Me.objFormError.SetError(Me.obj_Selisih_Foreign, message)
                        MsgBox(message, MsgBoxStyle.Critical, "isn't Balance !!!")
                        Exit Sub
                    Else
                        Me.objFormError.SetError(Me.obj_Selisih, "")
                    End If
                End If
            End If
            ''----- End Cek Balance Tabel ---------

            dbCmd = New OleDb.OleDbCommand("act_TrnJurnal_Posting", dbConn)
            dbCmd.CommandType = CommandType.StoredProcedure
            dbCmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_id", System.Data.OleDb.OleDbType.VarWChar, 4000))
            dbCmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_postby", System.Data.OleDb.OleDbType.VarWChar, 32))
            dbCmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("@posting_method", System.Data.OleDb.OleDbType.VarWChar, 32))
            dbCmd.Parameters("@jurnal_id").Value = String.Format(" jurnal_id = '{0}'", Me.obj_Jurnal_id.Text)
            dbCmd.Parameters("@jurnal_postby").Value = Me.UserName
            dbCmd.Parameters("@posting_method").Value = "POSTING"

            Dim cookie As Byte() = Nothing

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
            Catch ex As Data.OleDb.OleDbException
                MessageBox.Show(ex.Message, "OLE DB Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "OLE DB Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Finally
                clsApplicationRole.UnsetAppRole(dbConn, cookie)
                dbConn.Close()
            End Try
        Else
            'tbl_TrnJurnalReference_temps.Clear()
            If Me.UserName <> clsUtil.IsDbNull(Me.DgvTrnJurnal.Rows(Me.DgvTrnJurnal.CurrentRow.Index).Cells("jurnal_ispostedby").Value, String.Empty) Then
                '    'Me.DataFill(tbl_TrnJurnalReference_temps, "act_TrnJurnalResponse_Select", Me.DgvTrnJurnal.Rows(Me.DgvTrnJurnal.CurrentRow.Index).Cells("jurnal_id").Value, Me._CHANNEL)
                '    Me.DataFill(tbl_TrnJurnalReference_temps, "act_TrnJurnalResponse_ChangeUser_Select", Me.DgvTrnJurnal.Rows(Me.DgvTrnJurnal.CurrentRow.Index).Cells("jurnal_id").Value, Me._CHANNEL)
                '    If tbl_TrnJurnalReference_temps.Rows.Count > 0 Then
                '        For k = 0 To tbl_TrnJurnalReference_temps.Rows.Count - 1
                '            If UnSuccessfully_alert = String.Empty Or k = 0 Then
                '                UnSuccessfully_alert = UnSuccessfully_alert & Me.DgvTrnJurnal.Rows(Me.DgvTrnJurnal.CurrentRow.Index).Cells("jurnal_id").Value & " Have response " & tbl_TrnJurnalReference_temps.Rows(k).Item("ref")
                '            Else
                '                UnSuccessfully_alert = UnSuccessfully_alert & ", " & Me.DgvTrnJurnal.Rows(Me.DgvTrnJurnal.CurrentRow.Index).Cells("jurnal_id").Value
                '            End If
                '        Next
                '        MsgBox(UnSuccessfully_alert)
                '        Exit Sub
                '    End If
                'Else
                MsgBox("Access Denied")
                Exit Sub
            End If

            dbCmd = New OleDb.OleDbCommand("act_TrnJurnal_Posting", dbConn)
            dbCmd.CommandType = CommandType.StoredProcedure
            dbCmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_id_temps", System.Data.OleDb.OleDbType.VarWChar, 4000))
            dbCmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_postby", System.Data.OleDb.OleDbType.VarWChar, 32))
            dbCmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("@posting_method", System.Data.OleDb.OleDbType.VarWChar, 32))
            dbCmd.Parameters("@jurnal_id_temps").Value = String.Format(" jurnal_id = '{0}'", Me.obj_Jurnal_id.Text)
            dbCmd.Parameters("@jurnal_postby").Value = Me.UserName
            dbCmd.Parameters("@posting_method").Value = "UNPOSTING"

            Dim cookie As Byte() = Nothing

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
            Catch ex As Data.OleDb.OleDbException
                MessageBox.Show(ex.Message, "OLE DB Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "OLE DB Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Finally
                clsApplicationRole.UnsetAppRole(dbConn, cookie)
                dbConn.Close()
            End Try
        End If

        Dim clsdocument As New clsTrnDocument(DSN, Me._CHANNEL)
        Me.obj_document_id.Text = clsdocument.filltextbox(Me.obj_Jurnal_id.Text.Trim)

        System.Windows.Forms.Cursor.Current = Cursors.Default
    End Sub

    Private Sub btn_ListAdvance_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_ListAdvance.Click
        Me.DialogOpen_Reference_Advance()
        'Me.DialogOpen_Reference_AdvanceOrder()
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
            Me.uiTrnJurnal_PV_Advance_NewData()
            Me.obj_Currency_id.SelectedValue = 1
            Me.obj_Budget_id.SelectedValue = 0
        Else
            Dim Message As String = "Data has been changed. " & vbCrLf & " Are you sure want to new data ?"
            Dim tbl_TrnJurnal_Temp_Changes As DataTable
            Dim tbl_TrnJurnalReference_Changes As DataTable
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

                Me.BindingContext(Me.tbl_TrnJurnalReference).EndCurrentEdit()
                tbl_TrnJurnalReference_Changes = Me.tbl_TrnJurnalReference.GetChanges()

                If tbl_TrnJurnal_Temp_Changes IsNot Nothing Or tbl_TrnJurnalReference_Changes IsNot Nothing Or tbl_TrnJurnaldetil_Debit_Changes IsNot Nothing Or tbl_TrnJurnaldetil_Credit_Changes IsNot Nothing Then
                    res = MessageBox.Show(Message, "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    Select Case res
                        Case DialogResult.Yes
                            Me.uiTrnJurnal_PV_Advance_NewData()
                            Me.obj_Currency_id.SelectedValue = 1
                            Me.obj_Budget_id.SelectedValue = 0
                            'Me.tbtnDel.Enabled = True
                            Me.tbtnSave.Enabled = True
                            Me.btnPost.Visible = True
                            Me.btnUnPost.Visible = False
                    End Select
                Else
                    Me.uiTrnJurnal_PV_Advance_NewData()
                    Me.obj_Currency_id.SelectedValue = 1
                    Me.obj_Budget_id.SelectedValue = 0
                    'Me.tbtnDel.Enabled = True
                    Me.tbtnSave.Enabled = True
                    Me.btnPost.Visible = True
                    Me.btnUnPost.Visible = False
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

                Me.BindingContext(Me.tbl_TrnJurnalReference).EndCurrentEdit()
                tbl_TrnJurnalReference_Changes = Me.tbl_TrnJurnalReference.GetChanges()

                If tbl_TrnJurnal_Temp_Changes IsNot Nothing Or tbl_TrnJurnalReference_Changes IsNot Nothing Or tbl_TrnJurnaldetil_Debit_Changes IsNot Nothing Or tbl_TrnJurnaldetil_Credit_Changes IsNot Nothing Then
                    res = MessageBox.Show(Message, mUiName, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    Select Case res
                        Case DialogResult.Yes
                            Me.uiTrnJurnal_PV_Advance_NewData()
                            Me.obj_Currency_id.SelectedValue = 1
                            Me.obj_Budget_id.SelectedValue = 0
                            Me.tbtnDel.Enabled = True
                            Me.tbtnSave.Enabled = True
                            Me.btnPost.Visible = True
                            Me.btnUnPost.Visible = False
                    End Select
                End If
            End If
        End If

        Me.Cursor = Cursors.Arrow
        Return MyBase.btnNew_Click()
    End Function

    Public Overrides Function btnLoad_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnJurnal_PV_Advance_Retrieve()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnLoad_Click()
    End Function

    Public Overrides Function btnSave_Click() As Boolean
        If Me.uiTrnJurnal_PV_Advance_FormError() Then
            Return True
        End If

        Call cek_BankLinkBeforeSave()
    End Function

    Public Overrides Function btnPrint_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnJurnal_PV_Advance_Print()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnPrint_Click()
    End Function

    Public Overrides Function btnPrintPreview_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnJurnal_PV_Advance_PrintPreview()
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
            Me.uiTrnJurnal_PV_Advance_Delete()
        End If
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnDel_Click()
    End Function

    Public Overrides Function btnFirst_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnJurnal_PV_Advance_First()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnFirst_Click()
    End Function

    Public Overrides Function btnPrev_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnJurnal_PV_Advance_Prev()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnPrev_Click()
    End Function

    Public Overrides Function btnNext_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnJurnal_PV_Advance_Next()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnNext_Click()
    End Function

    Public Overrides Function btnLast_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnJurnal_PV_Advance_Last()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnLast_Click()
    End Function
#End Region

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
        Dim cCirculation_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
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
        cCirculation_id.Name = "circulation_id"
        cCirculation_id.HeaderText = "CV. ID"
        cCirculation_id.DataPropertyName = "circulation_id"
        cCirculation_id.Width = 90
        cCirculation_id.Visible = True
        cCirculation_id.ReadOnly = True

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
        {cJurnal_id, cCirculation_id, cJurnal_bookdate, cJurnal_duedate, cJurnal_billdate, cJurnal_descr, cRekanan_name, cRekanan_id, _
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
        ' ''objDgv.Columns("circulation_id").Frozen = True
        ' ''objDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        objDgv.Columns("circulation_id").Frozen = True
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
        cAcc_id.Width = 200
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
        '  cJurnaldetil_foreignrate.DefaultCellStyle.BackColor = Color.LightYellow
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
        cStrukturunit_id.ReadOnly = True
        cStrukturunit_id.DataSource = Me.tbl_MstStrukturunitGrid
        cStrukturunit_id.DisplayMember = "strukturunit_name"
        cStrukturunit_id.ValueMember = "strukturunit_id"
        cStrukturunit_id.DisplayStyleForCurrentCellOnly = True
        cStrukturunit_id.DefaultCellStyle.BackColor = Color.LightYellow

        cRef_id.Name = "ref_id"
        cRef_id.HeaderText = "Ref ID"
        cRef_id.DataPropertyName = "ref_id"
        cRef_id.Width = 100
        cRef_id.Visible = True
        cRef_id.ReadOnly = True
        cRef_id.DefaultCellStyle.BackColor = Color.LightYellow

        cRef_line.Name = "ref_line"
        cRef_line.HeaderText = "Ref.Ln"
        cRef_line.DataPropertyName = "ref_line"
        cRef_line.Width = 50
        cRef_line.Visible = True
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
        cBudget_id.ReadOnly = True
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
        cBudget_button.Visible = False
        cBudget_button.ReadOnly = False


        cBudgetdetil_id.Name = "budgetdetil_id"
        cBudgetdetil_id.HeaderText = "Budget Detil ID"
        cBudgetdetil_id.DataPropertyName = "budgetdetil_id"
        cBudgetdetil_id.Width = 110
        cBudgetdetil_id.Visible = False
        cBudgetdetil_id.ReadOnly = True
        cBudgetdetil_id.DefaultCellStyle.BackColor = Color.LightYellow

        cBudgetdetil_name.Name = "budgetdetil_name"
        cBudgetdetil_name.HeaderText = "Budget Detil Name"
        cBudgetdetil_name.DataPropertyName = "budgetdetil_name"
        cBudgetdetil_name.Width = 150
        cBudgetdetil_name.Visible = False
        cBudgetdetil_name.ReadOnly = True
        cBudgetdetil_name.DefaultCellStyle.BackColor = Color.LightYellow

        cBudgetdetil_button.Name = "select_budget_detil"
        cBudgetdetil_button.HeaderText = ""
        cBudgetdetil_button.Text = "..."
        cBudgetdetil_button.UseColumnTextForButtonValue = True
        cBudgetdetil_button.CellTemplate.Style.BackColor = Color.LightGray
        cBudgetdetil_button.Width = 30
        cBudgetdetil_button.DividerWidth = 3
        cBudgetdetil_button.Visible = False
        cBudgetdetil_button.ReadOnly = False


        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
        {cJurnaldetil_line, cAcc_id, cAcc_no, cJurnaldetil_descr, _
         cCurrency_id, cJurnaldetil_foreign, cJurnaldetil_foreignrate, cJurnaldetil_idr, _
         cRekanan_id, cRekanan_name, cRekanan_button, cJurnal_id, cJurnaldetil_dk, _
         cChannel_id, _
          cRef_id, cRef_line, cRef_budgetline, cRegion_id, cBranch_id, _
         cBudget_id, cBudget_name, cBudget_button, _
         cBudgetdetil_id, cBudgetdetil_name, cBudgetdetil_button, cStrukturunit_id})
        objDgv.AutoGenerateColumns = False
        objDgv.Columns("acc_id").Frozen = True
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
        Dim cBranch_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBudget_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBudget_name As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBudget_button As System.Windows.Forms.DataGridViewButtonColumn = New System.Windows.Forms.DataGridViewButtonColumn
        Dim cBudgetdetil_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBudgetdetil_name As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBudgetdetil_button As System.Windows.Forms.DataGridViewButtonColumn = New System.Windows.Forms.DataGridViewButtonColumn
        Dim cCAacc_id As System.Windows.Forms.DataGridViewComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn
        Dim cCAacc_nm As System.Windows.Forms.DataGridViewComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn

        ' ''Kolom tambahan Dari Tabel transaksi_jurnalbilyet
        Dim cPaymenttype_id As System.Windows.Forms.DataGridViewComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn
        Dim cBank_id As System.Windows.Forms.DataGridViewComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn
        Dim cJurnaldetil_bilyetno As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnaldetil_bilyetdate As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnaldetil_bilyetdateefective As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnaldetil_bilyetperson As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnaldetil_bilyetpic As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cButton_ReceivedBy As New System.Windows.Forms.DataGridViewButtonColumn

        '======================== ADD PTS 20150527 ====================================================================================
        Dim cButtonPrint_GiroCek As System.Windows.Forms.DataGridViewButtonColumn = New System.Windows.Forms.DataGridViewButtonColumn
        '==============================================================================================================================

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
        cAcc_id.Width = 200
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
        ' cJurnaldetil_foreignrate.DefaultCellStyle.BackColor = Color.LightYellow
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
        cStrukturunit_id.Visible = False
        cStrukturunit_id.ReadOnly = True
        cStrukturunit_id.DataSource = Me.tbl_MstStrukturunitGrid
        cStrukturunit_id.DisplayMember = "strukturunit_name"
        cStrukturunit_id.ValueMember = "strukturunit_id"
        cStrukturunit_id.DisplayStyleForCurrentCellOnly = True
        cStrukturunit_id.DefaultCellStyle.BackColor = Color.LightYellow

        cRef_id.Name = "ref_id"
        cRef_id.HeaderText = "Ref ID"
        cRef_id.DataPropertyName = "ref_id"
        cRef_id.Width = 100
        cRef_id.Visible = True
        cRef_id.ReadOnly = True
        cRef_id.DefaultCellStyle.BackColor = Color.LightYellow

        cRef_line.Name = "ref_line"
        cRef_line.HeaderText = "Ref.Ln"
        cRef_line.DataPropertyName = "ref_line"
        cRef_line.Width = 50
        cRef_line.Visible = True
        cRef_line.ReadOnly = True
        cRef_line.DefaultCellStyle.BackColor = Color.LightYellow

        cRef_budgetline.Name = "ref_budgetline"
        cRef_budgetline.HeaderText = "Ref.BudgetLn"
        cRef_budgetline.DataPropertyName = "ref_budgetline"
        cRef_budgetline.Width = 80
        cRef_budgetline.Visible = False
        cRef_budgetline.ReadOnly = True
        cRef_budgetline.DefaultCellStyle.BackColor = Color.LightYellow

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
        cBudget_id.Visible = False
        cBudget_id.ReadOnly = True
        cBudget_id.DefaultCellStyle.BackColor = Color.LightYellow

        cBudget_name.Name = "budget_name"
        cBudget_name.HeaderText = "Budget Name"
        cBudget_name.DataPropertyName = "budget_name"
        cBudget_name.Width = 150
        cBudget_name.Visible = False
        cBudget_name.ReadOnly = True
        cBudget_name.DefaultCellStyle.BackColor = Color.LightYellow

        cBudget_button.Name = "select_budget"
        cBudget_button.HeaderText = ""
        cBudget_button.Text = "..."
        cBudget_button.UseColumnTextForButtonValue = True
        cBudget_button.CellTemplate.Style.BackColor = Color.LightGray
        cBudget_button.Width = 30
        cBudget_button.DividerWidth = 3
        cBudget_button.Visible = False
        cBudget_button.ReadOnly = False


        cBudgetdetil_id.Name = "budgetdetil_id"
        cBudgetdetil_id.HeaderText = "Budget Detil ID"
        cBudgetdetil_id.DataPropertyName = "budgetdetil_id"
        cBudgetdetil_id.Width = 110
        cBudgetdetil_id.Visible = False
        cBudgetdetil_id.ReadOnly = True
        cBudgetdetil_id.DefaultCellStyle.BackColor = Color.LightYellow

        cBudgetdetil_name.Name = "budgetdetil_name"
        cBudgetdetil_name.HeaderText = "Budget Detil Name"
        cBudgetdetil_name.DataPropertyName = "budgetdetil_name"
        cBudgetdetil_name.Width = 150
        cBudgetdetil_name.Visible = False
        cBudgetdetil_name.ReadOnly = True
        cBudgetdetil_name.DefaultCellStyle.BackColor = Color.LightYellow

        cBudgetdetil_button.Name = "select_budget_detil"
        cBudgetdetil_button.HeaderText = ""
        cBudgetdetil_button.Text = "..."
        cBudgetdetil_button.UseColumnTextForButtonValue = True
        cBudgetdetil_button.CellTemplate.Style.BackColor = Color.LightGray
        cBudgetdetil_button.Width = 30
        cBudgetdetil_button.DividerWidth = 3
        cBudgetdetil_button.Visible = False
        cBudgetdetil_button.ReadOnly = False

        ' ''Kolom tambahan Dari Tabel transaksi_jurnalbilyet
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
        cJurnaldetil_bilyetno.Visible = True
        cJurnaldetil_bilyetno.ReadOnly = False

        cJurnaldetil_bilyetdate.Name = "jurnalbilyet_date"
        cJurnaldetil_bilyetdate.HeaderText = "Tgl Bilyet"
        cJurnaldetil_bilyetdate.DataPropertyName = "jurnalbilyet_date"
        cJurnaldetil_bilyetdate.Width = 100
        cJurnaldetil_bilyetdate.Visible = True
        cJurnaldetil_bilyetdate.ReadOnly = False
        cJurnaldetil_bilyetdate.DefaultCellStyle.Format = "dd/MM/yyyy"

        cJurnaldetil_bilyetdateefective.Name = "jurnalbilyet_dateeffective"
        cJurnaldetil_bilyetdateefective.HeaderText = "Tgl Efektif"
        cJurnaldetil_bilyetdateefective.DataPropertyName = "jurnalbilyet_dateeffective"
        cJurnaldetil_bilyetdateefective.Width = 100
        cJurnaldetil_bilyetdateefective.Visible = True
        cJurnaldetil_bilyetdateefective.ReadOnly = False
        cJurnaldetil_bilyetdateefective.DefaultCellStyle.Format = "dd/MM/yyyy"

        cJurnaldetil_bilyetperson.Name = "jurnalbilyet_receiveperson"
        cJurnaldetil_bilyetperson.HeaderText = "Received By"
        cJurnaldetil_bilyetperson.DataPropertyName = "jurnalbilyet_receiveperson"
        cJurnaldetil_bilyetperson.Width = 150
        cJurnaldetil_bilyetperson.Visible = True
        cJurnaldetil_bilyetperson.ReadOnly = False

        cJurnaldetil_bilyetpic.Name = "jurnalbilyet_pic"
        cJurnaldetil_bilyetpic.HeaderText = "Penanggung Jawab"
        cJurnaldetil_bilyetpic.DataPropertyName = "jurnalbilyet_pic"
        cJurnaldetil_bilyetpic.Width = 100
        cJurnaldetil_bilyetpic.Visible = False
        cJurnaldetil_bilyetpic.ReadOnly = False

        cButton_ReceivedBy.Name = "select_received"
        cButton_ReceivedBy.HeaderText = "Transfer"
        cButton_ReceivedBy.Text = "..."
        cButton_ReceivedBy.UseColumnTextForButtonValue = True
        cButton_ReceivedBy.CellTemplate.Style.BackColor = Color.LightGray
        cButton_ReceivedBy.Width = 70
        cButton_ReceivedBy.DividerWidth = 3
        cButton_ReceivedBy.Visible = True
        cButton_ReceivedBy.ReadOnly = False

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

        '=========== ADD PTS 20150528 =============
        cButtonPrint_GiroCek.Name = "print_giro_cek"
        cButtonPrint_GiroCek.HeaderText = "G/C"
        'cButtonPrint_GiroCek.Text = "Print"
        'cButtonPrint_GiroCek.UseColumnTextForButtonValue = True
        cButtonPrint_GiroCek.CellTemplate.Style.BackColor = Color.LightGray
        cButtonPrint_GiroCek.Width = 40
        cButtonPrint_GiroCek.DividerWidth = 3
        cButtonPrint_GiroCek.Visible = True
        cButtonPrint_GiroCek.ReadOnly = False
        cButtonPrint_GiroCek.ToolTipText = "Print Giro Or Cek"
        '==========================================

        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
        {cJurnaldetil_line, cAcc_id, cAcc_no, cJurnaldetil_descr, _
         cCurrency_id, cJurnaldetil_foreign, cJurnaldetil_foreignrate, cJurnaldetil_idr, _
         cRekanan_id, cRekanan_name, cRekanan_button, cJurnal_id, cJurnaldetil_dk, _
         cChannel_id, _
          cRef_id, cRef_line, cRef_budgetline, cBranch_id, _
         cBudget_id, cBudget_name, cBudget_button, _
         cBudgetdetil_id, cBudgetdetil_name, cBudgetdetil_button, cStrukturunit_id, _
          cPaymenttype_id, cBank_id, _
        cJurnaldetil_bilyetno, cJurnaldetil_bilyetdate, cButtonPrint_GiroCek, _
        cJurnaldetil_bilyetdateefective, cJurnaldetil_bilyetperson, cButton_ReceivedBy, cJurnaldetil_bilyetpic, cCAacc_id, cCAacc_nm})
        objDgv.AutoGenerateColumns = False
        objDgv.Columns("acc_id").Frozen = True
    End Function

    Private Function FormatDgvTrnJurnalreference(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        Dim cJurnal_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnal_line As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnal_budgetline As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnal_descr As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cCurrency_name As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnal_foreignrate As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnal_foreign As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnal_idr As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cStrukturunit_name As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cChannel_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekanan_name As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cLineJurnal As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn



        cLineJurnal.Name = "jurnaldetil_line"
        cLineJurnal.HeaderText = "Line"
        cLineJurnal.DataPropertyName = "jurnaldetil_line"
        cLineJurnal.Width = 50
        cLineJurnal.Visible = True
        cLineJurnal.ReadOnly = True


        cJurnal_id.Name = "ref"
        cJurnal_id.HeaderText = "Ref"
        cJurnal_id.DataPropertyName = "ref"
        cJurnal_id.Width = 100
        cJurnal_id.Visible = True
        cJurnal_id.ReadOnly = True

        cJurnal_line.Name = "line"
        cJurnal_line.HeaderText = "Ref Line"
        cJurnal_line.DataPropertyName = "line"
        cJurnal_line.Width = 75
        cJurnal_line.Visible = True
        cJurnal_line.ReadOnly = True

        cJurnal_budgetline.Name = "budget_line"
        cJurnal_budgetline.HeaderText = "Budget Line"
        cJurnal_budgetline.DataPropertyName = "budget_line"
        cJurnal_budgetline.Width = 95
        cJurnal_budgetline.Visible = False
        cJurnal_budgetline.ReadOnly = True

        cJurnal_descr.Name = "descr"
        cJurnal_descr.HeaderText = "Descr"
        cJurnal_descr.DataPropertyName = "descr"
        cJurnal_descr.Width = 100
        cJurnal_descr.MaxInputLength = 255
        cJurnal_descr.Visible = True
        cJurnal_descr.ReadOnly = True

        cCurrency_name.Name = "currency_name"
        cCurrency_name.HeaderText = "Curr."
        cCurrency_name.DataPropertyName = "currency_name"
        cCurrency_name.Width = 75
        cCurrency_name.MaxInputLength = 255
        cCurrency_name.Visible = True
        cCurrency_name.ReadOnly = True

        cJurnal_foreignrate.Name = "rate"
        cJurnal_foreignrate.HeaderText = "Rate"
        cJurnal_foreignrate.DataPropertyName = "rate"
        cJurnal_foreignrate.Width = 75
        cJurnal_foreignrate.Visible = True
        cJurnal_foreignrate.ReadOnly = True
        cJurnal_foreignrate.DefaultCellStyle.Format = "#,##0.00"
        cJurnal_foreignrate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        cJurnal_idr.Name = "amount_idr"
        cJurnal_idr.HeaderText = "Amount (IDR)"
        cJurnal_idr.DataPropertyName = "amount_idr"
        cJurnal_idr.Width = 100
        cJurnal_idr.Visible = True
        cJurnal_idr.ReadOnly = True
        cJurnal_idr.DefaultCellStyle.Format = "#,##0"
        cJurnal_idr.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        cJurnal_foreign.Name = "amount_foreign"
        cJurnal_foreign.HeaderText = "Amount"
        cJurnal_foreign.DataPropertyName = "amount_foreign"
        cJurnal_foreign.Width = 100
        cJurnal_foreign.Visible = True
        cJurnal_foreign.ReadOnly = True
        cJurnal_foreign.DefaultCellStyle.Format = "#,##0.00"
        cJurnal_foreign.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight


        cStrukturunit_name.Name = "strukturunit_name"
        cStrukturunit_name.HeaderText = "Department"
        cStrukturunit_name.DataPropertyName = "strukturunit_name"
        cStrukturunit_name.Width = 150
        cStrukturunit_name.Visible = True
        cStrukturunit_name.ReadOnly = True

        cRekanan_name.Name = "rekanan_name"
        cRekanan_name.HeaderText = "Partner"
        cRekanan_name.DataPropertyName = "rekanan_name"
        cRekanan_name.Width = 200
        cRekanan_name.Visible = True
        cRekanan_name.ReadOnly = True

        cChannel_id.Name = "channel_id"
        cChannel_id.HeaderText = "Company"
        cChannel_id.DataPropertyName = "channel_id"
        cChannel_id.Width = 100
        cChannel_id.Visible = True
        cChannel_id.ReadOnly = True

        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
        {cLineJurnal, cJurnal_id, cJurnal_line, cJurnal_budgetline, cJurnal_descr, cCurrency_name, cJurnal_foreign, cJurnal_foreignrate, _
         cJurnal_idr, cRekanan_name, cStrukturunit_name, cChannel_id})


        ' DgvTrnJurnal Behaviours: 
        objDgv.AutoGenerateColumns = False
        objDgv.AllowUserToAddRows = False
        objDgv.AllowUserToDeleteRows = False
        objDgv.AllowUserToResizeRows = False
        objDgv.ReadOnly = False
        objDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        objDgv.Columns("line").Frozen = True
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

    'Private Function FormatDgvTrnBanktransfer(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
    '    Dim cBanktransfer_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
    '    Dim cJurnal_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
    '    Dim cJurnaldetil_line As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
    '    Dim cBanktransfer_dt As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
    '    Dim cSlipformat_id As System.Windows.Forms.DataGridViewComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn
    '    Dim cRekanan_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
    '    Dim cRekananbank_line As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
    '    Dim cBanktransfer_rekening As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
    '    Dim cPurposefund_id As System.Windows.Forms.DataGridViewComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn
    '    Dim cPaymenttype_id As System.Windows.Forms.DataGridViewComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn
    '    Dim cBanktransfer_pembayaranrek As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
    '    Dim cBanktransfer_idr As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
    '    Dim cBanktransfer_foreign As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
    '    Dim cBanktransfer_foreignrate As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
    '    Dim cCurrency_id As System.Windows.Forms.DataGridViewComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn
    '    Dim cBanktransfer_bi_idr As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
    '    Dim cBanktransfer_bi_foreign As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
    '    Dim cBanktransfer_message As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
    '    Dim cChannel_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
    '    Dim cBanktransfer_isdisabled As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
    '    Dim cBanktransfer_invoice As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
    '    Dim cBanktransfer_episode1 As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
    '    Dim cBanktransfer_episode2 As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
    '    Dim cProject_id As System.Windows.Forms.DataGridViewComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn
    '    Dim cRekananartis_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
    '    Dim cBanktransfer_episode As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
    '    Dim cChannelbank_line As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
    '    Dim cBanktransfer_create_by As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
    '    Dim cBanktransfer_create_date As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn

    '    Dim cJurnaldetil_bilyetperson As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
    '    Dim cJurnaldetil_bilyetpersonRekening As New System.Windows.Forms.DataGridViewTextBoxColumn
    '    Dim cJurnaldetil_bilyetpersonBank As New System.Windows.Forms.DataGridViewTextBoxColumn
    '    Dim cJurnaldetil_bilyetpersonBankAccountName As New System.Windows.Forms.DataGridViewTextBoxColumn
    '    Dim cButton_Print As New System.Windows.Forms.DataGridViewButtonColumn

    '    Dim cRekening_debit As New System.Windows.Forms.DataGridViewTextBoxColumn
    '    Dim cBank_debit As New System.Windows.Forms.DataGridViewTextBoxColumn
    '    Dim cAccount_bank_debit As New System.Windows.Forms.DataGridViewTextBoxColumn


    '    cBanktransfer_id.Name = "banktransfer_id"
    '    cBanktransfer_id.HeaderText = "ID"
    '    cBanktransfer_id.DataPropertyName = "banktransfer_id"
    '    cBanktransfer_id.Width = 100
    '    cBanktransfer_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
    '    cBanktransfer_id.Visible = True
    '    cBanktransfer_id.ReadOnly = True
    '    ' ''cBanktransfer_id.DefaultCellStyle.BackColor = Color.Gainsboro

    '    cJurnal_id.Name = "jurnal_id"
    '    cJurnal_id.HeaderText = "jurnal_id"
    '    cJurnal_id.DataPropertyName = "jurnal_id"
    '    cJurnal_id.Width = 100
    '    cJurnal_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
    '    cJurnal_id.Visible = False
    '    cJurnal_id.ReadOnly = False

    '    cJurnaldetil_line.Name = "jurnaldetil_line"
    '    cJurnaldetil_line.HeaderText = "jurnaldetil_line"
    '    cJurnaldetil_line.DataPropertyName = "jurnaldetil_line"
    '    cJurnaldetil_line.Width = 100
    '    cJurnaldetil_line.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
    '    cJurnaldetil_line.Visible = False
    '    cJurnaldetil_line.ReadOnly = False

    '    cBanktransfer_dt.Name = "banktransfer_dt"
    '    cBanktransfer_dt.HeaderText = "Trans. Date"
    '    cBanktransfer_dt.DataPropertyName = "banktransfer_dt"
    '    cBanktransfer_dt.Width = 100
    '    cBanktransfer_dt.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
    '    cBanktransfer_dt.Visible = True
    '    cBanktransfer_dt.ReadOnly = True
    '    ' ''cBanktransfer_dt.DefaultCellStyle.BackColor = Color.Gainsboro


    '    cSlipformat_id.Name = "slipformat_id"
    '    cSlipformat_id.HeaderText = "Penggunaan Dana"
    '    cSlipformat_id.DataPropertyName = "slipformat_id"
    '    cSlipformat_id.Width = 180
    '    cSlipformat_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
    '    cSlipformat_id.Visible = True
    '    cSlipformat_id.ReadOnly = False
    '    cSlipformat_id.DataSource = Me.tbl_MstSlipFormat
    '    cSlipformat_id.ValueMember = "slipformat_id"
    '    cSlipformat_id.DisplayMember = "slipformat_name"
    '    cSlipformat_id.DisplayStyleForCurrentCellOnly = True

    '    cRekanan_id.Name = "rekanan_id"
    '    cRekanan_id.HeaderText = "rekanan_id"
    '    cRekanan_id.DataPropertyName = "rekanan_id"
    '    cRekanan_id.Width = 100
    '    cRekanan_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
    '    cRekanan_id.Visible = False
    '    cRekanan_id.ReadOnly = False

    '    cRekananbank_line.Name = "rekananbank_line"
    '    cRekananbank_line.HeaderText = "Bank Line"
    '    cRekananbank_line.DataPropertyName = "rekananbank_line"
    '    cRekananbank_line.Width = 100
    '    cRekananbank_line.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
    '    cRekananbank_line.Visible = False
    '    cRekananbank_line.ReadOnly = False

    '    cBanktransfer_rekening.Name = "banktransfer_rekening"
    '    cBanktransfer_rekening.HeaderText = "banktransfer_rekening"
    '    cBanktransfer_rekening.DataPropertyName = "banktransfer_rekening"
    '    cBanktransfer_rekening.Width = 100
    '    cBanktransfer_rekening.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
    '    cBanktransfer_rekening.Visible = False
    '    cBanktransfer_rekening.ReadOnly = False

    '    cPurposefund_id.Name = "purposefund_id"
    '    cPurposefund_id.HeaderText = "Pengg. Dana"
    '    cPurposefund_id.DataPropertyName = "purposefund_id"
    '    cPurposefund_id.Width = 120
    '    cPurposefund_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
    '    cPurposefund_id.Visible = True
    '    cPurposefund_id.ReadOnly = False
    '    cPurposefund_id.DataSource = Me.tbl_MstPurposeFund
    '    cPurposefund_id.ValueMember = "purposefund_id"
    '    cPurposefund_id.DisplayMember = "purposefund_name"
    '    cPurposefund_id.DisplayStyleForCurrentCellOnly = True

    '    cPaymenttype_id.Name = "paymenttype_id"
    '    cPaymenttype_id.HeaderText = "Payment Type"
    '    cPaymenttype_id.DataPropertyName = "paymenttype_id"
    '    cPaymenttype_id.Width = 100
    '    cPaymenttype_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
    '    cPaymenttype_id.Visible = True
    '    cPaymenttype_id.ReadOnly = True
    '    cPaymenttype_id.DataSource = Me.tbl_MstPaymentTypeGrid
    '    cPaymenttype_id.ValueMember = "paymenttype_id"
    '    cPaymenttype_id.DisplayMember = "paymenttype_name"
    '    cPaymenttype_id.DisplayStyleForCurrentCellOnly = True
    '    ' ''cPaymenttype_id.DefaultCellStyle.BackColor = Color.Gainsboro

    '    cBanktransfer_pembayaranrek.Name = "banktransfer_pembayaranrek"
    '    cBanktransfer_pembayaranrek.HeaderText = "banktransfer_pembayaranrek"
    '    cBanktransfer_pembayaranrek.DataPropertyName = "banktransfer_pembayaranrek"
    '    cBanktransfer_pembayaranrek.Width = 100
    '    cBanktransfer_pembayaranrek.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
    '    cBanktransfer_pembayaranrek.Visible = False
    '    cBanktransfer_pembayaranrek.ReadOnly = False

    '    cBanktransfer_idr.Name = "banktransfer_idr"
    '    cBanktransfer_idr.HeaderText = "Amount IDR"
    '    cBanktransfer_idr.DataPropertyName = "banktransfer_idr"
    '    cBanktransfer_idr.Width = 100
    '    cBanktransfer_idr.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    '    cBanktransfer_idr.Visible = True
    '    cBanktransfer_idr.ReadOnly = True
    '    cBanktransfer_idr.DefaultCellStyle.Format = "#,##0"
    '    ' ''cBanktransfer_idr.DefaultCellStyle.BackColor = Color.Gainsboro

    '    cBanktransfer_foreign.Name = "banktransfer_foreign"
    '    cBanktransfer_foreign.HeaderText = "Amount"
    '    cBanktransfer_foreign.DataPropertyName = "banktransfer_foreign"
    '    cBanktransfer_foreign.Width = 100
    '    cBanktransfer_foreign.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    '    cBanktransfer_foreign.Visible = True
    '    cBanktransfer_foreign.ReadOnly = False
    '    cBanktransfer_foreign.DefaultCellStyle.Format = "#,##0.00"

    '    cBanktransfer_foreignrate.Name = "banktransfer_foreignrate"
    '    cBanktransfer_foreignrate.HeaderText = "Rate"
    '    cBanktransfer_foreignrate.DataPropertyName = "banktransfer_foreignrate"
    '    cBanktransfer_foreignrate.Width = 100
    '    cBanktransfer_foreignrate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    '    cBanktransfer_foreignrate.Visible = True
    '    cBanktransfer_foreignrate.ReadOnly = False
    '    cBanktransfer_foreignrate.DefaultCellStyle.Format = "#,##0.00"


    '    cCurrency_id.Name = "currency_id"
    '    cCurrency_id.HeaderText = "Curr"
    '    cCurrency_id.DataPropertyName = "currency_id"
    '    cCurrency_id.Width = 100
    '    cCurrency_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
    '    cCurrency_id.Visible = True
    '    cCurrency_id.ReadOnly = True
    '    cCurrency_id.DataSource = Me.tbl_MstCurrency
    '    cCurrency_id.ValueMember = "currency_id"
    '    cCurrency_id.DisplayMember = "currency_shortname"
    '    cCurrency_id.DisplayStyleForCurrentCellOnly = True


    '    cBanktransfer_bi_idr.Name = "banktransfer_bi_idr"
    '    cBanktransfer_bi_idr.HeaderText = "Trans. Amount IDR"
    '    cBanktransfer_bi_idr.DataPropertyName = "banktransfer_bi_idr"
    '    cBanktransfer_bi_idr.Width = 130
    '    cBanktransfer_bi_idr.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    '    cBanktransfer_bi_idr.Visible = True
    '    cBanktransfer_bi_idr.ReadOnly = True
    '    cBanktransfer_bi_idr.DefaultCellStyle.Format = "#,##0"
    '    ' ''cBanktransfer_bi_idr.DefaultCellStyle.BackColor = Color.Gainsboro



    '    cBanktransfer_bi_foreign.Name = "banktransfer_bi_foreign"
    '    cBanktransfer_bi_foreign.HeaderText = "Trans. Amount"
    '    cBanktransfer_bi_foreign.DataPropertyName = "banktransfer_bi_foreign"
    '    cBanktransfer_bi_foreign.Width = 115
    '    cBanktransfer_bi_foreign.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    '    cBanktransfer_bi_foreign.Visible = True
    '    cBanktransfer_bi_foreign.ReadOnly = False
    '    cBanktransfer_bi_foreign.DefaultCellStyle.Format = "#,##0.00"

    '    cBanktransfer_message.Name = "banktransfer_message"
    '    cBanktransfer_message.HeaderText = "banktransfer_message"
    '    cBanktransfer_message.DataPropertyName = "banktransfer_message"
    '    cBanktransfer_message.Width = 100
    '    cBanktransfer_message.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
    '    cBanktransfer_message.Visible = False
    '    cBanktransfer_message.ReadOnly = False

    '    cChannel_id.Name = "channel_id"
    '    cChannel_id.HeaderText = "channel_id"
    '    cChannel_id.DataPropertyName = "channel_id"
    '    cChannel_id.Width = 100
    '    cChannel_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
    '    cChannel_id.Visible = False
    '    cChannel_id.ReadOnly = False

    '    cBanktransfer_isdisabled.Name = "banktransfer_isdisabled"
    '    cBanktransfer_isdisabled.HeaderText = "banktransfer_isdisabled"
    '    cBanktransfer_isdisabled.DataPropertyName = "banktransfer_isdisabled"
    '    cBanktransfer_isdisabled.Width = 100
    '    cBanktransfer_isdisabled.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
    '    cBanktransfer_isdisabled.Visible = False
    '    cBanktransfer_isdisabled.ReadOnly = False

    '    cBanktransfer_invoice.Name = "banktransfer_invoice"
    '    cBanktransfer_invoice.HeaderText = "Invoice"
    '    cBanktransfer_invoice.DataPropertyName = "banktransfer_invoice"
    '    cBanktransfer_invoice.Width = 100
    '    cBanktransfer_invoice.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
    '    cBanktransfer_invoice.Visible = True
    '    cBanktransfer_invoice.ReadOnly = False

    '    cBanktransfer_episode1.Name = "banktransfer_episode1"
    '    cBanktransfer_episode1.HeaderText = "banktransfer_episode1"
    '    cBanktransfer_episode1.DataPropertyName = "banktransfer_episode1"
    '    cBanktransfer_episode1.Width = 100
    '    cBanktransfer_episode1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
    '    cBanktransfer_episode1.Visible = False
    '    cBanktransfer_episode1.ReadOnly = False

    '    cBanktransfer_episode2.Name = "banktransfer_episode2"
    '    cBanktransfer_episode2.HeaderText = "banktransfer_episode2"
    '    cBanktransfer_episode2.DataPropertyName = "banktransfer_episode2"
    '    cBanktransfer_episode2.Width = 100
    '    cBanktransfer_episode2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
    '    cBanktransfer_episode2.Visible = False
    '    cBanktransfer_episode2.ReadOnly = False

    '    cProject_id.Name = "project_id"
    '    cProject_id.HeaderText = "Program"
    '    cProject_id.DataPropertyName = "project_id"
    '    cProject_id.Width = 100
    '    cProject_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
    '    cProject_id.Visible = True
    '    cProject_id.ReadOnly = False
    '    cProject_id.DataSource = Me.tbl_MstShow
    '    cProject_id.ValueMember = "show_id"
    '    cProject_id.DisplayMember = "show_title"
    '    cProject_id.DisplayStyleForCurrentCellOnly = True

    '    cRekananartis_id.Name = "rekananartis_id"
    '    cRekananartis_id.HeaderText = "rekananartis_id"
    '    cRekananartis_id.DataPropertyName = "rekananartis_id"
    '    cRekananartis_id.Width = 100
    '    cRekananartis_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
    '    cRekananartis_id.Visible = False
    '    cRekananartis_id.ReadOnly = False

    '    cBanktransfer_episode.Name = "banktransfer_episode"
    '    cBanktransfer_episode.HeaderText = "Episode"
    '    cBanktransfer_episode.DataPropertyName = "banktransfer_episode"
    '    cBanktransfer_episode.Width = 100
    '    cBanktransfer_episode.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
    '    cBanktransfer_episode.Visible = True
    '    cBanktransfer_episode.ReadOnly = False

    '    cChannelbank_line.Name = "channelbank_line"
    '    cChannelbank_line.HeaderText = "Bank Line Channel"
    '    cChannelbank_line.DataPropertyName = "channelbank_line"
    '    cChannelbank_line.Width = 100
    '    cChannelbank_line.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
    '    cChannelbank_line.Visible = False
    '    cChannelbank_line.ReadOnly = False

    '    cBanktransfer_create_by.Name = "banktransfer_create_by"
    '    cBanktransfer_create_by.HeaderText = "banktransfer_create_by"
    '    cBanktransfer_create_by.DataPropertyName = "banktransfer_create_by"
    '    cBanktransfer_create_by.Width = 100
    '    cBanktransfer_create_by.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
    '    cBanktransfer_create_by.Visible = False
    '    cBanktransfer_create_by.ReadOnly = False

    '    cBanktransfer_create_date.Name = "banktransfer_create_date"
    '    cBanktransfer_create_date.HeaderText = "banktransfer_create_date"
    '    cBanktransfer_create_date.DataPropertyName = "banktransfer_create_date"
    '    cBanktransfer_create_date.Width = 100
    '    cBanktransfer_create_date.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
    '    cBanktransfer_create_date.Visible = False
    '    cBanktransfer_create_date.ReadOnly = False


    '    cJurnaldetil_bilyetperson.Name = "jurnalbilyet_receiveperson"
    '    cJurnaldetil_bilyetperson.HeaderText = "Received By"
    '    cJurnaldetil_bilyetperson.DataPropertyName = "jurnalbilyet_receiveperson"
    '    cJurnaldetil_bilyetperson.Width = 150
    '    cJurnaldetil_bilyetperson.Visible = True
    '    cJurnaldetil_bilyetperson.ReadOnly = False

    '    cJurnaldetil_bilyetpersonRekening.Name = "jurnalbilyet_receiverekening"
    '    cJurnaldetil_bilyetpersonRekening.HeaderText = "Account Bank"
    '    cJurnaldetil_bilyetpersonRekening.DataPropertyName = "jurnalbilyet_receiverekening"
    '    cJurnaldetil_bilyetpersonRekening.Width = 150
    '    cJurnaldetil_bilyetpersonRekening.Visible = True
    '    cJurnaldetil_bilyetpersonRekening.ReadOnly = False

    '    cJurnaldetil_bilyetpersonBank.Name = "jurnalbilyet_receivebank"
    '    cJurnaldetil_bilyetpersonBank.HeaderText = "Receive Bank"
    '    cJurnaldetil_bilyetpersonBank.DataPropertyName = "jurnalbilyet_receivebank"
    '    cJurnaldetil_bilyetpersonBank.Width = 200
    '    cJurnaldetil_bilyetpersonBank.Visible = True
    '    cJurnaldetil_bilyetpersonBank.ReadOnly = False

    '    cJurnaldetil_bilyetpersonBankAccountName.Name = "jurnalbilyet_receiveaccountname"
    '    cJurnaldetil_bilyetpersonBankAccountName.HeaderText = "Account Name"
    '    cJurnaldetil_bilyetpersonBankAccountName.DataPropertyName = "jurnalbilyet_receiveaccountname"
    '    cJurnaldetil_bilyetpersonBankAccountName.Width = 200
    '    cJurnaldetil_bilyetpersonBankAccountName.Visible = True
    '    cJurnaldetil_bilyetpersonBankAccountName.ReadOnly = False

    '    cRekening_debit.Name = "rekening_debit"
    '    cRekening_debit.HeaderText = "Rekening Debit"
    '    cRekening_debit.DataPropertyName = "rekening_debit"
    '    cRekening_debit.Width = 120
    '    cRekening_debit.Visible = True
    '    cRekening_debit.ReadOnly = True
    '    ' ''cRekening_debit.DefaultCellStyle.BackColor = Color.Gainsboro

    '    cBank_debit.Name = "bank_debit"
    '    cBank_debit.HeaderText = "Bank Debit"
    '    cBank_debit.DataPropertyName = "bank_debit"
    '    cBank_debit.Width = 100
    '    cBank_debit.Visible = True
    '    cBank_debit.ReadOnly = True
    '    ' ''cBank_debit.DefaultCellStyle.BackColor = Color.Gainsboro

    '    cAccount_bank_debit.Name = "account_bank_debit"
    '    cAccount_bank_debit.HeaderText = "Account Bank Debit"
    '    cAccount_bank_debit.DataPropertyName = "account_bank_debit"
    '    cAccount_bank_debit.Width = 140
    '    cAccount_bank_debit.Visible = True
    '    cAccount_bank_debit.ReadOnly = True
    '    ' ''cAccount_bank_debit.DefaultCellStyle.BackColor = Color.Gainsboro

    '    cButton_Print.Name = "print"
    '    cButton_Print.HeaderText = "Print"
    '    cButton_Print.Text = "..."
    '    cButton_Print.UseColumnTextForButtonValue = True
    '    cButton_Print.CellTemplate.Style.BackColor = Color.LightGray
    '    cButton_Print.Width = 40
    '    cButton_Print.DividerWidth = 3
    '    cButton_Print.Visible = True
    '    cButton_Print.ReadOnly = False

    '    objDgv.Columns.Clear()
    '    objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
    '    {cButton_Print, cBanktransfer_id, cJurnal_id, cJurnaldetil_line, cBanktransfer_dt, cRekanan_id, _
    '    cJurnaldetil_bilyetperson, cJurnaldetil_bilyetpersonRekening, cJurnaldetil_bilyetpersonBank, cJurnaldetil_bilyetpersonBankAccountName, _
    '    cRekananbank_line, cProject_id, cBanktransfer_episode, cBanktransfer_invoice, cSlipformat_id, cPurposefund_id, _
    '    cCurrency_id, cBanktransfer_foreign, cBanktransfer_bi_foreign, cBanktransfer_foreignrate, _
    '     cBanktransfer_idr, cBanktransfer_bi_idr, cPaymenttype_id, _
    '    cChannelbank_line, cBanktransfer_rekening, cBanktransfer_pembayaranrek, cBanktransfer_message, cChannel_id, cBanktransfer_isdisabled, cBanktransfer_episode1, cBanktransfer_episode2, cRekananartis_id, cBanktransfer_create_by, cBanktransfer_create_date, _
    '    cRekening_debit, cBank_debit, cAccount_bank_debit})
    '    objDgv.AutoGenerateColumns = False
    '    objDgv.AllowUserToAddRows = False
    '    objDgv.AllowUserToDeleteRows = True
    '    objDgv.ReadOnly = True
    'End Function

    Private Function FormatDgvTrnBanktransfer(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        ' Format DgvTrnBanktransfer Columns 
        Dim cBanktransfer_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnal_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnaldetil_line As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBanktransfer_dt As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cSlipformat_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekanan_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekananbank_line As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBanktransfer_rekening As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cPurposefund_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cPaymenttype_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cPaymenttype_id2 As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBanktransfer_pembayaranrek As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBanktransfer_idr As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBanktransfer_foreign As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBanktransfer_foreignrate As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cCurrency_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBanktransfer_bi_idr As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBanktransfer_bi_foreign As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBanktransfer_message As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cChannel_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBanktransfer_isdisabled As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBanktransfer_invoice As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn

        Dim cProject_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBanktransfer_episode As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cChannelbank_line As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBanktransfer_create_by As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBanktransfer_create_date As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTotalTrf As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekanan As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekening_debit As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBank_debit As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAccount_bank_debit As New System.Windows.Forms.DataGridViewTextBoxColumn

        cBanktransfer_id.Name = "ID Transfer"
        cBanktransfer_id.HeaderText = "ID Transfer"
        cBanktransfer_id.DataPropertyName = "ID Transfer"
        cBanktransfer_id.Width = 130
        cBanktransfer_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cBanktransfer_id.Visible = True
        cBanktransfer_id.ReadOnly = True
        cBanktransfer_id.DefaultCellStyle.BackColor = Color.Gainsboro


        cJurnal_id.Name = "ID Jurnal"
        cJurnal_id.HeaderText = "ID Jurnal"
        cJurnal_id.DataPropertyName = "ID Jurnal"
        cJurnal_id.Width = 100
        cJurnal_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cJurnal_id.Visible = True
        cJurnal_id.ReadOnly = True

        cJurnaldetil_line.Name = "jurnaldetil_line"
        cJurnaldetil_line.HeaderText = "jurnaldetil_line"
        cJurnaldetil_line.DataPropertyName = "jurnaldetil_line"
        cJurnaldetil_line.Width = 100
        cJurnaldetil_line.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cJurnaldetil_line.Visible = False
        cJurnaldetil_line.ReadOnly = False

        cBanktransfer_dt.Name = "Transfer Date"
        cBanktransfer_dt.HeaderText = "Transfer Date"
        cBanktransfer_dt.DataPropertyName = "Transfer Date"
        cBanktransfer_dt.Width = 150
        cBanktransfer_dt.Visible = True
        cBanktransfer_dt.ReadOnly = True
        cBanktransfer_dt.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet

        cSlipformat_id.Name = "Penggunaan Dana"
        cSlipformat_id.HeaderText = "Penggunaan Dana"
        cSlipformat_id.DataPropertyName = "Penggunaan Dana"
        cSlipformat_id.Width = 180
        cSlipformat_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cSlipformat_id.Visible = True
        cSlipformat_id.ReadOnly = True


        cRekanan_id.Name = "Rekanan Name Report"
        cRekanan_id.HeaderText = "Rekanan Name Report"
        cRekanan_id.DataPropertyName = "Rekanan Name Report"
        cRekanan_id.Width = 180
        cRekanan_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cRekanan_id.Visible = True
        cRekanan_id.ReadOnly = True

        cRekanan.Name = "rekanan_id"
        cRekanan.HeaderText = "ID Rekanan"
        cRekanan.DataPropertyName = "rekanan_id"
        cRekanan.Width = 140
        cRekanan.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cRekanan.Visible = True
        cRekanan.ReadOnly = True

        cRekananbank_line.Name = "rekananbank_line"
        cRekananbank_line.HeaderText = "Bank Line"
        cRekananbank_line.DataPropertyName = "rekananbank_line"
        cRekananbank_line.Width = 100
        cRekananbank_line.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cRekananbank_line.Visible = False
        cRekananbank_line.ReadOnly = False

        cBanktransfer_rekening.Name = "Receive Rekening"
        cBanktransfer_rekening.HeaderText = "Receive Rekening"
        cBanktransfer_rekening.DataPropertyName = "Receive Rekening"
        cBanktransfer_rekening.Width = 150
        cBanktransfer_rekening.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cBanktransfer_rekening.Visible = True
        cBanktransfer_rekening.ReadOnly = True

        cPurposefund_id.Name = "Pengg. Dana"
        cPurposefund_id.HeaderText = "Pengg. Dana"
        cPurposefund_id.DataPropertyName = "Pengg. Dana"
        cPurposefund_id.Width = 130
        cPurposefund_id.Visible = True
        cPurposefund_id.ReadOnly = True

        cPaymenttype_id.Name = "Payment Type"
        cPaymenttype_id.HeaderText = "Payment Type"
        cPaymenttype_id.DataPropertyName = "Payment Type"
        cPaymenttype_id.Width = 150
        cPaymenttype_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cPaymenttype_id.Visible = True
        cPaymenttype_id.ReadOnly = True

        cPaymenttype_id2.Name = "Paymenttype_id"
        cPaymenttype_id2.HeaderText = "Paymenttype_id"
        cPaymenttype_id2.DataPropertyName = "Paymenttype_id"
        cPaymenttype_id2.Width = 150
        cPaymenttype_id2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cPaymenttype_id2.Visible = False
        cPaymenttype_id2.ReadOnly = True

        cBanktransfer_pembayaranrek.Name = "Receive Bank"
        cBanktransfer_pembayaranrek.HeaderText = "Receive Bank"
        cBanktransfer_pembayaranrek.DataPropertyName = "Receive Bank"
        cBanktransfer_pembayaranrek.Width = 150
        cBanktransfer_pembayaranrek.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cBanktransfer_pembayaranrek.Visible = True
        cBanktransfer_pembayaranrek.ReadOnly = True

        cBanktransfer_idr.Name = "banktransfer_idr"
        cBanktransfer_idr.HeaderText = "Amount IDR"
        cBanktransfer_idr.DataPropertyName = "banktransfer_idr"
        cBanktransfer_idr.Width = 100
        cBanktransfer_idr.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cBanktransfer_idr.Visible = True
        cBanktransfer_idr.ReadOnly = True
        cBanktransfer_idr.DefaultCellStyle.Format = "#,##0"
        cBanktransfer_idr.DefaultCellStyle.BackColor = Color.Gainsboro

        cBanktransfer_foreign.Name = "banktransfer_foreign"
        cBanktransfer_foreign.HeaderText = "Amount"
        cBanktransfer_foreign.DataPropertyName = "banktransfer_foreign"
        cBanktransfer_foreign.Width = 100
        cBanktransfer_foreign.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cBanktransfer_foreign.Visible = True
        cBanktransfer_foreign.ReadOnly = False
        cBanktransfer_foreign.DefaultCellStyle.Format = "#,##0.00"

        cBanktransfer_foreignrate.Name = "banktransfer_foreignrate"
        cBanktransfer_foreignrate.HeaderText = "Rate"
        cBanktransfer_foreignrate.DataPropertyName = "banktransfer_foreignrate"
        cBanktransfer_foreignrate.Width = 100
        cBanktransfer_foreignrate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cBanktransfer_foreignrate.Visible = True
        cBanktransfer_foreignrate.ReadOnly = True
        cBanktransfer_foreignrate.DefaultCellStyle.Format = "#,##0.00"
        cBanktransfer_foreignrate.DefaultCellStyle.BackColor = Color.Gainsboro


        cCurrency_id.Name = "Curr"
        cCurrency_id.HeaderText = "Curr"
        cCurrency_id.DataPropertyName = "Curr"
        cCurrency_id.Width = 100
        cCurrency_id.Visible = True
        cCurrency_id.ReadOnly = True


        cBanktransfer_bi_idr.Name = "banktransfer_bi_idr"
        cBanktransfer_bi_idr.HeaderText = "Trans. Amount IDR"
        cBanktransfer_bi_idr.DataPropertyName = "banktransfer_bi_idr"
        cBanktransfer_bi_idr.Width = 130
        cBanktransfer_bi_idr.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cBanktransfer_bi_idr.Visible = True
        cBanktransfer_bi_idr.ReadOnly = True
        cBanktransfer_bi_idr.DefaultCellStyle.Format = "#,##0"
        cBanktransfer_bi_idr.DefaultCellStyle.BackColor = Color.Gainsboro


        cBanktransfer_bi_foreign.Name = "banktransfer_bi_foreign"
        cBanktransfer_bi_foreign.HeaderText = "Trans. Amount"
        cBanktransfer_bi_foreign.DataPropertyName = "banktransfer_bi_foreign"
        cBanktransfer_bi_foreign.Width = 115
        cBanktransfer_bi_foreign.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cBanktransfer_bi_foreign.Visible = True
        cBanktransfer_bi_foreign.ReadOnly = False
        cBanktransfer_bi_foreign.DefaultCellStyle.Format = "#,##0.00"

        cTotalTrf.Name = "Total Transfer"
        cTotalTrf.HeaderText = "Total Transfer"
        cTotalTrf.DataPropertyName = "Total Transfer"
        cTotalTrf.DefaultCellStyle.Format = "#,##0"
        cTotalTrf.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cTotalTrf.Width = 115
        cTotalTrf.Visible = True
        cTotalTrf.ReadOnly = False


        cBanktransfer_message.Name = "Receive By"
        cBanktransfer_message.HeaderText = "Received By"
        cBanktransfer_message.DataPropertyName = "Receive By"
        cBanktransfer_message.Width = 100
        cBanktransfer_message.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cBanktransfer_message.Visible = True
        cBanktransfer_message.ReadOnly = False
        cBanktransfer_message.DefaultCellStyle.BackColor = Color.Gainsboro

        cChannel_id.Name = "channel_id"
        cChannel_id.HeaderText = "channel_id"
        cChannel_id.DataPropertyName = "channel_id"
        cChannel_id.Width = 100
        cChannel_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cChannel_id.Visible = False
        cChannel_id.ReadOnly = False

        cBanktransfer_isdisabled.Name = "banktransfer_isdisabled"
        cBanktransfer_isdisabled.HeaderText = "banktransfer_isdisabled"
        cBanktransfer_isdisabled.DataPropertyName = "banktransfer_isdisabled"
        cBanktransfer_isdisabled.Width = 100
        cBanktransfer_isdisabled.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cBanktransfer_isdisabled.Visible = False
        cBanktransfer_isdisabled.ReadOnly = False

        cBanktransfer_invoice.Name = "Invoice"
        cBanktransfer_invoice.HeaderText = "Invoice" '"Received By"
        cBanktransfer_invoice.DataPropertyName = "Invoice"
        cBanktransfer_invoice.Width = 100
        cBanktransfer_invoice.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cBanktransfer_invoice.Visible = True
        cBanktransfer_invoice.ReadOnly = False
        cBanktransfer_invoice.DefaultCellStyle.BackColor = Color.White

        cProject_id.Name = "project"
        cProject_id.HeaderText = "Project"
        cProject_id.DataPropertyName = "project"
        cProject_id.Width = 150
        cProject_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cProject_id.Visible = True
        cProject_id.ReadOnly = True

        cBanktransfer_episode.Name = "Eps"
        cBanktransfer_episode.HeaderText = "Eps"
        cBanktransfer_episode.DataPropertyName = "Eps"
        cBanktransfer_episode.Width = 50
        cBanktransfer_episode.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cBanktransfer_episode.Visible = True
        cBanktransfer_episode.ReadOnly = True
        cBanktransfer_episode.DefaultCellStyle.BackColor = Color.Gainsboro

        cChannelbank_line.Name = "channelbank_line"
        cChannelbank_line.HeaderText = "Bank Line Channel"
        cChannelbank_line.DataPropertyName = "channelbank_line"
        cChannelbank_line.Width = 100
        cChannelbank_line.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cChannelbank_line.Visible = False
        cChannelbank_line.ReadOnly = False

        cBanktransfer_create_by.Name = "Create By"
        cBanktransfer_create_by.HeaderText = "Create By"
        cBanktransfer_create_by.DataPropertyName = "Create By"
        cBanktransfer_create_by.Width = 150
        cBanktransfer_create_by.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cBanktransfer_create_by.Visible = True
        cBanktransfer_create_by.ReadOnly = True
        cBanktransfer_create_by.DefaultCellStyle.BackColor = Color.Gainsboro

        cBanktransfer_create_date.Name = "Create Date"
        cBanktransfer_create_date.HeaderText = "Create Date"
        cBanktransfer_create_date.DataPropertyName = "Create Date"
        cBanktransfer_create_date.Width = 150
        cBanktransfer_create_date.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cBanktransfer_create_date.Visible = True
        cBanktransfer_create_date.ReadOnly = True
        cBanktransfer_create_date.DefaultCellStyle.BackColor = Color.Gainsboro


        cRekening_debit.Name = "rekening_debit"
        cRekening_debit.HeaderText = "Rekening Debit"
        cRekening_debit.DataPropertyName = "rekening_debit"
        cRekening_debit.Width = 120
        cRekening_debit.Visible = True
        cRekening_debit.ReadOnly = True
        cRekening_debit.DefaultCellStyle.BackColor = Color.Gainsboro

        cBank_debit.Name = "bank_debit"
        cBank_debit.HeaderText = "Bank Debit"
        cBank_debit.DataPropertyName = "bank_debit"
        cBank_debit.Width = 100
        cBank_debit.Visible = True
        cBank_debit.ReadOnly = True
        cBank_debit.DefaultCellStyle.BackColor = Color.Gainsboro

        cAccount_bank_debit.Name = "account_bank_debit"
        cAccount_bank_debit.HeaderText = "Account Bank Debit"
        cAccount_bank_debit.DataPropertyName = "account_bank_debit"
        cAccount_bank_debit.Width = 140
        cAccount_bank_debit.Visible = True
        cAccount_bank_debit.ReadOnly = True
        cAccount_bank_debit.DefaultCellStyle.BackColor = Color.Gainsboro

        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
        {cBanktransfer_id, cJurnal_id, cJurnaldetil_line, cBanktransfer_dt, _
          cBanktransfer_invoice, cBanktransfer_message, cBanktransfer_rekening, cBanktransfer_pembayaranrek, _
        cRekananbank_line, cRekanan, cRekanan_id, cProject_id, cBanktransfer_episode, cPaymenttype_id2, cPaymenttype_id, cSlipformat_id, cPurposefund_id, _
        cCurrency_id, cBanktransfer_foreign, cBanktransfer_foreignrate, cBanktransfer_idr, cBanktransfer_bi_foreign, cBanktransfer_bi_idr, _
          cTotalTrf, _
        cChannelbank_line, cChannel_id, cBanktransfer_isdisabled, cBanktransfer_create_by, cBanktransfer_create_date, _
        cRekening_debit, cBank_debit, cAccount_bank_debit})
        objDgv.AutoGenerateColumns = False
        objDgv.AllowUserToAddRows = False
        objDgv.AllowUserToDeleteRows = False
        objDgv.ReadOnly = True

    End Function

    Private Function FormatDgvTrnBankentrydetil(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        ' formating DgvTrnBankentrydetil_Kredit
        Dim cBankentry_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBankentrydetil_line As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBankentrydetil_dk As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBankentrydetil_descr As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBankentrydetil_type As System.Windows.Forms.DataGridViewComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn
        Dim cBankentrydetil_currency As System.Windows.Forms.DataGridViewComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn
        Dim cBankentrydetil_rate As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBankentrydetil_idr As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBankentrydetil_foreign As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBankentrydetil_refid As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBankentrydetil_refline As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBankentrydetil_bilyet As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBankentrydetil_entryby As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBankentrydetil_entrydt As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBankentrydetil_modifyby As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBankentrydetil_modifydt As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cChannel_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnaltype_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAcc_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAcc_ca_id As System.Windows.Forms.DataGridViewComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn

        Dim cBankentry_date As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBankentry_bankname As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn

        cBankentry_id.Name = "bankentry_id"
        cBankentry_id.HeaderText = "ID"
        cBankentry_id.DataPropertyName = "bankentry_id"
        cBankentry_id.Width = 100
        cBankentry_id.Visible = True
        cBankentry_id.ReadOnly = False
        cBankentry_id.DefaultCellStyle.BackColor = Color.LightGray

        cBankentrydetil_line.Name = "bankentrydetil_line"
        cBankentrydetil_line.HeaderText = "Line"
        cBankentrydetil_line.DataPropertyName = "bankentrydetil_line"
        cBankentrydetil_line.Width = 50
        cBankentrydetil_line.Visible = True
        cBankentrydetil_line.ReadOnly = True
        cBankentrydetil_line.DefaultCellStyle.BackColor = Color.LightGray

        cBankentrydetil_dk.Name = "bankentrydetil_dk"
        cBankentrydetil_dk.HeaderText = "D/K"
        cBankentrydetil_dk.DataPropertyName = "bankentrydetil_dk"
        cBankentrydetil_dk.Width = 50
        cBankentrydetil_dk.Visible = False
        cBankentrydetil_dk.ReadOnly = False

        cBankentrydetil_descr.Name = "bankentrydetil_descr"
        cBankentrydetil_descr.HeaderText = "Description"
        cBankentrydetil_descr.DataPropertyName = "bankentrydetil_descr"
        cBankentrydetil_descr.Width = 200
        cBankentrydetil_descr.Visible = False
        cBankentrydetil_descr.ReadOnly = True
        cBankentrydetil_descr.DefaultCellStyle.BackColor = Color.LightGray

        cBankentrydetil_type.Name = "bankentrydetil_type"
        cBankentrydetil_type.HeaderText = "Type"
        cBankentrydetil_type.DataPropertyName = "bankentrydetil_type"
        cBankentrydetil_type.Width = 100
        cBankentrydetil_type.Visible = False
        cBankentrydetil_type.ReadOnly = True
        cBankentrydetil_type.ValueMember = "valuetype"
        cBankentrydetil_type.DisplayMember = "payment_type"
        'cBankentrydetil_type.DisplayStyleForCurrentCellOnly = True
        cBankentrydetil_type.AutoComplete = True
        cBankentrydetil_type.DataSource = Me.tbl_Payment_type
        cBankentrydetil_type.DefaultCellStyle.BackColor = Color.LightGray


        cBankentrydetil_currency.Name = "bankentrydetil_currency"
        cBankentrydetil_currency.HeaderText = "Curr."
        cBankentrydetil_currency.DataPropertyName = "bankentrydetil_currency"
        cBankentrydetil_currency.Width = 75
        cBankentrydetil_currency.Visible = False
        cBankentrydetil_currency.ReadOnly = True
        cBankentrydetil_currency.ValueMember = "currency_id"
        cBankentrydetil_currency.DisplayMember = "currency_shortname"
        cBankentrydetil_currency.AutoComplete = True
        cBankentrydetil_currency.DataSource = Me.tbl_MstCurrencyGrid
        cBankentrydetil_currency.DefaultCellStyle.BackColor = Color.LightGray

        cBankentrydetil_rate.Name = "bankentrydetil_rate"
        cBankentrydetil_rate.HeaderText = "Trans. Rate"
        cBankentrydetil_rate.DataPropertyName = "bankentrydetil_rate"
        cBankentrydetil_rate.Width = 100
        cBankentrydetil_rate.Visible = False
        cBankentrydetil_rate.ReadOnly = True
        cBankentrydetil_rate.DefaultCellStyle.Format = "#,##0.00"
        cBankentrydetil_rate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cBankentrydetil_rate.DefaultCellStyle.BackColor = Color.LightGray


        cBankentrydetil_idr.Name = "bankentrydetil_idr"
        cBankentrydetil_idr.HeaderText = "Amount IDR"
        cBankentrydetil_idr.DataPropertyName = "bankentrydetil_idr"
        cBankentrydetil_idr.Width = 120
        cBankentrydetil_idr.Visible = False
        cBankentrydetil_idr.ReadOnly = True
        cBankentrydetil_idr.DefaultCellStyle.Format = "#,##0"
        cBankentrydetil_idr.DefaultCellStyle.BackColor = Color.LightGray
        cBankentrydetil_idr.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight


        cBankentrydetil_foreign.Name = "bankentrydetil_foreign"
        cBankentrydetil_foreign.HeaderText = "Amount"
        cBankentrydetil_foreign.DataPropertyName = "bankentrydetil_foreign"
        cBankentrydetil_foreign.Width = 100
        cBankentrydetil_foreign.Visible = False
        cBankentrydetil_foreign.ReadOnly = False
        cBankentrydetil_foreign.DefaultCellStyle.Format = "#,##0.00"
        cBankentrydetil_foreign.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cBankentrydetil_foreign.DefaultCellStyle.BackColor = Color.LightGray

        cBankentrydetil_refid.Name = "bankentrydetil_refid"
        cBankentrydetil_refid.HeaderText = "Ref ID"
        cBankentrydetil_refid.DataPropertyName = "bankentrydetil_refid"
        cBankentrydetil_refid.Width = 100
        cBankentrydetil_refid.Visible = False
        cBankentrydetil_refid.ReadOnly = True
        cBankentrydetil_refid.DefaultCellStyle.BackColor = Color.LightGray

        cBankentrydetil_refline.Name = "bankentrydetil_refline"
        cBankentrydetil_refline.HeaderText = "Ref Line"
        cBankentrydetil_refline.DataPropertyName = "bankentrydetil_refline"
        cBankentrydetil_refline.Width = 100
        cBankentrydetil_refline.Visible = False
        cBankentrydetil_refline.ReadOnly = True
        cBankentrydetil_refline.DefaultCellStyle.BackColor = Color.LightGray

        cBankentrydetil_bilyet.Name = "bankentrydetil_bilyet"
        cBankentrydetil_bilyet.HeaderText = "Bilyet"
        cBankentrydetil_bilyet.DataPropertyName = "bankentrydetil_bilyet"
        cBankentrydetil_bilyet.Width = 100
        cBankentrydetil_bilyet.Visible = False
        cBankentrydetil_bilyet.ReadOnly = True
        cBankentrydetil_bilyet.DefaultCellStyle.BackColor = Color.LightGray

        cBankentrydetil_entryby.Name = "bankentrydetil_entryby"
        cBankentrydetil_entryby.HeaderText = "bankentrydetil_entryby"
        cBankentrydetil_entryby.DataPropertyName = "bankentrydetil_entryby"
        cBankentrydetil_entryby.Width = 100
        cBankentrydetil_entryby.Visible = False
        cBankentrydetil_entryby.ReadOnly = True

        cBankentrydetil_entrydt.Name = "bankentrydetil_entrydt"
        cBankentrydetil_entrydt.HeaderText = "bankentrydetil_entrydt"
        cBankentrydetil_entrydt.DataPropertyName = "bankentrydetil_entrydt"
        cBankentrydetil_entrydt.Width = 100
        cBankentrydetil_entrydt.Visible = False
        cBankentrydetil_entrydt.ReadOnly = False

        cBankentrydetil_modifyby.Name = "bankentrydetil_modifyby"
        cBankentrydetil_modifyby.HeaderText = "bankentrydetil_modifyby"
        cBankentrydetil_modifyby.DataPropertyName = "bankentrydetil_modifyby"
        cBankentrydetil_modifyby.Width = 100
        cBankentrydetil_modifyby.Visible = False
        cBankentrydetil_modifyby.ReadOnly = False

        cBankentrydetil_modifydt.Name = "bankentrydetil_modifydt"
        cBankentrydetil_modifydt.HeaderText = "bankentrydetil_modifydt"
        cBankentrydetil_modifydt.DataPropertyName = "bankentrydetil_modifydt"
        cBankentrydetil_modifydt.Width = 100
        cBankentrydetil_modifydt.Visible = False
        cBankentrydetil_modifydt.ReadOnly = False

        cChannel_id.Name = "channel_id"
        cChannel_id.HeaderText = "Channel ID"
        cChannel_id.DataPropertyName = "channel_id"
        cChannel_id.Width = 100
        cChannel_id.Visible = False
        cChannel_id.ReadOnly = False

        cJurnaltype_id.Name = "jurnaltype_id"
        cJurnaltype_id.HeaderText = "Jurnal Type"
        cJurnaltype_id.DataPropertyName = "jurnaltype_id"
        cJurnaltype_id.Width = 100
        cJurnaltype_id.Visible = False
        cJurnaltype_id.ReadOnly = False

        cAcc_id.Name = "acc_id"
        cAcc_id.HeaderText = "Account"
        cAcc_id.DataPropertyName = "acc_id"
        cAcc_id.Width = 100
        cAcc_id.Visible = False
        cAcc_id.ReadOnly = False

        cAcc_ca_id.Name = "acc_ca_id"
        cAcc_ca_id.HeaderText = "CA Account"
        cAcc_ca_id.DataPropertyName = "acc_ca_id"
        cAcc_ca_id.Width = 150
        cAcc_ca_id.Visible = False
        cAcc_ca_id.ReadOnly = True
        cAcc_ca_id.ValueMember = "acc_ca_id"
        cAcc_ca_id.DisplayMember = "acc_ca_shortname"
        cAcc_ca_id.AutoComplete = True
        cAcc_ca_id.DataSource = Me.tbl_MstAcc_ca
        cAcc_ca_id.DefaultCellStyle.BackColor = Color.LightGray

        cBankentry_date.Name = "bankentry_date"
        cBankentry_date.HeaderText = "Date"
        cBankentry_date.DataPropertyName = "bankentry_date"
        cBankentry_date.Width = 100
        cBankentry_date.Visible = True
        cBankentry_date.ReadOnly = False
        cBankentry_date.DefaultCellStyle.BackColor = Color.LightGray

        cBankentry_bankname.Name = "bankacc_name"
        cBankentry_bankname.HeaderText = "Bank"
        cBankentry_bankname.DataPropertyName = "bankacc_name"
        cBankentry_bankname.Width = 120
        cBankentry_bankname.Visible = True
        cBankentry_bankname.ReadOnly = True
        cBankentry_bankname.DefaultCellStyle.BackColor = Color.LightGray


        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
        {cBankentry_id, cBankentrydetil_line, cBankentry_date, cBankentry_bankname, cAcc_id, cAcc_ca_id, cBankentrydetil_dk, _
        cBankentrydetil_currency, cBankentrydetil_foreign, cBankentrydetil_rate, cBankentrydetil_idr, _
         cBankentrydetil_descr, cBankentrydetil_type, cBankentrydetil_refid, _
        cBankentrydetil_refline, cBankentrydetil_bilyet, _
        cBankentrydetil_entryby, cBankentrydetil_entrydt, _
        cBankentrydetil_modifyby, cBankentrydetil_modifydt, cChannel_id, cJurnaltype_id})

        objDgv.AutoGenerateColumns = False
    End Function

    Private Function FormatDgvReferenceTandaterima(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean

        Dim cJurnal_id As New DataGridViewTextBoxColumn
        Dim cJurnal_line As New DataGridViewTextBoxColumn
        Dim cTandaterima_id As New DataGridViewTextBoxColumn
        Dim cTandaterima_line As New DataGridViewTextBoxColumn
        Dim cInvoiceId As New DataGridViewTextBoxColumn
        Dim cCurrency_id As New DataGridViewComboBoxColumn
        Dim cAmount_foreign As New DataGridViewTextBoxColumn
        Dim cAmount_foreignRate As New DataGridViewTextBoxColumn
        Dim cAmount_idr As New DataGridViewTextBoxColumn
        Dim cCreate_by As New DataGridViewTextBoxColumn
        Dim cCreate_dt As New DataGridViewTextBoxColumn


        cJurnal_line.Name = "jurnal_line"
        cJurnal_line.HeaderText = "Line"
        cJurnal_line.DataPropertyName = "jurnal_line"
        cJurnal_line.Width = 30
        cJurnal_line.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cJurnal_line.DefaultCellStyle.BackColor = Color.LightYellow
        cJurnal_line.Visible = True
        cJurnal_line.ReadOnly = True

        cTandaterima_id.Name = "tandaterima_id"
        cTandaterima_id.HeaderText = "Tanda Terima ID"
        cTandaterima_id.DataPropertyName = "tandaterima_id"
        cTandaterima_id.Width = 150
        cTandaterima_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cTandaterima_id.DefaultCellStyle.BackColor = Color.LightYellow
        cTandaterima_id.Visible = True
        cTandaterima_id.ReadOnly = True

        cTandaterima_line.Name = "tandaterima_line"
        cTandaterima_line.HeaderText = " RD Line"
        cTandaterima_line.DataPropertyName = "tandaterima_line"
        cTandaterima_line.Width = 80
        cTandaterima_line.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cTandaterima_line.DefaultCellStyle.BackColor = Color.LightYellow
        cTandaterima_line.Visible = True
        cTandaterima_line.ReadOnly = True

        cInvoiceId.Name = "tandaterima_invoiceno"
        cInvoiceId.HeaderText = "Invoice No."
        cInvoiceId.DataPropertyName = "tandaterima_invoiceno"
        cInvoiceId.Width = 150
        cInvoiceId.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cInvoiceId.Visible = True
        cInvoiceId.ReadOnly = True

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

        cAmount_foreign.Name = "amount_foreign"
        cAmount_foreign.HeaderText = "Amount Foreign"
        cAmount_foreign.DataPropertyName = "amount_foreign"
        cAmount_foreign.Width = 150
        cAmount_foreign.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cAmount_foreign.DefaultCellStyle.Format = "#,###,##0.00"
        cAmount_foreign.Visible = True
        cAmount_foreign.ReadOnly = False

        cAmount_foreignRate.Name = "amount_foreignrate"
        cAmount_foreignRate.HeaderText = "Rate"
        cAmount_foreignRate.DataPropertyName = "amount_foreignrate"
        cAmount_foreignRate.Width = 120
        cAmount_foreignRate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cAmount_foreignRate.DefaultCellStyle.Format = "#,###,##0.00"
        cAmount_foreignRate.Visible = True
        cAmount_foreignRate.ReadOnly = False

        cAmount_idr.Name = "amount_idr"
        cAmount_idr.HeaderText = "Amount idr"
        cAmount_idr.DataPropertyName = "amount_idr"
        cAmount_idr.Width = 120
        cAmount_idr.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cAmount_idr.DefaultCellStyle.Format = "#,###,##0.00"
        cAmount_idr.Visible = True
        cAmount_idr.ReadOnly = True

        cCreate_by.Name = "create_by"
        cCreate_by.HeaderText = "create_by"
        cCreate_by.DataPropertyName = "create_by"
        cCreate_by.Width = 100
        cCreate_by.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cCreate_by.Visible = False
        cCreate_by.ReadOnly = True

        cCreate_dt.Name = "create_dt"
        cCreate_dt.HeaderText = "create_dt"
        cCreate_dt.DataPropertyName = "create_dt"
        cCreate_dt.Width = 100
        cCreate_dt.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cCreate_dt.Visible = False
        cCreate_dt.ReadOnly = True

        cJurnal_id.Name = "jurnal_id"
        cJurnal_id.HeaderText = "jurnal id"
        cJurnal_id.DataPropertyName = "jurnal_id"
        cJurnal_id.Width = 100
        cJurnal_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cJurnal_id.DefaultCellStyle.BackColor = Color.Gainsboro
        cJurnal_id.Visible = False
        cJurnal_id.ReadOnly = True

        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New DataGridViewColumn() _
        {cJurnal_line, cJurnal_id, cTandaterima_id, cTandaterima_line, _
        cInvoiceId, cCurrency_id, cAmount_foreign, cAmount_foreignRate, cAmount_idr, _
        cCreate_by, cCreate_dt})


        objDgv.AllowUserToAddRows = False
        objDgv.AllowUserToDeleteRows = True
        objDgv.AllowUserToResizeRows = False

        objDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        objDgv.MultiSelect = False
        objDgv.Columns("jurnal_line").Frozen = True


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
        Me.DgvTrnJurnalreference.Dock = DockStyle.Fill
        Me.DgvTrnJurnalResponse.Dock = DockStyle.Fill
        Me.DgvTrnJurnal_BankLink.Dock = DockStyle.Fill

        Me.FormatDgvTrnJurnal(Me.DgvTrnJurnal)
        Me.FormatDgvTrnJurnalreference(Me.DgvTrnJurnalreference)
        Me.FormatDgvTrnJurnalresponse(Me.DgvTrnJurnalResponse)
        Me.FormatDgvTrnBanktransfer(Me.dgvTrnBankTransfer)
        '        Me.FormatDgvTrnBankentrydetil(Me.DgvTrnJurnal_BankLink)
        Me.FormatDgvTrnBankentrydetilReference(Me.DgvTrnJurnal_BankLink)
        'tambahan aji
        Me.FormatDgvReferenceTandaterima(Me.DgvTrnJurnalInvoice)
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
        Me.obj_Budget_id.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnJurnal_Temp, "budget_id", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))
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

#Region " Dialoged Control "
    Private Function DialogOpen_Reference_Advance() As Boolean
        Dim dlg As dlgTrnJurnal_PV_Select_AdvanceTravel = New dlgTrnJurnal_PV_Select_AdvanceTravel(Me.DSN, Me.tbl_MstRekananGrid.Copy, Me._SOURCE)

        Dim retObj As Object
        Dim retData As Collection
        Dim tblH, tblJDetil As DataTable
        Dim row As DataRow
        Dim k As Integer
        Dim selisih, jumlah As Decimal

        retObj = dlg.OpenDialog(Me, Me._CHANNEL, Me.tbl_TrnJurnalReference)
        Dim tbl_jurnaldetil_temps As DataTable = New DataTable
        Dim tbl_debet As DataTable = New DataTable
        Dim criteria_debet As String = String.Empty

        Dim amountForeign_total As Decimal
        Dim amountIDR_total As Decimal
        Dim amountForeign_pphTotal As Decimal = 0
        Dim amountIDR_pphTotal As Decimal = 0

        If retObj IsNot Nothing Then
            retData = CType(retObj, Collection)
            tblH = CType(retData.Item("tblH"), DataTable)
            tblJDetil = CType(retData.Item("tblJDetil"), DataTable)

            If Not DATADETIL_OPENED Then
                Me.obj_Jurnal_duedate.Value = Now.Date
                Me.obj_Rekanan_id.SelectedValue = tblH.Rows(0).Item("rekanan_id")
                Me.obj_Jurnal_descr.Text = tblH.Rows(0).Item("jurnal_descr")
                Me.obj_Currency_id.SelectedValue = tblH.Rows(0).Item("currency_id")
                Me.obj_Budget_id.SelectedValue = tblH.Rows(0).Item("budget_id")
                Me.obj_Currency_rate.Text = tblH.Rows(0).Item("currency_rate")
                Me.obj_Currency_rate.Enabled = False
                Me.obj_Currency_id.Enabled = False
            End If

            '=================================EXTRACT DEBIT AMOUNT ADVANCE========================================================================
            'Extract data for detil D
            For k = 0 To tblJDetil.Rows.Count - 1
                Dim amount_ppn_foreign As Decimal = 0
                Dim amount_ppn_real As Decimal = 0

                row = Me.tbl_TrnJurnaldetil_Debit.NewRow
                row.Item("currency_id") = tblJDetil.Rows(k).Item("currency_id")
                row.Item("jurnaldetil_descr") = tblJDetil.Rows(k).Item("advance_descr")

                If tblJDetil.Rows(k).Item("currency_id") = 1 Then
                    row.Item("jurnaldetil_idr") = String.Format("{0:#,##0}", Math.Round(CDec(tblJDetil.Rows(k).Item("jurnaldetil_foreign")), 0, MidpointRounding.AwayFromZero) _
                                                           * Math.Round(CDec(tblJDetil.Rows(k).Item("jurnaldetil_foreignrate")), 2, MidpointRounding.AwayFromZero))

                    row.Item("jurnaldetil_foreign") = String.Format("{0:#,##0.00}", Math.Round(CDec(tblJDetil.Rows(k).Item("jurnaldetil_foreign")), 0, MidpointRounding.AwayFromZero))

                    amountForeign_total += String.Format("{0:#,##0.00}", Math.Round(Math.Round(CDec(tblJDetil.Rows(k).Item("jurnaldetil_foreign")), 0, MidpointRounding.AwayFromZero) _
                                                                   + Math.Round(CDec(tblJDetil.Rows(k).Item("ppn_foreign")), 2, MidpointRounding.AwayFromZero) _
                                                                   - Math.Round(CDec(tblJDetil.Rows(k).Item("pph_foreign"))), 0, MidpointRounding.AwayFromZero))

                    amountIDR_total += String.Format("{0:#,##0.00}", Math.Round(Math.Round(CDec(tblJDetil.Rows(k).Item("jurnaldetil_foreign")), 0, MidpointRounding.AwayFromZero) _
                                                                + Math.Round(CDec(tblJDetil.Rows(k).Item("ppn_foreign")), 2, MidpointRounding.AwayFromZero) _
                                                                - Math.Round(CDec(tblJDetil.Rows(k).Item("pph_foreign")), 2, MidpointRounding.AwayFromZero) _
                                                                * Math.Round(CDec(tblJDetil.Rows(k).Item("jurnaldetil_foreignrate")), 2, MidpointRounding.AwayFromZero), 0, MidpointRounding.AwayFromZero))
                Else
                    row.Item("jurnaldetil_idr") = String.Format("{0:#,##0}", CDec(tblJDetil.Rows(k).Item("jurnaldetil_foreign")) _
                                                          * Math.Round(CDec(tblJDetil.Rows(k).Item("jurnaldetil_foreignrate")), 2, MidpointRounding.AwayFromZero))
                    row.Item("jurnaldetil_foreign") = String.Format("{0:#,##0.00}", CDec(tblJDetil.Rows(k).Item("jurnaldetil_foreign")))

                    amountForeign_total += String.Format("{0:#,##0.00}", CDec(tblJDetil.Rows(k).Item("jurnaldetil_foreign")) _
                                                                   + Math.Round(CDec(tblJDetil.Rows(k).Item("ppn_foreign")), 2, MidpointRounding.AwayFromZero) _
                                                                   - Math.Round(CDec(tblJDetil.Rows(k).Item("pph_foreign")), 2, MidpointRounding.AwayFromZero))

                    amountIDR_total += String.Format("{0:#,##0.00}", CDec(tblJDetil.Rows(k).Item("jurnaldetil_foreign")) _
                                                                + Math.Round(CDec(tblJDetil.Rows(k).Item("ppn_foreign")), 2, MidpointRounding.AwayFromZero) _
                                                                - Math.Round(CDec(tblJDetil.Rows(k).Item("pph_foreign")), 2, MidpointRounding.AwayFromZero)) _
                                                                * Math.Round(CDec(tblJDetil.Rows(k).Item("jurnaldetil_foreignrate")), 2, MidpointRounding.AwayFromZero)
                End If
                
                row.Item("jurnaldetil_foreignrate") = String.Format("{0:#,##0.00}", CDec(tblJDetil.Rows(k).Item("jurnaldetil_foreignrate")))
                row.Item("acc_id") = GetProdTypeBudgetID(tblJDetil.Rows(k).Item("budget_id"))
                row.Item("jurnaldetil_descr") = tblJDetil.Rows(k).Item("jurnaldetil_descr")
                row.Item("ref_id") = tblJDetil.Rows(k).Item("ref_id")
                row.Item("ref_line") = tblJDetil.Rows(k).Item("ref_line")
                row.Item("ref_budgetline") = 0
                row.Item("region_id") = clsUtil.IsDbNull(tblJDetil.Rows(k).Item("region_id"), 0)
                row.Item("branch_id") = clsUtil.IsDbNull(tblJDetil.Rows(k).Item("branch_id"), 0)
                row.Item("strukturunit_id") = clsUtil.IsDbNull(tblJDetil.Rows(k).Item("strukturunit_id"), 0)
                row.Item("rekanan_id") = tblH.Rows(0).Item("rekanan_id") ' tblJDetil.Rows(k).Item("rekanan_id") '==========" REKANAN DI DI Debit UM dikosongkan" ======20140922===============
                row.Item("rekanan_name") = Me.obj_Rekanan_id.Text 'tblJDetil.Rows(k).Item("rekanan_name") '==========" REKANAN DI DI Debit UM dikosongkan" ===20140922==================
                row.Item("budget_id") = tblJDetil.Rows(k).Item("budget_id")
                row.Item("budget_name") = tblJDetil.Rows(k).Item("budget_name")
                row.Item("budgetdetil_id") = 0
                row.Item("budgetdetil_name") = "-- PILIH --"
                Me.tbl_TrnJurnaldetil_Debit.Rows.Add(row)

                'Extract data for tabel Reference
                row = Me.tbl_TrnJurnalReference.NewRow
                row.Item("jurnaldetil_line") = Me.tbl_TrnJurnaldetil_Debit.Rows(Me.tbl_TrnJurnaldetil_Debit.Rows.Count - 1).Item("jurnaldetil_line")
                row.Item("ref") = tblJDetil.Rows(k).Item("ref_id")
                row.Item("line") = tblJDetil.Rows(k).Item("ref_line")
                row.Item("descr") = tblJDetil.Rows(k).Item("jurnaldetil_descr")
                row.Item("rate") = String.Format("{0:#,##0.00}", CDec(tblJDetil.Rows(k).Item("rate")))
                If CDec(tblJDetil.Rows(k).Item("rate")) = 1 Then
                    row.Item("amount_foreign") = String.Format("{0:#,##0.00}", Math.Round(CDec(tblJDetil.Rows(k).Item("amount_foreign")), 0, MidpointRounding.AwayFromZero))
                    row.Item("amount_idr") = String.Format("{0:#,##0}", Math.Round(CDec(tblJDetil.Rows(k).Item("amount_idr")), 0, MidpointRounding.AwayFromZero))
                Else
                    row.Item("amount_foreign") = String.Format("{0:#,##0.00}", CDec(tblJDetil.Rows(k).Item("amount_foreign")))
                    row.Item("amount_idr") = String.Format("{0:#,##0}", CDec(tblJDetil.Rows(k).Item("amount_idr")))
                End If
                
                row.Item("channel_id") = tblJDetil.Rows(k).Item("channel_id")
                row.Item("rekanan_name") = tblJDetil.Rows(k).Item("rekanan_name")
                row.Item("channel_id") = tblJDetil.Rows(k).Item("channel_id")
                row.Item("strukturunit_name") = tblJDetil.Rows(k).Item("strukturunit_name")
                row.Item("currency_name") = tblJDetil.Rows(k).Item("currency_name")
                Me.tbl_TrnJurnalReference.Rows.Add(row)
            Next

            '=========================================================EXTRACT CREDIT AMOUNT ADVANCE========================================================
            'Extract data for detil K
            row = Me.tbl_TrnJurnaldetil_Credit.NewRow
            row.Item("currency_id") = tblH.Rows(0).Item("currency_id")
            row.Item("jurnaldetil_descr") = tblH.Rows(0).Item("jurnal_descr")
            row.Item("jurnaldetil_idr") = String.Format("{0:#,##0.00}", CDec(amountIDR_total))
            row.Item("jurnaldetil_foreign") = String.Format("{0:#,##0.00}", CDec(amountForeign_total))

            row.Item("jurnaldetil_foreignrate") = String.Format("{0:#,##0.00}", CDec(tblJDetil.Rows(0).Item("jurnaldetil_foreignrate")))
            row.Item("acc_id") = IIf(amountIDR_total <= 5000000, 1111110, 1112106) '1111110 = Kas Umum, 1112106 = Danamon IDR
            row.Item("jurnaldetil_descr") = tblH.Rows(0).Item("jurnal_descr")
            row.Item("ref_id") = String.Empty
            row.Item("ref_line") = 0
            row.Item("ref_budgetline") = 0
            row.Item("region_id") = 0
            row.Item("branch_id") = 0
            row.Item("strukturunit_id") = tblH.Rows(0).Item("strukturunit_id")
            row.Item("rekanan_id") = tblH.Rows(0).Item("rekanan_id")
            row.Item("rekanan_name") = Me.obj_Rekanan_id.Text
            row.Item("budget_id") = 0
            row.Item("budget_name") = "-- PILIH --"
            row.Item("budgetdetil_id") = 0
            row.Item("budgetdetil_name") = "-- PILIH --"

            row.Item("paymenttype_id") = IIf(amountIDR_total <= 5000000, 1, 2)
            row.Item("jurnalbilyet_bank") = IIf(amountIDR_total <= 5000000, 42, 23)
            row.Item("jurnalbilyet_date") = Now.Date
            row.Item("jurnalbilyet_dateeffective") = Now.Date

            Me.tbl_TrnJurnaldetil_Credit.Rows.Add(row)

        '=============================================EXTRACT DEBIT AMOUNT PPN ADVANCE =============================================================
            For u As Integer = 0 To tblJDetil.Rows.Count - 1
                If tblJDetil.Rows(u).Item("ppn_foreign") <> 0 Then
                    Dim amount_ppn_foreign As Decimal = 0
                    Dim amount_ppn_real As Decimal = 0

                    row = Me.tbl_TrnJurnaldetil_Debit.NewRow
                    row.Item("currency_id") = tblJDetil.Rows(u).Item("currency_id")
                    row.Item("jurnaldetil_descr") = tblJDetil.Rows(u).Item("advance_descr")
                    '============remark pts 20140922=====================
                    'row.Item("jurnaldetil_idr") = CDec(tblJDetil.Rows(u).Item("ppn_idr")) 'String.Format("{0:#,##0}", CDec(tblJDetil.Rows(u).Item("ppn_idr")))
                    '==============PTS roundingan 20140922===============
                    If tblJDetil.Rows(u).Item("currency_id") = 1 Then
                        row.Item("jurnaldetil_idr") = String.Format("{0:#,##0}", Math.Round(CDec(tblJDetil.Rows(u).Item("ppn_foreign")), 0, MidpointRounding.AwayFromZero) * _
                                                                             CDec(tblJDetil.Rows(u).Item("jurnaldetil_foreignrate")))
                        row.Item("jurnaldetil_foreign") = String.Format("{0:#,##0.00}", Math.Round(CDec(tblJDetil.Rows(u).Item("ppn_foreign")), 0, MidpointRounding.AwayFromZero))
                    Else
                        row.Item("jurnaldetil_idr") = String.Format("{0:#,##0}", CDec(tblJDetil.Rows(u).Item("ppn_foreign")) * _
                                                                             CDec(tblJDetil.Rows(u).Item("jurnaldetil_foreignrate")))
                        row.Item("jurnaldetil_foreign") = String.Format("{0:#,##0.00}", CDec(tblJDetil.Rows(u).Item("ppn_foreign")))
                    End If                
                    '================================================================================================

                    row.Item("jurnaldetil_foreignrate") = String.Format("{0:#,##0.00}", CDec(tblJDetil.Rows(u).Item("jurnaldetil_foreignrate")))
                    row.Item("acc_id") = GetProdTypeBudgetID(tblJDetil.Rows(u).Item("budget_id"))
                    row.Item("jurnaldetil_descr") = "PPN" 'tblJDetil.Rows(u).Item("jurnaldetil_descr")
                    row.Item("ref_id") = tblJDetil.Rows(u).Item("ref_id")
                    row.Item("ref_line") = tblJDetil.Rows(u).Item("ref_line")
                    row.Item("ref_budgetline") = 0
                    row.Item("region_id") = clsUtil.IsDbNull(tblJDetil.Rows(u).Item("region_id"), 0)
                    row.Item("branch_id") = clsUtil.IsDbNull(tblJDetil.Rows(u).Item("branch_id"), 0)
                    row.Item("strukturunit_id") = clsUtil.IsDbNull(tblJDetil.Rows(u).Item("strukturunit_id"), 0)
                    row.Item("rekanan_id") = tblJDetil.Rows(u).Item("rekanan_id")
                    row.Item("rekanan_name") = tblJDetil.Rows(u).Item("rekanan_name")
                    row.Item("budget_id") = tblJDetil.Rows(u).Item("budget_id")
                    row.Item("budget_name") = tblJDetil.Rows(u).Item("budget_name")
                    row.Item("budgetdetil_id") = 0
                    row.Item("budgetdetil_name") = "-- PILIH --"
                    Me.tbl_TrnJurnaldetil_Debit.Rows.Add(row)


                    '=====================UNTUK REFERENCE NYA PPN=====
                    'Extract data for tabel Reference
                    row = Me.tbl_TrnJurnalReference.NewRow
                    row.Item("jurnaldetil_line") = Me.tbl_TrnJurnaldetil_Debit.Rows(Me.tbl_TrnJurnaldetil_Debit.Rows.Count - 1).Item("jurnaldetil_line")
                    row.Item("ref") = tblJDetil.Rows(u).Item("ref_id")
                    row.Item("line") = tblJDetil.Rows(u).Item("ref_line")
                    row.Item("descr") = tblJDetil.Rows(u).Item("jurnaldetil_descr")
                    row.Item("rate") = String.Format("{0:#,##0.00}", CDec(tblJDetil.Rows(u).Item("rate")))
                    If CDec(tblJDetil.Rows(u).Item("rate")) = 1 Then
                        row.Item("amount_foreign") = String.Format("{0:#,##0.00}", Math.Round(CDec(tblJDetil.Rows(u).Item("amount_foreign")), 0, MidpointRounding.AwayFromZero))
                        row.Item("amount_idr") = String.Format("{0:#,##0}", Math.Round(CDec(tblJDetil.Rows(u).Item("amount_idr")), 0, MidpointRounding.AwayFromZero))
                    Else
                        row.Item("amount_foreign") = String.Format("{0:#,##0.00}", CDec(tblJDetil.Rows(u).Item("amount_foreign")))
                        row.Item("amount_idr") = String.Format("{0:#,##0}", CDec(tblJDetil.Rows(u).Item("amount_idr")))
                    End If

                    row.Item("channel_id") = tblJDetil.Rows(u).Item("channel_id")
                    row.Item("rekanan_name") = tblJDetil.Rows(u).Item("rekanan_name")
                    row.Item("channel_id") = tblJDetil.Rows(u).Item("channel_id")
                    row.Item("strukturunit_name") = tblJDetil.Rows(u).Item("strukturunit_name")
                    row.Item("currency_name") = tblJDetil.Rows(u).Item("currency_name")
                    Me.tbl_TrnJurnalReference.Rows.Add(row)
                    '============================================================
                End If
            Next

        '=============================================EXTRACT Credit AMOUNT PPH ADVANCE =============================================================
            For u As Integer = 0 To tblJDetil.Rows.Count - 1

                If tblJDetil.Rows(u).Item("pph_foreign") <> 0 Then
                    Dim amount_ppn_foreign As Decimal = 0
                    Dim amount_ppn_real As Decimal = 0

                    row = Me.tbl_TrnJurnaldetil_Credit.NewRow
                    row.Item("currency_id") = tblJDetil.Rows(u).Item("currency_id")
                    row.Item("jurnaldetil_descr") = tblJDetil.Rows(u).Item("advance_descr")

                    '============remark pts 20140922=====================
                    'row.Item("jurnaldetil_idr") = String.Format("{0:#,##0}", CDec(tblJDetil.Rows(u).Item("pph_idr")))
                    '==============PTS roundingan 20140922===============
                    If tblJDetil.Rows(u).Item("currency_id") = 1 Then
                        row.Item("jurnaldetil_idr") = String.Format("{0:#,##0}", Math.Round(CDec(tblJDetil.Rows(u).Item("pph_foreign")), 0, MidpointRounding.AwayFromZero) * _
                                                                             Math.Round(CDec(tblJDetil.Rows(u).Item("jurnaldetil_foreignrate")), 2, MidpointRounding.AwayFromZero))
                        row.Item("jurnaldetil_foreign") = String.Format("{0:#,##0.00}", Math.Round(CDec(tblJDetil.Rows(u).Item("pph_foreign")), 0, MidpointRounding.AwayFromZero))

                    Else
                        row.Item("jurnaldetil_idr") = String.Format("{0:#,##0}", CDec(tblJDetil.Rows(u).Item("pph_foreign")) * _
                                                                             Math.Round(CDec(tblJDetil.Rows(u).Item("jurnaldetil_foreignrate")), 2, MidpointRounding.AwayFromZero))
                        row.Item("jurnaldetil_foreign") = String.Format("{0:#,##0.00}", CDec(tblJDetil.Rows(u).Item("pph_foreign")))
                    End If

                    
                    '====================================================
                    row.Item("jurnaldetil_foreignrate") = String.Format("{0:#,##0.00}", CDec(tblJDetil.Rows(u).Item("jurnaldetil_foreignrate")))
                    row.Item("acc_id") = IIf(amountIDR_total <= 5000000, 1111110, 1112106) '1111110 = Kas Umum, 1112106 = Danamon IDR
                    row.Item("jurnaldetil_descr") = "PPH" 'tblJDetil.Rows(u).Item("jurnaldetil_descr")
                    row.Item("ref_id") = tblJDetil.Rows(u).Item("ref_id")
                    row.Item("ref_line") = tblJDetil.Rows(u).Item("ref_line")
                    row.Item("ref_budgetline") = 0
                    row.Item("region_id") = clsUtil.IsDbNull(tblJDetil.Rows(u).Item("region_id"), 0)
                    row.Item("branch_id") = clsUtil.IsDbNull(tblJDetil.Rows(u).Item("branch_id"), 0)
                    row.Item("strukturunit_id") = clsUtil.IsDbNull(tblJDetil.Rows(u).Item("strukturunit_id"), 0)
                    row.Item("rekanan_id") = tblJDetil.Rows(u).Item("rekanan_id")
                    row.Item("rekanan_name") = tblJDetil.Rows(u).Item("rekanan_name")
                    row.Item("budget_id") = tblJDetil.Rows(u).Item("budget_id")
                    row.Item("budget_name") = tblJDetil.Rows(u).Item("budget_name")
                    row.Item("budgetdetil_id") = 0
                    row.Item("budgetdetil_name") = "-- PILIH --"
                    Me.tbl_TrnJurnaldetil_Credit.Rows.Add(row)


                    '=====================UNTUK REFERENCE NYA PPH=====
                    'Extract data for tabel Reference
                    row = Me.tbl_TrnJurnalReference.NewRow
                    row.Item("jurnaldetil_line") = Me.tbl_TrnJurnaldetil_Credit.Rows(Me.tbl_TrnJurnaldetil_Credit.Rows.Count - 1).Item("jurnaldetil_line")
                    row.Item("ref") = tblJDetil.Rows(u).Item("ref_id")
                    row.Item("line") = tblJDetil.Rows(u).Item("ref_line")
                    row.Item("descr") = tblJDetil.Rows(u).Item("jurnaldetil_descr")
                    row.Item("rate") = String.Format("{0:#,##0.00}", CDec(tblJDetil.Rows(u).Item("rate")))
                    If CDec(tblJDetil.Rows(u).Item("rate")) = 1 Then
                        row.Item("amount_foreign") = String.Format("{0:#,##0.00}", Math.Round(CDec(tblJDetil.Rows(u).Item("amount_foreign")), 0, MidpointRounding.AwayFromZero))
                        row.Item("amount_idr") = String.Format("{0:#,##0}", Math.Round(CDec(tblJDetil.Rows(u).Item("amount_idr")), 0, MidpointRounding.AwayFromZero))
                    Else
                        row.Item("amount_foreign") = String.Format("{0:#,##0.00}", CDec(tblJDetil.Rows(u).Item("amount_foreign")))
                        row.Item("amount_idr") = String.Format("{0:#,##0}", CDec(tblJDetil.Rows(u).Item("amount_idr")))
                    End If

                    row.Item("channel_id") = tblJDetil.Rows(u).Item("channel_id")
                    row.Item("rekanan_name") = tblJDetil.Rows(u).Item("rekanan_name")
                    row.Item("channel_id") = tblJDetil.Rows(u).Item("channel_id")
                    row.Item("strukturunit_name") = tblJDetil.Rows(u).Item("strukturunit_name")
                    row.Item("currency_name") = tblJDetil.Rows(u).Item("currency_name")
                    Me.tbl_TrnJurnalReference.Rows.Add(row)
                    '============================================================
                End If
            Next

        '===========================================================================================================================================
            Me.DgvTrnJurnalreference.DataSource = Me.tbl_TrnJurnalReference

            Me.uiTrnJurnal_PV_Advance_RowCalculate(Me.DgvTrnJurnaldetil_Debit, Me.DgvTrnJurnaldetil_Credit, selisih, jumlah)
            'Me.uiTrnJurnal_PV_Advance_RowCalculatePTS(Me.tbl_TrnJurnaldetil_Debit, Me.tbl_TrnJurnaldetil_Credit, selisih, jumlah)
            Me.obj_Selisih.Text = String.Format("{0:#,##0}", selisih)
            Me.obj_Jumlah.Text = String.Format("{0:#,##0}", jumlah)

            Me.uiTrnJurnal_PV_Advance_RowCalculateForeign(Me.DgvTrnJurnaldetil_Debit, Me.DgvTrnJurnaldetil_Credit, selisih, jumlah)
            Me.obj_Selisih_Foreign.Text = String.Format("{0:#,##0.00}", selisih)
            Me.obj_Jumlah_Foreign.Text = String.Format("{0:#,##0.00}", jumlah)
        End If

        'patch
        Me.DgvTrnJurnaldetil_Debit.Columns("jurnal_id").Visible = False
        Me.DgvTrnJurnaldetil_Credit.Columns("jurnal_id").Visible = False
    End Function
#End Region

#Region " User Defined Function "

    Private Function uiTrnJurnal_PV_Advance_NewData() As Boolean
        'new data
        RaiseEvent FormBeforeNew()

        Dim periodedefault As String

        '=======Add PTS 20131227=======Tambahan untuk dapat default periode by date now=========
        periodedefault = Me.channel_number & String.Format("{0:yyMM}", Now)
        '=======================================================================================

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
        Me.tbl_TrnJurnaldetil_Debit = clsDataset.CreateTblTrnJurnaldetil()
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
        Me.tbl_TrnJurnaldetil_Credit.Columns("paymenttype_id").DefaultValue = "0"
        Me.tbl_TrnJurnaldetil_Credit.Columns("jurnalbilyet_bank").DefaultValue = 0

        Me.DgvTrnJurnaldetil_Credit.DataSource = Me.tbl_TrnJurnaldetil_Credit

        'TODO: Set Default Value for tbl_JurnalReference
        Me.tbl_TrnJurnalReference.Clear()
        Me.tbl_TrnJurnalReference = clsDataset.CreateTblTrnJurnalreferencePayable()
        Me.DgvTrnJurnalreference.DataSource = Me.tbl_TrnJurnalReference

        'TODO: Set Default Value for tbl_JurnalResponse
        Me.tbl_TrnJurnalResponse.Clear()
        Me.tbl_TrnJurnalResponse = clsDataset.CreateTblTrnJurnalreference()
        Me.DgvTrnJurnalResponse.DataSource = Me.tbl_TrnJurnalResponse

        'TODO: Set Default Value for tbl_TrnBankTransfer
        Me.tbl_TrnBankTransfer.Clear()
        Me.tbl_TrnBankTransfer = clsDataset.CreateTblTrnBanktransfer()
        Me.tbl_TrnBankTransfer.Columns("channel_id").DefaultValue = Me._CHANNEL
        Me.dgvTrnBankTransfer.DataSource = Me.tbl_TrnBankTransfer

        'TODO: Set Default Value for tbl_JurnalInvoice tambahan tab detail invoice
        Me.tbl_trnJurnalRefTandaTerima.Clear()
        Me.DgvTrnJurnalInvoice.DataSource = Me.tbl_trnJurnalRefTandaTerima

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

        Me.obj_document_id.Text = String.Empty

        DATADETIL_OPENED = False
    End Function

    Private Function uiTrnJurnal_PV_Advance_Retrieve() As Boolean
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
            Me.DataFillLimit(Me.tbl_TrnJurnal, "act_TrnJurnalPVWithAmount_Select", criteria, Limit, Me.cboSearchChannel.SelectedValue)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Function

    Private Function uiTrnJurnal_PV_Advance_Save() As Boolean
        'save data
        Dim tbl_TrnJurnal_Temp_Changes As DataTable
        Dim tbl_TrnJurnaldetil_Debit_Changes As DataTable
        Dim tbl_TrnJurnaldetil_Credit_Changes As DataTable
        Dim tbl_TrnJurnalReference_Changes As DataTable
        Dim tbl_TrnBankTransfer_Changes As DataTable
        'tambahan aji
        Dim tbl_TrnJurnalRefTandaTerima_Changes As DataTable

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

        Me.dgvTrnBankTransfer.EndEdit()
        Me.BindingContext(Me.tbl_TrnBankTransfer).EndCurrentEdit()
        tbl_TrnBankTransfer_Changes = Me.tbl_TrnBankTransfer.GetChanges()
        If tbl_TrnBankTransfer_Changes IsNot Nothing Then
            If Me.tbl_TrnJurnal_Temp.Rows(0).RowState <> DataRowState.Added Then
                Me.obj_Modified_by.Text = Me.UserName
                Me.obj_Modified_dt.Text = Now()
            End If
        End If

        'tambahan aji
        Me.DgvTrnJurnalInvoice.EndEdit()
        Me.BindingContext(Me.tbl_trnJurnalRefTandaTerima).EndCurrentEdit()
        tbl_TrnJurnalRefTandaTerima_Changes = Me.tbl_trnJurnalRefTandaTerima.GetChanges()
        If tbl_TrnJurnalRefTandaTerima_Changes IsNot Nothing Then
            If Me.tbl_TrnJurnal_Temp.Rows(0).RowState = DataRowState.Deleted Then
                Me.obj_Modified_by.Text = Me.UserName
                Me.obj_Modified_dt.Text = Now()
            End If
        End If

        Me.BindingContext(Me.tbl_TrnJurnal_Temp).EndCurrentEdit()
        tbl_TrnJurnal_Temp_Changes = Me.tbl_TrnJurnal_Temp.GetChanges()

        Me.BindingContext(Me.tbl_TrnJurnalReference).EndCurrentEdit()
        tbl_TrnJurnalReference_Changes = Me.tbl_TrnJurnalReference.GetChanges()

        If tbl_TrnJurnal_Temp_Changes IsNot Nothing Or tbl_TrnJurnaldetil_Debit_Changes IsNot Nothing Or tbl_TrnJurnaldetil_Credit_Changes IsNot Nothing Or tbl_TrnJurnalReference_Changes IsNot Nothing Or tbl_TrnBankTransfer_Changes IsNot Nothing Then

            Try

                MasterDataState = tbl_TrnJurnal_Temp.Rows(0).RowState
                jurnal_id = tbl_TrnJurnal_Temp.Rows(0).Item("jurnal_id")

                If tbl_TrnJurnal_Temp_Changes IsNot Nothing Then
                    success = Me.uiTrnJurnal_PV_Advance_SaveMaster(jurnal_id, tbl_TrnJurnal_Temp_Changes, MasterDataState)
                    If Not success Then Throw New Exception("Error: Saving Master Data at Me.uiTrnJurnal_PV_Advance_SaveMaster(tbl_TrnJurnal_Temp_Changes)")
                    Me.tbl_TrnJurnal_Temp.AcceptChanges()
                End If

                If tbl_TrnJurnalReference_Changes IsNot Nothing Then
                    success = Me.uiTrnJurnal_PV_Advance_SaveReference(jurnal_id, tbl_TrnJurnalReference_Changes, MasterDataState)
                    If Not success Then Throw New Exception("Error: Saving Reference Data at Me.uiTrnJurnal_SaveMaster(tbl_TrnJurnal_Temp_Changes)")
                    Me.tbl_TrnJurnalReference.AcceptChanges()
                End If

                If tbl_TrnJurnaldetil_Debit_Changes IsNot Nothing Then
                    For i = 0 To Me.tbl_TrnJurnaldetil_Debit.Rows.Count - 1
                        If Me.tbl_TrnJurnaldetil_Debit.Rows(i).RowState = DataRowState.Added Then
                            Me.tbl_TrnJurnaldetil_Debit.Rows(i).Item("jurnal_id") = jurnal_id
                        End If
                    Next
                    success = Me.uiTrnJurnal_PV_Advance_SaveDetilDebit(jurnal_id, tbl_TrnJurnaldetil_Debit_Changes, MasterDataState)
                    If Not success Then Throw New Exception("Error: Save Detil Data at Me.uiTrnJurnal_PV_Advance_SaveDetil(tbl_TrnJurnaldetil_Debit_Changes)")
                    Me.tbl_TrnJurnaldetil_Debit.AcceptChanges()
                End If

                If tbl_TrnJurnaldetil_Credit_Changes IsNot Nothing Then
                    For i = 0 To Me.tbl_TrnJurnaldetil_Credit.Rows.Count - 1
                        If Me.tbl_TrnJurnaldetil_Credit.Rows(i).RowState = DataRowState.Added Then
                            Me.tbl_TrnJurnaldetil_Credit.Rows(i).Item("jurnal_id") = jurnal_id
                        End If
                    Next
                    Me.uiTrnJurnal_PV_Advance_TblDetilInverse(tbl_TrnJurnaldetil_Credit_Changes)
                    success = Me.uiTrnJurnal_PV_Advance_SaveDetilCredit(jurnal_id, tbl_TrnJurnaldetil_Credit_Changes, MasterDataState)
                    If Not success Then Throw New Exception("Error: Save Detil Data at Me.uiTrnJurnal_PV_Advance_SaveDetil(tbl_TrnJurnaldetil_Credit_Changes)")
                    Me.tbl_TrnJurnaldetil_Credit.AcceptChanges()
                End If

                If tbl_TrnBankTransfer_Changes IsNot Nothing Then
                    For i = 0 To Me.tbl_TrnBankTransfer.Rows.Count - 1
                        If Me.tbl_TrnBankTransfer.Rows(i).RowState = DataRowState.Added Then
                            Me.tbl_TrnBankTransfer.Rows(i).Item("jurnal_id") = jurnal_id
                        End If
                    Next
                    success = Me.uiTrnJurnal_PV_Advance_SaveTransfer(jurnal_id, tbl_TrnBankTransfer_Changes, MasterDataState)
                    If Not success Then Throw New Exception("Error: Save Detil Data at Me.uiTrnJurnal_PV_Advance_SaveTransfer(tbl_TrnBankTransfer_Changes)")
                    Me.tbl_TrnBankTransfer.AcceptChanges()
                End If

                'tambahan aji ketika refensi tanda terima (invoice) di hapus
                If tbl_TrnJurnalRefTandaTerima_Changes IsNot Nothing Then
                    success = Me.uiTrnJurnal_PV_List_AP_DeleteRefTandaTerima(jurnal_id, tbl_TrnJurnalRefTandaTerima_Changes, MasterDataState)
                    If Not success Then Throw New Exception("Error: Save Detil Data at Me.uiTrnJurnal_PV_List_AP_DeleteRefTandaTerima(tbl_TrnJurnalRefTandaTerima_Changes)")
                    Me.tbl_trnJurnalRefTandaTerima.AcceptChanges()
                End If
                '=end

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

    Private Function uiTrnJurnal_PV_Advance_SaveMaster(ByRef jurnal_id As Object, ByVal objTbl As DataTable, ByVal MasterDataState As System.Data.DataRowState) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbCmdInsert As OleDb.OleDbCommand
        Dim dbCmdUpdate As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

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
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@ae_id", System.Data.OleDb.OleDbType.Decimal, 5))
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

        Dim cookie As Byte() = Nothing

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
            Me.uiTrnJurnal_PV_Advance_Retrieve()
            Me.BindingContext(Me.tbl_TrnJurnal).Position = 0
            Me.locking.TryLocking(jurnal_id)
            ' ''ElseIf MasterDataState = DataRowState.Modified Then
            ' ''    curpos = Me.BindingContext(Me.tbl_TrnJurnal).Position
            ' ''    Me.tbl_TrnJurnal.Rows.RemoveAt(curpos)
            ' ''    Me.tbl_TrnJurnal.Merge(objTbl)
        End If

        ' ''Me.BindingContext(Me.tbl_TrnJurnal).Position = Me.BindingContext(Me.tbl_TrnJurnal).Count

        Return True
    End Function

    Private Function uiTrnJurnal_PV_Advance_SaveDetilDebit(ByRef jurnal_id As Object, ByVal objTbl As DataTable, ByVal MasterDataState As System.Data.DataRowState) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbCmdInsert As OleDb.OleDbCommand
        Dim dbCmdUpdate As OleDb.OleDbCommand
        Dim dbCmdDelete As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        ' Save data: Transaksi_jurnaldetil
        dbCmdInsert = New OleDb.OleDbCommand("act_TrnJurnaldetil_Insert", dbConn)
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
        dbCmdInsert.Parameters("@jurnal_id").Value = jurnal_id
        dbCmdInsert.Parameters("@jurnaldetil_dk").Value = "D"
        dbCmdInsert.Parameters("@username").Value = Me.UserName
        dbCmdInsert.Parameters("@channel_id").Value = Me._CHANNEL


        dbCmdUpdate = New OleDb.OleDbCommand("act_TrnJurnaldetil_Update", dbConn)
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

    Private Function uiTrnJurnal_PV_Advance_SaveDetilCredit(ByRef jurnal_id As Object, ByVal objTbl As DataTable, ByVal MasterDataState As System.Data.DataRowState) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbCmdInsert As OleDb.OleDbCommand
        Dim dbCmdUpdate As OleDb.OleDbCommand
        Dim dbCmdDelete As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

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

    Private Function uiTrnJurnal_PV_Advance_SaveReference(ByRef jurnal_id As Object, ByVal objTbl As DataTable, ByVal MasterDataState As System.Data.DataRowState) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbCmdInsert As OleDb.OleDbCommand
        Dim dbCmdDelete As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter


        ' Save data: transaksi_jurnaldetil
        dbCmdInsert = New OleDb.OleDbCommand("act_TrnJurnalreferenceAPListBQCQ_Insert", dbConn)
        dbCmdInsert.CommandType = CommandType.StoredProcedure
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_id", System.Data.OleDb.OleDbType.VarWChar, 24))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnaldetil_line", System.Data.OleDb.OleDbType.Integer, 4, "jurnaldetil_line"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_id_ref", System.Data.OleDb.OleDbType.VarWChar, 24, "ref"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_id_refline", System.Data.OleDb.OleDbType.Integer, 4, "line"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_id_budgetline", System.Data.OleDb.OleDbType.Integer, 4, "budget_line"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@referencetype", System.Data.OleDb.OleDbType.VarWChar, 30))
        dbCmdInsert.Parameters("@jurnal_id").Value = jurnal_id
        dbCmdInsert.Parameters("@referencetype").Value = "PAYMENT"

        dbCmdDelete = New OleDb.OleDbCommand("act_TrnJurnalreferenceAPListBQCQ_Delete", dbConn)
        dbCmdDelete.CommandType = CommandType.StoredProcedure
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_id", System.Data.OleDb.OleDbType.VarWChar, 24))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnaldetil_line", System.Data.OleDb.OleDbType.Integer, 4, "jurnaldetil_line"))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_id_ref", System.Data.OleDb.OleDbType.VarWChar, 24, "ref"))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_id_refline", System.Data.OleDb.OleDbType.Integer, 4, "line"))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_id_budgetline", System.Data.OleDb.OleDbType.Integer, 4, "budget_line"))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@referencetype", System.Data.OleDb.OleDbType.VarWChar, 30))
        dbCmdDelete.Parameters("@jurnal_id").Value = jurnal_id
        dbCmdDelete.Parameters("@referencetype").Value = "PAYMENT"

        dbDA = New OleDb.OleDbDataAdapter
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

    Private Function uiTrnJurnal_PV_Advance_SaveTransfer(ByRef jurnal_id As Object, ByVal objTbl As DataTable, ByVal MasterDataState As System.Data.DataRowState) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbCmdInsert As OleDb.OleDbCommand
        Dim dbCmdUpdate As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        dbCmdInsert = New OleDb.OleDbCommand("cp_TrnBanktransfer_Insert", dbConn)
        dbCmdInsert.CommandType = CommandType.StoredProcedure
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@banktransfer_id", System.Data.OleDb.OleDbType.VarWChar, 24, "banktransfer_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_id", System.Data.OleDb.OleDbType.VarWChar, 24))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnaldetil_line", System.Data.OleDb.OleDbType.Integer, 4, "jurnaldetil_line"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@banktransfer_dt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "banktransfer_dt"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@slipformat_id", System.Data.OleDb.OleDbType.VarWChar, 60, "slipformat_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@rekanan_id", System.Data.OleDb.OleDbType.VarWChar, 24, "rekanan_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@rekananbank_line", System.Data.OleDb.OleDbType.Integer, 4, "rekananbank_line"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@banktransfer_rekening", System.Data.OleDb.OleDbType.VarWChar, 100, "banktransfer_rekening"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@purposefund_id", System.Data.OleDb.OleDbType.Integer, 4, "purposefund_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@paymenttype_id", System.Data.OleDb.OleDbType.VarWChar, 6, "paymenttype_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@banktransfer_pembayaranrek", System.Data.OleDb.OleDbType.VarWChar, 100, "banktransfer_pembayaranrek"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@banktransfer_idr", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "banktransfer_idr", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@banktransfer_foreign", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "banktransfer_foreign", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@banktransfer_foreignrate", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "banktransfer_foreignrate", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@currency_id", System.Data.OleDb.OleDbType.VarWChar, 20, "currency_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@banktransfer_bi_idr", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "banktransfer_bi_idr", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@banktransfer_bi_foreign", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "banktransfer_bi_foreign", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@banktransfer_message", System.Data.OleDb.OleDbType.VarWChar, 510, "banktransfer_message"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20, "channel_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@banktransfer_isdisabled", System.Data.OleDb.OleDbType.Integer, 4, "banktransfer_isdisabled"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@banktransfer_invoice", System.Data.OleDb.OleDbType.VarWChar, 208, "banktransfer_invoice"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@banktransfer_episode1", System.Data.OleDb.OleDbType.Integer, 4, "banktransfer_episode1"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@banktransfer_episode2", System.Data.OleDb.OleDbType.Integer, 4, "banktransfer_episode2"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@project_id", System.Data.OleDb.OleDbType.VarWChar, 24, "project_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@rekananartis_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(7, Byte), CType(0, Byte), "rekananartis_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@banktransfer_episode", System.Data.OleDb.OleDbType.VarWChar, 50, "banktransfer_episode"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channelbank_line", System.Data.OleDb.OleDbType.Integer, 4, "channelbank_line"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@banktransfer_create_by", System.Data.OleDb.OleDbType.VarWChar, 100))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@banktransfer_create_date", System.Data.OleDb.OleDbType.DBTimeStamp, 4))
        dbCmdInsert.Parameters("@jurnal_id").Value = jurnal_id
        dbCmdInsert.Parameters("@banktransfer_create_by").Value = Me.UserName
        dbCmdInsert.Parameters("@banktransfer_create_date").Value = Now()


        dbCmdUpdate = New OleDb.OleDbCommand("cp_TrnBanktransfer_Update", dbConn)
        dbCmdUpdate.CommandType = CommandType.StoredProcedure
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@banktransfer_id", System.Data.OleDb.OleDbType.VarWChar, 24, "banktransfer_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_id", System.Data.OleDb.OleDbType.VarWChar, 24))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnaldetil_line", System.Data.OleDb.OleDbType.Integer, 4, "jurnaldetil_line"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@banktransfer_dt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "banktransfer_dt"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@slipformat_id", System.Data.OleDb.OleDbType.VarWChar, 60, "slipformat_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@rekanan_id", System.Data.OleDb.OleDbType.VarWChar, 24, "rekanan_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@rekananbank_line", System.Data.OleDb.OleDbType.Integer, 4, "rekananbank_line"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@banktransfer_rekening", System.Data.OleDb.OleDbType.VarWChar, 100, "banktransfer_rekening"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@purposefund_id", System.Data.OleDb.OleDbType.Integer, 4, "purposefund_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@paymenttype_id", System.Data.OleDb.OleDbType.VarWChar, 6, "paymenttype_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@banktransfer_pembayaranrek", System.Data.OleDb.OleDbType.VarWChar, 100, "banktransfer_pembayaranrek"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@banktransfer_idr", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "banktransfer_idr", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@banktransfer_foreign", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "banktransfer_foreign", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@banktransfer_foreignrate", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "banktransfer_foreignrate", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@currency_id", System.Data.OleDb.OleDbType.VarWChar, 20, "currency_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@banktransfer_bi_idr", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "banktransfer_bi_idr", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@banktransfer_bi_foreign", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "banktransfer_bi_foreign", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@banktransfer_message", System.Data.OleDb.OleDbType.VarWChar, 510, "banktransfer_message"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20, "channel_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@banktransfer_isdisabled", System.Data.OleDb.OleDbType.Integer, 4, "banktransfer_isdisabled"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@banktransfer_invoice", System.Data.OleDb.OleDbType.VarWChar, 208, "banktransfer_invoice"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@banktransfer_episode1", System.Data.OleDb.OleDbType.Integer, 4, "banktransfer_episode1"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@banktransfer_episode2", System.Data.OleDb.OleDbType.Integer, 4, "banktransfer_episode2"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@project_id", System.Data.OleDb.OleDbType.VarWChar, 24, "project_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@rekananartis_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(7, Byte), CType(0, Byte), "rekananartis_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@banktransfer_episode", System.Data.OleDb.OleDbType.VarWChar, 50, "banktransfer_episode"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channelbank_line", System.Data.OleDb.OleDbType.Integer, 4, "channelbank_line"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@banktransfer_create_by", System.Data.OleDb.OleDbType.VarWChar, 100, "banktransfer_create_by"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@banktransfer_create_date", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "banktransfer_create_date"))
        dbCmdUpdate.Parameters("@jurnal_id").Value = jurnal_id

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

        Return True
    End Function

    Private Function uiTrnJurnal_PV_Advance_Delete() As Boolean
        Dim res As String = ""
        Dim jurnal_id As Object = New Object

        Me.Cursor = Cursors.WaitCursor
        RaiseEvent FormBeforeDelete(jurnal_id)

        Me.Cursor = Cursors.WaitCursor
        If Me.DgvTrnJurnal.CurrentRow IsNot Nothing Then

            res = MessageBox.Show("Are you sure want to delete data ?", mUiName, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If res = DialogResult.Yes Then
                Me.uiTrnJurnal_PV_Advance_DeleteRow(Me.DgvTrnJurnal.CurrentRow.Index)
            End If

        End If

        RaiseEvent FormAfterDelete(jurnal_id)
        Me.Cursor = Cursors.Arrow

    End Function

    Private Function uiTrnJurnal_PV_Advance_DeleteRow(ByVal rowIndex As Integer) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbCmdDelete As OleDb.OleDbCommand
        Dim jurnal_id As String
        Dim NewRowIndex As Integer
        Dim i As Integer
        Dim dbCmdUpdate As OleDb.OleDbCommand
        Dim query As String

        jurnal_id = Me.DgvTrnJurnal.Rows(rowIndex).Cells("jurnal_id").Value

        Dim cookie As Byte() = Nothing

        Try
            dbConn.Open()
            clsApplicationRole.SetAppRole(dbConn, cookie)

            For i = 0 To Me.tbl_TrnJurnalReference.Rows.Count - 1
                query = String.Format("UPDATE E_FRM.dbo.transaksi_advance_detil SET advancedetil_ordered = 0, 	advancedetil_refreference = '' 	WHERE advance_id = '{0}' AND advancedetil_line = {1} ", Me.tbl_TrnJurnalReference.Rows(i).Item("ref"), Me.tbl_TrnJurnalReference.Rows(i).Item("line"))
                dbCmdUpdate = New OleDb.OleDbCommand(query, dbConn)
                dbCmdUpdate.CommandType = CommandType.Text
                dbCmdUpdate.ExecuteNonQuery()
            Next

            dbCmdDelete = New OleDb.OleDbCommand("act_TrnJurnal_Disabled", dbConn)
            dbCmdDelete.CommandType = CommandType.StoredProcedure
            dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_id", System.Data.OleDb.OleDbType.VarWChar, 24))
            dbCmdDelete.Parameters("@jurnal_id").Value = jurnal_id
            dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_isdisabledby", System.Data.OleDb.OleDbType.VarWChar, 32))
            dbCmdDelete.Parameters("@jurnal_isdisabledby").Value = Me.UserName
            dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_isdisableddt", System.Data.OleDb.OleDbType.DBTimeStamp, 4))
            dbCmdDelete.Parameters("@jurnal_isdisableddt").Value = Now.Date
            dbCmdDelete.ExecuteNonQuery()

            If Me.DgvTrnJurnal.Rows.Count > 1 Then
                If rowIndex = 0 Then
                    NewRowIndex = rowIndex + 1
                    Me.uiTrnJurnal_PV_Advance_OpenRow(NewRowIndex)
                ElseIf rowIndex = Me.DgvTrnJurnal.Rows.Count - 1 Then
                    NewRowIndex = rowIndex - 1
                    Me.uiTrnJurnal_PV_Advance_OpenRow(NewRowIndex)
                Else
                    Me.uiTrnJurnal_PV_Advance_OpenRow(rowIndex)
                End If
            Else
                Me.tbl_TrnJurnal_Temp.Clear()
                Me.uiTrnJurnal_PV_Advance_NewData()
            End If

            Me.locking.Clear()
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

    Private Function uiTrnJurnal_PV_Advance_OpenRow(ByVal rowIndex As Integer) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim jurnal_id As String
        Dim channel_id As String

        jurnal_id = Me.DgvTrnJurnal.Rows(rowIndex).Cells("jurnal_id").Value
        channel_id = Me.DgvTrnJurnal.Rows(rowIndex).Cells("channel_id").Value

        Me.Cursor = Cursors.WaitCursor
        RaiseEvent FormBeforeOpenRow(jurnal_id)

        Dim cookie As Byte() = Nothing

        Try
            dbConn.Open()
            clsApplicationRole.SetAppRole(dbConn, cookie)
            Me.uiTrnJurnal_PV_Advance_OpenRowMaster(channel_id, jurnal_id, dbConn)
            Me.uiTrnJurnal_PV_Advance_OpenRowDetilDebit(channel_id, jurnal_id, dbConn)
            Me.uiTrnJurnal_PV_Advance_OpenRowDetilCredit(channel_id, jurnal_id, dbConn)
            Me.uiTrnJurnal_PV_Advance_OpenRowReference(channel_id, jurnal_id, dbConn)
            Me.uiTrnJurnal_PV_Advance_OpenRowResponse(channel_id, jurnal_id, dbConn)
            Me.uiTrnJurnal_PV_Advance_OpenRowTransfer(channel_id, jurnal_id, dbConn)
            Me.uiTrnJurnal_PV_Advance_OpenRowBankLink(channel_id, jurnal_id, dbConn)
            Me.uiTrnJurnal_PV_Advance_OpenRowContract(jurnal_id, dbConn)
            Me.uiTrnJurnal_PV_Advance_OpenRowInvoice(channel_id, jurnal_id, dbConn)

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
        Catch ex As Exception
            MessageBox.Show(ex.Message, mUiName & ": uiTrnJurnal_PV_Advance_OpenRow()", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            clsApplicationRole.UnsetAppRole(dbConn, cookie)
            dbConn.Close()
        End Try

        RaiseEvent FormAfterOpenRow(jurnal_id)

        Me.DgvTrnJurnaldetil_Credit.Columns("jurnal_id").Visible = False
        Me.DgvTrnJurnaldetil_Debit.Columns("jurnal_id").Visible = False
        Me.Cursor = Cursors.Arrow

        Return True
    End Function

    Private Function uiTrnJurnal_PV_Advance_OpenRowMaster(ByVal channel_id As String, ByVal jurnal_id As String, ByVal dbConn As OleDb.OleDbConnection) As Boolean
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
            Throw New Exception(mUiName & ": uiTrnJurnal_PV_Advance_OpenRowMaster()" & vbCrLf & ex.Message)
        End Try

    End Function

    Private Function uiTrnJurnal_PV_Advance_OpenRowDetilDebit(ByVal channel_id As String, ByVal jurnal_id As String, ByVal dbConn As OleDb.OleDbConnection) As Boolean
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        dbCmd = New OleDb.OleDbCommand("act_TrnJurnaldetil_Select", dbConn)
        dbCmd.Parameters.Add("@channel_id", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@channel_id").Value = channel_id
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@Criteria").Value = String.Format("jurnal_id = '{0}' AND jurnaldetil_dk = 'D'", jurnal_id)
        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)

        Me.tbl_TrnJurnaldetil_Debit.Clear()
        Me.tbl_TrnJurnaldetil_Debit = clsDataset.CreateTblTrnJurnaldetil()
        Me.tbl_TrnJurnaldetil_Debit.Columns("jurnal_id").DefaultValue = jurnal_id
        Me.tbl_TrnJurnaldetil_Debit.Columns("jurnaldetil_line").DefaultValue = DBNull.Value
        Me.tbl_TrnJurnaldetil_Debit.Columns("jurnaldetil_line").AutoIncrement = True
        Me.tbl_TrnJurnaldetil_Debit.Columns("jurnaldetil_line").AutoIncrementSeed = 10
        Me.tbl_TrnJurnaldetil_Debit.Columns("jurnaldetil_line").AutoIncrementStep = 10
        Me.tbl_TrnJurnaldetil_Debit.Columns("currency_id").DefaultValue = 1
        Me.tbl_TrnJurnaldetil_Debit.Columns("jurnaldetil_foreignrate").DefaultValue = 1
        Me.tbl_TrnJurnaldetil_Debit.Columns("channel_id").DefaultValue = Me._CHANNEL
        Me.tbl_TrnJurnaldetil_Debit.Columns("jurnaldetil_dk").DefaultValue = "D"
        Try
            dbDA.Fill(Me.tbl_TrnJurnaldetil_Debit)
            Me.DgvTrnJurnaldetil_Debit.DataSource = Me.tbl_TrnJurnaldetil_Debit
        Catch ex As Exception
            Throw New Exception(mUiName & ": uiTrnJurnal_PV_Advance_OpenRowDetilDebit()" & vbCrLf & ex.Message)
        End Try

    End Function

    Private Function uiTrnJurnal_PV_Advance_OpenRowDetilCredit(ByVal channel_id As String, ByVal jurnal_id As String, ByVal dbConn As OleDb.OleDbConnection) As Boolean
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
            Me.uiTrnJurnal_PV_Advance_TblDetilInverse(Me.tbl_TrnJurnaldetil_Credit)
            Me.DgvTrnJurnaldetil_Credit.DataSource = Me.tbl_TrnJurnaldetil_Credit

        Catch ex As Exception
            Throw New Exception(mUiName & ": uiTrnJurnal_PV_Advance_OpenRowDetilCredit()" & vbCrLf & ex.Message)
        End Try

    End Function

    Private Function uiTrnJurnal_PV_Advance_OpenRowReference(ByVal channel_id As String, ByVal jurnal_id As String, ByVal dbConn As OleDb.OleDbConnection) As Boolean
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter
        '============================REmark PTS 20140925============================
        'dbCmd = New OleDb.OleDbCommand("act_TrnJurnalReferencePVselectVQ_Select", dbConn)
        '============modified 20140925=============================================
        dbCmd = New OleDb.OleDbCommand("act_TrnJurnalReferencePVselectVQ_Order_Select", dbConn)
        '============================================================================

        dbCmd.Parameters.Add("@channel_id", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@channel_id").Value = channel_id
        dbCmd.Parameters.Add("@jurnal_id", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@jurnal_id").Value = jurnal_id
        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)

        Try
            Me.tbl_TrnJurnalReference.Clear()
            dbDA.Fill(Me.tbl_TrnJurnalReference)
            Me.DgvTrnJurnalreference.DataSource = Me.tbl_TrnJurnalReference
        Catch ex As Exception
            Throw New Exception(mUiName & ": uiTrnJurnal_OpenRowReference()" & vbCrLf & ex.Message)
        End Try

    End Function

    Private Function uiTrnJurnal_PV_Advance_OpenRowResponse(ByVal channel_id As String, ByVal jurnal_id As String, ByVal dbConn As OleDb.OleDbConnection) As Boolean
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        'dbCmd = New OleDb.OleDbCommand("act_TrnJurnalResponse_Select", dbConn)
        dbCmd = New OleDb.OleDbCommand("act_TrnJurnalResponse_ChangeUser_Select", dbConn)
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

    Private Function uiTrnJurnal_PV_Advance_OpenRowTransfer(ByVal channel_id As String, ByVal jurnal_id As String, ByVal dbConn As OleDb.OleDbConnection) As Boolean
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        dbCmd = New OleDb.OleDbCommand("cp_TrnBanktransfer_Select_2", dbConn)
        dbCmd.Parameters.Add("@channel_id", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@channel_id").Value = Me._CHANNEL
        dbCmd.Parameters.Add("@jurnal_id", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@jurnal_id").Value = jurnal_id
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@Criteria").Value = String.Empty

        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)

        Me.tbl_TrnBankTransferGrid.Clear()
        Try
            '  dbDA.Fill(Me.tbl_TrnBankTransfer)
            dbDA.Fill(Me.tbl_TrnBankTransferGrid)
            Me.dgvTrnBankTransfer.DataSource = Me.tbl_TrnBankTransferGrid
        Catch ex As Exception
            Throw New Exception(mUiName & ": uiTrnJurnal_OpenRowTransfer()" & vbCrLf & ex.Message)
        End Try

    End Function

    Private Function uiTrnJurnal_PV_Advance_OpenRowBankLink(ByVal channel_id As String, ByVal jurnal_id As String, ByVal dbConn As OleDb.OleDbConnection) As Boolean
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        'dbCmd = New OleDb.OleDbCommand("act_TrnBankentrydetil_Select", dbConn)
        '' ''dbCmd.Parameters.Add("@channel_id", Data.OleDb.OleDbType.VarChar)
        '' ''dbCmd.Parameters("@channel_id").Value = channel_id
        'dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
        'dbCmd.Parameters("@Criteria").Value = String.Format("bankentrydetil_refid='{0}'", jurnal_id)

        '=================================================================================================
        ' Modify By MDP2 NET 27 Juni 2014 15:54 WIB | Modify Ari MDP2 NET 14 Juli 2016
        '=================================================================================================
        'dbCmd = New OleDb.OleDbCommand("act_TrnBankEntryResponse_Select", dbConn)
        'dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
        'dbCmd.Parameters("@Criteria").Value = String.Format("b.jurnal_id_ref = '{0}'", jurnal_id)

        dbCmd = New OleDb.OleDbCommand("act_TrnBankEntryResponse_Select2", dbConn)
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@Criteria").Value = String.Format("a.jurnal_id = '{0}'", jurnal_id) 'String.Format("b.jurnal_id_ref = '{0}'", jurnal_id)
        '=================================================================================================

        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)
        Me.tbl_TrnBankentrydetil.Clear()

        Try
            dbDA.Fill(Me.tbl_TrnBankentrydetil)
            Me.DgvTrnJurnal_BankLink.DataSource = Me.tbl_TrnBankentrydetil
            Me.DgvTrnJurnal_BankLink.AllowUserToAddRows = False
        Catch ex As Exception
            Throw New Exception(mUiName & ": uiTrnJurnal_PV_List_AP_OpenRowBankLink()" & vbCrLf & ex.Message)
        End Try

    End Function

    'tambahan aji
    Private Function uiTrnJurnal_PV_Advance_OpenRowInvoice(ByVal channel_id As String, ByVal jurnal_id As String, ByVal dbConn As OleDb.OleDbConnection) As Boolean
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        dbCmd = New OleDb.OleDbCommand("act_TrnJurnalReferenceTandaTerima_Select", dbConn)
        dbCmd.Parameters.Add("@channel_id", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@channel_id").Value = channel_id
        dbCmd.Parameters.Add("@jurnal_id", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@jurnal_id").Value = jurnal_id
        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)

        Try
            Me.tbl_trnJurnalRefTandaTerima.Clear()
            dbDA.Fill(Me.tbl_trnJurnalRefTandaTerima)
            Me.DgvTrnJurnalInvoice.DataSource = Me.tbl_trnJurnalRefTandaTerima
        Catch ex As Exception
            Throw New Exception(mUiName & ": uiTrnJurnal_OpenRowinvoice()" & vbCrLf & ex.Message)
        End Try

    End Function

    Private Function uiTrnJurnal_PV_Advance_First() As Boolean
        'goto first record found
        Dim move As Boolean
        Dim Message As String = "Data has been changed. " & vbCrLf & "Save data changes before move to first record ?"
        Dim iTab As Integer = Me.ftabMain.SelectedIndex

        If iTab = 1 Then
            If Me.DATA_ISLOCKED Then
                move = True
            Else
                move = Me.uiTrnJurnal_PV_Advance_ConfirmSaveBeforeMove(Message)
            End If
        Else
            move = True
        End If

        If move Then
            Try
                Me.DgvTrnJurnal.CurrentCell = Me.DgvTrnJurnal(0, Me.DgvTrnJurnal.Rows.Count - 1)
                Me.uiTrnJurnal_PV_Advance_RefreshPosition()
            Catch ex As Exception
            End Try
        End If
    End Function

    Private Function uiTrnJurnal_PV_Advance_Prev() As Boolean
        'goto previous record found
        Dim move As Boolean
        Dim Message As String = "Data has been changed. " & vbCrLf & "Save data changes before move to previous record ?"
        Dim iTab As Integer = Me.ftabMain.SelectedIndex

        If iTab = 1 Then
            If Me.DATA_ISLOCKED Then
                move = True
            Else
                move = Me.uiTrnJurnal_PV_Advance_ConfirmSaveBeforeMove(Message)
            End If
        Else
            move = True
        End If

        If move Then
            Try
                If Me.DgvTrnJurnal.CurrentCell.RowIndex < Me.DgvTrnJurnal.Rows.Count - 1 Then
                    Me.DgvTrnJurnal.CurrentCell = Me.DgvTrnJurnal(0, DgvTrnJurnal.CurrentCell.RowIndex + 1)
                    Me.uiTrnJurnal_PV_Advance_RefreshPosition()
                End If
            Catch ex As Exception
            End Try
        End If
    End Function

    Private Function uiTrnJurnal_PV_Advance_Next() As Boolean
        'goto next record found
        Dim move As Boolean
        Dim Message As String = "Data has been changed. " & vbCrLf & "Save data changes before move to next record ?"
        Dim iTab As Integer = Me.ftabMain.SelectedIndex

        If iTab = 1 Then
            If Me.DATA_ISLOCKED Then
                move = True
            Else
                move = Me.uiTrnJurnal_PV_Advance_ConfirmSaveBeforeMove(Message)
            End If
        Else
            move = True
        End If

        If move Then
            Try

                If Me.DgvTrnJurnal.CurrentCell.RowIndex > 0 Then
                    Me.DgvTrnJurnal.CurrentCell = Me.DgvTrnJurnal(0, DgvTrnJurnal.CurrentCell.RowIndex - 1)
                    Me.uiTrnJurnal_PV_Advance_RefreshPosition()
                End If
            Catch ex As Exception
            End Try
        End If
    End Function

    Private Function uiTrnJurnal_PV_Advance_Last() As Boolean
        'goto last record found
        Dim move As Boolean
        Dim Message As String = "Data has been changed. " & vbCrLf & "Save data changes before move to next record ?"
        Dim iTab As Integer = Me.ftabMain.SelectedIndex

        If iTab = 1 Then
            If Me.DATA_ISLOCKED Then
                move = True
            Else
                move = Me.uiTrnJurnal_PV_Advance_ConfirmSaveBeforeMove(Message)
            End If
        Else
            move = True
        End If

        If move Then

            Try
                If move Then
                    Me.DgvTrnJurnal.CurrentCell = Me.DgvTrnJurnal(0, 0)
                    Me.uiTrnJurnal_PV_Advance_RefreshPosition()
                End If
            Catch ex As Exception
            End Try
        End If
    End Function

    Private Function uiTrnJurnal_PV_Advance_RefreshPosition() As Boolean
        'refresh position
        Dim iTab As Integer = Me.ftabMain.SelectedIndex
        If iTab = 1 Then uiTrnJurnal_PV_Advance_OpenRow(Me.DgvTrnJurnal.CurrentRow.Index)
    End Function

    Private Function uiTrnJurnal_PV_Advance_ConfirmSaveBeforeMove(ByVal Message As String) As Boolean
        'confirm saving data changes before move
        Dim tbl_TrnJurnal_Temp_Changes As DataTable
        Dim tbl_TrnJurnaldetil_Debit_Changes As DataTable
        Dim tbl_TrnJurnaldetil_Credit_Changes As DataTable
        Dim tbl_TrnJurnalReference_Changes As DataTable
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

            Me.BindingContext(Me.tbl_TrnJurnalReference).EndCurrentEdit()
            tbl_TrnJurnalReference_Changes = Me.tbl_TrnJurnalReference.GetChanges()

            If tbl_TrnJurnal_Temp_Changes IsNot Nothing Or tbl_TrnJurnaldetil_Debit_Changes IsNot Nothing Or tbl_TrnJurnaldetil_Credit_Changes IsNot Nothing Or tbl_TrnJurnalReference_Changes IsNot Nothing Then

                res = MessageBox.Show(Message, mUiName, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                Select Case res
                    Case DialogResult.Yes

                        RaiseEvent FormBeforeSave(jurnal_id)

                        Try

                            MasterDataState = tbl_TrnJurnal_Temp.Rows(0).RowState
                            jurnal_id = tbl_TrnJurnal_Temp.Rows(0).Item("jurnal_id")

                            If tbl_TrnJurnal_Temp_Changes IsNot Nothing Then
                                success = Me.uiTrnJurnal_PV_Advance_SaveMaster(jurnal_id, tbl_TrnJurnal_Temp_Changes, MasterDataState)
                                If Not success Then Throw New Exception("Error: Saving Master Data at Me.uiTrnJurnal_PV_Advance_SaveMaster(tbl_TrnJurnal_Temp_Changes)")
                                Me.tbl_TrnJurnal_Temp.AcceptChanges()
                            End If

                            If tbl_TrnJurnalReference_Changes IsNot Nothing Then
                                success = Me.uiTrnJurnal_PV_Advance_SaveReference(jurnal_id, tbl_TrnJurnalReference_Changes, MasterDataState)
                                If Not success Then Throw New Exception("Error: Saving Reference Data at Me.uiTrnJurnal_SaveMaster(tbl_TrnJurnal_Temp_Changes)")
                                Me.tbl_TrnJurnalReference.AcceptChanges()
                            End If

                            If tbl_TrnJurnaldetil_Debit_Changes IsNot Nothing Then
                                For i = 0 To Me.tbl_TrnJurnaldetil_Debit.Rows.Count - 1
                                    If Me.tbl_TrnJurnaldetil_Debit.Rows(i).RowState = DataRowState.Added Then
                                        Me.tbl_TrnJurnaldetil_Debit.Rows(i).Item("jurnal_id") = jurnal_id
                                    End If
                                Next
                                success = Me.uiTrnJurnal_PV_Advance_SaveDetilDebit(jurnal_id, tbl_TrnJurnaldetil_Debit_Changes, MasterDataState)
                                If Not success Then Throw New Exception("Error: Save Detil Data at Me.uiTrnJurnal_PV_Advance_SaveDetil(tbl_TrnJurnaldetil_Debit_Changes)")
                                Me.tbl_TrnJurnaldetil_Debit.AcceptChanges()
                            End If

                            If tbl_TrnJurnaldetil_Credit_Changes IsNot Nothing Then
                                For i = 0 To Me.tbl_TrnJurnaldetil_Credit.Rows.Count - 1
                                    If Me.tbl_TrnJurnaldetil_Credit.Rows(i).RowState = DataRowState.Added Then
                                        Me.tbl_TrnJurnaldetil_Credit.Rows(i).Item("jurnal_id") = jurnal_id
                                    End If
                                Next
                                Me.uiTrnJurnal_PV_Advance_TblDetilInverse(tbl_TrnJurnaldetil_Credit_Changes)
                                success = Me.uiTrnJurnal_PV_Advance_SaveDetilCredit(jurnal_id, tbl_TrnJurnaldetil_Credit_Changes, MasterDataState)
                                If Not success Then Throw New Exception("Error: Save Detil Data at Me.uiTrnJurnal_PV_Advance_SaveDetil(tbl_TrnJurnaldetil_Credit_Changes)")
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

    Private Function uiTrnJurnal_PV_Advance_FormError() As Boolean
        Dim message As String = ""
        Try
            ' TODO: Cek Error disini
            ' objFormError.SetError()

            'Cek Reference
            message = "Reference Journal is still empty." & vbCrLf & "Please fill out the data from reference"
            If Me.DgvTrnJurnalreference.Rows.Count <= 0 Then
                Throw New Exception(message)
            End If

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

            ''cek book date dan tanggal periode
            'Dim dr() As DataRow = Me.tbl_MstPeriode.Select(String.Format("periode_id='{0}'", Me.obj_Periode_id.SelectedValue))
            'Dim tgl_start As Date = dr(0).Item("periode_datestart")
            'Dim tgl_end As Date = dr(0).Item("periode_dateend")
            'Dim tgl As Date = CDate(Me.obj_Jurnal_bookdate.Value).Date

            'cek tbl_jurnal

            'modifikasi by ari prasasti 13 july 2011
            'ditambahkan kondisi untuk posting
            'apabila data sudah ada, dan akan di ubah periodenya sedangkan periode yang di ubah telah di close
            'maka perubahan tidak akan terjadi

            'jika obj_Jurnal_id tidak kosong
            If Me.obj_Jurnal_id.Text <> String.Empty Then
                If Me.tbtnSave.Enabled = False Then
                    'ambil baris dari tabel transaksi jurnal berdasarkan jurnal id yang ada di obj_Jurnal_id
                    Dim jr() As DataRow = Me.tbl_TrnJurnal.Select(String.Format("jurnal_id='{0}'", Me.obj_Jurnal_id.Text))
                    'ambil isi dari periode_id dari tabel jurnal
                    Dim period As String = jr(0).Item("periode_id")

                    'jika variabel period tidak sama dengan 0
                    If period <> 0 Then
                        'maka fill ke dalam tabel periode dimana criteria berdasarakan variabel period
                        Dim dr() As DataRow = Me.tbl_MstPeriode.Select(String.Format("periode_id='{0}'", period))
                        Dim tgl_start As Date = dr(0).Item("periode_datestart")
                        Dim tgl_end As Date = dr(0).Item("periode_dateend")
                        Dim tgl As Date = CDate(Me.obj_Jurnal_bookdate.Value).Date

                        'jika variabel periode_isclosed bernilai 1 atau true 
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
                    End If
                Else
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
                End If
            Else
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
            End If

            'cek balance
            ' Tambahan pengecekan balance Tgl 14 Oktober 2015 Ari MDP2
            '=======================================================================================
            '==== ari 20151014 ===
            'For r As Integer = 0 To Me.DgvTrnJurnaldetil_Debit.Rows.Count - 1
            '    If Me.DgvTrnJurnaldetil_Debit.Rows(r).Cells("acc_id").Value <> akun8002000 Then
            '        Me.uiTrnJurnal_PV_Advance_RowCalcIDR(Me.DgvTrnJurnaldetil_Debit, Me.DgvTrnJurnaldetil_Debit.Rows(r).Cells("jurnaldetil_idr"), Me.DgvTrnJurnaldetil_Debit.Rows(r).Cells("jurnaldetil_foreign"), Me.DgvTrnJurnaldetil_Debit.Rows(r).Cells("jurnaldetil_foreignrate"))
            '    End If
            'Next

            'For r As Integer = 0 To Me.DgvTrnJurnaldetil_Credit.Rows.Count - 1
            '    If Me.DgvTrnJurnaldetil_Credit.Rows(r).Cells("acc_id").Value <> akun8002000 Then
            '        Me.uiTrnJurnal_PV_Advance_RowCalcIDR(Me.DgvTrnJurnaldetil_Credit, Me.DgvTrnJurnaldetil_Credit.Rows(r).Cells("jurnaldetil_idr"), Me.DgvTrnJurnaldetil_Credit.Rows(r).Cells("jurnaldetil_foreign"), Me.DgvTrnJurnaldetil_Credit.Rows(r).Cells("jurnaldetil_foreignrate"))
            '    End If
            'Next


            For r As Integer = 0 To Me.DgvTrnJurnaldetil_Debit.Rows.Count - 1
                'If Me.DgvTrnJurnaldetil_Debit.Rows(r).Cells("acc_id").Value <> akun8002000
                If Me.DgvTrnJurnaldetil_Debit.Rows(r).Cells("acc_id").Value <> akunBiayaLainLainKerugianSelisihKurs And Me.DgvTrnJurnaldetil_Debit.Rows(r).Cells("acc_id").Value <> akunBiayaLainlainKerugianSelisihKursPajak Then
                    Me.uiTrnJurnal_PV_Advance_RowCalcIDR(Me.DgvTrnJurnaldetil_Debit, Me.DgvTrnJurnaldetil_Debit.Rows(r).Cells("jurnaldetil_idr"), Me.DgvTrnJurnaldetil_Debit.Rows(r).Cells("jurnaldetil_foreign"), Me.DgvTrnJurnaldetil_Debit.Rows(r).Cells("jurnaldetil_foreignrate"))
                End If
            Next

            For r As Integer = 0 To Me.DgvTrnJurnaldetil_Credit.Rows.Count - 1
                'If Me.DgvTrnJurnaldetil_Credit.Rows(r).Cells("acc_id").Value <> akun8002000
                If Me.DgvTrnJurnaldetil_Credit.Rows(r).Cells("acc_id").Value <> akunKeuntunganLainlainSelisihKurs _
                    And Me.DgvTrnJurnaldetil_Credit.Rows(r).Cells("acc_id").Value <> akunKeuntunganLainlainSelisihKursPajak Then
                    Me.uiTrnJurnal_PV_Advance_RowCalcIDR(Me.DgvTrnJurnaldetil_Credit, Me.DgvTrnJurnaldetil_Credit.Rows(r).Cells("jurnaldetil_idr"), Me.DgvTrnJurnaldetil_Credit.Rows(r).Cells("jurnaldetil_foreign"), Me.DgvTrnJurnaldetil_Credit.Rows(r).Cells("jurnaldetil_foreignrate"))
                End If
            Next
            '=========================================================================================


            'cek balance
            Dim selisih, jumlah As Decimal
            Me.DgvTrnJurnaldetil_Debit.EndEdit()
            Me.DgvTrnJurnaldetil_Credit.EndEdit()
            Me.uiTrnJurnal_PV_Advance_RowCalculate(Me.DgvTrnJurnaldetil_Debit, Me.DgvTrnJurnaldetil_Credit, selisih, jumlah)
            If selisih <> 0 Then
                Me.obj_Selisih.Text = String.Format("{0:#,##0}", selisih)
                Me.obj_Jumlah.Text = String.Format("{0:#,##0}", jumlah)
                message = "Debit and credit isn't balance!!"
                Me.objFormError.SetError(Me.obj_Selisih, message)
                Throw New Exception(message)
                'Else
                '    Me.objFormError.SetError(Me.obj_Selisih, "")
            End If

            Me.DgvTrnJurnaldetil_Debit.EndEdit()
            Me.DgvTrnJurnaldetil_Credit.EndEdit()
            Me.uiTrnJurnal_PV_Advance_RowCalculateForeign(Me.DgvTrnJurnaldetil_Debit, Me.DgvTrnJurnaldetil_Credit, selisih, jumlah)
            If selisih <> 0 Then
                Me.obj_Selisih_Foreign.Text = String.Format("{0:#,##0.00}", selisih)
                Me.obj_Jumlah_Foreign.Text = String.Format("{0:#,##0.00}", jumlah)
                message = "Debit and credit foreign isn't balance!!"
                Me.objFormError.SetError(Me.obj_Selisih_Foreign, message)
                Throw New Exception(message)
                'Else
                '    Me.objFormError.SetError(Me.obj_Selisih_Foreign, "")
            End If

            'cek isi cell di detil Debet
            Dim i As Integer
            Dim cell_acc_id, cell_rekanan_id, cell_ref_id, cell_ref_line, cell_Foreign, cell_accid, cell_currencyid As DataGridViewCell
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

                message = "Amount different with advance request"
                cell_ref_id = Me.DgvTrnJurnaldetil_Debit.Rows(i).Cells("ref_id")
                cell_ref_line = Me.DgvTrnJurnaldetil_Debit.Rows(i).Cells("ref_line")
                cell_Foreign = Me.DgvTrnJurnaldetil_Debit.Rows(i).Cells("jurnaldetil_foreign")
                cell_accid = Me.DgvTrnJurnaldetil_Debit.Rows(i).Cells("acc_id")
                cell_currencyid = Me.DgvTrnJurnaldetil_Debit.Rows(i).Cells("currency_id")

                If cell_ref_id.Value IsNot DBNull.Value And cell_ref_line.Value IsNot DBNull.Value Then
                    If cell_ref_id.Value <> String.Empty And cell_ref_line.Value <> 0 And cell_accid.Value <> "1162431" Then '1162431 = Clearing - PPN In
                        Dim dbconn As New OleDb.OleDbConnection(Me.DSN)
                        Dim da As OleDb.OleDbDataAdapter
                        Dim command As OleDb.OleDbCommand
                        Dim tbl_temp As DataTable = New DataTable

                        Dim cookie As Byte() = Nothing

                        Try
                            dbconn.Open()
                            clsApplicationRole.SetAppRole(dbconn, cookie)
                            'command = New OleDb.OleDbCommand("act_TrnJurnaldetil_PV_Select_VQerr", dbconn)
                            command = New OleDb.OleDbCommand("act_TrnJurnaldetil_PV_Select_VQListOrderErrTravel", dbconn)
                            command.CommandType = CommandType.StoredProcedure
                            command.Parameters.Add("@advance_id", OleDb.OleDbType.VarWChar, 24).Value = cell_ref_id.Value
                            command.Parameters.Add("@advancedetil_line", OleDb.OleDbType.Integer, 4).Value = cell_ref_line.Value
                            da = New OleDb.OleDbDataAdapter(command)
                            da.Fill(tbl_temp)

                            Dim Total_valas As Decimal = 0
                            '====== FOR cek wakwaw =====
                            If cell_currencyid.Value = 1 Then
                                Total_valas = Math.Round(tbl_temp.Rows(0).Item("Total_valas"), 0, MidpointRounding.AwayFromZero)
                            Else
                                Total_valas = Math.Round(tbl_temp.Rows(0).Item("Total_valas"), 2, MidpointRounding.AwayFromZero)
                            End If


                            If Total_valas <> cell_Foreign.Value Then
                                cell_Foreign.ErrorText = message
                                row_error = True
                            Else
                                cell_Foreign.ErrorText = ""
                            End If
                        Catch ex As Exception
                            MsgBox(ex.Message)
                        Finally
                            clsApplicationRole.UnsetAppRole(dbconn, cookie)
                            dbconn.Close()
                        End Try
                    Else
                        cell_Foreign.ErrorText = ""
                    End If
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

                '====================================================================================================================================================
                ' ARI MDP2 20160426 Add checking Account COA dan Account Bank
                '====================================================================================================================================================
                Dim foundRows() As DataRow
                message = "Account COA dan Bank tidak sama !!"
                cell_acc_id1 = Me.DgvTrnJurnaldetil_Credit.Rows(j).Cells("acc_id")

                foundRows = tbl_MstBankacc.Select(String.Format("bankacc_id = '{0}'", Me.DgvTrnJurnaldetil_Credit.Rows(j).Cells("jurnalbilyet_bank").Value))
                If foundRows.Length > 0 Then
                    If foundRows(0).Item("bankacc_reportname").ToString.Trim <> "-- PILIH --" Then
                        Dim bankacc_account As String = foundRows(0).Item("bankacc_account")
                        If Me.DgvTrnJurnaldetil_Credit.Rows(j).Cells("acc_id").Value.ToString <> bankacc_account Then
                            cell_acc_id1.ErrorText = message
                            row_error1 = True
                        Else
                            cell_acc_id1.ErrorText = ""
                        End If
                    Else
                        cell_acc_id1.ErrorText = ""
                    End If
                Else
                    cell_acc_id1.ErrorText = ""
                End If
                '====================================================================================================================================================

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
                Throw New Exception("Error")
            End If
            ' Throw New Exception("Error")
        Catch ex As Exception
            MessageBox.Show(ex.Message, mUiName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return True
        End Try
        Return False
    End Function

#End Region

    Private Sub uiTrnJurnal_PV_Advance_FormAfterOpenRow(ByRef id As Object) Handles Me.FormAfterOpenRow
        Dim selisih_idr, jumlah_idr, selisih_foreign, jumlah_foreign As Decimal

        Me.uiTrnJurnal_PV_Advance_RowCalculate(Me.DgvTrnJurnaldetil_Debit, Me.DgvTrnJurnaldetil_Credit, selisih_idr, jumlah_idr)
        Me.uiTrnJurnal_PV_Advance_RowCalculateForeign(Me.DgvTrnJurnaldetil_Debit, Me.DgvTrnJurnaldetil_Credit, selisih_foreign, jumlah_foreign)

        DATADETIL_OPENED = True

        'set default value dari DgvJurnaldetil
        ' ''Me.uiTrnJurnal_SetDefaultValueOfJurnaldetil_Debit(Me.obj_Strukturunit_id, "strukturunit_id")
        Me.uiTrnJurnal_PV_Advance_SetDefaultValueOfJurnaldetil_Debit(Me.obj_Rekanan_id, "rekanan_id")
        Me.tbl_TrnJurnaldetil_Debit.Columns("rekanan_name").DefaultValue = Me.obj_Rekanan_id.Text
        Me.uiTrnJurnal_PV_Advance_SetDefaultValueOfJurnaldetil_Debit(Me.obj_Budget_id, "budget_id")
        Me.tbl_TrnJurnaldetil_Debit.Columns("budget_name").DefaultValue = Me.obj_Budget_id.Text
        Me.uiTrnJurnal_PV_Advance_SetDefaultValueOfJurnaldetil_Debit(Me.obj_Currency_id, "currency_id")
        Me.tbl_TrnJurnaldetil_Debit.Columns("jurnaldetil_descr").DefaultValue = Me.obj_Jurnal_descr.Text
        Me.tbl_TrnJurnaldetil_Debit.Columns("jurnaldetil_foreignrate").DefaultValue = Me.obj_Currency_rate.Text

        Me.uiTrnJurnal_PV_Advance_SetDefaultValueOfJurnaldetil_Credit(Me.obj_Currency_id, "currency_id")
        Me.uiTrnJurnal_PV_Advance_SetDefaultValueOfJurnaldetil_Credit(Me.obj_Rekanan_id, "rekanan_id")
        Me.tbl_TrnJurnaldetil_Credit.Columns("rekanan_name").DefaultValue = Me.obj_Rekanan_id.Text
        Me.uiTrnJurnal_PV_Advance_SetDefaultValueOfJurnaldetil_Credit(Me.obj_Budget_id, "budget_id")
        Me.tbl_TrnJurnaldetil_Credit.Columns("budget_name").DefaultValue = Me.obj_Budget_id.Text
        Me.tbl_TrnJurnaldetil_Credit.Columns("jurnaldetil_foreignrate").DefaultValue = Me.obj_Currency_rate.Text

        Me.DgvTrnJurnaldetil_Credit.Columns("jurnal_id").Visible = False
        Me.DgvTrnJurnaldetil_Debit.Columns("jurnal_id").Visible = False

        ' Cek apakah masih bisa edit data
        ' kriteria locking
        ' - jurnaltype di data tidak sama dengan jurnaltype form ini
        ' - jurnal sudah diposting
        ' - jurnal sudah di response oleh jurnal lain
        If Me.uiTrnJurnal_PV_Advance_DataIsLocked() Then
            Me.DATA_ISLOCKED = True
            Me.tbtnSave.Enabled = False
            Me.tbtnDel.Enabled = False
        Else
            Me.DATA_ISLOCKED = False
            Me.tbtnSave.Enabled = True
            Me.tbtnDel.Enabled = True
        End If

        Me.tbl_TrnJurnal_Temp.AcceptChanges()
        Me.tbl_TrnJurnaldetil_Debit.AcceptChanges()
        Me.tbl_TrnJurnaldetil_Credit.AcceptChanges()

        Me.obj_Selisih.Text = String.Format("{0:#,##0}", selisih_idr)
        Me.obj_Jumlah.Text = String.Format("{0:#,##0}", jumlah_idr)
        Me.obj_Selisih_Foreign.Text = String.Format("{0:#,##0.00}", selisih_foreign)
        Me.obj_Jumlah_Foreign.Text = String.Format("{0:#,##0.00}", jumlah_foreign)

        Dim clsdocument As New clsTrnDocument(DSN, Me._CHANNEL)
        Me.obj_document_id.Text = clsdocument.filltextbox(Me.obj_Jurnal_id.Text.Trim)
        Me.locking.TryLocking(id)

    End Sub

    Private Sub uiTrnJurnal_PV_Advance_FormAfterSave(ByRef id As Object, ByVal result As uiBase.FormSaveResult) Handles Me.FormAfterSave
        Dim selisih, jumlah As Decimal
        Me.uiTrnJurnal_PV_Advance_RowCalculate(Me.DgvTrnJurnaldetil_Debit, Me.DgvTrnJurnaldetil_Credit, selisih, jumlah)
        Me.obj_Selisih.Text = String.Format("{0:#,##0}", selisih)
        Me.obj_Jumlah.Text = String.Format("{0:#,##0}", jumlah)

        Me.uiTrnJurnal_PV_Advance_RowCalculateForeign(Me.DgvTrnJurnaldetil_Debit, Me.DgvTrnJurnaldetil_Credit, selisih, jumlah)
        Me.obj_Selisih_Foreign.Text = String.Format("{0:#,##0.00}", selisih)
        Me.obj_Jumlah_Foreign.Text = String.Format("{0:#,##0.00}", jumlah)

        If result = FormSaveResult.SaveSuccess Then
            Me.tbtnDel.Enabled = True
        End If
    End Sub

    Private Sub uiTrnJurnal_PV_Advance_FormBeforeNew() Handles Me.FormBeforeNew
        Me.obj_document_id.Text = ""
        Me.tbtnDel.Enabled = False
        locking.Clear()
    End Sub

    Private Sub uiTrnJurnal_PV_Advance_FormBeforeOpenRow(ByRef id As Object) Handles Me.FormBeforeOpenRow
        DATADETIL_OPENED = False
    End Sub

    Public Sub Form_Load(ByVal sender As Object)
        Dim objParameters As Collection = New Collection

        'TODO: - Extract Parameter
        '      - Assign parameter
        If Me.Browser IsNot Nothing Then
            objParameters = Me.GetParameterCollection(Me.Parameter)
            Me._CHANNEL = Me.GetValueFromParameter(objParameters, "CHANNEL") 'Me.GetValueFromParameter(objParameters, "CHANNEL")
            Me._CHANNEL_CANBE_CHANGED = False 'Me.GetBolValueFromParameter(objParameters, "CHANNELCHANGED")
            Me._CHANNEL_CANBE_BROWSED = False 'Me.GetBolValueFromParameter(objParameters, "CHANNELBROWSED")
            Me._SOURCE = Me.GetValueFromParameter(objParameters, "SOURCE")
            Me._USER_TYPE = Me.GetValueFromParameter(objParameters, "USERTYPE")
        End If

        'Me.DSN = clsUtil.GetDSN


        If (Me.Browser IsNot Nothing And MyBase.Name = _Name) Or (Me.Browser Is Nothing And Application.ProductName <> _ProductName) Then
            'Fill Combobox
            'dan fungsi2 startup lainnya....
            Me.locking = New clsLockingTransaction(Me._CHANNEL, Me.UserName, Me, Me.ftabMain)
            Me.DgvTrnJurnal.DataSource = Me.tbl_TrnJurnal
            Me.uiTrnJurnal_PV_Advance_isBackgroudWorker()
            Me.uiTrnJurnal_PV_Advance_LoadComboBox()
            Dim row_type As DataRow

            tbl_Payment_type = New DataTable
            tbl_Payment_type.Clear()
            tbl_Payment_type.Columns.Add(New DataColumn("valuetype", GetType(System.Decimal)))
            tbl_Payment_type.Columns.Add(New DataColumn("payment_type", GetType(System.String)))
            Try
                If Me.tbl_Payment_type.Columns("payment_type") IsNot Nothing Then
                    row_type = tbl_Payment_type.NewRow
                    row_type.Item("valuetype") = 0
                    row_type.Item("payment_type") = "Payment"
                    tbl_Payment_type.Rows.InsertAt(row_type, 0)

                    row_type = tbl_Payment_type.NewRow
                    row_type.Item("valuetype") = 1
                    row_type.Item("payment_type") = "Received"
                    tbl_Payment_type.Rows.InsertAt(row_type, 1)
                End If
            Catch ex As Exception
                MsgBox("error")
                MessageBox.Show(ex.Message)
            End Try

            Me.InitLayoutUI()

            Me.BindingStop()
            Me.BindingStart()

            Me.uiTrnJurnal_PV_Advance_NewData()

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
            Me.btnPost.Visible = False
            Me.btnUnPost.Visible = False
            Me.ToolStrip1.Items.Add(Me.btnPost)
            Me.ToolStrip1.Items.Add(Me.btnUnPost)

            '========= ADD PTS 20150528 ===========
            Me.btnSettingPrinterGiro.Name = "printersetting"
            Me.btnSettingPrinterGiro.Image = My.Resources.printer_settingsimage
            Me.btnSettingPrinterGiro.Visible = True
            Me.btnSettingPrinterGiro.ToolTipText = "Default Printer Setting Cek & Giro"
            Me.ToolStrip1.Items.Add(Me.btnSettingPrinterGiro)
            '======================================

            Me.obj_Currency_rate.Enabled = False
            Me.obj_Currency_id.Enabled = False
        End If
    End Sub

    Private Sub uiTrnJurnal_PV_Advance_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Me.IsDevelopment = True Then Me.Form_Load(sender)
    End Sub

    Private Sub ftabMain_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ftabMain.SelectedIndexChanged
        Select Case ftabMain.SelectedIndex
            Case 0
                Me.tbtnSave.Enabled = False
                Me.tbtnDel.Enabled = False
                Me.tbtnLoad.Enabled = True
                Me.tbtnQuery.Enabled = True
                Me.ftabMain.TabPages.Item(0).BackColor = Color.LightSteelBlue 'Lavender
                Me.ftabMain.TabPages.Item(1).BackColor = Color.White
                Me.btnPost.Visible = False
                Me.btnUnPost.Visible = False
            Case 1
                Me.tbtnSave.Enabled = True
                Me.tbtnDel.Enabled = True
                Me.tbtnLoad.Enabled = False
                Me.tbtnQuery.Enabled = False
                Me.ftabMain.TabPages.Item(0).BackColor = Color.White
                Me.ftabMain.TabPages.Item(1).BackColor = Color.LightSteelBlue 'Lavender

                Me.fTabDataDetil.SelectedIndex = 1
                If Me._USER_TYPE = "SPV" Then
                    Me.btnPost.Visible = True
                Else
                    Me.btnPost.Visible = False
                End If
                If Me.isNewButton = True Then
                    Me.uiTrnJurnal_PV_Advance_NewData()
                Else
                    If Me.DgvTrnJurnal.CurrentRow IsNot Nothing Then
                        Me.uiTrnJurnal_PV_Advance_OpenRow(Me.DgvTrnJurnal.CurrentRow.Index)
                    Else
                        Me.uiTrnJurnal_PV_Advance_NewData()
                    End If
                End If
                Me.fTabDataDetil.SelectedIndex = 0
        End Select
    End Sub

    Private Sub fTabDataDetil_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles fTabDataDetil.SelectedIndexChanged
        Dim i, activetab As Byte

        For i = 0 To (Me.fTabDataDetil.TabCount - 1)
            Me.fTabDataDetil.TabPages.Item(i).BackColor = Color.LightSteelBlue 'LavenderBlush
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
        Dim table_acc_bank As DataTable = New DataTable
        Try
            If colName = "jurnaldetil_foreign" Or colName = "jurnaldetil_foreignrate" Then
                If obj.Rows(e.RowIndex).Cells("currency_id").Value = 1 Then
                    Me.uiTrnJurnal_PV_Advance_RowCalculateForeignIDR(Me.DgvTrnJurnaldetil_Debit, Me.DgvTrnJurnaldetil_Credit, selisih, jumlah)
                    If colName = "jurnaldetil_foreign" Then
                        obj.Rows(e.RowIndex).Cells("jurnaldetil_foreign").Value = Math.Round(obj.Rows(e.RowIndex).Cells("jurnaldetil_foreign").Value, 0, MidpointRounding.AwayFromZero)
                    End If
                Else
                    Me.uiTrnJurnal_PV_Advance_RowCalculateForeign(Me.DgvTrnJurnaldetil_Debit, Me.DgvTrnJurnaldetil_Credit, selisih, jumlah)
                End If
                Me.obj_Selisih_Foreign.Text = String.Format("{0:#,##0.00}", selisih)
                Me.obj_Jumlah_Foreign.Text = String.Format("{0:#,##0.00}", jumlah)

                '===================== REMARK MANG ARI 20160302 ===========================
                'If obj.Rows(e.RowIndex).Cells("acc_id").Value <> akun8002000 And _
                ' (obj.Rows(e.RowIndex).Cells("acc_id").Value <> akun8009990 And obj.Rows(e.RowIndex).Cells("jurnaldetil_foreign").Value <> 0 And obj.Rows(e.RowIndex).Cells("jurnaldetil_foreignrate").Value <> 0) Then
                '    Me.uiTrnJurnal_PV_Advance_RowCalcIDR(obj, obj.Rows(e.RowIndex).Cells("jurnaldetil_idr"), obj.Rows(e.RowIndex).Cells("jurnaldetil_foreign"), obj.Rows(e.RowIndex).Cells("jurnaldetil_foreignrate"))
                'End If
                '===================== MODIFIED 20160302 ==================================
                If (obj.Rows(e.RowIndex).Cells("acc_id").Value <> akunBiayaLainLainKerugianSelisihKurs And obj.Rows(e.RowIndex).Cells("acc_id").Value <> akunBiayaLainlainKerugianSelisihKursPajak) _
              And obj.Rows(e.RowIndex).Cells("jurnaldetil_foreign").Value <> 0 And obj.Rows(e.RowIndex).Cells("jurnaldetil_foreignrate").Value <> 0 Then
                    Me.uiTrnJurnal_PV_Advance_RowCalcIDR(obj, obj.Rows(e.RowIndex).Cells("jurnaldetil_idr"), obj.Rows(e.RowIndex).Cells("jurnaldetil_foreign"), obj.Rows(e.RowIndex).Cells("jurnaldetil_foreignrate"))
                End If
                '==============================================================================
            End If

            If obj.Columns(e.ColumnIndex).Name = "jurnaldetil_idr" Then
                Me.uiTrnJurnal_PV_Advance_RowCalculate(Me.DgvTrnJurnaldetil_Debit, Me.DgvTrnJurnaldetil_Credit, selisih, jumlah)
                Me.obj_Selisih.Text = String.Format("{0:#,##0}", selisih)
                Me.obj_Jumlah.Text = String.Format("{0:#,##0}", jumlah)
            End If

            If obj.Columns(e.ColumnIndex).Name = "jurnalbilyet_bank" Then
                Try
                    Me.DataFill(table_acc_bank, "ms_MstBankacc_Select", String.Format(" bankacc_id = {0} ", Me.DgvTrnJurnaldetil_Credit.Rows(Me.DgvTrnJurnaldetil_Credit.CurrentRow.Index).Cells("jurnalbilyet_bank").Value))
                    If table_acc_bank.Rows.Count > 0 Then
                        Me.DgvTrnJurnaldetil_Credit.Rows(Me.DgvTrnJurnaldetil_Credit.CurrentRow.Index).Cells("acc_id").Value = table_acc_bank.Rows(0).Item("bankacc_account")
                    End If
                Catch ex As Exception

                End Try
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
       
        'Dim obj As DataGridView = sender
        'Dim selisih, jumlah As Decimal
        'Dim colName As String = obj.Columns(e.ColumnIndex).Name


        'If colName = "jurnaldetil_foreign" Or colName = "jurnaldetil_foreignrate" Then
        '    If obj.Rows(e.RowIndex).Cells("currency_id").Value = 1 Then
        '        Me.uiTrnJurnal_PV_Advance_RowCalculateForeignIDR(Me.DgvTrnJurnaldetil_Debit, Me.DgvTrnJurnaldetil_Credit, selisih, jumlah)
        '        If colName = "jurnaldetil_foreign" Then
        '            obj.Rows(e.RowIndex).Cells("jurnaldetil_foreign").Value = Math.Round(obj.Rows(e.RowIndex).Cells("jurnaldetil_foreign").Value, 0, MidpointRounding.AwayFromZero)
        '        End If
        '    Else
        '        Me.uiTrnJurnal_PV_Advance_RowCalculateForeign(Me.DgvTrnJurnaldetil_Debit, Me.DgvTrnJurnaldetil_Credit, selisih, jumlah)
        '    End If
        '    Me.obj_Selisih_Foreign.Text = String.Format("{0:#,##0.00}", selisih)
        '    Me.obj_Jumlah_Foreign.Text = String.Format("{0:#,##0.00}", jumlah)

        '    If obj.Rows(e.RowIndex).Cells("acc_id").Value <> 8500015 Then
        '        Me.uiTrnJurnal_PV_Advance_RowCalcIDR(obj, obj.Rows(e.RowIndex).Cells("jurnaldetil_idr"), obj.Rows(e.RowIndex).Cells("jurnaldetil_foreign"), obj.Rows(e.RowIndex).Cells("jurnaldetil_foreignrate"))
        '    End If
        'End If

        'If obj.Columns(e.ColumnIndex).Name = "jurnaldetil_idr" Then
        '    Me.uiTrnJurnal_PV_Advance_RowCalculate(Me.DgvTrnJurnaldetil_Debit, Me.DgvTrnJurnaldetil_Credit, selisih, jumlah)
        '    Me.obj_Selisih.Text = String.Format("{0:#,##0}", selisih)
        '    Me.obj_Jumlah.Text = String.Format("{0:#,##0}", jumlah)
        'End If

    End Sub
    Private Sub DgvTrnJurnaldetil_Debit_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvTrnJurnaldetil_Debit.CellValueChanged
        Dim obj As DataGridView = sender
        Dim selisih, jumlah As Decimal
        Dim colName As String = obj.Columns(e.ColumnIndex).Name

        If colName = "jurnaldetil_foreign" Or colName = "jurnaldetil_foreignrate" Then
            If obj.Rows(e.RowIndex).Cells("currency_id").Value = 1 Then
                Me.uiTrnJurnal_PV_Advance_RowCalculateForeignIDR(Me.DgvTrnJurnaldetil_Debit, Me.DgvTrnJurnaldetil_Credit, selisih, jumlah)
            Else
                Me.uiTrnJurnal_PV_Advance_RowCalculateForeign(Me.DgvTrnJurnaldetil_Debit, Me.DgvTrnJurnaldetil_Credit, selisih, jumlah)
            End If
            Me.obj_Selisih_Foreign.Text = String.Format("{0:#,##0.00}", selisih)
            Me.obj_Jumlah_Foreign.Text = String.Format("{0:#,##0.00}", jumlah)
            If obj.Rows(e.RowIndex).Cells("acc_id").Value <> 8500015 Then
                Dim foreign As Object = obj.Rows(e.RowIndex).Cells("jurnaldetil_foreign").Value
                Dim rate As Object = obj.Rows(e.RowIndex).Cells("jurnaldetil_foreignrate").Value

                If foreign > 0 And rate > 0 Then
                    Me.uiTrnJurnal_PV_Advance_RowCalcIDR(obj, obj.Rows(e.RowIndex).Cells("jurnaldetil_idr"), obj.Rows(e.RowIndex).Cells("jurnaldetil_foreign"), obj.Rows(e.RowIndex).Cells("jurnaldetil_foreignrate"))
                End If
            End If
        End If

        If obj.Columns(e.ColumnIndex).Name = "jurnaldetil_idr" Then
            Me.uiTrnJurnal_PV_Advance_RowCalculate(Me.DgvTrnJurnaldetil_Debit, Me.DgvTrnJurnaldetil_Credit, selisih, jumlah)
            Me.obj_Selisih.Text = String.Format("{0:#,##0}", selisih)
            Me.obj_Jumlah.Text = String.Format("{0:#,##0}", jumlah)
        End If
        ''
        ''
        '================ ADD PTS 20140915 ====edit manual===buat selisih kurs===bisa rubah amount idr manual dengan rate=0 dan amount foreign nya= 0 juga =========
        If obj.Columns(e.ColumnIndex).Name = "acc_id" Then
            Dim tbl_checkacc_id As DataTable = New DataTable
            tbl_checkacc_id.Clear()
            If Me.tbl_TrnJurnal_Temp.Rows.Count > 0 Then
                If Me.tbl_TrnJurnal_Temp.Rows(0).Item("jurnal_isposted") = 0 Then
                    Me.DataFill(tbl_checkacc_id, "act_selectAccid_PerubahanKurs", String.Format(" acc_id = '{0}'", Me.DgvTrnJurnaldetil_Debit.Rows(e.RowIndex).Cells("acc_id").Value))
                    If tbl_checkacc_id.Rows.Count <> 0 And Me.DgvTrnJurnaldetil_Debit.Rows(e.RowIndex).Cells("ref_id").Value = "" Then
                       

                        Me.DgvTrnJurnaldetil_Debit.Rows(e.RowIndex).Cells("jurnaldetil_foreign").ReadOnly = True
                        Me.DgvTrnJurnaldetil_Debit.Rows(e.RowIndex).Cells("jurnaldetil_foreignrate").ReadOnly = True

                        Me.DgvTrnJurnaldetil_Debit.Rows(e.RowIndex).Cells("jurnaldetil_foreign").Style.BackColor = Color.LightYellow
                        Me.DgvTrnJurnaldetil_Debit.Rows(e.RowIndex).Cells("jurnaldetil_foreignrate").Style.BackColor = Color.LightYellow

                        Me.DgvTrnJurnaldetil_Debit.Rows(e.RowIndex).Cells("jurnaldetil_idr").ReadOnly = False
                        Me.DgvTrnJurnaldetil_Debit.Rows(e.RowIndex).Cells("jurnaldetil_idr").Style.BackColor = Color.White
                        Me.DgvTrnJurnaldetil_Debit.Rows(e.RowIndex).Cells("jurnaldetil_foreign").Value = 0
                        Me.DgvTrnJurnaldetil_Debit.Rows(e.RowIndex).Cells("jurnaldetil_foreignrate").Value = 0
                    ElseIf tbl_checkacc_id.Rows.Count <> 0 And Me.DgvTrnJurnaldetil_Debit.Rows(e.RowIndex).Cells("ref_id").Value <> "" Then
                        Me.DgvTrnJurnaldetil_Debit.Rows(e.RowIndex).Cells("jurnaldetil_foreign").ReadOnly = True
                        Me.DgvTrnJurnaldetil_Debit.Rows(e.RowIndex).Cells("jurnaldetil_foreignrate").ReadOnly = False

                        Me.DgvTrnJurnaldetil_Debit.Rows(e.RowIndex).Cells("jurnaldetil_foreign").Style.BackColor = Color.LightYellow
                        Me.DgvTrnJurnaldetil_Debit.Rows(e.RowIndex).Cells("jurnaldetil_foreignrate").Style.BackColor = Color.White


                        Me.DgvTrnJurnaldetil_Debit.Rows(e.RowIndex).Cells("jurnaldetil_idr").ReadOnly = True
                        Me.DgvTrnJurnaldetil_Debit.Rows(e.RowIndex).Cells("jurnaldetil_idr").Style.BackColor = Color.LightYellow

                    Else
                        Me.DgvTrnJurnaldetil_Debit.Rows(e.RowIndex).Cells("jurnaldetil_foreign").ReadOnly = False
                        Me.DgvTrnJurnaldetil_Debit.Rows(e.RowIndex).Cells("jurnaldetil_foreignrate").ReadOnly = False

                        Me.DgvTrnJurnaldetil_Debit.Rows(e.RowIndex).Cells("jurnaldetil_foreign").Style.BackColor = Color.White
                        Me.DgvTrnJurnaldetil_Debit.Rows(e.RowIndex).Cells("jurnaldetil_foreignrate").Style.BackColor = Color.White


                        Me.DgvTrnJurnaldetil_Debit.Rows(e.RowIndex).Cells("jurnaldetil_idr").ReadOnly = True
                        Me.DgvTrnJurnaldetil_Debit.Rows(e.RowIndex).Cells("jurnaldetil_idr").Style.BackColor = Color.LightYellow
                    End If

                End If
            Else
                Me.DataFill(tbl_checkacc_id, "act_selectAccid_PerubahanKurs", String.Format(" acc_id = '{0}'", Me.DgvTrnJurnaldetil_Debit.Rows(e.RowIndex).Cells("acc_id").Value))
                If tbl_checkacc_id.Rows.Count <> 0 And Me.DgvTrnJurnaldetil_Debit.Rows(e.RowIndex).Cells("ref_id").Value = "" Then
                    Me.DgvTrnJurnaldetil_Debit.Rows(e.RowIndex).Cells("jurnaldetil_foreign").ReadOnly = True
                    Me.DgvTrnJurnaldetil_Debit.Rows(e.RowIndex).Cells("jurnaldetil_foreignrate").ReadOnly = True

                    Me.DgvTrnJurnaldetil_Debit.Rows(e.RowIndex).Cells("jurnaldetil_foreign").Style.BackColor = Color.LightYellow
                    Me.DgvTrnJurnaldetil_Debit.Rows(e.RowIndex).Cells("jurnaldetil_foreignrate").Style.BackColor = Color.LightYellow

                    Me.DgvTrnJurnaldetil_Debit.Rows(e.RowIndex).Cells("jurnaldetil_idr").ReadOnly = False
                    Me.DgvTrnJurnaldetil_Debit.Rows(e.RowIndex).Cells("jurnaldetil_idr").Style.BackColor = Color.White
                    Me.DgvTrnJurnaldetil_Debit.Rows(e.RowIndex).Cells("jurnaldetil_foreign").Value = 0
                    Me.DgvTrnJurnaldetil_Debit.Rows(e.RowIndex).Cells("jurnaldetil_foreignrate").Value = 0
                ElseIf tbl_checkacc_id.Rows.Count <> 0 And Me.DgvTrnJurnaldetil_Debit.Rows(e.RowIndex).Cells("ref_id").Value <> "" Then
                    Me.DgvTrnJurnaldetil_Debit.Rows(e.RowIndex).Cells("jurnaldetil_foreign").ReadOnly = True
                    Me.DgvTrnJurnaldetil_Debit.Rows(e.RowIndex).Cells("jurnaldetil_foreignrate").ReadOnly = False

                    Me.DgvTrnJurnaldetil_Debit.Rows(e.RowIndex).Cells("jurnaldetil_foreign").Style.BackColor = Color.LightYellow
                    Me.DgvTrnJurnaldetil_Debit.Rows(e.RowIndex).Cells("jurnaldetil_foreignrate").Style.BackColor = Color.White

                    Me.DgvTrnJurnaldetil_Debit.Rows(e.RowIndex).Cells("jurnaldetil_idr").ReadOnly = True
                    Me.DgvTrnJurnaldetil_Debit.Rows(e.RowIndex).Cells("jurnaldetil_idr").Style.BackColor = Color.LightYellow

                Else
                    Me.DgvTrnJurnaldetil_Debit.Rows(e.RowIndex).Cells("jurnaldetil_foreign").ReadOnly = False
                    Me.DgvTrnJurnaldetil_Debit.Rows(e.RowIndex).Cells("jurnaldetil_foreignrate").ReadOnly = False

                    Me.DgvTrnJurnaldetil_Debit.Rows(e.RowIndex).Cells("jurnaldetil_foreign").Style.BackColor = Color.White
                    Me.DgvTrnJurnaldetil_Debit.Rows(e.RowIndex).Cells("jurnaldetil_foreignrate").Style.BackColor = Color.White

                    Me.DgvTrnJurnaldetil_Debit.Rows(e.RowIndex).Cells("jurnaldetil_idr").ReadOnly = True
                    Me.DgvTrnJurnaldetil_Debit.Rows(e.RowIndex).Cells("jurnaldetil_idr").Style.BackColor = Color.LightYellow
                End If
                    End If

        End If
        '===========================================================================================================================================================

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
    Private Sub DgvTrnJurnaldetil_Debet_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DgvTrnJurnaldetil_Debit.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim click As DataGridView.HitTestInfo = Me.DgvTrnJurnaldetil_Debit.HitTest(e.X, e.Y)
            If click.Type = Windows.Forms.DataGrid.HitTestType.Cell Then
                Me.DgvTrnJurnaldetil_Debit.CurrentCell = Me.DgvTrnJurnaldetil_Debit.Rows(click.RowIndex).Cells(click.ColumnIndex)
            End If
        End If

    End Sub
    Private Sub DgvTrnJurnaldetil_Debit_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles DgvTrnJurnaldetil_Debit.RowsRemoved
        Dim obj As DataGridView = sender
        Dim selisih, jumlah As Decimal
        If Me.ftabMain.SelectedIndex = 1 And Me.fTabDataDetil.SelectedIndex = 0 And DATADETIL_OPENED = True Then
            Me.uiTrnJurnal_PV_Advance_RowCalculate(Me.DgvTrnJurnaldetil_Debit, Me.DgvTrnJurnaldetil_Credit, selisih, jumlah)
            Me.obj_Selisih.Text = String.Format("{0:#,##0}", selisih)
            Me.obj_Jumlah.Text = String.Format("{0:#,##0}", jumlah)

            If Me.obj_Currency_id.SelectedValue = 1 Then
                Me.uiTrnJurnal_PV_Advance_RowCalculateForeignIDR(Me.DgvTrnJurnaldetil_Debit, Me.DgvTrnJurnaldetil_Credit, selisih, jumlah)
            Else
                Me.uiTrnJurnal_PV_Advance_RowCalculateForeign(Me.DgvTrnJurnaldetil_Debit, Me.DgvTrnJurnaldetil_Credit, selisih, jumlah)
            End If
            Me.obj_Selisih_Foreign.Text = String.Format("{0:#,##0.00}", selisih)
            Me.obj_Jumlah_Foreign.Text = String.Format("{0:#,##0.00}", jumlah)

        End If
    End Sub
    Private Sub DgvTrnJurnaldetil_Debit_UserDeletedRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles DgvTrnJurnaldetil_Debit.UserDeletedRow
        Dim obj As DataGridView = sender
        Dim selisih, jumlah As Decimal
        Me.uiTrnJurnal_PV_Advance_RowCalculate(Me.DgvTrnJurnaldetil_Debit, Me.DgvTrnJurnaldetil_Credit, selisih, jumlah)
        Me.obj_Selisih.Text = String.Format("{0:#,##0}", selisih)
        Me.obj_Jumlah.Text = String.Format("{0:#,##0}", jumlah)

        If Me.obj_Currency_id.SelectedValue = 1 Then
            Me.uiTrnJurnal_PV_Advance_RowCalculateForeignIDR(Me.DgvTrnJurnaldetil_Debit, Me.DgvTrnJurnaldetil_Credit, selisih, jumlah)
        Else
            Me.uiTrnJurnal_PV_Advance_RowCalculateForeign(Me.DgvTrnJurnaldetil_Debit, Me.DgvTrnJurnaldetil_Credit, selisih, jumlah)
        End If
        Me.obj_Selisih_Foreign.Text = String.Format("{0:#,##0.00}", selisih)
        Me.obj_Jumlah_Foreign.Text = String.Format("{0:#,##0.00}", jumlah)


    End Sub
    Private Sub DgvTrnJurnaldetil_Debit_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles DgvTrnJurnaldetil_Debit.UserDeletingRow
        Dim obj As DataGridView = sender
        Dim selisih, jumlah As Decimal
        Dim x As Integer
        If e.Row.Index < 0 Then Exit Sub

        '=======================================================================================
        For x = 0 To Me.DgvTrnJurnaldetil_Debit.SelectedRows.Count - 1
            Dim refId As String = Me.DgvTrnJurnaldetil_Debit.SelectedRows.Item(x).Cells("ref_id").Value
            Dim refLine As Integer = Me.DgvTrnJurnaldetil_Debit.SelectedRows.Item(x).Cells("ref_line").Value
            Dim ref As String = String.Empty
            Dim line As Integer = 0

            Dim jml As Integer = 0
            For i As Integer = 0 To Me.DgvTrnJurnaldetil_Debit.Rows.Count - 1
                If Me.DgvTrnJurnaldetil_Debit.Item("ref_id", i).Value = refId And _
                    Me.DgvTrnJurnaldetil_Debit.Item("ref_line", i).Value = refLine Then
                    jml = jml + 1
                End If
            Next

            If jml = 1 Then
ulang:
                For i As Integer = 0 To Me.DgvTrnJurnalreference.Rows.Count - 1
                    ref = Me.DgvTrnJurnalreference.Item("ref", i).Value
                    line = Me.DgvTrnJurnalreference.Item("line", i).Value
                    If refId = ref And refLine = line Then
                        DgvTrnJurnalreference.Rows.RemoveAt(i)
                        GoTo ulang
                    End If
                Next
            End If
        Next
        '====================================================================================

        Me.uiTrnJurnal_PV_Advance_RowCalculate(Me.DgvTrnJurnaldetil_Debit, Me.DgvTrnJurnaldetil_Credit, selisih, jumlah)
        Me.obj_Selisih.Text = String.Format("{0:#,##0}", selisih)
        Me.obj_Jumlah.Text = String.Format("{0:#,##0}", jumlah)

        If Me.obj_Currency_id.SelectedValue = 1 Then
            Me.uiTrnJurnal_PV_Advance_RowCalculateForeignIDR(Me.DgvTrnJurnaldetil_Debit, Me.DgvTrnJurnaldetil_Credit, selisih, jumlah)
        Else
            Me.uiTrnJurnal_PV_Advance_RowCalculateForeign(Me.DgvTrnJurnaldetil_Debit, Me.DgvTrnJurnaldetil_Credit, selisih, jumlah)
        End If
        Me.obj_Selisih_Foreign.Text = String.Format("{0:#,##0.00}", selisih)
        Me.obj_Jumlah_Foreign.Text = String.Format("{0:#,##0.00}", jumlah)

    End Sub
#End Region

#Region "Event On Dgv Credit"
    Private Sub DgvTrnJurnaldetil_Credit_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvTrnJurnaldetil_Credit.CellClick
        If e.RowIndex >= 0 Then
            Select Case e.ColumnIndex

                '=============== ADD PTS 20150528 =====================
                Case Me.DgvTrnJurnaldetil_Credit.Columns("print_giro_cek").Index
                    Dim paymenttype_id As Integer
                    paymenttype_id = Me.DgvTrnJurnaldetil_Credit.Rows(e.RowIndex).Cells("paymenttype_id").Value
                    If paymenttype_id <> 0 Then
                        Dim Amount_IDR As Decimal
                        Dim Rekanan_name, Receive_By As String
                        Dim Tgl_Bilyet, Tgl_Efektif As String
                        Dim jurnalbilyet_bank As Integer
                        Dim bank As Integer
                        Dim AccNumber As String = String.Empty
                        Dim BankName As String = String.Empty

                        Amount_IDR = Me.DgvTrnJurnaldetil_Credit.Rows(e.RowIndex).Cells("jurnaldetil_idr").Value
                        'Rekanan_name = Me.DgvTrnJurnaldetil_Credit.Rows(e.RowIndex).Cells("rekanan_name").Value
                        Receive_By = Me.DgvTrnJurnaldetil_Credit.Rows(e.RowIndex).Cells("jurnalbilyet_receiveperson").Value
                        Tgl_Bilyet = Me.DgvTrnJurnaldetil_Credit.Rows(e.RowIndex).Cells("jurnalbilyet_date").Value
                        Tgl_Efektif = Me.DgvTrnJurnaldetil_Credit.Rows(e.RowIndex).Cells("jurnalbilyet_dateeffective").Value
                        jurnalbilyet_bank = Me.DgvTrnJurnaldetil_Credit.Rows(e.RowIndex).Cells("jurnalbilyet_bank").Value

                        Dim tbl_bank As DataTable = New DataTable
                        tbl_bank.Clear()
                        DataFill(tbl_bank, "ms_MstBankaccCombo_Select", " bankacc_id = '" & jurnalbilyet_bank & "'")
                        bank = tbl_bank.Rows(0).Item("bankacc_bank")

                        '===ADD============================================================================================
                        Dim tbl_banktransfer As DataTable = New DataTable
                        tbl_banktransfer.Clear()
                        'Me.DataFill(tbl_banktransfer, "cp_TrnBanktransfer_Select_print", _
                        '            String.Format("a.jurnal_id = '{0}' AND a.jurnaldetil_line = '{1}' and a.banktransfer_isdisabled = 0 and paymenttype_id = '{2}'", _
                        '                           Me.DgvTrnJurnaldetil_Credit.Rows(e.RowIndex).Cells("jurnal_id").Value, _
                        '                           Me.DgvTrnJurnaldetil_Credit.Rows(e.RowIndex).Cells("jurnaldetil_line").Value, _
                        '                           paymenttype_id))

                        Me.DataFill(tbl_banktransfer, "cp_TrnBanktransfer_Select_print1", _
                                    String.Format("a.jurnal_id = '{0}' AND a.jurnaldetil_line = '{1}' and a.banktransfer_isdisabled = 0 and paymenttype_id = '{2}'", _
                                                   Me.DgvTrnJurnaldetil_Credit.Rows(e.RowIndex).Cells("jurnal_id").Value, _
                                                   Me.DgvTrnJurnaldetil_Credit.Rows(e.RowIndex).Cells("jurnaldetil_line").Value, _
                                                   paymenttype_id))

                        If tbl_banktransfer.Rows.Count >= 1 Then
                            Dim line As Integer = clsUtil.IsDbNull(Me.DgvTrnJurnaldetil_Credit.Rows(Me.DgvTrnJurnaldetil_Credit.CurrentRow.Index).Cells("jurnaldetil_line").Value, 0)
                            Dim acc_id As Decimal = clsUtil.IsDbNull(Me.DgvTrnJurnaldetil_Credit.Rows(Me.DgvTrnJurnaldetil_Credit.CurrentRow.Index).Cells("acc_id").Value, 0)
                            Dim currency_id As Decimal = clsUtil.IsDbNull(Me.DgvTrnJurnaldetil_Credit.Rows(Me.DgvTrnJurnaldetil_Credit.CurrentRow.Index).Cells("currency_id").Value, 0)
                            Dim rate As Decimal = clsUtil.IsDbNull(Me.DgvTrnJurnaldetil_Credit.Rows(Me.DgvTrnJurnaldetil_Credit.CurrentRow.Index).Cells("jurnaldetil_foreignrate").Value, 0)
                            Dim amount As Decimal = clsUtil.IsDbNull(Me.DgvTrnJurnaldetil_Credit.Rows(Me.DgvTrnJurnaldetil_Credit.CurrentRow.Index).Cells("jurnaldetil_foreign").Value, 0)
                            Dim amountIDR As Decimal = clsUtil.IsDbNull(Me.DgvTrnJurnaldetil_Credit.Rows(Me.DgvTrnJurnaldetil_Credit.CurrentRow.Index).Cells("jurnaldetil_idr").Value, 0)
                            Dim paymenttype As Integer = clsUtil.IsDbNull(Me.DgvTrnJurnaldetil_Credit.Rows(Me.DgvTrnJurnaldetil_Credit.CurrentRow.Index).Cells("paymenttype_id").Value, 0)
                            Dim bank1 As String = clsUtil.IsDbNull(Me.DgvTrnJurnaldetil_Credit.Rows(Me.DgvTrnJurnaldetil_Credit.CurrentRow.Index).Cells("jurnalbilyet_bank").Value, 0)

                            Dim dlgSelectRekeningPrint As dlgSelectRekeningPrint _
                                = New dlgSelectRekeningPrint(Me.DSN, tbl_banktransfer, line, acc_id, _
                                                             currency_id, rate, amount, amountIDR, paymenttype, bank1, Tgl_Bilyet)

                            'dlgSelectRekeningPrint.ShowDialog()
                            'If dlgSelectRekeningPrint.DialogResult = DialogResult.OK Then
                            '    With dlgSelectRekeningPrint
                            '        Rekanan_name = .dgvRekening.Rows(.dgvRekening.CurrentRow.Index).Cells("banktransfer_message").Value.ToString
                            '    End With
                            'Else
                            '    Exit Sub
                            'End If
                            dlgSelectRekeningPrint.ShowDialog()
                            If dlgSelectRekeningPrint.DialogResult = DialogResult.OK Then
                                With dlgSelectRekeningPrint
                                    Tgl_Bilyet = IIf(.chkTglBilyet.CheckState = CheckState.Checked, .dtpTglBilyet.Value, "")
                                    Rekanan_name = IIf(.chkRekananName.CheckState = CheckState.Checked, .txtRekananName.Text, "")
                                    AccNumber = IIf(.chkAccNumber.CheckState = CheckState.Checked, .txtAccNumber.Text, "")
                                    BankName = IIf(.chkBankName.CheckState = CheckState.Checked, .txtBankName.Text, "")
                                    'Tgl_Efektif = IIf(.chkTglPrint.CheckState = CheckState.Checked, .dtpTglPrint.Value, "")
                                    Tgl_Efektif = IIf(.chkKotaPrint.CheckState = CheckState.Checked, .obj_KotaPrint.Text + ", ", "") + IIf(.chkTglPrint.CheckState = CheckState.Checked, .dtpTglPrint.Value, "")
                                    If .chkAmountIDR.CheckState = CheckState.Unchecked Then
                                        Amount_IDR = 0
                                    End If
                                End With
                            Else
                                Exit Sub
                            End If
                        Else
                            Rekanan_name = " "
                            MsgBox("No data for print !")
                            Exit Sub
                        End If
                        '===================================================================================================

                        Dim printgirocek As clsPrintGiroAndCek = New clsPrintGiroAndCek(paymenttype_id, _
                            bank, Rekanan_name, Receive_By, Tgl_Bilyet, Tgl_Efektif, Amount_IDR, AccNumber, BankName)
                    Else
                        MsgBox("cant print, check your payment type", MsgBoxStyle.Information, "Information")
                    End If
                    '=========================================================

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

                Case Me.DgvTrnJurnaldetil_Credit.Columns("select_rekanan").Index
                    'Dim dlg As dlgSearch = New dlgSearch()'
                    'Dim retData As Collection
                    'Dim retObj As Object
                    'Dim rekanan_id As Decimal
                    'Dim rekanan_name As String

                    'retObj = dlg.OpenDialog(Me, Me.tbl_MstRekananGrid, "rekanan")
                    'If retObj IsNot Nothing Then
                    '    retData = CType(retObj, Collection)
                    '    rekanan_id = CType(retData.Item("retId"), Decimal)
                    '    rekanan_name = CType(retData.Item("retName"), String)
                    '    Me.DgvTrnJurnaldetil_Credit.Rows(e.RowIndex).Cells("rekanan_id").Value = rekanan_id
                    '    Me.DgvTrnJurnaldetil_Credit.Rows(e.RowIndex).Cells("rekanan_name").Value = rekanan_name
                    'End If
                    If Me.DgvTrnJurnaldetil_Credit.Rows(e.RowIndex).Cells("ref_id").Value.ToString = String.Empty Then

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
                    Else
                        MsgBox("Tidak Bisa Mengganti Rekanan Secara Manual" & vbCrLf & "Karena Sudah menarik rekanan Dari Ref ID " & Me.DgvTrnJurnaldetil_Credit.Rows(e.RowIndex).Cells("ref_id").Value.ToString, MsgBoxStyle.Information, "Can't Change Fill Rekanan")
                    End If

                Case Me.DgvTrnJurnaldetil_Credit.Columns("select_received").Index

                    Dim dlg As dlgTrnJurnal_PV_List_TransferRekening = New dlgTrnJurnal_PV_List_TransferRekening(Me.DSN, _
                    Me._CHANNEL, Me.DgvTrnJurnal.Rows.Count, Me.obj_Jurnal_isposted.Checked, Me.tbl_TrnBankTransfer.Copy, _
                    Me.DgvTrnJurnaldetil_Credit.Rows(e.RowIndex).Cells("currency_id").Value, _
                    Me.DgvTrnJurnaldetil_Credit.Rows(e.RowIndex).Cells("jurnaldetil_foreign").Value, _
                    Me.DgvTrnJurnaldetil_Credit.Rows(e.RowIndex).Cells("jurnaldetil_foreignrate").Value, _
                    Me.DgvTrnJurnaldetil_Credit.Rows(e.RowIndex).Cells("jurnaldetil_idr").Value, _
                    Me.DgvTrnJurnaldetil_Credit.Rows(e.RowIndex).Cells("paymenttype_id").Value, _
                    Me.tbl_MstSlipFormat.Copy, Me.tbl_MstCurrency.Copy, Me.tbl_MstPaymentTypeGrid.Copy, _
                    Me.tbl_MstPurposeFund.Copy, Me.tbl_MstShow.Copy, _
                    Me.DgvTrnJurnaldetil_Credit.Rows(e.RowIndex).Cells("jurnal_id").Value, _
                    Me.DgvTrnJurnaldetil_Credit.Rows(e.RowIndex).Cells("jurnaldetil_line").Value, "RekArtisOff", _
                    tbl_TrnContract, Me._CHANNEL, Me.UserName, Me.obj_Rekanan_id.SelectedValue)

                    Dim retObj As Object
                    Dim retData As Collection
                    Dim tblTransfer As DataTable = New DataTable

                    retObj = dlg.OpenDialog(Me)
                    If retObj IsNot Nothing Then
                        retData = CType(retObj, Collection)
                        tblTransfer = CType(retData.Item("tblTransfer"), DataTable)

                        Me.tbl_TrnBankTransfer = tblTransfer.Copy
                        Me.dgvTrnBankTransfer.DataSource = Me.tbl_TrnBankTransfer
                    End If

            End Select
        End If
    End Sub

    Private Sub DgvTrnJurnaldetil_Credit_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DgvTrnJurnaldetil_Credit.CellFormatting
        If Me.tbl_TrnJurnal_Temp.Rows.Count > 0 Then
            If Me.tbl_TrnJurnal_Temp.Rows(0).Item("jurnal_isposted") = 0 Then
                If clsUtil.IsDbNull(DgvTrnJurnaldetil_Credit.Rows(e.RowIndex).Cells("ref_id").Value, "") <> "" Then
                    ' Me.DgvTrnJurnaldetil_Credit.Rows(e.RowIndex).Cells("jurnaldetil_idr").ReadOnly = True
                    Me.DgvTrnJurnaldetil_Credit.Rows(e.RowIndex).Cells("jurnaldetil_foreign").ReadOnly = True
                    ' Me.DgvTrnJurnaldetil_Credit.Rows(e.RowIndex).Cells("jurnaldetil_idr").Style.BackColor = Color.LightYellow
                    Me.DgvTrnJurnaldetil_Credit.Rows(e.RowIndex).Cells("jurnaldetil_foreign").Style.BackColor = Color.LightYellow
                Else
                    'Me.DgvTrnJurnaldetil_Credit.Rows(e.RowIndex).Cells("jurnaldetil_idr").ReadOnly = False
                    Me.DgvTrnJurnaldetil_Credit.Rows(e.RowIndex).Cells("jurnaldetil_foreign").ReadOnly = False
                    'Me.DgvTrnJurnaldetil_Credit.Rows(e.RowIndex).Cells("jurnaldetil_idr").Style.BackColor = Color.White
                    Me.DgvTrnJurnaldetil_Credit.Rows(e.RowIndex).Cells("jurnaldetil_foreign").Style.BackColor = Color.White
                End If
            End If
        Else
            If clsUtil.IsDbNull(DgvTrnJurnaldetil_Credit.Rows(e.RowIndex).Cells("ref_id").Value, "") <> "" Then
                'Me.DgvTrnJurnaldetil_Credit.Rows(e.RowIndex).Cells("jurnaldetil_idr").ReadOnly = True
                Me.DgvTrnJurnaldetil_Credit.Rows(e.RowIndex).Cells("jurnaldetil_foreign").ReadOnly = True
                'Me.DgvTrnJurnaldetil_Credit.Rows(e.RowIndex).Cells("jurnaldetil_idr").Style.BackColor = Color.LightYellow
                Me.DgvTrnJurnaldetil_Credit.Rows(e.RowIndex).Cells("jurnaldetil_foreign").Style.BackColor = Color.LightYellow
            Else
                'Me.DgvTrnJurnaldetil_Credit.Rows(e.RowIndex).Cells("jurnaldetil_idr").ReadOnly = False
                Me.DgvTrnJurnaldetil_Credit.Rows(e.RowIndex).Cells("jurnaldetil_foreign").ReadOnly = False
                'Me.DgvTrnJurnaldetil_Credit.Rows(e.RowIndex).Cells("jurnaldetil_idr").Style.BackColor = Color.White
                Me.DgvTrnJurnaldetil_Credit.Rows(e.RowIndex).Cells("jurnaldetil_foreign").Style.BackColor = Color.White
            End If

        End If
    End Sub
    Private Sub DgvTrnJurnaldetil_Credit_CellValidated(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvTrnJurnaldetil_Credit.CellValidated
        Dim table_acc_bank As DataTable = New DataTable
        Dim obj As DataGridView = sender
        Dim selisih, jumlah As Decimal
        Dim colName As String = obj.Columns(e.ColumnIndex).Name

        If colName = "jurnaldetil_foreign" Or colName = "jurnaldetil_foreignrate" Then
            If obj.Rows(e.RowIndex).Cells("currency_id").Value = 1 Then
                Me.uiTrnJurnal_PV_Advance_RowCalculateForeignIDR(Me.DgvTrnJurnaldetil_Debit, Me.DgvTrnJurnaldetil_Credit, selisih, jumlah)
                If colName = "jurnaldetil_foreign" Then
                    obj.Rows(e.RowIndex).Cells("jurnaldetil_foreign").Value = Math.Round(obj.Rows(e.RowIndex).Cells("jurnaldetil_foreign").Value, 0, MidpointRounding.AwayFromZero)
                End If
            Else
                Me.uiTrnJurnal_PV_Advance_RowCalculateForeign(Me.DgvTrnJurnaldetil_Debit, Me.DgvTrnJurnaldetil_Credit, selisih, jumlah)
            End If
            Me.obj_Selisih_Foreign.Text = String.Format("{0:#,##0.00}", selisih)
            Me.obj_Jumlah_Foreign.Text = String.Format("{0:#,##0.00}", jumlah)

            '================= REMARK MANG ARI 20160302 ===========================
            'If obj.Rows(e.RowIndex).Cells("acc_id").Value <> akun8002000 Then
            '    Me.uiTrnJurnal_PV_Advance_RowCalcIDR(obj, obj.Rows(e.RowIndex).Cells("jurnaldetil_idr"), obj.Rows(e.RowIndex).Cells("jurnaldetil_foreign"), obj.Rows(e.RowIndex).Cells("jurnaldetil_foreignrate"))
            'End If
            '================= MODIFIED 20160302 ================================
            If obj.Rows(e.RowIndex).Cells("acc_id").Value <> akunKeuntunganLainlainSelisihKurs And obj.Rows(e.RowIndex).Cells("acc_id").Value <> akunKeuntunganLainlainSelisihKursPajak Then
                Me.uiTrnJurnal_PV_Advance_RowCalcIDR(obj, obj.Rows(e.RowIndex).Cells("jurnaldetil_idr"), obj.Rows(e.RowIndex).Cells("jurnaldetil_foreign"), obj.Rows(e.RowIndex).Cells("jurnaldetil_foreignrate"))
            End If

        End If

        If obj.Columns(e.ColumnIndex).Name = "jurnaldetil_idr" Then
            Me.uiTrnJurnal_PV_Advance_RowCalculate(Me.DgvTrnJurnaldetil_Debit, Me.DgvTrnJurnaldetil_Credit, selisih, jumlah)
            Me.obj_Selisih.Text = String.Format("{0:#,##0}", selisih)
            Me.obj_Jumlah.Text = String.Format("{0:#,##0}", jumlah)
        End If

        If obj.Columns(e.ColumnIndex).Name = "jurnalbilyet_bank" Then
            Try
                Me.DataFill(table_acc_bank, "ms_MstBankacc_Select", String.Format(" bankacc_id = {0} ", Me.DgvTrnJurnaldetil_Credit.Rows(Me.DgvTrnJurnaldetil_Credit.CurrentRow.Index).Cells("jurnalbilyet_bank").Value))
                If table_acc_bank.Rows.Count > 0 Then
                    Me.DgvTrnJurnaldetil_Credit.Rows(Me.DgvTrnJurnaldetil_Credit.CurrentRow.Index).Cells("acc_id").Value = table_acc_bank.Rows(0).Item("bankacc_account")
                End If
            Catch ex As Exception

            End Try
        End If
    End Sub
    Private Sub DgvTrnJurnaldetil_Credit_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvTrnJurnaldetil_Credit.CellValueChanged
        Dim table_acc_bank As DataTable = New DataTable
        Dim obj As DataGridView = sender
        Dim selisih, jumlah As Decimal
        Dim colName As String = obj.Columns(e.ColumnIndex).Name

        If colName = "jurnaldetil_foreign" Or colName = "jurnaldetil_foreignrate" Then
            If obj.Rows(e.RowIndex).Cells("currency_id").Value = 1 Then
                Me.uiTrnJurnal_PV_Advance_RowCalculateForeignIDR(Me.DgvTrnJurnaldetil_Debit, Me.DgvTrnJurnaldetil_Credit, selisih, jumlah)
            Else
                Me.uiTrnJurnal_PV_Advance_RowCalculateForeign(Me.DgvTrnJurnaldetil_Debit, Me.DgvTrnJurnaldetil_Credit, selisih, jumlah)
            End If
            Me.obj_Selisih_Foreign.Text = String.Format("{0:#,##0.00}", selisih)
            Me.obj_Jumlah_Foreign.Text = String.Format("{0:#,##0.00}", jumlah)

            '========================== REMARK 20160302 ==================================
            'If obj.Rows(e.RowIndex).Cells("acc_id").Value <> akun8002000 Then
            '=========================== MODIFIED 20160302 MANG ARI ======================
            If obj.Rows(e.RowIndex).Cells("acc_id").Value <> akunKeuntunganLainlainSelisihKurs And obj.Rows(e.RowIndex).Cells("acc_id").Value <> akunKeuntunganLainlainSelisihKursPajak Then
                Me.uiTrnJurnal_PV_Advance_RowCalcIDR(obj, obj.Rows(e.RowIndex).Cells("jurnaldetil_idr"), obj.Rows(e.RowIndex).Cells("jurnaldetil_foreign"), obj.Rows(e.RowIndex).Cells("jurnaldetil_foreignrate"))
            End If

        End If

        If obj.Columns(e.ColumnIndex).Name = "jurnaldetil_idr" Then
            Me.uiTrnJurnal_PV_Advance_RowCalculate(Me.DgvTrnJurnaldetil_Debit, Me.DgvTrnJurnaldetil_Credit, selisih, jumlah)
            Me.obj_Selisih.Text = String.Format("{0:#,##0}", selisih)
            Me.obj_Jumlah.Text = String.Format("{0:#,##0}", jumlah)
        End If

        If obj.Columns(e.ColumnIndex).Name = "jurnalbilyet_bank" Then
            Try
                Me.DataFill(table_acc_bank, "ms_MstBankacc_Select", String.Format(" bankacc_id = {0} ", Me.DgvTrnJurnaldetil_Credit.Rows(Me.DgvTrnJurnaldetil_Credit.CurrentRow.Index).Cells("jurnalbilyet_bank").Value))
                If table_acc_bank.Rows.Count > 0 Then
                    Me.DgvTrnJurnaldetil_Credit.Rows(Me.DgvTrnJurnaldetil_Credit.CurrentRow.Index).Cells("acc_id").Value = table_acc_bank.Rows(0).Item("bankacc_account")
                End If
            Catch ex As Exception

            End Try
        End If
        ''
        '================ ADD PTS 20140915 ====edit manual===buat selisih kurs===bisa rubah amount idr manual dengan rate=0 dan amount foreign nya= 0 juga =========
        If obj.Columns(e.ColumnIndex).Name = "acc_id" Then
            Dim tbl_checkacc_id As DataTable = New DataTable
            tbl_checkacc_id.Clear()
            If Me.tbl_TrnJurnal_Temp.Rows.Count > 0 Then
                If Me.tbl_TrnJurnal_Temp.Rows(0).Item("jurnal_isposted") = 0 Then
                    Me.DataFill(tbl_checkacc_id, "act_selectAccid_PerubahanKurs", String.Format(" acc_id = '{0}'", Me.DgvTrnJurnaldetil_Credit.Rows(e.RowIndex).Cells("acc_id").Value))
                    If tbl_checkacc_id.Rows.Count <> 0 And Me.DgvTrnJurnaldetil_Credit.Rows(e.RowIndex).Cells("ref_id").Value = "" Then
                       

                        Me.DgvTrnJurnaldetil_Credit.Rows(e.RowIndex).Cells("jurnaldetil_foreign").ReadOnly = True
                        Me.DgvTrnJurnaldetil_Credit.Rows(e.RowIndex).Cells("jurnaldetil_foreignrate").ReadOnly = True

                        Me.DgvTrnJurnaldetil_Credit.Rows(e.RowIndex).Cells("jurnaldetil_foreign").Style.BackColor = Color.LightYellow
                        Me.DgvTrnJurnaldetil_Credit.Rows(e.RowIndex).Cells("jurnaldetil_foreignrate").Style.BackColor = Color.LightYellow

                        Me.DgvTrnJurnaldetil_Credit.Rows(e.RowIndex).Cells("jurnaldetil_idr").ReadOnly = False
                        Me.DgvTrnJurnaldetil_Credit.Rows(e.RowIndex).Cells("jurnaldetil_idr").Style.BackColor = Color.White
                        Me.DgvTrnJurnaldetil_Credit.Rows(e.RowIndex).Cells("jurnaldetil_foreign").Value = 0
                        Me.DgvTrnJurnaldetil_Credit.Rows(e.RowIndex).Cells("jurnaldetil_foreignrate").Value = 0
                    ElseIf tbl_checkacc_id.Rows.Count <> 0 And Me.DgvTrnJurnaldetil_Credit.Rows(e.RowIndex).Cells("ref_id").Value <> "" Then
                        Me.DgvTrnJurnaldetil_Credit.Rows(e.RowIndex).Cells("jurnaldetil_foreign").ReadOnly = True
                        Me.DgvTrnJurnaldetil_Credit.Rows(e.RowIndex).Cells("jurnaldetil_foreignrate").ReadOnly = False

                        Me.DgvTrnJurnaldetil_Credit.Rows(e.RowIndex).Cells("jurnaldetil_foreign").Style.BackColor = Color.LightYellow
                        Me.DgvTrnJurnaldetil_Credit.Rows(e.RowIndex).Cells("jurnaldetil_foreignrate").Style.BackColor = Color.White


                        Me.DgvTrnJurnaldetil_Credit.Rows(e.RowIndex).Cells("jurnaldetil_idr").ReadOnly = True
                        Me.DgvTrnJurnaldetil_Credit.Rows(e.RowIndex).Cells("jurnaldetil_idr").Style.BackColor = Color.LightYellow
                    Else
                        Me.DgvTrnJurnaldetil_Credit.Rows(e.RowIndex).Cells("jurnaldetil_foreign").ReadOnly = False
                        Me.DgvTrnJurnaldetil_Credit.Rows(e.RowIndex).Cells("jurnaldetil_foreignrate").ReadOnly = False

                        Me.DgvTrnJurnaldetil_Credit.Rows(e.RowIndex).Cells("jurnaldetil_foreign").Style.BackColor = Color.White
                        Me.DgvTrnJurnaldetil_Credit.Rows(e.RowIndex).Cells("jurnaldetil_foreignrate").Style.BackColor = Color.White

                        Me.DgvTrnJurnaldetil_Credit.Rows(e.RowIndex).Cells("jurnaldetil_idr").ReadOnly = True
                        Me.DgvTrnJurnaldetil_Credit.Rows(e.RowIndex).Cells("jurnaldetil_idr").Style.BackColor = Color.LightYellow
                    End If
                End If

            Else
                Me.DataFill(tbl_checkacc_id, "act_selectAccid_PerubahanKurs", String.Format(" acc_id = '{0}'", Me.DgvTrnJurnaldetil_Credit.Rows(e.RowIndex).Cells("acc_id").Value))
                If tbl_checkacc_id.Rows.Count <> 0 And Me.DgvTrnJurnaldetil_Credit.Rows(e.RowIndex).Cells("ref_id").Value = "" Then
                   

                    Me.DgvTrnJurnaldetil_Credit.Rows(e.RowIndex).Cells("jurnaldetil_foreign").ReadOnly = True
                    Me.DgvTrnJurnaldetil_Credit.Rows(e.RowIndex).Cells("jurnaldetil_foreignrate").ReadOnly = True

                    Me.DgvTrnJurnaldetil_Credit.Rows(e.RowIndex).Cells("jurnaldetil_foreign").Style.BackColor = Color.LightYellow
                    Me.DgvTrnJurnaldetil_Credit.Rows(e.RowIndex).Cells("jurnaldetil_foreignrate").Style.BackColor = Color.LightYellow

                    Me.DgvTrnJurnaldetil_Credit.Rows(e.RowIndex).Cells("jurnaldetil_idr").ReadOnly = False
                    Me.DgvTrnJurnaldetil_Credit.Rows(e.RowIndex).Cells("jurnaldetil_idr").Style.BackColor = Color.White

                    Me.DgvTrnJurnaldetil_Credit.Rows(e.RowIndex).Cells("jurnaldetil_foreign").Value = 0
                    Me.DgvTrnJurnaldetil_Credit.Rows(e.RowIndex).Cells("jurnaldetil_foreignrate").Value = 0

                ElseIf tbl_checkacc_id.Rows.Count <> 0 And Me.DgvTrnJurnaldetil_Credit.Rows(e.RowIndex).Cells("ref_id").Value <> "" Then
                    Me.DgvTrnJurnaldetil_Credit.Rows(e.RowIndex).Cells("jurnaldetil_foreign").ReadOnly = True
                    Me.DgvTrnJurnaldetil_Credit.Rows(e.RowIndex).Cells("jurnaldetil_foreignrate").ReadOnly = False

                    Me.DgvTrnJurnaldetil_Credit.Rows(e.RowIndex).Cells("jurnaldetil_foreign").Style.BackColor = Color.LightYellow
                    Me.DgvTrnJurnaldetil_Credit.Rows(e.RowIndex).Cells("jurnaldetil_foreignrate").Style.BackColor = Color.White


                    Me.DgvTrnJurnaldetil_Credit.Rows(e.RowIndex).Cells("jurnaldetil_idr").ReadOnly = True
                    Me.DgvTrnJurnaldetil_Credit.Rows(e.RowIndex).Cells("jurnaldetil_idr").Style.BackColor = Color.LightYellow
                Else
                    Me.DgvTrnJurnaldetil_Credit.Rows(e.RowIndex).Cells("jurnaldetil_foreign").ReadOnly = False
                    Me.DgvTrnJurnaldetil_Credit.Rows(e.RowIndex).Cells("jurnaldetil_foreignrate").ReadOnly = False

                    Me.DgvTrnJurnaldetil_Credit.Rows(e.RowIndex).Cells("jurnaldetil_foreign").Style.BackColor = Color.White
                    Me.DgvTrnJurnaldetil_Credit.Rows(e.RowIndex).Cells("jurnaldetil_foreignrate").Style.BackColor = Color.White

                    Me.DgvTrnJurnaldetil_Credit.Rows(e.RowIndex).Cells("jurnaldetil_idr").ReadOnly = True
                    Me.DgvTrnJurnaldetil_Credit.Rows(e.RowIndex).Cells("jurnaldetil_idr").Style.BackColor = Color.LightYellow
                End If
            End If


        End If

        '===========================================================================================================================================================



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
    Private Sub DgvTrnJurnaldetil_Credit_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DgvTrnJurnaldetil_Credit.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim click As DataGridView.HitTestInfo = Me.DgvTrnJurnaldetil_Credit.HitTest(e.X, e.Y)
            If click.Type = Windows.Forms.DataGrid.HitTestType.Cell Then
                Me.DgvTrnJurnaldetil_Credit.CurrentCell = Me.DgvTrnJurnaldetil_Credit.Rows(click.RowIndex).Cells(click.ColumnIndex)
                'tambahan aji
                If checkAccountIsBankOrClearing(DgvTrnJurnaldetil_Credit.Rows(click.RowIndex).Cells("acc_id").Value) Then
                    AddInvoiceToolStripMenuItem.Enabled = True
                Else
                    AddInvoiceToolStripMenuItem.Enabled = False
                End If
            Else
                ContextMenuStrip1.Visible = False
                'end tambahan
            End If
        End If
    End Sub
    Private Sub DgvTrnJurnaldetil_Credit_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles DgvTrnJurnaldetil_Credit.RowsRemoved
        Dim obj As DataGridView = sender
        Dim selisih, jumlah As Decimal
        If Me.ftabMain.SelectedIndex = 1 And Me.fTabDataDetil.SelectedIndex = 0 And DATADETIL_OPENED = True Then
            Me.uiTrnJurnal_PV_Advance_RowCalculate(Me.DgvTrnJurnaldetil_Debit, Me.DgvTrnJurnaldetil_Credit, selisih, jumlah)
            Me.obj_Selisih.Text = String.Format("{0:#,##0}", selisih)
            Me.obj_Jumlah.Text = String.Format("{0:#,##0}", jumlah)

            If Me.obj_Currency_id.SelectedValue = 1 Then
                Me.uiTrnJurnal_PV_Advance_RowCalculateForeignIDR(Me.DgvTrnJurnaldetil_Debit, Me.DgvTrnJurnaldetil_Credit, selisih, jumlah)
            Else
                Me.uiTrnJurnal_PV_Advance_RowCalculateForeign(Me.DgvTrnJurnaldetil_Debit, Me.DgvTrnJurnaldetil_Credit, selisih, jumlah)
            End If
            Me.obj_Selisih_Foreign.Text = String.Format("{0:#,##0.00}", selisih)
            Me.obj_Jumlah_Foreign.Text = String.Format("{0:#,##0.00}", jumlah)
        End If
    End Sub
    Private Sub DgvTrnJurnaldetil_Credit_UserDeletedRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles DgvTrnJurnaldetil_Credit.UserDeletedRow
        Dim obj As DataGridView = sender
        Dim selisih, jumlah As Decimal
        Me.uiTrnJurnal_PV_Advance_RowCalculate(Me.DgvTrnJurnaldetil_Debit, Me.DgvTrnJurnaldetil_Credit, selisih, jumlah)
        Me.obj_Selisih.Text = String.Format("{0:#,##0}", selisih)
        Me.obj_Jumlah.Text = String.Format("{0:#,##0}", jumlah)

        If Me.obj_Currency_id.SelectedValue = 1 Then
            Me.uiTrnJurnal_PV_Advance_RowCalculateForeignIDR(Me.DgvTrnJurnaldetil_Debit, Me.DgvTrnJurnaldetil_Credit, selisih, jumlah)
        Else
            Me.uiTrnJurnal_PV_Advance_RowCalculateForeign(Me.DgvTrnJurnaldetil_Debit, Me.DgvTrnJurnaldetil_Credit, selisih, jumlah)
        End If
        Me.obj_Selisih_Foreign.Text = String.Format("{0:#,##0.00}", selisih)
        Me.obj_Jumlah_Foreign.Text = String.Format("{0:#,##0.00}", jumlah)
    End Sub
    Private Sub DgvTrnJurnaldetil_Credit_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles DgvTrnJurnaldetil_Credit.UserDeletingRow
        Dim obj As DataGridView = sender
        Dim selisih, jumlah As Decimal
        Dim x As Integer
        If e.Row.Index < 0 Then Exit Sub

        '======================================================================================= roso
        For x = 0 To Me.DgvTrnJurnaldetil_Credit.SelectedRows.Count - 1
            Dim refId As String = Me.DgvTrnJurnaldetil_Credit.SelectedRows.Item(x).Cells("jurnal_id").Value
            Dim refLine As Integer = Me.DgvTrnJurnaldetil_Credit.SelectedRows.Item(x).Cells("jurnaldetil_line").Value
            Dim ref As String = String.Empty
            Dim line As Integer = 0

            Dim jml As Integer = 0
            For i As Integer = 0 To Me.DgvTrnJurnaldetil_Credit.Rows.Count - 1
                If Me.DgvTrnJurnaldetil_Credit.Item("jurnal_id", i).Value = refId And _
                    Me.DgvTrnJurnaldetil_Credit.Item("jurnaldetil_line", i).Value = refLine Then
                    jml = jml + 1
                End If
            Next

            If jml = 1 Then
ulang:
                For i As Integer = 0 To Me.DgvTrnJurnalInvoice.Rows.Count - 1
                    ref = Me.DgvTrnJurnalInvoice.Item("jurnal_id", i).Value
                    line = Me.DgvTrnJurnalInvoice.Item("jurnal_line", i).Value
                    If refId = ref And refLine = line Then
                        DgvTrnJurnalInvoice.Rows.RemoveAt(i)
                        GoTo ulang
                    End If
                Next
            End If
        Next
        '========================================================================================

        Me.uiTrnJurnal_PV_Advance_RowCalculate(Me.DgvTrnJurnaldetil_Debit, Me.DgvTrnJurnaldetil_Credit, selisih, jumlah)
        Me.obj_Selisih.Text = String.Format("{0:#,##0}", selisih)
        Me.obj_Jumlah.Text = String.Format("{0:#,##0}", jumlah)

        If Me.obj_Currency_id.SelectedValue = 1 Then
            Me.uiTrnJurnal_PV_Advance_RowCalculateForeignIDR(Me.DgvTrnJurnaldetil_Debit, Me.DgvTrnJurnaldetil_Credit, selisih, jumlah)
        Else
            Me.uiTrnJurnal_PV_Advance_RowCalculateForeign(Me.DgvTrnJurnaldetil_Debit, Me.DgvTrnJurnaldetil_Credit, selisih, jumlah)
        End If
        Me.obj_Selisih_Foreign.Text = String.Format("{0:#,##0.00}", selisih)
        Me.obj_Jumlah_Foreign.Text = String.Format("{0:#,##0.00}", jumlah)
    End Sub
#End Region

#Region " Print "
    Private Function uiTrnJurnal_PV_Advance_Print() As Boolean
        Dim retObj As DataTable = New DataTable
        Dim i, j As Integer

        If Me.ftabMain.SelectedIndex = 0 Then
            If Me.DgvTrnJurnal.SelectedRows.Count <= 0 Then
                MsgBox("Belum ada data yang dipilih")
                Exit Function
            End If
        ElseIf Me.ftabMain.SelectedIndex = 1 Then
            If Me.DgvTrnJurnal.Rows.Count <= 0 Then
                MsgBox("Belum ada data yang dipilih")
                Exit Function
            End If
        End If

        If Me.ftabMain.SelectedIndex = 0 Then
            Dim dlg As dlgRptJurnal_PV_ChoiceTravel = New dlgRptJurnal_PV_ChoiceTravel("Print")
            retObj = dlg.OpenDialog(Me)

            If retObj IsNot Nothing Then
                For Each dtRow As DataRow In retObj.Rows
                    If dtRow("print_name") = "pv" And dtRow("print_check") = True Then 'payment voucher
                        For i = 0 To Me.DgvTrnJurnal.SelectedRows.Count - 1
                            GeneratePrintPV(Me.DgvTrnJurnal.SelectedRows.Item(i).Cells("jurnal_id").Value, Me.DgvTrnJurnal.SelectedRows.Item(i).Cells("channel_id").Value)
                        Next
                    ElseIf dtRow("print_name") = "at" And dtRow("print_check") = True Then 'advance travel (spd)
                        Dim advance_id As String = ""
                        Dim budget_id As Decimal = 0
                        For i = 0 To Me.DgvTrnJurnal.SelectedRows.Count - 1
                            advance_id = GetAdvanceID(Me.DgvTrnJurnal.SelectedRows.Item(i).Cells("jurnal_id").Value)
                            If advance_id <> "" Then
                                budget_id = GetAdvanceBudgetID(advance_id)
                            End If
                        Next

                        Dim oDataFiller As New clsDataFiller(Me.DSN)
                        Me.tbl_TrnAdvance.Clear()
                        Me.tbl_TrnAdvanceDetil.Clear()

                        oDataFiller.DataFill(Me.tbl_TrnAdvance, "vq_RptAdvance_Select", String.Format("advance_id = '{0}'", advance_id))
                        Me.GeneratePrintAdvanceTravel(advance_id, budget_id)
                    ElseIf dtRow("print_name") = "jv" And dtRow("print_check") = True Then 'Journal voucher
                        For i = 0 To Me.DgvTrnJurnal.SelectedRows.Count - 1
                            GeneratePrintJV(Me.DgvTrnJurnal.SelectedRows.Item(i).Cells("jurnal_id").Value, Me.DgvTrnJurnal.SelectedRows.Item(i).Cells("channel_id").Value)
                        Next
                    End If
                Next
            Else
                Exit Function
            End If

        ElseIf Me.ftabMain.SelectedIndex = 1 Then
            Dim dlg As dlgRptJurnal_PV_ChoiceTravel = New dlgRptJurnal_PV_ChoiceTravel("Print")
            retObj = dlg.OpenDialog(Me)

            If retObj IsNot Nothing Then
                For Each dtRow As DataRow In retObj.Rows
                    If dtRow("print_name") = "pv" And dtRow("print_check") = True Then 'payment voucher
                        GeneratePrintPV(Me.obj_Jurnal_id.Text, Me._CHANNEL)
                    ElseIf dtRow("print_name") = "at" And dtRow("print_check") = True Then 'advance travel (spd)
                        Dim advance_id As String = ""
                        Dim budget_id As Decimal = 0

                        advance_id = GetAdvanceID(Me.obj_Jurnal_id.Text)
                        If advance_id <> "" Then
                            budget_id = GetAdvanceBudgetID(advance_id)
                        End If


                        Dim oDataFiller As New clsDataFiller(Me.DSN)
                        Me.tbl_TrnAdvance.Clear()
                        Me.tbl_TrnAdvanceDetil.Clear()

                        oDataFiller.DataFill(Me.tbl_TrnAdvance, "vq_RptAdvance_Select", String.Format("advance_id = '{0}'", advance_id))
                        Me.GeneratePrintAdvanceTravel(advance_id, budget_id)
                    ElseIf dtRow("print_name") = "jv" And dtRow("print_check") = True Then 'Journal voucher
                        GeneratePrintJV(Me.obj_Jurnal_id.Text, Me._CHANNEL)
                    End If
                Next
            Else
                Exit Function
            End If

        End If
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
            Me.GenerateDataDetail()
        End With
        objDatalistHeader.Add(objPrintHeader)

        Return objDatalistHeader
    End Function

    Private Function GenerateDataDetail() As ArrayList
        Dim i As Integer
        '== ari
        Dim dt_accref1 As DataTable = New DataTable
        Dim dt_accref2 As DataTable = New DataTable
        dt_accref1.Clear()
        dt_accref2.Clear()
        Me.DataFill(dt_accref1, "act_selectAccRef_Detil", "accref_id = 3201") '8500015
        Me.DataFill(dt_accref2, "act_selectAccRef_Detil", "accref_id = 3202") 'akun8002000 
        Dim akun1 As String = dt_accref1.Rows(0).Item(0)
        Dim akun2 As String = dt_accref2.Rows(0).Item(0)
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
                If .acc_id = akun1 Or .acc_id = akun2 Then
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

    Private Function GenerateDataHeaderPayment(ByVal jurnal_id_temp As String, ByVal channel_id_temp As String) As ArrayList
        Dim objDatalistHeader As ArrayList = New ArrayList()
        Dim oDataFiller As New clsDataFiller(Me.DSN)
        Dim tbl_advance As DataTable = New DataTable
        Dim criteria As String

        Me.objPrintHeaderPayment = New DataSource.clsRptJurnalPV_Header(Me.DSN)
        Me.tbl_Print.Clear()
        Me.DataFill(Me.tbl_Print, "act_RptJurnalPV_SelectHeader", String.Format("jurnal_id = '{0}' ", jurnal_id_temp), channel_id_temp)
        With Me.objPrintHeaderPayment
            criteria = String.Format("jurnal_id = '{0}' ", jurnal_id_temp)
            .jurnal_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("jurnal_id"), String.Empty)
            .curr = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("currency_name"), String.Empty)
            Me.parCurrency_Name = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("currency_name"), String.Empty)
            Me.parRekanan_Name = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("rekanan_name"), String.Empty)
            Me.parJurnal_Desc = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("jurnal_descr"), String.Empty)
            Me.parCreate_Date = clsUtil.IsDbNull(Format(Me.tbl_Print.Rows(0).Item("created_dt"), "dd-MM-yyyy"), String.Empty)
            Me.parBudget_name = " "
            Me.parAmountRate = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("currency_rate"), 0)
            .channel_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("channel_id"), String.Empty)

            Me.strchannel_id = .channel_id
            Me.sptChannel_nameReport = .channel_namereport
            Me.sptChannel_address = .channel_address
            Me.id = .jurnal_id
            Me.p_date = .CreateDate
            Me.curr = .curr

            Me.tbl_PrintDetil.Clear()
            Me.DataFill(Me.tbl_PrintDetil, "act_RptJurnalPV_SelectDetil", criteria)
            Me.GenerateDataDetailPayment()
        End With
        objDatalistHeader.Add(Me.objPrintHeaderPayment)

        Return objDatalistHeader
    End Function

    Private Function GenerateDataDetailPayment() As ArrayList
        '== ari
        Dim dt_accref1 As DataTable = New DataTable
        Dim dt_accref2 As DataTable = New DataTable
        Dim dt_accref3 As DataTable = New DataTable
        Dim dt_accref4 As DataTable = New DataTable
        dt_accref1.Clear()
        dt_accref2.Clear()
        dt_accref3.Clear()
        dt_accref4.Clear()
        Me.DataFill(dt_accref1, "act_selectAccRef_Detil", "accref_id = 3101") '8500011
        Me.DataFill(dt_accref2, "act_selectAccRef_Detil", "accref_id = 5801") '1950420
        Me.DataFill(dt_accref3, "act_selectAccRef_Detil", "accref_id = 5901") '1950430  	 yang baru'1162433
        Me.DataFill(dt_accref4, "act_selectAccRef_Detil", "accref_id = 5701") '1950920
        Dim akun1 As String = dt_accref1.Rows(0).Item(0)
        Dim akun2 As String = dt_accref2.Rows(0).Item(0)
        Dim akun3 As String = dt_accref3.Rows(0).Item(0)
        Dim akun4 As String = dt_accref4.Rows(0).Item(0)
        '==
        Dim i As Integer
        Dim IdrAmount, foreignAmount As Decimal

        objDatalistDetil = New ArrayList()
        Me.AmountIdrNew = 0
        Me.AmountForeignNew = 0
        IdrAmount = 0
        foreignAmount = 0
        For i = 0 To Me.tbl_PrintDetil.Rows.Count - 1
            Me.objPrintDetilPayment = New DataSource.clsRptJurnalPV_Detil(Me.DSN)

            With Me.objPrintDetilPayment
                .account_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("acc_id"), 0)
                .jurnal_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("jurnal_id"), String.Empty)
                .DescriptionDetil = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("jurnaldetil_descr"), String.Empty)
                .Detil_dk = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("jurnaldetil_dk"), String.Empty)
                If .Detil_dk = "D" Then
                    .bilyet_reqs = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("ref_id"), String.Empty)
                    .date_create = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("entry_date"), "")
                Else
                    .bilyet_reqs = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("jurnal_bilyet"), String.Empty)
                    .date_create = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("entry_date"), String.Empty)
                    .bank_acc = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("bankacc_name"), String.Empty)
                    .type = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("paymenttype_name"), String.Empty)
                End If

                .curr = Me.curr
                .rate = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("jurnaldetil_foreignrate"), 0)
                If .account_id = akun1 Then
                    .foreign = 0
                Else
                    .foreign = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("jurnaldetil_foreign"), 0)
                End If

                If .account_id <> "0" And .account_id <> akun2 And .account_id <> akun3 And .account_id <> akun4 Then
                    If .Detil_dk = "K" Then
                        .idr = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("jurnaldetil_idr"), 0)
                        If .idr <= 0 And .foreign <= 0 Then
                            IdrAmount = .idr * -1
                            foreignAmount = .foreign * -1
                        End If
                        Me.AmountIdrNew += IdrAmount
                        Me.AmountForeignNew += foreignAmount
                    Else
                        .idr = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("jurnaldetil_idr"), 0)
                    End If
                Else
                    .idr = 0
                    .foreign = 0
                End If

                If .idr <= 0 Then
                    .idr = .idr * -1
                End If
                If .foreign <= 0 Then
                    .foreign = .foreign * -1
                End If
            End With
            objDatalistDetil.Add(Me.objPrintDetilPayment)
        Next

        Return objDatalistDetil
    End Function

    Private Sub Export(ByVal report As Microsoft.Reporting.WinForms.LocalReport)

        Dim deviceInfo As String = _
          "<DeviceInfo>" & _
        "  <OutputFormat>EMF</OutputFormat>" & _
        "  <PageWidth>8.27in</PageWidth>" & _
        "  <PageHeight>11.69in</PageHeight>" & _
        "  <MarginTop>0.1in</MarginTop>" & _
        "  <MarginLeft>0.1in</MarginLeft>" & _
        "  <MarginRight>0.1in</MarginRight>" & _
        "  <MarginBottom>0.1in</MarginBottom>" & _
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
        Dim stream As System.IO.Stream = New System.IO.FileStream(AppDomain.CurrentDomain.BaseDirectory & "Temp\" & name & "." & fileNameExtension, System.IO.FileMode.Create)

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

    Private Sub PrintCekBG()
        Dim printDoc As New System.Drawing.Printing.PrintDocument()
        Dim printSet As New System.Drawing.Printing.PrinterSettings
        ' Const printerName As String = "Epson LX-300+"

        Dim printerName As String

        printerName = clsUtil.GetRegistryValue("Software\Slipbank", "Printer Dot Matrix")
        If printerName <> "[ Setting Slip Belum Ada ]" Then
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
        Else
            MsgBox("Master Printer Belum Di Setting ")
        End If

    End Sub

    Public Sub SubreportProcessingPV(ByVal sender As Object, ByVal e As Microsoft.Reporting.WinForms.SubreportProcessingEventArgs)
        e.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("ACT_FINANCE_DataSource_clsRptJurnalPV_Detil", objDatalistDetil))
    End Sub

    Public Sub SubreportProcessingJV(ByVal sender As Object, ByVal e As Microsoft.Reporting.WinForms.SubreportProcessingEventArgs)
        e.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("ACT_FINANCE_DataSource_clsRptJurnal_Detil", objDatalistDetil))
    End Sub

    Public Sub SubreportProcessingAdvance(ByVal sender As Object, ByVal e As Microsoft.Reporting.WinForms.SubreportProcessingEventArgs)
        e.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("ACTFINANCE_DataSource_ClsRptAdvanceDetil", objDatalistDetil))
    End Sub

    Private Function uiTrnJurnal_PV_Advance_PrintPreview() As Boolean
        Dim retObj As DataTable = New DataTable

        If Me.ftabMain.SelectedIndex = 0 Then
            If Me.DgvTrnJurnal.SelectedRows.Count <= 0 Then
                MsgBox("Belum ada data yang dipilih")
                Exit Function
            End If

            Dim dlg As dlgRptJurnal_PV_ChoiceTravel = New dlgRptJurnal_PV_ChoiceTravel("Print Preview")
            retObj = dlg.OpenDialog(Me)
            If retObj IsNot Nothing Then

                For Each dtRow As DataRow In retObj.Rows
                    If dtRow("print_name") = "pv" And dtRow("print_check") = True Then 'payment voucher
                        For i = 0 To Me.DgvTrnJurnal.SelectedRows.Count - 1
                            Dim frmPrintPV As dlgRptJurnal_PV = New dlgRptJurnal_PV(Me.DSN, Me.SptServer, Me.DgvTrnJurnal.SelectedRows.Item(i).Cells("jurnal_id").Value, Me.DgvTrnJurnal.SelectedRows.Item(i).Cells("channel_id").Value)

                            frmPrintPV.ShowInTaskbar = False
                            frmPrintPV.StartPosition = FormStartPosition.CenterParent
                            frmPrintPV.ShowDialog(Me)
                        Next
                    ElseIf dtRow("print_name") = "at" And dtRow("print_check") = True Then 'advance travel (spd)
                        Dim advance_id As String = ""
                        Dim budget_id As Decimal = 0
                        For i = 0 To Me.DgvTrnJurnal.SelectedRows.Count - 1
                            advance_id = GetAdvanceID(Me.DgvTrnJurnal.SelectedRows.Item(i).Cells("jurnal_id").Value)
                            If advance_id <> "" Then
                                budget_id = GetAdvanceBudgetID(advance_id)
                            End If
                        Next
                        'DgvTrnAdvance.CurrentRow.Cells("advance_id").Value
                        'budget_id = DgvTrnAdvance.CurrentRow.Cells("budget_id").Value

                        Dim frmPrintAdvance As dlgTrnAdvancePrintListSPD = New dlgTrnAdvancePrintListSPD(Me.DSN, Me.SptServer, advance_id, Me._CHANNEL, budget_id)
                        Dim criteria As String = String.Empty

                        frmPrintAdvance.ShowInTaskbar = False
                        frmPrintAdvance.StartPosition = FormStartPosition.CenterParent

                        criteria = "  advance_id = '" & advance_id & "'"

                        frmPrintAdvance.SetIDCriteria(criteria)
                        frmPrintAdvance.ShowDialog(Me)
                    ElseIf dtRow("print_name") = "jv" And dtRow("print_check") = True Then 'Journal voucher
                        For i = 0 To Me.DgvTrnJurnal.SelectedRows.Count - 1
                            Dim frmPrint As dlgRptJurnal = New dlgRptJurnal(Me.DSN, Me.SptServer, Me.DgvTrnJurnal.SelectedRows.Item(i).Cells("jurnal_id").Value, Me.DgvTrnJurnal.SelectedRows.Item(i).Cells("channel_id").Value)

                            frmPrint.ShowInTaskbar = False
                            frmPrint.StartPosition = FormStartPosition.CenterParent
                            frmPrint.ShowDialog(Me)
                        Next
                    End If
                Next
            Else
                Exit Function
            End If
        ElseIf Me.ftabMain.SelectedIndex = 1 Then
            Dim dlg As dlgRptJurnal_PV_ChoiceTravel = New dlgRptJurnal_PV_ChoiceTravel("Print Preview")
            retObj = dlg.OpenDialog(Me)
            If retObj IsNot Nothing Then

                For Each dtRow As DataRow In retObj.Rows
                    If dtRow("print_name") = "pv" And dtRow("print_check") = True Then 'payment voucher
                        Dim frmPrintPV As dlgRptJurnal_PV = New dlgRptJurnal_PV(Me.DSN, Me.SptServer, obj_Jurnal_id.Text, Me._CHANNEL)

                        frmPrintPV.ShowInTaskbar = False
                        frmPrintPV.StartPosition = FormStartPosition.CenterParent
                        frmPrintPV.ShowDialog(Me)
                    ElseIf dtRow("print_name") = "at" And dtRow("print_check") = True Then 'advance travel (spd)
                        Dim advance_id As String = ""
                        Dim budget_id As Decimal = 0

                        advance_id = GetAdvanceID(obj_Jurnal_id.Text)
                        If advance_id <> "" Then
                            budget_id = GetAdvanceBudgetID(advance_id)
                        End If

                        'DgvTrnAdvance.CurrentRow.Cells("advance_id").Value
                        'budget_id = DgvTrnAdvance.CurrentRow.Cells("budget_id").Value

                        Dim frmPrintAdvance As dlgTrnAdvancePrintListSPD = New dlgTrnAdvancePrintListSPD(Me.DSN, Me.SptServer, advance_id, Me._CHANNEL, budget_id)
                        Dim criteria As String = String.Empty

                        frmPrintAdvance.ShowInTaskbar = False
                        frmPrintAdvance.StartPosition = FormStartPosition.CenterParent

                        criteria = "  advance_id = '" & advance_id & "'"

                        frmPrintAdvance.SetIDCriteria(criteria)
                        frmPrintAdvance.ShowDialog(Me)
                    ElseIf dtRow("print_name") = "jv" And dtRow("print_check") = True Then 'Journal voucher
                        Dim frmPrint As dlgRptJurnal = New dlgRptJurnal(Me.DSN, Me.SptServer, obj_Jurnal_id.Text, Me._CHANNEL)

                        frmPrint.ShowInTaskbar = False
                        frmPrint.StartPosition = FormStartPosition.CenterParent
                        frmPrint.ShowDialog(Me)
                    End If
                Next
            Else
                Exit Function
            End If
        End If
    End Function
#End Region

#Region "mencoba tuning (yanuar)"

#Region " Untuk BackgroundWorker"
    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Dim BG_Worker As BackgroundWorker = CType(sender, BackgroundWorker)
        If BG_Worker.CancellationPending Then
            e.Cancel = True
        Else
            Me.uiTrnJurnal_PV_Advance_CollectionData_with_BackgroundWorker(BG_Worker)
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
    Public Sub uiTrnJurnal_PV_Advance_newBackgroundWorker()
        Me.BackgroundWorker1 = New BackgroundWorker
        BackgroundWorker1.RunWorkerAsync()
    End Sub
    Private Sub uiTrnJurnal_PV_Advance_CollectionData_with_BackgroundWorker(ByVal worker As BackgroundWorker)
        worker.WorkerReportsProgress = True

        Me.label_thread = "Budget"
        worker.ReportProgress(0)
        Me.ComboFillDec(Me.obj_Budget_id, "budget_id", "budget_nameshort", Me.tbl_TrnBudget, "ms_MstBudgetCombo_Select", " budget_isactive = 1")
        Me.tbl_TrnBudget.DefaultView.Sort = "budget_nameshort"
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
        Me.ComboFillDec(Me.obj_Rekanan_id, "rekanan_id", "rekanan_name", Me.tbl_MstRekanan, "ms_MstRekanan_Select2", " rekanan_active = 1 ", Me._CHANNEL)
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
        Me.DataFill(dt_accref1, "act_selectAccRef_Detil", "accref_id = 3201") 'akun8500015
        Me.DataFill(dt_accref2, "act_selectAccRef_Detil", "accref_id = 3202") 'akun8002000
        Me.DataFill(dt_accref3, "act_selectAccRef_Detil", "accref_id = 3301") 'akun8009990 
        Me.DataFill(dt_accref4, "act_selectAccRef_Detil", "accref_id = 3302") 'akun8509990
        Me.DataFill(dt_accref5, "act_selectAccRef_Detil", "accref_id = 3101") 'akun8500011
        Me.DataFill(dt_accref6, "act_selectAccRef_Detil", "accref_id = 3102") 'akun8001000
        akun8500015 = dt_accref1.Rows(0).Item(0)
        akun8009990 = dt_accref3.Rows(0).Item(0)
        akun8002000 = dt_accref2.Rows(0).Item(0)
        akun8509990 = dt_accref4.Rows(0).Item(0)
        akun8500011 = dt_accref5.Rows(0).Item(0)
        akun8001000 = dt_accref6.Rows(0).Item(0)
        '==
        '====end

        worker.ReportProgress(100)

    End Sub

    Private Sub uiTrnJurnal_PV_Advance_isBackgroudWorker()

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
                    Me.uiTrnJurnal_PV_Advance_newBackgroundWorker()
                Else
                    Me.BackgroundWorker1.RunWorkerAsync()
                End If
                Me.isBackgroundWorker = True
            End If
        End If
        Me.Cursor = Cursors.Arrow
    End Sub
    Private Sub uiTrnJurnal_PV_Advance_LoadComboBox()
        If Me.isLoadComboInLoadData = False Then
            Try
                Me.ComboFill(Me.cboSearchChannel, "channel_id", "channel_name", Me.tbl_MstChannelSearch, "ms_MstChannelCombo_Select", " channel_id = '" & Me._CHANNEL & "' ")
                Me.tbl_MstChannelSearch.DefaultView.Sort = "channel_name"
                Dim channel As Boolean
                Me.tbl_MstChannel = tbl_MstChannelSearch.Copy
                channel = ComboFillFromDataTable(Me.obj_Channel_id, "channel_id", "channel_name", Me.tbl_MstChannel)
                Me.tbl_MstChannel.DefaultView.Sort = "channel_name"

                Me.ComboFill(Me.cbo_periodeSearch, "periode_id", "periode_name", Me.tbl_MstPeriodeSearch, "ms_MstPeriodeCombo_Select", " channel_id = '" & Me._CHANNEL & "' ")
                Me.tbl_MstPeriodeSearch.DefaultView.Sort = "periode_name"
                Dim periode As Boolean
                Me.tbl_MstPeriode = tbl_MstPeriodeSearch.Copy
                periode = ComboFillFromDataTable(Me.obj_Periode_id, "periode_id", "periode_name", Me.tbl_MstPeriode)
                Me.tbl_MstPeriode.DefaultView.Sort = "periode_name"

                Me.ComboFill(Me.cbo_createBySearch, "username", "user_fullname", Me.tbl_MstUserSearch, "ms_MstUserInsosysCombo_Select", " user_isdisabled = 0")
                Me.tbl_MstUserSearch.DefaultView.Sort = "user_fullname"

                Me.DataFillForCombo("acc_id", "acc_name", Me.tbl_MstAccGrid, "ms_MstAccountCombo_Select", " acc_isdisabled = 0 ")
                Me.tbl_MstAccGrid.DefaultView.Sort = "acc_name"

                Me.ComboFillDec(Me.obj_Acc_ca_id, "acc_ca_id", "acc_ca_shortname", tbl_MstAcc_ca, "ms_MstAccountCaCombo_Select", "  acc_ca_type = 2  ")
                Me.tbl_MstAcc_ca.DefaultView.Sort = "acc_ca_shortname"

                Me.DataFillForComboDec("bankacc_id", "bankacc_reportname", Me.tbl_MstBankacc, "ms_MstBankaccCombo_Select", " channel_id = '" & Me._CHANNEL & "' ")
                Me.tbl_MstBankacc.DefaultView.Sort = "bankacc_reportname"

                Me.DataFill(Me.tbl_MstPaymentTypeGrid, "cp_MstPaymenttype_Select", "")
                Me.tbl_MstPaymentTypeGrid.DefaultView.Sort = "paymenttype_name"

                Me.DataFillForCombo("slipformat_id", "slipformat_name", Me.tbl_MstSlipFormat, "ms_MstSlipformatCombo_Select", "")
                Me.tbl_MstSlipFormat.DefaultView.Sort = "slipformat_name"

                Me.DataFillForCombo("purposefund_id", "purposefund_name", Me.tbl_MstPurposeFund, "ms_MstPurposeFundCombo_Select", "")
                Me.tbl_MstPurposeFund.DefaultView.Sort = "purposefund_name"

                Me.DataFillForCombo("show_id", "show_title", Me.tbl_MstShow, "ms_MstShowCombo_select", "")
                Me.tbl_MstShow.DefaultView.Sort = "show_title"


                Me.txtSearchSource.Text = Me._SOURCE
                Me.isLoadComboInLoadData = True
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        End If
    End Sub
#End Region



#End Region

    Private Function uiTrnJurnal_PV_Advance_RowCalculate(ByVal dgv_D As DataGridView, ByVal dgv_K As DataGridView, ByRef selisih As Decimal, ByRef jumlah As Decimal) As Boolean
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
                    'value = cellIDR.Value
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
                    'value = Math.Round(cellIDR.Value, 0, MidpointRounding.AwayFromZero)
                    value = cellIDR.Value
                End If
            Else
                value = 0
            End If

            jumlah_K += value

        Next

        jumlah = Math.Round(jumlah_D, 0, MidpointRounding.AwayFromZero)
        selisih = Math.Round(jumlah_D, 0, MidpointRounding.AwayFromZero) - Math.Round(jumlah_K, 0, MidpointRounding.AwayFromZero)

        Me.obj_amountDebitIdr.Text = Format(jumlah_D, "#,##0")
        Me.obj_amountCreditIdr.Text = Format(jumlah_K, "#,##0")

    End Function

    Private Function uiTrnJurnal_PV_Advance_RowCalculateForeign(ByVal dgv_D As DataGridView, ByVal dgv_K As DataGridView, ByRef selisih As Decimal, ByRef jumlah As Decimal) As Boolean
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
                    'value = cellForeign.Value
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
                    'value = cellForeign.Value
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

    Private Function uiTrnJurnal_PV_Advance_RowCalculateForeignIDR(ByVal dgv_D As DataGridView, ByVal dgv_K As DataGridView, ByRef selisih As Decimal, ByRef jumlah As Decimal) As Boolean
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
                    'value = cellForeign.Value
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
                    'value = cellForeign.Value
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

    Private Function uiTrnJurnal_PV_Advance_RowCalcIDR(ByVal dgv As DataGridView, ByVal cellIDR As DataGridViewCell, ByVal cellForeign As DataGridViewCell, ByVal cellRate As DataGridViewCell) As Boolean
        Dim TotalperRow As Decimal

        'TotalperRow = Math.Round(clsUtil.IsDbNull(cellForeign.Value, 0), 2, MidpointRounding.AwayFromZero) * Math.Round(clsUtil.IsDbNull(cellRate.Value, 0), 2, MidpointRounding.AwayFromZero)
        ''TotalperRow = clsUtil.IsDbNull(cellForeign.Value, 0) * clsUtil.IsDbNull(cellRate.Value, 0)
        'Try
        '    cellIDR.Value = Math.Round(TotalperRow, 0, MidpointRounding.AwayFromZero) 'String.Format("{0:#,##0.00}", TotalperRow)    TotalperRow.ToString("{0:#,##0.00}")

        'Catch ex As Exception
        '    MessageBox.Show(ex.Message, "uiTrnJurnal_RowCalcIDR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try

        '===== ari 20151014 ======
        If obj_Jurnal_isposted.CheckState = CheckState.Unchecked Then
            If dgv.CurrentRow.Cells("branch_id").Value = 0 Then 'branch_id (TANDA UNTUK UBAH DARI RATE TAX ATAU AMOUNT IDR TAX)
                If dgv.CurrentRow.Cells("acc_id").Value <> akun8500015 And dgv.CurrentRow.Cells("acc_id").Value <> akun8002000 And _
                    dgv.CurrentRow.Cells("acc_id").Value <> akun8009990 And dgv.CurrentRow.Cells("acc_id").Value <> akun8509990 And _
                    dgv.CurrentRow.Cells("acc_id").Value <> akun8500011 And dgv.CurrentRow.Cells("acc_id").Value <> akun8001000 Then

                    TotalperRow = Math.Round(clsUtil.IsDbNull(cellForeign.Value, 0), 2, MidpointRounding.AwayFromZero) * Math.Round(clsUtil.IsDbNull(cellRate.Value, 0), 2, MidpointRounding.AwayFromZero)
                    Try
                        cellIDR.Value = Math.Round(TotalperRow, 0, MidpointRounding.AwayFromZero) 'String.Format("{0:#,##0.00}", TotalperRow)    TotalperRow.ToString("{0:#,##0.00}")
                    Catch ex As Exception
                        MessageBox.Show(ex.Message, "uiTrnJurnal_RowCalcIDR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End If
            End If
        End If
        '=========================

    End Function

    Private Function uiTrnJurnal_PV_Advance_TblDetilInverse(ByVal tbl As DataTable) As Boolean
        Dim i As Integer
        For i = 0 To tbl.Rows.Count - 1
            If tbl.Rows(i).RowState <> DataRowState.Deleted Then
                tbl.Rows(i).Item("jurnaldetil_idr") = -tbl.Rows(i).Item("jurnaldetil_idr")
                tbl.Rows(i).Item("jurnaldetil_foreign") = -tbl.Rows(i).Item("jurnaldetil_foreign")
            End If
        Next
        Return True
    End Function

    Private Function uiTrnJurnal_PV_Advance_SetDefaultValueOfJurnaldetil_Debit(ByVal sender As System.Object, ByVal columnname As String) As Boolean
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

    Private Function uiTrnJurnal_PV_Advance_SetDefaultValueOfJurnaldetil_Credit(ByVal sender As System.Object, ByVal columnname As String) As Boolean
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

    Private Function uiTrnJurnal_PV_Advance_DataIsLocked() As Boolean
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
        Dim i As Integer
        Dim row As DataRow
        Dim selisih, jumlah As Decimal

        For i = 0 To Me.DgvTrnJurnaldetil_Debit.Rows.Count - 1
            Me.DgvTrnJurnaldetil_Debit.Rows(i).Cells("jurnaldetil_foreignrate").Value = CDec(Me.obj_Currency_rate.Text)
        Next

        For i = 0 To Me.DgvTrnJurnaldetil_Credit.Rows.Count - 1
            Me.DgvTrnJurnaldetil_Credit.Rows(i).Cells("jurnaldetil_foreignrate").Value = CDec(Me.obj_Currency_rate.Text)
        Next

        Me.tbl_TrnJurnaldetil_Debit.Columns("jurnaldetil_foreignrate").DefaultValue = obj.Text
        Me.tbl_TrnJurnaldetil_Credit.Columns("jurnaldetil_foreignrate").DefaultValue = obj.Text

        Me.uiTrnJurnal_PV_Advance_RowCalculateForeign(Me.DgvTrnJurnaldetil_Debit, Me.DgvTrnJurnaldetil_Credit, selisih, jumlah)
        Me.obj_Selisih_Foreign.Text = String.Format("{0:#,##0.00}", selisih)
        Me.obj_Jumlah_Foreign.Text = String.Format("{0:#,##0.00}", jumlah)

        Me.uiTrnJurnal_PV_Advance_RowCalculate(Me.DgvTrnJurnaldetil_Debit, Me.DgvTrnJurnaldetil_Credit, selisih, jumlah)
        Me.obj_Selisih.Text = String.Format("{0:#,##0}", selisih)
        Me.obj_Jumlah.Text = String.Format("{0:#,##0}", jumlah)

        If selisih > 0 Then
            row = Me.tbl_TrnJurnaldetil_Credit.NewRow
            row.Item("currency_id") = Me.obj_Currency_id.SelectedValue
            row.Item("jurnaldetil_idr") = selisih


            If Me.obj_Currency_id.SelectedValue = 1 Then
                row.Item("jurnaldetil_foreign") = row.Item("jurnaldetil_idr")
                row.Item("jurnaldetil_foreignrate") = 0
            Else
                row.Item("jurnaldetil_foreign") = 0
                row.Item("jurnaldetil_foreignrate") = 0
            End If

            'row.Item("jurnaldetil_foreign") = 0
            'row.Item("jurnaldetil_foreignrate") = 0

            row.Item("acc_id") = "akun8009990"
            row.Item("ref_id") = String.Empty
            row.Item("ref_line") = 0
            row.Item("ref_budgetline") = 0
            row.Item("region_id") = 0
            row.Item("branch_id") = 0
            row.Item("strukturunit_id") = 0
            row.Item("rekanan_id") = Me.obj_Rekanan_id.SelectedValue
            row.Item("rekanan_name") = Me.obj_Rekanan_id.Text
            row.Item("jurnaldetil_descr") = "Pendapatan"
            Me.tbl_TrnJurnaldetil_Credit.Rows.Add(row)
        ElseIf selisih < 0 Then

            row = Me.tbl_TrnJurnaldetil_Debit.NewRow
            row.Item("currency_id") = Me.obj_Currency_id.SelectedValue
            row.Item("jurnaldetil_idr") = -selisih

            If Me.obj_Currency_id.SelectedValue = 1 Then
                row.Item("jurnaldetil_foreign") = row.Item("jurnaldetil_idr")
                row.Item("jurnaldetil_foreignrate") = 0
            Else
                row.Item("jurnaldetil_foreign") = 0
                row.Item("jurnaldetil_foreignrate") = 0
            End If

            'row.Item("jurnaldetil_foreign") = 0
            'row.Item("jurnaldetil_foreignrate") = 0


            row.Item("acc_id") = "8509990"
            row.Item("ref_id") = String.Empty
            row.Item("ref_line") = 0
            row.Item("ref_budgetline") = 0
            row.Item("region_id") = 0
            row.Item("branch_id") = 0
            row.Item("strukturunit_id") = 0
            row.Item("rekanan_id") = Me.obj_Rekanan_id.SelectedValue
            row.Item("rekanan_name") = Me.obj_Rekanan_id.Text
            row.Item("jurnaldetil_descr") = "Biaya"
            Me.tbl_TrnJurnaldetil_Debit.Rows.Add(row)
        End If

        Me.uiTrnJurnal_PV_Advance_RowCalculate(Me.DgvTrnJurnaldetil_Debit, Me.DgvTrnJurnaldetil_Credit, selisih, jumlah)
        Me.obj_Selisih.Text = String.Format("{0:#,##0}", selisih)
        Me.obj_Jumlah.Text = String.Format("{0:#,##0}", jumlah)
        'Dim obj As TextBox = sender
        'Dim i As Integer

        'For i = 0 To Me.DgvTrnJurnaldetil_Debit.Rows.Count - 1
        '    Me.DgvTrnJurnaldetil_Debit.Rows(i).Cells("jurnaldetil_foreignrate").Value = CDec(Me.obj_Currency_rate.Text)
        'Next

        'For i = 0 To Me.DgvTrnJurnaldetil_Credit.Rows.Count - 1
        '    Me.DgvTrnJurnaldetil_Credit.Rows(i).Cells("jurnaldetil_foreignrate").Value = CDec(Me.obj_Currency_rate.Text)
        'Next

        'Me.tbl_TrnJurnaldetil_Debit.Columns("jurnaldetil_foreignrate").DefaultValue = obj.Text
        'Me.tbl_TrnJurnaldetil_Credit.Columns("jurnaldetil_foreignrate").DefaultValue = obj.Text
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

        Me.uiTrnJurnal_PV_Advance_SetDefaultValueOfJurnaldetil_Debit(sender, cbo.ValueMember)
        Me.uiTrnJurnal_PV_Advance_SetDefaultValueOfJurnaldetil_Credit(sender, cbo.ValueMember)
        Me.tbl_TrnJurnaldetil_Debit.Columns("rekanan_name").DefaultValue = cbo.Text
        Me.tbl_TrnJurnaldetil_Credit.Columns("rekanan_name").DefaultValue = cbo.Text
    End Sub

    Private Sub obj_Budget_id_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles obj_Budget_id.SelectedIndexChanged
        Dim cbo As ComboBox = sender
        Me.uiTrnJurnal_PV_Advance_SetDefaultValueOfJurnaldetil_Debit(sender, cbo.ValueMember)
        Me.uiTrnJurnal_PV_Advance_SetDefaultValueOfJurnaldetil_Credit(sender, cbo.ValueMember)

        Me.tbl_TrnJurnaldetil_Debit.Columns("budget_name").DefaultValue = cbo.Text
        Me.tbl_TrnJurnaldetil_Credit.Columns("budget_name").DefaultValue = cbo.Text
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

    Private Sub btn_ChangeRate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ChangeRate.Click
        Dim rate As String
        Dim row As DataRow
        Dim selisih_idr, jumlah_idr, selisih_foreign, jumlah_foreign As Decimal
        Dim amountChangeSelisih As Decimal = 0

        '== ari
        Dim dt_accref1 As DataTable = New DataTable
        Dim dt_accref2 As DataTable = New DataTable
        Dim dt_accref3 As DataTable = New DataTable
        Dim dt_accref4 As DataTable = New DataTable
        dt_accref1.Clear()
        dt_accref2.Clear()
        dt_accref3.Clear()
        dt_accref4.Clear()
        Me.DataFill(dt_accref1, "act_selectAccRef_Detil", "accref_id = 3101") '8500011
        Me.DataFill(dt_accref2, "act_selectAccRef_Detil", "accref_id = 3102") '8001000
        Me.DataFill(dt_accref3, "act_selectAccRef_Detil", "accref_id = 3301") 'akun8009990 
        Me.DataFill(dt_accref4, "act_selectAccRef_Detil", "accref_id = 3302") '8509990
        Dim akun1 As String = dt_accref1.Rows(0).Item(0)
        Dim akun2 As String = dt_accref2.Rows(0).Item(0)
        Dim akun3 As String = dt_accref3.Rows(0).Item(0)
        Dim akun4 As String = dt_accref4.Rows(0).Item(0)
        '==
        '====end

        '3101 =	8500011
        '3102 =	8001000
        '3301 = akun8009990
        '3302 = 8509990

        rate = InputBox("Rate : ", "Rate", "", 100, 100)

        ' dv.RowFilter = "accref_id = 3101"
        'dv.Item(0).Row("acc_id")
        Dim rowChangesDebit As Byte = Me.tbl_TrnJurnaldetil_Debit.Compute("count(acc_id)", String.Format("acc_id = '{0}'", akun1))
        Dim sumChangesAmountIdrDebit As Decimal = clsUtil.IsDbNull(Me.tbl_TrnJurnaldetil_Debit.Compute("sum(jurnaldetil_idr)", String.Format("acc_id = '{0}'", akun1)), 0)

        'dv.RowFilter = "accref_id = 3102"
        'dv.Item(0).Row("acc_id")
        Dim rowChangesCredit As Byte = Me.tbl_TrnJurnaldetil_Credit.Compute("count(acc_id)", String.Format("acc_id = '{0}'", akun2))
        Dim sumChangesAmountIdrCredit As Decimal = clsUtil.IsDbNull(Me.tbl_TrnJurnaldetil_Credit.Compute("sum(jurnaldetil_idr)", String.Format("acc_id = '{0}'", akun2)), 0)


        If rate <> "" Then
            If IsNumeric(rate) = True Then
                Dim rate_dasar As Decimal = Me.DgvTrnJurnaldetil_Credit.CurrentRow.Cells("jurnaldetil_foreignrate").Value
                If rate_dasar > rate Then
                    If rowChangesDebit = 0 And rowChangesCredit = 0 Then
                        amountChangeSelisih = Math.Round(-Me.DgvTrnJurnaldetil_Credit.CurrentRow.Cells("jurnaldetil_foreign").Value * (CDec(rate_dasar - rate)), 0, MidpointRounding.AwayFromZero)
                    ElseIf rowChangesDebit = 0 And rowChangesCredit = 1 Then
                        amountChangeSelisih = -(Math.Round(Math.Round(Me.DgvTrnJurnaldetil_Credit.CurrentRow.Cells("jurnaldetil_foreign").Value * (CDec(rate_dasar - rate)), 0, MidpointRounding.AwayFromZero) + sumChangesAmountIdrCredit, 0, MidpointRounding.AwayFromZero))
                    ElseIf rowChangesDebit = 1 And rowChangesCredit = 0 Then
                        amountChangeSelisih = Math.Round(Math.Round((-Me.DgvTrnJurnaldetil_Credit.CurrentRow.Cells("jurnaldetil_foreign").Value * (CDec(rate_dasar - rate))), 0, MidpointRounding.AwayFromZero) + sumChangesAmountIdrDebit, 0, MidpointRounding.AwayFromZero)
                    Else
                        amountChangeSelisih = 0
                    End If
                Else
                    If rowChangesDebit = 0 And rowChangesCredit = 0 Then
                        amountChangeSelisih = Math.Round(Me.DgvTrnJurnaldetil_Credit.CurrentRow.Cells("jurnaldetil_foreign").Value * (CDec(rate - rate_dasar)), 0, MidpointRounding.AwayFromZero)
                    ElseIf rowChangesDebit = 0 And rowChangesCredit = 1 Then
                        amountChangeSelisih = Math.Round(Math.Round(Me.DgvTrnJurnaldetil_Credit.CurrentRow.Cells("jurnaldetil_foreign").Value * (CDec(rate - rate_dasar)), 0, MidpointRounding.AwayFromZero) - sumChangesAmountIdrCredit, 0, MidpointRounding.AwayFromZero)
                    ElseIf rowChangesDebit = 1 And rowChangesCredit = 0 Then
                        amountChangeSelisih = Math.Round(Math.Round(Me.DgvTrnJurnaldetil_Credit.CurrentRow.Cells("jurnaldetil_foreign").Value * (CDec(rate - rate_dasar)), 0, MidpointRounding.AwayFromZero) + sumChangesAmountIdrDebit, 0, MidpointRounding.AwayFromZero)
                    Else
                        amountChangeSelisih = 0
                    End If
                End If
            End If
        End If

        Dim i As Byte

        If amountChangeSelisih < 0 Then
            If rowChangesCredit = 0 Then
                If rowChangesDebit > 0 Then
                    ' dv.RowFilter = "accref_id = 3101"
                    For i = 0 To Me.tbl_TrnJurnaldetil_Debit.Rows.Count - 1
                        If Me.tbl_TrnJurnaldetil_Debit.Rows(i).RowState <> DataRowState.Deleted Then
                            If clsUtil.IsDbNull(Me.tbl_TrnJurnaldetil_Debit.Rows(i).Item("acc_id"), 0) = akun1 Then '8500011 Then
                                Me.tbl_TrnJurnaldetil_Debit.Rows(i).Delete()
                                Exit For
                            End If
                        End If
                    Next
                End If

                'dv.RowFilter = "accref_id = 3102"
                'dv.Item(0).Row("acc_id")
                row = Me.tbl_TrnJurnaldetil_Credit.NewRow
                row.Item("currency_id") = Me.DgvTrnJurnaldetil_Credit.CurrentRow.Cells("currency_id").Value
                row.Item("jurnaldetil_descr") = Me.DgvTrnJurnaldetil_Credit.CurrentRow.Cells("jurnaldetil_descr").Value
                row.Item("jurnaldetil_idr") = -amountChangeSelisih
                row.Item("jurnaldetil_foreign") = 0
                row.Item("jurnaldetil_foreignrate") = 0
                row.Item("acc_id") = akun2 '8001000
                row.Item("ref_id") = Me.DgvTrnJurnaldetil_Credit.CurrentRow.Cells("ref_id").Value
                row.Item("ref_line") = Me.DgvTrnJurnaldetil_Credit.CurrentRow.Cells("ref_line").Value
                row.Item("ref_budgetline") = 0
                row.Item("region_id") = 0
                row.Item("branch_id") = 0
                row.Item("strukturunit_id") = Me.DgvTrnJurnaldetil_Credit.CurrentRow.Cells("strukturunit_id").Value
                row.Item("rekanan_id") = Me.DgvTrnJurnaldetil_Credit.CurrentRow.Cells("rekanan_id").Value
                row.Item("rekanan_name") = Me.DgvTrnJurnaldetil_Debit.CurrentRow.Cells("rekanan_name").Value
                row.Item("budget_id") = 0
                row.Item("budget_name") = "-- PILIH --"
                row.Item("budgetdetil_id") = 0
                row.Item("budgetdetil_name") = "-- PILIH --"
                Me.tbl_TrnJurnaldetil_Credit.Rows.Add(row)
            Else
                'dv.RowFilter = "accref_id = 3102"
                'dv.Item(0).Row("acc_id")
                For i = 0 To Me.tbl_TrnJurnaldetil_Credit.Rows.Count - 1
                    If Me.tbl_TrnJurnaldetil_Credit.Rows(i).RowState <> DataRowState.Deleted Then
                        If clsUtil.IsDbNull(Me.tbl_TrnJurnaldetil_Credit.Rows(i).Item("acc_id"), 0) = akun2 Then '8001000 Then
                            Me.tbl_TrnJurnaldetil_Credit.Rows(i).Item("jurnaldetil_idr") = -amountChangeSelisih
                            Exit For
                        End If
                    End If
                Next
            End If

            Me.DgvTrnJurnaldetil_Credit.CurrentRow.Cells("jurnaldetil_foreignrate").Value = Math.Round(CDec(rate), 2, MidpointRounding.AwayFromZero)
            Me.DgvTrnJurnaldetil_Credit.CurrentRow.Cells("jurnaldetil_idr").Value = Math.Round(Me.DgvTrnJurnaldetil_Credit.CurrentRow.Cells("jurnaldetil_foreign").Value * rate, 0, MidpointRounding.AwayFromZero)

        ElseIf amountChangeSelisih > 0 Then
            If rowChangesDebit = 0 Then
                If rowChangesCredit > 0 Then
                    'dv.RowFilter = "accref_id = 3102"
                    'dv.Item(0).Row("acc_id")
                    For i = 0 To Me.tbl_TrnJurnaldetil_Credit.Rows.Count - 1
                        If Me.tbl_TrnJurnaldetil_Credit.Rows(i).RowState <> DataRowState.Deleted Then
                            If clsUtil.IsDbNull(Me.tbl_TrnJurnaldetil_Credit.Rows(i).Item("acc_id"), 0) = akun2 Then ' 8001000 Then
                                Me.tbl_TrnJurnaldetil_Credit.Rows(i).Delete()
                                Exit For
                            End If
                        End If
                    Next
                End If

                'dv.RowFilter = "accref_id = 3101"
                'dv.Item(0).Row("acc_id")
                row = Me.tbl_TrnJurnaldetil_Debit.NewRow
                row.Item("currency_id") = Me.DgvTrnJurnaldetil_Credit.CurrentRow.Cells("currency_id").Value
                row.Item("jurnaldetil_descr") = Me.DgvTrnJurnaldetil_Credit.CurrentRow.Cells("jurnaldetil_descr").Value
                row.Item("jurnaldetil_idr") = amountChangeSelisih
                row.Item("jurnaldetil_foreign") = 0
                row.Item("jurnaldetil_foreignrate") = 0
                row.Item("acc_id") = akun1 '8500011
                row.Item("ref_id") = Me.DgvTrnJurnaldetil_Credit.CurrentRow.Cells("ref_id").Value
                row.Item("ref_line") = Me.DgvTrnJurnaldetil_Credit.CurrentRow.Cells("ref_line").Value
                row.Item("ref_budgetline") = 0
                row.Item("region_id") = 0
                row.Item("branch_id") = 0
                row.Item("strukturunit_id") = Me.DgvTrnJurnaldetil_Credit.CurrentRow.Cells("strukturunit_id").Value
                row.Item("rekanan_id") = Me.DgvTrnJurnaldetil_Credit.CurrentRow.Cells("rekanan_id").Value
                row.Item("rekanan_name") = Me.DgvTrnJurnaldetil_Debit.CurrentRow.Cells("rekanan_name").Value
                row.Item("budget_id") = 0
                row.Item("budget_name") = "-- PILIH --"
                row.Item("budgetdetil_id") = 0
                row.Item("budgetdetil_name") = "-- PILIH --"
                Me.tbl_TrnJurnaldetil_Debit.Rows.Add(row)
            Else
                'dv.RowFilter = "accref_id = 3101"
                'dv.Item(0).Row("acc_id")
                For i = 0 To Me.tbl_TrnJurnaldetil_Debit.Rows.Count - 1
                    If Me.tbl_TrnJurnaldetil_Debit.Rows(i).RowState <> DataRowState.Deleted Then
                        If clsUtil.IsDbNull(Me.tbl_TrnJurnaldetil_Debit.Rows(i).Item("acc_id"), 0) = akun1 Then '8500011 Then
                            Me.tbl_TrnJurnaldetil_Debit.Rows(i).Item("jurnaldetil_idr") = amountChangeSelisih
                            Exit For
                        End If
                    End If
                Next
            End If
            Me.DgvTrnJurnaldetil_Credit.CurrentRow.Cells("jurnaldetil_foreignrate").Value = Math.Round(CDec(rate), 2, MidpointRounding.AwayFromZero)
            Me.DgvTrnJurnaldetil_Credit.CurrentRow.Cells("jurnaldetil_idr").Value = Math.Round(Math.Round(Me.DgvTrnJurnaldetil_Credit.CurrentRow.Cells("jurnaldetil_foreign").Value * rate, 2, MidpointRounding.AwayFromZero), 0, MidpointRounding.AwayFromZero)

        Else
            If rowChangesDebit > 0 Then
                'dv.RowFilter = "accref_id = 3101"
                'dv.Item(0).Row("acc_id")
                For i = 0 To Me.tbl_TrnJurnaldetil_Debit.Rows.Count - 1
                    If Me.tbl_TrnJurnaldetil_Debit.Rows(i).RowState <> DataRowState.Deleted Then
                        If clsUtil.IsDbNull(Me.tbl_TrnJurnaldetil_Debit.Rows(i).Item("acc_id"), 0) = akun1 Then '8500011 Then
                            Me.tbl_TrnJurnaldetil_Debit.Rows(i).Item("jurnaldetil_idr") = amountChangeSelisih
                            Exit For
                        End If
                    End If
                Next
            End If
            If rowChangesCredit > 0 Then
                'dv.RowFilter = "accref_id = 3102"
                'dv.Item(0).Row("acc_id")
                For i = 0 To Me.tbl_TrnJurnaldetil_Credit.Rows.Count - 1
                    If Me.tbl_TrnJurnaldetil_Credit.Rows(i).RowState <> DataRowState.Deleted Then
                        If clsUtil.IsDbNull(Me.tbl_TrnJurnaldetil_Credit.Rows(i).Item("acc_id"), 0) = akun2 Then '8001000 Then
                            Me.tbl_TrnJurnaldetil_Credit.Rows(i).Item("jurnaldetil_idr") = -amountChangeSelisih
                            Exit For
                        End If
                    End If
                Next
            End If
        End If

        Me.uiTrnJurnal_PV_Advance_RowCalculate(Me.DgvTrnJurnaldetil_Debit, Me.DgvTrnJurnaldetil_Credit, selisih_idr, jumlah_idr)
        Me.uiTrnJurnal_PV_Advance_RowCalculateForeign(Me.DgvTrnJurnaldetil_Debit, Me.DgvTrnJurnaldetil_Credit, selisih_foreign, jumlah_foreign)

        Me.obj_Selisih.Text = String.Format("{0:#,##0}", selisih_idr)
        Me.obj_Jumlah.Text = String.Format("{0:#,##0}", jumlah_idr)
        Me.obj_Selisih_Foreign.Text = String.Format("{0:#,##0.00}", selisih_foreign)
        Me.obj_Jumlah_Foreign.Text = String.Format("{0:#,##0.00}", jumlah_foreign)

        'akun3 = 3301 = akun8009990
        'akun4 = 3302 = 8509990
        'dv.RowFilter = "accref_id = 3302"
        'dv.Item(0).Row("acc_id")
        Dim rowDebit As Byte = Me.tbl_TrnJurnaldetil_Debit.Compute("count(acc_id)", String.Format("acc_id = '{0}' ", akun4)) '"acc_id = '8509990'"
        Dim sumAmountIdrDebit As Decimal = clsUtil.IsDbNull(Me.tbl_TrnJurnaldetil_Debit.Compute("sum(jurnaldetil_idr)", String.Format("acc_id = '{0}' ", akun4)), 0) '"acc_id = '8509990'"

        'dv.RowFilter = "accref_id = 3301"
        'dv.Item(0).Row("acc_id")
        Dim rowCredit As Byte = Me.tbl_TrnJurnaldetil_Credit.Compute("count(acc_id)", String.Format("acc_id = '{0}' ", akun3)) '"acc_id = 'akun8009990'"
        Dim sumAmountIdrCredit As Decimal = clsUtil.IsDbNull(Me.tbl_TrnJurnaldetil_Credit.Compute("sum(jurnaldetil_idr)", String.Format("acc_id = '{0}' ", akun3)), 0) '"acc_id = 'akun8009990'"

        Dim amountSelisih As Decimal = 0

        If selisih_idr > 0 Then
            If rowDebit = 0 And rowCredit = 0 Then
                amountSelisih = selisih_idr
            ElseIf rowDebit = 0 And rowCredit = 1 Then
                amountSelisih = Math.Round(selisih_idr + sumAmountIdrCredit, 0, MidpointRounding.AwayFromZero)
            ElseIf rowDebit = 1 And rowCredit = 0 Then
                amountSelisih = Math.Round(selisih_idr - sumAmountIdrDebit, 0, MidpointRounding.AwayFromZero)
            Else
                amountSelisih = 0
            End If
        ElseIf selisih_idr < 0 Then
            If rowDebit = 0 And rowCredit = 0 Then
                amountSelisih = selisih_idr
            ElseIf rowDebit = 0 And rowCredit = 1 Then
                amountSelisih = selisih_idr
            ElseIf rowDebit = 1 And rowCredit = 0 Then
                amountSelisih = Math.Round(selisih_idr - sumAmountIdrDebit, 0, MidpointRounding.AwayFromZero)
            Else
                amountSelisih = 0
            End If
        Else
            Exit Sub
        End If


        If amountSelisih > 0 Then
            If rowCredit = 0 Then
                If rowDebit > 0 Then
                    ' dv.RowFilter = "accref_id = 3302"
                    'dv.Item(0).Row("acc_id")
                    For i = 0 To Me.tbl_TrnJurnaldetil_Debit.Rows.Count - 1
                        If Me.tbl_TrnJurnaldetil_Debit.Rows(i).RowState <> DataRowState.Deleted Then
                            If clsUtil.IsDbNull(Me.tbl_TrnJurnaldetil_Debit.Rows(i).Item("acc_id"), 0) = akun4 Then '8509990 Then
                                Me.tbl_TrnJurnaldetil_Debit.Rows(i).Delete()
                                Exit For
                            End If
                        End If
                    Next
                End If

                'dv.RowFilter = "accref_id = 3301"
                'dv.Item(0).Row("acc_id")
                row = Me.tbl_TrnJurnaldetil_Credit.NewRow
                row.Item("currency_id") = Me.obj_Currency_id.SelectedValue
                row.Item("jurnaldetil_idr") = amountSelisih
                row.Item("jurnaldetil_foreign") = 0
                row.Item("jurnaldetil_foreignrate") = 0
                row.Item("acc_id") = String.Format("{0}", akun3) '"akun8009990"
                row.Item("ref_id") = String.Empty
                row.Item("ref_line") = 0
                row.Item("ref_budgetline") = 0
                row.Item("region_id") = 0
                row.Item("branch_id") = 0
                row.Item("strukturunit_id") = 0
                row.Item("rekanan_id") = Me.obj_Rekanan_id.SelectedValue
                row.Item("rekanan_name") = Trim(Me.obj_Rekanan_id.Text)
                row.Item("jurnaldetil_descr") = "Pendapatan"
                Me.tbl_TrnJurnaldetil_Credit.Rows.Add(row)
            Else
                'dv.RowFilter = "accref_id = 3301"
                'dv.Item(0).Row("acc_id")
                For i = 0 To Me.tbl_TrnJurnaldetil_Credit.Rows.Count - 1
                    If Me.tbl_TrnJurnaldetil_Credit.Rows(i).RowState <> DataRowState.Deleted Then
                        If clsUtil.IsDbNull(Me.tbl_TrnJurnaldetil_Credit.Rows(i).Item("acc_id"), 0) = akun3 Then 'akun8009990 Then
                            Me.tbl_TrnJurnaldetil_Credit.Rows(i).Item("jurnaldetil_idr") = amountSelisih
                            Exit For
                        End If
                    End If
                Next
            End If
        ElseIf amountSelisih < 0 Then

            If rowDebit = 0 Then
                If rowCredit > 0 Then
                    'dv.RowFilter = "accref_id = 3301"
                    'dv.Item(0).Row("acc_id")
                    For i = 0 To Me.tbl_TrnJurnaldetil_Credit.Rows.Count - 1
                        If Me.tbl_TrnJurnaldetil_Credit.Rows(i).RowState <> DataRowState.Deleted Then
                            If clsUtil.IsDbNull(Me.tbl_TrnJurnaldetil_Credit.Rows(i).Item("acc_id"), 0) = akun3 Then 'akun8009990 Then
                                Me.tbl_TrnJurnaldetil_Credit.Rows(i).Delete()
                                Exit For
                            End If
                        End If
                    Next
                End If
                'dv.RowFilter = "accref_id = 3302"
                'dv.Item(0).Row("acc_id")
                row = Me.tbl_TrnJurnaldetil_Debit.NewRow
                row.Item("currency_id") = Me.obj_Currency_id.SelectedValue
                row.Item("jurnaldetil_idr") = -amountSelisih
                row.Item("jurnaldetil_foreign") = 0
                row.Item("jurnaldetil_foreignrate") = 0
                row.Item("acc_id") = String.Format("{0}", akun4) '"8509990"
                row.Item("ref_id") = String.Empty
                row.Item("ref_line") = 0
                row.Item("ref_budgetline") = 0
                row.Item("region_id") = 0
                row.Item("branch_id") = 0
                row.Item("strukturunit_id") = 0
                row.Item("rekanan_id") = Me.obj_Rekanan_id.SelectedValue
                row.Item("rekanan_name") = Trim(Me.obj_Rekanan_id.Text)
                row.Item("jurnaldetil_descr") = "Biaya"
                Me.tbl_TrnJurnaldetil_Debit.Rows.Add(row)
            Else
                'dv.RowFilter = "accref_id = 3302"
                'dv.Item(0).Row("acc_id")
                For i = 0 To Me.tbl_TrnJurnaldetil_Debit.Rows.Count - 1
                    If Me.tbl_TrnJurnaldetil_Debit.Rows(i).RowState <> DataRowState.Deleted Then
                        If clsUtil.IsDbNull(Me.tbl_TrnJurnaldetil_Debit.Rows(i).Item("acc_id"), 0) = akun4 Then '8509990 Then
                            Me.tbl_TrnJurnaldetil_Debit.Rows(i).Item("jurnaldetil_idr") = -amountSelisih
                            Exit For
                        End If
                    End If
                Next
            End If
        Else
            If amountSelisih = 0 Then
                If rowDebit > 0 Then
                    'dv.RowFilter = "accref_id = 3302"
                    'dv.Item(0).Row("acc_id")
                    For i = 0 To Me.tbl_TrnJurnaldetil_Debit.Rows.Count - 1
                        If Me.tbl_TrnJurnaldetil_Debit.Rows(i).RowState <> DataRowState.Deleted Then
                            If clsUtil.IsDbNull(Me.tbl_TrnJurnaldetil_Debit.Rows(i).Item("acc_id"), 0) = akun4 Then '8509990 Then
                                Me.tbl_TrnJurnaldetil_Debit.Rows(i).Delete()
                                Exit For
                            End If
                        End If
                    Next
                End If
                If rowCredit > 0 Then
                    'dv.RowFilter = "accref_id = 3301"
                    'dv.Item(0).Row("acc_id")
                    For i = 0 To Me.tbl_TrnJurnaldetil_Credit.Rows.Count - 1
                        If Me.tbl_TrnJurnaldetil_Credit.Rows(i).RowState <> DataRowState.Deleted Then
                            If clsUtil.IsDbNull(Me.tbl_TrnJurnaldetil_Credit.Rows(i).Item("acc_id"), 0) = akun3 Then 'akun8009990 Then
                                Me.tbl_TrnJurnaldetil_Credit.Rows(i).Delete()
                                Exit For
                            End If
                        End If
                    Next
                End If
            Else
                If rowDebit > 0 Then
                    'dv.RowFilter = "accref_id = 3302"
                    'dv.Item(0).Row("acc_id")
                    For i = 0 To Me.tbl_TrnJurnaldetil_Debit.Rows.Count - 1
                        If Me.tbl_TrnJurnaldetil_Debit.Rows(i).RowState <> DataRowState.Deleted Then
                            If clsUtil.IsDbNull(Me.tbl_TrnJurnaldetil_Debit.Rows(i).Item("acc_id"), 0) = akun4 Then '8509990 Then
                                Me.tbl_TrnJurnaldetil_Debit.Rows(i).Item("jurnaldetil_idr") = -amountSelisih
                                Exit For
                            End If
                        End If
                    Next
                End If
                If rowCredit > 0 Then
                    'dv.RowFilter = "accref_id = 3301"
                    'dv.Item(0).Row("acc_id")
                    For i = 0 To Me.tbl_TrnJurnaldetil_Credit.Rows.Count - 1
                        If Me.tbl_TrnJurnaldetil_Credit.Rows(i).RowState <> DataRowState.Deleted Then
                            If clsUtil.IsDbNull(Me.tbl_TrnJurnaldetil_Credit.Rows(i).Item("acc_id"), 0) = akun3 Then 'akun8009990 Then
                                Me.tbl_TrnJurnaldetil_Credit.Rows(i).Item("jurnaldetil_idr") = amountSelisih
                                Exit For
                            End If
                        End If
                    Next
                End If
            End If

        End If

        Me.uiTrnJurnal_PV_Advance_RowCalculate(Me.DgvTrnJurnaldetil_Debit, Me.DgvTrnJurnaldetil_Credit, selisih_idr, jumlah_idr)
        Me.obj_Selisih.Text = String.Format("{0:#,##0}", selisih_idr)
        Me.obj_Jumlah.Text = String.Format("{0:#,##0}", jumlah_idr)


    End Sub

    Private Sub btn_ChangeRateTax_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ChangeRateTax.Click
        Dim tax_rate As String
        Dim row As DataRow
        Dim selisih_idr, jumlah_idr, selisih_foreign, jumlah_foreign As Decimal
        Dim amountChangeSelisih As Decimal = 0

        '=====tambahan ari 25/04/2012
        '== ari
        Dim dt_accref1 As DataTable = New DataTable
        Dim dt_accref2 As DataTable = New DataTable
        Dim dt_accref3 As DataTable = New DataTable
        Dim dt_accref4 As DataTable = New DataTable
        dt_accref1.Clear()
        dt_accref2.Clear()
        dt_accref3.Clear()
        dt_accref4.Clear()
        Me.DataFill(dt_accref1, "act_selectAccRef_Detil", "accref_id = 3201") '8500015
        Me.DataFill(dt_accref2, "act_selectAccRef_Detil", "accref_id = 3202") 'akun8002000
        Me.DataFill(dt_accref3, "act_selectAccRef_Detil", "accref_id = 3301") 'akun8009990
        Me.DataFill(dt_accref4, "act_selectAccRef_Detil", "accref_id = 3302") '8509990
        Dim akun1 As String = dt_accref1.Rows(0).Item(0)
        Dim akun2 As String = dt_accref2.Rows(0).Item(0)
        Dim akun3 As String = dt_accref3.Rows(0).Item(0)
        Dim akun4 As String = dt_accref4.Rows(0).Item(0)
        '==
        '====end

        '3201 =	8500015
        '3202 =	akun8002000 
        '====end


        tax_rate = InputBox("Rate : ", "Tax Rate", "", 100, 100)

        'dv.RowFilter = "accref_id = 3201"
        'dv.Item(0).Row("acc_id")
        Dim rowChangesDebit As Byte = Me.tbl_TrnJurnaldetil_Debit.Compute("count(acc_id)", String.Format("acc_id = '{0}'", akun1))  '"acc_id = '8500015'"
        Dim sumChangesAmountIdrDebit As Decimal = clsUtil.IsDbNull(Me.tbl_TrnJurnaldetil_Debit.Compute("sum(jurnaldetil_idr)", String.Format("acc_id = '{0}'", akun1)), 0) '"acc_id = '8500015'"

        'dv.RowFilter = "accref_id = 3202"
        'dv.Item(0).Row("acc_id")
        Dim rowChangesCredit As Byte = Me.tbl_TrnJurnaldetil_Credit.Compute("count(acc_id)", String.Format("acc_id = '{0}'", akun2)) '"acc_id = 'akun8002000'"
        Dim sumChangesAmountIdrCredit As Decimal = clsUtil.IsDbNull(Me.tbl_TrnJurnaldetil_Credit.Compute("sum(jurnaldetil_idr)", String.Format("acc_id = '{0}'", akun2)), 0) '"acc_id = 'akun8002000'"

        If tax_rate <> "" Then
            If IsNumeric(tax_rate) = True Then
                Dim rate_dasar As Decimal = Me.DgvTrnJurnaldetil_Credit.CurrentRow.Cells("jurnaldetil_foreignrate").Value
                If rate_dasar > tax_rate Then
                    If rowChangesDebit = 0 And rowChangesCredit = 0 Then
                        amountChangeSelisih = -Math.Round(Me.DgvTrnJurnaldetil_Credit.CurrentRow.Cells("jurnaldetil_foreign").Value * (CDec(rate_dasar - tax_rate)), 0, MidpointRounding.AwayFromZero)
                    ElseIf rowChangesDebit = 0 And rowChangesCredit = 1 Then
                        amountChangeSelisih = -(Math.Round(Math.Round(Me.DgvTrnJurnaldetil_Credit.CurrentRow.Cells("jurnaldetil_foreign").Value * (CDec(rate_dasar - tax_rate)), 0, MidpointRounding.AwayFromZero) + sumChangesAmountIdrCredit, 0, MidpointRounding.AwayFromZero))
                    ElseIf rowChangesDebit = 1 And rowChangesCredit = 0 Then
                        amountChangeSelisih = Math.Round(Math.Round(-(Me.DgvTrnJurnaldetil_Credit.CurrentRow.Cells("jurnaldetil_foreign").Value * (CDec(rate_dasar - tax_rate))), 0, MidpointRounding.AwayFromZero) + sumChangesAmountIdrDebit, 0, MidpointRounding.AwayFromZero)
                    Else
                        amountChangeSelisih = 0
                    End If
                Else
                    If rowChangesDebit = 0 And rowChangesCredit = 0 Then
                        amountChangeSelisih = Math.Round(Me.DgvTrnJurnaldetil_Credit.CurrentRow.Cells("jurnaldetil_foreign").Value * (CDec(tax_rate - rate_dasar)), 0, MidpointRounding.AwayFromZero)
                    ElseIf rowChangesDebit = 0 And rowChangesCredit = 1 Then
                        amountChangeSelisih = Math.Round(Math.Round(Me.DgvTrnJurnaldetil_Credit.CurrentRow.Cells("jurnaldetil_foreign").Value * (CDec(tax_rate - rate_dasar)), 0, MidpointRounding.AwayFromZero) - sumChangesAmountIdrCredit, 0, MidpointRounding.AwayFromZero)
                    ElseIf rowChangesDebit = 1 And rowChangesCredit = 0 Then
                        amountChangeSelisih = Math.Round(Math.Round(Me.DgvTrnJurnaldetil_Credit.CurrentRow.Cells("jurnaldetil_foreign").Value * (CDec(tax_rate - rate_dasar)), 0, MidpointRounding.AwayFromZero) + sumChangesAmountIdrDebit, 0, MidpointRounding.AwayFromZero)
                    Else
                        amountChangeSelisih = 0
                    End If
                End If
            End If
        End If

        Dim i As Byte

        If amountChangeSelisih < 0 Then
            If rowChangesCredit = 0 Then
                If rowChangesDebit > 0 Then
                    'dv.RowFilter = "accref_id = 3201"
                    'dv.Item(0).Row("acc_id")
                    For i = 0 To Me.tbl_TrnJurnaldetil_Debit.Rows.Count - 1
                        If Me.tbl_TrnJurnaldetil_Debit.Rows(i).RowState <> DataRowState.Deleted Then
                            If clsUtil.IsDbNull(Me.tbl_TrnJurnaldetil_Debit.Rows(i).Item("acc_id"), 0) = akun1 Then '8500015 Then
                                Me.tbl_TrnJurnaldetil_Debit.Rows(i).Delete()
                                Exit For
                            End If
                        End If
                    Next
                End If

                'dv.RowFilter = "accref_id = 3202"
                'dv.Item(0).Row("acc_id")

                row = Me.tbl_TrnJurnaldetil_Credit.NewRow
                row.Item("currency_id") = Me.DgvTrnJurnaldetil_Credit.CurrentRow.Cells("currency_id").Value
                row.Item("jurnaldetil_descr") = Me.DgvTrnJurnaldetil_Credit.CurrentRow.Cells("jurnaldetil_descr").Value
                row.Item("jurnaldetil_idr") = -amountChangeSelisih
                row.Item("jurnaldetil_foreign") = 0
                row.Item("jurnaldetil_foreignrate") = 0
                row.Item("acc_id") = akun2 'dv.Item(0).Row("acc_id") 'akun8002000
                row.Item("ref_id") = Me.DgvTrnJurnaldetil_Credit.CurrentRow.Cells("ref_id").Value
                row.Item("ref_line") = Me.DgvTrnJurnaldetil_Credit.CurrentRow.Cells("ref_line").Value
                row.Item("ref_budgetline") = 0
                row.Item("region_id") = 0
                row.Item("branch_id") = 0
                row.Item("strukturunit_id") = Me.DgvTrnJurnaldetil_Credit.CurrentRow.Cells("strukturunit_id").Value
                row.Item("rekanan_id") = Me.DgvTrnJurnaldetil_Credit.CurrentRow.Cells("rekanan_id").Value
                row.Item("rekanan_name") = Me.DgvTrnJurnaldetil_Debit.CurrentRow.Cells("rekanan_name").Value
                row.Item("budget_id") = 0
                row.Item("budget_name") = "-- PILIH --"
                row.Item("budgetdetil_id") = 0
                row.Item("budgetdetil_name") = "-- PILIH --"
                Me.tbl_TrnJurnaldetil_Credit.Rows.Add(row)
            Else
                'dv.RowFilter = "accref_id = 3202"
                'dv.Item(0).Row("acc_id")

                For i = 0 To Me.tbl_TrnJurnaldetil_Credit.Rows.Count - 1
                    If Me.tbl_TrnJurnaldetil_Credit.Rows(i).RowState <> DataRowState.Deleted Then
                        If clsUtil.IsDbNull(Me.tbl_TrnJurnaldetil_Credit.Rows(i).Item("acc_id"), 0) = akun2 Then ' akun8002000 Then
                            Me.tbl_TrnJurnaldetil_Credit.Rows(i).Item("jurnaldetil_idr") = -amountChangeSelisih
                            Exit For
                        End If
                    End If
                Next
            End If

            Me.DgvTrnJurnaldetil_Credit.CurrentRow.Cells("jurnaldetil_foreignrate").Value = Math.Round(CDec(tax_rate), 2, MidpointRounding.AwayFromZero)
            Me.DgvTrnJurnaldetil_Credit.CurrentRow.Cells("jurnaldetil_idr").Value = Math.Round(Me.DgvTrnJurnaldetil_Credit.CurrentRow.Cells("jurnaldetil_foreign").Value * tax_rate, 0, MidpointRounding.AwayFromZero)

        ElseIf amountChangeSelisih > 0 Then
            If rowChangesDebit = 0 Then
                If rowChangesCredit > 0 Then
                    'dv.RowFilter = "accref_id = 3202"
                    'dv.Item(0).Row("acc_id")
                    For i = 0 To Me.tbl_TrnJurnaldetil_Credit.Rows.Count - 1
                        If Me.tbl_TrnJurnaldetil_Credit.Rows(i).RowState <> DataRowState.Deleted Then
                            If clsUtil.IsDbNull(Me.tbl_TrnJurnaldetil_Credit.Rows(i).Item("acc_id"), 0) = akun2 Then 'akun8002000 Then
                                Me.tbl_TrnJurnaldetil_Credit.Rows(i).Delete()
                                Exit For
                            End If
                        End If
                    Next
                End If
                row = Me.tbl_TrnJurnaldetil_Debit.NewRow
                row.Item("currency_id") = Me.DgvTrnJurnaldetil_Credit.CurrentRow.Cells("currency_id").Value
                row.Item("jurnaldetil_descr") = Me.DgvTrnJurnaldetil_Credit.CurrentRow.Cells("jurnaldetil_descr").Value
                row.Item("jurnaldetil_idr") = amountChangeSelisih
                row.Item("jurnaldetil_foreign") = 0
                row.Item("jurnaldetil_foreignrate") = 0
                row.Item("acc_id") = akun1 '8500015
                row.Item("ref_id") = Me.DgvTrnJurnaldetil_Credit.CurrentRow.Cells("ref_id").Value
                row.Item("ref_line") = Me.DgvTrnJurnaldetil_Credit.CurrentRow.Cells("ref_line").Value
                row.Item("ref_budgetline") = 0
                row.Item("region_id") = 0
                row.Item("branch_id") = 0
                row.Item("strukturunit_id") = Me.DgvTrnJurnaldetil_Credit.CurrentRow.Cells("strukturunit_id").Value
                row.Item("rekanan_id") = Me.DgvTrnJurnaldetil_Credit.CurrentRow.Cells("rekanan_id").Value
                row.Item("rekanan_name") = Me.DgvTrnJurnaldetil_Debit.CurrentRow.Cells("rekanan_name").Value
                row.Item("budget_id") = 0
                row.Item("budget_name") = "-- PILIH --"
                row.Item("budgetdetil_id") = 0
                row.Item("budgetdetil_name") = "-- PILIH --"
                Me.tbl_TrnJurnaldetil_Debit.Rows.Add(row)
            Else
                'dv.RowFilter = "accref_id = 3201"
                'dv.Item(0).Row("acc_id")
                For i = 0 To Me.tbl_TrnJurnaldetil_Debit.Rows.Count - 1
                    If Me.tbl_TrnJurnaldetil_Debit.Rows(i).RowState <> DataRowState.Deleted Then
                        If clsUtil.IsDbNull(Me.tbl_TrnJurnaldetil_Debit.Rows(i).Item("acc_id"), 0) = akun1 Then '8500015 Then
                            Me.tbl_TrnJurnaldetil_Debit.Rows(i).Item("jurnaldetil_idr") = amountChangeSelisih
                            Exit For
                        End If
                    End If
                Next
            End If
            Me.DgvTrnJurnaldetil_Credit.CurrentRow.Cells("jurnaldetil_foreignrate").Value = Math.Round(CDec(tax_rate), 2, MidpointRounding.AwayFromZero)
            Me.DgvTrnJurnaldetil_Credit.CurrentRow.Cells("jurnaldetil_idr").Value = Math.Round(Me.DgvTrnJurnaldetil_Credit.CurrentRow.Cells("jurnaldetil_foreign").Value * tax_rate, 0, MidpointRounding.AwayFromZero)

        Else
            If rowChangesDebit > 0 Then
                'dv.RowFilter = "accref_id = 3201"
                'dv.Item(0).Row("acc_id")
                For i = 0 To Me.tbl_TrnJurnaldetil_Debit.Rows.Count - 1
                    If Me.tbl_TrnJurnaldetil_Debit.Rows(i).RowState <> DataRowState.Deleted Then
                        If clsUtil.IsDbNull(Me.tbl_TrnJurnaldetil_Debit.Rows(i).Item("acc_id"), 0) = akun1 Then ' 8500015 Then
                            Me.tbl_TrnJurnaldetil_Debit.Rows(i).Item("jurnaldetil_idr") = amountChangeSelisih
                            Exit For
                        End If
                    End If
                Next
            End If
            If rowChangesCredit > 0 Then
                'dv.RowFilter = "accref_id = 3202"
                'dv.Item(0).Row("acc_id")
                For i = 0 To Me.tbl_TrnJurnaldetil_Credit.Rows.Count - 1
                    If Me.tbl_TrnJurnaldetil_Credit.Rows(i).RowState <> DataRowState.Deleted Then
                        If clsUtil.IsDbNull(Me.tbl_TrnJurnaldetil_Credit.Rows(i).Item("acc_id"), 0) = akun2 Then 'akun8002000 Then
                            Me.tbl_TrnJurnaldetil_Credit.Rows(i).Item("jurnaldetil_idr") = -amountChangeSelisih
                            Exit For
                        End If
                    End If
                Next
            End If
        End If

        Me.uiTrnJurnal_PV_Advance_RowCalculate(Me.DgvTrnJurnaldetil_Debit, Me.DgvTrnJurnaldetil_Credit, selisih_idr, jumlah_idr)
        Me.uiTrnJurnal_PV_Advance_RowCalculateForeign(Me.DgvTrnJurnaldetil_Debit, Me.DgvTrnJurnaldetil_Credit, selisih_foreign, jumlah_foreign)

        Me.obj_Selisih.Text = String.Format("{0:#,##0}", selisih_idr)
        Me.obj_Jumlah.Text = String.Format("{0:#,##0}", jumlah_idr)
        Me.obj_Selisih_Foreign.Text = String.Format("{0:#,##0.00}", selisih_foreign)
        Me.obj_Jumlah_Foreign.Text = String.Format("{0:#,##0.00}", jumlah_foreign)

        '3301 =	akun8009990
        '3302 =	8509990
        '====================================
        'dv.RowFilter = "accref_id = 3302"
        'dv.Item(0).Row("acc_id")

        Dim rowDebit As Byte = Me.tbl_TrnJurnaldetil_Debit.Compute("count(acc_id)", String.Format("acc_id = '{0}'", akun4)) '"acc_id = '8509990'"
        Dim sumAmountIdrDebit As Decimal = clsUtil.IsDbNull(Me.tbl_TrnJurnaldetil_Debit.Compute("sum(jurnaldetil_idr)", String.Format("acc_id = '{0}'", akun4)), 0) '"acc_id = '8509990'"

        'dv.RowFilter = "accref_id = 3301"
        'dv.Item(0).Row("acc_id")
        Dim rowCredit As Byte = Me.tbl_TrnJurnaldetil_Credit.Compute("count(acc_id)", String.Format("acc_id = '{0}'", akun3)) '"acc_id = 'akun8009990'"
        Dim sumAmountIdrCredit As Decimal = clsUtil.IsDbNull(Me.tbl_TrnJurnaldetil_Credit.Compute("sum(jurnaldetil_idr)", String.Format("acc_id = '{0}'", akun3)), 0) '"acc_id = 'akun8009990'"

        Dim amountSelisih As Decimal = 0

        If selisih_idr > 0 Then
            If rowDebit = 0 And rowCredit = 0 Then
                amountSelisih = selisih_idr
            ElseIf rowDebit = 0 And rowCredit = 1 Then
                amountSelisih = Math.Round(selisih_idr + sumAmountIdrCredit, 0, MidpointRounding.AwayFromZero)
            ElseIf rowDebit = 1 And rowCredit = 0 Then
                amountSelisih = Math.Round(selisih_idr - sumAmountIdrDebit, 0, MidpointRounding.AwayFromZero)
            Else
                amountSelisih = 0
            End If
        ElseIf selisih_idr < 0 Then
            If rowDebit = 0 And rowCredit = 0 Then
                amountSelisih = selisih_idr
            ElseIf rowDebit = 0 And rowCredit = 1 Then
                amountSelisih = selisih_idr
            ElseIf rowDebit = 1 And rowCredit = 0 Then
                amountSelisih = Math.Round(selisih_idr - sumAmountIdrDebit, 0, MidpointRounding.AwayFromZero)
            Else
                amountSelisih = 0
            End If
        Else
            Exit Sub
        End If


        If amountSelisih > 0 Then
            If rowCredit = 0 Then
                If rowDebit > 0 Then
                    'dv.RowFilter = "accref_id = 3302"
                    'dv.Item(0).Row("acc_id")
                    For i = 0 To Me.tbl_TrnJurnaldetil_Debit.Rows.Count - 1
                        If Me.tbl_TrnJurnaldetil_Debit.Rows(i).RowState <> DataRowState.Deleted Then
                            If clsUtil.IsDbNull(Me.tbl_TrnJurnaldetil_Debit.Rows(i).Item("acc_id"), 0) = akun4 Then '8509990 Then
                                Me.tbl_TrnJurnaldetil_Debit.Rows(i).Delete()
                                Exit For
                            End If
                        End If
                    Next
                End If

                'dv.RowFilter = "accref_id = 3301"
                'dv.Item(0).Row("acc_id")
                row = Me.tbl_TrnJurnaldetil_Credit.NewRow
                row.Item("currency_id") = Me.obj_Currency_id.SelectedValue
                row.Item("jurnaldetil_idr") = amountSelisih
                row.Item("jurnaldetil_foreign") = 0
                row.Item("jurnaldetil_foreignrate") = 0
                row.Item("acc_id") = String.Format("{0}", akun3) '"akun8009990"
                row.Item("ref_id") = String.Empty
                row.Item("ref_line") = 0
                row.Item("ref_budgetline") = 0
                row.Item("region_id") = 0
                row.Item("branch_id") = 0
                row.Item("strukturunit_id") = 0
                row.Item("rekanan_id") = Me.obj_Rekanan_id.SelectedValue
                row.Item("rekanan_name") = Trim(Me.obj_Rekanan_id.Text)
                row.Item("jurnaldetil_descr") = "Pendapatan"
                Me.tbl_TrnJurnaldetil_Credit.Rows.Add(row)
            Else
                'dv.RowFilter = "accref_id = 3301"
                'dv.Item(0).Row("acc_id")
                For i = 0 To Me.tbl_TrnJurnaldetil_Credit.Rows.Count - 1
                    If Me.tbl_TrnJurnaldetil_Credit.Rows(i).RowState <> DataRowState.Deleted Then
                        If clsUtil.IsDbNull(Me.tbl_TrnJurnaldetil_Credit.Rows(i).Item("acc_id"), 0) = akun3 Then 'akun8009990 Then
                            Me.tbl_TrnJurnaldetil_Credit.Rows(i).Item("jurnaldetil_idr") = amountSelisih
                            Exit For
                        End If
                    End If
                Next
            End If
        ElseIf amountSelisih < 0 Then
            If rowDebit = 0 Then
                If rowCredit > 0 Then
                    'dv.RowFilter = "accref_id = 3301"
                    'dv.Item(0).Row("acc_id")
                    For i = 0 To Me.tbl_TrnJurnaldetil_Credit.Rows.Count - 1
                        If Me.tbl_TrnJurnaldetil_Credit.Rows(i).RowState <> DataRowState.Deleted Then
                            If clsUtil.IsDbNull(Me.tbl_TrnJurnaldetil_Credit.Rows(i).Item("acc_id"), 0) = akun3 Then 'akun8009990 Then
                                Me.tbl_TrnJurnaldetil_Credit.Rows(i).Delete()
                                Exit For
                            End If
                        End If
                    Next
                End If
                'dv.RowFilter = "accref_id = 3302"
                'dv.Item(0).Row("acc_id")

                row = Me.tbl_TrnJurnaldetil_Debit.NewRow
                row.Item("currency_id") = Me.obj_Currency_id.SelectedValue
                row.Item("jurnaldetil_idr") = -amountSelisih
                row.Item("jurnaldetil_foreign") = 0
                row.Item("jurnaldetil_foreignrate") = 0
                row.Item("acc_id") = String.Format("{0}", akun4) '"8509990"
                row.Item("ref_id") = String.Empty
                row.Item("ref_line") = 0
                row.Item("ref_budgetline") = 0
                row.Item("region_id") = 0
                row.Item("branch_id") = 0
                row.Item("strukturunit_id") = 0
                row.Item("rekanan_id") = Me.obj_Rekanan_id.SelectedValue
                row.Item("rekanan_name") = Trim(Me.obj_Rekanan_id.Text)
                row.Item("jurnaldetil_descr") = "Biaya"
                Me.tbl_TrnJurnaldetil_Debit.Rows.Add(row)
            Else
                'dv.RowFilter = "accref_id = 3302"
                'dv.Item(0).Row("acc_id")
                For i = 0 To Me.tbl_TrnJurnaldetil_Debit.Rows.Count - 1
                    If Me.tbl_TrnJurnaldetil_Debit.Rows(i).RowState <> DataRowState.Deleted Then
                        If clsUtil.IsDbNull(Me.tbl_TrnJurnaldetil_Debit.Rows(i).Item("acc_id"), 0) = akun4 Then '8509990 Then
                            Me.tbl_TrnJurnaldetil_Debit.Rows(i).Item("jurnaldetil_idr") = -amountSelisih
                            Exit For
                        End If
                    End If
                Next
            End If
        Else
            If amountSelisih = 0 Then
                If rowDebit > 0 Then
                    'dv.RowFilter = "accref_id = 3302"
                    'dv.Item(0).Row("acc_id")
                    For i = 0 To Me.tbl_TrnJurnaldetil_Debit.Rows.Count - 1
                        If Me.tbl_TrnJurnaldetil_Debit.Rows(i).RowState <> DataRowState.Deleted Then
                            If clsUtil.IsDbNull(Me.tbl_TrnJurnaldetil_Debit.Rows(i).Item("acc_id"), 0) = akun4 Then '8509990 Then
                                Me.tbl_TrnJurnaldetil_Debit.Rows(i).Delete()
                                Exit For
                            End If
                        End If
                    Next
                End If
                If rowCredit > 0 Then
                    'dv.RowFilter = "accref_id = 3301"
                    'dv.Item(0).Row("acc_id")
                    For i = 0 To Me.tbl_TrnJurnaldetil_Credit.Rows.Count - 1
                        If Me.tbl_TrnJurnaldetil_Credit.Rows(i).RowState <> DataRowState.Deleted Then
                            If clsUtil.IsDbNull(Me.tbl_TrnJurnaldetil_Credit.Rows(i).Item("acc_id"), 0) = akun3 Then 'akun8009990 Then
                                Me.tbl_TrnJurnaldetil_Credit.Rows(i).Delete()
                                Exit For
                            End If
                        End If
                    Next
                End If
            Else
                If rowDebit > 0 Then
                    'dv.RowFilter = "accref_id = 3302"
                    'dv.Item(0).Row("acc_id")
                    For i = 0 To Me.tbl_TrnJurnaldetil_Debit.Rows.Count - 1
                        If Me.tbl_TrnJurnaldetil_Debit.Rows(i).RowState <> DataRowState.Deleted Then
                            If clsUtil.IsDbNull(Me.tbl_TrnJurnaldetil_Debit.Rows(i).Item("acc_id"), 0) = akun4 Then '8509990 Then
                                Me.tbl_TrnJurnaldetil_Debit.Rows(i).Item("jurnaldetil_idr") = -amountSelisih
                                Exit For
                            End If
                        End If
                    Next
                End If
                If rowCredit > 0 Then
                    'dv.RowFilter = "accref_id = 3301"
                    'dv.Item(0).Row("acc_id")
                    For i = 0 To Me.tbl_TrnJurnaldetil_Credit.Rows.Count - 1
                        If Me.tbl_TrnJurnaldetil_Credit.Rows(i).RowState <> DataRowState.Deleted Then
                            If clsUtil.IsDbNull(Me.tbl_TrnJurnaldetil_Credit.Rows(i).Item("acc_id"), 0) = akun3 Then 'akun8009990 Then
                                Me.tbl_TrnJurnaldetil_Credit.Rows(i).Item("jurnaldetil_idr") = amountSelisih
                                Exit For
                            End If
                        End If
                    Next
                End If
            End If

        End If

        Me.uiTrnJurnal_PV_Advance_RowCalculate(Me.DgvTrnJurnaldetil_Debit, Me.DgvTrnJurnaldetil_Credit, selisih_idr, jumlah_idr)
        Me.obj_Selisih.Text = String.Format("{0:#,##0}", selisih_idr)
        Me.obj_Jumlah.Text = String.Format("{0:#,##0}", jumlah_idr)
    End Sub

    Private Sub btn_feeRate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_feeRate.Click
        Dim rate As String
        Dim row As DataRow
        Dim selisih_idr, jumlah_idr, selisih_foreign, jumlah_foreign As Decimal
        Dim amountChangeSelisih As Decimal = 0

        rate = InputBox("Rate : ", "Fee Rate", "", 100, 100)


        '== ari
        Dim dt_accref1 As DataTable = New DataTable
        Dim dt_accref2 As DataTable = New DataTable
        Dim dt_accref3 As DataTable = New DataTable
        Dim dt_accref4 As DataTable = New DataTable
        dt_accref1.Clear()
        dt_accref2.Clear()
        dt_accref3.Clear()
        dt_accref4.Clear()
        '3301	akun8009990
        '3302	8509990
        Me.DataFill(dt_accref1, "act_selectAccRef_Detil", "accref_id = 3101") '8500011
        Me.DataFill(dt_accref2, "act_selectAccRef_Detil", "accref_id = 3102") '8001000
        Me.DataFill(dt_accref3, "act_selectAccRef_Detil", "accref_id = 3301") 'akun8009990  	 
        Me.DataFill(dt_accref4, "act_selectAccRef_Detil", "accref_id = 3302") '8509990

        Dim akun1 As String = dt_accref1.Rows(0).Item(0)
        Dim akun2 As String = dt_accref2.Rows(0).Item(0)
        Dim akun3 As String = dt_accref3.Rows(0).Item(0)
        Dim akun4 As String = dt_accref4.Rows(0).Item(0)
        '==

        Dim rowChangesDebit As Byte = Me.tbl_TrnJurnaldetil_Debit.Compute("count(acc_id)", String.Format("acc_id={0}", akun1)) '"acc_id = '8500011'"
        Dim rowChangesCredit As Byte = Me.tbl_TrnJurnaldetil_Credit.Compute("count(acc_id)", String.Format("acc_id={0}", akun2)) '"acc_id = '8001000'"
        Dim sumChangesAmountIdrCredit As Decimal = clsUtil.IsDbNull(Me.tbl_TrnJurnaldetil_Credit.Compute("sum(jurnaldetil_idr)", String.Format("acc_id={0}", akun2)), 0) '"acc_id = '8001000'"
        Dim sumChangesAmountIdrDebit As Decimal = clsUtil.IsDbNull(Me.tbl_TrnJurnaldetil_Debit.Compute("sum(jurnaldetil_idr)", String.Format("acc_id={0}", akun1)), 0) '"acc_id = '8500011'"

        If rate <> "" Then
            If IsNumeric(rate) = True Then
                Dim rate_dasar As Decimal = Me.DgvTrnJurnaldetil_Debit.CurrentRow.Cells("jurnaldetil_foreignrate").Value
                If rate_dasar > rate Then
                    If rowChangesDebit = 0 And rowChangesCredit = 0 Then
                        amountChangeSelisih = Math.Round(Me.DgvTrnJurnaldetil_Debit.CurrentRow.Cells("jurnaldetil_foreign").Value * (CDec(rate_dasar - rate)), 0, MidpointRounding.AwayFromZero)
                    ElseIf rowChangesDebit = 0 And rowChangesCredit = 1 Then
                        amountChangeSelisih = (Math.Round(Math.Round(Me.DgvTrnJurnaldetil_Debit.CurrentRow.Cells("jurnaldetil_foreign").Value * (CDec(rate_dasar - rate)), 0, MidpointRounding.AwayFromZero) - sumChangesAmountIdrCredit, 0, MidpointRounding.AwayFromZero))
                    ElseIf rowChangesDebit = 1 And rowChangesCredit = 0 Then
                        amountChangeSelisih = Math.Round(Math.Round((Me.DgvTrnJurnaldetil_Debit.CurrentRow.Cells("jurnaldetil_foreign").Value * (CDec(rate_dasar - rate))), 0, MidpointRounding.AwayFromZero) + sumChangesAmountIdrDebit, 0, MidpointRounding.AwayFromZero)
                    Else
                        amountChangeSelisih = 0
                    End If
                Else
                    If rowChangesDebit = 0 And rowChangesCredit = 0 Then
                        amountChangeSelisih = Math.Round(-Me.DgvTrnJurnaldetil_Debit.CurrentRow.Cells("jurnaldetil_foreign").Value * (CDec(rate - rate_dasar)), 0, MidpointRounding.AwayFromZero)
                    ElseIf rowChangesDebit = 0 And rowChangesCredit = 1 Then
                        amountChangeSelisih = Math.Round(Math.Round(-Me.DgvTrnJurnaldetil_Debit.CurrentRow.Cells("jurnaldetil_foreign").Value * (CDec(rate - rate_dasar)), 0, MidpointRounding.AwayFromZero) - sumChangesAmountIdrCredit, 0, MidpointRounding.AwayFromZero)
                    ElseIf rowChangesDebit = 1 And rowChangesCredit = 0 Then
                        amountChangeSelisih = Math.Round(Math.Round(-Me.DgvTrnJurnaldetil_Debit.CurrentRow.Cells("jurnaldetil_foreign").Value * (CDec(rate - rate_dasar)), 0, MidpointRounding.AwayFromZero) + sumChangesAmountIdrDebit, 0, MidpointRounding.AwayFromZero)
                    Else
                        amountChangeSelisih = 0
                    End If
                End If
            End If
        End If

        Dim i As Byte

        If amountChangeSelisih < 0 Then
            If rowChangesCredit = 0 Then
                If rowChangesDebit > 0 Then
                    For i = 0 To Me.tbl_TrnJurnaldetil_Debit.Rows.Count - 1
                        If Me.tbl_TrnJurnaldetil_Debit.Rows(i).RowState <> DataRowState.Deleted Then
                            If clsUtil.IsDbNull(Me.tbl_TrnJurnaldetil_Debit.Rows(i).Item("acc_id"), 0) = akun1 Then '8500011 Then
                                Me.tbl_TrnJurnaldetil_Debit.Rows(i).Delete()
                                Exit For
                            End If
                        End If
                    Next
                End If
                row = Me.tbl_TrnJurnaldetil_Credit.NewRow
                row.Item("currency_id") = Me.DgvTrnJurnaldetil_Credit.CurrentRow.Cells("currency_id").Value
                row.Item("jurnaldetil_descr") = Me.DgvTrnJurnaldetil_Credit.CurrentRow.Cells("jurnaldetil_descr").Value
                row.Item("jurnaldetil_idr") = -amountChangeSelisih
                row.Item("jurnaldetil_foreign") = 0
                row.Item("jurnaldetil_foreignrate") = 0
                row.Item("acc_id") = akun2 '8001000
                row.Item("ref_id") = Me.DgvTrnJurnaldetil_Credit.CurrentRow.Cells("ref_id").Value
                row.Item("ref_line") = Me.DgvTrnJurnaldetil_Credit.CurrentRow.Cells("ref_line").Value
                row.Item("ref_budgetline") = 0
                row.Item("region_id") = 0
                row.Item("branch_id") = 0
                row.Item("strukturunit_id") = Me.DgvTrnJurnaldetil_Credit.CurrentRow.Cells("strukturunit_id").Value
                row.Item("rekanan_id") = Me.DgvTrnJurnaldetil_Credit.CurrentRow.Cells("rekanan_id").Value
                row.Item("rekanan_name") = Me.DgvTrnJurnaldetil_Debit.CurrentRow.Cells("rekanan_name").Value
                row.Item("budget_id") = 0
                row.Item("budget_name") = "-- PILIH --"
                row.Item("budgetdetil_id") = 0
                row.Item("budgetdetil_name") = "-- PILIH --"
                Me.tbl_TrnJurnaldetil_Credit.Rows.Add(row)
            Else
                For i = 0 To Me.tbl_TrnJurnaldetil_Credit.Rows.Count - 1
                    If Me.tbl_TrnJurnaldetil_Credit.Rows(i).RowState <> DataRowState.Deleted Then
                        If clsUtil.IsDbNull(Me.tbl_TrnJurnaldetil_Credit.Rows(i).Item("acc_id"), 0) = akun2 Then '8001000 Then
                            Me.tbl_TrnJurnaldetil_Credit.Rows(i).Item("jurnaldetil_idr") = -amountChangeSelisih
                            Exit For
                        End If
                    End If
                Next
            End If

            Me.DgvTrnJurnaldetil_Debit.CurrentRow.Cells("jurnaldetil_foreignrate").Value = Math.Round(CDec(rate), 2, MidpointRounding.AwayFromZero)
            Me.DgvTrnJurnaldetil_Debit.CurrentRow.Cells("jurnaldetil_idr").Value = Math.Round(Me.DgvTrnJurnaldetil_Debit.CurrentRow.Cells("jurnaldetil_foreign").Value * rate, 0, MidpointRounding.AwayFromZero)

        ElseIf amountChangeSelisih > 0 Then
            If rowChangesDebit = 0 Then
                If rowChangesCredit > 0 Then
                    For i = 0 To Me.tbl_TrnJurnaldetil_Credit.Rows.Count - 1
                        If Me.tbl_TrnJurnaldetil_Credit.Rows(i).RowState <> DataRowState.Deleted Then
                            If clsUtil.IsDbNull(Me.tbl_TrnJurnaldetil_Credit.Rows(i).Item("acc_id"), 0) = akun2 Then '8001000 Then
                                Me.tbl_TrnJurnaldetil_Credit.Rows(i).Delete()
                                Exit For
                            End If
                        End If
                    Next
                End If
                row = Me.tbl_TrnJurnaldetil_Debit.NewRow
                row.Item("currency_id") = Me.DgvTrnJurnaldetil_Credit.CurrentRow.Cells("currency_id").Value
                row.Item("jurnaldetil_descr") = Me.DgvTrnJurnaldetil_Credit.CurrentRow.Cells("jurnaldetil_descr").Value
                row.Item("jurnaldetil_idr") = amountChangeSelisih
                row.Item("jurnaldetil_foreign") = 0
                row.Item("jurnaldetil_foreignrate") = 0
                row.Item("acc_id") = akun1 '8500011
                row.Item("ref_id") = Me.DgvTrnJurnaldetil_Credit.CurrentRow.Cells("ref_id").Value
                row.Item("ref_line") = Me.DgvTrnJurnaldetil_Credit.CurrentRow.Cells("ref_line").Value
                row.Item("ref_budgetline") = 0
                row.Item("region_id") = 0
                row.Item("branch_id") = 0
                row.Item("strukturunit_id") = Me.DgvTrnJurnaldetil_Credit.CurrentRow.Cells("strukturunit_id").Value
                row.Item("rekanan_id") = Me.DgvTrnJurnaldetil_Credit.CurrentRow.Cells("rekanan_id").Value
                row.Item("rekanan_name") = Me.DgvTrnJurnaldetil_Debit.CurrentRow.Cells("rekanan_name").Value
                row.Item("budget_id") = 0
                row.Item("budget_name") = "-- PILIH --"
                row.Item("budgetdetil_id") = 0
                row.Item("budgetdetil_name") = "-- PILIH --"
                Me.tbl_TrnJurnaldetil_Debit.Rows.Add(row)
            Else
                For i = 0 To Me.tbl_TrnJurnaldetil_Debit.Rows.Count - 1
                    If Me.tbl_TrnJurnaldetil_Debit.Rows(i).RowState <> DataRowState.Deleted Then
                        If clsUtil.IsDbNull(Me.tbl_TrnJurnaldetil_Debit.Rows(i).Item("acc_id"), 0) = akun1 Then '8500011 Then
                            Me.tbl_TrnJurnaldetil_Debit.Rows(i).Item("jurnaldetil_idr") = amountChangeSelisih
                            Exit For
                        End If
                    End If
                Next
            End If
            Me.DgvTrnJurnaldetil_Debit.CurrentRow.Cells("jurnaldetil_foreignrate").Value = Math.Round(CDec(rate), 2, MidpointRounding.AwayFromZero)
            Me.DgvTrnJurnaldetil_Debit.CurrentRow.Cells("jurnaldetil_idr").Value = Math.Round(Me.DgvTrnJurnaldetil_Debit.CurrentRow.Cells("jurnaldetil_foreign").Value * rate, 0, MidpointRounding.AwayFromZero)

        Else
            If rowChangesDebit > 0 Then
                For i = 0 To Me.tbl_TrnJurnaldetil_Debit.Rows.Count - 1
                    If Me.tbl_TrnJurnaldetil_Debit.Rows(i).RowState <> DataRowState.Deleted Then
                        If clsUtil.IsDbNull(Me.tbl_TrnJurnaldetil_Debit.Rows(i).Item("acc_id"), 0) = akun1 Then '8500011 Then
                            Me.tbl_TrnJurnaldetil_Debit.Rows(i).Item("jurnaldetil_idr") = amountChangeSelisih
                            Exit For
                        End If
                    End If
                Next
            End If
            If rowChangesCredit > 0 Then
                For i = 0 To Me.tbl_TrnJurnaldetil_Credit.Rows.Count - 1
                    If Me.tbl_TrnJurnaldetil_Credit.Rows(i).RowState <> DataRowState.Deleted Then
                        If clsUtil.IsDbNull(Me.tbl_TrnJurnaldetil_Credit.Rows(i).Item("acc_id"), 0) = akun2 Then '8001000 Then
                            Me.tbl_TrnJurnaldetil_Credit.Rows(i).Item("jurnaldetil_idr") = -amountChangeSelisih
                            Exit For
                        End If
                    End If
                Next
            End If
        End If

        Me.uiTrnJurnal_PV_Advance_RowCalculate(Me.DgvTrnJurnaldetil_Debit, Me.DgvTrnJurnaldetil_Credit, selisih_idr, jumlah_idr)
        Me.uiTrnJurnal_PV_Advance_RowCalculateForeign(Me.DgvTrnJurnaldetil_Debit, Me.DgvTrnJurnaldetil_Credit, selisih_foreign, jumlah_foreign)

        Me.obj_Selisih.Text = String.Format("{0:#,##0}", selisih_idr)
        Me.obj_Jumlah.Text = String.Format("{0:#,##0}", jumlah_idr)
        Me.obj_Selisih_Foreign.Text = String.Format("{0:#,##0.00}", selisih_foreign)
        Me.obj_Jumlah_Foreign.Text = String.Format("{0:#,##0.00}", jumlah_foreign)

        Dim rowDebit As Byte = Me.tbl_TrnJurnaldetil_Debit.Compute("count(acc_id)", String.Format("acc_id='{0}'", akun4)) '"acc_id = '8509990'"
        Dim rowCredit As Byte = Me.tbl_TrnJurnaldetil_Credit.Compute("count(acc_id)", String.Format("acc_id='{0}'", akun3)) ' "acc_id = 'akun8009990'"
        Dim sumAmountIdrCredit As Decimal = clsUtil.IsDbNull(Me.tbl_TrnJurnaldetil_Credit.Compute("sum(jurnaldetil_idr)", String.Format("acc_id='{0}'", akun3)), 0) '"acc_id = 'akun8009990'"
        Dim sumAmountIdrDebit As Decimal = clsUtil.IsDbNull(Me.tbl_TrnJurnaldetil_Debit.Compute("sum(jurnaldetil_idr)", String.Format("acc_id='{0}'", akun4)), 0) '"acc_id = '8509990'"
        Dim amountSelisih As Decimal = 0

        If selisih_idr > 0 Then
            If rowDebit = 0 And rowCredit = 0 Then
                amountSelisih = selisih_idr
            ElseIf rowDebit = 0 And rowCredit = 1 Then
                amountSelisih = Math.Round(selisih_idr + sumAmountIdrCredit, 0, MidpointRounding.AwayFromZero)
            ElseIf rowDebit = 1 And rowCredit = 0 Then
                amountSelisih = Math.Round(selisih_idr - sumAmountIdrDebit, 0, MidpointRounding.AwayFromZero)
            Else
                amountSelisih = 0
            End If
        ElseIf selisih_idr < 0 Then
            If rowDebit = 0 And rowCredit = 0 Then
                amountSelisih = selisih_idr
            ElseIf rowDebit = 0 And rowCredit = 1 Then
                amountSelisih = selisih_idr
            ElseIf rowDebit = 1 And rowCredit = 0 Then
                amountSelisih = Math.Round(selisih_idr - sumAmountIdrDebit, 0, MidpointRounding.AwayFromZero)
            Else
                amountSelisih = 0
            End If
        Else
            Exit Sub
        End If


        If amountSelisih > 0 Then
            If rowCredit = 0 Then
                If rowDebit > 0 Then
                    For i = 0 To Me.tbl_TrnJurnaldetil_Debit.Rows.Count - 1
                        If Me.tbl_TrnJurnaldetil_Debit.Rows(i).RowState <> DataRowState.Deleted Then
                            If clsUtil.IsDbNull(Me.tbl_TrnJurnaldetil_Debit.Rows(i).Item("acc_id"), 0) = akun4 Then '8509990 Then
                                Me.tbl_TrnJurnaldetil_Debit.Rows(i).Delete()
                                Exit For
                            End If
                        End If
                    Next
                End If
                row = Me.tbl_TrnJurnaldetil_Credit.NewRow
                row.Item("currency_id") = Me.obj_Currency_id.SelectedValue
                row.Item("jurnaldetil_idr") = amountSelisih
                row.Item("jurnaldetil_foreign") = 0
                row.Item("jurnaldetil_foreignrate") = 0
                row.Item("acc_id") = String.Format("{0}", akun3) '"akun8009990"
                row.Item("ref_id") = String.Empty
                row.Item("ref_line") = 0
                row.Item("ref_budgetline") = 0
                row.Item("region_id") = 0
                row.Item("branch_id") = 0
                row.Item("strukturunit_id") = 0
                row.Item("rekanan_id") = Me.obj_Rekanan_id.SelectedValue
                row.Item("rekanan_name") = Trim(Me.obj_Rekanan_id.Text)
                row.Item("jurnaldetil_descr") = "Pendapatan"
                Me.tbl_TrnJurnaldetil_Credit.Rows.Add(row)
            Else
                For i = 0 To Me.tbl_TrnJurnaldetil_Credit.Rows.Count - 1
                    If Me.tbl_TrnJurnaldetil_Credit.Rows(i).RowState <> DataRowState.Deleted Then
                        If clsUtil.IsDbNull(Me.tbl_TrnJurnaldetil_Credit.Rows(i).Item("acc_id"), 0) = akun3 Then 'akun8009990 Then
                            Me.tbl_TrnJurnaldetil_Credit.Rows(i).Item("jurnaldetil_idr") = amountSelisih
                            Exit For
                        End If
                    End If
                Next
            End If
        ElseIf amountSelisih < 0 Then
            If rowDebit = 0 Then
                If rowCredit > 0 Then
                    For i = 0 To Me.tbl_TrnJurnaldetil_Credit.Rows.Count - 1
                        If Me.tbl_TrnJurnaldetil_Credit.Rows(i).RowState <> DataRowState.Deleted Then
                            If clsUtil.IsDbNull(Me.tbl_TrnJurnaldetil_Credit.Rows(i).Item("acc_id"), 0) = akun3 Then 'akun8009990 Then
                                Me.tbl_TrnJurnaldetil_Credit.Rows(i).Delete()
                                Exit For
                            End If
                        End If
                    Next
                End If
                row = Me.tbl_TrnJurnaldetil_Debit.NewRow
                row.Item("currency_id") = Me.obj_Currency_id.SelectedValue
                row.Item("jurnaldetil_idr") = -amountSelisih
                row.Item("jurnaldetil_foreign") = 0
                row.Item("jurnaldetil_foreignrate") = 0
                row.Item("acc_id") = String.Format("{0}", akun4) '"8509990"
                row.Item("ref_id") = String.Empty
                row.Item("ref_line") = 0
                row.Item("ref_budgetline") = 0
                row.Item("region_id") = 0
                row.Item("branch_id") = 0
                row.Item("strukturunit_id") = 0
                row.Item("rekanan_id") = Me.obj_Rekanan_id.SelectedValue
                row.Item("rekanan_name") = Trim(Me.obj_Rekanan_id.Text)
                row.Item("jurnaldetil_descr") = "Biaya"
                Me.tbl_TrnJurnaldetil_Debit.Rows.Add(row)
            Else
                For i = 0 To Me.tbl_TrnJurnaldetil_Debit.Rows.Count - 1
                    If Me.tbl_TrnJurnaldetil_Debit.Rows(i).RowState <> DataRowState.Deleted Then
                        If clsUtil.IsDbNull(Me.tbl_TrnJurnaldetil_Debit.Rows(i).Item("acc_id"), 0) = akun4 Then '8509990 Then
                            Me.tbl_TrnJurnaldetil_Debit.Rows(i).Item("jurnaldetil_idr") = -amountSelisih
                            Exit For
                        End If
                    End If
                Next
            End If
        Else
            If amountSelisih = 0 Then
                If rowDebit > 0 Then
                    For i = 0 To Me.tbl_TrnJurnaldetil_Debit.Rows.Count - 1
                        If Me.tbl_TrnJurnaldetil_Debit.Rows(i).RowState <> DataRowState.Deleted Then
                            If clsUtil.IsDbNull(Me.tbl_TrnJurnaldetil_Debit.Rows(i).Item("acc_id"), 0) = akun4 Then '8509990 Then
                                Me.tbl_TrnJurnaldetil_Debit.Rows(i).Delete()
                                Exit For
                            End If
                        End If
                    Next
                End If
                If rowCredit > 0 Then
                    For i = 0 To Me.tbl_TrnJurnaldetil_Credit.Rows.Count - 1
                        If Me.tbl_TrnJurnaldetil_Credit.Rows(i).RowState <> DataRowState.Deleted Then
                            If clsUtil.IsDbNull(Me.tbl_TrnJurnaldetil_Credit.Rows(i).Item("acc_id"), 0) = akun3 Then 'akun8009990 Then
                                Me.tbl_TrnJurnaldetil_Credit.Rows(i).Delete()
                                Exit For
                            End If
                        End If
                    Next
                End If
            Else
                If rowDebit > 0 Then
                    For i = 0 To Me.tbl_TrnJurnaldetil_Debit.Rows.Count - 1
                        If Me.tbl_TrnJurnaldetil_Debit.Rows(i).RowState <> DataRowState.Deleted Then
                            If clsUtil.IsDbNull(Me.tbl_TrnJurnaldetil_Debit.Rows(i).Item("acc_id"), 0) = akun4 Then '8509990 Then
                                Me.tbl_TrnJurnaldetil_Debit.Rows(i).Item("jurnaldetil_idr") = -amountSelisih
                                Exit For
                            End If
                        End If
                    Next
                End If
                If rowCredit > 0 Then
                    For i = 0 To Me.tbl_TrnJurnaldetil_Credit.Rows.Count - 1
                        If Me.tbl_TrnJurnaldetil_Credit.Rows(i).RowState <> DataRowState.Deleted Then
                            If clsUtil.IsDbNull(Me.tbl_TrnJurnaldetil_Credit.Rows(i).Item("acc_id"), 0) = akun3 Then 'akun8009990 Then
                                Me.tbl_TrnJurnaldetil_Credit.Rows(i).Item("jurnaldetil_idr") = amountSelisih
                                Exit For
                            End If
                        End If
                    Next
                End If
            End If

        End If

        Me.uiTrnJurnal_PV_Advance_RowCalculate(Me.DgvTrnJurnaldetil_Debit, Me.DgvTrnJurnaldetil_Credit, selisih_idr, jumlah_idr)
        Me.obj_Selisih.Text = String.Format("{0:#,##0}", selisih_idr)
        Me.obj_Jumlah.Text = String.Format("{0:#,##0}", jumlah_idr)

    End Sub

    Private Function cek_BankLinkBeforeSave() As Boolean
        Dim tbl_bankLink As DataTable = Me.tbl_TrnBankentrydetil
        Try
            If tbl_bankLink.Rows.Count > 0 Then
                Select Case tbl_bankLink.Rows(0).Item("bankentrydetil_dk")
                    Case "D"
                        ''
                        'jika posisi bank link di DEBET (PV) 
                        For i As Integer = 0 To Me.tbl_TrnJurnaldetil_Credit.Rows.Count - 1
                            'ambil nilai jika line didalam bank entry dan jurnal detil sama
                            If Me.tbl_TrnJurnaldetil_Credit.Rows(i).Item("jurnaldetil_line") = tbl_bankLink.Rows(0).Item("bankentrydetil_refline") _
                            And Me.tbl_TrnJurnaldetil_Credit.Rows(i).Item("jurnal_id") = tbl_bankLink.Rows(0).Item("bankentrydetil_refid") Then
                                'Cek nilai amount IDR di Jurnal Detil ada Perubahan ?
                                If Me.tbl_TrnJurnaldetil_Credit.Rows(i).Item("jurnaldetil_idr") <> tbl_bankLink.Rows(0).Item("bankentrydetil_idr") Then
                                    'tampilkan dialog informasi
                                    Dim hslDialog As String = MsgBox("Nilai Amount(IDR) Yang Ada di Jurnal(PV) " & Format(Me.tbl_TrnJurnaldetil_Credit.Rows(i).Item("jurnaldetil_idr"), "#,###.00") & vbCrLf & " Berbeda Dengan Nilai Amount(IDR) Bank Entry " & Format(tbl_bankLink.Rows(0).Item("bankentrydetil_idr"), "#,###.00") & vbCrLf & " Apakah Proses Tetap Di Lanjutkan ?", MsgBoxStyle.OkCancel, " * Konfirmasi Nilai Amount * ")
                                    'jika proses tetap dilanjutkan
                                    If hslDialog = DialogResult.OK Then
                                        Me.Cursor = Cursors.WaitCursor
                                        Me.uiTrnJurnal_PV_Advance_Save()
                                        Me.Cursor = Cursors.Arrow
                                        Return MyBase.btnSave_Click()
                                    Else
                                        Return False
                                    End If
                                Else
                                    Me.Cursor = Cursors.WaitCursor
                                    Me.uiTrnJurnal_PV_Advance_Save()
                                    Me.Cursor = Cursors.Arrow
                                    Return MyBase.btnSave_Click()
                                End If
                                'Else
                                '    'jika gak cocok
                                '    Return False
                            End If
                        Next
                        ''


                    Case "K"
                        'jika posisi bank link di KREDIT (OR)
                        For i As Integer = 0 To Me.tbl_TrnJurnaldetil_Debit.Rows.Count - 1
                            'ambil nilai jika line didalam bank entry dan jurnal detil sama
                            If Me.tbl_TrnJurnaldetil_Debit.Rows(i).Item("jurnaldetil_line") = tbl_bankLink.Rows(0).Item("bankentrydetil_refline") _
                            And Me.tbl_TrnJurnaldetil_Debit.Rows(i).Item("jurnal_id") = tbl_bankLink.Rows(0).Item("bankentrydetil_refid") Then
                                'Cek nilai amount IDR di Jurnal Detil ada Perubahan ?
                                If Me.tbl_TrnJurnaldetil_Debit.Rows(i).Item("jurnaldetil_idr") <> tbl_bankLink.Rows(0).Item("bankentrydetil_idr") Then
                                    'tampilkan dialog informasi
                                    Dim hslDialog As String = MsgBox("Nilai Amount(IDR) Yang Ada di Jurnal(PV) " & Format(Me.tbl_TrnJurnaldetil_Debit.Rows(i).Item("jurnaldetil_idr"), "#,###.00") & vbCrLf & " Berbeda Dengan Nilai Amount(IDR) Bank Entry " & Format(tbl_bankLink.Rows(0).Item("bankentrydetil_idr"), "#,###.00") & vbCrLf & " Apakah Proses Tetap Di Lanjutkan ?", MsgBoxStyle.OkCancel, " * Konfirmasi Nilai Amount * ")
                                    'jika proses tetap dilanjutkan
                                    If hslDialog = DialogResult.OK Then
                                        Me.Cursor = Cursors.WaitCursor
                                        Me.uiTrnJurnal_PV_Advance_Save()
                                        Me.Cursor = Cursors.Arrow
                                        Return MyBase.btnSave_Click()
                                    Else
                                        Return False
                                    End If
                                Else
                                    Me.Cursor = Cursors.WaitCursor
                                    Me.uiTrnJurnal_PV_Advance_Save()
                                    Me.Cursor = Cursors.Arrow
                                    Return MyBase.btnSave_Click()
                                End If
                                'Else
                                'jika gak cocok
                                'return False
                            End If
                        Next
                End Select

            Else
                Me.Cursor = Cursors.WaitCursor
                Me.uiTrnJurnal_PV_Advance_Save()
                Me.Cursor = Cursors.Arrow
                Return MyBase.btnSave_Click()
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information)
        End Try
    End Function

    '========================ADD PTS 20130711==================
    Private Function uiTrnJurnal_PV_Advance_OpenRowContract(ByVal jurnal_id As String, ByVal dbConn As OleDb.OleDbConnection) As Boolean
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        dbCmd = New OleDb.OleDbCommand("act_TrnJurnalDetil_PV_Select_ContractArtis", dbConn)
        dbCmd.Parameters.Add("@jurnal_id", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@jurnal_id").Value = jurnal_id
        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)

        Me.tbl_TrnContract.Clear()

        Try
            dbDA.Fill(Me.tbl_TrnContract)
            'Dim tbl As DataTable = New DataTable
            'dbDA.Fill(tbl)
            'DataFill(tbl_TrnContract, "act_TrnJurnalDetil_PV_Select_ContractArtis", jurnal_id)
            'Me.dgvTrnBankTransfer.DataSource = Me.tbl_TrnContract
        Catch ex As Exception
            Throw New Exception(mUiName & ": uiTrnJurnal_PV_List_Advance_OpenRowContract()" & vbCrLf & ex.Message)
        End Try

    End Function
    '=============================================================

    Private Function uiTrnJurnal_PV_Advance_FormChanges(ByVal messageNotify As Boolean) As Boolean
        Dim tbl_TrnJurnaldetil_Credit_Changes As DataTable

        Me.BindingContext(Me.tbl_TrnJurnaldetil_Credit).EndCurrentEdit()

        tbl_TrnJurnaldetil_Credit_Changes = Me.tbl_TrnJurnaldetil_Credit.GetChanges()

        If tbl_TrnJurnaldetil_Credit_Changes IsNot Nothing Then
            Dim res As MsgBoxResult

            If messageNotify = True Then
                res = MsgBox("Data has been changed. Are you sure to save data ?", MsgBoxStyle.OkCancel + MsgBoxStyle.Exclamation)
            Else
                res = MsgBoxResult.Ok
            End If

            If res = MsgBoxResult.Ok Then
                Me.Cursor = Cursors.WaitCursor
                If Me.uiTrnJurnal_PV_Advance_FormError() Then
                    Me.Cursor = Cursors.Default
                    Return True
                End If

                Return Not cek_BankLinkBeforeSave()

                Me.Cursor = Cursors.Default
            Else
                Return True
            End If
        End If
    End Function

    Private Sub AddInvoiceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddInvoiceToolStripMenuItem.Click
        If uiTrnJurnal_PV_Advance_FormChanges(True) Then
            Exit Sub
        End If
        DialogOpen_Reference_List_RD()
    End Sub

    'tambahan aji
    Private Function DialogOpen_Reference_List_RD() As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dlg As New dlgTrnJurnalAddInvoice_selectRD(Me.DSN, tbl_MstRekananGrid, Me._CHANNEL)

        Dim retObj As Object
        Dim retData As Collection
        Dim tblJDetil As DataTable
        Dim rowselected As DataGridViewRow = DgvTrnJurnaldetil_Credit.CurrentRow

        retObj = dlg.OpenDialog(Me, rowselected, tbl_trnJurnalRefTandaTerima)

        Dim cookie As Byte() = Nothing

        If retObj IsNot Nothing Then

            retData = CType(retObj, Collection)
            tblJDetil = CType(retData.Item("tblRefTandaTerima"), DataTable)
            jurnalDetilReferenceTandaTerima_save(tblJDetil)

            Try
                dbConn.Open()
                clsApplicationRole.SetAppRole(dbConn, cookie)
                Me.uiTrnJurnal_PV_Advance_OpenRowInvoice(Me._CHANNEL, Me.obj_Jurnal_id.Text, dbConn)
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                clsApplicationRole.UnsetAppRole(dbConn, cookie)
                dbConn.Close()
            End Try

        End If

    End Function

    Private Function jurnalDetilReferenceTandaTerima_save(ByVal objTbl As DataTable) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbCmdInsert As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        ' Save data: transaksi_jurnaldetil
        dbCmdInsert = New OleDb.OleDbCommand("act_TrnJurnalReferenceTandaTerima_Insert", dbConn)
        dbCmdInsert.CommandType = CommandType.StoredProcedure
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_id", System.Data.OleDb.OleDbType.VarWChar, 24, "jurnal_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_line", System.Data.OleDb.OleDbType.Integer, 4, "jurnal_line"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@tandaterima_id", System.Data.OleDb.OleDbType.VarWChar, 24, "tandaterima_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@tandaterima_line", System.Data.OleDb.OleDbType.Integer, 4, "tandaterima_line"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@tandaterima_invoiceno", System.Data.OleDb.OleDbType.VarWChar, 200, "tandaterima_invoiceno"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@currency_id", System.Data.OleDb.OleDbType.Integer, 3, "currency_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@amount_foreign", System.Data.OleDb.OleDbType.Decimal, 8, "amount_foreign"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@amount_foreignrate", System.Data.OleDb.OleDbType.Decimal, 8, "amount_foreignrate"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@amount_idr", System.Data.OleDb.OleDbType.Decimal, 8, "amount_idr"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@create_by", System.Data.OleDb.OleDbType.VarWChar, 24))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@create_dt", System.Data.OleDb.OleDbType.Date))

        dbCmdInsert.Parameters("@create_by").Value = Me.UserName
        dbCmdInsert.Parameters("@create_dt").Value = Now.Date

        dbDA = New OleDb.OleDbDataAdapter
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

    End Function

    Private Function checkAccountIsBankOrClearing(ByVal acc_id As String) As Boolean
        Dim criteria As String = " (accref_id = '4620' or accref_id='7000') AND acc_id = '" + acc_id + "'" '4620 = Bank Account (ALL) 7000 = All Clearing PPh
        Dim tbl_acc As New DataTable
        Me.DataFill(tbl_acc, "ms_MstAccrefdetil_Select", criteria)
        If tbl_acc.Rows.Count > 0 Then
            'tambahan aji
            If Me.DgvTrnJurnal.Rows(Me.DgvTrnJurnal.CurrentRow.Index).Cells("jurnal_isposted").Value = True Then
                Return False
            Else
                Return True
            End If
            'end tambahan
        End If
        Return False
    End Function

    Private Function uiTrnJurnal_PV_List_AP_DeleteRefTandaTerima(ByRef jurnal_id As Object, ByVal objTbl As DataTable, ByVal MasterDataState As System.Data.DataRowState) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbCmdDelete As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        dbCmdDelete = New OleDb.OleDbCommand("act_TrnJurnalReferenceTandaTerima_Delete", dbConn)
        dbCmdDelete.CommandType = CommandType.StoredProcedure
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_id", System.Data.OleDb.OleDbType.VarWChar, 24))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_line", System.Data.OleDb.OleDbType.Integer, 4, "jurnal_line"))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@tandaterima_id", System.Data.OleDb.OleDbType.VarWChar, 24, "tandaterima_id"))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@tandaterima_line", System.Data.OleDb.OleDbType.Integer, 4, "tandaterima_line"))
        dbCmdDelete.Parameters("@jurnal_id").Value = jurnal_id

        dbDA = New OleDb.OleDbDataAdapter
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

    Private Sub DgvTrnJurnaldetil_Debit_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DgvTrnJurnaldetil_Debit.CellFormatting
        If Me.tbl_TrnJurnal_Temp.Rows.Count > 0 Then
            If Me.tbl_TrnJurnal_Temp.Rows(0).Item("jurnal_isposted") = 0 Then
                If clsUtil.IsDbNull(DgvTrnJurnaldetil_Debit.Rows(e.RowIndex).Cells("ref_id").Value, "") <> "" Then
                    'Me.DgvTrnJurnaldetil_Debit.Rows(e.RowIndex).Cells("jurnaldetil_idr").ReadOnly = True
                    Me.DgvTrnJurnaldetil_Debit.Rows(e.RowIndex).Cells("jurnaldetil_foreign").ReadOnly = True
                    'Me.DgvTrnJurnaldetil_Debit.Rows(e.RowIndex).Cells("jurnaldetil_idr").Style.BackColor = Color.LightYellow
                    Me.DgvTrnJurnaldetil_Debit.Rows(e.RowIndex).Cells("jurnaldetil_foreign").Style.BackColor = Color.LightYellow
                Else
                    'Me.DgvTrnJurnaldetil_Debit.Rows(e.RowIndex).Cells("jurnaldetil_idr").ReadOnly = False
                    Me.DgvTrnJurnaldetil_Debit.Rows(e.RowIndex).Cells("jurnaldetil_foreign").ReadOnly = False
                    'Me.DgvTrnJurnaldetil_Debit.Rows(e.RowIndex).Cells("jurnaldetil_idr").Style.BackColor = Color.White
                    Me.DgvTrnJurnaldetil_Debit.Rows(e.RowIndex).Cells("jurnaldetil_foreign").Style.BackColor = Color.White
                End If
            End If
        Else
            If clsUtil.IsDbNull(DgvTrnJurnaldetil_Debit.Rows(e.RowIndex).Cells("ref_id").Value, "") <> "" Then
                'Me.DgvTrnJurnaldetil_Debit.Rows(e.RowIndex).Cells("jurnaldetil_idr").ReadOnly = True
                Me.DgvTrnJurnaldetil_Debit.Rows(e.RowIndex).Cells("jurnaldetil_foreign").ReadOnly = True
                'Me.DgvTrnJurnaldetil_Debit.Rows(e.RowIndex).Cells("jurnaldetil_idr").Style.BackColor = Color.LightYellow
                Me.DgvTrnJurnaldetil_Debit.Rows(e.RowIndex).Cells("jurnaldetil_foreign").Style.BackColor = Color.LightYellow
            Else
                'Me.DgvTrnJurnaldetil_Debit.Rows(e.RowIndex).Cells("jurnaldetil_idr").ReadOnly = False
                Me.DgvTrnJurnaldetil_Debit.Rows(e.RowIndex).Cells("jurnaldetil_foreign").ReadOnly = False
                'Me.DgvTrnJurnaldetil_Debit.Rows(e.RowIndex).Cells("jurnaldetil_idr").Style.BackColor = Color.White
                Me.DgvTrnJurnaldetil_Debit.Rows(e.RowIndex).Cells("jurnaldetil_foreign").Style.BackColor = Color.White
            End If
        End If

    End Sub

    '============ ADD PTS 20150528 =================
    Private Sub btnSettingPrinterGiro_Click(sender As Object, e As EventArgs) Handles btnSettingPrinterGiro.Click
        Dim printernamesetting As String
        Try
            printernamesetting = My.Computer.FileSystem.ReadAllText("\Gamba_cekgiro_printersetting.txt")
            Dim dlgsettingprinter As dlgSettingPrinterGiroCek = New dlgSettingPrinterGiroCek(printernamesetting)
            dlgsettingprinter.ShowDialog()
            'PrinterName = "HP LaserJet 400 M401n (172.16.52.200)"
            'PrinterName = "EPSON FX-890 Ver 2.0"
        Catch ex As Exception

            Dim filepath As String = "\Gamba_cekgiro_printersetting.txt"
            If Not System.IO.File.Exists(filepath) Then
                System.IO.File.Create(filepath).Dispose()
            End If

            Dim dialog As dlgSettingPrinterGiroCek = New dlgSettingPrinterGiroCek(String.Empty)
            dialog.ShowDialog()

        End Try
    End Sub

    Private Sub DgvTrnJurnaldetil_Credit_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles DgvTrnJurnaldetil_Credit.CellPainting
        If e.ColumnIndex = 29 AndAlso e.RowIndex >= 0 Then
            e.Paint(e.CellBounds, DataGridViewPaintParts.All)
            e.Graphics.DrawImage(My.Resources.printer_2, e.CellBounds.Left + 10, e.CellBounds.Top + 2, 16, 16)
            e.Handled = True
        End If
    End Sub
    '===============================================================

    Private Sub AddInvoiceToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles AddInvoiceToolStripMenuItem1.Click
        If uiTrnJurnal_PV_Advance_FormChanges(True) Then
            Exit Sub
        End If
        DialogOpen_Reference_List_RD()
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        Dim idr As String
        Dim row As DataRow
        Dim selisih_idr, jumlah_idr, selisih_foreign, jumlah_foreign As Decimal
        Dim amountChangeSelisih As Decimal = 0

        idr = InputBox("Amount(IDR) : ", "Amount(IDR)", "", 100, 100)

        '=====tambahan ari 25/04/2012
        '== ari
        Dim dt_accref1 As DataTable = New DataTable
        Dim dt_accref2 As DataTable = New DataTable
        Dim dt_accref3 As DataTable = New DataTable
        Dim dt_accref4 As DataTable = New DataTable
        dt_accref1.Clear()
        dt_accref2.Clear()
        dt_accref3.Clear()
        dt_accref4.Clear()
        Me.DataFill(dt_accref1, "act_selectAccRef_Detil", "accref_id = 3101") '8500011
        Me.DataFill(dt_accref2, "act_selectAccRef_Detil", "accref_id = 3102") '8001000
        Me.DataFill(dt_accref3, "act_selectAccRef_Detil", "accref_id = 3301") 'akun8009990
        Me.DataFill(dt_accref4, "act_selectAccRef_Detil", "accref_id = 3302") 'akun8509990
        Dim akun1 As String = dt_accref1.Rows(0).Item(0)
        Dim akun2 As String = dt_accref2.Rows(0).Item(0)
        Dim akun3 As String = dt_accref3.Rows(0).Item(0)
        Dim akun4 As String = dt_accref4.Rows(0).Item(0)
        '==
        '====end

        Dim rowChangesDebit As Byte = Me.tbl_TrnJurnaldetil_Debit.Compute("count(acc_id)", String.Format("acc_id='{0}'", akun1)) '"acc_id = '8500011'"
        Dim rowChangesCredit As Byte = Me.tbl_TrnJurnaldetil_Credit.Compute("count(acc_id)", String.Format("acc_id='{0}'", akun2)) '"acc_id = '8001000'"
        Dim sumChangesAmountIdrCredit As Decimal = clsUtil.IsDbNull(Me.tbl_TrnJurnaldetil_Credit.Compute("sum(jurnaldetil_idr)", String.Format("acc_id='{0}'", akun2)), 0) '"acc_id = '8001000'"
        Dim sumChangesAmountIdrDebit As Decimal = clsUtil.IsDbNull(Me.tbl_TrnJurnaldetil_Debit.Compute("sum(jurnaldetil_idr)", String.Format("acc_id='{0}'", akun1)), 0) '"acc_id = '8500011'"

        If idr <> "" Then
            If IsNumeric(idr) = True Then
                Me.DgvTrnJurnaldetil_Credit.CurrentRow.Cells("branch_id").Value = 1 ' UNTUK TANDA UBAH DARI RATE TAX ATAU AMOUNT IDR TAX
                Dim idr_dasar As Decimal = Me.DgvTrnJurnaldetil_Credit.CurrentRow.Cells("jurnaldetil_idr").Value
                If idr_dasar > idr Then
                    If rowChangesDebit = 0 And rowChangesCredit = 0 Then
                        amountChangeSelisih = Math.Round(-(CDec(idr_dasar - idr)), 0, MidpointRounding.AwayFromZero)
                    ElseIf rowChangesDebit = 0 And rowChangesCredit = 1 Then
                        amountChangeSelisih = -(Math.Round(Math.Round(CDec(idr_dasar - idr), 0, MidpointRounding.AwayFromZero) + sumChangesAmountIdrCredit, 0, MidpointRounding.AwayFromZero))
                    ElseIf rowChangesDebit = 1 And rowChangesCredit = 0 Then
                        amountChangeSelisih = Math.Round(Math.Round((-(CDec(idr_dasar - idr))), 0, MidpointRounding.AwayFromZero) + sumChangesAmountIdrDebit, 0, MidpointRounding.AwayFromZero)
                    Else
                        amountChangeSelisih = 0
                    End If
                Else
                    If rowChangesDebit = 0 And rowChangesCredit = 0 Then
                        amountChangeSelisih = Math.Round((CDec(idr - idr_dasar)), 0, MidpointRounding.AwayFromZero)
                    ElseIf rowChangesDebit = 0 And rowChangesCredit = 1 Then
                        amountChangeSelisih = Math.Round(Math.Round((CDec(idr - idr_dasar)), 0, MidpointRounding.AwayFromZero) - sumChangesAmountIdrCredit, 0, MidpointRounding.AwayFromZero)
                    ElseIf rowChangesDebit = 1 And rowChangesCredit = 0 Then
                        amountChangeSelisih = Math.Round(Math.Round((CDec(idr - idr_dasar)), 0, MidpointRounding.AwayFromZero) + sumChangesAmountIdrDebit, 0, MidpointRounding.AwayFromZero)
                    Else
                        amountChangeSelisih = 0
                    End If
                End If
            End If
        End If

        Dim i As Byte

        If amountChangeSelisih < 0 Then
            If rowChangesCredit = 0 Then
                If rowChangesDebit > 0 Then
                    For i = 0 To Me.tbl_TrnJurnaldetil_Debit.Rows.Count - 1
                        If Me.tbl_TrnJurnaldetil_Debit.Rows(i).RowState <> DataRowState.Deleted Then
                            If clsUtil.IsDbNull(Me.tbl_TrnJurnaldetil_Debit.Rows(i).Item("acc_id"), 0) = akun1 Then '8500011 Then
                                Me.tbl_TrnJurnaldetil_Debit.Rows(i).Delete()
                                Exit For
                            End If
                        End If
                    Next
                End If
                row = Me.tbl_TrnJurnaldetil_Credit.NewRow
                row.Item("currency_id") = Me.DgvTrnJurnaldetil_Credit.CurrentRow.Cells("currency_id").Value
                row.Item("jurnaldetil_descr") = Me.DgvTrnJurnaldetil_Credit.CurrentRow.Cells("jurnaldetil_descr").Value
                row.Item("jurnaldetil_idr") = -amountChangeSelisih
                row.Item("jurnaldetil_foreign") = 0
                row.Item("jurnaldetil_foreignrate") = 0
                row.Item("acc_id") = akun2 '8001000
                row.Item("ref_id") = Me.DgvTrnJurnaldetil_Credit.CurrentRow.Cells("ref_id").Value
                row.Item("ref_line") = Me.DgvTrnJurnaldetil_Credit.CurrentRow.Cells("ref_line").Value
                row.Item("ref_budgetline") = 0
                row.Item("region_id") = 0
                row.Item("branch_id") = 0
                row.Item("strukturunit_id") = Me.DgvTrnJurnaldetil_Credit.CurrentRow.Cells("strukturunit_id").Value
                row.Item("rekanan_id") = Me.DgvTrnJurnaldetil_Credit.CurrentRow.Cells("rekanan_id").Value
                row.Item("rekanan_name") = Me.DgvTrnJurnaldetil_Debit.CurrentRow.Cells("rekanan_name").Value
                row.Item("budget_id") = 0
                row.Item("budget_name") = "-- PILIH --"
                row.Item("budgetdetil_id") = 0
                row.Item("budgetdetil_name") = "-- PILIH --"
                Me.tbl_TrnJurnaldetil_Credit.Rows.Add(row)
            Else
                For i = 0 To Me.tbl_TrnJurnaldetil_Credit.Rows.Count - 1
                    If Me.tbl_TrnJurnaldetil_Credit.Rows(i).RowState <> DataRowState.Deleted Then
                        If clsUtil.IsDbNull(Me.tbl_TrnJurnaldetil_Credit.Rows(i).Item("acc_id"), 0) = akun2 Then '8001000 Then
                            Me.tbl_TrnJurnaldetil_Credit.Rows(i).Item("jurnaldetil_idr") = -amountChangeSelisih
                            Exit For
                        End If
                    End If
                Next
            End If

            Me.DgvTrnJurnaldetil_Credit.CurrentRow.Cells("jurnaldetil_foreignrate").Value = Math.Round(CDec(idr) / Me.DgvTrnJurnaldetil_Credit.CurrentRow.Cells("jurnaldetil_foreign").Value, 0, MidpointRounding.AwayFromZero)
            Me.DgvTrnJurnaldetil_Credit.CurrentRow.Cells("jurnaldetil_idr").Value = Math.Round(CDec(idr), 2, MidpointRounding.AwayFromZero)

        ElseIf amountChangeSelisih > 0 Then
            If rowChangesDebit = 0 Then
                If rowChangesCredit > 0 Then
                    For i = 0 To Me.tbl_TrnJurnaldetil_Credit.Rows.Count - 1
                        If Me.tbl_TrnJurnaldetil_Credit.Rows(i).RowState <> DataRowState.Deleted Then
                            If clsUtil.IsDbNull(Me.tbl_TrnJurnaldetil_Credit.Rows(i).Item("acc_id"), 0) = akun2 Then '8001000 Then
                                Me.tbl_TrnJurnaldetil_Credit.Rows(i).Delete()
                                Exit For
                            End If
                        End If
                    Next
                End If
                row = Me.tbl_TrnJurnaldetil_Debit.NewRow
                row.Item("currency_id") = Me.DgvTrnJurnaldetil_Credit.CurrentRow.Cells("currency_id").Value
                row.Item("jurnaldetil_descr") = Me.DgvTrnJurnaldetil_Credit.CurrentRow.Cells("jurnaldetil_descr").Value
                row.Item("jurnaldetil_idr") = amountChangeSelisih
                row.Item("jurnaldetil_foreign") = 0
                row.Item("jurnaldetil_foreignrate") = 0
                row.Item("acc_id") = akun1  '8500011
                row.Item("ref_id") = Me.DgvTrnJurnaldetil_Credit.CurrentRow.Cells("ref_id").Value
                row.Item("ref_line") = Me.DgvTrnJurnaldetil_Credit.CurrentRow.Cells("ref_line").Value
                row.Item("ref_budgetline") = 0
                row.Item("region_id") = 0
                row.Item("branch_id") = 0
                row.Item("strukturunit_id") = Me.DgvTrnJurnaldetil_Credit.CurrentRow.Cells("strukturunit_id").Value
                row.Item("rekanan_id") = Me.DgvTrnJurnaldetil_Credit.CurrentRow.Cells("rekanan_id").Value
                row.Item("rekanan_name") = Me.DgvTrnJurnaldetil_Debit.CurrentRow.Cells("rekanan_name").Value
                row.Item("budget_id") = 0
                row.Item("budget_name") = "-- PILIH --"
                row.Item("budgetdetil_id") = 0
                row.Item("budgetdetil_name") = "-- PILIH --"
                Me.tbl_TrnJurnaldetil_Debit.Rows.Add(row)
            Else
                For i = 0 To Me.tbl_TrnJurnaldetil_Debit.Rows.Count - 1
                    If Me.tbl_TrnJurnaldetil_Debit.Rows(i).RowState <> DataRowState.Deleted Then
                        If clsUtil.IsDbNull(Me.tbl_TrnJurnaldetil_Debit.Rows(i).Item("acc_id"), 0) = akun1 Then '8500011 Then
                            Me.tbl_TrnJurnaldetil_Debit.Rows(i).Item("jurnaldetil_idr") = amountChangeSelisih
                            Exit For
                        End If
                    End If
                Next
            End If
            Me.DgvTrnJurnaldetil_Credit.CurrentRow.Cells("jurnaldetil_foreignrate").Value = Math.Round(CDec(idr) / Me.DgvTrnJurnaldetil_Credit.CurrentRow.Cells("jurnaldetil_foreign").Value, 0, MidpointRounding.AwayFromZero)
            Me.DgvTrnJurnaldetil_Credit.CurrentRow.Cells("jurnaldetil_idr").Value = Math.Round(CDec(idr), 2, MidpointRounding.AwayFromZero)

        Else
            If rowChangesDebit > 0 Then
                For i = 0 To Me.tbl_TrnJurnaldetil_Debit.Rows.Count - 1
                    If Me.tbl_TrnJurnaldetil_Debit.Rows(i).RowState <> DataRowState.Deleted Then
                        If clsUtil.IsDbNull(Me.tbl_TrnJurnaldetil_Debit.Rows(i).Item("acc_id"), 0) = akun1 Then ' 8500011 Then
                            Me.tbl_TrnJurnaldetil_Debit.Rows(i).Item("jurnaldetil_idr") = amountChangeSelisih
                            Exit For
                        End If
                    End If
                Next
            End If
            If rowChangesCredit > 0 Then
                For i = 0 To Me.tbl_TrnJurnaldetil_Credit.Rows.Count - 1
                    If Me.tbl_TrnJurnaldetil_Credit.Rows(i).RowState <> DataRowState.Deleted Then
                        If clsUtil.IsDbNull(Me.tbl_TrnJurnaldetil_Credit.Rows(i).Item("acc_id"), 0) = akun2 Then '8001000 Then
                            Me.tbl_TrnJurnaldetil_Credit.Rows(i).Item("jurnaldetil_idr") = -amountChangeSelisih
                            Exit For
                        End If
                    End If
                Next
            End If
        End If
        Me.uiTrnJurnal_PV_Advance_RowCalculate(Me.DgvTrnJurnaldetil_Debit, Me.DgvTrnJurnaldetil_Credit, selisih_idr, jumlah_idr)
        Me.uiTrnJurnal_PV_Advance_RowCalculateForeign(Me.DgvTrnJurnaldetil_Debit, Me.DgvTrnJurnaldetil_Credit, selisih_foreign, jumlah_foreign)


        Me.obj_Selisih.Text = String.Format("{0:#,##0}", selisih_idr)
        Me.obj_Jumlah.Text = String.Format("{0:#,##0}", jumlah_idr)
        Me.obj_Selisih_Foreign.Text = String.Format("{0:#,##0.00}", selisih_foreign)
        Me.obj_Jumlah_Foreign.Text = String.Format("{0:#,##0.00}", jumlah_foreign)

        Dim rowDebit As Byte = Me.tbl_TrnJurnaldetil_Debit.Compute("count(acc_id)", String.Format("acc_id='{0}'", akun4)) '"acc_id = 'akun8509990'"
        Dim rowCredit As Byte = Me.tbl_TrnJurnaldetil_Credit.Compute("count(acc_id)", String.Format("acc_id='{0}'", akun3)) '"acc_id = 'akun8009990'"
        Dim sumAmountIdrCredit As Decimal = clsUtil.IsDbNull(Me.tbl_TrnJurnaldetil_Credit.Compute("sum(jurnaldetil_idr)", String.Format("acc_id='{0}'", akun3)), 0) '"acc_id = 'akun8009990'"
        Dim sumAmountIdrDebit As Decimal = clsUtil.IsDbNull(Me.tbl_TrnJurnaldetil_Debit.Compute("sum(jurnaldetil_idr)", String.Format("acc_id='{0}'", akun4)), 0) '"acc_id = 'akun8509990'"
        Dim amountSelisih As Decimal = 0

        If selisih_idr > 0 Then
            If rowDebit = 0 And rowCredit = 0 Then
                amountSelisih = selisih_idr
            ElseIf rowDebit = 0 And rowCredit = 1 Then
                amountSelisih = Math.Round(selisih_idr + sumAmountIdrCredit, 0, MidpointRounding.AwayFromZero)
            ElseIf rowDebit = 1 And rowCredit = 0 Then
                amountSelisih = Math.Round(selisih_idr - sumAmountIdrDebit, 0, MidpointRounding.AwayFromZero)
            Else
                amountSelisih = 0
            End If
        ElseIf selisih_idr < 0 Then
            If rowDebit = 0 And rowCredit = 0 Then
                amountSelisih = selisih_idr
            ElseIf rowDebit = 0 And rowCredit = 1 Then
                amountSelisih = selisih_idr
            ElseIf rowDebit = 1 And rowCredit = 0 Then
                amountSelisih = Math.Round(selisih_idr - sumAmountIdrDebit, 0, MidpointRounding.AwayFromZero)
            Else
                amountSelisih = 0
            End If
        Else
            Exit Sub
        End If


        If amountSelisih > 0 Then
            If rowCredit = 0 Then
                If rowDebit > 0 Then
                    For i = 0 To Me.tbl_TrnJurnaldetil_Debit.Rows.Count - 1
                        If Me.tbl_TrnJurnaldetil_Debit.Rows(i).RowState <> DataRowState.Deleted Then
                            If clsUtil.IsDbNull(Me.tbl_TrnJurnaldetil_Debit.Rows(i).Item("acc_id"), 0) = akun8509990 Then
                                Me.tbl_TrnJurnaldetil_Debit.Rows(i).Delete()
                                Exit For
                            End If
                        End If
                    Next
                End If
                row = Me.tbl_TrnJurnaldetil_Credit.NewRow
                row.Item("currency_id") = Me.obj_Currency_id.SelectedValue
                row.Item("jurnaldetil_idr") = amountSelisih
                row.Item("jurnaldetil_foreign") = 0
                row.Item("jurnaldetil_foreignrate") = 0
                row.Item("acc_id") = String.Format("{0}", akun3) '"akun8009990"
                row.Item("ref_id") = String.Empty
                row.Item("ref_line") = 0
                row.Item("ref_budgetline") = 0
                row.Item("region_id") = 0
                row.Item("branch_id") = 0
                row.Item("strukturunit_id") = 0
                row.Item("rekanan_id") = Me.obj_Rekanan_id.SelectedValue
                row.Item("rekanan_name") = Trim(Me.obj_Rekanan_id.Text)
                row.Item("jurnaldetil_descr") = "Pendapatan"
                Me.tbl_TrnJurnaldetil_Credit.Rows.Add(row)
            Else
                For i = 0 To Me.tbl_TrnJurnaldetil_Credit.Rows.Count - 1
                    If Me.tbl_TrnJurnaldetil_Credit.Rows(i).RowState <> DataRowState.Deleted Then
                        If clsUtil.IsDbNull(Me.tbl_TrnJurnaldetil_Credit.Rows(i).Item("acc_id"), 0) = akun3 Then 'akun8009990 Then
                            Me.tbl_TrnJurnaldetil_Credit.Rows(i).Item("jurnaldetil_idr") = amountSelisih
                            Exit For
                        End If
                    End If
                Next
            End If
        ElseIf amountSelisih < 0 Then
            If rowDebit = 0 Then
                If rowCredit > 0 Then
                    For i = 0 To Me.tbl_TrnJurnaldetil_Credit.Rows.Count - 1
                        If Me.tbl_TrnJurnaldetil_Credit.Rows(i).RowState <> DataRowState.Deleted Then
                            If clsUtil.IsDbNull(Me.tbl_TrnJurnaldetil_Credit.Rows(i).Item("acc_id"), 0) = akun3 Then 'akun8009990 Then
                                Me.tbl_TrnJurnaldetil_Credit.Rows(i).Delete()
                                Exit For
                            End If
                        End If
                    Next
                End If
                row = Me.tbl_TrnJurnaldetil_Debit.NewRow
                row.Item("currency_id") = Me.obj_Currency_id.SelectedValue
                row.Item("jurnaldetil_idr") = -amountSelisih
                row.Item("jurnaldetil_foreign") = 0
                row.Item("jurnaldetil_foreignrate") = 0
                row.Item("acc_id") = String.Format("{0}", akun4) '"akun8509990"
                row.Item("ref_id") = String.Empty
                row.Item("ref_line") = 0
                row.Item("ref_budgetline") = 0
                row.Item("region_id") = 0
                row.Item("branch_id") = 0
                row.Item("strukturunit_id") = 0
                row.Item("rekanan_id") = Me.obj_Rekanan_id.SelectedValue
                row.Item("rekanan_name") = Trim(Me.obj_Rekanan_id.Text)
                row.Item("jurnaldetil_descr") = "Biaya"
                Me.tbl_TrnJurnaldetil_Debit.Rows.Add(row)
            Else
                For i = 0 To Me.tbl_TrnJurnaldetil_Debit.Rows.Count - 1
                    If Me.tbl_TrnJurnaldetil_Debit.Rows(i).RowState <> DataRowState.Deleted Then
                        If clsUtil.IsDbNull(Me.tbl_TrnJurnaldetil_Debit.Rows(i).Item("acc_id"), 0) = akun4 Then 'akun8509990 Then
                            Me.tbl_TrnJurnaldetil_Debit.Rows(i).Item("jurnaldetil_idr") = -amountSelisih
                            Exit For
                        End If
                    End If
                Next
            End If
        Else
            If amountSelisih = 0 Then
                If rowDebit > 0 Then
                    For i = 0 To Me.tbl_TrnJurnaldetil_Debit.Rows.Count - 1
                        If Me.tbl_TrnJurnaldetil_Debit.Rows(i).RowState <> DataRowState.Deleted Then
                            If clsUtil.IsDbNull(Me.tbl_TrnJurnaldetil_Debit.Rows(i).Item("acc_id"), 0) = akun4 Then 'akun8509990 Then
                                Me.tbl_TrnJurnaldetil_Debit.Rows(i).Delete()
                                Exit For
                            End If
                        End If
                    Next
                End If
                If rowCredit > 0 Then
                    For i = 0 To Me.tbl_TrnJurnaldetil_Credit.Rows.Count - 1
                        If Me.tbl_TrnJurnaldetil_Credit.Rows(i).RowState <> DataRowState.Deleted Then
                            If clsUtil.IsDbNull(Me.tbl_TrnJurnaldetil_Credit.Rows(i).Item("acc_id"), 0) = akun3 Then 'akun8009990 Then
                                Me.tbl_TrnJurnaldetil_Credit.Rows(i).Delete()
                                Exit For
                            End If
                        End If
                    Next
                End If
            Else
                If rowDebit > 0 Then
                    For i = 0 To Me.tbl_TrnJurnaldetil_Debit.Rows.Count - 1
                        If Me.tbl_TrnJurnaldetil_Debit.Rows(i).RowState <> DataRowState.Deleted Then
                            If clsUtil.IsDbNull(Me.tbl_TrnJurnaldetil_Debit.Rows(i).Item("acc_id"), 0) = akun4 Then 'akun8509990 Then
                                Me.tbl_TrnJurnaldetil_Debit.Rows(i).Item("jurnaldetil_idr") = -amountSelisih
                                Exit For
                            End If
                        End If
                    Next
                End If
                If rowCredit > 0 Then
                    For i = 0 To Me.tbl_TrnJurnaldetil_Credit.Rows.Count - 1
                        If Me.tbl_TrnJurnaldetil_Credit.Rows(i).RowState <> DataRowState.Deleted Then
                            If clsUtil.IsDbNull(Me.tbl_TrnJurnaldetil_Credit.Rows(i).Item("acc_id"), 0) = akun3 Then 'akun8009990 Then
                                Me.tbl_TrnJurnaldetil_Credit.Rows(i).Item("jurnaldetil_idr") = amountSelisih
                                Exit For
                            End If
                        End If
                    Next
                End If
            End If

        End If

        Me.uiTrnJurnal_PV_Advance_RowCalculate(Me.DgvTrnJurnaldetil_Debit, Me.DgvTrnJurnaldetil_Credit, selisih_idr, jumlah_idr)
        Me.obj_Selisih.Text = String.Format("{0:#,##0}", selisih_idr)
        Me.obj_Jumlah.Text = String.Format("{0:#,##0}", jumlah_idr)
    End Sub

    Private Sub ChangeAmountIDRToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ChangeAmountIDRToolStripMenuItem1.Click
        Dim idr As String
        Dim row As DataRow
        Dim selisih_idr, jumlah_idr, selisih_foreign, jumlah_foreign As Decimal
        Dim amountChangeSelisih As Decimal = 0

        idr = InputBox("Amount(IDR) : ", "Fee Amount(IDR)", "", 100, 100)

        '===================REMARK BY PTS 20130726============================================
        'Dim rowChangesDebit As Byte = Me.tbl_TrnJurnaldetil_Debit.Compute("count(acc_id)", "acc_id = '8500011'")
        'Dim rowChangesCredit As Byte = Me.tbl_TrnJurnaldetil_Credit.Compute("count(acc_id)", "acc_id = '8001000'")
        'Dim sumChangesAmountIdrCredit As Decimal = clsUtil.IsDbNull(Me.tbl_TrnJurnaldetil_Credit.Compute("sum(jurnaldetil_idr)", "acc_id = '8001000'"), 0)
        'Dim sumChangesAmountIdrDebit As Decimal = clsUtil.IsDbNull(Me.tbl_TrnJurnaldetil_Debit.Compute("sum(jurnaldetil_idr)", "acc_id = '8500011'"), 0)
        '======================================================================================

        '==================================add PTS 20130726====================================
        Dim rowChangesDebit As Byte = Me.tbl_TrnJurnaldetil_Debit.Compute("count(acc_id)", "acc_id = '" & akun8500015 & "'")
        Dim rowChangesCredit As Byte = Me.tbl_TrnJurnaldetil_Credit.Compute("count(acc_id)", "acc_id = '" & akun8002000 & "'")
        Dim sumChangesAmountIdrCredit As Decimal = clsUtil.IsDbNull(Me.tbl_TrnJurnaldetil_Credit.Compute("sum(jurnaldetil_idr)", "acc_id = '" & akun8002000 & "'"), 0)
        Dim sumChangesAmountIdrDebit As Decimal = clsUtil.IsDbNull(Me.tbl_TrnJurnaldetil_Debit.Compute("sum(jurnaldetil_idr)", "acc_id = '" & akun8500015 & "'"), 0)
        '======================================================================================

        If idr <> "" Then
            If IsNumeric(idr) = True Then
                '==== ari 20151014 ====
                Me.DgvTrnJurnaldetil_Debit.CurrentRow.Cells("branch_id").Value = 1 ' UNTUK TANDA UBAH DARI RATE TAX ATAU AMOUNT IDR TAX
                '======================
                Dim idr_dasar As Decimal = Me.DgvTrnJurnaldetil_Debit.CurrentRow.Cells("jurnaldetil_idr").Value
                If idr_dasar > idr Then
                    If rowChangesDebit = 0 And rowChangesCredit = 0 Then
                        amountChangeSelisih = Math.Round(CDec(idr_dasar - idr), 0, MidpointRounding.AwayFromZero)
                    ElseIf rowChangesDebit = 0 And rowChangesCredit = 1 Then
                        amountChangeSelisih = (Math.Round(Math.Round(CDec(idr_dasar - idr), 0, MidpointRounding.AwayFromZero) - sumChangesAmountIdrCredit, 0, MidpointRounding.AwayFromZero))
                    ElseIf rowChangesDebit = 1 And rowChangesCredit = 0 Then
                        amountChangeSelisih = (Math.Round(Math.Round(CDec(idr_dasar - idr), 0, MidpointRounding.AwayFromZero) + sumChangesAmountIdrDebit, 0, MidpointRounding.AwayFromZero))
                    Else
                        amountChangeSelisih = 0
                    End If
                Else
                    If rowChangesDebit = 0 And rowChangesCredit = 0 Then
                        amountChangeSelisih = Math.Round(-(CDec(idr - idr_dasar)), 0, MidpointRounding.AwayFromZero)
                    ElseIf rowChangesDebit = 0 And rowChangesCredit = 1 Then
                        amountChangeSelisih = Math.Round(Math.Round(-(CDec(idr - idr_dasar)), 0, MidpointRounding.AwayFromZero) - sumChangesAmountIdrCredit, 0, MidpointRounding.AwayFromZero)
                    ElseIf rowChangesDebit = 1 And rowChangesCredit = 0 Then
                        amountChangeSelisih = Math.Round(Math.Round(-(CDec(idr - idr_dasar)), 0, MidpointRounding.AwayFromZero) + sumChangesAmountIdrDebit, 0, MidpointRounding.AwayFromZero)
                    Else
                        amountChangeSelisih = 0
                    End If
                End If
            End If
        End If

        Dim i As Byte

        If amountChangeSelisih < 0 Then
            If rowChangesCredit = 0 Then
                If rowChangesDebit > 0 Then
                    For i = 0 To Me.tbl_TrnJurnaldetil_Debit.Rows.Count - 1
                        If Me.tbl_TrnJurnaldetil_Debit.Rows(i).RowState <> DataRowState.Deleted Then
                            If clsUtil.IsDbNull(Me.tbl_TrnJurnaldetil_Debit.Rows(i).Item("acc_id"), 0) = akun8500015 Then '==>>> reMARK pts 20130726 ==> 8500011 Then
                                Me.tbl_TrnJurnaldetil_Debit.Rows(i).Delete()
                                Exit For
                            End If
                        End If
                    Next
                End If
                row = Me.tbl_TrnJurnaldetil_Credit.NewRow
                row.Item("currency_id") = Me.DgvTrnJurnaldetil_Credit.CurrentRow.Cells("currency_id").Value
                row.Item("jurnaldetil_descr") = Me.DgvTrnJurnaldetil_Credit.CurrentRow.Cells("jurnaldetil_descr").Value
                row.Item("jurnaldetil_idr") = -amountChangeSelisih
                row.Item("jurnaldetil_foreign") = 0
                row.Item("jurnaldetil_foreignrate") = 0
                row.Item("acc_id") = akun8001000 '==> REMARK BY PTS 20130726==>8001000
                row.Item("ref_id") = Me.DgvTrnJurnaldetil_Credit.CurrentRow.Cells("ref_id").Value
                row.Item("ref_line") = Me.DgvTrnJurnaldetil_Credit.CurrentRow.Cells("ref_line").Value
                row.Item("ref_budgetline") = 0
                row.Item("region_id") = 0
                row.Item("branch_id") = 0
                row.Item("strukturunit_id") = Me.DgvTrnJurnaldetil_Credit.CurrentRow.Cells("strukturunit_id").Value
                row.Item("rekanan_id") = Me.DgvTrnJurnaldetil_Credit.CurrentRow.Cells("rekanan_id").Value
                row.Item("rekanan_name") = Me.DgvTrnJurnaldetil_Debit.CurrentRow.Cells("rekanan_name").Value
                row.Item("budget_id") = 0
                row.Item("budget_name") = "-- PILIH --"
                row.Item("budgetdetil_id") = 0
                row.Item("budgetdetil_name") = "-- PILIH --"
                Me.tbl_TrnJurnaldetil_Credit.Rows.Add(row)
            Else
                For i = 0 To Me.tbl_TrnJurnaldetil_Credit.Rows.Count - 1
                    If Me.tbl_TrnJurnaldetil_Credit.Rows(i).RowState <> DataRowState.Deleted Then
                        If clsUtil.IsDbNull(Me.tbl_TrnJurnaldetil_Credit.Rows(i).Item("acc_id"), 0) = akun8002000 Then '==>>> reMARK pts 20130726 ==>8001000 Then
                            Me.tbl_TrnJurnaldetil_Credit.Rows(i).Item("jurnaldetil_idr") = -amountChangeSelisih
                            Exit For
                        End If
                    End If
                Next
            End If

            Me.DgvTrnJurnaldetil_Debit.CurrentRow.Cells("jurnaldetil_foreignrate").Value = Math.Round(CDec(idr) / Me.DgvTrnJurnaldetil_Debit.CurrentRow.Cells("jurnaldetil_foreign").Value, 0, MidpointRounding.AwayFromZero)
            Me.DgvTrnJurnaldetil_Debit.CurrentRow.Cells("jurnaldetil_idr").Value = Math.Round(CDec(idr), 2, MidpointRounding.AwayFromZero)

        ElseIf amountChangeSelisih > 0 Then
            If rowChangesDebit = 0 Then
                If rowChangesCredit > 0 Then
                    For i = 0 To Me.tbl_TrnJurnaldetil_Credit.Rows.Count - 1
                        If Me.tbl_TrnJurnaldetil_Credit.Rows(i).RowState <> DataRowState.Deleted Then
                            If clsUtil.IsDbNull(Me.tbl_TrnJurnaldetil_Credit.Rows(i).Item("acc_id"), 0) = akun8002000 Then '==>>> reMARK pts 20130726 ==>8001000 Then
                                Me.tbl_TrnJurnaldetil_Credit.Rows(i).Delete()
                                Exit For
                            End If
                        End If
                    Next
                End If
                row = Me.tbl_TrnJurnaldetil_Debit.NewRow
                row.Item("currency_id") = Me.DgvTrnJurnaldetil_Credit.CurrentRow.Cells("currency_id").Value
                row.Item("jurnaldetil_descr") = Me.DgvTrnJurnaldetil_Credit.CurrentRow.Cells("jurnaldetil_descr").Value
                row.Item("jurnaldetil_idr") = amountChangeSelisih
                row.Item("jurnaldetil_foreign") = 0
                row.Item("jurnaldetil_foreignrate") = 0
                row.Item("acc_id") = akun8500015 ' ==> REMARK BY PTS 20130726 =>8500011
                row.Item("ref_id") = Me.DgvTrnJurnaldetil_Credit.CurrentRow.Cells("ref_id").Value
                row.Item("ref_line") = Me.DgvTrnJurnaldetil_Credit.CurrentRow.Cells("ref_line").Value
                row.Item("ref_budgetline") = 0
                row.Item("region_id") = 0
                row.Item("branch_id") = 0
                row.Item("strukturunit_id") = Me.DgvTrnJurnaldetil_Credit.CurrentRow.Cells("strukturunit_id").Value
                row.Item("rekanan_id") = Me.DgvTrnJurnaldetil_Credit.CurrentRow.Cells("rekanan_id").Value
                row.Item("rekanan_name") = Me.DgvTrnJurnaldetil_Debit.CurrentRow.Cells("rekanan_name").Value
                row.Item("budget_id") = 0
                row.Item("budget_name") = "-- PILIH --"
                row.Item("budgetdetil_id") = 0
                row.Item("budgetdetil_name") = "-- PILIH --"
                Me.tbl_TrnJurnaldetil_Debit.Rows.Add(row)
            Else
                For i = 0 To Me.tbl_TrnJurnaldetil_Debit.Rows.Count - 1
                    If Me.tbl_TrnJurnaldetil_Debit.Rows(i).RowState <> DataRowState.Deleted Then
                        If clsUtil.IsDbNull(Me.tbl_TrnJurnaldetil_Debit.Rows(i).Item("acc_id"), 0) = akun8500015 Then '==>>> reMARK pts 20130726 ==> 8500011 Then
                            Me.tbl_TrnJurnaldetil_Debit.Rows(i).Item("jurnaldetil_idr") = amountChangeSelisih
                            Exit For
                        End If
                    End If
                Next
            End If
            Me.DgvTrnJurnaldetil_Debit.CurrentRow.Cells("jurnaldetil_foreignrate").Value = Math.Round(CDec(idr) / Me.DgvTrnJurnaldetil_Debit.CurrentRow.Cells("jurnaldetil_foreign").Value, 0, MidpointRounding.AwayFromZero)
            Me.DgvTrnJurnaldetil_Debit.CurrentRow.Cells("jurnaldetil_idr").Value = Math.Round(CDec(idr), 2, MidpointRounding.AwayFromZero)

        Else
            If rowChangesDebit > 0 Then
                For i = 0 To Me.tbl_TrnJurnaldetil_Debit.Rows.Count - 1
                    If Me.tbl_TrnJurnaldetil_Debit.Rows(i).RowState <> DataRowState.Deleted Then
                        If clsUtil.IsDbNull(Me.tbl_TrnJurnaldetil_Debit.Rows(i).Item("acc_id"), 0) = akun8500015 Then '==>>> reMARK pts 20130726 ==> 8500011 Then
                            Me.tbl_TrnJurnaldetil_Debit.Rows(i).Item("jurnaldetil_idr") = amountChangeSelisih
                            Exit For
                        End If
                    End If
                Next
            End If
            If rowChangesCredit > 0 Then
                For i = 0 To Me.tbl_TrnJurnaldetil_Credit.Rows.Count - 1
                    If Me.tbl_TrnJurnaldetil_Credit.Rows(i).RowState <> DataRowState.Deleted Then
                        If clsUtil.IsDbNull(Me.tbl_TrnJurnaldetil_Credit.Rows(i).Item("acc_id"), 0) = akun8002000 Then '==>>> reMARK pts 20130726 ==>8001000 Then
                            Me.tbl_TrnJurnaldetil_Credit.Rows(i).Item("jurnaldetil_idr") = -amountChangeSelisih
                            Exit For
                        End If
                    End If
                Next
            End If
        End If

        Me.uiTrnJurnal_PV_Advance_RowCalculate(Me.DgvTrnJurnaldetil_Debit, Me.DgvTrnJurnaldetil_Credit, selisih_idr, jumlah_idr)
        Me.uiTrnJurnal_PV_Advance_RowCalculateForeign(Me.DgvTrnJurnaldetil_Debit, Me.DgvTrnJurnaldetil_Credit, selisih_foreign, jumlah_foreign)

        Me.obj_Selisih.Text = String.Format("{0:#,##0}", selisih_idr)
        Me.obj_Jumlah.Text = String.Format("{0:#,##0}", jumlah_idr)
        Me.obj_Selisih_Foreign.Text = String.Format("{0:#,##0.00}", selisih_foreign)
        Me.obj_Jumlah_Foreign.Text = String.Format("{0:#,##0.00}", jumlah_foreign)

        '===============================================REMAK BY PTS 20130726=======================================
        'Dim rowDebit As Byte = Me.tbl_TrnJurnaldetil_Debit.Compute("count(acc_id)", "acc_id = 'akun8509990'")
        'Dim rowCredit As Byte = Me.tbl_TrnJurnaldetil_Credit.Compute("count(acc_id)", "acc_id = 'akun8009990'")
        'Dim sumAmountIdrCredit As Decimal = clsUtil.IsDbNull(Me.tbl_TrnJurnaldetil_Credit.Compute("sum(jurnaldetil_idr)", "acc_id = 'akun8009990'"), 0)
        'Dim sumAmountIdrDebit As Decimal = clsUtil.IsDbNull(Me.tbl_TrnJurnaldetil_Debit.Compute("sum(jurnaldetil_idr)", "acc_id = 'akun8509990'"), 0)
        'Dim amountSelisih As Decimal = 0
        '===========================================================================================================

        '===================ADD PTS 20130726====================================================================================================================
        Dim rowDebit As Byte = Me.tbl_TrnJurnaldetil_Debit.Compute("count(acc_id)", "acc_id = '" & akun8509990 & "'")
        Dim rowCredit As Byte = Me.tbl_TrnJurnaldetil_Credit.Compute("count(acc_id)", "acc_id = '" & akun8009990 & "'")
        Dim sumAmountIdrCredit As Decimal = clsUtil.IsDbNull(Me.tbl_TrnJurnaldetil_Credit.Compute("sum(jurnaldetil_idr)", "acc_id = '" & akun8009990 & "'"), 0)
        Dim sumAmountIdrDebit As Decimal = clsUtil.IsDbNull(Me.tbl_TrnJurnaldetil_Debit.Compute("sum(jurnaldetil_idr)", "acc_id = '" & akun8509990 & "'"), 0)
        Dim amountSelisih As Decimal = 0
        '=======================================================================================================================================================

        If selisih_idr > 0 Then
            If rowDebit = 0 And rowCredit = 0 Then
                amountSelisih = selisih_idr
            ElseIf rowDebit = 0 And rowCredit = 1 Then
                amountSelisih = Math.Round(selisih_idr + sumAmountIdrCredit, 0, MidpointRounding.AwayFromZero)
            ElseIf rowDebit = 1 And rowCredit = 0 Then
                amountSelisih = Math.Round(selisih_idr - sumAmountIdrDebit, 0, MidpointRounding.AwayFromZero)
            Else
                amountSelisih = 0
            End If
        ElseIf selisih_idr < 0 Then
            If rowDebit = 0 And rowCredit = 0 Then
                amountSelisih = selisih_idr
            ElseIf rowDebit = 0 And rowCredit = 1 Then
                amountSelisih = selisih_idr
            ElseIf rowDebit = 1 And rowCredit = 0 Then
                amountSelisih = Math.Round(selisih_idr - sumAmountIdrDebit, 0, MidpointRounding.AwayFromZero)
            Else
                amountSelisih = 0
            End If
        Else
            Exit Sub
        End If


        If amountSelisih > 0 Then
            If rowCredit = 0 Then
                If rowDebit > 0 Then
                    For i = 0 To Me.tbl_TrnJurnaldetil_Debit.Rows.Count - 1
                        If Me.tbl_TrnJurnaldetil_Debit.Rows(i).RowState <> DataRowState.Deleted Then
                            If clsUtil.IsDbNull(Me.tbl_TrnJurnaldetil_Debit.Rows(i).Item("acc_id"), 0) = akun8509990 Then
                                Me.tbl_TrnJurnaldetil_Debit.Rows(i).Delete()
                                Exit For
                            End If
                        End If
                    Next
                End If
                row = Me.tbl_TrnJurnaldetil_Credit.NewRow
                row.Item("currency_id") = Me.obj_Currency_id.SelectedValue
                row.Item("jurnaldetil_idr") = amountSelisih
                row.Item("jurnaldetil_foreign") = 0
                row.Item("jurnaldetil_foreignrate") = 0

                '=======REMARK BY PTS 20130726=====
                'row.Item("acc_id") = "akun8009990"
                '==================================

                '=============ADD PTS 20130726=====
                row.Item("acc_id") = akun8009990
                '==================================

                row.Item("ref_id") = String.Empty
                row.Item("ref_line") = 0
                row.Item("ref_budgetline") = 0
                row.Item("region_id") = 0
                row.Item("branch_id") = 0
                row.Item("strukturunit_id") = 0
                row.Item("rekanan_id") = Me.obj_Rekanan_id.SelectedValue
                row.Item("rekanan_name") = Trim(Me.obj_Rekanan_id.Text)
                row.Item("jurnaldetil_descr") = "Pendapatan"
                Me.tbl_TrnJurnaldetil_Credit.Rows.Add(row)
            Else
                For i = 0 To Me.tbl_TrnJurnaldetil_Credit.Rows.Count - 1
                    If Me.tbl_TrnJurnaldetil_Credit.Rows(i).RowState <> DataRowState.Deleted Then
                        If clsUtil.IsDbNull(Me.tbl_TrnJurnaldetil_Credit.Rows(i).Item("acc_id"), 0) = akun8009990 Then
                            Me.tbl_TrnJurnaldetil_Credit.Rows(i).Item("jurnaldetil_idr") = amountSelisih
                            Exit For
                        End If
                    End If
                Next
            End If
        ElseIf amountSelisih < 0 Then
            If rowDebit = 0 Then
                If rowCredit > 0 Then
                    For i = 0 To Me.tbl_TrnJurnaldetil_Credit.Rows.Count - 1
                        If Me.tbl_TrnJurnaldetil_Credit.Rows(i).RowState <> DataRowState.Deleted Then
                            If clsUtil.IsDbNull(Me.tbl_TrnJurnaldetil_Credit.Rows(i).Item("acc_id"), 0) = akun8009990 Then
                                Me.tbl_TrnJurnaldetil_Credit.Rows(i).Delete()
                                Exit For
                            End If
                        End If
                    Next
                End If
                row = Me.tbl_TrnJurnaldetil_Debit.NewRow
                row.Item("currency_id") = Me.obj_Currency_id.SelectedValue
                row.Item("jurnaldetil_idr") = -amountSelisih
                row.Item("jurnaldetil_foreign") = 0
                row.Item("jurnaldetil_foreignrate") = 0
                '==
                '=======REMARK BY PTS 20130726=====
                'row.Item("acc_id") = "akun8509990"
                '==================================

                '=======ADD PTS 20130726===========
                row.Item("acc_id") = akun8509990
                '==================================


                row.Item("ref_id") = String.Empty
                row.Item("ref_line") = 0
                row.Item("ref_budgetline") = 0
                row.Item("region_id") = 0
                row.Item("branch_id") = 0
                row.Item("strukturunit_id") = 0
                row.Item("rekanan_id") = Me.obj_Rekanan_id.SelectedValue
                row.Item("rekanan_name") = Trim(Me.obj_Rekanan_id.Text)
                row.Item("jurnaldetil_descr") = "Biaya"
                Me.tbl_TrnJurnaldetil_Debit.Rows.Add(row)
            Else
                For i = 0 To Me.tbl_TrnJurnaldetil_Debit.Rows.Count - 1
                    If Me.tbl_TrnJurnaldetil_Debit.Rows(i).RowState <> DataRowState.Deleted Then
                        If clsUtil.IsDbNull(Me.tbl_TrnJurnaldetil_Debit.Rows(i).Item("acc_id"), 0) = akun8509990 Then
                            Me.tbl_TrnJurnaldetil_Debit.Rows(i).Item("jurnaldetil_idr") = -amountSelisih
                            Exit For
                        End If
                    End If
                Next
            End If
        Else
            If amountSelisih = 0 Then
                If rowDebit > 0 Then
                    For i = 0 To Me.tbl_TrnJurnaldetil_Debit.Rows.Count - 1
                        If Me.tbl_TrnJurnaldetil_Debit.Rows(i).RowState <> DataRowState.Deleted Then
                            If clsUtil.IsDbNull(Me.tbl_TrnJurnaldetil_Debit.Rows(i).Item("acc_id"), 0) = akun8509990 Then
                                Me.tbl_TrnJurnaldetil_Debit.Rows(i).Delete()
                                Exit For
                            End If
                        End If
                    Next
                End If
                If rowCredit > 0 Then
                    For i = 0 To Me.tbl_TrnJurnaldetil_Credit.Rows.Count - 1
                        If Me.tbl_TrnJurnaldetil_Credit.Rows(i).RowState <> DataRowState.Deleted Then
                            If clsUtil.IsDbNull(Me.tbl_TrnJurnaldetil_Credit.Rows(i).Item("acc_id"), 0) = akun8009990 Then
                                Me.tbl_TrnJurnaldetil_Credit.Rows(i).Delete()
                                Exit For
                            End If
                        End If
                    Next
                End If
            Else
                If rowDebit > 0 Then
                    For i = 0 To Me.tbl_TrnJurnaldetil_Debit.Rows.Count - 1
                        If Me.tbl_TrnJurnaldetil_Debit.Rows(i).RowState <> DataRowState.Deleted Then
                            If clsUtil.IsDbNull(Me.tbl_TrnJurnaldetil_Debit.Rows(i).Item("acc_id"), 0) = akun8509990 Then
                                Me.tbl_TrnJurnaldetil_Debit.Rows(i).Item("jurnaldetil_idr") = -amountSelisih
                                Exit For
                            End If
                        End If
                    Next
                End If
                If rowCredit > 0 Then
                    For i = 0 To Me.tbl_TrnJurnaldetil_Credit.Rows.Count - 1
                        If Me.tbl_TrnJurnaldetil_Credit.Rows(i).RowState <> DataRowState.Deleted Then
                            If clsUtil.IsDbNull(Me.tbl_TrnJurnaldetil_Credit.Rows(i).Item("acc_id"), 0) = akun8009990 Then
                                Me.tbl_TrnJurnaldetil_Credit.Rows(i).Item("jurnaldetil_idr") = amountSelisih
                                Exit For
                            End If
                        End If
                    Next
                End If
            End If

        End If

        'Me.uiTrnJurnal_PV_Tax_RowCalculate(Me.DgvTrnJurnaldetil_Debit, Me.DgvTrnJurnaldetil_Credit, selisih_idr, jumlah_idr)
        Me.uiTrnJurnal_PV_Advance_RowCalculate(Me.DgvTrnJurnaldetil_Debit, Me.DgvTrnJurnaldetil_Credit, selisih_idr, jumlah_idr)
        Me.obj_Selisih.Text = String.Format("{0:#,##0}", selisih_idr)
        Me.obj_Jumlah.Text = String.Format("{0:#,##0}", jumlah_idr)
    End Sub

    Private Function GetAdvanceID(ByVal jurnal_id As String) As String
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbCmd As OleDb.OleDbCommand

        dbCmd = New OleDb.OleDbCommand(String.Format("select top 1 ref_Id from transaksi_jurnaldetil as a where a.jurnal_id = '{0}' and jurnaldetil_dk = 'D' and ref_id <> ''", jurnal_id), dbConn)
        dbCmd.CommandType = CommandType.Text

        Dim cookie As Byte() = Nothing
        Dim advance_id As String = String.Empty

        Try
            dbConn.Open()
            clsApplicationRole.SetAppRole(dbConn, cookie)
            advance_id = dbCmd.ExecuteScalar()
            Return advance_id
        Catch ex As Exception
            Return ""
            Throw ex
        Finally
            clsApplicationRole.UnsetAppRole(dbConn, cookie)
            dbConn.Close()
        End Try
    End Function

    Private Function GetAdvanceBudgetID(ByVal advance_id As String) As Decimal
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbCmd As OleDb.OleDbCommand

        dbCmd = New OleDb.OleDbCommand(String.Format("select budget_id from transaksi_advance where advance_id = '{0}'", advance_id), dbConn)
        dbCmd.CommandType = CommandType.Text

        Dim cookie As Byte() = Nothing
        Dim budget_id As Decimal = 0
        Try
            dbConn.Open()
            clsApplicationRole.SetAppRole(dbConn, cookie)
            budget_id = dbCmd.ExecuteScalar()
            Return budget_id
        Catch ex As Exception
            Return ""
            Throw ex
        Finally
            clsApplicationRole.UnsetAppRole(dbConn, cookie)
            dbConn.Close()
        End Try
    End Function

    Private Function GetProdTypeBudgetID(ByVal budget_id As Decimal) As Decimal
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbCmd As OleDb.OleDbCommand

        dbCmd = New OleDb.OleDbCommand(String.Format("select b.prodtype_name from transaksi_budget as a left join master_prodtype as b on a.prodtype_id = b.prodtype_id where a.budget_id = '{0}'", budget_id), dbConn)
        dbCmd.CommandType = CommandType.Text

        Dim cookie As Byte() = Nothing
        Dim prodtype_name As String = ""
        Dim retAccId As Decimal = 0
        Try
            dbConn.Open()
            clsApplicationRole.SetAppRole(dbConn, cookie)
            prodtype_name = dbCmd.ExecuteScalar()

            If prodtype_name = "Production" Then
                retAccId = 1161111
            ElseIf prodtype_name = "News" Then
                retAccId = 1161112
            ElseIf prodtype_name = "Join" Then
                retAccId = 0
            ElseIf prodtype_name = "Others" Then
                retAccId = 1161132
            ElseIf prodtype_name = "Innovation" Then
                retAccId = 1161132
            End If

            Return retAccId
        Catch ex As Exception
            Return retAccId
            Throw ex
        Finally
            clsApplicationRole.UnsetAppRole(dbConn, cookie)
            dbConn.Close()
        End Try
    End Function

    Private Sub GeneratePrintPV(ByVal jurnal_id As String, ByVal channel_id As String)
        Dim objRdsH As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Dim objReportH As Microsoft.Reporting.WinForms.LocalReport = New Microsoft.Reporting.WinForms.LocalReport
        Dim objRdsD As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Dim objReportD As Microsoft.Reporting.WinForms.LocalReport = New Microsoft.Reporting.WinForms.LocalReport
        Dim objDatalistHeader As ArrayList = New ArrayList()
        Dim objReportViewer As Microsoft.Reporting.WinForms.ReportViewer = New Microsoft.Reporting.WinForms.ReportViewer

        objDatalistHeader = Me.GenerateDataHeaderPayment(jurnal_id, channel_id)

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

        Dim parRptChannelID As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("channelID", Me.strchannel_id)
        Dim parRptChannel_namereport As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("channelName", Me.sptChannel_nameReport)
        Dim parRptChannel_address As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("channelAddress", Me.sptChannel_address)
        Dim parRptID As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("id", Me.id)
        Dim parRptPrint As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("print", Me.isPrint)
        Dim parRptDate As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("p_date", Me.p_date)
        Dim parRptAmountIdr As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("amountidr", Me.AmountIdrNew)
        Dim parRptAmountForeign As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("amountforeign", Me.AmountForeignNew)
        Dim parRptCreateDate As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("createDate", Me.parCreate_Date)
        Dim parRptRekananName As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("rekananName", Me.parRekanan_Name)
        Dim parRptBudgetName As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("budgetName", Me.parBudget_name)
        Dim parRptJurnalDescr As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("jurnalDescr", Me.parJurnal_Desc)
        Dim parRptCurrencyName As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("currencyName", Me.parCurrency_Name)
        Dim parRptAmountRate As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("amountRate", Me.parAmountRate)

        objRdsH.Name = "ACT_FINANCE_DataSource_clsRptJurnalPV_Header"
        objRdsH.Value = objDatalistHeader
        If Me._USER_TYPE = "SPV" Then
            objReportH.ReportEmbeddedResource = "ACT_FINANCE.rptPV_HeaderListAdvance_Post.rdlc"
        Else
            objReportH.ReportEmbeddedResource = "ACT_FINANCE.rptPV_HeaderListAdvance.rdlc"
        End If
        objReportH.DataSources.Add(objRdsH)

        objReportH.EnableExternalImages = True
        objReportH.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter() {parRptImageURL, _
            parRptChannelID, parRptChannel_namereport, parRptChannel_address, parRptID, _
            parRptAmountIdr, parRptAmountForeign, parRptCreateDate, parRptRekananName, parRptBudgetName, _
            parRptJurnalDescr, parRptCurrencyName, parRptAmountRate})
        AddHandler objReportH.SubreportProcessing, AddressOf SubreportProcessingPV

        Using report As New clsQuickPrint(objReportH)
            report.Print("0.1in", "0.25in", "0.1in", "0.1in")
        End Using
    End Sub

    Private Sub GeneratePrintJV(ByVal jurnal_id As String, ByVal channel_id As String)
        Dim objRdsH As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Dim objReportH As Microsoft.Reporting.WinForms.LocalReport = New Microsoft.Reporting.WinForms.LocalReport
        Dim objRdsD As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Dim objReportD As Microsoft.Reporting.WinForms.LocalReport = New Microsoft.Reporting.WinForms.LocalReport
        Dim objDatalistHeader As ArrayList = New ArrayList()
        Dim objReportViewer As Microsoft.Reporting.WinForms.ReportViewer = New Microsoft.Reporting.WinForms.ReportViewer

        Me.tbl_Print.Clear()
        Me.DataFill(Me.tbl_Print, "act_RptJurnal_SelectHeader", String.Format("jurnal_id = '{0}' AND channel_id = '{1}'", jurnal_id, channel_id))

        'Dim parRptImageURL As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("imageURL", Me.SptServer & "/Solutions/images/" & Me._CHANNEL & ".jpg")

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

        Dim parRptChannel_namereport As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("channel_name", CStr(Me.tbl_Print.Rows(0).Item("channel_name")))
        Dim parRptChannel_address As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("channel_address", CStr(Me.tbl_Print.Rows(0).Item("channel_address")))

        objDatalistHeader = Me.GenerateDataHeader(jurnal_id, channel_id)

        Dim parRptJurnalID As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("jurnal_id", parJurnal_id)
        Dim parRptJurnalTypeID As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("jurnaltype_id", Me.parJurnalType_id)
        Dim parRptJurnal_Source As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("jurnal_source", Me.parJurnal_Source)
        Dim parRptJurnal_BookDate As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("jurnal_bookdate", Me.parJurnal_BookDate)
        Dim parRptPeriodeName As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("periode_name", Me.parPeriode_Name)
        Dim parRptCurrencyName As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("currency_name", Me.parCurrency_Name)
        Dim parRptJurnal_AmountForeign As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("jurnal_amountforeign", Me.parJurnal_AmountForeign)
        Dim parRptRekananName As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("rekanan_name", Me.parRekanan_Name)
        Dim parRptJurnal_Desc As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("jurnal_descr", Me.parJurnal_Desc)

        objRdsH.Name = "ACT_FINANCE_DataSource_clsRptJurnal_Header"
        objRdsH.Value = objDatalistHeader
        If Me._USER_TYPE = "SPV" Then
            objReportH.ReportEmbeddedResource = "ACT_FINANCE.rptJurnal_PV_Advance_Post_Header.rdlc"
        Else
            objReportH.ReportEmbeddedResource = "ACT_FINANCE.rptJurnal_PV_Advance_Header.rdlc"
        End If
        objReportH.DataSources.Add(objRdsH)
        objReportH.EnableExternalImages = True

        objReportH.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter() {parRptImageURL, parRptChannel_namereport, parRptChannel_address, parRptJurnalID, _
        parRptJurnalTypeID, parRptJurnal_Source, parRptJurnal_BookDate, parRptPeriodeName, _
        parRptCurrencyName, parRptCurrencyName, parRptJurnal_AmountForeign, parRptRekananName, _
        parRptJurnal_Desc})

        AddHandler objReportH.SubreportProcessing, AddressOf SubreportProcessingJV
        'Export(objReportH)

        'm_currentPageIndex = 0
        'Print()
        Using report As New clsQuickPrint(objReportH)
            report.Print()
        End Using
    End Sub

#Region "Print Advance Travel"
    Private Function GeneratePrintAdvanceTravel(ByVal advance_id As String, ByVal budget_id As Decimal) As Boolean
        Dim objRdsH As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Dim objReportH As Microsoft.Reporting.WinForms.LocalReport = New Microsoft.Reporting.WinForms.LocalReport
        Dim objRdsD As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Dim objReportD As Microsoft.Reporting.WinForms.LocalReport = New Microsoft.Reporting.WinForms.LocalReport
        Dim objDatalistHeader As ArrayList = New ArrayList()
        Dim objReportViewer As Microsoft.Reporting.WinForms.ReportViewer = New Microsoft.Reporting.WinForms.ReportViewer
        Dim realization As Decimal = Me.GetRealization(budget_id)

        objDatalistHeader = Me.GenerateDataHeaderAdvance()
        Dim parRptImageURL As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("imageURL", Me.SptServer)
        Dim parRptChannelID As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("channelID", Me.strchannel_id)
        Dim parRptChannel_namereport As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("channelName", Me.sptChannel_nameReport)
        Dim parRptChannel_address As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("channelAddress", Me.sptChannel_address)
        Dim parRptID As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("id", Me.id)
        Dim parRptDomain As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("p_domain_name", Me.sptDomain)
        Dim parRptRealization As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("p_realization", realization)

        Dim parRptApproved1By As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("p_approved1by", approved1_by)
        Dim parRptApproved2By As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("p_approved2by", approved2_by)
        Dim parRptApproved3By As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("p_approved3by", approved3_by)
        Dim parRptApproved4By As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("p_approved4by", approved4_by)
        Dim parRptApproved5By As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("p_approved5by", approved5_by)
        Dim parRptApproved6By As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("p_approved6by", approved6_by)
        Dim parRptApproved7By As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("p_approved7by", approved7_by)

        Dim parRptTitleApp1 As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("p_titleapp1", titleapp1)
        Dim parRptTitleApp2 As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("p_titleapp2", titleapp2)
        Dim parRptTitleApp3 As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("p_titleapp3", titleapp3)
        Dim parRptTitleApp4 As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("p_titleapp4", titleapp4)
        Dim parRptTitleApp5 As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("p_titleapp5", titleapp5)
        Dim parRptTitleApp6 As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("p_titleapp6", titleapp6)
        Dim parRptTitleApp7 As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("p_titleapp7", titleapp7)

        objRdsH.Name = "ACTFINANCE_DataSource_ClsRptAdvanceHeader"
        objRdsH.Value = objDatalistHeader

        objReportH.ReportEmbeddedResource = "ACT_FINANCE.rptAdvancePrint_HeaderListSPD.rdlc"
        objReportH.DataSources.Add(objRdsH)
        objReportH.EnableExternalImages = True


        Try
            objReportH.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter() _
                                                  {parRptImageURL, parRptChannelID, parRptChannel_namereport, parRptChannel_address, parRptID, _
                                                   parRptDomain, parRptRealization, parRptApproved1By, parRptApproved2By, parRptTitleApp1, _
                                                   parRptTitleApp2, parRptTitleApp3, parRptApproved3By, parRptTitleApp4, _
                                                   parRptTitleApp5, parRptTitleApp6, parRptApproved4By, parRptApproved5By, parRptApproved6By, parRptTitleApp7, parRptApproved7By}) ', parRptChannel_telp1, parRptChannel_fax})
            AddHandler objReportH.SubreportProcessing, AddressOf SubreportProcessingAdvance

            Using report As New clsQuickPrint(objReportH)
                report.Print()
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Function

    Private Function GetRealization(ByVal budget_id As String) As Decimal
        Dim dbConn As New OleDb.OleDbConnection(Me.DSN)
        Dim cmd As OleDb.OleDbCommand
        Dim res As Decimal
        Dim cookie As Byte() = Nothing

        Try
            dbConn.Open()
            clsApplicationRole.SetAppRole(dbConn, cookie)

            cmd = New OleDb.OleDbCommand("vq_RptBudgetRealization", dbConn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@channel_id", OleDb.OleDbType.VarWChar, 10).Value = _CHANNEL
            cmd.Parameters.Add("@budget_id", OleDb.OleDbType.Numeric, 8).Value = budget_id

            res = cmd.ExecuteScalar()

            Return res
        Catch ex As Exception
            Throw ex
        Finally
            If dbConn.State = ConnectionState.Open Then
                clsApplicationRole.UnsetAppRole(dbConn, cookie)
                dbConn.Close()
            End If
        End Try
    End Function

    Private Function GenerateDataHeaderAdvance() As ArrayList
        Dim objDatalistHeader As ArrayList = New ArrayList()
        Dim oDataFiller As New clsDataFiller(Me.DSN)

        Dim tbl_approved As DataTable = New DataTable

        Dim criteria2 As String

        Dim i As Integer

        objPrintHeaderAdvance = New DataSource.ClsRptAdvanceHeader(Me.DSN)

        With objPrintHeaderAdvance
            criteria2 = String.Format("advance_id='{0}'", Me.tbl_TrnAdvance.Rows(0).Item("advance_id"))

            .ref_no = clsUtil.IsDbNull(Me.tbl_TrnAdvance.Rows(i).Item("advance_id"), String.Empty)
            .Advance_Descr = clsUtil.IsDbNull(Me.tbl_TrnAdvance.Rows(i).Item("advance_descr"), String.Empty)
            .request_date = clsUtil.IsDbNull(Me.tbl_TrnAdvance.Rows(i).Item("advance_entrydt"), String.Empty)
            .request_by = clsUtil.IsDbNull(Me.tbl_TrnAdvance.Rows(i).Item("advance_usedby"), String.Empty)
            .payment_to = clsUtil.IsDbNull(Me.tbl_TrnAdvance.Rows(i).Item("advance_userpic"), String.Empty)
            .payment_address = clsUtil.IsDbNull(Me.tbl_TrnAdvance.Rows(i).Item("advance_prepareloc"), String.Empty)
            .Budget_id = clsUtil.IsDbNull(Me.tbl_TrnAdvance.Rows(i).Item("budget_id"), 0)
            .channel_id = clsUtil.IsDbNull(Me.tbl_TrnAdvance.Rows(i).Item("channel_id"), String.Empty)
            .eps_start = clsUtil.IsDbNull(Me.tbl_TrnAdvance.Rows(i).Item("advance_epsstart"), String.Empty)
            .eps_end = clsUtil.IsDbNull(Me.tbl_TrnAdvance.Rows(i).Item("advance_epsend"), String.Empty)

            .Department = clsUtil.IsDbNull(Me.tbl_TrnAdvance.Rows(i).Item("strukturunit_name"), String.Empty)
            .Program = clsUtil.IsDbNull(Me.tbl_TrnAdvance.Rows(i).Item("budget_name"), String.Empty)
            .currency_name = clsUtil.IsDbNull(Me.tbl_TrnAdvance.Rows(i).Item("currency_shortname"), String.Empty)
            .Budget_name = clsUtil.IsDbNull(Me.tbl_TrnAdvance.Rows(i).Item("budget_name"), String.Empty)
            .budget_amount = clsUtil.IsDbNull(Me.tbl_TrnAdvance.Rows(i).Item("budget_amount"), String.Empty)

            .rekanan_id = clsUtil.IsDbNull(Me.tbl_TrnAdvance.Rows(i).Item("rekanan_name"), String.Empty)
            .Payment_type = clsUtil.IsDbNull(Me.tbl_TrnAdvance.Rows(i).Item("paymenttype_name"), String.Empty)
            .Payment_date = clsUtil.IsDbNull(Me.tbl_TrnAdvance.Rows(i).Item("advance_preparedt"), String.Empty)

            tbl_approved.Clear()
            tbl_approved = Me.getApprovedFromTravel(clsUtil.IsDbNull(Me.tbl_TrnAdvance.Rows(i).Item("advance_id"), String.Empty))

            Me.approved1_by = clsUtil.IsDbNull(tbl_approved.Rows(0).Item("approved1_by"), "")
            Me.approved2_by = clsUtil.IsDbNull(tbl_approved.Rows(0).Item("approved2_by"), "")
            Me.approved3_by = clsUtil.IsDbNull(tbl_approved.Rows(0).Item("approved3_by"), "")
            Me.approved4_by = clsUtil.IsDbNull(tbl_approved.Rows(0).Item("approved4_by"), "")
            Me.approved5_by = clsUtil.IsDbNull(tbl_approved.Rows(0).Item("approved5_by"), "")
            Me.approved6_by = clsUtil.IsDbNull(tbl_approved.Rows(0).Item("approved6_by"), "")
            Me.approved7_by = clsUtil.IsDbNull(tbl_approved.Rows(0).Item("approved7_by"), "")
            Me.titleapp1 = clsUtil.IsDbNull(tbl_approved.Rows(0).Item("titleapp1"), "")
            Me.titleapp2 = clsUtil.IsDbNull(tbl_approved.Rows(0).Item("titleapp2"), "")
            Me.titleapp3 = clsUtil.IsDbNull(tbl_approved.Rows(0).Item("titleapp3"), "")
            Me.titleapp4 = clsUtil.IsDbNull(tbl_approved.Rows(0).Item("titleapp4"), "")
            Me.titleapp5 = clsUtil.IsDbNull(tbl_approved.Rows(0).Item("titleapp5"), "")
            Me.titleapp6 = clsUtil.IsDbNull(tbl_approved.Rows(0).Item("titleapp6"), "")
            Me.titleapp7 = clsUtil.IsDbNull(tbl_approved.Rows(0).Item("titleapp7"), "")

            Me.id = .ref_no
            Me.total_amount = .adv_req
            Me.strchannel_id = .channel_id
            Me.sptChannel_nameReport = .channel_namereport
            Me.sptChannel_address = .channel_address
            Me.sptDomain = .domain_name
            Me.sptChannel_telp1 = .channel_telp1
            Me.sptChannel_fax = .channel_fax

            oDataFiller.DataFill(Me.tbl_TrnAdvanceDetil, "vq_TrnAdvanceDetil_Select", criteria2)
            GenerateDataDetailAdvance()

            .adv_req = Me.adv_req
            .balance = .budget_amount - .adv_req
        End With
        objDatalistHeader.Add(objPrintHeaderAdvance)

        Return objDatalistHeader
    End Function

    Private Function GenerateDataDetailAdvance() As ArrayList
        'Dim objDatalistDetil As ArrayList = New ArrayList()
        Dim oDataFiller As New clsDataFiller(Me.DSN)
        Dim tbl_departement_temp As DataTable = New DataTable
        Dim tbl_program_temp As DataTable = New DataTable
        Dim tbl_currency As DataTable = New DataTable
        Dim tbl_budget As DataTable = New DataTable
        Dim amount_real, pph_amount, ppn_amount, subtotal, total_pphamount, total_ppnamount, total_subtotal, total_discount As Decimal
        Dim amount_intercompay As Decimal
        Dim i, k As Integer
        Dim no As Integer = 1
        Dim pph_persen, ppn_persen, amount_advance, advancedetil_discount, advancedetil_foreignrate As Decimal
        Dim budget_amountdetail As Decimal
        Dim Budget_amountforeign As Decimal
        Dim currency As Decimal
        Dim total_discountAdv As Decimal = 0

        objDatalistDetil = New ArrayList()


        For i = 0 To Me.tbl_TrnAdvanceDetil.Rows.Count - 1
            objPrintDetilAdvance = New DataSource.ClsRptAdvanceDetil(Me.DSN)

            With objPrintDetilAdvance
                .no = no
                .descr = clsUtil.IsDbNull(Me.tbl_TrnAdvanceDetil.Rows(i).Item("advancedetil_descr"), String.Empty)
                .budget_amountdetail = clsUtil.IsDbNull(Me.tbl_TrnAdvanceDetil.Rows(i).Item("advancedetil_idrreal"), 0)
                .Budget_amountforeign = clsUtil.IsDbNull(Me.tbl_TrnAdvanceDetil.Rows(i).Item("advancedetil_foreignreal"), 0)
                .rate = clsUtil.IsDbNull(Me.tbl_TrnAdvanceDetil.Rows(i).Item("advancedetil_foreignrate"), 0)
                .currency = clsUtil.IsDbNull(Me.tbl_TrnAdvanceDetil.Rows(i).Item("currency_id"), 0)
                .total_amount = Me.total_amount
                .amount_intercompany = clsUtil.IsDbNull(Me.tbl_TrnAdvanceDetil.Rows(i).Item("amount_intercompany_sum"), 0)
                amount_intercompay = .amount_intercompany

                If clsUtil.IsDbNull(Me.tbl_TrnAdvanceDetil.Rows(i).Item("advancedetil_type"), String.Empty) = 1 Then
                    total_pphamount = 0
                    total_ppnamount = 0
                    total_subtotal = 0
                    total_discount = 0

                    ''''Me.tbl_TrnAdvanceItemDetil.Clear()
                    ''''oDataFiller.DataFill(Me.tbl_TrnAdvanceItemDetil, "vq_TrnAdvanceItemDetil_Selects", String.Format("a.advance_id='{0}' and a.advancedetil_line={1}", Me.tbl_TrnAdvanceDetil.Rows(i).Item("advance_id"), Me.tbl_TrnAdvanceDetil.Rows(i).Item("advancedetil_line")))
                    Me.tbl_PrintAdvanceListOrderDetil.Clear()
                    oDataFiller.DataFill(Me.tbl_PrintAdvanceListOrderDetil, "vq_TrnPrintAdvanceListOrder_Select", String.Format("advance_id='{0}' and advancedetil_line={1}", Me.tbl_TrnAdvanceDetil.Rows(i).Item("advance_id"), Me.tbl_TrnAdvanceDetil.Rows(i).Item("advancedetil_line")))

                    For k = 0 To Me.tbl_PrintAdvanceListOrderDetil.Rows.Count - 1

                        If Mid(clsUtil.IsDbNull(Me.tbl_PrintAdvanceListOrderDetil.Rows(k).Item("order_id"), ""), 1, 2) = "RO" Then
                            advancedetil_discount = clsUtil.IsDbNull(Me.tbl_PrintAdvanceListOrderDetil.Rows(k).Item("advancedetil_discount"), 0)
                        Else
                            If clsUtil.IsDbNull(Me.tbl_PrintAdvanceListOrderDetil.Rows(k).Item("advancedetil_discount"), 0) = (clsUtil.IsDbNull(Me.tbl_PrintAdvanceListOrderDetil.Rows(k).Item("orderdetil_discount"), 0) * clsUtil.IsDbNull(Me.tbl_PrintAdvanceListOrderDetil.Rows(k).Item("orderdetil_qty"), 0)) Then
                                advancedetil_discount = Math.Round(clsUtil.IsDbNull(Me.tbl_PrintAdvanceListOrderDetil.Rows(k).Item("advancedetil_discount"), 0), 0, MidpointRounding.ToEven)
                            Else
                                If Me.tbl_PrintAdvanceListOrderDetil.Rows(k).Item("advancedetil_foreignrate") = 1 Then
                                    advancedetil_discount = Math.Round((Math.Round(clsUtil.IsDbNull(Me.tbl_PrintAdvanceListOrderDetil.Rows(k).Item("advancedetil_discount"), 0), 2) * Me.tbl_PrintAdvanceListOrderDetil.Rows(k).Item("orderdetil_qty")), 2, MidpointRounding.AwayFromZero)
                                Else
                                    advancedetil_discount = Math.Round((Math.Round(clsUtil.IsDbNull(Me.tbl_PrintAdvanceListOrderDetil.Rows(k).Item("advancedetil_discount"), 0), 2) * Me.tbl_PrintAdvanceListOrderDetil.Rows(k).Item("orderdetil_qty")), 2, MidpointRounding.AwayFromZero) '(clsUtil.IsDbNull(Me.tbl_PrintAdvanceListOrderDetil.Rows(k).Item("advancedetil_discount"), 0) * clsUtil.IsDbNull(Me.tbl_PrintAdvanceListOrderDetil.Rows(k).Item("orderdetil_qty"), 0))
                                End If

                            End If
                        End If

                        amount_real = (clsUtil.IsDbNull(Me.tbl_PrintAdvanceListOrderDetil.Rows(k).Item("amount_advance"), 0) _
                       * clsUtil.IsDbNull(Me.tbl_PrintAdvanceListOrderDetil.Rows(k).Item("advancedetil_foreignrate"), 0)) _
                       - (advancedetil_discount * _
                       clsUtil.IsDbNull(Me.tbl_PrintAdvanceListOrderDetil.Rows(k).Item("advancedetil_foreignrate"), 0))

                        pph_persen = clsUtil.IsDbNull(Me.tbl_PrintAdvanceListOrderDetil.Rows(k).Item("pph_persen"), 0)
                        ppn_persen = clsUtil.IsDbNull(Me.tbl_PrintAdvanceListOrderDetil.Rows(k).Item("ppn_persen"), 0)
                        amount_advance = clsUtil.IsDbNull(Me.tbl_PrintAdvanceListOrderDetil.Rows(k).Item("amount_advance"), 0)
                        ''''advancedetil_discount = clsUtil.IsDbNull(Me.tbl_PrintAdvanceListOrderDetil.Rows(k).Item("advancedetil_discount"), 0)
                        advancedetil_foreignrate = clsUtil.IsDbNull(Me.tbl_PrintAdvanceListOrderDetil.Rows(k).Item("advancedetil_foreignrate"), 0)
                        pph_amount = Math.Round((((amount_advance - advancedetil_discount) * (pph_persen / 100)) * advancedetil_foreignrate), 2, MidpointRounding.AwayFromZero)
                        ppn_amount = Math.Round((((amount_advance - advancedetil_discount) * (ppn_persen / 100)) * advancedetil_foreignrate), 2, MidpointRounding.AwayFromZero)

                        subtotal = clsUtil.IsDbNull(Me.tbl_PrintAdvanceListOrderDetil.Rows(k).Item("amount_subtotal"), 0) ''''(amount_real + amount_intercompay) + ppn_amount - pph_amount
                        total_pphamount += pph_amount
                        total_ppnamount += ppn_amount
                        total_subtotal += subtotal
                        total_discount += advancedetil_discount ''''clsUtil.IsDbNull(Me.tbl_PrintAdvanceListOrderDetil.Rows(k).Item("advancedetil_discount"), 0)

                        total_discountAdv += advancedetil_discount
                    Next

                    budget_amountdetail += .budget_amountdetail
                    Budget_amountforeign += .Budget_amountforeign

                    currency = .currency
                ElseIf clsUtil.IsDbNull(Me.tbl_TrnAdvanceDetil.Rows(i).Item("advancedetil_type"), String.Empty) = 0 Then
                    total_pphamount = 0
                    total_ppnamount = 0
                    total_subtotal = 0
                    total_discount = 0
                End If

                .total_discount = total_discount
                .total_pphamount = total_pphamount
                .total_ppnamount = total_ppnamount
                .total_subtotal = total_subtotal

                no = no + 1

            End With
            objDatalistDetil.Add(objPrintDetilAdvance)
        Next

        If currency <> 1 Then
            Me.adv_req = (Budget_amountforeign - total_discountAdv) * advancedetil_foreignrate
        Else
            Me.adv_req = (budget_amountdetail - total_discountAdv)
        End If

        Return objDatalistDetil
    End Function

    Private Function getApprovedFromTravel(ByVal _advance_id As String) As DataTable
        Dim tbl As DataTable = New DataTable

        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        dbCmd = New OleDb.OleDbCommand("vq_TrnAdvanceListSPD_SelectApprove_Report", dbConn)

        dbCmd.Parameters.Add("@advance_id", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@advance_id").Value = _advance_id
        dbCmd.CommandType = CommandType.StoredProcedure
        dbCmd.CommandTimeout = 0

        dbDA = New OleDb.OleDbDataAdapter(dbCmd)
        Dim cookie As Byte() = Nothing


        Try
            tbl.Clear()
            dbConn.Open()
            clsApplicationRole.SetAppRole(dbConn, cookie)
            dbDA.Fill(tbl)
        Catch ex As Exception
            Throw ex
        Finally
            clsApplicationRole.UnsetAppRole(dbConn, cookie)
            dbConn.Close()
        End Try

        Return tbl
    End Function

    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
#End Region

    Public Sub SetControls_LockingTransactionTryLocking() Implements ILocking.SetControls_LockingTransactionTryLocking
        Dim status As clsLockingTransaction.LockStatus

        status = locking.Status

        If Me._USER_TYPE = "STAFF" Then
            Select Case status
                Case clsLockingTransaction.LockStatus.Locked
                    Me.tbtnDel.Enabled = False
                    Me.tbtnSave.Enabled = False
                Case clsLockingTransaction.LockStatus.LockedByMe
                    If Me.tbl_TrnJurnal_Temp.Rows(0).Item("jurnal_isdisabled").ToString = "1" Then
                        Me.tbtnDel.Enabled = False
                        Me.tbtnSave.Enabled = False
                        Me.locking.Clear()
                    ElseIf Me.tbl_TrnJurnal_Temp.Rows(0).Item("jurnal_isposted").ToString = "1" Then
                        Me.tbtnDel.Enabled = False
                        Me.tbtnSave.Enabled = False
                        Me.locking.Clear()
                    Else
                        Me.tbtnDel.Enabled = True
                        Me.tbtnSave.Enabled = True
                    End If
            End Select
        ElseIf Me._USER_TYPE = "SPV" Then
            Select Case status
                Case clsLockingTransaction.LockStatus.Locked
                    Me.tbtnDel.Enabled = False
                    Me.tbtnSave.Enabled = False
                    Me.btnPost.Enabled = False
                Case clsLockingTransaction.LockStatus.LockedByMe
                    Me.tbtnDel.Enabled = True
                    Me.tbtnSave.Enabled = True
                    Me.btnPost.Enabled = True
            End Select
        End If

    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Function FormatDgvTrnBankentrydetilReference(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        ' formating DgvTrnBankentrydetil_Kredit
        Dim cBankentry_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBankentrydetil_line As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cbankentry_date As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cbankacc_name As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cjurnaldetil_dk As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cjurnaldetilref_foreign As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cjurnaldetilref_foreignrate As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cjurnaldetilref_idr As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn

        cBankentry_id.Name = "bankentry_id"
        cBankentry_id.HeaderText = "ID"
        cBankentry_id.DataPropertyName = "bankentry_id"
        cBankentry_id.Width = 100
        cBankentry_id.Visible = True
        cBankentry_id.ReadOnly = False
        cBankentry_id.DefaultCellStyle.BackColor = Color.LightGray

        cBankentrydetil_line.Name = "bankentrydetil_line"
        cBankentrydetil_line.HeaderText = "Line"
        cBankentrydetil_line.DataPropertyName = "bankentrydetil_line"
        cBankentrydetil_line.Width = 50
        cBankentrydetil_line.Visible = True
        cBankentrydetil_line.ReadOnly = True
        cBankentrydetil_line.DefaultCellStyle.BackColor = Color.LightGray

        cbankentry_date.Name = "bankentry_date"
        cbankentry_date.HeaderText = "Date"
        cbankentry_date.DataPropertyName = "bankentry_date"
        cbankentry_date.Width = 100
        cbankentry_date.Visible = True
        cbankentry_date.ReadOnly = False
        cbankentry_date.DefaultCellStyle.BackColor = Color.LightGray

        cbankacc_name.Name = "bankacc_name"
        cbankacc_name.HeaderText = "Bank"
        cbankacc_name.DataPropertyName = "bankacc_name"
        cbankacc_name.Width = 120
        cbankacc_name.Visible = True
        cbankacc_name.ReadOnly = True
        cbankacc_name.DefaultCellStyle.BackColor = Color.LightGray

        cjurnaldetil_dk.Name = "jurnaldetil_dk"
        cjurnaldetil_dk.HeaderText = "D/K"
        cjurnaldetil_dk.DataPropertyName = "jurnaldetil_dk"
        cjurnaldetil_dk.Width = 50
        cjurnaldetil_dk.Visible = False
        cjurnaldetil_dk.ReadOnly = False
        cjurnaldetil_dk.DefaultCellStyle.BackColor = Color.LightGray

        cjurnaldetilref_foreign.Name = "jurnaldetilref_foreign"
        cjurnaldetilref_foreign.HeaderText = "Amount"
        cjurnaldetilref_foreign.DataPropertyName = "jurnaldetilref_foreign"
        cjurnaldetilref_foreign.Width = 200
        cjurnaldetilref_foreign.Visible = True
        cjurnaldetilref_foreign.ReadOnly = True
        cjurnaldetilref_foreign.DefaultCellStyle.BackColor = Color.LightGray
        cjurnaldetilref_foreign.DefaultCellStyle.Format = "#,##0.00"

        cjurnaldetilref_foreignrate.Name = "jurnaldetilref_foreignrate"
        cjurnaldetilref_foreignrate.HeaderText = "Rate"
        cjurnaldetilref_foreignrate.DataPropertyName = "jurnaldetilref_foreignrate"
        cjurnaldetilref_foreignrate.Width = 100
        cjurnaldetilref_foreignrate.Visible = False
        cjurnaldetilref_foreignrate.ReadOnly = True
        cjurnaldetilref_foreignrate.DefaultCellStyle.BackColor = Color.LightGray
        cjurnaldetilref_foreignrate.DefaultCellStyle.Format = "#,##0.00"

        cjurnaldetilref_idr.Name = "jurnaldetilref_idr"
        cjurnaldetilref_idr.HeaderText = "Curr."
        cjurnaldetilref_idr.DataPropertyName = "jurnaldetilref_idr"
        cjurnaldetilref_idr.Width = 75
        cjurnaldetilref_idr.Visible = False
        cjurnaldetilref_idr.ReadOnly = True
        cjurnaldetilref_idr.DefaultCellStyle.BackColor = Color.LightGray
        cjurnaldetilref_idr.DefaultCellStyle.Format = "#,##0"

        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
        {cBankentry_id, cBankentrydetil_line, cbankentry_date, cbankacc_name, cjurnaldetil_dk, cjurnaldetilref_foreign, cjurnaldetilref_foreignrate, cjurnaldetilref_idr})

        objDgv.AutoGenerateColumns = False
    End Function

    Private Sub obj_Jurnal_bookdate_ValueChanged(sender As Object, e As EventArgs) Handles obj_Jurnal_bookdate.ValueChanged
        Dim periodebookdate As String = String.Empty
        Dim tbl_periode As DataTable = New DataTable
        tbl_periode.Clear()
        Me.DataFill(tbl_periode, "ms_MstPeriodeCombo_Select", String.Format("channel_id = '{0}' AND MONTH(periode_datestart) = MONTH('{1}')AND YEAR(periode_datestart) = YEAR('{1}')", Me._CHANNEL, Format(Me.obj_Jurnal_bookdate.Value, "yyyy/MM/dd").ToString))
        If tbl_periode.Rows.Count <> 0 Then
            periodebookdate = tbl_periode.Rows(0).Item("periode_id")
            Me.obj_Periode_id.SelectedValue = periodebookdate
        End If
    End Sub

    Private Function tanya_date_sebelum_posting() As String
        Dim tanya As String = MsgBox("")
        Dim monthnow As Integer = Month(Date.Now)
        Dim yearnow As Integer = Year(Date.Now)
        Dim tbl_cek As DataTable = New DataTable()
        Dim monthbookdate As Integer = 0
        Dim yearbookdate As Integer = 0
        Dim msg As String = ""
        tbl_cek.Clear()
        Me.DataFill(tbl_cek, "act_TrnJurnal_Selectcekstat", String.Format(" jurnal_id = '{0}' ", Me.obj_Jurnal_id.Text))
        monthbookdate = Month(tbl_cek.Rows(0).Item("jurnal_bookdate"))
        yearbookdate = Year(tbl_cek.Rows(0).Item("jurnal_bookdate"))

        If monthnow <> monthbookdate Then
            msg = "Bulan bookdate tidak sama dengan bulan yang sedang berjalan" & vbCrLf & "Anda yakin untuk posting ?"
        End If

        If yearnow <> yearbookdate Then
            msg = "Tahun bookdate tidak sama dengan tahun yang sedang berjalan" & vbCrLf & "Anda yakin untuk posting ?"
        End If

        Return msg
    End Function
End Class