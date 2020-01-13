<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgTrnJurnal_PV_select_RD
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
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.gridControlSelectRD = New DevExpress.XtraGrid.GridControl()
        Me.dgvTrnJurnalPVselectRD = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn11 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn12 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn13 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn14 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn15 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn16 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemComboBox1 = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.GridColumn17 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn18 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.gridControlSelectRD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvTrnJurnalPVselectRD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(426, 10)
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
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.Controls.Add(Me.TableLayoutPanel1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 404)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(588, 50)
        Me.Panel2.TabIndex = 3
        '
        'Panel3
        '
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(588, 38)
        Me.Panel3.TabIndex = 5
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.gridControlSelectRD)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 38)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(588, 366)
        Me.Panel1.TabIndex = 6
        '
        'gridControlSelectRD
        '
        Me.gridControlSelectRD.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridControlSelectRD.Location = New System.Drawing.Point(0, 0)
        Me.gridControlSelectRD.MainView = Me.dgvTrnJurnalPVselectRD
        Me.gridControlSelectRD.Name = "gridControlSelectRD"
        Me.gridControlSelectRD.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemComboBox1})
        Me.gridControlSelectRD.Size = New System.Drawing.Size(588, 366)
        Me.gridControlSelectRD.TabIndex = 1
        Me.gridControlSelectRD.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.dgvTrnJurnalPVselectRD})
        '
        'dgvTrnJurnalPVselectRD
        '
        Me.dgvTrnJurnalPVselectRD.Appearance.Empty.BackColor = System.Drawing.Color.LavenderBlush
        Me.dgvTrnJurnalPVselectRD.Appearance.Empty.Options.UseBackColor = True
        Me.dgvTrnJurnalPVselectRD.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn6, Me.GridColumn3, Me.GridColumn4, Me.GridColumn5, Me.GridColumn7, Me.GridColumn8, Me.GridColumn9, Me.GridColumn10, Me.GridColumn11, Me.GridColumn12, Me.GridColumn13, Me.GridColumn14, Me.GridColumn15, Me.GridColumn16, Me.GridColumn17, Me.GridColumn18})
        Me.dgvTrnJurnalPVselectRD.GridControl = Me.gridControlSelectRD
        Me.dgvTrnJurnalPVselectRD.Name = "dgvTrnJurnalPVselectRD"
        Me.dgvTrnJurnalPVselectRD.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.dgvTrnJurnalPVselectRD.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.dgvTrnJurnalPVselectRD.OptionsBehavior.Editable = False
        Me.dgvTrnJurnalPVselectRD.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.dgvTrnJurnalPVselectRD.OptionsView.ColumnAutoWidth = False
        Me.dgvTrnJurnalPVselectRD.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Tanda Terima ID"
        Me.GridColumn1.FieldName = "tandaterima_id"
        Me.GridColumn1.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[True]
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 0
        Me.GridColumn1.Width = 100
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Line"
        Me.GridColumn2.FieldName = "tandaterima_line"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 1
        Me.GridColumn2.Width = 40
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Invoice No."
        Me.GridColumn6.FieldName = "remaks"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 2
        Me.GridColumn6.Width = 120
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Order ID"
        Me.GridColumn3.FieldName = "order_id"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 3
        Me.GridColumn3.Width = 100
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Order Desc"
        Me.GridColumn4.FieldName = "tandaterima_descr"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 4
        Me.GridColumn4.Width = 230
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Receipt No."
        Me.GridColumn5.FieldName = "receipt_no"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 5
        Me.GridColumn5.Width = 100
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "Invoice date"
        Me.GridColumn7.FieldName = "tandaterima_invoicedate"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 6
        Me.GridColumn7.Width = 100
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "Tax No."
        Me.GridColumn8.FieldName = "tax_no"
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumn8.Visible = True
        Me.GridColumn8.VisibleIndex = 7
        Me.GridColumn8.Width = 90
        '
        'GridColumn9
        '
        Me.GridColumn9.Caption = "Curr."
        Me.GridColumn9.FieldName = "currency_shortname"
        Me.GridColumn9.Name = "GridColumn9"
        Me.GridColumn9.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumn9.Visible = True
        Me.GridColumn9.VisibleIndex = 8
        Me.GridColumn9.Width = 50
        '
        'GridColumn10
        '
        Me.GridColumn10.Caption = "Order Balance"
        Me.GridColumn10.FieldName = "tandaterima_foreignreal"
        Me.GridColumn10.Name = "GridColumn10"
        Me.GridColumn10.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumn10.Visible = True
        Me.GridColumn10.VisibleIndex = 9
        Me.GridColumn10.Width = 90
        '
        'GridColumn11
        '
        Me.GridColumn11.Caption = "Amount"
        Me.GridColumn11.FieldName = "tandaterima_foreign"
        Me.GridColumn11.Name = "GridColumn11"
        Me.GridColumn11.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumn11.Visible = True
        Me.GridColumn11.VisibleIndex = 10
        Me.GridColumn11.Width = 100
        '
        'GridColumn12
        '
        Me.GridColumn12.Caption = "PPh Amount"
        Me.GridColumn12.FieldName = "tandaterima_pph"
        Me.GridColumn12.Name = "GridColumn12"
        Me.GridColumn12.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumn12.Visible = True
        Me.GridColumn12.VisibleIndex = 11
        Me.GridColumn12.Width = 100
        '
        'GridColumn13
        '
        Me.GridColumn13.Caption = "PPn Amount"
        Me.GridColumn13.FieldName = "tandaterima_ppn"
        Me.GridColumn13.Name = "GridColumn13"
        Me.GridColumn13.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumn13.Visible = True
        Me.GridColumn13.VisibleIndex = 12
        Me.GridColumn13.Width = 100
        '
        'GridColumn14
        '
        Me.GridColumn14.Caption = "Total Amount"
        Me.GridColumn14.FieldName = "tandaterima_total"
        Me.GridColumn14.Name = "GridColumn14"
        Me.GridColumn14.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumn14.Visible = True
        Me.GridColumn14.VisibleIndex = 13
        Me.GridColumn14.Width = 110
        '
        'GridColumn15
        '
        Me.GridColumn15.Caption = "Type"
        Me.GridColumn15.FieldName = "tandaterima_type"
        Me.GridColumn15.Name = "GridColumn15"
        Me.GridColumn15.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumn15.Visible = True
        Me.GridColumn15.VisibleIndex = 14
        Me.GridColumn15.Width = 55
        '
        'GridColumn16
        '
        Me.GridColumn16.Caption = "Due Date"
        Me.GridColumn16.FieldName = "tandaterima_duedate"
        Me.GridColumn16.Name = "GridColumn16"
        Me.GridColumn16.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumn16.Visible = True
        Me.GridColumn16.VisibleIndex = 15
        Me.GridColumn16.Width = 90
        '
        'RepositoryItemComboBox1
        '
        Me.RepositoryItemComboBox1.AutoHeight = False
        Me.RepositoryItemComboBox1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemComboBox1.Name = "RepositoryItemComboBox1"
        '
        'GridColumn17
        '
        Me.GridColumn17.Caption = "Outstanding Sisa"
        Me.GridColumn17.FieldName = "outstanding_inv_sisa"
        Me.GridColumn17.Name = "GridColumn17"
        Me.GridColumn17.Visible = True
        Me.GridColumn17.VisibleIndex = 16
        Me.GridColumn17.Width = 100
        '
        'GridColumn18
        '
        Me.GridColumn18.Caption = "Rate"
        Me.GridColumn18.FieldName = "tandaterima_foreginrate"
        Me.GridColumn18.Name = "GridColumn18"
        '
        'dlgTrnJurnal_PV_select_RD
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LavenderBlush
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(588, 454)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgTrnJurnal_PV_select_RD"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Select Received Document"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.gridControlSelectRD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvTrnJurnalPVselectRD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents gridControlSelectRD As DevExpress.XtraGrid.GridControl
    Friend WithEvents dgvTrnJurnalPVselectRD As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn11 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn12 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn13 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn14 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn15 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn16 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemComboBox1 As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents GridColumn17 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn18 As DevExpress.XtraGrid.Columns.GridColumn

End Class
