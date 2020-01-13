Imports System.Data

Public Class clsAddressConfig : Implements IDisposable

    Private _configDataset As System.Data.DataSet

    Private _dlladdress As String
    Private _sptaddress As String

#Region " Constructor "
    Sub New(ByVal ConfigDataset As Data.DataSet)
        Me._configDataset = ConfigDataset
        Me.Read()
    End Sub
#End Region

#Region " Property "
    Public Property DllAddress() As String
        Get
            Return Me._dlladdress
        End Get
        Set(ByVal value As String)
            Me._dlladdress = value
        End Set
    End Property

    Public Property SptAddress() As String
        Get
            Return Me._sptaddress
        End Get
        Set(ByVal value As String)
            Me._sptaddress = value
        End Set
    End Property
#End Region

    Public Sub Read()
        Try
            Dim rows() As DataRow
            Dim row As DataRow

            rows = Me._configDataset.Tables("Address").Select()

            If rows.Length() > 0 Then
                row = rows(0)

                Me._dlladdress = row.Item("DllAddress").ToString()
                Me._sptaddress = row.Item("SptAddress").ToString()
            Else
                Me._dlladdress = ""
                Me._sptaddress = ""
            End If

        Catch ex As Exception
            Me._dlladdress = ""
            Me._sptaddress = ""
        End Try
    End Sub

    Private disposedValue As Boolean = False        ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free unmanaged resources when explicitly called
            End If

            ' TODO: free shared unmanaged resources
        End If
        Me.disposedValue = True
    End Sub

#Region " IDisposable Support "
    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region

End Class
