Imports System.Windows.Forms
Imports System.Data.OleDb


Public Class dlgTrnJurnal_PV_Add_invoice
    Private DSN As String
    Private datafiller As clsDataFiller
    Private tbl_TrnJurnalDetil_Invoice As New DataTable
    Private tbl_jurnalReference_TandaTerima As DataTable = CreateTblTrnJurnalReference_tandaterima()
    Private rekanan_id As Decimal
    Private channel_id As String

    Public Function CreateTblTrnJurnalReference_tandaterima() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("jurnal_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("jurnaldetil_line", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("tandaterima_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("tandaterima_line", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("tandaterima_invoiceno", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("currency_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("amount_foreign", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("amount_foreignrate", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("amount_idr", GetType(System.Decimal)))
        '-------------------------------
        'Default Value: 
        tbl.Columns("jurnal_id").DefaultValue = ""
        tbl.Columns("jurnaldetil_line").DefaultValue = 0
        tbl.Columns("tandaterima_id").DefaultValue = ""
        tbl.Columns("tandaterima_line").DefaultValue = 0
        tbl.Columns("tandaterima_invoiceno").DefaultValue = ""
        tbl.Columns("currency_id").DefaultValue = ""
        tbl.Columns("amount_foreign").DefaultValue = 0
        tbl.Columns("amount_foreignrate").DefaultValue = 0
        tbl.Columns("amount_idr").DefaultValue = 0
        Return tbl

    End Function

    Private Function BindingStop() As Boolean
        'stop binding
        Me.obj_Jurnal_id.DataBindings.Clear()
        Me.obj_jurnal_line.DataBindings.Clear()
        Me.obj_RD_Id.DataBindings.Clear()
        Me.obj_RD_line.DataBindings.Clear()
        Me.obj_invoice_id.DataBindings.Clear()
        Me.cbo_currency_id.DataBindings.Clear()
        Me.obj_amount_foreign.DataBindings.Clear()
        Me.obj_rate.DataBindings.Clear()
        Me.obj_amount_idr.DataBindings.Clear()

        Return True
    End Function

    Private Function BindingStart() As Boolean
        'start binding
        Me.obj_jurnal_id.DataBindings.Add(New Binding("Text", Me.tbl_jurnalReference_TandaTerima, "jurnal_id"))
        Me.obj_jurnal_line.DataBindings.Add(New Binding("Text", Me.tbl_jurnalReference_TandaTerima, "jurnaldetil_line"))
        Me.obj_RD_Id.DataBindings.Add(New Binding("Text", Me.tbl_jurnalReference_TandaTerima, "tandaterima_id"))
        Me.obj_RD_line.DataBindings.Add(New Binding("Text", Me.tbl_jurnalReference_TandaTerima, "tandaterima_line"))
        Me.obj_invoice_id.DataBindings.Add(New Binding("Text", Me.tbl_jurnalReference_TandaTerima, "tandaterima_invoiceno"))
        Me.cbo_currency_id.DataBindings.Add(New Binding("SelectedValue", Me.tbl_jurnalReference_TandaTerima, "currency_id"))
        Me.obj_amount_foreign.DataBindings.Add(New Binding("Text", Me.tbl_jurnalReference_TandaTerima, "amount_foreign"))
        Me.obj_rate.DataBindings.Add(New Binding("Text", Me.tbl_jurnalReference_TandaTerima, "amount_foreignrate"))
        Me.obj_amount_idr.DataBindings.Add(New Binding("Text", Me.tbl_jurnalReference_TandaTerima, "amount_idr"))
        Return True
    End Function

    Sub New(ByVal DSN As String, ByVal rekanan_id As Decimal, ByVal channel_id As String)
        Me.InitializeComponent()
        Me.DSN = DSN
        Me.datafiller = New clsDataFiller(DSN)
        Me.rekanan_id = rekanan_id
        Me.channel_id = channel_id
    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btn_select_RD_Click(sender As Object, e As EventArgs) Handles btn_select_RD.Click
        'Dim dlg As New dlgTrnJurnalAddInvoice_selectRD(Me.DSN, Me.rekanan_id, Me.channel_id)
        'Dim retData As Collection
        'Dim retObj As Object
        'Dim amount_foreign, tandaterima_line, tandaterima_rate As Decimal
        'Dim tandaterima_id, tandaterima_invoice_id As String

        'retObj = dlg.OpenDialog(Me)
        'If retObj IsNot Nothing Then
        '    retData = CType(retObj, Collection)
        '    tandaterima_id = CType(retData.Item("tandaterima_id"), String)
        '    tandaterima_line = CType(retData.Item("tandaterima_line"), Decimal)
        '    tandaterima_invoice_id = CType(retData.Item("remaks"), String)
        '    amount_foreign = CType(retData.Item("outstanding_inv_sisa"), Decimal)
        '    tandaterima_rate = CType(retData.Item("tandaterima_foreignrate"), Decimal)
        '    Me.obj_RD_Id.Text = tandaterima_id
        '    Me.obj_RD_line.Text = tandaterima_line
        '    Me.obj_invoice_id.Text = tandaterima_invoice_id
        '    Me.obj_amount_foreign.EditValue = amount_foreign 'Format(amount_foreign, "#,##0")
        '    Me.obj_rate.EditValue = tandaterima_rate
        '    Me.obj_amount_foreign.Focus()
        'End If

        'Dim dlg As New dlgTrnJurnal_PV_select_RD(Me.DSN, Me.rekanan_id, Me.channel_id)


        'If dlg.ShowDialog = DialogResult.OK Then
        'Me.obj_RD_Id.Text = dlg.dgvTrnJurnalPVselectRD.GetRowCellValue(dlg.dgvTrnJurnalPVselectRD.FocusedRowHandle, "tandaterima_id").ToString
        'Me.obj_RD_line.Text = dlg.dgvTrnJurnalPVselectRD.GetRowCellValue(dlg.dgvTrnJurnalPVselectRD.FocusedRowHandle, "tandaterima_line").ToString
        'Me.obj_invoice_id.Text = dlg.dgvTrnJurnalPVselectRD.GetRowCellValue(dlg.dgvTrnJurnalPVselectRD.FocusedRowHandle, "remaks").ToString
        'Me.obj_amount_foreign.EditValue = Format(dlg.dgvTrnJurnalPVselectRD.GetRowCellValue(dlg.dgvTrnJurnalPVselectRD.FocusedRowHandle, "outstanding_inv_sisa"), "#,##0")
        'Me.obj_rate.Text = dlg.dgvTrnJurnalPVselectRD.GetRowCellValue(dlg.dgvTrnJurnalPVselectRD.FocusedRowHandle, "tandaterima_foreignrate").ToString
        'Me.obj_amount_foreign.Focus()

        'End If
    End Sub

    Private Sub obj_amount_foreign_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles obj_amount_foreign.EditValueChanging, obj_rate.EditValueChanging, obj_amount_idr.EditValueChanging
        'obj_amount_idr.Text = (CDec(IIf(obj_amount_foreign.EditValue = "", 0, obj_amount_foreign.EditValue)) * CDec(IIf(obj_rate.Text = "", 0, obj_rate.Text))).ToString
        'obj_amount_foreign.Text = Format(CDec(IIf(obj_amount_foreign.Text = "", 0, obj_amount_foreign.Text)), "#,##0.00")
    End Sub

    Private Sub obj_amount_foreign_KeyPress(sender As Object, e As KeyPressEventArgs) Handles obj_amount_foreign.KeyPress, obj_rate.KeyPress, obj_amount_idr.KeyPress
        If e.KeyChar >= "0" And e.KeyChar <= "9" Then 'Allows only numbers
            e.KeyChar = e.KeyChar
        ElseIf Asc(e.KeyChar) = 8 Then
            e.KeyChar = e.KeyChar
        ElseIf e.KeyChar = ","c Then
            e.KeyChar = ","c
        ElseIf e.KeyChar = "." Then
            If obj_amount_foreign.Text.IndexOf(".") > -1 Then
                e.Handled = True
                Beep()
            End If
        Else
            e.Handled = True
            Beep()
        End If
    End Sub

    Private Sub obj_amount_foreign_TextChanged(sender As Object, e As EventArgs) Handles obj_rate.TextChanged, obj_amount_foreign.TextChanged
        obj_amount_idr.EditValue = (CDec(IIf(obj_amount_foreign.EditValue = "", 0, obj_amount_foreign.EditValue)) * CDec(IIf(obj_rate.EditValue = "", 0, obj_rate.EditValue))).ToString
        'obj_amount_foreign.Text = Format(CDec(obj_amount_foreign.Text), "#,##0.00")
        'obj_amount_idr.Text = Format(CDec(obj_amount_idr.Text), "#,##0.00")
    End Sub

End Class
