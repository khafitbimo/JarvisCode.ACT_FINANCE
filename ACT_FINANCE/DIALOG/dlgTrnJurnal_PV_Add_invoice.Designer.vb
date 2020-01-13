<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgTrnJurnal_PV_Add_invoice
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.obj_jurnal_id = New System.Windows.Forms.TextBox()
        Me.obj_jurnal_line = New System.Windows.Forms.TextBox()
        Me.obj_jurnal_desc = New System.Windows.Forms.TextBox()
        Me.obj_RD_Id = New System.Windows.Forms.TextBox()
        Me.obj_RD_line = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.obj_invoice_id = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.btn_select_RD = New System.Windows.Forms.Button()
        Me.cbo_acc_id = New System.Windows.Forms.ComboBox()
        Me.cbo_currency_id = New System.Windows.Forms.ComboBox()
        Me.obj_amount_foreign = New DevExpress.XtraEditors.TextEdit()
        Me.obj_rate = New DevExpress.XtraEditors.TextEdit()
        Me.obj_amount_idr = New DevExpress.XtraEditors.TextEdit()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.obj_amount_foreign.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.obj_rate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.obj_amount_idr.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(228, 360)
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
        Me.Label1.Location = New System.Drawing.Point(12, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Jurnal ID"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Jurnal Line"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 68)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Account"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 97)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Desc."
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 164)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(93, 13)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Received Doc. ID"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 193)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(102, 13)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Received Doc. Line"
        '
        'obj_jurnal_id
        '
        Me.obj_jurnal_id.Location = New System.Drawing.Point(132, 14)
        Me.obj_jurnal_id.Name = "obj_jurnal_id"
        Me.obj_jurnal_id.ReadOnly = True
        Me.obj_jurnal_id.Size = New System.Drawing.Size(129, 20)
        Me.obj_jurnal_id.TabIndex = 7
        '
        'obj_jurnal_line
        '
        Me.obj_jurnal_line.Location = New System.Drawing.Point(132, 40)
        Me.obj_jurnal_line.Name = "obj_jurnal_line"
        Me.obj_jurnal_line.ReadOnly = True
        Me.obj_jurnal_line.Size = New System.Drawing.Size(74, 20)
        Me.obj_jurnal_line.TabIndex = 8
        '
        'obj_jurnal_desc
        '
        Me.obj_jurnal_desc.Location = New System.Drawing.Point(132, 94)
        Me.obj_jurnal_desc.Multiline = True
        Me.obj_jurnal_desc.Name = "obj_jurnal_desc"
        Me.obj_jurnal_desc.ReadOnly = True
        Me.obj_jurnal_desc.Size = New System.Drawing.Size(213, 49)
        Me.obj_jurnal_desc.TabIndex = 10
        '
        'obj_RD_Id
        '
        Me.obj_RD_Id.Location = New System.Drawing.Point(132, 158)
        Me.obj_RD_Id.Name = "obj_RD_Id"
        Me.obj_RD_Id.ReadOnly = True
        Me.obj_RD_Id.Size = New System.Drawing.Size(129, 20)
        Me.obj_RD_Id.TabIndex = 11
        '
        'obj_RD_line
        '
        Me.obj_RD_line.Location = New System.Drawing.Point(132, 184)
        Me.obj_RD_line.Name = "obj_RD_line"
        Me.obj_RD_line.ReadOnly = True
        Me.obj_RD_line.Size = New System.Drawing.Size(56, 20)
        Me.obj_RD_line.TabIndex = 12
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 220)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(42, 13)
        Me.Label7.TabIndex = 5
        Me.Label7.Text = "Inv. No"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(12, 249)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(49, 13)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "Currency"
        '
        'obj_invoice_id
        '
        Me.obj_invoice_id.Location = New System.Drawing.Point(132, 214)
        Me.obj_invoice_id.Name = "obj_invoice_id"
        Me.obj_invoice_id.ReadOnly = True
        Me.obj_invoice_id.Size = New System.Drawing.Size(173, 20)
        Me.obj_invoice_id.TabIndex = 11
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(12, 276)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(81, 13)
        Me.Label9.TabIndex = 5
        Me.Label9.Text = "Amount Foreign"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(12, 305)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(30, 13)
        Me.Label10.TabIndex = 6
        Me.Label10.Text = "Rate"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(12, 328)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(65, 13)
        Me.Label11.TabIndex = 6
        Me.Label11.Text = "Amount IDR"
        '
        'btn_select_RD
        '
        Me.btn_select_RD.Location = New System.Drawing.Point(268, 156)
        Me.btn_select_RD.Name = "btn_select_RD"
        Me.btn_select_RD.Size = New System.Drawing.Size(37, 21)
        Me.btn_select_RD.TabIndex = 13
        Me.btn_select_RD.Text = "..."
        Me.btn_select_RD.UseVisualStyleBackColor = True
        '
        'cbo_acc_id
        '
        Me.cbo_acc_id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cbo_acc_id.Enabled = False
        Me.cbo_acc_id.FormattingEnabled = True
        Me.cbo_acc_id.Location = New System.Drawing.Point(132, 66)
        Me.cbo_acc_id.Name = "cbo_acc_id"
        Me.cbo_acc_id.Size = New System.Drawing.Size(213, 21)
        Me.cbo_acc_id.TabIndex = 14
        '
        'cbo_currency_id
        '
        Me.cbo_currency_id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cbo_currency_id.Enabled = False
        Me.cbo_currency_id.FormattingEnabled = True
        Me.cbo_currency_id.Location = New System.Drawing.Point(132, 241)
        Me.cbo_currency_id.Name = "cbo_currency_id"
        Me.cbo_currency_id.Size = New System.Drawing.Size(74, 21)
        Me.cbo_currency_id.TabIndex = 14
        '
        'obj_amount_foreign
        '
        Me.obj_amount_foreign.Location = New System.Drawing.Point(132, 268)
        Me.obj_amount_foreign.Name = "obj_amount_foreign"
        Me.obj_amount_foreign.Properties.DisplayFormat.FormatString = "n0"
        Me.obj_amount_foreign.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.obj_amount_foreign.Properties.EditFormat.FormatString = "n0"
        Me.obj_amount_foreign.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.obj_amount_foreign.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.obj_amount_foreign.Size = New System.Drawing.Size(145, 20)
        Me.obj_amount_foreign.TabIndex = 15
        '
        'obj_rate
        '
        Me.obj_rate.Location = New System.Drawing.Point(132, 297)
        Me.obj_rate.Name = "obj_rate"
        Me.obj_rate.Properties.DisplayFormat.FormatString = "n0"
        Me.obj_rate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.obj_rate.Properties.EditFormat.FormatString = "n0"
        Me.obj_rate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.obj_rate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.obj_rate.Size = New System.Drawing.Size(90, 20)
        Me.obj_rate.TabIndex = 15
        '
        'obj_amount_idr
        '
        Me.obj_amount_idr.Location = New System.Drawing.Point(132, 325)
        Me.obj_amount_idr.Name = "obj_amount_idr"
        Me.obj_amount_idr.Properties.DisplayFormat.FormatString = "n0"
        Me.obj_amount_idr.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.obj_amount_idr.Properties.EditFormat.FormatString = "n0"
        Me.obj_amount_idr.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.obj_amount_idr.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.obj_amount_idr.Properties.ReadOnly = True
        Me.obj_amount_idr.Size = New System.Drawing.Size(129, 20)
        Me.obj_amount_idr.TabIndex = 15
        '
        'dlgTrnJurnal_PV_Add_invoice
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LavenderBlush
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(386, 401)
        Me.Controls.Add(Me.obj_amount_idr)
        Me.Controls.Add(Me.obj_rate)
        Me.Controls.Add(Me.obj_amount_foreign)
        Me.Controls.Add(Me.cbo_currency_id)
        Me.Controls.Add(Me.cbo_acc_id)
        Me.Controls.Add(Me.btn_select_RD)
        Me.Controls.Add(Me.obj_RD_line)
        Me.Controls.Add(Me.obj_invoice_id)
        Me.Controls.Add(Me.obj_RD_Id)
        Me.Controls.Add(Me.obj_jurnal_desc)
        Me.Controls.Add(Me.obj_jurnal_line)
        Me.Controls.Add(Me.obj_jurnal_id)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgTrnJurnal_PV_Add_invoice"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Select Invoice No."
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.obj_amount_foreign.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.obj_rate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.obj_amount_idr.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents obj_jurnal_id As System.Windows.Forms.TextBox
    Friend WithEvents obj_jurnal_line As System.Windows.Forms.TextBox
    Friend WithEvents obj_jurnal_desc As System.Windows.Forms.TextBox
    Friend WithEvents obj_RD_Id As System.Windows.Forms.TextBox
    Friend WithEvents obj_RD_line As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents obj_invoice_id As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents btn_select_RD As System.Windows.Forms.Button
    Friend WithEvents cbo_acc_id As System.Windows.Forms.ComboBox
    Friend WithEvents cbo_currency_id As System.Windows.Forms.ComboBox
    Friend WithEvents obj_amount_foreign As DevExpress.XtraEditors.TextEdit
    Friend WithEvents obj_rate As DevExpress.XtraEditors.TextEdit
    Friend WithEvents obj_amount_idr As DevExpress.XtraEditors.TextEdit

End Class
