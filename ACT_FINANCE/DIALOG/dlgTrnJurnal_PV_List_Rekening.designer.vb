<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgTrnJurnal_PV_List_Rekening
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
        Me.obj_search_type = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.obj_search_text = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.obj_type_search = New System.Windows.Forms.ComboBox()
        Me.ftabData = New FlatTabControl.FlatTabControl()
        Me.ftabData_Rekening = New System.Windows.Forms.TabPage()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.dgvArtisName = New System.Windows.Forms.DataGridView()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DgvRekening = New System.Windows.Forms.DataGridView()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.lbl_rekeninglist = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btn_cancel = New System.Windows.Forms.Button()
        Me.btn_Ok = New System.Windows.Forms.Button()
        Me.obj_artisname_srch = New System.Windows.Forms.TextBox()
        Me.Panel1.SuspendLayout()
        Me.ftabData.SuspendLayout()
        Me.ftabData_Rekening.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.dgvArtisName, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'obj_search_type
        '
        Me.obj_search_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.obj_search_type.FormattingEnabled = True
        Me.obj_search_type.Location = New System.Drawing.Point(55, 5)
        Me.obj_search_type.Name = "obj_search_type"
        Me.obj_search_type.Size = New System.Drawing.Size(63, 21)
        Me.obj_search_type.TabIndex = 18
        Me.obj_search_type.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 13)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Search"
        Me.Label1.Visible = False
        '
        'obj_search_text
        '
        Me.obj_search_text.Location = New System.Drawing.Point(124, 5)
        Me.obj_search_text.Name = "obj_search_text"
        Me.obj_search_text.Size = New System.Drawing.Size(145, 20)
        Me.obj_search_text.TabIndex = 16
        Me.obj_search_text.Visible = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.obj_type_search)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.obj_search_type)
        Me.Panel1.Controls.Add(Me.obj_search_text)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(817, 32)
        Me.Panel1.TabIndex = 19
        Me.Panel1.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(294, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(31, 13)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "Type"
        Me.Label2.Visible = False
        '
        'obj_type_search
        '
        Me.obj_type_search.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.obj_type_search.FormattingEnabled = True
        Me.obj_type_search.Location = New System.Drawing.Point(331, 5)
        Me.obj_type_search.Name = "obj_type_search"
        Me.obj_type_search.Size = New System.Drawing.Size(119, 21)
        Me.obj_type_search.TabIndex = 20
        Me.obj_type_search.Visible = False
        '
        'ftabData
        '
        Me.ftabData.Controls.Add(Me.ftabData_Rekening)
        Me.ftabData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ftabData.Location = New System.Drawing.Point(0, 32)
        Me.ftabData.myBackColor = System.Drawing.Color.WhiteSmoke
        Me.ftabData.Name = "ftabData"
        Me.ftabData.SelectedIndex = 0
        Me.ftabData.Size = New System.Drawing.Size(817, 333)
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
        Me.ftabData_Rekening.Size = New System.Drawing.Size(809, 304)
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.dgvArtisName)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel2)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.DgvRekening)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Panel4)
        Me.SplitContainer1.Size = New System.Drawing.Size(803, 270)
        Me.SplitContainer1.SplitterDistance = 193
        Me.SplitContainer1.TabIndex = 7
        '
        'dgvArtisName
        '
        Me.dgvArtisName.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvArtisName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvArtisName.Location = New System.Drawing.Point(0, 27)
        Me.dgvArtisName.Name = "dgvArtisName"
        Me.dgvArtisName.Size = New System.Drawing.Size(193, 243)
        Me.dgvArtisName.TabIndex = 6
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Lavender
        Me.Panel2.Controls.Add(Me.obj_artisname_srch)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(193, 27)
        Me.Panel2.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 7)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Artis Name"
        '
        'DgvRekening
        '
        Me.DgvRekening.AllowUserToAddRows = False
        Me.DgvRekening.AllowUserToDeleteRows = False
        Me.DgvRekening.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvRekening.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvRekening.Location = New System.Drawing.Point(0, 27)
        Me.DgvRekening.Name = "DgvRekening"
        Me.DgvRekening.ReadOnly = True
        Me.DgvRekening.Size = New System.Drawing.Size(606, 243)
        Me.DgvRekening.TabIndex = 0
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.lbl_rekeninglist)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(606, 27)
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
        Me.Panel3.Location = New System.Drawing.Point(3, 273)
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
        'obj_artisname_srch
        '
        Me.obj_artisname_srch.Location = New System.Drawing.Point(64, 3)
        Me.obj_artisname_srch.Name = "obj_artisname_srch"
        Me.obj_artisname_srch.Size = New System.Drawing.Size(126, 20)
        Me.obj_artisname_srch.TabIndex = 1
        '
        'dlgTrnJurnal_PV_List_Rekening
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(817, 365)
        Me.Controls.Add(Me.ftabData)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgTrnJurnal_PV_List_Rekening"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "List Rekening"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ftabData.ResumeLayout(False)
        Me.ftabData_Rekening.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.dgvArtisName, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents obj_search_type As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents obj_search_text As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ftabData As FlatTabControl.FlatTabControl
    Friend WithEvents ftabData_Rekening As System.Windows.Forms.TabPage
    Friend WithEvents DgvRekening As System.Windows.Forms.DataGridView
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents btn_cancel As System.Windows.Forms.Button
    Friend WithEvents btn_Ok As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents obj_type_search As System.Windows.Forms.ComboBox
    Friend WithEvents dgvArtisName As System.Windows.Forms.DataGridView
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents lbl_rekeninglist As System.Windows.Forms.Label
    Friend WithEvents obj_artisname_srch As System.Windows.Forms.TextBox

End Class
