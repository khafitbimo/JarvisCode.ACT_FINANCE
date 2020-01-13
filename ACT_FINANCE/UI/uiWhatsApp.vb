Imports System
Imports System.Net
Imports System.Net.Http
Imports System.IO

Public Class uiWhatsApp
    Private yourId As String = "vtf05aAONEau0d1iVLQXm2FyYm95MDhfYXRfZ21haWxfZG90X2NvbQ=="
    Private yourMobile As String = "+6281281316887"
    Private yourMessage As String = "Ari test kirim whatsapp lewat niceapi dot net"

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Try
            Dim url As String = "https://NiceApi.net/API"
            Dim request As System.Net.HttpWebRequest = CType(System.Net.WebRequest.Create(url), System.Net.HttpWebRequest)
            request.Method = "POST"
            request.ContentType = "application/x-www-form-urlencoded"
            request.Headers.Add("X-APIId", yourId)
            request.Headers.Add("X-APIMobile", yourMobile)
            Using streamOut = New StreamWriter(request.GetRequestStream())
                streamOut.Write(yourMessage)
            End Using
            Using streamIn = New StreamReader(request.GetResponse().GetResponseStream())
                MsgBox(streamIn.ReadToEnd())
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class
