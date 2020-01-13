Public Class uiRptBankReport
    Private tbl_MstBankAcc As DataTable = clsDataset.CreateTblMstBankAccCombo()

#Region " Window Parameter "
    ' TODO: Buat variabel untuk menampung parameter window 
    Private _CHANNEL As String = "TAS"
#End Region

    Public Sub Form_Load(ByVal sender As Object)
        If (Me.Browser IsNot Nothing And MyBase.Name = _Name) Or (Me.Browser Is Nothing And Application.ProductName <> _ProductName) Then
            Me.ComboFill(Me.cboBankName, "bankacc_id", "bankacc_reportname", Me.tbl_MstBankAcc, "cp_MstBankacc_Select", "channel_id = '" & Me._CHANNEL & "'")
            Me.ftabMain_Data.Dispose()
            Me.tbtnNew.Visible = False
            Me.tbtnSave.Visible = False
            Me.tbtnLoad.Visible = False
            Me.tbtnDel.Visible = False
            Me.tbtnLoad.Visible = False
            Me.tbtnEdit.Visible = False
            Me.tbtnFirst.Visible = False
            Me.tbtnLast.Visible = False
            Me.tbtnNext.Visible = False
            Me.tbtnPrev.Visible = False
            Me.tbtnPrint.Visible = False
            Me.tbtnPrintPreview.Visible = False
            Me.tbtnQuery.Visible = False
            Me.tbtnRefresh.Visible = False
            Me.obj_channel.Text = Me._CHANNEL
        End If
    End Sub

    Private Sub uiRptBankReport_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Me.IsDevelopment = True Then Me.Form_Load(sender)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim dbconn As New OleDb.OleDbConnection(Me.DSN)
        Dim da As OleDb.OleDbDataAdapter
        Dim command As OleDb.OleDbCommand
        Dim tbl_temp As DataTable = New DataTable
        Dim cookie As Byte() = Nothing

        Try
            dbconn.Open()
            clsApplicationRole.SetAppRole(dbconn, cookie)
            command = New OleDb.OleDbCommand("act_bankreport1", dbconn)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@start_date", OleDb.OleDbType.DBTimeStamp, 4).Value = Format(Me.dtStartDate.Value, "yyyy-MM-dd")
            command.Parameters.Add("@end_date", OleDb.OleDbType.DBTimeStamp, 4).Value = Format(Me.dtEndDate.Value, "yyyy-MM-dd")
            command.Parameters.Add("@bank_id", OleDb.OleDbType.Integer, 4).Value = Me.cboBankName.SelectedValue

            Dim channelnumber As String = GetChannelNumber()

            command.Parameters.Add("@periode_id", OleDb.OleDbType.Integer, 4).Value = Format(Me.dtStartDate.Value, GetChannelNumber() + "yyMM")

            da = New OleDb.OleDbDataAdapter(command)
            da.Fill(tbl_temp)

            If tbl_temp.Rows.Count <= 0 Then
                MessageBox.Show("Cannot export empty table.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                If tbl_temp.Rows.Count - 1 > 65534 Then
                    MessageBox.Show("The row number is exceed the limit of maximum Ms-Excel`s row.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    Me.lblProgress.Visible = True
                    Me.ProgressBar1.Visible = True

                    Dim ColumnIndex As Integer = 0
                    Dim RowIndex As Integer = 0
                    Dim xl As Excel.Application = New Excel.Application
                    Dim xlBook As Excel.Workbook = xl.Workbooks.Add
                    Dim xlWorksheet As Excel.Worksheet = CType(xlBook.Worksheets(1), Excel.Worksheet)

                    xl.Visible = False

                    Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

                    Try
                        For Each col As System.Data.DataColumn In tbl_temp.Columns
                            ColumnIndex = ColumnIndex + 1
                            xlWorksheet.Cells(1, ColumnIndex).Value = col.ColumnName
                        Next

                        For Each row As System.Data.DataRow In tbl_temp.Rows
                            RowIndex = RowIndex + 1
                            ColumnIndex = 0

                            For Each col As System.Data.DataColumn In tbl_temp.Columns
                                ColumnIndex = ColumnIndex + 1

                                Dim cMark As String = Mid(row.Item(ColumnIndex - 1).ToString, 1, 1)
                                If cMark = "=" Then cMark = "'" & row.Item(ColumnIndex - 1).ToString Else cMark = row.Item(ColumnIndex - 1).ToString

                                xlWorksheet.Cells(RowIndex + 1, ColumnIndex).Value = cMark
                                lblProgress.Text = "Exporting " & RowIndex & " of " & tbl_temp.Rows.Count & " records"
                                lblProgress.Refresh()
                                ProgressBar1.Value = CInt(100 * (RowIndex / tbl_temp.Rows.Count))
                                ProgressBar1.Refresh()
                            Next
                        Next
                        MessageBox.Show("Export Complete", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        xl.Visible = True
                    Catch ex As Exception
                        MessageBox.Show("Error" & vbCrLf & ex.Message)
                    End Try
                End If

            End If

            Me.lblProgress.Visible = False
            Me.ProgressBar1.Visible = False
            Me.Cursor = Cursors.Default
        
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            clsApplicationRole.UnsetAppRole(dbconn, cookie)
            dbconn.Close()
        End Try
    End Sub

    Private Function GetChannelNumber() As String
        Dim dbconn As New OleDb.OleDbConnection(Me.DSN)
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter
        Dim tbl_MstChannel As DataTable = New DataTable
        Dim cookie As Byte() = Nothing

        dbCmd = New OleDb.OleDbCommand("ms_MstChannel_Select", dbconn)
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@Criteria").Value = String.Format("channel_id='{0}'", Me._CHANNEL)
        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)
        tbl_MstChannel.Clear()

        Try
            dbconn.Open()
            clsApplicationRole.SetAppRole(dbconn, cookie)
            dbDA.Fill(tbl_MstChannel)
            Return tbl_MstChannel.Rows(0).Item("channel_number").ToString
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            clsApplicationRole.UnsetAppRole(dbconn, cookie)
            dbconn.Close()
        End Try

    End Function
End Class
