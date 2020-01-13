<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgRptJurnal_PV_ChoiceTravel
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(dlgRptJurnal_PV_ChoiceTravel))
        Me.btnJurnalVoucher = New System.Windows.Forms.Button()
        Me.btn_AdvanceTravel = New System.Windows.Forms.Button()
        Me.btnPaymentVoucher = New System.Windows.Forms.Button()
        Me.chkPaymentVoucher = New System.Windows.Forms.CheckBox()
        Me.chkJournalVoucher = New System.Windows.Forms.CheckBox()
        Me.chkAdvanceTravel = New System.Windows.Forms.CheckBox()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.pnlHeader.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnJurnalVoucher
        '
        Me.btnJurnalVoucher.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnJurnalVoucher.BackgroundImage = Global.ACT_FINANCE.My.Resources.Resources.BookMark_s
        Me.btnJurnalVoucher.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnJurnalVoucher.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnJurnalVoucher.Enabled = False
        Me.btnJurnalVoucher.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnJurnalVoucher.ForeColor = System.Drawing.Color.Black
        Me.btnJurnalVoucher.Location = New System.Drawing.Point(292, 12)
        Me.btnJurnalVoucher.Name = "btnJurnalVoucher"
        Me.btnJurnalVoucher.Size = New System.Drawing.Size(130, 94)
        Me.btnJurnalVoucher.TabIndex = 4
        Me.btnJurnalVoucher.Text = "Journal Voucher"
        Me.btnJurnalVoucher.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnJurnalVoucher.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnJurnalVoucher.UseVisualStyleBackColor = False
        '
        'btn_AdvanceTravel
        '
        Me.btn_AdvanceTravel.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_AdvanceTravel.BackgroundImage = Global.ACT_FINANCE.My.Resources.Resources.box_s
        Me.btn_AdvanceTravel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btn_AdvanceTravel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_AdvanceTravel.Enabled = False
        Me.btn_AdvanceTravel.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_AdvanceTravel.Location = New System.Drawing.Point(153, 12)
        Me.btn_AdvanceTravel.Name = "btn_AdvanceTravel"
        Me.btn_AdvanceTravel.Size = New System.Drawing.Size(130, 94)
        Me.btn_AdvanceTravel.TabIndex = 3
        Me.btn_AdvanceTravel.Text = "Advance Travel"
        Me.btn_AdvanceTravel.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_AdvanceTravel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_AdvanceTravel.UseVisualStyleBackColor = False
        '
        'btnPaymentVoucher
        '
        Me.btnPaymentVoucher.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnPaymentVoucher.BackgroundImage = CType(resources.GetObject("btnPaymentVoucher.BackgroundImage"), System.Drawing.Image)
        Me.btnPaymentVoucher.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnPaymentVoucher.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPaymentVoucher.Enabled = False
        Me.btnPaymentVoucher.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPaymentVoucher.Location = New System.Drawing.Point(12, 12)
        Me.btnPaymentVoucher.Name = "btnPaymentVoucher"
        Me.btnPaymentVoucher.Size = New System.Drawing.Size(130, 95)
        Me.btnPaymentVoucher.TabIndex = 1
        Me.btnPaymentVoucher.Text = "Payment Voucher"
        Me.btnPaymentVoucher.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnPaymentVoucher.UseVisualStyleBackColor = False
        '
        'chkPaymentVoucher
        '
        Me.chkPaymentVoucher.AutoSize = True
        Me.chkPaymentVoucher.Location = New System.Drawing.Point(17, 113)
        Me.chkPaymentVoucher.Name = "chkPaymentVoucher"
        Me.chkPaymentVoucher.Size = New System.Drawing.Size(110, 17)
        Me.chkPaymentVoucher.TabIndex = 6
        Me.chkPaymentVoucher.Text = "Payment Voucher"
        Me.chkPaymentVoucher.UseVisualStyleBackColor = True
        '
        'chkJournalVoucher
        '
        Me.chkJournalVoucher.AutoSize = True
        Me.chkJournalVoucher.Location = New System.Drawing.Point(292, 113)
        Me.chkJournalVoucher.Name = "chkJournalVoucher"
        Me.chkJournalVoucher.Size = New System.Drawing.Size(103, 17)
        Me.chkJournalVoucher.TabIndex = 7
        Me.chkJournalVoucher.Text = "Journal Voucher"
        Me.chkJournalVoucher.UseVisualStyleBackColor = True
        '
        'chkAdvanceTravel
        '
        Me.chkAdvanceTravel.AutoSize = True
        Me.chkAdvanceTravel.Location = New System.Drawing.Point(153, 112)
        Me.chkAdvanceTravel.Name = "chkAdvanceTravel"
        Me.chkAdvanceTravel.Size = New System.Drawing.Size(102, 17)
        Me.chkAdvanceTravel.TabIndex = 8
        Me.chkAdvanceTravel.Text = "Advance Travel"
        Me.chkAdvanceTravel.UseVisualStyleBackColor = True
        '
        'pnlHeader
        '
        Me.pnlHeader.Controls.Add(Me.chkPaymentVoucher)
        Me.pnlHeader.Controls.Add(Me.chkAdvanceTravel)
        Me.pnlHeader.Controls.Add(Me.chkJournalVoucher)
        Me.pnlHeader.Controls.Add(Me.btnJurnalVoucher)
        Me.pnlHeader.Controls.Add(Me.btnPaymentVoucher)
        Me.pnlHeader.Controls.Add(Me.btn_AdvanceTravel)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(433, 150)
        Me.pnlHeader.TabIndex = 9
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(12, 156)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(75, 23)
        Me.btnPrint.TabIndex = 0
        Me.btnPrint.Text = "Print"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'dlgRptJurnal_PV_ChoiceTravel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(433, 189)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.pnlHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgRptJurnal_PV_ChoiceTravel"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Print Selection"
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnPaymentVoucher As System.Windows.Forms.Button
    Friend WithEvents btn_AdvanceTravel As System.Windows.Forms.Button
    Friend WithEvents btnJurnalVoucher As System.Windows.Forms.Button
    Friend WithEvents chkPaymentVoucher As System.Windows.Forms.CheckBox
    Friend WithEvents chkJournalVoucher As System.Windows.Forms.CheckBox
    Friend WithEvents chkAdvanceTravel As System.Windows.Forms.CheckBox
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents btnPrint As System.Windows.Forms.Button

End Class
