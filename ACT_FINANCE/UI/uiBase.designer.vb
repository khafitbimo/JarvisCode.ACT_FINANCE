<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class uiBase
    Inherits System.Windows.Forms.UserControl

    'UserControl1 overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(uiBase))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tbtnNew = New System.Windows.Forms.ToolStripButton()
        Me.tbtnSave = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tbtnPrint = New System.Windows.Forms.ToolStripButton()
        Me.tbtnPrintPreview = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.tbtnEdit = New System.Windows.Forms.ToolStripButton()
        Me.tbtnDel = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tbtnLoad = New System.Windows.Forms.ToolStripButton()
        Me.tbtnQuery = New System.Windows.Forms.ToolStripButton()
        Me.tbtnRefresh = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tbtnFirst = New System.Windows.Forms.ToolStripButton()
        Me.tbtnPrev = New System.Windows.Forms.ToolStripButton()
        Me.tbtnNext = New System.Windows.Forms.ToolStripButton()
        Me.tbtnLast = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.SystemColors.Control
        Me.ToolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tbtnNew, Me.tbtnSave, Me.ToolStripSeparator1, Me.tbtnPrint, Me.tbtnPrintPreview, Me.ToolStripSeparator5, Me.tbtnEdit, Me.tbtnDel, Me.ToolStripSeparator2, Me.tbtnLoad, Me.tbtnQuery, Me.tbtnRefresh, Me.ToolStripSeparator3, Me.tbtnFirst, Me.tbtnPrev, Me.tbtnNext, Me.tbtnLast, Me.ToolStripSeparator4})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(755, 25)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tbtnNew
        '
        Me.tbtnNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tbtnNew.Image = CType(resources.GetObject("tbtnNew.Image"), System.Drawing.Image)
        Me.tbtnNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbtnNew.Name = "tbtnNew"
        Me.tbtnNew.Size = New System.Drawing.Size(23, 22)
        Me.tbtnNew.Text = "Data Baru"
        '
        'tbtnSave
        '
        Me.tbtnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tbtnSave.Image = CType(resources.GetObject("tbtnSave.Image"), System.Drawing.Image)
        Me.tbtnSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbtnSave.Name = "tbtnSave"
        Me.tbtnSave.Size = New System.Drawing.Size(23, 22)
        Me.tbtnSave.Text = "Simpan"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'tbtnPrint
        '
        Me.tbtnPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tbtnPrint.Image = CType(resources.GetObject("tbtnPrint.Image"), System.Drawing.Image)
        Me.tbtnPrint.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbtnPrint.Name = "tbtnPrint"
        Me.tbtnPrint.Size = New System.Drawing.Size(23, 22)
        Me.tbtnPrint.Text = "Cetak"
        '
        'tbtnPrintPreview
        '
        Me.tbtnPrintPreview.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tbtnPrintPreview.Image = CType(resources.GetObject("tbtnPrintPreview.Image"), System.Drawing.Image)
        Me.tbtnPrintPreview.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbtnPrintPreview.Name = "tbtnPrintPreview"
        Me.tbtnPrintPreview.Size = New System.Drawing.Size(23, 22)
        Me.tbtnPrintPreview.Text = "Preview"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
        '
        'tbtnEdit
        '
        Me.tbtnEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tbtnEdit.Image = CType(resources.GetObject("tbtnEdit.Image"), System.Drawing.Image)
        Me.tbtnEdit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbtnEdit.Name = "tbtnEdit"
        Me.tbtnEdit.Size = New System.Drawing.Size(23, 22)
        Me.tbtnEdit.Text = "Edit"
        '
        'tbtnDel
        '
        Me.tbtnDel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tbtnDel.Image = CType(resources.GetObject("tbtnDel.Image"), System.Drawing.Image)
        Me.tbtnDel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbtnDel.Name = "tbtnDel"
        Me.tbtnDel.Size = New System.Drawing.Size(23, 22)
        Me.tbtnDel.Text = "Hapus"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'tbtnLoad
        '
        Me.tbtnLoad.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tbtnLoad.Image = CType(resources.GetObject("tbtnLoad.Image"), System.Drawing.Image)
        Me.tbtnLoad.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbtnLoad.Name = "tbtnLoad"
        Me.tbtnLoad.Size = New System.Drawing.Size(23, 22)
        Me.tbtnLoad.Text = "Load Data"
        '
        'tbtnQuery
        '
        Me.tbtnQuery.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tbtnQuery.Image = CType(resources.GetObject("tbtnQuery.Image"), System.Drawing.Image)
        Me.tbtnQuery.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbtnQuery.Name = "tbtnQuery"
        Me.tbtnQuery.Size = New System.Drawing.Size(23, 22)
        Me.tbtnQuery.Text = "Query"
        '
        'tbtnRefresh
        '
        Me.tbtnRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tbtnRefresh.Image = CType(resources.GetObject("tbtnRefresh.Image"), System.Drawing.Image)
        Me.tbtnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbtnRefresh.Name = "tbtnRefresh"
        Me.tbtnRefresh.Size = New System.Drawing.Size(23, 22)
        Me.tbtnRefresh.Text = "Refresh"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'tbtnFirst
        '
        Me.tbtnFirst.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tbtnFirst.Image = CType(resources.GetObject("tbtnFirst.Image"), System.Drawing.Image)
        Me.tbtnFirst.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbtnFirst.Name = "tbtnFirst"
        Me.tbtnFirst.Size = New System.Drawing.Size(23, 22)
        Me.tbtnFirst.Text = "First"
        '
        'tbtnPrev
        '
        Me.tbtnPrev.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tbtnPrev.Image = CType(resources.GetObject("tbtnPrev.Image"), System.Drawing.Image)
        Me.tbtnPrev.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbtnPrev.Name = "tbtnPrev"
        Me.tbtnPrev.Size = New System.Drawing.Size(23, 22)
        Me.tbtnPrev.Text = "Prev"
        '
        'tbtnNext
        '
        Me.tbtnNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tbtnNext.Image = CType(resources.GetObject("tbtnNext.Image"), System.Drawing.Image)
        Me.tbtnNext.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbtnNext.Name = "tbtnNext"
        Me.tbtnNext.Size = New System.Drawing.Size(23, 22)
        Me.tbtnNext.Text = "Next"
        '
        'tbtnLast
        '
        Me.tbtnLast.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tbtnLast.Image = CType(resources.GetObject("tbtnLast.Image"), System.Drawing.Image)
        Me.tbtnLast.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbtnLast.Name = "tbtnLast"
        Me.tbtnLast.Size = New System.Drawing.Size(23, 22)
        Me.tbtnLast.Text = "Last"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'uiBase
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Controls.Add(Me.ToolStrip1)
        Me.MinimumSize = New System.Drawing.Size(755, 550)
        Me.Name = "uiBase"
        Me.Size = New System.Drawing.Size(755, 550)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tbtnNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents tbtnSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tbtnEdit As System.Windows.Forms.ToolStripButton
    Friend WithEvents tbtnDel As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tbtnLoad As System.Windows.Forms.ToolStripButton
    Friend WithEvents tbtnQuery As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tbtnFirst As System.Windows.Forms.ToolStripButton
    Friend WithEvents tbtnPrev As System.Windows.Forms.ToolStripButton
    Friend WithEvents tbtnNext As System.Windows.Forms.ToolStripButton
    Friend WithEvents tbtnLast As System.Windows.Forms.ToolStripButton
    Friend WithEvents tbtnPrint As System.Windows.Forms.ToolStripButton
    Friend WithEvents tbtnPrintPreview As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tbtnRefresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator

End Class
