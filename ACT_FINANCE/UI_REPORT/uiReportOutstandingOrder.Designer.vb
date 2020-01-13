<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class uiReportOutstandingOrder
    Inherits ACT_FINANCE.uiBase2

    'UserControl overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(uiReportOutstandingOrder))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.btnExportXLS = New DevExpress.XtraEditors.SimpleButton()
        Me.lbEndData = New DevExpress.XtraEditors.LabelControl()
        Me.lbStartDate = New DevExpress.XtraEditors.LabelControl()
        Me.deDate2 = New DevExpress.XtraEditors.DateEdit()
        Me.deDate1 = New DevExpress.XtraEditors.DateEdit()
        Me.btnLoadData = New DevExpress.XtraEditors.SimpleButton()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.AdvBandedGridView1 = New DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView()
        Me.colOrderID = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.coldeptname = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colDesc = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colamountorder = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colrvstatus = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colpvadvance = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colamountpvadv = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colpvap = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colamountpvap = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.coloutstanding = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn1 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand6 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.gridBand7 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.gridBand8 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.gridBand9 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.gridBand10 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.deDate2.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deDate2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deDate1.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deDate1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AdvBandedGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.btnExportXLS)
        Me.PanelControl1.Controls.Add(Me.lbEndData)
        Me.PanelControl1.Controls.Add(Me.lbStartDate)
        Me.PanelControl1.Controls.Add(Me.deDate2)
        Me.PanelControl1.Controls.Add(Me.deDate1)
        Me.PanelControl1.Controls.Add(Me.btnLoadData)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 26)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(881, 92)
        Me.PanelControl1.TabIndex = 4
        '
        'btnExportXLS
        '
        Me.btnExportXLS.Location = New System.Drawing.Point(167, 61)
        Me.btnExportXLS.Name = "btnExportXLS"
        Me.btnExportXLS.Size = New System.Drawing.Size(87, 23)
        Me.btnExportXLS.TabIndex = 7
        Me.btnExportXLS.Text = "Export To Excel"
        '
        'lbEndData
        '
        Me.lbEndData.Location = New System.Drawing.Point(15, 38)
        Me.lbEndData.Name = "lbEndData"
        Me.lbEndData.Size = New System.Drawing.Size(44, 13)
        Me.lbEndData.TabIndex = 6
        Me.lbEndData.Text = "End Date"
        '
        'lbStartDate
        '
        Me.lbStartDate.Location = New System.Drawing.Point(15, 12)
        Me.lbStartDate.Name = "lbStartDate"
        Me.lbStartDate.Size = New System.Drawing.Size(50, 13)
        Me.lbStartDate.TabIndex = 5
        Me.lbStartDate.Text = "Start Date"
        '
        'deDate2
        '
        Me.deDate2.EditValue = Nothing
        Me.deDate2.Location = New System.Drawing.Point(86, 35)
        Me.deDate2.Name = "deDate2"
        Me.deDate2.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.deDate2.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.deDate2.Size = New System.Drawing.Size(100, 20)
        Me.deDate2.TabIndex = 4
        '
        'deDate1
        '
        Me.deDate1.EditValue = Nothing
        Me.deDate1.Location = New System.Drawing.Point(86, 9)
        Me.deDate1.Name = "deDate1"
        Me.deDate1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.deDate1.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.deDate1.Size = New System.Drawing.Size(100, 20)
        Me.deDate1.TabIndex = 3
        '
        'btnLoadData
        '
        Me.btnLoadData.Location = New System.Drawing.Point(86, 61)
        Me.btnLoadData.Name = "btnLoadData"
        Me.btnLoadData.Size = New System.Drawing.Size(75, 23)
        Me.btnLoadData.TabIndex = 0
        Me.btnLoadData.Text = "Load Data"
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Location = New System.Drawing.Point(2, 158)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(597, 270)
        Me.ReportViewer1.TabIndex = 0
        Me.ReportViewer1.Visible = False
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.GridControl1)
        Me.PanelControl2.Controls.Add(Me.ReportViewer1)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelControl2.Location = New System.Drawing.Point(0, 118)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(881, 430)
        Me.PanelControl2.TabIndex = 5
        '
        'GridControl1
        '
        Me.GridControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl1.Location = New System.Drawing.Point(2, 2)
        Me.GridControl1.MainView = Me.AdvBandedGridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(877, 426)
        Me.GridControl1.TabIndex = 1
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.AdvBandedGridView1})
        '
        'AdvBandedGridView1
        '
        Me.AdvBandedGridView1.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.gridBand6, Me.gridBand7, Me.gridBand8, Me.gridBand9, Me.gridBand10})
        Me.AdvBandedGridView1.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.colOrderID, Me.coldeptname, Me.colDesc, Me.colamountorder, Me.colrvstatus, Me.colpvadvance, Me.colamountpvadv, Me.colpvap, Me.colamountpvap, Me.coloutstanding})
        Me.AdvBandedGridView1.GridControl = Me.GridControl1
        Me.AdvBandedGridView1.Name = "AdvBandedGridView1"
        Me.AdvBandedGridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.AdvBandedGridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.AdvBandedGridView1.OptionsBehavior.Editable = False
        Me.AdvBandedGridView1.OptionsBehavior.ReadOnly = True
        Me.AdvBandedGridView1.OptionsView.ShowGroupPanel = False
        '
        'colOrderID
        '
        Me.colOrderID.Caption = "Ref."
        Me.colOrderID.FieldName = "order_id"
        Me.colOrderID.Name = "colOrderID"
        Me.colOrderID.Visible = True
        Me.colOrderID.Width = 94
        '
        'coldeptname
        '
        Me.coldeptname.Caption = "Dept. Related"
        Me.coldeptname.FieldName = "strukturunit_name"
        Me.coldeptname.Name = "coldeptname"
        Me.coldeptname.Visible = True
        Me.coldeptname.Width = 121
        '
        'colDesc
        '
        Me.colDesc.Caption = "Description"
        Me.colDesc.FieldName = "order_descr"
        Me.colDesc.Name = "colDesc"
        Me.colDesc.Visible = True
        Me.colDesc.Width = 131
        '
        'colamountorder
        '
        Me.colamountorder.Caption = "Amount"
        Me.colamountorder.DisplayFormat.FormatString = "n0"
        Me.colamountorder.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colamountorder.FieldName = "amount_order"
        Me.colamountorder.Name = "colamountorder"
        Me.colamountorder.Visible = True
        Me.colamountorder.Width = 82
        '
        'colrvstatus
        '
        Me.colrvstatus.AppearanceHeader.Options.UseTextOptions = True
        Me.colrvstatus.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colrvstatus.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top
        Me.colrvstatus.Caption = "Status"
        Me.colrvstatus.FieldName = "rv_status"
        Me.colrvstatus.Name = "colrvstatus"
        Me.colrvstatus.Visible = True
        '
        'colpvadvance
        '
        Me.colpvadvance.Caption = "Ref."
        Me.colpvadvance.Name = "colpvadvance"
        Me.colpvadvance.Visible = True
        Me.colpvadvance.Width = 86
        '
        'colamountpvadv
        '
        Me.colamountpvadv.Caption = "Amount"
        Me.colamountpvadv.DisplayFormat.FormatString = "n0"
        Me.colamountpvadv.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colamountpvadv.FieldName = "amount_pv_advance"
        Me.colamountpvadv.Name = "colamountpvadv"
        Me.colamountpvadv.Visible = True
        Me.colamountpvadv.Width = 93
        '
        'colpvap
        '
        Me.colpvap.Caption = "Ref."
        Me.colpvap.FieldName = "pv_ap"
        Me.colpvap.Name = "colpvap"
        Me.colpvap.Visible = True
        Me.colpvap.Width = 83
        '
        'colamountpvap
        '
        Me.colamountpvap.Caption = "Amount"
        Me.colamountpvap.DisplayFormat.FormatString = "n0"
        Me.colamountpvap.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colamountpvap.FieldName = "amount_pv_ap"
        Me.colamountpvap.Name = "colamountpvap"
        Me.colamountpvap.Visible = True
        Me.colamountpvap.Width = 85
        '
        'coloutstanding
        '
        Me.coloutstanding.AppearanceHeader.Options.UseTextOptions = True
        Me.coloutstanding.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.coloutstanding.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top
        Me.coloutstanding.Caption = "Amount Capex"
        Me.coloutstanding.DisplayFormat.FormatString = "n0"
        Me.coloutstanding.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.coloutstanding.FieldName = "outstanding"
        Me.coloutstanding.Name = "coloutstanding"
        Me.coloutstanding.Visible = True
        Me.coloutstanding.Width = 113
        '
        'BandedGridColumn1
        '
        Me.BandedGridColumn1.Name = "BandedGridColumn1"
        '
        'gridBand6
        '
        Me.gridBand6.AppearanceHeader.Options.UseTextOptions = True
        Me.gridBand6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gridBand6.Caption = "Purchase Order"
        Me.gridBand6.Columns.Add(Me.colOrderID)
        Me.gridBand6.Columns.Add(Me.coldeptname)
        Me.gridBand6.Columns.Add(Me.colDesc)
        Me.gridBand6.Columns.Add(Me.colamountorder)
        Me.gridBand6.Name = "gridBand6"
        Me.gridBand6.Width = 428
        '
        'gridBand7
        '
        Me.gridBand7.AppearanceHeader.Options.UseTextOptions = True
        Me.gridBand7.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gridBand7.Caption = "RV"
        Me.gridBand7.Columns.Add(Me.colrvstatus)
        Me.gridBand7.Name = "gridBand7"
        Me.gridBand7.Width = 75
        '
        'gridBand8
        '
        Me.gridBand8.AppearanceHeader.Options.UseTextOptions = True
        Me.gridBand8.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gridBand8.Caption = "PV Advance List Order"
        Me.gridBand8.Columns.Add(Me.colpvadvance)
        Me.gridBand8.Columns.Add(Me.colamountpvadv)
        Me.gridBand8.Name = "gridBand8"
        Me.gridBand8.Width = 179
        '
        'gridBand9
        '
        Me.gridBand9.AppearanceHeader.Options.UseTextOptions = True
        Me.gridBand9.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gridBand9.Caption = "PV List AP"
        Me.gridBand9.Columns.Add(Me.colpvap)
        Me.gridBand9.Columns.Add(Me.colamountpvap)
        Me.gridBand9.Name = "gridBand9"
        Me.gridBand9.Width = 168
        '
        'gridBand10
        '
        Me.gridBand10.AppearanceHeader.Options.UseTextOptions = True
        Me.gridBand10.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gridBand10.Caption = "Outstanding"
        Me.gridBand10.Columns.Add(Me.coloutstanding)
        Me.gridBand10.Name = "gridBand10"
        Me.gridBand10.Width = 113
        '
        'uiReportOutstandingOrder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.PanelControl2)
        Me.Controls.Add(Me.PanelControl1)
        Me.Name = "uiReportOutstandingOrder"
        Me.Controls.SetChildIndex(Me.PanelControl1, 0)
        Me.Controls.SetChildIndex(Me.PanelControl2, 0)
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.deDate2.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deDate2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deDate1.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deDate1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AdvBandedGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents btnLoadData As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents deDate2 As DevExpress.XtraEditors.DateEdit
    Friend WithEvents deDate1 As DevExpress.XtraEditors.DateEdit
    Friend WithEvents lbEndData As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lbStartDate As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnExportXLS As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents AdvBandedGridView1 As DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView
    Friend WithEvents colOrderID As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents coldeptname As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colDesc As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colamountorder As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colrvstatus As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colpvadvance As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colamountpvadv As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colpvap As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colamountpvap As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents coloutstanding As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn1 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents gridBand6 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand7 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand8 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand9 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand10 As DevExpress.XtraGrid.Views.BandedGrid.GridBand

End Class
