Imports System.Data.OleDb
Namespace DataSource
    Public Class clsRptCirculationVoucherDetil
        Private DSN As String
        Private mCirculation_id As String
        Private mCirculationdetil_line As Int32
        Private mCirculationdetil_reference As String
        Private mCirculationdetil_bilyet As String
        Private mCirculationdetil_rekanan As Decimal
        Private mCirculationdetil_descr As String
        Private mCurrency_id As Decimal
        Private mCirculationdetil_foreign As Decimal
        Private mCirculationdetil_rate As Decimal
        Private mCirculationdetil_amount As Decimal
        Private mChannel_id As String
        Private mCirculationdetil_appdireksi As Byte
        Private mCirculationdetil_appdireksi_by As String
        Private mCirculationdetil_appdireksi_dt As DateTime
        Private mCirculationdetil_appbayar As Byte
        Private mCirculationdetil_appbayar_by As String
        Private mCirculationdetil_appbayar_dt As DateTime
        Private mCirculationdetil_appbankcair As Byte
        Private mCirculationdetil_appbankcair_by As String
        Private mCirculationdetil_appbankcair_dt As DateTime
        Private mCirculationdetil_canceled As Byte
        Private mCirculationdetil_canceledby As String
        Private mCirculationdetil_canceleddt As DateTime
        Private mEntry_by As String
        Private mEntry_dt As DateTime
        Private mModify_by As String
        Private mModify_dt As DateTime

        Private mAmount_ref_foreign As Decimal
        Private mAmount_ref_idr As Decimal

        Private mJurnal_id_ref As String
        Private mCurrRef As String
        Private mCurrName As String
        Private mPaymenttype As String
        Private mDescRef As String

        Public Property circulation_id() As String
            Get
                Return mCirculation_id
            End Get
            Set(ByVal value As String)
                mCirculation_id = value
            End Set
        End Property

        Public Property circulationdetil_line() As Int32
            Get
                Return mCirculationdetil_line
            End Get
            Set(ByVal value As Int32)
                mCirculationdetil_line = value
            End Set
        End Property

        Public Property circulationdetil_reference() As String
            Get
                Return mCirculationdetil_reference
            End Get
            Set(ByVal value As String)
                mCirculationdetil_reference = value
            End Set
        End Property

        Public Property circulationdetil_bilyet() As String
            Get
                Return mCirculationdetil_bilyet
            End Get
            Set(ByVal value As String)
                mCirculationdetil_bilyet = value
            End Set
        End Property

        Public Property circulationdetil_rekanan() As Decimal
            Get
                Return mCirculationdetil_rekanan
            End Get
            Set(ByVal value As Decimal)
                mCirculationdetil_rekanan = value
            End Set
        End Property

        Public Property circulationdetil_descr() As String
            Get
                Return mCirculationdetil_descr
            End Get
            Set(ByVal value As String)
                mCirculationdetil_descr = value
            End Set
        End Property

        Public Property currency_id() As Decimal
            Get
                Return mCurrency_id
            End Get
            Set(ByVal value As Decimal)
                mCurrency_id = value
            End Set
        End Property

        Public Property circulationdetil_foreign() As Decimal
            Get
                Return mCirculationdetil_foreign
            End Get
            Set(ByVal value As Decimal)
                mCirculationdetil_foreign = value
            End Set
        End Property

        Public Property circulationdetil_rate() As Decimal
            Get
                Return mCirculationdetil_rate
            End Get
            Set(ByVal value As Decimal)
                mCirculationdetil_rate = value
            End Set
        End Property

        Public Property circulationdetil_amount() As Decimal
            Get
                Return mCirculationdetil_amount
            End Get
            Set(ByVal value As Decimal)
                mCirculationdetil_amount = value
            End Set
        End Property

        Public Property channel_id() As String
            Get
                Return mChannel_id
            End Get
            Set(ByVal value As String)
                mChannel_id = value
            End Set
        End Property

        Public Property circulationdetil_appdireksi() As Byte
            Get
                Return mCirculationdetil_appdireksi
            End Get
            Set(ByVal value As Byte)
                mCirculationdetil_appdireksi = value
            End Set
        End Property

        Public Property circulationdetil_appdireksi_by() As String
            Get
                Return mCirculationdetil_appdireksi_by
            End Get
            Set(ByVal value As String)
                mCirculationdetil_appdireksi_by = value
            End Set
        End Property

        Public Property circulationdetil_appdireksi_dt() As DateTime
            Get
                Return mCirculationdetil_appdireksi_dt
            End Get
            Set(ByVal value As DateTime)
                mCirculationdetil_appdireksi_dt = value
            End Set
        End Property

        Public Property circulationdetil_appbayar() As Byte
            Get
                Return mCirculationdetil_appbayar
            End Get
            Set(ByVal value As Byte)
                mCirculationdetil_appbayar = value
            End Set
        End Property

        Public Property circulationdetil_appbayar_by() As String
            Get
                Return mCirculationdetil_appbayar_by
            End Get
            Set(ByVal value As String)
                mCirculationdetil_appbayar_by = value
            End Set
        End Property

        Public Property circulationdetil_appbayar_dt() As DateTime
            Get
                Return mCirculationdetil_appbayar_dt
            End Get
            Set(ByVal value As DateTime)
                mCirculationdetil_appbayar_dt = value
            End Set
        End Property

        Public Property circulationdetil_appbankcair() As Byte
            Get
                Return mCirculationdetil_appbankcair
            End Get
            Set(ByVal value As Byte)
                mCirculationdetil_appbankcair = value
            End Set
        End Property

        Public Property circulationdetil_appbankcair_by() As String
            Get
                Return mCirculationdetil_appbankcair_by
            End Get
            Set(ByVal value As String)
                mCirculationdetil_appbankcair_by = value
            End Set
        End Property

        Public Property circulationdetil_appbankcair_dt() As DateTime
            Get
                Return mCirculationdetil_appbankcair_dt
            End Get
            Set(ByVal value As DateTime)
                mCirculationdetil_appbankcair_dt = value
            End Set
        End Property

        Public Property circulationdetil_canceled() As Byte
            Get
                Return mCirculationdetil_canceled
            End Get
            Set(ByVal value As Byte)
                mCirculationdetil_canceled = value
            End Set
        End Property

        Public Property circulationdetil_canceledby() As String
            Get
                Return mCirculationdetil_canceledby
            End Get
            Set(ByVal value As String)
                mCirculationdetil_canceledby = value
            End Set
        End Property

        Public Property circulationdetil_canceleddt() As DateTime
            Get
                Return mCirculationdetil_canceleddt
            End Get
            Set(ByVal value As DateTime)
                mCirculationdetil_canceleddt = value
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

        Public Property amount_ref_foreign() As Decimal
            Get
                Return mAmount_ref_foreign
            End Get
            Set(ByVal value As Decimal)
                mAmount_ref_foreign = value
            End Set
        End Property


        Public Property amount_ref_idr() As Decimal
            Get
                Return mAmount_ref_idr
            End Get
            Set(ByVal value As Decimal)
                mAmount_ref_idr = value
            End Set
        End Property

        Public Property jurnal_id_ref() As String
            Get
                Return mJurnal_id_ref
            End Get
            Set(ByVal value As String)
                mJurnal_id_ref = value
            End Set
        End Property
        Public Property currref() As String
            Get
                Return mCurrRef
            End Get
            Set(ByVal value As String)
                mCurrRef = value
            End Set
        End Property
        Public Property currname() As String
            Get
                Return mCurrName
            End Get
            Set(ByVal value As String)
                mCurrName = value
            End Set
        End Property
        Public Property paymenttype() As String
            Get
                Return mPaymenttype
            End Get
            Set(ByVal value As String)
                mPaymenttype = value
            End Set
        End Property
        Public Property descref() As String
            Get
                Return mDescRef
            End Get
            Set(ByVal value As String)
                mDescRef = value
            End Set
        End Property


        Public Sub New(ByVal DSN As String)
            Me.DSN = DSN
        End Sub
    End Class
End Namespace