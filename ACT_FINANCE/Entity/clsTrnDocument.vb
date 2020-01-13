Public Class clsTrnDocument
    Private DSN As String
    Private channel_id As String

    Sub New(ByVal DSN As String, ByVal channel_id As String)
        Me.DSN = DSN
        Me.channel_id = channel_id
    End Sub

    Public Sub Retrieve(objTbl As DataTable, ByVal criteria As String)
        Dim dbConn As New OleDb.OleDbConnection(Me.DSN)
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter
        Dim cookie As Byte() = Nothing

        dbCmd = New OleDb.OleDbCommand("act_TrnJurnalDocument_Select", dbConn)
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@Criteria").Value = criteria
        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)

        Try
            dbConn.Open()
            clsApplicationRole.SetAppRole(dbConn, cookie)
            dbDA.Fill(objTbl)
        Catch ex As Exception
            Throw ex
        Finally
            clsApplicationRole.UnsetAppRole(dbConn, cookie)
            dbConn.Close()
        End Try

    End Sub

    Public Function ifExist(objTbl As DataTable, ByVal criteria As String) As Boolean
        Dim dbConn As New OleDb.OleDbConnection(Me.DSN)
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter
        objTbl.Clear()
        dbCmd = New OleDb.OleDbCommand("act_TrnJurnalDocument_Select", dbConn)
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@Criteria").Value = criteria
        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)

        Dim cookie As Byte() = Nothing
        Try
            dbConn.Open()
            clsApplicationRole.SetAppRole(dbConn, cookie)
            dbDA.Fill(objTbl)
            If objTbl.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Throw ex
            Return False
        Finally
            clsApplicationRole.UnsetAppRole(dbConn, cookie)
            dbConn.Close()
        End Try
    End Function

    Public Function filltextbox(ByVal jurnal_id As String) As String
        Dim doc_id As String = ""
        Dim tbl_document As New DataTable
        Dim criteria As String = String.Format(" channel_id = '{0}' and jurnal_id = '{1}'", channel_id, jurnal_id)

        If ifExist(tbl_document, criteria) Then
            doc_id = tbl_document.Rows(0).Item("doc_id").ToString
        End If
        Return doc_id
    End Function
End Class
