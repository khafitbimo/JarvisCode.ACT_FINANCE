Imports System.Windows.Forms

Public Class DlgDate
    Private _value As Date

    Public Property Value As Date
        Get
            Return Me._value
        End Get
        Set(value As Date)
            Me._value = value
            Me.DateNavigator1.DateTime = value
        End Set
    End Property

    Private Sub SBClear_Click(sender As Object, e As EventArgs) Handles SBClear.Click
        Me._value = Nothing

        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub SBOK_Click(sender As Object, e As EventArgs) Handles SBOK.Click
        Me._value = Me.DateNavigator1.DateTime

        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub SBCancel_Click(sender As Object, e As EventArgs) Handles SBCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class
