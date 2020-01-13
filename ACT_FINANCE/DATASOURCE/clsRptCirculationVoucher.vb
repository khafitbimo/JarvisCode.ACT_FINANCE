Imports System.Data.OleDb
Namespace DataSource
    Public Class clsRptCirculationVoucher
        Private DSN As String
        Private mCirculation_id As String
        Private mCirculation_senddt As DateTime
        Private mCirculation_sendto As Decimal
        Private mCirculation_foreign As Decimal
        Private mCirculation_amount As Decimal
        Private mCirculation_descr As String
        Private mJurnaltype_id As String
        Private mChannel_id As String
        Private mChannel_namereport As String
        Private mChannel_address As String
        Private mCirculation_appuser As Byte
        Private mCirculation_appuserby As String
        Private mCirculation_appuserdt As DateTime
        Private mCirculation_status As String
        Private mCirculation_totalrevisi As Int32
        Private mEntry_by As String
        Private mEntry_dt As DateTime
        Private mModify_by As String
        Private mModify_dt As DateTime

        Public Property circulation_id() As String
            Get
                Return mCirculation_id
            End Get
            Set(ByVal value As String)
                mCirculation_id = value
            End Set
        End Property

        Public Property circulation_senddt() As DateTime
            Get
                Return mCirculation_senddt
            End Get
            Set(ByVal value As DateTime)
                mCirculation_senddt = value
            End Set
        End Property

        Public Property circulation_sendto() As Decimal
            Get
                Return mCirculation_sendto
            End Get
            Set(ByVal value As Decimal)
                mCirculation_sendto = value
            End Set
        End Property

        Public Property circulation_foreign() As Decimal
            Get
                Return mCirculation_foreign
            End Get
            Set(ByVal value As Decimal)
                mCirculation_foreign = value
            End Set
        End Property

        Public Property circulation_amount() As Decimal
            Get
                Return mCirculation_amount
            End Get
            Set(ByVal value As Decimal)
                mCirculation_amount = value
            End Set
        End Property

        Public Property circulation_descr() As String
            Get
                Return mCirculation_descr
            End Get
            Set(ByVal value As String)
                mCirculation_descr = value
            End Set
        End Property

        Public Property jurnaltype_id() As String
            Get
                Return mJurnaltype_id
            End Get
            Set(ByVal value As String)
                mJurnaltype_id = value
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


        Public Property circulation_appuser() As Byte
            Get
                Return mCirculation_appuser
            End Get
            Set(ByVal value As Byte)
                mCirculation_appuser = value
            End Set
        End Property

        Public Property circulation_appuserby() As String
            Get
                Return mCirculation_appuserby
            End Get
            Set(ByVal value As String)
                mCirculation_appuserby = value
            End Set
        End Property

        Public Property circulation_appuserdt() As DateTime
            Get
                Return mCirculation_appuserdt
            End Get
            Set(ByVal value As DateTime)
                mCirculation_appuserdt = value
            End Set
        End Property

        Public Property circulation_status() As String
            Get
                Return mCirculation_status
            End Get
            Set(ByVal value As String)
                mCirculation_status = value
            End Set
        End Property

        Public Property circulation_totalrevisi() As Int32
            Get
                Return mCirculation_totalrevisi
            End Get
            Set(ByVal value As Int32)
                mCirculation_totalrevisi = value
            End Set
        End Property

        Public Property entry_by() As String
            Get
                Return mEntry_by
            End Get
            Set(ByVal value As String)
                mEntry_by = value
            End Set
        End Property

        Public Property entry_dt() As DateTime
            Get
                Return mEntry_dt
            End Get
            Set(ByVal value As DateTime)
                mEntry_dt = value
            End Set
        End Property

        Public Property modify_by() As String
            Get
                Return mModify_by
            End Get
            Set(ByVal value As String)
                mModify_by = value
            End Set
        End Property

        Public Property modify_dt() As DateTime
            Get
                Return mModify_dt
            End Get
            Set(ByVal value As DateTime)
                mModify_dt = value
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