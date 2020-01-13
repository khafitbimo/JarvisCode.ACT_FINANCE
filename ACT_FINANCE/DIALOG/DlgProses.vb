Public Class DlgProses

    Private Sub DlgProses_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.TopMost = True
    End Sub

    Private Sub pnlLoading_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pnlLoading.Paint
        Dim penGray As New Pen(Color.MidnightBlue, 1)
        Dim pnl As Panel = sender

        e.Graphics.DrawLine(penGray, 0, 0, 0, pnl.Height)
        e.Graphics.DrawLine(penGray, 0, 0, pnl.Width, 0)
        e.Graphics.DrawLine(penGray, pnl.Width - 1, 0, pnl.Width - 1, pnl.Height - 1)
        e.Graphics.DrawLine(penGray, 0, pnl.Height - 1, pnl.Width - 1, pnl.Height - 1)
    End Sub
End Class