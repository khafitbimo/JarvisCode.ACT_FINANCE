<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgTrnCirculationRekanan
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(dlgTrnCirculationRekanan))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.LBHeader = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.LBBottom = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.DGVRekananList = New System.Windows.Forms.DataGridView()
        Me.ColPvID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColRekanan = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColDeskripsi = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.DGVRekananList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.LBHeader)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Padding = New System.Windows.Forms.Padding(3, 5, 0, 0)
        Me.Panel1.Size = New System.Drawing.Size(442, 37)
        Me.Panel1.TabIndex = 0
        '
        'LBHeader
        '
        Me.LBHeader.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LBHeader.Location = New System.Drawing.Point(3, 5)
        Me.LBHeader.Name = "LBHeader"
        Me.LBHeader.Size = New System.Drawing.Size(439, 32)
        Me.LBHeader.TabIndex = 0
        Me.LBHeader.Text = "Berikut adalah daftar rekanan karyawan yang tidak mempunyai email atau vendor:"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.LBBottom)
        Me.Panel2.Controls.Add(Me.btnCancel)
        Me.Panel2.Controls.Add(Me.btnOK)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(3, 277)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Padding = New System.Windows.Forms.Padding(3, 5, 3, 0)
        Me.Panel2.Size = New System.Drawing.Size(442, 125)
        Me.Panel2.TabIndex = 1
        '
        'LBBottom
        '
        Me.LBBottom.Dock = System.Windows.Forms.DockStyle.Top
        Me.LBBottom.Location = New System.Drawing.Point(3, 5)
        Me.LBBottom.Name = "LBBottom"
        Me.LBBottom.Size = New System.Drawing.Size(436, 85)
        Me.LBBottom.TabIndex = 2
        Me.LBBottom.Text = resources.GetString("LBBottom.Text")
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Location = New System.Drawing.Point(360, 95)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.Location = New System.Drawing.Point(279, 95)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 0
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.DGVRekananList)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(3, 40)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Padding = New System.Windows.Forms.Padding(3)
        Me.Panel3.Size = New System.Drawing.Size(442, 237)
        Me.Panel3.TabIndex = 2
        '
        'DGVRekananList
        '
        Me.DGVRekananList.AllowUserToAddRows = False
        Me.DGVRekananList.AllowUserToDeleteRows = False
        Me.DGVRekananList.BackgroundColor = System.Drawing.Color.White
        Me.DGVRekananList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DGVRekananList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVRekananList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColPvID, Me.ColRekanan, Me.ColDeskripsi})
        Me.DGVRekananList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGVRekananList.Location = New System.Drawing.Point(3, 3)
        Me.DGVRekananList.Name = "DGVRekananList"
        Me.DGVRekananList.ReadOnly = True
        Me.DGVRekananList.RowHeadersVisible = False
        Me.DGVRekananList.RowHeadersWidth = 25
        Me.DGVRekananList.Size = New System.Drawing.Size(436, 231)
        Me.DGVRekananList.TabIndex = 0
        '
        'ColPvID
        '
        Me.ColPvID.DataPropertyName = "pv_id"
        Me.ColPvID.HeaderText = "PV ID"
        Me.ColPvID.Name = "ColPvID"
        Me.ColPvID.ReadOnly = True
        '
        'ColRekanan
        '
        Me.ColRekanan.DataPropertyName = "rekanan_name"
        Me.ColRekanan.HeaderText = "Partner"
        Me.ColRekanan.Name = "ColRekanan"
        Me.ColRekanan.ReadOnly = True
        Me.ColRekanan.Width = 120
        '
        'ColDeskripsi
        '
        Me.ColDeskripsi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.ColDeskripsi.DataPropertyName = "deskripsi"
        Me.ColDeskripsi.HeaderText = "Deskripsi"
        Me.ColDeskripsi.Name = "ColDeskripsi"
        Me.ColDeskripsi.ReadOnly = True
        '
        'dlgTrnCirculationRekanan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(448, 405)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgTrnCirculationRekanan"
        Me.Padding = New System.Windows.Forms.Padding(3)
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Rekanan List"
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        CType(Me.DGVRekananList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents LBHeader As System.Windows.Forms.Label
    Friend WithEvents LBBottom As System.Windows.Forms.Label
    Friend WithEvents DGVRekananList As System.Windows.Forms.DataGridView
    Friend WithEvents ColPvID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColRekanan As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColDeskripsi As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
