<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class uiMstCaReport
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(uiMstCaReport))
        Me.ftabMain = New FlatTabControl.FlatTabControl()
        Me.ftabMain_List = New System.Windows.Forms.TabPage()
        Me.PnlDfMain = New System.Windows.Forms.Panel()
        Me.DgvCaReport = New System.Windows.Forms.DataGridView()
        Me.PnlDfSearch = New System.Windows.Forms.Panel()
        Me.cbo_typereport = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboSearchChannel = New System.Windows.Forms.ComboBox()
        Me.ftabMain_Data = New System.Windows.Forms.TabPage()
        Me.ftabDataDetil = New FlatTabControl.FlatTabControl()
        Me.ftabDataDetil_Detil = New System.Windows.Forms.TabPage()
        Me.DgvMstCaReport_detil = New System.Windows.Forms.DataGridView()
        Me.PnlDataMaster = New System.Windows.Forms.Panel()
        Me.obj_Code = New System.Windows.Forms.TextBox()
        Me.lbl_Code = New System.Windows.Forms.Label()
        Me.obj_Row = New System.Windows.Forms.TextBox()
        Me.lbl_Row = New System.Windows.Forms.Label()
        Me.obj_Descr = New System.Windows.Forms.TextBox()
        Me.lbl_Descr = New System.Windows.Forms.Label()
        Me.obj_Remark = New System.Windows.Forms.TextBox()
        Me.lbl_Remark = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btn_deldetail = New System.Windows.Forms.Button()
        Me.btn_adddetail = New System.Windows.Forms.Button()
        Me.btn_del = New System.Windows.Forms.Button()
        Me.btn_add = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.obj_groupCode = New System.Windows.Forms.TextBox()
        CType(Me.tbl_MstSetting, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ftabMain.SuspendLayout()
        Me.ftabMain_List.SuspendLayout()
        Me.PnlDfMain.SuspendLayout()
        CType(Me.DgvCaReport, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlDfSearch.SuspendLayout()
        Me.ftabMain_Data.SuspendLayout()
        Me.ftabDataDetil.SuspendLayout()
        Me.ftabDataDetil_Detil.SuspendLayout()
        CType(Me.DgvMstCaReport_detil, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlDataMaster.SuspendLayout()
        Me.Panel1.SuspendLayout()
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
        Me.ftabMain.Size = New System.Drawing.Size(747, 487)
        Me.ftabMain.TabIndex = 1
        '
        'ftabMain_List
        '
        Me.ftabMain_List.BackColor = System.Drawing.Color.White
        Me.ftabMain_List.Controls.Add(Me.PnlDfMain)
        Me.ftabMain_List.Controls.Add(Me.PnlDfSearch)
        Me.ftabMain_List.Location = New System.Drawing.Point(4, 25)
        Me.ftabMain_List.Name = "ftabMain_List"
        Me.ftabMain_List.Padding = New System.Windows.Forms.Padding(3)
        Me.ftabMain_List.Size = New System.Drawing.Size(739, 458)
        Me.ftabMain_List.TabIndex = 0
        Me.ftabMain_List.Text = "List"
        '
        'PnlDfMain
        '
        Me.PnlDfMain.Controls.Add(Me.DgvCaReport)
        Me.PnlDfMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnlDfMain.Location = New System.Drawing.Point(3, 86)
        Me.PnlDfMain.Name = "PnlDfMain"
        Me.PnlDfMain.Size = New System.Drawing.Size(733, 369)
        Me.PnlDfMain.TabIndex = 1
        '
        'DgvCaReport
        '
        Me.DgvCaReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgvCaReport.DefaultCellStyle = DataGridViewCellStyle1
        Me.DgvCaReport.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvCaReport.Location = New System.Drawing.Point(0, 0)
        Me.DgvCaReport.MultiSelect = False
        Me.DgvCaReport.Name = "DgvCaReport"
        Me.DgvCaReport.Size = New System.Drawing.Size(733, 369)
        Me.DgvCaReport.TabIndex = 0
        '
        'PnlDfSearch
        '
        Me.PnlDfSearch.Controls.Add(Me.cbo_typereport)
        Me.PnlDfSearch.Controls.Add(Me.Label2)
        Me.PnlDfSearch.Controls.Add(Me.Label1)
        Me.PnlDfSearch.Controls.Add(Me.cboSearchChannel)
        Me.PnlDfSearch.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlDfSearch.Location = New System.Drawing.Point(3, 3)
        Me.PnlDfSearch.Name = "PnlDfSearch"
        Me.PnlDfSearch.Size = New System.Drawing.Size(733, 83)
        Me.PnlDfSearch.TabIndex = 0
        '
        'cbo_typereport
        '
        Me.cbo_typereport.FormattingEnabled = True
        Me.cbo_typereport.Location = New System.Drawing.Point(77, 42)
        Me.cbo_typereport.Name = "cbo_typereport"
        Me.cbo_typereport.Size = New System.Drawing.Size(243, 21)
        Me.cbo_typereport.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Channel"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(31, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Type"
        '
        'cboSearchChannel
        '
        Me.cboSearchChannel.BackColor = System.Drawing.Color.Honeydew
        Me.cboSearchChannel.FormattingEnabled = True
        Me.cboSearchChannel.Location = New System.Drawing.Point(78, 8)
        Me.cboSearchChannel.Name = "cboSearchChannel"
        Me.cboSearchChannel.Size = New System.Drawing.Size(91, 21)
        Me.cboSearchChannel.TabIndex = 3
        '
        'ftabMain_Data
        '
        Me.ftabMain_Data.BackColor = System.Drawing.Color.White
        Me.ftabMain_Data.Controls.Add(Me.ftabDataDetil)
        Me.ftabMain_Data.Controls.Add(Me.PnlDataMaster)
        Me.ftabMain_Data.Location = New System.Drawing.Point(4, 25)
        Me.ftabMain_Data.Name = "ftabMain_Data"
        Me.ftabMain_Data.Padding = New System.Windows.Forms.Padding(3)
        Me.ftabMain_Data.Size = New System.Drawing.Size(739, 458)
        Me.ftabMain_Data.TabIndex = 1
        Me.ftabMain_Data.Text = "Data"
        '
        'ftabDataDetil
        '
        Me.ftabDataDetil.Controls.Add(Me.ftabDataDetil_Detil)
        Me.ftabDataDetil.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ftabDataDetil.Location = New System.Drawing.Point(3, 116)
        Me.ftabDataDetil.myBackColor = System.Drawing.Color.White
        Me.ftabDataDetil.Name = "ftabDataDetil"
        Me.ftabDataDetil.SelectedIndex = 0
        Me.ftabDataDetil.Size = New System.Drawing.Size(733, 339)
        Me.ftabDataDetil.TabIndex = 3
        '
        'ftabDataDetil_Detil
        '
        Me.ftabDataDetil_Detil.BackColor = System.Drawing.Color.White
        Me.ftabDataDetil_Detil.Controls.Add(Me.DgvMstCaReport_detil)
        Me.ftabDataDetil_Detil.Location = New System.Drawing.Point(4, 25)
        Me.ftabDataDetil_Detil.Name = "ftabDataDetil_Detil"
        Me.ftabDataDetil_Detil.Padding = New System.Windows.Forms.Padding(3)
        Me.ftabDataDetil_Detil.Size = New System.Drawing.Size(725, 310)
        Me.ftabDataDetil_Detil.TabIndex = 0
        Me.ftabDataDetil_Detil.Text = "Detil"
        '
        'DgvMstCaReport_detil
        '
        Me.DgvMstCaReport_detil.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvMstCaReport_detil.Location = New System.Drawing.Point(3, 3)
        Me.DgvMstCaReport_detil.MultiSelect = False
        Me.DgvMstCaReport_detil.Name = "DgvMstCaReport_detil"
        Me.DgvMstCaReport_detil.Size = New System.Drawing.Size(719, 304)
        Me.DgvMstCaReport_detil.TabIndex = 0
        '
        'PnlDataMaster
        '
        Me.PnlDataMaster.AutoScroll = True
        Me.PnlDataMaster.BackColor = System.Drawing.Color.WhiteSmoke
        Me.PnlDataMaster.Controls.Add(Me.obj_Code)
        Me.PnlDataMaster.Controls.Add(Me.lbl_Code)
        Me.PnlDataMaster.Controls.Add(Me.obj_Row)
        Me.PnlDataMaster.Controls.Add(Me.lbl_Row)
        Me.PnlDataMaster.Controls.Add(Me.obj_Descr)
        Me.PnlDataMaster.Controls.Add(Me.lbl_Descr)
        Me.PnlDataMaster.Controls.Add(Me.obj_groupCode)
        Me.PnlDataMaster.Controls.Add(Me.Label3)
        Me.PnlDataMaster.Controls.Add(Me.obj_Remark)
        Me.PnlDataMaster.Controls.Add(Me.lbl_Remark)
        Me.PnlDataMaster.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlDataMaster.Location = New System.Drawing.Point(3, 3)
        Me.PnlDataMaster.Name = "PnlDataMaster"
        Me.PnlDataMaster.Size = New System.Drawing.Size(733, 113)
        Me.PnlDataMaster.TabIndex = 0
        '
        'obj_Code
        '
        Me.obj_Code.Location = New System.Drawing.Point(144, 7)
        Me.obj_Code.Name = "obj_Code"
        Me.obj_Code.ReadOnly = True
        Me.obj_Code.Size = New System.Drawing.Size(36, 20)
        Me.obj_Code.TabIndex = 1
        '
        'lbl_Code
        '
        Me.lbl_Code.AutoSize = True
        Me.lbl_Code.Location = New System.Drawing.Point(7, 7)
        Me.lbl_Code.Name = "lbl_Code"
        Me.lbl_Code.Size = New System.Drawing.Size(32, 13)
        Me.lbl_Code.TabIndex = 0
        Me.lbl_Code.Text = "Code"
        '
        'obj_Row
        '
        Me.obj_Row.Location = New System.Drawing.Point(144, 33)
        Me.obj_Row.Name = "obj_Row"
        Me.obj_Row.ReadOnly = True
        Me.obj_Row.Size = New System.Drawing.Size(36, 20)
        Me.obj_Row.TabIndex = 1
        '
        'lbl_Row
        '
        Me.lbl_Row.AutoSize = True
        Me.lbl_Row.Location = New System.Drawing.Point(7, 33)
        Me.lbl_Row.Name = "lbl_Row"
        Me.lbl_Row.Size = New System.Drawing.Size(29, 13)
        Me.lbl_Row.TabIndex = 0
        Me.lbl_Row.Text = "Row"
        '
        'obj_Descr
        '
        Me.obj_Descr.Location = New System.Drawing.Point(144, 59)
        Me.obj_Descr.Multiline = True
        Me.obj_Descr.Name = "obj_Descr"
        Me.obj_Descr.ReadOnly = True
        Me.obj_Descr.Size = New System.Drawing.Size(551, 38)
        Me.obj_Descr.TabIndex = 1
        '
        'lbl_Descr
        '
        Me.lbl_Descr.AutoSize = True
        Me.lbl_Descr.Location = New System.Drawing.Point(7, 59)
        Me.lbl_Descr.Name = "lbl_Descr"
        Me.lbl_Descr.Size = New System.Drawing.Size(35, 13)
        Me.lbl_Descr.TabIndex = 0
        Me.lbl_Descr.Text = "Descr"
        '
        'obj_Remark
        '
        Me.obj_Remark.Location = New System.Drawing.Point(387, 7)
        Me.obj_Remark.Name = "obj_Remark"
        Me.obj_Remark.ReadOnly = True
        Me.obj_Remark.Size = New System.Drawing.Size(308, 20)
        Me.obj_Remark.TabIndex = 1
        '
        'lbl_Remark
        '
        Me.lbl_Remark.AutoSize = True
        Me.lbl_Remark.Location = New System.Drawing.Point(319, 10)
        Me.lbl_Remark.Name = "lbl_Remark"
        Me.lbl_Remark.Size = New System.Drawing.Size(44, 13)
        Me.lbl_Remark.TabIndex = 0
        Me.lbl_Remark.Text = "Remark"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btn_deldetail)
        Me.Panel1.Controls.Add(Me.btn_adddetail)
        Me.Panel1.Controls.Add(Me.btn_del)
        Me.Panel1.Controls.Add(Me.btn_add)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 513)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(753, 35)
        Me.Panel1.TabIndex = 3
        '
        'btn_deldetail
        '
        Me.btn_deldetail.BackColor = System.Drawing.Color.PeachPuff
        Me.btn_deldetail.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_deldetail.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_deldetail.ForeColor = System.Drawing.Color.Red
        Me.btn_deldetail.Location = New System.Drawing.Point(88, 6)
        Me.btn_deldetail.Name = "btn_deldetail"
        Me.btn_deldetail.Size = New System.Drawing.Size(75, 23)
        Me.btn_deldetail.TabIndex = 4
        Me.btn_deldetail.Text = "[ - ]"
        Me.btn_deldetail.UseVisualStyleBackColor = False
        Me.btn_deldetail.Visible = False
        '
        'btn_adddetail
        '
        Me.btn_adddetail.BackColor = System.Drawing.Color.PeachPuff
        Me.btn_adddetail.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_adddetail.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_adddetail.ForeColor = System.Drawing.Color.Black
        Me.btn_adddetail.Location = New System.Drawing.Point(7, 6)
        Me.btn_adddetail.Name = "btn_adddetail"
        Me.btn_adddetail.Size = New System.Drawing.Size(75, 23)
        Me.btn_adddetail.TabIndex = 3
        Me.btn_adddetail.Text = "[ + ]"
        Me.btn_adddetail.UseVisualStyleBackColor = False
        Me.btn_adddetail.Visible = False
        '
        'btn_del
        '
        Me.btn_del.BackColor = System.Drawing.Color.SeaShell
        Me.btn_del.Location = New System.Drawing.Point(88, 6)
        Me.btn_del.Name = "btn_del"
        Me.btn_del.Size = New System.Drawing.Size(75, 23)
        Me.btn_del.TabIndex = 2
        Me.btn_del.Text = "[ - ]"
        Me.btn_del.UseVisualStyleBackColor = False
        '
        'btn_add
        '
        Me.btn_add.BackColor = System.Drawing.Color.SeaShell
        Me.btn_add.Location = New System.Drawing.Point(7, 6)
        Me.btn_add.Name = "btn_add"
        Me.btn_add.Size = New System.Drawing.Size(75, 23)
        Me.btn_add.TabIndex = 1
        Me.btn_add.Text = "[ + ]"
        Me.btn_add.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(319, 33)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Group Code"
        '
        'obj_groupCode
        '
        Me.obj_groupCode.Location = New System.Drawing.Point(387, 30)
        Me.obj_groupCode.Name = "obj_groupCode"
        Me.obj_groupCode.ReadOnly = True
        Me.obj_groupCode.Size = New System.Drawing.Size(308, 20)
        Me.obj_groupCode.TabIndex = 1
        '
        'uiMstCaReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ftabMain)
        Me.Name = "uiMstCaReport"
        Me.Controls.SetChildIndex(Me.ftabMain, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        CType(Me.tbl_MstSetting, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ftabMain.ResumeLayout(False)
        Me.ftabMain_List.ResumeLayout(False)
        Me.PnlDfMain.ResumeLayout(False)
        CType(Me.DgvCaReport, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlDfSearch.ResumeLayout(False)
        Me.PnlDfSearch.PerformLayout()
        Me.ftabMain_Data.ResumeLayout(False)
        Me.ftabDataDetil.ResumeLayout(False)
        Me.ftabDataDetil_Detil.ResumeLayout(False)
        CType(Me.DgvMstCaReport_detil, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlDataMaster.ResumeLayout(False)
        Me.PnlDataMaster.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ftabMain As FlatTabControl.FlatTabControl
    Friend WithEvents ftabMain_List As System.Windows.Forms.TabPage
    Friend WithEvents ftabMain_Data As System.Windows.Forms.TabPage
    Friend WithEvents PnlDfSearch As System.Windows.Forms.Panel
    Friend WithEvents PnlDfMain As System.Windows.Forms.Panel
    Friend WithEvents PnlDataMaster As System.Windows.Forms.Panel
    Friend WithEvents ftabDataDetil As FlatTabControl.FlatTabControl
    Friend WithEvents ftabDataDetil_Detil As System.Windows.Forms.TabPage
    Friend WithEvents DgvCaReport As System.Windows.Forms.DataGridView
    Friend WithEvents DgvMstCaReport_detil As System.Windows.Forms.DataGridView
    Friend WithEvents lbl_Code As System.Windows.Forms.Label
    Friend WithEvents obj_Code As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Row As System.Windows.Forms.Label
    Friend WithEvents obj_Row As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Descr As System.Windows.Forms.Label
    Friend WithEvents obj_Descr As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Remark As System.Windows.Forms.Label
    Friend WithEvents obj_Remark As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btn_del As System.Windows.Forms.Button
    Friend WithEvents btn_add As System.Windows.Forms.Button
    Friend WithEvents btn_deldetail As System.Windows.Forms.Button
    Friend WithEvents btn_adddetail As System.Windows.Forms.Button
    Friend WithEvents cboSearchChannel As System.Windows.Forms.ComboBox
    Friend WithEvents cbo_typereport As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents obj_groupCode As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label

End Class

