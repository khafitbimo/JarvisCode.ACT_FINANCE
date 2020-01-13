<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgRptJurnal_PV_Choice
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(dlgRptJurnal_PV_Choice))
        Me.btnJurnalVoucher = New System.Windows.Forms.Button
        Me.btn_SlipSetoran = New System.Windows.Forms.Button
        Me.btnFull = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'btnJurnalVoucher
        '
        Me.btnJurnalVoucher.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnJurnalVoucher.BackgroundImage = Global.ACT_FINANCE.My.Resources.Resources.BookMark_s
        Me.btnJurnalVoucher.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnJurnalVoucher.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnJurnalVoucher.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnJurnalVoucher.ForeColor = System.Drawing.Color.Black
        Me.btnJurnalVoucher.Location = New System.Drawing.Point(282, 11)
        Me.btnJurnalVoucher.Name = "btnJurnalVoucher"
        Me.btnJurnalVoucher.Size = New System.Drawing.Size(131, 101)
        Me.btnJurnalVoucher.TabIndex = 4
        Me.btnJurnalVoucher.Text = "Journal Voucher"
        Me.btnJurnalVoucher.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnJurnalVoucher.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnJurnalVoucher.UseVisualStyleBackColor = False
        '
        'btn_SlipSetoran
        '
        Me.btn_SlipSetoran.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_SlipSetoran.BackgroundImage = Global.ACT_FINANCE.My.Resources.Resources.box_s
        Me.btn_SlipSetoran.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btn_SlipSetoran.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_SlipSetoran.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_SlipSetoran.Location = New System.Drawing.Point(145, 11)
        Me.btn_SlipSetoran.Name = "btn_SlipSetoran"
        Me.btn_SlipSetoran.Size = New System.Drawing.Size(131, 101)
        Me.btn_SlipSetoran.TabIndex = 3
        Me.btn_SlipSetoran.Text = "Slip Setoran"
        Me.btn_SlipSetoran.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_SlipSetoran.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_SlipSetoran.UseVisualStyleBackColor = False
        '
        'btnFull
        '
        Me.btnFull.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnFull.BackgroundImage = CType(resources.GetObject("btnFull.BackgroundImage"), System.Drawing.Image)
        Me.btnFull.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnFull.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnFull.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFull.Location = New System.Drawing.Point(8, 10)
        Me.btnFull.Name = "btnFull"
        Me.btnFull.Size = New System.Drawing.Size(131, 102)
        Me.btnFull.TabIndex = 1
        Me.btnFull.Text = "Payment Voucher"
        Me.btnFull.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnFull.UseVisualStyleBackColor = False
        '
        'dlgRptJurnal_PV_Choice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(421, 123)
        Me.Controls.Add(Me.btnJurnalVoucher)
        Me.Controls.Add(Me.btn_SlipSetoran)
        Me.Controls.Add(Me.btnFull)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgRptJurnal_PV_Choice"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Print Selection"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnFull As System.Windows.Forms.Button
    Friend WithEvents btn_SlipSetoran As System.Windows.Forms.Button
    Friend WithEvents btnJurnalVoucher As System.Windows.Forms.Button

End Class
