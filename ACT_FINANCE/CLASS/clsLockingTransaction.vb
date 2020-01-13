Public Class clsLockingTransaction
    Private Const parentName As String = "frmProgram"
    Private _ChannelID As String
    Private _ID As String
    Private _Username As String
    Private _tabMain As FlatTabControl.FlatTabControl
    Private _owned As UserControl
    Private _parent As Form

    Enum LockStatus
        Open
        Locked
        LockedByMe
    End Enum

#Region " Constructor "
    Sub New()

    End Sub
    Sub New(ByVal channel_id As String,
            ByVal username As String,
            ByVal owned As UserControl,
            ByVal tabMain As FlatTabControl.FlatTabControl)
        Me._ChannelID = channel_id
        Me._Username = username
        Me._owned = owned
        Me._tabMain = tabMain

        AddHandler Me._owned.ParentChanged, AddressOf Me.parent_Changed
    End Sub

#End Region

#Region " Properties "
    Public Property Status As LockStatus
    Public Property LockedBy As String
    Public Property LockedDt As Date
#End Region

    Private Sub parent_Changed(ByVal sender As Object, ByVal e As EventArgs)
        If Me._owned.Parent IsNot Nothing Then
            If Me._owned.Parent.Name = parentName Then
                Me._parent = CType(Me._owned.Parent, Form)

                Dim objParent As Object = CType(Me._parent, Object)

                objParent.CreateLockTransaction(Me._ChannelID, Me._Username, Me._owned, Me._tabMain, Me)
            Else
                Me._parent = Nothing
            End If
        End If
    End Sub

    Public Sub TryLocking(ByVal ID As String)
        If Me._parent IsNot Nothing Then
            Me._ID = ID

            Dim objParent As Object = CType(Me._parent, Object)

            objParent.TryLocking(Me._ID)
        End If
    End Sub

    Public Sub Clear()
        If Me._parent IsNot Nothing Then
            Dim objParent As Object = CType(Me._parent, Object)

            objParent.Clear()
        End If
    End Sub
End Class
