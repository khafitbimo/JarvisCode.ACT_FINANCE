Namespace DataSource
    Public Class clsRptOutstandingOrder
        Private m_no As Integer
        Private m_order_id As String
        Private m_strukturunit_name As String
        Private m_order_descr As String
        Private m_amount_order As Decimal
        Private m_rv_status As String
        Private m_pv_advance As String
        Private m_amount_pv_advance As Decimal
        Private m_pv_ap As String
        Private m_amount_pv_ap As Decimal
        Private m_outstanding As Decimal
        Private DSN As String

        Public Sub New(ByVal DSN As String)
            Me.DSN = DSN
        End Sub

        Public Property no() As Integer
            Get
                Return m_no
            End Get
            Set(ByVal value As Integer)
                m_no = value
            End Set
        End Property

        Public Property order_id() As String
            Get
                Return m_order_id
            End Get
            Set(ByVal value As String)
                m_order_id = value
            End Set
        End Property

        Public Property strukturunit_name() As String
            Get
                Return m_strukturunit_name
            End Get
            Set(ByVal value As String)
                m_strukturunit_name = value
            End Set
        End Property

        Public Property order_descr() As String
            Get
                Return m_order_descr
            End Get
            Set(ByVal value As String)
                m_order_descr = value
            End Set
        End Property

        Public Property amount_order() As Decimal
            Get
                Return m_amount_order
            End Get
            Set(ByVal value As Decimal)
                m_amount_order = value
            End Set
        End Property

        Public Property rv_status() As String
            Get
                Return m_rv_status
            End Get
            Set(ByVal value As String)
                m_rv_status = value
            End Set
        End Property

        Public Property pv_advance() As String
            Get
                Return m_pv_advance
            End Get
            Set(ByVal value As String)
                m_pv_advance = value
            End Set
        End Property

        Public Property amount_pv_advance() As Decimal
            Get
                Return m_amount_pv_advance
            End Get
            Set(ByVal value As Decimal)
                m_amount_pv_advance = value
            End Set
        End Property

        Public Property pv_ap() As String
            Get
                Return m_pv_ap
            End Get
            Set(ByVal value As String)
                m_pv_ap = value
            End Set
        End Property

        Public Property amount_pv_ap() As Decimal
            Get
                Return m_amount_pv_ap
            End Get
            Set(ByVal value As Decimal)
                m_amount_pv_ap = value
            End Set
        End Property

        Public Property outstanding() As Decimal
            Get
                Return m_outstanding
            End Get
            Set(ByVal value As Decimal)
                m_outstanding = value
            End Set
        End Property

    End Class
End Namespace