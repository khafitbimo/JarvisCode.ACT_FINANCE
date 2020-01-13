Public Class clsSQLUDTableTypes
    Private mDSN As String

#Region " Constructor "
    Public Sub New(ByVal dsn As String)
        Me.mDSN = dsn
    End Sub
#End Region

    Public Function SaveDataRQ(ByVal dbConn As SqlClient.SqlConnection,
                               ByVal channel As String, _
                               ByVal jurnaltype_id As String, _
                               ByVal transaksi_request As DataTable,
                               ByVal transaksi_requestdetil As DataTable,
                               ByVal transaksi_requestdetiluse As DataTable,
                               ByVal transaksi_requestdetileps As DataTable,
                               ByVal transaksi_requestdetil_ref As DataTable,
                               ByVal user_strukturunit As Decimal) As String

        'Dim dbConn As New SqlClient.SqlConnection(Me.mDSN)
        Dim cmd As New SqlClient.SqlCommand("req_IUDRentalRequest", dbConn)
        Dim cReturn As String = String.Empty

        cmd.CommandType = CommandType.StoredProcedure

        Dim param1 As SqlClient.SqlParameter = cmd.Parameters.AddWithValue("@request_channelid", channel)
        Dim param2 As SqlClient.SqlParameter = cmd.Parameters.AddWithValue("@request_jurnaltypeid", jurnaltype_id)

        Dim param3 As SqlClient.SqlParameter = cmd.Parameters.AddWithValue("@transaksi_request", transaksi_request)
        param3.SqlDbType = SqlDbType.Structured
        Dim param4 As SqlClient.SqlParameter = cmd.Parameters.AddWithValue("@transaksi_requestdetil", transaksi_requestdetil)
        param4.SqlDbType = SqlDbType.Structured
        Dim param5 As SqlClient.SqlParameter = cmd.Parameters.AddWithValue("@transaksi_requestdetiluse", transaksi_requestdetiluse)
        param5.SqlDbType = SqlDbType.Structured
        Dim param6 As SqlClient.SqlParameter = cmd.Parameters.AddWithValue("@transaksi_requestdetileps", transaksi_requestdetileps)
        param6.SqlDbType = SqlDbType.Structured
        Dim param7 As SqlClient.SqlParameter = cmd.Parameters.AddWithValue("@transaksi_requestdetil_ref", transaksi_requestdetil_ref)
        param7.SqlDbType = SqlDbType.Structured
        Dim param8 As SqlClient.SqlParameter = cmd.Parameters.AddWithValue("@user_strukturunit", user_strukturunit)
        Dim param9 As SqlClient.SqlParameter = cmd.Parameters.Add("@request_id", SqlDbType.NVarChar, 21)
        param9.Direction = ParameterDirection.Output

        Try
            cReturn = CType(cmd.ExecuteScalar(), String)

            Return cReturn
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function SaveDataPQ(ByVal dbConn As SqlClient.SqlConnection,
                               ByVal channel As String, _
                               ByVal jurnaltype_id As String, _
                               ByVal transaksi_request As DataTable,
                               ByVal transaksi_requestdetil As DataTable,
                               ByVal transaksi_requestdetileps As DataTable,
                               ByVal transaksi_requestdetil_ref As DataTable,
                               ByVal user_strukturunit As Decimal) As String

        Dim cmd As New SqlClient.SqlCommand("req_IUDPurchaseRequest", dbConn)
        Dim cReturn As String = String.Empty

        cmd.CommandType = CommandType.StoredProcedure

        Dim param1 As SqlClient.SqlParameter = cmd.Parameters.AddWithValue("@request_channelid", channel)
        Dim param2 As SqlClient.SqlParameter = cmd.Parameters.AddWithValue("@request_jurnaltypeid", jurnaltype_id)

        Dim param3 As SqlClient.SqlParameter = cmd.Parameters.AddWithValue("@transaksi_request", transaksi_request)
        param3.SqlDbType = SqlDbType.Structured

        Dim param4 As SqlClient.SqlParameter = cmd.Parameters.AddWithValue("@transaksi_requestdetil", transaksi_requestdetil)
        param4.SqlDbType = SqlDbType.Structured

        Dim param5 As SqlClient.SqlParameter = cmd.Parameters.AddWithValue("@transaksi_requestdetileps", transaksi_requestdetileps)
        param5.SqlDbType = SqlDbType.Structured

        Dim param6 As SqlClient.SqlParameter = cmd.Parameters.AddWithValue("@transaksi_requestdetil_ref", transaksi_requestdetil_ref)
        param6.SqlDbType = SqlDbType.Structured

        Dim param7 As SqlClient.SqlParameter = cmd.Parameters.AddWithValue("@user_strukturunit", user_strukturunit)

        Dim param8 As SqlClient.SqlParameter = cmd.Parameters.Add("@request_id", SqlDbType.NVarChar, 21)
        param8.Direction = ParameterDirection.Output

        Try
            cReturn = CType(cmd.ExecuteScalar(), String)

            Return cReturn
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function SaveDataNQ(ByVal dbConn As SqlClient.SqlConnection,
                               ByVal channel As String, _
                               ByVal jurnaltype_id As String, _
                               ByVal transaksi_request As DataTable,
                               ByVal transaksi_requestdetil As DataTable,
                               ByVal transaksi_requestdetiluse As DataTable,
                               ByVal transaksi_requestdetileps As DataTable,
                               ByVal transaksi_requestdetil_ref As DataTable,
                               ByVal user_strukturunit As Decimal) As String

        Dim cmd As New SqlClient.SqlCommand("req_IUDGeneralRequest", dbConn)
        Dim cReturn As String = String.Empty

        cmd.CommandType = CommandType.StoredProcedure

        Dim param1 As SqlClient.SqlParameter = cmd.Parameters.AddWithValue("@request_channelid", channel)
        Dim param2 As SqlClient.SqlParameter = cmd.Parameters.AddWithValue("@request_jurnaltypeid", jurnaltype_id)

        Dim param3 As SqlClient.SqlParameter = cmd.Parameters.AddWithValue("@transaksi_request", transaksi_request)
        param3.SqlDbType = SqlDbType.Structured

        Dim param4 As SqlClient.SqlParameter = cmd.Parameters.AddWithValue("@transaksi_requestdetil", transaksi_requestdetil)
        param4.SqlDbType = SqlDbType.Structured

        Dim param5 As SqlClient.SqlParameter = cmd.Parameters.AddWithValue("@transaksi_requestdetiluse", transaksi_requestdetiluse)
        param5.SqlDbType = SqlDbType.Structured

        Dim param6 As SqlClient.SqlParameter = cmd.Parameters.AddWithValue("@transaksi_requestdetileps", transaksi_requestdetileps)
        param6.SqlDbType = SqlDbType.Structured

        Dim param7 As SqlClient.SqlParameter = cmd.Parameters.AddWithValue("@transaksi_requestdetil_ref", transaksi_requestdetil_ref)
        param7.SqlDbType = SqlDbType.Structured

        Dim param8 As SqlClient.SqlParameter = cmd.Parameters.AddWithValue("@user_strukturunit", user_strukturunit)

        Dim param9 As SqlClient.SqlParameter = cmd.Parameters.Add("@request_id", SqlDbType.NVarChar, 21)
        param9.Direction = ParameterDirection.Output

        Try
            cReturn = CType(cmd.ExecuteScalar(), String)

            Return cReturn
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function SaveAttachment(ByVal dbConn As SqlClient.SqlConnection, ByRef request_id As Object, ByVal transaksi_attachment As DataTable) As Boolean
        Dim cmd As New SqlClient.SqlCommand("req_IUDAttachment", dbConn)
        Dim cReturn As String = String.Empty

        cmd.CommandType = CommandType.StoredProcedure

        Dim param1 As SqlClient.SqlParameter = cmd.Parameters.AddWithValue("@request_id", request_id)
        Dim param2 As SqlClient.SqlParameter = cmd.Parameters.AddWithValue("@transaksi_attachment", transaksi_attachment)
        param2.SqlDbType = SqlDbType.Structured

        Try
            cmd.ExecuteNonQuery()

            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function CopyToDatatable(ByVal objTblSource As DataTable, ByVal colNameFlag As String, ByVal objTblDestination As DataTable) As DataTable
        Try
            If objTblSource.Rows.Count > 0 Then
                For q As Integer = 0 To objTblSource.Rows.Count - 1
                    Dim datarows As DataRow = objTblDestination.NewRow
                    If objTblSource.Rows(q).RowState = DataRowState.Added Or objTblSource.Rows(q).RowState = DataRowState.Modified Then
                        For idx As Integer = objTblSource.Columns.Count - 1 To 0 Step -1
                            Dim columnName1 = objTblSource.Columns(idx).ColumnName
                            For idx2 As Integer = objTblDestination.Columns.Count - 1 To 0 Step -1
                                Dim columnName2 As String = objTblDestination.Columns(idx2).ColumnName
                                If columnName2 = columnName1 Then
                                    datarows(columnName2) = objTblSource.Rows(q).Item(columnName1)
                                End If
                            Next
                        Next

                        If objTblSource.Rows(q).RowState = DataRowState.Added Then
                            datarows(colNameFlag) = 1
                        ElseIf objTblSource.Rows(q).RowState = DataRowState.Modified Then
                            datarows(colNameFlag) = 2
                        ElseIf objTblSource.Rows(q).RowState = DataRowState.Deleted Then
                            datarows(colNameFlag) = 3
                        End If

                        objTblDestination.Rows.Add(datarows)
                    ElseIf objTblSource.Rows(q).RowState = DataRowState.Deleted Then
                        For idx As Integer = objTblSource.Columns.Count - 1 To 0 Step -1
                            Dim columnName1 = objTblSource.Columns(idx).ColumnName
                            For idx2 As Integer = objTblDestination.Columns.Count - 1 To 0 Step -1
                                Dim columnName2 As String = objTblDestination.Columns(idx2).ColumnName
                                If columnName2 = columnName1 Then
                                    datarows(columnName2) = objTblSource.Rows(q)(columnName1, DataRowVersion.Original)
                                End If
                            Next
                        Next

                        If objTblSource.Rows(q).RowState = DataRowState.Added Then
                            datarows(colNameFlag) = 1
                        ElseIf objTblSource.Rows(q).RowState = DataRowState.Modified Then
                            datarows(colNameFlag) = 2
                        ElseIf objTblSource.Rows(q).RowState = DataRowState.Deleted Then
                            datarows(colNameFlag) = 3
                        End If

                        objTblDestination.Rows.Add(datarows)
                    End If

                Next
                'Else
                '    Throw New Exception("Datatable source empty !")
            End If

            Return objTblDestination
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function SaveDataEQ(ByVal dbConn As SqlClient.SqlConnection,
                           ByVal channel As String, _
                           ByVal jurnaltype_id As String, _
                           ByVal transaksi_request As DataTable,
                           ByVal transaksi_requestdetil As DataTable,
                           ByVal transaksi_requestdetiluse As DataTable,
                           ByVal transaksi_requestdetileps As DataTable,
                           ByVal transaksi_requestdetil_ref As DataTable,
                           ByVal user_strukturunit As Decimal) As String

        Dim cmd As New SqlClient.SqlCommand("req_IUDEditingRequest", dbConn)
        Dim cReturn As String = String.Empty

        cmd.CommandType = CommandType.StoredProcedure

        Dim param1 As SqlClient.SqlParameter = cmd.Parameters.AddWithValue("@request_channelid", channel)
        Dim param2 As SqlClient.SqlParameter = cmd.Parameters.AddWithValue("@request_jurnaltypeid", jurnaltype_id)

        Dim param3 As SqlClient.SqlParameter = cmd.Parameters.AddWithValue("@transaksi_request", transaksi_request)
        param3.SqlDbType = SqlDbType.Structured

        Dim param4 As SqlClient.SqlParameter = cmd.Parameters.AddWithValue("@transaksi_requestdetil", transaksi_requestdetil)
        param4.SqlDbType = SqlDbType.Structured

        Dim param5 As SqlClient.SqlParameter = cmd.Parameters.AddWithValue("@transaksi_requestdetiluse", transaksi_requestdetiluse)
        param5.SqlDbType = SqlDbType.Structured

        Dim param6 As SqlClient.SqlParameter = cmd.Parameters.AddWithValue("@transaksi_requestdetileps", transaksi_requestdetileps)
        param6.SqlDbType = SqlDbType.Structured

        Dim param7 As SqlClient.SqlParameter = cmd.Parameters.AddWithValue("@transaksi_requestdetil_ref", transaksi_requestdetil_ref)
        param7.SqlDbType = SqlDbType.Structured

        Dim param8 As SqlClient.SqlParameter = cmd.Parameters.AddWithValue("@user_strukturunit", user_strukturunit)

        Dim param9 As SqlClient.SqlParameter = cmd.Parameters.Add("@request_id", SqlDbType.NVarChar, 21)
        param9.Direction = ParameterDirection.Output

        Try
            cReturn = CType(cmd.ExecuteScalar(), String)

            Return cReturn
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function SaveDataPaymentVoucher(ByVal dbConn As SqlClient.SqlConnection,
                           ByVal channel_id As String, _
                           ByVal jurnaltype_id As String, _
                           ByVal jurnal_source As String, _
                           ByVal transaksi_jurnal As DataTable,
                           ByVal transaksi_jurnaldetil_debit As DataTable,
                           ByVal transaksi_jurnaldetilandbilyet_credit As DataTable,
                           ByVal transaksi_jurnalreference As DataTable,
                           ByVal user_strukturunit As Decimal) As String

        Dim cmd As New SqlClient.SqlCommand("fin_IUDPaymentVoucher", dbConn)
        Dim cReturn As String = String.Empty

        cmd.CommandType = CommandType.StoredProcedure

        Dim param1 As SqlClient.SqlParameter = cmd.Parameters.AddWithValue("@channel_id", channel_id)

        Dim param2 As SqlClient.SqlParameter = cmd.Parameters.AddWithValue("@jurnaltype_id", jurnaltype_id)

        Dim param3 As SqlClient.SqlParameter = cmd.Parameters.AddWithValue("@jurnal_source", jurnal_source)

        Dim param4 As SqlClient.SqlParameter = cmd.Parameters.AddWithValue("@transaksi_jurnal", transaksi_jurnal)
        param4.SqlDbType = SqlDbType.Structured

        Dim param5 As SqlClient.SqlParameter = cmd.Parameters.AddWithValue("@transaksi_jurnaldetil_debit", transaksi_jurnaldetil_debit)
        param5.SqlDbType = SqlDbType.Structured

        Dim param6 As SqlClient.SqlParameter = cmd.Parameters.AddWithValue("@transaksi_jurnaldetilandbilyet_credit", transaksi_jurnaldetilandbilyet_credit)
        param6.SqlDbType = SqlDbType.Structured

        Dim param7 As SqlClient.SqlParameter = cmd.Parameters.AddWithValue("@transaksi_jurnalreference", transaksi_jurnalreference)
        param7.SqlDbType = SqlDbType.Structured

        Dim param8 As SqlClient.SqlParameter = cmd.Parameters.AddWithValue("@user_strukturunit", user_strukturunit)

        Dim param9 As SqlClient.SqlParameter = cmd.Parameters.Add("@jurnal_id", SqlDbType.NVarChar, 21)
        param9.Direction = ParameterDirection.Output

        Try
            cReturn = CType(cmd.ExecuteScalar(), String)

            Return cReturn
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
