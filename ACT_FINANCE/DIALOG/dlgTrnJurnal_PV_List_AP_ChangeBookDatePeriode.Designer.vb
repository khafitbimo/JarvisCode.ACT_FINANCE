<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgTrnJurnal_PV_List_AP_ChangeBookDatePeriode
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
        Me.obj_Jurnal_bookdate = New System.Windows.Forms.DateTimePicker()
        Me.obj_Periode_id = New System.Windows.Forms.ComboBox()
        Me.lbl_Jurnal_bookdate = New System.Windows.Forms.Label()
        Me.lbl_Periode_id = New System.Windows.Forms.Label()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.cboBank = New System.Windows.Forms.ComboBox()
        Me.cboPaymentType = New System.Windows.Forms.ComboBox()
        Me.obj_Jurnal_bilyetdate = New System.Windows.Forms.DateTimePicker()
        Me.obj_Jurnal_paymentdate = New System.Windows.Forms.DateTimePicker()
        Me.chkBank = New System.Windows.Forms.CheckBox()
        Me.chkPaymentType = New System.Windows.Forms.CheckBox()
        Me.chkBilyetDate = New System.Windows.Forms.CheckBox()
        Me.chkEffectiveDate = New System.Windows.Forms.CheckBox()
        Me.chkAccCaId = New System.Windows.Forms.CheckBox()
        Me.cboAccCaId = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'obj_Jurnal_bookdate
        '
        Me.obj_Jurnal_bookdate.CalendarForeColor = System.Drawing.Color.Black
        Me.obj_Jurnal_bookdate.CalendarMonthBackground = System.Drawing.Color.White
        Me.obj_Jurnal_bookdate.CalendarTitleBackColor = System.Drawing.Color.Thistle
        Me.obj_Jurnal_bookdate.CalendarTitleForeColor = System.Drawing.Color.Black
        Me.obj_Jurnal_bookdate.CalendarTrailingForeColor = System.Drawing.Color.Gray
        Me.obj_Jurnal_bookdate.CustomFormat = "dd/MM/yyyy"
        Me.obj_Jurnal_bookdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.obj_Jurnal_bookdate.Location = New System.Drawing.Point(121, 12)
        Me.obj_Jurnal_bookdate.Name = "obj_Jurnal_bookdate"
        Me.obj_Jurnal_bookdate.Size = New System.Drawing.Size(100, 20)
        Me.obj_Jurnal_bookdate.TabIndex = 8
        '
        'obj_Periode_id
        '
        Me.obj_Periode_id.BackColor = System.Drawing.Color.Honeydew
        Me.obj_Periode_id.FormattingEnabled = True
        Me.obj_Periode_id.Location = New System.Drawing.Point(121, 38)
        Me.obj_Periode_id.Name = "obj_Periode_id"
        Me.obj_Periode_id.Size = New System.Drawing.Size(165, 21)
        Me.obj_Periode_id.TabIndex = 9
        '
        'lbl_Jurnal_bookdate
        '
        Me.lbl_Jurnal_bookdate.AutoSize = True
        Me.lbl_Jurnal_bookdate.Location = New System.Drawing.Point(21, 16)
        Me.lbl_Jurnal_bookdate.Name = "lbl_Jurnal_bookdate"
        Me.lbl_Jurnal_bookdate.Size = New System.Drawing.Size(58, 13)
        Me.lbl_Jurnal_bookdate.TabIndex = 10
        Me.lbl_Jurnal_bookdate.Text = "Book Date"
        '
        'lbl_Periode_id
        '
        Me.lbl_Periode_id.AutoSize = True
        Me.lbl_Periode_id.Location = New System.Drawing.Point(21, 42)
        Me.lbl_Periode_id.Name = "lbl_Periode_id"
        Me.lbl_Periode_id.Size = New System.Drawing.Size(43, 13)
        Me.lbl_Periode_id.TabIndex = 11
        Me.lbl_Periode_id.Text = "Periode"
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(293, 212)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(103, 23)
        Me.btnOK.TabIndex = 12
        Me.btnOK.Text = "Change"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'cboBank
        '
        Me.cboBank.BackColor = System.Drawing.Color.Honeydew
        Me.cboBank.FormattingEnabled = True
        Me.cboBank.Location = New System.Drawing.Point(121, 65)
        Me.cboBank.Name = "cboBank"
        Me.cboBank.Size = New System.Drawing.Size(275, 21)
        Me.cboBank.TabIndex = 13
        '
        'cboPaymentType
        '
        Me.cboPaymentType.BackColor = System.Drawing.Color.Honeydew
        Me.cboPaymentType.FormattingEnabled = True
        Me.cboPaymentType.Location = New System.Drawing.Point(121, 92)
        Me.cboPaymentType.Name = "cboPaymentType"
        Me.cboPaymentType.Size = New System.Drawing.Size(165, 21)
        Me.cboPaymentType.TabIndex = 15
        '
        'obj_Jurnal_bilyetdate
        '
        Me.obj_Jurnal_bilyetdate.CalendarForeColor = System.Drawing.Color.Black
        Me.obj_Jurnal_bilyetdate.CalendarMonthBackground = System.Drawing.Color.White
        Me.obj_Jurnal_bilyetdate.CalendarTitleBackColor = System.Drawing.Color.Thistle
        Me.obj_Jurnal_bilyetdate.CalendarTitleForeColor = System.Drawing.Color.Black
        Me.obj_Jurnal_bilyetdate.CalendarTrailingForeColor = System.Drawing.Color.Gray
        Me.obj_Jurnal_bilyetdate.CustomFormat = "dd/MM/yyyy"
        Me.obj_Jurnal_bilyetdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.obj_Jurnal_bilyetdate.Location = New System.Drawing.Point(121, 119)
        Me.obj_Jurnal_bilyetdate.Name = "obj_Jurnal_bilyetdate"
        Me.obj_Jurnal_bilyetdate.Size = New System.Drawing.Size(100, 20)
        Me.obj_Jurnal_bilyetdate.TabIndex = 17
        '
        'obj_Jurnal_paymentdate
        '
        Me.obj_Jurnal_paymentdate.CalendarForeColor = System.Drawing.Color.Black
        Me.obj_Jurnal_paymentdate.CalendarMonthBackground = System.Drawing.Color.White
        Me.obj_Jurnal_paymentdate.CalendarTitleBackColor = System.Drawing.Color.Thistle
        Me.obj_Jurnal_paymentdate.CalendarTitleForeColor = System.Drawing.Color.Black
        Me.obj_Jurnal_paymentdate.CalendarTrailingForeColor = System.Drawing.Color.Gray
        Me.obj_Jurnal_paymentdate.CustomFormat = "dd/MM/yyyy"
        Me.obj_Jurnal_paymentdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.obj_Jurnal_paymentdate.Location = New System.Drawing.Point(121, 145)
        Me.obj_Jurnal_paymentdate.Name = "obj_Jurnal_paymentdate"
        Me.obj_Jurnal_paymentdate.Size = New System.Drawing.Size(100, 20)
        Me.obj_Jurnal_paymentdate.TabIndex = 19
        '
        'chkBank
        '
        Me.chkBank.AutoSize = True
        Me.chkBank.Location = New System.Drawing.Point(24, 67)
        Me.chkBank.Name = "chkBank"
        Me.chkBank.Size = New System.Drawing.Size(51, 17)
        Me.chkBank.TabIndex = 21
        Me.chkBank.Text = "Bank"
        Me.chkBank.UseVisualStyleBackColor = True
        '
        'chkPaymentType
        '
        Me.chkPaymentType.AutoSize = True
        Me.chkPaymentType.Location = New System.Drawing.Point(24, 94)
        Me.chkPaymentType.Name = "chkPaymentType"
        Me.chkPaymentType.Size = New System.Drawing.Size(94, 17)
        Me.chkPaymentType.TabIndex = 22
        Me.chkPaymentType.Text = "Payment Type"
        Me.chkPaymentType.UseVisualStyleBackColor = True
        '
        'chkBilyetDate
        '
        Me.chkBilyetDate.AutoSize = True
        Me.chkBilyetDate.Location = New System.Drawing.Point(24, 119)
        Me.chkBilyetDate.Name = "chkBilyetDate"
        Me.chkBilyetDate.Size = New System.Drawing.Size(77, 17)
        Me.chkBilyetDate.TabIndex = 23
        Me.chkBilyetDate.Text = "Bilyet Date"
        Me.chkBilyetDate.UseVisualStyleBackColor = True
        '
        'chkEffectiveDate
        '
        Me.chkEffectiveDate.AutoSize = True
        Me.chkEffectiveDate.Location = New System.Drawing.Point(24, 145)
        Me.chkEffectiveDate.Name = "chkEffectiveDate"
        Me.chkEffectiveDate.Size = New System.Drawing.Size(94, 17)
        Me.chkEffectiveDate.TabIndex = 24
        Me.chkEffectiveDate.Text = "Effective Date"
        Me.chkEffectiveDate.UseVisualStyleBackColor = True
        '
        'chkAccCaId
        '
        Me.chkAccCaId.AutoSize = True
        Me.chkAccCaId.Location = New System.Drawing.Point(24, 173)
        Me.chkAccCaId.Name = "chkAccCaId"
        Me.chkAccCaId.Size = New System.Drawing.Size(92, 17)
        Me.chkAccCaId.TabIndex = 25
        Me.chkAccCaId.Text = "Acc Ca Name"
        Me.chkAccCaId.UseVisualStyleBackColor = True
        '
        'cboAccCaId
        '
        Me.cboAccCaId.BackColor = System.Drawing.Color.Honeydew
        Me.cboAccCaId.FormattingEnabled = True
        Me.cboAccCaId.Location = New System.Drawing.Point(121, 171)
        Me.cboAccCaId.Name = "cboAccCaId"
        Me.cboAccCaId.Size = New System.Drawing.Size(275, 21)
        Me.cboAccCaId.TabIndex = 26
        '
        'dlgTrnJurnal_PV_List_AP_ChangeBookDatePeriode
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(412, 253)
        Me.Controls.Add(Me.cboAccCaId)
        Me.Controls.Add(Me.chkAccCaId)
        Me.Controls.Add(Me.chkEffectiveDate)
        Me.Controls.Add(Me.chkBilyetDate)
        Me.Controls.Add(Me.chkPaymentType)
        Me.Controls.Add(Me.chkBank)
        Me.Controls.Add(Me.obj_Jurnal_paymentdate)
        Me.Controls.Add(Me.obj_Jurnal_bilyetdate)
        Me.Controls.Add(Me.cboPaymentType)
        Me.Controls.Add(Me.cboBank)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.lbl_Jurnal_bookdate)
        Me.Controls.Add(Me.lbl_Periode_id)
        Me.Controls.Add(Me.obj_Periode_id)
        Me.Controls.Add(Me.obj_Jurnal_bookdate)
        Me.Name = "dlgTrnJurnal_PV_List_AP_ChangeBookDatePeriode"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Change Period & Bank"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents obj_Jurnal_bookdate As System.Windows.Forms.DateTimePicker
    Friend WithEvents obj_Periode_id As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_Jurnal_bookdate As System.Windows.Forms.Label
    Friend WithEvents lbl_Periode_id As System.Windows.Forms.Label
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents cboBank As System.Windows.Forms.ComboBox
    Friend WithEvents cboPaymentType As System.Windows.Forms.ComboBox
    Friend WithEvents obj_Jurnal_bilyetdate As System.Windows.Forms.DateTimePicker
    Friend WithEvents obj_Jurnal_paymentdate As System.Windows.Forms.DateTimePicker
    Friend WithEvents chkBank As System.Windows.Forms.CheckBox
    Friend WithEvents chkPaymentType As System.Windows.Forms.CheckBox
    Friend WithEvents chkBilyetDate As System.Windows.Forms.CheckBox
    Friend WithEvents chkEffectiveDate As System.Windows.Forms.CheckBox
    Friend WithEvents chkAccCaId As System.Windows.Forms.CheckBox
    Friend WithEvents cboAccCaId As System.Windows.Forms.ComboBox
End Class
