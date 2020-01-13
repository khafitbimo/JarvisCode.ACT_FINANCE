'modified by Ari 
' 05 July 2012

Public Class dlgTrnJurnal_PV_List_TransferRekeningWinner

    Private mDSN As String
    Private retObj As Object

    Private mChannel_id As String
    Private mDgvCount As Integer
    Private mIsPosted As Boolean
    Private mPaymentType As String

    Private mCurrency_id As String
    Private mAmountForeign As Decimal
    Private mRate As Decimal
    Private mAmountIdr As Decimal

    Private mJurnal_id As String
    Private mJurnaldetil_line As Integer

    Private objError As ErrorProvider = New ErrorProvider


    Private myOwner As System.Windows.Forms.IWin32Window

    Private tbl_TrnBankTransfer As DataTable = clsDataset.CreateTblTrnBanktransfer()
    Private tbl_MstSlipFormat As DataTable = clsDataset.CreateTblMstSlipformatCombo()
    Private tbl_MstCurrency As DataTable = clsDataset.CreateTblMstCurrencyCombo()
    Private tbl_MstPaymentType As DataTable = clsDataset.CreateTblMstPaymenttypeCombo()
    Private tbl_MstPurposeFund As DataTable = clsDataset.CreateTblMstPurposefundCombo()
    Private tbl_MstShow As DataTable = clsDataset.CreateTblMstShowCombo
    Private tbl_MstChannelBank As DataTable = clsDataset.CreateTblMstChannelBank()
    Private tbl_listRekening As DataTable = clsDataset.CreateTblTrnContract()
    Private tbl_artist As DataTable = clsDataset.CreateTblMstArtis()
    Private tbl_MstRekanan As DataTable = clsDataset.CreateTblMstRekananCombo()
    Private tbl_rekening As DataTable = CreateTblMstChannelbankRekening()
    Private tbl_ListCheckAccDebit As DataTable = New DataTable
    Private tbl_ACCHutang As DataTable = New DataTable


    Private BtnRekArtisStatus As String
    Private BtnRekWinnerPrizeStatus As String

    Private channel As String
    Private user_name As String
    Private rekanan As Integer

    '--amount area
    'Private amount_idr As Decimal
    'Private rates As Decimal
    'Private amount_idrforeign As Decimal

#Region " Properties "

    Public ReadOnly Property DSN() As String
        Get
            Return mDSN
        End Get
    End Property
#End Region

#Region " Constructor & Default Function"

    Public Sub New(ByVal dsn As String,
                    ByVal channel_id As String,
                    ByVal dgvCount As Integer, _
                    ByVal isPosted As Boolean, _
                    ByVal tbl_TrnBankTransferTemps As DataTable, _
                    ByVal currency_id As String, _
                    ByVal amountForeign As Decimal, _
                    ByVal rate As Decimal, _
                    ByVal amountIdr As Decimal, _
                    ByVal paymentType As String, _
                    ByVal tbl_MstSlipFormat_temps As DataTable, _
                    ByVal tbl_MstCurrency_temps As DataTable, _
                    ByVal tbl_MstPaymentType_temps As DataTable, _
                    ByVal tbl_MstPurposeFund_temps As DataTable, _
                    ByVal tbl_project As DataTable, _
                    ByVal jurnal_id As String, _
                    ByVal jurnaldetil_line As Integer, _
                    ByVal BtnRekArtisStatus As String, _
                    ByVal BtnRekWinnerPrizeStatus As String, _
                    Optional ByVal tbl_listRekening As DataTable = Nothing, _
                    Optional ByVal channel As String = "NTV", _
                    Optional ByVal username As String = "", _
                    Optional ByVal rekanan As Integer = 0, _
                    Optional ByVal tbl_ListCheckAccDebit As DataTable = Nothing)

        'Optional ByVal amount_idr As Decimal = 0, Optional ByVal rates As Decimal = 0, Optional ByVal amount_idrforeign As Decimal = 0

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.mDSN = dsn
        Me.mChannel_id = channel_id
        Me.mDgvCount = dgvCount
        Me.mIsPosted = isPosted
        Me.tbl_TrnBankTransfer = tbl_TrnBankTransferTemps.Copy
        Me.mCurrency_id = currency_id
        Me.mAmountForeign = amountForeign
        Me.mRate = rate
        Me.mAmountIdr = amountIdr
        Me.mPaymentType = paymentType
        Me.tbl_MstSlipFormat = tbl_MstSlipFormat_temps
        Me.tbl_MstCurrency = tbl_MstCurrency_temps
        Me.tbl_MstPaymentType = tbl_MstPaymentType_temps
        Me.tbl_MstPurposeFund = tbl_MstPurposeFund_temps
        Me.tbl_MstShow = tbl_project
        Me.mJurnal_id = jurnal_id
        Me.mJurnaldetil_line = jurnaldetil_line
        Me.tbl_listRekening = tbl_listRekening.Copy
        Me.user_name = username
        Me.channel = channel
        Me.rekanan = rekanan
        Me.BtnRekArtisStatus = BtnRekArtisStatus
        Me.BtnRekWinnerPrizeStatus = BtnRekWinnerPrizeStatus
        Me.tbl_ListCheckAccDebit = tbl_ListCheckAccDebit
        '==
        ''--amount area
        'Me.amount_idr = amount_idr
        'Me.rates = rates
        'Me.amount_idrforeign = amount_idrforeign
        '===
        Dim oDataFiller As New clsDataFiller(Me.DSN)
        Me.tbl_artist.Clear()
        Me.tbl_MstRekanan.Clear()

        oDataFiller.DataFill(Me.tbl_artist, "ms_MstArtis_Select_2", "")
        oDataFiller.DataFill(tbl_rekening, "ms_MstRekening_Bank", "", Me.channel)
        oDataFiller.DataFill(Me.tbl_ACCHutang, "act_selectAccRef_Detil", "accref_id = 4801")

    End Sub

    Public Shadows Function OpenDialog(ByVal owner As System.Windows.Forms.IWin32Window) As Object
        Me.myOwner = owner
        MyBase.ShowDialog(owner)
        Return retObj
    End Function

#End Region

#Region "Data Set"
    Public Shared Function CreateTblMstChannelbankRekening() As DataTable
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

#End Region

#Region " UI Layout & Format "
    Private Function FormatDgvTrnBanktransfer(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        Dim cBanktransfer_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnal_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnaldetil_line As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBanktransfer_dt As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cSlipformat_id As System.Windows.Forms.DataGridViewComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn
        Dim cRekanan_id As System.Windows.Forms.DataGridViewComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn
        Dim cRekananbank_line As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBanktransfer_rekening As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cPurposefund_id As System.Windows.Forms.DataGridViewComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn
        Dim cPaymenttype_id As System.Windows.Forms.DataGridViewComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn
        Dim cBanktransfer_pembayaranrek As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBanktransfer_idr As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBanktransfer_foreign As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBanktransfer_foreignrate As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cCurrency_id As System.Windows.Forms.DataGridViewComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn
        Dim cBanktransfer_bi_idr As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBanktransfer_bi_foreign As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBanktransfer_message As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cChannel_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBanktransfer_isdisabled As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBanktransfer_invoice As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBanktransfer_episode1 As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBanktransfer_episode2 As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cProject_id As System.Windows.Forms.DataGridViewComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn
        Dim cRekananartis_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBanktransfer_episode As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cChannelbank_line As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBanktransfer_create_by As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBanktransfer_create_date As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn

        Dim cJurnaldetil_bilyetperson As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnaldetil_bilyetpersonRekening As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnaldetil_bilyetpersonBank As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnaldetil_bilyetpersonBankAccountName As New System.Windows.Forms.DataGridViewTextBoxColumn

        Dim cRekening_debit As New System.Windows.Forms.DataGridViewComboBoxColumn
        Dim cBank_debit As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAccount_bank_debit As New System.Windows.Forms.DataGridViewTextBoxColumn

        cBanktransfer_id.Name = "banktransfer_id"
        cBanktransfer_id.HeaderText = "ID"
        cBanktransfer_id.DataPropertyName = "banktransfer_id"
        cBanktransfer_id.Width = 100
        cBanktransfer_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cBanktransfer_id.Visible = True
        cBanktransfer_id.ReadOnly = True
        cBanktransfer_id.DefaultCellStyle.BackColor = Color.Gainsboro


        cJurnal_id.Name = "jurnal_id"
        cJurnal_id.HeaderText = "jurnal_id"
        cJurnal_id.DataPropertyName = "jurnal_id"
        cJurnal_id.Width = 100
        cJurnal_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cJurnal_id.Visible = False
        cJurnal_id.ReadOnly = False

        cJurnaldetil_line.Name = "jurnaldetil_line"
        cJurnaldetil_line.HeaderText = "jurnaldetil_line"
        cJurnaldetil_line.DataPropertyName = "jurnaldetil_line"
        cJurnaldetil_line.Width = 100
        cJurnaldetil_line.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cJurnaldetil_line.Visible = False
        cJurnaldetil_line.ReadOnly = False

        cBanktransfer_dt.Name = "banktransfer_dt"
        cBanktransfer_dt.HeaderText = "Trans. Date"
        cBanktransfer_dt.DataPropertyName = "banktransfer_dt"
        cBanktransfer_dt.Width = 100
        cBanktransfer_dt.Visible = True
        cBanktransfer_dt.ReadOnly = False
        'cBanktransfer_dt.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet

        cSlipformat_id.Name = "slipformat_id"
        cSlipformat_id.HeaderText = "Penggunaan Dana"
        cSlipformat_id.DataPropertyName = "slipformat_id"
        cSlipformat_id.Width = 180
        cSlipformat_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cSlipformat_id.Visible = True
        cSlipformat_id.ReadOnly = False
        cSlipformat_id.DataSource = Me.tbl_MstSlipFormat
        cSlipformat_id.ValueMember = "slipformat_id"
        cSlipformat_id.DisplayMember = "slipformat_name"
        cSlipformat_id.DisplayStyleForCurrentCellOnly = True


        cRekanan_id.Name = "rekanan_id"
        cRekanan_id.HeaderText = "Artist/Rekanan"
        cRekanan_id.DataPropertyName = "rekanan_id"
        cRekanan_id.Width = 140
        cRekanan_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cRekanan_id.Visible = True
        cRekanan_id.ReadOnly = True
        cRekanan_id.DataSource = tbl_artist
        cRekanan_id.ValueMember = "code"
        cRekanan_id.DisplayMember = "name"
        cRekanan_id.DefaultCellStyle.BackColor = Color.Gainsboro
        cRekanan_id.DisplayStyleForCurrentCellOnly = True



        cRekananbank_line.Name = "rekananbank_line"
        cRekananbank_line.HeaderText = "Bank Line"
        cRekananbank_line.DataPropertyName = "rekananbank_line"
        cRekananbank_line.Width = 100
        cRekananbank_line.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cRekananbank_line.Visible = False
        cRekananbank_line.ReadOnly = False

        cBanktransfer_rekening.Name = "banktransfer_rekening"
        cBanktransfer_rekening.HeaderText = "banktransfer_rekening"
        cBanktransfer_rekening.DataPropertyName = "banktransfer_rekening"
        cBanktransfer_rekening.Width = 100
        cBanktransfer_rekening.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cBanktransfer_rekening.Visible = False
        cBanktransfer_rekening.ReadOnly = False

        cPurposefund_id.Name = "purposefund_id"
        cPurposefund_id.HeaderText = "Pengg. Dana"
        cPurposefund_id.DataPropertyName = "purposefund_id"
        cPurposefund_id.Width = 130
        cPurposefund_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cPurposefund_id.Visible = True
        cPurposefund_id.ReadOnly = True
        cPurposefund_id.DataSource = Me.tbl_MstPurposeFund
        cPurposefund_id.ValueMember = "purposefund_id"
        cPurposefund_id.DisplayMember = "purposefund_name"
        cPurposefund_id.DisplayStyleForCurrentCellOnly = True
        cPurposefund_id.DefaultCellStyle.BackColor = Color.Gainsboro 'Color.Gainsboro

        cPaymenttype_id.Name = "paymenttype_id"
        cPaymenttype_id.HeaderText = "Payment Type"
        cPaymenttype_id.DataPropertyName = "paymenttype_id"
        cPaymenttype_id.Width = 100
        cPaymenttype_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cPaymenttype_id.Visible = True
        cPaymenttype_id.ReadOnly = False
        cPaymenttype_id.DataSource = Me.tbl_MstPaymentType
        cPaymenttype_id.ValueMember = "paymenttype_id"
        cPaymenttype_id.DisplayMember = "paymenttype_name"
        cPaymenttype_id.DisplayStyleForCurrentCellOnly = True
        cPaymenttype_id.DefaultCellStyle.BackColor = Color.White 'Color.Gainsboro

        cBanktransfer_pembayaranrek.Name = "banktransfer_pembayaranrek"
        cBanktransfer_pembayaranrek.HeaderText = "banktransfer_pembayaranrek"
        cBanktransfer_pembayaranrek.DataPropertyName = "banktransfer_pembayaranrek"
        cBanktransfer_pembayaranrek.Width = 100
        cBanktransfer_pembayaranrek.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cBanktransfer_pembayaranrek.Visible = False
        cBanktransfer_pembayaranrek.ReadOnly = False

        cBanktransfer_idr.Name = "banktransfer_idr"
        cBanktransfer_idr.HeaderText = "Amount IDR"
        cBanktransfer_idr.DataPropertyName = "banktransfer_idr"
        cBanktransfer_idr.Width = 100
        cBanktransfer_idr.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cBanktransfer_idr.Visible = True
        cBanktransfer_idr.ReadOnly = True
        cBanktransfer_idr.DefaultCellStyle.Format = "#,##0"
        cBanktransfer_idr.DefaultCellStyle.BackColor = Color.Gainsboro

        cBanktransfer_foreign.Name = "banktransfer_foreign"
        cBanktransfer_foreign.HeaderText = "Amount"
        cBanktransfer_foreign.DataPropertyName = "banktransfer_foreign"
        cBanktransfer_foreign.Width = 100
        cBanktransfer_foreign.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cBanktransfer_foreign.Visible = True
        cBanktransfer_foreign.ReadOnly = False
        cBanktransfer_foreign.DefaultCellStyle.Format = "#,##0.00"

        cBanktransfer_foreignrate.Name = "banktransfer_foreignrate"
        cBanktransfer_foreignrate.HeaderText = "Rate"
        cBanktransfer_foreignrate.DataPropertyName = "banktransfer_foreignrate"
        cBanktransfer_foreignrate.Width = 100
        cBanktransfer_foreignrate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cBanktransfer_foreignrate.Visible = True
        cBanktransfer_foreignrate.ReadOnly = True
        cBanktransfer_foreignrate.DefaultCellStyle.Format = "#,##0.00"
        cBanktransfer_foreignrate.DefaultCellStyle.BackColor = Color.Gainsboro


        cCurrency_id.Name = "currency_id"
        cCurrency_id.HeaderText = "Curr"
        cCurrency_id.DataPropertyName = "currency_id"
        cCurrency_id.Width = 100
        cCurrency_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cCurrency_id.Visible = True
        cCurrency_id.ReadOnly = True
        cCurrency_id.DataSource = Me.tbl_MstCurrency
        cCurrency_id.ValueMember = "currency_id"
        cCurrency_id.DisplayMember = "currency_shortname"
        cCurrency_id.DisplayStyleForCurrentCellOnly = True
        cCurrency_id.DefaultCellStyle.BackColor = Color.Gainsboro


        cBanktransfer_bi_idr.Name = "banktransfer_bi_idr"
        cBanktransfer_bi_idr.HeaderText = "Transfer Amount IDR"
        cBanktransfer_bi_idr.DataPropertyName = "banktransfer_bi_idr"
        cBanktransfer_bi_idr.Width = 150
        cBanktransfer_bi_idr.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cBanktransfer_bi_idr.Visible = True
        cBanktransfer_bi_idr.ReadOnly = True
        cBanktransfer_bi_idr.DefaultCellStyle.Format = "#,##0"
        cBanktransfer_bi_idr.DefaultCellStyle.BackColor = Color.Gainsboro



        cBanktransfer_bi_foreign.Name = "banktransfer_bi_foreign"
        cBanktransfer_bi_foreign.HeaderText = "Transfer Amount"
        cBanktransfer_bi_foreign.DataPropertyName = "banktransfer_bi_foreign"
        cBanktransfer_bi_foreign.Width = 130
        cBanktransfer_bi_foreign.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cBanktransfer_bi_foreign.Visible = True
        cBanktransfer_bi_foreign.ReadOnly = False
        cBanktransfer_bi_foreign.DefaultCellStyle.Format = "#,##0.00"

        cBanktransfer_message.Name = "banktransfer_message"
        cBanktransfer_message.HeaderText = "Received By"
        cBanktransfer_message.DataPropertyName = "banktransfer_message"
        cBanktransfer_message.Width = 100
        cBanktransfer_message.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cBanktransfer_message.Visible = True
        cBanktransfer_message.ReadOnly = False
        cBanktransfer_message.DefaultCellStyle.BackColor = Color.Gainsboro

        cChannel_id.Name = "channel_id"
        cChannel_id.HeaderText = "channel_id"
        cChannel_id.DataPropertyName = "channel_id"
        cChannel_id.Width = 100
        cChannel_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cChannel_id.Visible = False
        cChannel_id.ReadOnly = False

        cBanktransfer_isdisabled.Name = "banktransfer_isdisabled"
        cBanktransfer_isdisabled.HeaderText = "banktransfer_isdisabled"
        cBanktransfer_isdisabled.DataPropertyName = "banktransfer_isdisabled"
        cBanktransfer_isdisabled.Width = 100
        cBanktransfer_isdisabled.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cBanktransfer_isdisabled.Visible = False
        cBanktransfer_isdisabled.ReadOnly = False

        cBanktransfer_invoice.Name = "banktransfer_invoice"
        cBanktransfer_invoice.HeaderText = "Invoice" '"Received By"
        cBanktransfer_invoice.DataPropertyName = "banktransfer_invoice"
        cBanktransfer_invoice.Width = 100
        cBanktransfer_invoice.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cBanktransfer_invoice.Visible = True
        cBanktransfer_invoice.ReadOnly = False
        cBanktransfer_invoice.DefaultCellStyle.BackColor = Color.White

        cBanktransfer_episode1.Name = "banktransfer_episode1"
        cBanktransfer_episode1.HeaderText = "banktransfer_episode1"
        cBanktransfer_episode1.DataPropertyName = "banktransfer_episode1"
        cBanktransfer_episode1.Width = 100
        cBanktransfer_episode1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cBanktransfer_episode1.Visible = False
        cBanktransfer_episode1.ReadOnly = False

        cBanktransfer_episode2.Name = "banktransfer_episode2"
        cBanktransfer_episode2.HeaderText = "banktransfer_episode2"
        cBanktransfer_episode2.DataPropertyName = "banktransfer_episode2"
        cBanktransfer_episode2.Width = 100
        cBanktransfer_episode2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cBanktransfer_episode2.Visible = False
        cBanktransfer_episode2.ReadOnly = False

        cProject_id.Name = "project_id"
        cProject_id.HeaderText = "Program"
        cProject_id.DataPropertyName = "project_id"
        cProject_id.Width = 150
        cProject_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cProject_id.Visible = True
        cProject_id.ReadOnly = False
        cProject_id.DataSource = Me.tbl_MstShow
        cProject_id.ValueMember = "show_id"
        cProject_id.DisplayMember = "show_title"
        cProject_id.DisplayStyleForCurrentCellOnly = True
        'cProject_id.DefaultCellStyle.BackColor = Color.Gainsboro


        cRekananartis_id.Name = "rekananartis_id"
        cRekananartis_id.HeaderText = "rekananartis_id"
        cRekananartis_id.DataPropertyName = "rekananartis_id"
        cRekananartis_id.Width = 100
        cRekananartis_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cRekananartis_id.Visible = False
        cRekananartis_id.ReadOnly = False

        cBanktransfer_episode.Name = "banktransfer_episode"
        cBanktransfer_episode.HeaderText = "Episode"
        cBanktransfer_episode.DataPropertyName = "banktransfer_episode"
        cBanktransfer_episode.Width = 100
        cBanktransfer_episode.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cBanktransfer_episode.Visible = True
        cBanktransfer_episode.ReadOnly = False 'true remark by pts 20130711
        'cBanktransfer_episode.DefaultCellStyle.BackColor = Color.Gainsboro

        cChannelbank_line.Name = "channelbank_line"
        cChannelbank_line.HeaderText = "Bank Line Channel"
        cChannelbank_line.DataPropertyName = "channelbank_line"
        cChannelbank_line.Width = 100
        cChannelbank_line.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cChannelbank_line.Visible = False
        cChannelbank_line.ReadOnly = False

        cBanktransfer_create_by.Name = "banktransfer_create_by"
        cBanktransfer_create_by.HeaderText = "banktransfer by"
        cBanktransfer_create_by.DataPropertyName = "banktransfer_create_by"
        cBanktransfer_create_by.Width = 150
        cBanktransfer_create_by.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cBanktransfer_create_by.Visible = True
        cBanktransfer_create_by.ReadOnly = True
        cBanktransfer_create_by.DefaultCellStyle.BackColor = Color.Gainsboro

        cBanktransfer_create_date.Name = "banktransfer_create_date"
        cBanktransfer_create_date.HeaderText = "banktransfer date"
        cBanktransfer_create_date.DataPropertyName = "banktransfer_create_date"
        cBanktransfer_create_date.Width = 150
        cBanktransfer_create_date.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cBanktransfer_create_date.Visible = True
        cBanktransfer_create_date.ReadOnly = True
        cBanktransfer_create_date.DefaultCellStyle.BackColor = Color.Gainsboro

        cJurnaldetil_bilyetperson.Name = "jurnalbilyet_receiveperson"
        cJurnaldetil_bilyetperson.HeaderText = "Received By"
        cJurnaldetil_bilyetperson.DataPropertyName = "jurnalbilyet_receiveperson"
        cJurnaldetil_bilyetperson.Width = 150
        cJurnaldetil_bilyetperson.Visible = False
        cJurnaldetil_bilyetperson.ReadOnly = True
        cJurnaldetil_bilyetperson.DefaultCellStyle.BackColor = Color.Gainsboro

        cJurnaldetil_bilyetpersonRekening.Name = "jurnalbilyet_receiverekening"
        cJurnaldetil_bilyetpersonRekening.HeaderText = "Account Bank"
        cJurnaldetil_bilyetpersonRekening.DataPropertyName = "jurnalbilyet_receiverekening"
        cJurnaldetil_bilyetpersonRekening.Width = 150
        cJurnaldetil_bilyetpersonRekening.Visible = True
        cJurnaldetil_bilyetpersonRekening.ReadOnly = True
        cJurnaldetil_bilyetpersonRekening.DefaultCellStyle.BackColor = Color.Gainsboro


        cJurnaldetil_bilyetpersonBank.Name = "jurnalbilyet_receivebank"
        cJurnaldetil_bilyetpersonBank.HeaderText = "Receive Bank"
        cJurnaldetil_bilyetpersonBank.DataPropertyName = "jurnalbilyet_receivebank"
        cJurnaldetil_bilyetpersonBank.Width = 200
        cJurnaldetil_bilyetpersonBank.Visible = True
        cJurnaldetil_bilyetpersonBank.ReadOnly = True
        cJurnaldetil_bilyetpersonBank.DefaultCellStyle.BackColor = Color.Gainsboro


        cJurnaldetil_bilyetpersonBankAccountName.Name = "jurnalbilyet_receiveaccountname"
        cJurnaldetil_bilyetpersonBankAccountName.HeaderText = "Artis Name"
        cJurnaldetil_bilyetpersonBankAccountName.DataPropertyName = "jurnalbilyet_receiveaccountname"
        cJurnaldetil_bilyetpersonBankAccountName.Width = 200
        cJurnaldetil_bilyetpersonBankAccountName.Visible = False
        cJurnaldetil_bilyetpersonBankAccountName.ReadOnly = True
        cJurnaldetil_bilyetpersonBankAccountName.DefaultCellStyle.BackColor = Color.Gainsboro

        cRekening_debit.Name = "rekening_debit"
        cRekening_debit.HeaderText = "Rekening Debit"
        cRekening_debit.DataPropertyName = "rekening_debit"
        cRekening_debit.Width = 120
        cRekening_debit.Visible = True
        cRekening_debit.ReadOnly = False
        cRekening_debit.DataSource = tbl_rekening
        cRekening_debit.ValueMember = "channelbank_rekening"
        cRekening_debit.DisplayMember = "channelbank_rekening"
        cRekening_debit.DisplayStyleForCurrentCellOnly = True
        cRekening_debit.DefaultCellStyle.BackColor = Color.White

        cBank_debit.Name = "bank_debit"
        cBank_debit.HeaderText = "Bank Debit"
        cBank_debit.DataPropertyName = "bank_debit"
        cBank_debit.Width = 100
        cBank_debit.Visible = True
        cBank_debit.ReadOnly = True
        cBank_debit.DefaultCellStyle.BackColor = Color.Gainsboro


        cAccount_bank_debit.Name = "account_bank_debit"
        cAccount_bank_debit.HeaderText = "Account Bank Debit"
        cAccount_bank_debit.DataPropertyName = "account_bank_debit"
        cAccount_bank_debit.Width = 140
        cAccount_bank_debit.Visible = True
        cAccount_bank_debit.ReadOnly = False
        cAccount_bank_debit.DefaultCellStyle.BackColor = Color.Gainsboro


        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
        {cBanktransfer_id, cJurnal_id, cJurnaldetil_line, cBanktransfer_dt, _
          cBanktransfer_invoice, cBanktransfer_message, cJurnaldetil_bilyetpersonRekening, cJurnaldetil_bilyetpersonBank, cJurnaldetil_bilyetpersonBankAccountName, _
        cRekananbank_line, cRekanan_id, cProject_id, cBanktransfer_episode, cSlipformat_id, cPurposefund_id, _
        cCurrency_id, cBanktransfer_foreign, cBanktransfer_bi_foreign, cBanktransfer_foreignrate, _
         cBanktransfer_idr, cBanktransfer_bi_idr, cPaymenttype_id, _
        cChannelbank_line, cBanktransfer_rekening, cBanktransfer_pembayaranrek, cChannel_id, cBanktransfer_isdisabled, cBanktransfer_episode1, cBanktransfer_episode2, cRekananartis_id, cBanktransfer_create_by, cBanktransfer_create_date, _
        cRekening_debit, cBank_debit, cAccount_bank_debit})

        objDgv.AutoGenerateColumns = False
        objDgv.AllowUserToAddRows = False
        objDgv.AllowUserToOrderColumns = False
        objDgv.AllowUserToDeleteRows = True

        'objDgv.allow()
    End Function
#End Region

#Region " User defined function "

#End Region

    Private Sub dlgTrnJurnal_PV_List_TransferRekening_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.Cursor = Cursors.WaitCursor
        Me.Cursor = Cursors.Arrow


        Me.FormatDgvTrnBanktransfer(Me.DgvDetil)
        Me.DgvDetil.DataSource = Me.tbl_TrnBankTransfer

        Me.tbl_MstShow.Rows.Add(0).Item("show_id") = " "
        Me.tbl_artist.Rows.Add(0).Item("code") = " "

        ' ''Me.DgvDetil.SelectionMode = DataGridViewSelectionMode.FullRowSelect


        If DgvDetil.Rows.Count > 0 Then
            For i As Integer = 0 To DgvDetil.Rows.Count - 1
                If i = 0 Then
                    Me.txtHitung.Text = Format(DgvDetil.Rows(i).Cells("banktransfer_idr").Value, "#,###0.00")
                Else
                    Me.txtHitung.Text = Format(CType(Me.txtHitung.Text, Decimal) + DgvDetil.Rows(i).Cells("banktransfer_idr").Value, "#,###0.00")
                End If
            Next
        Else
            Me.txtHitung.Text = "0.00"
        End If

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.retObj = Nothing
        Me.Close()
    End Sub

    Private Sub Btn_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim oDataFiller As New clsDataFiller(Me.DSN)
        If mDgvCount > 0 Then
            If Me.mIsPosted = False Then
                Dim retTbl As DataTable = New DataTable
                'Dim dlg As New dlgTrnJurnal_PV_List_Rekening(Me.DSN)
                Dim dlg As New dlgContractChoice(Me.DSN, Me.tbl_listRekening, Me.channel, Me.user_name)
                'Dim row As DataRow

                retTbl.Clear()
                Me.Cursor = Cursors.WaitCursor
                retTbl = dlg.OpenDialog(Me)
                Me.Cursor = Cursors.Arrow

                If retTbl IsNot Nothing Then
                    If retTbl.Rows.Count <> 0 Then
                        Me.tbl_TrnBankTransfer = retTbl.Copy
                        Me.DgvDetil.DataSource = tbl_TrnBankTransfer

                        If DgvDetil.Rows.Count > 0 Then
                            For i As Integer = 0 To DgvDetil.Rows.Count - 1
                                If i = 0 Then
                                    Me.txtHitung.Text = Format(DgvDetil.Rows(i).Cells("banktransfer_idr").Value, "#,###0.00")
                                Else
                                    Me.txtHitung.Text = Format(CType(Me.txtHitung.Text, Decimal) + DgvDetil.Rows(i).Cells("banktransfer_idr").Value, "#,###0.00")
                                End If
                            Next
                        Else
                            Me.txtHitung.Text = "0.00"
                        End If
                    End If
                End If

            End If
        Else
            Dim retTbl As DataTable = tbl_TrnBankTransfer 'clsDataset.CreateTblTrnBanktransfer()
            Dim dlg As New dlgContractChoice(Me.DSN, Me.tbl_listRekening, Me.channel, Me.user_name)

            retTbl.Clear()
            Me.Cursor = Cursors.WaitCursor
            retTbl = dlg.OpenDialog(Me)
            Me.Cursor = Cursors.Arrow

            If retTbl IsNot Nothing Then
                If retTbl.Rows.Count <> 0 Then
                    Me.tbl_TrnBankTransfer = retTbl.Copy
                    Me.DgvDetil.DataSource = tbl_TrnBankTransfer

                    If DgvDetil.Rows.Count > 0 Then
                        For i As Integer = 0 To DgvDetil.Rows.Count - 1
                            If i = 0 Then
                                Me.txtHitung.Text = Format(DgvDetil.Rows(i).Cells("banktransfer_idr").Value, "#,###0.00")
                            Else
                                Me.txtHitung.Text = Format(CType(Me.txtHitung.Text, Decimal) + DgvDetil.Rows(i).Cells("banktransfer_idr").Value, "#,###0.00")
                            End If
                        Next
                    Else
                        Me.txtHitung.Text = "0.00"
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub DgvDetil_CellValidated(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvDetil.CellValidated
        Dim obj As DataGridView = sender
        Dim colName As String = obj.Columns(e.ColumnIndex).Name

        If obj.Columns(e.ColumnIndex).Name = "slipformat_id" Then
            If obj.Rows(e.RowIndex).Cells("slipformat_id").Value = "SF070022" Or _
               obj.Rows(e.RowIndex).Cells("slipformat_id").Value = "SF070028" Or _
               obj.Rows(e.RowIndex).Cells("slipformat_id").Value = "SF070037" Or _
               obj.Rows(e.RowIndex).Cells("slipformat_id").Value = "SF070040" Or _
               obj.Rows(e.RowIndex).Cells("slipformat_id").Value = "SF070041" Or _
               obj.Rows(e.RowIndex).Cells("slipformat_id").Value = "SF070042" Or _
               obj.Rows(e.RowIndex).Cells("slipformat_id").Value = "SF070044" Or _
               obj.Rows(e.RowIndex).Cells("slipformat_id").Value = "SF070048" Then

                obj.Rows(e.RowIndex).Cells("purposefund_id").Value = 1

            ElseIf obj.Rows(e.RowIndex).Cells("slipformat_id").Value = "SF070030" Or _
               obj.Rows(e.RowIndex).Cells("slipformat_id").Value = "SF070031" Or _
               obj.Rows(e.RowIndex).Cells("slipformat_id").Value = "SF070038" Or _
               obj.Rows(e.RowIndex).Cells("slipformat_id").Value = "SF070043" Or _
               obj.Rows(e.RowIndex).Cells("slipformat_id").Value = "SF070045" Or _
               obj.Rows(e.RowIndex).Cells("slipformat_id").Value = "SF070047" Or _
               obj.Rows(e.RowIndex).Cells("slipformat_id").Value = "SF070049" Then

                obj.Rows(e.RowIndex).Cells("purposefund_id").Value = 2
            Else
                obj.Rows(e.RowIndex).Cells("purposefund_id").Value = 3
            End If
        End If

        If colName = "banktransfer_foreign" Or colName = "banktransfer_foreignate" Then
            dlgTrnJurnal_PV_List_TransferRekening_RowCalcIDR(obj, obj.Rows(e.RowIndex).Cells("banktransfer_idr"), obj.Rows(e.RowIndex).Cells("banktransfer_foreign"), obj.Rows(e.RowIndex).Cells("banktransfer_foreignrate"))
        End If

        If colName = "banktransfer_bi_foreign" Or colName = "banktransfer_foreignate" Then
            dlgTrnJurnal_PV_List_TransferRekening_RowCalcIDR(obj, obj.Rows(e.RowIndex).Cells("banktransfer_bi_idr"), obj.Rows(e.RowIndex).Cells("banktransfer_bi_foreign"), obj.Rows(e.RowIndex).Cells("banktransfer_foreignrate"))
        End If


    End Sub

    Private Sub DgvDetil_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvDetil.CellValueChanged
        Dim obj As DataGridView = sender
        If obj.Columns(e.ColumnIndex).Name = "slipformat_id" Then
            If obj.Rows(e.RowIndex).Cells("slipformat_id").Value = "SF070022" Or _
               obj.Rows(e.RowIndex).Cells("slipformat_id").Value = "SF070028" Or _
               obj.Rows(e.RowIndex).Cells("slipformat_id").Value = "SF070037" Or _
               obj.Rows(e.RowIndex).Cells("slipformat_id").Value = "SF070040" Or _
               obj.Rows(e.RowIndex).Cells("slipformat_id").Value = "SF070041" Or _
               obj.Rows(e.RowIndex).Cells("slipformat_id").Value = "SF070042" Or _
               obj.Rows(e.RowIndex).Cells("slipformat_id").Value = "SF070044" Or _
               obj.Rows(e.RowIndex).Cells("slipformat_id").Value = "SF070048" Then

                obj.Rows(e.RowIndex).Cells("purposefund_id").Value = 1

            ElseIf obj.Rows(e.RowIndex).Cells("slipformat_id").Value = "SF070030" Or _
               obj.Rows(e.RowIndex).Cells("slipformat_id").Value = "SF070031" Or _
               obj.Rows(e.RowIndex).Cells("slipformat_id").Value = "SF070038" Or _
               obj.Rows(e.RowIndex).Cells("slipformat_id").Value = "SF070043" Or _
               obj.Rows(e.RowIndex).Cells("slipformat_id").Value = "SF070045" Or _
               obj.Rows(e.RowIndex).Cells("slipformat_id").Value = "SF070047" Or _
               obj.Rows(e.RowIndex).Cells("slipformat_id").Value = "SF070049" Then

                obj.Rows(e.RowIndex).Cells("purposefund_id").Value = 2
            Else
                obj.Rows(e.RowIndex).Cells("purposefund_id").Value = 3
            End If
        End If

        If DgvDetil.Rows.Count > 0 Then
            For i As Integer = 0 To DgvDetil.Rows.Count - 1
                If i = 0 Then
                    Me.txtHitung.Text = Format(DgvDetil.Rows(i).Cells("banktransfer_idr").Value, "#,###0.00")
                Else
                    Me.txtHitung.Text = Format(CType(Me.txtHitung.Text, Decimal) + DgvDetil.Rows(i).Cells("banktransfer_idr").Value, "#,###0.00")
                End If
            Next
        Else
            Me.txtHitung.Text = "0.00"
        End If
    End Sub

    Private Function dlgTrnJurnal_PV_List_TransferRekening_RowCalcIDR(ByVal dgv As DataGridView, ByVal cellIDR As DataGridViewCell, ByVal cellForeign As DataGridViewCell, ByVal cellRate As DataGridViewCell) As Boolean
        Dim TotalperRow As Decimal

        TotalperRow = String.Format("{0:#,##0.00}", Math.Round(CDec(clsUtil.IsDbNull(cellForeign.Value, 0)), 2)) * String.Format("{0:#,##0.00}", Math.Round(CDec(clsUtil.IsDbNull(cellRate.Value, 0)), 2))
        Try
            cellIDR.Value = TotalperRow 'String.Format("{0:#,##0.00}", TotalperRow)    TotalperRow.ToString("{0:#,##0.00}")
            cellIDR.Value = Math.Round(cellIDR.Value, 2)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "uiTrnJurnal_RowCalcIDR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        Dim thisRetObj As Collection = New Collection
        Dim i As Integer
        Dim total_idr, total_foreign As Decimal

        For i = 0 To Me.DgvDetil.Rows.Count - 1
            total_idr += clsUtil.IsDbNull(Me.DgvDetil.Rows(i).Cells("banktransfer_idr").Value, 0)
            total_foreign += clsUtil.IsDbNull(Me.DgvDetil.Rows(i).Cells("banktransfer_foreign").Value, 0)
        Next

        If Me.mAmountForeign < total_foreign Or Me.mAmountIdr < total_idr Then
            MsgBox("Total transfer lebih besar dari jumlah payment yang dideklarasikan", MsgBoxStyle.Critical, "Info")
            Exit Sub
        Else
            thisRetObj.Add(Me.tbl_TrnBankTransfer.Copy(), "tblTransfer")
            retObj = thisRetObj
        End If

        Me.Close()
    End Sub

    Private Sub btn_listRekening_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim oDataFiller As New clsDataFiller(Me.DSN)
        If mDgvCount > 0 Then
            If Me.mIsPosted = False Then
                Dim retTbl As DataTable = New DataTable
                Dim dlg As New dlgTrnJurnal_PV_List_Rekening(Me.channel, Me.DSN, Me.rekanan, "rekanan")
                Dim row As DataRow

                retTbl.Clear()
                Me.Cursor = Cursors.WaitCursor
                retTbl = dlg.OpenDialog(Me)
                Me.Cursor = Cursors.Arrow

                If retTbl IsNot Nothing Then
                    'Me.tbl_TrnBankTransfer.Clear()
                    If retTbl.Rows.Count <> 0 Then
                        row = Me.tbl_TrnBankTransfer.NewRow

                        row.Item("jurnal_id") = Me.mJurnal_id
                        row.Item("jurnaldetil_line") = Me.mJurnaldetil_line
                        row.Item("rekanan_id") = Me.rekanan 'retTbl.Rows(0).Item("rekanan_id")
                        row.Item("rekananbank_line") = retTbl.Rows(0).Item("rekananbank_line")
                        row.Item("currency_id") = Me.mCurrency_id
                        row.Item("paymenttype_id") = Me.mPaymentType
                        row.Item("banktransfer_dt") = (Now.AddDays(+1).Date) 'default date
                        row.Item("slipformat_id") = "SF070022"
                        row.Item("purposefund_id") = 1
                        'row.Item("paymenttype_id") = 4
                        If Me.mPaymentType = "4" Then
                            'row.Item("channelbank_line") = 1
                            Me.tbl_MstChannelBank.Clear()
                            oDataFiller.DataFill(Me.tbl_MstChannelBank, "ms_MstChannelBank_Select", String.Format("channel_id = '{0}' AND channelbank_line = {1} ", Me.mChannel_id, Me.mCurrency_id))
                            If Me.tbl_MstChannelBank.Rows.Count > 0 Then
                                row.Item("rekening_debit") = Me.tbl_MstChannelBank.Rows(0).Item("channelbank_rekening")
                                row.Item("bank_debit") = Me.tbl_MstChannelBank.Rows(0).Item("channelbank_name")
                                row.Item("account_bank_debit") = Me.tbl_MstChannelBank.Rows(0).Item("channelbank_accountname")
                            Else
                                row.Item("rekening_debit") = String.Empty
                                row.Item("bank_debit") = String.Empty
                                row.Item("account_bank_debit") = String.Empty
                            End If
                        Else
                            row.Item("channelbank_line") = 0
                            row.Item("rekening_debit") = String.Empty
                            row.Item("bank_debit") = String.Empty
                            row.Item("account_bank_debit") = String.Empty
                        End If

                        row.Item("channel_id") = Me.channel
                        row.Item("banktransfer_isdisabled") = 0
                        row.Item("banktransfer_invoice") = ""
                        row.Item("banktransfer_message") = retTbl.Rows(0).Item("penerima_bankaccountname")
                        row.Item("banktransfer_episode1") = 0
                        row.Item("banktransfer_episode2") = 0
                        row.Item("project_id") = 0
                        row.Item("rekananartis_id") = 0
                        row.Item("banktransfer_episode") = ""
                        row.Item("banktransfer_create_by") = Me.user_name
                        row.Item("banktransfer_create_date") = Date.Now.Date

                        '======================REMARK  BY PTS 20130711====================================
                        '---
                        'If retTbl.Rows(0).Item("penerima_bank").ToString.Trim = "Bank Mega" Or retTbl.Rows(0).Item("penerima_bank").ToString.Trim = "Bank Mega KPO" Then
                        '    row.Item("banktransfer_bi_foreign") = 0
                        '    row.Item("banktransfer_foreignrate") = Me.mRate
                        '    row.Item("banktransfer_bi_idr") = 0
                        '    row.Item("banktransfer_idr") = Me.mAmountIdr
                        '    row.Item("banktransfer_foreign") = Me.mAmountForeign
                        'ElseIf (retTbl.Rows(0).Item("penerima_bank").ToString.Trim <> "Bank Mega" Or retTbl.Rows(0).Item("penerima_bank").ToString.Trim <> "Bank Mega KPO") And Me.mAmountIdr < 100000000 Then

                        '    'row.Item("banktransfer_bi_foreign") = 5000
                        '    'row.Item("banktransfer_foreignrate") = Me.mRate
                        '    'row.Item("banktransfer_bi_idr") = 5000
                        '    'row.Item("banktransfer_idr") = Me.mAmountIdr
                        '    'row.Item("banktransfer_foreign") = Me.mAmountForeign

                        '    If mCurrency_id = 1 Then
                        '        row.Item("banktransfer_bi_foreign") = 5000
                        '        row.Item("banktransfer_foreignrate") = Me.mRate
                        '        row.Item("banktransfer_bi_idr") = 5000
                        '        row.Item("banktransfer_idr") = Me.mAmountIdr
                        '        row.Item("banktransfer_foreign") = Me.mAmountForeign
                        '    ElseIf mCurrency_id = 2 Then
                        '        row.Item("banktransfer_bi_foreign") = 5000
                        '        row.Item("banktransfer_foreignrate") = Me.mRate
                        '        row.Item("banktransfer_bi_idr") = (Me.mAmountIdr - 5000)
                        '        row.Item("banktransfer_idr") = Me.mAmountIdr
                        '        row.Item("banktransfer_foreign") = Me.mAmountForeign
                        '    Else
                        '        row.Item("banktransfer_bi_foreign") = 5000
                        '        row.Item("banktransfer_foreignrate") = Me.mRate
                        '        row.Item("banktransfer_bi_idr") = 5000
                        '        row.Item("banktransfer_idr") = Me.mAmountIdr
                        '        row.Item("banktransfer_foreign") = Me.mAmountForeign
                        '    End If

                        'ElseIf (retTbl.Rows(0).Item("penerima_bank").ToString.Trim <> "Bank Mega" Or retTbl.Rows(0).Item("penerima_bank").ToString.Trim <> "Bank Mega KPO") And Me.mAmountIdr >= 100000000 Then

                        '    If mCurrency_id = 1 Then
                        '        row.Item("banktransfer_bi_foreign") = 25000
                        '        row.Item("banktransfer_foreignrate") = Me.mRate
                        '        row.Item("banktransfer_bi_idr") = 25000
                        '        row.Item("banktransfer_idr") = Me.mAmountIdr
                        '        row.Item("banktransfer_foreign") = Me.mAmountForeign
                        '    ElseIf mCurrency_id = 2 Then
                        '        row.Item("banktransfer_bi_foreign") = 25000
                        '        row.Item("banktransfer_foreignrate") = Me.mRate
                        '        row.Item("banktransfer_bi_idr") = (Me.mAmountIdr - 25000)
                        '        row.Item("banktransfer_idr") = Me.mAmountIdr
                        '        row.Item("banktransfer_foreign") = Me.mAmountForeign
                        '    Else
                        '        row.Item("banktransfer_bi_foreign") = 25000
                        '        row.Item("banktransfer_foreignrate") = Me.mRate
                        '        row.Item("banktransfer_bi_idr") = 25000
                        '        row.Item("banktransfer_idr") = Me.mAmountIdr
                        '        row.Item("banktransfer_foreign") = Me.mAmountForeign
                        '    End If

                        'End If
                        '=================================================================

                        '=========ADD BY PTS 20130710=========
                        If Me.mAmountIdr < 100000000 Then

                            If mCurrency_id = 1 Then
                                row.Item("banktransfer_bi_foreign") = 5000
                                row.Item("banktransfer_foreignrate") = Me.mRate
                                row.Item("banktransfer_bi_idr") = 5000
                                row.Item("banktransfer_idr") = Me.mAmountIdr
                                row.Item("banktransfer_foreign") = Me.mAmountForeign
                            ElseIf mCurrency_id = 2 Then
                                row.Item("banktransfer_bi_foreign") = 5000
                                row.Item("banktransfer_foreignrate") = Me.mRate
                                row.Item("banktransfer_bi_idr") = (Me.mAmountIdr - 5000)
                                row.Item("banktransfer_idr") = Me.mAmountIdr
                                row.Item("banktransfer_foreign") = Me.mAmountForeign
                            Else
                                row.Item("banktransfer_bi_foreign") = 5000
                                row.Item("banktransfer_foreignrate") = Me.mRate
                                row.Item("banktransfer_bi_idr") = 5000
                                row.Item("banktransfer_idr") = Me.mAmountIdr
                                row.Item("banktransfer_foreign") = Me.mAmountForeign
                            End If

                        ElseIf Me.mAmountIdr >= 100000000 Then

                            If mCurrency_id = 1 Then
                                row.Item("banktransfer_bi_foreign") = 25000
                                row.Item("banktransfer_foreignrate") = Me.mRate
                                row.Item("banktransfer_bi_idr") = 25000
                                row.Item("banktransfer_idr") = Me.mAmountIdr
                                row.Item("banktransfer_foreign") = Me.mAmountForeign
                            ElseIf mCurrency_id = 2 Then
                                row.Item("banktransfer_bi_foreign") = 25000
                                row.Item("banktransfer_foreignrate") = Me.mRate
                                row.Item("banktransfer_bi_idr") = (Me.mAmountIdr - 25000)
                                row.Item("banktransfer_idr") = Me.mAmountIdr
                                row.Item("banktransfer_foreign") = Me.mAmountForeign
                            Else
                                row.Item("banktransfer_bi_foreign") = 25000
                                row.Item("banktransfer_foreignrate") = Me.mRate
                                row.Item("banktransfer_bi_idr") = 25000
                                row.Item("banktransfer_idr") = Me.mAmountIdr
                                row.Item("banktransfer_foreign") = Me.mAmountForeign
                            End If

                        End If
                        '==================================================

                        row.Item("banktransfer_pembayaranrek") = retTbl.Rows(0).Item("penerima_bank")
                        row.Item("banktransfer_rekening") = retTbl.Rows(0).Item("penerima_rekening")

                        row.Item("jurnalbilyet_receiveperson") = retTbl.Rows(0).Item("penerima_name")
                        row.Item("jurnalbilyet_receiverekening") = retTbl.Rows(0).Item("penerima_rekening")
                        row.Item("jurnalbilyet_receivebank") = retTbl.Rows(0).Item("penerima_bank")
                        row.Item("jurnalbilyet_receiveaccountname") = retTbl.Rows(0).Item("penerima_bankaccountname")

                        Me.tbl_TrnBankTransfer.Rows.Add(row)

                    End If
                End If
                If DgvDetil.Rows.Count > 0 Then
                    For i As Integer = 0 To DgvDetil.Rows.Count - 1
                        If i = 0 Then
                            Me.txtHitung.Text = Format(DgvDetil.Rows(i).Cells("banktransfer_idr").Value, "#,###0.00")
                        Else
                            Me.txtHitung.Text = Format(CType(Me.txtHitung.Text, Decimal) + DgvDetil.Rows(i).Cells("banktransfer_idr").Value, "#,###0.00")
                        End If
                    Next
                Else
                    Me.txtHitung.Text = "0.00"
                End If
            End If
        Else
            Dim retTbl As DataTable = New DataTable
            Dim dlg As New dlgTrnJurnal_PV_List_Rekening(Me.channel, Me.DSN, Me.rekanan, "rekanan")
            Dim row As DataRow

            retTbl.Clear()
            Me.Cursor = Cursors.WaitCursor
            retTbl = dlg.OpenDialog(Me)
            Me.Cursor = Cursors.Arrow

            If retTbl IsNot Nothing Then
                If retTbl.Rows.Count <> 0 Then
                    row = Me.tbl_TrnBankTransfer.NewRow
                    row.Item("jurnal_id") = Me.mJurnal_id
                    row.Item("jurnaldetil_line") = Me.mJurnaldetil_line
                    row.Item("rekanan_id") = retTbl.Rows(0).Item("rekanan_id")
                    row.Item("rekananbank_line") = retTbl.Rows(0).Item("rekananbank_line")
                    row.Item("currency_id") = Me.mCurrency_id
                    row.Item("paymenttype_id") = Me.mPaymentType
                    row.Item("banktransfer_dt") = (Now.AddDays(+1).Date) 'default date
                    row.Item("slipformat_id") = "SF070022"
                    row.Item("rekananbank_line") = 0
                    row.Item("purposefund_id") = 1
                    'row.Item("paymenttype_id") = 4
                    If Me.mPaymentType = "4" Then
                        row.Item("channelbank_line") = 1
                        Me.tbl_MstChannelBank.Clear()
                        oDataFiller.DataFill(Me.tbl_MstChannelBank, "ms_MstChannelBank_Select", String.Format("channel_id = '{0}' AND channelbank_line = {1} ", Me.mChannel_id, row.Item("channelbank_line")))
                        If Me.tbl_MstChannelBank.Rows.Count > 0 Then
                            row.Item("rekening_debit") = Me.tbl_MstChannelBank.Rows(0).Item("channelbank_rekening")
                            row.Item("bank_debit") = Me.tbl_MstChannelBank.Rows(0).Item("channelbank_name")
                            row.Item("account_bank_debit") = Me.tbl_MstChannelBank.Rows(0).Item("channelbank_accountname")
                        Else
                            row.Item("rekening_debit") = String.Empty
                            row.Item("bank_debit") = String.Empty
                            row.Item("account_bank_debit") = String.Empty
                        End If
                    Else
                        row.Item("channelbank_line") = 0
                        row.Item("rekening_debit") = String.Empty
                        row.Item("bank_debit") = String.Empty
                        row.Item("account_bank_debit") = String.Empty
                    End If

                    row.Item("channel_id") = Me.channel
                    row.Item("banktransfer_isdisabled") = 0
                    row.Item("banktransfer_invoice") = ""
                    row.Item("banktransfer_message") = ""
                    row.Item("banktransfer_episode1") = 0
                    row.Item("banktransfer_episode2") = 0
                    row.Item("project_id") = 0
                    row.Item("rekananartis_id") = 0
                    row.Item("banktransfer_episode") = ""
                    row.Item("banktransfer_create_by") = Me.user_name
                    row.Item("banktransfer_create_date") = Date.Now.Date

                    '================ REMARK BY PTS 20130711 =========================
                    '---
                    If retTbl.Rows(0).Item("penerima_bank").ToString.Trim = "Bank Mega" Or retTbl.Rows(0).Item("penerima_bank").ToString.Trim = "Bank Mega KPO" Then
                        row.Item("banktransfer_bi_foreign") = 0
                        row.Item("banktransfer_foreignrate") = Me.mRate
                        row.Item("banktransfer_bi_idr") = 0
                        row.Item("banktransfer_idr") = Me.mAmountIdr
                        row.Item("banktransfer_foreign") = Me.mAmountForeign
                    ElseIf (retTbl.Rows(0).Item("penerima_bank").ToString.Trim <> "Bank Mega" Or retTbl.Rows(0).Item("penerima_bank").ToString.Trim <> "Bank Mega KPO") And Me.mAmountIdr < 100000000 Then

                        'row.Item("banktransfer_bi_foreign") = 5000
                        'row.Item("banktransfer_foreignrate") = Me.mRate
                        'row.Item("banktransfer_bi_idr") = 5000
                        'row.Item("banktransfer_idr") = Me.mAmountIdr
                        'row.Item("banktransfer_foreign") = Me.mAmountForeign

                        If mCurrency_id = 1 Then
                            row.Item("banktransfer_bi_foreign") = 5000
                            row.Item("banktransfer_foreignrate") = Me.mRate
                            row.Item("banktransfer_bi_idr") = 5000
                            row.Item("banktransfer_idr") = Me.mAmountIdr
                            row.Item("banktransfer_foreign") = Me.mAmountForeign
                        ElseIf mCurrency_id = 2 Then
                            row.Item("banktransfer_bi_foreign") = 5000
                            row.Item("banktransfer_foreignrate") = Me.mRate
                            row.Item("banktransfer_bi_idr") = (Me.mAmountIdr - 5000)
                            row.Item("banktransfer_idr") = Me.mAmountIdr
                            row.Item("banktransfer_foreign") = Me.mAmountForeign
                        Else
                            row.Item("banktransfer_bi_foreign") = 5000
                            row.Item("banktransfer_foreignrate") = Me.mRate
                            row.Item("banktransfer_bi_idr") = 5000
                            row.Item("banktransfer_idr") = Me.mAmountIdr
                            row.Item("banktransfer_foreign") = Me.mAmountForeign
                        End If

                    ElseIf (retTbl.Rows(0).Item("penerima_bank").ToString.Trim <> "Bank Mega" Or retTbl.Rows(0).Item("penerima_bank").ToString.Trim <> "Bank Mega KPO") And Me.mAmountIdr >= 100000000 Then

                        If mCurrency_id = 1 Then
                            row.Item("banktransfer_bi_foreign") = 25000
                            row.Item("banktransfer_foreignrate") = Me.mRate
                            row.Item("banktransfer_bi_idr") = 25000
                            row.Item("banktransfer_idr") = Me.mAmountIdr
                            row.Item("banktransfer_foreign") = Me.mAmountForeign
                        ElseIf mCurrency_id = 2 Then
                            row.Item("banktransfer_bi_foreign") = 25000
                            row.Item("banktransfer_foreignrate") = Me.mRate
                            row.Item("banktransfer_bi_idr") = (Me.mAmountIdr - 25000)
                            row.Item("banktransfer_idr") = Me.mAmountIdr
                            row.Item("banktransfer_foreign") = Me.mAmountForeign
                        Else
                            row.Item("banktransfer_bi_foreign") = 25000
                            row.Item("banktransfer_foreignrate") = Me.mRate
                            row.Item("banktransfer_bi_idr") = 25000
                            row.Item("banktransfer_idr") = Me.mAmountIdr
                            row.Item("banktransfer_foreign") = Me.mAmountForeign
                        End If

                    End If
                    '==============================================================

                    '=========ADD BY PTS 20130710========================
                    If Me.mAmountIdr < 100000000 Then

                        If mCurrency_id = 1 Then
                            row.Item("banktransfer_bi_foreign") = 0 '5000
                            row.Item("banktransfer_foreignrate") = Me.mRate
                            row.Item("banktransfer_bi_idr") = 0 '5000
                            row.Item("banktransfer_idr") = Me.mAmountIdr
                            row.Item("banktransfer_foreign") = Me.mAmountForeign
                        ElseIf mCurrency_id = 2 Then
                            row.Item("banktransfer_bi_foreign") = 0 '5000
                            row.Item("banktransfer_foreignrate") = Me.mRate
                            row.Item("banktransfer_bi_idr") = (Me.mAmountIdr - 0) '(Me.mAmountIdr - 5000)
                            row.Item("banktransfer_idr") = Me.mAmountIdr
                            row.Item("banktransfer_foreign") = Me.mAmountForeign
                        Else
                            row.Item("banktransfer_bi_foreign") = 0 '5000
                            row.Item("banktransfer_foreignrate") = Me.mRate
                            row.Item("banktransfer_bi_idr") = 0 '5000
                            row.Item("banktransfer_idr") = Me.mAmountIdr
                            row.Item("banktransfer_foreign") = Me.mAmountForeign
                        End If

                    ElseIf Me.mAmountIdr >= 100000000 Then

                        If mCurrency_id = 1 Then
                            row.Item("banktransfer_bi_foreign") = 0 '25000
                            row.Item("banktransfer_foreignrate") = Me.mRate
                            row.Item("banktransfer_bi_idr") = 0 '25000
                            row.Item("banktransfer_idr") = Me.mAmountIdr
                            row.Item("banktransfer_foreign") = Me.mAmountForeign
                        ElseIf mCurrency_id = 2 Then
                            row.Item("banktransfer_bi_foreign") = 0 '25000
                            row.Item("banktransfer_foreignrate") = Me.mRate
                            row.Item("banktransfer_bi_idr") = (Me.mAmountIdr - 0) '(Me.mAmountIdr - 25000)
                            row.Item("banktransfer_idr") = Me.mAmountIdr
                            row.Item("banktransfer_foreign") = Me.mAmountForeign
                        Else
                            row.Item("banktransfer_bi_foreign") = 0 '25000
                            row.Item("banktransfer_foreignrate") = Me.mRate
                            row.Item("banktransfer_bi_idr") = 0 '25000
                            row.Item("banktransfer_idr") = Me.mAmountIdr
                            row.Item("banktransfer_foreign") = Me.mAmountForeign
                        End If

                    End If
                    '==================================================

                    row.Item("jurnalbilyet_receiveperson") = retTbl.Rows(0).Item("penerima_name")
                    row.Item("jurnalbilyet_receiverekening") = retTbl.Rows(0).Item("penerima_rekening")
                    row.Item("jurnalbilyet_receivebank") = retTbl.Rows(0).Item("penerima_bank")
                    row.Item("jurnalbilyet_receiveaccountname") = retTbl.Rows(0).Item("penerima_bankaccountname")
                    Me.tbl_TrnBankTransfer.Rows.Add(row)
                End If
            End If
            If DgvDetil.Rows.Count > 0 Then
                For i As Integer = 0 To DgvDetil.Rows.Count - 1
                    If i = 0 Then
                        Me.txtHitung.Text = Format(DgvDetil.Rows(i).Cells("banktransfer_idr").Value, "#,###0.00")
                    Else
                        Me.txtHitung.Text = Format(CType(Me.txtHitung.Text, Decimal) + DgvDetil.Rows(i).Cells("banktransfer_idr").Value, "#,###0.00")
                    End If
                Next
            Else
                Me.txtHitung.Text = "0.00"
            End If
        End If
        '==
    End Sub
    '===
    Private Sub DgvDetil_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles DgvDetil.RowsRemoved
        Dim obj As DataGridView = sender
        If DgvDetil.Rows.Count > 0 Then
            For i As Integer = 0 To DgvDetil.Rows.Count - 1
                If i = 0 Then
                    Me.txtHitung.Text = Format(DgvDetil.Rows(i).Cells("banktransfer_idr").Value, "#,###0.00")
                Else
                    Me.txtHitung.Text = Format(CType(Me.txtHitung.Text, Decimal) + DgvDetil.Rows(i).Cells("banktransfer_idr").Value, "#,###0.00")
                End If
            Next
        Else
            Me.txtHitung.Text = "0.00"
        End If
    End Sub

    Private Sub btn_RekeningArtis_Click(sender As Object, e As EventArgs)
        Dim oDataFiller As New clsDataFiller(Me.DSN)
        If mDgvCount > 0 Then
            If Me.mIsPosted = False Then
                Dim retTbl As DataTable = New DataTable
                Dim dlg As New dlgTrnJurnal_PV_List_Rekening(Me.channel, Me.DSN, Me.rekanan, "artis")
                Dim row As DataRow

                retTbl.Clear()
                Me.Cursor = Cursors.WaitCursor
                retTbl = dlg.OpenDialog(Me)
                Me.Cursor = Cursors.Arrow

                If retTbl IsNot Nothing Then
                    'Me.tbl_TrnBankTransfer.Clear()
                    If retTbl.Rows.Count <> 0 Then
                        row = Me.tbl_TrnBankTransfer.NewRow

                        row.Item("jurnal_id") = Me.mJurnal_id
                        row.Item("jurnaldetil_line") = Me.mJurnaldetil_line
                        row.Item("rekanan_id") = retTbl.Rows(0).Item("rekanan_id") 'Me.rekanan 'retTbl.Rows(0).Item("rekanan_id")
                        row.Item("rekananbank_line") = retTbl.Rows(0).Item("rekananbank_line")
                        row.Item("currency_id") = Me.mCurrency_id
                        row.Item("paymenttype_id") = Me.mPaymentType
                        row.Item("banktransfer_dt") = (Now.AddDays(+1).Date) 'default date
                        row.Item("slipformat_id") = "SF070022"
                        row.Item("purposefund_id") = 1
                        'row.Item("paymenttype_id") = 4
                        If Me.mPaymentType = "4" Then
                            'row.Item("channelbank_line") = 1
                            Me.tbl_MstChannelBank.Clear()
                            oDataFiller.DataFill(Me.tbl_MstChannelBank, "ms_MstChannelBank_Select", String.Format("channel_id = '{0}' AND channelbank_line = {1} ", Me.mChannel_id, Me.mCurrency_id))
                            If Me.tbl_MstChannelBank.Rows.Count > 0 Then
                                row.Item("rekening_debit") = Me.tbl_MstChannelBank.Rows(0).Item("channelbank_rekening")
                                row.Item("bank_debit") = Me.tbl_MstChannelBank.Rows(0).Item("channelbank_name")
                                row.Item("account_bank_debit") = Me.tbl_MstChannelBank.Rows(0).Item("channelbank_accountname")
                            Else
                                row.Item("rekening_debit") = String.Empty
                                row.Item("bank_debit") = String.Empty
                                row.Item("account_bank_debit") = String.Empty
                            End If
                        Else
                            row.Item("channelbank_line") = 0
                            row.Item("rekening_debit") = String.Empty
                            row.Item("bank_debit") = String.Empty
                            row.Item("account_bank_debit") = String.Empty
                        End If

                        row.Item("channel_id") = Me.channel
                        row.Item("banktransfer_isdisabled") = 0
                        row.Item("banktransfer_invoice") = ""
                        row.Item("banktransfer_message") = retTbl.Rows(0).Item("penerima_bankaccountname")
                        row.Item("banktransfer_episode1") = 0
                        row.Item("banktransfer_episode2") = 0
                        row.Item("project_id") = 0
                        row.Item("rekananartis_id") = 0
                        row.Item("banktransfer_episode") = ""
                        row.Item("banktransfer_create_by") = Me.user_name
                        row.Item("banktransfer_create_date") = Date.Now.Date
                        '---
                        '=============================REMARK BY pts 20130710 ============================================================
                        'If retTbl.Rows(0).Item("penerima_bank").ToString.Trim = "Bank Mega" Or retTbl.Rows(0).Item("penerima_bank").ToString.Trim = "Bank Mega KPO" Then
                        '    row.Item("banktransfer_bi_foreign") = 0
                        '    row.Item("banktransfer_foreignrate") = Me.mRate
                        '    row.Item("banktransfer_bi_idr") = 0
                        '    row.Item("banktransfer_idr") = Me.mAmountIdr
                        '    row.Item("banktransfer_foreign") = Me.mAmountForeign

                        'ElseIf (retTbl.Rows(0).Item("penerima_bank").ToString.Trim <> "Bank Mega" Or retTbl.Rows(0).Item("penerima_bank").ToString.Trim <> "Bank Mega KPO") And Me.mAmountIdr < 100000000 Then

                        '    'row.Item("banktransfer_bi_foreign") = 5000
                        '    'row.Item("banktransfer_foreignrate") = Me.mRate
                        '    'row.Item("banktransfer_bi_idr") = 5000
                        '    'row.Item("banktransfer_idr") = Me.mAmountIdr
                        '    'row.Item("banktransfer_foreign") = Me.mAmountForeign

                        '    If mCurrency_id = 1 Then
                        '        row.Item("banktransfer_bi_foreign") = 5000
                        '        row.Item("banktransfer_foreignrate") = Me.mRate
                        '        row.Item("banktransfer_bi_idr") = 5000
                        '        row.Item("banktransfer_idr") = Me.mAmountIdr
                        '        row.Item("banktransfer_foreign") = Me.mAmountForeign
                        '    ElseIf mCurrency_id = 2 Then
                        '        row.Item("banktransfer_bi_foreign") = 5000
                        '        row.Item("banktransfer_foreignrate") = Me.mRate
                        '        row.Item("banktransfer_bi_idr") = (Me.mAmountIdr - 5000)
                        '        row.Item("banktransfer_idr") = Me.mAmountIdr
                        '        row.Item("banktransfer_foreign") = Me.mAmountForeign
                        '    Else
                        '        row.Item("banktransfer_bi_foreign") = 5000
                        '        row.Item("banktransfer_foreignrate") = Me.mRate
                        '        row.Item("banktransfer_bi_idr") = 5000
                        '        row.Item("banktransfer_idr") = Me.mAmountIdr
                        '        row.Item("banktransfer_foreign") = Me.mAmountForeign
                        '    End If

                        'ElseIf (retTbl.Rows(0).Item("penerima_bank").ToString.Trim <> "Bank Mega" Or retTbl.Rows(0).Item("penerima_bank").ToString.Trim <> "Bank Mega KPO") And Me.mAmountIdr >= 100000000 Then

                        '    If mCurrency_id = 1 Then
                        '        row.Item("banktransfer_bi_foreign") = 25000
                        '        row.Item("banktransfer_foreignrate") = Me.mRate
                        '        row.Item("banktransfer_bi_idr") = 25000
                        '        row.Item("banktransfer_idr") = Me.mAmountIdr
                        '        row.Item("banktransfer_foreign") = Me.mAmountForeign
                        '    ElseIf mCurrency_id = 2 Then
                        '        row.Item("banktransfer_bi_foreign") = 25000
                        '        row.Item("banktransfer_foreignrate") = Me.mRate
                        '        row.Item("banktransfer_bi_idr") = (Me.mAmountIdr - 25000)
                        '        row.Item("banktransfer_idr") = Me.mAmountIdr
                        '        row.Item("banktransfer_foreign") = Me.mAmountForeign
                        '    Else
                        '        row.Item("banktransfer_bi_foreign") = 25000
                        '        row.Item("banktransfer_foreignrate") = Me.mRate
                        '        row.Item("banktransfer_bi_idr") = 25000
                        '        row.Item("banktransfer_idr") = Me.mAmountIdr
                        '        row.Item("banktransfer_foreign") = Me.mAmountForeign
                        '    End If

                        'End If
                        '=========================================================================================================

                        '=========ADD BY PTS 20130710=========
                        If Me.mAmountIdr < 100000000 Then

                            If mCurrency_id = 1 Then
                                row.Item("banktransfer_bi_foreign") = 0 '5000
                                row.Item("banktransfer_foreignrate") = Me.mRate
                                row.Item("banktransfer_bi_idr") = 0 '5000
                                row.Item("banktransfer_idr") = Me.mAmountIdr
                                row.Item("banktransfer_foreign") = Me.mAmountForeign
                            ElseIf mCurrency_id = 2 Then
                                row.Item("banktransfer_bi_foreign") = 0 '5000
                                row.Item("banktransfer_foreignrate") = Me.mRate
                                row.Item("banktransfer_bi_idr") = (Me.mAmountIdr - 0) ' (Me.mAmountIdr - 5000)
                                row.Item("banktransfer_idr") = Me.mAmountIdr
                                row.Item("banktransfer_foreign") = Me.mAmountForeign
                            Else
                                row.Item("banktransfer_bi_foreign") = 0 '5000
                                row.Item("banktransfer_foreignrate") = Me.mRate
                                row.Item("banktransfer_bi_idr") = 0 '5000
                                row.Item("banktransfer_idr") = Me.mAmountIdr
                                row.Item("banktransfer_foreign") = Me.mAmountForeign
                            End If

                        ElseIf Me.mAmountIdr >= 100000000 Then

                            If mCurrency_id = 1 Then
                                row.Item("banktransfer_bi_foreign") = 0 '25000
                                row.Item("banktransfer_foreignrate") = Me.mRate
                                row.Item("banktransfer_bi_idr") = 0 '25000
                                row.Item("banktransfer_idr") = Me.mAmountIdr
                                row.Item("banktransfer_foreign") = Me.mAmountForeign
                            ElseIf mCurrency_id = 2 Then
                                row.Item("banktransfer_bi_foreign") = 0 '25000
                                row.Item("banktransfer_foreignrate") = Me.mRate
                                row.Item("banktransfer_bi_idr") = (Me.mAmountIdr - 0) '(Me.mAmountIdr - 25000)
                                row.Item("banktransfer_idr") = Me.mAmountIdr
                                row.Item("banktransfer_foreign") = Me.mAmountForeign
                            Else
                                row.Item("banktransfer_bi_foreign") = 0 '25000
                                row.Item("banktransfer_foreignrate") = Me.mRate
                                row.Item("banktransfer_bi_idr") = 0 '25000
                                row.Item("banktransfer_idr") = Me.mAmountIdr
                                row.Item("banktransfer_foreign") = Me.mAmountForeign
                            End If

                        End If
                        '======================================================================

                        row.Item("banktransfer_pembayaranrek") = retTbl.Rows(0).Item("penerima_bank")
                        row.Item("banktransfer_rekening") = retTbl.Rows(0).Item("penerima_rekening")

                        row.Item("jurnalbilyet_receiveperson") = retTbl.Rows(0).Item("penerima_name")
                        row.Item("jurnalbilyet_receiverekening") = retTbl.Rows(0).Item("penerima_rekening")
                        row.Item("jurnalbilyet_receivebank") = retTbl.Rows(0).Item("penerima_bank")
                        row.Item("jurnalbilyet_receiveaccountname") = retTbl.Rows(0).Item("penerima_bankaccountname")

                        Me.tbl_TrnBankTransfer.Rows.Add(row)

                    End If
                End If

                If DgvDetil.Rows.Count > 0 Then
                    For i As Integer = 0 To DgvDetil.Rows.Count - 1
                        If i = 0 Then
                            Me.txtHitung.Text = Format(DgvDetil.Rows(i).Cells("banktransfer_idr").Value, "#,###0.00")
                        Else
                            Me.txtHitung.Text = Format(CType(Me.txtHitung.Text, Decimal) + DgvDetil.Rows(i).Cells("banktransfer_idr").Value, "#,###0.00")
                        End If
                    Next
                Else
                    Me.txtHitung.Text = "0.00"
                End If
            End If
        Else
            Dim retTbl As DataTable = New DataTable
            Dim dlg As New dlgTrnJurnal_PV_List_Rekening(Me.channel, Me.DSN, Me.rekanan, "artis")
            Dim row As DataRow

            retTbl.Clear()
            Me.Cursor = Cursors.WaitCursor
            retTbl = dlg.OpenDialog(Me)
            Me.Cursor = Cursors.Arrow

            If retTbl IsNot Nothing Then
                If retTbl.Rows.Count <> 0 Then
                    row = Me.tbl_TrnBankTransfer.NewRow
                    row.Item("jurnal_id") = Me.mJurnal_id
                    row.Item("jurnaldetil_line") = Me.mJurnaldetil_line
                    row.Item("rekanan_id") = retTbl.Rows(0).Item("rekanan_id")
                    row.Item("rekananbank_line") = retTbl.Rows(0).Item("rekananbank_line")
                    row.Item("currency_id") = Me.mCurrency_id
                    row.Item("paymenttype_id") = Me.mPaymentType
                    row.Item("banktransfer_dt") = (Now.AddDays(+1).Date) 'default date
                    row.Item("slipformat_id") = "SF070022"
                    row.Item("rekananbank_line") = 0
                    row.Item("purposefund_id") = 1
                    'row.Item("paymenttype_id") = 4
                    If Me.mPaymentType = "4" Then
                        row.Item("channelbank_line") = 1
                        Me.tbl_MstChannelBank.Clear()
                        oDataFiller.DataFill(Me.tbl_MstChannelBank, "ms_MstChannelBank_Select", String.Format("channel_id = '{0}' AND channelbank_line = {1} ", Me.mChannel_id, row.Item("channelbank_line")))
                        If Me.tbl_MstChannelBank.Rows.Count > 0 Then
                            row.Item("rekening_debit") = Me.tbl_MstChannelBank.Rows(0).Item("channelbank_rekening")
                            row.Item("bank_debit") = Me.tbl_MstChannelBank.Rows(0).Item("channelbank_name")
                            row.Item("account_bank_debit") = Me.tbl_MstChannelBank.Rows(0).Item("channelbank_accountname")
                        Else
                            row.Item("rekening_debit") = String.Empty
                            row.Item("bank_debit") = String.Empty
                            row.Item("account_bank_debit") = String.Empty
                        End If
                    Else
                        row.Item("channelbank_line") = 0
                        row.Item("rekening_debit") = String.Empty
                        row.Item("bank_debit") = String.Empty
                        row.Item("account_bank_debit") = String.Empty
                    End If

                    row.Item("channel_id") = Me.channel
                    row.Item("banktransfer_isdisabled") = 0
                    row.Item("banktransfer_invoice") = ""
                    row.Item("banktransfer_message") = ""
                    row.Item("banktransfer_episode1") = 0
                    row.Item("banktransfer_episode2") = 0
                    row.Item("project_id") = 0
                    row.Item("rekananartis_id") = 0
                    row.Item("banktransfer_episode") = ""
                    row.Item("banktransfer_create_by") = Me.user_name
                    row.Item("banktransfer_create_date") = Date.Now.Date
                    '---
                    '==================================REMARK BY PTS 20130710================================================
                    'If retTbl.Rows(0).Item("penerima_bank").ToString.Trim = "Bank Mega" Or retTbl.Rows(0).Item("penerima_bank").ToString.Trim = "Bank Mega KPO" Then
                    '    row.Item("banktransfer_bi_foreign") = 0
                    '    row.Item("banktransfer_foreignrate") = Me.mRate
                    '    row.Item("banktransfer_bi_idr") = 0
                    '    row.Item("banktransfer_idr") = Me.mAmountIdr
                    '    row.Item("banktransfer_foreign") = Me.mAmountForeign
                    'ElseIf (retTbl.Rows(0).Item("penerima_bank").ToString.Trim <> "Bank Mega" Or retTbl.Rows(0).Item("penerima_bank").ToString.Trim <> "Bank Mega KPO") And Me.mAmountIdr < 100000000 Then

                    '    'row.Item("banktransfer_bi_foreign") = 5000
                    '    'row.Item("banktransfer_foreignrate") = Me.mRate
                    '    'row.Item("banktransfer_bi_idr") = 5000
                    '    'row.Item("banktransfer_idr") = Me.mAmountIdr
                    '    'row.Item("banktransfer_foreign") = Me.mAmountForeign

                    '    If mCurrency_id = 1 Then
                    '        row.Item("banktransfer_bi_foreign") = 5000
                    '        row.Item("banktransfer_foreignrate") = Me.mRate
                    '        row.Item("banktransfer_bi_idr") = 5000
                    '        row.Item("banktransfer_idr") = Me.mAmountIdr
                    '        row.Item("banktransfer_foreign") = Me.mAmountForeign
                    '    ElseIf mCurrency_id = 2 Then
                    '        row.Item("banktransfer_bi_foreign") = 5000
                    '        row.Item("banktransfer_foreignrate") = Me.mRate
                    '        row.Item("banktransfer_bi_idr") = (Me.mAmountIdr - 5000)
                    '        row.Item("banktransfer_idr") = Me.mAmountIdr
                    '        row.Item("banktransfer_foreign") = Me.mAmountForeign
                    '    Else
                    '        row.Item("banktransfer_bi_foreign") = 5000
                    '        row.Item("banktransfer_foreignrate") = Me.mRate
                    '        row.Item("banktransfer_bi_idr") = 5000
                    '        row.Item("banktransfer_idr") = Me.mAmountIdr
                    '        row.Item("banktransfer_foreign") = Me.mAmountForeign
                    '    End If

                    'ElseIf (retTbl.Rows(0).Item("penerima_bank").ToString.Trim <> "Bank Mega" Or retTbl.Rows(0).Item("penerima_bank").ToString.Trim <> "Bank Mega KPO") And Me.mAmountIdr >= 100000000 Then

                    '    If mCurrency_id = 1 Then
                    '        row.Item("banktransfer_bi_foreign") = 25000
                    '        row.Item("banktransfer_foreignrate") = Me.mRate
                    '        row.Item("banktransfer_bi_idr") = 25000
                    '        row.Item("banktransfer_idr") = Me.mAmountIdr
                    '        row.Item("banktransfer_foreign") = Me.mAmountForeign
                    '    ElseIf mCurrency_id = 2 Then
                    '        row.Item("banktransfer_bi_foreign") = 25000
                    '        row.Item("banktransfer_foreignrate") = Me.mRate
                    '        row.Item("banktransfer_bi_idr") = (Me.mAmountIdr - 25000)
                    '        row.Item("banktransfer_idr") = Me.mAmountIdr
                    '        row.Item("banktransfer_foreign") = Me.mAmountForeign
                    '    Else
                    '        row.Item("banktransfer_bi_foreign") = 25000
                    '        row.Item("banktransfer_foreignrate") = Me.mRate
                    '        row.Item("banktransfer_bi_idr") = 25000
                    '        row.Item("banktransfer_idr") = Me.mAmountIdr
                    '        row.Item("banktransfer_foreign") = Me.mAmountForeign
                    '    End If

                    'End If
                    '============================================================================================


                    '=========ADD BY PTS 20130710=========
                    If Me.mAmountIdr < 100000000 Then

                        If mCurrency_id = 1 Then
                            row.Item("banktransfer_bi_foreign") = 5000
                            row.Item("banktransfer_foreignrate") = Me.mRate
                            row.Item("banktransfer_bi_idr") = 5000
                            row.Item("banktransfer_idr") = Me.mAmountIdr
                            row.Item("banktransfer_foreign") = Me.mAmountForeign
                        ElseIf mCurrency_id = 2 Then
                            row.Item("banktransfer_bi_foreign") = 5000
                            row.Item("banktransfer_foreignrate") = Me.mRate
                            row.Item("banktransfer_bi_idr") = (Me.mAmountIdr - 5000)
                            row.Item("banktransfer_idr") = Me.mAmountIdr
                            row.Item("banktransfer_foreign") = Me.mAmountForeign
                        Else
                            row.Item("banktransfer_bi_foreign") = 5000
                            row.Item("banktransfer_foreignrate") = Me.mRate
                            row.Item("banktransfer_bi_idr") = 5000
                            row.Item("banktransfer_idr") = Me.mAmountIdr
                            row.Item("banktransfer_foreign") = Me.mAmountForeign
                        End If

                    ElseIf Me.mAmountIdr >= 100000000 Then

                        If mCurrency_id = 1 Then
                            row.Item("banktransfer_bi_foreign") = 25000
                            row.Item("banktransfer_foreignrate") = Me.mRate
                            row.Item("banktransfer_bi_idr") = 25000
                            row.Item("banktransfer_idr") = Me.mAmountIdr
                            row.Item("banktransfer_foreign") = Me.mAmountForeign
                        ElseIf mCurrency_id = 2 Then
                            row.Item("banktransfer_bi_foreign") = 25000
                            row.Item("banktransfer_foreignrate") = Me.mRate
                            row.Item("banktransfer_bi_idr") = (Me.mAmountIdr - 25000)
                            row.Item("banktransfer_idr") = Me.mAmountIdr
                            row.Item("banktransfer_foreign") = Me.mAmountForeign
                        Else
                            row.Item("banktransfer_bi_foreign") = 25000
                            row.Item("banktransfer_foreignrate") = Me.mRate
                            row.Item("banktransfer_bi_idr") = 25000
                            row.Item("banktransfer_idr") = Me.mAmountIdr
                            row.Item("banktransfer_foreign") = Me.mAmountForeign
                        End If

                    End If
                    '======================================================================


                    row.Item("jurnalbilyet_receiveperson") = retTbl.Rows(0).Item("penerima_name")
                    row.Item("jurnalbilyet_receiverekening") = retTbl.Rows(0).Item("penerima_rekening")
                    row.Item("jurnalbilyet_receivebank") = retTbl.Rows(0).Item("penerima_bank")
                    row.Item("jurnalbilyet_receiveaccountname") = retTbl.Rows(0).Item("penerima_bankaccountname")
                    Me.tbl_TrnBankTransfer.Rows.Add(row)
                End If
            End If

            If DgvDetil.Rows.Count > 0 Then
                For i As Integer = 0 To DgvDetil.Rows.Count - 1
                    If i = 0 Then
                        Me.txtHitung.Text = Format(DgvDetil.Rows(i).Cells("banktransfer_idr").Value, "#,###0.00")
                    Else
                        Me.txtHitung.Text = Format(CType(Me.txtHitung.Text, Decimal) + DgvDetil.Rows(i).Cells("banktransfer_idr").Value, "#,###0.00")
                    End If
                Next
            Else
                Me.txtHitung.Text = "0.00"
            End If

        End If
    End Sub


    '============ ADD PTS 20151009 ===================
    Private Sub btn_RekananOther_Click(sender As Object, e As EventArgs)
        Dim oDataFiller As New clsDataFiller(Me.DSN)
        If mDgvCount > 0 Then
            If Me.mIsPosted = False Then
                Dim retTbl As DataTable = New DataTable
                Dim dlg As New dlgTrnJurnal_PV_List_Rekening1(Me.channel, Me.DSN, Me.rekanan, "other")
                Dim row As DataRow

                retTbl.Clear()
                Me.Cursor = Cursors.WaitCursor
                retTbl = dlg.OpenDialog(Me)
                Me.Cursor = Cursors.Arrow

                If retTbl IsNot Nothing Then
                    If retTbl.Rows.Count <> 0 Then
                        row = Me.tbl_TrnBankTransfer.NewRow
                        row.Item("jurnal_id") = Me.mJurnal_id
                        row.Item("jurnaldetil_line") = Me.mJurnaldetil_line
                        row.Item("rekanan_id") = Me.rekanan
                        row.Item("rekananbank_line") = retTbl.Rows(0).Item("rekananbank_line")
                        row.Item("currency_id") = Me.mCurrency_id
                        row.Item("paymenttype_id") = Me.mPaymentType
                        row.Item("banktransfer_dt") = (Now.AddDays(+1).Date)
                        row.Item("slipformat_id") = "SF070022"
                        row.Item("purposefund_id") = 1
                        'row.Item("paymenttype_id") = 4
                        If Me.mPaymentType = "4" Then
                            Me.tbl_MstChannelBank.Clear()
                            oDataFiller.DataFill(Me.tbl_MstChannelBank, "ms_MstChannelBank_Select", String.Format("channel_id = '{0}' AND channelbank_line = {1} ", Me.mChannel_id, Me.mCurrency_id))
                            If Me.tbl_MstChannelBank.Rows.Count > 0 Then
                                row.Item("rekening_debit") = Me.tbl_MstChannelBank.Rows(0).Item("channelbank_rekening")
                                row.Item("bank_debit") = Me.tbl_MstChannelBank.Rows(0).Item("channelbank_name")
                                row.Item("account_bank_debit") = Me.tbl_MstChannelBank.Rows(0).Item("channelbank_accountname")
                            Else
                                row.Item("rekening_debit") = String.Empty
                                row.Item("bank_debit") = String.Empty
                                row.Item("account_bank_debit") = String.Empty
                            End If
                        Else
                            row.Item("channelbank_line") = 0
                            row.Item("rekening_debit") = String.Empty
                            row.Item("bank_debit") = String.Empty
                            row.Item("account_bank_debit") = String.Empty
                        End If

                        row.Item("channel_id") = Me.channel
                        row.Item("banktransfer_isdisabled") = 0
                        row.Item("banktransfer_invoice") = ""
                        row.Item("banktransfer_message") = retTbl.Rows(0).Item("penerima_bankaccountname")
                        row.Item("banktransfer_episode1") = 0
                        row.Item("banktransfer_episode2") = 0
                        row.Item("project_id") = 0
                        row.Item("rekananartis_id") = 0
                        row.Item("banktransfer_episode") = ""
                        row.Item("banktransfer_create_by") = Me.user_name
                        row.Item("banktransfer_create_date") = Date.Now.Date

                        If Me.mAmountIdr < 100000000 Then
                            If mCurrency_id = 1 Then
                                row.Item("banktransfer_bi_foreign") = 5000
                                row.Item("banktransfer_foreignrate") = Me.mRate
                                row.Item("banktransfer_bi_idr") = 5000
                                row.Item("banktransfer_idr") = Me.mAmountIdr
                                row.Item("banktransfer_foreign") = Me.mAmountForeign
                            ElseIf mCurrency_id = 2 Then
                                row.Item("banktransfer_bi_foreign") = 5000
                                row.Item("banktransfer_foreignrate") = Me.mRate
                                row.Item("banktransfer_bi_idr") = (Me.mAmountIdr - 5000)
                                row.Item("banktransfer_idr") = Me.mAmountIdr
                                row.Item("banktransfer_foreign") = Me.mAmountForeign
                            Else
                                row.Item("banktransfer_bi_foreign") = 5000
                                row.Item("banktransfer_foreignrate") = Me.mRate
                                row.Item("banktransfer_bi_idr") = 5000
                                row.Item("banktransfer_idr") = Me.mAmountIdr
                                row.Item("banktransfer_foreign") = Me.mAmountForeign
                            End If
                        ElseIf Me.mAmountIdr >= 100000000 Then

                            If mCurrency_id = 1 Then
                                row.Item("banktransfer_bi_foreign") = 25000
                                row.Item("banktransfer_foreignrate") = Me.mRate
                                row.Item("banktransfer_bi_idr") = 25000
                                row.Item("banktransfer_idr") = Me.mAmountIdr
                                row.Item("banktransfer_foreign") = Me.mAmountForeign
                            ElseIf mCurrency_id = 2 Then
                                row.Item("banktransfer_bi_foreign") = 25000
                                row.Item("banktransfer_foreignrate") = Me.mRate
                                row.Item("banktransfer_bi_idr") = (Me.mAmountIdr - 25000)
                                row.Item("banktransfer_idr") = Me.mAmountIdr
                                row.Item("banktransfer_foreign") = Me.mAmountForeign
                            Else
                                row.Item("banktransfer_bi_foreign") = 25000
                                row.Item("banktransfer_foreignrate") = Me.mRate
                                row.Item("banktransfer_bi_idr") = 25000
                                row.Item("banktransfer_idr") = Me.mAmountIdr
                                row.Item("banktransfer_foreign") = Me.mAmountForeign
                            End If
                        End If

                        row.Item("banktransfer_pembayaranrek") = retTbl.Rows(0).Item("penerima_bank")
                        row.Item("banktransfer_rekening") = retTbl.Rows(0).Item("penerima_rekening")
                        row.Item("jurnalbilyet_receiveperson") = retTbl.Rows(0).Item("penerima_name")
                        row.Item("jurnalbilyet_receiverekening") = retTbl.Rows(0).Item("penerima_rekening")
                        row.Item("jurnalbilyet_receivebank") = retTbl.Rows(0).Item("penerima_bank")
                        row.Item("jurnalbilyet_receiveaccountname") = retTbl.Rows(0).Item("penerima_bankaccountname")
                        Me.tbl_TrnBankTransfer.Rows.Add(row)

                    End If
                End If
                If DgvDetil.Rows.Count > 0 Then
                    For i As Integer = 0 To DgvDetil.Rows.Count - 1
                        If i = 0 Then
                            Me.txtHitung.Text = Format(DgvDetil.Rows(i).Cells("banktransfer_idr").Value, "#,###0.00")
                        Else
                            Me.txtHitung.Text = Format(CType(Me.txtHitung.Text, Decimal) + DgvDetil.Rows(i).Cells("banktransfer_idr").Value, "#,###0.00")
                        End If
                    Next
                Else
                    Me.txtHitung.Text = "0.00"
                End If
            End If
        Else
            Dim retTbl As DataTable = New DataTable
            Dim dlg As New dlgTrnJurnal_PV_List_Rekening1(Me.channel, Me.DSN, Me.rekanan, "rekanan")
            Dim row As DataRow

            retTbl.Clear()
            Me.Cursor = Cursors.WaitCursor
            retTbl = dlg.OpenDialog(Me)
            Me.Cursor = Cursors.Arrow

            If retTbl IsNot Nothing Then
                If retTbl.Rows.Count <> 0 Then
                    row = Me.tbl_TrnBankTransfer.NewRow
                    row.Item("jurnal_id") = Me.mJurnal_id
                    row.Item("jurnaldetil_line") = Me.mJurnaldetil_line
                    row.Item("rekanan_id") = retTbl.Rows(0).Item("rekanan_id")
                    row.Item("rekananbank_line") = retTbl.Rows(0).Item("rekananbank_line")
                    row.Item("currency_id") = Me.mCurrency_id
                    row.Item("paymenttype_id") = Me.mPaymentType
                    row.Item("banktransfer_dt") = (Now.AddDays(+1).Date)
                    row.Item("slipformat_id") = "SF070022"
                    row.Item("rekananbank_line") = 0
                    row.Item("purposefund_id") = 1
                    'row.Item("paymenttype_id") = 4
                    If Me.mPaymentType = "4" Then
                        row.Item("channelbank_line") = 1
                        Me.tbl_MstChannelBank.Clear()
                        oDataFiller.DataFill(Me.tbl_MstChannelBank, "ms_MstChannelBank_Select", String.Format("channel_id = '{0}' AND channelbank_line = {1} ", Me.mChannel_id, row.Item("channelbank_line")))
                        If Me.tbl_MstChannelBank.Rows.Count > 0 Then
                            row.Item("rekening_debit") = Me.tbl_MstChannelBank.Rows(0).Item("channelbank_rekening")
                            row.Item("bank_debit") = Me.tbl_MstChannelBank.Rows(0).Item("channelbank_name")
                            row.Item("account_bank_debit") = Me.tbl_MstChannelBank.Rows(0).Item("channelbank_accountname")
                        Else
                            row.Item("rekening_debit") = String.Empty
                            row.Item("bank_debit") = String.Empty
                            row.Item("account_bank_debit") = String.Empty
                        End If
                    Else
                        row.Item("channelbank_line") = 0
                        row.Item("rekening_debit") = String.Empty
                        row.Item("bank_debit") = String.Empty
                        row.Item("account_bank_debit") = String.Empty
                    End If

                    row.Item("channel_id") = Me.channel
                    row.Item("banktransfer_isdisabled") = 0
                    row.Item("banktransfer_invoice") = ""
                    row.Item("banktransfer_message") = ""
                    row.Item("banktransfer_episode1") = 0
                    row.Item("banktransfer_episode2") = 0
                    row.Item("project_id") = 0
                    row.Item("rekananartis_id") = 0
                    row.Item("banktransfer_episode") = ""
                    row.Item("banktransfer_create_by") = Me.user_name
                    row.Item("banktransfer_create_date") = Date.Now.Date

                    If retTbl.Rows(0).Item("penerima_bank").ToString.Trim = "Bank Mega" Or retTbl.Rows(0).Item("penerima_bank").ToString.Trim = "Bank Mega KPO" Then
                        row.Item("banktransfer_bi_foreign") = 0
                        row.Item("banktransfer_foreignrate") = Me.mRate
                        row.Item("banktransfer_bi_idr") = 0
                        row.Item("banktransfer_idr") = Me.mAmountIdr
                        row.Item("banktransfer_foreign") = Me.mAmountForeign
                    ElseIf (retTbl.Rows(0).Item("penerima_bank").ToString.Trim <> "Bank Mega" Or retTbl.Rows(0).Item("penerima_bank").ToString.Trim <> "Bank Mega KPO") And Me.mAmountIdr < 100000000 Then

                        If mCurrency_id = 1 Then
                            row.Item("banktransfer_bi_foreign") = 5000
                            row.Item("banktransfer_foreignrate") = Me.mRate
                            row.Item("banktransfer_bi_idr") = 5000
                            row.Item("banktransfer_idr") = Me.mAmountIdr
                            row.Item("banktransfer_foreign") = Me.mAmountForeign
                        ElseIf mCurrency_id = 2 Then
                            row.Item("banktransfer_bi_foreign") = 5000
                            row.Item("banktransfer_foreignrate") = Me.mRate
                            row.Item("banktransfer_bi_idr") = (Me.mAmountIdr - 5000)
                            row.Item("banktransfer_idr") = Me.mAmountIdr
                            row.Item("banktransfer_foreign") = Me.mAmountForeign
                        Else
                            row.Item("banktransfer_bi_foreign") = 5000
                            row.Item("banktransfer_foreignrate") = Me.mRate
                            row.Item("banktransfer_bi_idr") = 5000
                            row.Item("banktransfer_idr") = Me.mAmountIdr
                            row.Item("banktransfer_foreign") = Me.mAmountForeign
                        End If

                    ElseIf (retTbl.Rows(0).Item("penerima_bank").ToString.Trim <> "Bank Mega" Or retTbl.Rows(0).Item("penerima_bank").ToString.Trim <> "Bank Mega KPO") And Me.mAmountIdr >= 100000000 Then

                        If mCurrency_id = 1 Then
                            row.Item("banktransfer_bi_foreign") = 25000
                            row.Item("banktransfer_foreignrate") = Me.mRate
                            row.Item("banktransfer_bi_idr") = 25000
                            row.Item("banktransfer_idr") = Me.mAmountIdr
                            row.Item("banktransfer_foreign") = Me.mAmountForeign
                        ElseIf mCurrency_id = 2 Then
                            row.Item("banktransfer_bi_foreign") = 25000
                            row.Item("banktransfer_foreignrate") = Me.mRate
                            row.Item("banktransfer_bi_idr") = (Me.mAmountIdr - 25000)
                            row.Item("banktransfer_idr") = Me.mAmountIdr
                            row.Item("banktransfer_foreign") = Me.mAmountForeign
                        Else
                            row.Item("banktransfer_bi_foreign") = 25000
                            row.Item("banktransfer_foreignrate") = Me.mRate
                            row.Item("banktransfer_bi_idr") = 25000
                            row.Item("banktransfer_idr") = Me.mAmountIdr
                            row.Item("banktransfer_foreign") = Me.mAmountForeign
                        End If

                    End If

                    If Me.mAmountIdr < 100000000 Then

                        If mCurrency_id = 1 Then
                            row.Item("banktransfer_bi_foreign") = 0
                            row.Item("banktransfer_foreignrate") = Me.mRate
                            row.Item("banktransfer_bi_idr") = 0
                            row.Item("banktransfer_idr") = Me.mAmountIdr
                            row.Item("banktransfer_foreign") = Me.mAmountForeign
                        ElseIf mCurrency_id = 2 Then
                            row.Item("banktransfer_bi_foreign") = 0
                            row.Item("banktransfer_foreignrate") = Me.mRate
                            row.Item("banktransfer_bi_idr") = (Me.mAmountIdr - 0)
                            row.Item("banktransfer_idr") = Me.mAmountIdr
                            row.Item("banktransfer_foreign") = Me.mAmountForeign
                        Else
                            row.Item("banktransfer_bi_foreign") = 0
                            row.Item("banktransfer_foreignrate") = Me.mRate
                            row.Item("banktransfer_bi_idr") = 0
                            row.Item("banktransfer_idr") = Me.mAmountIdr
                            row.Item("banktransfer_foreign") = Me.mAmountForeign
                        End If

                    ElseIf Me.mAmountIdr >= 100000000 Then

                        If mCurrency_id = 1 Then
                            row.Item("banktransfer_bi_foreign") = 0
                            row.Item("banktransfer_foreignrate") = Me.mRate
                            row.Item("banktransfer_bi_idr") = 0
                            row.Item("banktransfer_idr") = Me.mAmountIdr
                            row.Item("banktransfer_foreign") = Me.mAmountForeign
                        ElseIf mCurrency_id = 2 Then
                            row.Item("banktransfer_bi_foreign") = 0
                            row.Item("banktransfer_foreignrate") = Me.mRate
                            row.Item("banktransfer_bi_idr") = (Me.mAmountIdr - 0)
                            row.Item("banktransfer_idr") = Me.mAmountIdr
                            row.Item("banktransfer_foreign") = Me.mAmountForeign
                        Else
                            row.Item("banktransfer_bi_foreign") = 0
                            row.Item("banktransfer_foreignrate") = Me.mRate
                            row.Item("banktransfer_bi_idr") = 0
                            row.Item("banktransfer_idr") = Me.mAmountIdr
                            row.Item("banktransfer_foreign") = Me.mAmountForeign
                        End If

                    End If

                    row.Item("jurnalbilyet_receiveperson") = retTbl.Rows(0).Item("penerima_name")
                    row.Item("jurnalbilyet_receiverekening") = retTbl.Rows(0).Item("penerima_rekening")
                    row.Item("jurnalbilyet_receivebank") = retTbl.Rows(0).Item("penerima_bank")
                    row.Item("jurnalbilyet_receiveaccountname") = retTbl.Rows(0).Item("penerima_bankaccountname")
                    Me.tbl_TrnBankTransfer.Rows.Add(row)
                End If
            End If
            If DgvDetil.Rows.Count > 0 Then
                For i As Integer = 0 To DgvDetil.Rows.Count - 1
                    If i = 0 Then
                        Me.txtHitung.Text = Format(DgvDetil.Rows(i).Cells("banktransfer_idr").Value, "#,###0.00")
                    Else
                        Me.txtHitung.Text = Format(CType(Me.txtHitung.Text, Decimal) + DgvDetil.Rows(i).Cells("banktransfer_idr").Value, "#,###0.00")
                    End If
                Next
            Else
                Me.txtHitung.Text = "0.00"
            End If
        End If
    End Sub
    '=================================================

    '============ ADD MDP2NET 20161010 ===================
    Private Sub btn_RekeningWinner_Click(sender As Object, e As EventArgs) Handles btn_RekeningWinner.Click
        Dim oDataFiller As New clsDataFiller(Me.DSN)
        Dim Jurnal_ID_AppPrize As String = String.Empty
        Dim cRekananID As String = String.Empty
        Dim cAccID As String = String.Empty

        For Each dtRow As DataRow In Me.tbl_TrnBankTransfer.Rows
            cRekananID = IIf(cRekananID <> "", cRekananID + ", '" + dtRow.Item("rekanan_id").ToString() + "'", "'" + dtRow.Item("rekanan_id").ToString() + "'")
        Next


        Dim tbl_filter As New DataTable

        For Each dtRow As DataRow In Me.tbl_ACCHutang.Rows
            cAccID = IIf(cAccID <> "", cAccID + "," + dtRow.Item("acc_id").ToString, dtRow.Item("acc_id").ToString)
        Next

        tbl_filter = Me.tbl_ListCheckAccDebit.Select(String.Format("acc_id IN ({0})", cAccID)).CopyToDataTable

        For Each dtRow As DataRow In tbl_filter.Rows
            Jurnal_ID_AppPrize = IIf(Jurnal_ID_AppPrize <> "", Jurnal_ID_AppPrize + ", '" + dtRow.Item("ref_id").ToString() + "'", "'" + dtRow.Item("ref_id").ToString() + "'")
        Next

        ' Me.tbl_ACCHutang()
        ' Me.tbl_ListCheckAccDebit()

        If mDgvCount > 0 Then
            If Me.mIsPosted = False Then
                Dim retTbl As DataTable = New DataTable
                Dim dlg As New dlgTrnJurnal_PV_List_RekeningWinner(Me.channel, Me.DSN, Me.rekanan, "prize", Jurnal_ID_AppPrize, cRekananID)
                Dim row As DataRow

                retTbl.Clear()
                Me.Cursor = Cursors.WaitCursor
                retTbl = dlg.OpenDialog(Me)
                Me.Cursor = Cursors.Arrow

                If retTbl IsNot Nothing Then
                    If retTbl.Rows.Count <> 0 Then
                        Dim mAmountIdr2 As Decimal
                        Dim mAmountForeign2 As Decimal

                        mAmountIdr2 = tbl_filter.Compute("sum(jurnaldetil_idr)", String.Format("ref_id = '{0}'", retTbl.Rows(0).Item("ref_id")))
                        mAmountForeign2 = tbl_filter.Compute("sum(jurnaldetil_foreign)", String.Format("ref_id = '{0}'", retTbl.Rows(0).Item("ref_id")))

                        row = Me.tbl_TrnBankTransfer.NewRow
                        row.Item("jurnal_id") = Me.mJurnal_id
                        row.Item("jurnaldetil_line") = Me.mJurnaldetil_line
                        row.Item("rekanan_id") = retTbl.Rows(0).Item("rekanan_id")
                        row.Item("rekananbank_line") = retTbl.Rows(0).Item("rekananbank_line")
                        row.Item("currency_id") = Me.mCurrency_id
                        row.Item("paymenttype_id") = Me.mPaymentType
                        row.Item("banktransfer_dt") = (Now.AddDays(+1).Date)
                        row.Item("slipformat_id") = "SF070022"
                        row.Item("purposefund_id") = 1
                        'row.Item("paymenttype_id") = 4
                        If Me.mPaymentType = "4" Then
                            Me.tbl_MstChannelBank.Clear()
                            oDataFiller.DataFill(Me.tbl_MstChannelBank, "ms_MstChannelBank_Select", String.Format("channel_id = '{0}' AND channelbank_line = {1} ", Me.mChannel_id, Me.mCurrency_id))
                            If Me.tbl_MstChannelBank.Rows.Count > 0 Then
                                row.Item("rekening_debit") = Me.tbl_MstChannelBank.Rows(0).Item("channelbank_rekening")
                                row.Item("bank_debit") = Me.tbl_MstChannelBank.Rows(0).Item("channelbank_name")
                                row.Item("account_bank_debit") = Me.tbl_MstChannelBank.Rows(0).Item("channelbank_accountname")
                            Else
                                row.Item("rekening_debit") = String.Empty
                                row.Item("bank_debit") = String.Empty
                                row.Item("account_bank_debit") = String.Empty
                            End If
                        Else
                            row.Item("channelbank_line") = 0
                            row.Item("rekening_debit") = String.Empty
                            row.Item("bank_debit") = String.Empty
                            row.Item("account_bank_debit") = String.Empty
                        End If

                        row.Item("channel_id") = Me.channel
                        row.Item("banktransfer_isdisabled") = 0
                        row.Item("banktransfer_invoice") = ""
                        row.Item("banktransfer_message") = retTbl.Rows(0).Item("penerima_bankaccountname")
                        row.Item("banktransfer_episode1") = 0
                        row.Item("banktransfer_episode2") = 0
                        row.Item("project_id") = 0
                        row.Item("rekananartis_id") = 0
                        row.Item("banktransfer_episode") = ""
                        row.Item("banktransfer_create_by") = Me.user_name
                        row.Item("banktransfer_create_date") = Date.Now.Date

                        If Me.mAmountIdr < 100000000 Then
                            If mCurrency_id = 1 Then
                                row.Item("banktransfer_bi_foreign") = 5000
                                row.Item("banktransfer_foreignrate") = Me.mRate
                                row.Item("banktransfer_bi_idr") = 5000
                                row.Item("banktransfer_idr") = mAmountIdr2
                                row.Item("banktransfer_foreign") = mAmountForeign2
                            ElseIf mCurrency_id = 2 Then
                                row.Item("banktransfer_bi_foreign") = 5000
                                row.Item("banktransfer_foreignrate") = Me.mRate
                                row.Item("banktransfer_bi_idr") = (mAmountIdr2 - 5000)
                                row.Item("banktransfer_idr") = mAmountIdr2
                                row.Item("banktransfer_foreign") = mAmountForeign2
                            Else
                                row.Item("banktransfer_bi_foreign") = 5000
                                row.Item("banktransfer_foreignrate") = Me.mRate
                                row.Item("banktransfer_bi_idr") = 5000
                                row.Item("banktransfer_idr") = mAmountIdr2
                                row.Item("banktransfer_foreign") = mAmountForeign2
                            End If
                        ElseIf Me.mAmountIdr >= 100000000 Then

                            If mCurrency_id = 1 Then
                                row.Item("banktransfer_bi_foreign") = 25000
                                row.Item("banktransfer_foreignrate") = Me.mRate
                                row.Item("banktransfer_bi_idr") = 25000
                                row.Item("banktransfer_idr") = mAmountIdr2
                                row.Item("banktransfer_foreign") = mAmountForeign2
                            ElseIf mCurrency_id = 2 Then
                                row.Item("banktransfer_bi_foreign") = 25000
                                row.Item("banktransfer_foreignrate") = Me.mRate
                                row.Item("banktransfer_bi_idr") = (mAmountIdr2 - 25000)
                                row.Item("banktransfer_idr") = mAmountIdr2
                                row.Item("banktransfer_foreign") = mAmountForeign2
                            Else
                                row.Item("banktransfer_bi_foreign") = 25000
                                row.Item("banktransfer_foreignrate") = Me.mRate
                                row.Item("banktransfer_bi_idr") = 25000
                                row.Item("banktransfer_idr") = mAmountIdr2
                                row.Item("banktransfer_foreign") = mAmountForeign2
                            End If
                        End If

                        row.Item("banktransfer_pembayaranrek") = retTbl.Rows(0).Item("penerima_bank")
                        row.Item("banktransfer_rekening") = retTbl.Rows(0).Item("penerima_rekening")
                        row.Item("jurnalbilyet_receiveperson") = retTbl.Rows(0).Item("penerima_name")
                        row.Item("jurnalbilyet_receiverekening") = retTbl.Rows(0).Item("penerima_rekening")
                        row.Item("jurnalbilyet_receivebank") = retTbl.Rows(0).Item("penerima_bank")
                        row.Item("jurnalbilyet_receiveaccountname") = retTbl.Rows(0).Item("penerima_bankaccountname")
                        row.Item("project_id") = retTbl.Rows(0).Item("show_id")
                        row.Item("banktransfer_episode") = retTbl.Rows(0).Item("prize_eps")

                        Me.tbl_TrnBankTransfer.Rows.Add(row)

                    End If
                End If
                If DgvDetil.Rows.Count > 0 Then
                    For i As Integer = 0 To DgvDetil.Rows.Count - 1
                        If i = 0 Then
                            Me.txtHitung.Text = Format(DgvDetil.Rows(i).Cells("banktransfer_idr").Value, "#,###0.00")
                        Else
                            Me.txtHitung.Text = Format(CType(Me.txtHitung.Text, Decimal) + DgvDetil.Rows(i).Cells("banktransfer_idr").Value, "#,###0.00")
                        End If
                    Next
                Else
                    Me.txtHitung.Text = "0.00"
                End If
            End If
        Else
            Dim retTbl As DataTable = New DataTable
            Dim dlg As New dlgTrnJurnal_PV_List_RekeningWinner(Me.channel, Me.DSN, Me.rekanan, "prize", Jurnal_ID_AppPrize, cRekananID)
            Dim row As DataRow

            retTbl.Clear()
            Me.Cursor = Cursors.WaitCursor
            retTbl = dlg.OpenDialog(Me)
            Me.Cursor = Cursors.Arrow

            If retTbl IsNot Nothing Then
                If retTbl.Rows.Count <> 0 Then
                    Dim mAmountIdr2 As Decimal
                    Dim mAmountForeign2 As Decimal
                    mAmountIdr2 = tbl_filter.Compute("sum(jurnaldetil_idr)", String.Format("ref_id = '{0}'", retTbl.Rows(0).Item("ref_id")))
                    mAmountForeign2 = tbl_filter.Compute("sum(jurnaldetil_foreign)", String.Format("ref_id = '{0}'", retTbl.Rows(0).Item("ref_id")))

                    row = Me.tbl_TrnBankTransfer.NewRow
                    row.Item("jurnal_id") = Me.mJurnal_id
                    row.Item("jurnaldetil_line") = Me.mJurnaldetil_line
                    row.Item("rekanan_id") = retTbl.Rows(0).Item("rekanan_id")
                    row.Item("rekananbank_line") = retTbl.Rows(0).Item("rekananbank_line")
                    row.Item("currency_id") = Me.mCurrency_id
                    row.Item("paymenttype_id") = Me.mPaymentType
                    row.Item("banktransfer_dt") = (Now.AddDays(+1).Date)
                    row.Item("slipformat_id") = "SF070022"
                    row.Item("rekananbank_line") = 0
                    row.Item("purposefund_id") = 1
                    'row.Item("paymenttype_id") = 4
                    If Me.mPaymentType = "4" Then
                        row.Item("channelbank_line") = 1
                        Me.tbl_MstChannelBank.Clear()
                        oDataFiller.DataFill(Me.tbl_MstChannelBank, "ms_MstChannelBank_Select", String.Format("channel_id = '{0}' AND channelbank_line = {1} ", Me.mChannel_id, row.Item("channelbank_line")))
                        If Me.tbl_MstChannelBank.Rows.Count > 0 Then
                            row.Item("rekening_debit") = Me.tbl_MstChannelBank.Rows(0).Item("channelbank_rekening")
                            row.Item("bank_debit") = Me.tbl_MstChannelBank.Rows(0).Item("channelbank_name")
                            row.Item("account_bank_debit") = Me.tbl_MstChannelBank.Rows(0).Item("channelbank_accountname")
                        Else
                            row.Item("rekening_debit") = String.Empty
                            row.Item("bank_debit") = String.Empty
                            row.Item("account_bank_debit") = String.Empty
                        End If
                    Else
                        row.Item("channelbank_line") = 0
                        row.Item("rekening_debit") = String.Empty
                        row.Item("bank_debit") = String.Empty
                        row.Item("account_bank_debit") = String.Empty
                    End If

                    row.Item("channel_id") = Me.channel
                    row.Item("banktransfer_isdisabled") = 0
                    row.Item("banktransfer_invoice") = ""
                    row.Item("banktransfer_message") = ""
                    row.Item("banktransfer_episode1") = 0
                    row.Item("banktransfer_episode2") = 0
                    row.Item("project_id") = 0
                    row.Item("rekananartis_id") = 0
                    row.Item("banktransfer_episode") = ""
                    row.Item("banktransfer_create_by") = Me.user_name
                    row.Item("banktransfer_create_date") = Date.Now.Date

                    If retTbl.Rows(0).Item("penerima_bank").ToString.Trim = "Bank Mega" Or retTbl.Rows(0).Item("penerima_bank").ToString.Trim = "Bank Mega KPO" Then
                        row.Item("banktransfer_bi_foreign") = 0
                        row.Item("banktransfer_foreignrate") = Me.mRate
                        row.Item("banktransfer_bi_idr") = 0
                        row.Item("banktransfer_idr") = mAmountIdr2
                        row.Item("banktransfer_foreign") = mAmountForeign2
                    ElseIf (retTbl.Rows(0).Item("penerima_bank").ToString.Trim <> "Bank Mega" Or retTbl.Rows(0).Item("penerima_bank").ToString.Trim <> "Bank Mega KPO") And Me.mAmountIdr < 100000000 Then

                        If mCurrency_id = 1 Then
                            row.Item("banktransfer_bi_foreign") = 5000
                            row.Item("banktransfer_foreignrate") = Me.mRate
                            row.Item("banktransfer_bi_idr") = 5000
                            row.Item("banktransfer_idr") = mAmountIdr2
                            row.Item("banktransfer_foreign") = mAmountForeign2
                        ElseIf mCurrency_id = 2 Then
                            row.Item("banktransfer_bi_foreign") = 5000
                            row.Item("banktransfer_foreignrate") = Me.mRate
                            row.Item("banktransfer_bi_idr") = (mAmountIdr2 - 5000)
                            row.Item("banktransfer_idr") = mAmountIdr2
                            row.Item("banktransfer_foreign") = mAmountForeign2
                        Else
                            row.Item("banktransfer_bi_foreign") = 5000
                            row.Item("banktransfer_foreignrate") = Me.mRate
                            row.Item("banktransfer_bi_idr") = 5000
                            row.Item("banktransfer_idr") = mAmountIdr2
                            row.Item("banktransfer_foreign") = mAmountForeign2
                        End If

                    ElseIf (retTbl.Rows(0).Item("penerima_bank").ToString.Trim <> "Bank Mega" Or retTbl.Rows(0).Item("penerima_bank").ToString.Trim <> "Bank Mega KPO") And Me.mAmountIdr >= 100000000 Then

                        If mCurrency_id = 1 Then
                            row.Item("banktransfer_bi_foreign") = 25000
                            row.Item("banktransfer_foreignrate") = Me.mRate
                            row.Item("banktransfer_bi_idr") = 25000
                            row.Item("banktransfer_idr") = mAmountIdr2
                            row.Item("banktransfer_foreign") = mAmountForeign2
                        ElseIf mCurrency_id = 2 Then
                            row.Item("banktransfer_bi_foreign") = 25000
                            row.Item("banktransfer_foreignrate") = Me.mRate
                            row.Item("banktransfer_bi_idr") = (mAmountIdr2 - 25000)
                            row.Item("banktransfer_idr") = mAmountIdr2
                            row.Item("banktransfer_foreign") = mAmountForeign2
                        Else
                            row.Item("banktransfer_bi_foreign") = 25000
                            row.Item("banktransfer_foreignrate") = Me.mRate
                            row.Item("banktransfer_bi_idr") = 25000
                            row.Item("banktransfer_idr") = mAmountIdr2
                            row.Item("banktransfer_foreign") = mAmountForeign2
                        End If

                    End If

                    If Me.mAmountIdr < 100000000 Then

                        If mCurrency_id = 1 Then
                            row.Item("banktransfer_bi_foreign") = 0
                            row.Item("banktransfer_foreignrate") = Me.mRate
                            row.Item("banktransfer_bi_idr") = 0
                            row.Item("banktransfer_idr") = mAmountIdr2
                            row.Item("banktransfer_foreign") = mAmountForeign2
                        ElseIf mCurrency_id = 2 Then
                            row.Item("banktransfer_bi_foreign") = 0
                            row.Item("banktransfer_foreignrate") = Me.mRate
                            row.Item("banktransfer_bi_idr") = (mAmountIdr2 - 0)
                            row.Item("banktransfer_idr") = mAmountIdr2
                            row.Item("banktransfer_foreign") = mAmountForeign2
                        Else
                            row.Item("banktransfer_bi_foreign") = 0
                            row.Item("banktransfer_foreignrate") = Me.mRate
                            row.Item("banktransfer_bi_idr") = 0
                            row.Item("banktransfer_idr") = mAmountIdr2
                            row.Item("banktransfer_foreign") = mAmountForeign2
                        End If

                    ElseIf Me.mAmountIdr >= 100000000 Then

                        If mCurrency_id = 1 Then
                            row.Item("banktransfer_bi_foreign") = 0
                            row.Item("banktransfer_foreignrate") = Me.mRate
                            row.Item("banktransfer_bi_idr") = 0
                            row.Item("banktransfer_idr") = mAmountIdr2
                            row.Item("banktransfer_foreign") = mAmountForeign2
                        ElseIf mCurrency_id = 2 Then
                            row.Item("banktransfer_bi_foreign") = 0
                            row.Item("banktransfer_foreignrate") = Me.mRate
                            row.Item("banktransfer_bi_idr") = (mAmountIdr2 - 0)
                            row.Item("banktransfer_idr") = mAmountIdr2
                            row.Item("banktransfer_foreign") = mAmountForeign2
                        Else
                            row.Item("banktransfer_bi_foreign") = 0
                            row.Item("banktransfer_foreignrate") = Me.mRate
                            row.Item("banktransfer_bi_idr") = 0
                            row.Item("banktransfer_idr") = mAmountIdr2
                            row.Item("banktransfer_foreign") = mAmountForeign2
                        End If

                    End If

                    row.Item("jurnalbilyet_receiveperson") = retTbl.Rows(0).Item("penerima_name")
                    row.Item("jurnalbilyet_receiverekening") = retTbl.Rows(0).Item("penerima_rekening")
                    row.Item("jurnalbilyet_receivebank") = retTbl.Rows(0).Item("penerima_bank")
                    row.Item("jurnalbilyet_receiveaccountname") = retTbl.Rows(0).Item("penerima_bankaccountname")
                    row.Item("project_id") = retTbl.Rows(0).Item("show_id")
                    row.Item("banktransfer_episode") = retTbl.Rows(0).Item("prize_eps")

                    Me.tbl_TrnBankTransfer.Rows.Add(row)
                End If
            End If
            If DgvDetil.Rows.Count > 0 Then
                For i As Integer = 0 To DgvDetil.Rows.Count - 1
                    If i = 0 Then
                        Me.txtHitung.Text = Format(DgvDetil.Rows(i).Cells("banktransfer_idr").Value, "#,###0.00")
                    Else
                        Me.txtHitung.Text = Format(CType(Me.txtHitung.Text, Decimal) + DgvDetil.Rows(i).Cells("banktransfer_idr").Value, "#,###0.00")
                    End If
                Next
            Else
                Me.txtHitung.Text = "0.00"
            End If
        End If
    End Sub
    '=================================================
End Class