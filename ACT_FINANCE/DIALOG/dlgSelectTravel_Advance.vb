Public Class dlgSelectTravel_Advance

    Private DSN As String
    Private _ChannelID As String

    Private tbl_TrnAdvanceHeader As DataTable = clsDataset.CreateTblTrnOrderforadvance()
    Private tbl_TrnAdvanceForOrder_temp As DataTable = clsDataset.CreateTblTrnOrderforadvance()
    Private tbl_TrnAdvanceForOrderDetil As DataTable = clsDataset.CreateTblTrnOrderforadvancedetil()

    Private tbl_TrnAdvanceForHeader_result As DataTable = clsDataset.CreateTblTrnOrderforadvance()
    Private tbl_TrnAdvanceForTravelPerdiems_result As DataTable = clsDataset.CreateTblTrnOrderforadvancedetil()
    Private tbl_TrnAdvanceForTravelDetil_result As DataTable = clsDataset.CreateTblTrnOrderforadvancedetil()

    Private _PROGRAMTYPE As String
    Private objective As String
    Private OrderID As String
    Private line As String
    Private _USERNAME As String

    Private CloseButtonIsPressed As Boolean
    Private retObj As Object

    Private reports As ArrayList = New ArrayList()
    Private objReport As clsReportList

    Private myOwner As System.Windows.Forms.IWin32Window
    Private tbl_MstRekanan As DataTable = clsDataset.CreateTblMstrekananCombo()


#Region " Class "

    Private Function AddReportList(ByRef rpts As ArrayList, ByVal id As String, ByVal name As String) As ArrayList
        objReport = New clsReportList
        objReport.report_id = id
        objReport.report_name = name
        rpts.Add(objReport)
        Return rpts
    End Function


    Friend Class clsReportList
        Private mReport_id As String
        Private mReport_name As String

        Public Property report_id() As String
            Get
                Return mReport_id
            End Get
            Set(ByVal value As String)
                mReport_id = value
            End Set
        End Property

        Public Property report_name() As String
            Get
                Return mReport_name
            End Get
            Set(ByVal value As String)
                mReport_name = value
            End Set
        End Property

    End Class

#End Region

#Region " Layout & Init UI "

    Private Function FormatDgvTrnRequest(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        Dim cOrder_id As New DataGridViewTextBoxColumn
        Dim cOrder_date As New DataGridViewTextBoxColumn
        Dim cOrder_descr As New DataGridViewTextBoxColumn
        Dim cRequest_id As New DataGridViewTextBoxColumn
        Dim cCurrency_id As New DataGridViewTextBoxColumn
        Dim cCurrency_name As New DataGridViewTextBoxColumn
        Dim cRekanan_id As New DataGridViewTextBoxColumn
        Dim cVendor As New DataGridViewTextBoxColumn
        Dim cOrder_prognm As New DataGridViewTextBoxColumn
        Dim cBudget_id As New DataGridViewTextBoxColumn
        Dim cBudget_name As New DataGridViewTextBoxColumn
        Dim cOrder_setlocation As New DataGridViewTextBoxColumn
        Dim cOrder_utilizeddatestart As New DataGridViewTextBoxColumn
        Dim cOrder_utilizeddateend As New DataGridViewTextBoxColumn
        Dim cOrder_pph_percent As New DataGridViewTextBoxColumn
        Dim cOrder_ppn_percent As New DataGridViewTextBoxColumn
        Dim cOrder_canceled As New DataGridViewTextBoxColumn
        Dim cOrder_createby As New DataGridViewTextBoxColumn
        Dim cOrder_createdate As New DataGridViewTextBoxColumn
        Dim cOrder_modifyby As New DataGridViewTextBoxColumn
        Dim cOrder_modifydate As New DataGridViewTextBoxColumn
        Dim cOrder_source As New DataGridViewTextBoxColumn
        Dim cOrdertype_id As New DataGridViewTextBoxColumn
        Dim cChannel_id As New DataGridViewTextBoxColumn
        Dim cPeriode_id As New DataGridViewTextBoxColumn
        Dim cPeriode_name As New DataGridViewTextBoxColumn
        Dim cStrukturunit_id As New DataGridViewTextBoxColumn
        Dim cDepartment As New DataGridViewTextBoxColumn
        Dim cOrder_programtype As New DataGridViewTextBoxColumn
        Dim cOrder_epsstart As New DataGridViewTextBoxColumn
        Dim cOrder_epsend As New DataGridViewTextBoxColumn
        Dim cSub_discount_idr As New DataGridViewTextBoxColumn
        Dim cSub_discount_foreign As New DataGridViewTextBoxColumn
        Dim cSubtotal_idr As New DataGridViewTextBoxColumn
        Dim cSubtotal_foreign As New DataGridViewTextBoxColumn
        Dim cSubtotal_incldisc_idr As New DataGridViewTextBoxColumn
        Dim cSubtotal_incldisc_foreign As New DataGridViewTextBoxColumn
        Dim cPph_amount_idr As New DataGridViewTextBoxColumn
        Dim cPph_amount_foreign As New DataGridViewTextBoxColumn
        Dim cPpn_amount_idr As New DataGridViewTextBoxColumn
        Dim cPpn_amount_foreign As New DataGridViewTextBoxColumn
        Dim cGrand_total_idr As New DataGridViewTextBoxColumn

        cOrder_id.Name = "order_id"
        cOrder_id.HeaderText = "Travel ID"
        cOrder_id.DataPropertyName = "order_id"
        cOrder_id.Width = 100
        cOrder_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cOrder_id.Visible = True
        cOrder_id.ReadOnly = True

        cOrder_date.Name = "order_date"
        cOrder_date.HeaderText = "order_date"
        cOrder_date.DataPropertyName = "order_date"
        cOrder_date.Width = 100
        cOrder_date.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cOrder_date.Visible = False
        cOrder_date.ReadOnly = True

        cOrder_descr.Name = "order_descr"
        cOrder_descr.HeaderText = "Description"
        cOrder_descr.DataPropertyName = "order_descr"
        cOrder_descr.Width = 200
        cOrder_descr.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cOrder_descr.Visible = True
        cOrder_descr.ReadOnly = True

        cRequest_id.Name = "request_id"
        cRequest_id.HeaderText = "Request ID"
        cRequest_id.DataPropertyName = "request_id"
        cRequest_id.Width = 100
        cRequest_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cRequest_id.Visible = False
        cRequest_id.ReadOnly = True

        cCurrency_id.Name = "currency_id"
        cCurrency_id.HeaderText = "currency_id"
        cCurrency_id.DataPropertyName = "currency_id"
        cCurrency_id.Width = 100
        cCurrency_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cCurrency_id.Visible = False
        cCurrency_id.ReadOnly = True

        cCurrency_name.Name = "currency_name"
        cCurrency_name.HeaderText = "Curr."
        cCurrency_name.DataPropertyName = "currency_name"
        cCurrency_name.Width = 40
        cCurrency_name.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cCurrency_name.Visible = True
        cCurrency_name.ReadOnly = True

        cRekanan_id.Name = "rekanan_id"
        cRekanan_id.HeaderText = "rekanan_id"
        cRekanan_id.DataPropertyName = "rekanan_id"
        cRekanan_id.Width = 100
        cRekanan_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cRekanan_id.Visible = False
        cRekanan_id.ReadOnly = True

        cVendor.Name = "vendor"
        cVendor.HeaderText = "Vendor"
        cVendor.DataPropertyName = "vendor"
        cVendor.Width = 200
        cVendor.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cVendor.Visible = True
        cVendor.ReadOnly = True

        cOrder_prognm.Name = "order_prognm"
        cOrder_prognm.HeaderText = "order_prognm"
        cOrder_prognm.DataPropertyName = "order_prognm"
        cOrder_prognm.Width = 100
        cOrder_prognm.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cOrder_prognm.Visible = False
        cOrder_prognm.ReadOnly = True

        cBudget_id.Name = "budget_id"
        cBudget_id.HeaderText = "budget_id"
        cBudget_id.DataPropertyName = "budget_id"
        cBudget_id.Width = 100
        cBudget_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cBudget_id.Visible = False
        cBudget_id.ReadOnly = True

        cBudget_name.Name = "budget_name"
        cBudget_name.HeaderText = "Budget Name"
        cBudget_name.DataPropertyName = "budget_name"
        cBudget_name.Width = 200
        cBudget_name.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cBudget_name.Visible = True
        cBudget_name.ReadOnly = True

        cOrder_setlocation.Name = "order_setlocation"
        cOrder_setlocation.HeaderText = "order_setlocation"
        cOrder_setlocation.DataPropertyName = "order_setlocation"
        cOrder_setlocation.Width = 100
        cOrder_setlocation.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cOrder_setlocation.Visible = False
        cOrder_setlocation.ReadOnly = True

        cOrder_utilizeddatestart.Name = "order_utilizeddatestart"
        cOrder_utilizeddatestart.HeaderText = "Shooting Start"
        cOrder_utilizeddatestart.DataPropertyName = "order_utilizeddatestart"
        cOrder_utilizeddatestart.Width = 100
        cOrder_utilizeddatestart.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cOrder_utilizeddatestart.DefaultCellStyle.Format = "dd/MM/yyyy"
        cOrder_utilizeddatestart.Visible = False
        cOrder_utilizeddatestart.ReadOnly = True

        cOrder_utilizeddateend.Name = "order_utilizeddateend"
        cOrder_utilizeddateend.HeaderText = "Shooting End"
        cOrder_utilizeddateend.DataPropertyName = "order_utilizeddateend"
        cOrder_utilizeddateend.Width = 100
        cOrder_utilizeddateend.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cOrder_utilizeddateend.DefaultCellStyle.Format = "dd/MM/yyyy"
        cOrder_utilizeddateend.Visible = False
        cOrder_utilizeddateend.ReadOnly = True

        cOrder_pph_percent.Name = "order_pph_percent"
        cOrder_pph_percent.HeaderText = "order_pph_percent"
        cOrder_pph_percent.DataPropertyName = "order_pph_percent"
        cOrder_pph_percent.Width = 100
        cOrder_pph_percent.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cOrder_pph_percent.Visible = False
        cOrder_pph_percent.ReadOnly = True

        cOrder_ppn_percent.Name = "order_ppn_percent"
        cOrder_ppn_percent.HeaderText = "order_ppn_percent"
        cOrder_ppn_percent.DataPropertyName = "order_ppn_percent"
        cOrder_ppn_percent.Width = 100
        cOrder_ppn_percent.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cOrder_ppn_percent.Visible = False
        cOrder_ppn_percent.ReadOnly = True

        cOrder_canceled.Name = "order_canceled"
        cOrder_canceled.HeaderText = "order_canceled"
        cOrder_canceled.DataPropertyName = "order_canceled"
        cOrder_canceled.Width = 100
        cOrder_canceled.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cOrder_canceled.Visible = False
        cOrder_canceled.ReadOnly = True

        cOrder_createby.Name = "order_createby"
        cOrder_createby.HeaderText = "Create by"
        cOrder_createby.DataPropertyName = "order_createby"
        cOrder_createby.Width = 100
        cOrder_createby.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cOrder_createby.Visible = False
        cOrder_createby.ReadOnly = True

        cOrder_createdate.Name = "order_createdate"
        cOrder_createdate.HeaderText = "Create date"
        cOrder_createdate.DataPropertyName = "order_createdate"
        cOrder_createdate.Width = 100
        cOrder_createdate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cOrder_createdate.DefaultCellStyle.Format = "dd/MM/yyyy"
        cOrder_createdate.Visible = False
        cOrder_createdate.ReadOnly = True

        cOrder_modifyby.Name = "order_modifyby"
        cOrder_modifyby.HeaderText = "order_modifyby"
        cOrder_modifyby.DataPropertyName = "order_modifyby"
        cOrder_modifyby.Width = 100
        cOrder_modifyby.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cOrder_modifyby.Visible = False
        cOrder_modifyby.ReadOnly = True

        cOrder_modifydate.Name = "order_modifydate"
        cOrder_modifydate.HeaderText = "order_modifydate"
        cOrder_modifydate.DataPropertyName = "order_modifydate"
        cOrder_modifydate.Width = 100
        cOrder_modifydate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cOrder_modifydate.Visible = False
        cOrder_modifydate.ReadOnly = True

        cOrder_source.Name = "order_source"
        cOrder_source.HeaderText = "order_source"
        cOrder_source.DataPropertyName = "order_source"
        cOrder_source.Width = 100
        cOrder_source.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cOrder_source.Visible = False
        cOrder_source.ReadOnly = True

        cOrdertype_id.Name = "ordertype_id"
        cOrdertype_id.HeaderText = "ordertype_id"
        cOrdertype_id.DataPropertyName = "ordertype_id"
        cOrdertype_id.Width = 100
        cOrdertype_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cOrdertype_id.Visible = False
        cOrdertype_id.ReadOnly = True

        cChannel_id.Name = "channel_id"
        cChannel_id.HeaderText = "channel_id"
        cChannel_id.DataPropertyName = "channel_id"
        cChannel_id.Width = 100
        cChannel_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cChannel_id.Visible = False
        cChannel_id.ReadOnly = True

        cPeriode_id.Name = "periode_id"
        cPeriode_id.HeaderText = "periode_id"
        cPeriode_id.DataPropertyName = "periode_id"
        cPeriode_id.Width = 100
        cPeriode_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cPeriode_id.Visible = False
        cPeriode_id.ReadOnly = True

        cPeriode_name.Name = "periode_name"
        cPeriode_name.HeaderText = "Periode"
        cPeriode_name.DataPropertyName = "periode_name"
        cPeriode_name.Width = 100
        cPeriode_name.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cPeriode_name.Visible = False
        cPeriode_name.ReadOnly = True

        cStrukturunit_id.Name = "strukturunit_id"
        cStrukturunit_id.HeaderText = "strukturunit_id"
        cStrukturunit_id.DataPropertyName = "strukturunit_id"
        cStrukturunit_id.Width = 100
        cStrukturunit_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cStrukturunit_id.Visible = False
        cStrukturunit_id.ReadOnly = True

        cDepartment.Name = "department"
        cDepartment.HeaderText = "Department"
        cDepartment.DataPropertyName = "department"
        cDepartment.Width = 150
        cDepartment.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cDepartment.Visible = False
        cDepartment.ReadOnly = True

        cOrder_programtype.Name = "order_programtype"
        cOrder_programtype.HeaderText = "order_programtype"
        cOrder_programtype.DataPropertyName = "order_programtype"
        cOrder_programtype.Width = 100
        cOrder_programtype.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cOrder_programtype.Visible = False
        cOrder_programtype.ReadOnly = True

        cOrder_epsstart.Name = "order_epsstart"
        cOrder_epsstart.HeaderText = "Eps Start"
        cOrder_epsstart.DataPropertyName = "order_epsstart"
        cOrder_epsstart.Width = 60
        cOrder_epsstart.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cOrder_epsstart.Visible = False
        cOrder_epsstart.ReadOnly = True

        cOrder_epsend.Name = "order_epsend"
        cOrder_epsend.HeaderText = "Eps End"
        cOrder_epsend.DataPropertyName = "order_epsend"
        cOrder_epsend.Width = 60
        cOrder_epsend.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cOrder_epsend.Visible = False
        cOrder_epsend.ReadOnly = True

        cSub_discount_idr.Name = "sub_discount_idr"
        cSub_discount_idr.HeaderText = "sub_discount_idr"
        cSub_discount_idr.DataPropertyName = "sub_discount_idr"
        cSub_discount_idr.Width = 100
        cSub_discount_idr.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cSub_discount_idr.Visible = False
        cSub_discount_idr.ReadOnly = True

        cSub_discount_foreign.Name = "sub_discount_foreign"
        cSub_discount_foreign.HeaderText = "sub_discount_foreign"
        cSub_discount_foreign.DataPropertyName = "sub_discount_foreign"
        cSub_discount_foreign.Width = 100
        cSub_discount_foreign.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cSub_discount_foreign.Visible = False
        cSub_discount_foreign.ReadOnly = True

        cSubtotal_idr.Name = "subtotal_idr"
        cSubtotal_idr.HeaderText = "subtotal_idr"
        cSubtotal_idr.DataPropertyName = "subtotal_idr"
        cSubtotal_idr.Width = 100
        cSubtotal_idr.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cSubtotal_idr.Visible = False
        cSubtotal_idr.ReadOnly = True

        cSubtotal_foreign.Name = "subtotal_foreign"
        cSubtotal_foreign.HeaderText = "subtotal_foreign"
        cSubtotal_foreign.DataPropertyName = "subtotal_foreign"
        cSubtotal_foreign.Width = 100
        cSubtotal_foreign.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cSubtotal_foreign.Visible = False
        cSubtotal_foreign.ReadOnly = True

        cSubtotal_incldisc_idr.Name = "subtotal_incldisc_idr"
        cSubtotal_incldisc_idr.HeaderText = "subtotal_incldisc_idr"
        cSubtotal_incldisc_idr.DataPropertyName = "subtotal_incldisc_idr"
        cSubtotal_incldisc_idr.Width = 100
        cSubtotal_incldisc_idr.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cSubtotal_incldisc_idr.Visible = False
        cSubtotal_incldisc_idr.ReadOnly = True

        cSubtotal_incldisc_foreign.Name = "subtotal_incldisc_foreign"
        cSubtotal_incldisc_foreign.HeaderText = "subtotal_incldisc_foreign"
        cSubtotal_incldisc_foreign.DataPropertyName = "subtotal_incldisc_foreign"
        cSubtotal_incldisc_foreign.Width = 100
        cSubtotal_incldisc_foreign.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cSubtotal_incldisc_foreign.Visible = False
        cSubtotal_incldisc_foreign.ReadOnly = True

        cPph_amount_idr.Name = "pph_amount_idr"
        cPph_amount_idr.HeaderText = "pph_amount_idr"
        cPph_amount_idr.DataPropertyName = "pph_amount_idr"
        cPph_amount_idr.Width = 100
        cPph_amount_idr.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cPph_amount_idr.Visible = False
        cPph_amount_idr.ReadOnly = True

        cPph_amount_foreign.Name = "pph_amount_foreign"
        cPph_amount_foreign.HeaderText = "pph_amount_foreign"
        cPph_amount_foreign.DataPropertyName = "pph_amount_foreign"
        cPph_amount_foreign.Width = 100
        cPph_amount_foreign.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cPph_amount_foreign.Visible = False
        cPph_amount_foreign.ReadOnly = True

        cPpn_amount_idr.Name = "ppn_amount_idr"
        cPpn_amount_idr.HeaderText = "ppn_amount_idr"
        cPpn_amount_idr.DataPropertyName = "ppn_amount_idr"
        cPpn_amount_idr.Width = 100
        cPpn_amount_idr.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cPpn_amount_idr.Visible = False
        cPpn_amount_idr.ReadOnly = True

        cPpn_amount_foreign.Name = "ppn_amount_foreign"
        cPpn_amount_foreign.HeaderText = "ppn_amount_foreign"
        cPpn_amount_foreign.DataPropertyName = "ppn_amount_foreign"
        cPpn_amount_foreign.Width = 100
        cPpn_amount_foreign.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cPpn_amount_foreign.Visible = False
        cPpn_amount_foreign.ReadOnly = True

        cGrand_total_idr.Name = "grand_total_idr"
        cGrand_total_idr.HeaderText = "Total"
        cGrand_total_idr.DataPropertyName = "grand_total_idr"
        cGrand_total_idr.Width = 120
        cGrand_total_idr.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cGrand_total_idr.DefaultCellStyle.Format = "#,###,##0.00"
        cGrand_total_idr.Visible = True
        cGrand_total_idr.ReadOnly = True

        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New DataGridViewColumn() _
        {cOrder_id, cOrder_date, _
        cOrder_descr, cBudget_name, _
        cRequest_id, cVendor, _
        cPeriode_name, cDepartment, _
        cCurrency_id, cCurrency_name, _
        cRekanan_id, _
        cOrder_prognm, cBudget_id, _
        cOrder_setlocation, _
        cOrder_utilizeddatestart, cOrder_utilizeddateend, _
        cOrder_pph_percent, cOrder_ppn_percent, _
        cOrder_canceled, cOrder_createby, _
        cOrder_createdate, cOrder_modifyby, _
        cOrder_modifydate, cOrder_source, _
        cOrdertype_id, cChannel_id, _
        cPeriode_id, _
        cStrukturunit_id, _
        cOrder_programtype, cOrder_epsstart, _
        cOrder_epsend, cSub_discount_idr, _
        cSub_discount_foreign, cSubtotal_idr, _
        cSubtotal_foreign, cSubtotal_incldisc_idr, _
        cSubtotal_incldisc_foreign, cPph_amount_idr, _
        cPph_amount_foreign, cPpn_amount_idr, _
        cPpn_amount_foreign, cGrand_total_idr})

        objDgv.AutoGenerateColumns = False
        objDgv.AllowUserToAddRows = False
        objDgv.AllowUserToDeleteRows = False
        objDgv.MultiSelect = False

    End Function

    Private Function FormatDgvTrnRequestDetailDlg(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        Dim cSelect As New DataGridViewCheckBoxColumn
        Dim cOrder_id As New DataGridViewTextBoxColumn
        Dim cOrderdetil_line As New DataGridViewTextBoxColumn
        Dim cOrderdetil_type As New DataGridViewTextBoxColumn
        Dim cItem_name As New DataGridViewTextBoxColumn
        Dim cCurrency_id As New DataGridViewTextBoxColumn
        Dim cCurrency_name As New DataGridViewTextBoxColumn
        Dim cOrderdetil_qty As New DataGridViewTextBoxColumn
        Dim cOrderdetil_days As New DataGridViewTextBoxColumn
        Dim cOrderdetil_foreign As New DataGridViewTextBoxColumn
        Dim cOrderdetil_foreignrate As New DataGridViewTextBoxColumn
        Dim cOrderdetil_discount As New DataGridViewTextBoxColumn
        Dim cBudget_id As New DataGridViewTextBoxColumn
        Dim cBudget_name As New DataGridViewTextBoxColumn
        Dim cBudgetdetil_id As New DataGridViewTextBoxColumn
        Dim cBudgetdetil_name As New DataGridViewTextBoxColumn
        Dim cSubtotal_idr As New DataGridViewTextBoxColumn
        Dim cSubtotal_foreign As New DataGridViewTextBoxColumn
        Dim cSubtotal_incldisc_idr As New DataGridViewTextBoxColumn
        Dim cSubtotal_incldisc_foreign As New DataGridViewTextBoxColumn
        Dim cPph_amount_idr As New DataGridViewTextBoxColumn
        Dim cPph_amount_foreign As New DataGridViewTextBoxColumn
        Dim cPpn_amount_idr As New DataGridViewTextBoxColumn
        Dim cPpn_amount_foreign As New DataGridViewTextBoxColumn
        Dim cTotal As New DataGridViewTextBoxColumn
        Dim cAmount As New DataGridViewTextBoxColumn
        Dim cAmount_order As New DataGridViewTextBoxColumn
        Dim cAmount_sisa As New DataGridViewTextBoxColumn

        Dim colIndex As Integer

        cSelect.Name = "select"
        cSelect.HeaderText = "Select"
        cSelect.Width = 50
        cSelect.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        cSelect.Visible = True
        cSelect.Frozen = True
        cSelect.ReadOnly = True

        cOrder_id.Name = "order_id"
        cOrder_id.HeaderText = "Travel ID"
        cOrder_id.DataPropertyName = "order_id"
        cOrder_id.Width = 100
        cOrder_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cOrder_id.DefaultCellStyle.BackColor = Color.Gainsboro
        cOrder_id.Visible = True
        cOrder_id.ReadOnly = True

        cOrderdetil_line.Name = "orderdetil_line"
        cOrderdetil_line.HeaderText = "Line"
        cOrderdetil_line.DataPropertyName = "orderdetil_line"
        cOrderdetil_line.Width = 50
        cOrderdetil_line.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cOrderdetil_line.DefaultCellStyle.BackColor = Color.Gainsboro
        cOrderdetil_line.Visible = True
        cOrderdetil_line.ReadOnly = True

        cOrderdetil_type.Name = "orderdetil_type"
        cOrderdetil_type.HeaderText = "orderdetil_type"
        cOrderdetil_type.DataPropertyName = "orderdetil_type"
        cOrderdetil_type.Width = 100
        cOrderdetil_type.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cOrderdetil_type.DefaultCellStyle.BackColor = Color.Gainsboro
        cOrderdetil_type.Visible = False
        cOrderdetil_type.ReadOnly = True

        cItem_name.Name = "item_name"
        cItem_name.HeaderText = "Item Name"
        cItem_name.DataPropertyName = "item_name"
        cItem_name.Width = 300
        cItem_name.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cItem_name.DefaultCellStyle.BackColor = Color.Gainsboro
        cItem_name.Visible = True
        cItem_name.ReadOnly = True

        cCurrency_id.Name = "currency_id"
        cCurrency_id.HeaderText = "currency_id"
        cCurrency_id.DataPropertyName = "currency_id"
        cCurrency_id.Width = 50
        cCurrency_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cCurrency_id.DefaultCellStyle.BackColor = Color.Gainsboro
        cCurrency_id.Visible = False
        cCurrency_id.ReadOnly = True

        cCurrency_name.Name = "currency_name"
        cCurrency_name.HeaderText = "Curr."
        cCurrency_name.DataPropertyName = "currency_name"
        cCurrency_name.Width = 40
        cCurrency_name.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cCurrency_name.DefaultCellStyle.BackColor = Color.Gainsboro
        cCurrency_name.Visible = True
        cCurrency_name.ReadOnly = True

        cOrderdetil_qty.Name = "orderdetil_qty"
        cOrderdetil_qty.HeaderText = "Qty"
        cOrderdetil_qty.DataPropertyName = "orderdetil_qty"
        cOrderdetil_qty.Width = 80
        cOrderdetil_qty.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cOrderdetil_qty.DefaultCellStyle.BackColor = Color.Gainsboro
        cOrderdetil_qty.DefaultCellStyle.Format = "#,###,##0.00"
        cOrderdetil_qty.Visible = True
        cOrderdetil_qty.ReadOnly = True

        cOrderdetil_days.Name = "orderdetil_days"
        cOrderdetil_days.HeaderText = "Days"
        cOrderdetil_days.DataPropertyName = "orderdetil_days"
        cOrderdetil_days.Width = 80
        cOrderdetil_days.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cOrderdetil_days.DefaultCellStyle.BackColor = Color.Gainsboro
        cOrderdetil_days.DefaultCellStyle.Format = "#,###,##0.00"
        cOrderdetil_days.Visible = True
        cOrderdetil_days.ReadOnly = True

        cOrderdetil_foreign.Name = "orderdetil_foreign"
        cOrderdetil_foreign.HeaderText = "orderdetil_foreign"
        cOrderdetil_foreign.DataPropertyName = "orderdetil_foreign"
        cOrderdetil_foreign.Width = 100
        cOrderdetil_foreign.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cOrderdetil_foreign.DefaultCellStyle.BackColor = Color.Gainsboro
        cOrderdetil_foreign.Visible = False
        cOrderdetil_foreign.ReadOnly = True

        cOrderdetil_foreignrate.Name = "orderdetil_foreignrate"
        cOrderdetil_foreignrate.HeaderText = "orderdetil_foreignrate"
        cOrderdetil_foreignrate.DataPropertyName = "orderdetil_foreignrate"
        cOrderdetil_foreignrate.Width = 100
        cOrderdetil_foreignrate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cOrderdetil_foreignrate.DefaultCellStyle.BackColor = Color.Gainsboro
        cOrderdetil_foreignrate.Visible = False
        cOrderdetil_foreignrate.ReadOnly = True

        cOrderdetil_discount.Name = "orderdetil_discount"
        cOrderdetil_discount.HeaderText = "Discount"
        cOrderdetil_discount.DataPropertyName = "orderdetil_discount"
        cOrderdetil_discount.Width = 120
        cOrderdetil_discount.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cOrderdetil_discount.DefaultCellStyle.BackColor = Color.Gainsboro
        cOrderdetil_discount.DefaultCellStyle.Format = "#,###,##0.00"
        cOrderdetil_discount.Visible = True
        cOrderdetil_discount.ReadOnly = True

        cBudget_id.Name = "budget_id"
        cBudget_id.HeaderText = "budget_id"
        cBudget_id.DataPropertyName = "budget_id"
        cBudget_id.Width = 100
        cBudget_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cBudget_id.DefaultCellStyle.BackColor = Color.Gainsboro
        cBudget_id.Visible = False
        cBudget_id.ReadOnly = True

        cBudget_name.Name = "budget_name"
        cBudget_name.HeaderText = "Budget Name"
        cBudget_name.DataPropertyName = "budget_name"
        cBudget_name.Width = 120
        cBudget_name.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cBudget_name.DefaultCellStyle.BackColor = Color.Gainsboro
        cBudget_name.Visible = True
        cBudget_name.ReadOnly = True

        cBudgetdetil_id.Name = "budgetdetil_id"
        cBudgetdetil_id.HeaderText = "budgetdetil_id"
        cBudgetdetil_id.DataPropertyName = "budgetdetil_id"
        cBudgetdetil_id.Width = 100
        cBudgetdetil_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cBudgetdetil_id.DefaultCellStyle.BackColor = Color.Gainsboro
        cBudgetdetil_id.Visible = False
        cBudgetdetil_id.ReadOnly = True

        cBudgetdetil_name.Name = "budgetdetil_name"
        cBudgetdetil_name.HeaderText = "Budget Detil Name"
        cBudgetdetil_name.DataPropertyName = "budgetdetil_name"
        cBudgetdetil_name.Width = 120
        cBudgetdetil_name.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cBudgetdetil_name.DefaultCellStyle.BackColor = Color.Gainsboro
        cBudgetdetil_name.Visible = True
        cBudgetdetil_name.ReadOnly = True

        cSubtotal_idr.Name = "subtotal_idr"
        cSubtotal_idr.HeaderText = "Subtotal IDR"
        cSubtotal_idr.DataPropertyName = "subtotal_idr"
        cSubtotal_idr.Width = 120
        cSubtotal_idr.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cSubtotal_idr.DefaultCellStyle.BackColor = Color.Gainsboro
        cSubtotal_idr.DefaultCellStyle.Format = "#,###,##0.00"
        cSubtotal_idr.Visible = False
        cSubtotal_idr.ReadOnly = True

        cSubtotal_foreign.Name = "subtotal_foreign"
        cSubtotal_foreign.HeaderText = "Subtotal Foreign"
        cSubtotal_foreign.DataPropertyName = "subtotal_foreign"
        cSubtotal_foreign.Width = 120
        cSubtotal_foreign.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cSubtotal_foreign.DefaultCellStyle.BackColor = Color.Gainsboro
        cSubtotal_foreign.DefaultCellStyle.Format = "#,###,##0.00"
        cSubtotal_foreign.Visible = False
        cSubtotal_foreign.ReadOnly = True

        cSubtotal_incldisc_idr.Name = "subtotal_incldisc_idr"
        cSubtotal_incldisc_idr.HeaderText = "SubtotalIncl.Disc IDR"
        cSubtotal_incldisc_idr.DataPropertyName = "subtotal_incldisc_idr"
        cSubtotal_incldisc_idr.Width = 150
        cSubtotal_incldisc_idr.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cSubtotal_incldisc_idr.DefaultCellStyle.BackColor = Color.Gainsboro
        cSubtotal_incldisc_idr.DefaultCellStyle.Format = "#,###,##0.00"
        cSubtotal_incldisc_idr.Visible = True
        cSubtotal_incldisc_idr.ReadOnly = True

        cSubtotal_incldisc_foreign.Name = "subtotal_incldisc_foreign"
        cSubtotal_incldisc_foreign.HeaderText = "SubtotalIncl.Disc Foreign"
        cSubtotal_incldisc_foreign.DataPropertyName = "subtotal_incldisc_foreign"
        cSubtotal_incldisc_foreign.Width = 150
        cSubtotal_incldisc_foreign.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cSubtotal_incldisc_foreign.DefaultCellStyle.BackColor = Color.Gainsboro
        cSubtotal_incldisc_foreign.DefaultCellStyle.Format = "#,###,##0.00"
        cSubtotal_incldisc_foreign.Visible = True
        cSubtotal_incldisc_foreign.ReadOnly = True

        cPph_amount_idr.Name = "pph_amount_idr"
        cPph_amount_idr.HeaderText = "PPh Amount IDR"
        cPph_amount_idr.DataPropertyName = "pph_amount_idr"
        cPph_amount_idr.Width = 120
        cPph_amount_idr.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cPph_amount_idr.DefaultCellStyle.BackColor = Color.Gainsboro
        cPph_amount_idr.DefaultCellStyle.Format = "#,###,##0.00"
        cPph_amount_idr.Visible = False
        cPph_amount_idr.ReadOnly = True

        cPph_amount_foreign.Name = "pph_amount_foreign"
        cPph_amount_foreign.HeaderText = "PPh Amount Foreign"
        cPph_amount_foreign.DataPropertyName = "pph_amount_foreign"
        cPph_amount_foreign.Width = 120
        cPph_amount_foreign.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cPph_amount_foreign.DefaultCellStyle.BackColor = Color.Gainsboro
        cPph_amount_foreign.DefaultCellStyle.Format = "#,###,##0.00"
        cPph_amount_foreign.Visible = False
        cPph_amount_foreign.ReadOnly = True

        cPpn_amount_idr.Name = "ppn_amount_idr"
        cPpn_amount_idr.HeaderText = "PPN Amount IDR"
        cPpn_amount_idr.DataPropertyName = "ppn_amount_idr"
        cPpn_amount_idr.Width = 120
        cPpn_amount_idr.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cPpn_amount_idr.DefaultCellStyle.BackColor = Color.Gainsboro
        cPpn_amount_idr.DefaultCellStyle.Format = "#,###,##0.00"
        cPpn_amount_idr.Visible = False
        cPpn_amount_idr.ReadOnly = True

        cPpn_amount_foreign.Name = "ppn_amount_foreign"
        cPpn_amount_foreign.HeaderText = "PPN Amount Foreign"
        cPpn_amount_foreign.DataPropertyName = "ppn_amount_foreign"
        cPpn_amount_foreign.Width = 120
        cPpn_amount_foreign.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cPpn_amount_foreign.DefaultCellStyle.BackColor = Color.Gainsboro
        cPpn_amount_foreign.DefaultCellStyle.Format = "#,###,##0.00"
        cPpn_amount_foreign.Visible = False
        cPpn_amount_foreign.ReadOnly = True

        cTotal.Name = "total"
        cTotal.HeaderText = "Total Order [Incl.Disc]" '"Subtotal[PPN,PPh,Disc]"
        cTotal.DataPropertyName = "total"
        cTotal.Width = 120
        cTotal.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cTotal.DefaultCellStyle.BackColor = Color.Gainsboro
        cTotal.DefaultCellStyle.Format = "#,###,##0.00"
        cTotal.Visible = True
        cTotal.ReadOnly = True

        cAmount.Name = "amount"
        cAmount.HeaderText = "Amount"
        cAmount.DataPropertyName = "amount"
        cAmount.Width = 120
        cAmount.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cAmount.DefaultCellStyle.BackColor = Color.Gainsboro
        cAmount.DefaultCellStyle.Format = "#,###,##0.00"
        cAmount.Visible = True
        cAmount.ReadOnly = True

        cAmount_order.Name = "amount_order"
        cAmount_order.HeaderText = "Amount Travel"
        cAmount_order.DataPropertyName = "amount_order"
        cAmount_order.Width = 120
        cAmount_order.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cAmount_order.DefaultCellStyle.BackColor = Color.Gainsboro
        cAmount_order.DefaultCellStyle.Format = "#,###,##0.00"
        cAmount_order.Visible = False
        cAmount_order.ReadOnly = True

        cAmount_sisa.Name = "amount_sisa"
        cAmount_sisa.HeaderText = "Amount Sisa"
        cAmount_sisa.DataPropertyName = "amount_sisa"
        cAmount_sisa.Width = 120
        cAmount_sisa.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cAmount_sisa.DefaultCellStyle.BackColor = Color.Gainsboro
        cAmount_sisa.DefaultCellStyle.Format = "#,###,##0.00"
        cAmount_sisa.Visible = False
        cAmount_sisa.ReadOnly = True


        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New DataGridViewColumn() _
        {cSelect, cOrder_id, cOrderdetil_line, _
        cOrderdetil_type, cItem_name, cCurrency_id, cCurrency_name, _
        cOrderdetil_qty, cOrderdetil_days, cOrderdetil_foreign, _
        cOrderdetil_foreignrate, _
        cBudget_id, cBudget_name, cBudgetdetil_id, _
        cBudgetdetil_name, _
        cOrderdetil_discount, _
        cSubtotal_incldisc_idr, cSubtotal_incldisc_foreign, _
        cPph_amount_idr, cPph_amount_foreign, cPpn_amount_idr, _
        cPpn_amount_foreign, cTotal, _
        cSubtotal_idr, cSubtotal_foreign, _
        cAmount_order, cAmount_sisa, cAmount})
        objDgv.AutoGenerateColumns = False
        objDgv.AllowUserToAddRows = False
        objDgv.AllowUserToDeleteRows = False


        For colIndex = 0 To objDgv.Columns.Count - 1
            objDgv.Columns(colIndex).SortMode = DataGridViewColumnSortMode.NotSortable
        Next
    End Function

#End Region

#Region " Opener "

    Public Shadows Function OpenDialog(ByVal owner As System.Windows.Forms.IWin32Window) As Object
        Me.myOwner = owner

        Dim oDataFiller As clsDataFiller = New clsDataFiller(Me.DSN)

        Me.AddReportList(Me.reports, "000", "-- PILIH --")
        Me.AddReportList(Me.reports, "NO", " General Order ")
        Me.AddReportList(Me.reports, "RO", " Rental Order ")
        Me.AddReportList(Me.reports, "MO", " Maintenance Order ")
        Me.AddReportList(Me.reports, "PO", " Purchase Order ")

        'Me.obj_Source.DataSource = Me.reports
        'Me.obj_Source.DisplayMember = "report_name"
        'Me.obj_Source.ValueMember = "report_id"

        Me.obj_Channel_id.Text = Me._ChannelID

        oDataFiller.DataFill(Me.tbl_MstRekanan, "ms_MstRekanan_Select2", "", Me._ChannelID)
        Me.tbl_MstRekanan.DefaultView.Sort = "rekanan_name"

        Me.FormatDgvTrnRequest(DgvTrnGoodsRq)
        Me.FormatDgvTrnRequestDetailDlg(DgvTrnGoodsRqDetil)

        Me.lbl_Inclpajak.Visible = False
        Me.lbl_order.Visible = False
        Me.lbl_amount.Visible = False
        Me.txt_total_amount.Visible = False
        Me.txt_total_amountIncl.Visible = False
        Me.txt_total_order.Visible = False

        Me.btnOK.Visible = False
        MyBase.ShowDialog(owner)

        Me.Cursor = Cursors.Arrow

        If Me.CloseButtonIsPressed Then
            Return retObj
        Else
            Return Nothing
        End If
    End Function

#End Region

    Private Sub btn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click, btnCancel.Click
        Dim obj As Button = sender
        Dim thisRetObj As Collection = New Collection
        '' ''Dim tblAdvanceHeader As DataTable = clsDataset.CreateTblTrnOrderforadvance()
        '' ''Dim tblAdvanceDetil As DataTable = clsDataset.CreateTblTrnOrderforadvance()
        '' ''Dim tblAdvance_itemDetil As DataTable = clsDataset.CreateTblTrnOrderforadvancedetil()

        If obj.Name = "btnOK" Then
            Dim rowInt As Integer = 0
            Dim row As DataRow
            Dim maxRow As Integer = DgvTrnGoodsRq.RowCount
            Dim i As Integer
            Dim col As Integer
            Dim columnName As String
            Dim oDataFiller As clsDataFiller = New clsDataFiller(Me.DSN)
            Dim criteria As String = String.Empty
            Dim amount_incl, amount, amount_order As Decimal

            ''''If Me._PROGRAMTYPE = "PG" Then

            Me.tbl_TrnAdvanceForOrder_temp.Clear()
            criteria = String.Format(" order_id = '{0}'", Me.DgvTrnGoodsRq.Rows(Me.DgvTrnGoodsRq.CurrentRow.Index).Cells("order_id").Value)

            oDataFiller.DataFill(Me.tbl_TrnAdvanceForOrder_temp, "lq_TrnAdvanceListTravelDialog_Select", criteria)

            Me.tbl_TrnAdvanceForHeader_result.Clear()
            row = Me.tbl_TrnAdvanceForHeader_result.NewRow
            For col = 0 To Me.tbl_TrnAdvanceForOrder_temp.Columns.Count - 2
                columnName = Me.tbl_TrnAdvanceForOrder_temp.Columns(col).ColumnName
                row(columnName) = Me.tbl_TrnAdvanceForOrder_temp.Rows(0).Item(columnName)
            Next
            Me.tbl_TrnAdvanceForHeader_result.Rows.Add(row)
            ''''retObj.tbl_request = Me.tbl_TrnAdvanceForOrder_result

            For i = 0 To DgvTrnGoodsRqDetil.RowCount - 1
                If Me.DgvTrnGoodsRqDetil.Rows(i).Cells("select").Value = 1 Then

                    '' ''If Me.tbl_TrnAdvanceForOrderDetil.Rows(i).Item("currency_id") = 1 Then
                    '' ''    amount_order += Me.tbl_TrnAdvanceForOrderDetil.Rows(i).Item("subtotal_idr")
                    '' ''Else
                    amount_order += Me.tbl_TrnAdvanceForOrderDetil.Rows(i).Item("amount_sisa")
                    ''''End If

                    amount_incl += clsUtil.IsDbNull(Me.DgvTrnGoodsRqDetil.Rows(i).Cells("total").Value, 0)
                    amount += clsUtil.IsDbNull(Me.DgvTrnGoodsRqDetil.Rows(i).Cells("amount").Value, 0)


                End If
            Next

            If Me.txt_total_amount.Text > amount_order Then
                MsgBox("Total Amount > Total Amount Order")
                Me.btnOK.Enabled = False
                Exit Sub
            Else
                Me.btnOK.Enabled = True
            End If

            Me.tbl_TrnAdvanceForTravelDetil_result.Clear()
            For i = 0 To DgvTrnGoodsRqDetil.RowCount - 1
                If Me.DgvTrnGoodsRqDetil.Rows(i).Cells("select").Value = 1 Then
                    row = Me.tbl_TrnAdvanceForTravelDetil_result.NewRow
                    For col = 0 To Me.tbl_TrnAdvanceForOrderDetil.Columns.Count - 1
                        columnName = Me.tbl_TrnAdvanceForOrderDetil.Columns(col).ColumnName
                        row(columnName) = Me.tbl_TrnAdvanceForOrderDetil.Rows(i).Item(columnName)
                    Next
                    Me.tbl_TrnAdvanceForTravelDetil_result.Rows.Add(row)
                End If
            Next

            Dim tbl_TrnAdvanceForOrder_result2 As DataTable = clsDataset.CreateTblTrnOrderforadvancedetil

            tbl_TrnAdvanceForOrder_result2.Clear()
            tbl_TrnAdvanceForOrder_result2 = Me.tbl_TrnAdvanceForHeader_result.Copy
            ''''retObj.tbl_requestdetil = Me.tbl_TrnAdvanceForOrderDetil_result
            ''''End If

            thisRetObj.Add(tbl_TrnAdvanceForHeader_result.Copy(), "tbl_TrnAdvanceForOrder_result")
            thisRetObj.Add(tbl_TrnAdvanceForOrder_result2.Copy(), "tbl_TrnAdvanceForOrder_result2")
            thisRetObj.Add(tbl_TrnAdvanceForTravelDetil_result.Copy(), "tbl_TrnAdvanceForOrderDetil_result")

            retObj = thisRetObj

            Me.CloseButtonIsPressed = True
            Me.Visible = False
        Else
            Me.CloseButtonIsPressed = False
        End If

        Me.Close()
    End Sub

    Public Sub New(ByVal strDSN As String, ByVal channel_id As String, ByVal strTravelID As String, ByVal strLine As String, ByVal strUsername As String)
        Me.DSN = strDSN
        Me._ChannelID = channel_id
        Me.OrderID = strTravelID
        Me.line = strLine
        Me._USERNAME = strUsername
        InitializeComponent()
    End Sub

    Private Sub DgvTrnGoodsRq_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvTrnGoodsRq.CellDoubleClick
        If e.ColumnIndex < 0 Or e.RowIndex < 0 Then
            Exit Sub
        End If
        If Me.DgvTrnGoodsRq.CurrentRow IsNot Nothing Then
            Me.ftabMain.SelectedIndex = 1
        End If
    End Sub

    Private Sub ftabMain_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ftabMain.SelectedIndexChanged
        Dim oDataFiller As New clsDataFiller(Me.DSN)
        Dim i As Integer
        Dim criteria As String = String.Empty
        Dim amount_incl, amount_order, amount As Decimal

        Select Case ftabMain.SelectedIndex
            Case 0
                'ftabMain_header

                Me.lbl_Inclpajak.Visible = False
                Me.lbl_order.Visible = False
                Me.lbl_amount.Visible = False
                Me.txt_total_amount.Visible = False
                Me.txt_total_amountIncl.Visible = False
                Me.txt_total_order.Visible = False

                Me.btnOK.Visible = False
            Case 1
                'ftabMain_detail
                If DgvTrnGoodsRq.Rows.Count > 0 Then
                    If OrderID = String.Empty Then
                        Me.lbl_Inclpajak.Visible = True
                        Me.lbl_order.Visible = True
                        Me.lbl_amount.Visible = True
                        Me.txt_total_amount.Visible = True
                        Me.txt_total_amountIncl.Visible = True
                        Me.txt_total_order.Visible = True

                        Me.btnOK.Visible = True
                        Me.tbl_TrnAdvanceForOrderDetil.Clear()
                        oDataFiller.DataFill(Me.tbl_TrnAdvanceForOrderDetil, "lq_TrnAdvanceListTravelDetilDialog_Select", String.Format("order_id = '{0}'", Me.DgvTrnGoodsRq.CurrentRow.Cells("order_id").Value))
                        Me.DgvTrnGoodsRqDetil.DataSource = Me.tbl_TrnAdvanceForOrderDetil

                        Me.DgvTrnGoodsRq.EndEdit()
                        Me.DgvTrnGoodsRqDetil.EndEdit()
                        For i = 0 To Me.DgvTrnGoodsRqDetil.Rows.Count - 1
                            Me.DgvTrnGoodsRqDetil.Rows(i).Cells("select").Value = 1

                            '' ''If Me.tbl_TrnAdvanceForOrderDetil.Rows(i).Item("currency_id") = 1 Then
                            Me.DgvTrnGoodsRqDetil.Rows(i).Cells("amount").Value = Me.tbl_TrnAdvanceForOrderDetil.Rows(i).Item("amount_sisa")
                            '' ''Else
                            '' ''    Me.DgvTrnGoodsRqDetil.Rows(i).Cells("amount").Value = Me.tbl_TrnAdvanceForOrderDetil.Rows(i).Item("subtotal_foreign")
                            '' ''End If

                            amount_incl += clsUtil.IsDbNull(Me.DgvTrnGoodsRqDetil.Rows(i).Cells("total").Value, 0)
                            amount += clsUtil.IsDbNull(Me.DgvTrnGoodsRqDetil.Rows(i).Cells("amount").Value, 0)
                            amount_order += Me.tbl_TrnAdvanceForOrderDetil.Rows(i).Item("amount_sisa")

                        Next

                        Me.txt_total_amountIncl.Text = Format(amount_incl, "#,##0.00")
                        Me.txt_total_order.Text = Format(amount_order, "#,##0.00")
                        Me.txt_total_amount.Text = Format(amount, "#,##0.00")


                    Else

                        Me.lbl_Inclpajak.Visible = True
                        Me.lbl_order.Visible = True
                        Me.lbl_amount.Visible = True
                        Me.txt_total_amount.Visible = True
                        Me.txt_total_amountIncl.Visible = True
                        Me.txt_total_order.Visible = True

                        Me.btnOK.Visible = True

                        Dim y As Integer
                        Dim b As Integer = 1
                        Dim lines As String = String.Empty
                        Dim liness As Integer
                        For y = 0 To (Len(line) / 3) - 1
                            liness = Mid(line, b, 3)
                            If lines = String.Empty Then
                                lines = liness
                            Else
                                lines = lines & ", " & liness
                            End If

                            b += 3

                        Next
                        ''

                        '' ''Me.tbl_TrnRequestDetilGoods.Clear()
                        '' ''oDataFiller.DataFill(Me.tbl_TrnRequestDetilGoods, "cq_TrnRequestDetil_Select", String.Format("transaksi_request.request_id = '{0}' AND requestdetil_objective = '{1}' AND requestdetil_line NOT in ( {2} ) AND (requestdetil_refreference = NULL OR requestdetil_refreference = '')", Me.DgvTrnGoodsRq.CurrentRow.Cells("request_id").Value, objective, lines))
                        '' ''Me.DgvTrnGoodsRqDetil.DataSource = Me.tbl_TrnRequestDetilGoods

                        Me.DgvTrnGoodsRq.EndEdit()
                        Me.DgvTrnGoodsRqDetil.EndEdit()
                        For i = 0 To Me.DgvTrnGoodsRqDetil.Rows.Count - 1
                            Me.DgvTrnGoodsRqDetil.Rows(i).Cells("select").Value = 1
                        Next
                    End If
                End If
        End Select
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Me.dlgTrnAdvanceDetilSelect_Load(Me._ChannelID) '(Me.getSetting("channel_id"))
        Me.DgvTrnGoodsRq.DataSource = Me.tbl_TrnAdvanceHeader
    End Sub

    Private Function dlgTrnAdvanceDetilSelect_Load(ByVal channel_id As String) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter
        Dim criteria = ""

        Dim txtSearchCriteria As String = ""
        Dim txtSQLSearch As String = String.Empty


        If Me.chkSearchJurnalID.Checked Then
            txtSearchCriteria = clsUtil.RefParser("order_id", Me.obj_jurnal_id)
            If txtSQLSearch = "" Then
                txtSQLSearch = " (" & txtSearchCriteria & ") "
            Else
                txtSQLSearch = txtSQLSearch & " AND " & " (" & txtSearchCriteria & ") "
            End If
        End If

        '-- Rekanan Search    
        If Me.chkRekanan.Checked Then
            txtSearchCriteria = String.Format(" rekanan_id = '{0}' ", Me.obj_Rekanan_id.Text)
            If txtSQLSearch = "" Then
                txtSQLSearch = " (" & txtSearchCriteria & ") "
            Else
                txtSQLSearch = txtSQLSearch & " AND " & " (" & txtSearchCriteria & ") "
            End If
        End If
        '--END 
        ''==
        If txtSQLSearch <> "" Then
            criteria = "channel_id = '" & Me._ChannelID & "' AND" & txtSQLSearch
        Else
            criteria = "channel_id = '" & Me._ChannelID & "'"
        End If

        criteria = criteria & " AND " & String.Format("order_createby='{0}'", Me._USERNAME)


        dbCmd = New OleDb.OleDbCommand("lq_TrnAdvanceListTravelDialog_Select", dbConn)
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarWChar)
        dbCmd.Parameters("@Criteria").Value = criteria

        dbCmd.CommandType = CommandType.StoredProcedure
        dbCmd.CommandTimeout = 0
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)
        Me.tbl_TrnAdvanceHeader.Clear()
        Dim cookie As Byte() = Nothing

        Try
            dbConn.Open()
            clsApplicationRole.SetAppRole(dbConn, cookie)
            dbDA.Fill(Me.tbl_TrnAdvanceHeader)

            Me.DgvTrnGoodsRq.DataSource = Me.tbl_TrnAdvanceHeader
        Catch ex As Exception
            MessageBox.Show(ex.Message, "dlgTrnAdvanceDetilSelect_Load" & ": dlgTrnAdvanceDetilSelect_Load()", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            clsApplicationRole.UnsetAppRole(dbConn, cookie)
            dbConn.Close()
        End Try


    End Function

    Private Function getSetting(ByVal setting_id As String) As String
        Dim frmOwner As uiBase = CType(Me.myOwner, uiBase)
        Return frmOwner.getSetting(setting_id)
    End Function

    Private Sub DgvTrnGoodsRqDetil_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvTrnGoodsRqDetil.CellValueChanged
        Select Case e.ColumnIndex
            Case Me.DgvTrnGoodsRqDetil.Columns("amount").Index
                Me.txt_total_amount.Text = Format(Me.GetTotalAmount(), "#,##0.00")
            Case Me.DgvTrnGoodsRqDetil.Columns("select").Index
                Me.txt_total_amount.Text = Format(Me.GetTotalAmount(), "#,##0.00")
        End Select
    End Sub

    Private Function GetTotalAmount() As Decimal
        Dim f As Integer
        Dim amount As Decimal

        For f = 0 To Me.DgvTrnGoodsRqDetil.Rows.Count - 1
            If clsUtil.IsDbNull(Me.DgvTrnGoodsRqDetil.Rows(f).Cells("select").Value, 0) = True Then
                amount += clsUtil.IsDbNull(Me.DgvTrnGoodsRqDetil.Rows(f).Cells("amount").Value, 0)
            End If
        Next

        Return amount
    End Function

    Private Sub btn_Rekanan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Rekanan.Click
        '' ''Dim rekanan_id As String
        '' ''Dim dlg As dlgSearch = New dlgSearch()
        '' ''Dim retData As String
        '' ''retData = dlg.OpenDialog(Me, Me.tbl_MstRekanan, "rekanan")
        '' ''rekanan_id = retData

        '' ''If rekanan_id IsNot Nothing Then
        '' ''    Me.obj_Rekanan_id.Text = rekanan_id
        '' ''End If

        Dim dlg As dlgSearch = New dlgSearch()
        Dim retData As Collection
        Dim retObj As Object
        Dim rekanan_id As String

        retObj = dlg.OpenDialog(Me, Me.tbl_MstRekanan, "rekanan")
        If retObj IsNot Nothing Then
            retData = CType(retObj, Collection)
            rekanan_id = CType(retData.Item("retId"), Decimal)
            Me.obj_Rekanan_id.Text = rekanan_id
        End If
    End Sub

    Private Sub DgvTrnGoodsRqDetil_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles DgvTrnGoodsRqDetil.CurrentCellDirtyStateChanged
        If Me.DgvTrnGoodsRqDetil.IsCurrentCellDirty Then
            Me.DgvTrnGoodsRqDetil.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub
End Class