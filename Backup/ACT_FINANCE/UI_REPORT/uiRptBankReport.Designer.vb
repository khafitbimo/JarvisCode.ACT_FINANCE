<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class uiRptBankReport
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(uiRptBankReport))
        Me.ftabMain = New FlatTabControl.FlatTabControl
        Me.ftabMain_List = New System.Windows.Forms.TabPage
        Me.pnlLoading = New System.Windows.Forms.Panel
        Me.lblProgress = New System.Windows.Forms.Label
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.PnlDfFooter = New System.Windows.Forms.Panel
        Me.PnlDfSearch = New System.Windows.Forms.Panel
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.cboBankName = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.dtEndDate = New System.Windows.Forms.DateTimePicker
        Me.dtStartDate = New System.Windows.Forms.DateTimePicker
        Me.ftabMain_Data = New System.Windows.Forms.TabPage
        Me.PnlDataFooter = New System.Windows.Forms.Panel
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.btn_CheckAllAppDir = New System.Windows.Forms.ToolStripMenuItem
        Me.btn_UnCheckAllAppDir = New System.Windows.Forms.ToolStripMenuItem
        Me.btn_Refresh = New System.Windows.Forms.ToolStripMenuItem
        Me.lblLoading = New System.Windows.Forms.Label
        Me.obj_ProgressBar_backGroundWorker = New System.Windows.Forms.ProgressBar
        CType(Me.tbl_MstSetting, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ftabMain.SuspendLayout()
        Me.ftabMain_List.SuspendLayout()
        Me.pnlLoading.SuspendLayout()
        Me.PnlDfSearch.SuspendLayout()
        Me.ftabMain_Data.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ftabMain
        '
        Me.ftabMain.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ftabMain.Controls.Add(Me.ftabMain_List)
        Me.ftabMain.Controls.Add(Me.ftabMain_Data)
        Me.ftabMain.Location = New System.Drawing.Point(3, 28)
        Me.ftabMain.myBackColor = System.Drawing.Color.White
        Me.ftabMain.Name = "ftabMain"
        Me.ftabMain.SelectedIndex = 0
        Me.ftabMain.Size = New System.Drawing.Size(747, 517)
        Me.ftabMain.TabIndex = 1
        '
        'ftabMain_List
        '
        Me.ftabMain_List.BackColor = System.Drawing.Color.LavenderBlush
        Me.ftabMain_List.Controls.Add(Me.pnlLoading)
        Me.ftabMain_List.Controls.Add(Me.PnlDfFooter)
        Me.ftabMain_List.Controls.Add(Me.PnlDfSearch)
        Me.ftabMain_List.Location = New System.Drawing.Point(4, 25)
        Me.ftabMain_List.Name = "ftabMain_List"
        Me.ftabMain_List.Padding = New System.Windows.Forms.Padding(3)
        Me.ftabMain_List.Size = New System.Drawing.Size(739, 488)
        Me.ftabMain_List.TabIndex = 0
        Me.ftabMain_List.Text = "List"
        '
        'pnlLoading
        '
        Me.pnlLoading.BackColor = System.Drawing.Color.Moccasin
        Me.pnlLoading.Controls.Add(Me.lblProgress)
        Me.pnlLoading.Controls.Add(Me.ProgressBar1)
        Me.pnlLoading.Location = New System.Drawing.Point(222, 215)
        Me.pnlLoading.Name = "pnlLoading"
        Me.pnlLoading.Size = New System.Drawing.Size(294, 58)
        Me.pnlLoading.TabIndex = 47
        Me.pnlLoading.UseWaitCursor = True
        Me.pnlLoading.Visible = False
        '
        'lblProgress
        '
        Me.lblProgress.AutoSize = True
        Me.lblProgress.Location = New System.Drawing.Point(14, 11)
        Me.lblProgress.Name = "lblProgress"
        Me.lblProgress.Size = New System.Drawing.Size(108, 13)
        Me.lblProgress.TabIndex = 57
        Me.lblProgress.Text = "Saving 0 of 0 records"
        Me.lblProgress.UseWaitCursor = True
        '
        'ProgressBar1
        '
        Me.ProgressBar1.ForeColor = System.Drawing.Color.Magenta
        Me.ProgressBar1.Location = New System.Drawing.Point(17, 30)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.RightToLeftLayout = True
        Me.ProgressBar1.Size = New System.Drawing.Size(252, 12)
        Me.ProgressBar1.Step = 5
        Me.ProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.ProgressBar1.TabIndex = 54
        Me.ProgressBar1.UseWaitCursor = True
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
        Me.PnlDfSearch.BackColor = System.Drawing.Color.LavenderBlush
        Me.PnlDfSearch.Controls.Add(Me.Button1)
        Me.PnlDfSearch.Controls.Add(Me.Label4)
        Me.PnlDfSearch.Controls.Add(Me.cboBankName)
        Me.PnlDfSearch.Controls.Add(Me.Label3)
        Me.PnlDfSearch.Controls.Add(Me.Label2)
        Me.PnlDfSearch.Controls.Add(Me.dtEndDate)
        Me.PnlDfSearch.Controls.Add(Me.dtStartDate)
        Me.PnlDfSearch.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlDfSearch.Location = New System.Drawing.Point(3, 3)
        Me.PnlDfSearch.Name = "PnlDfSearch"
        Me.PnlDfSearch.Size = New System.Drawing.Size(733, 122)
        Me.PnlDfSearch.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(19, 85)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 108
        Me.Button1.Text = "Export"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(16, 25)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 13)
        Me.Label4.TabIndex = 107
        Me.Label4.Text = "Bank Name"
        '
        'cboBankName
        '
        Me.cboBankName.FormattingEnabled = True
        Me.cboBankName.Location = New System.Drawing.Point(95, 22)
        Me.cboBankName.Name = "cboBankName"
        Me.cboBankName.Size = New System.Drawing.Size(277, 21)
        Me.cboBankName.TabIndex = 106
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(217, 52)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 13)
        Me.Label3.TabIndex = 105
        Me.Label3.Text = "Date End"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 13)
        Me.Label2.TabIndex = 104
        Me.Label2.Text = "Date Start"
        '
        'dtEndDate
        '
        Me.dtEndDate.CustomFormat = "dd/MM/yyyy"
        Me.dtEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtEndDate.Location = New System.Drawing.Point(278, 49)
        Me.dtEndDate.Name = "dtEndDate"
        Me.dtEndDate.Size = New System.Drawing.Size(94, 20)
        Me.dtEndDate.TabIndex = 103
        '
        'dtStartDate
        '
        Me.dtStartDate.CustomFormat = "dd/MM/yyyy"
        Me.dtStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtStartDate.Location = New System.Drawing.Point(95, 49)
        Me.dtStartDate.Name = "dtStartDate"
        Me.dtStartDate.Size = New System.Drawing.Size(94, 20)
        Me.dtStartDate.TabIndex = 102
        '
        'ftabMain_Data
        '
        Me.ftabMain_Data.BackColor = System.Drawing.Color.White
        Me.ftabMain_Data.Controls.Add(Me.PnlDataFooter)
        Me.ftabMain_Data.Location = New System.Drawing.Point(4, 25)
        Me.ftabMain_Data.Name = "ftabMain_Data"
        Me.ftabMain_Data.Padding = New System.Windows.Forms.Padding(3)
        Me.ftabMain_Data.Size = New System.Drawing.Size(739, 488)
        Me.ftabMain_Data.TabIndex = 1
        Me.ftabMain_Data.Text = "Data"
        '
        'PnlDataFooter
        '
        Me.PnlDataFooter.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnlDataFooter.Location = New System.Drawing.Point(3, 458)
        Me.PnlDataFooter.Name = "PnlDataFooter"
        Me.PnlDataFooter.Size = New System.Drawing.Size(733, 27)
        Me.PnlDataFooter.TabIndex = 2
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btn_CheckAllAppDir, Me.btn_UnCheckAllAppDir, Me.btn_Refresh})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(192, 70)
        '
        'btn_CheckAllAppDir
        '
        Me.btn_CheckAllAppDir.Name = "btn_CheckAllAppDir"
        Me.btn_CheckAllAppDir.Size = New System.Drawing.Size(191, 22)
        Me.btn_CheckAllAppDir.Text = "Check All (App. Dir)"
        '
        'btn_UnCheckAllAppDir
        '
        Me.btn_UnCheckAllAppDir.Name = "btn_UnCheckAllAppDir"
        Me.btn_UnCheckAllAppDir.Size = New System.Drawing.Size(191, 22)
        Me.btn_UnCheckAllAppDir.Text = "UnCheck All (App. Dir)"
        '
        'btn_Refresh
        '
        Me.btn_Refresh.Name = "btn_Refresh"
        Me.btn_Refresh.Size = New System.Drawing.Size(191, 22)
        Me.btn_Refresh.Text = "Refresh"
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
        'uiRptBankReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.Controls.Add(Me.ftabMain)
        Me.DSN = resources.GetString("$this.DSN")
        Me.Name = "uiRptBankReport"
        Me.Controls.SetChildIndex(Me.ftabMain, 0)
        CType(Me.tbl_MstSetting, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ftabMain.ResumeLayout(False)
        Me.ftabMain_List.ResumeLayout(False)
        Me.pnlLoading.ResumeLayout(False)
        Me.pnlLoading.PerformLayout()
        Me.PnlDfSearch.ResumeLayout(False)
        Me.PnlDfSearch.PerformLayout()
        Me.ftabMain_Data.ResumeLayout(False)
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ftabMain As FlatTabControl.FlatTabControl
    Friend WithEvents ftabMain_List As System.Windows.Forms.TabPage
    Friend WithEvents ftabMain_Data As System.Windows.Forms.TabPage
    Friend WithEvents PnlDfSearch As System.Windows.Forms.Panel
    Friend WithEvents PnlDfFooter As System.Windows.Forms.Panel
    Friend WithEvents PnlDataFooter As System.Windows.Forms.Panel
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents btn_CheckAllAppDir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btn_UnCheckAllAppDir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btn_Refresh As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblLoading As System.Windows.Forms.Label
    Friend WithEvents obj_ProgressBar_backGroundWorker As System.Windows.Forms.ProgressBar
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboBankName As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtStartDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents pnlLoading As System.Windows.Forms.Panel
    Friend WithEvents lblProgress As System.Windows.Forms.Label
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar

End Class

