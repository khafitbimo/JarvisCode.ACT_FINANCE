Imports System.Data.Linq

Public Class uiTrnAdvanceDisbursementList
    Private Const mUiName As String = "Advance Disbursement Transaction"
    Private Const SHOW_SAVE_CONFIRMATION As Boolean = True

    Private tbl_MstChannel As DataTable = DatabaseUtils.CreateTbl(Of master_channel)()
    Private tbl_TrnAdvanceDisbursement As DataTable = DatabaseUtils.CreateTbl(Of view_transaksi_advancedisbursement)()
    Private tbl_MstProdType As DataTable = DatabaseUtils.CreateTbl(Of master_prodtype)()

    Enum ModuleType
        User
        BMA
        Finance
    End Enum

#Region " Window Parameter "
    Private _CHANNEL As String = "TAS"
    Private _ModuleType As ModuleType = ModuleType.Finance
#End Region

#Region " Overrides "
    Public Overrides Function btnLoad_Click() As Boolean
        Me.uiTrnAdvanceDisbursementList_Retrieve()

        Return MyBase.btnLoad_Click()
    End Function

    Public Overrides Function btnQuery_Click() As Boolean
        Me.PCHeader.Visible = Not Me.PCHeader.Visible

        Return MyBase.btnQuery_Click()
    End Function
#End Region

#Region " Layout & Init UI "
    Private Function InitLayoutUI() As Boolean
        Me.tbtnNew.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        Me.tbtnSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        Me.tbtnPrint.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        Me.tbtnPrintPreview.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        Me.tbtnDel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        Me.tbtnPosting.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        Me.tbtnUnposting.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        Me.tbtnQuery.PerformClick()

        Select Case Me._ModuleType
            Case ModuleType.User
                Me.colCirVoucherID.Visible = False
                Me.colCirVoucherLine.Visible = False
                Me.colBMAStatusOK.Visible = False
                Me.colBMAStatusPending.Visible = False
                Me.colFinApp.Visible = False
                Me.colFinAppBy.Visible = False
                Me.colFinAppDt.Visible = False
                Me.colBMAAppName.Visible = True
                Me.colBMAAppBy.Visible = True
                Me.colBMAAppDate.Visible = True
                Me.colDisbursementDate.AppearanceCell.BackColor = Color.White
                Me.colDisbursementDate.OptionsColumn.AllowEdit = True
                Me.colFinApp.OptionsColumn.AllowEdit = False
                Me.CEChannel.Checked = True
                Me.CEChannel.Enabled = False
                Me.GEChannel.Properties.ReadOnly = True
                Me.CEBudgetProdType.Visible = False
                Me.CCBudgetType.Visible = False
            Case ModuleType.BMA
                Me.colCirVoucherID.Visible = True
                Me.colCirVoucherLine.Visible = True
                Me.colBMAStatusOK.Visible = True
                Me.colBMAStatusPending.Visible = True
                Me.colFinApp.Visible = False
                Me.colFinAppBy.Visible = False
                Me.colFinAppDt.Visible = False
                Me.colBMAAppName.Visible = False
                Me.colBMAAppBy.Visible = False
                Me.colBMAAppDate.Visible = False
                Me.colDisbursementDate.OptionsColumn.AllowEdit = False
                Me.colBMAStatusOK.OptionsColumn.AllowEdit = True
                Me.colBMAStatusPending.OptionsColumn.AllowEdit = True
                Me.colFinApp.OptionsColumn.AllowEdit = False
                Me.colBMAStatusOK.VisibleIndex = 0
                Me.colBMAStatusPending.VisibleIndex = 1
                Me.CEChannel.Checked = False
                Me.CEChannel.Enabled = True
                Me.GEChannel.Properties.ReadOnly = False
                Me.CEFinApproval.Checked = True
                Me.CEBudgetProdType.Visible = True
                Me.CCBudgetType.Visible = True
            Case ModuleType.Finance
                Me.colCirVoucherID.Visible = True
                Me.colCirVoucherLine.Visible = True
                Me.colBMAStatusOK.Visible = False
                Me.colBMAStatusPending.Visible = False
                Me.colFinApp.Visible = True
                Me.colFinAppBy.Visible = True
                Me.colFinAppDt.Visible = True
                Me.colBMAAppName.Visible = True
                Me.colBMAAppBy.Visible = True
                Me.colBMAAppDate.Visible = True
                Me.colDisbursementDate.OptionsColumn.AllowEdit = True
                Me.colFinApp.OptionsColumn.AllowEdit = True
                Me.CEFinApproval.Checked = True
                Me.CBFinApproval.SelectedIndex = 0
                Me.colFinApp.VisibleIndex = 0
                Me.CEChannel.Checked = False
                Me.CEChannel.Enabled = True
                Me.GEChannel.Properties.ReadOnly = False
                Me.CEBudgetProdType.Visible = True
                Me.CCBudgetType.Visible = True
        End Select
    End Function
#End Region

#Region " User Defined Function "

    Private Sub uiTrnAdvanceDisbursementList_Retrieve()
        Dim db As New DataClassesFrmDataContext(Me.DSNLinq)
        Dim query As IQueryable(Of view_transaksi_advancedisbursement)

        db.OpenConnectionWithRole()

        Me.Cursor = Cursors.WaitCursor

        Try
            query = db.view_transaksi_advancedisbursements.Where(Function(p) p.advancedisbursement_isdisabled = 0)

            If CEChannel.Checked = True Then
                query = query.Where(Function(p) p.channel_id = Me.GEChannel.EditValue.ToString())
            End If

            If CEFinApproval.Checked = True Then
                query = query.Where(Function(p) p.fin_app = Me.CBFinApproval.SelectedIndex)
            End If

            'If CELimit.Checked = True Then
            '    query = query.Take(Integer.Parse(Me.TELimit.Text))
            'End If

            If CEAdvance.Checked = True Then
                Dim disbursement = From p As view_transaksi_advancedisbursementadvanceentryby In db.view_transaksi_advancedisbursementadvanceentrybies
                              Where p.advance_id = Me.TEAdvanceID.Text
                              Select p.advancedisbursement_id

                query = query.Where(Function(p) disbursement.Contains(p.advancedisbursement_id))
            End If

            If Me.CEBudgetProdType.Checked = True Then
                Dim prodtypes As New List(Of Decimal)

                For i As Integer = 0 To Me.CCBudgetType.Properties.Items.Count - 1
                    Dim item = Me.CCBudgetType.Properties.Items(i)

                    If item.CheckState = CheckState.Checked Then
                        prodtypes.Add(Decimal.Parse(item.Value))
                    End If
                Next

                query = query.Where(Function(p) (From x As view_transaksi_advancedisbursementadvanceentryby In db.view_transaksi_advancedisbursementadvanceentrybies
                                                 Where prodtypes.Contains(x.prodtype_id)
                                                 Select x.advancedisbursement_id).Contains(p.advancedisbursement_id))
            End If

            If CEPVID.Checked = True Then
                query = query.Where(Function(p) p.pv_id = Me.TEPVID.Text)
            End If

            If CEDisbursementDate.Checked = True Then
                query = query.Where(Function(p) p.advancedisbursement_date.Value.Date >= Me.DEDisbursementDate1.DateTime.Date _
                                            And p.advancedisbursement_date.Value.Date <= Me.DEDisbursementDate2.DateTime.Date)
            End If

            Select Case Me._ModuleType
                Case ModuleType.User
                    Dim advanceentryby = (From p As view_transaksi_advancedisbursementadvanceentryby In db.view_transaksi_advancedisbursementadvanceentrybies
                                     Where p.advance_entryby = Me.UserName
                                     Select p.advancedisbursement_id)

                    advanceentryby = advanceentryby.OrderByDescending(Function(p) p)
                    '  advanceentryby = advanceentryby.Take(Integer.Parse(Me.TELimit.Text))

                    query = query.OrderByDescending(Function(p) p.advancedisbursement_id)
                    query = query.Where(Function(p) advanceentryby.Contains(p.advancedisbursement_id))
                Case ModuleType.BMA
                    query = query.Where(Function(p) p.advancedisbursement_date IsNot Nothing)
                    query = query.OrderBy(Function(p) p.bma_app)
                Case ModuleType.Finance
                    query = query.OrderBy(Function(p) p.advancedisbursement_date)
            End Select

            Me.tbl_TrnAdvanceDisbursement.Clear()

            DatabaseUtils.DataFill(Me.tbl_TrnAdvanceDisbursement, query)
        Catch ex As Exception
            Throw ex
        Finally
            db.CloseConnectionWithRole()
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub uiTrnAdvanceDisbursementList_RetrieveChannel()
        Dim db As New DataClassesFrmDataContext(Me.DSNLinq)
        Dim channels As IQueryable(Of String)
        Dim query As IQueryable(Of master_channel) = Nothing

        db.OpenConnectionWithRole()

        Try
            Select Case Me._ModuleType
                Case ModuleType.User
                    channels = From p In db.master_userchannels
                               Where p.username = Me.UserName
                               Select p.channel_id

                    query = db.master_channels.Where(Function(p) channels.Contains(p.channel_id) And p.channel_isdisabled = 0)
                Case ModuleType.BMA, ModuleType.Finance
                    query = db.master_channels.Where(Function(p) p.channel_isdisabled = 0)
            End Select

            Me.tbl_MstChannel.Clear()
            DatabaseUtils.DataFill(Me.tbl_MstChannel, query)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        Finally
            db.CloseConnectionWithRole()
        End Try
    End Sub

    Private Sub uiTrnAdvanceDisbursementList_RetrieveProdType()
        Dim db As New DataClassesFrmDataContext(Me.DSNLinq)

        Try
            db.OpenConnectionWithRole()

            Me.tbl_MstProdType.Clear()
            DatabaseUtils.DataFill(Me.tbl_MstProdType, db.master_prodtypes)
        Catch ex As Exception
            Throw ex
        Finally
            db.CloseConnectionWithRole()
        End Try
    End Sub

    Private Sub uiTrnAdvanceDisbursementList_RefreshDataRow(ByVal id As String)
        Dim db As New DataClassesFrmDataContext(Me.DSNLinq)
        Dim disbursement As view_transaksi_advancedisbursement

        db.OpenConnectionWithRole()

        Me.Cursor = Cursors.WaitCursor
        Try
            disbursement = db.view_transaksi_advancedisbursements.Where(Function(p) p.advancedisbursement_id = id).FirstOrDefault()

            If disbursement IsNot Nothing Then
                Dim currentRow As DataRow = Me.GVAdvDisbursement.GetFocusedDataRow()

                clsUtil.EntityToDataRow(disbursement, currentRow)

                currentRow.AcceptChanges()
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        Finally
            db.CloseConnectionWithRole()

            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub uiTrnAdvanceDisbursementList_BMAApprove(ByVal bmaApp As Byte)
        Dim db As New DataClassesFrmDataContext(Me.DSNLinq)
        Dim id As String = Me.GVAdvDisbursement.GetFocusedRowCellValue(ColID).ToString()

        db.OpenConnectionWithRole()

        Me.Cursor = Cursors.WaitCursor

        Try
            db.act_TrnAdvanceDisbursement_BMAApprove(id, bmaApp)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        Finally
            db.CloseConnectionWithRole()

            Me.Cursor = Cursors.Default
        End Try

        Me.uiTrnAdvanceDisbursementList_RefreshDataRow(id)

        Me.GVAdvDisbursement.SetFocusedRowCellValue(colBMAStatusOK, Me.GVAdvDisbursement.GetFocusedDataRow().Item(colBMAStatusOK.FieldName))
        Me.GVAdvDisbursement.SetFocusedRowCellValue(colBMAStatusPending, Me.GVAdvDisbursement.GetFocusedDataRow().Item(colBMAStatusPending.FieldName))
    End Sub
#End Region

    Public Sub Form_Load(ByVal sender As Object)
        Dim objParameters As Collection = New Collection

        If Me.Browser IsNot Nothing Then
            Dim moduleType As String

            objParameters = Me.GetParameterCollection(Me.Parameter)
            Me._CHANNEL = Me.GetValueFromParameter(objParameters, "CHANNEL")
            moduleType = Me.GetValueFromParameter(objParameters, "MODULE_TYPE")

            Select Case moduleType.ToLower()
                Case "user"
                    Me._ModuleType = uiTrnAdvanceDisbursementList.ModuleType.User
                Case "bma"
                    Me._ModuleType = uiTrnAdvanceDisbursementList.ModuleType.BMA
                Case "finance"
                    Me._ModuleType = uiTrnAdvanceDisbursementList.ModuleType.Finance
            End Select
        End If

        If (Me.Browser IsNot Nothing And MyBase.Name = _Name) Or (Me.Browser Is Nothing And Application.ProductName <> _ProductName) Then
            Me.GCAdvDisbursement.DataSource = Me.tbl_TrnAdvanceDisbursement

            Me.InitLayoutUI()

            If Me._ModuleType = ModuleType.BMA Or Me._ModuleType = ModuleType.Finance Then
                Me.DEDisbursementDate1.DateTime = Date.Now
                Me.DEDisbursementDate2.DateTime = Date.Now
                Me.CEDisbursementDate.Checked = True
            End If

            Me.GEChannel.Properties.DataSource = Me.tbl_MstChannel
            Me.GEChannel.Properties.DisplayMember = "channel_name"
            Me.GEChannel.Properties.ValueMember = "channel_id"
            Me.GEChannel.EditValue = Me._CHANNEL

            Me.CCBudgetType.Properties.DataSource = Me.tbl_MstProdType
            Me.CCBudgetType.Properties.DisplayMember = "prodtype_name"
            Me.CCBudgetType.Properties.ValueMember = "prodtype_id"

            Me.uiTrnAdvanceDisbursementList_RetrieveChannel()
            Me.uiTrnAdvanceDisbursementList_RetrieveProdType()
        End If
    End Sub

    Private Sub uiTrnAdvanceDisbursementList_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Me.IsDevelopment = True Then
            Me.Form_Load(sender)
        End If
    End Sub

    Private Sub RepositoryItemButtonDate_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles RepositoryItemButtonDate.ButtonClick
        Dim db As New DataClassesFrmDataContext(Me.DSNLinq)
        Dim pv_id As String = Me.GVAdvDisbursement.GetFocusedRowCellValue(colPaymentVoucher).ToString()

        db.OpenConnectionWithRole()

        Try
            Select Case db.f_AdvanceDisbursement_CheckMaxPVAmount(pv_id)
                Case 0
                    If Me._ModuleType = ModuleType.Finance Then
                        MsgBox("Anda tidak dapat memasukan tanggal.", MsgBoxStyle.Exclamation)

                        Exit Sub
                    End If
                Case 1
                    If Me._ModuleType = ModuleType.User Then
                        MsgBox("Hanya finance yang dapat memasukan tanggal pada data ini, silahkan menghubungi finance.", MsgBoxStyle.Exclamation)

                        Exit Sub
                    End If
            End Select

            Dim dlg As New DlgDate()
            Dim disDate As Object = Me.GVAdvDisbursement.GetFocusedRowCellValue(colDisbursementDate)

            Me.Cursor = Cursors.WaitCursor

            If disDate Is DBNull.Value Then
                dlg.Value = Date.Now
            Else
                dlg.Value = disDate
            End If

            If dlg.ShowDialog() = DialogResult.OK Then
                Dim id As String = Me.GVAdvDisbursement.GetRowCellValue(Me.GVAdvDisbursement.FocusedRowHandle, ColID).ToString()

                db.act_TrnAdvanceDisbursement_UpdateDate(id, IIf(dlg.Value <> Nothing, dlg.Value, Nothing))

                Me.GVAdvDisbursement.SetRowCellValue(Me.GVAdvDisbursement.FocusedRowHandle,
                                                     colDisbursementDate,
                                                     IIf(dlg.Value <> Nothing, dlg.Value, DBNull.Value))
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        Finally
            db.CloseConnectionWithRole()
        End Try

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub RepositoryItemOK_CheckedChanged(sender As Object, e As EventArgs) Handles RepositoryItemOK.CheckedChanged
        Dim c As DevExpress.XtraEditors.CheckEdit = sender

        If c.CheckState = CheckState.Checked Then
            Me.uiTrnAdvanceDisbursementList_BMAApprove(1)
        ElseIf c.CheckState = CheckState.Unchecked Then
            Me.uiTrnAdvanceDisbursementList_BMAApprove(0)
        End If
    End Sub

    Private Sub RepositoryItemPending_CheckedChanged(sender As Object, e As EventArgs) Handles RepositoryItemPending.CheckedChanged
        Dim c As DevExpress.XtraEditors.CheckEdit = sender

        If c.CheckState = CheckState.Checked Then
            Me.uiTrnAdvanceDisbursementList_BMAApprove(2)
        ElseIf c.CheckState = CheckState.Unchecked Then
            Me.uiTrnAdvanceDisbursementList_BMAApprove(0)
        End If
    End Sub

    Private Sub RepositoryItemFinApp_CheckedChanged(sender As Object, e As EventArgs) Handles RepositoryItemFinApp.CheckedChanged
        Dim c As DevExpress.XtraEditors.CheckEdit = sender
        Dim db As New DataClassesFrmDataContext(Me.DSNLinq)
        Dim id As String = Me.GVAdvDisbursement.GetFocusedRowCellValue(ColID).ToString()

        db.OpenConnectionWithRole()

        Try
            Select Case c.CheckState
                Case CheckState.Checked
                    Dim disbursement As transaksi_advancedisbursement

                    disbursement = db.transaksi_advancedisbursements.Where(Function(p) p.advancedisbursement_id = id).FirstOrDefault()

                    If disbursement IsNot Nothing Then
                        If disbursement.bma_app <> 1 Then
                            Me.GVAdvDisbursement.SetFocusedRowCellValue(colFinApp, 0)

                            MsgBox("Tidak dapat di approve, menunggu persetujuan BMA.", MsgBoxStyle.Exclamation)

                            Exit Sub
                        End If
                    End If

                    db.act_TrnAdvanceDisbursement_FinApprove(id, 1)
                Case CheckState.Unchecked
                    db.act_TrnAdvanceDisbursement_FinApprove(id, 0)
            End Select
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        Finally
            db.CloseConnectionWithRole()
        End Try

        Me.uiTrnAdvanceDisbursementList_RefreshDataRow(id)
    End Sub

    Private Sub GVAdvDisbursement_CustomDrawRowIndicator(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs) Handles GVAdvDisbursement.CustomDrawRowIndicator
        If e.RowHandle > -1 Then
            e.Info.DisplayText = (e.RowHandle + 1).ToString()
        End If
    End Sub

    'Private Sub GVAdvDisbursement_CustomDrawCell(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs) Handles GVAdvDisbursement.CustomDrawCell
    '    'Select Case Me._ModuleType
    '    '    Case ModuleType.User
    '    '        If e.Column Is Me.colDisbursementDate Then
    '    '            Dim appBMA As Byte = Me.GVAdvDisbursement.GetRowCellValue(e.RowHandle, Me.colBMAApp)

    '    '            If appBMA > 0 Then
    '    '                e.Column.OptionsColumn.AllowEdit = False
    '    '            End If
    '    '        End If
    '    '    Case ModuleType.BMA
    '    '        If e.Column Is Me.colBMAStatusOK Or e.Column Is Me.colBMAStatusPending Then
    '    '            Dim appFin As Byte = Me.GVAdvDisbursement.GetRowCellValue(e.RowHandle, Me.colFinApp)

    '    '            If appFin > 0 Then
    '    '                e.Column.OptionsColumn.AllowEdit = False
    '    '            End If
    '    '        End If               
    '    'End Select
    'End Sub

    Private Sub GVAdvDisbursement_RowStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles GVAdvDisbursement.RowStyle
        Dim finApp As Byte = Me.GVAdvDisbursement.GetRowCellValue(e.RowHandle, colFinApp)
        Dim bmaApp As Byte = Me.GVAdvDisbursement.GetRowCellValue(e.RowHandle, colBMAApp)
        Dim userDate As Object = Me.GVAdvDisbursement.GetRowCellValue(e.RowHandle, colDisbursementDate)

        If finApp > 0 Then
            e.Appearance.BackColor = Color.PaleTurquoise
        ElseIf bmaApp > 0 Then
            If bmaApp = 1 Then
                e.Appearance.BackColor = Color.DarkSeaGreen
            ElseIf bmaApp = 2 Then
                e.Appearance.BackColor = Color.LightCoral
            End If
        ElseIf userDate IsNot DBNull.Value Then
            e.Appearance.BackColor = Color.Khaki
        ElseIf userDate Is DBNull.Value Then
            e.Appearance.BackColor = Color.Gainsboro
        End If

        Select Case Me._ModuleType
            Case ModuleType.Finance
                Me.colFinApp.AppearanceCell.BackColor = Color.White
            Case ModuleType.BMA
                If finApp = 0 Then
                    Me.colBMAStatusOK.AppearanceCell.BackColor = Color.White
                    Me.colBMAStatusPending.AppearanceCell.BackColor = Color.White
                Else
                    Me.colBMAStatusOK.AppearanceCell.BackColor = Nothing
                    Me.colBMAStatusPending.AppearanceCell.BackColor = Nothing
                End If
            Case ModuleType.User
                If bmaApp = 0 Then
                    Me.colDisbursementDate.AppearanceCell.BackColor = Color.White
                Else
                    Me.colDisbursementDate.AppearanceCell.BackColor = Nothing
                End If
        End Select
    End Sub

    Private Sub RepositoryItemAdvance_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles RepositoryItemAdvance.ButtonClick
        Dim id As String = Me.GVAdvDisbursement.GetRowCellValue(Me.GVAdvDisbursement.FocusedRowHandle, ColID)
        Dim dlg As New DlgAdvanceDisbursement_Advance(id, DSNLinq)

        Me.Cursor = Cursors.WaitCursor

        dlg.ShowDialog()

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub RepositoryItemHistory_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles RepositoryItemHistory.ButtonClick
        Dim id As String = Me.GVAdvDisbursement.GetRowCellValue(Me.GVAdvDisbursement.FocusedRowHandle, ColID)
        Dim dlg As New DlgAdvanceDisbursement_History(id, DSNLinq)

        Me.Cursor = Cursors.WaitCursor
        dlg.ShowDialog()
        Me.Cursor = Cursors.Default
    End Sub
End Class

