<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgSearch_Acc_Ca
    Inherits System.Windows.Forms.Form

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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.obj_search = New System.Windows.Forms.TextBox()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.tList_mst_acc = New DevExpress.XtraTreeList.TreeList()
        Me.acc_name = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.acc_id = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.index = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.acc_mother = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.tl_enry_dt = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.tList_mst_acc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(421, 5)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Cancel"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 13)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Name"
        Me.Label1.Visible = False
        '
        'obj_search
        '
        Me.obj_search.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.obj_search.Location = New System.Drawing.Point(75, 12)
        Me.obj_search.Name = "obj_search"
        Me.obj_search.Size = New System.Drawing.Size(269, 20)
        Me.obj_search.TabIndex = 0
        Me.obj_search.Visible = False
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.TableLayoutPanel1)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl2.Location = New System.Drawing.Point(0, 388)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(577, 40)
        Me.PanelControl2.TabIndex = 19
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.tList_mst_acc)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 1)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(577, 387)
        Me.PanelControl1.TabIndex = 20
        '
        'tList_mst_acc
        '
        Me.tList_mst_acc.Appearance.EvenRow.BackColor = System.Drawing.Color.WhiteSmoke
        Me.tList_mst_acc.Appearance.EvenRow.Options.UseBackColor = True
        Me.tList_mst_acc.Appearance.OddRow.BackColor = System.Drawing.Color.White
        Me.tList_mst_acc.Appearance.OddRow.Options.UseBackColor = True
        Me.tList_mst_acc.Columns.AddRange(New DevExpress.XtraTreeList.Columns.TreeListColumn() {Me.acc_name, Me.acc_id, Me.index, Me.acc_mother, Me.tl_enry_dt})
        Me.tList_mst_acc.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tList_mst_acc.Location = New System.Drawing.Point(2, 2)
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
        Me.tList_mst_acc.Size = New System.Drawing.Size(573, 383)
        Me.tList_mst_acc.TabIndex = 18
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
        Me.acc_id.Width = 60
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
        'dlgSearch_Acc_Ca
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Lavender
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(577, 428)
        Me.Controls.Add(Me.PanelControl1)
        Me.Controls.Add(Me.PanelControl2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.obj_search)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgSearch_Acc_Ca"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Search"
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.tList_mst_acc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents obj_search As System.Windows.Forms.TextBox
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents tList_mst_acc As DevExpress.XtraTreeList.TreeList
    Friend WithEvents acc_name As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents acc_id As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents index As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents acc_mother As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents tl_enry_dt As DevExpress.XtraTreeList.Columns.TreeListColumn

End Class
