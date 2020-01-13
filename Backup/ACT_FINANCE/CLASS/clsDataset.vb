' Yanuar Andriyana Putra
' TransTV
' 9/19/2010 9:41 PM

Public Class clsDataset
#Region " Transaction "
    Public Shared Function CreateTblTrnContract() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("contract_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("bank_name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("bank_account", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("bank_receivedby", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("currency_id", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("currency_name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("bank_amountidr", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("bank_amountforeign", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("bank_foreignrate", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("bank_foreign", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("bank_transferidr", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("bank_transferforeign", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("show_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("episode", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("artist", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("pv_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("pv_line", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("pv_amount", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("check", GetType(System.Boolean)))
        tbl.Columns.Add(New DataColumn("item_id", GetType(System.String)))
        ''-------------------------------
        ''Default Value: 
        'tbl.Columns("contract_id").DefaultValue = ""
        'tbl.Columns("bank_name").DefaultValue = ""
        'tbl.Columns("bank_account").DefaultValue = ""
        'tbl.Columns("bank_receivedby").DefaultValue = ""
        'tbl.Columns("currency_id").DefaultValue = 0
        'tbl.Columns("currency_name").DefaultValue = ""
        'tbl.Columns("bank_amountidr").DefaultValue = 0
        'tbl.Columns("bank_foreignrate").DefaultValue = 0
        'tbl.Columns("bank_foreign").DefaultValue = 0
        'tbl.Columns("bank_transferidr").DefaultValue = 0
        'tbl.Columns("bank_transferforeign").DefaultValue = 0
        'tbl.Columns("show_id").DefaultValue = ""
        'tbl.Columns("artist").DefaultValue = ""
        'tbl.Columns("pv_id").DefaultValue = 0
        'tbl.Columns("pv_line").DefaultValue = 0
        'tbl.Columns("pv_amount").DefaultValue = 0
        'tbl.Columns("check").DefaultValue = False
        Return tbl
    End Function
    Public Shared Function CreateTblTrnBanktransfer() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("banktransfer_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("jurnal_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("jurnaldetil_line", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("banktransfer_dt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("slipformat_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("rekanan_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("rekananbank_line", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("banktransfer_rekening", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("purposefund_id", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("paymenttype_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("banktransfer_pembayaranrek", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("banktransfer_idr", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("banktransfer_foreign", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("banktransfer_foreignrate", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("currency_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("banktransfer_bi_idr", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("banktransfer_bi_foreign", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("banktransfer_message", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("channel_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("banktransfer_isdisabled", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("banktransfer_invoice", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("banktransfer_episode1", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("banktransfer_episode2", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("project_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("rekananartis_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("banktransfer_episode", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("channelbank_line", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("banktransfer_create_by", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("banktransfer_create_date", GetType(System.DateTime)))

        'tambahan
        tbl.Columns.Add(New DataColumn("jurnalbilyet_receiveperson", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("jurnalbilyet_receiverekening", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("jurnalbilyet_receivebank", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("jurnalbilyet_receiveaccountname", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("rekening_debit", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("bank_debit", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("account_bank_debit", GetType(System.String))) 

        Return tbl
    End Function

    Public Shared Function CreateTblTrnBanktransfer2() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("ID Transfer", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("ID Jurnal", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("jurnaldetil_line", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("Transfer Date", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("Invoice", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("Receive By", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("Receive Rekening", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("Receive Bank", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("Rekanan Name Report", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("rekananbank_line", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("Penggunaan Dana", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("Payment Type", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("Project", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("Pengg. Dana", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("Curr", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("banktransfer_idr", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("banktransfer_foreignrate", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("banktransfer_foreign", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("banktransfer_bi_idr", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("banktransfer_bi_foreign", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("Total Transfer", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("eps", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("Create By", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("Create Date", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("rekening_debit", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("bank_debit", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("account_bank_debit", GetType(System.String))) 
        tbl.Columns.Add(New DataColumn("rekanan_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("paymenttype_id", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("banktransfer_isdisabled", GetType(System.Int32)))
        Return tbl
    End Function

    Public Shared Function CreateTblTrnCirculationvoucher() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("circulation_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("circulation_senddt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("circulation_sendto", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("circulation_foreign", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("circulation_amount", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("circulation_descr", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("jurnaltype_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("channel_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("circulation_appuser", GetType(System.Boolean)))
        tbl.Columns.Add(New DataColumn("circulation_appuserby", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("circulation_appuserdt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("circulation_status", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("circulation_totalrevisi", GetType(System.Int64)))
        tbl.Columns.Add(New DataColumn("entry_by", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("entry_dt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("modify_by", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("modify_dt", GetType(System.DateTime)))


        '-------------------------------
        'Default Value: 
        tbl.Columns("circulation_id").DefaultValue = ""
        tbl.Columns("circulation_senddt").DefaultValue = Now.Date
        tbl.Columns("circulation_sendto").DefaultValue = 0
        tbl.Columns("circulation_foreign").DefaultValue = 0
        tbl.Columns("circulation_amount").DefaultValue = 0
        tbl.Columns("circulation_descr").DefaultValue = ""
        tbl.Columns("jurnaltype_id").DefaultValue = ""
        tbl.Columns("channel_id").DefaultValue = ""
        tbl.Columns("circulation_appuser").DefaultValue = 0
        tbl.Columns("circulation_appuserby").DefaultValue = ""
        tbl.Columns("circulation_appuserdt").DefaultValue = DBNull.Value
        tbl.Columns("circulation_status").DefaultValue = ""
        tbl.Columns("circulation_totalrevisi").DefaultValue = 0
        tbl.Columns("entry_by").DefaultValue = ""
        tbl.Columns("entry_dt").DefaultValue = Now()
        tbl.Columns("modify_by").DefaultValue = ""
        tbl.Columns("modify_dt").DefaultValue = Now()


        Return tbl
    End Function
    Public Shared Function CreateTblTrnCirculationvoucherdetil() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("circulation_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("circulationdetil_line", GetType(System.Int64)))
        tbl.Columns.Add(New DataColumn("circulationdetil_reference", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("circulationdetil_bilyet", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("circulationdetil_rekanan", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("rekanan_name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("circulationdetil_descr", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("currency_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("circulationdetil_foreign", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("circulationdetil_rate", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("circulationdetil_amount", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("channel_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("circulationdetil_appdireksi", GetType(System.Boolean)))
        tbl.Columns.Add(New DataColumn("circulationdetil_appdireksi_by", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("circulationdetil_appdireksi_dt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("circulationdetil_appbayar", GetType(System.Boolean)))
        tbl.Columns.Add(New DataColumn("circulationdetil_appbayar_by", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("circulationdetil_appbayar_dt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("circulationdetil_appbankcair", GetType(System.Boolean)))
        tbl.Columns.Add(New DataColumn("circulationdetil_appbankcair_by", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("circulationdetil_appbankcair_dt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("circulationdetil_canceled", GetType(System.Boolean)))
        tbl.Columns.Add(New DataColumn("circulationdetil_canceledby", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("circulationdetil_canceleddt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("entry_by", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("entry_dt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("modify_by", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("modify_dt", GetType(System.DateTime)))


        '-------------------------------
        'Default Value: 
        tbl.Columns("circulation_id").DefaultValue = ""
        tbl.Columns("circulationdetil_line").DefaultValue = 0
        tbl.Columns("circulationdetil_reference").DefaultValue = ""
        tbl.Columns("circulationdetil_bilyet").DefaultValue = ""
        tbl.Columns("circulationdetil_rekanan").DefaultValue = 0
        tbl.Columns("rekanan_name").DefaultValue = String.Empty
        tbl.Columns("circulationdetil_descr").DefaultValue = ""
        tbl.Columns("currency_id").DefaultValue = 0
        tbl.Columns("circulationdetil_foreign").DefaultValue = 0
        tbl.Columns("circulationdetil_rate").DefaultValue = 0
        tbl.Columns("circulationdetil_amount").DefaultValue = 0
        tbl.Columns("channel_id").DefaultValue = ""
        tbl.Columns("circulationdetil_appdireksi").DefaultValue = 0
        tbl.Columns("circulationdetil_appdireksi_by").DefaultValue = ""
        tbl.Columns("circulationdetil_appdireksi_dt").DefaultValue = DBNull.Value
        tbl.Columns("circulationdetil_appbayar").DefaultValue = 0
        tbl.Columns("circulationdetil_appbayar_by").DefaultValue = ""
        tbl.Columns("circulationdetil_appbayar_dt").DefaultValue = DBNull.Value
        tbl.Columns("circulationdetil_appbankcair").DefaultValue = 0
        tbl.Columns("circulationdetil_appbankcair_by").DefaultValue = ""
        tbl.Columns("circulationdetil_appbankcair_dt").DefaultValue = DBNull.Value
        tbl.Columns("circulationdetil_canceled").DefaultValue = 0
        tbl.Columns("circulationdetil_canceledby").DefaultValue = ""
        tbl.Columns("circulationdetil_canceleddt").DefaultValue = DBNull.Value
        tbl.Columns("entry_by").DefaultValue = ""
        tbl.Columns("entry_dt").DefaultValue = Now()
        tbl.Columns("modify_by").DefaultValue = ""
        tbl.Columns("modify_dt").DefaultValue = Now()


        Return tbl
    End Function
    Public Shared Function CreateTblTrnJurnal() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("jurnal_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("jurnal_bookdate", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("jurnal_duedate", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("jurnal_billdate", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("jurnal_descr", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("jurnal_invoice_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("jurnal_invoice_descr", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("jurnal_source", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("jurnaltype_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("rekanan_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("periode_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("channel_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("budget_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("budget_name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("currency_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("currency_rate", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("strukturunit_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("acc_ca_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("region_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("branch_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("advertiser_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("brand_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("ae_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("jurnal_iscreated", GetType(System.Boolean)))
        tbl.Columns.Add(New DataColumn("jurnal_iscreatedby", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("jurnal_iscreatedate", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("jurnal_isposted", GetType(System.Boolean)))
        tbl.Columns.Add(New DataColumn("jurnal_ispostedby", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("jurnal_isposteddate", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("jurnal_isdisabled", GetType(System.Boolean)))
        tbl.Columns.Add(New DataColumn("jurnal_isdisabledby", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("jurnal_isdisableddt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("created_by", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("created_dt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("modified_by", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("modified_dt", GetType(System.DateTime)))


        '-------------------------------
        'Default Value: 
        tbl.Columns("jurnal_id").DefaultValue = ""
        tbl.Columns("jurnal_bookdate").DefaultValue = Now()
        tbl.Columns("jurnal_duedate").DefaultValue = Now()
        tbl.Columns("jurnal_billdate").DefaultValue = Now()
        tbl.Columns("jurnal_descr").DefaultValue = ""
        tbl.Columns("jurnal_invoice_id").DefaultValue = ""
        tbl.Columns("jurnal_invoice_descr").DefaultValue = ""
        tbl.Columns("jurnal_source").DefaultValue = ""
        tbl.Columns("jurnaltype_id").DefaultValue = ""
        tbl.Columns("rekanan_id").DefaultValue = 0
        tbl.Columns("periode_id").DefaultValue = ""
        tbl.Columns("channel_id").DefaultValue = ""
        tbl.Columns("budget_id").DefaultValue = 0
        tbl.Columns("budget_name").DefaultValue = "-- PILIH --"
        tbl.Columns("currency_id").DefaultValue = 0
        tbl.Columns("currency_rate").DefaultValue = 0
        tbl.Columns("strukturunit_id").DefaultValue = 0
        tbl.Columns("acc_ca_id").DefaultValue = 0
        tbl.Columns("region_id").DefaultValue = 0
        tbl.Columns("branch_id").DefaultValue = 0
        tbl.Columns("advertiser_id").DefaultValue = 0
        tbl.Columns("brand_id").DefaultValue = 0
        tbl.Columns("ae_id").DefaultValue = 0
        tbl.Columns("jurnal_iscreated").DefaultValue = 0
        tbl.Columns("jurnal_iscreatedby").DefaultValue = ""
        tbl.Columns("jurnal_iscreatedate").DefaultValue = Now()
        tbl.Columns("jurnal_isposted").DefaultValue = 0
        tbl.Columns("jurnal_ispostedby").DefaultValue = ""
        tbl.Columns("jurnal_isposteddate").DefaultValue = Now()
        tbl.Columns("jurnal_isdisabled").DefaultValue = 0
        tbl.Columns("jurnal_isdisabledby").DefaultValue = ""
        tbl.Columns("jurnal_isdisableddt").DefaultValue = Now()
        tbl.Columns("created_by").DefaultValue = ""
        tbl.Columns("created_dt").DefaultValue = Now()
        tbl.Columns("modified_by").DefaultValue = ""
        tbl.Columns("modified_dt").DefaultValue = Now()


        Return tbl
    End Function
    Public Shared Function CreateTblTrnJurnaldetil() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("jurnal_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("jurnaldetil_line", GetType(System.Int64)))
        tbl.Columns.Add(New DataColumn("jurnaldetil_dk", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("jurnaldetil_descr", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("rekanan_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("rekanan_name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("acc_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("currency_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("jurnaldetil_foreign", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("jurnaldetil_foreignrate", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("jurnaldetil_idr", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("channel_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("strukturunit_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("ref_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("ref_line", GetType(System.Int64)))
        tbl.Columns.Add(New DataColumn("ref_budgetline", GetType(System.Int64)))
        tbl.Columns.Add(New DataColumn("region_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("branch_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("budget_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("budget_name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("budgetdetil_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("budgetdetil_name", GetType(System.String)))

        '-------------------------------
        'Default Value: 
        tbl.Columns("jurnal_id").DefaultValue = ""
        tbl.Columns("jurnaldetil_line").DefaultValue = 0
        tbl.Columns("jurnaldetil_dk").DefaultValue = ""
        tbl.Columns("jurnaldetil_descr").DefaultValue = ""
        tbl.Columns("rekanan_id").DefaultValue = 0
        tbl.Columns("rekanan_name").DefaultValue = "-- PILIH --"
        tbl.Columns("acc_id").DefaultValue = "0"
        tbl.Columns("currency_id").DefaultValue = 0
        tbl.Columns("jurnaldetil_foreign").DefaultValue = 0
        tbl.Columns("jurnaldetil_foreignrate").DefaultValue = 0
        tbl.Columns("jurnaldetil_idr").DefaultValue = 0
        tbl.Columns("channel_id").DefaultValue = ""
        tbl.Columns("strukturunit_id").DefaultValue = 0
        tbl.Columns("ref_id").DefaultValue = ""
        tbl.Columns("ref_line").DefaultValue = 0
        tbl.Columns("ref_budgetline").DefaultValue = 0
        tbl.Columns("region_id").DefaultValue = 0
        tbl.Columns("branch_id").DefaultValue = 0
        tbl.Columns("budget_id").DefaultValue = 0
        tbl.Columns("budget_name").DefaultValue = "-- PILIH --"
        tbl.Columns("budgetdetil_id").DefaultValue = 0
        tbl.Columns("budgetdetil_name").DefaultValue = "-- PILIH --"

        Return tbl
    End Function
    Public Shared Function CreateTblTrnJurnaldetilBilyet() As DataTable
        Dim tbl As DataTable = CreateTblTrnJurnaldetil()

        tbl.Columns.Add(New DataColumn("paymenttype_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("jurnalbilyet_bank", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("jurnalbilyet_pic", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("jurnalbilyet_no", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("jurnalbilyet_date", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("jurnalbilyet_dateeffective", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("jurnalbilyet_receiveperson", GetType(System.String)))
        '
        'tambahan
        tbl.Columns.Add(New DataColumn("jurnalbilyet_receiverekening", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("jurnalbilyet_receivebank", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("jurnalbilyet_receiveaccountname", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("slipformat_id", GetType(System.String)))


        '-------------------------------
        'Default Value: 
        tbl.Columns("paymenttype_id").DefaultValue = "0"
        tbl.Columns("jurnalbilyet_bank").DefaultValue = 0
        tbl.Columns("jurnalbilyet_pic").DefaultValue = ""
        tbl.Columns("jurnalbilyet_no").DefaultValue = ""
        tbl.Columns("jurnalbilyet_date").DefaultValue = Now.Date
        tbl.Columns("jurnalbilyet_dateeffective").DefaultValue = Now.Date
        tbl.Columns("jurnalbilyet_receiveperson").DefaultValue = ""
        '
        'tambahan
        tbl.Columns("jurnalbilyet_receiverekening").DefaultValue = ""
        tbl.Columns("jurnalbilyet_receivebank").DefaultValue = ""
        tbl.Columns("jurnalbilyet_receiveaccountname").DefaultValue = ""
        tbl.Columns("slipformat_id").DefaultValue = "0"

        Return tbl
    End Function
    Public Shared Function CreateTblTrnJurnalreference() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("jurnal_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("jurnaldetil_line", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("jurnal_id_ref", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("jurnal_id_refline", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("jurnal_id_budgetline", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("referencetype", GetType(System.String)))

        tbl.Columns("jurnal_id").DefaultValue = String.Empty
        tbl.Columns("jurnaldetil_line").DefaultValue = 0
        tbl.Columns("jurnal_id_ref").DefaultValue = String.Empty
        tbl.Columns("jurnal_id_refline").DefaultValue = 0
        tbl.Columns("jurnal_id_budgetline").DefaultValue = 0
        tbl.Columns("referencetype").DefaultValue = String.Empty

        Return tbl
    End Function
    Public Shared Function CreateTblTrnJurnalreferencePayable() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("jurnal_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("jurnaldetil_line", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("ref", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("line", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("budget_line", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("descr", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("currency_name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("rate", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("amount_foreign", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("amount_idr", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("strukturunit_name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("channel_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("rekanan_name", GetType(System.String)))

        tbl.Columns("jurnal_id").DefaultValue = String.Empty
        tbl.Columns("jurnaldetil_line").DefaultValue = 0
        tbl.Columns("ref").DefaultValue = String.Empty
        tbl.Columns("line").DefaultValue = 0
        tbl.Columns("budget_line").DefaultValue = 0
        tbl.Columns("descr").DefaultValue = String.Empty
        tbl.Columns("currency_name").DefaultValue = String.Empty
        tbl.Columns("rate").DefaultValue = 0
        tbl.Columns("amount_foreign").DefaultValue = 0
        tbl.Columns("amount_idr").DefaultValue = 0
        tbl.Columns("strukturunit_name").DefaultValue = String.Empty
        tbl.Columns("channel_id").DefaultValue = String.Empty
        tbl.Columns("rekanan_name").DefaultValue = String.Empty

        Return tbl
    End Function

    Public Shared Function CreateTblJurnalPVreference() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("jurnal_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("jurnal_bookdate", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("jurnal_duedate", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("jurnal_billdate", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("jurnal_descr", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("jurnal_invoice_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("jurnal_invoice_descr", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("jurnal_source", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("jurnaltype_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("rekanan_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("periode_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("channel_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("budget_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("currency_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("currency_rate", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("strukturunit_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("acc_ca_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("region_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("branch_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("advertiser_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("brand_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("ae_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("jurnal_iscreated", GetType(System.Boolean)))
        tbl.Columns.Add(New DataColumn("jurnal_iscreatedby", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("jurnal_iscreatedate", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("jurnal_isposted", GetType(System.Boolean)))
        tbl.Columns.Add(New DataColumn("jurnal_ispostedby", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("jurnal_isposteddate", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("jurnal_isdisabled", GetType(System.Boolean)))
        tbl.Columns.Add(New DataColumn("jurnal_isdisabledby", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("jurnal_isdisableddt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("created_by", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("created_dt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("modified_by", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("modified_dt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("rekanan_name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("amount", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("pv_check", GetType(System.Boolean)))


        '-------------------------------
        'Default Value: 
        tbl.Columns("jurnal_id").DefaultValue = ""
        tbl.Columns("jurnal_bookdate").DefaultValue = Now()
        tbl.Columns("jurnal_duedate").DefaultValue = Now()
        tbl.Columns("jurnal_billdate").DefaultValue = Now()
        tbl.Columns("jurnal_descr").DefaultValue = ""
        tbl.Columns("jurnal_invoice_id").DefaultValue = ""
        tbl.Columns("jurnal_invoice_descr").DefaultValue = ""
        tbl.Columns("jurnal_source").DefaultValue = ""
        tbl.Columns("jurnaltype_id").DefaultValue = ""
        tbl.Columns("rekanan_id").DefaultValue = 0
        tbl.Columns("periode_id").DefaultValue = ""
        tbl.Columns("channel_id").DefaultValue = ""
        tbl.Columns("budget_id").DefaultValue = 0
        tbl.Columns("currency_id").DefaultValue = 0
        tbl.Columns("currency_rate").DefaultValue = 0
        tbl.Columns("strukturunit_id").DefaultValue = 0
        tbl.Columns("acc_ca_id").DefaultValue = 0
        tbl.Columns("region_id").DefaultValue = 0
        tbl.Columns("branch_id").DefaultValue = 0
        tbl.Columns("advertiser_id").DefaultValue = 0
        tbl.Columns("brand_id").DefaultValue = 0
        tbl.Columns("ae_id").DefaultValue = 0
        tbl.Columns("jurnal_iscreated").DefaultValue = 0
        tbl.Columns("jurnal_iscreatedby").DefaultValue = ""
        tbl.Columns("jurnal_iscreatedate").DefaultValue = Now()
        tbl.Columns("jurnal_isposted").DefaultValue = 0
        tbl.Columns("jurnal_ispostedby").DefaultValue = ""
        tbl.Columns("jurnal_isposteddate").DefaultValue = Now()
        tbl.Columns("jurnal_isdisabled").DefaultValue = 0
        tbl.Columns("jurnal_isdisabledby").DefaultValue = ""
        tbl.Columns("jurnal_isdisableddt").DefaultValue = Now()
        tbl.Columns("created_by").DefaultValue = ""
        tbl.Columns("created_dt").DefaultValue = Now()
        tbl.Columns("modified_by").DefaultValue = ""
        tbl.Columns("modified_dt").DefaultValue = Now()
        tbl.Columns("rekanan_name").DefaultValue = ""
        tbl.Columns("amount").DefaultValue = 0
        tbl.Columns("pv_check").DefaultValue = False


        Return tbl
    End Function
#End Region

#Region " Master "
    Public Shared Function CreateTblMstArtis() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("code", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("address", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("sex", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("active", GetType(System.Byte)))
        tbl.Columns.Add(New DataColumn("channel_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("entry_by", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("entry_date", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("modified_by", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("modified_date", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("type_id", GetType(System.String)))

        tbl.Columns("code").DefaultValue = String.Empty
        tbl.Columns("name").DefaultValue = String.Empty
        tbl.Columns("address").DefaultValue = String.Empty
        tbl.Columns("sex").DefaultValue = String.Empty
        tbl.Columns("active").DefaultValue = 0
        tbl.Columns("channel_id").DefaultValue = String.Empty
        tbl.Columns("entry_by").DefaultValue = String.Empty
        tbl.Columns("entry_date").DefaultValue = Now()
        tbl.Columns("modified_by").DefaultValue = String.Empty
        tbl.Columns("modified_date").DefaultValue = Now()
        tbl.Columns("type_id").DefaultValue = String.Empty


        Return tbl
    End Function
    Public Shared Function CreateTblMstArtisbank() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("artis_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("artisbank_line", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("artisbank_name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("artisbank_rekening", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("artisbank_accountname", GetType(System.String)))

        tbl.Columns("artis_id").DefaultValue = String.Empty
        tbl.Columns("artisbank_line").DefaultValue = 0
        tbl.Columns("artisbank_name").DefaultValue = String.Empty
        tbl.Columns("artisbank_rekening").DefaultValue = String.Empty
        tbl.Columns("artisbank_accountname").DefaultValue = String.Empty

        Return tbl
    End Function
    Public Shared Function CreateTblMstAuthsign() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("authsign_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("authsign_name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("authsign_shortname", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("authsign_position", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("authsign_isactive", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("authsign_login", GetType(System.Decimal)))

        tbl.Columns("authsign_id").DefaultValue = 0
        tbl.Columns("authsign_name").DefaultValue = String.Empty
        tbl.Columns("authsign_shortname").DefaultValue = String.Empty
        tbl.Columns("authsign_position").DefaultValue = String.Empty
        tbl.Columns("authsign_isactive").DefaultValue = 0
        tbl.Columns("authsign_login").DefaultValue = 0

        Return tbl
    End Function
    Public Shared Function CreateTblMstChannel() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("channel_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("channel_name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("channel_number", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("channel_namereport", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("channel_isdisabled", GetType(System.Boolean)))


        '-------------------------------
        'Default Value: 
        tbl.Columns("channel_id").DefaultValue = ""
        tbl.Columns("channel_name").DefaultValue = ""
        tbl.Columns("channel_number").DefaultValue = ""
        tbl.Columns("channel_namereport").DefaultValue = ""
        tbl.Columns("channel_isdisabled").DefaultValue = 0


        Return tbl
    End Function
    Public Shared Function CreateTblMstChannelBank() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("channel_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("channelbank_line", GetType(System.Int64)))
        tbl.Columns.Add(New DataColumn("channelbank_name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("channelbank_rekening", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("channelbank_accountname", GetType(System.String)))


        '-------------------------------
        'Default Value: 
        tbl.Columns("channel_id").DefaultValue = ""
        tbl.Columns("channelbank_line").DefaultValue = 0
        tbl.Columns("channelbank_name").DefaultValue = ""
        tbl.Columns("channelbank_rekening").DefaultValue = ""
        tbl.Columns("channelbank_accountname").DefaultValue = ""


        Return tbl
    End Function
    Public Shared Function CreateTblMstPeriode() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("periode_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("periode_name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("periode_datestart", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("periode_dateend", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("periode_isclosed", GetType(System.Boolean)))
        tbl.Columns.Add(New DataColumn("periode_createby", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("periode_createdate", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("periode_allowsaldoawalentry", GetType(System.Boolean)))

        '-------------------------------
        'Default Value: 
        tbl.Columns("periode_id").DefaultValue = ""
        tbl.Columns("periode_name").DefaultValue = ""
        tbl.Columns("periode_datestart").DefaultValue = Now.Date
        tbl.Columns("periode_dateend").DefaultValue = Now.Date
        tbl.Columns("periode_isclosed").DefaultValue = 0
        tbl.Columns("periode_createby").DefaultValue = ""
        tbl.Columns("periode_createdate").DefaultValue = Now()
        tbl.Columns("periode_allowsaldoawalentry").DefaultValue = 0


        Return tbl
    End Function
    Public Shared Function CreateTblMstRekananbank() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("rekanan_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("rekananbank_line", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("currency_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("rekananbank_account", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("rekananbank_name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("rekananbank_rekening", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("rekananbank_addr1", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("rekananbank_addr2", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("rekananbank_city", GetType(System.String)))

        tbl.Columns("rekanan_id").DefaultValue = 0
        tbl.Columns("rekananbank_line").DefaultValue = 0
        tbl.Columns("currency_id").DefaultValue = 0
        tbl.Columns("rekananbank_account").DefaultValue = String.Empty
        tbl.Columns("rekananbank_name").DefaultValue = String.Empty
        tbl.Columns("rekananbank_rekening").DefaultValue = String.Empty
        tbl.Columns("rekananbank_addr1").DefaultValue = String.Empty
        tbl.Columns("rekananbank_addr2").DefaultValue = String.Empty
        tbl.Columns("rekananbank_city").DefaultValue = String.Empty

        Return tbl
    End Function
    Public Shared Function CreateTblMstUser() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("username", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("strukturunit_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("user_position", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("user_fullname", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("user_isauthorized_toapprove", GetType(System.Byte)))

        '-------------------------------
        'Default Value: 
        tbl.Columns("username").DefaultValue = ""
        tbl.Columns("strukturunit_id").DefaultValue = 0
        tbl.Columns("user_position").DefaultValue = 0
        tbl.Columns("user_fullname").DefaultValue = ""
        tbl.Columns("user_isauthorized_toapprove").DefaultValue = 0

        Return tbl
    End Function

    '================================================== 
    ' Generated by DWRAD version 1.0.0.0
    ' Ari Prasasti
    ' TRANS TV

    ' Created Date: 4/20/2011 3:48:29 PM
    ' 

    Public Shared Function CreateTblMstBankacc() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("bankacc_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("bankacc_ac", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("bankacc_name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("bankacc_bank", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("currency_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("bankacc_descr", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("bankacc_telp", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("bankacc_fax", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("bankacc_branch", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("bankacc_address1", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("bankacc_address2", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("bankacc_active", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("bankacc_account", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("bankacc_createdt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("bankacc_createby", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("bankacc_reportname", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("bankacc_formbg", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("bankacc_formcek", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("bankacc_formtrf", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("bankacc_formset", GetType(System.String)))


        '-------------------------------
        'Default Value: 
        tbl.Columns("bankacc_id").DefaultValue = 0
        tbl.Columns("bankacc_ac").DefaultValue = ""
        tbl.Columns("bankacc_name").DefaultValue = ""
        tbl.Columns("bankacc_bank").DefaultValue = 0
        tbl.Columns("currency_id").DefaultValue = 0
        tbl.Columns("bankacc_descr").DefaultValue = ""
        tbl.Columns("bankacc_telp").DefaultValue = ""
        tbl.Columns("bankacc_fax").DefaultValue = ""
        tbl.Columns("bankacc_branch").DefaultValue = ""
        tbl.Columns("bankacc_address1").DefaultValue = ""
        tbl.Columns("bankacc_address2").DefaultValue = ""
        tbl.Columns("bankacc_active").DefaultValue = 0
        tbl.Columns("bankacc_account").DefaultValue = 0
        tbl.Columns("bankacc_createdt").DefaultValue = Now()
        tbl.Columns("bankacc_createby").DefaultValue = ""
        tbl.Columns("bankacc_reportname").DefaultValue = ""
        tbl.Columns("bankacc_formbg").DefaultValue = ""
        tbl.Columns("bankacc_formcek").DefaultValue = ""
        tbl.Columns("bankacc_formtrf").DefaultValue = ""
        tbl.Columns("bankacc_formset").DefaultValue = ""


        Return tbl
    End Function
    Public Shared Function CreateTblMstBank() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("bank_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("bank_name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("bank_active", GetType(System.Decimal)))


        '-------------------------------
        'Default Value: 
        tbl.Columns("bank_id").DefaultValue = 0
        tbl.Columns("bank_name").DefaultValue = ""
        tbl.Columns("bank_active").DefaultValue = 0


        Return tbl
    End Function
    Public Shared Function CreateTblMstBankacccontact() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("bankcontact_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("bankcontact_line", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("bankcontact_shortname", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("bankcontact_position", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("bankcontact_telp", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("bankcontact_fax", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("bankcontact_address1", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("bankcontact_address2", GetType(System.String)))


        '-------------------------------
        'Default Value: 
        tbl.Columns("bankcontact_id").DefaultValue = 0
        tbl.Columns("bankcontact_line").DefaultValue = 0
        tbl.Columns("bankcontact_shortname").DefaultValue = ""
        tbl.Columns("bankcontact_position").DefaultValue = ""
        tbl.Columns("bankcontact_telp").DefaultValue = ""
        tbl.Columns("bankcontact_fax").DefaultValue = ""
        tbl.Columns("bankcontact_address1").DefaultValue = ""
        tbl.Columns("bankcontact_address2").DefaultValue = ""


        Return tbl
    End Function
    Public Shared Function CreateTblMstCurrency() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("currency_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("currency_shortname", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("currency_name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("currency_country", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("currency_active", GetType(System.Decimal)))


        '-------------------------------
        'Default Value: 
        tbl.Columns("currency_id").DefaultValue = 0
        tbl.Columns("currency_shortname").DefaultValue = ""
        tbl.Columns("currency_name").DefaultValue = ""
        tbl.Columns("currency_country").DefaultValue = ""
        tbl.Columns("currency_active").DefaultValue = 0


        Return tbl
    End Function

    Public Shared Function CreateTblTrnVoid() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("void_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("void_date", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("created_by", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("created_dt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("modified_by", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("modified_dt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("approved_by", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("approved_dt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("posted_by", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("posted_dt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("channel_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("void_jurnaltype", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("void_approved", GetType(System.Boolean)))
        tbl.Columns.Add(New DataColumn("void_posted", GetType(System.Boolean)))


        '-------------------------------
        'Default Value: 
        tbl.Columns("void_id").DefaultValue = ""
        tbl.Columns("void_date").DefaultValue = Now()
        tbl.Columns("created_by").DefaultValue = ""
        tbl.Columns("created_dt").DefaultValue = DBNull.Value
        tbl.Columns("modified_by").DefaultValue = ""
        tbl.Columns("modified_dt").DefaultValue = DBNull.Value
        tbl.Columns("approved_by").DefaultValue = ""
        tbl.Columns("approved_dt").DefaultValue = DBNull.Value
        tbl.Columns("posted_by").DefaultValue = ""
        tbl.Columns("posted_dt").DefaultValue = DBNull.Value
        tbl.Columns("channel_id").DefaultValue = ""
        tbl.Columns("void_jurnaltype").DefaultValue = ""
        tbl.Columns("void_approved").DefaultValue = False
        tbl.Columns("void_posted").DefaultValue = False


        Return tbl
    End Function


    Public Shared Function CreateTblTrnVoidAdvance() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("void_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("void_line", GetType(System.Int64)))
        tbl.Columns.Add(New DataColumn("ref", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("rekanan", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("jurnal_descr", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("amount", GetType(System.Decimal)))


        '-------------------------------
        'Default Value: 
        tbl.Columns("void_id").DefaultValue = ""
        tbl.Columns("void_line").DefaultValue = 0
        tbl.Columns("ref").DefaultValue = ""
        tbl.Columns("rekanan").DefaultValue = ""
        tbl.Columns("jurnal_descr").DefaultValue = ""
        tbl.Columns("amount").DefaultValue = 0


        Return tbl
    End Function


    Public Shared Function CreateTblJurnalPVDetilReference() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("jurnal_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("jurnaldetil_line", GetType(System.Int64)))
        tbl.Columns.Add(New DataColumn("rekanan_name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("jurnaldetil_descr", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("jurnaldetil_idr", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("jurnalbilyet_no", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("ref_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("ref_line", GetType(System.Int64)))


        '-------------------------------
        'Default Value: 
        tbl.Columns("jurnal_id").DefaultValue = ""
        tbl.Columns("jurnaldetil_line").DefaultValue = 0
        tbl.Columns("rekanan_name").DefaultValue = ""
        tbl.Columns("jurnaldetil_descr").DefaultValue = ""
        tbl.Columns("jurnaldetil_idr").DefaultValue = 0
        tbl.Columns("jurnalbilyet_no").DefaultValue = ""
        tbl.Columns("ref_id").DefaultValue = ""
        tbl.Columns("ref_line").DefaultValue = 0


        Return tbl
    End Function
#End Region

#Region " Master ComboBox"
    Public Shared Function CreateTblMstAccountCaCombo() As DataTable
        Dim tbl As DataTable = New DataTable
        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("acc_ca_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("acc_ca_shortname", GetType(System.String)))

        tbl.Columns("acc_ca_id").DefaultValue = 0
        tbl.Columns("acc_ca_shortname").DefaultValue = String.Empty
        Return tbl
    End Function
    Public Shared Function CreateTblMstAccountCombo() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("acc_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("acc_name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("acc_nameshort", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("acc_isdisabled", GetType(System.Byte)))
        tbl.Columns.Add(New DataColumn("acc_isgroup", GetType(System.Byte)))

        tbl.Columns("acc_id").DefaultValue = String.Empty
        tbl.Columns("acc_name").DefaultValue = String.Empty
        tbl.Columns("acc_nameshort").DefaultValue = String.Empty
        tbl.Columns("acc_isdisabled").DefaultValue = 0
        tbl.Columns("acc_isgroup").DefaultValue = 0



        Return tbl
    End Function
    Public Shared Function CreateTblMstBankAccCombo() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("bankacc_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("bankacc_account", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("bankacc_reportname", GetType(System.String)))

        tbl.Columns("bankacc_id").DefaultValue = 0
        tbl.Columns("bankacc_account").DefaultValue = 0
        tbl.Columns("bankacc_reportname").DefaultValue = String.Empty

        Return tbl
    End Function
    Public Shared Function CreateTblMstBudgetCombo() As DataTable
        Dim tbl As DataTable = New DataTable
        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("budget_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("budget_name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("budget_nameshort", GetType(System.String)))
        '-------------------------------
        'Default Value: 
        tbl.Columns("budget_id").DefaultValue = 0
        tbl.Columns("budget_name").DefaultValue = ""
        tbl.Columns("budget_nameshort").DefaultValue = ""
        Return tbl
    End Function
    Public Shared Function CreateTblMstBudgetdetilCombo() As DataTable
        Dim tbl As DataTable = New DataTable
        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("budgetdetil_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("budget_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("budgetdetil_desc", GetType(System.String)))

        tbl.Columns("budgetdetil_id").DefaultValue = 0
        tbl.Columns("budget_id").DefaultValue = 0
        tbl.Columns("budgetdetil_desc").DefaultValue = String.Empty
        Return tbl
    End Function
    Public Shared Function CreateTblMstChannelCombo() As DataTable
        Dim tbl As DataTable = New DataTable
        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("channel_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("channel_name", GetType(System.String)))
        '-------------------------------
        'Default Value: 
        tbl.Columns("channel_id").DefaultValue = ""
        tbl.Columns("channel_name").DefaultValue = ""
        Return tbl
    End Function
    Public Shared Function CreateTblMstCurrencyCombo() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("currency_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("currency_shortname", GetType(System.String)))

        '-------------------------------
        'Default Value: 
        tbl.Columns("currency_id").DefaultValue = 0
        tbl.Columns("currency_shortname").DefaultValue = ""

        Return tbl
    End Function
    Public Shared Function CreateTblMstPaymenttypeCombo() As DataTable
        Dim tbl As DataTable = New DataTable
        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("paymenttype_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("paymenttype_name", GetType(System.String)))
        '-------------------------------
        'Default Value: 
        tbl.Columns("paymenttype_id").DefaultValue = "0"
        tbl.Columns("paymenttype_name").DefaultValue = ""
        Return tbl
    End Function
    Public Shared Function CreateTblMstPeriodeCombo() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("periode_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("periode_name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("periode_datestart", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("periode_dateend", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("periode_isclosed", GetType(System.Boolean)))
        '-------------------------------
        'Default Value: 
        tbl.Columns("periode_id").DefaultValue = ""
        tbl.Columns("periode_name").DefaultValue = ""
        tbl.Columns("periode_datestart").DefaultValue = Now()
        tbl.Columns("periode_dateend").DefaultValue = Now()
        tbl.Columns("periode_isclosed").DefaultValue = False
        Return tbl
    End Function
    Public Shared Function CreateTblMstPurposefundCombo() As DataTable
        Dim tbl As DataTable = New DataTable
        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("purposefund_id", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("purposefund_name", GetType(System.String)))

        tbl.Columns("purposefund_id").DefaultValue = 0
        tbl.Columns("purposefund_name").DefaultValue = String.Empty
        Return tbl
    End Function
    Public Shared Function CreateTblMstRekananCombo() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("rekanan_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("rekanan_name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("rekanan_namereport", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("rekanantype_id", GetType(System.Decimal)))

        tbl.Columns("rekanan_id").DefaultValue = 0
        tbl.Columns("rekanan_name").DefaultValue = String.Empty
        tbl.Columns("rekanan_namereport").DefaultValue = String.Empty
        tbl.Columns("rekanantype_id").DefaultValue = 0

        Return tbl
    End Function
    Public Shared Function CreateTblMstShowCombo() As DataTable
        Dim tbl As DataTable = New DataTable
        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("show_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("show_title", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("show_active", GetType(System.Boolean)))
        'Default Value: 
        tbl.Columns("show_id").DefaultValue = ""
        tbl.Columns("show_title").DefaultValue = ""
        tbl.Columns("show_active").DefaultValue = 0
        Return tbl
    End Function
    Public Shared Function CreateTblMstSlipformatCombo() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("slipformat_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("slipformat_name", GetType(System.String)))

        tbl.Columns("slipformat_id").DefaultValue = String.Empty
        tbl.Columns("slipformat_name").DefaultValue = String.Empty

        Return tbl
    End Function
    Public Shared Function CreateTblMstStrukturunitCombo() As DataTable
        Dim tbl As DataTable = New DataTable
        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("strukturunit_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("strukturunit_name", GetType(System.String)))
        '-------------------------------
        'Default Value: 
        tbl.Columns("strukturunit_id").DefaultValue = 0
        tbl.Columns("strukturunit_name").DefaultValue = ""
        Return tbl
    End Function
    Public Shared Function CreateTblMstUserCombo() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("username", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("user_fullname", GetType(System.String)))

        '-------------------------------
        'Default Value: 
        tbl.Columns("username").DefaultValue = ""
        tbl.Columns("user_fullname").DefaultValue = ""

        Return tbl
    End Function
#End Region
    Public Shared Function CreateTblMstSetting() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("setting_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("setting_value", GetType(System.String)))

        '-------------------------------
        'Default Value: 
        tbl.Columns("setting_id").DefaultValue = ""
        tbl.Columns("setting_value").DefaultValue = ""

        Return tbl
    End Function

    Public Shared Function CreateTblTrnBankentrydetil() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("bankentry_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("bankentrydetil_line", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("bankentrydetil_dk", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("bankentrydetil_descr", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("bankentrydetil_type", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("bankentrydetil_currency", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("bankentrydetil_rate", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("bankentrydetil_idr", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("bankentrydetil_foreign", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("bankentrydetil_refid", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("bankentrydetil_refline", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("bankentrydetil_bilyet", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("bankentrydetil_entryby", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("bankentrydetil_entrydt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("bankentrydetil_modifyby", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("bankentrydetil_modifydt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("channel_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("jurnaltype_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("acc_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("acc_ca_id", GetType(System.Decimal)))

        tbl.Columns("bankentry_id").DefaultValue = String.Empty
        tbl.Columns("bankentrydetil_line").DefaultValue = 0
        tbl.Columns("bankentrydetil_dk").DefaultValue = String.Empty
        tbl.Columns("bankentrydetil_descr").DefaultValue = String.Empty
        tbl.Columns("bankentrydetil_type").DefaultValue = 0
        tbl.Columns("bankentrydetil_currency").DefaultValue = 0
        tbl.Columns("bankentrydetil_rate").DefaultValue = 0
        tbl.Columns("bankentrydetil_idr").DefaultValue = 0
        tbl.Columns("bankentrydetil_foreign").DefaultValue = 0
        tbl.Columns("bankentrydetil_refid").DefaultValue = String.Empty
        tbl.Columns("bankentrydetil_refline").DefaultValue = 0
        tbl.Columns("bankentrydetil_bilyet").DefaultValue = String.Empty
        tbl.Columns("bankentrydetil_entryby").DefaultValue = String.Empty
        tbl.Columns("bankentrydetil_entrydt").DefaultValue = Now()
        tbl.Columns("bankentrydetil_modifyby").DefaultValue = String.Empty
        tbl.Columns("bankentrydetil_modifydt").DefaultValue = Now()
        tbl.Columns("channel_id").DefaultValue = String.Empty
        tbl.Columns("jurnaltype_id").DefaultValue = String.Empty
        tbl.Columns("acc_id").DefaultValue = 0
        tbl.Columns("acc_ca_id").DefaultValue = 0

        Return tbl
    End Function
End Class
