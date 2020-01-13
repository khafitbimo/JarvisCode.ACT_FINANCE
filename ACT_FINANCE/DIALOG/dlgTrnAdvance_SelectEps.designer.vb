<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgTrnAdvance_SelectEps
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
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.DgvOrderdetiluse = New System.Windows.Forms.DataGridView
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.obj_Budget_name = New System.Windows.Forms.TextBox
        Me.obj_eps_end = New System.Windows.Forms.TextBox
        Me.obj_eps_start = New System.Windows.Forms.TextBox
        Me.btnGenerate = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.obj_Advancedetil_line = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnOK = New System.Windows.Forms.Button
        Me.GroupBox2.SuspendLayout()
        CType(Me.DgvOrderdetiluse, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.DgvOrderdetiluse)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 110)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(397, 276)
        Me.GroupBox2.TabIndex = 61
        Me.GroupBox2.TabStop = False
        '
        'DgvOrderdetiluse
        '
        Me.DgvOrderdetiluse.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvOrderdetiluse.Location = New System.Drawing.Point(10, 15)
        Me.DgvOrderdetiluse.Name = "DgvOrderdetiluse"
        Me.DgvOrderdetiluse.Size = New System.Drawing.Size(374, 255)
        Me.DgvOrderdetiluse.TabIndex = 54
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.obj_Budget_name)
        Me.GroupBox3.Controls.Add(Me.obj_eps_end)
        Me.GroupBox3.Controls.Add(Me.obj_eps_start)
        Me.GroupBox3.Controls.Add(Me.btnGenerate)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.obj_Advancedetil_line)
        Me.GroupBox3.Location = New System.Drawing.Point(6, 2)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(397, 97)
        Me.GroupBox3.TabIndex = 60
        Me.GroupBox3.TabStop = False
        '
        'obj_Budget_name
        '
        Me.obj_Budget_name.Location = New System.Drawing.Point(91, 61)
        Me.obj_Budget_name.Name = "obj_Budget_name"
        Me.obj_Budget_name.Size = New System.Drawing.Size(276, 20)
        Me.obj_Budget_name.TabIndex = 82
        '
        'obj_eps_end
        '
        Me.obj_eps_end.Location = New System.Drawing.Point(269, 38)
        Me.obj_eps_end.Name = "obj_eps_end"
        Me.obj_eps_end.Size = New System.Drawing.Size(98, 20)
        Me.obj_eps_end.TabIndex = 81
        '
        'obj_eps_start
        '
        Me.obj_eps_start.Location = New System.Drawing.Point(91, 38)
        Me.obj_eps_start.Name = "obj_eps_start"
        Me.obj_eps_start.Size = New System.Drawing.Size(98, 20)
        Me.obj_eps_start.TabIndex = 80
        '
        'btnGenerate
        '
        Me.btnGenerate.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.btnGenerate.Enabled = False
        Me.btnGenerate.Location = New System.Drawing.Point(255, 9)
        Me.btnGenerate.Name = "btnGenerate"
        Me.btnGenerate.Size = New System.Drawing.Size(112, 23)
        Me.btnGenerate.TabIndex = 79
        Me.btnGenerate.Text = "&Apply Changes"
        Me.btnGenerate.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(13, 64)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 13)
        Me.Label5.TabIndex = 73
        Me.Label5.Text = "Budget Name"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(27, 13)
        Me.Label3.TabIndex = 70
        Me.Label3.Text = "Line"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(221, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(26, 13)
        Me.Label2.TabIndex = 69
        Me.Label2.Text = "End"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 13)
        Me.Label1.TabIndex = 68
        Me.Label1.Text = "Start"
        '
        'obj_Advancedetil_line
        '
        Me.obj_Advancedetil_line.BackColor = System.Drawing.Color.Gainsboro
        Me.obj_Advancedetil_line.Location = New System.Drawing.Point(91, 15)
        Me.obj_Advancedetil_line.Name = "obj_Advancedetil_line"
        Me.obj_Advancedetil_line.ReadOnly = True
        Me.obj_Advancedetil_line.Size = New System.Drawing.Size(98, 20)
        Me.obj_Advancedetil_line.TabIndex = 67
        Me.obj_Advancedetil_line.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnCancel)
        Me.GroupBox1.Controls.Add(Me.btnOK)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 393)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(397, 43)
        Me.GroupBox1.TabIndex = 59
        Me.GroupBox1.TabStop = False
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(309, 14)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(224, 14)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 2
        Me.btnOK.Text = "&OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'dlgTrnAdvance_SelectEps
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(415, 439)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "dlgTrnAdvance_SelectEps"
        Me.Text = "Select Eps"
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.DgvOrderdetiluse, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents DgvOrderdetiluse As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents btnGenerate As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents obj_Advancedetil_line As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents obj_eps_end As System.Windows.Forms.TextBox
    Friend WithEvents obj_eps_start As System.Windows.Forms.TextBox
    Friend WithEvents obj_Budget_name As System.Windows.Forms.TextBox
End Class
