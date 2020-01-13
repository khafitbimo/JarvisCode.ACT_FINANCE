<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class uiTrnVoid
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(uiTrnVoid))
        Me.ftabMain = New FlatTabControl.FlatTabControl()
        Me.ftabMain_List = New System.Windows.Forms.TabPage()
        Me.PnlDfMain = New System.Windows.Forms.Panel()
        Me.DgvTrnVoid = New System.Windows.Forms.DataGridView()
        Me.PnlDfFooter = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.PnlDfSearch = New System.Windows.Forms.Panel()
        Me.chk_status_search = New System.Windows.Forms.CheckBox()
        Me.obj_status_search = New System.Windows.Forms.ComboBox()
        Me.chk_voidid_search = New System.Windows.Forms.CheckBox()
        Me.obj_voidid_search = New System.Windows.Forms.TextBox()
        Me.ftabMain_Data = New System.Windows.Forms.TabPage()
        Me.ftabDataDetil = New FlatTabControl.FlatTabControl()
        Me.ftabDataDetil_Advance = New System.Windows.Forms.TabPage()
        Me.DgvTrnVoidAdvance = New System.Windows.Forms.DataGridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnLoadAdvance = New System.Windows.Forms.Button()
        Me.ftabDataDetil_AdvanceDetil = New System.Windows.Forms.TabPage()
        Me.dgvTrnVoidAdvanceDetail = New System.Windows.Forms.DataGridView()
        Me.ftabDataDetil_Info = New System.Windows.Forms.TabPage()
        Me.obj_Created_by = New System.Windows.Forms.TextBox()
        Me.lbl_Approved_by = New System.Windows.Forms.Label()
        Me.lbl_Created_by = New System.Windows.Forms.Label()
        Me.lbl_Posted_dt = New System.Windows.Forms.Label()
        Me.obj_Created_dt = New System.Windows.Forms.TextBox()
        Me.obj_Posted_dt = New System.Windows.Forms.TextBox()
        Me.lbl_Created_dt = New System.Windows.Forms.Label()
        Me.lbl_Posted_by = New System.Windows.Forms.Label()
        Me.obj_Modified_by = New System.Windows.Forms.TextBox()
        Me.obj_Posted_by = New System.Windows.Forms.TextBox()
        Me.lbl_Modified_by = New System.Windows.Forms.Label()
        Me.lbl_Approved_dt = New System.Windows.Forms.Label()
        Me.obj_Modified_dt = New System.Windows.Forms.TextBox()
        Me.obj_Approved_dt = New System.Windows.Forms.TextBox()
        Me.lbl_Modified_dt = New System.Windows.Forms.Label()
        Me.obj_Approved_by = New System.Windows.Forms.TextBox()
        Me.PnlDataMaster = New System.Windows.Forms.Panel()
        Me.obj_Void_date = New System.Windows.Forms.DateTimePicker()
        Me.obj_Void_id = New System.Windows.Forms.TextBox()
        Me.lbl_Void_id = New System.Windows.Forms.Label()
        Me.lbl_Void_date = New System.Windows.Forms.Label()
        CType(Me.tbl_MstSetting, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ftabMain.SuspendLayout()
        Me.ftabMain_List.SuspendLayout()
        Me.PnlDfMain.SuspendLayout()
        CType(Me.DgvTrnVoid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlDfFooter.SuspendLayout()
        Me.PnlDfSearch.SuspendLayout()
        Me.ftabMain_Data.SuspendLayout()
        Me.ftabDataDetil.SuspendLayout()
        Me.ftabDataDetil_Advance.SuspendLayout()
        CType(Me.DgvTrnVoidAdvance, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.ftabDataDetil_AdvanceDetil.SuspendLayout()
        CType(Me.dgvTrnVoidAdvanceDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ftabDataDetil_Info.SuspendLayout()
        Me.PnlDataMaster.SuspendLayout()
        Me.SuspendLayout()
        '
        'ftabMain
        '
        Me.ftabMain.Controls.Add(Me.ftabMain_List)
        Me.ftabMain.Controls.Add(Me.ftabMain_Data)
        Me.ftabMain.Location = New System.Drawing.Point(3, 28)
        Me.ftabMain.myBackColor = System.Drawing.Color.Transparent
        Me.ftabMain.Name = "ftabMain"
        Me.ftabMain.SelectedIndex = 0
        Me.ftabMain.Size = New System.Drawing.Size(747, 517)
        Me.ftabMain.TabIndex = 1
        '
        'ftabMain_List
        '
        Me.ftabMain_List.BackColor = System.Drawing.Color.Gainsboro
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
        Me.PnlDfMain.Controls.Add(Me.DgvTrnVoid)
        Me.PnlDfMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnlDfMain.Location = New System.Drawing.Point(3, 70)
        Me.PnlDfMain.Name = "PnlDfMain"
        Me.PnlDfMain.Size = New System.Drawing.Size(733, 376)
        Me.PnlDfMain.TabIndex = 1
        '
        'DgvTrnVoid
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvTrnVoid.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DgvTrnVoid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgvTrnVoid.DefaultCellStyle = DataGridViewCellStyle2
        Me.DgvTrnVoid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvTrnVoid.Location = New System.Drawing.Point(0, 0)
        Me.DgvTrnVoid.Name = "DgvTrnVoid"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvTrnVoid.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DgvTrnVoid.Size = New System.Drawing.Size(733, 376)
        Me.DgvTrnVoid.TabIndex = 0
        '
        'PnlDfFooter
        '
        Me.PnlDfFooter.BackColor = System.Drawing.Color.Gainsboro
        Me.PnlDfFooter.Controls.Add(Me.Label2)
        Me.PnlDfFooter.Controls.Add(Me.Panel3)
        Me.PnlDfFooter.Controls.Add(Me.Label1)
        Me.PnlDfFooter.Controls.Add(Me.Panel2)
        Me.PnlDfFooter.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnlDfFooter.Location = New System.Drawing.Point(3, 446)
        Me.PnlDfFooter.Name = "PnlDfFooter"
        Me.PnlDfFooter.Size = New System.Drawing.Size(733, 39)
        Me.PnlDfFooter.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(148, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Posted"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.CornflowerBlue
        Me.Panel3.Location = New System.Drawing.Point(120, 11)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(22, 21)
        Me.Panel3.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(42, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Approved"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.DarkMagenta
        Me.Panel2.Location = New System.Drawing.Point(14, 11)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(22, 21)
        Me.Panel2.TabIndex = 0
        '
        'PnlDfSearch
        '
        Me.PnlDfSearch.BackColor = System.Drawing.Color.Gainsboro
        Me.PnlDfSearch.Controls.Add(Me.chk_status_search)
        Me.PnlDfSearch.Controls.Add(Me.obj_status_search)
        Me.PnlDfSearch.Controls.Add(Me.chk_voidid_search)
        Me.PnlDfSearch.Controls.Add(Me.obj_voidid_search)
        Me.PnlDfSearch.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlDfSearch.Location = New System.Drawing.Point(3, 3)
        Me.PnlDfSearch.Name = "PnlDfSearch"
        Me.PnlDfSearch.Size = New System.Drawing.Size(733, 67)
        Me.PnlDfSearch.TabIndex = 0
        '
        'chk_status_search
        '
        Me.chk_status_search.AutoSize = True
        Me.chk_status_search.Location = New System.Drawing.Point(9, 39)
        Me.chk_status_search.Name = "chk_status_search"
        Me.chk_status_search.Size = New System.Drawing.Size(56, 17)
        Me.chk_status_search.TabIndex = 4
        Me.chk_status_search.Text = "Status"
        Me.chk_status_search.UseVisualStyleBackColor = True
        '
        'obj_status_search
        '
        Me.obj_status_search.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.obj_status_search.FormattingEnabled = True
        Me.obj_status_search.Items.AddRange(New Object() {"Approved", "Posted"})
        Me.obj_status_search.Location = New System.Drawing.Point(74, 35)
        Me.obj_status_search.Name = "obj_status_search"
        Me.obj_status_search.Size = New System.Drawing.Size(132, 21)
        Me.obj_status_search.TabIndex = 3
        '
        'chk_voidid_search
        '
        Me.chk_voidid_search.AutoSize = True
        Me.chk_voidid_search.Location = New System.Drawing.Point(9, 12)
        Me.chk_voidid_search.Name = "chk_voidid_search"
        Me.chk_voidid_search.Size = New System.Drawing.Size(59, 17)
        Me.chk_voidid_search.TabIndex = 2
        Me.chk_voidid_search.Text = "Void Id"
        Me.chk_voidid_search.UseVisualStyleBackColor = True
        '
        'obj_voidid_search
        '
        Me.obj_voidid_search.Location = New System.Drawing.Point(74, 9)
        Me.obj_voidid_search.Name = "obj_voidid_search"
        Me.obj_voidid_search.Size = New System.Drawing.Size(132, 20)
        Me.obj_voidid_search.TabIndex = 0
        '
        'ftabMain_Data
        '
        Me.ftabMain_Data.BackColor = System.Drawing.Color.Gainsboro
        Me.ftabMain_Data.Controls.Add(Me.ftabDataDetil)
        Me.ftabMain_Data.Controls.Add(Me.PnlDataMaster)
        Me.ftabMain_Data.Location = New System.Drawing.Point(4, 25)
        Me.ftabMain_Data.Name = "ftabMain_Data"
        Me.ftabMain_Data.Padding = New System.Windows.Forms.Padding(3)
        Me.ftabMain_Data.Size = New System.Drawing.Size(739, 488)
        Me.ftabMain_Data.TabIndex = 1
        Me.ftabMain_Data.Text = "Data"
        '
        'ftabDataDetil
        '
        Me.ftabDataDetil.Controls.Add(Me.ftabDataDetil_Advance)
        Me.ftabDataDetil.Controls.Add(Me.ftabDataDetil_AdvanceDetil)
        Me.ftabDataDetil.Controls.Add(Me.ftabDataDetil_Info)
        Me.ftabDataDetil.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ftabDataDetil.Location = New System.Drawing.Point(3, 77)
        Me.ftabDataDetil.myBackColor = System.Drawing.Color.Gainsboro
        Me.ftabDataDetil.Name = "ftabDataDetil"
        Me.ftabDataDetil.SelectedIndex = 0
        Me.ftabDataDetil.Size = New System.Drawing.Size(733, 408)
        Me.ftabDataDetil.TabIndex = 3
        '
        'ftabDataDetil_Advance
        '
        Me.ftabDataDetil_Advance.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ftabDataDetil_Advance.Controls.Add(Me.DgvTrnVoidAdvance)
        Me.ftabDataDetil_Advance.Controls.Add(Me.Panel1)
        Me.ftabDataDetil_Advance.Location = New System.Drawing.Point(4, 25)
        Me.ftabDataDetil_Advance.Name = "ftabDataDetil_Advance"
        Me.ftabDataDetil_Advance.Padding = New System.Windows.Forms.Padding(3)
        Me.ftabDataDetil_Advance.Size = New System.Drawing.Size(725, 379)
        Me.ftabDataDetil_Advance.TabIndex = 0
        Me.ftabDataDetil_Advance.Text = "PV"
        '
        'DgvTrnVoidAdvance
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvTrnVoidAdvance.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.DgvTrnVoidAdvance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgvTrnVoidAdvance.DefaultCellStyle = DataGridViewCellStyle5
        Me.DgvTrnVoidAdvance.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvTrnVoidAdvance.Location = New System.Drawing.Point(3, 3)
        Me.DgvTrnVoidAdvance.Name = "DgvTrnVoidAdvance"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvTrnVoidAdvance.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.DgvTrnVoidAdvance.Size = New System.Drawing.Size(719, 339)
        Me.DgvTrnVoidAdvance.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel1.Controls.Add(Me.btnLoadAdvance)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(3, 342)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(719, 34)
        Me.Panel1.TabIndex = 2
        '
        'btnLoadAdvance
        '
        Me.btnLoadAdvance.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnLoadAdvance.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLoadAdvance.ForeColor = System.Drawing.Color.Black
        Me.btnLoadAdvance.Location = New System.Drawing.Point(3, 3)
        Me.btnLoadAdvance.Name = "btnLoadAdvance"
        Me.btnLoadAdvance.Size = New System.Drawing.Size(117, 28)
        Me.btnLoadAdvance.TabIndex = 1
        Me.btnLoadAdvance.Text = "PV List Advance"
        Me.btnLoadAdvance.UseVisualStyleBackColor = False
        '
        'ftabDataDetil_AdvanceDetil
        '
        Me.ftabDataDetil_AdvanceDetil.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ftabDataDetil_AdvanceDetil.Controls.Add(Me.dgvTrnVoidAdvanceDetail)
        Me.ftabDataDetil_AdvanceDetil.Location = New System.Drawing.Point(4, 25)
        Me.ftabDataDetil_AdvanceDetil.Name = "ftabDataDetil_AdvanceDetil"
        Me.ftabDataDetil_AdvanceDetil.Padding = New System.Windows.Forms.Padding(3)
        Me.ftabDataDetil_AdvanceDetil.Size = New System.Drawing.Size(725, 379)
        Me.ftabDataDetil_AdvanceDetil.TabIndex = 2
        Me.ftabDataDetil_AdvanceDetil.Text = "PV Detil"
        '
        'dgvTrnVoidAdvanceDetail
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvTrnVoidAdvanceDetail.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dgvTrnVoidAdvanceDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvTrnVoidAdvanceDetail.DefaultCellStyle = DataGridViewCellStyle8
        Me.dgvTrnVoidAdvanceDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvTrnVoidAdvanceDetail.Location = New System.Drawing.Point(3, 3)
        Me.dgvTrnVoidAdvanceDetail.Name = "dgvTrnVoidAdvanceDetail"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvTrnVoidAdvanceDetail.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.dgvTrnVoidAdvanceDetail.Size = New System.Drawing.Size(719, 373)
        Me.dgvTrnVoidAdvanceDetail.TabIndex = 0
        '
        'ftabDataDetil_Info
        '
        Me.ftabDataDetil_Info.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ftabDataDetil_Info.Controls.Add(Me.obj_Created_by)
        Me.ftabDataDetil_Info.Controls.Add(Me.lbl_Approved_by)
        Me.ftabDataDetil_Info.Controls.Add(Me.lbl_Created_by)
        Me.ftabDataDetil_Info.Controls.Add(Me.lbl_Posted_dt)
        Me.ftabDataDetil_Info.Controls.Add(Me.obj_Created_dt)
        Me.ftabDataDetil_Info.Controls.Add(Me.obj_Posted_dt)
        Me.ftabDataDetil_Info.Controls.Add(Me.lbl_Created_dt)
        Me.ftabDataDetil_Info.Controls.Add(Me.lbl_Posted_by)
        Me.ftabDataDetil_Info.Controls.Add(Me.obj_Modified_by)
        Me.ftabDataDetil_Info.Controls.Add(Me.obj_Posted_by)
        Me.ftabDataDetil_Info.Controls.Add(Me.lbl_Modified_by)
        Me.ftabDataDetil_Info.Controls.Add(Me.lbl_Approved_dt)
        Me.ftabDataDetil_Info.Controls.Add(Me.obj_Modified_dt)
        Me.ftabDataDetil_Info.Controls.Add(Me.obj_Approved_dt)
        Me.ftabDataDetil_Info.Controls.Add(Me.lbl_Modified_dt)
        Me.ftabDataDetil_Info.Controls.Add(Me.obj_Approved_by)
        Me.ftabDataDetil_Info.Location = New System.Drawing.Point(4, 25)
        Me.ftabDataDetil_Info.Name = "ftabDataDetil_Info"
        Me.ftabDataDetil_Info.Padding = New System.Windows.Forms.Padding(3)
        Me.ftabDataDetil_Info.Size = New System.Drawing.Size(725, 379)
        Me.ftabDataDetil_Info.TabIndex = 1
        Me.ftabDataDetil_Info.Text = "Info"
        '
        'obj_Created_by
        '
        Me.obj_Created_by.BackColor = System.Drawing.Color.LightYellow
        Me.obj_Created_by.Location = New System.Drawing.Point(110, 14)
        Me.obj_Created_by.Name = "obj_Created_by"
        Me.obj_Created_by.ReadOnly = True
        Me.obj_Created_by.Size = New System.Drawing.Size(175, 20)
        Me.obj_Created_by.TabIndex = 10
        '
        'lbl_Approved_by
        '
        Me.lbl_Approved_by.AutoSize = True
        Me.lbl_Approved_by.Location = New System.Drawing.Point(408, 17)
        Me.lbl_Approved_by.Name = "lbl_Approved_by"
        Me.lbl_Approved_by.Size = New System.Drawing.Size(68, 13)
        Me.lbl_Approved_by.TabIndex = 4
        Me.lbl_Approved_by.Text = "Approved By"
        '
        'lbl_Created_by
        '
        Me.lbl_Created_by.AutoSize = True
        Me.lbl_Created_by.Location = New System.Drawing.Point(16, 17)
        Me.lbl_Created_by.Name = "lbl_Created_by"
        Me.lbl_Created_by.Size = New System.Drawing.Size(59, 13)
        Me.lbl_Created_by.TabIndex = 7
        Me.lbl_Created_by.Text = "Created By"
        '
        'lbl_Posted_dt
        '
        Me.lbl_Posted_dt.AutoSize = True
        Me.lbl_Posted_dt.Location = New System.Drawing.Point(408, 95)
        Me.lbl_Posted_dt.Name = "lbl_Posted_dt"
        Me.lbl_Posted_dt.Size = New System.Drawing.Size(66, 13)
        Me.lbl_Posted_dt.TabIndex = 2
        Me.lbl_Posted_dt.Text = "Posted Date"
        '
        'obj_Created_dt
        '
        Me.obj_Created_dt.BackColor = System.Drawing.Color.LightYellow
        Me.obj_Created_dt.Location = New System.Drawing.Point(110, 40)
        Me.obj_Created_dt.Name = "obj_Created_dt"
        Me.obj_Created_dt.ReadOnly = True
        Me.obj_Created_dt.Size = New System.Drawing.Size(175, 20)
        Me.obj_Created_dt.TabIndex = 17
        '
        'obj_Posted_dt
        '
        Me.obj_Posted_dt.BackColor = System.Drawing.Color.LightYellow
        Me.obj_Posted_dt.Location = New System.Drawing.Point(505, 92)
        Me.obj_Posted_dt.Name = "obj_Posted_dt"
        Me.obj_Posted_dt.ReadOnly = True
        Me.obj_Posted_dt.Size = New System.Drawing.Size(175, 20)
        Me.obj_Posted_dt.TabIndex = 12
        '
        'lbl_Created_dt
        '
        Me.lbl_Created_dt.AutoSize = True
        Me.lbl_Created_dt.Location = New System.Drawing.Point(16, 43)
        Me.lbl_Created_dt.Name = "lbl_Created_dt"
        Me.lbl_Created_dt.Size = New System.Drawing.Size(70, 13)
        Me.lbl_Created_dt.TabIndex = 9
        Me.lbl_Created_dt.Text = "Created Date"
        '
        'lbl_Posted_by
        '
        Me.lbl_Posted_by.AutoSize = True
        Me.lbl_Posted_by.Location = New System.Drawing.Point(408, 69)
        Me.lbl_Posted_by.Name = "lbl_Posted_by"
        Me.lbl_Posted_by.Size = New System.Drawing.Size(55, 13)
        Me.lbl_Posted_by.TabIndex = 5
        Me.lbl_Posted_by.Text = "Posted By"
        '
        'obj_Modified_by
        '
        Me.obj_Modified_by.BackColor = System.Drawing.Color.LightYellow
        Me.obj_Modified_by.Location = New System.Drawing.Point(110, 66)
        Me.obj_Modified_by.Name = "obj_Modified_by"
        Me.obj_Modified_by.ReadOnly = True
        Me.obj_Modified_by.Size = New System.Drawing.Size(175, 20)
        Me.obj_Modified_by.TabIndex = 14
        '
        'obj_Posted_by
        '
        Me.obj_Posted_by.BackColor = System.Drawing.Color.LightYellow
        Me.obj_Posted_by.Location = New System.Drawing.Point(505, 66)
        Me.obj_Posted_by.Name = "obj_Posted_by"
        Me.obj_Posted_by.ReadOnly = True
        Me.obj_Posted_by.Size = New System.Drawing.Size(175, 20)
        Me.obj_Posted_by.TabIndex = 11
        '
        'lbl_Modified_by
        '
        Me.lbl_Modified_by.AutoSize = True
        Me.lbl_Modified_by.Location = New System.Drawing.Point(16, 69)
        Me.lbl_Modified_by.Name = "lbl_Modified_by"
        Me.lbl_Modified_by.Size = New System.Drawing.Size(62, 13)
        Me.lbl_Modified_by.TabIndex = 3
        Me.lbl_Modified_by.Text = "Modified By"
        '
        'lbl_Approved_dt
        '
        Me.lbl_Approved_dt.AutoSize = True
        Me.lbl_Approved_dt.Location = New System.Drawing.Point(408, 43)
        Me.lbl_Approved_dt.Name = "lbl_Approved_dt"
        Me.lbl_Approved_dt.Size = New System.Drawing.Size(79, 13)
        Me.lbl_Approved_dt.TabIndex = 6
        Me.lbl_Approved_dt.Text = "Approved Date"
        '
        'obj_Modified_dt
        '
        Me.obj_Modified_dt.BackColor = System.Drawing.Color.LightYellow
        Me.obj_Modified_dt.Location = New System.Drawing.Point(110, 92)
        Me.obj_Modified_dt.Name = "obj_Modified_dt"
        Me.obj_Modified_dt.ReadOnly = True
        Me.obj_Modified_dt.Size = New System.Drawing.Size(175, 20)
        Me.obj_Modified_dt.TabIndex = 13
        '
        'obj_Approved_dt
        '
        Me.obj_Approved_dt.BackColor = System.Drawing.Color.LightYellow
        Me.obj_Approved_dt.Location = New System.Drawing.Point(505, 40)
        Me.obj_Approved_dt.Name = "obj_Approved_dt"
        Me.obj_Approved_dt.ReadOnly = True
        Me.obj_Approved_dt.Size = New System.Drawing.Size(175, 20)
        Me.obj_Approved_dt.TabIndex = 16
        '
        'lbl_Modified_dt
        '
        Me.lbl_Modified_dt.AutoSize = True
        Me.lbl_Modified_dt.Location = New System.Drawing.Point(16, 95)
        Me.lbl_Modified_dt.Name = "lbl_Modified_dt"
        Me.lbl_Modified_dt.Size = New System.Drawing.Size(73, 13)
        Me.lbl_Modified_dt.TabIndex = 8
        Me.lbl_Modified_dt.Text = "Modified Date"
        '
        'obj_Approved_by
        '
        Me.obj_Approved_by.BackColor = System.Drawing.Color.LightYellow
        Me.obj_Approved_by.Location = New System.Drawing.Point(505, 14)
        Me.obj_Approved_by.Name = "obj_Approved_by"
        Me.obj_Approved_by.ReadOnly = True
        Me.obj_Approved_by.Size = New System.Drawing.Size(175, 20)
        Me.obj_Approved_by.TabIndex = 15
        '
        'PnlDataMaster
        '
        Me.PnlDataMaster.AutoScroll = True
        Me.PnlDataMaster.BackColor = System.Drawing.Color.Gainsboro
        Me.PnlDataMaster.Controls.Add(Me.obj_Void_date)
        Me.PnlDataMaster.Controls.Add(Me.obj_Void_id)
        Me.PnlDataMaster.Controls.Add(Me.lbl_Void_id)
        Me.PnlDataMaster.Controls.Add(Me.lbl_Void_date)
        Me.PnlDataMaster.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlDataMaster.Location = New System.Drawing.Point(3, 3)
        Me.PnlDataMaster.Name = "PnlDataMaster"
        Me.PnlDataMaster.Size = New System.Drawing.Size(733, 74)
        Me.PnlDataMaster.TabIndex = 0
        '
        'obj_Void_date
        '
        Me.obj_Void_date.CustomFormat = "dd/MM/yyyy"
        Me.obj_Void_date.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.obj_Void_date.Location = New System.Drawing.Point(61, 40)
        Me.obj_Void_date.Name = "obj_Void_date"
        Me.obj_Void_date.Size = New System.Drawing.Size(150, 20)
        Me.obj_Void_date.TabIndex = 2
        Me.obj_Void_date.Value = New Date(2011, 3, 4, 0, 0, 0, 0)
        '
        'obj_Void_id
        '
        Me.obj_Void_id.BackColor = System.Drawing.Color.LightYellow
        Me.obj_Void_id.Location = New System.Drawing.Point(61, 15)
        Me.obj_Void_id.Name = "obj_Void_id"
        Me.obj_Void_id.ReadOnly = True
        Me.obj_Void_id.Size = New System.Drawing.Size(150, 20)
        Me.obj_Void_id.TabIndex = 1
        '
        'lbl_Void_id
        '
        Me.lbl_Void_id.AutoSize = True
        Me.lbl_Void_id.Location = New System.Drawing.Point(14, 18)
        Me.lbl_Void_id.Name = "lbl_Void_id"
        Me.lbl_Void_id.Size = New System.Drawing.Size(18, 13)
        Me.lbl_Void_id.TabIndex = 0
        Me.lbl_Void_id.Text = "ID"
        '
        'lbl_Void_date
        '
        Me.lbl_Void_date.AutoSize = True
        Me.lbl_Void_date.Location = New System.Drawing.Point(14, 44)
        Me.lbl_Void_date.Name = "lbl_Void_date"
        Me.lbl_Void_date.Size = New System.Drawing.Size(30, 13)
        Me.lbl_Void_date.TabIndex = 0
        Me.lbl_Void_date.Text = "Date"
        '
        'uiTrnVoid
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.Controls.Add(Me.ftabMain)
        Me.Name = "uiTrnVoid"
        Me.Controls.SetChildIndex(Me.ftabMain, 0)
        CType(Me.tbl_MstSetting, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ftabMain.ResumeLayout(False)
        Me.ftabMain_List.ResumeLayout(False)
        Me.PnlDfMain.ResumeLayout(False)
        CType(Me.DgvTrnVoid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlDfFooter.ResumeLayout(False)
        Me.PnlDfFooter.PerformLayout()
        Me.PnlDfSearch.ResumeLayout(False)
        Me.PnlDfSearch.PerformLayout()
        Me.ftabMain_Data.ResumeLayout(False)
        Me.ftabDataDetil.ResumeLayout(False)
        Me.ftabDataDetil_Advance.ResumeLayout(False)
        CType(Me.DgvTrnVoidAdvance, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ftabDataDetil_AdvanceDetil.ResumeLayout(False)
        CType(Me.dgvTrnVoidAdvanceDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ftabDataDetil_Info.ResumeLayout(False)
        Me.ftabDataDetil_Info.PerformLayout()
        Me.PnlDataMaster.ResumeLayout(False)
        Me.PnlDataMaster.PerformLayout()
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
    Friend WithEvents ftabDataDetil As FlatTabControl.FlatTabControl
    Friend WithEvents ftabDataDetil_Advance As System.Windows.Forms.TabPage
    Friend WithEvents DgvTrnVoidAdvance As System.Windows.Forms.DataGridView
    Friend WithEvents DgvTrnVoid As System.Windows.Forms.DataGridView
    Friend WithEvents lbl_Void_id As System.Windows.Forms.Label
    Friend WithEvents obj_Void_id As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Void_date As System.Windows.Forms.Label
    Friend WithEvents ftabDataDetil_Info As System.Windows.Forms.TabPage
    Friend WithEvents obj_Created_by As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Approved_by As System.Windows.Forms.Label
    Friend WithEvents lbl_Created_by As System.Windows.Forms.Label
    Friend WithEvents lbl_Posted_dt As System.Windows.Forms.Label
    Friend WithEvents obj_Created_dt As System.Windows.Forms.TextBox
    Friend WithEvents obj_Posted_dt As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Created_dt As System.Windows.Forms.Label
    Friend WithEvents lbl_Posted_by As System.Windows.Forms.Label
    Friend WithEvents obj_Modified_by As System.Windows.Forms.TextBox
    Friend WithEvents obj_Posted_by As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Modified_by As System.Windows.Forms.Label
    Friend WithEvents lbl_Approved_dt As System.Windows.Forms.Label
    Friend WithEvents obj_Modified_dt As System.Windows.Forms.TextBox
    Friend WithEvents obj_Approved_dt As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Modified_dt As System.Windows.Forms.Label
    Friend WithEvents obj_Approved_by As System.Windows.Forms.TextBox
    Friend WithEvents btnLoadAdvance As System.Windows.Forms.Button
    Friend WithEvents ftabDataDetil_AdvanceDetil As System.Windows.Forms.TabPage
    Friend WithEvents dgvTrnVoidAdvanceDetail As System.Windows.Forms.DataGridView
    Friend WithEvents obj_Void_date As System.Windows.Forms.DateTimePicker
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents chk_status_search As System.Windows.Forms.CheckBox
    Friend WithEvents obj_status_search As System.Windows.Forms.ComboBox
    Friend WithEvents chk_voidid_search As System.Windows.Forms.CheckBox
    Friend WithEvents obj_voidid_search As System.Windows.Forms.TextBox

End Class

