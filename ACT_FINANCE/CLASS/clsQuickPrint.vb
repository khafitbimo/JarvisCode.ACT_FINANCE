Imports System.IO
Imports System.Text
Imports Microsoft.Reporting.WinForms
Imports System.Drawing.Printing
Imports System.Drawing.Imaging

Public Class clsQuickPrint : Implements IDisposable
    Private _LocalReport As LocalReport
    Private m_streams As IList(Of Stream)
    Private m_currentPageIndex As Integer
    Private MarginTop As String = "0.25in"
    Private MarginLeft As String = "0.25in"
    Private MarginRight As String = "0.25in"
    Private MarginBottom As String = "0.25in"

#Region " Constructor "
    Sub New()
    End Sub

    Sub New(ByVal LocalReport As LocalReport)
        Me._LocalReport = LocalReport
    End Sub
#End Region

#Region " Properties "
    Public Property LocalReport() As LocalReport
        Get
            Return Me._LocalReport
        End Get
        Set(value As LocalReport)
            Me._LocalReport = value
        End Set
    End Property
#End Region

#Region " Method "
    Private Function CreateStream(ByVal name As String, ByVal fileNameExtension As String, _
                                      ByVal encoding As Encoding, ByVal mimeType As String, ByVal willSeek As Boolean) As Stream
        Dim stream As Stream = New MemoryStream()
        m_streams.Add(stream)
        Return stream
    End Function

    Private Sub Export(ByVal report As LocalReport)
        'Dim deviceInfo As String = "<DeviceInfo>" & _
        '    "<OutputFormat>EMF</OutputFormat>" & _
        '    "<PageWidth>8.5in</PageWidth>" & _
        '    "<PageHeight>11.69in</PageHeight>" & _
        '    "<MarginTop>0.25in</MarginTop>" & _
        '    "<MarginLeft>0.25in</MarginLeft>" & _
        '    "<MarginRight>0.25in</MarginRight>" & _
        '    "<MarginBottom>0.25in</MarginBottom>" & _
        '    "</DeviceInfo>"

        Dim deviceInfo As String = "<DeviceInfo>" & _
            "<OutputFormat>EMF</OutputFormat>" & _
            "<PageWidth>8.5in</PageWidth>" & _
            "<PageHeight>11.69in</PageHeight>" & _
            "<MarginTop>" & Me.MarginTop & "</MarginTop>" & _
            "<MarginLeft>" & Me.MarginLeft & "</MarginLeft>" & _
            "<MarginRight>" & Me.MarginRight & "</MarginRight>" & _
            "<MarginBottom>" & Me.MarginBottom & "</MarginBottom>" & _
            "</DeviceInfo>"

        Dim warnings As Warning() = {}
        m_streams = New List(Of Stream)()
        report.Render("Image", deviceInfo, AddressOf CreateStream, warnings)
        For Each stream As Stream In m_streams
            stream.Position = 0
        Next
    End Sub

    Private Sub PrintPage(ByVal sender As Object, ByVal ev As PrintPageEventArgs)
        Dim pageImage As New Metafile(m_streams(m_currentPageIndex))

        ' Adjust rectangular area with printer margins.
        Dim adjustedRect As New Rectangle(ev.PageBounds.Left - CInt(ev.PageSettings.HardMarginX), _
                                          ev.PageBounds.Top - CInt(ev.PageSettings.HardMarginY), _
                                          ev.PageBounds.Width, _
                                          ev.PageBounds.Height)

        ' Draw a white background for the report
        ev.Graphics.FillRectangle(Brushes.White, adjustedRect)

        ' Draw the report content
        ev.Graphics.DrawImage(pageImage, adjustedRect)

        ' Prepare for the next page. Make sure we haven't hit the end.
        m_currentPageIndex += 1
        ev.HasMorePages = (m_currentPageIndex < m_streams.Count)
    End Sub

    Private Sub Run()
        If m_streams Is Nothing OrElse m_streams.Count = 0 Then
            Throw New Exception("Error: no stream to print.")
        End If
        Dim printDoc As New PrintDocument()
        If Not printDoc.PrinterSettings.IsValid Then
            Throw New Exception("Error: cannot find the default printer.")
        Else
            AddHandler printDoc.PrintPage, AddressOf PrintPage
            m_currentPageIndex = 0
            printDoc.Print()
        End If
    End Sub

    Public Sub Print()
        Me.Export(Me._LocalReport)
        Me.Run()
    End Sub

    Public Sub Print(ByVal MarginTop As String, ByVal MarginLeft As String, ByVal MarginRight As String, ByVal MarginBottom As String)
        Me.MarginTop = MarginTop
        Me.MarginLeft = MarginLeft
        Me.MarginRight = MarginRight
        Me.MarginBottom = MarginBottom

        Me.Export(Me._LocalReport)
        Me.Run()
    End Sub
#End Region

#Region "IDisposable Support"
    Private disposedValue As Boolean

    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                If m_streams IsNot Nothing Then
                    For Each stream As Stream In m_streams
                        stream.Close()
                    Next
                    m_streams = Nothing
                End If
            End If
        End If
        Me.disposedValue = True
    End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region

End Class
