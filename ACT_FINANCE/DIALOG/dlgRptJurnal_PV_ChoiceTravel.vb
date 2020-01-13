Public Class dlgRptJurnal_PV_ChoiceTravel
    Private CloseButtonIsPressed As Boolean

    Dim tblkondisi As DataTable = CreateTblPrintKondisi()
    Private statusprint As String

    Public Shared Function CreateTblPrintKondisi() As DataTable
        Dim tbl As DataTable = New DataTable
        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("print_name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("print_check", GetType(System.Boolean)))
        '-------------------------------
        'Default Value: 
        tbl.Columns("print_name").DefaultValue = ""
        tbl.Columns("print_check").DefaultValue = False

        Dim dtRow As DataRow = tbl.NewRow
        dtRow("print_name") = "pv"
        dtRow("print_check") = False
        tbl.Rows.Add(dtRow)

        dtRow = tbl.NewRow
        dtRow("print_name") = "at"
        dtRow("print_check") = False
        tbl.Rows.Add(dtRow)

        dtRow = tbl.NewRow
        dtRow("print_name") = "jv"
        dtRow("print_check") = False
        tbl.Rows.Add(dtRow)

        Return tbl
    End Function

    Public Shadows Function OpenDialog(ByVal owner As System.Windows.Forms.IWin32Window) As DataTable
        'If statusprint <> "Print" Then
        '    btn_AdvanceTravel.Enabled = False
        'End If

        MyBase.ShowDialog(owner)
        If Me.CloseButtonIsPressed Then
            Return Me.tblkondisi
        Else
            Return Nothing
        End If
    End Function
    Public Sub New(ByVal status_print As String)
        statusprint = status_print
        InitializeComponent()
    End Sub
    Private Sub btnPaymentVoucher_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPaymentVoucher.Click
        'Me.kondisi = "PaymentVoucher"
        'Me.CloseButtonIsPressed = True
        'Me.Close()
    End Sub

    Private Sub btnJurnalVoucher_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnJurnalVoucher.Click
        'Me.kondisi = "Jurnal"
        'Me.CloseButtonIsPressed = True
        'Me.Close()
    End Sub

    Private Sub btn_AdvanceTravel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_AdvanceTravel.Click
        'Me.kondisi = "Slip Setoran"
        'Me.CloseButtonIsPressed = True
        'Me.Close()
    End Sub

    Private Sub chkPaymentVoucher_CheckedChanged(sender As Object, e As EventArgs) Handles chkPaymentVoucher.CheckedChanged
        Me.btnPaymentVoucher.Enabled = Me.chkPaymentVoucher.Checked

        If Me.chkPaymentVoucher.Checked = True Then
            For Each dtrow As DataRow In Me.tblkondisi.Rows
                If dtrow("print_name") = "pv" Then
                    dtrow("print_check") = True
                End If
            Next
        Else
            For Each dtrow As DataRow In Me.tblkondisi.Rows
                If dtrow("print_name") = "pv" Then
                    dtrow("print_check") = False
                End If
            Next
        End If

        Me.tblkondisi.AcceptChanges()
    End Sub

    Private Sub chkAdvanceTravel_CheckedChanged(sender As Object, e As EventArgs) Handles chkAdvanceTravel.CheckedChanged
        Me.btn_AdvanceTravel.Enabled = Me.chkAdvanceTravel.Checked

        If Me.chkAdvanceTravel.Checked = True Then
            For Each dtrow As DataRow In Me.tblkondisi.Rows
                If dtrow("print_name") = "at" Then
                    dtrow("print_check") = True
                End If
            Next
        Else
            For Each dtrow As DataRow In Me.tblkondisi.Rows
                If dtrow("print_name") = "at" Then
                    dtrow("print_check") = False
                End If
            Next
        End If

        Me.tblkondisi.AcceptChanges()
    End Sub

    Private Sub chkJournalVoucher_CheckedChanged(sender As Object, e As EventArgs) Handles chkJournalVoucher.CheckedChanged
        Me.btnJurnalVoucher.Enabled = Me.chkJournalVoucher.Checked

        If Me.chkJournalVoucher.Checked = True Then
            For Each dtrow As DataRow In Me.tblkondisi.Rows
                If dtrow("print_name") = "jv" Then
                    dtrow("print_check") = True
                End If
            Next
        Else
            For Each dtrow As DataRow In Me.tblkondisi.Rows
                If dtrow("print_name") = "jv" Then
                    dtrow("print_check") = False
                End If
            Next
        End If

        Me.tblkondisi.AcceptChanges()
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Me.CloseButtonIsPressed = True
        Me.Close()
    End Sub
End Class
