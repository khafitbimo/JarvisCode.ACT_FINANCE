<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DlgAdvanceDisbursement_Advance
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
        Me.GCAdvance = New DevExpress.XtraGrid.GridControl()
        Me.GVAdvance = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colAdvanceID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colRekanan = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDescription = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colBudgetName = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.GCAdvance, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVAdvance, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GCAdvance
        '
        Me.GCAdvance.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCAdvance.Location = New System.Drawing.Point(3, 3)
        Me.GCAdvance.MainView = Me.GVAdvance
        Me.GCAdvance.Name = "GCAdvance"
        Me.GCAdvance.Size = New System.Drawing.Size(762, 398)
        Me.GCAdvance.TabIndex = 0
        Me.GCAdvance.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVAdvance})
        '
        'GVAdvance
        '
        Me.GVAdvance.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colAdvanceID, Me.colRekanan, Me.colBudgetName, Me.colDescription})
        Me.GVAdvance.GridControl = Me.GCAdvance
        Me.GVAdvance.Name = "GVAdvance"
        Me.GVAdvance.OptionsSelection.EnableAppearanceFocusedRow = False
        Me.GVAdvance.OptionsSelection.EnableAppearanceHideSelection = False
        Me.GVAdvance.OptionsView.ColumnAutoWidth = False
        Me.GVAdvance.OptionsView.ShowGroupPanel = False
        Me.GVAdvance.OptionsView.ShowViewCaption = True
        Me.GVAdvance.ViewCaption = "Advance"
        '
        'colAdvanceID
        '
        Me.colAdvanceID.Caption = "Advance ID"
        Me.colAdvanceID.FieldName = "advance_id"
        Me.colAdvanceID.Name = "colAdvanceID"
        Me.colAdvanceID.OptionsColumn.AllowEdit = False
        Me.colAdvanceID.OptionsColumn.FixedWidth = True
        Me.colAdvanceID.Visible = True
        Me.colAdvanceID.VisibleIndex = 0
        Me.colAdvanceID.Width = 100
        '
        'colRekanan
        '
        Me.colRekanan.Caption = "Rekanan"
        Me.colRekanan.FieldName = "rekanan_name"
        Me.colRekanan.Name = "colRekanan"
        Me.colRekanan.OptionsColumn.AllowEdit = False
        Me.colRekanan.OptionsColumn.FixedWidth = True
        Me.colRekanan.Visible = True
        Me.colRekanan.VisibleIndex = 1
        Me.colRekanan.Width = 150
        '
        'colDescription
        '
        Me.colDescription.Caption = "Description"
        Me.colDescription.FieldName = "advance_descr"
        Me.colDescription.Name = "colDescription"
        Me.colDescription.OptionsColumn.AllowEdit = False
        Me.colDescription.Visible = True
        Me.colDescription.VisibleIndex = 3
        Me.colDescription.Width = 250
        '
        'colBudgetName
        '
        Me.colBudgetName.Caption = "Budget Name"
        Me.colBudgetName.FieldName = "budget_name"
        Me.colBudgetName.Name = "colBudgetName"
        Me.colBudgetName.Visible = True
        Me.colBudgetName.VisibleIndex = 2
        Me.colBudgetName.Width = 200
        '
        'DlgAdvanceDisbursement_Advance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(768, 404)
        Me.Controls.Add(Me.GCAdvance)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DlgAdvanceDisbursement_Advance"
        Me.Padding = New System.Windows.Forms.Padding(3)
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Advance"
        CType(Me.GCAdvance, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVAdvance, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GCAdvance As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVAdvance As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colAdvanceID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDescription As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colRekanan As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colBudgetName As DevExpress.XtraGrid.Columns.GridColumn

End Class
