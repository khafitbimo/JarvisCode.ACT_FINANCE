Public Class clsDataFiller

    Private mDSN As String

#Region " Constructor "
    Public Sub New(ByVal dsn As String)
        Me.mDSN = dsn
    End Sub
#End Region

    Public Function DataFill(ByRef datatable As DataTable, ByVal procedure As String, ByVal criteria As String, Optional ByVal channel_id As String = "") As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.mDSN)
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        dbCmd = New OleDb.OleDbCommand(procedure, dbConn)
        If channel_id <> "" Then
            dbCmd.Parameters.Add("@channel_id", Data.OleDb.OleDbType.VarChar)
            dbCmd.Parameters("@channel_id").Value = channel_id
        End If
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@Criteria").Value = criteria

        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)

        Try
            dbConn.Open()
            dbDA.Fill(datatable)
        Catch ex As Exception
            Throw ex
        Finally
            dbConn.Close()
        End Try

        Return True

    End Function

    Public Function DataFill(ByRef dbConn As OleDb.OleDbConnection, ByRef datatable As DataTable, ByVal procedure As String, ByVal criteria As String, Optional ByVal channel_id As String = "") As Boolean
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        dbCmd = New OleDb.OleDbCommand(procedure, dbConn)
        If channel_id <> "" Then
            dbCmd.Parameters.Add("@channel_id", Data.OleDb.OleDbType.VarChar)
            dbCmd.Parameters("@channel_id").Value = channel_id
        End If
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@Criteria").Value = criteria

        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)

        Try
            dbDA.Fill(datatable)
        Catch ex As Exception
            Throw ex
        End Try

        Return True

    End Function

    Public Function DataFillParam(ByRef datatable As DataTable, ByVal procedure As String, ByVal parameter1 As String, ByVal parameter2 As String, ByVal criteria As String, Optional ByVal channel_id As String = "") As Boolean
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.mDSN)

        dbCmd = New OleDb.OleDbCommand(procedure, dbConn)
        If channel_id <> "" Then
            dbCmd.Parameters.Add("@channel_id", Data.OleDb.OleDbType.VarChar)
            dbCmd.Parameters("@channel_id").Value = channel_id
        End If
        dbCmd.Parameters.Add("@channel_id", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@channel_id").Value = parameter1
        dbCmd.Parameters.Add("@jurnal_id", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@jurnal_id").Value = parameter2
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@Criteria").Value = criteria

        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)

        Try
            dbDA.Fill(datatable)
        Catch ex As Exception
            Throw ex
        End Try

        Return True

    End Function

    Public Function DataFill(ByRef dbconn As OleDb.OleDbConnection, ByRef dbtrans As OleDb.OleDbTransaction, ByRef datatable As DataTable, ByVal procedure As String, ByVal criteria As String, Optional ByVal channel_id As String = "") As Boolean
        ''''Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.mDSN)
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        dbCmd = New OleDb.OleDbCommand(procedure, dbconn, dbtrans)
        If channel_id <> "" Then
            dbCmd.Parameters.Add("@channel_id", Data.OleDb.OleDbType.VarChar)
            dbCmd.Parameters("@channel_id").Value = channel_id
        End If
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@Criteria").Value = criteria

        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)

        Try
            ''''dbConn.Open()
            dbDA.Fill(datatable)
        Catch ex As Exception
            Throw ex
        Finally
            ''''dbConn.Close()
        End Try

        Return True

    End Function

    Public Function DataFillLimit(ByRef datatable As DataTable, ByVal procedure As String, ByVal criteria As String, ByVal limit As Integer, Optional ByVal channel_id As String = "") As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.mDSN)
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        dbCmd = New OleDb.OleDbCommand(procedure, dbConn)
        If channel_id <> "" Then
            dbCmd.Parameters.Add("@channel_id", Data.OleDb.OleDbType.VarChar)
            dbCmd.Parameters("@channel_id").Value = channel_id
        End If
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@Criteria").Value = criteria

        dbCmd.Parameters.Add("@Limit", Data.OleDb.OleDbType.Integer)
        dbCmd.Parameters("@Limit").Value = limit

        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)

        Try
            dbConn.Open()
            dbDA.Fill(datatable)
        Catch ex As Exception
            Throw ex
        Finally
            dbConn.Dispose()
            dbConn.Close()
        End Try

        Return True

    End Function
    Public Function DataFillForCombo(ByVal valuemember As String, ByVal displaymember As String, ByRef datatable As DataTable, ByVal procedure As String, ByVal criteria As String, Optional ByVal channel_id As String = "") As Boolean
        Dim row As System.Data.DataRow

        datatable.Clear()
        row = datatable.NewRow
        row.Item(valuemember) = "0"
        row.Item(displaymember) = " -- PILIH -- "
        datatable.Rows.InsertAt(row, 0)

        If procedure <> "" Then
            Me.DataFill(datatable, procedure, criteria, channel_id)
        End If

        Return True
    End Function
    Public Function DataFillForComboAngka(ByVal valuemember As String, ByVal displaymember As String, ByRef datatable As DataTable, ByVal procedure As String, ByVal criteria As String, Optional ByVal channel_id As String = "") As Boolean
        Dim row As System.Data.DataRow

        datatable.Clear()
        row = datatable.NewRow
        row.Item(valuemember) = 0
        row.Item(displaymember) = " -- PILIH -- "
        datatable.Rows.InsertAt(row, 0)

        If procedure <> "" Then
            Me.DataFill(datatable, procedure, criteria, channel_id)
        End If

        Return True
    End Function

    Public Function ComboFill(ByRef combobox As ComboBox, ByVal valuemember As String, ByVal displaymember As String, ByRef datatable As DataTable, ByVal procedure As String, ByVal criteria As String, Optional ByVal channel_id As String = "") As Boolean
        Dim row As System.Data.DataRow

        datatable.Clear()
        row = datatable.NewRow
        row.Item(valuemember) = "0"
        row.Item(displaymember) = " -- PILIH -- "
        datatable.Rows.InsertAt(row, 0)

        If procedure <> "" Then
            Me.DataFill(datatable, procedure, criteria, channel_id)
        End If

        combobox.DataSource = datatable
        combobox.ValueMember = valuemember
        combobox.DisplayMember = displaymember

        Return True
    End Function
    Public Function ComboFillDec(ByRef combobox As ComboBox, ByVal valuemember As String, ByVal displaymember As String, ByRef datatable As DataTable, ByVal procedure As String, ByVal criteria As String, Optional ByVal channel_id As String = "") As Boolean
        Dim row As System.Data.DataRow

        datatable.Clear()
        row = datatable.NewRow
        row.Item(valuemember) = 0
        row.Item(displaymember) = " -- PILIH -- "
        datatable.Rows.InsertAt(row, 0)

        If procedure <> "" Then
            Me.DataFill(datatable, procedure, criteria, channel_id)
        End If

        combobox.DataSource = datatable
        combobox.ValueMember = valuemember
        combobox.DisplayMember = displaymember

        Return True
    End Function
    Public Function ComboLink(ByRef combobox As ComboBox, ByVal valuemember As String, ByVal displaymember As String, ByRef datatable As DataTable, ByVal withOption As Boolean) As Boolean
        Dim row As System.Data.DataRow

        If withOption Then
            row = datatable.NewRow
            row.Item(valuemember) = "0"
            row.Item(displaymember) = " -- PILIH -- "
            datatable.Rows.InsertAt(row, 0)
        End If

        combobox.DataSource = datatable
        combobox.ValueMember = valuemember
        combobox.DisplayMember = displaymember

        Return True
    End Function

    Public Function ComboFillNoSP(ByRef combobox As ComboBox, ByVal valuemember As String, ByVal displaymember As String, ByRef datatable As DataTable) As Boolean
        Dim row As System.Data.DataRow

        If datatable.Rows(0).Item(displaymember) <> "-- PILIH --" Then
            row = datatable.NewRow
            row.Item(valuemember) = "0"
            row.Item(displaymember) = "-- PILIH --"
            datatable.Rows.InsertAt(row, 0)
        End If
        combobox.DataSource = datatable
        combobox.ValueMember = valuemember
        combobox.DisplayMember = displaymember

        Return True
    End Function

    Public Overloads Function DataFillAmountAdvance(ByRef dbconn As OleDb.OleDbConnection, ByRef dbtrans As OleDb.OleDbTransaction, ByRef datatable As DataTable, ByVal procedure As String, ByVal budget_id As Decimal, ByVal budgetdetil_id As Decimal) As Boolean
        ''''Dim dbConn As New OleDb.OleDbConnection(Me.mDSN)
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        dbCmd = New OleDb.OleDbCommand(procedure, dbconn, dbtrans)
        dbCmd.Parameters.Add("@budget_id", Data.OleDb.OleDbType.Decimal)
        dbCmd.Parameters("@budget_id").Value = budget_id
        dbCmd.Parameters.Add("@budgetdetil_id", Data.OleDb.OleDbType.Decimal)
        dbCmd.Parameters("@budgetdetil_id").Value = budgetdetil_id

        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)

        Try
            '''' dbConn.Open()

            dbDA.Fill(datatable)
        Catch ex As Exception
            Throw ex
        Finally
            ''''dbConn.Close()
        End Try

        Return True
    End Function

    Public Overloads Function DataFillAmountAdvance(ByRef datatable As DataTable, ByVal procedure As String, ByVal budget_id As Decimal, ByVal budgetdetil_id As Decimal) As Boolean
        Dim dbConn As New OleDb.OleDbConnection(Me.mDSN)
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        dbCmd = New OleDb.OleDbCommand(procedure, dbConn)
        dbCmd.Parameters.Add("@budget_id", Data.OleDb.OleDbType.Decimal)
        dbCmd.Parameters("@budget_id").Value = budget_id
        dbCmd.Parameters.Add("@budgetdetil_id", Data.OleDb.OleDbType.Decimal)
        dbCmd.Parameters("@budgetdetil_id").Value = budgetdetil_id

        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)

        Try
            dbConn.Open()

            dbDA.Fill(datatable)
        Catch ex As Exception
            Throw ex
        Finally
            dbConn.Close()
        End Try

        Return True
    End Function
End Class
