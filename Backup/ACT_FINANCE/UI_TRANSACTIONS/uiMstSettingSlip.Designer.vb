<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class uiMstSettingSlip
    Inherits ACT_FINANCE.uiBase

    'UserControl overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(uiMstSettingSlip))
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.btnFindPrinter = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtPrinterName = New System.Windows.Forms.TextBox
        CType(Me.tbl_MstSetting, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Location = New System.Drawing.Point(1, 26)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(751, 523)
        Me.TabControl1.TabIndex = 2
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.TabPage1.Controls.Add(Me.btnFindPrinter)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.txtPrinterName)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(743, 497)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = " Slip Setup "
        '
        'btnFindPrinter
        '
        Me.btnFindPrinter.Location = New System.Drawing.Point(517, 236)
        Me.btnFindPrinter.Name = "btnFindPrinter"
        Me.btnFindPrinter.Size = New System.Drawing.Size(75, 23)
        Me.btnFindPrinter.TabIndex = 14
        Me.btnFindPrinter.Text = "Find Printer"
        Me.btnFindPrinter.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(151, 239)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 13)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Printer Name"
        '
        'txtPrinterName
        '
        Me.txtPrinterName.Location = New System.Drawing.Point(225, 236)
        Me.txtPrinterName.Name = "txtPrinterName"
        Me.txtPrinterName.Size = New System.Drawing.Size(286, 20)
        Me.txtPrinterName.TabIndex = 12
        '
        'uiMstSettingSlip
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TabControl1)
        Me.DSN = resources.GetString("$this.DSN")
        Me.Name = "uiMstSettingSlip"
        Me.Controls.SetChildIndex(Me.TabControl1, 0)
        CType(Me.tbl_MstSetting, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents btnFindPrinter As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtPrinterName As System.Windows.Forms.TextBox

End Class
