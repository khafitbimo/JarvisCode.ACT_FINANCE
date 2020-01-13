Imports System.Windows.Forms
Imports System.Data.OleDb


Public Class dlgContact
    Private DSN As String
    Private combo As clsDataFiller

    Sub New(ByVal DSN As String)
        Me.InitializeComponent()
        Me.DSN = DSN
        Me.combo = New clsDataFiller(DSN)
    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

End Class
