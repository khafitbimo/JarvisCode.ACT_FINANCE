<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgQueryBuilder
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
        Me.listFields = New System.Windows.Forms.ListBox
        Me.txtQuery = New System.Windows.Forms.TextBox
        Me.btnOK = New System.Windows.Forms.Button
        Me.listOperator = New System.Windows.Forms.ListBox
        Me.btnAdd = New System.Windows.Forms.Button
        Me.listLogical = New System.Windows.Forms.ListBox
        Me.btnClear = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'listFields
        '
        Me.listFields.FormattingEnabled = True
        Me.listFields.Location = New System.Drawing.Point(12, 25)
        Me.listFields.Name = "listFields"
        Me.listFields.Size = New System.Drawing.Size(140, 251)
        Me.listFields.TabIndex = 0
        '
        'txtQuery
        '
        Me.txtQuery.Location = New System.Drawing.Point(276, 25)
        Me.txtQuery.Multiline = True
        Me.txtQuery.Name = "txtQuery"
        Me.txtQuery.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtQuery.Size = New System.Drawing.Size(311, 251)
        Me.txtQuery.TabIndex = 1
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(512, 303)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 2
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'listOperator
        '
        Me.listOperator.FormattingEnabled = True
        Me.listOperator.Location = New System.Drawing.Point(158, 25)
        Me.listOperator.Name = "listOperator"
        Me.listOperator.Size = New System.Drawing.Size(97, 121)
        Me.listOperator.TabIndex = 3
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(158, 253)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(97, 23)
        Me.btnAdd.TabIndex = 4
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'listLogical
        '
        Me.listLogical.FormattingEnabled = True
        Me.listLogical.Location = New System.Drawing.Point(158, 178)
        Me.listLogical.Name = "listLogical"
        Me.listLogical.Size = New System.Drawing.Size(97, 56)
        Me.listLogical.TabIndex = 5
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(276, 303)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(75, 23)
        Me.btnClear.TabIndex = 6
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(431, 303)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 7
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Fields"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(155, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Operator"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(273, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 13)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Query"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(158, 162)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 13)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Logical"
        '
        'dlgQueryBuilder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(599, 342)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.listLogical)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.listOperator)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.txtQuery)
        Me.Controls.Add(Me.listFields)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "dlgQueryBuilder"
        Me.Text = "Query Builder"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents listFields As System.Windows.Forms.ListBox
    Friend WithEvents txtQuery As System.Windows.Forms.TextBox
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents listOperator As System.Windows.Forms.ListBox
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents listLogical As System.Windows.Forms.ListBox
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
