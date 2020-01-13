<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class uiMstBank
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(uiMstBank))
        Me.ftabMain = New FlatTabControl.FlatTabControl()
        Me.ftabMain_List = New System.Windows.Forms.TabPage()
        Me.PnlDfMain = New System.Windows.Forms.Panel()
        Me.DgvMstBank = New System.Windows.Forms.DataGridView()
        Me.PnlDfSearch = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtNameBank = New System.Windows.Forms.TextBox()
        Me.txtIDBank = New System.Windows.Forms.TextBox()
        Me.chkNotActive = New System.Windows.Forms.CheckBox()
        Me.chkNameBank = New System.Windows.Forms.CheckBox()
        Me.chkIDbank = New System.Windows.Forms.CheckBox()
        Me.ftabMain_Data = New System.Windows.Forms.TabPage()
        Me.PnlDataMaster = New System.Windows.Forms.Panel()
        Me.obj_Bank_active = New System.Windows.Forms.CheckBox()
        Me.FlatTabControl1 = New FlatTabControl.FlatTabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.DgvMstBankacc = New System.Windows.Forms.DataGridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.DgvMstBankacccontact = New System.Windows.Forms.DataGridView()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.obj_Bank_id = New System.Windows.Forms.TextBox()
        Me.lbl_Bank_id = New System.Windows.Forms.Label()
        Me.obj_Bank_name = New System.Windows.Forms.TextBox()
        Me.lbl_Bank_name = New System.Windows.Forms.Label()
        Me.lbl_Bank_active = New System.Windows.Forms.Label()
        CType(Me.tbl_MstSetting, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ftabMain.SuspendLayout()
        Me.ftabMain_List.SuspendLayout()
        Me.PnlDfMain.SuspendLayout()
        CType(Me.DgvMstBank, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlDfSearch.SuspendLayout()
        Me.ftabMain_Data.SuspendLayout()
        Me.PnlDataMaster.SuspendLayout()
        Me.FlatTabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.DgvMstBankacc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.DgvMstBankacccontact, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
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
        Me.ftabMain_List.BackColor = System.Drawing.Color.White
        Me.ftabMain_List.Controls.Add(Me.PnlDfMain)
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
        Me.PnlDfMain.Controls.Add(Me.DgvMstBank)
        Me.PnlDfMain.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlDfMain.Location = New System.Drawing.Point(3, 85)
        Me.PnlDfMain.Name = "PnlDfMain"
        Me.PnlDfMain.Size = New System.Drawing.Size(733, 398)
        Me.PnlDfMain.TabIndex = 1
        '
        'DgvMstBank
        '
        Me.DgvMstBank.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvMstBank.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvMstBank.Location = New System.Drawing.Point(0, 0)
        Me.DgvMstBank.Name = "DgvMstBank"
        Me.DgvMstBank.Size = New System.Drawing.Size(733, 398)
        Me.DgvMstBank.TabIndex = 0
        '
        'PnlDfSearch
        '
        Me.PnlDfSearch.Controls.Add(Me.Label2)
        Me.PnlDfSearch.Controls.Add(Me.Label1)
        Me.PnlDfSearch.Controls.Add(Me.txtNameBank)
        Me.PnlDfSearch.Controls.Add(Me.txtIDBank)
        Me.PnlDfSearch.Controls.Add(Me.chkNotActive)
        Me.PnlDfSearch.Controls.Add(Me.chkNameBank)
        Me.PnlDfSearch.Controls.Add(Me.chkIDbank)
        Me.PnlDfSearch.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlDfSearch.Location = New System.Drawing.Point(3, 3)
        Me.PnlDfSearch.Name = "PnlDfSearch"
        Me.PnlDfSearch.Size = New System.Drawing.Size(733, 82)
        Me.PnlDfSearch.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Bank Name"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Bank ID"
        '
        'txtNameBank
        '
        Me.txtNameBank.Enabled = False
        Me.txtNameBank.Location = New System.Drawing.Point(108, 43)
        Me.txtNameBank.Name = "txtNameBank"
        Me.txtNameBank.Size = New System.Drawing.Size(100, 20)
        Me.txtNameBank.TabIndex = 4
        '
        'txtIDBank
        '
        Me.txtIDBank.Enabled = False
        Me.txtIDBank.Location = New System.Drawing.Point(108, 13)
        Me.txtIDBank.Name = "txtIDBank"
        Me.txtIDBank.Size = New System.Drawing.Size(100, 20)
        Me.txtIDBank.TabIndex = 3
        '
        'chkNotActive
        '
        Me.chkNotActive.AutoSize = True
        Me.chkNotActive.Location = New System.Drawing.Point(251, 13)
        Me.chkNotActive.Name = "chkNotActive"
        Me.chkNotActive.Size = New System.Drawing.Size(76, 17)
        Me.chkNotActive.TabIndex = 2
        Me.chkNotActive.Text = "Not Active"
        Me.chkNotActive.UseVisualStyleBackColor = True
        '
        'chkNameBank
        '
        Me.chkNameBank.AutoSize = True
        Me.chkNameBank.Location = New System.Drawing.Point(85, 45)
        Me.chkNameBank.Name = "chkNameBank"
        Me.chkNameBank.Size = New System.Drawing.Size(15, 14)
        Me.chkNameBank.TabIndex = 1
        Me.chkNameBank.UseVisualStyleBackColor = True
        '
        'chkIDbank
        '
        Me.chkIDbank.AutoSize = True
        Me.chkIDbank.Location = New System.Drawing.Point(85, 16)
        Me.chkIDbank.Name = "chkIDbank"
        Me.chkIDbank.Size = New System.Drawing.Size(15, 14)
        Me.chkIDbank.TabIndex = 0
        Me.chkIDbank.UseVisualStyleBackColor = True
        '
        'ftabMain_Data
        '
        Me.ftabMain_Data.BackColor = System.Drawing.Color.White
        Me.ftabMain_Data.Controls.Add(Me.PnlDataMaster)
        Me.ftabMain_Data.Location = New System.Drawing.Point(4, 25)
        Me.ftabMain_Data.Name = "ftabMain_Data"
        Me.ftabMain_Data.Padding = New System.Windows.Forms.Padding(3)
        Me.ftabMain_Data.Size = New System.Drawing.Size(739, 488)
        Me.ftabMain_Data.TabIndex = 1
        Me.ftabMain_Data.Text = "Data"
        '
        'PnlDataMaster
        '
        Me.PnlDataMaster.AutoScroll = True
        Me.PnlDataMaster.BackColor = System.Drawing.Color.Gainsboro
        Me.PnlDataMaster.Controls.Add(Me.obj_Bank_active)
        Me.PnlDataMaster.Controls.Add(Me.FlatTabControl1)
        Me.PnlDataMaster.Controls.Add(Me.obj_Bank_id)
        Me.PnlDataMaster.Controls.Add(Me.lbl_Bank_id)
        Me.PnlDataMaster.Controls.Add(Me.obj_Bank_name)
        Me.PnlDataMaster.Controls.Add(Me.lbl_Bank_name)
        Me.PnlDataMaster.Controls.Add(Me.lbl_Bank_active)
        Me.PnlDataMaster.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnlDataMaster.Location = New System.Drawing.Point(3, 3)
        Me.PnlDataMaster.Name = "PnlDataMaster"
        Me.PnlDataMaster.Size = New System.Drawing.Size(733, 482)
        Me.PnlDataMaster.TabIndex = 0
        '
        'obj_Bank_active
        '
        Me.obj_Bank_active.AutoSize = True
        Me.obj_Bank_active.Enabled = False
        Me.obj_Bank_active.Location = New System.Drawing.Point(161, 61)
        Me.obj_Bank_active.Name = "obj_Bank_active"
        Me.obj_Bank_active.Size = New System.Drawing.Size(15, 14)
        Me.obj_Bank_active.TabIndex = 3
        Me.obj_Bank_active.UseVisualStyleBackColor = True
        '
        'FlatTabControl1
        '
        Me.FlatTabControl1.Controls.Add(Me.TabPage1)
        Me.FlatTabControl1.Controls.Add(Me.TabPage2)
        Me.FlatTabControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.FlatTabControl1.Location = New System.Drawing.Point(0, 93)
        Me.FlatTabControl1.myBackColor = System.Drawing.Color.Gainsboro
        Me.FlatTabControl1.Name = "FlatTabControl1"
        Me.FlatTabControl1.SelectedIndex = 0
        Me.FlatTabControl1.Size = New System.Drawing.Size(733, 389)
        Me.FlatTabControl1.TabIndex = 2
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.DgvMstBankacc)
        Me.TabPage1.Controls.Add(Me.Panel1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(725, 360)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Bank Account"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'DgvMstBankacc
        '
        Me.DgvMstBankacc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvMstBankacc.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvMstBankacc.Location = New System.Drawing.Point(3, 3)
        Me.DgvMstBankacc.Name = "DgvMstBankacc"
        Me.DgvMstBankacc.Size = New System.Drawing.Size(719, 328)
        Me.DgvMstBankacc.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(3, 331)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(719, 26)
        Me.Panel1.TabIndex = 5
        '
        'Button2
        '
        Me.Button2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Button2.Location = New System.Drawing.Point(75, 0)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 26)
        Me.Button2.TabIndex = 4
        Me.Button2.Text = "[-] Account"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Button1.Location = New System.Drawing.Point(0, 0)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 26)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "[+] Account"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.DgvMstBankacccontact)
        Me.TabPage2.Controls.Add(Me.Panel2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 25)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(252, 360)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Bank Contact"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'DgvMstBankacccontact
        '
        Me.DgvMstBankacccontact.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvMstBankacccontact.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvMstBankacccontact.Location = New System.Drawing.Point(3, 3)
        Me.DgvMstBankacccontact.Name = "DgvMstBankacccontact"
        Me.DgvMstBankacccontact.Size = New System.Drawing.Size(246, 328)
        Me.DgvMstBankacccontact.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Button3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(3, 331)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(246, 26)
        Me.Panel2.TabIndex = 2
        '
        'Button3
        '
        Me.Button3.Dock = System.Windows.Forms.DockStyle.Left
        Me.Button3.Location = New System.Drawing.Point(0, 0)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 26)
        Me.Button3.TabIndex = 1
        Me.Button3.Text = "[+] Contact"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'obj_Bank_id
        '
        Me.obj_Bank_id.Location = New System.Drawing.Point(160, 9)
        Me.obj_Bank_id.Name = "obj_Bank_id"
        Me.obj_Bank_id.Size = New System.Drawing.Size(100, 20)
        Me.obj_Bank_id.TabIndex = 1
        '
        'lbl_Bank_id
        '
        Me.lbl_Bank_id.AutoSize = True
        Me.lbl_Bank_id.Location = New System.Drawing.Point(23, 9)
        Me.lbl_Bank_id.Name = "lbl_Bank_id"
        Me.lbl_Bank_id.Size = New System.Drawing.Size(18, 13)
        Me.lbl_Bank_id.TabIndex = 0
        Me.lbl_Bank_id.Text = "ID"
        '
        'obj_Bank_name
        '
        Me.obj_Bank_name.Location = New System.Drawing.Point(160, 35)
        Me.obj_Bank_name.Name = "obj_Bank_name"
        Me.obj_Bank_name.Size = New System.Drawing.Size(100, 20)
        Me.obj_Bank_name.TabIndex = 1
        '
        'lbl_Bank_name
        '
        Me.lbl_Bank_name.AutoSize = True
        Me.lbl_Bank_name.Location = New System.Drawing.Point(23, 35)
        Me.lbl_Bank_name.Name = "lbl_Bank_name"
        Me.lbl_Bank_name.Size = New System.Drawing.Size(63, 13)
        Me.lbl_Bank_name.TabIndex = 0
        Me.lbl_Bank_name.Text = "Bank Name"
        '
        'lbl_Bank_active
        '
        Me.lbl_Bank_active.AutoSize = True
        Me.lbl_Bank_active.Location = New System.Drawing.Point(23, 61)
        Me.lbl_Bank_active.Name = "lbl_Bank_active"
        Me.lbl_Bank_active.Size = New System.Drawing.Size(65, 13)
        Me.lbl_Bank_active.TabIndex = 0
        Me.lbl_Bank_active.Text = "Bank Active"
        '
        'uiMstBank
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.Controls.Add(Me.ftabMain)
        Me.Name = "uiMstBank"
        Me.Controls.SetChildIndex(Me.ftabMain, 0)
        CType(Me.tbl_MstSetting, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ftabMain.ResumeLayout(False)
        Me.ftabMain_List.ResumeLayout(False)
        Me.PnlDfMain.ResumeLayout(False)
        CType(Me.DgvMstBank, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlDfSearch.ResumeLayout(False)
        Me.PnlDfSearch.PerformLayout()
        Me.ftabMain_Data.ResumeLayout(False)
        Me.PnlDataMaster.ResumeLayout(False)
        Me.PnlDataMaster.PerformLayout()
        Me.FlatTabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.DgvMstBankacc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        CType(Me.DgvMstBankacccontact, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ftabMain As FlatTabControl.FlatTabControl
    Friend WithEvents ftabMain_List As System.Windows.Forms.TabPage
    Friend WithEvents ftabMain_Data As System.Windows.Forms.TabPage
    Friend WithEvents PnlDfSearch As System.Windows.Forms.Panel
    Friend WithEvents PnlDfMain As System.Windows.Forms.Panel
    Friend WithEvents PnlDataMaster As System.Windows.Forms.Panel
    Friend WithEvents DgvMstBank As System.Windows.Forms.DataGridView
    Friend WithEvents lbl_Bank_id As System.Windows.Forms.Label
    Friend WithEvents obj_Bank_id As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Bank_name As System.Windows.Forms.Label
    Friend WithEvents obj_Bank_name As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Bank_active As System.Windows.Forms.Label
    Friend WithEvents FlatTabControl1 As FlatTabControl.FlatTabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents obj_Bank_active As System.Windows.Forms.CheckBox
    Friend WithEvents txtNameBank As System.Windows.Forms.TextBox
    Friend WithEvents txtIDBank As System.Windows.Forms.TextBox
    Friend WithEvents chkNotActive As System.Windows.Forms.CheckBox
    Friend WithEvents chkNameBank As System.Windows.Forms.CheckBox
    Friend WithEvents chkIDbank As System.Windows.Forms.CheckBox
    Friend WithEvents DgvMstBankacc As System.Windows.Forms.DataGridView
    Friend WithEvents DgvMstBankacccontact As System.Windows.Forms.DataGridView
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel

End Class

