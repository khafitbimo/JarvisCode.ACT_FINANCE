<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgTrnAdvanceOrder_Select_Order
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
        Me.btnSelect = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.obj_Channel_id = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.chkRekanan = New System.Windows.Forms.CheckBox
        Me.chkSearchSource = New System.Windows.Forms.CheckBox
        Me.obj_Source = New System.Windows.Forms.ComboBox
        Me.btn_Rekanan = New System.Windows.Forms.Button
        Me.obj_Rekanan_id = New System.Windows.Forms.TextBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.txt_total_amount = New System.Windows.Forms.TextBox
        Me.txt_total_amountorder = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.ftabMain = New FlatTabControl.FlatTabControl
        Me.ftabMain_header = New System.Windows.Forms.TabPage
        Me.DgvTrnGoodsRq = New System.Windows.Forms.DataGridView
        Me.ftabMain_detail = New System.Windows.Forms.TabPage
        Me.DgvTrnGoodsRqDetil = New System.Windows.Forms.DataGridView
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.ftabMain.SuspendLayout()
        Me.ftabMain_header.SuspendLayout()
        CType(Me.DgvTrnGoodsRq, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ftabMain_detail.SuspendLayout()
        CType(Me.DgvTrnGoodsRqDetil, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnSelect
        '
        Me.btnSelect.Location = New System.Drawing.Point(448, 5)
        Me.btnSelect.Name = "btnSelect"
        Me.btnSelect.Size = New System.Drawing.Size(75, 21)
        Me.btnSelect.TabIndex = 13
        Me.btnSelect.Text = "Ok"
        Me.btnSelect.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(529, 5)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 21)
        Me.btnCancel.TabIndex = 14
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'obj_Channel_id
        '
        Me.obj_Channel_id.Location = New System.Drawing.Point(70, 6)
        Me.obj_Channel_id.Name = "obj_Channel_id"
        Me.obj_Channel_id.ReadOnly = True
        Me.obj_Channel_id.Size = New System.Drawing.Size(62, 20)
        Me.obj_Channel_id.TabIndex = 15
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Company"
        '
        'chkRekanan
        '
        Me.chkRekanan.AutoSize = True
        Me.chkRekanan.Location = New System.Drawing.Point(369, 32)
        Me.chkRekanan.Name = "chkRekanan"
        Me.chkRekanan.Size = New System.Drawing.Size(84, 17)
        Me.chkRekanan.TabIndex = 47
        Me.chkRekanan.Text = "Rekanan ID"
        Me.chkRekanan.UseVisualStyleBackColor = True
        '
        'chkSearchSource
        '
        Me.chkSearchSource.AutoSize = True
        Me.chkSearchSource.Checked = True
        Me.chkSearchSource.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkSearchSource.Enabled = False
        Me.chkSearchSource.Location = New System.Drawing.Point(369, 5)
        Me.chkSearchSource.Name = "chkSearchSource"
        Me.chkSearchSource.Size = New System.Drawing.Size(60, 17)
        Me.chkSearchSource.TabIndex = 76
        Me.chkSearchSource.Text = "Source"
        Me.chkSearchSource.UseVisualStyleBackColor = True
        '
        'obj_Source
        '
        Me.obj_Source.FormattingEnabled = True
        Me.obj_Source.Location = New System.Drawing.Point(450, 3)
        Me.obj_Source.Name = "obj_Source"
        Me.obj_Source.Size = New System.Drawing.Size(117, 21)
        Me.obj_Source.TabIndex = 75
        '
        'btn_Rekanan
        '
        Me.btn_Rekanan.Location = New System.Drawing.Point(573, 27)
        Me.btn_Rekanan.Name = "btn_Rekanan"
        Me.btn_Rekanan.Size = New System.Drawing.Size(33, 24)
        Me.btn_Rekanan.TabIndex = 88
        Me.btn_Rekanan.Text = "..."
        Me.btn_Rekanan.UseVisualStyleBackColor = True
        '
        'obj_Rekanan_id
        '
        Me.obj_Rekanan_id.Location = New System.Drawing.Point(450, 28)
        Me.obj_Rekanan_id.Name = "obj_Rekanan_id"
        Me.obj_Rekanan_id.Size = New System.Drawing.Size(117, 20)
        Me.obj_Rekanan_id.TabIndex = 87
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.obj_Source)
        Me.Panel1.Controls.Add(Me.btn_Rekanan)
        Me.Panel1.Controls.Add(Me.obj_Channel_id)
        Me.Panel1.Controls.Add(Me.obj_Rekanan_id)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.chkSearchSource)
        Me.Panel1.Controls.Add(Me.chkRekanan)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(616, 58)
        Me.Panel1.TabIndex = 89
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.txt_total_amount)
        Me.Panel2.Controls.Add(Me.txt_total_amountorder)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.btnCancel)
        Me.Panel2.Controls.Add(Me.btnSelect)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 407)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(616, 32)
        Me.Panel2.TabIndex = 90
        '
        'txt_total_amount
        '
        Me.txt_total_amount.BackColor = System.Drawing.Color.Linen
        Me.txt_total_amount.Location = New System.Drawing.Point(285, 6)
        Me.txt_total_amount.Name = "txt_total_amount"
        Me.txt_total_amount.ReadOnly = True
        Me.txt_total_amount.Size = New System.Drawing.Size(151, 20)
        Me.txt_total_amount.TabIndex = 18
        Me.txt_total_amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_total_amountorder
        '
        Me.txt_total_amountorder.BackColor = System.Drawing.Color.Linen
        Me.txt_total_amountorder.Location = New System.Drawing.Point(83, 7)
        Me.txt_total_amountorder.Name = "txt_total_amountorder"
        Me.txt_total_amountorder.ReadOnly = True
        Me.txt_total_amountorder.Size = New System.Drawing.Size(147, 20)
        Me.txt_total_amountorder.TabIndex = 17
        Me.txt_total_amountorder.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(236, 10)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 13)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "Amount"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 10)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 13)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Amount Order"
        '
        'ftabMain
        '
        Me.ftabMain.Controls.Add(Me.ftabMain_header)
        Me.ftabMain.Controls.Add(Me.ftabMain_detail)
        Me.ftabMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ftabMain.Location = New System.Drawing.Point(0, 58)
        Me.ftabMain.myBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ftabMain.Name = "ftabMain"
        Me.ftabMain.SelectedIndex = 0
        Me.ftabMain.Size = New System.Drawing.Size(616, 349)
        Me.ftabMain.TabIndex = 91
        '
        'ftabMain_header
        '
        Me.ftabMain_header.BackColor = System.Drawing.SystemColors.Control
        Me.ftabMain_header.Controls.Add(Me.DgvTrnGoodsRq)
        Me.ftabMain_header.Location = New System.Drawing.Point(4, 25)
        Me.ftabMain_header.Name = "ftabMain_header"
        Me.ftabMain_header.Padding = New System.Windows.Forms.Padding(3)
        Me.ftabMain_header.Size = New System.Drawing.Size(608, 320)
        Me.ftabMain_header.TabIndex = 0
        Me.ftabMain_header.Text = "Header"
        '
        'DgvTrnGoodsRq
        '
        Me.DgvTrnGoodsRq.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvTrnGoodsRq.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvTrnGoodsRq.Location = New System.Drawing.Point(3, 3)
        Me.DgvTrnGoodsRq.Name = "DgvTrnGoodsRq"
        Me.DgvTrnGoodsRq.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvTrnGoodsRq.Size = New System.Drawing.Size(602, 314)
        Me.DgvTrnGoodsRq.TabIndex = 9
        '
        'ftabMain_detail
        '
        Me.ftabMain_detail.BackColor = System.Drawing.SystemColors.Control
        Me.ftabMain_detail.Controls.Add(Me.DgvTrnGoodsRqDetil)
        Me.ftabMain_detail.Location = New System.Drawing.Point(4, 25)
        Me.ftabMain_detail.Name = "ftabMain_detail"
        Me.ftabMain_detail.Padding = New System.Windows.Forms.Padding(3)
        Me.ftabMain_detail.Size = New System.Drawing.Size(608, 320)
        Me.ftabMain_detail.TabIndex = 1
        Me.ftabMain_detail.Text = "Detail"
        '
        'DgvTrnGoodsRqDetil
        '
        Me.DgvTrnGoodsRqDetil.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvTrnGoodsRqDetil.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvTrnGoodsRqDetil.Location = New System.Drawing.Point(3, 3)
        Me.DgvTrnGoodsRqDetil.Name = "DgvTrnGoodsRqDetil"
        Me.DgvTrnGoodsRqDetil.Size = New System.Drawing.Size(602, 314)
        Me.DgvTrnGoodsRqDetil.TabIndex = 8
        '
        'dlgTrnAdvanceOrder_Select_Order
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(616, 439)
        Me.ControlBox = False
        Me.Controls.Add(Me.ftabMain)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "dlgTrnAdvanceOrder_Select_Order"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "BQ"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ftabMain.ResumeLayout(False)
        Me.ftabMain_header.ResumeLayout(False)
        CType(Me.DgvTrnGoodsRq, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ftabMain_detail.ResumeLayout(False)
        CType(Me.DgvTrnGoodsRqDetil, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnSelect As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents obj_Channel_id As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents chkRekanan As System.Windows.Forms.CheckBox
    Friend WithEvents chkSearchSource As System.Windows.Forms.CheckBox
    Friend WithEvents obj_Source As System.Windows.Forms.ComboBox
    Friend WithEvents btn_Rekanan As System.Windows.Forms.Button
    Friend WithEvents obj_Rekanan_id As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents ftabMain As FlatTabControl.FlatTabControl
    Friend WithEvents ftabMain_header As System.Windows.Forms.TabPage
    Friend WithEvents DgvTrnGoodsRq As System.Windows.Forms.DataGridView
    Friend WithEvents ftabMain_detail As System.Windows.Forms.TabPage
    Friend WithEvents DgvTrnGoodsRqDetil As System.Windows.Forms.DataGridView
    Friend WithEvents txt_total_amount As System.Windows.Forms.TextBox
    Friend WithEvents txt_total_amountorder As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
