Public Class clsMstAccCa
    Private DSN As String
    Private channel_id As String

    Sub New(ByVal DSN As String)
        Me.DSN = DSN
    End Sub

    Sub New(ByVal DSN As String, ByVal channel_id As String)
        Me.DSN = DSN
        Me.channel_id = channel_id
    End Sub

    Public Sub Retrieve(objTbl As DataTable, ByVal Criteria As String)
        objTbl.Clear()
        Dim dbConn As New OleDb.OleDbConnection(Me.DSN)
            Dim dbCmd As OleDb.OleDbCommand
            Dim dbDA As OleDb.OleDbDataAdapter

            dbCmd = New OleDb.OleDbCommand("ms_MstAcc_ca_Select", dbConn)
            dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
            dbCmd.Parameters("@Criteria").Value = Criteria
            dbCmd.CommandType = CommandType.StoredProcedure
            dbDA = New OleDb.OleDbDataAdapter(dbCmd)
            Dim cookie As Byte() = Nothing
          
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

    Public Sub Save(ByVal objTbl As DataTable, ByVal dbConn As OleDb.OleDbConnection, ByVal dbTrans As OleDb.OleDbTransaction)
        Dim dbCmdInsert As OleDb.OleDbCommand
        Dim dbCmdUpdate As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        dbCmdInsert = New OleDb.OleDbCommand("ms_MstAcc_ca_Insert", dbConn, dbTrans)
        dbCmdInsert.CommandType = CommandType.StoredProcedure
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@acc_ca_id", System.Data.OleDb.OleDbType.Integer, 7, "acc_ca_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@acc_ca_name", System.Data.OleDb.OleDbType.VarWChar, 100, "acc_ca_name"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@acc_ca_shortname", System.Data.OleDb.OleDbType.VarWChar, 100, "acc_ca_shortname"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@acc_ca_type", 2))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@acc_ca_mother", System.Data.OleDb.OleDbType.Integer, 7, "acc_ca_mother"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@acc_ca_idx", System.Data.OleDb.OleDbType.VarWChar, 70, "acc_ca_idx"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@acc_ca_active", System.Data.OleDb.OleDbType.Integer, 1, "acc_ca_active"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@acc_ca_entry_dt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "acc_ca_entry_dt"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@acc_ca_entry_by", System.Data.OleDb.OleDbType.Integer, 4, "acc_ca_entry_by"))

        dbCmdUpdate = New OleDb.OleDbCommand("ms_MstAcc_ca_Update", dbConn, dbTrans)
        dbCmdUpdate.CommandType = CommandType.StoredProcedure
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@acc_ca_id", System.Data.OleDb.OleDbType.Integer, 7, "acc_ca_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@acc_ca_name", System.Data.OleDb.OleDbType.VarWChar, 100, "acc_ca_name"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@acc_ca_shortname", System.Data.OleDb.OleDbType.VarWChar, 100, "acc_ca_shortname"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@acc_ca_type", System.Data.OleDb.OleDbType.Integer, 2, "acc_ca_type"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@acc_ca_mother", System.Data.OleDb.OleDbType.Integer, 7, "acc_ca_mother"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@acc_ca_idx", System.Data.OleDb.OleDbType.VarWChar, 70, "acc_ca_idx"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@acc_ca_active", System.Data.OleDb.OleDbType.Integer, 1, "acc_ca_active"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@acc_ca_entry_dt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "acc_ca_entry_dt"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@acc_ca_entry_by", System.Data.OleDb.OleDbType.Integer, 4, "acc_ca_entry_by"))

        dbDA = New OleDb.OleDbDataAdapter
        dbDA.UpdateCommand = dbCmdUpdate
        dbDA.InsertCommand = dbCmdInsert

        Try
            dbDA.Update(objTbl)
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Sub ChangeAcc_Type(ByVal acc_ca_id As String, ByVal dbConn As OleDb.OleDbConnection, ByVal dbTrans As OleDb.OleDbTransaction)
        Try
            Dim dbCmd As OleDb.OleDbCommand

            dbCmd = New OleDb.OleDbCommand("ms_MstAcc_changeType", dbConn, dbTrans)
            dbCmd.Parameters.Add("@acc_ca_id", Data.OleDb.OleDbType.VarChar)
            dbCmd.Parameters("@acc_ca_id").Value = acc_ca_id
            dbCmd.CommandType = CommandType.StoredProcedure

            Try
                dbCmd.ExecuteNonQuery()
            Catch ex As Exception
                Throw ex
            End Try
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
