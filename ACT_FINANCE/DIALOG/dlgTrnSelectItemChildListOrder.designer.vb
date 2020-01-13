<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgTrnSelectItemChildListOrder
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
        Me.components = New System.ComponentModel.Container
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.DgvAdvanceItemDetil = New System.Windows.Forms.DataGridView
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CopyItemToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DgvRefOrder = New System.Windows.Forms.DataGridView
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label1 = New System.Windows.Forms.Label
        Me.obj_total_amount = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btn_unbudget = New System.Windows.Forms.Button
        Me.addBudgetDetil = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnOK = New System.Windows.Forms.Button
        Me.GroupBox2.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.DgvAdvanceItemDetil, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.DgvRefOrder, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Panel2)
        Me.GroupBox2.Controls.Add(Me.Panel1)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(808, 374)
        Me.GroupBox2.TabIndex = 61
        Me.GroupBox2.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.DgvAdvanceItemDetil)
        Me.Panel2.Controls.Add(Me.DgvRefOrder)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(3, 16)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(802, 326)
        Me.Panel2.TabIndex = 56
        '
        'DgvAdvanceItemDetil
        '
        Me.DgvAdvanceItemDetil.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvAdvanceItemDetil.ContextMenuStrip = Me.ContextMenuStrip1
        Me.DgvAdvanceItemDetil.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvAdvanceItemDetil.Location = New System.Drawing.Point(0, 0)
        Me.DgvAdvanceItemDetil.Name = "DgvAdvanceItemDetil"
        Me.DgvAdvanceItemDetil.Size = New System.Drawing.Size(802, 326)
        Me.DgvAdvanceItemDetil.TabIndex = 55
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CopyItemToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(136, 26)
        '
        'CopyItemToolStripMenuItem
        '
        Me.CopyItemToolStripMenuItem.Name = "CopyItemToolStripMenuItem"
        Me.CopyItemToolStripMenuItem.Size = New System.Drawing.Size(135, 22)
        Me.CopyItemToolStripMenuItem.Text = "Copy Item"
        '
        'DgvRefOrder
        '
        Me.DgvRefOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvRefOrder.ContextMenuStrip = Me.ContextMenuStrip1
        Me.DgvRefOrder.Location = New System.Drawing.Point(372, 3)
        Me.DgvRefOrder.Name = "DgvRefOrder"
        Me.DgvRefOrder.Size = New System.Drawing.Size(349, 291)
        Me.DgvRefOrder.TabIndex = 56
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.obj_total_amount)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(3, 342)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(802, 29)
        Me.Panel1.TabIndex = 55
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(570, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Total Amount"
        '
        'obj_total_amount
        '
        Me.obj_total_amount.BackColor = System.Drawing.Color.SeaShell
        Me.obj_total_amount.Location = New System.Drawing.Point(650, 5)
        Me.obj_total_amount.Name = "obj_total_amount"
        Me.obj_total_amount.ReadOnly = True
        Me.obj_total_amount.Size = New System.Drawing.Size(149, 20)
        Me.obj_total_amount.TabIndex = 0
        Me.obj_total_amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btn_unbudget)
        Me.GroupBox1.Controls.Add(Me.addBudgetDetil)
        Me.GroupBox1.Controls.Add(Me.btnCancel)
        Me.GroupBox1.Controls.Add(Me.btnOK)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 393)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(808, 43)
        Me.GroupBox1.TabIndex = 59
        Me.GroupBox1.TabStop = False
        '
        'btn_unbudget
        '
        Me.btn_unbudget.Location = New System.Drawing.Point(91, 14)
        Me.btn_unbudget.Name = "btn_unbudget"
        Me.btn_unbudget.Size = New System.Drawing.Size(75, 24)
        Me.btn_unbudget.TabIndex = 5
        Me.btn_unbudget.Text = "UnBudget"
        Me.btn_unbudget.UseVisualStyleBackColor = True
        '
        'addBudgetDetil
        '
        Me.addBudgetDetil.Location = New System.Drawing.Point(10, 14)
        Me.addBudgetDetil.Name = "addBudgetDetil"
        Me.addBudgetDetil.Size = New System.Drawing.Size(75, 24)
        Me.addBudgetDetil.TabIndex = 4
        Me.addBudgetDetil.Text = "[+] Row"
        Me.addBudgetDetil.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(730, 15)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(649, 15)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 2
        Me.btnOK.Text = "&OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'dlgTrnSelectItemChildListOrder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(826, 439)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "dlgTrnSelectItemChildListOrder"
        Me.Text = "Select Item Budget Detil"
        Me.GroupBox2.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.DgvAdvanceItemDetil, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.DgvRefOrder, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents addBudgetDetil As System.Windows.Forms.Button
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents CopyItemToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents DgvAdvanceItemDetil As System.Windows.Forms.DataGridView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents obj_total_amount As System.Windows.Forms.TextBox
    Friend WithEvents btn_unbudget As System.Windows.Forms.Button
    Friend WithEvents DgvRefOrder As System.Windows.Forms.DataGridView

End Class
