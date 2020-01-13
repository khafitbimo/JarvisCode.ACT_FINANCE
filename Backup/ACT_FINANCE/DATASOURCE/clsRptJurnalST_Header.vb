Imports System.Data.OleDb
Namespace DataSource

    Public Class clsRptJurnalST_Header
        Private m_jurnal_id As String
        Private m_bank As String
        Private m_amountForeign As Decimal
        Private m_amountIDR As Decimal
        Private m_Bookdate As Date
        Private m_paidto As String
        Private m_acc_id As String
        Private m_acc_name As String
        Private m_cek_no As String
        Private m_descr As String
        Private m_descrBilyet As String
        Private m_terbilang As String
        Private m_createby As String
        Private m_createdate As Date
        Private m_curr As String
        Private m_paymenttype_id As String
        Private m_rate As Decimal
        Private m_JumlahIDR As Decimal
        Private m_JumlahForeign As Decimal
        Private m_PeriodeID As String
        Private m_Source As String
        Private m_ReceiveBy As String
        Private m_ReceiveDate As Date
        Private m_StrPA As String

        Private m_rekanan_id As String
        Private m_rekanan_name As String
        Private DSN As String

        Private mChannel_id As String
        Private mChannel_namereport As String
        Private mChannel_address As String
        Private mbudget_name As String
        Private mbudget_id As String
        Public Property budget_name() As String
            Get
                Return mbudget_name
            End Get
            Set(ByVal value As String)
                mbudget_name = value

            End Set
        End Property
        Public Property budget_id() As String
            Get
                Return mbudget_id
            End Get
            Set(ByVal value As String)
                mbudget_id = value

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

        Public Property StrPA() As String
            Get
                Return m_StrPA
            End Get
            Set(ByVal value As String)
                m_StrPA = value
            End Set
        End Property
        Public Property jurnal_id() As String
            Get
                Return m_jurnal_id
            End Get
            Set(ByVal value As String)
                m_jurnal_id = value
            End Set
        End Property
        Public Property bank() As String
            Get
                Return m_bank
            End Get
            Set(ByVal value As String)
                m_bank = value
            End Set
        End Property

        Public Property amountForeign() As Decimal
            Get
                Return m_amountForeign
            End Get
            Set(ByVal value As Decimal)
                m_amountForeign = value
            End Set
        End Property

        Public Property amountIDR() As Decimal
            Get
                Return m_amountIDR
            End Get
            Set(ByVal value As Decimal)
                m_amountIDR = value
            End Set
        End Property
        Public Property Rate() As Decimal
            Get
                Return m_rate
            End Get
            Set(ByVal value As Decimal)
                m_rate = value
            End Set
        End Property
        Public Property bookdate() As Date
            Get
                Return m_Bookdate
            End Get
            Set(ByVal value As Date)
                m_Bookdate = value
            End Set
        End Property
        Public Property PeriodeID() As String
            Get
                Return m_PeriodeID
            End Get
            Set(ByVal value As String)
                m_PeriodeID = value
            End Set
        End Property
        Public Property PaidTo() As String
            Get
                Return m_paidto
            End Get
            Set(ByVal value As String)
                m_paidto = value
            End Set
        End Property


        Public Property cek_no() As String
            Get
                Return m_cek_no
            End Get
            Set(ByVal value As String)
                m_cek_no = value
            End Set
        End Property

        Public Property descr() As String
            Get
                Return m_descr
            End Get
            Set(ByVal value As String)
                m_descr = value
            End Set
        End Property

        Public Property JurnalSource() As String
            Get
                Return m_Source
            End Get
            Set(ByVal value As String)
                m_Source = value
            End Set
        End Property
        Public Property descrBilyet() As String
            Get
                Return m_descrBilyet
            End Get
            Set(ByVal value As String)
                m_descrBilyet = value
            End Set
        End Property
        Public Property terbilang() As String
            Get
                Return m_terbilang
            End Get
            Set(ByVal value As String)
                m_terbilang = value
            End Set
        End Property

        Public Property CreateBy() As String
            Get
                Return m_createby
            End Get
            Set(ByVal value As String)
                m_createby = value
            End Set
        End Property
        Public Property CreateDate() As Date
            Get
                Return m_createdate
            End Get
            Set(ByVal value As Date)
                m_createdate = value
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
        Public Property paymenttype_name() As String
            Get
                Return m_paymenttype_id
            End Get
            Set(ByVal value As String)
                m_paymenttype_id = value
            End Set
        End Property

        Public Property sumIDR() As Decimal
            Get
                Return m_JumlahIDR
            End Get
            Set(ByVal value As Decimal)
                m_JumlahIDR = value
            End Set
        End Property

        Public Property sumForeign() As Decimal
            Get
                Return m_JumlahForeign
            End Get
            Set(ByVal value As Decimal)
                m_JumlahForeign = value
            End Set
        End Property
        Public Property ReceiveBy() As String
            Get
                Return m_ReceiveBy
            End Get
            Set(ByVal value As String)
                m_ReceiveBy = value
            End Set
        End Property
        Public Property ReceiveDate() As Date
            Get
                Return m_ReceiveDate
            End Get
            Set(ByVal value As Date)
                m_ReceiveDate = value
            End Set
        End Property

        Public Property rekanan_id() As String
            Get
                Return m_rekanan_id
            End Get
            Set(ByVal value As String)
                m_rekanan_id = value
            End Set
        End Property

        Public Property rekanan_name() As String
            Get
                Return m_rekanan_name
            End Get
            Set(ByVal value As String)
                m_rekanan_name = value
            End Set
        End Property
    End Class
End Namespace


