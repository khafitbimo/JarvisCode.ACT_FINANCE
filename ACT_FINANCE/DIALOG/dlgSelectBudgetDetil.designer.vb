<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgSelectBudgetDetil
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
        Me.DgvTrnBudgetDetil = New System.Windows.Forms.DataGridView
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnOK = New System.Windows.Forms.Button
        Me.obj_search_type = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.obj_search_text = New System.Windows.Forms.TextBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Label3 = New System.Windows.Forms.Label
        Me.obj_eps_end = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.obj_eps_start = New System.Windows.Forms.TextBox
        CType(Me.DgvTrnBudgetDetil, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'DgvTrnBudgetDetil
        '
        Me.DgvTrnBudgetDetil.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvTrnBudgetDetil.Location = New System.Drawing.Point(0, 32)
        Me.DgvTrnBudgetDetil.Name = "DgvTrnBudgetDetil"
        Me.DgvTrnBudgetDetil.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvTrnBudgetDetil.Size = New System.Drawing.Size(619, 289)
        Me.DgvTrnBudgetDetil.TabIndex = 1
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(531, 8)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 8
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(454, 8)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 7
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
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
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 13)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Search"
        '
        'obj_search_text
        '
        Me.obj_search_text.Location = New System.Drawing.Point(124, 5)
        Me.obj_search_text.Name = "obj_search_text"
        Me.obj_search_text.Size = New System.Drawing.Size(145, 20)
        Me.obj_search_text.TabIndex = 16
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.obj_search_type)
        Me.Panel1.Controls.Add(Me.obj_search_text)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(618, 32)
        Me.Panel1.TabIndex = 19
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.obj_eps_end)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.obj_eps_start)
        Me.Panel2.Controls.Add(Me.btnOK)
        Me.Panel2.Controls.Add(Me.btnCancel)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 327)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(618, 38)
        Me.Panel2.TabIndex = 20
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(94, 13)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(23, 13)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "To."
        '
        'obj_eps_end
        '
        Me.obj_eps_end.Location = New System.Drawing.Point(120, 10)
        Me.obj_eps_end.Name = "obj_eps_end"
        Me.obj_eps_end.Size = New System.Drawing.Size(57, 20)
        Me.obj_eps_end.TabIndex = 11
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(25, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Eps"
        '
        'obj_eps_start
        '
        Me.obj_eps_start.Location = New System.Drawing.Point(34, 10)
        Me.obj_eps_start.Name = "obj_eps_start"
        Me.obj_eps_start.Size = New System.Drawing.Size(57, 20)
        Me.obj_eps_start.TabIndex = 9
        '
        'dlgSelectBudgetDetil
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(618, 365)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.DgvTrnBudgetDetil)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgSelectBudgetDetil"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "dlgSelectBudgetDetil"
        CType(Me.DgvTrnBudgetDetil, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DgvTrnBudgetDetil As System.Windows.Forms.DataGridView
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents obj_search_type As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents obj_search_text As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents obj_eps_end As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents obj_eps_start As System.Windows.Forms.TextBox
End Class
