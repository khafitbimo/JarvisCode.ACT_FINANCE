
Imports System.Data.OleDb
Namespace DataSource
    Public Class ClsRptAdvanceDetil
        Private DSN As String
        Private mBudget_amountdetil As Decimal
        Private mBudget_amountforeign As Decimal
        Private mRate As Decimal
        Private mtotal_pphamount As Decimal
        Private mtotal_ppnamount As Decimal
        Private mtotal_subtotal As Decimal
        Private mtotal_discount As Decimal
        Private mTotalAmount As Decimal
        Private mDescr As String
        Private mCurrency As String
        Private mNo As String

        private mAmount_intercompany as decimal

        Public Property total_discount() As Decimal
            Get
                Return mtotal_discount
            End Get
            Set(ByVal value As Decimal)
                mtotal_discount = value
            End Set
        End Property
        Public Property total_pphamount() As Decimal
            Get
                Return mtotal_pphamount
            End Get
            Set(ByVal value As Decimal)
                mtotal_pphamount = value
            End Set
        End Property
        Public Property total_ppnamount() As Decimal
            Get
                Return mtotal_ppnamount
            End Get
            Set(ByVal value As Decimal)
                mtotal_ppnamount = value
            End Set
        End Property
        Public Property total_subtotal() As Decimal
            Get
                Return mtotal_subtotal
            End Get
            Set(ByVal value As Decimal)
                mtotal_subtotal = value
            End Set
        End Property
        Public Property budget_amountdetail() As Decimal
            Get
                Return mBudget_amountdetil
            End Get
            Set(ByVal value As Decimal)
                mBudget_amountdetil = value
            End Set
        End Property
        Public Property Budget_amountforeign() As Decimal
            Get
                Return mBudget_amountforeign
            End Get
            Set(ByVal value As Decimal)
                mBudget_amountforeign = value
            End Set
        End Property
        Public Property total_amount() As Decimal
            Get
                Return mTotalAmount
            End Get
            Set(ByVal value As Decimal)
                mTotalAmount = value
            End Set
        End Property
        Public Property currency() As String
            Get
                Return mCurrency
            End Get
            Set(ByVal value As String)
                mCurrency = value
            End Set
        End Property
        Public Property rate() As Decimal
            Get
                Return mRate
            End Get
            Set(ByVal value As Decimal)
                mRate = value
            End Set
        End Property
        Public Property no() As String
            Get
                Return mNo
            End Get
            Set(ByVal value As String)
                mNo = value
            End Set
        End Property
        Public Property descr() As String
            Get
                Return mDescr
            End Get
            Set(ByVal value As String)
                mDescr = value
            End Set
        End Property

        Public Property amount_intercompany() As Decimal
            Get
                Return mAmount_intercompany
            End Get
            Set(ByVal value As Decimal)
                mAmount_intercompany = value
            End Set
        End Property

        Public Sub New(ByVal DSN As String)
            Me.DSN = DSN
        End Sub
    End Class
End Namespace

