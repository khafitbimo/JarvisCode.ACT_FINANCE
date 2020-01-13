'================================================== 
' Created Date: 9/20/2010 10:39 PM

Public Class dlgTrnJurnalAddInvoice_selectRD
    Private CloseButtonIsPressed As Boolean
    Private myOwner As System.Windows.Forms.IWin32Window

    Private retObj As Object
    Private DSN As String
    Private dataFiller As clsDataFiller
    Private channel_id As String
    Private rekanan_id As Decimal
    Private jurnal_id As String
    Private jurnal_line As Decimal
    Private jurnal_amount As Decimal
    'Private rate As Decimal

    Private tbl_MstRekananCombo As DataTable = clsDataset.CreateTblMstRekananCombo
    Private tbl_tandaTerima_detil As DataTable = CreateTblTrnJurnalDetilSelectRD()
    Private tbl_exception As New DataTable

    Sub New(ByVal DSN As String, ByVal tbl_MstRekananCombo As DataTable, ByVal channel_id As String)
        Me.InitializeComponent()
        Me.channel_id = channel_id
        Me.DSN = DSN
        Me.dataFiller = New clsDataFiller(DSN)
        Me.tbl_MstRekananCombo = tbl_MstRekananCombo

    End Sub

    Public Shadows Function OpenDialog(ByVal owner As System.Windows.Forms.IWin32Window, _
                                        ByVal row As DataGridViewRow, ByVal tbl_exception As DataTable, Optional ByVal totalRemainPVListAP As Integer = 0) As Object

        Me.rekanan_id = row.Cells("rekanan_id").Value
        Me.jurnal_id = row.Cells("jurnal_id").Value
        Me.jurnal_line = row.Cells("jurnaldetil_line").Value
        Me.jurnal_amount = row.Cells("jurnaldetil_foreign").Value

        'Kondisi untuk PV-ListAP 08 Oktober 2015 By. Ari MDP2
        '=====================================================
        If totalRemainPVListAP <> 0 Then
            Me.jurnal_line = 0
            Me.jurnal_amount = totalRemainPVListAP
        End If
        '=====================================================

        'Me.rate = row.Cells("jurnaldetil_foreignrate").Value
        Me.Cursor = Cursors.Default
        Me.tbl_exception = tbl_exception
        Me.myOwner = owner
        MyBase.ShowDialog(owner)
        Return retObj


    End Function

    Function CreateTblTrnJurnalDetilSelectRD() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("tandaterima_check", GetType(System.Boolean)))
        tbl.Columns.Add(New DataColumn("tandaterima_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("tandaterima_line", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("tandaterima_descr", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("remaks", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("order_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("channel_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("rekanan_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("currency_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("currency_shortname", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("tandaterima_total", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("tandaterima_foreignrate", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("tandaterima_foreignreal", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("tandaterima_idrreal", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("tandaterima_invoicedate", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("sum_amount_foreign_tandaterima", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("outstanding_remaining_foreign", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("amount_foreign", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("amount_foreignrate", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("amount_idr", GetType(System.Decimal)))
        

        '-------------------------------
        'Default Value: 
        tbl.Columns("tandaterima_check").DefaultValue = False
        tbl.Columns("tandaterima_id").DefaultValue = ""
        tbl.Columns("tandaterima_line").DefaultValue = 0
        tbl.Columns("tandaterima_descr").DefaultValue = ""
        tbl.Columns("remaks").DefaultValue = ""
        tbl.Columns("channel_id").DefaultValue = ""
        tbl.Columns("rekanan_id").DefaultValue = 0
        tbl.Columns("currency_id").DefaultValue = 0
        tbl.Columns("currency_shortname").DefaultValue = ""
        tbl.Columns("tandaterima_total").DefaultValue = 0
        tbl.Columns("tandaterima_foreignrate").DefaultValue = 0
        tbl.Columns("tandaterima_foreignreal").DefaultValue = 0
        tbl.Columns("tandaterima_idrreal").DefaultValue = 0
        tbl.Columns("tandaterima_invoicedate").DefaultValue = Now.Date
        tbl.Columns("sum_amount_foreign_tandaterima").DefaultValue = 0
        tbl.Columns("outstanding_remaining_foreign").DefaultValue = 0
        tbl.Columns("amount_foreign").DefaultValue = 0
        tbl.Columns("amount_foreignrate").DefaultValue = 0
        tbl.Columns("amount_idr").DefaultValue = 0

        Return tbl
    End Function

    Function CreateTblTrnJurnalReferenceTandaterima() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("jurnal_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("jurnal_line", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("tandaterima_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("tandaterima_line", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("tandaterima_invoiceno", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("currency_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("amount_foreign", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("amount_foreignrate", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("amount_idr", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("create_by", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("create_dt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("modify_by", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("modify_dt", GetType(System.DateTime)))



        '-------------------------------
        'Default Value: 
        tbl.Columns("jurnal_id").DefaultValue = ""
        tbl.Columns("jurnal_line").DefaultValue = 0
        tbl.Columns("tandaterima_id").DefaultValue = ""
        tbl.Columns("tandaterima_line").DefaultValue = 0
        tbl.Columns("tandaterima_invoiceno").DefaultValue = ""
        tbl.Columns("currency_id").DefaultValue = 0
        tbl.Columns("amount_foreign").DefaultValue = 0
        tbl.Columns("amount_foreignrate").DefaultValue = 0
        tbl.Columns("amount_idr").DefaultValue = 0
        tbl.Columns("create_by").DefaultValue = ""
        tbl.Columns("create_dt").DefaultValue = Now.Date
        tbl.Columns("modify_by").DefaultValue = ""
        tbl.Columns("modify_dt").DefaultValue = Now.Date

        Return tbl
    End Function

    Private Function FormatDgvTandaterima(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean

        Dim cTandaterima_check As New DataGridViewCheckBoxColumn
        Dim cTandaterima_id As New DataGridViewTextBoxColumn
        Dim cTandaterima_line As New DataGridViewTextBoxColumn
        Dim cTandaterima_descr As New DataGridViewTextBoxColumn
        Dim cInvoiceId As New DataGridViewTextBoxColumn
        Dim cTandaterima_invoiceDate As New DataGridViewTextBoxColumn
        Dim cOrder_id As New DataGridViewTextBoxColumn

        Dim cChannel_id As New DataGridViewTextBoxColumn
        Dim cRekanan_id As New DataGridViewTextBoxColumn
        Dim cCurrency_id As New DataGridViewTextBoxColumn
        Dim cCurrency_shortname As New DataGridViewTextBoxColumn

        Dim cTandaterima_total As New DataGridViewTextBoxColumn
        Dim cTandaterima_foreignrate As New DataGridViewTextBoxColumn
        Dim cTandaterima_idrreal As New DataGridViewTextBoxColumn
        Dim cTandaterima_foreignreal As New DataGridViewTextBoxColumn

        Dim cSumAmountTandaTerima As New DataGridViewTextBoxColumn
        Dim cOutstanding_remain_foreign As New DataGridViewTextBoxColumn

        Dim cAmount_foreign As New DataGridViewTextBoxColumn
        Dim cAmount_foreignRate As New DataGridViewTextBoxColumn
        Dim cAmount_idr As New DataGridViewTextBoxColumn

        cTandaterima_check.Name = "Tandaterima_check"
        cTandaterima_check.HeaderText = "Pilih"
        cTandaterima_check.DataPropertyName = "tandaterima_check"
        cTandaterima_check.Width = 40
        cTandaterima_check.Visible = True
        cTandaterima_check.ReadOnly = False

        cTandaterima_id.Name = "tandaterima_id"
        cTandaterima_id.HeaderText = "ID"
        cTandaterima_id.DataPropertyName = "tandaterima_id"
        cTandaterima_id.Width = 100
        cTandaterima_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cTandaterima_id.DefaultCellStyle.BackColor = Color.Gainsboro
        cTandaterima_id.Visible = True
        cTandaterima_id.ReadOnly = True

        cTandaterima_line.Name = "tandaterima_line"
        cTandaterima_line.HeaderText = "Line"
        cTandaterima_line.DataPropertyName = "tandaterima_line"
        cTandaterima_line.Width = 30
        cTandaterima_line.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cTandaterima_line.DefaultCellStyle.BackColor = Color.Gainsboro
        cTandaterima_line.Visible = True
        cTandaterima_line.ReadOnly = True

        cTandaterima_descr.Name = "tandaterima_descr"
        cTandaterima_descr.HeaderText = "Descr."
        cTandaterima_descr.DataPropertyName = "tandaterima_descr"
        cTandaterima_descr.Width = 200
        cTandaterima_descr.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cTandaterima_descr.DefaultCellStyle.BackColor = Color.Gainsboro
        cTandaterima_descr.Visible = True
        cTandaterima_descr.ReadOnly = True

        cOrder_id.Name = "order_id"
        cOrder_id.HeaderText = "Order ID"
        cOrder_id.DataPropertyName = "order_id"
        cOrder_id.Width = 100
        cOrder_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cOrder_id.DefaultCellStyle.BackColor = Color.Gainsboro
        cOrder_id.Visible = True
        cOrder_id.ReadOnly = True

        cInvoiceId.Name = "remaks"
        cInvoiceId.HeaderText = "Invoice No."
        cInvoiceId.DataPropertyName = "remaks"
        cInvoiceId.Width = 150
        cInvoiceId.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cInvoiceId.DefaultCellStyle.BackColor = Color.Gainsboro
        cInvoiceId.Visible = True
        cInvoiceId.ReadOnly = True

        cTandaterima_invoiceDate.Name = "tandaterima_invoicedate"
        cTandaterima_invoiceDate.HeaderText = "Invoice Date"
        cTandaterima_invoiceDate.DataPropertyName = "tandaterima_invoicedate"
        cTandaterima_invoiceDate.Width = 100
        cTandaterima_invoiceDate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cTandaterima_invoiceDate.DefaultCellStyle.BackColor = Color.Gainsboro
        cTandaterima_invoiceDate.Visible = True
        cTandaterima_invoiceDate.ReadOnly = True

        cCurrency_shortname.Name = "currency_shortname"
        cCurrency_shortname.HeaderText = "Curr."
        cCurrency_shortname.DataPropertyName = "currency_shortname"
        cCurrency_shortname.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cCurrency_shortname.DefaultCellStyle.BackColor = Color.Gainsboro
        cCurrency_shortname.Width = 40
        cCurrency_shortname.Visible = True
        cCurrency_shortname.ReadOnly = True

        cTandaterima_total.Name = "tandaterima_total"
        cTandaterima_total.HeaderText = "Inv. Total"
        cTandaterima_total.DataPropertyName = "tandaterima_total"
        cTandaterima_total.Width = 150
        cTandaterima_total.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cTandaterima_total.DefaultCellStyle.BackColor = Color.Gainsboro
        cTandaterima_total.DefaultCellStyle.Format = "#,###,##0.00"
        cTandaterima_total.Visible = False
        cTandaterima_total.ReadOnly = True

        cOutstanding_remain_foreign.Name = "outstanding_remaining_foreign"
        cOutstanding_remain_foreign.HeaderText = "Remaining Foreign"
        cOutstanding_remain_foreign.DataPropertyName = "outstanding_remaining_foreign"
        cOutstanding_remain_foreign.Width = 150
        cOutstanding_remain_foreign.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cOutstanding_remain_foreign.DefaultCellStyle.BackColor = Color.Gainsboro
        cOutstanding_remain_foreign.DefaultCellStyle.Format = "#,###,##0.00"
        cOutstanding_remain_foreign.Visible = True
        cOutstanding_remain_foreign.ReadOnly = True

        cChannel_id.Name = "channel_id"
        cChannel_id.HeaderText = "Channel"
        cChannel_id.DataPropertyName = "channel_id"
        cChannel_id.Width = 100
        cChannel_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cChannel_id.Visible = False
        cChannel_id.ReadOnly = True

        cRekanan_id.Name = "rekanan_id"
        cRekanan_id.HeaderText = "Vendor"
        cRekanan_id.DataPropertyName = "rekanan_id"
        cRekanan_id.Width = 200
        cRekanan_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cRekanan_id.Visible = False
        cRekanan_id.ReadOnly = True


        cCurrency_id.Name = "currency_id"
        cCurrency_id.HeaderText = "Curr. ID"
        cCurrency_id.DataPropertyName = "currency_id"
        cCurrency_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cCurrency_id.Width = 40
        cCurrency_id.Visible = False
        cCurrency_id.ReadOnly = True


        cTandaterima_foreignrate.Name = "tandaterima_foreignrate"
        cTandaterima_foreignrate.HeaderText = "Rate"
        cTandaterima_foreignrate.DataPropertyName = "tandaterima_foreignrate"
        cTandaterima_foreignrate.Width = 50
        cTandaterima_foreignrate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cTandaterima_foreignrate.DefaultCellStyle.Format = "#,###,##0.00"
        cTandaterima_foreignrate.Visible = False
        cTandaterima_foreignrate.ReadOnly = False

        cTandaterima_idrreal.Name = "tandaterima_idrreal"
        cTandaterima_idrreal.HeaderText = "Amount IDR"
        cTandaterima_idrreal.DataPropertyName = "tandaterima_idrreal"
        cTandaterima_idrreal.Width = 120
        cTandaterima_idrreal.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cTandaterima_idrreal.DefaultCellStyle.Format = "#,###,##0.00"
        cTandaterima_idrreal.DefaultCellStyle.BackColor = Color.Gainsboro
        cTandaterima_idrreal.Visible = False
        cTandaterima_idrreal.ReadOnly = True

        cTandaterima_foreignreal.Name = "tandaterima_foreignreal"
        cTandaterima_foreignreal.HeaderText = "Amount Foreign"
        cTandaterima_foreignreal.DataPropertyName = "tandaterima_foreignreal"
        cTandaterima_foreignreal.Width = 120
        cTandaterima_foreignreal.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cTandaterima_foreignreal.DefaultCellStyle.BackColor = Color.Gainsboro
        cTandaterima_foreignreal.DefaultCellStyle.Format = "#,###,##0.00"
        cTandaterima_foreignreal.Visible = False
        cTandaterima_foreignreal.ReadOnly = True

        cSumAmountTandaTerima.Name = "sum_amount_foreign_tandaterima"
        cSumAmountTandaTerima.HeaderText = "sum_amount_foreign_tandaterima"
        cSumAmountTandaTerima.DataPropertyName = "sum_amount_foreign_tandaterima"
        cSumAmountTandaTerima.Width = 120
        cSumAmountTandaTerima.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cSumAmountTandaTerima.DefaultCellStyle.BackColor = Color.Gainsboro
        cSumAmountTandaTerima.DefaultCellStyle.Format = "#,###,##0.00"
        cSumAmountTandaTerima.Visible = False
        cSumAmountTandaTerima.ReadOnly = True

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
        cAmount_idr.DefaultCellStyle.BackColor = Color.Gainsboro
        cAmount_idr.DefaultCellStyle.Format = "#,###,##0.00"
        cAmount_idr.Visible = True
        cAmount_idr.ReadOnly = True

        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New DataGridViewColumn() _
        {cTandaterima_check, cTandaterima_id, cTandaterima_line, _
        cTandaterima_descr, cOrder_id, cInvoiceId, cTandaterima_invoiceDate, cCurrency_shortname, cTandaterima_total, cOutstanding_remain_foreign,
         cChannel_id, cRekanan_id, cCurrency_id, _
         cTandaterima_foreignrate, cTandaterima_foreignreal, cTandaterima_idrreal, _
          cSumAmountTandaTerima, cAmount_foreign, cAmount_foreignRate, cAmount_idr})
        objDgv.AllowUserToAddRows = False
        objDgv.AllowUserToDeleteRows = False
        objDgv.AllowUserToResizeRows = False

        objDgv.SelectionMode = DataGridViewSelectionMode.CellSelect
        objDgv.MultiSelect = False
        objDgv.Columns("tandaterima_line").Frozen = True


    End Function

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If Me.dlgTrnJurnalAddInvoice_SelectRD_FormError Then
            Exit Sub
        End If

        Dim tbl_jurnalTandaTerima_temp As DataTable = CreateTblTrnJurnalReferenceTandaterima()
        Dim thisRetObj As Collection = New Collection
        Dim row As DataRow
        If Me.tbl_tandaTerima_detil.Select("tandaterima_check = true").Length > 0 Then
            For i As Integer = 0 To tbl_tandaTerima_detil.Rows.Count - 1
                If tbl_tandaTerima_detil.Rows(i).Item("tandaterima_check") = True Then
                    row = tbl_jurnalTandaTerima_temp.NewRow()
                    row.Item("jurnal_id") = Me.jurnal_id
                    row.Item("jurnal_line") = Me.jurnal_line
                    row.Item("tandaterima_id") = tbl_tandaTerima_detil.Rows(i).Item("tandaterima_id")
                    row.Item("tandaterima_line") = tbl_tandaTerima_detil.Rows(i).Item("tandaterima_line")
                    row.Item("tandaterima_invoiceno") = tbl_tandaTerima_detil.Rows(i).Item("remaks")
                    row.Item("currency_id") = tbl_tandaTerima_detil.Rows(i).Item("currency_id")
                    row.Item("amount_foreign") = tbl_tandaTerima_detil.Rows(i).Item("amount_foreign")
                    row.Item("amount_foreignrate") = tbl_tandaTerima_detil.Rows(i).Item("amount_foreignrate")
                    row.Item("amount_idr") = tbl_tandaTerima_detil.Rows(i).Item("amount_idr")
                    tbl_jurnalTandaTerima_temp.Rows.Add(row)
                End If
            Next
        End If


        thisRetObj.Add(tbl_jurnalTandaTerima_temp.Copy(), "tblRefTandaTerima")
        retObj = thisRetObj

        Me.Close()
        'Me.Cursor = Cursors.WaitCursor
        ''dlgAddInvoice_save(tbl_jurnalTandaTerima_temp)
        'Me.Cursor = Cursors.Arrow
        'Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.CloseButtonIsPressed = False
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub dlgTrnJurnalAddInvoice_selectRD_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Cursor = Cursors.WaitCursor
        FormatDgvTandaterima(DgvSelectRd)
        Me.dataFiller.ComboFillNoSP(cbo_rekanan_id, "rekanan_id", "rekanan_name", Me.tbl_MstRekananCombo)

        Me.obj_Channel_id.Text = Me.channel_id
        Me.obj_jurnal_id.Text = Me.jurnal_id
        Me.obj_jurnal_line.Text = Me.jurnal_line
        Me.cbo_rekanan_id.SelectedValue = Me.rekanan_id

        Dim sum_foreign_rd As Decimal = 0
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter
        Dim criteria = " rekanan_id = " + Me.rekanan_id.ToString

        dbCmd = New OleDb.OleDbCommand("act_TrnJurnaldetil_PV_Select_RD", dbConn)
        dbCmd.Parameters.Add("@channel_id", Data.OleDb.OleDbType.VarWChar)
        dbCmd.Parameters("@channel_id").Value = channel_id
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarWChar)
        dbCmd.Parameters("@Criteria").Value = criteria

        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)
        Me.tbl_tandaTerima_detil.Clear()

        Dim cookie As Byte() = Nothing

        Try
            dbConn.Open()
            clsApplicationRole.SetAppRole(dbConn, cookie)
            dbDA.Fill(Me.tbl_tandaTerima_detil)

            If Me.tbl_exception.Rows.Count <> 0 Then
                Dim rows_exception As DataRow()
                Dim ref As String
                Dim line As Integer

                If Me.tbl_exception.Select(String.Format("jurnal_id = '{0}' and jurnal_line = {1} ", jurnal_id, jurnal_line)).Length <> 0 Then
                    Dim tbl_sum_amount As DataTable = Me.tbl_exception.Select(String.Format("jurnal_id = '{0}' and jurnal_line = {1} ", jurnal_id, jurnal_line)).CopyToDataTable
                    For i As Integer = 0 To tbl_sum_amount.Rows.Count - 1
                        sum_foreign_rd = sum_foreign_rd + tbl_sum_amount.Rows(i).Item("amount_foreign")
                    Next

                    For Each row As DataRow In Me.tbl_exception.Rows
                        If row.RowState <> DataRowState.Deleted Then
                            ref = row.Item("tandaterima_id")
                            line = row.Item("tandaterima_line")
                            rows_exception = Me.tbl_tandaTerima_detil.Select(String.Format(" tandaterima_id = '{0}' and tandaterima_line = {1}", ref, line))
                            If rows_exception.Length > 0 Then
                                For n As Integer = 0 To rows_exception.Length - 1
                                    rows_exception(n).Delete()
                                Next
                            End If
                        End If
                    Next
                End If

                Me.tbl_tandaTerima_detil.AcceptChanges()
            End If

            Me.obj_amount_credit.Text = Format(Me.jurnal_amount - sum_foreign_rd, "#,###,##0.00")
            Me.DgvSelectRd.DataSource = Me.tbl_tandaTerima_detil
        Catch ex As Exception
            MessageBox.Show(ex.Message, "dlgTrnJurnalSelect" & ": dlgTrnJurnalDetilSelect_LoadDetil()", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            clsApplicationRole.UnsetAppRole(dbConn, cookie)
            dbConn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub DgvSelectRd_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DgvSelectRd.CellValueChanged
        If e.ColumnIndex = 0 Then
            If DgvSelectRd.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = True Then
                DgvSelectRd.Rows(e.RowIndex).Cells("amount_foreign").Value = DgvSelectRd.Rows(e.RowIndex).Cells("outstanding_remaining_foreign").Value
                DgvSelectRd.Rows(e.RowIndex).Cells("amount_foreignrate").Value = DgvSelectRd.Rows(e.RowIndex).Cells("tandaterima_foreignrate").Value
                DgvSelectRd.Rows(e.RowIndex).Cells("amount_idr").Value = Val(DgvSelectRd.Rows(e.RowIndex).Cells("amount_foreign").Value) * Val(DgvSelectRd.Rows(e.RowIndex).Cells("tandaterima_foreignrate").Value)
            Else
                DgvSelectRd.Rows(e.RowIndex).Cells("amount_foreign").Value = 0
                DgvSelectRd.Rows(e.RowIndex).Cells("amount_foreignrate").Value = 0
                DgvSelectRd.Rows(e.RowIndex).Cells("amount_idr").Value = 0
            End If
        Else
            DgvSelectRd.Rows(e.RowIndex).Cells("amount_idr").Value = clsUtil.IsDbNull(DgvSelectRd.Rows(e.RowIndex).Cells("amount_foreign").Value, 0) * clsUtil.IsDbNull(DgvSelectRd.Rows(e.RowIndex).Cells("tandaterima_foreignrate").Value, 0)
        End If
        rowCalculate()
    End Sub

    Private Sub DgvSelectRd_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles DgvSelectRd.CurrentCellDirtyStateChanged
        If Me.DgvSelectRd.IsCurrentCellDirty Then
            Me.DgvSelectRd.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If

    End Sub

    Private Function dlgTrnJurnalAddInvoice_SelectRD_FormError() As Boolean
        Dim message As String = ""

        Try
            Dim i As Integer
            Dim cell_foreign_remain, cell_foreign As DataGridViewCell
            Dim error_found, row_error As Boolean
            Me.DgvSelectRd.EndEdit()
            Me.tbl_tandaTerima_detil.AcceptChanges()
            'header'
            error_found = False
            If CDec(obj_amount_credit.Text) < CDec(obj_amount.Text) Then
                ErrorProvider1.SetError(obj_amount, "Amount Foreign Tanda Terima lebih Besar dari Amount Credit")
                error_found = True
            Else
                ErrorProvider1.SetError(obj_amount, "")
            End If
            'end 
            For i = 0 To Me.DgvSelectRd.Rows.Count - 1
                If DgvSelectRd.Rows(i).Cells("tandaterima_check").Value = True Then
                    row_error = False
                    cell_foreign_remain = Me.DgvSelectRd.Rows(i).Cells("outstanding_remaining_foreign")
                    cell_foreign = Me.DgvSelectRd.Rows(i).Cells("amount_foreign")

                    If cell_foreign.Value > cell_foreign_remain.Value Then
                        cell_foreign.ErrorText = "Amount Foreign lebih besar dari Remaining Foreign"
                        row_error = True
                    Else
                        cell_foreign_remain.ErrorText = String.Empty
                        cell_foreign.ErrorText = String.Empty
                    End If

                    If row_error Then
                        error_found = True
                        Me.DgvSelectRd.Rows(i).DefaultCellStyle.BackColor = Color.Coral
                    End If
                End If
            Next
            If error_found Then
                Return True
            End If
            'FormatDgvTandaterima(DgvSelectRd)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return True
        End Try
        Return False
    End Function

    Private Function rowCalculate() As Boolean
        Dim amount As Decimal = 0
        Dim amount_idr As Decimal = 0
        For i As Integer = 0 To DgvSelectRd.Rows.Count - 1
            If DgvSelectRd.Rows(i).Cells("tandaterima_check").Value = True Then
                amount = amount + Val(clsUtil.IsDbNull(DgvSelectRd.Rows(i).Cells("amount_foreign").Value, 0))
                amount_idr = amount_idr + Val(clsUtil.IsDbNull(DgvSelectRd.Rows(i).Cells("amount_idr").Value, 0))
            End If
        Next
        obj_amount.Text = Format(amount, "#,###,##0.00")
        obj_amount_idr.Text = Format(amount_idr, "#,###,##0.00")
    End Function

   
    Private Sub obj_src_tandaterimaID_TextChanged(sender As Object, e As EventArgs) Handles obj_src_tandaterimaID.TextChanged, obj_src_orderID.TextChanged

        Dim filter As String = String.Empty

        Try
            filter = String.Format("tandaterima_id like '%{0}%' and order_id like '%{1}%'", Me.obj_src_tandaterimaID.Text, Me.obj_src_orderID.Text)

            Me.tbl_tandaTerima_detil.DefaultView.RowFilter = filter
        Catch ex As Exception
        End Try
    End Sub
End Class
