<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class uiRptBankTransfer
    Inherits uiBase

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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(uiRptBankTransfer))
        Me.ftabMain_List = New System.Windows.Forms.TabPage
        Me.PnlDfMain = New System.Windows.Forms.Panel
        Me.DgvTrnBanktransfer = New System.Windows.Forms.DataGridView
        Me.PnlDfFooter = New System.Windows.Forms.Panel
        Me.PnlDfSearch = New System.Windows.Forms.Panel
        Me.obj_srch_eps = New System.Windows.Forms.TextBox
        Me.chk_srch_episode = New System.Windows.Forms.CheckBox
        Me.cbo_srch_program = New System.Windows.Forms.ComboBox
        Me.chk_srch_Program = New System.Windows.Forms.CheckBox
        Me.cbo_screateBySearch = New System.Windows.Forms.ComboBox
        Me.chk_srch_createby = New System.Windows.Forms.CheckBox
        Me.obj_srch_curr = New System.Windows.Forms.ComboBox
        Me.chk_curr = New System.Windows.Forms.CheckBox
        Me.obj_srch_jurnal = New System.Windows.Forms.TextBox
        Me.chk_jurnal = New System.Windows.Forms.CheckBox
        Me.dtTime2 = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.dtTime1 = New System.Windows.Forms.DateTimePicker
        Me.obj_srch_date = New System.Windows.Forms.CheckBox
        Me.ftabMain = New FlatTabControl.FlatTabControl
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.lblLoading = New System.Windows.Forms.Label
        Me.obj_ProgressBar_backGroundWorker = New System.Windows.Forms.ProgressBar
        CType(Me.tbl_MstSetting, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ftabMain_List.SuspendLayout()
        Me.PnlDfMain.SuspendLayout()
        CType(Me.DgvTrnBanktransfer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlDfSearch.SuspendLayout()
        Me.ftabMain.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ftabMain_List
        '
        Me.ftabMain_List.BackColor = System.Drawing.Color.White
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
        Me.PnlDfMain.Controls.Add(Me.DgvTrnBanktransfer)
        Me.PnlDfMain.Location = New System.Drawing.Point(6, 101)
        Me.PnlDfMain.Name = "PnlDfMain"
        Me.PnlDfMain.Size = New System.Drawing.Size(727, 339)
        Me.PnlDfMain.TabIndex = 1
        '
        'DgvTrnBanktransfer
        '
        Me.DgvTrnBanktransfer.AllowUserToAddRows = False
        Me.DgvTrnBanktransfer.AllowUserToDeleteRows = False
        Me.DgvTrnBanktransfer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvTrnBanktransfer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvTrnBanktransfer.Location = New System.Drawing.Point(0, 0)
        Me.DgvTrnBanktransfer.Name = "DgvTrnBanktransfer"
        Me.DgvTrnBanktransfer.ReadOnly = True
        Me.DgvTrnBanktransfer.Size = New System.Drawing.Size(727, 339)
        Me.DgvTrnBanktransfer.TabIndex = 0
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
        Me.PnlDfSearch.Controls.Add(Me.obj_srch_eps)
        Me.PnlDfSearch.Controls.Add(Me.chk_srch_episode)
        Me.PnlDfSearch.Controls.Add(Me.cbo_srch_program)
        Me.PnlDfSearch.Controls.Add(Me.chk_srch_Program)
        Me.PnlDfSearch.Controls.Add(Me.cbo_screateBySearch)
        Me.PnlDfSearch.Controls.Add(Me.chk_srch_createby)
        Me.PnlDfSearch.Controls.Add(Me.obj_srch_curr)
        Me.PnlDfSearch.Controls.Add(Me.chk_curr)
        Me.PnlDfSearch.Controls.Add(Me.obj_srch_jurnal)
        Me.PnlDfSearch.Controls.Add(Me.chk_jurnal)
        Me.PnlDfSearch.Controls.Add(Me.dtTime2)
        Me.PnlDfSearch.Controls.Add(Me.Label1)
        Me.PnlDfSearch.Controls.Add(Me.dtTime1)
        Me.PnlDfSearch.Controls.Add(Me.obj_srch_date)
        Me.PnlDfSearch.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlDfSearch.Location = New System.Drawing.Point(3, 3)
        Me.PnlDfSearch.Name = "PnlDfSearch"
        Me.PnlDfSearch.Size = New System.Drawing.Size(733, 92)
        Me.PnlDfSearch.TabIndex = 0
        '
        'obj_srch_eps
        '
        Me.obj_srch_eps.Enabled = False
        Me.obj_srch_eps.Location = New System.Drawing.Point(378, 67)
        Me.obj_srch_eps.Name = "obj_srch_eps"
        Me.obj_srch_eps.Size = New System.Drawing.Size(76, 20)
        Me.obj_srch_eps.TabIndex = 233
        '
        'chk_srch_episode
        '
        Me.chk_srch_episode.AutoSize = True
        Me.chk_srch_episode.Location = New System.Drawing.Point(308, 68)
        Me.chk_srch_episode.Name = "chk_srch_episode"
        Me.chk_srch_episode.Size = New System.Drawing.Size(44, 17)
        Me.chk_srch_episode.TabIndex = 232
        Me.chk_srch_episode.Text = "Eps"
        Me.chk_srch_episode.UseVisualStyleBackColor = True
        '
        'cbo_srch_program
        '
        Me.cbo_srch_program.Enabled = False
        Me.cbo_srch_program.FormattingEnabled = True
        Me.cbo_srch_program.Location = New System.Drawing.Point(378, 44)
        Me.cbo_srch_program.Name = "cbo_srch_program"
        Me.cbo_srch_program.Size = New System.Drawing.Size(206, 21)
        Me.cbo_srch_program.TabIndex = 231
        '
        'chk_srch_Program
        '
        Me.chk_srch_Program.AutoSize = True
        Me.chk_srch_Program.Location = New System.Drawing.Point(308, 46)
        Me.chk_srch_Program.Name = "chk_srch_Program"
        Me.chk_srch_Program.Size = New System.Drawing.Size(65, 17)
        Me.chk_srch_Program.TabIndex = 230
        Me.chk_srch_Program.Text = "Program"
        Me.chk_srch_Program.UseVisualStyleBackColor = True
        '
        'cbo_screateBySearch
        '
        Me.cbo_screateBySearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbo_screateBySearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbo_screateBySearch.BackColor = System.Drawing.Color.Honeydew
        Me.cbo_screateBySearch.Enabled = False
        Me.cbo_screateBySearch.FormattingEnabled = True
        Me.cbo_screateBySearch.Location = New System.Drawing.Point(77, 55)
        Me.cbo_screateBySearch.Name = "cbo_screateBySearch"
        Me.cbo_screateBySearch.Size = New System.Drawing.Size(176, 21)
        Me.cbo_screateBySearch.TabIndex = 229
        '
        'chk_srch_createby
        '
        Me.chk_srch_createby.AutoSize = True
        Me.chk_srch_createby.Location = New System.Drawing.Point(6, 57)
        Me.chk_srch_createby.Name = "chk_srch_createby"
        Me.chk_srch_createby.Size = New System.Drawing.Size(72, 17)
        Me.chk_srch_createby.TabIndex = 8
        Me.chk_srch_createby.Text = "Create By"
        Me.chk_srch_createby.UseVisualStyleBackColor = True
        '
        'obj_srch_curr
        '
        Me.obj_srch_curr.Enabled = False
        Me.obj_srch_curr.FormattingEnabled = True
        Me.obj_srch_curr.Location = New System.Drawing.Point(77, 30)
        Me.obj_srch_curr.Name = "obj_srch_curr"
        Me.obj_srch_curr.Size = New System.Drawing.Size(121, 21)
        Me.obj_srch_curr.TabIndex = 7
        '
        'chk_curr
        '
        Me.chk_curr.AutoSize = True
        Me.chk_curr.Location = New System.Drawing.Point(6, 34)
        Me.chk_curr.Name = "chk_curr"
        Me.chk_curr.Size = New System.Drawing.Size(45, 17)
        Me.chk_curr.TabIndex = 6
        Me.chk_curr.Text = "Curr"
        Me.chk_curr.UseVisualStyleBackColor = True
        '
        'obj_srch_jurnal
        '
        Me.obj_srch_jurnal.Enabled = False
        Me.obj_srch_jurnal.Location = New System.Drawing.Point(378, 4)
        Me.obj_srch_jurnal.Multiline = True
        Me.obj_srch_jurnal.Name = "obj_srch_jurnal"
        Me.obj_srch_jurnal.Size = New System.Drawing.Size(250, 36)
        Me.obj_srch_jurnal.TabIndex = 5
        '
        'chk_jurnal
        '
        Me.chk_jurnal.AutoSize = True
        Me.chk_jurnal.Location = New System.Drawing.Point(308, 8)
        Me.chk_jurnal.Name = "chk_jurnal"
        Me.chk_jurnal.Size = New System.Drawing.Size(40, 17)
        Me.chk_jurnal.TabIndex = 4
        Me.chk_jurnal.Text = "PV"
        Me.chk_jurnal.UseVisualStyleBackColor = True
        '
        'dtTime2
        '
        Me.dtTime2.Enabled = False
        Me.dtTime2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtTime2.Location = New System.Drawing.Point(203, 6)
        Me.dtTime2.Name = "dtTime2"
        Me.dtTime2.Size = New System.Drawing.Size(85, 20)
        Me.dtTime2.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(169, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(28, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Until"
        '
        'dtTime1
        '
        Me.dtTime1.Enabled = False
        Me.dtTime1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtTime1.Location = New System.Drawing.Point(77, 6)
        Me.dtTime1.Name = "dtTime1"
        Me.dtTime1.Size = New System.Drawing.Size(85, 20)
        Me.dtTime1.TabIndex = 1
        '
        'obj_srch_date
        '
        Me.obj_srch_date.AutoSize = True
        Me.obj_srch_date.Location = New System.Drawing.Point(6, 9)
        Me.obj_srch_date.Name = "obj_srch_date"
        Me.obj_srch_date.Size = New System.Drawing.Size(74, 17)
        Me.obj_srch_date.TabIndex = 0
        Me.obj_srch_date.Text = "Date Start"
        Me.obj_srch_date.UseVisualStyleBackColor = True
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
        'Timer1
        '
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Moccasin
        Me.Panel1.Controls.Add(Me.lblLoading)
        Me.Panel1.Controls.Add(Me.obj_ProgressBar_backGroundWorker)
        Me.Panel1.Location = New System.Drawing.Point(187, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(360, 82)
        Me.Panel1.TabIndex = 5
        Me.Panel1.UseWaitCursor = True
        Me.Panel1.Visible = False
        '
        'lblLoading
        '
        Me.lblLoading.AutoSize = True
        Me.lblLoading.Location = New System.Drawing.Point(53, 44)
        Me.lblLoading.Name = "lblLoading"
        Me.lblLoading.Size = New System.Drawing.Size(147, 13)
        Me.lblLoading.TabIndex = 57
        Me.lblLoading.Text = "Please Wait... Loading data..."
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
        'uiRptBankTransfer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.Controls.Add(Me.ftabMain)
        Me.DSN = resources.GetString("$this.DSN")
        Me.Name = "uiRptBankTransfer"
        Me.Controls.SetChildIndex(Me.ftabMain, 0)
        CType(Me.tbl_MstSetting, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ftabMain_List.ResumeLayout(False)
        Me.PnlDfMain.ResumeLayout(False)
        CType(Me.DgvTrnBanktransfer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlDfSearch.ResumeLayout(False)
        Me.PnlDfSearch.PerformLayout()
        Me.ftabMain.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ftabMain_List As System.Windows.Forms.TabPage
    Friend WithEvents PnlDfMain As System.Windows.Forms.Panel
    Friend WithEvents DgvTrnBanktransfer As System.Windows.Forms.DataGridView
    Friend WithEvents PnlDfFooter As System.Windows.Forms.Panel
    Friend WithEvents PnlDfSearch As System.Windows.Forms.Panel
    Friend WithEvents ftabMain As FlatTabControl.FlatTabControl
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents dtTime2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtTime1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents obj_srch_date As System.Windows.Forms.CheckBox
    Friend WithEvents obj_srch_jurnal As System.Windows.Forms.TextBox
    Friend WithEvents chk_jurnal As System.Windows.Forms.CheckBox
    Friend WithEvents obj_srch_curr As System.Windows.Forms.ComboBox
    Friend WithEvents chk_curr As System.Windows.Forms.CheckBox
    Friend WithEvents chk_srch_createby As System.Windows.Forms.CheckBox
    Friend WithEvents cbo_screateBySearch As System.Windows.Forms.ComboBox
    Friend WithEvents obj_srch_eps As System.Windows.Forms.TextBox
    Friend WithEvents chk_srch_episode As System.Windows.Forms.CheckBox
    Friend WithEvents cbo_srch_program As System.Windows.Forms.ComboBox
    Friend WithEvents chk_srch_Program As System.Windows.Forms.CheckBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblLoading As System.Windows.Forms.Label
    Friend WithEvents obj_ProgressBar_backGroundWorker As System.Windows.Forms.ProgressBar

End Class

