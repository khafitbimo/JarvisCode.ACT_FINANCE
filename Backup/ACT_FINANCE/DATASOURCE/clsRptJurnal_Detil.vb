'================================================== 
' Yanuar Andriyana Putra
' TransTV
' Created Date: 9/21/2010 9:16 AM

Imports System.Data.OleDb
Namespace DataSource
    Public Class clsRptJurnal_Detil
        Private DSN As String
        Private mJurnal_id As String
        Private mJurnaldetil_line As Int32
        Private mJurnaldetil_dk As String
        Private mJurnaldetil_descr As String
        Private mJurnaldetil_idr As Decimal
        Private mJurnaldetil_foreign As Decimal
        Private mJurnaldetil_foreignrate As Decimal
        Private mRef_id As String
        Private mRef_line As Int32
        Private mAcc_id As String
        Private mAcc_name As String
        Private mChannel_id As String
        Private mRekanan_id As Decimal
        Private mRekanan_name As String

        'Add On
        Private mJurnal_descr As String
        Private mJurnaldetil_idr_string As String
        Private mJurnaltax_hargajual As Decimal
        Private mJurnalTax_ppn As Decimal


        Public Property jurnal_id() As String
            Get
                Return mJurnal_id
            End Get
            Set(ByVal value As String)
                mJurnal_id = value
            End Set
        End Property
        Public Property jurnaldetil_line() As Int32
            Get
                Return mJurnaldetil_line
            End Get
            Set(ByVal value As Int32)
                mJurnaldetil_line = value
            End Set
        End Property
        Public Property jurnaldetil_dk() As String
            Get
                Return mJurnaldetil_dk
            End Get
            Set(ByVal value As String)
                mJurnaldetil_dk = value
            End Set
        End Property
        Public Property jurnaldetil_descr() As String
            Get
                Return mJurnaldetil_descr
            End Get
            Set(ByVal value As String)
                mJurnaldetil_descr = value
            End Set
        End Property
        Public Property jurnaldetil_idr() As Decimal
            Get
                Return mJurnaldetil_idr
            End Get
            Set(ByVal value As Decimal)
                mJurnaldetil_idr = value
            End Set
        End Property
        Public Property jurnaldetil_foreign() As Decimal
            Get
                Return mJurnaldetil_foreign
            End Get
            Set(ByVal value As Decimal)
                mJurnaldetil_foreign = value
            End Set
        End Property
        Public Property jurnaldetil_foreignrate() As Decimal
            Get
                Return mJurnaldetil_foreignrate
            End Get
            Set(ByVal value As Decimal)
                mJurnaldetil_foreignrate = value
            End Set
        End Property
        Public Property ref_id() As String
            Get
                Return mRef_id
            End Get
            Set(ByVal value As String)
                mRef_id = value
            End Set
        End Property
        Public Property ref_line() As Int32
            Get
                Return mRef_line
            End Get
            Set(ByVal value As Int32)
                mRef_line = value
            End Set
        End Property
        Public Property acc_id() As String
            Get
                Return mAcc_id
            End Get
            Set(ByVal value As String)
                mAcc_id = value
            End Set
        End Property
        Public Property acc_name() As String
            Get
                Return mAcc_name
            End Get
            Set(ByVal value As String)
                mAcc_name = value
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
        Public Property rekanan_id() As Decimal
            Get
                Return mRekanan_id
            End Get
            Set(ByVal value As Decimal)
                mRekanan_id = value
            End Set
        End Property
        Public Property rekanan_name() As String
            Get
                Return mRekanan_name
            End Get
            Set(ByVal value As String)
                mRekanan_name = value
            End Set
        End Property

        'Add On
        Public Property jurnaldetil_idr_string() As String
            Get
                Return mJurnaldetil_idr_string
            End Get
            Set(ByVal value As String)
                mJurnaldetil_idr_string = value
            End Set
        End Property
        Public Property jurnal_descr() As String
            Get
                Return mJurnal_descr
            End Get
            Set(ByVal value As String)
                mJurnal_descr = value
            End Set
        End Property
        Public Property jurnaltax_hargajual() As Decimal
            Get
                Return mJurnaltax_hargajual
            End Get
            Set(ByVal value As Decimal)
                mJurnaltax_hargajual = value
            End Set
        End Property
        Public Property jurnalTax_ppn() As Decimal
            Get
                Return mJurnalTax_ppn
            End Get
            Set(ByVal value As Decimal)
                mJurnalTax_ppn = value
            End Set
        End Property
        Public Sub New(ByVal DSN As String)
            Me.DSN = DSN
        End Sub
    End Class
End Namespace

