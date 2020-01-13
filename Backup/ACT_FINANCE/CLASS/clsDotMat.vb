Imports System.Data.OleDb

Public Class clsDotMat
    Private m_DSN As String
    Private m_PrinterName As String
    Private m_ReportID As String
    Private m_TblReport As DataTable
    Private m_TblReportDetil As DataTable
    Private m_TblItemToPrint As DataTable
    Private m_ColItemToPrint As Collection = New Collection
    Private m_ColItemToPrintConst As Collection = New Collection

    Structure ItemToPrint
        Dim ItemKey As String
        Dim ColumnName As String
    End Structure

    Structure ItemToPrintConst
        Dim ItemKey As String
        Dim Content As String
    End Structure

    Public Property ReportID()
        Get
            Return m_ReportID
        End Get
        Set(ByVal value)
            m_ReportID = Trim(value)
        End Set
    End Property

    Public Sub AddColItemToPrint(ByVal ItemKey As String, ByVal ColumnName As String)

        m_ColItemToPrint.Add(ColumnName, ItemKey)

    End Sub

    Public Sub AddColItemToPrintConst(ByVal ItemKey As String, ByVal Content As String)

        m_ColItemToPrintConst.Add(Content, ItemKey)

    End Sub

    Public WriteOnly Property TblToPrint()
        Set(ByVal value)
            m_TblItemToPrint = value
        End Set
    End Property

    Public Sub Print()
        Dim strToPrint As String

        strToPrint = Chr(27) + "@" + Chr(27) + "x0" + Chr(27) + Chr(15) + GetStringToPrint()

        RawPrinterHelper.SendStringToPrinter(m_PrinterName, strToPrint)

    End Sub

    Private Sub CreateExtendedRptDataTable(ByVal SlipFormatID As String)
        Dim tbl_report As DataTable = New DataTable
        Dim tbl_reportdetil As DataTable = New DataTable
        Dim criteria As String

        'Dim parRptID As New OleDbParameter("@Criteria", OleDbType.VarChar, 50)
        'parRptID.Value = String.Format(" slipformat_id = '{0}'", SlipFormatID)
        criteria = String.Format(" slipformat_id = '{0}'", SlipFormatID)

        clsUtil.DataFill(m_DSN, tbl_report, "cp_MstSlipFormat_Select", criteria)
        m_TblReport = tbl_report.Copy
        'parRptID = New OleDbParameter("@slipformat_id", OleDbType.VarChar, 50)
        'parRptID.Value = SlipFormatID 

        clsUtil.DataFill(m_DSN, tbl_reportdetil, "cp_MstSlipFormatDetil_Select", SlipFormatID)
        m_TblReportDetil = tbl_reportdetil.Copy
        'm_TblReportDetil = GetDataTable("cp_MstSlipFormatDetil_Select", m_DSN, parRptID)
        m_TblReportDetil.Columns("slipformatfield_isdisabled").DefaultValue = 0
        m_TblReportDetil.Columns("slipformatfield_isNumber").DefaultValue = 0

        m_TblReportDetil.Columns.Add(New DataColumn("slipformatfield_midstart", GetType(Byte)))
        m_TblReportDetil.Columns.Add(New DataColumn("slipformatfield_midlength", GetType(Byte)))

        Dim i, j, k As Byte
        Dim dtrow As DataRow

        If m_TblReportDetil.Rows.Count > 0 Then
            For i = 0 To m_TblReportDetil.Rows.Count - 1
                If m_TblReportDetil.Rows(i)("slipformatfield_height") > 1 Then
                    k = Me.m_TblReportDetil.Rows(i)("slipformatfield_y")
                    For j = 2 To m_TblReportDetil.Rows(i)("slipformatfield_height")
                        dtrow = Me.m_TblReportDetil.NewRow
                        dtrow.Item("slipformat_id") = Me.m_TblReportDetil.Rows(i)("slipformat_id")
                        dtrow.Item("slipformatfield_name") = Me.m_TblReportDetil.Rows(i)("slipformatfield_name")
                        dtrow.Item("slipformatfield_x") = Me.m_TblReportDetil.Rows(i)("slipformatfield_x")
                        dtrow.Item("slipformatfield_y") = k + 1
                        dtrow.Item("slipformatfield_width") = Me.m_TblReportDetil.Rows(i)("slipformatfield_width")
                        dtrow.Item("slipformatfield_height") = 1
                        dtrow.Item("slipformatfield_fontlevel") = Me.m_TblReportDetil.Rows(i)("slipformatfield_fontlevel")
                        dtrow.Item("slipformatfield_alignment") = Me.m_TblReportDetil.Rows(i)("slipformatfield_alignment")
                        dtrow.Item("slipformatfield_midstart") = (j - 1) * Me.m_TblReportDetil.Rows(i)("slipformatfield_width") + 1
                        Me.m_TblReportDetil.Rows.Add(dtrow)
                        k += 1
                    Next
                End If
            Next
        End If

    End Sub
    Public Enum StringAlignment
        Left
        Center
        Right
    End Enum
    Private Function GetStringToPrint() As String

        Dim totalPage As Int16
        Dim i As Int32
        GetStringToPrint = String.Empty

        Dim index As Byte
        Dim index2 As Byte
        Dim tempString As String
        Dim itemPrint As String
        Dim tempDataRow(100) As DataRow
        Dim startPoint As Byte
        Dim endPoint As Byte
        Dim widthItem As Byte


        totalPage = m_TblItemToPrint.Rows.Count
        tempString = String.Empty
        itemPrint = String.Empty

        For i = 0 To totalPage - 1

            CreateExtendedRptDataTable(m_TblItemToPrint.Rows(i)("slipformat_id"))
            For index = 1 To m_TblReport.Rows(0)("slipformat_length")
                tempDataRow = m_TblReportDetil.Select(String.Format("slipformatfield_y = {0}", index), "slipformatfield_x")
                If tempDataRow.Length > 0 Then
                    startPoint = 1
                    endPoint = 0
                    For index2 = 0 To tempDataRow.Length - 1

                        itemPrint = String.Empty
                        '

                        If m_TblItemToPrint.Columns(tempDataRow(index2)("slipformatfield_name")) IsNot Nothing Then
                            If m_TblItemToPrint.Rows(i)(tempDataRow(index2)("slipformatfield_name")) IsNot DBNull.Value Then
                                If tempDataRow(index2)("slipformatfield_isdisabled") = 0 Then
                                    If tempDataRow(index2)("slipformatfield_isNumber") = 1 Then
                                        itemPrint = FormatNumber(m_TblItemToPrint.Rows(i)(tempDataRow(index2)("slipformatfield_name")), 2)
                                    Else
                                        itemPrint = m_TblItemToPrint.Rows(i)(tempDataRow(index2)("slipformatfield_name"))
                                    End If
                                    If Not tempDataRow(index2)("slipformatfield_midstart") Is DBNull.Value Then
                                        itemPrint = Mid(itemPrint, tempDataRow(index2)("slipformatfield_midstart"), tempDataRow(index2)("slipformatfield_width"))
                                    End If

                                    widthItem = tempDataRow(index2)("slipformatfield_x") - startPoint + tempDataRow(index2)("slipformatfield_width")
                                    endPoint += widthItem + 1
                                    tempString += FillString(FillString(itemPrint, tempDataRow(index2)("slipformatfield_width"), tempDataRow(index2)("slipformatfield_alignment"), " "), widthItem, StringAlignment.Right, " ")
                                    startPoint = endPoint

                                End If
                            End If
                        End If


                    Next
                    tempString += Chr(10)
                Else
                    tempString += Chr(10)
                End If
            Next
            If tempString.Length > 0 Then
                tempString = tempString.TrimEnd
            End If
            tempString += Chr(12)

        Next
        GetStringToPrint = tempString
        Return GetStringToPrint
    End Function

    Private Sub EjectKertas()
        PrintLine(1, Chr(12))
    End Sub

    Public Sub New(ByVal DSN As String, ByVal PrinterName As String)
        m_DSN = DSN
        m_PrinterName = PrinterName
    End Sub

    Public Sub PrintSlipFormat()
        Dim strToPrint As String

        strToPrint = Chr(27) + "@" + Chr(27) + "x0" + Chr(27) + Chr(15) + GetStringToPrintSlipFormat()

        RawPrinterHelper.SendStringToPrinter(m_PrinterName, strToPrint)

    End Sub

    Private Function GetStringToPrintSlipFormat() As String

        Dim totalPage As Int16
        Dim i As Int32
        GetStringToPrintSlipFormat = String.Empty

        Dim index As Byte
        Dim index2 As Byte
        Dim tempString As String
        Dim itemPrint As String
        Dim tempDataRow(100) As DataRow
        Dim startPoint As Byte
        Dim endPoint As Byte
        Dim widthItem As Byte


        totalPage = m_TblItemToPrint.Rows.Count
        tempString = String.Empty
        itemPrint = String.Empty

        For i = 0 To totalPage - 1

            CreateExtendedRptDataTable(m_TblItemToPrint.Rows(i)("slipformat_id"))
            For index = 1 To m_TblReport.Rows(0)("slipformat_length")
                tempDataRow = m_TblReportDetil.Select(String.Format("slipformatfield_y = {0}", index), "slipformatfield_x")
                If tempDataRow.Length > 0 Then
                    startPoint = 1
                    endPoint = 0
                    For index2 = 0 To tempDataRow.Length - 1

                        itemPrint = String.Empty
                        '

                        If m_TblItemToPrint.Columns(tempDataRow(index2)("slipformatfield_name")) IsNot Nothing Then
                            If m_TblItemToPrint.Rows(i)(tempDataRow(index2)("slipformatfield_name")) IsNot DBNull.Value Then
                                If tempDataRow(index2)("slipformatfield_isdisabled") = 0 Then
                                    'If tempDataRow(index2)("slipformatfield_isNumber") = 1 Then
                                    '    itemPrint = FormatNumber(m_TblItemToPrint.Rows(i)(tempDataRow(index2)("slipformatfield_name")), 2)
                                    'Else
                                    '    itemPrint = m_TblItemToPrint.Rows(i)(tempDataRow(index2)("slipformatfield_name"))
                                    'End If
                                    itemPrint = m_TblItemToPrint.Rows(i)(tempDataRow(index2)("slipformatfield_name"))
                                    If Not tempDataRow(index2)("slipformatfield_midstart") Is DBNull.Value Then
                                        itemPrint = Mid(itemPrint, tempDataRow(index2)("slipformatfield_midstart"), tempDataRow(index2)("slipformatfield_width"))
                                    End If

                                    widthItem = tempDataRow(index2)("slipformatfield_x") - startPoint + tempDataRow(index2)("slipformatfield_width")
                                    endPoint += widthItem + 1
                                    tempString += FillString(FillString(itemPrint, tempDataRow(index2)("slipformatfield_width"), tempDataRow(index2)("slipformatfield_alignment"), " "), widthItem, StringAlignment.Right, " ")
                                    startPoint = endPoint

                                End If
                            End If
                        End If


                    Next
                    tempString += Chr(10)
                Else
                    tempString += Chr(10)
                End If
            Next
            If tempString.Length > 0 Then
                tempString = tempString.TrimEnd
            End If
            tempString += Chr(12)

        Next
        GetStringToPrintSlipFormat = tempString
        Return GetStringToPrintSlipFormat
    End Function


End Class
