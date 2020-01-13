'================================================== 
' Yanuar Andriyana Putra
' TransTV
' Created Date: 1/4/2010 5:05 PM

Imports System.Data.OleDb
Namespace DataSource

    Public Class clsRptJurnalPV_Cek
        Private mRekanan_namereport As String
        Private mJumlah_dikirim As String
        Private mJumlah_terbilang As String
        Private mJurnal_date As DateTime

        Public Property rekanan_namereport() As String
            Get
                Return mRekanan_namereport
            End Get
            Set(ByVal value As String)
                mRekanan_namereport = value
            End Set
        End Property
        Public Property jumlah_dikirim() As DateTime
            Get
                Return mJumlah_dikirim
            End Get
            Set(ByVal value As DateTime)
                mJumlah_dikirim = value
            End Set
        End Property
        Public Property jumlah_terbilang() As String
            Get
                Return mJumlah_terbilang
            End Get
            Set(ByVal value As String)
                mJumlah_terbilang = value
            End Set
        End Property
        Public Property jurnal_date() As DateTime
            Get
                Return mJurnal_date
            End Get
            Set(ByVal value As DateTime)
                mJurnal_date = value
            End Set
        End Property
    End Class

End Namespace
