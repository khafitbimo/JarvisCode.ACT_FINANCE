<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgTrnReimburseSettlement_Select_ST
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.btnSelect = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.obj_Channel_id = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnAdd = New System.Windows.Forms.Button
        Me.obj_jurnal_id = New System.Windows.Forms.TextBox
        Me.LinkClear1 = New System.Windows.Forms.LinkLabel
        Me.LinkCheck1 = New System.Windows.Forms.LinkLabel
        Me.lnkQueryBuilder = New System.Windows.Forms.LinkLabel
        Me.txtSearchAdv = New System.Windows.Forms.TextBox
        Me.lnkClear = New System.Windows.Forms.LinkLabel
        Me.chkSearchAdv = New System.Windows.Forms.CheckBox
        Me.chkRekanan = New System.Windows.Forms.CheckBox
        Me.chkAccount = New System.Windows.Forms.CheckBox
        Me.chkSearchJurnalID = New System.Windows.Forms.CheckBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.chkSearchSource = New System.Windows.Forms.CheckBox
        Me.obj_Source = New System.Windows.Forms.ComboBox
        Me.btn_Account = New System.Windows.Forms.Button
        Me.obj_Acc_H = New System.Windows.Forms.TextBox
        Me.btn_Rekanan = New System.Windows.Forms.Button
        Me.obj_Rekanan_id = New System.Windows.Forms.TextBox
        Me.DgvDetil = New System.Windows.Forms.DataGridView
        CType(Me.DgvDetil, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnSelect
        '
        Me.btnSelect.Location = New System.Drawing.Point(769, 414)
        Me.btnSelect.Name = "btnSelect"
        Me.btnSelect.Size = New System.Drawing.Size(75, 21)
        Me.btnSelect.TabIndex = 13
        Me.btnSelect.Text = "Ok"
        Me.btnSelect.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(850, 414)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 21)
        Me.btnCancel.TabIndex = 14
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'obj_Channel_id
        '
        Me.obj_Channel_id.Location = New System.Drawing.Point(70, 7)
        Me.obj_Channel_id.Name = "obj_Channel_id"
        Me.obj_Channel_id.ReadOnly = True
        Me.obj_Channel_id.Size = New System.Drawing.Size(62, 20)
        Me.obj_Channel_id.TabIndex = 15
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Company"
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(835, 98)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(89, 24)
        Me.btnAdd.TabIndex = 23
        Me.btnAdd.Text = "Load"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'obj_jurnal_id
        '
        Me.obj_jurnal_id.Location = New System.Drawing.Point(69, 31)
        Me.obj_jurnal_id.Multiline = True
        Me.obj_jurnal_id.Name = "obj_jurnal_id"
        Me.obj_jurnal_id.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.obj_jurnal_id.Size = New System.Drawing.Size(270, 61)
        Me.obj_jurnal_id.TabIndex = 24
        '
        'LinkClear1
        '
        Me.LinkClear1.AutoSize = True
        Me.LinkClear1.Location = New System.Drawing.Point(88, 414)
        Me.LinkClear1.Name = "LinkClear1"
        Me.LinkClear1.Size = New System.Drawing.Size(77, 13)
        Me.LinkClear1.TabIndex = 42
        Me.LinkClear1.TabStop = True
        Me.LinkClear1.Text = "Clear Checked"
        '
        'LinkCheck1
        '
        Me.LinkCheck1.AutoSize = True
        Me.LinkCheck1.Location = New System.Drawing.Point(12, 414)
        Me.LinkCheck1.Name = "LinkCheck1"
        Me.LinkCheck1.Size = New System.Drawing.Size(52, 13)
        Me.LinkCheck1.TabIndex = 41
        Me.LinkCheck1.TabStop = True
        Me.LinkCheck1.Text = "Check All"
        '
        'lnkQueryBuilder
        '
        Me.lnkQueryBuilder.AutoSize = True
        Me.lnkQueryBuilder.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lnkQueryBuilder.Location = New System.Drawing.Point(696, 98)
        Me.lnkQueryBuilder.Name = "lnkQueryBuilder"
        Me.lnkQueryBuilder.Size = New System.Drawing.Size(70, 13)
        Me.lnkQueryBuilder.TabIndex = 46
        Me.lnkQueryBuilder.TabStop = True
        Me.lnkQueryBuilder.Text = "Query Builder"
        '
        'txtSearchAdv
        '
        Me.txtSearchAdv.Location = New System.Drawing.Point(658, 58)
        Me.txtSearchAdv.Multiline = True
        Me.txtSearchAdv.Name = "txtSearchAdv"
        Me.txtSearchAdv.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtSearchAdv.Size = New System.Drawing.Size(266, 34)
        Me.txtSearchAdv.TabIndex = 44
        '
        'lnkClear
        '
        Me.lnkClear.AutoSize = True
        Me.lnkClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lnkClear.Location = New System.Drawing.Point(656, 98)
        Me.lnkClear.Name = "lnkClear"
        Me.lnkClear.Size = New System.Drawing.Size(31, 13)
        Me.lnkClear.TabIndex = 45
        Me.lnkClear.TabStop = True
        Me.lnkClear.Text = "Clear"
        '
        'chkSearchAdv
        '
        Me.chkSearchAdv.AutoSize = True
        Me.chkSearchAdv.Location = New System.Drawing.Point(573, 60)
        Me.chkSearchAdv.Name = "chkSearchAdv"
        Me.chkSearchAdv.Size = New System.Drawing.Size(79, 17)
        Me.chkSearchAdv.TabIndex = 43
        Me.chkSearchAdv.Text = "Adv.Seach"
        Me.chkSearchAdv.UseVisualStyleBackColor = True
        '
        'chkRekanan
        '
        Me.chkRekanan.AutoSize = True
        Me.chkRekanan.Location = New System.Drawing.Point(573, 9)
        Me.chkRekanan.Name = "chkRekanan"
        Me.chkRekanan.Size = New System.Drawing.Size(84, 17)
        Me.chkRekanan.TabIndex = 47
        Me.chkRekanan.Text = "Rekanan ID"
        Me.chkRekanan.UseVisualStyleBackColor = True
        '
        'chkAccount
        '
        Me.chkAccount.AutoSize = True
        Me.chkAccount.Location = New System.Drawing.Point(573, 35)
        Me.chkAccount.Name = "chkAccount"
        Me.chkAccount.Size = New System.Drawing.Size(80, 17)
        Me.chkAccount.TabIndex = 48
        Me.chkAccount.Text = "Account ID"
        Me.chkAccount.UseVisualStyleBackColor = True
        '
        'chkSearchJurnalID
        '
        Me.chkSearchJurnalID.AutoSize = True
        Me.chkSearchJurnalID.Location = New System.Drawing.Point(15, 31)
        Me.chkSearchJurnalID.Name = "chkSearchJurnalID"
        Me.chkSearchJurnalID.Size = New System.Drawing.Size(48, 17)
        Me.chkSearchJurnalID.TabIndex = 66
        Me.chkSearchJurnalID.Text = "ID(s)"
        Me.chkSearchJurnalID.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(68, 98)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(263, 12)
        Me.Label2.TabIndex = 74
        Me.Label2.Text = "Use semicolone (;) to enter more than one references in textbox"
        '
        'chkSearchSource
        '
        Me.chkSearchSource.AutoSize = True
        Me.chkSearchSource.Checked = True
        Me.chkSearchSource.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkSearchSource.Enabled = False
        Me.chkSearchSource.Location = New System.Drawing.Point(156, 9)
        Me.chkSearchSource.Name = "chkSearchSource"
        Me.chkSearchSource.Size = New System.Drawing.Size(60, 17)
        Me.chkSearchSource.TabIndex = 76
        Me.chkSearchSource.Text = "Source"
        Me.chkSearchSource.UseVisualStyleBackColor = True
        '
        'obj_Source
        '
        Me.obj_Source.FormattingEnabled = True
        Me.obj_Source.Location = New System.Drawing.Point(222, 7)
        Me.obj_Source.Name = "obj_Source"
        Me.obj_Source.Size = New System.Drawing.Size(117, 21)
        Me.obj_Source.TabIndex = 75
        '
        'btn_Account
        '
        Me.btn_Account.Location = New System.Drawing.Point(768, 31)
        Me.btn_Account.Name = "btn_Account"
        Me.btn_Account.Size = New System.Drawing.Size(33, 24)
        Me.btn_Account.TabIndex = 90
        Me.btn_Account.Text = "..."
        Me.btn_Account.UseVisualStyleBackColor = True
        '
        'obj_Acc_H
        '
        Me.obj_Acc_H.Location = New System.Drawing.Point(658, 33)
        Me.obj_Acc_H.Name = "obj_Acc_H"
        Me.obj_Acc_H.Size = New System.Drawing.Size(108, 20)
        Me.obj_Acc_H.TabIndex = 89
        '
        'btn_Rekanan
        '
        Me.btn_Rekanan.Location = New System.Drawing.Point(768, 6)
        Me.btn_Rekanan.Name = "btn_Rekanan"
        Me.btn_Rekanan.Size = New System.Drawing.Size(33, 24)
        Me.btn_Rekanan.TabIndex = 88
        Me.btn_Rekanan.Text = "..."
        Me.btn_Rekanan.UseVisualStyleBackColor = True
        '
        'obj_Rekanan_id
        '
        Me.obj_Rekanan_id.Location = New System.Drawing.Point(658, 7)
        Me.obj_Rekanan_id.Name = "obj_Rekanan_id"
        Me.obj_Rekanan_id.Size = New System.Drawing.Size(108, 20)
        Me.obj_Rekanan_id.TabIndex = 87
        '
        'DgvDetil
        '
        Me.DgvDetil.BackgroundColor = System.Drawing.Color.Lavender
        Me.DgvDetil.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Comic Sans MS", 8.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DarkViolet
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvDetil.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DgvDetil.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvDetil.Cursor = System.Windows.Forms.Cursors.Hand
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Comic Sans MS", 8.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DarkViolet
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgvDetil.DefaultCellStyle = DataGridViewCellStyle2
        Me.DgvDetil.GridColor = System.Drawing.Color.Moccasin
        Me.DgvDetil.Location = New System.Drawing.Point(15, 124)
        Me.DgvDetil.Name = "DgvDetil"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Comic Sans MS", 8.0!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.DarkViolet
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvDetil.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DgvDetil.Size = New System.Drawing.Size(909, 287)
        Me.DgvDetil.TabIndex = 91
        '
        'dlgTrnJurnal_PV_Select_Advance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(937, 439)
        Me.ControlBox = False
        Me.Controls.Add(Me.DgvDetil)
        Me.Controls.Add(Me.btn_Account)
        Me.Controls.Add(Me.obj_Acc_H)
        Me.Controls.Add(Me.btn_Rekanan)
        Me.Controls.Add(Me.obj_Rekanan_id)
        Me.Controls.Add(Me.chkSearchSource)
        Me.Controls.Add(Me.obj_Source)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.chkSearchJurnalID)
        Me.Controls.Add(Me.chkAccount)
        Me.Controls.Add(Me.chkRekanan)
        Me.Controls.Add(Me.lnkQueryBuilder)
        Me.Controls.Add(Me.txtSearchAdv)
        Me.Controls.Add(Me.lnkClear)
        Me.Controls.Add(Me.chkSearchAdv)
        Me.Controls.Add(Me.LinkClear1)
        Me.Controls.Add(Me.LinkCheck1)
        Me.Controls.Add(Me.obj_jurnal_id)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.obj_Channel_id)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSelect)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "dlgTrnReimburseSettlement_Select_ST"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "BQ"
        CType(Me.DgvDetil, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnSelect As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents obj_Channel_id As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents obj_jurnal_id As System.Windows.Forms.TextBox
    Friend WithEvents LinkClear1 As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkCheck1 As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkQueryBuilder As System.Windows.Forms.LinkLabel
    Friend WithEvents txtSearchAdv As System.Windows.Forms.TextBox
    Friend WithEvents lnkClear As System.Windows.Forms.LinkLabel
    Friend WithEvents chkSearchAdv As System.Windows.Forms.CheckBox
    Friend WithEvents chkRekanan As System.Windows.Forms.CheckBox
    Friend WithEvents chkAccount As System.Windows.Forms.CheckBox
    Friend WithEvents chkSearchJurnalID As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents chkSearchSource As System.Windows.Forms.CheckBox
    Friend WithEvents obj_Source As System.Windows.Forms.ComboBox
    Friend WithEvents btn_Account As System.Windows.Forms.Button
    Friend WithEvents obj_Acc_H As System.Windows.Forms.TextBox
    Friend WithEvents btn_Rekanan As System.Windows.Forms.Button
    Friend WithEvents obj_Rekanan_id As System.Windows.Forms.TextBox
    Friend WithEvents DgvDetil As System.Windows.Forms.DataGridView
End Class
