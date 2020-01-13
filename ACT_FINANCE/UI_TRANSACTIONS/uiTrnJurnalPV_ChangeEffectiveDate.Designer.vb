<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class uiTrnJurnalPV_ChangeEffectiveDate
    Inherits uiBase2

    'UserControl overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(uiTrnJurnalPV_ChangeEffectiveDate))
        Me.xTabMainList = New DevExpress.XtraTab.XtraTabControl()
        Me.XtraTabPage1 = New DevExpress.XtraTab.XtraTabPage()
        Me.gcJurnalEffectiveDate = New DevExpress.XtraGrid.GridControl()
        Me.gvJurnalEffectiveDate = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colJurnalId = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colJurnalDetilLine = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colRegionID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAccCaName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colJurnalBilyetNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDateEffective = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colJurnalBilyetBank = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colBankAccName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colPaymentID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colPaymenTypeName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCurrencyID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCurrencyShortName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCurrencyName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colJurnalDetilForeign = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colJurnalDetilForeignRate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colJurnalDetilIDR = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colChannelID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.pnlBottom = New DevExpress.XtraEditors.PanelControl()
        Me.pnlSearch = New DevExpress.XtraEditors.PanelControl()
        Me.lueBankName = New DevExpress.XtraEditors.LookUpEdit()
        Me.txtPVID = New System.Windows.Forms.TextBox()
        Me.ceBankName = New DevExpress.XtraEditors.CheckEdit()
        Me.ceEffectiveDate = New DevExpress.XtraEditors.CheckEdit()
        Me.ceJurnal_ID = New DevExpress.XtraEditors.CheckEdit()
        Me.de2 = New DevExpress.XtraEditors.DateEdit()
        Me.lbTo = New DevExpress.XtraEditors.LabelControl()
        Me.de1 = New DevExpress.XtraEditors.DateEdit()
        CType(Me.xTabMainList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.xTabMainList.SuspendLayout()
        Me.XtraTabPage1.SuspendLayout()
        CType(Me.gcJurnalEffectiveDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvJurnalEffectiveDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlBottom, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlSearch, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlSearch.SuspendLayout()
        CType(Me.lueBankName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ceBankName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ceEffectiveDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ceJurnal_ID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.de2.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.de2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.de1.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.de1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'xTabMainList
        '
        Me.xTabMainList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.xTabMainList.Location = New System.Drawing.Point(0, 26)
        Me.xTabMainList.Name = "xTabMainList"
        Me.xTabMainList.SelectedTabPage = Me.XtraTabPage1
        Me.xTabMainList.Size = New System.Drawing.Size(881, 522)
        Me.xTabMainList.TabIndex = 4
        Me.xTabMainList.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XtraTabPage1})
        '
        'XtraTabPage1
        '
        Me.XtraTabPage1.Controls.Add(Me.gcJurnalEffectiveDate)
        Me.XtraTabPage1.Controls.Add(Me.pnlBottom)
        Me.XtraTabPage1.Controls.Add(Me.pnlSearch)
        Me.XtraTabPage1.Name = "XtraTabPage1"
        Me.XtraTabPage1.Size = New System.Drawing.Size(876, 497)
        Me.XtraTabPage1.Text = "List Data"
        '
        'gcJurnalEffectiveDate
        '
        Me.gcJurnalEffectiveDate.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gcJurnalEffectiveDate.Location = New System.Drawing.Point(0, 128)
        Me.gcJurnalEffectiveDate.MainView = Me.gvJurnalEffectiveDate
        Me.gcJurnalEffectiveDate.Name = "gcJurnalEffectiveDate"
        Me.gcJurnalEffectiveDate.Size = New System.Drawing.Size(876, 329)
        Me.gcJurnalEffectiveDate.TabIndex = 2
        Me.gcJurnalEffectiveDate.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvJurnalEffectiveDate})
        '
        'gvJurnalEffectiveDate
        '
        Me.gvJurnalEffectiveDate.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colJurnalId, Me.colJurnalDetilLine, Me.colRegionID, Me.colAccCaName, Me.colJurnalBilyetNo, Me.colDateEffective, Me.colJurnalBilyetBank, Me.colBankAccName, Me.colPaymentID, Me.colPaymenTypeName, Me.colCurrencyID, Me.colCurrencyShortName, Me.colCurrencyName, Me.colJurnalDetilForeign, Me.colJurnalDetilForeignRate, Me.colJurnalDetilIDR, Me.colChannelID})
        Me.gvJurnalEffectiveDate.GridControl = Me.gcJurnalEffectiveDate
        Me.gvJurnalEffectiveDate.Name = "gvJurnalEffectiveDate"
        Me.gvJurnalEffectiveDate.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.gvJurnalEffectiveDate.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.gvJurnalEffectiveDate.OptionsBehavior.Editable = False
        Me.gvJurnalEffectiveDate.OptionsBehavior.ReadOnly = True
        Me.gvJurnalEffectiveDate.OptionsView.ColumnAutoWidth = False
        Me.gvJurnalEffectiveDate.OptionsView.ShowGroupPanel = False
        '
        'colJurnalId
        '
        Me.colJurnalId.Caption = "Jurnal ID"
        Me.colJurnalId.FieldName = "jurnal_id"
        Me.colJurnalId.Name = "colJurnalId"
        Me.colJurnalId.Visible = True
        Me.colJurnalId.VisibleIndex = 0
        Me.colJurnalId.Width = 100
        '
        'colJurnalDetilLine
        '
        Me.colJurnalDetilLine.Caption = "Line"
        Me.colJurnalDetilLine.FieldName = "jurnaldetil_line"
        Me.colJurnalDetilLine.Name = "colJurnalDetilLine"
        Me.colJurnalDetilLine.Visible = True
        Me.colJurnalDetilLine.VisibleIndex = 1
        '
        'colRegionID
        '
        Me.colRegionID.Caption = "Acc. Ca ID"
        Me.colRegionID.FieldName = "region_id"
        Me.colRegionID.Name = "colRegionID"
        Me.colRegionID.Visible = True
        Me.colRegionID.VisibleIndex = 2
        '
        'colAccCaName
        '
        Me.colAccCaName.Caption = "Acc. Ca Name"
        Me.colAccCaName.FieldName = "acc_ca_name"
        Me.colAccCaName.Name = "colAccCaName"
        Me.colAccCaName.Visible = True
        Me.colAccCaName.VisibleIndex = 3
        Me.colAccCaName.Width = 120
        '
        'colJurnalBilyetNo
        '
        Me.colJurnalBilyetNo.Caption = "Bilyet No."
        Me.colJurnalBilyetNo.FieldName = "jurnalbilyet_no"
        Me.colJurnalBilyetNo.Name = "colJurnalBilyetNo"
        Me.colJurnalBilyetNo.Visible = True
        Me.colJurnalBilyetNo.VisibleIndex = 4
        Me.colJurnalBilyetNo.Width = 100
        '
        'colDateEffective
        '
        Me.colDateEffective.Caption = "Effective Date"
        Me.colDateEffective.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.colDateEffective.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.colDateEffective.FieldName = "jurnalbilyet_dateeffective"
        Me.colDateEffective.Name = "colDateEffective"
        Me.colDateEffective.Visible = True
        Me.colDateEffective.VisibleIndex = 5
        Me.colDateEffective.Width = 100
        '
        'colJurnalBilyetBank
        '
        Me.colJurnalBilyetBank.Caption = "Bank Id"
        Me.colJurnalBilyetBank.FieldName = "jurnalbilyet_bank"
        Me.colJurnalBilyetBank.Name = "colJurnalBilyetBank"
        Me.colJurnalBilyetBank.Width = 50
        '
        'colBankAccName
        '
        Me.colBankAccName.Caption = "Bank Name"
        Me.colBankAccName.FieldName = "bankacc_name"
        Me.colBankAccName.Name = "colBankAccName"
        Me.colBankAccName.Visible = True
        Me.colBankAccName.VisibleIndex = 6
        Me.colBankAccName.Width = 140
        '
        'colPaymentID
        '
        Me.colPaymentID.Caption = "Payment Type ID"
        Me.colPaymentID.FieldName = "paymenttype_id"
        Me.colPaymentID.Name = "colPaymentID"
        Me.colPaymentID.Width = 50
        '
        'colPaymenTypeName
        '
        Me.colPaymenTypeName.Caption = "Payment Type"
        Me.colPaymenTypeName.FieldName = "paymenttype_name"
        Me.colPaymenTypeName.Name = "colPaymenTypeName"
        Me.colPaymenTypeName.Visible = True
        Me.colPaymenTypeName.VisibleIndex = 7
        Me.colPaymenTypeName.Width = 100
        '
        'colCurrencyID
        '
        Me.colCurrencyID.Caption = "Currency ID"
        Me.colCurrencyID.FieldName = "currency_id"
        Me.colCurrencyID.Name = "colCurrencyID"
        Me.colCurrencyID.Width = 50
        '
        'colCurrencyShortName
        '
        Me.colCurrencyShortName.Caption = "Currency"
        Me.colCurrencyShortName.FieldName = "currency_shortname"
        Me.colCurrencyShortName.Name = "colCurrencyShortName"
        Me.colCurrencyShortName.Visible = True
        Me.colCurrencyShortName.VisibleIndex = 8
        '
        'colCurrencyName
        '
        Me.colCurrencyName.Caption = "Currency Name"
        Me.colCurrencyName.FieldName = "currency_name"
        Me.colCurrencyName.Name = "colCurrencyName"
        '
        'colJurnalDetilForeign
        '
        Me.colJurnalDetilForeign.Caption = "Amount"
        Me.colJurnalDetilForeign.DisplayFormat.FormatString = "n2"
        Me.colJurnalDetilForeign.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colJurnalDetilForeign.FieldName = "jurnaldetil_foreign"
        Me.colJurnalDetilForeign.Name = "colJurnalDetilForeign"
        Me.colJurnalDetilForeign.Visible = True
        Me.colJurnalDetilForeign.VisibleIndex = 9
        Me.colJurnalDetilForeign.Width = 100
        '
        'colJurnalDetilForeignRate
        '
        Me.colJurnalDetilForeignRate.Caption = "Rate"
        Me.colJurnalDetilForeignRate.DisplayFormat.FormatString = "n2"
        Me.colJurnalDetilForeignRate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colJurnalDetilForeignRate.FieldName = "jurnaldetil_foreignrate"
        Me.colJurnalDetilForeignRate.Name = "colJurnalDetilForeignRate"
        Me.colJurnalDetilForeignRate.Visible = True
        Me.colJurnalDetilForeignRate.VisibleIndex = 10
        '
        'colJurnalDetilIDR
        '
        Me.colJurnalDetilIDR.Caption = "Amount (IDR)"
        Me.colJurnalDetilIDR.DisplayFormat.FormatString = "n2"
        Me.colJurnalDetilIDR.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colJurnalDetilIDR.FieldName = "jurnaldetil_idr"
        Me.colJurnalDetilIDR.Name = "colJurnalDetilIDR"
        Me.colJurnalDetilIDR.Visible = True
        Me.colJurnalDetilIDR.VisibleIndex = 11
        Me.colJurnalDetilIDR.Width = 100
        '
        'colChannelID
        '
        Me.colChannelID.Caption = "Channel ID"
        Me.colChannelID.FieldName = "channel_id"
        Me.colChannelID.Name = "colChannelID"
        '
        'pnlBottom
        '
        Me.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlBottom.Location = New System.Drawing.Point(0, 457)
        Me.pnlBottom.Name = "pnlBottom"
        Me.pnlBottom.Size = New System.Drawing.Size(876, 40)
        Me.pnlBottom.TabIndex = 1
        '
        'pnlSearch
        '
        Me.pnlSearch.Controls.Add(Me.lueBankName)
        Me.pnlSearch.Controls.Add(Me.txtPVID)
        Me.pnlSearch.Controls.Add(Me.ceBankName)
        Me.pnlSearch.Controls.Add(Me.ceEffectiveDate)
        Me.pnlSearch.Controls.Add(Me.ceJurnal_ID)
        Me.pnlSearch.Controls.Add(Me.de2)
        Me.pnlSearch.Controls.Add(Me.lbTo)
        Me.pnlSearch.Controls.Add(Me.de1)
        Me.pnlSearch.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlSearch.Location = New System.Drawing.Point(0, 0)
        Me.pnlSearch.Name = "pnlSearch"
        Me.pnlSearch.Size = New System.Drawing.Size(876, 128)
        Me.pnlSearch.TabIndex = 0
        '
        'lueBankName
        '
        Me.lueBankName.Location = New System.Drawing.Point(424, 37)
        Me.lueBankName.Name = "lueBankName"
        Me.lueBankName.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.lueBankName.Properties.NullText = "-- PILIH --"
        Me.lueBankName.Size = New System.Drawing.Size(227, 20)
        Me.lueBankName.TabIndex = 16
        '
        'txtPVID
        '
        Me.txtPVID.Location = New System.Drawing.Point(73, 9)
        Me.txtPVID.Multiline = True
        Me.txtPVID.Name = "txtPVID"
        Me.txtPVID.Size = New System.Drawing.Size(250, 103)
        Me.txtPVID.TabIndex = 15
        '
        'ceBankName
        '
        Me.ceBankName.Location = New System.Drawing.Point(329, 37)
        Me.ceBankName.Name = "ceBankName"
        Me.ceBankName.Properties.Caption = "Bank Name"
        Me.ceBankName.Size = New System.Drawing.Size(92, 19)
        Me.ceBankName.TabIndex = 12
        '
        'ceEffectiveDate
        '
        Me.ceEffectiveDate.Location = New System.Drawing.Point(329, 9)
        Me.ceEffectiveDate.Name = "ceEffectiveDate"
        Me.ceEffectiveDate.Properties.Caption = "Effective Date"
        Me.ceEffectiveDate.Size = New System.Drawing.Size(92, 19)
        Me.ceEffectiveDate.TabIndex = 11
        '
        'ceJurnal_ID
        '
        Me.ceJurnal_ID.Location = New System.Drawing.Point(2, 10)
        Me.ceJurnal_ID.Name = "ceJurnal_ID"
        Me.ceJurnal_ID.Properties.Caption = "Jurnal ID"
        Me.ceJurnal_ID.Size = New System.Drawing.Size(65, 19)
        Me.ceJurnal_ID.TabIndex = 10
        '
        'de2
        '
        Me.de2.EditValue = Nothing
        Me.de2.Location = New System.Drawing.Point(551, 8)
        Me.de2.Name = "de2"
        Me.de2.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.de2.Properties.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.de2.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.de2.Properties.EditFormat.FormatString = "dd/MM/yyyy"
        Me.de2.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.de2.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.de2.Size = New System.Drawing.Size(100, 20)
        Me.de2.TabIndex = 7
        '
        'lbTo
        '
        Me.lbTo.Location = New System.Drawing.Point(530, 12)
        Me.lbTo.Name = "lbTo"
        Me.lbTo.Size = New System.Drawing.Size(15, 13)
        Me.lbTo.TabIndex = 6
        Me.lbTo.Text = "s/d"
        '
        'de1
        '
        Me.de1.EditValue = Nothing
        Me.de1.Location = New System.Drawing.Point(424, 9)
        Me.de1.Name = "de1"
        Me.de1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.de1.Properties.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.de1.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.de1.Properties.EditFormat.FormatString = "dd/MM/yyyy"
        Me.de1.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.de1.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.de1.Size = New System.Drawing.Size(100, 20)
        Me.de1.TabIndex = 5
        '
        'uiTrnJurnalPV_ChangeEffectiveDate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.xTabMainList)
        Me.Name = "uiTrnJurnalPV_ChangeEffectiveDate"
        Me.Controls.SetChildIndex(Me.xTabMainList, 0)
        CType(Me.xTabMainList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.xTabMainList.ResumeLayout(False)
        Me.XtraTabPage1.ResumeLayout(False)
        CType(Me.gcJurnalEffectiveDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvJurnalEffectiveDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlBottom, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlSearch, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlSearch.ResumeLayout(False)
        Me.pnlSearch.PerformLayout()
        CType(Me.lueBankName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ceBankName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ceEffectiveDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ceJurnal_ID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.de2.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.de2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.de1.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.de1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents xTabMainList As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XtraTabPage1 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents pnlSearch As DevExpress.XtraEditors.PanelControl
    Friend WithEvents de2 As DevExpress.XtraEditors.DateEdit
    Friend WithEvents lbTo As DevExpress.XtraEditors.LabelControl
    Friend WithEvents de1 As DevExpress.XtraEditors.DateEdit
    Friend WithEvents gcJurnalEffectiveDate As DevExpress.XtraGrid.GridControl
    Friend WithEvents gvJurnalEffectiveDate As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents pnlBottom As DevExpress.XtraEditors.PanelControl
    Friend WithEvents ceBankName As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents ceEffectiveDate As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents ceJurnal_ID As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents txtPVID As System.Windows.Forms.TextBox
    Friend WithEvents colJurnalId As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colJurnalDetilLine As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colJurnalBilyetNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDateEffective As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colJurnalBilyetBank As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colBankAccName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colPaymentID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colPaymenTypeName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCurrencyID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCurrencyShortName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCurrencyName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colJurnalDetilForeign As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colJurnalDetilForeignRate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colJurnalDetilIDR As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colChannelID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents lueBankName As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents colRegionID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAccCaName As DevExpress.XtraGrid.Columns.GridColumn

End Class
