Public Class dlgTrnJurnal_PV_List_RekeningWinner

    Private DSN As String
    Private tbl_MstArtis As DataTable = clsDataset.CreateTblMstArtis()
    Private tbl_MstRekanan As DataTable = clsDataset.CreateTblMstRekananCombo()
    Private tbl_MstRekananWinner As DataTable = clsDataset.CreateTblMstRekananWinner()
    Private tbl_MstRekananBank As DataTable = clsDataset.CreateTblMstRekananbank()
    Private tbl_MstRekananBankWinner As DataTable = clsDataset.CreateTblMstRekananbankWinner()

    Private retTbl As DataTable = CreateTblRet()
    Private CloseButtonIsPressed As Boolean
    Private rekanan As Integer
    Private TombolRekeningClick As String
    Private channel_id As String
    Private Jurnal_ID_AppPrize As String
    Private cRekananID As String


#Region " Layout & Init UI "

    Private Function FormatDgvMstWinner(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
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
        Dim cRef_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cShow_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cPrize_eps As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn

        cRekanan_id.Name = "rekanan_id"
        cRekanan_id.HeaderText = "Winner ID"
        cRekanan_id.DataPropertyName = "rekanan_id"
        cRekanan_id.Width = 100
        cRekanan_id.Visible = True
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

        cRef_id.Name = "ref_id"
        cRef_id.HeaderText = "Ref. Id"
        cRef_id.DataPropertyName = "ref_id"
        cRef_id.Width = 100
        cRef_id.Visible = False
        cRef_id.ReadOnly = False

        cShow_id.Name = "show_id"
        cShow_id.HeaderText = "Show Id"
        cShow_id.DataPropertyName = "show_id"
        cShow_id.Width = 100
        cShow_id.Visible = False
        cShow_id.ReadOnly = False

        cPrize_eps.Name = "prize_eps"
        cPrize_eps.HeaderText = "Prize Eps."
        cPrize_eps.DataPropertyName = "prize_eps"
        cPrize_eps.Width = 100
        cPrize_eps.Visible = False
        cPrize_eps.ReadOnly = False

        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
        {cRekanan_id, cRekanan_name, cRekanan_badanhukum, cRekanan_namereport, cRekanantype_id, cRekanan_Addr1, _
         cRekanan_Addr2, cRekanan_city, cRekanan_telp, cRekanan_fax, cRekanan_email, cRekanan_NPWP, cRekanan_Create_by, _
         cRekanan_Create_dt, cRekanan_active, cRekanan_Bill, cRekanan_taxprefix, cRekanan_pkpname, cRekanan_salesperson, _
         cRekanan_trf, cRekanan_invsign, cRekanan_invsignpos, cRekanan_taxsign, cRekanan_taxsignpos, cChannel_id, cRef_id, cShow_id, cPrize_eps})

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
        tbl.Columns.Add(New DataColumn("ref_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("show_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("prize_eps", GetType(System.String)))
        '-------------------------------
        'Default Value: 
        tbl.Columns("rekanan_id").DefaultValue = ""
        tbl.Columns("rekananbank_line").DefaultValue = 0
        tbl.Columns("penerima_name").DefaultValue = ""
        tbl.Columns("penerima_rekening").DefaultValue = ""
        tbl.Columns("penerima_bank").DefaultValue = ""
        tbl.Columns("penerima_bankaccountname").DefaultValue = ""
        tbl.Columns("ref_id").DefaultValue = ""
        tbl.Columns("show_id").DefaultValue = ""
        tbl.Columns("prize_eps").DefaultValue = ""

        Return tbl
    End Function

#End Region

#Region " Opener "
    Public Shadows Function OpenDialog(ByVal owner As System.Windows.Forms.IWin32Window) As Object
        Dim oDataFiller As clsDataFiller = New clsDataFiller(Me.DSN)
        Dim isExist As Boolean = False
        Dim tbl_srchType As New DataTable
        Dim tbl_typeRekananSearch As New DataTable

        If cRekananID = "" Then
            oDataFiller.DataFillWinnerPrize(Me.tbl_MstRekananWinner, "ms_MstWinnerPrize_Select", Me.Jurnal_ID_AppPrize, "", "")
        Else
            oDataFiller.DataFillWinnerPrize(Me.tbl_MstRekananWinner, "ms_MstWinnerPrize_Select", Me.Jurnal_ID_AppPrize, String.Format("rekanan_id NOT IN ({0})", cRekananID), "")
        End If

        Me.lb_rekananname.Text = "Winner"
        Me.dgvWinnerName.Visible = True
        Me.SplitContainer1.SplitterDistance = 194
        Me.SplitContainer1.Panel1Collapsed = False
        Me.lbl_rekeninglist.Text = "List Rekening"
        Me.FormatDgvMstWinner(Me.dgvWinnerName)
        Me.tbl_MstRekananWinner.DefaultView.Sort = "rekanan_name"
        Me.dgvWinnerName.DataSource = Me.tbl_MstRekananWinner

        MyBase.ShowDialog(owner)
        Me.Cursor = Cursors.Arrow

        If Me.CloseButtonIsPressed Then
            Return Me.retTbl
        Else
            Return Nothing
        End If
    End Function
#End Region

    Public Sub New(ByVal channel_id As String, ByVal strDSN As String, ByVal rekanan As Integer, ByVal btnRekeningType As String, ByVal Jurnal_ID_AppPrize As String, ByVal cRekananID As String)
        InitializeComponent()
        Me.DSN = strDSN
        Me.rekanan = rekanan
        Me.TombolRekeningClick = btnRekeningType
        Me.channel_id = channel_id
        Me.Jurnal_ID_AppPrize = Jurnal_ID_AppPrize
        Me.cRekananID = cRekananID
    End Sub

    Private Sub btn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Ok.Click, btn_cancel.Click
        Dim obj As Button = sender

        If obj.Name = "btn_Ok" Then
            If Me.DgvRekening.Rows.Count > 0 Then
                Dim row As DataRow

                Me.retTbl.Clear()
                row = retTbl.NewRow
                row.Item("rekanan_id") = Me.tbl_MstRekananBankWinner.Rows(0).Item("rekanan_id") 'Me.DgvRekening.Item("rekanan_id", Me.DgvRekening.CurrentCell.RowIndex).Value 'Me.DgvRekanan.Rows(Me.DgvRekanan.CurrentRow.Index).Cells("name").Value
                row.Item("rekananbank_line") = Me.DgvRekening.Item("rekananbank_line", Me.DgvRekening.CurrentCell.RowIndex).Value 'Me.DgvRekanan.Rows(Me.DgvRekanan.CurrentRow.Index).Cells("name").Value
                row.Item("penerima_name") = Me.tbl_MstRekananWinner.Rows(0).Item("rekanan_name") 'Me.DgvRekanan.Item("rekanan_name", Me.DgvRekanan.CurrentCell.RowIndex).Value 'Me.DgvRekanan.Rows(Me.DgvRekanan.CurrentRow.Index).Cells("rekanan_name").Value
                row.Item("penerima_rekening") = Me.DgvRekening.Item("rekananbank_account", Me.DgvRekening.CurrentCell.RowIndex).Value 'Me.tbl_MstRekananBank.Rows(i).Item("rekananbank_account")
                row.Item("penerima_bank") = Me.DgvRekening.Item("rekananbank_rekening", Me.DgvRekening.CurrentCell.RowIndex).Value 'Me.tbl_MstRekananBank.Rows(i).Item("rekananbank_rekening")
                row.Item("penerima_bankaccountname") = Me.DgvRekening.Item("rekananbank_name", Me.DgvRekening.CurrentCell.RowIndex).Value 'Me.tbl_MstRekananBank.Rows(i).Item("rekananbank_name")
                row.Item("ref_id") = Me.dgvWinnerName.Item("ref_id", Me.dgvWinnerName.CurrentCell.RowIndex).Value
                row.Item("show_id") = Me.dgvWinnerName.Item("show_id", Me.dgvWinnerName.CurrentCell.RowIndex).Value
                row.Item("prize_eps") = Me.dgvWinnerName.Item("prize_eps", Me.dgvWinnerName.CurrentCell.RowIndex).Value
                Me.retTbl.Rows.Add(row)

                Me.CloseButtonIsPressed = True
            Else
                Me.CloseButtonIsPressed = False
            End If
        Else
            Me.CloseButtonIsPressed = False
        End If

        Me.Close()
    End Sub

    'Private Function dlgTrnJurnalPVSelect_rekening_OpenRowDetilRekeningWinner(ByVal artis_id As String, ByVal dbConn As OleDb.OleDbConnection) As Boolean
    '    Dim dbCmd As OleDb.OleDbCommand
    '    Dim dbDA As OleDb.OleDbDataAdapter

    '    dbCmd = New OleDb.OleDbCommand("ms_MstRekananbank_Select", dbConn)
    '    dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
    '    dbCmd.Parameters("@Criteria").Value = String.Format("rekanan_id='{0}'", artis_id)
    '    dbCmd.CommandType = CommandType.StoredProcedure
    '    dbDA = New OleDb.OleDbDataAdapter(dbCmd)
    '    Me.tbl_MstRekananBank.Clear()

    '    Me.tbl_MstRekananBank = clsDataset.CreateTblMstRekananbank()
    '    tbl_MstRekananBank.Columns.Add(New DataColumn("select", GetType(System.Boolean)))
    '    tbl_MstRekananBank.Columns("select").DefaultValue = False

    '    Me.tbl_MstRekananBank.Columns("rekanan_id").DefaultValue = artis_id
    '    Me.tbl_MstRekananBank.Columns("rekananbank_line").DefaultValue = DBNull.Value
    '    Me.tbl_MstRekananBank.Columns("rekananbank_line").AutoIncrement = True
    '    Me.tbl_MstRekananBank.Columns("rekananbank_line").AutoIncrementSeed = 10
    '    Me.tbl_MstRekananBank.Columns("rekananbank_line").AutoIncrementStep = 10

    '    Try
    '        dbDA.Fill(Me.tbl_MstRekananBank)
    '        Me.FormatDgvMstRekananbank(Me.DgvRekening)
    '        Me.DgvRekening.DataSource = Me.tbl_MstRekananBank
    '    Catch ex As Exception
    '        Throw New Exception("dlgTrnJurnalPVSelect_rekening_OpenRowDetilRekeningRekanan " & ": _OpenRowDetil()" & vbCrLf & ex.Message)
    '    End Try

    'End Function

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

    Private Sub DgvRekening_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvRekening.CellDoubleClick
        If Me.DgvRekening.Rows.Count > 0 Then
            Dim row As DataRow
            Dim thisRetObj As Collection = New Collection

            Me.retTbl.Clear()
            row = retTbl.NewRow
            row.Item("rekanan_id") = Me.tbl_MstRekananBankWinner.Rows(0).Item("rekanan_id") 'Me.DgvRekening.Item("rekanan_id", Me.DgvRekening.CurrentCell.RowIndex).Value 'Me.DgvRekanan.Rows(Me.DgvRekanan.CurrentRow.Index).Cells("name").Value
            row.Item("rekananbank_line") = Me.DgvRekening.Item("rekananbank_line", Me.DgvRekening.CurrentCell.RowIndex).Value 'Me.DgvRekanan.Rows(Me.DgvRekanan.CurrentRow.Index).Cells("name").Value
            row.Item("penerima_name") = Me.tbl_MstRekananWinner.Rows(0).Item("rekanan_name") 'Me.DgvRekanan.Item("rekanan_name", Me.DgvRekanan.CurrentCell.RowIndex).Value 'Me.DgvRekanan.Rows(Me.DgvRekanan.CurrentRow.Index).Cells("rekanan_name").Value
            row.Item("penerima_rekening") = Me.DgvRekening.Item("rekananbank_account", Me.DgvRekening.CurrentCell.RowIndex).Value 'Me.tbl_MstRekananBank.Rows(i).Item("rekananbank_account")
            row.Item("penerima_bank") = Me.DgvRekening.Item("rekananbank_rekening", Me.DgvRekening.CurrentCell.RowIndex).Value 'Me.tbl_MstRekananBank.Rows(i).Item("rekananbank_rekening")
            row.Item("penerima_bankaccountname") = Me.DgvRekening.Item("rekananbank_name", Me.DgvRekening.CurrentCell.RowIndex).Value 'Me.tbl_MstRekananBank.Rows(i).Item("rekananbank_name")
            row.Item("ref_id") = Me.dgvWinnerName.Item("ref_id", Me.dgvWinnerName.CurrentCell.RowIndex).Value
            row.Item("show_id") = Me.dgvWinnerName.Item("show_id", Me.dgvWinnerName.CurrentCell.RowIndex).Value
            row.Item("prize_eps") = Me.dgvWinnerName.Item("prize_eps", Me.dgvWinnerName.CurrentCell.RowIndex).Value
            Me.retTbl.Rows.Add(row)

            Me.CloseButtonIsPressed = True

            Me.Close()
        End If
    End Sub

    Private Sub dgvArtisName_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvWinnerName.CellClick
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim cookie As Byte() = Nothing
        Try
            dbConn.Open()
            clsApplicationRole.SetAppRole(dbConn, cookie)
            Me.dlgTrnJurnalPVSelect_rekening_OpenRowDetilRekeningRekananPrize(Me.dgvWinnerName.Rows(Me.dgvWinnerName.CurrentRow.Index).Cells("rekanan_id").Value, dbConn)
        Catch ex As Exception
        Finally
            clsApplicationRole.UnsetAppRole(dbConn, cookie)
            dbConn.Close()
        End Try
    End Sub
End Class
