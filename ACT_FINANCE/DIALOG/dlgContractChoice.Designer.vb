<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgContractChoice
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.btn_ok = New System.Windows.Forms.Button
        Me.btn_cancel = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.dgvContract = New System.Windows.Forms.DataGridView
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvContract, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.btn_ok, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btn_cancel, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(549, 319)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'btn_ok
        '
        Me.btn_ok.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btn_ok.Location = New System.Drawing.Point(3, 3)
        Me.btn_ok.Name = "btn_ok"
        Me.btn_ok.Size = New System.Drawing.Size(67, 23)
        Me.btn_ok.TabIndex = 0
        Me.btn_ok.Text = "OK"
        '
        'btn_cancel
        '
        Me.btn_cancel.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btn_cancel.Location = New System.Drawing.Point(76, 3)
        Me.btn_cancel.Name = "btn_cancel"
        Me.btn_cancel.Size = New System.Drawing.Size(67, 23)
        Me.btn_cancel.TabIndex = 1
        Me.btn_cancel.Text = "Cancel"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.dgvContract)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(707, 311)
        Me.Panel1.TabIndex = 1
        '
        'dgvContract
        '
        Me.dgvContract.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvContract.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvContract.Location = New System.Drawing.Point(0, 0)
        Me.dgvContract.Name = "dgvContract"
        Me.dgvContract.Size = New System.Drawing.Size(707, 311)
        Me.dgvContract.TabIndex = 0
        '
        'dlgContractChoice
        '
        Me.AcceptButton = Me.btn_ok
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btn_cancel
        Me.ClientSize = New System.Drawing.Size(707, 350)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgContractChoice"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "List Rekening"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.dgvContract, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btn_ok As System.Windows.Forms.Button
    Friend WithEvents btn_cancel As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents dgvContract As System.Windows.Forms.DataGridView

End Class
