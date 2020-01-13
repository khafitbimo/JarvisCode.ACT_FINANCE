Imports System.Windows.Forms

Public Class dlgMstAcc
    Private DSN As String
    Private cls As clsDataFiller
    Private clsAcc As clsMstAccCa
    Private tblAccCa_combo As DataTable = clsDataset.CreateTblMstAccountCaCombo
    Private tblMstAccCa As DataTable = clsDataset.CreateTblMstAccCa
    Private tblMstAcc_edit As DataTable = clsDataset.CreateTblMstAccCa
    Private acc_index, tipe, acc_ca_id As String


    Sub New(ByVal DSN As String, ByVal tipe As String, ByVal acc_id As String)
        Me.InitializeComponent()
        Me.DSN = DSN
        Me.tipe = tipe
        Me.acc_ca_id = acc_id
        Me.cls = New clsDataFiller(DSN)
        Me.clsAcc = New clsMstAccCa(DSN)
        Me.cls.ComboFillacc_ca(cbParent, "acc_ca_id", "acc_ca_shortname", tblAccCa_combo, "ms_MstAcc_ca_Select", "")
    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Call save()
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub dlgAccount_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Call form_load()
    End Sub

    Private Sub txtAcc_TextChanged(sender As Object, e As EventArgs) Handles txtAccId.TextChanged
        If acc_index <> "" Then
            txtIndex.Text = acc_index + txtAccId.Text
        End If
    End Sub

    Private Function BindingStop() As Boolean
        'stop binding
        Me.txtAccId.DataBindings.Clear()
        Me.txtAccName.DataBindings.Clear()
        Me.txtShort.DataBindings.Clear()
        Me.txtIndex.DataBindings.Clear()
        Me.chkActive.DataBindings.Clear()
        Me.cbParent.DataBindings.Clear()

        Return True
    End Function

    Private Function BindingStart() As Boolean
        'start binding
        Me.txtAccId.DataBindings.Add(New Binding("Text", Me.tblMstAccCa, "acc_ca_id"))
        Me.txtAccName.DataBindings.Add(New Binding("Text", Me.tblMstAccCa, "acc_ca_name"))
        Me.txtShort.DataBindings.Add(New Binding("Text", Me.tblMstAccCa, "acc_ca_shortname"))
        Me.txtIndex.DataBindings.Add(New Binding("Text", Me.tblMstAccCa, "acc_ca_idx"))
        Me.chkActive.DataBindings.Add(New Binding("checked", Me.tblMstAccCa, "acc_ca_active"))
        Me.cbParent.DataBindings.Add(New Binding("selectedValue", Me.tblMstAccCa, "acc_ca_mother"))
        Return True
    End Function

    Sub form_load()
        BindingStop()
        If tipe = "root" Then
            cbParent.SelectedIndex = 0
            Me.BindingContext(Me.tblMstAccCa).AddNew()
            Me.acc_index = ""
            BindingStart()
        ElseIf tipe = "child" Then
            Me.BindingContext(Me.tblMstAccCa).AddNew()
            BindingStart()
            cbParent.SelectedValue = acc_ca_id
            Me.clsAcc.Retrieve(Me.tblMstAcc_edit, "acc_ca_id = '" + acc_ca_id + "'")
            Me.acc_index = IIf(Me.tblMstAcc_edit.Rows(0).Item("acc_ca_mother").ToString = "", Me.tblMstAcc_edit.Rows(0).Item("acc_ca_id").ToString, Me.tblMstAcc_edit.Rows(0).Item("acc_ca_idx").ToString)
        Else
            Me.clsAcc.Retrieve(Me.tblMstAccCa, "acc_ca_id = '" + acc_ca_id + "'")

            BindingStart()
            If Me.tblMstAccCa.Rows(0).Item("acc_ca_idx").ToString = "" Then
                cbParent.SelectedValue = 0
                Me.acc_index = ""
            Else
                Me.acc_index = Strings.Left(Me.tblMstAccCa.Rows(0).Item("acc_ca_idx"), Len(Me.tblMstAccCa.Rows(0).Item("acc_ca_idx")) - Len(Trim(txtAccId.Text)))
            End If
        End If

    End Sub

    Sub save()
        Dim tblMstAccCa_tempchange As DataTable
        Dim i As Integer = 0
        Me.Cursor = Cursors.WaitCursor

        Me.BindingContext(Me.tblMstAccCa).EndCurrentEdit()
        tblMstAccCa_tempchange = Me.tblMstAccCa.GetChanges()

        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbTrans As OleDb.OleDbTransaction

        Dim cookie As Byte() = Nothing

        If tblMstAccCa_tempchange IsNot Nothing Then
            dbConn.Open()
            dbTrans = dbConn.BeginTransaction()
            clsApplicationRole.SetAppRole(dbConn, dbTrans, cookie)
            Try
                clsAcc.Save(tblMstAccCa_tempchange, dbConn, dbTrans)
                If acc_ca_id <> "" Then
                    clsAcc.ChangeAcc_Type(acc_ca_id, dbConn, dbTrans)
                End If

                Me.tblMstAccCa.AcceptChanges()
                dbTrans.Commit()
            Catch ex As Data.OleDb.OleDbException
                dbTrans.Rollback()
                MessageBox.Show(ex.Message, "OLE DB Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "OLE DB Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Finally
                clsApplicationRole.UnsetAppRole(dbConn, dbTrans, cookie)
                dbConn.Close()
            End Try
        End If
        Me.Cursor = Cursors.Arrow
    End Sub
End Class
