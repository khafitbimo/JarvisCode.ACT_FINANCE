Public Class dlgQueryBuilder

    Dim retString As String
    Dim currentString As String

#Region " Constructor & Default Function"

    Public Shadows Function OpenDialog(ByVal owner As System.Windows.Forms.IWin32Window) As String
        MyBase.ShowDialog(owner)
        Return retString
    End Function

#End Region

    Public Function Init(ByVal query As String, ByVal dt As DataTable) As Boolean

        Me.currentString = query
        Me.txtQuery.Text = query

        Dim i As Integer
        For i = 0 To dt.Columns.Count - 1
            Me.listFields.Items.Add(dt.Columns(i).ColumnName)
        Next

        With Me.listOperator.Items
            .Add("=")
            .Add(">")
            .Add(">=")
            .Add("<")
            .Add("<=")
            .Add("Like '...%'")
            .Add("Like '%...'")
            .Add("Like '%..%'")
            .Add("Between")
        End With

        With Me.listLogical.Items
            .Add(" ")
            .Add("And")
            .Add("Or")
        End With

        Me.listFields.SelectedIndex = 0
        Me.listOperator.SelectedIndex = 0
        Me.listLogical.SelectedIndex = 0

    End Function

    Private Sub dlgQueryBuilder_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub


    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Dim qbuilderrow As String = ""

        Try

            Select Case Me.listLogical.Items(Me.listLogical.SelectedIndex).ToString
                Case " "
                    qbuilderrow = " "
                Case "And"
                    qbuilderrow = " And "
                Case "Or"
                    qbuilderrow = " Or "
            End Select

            qbuilderrow &= Me.listFields.Items(Me.listFields.SelectedIndex).ToString

            Select Case Me.listOperator.Items(Me.listOperator.SelectedIndex).ToString
                Case "Like '...%'"
                    qbuilderrow &= " Like '%.' "
                Case "Like '%...'"
                    qbuilderrow &= " Like '.%' "
                Case "Like '%..%'"
                    qbuilderrow &= " Like '%.%' "
                Case "Between"
                    qbuilderrow &= " Between '' And '' "
                Case Else
                    qbuilderrow &= " " & Me.listOperator.Items(Me.listOperator.SelectedIndex).ToString & " '' "
            End Select


            Me.txtQuery.Text = Trim(Me.txtQuery.Text) & " " & qbuilderrow

            Me.listLogical.SelectedIndex = 1


        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Me.retString = Me.txtQuery.Text
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.retString = Me.currentString
        Me.Close()
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        Me.txtQuery.Text = ""
    End Sub

    Private Sub listFields_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles listFields.DoubleClick
        Try
            Me.btnAdd_Click(Me.btnAdd, e)
        Catch ex As Exception
        End Try
    End Sub


End Class