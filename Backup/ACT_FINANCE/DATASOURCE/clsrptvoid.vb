Imports System.Data.OleDb
Namespace DataSource
    Public Class clsRptVoid
        Private DSN As String
        Private mvoid_id As String
        Private mcirculation_id As String
        Private mCirculation_ref As String
        Private mrekanan_name As String
        Private mdescr As String
        Private mamount_sum As Decimal
        Private mbilyet As String
        Private mamount As Decimal
        Private mcreatedate As Date
        Private mChannel_id As String
        Private mChannel_namereport As String
        Private mChannel_address As String
        Public Property void_id() As String
            Get
                Return mvoid_id
            End Get
            Set(ByVal value As String)
                mvoid_id = value
            End Set
        End Property

        Public Property circulation_id() As String
            Get
                Return mCirculation_id
            End Get
            Set(ByVal value As String)
                mCirculation_id = value
            End Set
        End Property

        Public Property circulation_ref() As String
            Get
                Return mCirculation_ref
            End Get
            Set(ByVal value As String)
                mCirculation_ref = value
            End Set
        End Property

        Public Property rekanan_name() As String
            Get
                Return mrekanan_name
            End Get
            Set(ByVal value As String)
                mrekanan_name = value
            End Set
        End Property

        Public Property descr() As String
            Get
                Return mdescr
            End Get
            Set(ByVal value As String)
                mdescr = value
            End Set
        End Property

        Public Property amount_sum() As Decimal
            Get
                Return mamount_sum
            End Get
            Set(ByVal value As Decimal)
                mamount_sum = value
            End Set
        End Property

        Public Property bilyet() As String
            Get
                Return mbilyet
            End Get
            Set(ByVal value As String)
                mbilyet = value
            End Set
        End Property

        Public Property amount() As Decimal
            Get
                Return mamount
            End Get
            Set(ByVal value As Decimal)
                mamount = value
            End Set
        End Property
        Public Property createdate() As Date
            Get
                Return mcreatedate
            End Get
            Set(ByVal value As Date)
                mcreatedate = value
            End Set
        End Property

        Public Property channel_id() As String
            Get
                Return mChannel_id
            End Get
            Set(ByVal value As String)
                mChannel_id = value
                Me.setChannelDesc()
            End Set
        End Property

        Public Property channel_namereport() As String
            Get
                Return mChannel_namereport
            End Get
            Set(ByVal value As String)
                mChannel_namereport = value
            End Set
        End Property

        Public Property channel_address() As String
            Get
                Return mChannel_address
            End Get
            Set(ByVal value As String)
                mChannel_address = value
            End Set
        End Property


        Public Sub New(ByVal DSN As String)
            Me.DSN = DSN
        End Sub

        Private Sub setChannelDesc()
            If mChannel_id <> "" Then
                Dim tblChannel As DataTable
                Dim parCriteria As OleDbParameter

                Try
                    parCriteria = New OleDbParameter("@Criteria", OleDbType.VarChar, 1024)
                    parCriteria.Value = String.Format(" channel_id = '{0}' ", mChannel_id)
                    tblChannel = clsUtil.GetDataTable("ms_MstChannel_Select", Me.DSN, parCriteria)
                    If tblChannel.Rows.Count > 0 Then
                        Me.mChannel_namereport = Trim(tblChannel.Rows(0)("channel_namereport").ToString)
                        Me.mChannel_address = Trim(tblChannel.Rows(0)("channel_address").ToString)
                    End If
                Catch ex As Exception
                    MsgBox("error on retrieving channel desc.")
                Finally
                    parCriteria = Nothing
                    tblChannel = Nothing
                End Try
            End If
        End Sub
    End Class
End Namespace