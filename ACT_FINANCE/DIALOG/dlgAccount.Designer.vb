<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgAccount
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.chkActive = New System.Windows.Forms.CheckBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtAcc = New System.Windows.Forms.TextBox()
        Me.txtAccName = New System.Windows.Forms.TextBox()
        Me.cmbCurrency = New System.Windows.Forms.ComboBox()
        Me.txtDescr = New System.Windows.Forms.TextBox()
        Me.txtTlp = New System.Windows.Forms.TextBox()
        Me.txtFax = New System.Windows.Forms.TextBox()
        Me.txtBranch = New System.Windows.Forms.TextBox()
        Me.txtAddr1 = New System.Windows.Forms.TextBox()
        Me.txtAddr2 = New System.Windows.Forms.TextBox()
        Me.cmbAccount = New System.Windows.Forms.ComboBox()
        Me.txtReportName = New System.Windows.Forms.TextBox()
        Me.txtFormBG = New System.Windows.Forms.TextBox()
        Me.txtFormCek = New System.Windows.Forms.TextBox()
        Me.txtFormTrf = New System.Windows.Forms.TextBox()
        Me.txtFormSet = New System.Windows.Forms.TextBox()
        Me.txtDate = New System.Windows.Forms.TextBox()
        Me.txtCreateBy = New System.Windows.Forms.TextBox()
        Me.txtIdCurrencyforCombo = New System.Windows.Forms.TextBox()
        Me.txtAccountforCombo = New System.Windows.Forms.TextBox()
        Me.kalendar = New System.Windows.Forms.DateTimePicker()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(258, 505)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Cancel"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(4, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Bank Account"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(4, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Account Name"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(4, 69)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Currency"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(3, 96)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Description"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(4, 126)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 13)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Account Tlp"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(3, 155)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(67, 13)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Account Fax"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(4, 184)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(41, 13)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "Branch"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(4, 210)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(51, 13)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "Adrress 1"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(4, 239)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(54, 13)
        Me.Label9.TabIndex = 9
        Me.Label9.Text = "Address 2"
        '
        'chkActive
        '
        Me.chkActive.AutoSize = True
        Me.chkActive.Location = New System.Drawing.Point(7, 439)
        Me.chkActive.Name = "chkActive"
        Me.chkActive.Size = New System.Drawing.Size(56, 17)
        Me.chkActive.TabIndex = 10
        Me.chkActive.Text = "Active" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.chkActive.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(4, 267)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(47, 13)
        Me.Label10.TabIndex = 11
        Me.Label10.Text = "Account"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(4, 465)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(64, 13)
        Me.Label11.TabIndex = 12
        Me.Label11.Text = "Create Date"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(210, 466)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(53, 13)
        Me.Label12.TabIndex = 13
        Me.Label12.Text = "Create By" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(4, 295)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(70, 13)
        Me.Label13.TabIndex = 14
        Me.Label13.Text = "Report Name"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(4, 324)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(48, 13)
        Me.Label14.TabIndex = 15
        Me.Label14.Text = "Form BG"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(4, 351)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(52, 13)
        Me.Label15.TabIndex = 16
        Me.Label15.Text = "Form Cek"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(4, 381)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(54, 13)
        Me.Label16.TabIndex = 17
        Me.Label16.Text = "Form TRF"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(4, 411)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(54, 13)
        Me.Label17.TabIndex = 18
        Me.Label17.Text = "Form SET"
        '
        'txtAcc
        '
        Me.txtAcc.Location = New System.Drawing.Point(110, 13)
        Me.txtAcc.Name = "txtAcc"
        Me.txtAcc.Size = New System.Drawing.Size(289, 20)
        Me.txtAcc.TabIndex = 19
        '
        'txtAccName
        '
        Me.txtAccName.Location = New System.Drawing.Point(110, 40)
        Me.txtAccName.Name = "txtAccName"
        Me.txtAccName.Size = New System.Drawing.Size(289, 20)
        Me.txtAccName.TabIndex = 20
        '
        'cmbCurrency
        '
        Me.cmbCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCurrency.FormattingEnabled = True
        Me.cmbCurrency.Location = New System.Drawing.Point(110, 67)
        Me.cmbCurrency.Name = "cmbCurrency"
        Me.cmbCurrency.Size = New System.Drawing.Size(121, 21)
        Me.cmbCurrency.TabIndex = 21
        '
        'txtDescr
        '
        Me.txtDescr.Location = New System.Drawing.Point(110, 94)
        Me.txtDescr.Name = "txtDescr"
        Me.txtDescr.Size = New System.Drawing.Size(289, 20)
        Me.txtDescr.TabIndex = 22
        '
        'txtTlp
        '
        Me.txtTlp.Location = New System.Drawing.Point(110, 121)
        Me.txtTlp.Name = "txtTlp"
        Me.txtTlp.Size = New System.Drawing.Size(179, 20)
        Me.txtTlp.TabIndex = 23
        '
        'txtFax
        '
        Me.txtFax.Location = New System.Drawing.Point(110, 150)
        Me.txtFax.Name = "txtFax"
        Me.txtFax.Size = New System.Drawing.Size(179, 20)
        Me.txtFax.TabIndex = 24
        '
        'txtBranch
        '
        Me.txtBranch.Location = New System.Drawing.Point(110, 177)
        Me.txtBranch.Name = "txtBranch"
        Me.txtBranch.Size = New System.Drawing.Size(289, 20)
        Me.txtBranch.TabIndex = 25
        '
        'txtAddr1
        '
        Me.txtAddr1.Location = New System.Drawing.Point(110, 205)
        Me.txtAddr1.Name = "txtAddr1"
        Me.txtAddr1.Size = New System.Drawing.Size(289, 20)
        Me.txtAddr1.TabIndex = 26
        '
        'txtAddr2
        '
        Me.txtAddr2.Location = New System.Drawing.Point(110, 234)
        Me.txtAddr2.Name = "txtAddr2"
        Me.txtAddr2.Size = New System.Drawing.Size(289, 20)
        Me.txtAddr2.TabIndex = 27
        '
        'cmbAccount
        '
        Me.cmbAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAccount.FormattingEnabled = True
        Me.cmbAccount.Location = New System.Drawing.Point(110, 263)
        Me.cmbAccount.Name = "cmbAccount"
        Me.cmbAccount.Size = New System.Drawing.Size(289, 21)
        Me.cmbAccount.TabIndex = 28
        '
        'txtReportName
        '
        Me.txtReportName.Location = New System.Drawing.Point(110, 292)
        Me.txtReportName.Name = "txtReportName"
        Me.txtReportName.Size = New System.Drawing.Size(289, 20)
        Me.txtReportName.TabIndex = 29
        '
        'txtFormBG
        '
        Me.txtFormBG.Location = New System.Drawing.Point(110, 319)
        Me.txtFormBG.Name = "txtFormBG"
        Me.txtFormBG.Size = New System.Drawing.Size(289, 20)
        Me.txtFormBG.TabIndex = 30
        '
        'txtFormCek
        '
        Me.txtFormCek.Location = New System.Drawing.Point(110, 347)
        Me.txtFormCek.Name = "txtFormCek"
        Me.txtFormCek.Size = New System.Drawing.Size(289, 20)
        Me.txtFormCek.TabIndex = 31
        '
        'txtFormTrf
        '
        Me.txtFormTrf.Location = New System.Drawing.Point(110, 374)
        Me.txtFormTrf.Name = "txtFormTrf"
        Me.txtFormTrf.Size = New System.Drawing.Size(289, 20)
        Me.txtFormTrf.TabIndex = 32
        '
        'txtFormSet
        '
        Me.txtFormSet.Location = New System.Drawing.Point(110, 404)
        Me.txtFormSet.Name = "txtFormSet"
        Me.txtFormSet.Size = New System.Drawing.Size(289, 20)
        Me.txtFormSet.TabIndex = 33
        '
        'txtDate
        '
        Me.txtDate.Location = New System.Drawing.Point(72, 462)
        Me.txtDate.Name = "txtDate"
        Me.txtDate.ReadOnly = True
        Me.txtDate.Size = New System.Drawing.Size(132, 20)
        Me.txtDate.TabIndex = 34
        '
        'txtCreateBy
        '
        Me.txtCreateBy.Location = New System.Drawing.Point(266, 462)
        Me.txtCreateBy.Name = "txtCreateBy"
        Me.txtCreateBy.ReadOnly = True
        Me.txtCreateBy.Size = New System.Drawing.Size(133, 20)
        Me.txtCreateBy.TabIndex = 35
        '
        'txtIdCurrencyforCombo
        '
        Me.txtIdCurrencyforCombo.Location = New System.Drawing.Point(453, 280)
        Me.txtIdCurrencyforCombo.Name = "txtIdCurrencyforCombo"
        Me.txtIdCurrencyforCombo.Size = New System.Drawing.Size(100, 20)
        Me.txtIdCurrencyforCombo.TabIndex = 36
        Me.txtIdCurrencyforCombo.Visible = False
        '
        'txtAccountforCombo
        '
        Me.txtAccountforCombo.Location = New System.Drawing.Point(453, 309)
        Me.txtAccountforCombo.Name = "txtAccountforCombo"
        Me.txtAccountforCombo.Size = New System.Drawing.Size(100, 20)
        Me.txtAccountforCombo.TabIndex = 37
        Me.txtAccountforCombo.Visible = False
        '
        'kalendar
        '
        Me.kalendar.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.kalendar.Location = New System.Drawing.Point(453, 339)
        Me.kalendar.Name = "kalendar"
        Me.kalendar.Size = New System.Drawing.Size(100, 20)
        Me.kalendar.TabIndex = 38
        Me.kalendar.Visible = False
        '
        'dlgAccount
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightGray
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(407, 540)
        Me.ControlBox = False
        Me.Controls.Add(Me.kalendar)
        Me.Controls.Add(Me.txtAccountforCombo)
        Me.Controls.Add(Me.txtIdCurrencyforCombo)
        Me.Controls.Add(Me.txtCreateBy)
        Me.Controls.Add(Me.txtDate)
        Me.Controls.Add(Me.txtFormSet)
        Me.Controls.Add(Me.txtFormTrf)
        Me.Controls.Add(Me.txtFormCek)
        Me.Controls.Add(Me.txtFormBG)
        Me.Controls.Add(Me.txtReportName)
        Me.Controls.Add(Me.cmbAccount)
        Me.Controls.Add(Me.txtAddr2)
        Me.Controls.Add(Me.txtAddr1)
        Me.Controls.Add(Me.txtBranch)
        Me.Controls.Add(Me.txtFax)
        Me.Controls.Add(Me.txtTlp)
        Me.Controls.Add(Me.txtDescr)
        Me.Controls.Add(Me.cmbCurrency)
        Me.Controls.Add(Me.txtAccName)
        Me.Controls.Add(Me.txtAcc)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.chkActive)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgAccount"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Account"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents chkActive As System.Windows.Forms.CheckBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtAcc As System.Windows.Forms.TextBox
    Friend WithEvents txtAccName As System.Windows.Forms.TextBox
    Friend WithEvents cmbCurrency As System.Windows.Forms.ComboBox
    Friend WithEvents txtDescr As System.Windows.Forms.TextBox
    Friend WithEvents txtTlp As System.Windows.Forms.TextBox
    Friend WithEvents txtFax As System.Windows.Forms.TextBox
    Friend WithEvents txtBranch As System.Windows.Forms.TextBox
    Friend WithEvents txtAddr1 As System.Windows.Forms.TextBox
    Friend WithEvents txtAddr2 As System.Windows.Forms.TextBox
    Friend WithEvents cmbAccount As System.Windows.Forms.ComboBox
    Friend WithEvents txtReportName As System.Windows.Forms.TextBox
    Friend WithEvents txtFormBG As System.Windows.Forms.TextBox
    Friend WithEvents txtFormCek As System.Windows.Forms.TextBox
    Friend WithEvents txtFormTrf As System.Windows.Forms.TextBox
    Friend WithEvents txtFormSet As System.Windows.Forms.TextBox
    Friend WithEvents txtDate As System.Windows.Forms.TextBox
    Friend WithEvents txtCreateBy As System.Windows.Forms.TextBox
    Friend WithEvents txtIdCurrencyforCombo As System.Windows.Forms.TextBox
    Friend WithEvents txtAccountforCombo As System.Windows.Forms.TextBox
    Friend WithEvents kalendar As System.Windows.Forms.DateTimePicker

End Class
