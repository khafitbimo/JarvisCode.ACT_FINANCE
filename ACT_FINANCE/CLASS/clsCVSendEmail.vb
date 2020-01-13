Public Class clsCVSendEmail

    Private DSN As String

#Region " Constructor "
    Sub New(ByVal DSN As String)
        Me.DSN = DSN
    End Sub
#End Region

    Public Function GetDataEmail(ByRef datatable As DataTable, ByVal jurnal_id As String) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        dbCmd = New OleDb.OleDbCommand("ms_CirculationVoucherContactEmail_Select", dbConn)
        dbCmd.Parameters.Add("@criteria", Data.OleDb.OleDbType.VarChar).Value = String.Format(" A.jurnal_id = '{0}'", jurnal_id)
        'dbCmd.Parameters.Add("@criteria", Data.OleDb.OleDbType.VarChar).Value = String.Format(" LEFT(A.jurnal_id,2) = 'PV' AND A.jurnaldetil_dk = 'D'" + _
        '                                    " AND B.rekanantype_id = 7 AND A.acc_id in (SELECT acc_id FROM master_accrefdetil WHERE accref_id = 9015) AND " + _
        '                                    " A.jurnal_id = '{0}'", jurnal_id)

        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)

        Dim cookie As Byte() = Nothing

        Try
            dbConn.Open()
            clsApplicationRole.SetAppRole(dbConn, cookie)
            dbDA.Fill(datatable)
            Return True
        Catch ex As Exception
            Throw ex
            Return False
        Finally
            clsApplicationRole.UnsetAppRole(dbConn, cookie)
            dbConn.Close()
        End Try
    End Function
End Class
