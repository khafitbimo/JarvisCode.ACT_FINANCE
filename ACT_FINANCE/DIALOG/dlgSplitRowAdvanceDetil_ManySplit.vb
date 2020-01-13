Imports System.Windows.Forms

Public Class dlgSplitRowAdvanceDetil_ManySplit

    Private line, description, currency, rate, amount, subtotal As String
    Private openDialog As Boolean = True

    Private Function OK_Rule() As Boolean
        Dim isOK As Boolean = True

        If Me.chk_split1.Checked = True And Me.obj_split1.Text = 0 Then
            MsgBox("If your selected a Split 1, The value cant be 0 !", MsgBoxStyle.Information, "Information")
            isOK = False
            Return isOK
            Exit Function
        End If
        If Me.chk_split2.Checked = True And Me.obj_split2.Text = 0 Then
            MsgBox("If your selected a Split 2, The value cant be 0 !", MsgBoxStyle.Information, "Information")
            isOK = False
            Return isOK
            Exit Function
        End If
        If Me.chk_split3.Checked = True And Me.obj_split3.Text = 0 Then
            MsgBox("If your selected a Split 3, The value cant be 0 !", MsgBoxStyle.Information, "Information")
            isOK = False
            Return isOK
            Exit Function
        End If
        If Me.chk_split4.Checked = True And Me.obj_split4.Text = 0 Then
            MsgBox("If your selected a Split 4, The value cant be 0 !", MsgBoxStyle.Information, "Information")
            isOK = False
            Return isOK
            Exit Function
        End If
        If Me.chk_split5.Checked = True And Me.obj_split5.Text = 0 Then
            MsgBox("If your selected a Split 5, The value cant be 0 !", MsgBoxStyle.Information, "Information")
            isOK = False
            Return isOK
            Exit Function
        End If
        If Me.chk_split6.Checked = True And Me.obj_split6.Text = 0 Then
            MsgBox("If your selected a Split 6, The value cant be 0 !", MsgBoxStyle.Information, "Information")
            isOK = False
            Return isOK
            Exit Function
        End If
        If Me.chk_split7.Checked = True And Me.obj_split7.Text = 0 Then
            MsgBox("If your selected a Split 7, The value cant be 0 !", MsgBoxStyle.Information, "Information")
            isOK = False
            Return isOK
            Exit Function
        End If
        If Me.chk_split8.Checked = True And Me.obj_split8.Text = 0 Then
            MsgBox("If your selected a Split 8, The value cant be 0 !", MsgBoxStyle.Information, "Information")
            isOK = False
            Return isOK
            Exit Function
        End If
        If Me.chk_split9.Checked = True And Me.obj_split9.Text = 0 Then
            MsgBox("If your selected a Split 9, The value cant be 0 !", MsgBoxStyle.Information, "Information")
            isOK = False
            Return isOK
            Exit Function
        End If
        If Me.chk_split10.Checked = True And Me.obj_split10.Text = 0 Then
            MsgBox("If your selected a Split 10, The value cant be 0 !!", MsgBoxStyle.Information, "Information")
            isOK = False
            Return isOK
            Exit Function
        End If

        Return isOK

    End Function

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click

        If Me.OK_Rule = True Then
            If lb_sisa.Text = 0 Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Me.Close()
            Else
                MsgBox("Split remains must be 0 !")
            End If
        End If
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Public Sub New(ByVal line As String, ByVal description As String, ByVal currency As String, _
                   ByVal rate As String, ByVal amount As String, ByVal subtotal As String)

        Me.line = line
        Me.description = description
        Me.currency = currency
        Me.rate = rate
        Me.amount = amount
        Me.subtotal = subtotal

        InitializeComponent()

    End Sub

    Private Sub dlgSplitRowAdvanceDetil_ManySplit_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.obj_line.Text = Me.line
        Me.obj_currency.Text = Me.currency
        Me.obj_desc.Text = Me.description
        Me.obj_rate.Text = Me.rate
        Me.obj_amount.Text = Me.amount
        Me.obj_subtotal.Text = Me.subtotal


        Me.openDialog = True

        Me.chk_split1.Checked = True
        Me.chk_split2.Checked = True
        Me.chk_split3.Checked = False
        Me.chk_split4.Checked = False
        Me.chk_split5.Checked = False
        Me.chk_split6.Checked = False
        Me.chk_split7.Checked = False
        Me.chk_split8.Checked = False
        Me.chk_split9.Checked = False
        Me.chk_split10.Checked = False

        Me.chk_split1.Enabled = False
        Me.chk_split2.Enabled = False
        Me.chk_split3.Enabled = True
        Me.chk_split4.Enabled = False
        Me.chk_split5.Enabled = False
        Me.chk_split6.Enabled = False
        Me.chk_split7.Enabled = False
        Me.chk_split8.Enabled = False
        Me.chk_split9.Enabled = False
        Me.chk_split10.Enabled = False

        Me.obj_split1.Enabled = True
        Me.obj_split2.Enabled = True
        Me.obj_split3.Enabled = False
        Me.obj_split4.Enabled = False
        Me.obj_split5.Enabled = False
        Me.obj_split6.Enabled = False
        Me.obj_split7.Enabled = False
        Me.obj_split8.Enabled = False
        Me.obj_split9.Enabled = False
        Me.obj_split10.Enabled = False

        Call Sisa(Me.openDialog)
        Me.openDialog = False

    End Sub

    Private Sub chk_split3_CheckedChanged(sender As Object, e As EventArgs) Handles chk_split3.CheckedChanged
        If chk_split3.Checked = True Then
            Me.obj_split3.Enabled = True
            Me.chk_split4.Enabled = True
        Else
            Me.obj_split3.Enabled = False
            Me.obj_split4.Enabled = False
            Me.obj_split5.Enabled = False
            Me.obj_split6.Enabled = False
            Me.obj_split7.Enabled = False
            Me.obj_split8.Enabled = False
            Me.obj_split9.Enabled = False
            Me.obj_split10.Enabled = False

            Me.obj_split3.Text = 0
            Me.obj_split4.Text = 0
            Me.obj_split5.Text = 0
            Me.obj_split6.Text = 0
            Me.obj_split7.Text = 0
            Me.obj_split8.Text = 0
            Me.obj_split9.Text = 0
            Me.obj_split10.Text = 0

            Me.chk_split4.Checked = False
            Me.chk_split5.Checked = False
            Me.chk_split6.Checked = False
            Me.chk_split7.Checked = False
            Me.chk_split8.Checked = False
            Me.chk_split9.Checked = False
            Me.chk_split10.Checked = False

            Me.chk_split4.Enabled = False
            Me.chk_split5.Enabled = False
            Me.chk_split6.Enabled = False
            Me.chk_split7.Enabled = False
            Me.chk_split8.Enabled = False
            Me.chk_split9.Enabled = False
            Me.chk_split10.Enabled = False

        End If
    End Sub

    Private Sub chk_split4_CheckedChanged(sender As Object, e As EventArgs) Handles chk_split4.CheckedChanged
        If chk_split4.Checked = True Then
            Me.obj_split4.Enabled = True
            Me.chk_split5.Enabled = True
        Else
            Me.obj_split4.Enabled = False
            Me.obj_split5.Enabled = False
            Me.obj_split6.Enabled = False
            Me.obj_split7.Enabled = False
            Me.obj_split8.Enabled = False
            Me.obj_split9.Enabled = False
            Me.obj_split10.Enabled = False

            Me.obj_split4.Text = 0
            Me.obj_split5.Text = 0
            Me.obj_split6.Text = 0
            Me.obj_split7.Text = 0
            Me.obj_split8.Text = 0
            Me.obj_split9.Text = 0
            Me.obj_split10.Text = 0

            Me.chk_split5.Checked = False
            Me.chk_split6.Checked = False
            Me.chk_split7.Checked = False
            Me.chk_split8.Checked = False
            Me.chk_split9.Checked = False
            Me.chk_split10.Checked = False

            Me.chk_split5.Enabled = False
            Me.chk_split6.Enabled = False
            Me.chk_split7.Enabled = False
            Me.chk_split8.Enabled = False
            Me.chk_split9.Enabled = False
            Me.chk_split10.Enabled = False
        End If
    End Sub

    Private Sub chk_split5_CheckedChanged(sender As Object, e As EventArgs) Handles chk_split5.CheckedChanged
        If chk_split5.Checked = True Then
            Me.obj_split5.Enabled = True
            Me.chk_split6.Enabled = True
        Else
            Me.obj_split5.Enabled = False
            Me.obj_split6.Enabled = False
            Me.obj_split7.Enabled = False
            Me.obj_split8.Enabled = False
            Me.obj_split9.Enabled = False
            Me.obj_split10.Enabled = False

            Me.obj_split5.Text = 0
            Me.obj_split6.Text = 0
            Me.obj_split7.Text = 0
            Me.obj_split8.Text = 0
            Me.obj_split9.Text = 0
            Me.obj_split10.Text = 0

            Me.chk_split6.Checked = False
            Me.chk_split7.Checked = False
            Me.chk_split8.Checked = False
            Me.chk_split9.Checked = False
            Me.chk_split10.Checked = False

            Me.chk_split6.Enabled = False
            Me.chk_split7.Enabled = False
            Me.chk_split8.Enabled = False
            Me.chk_split9.Enabled = False
            Me.chk_split10.Enabled = False
        End If
    End Sub

    Private Sub chk_split6_CheckedChanged(sender As Object, e As EventArgs) Handles chk_split6.CheckedChanged
        If chk_split6.Checked = True Then
            Me.obj_split6.Enabled = True
            Me.chk_split7.Enabled = True
        Else

            Me.obj_split6.Enabled = False
            Me.obj_split7.Enabled = False
            Me.obj_split8.Enabled = False
            Me.obj_split9.Enabled = False
            Me.obj_split10.Enabled = False

            Me.obj_split6.Text = 0
            Me.obj_split7.Text = 0
            Me.obj_split8.Text = 0
            Me.obj_split9.Text = 0
            Me.obj_split10.Text = 0

            Me.chk_split7.Checked = False
            Me.chk_split8.Checked = False
            Me.chk_split9.Checked = False
            Me.chk_split10.Checked = False

            Me.chk_split7.Enabled = False
            Me.chk_split8.Enabled = False
            Me.chk_split9.Enabled = False
            Me.chk_split10.Enabled = False
        End If
    End Sub

    Private Sub chk_split7_CheckedChanged(sender As Object, e As EventArgs) Handles chk_split7.CheckedChanged
        If chk_split7.Checked = True Then
            Me.obj_split7.Enabled = True
            Me.chk_split8.Enabled = True
        Else

            Me.obj_split7.Enabled = False
            Me.obj_split8.Enabled = False
            Me.obj_split9.Enabled = False
            Me.obj_split10.Enabled = False

            Me.obj_split7.Text = 0
            Me.obj_split8.Text = 0
            Me.obj_split9.Text = 0
            Me.obj_split10.Text = 0

            Me.chk_split8.Checked = False
            Me.chk_split9.Checked = False
            Me.chk_split10.Checked = False

            Me.chk_split8.Enabled = False
            Me.chk_split9.Enabled = False
            Me.chk_split10.Enabled = False
        End If
    End Sub

    Private Sub chk_split8_CheckedChanged(sender As Object, e As EventArgs) Handles chk_split8.CheckedChanged
        If chk_split8.Checked = True Then
            Me.obj_split8.Enabled = True
            Me.chk_split9.Enabled = True
        Else
            Me.obj_split8.Enabled = False
            Me.obj_split9.Enabled = False
            Me.obj_split10.Enabled = False

            Me.obj_split8.Text = 0
            Me.obj_split9.Text = 0
            Me.obj_split10.Text = 0

            Me.chk_split9.Checked = False
            Me.chk_split10.Checked = False

            Me.chk_split9.Enabled = False
            Me.chk_split10.Enabled = False
        End If
    End Sub

    Private Sub chk_split9_CheckedChanged(sender As Object, e As EventArgs) Handles chk_split9.CheckedChanged
        If chk_split9.Checked = True Then
            Me.obj_split9.Enabled = True
            Me.chk_split10.Enabled = True
        Else
            Me.obj_split9.Enabled = False
            Me.obj_split10.Enabled = False

            Me.obj_split9.Text = 0
            Me.obj_split10.Text = 0

            Me.chk_split10.Checked = False

            Me.chk_split10.Enabled = False

        End If
    End Sub

    Private Sub chk_split10_CheckedChanged(sender As Object, e As EventArgs) Handles chk_split10.CheckedChanged
        If chk_split10.Checked = True Then
            Me.obj_split10.Enabled = True
        Else
            Me.obj_split10.Enabled = False
            Me.obj_split10.Text = 0
        End If
    End Sub

    Private Function Sisa(ByVal openDialog As Boolean) As Integer
        Dim sisapersen As Integer
        Dim s1, s2, s3, s4, s5, s6, s7, s8, s9, s10 As Integer

        If openDialog = True Then
            s1 = 0
            s2 = 0
            s3 = 0
            s4 = 0
            s5 = 0
            s6 = 0
            s7 = 0
            s8 = 0
            s9 = 0
            s10 = 0
            sisapersen = 100 - (s1 + s2 + s3 + s4 + s5 + s6 + s7 + s8 + s9 + s10)
        Else

            s1 = Me.obj_split1.Text
            s2 = Me.obj_split2.Text
            s3 = Me.obj_split3.Text
            s4 = Me.obj_split4.Text
            s5 = Me.obj_split5.Text
            s6 = Me.obj_split6.Text
            s7 = Me.obj_split7.Text
            s8 = Me.obj_split8.Text
            s9 = Me.obj_split9.Text
            s10 = Me.obj_split10.Text


            sisapersen = 100 - (s1 + s2 + s3 + s4 + s5 + s6 + s7 + s8 + s9 + s10)
            If sisapersen < 0 Then
                MsgBox("Over split value !", MsgBoxStyle.Critical, "Critical")
            End If
        End If

        lb_sisa.Text = sisapersen
        Return sisapersen

    End Function

    Private Sub obj_split1_TextChanged(sender As Object, e As EventArgs) Handles obj_split1.TextChanged
        If Me.obj_split1.Text = "" Then
            Me.obj_split1.Text = 0
        End If

        If Me.Sisa(Me.openDialog) < 0 Then
            Me.obj_split1.Text = 0
        End If
    End Sub

    Private Sub obj_split2_TextChanged(sender As Object, e As EventArgs) Handles obj_split2.TextChanged
        If Me.obj_split2.Text = "" Then
            Me.obj_split2.Text = 0
        End If
        If Me.Sisa(Me.openDialog) < 0 Then
            Me.obj_split2.Text = 0
        End If
    End Sub

    Private Sub obj_split3_TextChanged(sender As Object, e As EventArgs) Handles obj_split3.TextChanged
        If Me.obj_split3.Text = "" Then
            Me.obj_split3.Text = 0
        End If
        If Me.Sisa(Me.openDialog) < 0 Then
            Me.obj_split3.Text = 0
        End If
    End Sub

    Private Sub obj_split4_TextChanged(sender As Object, e As EventArgs) Handles obj_split4.TextChanged
        If Me.obj_split4.Text = "" Then
            Me.obj_split4.Text = 0
        End If
        If Me.Sisa(Me.openDialog) < 0 Then
            Me.obj_split4.Text = 0
        End If
    End Sub

    Private Sub obj_split5_TextChanged(sender As Object, e As EventArgs) Handles obj_split5.TextChanged
        If Me.obj_split5.Text = "" Then
            Me.obj_split5.Text = 0
        End If
        If Me.Sisa(Me.openDialog) < 0 Then
            Me.obj_split5.Text = 0
        End If
    End Sub

    Private Sub obj_split6_TextChanged(sender As Object, e As EventArgs) Handles obj_split6.TextChanged
        If Me.obj_split6.Text = "" Then
            Me.obj_split6.Text = 0
        End If
        If Me.Sisa(Me.openDialog) < 0 Then
            Me.obj_split6.Text = 0
        End If
    End Sub

    Private Sub obj_split7_TextChanged(sender As Object, e As EventArgs) Handles obj_split7.TextChanged
        If Me.obj_split7.Text = "" Then
            Me.obj_split7.Text = 0
        End If
        If Me.Sisa(Me.openDialog) < 0 Then
            Me.obj_split7.Text = 0
        End If
    End Sub

    Private Sub obj_split8_TextChanged(sender As Object, e As EventArgs) Handles obj_split8.TextChanged
        If Me.obj_split8.Text = "" Then
            Me.obj_split8.Text = 0
        End If
        If Me.Sisa(Me.openDialog) < 0 Then
            Me.obj_split8.Text = 0
        End If
    End Sub

    Private Sub obj_split9_TextChanged(sender As Object, e As EventArgs) Handles obj_split9.TextChanged
        If Me.obj_split9.Text = "" Then
            Me.obj_split9.Text = 0
        End If
        If Me.Sisa(Me.openDialog) < 0 Then
            Me.obj_split8.Text = 0
        End If
    End Sub

    Private Sub obj_split10_TextChanged(sender As Object, e As EventArgs) Handles obj_split10.TextChanged
        If Me.obj_split10.Text = "" Then
            Me.obj_split10.Text = 0
        End If
        If Me.Sisa(Me.openDialog) < 0 Then
            Me.obj_split10.Text = 0
        End If
    End Sub
End Class
