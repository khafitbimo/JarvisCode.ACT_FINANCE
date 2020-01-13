'--- PTS 15 Agustus 2011 -----
Option Strict Off
Imports System.Data
Public Class clsExcelFromDgv
    Private Function CreateRecordsetFromDataGrid(ByVal DGV As DataGridView) As ADODB.Recordset
        Dim rs As New ADODB.Recordset
        'Create columns in ADODB.Recordset

        Dim FieldAttr As ADODB.FieldAttributeEnum
        FieldAttr = ADODB.FieldAttributeEnum.adFldIsNullable Or ADODB.FieldAttributeEnum.adFldIsNullable Or ADODB.FieldAttributeEnum.adFldUpdatable

        For Each iColumn As DataGridViewColumn In DGV.Columns
            'only add Visible columns
            If iColumn.Visible = True Then
                Dim FieldType As ADODB.DataTypeEnum
                'select dataType
                If iColumn.ValueType Is GetType(Boolean) Then
                    FieldType = ADODB.DataTypeEnum.adBoolean
                ElseIf iColumn.ValueType Is GetType(Byte) Then
                    FieldType = ADODB.DataTypeEnum.adTinyInt
                ElseIf iColumn.ValueType Is GetType(Int16) Then
                    FieldType = ADODB.DataTypeEnum.adSmallInt
                ElseIf iColumn.ValueType Is GetType(Int32) Then
                    FieldType = ADODB.DataTypeEnum.adInteger
                ElseIf iColumn.ValueType Is GetType(Int64) Then
                    FieldType = ADODB.DataTypeEnum.adBigInt
                ElseIf iColumn.ValueType Is GetType(Single) Then
                    FieldType = ADODB.DataTypeEnum.adSingle
                ElseIf iColumn.ValueType Is GetType(Double) Then
                    FieldType = ADODB.DataTypeEnum.adDouble
                ElseIf iColumn.ValueType Is GetType(Decimal) Then
                    FieldType = ADODB.DataTypeEnum.adCurrency
                ElseIf iColumn.ValueType Is GetType(DateTime) Then
                    FieldType = ADODB.DataTypeEnum.adDBDate
                ElseIf iColumn.ValueType Is GetType(Char) Then
                    FieldType = ADODB.DataTypeEnum.adChar
                ElseIf iColumn.ValueType Is GetType(String) Then
                    FieldType = ADODB.DataTypeEnum.adVarWChar
                End If
                If FieldType = ADODB.DataTypeEnum.adVarWChar Then
                    rs.Fields.Append(iColumn.Name, FieldType, 300)
                Else
                    rs.Fields.Append(iColumn.Name, FieldType)
                End If
                rs.Fields(iColumn.Name).Attributes = FieldAttr
            End If
        Next
        'Opens the ADODB.Recordset
        rs.Open()
        'Inserts rows into the recordset
        For Each iRow As DataGridViewRow In DGV.Rows
            rs.AddNew()
            For Each iColumn As DataGridViewColumn In DGV.Columns
                'only add values for Visible columns
                If iColumn.Visible = True Then
                    'Dim col As New List(Of String)
                    'col.Add(iColumn.HeaderText)
                    If iRow.Cells(iColumn.Name).Value.ToString = "" Then
                        If (rs(iColumn.Name).Attributes And ADODB.FieldAttributeEnum.adFldIsNullable) <> 0 Then
                            rs(iColumn.Name).Value = DBNull.Value
                        End If
                    Else
                        rs(iColumn.Name).Value = iRow.Cells(iColumn.Name).Value
                    End If
                End If
            Next
        Next
        'Moves to the first record in recordset
        If Not rs.BOF Then rs.MoveFirst()
        Return rs

    End Function

    Public Sub openExcelReport(ByRef DGV As DataGridView, _
    Optional ByVal bolSave As Boolean = False, _
    Optional ByVal bolOpen As Boolean = True)

        Dim xlApp As New Microsoft.Office.Interop.Excel.Application
        Dim xlBook As Microsoft.Office.Interop.Excel.Workbook
        Dim xlSheet As Microsoft.Office.Interop.Excel.Worksheet
        Dim rs As New ADODB.Recordset
        Dim xlrow As Integer
        Dim strColType() As String

        'Add WorkSheet... Cuyyy...!---
        Try
            

            'opening connections to excel
            xlBook = xlApp.Workbooks.Add
            'xlSheet = xlBook.Worksheets.Add()
            xlSheet = xlBook.Worksheets(1)
            If bolOpen = True Then
                xlApp.Application.Visible = True
            End If
            xlrow = 1

            Try
                xlSheet.Columns.HorizontalAlignment = 2
                'formating the output of the report
                xlSheet.Columns.Font.Name = "Times New Roman"
                xlSheet.Rows.Item(xlrow).Font.Bold = 1
                'xlSheet.Rows.Item(xlrow).Interior.ColorIndex = 15
                rs = CreateRecordsetFromDataGrid(DGV)
                If rs.State = 0 Then rs.Open()
            Catch
                GoTo PROC_EXIT
            End Try

            ReDim strColType(rs.Fields.Count)
            For j As Integer = 0 To rs.Fields.Count - 1
                xlSheet.Cells.Item(xlrow, j + 1) = rs.Fields.Item(j).Name
                xlSheet.Cells(xlrow, j + 1).BorderAround(1, ColorIndex:=16, Weight:=2)
            Next j

            'This does a simple test to see if the of excel held by the user is 2000 or later
            'This is needed because "CopyFromRecordset" only works with excel 2000 or later

            xlrow = 2

            If Val(Mid(xlApp.Version, 1, InStr(1, xlApp.Version, ".") - 1)) > 8 Then
                xlSheet.Range("A" & xlrow).CopyFromRecordset(rs)
            Else
                MessageBox.Show("You must use excel 2000 or above, opperation can not continue", "Excel Report", _
                MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                GoTo PROC_EXIT
            End If


            'some more formatting of the excel sheet. Thsi formats the way the

            'sheet looks in print preview

            xlSheet.PageSetup.LeftHeader = "&[Page]" & " of " & "&[Pages]"
            xlSheet.PageSetup.RightHeader = "&[Date]" & " &[Time]"
            xlSheet.PageSetup.HeaderMargin = 2
            xlSheet.PageSetup.BottomMargin = 2
            xlSheet.PageSetup.LeftMargin = 2
            xlSheet.PageSetup.RightMargin = 2
            xlSheet.PageSetup.TopMargin = 13
            xlSheet.Columns.AutoFit()
            xlSheet.Rows.AutoFit()
            xlApp.UserControl = True
            If bolOpen = False Then
                xlApp.DisplayAlerts = False
                xlApp.Application.Quit()
            ElseIf bolSave = True Then
                xlApp.DisplayAlerts = False
                xlApp.DisplayAlerts = True
            End If

        Catch ex As Exception

        End Try

PROC_EXIT:
        xlSheet = Nothing
        xlBook = Nothing
        xlApp = Nothing
    End Sub
End Class
