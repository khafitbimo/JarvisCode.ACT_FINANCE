Imports System.Data.OleDb
Imports System.Globalization
Imports System.Threading
Module modMain

    Public sSQL As String
    Public sUser As String = "siFulan"
    Public sChannel As String = "NTV"
    Public oConn As New OleDbConnection '= New System.Data.SqlClient.SqlConnection(strConn)
    Public gFindResult As String
    Public dsTemp As New DataSet
    Public gDSN As String


    'Public Sub OpenConn(ByRef objConnection As OleDbConnection)
    '    Dim mDBSERVER As String = "WORKSHOP"
    '    Dim mDBNAME As String = "ACT"
    '    Dim mDBUSER As String = "sa"
    '    Dim mDBPASSWORD As String = "rahasia"
    '    Dim mDSNTemp As String = " User ID={0}; Password={1}; Data Source=""{2}""; " _
    '                               & " Initial Catalog={3}; " _
    '                               & " Tag with column collation when possible=False; " _
    '                               & " Use Procedure for Prepare=1; Auto Translate=True; " _
    '                               & " Persist Security Info=True; " _
    '                               & " Provider=""SQLOLEDB.1""; " _
    '                               & " Use Encryption for Data=False; Packet Size=4096"

    '    Dim sConn As String = String.Format(mDSNTemp, mDBUSER, mDBPASSWORD, mDBSERVER, mDBNAME)
    '    If oConn.State = ConnectionState.Closed Then
    '        oConn = New OleDbConnection(sConn)
    '        oConn.Open()
    '    End If
    'End Sub

    '-- fungsi buat open dan close connection
    Public Sub OpenConn(ByRef objConnection As OleDbConnection, ByVal strConn As String)

        If oConn.State = ConnectionState.Closed Then
            oConn = New OleDbConnection(strConn)
            oConn.Open()
        End If

    End Sub

    Public Sub CloseConn(ByRef objConnection As OleDbConnection)
        If oConn.State = ConnectionState.Open Then
            oConn.Close()
            oConn.Dispose()
        End If
    End Sub

    '-- digunakan utk memformat tanggal supaya bisa diterima layak oleh sql server
    '-- utk dikembalikan ke aplikasi
    Public Function SetToSQLDate(ByVal strDate As String) As String
        SetToSQLDate = Mid(strDate, 7, 4) & "-" & Mid(strDate, 4, 2) & "-" & Mid(strDate, 1, 2)
        Return SetToSQLDate
    End Function

    '-- digunakan utk mengeset culture ke model tanggal dd/MM/yyyy
    '--
    Public Sub SetGlobalCulture()
        Dim myCI As New CultureInfo("en-GB", False)
        Dim myCIclone As CultureInfo = CType(myCI.Clone(), CultureInfo)

        myCIclone.DateTimeFormat.AMDesignator = "a.m."
        myCIclone.DateTimeFormat.DateSeparator = "/"
        myCIclone.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy"
        myCIclone.NumberFormat.CurrencySymbol = "$"
        myCIclone.NumberFormat.NumberDecimalDigits = 4
        Thread.CurrentThread.CurrentCulture = myCIclone
    End Sub

    '-- Fungsi utk menambahkan karakter pada sebelah kiri text
    '-- Exmpl : InsertSpace(txtID.text, 8, "0") -> mis : txtID.text isinya "250"
    '-- Artinya menambahkan karakter "0" disebelah kiri isi txtID.text dipenuhi 
    '--         sampai sebanyak 8 karakter
    '-- Hasilnya : "00000250"
    Public Function InsertSpace(ByVal sVar As String, ByVal nPanjang As Byte, ByVal sChar As Char) As String
        Dim i As Byte
        Dim nLenSVar As Integer

        nLenSVar = Len(sVar)

        If Len(sVar) <= nPanjang Then
            For i = 1 To nPanjang - nLenSVar
                sVar = sChar & sVar
            Next
            Return sVar
        Else
            sVar = Mid(sVar, 1, 8)
            Return sVar
        End If

    End Function

    Public Sub ClearCheck(ByVal container As Control)
        Dim ctrl As Control
        For Each ctrl In container.Controls
            If TypeOf ctrl Is CheckBox Then
                DirectCast(ctrl, CheckBox).Checked = False
            End If
            If ctrl.HasChildren Then
                ClearText(ctrl)

            End If
        Next
    End Sub

    Public Sub DisabledControl(ByVal container As Control)
        Dim ctrl As Control
        For Each ctrl In container.Controls
            If TypeOf ctrl Is CheckBox Then
                DirectCast(ctrl, CheckBox).Enabled = False
            End If
            If TypeOf ctrl Is TextBox Then
                DirectCast(ctrl, TextBox).Enabled = False
            End If
            If TypeOf ctrl Is ComboBox Then
                DirectCast(ctrl, ComboBox).Enabled = False
            End If
            If TypeOf ctrl Is DateTimePicker Then
                DirectCast(ctrl, DateTimePicker).Enabled = False
            End If

            If ctrl.HasChildren Then
                ClearText(ctrl)

            End If
        Next
    End Sub

    Public Sub EnableControl(ByVal container As Control)
        Dim ctrl As Control
        For Each ctrl In container.Controls
            If TypeOf ctrl Is CheckBox Then
                DirectCast(ctrl, CheckBox).Enabled = True
            End If
            If TypeOf ctrl Is TextBox Then
                DirectCast(ctrl, TextBox).Enabled = True
            End If
            If TypeOf ctrl Is ComboBox Then
                DirectCast(ctrl, ComboBox).Enabled = True
            End If
            If TypeOf ctrl Is DateTimePicker Then
                DirectCast(ctrl, DateTimePicker).Enabled = True
            End If

            If ctrl.HasChildren Then
                ClearText(ctrl)

            End If
        Next
    End Sub


    '-- Procedur utk menghapus text2 di dalam container seperti panel / form
    '-- Penggunaan : ClearText(panel1) : artinya menghapus isi text yg di dalam panel1
    Public Sub ClearText(ByVal container As Control)
        Dim ctrl As Control
        For Each ctrl In container.Controls
            If TypeOf (ctrl) Is TextBox Or TypeOf (ctrl) Is MaskedTextBox Then
                ctrl.Text = ""
            End If
            If TypeOf (ctrl) Is DateTimePicker Then

                ctrl.Text = Today.ToShortDateString
            End If
            If ctrl.HasChildren Then
                ClearText(ctrl)
            End If
        Next
    End Sub

    Public Sub ClearText(ByVal container As Control, ByVal ctrlName As String)
        Dim ctrl As Control
        For Each ctrl In container.Controls
            If (TypeOf (ctrl) Is TextBox Or TypeOf (ctrl) Is MaskedTextBox) _
                And UCase(ctrl.Name) <> UCase(ctrlName) Then
                ctrl.Text = ""
            End If
            If TypeOf (ctrl) Is DateTimePicker Then
                ctrl.Text = Today.ToShortDateString
            End If
            If ctrl.HasChildren Then
                ClearText(ctrl)
            End If
        Next
    End Sub


    '-- digunakan utk mengubah tampilan form (membedakan yg allow user to entry or not)
    '--
    Public Sub ChangeApperance(ByVal container As Control)
        Dim ctrl As Control
        For Each ctrl In container.Controls
            If (TypeOf (ctrl) Is TextBox Or TypeOf (ctrl) Is MaskedTextBox) And _
                ctrl.TabStop = False Then
                ctrl.BackColor = Color.Gainsboro
            End If

            If ctrl.HasChildren Then
                ChangeApperance(ctrl)
            End If
        Next
    End Sub

    '-- Function utk mengenerate column ---------------------------------------
    '-- Penggunaan : Dim colName as DataGridViewTextBoxColumn("column_nama", _
    '--                                                       "column_nama", _
    '--                                                       "NAMA", _
    '--                                                       "TXT10")
    '-- Artinya mengenerate column dgn column dari datasource kolom "column_nama"
    '-- header column = "NAMA", lebar kolom 10 karakter(dg font default), 
    '-- tipe isi kolom text(bs jg utk numeric, atau kolom checkbox)
    Public Function CreateColumn(ByVal ColumnName As String, _
            ByVal DataPropertyName As String, _
            ByVal HeaderText As String, _
            ByVal TypePanjang As String, _
            Optional ByVal Alignment As DataGridViewContentAlignment = DataGridViewContentAlignment.MiddleCenter, _
            Optional ByVal IsreadOnly As Boolean = True, _
            Optional ByVal IsHidden As Boolean = False, _
            Optional ByVal SortMode As DataGridViewColumnSortMode = DataGridViewColumnSortMode.NotSortable) As DataGridViewTextBoxColumn

        Try
            CreateColumn = New DataGridViewTextBoxColumn
            CreateColumn.Name = ColumnName
            CreateColumn.DataPropertyName = DataPropertyName
            CreateColumn.HeaderText = HeaderText
            CreateColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            CreateColumn.DefaultCellStyle.Alignment = Alignment
            CreateColumn.ReadOnly = IsreadOnly
            CreateColumn.Visible = Not IsHidden
            CreateColumn.SortMode = SortMode

            TypePanjang = Trim(TypePanjang)
            Select Case UCase(Mid(TypePanjang, 1, 3))
                Case "TXT"
                    If Len(HeaderText) >= Val(Right(TypePanjang, Len(TypePanjang) - 3)) Then
                        CreateColumn.Width = Val(Right(TypePanjang, Len(TypePanjang) - 3)) * 6.0075 + 10 + 10
                    Else
                        CreateColumn.Width = Val(Right(TypePanjang, Len(TypePanjang) - 3)) * 6.0075 + 10
                    End If
                Case "NUM"
                    Dim arrsTemp(1) As String
                    Dim sDecimal As String
                    Dim i As Integer

                    arrsTemp = Right(TypePanjang, Len(TypePanjang) - 3).Split(".")

                    If Val(arrsTemp(1)) > 0 Then
                        CreateColumn.Width = (Val(arrsTemp(0)) + Val(arrsTemp(1)) + 1) * 6.0075 + 10
                        sDecimal = ""
                        If Val(Len(arrsTemp(1))) > 1 Then
                            For i = 2 To Val(Len(arrsTemp(1)))
                                sDecimal = sDecimal & "#"
                            Next
                        End If
                        sDecimal = sDecimal + "0"

                        CreateColumn.DefaultCellStyle.Format = "#." + sDecimal
                    Else
                        CreateColumn.Width = (Val(arrsTemp(0))) * 6.0075 + 10
                        CreateColumn.DefaultCellStyle.Format = "#0"
                    End If

                Case "CHK"
            End Select

            Return CreateColumn

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try

    End Function

    Public Function CreateColumn(ByVal ColumnName As String, _
            ByVal DataPropertyName As String, _
            ByVal HeaderText As String, _
            ByVal Width As Integer, _
            Optional ByVal IsreadOnly As Boolean = True, _
            Optional ByVal IsHidden As Boolean = False, _
            Optional ByVal SortMode As DataGridViewColumnSortMode = DataGridViewColumnSortMode.NotSortable) As DataGridViewCheckBoxColumn

        Try
            CreateColumn = New DataGridViewCheckBoxColumn
            CreateColumn.Name = ColumnName
            CreateColumn.DataPropertyName = DataPropertyName
            CreateColumn.HeaderText = HeaderText
            CreateColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            CreateColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            CreateColumn.ReadOnly = IsreadOnly
            CreateColumn.Visible = Not IsHidden
            CreateColumn.SortMode = SortMode

            CreateColumn.Width = Width * 6.0075 + 10
            Return CreateColumn

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try

    End Function

    Public Function CreateColumn(ByVal ColumnName As String, _
                    ByVal DataPropertyName As String, _
                    ByVal HeaderText As String, _
                    ByVal Panjang As Long, _
                    ByVal ValueMember As String, _
                    ByVal DisplayMember As String, _
                    ByVal DataSource As DataTable, _
                    Optional ByVal AutoComplete As Boolean = True, _
                    Optional ByVal DisplayStyle As DataGridViewComboBoxDisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox, _
                    Optional ByVal Alignment As DataGridViewContentAlignment = DataGridViewContentAlignment.MiddleCenter, _
                    Optional ByVal DisplayStyleForCurrentCellOnly As Boolean = True, _
                    Optional ByVal IsreadOnly As Boolean = True, _
                    Optional ByVal IsHidden As Boolean = False, _
                    Optional ByVal SortMode As DataGridViewColumnSortMode = DataGridViewColumnSortMode.NotSortable) As DataGridViewComboBoxColumn

        Try

            CreateColumn = New DataGridViewComboBoxColumn

            CreateColumn.Name = ColumnName
            CreateColumn.DataPropertyName = DataPropertyName
            CreateColumn.HeaderText = HeaderText
            CreateColumn.ValueMember = ValueMember
            CreateColumn.DisplayMember = DisplayMember
            CreateColumn.DataSource = DataSource

            CreateColumn.DefaultCellStyle.Alignment = Alignment
            CreateColumn.ReadOnly = IsreadOnly
            CreateColumn.Visible = Not IsHidden
            CreateColumn.Width = Panjang * 6.0075 + 10
            CreateColumn.SortMode = SortMode

            Return CreateColumn

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return Nothing
    End Function


    Public Sub FillDataTable(ByRef data_table As DataTable, ByVal stored_procedure_name As String, ByVal conn As String, ByVal ParamArray params() As OleDb.OleDbParameter)
        Dim oConn As System.Data.OleDb.OleDbConnection
        Dim oCmd As System.Data.OleDb.OleDbCommand
        Dim oDA As System.Data.OleDb.OleDbDataAdapter

        Try

            oConn = New System.Data.OleDb.OleDbConnection(conn)
            oCmd = New System.Data.OleDb.OleDbCommand(stored_procedure_name, oConn)
            oCmd.CommandType = CommandType.StoredProcedure
            oCmd.Parameters.AddRange(params)


            oDA = New System.Data.OleDb.OleDbDataAdapter(oCmd)
            oDA.Fill(data_table)

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            oConn = Nothing
            oCmd = Nothing
            oDA = Nothing
        End Try


    End Sub

    Public Sub FillDataTable(ByRef data_table As DataTable, ByVal strSQL As String, ByVal conn As String)
        Dim oConn As System.Data.OleDb.OleDbConnection
        Dim oCmd As System.Data.OleDb.OleDbCommand
        Dim oDA As System.Data.OleDb.OleDbDataAdapter

        Try

            oConn = New System.Data.OleDb.OleDbConnection(conn)
            oCmd = New System.Data.OleDb.OleDbCommand(strSQL, oConn)
            oCmd.CommandType = CommandType.Text


            oDA = New System.Data.OleDb.OleDbDataAdapter(oCmd)
            oDA.Fill(data_table)

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            oConn = Nothing
            oCmd = Nothing
            oDA = Nothing
        End Try


    End Sub

    Public Sub ExecuteSP(ByVal stored_procedure_name As String, ByVal conn As String, ByVal ParamArray params() As OleDb.OleDbParameter)
        Dim oConn As System.Data.OleDb.OleDbConnection
        Dim oCmd As System.Data.OleDb.OleDbCommand

        Try

            oConn = New System.Data.OleDb.OleDbConnection(conn)
            oConn.Open()

            oCmd = New System.Data.OleDb.OleDbCommand(stored_procedure_name, oConn)
            oCmd.CommandType = CommandType.StoredProcedure
            oCmd.Parameters.AddRange(params)
            oCmd.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            oConn = Nothing
            oCmd = Nothing
        End Try

    End Sub

    Public Sub ExecuteStringCommand(ByVal strSQL As String, ByVal strConn As String)

        Dim oConn As System.Data.OleDb.OleDbConnection = New OleDb.OleDbConnection(strConn)
        Dim oCmd As System.Data.OleDb.OleDbCommand = New OleDb.OleDbCommand

        oConn.Open()
        oCmd.Connection = oConn
        oCmd.CommandType = CommandType.Text
        oCmd.CommandText = strSQL
        oCmd.ExecuteNonQuery()
        oConn.Close()

    End Sub



    Public Function GetDataTable(ByVal _sStoredProcedureName As String, ByVal _sConn As String, ByVal ParamArray _Params() As System.Data.OleDb.OleDbParameter) As DataTable
        GetDataTable = New DataTable

        Dim oConn As System.Data.OleDb.OleDbConnection
        Dim oCmd As System.Data.OleDb.OleDbCommand
        Dim oDA As System.Data.OleDb.OleDbDataAdapter

        Try

            oConn = New System.Data.OleDb.OleDbConnection(_sConn)
            oCmd = New System.Data.OleDb.OleDbCommand(_sStoredProcedureName, oConn)
            oCmd.CommandType = CommandType.StoredProcedure
            oCmd.Parameters.AddRange(_Params)


            oDA = New System.Data.OleDb.OleDbDataAdapter(oCmd)
            oDA.Fill(GetDataTable)

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            oConn = Nothing
            oCmd = Nothing
            oDA = Nothing
        End Try

        Return GetDataTable
    End Function

    Public Function GetDataTable(ByVal strSQL As String, ByVal _sConn As String) As DataTable
        GetDataTable = New DataTable

        Dim oConn As System.Data.OleDb.OleDbConnection
        Dim oCmd As System.Data.OleDb.OleDbCommand
        Dim oDA As System.Data.OleDb.OleDbDataAdapter

        Try

            oConn = New System.Data.OleDb.OleDbConnection(_sConn)
            oCmd = New System.Data.OleDb.OleDbCommand(strSQL, oConn)
            oCmd.CommandType = CommandType.Text


            oDA = New System.Data.OleDb.OleDbDataAdapter(oCmd)
            oDA.Fill(GetDataTable)

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            oConn = Nothing
            oCmd = Nothing
            oDA = Nothing
        End Try

        Return GetDataTable
    End Function

    Public Sub ValidatingCombo(ByVal combo_box As ComboBox, ByVal evArg As System.ComponentModel.CancelEventArgs)

        If combo_box.SelectedValue Is Nothing And Trim(combo_box.Text) <> String.Empty Then
            MsgBox(String.Format("Item '{0}' does not pass validation test", combo_box.Text))
            evArg.Cancel = True
        End If

    End Sub


    Public Enum StringAlignment
        Left
        Center
        Right
    End Enum


    Public Function FillString(ByVal StringObject As String, _
                             ByVal StringWidth As Int16, _
                             ByVal Alignment As StringAlignment, _
                             ByVal CharToFill As String) As String

        Dim WidthAddedChar As Integer
        Dim WidthAddedLeftChar As Integer
        Dim WidthAddedRightChar As Integer

        FillString = ""
        If StringWidth > Len(StringObject) Then
            Select Case Alignment

                Case StringAlignment.Left
                    FillString = StringObject.PadRight(StringWidth, CharToFill)

                Case StringAlignment.Center
                    WidthAddedChar = StringWidth - Len(StringObject)
                    WidthAddedLeftChar = System.Math.Round(WidthAddedChar / 2)

                    WidthAddedRightChar = WidthAddedChar - WidthAddedLeftChar
                    If WidthAddedLeftChar > WidthAddedRightChar Then
                        WidthAddedLeftChar = WidthAddedLeftChar - 1
                        WidthAddedRightChar = WidthAddedRightChar + 1
                    End If
                    FillString = StringObject.PadLeft(StringObject.Length + WidthAddedLeftChar, CharToFill).PadRight(StringWidth, CharToFill)

                Case StringAlignment.Right
                    FillString = StringObject.PadLeft(StringWidth, CharToFill)
            End Select
        Else
            FillString = Mid(StringObject, 1, StringWidth)

        End If
        Return FillString

    End Function

    Public gResult As String

End Module
