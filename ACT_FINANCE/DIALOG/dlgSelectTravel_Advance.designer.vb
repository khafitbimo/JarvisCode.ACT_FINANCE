<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgSelectTravel_Advance
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
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btn_Rekanan = New System.Windows.Forms.Button()
        Me.obj_Rekanan_id = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.chkSearchJurnalID = New System.Windows.Forms.CheckBox()
        Me.chkRekanan = New System.Windows.Forms.CheckBox()
        Me.obj_jurnal_id = New System.Windows.Forms.TextBox()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.obj_Channel_id = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.txt_total_amount = New System.Windows.Forms.TextBox()
        Me.lbl_amount = New System.Windows.Forms.Label()
        Me.txt_total_order = New System.Windows.Forms.TextBox()
        Me.txt_total_amountIncl = New System.Windows.Forms.TextBox()
        Me.lbl_order = New System.Windows.Forms.Label()
        Me.lbl_Inclpajak = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.ftabMain = New FlatTabControl.FlatTabControl()
        Me.ftabMain_header = New System.Windows.Forms.TabPage()
        Me.DgvTrnGoodsRq = New System.Windows.Forms.DataGridView()
        Me.ftabMain_detail = New System.Windows.Forms.TabPage()
        Me.DgvTrnGoodsRqDetil = New System.Windows.Forms.DataGridView()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.ftabMain.SuspendLayout()
        Me.ftabMain_header.SuspendLayout()
        CType(Me.DgvTrnGoodsRq, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ftabMain_detail.SuspendLayout()
        CType(Me.DgvTrnGoodsRqDetil, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.BackColor = System.Drawing.SystemColors.Control
        Me.btnOK.Location = New System.Drawing.Point(766, 2)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 8
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = False
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.SystemColors.Control
        Me.btnCancel.Location = New System.Drawing.Point(847, 3)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 9
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Panel1.Controls.Add(Me.btn_Rekanan)
        Me.Panel1.Controls.Add(Me.obj_Rekanan_id)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.chkSearchJurnalID)
        Me.Panel1.Controls.Add(Me.chkRekanan)
        Me.Panel1.Controls.Add(Me.obj_jurnal_id)
        Me.Panel1.Controls.Add(Me.btnAdd)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.obj_Channel_id)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(928, 115)
        Me.Panel1.TabIndex = 10
        '
        'btn_Rekanan
        '
        Me.btn_Rekanan.Location = New System.Drawing.Point(889, 11)
        Me.btn_Rekanan.Name = "btn_Rekanan"
        Me.btn_Rekanan.Size = New System.Drawing.Size(33, 24)
        Me.btn_Rekanan.TabIndex = 99
        Me.btn_Rekanan.Text = "..."
        Me.btn_Rekanan.UseVisualStyleBackColor = True
        Me.btn_Rekanan.Visible = False
        '
        'obj_Rekanan_id
        '
        Me.obj_Rekanan_id.Location = New System.Drawing.Point(766, 12)
        Me.obj_Rekanan_id.Name = "obj_Rekanan_id"
        Me.obj_Rekanan_id.Size = New System.Drawing.Size(117, 20)
        Me.obj_Rekanan_id.TabIndex = 98
        Me.obj_Rekanan_id.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(67, 98)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(263, 12)
        Me.Label2.TabIndex = 95
        Me.Label2.Text = "Use semicolone (;) to enter more than one references in textbox"
        '
        'chkSearchJurnalID
        '
        Me.chkSearchJurnalID.AutoSize = True
        Me.chkSearchJurnalID.Location = New System.Drawing.Point(14, 31)
        Me.chkSearchJurnalID.Name = "chkSearchJurnalID"
        Me.chkSearchJurnalID.Size = New System.Drawing.Size(48, 17)
        Me.chkSearchJurnalID.TabIndex = 94
        Me.chkSearchJurnalID.Text = "ID(s)"
        Me.chkSearchJurnalID.UseVisualStyleBackColor = True
        '
        'chkRekanan
        '
        Me.chkRekanan.AutoSize = True
        Me.chkRekanan.Location = New System.Drawing.Point(685, 16)
        Me.chkRekanan.Name = "chkRekanan"
        Me.chkRekanan.Size = New System.Drawing.Size(84, 17)
        Me.chkRekanan.TabIndex = 93
        Me.chkRekanan.Text = "Rekanan ID"
        Me.chkRekanan.UseVisualStyleBackColor = True
        Me.chkRekanan.Visible = False
        '
        'obj_jurnal_id
        '
        Me.obj_jurnal_id.Location = New System.Drawing.Point(68, 31)
        Me.obj_jurnal_id.Multiline = True
        Me.obj_jurnal_id.Name = "obj_jurnal_id"
        Me.obj_jurnal_id.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.obj_jurnal_id.Size = New System.Drawing.Size(270, 61)
        Me.obj_jurnal_id.TabIndex = 92
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(833, 86)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(89, 24)
        Me.btnAdd.TabIndex = 91
        Me.btnAdd.Text = "Load"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 89
        Me.Label1.Text = "Channel"
        '
        'obj_Channel_id
        '
        Me.obj_Channel_id.Location = New System.Drawing.Point(69, 7)
        Me.obj_Channel_id.Name = "obj_Channel_id"
        Me.obj_Channel_id.ReadOnly = True
        Me.obj_Channel_id.Size = New System.Drawing.Size(62, 20)
        Me.obj_Channel_id.TabIndex = 90
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Panel2.Controls.Add(Me.txt_total_amount)
        Me.Panel2.Controls.Add(Me.lbl_amount)
        Me.Panel2.Controls.Add(Me.txt_total_order)
        Me.Panel2.Controls.Add(Me.txt_total_amountIncl)
        Me.Panel2.Controls.Add(Me.lbl_order)
        Me.Panel2.Controls.Add(Me.lbl_Inclpajak)
        Me.Panel2.Controls.Add(Me.btnOK)
        Me.Panel2.Controls.Add(Me.btnCancel)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 366)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(928, 29)
        Me.Panel2.TabIndex = 11
        '
        'txt_total_amount
        '
        Me.txt_total_amount.BackColor = System.Drawing.Color.Linen
        Me.txt_total_amount.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_total_amount.Location = New System.Drawing.Point(573, 5)
        Me.txt_total_amount.Name = "txt_total_amount"
        Me.txt_total_amount.ReadOnly = True
        Me.txt_total_amount.Size = New System.Drawing.Size(146, 20)
        Me.txt_total_amount.TabIndex = 15
        Me.txt_total_amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbl_amount
        '
        Me.lbl_amount.AutoSize = True
        Me.lbl_amount.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_amount.Location = New System.Drawing.Point(501, 8)
        Me.lbl_amount.Name = "lbl_amount"
        Me.lbl_amount.Size = New System.Drawing.Size(68, 13)
        Me.lbl_amount.TabIndex = 14
        Me.lbl_amount.Text = "Total Amount"
        '
        'txt_total_order
        '
        Me.txt_total_order.BackColor = System.Drawing.Color.Linen
        Me.txt_total_order.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_total_order.Location = New System.Drawing.Point(345, 5)
        Me.txt_total_order.Name = "txt_total_order"
        Me.txt_total_order.ReadOnly = True
        Me.txt_total_order.Size = New System.Drawing.Size(146, 20)
        Me.txt_total_order.TabIndex = 13
        Me.txt_total_order.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_total_amountIncl
        '
        Me.txt_total_amountIncl.BackColor = System.Drawing.Color.Linen
        Me.txt_total_amountIncl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_total_amountIncl.Location = New System.Drawing.Point(131, 5)
        Me.txt_total_amountIncl.Name = "txt_total_amountIncl"
        Me.txt_total_amountIncl.ReadOnly = True
        Me.txt_total_amountIncl.Size = New System.Drawing.Size(146, 20)
        Me.txt_total_amountIncl.TabIndex = 12
        Me.txt_total_amountIncl.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbl_order
        '
        Me.lbl_order.AutoSize = True
        Me.lbl_order.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_order.Location = New System.Drawing.Point(282, 8)
        Me.lbl_order.Name = "lbl_order"
        Me.lbl_order.Size = New System.Drawing.Size(58, 13)
        Me.lbl_order.TabIndex = 11
        Me.lbl_order.Text = "Total Order"
        '
        'lbl_Inclpajak
        '
        Me.lbl_Inclpajak.AutoSize = True
        Me.lbl_Inclpajak.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Inclpajak.Location = New System.Drawing.Point(5, 8)
        Me.lbl_Inclpajak.Name = "lbl_Inclpajak"
        Me.lbl_Inclpajak.Size = New System.Drawing.Size(121, 13)
        Me.lbl_Inclpajak.TabIndex = 10
        Me.lbl_Inclpajak.Text = "Total Incl[PPh,PPN,Disc]"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.ftabMain)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 115)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(928, 251)
        Me.Panel3.TabIndex = 12
        '
        'ftabMain
        '
        Me.ftabMain.Controls.Add(Me.ftabMain_header)
        Me.ftabMain.Controls.Add(Me.ftabMain_detail)
        Me.ftabMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ftabMain.Location = New System.Drawing.Point(0, 0)
        Me.ftabMain.myBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ftabMain.Name = "ftabMain"
        Me.ftabMain.SelectedIndex = 0
        Me.ftabMain.Size = New System.Drawing.Size(928, 251)
        Me.ftabMain.TabIndex = 8
        '
        'ftabMain_header
        '
        Me.ftabMain_header.BackColor = System.Drawing.SystemColors.Control
        Me.ftabMain_header.Controls.Add(Me.DgvTrnGoodsRq)
        Me.ftabMain_header.Location = New System.Drawing.Point(4, 25)
        Me.ftabMain_header.Name = "ftabMain_header"
        Me.ftabMain_header.Padding = New System.Windows.Forms.Padding(3)
        Me.ftabMain_header.Size = New System.Drawing.Size(920, 222)
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
        Me.DgvTrnGoodsRq.Size = New System.Drawing.Size(914, 216)
        Me.DgvTrnGoodsRq.TabIndex = 9
        '
        'ftabMain_detail
        '
        Me.ftabMain_detail.BackColor = System.Drawing.SystemColors.Control
        Me.ftabMain_detail.Controls.Add(Me.DgvTrnGoodsRqDetil)
        Me.ftabMain_detail.Location = New System.Drawing.Point(4, 25)
        Me.ftabMain_detail.Name = "ftabMain_detail"
        Me.ftabMain_detail.Padding = New System.Windows.Forms.Padding(3)
        Me.ftabMain_detail.Size = New System.Drawing.Size(920, 222)
        Me.ftabMain_detail.TabIndex = 1
        Me.ftabMain_detail.Text = "Detail"
        '
        'DgvTrnGoodsRqDetil
        '
        Me.DgvTrnGoodsRqDetil.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvTrnGoodsRqDetil.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvTrnGoodsRqDetil.Location = New System.Drawing.Point(3, 3)
        Me.DgvTrnGoodsRqDetil.Name = "DgvTrnGoodsRqDetil"
        Me.DgvTrnGoodsRqDetil.Size = New System.Drawing.Size(914, 216)
        Me.DgvTrnGoodsRqDetil.TabIndex = 8
        '
        'dlgSelectTravel_Advance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(928, 395)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgSelectTravel_Advance"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Select Order"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.ftabMain.ResumeLayout(False)
        Me.ftabMain_header.ResumeLayout(False)
        CType(Me.DgvTrnGoodsRq, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ftabMain_detail.ResumeLayout(False)
        CType(Me.DgvTrnGoodsRqDetil, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents ftabMain As FlatTabControl.FlatTabControl
    Friend WithEvents ftabMain_header As System.Windows.Forms.TabPage
    Friend WithEvents DgvTrnGoodsRq As System.Windows.Forms.DataGridView
    Friend WithEvents ftabMain_detail As System.Windows.Forms.TabPage
    Friend WithEvents DgvTrnGoodsRqDetil As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents chkSearchJurnalID As System.Windows.Forms.CheckBox
    Friend WithEvents obj_jurnal_id As System.Windows.Forms.TextBox
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents obj_Channel_id As System.Windows.Forms.TextBox
    Friend WithEvents txt_total_amountIncl As System.Windows.Forms.TextBox
    Friend WithEvents lbl_order As System.Windows.Forms.Label
    Friend WithEvents lbl_Inclpajak As System.Windows.Forms.Label
    Friend WithEvents txt_total_order As System.Windows.Forms.TextBox
    Friend WithEvents txt_total_amount As System.Windows.Forms.TextBox
    Friend WithEvents lbl_amount As System.Windows.Forms.Label
    Friend WithEvents btn_Rekanan As System.Windows.Forms.Button
    Friend WithEvents obj_Rekanan_id As System.Windows.Forms.TextBox
    Friend WithEvents chkRekanan As System.Windows.Forms.CheckBox
End Class
