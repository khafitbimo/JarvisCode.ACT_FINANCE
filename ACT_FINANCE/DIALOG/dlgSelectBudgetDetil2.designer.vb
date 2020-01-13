<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgSelectBudgetDetil2
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
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label1 = New System.Windows.Forms.Label
        Me.obj_search_type = New System.Windows.Forms.ComboBox
        Me.obj_search_text = New System.Windows.Forms.TextBox
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.obj_check_eps = New System.Windows.Forms.CheckBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.obj_eps_end = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.obj_eps_start = New System.Windows.Forms.TextBox
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.DgvTrnBudgetDetil = New System.Windows.Forms.DataGridView
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.DgvTrnBudgetDetil, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.obj_search_type)
        Me.Panel1.Controls.Add(Me.obj_search_text)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(634, 32)
        Me.Panel1.TabIndex = 20
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 13)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Search"
        '
        'obj_search_type
        '
        Me.obj_search_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.obj_search_type.FormattingEnabled = True
        Me.obj_search_type.Location = New System.Drawing.Point(55, 5)
        Me.obj_search_type.Name = "obj_search_type"
        Me.obj_search_type.Size = New System.Drawing.Size(63, 21)
        Me.obj_search_type.TabIndex = 18
        '
        'obj_search_text
        '
        Me.obj_search_text.Location = New System.Drawing.Point(124, 5)
        Me.obj_search_text.Name = "obj_search_text"
        Me.obj_search_text.Size = New System.Drawing.Size(145, 20)
        Me.obj_search_text.TabIndex = 16
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.obj_check_eps)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.obj_eps_end)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.obj_eps_start)
        Me.Panel2.Controls.Add(Me.btnOK)
        Me.Panel2.Controls.Add(Me.btnCancel)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 325)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(634, 38)
        Me.Panel2.TabIndex = 21
        '
        'obj_check_eps
        '
        Me.obj_check_eps.AutoSize = True
        Me.obj_check_eps.Location = New System.Drawing.Point(12, 13)
        Me.obj_check_eps.Name = "obj_check_eps"
        Me.obj_check_eps.Size = New System.Drawing.Size(15, 14)
        Me.obj_check_eps.TabIndex = 13
        Me.obj_check_eps.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(121, 13)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(23, 13)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "To."
        '
        'obj_eps_end
        '
        Me.obj_eps_end.Enabled = False
        Me.obj_eps_end.Location = New System.Drawing.Point(147, 10)
        Me.obj_eps_end.Name = "obj_eps_end"
        Me.obj_eps_end.Size = New System.Drawing.Size(57, 20)
        Me.obj_eps_end.TabIndex = 11
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(30, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(25, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Eps"
        '
        'obj_eps_start
        '
        Me.obj_eps_start.Enabled = False
        Me.obj_eps_start.Location = New System.Drawing.Point(61, 10)
        Me.obj_eps_start.Name = "obj_eps_start"
        Me.obj_eps_start.Size = New System.Drawing.Size(57, 20)
        Me.obj_eps_start.TabIndex = 9
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(476, 8)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 7
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(553, 8)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 8
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.DgvTrnBudgetDetil)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 32)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(634, 293)
        Me.Panel3.TabIndex = 22
        '
        'DgvTrnBudgetDetil
        '
        Me.DgvTrnBudgetDetil.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvTrnBudgetDetil.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvTrnBudgetDetil.Location = New System.Drawing.Point(0, 0)
        Me.DgvTrnBudgetDetil.Name = "DgvTrnBudgetDetil"
        Me.DgvTrnBudgetDetil.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvTrnBudgetDetil.Size = New System.Drawing.Size(634, 293)
        Me.DgvTrnBudgetDetil.TabIndex = 2
        '
        'dlgSelectBudgetDetil2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(634, 363)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "dlgSelectBudgetDetil2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "List Budget Detil"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        CType(Me.DgvTrnBudgetDetil, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents obj_search_type As System.Windows.Forms.ComboBox
    Friend WithEvents obj_search_text As System.Windows.Forms.TextBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents obj_eps_end As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents obj_eps_start As System.Windows.Forms.TextBox
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents DgvTrnBudgetDetil As System.Windows.Forms.DataGridView
    Friend WithEvents obj_check_eps As System.Windows.Forms.CheckBox
End Class
