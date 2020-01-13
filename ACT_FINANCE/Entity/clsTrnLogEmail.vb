Public Class clsTrnLogEmail
    Private DSN As String

#Region " Constructor "
    Sub New(ByVal DSN As String)
        Me.DSN = DSN
    End Sub
#End Region

    'Public Function [Select](ByVal username As String) As Specialized.OrderedDictionary
    '    Dim dbConn As New OleDb.OleDbConnection(Me.DSN)
    '    Dim cmd As OleDb.OleDbCommand
    '    Dim reader As OleDb.OleDbDataReader
    '    Dim criteria As String
    '    Dim res As New Specialized.OrderedDictionary

    '    Try
    '        dbConn.Open()

    '        criteria = String.Format(" username = '{0}'", username)

    '        cmd = New OleDb.OleDbCommand("ms_MstUser_Select", dbConn)
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.Parameters.AddWithValue("@criteria", criteria)

    '        cmd.ExecuteNonQuery()
    '        reader = cmd.ExecuteReader()

    '        For i As Integer = 0 To reader.FieldCount - 1
    '            res.Add(reader.GetName(i), DBNull.Value)
    '        Next

    '        If reader.HasRows = True Then
    '            While reader.Read()
    '                For i As Integer = 0 To reader.FieldCount - 1
    '                    res.Item(i) = reader.Item(i)
    '                Next
    '            End While
    '        End If
    '    Catch ex As Exception
    '        Throw ex
    '    Finally
    '        If dbConn.State = ConnectionState.Open Then
    '            dbConn.Close()
    '        End If
    '    End Try

    '    Return res
    'End Function

    Public Sub InsertTrnLogEmail(ByVal ref_id As String, ByVal user_from As String, ByVal email_from As String, ByVal user_to As String, ByVal email_to As String, _
                                    ByVal events As String)
        Dim dbConn As New OleDb.OleDbConnection(Me.DSN)
        Dim cmd As OleDb.OleDbCommand
        Dim res As New Specialized.OrderedDictionary
        Dim cookie As Byte() = Nothing

        Try
            dbConn.Open()
            clsApplicationRole.SetAppRole(dbConn, cookie)

            cmd = New OleDb.OleDbCommand("log_TrnLogEmail_Insert", dbConn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@ref_id", ref_id)
            cmd.Parameters.AddWithValue("@user_from", user_from)
            cmd.Parameters.AddWithValue("@email_from", email_from)
            cmd.Parameters.AddWithValue("@user_to", user_to)
            cmd.Parameters.AddWithValue("@email_to", email_to)
            cmd.Parameters.AddWithValue("@event", events)
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            Throw ex
        Finally
            If dbConn.State = ConnectionState.Open Then
                clsApplicationRole.UnsetAppRole(dbConn, cookie)
                dbConn.Close()
            End If
        End Try
    End Sub

End Class
