<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DlgAdvanceDisbursement_History
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
        Me.GCLogHistory = New DevExpress.XtraGrid.GridControl()
        Me.GVLogHistory = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colLogEvent = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colLogDescr = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colLogUserBy = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colLogUserDt = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.GCLogHistory, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVLogHistory, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GCLogHistory
        '
        Me.GCLogHistory.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCLogHistory.Location = New System.Drawing.Point(3, 3)
        Me.GCLogHistory.MainView = Me.GVLogHistory
        Me.GCLogHistory.Name = "GCLogHistory"
        Me.GCLogHistory.Size = New System.Drawing.Size(831, 396)
        Me.GCLogHistory.TabIndex = 0
        Me.GCLogHistory.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVLogHistory})
        '
        'GVLogHistory
        '
        Me.GVLogHistory.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colID, Me.colLogEvent, Me.colLogDescr, Me.colLogUserBy, Me.colLogUserDt})
        Me.GVLogHistory.GridControl = Me.GCLogHistory
        Me.GVLogHistory.Name = "GVLogHistory"
        Me.GVLogHistory.OptionsBehavior.Editable = False
        Me.GVLogHistory.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GVLogHistory.OptionsSelection.EnableAppearanceFocusedRow = False
        Me.GVLogHistory.OptionsSelection.EnableAppearanceHideSelection = False
        Me.GVLogHistory.OptionsView.ShowGroupPanel = False
        Me.GVLogHistory.OptionsView.ShowViewCaption = True
        Me.GVLogHistory.ViewCaption = "Log History"
        '
        'colID
        '
        Me.colID.Caption = "ID"
        Me.colID.FieldName = "log_id"
        Me.colID.Name = "colID"
        Me.colID.OptionsColumn.FixedWidth = True
        Me.colID.Visible = True
        Me.colID.VisibleIndex = 0
        Me.colID.Width = 50
        '
        'colLogEvent
        '
        Me.colLogEvent.Caption = "Event"
        Me.colLogEvent.FieldName = "log_event"
        Me.colLogEvent.Name = "colLogEvent"
        Me.colLogEvent.OptionsColumn.FixedWidth = True
        Me.colLogEvent.Visible = True
        Me.colLogEvent.VisibleIndex = 1
        Me.colLogEvent.Width = 120
        '
        'colLogDescr
        '
        Me.colLogDescr.Caption = "Description"
        Me.colLogDescr.FieldName = "log_descr"
        Me.colLogDescr.Name = "colLogDescr"
        Me.colLogDescr.Visible = True
        Me.colLogDescr.VisibleIndex = 2
        '
        'colLogUserBy
        '
        Me.colLogUserBy.Caption = "Log Create By"
        Me.colLogUserBy.FieldName = "log_userby"
        Me.colLogUserBy.Name = "colLogUserBy"
        Me.colLogUserBy.OptionsColumn.FixedWidth = True
        Me.colLogUserBy.Visible = True
        Me.colLogUserBy.VisibleIndex = 3
        Me.colLogUserBy.Width = 150
        '
        'colLogUserDt
        '
        Me.colLogUserDt.Caption = "Log Create Date"
        Me.colLogUserDt.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"
        Me.colLogUserDt.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.colLogUserDt.FieldName = "log_userdt"
        Me.colLogUserDt.Name = "colLogUserDt"
        Me.colLogUserDt.OptionsColumn.FixedWidth = True
        Me.colLogUserDt.Visible = True
        Me.colLogUserDt.VisibleIndex = 4
        Me.colLogUserDt.Width = 120
        '
        'DlgAdvanceDisbursement_History
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(837, 402)
        Me.Controls.Add(Me.GCLogHistory)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DlgAdvanceDisbursement_History"
        Me.Padding = New System.Windows.Forms.Padding(3)
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Log History"
        CType(Me.GCLogHistory, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVLogHistory, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GCLogHistory As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVLogHistory As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colLogEvent As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colLogDescr As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colLogUserBy As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colLogUserDt As DevExpress.XtraGrid.Columns.GridColumn

End Class
