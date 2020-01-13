<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgSelectRekeningPrint
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.dgvRekening = New System.Windows.Forms.DataGridView()
        Me.chkTglBilyet = New System.Windows.Forms.CheckBox()
        Me.dtpTglBilyet = New System.Windows.Forms.DateTimePicker()
        Me.chkRekananName = New System.Windows.Forms.CheckBox()
        Me.txtRekananName = New System.Windows.Forms.TextBox()
        Me.txtAccNumber = New System.Windows.Forms.TextBox()
        Me.chkAccNumber = New System.Windows.Forms.CheckBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.dtpTglPrint = New System.Windows.Forms.DateTimePicker()
        Me.chkTglPrint = New System.Windows.Forms.CheckBox()
        Me.lbPrintOption = New System.Windows.Forms.Label()
        Me.chkAmountIDR = New System.Windows.Forms.CheckBox()
        Me.txtBankName = New System.Windows.Forms.TextBox()
        Me.chkBankName = New System.Windows.Forms.CheckBox()
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.LineShape1 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.obj_KotaPrint = New System.Windows.Forms.TextBox()
        Me.chkKotaPrint = New System.Windows.Forms.CheckBox()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.dgvRekening, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(336, 3)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 0
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
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        '
        'dgvRekening
        '
        Me.dgvRekening.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRekening.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvRekening.Location = New System.Drawing.Point(0, 0)
        Me.dgvRekening.Name = "dgvRekening"
        Me.dgvRekening.Size = New System.Drawing.Size(483, 240)
        Me.dgvRekening.TabIndex = 1
        '
        'chkTglBilyet
        '
        Me.chkTglBilyet.AutoSize = True
        Me.chkTglBilyet.Checked = True
        Me.chkTglBilyet.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkTglBilyet.Location = New System.Drawing.Point(12, 63)
        Me.chkTglBilyet.Name = "chkTglBilyet"
        Me.chkTglBilyet.Size = New System.Drawing.Size(77, 17)
        Me.chkTglBilyet.TabIndex = 2
        Me.chkTglBilyet.Text = "Bilyet Date"
        Me.chkTglBilyet.UseVisualStyleBackColor = True
        '
        'dtpTglBilyet
        '
        Me.dtpTglBilyet.CustomFormat = "dd/MM/yyyy"
        Me.dtpTglBilyet.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpTglBilyet.Location = New System.Drawing.Point(110, 62)
        Me.dtpTglBilyet.Name = "dtpTglBilyet"
        Me.dtpTglBilyet.Size = New System.Drawing.Size(105, 20)
        Me.dtpTglBilyet.TabIndex = 3
        '
        'chkRekananName
        '
        Me.chkRekananName.AutoSize = True
        Me.chkRekananName.Checked = True
        Me.chkRekananName.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkRekananName.Location = New System.Drawing.Point(12, 141)
        Me.chkRekananName.Name = "chkRekananName"
        Me.chkRekananName.Size = New System.Drawing.Size(91, 17)
        Me.chkRekananName.TabIndex = 4
        Me.chkRekananName.Text = "Vendor Name"
        Me.chkRekananName.UseVisualStyleBackColor = True
        '
        'txtRekananName
        '
        Me.txtRekananName.Location = New System.Drawing.Point(110, 139)
        Me.txtRekananName.Name = "txtRekananName"
        Me.txtRekananName.Size = New System.Drawing.Size(220, 20)
        Me.txtRekananName.TabIndex = 5
        '
        'txtAccNumber
        '
        Me.txtAccNumber.Location = New System.Drawing.Point(110, 165)
        Me.txtAccNumber.Name = "txtAccNumber"
        Me.txtAccNumber.Size = New System.Drawing.Size(220, 20)
        Me.txtAccNumber.TabIndex = 9
        '
        'chkAccNumber
        '
        Me.chkAccNumber.AutoSize = True
        Me.chkAccNumber.Checked = True
        Me.chkAccNumber.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkAccNumber.Location = New System.Drawing.Point(12, 167)
        Me.chkAccNumber.Name = "chkAccNumber"
        Me.chkAccNumber.Size = New System.Drawing.Size(94, 17)
        Me.chkAccNumber.TabIndex = 8
        Me.chkAccNumber.Text = "Account Num."
        Me.chkAccNumber.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.obj_KotaPrint)
        Me.Panel1.Controls.Add(Me.chkKotaPrint)
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Controls.Add(Me.dtpTglPrint)
        Me.Panel1.Controls.Add(Me.chkTglPrint)
        Me.Panel1.Controls.Add(Me.lbPrintOption)
        Me.Panel1.Controls.Add(Me.chkAmountIDR)
        Me.Panel1.Controls.Add(Me.dtpTglBilyet)
        Me.Panel1.Controls.Add(Me.txtAccNumber)
        Me.Panel1.Controls.Add(Me.chkTglBilyet)
        Me.Panel1.Controls.Add(Me.chkAccNumber)
        Me.Panel1.Controls.Add(Me.chkRekananName)
        Me.Panel1.Controls.Add(Me.txtBankName)
        Me.Panel1.Controls.Add(Me.txtRekananName)
        Me.Panel1.Controls.Add(Me.chkBankName)
        Me.Panel1.Controls.Add(Me.ShapeContainer1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 242)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(485, 248)
        Me.Panel1.TabIndex = 10
        '
        'dtpTglPrint
        '
        Me.dtpTglPrint.CustomFormat = "dd/MM/yyyy"
        Me.dtpTglPrint.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpTglPrint.Location = New System.Drawing.Point(110, 88)
        Me.dtpTglPrint.Name = "dtpTglPrint"
        Me.dtpTglPrint.Size = New System.Drawing.Size(105, 20)
        Me.dtpTglPrint.TabIndex = 14
        '
        'chkTglPrint
        '
        Me.chkTglPrint.AutoSize = True
        Me.chkTglPrint.Checked = True
        Me.chkTglPrint.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkTglPrint.Location = New System.Drawing.Point(12, 89)
        Me.chkTglPrint.Name = "chkTglPrint"
        Me.chkTglPrint.Size = New System.Drawing.Size(85, 17)
        Me.chkTglPrint.TabIndex = 13
        Me.chkTglPrint.Text = "Printed Date"
        Me.chkTglPrint.UseVisualStyleBackColor = True
        '
        'lbPrintOption
        '
        Me.lbPrintOption.AutoSize = True
        Me.lbPrintOption.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbPrintOption.Location = New System.Drawing.Point(8, 12)
        Me.lbPrintOption.Name = "lbPrintOption"
        Me.lbPrintOption.Size = New System.Drawing.Size(80, 13)
        Me.lbPrintOption.TabIndex = 11
        Me.lbPrintOption.Text = "Print Options"
        '
        'chkAmountIDR
        '
        Me.chkAmountIDR.AutoSize = True
        Me.chkAmountIDR.Checked = True
        Me.chkAmountIDR.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkAmountIDR.Location = New System.Drawing.Point(12, 40)
        Me.chkAmountIDR.Name = "chkAmountIDR"
        Me.chkAmountIDR.Size = New System.Drawing.Size(62, 17)
        Me.chkAmountIDR.TabIndex = 10
        Me.chkAmountIDR.Text = "Amount"
        Me.chkAmountIDR.UseVisualStyleBackColor = True
        '
        'txtBankName
        '
        Me.txtBankName.Location = New System.Drawing.Point(110, 191)
        Me.txtBankName.Name = "txtBankName"
        Me.txtBankName.Size = New System.Drawing.Size(220, 20)
        Me.txtBankName.TabIndex = 7
        '
        'chkBankName
        '
        Me.chkBankName.AutoSize = True
        Me.chkBankName.Checked = True
        Me.chkBankName.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkBankName.Location = New System.Drawing.Point(12, 193)
        Me.chkBankName.Name = "chkBankName"
        Me.chkBankName.Size = New System.Drawing.Size(82, 17)
        Me.chkBankName.TabIndex = 6
        Me.chkBankName.Text = "Bank Name"
        Me.chkBankName.UseVisualStyleBackColor = True
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.LineShape1})
        Me.ShapeContainer1.Size = New System.Drawing.Size(485, 248)
        Me.ShapeContainer1.TabIndex = 12
        Me.ShapeContainer1.TabStop = False
        '
        'LineShape1
        '
        Me.LineShape1.Name = "LineShape1"
        Me.LineShape1.X1 = 10
        Me.LineShape1.X2 = 478
        Me.LineShape1.Y1 = 31
        Me.LineShape1.Y2 = 31
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.dgvRekening)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(485, 242)
        Me.Panel2.TabIndex = 11
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.TableLayoutPanel1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 214)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(485, 34)
        Me.Panel3.TabIndex = 15
        '
        'obj_KotaPrint
        '
        Me.obj_KotaPrint.Location = New System.Drawing.Point(110, 113)
        Me.obj_KotaPrint.Name = "obj_KotaPrint"
        Me.obj_KotaPrint.Size = New System.Drawing.Size(220, 20)
        Me.obj_KotaPrint.TabIndex = 17
        '
        'chkKotaPrint
        '
        Me.chkKotaPrint.AutoSize = True
        Me.chkKotaPrint.Checked = True
        Me.chkKotaPrint.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkKotaPrint.Location = New System.Drawing.Point(12, 115)
        Me.chkKotaPrint.Name = "chkKotaPrint"
        Me.chkKotaPrint.Size = New System.Drawing.Size(79, 17)
        Me.chkKotaPrint.TabIndex = 16
        Me.chkKotaPrint.Text = "Printed City"
        Me.chkKotaPrint.UseVisualStyleBackColor = True
        '
        'dlgSelectRekeningPrint
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(485, 490)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgSelectRekeningPrint"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Select Rekening Print"
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.dgvRekening, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents dgvRekening As System.Windows.Forms.DataGridView
    Friend WithEvents chkTglBilyet As System.Windows.Forms.CheckBox
    Friend WithEvents dtpTglBilyet As System.Windows.Forms.DateTimePicker
    Friend WithEvents chkRekananName As System.Windows.Forms.CheckBox
    Friend WithEvents txtRekananName As System.Windows.Forms.TextBox
    Friend WithEvents txtAccNumber As System.Windows.Forms.TextBox
    Friend WithEvents chkAccNumber As System.Windows.Forms.CheckBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents txtBankName As System.Windows.Forms.TextBox
    Friend WithEvents chkBankName As System.Windows.Forms.CheckBox
    Friend WithEvents lbPrintOption As System.Windows.Forms.Label
    Friend WithEvents chkAmountIDR As System.Windows.Forms.CheckBox
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents LineShape1 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents dtpTglPrint As System.Windows.Forms.DateTimePicker
    Friend WithEvents chkTglPrint As System.Windows.Forms.CheckBox
    Friend WithEvents obj_KotaPrint As System.Windows.Forms.TextBox
    Friend WithEvents chkKotaPrint As System.Windows.Forms.CheckBox
    Friend WithEvents Panel3 As System.Windows.Forms.Panel

End Class
