<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class uiTrnPVDocument
    Inherits ACT_FINANCE.uiBase

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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(uiTrnPVDocument))
        Me.ftabMain_List = New System.Windows.Forms.TabPage()
        Me.PnlDfMain = New System.Windows.Forms.Panel()
        Me.DgvTrnPVDocument = New System.Windows.Forms.DataGridView()
        Me.PnlDfFooter = New System.Windows.Forms.Panel()
        Me.PnlDfSearch = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtSearchDocId = New System.Windows.Forms.TextBox()
        Me.txtSearchJurnalID = New System.Windows.Forms.TextBox()
        Me.chkSearchJurnalID = New System.Windows.Forms.CheckBox()
        Me.cboSearchDocStatus = New System.Windows.Forms.ComboBox()
        Me.chkSearchDocId = New System.Windows.Forms.CheckBox()
        Me.chkSearchDocStatus = New System.Windows.Forms.CheckBox()
        Me.cbSearchType = New System.Windows.Forms.ComboBox()
        Me.chkType = New System.Windows.Forms.CheckBox()
        Me.cboSearchChannel = New System.Windows.Forms.ComboBox()
        Me.chkSearchChannel = New System.Windows.Forms.CheckBox()
        Me.ftabMain = New FlatTabControl.FlatTabControl()
        CType(Me.tbl_MstSetting, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ftabMain_List.SuspendLayout()
        Me.PnlDfMain.SuspendLayout()
        CType(Me.DgvTrnPVDocument, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlDfSearch.SuspendLayout()
        Me.ftabMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'ftabMain_List
        '
        Me.ftabMain_List.BackColor = System.Drawing.Color.Lavender
        Me.ftabMain_List.Controls.Add(Me.PnlDfMain)
        Me.ftabMain_List.Controls.Add(Me.PnlDfFooter)
        Me.ftabMain_List.Controls.Add(Me.PnlDfSearch)
        Me.ftabMain_List.Location = New System.Drawing.Point(4, 25)
        Me.ftabMain_List.Name = "ftabMain_List"
        Me.ftabMain_List.Padding = New System.Windows.Forms.Padding(3)
        Me.ftabMain_List.Size = New System.Drawing.Size(739, 488)
        Me.ftabMain_List.TabIndex = 0
        Me.ftabMain_List.Text = "List"
        '
        'PnlDfMain
        '
        Me.PnlDfMain.Controls.Add(Me.DgvTrnPVDocument)
        Me.PnlDfMain.Location = New System.Drawing.Point(20, 131)
        Me.PnlDfMain.Name = "PnlDfMain"
        Me.PnlDfMain.Size = New System.Drawing.Size(704, 296)
        Me.PnlDfMain.TabIndex = 1
        '
        'DgvTrnPVDocument
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvTrnPVDocument.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DgvTrnPVDocument.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgvTrnPVDocument.DefaultCellStyle = DataGridViewCellStyle2
        Me.DgvTrnPVDocument.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvTrnPVDocument.Location = New System.Drawing.Point(0, 0)
        Me.DgvTrnPVDocument.Name = "DgvTrnPVDocument"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvTrnPVDocument.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DgvTrnPVDocument.Size = New System.Drawing.Size(704, 296)
        Me.DgvTrnPVDocument.TabIndex = 0
        '
        'PnlDfFooter
        '
        Me.PnlDfFooter.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnlDfFooter.Location = New System.Drawing.Point(3, 446)
        Me.PnlDfFooter.Name = "PnlDfFooter"
        Me.PnlDfFooter.Size = New System.Drawing.Size(733, 39)
        Me.PnlDfFooter.TabIndex = 2
        '
        'PnlDfSearch
        '
        Me.PnlDfSearch.Controls.Add(Me.Label1)
        Me.PnlDfSearch.Controls.Add(Me.Label3)
        Me.PnlDfSearch.Controls.Add(Me.txtSearchDocId)
        Me.PnlDfSearch.Controls.Add(Me.txtSearchJurnalID)
        Me.PnlDfSearch.Controls.Add(Me.chkSearchJurnalID)
        Me.PnlDfSearch.Controls.Add(Me.cboSearchDocStatus)
        Me.PnlDfSearch.Controls.Add(Me.chkSearchDocId)
        Me.PnlDfSearch.Controls.Add(Me.chkSearchDocStatus)
        Me.PnlDfSearch.Controls.Add(Me.cbSearchType)
        Me.PnlDfSearch.Controls.Add(Me.chkType)
        Me.PnlDfSearch.Controls.Add(Me.cboSearchChannel)
        Me.PnlDfSearch.Controls.Add(Me.chkSearchChannel)
        Me.PnlDfSearch.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlDfSearch.Location = New System.Drawing.Point(3, 3)
        Me.PnlDfSearch.Name = "PnlDfSearch"
        Me.PnlDfSearch.Size = New System.Drawing.Size(733, 122)
        Me.PnlDfSearch.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(504, 92)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(214, 12)
        Me.Label1.TabIndex = 245
        Me.Label1.Text = "Use (;) to enter more than one references in textbox"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(113, 98)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(263, 12)
        Me.Label3.TabIndex = 245
        Me.Label3.Text = "Use semicolone (;) to enter more than one references in textbox"
        '
        'txtSearchDocId
        '
        Me.txtSearchDocId.BackColor = System.Drawing.Color.White
        Me.txtSearchDocId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSearchDocId.Location = New System.Drawing.Point(506, 38)
        Me.txtSearchDocId.Multiline = True
        Me.txtSearchDocId.Name = "txtSearchDocId"
        Me.txtSearchDocId.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtSearchDocId.Size = New System.Drawing.Size(214, 51)
        Me.txtSearchDocId.TabIndex = 233
        '
        'txtSearchJurnalID
        '
        Me.txtSearchJurnalID.BackColor = System.Drawing.Color.White
        Me.txtSearchJurnalID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSearchJurnalID.Location = New System.Drawing.Point(116, 38)
        Me.txtSearchJurnalID.Multiline = True
        Me.txtSearchJurnalID.Name = "txtSearchJurnalID"
        Me.txtSearchJurnalID.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtSearchJurnalID.Size = New System.Drawing.Size(260, 57)
        Me.txtSearchJurnalID.TabIndex = 233
        '
        'chkSearchJurnalID
        '
        Me.chkSearchJurnalID.AutoSize = True
        Me.chkSearchJurnalID.Location = New System.Drawing.Point(25, 41)
        Me.chkSearchJurnalID.Name = "chkSearchJurnalID"
        Me.chkSearchJurnalID.Size = New System.Drawing.Size(79, 17)
        Me.chkSearchJurnalID.TabIndex = 232
        Me.chkSearchJurnalID.Text = "Jurnal ID(s)"
        Me.chkSearchJurnalID.UseVisualStyleBackColor = True
        '
        'cboSearchDocStatus
        '
        Me.cboSearchDocStatus.BackColor = System.Drawing.Color.Honeydew
        Me.cboSearchDocStatus.Enabled = False
        Me.cboSearchDocStatus.FormattingEnabled = True
        Me.cboSearchDocStatus.Items.AddRange(New Object() {"POSTED", "UNPOSTED", "VOID"})
        Me.cboSearchDocStatus.Location = New System.Drawing.Point(506, 11)
        Me.cboSearchDocStatus.Name = "cboSearchDocStatus"
        Me.cboSearchDocStatus.Size = New System.Drawing.Size(134, 21)
        Me.cboSearchDocStatus.TabIndex = 231
        '
        'chkSearchDocId
        '
        Me.chkSearchDocId.AutoSize = True
        Me.chkSearchDocId.Location = New System.Drawing.Point(392, 34)
        Me.chkSearchDocId.Name = "chkSearchDocId"
        Me.chkSearchDocId.Size = New System.Drawing.Size(89, 17)
        Me.chkSearchDocId.TabIndex = 230
        Me.chkSearchDocId.Text = "Document ID"
        Me.chkSearchDocId.UseVisualStyleBackColor = True
        '
        'chkSearchDocStatus
        '
        Me.chkSearchDocStatus.AutoSize = True
        Me.chkSearchDocStatus.Location = New System.Drawing.Point(392, 11)
        Me.chkSearchDocStatus.Name = "chkSearchDocStatus"
        Me.chkSearchDocStatus.Size = New System.Drawing.Size(108, 17)
        Me.chkSearchDocStatus.TabIndex = 230
        Me.chkSearchDocStatus.Text = "Document Status"
        Me.chkSearchDocStatus.UseVisualStyleBackColor = True
        '
        'cbSearchType
        '
        Me.cbSearchType.BackColor = System.Drawing.Color.Honeydew
        Me.cbSearchType.Enabled = False
        Me.cbSearchType.FormattingEnabled = True
        Me.cbSearchType.Items.AddRange(New Object() {"PV", "OR"})
        Me.cbSearchType.Location = New System.Drawing.Point(305, 9)
        Me.cbSearchType.Name = "cbSearchType"
        Me.cbSearchType.Size = New System.Drawing.Size(71, 21)
        Me.cbSearchType.TabIndex = 231
        Me.cbSearchType.Text = "-- PILIH --"
        '
        'chkType
        '
        Me.chkType.AutoSize = True
        Me.chkType.Location = New System.Drawing.Point(249, 11)
        Me.chkType.Name = "chkType"
        Me.chkType.Size = New System.Drawing.Size(50, 17)
        Me.chkType.TabIndex = 230
        Me.chkType.Text = "Type"
        Me.chkType.UseVisualStyleBackColor = True
        '
        'cboSearchChannel
        '
        Me.cboSearchChannel.BackColor = System.Drawing.Color.Honeydew
        Me.cboSearchChannel.FormattingEnabled = True
        Me.cboSearchChannel.Location = New System.Drawing.Point(115, 9)
        Me.cboSearchChannel.Name = "cboSearchChannel"
        Me.cboSearchChannel.Size = New System.Drawing.Size(91, 21)
        Me.cboSearchChannel.TabIndex = 231
        '
        'chkSearchChannel
        '
        Me.chkSearchChannel.AutoSize = True
        Me.chkSearchChannel.Location = New System.Drawing.Point(25, 11)
        Me.chkSearchChannel.Name = "chkSearchChannel"
        Me.chkSearchChannel.Size = New System.Drawing.Size(65, 17)
        Me.chkSearchChannel.TabIndex = 230
        Me.chkSearchChannel.Text = "Company"
        Me.chkSearchChannel.UseVisualStyleBackColor = True
        '
        'ftabMain
        '
        Me.ftabMain.Controls.Add(Me.ftabMain_List)
        Me.ftabMain.Location = New System.Drawing.Point(3, 28)
        Me.ftabMain.myBackColor = System.Drawing.Color.White
        Me.ftabMain.Name = "ftabMain"
        Me.ftabMain.SelectedIndex = 0
        Me.ftabMain.Size = New System.Drawing.Size(747, 517)
        Me.ftabMain.TabIndex = 1
        '
        'uiTrnPVDocument
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.Controls.Add(Me.ftabMain)
        Me.Name = "uiTrnPVDocument"
        Me.Controls.SetChildIndex(Me.ftabMain, 0)
        CType(Me.tbl_MstSetting, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ftabMain_List.ResumeLayout(False)
        Me.PnlDfMain.ResumeLayout(False)
        CType(Me.DgvTrnPVDocument, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlDfSearch.ResumeLayout(False)
        Me.PnlDfSearch.PerformLayout()
        Me.ftabMain.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ftabMain_List As System.Windows.Forms.TabPage
    Friend WithEvents PnlDfMain As System.Windows.Forms.Panel
    Friend WithEvents DgvTrnPVDocument As System.Windows.Forms.DataGridView
    Friend WithEvents PnlDfFooter As System.Windows.Forms.Panel
    Friend WithEvents PnlDfSearch As System.Windows.Forms.Panel
    Friend WithEvents ftabMain As FlatTabControl.FlatTabControl
    Friend WithEvents txtSearchJurnalID As System.Windows.Forms.TextBox
    Friend WithEvents chkSearchJurnalID As System.Windows.Forms.CheckBox
    Friend WithEvents cboSearchChannel As System.Windows.Forms.ComboBox
    Friend WithEvents chkSearchChannel As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboSearchDocStatus As System.Windows.Forms.ComboBox
    Friend WithEvents chkSearchDocStatus As System.Windows.Forms.CheckBox
    Friend WithEvents chkSearchDocId As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtSearchDocId As System.Windows.Forms.TextBox
    Friend WithEvents cbSearchType As System.Windows.Forms.ComboBox
    Friend WithEvents chkType As System.Windows.Forms.CheckBox

End Class

