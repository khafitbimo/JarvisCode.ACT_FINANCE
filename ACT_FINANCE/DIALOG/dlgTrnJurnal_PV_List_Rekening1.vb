Public Class dlgTrnJurnal_PV_List_Rekening1

    Private DSN As String
    Private tbl_MstArtis As DataTable = clsDataset.CreateTblMstArtis()
    Private tbl_MstRekanan As DataTable = clsDataset.CreateTblMstRekananCombo()
    Private tbl_MstRekananWinner As DataTable = clsDataset.CreateTblMstRekananWinner()
    Private tbl_MstArtisBank As DataTable = clsDataset.CreateTblMstArtisbank()
    Private tbl_MstRekananBank As DataTable = clsDataset.CreateTblMstRekananbank()
    Private tbl_MstRekananBankWinner As DataTable = clsDataset.CreateTblMstRekananbankWinner()

    Private retTbl As DataTable = CreateTblRet()
    Private CloseButtonIsPressed As Boolean
    Private rekanan As Integer
    Private TombolRekeningClick As String
    Private channel_id As String


#Region " Layout & Init UI "

    Private Function FormatDgvMstRekananOther(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean

        Dim cRekanan_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekanan_name As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekanan_badanhukum As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekanan_namereport As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekanantype_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekanan_Addr1 As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekanan_Addr2 As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekanan_city As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekanan_telp As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekanan_fax As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekanan_email As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekanan_NPWP As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekanan_Create_by As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekanan_Create_dt As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekanan_active As System.Windows.Forms.DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Dim cRekanan_Bill As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekanan_taxprefix As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekanan_pkpname As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekanan_salesperson As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekanan_trf As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekanan_invsign As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekanan_invsignpos As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekanan_taxsign As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekanan_taxsignpos As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cChannel_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn

        cRekanan_id.Name = "rekanan_id"
        cRekanan_id.HeaderText = "rekanan_id"
        cRekanan_id.DataPropertyName = "rekanan_id"
        cRekanan_id.Width = 100
        cRekanan_id.Visible = False
        cRekanan_id.ReadOnly = True

        cRekanan_name.Name = "rekanan_name"
        cRekanan_name.HeaderText = "Name"
        cRekanan_name.DataPropertyName = "rekanan_name"
        cRekanan_name.Width = 200
        cRekanan_name.Visible = True
        cRekanan_name.ReadOnly = True

        cRekanan_badanhukum.Name = "rekanan_badanhukum"
        cRekanan_badanhukum.HeaderText = "rekanan_badanhukum"
        cRekanan_badanhukum.DataPropertyName = "rekanan_badanhukum"
        cRekanan_badanhukum.Width = 100
        cRekanan_badanhukum.Visible = False
        cRekanan_badanhukum.ReadOnly = True

        cRekanan_namereport.Name = "rekanan_namereport"
        cRekanan_namereport.HeaderText = "rekanan_namereport"
        cRekanan_namereport.DataPropertyName = "rekanan_namereport"
        cRekanan_namereport.Width = 100
        cRekanan_namereport.Visible = False
        cRekanan_namereport.ReadOnly = True

        cRekanantype_id.Name = "rekanantype_id"
        cRekanantype_id.HeaderText = "rekanantype_id"
        cRekanantype_id.DataPropertyName = "rekanantype_id"
        cRekanantype_id.Width = 100
        cRekanantype_id.Visible = False
        cRekanantype_id.ReadOnly = True

        cRekanan_Addr1.Name = "rekanan_Addr1"
        cRekanan_Addr1.HeaderText = "rekanan_Addr1"
        cRekanan_Addr1.DataPropertyName = "rekanan_Addr1"
        cRekanan_Addr1.Width = 100
        cRekanan_Addr1.Visible = False
        cRekanan_Addr1.ReadOnly = True

        cRekanan_Addr2.Name = "rekanan_Addr2"
        cRekanan_Addr2.HeaderText = "rekanan_Addr2"
        cRekanan_Addr2.DataPropertyName = "rekanan_Addr2"
        cRekanan_Addr2.Width = 100
        cRekanan_Addr2.Visible = False
        cRekanan_Addr2.ReadOnly = True

        cRekanan_city.Name = "rekanan_city"
        cRekanan_city.HeaderText = "rekanan_city"
        cRekanan_city.DataPropertyName = "rekanan_city"
        cRekanan_city.Width = 100
        cRekanan_city.Visible = False
        cRekanan_city.ReadOnly = True

        cRekanan_telp.Name = "rekanan_telp"
        cRekanan_telp.HeaderText = "rekanan_telp"
        cRekanan_telp.DataPropertyName = "rekanan_telp"
        cRekanan_telp.Width = 100
        cRekanan_telp.Visible = False
        cRekanan_telp.ReadOnly = True

        cRekanan_fax.Name = "rekanan_fax"
        cRekanan_fax.HeaderText = "rekanan_fax"
        cRekanan_fax.DataPropertyName = "rekanan_fax"
        cRekanan_fax.Width = 100
        cRekanan_fax.Visible = False
        cRekanan_fax.ReadOnly = True

        cRekanan_email.Name = "rekanan_email"
        cRekanan_email.HeaderText = "rekanan_email"
        cRekanan_email.DataPropertyName = "rekanan_email"
        cRekanan_email.Width = 100
        cRekanan_email.Visible = False
        cRekanan_email.ReadOnly = False

        cRekanan_NPWP.Name = "rekanan_NPWP"
        cRekanan_NPWP.HeaderText = "rekanan_NPWP"
        cRekanan_NPWP.DataPropertyName = "rekanan_NPWP"
        cRekanan_NPWP.Width = 100
        cRekanan_NPWP.Visible = False
        cRekanan_NPWP.ReadOnly = True

        cRekanan_Create_by.Name = "rekanan_Create_by"
        cRekanan_Create_by.HeaderText = "rekanan_Create_by"
        cRekanan_Create_by.DataPropertyName = "rekanan_Create_by"
        cRekanan_Create_by.Width = 100
        cRekanan_Create_by.Visible = False
        cRekanan_Create_by.ReadOnly = True

        cRekanan_Create_dt.Name = "rekanan_Create_dt"
        cRekanan_Create_dt.HeaderText = "rekanan_Create_dt"
        cRekanan_Create_dt.DataPropertyName = "rekanan_Create_dt"
        cRekanan_Create_dt.Width = 100
        cRekanan_Create_dt.Visible = False
        cRekanan_Create_dt.ReadOnly = True

        cRekanan_active.Name = "rekanan_active"
        cRekanan_active.HeaderText = "rekanan_active"
        cRekanan_active.DataPropertyName = "rekanan_active"
        cRekanan_active.Width = 100
        cRekanan_active.Visible = False
        cRekanan_active.ReadOnly = True

        cRekanan_Bill.Name = "rekanan_Bill"
        cRekanan_Bill.HeaderText = "rekanan_Bill"
        cRekanan_Bill.DataPropertyName = "rekanan_Bill"
        cRekanan_Bill.Width = 100
        cRekanan_Bill.Visible = False
        cRekanan_Bill.ReadOnly = True

        cRekanan_taxprefix.Name = "rekanan_taxprefix"
        cRekanan_taxprefix.HeaderText = "rekanan_taxprefix"
        cRekanan_taxprefix.DataPropertyName = "rekanan_taxprefix"
        cRekanan_taxprefix.Width = 100
        cRekanan_taxprefix.Visible = False
        cRekanan_taxprefix.ReadOnly = True

        cRekanan_pkpname.Name = "rekanan_pkpname"
        cRekanan_pkpname.HeaderText = "rekanan_pkpname"
        cRekanan_pkpname.DataPropertyName = "rekanan_pkpname"
        cRekanan_pkpname.Width = 100
        cRekanan_pkpname.Visible = False
        cRekanan_pkpname.ReadOnly = True

        cRekanan_salesperson.Name = "rekanan_salesperson"
        cRekanan_salesperson.HeaderText = "rekanan_salesperson"
        cRekanan_salesperson.DataPropertyName = "rekanan_salesperson"
        cRekanan_salesperson.Width = 100
        cRekanan_salesperson.Visible = False
        cRekanan_salesperson.ReadOnly = True

        cRekanan_trf.Name = "rekanan_trf"
        cRekanan_trf.HeaderText = "rekanan_trf"
        cRekanan_trf.DataPropertyName = "rekanan_trf"
        cRekanan_trf.Width = 100
        cRekanan_trf.Visible = False
        cRekanan_trf.ReadOnly = True

        cRekanan_invsign.Name = "rekanan_invsign"
        cRekanan_invsign.HeaderText = "rekanan_invsign"
        cRekanan_invsign.DataPropertyName = "rekanan_invsign"
        cRekanan_invsign.Width = 100
        cRekanan_invsign.Visible = False
        cRekanan_invsign.ReadOnly = True

        cRekanan_invsignpos.Name = "rekanan_invsignpos"
        cRekanan_invsignpos.HeaderText = "rekanan_invsignpos"
        cRekanan_invsignpos.DataPropertyName = "rekanan_invsignpos"
        cRekanan_invsignpos.Width = 100
        cRekanan_invsignpos.Visible = False
        cRekanan_invsignpos.ReadOnly = True

        cRekanan_taxsign.Name = "rekanan_taxsign"
        cRekanan_taxsign.HeaderText = "rekanan_taxsign"
        cRekanan_taxsign.DataPropertyName = "rekanan_taxsign"
        cRekanan_taxsign.Width = 100
        cRekanan_taxsign.Visible = False
        cRekanan_taxsign.ReadOnly = True

        cRekanan_taxsignpos.Name = "rekanan_taxsignpos"
        cRekanan_taxsignpos.HeaderText = "rekanan_taxsignpos"
        cRekanan_taxsignpos.DataPropertyName = "rekanan_taxsignpos"
        cRekanan_taxsignpos.Width = 100
        cRekanan_taxsignpos.Visible = False
        cRekanan_taxsignpos.ReadOnly = True

        cChannel_id.Name = "channel_id"
        cChannel_id.HeaderText = "channel_id"
        cChannel_id.DataPropertyName = "channel_id"
        cChannel_id.Width = 100
        cChannel_id.Visible = False
        cChannel_id.ReadOnly = False

        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
        {cRekanan_id, cRekanan_name, cRekanan_badanhukum, cRekanan_namereport, cRekanantype_id, cRekanan_Addr1, cRekanan_Addr2, cRekanan_city, cRekanan_telp, cRekanan_fax, cRekanan_email, cRekanan_NPWP, cRekanan_Create_by, cRekanan_Create_dt, cRekanan_active, cRekanan_Bill, cRekanan_taxprefix, cRekanan_pkpname, cRekanan_salesperson, cRekanan_trf, cRekanan_invsign, cRekanan_invsignpos, cRekanan_taxsign, cRekanan_taxsignpos, cChannel_id})
        objDgv.AutoGenerateColumns = False
        objDgv.AllowUserToAddRows = False
        objDgv.AllowUserToDeleteRows = False
        objDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        objDgv.ReadOnly = True

    End Function

    Private Function FormatDgvMstArtis(ByRef objDgv As DataGridView) As Boolean
        Dim cCode As New DataGridViewTextBoxColumn
        Dim cName As New DataGridViewTextBoxColumn
        Dim cAddress As New DataGridViewTextBoxColumn
        Dim cSex As New DataGridViewTextBoxColumn
        Dim cActive As New DataGridViewCheckBoxColumn

        cCode.Name = "code"
        cCode.HeaderText = "ID"
        cCode.DataPropertyName = "code"
        cCode.Width = 100
        cCode.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cCode.Visible = False
        cCode.ReadOnly = True

        cName.Name = "name"
        cName.HeaderText = "Name"
        cName.DataPropertyName = "name"
        cName.Width = 200
        cName.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cName.Visible = True
        cName.ReadOnly = True

        cAddress.Name = "address"
        cAddress.HeaderText = "Alamat"
        cAddress.DataPropertyName = "address"
        cAddress.Width = 200
        cAddress.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cAddress.Visible = False
        cAddress.ReadOnly = True

        cSex.Name = "sex"
        cSex.HeaderText = "Jenis Kelamin"
        cSex.DataPropertyName = "sex"
        cSex.Width = 60
        cSex.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cSex.Visible = False
        cSex.ReadOnly = True

        cActive.Name = "active"
        cActive.HeaderText = "Active"
        cActive.DataPropertyName = "active"
        cActive.Width = 50
        cActive.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cActive.Visible = False
        cActive.ReadOnly = True

        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New DataGridViewColumn() _
        {cCode, cName, cAddress, cSex, cActive})
        objDgv.AutoGenerateColumns = False
        objDgv.AllowUserToAddRows = False
        objDgv.AllowUserToDeleteRows = False
        objDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        objDgv.ReadOnly = True
    End Function

    Private Function FormatDgvMstArtisbank(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        'Dim cSelect As System.Windows.Forms.DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Dim cArtis_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cArtisbank_line As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cArtisbank_name As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cArtisbank_rekening As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cArtisbank_accountname As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn


        ' ''cSelect.Name = "select"
        ' ''cSelect.HeaderText = "Select"
        ' ''cSelect.DataPropertyName = "select"
        ' ''cSelect.Width = 50
        ' ''cSelect.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        ' ''cSelect.Visible = True
        ' ''cSelect.ReadOnly = False

        cArtis_id.Name = "artis_id"
        cArtis_id.HeaderText = "artis_id"
        cArtis_id.DataPropertyName = "artis_id"
        cArtis_id.Width = 100
        cArtis_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cArtis_id.Visible = False
        cArtis_id.ReadOnly = True

        cArtisbank_line.Name = "artisbank_line"
        cArtisbank_line.HeaderText = "Line"
        cArtisbank_line.DataPropertyName = "artisbank_line"
        cArtisbank_line.Width = 50
        cArtisbank_line.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cArtisbank_line.Visible = True
        cArtisbank_line.ReadOnly = True

        cArtisbank_name.Name = "artisbank_name"
        cArtisbank_name.HeaderText = "Bank"
        cArtisbank_name.DataPropertyName = "artisbank_name"
        cArtisbank_name.Width = 200
        cArtisbank_name.Visible = True
        cArtisbank_name.ReadOnly = True

        cArtisbank_rekening.Name = "artisbank_rekening"
        cArtisbank_rekening.HeaderText = "Rek. No."
        cArtisbank_rekening.DataPropertyName = "artisbank_rekening"
        cArtisbank_rekening.Width = 200
        cArtisbank_rekening.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cArtisbank_rekening.Visible = True
        cArtisbank_rekening.ReadOnly = True

        cArtisbank_accountname.Name = "artisbank_accountname"
        cArtisbank_accountname.HeaderText = "Account Name"
        cArtisbank_accountname.DataPropertyName = "artisbank_accountname"
        cArtisbank_accountname.Width = 200
        cArtisbank_accountname.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cArtisbank_accountname.Visible = True
        cArtisbank_accountname.ReadOnly = False

        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
        {cArtis_id, cArtisbank_line, cArtisbank_name, cArtisbank_rekening, cArtisbank_accountname})
        objDgv.AutoGenerateColumns = False
        objDgv.AllowUserToAddRows = False
        objDgv.AllowUserToDeleteRows = True
        objDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        objDgv.ReadOnly = True
    End Function

    Private Function FormatDgvMstrekanan(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        Dim cRekanan_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekanan_badanhukum As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekanan_name As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekanan_namereport As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekanantype_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekanan_address As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekanan_address2 As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekanan_city As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekanan_telp As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekanan_fax As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekanan_email As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekanan_NPWP As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekanan_create_by As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekanan_create_date As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekanan_active As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekanan_bill As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekanan_taxprefix As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekanan_pkpname As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekanan_buyup As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekanan_trfcode As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekanan_invsign As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekanan_invsignpos As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekanan_taxsign As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekanan_taxsignpos As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekanan_url As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekanan_buyupposition As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekanan_buyaddress As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekanan_modified_by As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekanan_modified_date As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn

        cRekanan_id.Name = "rekanan_id"
        cRekanan_id.HeaderText = "ID"
        cRekanan_id.DataPropertyName = "rekanan_id"
        cRekanan_id.Width = 100
        cRekanan_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cRekanan_id.Visible = False
        cRekanan_id.ReadOnly = False

        cRekanan_badanhukum.Name = "rekanan_badanhukum"
        cRekanan_badanhukum.HeaderText = "rekanan_badanhukum"
        cRekanan_badanhukum.DataPropertyName = "rekanan_badanhukum"
        cRekanan_badanhukum.Width = 100
        cRekanan_badanhukum.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cRekanan_badanhukum.Visible = False
        cRekanan_badanhukum.ReadOnly = False

        cRekanan_name.Name = "rekanan_name"
        cRekanan_name.HeaderText = "Name"
        cRekanan_name.DataPropertyName = "rekanan_name"
        cRekanan_name.Width = 200
        cRekanan_name.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cRekanan_name.Visible = True
        cRekanan_name.ReadOnly = False

        cRekanan_namereport.Name = "rekanan_namereport"
        cRekanan_namereport.HeaderText = "rekanan_namereport"
        cRekanan_namereport.DataPropertyName = "rekanan_namereport"
        cRekanan_namereport.Width = 100
        cRekanan_namereport.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cRekanan_namereport.Visible = False
        cRekanan_namereport.ReadOnly = False

        cRekanantype_id.Name = "rekanantype_id"
        cRekanantype_id.HeaderText = "rekanantype_id"
        cRekanantype_id.DataPropertyName = "rekanantype_id"
        cRekanantype_id.Width = 100
        cRekanantype_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cRekanantype_id.Visible = False
        cRekanantype_id.ReadOnly = False

        cRekanan_address.Name = "rekanan_address"
        cRekanan_address.HeaderText = "Address1"
        cRekanan_address.DataPropertyName = "rekanan_address"
        cRekanan_address.Width = 150
        cRekanan_address.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cRekanan_address.Visible = True
        cRekanan_address.ReadOnly = False

        cRekanan_address2.Name = "rekanan_address2"
        cRekanan_address2.HeaderText = "Address2"
        cRekanan_address2.DataPropertyName = "rekanan_address2"
        cRekanan_address2.Width = 150
        cRekanan_address2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cRekanan_address2.Visible = True
        cRekanan_address2.ReadOnly = False

        cRekanan_city.Name = "rekanan_city"
        cRekanan_city.HeaderText = "rekanan_city"
        cRekanan_city.DataPropertyName = "rekanan_city"
        cRekanan_city.Width = 100
        cRekanan_city.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cRekanan_city.Visible = False
        cRekanan_city.ReadOnly = False

        cRekanan_telp.Name = "rekanan_telp"
        cRekanan_telp.HeaderText = "rekanan_telp"
        cRekanan_telp.DataPropertyName = "rekanan_telp"
        cRekanan_telp.Width = 100
        cRekanan_telp.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cRekanan_telp.Visible = False
        cRekanan_telp.ReadOnly = False

        cRekanan_fax.Name = "rekanan_fax"
        cRekanan_fax.HeaderText = "rekanan_fax"
        cRekanan_fax.DataPropertyName = "rekanan_fax"
        cRekanan_fax.Width = 100
        cRekanan_fax.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cRekanan_fax.Visible = False
        cRekanan_fax.ReadOnly = False

        cRekanan_email.Name = "rekanan_email"
        cRekanan_email.HeaderText = "rekanan_email"
        cRekanan_email.DataPropertyName = "rekanan_email"
        cRekanan_email.Width = 100
        cRekanan_email.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cRekanan_email.Visible = False
        cRekanan_email.ReadOnly = False

        cRekanan_NPWP.Name = "rekanan_NPWP"
        cRekanan_NPWP.HeaderText = "NPWP"
        cRekanan_NPWP.DataPropertyName = "rekanan_NPWP"
        cRekanan_NPWP.Width = 100
        cRekanan_NPWP.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cRekanan_NPWP.Visible = True
        cRekanan_NPWP.ReadOnly = False

        cRekanan_create_by.Name = "rekanan_create_by"
        cRekanan_create_by.HeaderText = "rekanan_create_by"
        cRekanan_create_by.DataPropertyName = "rekanan_create_by"
        cRekanan_create_by.Width = 100
        cRekanan_create_by.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cRekanan_create_by.Visible = False
        cRekanan_create_by.ReadOnly = False

        cRekanan_create_date.Name = "rekanan_create_date"
        cRekanan_create_date.HeaderText = "rekanan_create_date"
        cRekanan_create_date.DataPropertyName = "rekanan_create_date"
        cRekanan_create_date.Width = 100
        cRekanan_create_date.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cRekanan_create_date.Visible = False
        cRekanan_create_date.ReadOnly = False

        cRekanan_active.Name = "rekanan_active"
        cRekanan_active.HeaderText = "rekanan_active"
        cRekanan_active.DataPropertyName = "rekanan_active"
        cRekanan_active.Width = 100
        cRekanan_active.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cRekanan_active.Visible = False
        cRekanan_active.ReadOnly = False

        cRekanan_bill.Name = "rekanan_bill"
        cRekanan_bill.HeaderText = "rekanan_bill"
        cRekanan_bill.DataPropertyName = "rekanan_bill"
        cRekanan_bill.Width = 100
        cRekanan_bill.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cRekanan_bill.Visible = False
        cRekanan_bill.ReadOnly = False

        cRekanan_taxprefix.Name = "rekanan_taxprefix"
        cRekanan_taxprefix.HeaderText = "rekanan_taxprefix"
        cRekanan_taxprefix.DataPropertyName = "rekanan_taxprefix"
        cRekanan_taxprefix.Width = 100
        cRekanan_taxprefix.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cRekanan_taxprefix.Visible = False
        cRekanan_taxprefix.ReadOnly = False

        cRekanan_pkpname.Name = "rekanan_pkpname"
        cRekanan_pkpname.HeaderText = "rekanan_pkpname"
        cRekanan_pkpname.DataPropertyName = "rekanan_pkpname"
        cRekanan_pkpname.Width = 100
        cRekanan_pkpname.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cRekanan_pkpname.Visible = False
        cRekanan_pkpname.ReadOnly = False

        cRekanan_buyup.Name = "rekanan_buyup"
        cRekanan_buyup.HeaderText = "rekanan_buyup"
        cRekanan_buyup.DataPropertyName = "rekanan_buyup"
        cRekanan_buyup.Width = 100
        cRekanan_buyup.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cRekanan_buyup.Visible = False
        cRekanan_buyup.ReadOnly = False

        cRekanan_trfcode.Name = "rekanan_trfcode"
        cRekanan_trfcode.HeaderText = "rekanan_trfcode"
        cRekanan_trfcode.DataPropertyName = "rekanan_trfcode"
        cRekanan_trfcode.Width = 100
        cRekanan_trfcode.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cRekanan_trfcode.Visible = False
        cRekanan_trfcode.ReadOnly = False

        cRekanan_invsign.Name = "rekanan_invsign"
        cRekanan_invsign.HeaderText = "rekanan_invsign"
        cRekanan_invsign.DataPropertyName = "rekanan_invsign"
        cRekanan_invsign.Width = 100
        cRekanan_invsign.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cRekanan_invsign.Visible = False
        cRekanan_invsign.ReadOnly = False

        cRekanan_invsignpos.Name = "rekanan_invsignpos"
        cRekanan_invsignpos.HeaderText = "rekanan_invsignpos"
        cRekanan_invsignpos.DataPropertyName = "rekanan_invsignpos"
        cRekanan_invsignpos.Width = 100
        cRekanan_invsignpos.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cRekanan_invsignpos.Visible = False
        cRekanan_invsignpos.ReadOnly = False

        cRekanan_taxsign.Name = "rekanan_taxsign"
        cRekanan_taxsign.HeaderText = "rekanan_taxsign"
        cRekanan_taxsign.DataPropertyName = "rekanan_taxsign"
        cRekanan_taxsign.Width = 100
        cRekanan_taxsign.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cRekanan_taxsign.Visible = False
        cRekanan_taxsign.ReadOnly = False

        cRekanan_taxsignpos.Name = "rekanan_taxsignpos"
        cRekanan_taxsignpos.HeaderText = "rekanan_taxsignpos"
        cRekanan_taxsignpos.DataPropertyName = "rekanan_taxsignpos"
        cRekanan_taxsignpos.Width = 100
        cRekanan_taxsignpos.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cRekanan_taxsignpos.Visible = False
        cRekanan_taxsignpos.ReadOnly = False

        cRekanan_url.Name = "rekanan_url"
        cRekanan_url.HeaderText = "rekanan_url"
        cRekanan_url.DataPropertyName = "rekanan_url"
        cRekanan_url.Width = 100
        cRekanan_url.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cRekanan_url.Visible = False
        cRekanan_url.ReadOnly = False

        cRekanan_buyupposition.Name = "rekanan_buyupposition"
        cRekanan_buyupposition.HeaderText = "rekanan_buyupposition"
        cRekanan_buyupposition.DataPropertyName = "rekanan_buyupposition"
        cRekanan_buyupposition.Width = 100
        cRekanan_buyupposition.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cRekanan_buyupposition.Visible = False
        cRekanan_buyupposition.ReadOnly = False

        cRekanan_buyaddress.Name = "rekanan_buyaddress"
        cRekanan_buyaddress.HeaderText = "rekanan_buyaddress"
        cRekanan_buyaddress.DataPropertyName = "rekanan_buyaddress"
        cRekanan_buyaddress.Width = 100
        cRekanan_buyaddress.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cRekanan_buyaddress.Visible = False
        cRekanan_buyaddress.ReadOnly = False

        cRekanan_modified_by.Name = "rekanan_modified_by"
        cRekanan_modified_by.HeaderText = "rekanan_modified_by"
        cRekanan_modified_by.DataPropertyName = "rekanan_modified_by"
        cRekanan_modified_by.Width = 100
        cRekanan_modified_by.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cRekanan_modified_by.Visible = False
        cRekanan_modified_by.ReadOnly = False

        cRekanan_modified_date.Name = "rekanan_modified_date"
        cRekanan_modified_date.HeaderText = "rekanan_modified_date"
        cRekanan_modified_date.DataPropertyName = "rekanan_modified_date"
        cRekanan_modified_date.Width = 100
        cRekanan_modified_date.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cRekanan_modified_date.Visible = False
        cRekanan_modified_date.ReadOnly = False

        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
        {cRekanan_id, cRekanan_badanhukum, cRekanan_name, cRekanan_namereport, cRekanantype_id, cRekanan_address, cRekanan_address2, cRekanan_city, cRekanan_telp, cRekanan_fax, cRekanan_email, cRekanan_NPWP, cRekanan_create_by, cRekanan_create_date, cRekanan_active, cRekanan_bill, cRekanan_taxprefix, cRekanan_pkpname, cRekanan_buyup, cRekanan_trfcode, cRekanan_invsign, cRekanan_invsignpos, cRekanan_taxsign, cRekanan_taxsignpos, cRekanan_url, cRekanan_buyupposition, cRekanan_buyaddress, cRekanan_modified_by, cRekanan_modified_date})
        objDgv.AutoGenerateColumns = False
        objDgv.AllowUserToAddRows = False
        objDgv.AllowUserToDeleteRows = False
        objDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        objDgv.ReadOnly = True
    End Function

    Private Function FormatDgvMstRekananbank(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        'Dim cSelect As System.Windows.Forms.DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Dim cRekanan_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekananbank_line As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cCurrency_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekananbank_account As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekananbank_name As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekananbank_rekening As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekananbank_addr1 As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekananbank_addr2 As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekananbank_city As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn

        ' ''cSelect.Name = "select"
        ' ''cSelect.HeaderText = "Select"
        ' ''cSelect.DataPropertyName = "select"
        ' ''cSelect.Width = 50
        ' ''cSelect.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        ' ''cSelect.Visible = True
        ' ''cSelect.ReadOnly = False

        cRekanan_id.Name = "rekanan_id"
        cRekanan_id.HeaderText = "ID"
        cRekanan_id.DataPropertyName = "rekanan_id"
        cRekanan_id.Width = 100
        cRekanan_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cRekanan_id.Visible = False
        cRekanan_id.ReadOnly = True

        cRekananbank_line.Name = "rekananbank_line"
        cRekananbank_line.HeaderText = "Line"
        cRekananbank_line.DataPropertyName = "rekananbank_line"
        cRekananbank_line.Width = 50
        cRekananbank_line.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cRekananbank_line.Visible = False
        cRekananbank_line.ReadOnly = True

        cCurrency_id.Name = "currency_id"
        cCurrency_id.HeaderText = "currency_id"
        cCurrency_id.DataPropertyName = "currency_id"
        cCurrency_id.Width = 100
        cCurrency_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cCurrency_id.Visible = False
        cCurrency_id.ReadOnly = False

        cRekananbank_account.Name = "rekananbank_account"
        cRekananbank_account.HeaderText = "Rek. No."
        cRekananbank_account.DataPropertyName = "rekananbank_account"
        cRekananbank_account.Width = 200
        cRekananbank_account.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cRekananbank_account.Visible = True
        cRekananbank_account.ReadOnly = False

        cRekananbank_name.Name = "rekananbank_name"
        cRekananbank_name.HeaderText = "Account Name"
        cRekananbank_name.DataPropertyName = "rekananbank_name"
        cRekananbank_name.Width = 200
        cRekananbank_name.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cRekananbank_name.Visible = True
        cRekananbank_name.ReadOnly = True

        cRekananbank_rekening.Name = "rekananbank_rekening"
        cRekananbank_rekening.HeaderText = "Bank"
        cRekananbank_rekening.DataPropertyName = "rekananbank_rekening"
        cRekananbank_rekening.Width = 200
        cRekananbank_rekening.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cRekananbank_rekening.Visible = True
        cRekananbank_rekening.ReadOnly = True

        cRekananbank_addr1.Name = "rekananbank_addr1"
        cRekananbank_addr1.HeaderText = "rekananbank_addr1"
        cRekananbank_addr1.DataPropertyName = "rekananbank_addr1"
        cRekananbank_addr1.Width = 100
        cRekananbank_addr1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cRekananbank_addr1.Visible = False
        cRekananbank_addr1.ReadOnly = False

        cRekananbank_addr2.Name = "rekananbank_addr2"
        cRekananbank_addr2.HeaderText = "rekananbank_addr2"
        cRekananbank_addr2.DataPropertyName = "rekananbank_addr2"
        cRekananbank_addr2.Width = 100
        cRekananbank_addr2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cRekananbank_addr2.Visible = False
        cRekananbank_addr2.ReadOnly = False

        cRekananbank_city.Name = "rekananbank_city"
        cRekananbank_city.HeaderText = "rekananbank_city"
        cRekananbank_city.DataPropertyName = "rekananbank_city"
        cRekananbank_city.Width = 100
        cRekananbank_city.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cRekananbank_city.Visible = False
        cRekananbank_city.ReadOnly = False

        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
        {cRekanan_id, cRekananbank_line, cCurrency_id, cRekananbank_rekening, cRekananbank_account, _
        cRekananbank_name, cRekananbank_addr1, _
        cRekananbank_addr2, cRekananbank_city})

        objDgv.AutoGenerateColumns = False
        objDgv.AllowUserToAddRows = False
        objDgv.AllowUserToDeleteRows = False
        objDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        objDgv.ReadOnly = True


    End Function

    Function CreateTblRet() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("rekanan_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("rekananbank_line", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("penerima_name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("penerima_rekening", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("penerima_bank", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("penerima_bankaccountname", GetType(System.String)))
        '-------------------------------
        'Default Value: 
        tbl.Columns("rekanan_id").DefaultValue = ""
        tbl.Columns("rekananbank_line").DefaultValue = 0
        tbl.Columns("penerima_name").DefaultValue = ""
        tbl.Columns("penerima_rekening").DefaultValue = ""
        tbl.Columns("penerima_bank").DefaultValue = ""
        tbl.Columns("penerima_bankaccountname").DefaultValue = ""

        Return tbl
    End Function

#End Region

#Region " Opener "
    Public Shadows Function OpenDialog(ByVal owner As System.Windows.Forms.IWin32Window) As Object
        Dim oDataFiller As clsDataFiller = New clsDataFiller(Me.DSN)
        Dim isExist As Boolean = False
        Dim tbl_srchType As New DataTable
        Dim tbl_typeRekananSearch As New DataTable

        If Me.TombolRekeningClick = "rekanan" Then
            oDataFiller.DataFill(Me.tbl_MstRekanan, "ms_mstRekanan_select", "rekanan_id='" + Me.rekanan.ToString + "'")
        ElseIf Me.TombolRekeningClick = "artis" Then
            oDataFiller.DataFill(Me.tbl_MstArtis, "ms_MstArtis_Select", "active = 1 AND (name <> '' OR name <> null) and channel_id = '" + Me.channel_id + "'")
        ElseIf Me.TombolRekeningClick = "other" Then
            oDataFiller.DataFill(Me.tbl_MstRekanan, "ms_mstRekanan_select2", "", Me.channel_id)
        ElseIf Me.TombolRekeningClick = "prize" Then
            oDataFiller.DataFillWinnerPrize(Me.tbl_MstRekananWinner, "ms_MstWinnerPrize_Select", "", Me.channel_id)
        End If

        If Me.TombolRekeningClick = "rekanan" Then
            Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
            Me.dgvArtisName.Visible = False
            Me.SplitContainer1.SplitterDistance = 0
            Me.SplitContainer1.Panel1Collapsed = True
            Me.lbl_rekeninglist.Text = "Rekanan Name : " & Me.tbl_MstRekanan.Rows(0).Item("rekanan_name").ToString
            Dim cookie As Byte() = Nothing

            Try
                dbConn.Open()
                clsApplicationRole.SetAppRole(dbConn, cookie)
                Me.dlgTrnJurnalPVSelect_rekening_OpenRowDetilRekeningRekanan(Me.rekanan, dbConn)
            Catch ex As Exception
            Finally
                clsApplicationRole.UnsetAppRole(dbConn, cookie)
                dbConn.Close()
            End Try

        ElseIf Me.TombolRekeningClick = "artis" Then
            Me.lb_rekananname.Text = "Artis"
            Me.dgvArtisName.Visible = True
            Me.SplitContainer1.SplitterDistance = 194
            Me.SplitContainer1.Panel1Collapsed = False
            Me.lbl_rekeninglist.Text = "List Rekening"
            Me.FormatDgvMstArtis(Me.dgvArtisName)
            Me.tbl_MstArtis.DefaultView.Sort = "name"
            Me.dgvArtisName.DataSource = Me.tbl_MstArtis

        ElseIf Me.TombolRekeningClick = "other" Then
            Me.lb_rekananname.Text = "Partner"
            Me.dgvArtisName.Visible = True
            Me.SplitContainer1.SplitterDistance = 194
            Me.SplitContainer1.Panel1Collapsed = False
            Me.lbl_rekeninglist.Text = "List Rekening"
            Me.FormatDgvMstRekananOther(Me.dgvArtisName)
            Me.tbl_MstRekanan.DefaultView.Sort = "rekanan_name"
            Me.dgvArtisName.DataSource = Me.tbl_MstRekanan
        ElseIf Me.TombolRekeningClick = "prize" Then
            Me.lb_rekananname.Text = "Winner"
            Me.dgvArtisName.Visible = True
            Me.SplitContainer1.SplitterDistance = 194
            Me.SplitContainer1.Panel1Collapsed = False
            Me.lbl_rekeninglist.Text = "List Rekening"
            Me.FormatDgvMstRekananOther(Me.dgvArtisName)
            Me.tbl_MstRekananWinner.DefaultView.Sort = "rekanan_name"
            Me.dgvArtisName.DataSource = Me.tbl_MstRekananWinner

        End If

        MyBase.ShowDialog(owner)
        Me.Cursor = Cursors.Arrow

        If Me.CloseButtonIsPressed Then
            Return Me.retTbl
        Else
            Return Nothing
        End If
    End Function
#End Region

    Public Sub New(ByVal channel_id As String, ByVal strDSN As String, ByVal rekanan As Integer, ByVal btnRekeningType As String)
        InitializeComponent()
        Me.DSN = strDSN
        Me.rekanan = rekanan
        Me.TombolRekeningClick = btnRekeningType
        Me.channel_id = channel_id
    End Sub

    Private Sub btn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Ok.Click, btn_cancel.Click
        Dim obj As Button = sender

        If obj.Name = "btn_Ok" Then
            Dim row As DataRow
            If Me.tbl_MstRekananBank.Rows.Count > 0 Then
                Me.retTbl.Clear()
                row = retTbl.NewRow
                row.Item("rekanan_id") = Me.tbl_MstRekananBank.Rows(0).Item("rekanan_id") 'Me.DgvRekening.Item("rekanan_id", Me.DgvRekening.CurrentCell.RowIndex).Value 'Me.DgvRekanan.Rows(Me.DgvRekanan.CurrentRow.Index).Cells("name").Value
                row.Item("rekananbank_line") = Me.DgvRekening.Item("rekananbank_line", Me.DgvRekening.CurrentCell.RowIndex).Value 'Me.DgvRekanan.Rows(Me.DgvRekanan.CurrentRow.Index).Cells("name").Value
                row.Item("penerima_name") = Me.tbl_MstRekanan.Rows(0).Item("rekanan_name") 'Me.DgvRekanan.Item("rekanan_name", Me.DgvRekanan.CurrentCell.RowIndex).Value 'Me.DgvRekanan.Rows(Me.DgvRekanan.CurrentRow.Index).Cells("rekanan_name").Value
                row.Item("penerima_rekening") = Me.DgvRekening.Item("rekananbank_account", Me.DgvRekening.CurrentCell.RowIndex).Value 'Me.tbl_MstRekananBank.Rows(i).Item("rekananbank_account")
                row.Item("penerima_bank") = Me.DgvRekening.Item("rekananbank_rekening", Me.DgvRekening.CurrentCell.RowIndex).Value 'Me.tbl_MstRekananBank.Rows(i).Item("rekananbank_rekening")
                row.Item("penerima_bankaccountname") = Me.DgvRekening.Item("rekananbank_name", Me.DgvRekening.CurrentCell.RowIndex).Value 'Me.tbl_MstRekananBank.Rows(i).Item("rekananbank_name")
                Me.retTbl.Rows.Add(row)

            ElseIf Me.tbl_MstArtisBank.Rows.Count > 0 Then
                Me.retTbl.NewRow()
                row = retTbl.NewRow
                row.Item("rekanan_id") = Me.DgvRekening.Item("artis_id", Me.DgvRekening.CurrentCell.RowIndex).Value 'Me.DgvRekanan.Rows(Me.DgvRekanan.CurrentRow.Index).Cells("name").Value
                row.Item("rekananbank_line") = Me.DgvRekening.Item("artisbank_line", Me.DgvRekening.CurrentCell.RowIndex).Value 'Me.DgvRekanan.Rows(Me.DgvRekanan.CurrentRow.Index).Cells("name").Value
                row.Item("penerima_name") = Me.tbl_MstRekanan.Rows(0).Item("rekanan_name") 'Me.DgvRekanan.Item("name", Me.DgvRekanan.CurrentCell.RowIndex).Value 'Me.DgvRekanan.Rows(Me.DgvRekanan.CurrentRow.Index).Cells("name").Value
                row.Item("penerima_rekening") = Me.DgvRekening.Item("artisbank_rekening", Me.DgvRekening.CurrentCell.RowIndex).Value ' Me.tbl_MstArtisBank.Rows(i).Item("artisbank_rekening")
                row.Item("penerima_bank") = Me.DgvRekening.Item("artisbank_name", Me.DgvRekening.CurrentCell.RowIndex).Value ' Me.tbl_MstArtisBank.Rows(i).Item("artisbank_name")
                row.Item("penerima_bankaccountname") = Me.DgvRekening.Item("artisbank_accountname", Me.DgvRekening.CurrentCell.RowIndex).Value 'Me.tbl_MstArtisBank.Rows(i).Item("artisbank_accountname")
                Me.retTbl.Rows.Add(row)

            ElseIf Me.tbl_MstRekananBankWinner.Rows.Count > 0 Then
                Me.retTbl.Clear()
                row = retTbl.NewRow
                row.Item("rekanan_id") = Me.tbl_MstRekananBankWinner.Rows(0).Item("rekanan_id") 'Me.DgvRekening.Item("rekanan_id", Me.DgvRekening.CurrentCell.RowIndex).Value 'Me.DgvRekanan.Rows(Me.DgvRekanan.CurrentRow.Index).Cells("name").Value
                row.Item("rekananbank_line") = Me.DgvRekening.Item("rekananbank_line", Me.DgvRekening.CurrentCell.RowIndex).Value 'Me.DgvRekanan.Rows(Me.DgvRekanan.CurrentRow.Index).Cells("name").Value
                row.Item("penerima_name") = Me.tbl_MstRekananWinner.Rows(0).Item("rekanan_name") 'Me.DgvRekanan.Item("rekanan_name", Me.DgvRekanan.CurrentCell.RowIndex).Value 'Me.DgvRekanan.Rows(Me.DgvRekanan.CurrentRow.Index).Cells("rekanan_name").Value
                row.Item("penerima_rekening") = Me.DgvRekening.Item("rekananbank_account", Me.DgvRekening.CurrentCell.RowIndex).Value 'Me.tbl_MstRekananBank.Rows(i).Item("rekananbank_account")
                row.Item("penerima_bank") = Me.DgvRekening.Item("rekananbank_rekening", Me.DgvRekening.CurrentCell.RowIndex).Value 'Me.tbl_MstRekananBank.Rows(i).Item("rekananbank_rekening")
                row.Item("penerima_bankaccountname") = Me.DgvRekening.Item("rekananbank_name", Me.DgvRekening.CurrentCell.RowIndex).Value 'Me.tbl_MstRekananBank.Rows(i).Item("rekananbank_name")
                Me.retTbl.Rows.Add(row)
            End If



            Me.CloseButtonIsPressed = True
        Else
            Me.CloseButtonIsPressed = False
        End If
        Me.Close()
    End Sub

    'Private Sub obj_search_Changed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles obj_search_text.TextChanged, obj_search_type.SelectedValueChanged
    '    Dim filter As String = String.Empty

    '    Try
    '        If Me.obj_type_search.SelectedValue = "0" Or Me.obj_type_search.SelectedValue = 1 Then
    '            Select Case Me.obj_search_type.SelectedValue
    '                Case "0"
    '                    filter = String.Format("rekanan_id = {0}", Me.obj_search_text.Text)
    '                Case "1"
    '                    filter = String.Format("rekanan_name LIKE '%{0}%'", Me.obj_search_text.Text)
    '                Case Else
    '                    filter = String.Empty
    '            End Select
    '            If Me.obj_search_text.Text = String.Empty Then
    '                filter = String.Empty
    '            End If
    '            Me.tbl_MstRekanan.DefaultView.RowFilter = filter
    '        Else
    '            Select Case Me.obj_search_type.SelectedValue
    '                Case "0"
    '                    filter = String.Format("code = {0}", Me.obj_search_text.Text)
    '                Case "1"
    '                    filter = String.Format("name LIKE '%{0}%'", Me.obj_search_text.Text)
    '                Case Else
    '                    filter = String.Empty
    '            End Select

    '            If Me.obj_search_text.Text = String.Empty Then
    '                filter = String.Empty
    '            End If
    '            Me.tbl_MstArtis.DefaultView.RowFilter = filter
    '        End If


    '    Catch ex As Exception
    '    End Try
    'End Sub
    'Private Sub obj_type_search_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles obj_type_search.SelectionChangeCommitted
    '    Dim oDataFiller As clsDataFiller = New clsDataFiller(Me.DSN)
    '    If Me.obj_type_search.SelectedValue = 0 Then
    '        Me.tbl_MstRekanan.Clear()
    '        oDataFiller.DataFill(Me.tbl_MstRekanan, "ms_MstRekanan_Select", " rekanan_active = 1 AND rekanantype_id <> 7 ")
    '        Me.FormatDgvMstrekanan(Me.DgvRekanan)
    '        Me.tbl_MstRekanan.DefaultView.Sort = "rekanan_name"
    '        Me.DgvRekanan.DataSource = Me.tbl_MstRekanan
    '    ElseIf Me.obj_type_search.SelectedValue = 1 Then
    '        Me.tbl_MstRekanan.Clear()
    '        oDataFiller.DataFill(Me.tbl_MstRekanan, "ms_MstRekanan_Select", " rekanan_active = 1 AND rekanantype_id = 7 ")
    '        Me.FormatDgvMstrekanan(Me.DgvRekanan)
    '        Me.tbl_MstRekanan.DefaultView.Sort = "rekanan_name"
    '        Me.DgvRekanan.DataSource = Me.tbl_MstRekanan
    '    Else
    '        Me.tbl_MstArtis.Clear()
    '        oDataFiller.DataFill(Me.tbl_MstArtis, "ms_MstArtis_Select", "active = 1")
    '        Me.FormatDgvMstArtis(Me.DgvRekanan)
    '        Me.tbl_MstArtis.DefaultView.Sort = "name"
    '        Me.DgvRekanan.DataSource = Me.tbl_MstArtis
    '    End If
    'End Sub

    Private Sub ftabData_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ftabData.SelectedIndexChanged
        'Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        'Select Case ftabData.SelectedIndex
        '    Case 0
        '        Me.ftabData.TabPages.Item(0).BackColor = Color.WhiteSmoke
        '        Me.ftabData.TabPages.Item(1).BackColor = Color.LavenderBlush
        '    Case 1
        '        Me.ftabData.TabPages.Item(0).BackColor = Color.LavenderBlush
        '        Me.ftabData.TabPages.Item(1).BackColor = Color.WhiteSmoke
        '        If Me.DgvRekanan.CurrentRow IsNot Nothing Then
        '            If Me.obj_type_search.SelectedValue = 0 Or Me.obj_type_search.SelectedValue = 1 Then
        '                Me.dlgTrnJurnalPVSelect_rekening_OpenRowDetilRekeningRekanan(Me.DgvRekanan.Rows(Me.DgvRekanan.CurrentRow.Index).Cells("rekanan_id").Value, dbConn)
        '            Else
        '                Me.dlgTrnJurnalPVSelect_rekening_OpenRowDetilRekeningArtis(Me.DgvRekanan.Rows(Me.DgvRekanan.CurrentRow.Index).Cells("code").Value, dbConn)
        '            End If
        '        End If
        'End Select
    End Sub

    Private Function dlgTrnJurnalPVSelect_rekening_OpenRowDetilRekeningArtis(ByVal artis_id As String, ByVal dbConn As OleDb.OleDbConnection) As Boolean
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        dbCmd = New OleDb.OleDbCommand("ms_MstArtisbank_Select", dbConn)
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@Criteria").Value = String.Format("artis_id='{0}'", artis_id)
        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)
        Me.tbl_MstArtisBank.Clear()

        Me.tbl_MstArtisBank = clsDataset.CreateTblMstArtisbank()
        tbl_MstArtisBank.Columns.Add(New DataColumn("select", GetType(System.Boolean)))
        tbl_MstArtisBank.Columns("select").DefaultValue = False

        Me.tbl_MstArtisBank.Columns("artis_id").DefaultValue = artis_id
        Me.tbl_MstArtisBank.Columns("artisbank_line").DefaultValue = DBNull.Value
        Me.tbl_MstArtisBank.Columns("artisbank_line").AutoIncrement = True
        Me.tbl_MstArtisBank.Columns("artisbank_line").AutoIncrementSeed = 10
        Me.tbl_MstArtisBank.Columns("artisbank_line").AutoIncrementStep = 10

        Try
            dbDA.Fill(Me.tbl_MstArtisBank)
            Me.FormatDgvMstArtisbank(Me.DgvRekening)
            Me.DgvRekening.DataSource = Me.tbl_MstArtisBank
        Catch ex As Exception
            Throw New Exception("dlgTrnJurnalPVSelect_rekening" & ": _OpenRowDetil()" & vbCrLf & ex.Message)
        End Try

    End Function

    Private Function dlgTrnJurnalPVSelect_rekening_OpenRowDetilRekeningRekanan(ByVal artis_id As String, ByVal dbConn As OleDb.OleDbConnection) As Boolean
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        dbCmd = New OleDb.OleDbCommand("ms_MstRekananbank_Select", dbConn)
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@Criteria").Value = String.Format("rekanan_id='{0}'", artis_id)
        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)
        Me.tbl_MstRekananBank.Clear()

        Me.tbl_MstRekananBank = clsDataset.CreateTblMstRekananbank()
        tbl_MstRekananBank.Columns.Add(New DataColumn("select", GetType(System.Boolean)))
        tbl_MstRekananBank.Columns("select").DefaultValue = False

        Me.tbl_MstRekananBank.Columns("rekanan_id").DefaultValue = artis_id
        Me.tbl_MstRekananBank.Columns("rekananbank_line").DefaultValue = DBNull.Value
        Me.tbl_MstRekananBank.Columns("rekananbank_line").AutoIncrement = True
        Me.tbl_MstRekananBank.Columns("rekananbank_line").AutoIncrementSeed = 10
        Me.tbl_MstRekananBank.Columns("rekananbank_line").AutoIncrementStep = 10

        Try
            dbDA.Fill(Me.tbl_MstRekananBank)
            Me.FormatDgvMstRekananbank(Me.DgvRekening)
            Me.DgvRekening.DataSource = Me.tbl_MstRekananBank
        Catch ex As Exception
            Throw New Exception("dlgTrnJurnalPVSelect_rekening_OpenRowDetilRekeningRekanan " & ": _OpenRowDetil()" & vbCrLf & ex.Message)
        End Try

    End Function

    Private Function dlgTrnJurnalPVSelect_rekening_OpenRowDetilRekeningRekananPrize(ByVal artis_id As String, ByVal dbConn As OleDb.OleDbConnection) As Boolean
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        dbCmd = New OleDb.OleDbCommand("ms_MstRekananBankWinner_Select", dbConn)
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@Criteria").Value = String.Format(" rekanan_id = '{0}'", artis_id)
        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)
        Me.tbl_MstRekananBankWinner.Clear()

        Me.tbl_MstRekananBankWinner = clsDataset.CreateTblMstRekananbankWinner()
        tbl_MstRekananBankWinner.Columns.Add(New DataColumn("select", GetType(System.Boolean)))
        tbl_MstRekananBankWinner.Columns("select").DefaultValue = False

        Me.tbl_MstRekananBankWinner.Columns("rekanan_id").DefaultValue = artis_id
        Me.tbl_MstRekananBankWinner.Columns("rekananbank_line").DefaultValue = DBNull.Value
        Me.tbl_MstRekananBankWinner.Columns("rekananbank_line").AutoIncrement = True
        Me.tbl_MstRekananBankWinner.Columns("rekananbank_line").AutoIncrementSeed = 10
        Me.tbl_MstRekananBankWinner.Columns("rekananbank_line").AutoIncrementStep = 10

        Try
            dbDA.Fill(Me.tbl_MstRekananBankWinner)
            Me.FormatDgvMstRekananbank(Me.DgvRekening)
            Me.DgvRekening.DataSource = Me.tbl_MstRekananBankWinner
        Catch ex As Exception
            Throw New Exception("dlgTrnJurnalPVSelect_rekening_OpenRowDetilRekeningRekanan " & ": _OpenRowDetil()" & vbCrLf & ex.Message)
        End Try

    End Function

    Private Sub DgvRekening_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvRekening.CellClick
        ' ''If e.ColumnIndex = 0 Then
        ' ''    Dim i As Integer

        ' ''    For i = 0 To Me.DgvRekening.Rows.Count - 1
        ' ''        If i <> e.RowIndex Then
        ' ''            Me.DgvRekening.Rows(i).Cells("select").Value = False
        ' ''        End If
        ' ''    Next
        ' ''End If
    End Sub

    'Private Sub DgvRekanan_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
    '    If e.ColumnIndex < 0 Or e.RowIndex < 0 Then
    '        Exit Sub
    '    End If
    '    If Me.DgvRekanan.CurrentRow IsNot Nothing Then
    '        Me.ftabData.SelectedIndex = 1
    '    End If
    'End Sub

    Private Sub DgvRekening_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvRekening.CellDoubleClick
        If Me.DgvRekening.Rows.Count > 0 Then
            Dim row As DataRow
            Dim thisRetObj As Collection = New Collection
            ' ''Dim i As Integer

            If Me.tbl_MstRekananBank.Rows.Count > 0 Then
                ' ''For i = 0 To Me.tbl_MstRekananBank.Rows.Count - 1
                ' ''If Me.tbl_MstRekananBank.Rows(i).Item("select") = True Then
                Me.retTbl.Clear()
                row = retTbl.NewRow
                row.Item("rekanan_id") = Me.DgvRekening.Item("rekanan_id", Me.DgvRekening.CurrentCell.RowIndex).Value 'Me.DgvRekanan.Rows(Me.DgvRekanan.CurrentRow.Index).Cells("name").Value
                row.Item("rekananbank_line") = Me.DgvRekening.Item("rekananbank_line", Me.DgvRekening.CurrentCell.RowIndex).Value 'Me.DgvRekanan.Rows(Me.DgvRekanan.CurrentRow.Index).Cells("name").Value
                row.Item("penerima_name") = Me.tbl_MstRekanan.Rows(0).Item("rekanan_name") 'Me.DgvRekanan.Item("rekanan_name", Me.DgvRekanan.CurrentCell.RowIndex).Value 'Me.DgvRekanan.Rows(Me.DgvRekanan.CurrentRow.Index).Cells("rekanan_name").Value
                row.Item("penerima_rekening") = Me.DgvRekening.Item("rekananbank_account", Me.DgvRekening.CurrentCell.RowIndex).Value 'Me.tbl_MstRekananBank.Rows(i).Item("rekananbank_account")
                row.Item("penerima_bank") = Me.DgvRekening.Item("rekananbank_rekening", Me.DgvRekening.CurrentCell.RowIndex).Value 'Me.tbl_MstRekananBank.Rows(i).Item("rekananbank_rekening")
                row.Item("penerima_bankaccountname") = Me.DgvRekening.Item("rekananbank_name", Me.DgvRekening.CurrentCell.RowIndex).Value 'Me.tbl_MstRekananBank.Rows(i).Item("rekananbank_name")
                Me.retTbl.Rows.Add(row)
                ' ''End If
                ' ''Next
            ElseIf Me.tbl_MstArtisBank.Rows.Count > 0 Then
                ' ''For i = 0 To Me.tbl_MstArtisBank.Rows.Count - 1
                ' ''    If Me.tbl_MstArtisBank.Rows(i).Item("select") = True Then
                Me.retTbl.NewRow()
                row = retTbl.NewRow
                row.Item("rekanan_id") = Me.DgvRekening.Item("artis_id", Me.DgvRekening.CurrentCell.RowIndex).Value 'Me.DgvRekanan.Rows(Me.DgvRekanan.CurrentRow.Index).Cells("name").Value
                row.Item("rekananbank_line") = Me.DgvRekening.Item("artisbank_line", Me.DgvRekening.CurrentCell.RowIndex).Value 'Me.DgvRekanan.Rows(Me.DgvRekanan.CurrentRow.Index).Cells("name").Value
                row.Item("penerima_name") = Me.tbl_MstRekanan.Rows(0).Item("rekanan_name") 'Me.DgvRekanan.Item("name", Me.DgvRekanan.CurrentCell.RowIndex).Value 'Me.DgvRekanan.Rows(Me.DgvRekanan.CurrentRow.Index).Cells("name").Value
                row.Item("penerima_rekening") = Me.DgvRekening.Item("artisbank_rekening", Me.DgvRekening.CurrentCell.RowIndex).Value ' Me.tbl_MstArtisBank.Rows(i).Item("artisbank_rekening")
                row.Item("penerima_bank") = Me.DgvRekening.Item("artisbank_name", Me.DgvRekening.CurrentCell.RowIndex).Value ' Me.tbl_MstArtisBank.Rows(i).Item("artisbank_name")
                row.Item("penerima_bankaccountname") = Me.DgvRekening.Item("artisbank_accountname", Me.DgvRekening.CurrentCell.RowIndex).Value 'Me.tbl_MstArtisBank.Rows(i).Item("artisbank_accountname")
                Me.retTbl.Rows.Add(row)
                ' ''End If
                ' ''Next
            End If

            Me.CloseButtonIsPressed = True

            Me.Close()
        End If
    End Sub

    Private Sub dgvArtisName_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvArtisName.CellClick
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim cookie As Byte() = Nothing
        Try
            dbConn.Open()
            clsApplicationRole.SetAppRole(dbConn, cookie)
            If Me.TombolRekeningClick = "other" Then
                Me.dlgTrnJurnalPVSelect_rekening_OpenRowDetilRekeningRekanan(Me.dgvArtisName.Rows(Me.dgvArtisName.CurrentRow.Index).Cells("rekanan_id").Value, dbConn)
            ElseIf Me.TombolRekeningClick = "prize" Then
                Me.dlgTrnJurnalPVSelect_rekening_OpenRowDetilRekeningRekananPrize(Me.dgvArtisName.Rows(Me.dgvArtisName.CurrentRow.Index).Cells("rekanan_id").Value, dbConn)
            ElseIf Me.TombolRekeningClick = "artis" Then
                Me.dlgTrnJurnalPVSelect_rekening_OpenRowDetilRekeningArtis(Me.dgvArtisName.Rows(Me.dgvArtisName.CurrentRow.Index).Cells("code").Value, dbConn)
            End If
        Catch ex As Exception
        Finally
            clsApplicationRole.UnsetAppRole(dbConn, cookie)
            dbConn.Close()
        End Try


    End Sub

    Private Sub obj_artisname_srch_TextChanged(sender As Object, e As EventArgs) Handles obj_artisname_srch.TextChanged
        Dim criteria As String

        If Me.TombolRekeningClick = "other" Then
            If Me.tbl_MstRekanan.Rows.Count > 0 Then
                'If Me.chk_artisName.Checked Then
                criteria = String.Format("rekanan_name LIKE '%{0}%'", Me.obj_artisname_srch.Text)
                Me.tbl_MstRekanan.DefaultView.RowFilter = criteria
                'End If
            Else
                MsgBox("Data does not exist, you must first load the data")
            End If
        ElseIf Me.TombolRekeningClick = "artis" Then
            If Me.tbl_MstArtis.Rows.Count > 0 Then
                'If Me.chk_artisName.Checked Then
                criteria = String.Format("name LIKE '%{0}%'", Me.obj_artisname_srch.Text)
                Me.tbl_MstArtis.DefaultView.RowFilter = criteria
                'End If
            Else
                MsgBox("Data does not exist, you must first load the data")
            End If
        ElseIf Me.TombolRekeningClick = "prize" Then
            If Me.tbl_MstRekanan.Rows.Count > 0 Then
                'If Me.chk_artisName.Checked Then
                criteria = String.Format("rekanan_name LIKE '%{0}%'", Me.obj_artisname_srch.Text)
                Me.tbl_MstRekanan.DefaultView.RowFilter = criteria
                'End If
            Else
                MsgBox("Data does not exist, you must first load the data")
            End If
        End If

    End Sub

   
    Private Sub dgvArtisName_SelectionChanged(sender As Object, e As EventArgs) Handles dgvArtisName.SelectionChanged
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim cookie As Byte() = Nothing

        Try
            dbConn.Open()
            clsApplicationRole.SetAppRole(dbConn, cookie)
            If Me.TombolRekeningClick = "other" Then
                Me.dlgTrnJurnalPVSelect_rekening_OpenRowDetilRekeningRekanan(Me.dgvArtisName.Rows(Me.dgvArtisName.CurrentRow.Index).Cells("rekanan_id").Value, dbConn)
            ElseIf Me.TombolRekeningClick = "prize" Then
                Me.dlgTrnJurnalPVSelect_rekening_OpenRowDetilRekeningRekanan(Me.dgvArtisName.Rows(Me.dgvArtisName.CurrentRow.Index).Cells("rekanan_id").Value, dbConn)
            ElseIf Me.TombolRekeningClick = "artis" Then
                Me.dlgTrnJurnalPVSelect_rekening_OpenRowDetilRekeningArtis(Me.dgvArtisName.Rows(Me.dgvArtisName.CurrentRow.Index).Cells("code").Value, dbConn)
            End If
        Catch ex As Exception
        Finally
            clsApplicationRole.UnsetAppRole(dbConn, cookie)
            dbConn.Close()
        End Try
    End Sub
End Class
