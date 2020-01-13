<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class uiTrnPVDocument2
    Inherits uiBase

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.ftabMain_List = New System.Windows.Forms.TabPage()
        Me.PnlDfMain = New System.Windows.Forms.Panel()
        Me.gcTrnPVDocument = New DevExpress.XtraGrid.GridControl()
        Me.gvTrnPVDocument = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colChannelID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colJurnalID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDocID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDocStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colPostBy = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colPostDt = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colUnpostBy = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colUnpostDt = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colVoidBy = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colVoidDt = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colJurnalBilyetNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colBankAccName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCurrencyId = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCurrencyName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colJurnalDetilForeign = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colJurnalDetilForeignRate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colJurnalDetilIdr = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colJurnalDetilDescr = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colRekananId = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colRekananName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAccCaName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colBookDt = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PnlDfFooter = New System.Windows.Forms.Panel()
        Me.PnlDfSearch = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.bookdate2 = New System.Windows.Forms.DateTimePicker()
        Me.bookdate1 = New System.Windows.Forms.DateTimePicker()
        Me.chkRangeBookDate = New System.Windows.Forms.CheckBox()
        Me.chkBankSrch = New System.Windows.Forms.CheckBox()
        Me.cboBankSrch = New System.Windows.Forms.ComboBox()
        Me.cboRekananIdSrch = New System.Windows.Forms.ComboBox()
        Me.chkRekananIDSrch = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtSearchDocId = New System.Windows.Forms.TextBox()
        Me.txtSearchJurnalID = New System.Windows.Forms.TextBox()
        Me.chkSearchJurnalID = New System.Windows.Forms.CheckBox()
        Me.cboSearchDocStatus = New System.Windows.Forms.ComboBox()
        Me.chkSearchDocId = New System.Windows.Forms.CheckBox()
        Me.chkSearchDocStatus = New System.Windows.Forms.CheckBox()
        Me.cbSearchType = New System.Windows.Forms.ComboBox()
        Me.chkType = New System.Windows.Forms.CheckBox()
        Me.cboSearchChannel = New System.Windows.Forms.ComboBox()
        Me.chkSearchChannel = New System.Windows.Forms.CheckBox()
        Me.ftabMain = New FlatTabControl.FlatTabControl()
        CType(Me.tbl_MstSetting, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ftabMain_List.SuspendLayout()
        Me.PnlDfMain.SuspendLayout()
        CType(Me.gcTrnPVDocument, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvTrnPVDocument, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlDfSearch.SuspendLayout()
        Me.ftabMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'ftabMain_List
        '
        Me.ftabMain_List.BackColor = System.Drawing.Color.Lavender
        Me.ftabMain_List.Controls.Add(Me.PnlDfMain)
        Me.ftabMain_List.Controls.Add(Me.PnlDfFooter)
        Me.ftabMain_List.Controls.Add(Me.PnlDfSearch)
        Me.ftabMain_List.Location = New System.Drawing.Point(4, 25)
        Me.ftabMain_List.Name = "ftabMain_List"
        Me.ftabMain_List.Padding = New System.Windows.Forms.Padding(3)
        Me.ftabMain_List.Size = New System.Drawing.Size(739, 488)
        Me.ftabMain_List.TabIndex = 0
        Me.ftabMain_List.Text = "List"
        '
        'PnlDfMain
        '
        Me.PnlDfMain.Controls.Add(Me.gcTrnPVDocument)
        Me.PnlDfMain.Location = New System.Drawing.Point(20, 181)
        Me.PnlDfMain.Name = "PnlDfMain"
        Me.PnlDfMain.Size = New System.Drawing.Size(704, 258)
        Me.PnlDfMain.TabIndex = 1
        '
        'gcTrnPVDocument
        '
        Me.gcTrnPVDocument.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gcTrnPVDocument.Location = New System.Drawing.Point(0, 0)
        Me.gcTrnPVDocument.MainView = Me.gvTrnPVDocument
        Me.gcTrnPVDocument.Name = "gcTrnPVDocument"
        Me.gcTrnPVDocument.Size = New System.Drawing.Size(704, 258)
        Me.gcTrnPVDocument.TabIndex = 1
        Me.gcTrnPVDocument.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvTrnPVDocument})
        '
        'gvTrnPVDocument
        '
        Me.gvTrnPVDocument.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colChannelID, Me.colJurnalID, Me.colDocID, Me.colDocStatus, Me.colPostBy, Me.colPostDt, Me.colUnpostBy, Me.colUnpostDt, Me.colVoidBy, Me.colVoidDt, Me.colJurnalBilyetNo, Me.colBankAccName, Me.colCurrencyId, Me.colCurrencyName, Me.colJurnalDetilForeign, Me.colJurnalDetilForeignRate, Me.colJurnalDetilIdr, Me.colJurnalDetilDescr, Me.colRekananId, Me.colRekananName, Me.colAccCaName, Me.colBookDt})
        Me.gvTrnPVDocument.GridControl = Me.gcTrnPVDocument
        Me.gvTrnPVDocument.Name = "gvTrnPVDocument"
        Me.gvTrnPVDocument.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.gvTrnPVDocument.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.gvTrnPVDocument.OptionsBehavior.ReadOnly = True
        Me.gvTrnPVDocument.OptionsView.ColumnAutoWidth = False
        Me.gvTrnPVDocument.OptionsView.ShowGroupPanel = False
        '
        'colChannelID
        '
        Me.colChannelID.Caption = "Channel"
        Me.colChannelID.FieldName = "channel_id"
        Me.colChannelID.Name = "colChannelID"
        Me.colChannelID.Visible = True
        Me.colChannelID.VisibleIndex = 0
        Me.colChannelID.Width = 50
        '
        'colJurnalID
        '
        Me.colJurnalID.Caption = "Jurnal ID"
        Me.colJurnalID.FieldName = "jurnal_id"
        Me.colJurnalID.Name = "colJurnalID"
        Me.colJurnalID.Visible = True
        Me.colJurnalID.VisibleIndex = 1
        Me.colJurnalID.Width = 85
        '
        'colDocID
        '
        Me.colDocID.Caption = "Doc. ID"
        Me.colDocID.FieldName = "doc_id"
        Me.colDocID.Name = "colDocID"
        Me.colDocID.Visible = True
        Me.colDocID.VisibleIndex = 2
        Me.colDocID.Width = 100
        '
        'colDocStatus
        '
        Me.colDocStatus.Caption = "Doc. Status"
        Me.colDocStatus.FieldName = "doc_status"
        Me.colDocStatus.Name = "colDocStatus"
        Me.colDocStatus.Visible = True
        Me.colDocStatus.VisibleIndex = 3
        '
        'colPostBy
        '
        Me.colPostBy.Caption = "Posted By"
        Me.colPostBy.FieldName = "post_by"
        Me.colPostBy.Name = "colPostBy"
        Me.colPostBy.Visible = True
        Me.colPostBy.VisibleIndex = 4
        '
        'colPostDt
        '
        Me.colPostDt.Caption = "Posted Time"
        Me.colPostDt.DisplayFormat.FormatString = "dd/MM/yyyy hh:mm:ss"
        Me.colPostDt.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.colPostDt.FieldName = "post_dt"
        Me.colPostDt.Name = "colPostDt"
        Me.colPostDt.OptionsColumn.AllowEdit = False
        Me.colPostDt.OptionsColumn.ReadOnly = True
        Me.colPostDt.Visible = True
        Me.colPostDt.VisibleIndex = 5
        Me.colPostDt.Width = 120
        '
        'colUnpostBy
        '
        Me.colUnpostBy.Caption = "Unpost By"
        Me.colUnpostBy.FieldName = "unpost_by"
        Me.colUnpostBy.Name = "colUnpostBy"
        Me.colUnpostBy.Visible = True
        Me.colUnpostBy.VisibleIndex = 6
        '
        'colUnpostDt
        '
        Me.colUnpostDt.Caption = "Unpost Time"
        Me.colUnpostDt.DisplayFormat.FormatString = "dd/MM/yyyy hh:mm:ss"
        Me.colUnpostDt.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.colUnpostDt.FieldName = "unpost_dt"
        Me.colUnpostDt.Name = "colUnpostDt"
        Me.colUnpostDt.OptionsColumn.AllowEdit = False
        Me.colUnpostDt.OptionsColumn.ReadOnly = True
        Me.colUnpostDt.Visible = True
        Me.colUnpostDt.VisibleIndex = 7
        Me.colUnpostDt.Width = 120
        '
        'colVoidBy
        '
        Me.colVoidBy.Caption = "Void By"
        Me.colVoidBy.FieldName = "void_by"
        Me.colVoidBy.Name = "colVoidBy"
        Me.colVoidBy.Visible = True
        Me.colVoidBy.VisibleIndex = 9
        '
        'colVoidDt
        '
        Me.colVoidDt.Caption = "Void Time"
        Me.colVoidDt.FieldName = "void_dt"
        Me.colVoidDt.Name = "colVoidDt"
        Me.colVoidDt.Visible = True
        Me.colVoidDt.VisibleIndex = 10
        '
        'colJurnalBilyetNo
        '
        Me.colJurnalBilyetNo.Caption = "Bilyet No."
        Me.colJurnalBilyetNo.FieldName = "jurnalbilyet_no"
        Me.colJurnalBilyetNo.Name = "colJurnalBilyetNo"
        Me.colJurnalBilyetNo.Visible = True
        Me.colJurnalBilyetNo.VisibleIndex = 11
        '
        'colBankAccName
        '
        Me.colBankAccName.Caption = "Bank Name"
        Me.colBankAccName.FieldName = "bankacc_name"
        Me.colBankAccName.Name = "colBankAccName"
        Me.colBankAccName.Visible = True
        Me.colBankAccName.VisibleIndex = 12
        Me.colBankAccName.Width = 150
        '
        'colCurrencyId
        '
        Me.colCurrencyId.Caption = "Currency ID"
        Me.colCurrencyId.FieldName = "currency_id"
        Me.colCurrencyId.Name = "colCurrencyId"
        '
        'colCurrencyName
        '
        Me.colCurrencyName.Caption = "Currency"
        Me.colCurrencyName.FieldName = "currency_name"
        Me.colCurrencyName.Name = "colCurrencyName"
        Me.colCurrencyName.Visible = True
        Me.colCurrencyName.VisibleIndex = 13
        '
        'colJurnalDetilForeign
        '
        Me.colJurnalDetilForeign.Caption = "Amount"
        Me.colJurnalDetilForeign.DisplayFormat.FormatString = "n2"
        Me.colJurnalDetilForeign.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colJurnalDetilForeign.FieldName = "jurnaldetil_foreign"
        Me.colJurnalDetilForeign.Name = "colJurnalDetilForeign"
        Me.colJurnalDetilForeign.Visible = True
        Me.colJurnalDetilForeign.VisibleIndex = 14
        Me.colJurnalDetilForeign.Width = 100
        '
        'colJurnalDetilForeignRate
        '
        Me.colJurnalDetilForeignRate.Caption = "Rate"
        Me.colJurnalDetilForeignRate.DisplayFormat.FormatString = "n2"
        Me.colJurnalDetilForeignRate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colJurnalDetilForeignRate.FieldName = "jurnaldetil_foreignrate"
        Me.colJurnalDetilForeignRate.Name = "colJurnalDetilForeignRate"
        Me.colJurnalDetilForeignRate.Visible = True
        Me.colJurnalDetilForeignRate.VisibleIndex = 15
        '
        'colJurnalDetilIdr
        '
        Me.colJurnalDetilIdr.Caption = "Amount IDR"
        Me.colJurnalDetilIdr.DisplayFormat.FormatString = "n0"
        Me.colJurnalDetilIdr.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colJurnalDetilIdr.FieldName = "jurnaldetil_idr"
        Me.colJurnalDetilIdr.Name = "colJurnalDetilIdr"
        Me.colJurnalDetilIdr.Visible = True
        Me.colJurnalDetilIdr.VisibleIndex = 16
        '
        'colJurnalDetilDescr
        '
        Me.colJurnalDetilDescr.Caption = "Description"
        Me.colJurnalDetilDescr.FieldName = "jurnaldetil_descr"
        Me.colJurnalDetilDescr.Name = "colJurnalDetilDescr"
        Me.colJurnalDetilDescr.Visible = True
        Me.colJurnalDetilDescr.VisibleIndex = 17
        Me.colJurnalDetilDescr.Width = 250
        '
        'colRekananId
        '
        Me.colRekananId.Caption = "Rekanan ID"
        Me.colRekananId.FieldName = "rekanan_id"
        Me.colRekananId.Name = "colRekananId"
        Me.colRekananId.Visible = True
        Me.colRekananId.VisibleIndex = 18
        '
        'colRekananName
        '
        Me.colRekananName.Caption = "Rekanan Name"
        Me.colRekananName.FieldName = "rekanan_name"
        Me.colRekananName.Name = "colRekananName"
        Me.colRekananName.Visible = True
        Me.colRekananName.VisibleIndex = 19
        Me.colRekananName.Width = 150
        '
        'colAccCaName
        '
        Me.colAccCaName.Caption = "CA Name"
        Me.colAccCaName.FieldName = "acc_ca_name"
        Me.colAccCaName.Name = "colAccCaName"
        Me.colAccCaName.Visible = True
        Me.colAccCaName.VisibleIndex = 20
        Me.colAccCaName.Width = 150
        '
        'colBookDt
        '
        Me.colBookDt.Caption = "Booked Time"
        Me.colBookDt.DisplayFormat.FormatString = "dd/MM/yyyy hh:mm:ss"
        Me.colBookDt.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.colBookDt.FieldName = "book_dt"
        Me.colBookDt.Name = "colBookDt"
        Me.colBookDt.OptionsColumn.AllowEdit = False
        Me.colBookDt.OptionsColumn.ReadOnly = True
        Me.colBookDt.Visible = True
        Me.colBookDt.VisibleIndex = 8
        Me.colBookDt.Width = 135
        '
        'PnlDfFooter
        '
        Me.PnlDfFooter.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnlDfFooter.Location = New System.Drawing.Point(3, 446)
        Me.PnlDfFooter.Name = "PnlDfFooter"
        Me.PnlDfFooter.Size = New System.Drawing.Size(733, 39)
        Me.PnlDfFooter.TabIndex = 2
        '
        'PnlDfSearch
        '
        Me.PnlDfSearch.Controls.Add(Me.Label2)
        Me.PnlDfSearch.Controls.Add(Me.bookdate2)
        Me.PnlDfSearch.Controls.Add(Me.bookdate1)
        Me.PnlDfSearch.Controls.Add(Me.chkRangeBookDate)
        Me.PnlDfSearch.Controls.Add(Me.chkBankSrch)
        Me.PnlDfSearch.Controls.Add(Me.cboBankSrch)
        Me.PnlDfSearch.Controls.Add(Me.cboRekananIdSrch)
        Me.PnlDfSearch.Controls.Add(Me.chkRekananIDSrch)
        Me.PnlDfSearch.Controls.Add(Me.Label1)
        Me.PnlDfSearch.Controls.Add(Me.Label3)
        Me.PnlDfSearch.Controls.Add(Me.txtSearchDocId)
        Me.PnlDfSearch.Controls.Add(Me.txtSearchJurnalID)
        Me.PnlDfSearch.Controls.Add(Me.chkSearchJurnalID)
        Me.PnlDfSearch.Controls.Add(Me.cboSearchDocStatus)
        Me.PnlDfSearch.Controls.Add(Me.chkSearchDocId)
        Me.PnlDfSearch.Controls.Add(Me.chkSearchDocStatus)
        Me.PnlDfSearch.Controls.Add(Me.cbSearchType)
        Me.PnlDfSearch.Controls.Add(Me.chkType)
        Me.PnlDfSearch.Controls.Add(Me.cboSearchChannel)
        Me.PnlDfSearch.Controls.Add(Me.chkSearchChannel)
        Me.PnlDfSearch.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlDfSearch.Location = New System.Drawing.Point(3, 3)
        Me.PnlDfSearch.Name = "PnlDfSearch"
        Me.PnlDfSearch.Size = New System.Drawing.Size(733, 172)
        Me.PnlDfSearch.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(192, 147)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(23, 13)
        Me.Label2.TabIndex = 253
        Me.Label2.Text = "s/d"
        '
        'bookdate2
        '
        Me.bookdate2.Enabled = False
        Me.bookdate2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.bookdate2.Location = New System.Drawing.Point(221, 144)
        Me.bookdate2.Name = "bookdate2"
        Me.bookdate2.Size = New System.Drawing.Size(95, 20)
        Me.bookdate2.TabIndex = 252
        '
        'bookdate1
        '
        Me.bookdate1.Enabled = False
        Me.bookdate1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.bookdate1.Location = New System.Drawing.Point(91, 144)
        Me.bookdate1.Name = "bookdate1"
        Me.bookdate1.Size = New System.Drawing.Size(95, 20)
        Me.bookdate1.TabIndex = 251
        '
        'chkRangeBookDate
        '
        Me.chkRangeBookDate.AutoSize = True
        Me.chkRangeBookDate.Location = New System.Drawing.Point(8, 146)
        Me.chkRangeBookDate.Name = "chkRangeBookDate"
        Me.chkRangeBookDate.Size = New System.Drawing.Size(77, 17)
        Me.chkRangeBookDate.TabIndex = 250
        Me.chkRangeBookDate.Text = "Book Date"
        Me.chkRangeBookDate.UseVisualStyleBackColor = True
        '
        'chkBankSrch
        '
        Me.chkBankSrch.AutoSize = True
        Me.chkBankSrch.Location = New System.Drawing.Point(420, 119)
        Me.chkBankSrch.Name = "chkBankSrch"
        Me.chkBankSrch.Size = New System.Drawing.Size(82, 17)
        Me.chkBankSrch.TabIndex = 249
        Me.chkBankSrch.Text = "Bank Name"
        Me.chkBankSrch.UseVisualStyleBackColor = True
        '
        'cboBankSrch
        '
        Me.cboBankSrch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboBankSrch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboBankSrch.BackColor = System.Drawing.Color.Honeydew
        Me.cboBankSrch.Enabled = False
        Me.cboBankSrch.FormattingEnabled = True
        Me.cboBankSrch.Location = New System.Drawing.Point(531, 115)
        Me.cboBankSrch.Name = "cboBankSrch"
        Me.cboBankSrch.Size = New System.Drawing.Size(187, 21)
        Me.cboBankSrch.TabIndex = 248
        '
        'cboRekananIdSrch
        '
        Me.cboRekananIdSrch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboRekananIdSrch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboRekananIdSrch.BackColor = System.Drawing.Color.Honeydew
        Me.cboRekananIdSrch.Enabled = False
        Me.cboRekananIdSrch.FormattingEnabled = True
        Me.cboRekananIdSrch.Location = New System.Drawing.Point(90, 117)
        Me.cboRekananIdSrch.Name = "cboRekananIdSrch"
        Me.cboRekananIdSrch.Size = New System.Drawing.Size(259, 21)
        Me.cboRekananIdSrch.TabIndex = 247
        '
        'chkRekananIDSrch
        '
        Me.chkRekananIDSrch.AutoSize = True
        Me.chkRekananIDSrch.Location = New System.Drawing.Point(8, 119)
        Me.chkRekananIDSrch.Name = "chkRekananIDSrch"
        Me.chkRekananIDSrch.Size = New System.Drawing.Size(70, 17)
        Me.chkRekananIDSrch.TabIndex = 246
        Me.chkRekananIDSrch.Text = "Rekanan"
        Me.chkRekananIDSrch.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(504, 92)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(214, 12)
        Me.Label1.TabIndex = 245
        Me.Label1.Text = "Use (;) to enter more than one references in textbox"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(86, 98)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(263, 12)
        Me.Label3.TabIndex = 245
        Me.Label3.Text = "Use semicolone (;) to enter more than one references in textbox"
        '
        'txtSearchDocId
        '
        Me.txtSearchDocId.BackColor = System.Drawing.Color.White
        Me.txtSearchDocId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSearchDocId.Location = New System.Drawing.Point(531, 38)
        Me.txtSearchDocId.Multiline = True
        Me.txtSearchDocId.Name = "txtSearchDocId"
        Me.txtSearchDocId.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtSearchDocId.Size = New System.Drawing.Size(189, 51)
        Me.txtSearchDocId.TabIndex = 233
        '
        'txtSearchJurnalID
        '
        Me.txtSearchJurnalID.BackColor = System.Drawing.Color.White
        Me.txtSearchJurnalID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSearchJurnalID.Location = New System.Drawing.Point(89, 38)
        Me.txtSearchJurnalID.Multiline = True
        Me.txtSearchJurnalID.Name = "txtSearchJurnalID"
        Me.txtSearchJurnalID.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtSearchJurnalID.Size = New System.Drawing.Size(315, 57)
        Me.txtSearchJurnalID.TabIndex = 233
        '
        'chkSearchJurnalID
        '
        Me.chkSearchJurnalID.AutoSize = True
        Me.chkSearchJurnalID.Location = New System.Drawing.Point(8, 41)
        Me.chkSearchJurnalID.Name = "chkSearchJurnalID"
        Me.chkSearchJurnalID.Size = New System.Drawing.Size(79, 17)
        Me.chkSearchJurnalID.TabIndex = 232
        Me.chkSearchJurnalID.Text = "Jurnal ID(s)"
        Me.chkSearchJurnalID.UseVisualStyleBackColor = True
        '
        'cboSearchDocStatus
        '
        Me.cboSearchDocStatus.BackColor = System.Drawing.Color.Honeydew
        Me.cboSearchDocStatus.Enabled = False
        Me.cboSearchDocStatus.FormattingEnabled = True
        Me.cboSearchDocStatus.Items.AddRange(New Object() {"POSTED", "UNPOSTED", "VOID"})
        Me.cboSearchDocStatus.Location = New System.Drawing.Point(531, 11)
        Me.cboSearchDocStatus.Name = "cboSearchDocStatus"
        Me.cboSearchDocStatus.Size = New System.Drawing.Size(109, 21)
        Me.cboSearchDocStatus.TabIndex = 231
        '
        'chkSearchDocId
        '
        Me.chkSearchDocId.AutoSize = True
        Me.chkSearchDocId.Location = New System.Drawing.Point(420, 34)
        Me.chkSearchDocId.Name = "chkSearchDocId"
        Me.chkSearchDocId.Size = New System.Drawing.Size(89, 17)
        Me.chkSearchDocId.TabIndex = 230
        Me.chkSearchDocId.Text = "Document ID"
        Me.chkSearchDocId.UseVisualStyleBackColor = True
        '
        'chkSearchDocStatus
        '
        Me.chkSearchDocStatus.AutoSize = True
        Me.chkSearchDocStatus.Location = New System.Drawing.Point(420, 11)
        Me.chkSearchDocStatus.Name = "chkSearchDocStatus"
        Me.chkSearchDocStatus.Size = New System.Drawing.Size(108, 17)
        Me.chkSearchDocStatus.TabIndex = 230
        Me.chkSearchDocStatus.Text = "Document Status"
        Me.chkSearchDocStatus.UseVisualStyleBackColor = True
        '
        'cbSearchType
        '
        Me.cbSearchType.BackColor = System.Drawing.Color.Honeydew
        Me.cbSearchType.Enabled = False
        Me.cbSearchType.FormattingEnabled = True
        Me.cbSearchType.Items.AddRange(New Object() {"PV", "OR"})
        Me.cbSearchType.Location = New System.Drawing.Point(333, 9)
        Me.cbSearchType.Name = "cbSearchType"
        Me.cbSearchType.Size = New System.Drawing.Size(71, 21)
        Me.cbSearchType.TabIndex = 231
        Me.cbSearchType.Text = "-- PILIH --"
        '
        'chkType
        '
        Me.chkType.AutoSize = True
        Me.chkType.Location = New System.Drawing.Point(277, 11)
        Me.chkType.Name = "chkType"
        Me.chkType.Size = New System.Drawing.Size(50, 17)
        Me.chkType.TabIndex = 230
        Me.chkType.Text = "Type"
        Me.chkType.UseVisualStyleBackColor = True
        '
        'cboSearchChannel
        '
        Me.cboSearchChannel.BackColor = System.Drawing.Color.Honeydew
        Me.cboSearchChannel.FormattingEnabled = True
        Me.cboSearchChannel.Location = New System.Drawing.Point(88, 9)
        Me.cboSearchChannel.Name = "cboSearchChannel"
        Me.cboSearchChannel.Size = New System.Drawing.Size(183, 21)
        Me.cboSearchChannel.TabIndex = 231
        '
        'chkSearchChannel
        '
        Me.chkSearchChannel.AutoSize = True
        Me.chkSearchChannel.Location = New System.Drawing.Point(8, 11)
        Me.chkSearchChannel.Name = "chkSearchChannel"
        Me.chkSearchChannel.Size = New System.Drawing.Size(65, 17)
        Me.chkSearchChannel.TabIndex = 230
        Me.chkSearchChannel.Text = "Channel"
        Me.chkSearchChannel.UseVisualStyleBackColor = True
        '
        'ftabMain
        '
        Me.ftabMain.Controls.Add(Me.ftabMain_List)
        Me.ftabMain.Location = New System.Drawing.Point(3, 28)
        Me.ftabMain.myBackColor = System.Drawing.Color.White
        Me.ftabMain.Name = "ftabMain"
        Me.ftabMain.SelectedIndex = 0
        Me.ftabMain.Size = New System.Drawing.Size(747, 517)
        Me.ftabMain.TabIndex = 1
        '
        'uiTrnPVDocument2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.Controls.Add(Me.ftabMain)
        Me.Name = "uiTrnPVDocument2"
        Me.Controls.SetChildIndex(Me.ftabMain, 0)
        CType(Me.tbl_MstSetting, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ftabMain_List.ResumeLayout(False)
        Me.PnlDfMain.ResumeLayout(False)
        CType(Me.gcTrnPVDocument, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvTrnPVDocument, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlDfSearch.ResumeLayout(False)
        Me.PnlDfSearch.PerformLayout()
        Me.ftabMain.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ftabMain_List As System.Windows.Forms.TabPage
    Friend WithEvents PnlDfMain As System.Windows.Forms.Panel
    Friend WithEvents PnlDfFooter As System.Windows.Forms.Panel
    Friend WithEvents PnlDfSearch As System.Windows.Forms.Panel
    Friend WithEvents ftabMain As FlatTabControl.FlatTabControl
    Friend WithEvents txtSearchJurnalID As System.Windows.Forms.TextBox
    Friend WithEvents chkSearchJurnalID As System.Windows.Forms.CheckBox
    Friend WithEvents cboSearchChannel As System.Windows.Forms.ComboBox
    Friend WithEvents chkSearchChannel As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboSearchDocStatus As System.Windows.Forms.ComboBox
    Friend WithEvents chkSearchDocStatus As System.Windows.Forms.CheckBox
    Friend WithEvents chkSearchDocId As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtSearchDocId As System.Windows.Forms.TextBox
    Friend WithEvents cbSearchType As System.Windows.Forms.ComboBox
    Friend WithEvents chkType As System.Windows.Forms.CheckBox
    Friend WithEvents gcTrnPVDocument As DevExpress.XtraGrid.GridControl
    Friend WithEvents gvTrnPVDocument As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colChannelID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colJurnalID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDocID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDocStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colPostBy As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colPostDt As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colUnpostBy As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colUnpostDt As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colVoidBy As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colVoidDt As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colJurnalBilyetNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colBankAccName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCurrencyId As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCurrencyName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colJurnalDetilForeign As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colJurnalDetilForeignRate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colJurnalDetilIdr As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colJurnalDetilDescr As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colRekananId As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colRekananName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents chkRekananIDSrch As System.Windows.Forms.CheckBox
    Friend WithEvents cboRekananIdSrch As System.Windows.Forms.ComboBox
    Friend WithEvents chkBankSrch As System.Windows.Forms.CheckBox
    Friend WithEvents cboBankSrch As System.Windows.Forms.ComboBox
    Friend WithEvents colAccCaName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colBookDt As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents bookdate1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents chkRangeBookDate As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents bookdate2 As System.Windows.Forms.DateTimePicker

End Class

