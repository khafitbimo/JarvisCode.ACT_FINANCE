'================================================== 
' Yanuar Andriyana Putra
' TransTV
' Created Date: 11/24/2010 5:32 PM
 
Public Class uiTrnCirculationVoucher
    Private Const mUiName As String = "Transaksi Circulation Voucher"
    Private Const SHOW_SAVE_CONFIRMATION As Boolean = True

    Private Event FormBeforeOpenRow(ByRef id As Object)
    Private Event FormAfterOpenRow(ByRef id As Object)
    Private Event FormBeforeSave(ByRef id As Object)
    Private Event FormAfterSave(ByRef id As Object, ByVal result As FormSaveResult)
    Private Event FormBeforeNew()
    Private Event FormBeforeDelete(ByRef id As Object)
    Private Event FormAfterDelete(ByRef id As Object)
 
    Private DATA_ISLOCKED As Boolean

    Private objFormError As Windows.Forms.ErrorProvider = New Windows.Forms.ErrorProvider

    'Table For Transaction
    Private tbl_TrnCirculationvoucher As DataTable = clsDataset.CreateTblTrnCirculationvoucher()
    Private tbl_TrnCirculationvoucher_Temp As DataTable = clsDataset.CreateTblTrnCirculationvoucher()
    Private tbl_TrnCirculationvoucherdetil As DataTable = clsDataset.CreateTblTrnCirculationvoucherdetil()

    'Table For Master
    Private tbl_MstAuthSign As DataTable = clsDataset.CreateTblMstAuthsign()
    Private tbl_MstCurrencyGrid As DataTable = clsDataset.CreateTblMstCurrencyCombo()
    Private tbl_MstChannelSearch As DataTable = clsDataset.CreateTblMstChannel()
    Private tbl_MstUserSearch As DataTable = clsDataset.CreateTblMstUserCombo()

    'Variable For Additional Button
    Friend WithEvents btnApproved As ToolStripButton = New ToolStripButton
    Friend WithEvents btnUnApproved As ToolStripButton = New ToolStripButton
    Friend WithEvents btnExcel As ToolStripButton = New ToolStripButton

    'Variable For print
    Private tbl_Print As DataTable = clsDataset.CreateTblTrnCirculationvoucher
    Private tbl_PrintDetil As DataTable = clsDataset.CreateTblTrnCirculationvoucherdetil
    Private m_streams As IList(Of System.IO.Stream)
    Private m_currentPageIndex As Integer
    Private objPrintHeader As DataSource.clsRptCirculationVoucher
    Private objDatalistDetil As ArrayList
    Private strChannel_id As String
    Private strChannel_nameReport As String
    Private strChannel_address As String
    Private strCirculation_id As String
    Private strCirculation_date As DateTime
    Private strRevisi As String
    Private strDescr As String

    'variabled additional
    Private parTotal_amount As Decimal
    Private parTotal_foreign As Decimal
    Private _LoadComboInLoadData As Boolean = False

#Region " Window Parameter "
    Private _CHANNEL As String = "NTV"
    Private _CHANNEL_CANBE_CHANGED As Boolean = False
    Private _CHANNEL_CANBE_BROWSED As Boolean = False
    Private _JURNALTYPE As String = "CV"
    ' TODO: Buat variabel untuk menampung parameter window 
#End Region
#Region " Additional Overrides "
    Private Sub btnApproved_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApproved.Click
        If Me.DgvTrnCirculationvoucher.Rows.Count > 0 Then
            If Me.obj_Circulation_id.Text <> String.Empty Then
                DataIsApproved(1)
            Else
                MsgBox("Data harus di simpan dulu")
            End If
        End If
    End Sub
    Private Sub btnCanceled_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUnApproved.Click
        If Me.DgvTrnCirculationvoucher.Rows.Count > 0 Then
            DataIsApproved(0)
        End If
    End Sub
    Private Sub btnExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExcel.Click
        Me.Cursor = Cursors.WaitCursor

        If Me.tbl_TrnCirculationvoucherdetil.Rows.Count <= 0 Then
            MessageBox.Show("Cannot export empty table.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            If Me.tbl_TrnCirculationvoucherdetil.Rows.Count - 1 > 65534 Then
                MessageBox.Show("The row number is exceed the limit of maximum Ms-Excel`s row.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                Me.pnlLoading.Visible = True
                Me.lblProgress.Visible = True
                Me.ProgressBar1.Visible = True
                Me.ProgressBar1.Value = 0

                Dim ColumnIndex As Integer = 0
                Dim RowIndex As Integer = 0
                Dim xl As Excel.Application = New Excel.Application
                Dim xlBook As Excel.Workbook = xl.Workbooks.Add
                Dim xlWorksheet As Excel.Worksheet = CType(xlBook.Worksheets(1), Excel.Worksheet)

                xl.Visible = False

                Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

                Try
                    xlWorksheet.Cells(1, 1).Value = "Ref ID"
                    xlWorksheet.Cells(1, 2).Value = "Bilyet Type"
                    xlWorksheet.Cells(1, 3).Value = "Bilyet"
                    xlWorksheet.Cells(1, 4).Value = "Rekanan"
                    xlWorksheet.Cells(1, 5).Value = "Description"
                    xlWorksheet.Cells(1, 6).Value = "Amount"

                    For Each row As System.Data.DataRow In Me.tbl_TrnCirculationvoucherdetil.Rows
                        RowIndex = RowIndex + 1
                        ColumnIndex = 0

                        If Mid(row.Item("circulationdetil_reference").ToString, 1, 1) = "=" Then xlWorksheet.Cells(RowIndex + 1, 1).Value = "'" & row.Item("circulationdetil_reference").ToString Else xlWorksheet.Cells(RowIndex + 1, 1).Value = row.Item("circulationdetil_reference").ToString

                        If Mid(row.Item("payment").ToString, 1, 1) = "=" Then xlWorksheet.Cells(RowIndex + 1, 2).Value = "'" & row.Item("payment").ToString Else xlWorksheet.Cells(RowIndex + 1, 2).Value = row.Item("payment").ToString

                        If Mid(row.Item("circulationdetil_bilyet").ToString, 1, 1) = "=" Then xlWorksheet.Cells(RowIndex + 1, 3).Value = "'" & row.Item("circulationdetil_bilyet").ToString Else xlWorksheet.Cells(RowIndex + 1, 3).Value = row.Item("circulationdetil_bilyet").ToString

                        If Mid(row.Item("rekanan_name").ToString, 1, 1) = "=" Then xlWorksheet.Cells(RowIndex + 1, 4).Value = "'" & row.Item("rekanan_name").ToString Else xlWorksheet.Cells(RowIndex + 1, 4).Value = row.Item("rekanan_name").ToString

                        If Mid(row.Item("circulationdetil_descr").ToString, 1, 1) = "=" Then xlWorksheet.Cells(RowIndex + 1, 5).Value = "'" & row.Item("circulationdetil_descr").ToString Else xlWorksheet.Cells(RowIndex + 1, 5).Value = row.Item("circulationdetil_descr").ToString

                        If row.Item("currency_id") = 1 Then
                            If Mid(row.Item("circulationdetil_amount").ToString, 1, 1) = "=" Then xlWorksheet.Cells(RowIndex + 1, 6).Value = "'" & row.Item("circulationdetil_amount") Else xlWorksheet.Cells(RowIndex + 1, 6).Value = row.Item("circulationdetil_amount")
                        Else
                            If Mid(row.Item("circulationdetil_foreign").ToString, 1, 1) = "=" Then xlWorksheet.Cells(RowIndex + 1, 6).Value = "'" & row.Item("circulationdetil_foreign") Else xlWorksheet.Cells(RowIndex + 1, 7).Value = row.Item("circulationdetil_foreign")
                        End If

                        lblProgress.Text = "Exporting " & RowIndex & " of " & Me.tbl_TrnCirculationvoucherdetil.Rows.Count & " records"
                        lblProgress.Refresh()
                        ProgressBar1.Value = CInt(100 * (RowIndex / Me.tbl_TrnCirculationvoucherdetil.Rows.Count))
                        ProgressBar1.Refresh()
                    Next
                    MessageBox.Show("Export Complete", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    xl.Visible = True
                Catch ex As Exception
                    MessageBox.Show("Error" & vbCrLf & ex.Message)
                End Try
            End If

        End If

        Me.pnlLoading.Visible = False
        Me.lblProgress.Visible = False
        Me.ProgressBar1.Visible = False
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub btn_CheckAllAppDir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_CheckAllAppDir.Click
        Dim i As Integer
        For i = 0 To Me.DgvTrnCirculationvoucherdetil.Rows.Count - 1
            Me.DgvTrnCirculationvoucherdetil.Rows(i).Cells("circulationdetil_appdireksi").Value = True
        Next
    End Sub
    Private Sub btn_List_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_List.Click
        Dim dlg As dlgTrnCirculationSelectPV
        Dim retObj As Object
        Dim tbl_ret As DataTable = New DataTable
        Dim i, j As Integer
        Dim row As DataRow
        Dim totalAmount, totalAmountIDR As Decimal
        Dim ref_id As String = String.Empty

        For j = 0 To Me.DgvTrnCirculationvoucherdetil.Rows.Count - 1
            If ref_id = String.Empty Then
                ref_id = String.Format("'{0}'", clsUtil.IsDbNull(Me.DgvTrnCirculationvoucherdetil.Rows(j).Cells("circulationdetil_reference").Value, String.Empty))
            Else
                ref_id &= ", " & String.Format("'{0}'", clsUtil.IsDbNull(Me.DgvTrnCirculationvoucherdetil.Rows(j).Cells("circulationdetil_reference").Value, String.Empty))
            End If
        Next

        If ref_id <> String.Empty Then
            ref_id = "(" & ref_id & ")"
        End If


        dlg = New dlgTrnCirculationSelectPV(Me.DSN, Me._CHANNEL, ref_id)
        retObj = dlg.OpenDialog(Me)



        If retObj IsNot Nothing Then
            tbl_ret = retObj
            totalAmount = 0
            totalAmountIDR = 0 
            For i = 0 To tbl_ret.Rows.Count - 1
                row = Me.tbl_TrnCirculationvoucherdetil.NewRow
                row.Item("currency_id") = tbl_ret.Rows(i).Item("currency_id")
                row.Item("circulationdetil_reference") = tbl_ret.Rows(i).Item("jurnal_id")
                row.Item("circulationdetil_bilyet") = tbl_ret.Rows(i).Item("bilyet")
                row.Item("circulationdetil_rekanan") = tbl_ret.Rows(i).Item("rekanan_id")
                row.Item("circulationdetil_descr") = Trim(tbl_ret.Rows(i).Item("rekanan_name")) & " - " & tbl_ret.Rows(i).Item("jurnal_descr")
                If tbl_ret.Rows(i).Item("currency_id") = "1" Then
                    row.Item("circulationdetil_amount") = tbl_ret.Rows(i).Item("jurnal_amountidr")
                    row.Item("circulationdetil_foreign") = 0 'tbl_ret.Rows(i).Item("jurnal_amountforeign")
                Else
                    row.Item("circulationdetil_amount") = 0 'tbl_ret.Rows(i).Item("jurnal_amountidr")
                    row.Item("circulationdetil_foreign") = tbl_ret.Rows(i).Item("jurnal_amountforeign")
                End If
                row.Item("circulationdetil_rate") = tbl_ret.Rows(i).Item("currency_rate")
                row.Item("rekanan_name") = tbl_ret.Rows(i).Item("rekanan_name")
                Me.tbl_TrnCirculationvoucherdetil.Rows.Add(row)
            Next

            For i = 0 To Me.DgvTrnCirculationvoucherdetil.Rows.Count - 1
                totalAmount += clsUtil.IsDbNull(Me.DgvTrnCirculationvoucherdetil.Rows(i).Cells("circulationdetil_foreign").Value, 0)
                totalAmountIDR += clsUtil.IsDbNull(Me.DgvTrnCirculationvoucherdetil.Rows(i).Cells("circulationdetil_amount").Value, 0)
            Next

            Me.obj_Circulation_foreign.Text = Format(totalAmount, "#,##0.00")
            Me.obj_Circulation_amount.Text = Format(totalAmountIDR, "#,##0")
        End If

    End Sub
    Private Sub btn_Refresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Refresh.Click
        Dim tbl_trnJurnalPV_Temps As DataTable = New DataTable
        Dim totalAmount, totalAmountIdr As Decimal
        Dim i As Integer
        If Me.obj_Circulation_appuser.Checked = False And Me.DgvTrnCirculationvoucherdetil.CurrentRow.Cells("circulationdetil_appdireksi").Value = False Then
            Me.DataFill(tbl_trnJurnalPV_Temps, "act_TrnCirculationVoucher_Select_PV", String.Format(" A.jurnal_id = '{0}'", Me.DgvTrnCirculationvoucherdetil.CurrentRow.Cells("circulationdetil_reference").Value), Me._CHANNEL)
            If tbl_trnJurnalPV_Temps.Rows.Count > 0 Then
                totalAmount = 0
                totalAmountIdr = 0

                Me.DgvTrnCirculationvoucherdetil.CurrentRow.Cells("currency_id").Value = tbl_trnJurnalPV_Temps.Rows(0).Item("currency_id")
                Me.DgvTrnCirculationvoucherdetil.CurrentRow.Cells("circulationdetil_reference").Value = tbl_trnJurnalPV_Temps.Rows(0).Item("jurnal_id")
                Me.DgvTrnCirculationvoucherdetil.CurrentRow.Cells("circulationdetil_bilyet").Value = tbl_trnJurnalPV_Temps.Rows(0).Item("bilyet")
                Me.DgvTrnCirculationvoucherdetil.CurrentRow.Cells("circulationdetil_rekanan").Value = tbl_trnJurnalPV_Temps.Rows(0).Item("rekanan_id")
                Me.DgvTrnCirculationvoucherdetil.CurrentRow.Cells("circulationdetil_descr").Value = Trim(tbl_trnJurnalPV_Temps.Rows(0).Item("rekanan_name")) & " - " & tbl_trnJurnalPV_Temps.Rows(0).Item("jurnal_descr")
                If tbl_trnJurnalPV_Temps.Rows(0).Item("currency_id") = "1" Then
                    Me.DgvTrnCirculationvoucherdetil.CurrentRow.Cells("circulationdetil_amount").Value = tbl_trnJurnalPV_Temps.Rows(0).Item("jurnal_amountidr")
                    Me.DgvTrnCirculationvoucherdetil.CurrentRow.Cells("circulationdetil_foreign").Value = 0 'tbl_ret.Rows(i).Item("jurnal_amountforeign")
                Else
                    Me.DgvTrnCirculationvoucherdetil.CurrentRow.Cells("circulationdetil_amount").Value = 0 'tbl_ret.Rows(i).Item("jurnal_amountidr")
                    Me.DgvTrnCirculationvoucherdetil.CurrentRow.Cells("circulationdetil_foreign").Value = tbl_trnJurnalPV_Temps.Rows(0).Item("jurnal_amountforeign")
                End If
                Me.DgvTrnCirculationvoucherdetil.CurrentRow.Cells("circulationdetil_rate").Value = tbl_trnJurnalPV_Temps.Rows(0).Item("currency_rate")

                For i = 0 To Me.DgvTrnCirculationvoucherdetil.Rows.Count - 1
                    totalAmount += clsUtil.IsDbNull(Me.DgvTrnCirculationvoucherdetil.Rows(i).Cells("circulationdetil_foreign").Value, 0)
                    totalAmountIdr += clsUtil.IsDbNull(Me.DgvTrnCirculationvoucherdetil.Rows(i).Cells("circulationdetil_amount").Value, 0)
                Next

                Me.obj_Circulation_foreign.Text = Format(totalAmount, "#,##0.00")
                Me.obj_Circulation_amount.Text = Format(totalAmountIdr, "#,##0")

            Else
                MsgBox("Tidak ada perubahan")
            End If
        Else
            MsgBox("Access Denied")
        End If
    End Sub
    Private Sub btn_UnCheckAllAppDir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_UnCheckAllAppDir.Click
        Dim i As Integer

        For i = 0 To Me.DgvTrnCirculationvoucherdetil.Rows.Count - 1
            Me.DgvTrnCirculationvoucherdetil.Rows(i).Cells("circulationdetil_appdireksi").Value = False
        Next
    End Sub
    Private Sub DataIsApproved(ByVal isApproved As Boolean)

        System.Windows.Forms.Cursor.Current = Cursors.WaitCursor
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbCmdUpdate As OleDb.OleDbCommand
        Dim query As String
        Dim message As String = ""
        If isApproved = False Then
            Try
                Dim i As Integer
                Dim cell_appbayar, cell_cair, cell_direksi As DataGridViewCell
                Dim dgv_error, row_error As Boolean
                Me.DgvTrnCirculationvoucherdetil.EndEdit()
                For i = 0 To Me.DgvTrnCirculationvoucherdetil.Rows.Count - 1
                    row_error = False
                    message = "Data tidak bisa dicanceled karena data sudah di jurnal"
                    cell_appbayar = Me.DgvTrnCirculationvoucherdetil.Rows(i).Cells("circulationdetil_appbayar")
                    cell_cair = Me.DgvTrnCirculationvoucherdetil.Rows(i).Cells("circulationdetil_appbankcair")
                    cell_direksi = Me.DgvTrnCirculationvoucherdetil.Rows(i).Cells("circulationdetil_appdireksi")

                    If clsUtil.IsDbNull(cell_cair.Value, False) = True Then
                        cell_cair.ErrorText = "PV-nya harus di un-Link dulu untuk dapat unapproved circulation voucher"
                        row_error = True
                    ElseIf clsUtil.IsDbNull(cell_appbayar.Value, False) = True Then
                        cell_appbayar.ErrorText = "PV-nya harus di un-Jurnal dulu untuk dapat unapproved circulation voucher"
                        row_error = True
                    ElseIf clsUtil.IsDbNull(cell_direksi.Value, False) = True Then
                        cell_direksi.ErrorText = "Data harus di unapproved direksi dulu untuk dapat unapproved circulation voucher"
                        row_error = True
                    Else
                        cell_direksi.ErrorText = String.Empty
                        cell_appbayar.ErrorText = String.Empty
                        cell_cair.ErrorText = String.Empty
                    End If

                    If row_error Then
                        dgv_error = True
                        Me.DgvTrnCirculationvoucherdetil.Rows(i).DefaultCellStyle.BackColor = Color.Coral
                    Else
                        Me.DgvTrnCirculationvoucherdetil.Rows(i).DefaultCellStyle.BackColor = Color.White
                        ' ''Me.FormatDgvTrnCirculationvoucherdetil(Me.DgvTrnCirculationvoucherdetil)
                    End If

                Next

                If dgv_error Then
                    Throw New Exception("Data ada yang masih salah!")
                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message, mUiName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End Try
        End If


        Try
            dbConn.Open()
            Dim oCm As New OleDb.OleDbCommand("act_TrnCirculationvoucher_approved", dbConn)
            oCm.CommandType = CommandType.StoredProcedure
            oCm.Parameters.Add("@circulation_id", System.Data.OleDb.OleDbType.VarWChar, 24).Value = Me.DgvTrnCirculationvoucher.Rows(Me.DgvTrnCirculationvoucher.CurrentRow.Index).Cells("circulation_id").Value
            oCm.Parameters.Add("@circulation_appby", System.Data.OleDb.OleDbType.VarWChar, 100).Value = Me.UserName
            oCm.Parameters.Add("@circulation_appdt", System.Data.OleDb.OleDbType.DBTimeStamp, 4).Value = Now.Date

            If isApproved = True Then
                oCm.Parameters.Add("@app_method", System.Data.OleDb.OleDbType.VarWChar, 32).Value = "APPROVED"
            Else
                oCm.Parameters.Add("@app_method", System.Data.OleDb.OleDbType.VarWChar, 32).Value = "UNAPPROVED"
            End If
            oCm.ExecuteNonQuery()
            oCm.Dispose()
            If isApproved = True Then
                Me.DgvTrnCirculationvoucher.Rows(Me.DgvTrnCirculationvoucher.CurrentRow.Index).Cells("circulation_appuser").Value = 1
                Me.obj_Circulation_appuser.Checked = True
                Me.btnApproved.Visible = False
                Me.btnUnApproved.Visible = True
                Me.btn_List.Enabled = False
                Me.obj_Circulation_descr.ReadOnly = True
                Me.obj_Circulation_sendto.Enabled = False
                MessageBox.Show("Data Has Been Approved", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                Me.DgvTrnCirculationvoucher.Rows(Me.DgvTrnCirculationvoucher.CurrentRow.Index).Cells("circulation_appuser").Value = 0
                Me.obj_Circulation_appuser.Checked = False
                Me.btnApproved.Visible = True
                Me.btnUnApproved.Visible = False
                Me.btn_List.Enabled = True
                Me.obj_Circulation_descr.ReadOnly = False
                Me.obj_Circulation_sendto.Enabled = True
                MessageBox.Show("Data Has Been UnApproved", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            Me.uiTrnCirculationVoucher_Save(False)
        Catch ex As Data.OleDb.OleDbException
            MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            dbConn.Close()
        End Try

        If isApproved = False Then
            query = String.Format("UPDATE FRM.E_FRM.dbo.transaksi_circulationvoucher SET circulation_status = 'REVISI',	circulation_totalrevisi = {0} 	WHERE circulation_id = '{1}'", clsUtil.IsDbNull(Me.DgvTrnCirculationvoucher.Rows(Me.DgvTrnCirculationvoucher.CurrentRow.Index).Cells("circulation_totalrevisi").Value, 0) + 1, Me.DgvTrnCirculationvoucher.Rows(Me.DgvTrnCirculationvoucher.CurrentRow.Index).Cells("circulation_id").Value)
            dbConn.Open()
            dbCmdUpdate = New OleDb.OleDbCommand(query, dbConn)
            dbCmdUpdate.CommandType = CommandType.Text
            dbCmdUpdate.ExecuteNonQuery()
            dbConn.Close()
            Me.obj_Circulation_status.Text = "REVISI"
            Me.obj_Circulation_totalrevisi.Text = clsUtil.IsDbNull(Me.DgvTrnCirculationvoucher.Rows(Me.DgvTrnCirculationvoucher.CurrentRow.Index).Cells("circulation_totalrevisi").Value, 0) + 1
            Me.DgvTrnCirculationvoucher.Rows(Me.DgvTrnCirculationvoucher.CurrentRow.Index).Cells("circulation_totalrevisi").Value = clsUtil.IsDbNull(Me.DgvTrnCirculationvoucher.Rows(Me.DgvTrnCirculationvoucher.CurrentRow.Index).Cells("circulation_totalrevisi").Value, 0) + 1
        End If

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
            Me.ftabMain.SelectedIndex = 1
        End If
        Me.uiTrnCirculationVoucher_NewData()
        Me.btnApproved.Visible = True
        Me.btnUnApproved.Visible = False
        Me.btn_List.Enabled = True
        Me.tbtnSave.Enabled = True
        Me.tbtnDel.Enabled = False
        Me.obj_Circulation_descr.ReadOnly = False
        Me.obj_Circulation_sendto.Enabled = True
        Me.DgvTrnCirculationvoucherdetil.AllowUserToDeleteRows = True
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnNew_Click()
    End Function
    Public Overrides Function btnLoad_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnCirculationVoucher_Retrieve()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnLoad_Click()
    End Function
    Public Overrides Function btnSave_Click() As Boolean
        If Me.uiTrnCirculationVoucher_FormError() Then
            Return True
        End If
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnCirculationVoucher_Save(True)
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnSave_Click()
    End Function
    Public Overrides Function btnPrintPreview_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        If clsUtil.IsDbNull(Me.DgvTrnCirculationvoucher.Rows(Me.DgvTrnCirculationvoucher.CurrentRow.Index).Cells("circulation_appuser").Value, False) = True Then
            Me.uiTrnCirculationVoucher_PrintPreview()
        Else
            MsgBox("Harus Approved user dulu untuk dapat melakukan print preview")
        End If
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnPrint_Click()
    End Function
    Public Overrides Function btnPrint_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        If clsUtil.IsDbNull(Me.DgvTrnCirculationvoucher.Rows(Me.DgvTrnCirculationvoucher.CurrentRow.Index).Cells("circulation_appuser").Value, False) = True Then
            Me.uiTrnCirculationVoucher_Print()
        Else
            MsgBox("Harus Approved user dulu untuk dapat melakukan print")
        End If
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnPrint_Click()
    End Function
    Public Overrides Function btnDel_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        ' ''Me.uiTrnCirculationVoucher_Delete()
        MsgBox("Under Construction")
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnDel_Click()
    End Function
    Public Overrides Function btnFirst_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnCirculationVoucher_First()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnFirst_Click()
    End Function
    Public Overrides Function btnPrev_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnCirculationVoucher_Prev()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnPrev_Click()
    End Function
    Public Overrides Function btnNext_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnCirculationVoucher_Next()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnNext_Click()
    End Function
    Public Overrides Function btnLast_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnCirculationVoucher_Last()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnLast_Click()
    End Function
#End Region
#Region " Layout & Init UI "
    Private Function FormatDgvTrnCirculationvoucher(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        ' Format DgvTrnCirculationvoucher Columns 
        Dim cCirculation_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cCirculation_senddt As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cCirculation_sendto As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cCirculation_foreign As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cCirculation_amount As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cCirculation_descr As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnaltype_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cChannel_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cCirculation_appuser As System.Windows.Forms.DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Dim cCirculation_appuserby As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cCirculation_appuserdt As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cCirculation_status As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cCirculation_totalrevisi As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cEntry_by As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cEntry_dt As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cModified_by As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cModified_dt As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAuth_name As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn

        cCirculation_id.Name = "circulation_id"
        cCirculation_id.HeaderText = "ID"
        cCirculation_id.DataPropertyName = "circulation_id"
        cCirculation_id.Width = 100
        cCirculation_id.Visible = True
        cCirculation_id.ReadOnly = False

        cCirculation_senddt.Name = "circulation_senddt"
        cCirculation_senddt.HeaderText = "Send Date"
        cCirculation_senddt.DataPropertyName = "circulation_senddt"
        cCirculation_senddt.Width = 100
        cCirculation_senddt.Visible = True
        cCirculation_senddt.ReadOnly = False
        cCirculation_senddt.DefaultCellStyle.Format = "dd/MM/yyyy"


        cCirculation_sendto.Name = "circulation_sendto"
        cCirculation_sendto.HeaderText = "Send To"
        cCirculation_sendto.DataPropertyName = "circulation_sendto"
        cCirculation_sendto.Width = 150
        cCirculation_sendto.Visible = False
        cCirculation_sendto.ReadOnly = False

        cCirculation_foreign.Name = "circulation_foreign"
        cCirculation_foreign.HeaderText = "Amount"
        cCirculation_foreign.DataPropertyName = "circulation_foreign"
        cCirculation_foreign.Width = 120
        cCirculation_foreign.Visible = True
        cCirculation_foreign.ReadOnly = False
        cCirculation_foreign.DefaultCellStyle.Format = "#,##0.00"
        cCirculation_foreign.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        cCirculation_amount.Name = "circulation_amount"
        cCirculation_amount.HeaderText = "Amount IDR"
        cCirculation_amount.DataPropertyName = "circulation_amount"
        cCirculation_amount.Width = 120
        cCirculation_amount.Visible = True
        cCirculation_amount.ReadOnly = False
        cCirculation_amount.DefaultCellStyle.Format = "#,##0"
        cCirculation_amount.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        cCirculation_descr.Name = "circulation_descr"
        cCirculation_descr.HeaderText = "Descr"
        cCirculation_descr.DataPropertyName = "circulation_descr"
        cCirculation_descr.Width = 200
        cCirculation_descr.Visible = True
        cCirculation_descr.ReadOnly = False

        cJurnaltype_id.Name = "jurnaltype_id"
        cJurnaltype_id.HeaderText = "jurnaltype_id"
        cJurnaltype_id.DataPropertyName = "jurnaltype_id"
        cJurnaltype_id.Width = 100
        cJurnaltype_id.Visible = False
        cJurnaltype_id.ReadOnly = False

        cChannel_id.Name = "channel_id"
        cChannel_id.HeaderText = "channel_id"
        cChannel_id.DataPropertyName = "channel_id"
        cChannel_id.Width = 100
        cChannel_id.Visible = False
        cChannel_id.ReadOnly = False

        cCirculation_appuser.Name = "circulation_appuser"
        cCirculation_appuser.HeaderText = "App. User"
        cCirculation_appuser.DataPropertyName = "circulation_appuser"
        cCirculation_appuser.Width = 80
        cCirculation_appuser.Visible = True
        cCirculation_appuser.ReadOnly = False

        cCirculation_appuserby.Name = "circulation_appuserby"
        cCirculation_appuserby.HeaderText = "App. User By"
        cCirculation_appuserby.DataPropertyName = "circulation_appuserby"
        cCirculation_appuserby.Width = 100
        cCirculation_appuserby.Visible = True
        cCirculation_appuserby.ReadOnly = False

        cCirculation_appuserdt.Name = "circulation_appuserdt"
        cCirculation_appuserdt.HeaderText = "App. User Dt"
        cCirculation_appuserdt.DataPropertyName = "circulation_appuserdt"
        cCirculation_appuserdt.Width = 100
        cCirculation_appuserdt.Visible = True
        cCirculation_appuserdt.ReadOnly = False

        cCirculation_status.Name = "circulation_status"
        cCirculation_status.HeaderText = "circulation_status"
        cCirculation_status.DataPropertyName = "circulation_status"
        cCirculation_status.Width = 100
        cCirculation_status.Visible = False
        cCirculation_status.ReadOnly = False

        cCirculation_totalrevisi.Name = "circulation_totalrevisi"
        cCirculation_totalrevisi.HeaderText = "circulation_totalrevisi"
        cCirculation_totalrevisi.DataPropertyName = "circulation_totalrevisi"
        cCirculation_totalrevisi.Width = 100
        cCirculation_totalrevisi.Visible = False
        cCirculation_totalrevisi.ReadOnly = False

        cEntry_by.Name = "entry_by"
        cEntry_by.HeaderText = "Entry By"
        cEntry_by.DataPropertyName = "entry_by"
        cEntry_by.Width = 100
        cEntry_by.Visible = True
        cEntry_by.ReadOnly = False

        cEntry_dt.Name = "entry_dt"
        cEntry_dt.HeaderText = "entry_dt"
        cEntry_dt.DataPropertyName = "entry_dt"
        cEntry_dt.Width = 100
        cEntry_dt.Visible = False
        cEntry_dt.ReadOnly = False

        cModified_by.Name = "modified_by"
        cModified_by.HeaderText = "modified_by"
        cModified_by.DataPropertyName = "modified_by"
        cModified_by.Width = 100
        cModified_by.Visible = False
        cModified_by.ReadOnly = False

        cModified_dt.Name = "modified_dt"
        cModified_dt.HeaderText = "modified_dt"
        cModified_dt.DataPropertyName = "modified_dt"
        cModified_dt.Width = 100
        cModified_dt.Visible = False
        cModified_dt.ReadOnly = False

        cAuth_name.Name = "auth_name"
        cAuth_name.HeaderText = "Send To"
        cAuth_name.DataPropertyName = "auth_name"
        cAuth_name.Width = 150
        cAuth_name.Visible = True
        cAuth_name.ReadOnly = False

        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
        {cCirculation_id, cCirculation_senddt, cCirculation_sendto, cAuth_name, cCirculation_foreign, _
        cCirculation_amount, cCirculation_descr, cJurnaltype_id, cChannel_id, _
        cCirculation_appuser, cCirculation_appuserby, cCirculation_appuserdt, _
        cCirculation_status, cCirculation_totalrevisi, cEntry_by, cEntry_dt, _
        cModified_by, cModified_dt})

        ' DgvTrnCirculationvoucher Behaviours: 
        objDgv.AllowUserToAddRows = False
        objDgv.AllowUserToDeleteRows = False
        objDgv.AllowUserToResizeRows = False
        objDgv.ReadOnly = True
        objDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        objDgv.MultiSelect = True

    End Function
    Private Function FormatDgvTrnCirculationvoucherdetil(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        ' formating DgvTrnCirculationvoucherdetil
        Dim cCirculation_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cCirculationdetil_line As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cCirculationdetil_reference As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cCirculationdetil_bilyet As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cCirculationdetil_rekanan As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cCirculationdetil_rekananName As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cCirculationdetil_descr As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cCurrency_id As System.Windows.Forms.DataGridViewComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn
        Dim cCirculationdetil_foreign As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cCirculationdetil_rate As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cCirculationdetil_amount As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cChannel_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cCirculationdetil_appdireksi As System.Windows.Forms.DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Dim cCirculationdetil_appdireksi_by As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cCirculationdetil_appdireksi_dt As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cCirculationdetil_appbayar As System.Windows.Forms.DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Dim cCirculationdetil_appbayar_by As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cCirculationdetil_appbayar_dt As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cCirculationdetil_appbankcair As System.Windows.Forms.DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Dim cCirculationdetil_appbankcair_by As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cCirculationdetil_appbankcair_dt As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cCirculationdetil_canceled As System.Windows.Forms.DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Dim cCirculationdetil_canceledby As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cCirculationdetil_canceleddt As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cEntry_by As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cEntry_dt As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cModify_by As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cModify_dt As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn

        cCirculation_id.Name = "circulation_id"
        cCirculation_id.HeaderText = "circulation_id"
        cCirculation_id.DataPropertyName = "circulation_id"
        cCirculation_id.Width = 100
        cCirculation_id.Visible = False
        cCirculation_id.ReadOnly = False
        cCirculation_id.Frozen = True

        cCirculationdetil_line.Name = "circulationdetil_line"
        cCirculationdetil_line.HeaderText = "Line"
        cCirculationdetil_line.DataPropertyName = "circulationdetil_line"
        cCirculationdetil_line.Width = 40
        cCirculationdetil_line.Visible = True
        cCirculationdetil_line.ReadOnly = True
        cCirculationdetil_line.DefaultCellStyle.BackColor = Color.LightYellow
        cCirculationdetil_line.Frozen = True

        cCirculationdetil_reference.Name = "circulationdetil_reference"
        cCirculationdetil_reference.HeaderText = "Ref. ID"
        cCirculationdetil_reference.DataPropertyName = "circulationdetil_reference"
        cCirculationdetil_reference.Width = 100
        cCirculationdetil_reference.Visible = True
        cCirculationdetil_reference.ReadOnly = True
        cCirculationdetil_reference.DefaultCellStyle.BackColor = Color.LightYellow
        cCirculationdetil_reference.Frozen = True

        cCirculationdetil_bilyet.Name = "circulationdetil_bilyet"
        cCirculationdetil_bilyet.HeaderText = "Bilyet"
        cCirculationdetil_bilyet.DataPropertyName = "circulationdetil_bilyet"
        cCirculationdetil_bilyet.Width = 100
        cCirculationdetil_bilyet.Visible = True
        cCirculationdetil_bilyet.ReadOnly = True
        cCirculationdetil_bilyet.DefaultCellStyle.BackColor = Color.LightYellow

        cCirculationdetil_rekanan.Name = "circulationdetil_rekanan"
        cCirculationdetil_rekanan.HeaderText = "Rekanan"
        cCirculationdetil_rekanan.DataPropertyName = "circulationdetil_rekanan"
        cCirculationdetil_rekanan.Width = 150
        cCirculationdetil_rekanan.Visible = False
        cCirculationdetil_rekanan.ReadOnly = True

        cCirculationdetil_rekananName.Name = "rekanan_name"
        cCirculationdetil_rekananName.HeaderText = "Rekanan"
        cCirculationdetil_rekananName.DataPropertyName = "rekanan_name"
        cCirculationdetil_rekananName.Width = 150
        cCirculationdetil_rekananName.Visible = True
        cCirculationdetil_rekananName.ReadOnly = True
        cCirculationdetil_rekananName.DefaultCellStyle.BackColor = Color.LightYellow

        cCirculationdetil_descr.Name = "circulationdetil_descr"
        cCirculationdetil_descr.HeaderText = "Description"
        cCirculationdetil_descr.DataPropertyName = "circulationdetil_descr"
        cCirculationdetil_descr.Width = 200
        cCirculationdetil_descr.Visible = True
        cCirculationdetil_descr.ReadOnly = True
        cCirculationdetil_descr.DefaultCellStyle.BackColor = Color.LightYellow

        cCurrency_id.Name = "currency_id"
        cCurrency_id.HeaderText = "Curr."
        cCurrency_id.DataPropertyName = "currency_id"
        cCurrency_id.Width = 70
        cCurrency_id.Visible = True
        cCurrency_id.ReadOnly = True
        cCurrency_id.ValueMember = "currency_id"
        cCurrency_id.DisplayMember = "currency_shortname"
        cCurrency_id.DataSource = Me.tbl_MstCurrencyGrid
        cCurrency_id.DefaultCellStyle.BackColor = Color.LightYellow
        cCurrency_id.DisplayStyleForCurrentCellOnly = True

        cCirculationdetil_foreign.Name = "circulationdetil_foreign"
        cCirculationdetil_foreign.HeaderText = "Amount"
        cCirculationdetil_foreign.DataPropertyName = "circulationdetil_foreign"
        cCirculationdetil_foreign.Width = 120
        cCirculationdetil_foreign.Visible = True
        cCirculationdetil_foreign.ReadOnly = True
        cCirculationdetil_foreign.DefaultCellStyle.Format = "#,##0.00"
        cCirculationdetil_foreign.DefaultCellStyle.BackColor = Color.LightYellow
        cCirculationdetil_foreign.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        cCirculationdetil_rate.Name = "circulationdetil_rate"
        cCirculationdetil_rate.HeaderText = "Rate"
        cCirculationdetil_rate.DataPropertyName = "circulationdetil_rate"
        cCirculationdetil_rate.Width = 70
        cCirculationdetil_rate.Visible = False
        cCirculationdetil_rate.ReadOnly = True
        cCirculationdetil_rate.DefaultCellStyle.Format = "#,##0.00"
        cCirculationdetil_rate.DefaultCellStyle.BackColor = Color.LightYellow
        cCirculationdetil_rate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        cCirculationdetil_amount.Name = "circulationdetil_amount"
        cCirculationdetil_amount.HeaderText = "Amount IDR"
        cCirculationdetil_amount.DataPropertyName = "circulationdetil_amount"
        cCirculationdetil_amount.Width = 120
        cCirculationdetil_amount.Visible = True
        cCirculationdetil_amount.ReadOnly = True
        cCirculationdetil_amount.DefaultCellStyle.Format = "#,##0"
        cCirculationdetil_amount.DefaultCellStyle.BackColor = Color.LightYellow
        cCirculationdetil_amount.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        cChannel_id.Name = "channel_id"
        cChannel_id.HeaderText = "channel_id"
        cChannel_id.DataPropertyName = "channel_id"
        cChannel_id.Width = 100
        cChannel_id.Visible = False
        cChannel_id.ReadOnly = False

        cCirculationdetil_appdireksi.Name = "circulationdetil_appdireksi"
        cCirculationdetil_appdireksi.HeaderText = "App. Dir."
        cCirculationdetil_appdireksi.DataPropertyName = "circulationdetil_appdireksi"
        cCirculationdetil_appdireksi.Width = 60
        cCirculationdetil_appdireksi.Visible = True
        cCirculationdetil_appdireksi.ReadOnly = False

        cCirculationdetil_appdireksi_by.Name = "circulationdetil_appdireksi_by"
        cCirculationdetil_appdireksi_by.HeaderText = "App. Dir. By"
        cCirculationdetil_appdireksi_by.DataPropertyName = "circulationdetil_appdireksi_by"
        cCirculationdetil_appdireksi_by.Width = 100
        cCirculationdetil_appdireksi_by.Visible = True
        cCirculationdetil_appdireksi_by.ReadOnly = True
        cCirculationdetil_appdireksi_by.DefaultCellStyle.BackColor = Color.LightYellow

        cCirculationdetil_appdireksi_dt.Name = "circulationdetil_appdireksi_dt"
        cCirculationdetil_appdireksi_dt.HeaderText = "App. Dir. Dt"
        cCirculationdetil_appdireksi_dt.DataPropertyName = "circulationdetil_appdireksi_dt"
        cCirculationdetil_appdireksi_dt.Width = 100
        cCirculationdetil_appdireksi_dt.Visible = True
        cCirculationdetil_appdireksi_dt.ReadOnly = True
        cCirculationdetil_appdireksi_dt.DefaultCellStyle.BackColor = Color.LightYellow

        cCirculationdetil_appbayar.Name = "circulationdetil_appbayar"
        cCirculationdetil_appbayar.HeaderText = "App. Paid"
        cCirculationdetil_appbayar.DataPropertyName = "circulationdetil_appbayar"
        cCirculationdetil_appbayar.Width = 60
        cCirculationdetil_appbayar.Visible = True
        cCirculationdetil_appbayar.ReadOnly = True
        cCirculationdetil_appbayar.DefaultCellStyle.BackColor = Color.LightYellow

        cCirculationdetil_appbayar_by.Name = "circulationdetil_appbayar_by"
        cCirculationdetil_appbayar_by.HeaderText = "App. Paid By"
        cCirculationdetil_appbayar_by.DataPropertyName = "circulationdetil_appbayar_by"
        cCirculationdetil_appbayar_by.Width = 100
        cCirculationdetil_appbayar_by.Visible = True
        cCirculationdetil_appbayar_by.ReadOnly = True
        cCirculationdetil_appbayar_by.DefaultCellStyle.BackColor = Color.LightYellow

        cCirculationdetil_appbayar_dt.Name = "circulationdetil_appbayar_dt"
        cCirculationdetil_appbayar_dt.HeaderText = "App. Paid Dt"
        cCirculationdetil_appbayar_dt.DataPropertyName = "circulationdetil_appbayar_dt"
        cCirculationdetil_appbayar_dt.Width = 100
        cCirculationdetil_appbayar_dt.Visible = True
        cCirculationdetil_appbayar_dt.ReadOnly = True
        cCirculationdetil_appbayar_dt.DefaultCellStyle.BackColor = Color.LightYellow

        cCirculationdetil_appbankcair.Name = "circulationdetil_appbankcair"
        cCirculationdetil_appbankcair.HeaderText = "App. Cash Flow"
        cCirculationdetil_appbankcair.DataPropertyName = "circulationdetil_appbankcair"
        cCirculationdetil_appbankcair.Width = 100
        cCirculationdetil_appbankcair.Visible = True
        cCirculationdetil_appbankcair.ReadOnly = True
        cCirculationdetil_appbankcair.DefaultCellStyle.BackColor = Color.LightYellow

        cCirculationdetil_appbankcair_by.Name = "circulationdetil_appbankcair_by"
        cCirculationdetil_appbankcair_by.HeaderText = "App. Cash Flow By"
        cCirculationdetil_appbankcair_by.DataPropertyName = "circulationdetil_appbankcair_by"
        cCirculationdetil_appbankcair_by.Width = 100
        cCirculationdetil_appbankcair_by.Visible = True
        cCirculationdetil_appbankcair_by.ReadOnly = True
        cCirculationdetil_appbankcair_by.DefaultCellStyle.BackColor = Color.LightYellow

        cCirculationdetil_appbankcair_dt.Name = "circulationdetil_appbankcair_dt"
        cCirculationdetil_appbankcair_dt.HeaderText = "App. Cash Flow Dt"
        cCirculationdetil_appbankcair_dt.DataPropertyName = "circulationdetil_appbankcair_dt"
        cCirculationdetil_appbankcair_dt.Width = 100
        cCirculationdetil_appbankcair_dt.Visible = True
        cCirculationdetil_appbankcair_dt.ReadOnly = True
        cCirculationdetil_appbankcair_dt.DefaultCellStyle.BackColor = Color.LightYellow

        cCirculationdetil_canceled.Name = "circulationdetil_canceled"
        cCirculationdetil_canceled.HeaderText = "Canceled"
        cCirculationdetil_canceled.DataPropertyName = "circulationdetil_canceled"
        cCirculationdetil_canceled.Width = 80
        cCirculationdetil_canceled.Visible = True
        cCirculationdetil_canceled.ReadOnly = False

        cCirculationdetil_canceledby.Name = "circulationdetil_canceledby"
        cCirculationdetil_canceledby.HeaderText = "Canceled By"
        cCirculationdetil_canceledby.DataPropertyName = "circulationdetil_canceledby"
        cCirculationdetil_canceledby.Width = 100
        cCirculationdetil_canceledby.Visible = True
        cCirculationdetil_canceledby.ReadOnly = True
        cCirculationdetil_canceledby.DefaultCellStyle.BackColor = Color.LightYellow

        cCirculationdetil_canceleddt.Name = "circulationdetil_canceleddt"
        cCirculationdetil_canceleddt.HeaderText = "Canceled Dt"
        cCirculationdetil_canceleddt.DataPropertyName = "circulationdetil_canceleddt"
        cCirculationdetil_canceleddt.Width = 100
        cCirculationdetil_canceleddt.Visible = True
        cCirculationdetil_canceleddt.ReadOnly = True
        cCirculationdetil_canceleddt.DefaultCellStyle.BackColor = Color.LightYellow

        cEntry_by.Name = "entry_by"
        cEntry_by.HeaderText = "entry_by"
        cEntry_by.DataPropertyName = "entry_by"
        cEntry_by.Width = 100
        cEntry_by.Visible = False
        cEntry_by.ReadOnly = False

        cEntry_dt.Name = "entry_dt"
        cEntry_dt.HeaderText = "entry_dt"
        cEntry_dt.DataPropertyName = "entry_dt"
        cEntry_dt.Width = 100
        cEntry_dt.Visible = False
        cEntry_dt.ReadOnly = False

        cModify_by.Name = "modify_by"
        cModify_by.HeaderText = "modify_by"
        cModify_by.DataPropertyName = "modify_by"
        cModify_by.Width = 100
        cModify_by.Visible = False
        cModify_by.ReadOnly = False

        cModify_dt.Name = "modify_dt"
        cModify_dt.HeaderText = "modify_dt"
        cModify_dt.DataPropertyName = "modify_dt"
        cModify_dt.Width = 100
        cModify_dt.Visible = False
        cModify_dt.ReadOnly = False

        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
        {cCirculation_id, cCirculationdetil_line, cCirculationdetil_reference, _
        cCirculationdetil_bilyet, cCirculationdetil_rekanan, cCirculationdetil_rekananName, _
        cCirculationdetil_descr, _
        cCurrency_id, cCirculationdetil_foreign, cCirculationdetil_rate, _
        cCirculationdetil_amount, cChannel_id, cCirculationdetil_appdireksi, _
        cCirculationdetil_appdireksi_by, cCirculationdetil_appdireksi_dt, _
        cCirculationdetil_appbayar, cCirculationdetil_appbayar_by, cCirculationdetil_appbayar_dt, _
        cCirculationdetil_appbankcair, cCirculationdetil_appbankcair_by, cCirculationdetil_appbankcair_dt, _
        cCirculationdetil_canceled, cCirculationdetil_canceledby, cCirculationdetil_canceleddt, _
        cEntry_by, cEntry_dt, cModify_by, cModify_dt})

        objDgv.AllowUserToAddRows = False
        objDgv.AllowUserToDeleteRows = False
        objDgv.AutoGenerateColumns = False



    End Function
    Private Function InitLayoutUI() As Boolean

        Me.ftabMain.Anchor = AnchorStyles.Bottom
        Me.ftabMain.Anchor += AnchorStyles.Top
        Me.ftabMain.Anchor += AnchorStyles.Right
        Me.ftabMain.Anchor += AnchorStyles.Left

        Me.PnlDfSearch.Dock = DockStyle.Top
        Me.PnlDfSearch.Visible = False
        Me.PnlDfMain.Dock = DockStyle.Fill
        Me.DgvTrnCirculationvoucher.Dock = DockStyle.Fill

        Me.FormatDgvTrnCirculationvoucher(Me.DgvTrnCirculationvoucher)
        Me.FormatDgvTrnCirculationvoucherdetil(Me.DgvTrnCirculationvoucherdetil)

    End Function
    Private Function BindingStop() As Boolean
        'stop binding
        Me.obj_Circulation_id.DataBindings.Clear()
        Me.obj_Circulation_senddt.DataBindings.Clear()
        Me.obj_Circulation_sendto.DataBindings.Clear()
        Me.obj_Circulation_foreign.DataBindings.Clear()
        Me.obj_Circulation_amount.DataBindings.Clear()
        Me.obj_Circulation_descr.DataBindings.Clear()
        Me.obj_Jurnaltype_id.DataBindings.Clear()
        Me.obj_Channel_id.DataBindings.Clear()
        Me.obj_Circulation_appuser.DataBindings.Clear()
        Me.obj_Circulation_appuserby.DataBindings.Clear()
        Me.obj_Circulation_appuserdt.DataBindings.Clear()
        Me.obj_Circulation_status.DataBindings.Clear()
        Me.obj_Circulation_totalrevisi.DataBindings.Clear()
        Me.obj_Entry_by.DataBindings.Clear()
        Me.obj_Entry_dt.DataBindings.Clear()
        Me.obj_Modified_by.DataBindings.Clear()
        Me.obj_Modified_dt.DataBindings.Clear()

        ' Search Box
        Me.txtSearchJurnalID.DataBindings.Clear()
        Me.cmbSearchCreateBy.DataBindings.Clear()
        Me.cmbSearchAppUser.DataBindings.Clear()
        Return True
    End Function
    Private Function BindingStart() As Boolean
        'start binding
        Me.obj_Circulation_id.DataBindings.Add(New Binding("Text", Me.tbl_TrnCirculationvoucher_Temp, "circulation_id"))
        Me.obj_Circulation_senddt.DataBindings.Add(New Binding("Text", Me.tbl_TrnCirculationvoucher_Temp, "circulation_senddt"))
        Me.obj_Circulation_sendto.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnCirculationvoucher_Temp, "circulation_sendto", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))
        Me.obj_Circulation_foreign.DataBindings.Add(New Binding("Text", Me.tbl_TrnCirculationvoucher_Temp, "circulation_foreign", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))
        Me.obj_Circulation_amount.DataBindings.Add(New Binding("Text", Me.tbl_TrnCirculationvoucher_Temp, "circulation_amount", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0"))
        Me.obj_Circulation_descr.DataBindings.Add(New Binding("Text", Me.tbl_TrnCirculationvoucher_Temp, "circulation_descr"))
        Me.obj_Jurnaltype_id.DataBindings.Add(New Binding("Text", Me.tbl_TrnCirculationvoucher_Temp, "jurnaltype_id"))
        Me.obj_Channel_id.DataBindings.Add(New Binding("Text", Me.tbl_TrnCirculationvoucher_Temp, "channel_id"))
        Me.obj_Circulation_appuser.DataBindings.Add(New Binding("Checked", Me.tbl_TrnCirculationvoucher_Temp, "circulation_appuser"))
        Me.obj_Circulation_appuserby.DataBindings.Add(New Binding("Text", Me.tbl_TrnCirculationvoucher_Temp, "circulation_appuserby"))
        Me.obj_Circulation_appuserdt.DataBindings.Add(New Binding("Text", Me.tbl_TrnCirculationvoucher_Temp, "circulation_appuserdt"))
        Me.obj_Circulation_status.DataBindings.Add(New Binding("Text", Me.tbl_TrnCirculationvoucher_Temp, "circulation_status"))
        Me.obj_Circulation_totalrevisi.DataBindings.Add(New Binding("Text", Me.tbl_TrnCirculationvoucher_Temp, "circulation_totalrevisi"))
        Me.obj_Entry_by.DataBindings.Add(New Binding("Text", Me.tbl_TrnCirculationvoucher_Temp, "entry_by"))
        Me.obj_Entry_dt.DataBindings.Add(New Binding("Text", Me.tbl_TrnCirculationvoucher_Temp, "entry_dt"))
        Me.obj_Modified_by.DataBindings.Add(New Binding("Text", Me.tbl_TrnCirculationvoucher_Temp, "modify_by"))
        Me.obj_Modified_dt.DataBindings.Add(New Binding("Text", Me.tbl_TrnCirculationvoucher_Temp, "modify_dt"))

        ' Search box
        Me.txtSearchJurnalID.DataBindings.Add((New Binding("Enabled", Me.chkSearchJurnalID, "Checked")))
        Me.cmbSearchCreateBy.DataBindings.Add((New Binding("Enabled", Me.chkSearchCreateBy, "Checked")))
        Me.cmbSearchAppUser.DataBindings.Add((New Binding("Enabled", Me.chkSearchAppUser, "Checked")))

        Return True
    End Function
#End Region
#Region " User Defined Function "

    Private Function uiTrnCirculationVoucher_NewData() As Boolean
        'new data
        RaiseEvent FormBeforeNew()

        ' TODO: Set Default Value for tbl_TrnCirculationvoucher_Temp
        Me.tbl_TrnCirculationvoucher_Temp.Clear()
        Me.tbl_TrnCirculationvoucher_Temp.Columns("channel_id").DefaultValue = Me._CHANNEL
        Me.tbl_TrnCirculationvoucher_Temp.Columns("jurnaltype_id").DefaultValue = "CV"
        Me.tbl_TrnCirculationvoucher_Temp.Columns("circulation_status").DefaultValue = "NEW"
        Me.tbl_TrnCirculationvoucher_Temp.Columns("circulation_totalrevisi").DefaultValue = 0

        ' TODO: Set Default Value for tbl_TrnCirculationvoucherdetil
        Me.tbl_TrnCirculationvoucherdetil.Clear()
        Me.tbl_TrnCirculationvoucherdetil = clsDataset.CreateTblTrnCirculationvoucherdetil()
        Me.tbl_TrnCirculationvoucherdetil.Columns("circulation_id").DefaultValue = 0
        Me.tbl_TrnCirculationvoucherdetil.Columns("circulationdetil_line").DefaultValue = DBNull.Value
        Me.tbl_TrnCirculationvoucherdetil.Columns("circulationdetil_line").AutoIncrement = True
        Me.tbl_TrnCirculationvoucherdetil.Columns("circulationdetil_line").AutoIncrementSeed = 10
        Me.tbl_TrnCirculationvoucherdetil.Columns("circulationdetil_line").AutoIncrementStep = 10
        Me.tbl_TrnCirculationvoucherdetil.Columns("channel_id").DefaultValue = Me._CHANNEL

        Me.DgvTrnCirculationvoucherdetil.DataSource = Me.tbl_TrnCirculationvoucherdetil

        Me.BindingContext(Me.tbl_TrnCirculationvoucher_Temp).EndCurrentEdit()
        Try
            Me.BindingContext(Me.tbl_TrnCirculationvoucher_Temp).AddNew()
        Catch ex As Exception
            MessageBox.Show(ex.Source)
        End Try

    End Function
    Private Function uiTrnCirculationVoucher_Retrieve() As Boolean
        'retrieve data
        Dim criteria As String = ""
        Dim txtSearchCriteria As String = ""
        Dim txtSQLSearch As String = ""

        ' TODO: Parse Criteria using clsProc.RefParser()

        '-- Channel ID
        If Me.chkSearchChannel.Checked Then
            txtSearchCriteria = String.Format(" channel_id = '{0}' ", Me.cboSearchChannel.SelectedValue)
            If txtSQLSearch = "" Then
                txtSQLSearch = " (" & txtSearchCriteria & ") "
            Else
                txtSQLSearch = txtSQLSearch & " AND " & " (" & txtSearchCriteria & ") "
            End If
        End If
        '-- END Channel

        '-- CirculationID
        If Me.chkSearchJurnalID.Checked Then
            txtSearchCriteria = clsUtil.RefParser("circulation_id", Me.txtSearchJurnalID)
            If txtSQLSearch = "" Then
                txtSQLSearch = " (" & txtSearchCriteria & ") "
            Else
                txtSQLSearch = txtSQLSearch & " AND " & " (" & txtSearchCriteria & ") "
            End If
        End If
        '-- END CirculationID

        '-- Create By
        If Me.chkSearchCreateBy.Checked Then
            txtSearchCriteria = String.Format(" entry_by = '{0}' ", Me.cmbSearchCreateBy.SelectedValue)
            If txtSQLSearch = "" Then
                txtSQLSearch = " (" & txtSearchCriteria & ") "
            Else
                txtSQLSearch = txtSQLSearch & " AND " & " (" & txtSearchCriteria & ") "
            End If
        End If
        'END Create By

        '-- Approved User
        If Me.chkSearchAppUser.Checked Then
            Dim appUser As Byte
            If Me.cmbSearchAppUser.SelectedItem = "YES" Then
                appUser = 1
            Else
                appUser = 0
            End If
            txtSearchCriteria = String.Format(" circulation_appuser = '{0}' ", appUser)
            If txtSQLSearch = "" Then
                txtSQLSearch = " (" & txtSearchCriteria & ") "
            Else
                txtSQLSearch = txtSQLSearch & " AND " & " (" & txtSearchCriteria & ") "
            End If
        End If
        'END Approved User

        criteria = txtSQLSearch

        Me.tbl_TrnCirculationvoucher.Clear()
        Try
            Me.DataFill(Me.tbl_TrnCirculationvoucher, "act_TrnCirculationvoucher_Select", criteria, Me._CHANNEL)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Function

    Private Function uiTrnCirculationVoucher_Save(ByVal isShow As Boolean) As Boolean
        'save data
        Dim tbl_TrnCirculationvoucher_Temp_Changes As DataTable
        Dim tbl_TrnCirculationvoucherdetil_Changes As DataTable
        Dim success As Boolean
        Dim circulation_id As Object = New Object
        Dim i As Integer = 0
        Dim MasterDataState As System.Data.DataRowState
        Dim result As FormSaveResult

        Me.Cursor = Cursors.WaitCursor
        RaiseEvent FormBeforeSave(circulation_id)

        Me.BindingContext(Me.tbl_TrnCirculationvoucher_Temp).EndCurrentEdit()
        tbl_TrnCirculationvoucher_Temp_Changes = Me.tbl_TrnCirculationvoucher_Temp.GetChanges()

        Me.DgvTrnCirculationvoucherdetil.EndEdit()
        Me.BindingContext(Me.tbl_TrnCirculationvoucherdetil).EndCurrentEdit()
        tbl_TrnCirculationvoucherdetil_Changes = Me.tbl_TrnCirculationvoucherdetil.GetChanges()

        If tbl_TrnCirculationvoucher_Temp_Changes IsNot Nothing Or tbl_TrnCirculationvoucherdetil_Changes IsNot Nothing Then

            Try

                MasterDataState = tbl_TrnCirculationvoucher_Temp.Rows(0).RowState
                circulation_id = tbl_TrnCirculationvoucher_Temp.Rows(0).Item("circulation_id")

                If tbl_TrnCirculationvoucher_Temp_Changes IsNot Nothing Then
                    success = Me.uiTrnCirculationVoucher_SaveMaster(circulation_id, tbl_TrnCirculationvoucher_Temp_Changes, MasterDataState)
                    If Not success Then Throw New Exception("Error: Saving Master Data at Me.uiTrnCirculationVoucher_SaveMaster(tbl_TrnCirculationvoucher_Temp_Changes)")
                    Me.tbl_TrnCirculationvoucher_Temp.AcceptChanges()
                End If

                If tbl_TrnCirculationvoucherdetil_Changes IsNot Nothing Then
                    For i = 0 To Me.tbl_TrnCirculationvoucherdetil.Rows.Count - 1
                        If Me.tbl_TrnCirculationvoucherdetil.Rows(i).RowState = DataRowState.Added Then
                            Me.tbl_TrnCirculationvoucherdetil.Rows(i).Item("circulation_id") = circulation_id
                        End If
                    Next
                    success = Me.uiTrnCirculationVoucher_SaveDetil(circulation_id, tbl_TrnCirculationvoucherdetil_Changes, MasterDataState)
                    If Not success Then Throw New Exception("Error: Save Detil Data at Me.uiTrnCirculationVoucher_SaveDetil(tbl_TrnCirculationvoucherdetil_Changes)")
                    Me.tbl_TrnCirculationvoucherdetil.AcceptChanges()
                    success = Me.uiTrnCirculationVoucher_updateHeader(circulation_id, tbl_TrnCirculationvoucherdetil_Changes, MasterDataState)
                    If Not success Then Throw New Exception("Error: Save Detil Data at Me.uiTrnCirculationVoucher_SaveDetil(tbl_TrnCirculationvoucherdetil_Changes)")

                End If

                result = FormSaveResult.SaveSuccess
                If SHOW_SAVE_CONFIRMATION Then
                    If isShow = True Then
                        MessageBox.Show("Data Saved", mUiName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                    Me.DgvTrnCirculationvoucherdetil.AllowUserToDeleteRows = False
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

        RaiseEvent FormAfterSave(circulation_id, result)
        Me.Cursor = Cursors.Arrow

    End Function
    Private Function uiTrnCirculationVoucher_SaveMaster(ByRef circulation_id As Object, ByVal objTbl As DataTable, ByVal MasterDataState As System.Data.DataRowState) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbCmdInsert As OleDb.OleDbCommand
        Dim dbCmdUpdate As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        ' Save data: transaksi_circulationvoucher
        dbCmdInsert = New OleDb.OleDbCommand("act_TrnCirculationvoucher_Insert", dbConn)
        dbCmdInsert.CommandType = CommandType.StoredProcedure
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@circulation_id", System.Data.OleDb.OleDbType.VarWChar, 24, "circulation_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@circulation_senddt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "circulation_senddt"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@circulation_sendto", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(4, Byte), CType(0, Byte), "circulation_sendto", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@circulation_foreign", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "circulation_foreign", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@circulation_amount", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "circulation_amount", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@circulation_descr", System.Data.OleDb.OleDbType.VarWChar, 4000, "circulation_descr"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnaltype_id", System.Data.OleDb.OleDbType.VarWChar, 4, "jurnaltype_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20, "channel_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@circulation_appuser", System.Data.OleDb.OleDbType.Boolean, 1, "circulation_appuser"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@circulation_appuserby", System.Data.OleDb.OleDbType.VarWChar, 100, "circulation_appuserby"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@circulation_appuserdt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "circulation_appuserdt"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@circulation_status", System.Data.OleDb.OleDbType.VarWChar, 40, "circulation_status"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@circulation_totalrevisi", System.Data.OleDb.OleDbType.Integer, 4, "circulation_totalrevisi"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@circulation_isdisabled", System.Data.OleDb.OleDbType.Boolean, 1))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@circulation_isdisabledby", System.Data.OleDb.OleDbType.VarWChar, 100))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@circulation_isdisableddt", System.Data.OleDb.OleDbType.DBTimeStamp, 4))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@entry_by", System.Data.OleDb.OleDbType.VarWChar, 200))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@entry_dt", System.Data.OleDb.OleDbType.DBTimeStamp, 4))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@modify_by", System.Data.OleDb.OleDbType.VarWChar, 200, "modify_by"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@modify_dt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "modify_dt"))
        dbCmdInsert.Parameters("@entry_by").Value = Me.UserName
        dbCmdInsert.Parameters("@entry_dt").Value = Now()
        dbCmdInsert.Parameters("@circulation_isdisabled").Value = 0
        dbCmdInsert.Parameters("@circulation_isdisabledby").Value = String.Empty
        dbCmdInsert.Parameters("@circulation_isdisableddt").Value = DBNull.Value

        dbCmdUpdate = New OleDb.OleDbCommand("act_TrnCirculationvoucher_Update", dbConn)
        dbCmdUpdate.CommandType = CommandType.StoredProcedure
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@circulation_id", System.Data.OleDb.OleDbType.VarWChar, 24, "circulation_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@circulation_senddt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "circulation_senddt"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@circulation_sendto", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(4, Byte), CType(0, Byte), "circulation_sendto", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@circulation_foreign", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "circulation_foreign", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@circulation_amount", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "circulation_amount", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@circulation_descr", System.Data.OleDb.OleDbType.VarWChar, 4000, "circulation_descr"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnaltype_id", System.Data.OleDb.OleDbType.VarWChar, 4, "jurnaltype_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20, "channel_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@circulation_appuser", System.Data.OleDb.OleDbType.Boolean, 1, "circulation_appuser"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@circulation_appuserby", System.Data.OleDb.OleDbType.VarWChar, 100, "circulation_appuserby"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@circulation_appuserdt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "circulation_appuserdt"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@circulation_status", System.Data.OleDb.OleDbType.VarWChar, 40, "circulation_status"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@circulation_totalrevisi", System.Data.OleDb.OleDbType.Integer, 4, "circulation_totalrevisi"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@circulation_isdisabled", System.Data.OleDb.OleDbType.Boolean, 1, "circulation_isdisabled"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@circulation_isdisabledby", System.Data.OleDb.OleDbType.VarWChar, 100, "circulation_isdisabledby"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@circulation_isdisableddt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "circulation_isdisableddt"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@entry_by", System.Data.OleDb.OleDbType.VarWChar, 200, "entry_by"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@entry_dt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "entry_dt"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@modify_by", System.Data.OleDb.OleDbType.VarWChar, 200))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@modify_dt", System.Data.OleDb.OleDbType.DBTimeStamp, 4))
        dbCmdUpdate.Parameters("@modify_by").Value = Me.UserName
        dbCmdUpdate.Parameters("@modify_dt").Value = Now()

        dbDA = New OleDb.OleDbDataAdapter
        dbDA.UpdateCommand = dbCmdUpdate
        dbDA.InsertCommand = dbCmdInsert


        Try
            dbConn.Open()
            dbDA.Update(objTbl)

            circulation_id = objTbl.Rows(0).Item("circulation_id")
            Me.tbl_TrnCirculationvoucher_Temp.Clear()
            Me.tbl_TrnCirculationvoucher_Temp.Merge(objTbl)

        Catch ex As Data.OleDb.OleDbException
            MessageBox.Show(ex.Message, "OLE DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return False
        Finally
            dbConn.Close()
        End Try


        If MasterDataState = DataRowState.Added Then
            Me.tbl_TrnCirculationvoucher.Merge(objTbl)
            Me.uiTrnCirculationVoucher_Retrieve()
            Me.BindingContext(Me.tbl_TrnCirculationvoucher).Position = 0
        End If

        Return True
    End Function
    Private Function uiTrnCirculationVoucher_updateHeader(ByRef circulation_id As Object, ByVal objTbl As DataTable, ByVal MasterDataState As System.Data.DataRowState) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbCmdUpdate As OleDb.OleDbCommand
        Dim query As String

        Dim i As Integer
        Dim totalAmount, totalAmountIDR As Decimal

        For i = 0 To Me.DgvTrnCirculationvoucherdetil.Rows.Count - 1
            totalAmount += clsUtil.IsDbNull(Me.DgvTrnCirculationvoucherdetil.Rows(i).Cells("circulationdetil_foreign").Value, 0)
            totalAmountIDR += clsUtil.IsDbNull(Me.DgvTrnCirculationvoucherdetil.Rows(i).Cells("circulationdetil_amount").Value, 0)
        Next

        Me.obj_Circulation_foreign.Text = Format(totalAmount, "#,##0.00")
        Me.obj_Circulation_amount.Text = Format(totalAmountIDR, "#,##0")

        query = String.Format("UPDATE FRM.E_FRM.dbo.transaksi_circulationvoucher SET circulation_foreign = {0},	circulation_amount = {1} 	WHERE circulation_id = '{2}' ", totalAmount, totalAmountIDR, clsUtil.IsDbNull(Me.DgvTrnCirculationvoucher.Rows(Me.DgvTrnCirculationvoucher.CurrentRow.Index).Cells("circulation_totalrevisi").Value, 0) + 1, Me.DgvTrnCirculationvoucher.Rows(Me.DgvTrnCirculationvoucher.CurrentRow.Index).Cells("circulation_id").Value)

        Try
            dbConn.Open()
            dbCmdUpdate = New OleDb.OleDbCommand(query, dbConn)
            dbCmdUpdate.CommandType = CommandType.Text
            dbCmdUpdate.ExecuteNonQuery()
        Catch ex As Data.OleDb.OleDbException
            MessageBox.Show(ex.Message, "OLE DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return False
        Finally
            dbConn.Close()
        End Try



        Return True
    End Function
    Private Function uiTrnCirculationVoucher_SaveDetil(ByRef circulation_id As Object, ByVal objTbl As DataTable, ByVal MasterDataState As System.Data.DataRowState) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbCmdInsert As OleDb.OleDbCommand
        Dim dbCmdUpdate As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        ' Save data: transaksi_circulationvoucherdetil
        dbCmdInsert = New OleDb.OleDbCommand("act_TrnCirculationvoucherdetil_Insert", dbConn)
        dbCmdInsert.CommandType = CommandType.StoredProcedure
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@circulation_id", System.Data.OleDb.OleDbType.VarWChar, 24))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@circulationdetil_line", System.Data.OleDb.OleDbType.Integer, 4, "circulationdetil_line"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@circulationdetil_reference", System.Data.OleDb.OleDbType.VarWChar, 24, "circulationdetil_reference"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@circulationdetil_bilyet", System.Data.OleDb.OleDbType.VarWChar, 60, "circulationdetil_bilyet"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@circulationdetil_rekanan", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(5, Byte), CType(0, Byte), "circulationdetil_rekanan", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@circulationdetil_descr", System.Data.OleDb.OleDbType.VarWChar, 4000, "circulationdetil_descr"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@currency_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(3, Byte), CType(0, Byte), "currency_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@circulationdetil_foreign", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "circulationdetil_foreign", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@circulationdetil_rate", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "circulationdetil_rate", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@circulationdetil_amount", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "circulationdetil_amount", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20, "channel_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@circulationdetil_appdireksi", System.Data.OleDb.OleDbType.Boolean, 1, "circulationdetil_appdireksi"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@circulationdetil_appdireksi_by", System.Data.OleDb.OleDbType.VarWChar, 100, "circulationdetil_appdireksi_by"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@circulationdetil_appdireksi_dt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "circulationdetil_appdireksi_dt"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@circulationdetil_appbayar", System.Data.OleDb.OleDbType.Boolean, 1, "circulationdetil_appbayar"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@circulationdetil_appbayar_by", System.Data.OleDb.OleDbType.VarWChar, 100, "circulationdetil_appbayar_by"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@circulationdetil_appbayar_dt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "circulationdetil_appbayar_dt"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@circulationdetil_appbankcair", System.Data.OleDb.OleDbType.Boolean, 1, "circulationdetil_appbankcair"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@circulationdetil_appbankcair_by", System.Data.OleDb.OleDbType.VarWChar, 100, "circulationdetil_appbankcair_by"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@circulationdetil_appbankcair_dt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "circulationdetil_appbankcair_dt"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@circulationdetil_canceled", System.Data.OleDb.OleDbType.Boolean, 1, "circulationdetil_canceled"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@circulationdetil_canceledby", System.Data.OleDb.OleDbType.VarWChar, 100, "circulationdetil_canceledby"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@circulationdetil_canceleddt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "circulationdetil_canceleddt"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@entry_by", System.Data.OleDb.OleDbType.VarWChar, 200))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@entry_dt", System.Data.OleDb.OleDbType.DBTimeStamp, 4))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@modify_by", System.Data.OleDb.OleDbType.VarWChar, 200, "modify_by"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@modify_dt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "modify_dt"))
        dbCmdInsert.Parameters("@circulation_id").Value = circulation_id
        dbCmdInsert.Parameters("@entry_by").Value = Me.UserName
        dbCmdInsert.Parameters("@entry_dt").Value = Now()


        dbCmdUpdate = New OleDb.OleDbCommand("act_TrnCirculationvoucherdetil_Update", dbConn)
        dbCmdUpdate.CommandType = CommandType.StoredProcedure
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@circulation_id", System.Data.OleDb.OleDbType.VarWChar, 24))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@circulationdetil_line", System.Data.OleDb.OleDbType.Integer, 4, "circulationdetil_line"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@circulationdetil_reference", System.Data.OleDb.OleDbType.VarWChar, 24, "circulationdetil_reference"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@circulationdetil_bilyet", System.Data.OleDb.OleDbType.VarWChar, 60, "circulationdetil_bilyet"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@circulationdetil_rekanan", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(5, Byte), CType(0, Byte), "circulationdetil_rekanan", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@circulationdetil_descr", System.Data.OleDb.OleDbType.VarWChar, 4000, "circulationdetil_descr"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@currency_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(3, Byte), CType(0, Byte), "currency_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@circulationdetil_foreign", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "circulationdetil_foreign", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@circulationdetil_rate", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "circulationdetil_rate", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@circulationdetil_amount", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "circulationdetil_amount", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20, "channel_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@circulationdetil_appdireksi", System.Data.OleDb.OleDbType.Boolean, 1, "circulationdetil_appdireksi"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@circulationdetil_appdireksi_by", System.Data.OleDb.OleDbType.VarWChar, 100, "circulationdetil_appdireksi_by"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@circulationdetil_appdireksi_dt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "circulationdetil_appdireksi_dt"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@circulationdetil_appbayar", System.Data.OleDb.OleDbType.Boolean, 1, "circulationdetil_appbayar"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@circulationdetil_appbayar_by", System.Data.OleDb.OleDbType.VarWChar, 100, "circulationdetil_appbayar_by"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@circulationdetil_appbayar_dt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "circulationdetil_appbayar_dt"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@circulationdetil_appbankcair", System.Data.OleDb.OleDbType.Boolean, 1, "circulationdetil_appbankcair"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@circulationdetil_appbankcair_by", System.Data.OleDb.OleDbType.VarWChar, 100, "circulationdetil_appbankcair_by"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@circulationdetil_appbankcair_dt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "circulationdetil_appbankcair_dt"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@circulationdetil_canceled", System.Data.OleDb.OleDbType.Boolean, 1, "circulationdetil_canceled"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@circulationdetil_canceledby", System.Data.OleDb.OleDbType.VarWChar, 100, "circulationdetil_canceledby"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@circulationdetil_canceleddt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "circulationdetil_canceleddt"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@entry_by", System.Data.OleDb.OleDbType.VarWChar, 200, "entry_by"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@entry_dt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "entry_dt"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@modify_by", System.Data.OleDb.OleDbType.VarWChar, 200))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@modify_dt", System.Data.OleDb.OleDbType.DBTimeStamp, 4))
        dbCmdUpdate.Parameters("@circulation_id").Value = circulation_id
        dbCmdUpdate.Parameters("@modify_by").Value = Me.UserName
        dbCmdUpdate.Parameters("@modify_dt").Value = Now()


        dbDA = New OleDb.OleDbDataAdapter
        dbDA.UpdateCommand = dbCmdUpdate
        dbDA.InsertCommand = dbCmdInsert

        Try
            dbConn.Open()
            dbDA.Update(objTbl)

        Catch ex As Data.OleDb.OleDbException
            MessageBox.Show(ex.Message, "OLE DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return False
        Finally
            dbConn.Close()
        End Try

        Return True
    End Function

    Private Function uiTrnCirculationVoucher_Delete() As Boolean
        Dim res As String = ""
        Dim circulation_id As Object = New Object

        Me.Cursor = Cursors.WaitCursor
        RaiseEvent FormBeforeDelete(circulation_id)

        Me.Cursor = Cursors.WaitCursor
        If Me.DgvTrnCirculationvoucher.CurrentRow IsNot Nothing Then

            res = MessageBox.Show("Are you sure want to delete data ?", mUiName, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If res = DialogResult.Yes Then
                Me.uiTrnCirculationVoucher_DeleteRow(Me.DgvTrnCirculationvoucher.CurrentRow.Index)
            End If

        End If

        RaiseEvent FormAfterDelete(circulation_id)
        Me.Cursor = Cursors.Arrow

    End Function
    Private Function uiTrnCirculationVoucher_DeleteRow(ByVal rowIndex As Integer) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbCmdDelete As OleDb.OleDbCommand
        Dim circulation_id As String
        Dim NewRowIndex As Integer

        circulation_id = Me.DgvTrnCirculationvoucher.Rows(rowIndex).Cells("circulation_id").Value

        dbCmdDelete = New OleDb.OleDbCommand("act_TrnCirculationVoucher_Disabled", dbConn)
        dbCmdDelete.CommandType = CommandType.StoredProcedure
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_id", System.Data.OleDb.OleDbType.VarWChar, 24))
        dbCmdDelete.Parameters("@jurnal_id").Value = circulation_id
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_isdisabledby", System.Data.OleDb.OleDbType.VarWChar, 32))
        dbCmdDelete.Parameters("@jurnal_isdisabledby").Value = Me.UserName
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_isdisableddt", System.Data.OleDb.OleDbType.DBTimeStamp, 4))
        dbCmdDelete.Parameters("@jurnal_isdisableddt").Value = Now.Date


        Try
            dbConn.Open()
            dbCmdDelete.ExecuteNonQuery()

            If Me.DgvTrnCirculationvoucher.Rows.Count > 1 Then

                If rowIndex = 0 Then
                    NewRowIndex = rowIndex + 1
                    Me.uiTrnCirculationVoucher_OpenRow(NewRowIndex)
                    Me.tbl_TrnCirculationvoucher.Rows.RemoveAt(rowIndex)
                ElseIf rowIndex = Me.DgvTrnCirculationvoucher.Rows.Count - 1 Then
                    NewRowIndex = rowIndex - 1
                    Me.uiTrnCirculationVoucher_OpenRow(NewRowIndex)
                Else
                    Me.uiTrnCirculationVoucher_OpenRow(rowIndex)
                End If

            Else

                Me.tbl_TrnCirculationvoucher_Temp.Clear()
                Me.uiTrnCirculationVoucher_NewData()

            End If

        Catch ex As Data.OleDb.OleDbException
            MessageBox.Show(ex.Message, "OLE DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Function
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Exit Function
        Finally
            dbConn.Close()
        End Try
    End Function

    Private Function uiTrnCirculationVoucher_OpenRow(ByVal rowIndex As Integer) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim circulation_id As String
        Dim channel_id As String

        circulation_id = Me.DgvTrnCirculationvoucher.Rows(rowIndex).Cells("circulation_id").Value
        channel_id = Me.DgvTrnCirculationvoucher.Rows(rowIndex).Cells("channel_id").Value

        Me.Cursor = Cursors.WaitCursor
        RaiseEvent FormBeforeOpenRow(circulation_id)


        Try
            dbConn.Open()
            Me.uiTrnCirculationVoucher_OpenRowMaster(channel_id, circulation_id, dbConn)
            Me.uiTrnCirculationVoucher_OpenRowDetil(channel_id, circulation_id, dbConn)
        Catch ex As Exception
            MessageBox.Show(ex.Message, mUiName & ": uiTrnCirculationVoucher_OpenRow()", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            dbConn.Close()
        End Try

        RaiseEvent FormAfterOpenRow(circulation_id)
        Me.Cursor = Cursors.Arrow

        Return True

    End Function
    Private Function uiTrnCirculationVoucher_OpenRowMaster(ByVal channel_id As String, ByVal circulation_id As String, ByVal dbConn As OleDb.OleDbConnection) As Boolean
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        dbCmd = New OleDb.OleDbCommand("act_TrnCirculationvoucher_Select", dbConn)
        dbCmd.Parameters.Add("@channel_id", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@channel_id").Value = channel_id
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@Criteria").Value = String.Format("circulation_id='{0}'", circulation_id)
        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)
        Me.tbl_TrnCirculationvoucher_Temp.Clear()

        Try
            Me.BindingStop()
            dbDA.Fill(Me.tbl_TrnCirculationvoucher_Temp)
            Me.BindingStart()

            If CType(clsUtil.IsDbNull(Me.tbl_TrnCirculationvoucher_Temp.Rows(0).Item("circulation_appuser"), 0), Integer) = 0 Then
                Me.btnApproved.Visible = True
                Me.btn_List.Enabled = True
                Me.obj_Circulation_descr.ReadOnly = False
                Me.obj_Circulation_sendto.Enabled = True
            Else
                Me.btnUnApproved.Visible = True
                Me.btn_List.Enabled = False
                Me.obj_Circulation_descr.ReadOnly = True
                Me.obj_Circulation_sendto.Enabled = False
            End If
        Catch ex As Exception
            Throw New Exception(mUiName & ": uiTrnCirculationVoucher_OpenRowMaster()" & vbCrLf & ex.Message)
        End Try

    End Function
    Private Function uiTrnCirculationVoucher_OpenRowDetil(ByVal channel_id As String, ByVal circulation_id As String, ByVal dbConn As OleDb.OleDbConnection) As Boolean
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        dbCmd = New OleDb.OleDbCommand("act_TrnCirculationvoucherdetil_Select", dbConn)
        ' ''dbCmd.Parameters.Add("@channel_id", Data.OleDb.OleDbType.VarChar)
        ' ''dbCmd.Parameters("@channel_id").Value = channel_id
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@Criteria").Value = String.Format("circulation_id='{0}' AND circulationdetil_canceled = 0", circulation_id)
        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)
        Me.tbl_TrnCirculationvoucherdetil.Clear()

        Me.tbl_TrnCirculationvoucherdetil = clsDataset.CreateTblTrnCirculationvoucherdetil()
        Me.tbl_TrnCirculationvoucherdetil.Columns("circulation_id").DefaultValue = circulation_id
        Me.tbl_TrnCirculationvoucherdetil.Columns("circulationdetil_line").DefaultValue = DBNull.Value
        Me.tbl_TrnCirculationvoucherdetil.Columns("circulationdetil_line").AutoIncrement = True
        Me.tbl_TrnCirculationvoucherdetil.Columns("circulationdetil_line").AutoIncrementSeed = 10
        Me.tbl_TrnCirculationvoucherdetil.Columns("circulationdetil_line").AutoIncrementStep = 10
        Me.tbl_TrnCirculationvoucherdetil.Columns("channel_id").DefaultValue = Me._CHANNEL


        Try
            dbDA.Fill(Me.tbl_TrnCirculationvoucherdetil)
            Me.DgvTrnCirculationvoucherdetil.DataSource = Me.tbl_TrnCirculationvoucherdetil
        Catch ex As Exception
            Throw New Exception(mUiName & ": uiTrnCirculationVoucher_OpenRowDetil()" & vbCrLf & ex.Message)
        End Try

    End Function

    Private Function uiTrnCirculationVoucher_First() As Boolean
        'goto first record found
        Dim move As Boolean
        Dim Message As String = "Data has been changed. " & vbCrLf & "Save data changes before move to first record ?"
        Dim iTab As Integer = Me.ftabMain.SelectedIndex

        If iTab = 1 Then
            If Me.DATA_ISLOCKED Then
                move = True
            Else
                move = Me.uiTrnCirculationVoucher_ConfirmSaveBeforeMove(Message)
            End If
        Else
            move = True
        End If

        If move Then

            Me.DgvTrnCirculationvoucher.CurrentCell = Me.DgvTrnCirculationvoucher(2, Me.DgvTrnCirculationvoucher.Rows.Count - 1)
            Me.uiTrnCirculationVoucher_RefreshPosition()
        End If
    End Function
    Private Function uiTrnCirculationVoucher_Prev() As Boolean
        'goto previous record found
        Dim move As Boolean
        Dim Message As String = "Data has been changed. " & vbCrLf & "Save data changes before move to previous record ?"
        Dim iTab As Integer = Me.ftabMain.SelectedIndex

        If iTab = 1 Then
            If Me.DATA_ISLOCKED Then
                move = True
            Else
                move = Me.uiTrnCirculationVoucher_ConfirmSaveBeforeMove(Message)
            End If
        Else
            move = True
        End If

        If move Then
            If Me.DgvTrnCirculationvoucher.CurrentCell.RowIndex < Me.DgvTrnCirculationvoucher.Rows.Count - 1 Then
                Me.DgvTrnCirculationvoucher.CurrentCell = Me.DgvTrnCirculationvoucher(2, DgvTrnCirculationvoucher.CurrentCell.RowIndex + 1)
                Me.uiTrnCirculationVoucher_RefreshPosition()
            End If
        End If
    End Function
    Private Function uiTrnCirculationVoucher_Next() As Boolean
        'goto next record found
        Dim move As Boolean
        Dim Message As String = "Data has been changed. " & vbCrLf & "Save data changes before move to next record ?"
        Dim iTab As Integer = Me.ftabMain.SelectedIndex

        If iTab = 1 Then
            If Me.DATA_ISLOCKED Then
                move = True
            Else
                move = Me.uiTrnCirculationVoucher_ConfirmSaveBeforeMove(Message)
            End If
        Else
            move = True
        End If

        If move Then
            If Me.DgvTrnCirculationvoucher.CurrentCell.RowIndex > 0 Then
                Me.DgvTrnCirculationvoucher.CurrentCell = Me.DgvTrnCirculationvoucher(2, DgvTrnCirculationvoucher.CurrentCell.RowIndex - 1)
                Me.uiTrnCirculationVoucher_RefreshPosition()
            End If
        End If
    End Function
    Private Function uiTrnCirculationVoucher_Last() As Boolean
        'goto last record found
        Dim move As Boolean
        Dim Message As String = "Data has been changed. " & vbCrLf & "Save data changes before move to next record ?"
        Dim iTab As Integer = Me.ftabMain.SelectedIndex

        If iTab = 1 Then
            If Me.DATA_ISLOCKED Then
                move = True
            Else
                move = Me.uiTrnCirculationVoucher_ConfirmSaveBeforeMove(Message)
            End If
        Else
            move = True
        End If

        If move Then
            Me.DgvTrnCirculationvoucher.CurrentCell = Me.DgvTrnCirculationvoucher(2, 0)
            Me.uiTrnCirculationVoucher_RefreshPosition()
        End If
    End Function
    Private Function uiTrnCirculationVoucher_RefreshPosition() As Boolean
        'refresh position
        Dim iTab As Integer = Me.ftabMain.SelectedIndex
        If iTab = 1 Then uiTrnCirculationVoucher_OpenRow(Me.DgvTrnCirculationvoucher.CurrentRow.Index)
    End Function
    Private Function uiTrnCirculationVoucher_ConfirmSaveBeforeMove(ByVal Message As String) As Boolean
        'confirm saving data changes before move
        Dim tbl_TrnCirculationvoucher_Temp_Changes As DataTable
        Dim tbl_TrnCirculationvoucherdetil_Changes As DataTable
        Dim res As System.Windows.Forms.DialogResult
        Dim success As Boolean
        Dim i As Integer = 0
        Dim MasterDataState As System.Data.DataRowState
        Dim circulation_id As Object = New Object
        Dim move As Boolean = False
        Dim result As FormSaveResult


        If Me.DgvTrnCirculationvoucher.CurrentCell IsNot Nothing Then

            Me.BindingContext(Me.tbl_TrnCirculationvoucher_Temp).EndCurrentEdit()
            tbl_TrnCirculationvoucher_Temp_Changes = Me.tbl_TrnCirculationvoucher_Temp.GetChanges()

            Me.DgvTrnCirculationvoucherdetil.EndEdit()
            Me.BindingContext(Me.tbl_TrnCirculationvoucherdetil).EndCurrentEdit()
            tbl_TrnCirculationvoucherdetil_Changes = Me.tbl_TrnCirculationvoucherdetil.GetChanges()

            If tbl_TrnCirculationvoucher_Temp_Changes IsNot Nothing Or tbl_TrnCirculationvoucherdetil_Changes IsNot Nothing Then

                res = MessageBox.Show(Message, mUiName, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                Select Case res
                    Case DialogResult.Yes

                        RaiseEvent FormBeforeSave(circulation_id)

                        Try

                            If tbl_TrnCirculationvoucher_Temp_Changes IsNot Nothing Then
                                success = Me.uiTrnCirculationVoucher_SaveMaster(circulation_id, tbl_TrnCirculationvoucher_Temp_Changes, MasterDataState)
                                If Not success Then Throw New Exception("Cannot Save Master Data")
                                Me.tbl_TrnCirculationvoucher_Temp.AcceptChanges()
                            End If

                            If tbl_TrnCirculationvoucherdetil_Changes IsNot Nothing Then
                                For i = 0 To Me.tbl_TrnCirculationvoucherdetil.Rows.Count - 1
                                    If Me.tbl_TrnCirculationvoucherdetil.Rows(i).RowState = DataRowState.Added Then
                                        Me.tbl_TrnCirculationvoucherdetil.Rows(i).Item("circulation_id") = circulation_id
                                    End If
                                Next
                                success = Me.uiTrnCirculationVoucher_SaveDetil(circulation_id, tbl_TrnCirculationvoucherdetil_Changes, MasterDataState)
                                If Not success Then Throw New Exception("Cannot Save Detil Data")
                                Me.tbl_TrnCirculationvoucherdetil.AcceptChanges()
                            End If

                            result = FormSaveResult.SaveSuccess
                            If SHOW_SAVE_CONFIRMATION Then
                                MessageBox.Show("Data Saved", mUiName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                            End If

                        Catch ex As Exception
                            result = FormSaveResult.SaveError
                            MessageBox.Show(ex.Message & vbCrLf & "Data Cannot Be Saved", mUiName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try

                        RaiseEvent FormAfterSave(circulation_id, result)

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
    Private Function uiTrnCirculationVoucher_FormError() As Boolean
        Dim message As String = ""

        Try
            ' TODO: Cek Error disini
            ' objFormError.SetError()

            ' Throw New Exception("Error")

            Dim i As Integer
            Dim cell_appbayar, cell_cair, cell_cancel, cell_direksi As DataGridViewCell
            Dim dgv_error, row_error As Boolean
            Me.DgvTrnCirculationvoucherdetil.EndEdit()
            For i = 0 To Me.DgvTrnCirculationvoucherdetil.Rows.Count - 1
                row_error = False
                message = "Data tidak bisa dicanceled karena data sudah di jurnal"
                cell_appbayar = Me.DgvTrnCirculationvoucherdetil.Rows(i).Cells("circulationdetil_appbayar")
                cell_cancel = Me.DgvTrnCirculationvoucherdetil.Rows(i).Cells("circulationdetil_canceled")
                cell_cair = Me.DgvTrnCirculationvoucherdetil.Rows(i).Cells("circulationdetil_appbankcair")
                cell_direksi = Me.DgvTrnCirculationvoucherdetil.Rows(i).Cells("circulationdetil_appdireksi")

                If clsUtil.IsDbNull(Me.obj_Circulation_appuser.Checked, False) = False And clsUtil.IsDbNull(cell_direksi.Value, False) = True Then
                    cell_direksi.ErrorText = "Transaksi harus diapproved user dulu untuk dapat approved direksi"
                    row_error = True
                ElseIf clsUtil.IsDbNull(Me.obj_Circulation_appuser.Checked, False) = True And clsUtil.IsDbNull(cell_cancel.Value, False) = True Then
                    cell_cancel.ErrorText = "Data tidak bisa dicanceled karena data sudah di approved"
                    row_error = True
                ElseIf clsUtil.IsDbNull(cell_cair.Value, False) = True And clsUtil.IsDbNull(cell_cancel.Value, False) = True Then
                    cell_cancel.ErrorText = "Data tidak bisa dicanceled karena data sudah cair dananya"
                    cell_cair.ErrorText = "Data tidak bisa dicanceled karena data sudah cair dananya"
                    row_error = True
                ElseIf clsUtil.IsDbNull(cell_appbayar.Value, False) = True And clsUtil.IsDbNull(cell_cancel.Value, False) = True Then
                    cell_cancel.ErrorText = message
                    cell_appbayar.ErrorText = message
                    row_error = True
                Else
                    cell_cancel.ErrorText = String.Empty
                    cell_direksi.ErrorText = String.Empty
                    cell_appbayar.ErrorText = String.Empty
                    cell_cair.ErrorText = String.Empty

                End If

                If row_error Then
                    dgv_error = True
                    Me.DgvTrnCirculationvoucherdetil.Rows(i).DefaultCellStyle.BackColor = Color.Coral
                Else
                    ' ''Me.DgvTrnCirculationvoucherdetil.Rows(i).DefaultCellStyle.BackColor = Color.White
                    Me.FormatDgvTrnCirculationvoucherdetil(Me.DgvTrnCirculationvoucherdetil)
                End If

            Next

            If dgv_error Then
                Throw New Exception("Data ada yang masih salah!")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, mUiName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return True
        End Try
        Return False
    End Function

#End Region
    Private Sub uiTrnCirculationVoucher_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim objParameters As Collection = New Collection


        'TODO: - Extract Parameter
        '      - Assign parameter
        If Me.Browser IsNot Nothing Then
            objParameters = Me.GetParameterCollection(Me.Parameter)
            Me._CHANNEL = Me.GetValueFromParameter(objParameters, "CHANNEL") 'Me.GetValueFromParameter(objParameters, "CHANNEL")
            Me._CHANNEL_CANBE_CHANGED = False 'Me.GetBolValueFromParameter(objParameters, "CHANNELCHANGED")
            Me._CHANNEL_CANBE_BROWSED = False 'Me.GetBolValueFromParameter(objParameters, "CHANNELBROWSED")
            Me._JURNALTYPE = Me.GetValueFromParameter(objParameters, "JURNALTYPE")
        End If

        'Me.DSN = clsUtil.GetDSN


        If (Me.Browser IsNot Nothing And MyBase.Name = "MainControl") Or (Me.Browser Is Nothing And Application.ProductName <> "TransBrowser") Then
            'Fill Combobox
            'dan fungsi2 startup lainnya....
            Me.DgvTrnCirculationvoucher.DataSource = Me.tbl_TrnCirculationvoucher
            Me.uiTrnCirculationVoucher_LoadComboBox()
            Me.InitLayoutUI()

            Me.BindingStop()
            Me.BindingStart()

            Me.uiTrnCirculationVoucher_NewData()

            Me.btnExcel.ToolTipText = "Export to Excel"
            Me.ToolStrip1.Items.Add(Me.btnExcel)
            Me.btnExcel.Image = Me.ImageList1.Images(2)
            Me.btnExcel.Visible = False

            Me.btnApproved.ToolTipText = "Approved Transaction"
            Me.ToolStrip1.Items.Add(Me.btnApproved)
            Me.btnApproved.Image = Me.ImageList1.Images(1)
            Me.btnApproved.Visible = False

            Me.btnUnApproved.ToolTipText = "UnApproved Transaction"
            Me.ToolStrip1.Items.Add(Me.btnUnApproved)
            Me.btnUnApproved.Image = Me.ImageList1.Images(0)
            Me.btnUnApproved.Visible = False

            Me.tbtnSave.Enabled = False
            Me.tbtnDel.Enabled = False
            Me.tbtnLoad.Enabled = True
            Me.tbtnQuery.Enabled = True


            Me.chkSearchChannel.Checked = Not Me._CHANNEL_CANBE_CHANGED
            Me.chkSearchChannel.Enabled = Me._CHANNEL_CANBE_BROWSED
            Me.cboSearchChannel.Enabled = Me._CHANNEL_CANBE_BROWSED
            Me.cboSearchChannel.SelectedValue = Me._CHANNEL
            Me.cmbSearchAppUser.SelectedItem = "-- PILIH --"
        End If



    End Sub
    Private Sub ftabMain_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ftabMain.SelectedIndexChanged

        Select Case ftabMain.SelectedIndex
            Case 0
                Me.tbtnSave.Enabled = False
                Me.tbtnDel.Enabled = False
                Me.tbtnLoad.Enabled = True
                Me.tbtnQuery.Enabled = True
                Me.ftabMain.TabPages.Item(0).BackColor = Color.LavenderBlush
                Me.ftabMain.TabPages.Item(1).BackColor = Color.White

                Me.btnApproved.Visible = False
                Me.btnUnApproved.Visible = False
                Me.btnExcel.Visible = False

            Case 1
                Me.tbtnSave.Enabled = True
                Me.tbtnDel.Enabled = False 'True
                Me.tbtnLoad.Enabled = False
                Me.tbtnQuery.Enabled = False
                Me.ftabMain.TabPages.Item(0).BackColor = Color.White
                Me.ftabMain.TabPages.Item(1).BackColor = Color.LavenderBlush
                Me.btnExcel.Visible = True

                If Me.DgvTrnCirculationvoucher.CurrentRow IsNot Nothing Then
                    Me.uiTrnCirculationVoucher_OpenRow(Me.DgvTrnCirculationvoucher.CurrentRow.Index)
                Else
                    Me.uiTrnCirculationVoucher_NewData()
                End If


        End Select
    End Sub
    Private Sub uiTrnCirculationVoucher_LoadComboBox()
        If Me._LoadComboInLoadData = False Then
            Me.ComboFill(Me.cboSearchChannel, "channel_id", "channel_name", Me.tbl_MstChannelSearch, "ms_MstChannel_Select", "")

            Me.ComboFill(Me.obj_Circulation_sendto, "authsign_id", "authsign_shortname", Me.tbl_MstAuthSign, "bg_MstAuthsign_Select", "")
            Me.tbl_MstAuthSign.DefaultView.Sort = "authsign_shortname"

            Me.DataFillForCombo("currency_id", "currency_shortname", Me.tbl_MstCurrencyGrid, "ms_MstCurrencyCombo_Select", "")
           
            Me.ComboFill(Me.cmbSearchCreateBy, "username", "user_fullname", Me.tbl_MstUserSearch, "ms_MstUserInsosys_Select", "")
            Me.tbl_MstUserSearch.DefaultView.Sort = "user_fullname"

            Me._LoadComboInLoadData = True
        End If
    End Sub
#Region " Print "
    Private Function uiTrnCirculationVoucher_Print() As Boolean
        Dim i As Integer
        If Me.DgvTrnCirculationvoucher.SelectedRows.Count <= 0 Then
            MsgBox("No data selected")
            Exit Function
        End If

        For i = 0 To Me.DgvTrnCirculationvoucher.SelectedRows.Count - 1
            Dim objRdsH As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
            Dim objReportH As Microsoft.Reporting.WinForms.LocalReport = New Microsoft.Reporting.WinForms.LocalReport
            Dim objDatalistHeader As ArrayList = New ArrayList()
            'Dim parRptImageURL As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("imageURL", Me.SptServer)

            '============ tambahan by ari prasasti <parameter global> 20 April 2012
            Dim dt As DataTable = New DataTable

            dt.Clear()

            clsUtil.DataFill(Me.DSN, dt, "act_select_channel", Me._CHANNEL)

            'fill variabel global
            Dim fileUrl As String = CStr(dt.Rows(0).Item("channel_domainname"))

            '---------------tambahan buat insosys baru 2012-- 19 April 2012---------------
            fileUrl = fileUrl.Replace("\", "/")
            fileUrl = "file:///" & fileUrl & "/services/live/solutions/images/" & Me._CHANNEL & ".jpg"
            '---------------------------------------------------------------

            Dim parRptImageURL As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("imageURL", fileUrl)

            '===end tambahan

            Me.tbl_Print.Clear()
            Me.DataFill(tbl_Print, "act_TrnCirculationvoucher_Select", "circulation_id = '" & Me.DgvTrnCirculationvoucher.SelectedRows.Item(i).Cells("circulation_id").Value & "'", Me._CHANNEL)

            objDatalistHeader = Me.GenerateDataHeader()

            Dim parRptChannelID As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("channelID", Me.strChannel_id)
            Dim parRptChannel_namereport As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("channelName", Me.strChannel_nameReport)
            Dim parRptChannel_address As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("channelAddress", Me.strChannel_address)
            Dim parRptCirculation_id As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("circulation_id", Me.strCirculation_id)
            Dim parRptCirculation_date As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("circulation_date", Me.strCirculation_date)
            Dim parRptRevisi As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("revisi", Me.strRevisi)
            Dim parRptDescr As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("descr", Me.strDescr)
            Dim parRptTotalAmount As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("total_amount", Format(Me.parTotal_amount, "#,##0"))
            Dim parRptTotalForeign As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("total_foreign", Format(Me.parTotal_foreign, "#,##0.00"))


            objRdsH.Name = "ACT_FINANCE_DataSource_clsRptCirculationVoucher"
            objRdsH.Value = objDatalistHeader

            objReportH.ReportEmbeddedResource = "ACT_FINANCE.rptCirculationVoucher.rdlc"
            objReportH.DataSources.Add(objRdsH)
            objReportH.EnableExternalImages = True
            objReportH.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter() {parRptImageURL, parRptChannelID, parRptChannel_namereport, _
                parRptChannel_address, parRptCirculation_id, parRptCirculation_date, parRptRevisi, parRptDescr, _
                parRptTotalAmount, parRptTotalForeign})


            AddHandler objReportH.SubreportProcessing, AddressOf SubreportProcessing
            Export(objReportH)

            m_currentPageIndex = 0
            Print()
        Next
    End Function
    Private Function GenerateDataHeader() As ArrayList
        Dim objDatalistHeader As ArrayList = New ArrayList()
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        ' ''tbl_Print.Clear()
        objPrintHeader = New DataSource.clsRptCirculationVoucher(Me.DSN)
        ' ''DataFill(tbl_Print, "act_TrnCirculationvoucher_Select", "circulation_id = '" & DgvTrnCirculationvoucher.Item("circulation_id", DgvTrnCirculationvoucher.SelectedCells.Item(0).RowIndex).Value & "'")
        With objPrintHeader
            .circulation_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("circulation_id").ToString, String.Empty)
            .circulation_senddt = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("circulation_senddt"), Now())
            .circulation_sendto = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("circulation_sendto"), 0)
            .circulation_foreign = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("circulation_foreign"), 0)
            .circulation_amount = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("circulation_amount"), 0)
            .circulation_descr = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("circulation_descr").ToString, String.Empty)
            .jurnaltype_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("jurnaltype_id").ToString, String.Empty)
            .channel_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("channel_id").ToString, String.Empty)
            .circulation_appuser = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("circulation_appuser"), 0)
            .circulation_appuserby = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("circulation_appuserby").ToString, String.Empty)
            .circulation_appuserdt = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("circulation_appuserdt"), Now())
            .circulation_status = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("circulation_status").ToString, String.Empty)
            .circulation_totalrevisi = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("circulation_totalrevisi"), 0)
            .entry_by = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("entry_by").ToString, String.Empty)
            .entry_dt = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("entry_dt"), Now())
            .modify_by = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("modify_by").ToString, String.Empty)
            .modify_dt = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("modify_dt"), Now())

            Me.strChannel_id = .channel_id
            Me.strChannel_nameReport = .channel_namereport
            Me.strChannel_address = .channel_address
            Me.strCirculation_date = .circulation_senddt
            Me.strRevisi = .circulation_status & "-" & .circulation_totalrevisi
            Me.strCirculation_id = .circulation_id
            Me.strDescr = .circulation_descr

            dbCmd = New OleDb.OleDbCommand("act_TrnCirculationDetilPrint_select", dbConn)
            dbCmd.Parameters.Add("@channel_id", Data.OleDb.OleDbType.VarWChar)
            dbCmd.Parameters("@channel_id").Value = Me._CHANNEL
            dbCmd.Parameters.Add("@circulation_id", Data.OleDb.OleDbType.VarWChar)
            dbCmd.Parameters("@circulation_id").Value = Me.strCirculation_id
            dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarWChar)
            dbCmd.Parameters("@Criteria").Value = " circulationdetil_appdireksi = 0"

            dbCmd.CommandType = CommandType.StoredProcedure
            dbDA = New OleDb.OleDbDataAdapter(dbCmd)
            Me.tbl_PrintDetil.Clear()

            Try
                dbConn.Open()
                dbDA.Fill(Me.tbl_PrintDetil)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "GenerateDataHeader", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                dbConn.Close()
            End Try
            Dim ssql As String
            Dim tbl_temps As DataTable = New DataTable
            ssql = String.Format("SELECT SUM(circulationdetil_amount) AS total_amount , SUM(circulationdetil_foreign) AS total_foreign FROM FRM.E_FRM.dbo.transaksi_circulationvoucherdetil WHERE circulation_id = '{0}' AND circulationdetil_canceled = 0", strCirculation_id)
            Try
                dbDA = New OleDb.OleDbDataAdapter(ssql, dbConn)
                tbl_temps.Clear()
                dbDA.Fill(tbl_temps)

                If tbl_temps.Rows.Count > 0 Then
                    Me.parTotal_amount = tbl_temps.Rows(0).Item("total_amount")
                    Me.parTotal_foreign = tbl_temps.Rows(0).Item("total_foreign")
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            GenerateDataDetail()
        End With
        objDatalistHeader.Add(objPrintHeader)

        Return objDatalistHeader
    End Function
    Private Sub GenerateDataDetail()
        Dim objDetil As DataSource.clsRptCirculationVoucherDetil
        Dim i As Integer

        objDatalistDetil = New ArrayList()
        For i = 0 To Me.tbl_PrintDetil.Rows.Count - 1
            objDetil = New DataSource.clsRptCirculationVoucherDetil(Me.DSN)
            With objDetil
                .circulation_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("circulation_id").ToString, String.Empty)
                .circulationdetil_line = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("circulationdetil_line"), 0)
                .circulationdetil_reference = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("circulationdetil_reference").ToString, String.Empty)
                .circulationdetil_bilyet = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("circulationdetil_bilyet").ToString, String.Empty)
                .circulationdetil_rekanan = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("circulationdetil_rekanan"), 0)
                .circulationdetil_descr = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("circulationdetil_descr").ToString, String.Empty)
                .currency_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("currency_id"), 0)
                .circulationdetil_foreign = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("circulationdetil_foreign"), 0)
                .circulationdetil_rate = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("circulationdetil_rate"), 0)
                .circulationdetil_amount = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("circulationdetil_amount"), 0)
                .channel_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("channel_id").ToString, String.Empty)
                .circulationdetil_appdireksi = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("circulationdetil_appdireksi"), 0)
                .circulationdetil_appdireksi_by = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("circulationdetil_appdireksi_by").ToString, String.Empty)
                .circulationdetil_appdireksi_dt = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("circulationdetil_appdireksi_dt"), Now())
                .circulationdetil_appbayar = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("circulationdetil_appbayar"), 0)
                .circulationdetil_appbayar_by = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("circulationdetil_appbayar_by").ToString, String.Empty)
                .circulationdetil_appbayar_dt = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("circulationdetil_appbayar_dt"), Now())
                .circulationdetil_appbankcair = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("circulationdetil_appbankcair"), 0)
                .circulationdetil_appbankcair_by = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("circulationdetil_appbankcair_by").ToString, String.Empty)
                .circulationdetil_appbankcair_dt = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("circulationdetil_appbankcair_dt"), Now())
                .circulationdetil_canceled = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("circulationdetil_canceled"), 0)
                .circulationdetil_canceledby = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("circulationdetil_canceledby").ToString, String.Empty)
                .circulationdetil_canceleddt = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("circulationdetil_canceleddt"), Now())
                .entry_by = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("entry_by").ToString, String.Empty)
                .entry_dt = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("entry_dt"), Now())
                .modify_by = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("modify_by").ToString, String.Empty)
                .modify_dt = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("modify_dt"), Now())
                .amount_ref_foreign = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("amount_ref_foreign"), clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("circulationdetil_foreign"), 0))
                '.amount_ref_idr = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("amount_ref_idr"), clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("circulationdetil_amount"), 0))
                If .currname = "IDR" Then
                    .amount_ref_idr = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("amount_ref_idr"), clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("circulationdetil_amount"), 0))
                Else
                    .amount_ref_idr = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("amount_ref_foreign_print"), clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("circulationdetil_amount"), 0))

                End If

                .jurnal_id_ref = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("jurnal_id_ref"), String.Empty)
                .currref = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("curr_ref"), String.Empty)
                .currname = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("curr_name"), String.Empty)
                .descref = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("desc_ref"), String.Empty)
                .paymenttype = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("paymenttype"), String.Empty)
            End With
            objDatalistDetil.Add(objDetil)
        Next
    End Sub
    Private Sub Export(ByVal report As Microsoft.Reporting.WinForms.LocalReport)
        Dim warnings() As Microsoft.Reporting.WinForms.Warning = Nothing
        Dim stream As System.IO.Stream
        Dim deviceInfo As String = _
        "<DeviceInfo>" & _
        "  <OutputFormat>EMF</OutputFormat>" & _
        "  <PageWidth>8.27in</PageWidth>" & _
        "  <PageHeight>11.69in</PageHeight>" & _
        "  <MarginLeft>0.22in</MarginLeft>" & _
        "  <MarginRight>0.22in</MarginRight>" & _
        "  <MarginTop>0.5in</MarginTop>" & _
        "  <MarginBottom>0.5in</MarginBottom>" & _
        "</DeviceInfo>"

        

        m_streams = New List(Of System.IO.Stream)()
        report.Render("Image", deviceInfo, AddressOf CreateStream, warnings)
        For Each stream In m_streams
            stream.Position = 0
        Next
    End Sub
    Private Function CreateStream _
    (ByVal name As String, ByVal fileNameExtension As String, ByVal encoding As System.Text.Encoding, ByVal mimeType As String, ByVal willSeek As Boolean) _
    As System.IO.Stream
        Dim stream As System.IO.Stream = New System.IO.FileStream("C:\TransBrowser\Temp" & name & "_" & Date.Now.Second.ToString & "." & fileNameExtension, System.IO.FileMode.Create)

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
        e.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("ACT_FINANCE_DataSource_clsRptCirculationVoucherDetil", objDatalistDetil))
    End Sub
    Private Function uiTrnCirculationVoucher_PrintPreview() As Boolean
        If Me.DgvTrnCirculationvoucher.SelectedRows.Count <= 0 Then
            MsgBox("Belum ada data yang dipilih")
            Exit Function
        End If

        Dim i As Integer

        For i = 0 To Me.DgvTrnCirculationvoucher.SelectedRows.Count - 1
            Dim frmPrint As dlgRptCirculationVoucher = New dlgRptCirculationVoucher(Me.DSN, Me.SptServer, Me.DgvTrnCirculationvoucher.SelectedRows.Item(i).Cells("circulation_id").Value, Me._CHANNEL)
            frmPrint.ShowInTaskbar = False
            frmPrint.StartPosition = FormStartPosition.CenterParent
            frmPrint.ShowDialog(Me)
        Next

    End Function
#End Region
    Private Sub ftabDataDetil_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ftabDataDetil.SelectedIndexChanged
        Dim i, activetab As Byte

        For i = 0 To (Me.ftabDataDetil.TabCount - 1)
            Me.ftabDataDetil.TabPages.Item(i).BackColor = Color.LavenderBlush
        Next
        activetab = Me.ftabDataDetil.SelectedIndex
        Me.ftabDataDetil.TabPages.Item(activetab).BackColor = Color.White
    End Sub


#Region "Event On Dgv Header"
    Private Sub DgvTrnCirculationvoucher_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvTrnCirculationvoucher.CellDoubleClick
        If e.ColumnIndex < 0 Or e.RowIndex < 0 Then
            Exit Sub
        End If
        If Me.DgvTrnCirculationvoucher.CurrentRow IsNot Nothing Then
            Me.ftabMain.SelectedIndex = 1
        End If
    End Sub
    Private Sub DgvTrnCirculationvoucher_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DgvTrnCirculationvoucher.CellFormatting
        Dim approved As Integer
        Dim obj As DataGridView = sender
        Dim objRow As System.Windows.Forms.DataGridViewRow = obj.Rows(e.RowIndex)
        Try
            approved = CType(objRow.Cells("circulation_appuser").Value, Integer)
            If approved Then
                objRow.DefaultCellStyle.BackColor = Color.Thistle
            Else
                objRow.DefaultCellStyle.BackColor = Color.White
            End If
        Catch ex As Exception
        End Try
    End Sub
#End Region
#Region "Event On Dgv Detil"
    Private Sub DgvTrnCirculationvoucherdetil_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DgvTrnCirculationvoucherdetil.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim click As DataGridView.HitTestInfo = Me.DgvTrnCirculationvoucherdetil.HitTest(e.X, e.Y)
            If click.Type = Windows.Forms.DataGrid.HitTestType.Cell Then
                Me.DgvTrnCirculationvoucherdetil.CurrentCell = Me.DgvTrnCirculationvoucherdetil.Rows(click.RowIndex).Cells(click.ColumnIndex)
            End If
        End If
    End Sub
#End Region


 
    
    
    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class
