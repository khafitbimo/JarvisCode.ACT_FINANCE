Public Class clsTrnJurnal
    Private DSN As String

    Sub New(ByVal DSN As String)
        Me.DSN = DSN
    End Sub

    Public Sub Posting(ByVal jurnal_id As String, ByVal jurnal_postby As String, ByVal dbConn As OleDb.OleDbConnection, _
                       ByVal dbTrans As OleDb.OleDbTransaction)
        Dim cmd As OleDb.OleDbCommand

        Try
            cmd = New OleDb.OleDbCommand("act_TrnJurnal_Posting", dbConn, dbTrans)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@jurnal_id", String.Format(" jurnal_id = '{0}'", jurnal_id))
            cmd.Parameters.AddWithValue("@jurnal_postby", jurnal_postby)
            cmd.Parameters.AddWithValue("@posting_method", "POSTING")

            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub UnPosting(ByVal jurnal_id As String, ByVal jurnal_postby As String, ByVal dbConn As OleDb.OleDbConnection, _
                         ByVal dbTrans As OleDb.OleDbTransaction)
        Dim cmd As OleDb.OleDbCommand

        Try
            cmd = New OleDb.OleDbCommand("act_TrnJurnal_Posting", dbConn, dbTrans)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@jurnal_id", String.Format(" jurnal_id = '{0}'", jurnal_id))
            cmd.Parameters.AddWithValue("@jurnal_postby", jurnal_postby)
            cmd.Parameters.AddWithValue("@posting_method", "UNPOSTING")

            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
