<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgTrnJurnal_PV_List_AP_MessageBox_PostingListResult
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.dgvResultPosting = New System.Windows.Forms.DataGridView()
        Me.obj_txTotal = New DevExpress.XtraEditors.TextEdit()
        Me.obj_txSuccess = New DevExpress.XtraEditors.TextEdit()
        Me.obj_txFailed = New DevExpress.XtraEditors.TextEdit()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvResultPosting, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.obj_txTotal.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.obj_txSuccess.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.obj_txFailed.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.obj_txFailed)
        Me.Panel1.Controls.Add(Me.obj_txSuccess)
        Me.Panel1.Controls.Add(Me.obj_txTotal)
        Me.Panel1.Controls.Add(Me.btnOK)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 225)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(562, 36)
        Me.Panel1.TabIndex = 0
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(417, 7)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(133, 23)
        Me.btnOK.TabIndex = 0
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'dgvResultPosting
        '
        Me.dgvResultPosting.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        Me.dgvResultPosting.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvResultPosting.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvResultPosting.Location = New System.Drawing.Point(0, 0)
        Me.dgvResultPosting.Name = "dgvResultPosting"
        Me.dgvResultPosting.Size = New System.Drawing.Size(562, 225)
        Me.dgvResultPosting.TabIndex = 1
        '
        'obj_txTotal
        '
        Me.obj_txTotal.Location = New System.Drawing.Point(52, 8)
        Me.obj_txTotal.Name = "obj_txTotal"
        Me.obj_txTotal.Properties.ReadOnly = True
        Me.obj_txTotal.Size = New System.Drawing.Size(40, 20)
        Me.obj_txTotal.TabIndex = 1
        '
        'obj_txSuccess
        '
        Me.obj_txSuccess.Location = New System.Drawing.Point(153, 8)
        Me.obj_txSuccess.Name = "obj_txSuccess"
        Me.obj_txSuccess.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.obj_txSuccess.Properties.Appearance.Options.UseForeColor = True
        Me.obj_txSuccess.Properties.ReadOnly = True
        Me.obj_txSuccess.Size = New System.Drawing.Size(40, 20)
        Me.obj_txSuccess.TabIndex = 1
        '
        'obj_txFailed
        '
        Me.obj_txFailed.Location = New System.Drawing.Point(251, 8)
        Me.obj_txFailed.Name = "obj_txFailed"
        Me.obj_txFailed.Properties.Appearance.ForeColor = System.Drawing.Color.Red
        Me.obj_txFailed.Properties.Appearance.Options.UseForeColor = True
        Me.obj_txFailed.Properties.ReadOnly = True
        Me.obj_txFailed.Size = New System.Drawing.Size(40, 20)
        Me.obj_txFailed.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(18, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(31, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Total"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(102, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Success"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(213, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Failed"
        '
        'dlgTrnJurnal_PV_List_AP_MessageBox_PostingListResult
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(562, 261)
        Me.Controls.Add(Me.dgvResultPosting)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "dlgTrnJurnal_PV_List_AP_MessageBox_PostingListResult"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PV numbers are failed to post / unpost"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgvResultPosting, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.obj_txTotal.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.obj_txSuccess.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.obj_txFailed.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents dgvResultPosting As System.Windows.Forms.DataGridView
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents obj_txFailed As DevExpress.XtraEditors.TextEdit
    Friend WithEvents obj_txSuccess As DevExpress.XtraEditors.TextEdit
    Friend WithEvents obj_txTotal As DevExpress.XtraEditors.TextEdit
End Class
