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
        'tbl.Columns("modify_dt").DefaultValue = Now()


        Return tbl
    End Function

    Public Shared Function CreateTblTrnJurnal_withDocId() As DataTable
        Dim tbl As DataTable = CreateTblTrnJurnal()
        tbl.Columns.Add(New DataColumn("doc_id", GetType(System.String)))

        tbl.Columns("doc_id").DefaultValue = ""
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

    Public Shared Function CreateTblMstRekananbankWinner() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("rekanan_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("rekananbank_line", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("currency_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("rekananbank_account", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("rekananbank_name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("rekananbank_rekening", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("rekananbank_addr1", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("rekananbank_addr2", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("rekananbank_city", GetType(System.String)))

        tbl.Columns("rekanan_id").DefaultValue = ""
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
        tbl.Columns.Add(New DataColumn("channel_id", GetType(System.String)))
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
        tbl.Columns.Add(New DataColumn("acc_name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("bankacc_createdt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("bankacc_createby", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("bankacc_reportname", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("bankacc_formbg", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("bankacc_formcek", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("bankacc_formtrf", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("bankacc_formset", GetType(System.String)))


        '-------------------------------
        'Default Value: 
        tbl.Columns("channel_id").DefaultValue = ""
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
        tbl.Columns("acc_name").DefaultValue = ""
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
        tbl.Columns("bank_active").DefaultValue = 1


        Return tbl
    End Function

    Public Shared Function CreateTblMstBankacccontact() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("channel_id", GetType(System.String)))
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
        tbl.Columns("channel_id").DefaultValue = ""
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

    Public Shared Function CreateTblMstShow() As DataTable

        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("show_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("fokus_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("distributor_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("Package_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("show_title", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("show_eps", GetType(System.Int64)))
        tbl.Columns.Add(New DataColumn("show_run", GetType(System.Int64)))
        tbl.Columns.Add(New DataColumn("show_dur", GetType(System.Int64)))
        tbl.Columns.Add(New DataColumn("show_startdt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("show_enddt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("banner_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("tipeshow_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("category1_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("category2_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("show_lokal", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("show_sinopsisEng", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("show_sinopsisIna", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("amortisasi_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("currency_id", GetType(System.Int64)))
        tbl.Columns.Add(New DataColumn("show_amount", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("show_valas", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("show_kw", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("show_kwdate", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("show_active", GetType(System.Boolean)))
        tbl.Columns.Add(New DataColumn("show_lasttx", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("cass_id", GetType(System.String)))

        'Default Value: 
        tbl.Columns("show_id").DefaultValue = ""
        tbl.Columns("fokus_id").DefaultValue = ""
        tbl.Columns("distributor_id").DefaultValue = ""
        tbl.Columns("Package_id").DefaultValue = ""
        tbl.Columns("show_title").DefaultValue = ""
        tbl.Columns("show_eps").DefaultValue = 0
        tbl.Columns("show_run").DefaultValue = 0
        tbl.Columns("show_dur").DefaultValue = 0
        tbl.Columns("show_startdt").DefaultValue = Now()
        tbl.Columns("show_enddt").DefaultValue = Now()
        tbl.Columns("banner_id").DefaultValue = ""
        tbl.Columns("tipeshow_id").DefaultValue = ""
        tbl.Columns("category1_id").DefaultValue = ""
        tbl.Columns("category2_id").DefaultValue = ""
        tbl.Columns("show_lokal").DefaultValue = ""
        tbl.Columns("show_sinopsisEng").DefaultValue = ""
        tbl.Columns("show_sinopsisIna").DefaultValue = ""
        tbl.Columns("amortisasi_id").DefaultValue = ""
        tbl.Columns("currency_id").DefaultValue = 0
        tbl.Columns("show_amount").DefaultValue = 0
        tbl.Columns("show_valas").DefaultValue = 0
        tbl.Columns("show_kw").DefaultValue = ""
        tbl.Columns("show_kwdate").DefaultValue = Now()
        tbl.Columns("show_active").DefaultValue = 0
        tbl.Columns("show_lasttx").DefaultValue = Now()
        tbl.Columns("cass_id").DefaultValue = ""


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

    Public Shared Function CreateTblMstPurposefund() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("purposefund_id", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("purposefund_name", GetType(System.String)))

        tbl.Columns("purposefund_id").DefaultValue = 0
        tbl.Columns("purposefund_name").DefaultValue = String.Empty

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

    Public Shared Function CreateTblMstRekananWinner() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("rekanan_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("rekanan_name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("rekanan_namereport", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("rekanantype_id", GetType(System.Decimal)))

        tbl.Columns("rekanan_id").DefaultValue = String.Empty
        tbl.Columns("rekanan_name").DefaultValue = String.Empty
        tbl.Columns("rekanan_namereport").DefaultValue = String.Empty
        tbl.Columns("rekanantype_id").DefaultValue = 0

        Return tbl
    End Function

    Public Shared Function CreateTblMstSlipformat() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("slipformat_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("slipformat_name", GetType(System.String)))

        tbl.Columns("slipformat_id").DefaultValue = String.Empty
        tbl.Columns("slipformat_name").DefaultValue = String.Empty

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

    Public Shared Function CreateTblTrnBankentrydetilReference() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("bankentry_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("bankentrydetil_line", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("bankentry_date", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("bankacc_name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("jurnaldetil_dk", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("jurnaldetilref_foreign", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("jurnaldetilref_foreignrate", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("jurnaldetilref_idr", GetType(System.Decimal)))

        tbl.Columns("bankentry_id").DefaultValue = String.Empty
        tbl.Columns("bankentrydetil_line").DefaultValue = 0
        tbl.Columns("bankentry_date").DefaultValue = DBNull.Value
        tbl.Columns("bankacc_name").DefaultValue = String.Empty
        tbl.Columns("jurnaldetil_dk").DefaultValue = String.Empty
        tbl.Columns("jurnaldetilref_foreign").DefaultValue = 0
        tbl.Columns("jurnaldetilref_foreignrate").DefaultValue = 0
        tbl.Columns("jurnaldetilref_idr").DefaultValue = 0

        Return tbl
    End Function

    '=====tambahan===
    Public Shared Function CreateTblTrnJurnalDocument() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("channel_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("jurnal_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("doc_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("doc_status", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("post_by", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("post_dt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("unpost_by", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("unpost_dt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("void_by", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("void_dt", GetType(System.DateTime)))

        tbl.Columns("channel_id").DefaultValue = String.Empty
        tbl.Columns("jurnal_id").DefaultValue = String.Empty
        tbl.Columns("doc_id").DefaultValue = String.Empty
        tbl.Columns("doc_status").DefaultValue = String.Empty
        tbl.Columns("post_by").DefaultValue = String.Empty
        tbl.Columns("post_dt").DefaultValue = Now()
        tbl.Columns("unpost_by").DefaultValue = String.Empty
        tbl.Columns("unpost_dt").DefaultValue = Now()
        tbl.Columns("void_by").DefaultValue = String.Empty
        tbl.Columns("void_dt").DefaultValue = Now()

        Return tbl
    End Function

    Public Shared Function CreateTblMstAccCa() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()

        tbl.Columns.Add(New DataColumn("acc_ca_id", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("acc_ca_name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("acc_ca_shortname", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("acc_ca_type", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("acc_ca_mother", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("acc_ca_idx", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("acc_ca_active", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("acc_ca_entry_dt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("acc_ca_entry_by", GetType(System.Int32)))

        tbl.Columns("acc_ca_id").DefaultValue = 0
        tbl.Columns("acc_ca_name").DefaultValue = String.Empty
        tbl.Columns("acc_ca_shortname").DefaultValue = String.Empty
        tbl.Columns("acc_ca_type").DefaultValue = 0
        tbl.Columns("acc_ca_mother").DefaultValue = DBNull.Value
        tbl.Columns("acc_ca_idx").DefaultValue = DBNull.Value
        tbl.Columns("acc_ca_active").DefaultValue = 1
        tbl.Columns("acc_ca_entry_dt").DefaultValue = Now()
        tbl.Columns("acc_ca_entry_by").DefaultValue = 0

        Return tbl
    End Function

    Public Shared Function CreateTblMstCa() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("code", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("row", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("seq", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("descr", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("remark", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("fbold", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("fline", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("fitalic", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("fprint", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("fsaldo", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("code_group", GetType(System.String)))


        '-------------------------------
        'Default Value: 
        tbl.Columns("code").DefaultValue = 0
        tbl.Columns("row").DefaultValue = 0
        tbl.Columns("seq").DefaultValue = 0
        tbl.Columns("descr").DefaultValue = ""
        tbl.Columns("remark").DefaultValue = ""
        tbl.Columns("fbold").DefaultValue = 0
        tbl.Columns("fline").DefaultValue = 0
        tbl.Columns("fitalic").DefaultValue = 0



        Return tbl
    End Function

    Public Shared Function CreateTblMstCa_detil() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("code", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("row", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("line", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("descr", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("ac_start", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("ac_end", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("sign", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("ytd", GetType(System.Decimal)))


        '-------------------------------
        'Default Value: 
        tbl.Columns("code").DefaultValue = 0
        tbl.Columns("row").DefaultValue = 0
        tbl.Columns("line").DefaultValue = 0
        tbl.Columns("descr").DefaultValue = ""
        tbl.Columns("ac_start").DefaultValue = ""
        tbl.Columns("ac_end").DefaultValue = ""
        tbl.Columns("sign").DefaultValue = 0
        tbl.Columns("ytd").DefaultValue = 0


        Return tbl
    End Function

    Public Shared Function CreateTblMstCaType() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("Code", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("Name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("Create_by", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("Create_dt", GetType(System.DateTime)))

        '-------------------------------
        'Default Value: 
        tbl.Columns("Code").DefaultValue = 0
        tbl.Columns("Name").DefaultValue = ""
        tbl.Columns("Create_by").DefaultValue = 0
        tbl.Columns("Create_dt").DefaultValue = Now()

        Return tbl
    End Function

    Public Shared Function CreateTblMstAcc() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("acc_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("acc_name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("acc_nameshort", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("acc_descr", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("acc_isgroup", GetType(System.Boolean)))
        tbl.Columns.Add(New DataColumn("acc_parent", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("acc_path", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("acc_isdisabled", GetType(System.Boolean)))
        tbl.Columns.Add(New DataColumn("acc_ismonetary", GetType(System.Boolean)))
        tbl.Columns.Add(New DataColumn("acc_createby", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("acc_createdate", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("accsubgroup_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("accaging_type", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("acctype_id", GetType(System.Decimal)))
        '-------------------------------
        'Default Value: 
        tbl.Columns("acc_id").DefaultValue = ""
        tbl.Columns("acc_name").DefaultValue = ""
        tbl.Columns("acc_nameshort").DefaultValue = ""
        tbl.Columns("acc_descr").DefaultValue = ""
        tbl.Columns("acc_isgroup").DefaultValue = 0
        tbl.Columns("acc_parent").DefaultValue = "0"
        tbl.Columns("acc_path").DefaultValue = ""
        tbl.Columns("acc_isdisabled").DefaultValue = 0
        tbl.Columns("acc_ismonetary").DefaultValue = 0
        tbl.Columns("acc_createby").DefaultValue = ""
        tbl.Columns("acc_createdate").DefaultValue = Now.Date()
        tbl.Columns("accsubgroup_id").DefaultValue = 0
        tbl.Columns("accaging_type").DefaultValue = ""
        tbl.Columns("acctype_id").DefaultValue = 0
        Return tbl
    End Function

    Public Shared Function CreateTblJurnalInvoice() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("jurnal_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("jurnal_line", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("tandaterima_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("tandaterima_line", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("tandaterima_invoiceno", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("currency_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("amount_foreign", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("amount_foreignrate", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("amount_idr", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("create_by", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("create_dt", GetType(System.DateTime)))
        '-------------------------------
        'Default Value: 
        tbl.Columns("jurnal_id").DefaultValue = ""
        tbl.Columns("jurnal_line").DefaultValue = 0
        tbl.Columns("tandaterima_id").DefaultValue = ""
        tbl.Columns("tandaterima_line").DefaultValue = 0
        tbl.Columns("tandaterima_invoiceno").DefaultValue = ""
        tbl.Columns("currency_id").DefaultValue = "0"
        tbl.Columns("amount_foreign").DefaultValue = 0
        tbl.Columns("amount_foreignrate").DefaultValue = 0
        tbl.Columns("amount_idr").DefaultValue = 0
        tbl.Columns("create_by").DefaultValue = ""
        tbl.Columns("create_dt").DefaultValue = Now.Date()
        Return tbl
    End Function

    Public Shared Function CreateTblListCaAccountJurnalPV() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("channel_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("jurnal_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("jurnal_bookdate", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("jurnaldetil_descr", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("acc_ca_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("acc_ca_descr", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("rekanan_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("rekanan_name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("jurnal_id_ref", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("budget_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("budget_name", GetType(System.String)))
        '-------------------------------
        'Default Value: 
        tbl.Columns("jurnal_id").DefaultValue = ""
        tbl.Columns("jurnal_bookdate").DefaultValue = Now.Date()
        tbl.Columns("jurnaldetil_descr").DefaultValue = ""
        tbl.Columns("acc_ca_id").DefaultValue = ""
        tbl.Columns("acc_ca_descr").DefaultValue = ""
        tbl.Columns("rekanan_id").DefaultValue = ""
        tbl.Columns("rekanan_name").DefaultValue = ""
        tbl.Columns("jurnal_id_ref").DefaultValue = ""
        tbl.Columns("budget_id").DefaultValue = ""
        tbl.Columns("budget_name").DefaultValue = ""
        Return tbl
    End Function

    Public Shared Function CreateTblTrnJurnalReferenceRevalAP() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("reval_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("reval_line", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("descr", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("currency_name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("amount_foreign", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("rate", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("amount_idr", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("refreval", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("refreval_line", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("channel_id", GetType(System.String)))

        tbl.Columns("reval_id").DefaultValue = String.Empty
        tbl.Columns("reval_line").DefaultValue = 0
        tbl.Columns("descr").DefaultValue = String.Empty
        tbl.Columns("currency_name").DefaultValue = String.Empty
        tbl.Columns("amount_foreign").DefaultValue = 0
        tbl.Columns("rate").DefaultValue = 0
        tbl.Columns("amount_idr").DefaultValue = 0
        tbl.Columns("refreval").DefaultValue = String.Empty
        tbl.Columns("refreval_line").DefaultValue = 0
        tbl.Columns("channel_id").DefaultValue = String.Empty


        Return tbl
    End Function

    Public Shared Function CreateTblMstAccDK() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("id", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("jurnal_source", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("acc_id_debet", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("acc_id_kredit", GetType(System.String)))


        tbl.Columns("id").DefaultValue = 0
        tbl.Columns("jurnal_source").DefaultValue = String.Empty
        tbl.Columns("acc_id_debet").DefaultValue = String.Empty
        tbl.Columns("acc_id_kredit").DefaultValue = String.Empty

        Return tbl
    End Function

    Public Shared Function CreateTblTrnAdvance() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("advance_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("advance_descr", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("advance_modifieddt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("advance_modifiedby", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("strukturunit_id_dest", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("budget_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("advance_prepareby", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("advance_prepareloc", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("advance_preparedt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("advance_userpic", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("advance_usedby", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("advance_status", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("source_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("type_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("channel_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("strukturunit_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("rekanan_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("currency_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("advance_foreignrate", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("advance_entrydt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("advance_entryby", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("advance_foreignreal", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("advance_ordered", GetType(System.Byte)))
        tbl.Columns.Add(New DataColumn("advance_pathfile", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("advance_programtype", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("advance_epsstart", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("advance_epsend", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("advance_approved1", GetType(System.Byte)))
        tbl.Columns.Add(New DataColumn("advance_approved1dt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("advance_approved1by", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("advance_approved2", GetType(System.Byte)))
        tbl.Columns.Add(New DataColumn("advance_approved2dt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("advance_approved2by", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("advance_canceled", GetType(System.Byte)))
        tbl.Columns.Add(New DataColumn("advance_reference", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("advance_type", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("receivedDoc_by", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("receivedDoc_date", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("receivedDoc_app", GetType(System.Byte)))
        tbl.Columns.Add(New DataColumn("advance_approvedproc", GetType(System.Byte)))
        tbl.Columns.Add(New DataColumn("advance_approvedbma", GetType(System.Byte)))
        tbl.Columns.Add(New DataColumn("advance_timeremain", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("amount_itemdetil", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("advance_idrreal", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("advance_idrrealuser", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("advance_subtotal", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("advance_singlebudget", GetType(System.Byte)))

        tbl.Columns("advance_id").DefaultValue = String.Empty
        tbl.Columns("advance_descr").DefaultValue = String.Empty
        tbl.Columns("advance_modifieddt").DefaultValue = Now()
        tbl.Columns("advance_modifiedby").DefaultValue = String.Empty
        tbl.Columns("strukturunit_id_dest").DefaultValue = String.Empty
        tbl.Columns("budget_id").DefaultValue = 0
        tbl.Columns("advance_prepareby").DefaultValue = String.Empty
        tbl.Columns("advance_prepareloc").DefaultValue = String.Empty
        tbl.Columns("advance_preparedt").DefaultValue = Now()
        tbl.Columns("advance_usedby").DefaultValue = String.Empty
        tbl.Columns("advance_userpic").DefaultValue = String.Empty
        tbl.Columns("advance_status").DefaultValue = "BARU"
        tbl.Columns("source_id").DefaultValue = String.Empty
        tbl.Columns("type_id").DefaultValue = String.Empty
        tbl.Columns("channel_id").DefaultValue = String.Empty
        tbl.Columns("strukturunit_id").DefaultValue = String.Empty
        tbl.Columns("rekanan_id").DefaultValue = 0
        tbl.Columns("currency_id").DefaultValue = String.Empty
        tbl.Columns("advance_foreignrate").DefaultValue = 1
        tbl.Columns("advance_entrydt").DefaultValue = Now()
        tbl.Columns("advance_entryby").DefaultValue = String.Empty
        tbl.Columns("advance_foreignreal").DefaultValue = 0
        tbl.Columns("advance_ordered").DefaultValue = 0
        tbl.Columns("advance_pathfile").DefaultValue = String.Empty
        tbl.Columns("advance_programtype").DefaultValue = String.Empty
        tbl.Columns("advance_epsstart").DefaultValue = 0
        tbl.Columns("advance_epsend").DefaultValue = 0
        tbl.Columns("advance_approved1").DefaultValue = 0
        tbl.Columns("advance_approved1dt").DefaultValue = Now()
        tbl.Columns("advance_approved1by").DefaultValue = String.Empty
        tbl.Columns("advance_approved2").DefaultValue = 0
        tbl.Columns("advance_approved2dt").DefaultValue = Now()
        tbl.Columns("advance_approved2by").DefaultValue = String.Empty
        tbl.Columns("advance_canceled").DefaultValue = 0
        tbl.Columns("advance_reference").DefaultValue = String.Empty
        tbl.Columns("advance_type").DefaultValue = "0"
        tbl.Columns("receivedDoc_by").DefaultValue = String.Empty
        tbl.Columns("receivedDoc_date").DefaultValue = Now()
        tbl.Columns("receivedDoc_app").DefaultValue = 0
        tbl.Columns("advance_approvedproc").DefaultValue = 0
        tbl.Columns("advance_approvedbma").DefaultValue = 0
        tbl.Columns("advance_timeremain").DefaultValue = String.Empty
        tbl.Columns("amount_itemdetil").DefaultValue = 0
        tbl.Columns("advance_idrreal").DefaultValue = 0
        tbl.Columns("advance_idrrealuser").DefaultValue = 0
        tbl.Columns("advance_subtotal").DefaultValue = 0
        tbl.Columns("advance_singlebudget").DefaultValue = 0

        Return tbl
    End Function

    Public Shared Function CreateTblTrnAdvancedetil() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("advance_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("advancedetil_line", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("advancedetil_type", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("advancedetil_descr", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("requestdetil_idr", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("currency_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("advancedetil_foreignrate", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("channel_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("strukturunit_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("advancedetil_foreignreal", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("advancedetil_ordered", GetType(System.Byte)))
        tbl.Columns.Add(New DataColumn("advancedetil_refreference", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("advancedetil_idrreal", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("advancedetil_approvedbma", GetType(System.Byte)))
        tbl.Columns.Add(New DataColumn("advancedetil_approvedbmadt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("advancedetil_approvedbmaby", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("advancedetil_approveddescr", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("username", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("advancedetil_paymentdt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("advancedetil_paymenttype", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("advancedetil_subtotal", GetType(System.Decimal)))

        tbl.Columns.Add(New DataColumn("bma_approved", GetType(System.Byte)))
        tbl.Columns.Add(New DataColumn("bma_approveddt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("bma_approvedby", GetType(System.String)))

        tbl.Columns.Add(New DataColumn("advancedetil_canceled", GetType(System.Byte)))
        tbl.Columns.Add(New DataColumn("advancedetil_canceleddt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("advancedetil_canceledby", GetType(System.String)))

        tbl.Columns.Add(New DataColumn("status_over", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("status_memobook", GetType(System.Byte)))
        tbl.Columns.Add(New DataColumn("id_memo", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("on_proses", GetType(System.Byte)))

        tbl.Columns("advance_id").DefaultValue = String.Empty
        tbl.Columns("advancedetil_line").DefaultValue = 0
        tbl.Columns("advancedetil_type").DefaultValue = 1
        tbl.Columns("currency_id").DefaultValue = 0
        tbl.Columns("advancedetil_foreignrate").DefaultValue = 0
        tbl.Columns("channel_id").DefaultValue = String.Empty
        tbl.Columns("strukturunit_id").DefaultValue = 0
        tbl.Columns("advancedetil_foreignreal").DefaultValue = 0
        tbl.Columns("advancedetil_ordered").DefaultValue = 0
        tbl.Columns("advancedetil_refreference").DefaultValue = String.Empty
        tbl.Columns("advancedetil_idrreal").DefaultValue = 0
        tbl.Columns("advancedetil_approvedbma").DefaultValue = 0
        tbl.Columns("advancedetil_approvedbmadt").DefaultValue = Now()
        tbl.Columns("advancedetil_approvedbmaby").DefaultValue = String.Empty
        tbl.Columns("advancedetil_approveddescr").DefaultValue = String.Empty
        tbl.Columns("username").DefaultValue = String.Empty
        tbl.Columns("advancedetil_paymentdt").DefaultValue = Now()
        tbl.Columns("advancedetil_paymenttype").DefaultValue = String.Empty
        tbl.Columns("advancedetil_subtotal").DefaultValue = 0

        tbl.Columns("bma_approved").DefaultValue = 0
        tbl.Columns("bma_approveddt").DefaultValue = Now()
        tbl.Columns("bma_approvedby").DefaultValue = String.Empty

        tbl.Columns("advancedetil_canceled").DefaultValue = 0
        tbl.Columns("advancedetil_canceleddt").DefaultValue = DBNull.Value
        tbl.Columns("advancedetil_canceledby").DefaultValue = String.Empty

        tbl.Columns("status_over").DefaultValue = String.Empty
        tbl.Columns("status_memobook").DefaultValue = 0
        tbl.Columns("id_memo").DefaultValue = String.Empty
        tbl.Columns("on_proses").DefaultValue = 0

        Return tbl
    End Function

    Public Shared Function CreateTblTrnAdvanceItemDetil() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("advance_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("advancedetil_line", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("budgetdetil_line", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("advancedetil_type", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("budget_name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("currency_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("budgetdetil_eps", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("budgetdetil_days", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("acc_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("channel_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("strukturunit_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("amount_advance", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("budget_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("budgetdetil_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("budgetdetil_name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("advancedetil_foreignrate", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("amount_idrreal", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("amount_budget", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("budget_accum", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("outstanding_budget", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("outstanding_approved", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("outstanding_check", GetType(System.Boolean)))
        tbl.Columns.Add(New DataColumn("amount_approvebma", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("advance_isrequest", GetType(System.Byte)))
        tbl.Columns.Add(New DataColumn("advance_requestid", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("amount_settlement", GetType(System.Decimal)))

        tbl.Columns.Add(New DataColumn("pph_persen_settlement", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("pph_amountforeign_settlement", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("pph_amount_settlement", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("ppn_persen_settlement", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("ppn_amountforeign_settlement", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("ppn_amount_settlement", GetType(System.Decimal)))

        tbl.Columns.Add(New DataColumn("amount_discount_settlement", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("amount_intercompany_settlement", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("amount_settlement_nettforeign", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("amount_settlement_nett", GetType(System.Decimal)))


        tbl.Columns.Add(New DataColumn("amount_settlementreimburseforeign", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("amount_settlementreimburse", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("amount_settlementrefundforeign", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("amount_settlementrefund", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("settlement_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("username", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("settlement_rate", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("settlement_foreign", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("account", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("advance_isreimburse", GetType(System.Byte)))
        tbl.Columns.Add(New DataColumn("advance_reimburseid", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("advancedetil_fromsettlement", GetType(System.Byte)))

        tbl.Columns.Add(New DataColumn("advancedetil_discount", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("pph_persen", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("ppn_persen", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("pph_amount", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("ppn_amount", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("amount_subtotalforeign", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("amount_subtotal", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("faktur_id", GetType(System.String)))

        tbl.Columns.Add(New DataColumn("amount_intercompany", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("advance_requestid_line", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("outstanding_settlement", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("budget_accumRequest", GetType(System.Decimal)))
        '''' tambahan 02-01-2011
        tbl.Columns.Add(New DataColumn("amount_bpj", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("status_memobook", GetType(System.Byte)))
        tbl.Columns.Add(New DataColumn("id_memo", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("on_proses", GetType(System.Byte)))

        tbl.Columns("advance_id").DefaultValue = String.Empty
        tbl.Columns("advancedetil_line").DefaultValue = 0
        tbl.Columns("budgetdetil_line").DefaultValue = 0
        tbl.Columns("advancedetil_type").DefaultValue = 1
        tbl.Columns("budget_name").DefaultValue = String.Empty
        tbl.Columns("currency_id").DefaultValue = String.Empty
        tbl.Columns("budgetdetil_eps").DefaultValue = String.Empty
        tbl.Columns("budgetdetil_days").DefaultValue = 0
        tbl.Columns("acc_id").DefaultValue = String.Empty
        tbl.Columns("channel_id").DefaultValue = String.Empty
        tbl.Columns("strukturunit_id").DefaultValue = 0
        tbl.Columns("amount_advance").DefaultValue = 0
        tbl.Columns("budget_id").DefaultValue = 0
        tbl.Columns("budgetdetil_id").DefaultValue = 0
        tbl.Columns("budgetdetil_name").DefaultValue = String.Empty
        tbl.Columns("advancedetil_foreignrate").DefaultValue = 0
        tbl.Columns("amount_idrreal").DefaultValue = 0
        tbl.Columns("amount_budget").DefaultValue = 0
        tbl.Columns("budget_accum").DefaultValue = 0
        tbl.Columns("outstanding_budget").DefaultValue = 0
        tbl.Columns("outstanding_approved").DefaultValue = 0
        tbl.Columns("outstanding_check").DefaultValue = False
        tbl.Columns("amount_approvebma").DefaultValue = 0
        tbl.Columns("advance_isrequest").DefaultValue = False
        tbl.Columns("advance_requestid").DefaultValue = String.Empty
        tbl.Columns("amount_settlement").DefaultValue = 0

        tbl.Columns("pph_persen_settlement").DefaultValue = 0
        tbl.Columns("pph_amountforeign_settlement").DefaultValue = 0
        tbl.Columns("pph_amount_settlement").DefaultValue = 0
        tbl.Columns("ppn_persen_settlement").DefaultValue = 0
        tbl.Columns("ppn_amountforeign_settlement").DefaultValue = 0
        tbl.Columns("ppn_amount_settlement").DefaultValue = 0

        tbl.Columns("amount_discount_settlement").DefaultValue = 0
        tbl.Columns("amount_intercompany_settlement").DefaultValue = 0
        tbl.Columns("amount_settlement_nettforeign").DefaultValue = 0
        tbl.Columns("amount_settlement_nett").DefaultValue = 0

        tbl.Columns("settlement_id").DefaultValue = String.Empty
        tbl.Columns("username").DefaultValue = String.Empty
        tbl.Columns("settlement_rate").DefaultValue = 0
        ' ''tbl.Columns("settlement_currency").DefaultValue = String.Empty
        tbl.Columns("settlement_foreign").DefaultValue = 0
        tbl.Columns("account").DefaultValue = String.Empty
        tbl.Columns("advance_isreimburse").DefaultValue = 0
        tbl.Columns("advance_reimburseid").DefaultValue = String.Empty
        tbl.Columns("advancedetil_fromsettlement").DefaultValue = 0
        tbl.Columns("amount_settlementreimburseforeign").DefaultValue = 0
        tbl.Columns("amount_settlementreimburse").DefaultValue = 0
        tbl.Columns("amount_settlementrefundforeign").DefaultValue = 0
        tbl.Columns("amount_settlementrefund").DefaultValue = 0

        tbl.Columns("advancedetil_discount").DefaultValue = 0
        tbl.Columns("pph_persen").DefaultValue = 0
        tbl.Columns("ppn_persen").DefaultValue = 0
        tbl.Columns("pph_amount").DefaultValue = 0
        tbl.Columns("ppn_amount").DefaultValue = 0
        tbl.Columns("amount_subtotalforeign").DefaultValue = 0
        tbl.Columns("amount_subtotal").DefaultValue = 0
        tbl.Columns("faktur_id").DefaultValue = String.Empty

        tbl.Columns("amount_intercompany").DefaultValue = 0
        tbl.Columns("advance_requestid_line").DefaultValue = 0
        tbl.Columns("outstanding_settlement").DefaultValue = 0
        tbl.Columns("budget_accumRequest").DefaultValue = 0

        tbl.Columns("amount_bpj").DefaultValue = 0
        tbl.Columns("status_memobook").DefaultValue = 0
        tbl.Columns("id_memo").DefaultValue = String.Empty
        tbl.Columns("on_proses").DefaultValue = 0

        Return tbl
    End Function

    Public Shared Function CreateTblTrnPrintAdvanceListOrder() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("advance_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("advancedetil_line", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("budgetdetil_line", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("order_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("orderdetil_qty", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("amount_advance", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("advancedetil_foreignrate", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("advancedetil_discount", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("pph_persen", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("ppn_persen", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("amount_subtotal", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("amount_intercompany", GetType(System.Decimal)))

        tbl.Columns("advance_id").DefaultValue = String.Empty
        tbl.Columns("advancedetil_line").DefaultValue = 0
        tbl.Columns("budgetdetil_line").DefaultValue = 0
        tbl.Columns("order_id").DefaultValue = String.Empty
        tbl.Columns("orderdetil_qty").DefaultValue = 0
        tbl.Columns("amount_advance").DefaultValue = 0
        tbl.Columns("advancedetil_foreignrate").DefaultValue = 0
        tbl.Columns("advancedetil_discount").DefaultValue = 0
        tbl.Columns("pph_persen").DefaultValue = 0
        tbl.Columns("ppn_persen").DefaultValue = 0
        tbl.Columns("amount_subtotal").DefaultValue = 0
        tbl.Columns("amount_intercompany").DefaultValue = 0

        Return tbl
    End Function

    Public Shared Function CreateTblFromUDTableTypes(ByVal dsn As String, ByVal table_name As String) As DataTable
        Try
            Dim objTbl As DataTable = New DataTable
            Dim Query1 As clsDataFiller = New clsDataFiller(dsn)

            Query1.DataFillQuery2(objTbl, String.Format("SELECT c.name, t.name as type_data, c.max_length " + _
                                                "FROM sys.columns c LEFT JOIN sys.types t ON t.system_type_id = c.system_type_id AND c.user_type_id = t.user_type_id " + _
                                                "WHERE object_id IN (SELECT type_table_object_id FROM sys.table_types WHERE name = '{0}');", table_name))

            Dim tbl As DataTable = New DataTable
            tbl.Columns.Clear()

            For Each dtRow As DataRow In objTbl.Rows
                If dtRow.Item("type_data").ToString = "bigint" Then
                    tbl.Columns.Add(New DataColumn(dtRow.Item("name").ToString, GetType(Int64)))
                ElseIf dtRow.Item("type_data").ToString = "binary" Then
                    tbl.Columns.Add(New DataColumn(dtRow.Item("name").ToString, GetType(Byte)))
                ElseIf dtRow.Item("type_data").ToString = "bit" Then
                    tbl.Columns.Add(New DataColumn(dtRow.Item("name").ToString, GetType(Boolean)))
                ElseIf dtRow.Item("type_data").ToString = "date" Then
                    tbl.Columns.Add(New DataColumn(dtRow.Item("name").ToString, GetType(Date)))
                ElseIf dtRow.Item("type_data").ToString = "bit" Then
                    tbl.Columns.Add(New DataColumn(dtRow.Item("name").ToString, GetType(Boolean)))
                ElseIf dtRow.Item("type_data").ToString = "decimal" Then
                    tbl.Columns.Add(New DataColumn(dtRow.Item("name").ToString, GetType(Decimal)))
                ElseIf dtRow.Item("type_data").ToString = "float" Then
                    tbl.Columns.Add(New DataColumn(dtRow.Item("name").ToString, GetType(Double)))
                ElseIf dtRow.Item("type_data").ToString = "int" Then
                    tbl.Columns.Add(New DataColumn(dtRow.Item("name").ToString, GetType(Int64)))
                ElseIf dtRow.Item("type_data").ToString = "money" Then
                    tbl.Columns.Add(New DataColumn(dtRow.Item("name").ToString, GetType(Decimal)))
                ElseIf dtRow.Item("type_data").ToString = "nchar" Then
                    tbl.Columns.Add(New DataColumn(dtRow.Item("name").ToString, GetType(String)))
                ElseIf dtRow.Item("type_data").ToString = "ntext" Then
                    tbl.Columns.Add(New DataColumn(dtRow.Item("name").ToString, GetType(String)))
                ElseIf dtRow.Item("type_data").ToString = "numeric" Then
                    tbl.Columns.Add(New DataColumn(dtRow.Item("name").ToString, GetType(Int64)))
                ElseIf dtRow.Item("type_data").ToString = "nvarchar" Then
                    tbl.Columns.Add(New DataColumn(dtRow.Item("name").ToString, GetType(String)))
                ElseIf dtRow.Item("type_data").ToString = "smalldatetime" Then
                    tbl.Columns.Add(New DataColumn(dtRow.Item("name").ToString, GetType(DateTime)))
                ElseIf dtRow.Item("type_data").ToString = "datetime" Then
                    tbl.Columns.Add(New DataColumn(dtRow.Item("name").ToString, GetType(DateTime)))
                ElseIf dtRow.Item("type_data").ToString = "smallint" Then
                    tbl.Columns.Add(New DataColumn(dtRow.Item("name").ToString, GetType(Int16)))
                ElseIf dtRow.Item("type_data").ToString = "text" Then
                    tbl.Columns.Add(New DataColumn(dtRow.Item("name").ToString, GetType(String)))
                ElseIf dtRow.Item("type_data").ToString = "timestamp" Then
                    tbl.Columns.Add(New DataColumn(dtRow.Item("name").ToString, GetType(Byte)))
                ElseIf dtRow.Item("type_data").ToString = "tinyint" Then
                    tbl.Columns.Add(New DataColumn(dtRow.Item("name").ToString, GetType(Byte)))
                ElseIf dtRow.Item("type_data").ToString = "real" Then
                    tbl.Columns.Add(New DataColumn(dtRow.Item("name").ToString, GetType(Single)))
                ElseIf dtRow.Item("type_data").ToString = "smallmoney" Then
                    tbl.Columns.Add(New DataColumn(dtRow.Item("name").ToString, GetType(Decimal)))
                ElseIf dtRow.Item("type_data").ToString = "time" Then
                    tbl.Columns.Add(New DataColumn(dtRow.Item("name").ToString, GetType(TimeSpan)))
                ElseIf dtRow.Item("type_data").ToString = "varbinary" Then
                    tbl.Columns.Add(New DataColumn(dtRow.Item("name").ToString, GetType(Byte)))
                ElseIf dtRow.Item("type_data").ToString = "varchar" Then
                    tbl.Columns.Add(New DataColumn(dtRow.Item("name").ToString, GetType(String)))
                ElseIf dtRow.Item("type_data").ToString = "uniqueidentifier" Then
                    tbl.Columns.Add(New DataColumn(dtRow.Item("name").ToString, GetType(Guid)))
                ElseIf dtRow.Item("type_data").ToString = "sql_variant" Then
                    tbl.Columns.Add(New DataColumn(dtRow.Item("name").ToString, GetType(Object)))
                End If
            Next

            Return tbl
        Catch ex As Exception
            Throw ex
        End Try
        '-------------------------------
        'Default Value: 
        'tbl.Columns("warn_id").DefaultValue = ""
        'tbl.Columns("warnemailscheduled_line").DefaultValue = 0
        'tbl.Columns("warn_date").DefaultValue = DBNull.Value
    End Function

#Region "Advance Travel"
    Public Shared Function CreateTblTrnAdvanceItemDetilListOrder() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("advance_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("advancedetil_line", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("budgetdetil_line", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("advancedetil_type", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("budget_name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("currency_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("budgetdetil_eps", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("budgetdetil_days", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("acc_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("channel_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("strukturunit_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("amount_advance", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("budget_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("budgetdetil_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("budgetdetil_name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("advancedetil_foreignrate", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("amount_idrreal", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("amount_budget", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("budget_accum", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("outstanding_budget", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("outstanding_approved", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("outstanding_check", GetType(System.Boolean)))
        tbl.Columns.Add(New DataColumn("amount_approvebma", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("advance_isrequest", GetType(System.Byte)))
        tbl.Columns.Add(New DataColumn("advance_requestid", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("amount_settlement", GetType(System.Decimal)))

        tbl.Columns.Add(New DataColumn("pph_persen_settlement", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("pph_amountforeign_settlement", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("pph_amount_settlement", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("ppn_persen_settlement", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("ppn_amountforeign_settlement", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("ppn_amount_settlement", GetType(System.Decimal)))

        tbl.Columns.Add(New DataColumn("amount_discount_settlement", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("amount_intercompany_settlement", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("amount_settlement_nettforeign", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("amount_settlement_nett", GetType(System.Decimal)))


        tbl.Columns.Add(New DataColumn("amount_settlementreimburseforeign", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("amount_settlementreimburse", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("amount_settlementrefundforeign", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("amount_settlementrefund", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("settlement_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("username", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("settlement_rate", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("settlement_foreign", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("account", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("advance_isreimburse", GetType(System.Byte)))
        tbl.Columns.Add(New DataColumn("advance_reimburseid", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("advancedetil_fromsettlement", GetType(System.Byte)))

        tbl.Columns.Add(New DataColumn("advancedetil_discount", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("pph_persen", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("ppn_persen", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("pph_amount", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("ppn_amount", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("amount_subtotalforeign", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("amount_subtotal", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("faktur_id", GetType(System.String)))

        tbl.Columns.Add(New DataColumn("amount_intercompany", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("outstanding_settlement", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("advance_requestid_line", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("amount_sum", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("amount_sisa", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("qty", GetType(System.Decimal)))

        tbl.Columns.Add(New DataColumn("amount_order", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("budget_accumRequest", GetType(System.Decimal)))

        tbl.Columns("advance_id").DefaultValue = String.Empty
        tbl.Columns("advancedetil_line").DefaultValue = 0
        tbl.Columns("budgetdetil_line").DefaultValue = 0
        tbl.Columns("advancedetil_type").DefaultValue = 1
        tbl.Columns("budget_name").DefaultValue = String.Empty
        tbl.Columns("currency_id").DefaultValue = String.Empty
        tbl.Columns("budgetdetil_eps").DefaultValue = String.Empty
        tbl.Columns("budgetdetil_days").DefaultValue = 0
        tbl.Columns("acc_id").DefaultValue = String.Empty
        tbl.Columns("channel_id").DefaultValue = String.Empty
        tbl.Columns("strukturunit_id").DefaultValue = 0
        tbl.Columns("amount_advance").DefaultValue = 0
        tbl.Columns("budget_id").DefaultValue = 0
        tbl.Columns("budgetdetil_id").DefaultValue = 0
        tbl.Columns("budgetdetil_name").DefaultValue = String.Empty
        tbl.Columns("advancedetil_foreignrate").DefaultValue = 0
        tbl.Columns("amount_idrreal").DefaultValue = 0
        tbl.Columns("amount_budget").DefaultValue = 0
        tbl.Columns("budget_accum").DefaultValue = 0
        tbl.Columns("outstanding_budget").DefaultValue = 0
        tbl.Columns("outstanding_approved").DefaultValue = 0
        tbl.Columns("outstanding_check").DefaultValue = False
        tbl.Columns("amount_approvebma").DefaultValue = 0
        tbl.Columns("advance_isrequest").DefaultValue = False
        tbl.Columns("advance_requestid").DefaultValue = String.Empty
        tbl.Columns("amount_settlement").DefaultValue = 0

        tbl.Columns("pph_persen_settlement").DefaultValue = 0
        tbl.Columns("pph_amountforeign_settlement").DefaultValue = 0
        tbl.Columns("pph_amount_settlement").DefaultValue = 0
        tbl.Columns("ppn_persen_settlement").DefaultValue = 0
        tbl.Columns("ppn_amountforeign_settlement").DefaultValue = 0
        tbl.Columns("ppn_amount_settlement").DefaultValue = 0

        tbl.Columns("amount_discount_settlement").DefaultValue = 0
        tbl.Columns("amount_intercompany_settlement").DefaultValue = 0
        tbl.Columns("amount_settlement_nettforeign").DefaultValue = 0
        tbl.Columns("amount_settlement_nett").DefaultValue = 0

        tbl.Columns("settlement_id").DefaultValue = String.Empty
        tbl.Columns("username").DefaultValue = String.Empty
        tbl.Columns("settlement_rate").DefaultValue = 0
        ' ''tbl.Columns("settlement_currency").DefaultValue = String.Empty
        tbl.Columns("settlement_foreign").DefaultValue = 0
        tbl.Columns("account").DefaultValue = String.Empty
        tbl.Columns("advance_isreimburse").DefaultValue = 0
        tbl.Columns("advance_reimburseid").DefaultValue = String.Empty
        tbl.Columns("advancedetil_fromsettlement").DefaultValue = 0
        tbl.Columns("amount_settlementreimburseforeign").DefaultValue = 0
        tbl.Columns("amount_settlementreimburse").DefaultValue = 0
        tbl.Columns("amount_settlementrefundforeign").DefaultValue = 0
        tbl.Columns("amount_settlementrefund").DefaultValue = 0

        tbl.Columns("advancedetil_discount").DefaultValue = 0
        tbl.Columns("pph_persen").DefaultValue = 0
        tbl.Columns("ppn_persen").DefaultValue = 0
        tbl.Columns("pph_amount").DefaultValue = 0
        tbl.Columns("ppn_amount").DefaultValue = 0
        tbl.Columns("amount_subtotalforeign").DefaultValue = 0
        tbl.Columns("amount_subtotal").DefaultValue = 0
        tbl.Columns("faktur_id").DefaultValue = String.Empty

        tbl.Columns("amount_intercompany").DefaultValue = 0
        tbl.Columns("outstanding_settlement").DefaultValue = 0
        tbl.Columns("advance_requestid_line").DefaultValue = 0
        tbl.Columns("amount_sum").DefaultValue = 0
        tbl.Columns("amount_sisa").DefaultValue = 0
        tbl.Columns("qty").DefaultValue = 0
        tbl.Columns("amount_order").DefaultValue = 0
        tbl.Columns("budget_accumRequest").DefaultValue = 0

        Return tbl
    End Function

    Public Shared Function CreateTblTrnAdvanceItemDetilEps() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("advance_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("advancedetil_line", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("budgetdetil_line", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("budgetdetiluse_line", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("budgetdetil_eps", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("budget_name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("checked", GetType(System.Decimal)))

        '-------------------------------
        'Default Value: 
        tbl.Columns("advance_id").DefaultValue = String.Empty
        tbl.Columns("advancedetil_line").DefaultValue = 0
        tbl.Columns("budgetdetil_line").DefaultValue = 0
        tbl.Columns("budgetdetiluse_line").DefaultValue = 0
        tbl.Columns("budgetdetil_eps").DefaultValue = 0
        tbl.Columns("budget_name").DefaultValue = String.Empty
        tbl.Columns("checked").DefaultValue = 0

        Return tbl
    End Function

    Public Shared Function CreateTblTrnAdvanceRefPV() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("jurnal_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("jurnal_id_ref", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("jurnal_id_refline", GetType(System.Int64)))
        tbl.Columns.Add(New DataColumn("advance_id", GetType(System.String)))

        '-------------------------------
        'Default Value: 
        tbl.Columns("jurnal_id").DefaultValue = ""
        tbl.Columns("jurnal_id_ref").DefaultValue = ""
        tbl.Columns("jurnal_id_refline").DefaultValue = 0
        tbl.Columns("advance_id").DefaultValue = ""

        Return tbl
    End Function

    Public Shared Function CreateTblMstStrukturunit() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("strukturunit_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("strukturunit_name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("strukturunit_nameshort", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("strukturunit_namereport", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("strukturunit_parent", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("strukturunit_path", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("strukturunit_isgroup", GetType(System.Boolean)))
        tbl.Columns.Add(New DataColumn("strukturunit_isdisabled", GetType(System.Boolean)))
        tbl.Columns.Add(New DataColumn("strukturlevel_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("costcenter_id", GetType(System.String)))

        '-------------------------------
        'Default Value: 
        tbl.Columns("strukturunit_id").DefaultValue = 0
        tbl.Columns("strukturunit_name").DefaultValue = ""
        tbl.Columns("strukturunit_nameshort").DefaultValue = ""
        tbl.Columns("strukturunit_namereport").DefaultValue = ""
        tbl.Columns("strukturunit_parent").DefaultValue = "0"
        tbl.Columns("strukturunit_path").DefaultValue = ""
        tbl.Columns("strukturunit_isgroup").DefaultValue = 0
        tbl.Columns("strukturunit_isdisabled").DefaultValue = 0
        tbl.Columns("strukturlevel_id").DefaultValue = "0"
        tbl.Columns("costcenter_id").DefaultValue = "0"

        Return tbl
    End Function

    Public Shared Function CreateTblTrnBudgetCombo() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("budget_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("budget_nameshort", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("budget_epsstart", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("budget_epsend", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("prodtype_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("budget_isactive", GetType(System.Decimal)))

        tbl.Columns("budget_id").DefaultValue = 0
        tbl.Columns("budget_nameshort").DefaultValue = String.Empty
        tbl.Columns("budget_epsstart").DefaultValue = 0
        tbl.Columns("budget_epsend").DefaultValue = 0
        tbl.Columns("prodtype_id").DefaultValue = 0
        tbl.Columns("budget_isactive").DefaultValue = 0

        Return tbl
    End Function

    Public Shared Function CreateTblMstPaymenttype() As DataTable
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

    Public Shared Function CreateTblMstBodyEmail() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("id", GetType(System.Int64)))
        tbl.Columns.Add(New DataColumn("name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("description", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("id_type", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("email_subject", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("email_bodypath", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("channel_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("isdisabled", GetType(System.Boolean)))

        tbl.Columns("id").DefaultValue = 0
        tbl.Columns("name").DefaultValue = String.Empty
        tbl.Columns("description").DefaultValue = String.Empty
        tbl.Columns("id_type").DefaultValue = String.Empty
        tbl.Columns("email_subject").DefaultValue = String.Empty
        tbl.Columns("email_bodypath").DefaultValue = String.Empty
        tbl.Columns("channel_id").DefaultValue = String.Empty
        tbl.Columns("isdisabled").DefaultValue = False

        Return tbl
    End Function

    Public Shared Function CreateTblMstRekanan() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("rekanan_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("rekanan_badanhukum", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("rekanan_name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("rekanan_namereport", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("rekanan_address", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("rekanan_city", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("rekanan_telp", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("rekanan_fax", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("rekanan_email", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("rekanan_url", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("rekanan_pkpname", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("rekanan_taxprefix", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("rekanan_buyup", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("rekanan_buyupposition", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("rekanan_buyaddress", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("rekanan_create_by", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("rekanan_create_date", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("rekanan_modified_by", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("rekanan_modified_date", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("rekanan_isdisabled", GetType(System.Boolean)))
        tbl.Columns.Add(New DataColumn("rekanantype_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("taxsign_id", GetType(System.String)))

        '-------------------------------
        'Default Value: 
        tbl.Columns("rekanan_id").DefaultValue = ""
        tbl.Columns("rekanan_badanhukum").DefaultValue = ""
        tbl.Columns("rekanan_name").DefaultValue = ""
        tbl.Columns("rekanan_namereport").DefaultValue = ""
        tbl.Columns("rekanan_address").DefaultValue = ""
        tbl.Columns("rekanan_city").DefaultValue = ""
        tbl.Columns("rekanan_telp").DefaultValue = ""
        tbl.Columns("rekanan_fax").DefaultValue = ""
        tbl.Columns("rekanan_email").DefaultValue = ""
        tbl.Columns("rekanan_url").DefaultValue = ""
        tbl.Columns("rekanan_pkpname").DefaultValue = ""
        tbl.Columns("rekanan_taxprefix").DefaultValue = ""
        tbl.Columns("rekanan_buyup").DefaultValue = ""
        tbl.Columns("rekanan_buyupposition").DefaultValue = ""
        tbl.Columns("rekanan_buyaddress").DefaultValue = ""
        tbl.Columns("rekanan_create_by").DefaultValue = ""
        tbl.Columns("rekanan_create_date").DefaultValue = Now()
        tbl.Columns("rekanan_modified_by").DefaultValue = ""
        tbl.Columns("rekanan_modified_date").DefaultValue = Now()
        tbl.Columns("rekanan_isdisabled").DefaultValue = 0
        tbl.Columns("rekanantype_id").DefaultValue = "0"
        tbl.Columns("taxsign_id").DefaultValue = "0"

        Return tbl
    End Function

    Public Shared Function CreateTblTrnAdvanceApproveBmaOver() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("advance_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("advancedetil_line", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("bma_approved", GetType(System.Byte)))
        tbl.Columns.Add(New DataColumn("bma_approveddt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("bma_approvedby", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("bma_memo", GetType(System.String)))

        tbl.Columns("advance_id").DefaultValue = String.Empty
        tbl.Columns("advancedetil_line").DefaultValue = 0
        tbl.Columns("bma_approved").DefaultValue = 0
        tbl.Columns("bma_approveddt").DefaultValue = Now()
        tbl.Columns("bma_approvedby").DefaultValue = String.Empty
        tbl.Columns("bma_memo").DefaultValue = String.Empty

        Return tbl
    End Function

    Public Shared Function CreateTblTrnApprovebmaMemoItem() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("request_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("requestdetil_line", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("bma_approved", GetType(System.Byte)))
        tbl.Columns.Add(New DataColumn("bma_approveddt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("bma_approvedby", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("bma_memo", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("budget_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("budgetdetil_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("bma_line", GetType(System.Decimal)))

        tbl.Columns("request_id").DefaultValue = String.Empty
        tbl.Columns("requestdetil_line").DefaultValue = 0
        tbl.Columns("bma_approved").DefaultValue = 0
        tbl.Columns("bma_approveddt").DefaultValue = Now()
        tbl.Columns("bma_approvedby").DefaultValue = String.Empty
        tbl.Columns("bma_memo").DefaultValue = String.Empty
        tbl.Columns("budget_id").DefaultValue = 0
        tbl.Columns("budgetdetil_id").DefaultValue = 0
        tbl.Columns("bma_line").DefaultValue = 0

        Return tbl
    End Function

    Public Shared Function CreateTblTrnBudget() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("budget_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("budget_name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("budget_nameshort", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("budget_datestart", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("budget_dateend", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("budget_isactive", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("budget_amount", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("budget_valas", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("currency_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("budget_amountpaid", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("budget_valaspaid", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("budget_amountreq", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("budget_valasreq", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("budget_eps", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("category_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("showtype_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("projecttype_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("telecast_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("strukturunit_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("budget_apprby", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("budget_apprdt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("budget_apprauth", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("budget_apprver", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("budget_apprreq", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("rekanan_idproducer", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("prodtype_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("budget_entrybyERP", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("budget_entrydt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("budget_ispilot", GetType(System.Boolean)))
        tbl.Columns.Add(New DataColumn("budget_status", GetType(System.Int64)))
        tbl.Columns.Add(New DataColumn("project_id", GetType(System.Int64)))
        tbl.Columns.Add(New DataColumn("channel_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("budget_entryby", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("budget_epsstart", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("budget_epsend", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("budget_disabledby", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("budget_disabledate", GetType(System.DateTime)))

        '-------------------------------
        'Default Value: 
        tbl.Columns("budget_id").DefaultValue = 0
        tbl.Columns("budget_name").DefaultValue = ""
        tbl.Columns("budget_nameshort").DefaultValue = ""
        tbl.Columns("budget_datestart").DefaultValue = Now()
        tbl.Columns("budget_dateend").DefaultValue = Now()
        tbl.Columns("budget_isactive").DefaultValue = 0
        tbl.Columns("budget_amount").DefaultValue = 0
        tbl.Columns("budget_valas").DefaultValue = 0
        tbl.Columns("currency_id").DefaultValue = 0
        tbl.Columns("budget_amountpaid").DefaultValue = 0
        tbl.Columns("budget_valaspaid").DefaultValue = 0
        tbl.Columns("budget_amountreq").DefaultValue = 0
        tbl.Columns("budget_valasreq").DefaultValue = 0
        tbl.Columns("budget_eps").DefaultValue = 0
        tbl.Columns("category_id").DefaultValue = 0
        tbl.Columns("showtype_id").DefaultValue = 0
        tbl.Columns("projecttype_id").DefaultValue = 0
        tbl.Columns("telecast_id").DefaultValue = 0
        tbl.Columns("strukturunit_id").DefaultValue = 0
        tbl.Columns("budget_apprby").DefaultValue = 0
        tbl.Columns("budget_apprdt").DefaultValue = Now()
        tbl.Columns("budget_apprauth").DefaultValue = 0
        tbl.Columns("budget_apprver").DefaultValue = 0
        tbl.Columns("budget_apprreq").DefaultValue = 0
        tbl.Columns("rekanan_idproducer").DefaultValue = 0
        tbl.Columns("prodtype_id").DefaultValue = 0
        tbl.Columns("budget_entrybyERP").DefaultValue = 0
        tbl.Columns("budget_entrydt").DefaultValue = Now()
        tbl.Columns("budget_ispilot").DefaultValue = 0
        tbl.Columns("budget_status").DefaultValue = 0
        tbl.Columns("project_id").DefaultValue = 0
        tbl.Columns("channel_id").DefaultValue = ""
        tbl.Columns("budget_entryby").DefaultValue = ""
        tbl.Columns("budget_epsstart").DefaultValue = 0
        tbl.Columns("budget_epsend").DefaultValue = 0
        tbl.Columns("budget_disabledby").DefaultValue = ""
        tbl.Columns("budget_disabledate").DefaultValue = Now()

        Return tbl
    End Function

    Public Shared Function CreateTblTrnBudgetDetil() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("budgetdetil_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("budgetdetil_line", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("budget_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("budgetdetil_date", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("acc_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("projectacc_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("budgetdetil_desc", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("budgetdetil_amount", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("currency_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("budgetdetil_valas", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("budgetdetil_comp", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("budgetdetil_rate", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("budgetdetil_eps", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("budgetdetil_unit", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("budgetdetil_days", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("budgetdetil_amountprop", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("budgetdetil_valasprop", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("budgetdetil_amountrev", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("budgetdetil_valasrev", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("budgetdetil_amountpaid", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("budgetdetil_valaspaid", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("budgetdetil_amountreq", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("budgetdetil_valasreq", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("account", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("account_oth", GetType(System.String)))

        '-------------------------------
        'Default Value: 
        tbl.Columns("budgetdetil_id").DefaultValue = 0
        tbl.Columns("budgetdetil_line").DefaultValue = 0
        tbl.Columns("budget_id").DefaultValue = 0
        tbl.Columns("budgetdetil_date").DefaultValue = Now()
        tbl.Columns("acc_id").DefaultValue = 0
        tbl.Columns("projectacc_id").DefaultValue = 0
        tbl.Columns("budgetdetil_desc").DefaultValue = ""
        tbl.Columns("budgetdetil_amount").DefaultValue = 0
        tbl.Columns("currency_id").DefaultValue = 0
        tbl.Columns("budgetdetil_valas").DefaultValue = 0
        tbl.Columns("budgetdetil_comp").DefaultValue = 0
        tbl.Columns("budgetdetil_rate").DefaultValue = 0
        tbl.Columns("budgetdetil_eps").DefaultValue = 0
        tbl.Columns("budgetdetil_unit").DefaultValue = 0
        tbl.Columns("budgetdetil_days").DefaultValue = 0
        tbl.Columns("budgetdetil_amountprop").DefaultValue = 0
        tbl.Columns("budgetdetil_valasprop").DefaultValue = 0
        tbl.Columns("budgetdetil_amountrev").DefaultValue = 0
        tbl.Columns("budgetdetil_valasrev").DefaultValue = 0
        tbl.Columns("budgetdetil_amountpaid").DefaultValue = 0
        tbl.Columns("budgetdetil_valaspaid").DefaultValue = 0
        tbl.Columns("budgetdetil_amountreq").DefaultValue = 0
        tbl.Columns("budgetdetil_valasreq").DefaultValue = 0
        tbl.Columns("account").DefaultValue = String.Empty
        tbl.Columns("account_oth").DefaultValue = String.Empty

        Return tbl
    End Function

    Public Shared Function CreateTblTrnOrderadvance() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("advance_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("advancedetil_line", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("budgetdetil_line", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("order_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("orderdetil_line", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("budget_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("budgetdetil_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("currency_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("amount_order", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("amount_advance", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("amount_sisa", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("orderdetil_qty", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("orderdetil_pphpercent", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("orderdetil_ppnpercent", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("orderdetil_pphamount", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("orderdetil_ppnamount", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("orderdetil_days", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("orderdetil_discount", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("item_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("orderdetil_foreignrate", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("acc_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("account", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("amount_ppnpphdisc", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("iscanceled", GetType(System.Int64)))

        tbl.Columns("advance_id").DefaultValue = String.Empty
        tbl.Columns("advancedetil_line").DefaultValue = 0
        tbl.Columns("budgetdetil_line").DefaultValue = 0
        tbl.Columns("order_id").DefaultValue = String.Empty
        tbl.Columns("orderdetil_line").DefaultValue = 0
        tbl.Columns("budget_id").DefaultValue = 0
        tbl.Columns("budgetdetil_id").DefaultValue = 0
        tbl.Columns("currency_id").DefaultValue = String.Empty
        tbl.Columns("amount_order").DefaultValue = 0
        tbl.Columns("amount_advance").DefaultValue = 0
        tbl.Columns("amount_sisa").DefaultValue = 0
        tbl.Columns("orderdetil_qty").DefaultValue = 0
        tbl.Columns("orderdetil_pphpercent").DefaultValue = 0
        tbl.Columns("orderdetil_ppnpercent").DefaultValue = 0
        tbl.Columns("orderdetil_pphamount").DefaultValue = 0
        tbl.Columns("orderdetil_ppnamount").DefaultValue = 0
        tbl.Columns("orderdetil_days").DefaultValue = 0
        tbl.Columns("orderdetil_discount").DefaultValue = 0
        tbl.Columns("item_id").DefaultValue = String.Empty
        tbl.Columns("orderdetil_foreignrate").DefaultValue = 0
        tbl.Columns("acc_id").DefaultValue = String.Empty
        tbl.Columns("account").DefaultValue = String.Empty
        tbl.Columns("amount_ppnpphdisc").DefaultValue = 0
        tbl.Columns("iscanceled").DefaultValue = 0

        Return tbl
    End Function

    Public Shared Function CreateTblUserEmail() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("idemail", GetType(System.Int64)))
        tbl.Columns.Add(New DataColumn("username", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("user_email", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("user_emaildefault", GetType(System.Byte)))
        tbl.Columns.Add(New DataColumn("create_by", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("create_dt", GetType(System.DateTime)))


        tbl.Columns("idemail").DefaultValue = 0
        tbl.Columns("username").DefaultValue = ""
        tbl.Columns("user_email").DefaultValue = ""
        tbl.Columns("user_emaildefault").DefaultValue = 0
        tbl.Columns("create_by").DefaultValue = ""
        tbl.Columns("create_dt").DefaultValue = Now()

        Return tbl
    End Function

    Public Shared Function CreateTblTrnBudgetdetilWithAmount_new() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("budgetdetil_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("budget_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("budgetdetil_line", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("projectacc_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("account_oth", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("account", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("budgetdetil_desc", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("budgetdetil_amount", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("orderdetil_idr", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("outstanding_budget", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("eps_start", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("eps_end", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("budgetdetil_select", GetType(System.Boolean)))
        tbl.Columns.Add(New DataColumn("amount_bpj", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("amount_st", GetType(System.Decimal)))

        tbl.Columns("budgetdetil_id").DefaultValue = 0
        tbl.Columns("budget_id").DefaultValue = 0
        tbl.Columns("budgetdetil_line").DefaultValue = 0
        tbl.Columns("projectacc_id").DefaultValue = 0
        tbl.Columns("account_oth").DefaultValue = 0
        tbl.Columns("account").DefaultValue = String.Empty
        tbl.Columns("budgetdetil_desc").DefaultValue = String.Empty
        tbl.Columns("budgetdetil_amount").DefaultValue = 0
        tbl.Columns("orderdetil_idr").DefaultValue = 0
        tbl.Columns("outstanding_budget").DefaultValue = 0
        tbl.Columns("eps_start").DefaultValue = 0
        tbl.Columns("eps_end").DefaultValue = 0
        tbl.Columns("budgetdetil_select").DefaultValue = False
        tbl.Columns("amount_bpj").DefaultValue = 0
        tbl.Columns("amount_st").DefaultValue = 0

        Return tbl
    End Function

    Public Shared Function CreateTblTrnOrderforadvancedetil() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("order_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("orderdetil_line", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("orderdetil_type", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("item_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("item_name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("currency_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("currency_name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("orderdetil_qty", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("orderdetil_days", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("orderdetil_foreign", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("orderdetil_foreignrate", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("orderdetil_discount", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("budget_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("budget_name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("budgetdetil_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("budgetdetil_name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("subtotal_idr", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("subtotal_foreign", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("subtotal_incldisc_idr", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("subtotal_incldisc_foreign", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("pph_amount_idr", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("pph_amount_foreign", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("ppn_amount_idr", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("ppn_amount_foreign", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("total", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("amount", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("account", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("account_oth", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("orderdetil_pphpercent", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("orderdetil_ppnpercent", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("isadvance", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("amount_sisa", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("amount_order", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("advance_id", GetType(System.String)))

        tbl.Columns("order_id").DefaultValue = String.Empty
        tbl.Columns("orderdetil_line").DefaultValue = 0
        tbl.Columns("orderdetil_type").DefaultValue = String.Empty
        tbl.Columns("item_id").DefaultValue = String.Empty
        tbl.Columns("item_name").DefaultValue = String.Empty
        tbl.Columns("currency_id").DefaultValue = 0
        tbl.Columns("currency_name").DefaultValue = String.Empty
        tbl.Columns("orderdetil_qty").DefaultValue = 0
        tbl.Columns("orderdetil_days").DefaultValue = 0
        tbl.Columns("orderdetil_foreign").DefaultValue = 0
        tbl.Columns("orderdetil_foreignrate").DefaultValue = 0
        tbl.Columns("orderdetil_discount").DefaultValue = 0
        tbl.Columns("budget_id").DefaultValue = 0
        tbl.Columns("budget_name").DefaultValue = String.Empty
        tbl.Columns("budgetdetil_id").DefaultValue = 0
        tbl.Columns("budgetdetil_name").DefaultValue = String.Empty
        tbl.Columns("subtotal_idr").DefaultValue = 0
        tbl.Columns("subtotal_foreign").DefaultValue = 0
        tbl.Columns("subtotal_incldisc_idr").DefaultValue = 0
        tbl.Columns("subtotal_incldisc_foreign").DefaultValue = 0
        tbl.Columns("pph_amount_idr").DefaultValue = 0
        tbl.Columns("pph_amount_foreign").DefaultValue = 0
        tbl.Columns("ppn_amount_idr").DefaultValue = 0
        tbl.Columns("ppn_amount_foreign").DefaultValue = 0
        tbl.Columns("total").DefaultValue = 0
        tbl.Columns("amount").DefaultValue = 0

        tbl.Columns("account").DefaultValue = String.Empty
        tbl.Columns("account_oth").DefaultValue = String.Empty

        tbl.Columns("orderdetil_pphpercent").DefaultValue = 0
        tbl.Columns("orderdetil_ppnpercent").DefaultValue = 0

        tbl.Columns("isadvance").DefaultValue = 0
        tbl.Columns("amount_sisa").DefaultValue = 0
        tbl.Columns("amount_order").DefaultValue = 0
        tbl.Columns("advance_id").DefaultValue = String.Empty

        Return tbl
    End Function

    Public Shared Function CreateTblTrnOrderforadvance() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("order_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("order_date", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("order_descr", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("request_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("currency_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("currency_name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("rekanan_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("vendor", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("order_prognm", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("budget_id", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("budget_name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("order_setlocation", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("order_utilizeddatestart", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("order_utilizeddateend", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("order_pph_percent", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("order_ppn_percent", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("order_canceled", GetType(System.Byte)))
        tbl.Columns.Add(New DataColumn("order_createby", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("order_createdate", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("order_modifyby", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("order_modifydate", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("order_source", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("ordertype_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("channel_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("periode_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("periode_name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("strukturunit_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("department", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("order_programtype", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("order_epsstart", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("order_epsend", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("sub_discount_idr", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("sub_discount_foreign", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("subtotal_idr", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("subtotal_foreign", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("subtotal_incldisc_idr", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("subtotal_incldisc_foreign", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("pph_amount_idr", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("pph_amount_foreign", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("ppn_amount_idr", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("ppn_amount_foreign", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("grand_total_idr", GetType(System.Decimal)))

        tbl.Columns("order_id").DefaultValue = String.Empty
        tbl.Columns("order_date").DefaultValue = Now()
        tbl.Columns("order_descr").DefaultValue = String.Empty
        tbl.Columns("request_id").DefaultValue = String.Empty
        tbl.Columns("currency_id").DefaultValue = 0
        tbl.Columns("currency_name").DefaultValue = String.Empty
        tbl.Columns("rekanan_id").DefaultValue = 0
        tbl.Columns("vendor").DefaultValue = String.Empty
        tbl.Columns("order_prognm").DefaultValue = String.Empty
        tbl.Columns("budget_id").DefaultValue = 0
        tbl.Columns("budget_name").DefaultValue = String.Empty
        tbl.Columns("order_setlocation").DefaultValue = String.Empty
        tbl.Columns("order_utilizeddatestart").DefaultValue = Now()
        tbl.Columns("order_utilizeddateend").DefaultValue = Now()
        tbl.Columns("order_pph_percent").DefaultValue = 0
        tbl.Columns("order_ppn_percent").DefaultValue = 0
        tbl.Columns("order_canceled").DefaultValue = 0
        tbl.Columns("order_createby").DefaultValue = String.Empty
        tbl.Columns("order_createdate").DefaultValue = Now()
        tbl.Columns("order_modifyby").DefaultValue = String.Empty
        tbl.Columns("order_modifydate").DefaultValue = Now()
        tbl.Columns("order_source").DefaultValue = String.Empty
        tbl.Columns("ordertype_id").DefaultValue = String.Empty
        tbl.Columns("channel_id").DefaultValue = String.Empty
        tbl.Columns("periode_id").DefaultValue = String.Empty
        tbl.Columns("periode_name").DefaultValue = String.Empty
        tbl.Columns("strukturunit_id").DefaultValue = 0
        tbl.Columns("department").DefaultValue = String.Empty
        tbl.Columns("order_programtype").DefaultValue = String.Empty
        tbl.Columns("order_epsstart").DefaultValue = 0
        tbl.Columns("order_epsend").DefaultValue = 0
        tbl.Columns("sub_discount_idr").DefaultValue = 0
        tbl.Columns("sub_discount_foreign").DefaultValue = 0
        tbl.Columns("subtotal_idr").DefaultValue = 0
        tbl.Columns("subtotal_foreign").DefaultValue = 0
        tbl.Columns("subtotal_incldisc_idr").DefaultValue = 0
        tbl.Columns("subtotal_incldisc_foreign").DefaultValue = 0
        tbl.Columns("pph_amount_idr").DefaultValue = 0
        tbl.Columns("pph_amount_foreign").DefaultValue = 0
        tbl.Columns("ppn_amount_idr").DefaultValue = 0
        tbl.Columns("ppn_amount_foreign").DefaultValue = 0
        tbl.Columns("grand_total_idr").DefaultValue = 0

        Return tbl
    End Function

    Public Shared Function CreateTblJurnalReferencePVselectAP() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("ref", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("line", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("bookdate", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("descr", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("currency_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("currency_name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("rate", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("foreigns", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("idr", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("strukturunit_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("strukturunit_name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("channel_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("rekanan_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("rekanan_name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("jurnal_duedate", GetType(System.DateTime)))

        '-------------------------------
        'Default Value: 
        tbl.Columns("ref").DefaultValue = ""
        tbl.Columns("line").DefaultValue = 0
        tbl.Columns("bookdate").DefaultValue = Now.Date
        tbl.Columns("descr").DefaultValue = ""
        tbl.Columns("currency_id").DefaultValue = 0
        tbl.Columns("currency_name").DefaultValue = ""
        tbl.Columns("rate").DefaultValue = 0
        tbl.Columns("foreigns").DefaultValue = 0
        tbl.Columns("idr").DefaultValue = 0
        tbl.Columns("strukturunit_id").DefaultValue = "0"
        tbl.Columns("strukturunit_name").DefaultValue = ""
        tbl.Columns("channel_id").DefaultValue = ""
        tbl.Columns("rekanan_id").DefaultValue = 0
        tbl.Columns("rekanan_name").DefaultValue = ""
        tbl.Columns("jurnal_duedate").DefaultValue = Now.Date

        Return tbl
    End Function

    Public Shared Function CreateTblTrnJurnalBilyet() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Add(New DataColumn("jurnal_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("jurnaldetil_line", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("jurnaldetil_dk", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("jurnalbilyet_no", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("jurnalbilyet_date", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("jurnalbilyet_dateeffective", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("jurnalbilyet_receiveperson", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("jurnalbilyet_bank", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("paymenttype_id", GetType(System.String)))

        '-------------------------------
        'Default Value: 
        tbl.Columns("jurnal_id").DefaultValue = ""
        tbl.Columns("jurnaldetil_line").DefaultValue = 0
        tbl.Columns("jurnaldetil_dk").DefaultValue = ""
        tbl.Columns("jurnalbilyet_no").DefaultValue = ""
        tbl.Columns("jurnalbilyet_date").DefaultValue = Now.Date
        tbl.Columns("jurnalbilyet_dateeffective").DefaultValue = Now.Date
        tbl.Columns("jurnalbilyet_receiveperson").DefaultValue = ""
        tbl.Columns("jurnalbilyet_bank").DefaultValue = 0
        tbl.Columns("paymenttype_id").DefaultValue = ""

        Return tbl
    End Function
#End Region

End Class
