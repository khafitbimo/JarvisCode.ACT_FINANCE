<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DlgProses
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
        Me.pnlLoading = New System.Windows.Forms.Panel
        Me.lblProgress = New System.Windows.Forms.Label
        Me.PBProses = New System.Windows.Forms.ProgressBar
        Me.pnlLoading.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlLoading
        '
        Me.pnlLoading.BackColor = System.Drawing.Color.Moccasin
        Me.pnlLoading.Controls.Add(Me.lblProgress)
        Me.pnlLoading.Controls.Add(Me.PBProses)
        Me.pnlLoading.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlLoading.Location = New System.Drawing.Point(0, 0)
        Me.pnlLoading.Name = "pnlLoading"
        Me.pnlLoading.Size = New System.Drawing.Size(288, 58)
        Me.pnlLoading.TabIndex = 51
        Me.pnlLoading.UseWaitCursor = True
        '
        'lblProgress
        '
        Me.lblProgress.AutoSize = True
        Me.lblProgress.Location = New System.Drawing.Point(14, 11)
        Me.lblProgress.Name = "lblProgress"
        Me.lblProgress.Size = New System.Drawing.Size(108, 13)
        Me.lblProgress.TabIndex = 57
        Me.lblProgress.Text = "Saving 0 of 0 records"
        Me.lblProgress.UseWaitCursor = True
        '
        'PBProses
        '
        Me.PBProses.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PBProses.ForeColor = System.Drawing.Color.Magenta
        Me.PBProses.Location = New System.Drawing.Point(17, 30)
        Me.PBProses.Name = "PBProses"
        Me.PBProses.RightToLeftLayout = True
        Me.PBProses.Size = New System.Drawing.Size(252, 12)
        Me.PBProses.Step = 5
        Me.PBProses.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.PBProses.TabIndex = 54
        Me.PBProses.UseWaitCursor = True
        '
        'DlgProses
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(288, 58)
        Me.ControlBox = False
        Me.Controls.Add(Me.pnlLoading)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "DlgProses"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.pnlLoading.ResumeLayout(False)
        Me.pnlLoading.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlLoading As System.Windows.Forms.Panel
    Friend WithEvents lblProgress As System.Windows.Forms.Label
    Friend WithEvents lblprogresPrs As System.Windows.Forms.Label
    Friend WithEvents PBProses As System.Windows.Forms.ProgressBar
End Class
