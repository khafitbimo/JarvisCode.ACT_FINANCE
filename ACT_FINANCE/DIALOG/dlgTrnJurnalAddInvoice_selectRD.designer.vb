<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgTrnJurnalAddInvoice_selectRD
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.DgvSelectRd = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.obj_Channel_id = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.obj_jurnal_line = New System.Windows.Forms.TextBox()
        Me.obj_jurnal_id = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cbo_rekanan_id = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.obj_amount_credit = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.obj_amount = New System.Windows.Forms.TextBox()
        Me.obj_amount_idr = New System.Windows.Forms.TextBox()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Label7 = New System.Windows.Forms.Label()
        Me.obj_src_orderID = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.obj_src_tandaterimaID = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.DgvSelectRd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
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
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(716, 428)
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
        'DgvSelectRd
        '
        Me.DgvSelectRd.AllowUserToAddRows = False
        Me.DgvSelectRd.AllowUserToDeleteRows = False
        Me.DgvSelectRd.BackgroundColor = System.Drawing.Color.Lavender
        Me.DgvSelectRd.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Comic Sans MS", 8.0!)
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.DarkViolet
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvSelectRd.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.DgvSelectRd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvSelectRd.Cursor = System.Windows.Forms.Cursors.Hand
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Comic Sans MS", 8.0!)
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.DarkViolet
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgvSelectRd.DefaultCellStyle = DataGridViewCellStyle5
        Me.DgvSelectRd.GridColor = System.Drawing.Color.Moccasin
        Me.DgvSelectRd.Location = New System.Drawing.Point(12, 130)
        Me.DgvSelectRd.MultiSelect = False
        Me.DgvSelectRd.Name = "DgvSelectRd"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Comic Sans MS", 8.0!)
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.DarkViolet
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvSelectRd.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.DgvSelectRd.Size = New System.Drawing.Size(848, 247)
        Me.DgvSelectRd.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(18, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Company"
        '
        'obj_Channel_id
        '
        Me.obj_Channel_id.BackColor = System.Drawing.SystemColors.Info
        Me.obj_Channel_id.Location = New System.Drawing.Point(111, 16)
        Me.obj_Channel_id.Name = "obj_Channel_id"
        Me.obj_Channel_id.ReadOnly = True
        Me.obj_Channel_id.Size = New System.Drawing.Size(62, 20)
        Me.obj_Channel_id.TabIndex = 17
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(18, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 13)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "Partner"
        '
        'obj_jurnal_line
        '
        Me.obj_jurnal_line.BackColor = System.Drawing.SystemColors.Info
        Me.obj_jurnal_line.Location = New System.Drawing.Point(386, 39)
        Me.obj_jurnal_line.Name = "obj_jurnal_line"
        Me.obj_jurnal_line.ReadOnly = True
        Me.obj_jurnal_line.Size = New System.Drawing.Size(74, 20)
        Me.obj_jurnal_line.TabIndex = 21
        '
        'obj_jurnal_id
        '
        Me.obj_jurnal_id.BackColor = System.Drawing.SystemColors.Info
        Me.obj_jurnal_id.Location = New System.Drawing.Point(386, 13)
        Me.obj_jurnal_id.Name = "obj_jurnal_id"
        Me.obj_jurnal_id.ReadOnly = True
        Me.obj_jurnal_id.Size = New System.Drawing.Size(129, 20)
        Me.obj_jurnal_id.TabIndex = 20
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(314, 42)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 13)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "Jurnal Line"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(314, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 13)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "Jurnal ID"
        '
        'cbo_rekanan_id
        '
        Me.cbo_rekanan_id.BackColor = System.Drawing.SystemColors.Info
        Me.cbo_rekanan_id.Enabled = False
        Me.cbo_rekanan_id.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cbo_rekanan_id.FormattingEnabled = True
        Me.cbo_rekanan_id.Location = New System.Drawing.Point(111, 42)
        Me.cbo_rekanan_id.Name = "cbo_rekanan_id"
        Me.cbo_rekanan_id.Size = New System.Drawing.Size(174, 21)
        Me.cbo_rekanan_id.TabIndex = 22
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(555, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(112, 13)
        Me.Label5.TabIndex = 18
        Me.Label5.Text = "Amount Credit Remain"
        '
        'obj_amount_credit
        '
        Me.obj_amount_credit.BackColor = System.Drawing.SystemColors.Info
        Me.obj_amount_credit.Location = New System.Drawing.Point(673, 11)
        Me.obj_amount_credit.Name = "obj_amount_credit"
        Me.obj_amount_credit.ReadOnly = True
        Me.obj_amount_credit.Size = New System.Drawing.Size(129, 20)
        Me.obj_amount_credit.TabIndex = 20
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(645, 392)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(83, 13)
        Me.Label8.TabIndex = 66
        Me.Label8.Text = "Amount (IDR)"
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(395, 392)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(49, 13)
        Me.Label9.TabIndex = 64
        Me.Label9.Text = "Amount"
        '
        'obj_amount
        '
        Me.obj_amount.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.obj_amount.BackColor = System.Drawing.SystemColors.Info
        Me.obj_amount.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.obj_amount.ForeColor = System.Drawing.Color.Blue
        Me.obj_amount.Location = New System.Drawing.Point(450, 389)
        Me.obj_amount.Name = "obj_amount"
        Me.obj_amount.ReadOnly = True
        Me.obj_amount.Size = New System.Drawing.Size(137, 20)
        Me.obj_amount.TabIndex = 65
        Me.obj_amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'obj_amount_idr
        '
        Me.obj_amount_idr.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.obj_amount_idr.BackColor = System.Drawing.SystemColors.Info
        Me.obj_amount_idr.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.obj_amount_idr.ForeColor = System.Drawing.Color.Blue
        Me.obj_amount_idr.Location = New System.Drawing.Point(734, 389)
        Me.obj_amount_idr.Name = "obj_amount_idr"
        Me.obj_amount_idr.ReadOnly = True
        Me.obj_amount_idr.Size = New System.Drawing.Size(125, 20)
        Me.obj_amount_idr.TabIndex = 63
        Me.obj_amount_idr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(302, 23)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(47, 13)
        Me.Label7.TabIndex = 18
        Me.Label7.Text = "Order ID"
        '
        'obj_src_orderID
        '
        Me.obj_src_orderID.BackColor = System.Drawing.SystemColors.HighlightText
        Me.obj_src_orderID.Location = New System.Drawing.Point(374, 20)
        Me.obj_src_orderID.Name = "obj_src_orderID"
        Me.obj_src_orderID.Size = New System.Drawing.Size(160, 20)
        Me.obj_src_orderID.TabIndex = 20
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 23)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(87, 13)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "Tanda Terima ID"
        '
        'obj_src_tandaterimaID
        '
        Me.obj_src_tandaterimaID.BackColor = System.Drawing.SystemColors.HighlightText
        Me.obj_src_tandaterimaID.Location = New System.Drawing.Point(99, 20)
        Me.obj_src_tandaterimaID.Name = "obj_src_tandaterimaID"
        Me.obj_src_tandaterimaID.Size = New System.Drawing.Size(174, 20)
        Me.obj_src_tandaterimaID.TabIndex = 20
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.obj_src_orderID)
        Me.GroupBox1.Controls.Add(Me.obj_src_tandaterimaID)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 65)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(847, 59)
        Me.GroupBox1.TabIndex = 68
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filter"
        '
        'dlgTrnJurnalAddInvoice_selectRD
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Lavender
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(874, 469)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.obj_amount)
        Me.Controls.Add(Me.obj_amount_idr)
        Me.Controls.Add(Me.cbo_rekanan_id)
        Me.Controls.Add(Me.obj_jurnal_line)
        Me.Controls.Add(Me.obj_amount_credit)
        Me.Controls.Add(Me.obj_jurnal_id)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.obj_Channel_id)
        Me.Controls.Add(Me.DgvSelectRd)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgTrnJurnalAddInvoice_selectRD"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Get Tanda Terima"
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.DgvSelectRd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents DgvSelectRd As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents obj_Channel_id As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents obj_jurnal_line As System.Windows.Forms.TextBox
    Friend WithEvents obj_jurnal_id As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cbo_rekanan_id As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents obj_amount_credit As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents obj_amount As System.Windows.Forms.TextBox
    Friend WithEvents obj_amount_idr As System.Windows.Forms.TextBox
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents obj_src_orderID As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents obj_src_tandaterimaID As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox

End Class
