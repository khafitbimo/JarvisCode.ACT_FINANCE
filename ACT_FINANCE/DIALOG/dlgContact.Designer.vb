<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgContact
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.OK_Button = New System.Windows.Forms.Button
        Me.Cancel_Button = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.shortname = New System.Windows.Forms.TextBox
        Me.position = New System.Windows.Forms.TextBox
        Me.tlp = New System.Windows.Forms.TextBox
        Me.fax = New System.Windows.Forms.TextBox
        Me.addr1 = New System.Windows.Forms.TextBox
        Me.addr2 = New System.Windows.Forms.TextBox
        Me.idBankForContact = New System.Windows.Forms.TextBox
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
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(228, 166)
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
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(103, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Contact Short Name"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Contact Position"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 59)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Contact Tlp"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 88)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Contact Fax"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 120)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(54, 13)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Address 1"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 149)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(54, 13)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Address 2"
        '
        'shortname
        '
        Me.shortname.Location = New System.Drawing.Point(132, 5)
        Me.shortname.Name = "shortname"
        Me.shortname.Size = New System.Drawing.Size(185, 20)
        Me.shortname.TabIndex = 7
        '
        'position
        '
        Me.position.Location = New System.Drawing.Point(132, 31)
        Me.position.Name = "position"
        Me.position.Size = New System.Drawing.Size(185, 20)
        Me.position.TabIndex = 8
        '
        'tlp
        '
        Me.tlp.Location = New System.Drawing.Point(132, 58)
        Me.tlp.Name = "tlp"
        Me.tlp.Size = New System.Drawing.Size(185, 20)
        Me.tlp.TabIndex = 9
        '
        'fax
        '
        Me.fax.Location = New System.Drawing.Point(132, 85)
        Me.fax.Name = "fax"
        Me.fax.Size = New System.Drawing.Size(185, 20)
        Me.fax.TabIndex = 10
        '
        'addr1
        '
        Me.addr1.Location = New System.Drawing.Point(132, 114)
        Me.addr1.Name = "addr1"
        Me.addr1.Size = New System.Drawing.Size(239, 20)
        Me.addr1.TabIndex = 11
        '
        'addr2
        '
        Me.addr2.Location = New System.Drawing.Point(132, 140)
        Me.addr2.Name = "addr2"
        Me.addr2.Size = New System.Drawing.Size(239, 20)
        Me.addr2.TabIndex = 12
        '
        'idBankForContact
        '
        Me.idBankForContact.Location = New System.Drawing.Point(8, 172)
        Me.idBankForContact.Name = "idBankForContact"
        Me.idBankForContact.ReadOnly = True
        Me.idBankForContact.Size = New System.Drawing.Size(100, 20)
        Me.idBankForContact.TabIndex = 13
        Me.idBankForContact.Visible = False
        '
        'dlgContact
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LavenderBlush
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(386, 207)
        Me.Controls.Add(Me.idBankForContact)
        Me.Controls.Add(Me.addr2)
        Me.Controls.Add(Me.addr1)
        Me.Controls.Add(Me.fax)
        Me.Controls.Add(Me.tlp)
        Me.Controls.Add(Me.position)
        Me.Controls.Add(Me.shortname)
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
        Me.Name = "dlgContact"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Contact"
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
    Friend WithEvents shortname As System.Windows.Forms.TextBox
    Friend WithEvents position As System.Windows.Forms.TextBox
    Friend WithEvents tlp As System.Windows.Forms.TextBox
    Friend WithEvents fax As System.Windows.Forms.TextBox
    Friend WithEvents addr1 As System.Windows.Forms.TextBox
    Friend WithEvents addr2 As System.Windows.Forms.TextBox
    Friend WithEvents idBankForContact As System.Windows.Forms.TextBox

End Class
