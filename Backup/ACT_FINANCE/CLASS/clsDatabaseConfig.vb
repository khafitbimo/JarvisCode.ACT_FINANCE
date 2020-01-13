Imports System.Data
Imports System.Security.Cryptography

Public Class clsDatabaseConfig : Implements IDisposable

    Private _instance As String
    Private _serverName As String
    Private _username As String
    Private _password As String
    Private _databasename As String
    Private _dsnTemp As String = "User ID={0}; Password={1}; Data Source=""{2}""; Initial Catalog={3}; Tag with column collation when possible=False; Use Procedure for Prepare=1; Auto Translate=True; Persist Security Info=True; Provider=""SQLOLEDB.1""; Use Encryption for Data=False; Packet Size=4096"
    Private _configDataset As Data.DataSet

#Region " Constructor "

    Sub New(ByVal Instance As String, ByVal ConfigurasiDataset As Data.DataSet)
        Me._instance = Instance
        Me._configDataset = ConfigurasiDataset

        Me.Read()
    End Sub

#End Region

#Region " Property "

    Public Property ServerName() As String
        Get
            Return Me._serverName
        End Get
        Set(ByVal value As String)
            Me._serverName = value
        End Set
    End Property

    Public Property UserName() As String
        Get
            Return Me._username
        End Get
        Set(ByVal value As String)
            Me._username = value
        End Set
    End Property

    Public Property Password() As String
        Get
            Return Me._password
        End Get
        Set(ByVal value As String)
            Me._password = value
        End Set
    End Property

    Public Property DatabaseName() As String
        Get
            Return Me._databasename
        End Get
        Set(ByVal value As String)
            Me._databasename = value
        End Set
    End Property

    Public ReadOnly Property DSN() As String
        Get
            Return String.Format(Me._dsnTemp, Me.UserName, Me.Password, Me.ServerName, Me.DatabaseName)
        End Get
    End Property

#End Region

#Region " Method "

    Public Sub TestConnection()
        Dim dbConn As New OleDb.OleDbConnection(Me.DSN)

        Try
            dbConn.Open()
        Catch ex As Exception
            Throw New Exception("Cannot Establishing Connection to " & Me.ServerName & " using " & Me.DatabaseName & vbCrLf & ex.Message)
        Finally
            dbConn.Close()
        End Try
    End Sub

    Public Sub Read()
        Try
            Dim rows() As DataRow
            Dim row As DataRow

            rows = Me._configDataset.Tables("DbServer").Select(String.Format("Inst = '{0}'", Me._instance))

            If rows.Length() > 0 Then
                row = rows(0)

                Me.ServerName = row.Item("ServerName").ToString()
                Me.UserName = row.Item("UserName").ToString()
                Me.Password = row.Item("Password").ToString()
                Me.DatabaseName = row.Item("DatabaseName").ToString()
            Else
                Me.ServerName = ""
                Me.UserName = ""
                Me.Password = ""
                Me.DatabaseName = ""
            End If

        Catch ex As Exception
            Me.ServerName = ""
            Me.UserName = ""
            Me.Password = ""
            Me.DatabaseName = ""
        End Try
    End Sub

#End Region

#Region " IDisposable Support "
    Private disposedValue As Boolean = False

    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
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
