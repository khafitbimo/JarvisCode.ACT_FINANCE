Public Class clsTrnBankTransfer
    Private DSN As String
    Private channel_id As String

    Sub New(ByVal DSN As String)
        Me.DSN = DSN
    End Sub

    Sub New(ByVal DSN As String, ByVal channel_id As String)
        Me.DSN = DSN
        Me.channel_id = channel_id
    End Sub

    Public Sub Retrieve(objTbl As DataTable, ByVal jurnal_id As String, ByVal Criteria As String)
        Dim dbConn As New OleDb.OleDbConnection(Me.DSN)
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter
        Dim cookie As Byte() = Nothing


        dbCmd = New OleDb.OleDbCommand("cp_TrnBanktransfer_Select", dbConn)
        dbCmd.Parameters.Add("@channel_id", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@channel_id").Value = channel_id
        dbCmd.Parameters.Add("@jurnal_id", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@jurnal_id").Value = jurnal_id
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@Criteria").Value = Criteria
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

    Public Sub Save(ByVal objTbl As DataTable, ByVal dbConn As OleDb.OleDbConnection, ByVal dbTrans As OleDb.OleDbTransaction)
        Dim dbCmdInsert As OleDb.OleDbCommand
        Dim dbCmdUpdate As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        dbCmdInsert = New OleDb.OleDbCommand("cp_TrnBanktransfer_Insert", dbConn, dbTrans)
        dbCmdInsert.CommandType = CommandType.StoredProcedure
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@banktransfer_id", System.Data.OleDb.OleDbType.VarWChar, 24, "banktransfer_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_id", System.Data.OleDb.OleDbType.VarWChar, 24, "jurnal_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnaldetil_line", System.Data.OleDb.OleDbType.Integer, 4, "jurnaldetil_line"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@banktransfer_dt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "banktransfer_dt"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@slipformat_id", System.Data.OleDb.OleDbType.VarWChar, 60, "slipformat_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@rekanan_id", System.Data.OleDb.OleDbType.VarWChar, 24, "rekanan_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@rekananbank_line", System.Data.OleDb.OleDbType.Integer, 4, "rekananbank_line"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@banktransfer_rekening", System.Data.OleDb.OleDbType.VarWChar, 100, "banktransfer_rekening"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@purposefund_id", System.Data.OleDb.OleDbType.Integer, 4, "purposefund_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@paymenttype_id", System.Data.OleDb.OleDbType.VarWChar, 6, "paymenttype_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@banktransfer_pembayaranrek", System.Data.OleDb.OleDbType.VarWChar, 100, "banktransfer_pembayaranrek"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@banktransfer_idr", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "banktransfer_idr", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@banktransfer_foreign", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "banktransfer_foreign", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@banktransfer_foreignrate", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "banktransfer_foreignrate", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@currency_id", System.Data.OleDb.OleDbType.VarWChar, 20, "currency_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@banktransfer_bi_idr", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "banktransfer_bi_idr", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@banktransfer_bi_foreign", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "banktransfer_bi_foreign", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@banktransfer_message", System.Data.OleDb.OleDbType.VarWChar, 510, "banktransfer_message"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20, "channel_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@banktransfer_isdisabled", System.Data.OleDb.OleDbType.Integer, 4, "banktransfer_isdisabled"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@banktransfer_invoice", System.Data.OleDb.OleDbType.VarWChar, 208, "banktransfer_invoice"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@banktransfer_episode1", System.Data.OleDb.OleDbType.Integer, 4, "banktransfer_episode1"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@banktransfer_episode2", System.Data.OleDb.OleDbType.Integer, 4, "banktransfer_episode2"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@project_id", System.Data.OleDb.OleDbType.VarWChar, 24, "project_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@rekananartis_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(7, Byte), CType(0, Byte), "rekananartis_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@banktransfer_episode", System.Data.OleDb.OleDbType.VarWChar, 50, "banktransfer_episode"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channelbank_line", System.Data.OleDb.OleDbType.Integer, 4, "channelbank_line"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@banktransfer_create_by", System.Data.OleDb.OleDbType.VarWChar, 100, "banktransfer_create_by"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@banktransfer_create_date", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "banktransfer_create_date"))

        dbCmdUpdate = New OleDb.OleDbCommand("cp_TrnBanktransfer_Update", dbConn, dbTrans)
        dbCmdUpdate.CommandType = CommandType.StoredProcedure
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@banktransfer_id", System.Data.OleDb.OleDbType.VarWChar, 24, "banktransfer_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_id", System.Data.OleDb.OleDbType.VarWChar, 24, "jurnal_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnaldetil_line", System.Data.OleDb.OleDbType.Integer, 4, "jurnaldetil_line"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@banktransfer_dt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "banktransfer_dt"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@slipformat_id", System.Data.OleDb.OleDbType.VarWChar, 60, "slipformat_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@rekanan_id", System.Data.OleDb.OleDbType.VarWChar, 24, "rekanan_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@rekananbank_line", System.Data.OleDb.OleDbType.Integer, 4, "rekananbank_line"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@banktransfer_rekening", System.Data.OleDb.OleDbType.VarWChar, 100, "banktransfer_rekening"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@purposefund_id", System.Data.OleDb.OleDbType.Integer, 4, "purposefund_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@paymenttype_id", System.Data.OleDb.OleDbType.VarWChar, 6, "paymenttype_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@banktransfer_pembayaranrek", System.Data.OleDb.OleDbType.VarWChar, 100, "banktransfer_pembayaranrek"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@banktransfer_idr", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "banktransfer_idr", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@banktransfer_foreign", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "banktransfer_foreign", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@banktransfer_foreignrate", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "banktransfer_foreignrate", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@currency_id", System.Data.OleDb.OleDbType.VarWChar, 20, "currency_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@banktransfer_bi_idr", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "banktransfer_bi_idr", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@banktransfer_bi_foreign", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "banktransfer_bi_foreign", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@banktransfer_message", System.Data.OleDb.OleDbType.VarWChar, 510, "banktransfer_message"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20, "channel_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@banktransfer_isdisabled", System.Data.OleDb.OleDbType.Integer, 4, "banktransfer_isdisabled"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@banktransfer_invoice", System.Data.OleDb.OleDbType.VarWChar, 208, "banktransfer_invoice"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@banktransfer_episode1", System.Data.OleDb.OleDbType.Integer, 4, "banktransfer_episode1"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@banktransfer_episode2", System.Data.OleDb.OleDbType.Integer, 4, "banktransfer_episode2"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@project_id", System.Data.OleDb.OleDbType.VarWChar, 24, "project_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@rekananartis_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(7, Byte), CType(0, Byte), "rekananartis_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@banktransfer_episode", System.Data.OleDb.OleDbType.VarWChar, 50, "banktransfer_episode"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channelbank_line", System.Data.OleDb.OleDbType.Integer, 4, "channelbank_line"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@banktransfer_create_by", System.Data.OleDb.OleDbType.VarWChar, 100, "banktransfer_create_by"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@banktransfer_create_date", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "banktransfer_create_date"))

        dbDA = New OleDb.OleDbDataAdapter
        dbDA.UpdateCommand = dbCmdUpdate
        dbDA.InsertCommand = dbCmdInsert

        Try
            dbDA.Update(objTbl)
        Catch ex As Exception
            Throw ex
        End Try

    End Sub
End Class
