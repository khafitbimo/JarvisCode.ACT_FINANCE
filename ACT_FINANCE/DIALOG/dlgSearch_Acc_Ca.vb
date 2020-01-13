
Public Class dlgSearch_Acc_Ca
    Private CloseButtonIsPressed As Boolean
    Private tbl_temps As DataTable = New DataTable
    Private source As String

    Private retObj As Object


    Public Shadows Function OpenDialog(ByVal owner As System.Windows.Forms.IWin32Window, _
                    ByVal Tbl_temps As DataTable, ByVal source As String) As Object
        Me.tbl_temps = Tbl_temps.Copy
        Me.tbl_temps.Rows(0).Delete()
        Me.source = source
        If Me.source = "account_ca" Then
            Me.Text = "Search Account Ca"
            Me.tbl_temps.DefaultView.Sort = "acc_ca_id"
        End If

        tList_mst_acc.KeyFieldName = "acc_ca_id"
        tList_mst_acc.ParentFieldName = "acc_ca_mother"
        tList_mst_acc.DataSource = Me.tbl_temps
        tList_mst_acc.ExpandAll()

        MyBase.ShowDialog(owner)
        If Me.CloseButtonIsPressed Then
            Return Me.retObj
        Else
            Return Nothing
        End If
    End Function

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Dim retObjTemp As Collection = New Collection

        If Me.tList_mst_acc.FocusedNode IsNot Nothing Then
            retObjTemp.Add(Me.tList_mst_acc.FocusedNode("acc_ca_id").ToString)
            Me.retObj = retObjTemp
            Me.CloseButtonIsPressed = True
        Else
            MsgBox("No Data", MsgBoxStyle.Exclamation, "Exclamation")
            Exit Sub
        End If
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.CloseButtonIsPressed = False
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub obj_search_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles obj_search.TextChanged
        Dim filter As String = String.Empty

        Try
            If Me.source = "rekanan" Then
                filter = String.Format("rekanan_name LIKE '%{0}%'", Me.obj_search.Text)
            ElseIf Me.source = "account" Then
                filter = String.Format("acc_nameshort LIKE '%{0}%'", Me.obj_search.Text)
            ElseIf Me.source = "budget" Then
                filter = String.Format("budget_nameshort LIKE '%{0}%'", Me.obj_search.Text)
            ElseIf Me.source = "budgetdetil" Then
                filter = String.Format("budgetdetil_desc LIKE '%{0}%'", Me.obj_search.Text)
            ElseIf Me.source = "periode" Then
                filter = String.Format("periode_name LIKE '%{0}%'", Me.obj_search.Text)
            ElseIf Me.source = "account_ca" Then
                filter = String.Format("acc_ca_shortname LIKE '%{0}%'", Me.obj_search.Text)
            End If
            If Me.obj_search.Text = String.Empty Then
                filter = String.Empty
            End If

            Me.tbl_temps.DefaultView.RowFilter = filter
        Catch ex As Exception
        End Try

    End Sub

End Class
