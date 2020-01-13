Public Class dlgTrnJurnal_PV_Select_VQ

    Private mDSN As String
    Private retObj As Object
    Private source As String
    Private dataFiller As Object

    Private mChannel_id As String
    Private myOwner As System.Windows.Forms.IWin32Window

    Private tbl_MstPeriode As DataTable = clsDataset.CreateTblMstPeriodeCombo()
    Private tbl_PVlist As DataTable = clsDataset.CreateTblJurnalPVreference()
    Private tbl_PVexport As DataTable = clsDataset.CreateTblJurnalPVreference()
    Private tbl_PVexport_detil As DataTable = clsDataset.CreateTblJurnalPVDetilReference()


#Region " Constructor & Default Function"
    Public Sub New(ByVal dsn As String)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.mDSN = dsn
    End Sub
    Public Shadows Function OpenDialog(ByVal owner As System.Windows.Forms.IWin32Window, _
                ByVal channel_id As String, ByRef x As Object, Optional ByVal source As String = "") As Object

        Me.mChannel_id = channel_id
        Me.source = source
        Me.dataFiller = x
        Me.myOwner = owner
        MyBase.ShowDialog(owner)
        Return retObj
    End Function
#End Region

#Region " Layout & Init UI "
    Private Function FormatDgvJurnalPVreference(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        Dim cJurnal_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnal_bookdate As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnal_duedate As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnal_billdate As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnal_descr As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnal_invoice_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnal_invoice_descr As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnal_source As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnaltype_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekanan_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cPeriode_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cChannel_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBudget_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cCurrency_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cCurrency_rate As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cStrukturunit_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAcc_ca_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRegion_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBranch_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAdvertiser_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBrand_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAe_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnal_iscreated As System.Windows.Forms.DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Dim cJurnal_iscreatedby As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnal_iscreatedate As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnal_isposted As System.Windows.Forms.DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Dim cJurnal_ispostedby As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnal_isposteddate As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnal_isdisabled As System.Windows.Forms.DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Dim cJurnal_isdisabledby As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnal_isdisableddt As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cCreated_by As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cCreated_dt As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cModified_by As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cModified_dt As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekanan_name As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAmount As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cPV_check As System.Windows.Forms.DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn

        cJurnal_id.Name = "jurnal_id"
        cJurnal_id.HeaderText = "ID Jurnal"
        cJurnal_id.DataPropertyName = "jurnal_id"
        cJurnal_id.Width = 100
        cJurnal_id.Visible = True
        cJurnal_id.ReadOnly = False

        cJurnal_bookdate.Name = "jurnal_bookdate"
        cJurnal_bookdate.HeaderText = "Book Date"
        cJurnal_bookdate.DataPropertyName = "jurnal_bookdate"
        cJurnal_bookdate.Width = 100
        cJurnal_bookdate.Visible = True
        cJurnal_bookdate.ReadOnly = False

        cJurnal_duedate.Name = "jurnal_duedate"
        cJurnal_duedate.HeaderText = "Due Date"
        cJurnal_duedate.DataPropertyName = "jurnal_duedate"
        cJurnal_duedate.Width = 100
        cJurnal_duedate.Visible = True
        cJurnal_duedate.ReadOnly = False

        cJurnal_billdate.Name = "jurnal_billdate"
        cJurnal_billdate.HeaderText = "Bill Date"
        cJurnal_billdate.DataPropertyName = "jurnal_billdate"
        cJurnal_billdate.Width = 100
        cJurnal_billdate.Visible = True
        cJurnal_billdate.ReadOnly = False

        cJurnal_descr.Name = "jurnal_descr"
        cJurnal_descr.HeaderText = "Description"
        cJurnal_descr.DataPropertyName = "jurnal_descr"
        cJurnal_descr.Width = 100
        cJurnal_descr.Visible = True
        cJurnal_descr.ReadOnly = False

        cJurnal_invoice_id.Name = "jurnal_invoice_id"
        cJurnal_invoice_id.HeaderText = "ID Invoice"
        cJurnal_invoice_id.DataPropertyName = "jurnal_invoice_id"
        cJurnal_invoice_id.Width = 100
        cJurnal_invoice_id.Visible = True
        cJurnal_invoice_id.ReadOnly = False

        cJurnal_invoice_descr.Name = "jurnal_invoice_descr"
        cJurnal_invoice_descr.HeaderText = "Invoice Name"
        cJurnal_invoice_descr.DataPropertyName = "jurnal_invoice_descr"
        cJurnal_invoice_descr.Width = 100
        cJurnal_invoice_descr.Visible = True
        cJurnal_invoice_descr.ReadOnly = False

        cJurnal_source.Name = "jurnal_source"
        cJurnal_source.HeaderText = "Source"
        cJurnal_source.DataPropertyName = "jurnal_source"
        cJurnal_source.Width = 100
        cJurnal_source.Visible = True
        cJurnal_source.ReadOnly = False

        cJurnaltype_id.Name = "jurnaltype_id"
        cJurnaltype_id.HeaderText = "ID Type"
        cJurnaltype_id.DataPropertyName = "jurnaltype_id"
        cJurnaltype_id.Width = 100
        cJurnaltype_id.Visible = True
        cJurnaltype_id.ReadOnly = False

        cRekanan_id.Name = "rekanan_id"
        cRekanan_id.HeaderText = "ID Rekanan"
        cRekanan_id.DataPropertyName = "rekanan_id"
        cRekanan_id.Width = 100
        cRekanan_id.Visible = True
        cRekanan_id.ReadOnly = False

        cPeriode_id.Name = "periode_id"
        cPeriode_id.HeaderText = "ID Periode"
        cPeriode_id.DataPropertyName = "periode_id"
        cPeriode_id.Width = 100
        cPeriode_id.Visible = True
        cPeriode_id.ReadOnly = False

        cChannel_id.Name = "channel_id"
        cChannel_id.HeaderText = "Channel"
        cChannel_id.DataPropertyName = "channel_id"
        cChannel_id.Width = 100
        cChannel_id.Visible = True
        cChannel_id.ReadOnly = False

        cBudget_id.Name = "budget_id"
        cBudget_id.HeaderText = "ID Budget"
        cBudget_id.DataPropertyName = "budget_id"
        cBudget_id.Width = 100
        cBudget_id.Visible = True
        cBudget_id.ReadOnly = False

        cCurrency_id.Name = "currency_id"
        cCurrency_id.HeaderText = "currency_id"
        cCurrency_id.DataPropertyName = "currency_id"
        cCurrency_id.Width = 100
        cCurrency_id.Visible = True
        cCurrency_id.ReadOnly = False

        cCurrency_rate.Name = "currency_rate"
        cCurrency_rate.HeaderText = "currency_rate"
        cCurrency_rate.DataPropertyName = "currency_rate"
        cCurrency_rate.Width = 100
        cCurrency_rate.Visible = True
        cCurrency_rate.ReadOnly = False

        cStrukturunit_id.Name = "strukturunit_id"
        cStrukturunit_id.HeaderText = "strukturunit_id"
        cStrukturunit_id.DataPropertyName = "strukturunit_id"
        cStrukturunit_id.Width = 100
        cStrukturunit_id.Visible = True
        cStrukturunit_id.ReadOnly = False

        cAcc_ca_id.Name = "acc_ca_id"
        cAcc_ca_id.HeaderText = "acc_ca_id"
        cAcc_ca_id.DataPropertyName = "acc_ca_id"
        cAcc_ca_id.Width = 100
        cAcc_ca_id.Visible = True
        cAcc_ca_id.ReadOnly = False

        cRegion_id.Name = "region_id"
        cRegion_id.HeaderText = "region_id"
        cRegion_id.DataPropertyName = "region_id"
        cRegion_id.Width = 100
        cRegion_id.Visible = True
        cRegion_id.ReadOnly = False

        cBranch_id.Name = "branch_id"
        cBranch_id.HeaderText = "branch_id"
        cBranch_id.DataPropertyName = "branch_id"
        cBranch_id.Width = 100
        cBranch_id.Visible = True
        cBranch_id.ReadOnly = False

        cAdvertiser_id.Name = "advertiser_id"
        cAdvertiser_id.HeaderText = "advertiser_id"
        cAdvertiser_id.DataPropertyName = "advertiser_id"
        cAdvertiser_id.Width = 100
        cAdvertiser_id.Visible = True
        cAdvertiser_id.ReadOnly = False

        cBrand_id.Name = "brand_id"
        cBrand_id.HeaderText = "brand_id"
        cBrand_id.DataPropertyName = "brand_id"
        cBrand_id.Width = 100
        cBrand_id.Visible = True
        cBrand_id.ReadOnly = False

        cAe_id.Name = "ae_id"
        cAe_id.HeaderText = "ae_id"
        cAe_id.DataPropertyName = "ae_id"
        cAe_id.Width = 100
        cAe_id.Visible = True
        cAe_id.ReadOnly = False

        cJurnal_iscreated.Name = "jurnal_iscreated"
        cJurnal_iscreated.HeaderText = "jurnal_iscreated"
        cJurnal_iscreated.DataPropertyName = "jurnal_iscreated"
        cJurnal_iscreated.Width = 100
        cJurnal_iscreated.Visible = True
        cJurnal_iscreated.ReadOnly = False

        cJurnal_iscreatedby.Name = "jurnal_iscreatedby"
        cJurnal_iscreatedby.HeaderText = "jurnal_iscreatedby"
        cJurnal_iscreatedby.DataPropertyName = "jurnal_iscreatedby"
        cJurnal_iscreatedby.Width = 100
        cJurnal_iscreatedby.Visible = True
        cJurnal_iscreatedby.ReadOnly = False

        cJurnal_iscreatedate.Name = "jurnal_iscreatedate"
        cJurnal_iscreatedate.HeaderText = "jurnal_iscreatedate"
        cJurnal_iscreatedate.DataPropertyName = "jurnal_iscreatedate"
        cJurnal_iscreatedate.Width = 100
        cJurnal_iscreatedate.Visible = True
        cJurnal_iscreatedate.ReadOnly = False

        cJurnal_isposted.Name = "jurnal_isposted"
        cJurnal_isposted.HeaderText = "jurnal_isposted"
        cJurnal_isposted.DataPropertyName = "jurnal_isposted"
        cJurnal_isposted.Width = 100
        cJurnal_isposted.Visible = True
        cJurnal_isposted.ReadOnly = False

        cJurnal_ispostedby.Name = "jurnal_ispostedby"
        cJurnal_ispostedby.HeaderText = "jurnal_ispostedby"
        cJurnal_ispostedby.DataPropertyName = "jurnal_ispostedby"
        cJurnal_ispostedby.Width = 100
        cJurnal_ispostedby.Visible = True
        cJurnal_ispostedby.ReadOnly = False

        cJurnal_isposteddate.Name = "jurnal_isposteddate"
        cJurnal_isposteddate.HeaderText = "jurnal_isposteddate"
        cJurnal_isposteddate.DataPropertyName = "jurnal_isposteddate"
        cJurnal_isposteddate.Width = 100
        cJurnal_isposteddate.Visible = True
        cJurnal_isposteddate.ReadOnly = False

        cJurnal_isdisabled.Name = "jurnal_isdisabled"
        cJurnal_isdisabled.HeaderText = "jurnal_isdisabled"
        cJurnal_isdisabled.DataPropertyName = "jurnal_isdisabled"
        cJurnal_isdisabled.Width = 100
        cJurnal_isdisabled.Visible = True
        cJurnal_isdisabled.ReadOnly = False

        cJurnal_isdisabledby.Name = "jurnal_isdisabledby"
        cJurnal_isdisabledby.HeaderText = "jurnal_isdisabledby"
        cJurnal_isdisabledby.DataPropertyName = "jurnal_isdisabledby"
        cJurnal_isdisabledby.Width = 100
        cJurnal_isdisabledby.Visible = True
        cJurnal_isdisabledby.ReadOnly = False

        cJurnal_isdisableddt.Name = "jurnal_isdisableddt"
        cJurnal_isdisableddt.HeaderText = "jurnal_isdisableddt"
        cJurnal_isdisableddt.DataPropertyName = "jurnal_isdisableddt"
        cJurnal_isdisableddt.Width = 100
        cJurnal_isdisableddt.Visible = True
        cJurnal_isdisableddt.ReadOnly = False

        cCreated_by.Name = "created_by"
        cCreated_by.HeaderText = "created_by"
        cCreated_by.DataPropertyName = "created_by"
        cCreated_by.Width = 100
        cCreated_by.Visible = True
        cCreated_by.ReadOnly = False

        cCreated_dt.Name = "created_dt"
        cCreated_dt.HeaderText = "created_dt"
        cCreated_dt.DataPropertyName = "created_dt"
        cCreated_dt.Width = 100
        cCreated_dt.Visible = True
        cCreated_dt.ReadOnly = False

        cModified_by.Name = "modified_by"
        cModified_by.HeaderText = "modified_by"
        cModified_by.DataPropertyName = "modified_by"
        cModified_by.Width = 100
        cModified_by.Visible = True
        cModified_by.ReadOnly = False

        cModified_dt.Name = "modified_dt"
        cModified_dt.HeaderText = "modified_dt"
        cModified_dt.DataPropertyName = "modified_dt"
        cModified_dt.Width = 100
        cModified_dt.Visible = True
        cModified_dt.ReadOnly = False

        cRekanan_name.Name = "rekanan_name"
        cRekanan_name.HeaderText = "Rekanan"
        cRekanan_name.DataPropertyName = "rekanan_name"
        cRekanan_name.Width = 100
        cRekanan_name.Visible = True
        cRekanan_name.ReadOnly = False

        cAmount.Name = "amount"
        cAmount.HeaderText = "Total Amount"
        cAmount.DataPropertyName = "amount"
        cAmount.Width = 100
        cAmount.Visible = True
        cAmount.ReadOnly = False

        cPV_check.Name = "pv_check"
        cPV_check.HeaderText = "pv_check"
        cPV_check.DataPropertyName = "pv_check"
        cPV_check.Width = 50
        cPV_check.Visible = True
        cPV_check.ReadOnly = True


        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
        {cJurnal_id, cJurnal_descr, cRekanan_name, cJurnal_bookdate, cJurnal_duedate, cJurnal_billdate, cJurnal_invoice_id, cJurnal_invoice_descr, cJurnal_source, cJurnaltype_id, cRekanan_id, cPeriode_id, cChannel_id, cBudget_id, cCurrency_id, cCurrency_rate, cStrukturunit_id, cAcc_ca_id, cRegion_id, cBranch_id, cAdvertiser_id, cBrand_id, cAe_id, cJurnal_iscreated, cJurnal_iscreatedby, cJurnal_iscreatedate, cJurnal_isposted, cJurnal_ispostedby, cJurnal_isposteddate, cJurnal_isdisabled, cJurnal_isdisabledby, cJurnal_isdisableddt, cCreated_by, cCreated_dt, cModified_by, cModified_dt, cPV_check, cAmount})

        objDgv.ReadOnly = True
        objDgv.AllowUserToAddRows = False
        objDgv.AllowUserToDeleteRows = False
        objDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect

    End Function

    Private Function FormatDgvJurnalPVDetilReference(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean

        Dim cJurnal_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnaldetil_line As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekanan_name As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnaldetil_descr As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnaldetil_idr As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnalbilyet_no As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRef_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRef_line As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn

        cJurnal_id.Name = "jurnal_id"
        cJurnal_id.HeaderText = "jurnal_id"
        cJurnal_id.DataPropertyName = "jurnal_id"
        cJurnal_id.Width = 100
        cJurnal_id.Visible = True
        cJurnal_id.ReadOnly = False

        cJurnaldetil_line.Name = "jurnaldetil_line"
        cJurnaldetil_line.HeaderText = "jurnaldetil_line"
        cJurnaldetil_line.DataPropertyName = "jurnaldetil_line"
        cJurnaldetil_line.Width = 100
        cJurnaldetil_line.Visible = True
        cJurnaldetil_line.ReadOnly = False

        cRekanan_name.Name = "rekanan_name"
        cRekanan_name.HeaderText = "rekanan_name"
        cRekanan_name.DataPropertyName = "rekanan_name"
        cRekanan_name.Width = 100
        cRekanan_name.Visible = True
        cRekanan_name.ReadOnly = False

        cJurnaldetil_descr.Name = "jurnaldetil_descr"
        cJurnaldetil_descr.HeaderText = "jurnaldetil_descr"
        cJurnaldetil_descr.DataPropertyName = "jurnaldetil_descr"
        cJurnaldetil_descr.Width = 100
        cJurnaldetil_descr.Visible = True
        cJurnaldetil_descr.ReadOnly = False

        cJurnaldetil_idr.Name = "jurnaldetil_idr"
        cJurnaldetil_idr.HeaderText = "jurnaldetil_idr"
        cJurnaldetil_idr.DataPropertyName = "jurnaldetil_idr"
        cJurnaldetil_idr.Width = 100
        cJurnaldetil_idr.Visible = True
        cJurnaldetil_idr.ReadOnly = False

        cJurnalbilyet_no.Name = "jurnalbilyet_no"
        cJurnalbilyet_no.HeaderText = "jurnalbilyet_no"
        cJurnalbilyet_no.DataPropertyName = "jurnalbilyet_no"
        cJurnalbilyet_no.Width = 100
        cJurnalbilyet_no.Visible = True
        cJurnalbilyet_no.ReadOnly = False

        cRef_id.Name = "ref_id"
        cRef_id.HeaderText = "ref_id"
        cRef_id.DataPropertyName = "ref_id"
        cRef_id.Width = 100
        cRef_id.Visible = True
        cRef_id.ReadOnly = False

        cRef_line.Name = "ref_line"
        cRef_line.HeaderText = "ref_line"
        cRef_line.DataPropertyName = "ref_line"
        cRef_line.Width = 100
        cRef_line.Visible = True
        cRef_line.ReadOnly = False

        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
        {cJurnal_id, cJurnaldetil_line, cRekanan_name, cJurnaldetil_descr, cJurnaldetil_idr, cJurnalbilyet_no, cRef_id, cRef_line})

        objDgv.ReadOnly = True
        objDgv.AllowUserToAddRows = False
        objDgv.AllowUserToDeleteRows = False
        objDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
    End Function

#End Region

#Region "User Defined Function"
    Private Function PV_Detil_Add(ByVal id As String)
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.mDSN)
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter
        Dim row As DataRow
        Dim i, col As Integer
        Dim columnName As String
        Dim tbl_pvexport_detildump As DataTable = clsDataset.CreateTblJurnalPVDetilReference()

        If id <> "" Then
            dbCmd = New OleDb.OleDbCommand("act_TrnVoid_PV_Detil_select", dbConn)
            dbCmd.Parameters.Add("@ID", OleDb.OleDbType.VarWChar)
            dbCmd.Parameters("@ID").Value = id
            dbCmd.CommandType = CommandType.StoredProcedure

            dbDA = New OleDb.OleDbDataAdapter(dbCmd)
            Try
                dbConn.Open()
                dbDA.Fill(tbl_pvexport_detildump)

                For i = 0 To tbl_pvexport_detildump.DefaultView.Count - 1
                    row = Me.tbl_PVexport_detil.NewRow()
                    For col = 0 To tbl_pvexport_detildump.Columns.Count - 1
                        columnName = tbl_pvexport_detildump.Columns(col).ColumnName
                        row(columnName) = tbl_pvexport_detildump.Rows(i).Item(columnName)
                    Next
                    tbl_PVexport_detil.Rows.Add(row)
                Next
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
        Return True
    End Function

    Private Function PV_Detil_Del(ByVal id As String)
        'Dim i As Integer
        Dim row As DataRow

        For Each row In Me.tbl_PVexport_detil.Rows
            If row.Item("jurnal_id") = id Then
                row.Delete()
                PV_Detil_Del(id)
                Exit For
            End If
        Next


        'For i = 0 To Me.tbl_PVexport_detil.DefaultView.Count - 1
        '    If Me.tbl_PVexport_detil.Rows(i).Item("jurnal_id") = id Then
        '        Me.tbl_PVexport_detil.Rows(i).Delete()
        '    End If
        'Next
        Return True
    End Function
#End Region

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        retObj = Nothing
        Me.Close()
    End Sub

    Private Sub dlgTrnJurnal_PV_Select_VQ_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dataFiller.ComboFill(Me.cbo_periodeSearch, "periode_id", "periode_name", Me.tbl_MstPeriode, "ms_MstPeriodeCombo_Select", "")
        Me.tbl_MstPeriode.DefaultView.Sort = "periode_id"

        Me.FormatDgvJurnalPVreference(Me.dgvExport)
        Me.FormatDgvJurnalPVreference(Me.dgvList)
        Me.FormatDgvJurnalPVDetilReference(Me.dgvExportDetil)
    End Sub

    Private Sub btnLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoad.Click
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.mDSN)
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter
        Dim criteria As String = ""

        Me.Cursor = Cursors.WaitCursor
        If Me.cbID.Checked And Me.txtID.Text <> "" = True Then
            criteria = clsUtil.RefParser("transaksi_jurnal.jurnal_id", Me.txtID)
        End If

        If chkSearchPeriode.Checked = True Then
            If criteria = "" Then
                criteria = String.Format(" periode_id = {0} ", Me.cbo_periodeSearch.SelectedValue)
            Else
                criteria &= String.Format(" AND periode_id = {0} ", Me.cbo_periodeSearch.SelectedValue)
            End If
        End If

        dbCmd = New OleDb.OleDbCommand("act_TrnVoid_PV_select", dbConn)
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarWChar)
        dbCmd.Parameters("@Criteria").Value = criteria

        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)
        Me.tbl_PVexport.Clear()
        Me.tbl_PVexport_detil.Clear()
        Me.tbl_PVlist.Clear()

        Try
            dbConn.Open()
            dbDA.Fill(Me.tbl_PVlist)
            Me.dgvList.DataSource = Me.tbl_PVlist
            Me.dgvExport.DataSource = Me.tbl_PVexport
            Me.dgvExportDetil.DataSource = Me.tbl_PVexport_detil
        Catch ex As Exception
            MessageBox.Show(ex.Message, "sl_media_select", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            dbConn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub dgvList_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvList.CellDoubleClick
        If e.ColumnIndex < 0 Or e.RowIndex < 0 Then
            Exit Sub
        End If
        If Me.dgvList.CurrentRow IsNot Nothing Then
            If clsUtil.IsDbNull(Me.dgvList.Rows(e.RowIndex).Cells("pv_check").Value, False) = False Then
                Dim row As DataRow
                Dim i, col As Integer
                Dim columnName As String

                If Me.tbl_PVlist.DefaultView.Count > 0 Then
                    For i = 0 To Me.tbl_PVlist.Rows.Count - 1
                        If Me.tbl_PVlist.Rows(i).Item("jurnal_id") = Me.dgvList.Rows(e.RowIndex).Cells("jurnal_id").Value Then
                            Me.tbl_PVlist.Rows(i).Item("pv_check") = True
                            row = Me.tbl_PVexport.NewRow()
                            For col = 0 To Me.tbl_PVlist.Columns.Count - 1
                                columnName = Me.tbl_PVlist.Columns(col).ColumnName
                                row(columnName) = Me.tbl_PVlist.Rows(i).Item(columnName)
                            Next
                            tbl_PVexport.Rows.Add(row)
                            Me.PV_Detil_Add(Me.tbl_PVlist.Rows(i).Item("jurnal_id"))
                            Exit For
                        End If
                    Next
                End If
            Else
                If Me.tbl_PVexport.DefaultView.Count > 0 Then
                    For i As Integer = 0 To Me.tbl_PVexport.Rows.Count - 1
                        If Me.tbl_PVexport.Rows(i).Item("jurnal_id") = Me.dgvList.Rows(e.RowIndex).Cells("jurnal_id").Value Then
                            Me.PV_Detil_Del(Me.tbl_PVexport.Rows(i).Item("jurnal_id"))
                            For x As Integer = 0 To Me.tbl_PVlist.Rows.Count - 1
                                If Me.tbl_PVlist.Rows(x).Item("jurnal_id") = Me.dgvList.Rows(e.RowIndex).Cells("jurnal_id").Value Then
                                    Me.tbl_PVlist.Rows(x).Item("pv_check") = False
                                    Exit For
                                End If
                            Next
                            tbl_PVexport.Rows(i).Delete()
                            Exit For
                        End If
                    Next
                End If
                'MsgBox("Ref ID sudah ada di list")
            End If
        End If
    End Sub

    Private Sub dgvList_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvList.CellFormatting
        Dim Selected As Boolean
        Dim obj As DataGridView = sender
        Dim objRow As System.Windows.Forms.DataGridViewRow = obj.Rows(e.RowIndex)
        Try
            Selected = CBool(objRow.Cells("pv_check").Value)
            If Selected Then
                objRow.DefaultCellStyle.BackColor = Color.PaleGreen
            Else
                objRow.DefaultCellStyle.BackColor = Color.White
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectAll.Click
        If Me.dgvList.RowCount > 0 Then
            Dim row As DataRow
            Dim i, col As Integer
            Dim columnName As String

            If Me.tbl_PVlist.DefaultView.Count > 0 Then
                For i = 0 To Me.tbl_PVlist.Rows.Count - 1
                    If Me.tbl_PVlist.Rows(i).Item("pv_check") = False Then
                        Me.tbl_PVlist.Rows(i).Item("pv_check") = True
                        row = Me.tbl_PVexport.NewRow()
                        For col = 0 To Me.tbl_PVlist.Columns.Count - 1
                            columnName = Me.tbl_PVlist.Columns(col).ColumnName
                            row(columnName) = Me.tbl_PVlist.Rows(i).Item(columnName)
                        Next
                        tbl_PVexport.Rows.Add(row)
                        Me.PV_Detil_Add(Me.tbl_PVlist.Rows(i).Item("jurnal_id"))
                    End If
                Next
            End If
        End If
    End Sub

    Private Sub btnRemoveAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveAll.Click
        Dim i As Integer
        If Me.dgvExport.RowCount > 0 Then
            If Me.tbl_PVexport.DefaultView.Count > 0 Then
                Me.tbl_PVexport.Clear()
            End If

            If Me.tbl_PVexport_detil.DefaultView.Count > 0 Then
                Me.tbl_PVexport_detil.Clear()
            End If

            For i = 0 To Me.tbl_PVlist.DefaultView.Count - 1
                'If Me.tbl_PVlist.Rows(i).Item("pv_check") = True Then
                Me.tbl_PVlist.Rows(i).Item("pv_check") = False
                'End If
            Next
        End If
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Dim tbl_adv_mst As DataTable = clsDataset.CreateTblTrnVoidAdvance()
        Dim tbl_adv_dtl As DataTable = clsDataset.CreateTblJurnalPVDetilReference()
        Dim row As DataRow
        Dim columnName As String
        Dim result As Collection = New Collection

        Dim i As Integer
        Me.BindingContext(Me.dgvExport).EndCurrentEdit()
        Me.BindingContext(Me.dgvExportDetil).EndCurrentEdit()

        For i = 0 To Me.tbl_PVexport.DefaultView.Count - 1
            row = tbl_adv_mst.NewRow()
            row.Item("void_id") = 0
            row.Item("ref") = clsUtil.IsDbNull(Me.tbl_PVexport.Rows(i).Item("jurnal_id"), "")
            row.Item("rekanan") = clsUtil.IsDbNull(Me.tbl_PVexport.Rows(i).Item("rekanan_name"), "")
            row.Item("jurnal_descr") = clsUtil.IsDbNull(Me.tbl_PVexport.Rows(i).Item("jurnal_descr"), "")
            row.Item("amount") = clsUtil.IsDbNull(Me.tbl_PVexport.Rows(i).Item("amount"), 0)
            tbl_adv_mst.Rows.Add(row)
        Next

        For i = 0 To Me.tbl_PVexport_detil.DefaultView.Count - 1
            row = tbl_adv_dtl.NewRow()
            For col As Integer = 0 To Me.tbl_PVexport_detil.Columns.Count - 1
                columnName = Me.tbl_PVexport_detil.Columns(col).ColumnName
                row(columnName) = Me.tbl_PVexport_detil.Rows(i).Item(columnName)
            Next
            tbl_adv_dtl.Rows.Add(row)
        Next

        result.Add(tbl_adv_mst.Copy(), "mst")
        result.Add(tbl_adv_dtl.Copy(), "dtl")
        retObj = result
        Me.Close()
    End Sub
End Class