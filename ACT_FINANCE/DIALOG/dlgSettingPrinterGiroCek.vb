Imports System.Windows.Forms

Public Class dlgSettingPrinterGiroCek
    Private path As String
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        'Me.DialogResult = System.Windows.Forms.DialogResult.OK
        If TextBox1.Text = "" Then
            MsgBox("please type your printer !")
            Exit Sub
        End If

        Dim FILE_NAME As String = "\Gamba_cekgiro_printersetting.txt"
        If System.IO.File.Exists(FILE_NAME) = True Then
            Dim objWriter As New System.IO.StreamWriter(FILE_NAME)
            objWriter.Write(TextBox1.Text)
            objWriter.Close()
            'MsgBox("pri", MsgBoxStyle.OkOnly, "Information")
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        Else
            MsgBox("Gamba_cekgiro_printersetting.txt Does Not Exist")
        End If

        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Public Sub New(ByVal path As String)

        ' This call is required by the designer.
        InitializeComponent()
        Me.path = path
        ' Add any initialization after the InitializeComponent() call.
        Me.TextBox1.Text = Me.path
    End Sub
End Class
