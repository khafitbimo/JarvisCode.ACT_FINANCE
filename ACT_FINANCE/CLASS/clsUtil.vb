Imports Microsoft.Win32
Imports System.Data.OleDb
Imports System.Globalization
Imports System.Threading
Imports System.Linq.Expressions
Imports System.Data.Linq.Mapping
Imports System.Data.Linq

Public Class clsUtil

    Public Shared Function SetLocalization() As Boolean
        Dim myCI As New System.Globalization.CultureInfo("en-GB", False)
        Dim myCIclone As System.Globalization.CultureInfo = CType(myCI.Clone(), System.Globalization.CultureInfo)
        myCIclone.DateTimeFormat.AMDesignator = "a.m."
        myCIclone.DateTimeFormat.DateSeparator = "/"
        myCIclone.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy"
        myCIclone.NumberFormat.CurrencySymbol = "$"
        myCIclone.NumberFormat.NumberDecimalDigits = 4
        System.Threading.Thread.CurrentThread.CurrentCulture = myCIclone
    End Function

    Public Shared Function IsDbNull(ByVal value As Object, ByVal value_if_null As Object) As Object
        If value IsNot Nothing Then
            If value Is DBNull.Value Then
                Return value_if_null
            Else
                Return value
            End If
        Else
            Return value_if_null
        End If
    End Function

    Public Shared Function Terbilang(ByVal x As Double) As String
        Dim xstr, major, minor, negatifsign As String
        Dim axstr(2) As String
        Dim t As String

        If x = 0 Then
            Return "nol"
        End If

        negatifsign = ""

        If x < 0 Then
            x = -1 * x
            negatifsign = "Negatif "
        Else
            negatifsign = ""
        End If

        x = Math.Round(x, 2)
        xstr = CType(x, String)
        axstr = xstr.Split(".")
        major = axstr(0)

        If axstr.Length > 1 Then
            minor = axstr(1)
            t = negatifsign & " " & Num2Word(CType(major, Long)) & " koma " & Num2Word(CType(minor, Long))
        Else
            t = negatifsign & " " & Num2Word(CType(major, Long))
        End If

        Return t

    End Function

    Public Shared Function Num2Word(ByVal x As Long) As String
        Dim bilangan As String() = {"", "Satu", "Dua", "Tiga", "Empat", "Lima", "Enam", "Tujuh", "Delapan", "Sembilan", "Sepuluh", "Sebelas"}
        Dim temp As String = ""

        If x < 12 Then
            temp = " " + bilangan(x)
        ElseIf x < 20 Then
            temp = Num2Word(x - 10).ToString + " Belas"
        ElseIf x < 100 Then
            temp = Num2Word(Math.Floor(x / 10)) + " Puluh" + Num2Word(x Mod 10)
        ElseIf x < 200 Then
            temp = " Seratus" + Num2Word(x - 100)
        ElseIf x < 1000 Then
            temp = Num2Word(Math.Floor(x / 100)) + " Ratus" + Num2Word(x Mod 100)
        ElseIf x < 2000 Then
            temp = " Seribu" + Num2Word(x - 1000)
        ElseIf x < 1000000 Then
            temp = Num2Word(Math.Floor(x / 1000)) + " Ribu" + Num2Word(x Mod 1000)
        ElseIf x < 1000000000 Then
            temp = Num2Word(Math.Floor(x / 1000000)) + " Juta" + Num2Word(x Mod 1000000)
        ElseIf x < 1000000000000 Then
            temp = Num2Word(Math.Floor(x / 1000000000)) + " Milyar" + Num2Word(x Mod 1000000000)
        End If

        Return temp

    End Function

    Public Shared Function RefParser(ByVal txtField As String, ByVal txtSearchRef As TextBox) As String
        Dim i, j As Integer
        Dim txtTempLineSearchText As String
        Dim txtTempSearchText As String
        Dim txtSearchCriteria As String = ""
        Dim arrSearchText() As String
        Dim txtSQLSearch As String = ""

        For i = 0 To txtSearchRef.Lines.Length - 1
            txtTempLineSearchText = txtSearchRef.Lines(i)
            arrSearchText = Nothing
            arrSearchText = txtTempLineSearchText.Split(";")
            For j = 0 To arrSearchText.Length - 1
                txtTempSearchText = Trim(arrSearchText(j))
                If txtTempSearchText <> "" Then
                    txtSearchCriteria = txtTempSearchText & ";" & txtSearchCriteria
                End If
            Next
        Next

        arrSearchText = Nothing
        arrSearchText = txtSearchCriteria.Split(";")

        For i = 0 To arrSearchText.Length - 1
            If i > 0 Then
                If arrSearchText(i) <> "" Then
                    txtSearchCriteria = txtSearchCriteria & " OR " & txtField & " = '" & arrSearchText(i) & "' "
                End If
            Else
                txtSearchCriteria = txtField & " = '" & arrSearchText(0) & "' "
            End If
        Next


        Return txtSearchCriteria

    End Function

    Public Shared Function GetDataFromDatatable(ByRef dt As DataTable, ByVal colid As String, ByVal colname As String, ByVal id As String) As String
        Dim dr() As DataRow
        dr = dt.Select(String.Format("{0}='{1}'", colid, id))

        If dr.Length > 0 Then
            Return dr(0).Item(colname).ToString
        Else
            Return ""
        End If
    End Function

    Public Shared Function GetDataTable(ByVal _sStoredProcedureName As String, ByVal _sConn As String, ByVal ParamArray _Params() As System.Data.OleDb.OleDbParameter) As DataTable
        GetDataTable = New DataTable

        Dim oConn As System.Data.OleDb.OleDbConnection
        Dim oCmd As System.Data.OleDb.OleDbCommand
        Dim oDA As System.Data.OleDb.OleDbDataAdapter
        Dim cookie As Byte() = Nothing

        oConn = New System.Data.OleDb.OleDbConnection(_sConn)
        oCmd = New System.Data.OleDb.OleDbCommand(_sStoredProcedureName, oConn)
        oCmd.CommandType = CommandType.StoredProcedure
        oCmd.Parameters.AddRange(_Params)

        oDA = New System.Data.OleDb.OleDbDataAdapter(oCmd)

        Try

            oConn.Open()
            clsApplicationRole.SetAppRole(oConn, cookie)
            oDA.Fill(GetDataTable)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

            clsApplicationRole.UnsetAppRole(oConn, cookie)
            oConn.Close()
            oConn = Nothing
            oCmd = Nothing
            oDA = Nothing
        End Try

        Return GetDataTable
    End Function

    Public Shared Function ExecuteCommand(ByVal _sCommand As String, ByVal _sConn As String, ByVal _cmdType As System.Data.CommandType) As Boolean
        Dim oConn As System.Data.OleDb.OleDbConnection
        Dim oCmd As System.Data.OleDb.OleDbCommand
        Dim cookie As Byte() = Nothing

        oConn = New System.Data.OleDb.OleDbConnection(_sConn)
        oCmd = New System.Data.OleDb.OleDbCommand(_sCommand, oConn)
        oCmd.CommandType = _cmdType

        Try
            oConn.Open()
            clsApplicationRole.SetAppRole(oConn, cookie)
            oCmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            clsApplicationRole.UnsetAppRole(oConn, cookie)
            oConn.Close()
            oConn = Nothing
            oCmd = Nothing
        End Try
        Return True
    End Function

    'End Function
    Public Shared Function GetRegistryValue(ByVal RootRegnya As String, ByVal NamaValuenya As String) As String
        Dim reg As RegistryKey
        Dim strTemp As String = ""
        Const m_Subkey As String = "Software\SlipBank"

        reg = Registry.CurrentUser.OpenSubKey(RootRegnya)
        If reg IsNot Nothing Then
            reg.OpenSubKey(m_Subkey)
            'reg.Name
            If Not (reg Is Nothing) Then
                strTemp = reg.GetValue(NamaValuenya)
                reg.Close()
            End If
        Else
            strTemp = "[ Setting Slip Belum Ada ]"
        End If
        Return strTemp
    End Function

    Public Shared Function DataFill(ByVal _sConn As String, ByRef datatable As DataTable, ByVal procedure As String, ByVal criteria As String, Optional ByVal channel_id As String = "") As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(_sConn)
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

        Dim cookie As Byte() = Nothing

        Try
            dbConn.Open()
            clsApplicationRole.SetAppRole(dbConn, cookie)
            dbDA.Fill(datatable)
        Catch ex As Exception
            Throw ex
        Finally
            clsApplicationRole.UnsetAppRole(dbConn, cookie)
            dbConn.Close()
            dbConn.Dispose()
        End Try
        Return True
    End Function

    Public Shared Function RefParser_ari(ByVal txtSearchRef As TextBox) As String
        Dim i, j As Integer
        Dim txtTempLineSearchText As String
        Dim txtTempSearchText As String
        Dim txtSearchCriteria As String = ""
        Dim arrSearchText() As String
        Dim txtSQLSearch As String = ""

        For i = 0 To txtSearchRef.Lines.Length - 1
            txtTempLineSearchText = txtSearchRef.Lines(i)
            arrSearchText = Nothing
            arrSearchText = txtTempLineSearchText.Split(";")
            For j = 0 To arrSearchText.Length - 1
                txtTempSearchText = Trim(arrSearchText(j))
                If txtTempSearchText <> "" Then
                    txtSearchCriteria = txtTempSearchText & ";" & txtSearchCriteria
                End If
            Next
        Next

        arrSearchText = Nothing
        arrSearchText = txtSearchCriteria.Split(";")

        If arrSearchText.Length > 2 Then
            For i = 0 To arrSearchText.Length - 1
                If i > 0 Then
                    If arrSearchText(i) <> "" Then
                        txtSearchCriteria = txtSearchCriteria & ",'" & arrSearchText(i) & "'"
                    End If

                Else
                    txtSearchCriteria = "'" & arrSearchText(0) & "'"
                End If
            Next
        Else
            txtSearchCriteria = "'" & arrSearchText(0) & "'"
        End If

        Return txtSearchCriteria
    End Function

    Public Shared Function ServerDate(ByVal db As DataClassesFrmDataContext) As Date
        Dim result As IEnumerable(Of Date) = db.ExecuteQuery(Of Date)("SELECT GetDate()")

        Try
            Return result(0)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#Region " LinqToSQL"
    Private Shared Function GetMemberInfo(method As Expression) As MemberExpression
        Dim lambda As LambdaExpression = TryCast(method, LambdaExpression)
        If lambda Is Nothing Then
            Throw New ArgumentNullException("method")
        End If

        Dim memberExpr As MemberExpression = Nothing

        If lambda.Body.NodeType = ExpressionType.Convert Then
            memberExpr = TryCast(DirectCast(lambda.Body, UnaryExpression).Operand, MemberExpression)
        ElseIf lambda.Body.NodeType = ExpressionType.MemberAccess Then
            memberExpr = TryCast(lambda.Body, MemberExpression)
        End If

        If memberExpr Is Nothing Then
            Throw New ArgumentException("method")
        End If

        Return memberExpr
    End Function

    Public Shared Function NameOf(Of T)(prop As Expression(Of Func(Of T))) As String
        Dim expression = GetMemberInfo(prop)
        Return expression.Member.Name
    End Function

    Public Shared Sub DataRowToEntity(ByVal Entity As Object, ByVal dataRow As DataRow, Optional ByVal version As DataRowVersion = DataRowVersion.Default)
        Dim value As Object

        For Each i As Reflection.PropertyInfo In Entity.GetType().GetProperties()
            value = dataRow.Item(i.Name, version)

            If value Is DBNull.Value Then
                value = Nothing
            End If

            i.SetValue(Entity, value, Nothing)
        Next
    End Sub

    Public Shared Sub EntityToDataRow(ByVal Entity As Object, ByVal dataRow As DataRow)
        Dim value As Object

        For Each i As System.Reflection.PropertyInfo In Entity.GetType().GetProperties()
            value = i.GetValue(Entity, Nothing)

            If value Is Nothing Then
                value = DBNull.Value
            End If

            dataRow.Item(i.Name) = value
        Next
    End Sub

    Public Shared Function GetPathOfFolderExtra() As String
        Dim baseDir As String() = AppDomain.CurrentDomain.BaseDirectory.Split("\")
        Dim name As String = baseDir(baseDir.Length - 2)
        Dim result As String = String.Empty

        For i As Integer = 0 To baseDir.Length - 3
            result = result + baseDir(i) + String.Format("\{0} Extra\", name)
        Next

        Return result
    End Function

    Public Shared Function TextParse(ByVal text As String) As List(Of String)
        Dim items As String() = text.Trim(Chr(13)).Split(Chr(13))
        Dim newList As New List(Of String)

        For Each i As String In items
            newList.Add(i.Trim())
        Next

        Return newList
    End Function
#End Region

#Region "Advance Travel (SPD)"
    Public Shared Function GetEmailDept(ByVal department As Integer, ByVal DSN As String) As String
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(DSN)
        Dim query As String = ""

        Dim cookie As Byte() = Nothing

        Dim _emaildept As Object = ""

        query = "select costcenter_id from master_strukturunit where strukturunit_id = " & department & " and strukturunit_active = 1"

        Try
            dbConn.Open()
            clsApplicationRole.SetAppRole(dbConn, cookie)
            Dim dbCmd As New OleDb.OleDbCommand(query, dbConn)
            _emaildept = dbCmd.ExecuteScalar()

        Catch ex As Exception
        Finally
            clsApplicationRole.UnsetAppRole(dbConn, cookie)
            dbConn.Close()
        End Try

        Return _emaildept
    End Function

    Public Shared Function IsEmptyText(ByVal value As String, ByVal value_if_empty As String) As String
        If value <> "" Then
            Return value
        Else
            Return value_if_empty
        End If
    End Function
#End Region
End Class
