Imports Microsoft.Office.Interop
Imports System.Runtime.InteropServices

Public Class clsExcel : Implements IDisposable

    Private tbl As DataTable
    Private xl As Excel.Application
    Private xlBook As Excel.Workbook
    Private xlWorkSheet As Excel.Worksheet
    Private _Columns As List(Of String)

    Public Event AfterInsert(ByVal row As DataRow)

#Region " Constructor"

    Sub New()
        Me.xl = New Excel.Application
        Me.xlBook = xl.Workbooks.Add
        Me.xlWorkSheet = Me.xlBook.Worksheets(1)
    End Sub

    Sub New(ByRef tbl As DataTable)
        Me.xl = New Excel.Application
        Me.tbl = tbl

        Me.xlBook = xl.Workbooks.Add
        Me.xlWorkSheet = Me.xlBook.Worksheets(1)
    End Sub
#End Region

#Region "  Property "

    Public Property MyTable() As DataTable
        Get
            Return Me.tbl
        End Get
        Set(ByVal value As DataTable)
            Me.tbl = value
        End Set
    End Property

    Public Property ExcelApplication() As Excel.Application
        Get
            Return Me.xl
        End Get
        Set(ByVal value As Excel.Application)
            Me.xl = value
        End Set
    End Property

    Public Property MyColumns() As List(Of String)
        Get
            Return Me._Columns
        End Get
        Set(ByVal value As List(Of String))
            Me._Columns = value
        End Set
    End Property

#End Region


    Public Sub Execute()

        'Membuat columns

        If Me.MyColumns.Count > 0 Then
            For i As Integer = 1 To Me.MyColumns.Count
                CType(Me.xlWorkSheet.Cells(1, i), Excel.Range).Value = Me.MyColumns(i - 1)
                CType(Me.xlWorkSheet.Cells(1, i), Excel.Range).Font.Bold = True
                CType(Me.xlWorkSheet.Cells(1, i), Excel.Range).BorderAround(1, ColorIndex:=1, Weight:=2)
            Next
        Else
            Dim i As Integer = 0

            For Each col As DataColumn In Me.tbl.Columns
                i += 1

                CType(Me.xlWorkSheet.Cells(1, i), Excel.Range).Value = col.Caption
                CType(Me.xlWorkSheet.Cells(1, i), Excel.Range).Font.Bold = True
            Next

        End If

        'Insert row
        Dim rowVal As String = String.Empty
        Dim mark As String = String.Empty
        Dim rowIndex As Integer = 0
        Dim colIndex As Integer = 0

        For Each row As DataRow In Me.tbl.Rows

            colIndex = 0
            For Each col As DataColumn In Me.tbl.Columns
                If col.DataType Is GetType(String) Then
                    rowVal = row.Item(col.ColumnName).ToString().Trim()

                    If rowVal = "-- Pilih --" Then
                        rowVal = ""
                    End If

                    If rowVal <> String.Empty Then
                        mark = row.Item(col.ColumnName).ToString().Substring(0, 1)
                    End If

                    If mark = "=" Then
                        mark = "'" & rowVal
                    Else
                        mark = rowVal
                    End If

                ElseIf col.DataType Is GetType(Boolean) Then
                    Dim val As Boolean = clsUtil.IsDbNull(row.Item(col.ColumnName), 0)

                    If val = True Then
                        mark = 1
                    ElseIf val = False Then
                        mark = 0
                    End If
                Else
                    mark = row.Item(col.ColumnName).ToString().Trim()
                End If

                Me.xlWorkSheet.Cells((rowIndex + 2), (colIndex + 1)).Value = mark
                Me.xlWorkSheet.Cells((rowIndex + 2), (colIndex + 1)).BorderAround(1, ColorIndex:=1, Weight:=2)
                CType(Me.xlWorkSheet.Cells((rowIndex + 2), (colIndex + 1)), Excel.Range).Columns.AutoFit()


                colIndex += 1
            Next

            RaiseEvent AfterInsert(row)
            rowIndex += 1
        Next
    End Sub

#Region " IDisposable Support "
    Private disposedValue As Boolean = False
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                Marshal.ReleaseComObject(xl)
                xl = Nothing
                GC.Collect()
                GC.WaitForPendingFinalizers()
                GC.Collect()
                ' TODO: free unmanaged resources when explicitly called
            End If
            ' TODO: free shared unmanaged resources
        End If
        Me.disposedValue = True
    End Sub

    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region

End Class
