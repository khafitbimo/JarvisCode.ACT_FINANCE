<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgTrnJurnal_PV_List_RekeningWinner
    Inherits System.Windows.Forms.Form

    '''Form overrides dispose to clean up the component list.
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
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.ftabData = New FlatTabControl.FlatTabControl()
        Me.ftabData_Rekening = New System.Windows.Forms.TabPage()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.dgvWinnerName = New System.Windows.Forms.DataGridView()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lb_rekananname = New System.Windows.Forms.Label()
        Me.DgvRekening = New System.Windows.Forms.DataGridView()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.lbl_rekeninglist = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btn_cancel = New System.Windows.Forms.Button()
        Me.btn_Ok = New System.Windows.Forms.Button()
        Me.ftabData.SuspendLayout()
        Me.ftabData_Rekening.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.dgvWinnerName, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.DgvRekening, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(400, 337)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 8
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(319, 337)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 7
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'ftabData
        '
        Me.ftabData.Controls.Add(Me.ftabData_Rekening)
        Me.ftabData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ftabData.Location = New System.Drawing.Point(0, 0)
        Me.ftabData.myBackColor = System.Drawing.Color.WhiteSmoke
        Me.ftabData.Name = "ftabData"
        Me.ftabData.SelectedIndex = 0
        Me.ftabData.Size = New System.Drawing.Size(817, 365)
        Me.ftabData.TabIndex = 20
        '
        'ftabData_Rekening
        '
        Me.ftabData_Rekening.BackColor = System.Drawing.Color.LavenderBlush
        Me.ftabData_Rekening.Controls.Add(Me.SplitContainer1)
        Me.ftabData_Rekening.Controls.Add(Me.Panel3)
        Me.ftabData_Rekening.Location = New System.Drawing.Point(4, 25)
        Me.ftabData_Rekening.Name = "ftabData_Rekening"
        Me.ftabData_Rekening.Padding = New System.Windows.Forms.Padding(3)
        Me.ftabData_Rekening.Size = New System.Drawing.Size(809, 336)
        Me.ftabData_Rekening.TabIndex = 0
        Me.ftabData_Rekening.Text = "Rekening"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(3, 3)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.dgvWinnerName)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel2)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.DgvRekening)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Panel4)
        Me.SplitContainer1.Size = New System.Drawing.Size(803, 302)
        Me.SplitContainer1.SplitterDistance = 210
        Me.SplitContainer1.TabIndex = 7
        '
        'dgvWinnerName
        '
        Me.dgvWinnerName.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvWinnerName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvWinnerName.Location = New System.Drawing.Point(0, 27)
        Me.dgvWinnerName.MultiSelect = False
        Me.dgvWinnerName.Name = "dgvWinnerName"
        Me.dgvWinnerName.RowHeadersVisible = False
        Me.dgvWinnerName.Size = New System.Drawing.Size(210, 275)
        Me.dgvWinnerName.TabIndex = 6
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Lavender
        Me.Panel2.Controls.Add(Me.lb_rekananname)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(210, 27)
        Me.Panel2.TabIndex = 7
        '
        'lb_rekananname
        '
        Me.lb_rekananname.AutoSize = True
        Me.lb_rekananname.Location = New System.Drawing.Point(3, 7)
        Me.lb_rekananname.Name = "lb_rekananname"
        Me.lb_rekananname.Size = New System.Drawing.Size(51, 13)
        Me.lb_rekananname.TabIndex = 0
        Me.lb_rekananname.Text = "Rekanan"
        '
        'DgvRekening
        '
        Me.DgvRekening.AllowUserToAddRows = False
        Me.DgvRekening.AllowUserToDeleteRows = False
        Me.DgvRekening.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvRekening.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvRekening.Location = New System.Drawing.Point(0, 27)
        Me.DgvRekening.MultiSelect = False
        Me.DgvRekening.Name = "DgvRekening"
        Me.DgvRekening.ReadOnly = True
        Me.DgvRekening.RowHeadersVisible = False
        Me.DgvRekening.Size = New System.Drawing.Size(589, 275)
        Me.DgvRekening.TabIndex = 0
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.lbl_rekeninglist)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(589, 27)
        Me.Panel4.TabIndex = 8
        '
        'lbl_rekeninglist
        '
        Me.lbl_rekeninglist.AutoSize = True
        Me.lbl_rekeninglist.Location = New System.Drawing.Point(3, 6)
        Me.lbl_rekeninglist.Name = "lbl_rekeninglist"
        Me.lbl_rekeninglist.Size = New System.Drawing.Size(72, 13)
        Me.lbl_rekeninglist.TabIndex = 0
        Me.lbl_rekeninglist.Text = "Rekening List"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.btn_cancel)
        Me.Panel3.Controls.Add(Me.btn_Ok)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(3, 305)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(803, 28)
        Me.Panel3.TabIndex = 5
        '
        'btn_cancel
        '
        Me.btn_cancel.Location = New System.Drawing.Point(729, 3)
        Me.btn_cancel.Name = "btn_cancel"
        Me.btn_cancel.Size = New System.Drawing.Size(71, 23)
        Me.btn_cancel.TabIndex = 1
        Me.btn_cancel.Text = "&Cancel"
        Me.btn_cancel.UseVisualStyleBackColor = True
        '
        'btn_Ok
        '
        Me.btn_Ok.Location = New System.Drawing.Point(655, 3)
        Me.btn_Ok.Name = "btn_Ok"
        Me.btn_Ok.Size = New System.Drawing.Size(71, 23)
        Me.btn_Ok.TabIndex = 0
        Me.btn_Ok.Text = "&Ok"
        Me.btn_Ok.UseVisualStyleBackColor = True
        '
        'dlgTrnJurnal_PV_List_RekeningWinner
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(817, 365)
        Me.Controls.Add(Me.ftabData)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgTrnJurnal_PV_List_RekeningWinner"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "List Rekening Winner"
        Me.ftabData.ResumeLayout(False)
        Me.ftabData_Rekening.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.dgvWinnerName, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.DgvRekening, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents ftabData As FlatTabControl.FlatTabControl
    Friend WithEvents ftabData_Rekening As System.Windows.Forms.TabPage
    Friend WithEvents DgvRekening As System.Windows.Forms.DataGridView
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents btn_cancel As System.Windows.Forms.Button
    Friend WithEvents btn_Ok As System.Windows.Forms.Button
    Friend WithEvents dgvWinnerName As System.Windows.Forms.DataGridView
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lb_rekananname As System.Windows.Forms.Label
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents lbl_rekeninglist As System.Windows.Forms.Label

End Class
