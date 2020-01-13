Imports System.Data.OleDb
Namespace DataSource
    Public Class clsRptJurnalST_Detil

        Private m_jurnal_id As String
        Private m_no As Integer
        Private m_line As Integer
        Private m_account_id As String
        Private m_account_name As String
        Private m_idr As Decimal
        Private m_rate As Decimal
        Private m_curr As String
        Private m_foreign As Decimal
        Private m_descriptionDetil As String
        Private m_detil_dk As String
        Private m_region As String
        Private m_branch As String
        Private m_StrukturUnit As String
        Private mChannel_id As String
        Private mChannel_namereport As String
        Private mChannel_address As String
        Private dsn As String
        Private mdate_create As Date
        Private mtype As String
        Private mbilyet_reqs As String
        Private mbank_acc As String
        Private mbudget_name As String
        Public Property budget_name() As String
            Get
                Return mbudget_name
            End Get
            Set(ByVal value As String)
                mbudget_name = value

            End Set
        End Property
        Public Property bank_acc() As String
            Get
                Return mbank_acc
            End Get
            Set(ByVal value As String)
                mbank_acc = value

            End Set
        End Property
        Public Property bilyet_reqs() As String
            Get
                Return mbilyet_reqs
            End Get
            Set(ByVal value As String)
                mbilyet_reqs = value

            End Set
        End Property
        Public Property type() As String
            Get
                Return mtype
            End Get
            Set(ByVal value As String)
                mtype = value

            End Set
        End Property
        Public Property date_create() As Date
            Get
                Return mdate_create
            End Get
            Set(ByVal value As Date)
                mdate_create = value

            End Set
        End Property
        Public Property channel_id() As String
            Get
                Return mChannel_id
            End Get
            Set(ByVal value As String)
                mChannel_id = value
                setChannelDesc()
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
            Me.dsn = DSN
        End Sub

        Private Sub setChannelDesc()
            If mChannel_id <> "" Then
                Dim tblChannel As DataTable
                Dim parCriteria As OleDbParameter

                Try
                    parCriteria = New OleDbParameter("@Criteria", OleDbType.VarChar, 1024)
                    parCriteria.Value = String.Format(" channel_id = '{0}' ", mChannel_id)
                    tblChannel = clsUtil.GetDataTable("ms_MstChannel_Select", Me.dsn, parCriteria)
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


        Public Property jurnal_id() As String
            Get
                Return m_jurnal_id
            End Get
            Set(ByVal value As String)
                m_jurnal_id = value
            End Set
        End Property

        Public Property no() As Integer
            Get
                Return m_no
            End Get
            Set(ByVal value As Integer)
                m_no = value
            End Set
        End Property

        Public Property line() As Integer
            Get
                Return m_line
            End Get
            Set(ByVal value As Integer)
                m_line = value
            End Set
        End Property

        Public Property account_id() As String
            Get
                Return m_account_id
            End Get
            Set(ByVal value As String)
                m_account_id = value
            End Set
        End Property

        Public Property account_name() As String
            Get
                Return m_account_name
            End Get
            Set(ByVal value As String)
                m_account_name = value
            End Set
        End Property

        Public Property idr() As Decimal
            Get
                Return m_idr
            End Get
            Set(ByVal value As Decimal)
                m_idr = value
            End Set
        End Property

        Public Property curr() As String
            Get
                Return m_curr
            End Get
            Set(ByVal value As String)
                m_curr = value
            End Set
        End Property

        Public Property rate() As Decimal
            Get
                Return m_rate
            End Get
            Set(ByVal value As Decimal)
                m_rate = value
            End Set
        End Property

        Public Property foreign() As Decimal
            Get
                Return m_foreign
            End Get
            Set(ByVal value As Decimal)
                m_foreign = value
            End Set
        End Property

        Public Property DescriptionDetil() As String
            Get
                Return m_descriptionDetil
            End Get
            Set(ByVal value As String)
                m_descriptionDetil = value
            End Set
        End Property

        Public Property Detil_dk() As String
            Get
                Return m_detil_dk
            End Get
            Set(ByVal value As String)
                m_detil_dk = value
            End Set
        End Property

        Public Property Region() As String
            Get
                Return m_region
            End Get
            Set(ByVal value As String)
                m_region = value
            End Set
        End Property

        Public Property Branch() As String
            Get
                Return m_branch
            End Get
            Set(ByVal value As String)
                m_branch = value
            End Set
        End Property

        Public Property StrukturUnit() As String
            Get
                Return m_StrukturUnit
            End Get
            Set(ByVal value As String)
                m_StrukturUnit = value
            End Set
        End Property

    End Class

End Namespace