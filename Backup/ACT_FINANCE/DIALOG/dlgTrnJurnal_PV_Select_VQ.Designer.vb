<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgTrnJurnal_PV_Select_VQ
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
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle22 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle23 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle24 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle25 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle26 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle27 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.cbo_periodeSearch = New System.Windows.Forms.ComboBox
        Me.chkSearchPeriode = New System.Windows.Forms.CheckBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtID = New System.Windows.Forms.TextBox
        Me.cbID = New System.Windows.Forms.CheckBox
        Me.dgvList = New System.Windows.Forms.DataGridView
        Me.dgvExport = New System.Windows.Forms.DataGridView
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnLoad = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.dgvExportDetil = New System.Windows.Forms.DataGridView
        Me.btnRemoveAll = New System.Windows.Forms.Button
        Me.btnSelectAll = New System.Windows.Forms.Button
        CType(Me.dgvList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvExport, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvExportDetil, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cbo_periodeSearch
        '
        Me.cbo_periodeSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbo_periodeSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbo_periodeSearch.BackColor = System.Drawing.Color.Honeydew
        Me.cbo_periodeSearch.FormattingEnabled = True
        Me.cbo_periodeSearch.Location = New System.Drawing.Point(77, 134)
        Me.cbo_periodeSearch.Name = "cbo_periodeSearch"
        Me.cbo_periodeSearch.Size = New System.Drawing.Size(158, 21)
        Me.cbo_periodeSearch.TabIndex = 239
        '
        'chkSearchPeriode
        '
        Me.chkSearchPeriode.AutoSize = True
        Me.chkSearchPeriode.Location = New System.Drawing.Point(10, 136)
        Me.chkSearchPeriode.Name = "chkSearchPeriode"
        Me.chkSearchPeriode.Size = New System.Drawing.Size(62, 17)
        Me.chkSearchPeriode.TabIndex = 238
        Me.chkSearchPeriode.Text = "Periode"
        Me.chkSearchPeriode.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(75, 111)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(263, 12)
        Me.Label13.TabIndex = 237
        Me.Label13.Text = "Use semicolone (;) to enter more than one references in textbox"
        '
        'txtID
        '
        Me.txtID.Location = New System.Drawing.Point(77, 13)
        Me.txtID.Multiline = True
        Me.txtID.Name = "txtID"
        Me.txtID.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtID.Size = New System.Drawing.Size(277, 95)
        Me.txtID.TabIndex = 236
        '
        'cbID
        '
        Me.cbID.AutoSize = True
        Me.cbID.Location = New System.Drawing.Point(10, 17)
        Me.cbID.Name = "cbID"
        Me.cbID.Size = New System.Drawing.Size(37, 17)
        Me.cbID.TabIndex = 235
        Me.cbID.Text = "ID"
        Me.cbID.UseVisualStyleBackColor = True
        '
        'dgvList
        '
        DataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle19
        Me.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvList.DefaultCellStyle = DataGridViewCellStyle20
        Me.dgvList.Location = New System.Drawing.Point(9, 174)
        Me.dgvList.Name = "dgvList"
        DataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle21.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle21.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle21.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle21.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvList.RowHeadersDefaultCellStyle = DataGridViewCellStyle21
        Me.dgvList.Size = New System.Drawing.Size(456, 293)
        Me.dgvList.TabIndex = 240
        '
        'dgvExport
        '
        DataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle22.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle22.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle22.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvExport.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle22
        Me.dgvExport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle23.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle23.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle23.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle23.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvExport.DefaultCellStyle = DataGridViewCellStyle23
        Me.dgvExport.Location = New System.Drawing.Point(6, 19)
        Me.dgvExport.Name = "dgvExport"
        DataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle24.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle24.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle24.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle24.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvExport.RowHeadersDefaultCellStyle = DataGridViewCellStyle24
        Me.dgvExport.Size = New System.Drawing.Size(394, 183)
        Me.dgvExport.TabIndex = 241
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(802, 473)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 31)
        Me.btnCancel.TabIndex = 242
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(721, 473)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 31)
        Me.btnOK.TabIndex = 243
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnLoad
        '
        Me.btnLoad.Location = New System.Drawing.Point(390, 134)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(75, 31)
        Me.btnLoad.TabIndex = 244
        Me.btnLoad.Text = "Load"
        Me.btnLoad.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Lavender
        Me.GroupBox1.Controls.Add(Me.dgvExport)
        Me.GroupBox1.Location = New System.Drawing.Point(471, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(406, 209)
        Me.GroupBox1.TabIndex = 245
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Master"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.dgvExportDetil)
        Me.GroupBox2.Location = New System.Drawing.Point(471, 228)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(406, 239)
        Me.GroupBox2.TabIndex = 246
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Detail"
        '
        'dgvExportDetil
        '
        DataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle25.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle25.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle25.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle25.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle25.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle25.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvExportDetil.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle25
        Me.dgvExportDetil.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle26.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle26.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle26.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle26.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle26.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvExportDetil.DefaultCellStyle = DataGridViewCellStyle26
        Me.dgvExportDetil.Location = New System.Drawing.Point(6, 19)
        Me.dgvExportDetil.Name = "dgvExportDetil"
        DataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle27.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle27.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle27.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle27.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle27.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle27.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvExportDetil.RowHeadersDefaultCellStyle = DataGridViewCellStyle27
        Me.dgvExportDetil.Size = New System.Drawing.Size(394, 214)
        Me.dgvExportDetil.TabIndex = 0
        '
        'btnRemoveAll
        '
        Me.btnRemoveAll.Location = New System.Drawing.Point(92, 473)
        Me.btnRemoveAll.Name = "btnRemoveAll"
        Me.btnRemoveAll.Size = New System.Drawing.Size(75, 30)
        Me.btnRemoveAll.TabIndex = 248
        Me.btnRemoveAll.Text = "Remove All"
        Me.btnRemoveAll.UseVisualStyleBackColor = True
        '
        'btnSelectAll
        '
        Me.btnSelectAll.Location = New System.Drawing.Point(10, 473)
        Me.btnSelectAll.Name = "btnSelectAll"
        Me.btnSelectAll.Size = New System.Drawing.Size(75, 31)
        Me.btnSelectAll.TabIndex = 247
        Me.btnSelectAll.Text = "Select All"
        Me.btnSelectAll.UseVisualStyleBackColor = True
        '
        'dlgTrnJurnal_PV_Select_VQ
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(889, 514)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnRemoveAll)
        Me.Controls.Add(Me.btnSelectAll)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnLoad)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.dgvList)
        Me.Controls.Add(Me.cbo_periodeSearch)
        Me.Controls.Add(Me.chkSearchPeriode)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.txtID)
        Me.Controls.Add(Me.cbID)
        Me.Name = "dlgTrnJurnal_PV_Select_VQ"
        Me.Text = "dlgTrnJurnal_PV_Select_VQ"
        CType(Me.dgvList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvExport, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.dgvExportDetil, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cbo_periodeSearch As System.Windows.Forms.ComboBox
    Friend WithEvents chkSearchPeriode As System.Windows.Forms.CheckBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtID As System.Windows.Forms.TextBox
    Friend WithEvents cbID As System.Windows.Forms.CheckBox
    Friend WithEvents dgvList As System.Windows.Forms.DataGridView
    Friend WithEvents dgvExport As System.Windows.Forms.DataGridView
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnLoad As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents dgvExportDetil As System.Windows.Forms.DataGridView
    Friend WithEvents btnRemoveAll As System.Windows.Forms.Button
    Friend WithEvents btnSelectAll As System.Windows.Forms.Button
End Class
