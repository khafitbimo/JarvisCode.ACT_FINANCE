Partial Class DataClassesFrmDataContext
    Private cookie() As Byte

    Public Sub OpenConnectionWithRole()
        MyBase.Connection.Open()

        clsApplicationRole.SetAppRoles(MyBase.Connection, Me.cookie)
    End Sub

    Public Sub CloseConnectionWithRole()
        clsApplicationRole.UnsetAppRoles(MyBase.Connection, Me.cookie)

        MyBase.Connection.Close()
    End Sub
End Class

