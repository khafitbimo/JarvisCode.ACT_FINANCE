﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.UiTrnJurnal_PV_Manual1 = New ACT_FINANCE.uiTrnJurnal_PV_Manual()
        Me.SuspendLayout()
        '
        'UiTrnJurnal_PV_Manual1
        '
        Me.UiTrnJurnal_PV_Manual1.BackColor = System.Drawing.Color.White
        Me.UiTrnJurnal_PV_Manual1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.UiTrnJurnal_PV_Manual1.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.UiTrnJurnal_PV_Manual1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UiTrnJurnal_PV_Manual1.Location = New System.Drawing.Point(0, 0)
        Me.UiTrnJurnal_PV_Manual1.MinimumSize = New System.Drawing.Size(755, 550)
        Me.UiTrnJurnal_PV_Manual1.Name = "UiTrnJurnal_PV_Manual1"
        Me.UiTrnJurnal_PV_Manual1.Size = New System.Drawing.Size(891, 563)
        Me.UiTrnJurnal_PV_Manual1.TabIndex = 0
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(891, 563)
        Me.Controls.Add(Me.UiTrnJurnal_PV_Manual1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UiTrnJurnal_PV_Manual1 As ACT_FINANCE.uiTrnJurnal_PV_Manual
End Class
