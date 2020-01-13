<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class uiMstListCaAccountJurnalPV
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(uiMstListCaAccountJurnalPV))
        Me.ftabMain_List = New System.Windows.Forms.TabPage()
        Me.PnlDfMain = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblLoading = New System.Windows.Forms.Label()
        Me.obj_ProgressBar_backGroundWorker = New System.Windows.Forms.ProgressBar()
        Me.DgvListCaAccount_JournalPv = New System.Windows.Forms.DataGridView()
        Me.PnlDfFooter = New System.Windows.Forms.Panel()
        Me.PnlDfSearch = New System.Windows.Forms.Panel()
        Me.chkSearchPeriode = New System.Windows.Forms.CheckBox()
        Me.cbo_periodeSearch = New System.Windows.Forms.ComboBox()
        Me.obj_Budget_id = New System.Windows.Forms.ComboBox()
        Me.obj_Acc_ca_id = New System.Windows.Forms.ComboBox()
        Me.btn_Rekanan = New System.Windows.Forms.Button()
        Me.txtSearchRekananID = New System.Windows.Forms.TextBox()
        Me.chkSearchRekanan = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.obj_srcRefID = New System.Windows.Forms.TextBox()
        Me.txtSearchJurnalID = New System.Windows.Forms.TextBox()
        Me.chkSrcRefid = New System.Windows.Forms.CheckBox()
        Me.chkSearchJurnalID = New System.Windows.Forms.CheckBox()
        Me.cboSearchChannel = New System.Windows.Forms.ComboBox()
        Me.chkBudgetId = New System.Windows.Forms.CheckBox()
        Me.chkSearchAccCa = New System.Windows.Forms.CheckBox()
        Me.chkSearchChannel = New System.Windows.Forms.CheckBox()
        Me.ftabMain = New FlatTabControl.FlatTabControl()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        CType(Me.tbl_MstSetting, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ftabMain_List.SuspendLayout()
        Me.PnlDfMain.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.DgvListCaAccount_JournalPv, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.PnlDfMain.Controls.Add(Me.Panel1)
        Me.PnlDfMain.Controls.Add(Me.DgvListCaAccount_JournalPv)
        Me.PnlDfMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnlDfMain.Location = New System.Drawing.Point(3, 159)
        Me.PnlDfMain.Name = "PnlDfMain"
        Me.PnlDfMain.Size = New System.Drawing.Size(733, 287)
        Me.PnlDfMain.TabIndex = 1
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Moccasin
        Me.Panel1.Controls.Add(Me.lblLoading)
        Me.Panel1.Controls.Add(Me.obj_ProgressBar_backGroundWorker)
        Me.Panel1.Location = New System.Drawing.Point(175, 6)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(360, 82)
        Me.Panel1.TabIndex = 4
        Me.Panel1.UseWaitCursor = True
        Me.Panel1.Visible = False
        '
        'lblLoading
        '
        Me.lblLoading.AutoSize = True
        Me.lblLoading.Location = New System.Drawing.Point(53, 44)
        Me.lblLoading.Name = "lblLoading"
        Me.lblLoading.Size = New System.Drawing.Size(73, 13)
        Me.lblLoading.TabIndex = 57
        Me.lblLoading.Text = "Please Wait..."
        Me.lblLoading.UseWaitCursor = True
        '
        'obj_ProgressBar_backGroundWorker
        '
        Me.obj_ProgressBar_backGroundWorker.ForeColor = System.Drawing.Color.Magenta
        Me.obj_ProgressBar_backGroundWorker.Location = New System.Drawing.Point(57, 32)
        Me.obj_ProgressBar_backGroundWorker.Name = "obj_ProgressBar_backGroundWorker"
        Me.obj_ProgressBar_backGroundWorker.RightToLeftLayout = True
        Me.obj_ProgressBar_backGroundWorker.Size = New System.Drawing.Size(252, 12)
        Me.obj_ProgressBar_backGroundWorker.Step = 5
        Me.obj_ProgressBar_backGroundWorker.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.obj_ProgressBar_backGroundWorker.TabIndex = 54
        Me.obj_ProgressBar_backGroundWorker.UseWaitCursor = True
        '
        'DgvListCaAccount_JournalPv
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvListCaAccount_JournalPv.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DgvListCaAccount_JournalPv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgvListCaAccount_JournalPv.DefaultCellStyle = DataGridViewCellStyle2
        Me.DgvListCaAccount_JournalPv.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvListCaAccount_JournalPv.Location = New System.Drawing.Point(0, 0)
        Me.DgvListCaAccount_JournalPv.Name = "DgvListCaAccount_JournalPv"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvListCaAccount_JournalPv.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DgvListCaAccount_JournalPv.Size = New System.Drawing.Size(733, 287)
        Me.DgvListCaAccount_JournalPv.TabIndex = 0
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
        Me.PnlDfSearch.Controls.Add(Me.chkSearchPeriode)
        Me.PnlDfSearch.Controls.Add(Me.cbo_periodeSearch)
        Me.PnlDfSearch.Controls.Add(Me.obj_Budget_id)
        Me.PnlDfSearch.Controls.Add(Me.obj_Acc_ca_id)
        Me.PnlDfSearch.Controls.Add(Me.btn_Rekanan)
        Me.PnlDfSearch.Controls.Add(Me.txtSearchRekananID)
        Me.PnlDfSearch.Controls.Add(Me.chkSearchRekanan)
        Me.PnlDfSearch.Controls.Add(Me.Label1)
        Me.PnlDfSearch.Controls.Add(Me.Label3)
        Me.PnlDfSearch.Controls.Add(Me.obj_srcRefID)
        Me.PnlDfSearch.Controls.Add(Me.txtSearchJurnalID)
        Me.PnlDfSearch.Controls.Add(Me.chkSrcRefid)
        Me.PnlDfSearch.Controls.Add(Me.chkSearchJurnalID)
        Me.PnlDfSearch.Controls.Add(Me.cboSearchChannel)
        Me.PnlDfSearch.Controls.Add(Me.chkBudgetId)
        Me.PnlDfSearch.Controls.Add(Me.chkSearchAccCa)
        Me.PnlDfSearch.Controls.Add(Me.chkSearchChannel)
        Me.PnlDfSearch.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlDfSearch.Location = New System.Drawing.Point(3, 3)
        Me.PnlDfSearch.Name = "PnlDfSearch"
        Me.PnlDfSearch.Size = New System.Drawing.Size(733, 156)
        Me.PnlDfSearch.TabIndex = 0
        '
        'chkSearchPeriode
        '
        Me.chkSearchPeriode.AutoSize = True
        Me.chkSearchPeriode.Location = New System.Drawing.Point(387, 60)
        Me.chkSearchPeriode.Name = "chkSearchPeriode"
        Me.chkSearchPeriode.Size = New System.Drawing.Size(56, 17)
        Me.chkSearchPeriode.TabIndex = 249
        Me.chkSearchPeriode.Text = "Period"
        Me.chkSearchPeriode.UseVisualStyleBackColor = True
        '
        'cbo_periodeSearch
        '
        Me.cbo_periodeSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbo_periodeSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbo_periodeSearch.BackColor = System.Drawing.Color.Honeydew
        Me.cbo_periodeSearch.FormattingEnabled = True
        Me.cbo_periodeSearch.Location = New System.Drawing.Point(478, 58)
        Me.cbo_periodeSearch.Name = "cbo_periodeSearch"
        Me.cbo_periodeSearch.Size = New System.Drawing.Size(176, 21)
        Me.cbo_periodeSearch.TabIndex = 248
        '
        'obj_Budget_id
        '
        Me.obj_Budget_id.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.obj_Budget_id.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.obj_Budget_id.BackColor = System.Drawing.Color.Honeydew
        Me.obj_Budget_id.FormattingEnabled = True
        Me.obj_Budget_id.Location = New System.Drawing.Point(477, 32)
        Me.obj_Budget_id.Name = "obj_Budget_id"
        Me.obj_Budget_id.Size = New System.Drawing.Size(242, 21)
        Me.obj_Budget_id.TabIndex = 247
        '
        'obj_Acc_ca_id
        '
        Me.obj_Acc_ca_id.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.obj_Acc_ca_id.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.obj_Acc_ca_id.BackColor = System.Drawing.Color.Honeydew
        Me.obj_Acc_ca_id.FormattingEnabled = True
        Me.obj_Acc_ca_id.Location = New System.Drawing.Point(109, 36)
        Me.obj_Acc_ca_id.Name = "obj_Acc_ca_id"
        Me.obj_Acc_ca_id.Size = New System.Drawing.Size(261, 21)
        Me.obj_Acc_ca_id.TabIndex = 246
        '
        'btn_Rekanan
        '
        Me.btn_Rekanan.Location = New System.Drawing.Point(594, 8)
        Me.btn_Rekanan.Name = "btn_Rekanan"
        Me.btn_Rekanan.Size = New System.Drawing.Size(37, 20)
        Me.btn_Rekanan.TabIndex = 245
        Me.btn_Rekanan.Text = "..."
        Me.btn_Rekanan.UseVisualStyleBackColor = True
        '
        'txtSearchRekananID
        '
        Me.txtSearchRekananID.BackColor = System.Drawing.Color.White
        Me.txtSearchRekananID.Location = New System.Drawing.Point(477, 7)
        Me.txtSearchRekananID.Name = "txtSearchRekananID"
        Me.txtSearchRekananID.Size = New System.Drawing.Size(111, 20)
        Me.txtSearchRekananID.TabIndex = 244
        '
        'chkSearchRekanan
        '
        Me.chkSearchRekanan.AutoSize = True
        Me.chkSearchRekanan.Location = New System.Drawing.Point(387, 9)
        Me.chkSearchRekanan.Name = "chkSearchRekanan"
        Me.chkSearchRekanan.Size = New System.Drawing.Size(84, 17)
        Me.chkSearchRekanan.TabIndex = 243
        Me.chkSearchRekanan.Text = "Rekanan ID"
        Me.chkSearchRekanan.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(467, 138)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(263, 12)
        Me.Label1.TabIndex = 241
        Me.Label1.Text = "Use semicolone (;) to enter more than one references in textbox"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(107, 131)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(263, 12)
        Me.Label3.TabIndex = 241
        Me.Label3.Text = "Use semicolone (;) to enter more than one references in textbox"
        '
        'obj_srcRefID
        '
        Me.obj_srcRefID.BackColor = System.Drawing.Color.White
        Me.obj_srcRefID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.obj_srcRefID.Location = New System.Drawing.Point(478, 84)
        Me.obj_srcRefID.Multiline = True
        Me.obj_srcRefID.Name = "obj_srcRefID"
        Me.obj_srcRefID.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.obj_srcRefID.Size = New System.Drawing.Size(241, 48)
        Me.obj_srcRefID.TabIndex = 233
        '
        'txtSearchJurnalID
        '
        Me.txtSearchJurnalID.BackColor = System.Drawing.Color.White
        Me.txtSearchJurnalID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSearchJurnalID.Location = New System.Drawing.Point(109, 63)
        Me.txtSearchJurnalID.Multiline = True
        Me.txtSearchJurnalID.Name = "txtSearchJurnalID"
        Me.txtSearchJurnalID.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtSearchJurnalID.Size = New System.Drawing.Size(261, 65)
        Me.txtSearchJurnalID.TabIndex = 233
        '
        'chkSrcRefid
        '
        Me.chkSrcRefid.AutoSize = True
        Me.chkSrcRefid.Location = New System.Drawing.Point(387, 87)
        Me.chkSrcRefid.Name = "chkSrcRefid"
        Me.chkSrcRefid.Size = New System.Drawing.Size(71, 17)
        Me.chkSrcRefid.TabIndex = 232
        Me.chkSrcRefid.Text = "Ref. ID(s)"
        Me.chkSrcRefid.UseVisualStyleBackColor = True
        '
        'chkSearchJurnalID
        '
        Me.chkSearchJurnalID.AutoSize = True
        Me.chkSearchJurnalID.Location = New System.Drawing.Point(24, 62)
        Me.chkSearchJurnalID.Name = "chkSearchJurnalID"
        Me.chkSearchJurnalID.Size = New System.Drawing.Size(79, 17)
        Me.chkSearchJurnalID.TabIndex = 232
        Me.chkSearchJurnalID.Text = "Jurnal ID(s)"
        Me.chkSearchJurnalID.UseVisualStyleBackColor = True
        '
        'cboSearchChannel
        '
        Me.cboSearchChannel.BackColor = System.Drawing.Color.Honeydew
        Me.cboSearchChannel.FormattingEnabled = True
        Me.cboSearchChannel.Location = New System.Drawing.Point(109, 7)
        Me.cboSearchChannel.Name = "cboSearchChannel"
        Me.cboSearchChannel.Size = New System.Drawing.Size(141, 21)
        Me.cboSearchChannel.TabIndex = 231
        '
        'chkBudgetId
        '
        Me.chkBudgetId.AutoSize = True
        Me.chkBudgetId.Location = New System.Drawing.Point(387, 34)
        Me.chkBudgetId.Name = "chkBudgetId"
        Me.chkBudgetId.Size = New System.Drawing.Size(60, 17)
        Me.chkBudgetId.TabIndex = 230
        Me.chkBudgetId.Text = "Budget"
        Me.chkBudgetId.UseVisualStyleBackColor = True
        '
        'chkSearchAccCa
        '
        Me.chkSearchAccCa.AutoSize = True
        Me.chkSearchAccCa.Location = New System.Drawing.Point(24, 36)
        Me.chkSearchAccCa.Name = "chkSearchAccCa"
        Me.chkSearchAccCa.Size = New System.Drawing.Size(61, 17)
        Me.chkSearchAccCa.TabIndex = 230
        Me.chkSearchAccCa.Text = "Acc Ca"
        Me.chkSearchAccCa.UseVisualStyleBackColor = True
        '
        'chkSearchChannel
        '
        Me.chkSearchChannel.AutoSize = True
        Me.chkSearchChannel.Location = New System.Drawing.Point(24, 9)
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
        'BackgroundWorker1
        '
        '
        'uiMstListCaAccountJurnalPV
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.Controls.Add(Me.ftabMain)
        Me.Name = "uiMstListCaAccountJurnalPV"
        Me.Controls.SetChildIndex(Me.ftabMain, 0)
        CType(Me.tbl_MstSetting, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ftabMain_List.ResumeLayout(False)
        Me.PnlDfMain.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.DgvListCaAccount_JournalPv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlDfSearch.ResumeLayout(False)
        Me.PnlDfSearch.PerformLayout()
        Me.ftabMain.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ftabMain_List As System.Windows.Forms.TabPage
    Friend WithEvents PnlDfMain As System.Windows.Forms.Panel
    Friend WithEvents DgvListCaAccount_JournalPv As System.Windows.Forms.DataGridView
    Friend WithEvents PnlDfFooter As System.Windows.Forms.Panel
    Friend WithEvents PnlDfSearch As System.Windows.Forms.Panel
    Friend WithEvents ftabMain As FlatTabControl.FlatTabControl
    Friend WithEvents btn_Rekanan As System.Windows.Forms.Button
    Friend WithEvents txtSearchRekananID As System.Windows.Forms.TextBox
    Friend WithEvents chkSearchRekanan As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents obj_srcRefID As System.Windows.Forms.TextBox
    Friend WithEvents txtSearchJurnalID As System.Windows.Forms.TextBox
    Friend WithEvents chkSrcRefid As System.Windows.Forms.CheckBox
    Friend WithEvents chkSearchJurnalID As System.Windows.Forms.CheckBox
    Friend WithEvents cboSearchChannel As System.Windows.Forms.ComboBox
    Friend WithEvents chkSearchChannel As System.Windows.Forms.CheckBox
    Friend WithEvents obj_Acc_ca_id As System.Windows.Forms.ComboBox
    Friend WithEvents obj_Budget_id As System.Windows.Forms.ComboBox
    Friend WithEvents chkBudgetId As System.Windows.Forms.CheckBox
    Friend WithEvents chkSearchAccCa As System.Windows.Forms.CheckBox
    Friend WithEvents cbo_periodeSearch As System.Windows.Forms.ComboBox
    Friend WithEvents chkSearchPeriode As System.Windows.Forms.CheckBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblLoading As System.Windows.Forms.Label
    Friend WithEvents obj_ProgressBar_backGroundWorker As System.Windows.Forms.ProgressBar
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker

End Class

