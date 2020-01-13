Imports System.Net.IPAddress
Imports System.Net.NetworkInformation.PingReply
Imports System.Net.Mail

Public Class clsKirimEmail
    Private mailerNET As System.Net.Mail.SmtpClient
    Private mDSN As String

    Private Shared myHost As String = "mailserver.netmedia.co.id"
    Private Shared smtp As New Net.Mail.SmtpClient

#Region " Constructor "
    Public Sub New(ByVal dsn As String)
        Me.mDSN = dsn
    End Sub
#End Region

    Public Shared Sub Send(ByVal MyMail As Net.Mail.MailMessage, ByVal eMailFrom As String, ByVal eMailPassword As String)
        Dim cred As New Net.NetworkCredential(eMailFrom, eMailPassword)
        Dim credCache As New Net.CredentialCache

        credCache.Add(myHost, "35", "Basic", cred)
        credCache.Add(myHost, "45", "NTLM", cred)

        smtp.Host = myHost

        MyMail.DeliveryNotificationOptions = Net.Mail.DeliveryNotificationOptions.None

        smtp.EnableSsl = True
        smtp.UseDefaultCredentials = False
        smtp.Credentials = credCache.GetCredential(myHost, "45", "NTLM")

        Try
            smtp.Send(MyMail)
        Catch exfailed As SmtpFailedRecipientsException
            Throw exfailed
        End Try
    End Sub

    Public Function SendEmail_SQL(ByVal Email_To As String, ByVal Email_CC As String, Email_BCC As String, ByVal subject As String, ByVal body As String) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.mDSN)
        Dim cookie As Byte() = Nothing
        Dim reason As String = ""

        Try
            dbConn.Open()
            clsApplicationRole.SetAppRole(dbConn, cookie)
            Dim oCm As New OleDb.OleDbCommand("to_SendEmail", dbConn)
            oCm.CommandType = CommandType.StoredProcedure
            oCm.Parameters.Add("@recipients", System.Data.OleDb.OleDbType.VarWChar, 5000).Value = Email_To
            oCm.Parameters.Add("@copy_recipients", System.Data.OleDb.OleDbType.VarWChar, 5000).Value = Email_CC
            oCm.Parameters.Add("@blind_copy_recipients", System.Data.OleDb.OleDbType.VarWChar, 5000).Value = Email_BCC
            oCm.Parameters.Add("@subject", System.Data.OleDb.OleDbType.VarWChar, 5000).Value = subject
            oCm.Parameters.Add("@body", System.Data.OleDb.OleDbType.VarWChar, 5000).Value = body
            oCm.Parameters.Add("@importance", System.Data.OleDb.OleDbType.VarWChar, 5000).Value = ""

            oCm.ExecuteNonQuery()
            oCm.Dispose()

        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            clsApplicationRole.UnsetAppRole(dbConn, cookie)
            dbConn.Close()
        End Try

        Return True
    End Function
End Class
