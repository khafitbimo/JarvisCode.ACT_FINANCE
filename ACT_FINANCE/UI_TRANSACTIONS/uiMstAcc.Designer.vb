<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class uiMstAcc
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(uiMstAcc))
        Me.ftabMain_List = New System.Windows.Forms.TabPage()
        Me.PnlDfMain = New System.Windows.Forms.Panel()
        Me.tList_mst_acc = New DevExpress.XtraTreeList.TreeList()
        Me.acc_name = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.acc_id = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.index = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.acc_mother = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.tl_enry_dt = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnExport = New System.Windows.Forms.Button()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AddNodeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ftabMain = New FlatTabControl.FlatTabControl()
        Me.ftabMain_Data = New System.Windows.Forms.TabPage()
        Me.cbParent = New System.Windows.Forms.ComboBox()
        Me.txtIndex = New System.Windows.Forms.TextBox()
        Me.txtShort = New System.Windows.Forms.TextBox()
        Me.txtAccName = New System.Windows.Forms.TextBox()
        Me.txtAcc_ca_Id = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        CType(Me.tbl_MstSetting, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ftabMain_List.SuspendLayout()
        Me.PnlDfMain.SuspendLayout()
        CType(Me.tList_mst_acc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.ftabMain.SuspendLayout()
        Me.ftabMain_Data.SuspendLayout()
        Me.SuspendLayout()
        '
        'ftabMain_List
        '
        Me.ftabMain_List.BackColor = System.Drawing.Color.Lavender
        Me.ftabMain_List.Controls.Add(Me.PnlDfMain)
        Me.ftabMain_List.Controls.Add(Me.Panel1)
        Me.ftabMain_List.Location = New System.Drawing.Point(4, 25)
        Me.ftabMain_List.Name = "ftabMain_List"
        Me.ftabMain_List.Padding = New System.Windows.Forms.Padding(3)
        Me.ftabMain_List.Size = New System.Drawing.Size(739, 488)
        Me.ftabMain_List.TabIndex = 0
        Me.ftabMain_List.Text = "List"
        '
        'PnlDfMain
        '
        Me.PnlDfMain.Controls.Add(Me.tList_mst_acc)
        Me.PnlDfMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnlDfMain.Location = New System.Drawing.Point(3, 3)
        Me.PnlDfMain.Name = "PnlDfMain"
        Me.PnlDfMain.Size = New System.Drawing.Size(733, 433)
        Me.PnlDfMain.TabIndex = 1
        '
        'tList_mst_acc
        '
        Me.tList_mst_acc.Appearance.EvenRow.BackColor = System.Drawing.Color.WhiteSmoke
        Me.tList_mst_acc.Appearance.EvenRow.Options.UseBackColor = True
        Me.tList_mst_acc.Appearance.OddRow.BackColor = System.Drawing.Color.White
        Me.tList_mst_acc.Appearance.OddRow.Options.UseBackColor = True
        Me.tList_mst_acc.Columns.AddRange(New DevExpress.XtraTreeList.Columns.TreeListColumn() {Me.acc_name, Me.acc_id, Me.index, Me.acc_mother, Me.tl_enry_dt})
        Me.tList_mst_acc.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tList_mst_acc.Location = New System.Drawing.Point(0, 0)
        Me.tList_mst_acc.Name = "tList_mst_acc"
        Me.tList_mst_acc.OptionsBehavior.Editable = False
        Me.tList_mst_acc.OptionsBehavior.MoveOnEdit = False
        Me.tList_mst_acc.OptionsBehavior.PopulateServiceColumns = True
        Me.tList_mst_acc.OptionsLayout.AddNewColumns = False
        Me.tList_mst_acc.OptionsPrint.UsePrintStyles = True
        Me.tList_mst_acc.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.tList_mst_acc.OptionsView.AutoWidth = False
        Me.tList_mst_acc.OptionsView.EnableAppearanceEvenRow = True
        Me.tList_mst_acc.OptionsView.EnableAppearanceOddRow = True
        Me.tList_mst_acc.Size = New System.Drawing.Size(733, 433)
        Me.tList_mst_acc.TabIndex = 0
        '
        'acc_name
        '
        Me.acc_name.Caption = "Name"
        Me.acc_name.FieldName = "acc_ca_name"
        Me.acc_name.Name = "acc_name"
        Me.acc_name.OptionsColumn.AllowMoveToCustomizationForm = False
        Me.acc_name.Visible = True
        Me.acc_name.VisibleIndex = 0
        Me.acc_name.Width = 363
        '
        'acc_id
        '
        Me.acc_id.Caption = "Acc ID"
        Me.acc_id.FieldName = "acc_ca_id"
        Me.acc_id.Name = "acc_id"
        Me.acc_id.Visible = True
        Me.acc_id.VisibleIndex = 1
        Me.acc_id.Width = 118
        '
        'index
        '
        Me.index.Caption = "Index"
        Me.index.FieldName = "acc_ca_idx"
        Me.index.Name = "index"
        Me.index.OptionsColumn.AllowMoveToCustomizationForm = False
        Me.index.Visible = True
        Me.index.VisibleIndex = 2
        Me.index.Width = 217
        '
        'acc_mother
        '
        Me.acc_mother.Caption = "mother"
        Me.acc_mother.FieldName = "acc_ca_mother"
        Me.acc_mother.Name = "acc_mother"
        '
        'tl_enry_dt
        '
        Me.tl_enry_dt.Caption = "Entry Date"
        Me.tl_enry_dt.FieldName = "acc_ca_entry_dt"
        Me.tl_enry_dt.Format.FormatString = "dd MMM yyyy"
        Me.tl_enry_dt.Format.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.tl_enry_dt.Name = "tl_enry_dt"
        Me.tl_enry_dt.OptionsColumn.AllowMoveToCustomizationForm = False
        Me.tl_enry_dt.Width = 150
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnExport)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(3, 436)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(733, 49)
        Me.Panel1.TabIndex = 2
        '
        'btnExport
        '
        Me.btnExport.Location = New System.Drawing.Point(5, 9)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(75, 23)
        Me.btnExport.TabIndex = 0
        Me.btnExport.Text = "Export"
        Me.btnExport.UseVisualStyleBackColor = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddNodeToolStripMenuItem, Me.EditToolStripMenuItem, Me.DeleteToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(128, 70)
        '
        'AddNodeToolStripMenuItem
        '
        Me.AddNodeToolStripMenuItem.Name = "AddNodeToolStripMenuItem"
        Me.AddNodeToolStripMenuItem.Size = New System.Drawing.Size(127, 22)
        Me.AddNodeToolStripMenuItem.Text = "&Add Child"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(127, 22)
        Me.EditToolStripMenuItem.Text = "&Edit"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(127, 22)
        Me.DeleteToolStripMenuItem.Text = "&Delete"
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
        'ftabMain_Data
        '
        Me.ftabMain_Data.BackColor = System.Drawing.Color.Lavender
        Me.ftabMain_Data.Controls.Add(Me.cbParent)
        Me.ftabMain_Data.Controls.Add(Me.txtIndex)
        Me.ftabMain_Data.Controls.Add(Me.txtShort)
        Me.ftabMain_Data.Controls.Add(Me.txtAccName)
        Me.ftabMain_Data.Controls.Add(Me.txtAcc_ca_Id)
        Me.ftabMain_Data.Controls.Add(Me.Label5)
        Me.ftabMain_Data.Controls.Add(Me.Label3)
        Me.ftabMain_Data.Controls.Add(Me.Label4)
        Me.ftabMain_Data.Controls.Add(Me.Label2)
        Me.ftabMain_Data.Controls.Add(Me.Label1)
        Me.ftabMain_Data.Location = New System.Drawing.Point(4, 25)
        Me.ftabMain_Data.Name = "ftabMain_Data"
        Me.ftabMain_Data.Padding = New System.Windows.Forms.Padding(3)
        Me.ftabMain_Data.Size = New System.Drawing.Size(739, 488)
        Me.ftabMain_Data.TabIndex = 1
        Me.ftabMain_Data.Text = "Data"
        '
        'cbParent
        '
        Me.cbParent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbParent.Enabled = False
        Me.cbParent.FormattingEnabled = True
        Me.cbParent.Location = New System.Drawing.Point(135, 143)
        Me.cbParent.Name = "cbParent"
        Me.cbParent.Size = New System.Drawing.Size(153, 21)
        Me.cbParent.TabIndex = 5
        '
        'txtIndex
        '
        Me.txtIndex.Enabled = False
        Me.txtIndex.Location = New System.Drawing.Point(135, 112)
        Me.txtIndex.Name = "txtIndex"
        Me.txtIndex.Size = New System.Drawing.Size(270, 20)
        Me.txtIndex.TabIndex = 4
        '
        'txtShort
        '
        Me.txtShort.Location = New System.Drawing.Point(135, 84)
        Me.txtShort.Name = "txtShort"
        Me.txtShort.Size = New System.Drawing.Size(289, 20)
        Me.txtShort.TabIndex = 3
        '
        'txtAccName
        '
        Me.txtAccName.Location = New System.Drawing.Point(135, 56)
        Me.txtAccName.Name = "txtAccName"
        Me.txtAccName.Size = New System.Drawing.Size(289, 20)
        Me.txtAccName.TabIndex = 2
        '
        'txtAcc_ca_Id
        '
        Me.txtAcc_ca_Id.Location = New System.Drawing.Point(135, 29)
        Me.txtAcc_ca_Id.MaxLength = 7
        Me.txtAcc_ca_Id.Name = "txtAcc_ca_Id"
        Me.txtAcc_ca_Id.ReadOnly = True
        Me.txtAcc_ca_Id.Size = New System.Drawing.Size(127, 20)
        Me.txtAcc_ca_Id.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(29, 146)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(38, 13)
        Me.Label5.TabIndex = 26
        Me.Label5.Text = "Parent"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(29, 114)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 13)
        Me.Label3.TabIndex = 23
        Me.Label3.Text = "Acc Index"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(29, 86)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(85, 13)
        Me.Label4.TabIndex = 24
        Me.Label4.Text = "Acc Short Name"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(29, 58)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 13)
        Me.Label2.TabIndex = 25
        Me.Label2.Text = "Acc Name"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(29, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 22
        Me.Label1.Text = "Acc ID"
        '
        'uiMstAcc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.Controls.Add(Me.ftabMain)
        Me.Name = "uiMstAcc"
        Me.Controls.SetChildIndex(Me.ftabMain, 0)
        CType(Me.tbl_MstSetting, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ftabMain_List.ResumeLayout(False)
        Me.PnlDfMain.ResumeLayout(False)
        CType(Me.tList_mst_acc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ftabMain.ResumeLayout(False)
        Me.ftabMain_Data.ResumeLayout(False)
        Me.ftabMain_Data.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ftabMain_List As System.Windows.Forms.TabPage
    Friend WithEvents PnlDfMain As System.Windows.Forms.Panel
    Friend WithEvents ftabMain As FlatTabControl.FlatTabControl
    Friend WithEvents tList_mst_acc As DevExpress.XtraTreeList.TreeList
    Friend WithEvents acc_id As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents acc_name As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents index As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents acc_mother As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents tl_enry_dt As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents AddNodeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ftabMain_Data As System.Windows.Forms.TabPage
    Friend WithEvents cbParent As System.Windows.Forms.ComboBox
    Friend WithEvents txtIndex As System.Windows.Forms.TextBox
    Friend WithEvents txtShort As System.Windows.Forms.TextBox
    Friend WithEvents txtAccName As System.Windows.Forms.TextBox
    Friend WithEvents txtAcc_ca_Id As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnExport As System.Windows.Forms.Button
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog

End Class

