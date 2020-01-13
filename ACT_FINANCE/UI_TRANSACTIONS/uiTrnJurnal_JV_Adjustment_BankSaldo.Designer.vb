<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class uiTrnJurnal_JV_Adjustment_BankSaldo
    Inherits ACT_FINANCE.uiBase

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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(uiTrnJurnal_JV_Adjustment_BankSaldo))
        Me.ftabMain = New FlatTabControl.FlatTabControl()
        Me.ftabMain_List = New System.Windows.Forms.TabPage()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblLoading = New System.Windows.Forms.Label()
        Me.obj_ProgressBar_backGroundWorker = New System.Windows.Forms.ProgressBar()
        Me.PnlDfMain = New System.Windows.Forms.Panel()
        Me.DgvTrnJurnal = New System.Windows.Forms.DataGridView()
        Me.PnlDfFooter = New System.Windows.Forms.Panel()
        Me.txtLimit = New System.Windows.Forms.TextBox()
        Me.chkLimit = New System.Windows.Forms.CheckBox()
        Me.PnlDfSearch = New System.Windows.Forms.Panel()
        Me.cbo_periodeSearch = New System.Windows.Forms.ComboBox()
        Me.cbo_createBySearch = New System.Windows.Forms.ComboBox()
        Me.btn_Rekanan = New System.Windows.Forms.Button()
        Me.txtSearchRekananID = New System.Windows.Forms.TextBox()
        Me.chkSearchRekanan = New System.Windows.Forms.CheckBox()
        Me.chkSearchPeriode = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtSearchSource = New System.Windows.Forms.TextBox()
        Me.chkSearchSource = New System.Windows.Forms.CheckBox()
        Me.lnkQueryBuilder = New System.Windows.Forms.LinkLabel()
        Me.txtSearchAdv = New System.Windows.Forms.TextBox()
        Me.lnkClear = New System.Windows.Forms.LinkLabel()
        Me.chkSearchAdv = New System.Windows.Forms.CheckBox()
        Me.chkSearchCreateBy = New System.Windows.Forms.CheckBox()
        Me.txtSearchJurnalID = New System.Windows.Forms.TextBox()
        Me.chkSearchJurnalID = New System.Windows.Forms.CheckBox()
        Me.cboSearchChannel = New System.Windows.Forms.ComboBox()
        Me.chkSearchChannel = New System.Windows.Forms.CheckBox()
        Me.ftabMain_Data = New System.Windows.Forms.TabPage()
        Me.fTabDataDetil = New FlatTabControl.FlatTabControl()
        Me.ftabDataDetil_Debit = New System.Windows.Forms.TabPage()
        Me.DgvTrnJurnaldetil_Debit = New System.Windows.Forms.DataGridView()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.obj_amountDebit = New System.Windows.Forms.TextBox()
        Me.obj_amountDebitIdr = New System.Windows.Forms.TextBox()
        Me.ftabDataDetil_Credit = New System.Windows.Forms.TabPage()
        Me.DgvTrnJurnaldetil_Credit = New System.Windows.Forms.DataGridView()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.obj_amountCredit = New System.Windows.Forms.TextBox()
        Me.obj_amountCreditIdr = New System.Windows.Forms.TextBox()
        Me.ftabDataDetil_Response = New System.Windows.Forms.TabPage()
        Me.DgvTrnJurnalResponse = New System.Windows.Forms.DataGridView()
        Me.ftabDataDetil_Info = New System.Windows.Forms.TabPage()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lbl_Jurnaltype_id = New System.Windows.Forms.Label()
        Me.obj_Jurnal_iscreatedby = New System.Windows.Forms.TextBox()
        Me.lbl_Branch_id = New System.Windows.Forms.Label()
        Me.lbl_Jurnal_iscreatedate = New System.Windows.Forms.Label()
        Me.obj_Strukturunit_id = New System.Windows.Forms.TextBox()
        Me.obj_Jurnal_iscreatedate = New System.Windows.Forms.TextBox()
        Me.lbl_Strukturunit_id = New System.Windows.Forms.Label()
        Me.lbl_Jurnal_iscreatedby = New System.Windows.Forms.Label()
        Me.obj_Jurnal_iscreated = New System.Windows.Forms.CheckBox()
        Me.obj_Jurnal_isposteddate = New System.Windows.Forms.TextBox()
        Me.obj_Branch_id = New System.Windows.Forms.TextBox()
        Me.lbl_Jurnal_isposteddate = New System.Windows.Forms.Label()
        Me.lbl_Jurnal_ispostedby = New System.Windows.Forms.Label()
        Me.obj_Jurnal_ispostedby = New System.Windows.Forms.TextBox()
        Me.obj_Jurnal_isdisableddt = New System.Windows.Forms.TextBox()
        Me.lbl_Jurnal_isdisableddt = New System.Windows.Forms.Label()
        Me.lbl_Jurnal_isdisabledby = New System.Windows.Forms.Label()
        Me.obj_Jurnal_isdisabledby = New System.Windows.Forms.TextBox()
        Me.obj_Jurnal_isdisabled = New System.Windows.Forms.CheckBox()
        Me.obj_Created_dt = New System.Windows.Forms.TextBox()
        Me.lbl_Created_dt = New System.Windows.Forms.Label()
        Me.lbl_Created_by = New System.Windows.Forms.Label()
        Me.obj_Created_by = New System.Windows.Forms.TextBox()
        Me.obj_Modified_dt = New System.Windows.Forms.TextBox()
        Me.lbl_Modified_dt = New System.Windows.Forms.Label()
        Me.lbl_Modified_by = New System.Windows.Forms.Label()
        Me.obj_Modified_by = New System.Windows.Forms.TextBox()
        Me.obj_Region_id = New System.Windows.Forms.TextBox()
        Me.lbl_Region_id = New System.Windows.Forms.Label()
        Me.PnlDataMaster = New System.Windows.Forms.Panel()
        Me.btn_Budget_Header = New System.Windows.Forms.Button()
        Me.obj_Budget_name = New System.Windows.Forms.TextBox()
        Me.obj_Budget_id = New System.Windows.Forms.TextBox()
        Me.obj_Jurnal_descr = New System.Windows.Forms.TextBox()
        Me.obj_Acc_ca_id = New System.Windows.Forms.ComboBox()
        Me.obj_Jurnal_bookdate = New System.Windows.Forms.DateTimePicker()
        Me.obj_Jurnal_duedate = New System.Windows.Forms.DateTimePicker()
        Me.obj_Currency_id = New System.Windows.Forms.ComboBox()
        Me.obj_Channel_id = New System.Windows.Forms.ComboBox()
        Me.obj_Periode_id = New System.Windows.Forms.ComboBox()
        Me.obj_Rekanan_id = New System.Windows.Forms.ComboBox()
        Me.obj_Jurnal_billdate = New System.Windows.Forms.DateTimePicker()
        Me.lbl_Acc_ca_id = New System.Windows.Forms.Label()
        Me.obj_Jurnal_id = New System.Windows.Forms.TextBox()
        Me.lbl_Jurnal_id = New System.Windows.Forms.Label()
        Me.lbl_Jurnal_bookdate = New System.Windows.Forms.Label()
        Me.lbl_Jurnal_duedate = New System.Windows.Forms.Label()
        Me.obj_Jurnal_isposted = New System.Windows.Forms.CheckBox()
        Me.lbl_Jurnal_billdate = New System.Windows.Forms.Label()
        Me.lbl_Jurnal_descr = New System.Windows.Forms.Label()
        Me.obj_Jurnal_invoice_id = New System.Windows.Forms.TextBox()
        Me.lbl_Jurnal_invoice_id = New System.Windows.Forms.Label()
        Me.obj_Jurnal_invoice_descr = New System.Windows.Forms.TextBox()
        Me.lbl_Jurnal_invoice_descr = New System.Windows.Forms.Label()
        Me.obj_Jurnal_source = New System.Windows.Forms.TextBox()
        Me.lbl_Jurnal_source = New System.Windows.Forms.Label()
        Me.lbl_Rekanan_id = New System.Windows.Forms.Label()
        Me.lbl_Periode_id = New System.Windows.Forms.Label()
        Me.lbl_Channel_id = New System.Windows.Forms.Label()
        Me.lbl_Currency_id = New System.Windows.Forms.Label()
        Me.obj_Currency_rate = New System.Windows.Forms.TextBox()
        Me.lbl_Currency_rate = New System.Windows.Forms.Label()
        Me.obj_Jurnaltype_id = New System.Windows.Forms.TextBox()
        Me.lbl_Budget_id = New System.Windows.Forms.Label()
        Me.PnlDataFooter = New System.Windows.Forms.Panel()
        Me.btnTemplateXLS = New System.Windows.Forms.Button()
        Me.btnUpload = New System.Windows.Forms.Button()
        Me.PnlDataFooterFR = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.obj_Selisih_Foreign = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.obj_Jumlah_Foreign = New System.Windows.Forms.TextBox()
        Me.lbl_Selisih = New System.Windows.Forms.Label()
        Me.obj_Selisih = New System.Windows.Forms.TextBox()
        Me.obj_Jumlah = New System.Windows.Forms.TextBox()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        CType(Me.tbl_MstSetting, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ftabMain.SuspendLayout()
        Me.ftabMain_List.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.PnlDfMain.SuspendLayout()
        CType(Me.DgvTrnJurnal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlDfFooter.SuspendLayout()
        Me.PnlDfSearch.SuspendLayout()
        Me.ftabMain_Data.SuspendLayout()
        Me.fTabDataDetil.SuspendLayout()
        Me.ftabDataDetil_Debit.SuspendLayout()
        CType(Me.DgvTrnJurnaldetil_Debit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel6.SuspendLayout()
        Me.ftabDataDetil_Credit.SuspendLayout()
        CType(Me.DgvTrnJurnaldetil_Credit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.ftabDataDetil_Response.SuspendLayout()
        CType(Me.DgvTrnJurnalResponse, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ftabDataDetil_Info.SuspendLayout()
        Me.PnlDataMaster.SuspendLayout()
        Me.PnlDataFooter.SuspendLayout()
        Me.PnlDataFooterFR.SuspendLayout()
        Me.SuspendLayout()
        '
        'ftabMain
        '
        Me.ftabMain.Controls.Add(Me.ftabMain_List)
        Me.ftabMain.Controls.Add(Me.ftabMain_Data)
        Me.ftabMain.Location = New System.Drawing.Point(3, 28)
        Me.ftabMain.myBackColor = System.Drawing.Color.White
        Me.ftabMain.Name = "ftabMain"
        Me.ftabMain.SelectedIndex = 0
        Me.ftabMain.Size = New System.Drawing.Size(747, 517)
        Me.ftabMain.TabIndex = 1
        '
        'ftabMain_List
        '
        Me.ftabMain_List.BackColor = System.Drawing.Color.Lavender
        Me.ftabMain_List.Controls.Add(Me.Panel1)
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
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Moccasin
        Me.Panel1.Controls.Add(Me.lblLoading)
        Me.Panel1.Controls.Add(Me.obj_ProgressBar_backGroundWorker)
        Me.Panel1.Location = New System.Drawing.Point(189, 142)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(360, 82)
        Me.Panel1.TabIndex = 3
        Me.Panel1.UseWaitCursor = True
        Me.Panel1.Visible = False
        '
        'lblLoading
        '
        Me.lblLoading.AutoSize = True
        Me.lblLoading.Location = New System.Drawing.Point(53, 44)
        Me.lblLoading.Name = "lblLoading"
        Me.lblLoading.Size = New System.Drawing.Size(147, 13)
        Me.lblLoading.TabIndex = 57
        Me.lblLoading.Text = "Please Wait... Loading data..."
        Me.lblLoading.UseWaitCursor = True
        '
        'obj_ProgressBar_backGroundWorker
        '
        Me.obj_ProgressBar_backGroundWorker.ForeColor = System.Drawing.Color.Magenta
        Me.obj_ProgressBar_backGroundWorker.Location = New System.Drawing.Point(57, 32)
        Me.obj_ProgressBar_backGroundWorker.Name = "obj_ProgressBar_backGroundWorker"
        Me.obj_ProgressBar_backGroundWorker.RightToLeftLayout = True
        Me.obj_ProgressBar_backGroundWorker.Size = New System.Drawing.Size(252, 12)
        Me.obj_ProgressBar_backGroundWorker.Step = 5
        Me.obj_ProgressBar_backGroundWorker.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.obj_ProgressBar_backGroundWorker.TabIndex = 54
        Me.obj_ProgressBar_backGroundWorker.UseWaitCursor = True
        '
        'PnlDfMain
        '
        Me.PnlDfMain.Controls.Add(Me.DgvTrnJurnal)
        Me.PnlDfMain.Location = New System.Drawing.Point(20, 234)
        Me.PnlDfMain.Name = "PnlDfMain"
        Me.PnlDfMain.Size = New System.Drawing.Size(704, 193)
        Me.PnlDfMain.TabIndex = 1
        '
        'DgvTrnJurnal
        '
        Me.DgvTrnJurnal.BackgroundColor = System.Drawing.Color.Lavender
        Me.DgvTrnJurnal.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Comic Sans MS", 8.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DarkViolet
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvTrnJurnal.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DgvTrnJurnal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvTrnJurnal.Cursor = System.Windows.Forms.Cursors.Hand
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Comic Sans MS", 8.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DarkViolet
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgvTrnJurnal.DefaultCellStyle = DataGridViewCellStyle2
        Me.DgvTrnJurnal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvTrnJurnal.GridColor = System.Drawing.Color.Moccasin
        Me.DgvTrnJurnal.Location = New System.Drawing.Point(0, 0)
        Me.DgvTrnJurnal.Name = "DgvTrnJurnal"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Comic Sans MS", 8.0!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.DarkViolet
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvTrnJurnal.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DgvTrnJurnal.Size = New System.Drawing.Size(704, 193)
        Me.DgvTrnJurnal.TabIndex = 6
        '
        'PnlDfFooter
        '
        Me.PnlDfFooter.Controls.Add(Me.txtLimit)
        Me.PnlDfFooter.Controls.Add(Me.chkLimit)
        Me.PnlDfFooter.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnlDfFooter.Location = New System.Drawing.Point(3, 458)
        Me.PnlDfFooter.Name = "PnlDfFooter"
        Me.PnlDfFooter.Size = New System.Drawing.Size(733, 27)
        Me.PnlDfFooter.TabIndex = 2
        '
        'txtLimit
        '
        Me.txtLimit.Location = New System.Drawing.Point(117, 3)
        Me.txtLimit.Name = "txtLimit"
        Me.txtLimit.Size = New System.Drawing.Size(49, 20)
        Me.txtLimit.TabIndex = 7
        Me.txtLimit.Text = "100"
        Me.txtLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chkLimit
        '
        Me.chkLimit.AutoSize = True
        Me.chkLimit.Checked = True
        Me.chkLimit.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkLimit.Location = New System.Drawing.Point(17, 6)
        Me.chkLimit.Name = "chkLimit"
        Me.chkLimit.Size = New System.Drawing.Size(92, 17)
        Me.chkLimit.TabIndex = 6
        Me.chkLimit.Text = "Limit Result to"
        Me.chkLimit.UseVisualStyleBackColor = True
        '
        'PnlDfSearch
        '
        Me.PnlDfSearch.BackColor = System.Drawing.Color.Lavender
        Me.PnlDfSearch.Controls.Add(Me.cbo_periodeSearch)
        Me.PnlDfSearch.Controls.Add(Me.cbo_createBySearch)
        Me.PnlDfSearch.Controls.Add(Me.btn_Rekanan)
        Me.PnlDfSearch.Controls.Add(Me.txtSearchRekananID)
        Me.PnlDfSearch.Controls.Add(Me.chkSearchRekanan)
        Me.PnlDfSearch.Controls.Add(Me.chkSearchPeriode)
        Me.PnlDfSearch.Controls.Add(Me.Label3)
        Me.PnlDfSearch.Controls.Add(Me.txtSearchSource)
        Me.PnlDfSearch.Controls.Add(Me.chkSearchSource)
        Me.PnlDfSearch.Controls.Add(Me.lnkQueryBuilder)
        Me.PnlDfSearch.Controls.Add(Me.txtSearchAdv)
        Me.PnlDfSearch.Controls.Add(Me.lnkClear)
        Me.PnlDfSearch.Controls.Add(Me.chkSearchAdv)
        Me.PnlDfSearch.Controls.Add(Me.chkSearchCreateBy)
        Me.PnlDfSearch.Controls.Add(Me.txtSearchJurnalID)
        Me.PnlDfSearch.Controls.Add(Me.chkSearchJurnalID)
        Me.PnlDfSearch.Controls.Add(Me.cboSearchChannel)
        Me.PnlDfSearch.Controls.Add(Me.chkSearchChannel)
        Me.PnlDfSearch.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlDfSearch.Location = New System.Drawing.Point(3, 3)
        Me.PnlDfSearch.Name = "PnlDfSearch"
        Me.PnlDfSearch.Size = New System.Drawing.Size(733, 132)
        Me.PnlDfSearch.TabIndex = 0
        '
        'cbo_periodeSearch
        '
        Me.cbo_periodeSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbo_periodeSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbo_periodeSearch.BackColor = System.Drawing.Color.Honeydew
        Me.cbo_periodeSearch.FormattingEnabled = True
        Me.cbo_periodeSearch.Location = New System.Drawing.Point(476, 36)
        Me.cbo_periodeSearch.Name = "cbo_periodeSearch"
        Me.cbo_periodeSearch.Size = New System.Drawing.Size(223, 21)
        Me.cbo_periodeSearch.TabIndex = 229
        '
        'cbo_createBySearch
        '
        Me.cbo_createBySearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbo_createBySearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbo_createBySearch.BackColor = System.Drawing.Color.Honeydew
        Me.cbo_createBySearch.FormattingEnabled = True
        Me.cbo_createBySearch.Location = New System.Drawing.Point(476, 60)
        Me.cbo_createBySearch.Name = "cbo_createBySearch"
        Me.cbo_createBySearch.Size = New System.Drawing.Size(223, 21)
        Me.cbo_createBySearch.TabIndex = 228
        '
        'btn_Rekanan
        '
        Me.btn_Rekanan.Location = New System.Drawing.Point(573, 13)
        Me.btn_Rekanan.Name = "btn_Rekanan"
        Me.btn_Rekanan.Size = New System.Drawing.Size(24, 20)
        Me.btn_Rekanan.TabIndex = 227
        Me.btn_Rekanan.Text = "..."
        Me.btn_Rekanan.UseVisualStyleBackColor = True
        '
        'txtSearchRekananID
        '
        Me.txtSearchRekananID.BackColor = System.Drawing.Color.White
        Me.txtSearchRekananID.Location = New System.Drawing.Point(476, 13)
        Me.txtSearchRekananID.Name = "txtSearchRekananID"
        Me.txtSearchRekananID.Size = New System.Drawing.Size(91, 20)
        Me.txtSearchRekananID.TabIndex = 226
        '
        'chkSearchRekanan
        '
        Me.chkSearchRekanan.AutoSize = True
        Me.chkSearchRekanan.Location = New System.Drawing.Point(386, 15)
        Me.chkSearchRekanan.Name = "chkSearchRekanan"
        Me.chkSearchRekanan.Size = New System.Drawing.Size(84, 17)
        Me.chkSearchRekanan.TabIndex = 225
        Me.chkSearchRekanan.Text = "Rekanan ID"
        Me.chkSearchRekanan.UseVisualStyleBackColor = True
        '
        'chkSearchPeriode
        '
        Me.chkSearchPeriode.AutoSize = True
        Me.chkSearchPeriode.Location = New System.Drawing.Point(386, 39)
        Me.chkSearchPeriode.Name = "chkSearchPeriode"
        Me.chkSearchPeriode.Size = New System.Drawing.Size(62, 17)
        Me.chkSearchPeriode.TabIndex = 224
        Me.chkSearchPeriode.Text = "Periode"
        Me.chkSearchPeriode.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(87, 115)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(263, 12)
        Me.Label3.TabIndex = 223
        Me.Label3.Text = "Use semicolone (;) to enter more than one references in textbox"
        '
        'txtSearchSource
        '
        Me.txtSearchSource.BackColor = System.Drawing.Color.White
        Me.txtSearchSource.Enabled = False
        Me.txtSearchSource.Location = New System.Drawing.Point(89, 33)
        Me.txtSearchSource.Name = "txtSearchSource"
        Me.txtSearchSource.Size = New System.Drawing.Size(184, 20)
        Me.txtSearchSource.TabIndex = 222
        '
        'chkSearchSource
        '
        Me.chkSearchSource.AutoSize = True
        Me.chkSearchSource.Location = New System.Drawing.Point(17, 35)
        Me.chkSearchSource.Name = "chkSearchSource"
        Me.chkSearchSource.Size = New System.Drawing.Size(60, 17)
        Me.chkSearchSource.TabIndex = 221
        Me.chkSearchSource.Text = "Source"
        Me.chkSearchSource.UseVisualStyleBackColor = True
        '
        'lnkQueryBuilder
        '
        Me.lnkQueryBuilder.AutoSize = True
        Me.lnkQueryBuilder.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lnkQueryBuilder.Location = New System.Drawing.Point(518, 109)
        Me.lnkQueryBuilder.Name = "lnkQueryBuilder"
        Me.lnkQueryBuilder.Size = New System.Drawing.Size(70, 13)
        Me.lnkQueryBuilder.TabIndex = 220
        Me.lnkQueryBuilder.TabStop = True
        Me.lnkQueryBuilder.Text = "Query Builder"
        '
        'txtSearchAdv
        '
        Me.txtSearchAdv.BackColor = System.Drawing.Color.White
        Me.txtSearchAdv.Location = New System.Drawing.Point(476, 86)
        Me.txtSearchAdv.Name = "txtSearchAdv"
        Me.txtSearchAdv.Size = New System.Drawing.Size(223, 20)
        Me.txtSearchAdv.TabIndex = 218
        '
        'lnkClear
        '
        Me.lnkClear.AutoSize = True
        Me.lnkClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lnkClear.Location = New System.Drawing.Point(478, 109)
        Me.lnkClear.Name = "lnkClear"
        Me.lnkClear.Size = New System.Drawing.Size(31, 13)
        Me.lnkClear.TabIndex = 219
        Me.lnkClear.TabStop = True
        Me.lnkClear.Text = "Clear"
        '
        'chkSearchAdv
        '
        Me.chkSearchAdv.AutoSize = True
        Me.chkSearchAdv.Location = New System.Drawing.Point(386, 89)
        Me.chkSearchAdv.Name = "chkSearchAdv"
        Me.chkSearchAdv.Size = New System.Drawing.Size(79, 17)
        Me.chkSearchAdv.TabIndex = 217
        Me.chkSearchAdv.Text = "Adv.Seach"
        Me.chkSearchAdv.UseVisualStyleBackColor = True
        '
        'chkSearchCreateBy
        '
        Me.chkSearchCreateBy.AutoSize = True
        Me.chkSearchCreateBy.Location = New System.Drawing.Point(386, 65)
        Me.chkSearchCreateBy.Name = "chkSearchCreateBy"
        Me.chkSearchCreateBy.Size = New System.Drawing.Size(72, 17)
        Me.chkSearchCreateBy.TabIndex = 216
        Me.chkSearchCreateBy.Text = "Create By"
        Me.chkSearchCreateBy.UseVisualStyleBackColor = True
        '
        'txtSearchJurnalID
        '
        Me.txtSearchJurnalID.BackColor = System.Drawing.Color.White
        Me.txtSearchJurnalID.Location = New System.Drawing.Point(89, 58)
        Me.txtSearchJurnalID.Multiline = True
        Me.txtSearchJurnalID.Name = "txtSearchJurnalID"
        Me.txtSearchJurnalID.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtSearchJurnalID.Size = New System.Drawing.Size(277, 54)
        Me.txtSearchJurnalID.TabIndex = 215
        '
        'chkSearchJurnalID
        '
        Me.chkSearchJurnalID.AutoSize = True
        Me.chkSearchJurnalID.Location = New System.Drawing.Point(17, 60)
        Me.chkSearchJurnalID.Name = "chkSearchJurnalID"
        Me.chkSearchJurnalID.Size = New System.Drawing.Size(48, 17)
        Me.chkSearchJurnalID.TabIndex = 214
        Me.chkSearchJurnalID.Text = "ID(s)"
        Me.chkSearchJurnalID.UseVisualStyleBackColor = True
        '
        'cboSearchChannel
        '
        Me.cboSearchChannel.BackColor = System.Drawing.Color.Honeydew
        Me.cboSearchChannel.FormattingEnabled = True
        Me.cboSearchChannel.Location = New System.Drawing.Point(89, 9)
        Me.cboSearchChannel.Name = "cboSearchChannel"
        Me.cboSearchChannel.Size = New System.Drawing.Size(184, 21)
        Me.cboSearchChannel.TabIndex = 1
        '
        'chkSearchChannel
        '
        Me.chkSearchChannel.AutoSize = True
        Me.chkSearchChannel.Location = New System.Drawing.Point(17, 11)
        Me.chkSearchChannel.Name = "chkSearchChannel"
        Me.chkSearchChannel.Size = New System.Drawing.Size(65, 17)
        Me.chkSearchChannel.TabIndex = 0
        Me.chkSearchChannel.Text = "Channel"
        Me.chkSearchChannel.UseVisualStyleBackColor = True
        '
        'ftabMain_Data
        '
        Me.ftabMain_Data.BackColor = System.Drawing.Color.White
        Me.ftabMain_Data.Controls.Add(Me.fTabDataDetil)
        Me.ftabMain_Data.Controls.Add(Me.PnlDataMaster)
        Me.ftabMain_Data.Controls.Add(Me.PnlDataFooter)
        Me.ftabMain_Data.Location = New System.Drawing.Point(4, 25)
        Me.ftabMain_Data.Name = "ftabMain_Data"
        Me.ftabMain_Data.Padding = New System.Windows.Forms.Padding(3)
        Me.ftabMain_Data.Size = New System.Drawing.Size(739, 488)
        Me.ftabMain_Data.TabIndex = 1
        Me.ftabMain_Data.Text = "Data"
        '
        'fTabDataDetil
        '
        Me.fTabDataDetil.Controls.Add(Me.ftabDataDetil_Debit)
        Me.fTabDataDetil.Controls.Add(Me.ftabDataDetil_Credit)
        Me.fTabDataDetil.Controls.Add(Me.ftabDataDetil_Response)
        Me.fTabDataDetil.Controls.Add(Me.ftabDataDetil_Info)
        Me.fTabDataDetil.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fTabDataDetil.Location = New System.Drawing.Point(3, 172)
        Me.fTabDataDetil.myBackColor = System.Drawing.Color.Lavender
        Me.fTabDataDetil.Name = "fTabDataDetil"
        Me.fTabDataDetil.SelectedIndex = 0
        Me.fTabDataDetil.Size = New System.Drawing.Size(733, 260)
        Me.fTabDataDetil.TabIndex = 3
        '
        'ftabDataDetil_Debit
        '
        Me.ftabDataDetil_Debit.BackColor = System.Drawing.Color.White
        Me.ftabDataDetil_Debit.Controls.Add(Me.DgvTrnJurnaldetil_Debit)
        Me.ftabDataDetil_Debit.Controls.Add(Me.Panel6)
        Me.ftabDataDetil_Debit.Location = New System.Drawing.Point(4, 25)
        Me.ftabDataDetil_Debit.Name = "ftabDataDetil_Debit"
        Me.ftabDataDetil_Debit.Padding = New System.Windows.Forms.Padding(3)
        Me.ftabDataDetil_Debit.Size = New System.Drawing.Size(725, 231)
        Me.ftabDataDetil_Debit.TabIndex = 0
        Me.ftabDataDetil_Debit.Text = "Debit"
        '
        'DgvTrnJurnaldetil_Debit
        '
        Me.DgvTrnJurnaldetil_Debit.BackgroundColor = System.Drawing.Color.Lavender
        Me.DgvTrnJurnaldetil_Debit.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Comic Sans MS", 8.0!)
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.DarkViolet
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvTrnJurnaldetil_Debit.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.DgvTrnJurnaldetil_Debit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvTrnJurnaldetil_Debit.Cursor = System.Windows.Forms.Cursors.Hand
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Comic Sans MS", 8.0!)
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.DarkViolet
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgvTrnJurnaldetil_Debit.DefaultCellStyle = DataGridViewCellStyle5
        Me.DgvTrnJurnaldetil_Debit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvTrnJurnaldetil_Debit.GridColor = System.Drawing.Color.Moccasin
        Me.DgvTrnJurnaldetil_Debit.Location = New System.Drawing.Point(3, 3)
        Me.DgvTrnJurnaldetil_Debit.Name = "DgvTrnJurnaldetil_Debit"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Comic Sans MS", 8.0!)
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.DarkViolet
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvTrnJurnaldetil_Debit.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.DgvTrnJurnaldetil_Debit.Size = New System.Drawing.Size(719, 197)
        Me.DgvTrnJurnaldetil_Debit.TabIndex = 7
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.Label8)
        Me.Panel6.Controls.Add(Me.Label9)
        Me.Panel6.Controls.Add(Me.obj_amountDebit)
        Me.Panel6.Controls.Add(Me.obj_amountDebitIdr)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel6.Location = New System.Drawing.Point(3, 200)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(719, 28)
        Me.Panel6.TabIndex = 6
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(499, 6)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(83, 13)
        Me.Label8.TabIndex = 62
        Me.Label8.Text = "Amount (IDR)"
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(249, 6)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(49, 13)
        Me.Label9.TabIndex = 60
        Me.Label9.Text = "Amount"
        '
        'obj_amountDebit
        '
        Me.obj_amountDebit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.obj_amountDebit.BackColor = System.Drawing.Color.White
        Me.obj_amountDebit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.obj_amountDebit.ForeColor = System.Drawing.Color.Blue
        Me.obj_amountDebit.Location = New System.Drawing.Point(304, 3)
        Me.obj_amountDebit.Name = "obj_amountDebit"
        Me.obj_amountDebit.ReadOnly = True
        Me.obj_amountDebit.Size = New System.Drawing.Size(137, 20)
        Me.obj_amountDebit.TabIndex = 61
        Me.obj_amountDebit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'obj_amountDebitIdr
        '
        Me.obj_amountDebitIdr.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.obj_amountDebitIdr.BackColor = System.Drawing.Color.White
        Me.obj_amountDebitIdr.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.obj_amountDebitIdr.ForeColor = System.Drawing.Color.Blue
        Me.obj_amountDebitIdr.Location = New System.Drawing.Point(588, 3)
        Me.obj_amountDebitIdr.Name = "obj_amountDebitIdr"
        Me.obj_amountDebitIdr.ReadOnly = True
        Me.obj_amountDebitIdr.Size = New System.Drawing.Size(125, 20)
        Me.obj_amountDebitIdr.TabIndex = 59
        Me.obj_amountDebitIdr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ftabDataDetil_Credit
        '
        Me.ftabDataDetil_Credit.BackColor = System.Drawing.Color.LavenderBlush
        Me.ftabDataDetil_Credit.Controls.Add(Me.DgvTrnJurnaldetil_Credit)
        Me.ftabDataDetil_Credit.Controls.Add(Me.Panel3)
        Me.ftabDataDetil_Credit.Location = New System.Drawing.Point(4, 25)
        Me.ftabDataDetil_Credit.Name = "ftabDataDetil_Credit"
        Me.ftabDataDetil_Credit.Size = New System.Drawing.Size(178, 0)
        Me.ftabDataDetil_Credit.TabIndex = 1
        Me.ftabDataDetil_Credit.Text = "Credit"
        '
        'DgvTrnJurnaldetil_Credit
        '
        Me.DgvTrnJurnaldetil_Credit.BackgroundColor = System.Drawing.Color.Lavender
        Me.DgvTrnJurnaldetil_Credit.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Comic Sans MS", 8.0!)
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.DarkViolet
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvTrnJurnaldetil_Credit.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.DgvTrnJurnaldetil_Credit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvTrnJurnaldetil_Credit.Cursor = System.Windows.Forms.Cursors.Hand
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Comic Sans MS", 8.0!)
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.DarkViolet
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgvTrnJurnaldetil_Credit.DefaultCellStyle = DataGridViewCellStyle8
        Me.DgvTrnJurnaldetil_Credit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvTrnJurnaldetil_Credit.GridColor = System.Drawing.Color.Moccasin
        Me.DgvTrnJurnaldetil_Credit.Location = New System.Drawing.Point(0, 0)
        Me.DgvTrnJurnaldetil_Credit.Name = "DgvTrnJurnaldetil_Credit"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Comic Sans MS", 8.0!)
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.DarkViolet
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvTrnJurnaldetil_Credit.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.DgvTrnJurnaldetil_Credit.Size = New System.Drawing.Size(178, 0)
        Me.DgvTrnJurnaldetil_Credit.TabIndex = 8
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Controls.Add(Me.obj_amountCredit)
        Me.Panel3.Controls.Add(Me.obj_amountCreditIdr)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, -28)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(178, 28)
        Me.Panel3.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(-45, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 13)
        Me.Label1.TabIndex = 58
        Me.Label1.Text = "Amount (IDR)"
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(-295, 7)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(49, 13)
        Me.Label5.TabIndex = 56
        Me.Label5.Text = "Amount"
        '
        'obj_amountCredit
        '
        Me.obj_amountCredit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.obj_amountCredit.BackColor = System.Drawing.Color.White
        Me.obj_amountCredit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.obj_amountCredit.ForeColor = System.Drawing.Color.Blue
        Me.obj_amountCredit.Location = New System.Drawing.Point(-240, 4)
        Me.obj_amountCredit.Name = "obj_amountCredit"
        Me.obj_amountCredit.ReadOnly = True
        Me.obj_amountCredit.Size = New System.Drawing.Size(137, 20)
        Me.obj_amountCredit.TabIndex = 57
        Me.obj_amountCredit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'obj_amountCreditIdr
        '
        Me.obj_amountCreditIdr.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.obj_amountCreditIdr.BackColor = System.Drawing.Color.White
        Me.obj_amountCreditIdr.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.obj_amountCreditIdr.ForeColor = System.Drawing.Color.Blue
        Me.obj_amountCreditIdr.Location = New System.Drawing.Point(44, 3)
        Me.obj_amountCreditIdr.Name = "obj_amountCreditIdr"
        Me.obj_amountCreditIdr.ReadOnly = True
        Me.obj_amountCreditIdr.Size = New System.Drawing.Size(125, 20)
        Me.obj_amountCreditIdr.TabIndex = 55
        Me.obj_amountCreditIdr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ftabDataDetil_Response
        '
        Me.ftabDataDetil_Response.BackColor = System.Drawing.Color.LavenderBlush
        Me.ftabDataDetil_Response.Controls.Add(Me.DgvTrnJurnalResponse)
        Me.ftabDataDetil_Response.Location = New System.Drawing.Point(4, 25)
        Me.ftabDataDetil_Response.Name = "ftabDataDetil_Response"
        Me.ftabDataDetil_Response.Size = New System.Drawing.Size(178, 0)
        Me.ftabDataDetil_Response.TabIndex = 3
        Me.ftabDataDetil_Response.Text = "Response"
        '
        'DgvTrnJurnalResponse
        '
        Me.DgvTrnJurnalResponse.BackgroundColor = System.Drawing.Color.Lavender
        Me.DgvTrnJurnalResponse.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Comic Sans MS", 8.0!)
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.DarkViolet
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvTrnJurnalResponse.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle10
        Me.DgvTrnJurnalResponse.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvTrnJurnalResponse.Cursor = System.Windows.Forms.Cursors.Hand
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Comic Sans MS", 8.0!)
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.DarkViolet
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgvTrnJurnalResponse.DefaultCellStyle = DataGridViewCellStyle11
        Me.DgvTrnJurnalResponse.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvTrnJurnalResponse.GridColor = System.Drawing.Color.Moccasin
        Me.DgvTrnJurnalResponse.Location = New System.Drawing.Point(0, 0)
        Me.DgvTrnJurnalResponse.Name = "DgvTrnJurnalResponse"
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Comic Sans MS", 8.0!)
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.DarkViolet
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvTrnJurnalResponse.RowHeadersDefaultCellStyle = DataGridViewCellStyle12
        Me.DgvTrnJurnalResponse.Size = New System.Drawing.Size(178, 0)
        Me.DgvTrnJurnalResponse.TabIndex = 7
        '
        'ftabDataDetil_Info
        '
        Me.ftabDataDetil_Info.BackColor = System.Drawing.Color.LavenderBlush
        Me.ftabDataDetil_Info.Controls.Add(Me.Panel2)
        Me.ftabDataDetil_Info.Controls.Add(Me.lbl_Jurnaltype_id)
        Me.ftabDataDetil_Info.Controls.Add(Me.obj_Jurnal_iscreatedby)
        Me.ftabDataDetil_Info.Controls.Add(Me.lbl_Branch_id)
        Me.ftabDataDetil_Info.Controls.Add(Me.lbl_Jurnal_iscreatedate)
        Me.ftabDataDetil_Info.Controls.Add(Me.obj_Strukturunit_id)
        Me.ftabDataDetil_Info.Controls.Add(Me.obj_Jurnal_iscreatedate)
        Me.ftabDataDetil_Info.Controls.Add(Me.lbl_Strukturunit_id)
        Me.ftabDataDetil_Info.Controls.Add(Me.lbl_Jurnal_iscreatedby)
        Me.ftabDataDetil_Info.Controls.Add(Me.obj_Jurnal_iscreated)
        Me.ftabDataDetil_Info.Controls.Add(Me.obj_Jurnal_isposteddate)
        Me.ftabDataDetil_Info.Controls.Add(Me.obj_Branch_id)
        Me.ftabDataDetil_Info.Controls.Add(Me.lbl_Jurnal_isposteddate)
        Me.ftabDataDetil_Info.Controls.Add(Me.lbl_Jurnal_ispostedby)
        Me.ftabDataDetil_Info.Controls.Add(Me.obj_Jurnal_ispostedby)
        Me.ftabDataDetil_Info.Controls.Add(Me.obj_Jurnal_isdisableddt)
        Me.ftabDataDetil_Info.Controls.Add(Me.lbl_Jurnal_isdisableddt)
        Me.ftabDataDetil_Info.Controls.Add(Me.lbl_Jurnal_isdisabledby)
        Me.ftabDataDetil_Info.Controls.Add(Me.obj_Jurnal_isdisabledby)
        Me.ftabDataDetil_Info.Controls.Add(Me.obj_Jurnal_isdisabled)
        Me.ftabDataDetil_Info.Controls.Add(Me.obj_Created_dt)
        Me.ftabDataDetil_Info.Controls.Add(Me.lbl_Created_dt)
        Me.ftabDataDetil_Info.Controls.Add(Me.lbl_Created_by)
        Me.ftabDataDetil_Info.Controls.Add(Me.obj_Created_by)
        Me.ftabDataDetil_Info.Controls.Add(Me.obj_Modified_dt)
        Me.ftabDataDetil_Info.Controls.Add(Me.lbl_Modified_dt)
        Me.ftabDataDetil_Info.Controls.Add(Me.lbl_Modified_by)
        Me.ftabDataDetil_Info.Controls.Add(Me.obj_Modified_by)
        Me.ftabDataDetil_Info.Controls.Add(Me.obj_Region_id)
        Me.ftabDataDetil_Info.Controls.Add(Me.lbl_Region_id)
        Me.ftabDataDetil_Info.Location = New System.Drawing.Point(4, 25)
        Me.ftabDataDetil_Info.Name = "ftabDataDetil_Info"
        Me.ftabDataDetil_Info.Size = New System.Drawing.Size(178, 0)
        Me.ftabDataDetil_Info.TabIndex = 4
        Me.ftabDataDetil_Info.Text = "Info"
        '
        'Panel2
        '
        Me.Panel2.Location = New System.Drawing.Point(12, 156)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(640, 67)
        Me.Panel2.TabIndex = 3
        '
        'lbl_Jurnaltype_id
        '
        Me.lbl_Jurnaltype_id.AutoSize = True
        Me.lbl_Jurnaltype_id.Location = New System.Drawing.Point(206, 199)
        Me.lbl_Jurnaltype_id.Name = "lbl_Jurnaltype_id"
        Me.lbl_Jurnaltype_id.Size = New System.Drawing.Size(31, 13)
        Me.lbl_Jurnaltype_id.TabIndex = 0
        Me.lbl_Jurnaltype_id.Text = "Type"
        '
        'obj_Jurnal_iscreatedby
        '
        Me.obj_Jurnal_iscreatedby.BackColor = System.Drawing.Color.LightYellow
        Me.obj_Jurnal_iscreatedby.Location = New System.Drawing.Point(392, 27)
        Me.obj_Jurnal_iscreatedby.Name = "obj_Jurnal_iscreatedby"
        Me.obj_Jurnal_iscreatedby.ReadOnly = True
        Me.obj_Jurnal_iscreatedby.Size = New System.Drawing.Size(169, 20)
        Me.obj_Jurnal_iscreatedby.TabIndex = 1
        Me.obj_Jurnal_iscreatedby.TabStop = False
        '
        'lbl_Branch_id
        '
        Me.lbl_Branch_id.AutoSize = True
        Me.lbl_Branch_id.Location = New System.Drawing.Point(331, 192)
        Me.lbl_Branch_id.Name = "lbl_Branch_id"
        Me.lbl_Branch_id.Size = New System.Drawing.Size(55, 13)
        Me.lbl_Branch_id.TabIndex = 0
        Me.lbl_Branch_id.Text = "Branch_id"
        '
        'lbl_Jurnal_iscreatedate
        '
        Me.lbl_Jurnal_iscreatedate.AutoSize = True
        Me.lbl_Jurnal_iscreatedate.Location = New System.Drawing.Point(273, 52)
        Me.lbl_Jurnal_iscreatedate.Name = "lbl_Jurnal_iscreatedate"
        Me.lbl_Jurnal_iscreatedate.Size = New System.Drawing.Size(113, 13)
        Me.lbl_Jurnal_iscreatedate.TabIndex = 0
        Me.lbl_Jurnal_iscreatedate.Text = "Created Date (Journal)"
        '
        'obj_Strukturunit_id
        '
        Me.obj_Strukturunit_id.Location = New System.Drawing.Point(319, 173)
        Me.obj_Strukturunit_id.Name = "obj_Strukturunit_id"
        Me.obj_Strukturunit_id.Size = New System.Drawing.Size(100, 20)
        Me.obj_Strukturunit_id.TabIndex = 1
        '
        'obj_Jurnal_iscreatedate
        '
        Me.obj_Jurnal_iscreatedate.BackColor = System.Drawing.Color.LightYellow
        Me.obj_Jurnal_iscreatedate.Location = New System.Drawing.Point(392, 49)
        Me.obj_Jurnal_iscreatedate.Name = "obj_Jurnal_iscreatedate"
        Me.obj_Jurnal_iscreatedate.ReadOnly = True
        Me.obj_Jurnal_iscreatedate.Size = New System.Drawing.Size(169, 20)
        Me.obj_Jurnal_iscreatedate.TabIndex = 1
        Me.obj_Jurnal_iscreatedate.TabStop = False
        '
        'lbl_Strukturunit_id
        '
        Me.lbl_Strukturunit_id.AutoSize = True
        Me.lbl_Strukturunit_id.Location = New System.Drawing.Point(240, 179)
        Me.lbl_Strukturunit_id.Name = "lbl_Strukturunit_id"
        Me.lbl_Strukturunit_id.Size = New System.Drawing.Size(75, 13)
        Me.lbl_Strukturunit_id.TabIndex = 0
        Me.lbl_Strukturunit_id.Text = "Strukturunit_id"
        '
        'lbl_Jurnal_iscreatedby
        '
        Me.lbl_Jurnal_iscreatedby.AutoSize = True
        Me.lbl_Jurnal_iscreatedby.Location = New System.Drawing.Point(273, 30)
        Me.lbl_Jurnal_iscreatedby.Name = "lbl_Jurnal_iscreatedby"
        Me.lbl_Jurnal_iscreatedby.Size = New System.Drawing.Size(102, 13)
        Me.lbl_Jurnal_iscreatedby.TabIndex = 0
        Me.lbl_Jurnal_iscreatedby.Text = "Created By (Journal)"
        '
        'obj_Jurnal_iscreated
        '
        Me.obj_Jurnal_iscreated.AutoSize = True
        Me.obj_Jurnal_iscreated.Enabled = False
        Me.obj_Jurnal_iscreated.Location = New System.Drawing.Point(392, 8)
        Me.obj_Jurnal_iscreated.Name = "obj_Jurnal_iscreated"
        Me.obj_Jurnal_iscreated.Size = New System.Drawing.Size(106, 17)
        Me.obj_Jurnal_iscreated.TabIndex = 2
        Me.obj_Jurnal_iscreated.TabStop = False
        Me.obj_Jurnal_iscreated.Text = "Created (Journal)"
        Me.obj_Jurnal_iscreated.UseVisualStyleBackColor = True
        '
        'obj_Jurnal_isposteddate
        '
        Me.obj_Jurnal_isposteddate.BackColor = System.Drawing.Color.LightYellow
        Me.obj_Jurnal_isposteddate.Location = New System.Drawing.Point(87, 119)
        Me.obj_Jurnal_isposteddate.Name = "obj_Jurnal_isposteddate"
        Me.obj_Jurnal_isposteddate.ReadOnly = True
        Me.obj_Jurnal_isposteddate.Size = New System.Drawing.Size(153, 20)
        Me.obj_Jurnal_isposteddate.TabIndex = 1
        Me.obj_Jurnal_isposteddate.TabStop = False
        '
        'obj_Branch_id
        '
        Me.obj_Branch_id.Location = New System.Drawing.Point(392, 189)
        Me.obj_Branch_id.Name = "obj_Branch_id"
        Me.obj_Branch_id.Size = New System.Drawing.Size(100, 20)
        Me.obj_Branch_id.TabIndex = 1
        '
        'lbl_Jurnal_isposteddate
        '
        Me.lbl_Jurnal_isposteddate.AutoSize = True
        Me.lbl_Jurnal_isposteddate.Location = New System.Drawing.Point(9, 122)
        Me.lbl_Jurnal_isposteddate.Name = "lbl_Jurnal_isposteddate"
        Me.lbl_Jurnal_isposteddate.Size = New System.Drawing.Size(66, 13)
        Me.lbl_Jurnal_isposteddate.TabIndex = 0
        Me.lbl_Jurnal_isposteddate.Text = "Posted Date"
        '
        'lbl_Jurnal_ispostedby
        '
        Me.lbl_Jurnal_ispostedby.AutoSize = True
        Me.lbl_Jurnal_ispostedby.Location = New System.Drawing.Point(9, 100)
        Me.lbl_Jurnal_ispostedby.Name = "lbl_Jurnal_ispostedby"
        Me.lbl_Jurnal_ispostedby.Size = New System.Drawing.Size(55, 13)
        Me.lbl_Jurnal_ispostedby.TabIndex = 0
        Me.lbl_Jurnal_ispostedby.Text = "Posted By"
        '
        'obj_Jurnal_ispostedby
        '
        Me.obj_Jurnal_ispostedby.BackColor = System.Drawing.Color.LightYellow
        Me.obj_Jurnal_ispostedby.Location = New System.Drawing.Point(87, 97)
        Me.obj_Jurnal_ispostedby.Name = "obj_Jurnal_ispostedby"
        Me.obj_Jurnal_ispostedby.ReadOnly = True
        Me.obj_Jurnal_ispostedby.Size = New System.Drawing.Size(153, 20)
        Me.obj_Jurnal_ispostedby.TabIndex = 1
        Me.obj_Jurnal_ispostedby.TabStop = False
        '
        'obj_Jurnal_isdisableddt
        '
        Me.obj_Jurnal_isdisableddt.BackColor = System.Drawing.Color.LightYellow
        Me.obj_Jurnal_isdisableddt.Location = New System.Drawing.Point(392, 119)
        Me.obj_Jurnal_isdisableddt.Name = "obj_Jurnal_isdisableddt"
        Me.obj_Jurnal_isdisableddt.ReadOnly = True
        Me.obj_Jurnal_isdisableddt.Size = New System.Drawing.Size(129, 20)
        Me.obj_Jurnal_isdisableddt.TabIndex = 1
        Me.obj_Jurnal_isdisableddt.TabStop = False
        '
        'lbl_Jurnal_isdisableddt
        '
        Me.lbl_Jurnal_isdisableddt.AutoSize = True
        Me.lbl_Jurnal_isdisableddt.Location = New System.Drawing.Point(273, 122)
        Me.lbl_Jurnal_isdisableddt.Name = "lbl_Jurnal_isdisableddt"
        Me.lbl_Jurnal_isdisableddt.Size = New System.Drawing.Size(74, 13)
        Me.lbl_Jurnal_isdisableddt.TabIndex = 0
        Me.lbl_Jurnal_isdisableddt.Text = "Disabled Date"
        '
        'lbl_Jurnal_isdisabledby
        '
        Me.lbl_Jurnal_isdisabledby.AutoSize = True
        Me.lbl_Jurnal_isdisabledby.Location = New System.Drawing.Point(273, 100)
        Me.lbl_Jurnal_isdisabledby.Name = "lbl_Jurnal_isdisabledby"
        Me.lbl_Jurnal_isdisabledby.Size = New System.Drawing.Size(63, 13)
        Me.lbl_Jurnal_isdisabledby.TabIndex = 0
        Me.lbl_Jurnal_isdisabledby.Text = "Disabled By"
        '
        'obj_Jurnal_isdisabledby
        '
        Me.obj_Jurnal_isdisabledby.BackColor = System.Drawing.Color.LightYellow
        Me.obj_Jurnal_isdisabledby.Location = New System.Drawing.Point(392, 97)
        Me.obj_Jurnal_isdisabledby.Name = "obj_Jurnal_isdisabledby"
        Me.obj_Jurnal_isdisabledby.ReadOnly = True
        Me.obj_Jurnal_isdisabledby.Size = New System.Drawing.Size(129, 20)
        Me.obj_Jurnal_isdisabledby.TabIndex = 1
        Me.obj_Jurnal_isdisabledby.TabStop = False
        '
        'obj_Jurnal_isdisabled
        '
        Me.obj_Jurnal_isdisabled.AutoSize = True
        Me.obj_Jurnal_isdisabled.Enabled = False
        Me.obj_Jurnal_isdisabled.Location = New System.Drawing.Point(392, 74)
        Me.obj_Jurnal_isdisabled.Name = "obj_Jurnal_isdisabled"
        Me.obj_Jurnal_isdisabled.Size = New System.Drawing.Size(106, 17)
        Me.obj_Jurnal_isdisabled.TabIndex = 2
        Me.obj_Jurnal_isdisabled.TabStop = False
        Me.obj_Jurnal_isdisabled.Text = "Jurnal_isdisabled"
        Me.obj_Jurnal_isdisabled.UseVisualStyleBackColor = True
        '
        'obj_Created_dt
        '
        Me.obj_Created_dt.BackColor = System.Drawing.Color.LightYellow
        Me.obj_Created_dt.Location = New System.Drawing.Point(87, 31)
        Me.obj_Created_dt.Name = "obj_Created_dt"
        Me.obj_Created_dt.ReadOnly = True
        Me.obj_Created_dt.Size = New System.Drawing.Size(153, 20)
        Me.obj_Created_dt.TabIndex = 1
        Me.obj_Created_dt.TabStop = False
        '
        'lbl_Created_dt
        '
        Me.lbl_Created_dt.AutoSize = True
        Me.lbl_Created_dt.Location = New System.Drawing.Point(9, 34)
        Me.lbl_Created_dt.Name = "lbl_Created_dt"
        Me.lbl_Created_dt.Size = New System.Drawing.Size(70, 13)
        Me.lbl_Created_dt.TabIndex = 0
        Me.lbl_Created_dt.Text = "Created Date"
        '
        'lbl_Created_by
        '
        Me.lbl_Created_by.AutoSize = True
        Me.lbl_Created_by.Location = New System.Drawing.Point(9, 12)
        Me.lbl_Created_by.Name = "lbl_Created_by"
        Me.lbl_Created_by.Size = New System.Drawing.Size(59, 13)
        Me.lbl_Created_by.TabIndex = 0
        Me.lbl_Created_by.Text = "Created By"
        '
        'obj_Created_by
        '
        Me.obj_Created_by.BackColor = System.Drawing.Color.LightYellow
        Me.obj_Created_by.Location = New System.Drawing.Point(87, 9)
        Me.obj_Created_by.Name = "obj_Created_by"
        Me.obj_Created_by.ReadOnly = True
        Me.obj_Created_by.Size = New System.Drawing.Size(153, 20)
        Me.obj_Created_by.TabIndex = 1
        Me.obj_Created_by.TabStop = False
        '
        'obj_Modified_dt
        '
        Me.obj_Modified_dt.BackColor = System.Drawing.Color.LightYellow
        Me.obj_Modified_dt.Location = New System.Drawing.Point(87, 75)
        Me.obj_Modified_dt.Name = "obj_Modified_dt"
        Me.obj_Modified_dt.ReadOnly = True
        Me.obj_Modified_dt.Size = New System.Drawing.Size(153, 20)
        Me.obj_Modified_dt.TabIndex = 1
        Me.obj_Modified_dt.TabStop = False
        '
        'lbl_Modified_dt
        '
        Me.lbl_Modified_dt.AutoSize = True
        Me.lbl_Modified_dt.Location = New System.Drawing.Point(9, 78)
        Me.lbl_Modified_dt.Name = "lbl_Modified_dt"
        Me.lbl_Modified_dt.Size = New System.Drawing.Size(73, 13)
        Me.lbl_Modified_dt.TabIndex = 0
        Me.lbl_Modified_dt.Text = "Modified Date"
        '
        'lbl_Modified_by
        '
        Me.lbl_Modified_by.AutoSize = True
        Me.lbl_Modified_by.Location = New System.Drawing.Point(9, 56)
        Me.lbl_Modified_by.Name = "lbl_Modified_by"
        Me.lbl_Modified_by.Size = New System.Drawing.Size(62, 13)
        Me.lbl_Modified_by.TabIndex = 0
        Me.lbl_Modified_by.Text = "Modified By"
        '
        'obj_Modified_by
        '
        Me.obj_Modified_by.BackColor = System.Drawing.Color.LightYellow
        Me.obj_Modified_by.Location = New System.Drawing.Point(87, 53)
        Me.obj_Modified_by.Name = "obj_Modified_by"
        Me.obj_Modified_by.ReadOnly = True
        Me.obj_Modified_by.Size = New System.Drawing.Size(153, 20)
        Me.obj_Modified_by.TabIndex = 1
        Me.obj_Modified_by.TabStop = False
        '
        'obj_Region_id
        '
        Me.obj_Region_id.Location = New System.Drawing.Point(220, 156)
        Me.obj_Region_id.Name = "obj_Region_id"
        Me.obj_Region_id.Size = New System.Drawing.Size(100, 20)
        Me.obj_Region_id.TabIndex = 1
        '
        'lbl_Region_id
        '
        Me.lbl_Region_id.AutoSize = True
        Me.lbl_Region_id.Location = New System.Drawing.Point(159, 159)
        Me.lbl_Region_id.Name = "lbl_Region_id"
        Me.lbl_Region_id.Size = New System.Drawing.Size(55, 13)
        Me.lbl_Region_id.TabIndex = 0
        Me.lbl_Region_id.Text = "Region_id"
        '
        'PnlDataMaster
        '
        Me.PnlDataMaster.AutoScroll = True
        Me.PnlDataMaster.BackColor = System.Drawing.Color.Lavender
        Me.PnlDataMaster.Controls.Add(Me.btn_Budget_Header)
        Me.PnlDataMaster.Controls.Add(Me.obj_Budget_name)
        Me.PnlDataMaster.Controls.Add(Me.obj_Budget_id)
        Me.PnlDataMaster.Controls.Add(Me.obj_Jurnal_descr)
        Me.PnlDataMaster.Controls.Add(Me.obj_Acc_ca_id)
        Me.PnlDataMaster.Controls.Add(Me.obj_Jurnal_bookdate)
        Me.PnlDataMaster.Controls.Add(Me.obj_Jurnal_duedate)
        Me.PnlDataMaster.Controls.Add(Me.obj_Currency_id)
        Me.PnlDataMaster.Controls.Add(Me.obj_Channel_id)
        Me.PnlDataMaster.Controls.Add(Me.obj_Periode_id)
        Me.PnlDataMaster.Controls.Add(Me.obj_Rekanan_id)
        Me.PnlDataMaster.Controls.Add(Me.obj_Jurnal_billdate)
        Me.PnlDataMaster.Controls.Add(Me.lbl_Acc_ca_id)
        Me.PnlDataMaster.Controls.Add(Me.obj_Jurnal_id)
        Me.PnlDataMaster.Controls.Add(Me.lbl_Jurnal_id)
        Me.PnlDataMaster.Controls.Add(Me.lbl_Jurnal_bookdate)
        Me.PnlDataMaster.Controls.Add(Me.lbl_Jurnal_duedate)
        Me.PnlDataMaster.Controls.Add(Me.obj_Jurnal_isposted)
        Me.PnlDataMaster.Controls.Add(Me.lbl_Jurnal_billdate)
        Me.PnlDataMaster.Controls.Add(Me.lbl_Jurnal_descr)
        Me.PnlDataMaster.Controls.Add(Me.obj_Jurnal_invoice_id)
        Me.PnlDataMaster.Controls.Add(Me.lbl_Jurnal_invoice_id)
        Me.PnlDataMaster.Controls.Add(Me.obj_Jurnal_invoice_descr)
        Me.PnlDataMaster.Controls.Add(Me.lbl_Jurnal_invoice_descr)
        Me.PnlDataMaster.Controls.Add(Me.obj_Jurnal_source)
        Me.PnlDataMaster.Controls.Add(Me.lbl_Jurnal_source)
        Me.PnlDataMaster.Controls.Add(Me.lbl_Rekanan_id)
        Me.PnlDataMaster.Controls.Add(Me.lbl_Periode_id)
        Me.PnlDataMaster.Controls.Add(Me.lbl_Channel_id)
        Me.PnlDataMaster.Controls.Add(Me.lbl_Currency_id)
        Me.PnlDataMaster.Controls.Add(Me.obj_Currency_rate)
        Me.PnlDataMaster.Controls.Add(Me.lbl_Currency_rate)
        Me.PnlDataMaster.Controls.Add(Me.obj_Jurnaltype_id)
        Me.PnlDataMaster.Controls.Add(Me.lbl_Budget_id)
        Me.PnlDataMaster.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlDataMaster.Location = New System.Drawing.Point(3, 3)
        Me.PnlDataMaster.Name = "PnlDataMaster"
        Me.PnlDataMaster.Size = New System.Drawing.Size(733, 169)
        Me.PnlDataMaster.TabIndex = 0
        '
        'btn_Budget_Header
        '
        Me.btn_Budget_Header.BackColor = System.Drawing.Color.Honeydew
        Me.btn_Budget_Header.Location = New System.Drawing.Point(337, 118)
        Me.btn_Budget_Header.Name = "btn_Budget_Header"
        Me.btn_Budget_Header.Size = New System.Drawing.Size(24, 20)
        Me.btn_Budget_Header.TabIndex = 251
        Me.btn_Budget_Header.Text = "..."
        Me.btn_Budget_Header.UseVisualStyleBackColor = False
        '
        'obj_Budget_name
        '
        Me.obj_Budget_name.BackColor = System.Drawing.Color.LightYellow
        Me.obj_Budget_name.Location = New System.Drawing.Point(128, 118)
        Me.obj_Budget_name.Name = "obj_Budget_name"
        Me.obj_Budget_name.ReadOnly = True
        Me.obj_Budget_name.Size = New System.Drawing.Size(207, 20)
        Me.obj_Budget_name.TabIndex = 250
        '
        'obj_Budget_id
        '
        Me.obj_Budget_id.BackColor = System.Drawing.Color.LightYellow
        Me.obj_Budget_id.Location = New System.Drawing.Point(79, 118)
        Me.obj_Budget_id.Name = "obj_Budget_id"
        Me.obj_Budget_id.ReadOnly = True
        Me.obj_Budget_id.Size = New System.Drawing.Size(46, 20)
        Me.obj_Budget_id.TabIndex = 249
        Me.obj_Budget_id.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'obj_Jurnal_descr
        '
        Me.obj_Jurnal_descr.BackColor = System.Drawing.Color.White
        Me.obj_Jurnal_descr.Location = New System.Drawing.Point(438, 79)
        Me.obj_Jurnal_descr.Multiline = True
        Me.obj_Jurnal_descr.Name = "obj_Jurnal_descr"
        Me.obj_Jurnal_descr.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.obj_Jurnal_descr.Size = New System.Drawing.Size(285, 82)
        Me.obj_Jurnal_descr.TabIndex = 9
        '
        'obj_Acc_ca_id
        '
        Me.obj_Acc_ca_id.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.obj_Acc_ca_id.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.obj_Acc_ca_id.BackColor = System.Drawing.Color.Honeydew
        Me.obj_Acc_ca_id.FormattingEnabled = True
        Me.obj_Acc_ca_id.Location = New System.Drawing.Point(553, 117)
        Me.obj_Acc_ca_id.Name = "obj_Acc_ca_id"
        Me.obj_Acc_ca_id.Size = New System.Drawing.Size(100, 21)
        Me.obj_Acc_ca_id.TabIndex = 18
        '
        'obj_Jurnal_bookdate
        '
        Me.obj_Jurnal_bookdate.CalendarForeColor = System.Drawing.Color.Black
        Me.obj_Jurnal_bookdate.CalendarMonthBackground = System.Drawing.Color.White
        Me.obj_Jurnal_bookdate.CalendarTitleBackColor = System.Drawing.Color.Thistle
        Me.obj_Jurnal_bookdate.CalendarTitleForeColor = System.Drawing.Color.Black
        Me.obj_Jurnal_bookdate.CalendarTrailingForeColor = System.Drawing.Color.Gray
        Me.obj_Jurnal_bookdate.CustomFormat = "dd/MM/yyyy"
        Me.obj_Jurnal_bookdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.obj_Jurnal_bookdate.Location = New System.Drawing.Point(438, 48)
        Me.obj_Jurnal_bookdate.Name = "obj_Jurnal_bookdate"
        Me.obj_Jurnal_bookdate.Size = New System.Drawing.Size(100, 20)
        Me.obj_Jurnal_bookdate.TabIndex = 7
        '
        'obj_Jurnal_duedate
        '
        Me.obj_Jurnal_duedate.CalendarForeColor = System.Drawing.Color.Black
        Me.obj_Jurnal_duedate.CalendarTitleBackColor = System.Drawing.Color.Thistle
        Me.obj_Jurnal_duedate.CalendarTitleForeColor = System.Drawing.Color.Black
        Me.obj_Jurnal_duedate.CalendarTrailingForeColor = System.Drawing.Color.Gray
        Me.obj_Jurnal_duedate.CustomFormat = "dd/MM/yyyy"
        Me.obj_Jurnal_duedate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.obj_Jurnal_duedate.Location = New System.Drawing.Point(490, 110)
        Me.obj_Jurnal_duedate.Name = "obj_Jurnal_duedate"
        Me.obj_Jurnal_duedate.Size = New System.Drawing.Size(44, 20)
        Me.obj_Jurnal_duedate.TabIndex = 17
        '
        'obj_Currency_id
        '
        Me.obj_Currency_id.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.obj_Currency_id.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.obj_Currency_id.BackColor = System.Drawing.Color.Honeydew
        Me.obj_Currency_id.FormattingEnabled = True
        Me.obj_Currency_id.Location = New System.Drawing.Point(79, 70)
        Me.obj_Currency_id.Name = "obj_Currency_id"
        Me.obj_Currency_id.Size = New System.Drawing.Size(77, 21)
        Me.obj_Currency_id.TabIndex = 5
        '
        'obj_Channel_id
        '
        Me.obj_Channel_id.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.obj_Channel_id.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.obj_Channel_id.BackColor = System.Drawing.Color.Honeydew
        Me.obj_Channel_id.Enabled = False
        Me.obj_Channel_id.FormattingEnabled = True
        Me.obj_Channel_id.Location = New System.Drawing.Point(595, 7)
        Me.obj_Channel_id.Name = "obj_Channel_id"
        Me.obj_Channel_id.Size = New System.Drawing.Size(93, 21)
        Me.obj_Channel_id.TabIndex = 14
        Me.obj_Channel_id.TabStop = False
        '
        'obj_Periode_id
        '
        Me.obj_Periode_id.BackColor = System.Drawing.Color.Honeydew
        Me.obj_Periode_id.FormattingEnabled = True
        Me.obj_Periode_id.Location = New System.Drawing.Point(595, 47)
        Me.obj_Periode_id.Name = "obj_Periode_id"
        Me.obj_Periode_id.Size = New System.Drawing.Size(128, 21)
        Me.obj_Periode_id.TabIndex = 8
        '
        'obj_Rekanan_id
        '
        Me.obj_Rekanan_id.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.obj_Rekanan_id.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.obj_Rekanan_id.BackColor = System.Drawing.Color.Honeydew
        Me.obj_Rekanan_id.FormattingEnabled = True
        Me.obj_Rekanan_id.Location = New System.Drawing.Point(79, 47)
        Me.obj_Rekanan_id.Name = "obj_Rekanan_id"
        Me.obj_Rekanan_id.Size = New System.Drawing.Size(259, 21)
        Me.obj_Rekanan_id.TabIndex = 3
        '
        'obj_Jurnal_billdate
        '
        Me.obj_Jurnal_billdate.CalendarForeColor = System.Drawing.Color.Black
        Me.obj_Jurnal_billdate.CalendarTitleBackColor = System.Drawing.Color.Thistle
        Me.obj_Jurnal_billdate.CalendarTitleForeColor = System.Drawing.Color.Black
        Me.obj_Jurnal_billdate.CalendarTrailingForeColor = System.Drawing.Color.Gray
        Me.obj_Jurnal_billdate.CustomFormat = "dd/MM/yyyy"
        Me.obj_Jurnal_billdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.obj_Jurnal_billdate.Location = New System.Drawing.Point(540, 110)
        Me.obj_Jurnal_billdate.Name = "obj_Jurnal_billdate"
        Me.obj_Jurnal_billdate.Size = New System.Drawing.Size(27, 20)
        Me.obj_Jurnal_billdate.TabIndex = 8
        '
        'lbl_Acc_ca_id
        '
        Me.lbl_Acc_ca_id.AutoSize = True
        Me.lbl_Acc_ca_id.Location = New System.Drawing.Point(466, 125)
        Me.lbl_Acc_ca_id.Name = "lbl_Acc_ca_id"
        Me.lbl_Acc_ca_id.Size = New System.Drawing.Size(46, 13)
        Me.lbl_Acc_ca_id.TabIndex = 0
        Me.lbl_Acc_ca_id.Text = "CA Acc."
        '
        'obj_Jurnal_id
        '
        Me.obj_Jurnal_id.BackColor = System.Drawing.Color.LightYellow
        Me.obj_Jurnal_id.Location = New System.Drawing.Point(79, 7)
        Me.obj_Jurnal_id.Name = "obj_Jurnal_id"
        Me.obj_Jurnal_id.ReadOnly = True
        Me.obj_Jurnal_id.Size = New System.Drawing.Size(100, 20)
        Me.obj_Jurnal_id.TabIndex = 1
        Me.obj_Jurnal_id.TabStop = False
        '
        'lbl_Jurnal_id
        '
        Me.lbl_Jurnal_id.AutoSize = True
        Me.lbl_Jurnal_id.Location = New System.Drawing.Point(23, 10)
        Me.lbl_Jurnal_id.Name = "lbl_Jurnal_id"
        Me.lbl_Jurnal_id.Size = New System.Drawing.Size(18, 13)
        Me.lbl_Jurnal_id.TabIndex = 0
        Me.lbl_Jurnal_id.Text = "ID"
        '
        'lbl_Jurnal_bookdate
        '
        Me.lbl_Jurnal_bookdate.AutoSize = True
        Me.lbl_Jurnal_bookdate.Location = New System.Drawing.Point(366, 50)
        Me.lbl_Jurnal_bookdate.Name = "lbl_Jurnal_bookdate"
        Me.lbl_Jurnal_bookdate.Size = New System.Drawing.Size(58, 13)
        Me.lbl_Jurnal_bookdate.TabIndex = 0
        Me.lbl_Jurnal_bookdate.Text = "Book Date"
        '
        'lbl_Jurnal_duedate
        '
        Me.lbl_Jurnal_duedate.AutoSize = True
        Me.lbl_Jurnal_duedate.Location = New System.Drawing.Point(487, 90)
        Me.lbl_Jurnal_duedate.Name = "lbl_Jurnal_duedate"
        Me.lbl_Jurnal_duedate.Size = New System.Drawing.Size(53, 13)
        Me.lbl_Jurnal_duedate.TabIndex = 0
        Me.lbl_Jurnal_duedate.Text = "Due Date"
        '
        'obj_Jurnal_isposted
        '
        Me.obj_Jurnal_isposted.AutoSize = True
        Me.obj_Jurnal_isposted.Enabled = False
        Me.obj_Jurnal_isposted.Location = New System.Drawing.Point(309, 144)
        Me.obj_Jurnal_isposted.Name = "obj_Jurnal_isposted"
        Me.obj_Jurnal_isposted.Size = New System.Drawing.Size(59, 17)
        Me.obj_Jurnal_isposted.TabIndex = 2
        Me.obj_Jurnal_isposted.TabStop = False
        Me.obj_Jurnal_isposted.Text = "Posted"
        Me.obj_Jurnal_isposted.UseVisualStyleBackColor = True
        '
        'lbl_Jurnal_billdate
        '
        Me.lbl_Jurnal_billdate.AutoSize = True
        Me.lbl_Jurnal_billdate.Location = New System.Drawing.Point(537, 93)
        Me.lbl_Jurnal_billdate.Name = "lbl_Jurnal_billdate"
        Me.lbl_Jurnal_billdate.Size = New System.Drawing.Size(46, 13)
        Me.lbl_Jurnal_billdate.TabIndex = 0
        Me.lbl_Jurnal_billdate.Text = "Bill Date"
        '
        'lbl_Jurnal_descr
        '
        Me.lbl_Jurnal_descr.AutoSize = True
        Me.lbl_Jurnal_descr.Location = New System.Drawing.Point(366, 82)
        Me.lbl_Jurnal_descr.Name = "lbl_Jurnal_descr"
        Me.lbl_Jurnal_descr.Size = New System.Drawing.Size(60, 13)
        Me.lbl_Jurnal_descr.TabIndex = 0
        Me.lbl_Jurnal_descr.Text = "Description"
        '
        'obj_Jurnal_invoice_id
        '
        Me.obj_Jurnal_invoice_id.BackColor = System.Drawing.Color.LightYellow
        Me.obj_Jurnal_invoice_id.Location = New System.Drawing.Point(598, 86)
        Me.obj_Jurnal_invoice_id.Name = "obj_Jurnal_invoice_id"
        Me.obj_Jurnal_invoice_id.Size = New System.Drawing.Size(111, 20)
        Me.obj_Jurnal_invoice_id.TabIndex = 1
        '
        'lbl_Jurnal_invoice_id
        '
        Me.lbl_Jurnal_invoice_id.AutoSize = True
        Me.lbl_Jurnal_invoice_id.Location = New System.Drawing.Point(564, 89)
        Me.lbl_Jurnal_invoice_id.Name = "lbl_Jurnal_invoice_id"
        Me.lbl_Jurnal_invoice_id.Size = New System.Drawing.Size(39, 13)
        Me.lbl_Jurnal_invoice_id.TabIndex = 0
        Me.lbl_Jurnal_invoice_id.Text = "Tax ID"
        '
        'obj_Jurnal_invoice_descr
        '
        Me.obj_Jurnal_invoice_descr.BackColor = System.Drawing.Color.White
        Me.obj_Jurnal_invoice_descr.Location = New System.Drawing.Point(490, 90)
        Me.obj_Jurnal_invoice_descr.Multiline = True
        Me.obj_Jurnal_invoice_descr.Name = "obj_Jurnal_invoice_descr"
        Me.obj_Jurnal_invoice_descr.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.obj_Jurnal_invoice_descr.Size = New System.Drawing.Size(100, 21)
        Me.obj_Jurnal_invoice_descr.TabIndex = 1
        '
        'lbl_Jurnal_invoice_descr
        '
        Me.lbl_Jurnal_invoice_descr.AutoSize = True
        Me.lbl_Jurnal_invoice_descr.Location = New System.Drawing.Point(500, 90)
        Me.lbl_Jurnal_invoice_descr.Name = "lbl_Jurnal_invoice_descr"
        Me.lbl_Jurnal_invoice_descr.Size = New System.Drawing.Size(76, 13)
        Me.lbl_Jurnal_invoice_descr.TabIndex = 0
        Me.lbl_Jurnal_invoice_descr.Text = "Invoice Descr."
        '
        'obj_Jurnal_source
        '
        Me.obj_Jurnal_source.BackColor = System.Drawing.Color.LightYellow
        Me.obj_Jurnal_source.Location = New System.Drawing.Point(438, 7)
        Me.obj_Jurnal_source.Name = "obj_Jurnal_source"
        Me.obj_Jurnal_source.ReadOnly = True
        Me.obj_Jurnal_source.Size = New System.Drawing.Size(100, 20)
        Me.obj_Jurnal_source.TabIndex = 1
        Me.obj_Jurnal_source.TabStop = False
        '
        'lbl_Jurnal_source
        '
        Me.lbl_Jurnal_source.AutoSize = True
        Me.lbl_Jurnal_source.Location = New System.Drawing.Point(366, 10)
        Me.lbl_Jurnal_source.Name = "lbl_Jurnal_source"
        Me.lbl_Jurnal_source.Size = New System.Drawing.Size(41, 13)
        Me.lbl_Jurnal_source.TabIndex = 0
        Me.lbl_Jurnal_source.Text = "Source"
        '
        'lbl_Rekanan_id
        '
        Me.lbl_Rekanan_id.AutoSize = True
        Me.lbl_Rekanan_id.Location = New System.Drawing.Point(23, 50)
        Me.lbl_Rekanan_id.Name = "lbl_Rekanan_id"
        Me.lbl_Rekanan_id.Size = New System.Drawing.Size(51, 13)
        Me.lbl_Rekanan_id.TabIndex = 0
        Me.lbl_Rekanan_id.Text = "Rekanan"
        '
        'lbl_Periode_id
        '
        Me.lbl_Periode_id.AutoSize = True
        Me.lbl_Periode_id.Location = New System.Drawing.Point(549, 50)
        Me.lbl_Periode_id.Name = "lbl_Periode_id"
        Me.lbl_Periode_id.Size = New System.Drawing.Size(37, 13)
        Me.lbl_Periode_id.TabIndex = 0
        Me.lbl_Periode_id.Text = "Period"
        '
        'lbl_Channel_id
        '
        Me.lbl_Channel_id.AutoSize = True
        Me.lbl_Channel_id.Location = New System.Drawing.Point(549, 10)
        Me.lbl_Channel_id.Name = "lbl_Channel_id"
        Me.lbl_Channel_id.Size = New System.Drawing.Size(49, 13)
        Me.lbl_Channel_id.TabIndex = 0
        Me.lbl_Channel_id.Text = "Channel "
        '
        'lbl_Currency_id
        '
        Me.lbl_Currency_id.AutoSize = True
        Me.lbl_Currency_id.Location = New System.Drawing.Point(23, 73)
        Me.lbl_Currency_id.Name = "lbl_Currency_id"
        Me.lbl_Currency_id.Size = New System.Drawing.Size(29, 13)
        Me.lbl_Currency_id.TabIndex = 0
        Me.lbl_Currency_id.Text = "Curr."
        '
        'obj_Currency_rate
        '
        Me.obj_Currency_rate.BackColor = System.Drawing.Color.White
        Me.obj_Currency_rate.Location = New System.Drawing.Point(79, 94)
        Me.obj_Currency_rate.Name = "obj_Currency_rate"
        Me.obj_Currency_rate.Size = New System.Drawing.Size(77, 20)
        Me.obj_Currency_rate.TabIndex = 6
        Me.obj_Currency_rate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbl_Currency_rate
        '
        Me.lbl_Currency_rate.AutoSize = True
        Me.lbl_Currency_rate.Location = New System.Drawing.Point(23, 94)
        Me.lbl_Currency_rate.Name = "lbl_Currency_rate"
        Me.lbl_Currency_rate.Size = New System.Drawing.Size(30, 13)
        Me.lbl_Currency_rate.TabIndex = 0
        Me.lbl_Currency_rate.Text = "Rate"
        '
        'obj_Jurnaltype_id
        '
        Me.obj_Jurnaltype_id.Location = New System.Drawing.Point(459, 87)
        Me.obj_Jurnaltype_id.Name = "obj_Jurnaltype_id"
        Me.obj_Jurnaltype_id.Size = New System.Drawing.Size(53, 20)
        Me.obj_Jurnaltype_id.TabIndex = 1
        '
        'lbl_Budget_id
        '
        Me.lbl_Budget_id.AutoSize = True
        Me.lbl_Budget_id.Location = New System.Drawing.Point(23, 121)
        Me.lbl_Budget_id.Name = "lbl_Budget_id"
        Me.lbl_Budget_id.Size = New System.Drawing.Size(41, 13)
        Me.lbl_Budget_id.TabIndex = 0
        Me.lbl_Budget_id.Text = "Budget"
        '
        'PnlDataFooter
        '
        Me.PnlDataFooter.Controls.Add(Me.btnTemplateXLS)
        Me.PnlDataFooter.Controls.Add(Me.btnUpload)
        Me.PnlDataFooter.Controls.Add(Me.PnlDataFooterFR)
        Me.PnlDataFooter.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnlDataFooter.Location = New System.Drawing.Point(3, 432)
        Me.PnlDataFooter.Name = "PnlDataFooter"
        Me.PnlDataFooter.Size = New System.Drawing.Size(733, 53)
        Me.PnlDataFooter.TabIndex = 2
        '
        'btnTemplateXLS
        '
        Me.btnTemplateXLS.Location = New System.Drawing.Point(7, 12)
        Me.btnTemplateXLS.Name = "btnTemplateXLS"
        Me.btnTemplateXLS.Size = New System.Drawing.Size(90, 29)
        Me.btnTemplateXLS.TabIndex = 13
        Me.btnTemplateXLS.Text = "Excel Template"
        Me.btnTemplateXLS.UseVisualStyleBackColor = True
        '
        'btnUpload
        '
        Me.btnUpload.Location = New System.Drawing.Point(106, 12)
        Me.btnUpload.Name = "btnUpload"
        Me.btnUpload.Size = New System.Drawing.Size(76, 29)
        Me.btnUpload.TabIndex = 11
        Me.btnUpload.Text = "Import Excel"
        Me.btnUpload.UseVisualStyleBackColor = True
        '
        'PnlDataFooterFR
        '
        Me.PnlDataFooterFR.Controls.Add(Me.Label7)
        Me.PnlDataFooterFR.Controls.Add(Me.obj_Selisih_Foreign)
        Me.PnlDataFooterFR.Controls.Add(Me.Label6)
        Me.PnlDataFooterFR.Controls.Add(Me.Label2)
        Me.PnlDataFooterFR.Controls.Add(Me.Label4)
        Me.PnlDataFooterFR.Controls.Add(Me.obj_Jumlah_Foreign)
        Me.PnlDataFooterFR.Controls.Add(Me.lbl_Selisih)
        Me.PnlDataFooterFR.Controls.Add(Me.obj_Selisih)
        Me.PnlDataFooterFR.Controls.Add(Me.obj_Jumlah)
        Me.PnlDataFooterFR.Dock = System.Windows.Forms.DockStyle.Right
        Me.PnlDataFooterFR.Location = New System.Drawing.Point(205, 0)
        Me.PnlDataFooterFR.Name = "PnlDataFooterFR"
        Me.PnlDataFooterFR.Size = New System.Drawing.Size(528, 53)
        Me.PnlDataFooterFR.TabIndex = 9
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(260, 32)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(124, 13)
        Me.Label7.TabIndex = 55
        Me.Label7.Text = "Selisih Amount (IDR)"
        '
        'obj_Selisih_Foreign
        '
        Me.obj_Selisih_Foreign.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.obj_Selisih_Foreign.BackColor = System.Drawing.Color.White
        Me.obj_Selisih_Foreign.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.obj_Selisih_Foreign.Location = New System.Drawing.Point(106, 30)
        Me.obj_Selisih_Foreign.Name = "obj_Selisih_Foreign"
        Me.obj_Selisih_Foreign.ReadOnly = True
        Me.obj_Selisih_Foreign.Size = New System.Drawing.Size(137, 20)
        Me.obj_Selisih_Foreign.TabIndex = 7
        Me.obj_Selisih_Foreign.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(260, 7)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(126, 13)
        Me.Label6.TabIndex = 54
        Me.Label6.Text = "Jumlah Amount (IDR)"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(10, 33)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(90, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Selisih Amount"
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(8, 6)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(92, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Jumlah Amount"
        '
        'obj_Jumlah_Foreign
        '
        Me.obj_Jumlah_Foreign.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.obj_Jumlah_Foreign.BackColor = System.Drawing.Color.White
        Me.obj_Jumlah_Foreign.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.obj_Jumlah_Foreign.ForeColor = System.Drawing.Color.Blue
        Me.obj_Jumlah_Foreign.Location = New System.Drawing.Point(106, 4)
        Me.obj_Jumlah_Foreign.Name = "obj_Jumlah_Foreign"
        Me.obj_Jumlah_Foreign.ReadOnly = True
        Me.obj_Jumlah_Foreign.Size = New System.Drawing.Size(137, 20)
        Me.obj_Jumlah_Foreign.TabIndex = 5
        Me.obj_Jumlah_Foreign.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbl_Selisih
        '
        Me.lbl_Selisih.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_Selisih.AutoSize = True
        Me.lbl_Selisih.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Selisih.Location = New System.Drawing.Point(129, 34)
        Me.lbl_Selisih.Name = "lbl_Selisih"
        Me.lbl_Selisih.Size = New System.Drawing.Size(44, 13)
        Me.lbl_Selisih.TabIndex = 2
        Me.lbl_Selisih.Text = "Selisih"
        '
        'obj_Selisih
        '
        Me.obj_Selisih.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.obj_Selisih.BackColor = System.Drawing.Color.White
        Me.obj_Selisih.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.obj_Selisih.Location = New System.Drawing.Point(390, 29)
        Me.obj_Selisih.Name = "obj_Selisih"
        Me.obj_Selisih.ReadOnly = True
        Me.obj_Selisih.Size = New System.Drawing.Size(125, 20)
        Me.obj_Selisih.TabIndex = 3
        Me.obj_Selisih.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'obj_Jumlah
        '
        Me.obj_Jumlah.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.obj_Jumlah.BackColor = System.Drawing.Color.White
        Me.obj_Jumlah.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.obj_Jumlah.ForeColor = System.Drawing.Color.Blue
        Me.obj_Jumlah.Location = New System.Drawing.Point(390, 4)
        Me.obj_Jumlah.Name = "obj_Jumlah"
        Me.obj_Jumlah.ReadOnly = True
        Me.obj_Jumlah.Size = New System.Drawing.Size(125, 20)
        Me.obj_Jumlah.TabIndex = 1
        Me.obj_Jumlah.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'BackgroundWorker1
        '
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'uiTrnJurnal_JV_Adjustment_BankSaldo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.Controls.Add(Me.ftabMain)
        Me.Name = "uiTrnJurnal_JV_Adjustment_BankSaldo"
        Me.Controls.SetChildIndex(Me.ftabMain, 0)
        CType(Me.tbl_MstSetting, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ftabMain.ResumeLayout(False)
        Me.ftabMain_List.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.PnlDfMain.ResumeLayout(False)
        CType(Me.DgvTrnJurnal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlDfFooter.ResumeLayout(False)
        Me.PnlDfFooter.PerformLayout()
        Me.PnlDfSearch.ResumeLayout(False)
        Me.PnlDfSearch.PerformLayout()
        Me.ftabMain_Data.ResumeLayout(False)
        Me.fTabDataDetil.ResumeLayout(False)
        Me.ftabDataDetil_Debit.ResumeLayout(False)
        CType(Me.DgvTrnJurnaldetil_Debit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.ftabDataDetil_Credit.ResumeLayout(False)
        CType(Me.DgvTrnJurnaldetil_Credit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ftabDataDetil_Response.ResumeLayout(False)
        CType(Me.DgvTrnJurnalResponse, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ftabDataDetil_Info.ResumeLayout(False)
        Me.ftabDataDetil_Info.PerformLayout()
        Me.PnlDataMaster.ResumeLayout(False)
        Me.PnlDataMaster.PerformLayout()
        Me.PnlDataFooter.ResumeLayout(False)
        Me.PnlDataFooterFR.ResumeLayout(False)
        Me.PnlDataFooterFR.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ftabMain As FlatTabControl.FlatTabControl
    Friend WithEvents ftabMain_List As System.Windows.Forms.TabPage
    Friend WithEvents ftabMain_Data As System.Windows.Forms.TabPage
    Friend WithEvents PnlDfSearch As System.Windows.Forms.Panel
    Friend WithEvents PnlDfMain As System.Windows.Forms.Panel
    Friend WithEvents PnlDfFooter As System.Windows.Forms.Panel
    Friend WithEvents PnlDataMaster As System.Windows.Forms.Panel
    Friend WithEvents PnlDataFooter As System.Windows.Forms.Panel
    Friend WithEvents fTabDataDetil As FlatTabControl.FlatTabControl
    Friend WithEvents ftabDataDetil_Debit As System.Windows.Forms.TabPage
    Friend WithEvents chkSearchChannel As System.Windows.Forms.CheckBox
    Friend WithEvents cboSearchChannel As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_Jurnal_id As System.Windows.Forms.Label
    Friend WithEvents obj_Jurnal_id As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Jurnal_bookdate As System.Windows.Forms.Label
    Friend WithEvents lbl_Jurnal_duedate As System.Windows.Forms.Label
    Friend WithEvents lbl_Jurnal_billdate As System.Windows.Forms.Label
    Friend WithEvents lbl_Jurnal_descr As System.Windows.Forms.Label
    Friend WithEvents obj_Jurnal_descr As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Jurnal_invoice_id As System.Windows.Forms.Label
    Friend WithEvents obj_Jurnal_invoice_id As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Jurnal_invoice_descr As System.Windows.Forms.Label
    Friend WithEvents obj_Jurnal_invoice_descr As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Jurnal_source As System.Windows.Forms.Label
    Friend WithEvents obj_Jurnal_source As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Jurnaltype_id As System.Windows.Forms.Label
    Friend WithEvents obj_Jurnaltype_id As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Rekanan_id As System.Windows.Forms.Label
    Friend WithEvents lbl_Periode_id As System.Windows.Forms.Label
    Friend WithEvents lbl_Channel_id As System.Windows.Forms.Label
    Friend WithEvents lbl_Budget_id As System.Windows.Forms.Label
    Friend WithEvents lbl_Currency_id As System.Windows.Forms.Label
    Friend WithEvents lbl_Currency_rate As System.Windows.Forms.Label
    Friend WithEvents obj_Currency_rate As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Strukturunit_id As System.Windows.Forms.Label
    Friend WithEvents obj_Strukturunit_id As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Acc_ca_id As System.Windows.Forms.Label
    Friend WithEvents lbl_Region_id As System.Windows.Forms.Label
    Friend WithEvents obj_Region_id As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Branch_id As System.Windows.Forms.Label
    Friend WithEvents obj_Branch_id As System.Windows.Forms.TextBox
    Friend WithEvents obj_Jurnal_iscreated As System.Windows.Forms.CheckBox
    Friend WithEvents lbl_Jurnal_iscreatedby As System.Windows.Forms.Label
    Friend WithEvents obj_Jurnal_iscreatedby As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Jurnal_iscreatedate As System.Windows.Forms.Label
    Friend WithEvents obj_Jurnal_iscreatedate As System.Windows.Forms.TextBox
    Friend WithEvents obj_Jurnal_isposted As System.Windows.Forms.CheckBox
    Friend WithEvents lbl_Jurnal_ispostedby As System.Windows.Forms.Label
    Friend WithEvents obj_Jurnal_ispostedby As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Jurnal_isposteddate As System.Windows.Forms.Label
    Friend WithEvents obj_Jurnal_isposteddate As System.Windows.Forms.TextBox
    Friend WithEvents obj_Jurnal_isdisabled As System.Windows.Forms.CheckBox
    Friend WithEvents lbl_Jurnal_isdisabledby As System.Windows.Forms.Label
    Friend WithEvents obj_Jurnal_isdisabledby As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Jurnal_isdisableddt As System.Windows.Forms.Label
    Friend WithEvents obj_Jurnal_isdisableddt As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Created_by As System.Windows.Forms.Label
    Friend WithEvents obj_Created_by As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Created_dt As System.Windows.Forms.Label
    Friend WithEvents obj_Created_dt As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Modified_by As System.Windows.Forms.Label
    Friend WithEvents obj_Modified_by As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Modified_dt As System.Windows.Forms.Label
    Friend WithEvents obj_Modified_dt As System.Windows.Forms.TextBox
    Friend WithEvents cbo_periodeSearch As System.Windows.Forms.ComboBox
    Friend WithEvents cbo_createBySearch As System.Windows.Forms.ComboBox
    Friend WithEvents btn_Rekanan As System.Windows.Forms.Button
    Friend WithEvents txtSearchRekananID As System.Windows.Forms.TextBox
    Friend WithEvents chkSearchRekanan As System.Windows.Forms.CheckBox
    Friend WithEvents chkSearchPeriode As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtSearchSource As System.Windows.Forms.TextBox
    Friend WithEvents chkSearchSource As System.Windows.Forms.CheckBox
    Friend WithEvents lnkQueryBuilder As System.Windows.Forms.LinkLabel
    Friend WithEvents txtSearchAdv As System.Windows.Forms.TextBox
    Friend WithEvents lnkClear As System.Windows.Forms.LinkLabel
    Friend WithEvents chkSearchAdv As System.Windows.Forms.CheckBox
    Friend WithEvents chkSearchCreateBy As System.Windows.Forms.CheckBox
    Friend WithEvents txtSearchJurnalID As System.Windows.Forms.TextBox
    Friend WithEvents chkSearchJurnalID As System.Windows.Forms.CheckBox
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblLoading As System.Windows.Forms.Label
    Friend WithEvents obj_ProgressBar_backGroundWorker As System.Windows.Forms.ProgressBar
    Friend WithEvents txtLimit As System.Windows.Forms.TextBox
    Friend WithEvents chkLimit As System.Windows.Forms.CheckBox
    Friend WithEvents obj_Jurnal_billdate As System.Windows.Forms.DateTimePicker
    Friend WithEvents ftabDataDetil_Credit As System.Windows.Forms.TabPage
    Friend WithEvents ftabDataDetil_Response As System.Windows.Forms.TabPage
    Friend WithEvents ftabDataDetil_Info As System.Windows.Forms.TabPage
    Friend WithEvents obj_Channel_id As System.Windows.Forms.ComboBox
    Friend WithEvents obj_Periode_id As System.Windows.Forms.ComboBox
    Friend WithEvents obj_Rekanan_id As System.Windows.Forms.ComboBox
    Friend WithEvents obj_Currency_id As System.Windows.Forms.ComboBox
    Friend WithEvents obj_Jurnal_bookdate As System.Windows.Forms.DateTimePicker
    Friend WithEvents obj_Jurnal_duedate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents PnlDataFooterFR As System.Windows.Forms.Panel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents obj_Selisih_Foreign As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents obj_Jumlah_Foreign As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Selisih As System.Windows.Forms.Label
    Friend WithEvents obj_Selisih As System.Windows.Forms.TextBox
    Friend WithEvents obj_Jumlah As System.Windows.Forms.TextBox
    Friend WithEvents DgvTrnJurnalResponse As System.Windows.Forms.DataGridView
    Friend WithEvents DgvTrnJurnal As System.Windows.Forms.DataGridView
    Friend WithEvents DgvTrnJurnaldetil_Debit As System.Windows.Forms.DataGridView
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents DgvTrnJurnaldetil_Credit As System.Windows.Forms.DataGridView
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents obj_amountCredit As System.Windows.Forms.TextBox
    Friend WithEvents obj_amountCreditIdr As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents obj_amountDebit As System.Windows.Forms.TextBox
    Friend WithEvents obj_amountDebitIdr As System.Windows.Forms.TextBox
    Friend WithEvents obj_Acc_ca_id As System.Windows.Forms.ComboBox
    Friend WithEvents btn_Budget_Header As System.Windows.Forms.Button
    Friend WithEvents obj_Budget_name As System.Windows.Forms.TextBox
    Friend WithEvents obj_Budget_id As System.Windows.Forms.TextBox
    Friend WithEvents btnUpload As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents btnTemplateXLS As System.Windows.Forms.Button

End Class
