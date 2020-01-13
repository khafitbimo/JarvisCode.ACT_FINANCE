'=== PTS 20150527 ====
Imports System
Imports System.IO
Imports System.Data
Imports System.Text
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Drawing.Printing
Imports System.Collections.Generic
Imports System.Windows.Forms
Imports Microsoft.Reporting.WinForms
Imports System.Threading
Imports System.ComponentModel
Imports System.IO.File
Imports System.ComponentModel.Component

Public Class clsPrintGiroAndCek
    Private m_streams As IList(Of System.IO.Stream)
    Private m_currentPageIndex As Integer
    Private PaymentType As Integer
    Private Bank As Integer
    Private RekananName As String
    Private ReceiveBy As String
    Private TglBilyet As String
    Private TglEfektif As String
    Private AmountIDR As Decimal
    Private AmountIDRTerbilang As String
    Private printernamesetting As String '= My.Computer.FileSystem.ReadAllText("\cekgiro_printersetting.txt")''
    Private AccNumber As String
    Private BankName As String

#Region "ENUM"
    Enum Payment
        TUNAI = 1
        CEK = 2
        BG = 3
        TRANSFER = 4
    End Enum

    Enum BANKList
        ArthaGrahaInternasional = 1
        Panin = 2
        Danamon = 3
        BCA = 4
        Mandiri = 5
        CIMBNiaga = 6
        SinarMas = 7
        BRI = 11
    End Enum
#End Region

#Region "PRINT"
    Public Sub New(ByVal PaymentType As Integer, ByVal bank As Integer, _
                  ByVal RekananName As String, ByVal ReceiveBy As String, _
                  ByVal TglBilyet As String, ByVal TglEfektif As String, ByVal AmountIDR As Decimal, ByVal AccNumber As String, ByVal BankName As String)
        Me.PaymentType = PaymentType
        Me.Bank = bank
        Me.RekananName = RekananName
        Me.ReceiveBy = ReceiveBy
        Me.TglBilyet = TglBilyet
        Me.TglEfektif = TglEfektif
        Me.AmountIDR = AmountIDR
        Me.AmountIDRTerbilang = IIf(AmountIDR = 0, "", clsUtil.Terbilang(AmountIDR))
        Me.AccNumber = AccNumber
        Me.BankName = BankName


        If Me.PaymentType = Payment.BG Then
            If Me.Bank = BANKList.CIMBNiaga Then
                Me.PrintGiroCIMBNiaga()
            ElseIf Me.Bank = BANKList.Danamon Then
                Me.PrintGiroDanamon()
            ElseIf Me.Bank = BANKList.ArthaGrahaInternasional Then
                Me.PrintGiroArthaGraha()
            ElseIf Me.Bank = BANKList.Mandiri Then
                Me.PrintGiroMandiri()
                'MsgBox("Belum ada format Giro untuk Bank Mandiri", MsgBoxStyle.Information, "Information")
                'Exit Sub
            ElseIf Me.Bank = BANKList.BCA Then
                Me.PrintGiroBCA()
            Else
                MsgBox("That bank cant print giro", MsgBoxStyle.Information, "Information")
                Exit Sub
            End If

        ElseIf Me.PaymentType = Payment.CEK Then
            If Me.Bank = BANKList.CIMBNiaga Then
                Me.PrintCekCIMBNiaga()
            ElseIf Me.Bank = BANKList.Danamon Then
                Me.PrintCekDanamon()
            ElseIf Me.Bank = BANKList.ArthaGrahaInternasional Then
                Me.PrintCekArthaGraha()
            ElseIf Me.Bank = BANKList.Mandiri Then
                Me.PrintCekMandiri()
            ElseIf Me.Bank = BANKList.BCA Then
                Me.PrintCekBCA()
            Else
                MsgBox("That bank cant print cek", MsgBoxStyle.Information, "Information")
                Exit Sub
            End If
        Else
            MsgBox("cant print, check your payment type", MsgBoxStyle.Information, "Information")
            Exit Sub
        End If

    End Sub

    Private Function CreateStream(ByVal name As String, ByVal fileNameExtension As String, ByVal encoding As Encoding, ByVal mimeType As String, ByVal willSeek As Boolean) As Stream
        Dim stream As Stream = New MemoryStream()
        m_streams.Add(stream)
        Return stream
    End Function

    Private Sub Export(ByVal report As LocalReport)
        'Private Sub Export(ByVal report As Microsoft.Reporting.WinForms.LocalReport)
        Dim deviceInfo As String = "<DeviceInfo>" & _
            "<OutputFormat>EMF</OutputFormat>" & _
            "<PageWidth>21cm</PageWidth>" & _
            "<PageHeight>29.7cm</PageHeight>" & _
            "<MarginTop>0.0cm</MarginTop>" & _
            "<MarginLeft>0.0cm</MarginLeft>" & _
            "<MarginRight>0.0cm</MarginRight>" & _
            "<MarginBottom>0.0cm</MarginBottom>" & _
            "</DeviceInfo>"
        Dim warnings As Warning() = Nothing
        m_streams = New List(Of Stream)()

        Try
            report.Render("Image", deviceInfo, AddressOf CreateStream, warnings)
        Catch e As System.Exception
            Dim inner As Exception = e.InnerException
            While Not (inner Is Nothing)
                MsgBox(inner.Message)
                inner = inner.InnerException
            End While
        End Try
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

    Private Sub Print()
        Dim printDoc As New System.Drawing.Printing.PrintDocument()
        Dim printSet As New System.Drawing.Printing.PrinterSettings
        'Const printerName As String = "Microsoft Office Document Image Writer"
        Try
            Me.printernamesetting = My.Computer.FileSystem.ReadAllText("\Gamba_cekgiro_printersetting.txt")
            'printSet.PrinterName = "HP LaserJet 400 M401n (172.16.52.200)"
            'printSet.PrinterName = "EPSON FX-890 Ver 2.0"
            printSet.PrinterName = printernamesetting
        Catch ex As Exception

            Dim filepath As String = "\Gamba_cekgiro_printersetting.txt"
            If Not System.IO.File.Exists(filepath) Then
                System.IO.File.Create(filepath).Dispose()
            End If

            Dim dialog As dlgSettingPrinterGiroCek = New dlgSettingPrinterGiroCek(String.Empty)
            dialog.ShowDialog()

            If dialog.DialogResult = DialogResult.OK Then
                Me.printernamesetting = My.Computer.FileSystem.ReadAllText("\Gamba_cekgiro_printersetting.txt")
                printSet.PrinterName = printernamesetting
            End If
        End Try

        Dim printerName As String = printSet.PrinterName
        If m_streams Is Nothing Or m_streams.Count = 0 Then
            Return
        End If

        'Dim printDoc As New System.Drawing.Printing.PrintDocument()

        printDoc.PrinterSettings.PrinterName = printerName
        If Not printDoc.PrinterSettings.IsValid Then
            Dim msg As String = String.Format("Can't find printer ""{0}"".", printerName)
            Console.WriteLine(msg)
            Return
        End If
        AddHandler printDoc.PrintPage, AddressOf PrintPage
        printDoc.Print()

    End Sub
#End Region

#Region "Bank CIMB NIAGA"
    Private Sub PrintGiroCIMBNiaga()
        Dim objReportH As Microsoft.Reporting.WinForms.LocalReport = New Microsoft.Reporting.WinForms.LocalReport

        Dim parRptTglBilyet As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("tglbilyet", Me.TglBilyet)
        Dim parRptRekananName As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("rekananname", Me.RekananName)
        Dim parRptAmountIDR As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("amountidr", Me.AmountIDR)
        Dim parRptAmountIDRTerbilang As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("amountidrterbilang", Me.AmountIDRTerbilang)

        Dim parRptAccNumber As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("accnumber", Me.AccNumber)
        Dim parRptBankName As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("bankname", Me.BankName)
        Dim parRptTglEfektif As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("tglefektif", Me.TglEfektif)

        objReportH.ReportEmbeddedResource = My.Application.GetType.Namespace.ToString.Substring(0, Len(My.Application.GetType.Namespace.ToString) - 3) _
                                            + "." + "rptGiroCimbNiaga.rdlc" '"ACT_FINANCE.rptGiroCimbNiaga.rdlc"
        objReportH.EnableExternalImages = True
        objReportH.SetParameters((New Microsoft.Reporting.WinForms.ReportParameter() {parRptTglBilyet, parRptRekananName, parRptAmountIDR, parRptAmountIDRTerbilang, _
                                                                                      parRptAccNumber, parRptBankName, parRptTglEfektif}))
        Export(objReportH)
        m_currentPageIndex = 0
        Print()

    End Sub

    Private Sub PrintCekCIMBNiaga()
        Dim objReportH As Microsoft.Reporting.WinForms.LocalReport = New Microsoft.Reporting.WinForms.LocalReport

        Dim parRptTglBilyet As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("tglbilyet", Me.TglBilyet)
        Dim parRptRekananName As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("rekananname", Me.RekananName)
        Dim parRptAmountIDR As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("amountidr", Me.AmountIDR)
        Dim parRptAmountIDRTerbilang As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("amountidrterbilang", Me.AmountIDRTerbilang)
        Dim parRptTglEfektif As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("tglefektif", Me.TglEfektif)

        objReportH.ReportEmbeddedResource = My.Application.GetType.Namespace.ToString.Substring(0, Len(My.Application.GetType.Namespace.ToString) - 3) _
                                            + "." + "rptCekCimbNiaga.rdlc" '"ACT_FINANCE.rptCekCimbNiaga.rdlc"
        objReportH.EnableExternalImages = True
        objReportH.SetParameters((New Microsoft.Reporting.WinForms.ReportParameter() {parRptTglBilyet, parRptRekananName, parRptAmountIDR, parRptAmountIDRTerbilang, parRptTglEfektif}))
        Export(objReportH)
        m_currentPageIndex = 0
        Print()

    End Sub
#End Region

#Region "Bank Danamon"
    Private Sub PrintGiroDanamon()
        Dim objReportH As Microsoft.Reporting.WinForms.LocalReport = New Microsoft.Reporting.WinForms.LocalReport
        Dim parRptTglBilyet As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("tglbilyet", Me.TglBilyet)
        Dim parRptRekananName As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("rekananname", Me.RekananName)
        Dim parRptAmountIDR As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("amountidr", Me.AmountIDR)
        Dim parRptAmountIDRTerbilang As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("amountidrterbilang", Me.AmountIDRTerbilang)

        Dim parRptAccNumber As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("accnumber", Me.AccNumber)
        Dim parRptBankName As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("bankname", Me.BankName)
        Dim parRptTglEfektif As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("tglefektif", Me.TglEfektif)

        objReportH.ReportEmbeddedResource = My.Application.GetType.Namespace.ToString.Substring(0, Len(My.Application.GetType.Namespace.ToString) - 3) _
                                            + "." + "rptGiroDanamon.rdlc" '"ACT_FINANCE.rptGiroCimbNiaga.rdlc"
        objReportH.EnableExternalImages = True
        objReportH.SetParameters((New Microsoft.Reporting.WinForms.ReportParameter() {parRptTglBilyet, parRptRekananName, parRptAmountIDR, parRptAmountIDRTerbilang, _
                                                                                      parRptAccNumber, parRptBankName, parRptTglEfektif}))
        Export(objReportH)
        m_currentPageIndex = 0
        Print()
    End Sub

    Private Sub PrintCekDanamon()
        Dim objReportH As Microsoft.Reporting.WinForms.LocalReport = New Microsoft.Reporting.WinForms.LocalReport
        Dim parRptTglBilyet As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("tglbilyet", Me.TglBilyet)
        Dim parRptRekananName As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("rekananname", Me.RekananName)
        Dim parRptAmountIDR As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("amountidr", Me.AmountIDR)
        Dim parRptAmountIDRTerbilang As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("amountidrterbilang", Me.AmountIDRTerbilang)
        Dim parRptTglEfektif As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("tglefektif", Me.TglEfektif)

        objReportH.ReportEmbeddedResource = My.Application.GetType.Namespace.ToString.Substring(0, Len(My.Application.GetType.Namespace.ToString) - 3) _
                                            + "." + "rptCekDanamon.rdlc" '"ACT_FINANCE.rptCekCimbNiaga.rdlc"
        objReportH.EnableExternalImages = True
        objReportH.SetParameters((New Microsoft.Reporting.WinForms.ReportParameter() {parRptTglBilyet, parRptRekananName, parRptAmountIDR, parRptAmountIDRTerbilang, parRptTglEfektif}))
        Export(objReportH)
        m_currentPageIndex = 0
        Print()

    End Sub
#End Region

#Region "Bank Artha Graha"
    Private Sub PrintGiroArthaGraha()
        Dim objReportH As Microsoft.Reporting.WinForms.LocalReport = New Microsoft.Reporting.WinForms.LocalReport
        Dim parRptTglBilyet As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("tglbilyet", Me.TglBilyet)
        Dim parRptRekananName As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("rekananname", Me.RekananName)
        Dim parRptAmountIDR As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("amountidr", Me.AmountIDR)
        Dim parRptAmountIDRTerbilang As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("amountidrterbilang", Me.AmountIDRTerbilang)

        Dim parRptAccNumber As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("accnumber", Me.AccNumber)
        Dim parRptBankName As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("bankname", Me.BankName)
        Dim parRptTglEfektif As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("tglefektif", Me.TglEfektif)

        objReportH.ReportEmbeddedResource = My.Application.GetType.Namespace.ToString.Substring(0, Len(My.Application.GetType.Namespace.ToString) - 3) _
                                            + "." + "rptGiroArthaGraha.rdlc" '"ACT_FINANCE.rptGiroCimbNiaga.rdlc"
        objReportH.EnableExternalImages = True
        objReportH.SetParameters((New Microsoft.Reporting.WinForms.ReportParameter() {parRptTglBilyet, parRptRekananName, parRptAmountIDR, parRptAmountIDRTerbilang, _
                                                                                      parRptAccNumber, parRptBankName, parRptTglEfektif}))
        Export(objReportH)
        m_currentPageIndex = 0
        Print()
    End Sub

    Private Sub PrintCekArthaGraha()
        Dim objReportH As Microsoft.Reporting.WinForms.LocalReport = New Microsoft.Reporting.WinForms.LocalReport
        Dim parRptTglBilyet As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("tglbilyet", Me.TglBilyet)
        Dim parRptRekananName As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("rekananname", Me.RekananName)
        Dim parRptAmountIDR As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("amountidr", Me.AmountIDR)
        Dim parRptAmountIDRTerbilang As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("amountidrterbilang", Me.AmountIDRTerbilang)
        Dim parRptTglEfektif As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("tglefektif", Me.TglEfektif)

        objReportH.ReportEmbeddedResource = My.Application.GetType.Namespace.ToString.Substring(0, Len(My.Application.GetType.Namespace.ToString) - 3) _
                                            + "." + "rptCekArthaGraha.rdlc" '"ACT_FINANCE.rptCekCimbNiaga.rdlc"
        objReportH.EnableExternalImages = True
        objReportH.SetParameters((New Microsoft.Reporting.WinForms.ReportParameter() {parRptTglBilyet, parRptRekananName, parRptAmountIDR, parRptAmountIDRTerbilang, _
                                                                                      parRptTglEfektif}))
        Export(objReportH)
        m_currentPageIndex = 0
        Print()

    End Sub
#End Region

#Region "Bank Mandiri"
    Private Sub PrintGiroMandiri()
        Dim objReportH As Microsoft.Reporting.WinForms.LocalReport = New Microsoft.Reporting.WinForms.LocalReport

        Dim parRptTglBilyet As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("tglbilyet", Me.TglBilyet)
        Dim parRptRekananName As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("rekananname", Me.RekananName)
        Dim parRptAmountIDR As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("amountidr", Me.AmountIDR)
        Dim parRptAmountIDRTerbilang As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("amountidrterbilang", Me.AmountIDRTerbilang)

        Dim parRptAccNumber As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("accnumber", Me.AccNumber)
        Dim parRptBankName As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("bankname", Me.BankName)
        Dim parRptTglEfektif As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("tglefektif", Me.TglEfektif)

        objReportH.ReportEmbeddedResource = My.Application.GetType.Namespace.ToString.Substring(0, Len(My.Application.GetType.Namespace.ToString) - 3) _
                                            + "." + "rptGiroMandiri.rdlc" '"ACT_FINANCE.rptGiroCimbNiaga.rdlc"
        objReportH.EnableExternalImages = True
        objReportH.SetParameters((New Microsoft.Reporting.WinForms.ReportParameter() {parRptTglBilyet, parRptRekananName, parRptAmountIDR, parRptAmountIDRTerbilang, _
                                                                                      parRptAccNumber, parRptBankName, parRptTglEfektif}))
        Export(objReportH)
        m_currentPageIndex = 0
        Print()
    End Sub

    Private Sub PrintCekMandiri()
        Dim objReportH As Microsoft.Reporting.WinForms.LocalReport = New Microsoft.Reporting.WinForms.LocalReport
        Dim parRptTglBilyet As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("tglbilyet", Me.TglBilyet)
        Dim parRptRekananName As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("rekananname", Me.RekananName)
        Dim parRptAmountIDR As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("amountidr", Me.AmountIDR)
        Dim parRptAmountIDRTerbilang As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("amountidrterbilang", Me.AmountIDRTerbilang)
        Dim parRptTglEfektif As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("tglefektif", Me.TglEfektif)

        objReportH.ReportEmbeddedResource = My.Application.GetType.Namespace.ToString.Substring(0, Len(My.Application.GetType.Namespace.ToString) - 3) _
                                            + "." + "rptCekMandiri.rdlc" '"ACT_FINANCE.rptCekCimbNiaga.rdlc"
        objReportH.EnableExternalImages = True
        objReportH.SetParameters((New Microsoft.Reporting.WinForms.ReportParameter() {parRptTglBilyet, parRptRekananName, parRptAmountIDR, parRptAmountIDRTerbilang, parRptTglEfektif}))
        Export(objReportH)
        m_currentPageIndex = 0
        Print()
    End Sub
#End Region

#Region "Bank BCA"
    Private Sub PrintGiroBCA()
        Dim objReportH As Microsoft.Reporting.WinForms.LocalReport = New Microsoft.Reporting.WinForms.LocalReport
        Dim parRptTglBilyet As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("tglbilyet", Me.TglBilyet)
        Dim parRptRekananName As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("rekananname", Me.RekananName)
        Dim parRptAmountIDR As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("amountidr", Me.AmountIDR)
        Dim parRptAmountIDRTerbilang As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("amountidrterbilang", Me.AmountIDRTerbilang)

        Dim parRptAccNumber As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("accnumber", Me.AccNumber)
        Dim parRptBankName As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("bankname", Me.BankName)
        Dim parRptTglEfektif As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("tglefektif", Me.TglEfektif)

        objReportH.ReportEmbeddedResource = My.Application.GetType.Namespace.ToString.Substring(0, Len(My.Application.GetType.Namespace.ToString) - 3) _
                                            + "." + "rptGiroBCA.rdlc" '"ACT_FINANCE.rptGiroCimbNiaga.rdlc"
        objReportH.EnableExternalImages = True
        objReportH.SetParameters((New Microsoft.Reporting.WinForms.ReportParameter() {parRptTglBilyet, parRptRekananName, parRptAmountIDR, parRptAmountIDRTerbilang, _
                                                                                      parRptAccNumber, parRptBankName, parRptTglEfektif}))
        Export(objReportH)
        m_currentPageIndex = 0
        Print()
    End Sub

    Private Sub PrintCekBCA()
        Dim objReportH As Microsoft.Reporting.WinForms.LocalReport = New Microsoft.Reporting.WinForms.LocalReport
        Dim parRptTglBilyet As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("tglbilyet", Me.TglBilyet)
        Dim parRptRekananName As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("rekananname", Me.RekananName)
        Dim parRptAmountIDR As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("amountidr", Me.AmountIDR)
        Dim parRptAmountIDRTerbilang As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("amountidrterbilang", Me.AmountIDRTerbilang)
        Dim parRptTglEfektif As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("tglefektif", Me.TglEfektif)

        objReportH.ReportEmbeddedResource = My.Application.GetType.Namespace.ToString.Substring(0, Len(My.Application.GetType.Namespace.ToString) - 3) _
                                            + "." + "rptCekBCA.rdlc" '"ACT_FINANCE.rptCekCimbNiaga.rdlc"
        objReportH.EnableExternalImages = True
        objReportH.SetParameters((New Microsoft.Reporting.WinForms.ReportParameter() {parRptTglBilyet, parRptRekananName, parRptAmountIDR, parRptAmountIDRTerbilang, _
                                                                                      parRptTglEfektif}))
        Export(objReportH)
        m_currentPageIndex = 0
        Print()

    End Sub
#End Region

End Class
