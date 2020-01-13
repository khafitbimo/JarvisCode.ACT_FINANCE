<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class uiTrnCirculationVoucher
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
        Me.components = New System.ComponentModel.Container
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(uiTrnCirculationVoucher))
        Me.ftabMain = New FlatTabControl.FlatTabControl
        Me.ftabMain_List = New System.Windows.Forms.TabPage
        Me.PnlDfMain = New System.Windows.Forms.Panel
        Me.DgvTrnCirculationvoucher = New System.Windows.Forms.DataGridView
        Me.PnlDfFooter = New System.Windows.Forms.Panel
        Me.PnlDfSearch = New System.Windows.Forms.Panel
        Me.cmbSearchAppUser = New System.Windows.Forms.ComboBox
        Me.cmbSearchCreateBy = New System.Windows.Forms.ComboBox
        Me.chkSearchAppUser = New System.Windows.Forms.CheckBox
        Me.chkSearchCreateBy = New System.Windows.Forms.CheckBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtSearchJurnalID = New System.Windows.Forms.TextBox
        Me.chkSearchJurnalID = New System.Windows.Forms.CheckBox
        Me.cboSearchChannel = New System.Windows.Forms.ComboBox
        Me.chkSearchChannel = New System.Windows.Forms.CheckBox
        Me.ftabMain_Data = New System.Windows.Forms.TabPage
        Me.ftabDataDetil = New FlatTabControl.FlatTabControl
        Me.ftabDataDetil_Detil = New System.Windows.Forms.TabPage
        Me.DgvTrnCirculationvoucherdetil = New System.Windows.Forms.DataGridView
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.btn_CheckAllAppDir = New System.Windows.Forms.ToolStripMenuItem
        Me.btn_UnCheckAllAppDir = New System.Windows.Forms.ToolStripMenuItem
        Me.btn_Refresh = New System.Windows.Forms.ToolStripMenuItem
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.btn_List = New System.Windows.Forms.Button
        Me.obj_Circulation_foreign = New System.Windows.Forms.TextBox
        Me.lbl_Circulation_foreign = New System.Windows.Forms.Label
        Me.obj_Circulation_amount = New System.Windows.Forms.TextBox
        Me.lbl_Circulation_amount = New System.Windows.Forms.Label
        Me.ftabDataDetil_Info = New System.Windows.Forms.TabPage
        Me.obj_Circulation_appuserdt = New System.Windows.Forms.TextBox
        Me.lbl_Circulation_appuserdt = New System.Windows.Forms.Label
        Me.lbl_Circulation_appuserby = New System.Windows.Forms.Label
        Me.obj_Circulation_appuserby = New System.Windows.Forms.TextBox
        Me.obj_Modified_dt = New System.Windows.Forms.TextBox
        Me.lbl_Modified_dt = New System.Windows.Forms.Label
        Me.lbl_Modified_by = New System.Windows.Forms.Label
        Me.obj_Modified_by = New System.Windows.Forms.TextBox
        Me.lbl_Entry_dt = New System.Windows.Forms.Label
        Me.obj_Entry_dt = New System.Windows.Forms.TextBox
        Me.lbl_Entry_by = New System.Windows.Forms.Label
        Me.obj_Entry_by = New System.Windows.Forms.TextBox
        Me.PnlDataMaster = New System.Windows.Forms.Panel
        Me.obj_Circulation_senddt = New System.Windows.Forms.DateTimePicker
        Me.obj_Circulation_sendto = New System.Windows.Forms.ComboBox
        Me.pnlLoading = New System.Windows.Forms.Panel
        Me.lblProgress = New System.Windows.Forms.Label
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.obj_Circulation_id = New System.Windows.Forms.TextBox
        Me.lbl_Circulation_id = New System.Windows.Forms.Label
        Me.obj_Circulation_appuser = New System.Windows.Forms.CheckBox
        Me.lbl_Circulation_senddt = New System.Windows.Forms.Label
        Me.lbl_Circulation_sendto = New System.Windows.Forms.Label
        Me.obj_Circulation_descr = New System.Windows.Forms.TextBox
        Me.lbl_Circulation_descr = New System.Windows.Forms.Label
        Me.obj_Jurnaltype_id = New System.Windows.Forms.TextBox
        Me.lbl_Jurnaltype_id = New System.Windows.Forms.Label
        Me.obj_Channel_id = New System.Windows.Forms.TextBox
        Me.lbl_Channel_id = New System.Windows.Forms.Label
        Me.obj_Circulation_status = New System.Windows.Forms.TextBox
        Me.lbl_Circulation_status = New System.Windows.Forms.Label
        Me.obj_Circulation_totalrevisi = New System.Windows.Forms.TextBox
        Me.lbl_Circulation_totalrevisi = New System.Windows.Forms.Label
        Me.PnlDataFooter = New System.Windows.Forms.Panel
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.lblLoading = New System.Windows.Forms.Label
        Me.obj_ProgressBar_backGroundWorker = New System.Windows.Forms.ProgressBar
        CType(Me.tbl_MstSetting, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ftabMain.SuspendLayout()
        Me.ftabMain_List.SuspendLayout()
        Me.PnlDfMain.SuspendLayout()
        CType(Me.DgvTrnCirculationvoucher, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlDfSearch.SuspendLayout()
        Me.ftabMain_Data.SuspendLayout()
        Me.ftabDataDetil.SuspendLayout()
        Me.ftabDataDetil_Detil.SuspendLayout()
        CType(Me.DgvTrnCirculationvoucherdetil, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.ftabDataDetil_Info.SuspendLayout()
        Me.PnlDataMaster.SuspendLayout()
        Me.pnlLoading.SuspendLayout()
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
        Me.ftabMain_List.BackColor = System.Drawing.Color.LavenderBlush
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
        Me.PnlDfMain.Controls.Add(Me.DgvTrnCirculationvoucher)
        Me.PnlDfMain.Location = New System.Drawing.Point(20, 131)
        Me.PnlDfMain.Name = "PnlDfMain"
        Me.PnlDfMain.Size = New System.Drawing.Size(704, 296)
        Me.PnlDfMain.TabIndex = 1
        '
        'DgvTrnCirculationvoucher
        '
        Me.DgvTrnCirculationvoucher.BackgroundColor = System.Drawing.Color.LavenderBlush
        Me.DgvTrnCirculationvoucher.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Comic Sans MS", 8.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Pink
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvTrnCirculationvoucher.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DgvTrnCirculationvoucher.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvTrnCirculationvoucher.Cursor = System.Windows.Forms.Cursors.Hand
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Comic Sans MS", 8.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Pink
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgvTrnCirculationvoucher.DefaultCellStyle = DataGridViewCellStyle2
        Me.DgvTrnCirculationvoucher.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvTrnCirculationvoucher.GridColor = System.Drawing.Color.Moccasin
        Me.DgvTrnCirculationvoucher.Location = New System.Drawing.Point(0, 0)
        Me.DgvTrnCirculationvoucher.Name = "DgvTrnCirculationvoucher"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Comic Sans MS", 8.0!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Pink
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvTrnCirculationvoucher.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DgvTrnCirculationvoucher.Size = New System.Drawing.Size(704, 296)
        Me.DgvTrnCirculationvoucher.TabIndex = 7
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
        Me.PnlDfSearch.BackColor = System.Drawing.Color.LavenderBlush
        Me.PnlDfSearch.Controls.Add(Me.cmbSearchAppUser)
        Me.PnlDfSearch.Controls.Add(Me.cmbSearchCreateBy)
        Me.PnlDfSearch.Controls.Add(Me.chkSearchAppUser)
        Me.PnlDfSearch.Controls.Add(Me.chkSearchCreateBy)
        Me.PnlDfSearch.Controls.Add(Me.Label3)
        Me.PnlDfSearch.Controls.Add(Me.txtSearchJurnalID)
        Me.PnlDfSearch.Controls.Add(Me.chkSearchJurnalID)
        Me.PnlDfSearch.Controls.Add(Me.cboSearchChannel)
        Me.PnlDfSearch.Controls.Add(Me.chkSearchChannel)
        Me.PnlDfSearch.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlDfSearch.Location = New System.Drawing.Point(3, 3)
        Me.PnlDfSearch.Name = "PnlDfSearch"
        Me.PnlDfSearch.Size = New System.Drawing.Size(733, 122)
        Me.PnlDfSearch.TabIndex = 0
        '
        'cmbSearchAppUser
        '
        Me.cmbSearchAppUser.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbSearchAppUser.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbSearchAppUser.BackColor = System.Drawing.Color.Lavender
        Me.cmbSearchAppUser.FormattingEnabled = True
        Me.cmbSearchAppUser.Location = New System.Drawing.Point(504, 38)
        Me.cmbSearchAppUser.Name = "cmbSearchAppUser"
        Me.cmbSearchAppUser.Size = New System.Drawing.Size(176, 21)
        Me.cmbSearchAppUser.TabIndex = 231
        '
        'cmbSearchCreateBy
        '
        Me.cmbSearchCreateBy.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbSearchCreateBy.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbSearchCreateBy.BackColor = System.Drawing.Color.Lavender
        Me.cmbSearchCreateBy.FormattingEnabled = True
        Me.cmbSearchCreateBy.Location = New System.Drawing.Point(504, 13)
        Me.cmbSearchCreateBy.Name = "cmbSearchCreateBy"
        Me.cmbSearchCreateBy.Size = New System.Drawing.Size(176, 21)
        Me.cmbSearchCreateBy.TabIndex = 230
        '
        'chkSearchAppUser
        '
        Me.chkSearchAppUser.AutoSize = True
        Me.chkSearchAppUser.Location = New System.Drawing.Point(417, 40)
        Me.chkSearchAppUser.Name = "chkSearchAppUser"
        Me.chkSearchAppUser.Size = New System.Drawing.Size(73, 17)
        Me.chkSearchAppUser.TabIndex = 207
        Me.chkSearchAppUser.Text = "App. User"
        Me.chkSearchAppUser.UseVisualStyleBackColor = True
        '
        'chkSearchCreateBy
        '
        Me.chkSearchCreateBy.AutoSize = True
        Me.chkSearchCreateBy.Location = New System.Drawing.Point(417, 15)
        Me.chkSearchCreateBy.Name = "chkSearchCreateBy"
        Me.chkSearchCreateBy.Size = New System.Drawing.Size(72, 17)
        Me.chkSearchCreateBy.TabIndex = 205
        Me.chkSearchCreateBy.Text = "Create By"
        Me.chkSearchCreateBy.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(102, 106)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(263, 12)
        Me.Label3.TabIndex = 37
        Me.Label3.Text = "Use semicolone (;) to enter more than one references in textbox"
        '
        'txtSearchJurnalID
        '
        Me.txtSearchJurnalID.Location = New System.Drawing.Point(104, 40)
        Me.txtSearchJurnalID.Multiline = True
        Me.txtSearchJurnalID.Name = "txtSearchJurnalID"
        Me.txtSearchJurnalID.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtSearchJurnalID.Size = New System.Drawing.Size(261, 64)
        Me.txtSearchJurnalID.TabIndex = 36
        '
        'chkSearchJurnalID
        '
        Me.chkSearchJurnalID.AutoSize = True
        Me.chkSearchJurnalID.Location = New System.Drawing.Point(17, 40)
        Me.chkSearchJurnalID.Name = "chkSearchJurnalID"
        Me.chkSearchJurnalID.Size = New System.Drawing.Size(48, 17)
        Me.chkSearchJurnalID.TabIndex = 35
        Me.chkSearchJurnalID.Text = "ID(s)"
        Me.chkSearchJurnalID.UseVisualStyleBackColor = True
        '
        'cboSearchChannel
        '
        Me.cboSearchChannel.FormattingEnabled = True
        Me.cboSearchChannel.Location = New System.Drawing.Point(104, 13)
        Me.cboSearchChannel.Name = "cboSearchChannel"
        Me.cboSearchChannel.Size = New System.Drawing.Size(121, 21)
        Me.cboSearchChannel.TabIndex = 1
        '
        'chkSearchChannel
        '
        Me.chkSearchChannel.AutoSize = True
        Me.chkSearchChannel.Location = New System.Drawing.Point(17, 15)
        Me.chkSearchChannel.Name = "chkSearchChannel"
        Me.chkSearchChannel.Size = New System.Drawing.Size(65, 17)
        Me.chkSearchChannel.TabIndex = 0
        Me.chkSearchChannel.Text = "Channel"
        Me.chkSearchChannel.UseVisualStyleBackColor = True
        '
        'ftabMain_Data
        '
        Me.ftabMain_Data.BackColor = System.Drawing.Color.White
        Me.ftabMain_Data.Controls.Add(Me.ftabDataDetil)
        Me.ftabMain_Data.Controls.Add(Me.PnlDataMaster)
        Me.ftabMain_Data.Controls.Add(Me.PnlDataFooter)
        Me.ftabMain_Data.Location = New System.Drawing.Point(4, 25)
        Me.ftabMain_Data.Name = "ftabMain_Data"
        Me.ftabMain_Data.Padding = New System.Windows.Forms.Padding(3)
        Me.ftabMain_Data.Size = New System.Drawing.Size(739, 488)
        Me.ftabMain_Data.TabIndex = 1
        Me.ftabMain_Data.Text = "Data"
        '
        'ftabDataDetil
        '
        Me.ftabDataDetil.Controls.Add(Me.ftabDataDetil_Detil)
        Me.ftabDataDetil.Controls.Add(Me.ftabDataDetil_Info)
        Me.ftabDataDetil.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ftabDataDetil.Location = New System.Drawing.Point(3, 172)
        Me.ftabDataDetil.myBackColor = System.Drawing.Color.LavenderBlush
        Me.ftabDataDetil.Name = "ftabDataDetil"
        Me.ftabDataDetil.SelectedIndex = 0
        Me.ftabDataDetil.Size = New System.Drawing.Size(733, 286)
        Me.ftabDataDetil.TabIndex = 3
        '
        'ftabDataDetil_Detil
        '
        Me.ftabDataDetil_Detil.BackColor = System.Drawing.Color.White
        Me.ftabDataDetil_Detil.Controls.Add(Me.DgvTrnCirculationvoucherdetil)
        Me.ftabDataDetil_Detil.Controls.Add(Me.Panel1)
        Me.ftabDataDetil_Detil.Location = New System.Drawing.Point(4, 25)
        Me.ftabDataDetil_Detil.Name = "ftabDataDetil_Detil"
        Me.ftabDataDetil_Detil.Padding = New System.Windows.Forms.Padding(3)
        Me.ftabDataDetil_Detil.Size = New System.Drawing.Size(725, 257)
        Me.ftabDataDetil_Detil.TabIndex = 0
        Me.ftabDataDetil_Detil.Text = "Detil"
        '
        'DgvTrnCirculationvoucherdetil
        '
        Me.DgvTrnCirculationvoucherdetil.BackgroundColor = System.Drawing.Color.LavenderBlush
        Me.DgvTrnCirculationvoucherdetil.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Comic Sans MS", 8.0!)
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Pink
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvTrnCirculationvoucherdetil.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.DgvTrnCirculationvoucherdetil.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvTrnCirculationvoucherdetil.ContextMenuStrip = Me.ContextMenuStrip1
        Me.DgvTrnCirculationvoucherdetil.Cursor = System.Windows.Forms.Cursors.Hand
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Comic Sans MS", 8.0!)
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Pink
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgvTrnCirculationvoucherdetil.DefaultCellStyle = DataGridViewCellStyle5
        Me.DgvTrnCirculationvoucherdetil.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvTrnCirculationvoucherdetil.GridColor = System.Drawing.Color.Moccasin
        Me.DgvTrnCirculationvoucherdetil.Location = New System.Drawing.Point(3, 3)
        Me.DgvTrnCirculationvoucherdetil.Name = "DgvTrnCirculationvoucherdetil"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Comic Sans MS", 8.0!)
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Pink
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvTrnCirculationvoucherdetil.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.DgvTrnCirculationvoucherdetil.Size = New System.Drawing.Size(719, 214)
        Me.DgvTrnCirculationvoucherdetil.TabIndex = 8
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btn_CheckAllAppDir, Me.btn_UnCheckAllAppDir, Me.btn_Refresh})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(192, 70)
        '
        'btn_CheckAllAppDir
        '
        Me.btn_CheckAllAppDir.Name = "btn_CheckAllAppDir"
        Me.btn_CheckAllAppDir.Size = New System.Drawing.Size(191, 22)
        Me.btn_CheckAllAppDir.Text = "Check All (App. Dir)"
        '
        'btn_UnCheckAllAppDir
        '
        Me.btn_UnCheckAllAppDir.Name = "btn_UnCheckAllAppDir"
        Me.btn_UnCheckAllAppDir.Size = New System.Drawing.Size(191, 22)
        Me.btn_UnCheckAllAppDir.Text = "UnCheck All (App. Dir)"
        '
        'btn_Refresh
        '
        Me.btn_Refresh.Name = "btn_Refresh"
        Me.btn_Refresh.Size = New System.Drawing.Size(191, 22)
        Me.btn_Refresh.Text = "Refresh"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LavenderBlush
        Me.Panel1.Controls.Add(Me.btn_List)
        Me.Panel1.Controls.Add(Me.obj_Circulation_foreign)
        Me.Panel1.Controls.Add(Me.lbl_Circulation_foreign)
        Me.Panel1.Controls.Add(Me.obj_Circulation_amount)
        Me.Panel1.Controls.Add(Me.lbl_Circulation_amount)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(3, 217)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(719, 37)
        Me.Panel1.TabIndex = 3
        '
        'btn_List
        '
        Me.btn_List.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_List.BackColor = System.Drawing.Color.Moccasin
        Me.btn_List.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn_List.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_List.ForeColor = System.Drawing.Color.Black
        Me.btn_List.Location = New System.Drawing.Point(3, 4)
        Me.btn_List.Name = "btn_List"
        Me.btn_List.Size = New System.Drawing.Size(64, 30)
        Me.btn_List.TabIndex = 67
        Me.btn_List.Text = "+(Row)"
        Me.btn_List.UseVisualStyleBackColor = False
        '
        'obj_Circulation_foreign
        '
        Me.obj_Circulation_foreign.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.obj_Circulation_foreign.BackColor = System.Drawing.SystemColors.Info
        Me.obj_Circulation_foreign.Location = New System.Drawing.Point(375, 10)
        Me.obj_Circulation_foreign.Name = "obj_Circulation_foreign"
        Me.obj_Circulation_foreign.ReadOnly = True
        Me.obj_Circulation_foreign.Size = New System.Drawing.Size(118, 20)
        Me.obj_Circulation_foreign.TabIndex = 1
        Me.obj_Circulation_foreign.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbl_Circulation_foreign
        '
        Me.lbl_Circulation_foreign.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_Circulation_foreign.AutoSize = True
        Me.lbl_Circulation_foreign.Location = New System.Drawing.Point(326, 13)
        Me.lbl_Circulation_foreign.Name = "lbl_Circulation_foreign"
        Me.lbl_Circulation_foreign.Size = New System.Drawing.Size(43, 13)
        Me.lbl_Circulation_foreign.TabIndex = 0
        Me.lbl_Circulation_foreign.Text = "Amount"
        '
        'obj_Circulation_amount
        '
        Me.obj_Circulation_amount.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.obj_Circulation_amount.BackColor = System.Drawing.SystemColors.Info
        Me.obj_Circulation_amount.Location = New System.Drawing.Point(569, 10)
        Me.obj_Circulation_amount.Name = "obj_Circulation_amount"
        Me.obj_Circulation_amount.ReadOnly = True
        Me.obj_Circulation_amount.Size = New System.Drawing.Size(141, 20)
        Me.obj_Circulation_amount.TabIndex = 1
        Me.obj_Circulation_amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbl_Circulation_amount
        '
        Me.lbl_Circulation_amount.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_Circulation_amount.AutoSize = True
        Me.lbl_Circulation_amount.Location = New System.Drawing.Point(498, 13)
        Me.lbl_Circulation_amount.Name = "lbl_Circulation_amount"
        Me.lbl_Circulation_amount.Size = New System.Drawing.Size(65, 13)
        Me.lbl_Circulation_amount.TabIndex = 0
        Me.lbl_Circulation_amount.Text = "Amount IDR"
        '
        'ftabDataDetil_Info
        '
        Me.ftabDataDetil_Info.BackColor = System.Drawing.Color.LavenderBlush
        Me.ftabDataDetil_Info.Controls.Add(Me.obj_Circulation_appuserdt)
        Me.ftabDataDetil_Info.Controls.Add(Me.lbl_Circulation_appuserdt)
        Me.ftabDataDetil_Info.Controls.Add(Me.lbl_Circulation_appuserby)
        Me.ftabDataDetil_Info.Controls.Add(Me.obj_Circulation_appuserby)
        Me.ftabDataDetil_Info.Controls.Add(Me.obj_Modified_dt)
        Me.ftabDataDetil_Info.Controls.Add(Me.lbl_Modified_dt)
        Me.ftabDataDetil_Info.Controls.Add(Me.lbl_Modified_by)
        Me.ftabDataDetil_Info.Controls.Add(Me.obj_Modified_by)
        Me.ftabDataDetil_Info.Controls.Add(Me.lbl_Entry_dt)
        Me.ftabDataDetil_Info.Controls.Add(Me.obj_Entry_dt)
        Me.ftabDataDetil_Info.Controls.Add(Me.lbl_Entry_by)
        Me.ftabDataDetil_Info.Controls.Add(Me.obj_Entry_by)
        Me.ftabDataDetil_Info.Location = New System.Drawing.Point(4, 25)
        Me.ftabDataDetil_Info.Name = "ftabDataDetil_Info"
        Me.ftabDataDetil_Info.Size = New System.Drawing.Size(178, 0)
        Me.ftabDataDetil_Info.TabIndex = 1
        Me.ftabDataDetil_Info.Text = "Info"
        '
        'obj_Circulation_appuserdt
        '
        Me.obj_Circulation_appuserdt.BackColor = System.Drawing.SystemColors.Info
        Me.obj_Circulation_appuserdt.Location = New System.Drawing.Point(106, 124)
        Me.obj_Circulation_appuserdt.Name = "obj_Circulation_appuserdt"
        Me.obj_Circulation_appuserdt.ReadOnly = True
        Me.obj_Circulation_appuserdt.Size = New System.Drawing.Size(151, 20)
        Me.obj_Circulation_appuserdt.TabIndex = 1
        '
        'lbl_Circulation_appuserdt
        '
        Me.lbl_Circulation_appuserdt.AutoSize = True
        Me.lbl_Circulation_appuserdt.Location = New System.Drawing.Point(17, 127)
        Me.lbl_Circulation_appuserdt.Name = "lbl_Circulation_appuserdt"
        Me.lbl_Circulation_appuserdt.Size = New System.Drawing.Size(80, 13)
        Me.lbl_Circulation_appuserdt.TabIndex = 0
        Me.lbl_Circulation_appuserdt.Text = "App. User Date"
        '
        'lbl_Circulation_appuserby
        '
        Me.lbl_Circulation_appuserby.AutoSize = True
        Me.lbl_Circulation_appuserby.Location = New System.Drawing.Point(17, 105)
        Me.lbl_Circulation_appuserby.Name = "lbl_Circulation_appuserby"
        Me.lbl_Circulation_appuserby.Size = New System.Drawing.Size(69, 13)
        Me.lbl_Circulation_appuserby.TabIndex = 0
        Me.lbl_Circulation_appuserby.Text = "App. User By"
        '
        'obj_Circulation_appuserby
        '
        Me.obj_Circulation_appuserby.BackColor = System.Drawing.SystemColors.Info
        Me.obj_Circulation_appuserby.Location = New System.Drawing.Point(106, 102)
        Me.obj_Circulation_appuserby.Name = "obj_Circulation_appuserby"
        Me.obj_Circulation_appuserby.ReadOnly = True
        Me.obj_Circulation_appuserby.Size = New System.Drawing.Size(151, 20)
        Me.obj_Circulation_appuserby.TabIndex = 1
        '
        'obj_Modified_dt
        '
        Me.obj_Modified_dt.BackColor = System.Drawing.SystemColors.Info
        Me.obj_Modified_dt.Location = New System.Drawing.Point(106, 80)
        Me.obj_Modified_dt.Name = "obj_Modified_dt"
        Me.obj_Modified_dt.ReadOnly = True
        Me.obj_Modified_dt.Size = New System.Drawing.Size(151, 20)
        Me.obj_Modified_dt.TabIndex = 1
        '
        'lbl_Modified_dt
        '
        Me.lbl_Modified_dt.AutoSize = True
        Me.lbl_Modified_dt.Location = New System.Drawing.Point(17, 83)
        Me.lbl_Modified_dt.Name = "lbl_Modified_dt"
        Me.lbl_Modified_dt.Size = New System.Drawing.Size(73, 13)
        Me.lbl_Modified_dt.TabIndex = 0
        Me.lbl_Modified_dt.Text = "Modified Date"
        '
        'lbl_Modified_by
        '
        Me.lbl_Modified_by.AutoSize = True
        Me.lbl_Modified_by.Location = New System.Drawing.Point(17, 61)
        Me.lbl_Modified_by.Name = "lbl_Modified_by"
        Me.lbl_Modified_by.Size = New System.Drawing.Size(62, 13)
        Me.lbl_Modified_by.TabIndex = 0
        Me.lbl_Modified_by.Text = "Modified By"
        '
        'obj_Modified_by
        '
        Me.obj_Modified_by.BackColor = System.Drawing.SystemColors.Info
        Me.obj_Modified_by.Location = New System.Drawing.Point(106, 58)
        Me.obj_Modified_by.Name = "obj_Modified_by"
        Me.obj_Modified_by.ReadOnly = True
        Me.obj_Modified_by.Size = New System.Drawing.Size(151, 20)
        Me.obj_Modified_by.TabIndex = 1
        '
        'lbl_Entry_dt
        '
        Me.lbl_Entry_dt.AutoSize = True
        Me.lbl_Entry_dt.Location = New System.Drawing.Point(17, 39)
        Me.lbl_Entry_dt.Name = "lbl_Entry_dt"
        Me.lbl_Entry_dt.Size = New System.Drawing.Size(57, 13)
        Me.lbl_Entry_dt.TabIndex = 0
        Me.lbl_Entry_dt.Text = "Entry Date"
        '
        'obj_Entry_dt
        '
        Me.obj_Entry_dt.BackColor = System.Drawing.SystemColors.Info
        Me.obj_Entry_dt.Location = New System.Drawing.Point(106, 36)
        Me.obj_Entry_dt.Name = "obj_Entry_dt"
        Me.obj_Entry_dt.ReadOnly = True
        Me.obj_Entry_dt.Size = New System.Drawing.Size(151, 20)
        Me.obj_Entry_dt.TabIndex = 1
        '
        'lbl_Entry_by
        '
        Me.lbl_Entry_by.AutoSize = True
        Me.lbl_Entry_by.Location = New System.Drawing.Point(17, 17)
        Me.lbl_Entry_by.Name = "lbl_Entry_by"
        Me.lbl_Entry_by.Size = New System.Drawing.Size(46, 13)
        Me.lbl_Entry_by.TabIndex = 0
        Me.lbl_Entry_by.Text = "Entry By"
        '
        'obj_Entry_by
        '
        Me.obj_Entry_by.BackColor = System.Drawing.SystemColors.Info
        Me.obj_Entry_by.Location = New System.Drawing.Point(106, 14)
        Me.obj_Entry_by.Name = "obj_Entry_by"
        Me.obj_Entry_by.ReadOnly = True
        Me.obj_Entry_by.Size = New System.Drawing.Size(151, 20)
        Me.obj_Entry_by.TabIndex = 1
        '
        'PnlDataMaster
        '
        Me.PnlDataMaster.AutoScroll = True
        Me.PnlDataMaster.BackColor = System.Drawing.Color.LavenderBlush
        Me.PnlDataMaster.Controls.Add(Me.obj_Circulation_senddt)
        Me.PnlDataMaster.Controls.Add(Me.obj_Circulation_sendto)
        Me.PnlDataMaster.Controls.Add(Me.pnlLoading)
        Me.PnlDataMaster.Controls.Add(Me.obj_Circulation_id)
        Me.PnlDataMaster.Controls.Add(Me.lbl_Circulation_id)
        Me.PnlDataMaster.Controls.Add(Me.obj_Circulation_appuser)
        Me.PnlDataMaster.Controls.Add(Me.lbl_Circulation_senddt)
        Me.PnlDataMaster.Controls.Add(Me.lbl_Circulation_sendto)
        Me.PnlDataMaster.Controls.Add(Me.obj_Circulation_descr)
        Me.PnlDataMaster.Controls.Add(Me.lbl_Circulation_descr)
        Me.PnlDataMaster.Controls.Add(Me.obj_Jurnaltype_id)
        Me.PnlDataMaster.Controls.Add(Me.lbl_Jurnaltype_id)
        Me.PnlDataMaster.Controls.Add(Me.obj_Channel_id)
        Me.PnlDataMaster.Controls.Add(Me.lbl_Channel_id)
        Me.PnlDataMaster.Controls.Add(Me.obj_Circulation_status)
        Me.PnlDataMaster.Controls.Add(Me.lbl_Circulation_status)
        Me.PnlDataMaster.Controls.Add(Me.obj_Circulation_totalrevisi)
        Me.PnlDataMaster.Controls.Add(Me.lbl_Circulation_totalrevisi)
        Me.PnlDataMaster.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlDataMaster.Location = New System.Drawing.Point(3, 3)
        Me.PnlDataMaster.Name = "PnlDataMaster"
        Me.PnlDataMaster.Size = New System.Drawing.Size(733, 169)
        Me.PnlDataMaster.TabIndex = 0
        '
        'obj_Circulation_senddt
        '
        Me.obj_Circulation_senddt.CalendarForeColor = System.Drawing.Color.Black
        Me.obj_Circulation_senddt.CalendarMonthBackground = System.Drawing.Color.White
        Me.obj_Circulation_senddt.CalendarTitleBackColor = System.Drawing.Color.Thistle
        Me.obj_Circulation_senddt.CalendarTitleForeColor = System.Drawing.Color.Black
        Me.obj_Circulation_senddt.CalendarTrailingForeColor = System.Drawing.Color.Gray
        Me.obj_Circulation_senddt.CustomFormat = "dd/MM/yyyy"
        Me.obj_Circulation_senddt.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.obj_Circulation_senddt.Location = New System.Drawing.Point(96, 47)
        Me.obj_Circulation_senddt.Name = "obj_Circulation_senddt"
        Me.obj_Circulation_senddt.Size = New System.Drawing.Size(125, 20)
        Me.obj_Circulation_senddt.TabIndex = 232
        '
        'obj_Circulation_sendto
        '
        Me.obj_Circulation_sendto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.obj_Circulation_sendto.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.obj_Circulation_sendto.BackColor = System.Drawing.Color.Lavender
        Me.obj_Circulation_sendto.FormattingEnabled = True
        Me.obj_Circulation_sendto.Location = New System.Drawing.Point(96, 72)
        Me.obj_Circulation_sendto.Name = "obj_Circulation_sendto"
        Me.obj_Circulation_sendto.Size = New System.Drawing.Size(189, 21)
        Me.obj_Circulation_sendto.TabIndex = 231
        '
        'pnlLoading
        '
        Me.pnlLoading.BackColor = System.Drawing.Color.Moccasin
        Me.pnlLoading.Controls.Add(Me.lblProgress)
        Me.pnlLoading.Controls.Add(Me.ProgressBar1)
        Me.pnlLoading.Location = New System.Drawing.Point(208, 104)
        Me.pnlLoading.Name = "pnlLoading"
        Me.pnlLoading.Size = New System.Drawing.Size(294, 58)
        Me.pnlLoading.TabIndex = 46
        Me.pnlLoading.UseWaitCursor = True
        Me.pnlLoading.Visible = False
        '
        'lblProgress
        '
        Me.lblProgress.AutoSize = True
        Me.lblProgress.Location = New System.Drawing.Point(14, 11)
        Me.lblProgress.Name = "lblProgress"
        Me.lblProgress.Size = New System.Drawing.Size(108, 13)
        Me.lblProgress.TabIndex = 57
        Me.lblProgress.Text = "Saving 0 of 0 records"
        Me.lblProgress.UseWaitCursor = True
        '
        'ProgressBar1
        '
        Me.ProgressBar1.ForeColor = System.Drawing.Color.Magenta
        Me.ProgressBar1.Location = New System.Drawing.Point(17, 30)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.RightToLeftLayout = True
        Me.ProgressBar1.Size = New System.Drawing.Size(252, 12)
        Me.ProgressBar1.Step = 5
        Me.ProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.ProgressBar1.TabIndex = 54
        Me.ProgressBar1.UseWaitCursor = True
        '
        'obj_Circulation_id
        '
        Me.obj_Circulation_id.BackColor = System.Drawing.SystemColors.Info
        Me.obj_Circulation_id.Location = New System.Drawing.Point(96, 23)
        Me.obj_Circulation_id.Name = "obj_Circulation_id"
        Me.obj_Circulation_id.ReadOnly = True
        Me.obj_Circulation_id.Size = New System.Drawing.Size(125, 20)
        Me.obj_Circulation_id.TabIndex = 1
        '
        'lbl_Circulation_id
        '
        Me.lbl_Circulation_id.AutoSize = True
        Me.lbl_Circulation_id.Location = New System.Drawing.Point(23, 23)
        Me.lbl_Circulation_id.Name = "lbl_Circulation_id"
        Me.lbl_Circulation_id.Size = New System.Drawing.Size(18, 13)
        Me.lbl_Circulation_id.TabIndex = 0
        Me.lbl_Circulation_id.Text = "ID"
        '
        'obj_Circulation_appuser
        '
        Me.obj_Circulation_appuser.AutoSize = True
        Me.obj_Circulation_appuser.Enabled = False
        Me.obj_Circulation_appuser.Location = New System.Drawing.Point(431, 126)
        Me.obj_Circulation_appuser.Name = "obj_Circulation_appuser"
        Me.obj_Circulation_appuser.Size = New System.Drawing.Size(73, 17)
        Me.obj_Circulation_appuser.TabIndex = 2
        Me.obj_Circulation_appuser.Text = "App. User"
        Me.obj_Circulation_appuser.UseVisualStyleBackColor = True
        '
        'lbl_Circulation_senddt
        '
        Me.lbl_Circulation_senddt.AutoSize = True
        Me.lbl_Circulation_senddt.Location = New System.Drawing.Point(23, 49)
        Me.lbl_Circulation_senddt.Name = "lbl_Circulation_senddt"
        Me.lbl_Circulation_senddt.Size = New System.Drawing.Size(58, 13)
        Me.lbl_Circulation_senddt.TabIndex = 0
        Me.lbl_Circulation_senddt.Text = "Send Date"
        '
        'lbl_Circulation_sendto
        '
        Me.lbl_Circulation_sendto.AutoSize = True
        Me.lbl_Circulation_sendto.Location = New System.Drawing.Point(23, 75)
        Me.lbl_Circulation_sendto.Name = "lbl_Circulation_sendto"
        Me.lbl_Circulation_sendto.Size = New System.Drawing.Size(48, 13)
        Me.lbl_Circulation_sendto.TabIndex = 0
        Me.lbl_Circulation_sendto.Text = "Send To"
        '
        'obj_Circulation_descr
        '
        Me.obj_Circulation_descr.BackColor = System.Drawing.Color.White
        Me.obj_Circulation_descr.Location = New System.Drawing.Point(96, 97)
        Me.obj_Circulation_descr.Multiline = True
        Me.obj_Circulation_descr.Name = "obj_Circulation_descr"
        Me.obj_Circulation_descr.Size = New System.Drawing.Size(189, 46)
        Me.obj_Circulation_descr.TabIndex = 1
        '
        'lbl_Circulation_descr
        '
        Me.lbl_Circulation_descr.AutoSize = True
        Me.lbl_Circulation_descr.Location = New System.Drawing.Point(23, 100)
        Me.lbl_Circulation_descr.Name = "lbl_Circulation_descr"
        Me.lbl_Circulation_descr.Size = New System.Drawing.Size(60, 13)
        Me.lbl_Circulation_descr.TabIndex = 0
        Me.lbl_Circulation_descr.Text = "Description"
        '
        'obj_Jurnaltype_id
        '
        Me.obj_Jurnaltype_id.BackColor = System.Drawing.SystemColors.Info
        Me.obj_Jurnaltype_id.Location = New System.Drawing.Point(431, 50)
        Me.obj_Jurnaltype_id.Name = "obj_Jurnaltype_id"
        Me.obj_Jurnaltype_id.ReadOnly = True
        Me.obj_Jurnaltype_id.Size = New System.Drawing.Size(74, 20)
        Me.obj_Jurnaltype_id.TabIndex = 1
        '
        'lbl_Jurnaltype_id
        '
        Me.lbl_Jurnaltype_id.AutoSize = True
        Me.lbl_Jurnaltype_id.Location = New System.Drawing.Point(346, 53)
        Me.lbl_Jurnaltype_id.Name = "lbl_Jurnaltype_id"
        Me.lbl_Jurnaltype_id.Size = New System.Drawing.Size(45, 13)
        Me.lbl_Jurnaltype_id.TabIndex = 0
        Me.lbl_Jurnaltype_id.Text = "Type ID"
        '
        'obj_Channel_id
        '
        Me.obj_Channel_id.BackColor = System.Drawing.SystemColors.Info
        Me.obj_Channel_id.Location = New System.Drawing.Point(431, 24)
        Me.obj_Channel_id.Name = "obj_Channel_id"
        Me.obj_Channel_id.ReadOnly = True
        Me.obj_Channel_id.Size = New System.Drawing.Size(100, 20)
        Me.obj_Channel_id.TabIndex = 1
        '
        'lbl_Channel_id
        '
        Me.lbl_Channel_id.AutoSize = True
        Me.lbl_Channel_id.Location = New System.Drawing.Point(346, 26)
        Me.lbl_Channel_id.Name = "lbl_Channel_id"
        Me.lbl_Channel_id.Size = New System.Drawing.Size(60, 13)
        Me.lbl_Channel_id.TabIndex = 0
        Me.lbl_Channel_id.Text = "Channel_id"
        '
        'obj_Circulation_status
        '
        Me.obj_Circulation_status.BackColor = System.Drawing.SystemColors.Info
        Me.obj_Circulation_status.Location = New System.Drawing.Point(431, 74)
        Me.obj_Circulation_status.Name = "obj_Circulation_status"
        Me.obj_Circulation_status.ReadOnly = True
        Me.obj_Circulation_status.Size = New System.Drawing.Size(74, 20)
        Me.obj_Circulation_status.TabIndex = 1
        '
        'lbl_Circulation_status
        '
        Me.lbl_Circulation_status.AutoSize = True
        Me.lbl_Circulation_status.Location = New System.Drawing.Point(346, 76)
        Me.lbl_Circulation_status.Name = "lbl_Circulation_status"
        Me.lbl_Circulation_status.Size = New System.Drawing.Size(37, 13)
        Me.lbl_Circulation_status.TabIndex = 0
        Me.lbl_Circulation_status.Text = "Status"
        '
        'obj_Circulation_totalrevisi
        '
        Me.obj_Circulation_totalrevisi.BackColor = System.Drawing.SystemColors.Info
        Me.obj_Circulation_totalrevisi.Location = New System.Drawing.Point(431, 100)
        Me.obj_Circulation_totalrevisi.Name = "obj_Circulation_totalrevisi"
        Me.obj_Circulation_totalrevisi.ReadOnly = True
        Me.obj_Circulation_totalrevisi.Size = New System.Drawing.Size(52, 20)
        Me.obj_Circulation_totalrevisi.TabIndex = 1
        Me.obj_Circulation_totalrevisi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbl_Circulation_totalrevisi
        '
        Me.lbl_Circulation_totalrevisi.AutoSize = True
        Me.lbl_Circulation_totalrevisi.Location = New System.Drawing.Point(346, 102)
        Me.lbl_Circulation_totalrevisi.Name = "lbl_Circulation_totalrevisi"
        Me.lbl_Circulation_totalrevisi.Size = New System.Drawing.Size(63, 13)
        Me.lbl_Circulation_totalrevisi.TabIndex = 0
        Me.lbl_Circulation_totalrevisi.Text = "Total Revisi"
        '
        'PnlDataFooter
        '
        Me.PnlDataFooter.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnlDataFooter.Location = New System.Drawing.Point(3, 458)
        Me.PnlDataFooter.Name = "PnlDataFooter"
        Me.PnlDataFooter.Size = New System.Drawing.Size(733, 27)
        Me.PnlDataFooter.TabIndex = 2
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "Stop 2.ico")
        Me.ImageList1.Images.SetKeyName(1, "Spell.ico")
        Me.ImageList1.Images.SetKeyName(2, "excel.jpg")
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
        'uiTrnCirculationVoucher
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.Controls.Add(Me.ftabMain)
        Me.DSN = resources.GetString("$this.DSN")
        Me.Name = "uiTrnCirculationVoucher"
        Me.Controls.SetChildIndex(Me.ftabMain, 0)
        CType(Me.tbl_MstSetting, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ftabMain.ResumeLayout(False)
        Me.ftabMain_List.ResumeLayout(False)
        Me.PnlDfMain.ResumeLayout(False)
        CType(Me.DgvTrnCirculationvoucher, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlDfSearch.ResumeLayout(False)
        Me.PnlDfSearch.PerformLayout()
        Me.ftabMain_Data.ResumeLayout(False)
        Me.ftabDataDetil.ResumeLayout(False)
        Me.ftabDataDetil_Detil.ResumeLayout(False)
        CType(Me.DgvTrnCirculationvoucherdetil, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ftabDataDetil_Info.ResumeLayout(False)
        Me.ftabDataDetil_Info.PerformLayout()
        Me.PnlDataMaster.ResumeLayout(False)
        Me.PnlDataMaster.PerformLayout()
        Me.pnlLoading.ResumeLayout(False)
        Me.pnlLoading.PerformLayout()
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
    Friend WithEvents ftabDataDetil As FlatTabControl.FlatTabControl
    Friend WithEvents ftabDataDetil_Detil As System.Windows.Forms.TabPage
    Friend WithEvents chkSearchChannel As System.Windows.Forms.CheckBox
    Friend WithEvents cboSearchChannel As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_Circulation_id As System.Windows.Forms.Label
    Friend WithEvents obj_Circulation_id As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Circulation_senddt As System.Windows.Forms.Label
    Friend WithEvents lbl_Circulation_sendto As System.Windows.Forms.Label
    Friend WithEvents lbl_Circulation_foreign As System.Windows.Forms.Label
    Friend WithEvents obj_Circulation_foreign As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Circulation_amount As System.Windows.Forms.Label
    Friend WithEvents obj_Circulation_amount As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Circulation_descr As System.Windows.Forms.Label
    Friend WithEvents obj_Circulation_descr As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Jurnaltype_id As System.Windows.Forms.Label
    Friend WithEvents obj_Jurnaltype_id As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Channel_id As System.Windows.Forms.Label
    Friend WithEvents obj_Channel_id As System.Windows.Forms.TextBox
    Friend WithEvents obj_Circulation_appuser As System.Windows.Forms.CheckBox
    Friend WithEvents lbl_Circulation_appuserby As System.Windows.Forms.Label
    Friend WithEvents obj_Circulation_appuserby As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Circulation_appuserdt As System.Windows.Forms.Label
    Friend WithEvents obj_Circulation_appuserdt As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Circulation_status As System.Windows.Forms.Label
    Friend WithEvents obj_Circulation_status As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Circulation_totalrevisi As System.Windows.Forms.Label
    Friend WithEvents obj_Circulation_totalrevisi As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Entry_by As System.Windows.Forms.Label
    Friend WithEvents obj_Entry_by As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Entry_dt As System.Windows.Forms.Label
    Friend WithEvents obj_Entry_dt As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Modified_by As System.Windows.Forms.Label
    Friend WithEvents obj_Modified_by As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Modified_dt As System.Windows.Forms.Label
    Friend WithEvents obj_Modified_dt As System.Windows.Forms.TextBox
    Friend WithEvents ftabDataDetil_Info As System.Windows.Forms.TabPage
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents btn_CheckAllAppDir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btn_UnCheckAllAppDir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btn_Refresh As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtSearchJurnalID As System.Windows.Forms.TextBox
    Friend WithEvents chkSearchJurnalID As System.Windows.Forms.CheckBox
    Friend WithEvents chkSearchAppUser As System.Windows.Forms.CheckBox
    Friend WithEvents chkSearchCreateBy As System.Windows.Forms.CheckBox
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents DgvTrnCirculationvoucher As System.Windows.Forms.DataGridView
    Friend WithEvents cmbSearchAppUser As System.Windows.Forms.ComboBox
    Friend WithEvents cmbSearchCreateBy As System.Windows.Forms.ComboBox
    Friend WithEvents DgvTrnCirculationvoucherdetil As System.Windows.Forms.DataGridView
    Friend WithEvents btn_List As System.Windows.Forms.Button
    Friend WithEvents pnlLoading As System.Windows.Forms.Panel
    Friend WithEvents lblProgress As System.Windows.Forms.Label
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents lblLoading As System.Windows.Forms.Label
    Friend WithEvents obj_ProgressBar_backGroundWorker As System.Windows.Forms.ProgressBar
    Friend WithEvents obj_Circulation_sendto As System.Windows.Forms.ComboBox
    Friend WithEvents obj_Circulation_senddt As System.Windows.Forms.DateTimePicker

End Class

