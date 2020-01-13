
Imports System.Data.OleDb
Namespace DataSource
    Public Class ClsRptAdvanceHeader
        Private DSN As String

        Private mRequestDate As DateTime
        Private mRequestBy As String
        Private mDepartment As String
        Private mPayment_to As String
        Private mPayment_Addr As String

        Private mRef_No As String
        Private mProgram As String

        Private mCurrency_id As String
        Private mCurrency_name As String
        Private mCurrency_rate As Decimal

        Private mBudget_id As Decimal
        Private mBudget_Name As String

        Private mChannel_id As String
        Private mChannel_namereport As String
        Private mChannel_address As String
        Private mDomain_name As String

        Private mChannel_telp1 As String
        Private mChannel_fax As String

        Private mBudget_amount As Decimal
        Private mBudget_amountdetil As Decimal
        Private mBalance As Decimal
        Private mAdv_req As Decimal
        Private mTotal As String
        Private mEpsstart As String
        Private mEpsend As String
        Private mRekanan_id As String
        Private mPayment_type As String
        Private mPayment_date As Date
        Private mAdvance_Descr As String


       

        Public Property Advance_Descr() As String
            Get
                Return mAdvance_Descr
            End Get
            Set(ByVal value As String)
                mAdvance_Descr = value
            End Set
        End Property

        Public Property Payment_type() As String
            Get
                Return mPayment_type
            End Get
            Set(ByVal value As String)
                mPayment_type = value
            End Set
        End Property
        Public Property Payment_date() As Date
            Get
                Return mPayment_date
            End Get
            Set(ByVal value As Date)
                mPayment_date = value
            End Set
        End Property

        Public Property rekanan_id() As String
            Get
                Return mRekanan_id
            End Get
            Set(ByVal value As String)
                mRekanan_id = value
            End Set
        End Property
        Public Property request_date() As DateTime
            Get
                Return mRequestDate
            End Get
            Set(ByVal value As DateTime)
                mRequestDate = value
            End Set
        End Property

        Public Property request_by() As String
            Get
                Return mRequestBy
            End Get
            Set(ByVal value As String)
                mRequestBy = value
            End Set
        End Property
        Public Property Department() As String
            Get
                Return mDepartment
            End Get
            Set(ByVal value As String)
                mDepartment = value
            End Set
        End Property
        Public Property payment_to() As String
            Get
                Return mPayment_to
            End Get
            Set(ByVal value As String)
                mPayment_to = value
            End Set
        End Property

        Public Property payment_address() As String
            Get
                Return mPayment_Addr
            End Get
            Set(ByVal value As String)
                mPayment_Addr = value
            End Set
        End Property

        Public Property ref_no() As String
            Get
                Return mRef_No
            End Get
            Set(ByVal value As String)
                mRef_No = value
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

        Public Property Program() As String
            Get
                Return mProgram
            End Get
            Set(ByVal value As String)
                mProgram = value
            End Set
        End Property

        Public Property Budget_id() As Decimal
            Get
                Return mBudget_id
            End Get
            Set(ByVal value As Decimal)
                mBudget_id = value
            End Set
        End Property

        Public Property Budget_name() As String
            Get
                Return mBudget_Name
            End Get
            Set(ByVal value As String)
                mBudget_Name = value
            End Set
        End Property
        Public Property budget_amount() As Decimal
            Get
                Return mBudget_amount
            End Get
            Set(ByVal value As Decimal)
                mBudget_amount = value
            End Set
        End Property
       
        Public Property balance() As Decimal
            Get
                Return mBalance
            End Get
            Set(ByVal value As Decimal)
                mBalance = value
            End Set
        End Property

        Public Property adv_req() As Decimal
            Get
                Return mAdv_req
            End Get
            Set(ByVal value As Decimal)
                mAdv_req = value
            End Set
        End Property

        Public Property total() As String
            Get
                Return mTotal
            End Get
            Set(ByVal value As String)
                mTotal = value
            End Set
        End Property
  

        Public Property currency_id() As String
            Get
                Return mCurrency_id
            End Get
            Set(ByVal value As String)
                mCurrency_id = value
                Me.setCurrencyName()
            End Set
        End Property

        Public Property currency_name() As String
            Get
                Return mCurrency_name
            End Get
            Set(ByVal value As String)
                mCurrency_name = value
            End Set
        End Property

        Public Property currency_rate() As Decimal
            Get
                Return mCurrency_rate
            End Get
            Set(ByVal value As Decimal)
                mCurrency_rate = value
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

        Public Property domain_name() As String
            Get
                Return mDomain_name
            End Get
            Set(ByVal value As String)
                mDomain_name = value
            End Set
        End Property

        Public Property channel_telp1() As String
            Get
                Return mChannel_telp1
            End Get
            Set(ByVal value As String)
                mChannel_telp1 = value
            End Set
        End Property

        Public Property channel_fax() As String
            Get
                Return mChannel_fax
            End Get
            Set(ByVal value As String)
                mChannel_fax = value
            End Set
        End Property

        Public Property eps_start() As String
            Get
                Return mEpsstart
            End Get
            Set(ByVal value As String)
                mEpsstart = value
            End Set
        End Property
        Public Property eps_end() As String
            Get
                Return mEpsend
            End Get
            Set(ByVal value As String)
                mEpsend = value
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
                        Me.mDomain_name = Trim(tblChannel.Rows(0)("channel_domainname").ToString)

                        Me.mChannel_telp1 = Trim(tblChannel.Rows(0)("channel_telp1").ToString)
                        Me.mChannel_fax = Trim(tblChannel.Rows(0)("channel_fax").ToString)
                        '---------------tambahan buat insosys baru 2012-- 19 April 2012---------------
                        Me.mDomain_name = Me.mDomain_name.Replace("\", "/")
                        Me.mDomain_name = "file:///" & Me.mDomain_name
                        '---------------------------------------------------------------

                    End If

                Catch ex As Exception
                    MsgBox("error on retrieving channel desc.")
                Finally
                    parCriteria = Nothing
                    tblChannel = Nothing
                End Try
            End If
        End Sub

       

        Private Sub setCurrencyName()
            If mCurrency_id <> "" Then
                Dim tblCurrency As DataTable
                Dim parCriteria As OleDbParameter

                Try
                    parCriteria = New OleDbParameter("@Criteria", OleDbType.VarChar, 1024)
                    parCriteria.Value = String.Format(" currency_id = '{0}' ", mCurrency_id)
                    tblCurrency = clsUtil.GetDataTable("ms_MstCurrency_Select", Me.DSN, parCriteria)
                    If tblCurrency.Rows.Count > 0 Then
                        Me.mCurrency_name = Trim(tblCurrency.Rows(0)("currency_shortname").ToString)
                    End If

                Catch ex As Exception
                    MsgBox("error on retrieving Currency")
                Finally
                    parCriteria = Nothing
                    tblCurrency = Nothing
                End Try
            End If
        End Sub
    End Class
End Namespace

