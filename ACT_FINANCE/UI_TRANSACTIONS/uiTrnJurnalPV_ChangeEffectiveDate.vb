Imports Microsoft.Win32
Imports System.Threading
Imports System.ComponentModel
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo

Public Class uiTrnJurnalPV_ChangeEffectiveDate
    Private Const mUiName As String = "Transaksi Jurnal PV - Change Effective Date"
    Private Const SHOW_SAVE_CONFIRMATION As Boolean = True

    Private Const ConstMyJurnalType As String = "'PV'" 'tambahkan jika ada jurnal lain
    Private tbl_JurnalPVEffectiveDate As DataTable = CreateTblTrnJurnal()
    Private tbl_MstBankACC As DataTable = New DataTable
    Private tbl_PaymentType As DataTable = New DataTable
    Private tbl_MstAccCaName As DataTable = New DataTable


#Region " Window Parameter "
    Private _CHANNEL As String = "TAS"
    Private _CHANNEL_CANBE_CHANGED As Boolean = False
    Private _CHANNEL_CANBE_BROWSED As Boolean = False

    ' TODO: Buat variabel untuk menampung parameter window 
    Private _USER_TYPE As String = "SPV"  'SPV 'STAFF
#End Region

#Region " Overrides "
    Public Overrides Function btnQuery_Click() As Boolean
        Me.pnlSearch.Visible = Not Me.pnlSearch.Visible
        If Me.pnlSearch.Visible Then
            Me.tbtnQuery.Checked = CheckState.Checked
        Else
            Me.tbtnQuery.Checked = CheckState.Unchecked
        End If
        Return MyBase.btnQuery_Click()
    End Function

    Public Overrides Function btnLoad_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnJurnal_PV_Retrieve()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnLoad_Click()
    End Function
#End Region
    Private Function CreateTblTrnJurnal() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("jurnal_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("jurnaldetil_line", GetType(System.Int64)))
        tbl.Columns.Add(New DataColumn("jurnalbilyet_no", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("jurnalbilyet_date", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("jurnalbilyet_dateeffective", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("jurnalbilyet_bank", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("bankacc_name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("currency_id", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("currency_shortname", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("currency_name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("paymenttype_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("paymenttype_name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("jurnaldetil_foreign", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("jurnaldetil_foreignrate", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("jurnaldetil_idr", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("region_id", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("acc_ca_name", GetType(System.String)))


        tbl.Columns("jurnal_id").DefaultValue = String.Empty
        tbl.Columns("jurnaldetil_line").DefaultValue = 0
        tbl.Columns("jurnalbilyet_no").DefaultValue = String.Empty
        tbl.Columns("jurnalbilyet_date").DefaultValue = DBNull.Value
        tbl.Columns("jurnalbilyet_dateeffective").DefaultValue = DBNull.Value
        tbl.Columns("jurnalbilyet_bank").DefaultValue = 0
        tbl.Columns("bankacc_name").DefaultValue = String.Empty

        tbl.Columns("currency_id").DefaultValue = 0
        tbl.Columns("currency_shortname").DefaultValue = String.Empty
        tbl.Columns("currency_name").DefaultValue = String.Empty

        tbl.Columns("paymenttype_id").DefaultValue = String.Empty
        tbl.Columns("paymenttype_name").DefaultValue = String.Empty

        tbl.Columns("jurnaldetil_foreign").DefaultValue = 0
        tbl.Columns("jurnaldetil_foreignrate").DefaultValue = 1
        tbl.Columns("jurnaldetil_idr").DefaultValue = 0

        tbl.Columns("region_id").DefaultValue = 0
        tbl.Columns("acc_ca_name").DefaultValue = String.Empty

        Return tbl
    End Function

    Private Function uiTrnJurnal_PV_Retrieve() As Boolean
        Dim criteria As String = String.Empty

        If Me.ceJurnal_ID.CheckState = CheckState.Checked Then
            criteria = IIf(criteria <> String.Empty, criteria & " AND " & String.Format("jurnal_id IN ({0})", clsUtil.RefParser_ari(Me.txtPVID)), _
                           String.Format("jurnal_id IN ({0})", clsUtil.RefParser_ari(Me.txtPVID)))
        End If

        If Me.ceEffectiveDate.CheckState = CheckState.Checked Then
            Dim format As String = "yyyy-MM-dd"
            Dim date1x As String = CDate(Me.de1.EditValue.ToString()).ToString(format)
            Dim date2x As String = CDate(Me.de2.EditValue.ToString()).ToString(format)

            criteria = IIf(criteria <> String.Empty, _
                           criteria & " AND " & String.Format("jurnalbilyet_dateeffective BETWEEN '{0}' AND '{1}'", date1x, date2x), _
                           String.Format("jurnalbilyet_dateeffective BETWEEN '{0}' AND '{1}'", date1x, date2x))
        End If

        If Me.ceBankName.CheckState = CheckState.Checked Then
            criteria = IIf(criteria <> String.Empty, _
                           criteria & " AND " & String.Format("jurnalbilyet_bank = '{0}'", Me.lueBankName.EditValue), _
                           String.Format("jurnalbilyet_bank = '{0}'", Me.lueBankName.EditValue))
        End If

        criteria = IIf(criteria <> String.Empty, criteria + " AND " + String.Format("channel_id = '{0}'", Me._CHANNEL), String.Format("channel_id = '{0}'", Me._CHANNEL))

        Me.tbl_JurnalPVEffectiveDate.Clear()

        Try
            Me.DataFill(Me.tbl_JurnalPVEffectiveDate, "act_TrnPVEffectiveDate_Select", criteria)
            Me.gcJurnalEffectiveDate.DataSource = Me.tbl_JurnalPVEffectiveDate
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Public Sub Form_Load(ByVal sender As Object)
        Dim objParameters As Collection = New Collection

        If Me.Browser IsNot Nothing Then
            objParameters = Me.GetParameterCollection(Me.Parameter)
            Me._CHANNEL = Me.GetValueFromParameter(objParameters, "CHANNEL") 'Me.GetValueFromParameter(objParameters, "CHANNEL")
            Me._CHANNEL_CANBE_CHANGED = False 'Me.GetBolValueFromParameter(objParameters, "CHANNELCHANGED")
            Me._CHANNEL_CANBE_BROWSED = False 'Me.GetBolValueFromParameter(objParameters, "CHANNELBROWSED")
            ' Me._SOURCE = Me.GetValueFromParameter(objParameters, "SOURCE")
            Me._USER_TYPE = Me.GetValueFromParameter(objParameters, "USERTYPE")
        End If

        If (Me.Browser IsNot Nothing And MyBase.Name = _Name) Or (Me.Browser Is Nothing And Application.ProductName <> _ProductName) Then
            Me.pnlSearch.Visible = False
            Me.DataFill(Me.tbl_MstBankACC, "ms_MstBankacc_Select", "bankacc_active = 1")
            Me.DataFill(Me.tbl_MstAccCaName, "ms_MstAcc_ca_Select", "acc_ca_active = 1")
            Me.ComboFillDXFromDataTable(Me.lueBankName, "bankacc_id", "bankacc_name", Me.tbl_MstBankACC)

            Me.DataFill(Me.tbl_PaymentType, "ms_MstPaymenttype_Select", "")

            Me.gcJurnalEffectiveDate.DataSource = Me.tbl_JurnalPVEffectiveDate

            Me.tbtnNew.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            Me.tbtnSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            Me.tbtnPrint.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            Me.tbtnPrintPreview.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            Me.tbtnDel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            Me.tbtnPosting.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            Me.tbtnUnposting.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        End If
    End Sub

    Private Sub uiTrnJurnalPV_ChangeEffectiveDate_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Me.IsDevelopment = True Then Me.Form_Load(sender)
    End Sub

    Private Sub gvJurnalEffectiveDate_DoubleClick(ByVal sender As Object, ByVal e As EventArgs) Handles gvJurnalEffectiveDate.DoubleClick
        Dim view As GridView = CType(sender, GridView)
        Dim pt As Point = view.GridControl.PointToClient(Control.MousePosition)
        DoRowDoubleClick(view, pt)
    End Sub

    Private Sub DoRowDoubleClick(ByVal view As GridView, ByVal pt As Point)
        Dim info As GridHitInfo = view.CalcHitInfo(pt)
        If info.InRow OrElse info.InRowCell Then
            Dim tblSelected As DataTable = Nothing
            Dim tblReturn As DataTable = Nothing
            Dim jurnal_id As String = view.GetRowCellValue(view.FocusedRowHandle, "jurnal_id").ToString
            Dim jurnaldetil_line As Integer = view.GetRowCellValue(view.FocusedRowHandle, "jurnaldetil_line")
            Dim criteria As String = String.Format("jurnal_id = '{0}' AND jurnaldetil_line = {1}", jurnal_id, jurnaldetil_line)
            tblSelected = Me.tbl_JurnalPVEffectiveDate.Select(criteria, "").CopyToDataTable            

            Dim dlg As dlgChangeEffectiveDate = New dlgChangeEffectiveDate(Me.DSNFrm, tblSelected, tbl_PaymentType, Me.tbl_MstBankACC, Me.tbl_MstAccCaName, Me._CHANNEL)
            Dim retObj As Object
            Dim retData As Collection

            retObj = dlg.OpenDialog(Me)

            If retObj IsNot Nothing Then
                retData = CType(retObj, Collection)
                tblReturn = CType(retData.Item("tbl_JurnalPVEffectiveDate"), DataTable)

                If tblReturn.Rows.Count > 0 Then
                    For i As Integer = 0 To (tblReturn.Rows.Count - 1)
                        For n As Integer = 0 To (Me.tbl_JurnalPVEffectiveDate.Rows.Count - 1)
                            If (tblReturn.Rows(i).Item("jurnal_id").ToString = Me.tbl_JurnalPVEffectiveDate.Rows(n).Item("jurnal_id").ToString) And _
                                (tblReturn.Rows(i).Item("jurnaldetil_line").ToString = Me.tbl_JurnalPVEffectiveDate.Rows(n).Item("jurnaldetil_line").ToString) Then

                                Me.tbl_JurnalPVEffectiveDate.Rows(n).Item("jurnalbilyet_no") = tblReturn.Rows(i).Item("jurnalbilyet_no")
                                Me.tbl_JurnalPVEffectiveDate.Rows(n).Item("jurnalbilyet_dateeffective") = tblReturn.Rows(i).Item("jurnalbilyet_dateeffective")
                            End If
                        Next
                    Next

                    Me.tbl_JurnalPVEffectiveDate.AcceptChanges()
                End If
            End If
        End If
    End Sub
End Class

