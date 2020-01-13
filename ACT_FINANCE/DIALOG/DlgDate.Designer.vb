<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DlgDate
    Inherits DevExpress.XtraEditors.XtraForm

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
        Me.DateNavigator1 = New DevExpress.XtraScheduler.DateNavigator()
        Me.SBOK = New DevExpress.XtraEditors.SimpleButton()
        Me.SBCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.SBClear = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.DateNavigator1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DateNavigator1
        '
        Me.DateNavigator1.DateTime = New Date(2018, 4, 24, 0, 0, 0, 0)
        Me.DateNavigator1.HotDate = Nothing
        Me.DateNavigator1.Location = New System.Drawing.Point(12, 12)
        Me.DateNavigator1.Multiselect = False
        Me.DateNavigator1.Name = "DateNavigator1"
        Me.DateNavigator1.Size = New System.Drawing.Size(257, 175)
        Me.DateNavigator1.TabIndex = 0
        '
        'SBOK
        '
        Me.SBOK.Location = New System.Drawing.Point(112, 193)
        Me.SBOK.Name = "SBOK"
        Me.SBOK.Size = New System.Drawing.Size(75, 23)
        Me.SBOK.TabIndex = 1
        Me.SBOK.Text = "OK"
        '
        'SBCancel
        '
        Me.SBCancel.Location = New System.Drawing.Point(194, 193)
        Me.SBCancel.Name = "SBCancel"
        Me.SBCancel.Size = New System.Drawing.Size(75, 23)
        Me.SBCancel.TabIndex = 2
        Me.SBCancel.Text = "Cancel"
        '
        'SBClear
        '
        Me.SBClear.Location = New System.Drawing.Point(12, 193)
        Me.SBClear.Name = "SBClear"
        Me.SBClear.Size = New System.Drawing.Size(75, 23)
        Me.SBClear.TabIndex = 3
        Me.SBClear.Text = "Nothing"
        '
        'DlgDate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(281, 222)
        Me.Controls.Add(Me.SBClear)
        Me.Controls.Add(Me.SBCancel)
        Me.Controls.Add(Me.SBOK)
        Me.Controls.Add(Me.DateNavigator1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DlgDate"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Date"
        CType(Me.DateNavigator1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DateNavigator1 As DevExpress.XtraScheduler.DateNavigator
    Friend WithEvents SBOK As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SBCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SBClear As DevExpress.XtraEditors.SimpleButton

End Class
