<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgTrnJurnal_PV_Select_AdvanceTravel
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.btnSelect = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.obj_Channel_id = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.obj_jurnal_id = New System.Windows.Forms.TextBox()
        Me.chkRekanan = New System.Windows.Forms.CheckBox()
        Me.chkSearchJurnalID = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.chkSearchSource = New System.Windows.Forms.CheckBox()
        Me.obj_Source = New System.Windows.Forms.ComboBox()
        Me.obj_Rekanan_id = New System.Windows.Forms.TextBox()
        Me.btn_Rekanan = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.dgvHeader = New System.Windows.Forms.DataGridView()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.DgvDetil = New System.Windows.Forms.DataGridView()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dgvHeader, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.DgvDetil, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnSelect
        '
        Me.btnSelect.Location = New System.Drawing.Point(761, 6)
        Me.btnSelect.Name = "btnSelect"
        Me.btnSelect.Size = New System.Drawing.Size(75, 21)
        Me.btnSelect.TabIndex = 13
        Me.btnSelect.Text = "Ok"
        Me.btnSelect.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(842, 6)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 21)
        Me.btnCancel.TabIndex = 14
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'obj_Channel_id
        '
        Me.obj_Channel_id.BackColor = System.Drawing.Color.LightYellow
        Me.obj_Channel_id.Location = New System.Drawing.Point(94, 8)
        Me.obj_Channel_id.Name = "obj_Channel_id"
        Me.obj_Channel_id.ReadOnly = True
        Me.obj_Channel_id.Size = New System.Drawing.Size(88, 20)
        Me.obj_Channel_id.TabIndex = 15
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Company"
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(859, 62)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(75, 24)
        Me.btnAdd.TabIndex = 23
        Me.btnAdd.Text = "Load"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'obj_jurnal_id
        '
        Me.obj_jurnal_id.Location = New System.Drawing.Point(583, 5)
        Me.obj_jurnal_id.Multiline = True
        Me.obj_jurnal_id.Name = "obj_jurnal_id"
        Me.obj_jurnal_id.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.obj_jurnal_id.Size = New System.Drawing.Size(270, 62)
        Me.obj_jurnal_id.TabIndex = 24
        '
        'chkRekanan
        '
        Me.chkRekanan.AutoSize = True
        Me.chkRekanan.Location = New System.Drawing.Point(9, 62)
        Me.chkRekanan.Name = "chkRekanan"
        Me.chkRekanan.Size = New System.Drawing.Size(84, 17)
        Me.chkRekanan.TabIndex = 47
        Me.chkRekanan.Text = "Rekanan ID"
        Me.chkRekanan.UseVisualStyleBackColor = True
        '
        'chkSearchJurnalID
        '
        Me.chkSearchJurnalID.AutoSize = True
        Me.chkSearchJurnalID.Location = New System.Drawing.Point(532, 8)
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
        Me.Label2.Location = New System.Drawing.Point(582, 70)
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
        Me.chkSearchSource.Location = New System.Drawing.Point(9, 36)
        Me.chkSearchSource.Name = "chkSearchSource"
        Me.chkSearchSource.Size = New System.Drawing.Size(60, 17)
        Me.chkSearchSource.TabIndex = 76
        Me.chkSearchSource.Text = "Source"
        Me.chkSearchSource.UseVisualStyleBackColor = True
        '
        'obj_Source
        '
        Me.obj_Source.FormattingEnabled = True
        Me.obj_Source.Location = New System.Drawing.Point(94, 34)
        Me.obj_Source.Name = "obj_Source"
        Me.obj_Source.Size = New System.Drawing.Size(146, 21)
        Me.obj_Source.TabIndex = 75
        '
        'obj_Rekanan_id
        '
        Me.obj_Rekanan_id.Location = New System.Drawing.Point(94, 62)
        Me.obj_Rekanan_id.Name = "obj_Rekanan_id"
        Me.obj_Rekanan_id.Size = New System.Drawing.Size(206, 20)
        Me.obj_Rekanan_id.TabIndex = 77
        '
        'btn_Rekanan
        '
        Me.btn_Rekanan.Location = New System.Drawing.Point(306, 62)
        Me.btn_Rekanan.Name = "btn_Rekanan"
        Me.btn_Rekanan.Size = New System.Drawing.Size(33, 20)
        Me.btn_Rekanan.TabIndex = 78
        Me.btn_Rekanan.Text = "..."
        Me.btn_Rekanan.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.TabControl1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 91)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(937, 349)
        Me.Panel1.TabIndex = 79
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(937, 349)
        Me.TabControl1.TabIndex = 27
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.dgvHeader)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(929, 323)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Header"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'dgvHeader
        '
        Me.dgvHeader.BackgroundColor = System.Drawing.Color.Lavender
        Me.dgvHeader.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Comic Sans MS", 8.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DarkViolet
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvHeader.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvHeader.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvHeader.Cursor = System.Windows.Forms.Cursors.Hand
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Comic Sans MS", 8.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DarkViolet
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvHeader.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvHeader.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvHeader.GridColor = System.Drawing.Color.Moccasin
        Me.dgvHeader.Location = New System.Drawing.Point(3, 3)
        Me.dgvHeader.Name = "dgvHeader"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Comic Sans MS", 8.0!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.DarkViolet
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvHeader.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvHeader.Size = New System.Drawing.Size(923, 317)
        Me.dgvHeader.TabIndex = 29
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.DgvDetil)
        Me.TabPage2.Controls.Add(Me.Panel4)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(929, 323)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Detil"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'DgvDetil
        '
        Me.DgvDetil.BackgroundColor = System.Drawing.Color.Lavender
        Me.DgvDetil.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Comic Sans MS", 8.0!)
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.DarkViolet
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvDetil.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.DgvDetil.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvDetil.Cursor = System.Windows.Forms.Cursors.Hand
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Comic Sans MS", 8.0!)
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.DarkViolet
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgvDetil.DefaultCellStyle = DataGridViewCellStyle5
        Me.DgvDetil.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvDetil.GridColor = System.Drawing.Color.Moccasin
        Me.DgvDetil.Location = New System.Drawing.Point(3, 3)
        Me.DgvDetil.Name = "DgvDetil"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Comic Sans MS", 8.0!)
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.DarkViolet
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvDetil.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.DgvDetil.Size = New System.Drawing.Size(923, 283)
        Me.DgvDetil.TabIndex = 28
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.btnSelect)
        Me.Panel4.Controls.Add(Me.btnCancel)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel4.Location = New System.Drawing.Point(3, 286)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(923, 34)
        Me.Panel4.TabIndex = 29
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.obj_Channel_id)
        Me.Panel2.Controls.Add(Me.btn_Rekanan)
        Me.Panel2.Controls.Add(Me.btnAdd)
        Me.Panel2.Controls.Add(Me.obj_Rekanan_id)
        Me.Panel2.Controls.Add(Me.obj_jurnal_id)
        Me.Panel2.Controls.Add(Me.chkSearchSource)
        Me.Panel2.Controls.Add(Me.chkRekanan)
        Me.Panel2.Controls.Add(Me.obj_Source)
        Me.Panel2.Controls.Add(Me.chkSearchJurnalID)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(937, 91)
        Me.Panel2.TabIndex = 80
        '
        'dlgTrnJurnal_PV_Select_AdvanceTravel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(937, 440)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgTrnJurnal_PV_Select_AdvanceTravel"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Jurnal PV - List Advance Travel (SPD)"
        Me.Panel1.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.dgvHeader, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.DgvDetil, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnSelect As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents obj_Channel_id As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents obj_jurnal_id As System.Windows.Forms.TextBox
    Friend WithEvents chkRekanan As System.Windows.Forms.CheckBox
    Friend WithEvents chkSearchJurnalID As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents chkSearchSource As System.Windows.Forms.CheckBox
    Friend WithEvents obj_Source As System.Windows.Forms.ComboBox
    Friend WithEvents obj_Rekanan_id As System.Windows.Forms.TextBox
    Friend WithEvents btn_Rekanan As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents dgvHeader As System.Windows.Forms.DataGridView
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents DgvDetil As System.Windows.Forms.DataGridView
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
End Class
