<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgTrnJurnal_PV_List_TransferRekening
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.DgvDetil = New System.Windows.Forms.DataGridView()
        Me.Btn_Add = New System.Windows.Forms.Button()
        Me.btn_listRekening = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtHitung = New System.Windows.Forms.TextBox()
        Me.btn_RekeningArtis = New System.Windows.Forms.Button()
        Me.btn_RekananOther = New System.Windows.Forms.Button()
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
        Me.DgvDetil.GridColor = System.Drawing.Color.Moccasin
        Me.DgvDetil.Location = New System.Drawing.Point(15, 12)
        Me.DgvDetil.Name = "DgvDetil"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Comic Sans MS", 8.0!)
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.DarkViolet
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvDetil.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.DgvDetil.Size = New System.Drawing.Size(909, 329)
        Me.DgvDetil.TabIndex = 77
        '
        'Btn_Add
        '
        Me.Btn_Add.Location = New System.Drawing.Point(15, 347)
        Me.Btn_Add.Name = "Btn_Add"
        Me.Btn_Add.Size = New System.Drawing.Size(75, 21)
        Me.Btn_Add.TabIndex = 78
        Me.Btn_Add.Text = "+ ( Row )"
        Me.Btn_Add.UseVisualStyleBackColor = True
        '
        'btn_listRekening
        '
        Me.btn_listRekening.Location = New System.Drawing.Point(15, 346)
        Me.btn_listRekening.Name = "btn_listRekening"
        Me.btn_listRekening.Size = New System.Drawing.Size(122, 23)
        Me.btn_listRekening.TabIndex = 79
        Me.btn_listRekening.Text = "[+]Rekening Rekanan"
        Me.btn_listRekening.UseVisualStyleBackColor = True
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
        'btn_RekeningArtis
        '
        Me.btn_RekeningArtis.Location = New System.Drawing.Point(263, 346)
        Me.btn_RekeningArtis.Name = "btn_RekeningArtis"
        Me.btn_RekeningArtis.Size = New System.Drawing.Size(99, 23)
        Me.btn_RekeningArtis.TabIndex = 82
        Me.btn_RekeningArtis.Text = "[+]Rekening Artis"
        Me.btn_RekeningArtis.UseVisualStyleBackColor = True
        '
        'btn_RekananOther
        '
        Me.btn_RekananOther.Location = New System.Drawing.Point(147, 346)
        Me.btn_RekananOther.Name = "btn_RekananOther"
        Me.btn_RekananOther.Size = New System.Drawing.Size(107, 22)
        Me.btn_RekananOther.TabIndex = 84
        Me.btn_RekananOther.Text = "[+]Rekening Other"
        Me.btn_RekananOther.UseVisualStyleBackColor = True
        '
        'dlgTrnJurnal_PV_List_TransferRekening
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(937, 372)
        Me.ControlBox = False
        Me.Controls.Add(Me.btn_RekananOther)
        Me.Controls.Add(Me.btn_RekeningArtis)
        Me.Controls.Add(Me.txtHitung)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btn_listRekening)
        Me.Controls.Add(Me.Btn_Add)
        Me.Controls.Add(Me.DgvDetil)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOk)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "dlgTrnJurnal_PV_List_TransferRekening"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Jurnal PV - List Transfer"
        CType(Me.DgvDetil, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents DgvDetil As System.Windows.Forms.DataGridView
    Friend WithEvents Btn_Add As System.Windows.Forms.Button
    Friend WithEvents btn_listRekening As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtHitung As System.Windows.Forms.TextBox
    Friend WithEvents btn_RekeningArtis As System.Windows.Forms.Button
    Friend WithEvents btn_RekananOther As System.Windows.Forms.Button

End Class
