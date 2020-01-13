Public Class dlgRptJurnal_PV_Choice
    Private CloseButtonIsPressed As Boolean

    Dim kondisi As String
    Private statusprint As String

    Public Shadows Function OpenDialog(ByVal owner As System.Windows.Forms.IWin32Window) As String
        If statusprint <> "Print" Then
            btn_SlipSetoran.Enabled = False
        End If
        MyBase.ShowDialog(owner)
        If Me.CloseButtonIsPressed Then
            Return Me.kondisi
        Else
            Return Nothing
        End If
    End Function
    Public Sub New(ByVal status_print As String)
        statusprint = status_print
        InitializeComponent()
    End Sub
    Private Sub btnFull_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFull.Click
        Me.kondisi = "PaymentVoucher"
        Me.CloseButtonIsPressed = True
        Me.Close()
    End Sub


    Private Sub btnJurnalVoucher_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnJurnalVoucher.Click
        Me.kondisi = "Jurnal"
        Me.CloseButtonIsPressed = True
        Me.Close()
    End Sub

    Private Sub btn_SlipSetoran_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_SlipSetoran.Click
        Me.kondisi = "Slip Setoran"
        Me.CloseButtonIsPressed = True
        Me.Close()
    End Sub
End Class
