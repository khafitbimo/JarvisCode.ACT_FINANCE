<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgTrnJurnal_PV_List_TransferRekeningWinner
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.DgvDetil = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtHitung = New System.Windows.Forms.TextBox()
        Me.btn_RekeningWinner = New System.Windows.Forms.Button()
        CType(Me.DgvDetil, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnOk
        '
        Me.btnOk.Location = New System.Drawing.Point(768, 347)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(75, 21)
        Me.btnOk.TabIndex = 13
        Me.btnOk.Text = "Ok"
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(849, 347)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 21)
        Me.btnCancel.TabIndex = 14
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'DgvDetil
        '
        Me.DgvDetil.AllowUserToAddRows = False
        Me.DgvDetil.AllowUserToDeleteRows = False
        Me.DgvDetil.BackgroundColor = System.Drawing.Color.Lavender
        Me.DgvDetil.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle13.Font = New System.Drawing.Font("Comic Sans MS", 8.0!)
        DataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle13.SelectionBackColor = System.Drawing.Color.DarkViolet
        DataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvDetil.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle13
        Me.DgvDetil.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvDetil.Cursor = System.Windows.Forms.Cursors.Hand
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Comic Sans MS", 8.0!)
        DataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.DarkViolet
        DataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgvDetil.DefaultCellStyle = DataGridViewCellStyle14
        Me.DgvDetil.GridColor = System.Drawing.Color.Moccasin
        Me.DgvDetil.Location = New System.Drawing.Point(15, 12)
        Me.DgvDetil.Name = "DgvDetil"
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle15.Font = New System.Drawing.Font("Comic Sans MS", 8.0!)
        DataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.DarkViolet
        DataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvDetil.RowHeadersDefaultCellStyle = DataGridViewCellStyle15
        Me.DgvDetil.Size = New System.Drawing.Size(909, 329)
        Me.DgvDetil.TabIndex = 77
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(566, 348)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 80
        Me.Label1.Text = "Amount"
        '
        'txtHitung
        '
        Me.txtHitung.Enabled = False
        Me.txtHitung.Location = New System.Drawing.Point(615, 345)
        Me.txtHitung.Name = "txtHitung"
        Me.txtHitung.Size = New System.Drawing.Size(100, 20)
        Me.txtHitung.TabIndex = 81
        Me.txtHitung.Text = "0.00"
        Me.txtHitung.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btn_RekeningWinner
        '
        Me.btn_RekeningWinner.Location = New System.Drawing.Point(15, 345)
        Me.btn_RekeningWinner.Name = "btn_RekeningWinner"
        Me.btn_RekeningWinner.Size = New System.Drawing.Size(117, 23)
        Me.btn_RekeningWinner.TabIndex = 85
        Me.btn_RekeningWinner.Text = "[+] Rekening Winner"
        Me.btn_RekeningWinner.UseVisualStyleBackColor = True
        '
        'dlgTrnJurnal_PV_List_TransferRekeningWinner
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(937, 372)
        Me.ControlBox = False
        Me.Controls.Add(Me.btn_RekeningWinner)
        Me.Controls.Add(Me.txtHitung)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DgvDetil)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOk)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "dlgTrnJurnal_PV_List_TransferRekeningWinner"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Jurnal PV - List Transfer Winner"
        CType(Me.DgvDetil, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents DgvDetil As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtHitung As System.Windows.Forms.TextBox
    Friend WithEvents btn_RekeningWinner As System.Windows.Forms.Button

End Class
