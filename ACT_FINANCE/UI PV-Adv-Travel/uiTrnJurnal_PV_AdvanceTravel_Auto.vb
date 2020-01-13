Imports System.Threading
Imports System.ComponentModel

Public Class uiTrnJurnal_PV_AdvanceTravel_Auto
    Implements ILocking
    Private Const mUiName As String = "Transaksi Advance List Order"
    Private Const SHOW_SAVE_CONFIRMATION As Boolean = True

    Private Const ConstMyJurnalType As String = "PV"
    Private ConstMyJurnalSource As String = clsSource.PVListTravel

    Private Event FormBeforeOpenRow(ByRef id As Object)
    Private Event FormAfterOpenRow(ByRef id As Object)
    Private Event FormBeforeSave(ByRef id As Object)
    Private Event FormAfterSave(ByRef id As Object, ByVal result As FormSaveResult)
    Private Event FormBeforeNew()
    Private Event FormBeforeDelete(ByRef id As Object)
    Private Event FormAfterDelete(ByRef id As Object)

    Private FILTER_QUERY_MODE As Boolean
    Private DATA_ISLOCKED As Boolean
    Private DATADETIL_OPENED As Boolean

    Private objFormError As Windows.Forms.ErrorProvider = New Windows.Forms.ErrorProvider

    Private tbl_TrnAdvance As DataTable = CreateTblTrnAdvance()
    Private tbl_TrnAdvance_Temp As DataTable = clsDataset.CreateTblTrnAdvance()

    Private tbl_TrnAdvanceDetil As DataTable = clsDataset.CreateTblTrnAdvancedetil()
    Private tbl_TrnAdvanceItemDetil As DataTable = clsDataset.CreateTblTrnAdvanceItemDetilListOrder()
    Private tbl_PrintAdvanceListOrderDetil As DataTable = clsDataset.CreateTblTrnPrintAdvanceListOrder()
    Private tbl_Advancedetileps As DataTable = clsDataset.CreateTblTrnAdvanceItemDetilEps()
    Private tbl_TrnAdvanceRefPV As DataTable = clsDataset.CreateTblTrnAdvanceRefPV()

    Private tbl_MstStrukturunit As DataTable = clsDataset.CreateTblMstStrukturunit()
    Private tbl_MstStrukturunit_dest As DataTable = clsDataset.CreateTblMstStrukturunit()
    Private tbl_MstStrukturunitSrch As DataTable = clsDataset.CreateTblMstStrukturunit()

    Private tbl_TrnBudget As DataTable = clsDataset.CreateTblTrnBudgetCombo()
    Private tbl_TrnBudgetMain As DataTable = clsDataset.CreateTblTrnBudgetCombo()
    Private tbl_TrnBudgetSearch As DataTable = clsDataset.CreateTblTrnBudgetCombo()

    Private tbl_MstRekanan As DataTable = clsDataset.CreateTblMstrekananCombo()
    Private tbl_RekananUseBy As DataTable = clsDataset.CreateTblMstrekananCombo()

    Private tbl_MstCurrencyHeader As DataTable = clsDataset.CreateTblMstCurrency()
    Private tbl_MstCurrencyDetil As DataTable = clsDataset.CreateTblMstCurrency()
   
    Private tbl_Trnrequestdetil_type As DataTable = New DataTable

    Private tbl_MstPaymentType As DataTable = clsDataset.CreateTblMstPaymenttype()
    Private tbl_MstPaymentTypeGrid As DataTable = clsDataset.CreateTblMstPaymenttype()

    Private tbl_MstAcc As DataTable = clsDataset.CreateTblMstAccountCombo()

    Private tbl_MstChannel As DataTable = clsDataset.CreateTblMstChannel()
    Private tbl_MstUser As DataTable = clsDataset.CreateTblMstUser()

    Private tbl_BodyEmail As DataTable = clsDataset.CreateTblMstBodyEmail()

    Private m_streams As IList(Of System.IO.Stream)
    Private m_currentPageIndex As Integer
    Private objDatalistTrnRq As ArrayList
    Private objDatalistTrnRqDetil As ArrayList

    'tambahan buat yg dgv ref
    Dim m_requestdetilref_idref_temp As String
    Dim m_requestdetilref_idreference As String

    'Private srvDir As String = "\\mis-14150\C$\TransBrowserFile\"
    Private srvDir As String = "" '"\\APLIKASI3\TransBrowserFile\"
    Private fi_src As System.IO.FileInfo
    Private fi_dest As System.IO.FileInfo

    Private attach_temp As String

    Private counter As Integer
    Private m, n As Integer
    Private isTimeValidating As Boolean
    Private guard As Boolean = True
    Private terors As Integer
    Dim p_domain_name As Microsoft.Reporting.WinForms.ReportParameter

    Friend WithEvents btnlock As ToolStripButton = New ToolStripButton
    Private isRetrieve As Boolean = False
    Private addManual As Boolean = False
    Private isNew As Boolean = False

    Private objPrintHeader As DataSource.ClsRptAdvanceHeader
    Private objPrintDetil As DataSource.ClsRptAdvanceDetil
    Private objDatalistDetil As ArrayList

    Private strchannel_id As String
    Private ref As String
    Private total_amount As Decimal
    Private id As String

    Private sptchannel_domainname As String
    Private sptChannel_nameReport As String
    Private sptChannel_address As String
    Private sptChannel_telp1 As String
    Private sptDomain As String

    Private isLoad As Boolean = False

    Private label_thread As String
    Private isBackGroundWorker_isWork As Boolean = False
    Private isBackgroundWorker As Boolean = False

    Private tbl_RefOrder As DataTable = clsDataset.CreateTblTrnOrderadvance()

    Private kondisi As Decimal = 0
    Private adv_req As Decimal

    Private approved1_by As String
    Private approved2_by As String
    Private titleapp1 As String
    Private titleapp2 As String

    Private approved3_by As String
    Private titleapp3 As String

    Private budgetdetil_line_temps As Integer

    Private tbl_TrnJurnal_Temp As DataTable = clsDataset.CreateTblTrnJurnal()
    Private tbl_TrnJurnaldetil_Debit As DataTable = clsDataset.CreateTblTrnJurnaldetil()
    Private tbl_TrnJurnaldetilandbilyet_Credit As DataTable = clsDataset.CreateTblTrnJurnaldetilBilyet()
    'Private tbl_TrnJurnalReference As DataTable = clsDataset.CreateTblTrnJurnalreferencePayable()
    Private tbl_TrnJurnalReference As DataTable = clsDataset.CreateTblTrnJurnalreference()

    ' Private tbl_TrnJurnalBilyet As DataTable = clsDataset.CreateTblTrnJurnalBilyet()
    Private tbl_TrnJurnalPV As DataTable = CreateTblTrnJurnalDetilPVListVQ()
    Private locking As clsLockingTransaction
    Friend WithEvents btnCreatePaymentVoucher As ToolStripButton = New ToolStripButton


    Private Enum Department As Integer
        Procurement = 5507
        BMA = 5559
        IT = 5517
        TSV = 5554
        BEN = 5560
        FIN = 5520
        NEWS = 3501
        PROD = 2360
    End Enum
    ''
#Region " Window Parameter "
    ' TODO: Buat variabel untuk menampung parameter window 
    Private _CHANNEL As String = "TAS"
    'tambahan Form Mode
    'Private _FORMMODE As String = "VIEW"
    Private _CHANNEL_CANBE_CHANGED As Boolean = False
    Private _CHANNEL_CANBE_BROWSED As Boolean = False
    Private _SOURCE As String = "Advance Travel" '"Reimburse Settlement" "Reimburse Request" "Advance Request"
    Private _TYPEID As String = "VQ"
    Private _USERSTRUKTURUNIT As Decimal = Department.FIN '5507 ''''Department.news   'Procurement: 5507; BMA: 5559
    Private _PROGRAMTYPE As String = "PG"
    Private _USERFULLNAME As String = "System"
    Private _SPLIT_ONLY As String = "No" 'Yes/No

    '=== ADD PTS 20150424 "Untuk keperluan Approve BMA yang dilakukan di Sekre"
    Private _MODUL_TYPE As String = "bma" 'staff,bma
    Private _AUTH_APPBMA_STRUKTURUNIT = "0" 'NGD - 3501, OPR - 2360, NONE - 0
    Private _USER_AUTHBMA As String = "" '"kokoh"
    '==========================================================================

#End Region

    Friend Class SelectEpsDialogReturn
        Private m_budgetdetil_line As Integer
        Private m_Advancedetil_line As Integer
        Private m_budget_name As String
        Private m_budgetdetil_eps As Decimal
        Private m_epsstart As Decimal
        Private m_epsend As Decimal

        Public Property budgetdetil_line() As Integer
            Get
                Return m_budgetdetil_line
            End Get
            Set(ByVal value As Integer)
                m_budgetdetil_line = value
            End Set
        End Property

        Public Property advancedetil_line() As Integer
            Get
                Return m_Advancedetil_line
            End Get
            Set(ByVal value As Integer)
                m_Advancedetil_line = value
            End Set

        End Property
        Public Property budget_name() As String
            Get
                Return m_budget_name
            End Get
            Set(ByVal value As String)
                m_budget_name = value
            End Set
        End Property

        Public Property budgetdetil_eps() As Decimal
            Get
                Return m_budgetdetil_eps
            End Get
            Set(ByVal value As Decimal)
                m_budgetdetil_eps = value
            End Set
        End Property

        Public Property epsstart() As Decimal
            Get
                Return m_epsstart
            End Get
            Set(ByVal value As Decimal)
                m_epsstart = value
            End Set
        End Property

        Public Property epsend() As Decimal
            Get
                Return m_epsend
            End Get
            Set(ByVal value As Decimal)
                m_epsend = value
            End Set
        End Property
    End Class

#Region " Overrides "

    Public Overrides Function btnQuery_Click() As Boolean
        Me.PnlDfSearch.Visible = Not Me.PnlDfSearch.Visible
        If Me.PnlDfSearch.Visible Then
            FILTER_QUERY_MODE = True
            Me.tbtnQuery.CheckState = CheckState.Checked
        Else
            FILTER_QUERY_MODE = False
            Me.tbtnQuery.CheckState = CheckState.Unchecked
        End If
        Return MyBase.btnQuery_Click()
    End Function

    Public Overrides Function btnNew_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        If Me.ftabMain.SelectedIndex = 0 Then
            If Me._USERSTRUKTURUNIT = Department.BMA Then
                Me.isNew = True
                Me.ftabMain.SelectedIndex = 1
                Me.isNew = False
            Else
                Me.isNew = True
                Me.ftabMain.SelectedIndex = 1
                Me.isNew = False
            End If
        End If

        Me.uiTransaksiAdvanceRequest_NewData()

        If Me._USERSTRUKTURUNIT = Department.BMA Then
            Me.obj_budget_id_code.Enabled = False
            Me.obj_budget_id_view.Enabled = False
            Me.obj_rekanan_id.Enabled = False
            Me.cmdAddItemManual.Enabled = True
            Me.obj_payment_type.Enabled = True
        Else
            Me.obj_budget_id_code.Enabled = False
            Me.obj_budget_id_view.Enabled = False
            Me.obj_rekanan_id.Enabled = False
            Me.cmdAddItemManual.Enabled = False
            Me.obj_payment_type.Enabled = True
            Me.obj_payment_addr.Enabled = True
            Me.obj_payment_addr.ReadOnly = False
            Me.obj_payment_addr.BackColor = Color.White
        End If


        If Me._SOURCE = "Advance Travel" Then
            Me.uiTransaksiAdvanceRequest_openDialogOrder_Advance()
            'Me.uiTransaksiAdvanceRequest_openDialogSPD_Advance()
            'Me.uiTransaksiAdvanceRequest_openDialogOrder_Advance()
        End If

        Me.Cursor = Cursors.Arrow

        'Default Value
        Me.tbl_TrnAdvance.Columns("source_id").DefaultValue = Me._SOURCE
        Me.tbl_TrnAdvance_Temp.Columns("source_id").DefaultValue = Me._SOURCE
        Me.tbl_TrnAdvance.Columns("type_id").DefaultValue = Me._TYPEID
        Me.tbl_TrnAdvance_Temp.Columns("type_id").DefaultValue = Me._TYPEID
        Me.tbl_TrnAdvance.Columns("channel_id").DefaultValue = Me._CHANNEL
        Me.tbl_TrnAdvance_Temp.Columns("channel_id").DefaultValue = Me._CHANNEL
        Me.tbl_TrnAdvance.Columns("advance_entryby").DefaultValue = Me._USERFULLNAME
        Me.tbl_TrnAdvance_Temp.Columns("advance_entryby").DefaultValue = Me._USERFULLNAME
        Me.tbl_TrnAdvance.Columns("advance_usedby").DefaultValue = Me._USERFULLNAME
        Me.tbl_TrnAdvance_Temp.Columns("advance_usedby").DefaultValue = Me._USERFULLNAME
        Me.tbl_TrnAdvance.Columns("advance_prepareby").DefaultValue = Me._USERFULLNAME
        Me.tbl_TrnAdvance_Temp.Columns("advance_prepareby").DefaultValue = Me._USERFULLNAME
        Me.tbl_TrnAdvance.Columns("advance_userpic").DefaultValue = Me._USERFULLNAME
        Me.tbl_TrnAdvance_Temp.Columns("advance_userpic").DefaultValue = Me._USERFULLNAME
        Me.tbl_TrnAdvance.Columns("strukturunit_id").DefaultValue = Me._USERSTRUKTURUNIT
        Me.tbl_TrnAdvance_Temp.Columns("strukturunit_id").DefaultValue = Me._USERSTRUKTURUNIT
        Me.tbl_TrnAdvance.Columns("advance_programtype").DefaultValue = Me._PROGRAMTYPE
        Me.tbl_TrnAdvance_Temp.Columns("advance_programtype").DefaultValue = Me._PROGRAMTYPE
        Me.tbl_TrnAdvance.Columns("strukturunit_id_dest").DefaultValue = Department.BMA
        Me.tbl_TrnAdvance_Temp.Columns("strukturunit_id_dest").DefaultValue = Department.BMA

        Me.tbl_TrnAdvance.Columns("currency_id").DefaultValue = 1
        Me.tbl_TrnAdvance_Temp.Columns("currency_id").DefaultValue = 1
        Me.tbl_TrnAdvance.Columns("advance_type").DefaultValue = "0"
        Me.tbl_TrnAdvance_Temp.Columns("advance_type").DefaultValue = "0"

        '
        Dim oDataFiller As New clsDataFiller(Me.DSN)
        Dim tbl_header As DataTable = clsDataset.CreateTblTrnBudget()
        Dim tbl_request_bma As New DataTable
        Dim activeColor As Color = Color.White
        Dim lockColor As Color = Color.Gainsboro

        'header
        obj_Advance_entrydt.Enabled = False
        obj_strukturunit_id_dest.Enabled = True
        obj_Advance_usedby.Enabled = True
        obj_RequestType.Enabled = True
        obj_budget_id_view.Enabled = False
        obj_budget_id_code.Enabled = False
        obj_Request_formid.Enabled = True
        obj_Request_jurnalisposted.Enabled = True
        obj_Advance_epsstart.Enabled = True
        obj_Advance_epsend.Enabled = True
        obj_Advance_currency.Enabled = False

        'add/del item and description
        cmdAddDesc.Enabled = True
        cmdDelDesc.Enabled = True

        'user info
        obj_Request_preparedt.Enabled = True
        obj_advance_prepare_dt.Enabled = True
        obj_Advance_preparedt_time.Enabled = True
        obj_Request_useddt.Enabled = True
        obj_Request_useddt_date.Enabled = True
        obj_Request_useddt_time.Enabled = True
        obj_Request_useddt2.Enabled = True
        obj_Request_useddt2_date.Enabled = True
        obj_Request_useddt2_time.Enabled = True

        obj_Advance_approved1dt.Enabled = False
        obj_Advance_modifieddt.Enabled = False
        obj_Advance_userpic.Enabled = True
        obj_Advance_approved1by.Enabled = False
        obj_Advance_modifiedby.Enabled = False
        obj_Advance_prepareloc.Enabled = True
        obj_Request_usedloc.Enabled = True

        'attachment
        obj_attach_browse.Enabled = True

        'note
        'obj_Request_descr.Enabled = True
        obj_Advance_descr.ReadOnly = False
        obj_Advance_descr.BackColor = Color.White

        'tambahan

        If Me._SOURCE = "Advance Request" And Me._SOURCE = "Reimburse Request" And Me._PROGRAMTYPE = "PG" Then
            Me.cmdAddItemManual.Enabled = True
        End If

        Me.DgvTrnAdvanceDetil.Columns("currency_id").ReadOnly = True
        Me.DgvTrnAdvanceDetil.Columns("currency_id").DefaultCellStyle.BackColor = lockColor
        Me.DgvTrnAdvanceDetil.Columns("advancedetil_foreignreal").ReadOnly = True
        Me.DgvTrnAdvanceDetil.Columns("advancedetil_foreignreal").DefaultCellStyle.BackColor = lockColor
        Me.DgvTrnAdvanceDetil.Columns("advancedetil_foreignrate").ReadOnly = True
        Me.DgvTrnAdvanceDetil.Columns("advancedetil_foreignrate").DefaultCellStyle.BackColor = lockColor
        Me.DgvTrnAdvanceDetil.Columns("advancedetil_idrreal").ReadOnly = True
        Me.DgvTrnAdvanceDetil.Columns("advancedetil_idrreal").DefaultCellStyle.BackColor = lockColor
        Me.DgvTrnAdvanceDetil.Columns("advancedetil_subtotal").ReadOnly = True
        Me.DgvTrnAdvanceDetil.Columns("advancedetil_subtotal").DefaultCellStyle.BackColor = lockColor

        Me.DgvTrnAdvanceDetil.Columns("advancedetil_approvedbma").ReadOnly = True
        Me.DgvTrnAdvanceDetil.Columns("advancedetil_approvedbma").DefaultCellStyle.BackColor = lockColor

        Me.DgvTrnAdvanceDetil.Columns("select_additem").ReadOnly = False
        Me.DgvTrnAdvanceDetil.Columns("advancedetil_descr").ReadOnly = False
        Me.DgvTrnAdvanceDetil.Columns("advancedetil_descr").DefaultCellStyle.BackColor = activeColor


        Me.DgvItemBudgetDetil.Columns("advance_id").Visible = False

        Me.DgvTrnAdvanceDetil.AllowUserToAddRows = False
        Me.DgvTrnAdvanceDetil.AllowUserToDeleteRows = True
        Me.DgvItemBudgetDetil.AllowUserToAddRows = False
        Me.DgvItemBudgetDetil.AllowUserToDeleteRows = False


        Dim tbl_currency, tbl_exrate As DataTable

        tbl_currency = New DataTable
        tbl_exrate = New DataTable

        tbl_currency.Clear()
        Me.DataFill(tbl_currency, "ms_MstCurrency_Select", String.Format("currency_id = {0}", Me.obj_Advance_currency.SelectedValue))

        tbl_exrate.Clear()
        If Me.obj_Advance_currency.SelectedValue <> 0 Then
            Me.DataFill(tbl_exrate, "pr_MstXRate_Select", String.Format("exrate_currency = '{0}'", tbl_currency.Rows(0).Item("currency_shortname")))
        End If
        Try
            If tbl_exrate.Rows.Count > 0 Then
                Me.obj_Advance_foreignrate.Text = tbl_exrate.Rows(0)("exrate_mid")
            Else
                Me.obj_Advance_foreignrate.Text = 0
            End If
        Catch ex As Exception
        End Try

        Return MyBase.btnNew_Click()
    End Function

    Public Overrides Function btnLoad_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTransaksiAdvanceRequest_Retrieve()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnLoad_Click()
    End Function

    Public Overrides Function btnSave_Click() As Boolean
        If Me.uiTransaksiAdvanceRequest_FormError() Then
            Return True
        End If
        Me.Cursor = Cursors.WaitCursor
        'Me.uiTransaksiRentalRequest_CheckRequestTime()
        Me.uiTransaksiAdvanceRequest_Save()

        Me.Cursor = Cursors.Arrow
        Return MyBase.btnSave_Click()
    End Function

    Public Overrides Function btnDel_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTransaksiAdvanceRequest_Delete()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnDel_Click()
    End Function

    Public Overrides Function btnFirst_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTransaksiAdvanceRequest_First()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnFirst_Click()
    End Function

    Public Overrides Function btnPrev_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTransaksiAdvanceRequest_Prev()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnPrev_Click()
    End Function

    Public Overrides Function btnNext_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTransaksiAdvanceRequest_Next()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnNext_Click()
    End Function

    Public Overrides Function btnLast_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTransaksiAdvanceRequest_Last()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnLast_Click()
    End Function

    Public Overrides Function btnPrint_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTransaksiAdvanceRequest_Print()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnPrint_Click()
    End Function

    Public Overrides Function btnPrintPreview_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTransaksiAdvanceRequest_PrintPreview()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnPrintPreview_Click()
    End Function

#End Region

#Region " Layout & Init UI "
    Public Shared Function CreateTblTrnAdvance() As DataTable
        Dim tbl As DataTable = clsDataset.CreateTblTrnAdvance

        tbl.Columns.Add(New DataColumn("pilih", GetType(System.Byte)))
        tbl.Columns.Add(New DataColumn("pv_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("ispulled_pv", GetType(System.Int32)))

        tbl.Columns("pilih").DefaultValue = 0
        tbl.Columns("pv_id").DefaultValue = ""
        tbl.Columns("ispulled_pv").DefaultValue = 0

        Return tbl
    End Function

    Public Shared Function CreateTblTrnJurnalDetilPVListVQ() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("jurnal_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("jurnaldetil_check", GetType(System.Boolean)))
        tbl.Columns.Add(New DataColumn("jurnal_bookdate", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("jurnal_duedate", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("jurnaldetil_line", GetType(System.Int64)))
        tbl.Columns.Add(New DataColumn("budgetdetil_line", GetType(System.Int64)))
        tbl.Columns.Add(New DataColumn("jurnaldetil_descr", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("jurnaldetil_idr", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("jurnaldetil_foreign", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("jurnaldetil_rate", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("jurnaldetil_receive", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("jurnaldetil_receive_foreign", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("jurnaldetil_foreignrate", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("jurnaldetil_idr_outstanding", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("jurnaldetil_foreign_outstanding", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("currency_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("acc_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("rekanan_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("channel_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("jurnal_isposted", GetType(System.Boolean)))
        tbl.Columns.Add(New DataColumn("rekanan_name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("currency_name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("acc_name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("strukturunit_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("strukturunit_name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("budget_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("budget_name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("budgetdetil_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("budgetdetil_name", GetType(System.String)))

        '-------------------------------
        'Default Value: 
        tbl.Columns("jurnal_id").DefaultValue = ""
        tbl.Columns("jurnaldetil_check").DefaultValue = False
        tbl.Columns("jurnal_bookdate").DefaultValue = Now.Date
        tbl.Columns("jurnal_duedate").DefaultValue = Now.Date
        tbl.Columns("jurnaldetil_line").DefaultValue = 0
        tbl.Columns("budgetdetil_line").DefaultValue = 0
        tbl.Columns("jurnaldetil_descr").DefaultValue = ""
        tbl.Columns("jurnaldetil_idr").DefaultValue = 0
        tbl.Columns("jurnaldetil_foreign").DefaultValue = 0
        tbl.Columns("jurnaldetil_rate").DefaultValue = 0
        tbl.Columns("jurnaldetil_receive").DefaultValue = 0
        tbl.Columns("jurnaldetil_receive_foreign").DefaultValue = 0
        tbl.Columns("jurnaldetil_foreignrate").DefaultValue = 0
        tbl.Columns("jurnaldetil_idr_outstanding").DefaultValue = 0
        tbl.Columns("jurnaldetil_foreign_outstanding").DefaultValue = 0
        tbl.Columns("currency_id").DefaultValue = ""
        tbl.Columns("acc_id").DefaultValue = "0"
        tbl.Columns("rekanan_id").DefaultValue = 0
        tbl.Columns("channel_id").DefaultValue = ""
        tbl.Columns("jurnal_isposted").DefaultValue = 0
        tbl.Columns("rekanan_name").DefaultValue = ""
        tbl.Columns("currency_name").DefaultValue = ""
        tbl.Columns("acc_name").DefaultValue = ""
        tbl.Columns("strukturunit_id").DefaultValue = 0
        tbl.Columns("strukturunit_name").DefaultValue = ""
        tbl.Columns("budget_id").DefaultValue = 0
        tbl.Columns("budget_name").DefaultValue = ""
        tbl.Columns("budgetdetil_id").DefaultValue = 0
        tbl.Columns("budgetdetil_name").DefaultValue = ""

        Return tbl
    End Function

    Private Function FormatDgvTrnAdvance(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        Dim cAdvance_id As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAdvance_timeremain As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAdvance_entrydt As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAdvance_entryby As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAdvance_preparedt As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAdvance_usedby As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAdvance_modifieddt As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAdvance_modifiedby As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cStrukturunit_id_dest As New System.Windows.Forms.DataGridViewComboBoxColumn
        Dim cBudget_id As New System.Windows.Forms.DataGridViewComboBoxColumn
        Dim cBudget_code As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAdvance_prepareloc As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAdvance_userpic As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAdvance_status As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cSource_id As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim ctype_id As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cchannel_id As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cStrukturunit_id As New System.Windows.Forms.DataGridViewComboBoxColumn
        Dim crekanan_id As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim crekanan_name As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim ccurrency_id As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAdvance_foreignrate As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAdvance_foreignreal As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAdvance_approved1 As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAdvance_approved1dt As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAdvance_approved1by As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAdvance_approved2 As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAdvance_approved2by As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAdvance_approved2dt As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAdvance_canceled As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAdvance_descr As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAdvance_approvedbma As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAdvance_IsChecked As New System.Windows.Forms.DataGridViewCheckBoxColumn
        Dim cJurnalID As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cIsPulledPV As New System.Windows.Forms.DataGridViewTextBoxColumn

        cAdvance_approved1.Name = "advance_approved1"
        cAdvance_approved1.HeaderText = "Approved 1"
        cAdvance_approved1.DataPropertyName = "advance_approved1"
        cAdvance_approved1.Width = 100
        cAdvance_approved1.SortMode = DataGridViewColumnSortMode.NotSortable
        cAdvance_approved1.Visible = False
        cAdvance_approved1.ReadOnly = True

        cAdvance_approved1dt.Name = "advance_approved1dt"
        cAdvance_approved1dt.HeaderText = "Approved Date"
        cAdvance_approved1dt.DataPropertyName = "advance_approved1dt"
        cAdvance_approved1dt.Width = 150
        cAdvance_approved1dt.SortMode = DataGridViewColumnSortMode.NotSortable
        cAdvance_approved1dt.Visible = True
        cAdvance_approved1dt.ReadOnly = True
        cAdvance_approved1dt.DefaultCellStyle.Format = "dd/MM/yyyy HH:mm"

        cAdvance_approved1by.Name = "advance_approved1by"
        cAdvance_approved1by.HeaderText = "Approved By User"
        cAdvance_approved1by.DataPropertyName = "advance_approved1by"
        cAdvance_approved1by.Width = 150
        cAdvance_approved1by.SortMode = DataGridViewColumnSortMode.NotSortable
        cAdvance_approved1by.Visible = True
        cAdvance_approved1by.ReadOnly = True

        cAdvance_IsChecked.Name = "pilih"
        cAdvance_IsChecked.HeaderText = "Pilih"
        cAdvance_IsChecked.DataPropertyName = "pilih"
        cAdvance_IsChecked.Width = 50
        cAdvance_IsChecked.Frozen = True
        cAdvance_IsChecked.Visible = True
        cAdvance_IsChecked.ReadOnly = False

        cAdvance_id.Name = "advance_id"
        cAdvance_id.HeaderText = "ID"
        cAdvance_id.DataPropertyName = "advance_id"
        cAdvance_id.Width = 120
        cAdvance_id.Frozen = True
        cAdvance_id.Visible = True
        cAdvance_id.ReadOnly = False

        cJurnalID.Name = "pv_id"
        cJurnalID.HeaderText = "PV ID"
        cJurnalID.DataPropertyName = "pv_id"
        cJurnalID.Width = 120
        cJurnalID.Frozen = True
        cJurnalID.Visible = True
        cJurnalID.ReadOnly = False

        cIsPulledPV.Name = "ispulled_pv"
        cIsPulledPV.HeaderText = "Is Pulled PV"
        cIsPulledPV.DataPropertyName = "ispulled_pv"
        cIsPulledPV.Width = 120
        cIsPulledPV.Visible = False
        cIsPulledPV.ReadOnly = False

        cAdvance_timeremain.Name = "advance_timeremain"
        cAdvance_timeremain.HeaderText = "Status"
        cAdvance_timeremain.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cAdvance_timeremain.DataPropertyName = "advance_timeremain"
        cAdvance_timeremain.Width = 60
        cAdvance_timeremain.Visible = False
        cAdvance_timeremain.ReadOnly = False

        cAdvance_descr.Name = "advance_descr"
        cAdvance_descr.HeaderText = "Description"
        cAdvance_descr.DataPropertyName = "advance_descr"
        cAdvance_descr.Width = 200
        cAdvance_descr.SortMode = DataGridViewColumnSortMode.NotSortable
        cAdvance_descr.Visible = True
        cAdvance_descr.ReadOnly = False

        cAdvance_entrydt.Name = "advance_entrydt"
        cAdvance_entrydt.HeaderText = "Entry Date"
        cAdvance_entrydt.DataPropertyName = "advance_entrydt"
        cAdvance_entrydt.Width = 100
        cAdvance_entrydt.SortMode = DataGridViewColumnSortMode.NotSortable
        cAdvance_entrydt.Visible = True
        cAdvance_entrydt.ReadOnly = False
        cAdvance_entrydt.DefaultCellStyle.Format = "dd/MM/yyyy HH:mm"

        cAdvance_entryby.Name = "advance_entryby"
        cAdvance_entryby.HeaderText = "Entry By"
        cAdvance_entryby.DataPropertyName = "advance_entryby"
        cAdvance_entryby.Width = 100
        cAdvance_entryby.SortMode = DataGridViewColumnSortMode.NotSortable
        cAdvance_entryby.Visible = False
        cAdvance_entryby.ReadOnly = False

        cAdvance_preparedt.Name = "advance_preparedt"
        cAdvance_preparedt.HeaderText = "advance_preparedt"
        cAdvance_preparedt.DataPropertyName = "advance_preparedt"
        cAdvance_preparedt.Width = 100
        cAdvance_preparedt.SortMode = DataGridViewColumnSortMode.NotSortable
        cAdvance_preparedt.Visible = False
        cAdvance_preparedt.ReadOnly = False

        cAdvance_usedby.Name = "advance_usedby"
        cAdvance_usedby.HeaderText = "Used By"
        cAdvance_usedby.DataPropertyName = "advance_usedby"
        cAdvance_usedby.Width = 150
        cAdvance_usedby.SortMode = DataGridViewColumnSortMode.NotSortable
        cAdvance_usedby.Visible = True
        cAdvance_usedby.ReadOnly = False

        cAdvance_modifieddt.Name = "advance_modifieddt"
        cAdvance_modifieddt.HeaderText = "advance_modifieddt"
        cAdvance_modifieddt.DataPropertyName = "advance_modifieddt"
        cAdvance_modifieddt.Width = 100
        cAdvance_modifieddt.SortMode = DataGridViewColumnSortMode.NotSortable
        cAdvance_modifieddt.Visible = False
        cAdvance_modifieddt.ReadOnly = False

        cAdvance_modifiedby.Name = "advance_modifiedby"
        cAdvance_modifiedby.HeaderText = "advance_modifiedby"
        cAdvance_modifiedby.DataPropertyName = "advance_modifiedby"
        cAdvance_modifiedby.Width = 100
        cAdvance_modifiedby.SortMode = DataGridViewColumnSortMode.NotSortable
        cAdvance_modifiedby.Visible = False
        cAdvance_modifiedby.ReadOnly = False

        cStrukturunit_id_dest.Name = "strukturunit_id_dest"
        cStrukturunit_id_dest.HeaderText = "Department To"
        cStrukturunit_id_dest.DataPropertyName = "strukturunit_id_dest"
        cStrukturunit_id_dest.DataSource = Me.tbl_MstStrukturunit_dest
        cStrukturunit_id_dest.DisplayStyleForCurrentCellOnly = True
        cStrukturunit_id_dest.ValueMember = "strukturunit_id"
        cStrukturunit_id_dest.DisplayMember = "strukturunit_namereport"
        cStrukturunit_id_dest.Width = 200
        cStrukturunit_id_dest.SortMode = DataGridViewColumnSortMode.NotSortable
        cStrukturunit_id_dest.Visible = True
        cStrukturunit_id_dest.ReadOnly = False

        cBudget_code.Name = "budget_id"
        cBudget_code.HeaderText = "Budget Code"
        cBudget_code.DataPropertyName = "budget_id"
        cBudget_code.Width = 100
        cBudget_code.SortMode = DataGridViewColumnSortMode.NotSortable
        cBudget_code.Visible = True
        cBudget_code.ReadOnly = True

        cBudget_id.Name = "budget_id"
        cBudget_id.HeaderText = "Budget"
        cBudget_id.DataPropertyName = "budget_id"
        cBudget_id.DataSource = Me.tbl_TrnBudgetMain
        cBudget_id.DisplayStyleForCurrentCellOnly = True
        cBudget_id.ValueMember = "budget_id"
        cBudget_id.DisplayMember = "budget_nameshort"
        cBudget_id.Width = 200
        cBudget_id.SortMode = DataGridViewColumnSortMode.NotSortable
        cBudget_id.Visible = True
        cBudget_id.ReadOnly = False

        cAdvance_prepareloc.Name = "advance_prepareloc"
        cAdvance_prepareloc.HeaderText = "advance_prepareloc"
        cAdvance_prepareloc.DataPropertyName = "advance_prepareloc"
        cAdvance_prepareloc.Width = 100
        cAdvance_prepareloc.SortMode = DataGridViewColumnSortMode.NotSortable
        cAdvance_prepareloc.Visible = False
        cAdvance_prepareloc.ReadOnly = False

        cAdvance_userpic.Name = "advance_userpic"
        cAdvance_userpic.HeaderText = "advance_userpic"
        cAdvance_userpic.DataPropertyName = "advance_userpic"
        cAdvance_userpic.Width = 100
        cAdvance_userpic.SortMode = DataGridViewColumnSortMode.NotSortable
        cAdvance_userpic.Visible = False
        cAdvance_userpic.ReadOnly = False

        cAdvance_status.Name = "advance_status"
        cAdvance_status.HeaderText = "advance_status"
        cAdvance_status.DataPropertyName = "advance_status"
        cAdvance_status.Width = 100
        cAdvance_status.SortMode = DataGridViewColumnSortMode.NotSortable
        cAdvance_status.Visible = False
        cAdvance_status.ReadOnly = False


        cSource_id.Name = "source_id"
        cSource_id.HeaderText = "source_id"
        cSource_id.DataPropertyName = "source_id"
        cSource_id.Width = 100
        cSource_id.SortMode = DataGridViewColumnSortMode.NotSortable
        cSource_id.Visible = False
        cSource_id.ReadOnly = False

        ctype_id.Name = "type_id"
        ctype_id.HeaderText = "type_id"
        ctype_id.DataPropertyName = "type_id"
        ctype_id.Width = 100
        ctype_id.SortMode = DataGridViewColumnSortMode.NotSortable
        ctype_id.Visible = False
        ctype_id.ReadOnly = False

        cchannel_id.Name = "channel_id"
        cchannel_id.HeaderText = "channel_id"
        cchannel_id.DataPropertyName = "channel_id"
        cchannel_id.Width = 100
        cchannel_id.SortMode = DataGridViewColumnSortMode.NotSortable
        cchannel_id.Visible = False
        cchannel_id.ReadOnly = False

        cStrukturunit_id.Name = "strukturunit_id"
        cStrukturunit_id.HeaderText = "Department From"
        cStrukturunit_id.DataPropertyName = "strukturunit_id"
        cStrukturunit_id.DataSource = Me.tbl_MstStrukturunit
        cStrukturunit_id.DisplayStyleForCurrentCellOnly = True
        cStrukturunit_id.ValueMember = "strukturunit_id"
        cStrukturunit_id.DisplayMember = "strukturunit_namereport"
        cStrukturunit_id.Width = 200
        cStrukturunit_id.SortMode = DataGridViewColumnSortMode.NotSortable
        cStrukturunit_id.Visible = True
        cStrukturunit_id.ReadOnly = False

        crekanan_id.Name = "rekanan_id"
        crekanan_id.HeaderText = "Vendor"
        crekanan_id.DataPropertyName = "rekanan_id"
        crekanan_id.Width = 100
        crekanan_id.SortMode = DataGridViewColumnSortMode.NotSortable
        crekanan_id.Visible = False
        crekanan_id.ReadOnly = False

        crekanan_name.Name = "rekanan_name"
        crekanan_name.HeaderText = "Vendor"
        crekanan_name.DataPropertyName = "rekanan_name"
        crekanan_name.Width = 150
        crekanan_name.SortMode = DataGridViewColumnSortMode.NotSortable
        crekanan_name.Visible = True
        crekanan_name.ReadOnly = False

        ccurrency_id.Name = "currency_id"
        ccurrency_id.HeaderText = "currency_id"
        ccurrency_id.DataPropertyName = "currency_id"
        ccurrency_id.Width = 100
        ccurrency_id.SortMode = DataGridViewColumnSortMode.NotSortable
        ccurrency_id.Visible = False
        ccurrency_id.ReadOnly = False

        cAdvance_foreignrate.Name = "advance_foreignrate"
        cAdvance_foreignrate.HeaderText = "advance_foreignrate"
        cAdvance_foreignrate.DataPropertyName = "advance_foreignrate"
        cAdvance_foreignrate.Width = 100
        cAdvance_foreignrate.SortMode = DataGridViewColumnSortMode.NotSortable
        cAdvance_foreignrate.Visible = False
        cAdvance_foreignrate.ReadOnly = False

        cAdvance_foreignreal.Name = "advance_foreignreal"
        cAdvance_foreignreal.HeaderText = "advance_foreignreal"
        cAdvance_foreignreal.DataPropertyName = "advance_foreignreal"
        cAdvance_foreignreal.Width = 100
        cAdvance_foreignreal.SortMode = DataGridViewColumnSortMode.NotSortable
        cAdvance_foreignreal.Visible = True
        cAdvance_foreignreal.ReadOnly = False

        cAdvance_approved2.Name = "advance_approved2"
        cAdvance_approved2.HeaderText = "advance_approved2"
        cAdvance_approved2.DataPropertyName = "advance_approved2"
        cAdvance_approved2.Width = 100
        cAdvance_approved2.SortMode = DataGridViewColumnSortMode.NotSortable
        cAdvance_approved2.Visible = False
        cAdvance_approved2.ReadOnly = True

        cAdvance_approved2by.Name = "advance_approved2by"
        cAdvance_approved2by.HeaderText = "Approved By Kadiv"
        cAdvance_approved2by.DataPropertyName = "advance_approved2by"
        cAdvance_approved2by.Width = 150
        cAdvance_approved2by.SortMode = DataGridViewColumnSortMode.NotSortable
        cAdvance_approved2by.Visible = False
        cAdvance_approved2by.ReadOnly = True

        cAdvance_approved2dt.Name = "advance_approved2dt"
        cAdvance_approved2dt.HeaderText = "Approved Date By Kadiv"
        cAdvance_approved2dt.DataPropertyName = "advance_approved2dt"
        cAdvance_approved2dt.Width = 150
        'crequest_approved2dt.SortMode = DataGridViewColumnSortMode.NotSortable
        cAdvance_approved2dt.Visible = False
        cAdvance_approved2dt.ReadOnly = True
        cAdvance_approved2dt.DefaultCellStyle.Format = "dd/MM/yyyy HH:mm"

        cAdvance_canceled.Name = "advance_canceled"
        cAdvance_canceled.HeaderText = "advance_canceled"
        cAdvance_canceled.DataPropertyName = "advance_canceled"
        cAdvance_canceled.Width = 100
        cAdvance_canceled.SortMode = DataGridViewColumnSortMode.NotSortable
        cAdvance_canceled.Visible = False
        cAdvance_canceled.ReadOnly = True

        cAdvance_approvedbma.Name = "advance_approvedbma"
        cAdvance_approvedbma.HeaderText = "advance_approvedbma"
        cAdvance_approvedbma.DataPropertyName = "advance_approvedbma"
        cAdvance_approvedbma.Width = 100
        cAdvance_approvedbma.SortMode = DataGridViewColumnSortMode.NotSortable
        cAdvance_approvedbma.Visible = False
        cAdvance_approvedbma.ReadOnly = True

        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
        {cAdvance_IsChecked, cAdvance_id, cJurnalID, cAdvance_canceled, cAdvance_timeremain, _
        cAdvance_descr, cAdvance_approved2dt, cAdvance_entrydt, cAdvance_entryby, cAdvance_preparedt, _
        cAdvance_modifieddt, cAdvance_modifiedby, cStrukturunit_id, cStrukturunit_id_dest, _
        cBudget_code, cBudget_id, cAdvance_approved1by, cAdvance_approved1dt, cAdvance_approved2by, _
        cAdvance_prepareloc, cAdvance_userpic, cAdvance_status, _
        cSource_id, ctype_id, cchannel_id, crekanan_id, crekanan_name, ccurrency_id, _
        cAdvance_foreignrate, cAdvance_foreignreal, cAdvance_approved1, cAdvance_approved2, _
        cAdvance_approvedbma, cIsPulledPV})

        ' DgvTrnRequest Behaviours: 
        objDgv.AutoGenerateColumns = False
        objDgv.AllowUserToAddRows = False
        objDgv.AllowUserToDeleteRows = False
        objDgv.AllowUserToResizeRows = False
        objDgv.ReadOnly = False
        objDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect

    End Function

    Private Function FormatDgvTrnAdvanceDetil(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        ' formating DgvTrnRequestdetil
        Dim cRequestdetil_type As System.Windows.Forms.DataGridViewComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn
        Dim cAdvance_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAdvancedetil_line As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAdvancedetil_descr As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cCurrency_id As System.Windows.Forms.DataGridViewComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn
        Dim cAdvanceDetil_foreignrate As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cChannel_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cStrukturunit_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAdvanceDetil_foreignreal As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAdvanceDetil_ordered As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAdvanceDetil_refreference As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAdvanceDetil_idrreal As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cStatus_over As New System.Windows.Forms.DataGridViewTextBoxColumn

        Dim cAdvancedetil_approvedbma As New System.Windows.Forms.DataGridViewCheckBoxColumn
        Dim cAdvancedetil_approvedbmadt As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAdvancedetil_approvedbmaby As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAdvancedetil_approveddescr As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAdvanceDetil_subtotal As New System.Windows.Forms.DataGridViewTextBoxColumn

        Dim columnIndex As Integer
        Dim cButton_additem As New System.Windows.Forms.DataGridViewButtonColumn

        Dim cDate_column As New clsCalender.CalendarColumn
        Dim cPayment_type As New System.Windows.Forms.DataGridViewComboBoxColumn

        Dim cAdvancedetil_bmaApproved As New System.Windows.Forms.DataGridViewCheckBoxColumn
        Dim cAdvancedetil_bmaApproveddt As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAdvancedetil_bmaApprovedby As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBma_memo As New System.Windows.Forms.DataGridViewTextBoxColumn

        Dim cAdvancedetil_canceled As New System.Windows.Forms.DataGridViewCheckBoxColumn
        Dim cAdvancedetil_canceleddt As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAdvancedetil_canceledby As New System.Windows.Forms.DataGridViewTextBoxColumn

        cButton_additem.Name = "select_additem"
        cButton_additem.HeaderText = ""
        cButton_additem.Text = "..."
        cButton_additem.UseColumnTextForButtonValue = True
        cButton_additem.Width = 30
        cButton_additem.DividerWidth = 3
        '' ''If Me._SOURCE = "Reimburse Settlement" Then
        '' ''    cButton_additem.Visible = False
        '' ''Else
        cButton_additem.Visible = False
        '' ''End If
        cButton_additem.ReadOnly = False
        cButton_additem.SortMode = DataGridViewColumnSortMode.NotSortable

        cRequestdetil_type.Name = "advancedetil_type"
        cRequestdetil_type.HeaderText = "Type"
        cRequestdetil_type.DataPropertyName = "advancedetil_type"

        If tbl_Trnrequestdetil_type.Columns("display_type") IsNot Nothing Then
            cRequestdetil_type.DataSource = Me.tbl_Trnrequestdetil_type
            cRequestdetil_type.ValueMember = "value_type"
            cRequestdetil_type.DisplayMember = "display_type"
        End If

        cRequestdetil_type.DisplayStyleForCurrentCellOnly = True
        cRequestdetil_type.Width = 100
        cRequestdetil_type.Visible = True
        cRequestdetil_type.ReadOnly = True
        cRequestdetil_type.Frozen = False
        cRequestdetil_type.DefaultCellStyle.BackColor = Color.Gainsboro

        cAdvance_id.Name = "advance_id"
        cAdvance_id.HeaderText = "Advance ID"
        cAdvance_id.DataPropertyName = "advance_id"
        cAdvance_id.Width = 100
        cAdvance_id.Visible = False
        cAdvance_id.ReadOnly = True

        cAdvancedetil_line.Name = "advancedetil_line"
        cAdvancedetil_line.HeaderText = "Line"
        cAdvancedetil_line.DataPropertyName = "advancedetil_line"
        cAdvancedetil_line.Width = 40
        cAdvancedetil_line.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cAdvancedetil_line.Frozen = False
        cAdvancedetil_line.Visible = True
        cAdvancedetil_line.ReadOnly = False
        cAdvancedetil_line.DefaultCellStyle.BackColor = Color.Gainsboro

        cAdvancedetil_descr.Name = "advancedetil_descr"
        cAdvancedetil_descr.HeaderText = "Description"
        cAdvancedetil_descr.DataPropertyName = "advancedetil_descr"
        cAdvancedetil_descr.Width = 200
        cAdvancedetil_descr.Visible = True
        cAdvancedetil_descr.ReadOnly = False

        cCurrency_id.Name = "currency_id"
        cCurrency_id.HeaderText = "Currency"
        cCurrency_id.DataPropertyName = "currency_id"
        cCurrency_id.Width = 85
        cCurrency_id.ValueMember = "currency_id"
        cCurrency_id.DisplayMember = "currency_shortname"
        cCurrency_id.DataSource = Me.tbl_MstCurrencyDetil
        cCurrency_id.DisplayStyleForCurrentCellOnly = True
        cCurrency_id.Visible = True
        cCurrency_id.ReadOnly = True
        cCurrency_id.DefaultCellStyle.BackColor = Color.Gainsboro

        cAdvanceDetil_foreignrate.Name = "advancedetil_foreignrate"
        cAdvanceDetil_foreignrate.HeaderText = "Rate"
        cAdvanceDetil_foreignrate.DataPropertyName = "advancedetil_foreignrate"
        cAdvanceDetil_foreignrate.Width = 125
        cAdvanceDetil_foreignrate.Visible = True
        cAdvanceDetil_foreignrate.ReadOnly = True
        cAdvanceDetil_foreignrate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cAdvanceDetil_foreignrate.DefaultCellStyle.Format = "#,##0.00"
        cAdvanceDetil_foreignrate.DefaultCellStyle.BackColor = Color.Gainsboro

        cAdvanceDetil_idrreal.Name = "advancedetil_idrreal"
        cAdvanceDetil_idrreal.HeaderText = "Amount IDR"
        cAdvanceDetil_idrreal.DataPropertyName = "advancedetil_idrreal"
        cAdvanceDetil_idrreal.Width = 125
        cAdvanceDetil_idrreal.Visible = True
        cAdvanceDetil_idrreal.ReadOnly = True
        cAdvanceDetil_idrreal.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cAdvanceDetil_idrreal.DefaultCellStyle.Format = "#,##0.00"
        cAdvanceDetil_idrreal.DefaultCellStyle.BackColor = Color.Gainsboro

        cChannel_id.Name = "channel_id"
        cChannel_id.HeaderText = "channel_id"
        cChannel_id.DataPropertyName = "channel_id"
        cChannel_id.Width = 100
        cChannel_id.Visible = False
        cChannel_id.ReadOnly = False

        cStrukturunit_id.Name = "strukturunit_id"
        cStrukturunit_id.HeaderText = "strukturunit_id"
        cStrukturunit_id.DataPropertyName = "strukturunit_id"
        cStrukturunit_id.Width = 100
        cStrukturunit_id.Visible = False
        cStrukturunit_id.ReadOnly = True

        cAdvanceDetil_foreignreal.Name = "advancedetil_foreignreal"
        cAdvanceDetil_foreignreal.HeaderText = "Amount"
        cAdvanceDetil_foreignreal.DataPropertyName = "advancedetil_foreignreal"
        cAdvanceDetil_foreignreal.Width = 125
        cAdvanceDetil_foreignreal.Visible = True
        cAdvanceDetil_foreignreal.ReadOnly = True
        cAdvanceDetil_foreignreal.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cAdvanceDetil_foreignreal.DefaultCellStyle.Format = "#,##0.00"
        cAdvanceDetil_foreignreal.DefaultCellStyle.BackColor = Color.Gainsboro

        cAdvanceDetil_refreference.Name = "advancedetil_refreference"
        cAdvanceDetil_refreference.HeaderText = "ID Reference"
        cAdvanceDetil_refreference.DataPropertyName = "advancedetil_refreference"
        cAdvanceDetil_refreference.Width = 100
        cAdvanceDetil_refreference.Visible = False
        cAdvanceDetil_refreference.ReadOnly = True

        cAdvanceDetil_ordered.Name = "advancedetil_ordered"
        cAdvanceDetil_ordered.HeaderText = "Ordered"
        cAdvanceDetil_ordered.DataPropertyName = "advancedetil_ordered"
        cAdvanceDetil_ordered.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        cAdvanceDetil_ordered.Width = 60
        cAdvanceDetil_ordered.Visible = False
        cAdvanceDetil_ordered.ReadOnly = True

        cStatus_over.Name = "status_over"
        cStatus_over.HeaderText = "Status"
        cStatus_over.Width = 125
        cStatus_over.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        cStatus_over.Visible = True
        cStatus_over.ReadOnly = True
        cStatus_over.DefaultCellStyle.BackColor = Color.LightGray

        cAdvancedetil_approvedbma.Name = "advancedetil_approvedbma"
        cAdvancedetil_approvedbma.HeaderText = "BMA Approve"
        cAdvancedetil_approvedbma.DataPropertyName = "advancedetil_approvedbma"
        cAdvancedetil_approvedbma.Width = 100
        cAdvancedetil_approvedbma.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        cAdvancedetil_approvedbma.Visible = True
        cAdvancedetil_approvedbma.ReadOnly = False

        cAdvancedetil_approvedbmadt.Name = "advancedetil_approvedbmadt"
        cAdvancedetil_approvedbmadt.HeaderText = "BMA Approve Date"
        cAdvancedetil_approvedbmadt.DataPropertyName = "advancedetil_approvedbmadt"
        cAdvancedetil_approvedbmadt.Width = 130
        cAdvancedetil_approvedbmadt.DefaultCellStyle.Format = "dd/MM/yyyy"
        cAdvancedetil_approvedbmadt.Visible = True
        cAdvancedetil_approvedbmadt.ReadOnly = True
        cAdvancedetil_approvedbmadt.DefaultCellStyle.BackColor = Color.LightGray

        cAdvancedetil_approvedbmaby.Name = "advancedetil_approvedbmaby"
        cAdvancedetil_approvedbmaby.HeaderText = "BMA Approve By"
        cAdvancedetil_approvedbmaby.DataPropertyName = "advancedetil_approvedbmaby"
        cAdvancedetil_approvedbmaby.Width = 200
        cAdvancedetil_approvedbmaby.Visible = True
        cAdvancedetil_approvedbmaby.ReadOnly = True
        cAdvancedetil_approvedbmaby.DefaultCellStyle.BackColor = Color.LightGray

        cAdvancedetil_approveddescr.Name = "advancedetil_approveddescr"
        cAdvancedetil_approveddescr.HeaderText = "BMA Note"
        cAdvancedetil_approveddescr.DataPropertyName = "advancedetil_approveddescr"
        cAdvancedetil_approveddescr.Width = 200
        cAdvancedetil_approveddescr.Visible = True
        cAdvancedetil_approveddescr.ReadOnly = True

        cDate_column.Name = "advancedetil_paymentdt"
        cDate_column.HeaderText = "Date"
        cDate_column.DataPropertyName = "advancedetil_paymentdt"
        cDate_column.Width = 100
        cDate_column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cDate_column.Visible = True
        cDate_column.ReadOnly = False
        cDate_column.DefaultCellStyle.Format = "dd/MM/yyyy"

        cPayment_type.Name = "advancedetil_paymenttype"
        cPayment_type.HeaderText = "Payment Type"
        cPayment_type.DataPropertyName = "advancedetil_paymenttype"
        cPayment_type.Width = 100
        cPayment_type.ValueMember = "paymenttype_id"
        cPayment_type.DisplayMember = "paymenttype_name"
        cPayment_type.DataSource = Me.tbl_MstPaymentTypeGrid
        cPayment_type.DisplayStyleForCurrentCellOnly = True
        cPayment_type.Visible = True
        cPayment_type.ReadOnly = False

        cAdvanceDetil_subtotal.Name = "advancedetil_subtotal"
        cAdvanceDetil_subtotal.HeaderText = "Subtotal Incl.(PPH,PPN,Disc.)"
        cAdvanceDetil_subtotal.DataPropertyName = "advancedetil_subtotal"
        cAdvanceDetil_subtotal.Width = 160
        cAdvanceDetil_subtotal.Visible = True
        cAdvanceDetil_subtotal.ReadOnly = True
        cAdvanceDetil_subtotal.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cAdvanceDetil_subtotal.DefaultCellStyle.Format = "#,##0.00"
        cAdvanceDetil_subtotal.DefaultCellStyle.BackColor = Color.Gainsboro

        cAdvancedetil_bmaApproved.Name = "bma_approved"
        cAdvancedetil_bmaApproved.HeaderText = "Approve Memo"
        cAdvancedetil_bmaApproved.DataPropertyName = "bma_approved"
        cAdvancedetil_bmaApproved.Width = 100
        cAdvancedetil_bmaApproved.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        cAdvancedetil_bmaApproved.Visible = True
        cAdvancedetil_bmaApproved.ReadOnly = True
        cAdvancedetil_bmaApproved.DefaultCellStyle.BackColor = Color.LightGray

        cAdvancedetil_bmaApproveddt.Name = "bma_approveddt"
        cAdvancedetil_bmaApproveddt.HeaderText = "Approve Memo Date"
        cAdvancedetil_bmaApproveddt.DataPropertyName = "bma_approveddt"
        cAdvancedetil_bmaApproveddt.Width = 130
        cAdvancedetil_bmaApproveddt.DefaultCellStyle.Format = "dd/MM/yyyy"
        cAdvancedetil_bmaApproveddt.Visible = True
        cAdvancedetil_bmaApproveddt.ReadOnly = True
        cAdvancedetil_bmaApproveddt.DefaultCellStyle.BackColor = Color.LightGray

        cAdvancedetil_bmaApprovedby.Name = "bma_approvedby"
        cAdvancedetil_bmaApprovedby.HeaderText = "Approve Memo By"
        cAdvancedetil_bmaApprovedby.DataPropertyName = "bma_approvedby"
        cAdvancedetil_bmaApprovedby.Width = 200
        cAdvancedetil_bmaApprovedby.Visible = True
        cAdvancedetil_bmaApprovedby.ReadOnly = True
        cAdvancedetil_bmaApprovedby.DefaultCellStyle.BackColor = Color.LightGray

        cBma_memo.Name = "bma_memo"
        cBma_memo.HeaderText = "Memo"
        cBma_memo.DataPropertyName = "bma_memo"
        cBma_memo.Width = 200
        cBma_memo.Visible = True
        cBma_memo.ReadOnly = True
        cBma_memo.DefaultCellStyle.BackColor = Color.LightGray

        cAdvancedetil_canceled.Name = "advancedetil_canceled"
        cAdvancedetil_canceled.HeaderText = "Cancel"
        cAdvancedetil_canceled.DataPropertyName = "advancedetil_canceled"
        cAdvancedetil_canceled.Width = 100
        cAdvancedetil_canceled.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        cAdvancedetil_canceled.Visible = True
        cAdvancedetil_canceled.ReadOnly = True
        cAdvancedetil_canceled.DefaultCellStyle.BackColor = Color.LightGray

        cAdvancedetil_canceleddt.Name = "advancedetil_canceleddt"
        cAdvancedetil_canceleddt.HeaderText = "Cancel Date"
        cAdvancedetil_canceleddt.DataPropertyName = "advancedetil_canceleddt"
        cAdvancedetil_canceleddt.Width = 130
        cAdvancedetil_canceleddt.DefaultCellStyle.Format = "dd/MM/yyyy"
        cAdvancedetil_canceleddt.Visible = True
        cAdvancedetil_canceleddt.ReadOnly = True
        cAdvancedetil_canceleddt.DefaultCellStyle.BackColor = Color.LightGray

        cAdvancedetil_canceledby.Name = "advancedetil_canceledby"
        cAdvancedetil_canceledby.HeaderText = "Cancel By"
        cAdvancedetil_canceledby.DataPropertyName = "advancedetil_canceledby"
        cAdvancedetil_canceledby.Width = 200
        cAdvancedetil_canceledby.Visible = True
        cAdvancedetil_canceledby.ReadOnly = True
        cAdvancedetil_canceledby.DefaultCellStyle.BackColor = Color.LightGray

        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
        {cButton_additem, cAdvancedetil_line, _
         cAdvance_id, cAdvanceDetil_refreference, cAdvancedetil_descr, cDate_column, cPayment_type, _
        cCurrency_id, cAdvanceDetil_foreignreal, cAdvanceDetil_foreignrate, cAdvanceDetil_idrreal, cAdvanceDetil_subtotal, _
        cChannel_id, cStatus_over, cAdvancedetil_approvedbma, cAdvancedetil_approvedbmadt, _
        cAdvancedetil_approvedbmaby, _
        cAdvancedetil_bmaApproved, cAdvancedetil_bmaApproveddt, cAdvancedetil_bmaApprovedby, cBma_memo, _
        cAdvancedetil_approveddescr, cAdvanceDetil_ordered, cRequestdetil_type, _
        cAdvancedetil_canceled, cAdvancedetil_canceleddt, cAdvancedetil_canceledby})
        objDgv.AutoGenerateColumns = False
        objDgv.AllowUserToAddRows = False

        For columnIndex = 0 To Me.DgvTrnAdvanceDetil.Columns.Count - 1
            Me.DgvTrnAdvanceDetil.Columns(columnIndex).SortMode = DataGridViewColumnSortMode.NotSortable
        Next
    End Function

    Private Function FormatDgvTrnAdvanceItemDetil(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        ' formating DgvTrnAdvanceItemDetil

        '''''Dim i As Integer
        Dim cAdvanceDetil_type As New System.Windows.Forms.DataGridViewComboBoxColumn
        Dim cAdvance_id As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAdvanceDetil_line As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBudgetDetil_line As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBudget_name As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cCurrency_id As New System.Windows.Forms.DataGridViewComboBoxColumn
        Dim cBudgetdetil_eps As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cButton_eps As New System.Windows.Forms.DataGridViewButtonColumn
        Dim cBudgetdetil_days As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cChannel_id As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cStrukturunit_id As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAmount_bgt As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAmount_advancebgt As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBudget_id As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cButton_budget_id As New System.Windows.Forms.DataGridViewButtonColumn
        Dim cBudgetdetil_id As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBudgetdetil_name As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cButton_budgetdetil_id As New System.Windows.Forms.DataGridViewButtonColumn
        Dim cAcc_id As New System.Windows.Forms.DataGridViewComboBoxColumn
        Dim cAcc_name As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cVQ_amount As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOutstanding_budget As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAdvancedetil_foreignrate As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAmount_idrreal As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBudget_accum As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cApproved_bma As New System.Windows.Forms.DataGridViewTextBoxColumn

        Dim cOutstanding_approved As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOutstanding_check As New System.Windows.Forms.DataGridViewCheckBoxColumn
        Dim cIsRequest As New System.Windows.Forms.DataGridViewCheckBoxColumn
        Dim cAdvance_reimburseID As New System.Windows.Forms.DataGridViewTextBoxColumn

        Dim cPph_persen As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cPph_amount As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cPpn_persen As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cPpn_amount As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cDiscount As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAmount_subtotal As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAmount_subtotalforeign As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cPpn_no As New System.Windows.Forms.DataGridViewTextBoxColumn

        Dim cAdvancedetil_bmaApproved As New System.Windows.Forms.DataGridViewCheckBoxColumn
        Dim cAdvancedetil_bmaApproveddt As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAdvancedetil_bmaApprovedby As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBma_memo As New System.Windows.Forms.DataGridViewTextBoxColumn

        Dim cAmount_intercompany As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAmount_sum As New System.Windows.Forms.DataGridViewTextBoxColumn

        cAdvanceDetil_type.Name = "advancedetil_type"
        cAdvanceDetil_type.HeaderText = "Type"
        cAdvanceDetil_type.DataPropertyName = "advancedetil_type"

        If tbl_Trnrequestdetil_type.Columns("display_type") IsNot Nothing Then
            cAdvanceDetil_type.DataSource = Me.tbl_Trnrequestdetil_type
            cAdvanceDetil_type.ValueMember = "value_type"
            cAdvanceDetil_type.DisplayMember = "display_type"
        End If

        cAdvanceDetil_type.DisplayStyleForCurrentCellOnly = True
        cAdvanceDetil_type.Width = 100
        cAdvanceDetil_type.Frozen = False
        cAdvanceDetil_type.Visible = False
        cAdvanceDetil_type.ReadOnly = True
        cAdvanceDetil_type.DefaultCellStyle.BackColor = Color.Gainsboro
        cAdvanceDetil_type.SortMode = DataGridViewColumnSortMode.NotSortable

        cAdvance_id.Name = "advance_id"
        cAdvance_id.HeaderText = "Advance ID"
        cAdvance_id.DataPropertyName = "advance_id"
        cAdvance_id.Width = 100
        cAdvance_id.Visible = False
        cAdvance_id.ReadOnly = True
        cAdvance_id.DefaultCellStyle.BackColor = Color.Gainsboro
        cAdvance_id.SortMode = DataGridViewColumnSortMode.NotSortable

        cAdvanceDetil_line.Name = "advancedetil_line"
        cAdvanceDetil_line.HeaderText = "Line"
        cAdvanceDetil_line.DataPropertyName = "advancedetil_line"
        cAdvanceDetil_line.Width = 40
        cAdvanceDetil_line.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cAdvanceDetil_line.Visible = True
        cAdvanceDetil_line.ReadOnly = True
        cAdvanceDetil_line.DefaultCellStyle.BackColor = Color.LightGray
        cAdvanceDetil_line.SortMode = DataGridViewColumnSortMode.NotSortable

        cBudgetDetil_line.Name = "budgetdetil_line"
        cBudgetDetil_line.HeaderText = "Budget Line"
        cBudgetDetil_line.DataPropertyName = "budgetdetil_line"
        cBudgetDetil_line.Width = 100
        cBudgetDetil_line.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cBudgetDetil_line.Visible = True
        cBudgetDetil_line.ReadOnly = True
        cBudgetDetil_line.DefaultCellStyle.BackColor = Color.LightGray
        cBudgetDetil_line.SortMode = DataGridViewColumnSortMode.NotSortable

        cCurrency_id.Name = "currency_id"
        cCurrency_id.HeaderText = "Currency"
        cCurrency_id.DataPropertyName = "currency_id"
        cCurrency_id.Width = 125
        cCurrency_id.ValueMember = "currency_id"
        cCurrency_id.DisplayMember = "currency_shortname"
        cCurrency_id.DataSource = Me.tbl_MstCurrencyDetil
        cCurrency_id.DisplayStyleForCurrentCellOnly = True
        cCurrency_id.Visible = True
        cCurrency_id.ReadOnly = True
        cCurrency_id.DefaultCellStyle.BackColor = Color.LightGray
        cCurrency_id.SortMode = DataGridViewColumnSortMode.NotSortable

        cBudgetdetil_eps.Name = "budgetdetil_eps"
        cBudgetdetil_eps.HeaderText = "Eps."
        cBudgetdetil_eps.DataPropertyName = "budgetdetil_eps"
        cBudgetdetil_eps.Width = 80
        cBudgetdetil_eps.Visible = True
        cBudgetdetil_eps.ReadOnly = True
        cBudgetdetil_eps.DefaultCellStyle.BackColor = Color.LightGray
        cBudgetdetil_eps.SortMode = DataGridViewColumnSortMode.NotSortable

        cButton_eps.Name = "select_eps"
        cButton_eps.HeaderText = ""
        cButton_eps.Text = "..."
        cButton_eps.UseColumnTextForButtonValue = True
        cButton_eps.CellTemplate.Style.BackColor = Color.LightGray
        cButton_eps.Width = 30
        cButton_eps.DividerWidth = 3
        cButton_eps.Visible = False
        cButton_eps.ReadOnly = True
        cButton_eps.SortMode = DataGridViewColumnSortMode.NotSortable

        cBudgetdetil_days.Name = "budgetdetil_days"
        cBudgetdetil_days.HeaderText = "Days"
        cBudgetdetil_days.DataPropertyName = "budgetdetil_days"
        cBudgetdetil_days.Width = 40
        cBudgetdetil_days.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cBudgetdetil_days.Visible = False
        cBudgetdetil_days.ReadOnly = False
        cBudgetdetil_days.SortMode = DataGridViewColumnSortMode.NotSortable

        cAcc_id.Name = "acc_id"
        cAcc_id.HeaderText = "Account"
        cAcc_id.DataPropertyName = "acc_id"
        cAcc_id.Width = 125
        cAcc_id.ValueMember = "acc_id"
        cAcc_id.DisplayMember = "acc_nameshort"
        cAcc_id.DataSource = Me.tbl_MstAcc
        cAcc_id.DisplayStyleForCurrentCellOnly = True
        cAcc_id.Visible = True
        cAcc_id.ReadOnly = True
        cAcc_id.DefaultCellStyle.BackColor = Color.LightGray
        cAcc_id.SortMode = DataGridViewColumnSortMode.NotSortable

        cAcc_name.Name = "account"
        cAcc_name.HeaderText = "Account"
        cAcc_name.DataPropertyName = "account"
        cAcc_name.Width = 125
        cAcc_name.Visible = False
        cAcc_name.ReadOnly = True
        cAcc_name.DefaultCellStyle.BackColor = Color.LightGray
        cAcc_name.SortMode = DataGridViewColumnSortMode.NotSortable

        cChannel_id.Name = "channel_id"
        cChannel_id.HeaderText = "channel_id"
        cChannel_id.DataPropertyName = "channel_id"
        cChannel_id.Width = 100
        cChannel_id.Visible = False
        cChannel_id.ReadOnly = False
        cChannel_id.SortMode = DataGridViewColumnSortMode.NotSortable

        cStrukturunit_id.Name = "strukturunit_id"
        cStrukturunit_id.HeaderText = "strukturunit_id"
        cStrukturunit_id.DataPropertyName = "strukturunit_id"
        cStrukturunit_id.Width = 100
        cStrukturunit_id.Visible = False
        cStrukturunit_id.ReadOnly = False
        cStrukturunit_id.SortMode = DataGridViewColumnSortMode.NotSortable

        cAmount_bgt.Name = "amount_budget"
        cAmount_bgt.HeaderText = "Budget Amount"
        cAmount_bgt.DataPropertyName = "amount_budget"
        cAmount_bgt.Width = 125
        cAmount_bgt.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cAmount_bgt.DefaultCellStyle.Format = "#,##0.00"
        cAmount_bgt.Visible = True
        cAmount_bgt.ReadOnly = True
        cAmount_bgt.DefaultCellStyle.BackColor = Color.LightGray
        cAmount_bgt.SortMode = DataGridViewColumnSortMode.NotSortable

        cAmount_advancebgt.Name = "amount_advance"
        cAmount_advancebgt.HeaderText = "Amount"
        cAmount_advancebgt.DataPropertyName = "amount_advance"
        cAmount_advancebgt.Width = 125
        cAmount_advancebgt.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cAmount_advancebgt.DefaultCellStyle.Format = "#,##0.00"
        cAmount_advancebgt.Visible = True
        cAmount_advancebgt.ReadOnly = True
        cAmount_advancebgt.DefaultCellStyle.BackColor = Color.LightGray
        cAmount_advancebgt.SortMode = DataGridViewColumnSortMode.NotSortable

        cBudget_id.Name = "budget_id"
        cBudget_id.HeaderText = "ID"
        cBudget_id.DataPropertyName = "budget_id"
        cBudget_id.Width = 100
        cBudget_id.Visible = False
        cBudget_id.ReadOnly = True
        cBudget_id.SortMode = DataGridViewColumnSortMode.NotSortable

        cBudget_name.Name = "budget_name"
        cBudget_name.HeaderText = "Budget Name"
        cBudget_name.DataPropertyName = "budget_name"
        cBudget_name.Width = 200
        cBudget_name.Visible = True
        cBudget_name.ReadOnly = True
        cBudget_name.DefaultCellStyle.BackColor = Color.LightGray
        cBudget_name.SortMode = DataGridViewColumnSortMode.NotSortable

        cButton_budget_id.Name = "select_budget_header"
        cButton_budget_id.HeaderText = ""
        cButton_budget_id.Text = "..."
        cButton_budget_id.UseColumnTextForButtonValue = True
        cButton_budget_id.CellTemplate.Style.BackColor = Color.LightGray
        cButton_budget_id.Width = 30
        cButton_budget_id.DividerWidth = 3
        cButton_budget_id.Visible = False
        cButton_budget_id.ReadOnly = False
        cButton_budget_id.SortMode = DataGridViewColumnSortMode.NotSortable

        cButton_budgetdetil_id.Name = "select_budget_detil"
        cButton_budgetdetil_id.HeaderText = ""
        cButton_budgetdetil_id.Text = "..."
        cButton_budgetdetil_id.UseColumnTextForButtonValue = True
        cButton_budgetdetil_id.CellTemplate.Style.BackColor = Color.LightGray
        cButton_budgetdetil_id.Width = 30
        cButton_budgetdetil_id.DividerWidth = 3
        cButton_budgetdetil_id.Visible = False
        cButton_budgetdetil_id.ReadOnly = False
        cButton_budgetdetil_id.SortMode = DataGridViewColumnSortMode.NotSortable

        cBudgetdetil_name.Name = "budgetdetil_name"
        cBudgetdetil_name.HeaderText = "Budget Detil Name"
        cBudgetdetil_name.DataPropertyName = "budgetdetil_name"
        cBudgetdetil_name.Visible = True
        cBudgetdetil_name.Width = 200
        cBudgetdetil_name.ReadOnly = True
        cBudgetdetil_name.DefaultCellStyle.BackColor = Color.LightGray
        cBudgetdetil_name.SortMode = DataGridViewColumnSortMode.NotSortable

        cBudgetdetil_id.Name = "budgetdetil_id"
        cBudgetdetil_id.HeaderText = "Code"
        cBudgetdetil_id.DataPropertyName = "budgetdetil_id"
        cBudgetdetil_id.Width = 100
        cBudgetdetil_id.Visible = True
        cBudgetdetil_id.ReadOnly = True
        cBudgetdetil_id.DefaultCellStyle.BackColor = Color.LightGray
        cBudgetdetil_id.SortMode = DataGridViewColumnSortMode.NotSortable

        cVQ_amount.Name = "vq_amount"
        cVQ_amount.HeaderText = "Advance Accum."
        cVQ_amount.DataPropertyName = "vq_amount"
        cVQ_amount.Width = 125
        cVQ_amount.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cVQ_amount.DefaultCellStyle.Format = "#,##0.00"
        cVQ_amount.Visible = False
        cVQ_amount.ReadOnly = True
        cVQ_amount.SortMode = DataGridViewColumnSortMode.NotSortable

        cOutstanding_budget.Name = "outstanding_budget"
        cOutstanding_budget.HeaderText = "Budget Outstand."
        ''''cOutstanding_budget.DataPropertyName = "outstanding_budget"
        cOutstanding_budget.Width = 125
        cOutstanding_budget.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cOutstanding_budget.DefaultCellStyle.Format = "#,##0.00"
        cOutstanding_budget.DefaultCellStyle.BackColor = Color.LightGray
        cOutstanding_budget.Visible = False
        cOutstanding_budget.ReadOnly = True
        cOutstanding_budget.SortMode = DataGridViewColumnSortMode.NotSortable

        cAdvancedetil_foreignrate.Name = "advancedetil_foreignrate"
        cAdvancedetil_foreignrate.HeaderText = "Rate"
        cAdvancedetil_foreignrate.DataPropertyName = "advancedetil_foreignrate"
        cAdvancedetil_foreignrate.Width = 125
        cAdvancedetil_foreignrate.Visible = True
        cAdvancedetil_foreignrate.ReadOnly = True
        cAdvancedetil_foreignrate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cAdvancedetil_foreignrate.DefaultCellStyle.Format = "#,##0.00"
        cAdvancedetil_foreignrate.DefaultCellStyle.BackColor = Color.LightGray
        cAdvancedetil_foreignrate.SortMode = DataGridViewColumnSortMode.NotSortable

        cAmount_idrreal.Name = "amount_idrreal"
        cAmount_idrreal.HeaderText = "Amount IDR"
        cAmount_idrreal.DataPropertyName = "amount_idrreal"
        cAmount_idrreal.Width = 125
        cAmount_idrreal.Visible = True
        cAmount_idrreal.ReadOnly = True
        cAmount_idrreal.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cAmount_idrreal.DefaultCellStyle.Format = "#,##0.00"
        cAmount_idrreal.DefaultCellStyle.BackColor = Color.LightGray
        cAmount_idrreal.SortMode = DataGridViewColumnSortMode.NotSortable

        cBudget_accum.Name = "budget_accum"
        cBudget_accum.HeaderText = "Budget Accum"
        cBudget_accum.DataPropertyName = "budget_accum"
        cBudget_accum.Width = 125
        cBudget_accum.Visible = True
        cBudget_accum.ReadOnly = True
        cBudget_accum.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cBudget_accum.DefaultCellStyle.Format = "#,##0.00"
        cBudget_accum.DefaultCellStyle.BackColor = Color.LightGray
        cBudget_accum.SortMode = DataGridViewColumnSortMode.NotSortable

        cApproved_bma.Name = "amount_approvebma"
        cApproved_bma.HeaderText = "Amount Approve BMA"
        cApproved_bma.DataPropertyName = "amount_approvebma"
        cApproved_bma.Width = 150
        ''''If Me._USERSTRUKTURUNIT = Department.BMA Then
        cApproved_bma.Visible = True
        ''''Else
        ''''cApproved_bma.Visible = False
        ''''End If
        cApproved_bma.ReadOnly = True
        cApproved_bma.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cApproved_bma.DefaultCellStyle.Format = "#,##0.00"
        cApproved_bma.DefaultCellStyle.BackColor = Color.LightGray
        cApproved_bma.SortMode = DataGridViewColumnSortMode.NotSortable

        cOutstanding_approved.Name = "outstanding_approved"
        If Me._USERSTRUKTURUNIT = Department.BMA Then
            cOutstanding_approved.HeaderText = "Outstand. When Approved"
        Else
            cOutstanding_approved.HeaderText = "Budget Outstand."
        End If
        cOutstanding_approved.DataPropertyName = "outstanding_approved"
        cOutstanding_approved.Width = 180
        cOutstanding_approved.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cOutstanding_approved.DefaultCellStyle.Format = "#,##0.00"
        cOutstanding_approved.Visible = True
        cOutstanding_approved.ReadOnly = True
        cOutstanding_approved.DefaultCellStyle.BackColor = Color.Gainsboro
        cOutstanding_approved.SortMode = DataGridViewColumnSortMode.NotSortable

        cOutstanding_check.Name = "outstanding_check"
        cOutstanding_check.HeaderText = "Check"
        cOutstanding_check.DataPropertyName = "outstanding_check"
        cOutstanding_check.Width = 60
        If Me._USERSTRUKTURUNIT = Department.BMA Then
            cOutstanding_check.Visible = True
        Else
            cOutstanding_check.Visible = False
        End If
        cOutstanding_check.ReadOnly = True
        cOutstanding_check.DefaultCellStyle.BackColor = Color.Gainsboro
        cOutstanding_check.SortMode = DataGridViewColumnSortMode.NotSortable

        cIsRequest.Name = "advance_isrequest"
        cIsRequest.HeaderText = "IsRequest"
        cIsRequest.DataPropertyName = "advance_isrequest"
        cIsRequest.Width = 60
        cIsRequest.Visible = False
        cIsRequest.ReadOnly = True
        cIsRequest.DefaultCellStyle.BackColor = Color.Gainsboro
        cIsRequest.SortMode = DataGridViewColumnSortMode.NotSortable

        '' ''If Me._SOURCE = "Reimburse Settlement" Then
        '' ''    cAdvance_reimburseID.Name = "advance_id_reimburse"
        '' ''    cAdvance_reimburseID.HeaderText = "Advance ID"
        '' ''    cAdvance_reimburseID.DataPropertyName = "advance_id_reimburse"
        '' ''    cAdvance_reimburseID.Width = 100
        '' ''    cAdvance_reimburseID.Visible = True
        '' ''    cAdvance_reimburseID.ReadOnly = True
        '' ''    cAdvance_reimburseID.DefaultCellStyle.BackColor = Color.Gainsboro
        '' ''Else
        cAdvance_reimburseID.Name = "advance_reimburseid"
        cAdvance_reimburseID.HeaderText = "Reimburse ID"
        cAdvance_reimburseID.DataPropertyName = "advance_reimburseid"
        cAdvance_reimburseID.Width = 100
        cAdvance_reimburseID.Visible = True
        cAdvance_reimburseID.ReadOnly = True
        cAdvance_reimburseID.DefaultCellStyle.BackColor = Color.Gainsboro
        ''''End If

        cPph_persen.Name = "pph_persen"
        cPph_persen.HeaderText = "Pph(%)"
        cPph_persen.DataPropertyName = "pph_persen"
        cPph_persen.Width = 50
        cPph_persen.DefaultCellStyle.Format = "#,##0.00"
        cPph_persen.Visible = True
        cPph_persen.ReadOnly = True
        cPph_persen.DefaultCellStyle.BackColor = Color.Gainsboro
        cPph_persen.SortMode = DataGridViewColumnSortMode.NotSortable

        cPph_amount.Name = "pph_amount"
        cPph_amount.HeaderText = "Pph Amount"
        cPph_amount.DataPropertyName = "pph_amount"
        cPph_amount.Width = 120
        cPph_amount.DefaultCellStyle.Format = "#,##0.00"
        cPph_amount.Visible = True
        cPph_amount.ReadOnly = True
        cPph_amount.DefaultCellStyle.BackColor = Color.Gainsboro
        cPph_amount.SortMode = DataGridViewColumnSortMode.NotSortable

        cPpn_persen.Name = "ppn_persen"
        cPpn_persen.HeaderText = "Ppn(%)"
        cPpn_persen.DataPropertyName = "ppn_persen"
        cPpn_persen.Width = 50
        cPpn_persen.DefaultCellStyle.Format = "#,##0.00"
        cPpn_persen.Visible = True
        cPpn_persen.ReadOnly = True
        cPpn_persen.DefaultCellStyle.BackColor = Color.Gainsboro
        cPpn_persen.SortMode = DataGridViewColumnSortMode.NotSortable

        cPpn_amount.Name = "ppn_amount"
        cPpn_amount.HeaderText = "Ppn Amount"
        cPpn_amount.DataPropertyName = "ppn_amount"
        cPpn_amount.Width = 120
        cPpn_amount.DefaultCellStyle.Format = "#,##0.00"
        cPpn_amount.Visible = True
        cPpn_amount.ReadOnly = True
        cPpn_amount.DefaultCellStyle.BackColor = Color.Gainsboro
        cPpn_amount.SortMode = DataGridViewColumnSortMode.NotSortable

        cPpn_no.Name = "faktur_id"
        cPpn_no.HeaderText = "Ppn No."
        cPpn_no.DataPropertyName = "faktur_id"
        cPpn_no.Width = 120
        cPpn_no.Visible = True
        cPpn_no.ReadOnly = True
        cPpn_no.DefaultCellStyle.BackColor = Color.Gainsboro
        cPpn_no.SortMode = DataGridViewColumnSortMode.NotSortable

        cDiscount.Name = "advancedetil_discount"
        cDiscount.HeaderText = "Discount"
        cDiscount.DataPropertyName = "advancedetil_discount"
        cDiscount.Width = 120
        cDiscount.DefaultCellStyle.Format = "#,##0.00"
        cDiscount.Visible = True
        cDiscount.ReadOnly = True
        cDiscount.DefaultCellStyle.BackColor = Color.Gainsboro
        cDiscount.SortMode = DataGridViewColumnSortMode.NotSortable

        cAmount_subtotal.Name = "amount_subtotal"
        cAmount_subtotal.HeaderText = "Subtotal"
        cAmount_subtotal.DataPropertyName = "amount_subtotal"
        cAmount_subtotal.Width = 125
        cAmount_subtotal.Visible = True
        cAmount_subtotal.ReadOnly = True
        cAmount_subtotal.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cAmount_subtotal.DefaultCellStyle.Format = "#,##0.00"
        cAmount_subtotal.DefaultCellStyle.BackColor = Color.LightGray
        cAmount_subtotal.SortMode = DataGridViewColumnSortMode.NotSortable

        cAmount_subtotalforeign.Name = "amount_subtotalforeign"
        cAmount_subtotalforeign.HeaderText = "Subtotal Foreign"
        cAmount_subtotalforeign.DataPropertyName = "amount_subtotalforeign"
        cAmount_subtotalforeign.Width = 125
        cAmount_subtotalforeign.Visible = True
        cAmount_subtotalforeign.ReadOnly = True
        cAmount_subtotalforeign.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cAmount_subtotalforeign.DefaultCellStyle.Format = "#,##0.00"
        cAmount_subtotalforeign.DefaultCellStyle.BackColor = Color.LightGray
        cAmount_subtotalforeign.SortMode = DataGridViewColumnSortMode.NotSortable

        cAmount_intercompany.Name = "amount_intercompany"
        cAmount_intercompany.HeaderText = "Amount Inter Company"
        cAmount_intercompany.DataPropertyName = "amount_intercompany"
        cAmount_intercompany.Width = 130
        cAmount_intercompany.Visible = True
        cAmount_intercompany.ReadOnly = True
        cAmount_intercompany.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cAmount_intercompany.DefaultCellStyle.Format = "#,##0.00"
        cAmount_intercompany.DefaultCellStyle.BackColor = Color.LightGray
        cAmount_intercompany.SortMode = DataGridViewColumnSortMode.NotSortable

        cAmount_sum.Name = "amount_sum"
        cAmount_sum.HeaderText = "Amount Travel"
        cAmount_sum.DataPropertyName = "amount_sum"
        cAmount_sum.Width = 130
        cAmount_sum.Visible = False
        cAmount_sum.ReadOnly = True
        cAmount_sum.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cAmount_sum.DefaultCellStyle.Format = "#,##0.00"
        cAmount_sum.DefaultCellStyle.BackColor = Color.LightGray
        cAmount_sum.SortMode = DataGridViewColumnSortMode.NotSortable

        cAdvancedetil_bmaApproved.Name = "bma_approved"
        cAdvancedetil_bmaApproved.HeaderText = "Approve Memo"
        cAdvancedetil_bmaApproved.DataPropertyName = "bma_approved"
        cAdvancedetil_bmaApproved.Width = 100
        cAdvancedetil_bmaApproved.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        cAdvancedetil_bmaApproved.Visible = True
        cAdvancedetil_bmaApproved.ReadOnly = True
        cAdvancedetil_bmaApproved.DefaultCellStyle.BackColor = Color.LightGray

        cAdvancedetil_bmaApproveddt.Name = "bma_approveddt"
        cAdvancedetil_bmaApproveddt.HeaderText = "Approve Memo Date"
        cAdvancedetil_bmaApproveddt.DataPropertyName = "bma_approveddt"
        cAdvancedetil_bmaApproveddt.Width = 130
        cAdvancedetil_bmaApproveddt.DefaultCellStyle.Format = "dd/MM/yyyy"
        cAdvancedetil_bmaApproveddt.Visible = True
        cAdvancedetil_bmaApproveddt.ReadOnly = True
        cAdvancedetil_bmaApproveddt.DefaultCellStyle.BackColor = Color.LightGray

        cAdvancedetil_bmaApprovedby.Name = "bma_approvedby"
        cAdvancedetil_bmaApprovedby.HeaderText = "Approve Memo By"
        cAdvancedetil_bmaApprovedby.DataPropertyName = "bma_approvedby"
        cAdvancedetil_bmaApprovedby.Width = 200
        cAdvancedetil_bmaApprovedby.Visible = True
        cAdvancedetil_bmaApprovedby.ReadOnly = True
        cAdvancedetil_bmaApprovedby.DefaultCellStyle.BackColor = Color.LightGray

        cBma_memo.Name = "bma_memo"
        cBma_memo.HeaderText = "Memo"
        cBma_memo.DataPropertyName = "bma_memo"
        cBma_memo.Width = 200
        cBma_memo.Visible = True
        cBma_memo.ReadOnly = True
        cBma_memo.DefaultCellStyle.BackColor = Color.LightGray

        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
            {cAdvance_id, _
            cAdvanceDetil_line, cBudgetDetil_line, cAdvanceDetil_type, cBudgetdetil_id, cBudget_id, _
            cBudget_name, cButton_budget_id, cBudgetdetil_eps, cButton_eps, _
            cBudgetdetil_name, cButton_budgetdetil_id, _
            cAcc_id, cCurrency_id, cAmount_bgt, cBudget_accum, cApproved_bma, _
            cVQ_amount, _
            cAmount_advancebgt, cAdvancedetil_foreignrate, cAmount_idrreal, cAmount_intercompany, _
            cDiscount, cPph_persen, cPph_amount, cPpn_persen, cPpn_amount, cPpn_no, _
             cAmount_subtotalforeign, cAmount_subtotal, _
            cOutstanding_budget, cOutstanding_approved, cOutstanding_check, _
            cAdvancedetil_bmaApproved, cAdvancedetil_bmaApproveddt, cAdvancedetil_bmaApprovedby, cBma_memo, _
            cBudgetdetil_days, _
            cChannel_id, _
            cStrukturunit_id, cIsRequest, cAcc_name, cAdvance_reimburseID, cAmount_sum})
        objDgv.AutoGenerateColumns = False

        ''''For i = 0 To objDgv.Columns.Count - 1
        ''''    objDgv.Columns(i).ReadOnly = True
        ''''    objDgv.Columns(i).DefaultCellStyle.BackColor = Color.Gainsboro
        ''''Next
        ''''objDgv.DefaultCellStyle.BackColor = Color.Gainsboro
        objDgv.AllowUserToAddRows = False
        objDgv.AllowUserToDeleteRows = True
    End Function

    Private Function FormatDgvTrnRequestdetiluse(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        Dim cRequestdetil_line As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRequest_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRequestdetiluse_date As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRequestdetiluse_descr As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn

        cRequestdetil_line.Name = "requestdetil_line"
        cRequestdetil_line.HeaderText = "Line"
        cRequestdetil_line.DataPropertyName = "requestdetil_line"
        cRequestdetil_line.Width = 50
        cRequestdetil_line.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cRequestdetil_line.Visible = True
        cRequestdetil_line.ReadOnly = True

        cRequest_id.Name = "advance_id"
        cRequest_id.HeaderText = "ID"
        cRequest_id.DataPropertyName = "advance_id"
        cRequest_id.Width = 100
        cRequest_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cRequest_id.Visible = False
        cRequest_id.ReadOnly = True

        cRequestdetiluse_date.Name = "requestdetiluse_date"
        cRequestdetiluse_date.HeaderText = "Date"
        cRequestdetiluse_date.DataPropertyName = "requestdetiluse_date"
        cRequestdetiluse_date.Width = 68
        cRequestdetiluse_date.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cRequestdetiluse_date.DefaultCellStyle.Format = "dd/MM/yyyy"
        cRequestdetiluse_date.Visible = True
        cRequestdetiluse_date.ReadOnly = True

        cRequestdetiluse_descr.Name = "requestdetiluse_descr"
        cRequestdetiluse_descr.HeaderText = "Description"
        cRequestdetiluse_descr.DataPropertyName = "requestdetiluse_descr"
        cRequestdetiluse_descr.Width = 190
        cRequestdetiluse_descr.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cRequestdetiluse_descr.Visible = True
        cRequestdetiluse_descr.ReadOnly = True

        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
        {cRequestdetil_line, cRequest_id, cRequestdetiluse_date, cRequestdetiluse_descr})
        objDgv.AutoGenerateColumns = False
        objDgv.AllowUserToAddRows = False
        objDgv.AllowUserToDeleteRows = False
        objDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        objDgv.DefaultCellStyle.BackColor = Color.Gainsboro
    End Function

    Private Function FormatDgvTrnRequestdetilEps(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        Dim cBudgetdetil_line As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAdvance_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBudgetdetil_eps As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBudget_name As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn

        cBudgetdetil_line.Name = "budgetdetil_line"
        cBudgetdetil_line.HeaderText = "Line"
        cBudgetdetil_line.DataPropertyName = "budgetdetil_line"
        cBudgetdetil_line.Width = 50
        cBudgetdetil_line.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cBudgetdetil_line.Visible = True
        cBudgetdetil_line.ReadOnly = True

        cAdvance_id.Name = "advance_id"
        cAdvance_id.HeaderText = "ID"
        cAdvance_id.DataPropertyName = "advance_id"
        cAdvance_id.Width = 100
        cAdvance_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cAdvance_id.Visible = False
        cAdvance_id.ReadOnly = True

        cBudgetdetil_eps.Name = "budgetdetil_eps"
        cBudgetdetil_eps.HeaderText = "Eps"
        cBudgetdetil_eps.DataPropertyName = "budgetdetil_eps"
        cBudgetdetil_eps.Width = 68
        cBudgetdetil_eps.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cBudgetdetil_eps.Visible = True
        cBudgetdetil_eps.ReadOnly = True

        cBudget_name.Name = "budget_name"
        cBudget_name.HeaderText = "Description"
        cBudget_name.DataPropertyName = "budget_name"
        cBudget_name.Width = 190
        cBudget_name.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cBudget_name.Visible = True
        cBudget_name.ReadOnly = True

        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
        {cBudgetdetil_line, cAdvance_id, cBudgetdetil_eps, cBudget_name})
        objDgv.AutoGenerateColumns = False
        objDgv.AllowUserToAddRows = False
        objDgv.AllowUserToDeleteRows = False
        objDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        objDgv.DefaultCellStyle.BackColor = Color.Gainsboro
    End Function

    Private Function FormatDgvTrnAdvanceRefPV(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        Dim cJurnal_id As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnal_line As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnal_descr As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cCurrency_name As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAdvancedetil_foreignrate As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAdvancedetil_foreignreal As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAdvancedetil_idrreal As New System.Windows.Forms.DataGridViewTextBoxColumn

        cJurnal_line.Name = "jurnal_id_refline"
        cJurnal_line.HeaderText = "Line"
        cJurnal_line.DataPropertyName = "jurnal_id_refline"
        cJurnal_line.Width = 50
        cJurnal_line.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cJurnal_line.DefaultCellStyle.BackColor = Color.LightGray
        cJurnal_line.Visible = True
        cJurnal_line.ReadOnly = True

        cJurnal_id.Name = "jurnal_id"
        cJurnal_id.HeaderText = "ID"
        cJurnal_id.DataPropertyName = "jurnal_id"
        cJurnal_id.Width = 100
        cJurnal_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cJurnal_id.DefaultCellStyle.BackColor = Color.LightGray
        cJurnal_id.Visible = True
        cJurnal_id.ReadOnly = True

        cJurnal_descr.Name = "advancedetil_descr"
        cJurnal_descr.HeaderText = "Description"
        cJurnal_descr.DataPropertyName = "advancedetil_descr"
        cJurnal_descr.Width = 190
        cJurnal_descr.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cJurnal_descr.DefaultCellStyle.BackColor = Color.LightGray
        cJurnal_descr.Visible = True
        cJurnal_descr.ReadOnly = True

        cCurrency_name.Name = "currency_name"
        cCurrency_name.HeaderText = "Currency"
        cCurrency_name.DataPropertyName = "currency_name"
        cCurrency_name.Width = 100
        cCurrency_name.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cCurrency_name.DefaultCellStyle.BackColor = Color.LightGray
        cCurrency_name.Visible = True
        cCurrency_name.ReadOnly = True

        cAdvancedetil_foreignrate.Name = "advancedetil_foreignrate"
        cAdvancedetil_foreignrate.HeaderText = "Rate"
        cAdvancedetil_foreignrate.DataPropertyName = "advancedetil_foreignrate"
        cAdvancedetil_foreignrate.Width = 125
        cAdvancedetil_foreignrate.Visible = True
        cAdvancedetil_foreignrate.ReadOnly = True
        cAdvancedetil_foreignrate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cAdvancedetil_foreignrate.DefaultCellStyle.Format = "#,##0.00"
        cAdvancedetil_foreignrate.DefaultCellStyle.BackColor = Color.LightGray
        cAdvancedetil_foreignrate.SortMode = DataGridViewColumnSortMode.NotSortable

        cAdvancedetil_foreignreal.Name = "advancedetil_foreignreal"
        cAdvancedetil_foreignreal.HeaderText = "Amount"
        cAdvancedetil_foreignreal.DataPropertyName = "advancedetil_foreignreal"
        cAdvancedetil_foreignreal.Width = 125
        cAdvancedetil_foreignreal.Visible = True
        cAdvancedetil_foreignreal.ReadOnly = True
        cAdvancedetil_foreignreal.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cAdvancedetil_foreignreal.DefaultCellStyle.Format = "#,##0.00"
        cAdvancedetil_foreignreal.DefaultCellStyle.BackColor = Color.LightGray
        cAdvancedetil_foreignreal.SortMode = DataGridViewColumnSortMode.NotSortable

        cAdvancedetil_idrreal.Name = "advancedetil_idrreal"
        cAdvancedetil_idrreal.HeaderText = "Subtotal"
        cAdvancedetil_idrreal.DataPropertyName = "advancedetil_idrreal"
        cAdvancedetil_idrreal.Width = 125
        cAdvancedetil_idrreal.Visible = True
        cAdvancedetil_idrreal.ReadOnly = True
        cAdvancedetil_idrreal.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cAdvancedetil_idrreal.DefaultCellStyle.Format = "#,##0.00"
        cAdvancedetil_idrreal.DefaultCellStyle.BackColor = Color.LightGray
        cAdvancedetil_idrreal.SortMode = DataGridViewColumnSortMode.NotSortable

        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
        {cJurnal_line, cJurnal_id, cJurnal_descr, cCurrency_name, _
        cAdvancedetil_foreignreal, cAdvancedetil_foreignrate, cAdvancedetil_idrreal})
        objDgv.AutoGenerateColumns = False
        objDgv.AllowUserToAddRows = False
        objDgv.AllowUserToDeleteRows = False
        objDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        objDgv.DefaultCellStyle.BackColor = Color.Gainsboro
    End Function

    Private Function FormatDgvTrnRefOrder(ByRef objDgv As DataGridView) As Boolean
        Dim cAdvance_id As New DataGridViewTextBoxColumn
        Dim cAdvancedetil_line As New DataGridViewTextBoxColumn
        Dim cBudgetdetil_line As New DataGridViewTextBoxColumn
        Dim cOrder_id As New DataGridViewTextBoxColumn
        Dim cOrderdetil_line As New DataGridViewTextBoxColumn
        Dim cBudget_id As New DataGridViewTextBoxColumn
        Dim cBudgetdetil_id As New DataGridViewTextBoxColumn
        Dim cCurrency_id As New DataGridViewTextBoxColumn
        Dim cAmount_order As New DataGridViewTextBoxColumn
        Dim cAmount_advance As New DataGridViewTextBoxColumn
        Dim cAmount_sisa As New DataGridViewTextBoxColumn
        Dim cOrderdetil_qty As New DataGridViewTextBoxColumn
        Dim cOrderdetil_pphpercent As New DataGridViewTextBoxColumn
        Dim cOrderdetil_ppnpercent As New DataGridViewTextBoxColumn
        Dim cOrderdetil_pphamount As New DataGridViewTextBoxColumn
        Dim cOrderdetil_ppnamount As New DataGridViewTextBoxColumn
        Dim cOrderdetil_days As New DataGridViewTextBoxColumn
        Dim cItem_id As New DataGridViewTextBoxColumn
        Dim cOrderdetil_foreignrate As New DataGridViewTextBoxColumn
        Dim cAcc_id As New DataGridViewTextBoxColumn
        Dim cAccount As New DataGridViewTextBoxColumn
        Dim cDiscount As New DataGridViewTextBoxColumn

        cAdvance_id.Name = "advance_id"
        cAdvance_id.HeaderText = "Advance ID"
        cAdvance_id.DataPropertyName = "advance_id"
        cAdvance_id.Width = 100
        cAdvance_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cAdvance_id.Visible = True
        cAdvance_id.ReadOnly = True

        cAdvancedetil_line.Name = "advancedetil_line"
        cAdvancedetil_line.HeaderText = "advancedetil_line"
        cAdvancedetil_line.DataPropertyName = "advancedetil_line"
        cAdvancedetil_line.Width = 100
        cAdvancedetil_line.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cAdvancedetil_line.Visible = False
        cAdvancedetil_line.ReadOnly = True

        cBudgetdetil_line.Name = "budgetdetil_line"
        cBudgetdetil_line.HeaderText = "budgetdetil_line"
        cBudgetdetil_line.DataPropertyName = "budgetdetil_line"
        cBudgetdetil_line.Width = 100
        cBudgetdetil_line.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cBudgetdetil_line.Visible = False
        cBudgetdetil_line.ReadOnly = True

        cOrder_id.Name = "order_id"
        cOrder_id.HeaderText = "Travel ID"
        cOrder_id.DataPropertyName = "order_id"
        cOrder_id.Width = 100
        cOrder_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cOrder_id.Visible = True
        cOrder_id.ReadOnly = True

        cOrderdetil_line.Name = "orderdetil_line"
        cOrderdetil_line.HeaderText = "Travel Line"
        cOrderdetil_line.DataPropertyName = "orderdetil_line"
        cOrderdetil_line.Width = 100
        cOrderdetil_line.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cOrderdetil_line.Visible = True
        cOrderdetil_line.ReadOnly = True

        cBudget_id.Name = "budget_id"
        cBudget_id.HeaderText = "Budget ID"
        cBudget_id.DataPropertyName = "budget_id"
        cBudget_id.Width = 100
        cBudget_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cBudget_id.Visible = True
        cBudget_id.ReadOnly = True

        cBudgetdetil_id.Name = "budgetdetil_id"
        cBudgetdetil_id.HeaderText = "Budgetdetil ID"
        cBudgetdetil_id.DataPropertyName = "budgetdetil_id"
        cBudgetdetil_id.Width = 100
        cBudgetdetil_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cBudgetdetil_id.Visible = True
        cBudgetdetil_id.ReadOnly = True

        cCurrency_id.Name = "currency_id"
        cCurrency_id.HeaderText = "Curr"
        cCurrency_id.DataPropertyName = "currency_id"
        cCurrency_id.Width = 100
        cCurrency_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cCurrency_id.Visible = True
        cCurrency_id.ReadOnly = True

        cAmount_order.Name = "amount_order"
        cAmount_order.HeaderText = "Amount Travel"
        cAmount_order.DataPropertyName = "amount_order"
        cAmount_order.Width = 120
        cAmount_order.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cAmount_order.DefaultCellStyle.Format = "#,###,##0.00"
        cAmount_order.Visible = False
        cAmount_order.ReadOnly = True

        cAmount_advance.Name = "amount_advance"
        cAmount_advance.HeaderText = "Amount Advance"
        cAmount_advance.DataPropertyName = "amount_advance"
        cAmount_advance.Width = 120
        cAmount_advance.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cAmount_advance.DefaultCellStyle.Format = "#,###,##0.00"
        cAmount_advance.Visible = True
        cAmount_advance.ReadOnly = True

        cAmount_sisa.Name = "amount_sisa"
        cAmount_sisa.HeaderText = "Amount Sisa"
        cAmount_sisa.DataPropertyName = "amount_sisa"
        cAmount_sisa.Width = 100
        cAmount_sisa.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cAmount_sisa.DefaultCellStyle.Format = "#,###,##0.00"
        cAmount_sisa.Visible = False
        cAmount_sisa.ReadOnly = True

        cOrderdetil_qty.Name = "orderdetil_qty"
        cOrderdetil_qty.HeaderText = "Qty"
        cOrderdetil_qty.DataPropertyName = "orderdetil_qty"
        cOrderdetil_qty.Width = 100
        cOrderdetil_qty.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cOrderdetil_qty.DefaultCellStyle.Format = "#,###,##0.00"
        cOrderdetil_qty.Visible = False
        cOrderdetil_qty.ReadOnly = True

        cOrderdetil_pphpercent.Name = "orderdetil_pphpercent"
        cOrderdetil_pphpercent.HeaderText = "PPh[%]"
        cOrderdetil_pphpercent.DataPropertyName = "orderdetil_pphpercent"
        cOrderdetil_pphpercent.Width = 100
        cOrderdetil_pphpercent.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cOrderdetil_pphpercent.DefaultCellStyle.Format = "#,###,##0.00"
        cOrderdetil_pphpercent.Visible = False
        cOrderdetil_pphpercent.ReadOnly = True

        cOrderdetil_ppnpercent.Name = "orderdetil_ppnpercent"
        cOrderdetil_ppnpercent.HeaderText = "PPN[%]"
        cOrderdetil_ppnpercent.DataPropertyName = "orderdetil_ppnpercent"
        cOrderdetil_ppnpercent.Width = 100
        cOrderdetil_ppnpercent.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cOrderdetil_ppnpercent.DefaultCellStyle.Format = "#,###,##0.00"
        cOrderdetil_ppnpercent.Visible = False
        cOrderdetil_ppnpercent.ReadOnly = True

        cOrderdetil_pphamount.Name = "orderdetil_pphamount"
        cOrderdetil_pphamount.HeaderText = "PPh Amount"
        cOrderdetil_pphamount.DataPropertyName = "orderdetil_pphamount"
        cOrderdetil_pphamount.Width = 100
        cOrderdetil_pphamount.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cOrderdetil_pphamount.DefaultCellStyle.Format = "#,###,##0.00"
        cOrderdetil_pphamount.Visible = False
        cOrderdetil_pphamount.ReadOnly = True

        cOrderdetil_ppnamount.Name = "orderdetil_ppnamount"
        cOrderdetil_ppnamount.HeaderText = "PPN amount"
        cOrderdetil_ppnamount.DataPropertyName = "orderdetil_ppnamount"
        cOrderdetil_ppnamount.Width = 100
        cOrderdetil_ppnamount.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cOrderdetil_ppnamount.DefaultCellStyle.Format = "#,###,##0.00"
        cOrderdetil_ppnamount.Visible = False
        cOrderdetil_ppnamount.ReadOnly = True

        cOrderdetil_days.Name = "orderdetil_days"
        cOrderdetil_days.HeaderText = "Days"
        cOrderdetil_days.DataPropertyName = "orderdetil_days"
        cOrderdetil_days.Width = 100
        cOrderdetil_days.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cOrderdetil_days.DefaultCellStyle.Format = "#,###,##0.00"
        cOrderdetil_days.Visible = False
        cOrderdetil_days.ReadOnly = True

        cItem_id.Name = "item_id"
        cItem_id.HeaderText = "Item ID"
        cItem_id.DataPropertyName = "item_id"
        cItem_id.Width = 100
        cItem_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cItem_id.Visible = False
        cItem_id.ReadOnly = True

        cOrderdetil_foreignrate.Name = "orderdetil_foreignrate"
        cOrderdetil_foreignrate.HeaderText = "Rate"
        cOrderdetil_foreignrate.DataPropertyName = "orderdetil_foreignrate"
        cOrderdetil_foreignrate.Width = 100
        cOrderdetil_foreignrate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cOrderdetil_foreignrate.DefaultCellStyle.Format = "#,###,##0.00"
        cOrderdetil_foreignrate.Visible = False
        cOrderdetil_foreignrate.ReadOnly = True

        cAcc_id.Name = "acc_id"
        cAcc_id.HeaderText = "acc_id"
        cAcc_id.DataPropertyName = "acc_id"
        cAcc_id.Width = 100
        cAcc_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cAcc_id.Visible = False
        cAcc_id.ReadOnly = True

        cAccount.Name = "account"
        cAccount.HeaderText = "Account"
        cAccount.DataPropertyName = "account"
        cAccount.Width = 100
        cAccount.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cAccount.Visible = False
        cAccount.ReadOnly = True

        cDiscount.Name = "orderdetil_discount"
        cDiscount.HeaderText = "Discount"
        cDiscount.DataPropertyName = "orderdetil_discount"
        cDiscount.Width = 100
        cDiscount.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cDiscount.DefaultCellStyle.Format = "#,###,##0.00"
        cDiscount.Visible = False
        cDiscount.ReadOnly = True

        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New DataGridViewColumn() _
        {cAdvance_id, cAdvancedetil_line, cBudgetdetil_line, _
        cOrder_id, cOrderdetil_line, cBudget_id, _
        cBudgetdetil_id, cCurrency_id, cAmount_order, cDiscount, _
        cAmount_advance, cAmount_sisa, cOrderdetil_qty, _
        cOrderdetil_pphpercent, cOrderdetil_ppnpercent, _
        cOrderdetil_pphamount, cOrderdetil_ppnamount, _
        cOrderdetil_days, cItem_id, _
        cOrderdetil_foreignrate, cAcc_id, cAccount})
        objDgv.AutoGenerateColumns = False
        objDgv.AllowUserToAddRows = False
        objDgv.AllowUserToDeleteRows = False
    End Function

    Private Function InitLayoutUI() As Boolean
        Me.ftabMain.Anchor = AnchorStyles.Bottom
        Me.ftabMain.Anchor += AnchorStyles.Top
        Me.ftabMain.Anchor += AnchorStyles.Right
        Me.ftabMain.Anchor += AnchorStyles.Left

        Me.ftabMain.TabPages.Item(1).BackColor = Color.Gainsboro
        Me.PnlDfSearch.Dock = DockStyle.Top
        Me.PnlDfSearch.Visible = False
        Me.PnlDfMain.Dock = DockStyle.Fill
        Me.DgvTrnAdvance.Dock = DockStyle.Fill

        Me.ftabDataDetil_Eps.Dispose()

        ' ''Me.FormatDgvTrnAdvance(Me.DgvTrnAdvance)
        ' ''Me.FormatDgvTrnAdvanceDetil(Me.DgvTrnAdvanceDetil)
        ' ''Me.FormatDgvTrnAdvanceItemDetil(Me.DgvItemBudgetDetil)
        Me.FormatDgvTrnRequestdetiluse(Me.DgvTrnRefRequest)
        Me.FormatDgvTrnRequestdetilEps(Me.DgvEps)
        Me.FormatDgvTrnAdvanceRefPV(Me.DgvRefPv)
        'Tambahan
        Me.DgvTrnAdvanceDetil.Dock = DockStyle.Fill
    End Function

    'tambahan Form Mode
    Private Function uiTransaksiAdvanceRequest_SetViewOnly() As Boolean
        Dim activeColor As Color = Color.White
        Dim lockColor As Color = Color.Gainsboro
        Dim oDataFiller As New clsDataFiller(Me.DSN)

        'NavigationButton
        Me.tbtnDel.Enabled = False
        Me.tbtnEdit.Enabled = False
        Me.tbtnNew.Enabled = False
        Me.tbtnPrint.Enabled = False
        Me.tbtnPrintPreview.Enabled = False
        Me.tbtnSave.Enabled = False
        Me.tbtnDel.Enabled = False

        obj_Advance_entrydt.Enabled = False
        obj_Advance_entryby.Enabled = False
        obj_strukturunit_id_dest.Enabled = False
        obj_Advance_usedby.Enabled = False
        obj_RequestType.Enabled = False

        obj_budget_id_view.Enabled = False
        obj_budget_id_code.Enabled = False

        obj_Request_formid.Enabled = False
        obj_Request_jurnalisposted.Enabled = False
        obj_Advance_epsstart.Enabled = False
        obj_Advance_epsend.Enabled = False
        obj_Advance_currency.Enabled = False

        'add/del item and description
        cmdAddItemManual.Enabled = False
        cmdAddDesc.Enabled = False
        cmdDelDesc.Enabled = False
        obj_Request_active.Enabled = False

        'user info
        obj_Request_preparedt.Enabled = False
        obj_advance_prepare_dt.Enabled = False
        obj_Advance_preparedt_time.Enabled = False
        obj_Request_useddt.Enabled = False
        obj_Request_useddt_date.Enabled = False
        obj_Request_useddt_time.Enabled = False
        obj_Request_useddt2.Enabled = False
        obj_Request_useddt2_date.Enabled = False
        obj_Request_useddt2_time.Enabled = False

        obj_Advance_approved1dt.Enabled = False
        obj_Advance_modifieddt.Enabled = False
        obj_Advance_userpic.Enabled = False
        obj_Advance_approved1by.Enabled = False
        obj_Advance_modifiedby.Enabled = False
        obj_Advance_prepareloc.Enabled = False
        obj_Request_usedloc.Enabled = False

        'attachment
        obj_attach_browse.Enabled = False

        'note
        'obj_Request_descr.Enabled = False
        obj_Advance_descr.ReadOnly = True
        obj_Advance_descr.BackColor = Color.Gainsboro
    End Function

    Private Function BindingStop() As Boolean
        'stop binding
        Me.obj_Advance_id.DataBindings.Clear()
        Me.obj_Request_preparedt.DataBindings.Clear()
        Me.obj_advance_prepare_dt.DataBindings.Clear()
        Me.obj_Advance_descr.DataBindings.Clear()
        Me.obj_Advance_entrydt.DataBindings.Clear()
        Me.obj_Advance_entryby.DataBindings.Clear()
        Me.obj_Advance_usedby.DataBindings.Clear()
        Me.obj_Advance_approved1dt.DataBindings.Clear()
        Me.obj_Advance_approved1by.DataBindings.Clear()
        Me.obj_Advance_approved2dt.DataBindings.Clear()
        Me.obj_Advance_approved2by.DataBindings.Clear()
        Me.obj_Advance_modifieddt.DataBindings.Clear()
        Me.obj_Advance_modifiedby.DataBindings.Clear()
        ''''Me.obj_Advance_prepareloc.DataBindings.Clear()
        Me.obj_Advance_userpic.DataBindings.Clear()
        Me.obj_source_id.DataBindings.Clear()
        Me.obj_type_id.DataBindings.Clear()
        Me.obj_channel_id.DataBindings.Clear()
        Me.obj_strukturunit_id_dest.DataBindings.Clear()
        Me.obj_rekanan_id.DataBindings.Clear()
        Me.obj_currency_id.DataBindings.Clear()
        Me.obj_Advance_foreignrate.DataBindings.Clear()
        Me.obj_Advance_foreignreal.DataBindings.Clear()
        Me.obj_Advance_pathfile.DataBindings.Clear()
        Me.obj_strukturunit_id.DataBindings.Clear()
        Me.obj_strukturunit_id_dest.DataBindings.Clear()
        Me.obj_budget_id_view.DataBindings.Clear()
        Me.obj_Advance_currency.DataBindings.Clear()
        Me.obj_Advance_programtype.DataBindings.Clear()
        Me.obj_budget_id_code.DataBindings.Clear()
        Me.obj_Advance_approved1.DataBindings.Clear()
        Me.obj_Advance_epsstart.DataBindings.Clear()
        Me.obj_Advance_epsend.DataBindings.Clear()
        Me.obj_amount.DataBindings.Clear()
        Me.obj_payment_type.DataBindings.Clear()
        Me.obj_payment_addr.DataBindings.Clear()
        Me.obj_Request_active.DataBindings.Clear()

        Me.chkSingleBgt.DataBindings.Clear()
        Return True
    End Function

    Private Function BindingStart() As Boolean
        'start binding
        Me.obj_Advance_id.DataBindings.Add(New Binding("Text", Me.tbl_TrnAdvance_Temp, "advance_id"))
        Me.obj_Advance_descr.DataBindings.Add(New Binding("Text", Me.tbl_TrnAdvance_Temp, "advance_descr"))
        Me.obj_Advance_entrydt.DataBindings.Add(New Binding("Text", Me.tbl_TrnAdvance_Temp, "advance_entrydt"))
        Me.obj_Advance_entryby.DataBindings.Add(New Binding("Text", Me.tbl_TrnAdvance_Temp, "advance_entryby"))
        Me.obj_Request_preparedt.DataBindings.Add(New Binding("Text", Me.tbl_TrnAdvance_Temp, "advance_preparedt"))
        Me.obj_advance_prepare_dt.DataBindings.Add(New Binding("Text", Me.tbl_TrnAdvance_Temp, "advance_preparedt"))
        Me.obj_Advance_approved1dt.DataBindings.Add(New Binding("Text", Me.tbl_TrnAdvance_Temp, "advance_approved1dt"))
        Me.obj_Advance_approved1by.DataBindings.Add(New Binding("Text", Me.tbl_TrnAdvance_Temp, "advance_approved1by"))
        Me.obj_Advance_approved2dt.DataBindings.Add(New Binding("Text", Me.tbl_TrnAdvance_Temp, "advance_approved2dt"))
        Me.obj_Advance_approved2by.DataBindings.Add(New Binding("Text", Me.tbl_TrnAdvance_Temp, "advance_approved2by"))
        Me.obj_Advance_modifieddt.DataBindings.Add(New Binding("Text", Me.tbl_TrnAdvance_Temp, "advance_modifieddt"))
        Me.obj_Advance_modifiedby.DataBindings.Add(New Binding("Text", Me.tbl_TrnAdvance_Temp, "advance_modifiedby"))
        ''''Me.obj_Advance_prepareloc.DataBindings.Add(New Binding("Text", Me.tbl_TrnAdvance_Temp, "advance_prepareloc"))
        Me.obj_Advance_userpic.DataBindings.Add(New Binding("Text", Me.tbl_TrnAdvance_Temp, "advance_userpic"))
        'Me.obj_Advance_usedby.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnAdvance_Temp, "advance_usedby"))
        Me.obj_Advance_usedby.DataBindings.Add(New Binding("Text", Me.tbl_TrnAdvance_Temp, "advance_usedby"))
        Me.obj_source_id.DataBindings.Add(New Binding("Text", Me.tbl_TrnAdvance_Temp, "source_id"))
        Me.obj_type_id.DataBindings.Add(New Binding("Text", Me.tbl_TrnAdvance_Temp, "type_id"))
        Me.obj_channel_id.DataBindings.Add(New Binding("Text", Me.tbl_TrnAdvance_Temp, "channel_id"))
        Me.obj_rekanan_id.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnAdvance_Temp, "rekanan_id"))
        Me.obj_currency_id.DataBindings.Add(New Binding("Text", Me.tbl_TrnAdvance_Temp, "currency_id", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))
        Me.obj_Advance_foreignrate.DataBindings.Add(New Binding("Text", Me.tbl_TrnAdvance_Temp, "advance_foreignrate", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))
        'Me.obj_Advance_foreignreal.DataBindings.Add(New Binding("Text", Me.tbl_TrnAdvance_Temp, "advance_idrreal", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))
        Me.obj_Advance_foreignreal.DataBindings.Add(New Binding("Text", Me.tbl_TrnAdvance_Temp, "advance_subtotal", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))
        Me.obj_Advance_pathfile.DataBindings.Add(New Binding("Text", Me.tbl_TrnAdvance_Temp, "advance_pathfile"))
        Me.obj_strukturunit_id.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnAdvance_Temp, "strukturunit_id"))
        Me.obj_strukturunit_id_dest.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnAdvance_Temp, "strukturunit_id_dest"))
        Me.obj_budget_id_view.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnAdvance_Temp, "budget_id"))
        Me.obj_Advance_currency.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnAdvance_Temp, "currency_id"))
        Me.obj_Advance_programtype.DataBindings.Add(New Binding("Text", Me.tbl_TrnAdvance_Temp, "advance_programtype"))
        Me.obj_budget_id_code.DataBindings.Add(New Binding("Text", Me.obj_budget_id_view, "SelectedValue"))
        Me.obj_Advance_approved1.DataBindings.Add(New Binding("Text", Me.tbl_TrnAdvance_Temp, "advance_approved1"))
        Me.obj_Advance_epsstart.DataBindings.Add(New Binding("Text", Me.tbl_TrnAdvance_Temp, "advance_epsstart"))
        Me.obj_Advance_epsend.DataBindings.Add(New Binding("Text", Me.tbl_TrnAdvance_Temp, "advance_epsend"))
        Me.obj_amount.DataBindings.Add(New Binding("Text", Me.tbl_TrnAdvance_Temp, "amount_itemdetil", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))
        Me.obj_payment_type.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnAdvance_Temp, "advance_type"))
        Me.obj_payment_addr.DataBindings.Add(New Binding("Text", Me.tbl_TrnAdvance_Temp, "advance_prepareloc"))
        Me.obj_Request_active.DataBindings.Add(New Binding("Checked", Me.tbl_TrnAdvance_Temp, "advance_canceled"))
        Me.chkSingleBgt.DataBindings.Add(New Binding("Checked", Me.tbl_TrnAdvance_Temp, "advance_singlebudget"))
        Return True
    End Function

    Private Sub BindingCheckBoxStart()
        Me.objSrchId.DataBindings.Add(New Binding("Enabled", Me.chkSrchId, "Checked"))
        Me.objSrchEntryBy.DataBindings.Add(New Binding("Enabled", Me.chkSrchEntryBy, "Checked"))
        Me.objSrchDept.DataBindings.Add(New Binding("Enabled", Me.chkSrchDept, "Checked"))
        Me.objSrchBudget.DataBindings.Add(New Binding("Enabled", Me.chkSrchBudget, "Checked"))
        Me.objSrchStatus.DataBindings.Add(New Binding("Enabled", Me.chkSrchStatus, "Checked"))
        Me.obj_attach_open.DataBindings.Add(New Binding("Enabled", Me.chk_Attachment, "Checked"))
        Me.txtSearchRekananID.DataBindings.Add(New Binding("Enabled", Me.chkSearchRekanan, "Checked"))
    End Sub

    Private Sub BindingCheckBoxStop()
        Me.objSrchId.DataBindings.Clear()
        Me.objSrchEntryBy.DataBindings.Clear()
        Me.objSrchDept.DataBindings.Clear()
        Me.objSrchBudget.DataBindings.Clear()
        Me.objSrchStatus.DataBindings.Clear()
        Me.obj_attach_open.DataBindings.Clear()
        Me.txtSearchRekananID.DataBindings.Clear()
    End Sub

#End Region

#Region " Dialoged Control "
#End Region

#Region " User Defined Function "

    Private Function DataFillBudget(ByRef datatable As DataTable, ByVal procedure As String, ByVal code As Decimal) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        'BEGIN -- Data using one Stored Procedure: FROM PARAMETER
        dbCmd = New OleDb.OleDbCommand(procedure, dbConn)
        dbCmd.Parameters.Add("@code", Data.OleDb.OleDbType.Numeric)
        dbCmd.Parameters("@code").Value = code
        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)
        Dim cookie As Byte() = Nothing

        Try
            dbConn.Open()
            clsApplicationRole.SetAppRole(dbConn, cookie)
            dbDA.Fill(datatable)
        Catch ex As Exception
            Throw ex
        Finally
            clsApplicationRole.UnsetAppRole(dbConn, cookie)
            dbConn.Close()
        End Try

        Return True
    End Function

    Public Function DataFillForComboBudget(ByVal valuemember As String, ByVal displaymember As String, ByRef datatable As DataTable, ByVal procedure As String, ByVal code As Decimal) As Boolean
        Dim row As System.Data.DataRow

        datatable.Clear()
        row = datatable.NewRow
        row.Item(valuemember) = "0"
        row.Item(displaymember) = "-- PILIH --"
        datatable.Rows.InsertAt(row, 0)

        If procedure <> "" Then
            Me.DataFillBudget(datatable, procedure, code)
        End If

        Return True
    End Function

    Private Function uiTransaksiAdvanceRequest_NewData() As Boolean
        'new data
        Dim oDataFiller As New clsDataFiller(Me.DSN)


        RaiseEvent FormBeforeNew()
        obj_Request_active.Enabled = True

        ' TODO: Set Default Value for tbl_TrnRequest_Temp
        Me.tbl_TrnAdvance_Temp.Clear()

        ' TODO: Set Default Value for tbl_TrnRequestdetil
        Me.tbl_TrnAdvanceDetil.Clear()
        Me.tbl_TrnAdvanceDetil = clsDataset.CreateTblTrnAdvancedetil()
        Me.tbl_TrnAdvanceDetil.Columns("advance_id").DefaultValue = 0
        Me.tbl_TrnAdvanceDetil.Columns("advancedetil_line").DefaultValue = DBNull.Value
        Me.tbl_TrnAdvanceDetil.Columns("advancedetil_line").AutoIncrement = True
        Me.tbl_TrnAdvanceDetil.Columns("advancedetil_line").AutoIncrementSeed = 10
        Me.tbl_TrnAdvanceDetil.Columns("advancedetil_line").AutoIncrementStep = 10


        '''''Me.tbl_TrnRequestdetilSum.Clear()
        ''''''oDataFiller.DataFill(Me.tbl_TrnRequestdetilSum, "cq_TrnRequestdetil_Select", "")
        Me.DgvTrnAdvanceDetil.DataSource = Me.tbl_TrnAdvanceDetil

        Me.tbl_TrnAdvanceItemDetil.Clear()
        Me.tbl_TrnAdvanceItemDetil = clsDataset.CreateTblTrnAdvanceItemDetilListOrder()
        Me.tbl_TrnAdvanceItemDetil.Columns("advance_id").DefaultValue = 0
        Me.tbl_TrnAdvanceItemDetil.Columns("budgetdetil_line").DefaultValue = DBNull.Value
        Me.tbl_TrnAdvanceItemDetil.Columns("budgetdetil_line").AutoIncrement = True
        Me.tbl_TrnAdvanceItemDetil.Columns("budgetdetil_line").AutoIncrementSeed = 10
        Me.tbl_TrnAdvanceItemDetil.Columns("budgetdetil_line").AutoIncrementStep = 10
        Me.tbl_TrnAdvanceItemDetil.Columns("advancedetil_fromsettlement").DefaultValue = False
        Me.DgvItemBudgetDetil.DataSource = Me.tbl_TrnAdvanceItemDetil

        '''''Me.DgvTrnRequestdetiluse.DataSource = Me.tbl_TrnRequestdetiluse

        Me.tbl_Advancedetileps.Clear()
        Me.tbl_Advancedetileps = clsDataset.CreateTblTrnAdvanceItemDetilEps()
        Me.tbl_Advancedetileps.Columns("advance_id").DefaultValue = 0
        Me.tbl_Advancedetileps.Columns("budgetdetiluse_line").DefaultValue = DBNull.Value
        Me.tbl_Advancedetileps.Columns("budgetdetiluse_line").AutoIncrement = True
        Me.tbl_Advancedetileps.Columns("budgetdetiluse_line").AutoIncrementSeed = 10
        Me.tbl_Advancedetileps.Columns("budgetdetiluse_line").AutoIncrementStep = 10
        Me.DgvEps.DataSource = Me.tbl_Advancedetileps


        Me.tbl_TrnAdvanceRefPV.Clear()

        Me.tbl_RefOrder.Clear()
        Me.tbl_RefOrder = clsDataset.CreateTblTrnOrderadvance()
        Me.tbl_RefOrder.Columns("advance_id").DefaultValue = 0
        Me.tbl_RefOrder.Columns("budgetdetil_line").DefaultValue = DBNull.Value
        Me.tbl_RefOrder.Columns("budgetdetil_line").AutoIncrement = False
        Me.tbl_RefOrder.Columns("budgetdetil_line").AutoIncrementSeed = 10
        Me.tbl_RefOrder.Columns("budgetdetil_line").AutoIncrementStep = 10
        Me.DgvRefOrder.DataSource = Me.tbl_RefOrder

        Me.BindingContext(Me.tbl_TrnAdvance_Temp).EndCurrentEdit()
        Try
            Me.BindingContext(Me.tbl_TrnAdvance_Temp).AddNew()
        Catch ex As Exception
            MessageBox.Show(ex.Source)
        End Try

        'wb_attach_viewer.Navigate("")
        Me.chk_Attachment.Checked = False
        Me.chkSingleBgt.Checked = True
        Me.chkSingleBgt.Enabled = False

        obj_Advance_preparedt_time.Text = "00:00"
        obj_Request_useddt_time.Text = "00:00"
        obj_Request_useddt2_time.Text = "00:00"

        Me.obj_Advance_epsstart.Text = 0
        Me.obj_Advance_epsend.Text = 0
        Me.obj_Advance_currency.SelectedValue = 1
        Me.obj_rekanan_id.SelectedValue = 0
        Me.obj_advance_prepare_dt.Text = Now()

        counter = 0
        Me.obj_Advance_approvedstatus.Text = "New"
        Me.obj_Advance_usedby.Text = Me._USERFULLNAME

        ''''Me.isNew = True
    End Function

    Private Function uiTransaksiAdvanceRequest_MatchDateTimeWithMask() As Boolean
        Me.isTimeValidating = True
        Try
            Me.obj_advance_prepare_dt.Value = Split(Me.obj_Request_preparedt.Text, " ")(0)
        Catch ex As Exception
            Me.obj_advance_prepare_dt.Value = Now().Date
        End Try
        Try
            Me.obj_Advance_preparedt_time.Text = Split(Me.obj_Request_preparedt.Text, " ")(1)
        Catch ex As Exception
        End Try
        Try
            Me.obj_Request_useddt_date.Value = Split(Me.obj_Request_useddt.Text, " ")(0)
        Catch ex As Exception
            Me.obj_Request_useddt_date.Value = Now().Date
        End Try
        Try
            Me.obj_Request_useddt_time.Text = Split(Me.obj_Request_useddt.Text, " ")(1)
        Catch ex As Exception
        End Try
        Try
            Me.obj_Request_useddt2_date.Value = Split(Me.obj_Request_useddt2.Text, " ")(0)
        Catch ex As Exception
            Me.obj_Request_useddt2_date.Value = Now().Date
        End Try
        Try
            Me.obj_Request_useddt2_time.Text = Split(Me.obj_Request_useddt2.Text, " ")(1)
        Catch ex As Exception
        End Try
        Me.isTimeValidating = False
    End Function

    Private Function uiTransaksiAdvanceRequest_Retrieve() As Boolean
        'retrieve data
        Dim oDataFiller As New clsDataFiller(Me.DSN)
        'Dim tbl_apprproc As DataTable
        'Dim tbl_apprbma As DataTable
        Dim criteria As String = ""
        Dim top As Integer = 0
        'Dim i As Integer

        ' TODO: Parse Criteria using clsProc.RefParser()
        criteria = "type_id='" & Me._TYPEID & "' AND channel_id ='" & Me._CHANNEL & "' AND advance_programtype = '" & Me._PROGRAMTYPE & "'" & " AND source_id = '" & Me._SOURCE & "'" ''''& " AND strukturunit_id = " & Me._USERSTRUKTURUNIT

        If chkSrchId.Checked Then
            criteria &= String.Format(" AND advance_id LIKE '%{0}%' ", objSrchId.Text)
        End If

        If chkSrchEntryBy.Checked Then
            criteria &= String.Format(" AND advance_entryby LIKE '%{0}%' ", objSrchEntryBy.Text)
        End If

        If chkSrchDept.Checked And objSrchDept.SelectedIndex <> 0 Then
            criteria &= String.Format(" AND strukturunit_id = {0} ", objSrchDept.SelectedValue)
        End If

        If chkSrchBudget.Checked And objSrchBudget.Text <> "" Then
            criteria &= String.Format(" AND budget_id = {0} ", objSrchBudget.Text)
        End If

        If chkSearchRekanan.Checked And Trim(txtSearchRekananID.Text) <> "" Then
            criteria &= String.Format(" AND rekanan_id = {0} ", txtSearchRekananID.Text)
        End If

        If Me.chkSrchStatus.Checked = True Then
            '======ADD 20140619========================
            If Me._USERSTRUKTURUNIT = Department.FIN Then
                criteria &= " AND advance_approved1 = 1 AND (advance_approvedbma = 2 OR advance_approvedbma = 1) AND advance_canceled = 0 "
            End If
        End If

        If Me.chkFullPulled.Checked = True Then
            criteria &= " AND ispulled_pv = 2 "
        Else
            criteria &= " AND ispulled_pv < 2 "
        End If

        criteria &= " ORDER BY advance_id DESC" 'ispulled = 0 (belum ditarik pv), ispulled_pv = 1 (sudah ditarik sebagian), ispulled_pv = 2 (sudah ditarik semua)

        If chkSrchTop.Checked Then
            top = Me.objSrchTop.Value
        End If

        Me.tbl_TrnAdvance.Clear()
        Try
            oDataFiller.DataFillLimit(Me.tbl_TrnAdvance, "vq_TrnAdvance_Select2", criteria, top) '"cq_TrnRequest_Select", criteria, top)

            If Me.tbl_TrnAdvance.Rows.Count > 0 Then
                Me.btnCreatePaymentVoucher.Visible = True
            Else
                Me.btnCreatePaymentVoucher.Visible = False
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Me.lblTotalRows.Text = Me.DgvTrnAdvance.Rows.Count & " " & "Row(s)"
    End Function

    Private Function uiTransaksiAdvanceRequest_Save() As Boolean
        'save data

        Dim tbl_TrnAdvance_Temp_Changes As DataTable
        Dim tbl_TrnAdvanceDetil_Changes As DataTable
        Dim tbl_TrnAdvanceItemDetil_Changes As DataTable

        '''''Tambahan - Item Budget
        Dim tbl_Advancedetileps_Changes As DataTable
        Dim tbl_RefOrder_Changes As DataTable

        Dim success As Boolean
        Dim advance_id As Object = New Object
        Dim i As Integer = 0
        Dim MasterDataState As System.Data.DataRowState
        Dim result As FormSaveResult

        Dim dbConn1 As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbTrans As OleDb.OleDbTransaction = Nothing
        Dim key(0) As DataColumn

        Me.Cursor = Cursors.WaitCursor
        RaiseEvent FormBeforeSave(advance_id)

        Me.BindingContext(Me.tbl_TrnAdvance_Temp).EndCurrentEdit()
        tbl_TrnAdvance_Temp_Changes = Me.tbl_TrnAdvance_Temp.GetChanges()

        Me.DgvTrnAdvanceDetil.EndEdit()
        Me.BindingContext(Me.tbl_TrnAdvanceDetil).EndCurrentEdit()
        tbl_TrnAdvanceDetil_Changes = Me.tbl_TrnAdvanceDetil.GetChanges()

        Me.DgvItemBudgetDetil.EndEdit()
        Me.BindingContext(Me.tbl_TrnAdvanceItemDetil).EndCurrentEdit()
        tbl_TrnAdvanceItemDetil_Changes = Me.tbl_TrnAdvanceItemDetil.GetChanges()

        Me.DgvEps.EndEdit()
        Me.BindingContext(Me.tbl_Advancedetileps).EndCurrentEdit()
        tbl_Advancedetileps_Changes = Me.tbl_Advancedetileps.GetChanges()

        Me.DgvRefOrder.EndEdit()
        Me.BindingContext(Me.tbl_RefOrder).EndCurrentEdit()
        tbl_RefOrder_Changes = Me.tbl_RefOrder.GetChanges()

        If tbl_TrnAdvance_Temp_Changes IsNot Nothing Or tbl_TrnAdvanceDetil_Changes IsNot Nothing Or tbl_TrnAdvanceItemDetil_Changes IsNot Nothing Or tbl_Advancedetileps_Changes IsNot Nothing Or tbl_RefOrder_Changes IsNot Nothing Then
            If Me.tbl_TrnAdvance_Temp.Rows(0).Item("advance_approved1") = 2 And Me.tbl_TrnAdvance_Temp.Rows(0).Item("advance_approved2") = 0 And clsUtil.IsDbNull(Me.obj_Request_active.Checked, False) = False Then
                Me.tbl_TrnAdvance_Temp.Rows(0).Item("advance_approved1") = 3
            ElseIf Me.tbl_TrnAdvance_Temp.Rows(0).Item("advance_approved1") = 2 And Me.tbl_TrnAdvance_Temp.Rows(0).Item("advance_approved2") = 2 And Me.obj_Request_active.Checked = False Then
                Me.tbl_TrnAdvance_Temp.Rows(0).Item("advance_approved1") = 3
                Me.tbl_TrnAdvance_Temp.Rows(0).Item("advance_approved2") = 0
            End If
            tbl_TrnAdvance_Temp_Changes = Me.tbl_TrnAdvance_Temp.GetChanges()

            Dim cookie As Byte() = Nothing

            Try
                MasterDataState = tbl_TrnAdvance_Temp.Rows(0).RowState
                advance_id = tbl_TrnAdvance_Temp.Rows(0).Item("advance_id")

                dbConn1.Open()
                dbTrans = dbConn1.BeginTransaction()
                clsApplicationRole.SetAppRole(dbConn1, dbTrans, cookie)

                If tbl_TrnAdvance_Temp_Changes IsNot Nothing Then
                    success = Me.uiTransaksiAdvanceRequest_SaveMaster(advance_id, tbl_TrnAdvance_Temp_Changes, MasterDataState, dbConn1, dbTrans)
                    If Not success Then
                        GoTo rollback
                    End If
                    If Not success Then Throw New Exception("Error: Saving Master Data at Me.uiTransaksiAdvanceRequest_SaveMaster(tbl_TrnAdvance_Temp_Changes)")
                    Me.tbl_TrnAdvance_Temp.AcceptChanges()

                End If

                If tbl_TrnAdvanceItemDetil_Changes IsNot Nothing Then
                    Dim j As Integer
                    For j = 0 To Me.tbl_TrnAdvanceItemDetil.Rows.Count - 1
                        Try
                            If Me.tbl_TrnAdvanceItemDetil.Rows(j).RowState = DataRowState.Added Then
                                Me.tbl_TrnAdvanceItemDetil.Rows(j).Item("advance_id") = advance_id
                            End If

                            Dim x As Integer
                            For x = 0 To tbl_TrnAdvanceItemDetil_Changes.Rows.Count - 1
                                If tbl_TrnAdvanceItemDetil_Changes.Rows(x).RowState <> DataRowState.Deleted Then
                                    tbl_TrnAdvanceItemDetil_Changes.Rows(x).Item("amount_advance") = Format(clsUtil.IsDbNull(tbl_TrnAdvanceItemDetil_Changes.Rows(x).Item("amount_advance"), 0), "#,##0.00") 'Math.Round((clsUtil.IsDbNull(tbl_TrnAdvanceItemDetil_Changes.Rows(x).Item("amount_advance"), 0)), 2, MidpointRounding.AwayFromZero) 
                                End If
                            Next

                        Catch ex As Exception
                        End Try
                    Next

                    success = Me.uiTransaksiAdvanceRequest_SaveItemBudgetDetil(advance_id, tbl_TrnAdvanceItemDetil_Changes, MasterDataState, dbConn1, dbTrans)
                    If Not success Then
                        GoTo rollback
                    End If

                    If _SOURCE = "Advance Travel" Then
                        success = Me.uiTransaksiAdvanceRequest_UpdateOrderFromAdvance(advance_id, dbConn1, dbTrans)
                    End If


                    If Not success Then Throw New Exception("Error: Save Detil Data at Me.uiTransaksiAdvanceRequest_SaveItemBudgetDetil(tbl_TrnAdvanceItemDetil_Changes)")
                    Me.tbl_TrnAdvanceItemDetil.AcceptChanges()
                End If

                If tbl_TrnAdvanceDetil_Changes IsNot Nothing Then
                    For i = 0 To Me.tbl_TrnAdvanceDetil.Rows.Count - 1
                        If Me._PROGRAMTYPE = "PG" Then
                            If Me.tbl_TrnAdvanceDetil.Rows(i).RowState = DataRowState.Added Then
                                Me.tbl_TrnAdvanceDetil.Rows(i).Item("advance_id") = advance_id
                            End If
                        End If
                    Next
                    success = Me.uiTransaksiAdvanceRequest_SaveDetil(advance_id, tbl_TrnAdvanceDetil_Changes, MasterDataState, dbConn1, dbTrans)
                    If Not success Then
                        GoTo rollback
                    End If
                    If Not success Then Throw New Exception("Error: Save Detil Data at Me.uiTransaksiAdvanceRequest_SaveDetil(tbl_TrnAdvanceDetil_Changes)")
                    Me.tbl_TrnAdvanceDetil.AcceptChanges()
                End If

                If tbl_Advancedetileps_Changes IsNot Nothing Then
                    For i = 0 To Me.tbl_Advancedetileps.Rows.Count - 1
                        Try
                            If Me.tbl_Advancedetileps.Rows(i).RowState = DataRowState.Added Then
                                Me.tbl_Advancedetileps.Rows(i).Item("advance_id") = advance_id
                            End If
                        Catch ex As Exception
                        End Try
                    Next
                    success = Me.uiTransaksiAdvanceRequest_SaveDetilEps(advance_id, tbl_Advancedetileps_Changes, MasterDataState, dbConn1, dbTrans)
                    If Not success Then
                        GoTo rollback
                    End If
                    If Not success Then Throw New Exception("Error: Save Detil Use Data at Me.uiTransaksiAdvanceRequest_SaveDetilEps(tbl_Advancedetileps_Changes)")
                    Me.tbl_Advancedetileps.AcceptChanges()
                End If

                If tbl_RefOrder_Changes IsNot Nothing Then
                    For i = 0 To Me.tbl_RefOrder.Rows.Count - 1
                        Try
                            If Me.tbl_RefOrder.Rows(i).RowState = DataRowState.Added Then
                                Me.tbl_RefOrder.Rows(i).Item("advance_id") = advance_id
                            End If
                        Catch ex As Exception
                        End Try
                    Next
                    success = Me.uiTransaksiAdvanceRequest_SaveDetilRefOrder(advance_id, tbl_RefOrder_Changes, MasterDataState, dbConn1, dbTrans)
                    If Not success Then
                        GoTo rollback
                    End If
                    If Not success Then Throw New Exception("Error: Save Detil Use Data at Me.uiTransaksiAdvanceRequest_SaveDetilRefOrder(tbl_RefOrder_Changes)")
                    Me.tbl_Advancedetileps.AcceptChanges()
                End If

                If Me.tbl_RefOrder.Rows.Count > 0 Then
                    Try
                        If Me.obj_Request_active.Checked = True Then
                            Me.uiTrnAdvanceRequestListOrder_UpdateAfterCanceled(dbConn1, dbTrans)
                        End If
                    Catch ex As Exception
                    End Try
                End If

                result = FormSaveResult.SaveSuccess

                If result = FormSaveResult.SaveSuccess Then
                    dbTrans.Commit()
                    GoTo save_confirmation
                End If

rollback:
                dbTrans.Rollback()
                
save_confirmation:
                If SHOW_SAVE_CONFIRMATION Then
                    'Dim dbConn2 As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
                    counter = 0
                    m = 0
                    n = 0

                    MessageBox.Show("data saved", mUiName, MessageBoxButtons.OK, MessageBoxIcon.Information)

                    If Me.obj_Request_active.Checked = False Then
                        Me.uiTransaksiAdvanceRequest_OpenRowRefOrder(advance_id, dbConn1)
                    End If

                    Me.uiTransaksiAdvanceRequest_TotalOutstanding()
                    
                End If
            Catch ex As Exception
                result = FormSaveResult.SaveError
                MessageBox.Show("Data Cannot Be Saved" & vbCrLf & ex.Message, mUiName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                dbTrans.Rollback()
            Finally
                clsApplicationRole.UnsetAppRole(dbConn1, cookie)
                dbConn1.Close()
            End Try
        Else
            result = FormSaveResult.Nochanges
            If SHOW_SAVE_CONFIRMATION Then
                MessageBox.Show("All changes has been saved", mUiName, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If

        RaiseEvent FormAfterSave(advance_id, result)
        Me.Cursor = Cursors.Arrow
    End Function

    Private Function uiTransaksiAdvanceRequest_UpdateBeforeSave() As Boolean
        'Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim a As Integer
        Dim line As Integer

        For a = 0 To Me.DgvTrnAdvanceDetil.Rows.Count - 1
            line = Me.DgvTrnAdvanceDetil.Rows(a).Cells("advancedetil_line").Value
        Next

    End Function

    Private Function uiTransaksiAdvanceRequest_AdditionalSave() As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbCmdInsert As OleDb.OleDbCommand
        Dim query As String
        Dim cookie As Byte() = Nothing

        query = String.Format("UPDATE FRM.E_FRM.dbo.transaksi_requestdetil SET requestdetil_refreference = '' WHERE requestdetil_refreference = '{0}'", Me.obj_Advance_id.Text)

        Try
            dbConn.Open()
            clsApplicationRole.SetAppRole(dbConn, cookie)
            dbCmdInsert = New OleDb.OleDbCommand(query, dbConn)
            dbCmdInsert.CommandType = CommandType.Text
            dbCmdInsert.ExecuteNonQuery()
          
        Catch ex As Exception
        Finally
            clsApplicationRole.UnsetAppRole(dbConn, cookie)
            dbConn.Close()
        End Try
        

    End Function

    Private Overloads Function uiTransaksiAdvanceRequest_SaveMaster(ByRef advance_id As Object, ByVal objTbl As DataTable, ByVal MasterDataState As System.Data.DataRowState) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)

        Dim dbCmdInsert As OleDb.OleDbCommand
        Dim dbCmdUpdate As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter
        Dim curpos As Integer

        Dim filename As String = String.Empty
        Dim advance_newid As String = String.Empty

        Dim cookie As Byte() = Nothing

        If obj_Advance_id.Text = "" Then
            Dim tbl_temp As DataTable = New DataTable
            Dim dbCmdSequencer As OleDb.OleDbCommand
            Dim dbDASequencer As OleDb.OleDbDataAdapter

            dbCmdSequencer = New OleDb.OleDbCommand("cq_sequencer_order_select", dbConn)
            dbCmdSequencer.Parameters.Add("@channel_id", Data.OleDb.OleDbType.VarChar)
            dbCmdSequencer.Parameters.Add("@jurnaltype_id", Data.OleDb.OleDbType.VarChar)
            dbCmdSequencer.Parameters.Add("@advance_id", Data.OleDb.OleDbType.VarChar)
            dbCmdSequencer.Parameters("@channel_id").Value = Me._CHANNEL
            dbCmdSequencer.Parameters("@jurnaltype_id").Value = Me._TYPEID
            dbCmdSequencer.Parameters("@advance_id").Value = String.Empty
            dbCmdSequencer.CommandType = CommandType.StoredProcedure
            dbDASequencer = New OleDb.OleDbDataAdapter(dbCmdSequencer)

            Try
                dbConn.Open()
                clsApplicationRole.SetAppRole(dbConn, cookie)
                tbl_temp.Clear()
                tbl_temp.Columns.Add(New DataColumn("request_newid", GetType(System.String)))
                dbDASequencer.Fill(tbl_temp)
                advance_newid = tbl_temp.Rows(0)("request_newid")
            Catch ex As Exception
                Throw ex
            Finally
                clsApplicationRole.UnsetAppRole(dbConn, cookie)
                dbConn.Close()
            End Try
        End If

        filename = obj_Advance_id.Text
        If filename = "" Then filename = advance_newid

        If Me.obj_Advance_pathfile.Text = "" Then
            fi_src = New System.IO.FileInfo("dummy")
            fi_dest = New System.IO.FileInfo(srvDir & filename & fi_src.Extension)
        Else
            fi_src = New System.IO.FileInfo(obj_Advance_pathfile.Text)
            fi_dest = New System.IO.FileInfo(srvDir & filename & fi_src.Extension)
        End If


        If attach_temp <> "" Then
            fi_dest = New System.IO.FileInfo(attach_temp)

            If fi_dest.Exists Then
                fi_dest.Delete()
            End If
            Me.obj_Advance_pathfile.Text = ""
            'wb_attach_viewer.Navigate("")
        ElseIf fi_src.Name <> fi_dest.Name Then
            If fi_dest.Exists Then
                fi_dest.Delete()
            End If

            If Me.obj_Advance_pathfile.Text <> "" Then
                fi_src.CopyTo(srvDir & fi_dest.Name)
            End If

            'wb_attach_viewer.Navigate(srvDir & fi_dest.Name)
        End If

        ' Save data: transaksi_request
        dbCmdInsert = New OleDb.OleDbCommand("vq_TrnAdvance_Insert", dbConn)
        dbCmdInsert.CommandType = CommandType.StoredProcedure
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_id", System.Data.OleDb.OleDbType.VarWChar, 30))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_descr", System.Data.OleDb.OleDbType.VarWChar, 4000, "advance_descr"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_usedby", System.Data.OleDb.OleDbType.VarWChar, 200, "advance_usedby"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_modifieddt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "advance_modifieddt"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_modifiedby", System.Data.OleDb.OleDbType.VarWChar, 200, "advance_modifiedby"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@strukturunit_id_dest", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(6, Byte), CType(0, Byte), "strukturunit_id_dest", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@budget_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(8, Byte), CType(0, Byte), "budget_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_prepareby", System.Data.OleDb.OleDbType.VarWChar, 200, "advance_prepareby"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_prepareloc", System.Data.OleDb.OleDbType.VarWChar, 400, "advance_prepareloc"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_preparedt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "advance_preparedt"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_userpic", System.Data.OleDb.OleDbType.VarWChar, 200, "advance_userpic"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@source_id", System.Data.OleDb.OleDbType.VarWChar, 60, "source_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@type_id", System.Data.OleDb.OleDbType.VarWChar, 4, "type_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", Me._CHANNEL))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@strukturunit_id", Me._USERSTRUKTURUNIT))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@rekanan_id", System.Data.OleDb.OleDbType.Decimal, 8, System.Data.ParameterDirection.Input, False, CType(8, Byte), CType(0, Byte), "rekanan_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@currency_id", System.Data.OleDb.OleDbType.VarWChar, 20, "currency_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_foreignrate", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "advance_foreignrate", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_entrydt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "advance_entrydt"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_entryby", System.Data.OleDb.OleDbType.VarWChar, 200, "advance_entryby"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_foreignreal", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "advance_foreignreal", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_ordered", System.Data.OleDb.OleDbType.Boolean, 1, "advance_ordered"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_programtype", System.Data.OleDb.OleDbType.VarWChar, 4, "advance_programtype"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_epsstart", System.Data.OleDb.OleDbType.Numeric, 5, "advance_epsstart"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_epsend", System.Data.OleDb.OleDbType.Numeric, 5, "advance_epsend"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_approved1", System.Data.OleDb.OleDbType.Decimal, 9, "advance_approved1"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_approved1dt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "advance_approved1dt"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_approved1by", System.Data.OleDb.OleDbType.VarWChar, 200, "advance_approved1by"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_approved2", System.Data.OleDb.OleDbType.Decimal, 9, "advance_approved2"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_approved2dt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "advance_approved2dt"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_approved2by", System.Data.OleDb.OleDbType.VarWChar, 200, "advance_approved2by"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_canceled", System.Data.OleDb.OleDbType.Boolean, 1, "advance_canceled"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_reference", System.Data.OleDb.OleDbType.VarWChar, 30, "advance_reference"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_type", System.Data.OleDb.OleDbType.VarWChar, 60, "advance_type"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_pathfile", System.Data.OleDb.OleDbType.VarWChar, 510))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@receivedDoc_by", System.Data.OleDb.OleDbType.VarWChar, 100, "receivedDoc_by"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@receivedDoc_date", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "receivedDoc_date"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@receivedDoc_app", System.Data.OleDb.OleDbType.Boolean, 1, "receivedDoc_app"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@amount_itemdetil", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "amount_itemdetil", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_idrreal", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "advance_idrreal", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_idrrealuser", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "advance_idrrealuser", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_subtotal", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "advance_subtotal", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_singlebudget", System.Data.OleDb.OleDbType.Decimal, 9, "advance_singlebudget"))
        dbCmdInsert.Parameters("@advance_id").Value = advance_newid
        If Me.obj_Advance_pathfile.Text = "" Then
            dbCmdInsert.Parameters("@advance_pathfile").Value = ""
        Else
            dbCmdInsert.Parameters("@advance_pathfile").Value = srvDir & fi_dest.Name
        End If

        dbCmdUpdate = New OleDb.OleDbCommand("vq_TrnAdvance_Update", dbConn)
        dbCmdUpdate.CommandType = CommandType.StoredProcedure
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_id", System.Data.OleDb.OleDbType.VarWChar, 30, "advance_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_descr", System.Data.OleDb.OleDbType.VarWChar, 4000, "advance_descr"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_usedby", System.Data.OleDb.OleDbType.VarWChar, 200, "advance_usedby"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_modifieddt", System.Data.OleDb.OleDbType.DBTimeStamp, 4))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_modifiedby", Me._USERFULLNAME))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@strukturunit_id_dest", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(6, Byte), CType(0, Byte), "strukturunit_id_dest", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@budget_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(8, Byte), CType(0, Byte), "budget_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_prepareby", System.Data.OleDb.OleDbType.VarWChar, 200, "advance_prepareby"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_prepareloc", System.Data.OleDb.OleDbType.VarWChar, 400, "advance_prepareloc"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_preparedt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "advance_preparedt"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_userpic", System.Data.OleDb.OleDbType.VarWChar, 200, "advance_userpic"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@source_id", System.Data.OleDb.OleDbType.VarWChar, 60, "source_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@type_id", System.Data.OleDb.OleDbType.VarWChar, 4, "type_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20, "channel_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@strukturunit_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(6, Byte), CType(0, Byte), "strukturunit_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@rekanan_id", System.Data.OleDb.OleDbType.Decimal, 8, System.Data.ParameterDirection.Input, False, CType(8, Byte), CType(0, Byte), "rekanan_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@currency_id", System.Data.OleDb.OleDbType.VarWChar, 20, "currency_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_foreignrate", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "advance_foreignrate", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_entrydt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "advance_entrydt"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_entryby", System.Data.OleDb.OleDbType.VarWChar, 200, "advance_entryby"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_foreignreal", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "advance_foreignreal", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_ordered", System.Data.OleDb.OleDbType.Boolean, 1, "advance_ordered"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_programtype", System.Data.OleDb.OleDbType.VarWChar, 4, "advance_programtype"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_epsstart", System.Data.OleDb.OleDbType.Numeric, 5, "advance_epsstart"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_epsend", System.Data.OleDb.OleDbType.Numeric, 5, "advance_epsend"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_approved1", System.Data.OleDb.OleDbType.Decimal, 9, "advance_approved1"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_approved1dt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "advance_approved1dt"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_approved1by", System.Data.OleDb.OleDbType.VarWChar, 200, "advance_approved1by"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_approved2", System.Data.OleDb.OleDbType.Decimal, 9, "advance_approved2"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_approved2dt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "advance_approved2dt"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_approved2by", System.Data.OleDb.OleDbType.VarWChar, 200, "advance_approved2by"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_canceled", System.Data.OleDb.OleDbType.Boolean, 1, "advance_canceled"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_reference", System.Data.OleDb.OleDbType.VarWChar, 30, "advance_reference"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_type", System.Data.OleDb.OleDbType.VarWChar, 60, "advance_type"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_pathfile", System.Data.OleDb.OleDbType.VarWChar, 510))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@receivedDoc_by", System.Data.OleDb.OleDbType.VarWChar, 100, "receivedDoc_by"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@receivedDoc_date", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "receivedDoc_date"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@receivedDoc_app", System.Data.OleDb.OleDbType.Boolean, 1, "receivedDoc_app"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@amount_itemdetil", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "amount_itemdetil", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_idrreal", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "advance_idrreal", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_idrrealuser", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "advance_idrrealuser", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_subtotal", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "advance_subtotal", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_singlebudget", System.Data.OleDb.OleDbType.Decimal, 9, "advance_singlebudget"))
        dbCmdUpdate.Parameters("@advance_modifieddt").Value = Now()
        If Me.obj_Advance_pathfile.Text = "" Then
            dbCmdUpdate.Parameters("@advance_pathfile").Value = ""
        Else
            dbCmdUpdate.Parameters("@advance_pathfile").Value = srvDir & fi_dest.Name
        End If

        dbDA = New OleDb.OleDbDataAdapter
        dbDA.UpdateCommand = dbCmdUpdate
        dbDA.InsertCommand = dbCmdInsert

        cookie = Nothing

        Try
            dbConn.Open()
            clsApplicationRole.SetAppRole(dbConn, cookie)
            dbDA.Update(objTbl)

            advance_id = objTbl.Rows(0).Item("advance_id")
            Me.tbl_TrnAdvance_Temp.Clear()
            Me.tbl_TrnAdvance_Temp.Merge(objTbl)
        Catch ex As Data.OleDb.OleDbException

            MessageBox.Show(ex.Message, "OLE DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return False
        Finally
            clsApplicationRole.UnsetAppRole(dbConn, cookie)
            dbConn.Close()
        End Try

        If MasterDataState = DataRowState.Added Then
            Me.tbl_TrnAdvance.Merge(objTbl)

        ElseIf MasterDataState = DataRowState.Modified Then
            curpos = Me.BindingContext(Me.tbl_TrnAdvance).Position
            Me.tbl_TrnAdvance.Rows.RemoveAt(curpos)
            Me.tbl_TrnAdvance.Merge(objTbl)
        End If

        Me.BindingContext(Me.tbl_TrnAdvance).Position = Me.BindingContext(Me.tbl_TrnAdvance).Count

        Return True
    End Function

    Private Overloads Function uiTransaksiAdvanceRequest_SaveMaster(ByRef advance_id As Object, ByVal objTbl As DataTable, ByVal MasterDataState As System.Data.DataRowState, _
    ByRef dbconn As OleDb.OleDbConnection, ByRef dbtrans As OleDb.OleDbTransaction) As Boolean

        '''' udah
        ''''Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)

        Dim dbCmdInsert As OleDb.OleDbCommand
        Dim dbCmdUpdate As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter
        Dim curpos As Integer

        Dim filename As String = String.Empty
        Dim advance_newid As String = String.Empty

        'wb_attach_viewer.Navigate("")

        If obj_Advance_id.Text = "" Then
            Dim tbl_temp As DataTable = New DataTable
            Dim dbCmdSequencer As OleDb.OleDbCommand
            Dim dbDASequencer As OleDb.OleDbDataAdapter

            dbCmdSequencer = New OleDb.OleDbCommand("cq_sequencer_order_select", dbconn, dbtrans)
            dbCmdSequencer.Parameters.Add("@channel_id", Data.OleDb.OleDbType.VarChar)
            dbCmdSequencer.Parameters.Add("@jurnaltype_id", Data.OleDb.OleDbType.VarChar)
            dbCmdSequencer.Parameters.Add("@advance_id", Data.OleDb.OleDbType.VarChar)
            dbCmdSequencer.Parameters("@channel_id").Value = Me._CHANNEL
            dbCmdSequencer.Parameters("@jurnaltype_id").Value = Me._TYPEID
            dbCmdSequencer.Parameters("@advance_id").Value = String.Empty
            dbCmdSequencer.CommandType = CommandType.StoredProcedure
            dbDASequencer = New OleDb.OleDbDataAdapter(dbCmdSequencer)

            Try
                ''''    dbConn.Open()
                tbl_temp.Clear()
                tbl_temp.Columns.Add(New DataColumn("request_newid", GetType(System.String)))
                dbDASequencer.Fill(tbl_temp)
                advance_newid = tbl_temp.Rows(0)("request_newid")
            Catch ex As Exception
                Throw ex
            Finally
                ''''dbConn.Close()
            End Try
        End If

        filename = obj_Advance_id.Text
        If filename = "" Then filename = advance_newid

        If Me.obj_Advance_pathfile.Text = "" Then
            fi_src = New System.IO.FileInfo("dummy")
            fi_dest = New System.IO.FileInfo(srvDir & filename & fi_src.Extension)
        Else
            fi_src = New System.IO.FileInfo(obj_Advance_pathfile.Text)
            fi_dest = New System.IO.FileInfo(srvDir & filename & fi_src.Extension)
        End If


        If attach_temp <> "" Then
            fi_dest = New System.IO.FileInfo(attach_temp)

            If fi_dest.Exists Then
                fi_dest.Delete()
            End If
            Me.obj_Advance_pathfile.Text = ""
            'wb_attach_viewer.Navigate("")
        ElseIf fi_src.Name <> fi_dest.Name Then
            If fi_dest.Exists Then
                fi_dest.Delete()
            End If

            If Me.obj_Advance_pathfile.Text <> "" Then
                fi_src.CopyTo(srvDir & fi_dest.Name)
            End If

            'wb_attach_viewer.Navigate(srvDir & fi_dest.Name)
        End If

        ' Save data: transaksi_request
        dbCmdInsert = New OleDb.OleDbCommand("vq_TrnAdvance_Insert", dbconn, dbtrans)
        dbCmdInsert.CommandType = CommandType.StoredProcedure
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_id", System.Data.OleDb.OleDbType.VarWChar, 30))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_descr", System.Data.OleDb.OleDbType.VarWChar, 4000, "advance_descr"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_usedby", System.Data.OleDb.OleDbType.VarWChar, 200, "advance_usedby"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_modifieddt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "advance_modifieddt"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_modifiedby", System.Data.OleDb.OleDbType.VarWChar, 200, "advance_modifiedby"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@strukturunit_id_dest", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(6, Byte), CType(0, Byte), "strukturunit_id_dest", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@budget_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(8, Byte), CType(0, Byte), "budget_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_prepareby", System.Data.OleDb.OleDbType.VarWChar, 200, "advance_prepareby"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_prepareloc", System.Data.OleDb.OleDbType.VarWChar, 400, "advance_prepareloc"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_preparedt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "advance_preparedt"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_userpic", System.Data.OleDb.OleDbType.VarWChar, 200, "advance_userpic"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@source_id", System.Data.OleDb.OleDbType.VarWChar, 60, "source_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@type_id", System.Data.OleDb.OleDbType.VarWChar, 4, "type_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", Me._CHANNEL))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@strukturunit_id", Me._USERSTRUKTURUNIT))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@rekanan_id", System.Data.OleDb.OleDbType.Decimal, 8, System.Data.ParameterDirection.Input, False, CType(8, Byte), CType(0, Byte), "rekanan_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@currency_id", System.Data.OleDb.OleDbType.VarWChar, 20, "currency_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_foreignrate", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "advance_foreignrate", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_entrydt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "advance_entrydt"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_entryby", System.Data.OleDb.OleDbType.VarWChar, 200, "advance_entryby"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_foreignreal", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "advance_foreignreal", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_ordered", System.Data.OleDb.OleDbType.Boolean, 1, "advance_ordered"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_programtype", System.Data.OleDb.OleDbType.VarWChar, 4, "advance_programtype"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_epsstart", System.Data.OleDb.OleDbType.Numeric, 5, "advance_epsstart"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_epsend", System.Data.OleDb.OleDbType.Numeric, 5, "advance_epsend"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_approved1", System.Data.OleDb.OleDbType.Decimal, 9, "advance_approved1"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_approved1dt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "advance_approved1dt"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_approved1by", System.Data.OleDb.OleDbType.VarWChar, 200, "advance_approved1by"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_approved2", System.Data.OleDb.OleDbType.Decimal, 9, "advance_approved2"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_approved2dt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "advance_approved2dt"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_approved2by", System.Data.OleDb.OleDbType.VarWChar, 200, "advance_approved2by"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_canceled", System.Data.OleDb.OleDbType.Boolean, 1, "advance_canceled"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_reference", System.Data.OleDb.OleDbType.VarWChar, 30, "advance_reference"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_type", System.Data.OleDb.OleDbType.VarWChar, 60, "advance_type"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_pathfile", System.Data.OleDb.OleDbType.VarWChar, 510))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@receivedDoc_by", System.Data.OleDb.OleDbType.VarWChar, 100, "receivedDoc_by"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@receivedDoc_date", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "receivedDoc_date"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@receivedDoc_app", System.Data.OleDb.OleDbType.Boolean, 1, "receivedDoc_app"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@amount_itemdetil", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "amount_itemdetil", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_idrreal", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "advance_idrreal", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_idrrealuser", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "advance_idrrealuser", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_subtotal", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "advance_subtotal", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_singlebudget", System.Data.OleDb.OleDbType.Decimal, 9, "advance_singlebudget"))
        dbCmdInsert.Parameters("@advance_id").Value = advance_newid
        If Me.obj_Advance_pathfile.Text = "" Then
            dbCmdInsert.Parameters("@advance_pathfile").Value = ""
        Else
            dbCmdInsert.Parameters("@advance_pathfile").Value = srvDir & fi_dest.Name
        End If

        dbCmdUpdate = New OleDb.OleDbCommand("vq_TrnAdvance_Update", dbconn, dbtrans)
        dbCmdUpdate.CommandType = CommandType.StoredProcedure
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_id", System.Data.OleDb.OleDbType.VarWChar, 30, "advance_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_descr", System.Data.OleDb.OleDbType.VarWChar, 4000, "advance_descr"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_usedby", System.Data.OleDb.OleDbType.VarWChar, 200, "advance_usedby"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_modifieddt", System.Data.OleDb.OleDbType.DBTimeStamp, 4))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_modifiedby", Me._USERFULLNAME))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@strukturunit_id_dest", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(6, Byte), CType(0, Byte), "strukturunit_id_dest", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@budget_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(8, Byte), CType(0, Byte), "budget_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_prepareby", System.Data.OleDb.OleDbType.VarWChar, 200, "advance_prepareby"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_prepareloc", System.Data.OleDb.OleDbType.VarWChar, 400, "advance_prepareloc"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_preparedt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "advance_preparedt"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_userpic", System.Data.OleDb.OleDbType.VarWChar, 200, "advance_userpic"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@source_id", System.Data.OleDb.OleDbType.VarWChar, 60, "source_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@type_id", System.Data.OleDb.OleDbType.VarWChar, 4, "type_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20, "channel_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@strukturunit_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(6, Byte), CType(0, Byte), "strukturunit_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@rekanan_id", System.Data.OleDb.OleDbType.Decimal, 8, System.Data.ParameterDirection.Input, False, CType(8, Byte), CType(0, Byte), "rekanan_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@currency_id", System.Data.OleDb.OleDbType.VarWChar, 20, "currency_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_foreignrate", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "advance_foreignrate", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_entrydt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "advance_entrydt"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_entryby", System.Data.OleDb.OleDbType.VarWChar, 200, "advance_entryby"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_foreignreal", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "advance_foreignreal", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_ordered", System.Data.OleDb.OleDbType.Boolean, 1, "advance_ordered"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_programtype", System.Data.OleDb.OleDbType.VarWChar, 4, "advance_programtype"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_epsstart", System.Data.OleDb.OleDbType.Numeric, 5, "advance_epsstart"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_epsend", System.Data.OleDb.OleDbType.Numeric, 5, "advance_epsend"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_approved1", System.Data.OleDb.OleDbType.Decimal, 9, "advance_approved1"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_approved1dt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "advance_approved1dt"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_approved1by", System.Data.OleDb.OleDbType.VarWChar, 200, "advance_approved1by"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_approved2", System.Data.OleDb.OleDbType.Decimal, 9, "advance_approved2"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_approved2dt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "advance_approved2dt"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_approved2by", System.Data.OleDb.OleDbType.VarWChar, 200, "advance_approved2by"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_canceled", System.Data.OleDb.OleDbType.Boolean, 1, "advance_canceled"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_reference", System.Data.OleDb.OleDbType.VarWChar, 30, "advance_reference"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_type", System.Data.OleDb.OleDbType.VarWChar, 60, "advance_type"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_pathfile", System.Data.OleDb.OleDbType.VarWChar, 510))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@receivedDoc_by", System.Data.OleDb.OleDbType.VarWChar, 100, "receivedDoc_by"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@receivedDoc_date", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "receivedDoc_date"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@receivedDoc_app", System.Data.OleDb.OleDbType.Boolean, 1, "receivedDoc_app"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@amount_itemdetil", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "amount_itemdetil", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_idrreal", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "advance_idrreal", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_idrrealuser", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "advance_idrrealuser", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_subtotal", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "advance_subtotal", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_singlebudget", System.Data.OleDb.OleDbType.Decimal, 9, "advance_singlebudget"))
        dbCmdUpdate.Parameters("@advance_modifieddt").Value = Now()
        If Me.obj_Advance_pathfile.Text = "" Then
            dbCmdUpdate.Parameters("@advance_pathfile").Value = ""
        Else
            dbCmdUpdate.Parameters("@advance_pathfile").Value = srvDir & fi_dest.Name
        End If


        dbDA = New OleDb.OleDbDataAdapter
        dbDA.UpdateCommand = dbCmdUpdate
        dbDA.InsertCommand = dbCmdInsert


        Try
            ''''dbConn.Open()
            dbDA.Update(objTbl)

            advance_id = objTbl.Rows(0).Item("advance_id")
            Me.tbl_TrnAdvance_Temp.Clear()
            Me.tbl_TrnAdvance_Temp.Merge(objTbl)
        Catch ex As Data.OleDb.OleDbException

            MessageBox.Show(ex.Message, "OLE DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return False
        Finally
            ''''dbConn.Close()
        End Try


        If MasterDataState = DataRowState.Added Then
            Me.tbl_TrnAdvance.Merge(objTbl)

        ElseIf MasterDataState = DataRowState.Modified Then
            curpos = Me.BindingContext(Me.tbl_TrnAdvance).Position
            Me.tbl_TrnAdvance.Rows.RemoveAt(curpos)
            Me.tbl_TrnAdvance.Merge(objTbl)
        End If

        Me.BindingContext(Me.tbl_TrnAdvance).Position = Me.BindingContext(Me.tbl_TrnAdvance).Count

        Return True
    End Function

    Private Function uiTransaksiAdvanceRequest_SaveDetil(ByRef advance_id As Object, ByVal objTbl As DataTable, ByVal MasterDataState As System.Data.DataRowState, _
    ByRef dbconn As OleDb.OleDbConnection, ByRef dbtrans As OleDb.OleDbTransaction) As Boolean

        '''' udah
        ''''Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbCmdInsert As OleDb.OleDbCommand
        Dim dbCmdUpdate As OleDb.OleDbCommand
        Dim dbCmdDelete As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter


        ' Save data: transaksi_requestdetil
        dbCmdInsert = New OleDb.OleDbCommand("vq_TrnAdvanceDetil_Insert", dbconn, dbtrans)
        dbCmdInsert.CommandType = CommandType.StoredProcedure
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_id", System.Data.OleDb.OleDbType.VarWChar, 30))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advancedetil_line", System.Data.OleDb.OleDbType.Integer, 4, "advancedetil_line"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advancedetil_descr", System.Data.OleDb.OleDbType.VarWChar, 510, "advancedetil_descr"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@currency_id", System.Data.OleDb.OleDbType.VarWChar, 20, "currency_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advancedetil_foreignrate", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(3, Byte), "advancedetil_foreignrate", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", Me._CHANNEL))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@strukturunit_id", Me._USERSTRUKTURUNIT))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advancedetil_foreignreal", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "advancedetil_foreignreal", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advancedetil_ordered", System.Data.OleDb.OleDbType.Boolean, 1, "advancedetil_ordered"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advancedetil_refreference", System.Data.OleDb.OleDbType.VarWChar, 60, "advancedetil_refreference"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advancedetil_type", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(2, Byte), CType(0, Byte), "advancedetil_type", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advancedetil_idrreal", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "advancedetil_idrreal", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advancedetil_approvedbma", System.Data.OleDb.OleDbType.TinyInt, 1, "advancedetil_approvedbma"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advancedetil_approvedbmadt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "advancedetil_approvedbmadt"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advancedetil_approvedbmaby", System.Data.OleDb.OleDbType.VarWChar, 200, "advancedetil_approvedbmaby"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advancedetil_approveddescr", System.Data.OleDb.OleDbType.VarWChar, 500, "advancedetil_approveddescr"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@username", Me.UserName))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advancedetil_paymentdt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "advancedetil_paymentdt"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advancedetil_paymenttype", System.Data.OleDb.OleDbType.VarWChar, 60, "advancedetil_paymenttype"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advancedetil_subtotal", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "advancedetil_subtotal", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advancedetil_canceled", System.Data.OleDb.OleDbType.TinyInt, 1, "advancedetil_canceled"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advancedetil_canceleddt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "advancedetil_canceleddt"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advancedetil_canceledby", System.Data.OleDb.OleDbType.VarWChar, 200, "advancedetil_canceledby"))
        dbCmdInsert.Parameters("@advance_id").Value = advance_id


        dbCmdUpdate = New OleDb.OleDbCommand("vq_TrnAdvanceDetil_Update", dbconn, dbtrans)
        dbCmdUpdate.CommandType = CommandType.StoredProcedure
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_id", System.Data.OleDb.OleDbType.VarWChar, 30))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advancedetil_line", System.Data.OleDb.OleDbType.Integer, 4, "advancedetil_line"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advancedetil_descr", System.Data.OleDb.OleDbType.VarWChar, 4000, "advancedetil_descr"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@currency_id", System.Data.OleDb.OleDbType.VarWChar, 20, "currency_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@requestdetil_foreignrate", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(3, Byte), "advancedetil_foreignrate", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20, "channel_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@strukturunit_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(6, Byte), CType(0, Byte), "strukturunit_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@requestdetil_foreignreal", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "advancedetil_foreignreal", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@requestdetil_ordered", System.Data.OleDb.OleDbType.Boolean, 1, "advancedetil_ordered"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@requestdetil_refreference", System.Data.OleDb.OleDbType.VarWChar, 60, "advancedetil_refreference"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advancedetil_type", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(2, Byte), CType(0, Byte), "advancedetil_type", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advancedetil_idrreal", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "advancedetil_idrreal", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advancedetil_approvedbma", System.Data.OleDb.OleDbType.TinyInt, 1, "advancedetil_approvedbma"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advancedetil_approvedbmadt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "advancedetil_approvedbmadt"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advancedetil_approvedbmaby", System.Data.OleDb.OleDbType.VarWChar, 200, "advancedetil_approvedbmaby"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advancedetil_approveddescr", System.Data.OleDb.OleDbType.VarWChar, 500, "advancedetil_approveddescr"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@username", Me.UserName))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advancedetil_paymentdt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "advancedetil_paymentdt"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advancedetil_paymenttype", System.Data.OleDb.OleDbType.VarWChar, 60, "advancedetil_paymenttype"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advancedetil_subtotal", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "advancedetil_subtotal", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advancedetil_canceled", System.Data.OleDb.OleDbType.TinyInt, 1, "advancedetil_canceled"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advancedetil_canceleddt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "advancedetil_canceleddt"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advancedetil_canceledby", System.Data.OleDb.OleDbType.VarWChar, 200, "advancedetil_canceledby"))
        dbCmdUpdate.Parameters("@advance_id").Value = advance_id

        dbCmdDelete = New OleDb.OleDbCommand("vq_TrnAdvanceDetil_Delete", dbconn, dbtrans)
        dbCmdDelete.CommandType = CommandType.StoredProcedure
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_id", System.Data.OleDb.OleDbType.VarWChar, 30))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advancedetil_line", System.Data.OleDb.OleDbType.Integer, 4, "advancedetil_line"))
        dbCmdDelete.Parameters("@advance_id").Value = advance_id

        dbDA = New OleDb.OleDbDataAdapter
        dbDA.UpdateCommand = dbCmdUpdate
        dbDA.InsertCommand = dbCmdInsert
        dbDA.DeleteCommand = dbCmdDelete

        Try
            ''''dbConn.Open()
            dbDA.Update(objTbl)

        Catch ex As Data.OleDb.OleDbException
            MessageBox.Show(ex.Message, "OLE DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return False
        Finally
            ''''dbConn.Close()
        End Try

        Return True
    End Function

    Private Function uiTransaksiAdvanceRequest_SaveItemBudgetDetil(ByRef advance_id As Object, ByVal objTbl As DataTable, ByVal MasterDataState As System.Data.DataRowState, _
    ByRef dbconn As OleDb.OleDbConnection, ByRef dbtrans As OleDb.OleDbTransaction) As Boolean
        '''' udah
        ''''Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbCmdInsert As OleDb.OleDbCommand
        Dim dbCmdUpdate As OleDb.OleDbCommand
        Dim dbCmdDelete As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter


        dbCmdInsert = New OleDb.OleDbCommand("vq_TrnAdvanceItemDetil_Insert", dbconn, dbtrans)
        dbCmdInsert.CommandType = CommandType.StoredProcedure
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_id", System.Data.OleDb.OleDbType.VarWChar, 30))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advancedetil_line", System.Data.OleDb.OleDbType.Integer, 4, "advancedetil_line"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@budgetdetil_line", System.Data.OleDb.OleDbType.Integer, 4, "budgetdetil_line"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advancedetil_type", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(2, Byte), CType(0, Byte), "advancedetil_type", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@budget_name", System.Data.OleDb.OleDbType.VarWChar, 510, "budget_name"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@currency_id", System.Data.OleDb.OleDbType.VarWChar, 20, "currency_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@budgetdetil_eps", System.Data.OleDb.OleDbType.VarWChar, 100, "budgetdetil_eps"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@budgetdetil_days", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "budgetdetil_days", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@acc_id", System.Data.OleDb.OleDbType.VarWChar, 14, "acc_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", Me._CHANNEL))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@strukturunit_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(6, Byte), CType(0, Byte), "strukturunit_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@amount_advance", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "amount_advance", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@budget_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(8, Byte), CType(0, Byte), "budget_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@budgetdetil_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(8, Byte), CType(0, Byte), "budgetdetil_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@budgetdetil_name", System.Data.OleDb.OleDbType.VarWChar, 1000, "budgetdetil_name"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advancedetil_foreignrate", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(3, Byte), "advancedetil_foreignrate", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@amount_idrreal", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "amount_idrreal", System.Data.DataRowVersion.Current, Nothing))
        ''''dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@outstanding_approved", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(3, Byte), "outstanding_approved", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_isrequest", System.Data.OleDb.OleDbType.Boolean, 1, "advance_isrequest"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_requestid", System.Data.OleDb.OleDbType.VarWChar, 30, "advance_requestid"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_requestid_line", System.Data.OleDb.OleDbType.Integer, 4, "advance_requestid_line"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@amount_settlement", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(3, Byte), "amount_settlement", System.Data.DataRowVersion.Current, Nothing))

        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@pph_persen_settlement", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "pph_persen_settlement", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@ppn_persen_settlement", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "ppn_persen_settlement", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@amount_discount_settlement", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "amount_discount_settlement", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@amount_intercompany_settlement", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "amount_intercompany_settlement", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@amount_settlement_nettforeign", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "amount_settlement_nettforeign", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@amount_settlement_nett", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "amount_settlement_nett", System.Data.DataRowVersion.Current, Nothing))

        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@amount_settlementreimburseforeign", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(3, Byte), "amount_settlementreimburseforeign", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@amount_settlementreimburse", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "amount_settlementreimburse", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@amount_settlementrefundforeign", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(3, Byte), "amount_settlementrefundforeign", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@amount_settlementrefund", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "amount_settlementrefund", System.Data.DataRowVersion.Current, Nothing))

        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@settlement_id", System.Data.OleDb.OleDbType.VarWChar, 30, "settlement_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@username", Me.UserName))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@settlement_rate", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(3, Byte), "settlement_rate", System.Data.DataRowVersion.Current, Nothing))
        ' ''dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@settlement_currency", System.Data.OleDb.OleDbType.VarWChar, 30, "settlement_currency"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@settlement_foreign", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(3, Byte), "settlement_foreign", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_isreimburse", System.Data.OleDb.OleDbType.Boolean, 1, "advance_isreimburse"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_reimburseid", System.Data.OleDb.OleDbType.VarWChar, 30, "advance_reimburseid"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advancedetil_fromsettlement", System.Data.OleDb.OleDbType.Boolean, 1, "advancedetil_fromsettlement"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advancedetil_discount", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "advancedetil_discount", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@pph_persen", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(3, Byte), "pph_persen", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@ppn_persen", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(3, Byte), "ppn_persen", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@amount_subtotalforeign", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "amount_subtotalforeign", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@amount_subtotal", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "amount_subtotal", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@faktur_id", System.Data.OleDb.OleDbType.VarWChar, 40, "faktur_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@amount_intercompany", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "amount_intercompany", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters("@advance_id").Value = advance_id

        dbCmdUpdate = New OleDb.OleDbCommand("vq_TrnAdvanceItemDetil_Update", dbconn, dbtrans)
        dbCmdUpdate.CommandType = CommandType.StoredProcedure
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_id", System.Data.OleDb.OleDbType.VarWChar, 30))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advancedetil_line", System.Data.OleDb.OleDbType.Integer, 4, "advancedetil_line"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@budgetdetil_line", System.Data.OleDb.OleDbType.Integer, 4, "budgetdetil_line"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advancedetil_type", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(2, Byte), CType(0, Byte), "advancedetil_type", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@budget_name", System.Data.OleDb.OleDbType.VarWChar, 510, "budget_name"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@currency_id", System.Data.OleDb.OleDbType.VarWChar, 20, "currency_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@budgetdetil_eps", System.Data.OleDb.OleDbType.VarWChar, 100, "budgetdetil_eps"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@budgetdetil_days", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "budgetdetil_days", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@acc_id", System.Data.OleDb.OleDbType.VarWChar, 14, "acc_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20, "channel_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@strukturunit_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(6, Byte), CType(0, Byte), "strukturunit_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@amount_advance", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "amount_advance", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@budget_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(8, Byte), CType(0, Byte), "budget_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@budgetdetil_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(8, Byte), CType(0, Byte), "budgetdetil_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@budgetdetil_name", System.Data.OleDb.OleDbType.VarWChar, 1000, "budgetdetil_name"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advancedetil_foreignrate", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(3, Byte), "advancedetil_foreignrate", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@amount_idrreal", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "amount_idrreal", System.Data.DataRowVersion.Current, Nothing))
        ''''dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@outstanding_approved", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(3, Byte), "outstanding_approved", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_isrequest", System.Data.OleDb.OleDbType.Boolean, 1, "advance_isrequest"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_requestid", System.Data.OleDb.OleDbType.VarWChar, 30, "advance_requestid"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_requestid_line", System.Data.OleDb.OleDbType.Integer, 4, "advance_requestid_line"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@amount_settlement", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(3, Byte), "amount_settlement", System.Data.DataRowVersion.Current, Nothing))

        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@pph_persen_settlement", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "pph_persen_settlement", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@ppn_persen_settlement", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "ppn_persen_settlement", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@amount_discount_settlement", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "amount_discount_settlement", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@amount_intercompany_settlement", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "amount_intercompany_settlement", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@amount_settlement_nettforeign", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "amount_settlement_nettforeign", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@amount_settlement_nett", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "amount_settlement_nett", System.Data.DataRowVersion.Current, Nothing))

        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@amount_settlementreimburseforeign", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(3, Byte), "amount_settlementreimburseforeign", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@amount_settlementreimburse", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "amount_settlementreimburse", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@amount_settlementrefundforeign", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(3, Byte), "amount_settlementrefundforeign", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@amount_settlementrefund", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "amount_settlementrefund", System.Data.DataRowVersion.Current, Nothing))

        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@settlement_id", System.Data.OleDb.OleDbType.VarWChar, 30, "settlement_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@username", Me.UserName))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@settlement_rate", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(3, Byte), "settlement_rate", System.Data.DataRowVersion.Current, Nothing))
        ' ''dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@settlement_currency", System.Data.OleDb.OleDbType.VarWChar, 30, "settlement_currency"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@settlement_foreign", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(3, Byte), "settlement_foreign", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_isreimburse", System.Data.OleDb.OleDbType.Boolean, 1, "advance_isreimburse"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_reimburseid", System.Data.OleDb.OleDbType.VarWChar, 30, "advance_reimburseid"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advancedetil_fromsettlement", System.Data.OleDb.OleDbType.Boolean, 1, "advancedetil_fromsettlement"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advancedetil_discount", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "advancedetil_discount", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@pph_persen", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(3, Byte), "pph_persen", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@ppn_persen", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(3, Byte), "ppn_persen", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@amount_subtotalforeign", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "amount_subtotalforeign", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@amount_subtotal", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "amount_subtotal", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@faktur_id", System.Data.OleDb.OleDbType.VarWChar, 40, "faktur_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@amount_intercompany", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "amount_intercompany", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters("@advance_id").Value = advance_id




        dbCmdDelete = New OleDb.OleDbCommand("vq_TrnAdvanceItemDetil_Delete", dbconn, dbtrans)
        dbCmdDelete.CommandType = CommandType.StoredProcedure
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_id", System.Data.OleDb.OleDbType.VarWChar, 30))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advancedetil_line", System.Data.OleDb.OleDbType.Integer, 4, "advancedetil_line"))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@budgetdetil_line", System.Data.OleDb.OleDbType.Integer, 4, "budgetdetil_line"))
        dbCmdDelete.Parameters("@advance_id").Value = advance_id

        dbDA = New OleDb.OleDbDataAdapter
        dbDA.UpdateCommand = dbCmdUpdate
        dbDA.InsertCommand = dbCmdInsert
        dbDA.DeleteCommand = dbCmdDelete

        Try
            ''''dbConn.Open()
            dbDA.Update(objTbl)

        Catch ex As Data.OleDb.OleDbException
            MessageBox.Show(ex.Message, "OLE DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return False
        Finally
            ''''dbConn.Close()
        End Try

        Return True
    End Function

    Private Function uiTransaksiAdvanceRequest_SaveDetilEps(ByRef advance_id As Object, ByVal objTbl As DataTable, ByVal MasterDataState As System.Data.DataRowState, _
    ByRef dbconn As OleDb.OleDbConnection, ByRef dbtrans As OleDb.OleDbTransaction) As Boolean
        '''' udah
        ''''Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbCmdInsert As OleDb.OleDbCommand
        Dim dbCmdUpdate As OleDb.OleDbCommand
        Dim dbCmdDelete As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        objTbl.PrimaryKey = Nothing

        ' Save data: transaksi_requestdetil
        dbCmdInsert = New OleDb.OleDbCommand("vq_TrnAdvanceDetilEps_Insert", dbconn, dbtrans)
        dbCmdInsert.CommandType = CommandType.StoredProcedure
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_id", System.Data.OleDb.OleDbType.VarWChar, 30))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advancedetil_line", System.Data.OleDb.OleDbType.Integer, 4, "advancedetil_line"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@budgetdetil_line", System.Data.OleDb.OleDbType.Integer, 4, "budgetdetil_line"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@budgetdetiluse_line", System.Data.OleDb.OleDbType.Integer, 4, "budgetdetiluse_line"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@budgetdetil_eps", System.Data.OleDb.OleDbType.VarWChar, 100, "budgetdetil_eps"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@budget_name", System.Data.OleDb.OleDbType.VarWChar, 510, "budget_name"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@checked", System.Data.OleDb.OleDbType.TinyInt, 1, "checked"))
        dbCmdInsert.Parameters("@advance_id").Value = advance_id


        dbCmdUpdate = New OleDb.OleDbCommand("vq_TrnAdvanceDetilEps_Update", dbconn, dbtrans)
        dbCmdUpdate.CommandType = CommandType.StoredProcedure
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_id", System.Data.OleDb.OleDbType.VarWChar, 30))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advancedetil_line", System.Data.OleDb.OleDbType.Integer, 4, "advancedetil_line"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@budgetdetil_line", System.Data.OleDb.OleDbType.Integer, 4, "budgetdetil_line"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@budgetdetiluse_line", System.Data.OleDb.OleDbType.Integer, 4, "budgetdetiluse_line"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@budgetdetil_eps", System.Data.OleDb.OleDbType.VarWChar, 100, "budgetdetil_eps"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@budget_name", System.Data.OleDb.OleDbType.VarWChar, 510, "budget_name"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@checked", System.Data.OleDb.OleDbType.TinyInt, 1, "checked"))
        dbCmdUpdate.Parameters("@advance_id").Value = advance_id


        dbCmdDelete = New OleDb.OleDbCommand("vq_TrnAdvanceDetilEps_Delete", dbconn, dbtrans)
        dbCmdDelete.CommandType = CommandType.StoredProcedure
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_id", System.Data.OleDb.OleDbType.VarWChar, 30))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advancedetil_line", System.Data.OleDb.OleDbType.Integer, 4, "advancedetil_line"))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@budgetdetil_line", System.Data.OleDb.OleDbType.Integer, 4, "budgetdetil_line"))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@budgetdetiluse_line", System.Data.OleDb.OleDbType.Integer, 4, "budgetdetiluse_line"))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@budgetdetil_eps", System.Data.OleDb.OleDbType.VarWChar, 100, "budgetdetil_eps"))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@budget_name", System.Data.OleDb.OleDbType.VarWChar, 510, "budget_name"))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@checked", System.Data.OleDb.OleDbType.TinyInt, 1, "checked"))
        dbCmdDelete.Parameters("@advance_id").Value = advance_id

        dbDA = New OleDb.OleDbDataAdapter
        dbDA.UpdateCommand = dbCmdUpdate
        dbDA.InsertCommand = dbCmdInsert
        dbDA.DeleteCommand = dbCmdDelete


        Try
            ''''dbConn.Open()
            dbDA.Update(objTbl)
        Catch ex As Data.OleDb.OleDbException
            MessageBox.Show(ex.Message, "OLE DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return False
        Finally
            ''''dbConn.Close()
        End Try

        Return True
    End Function

    Private Function uiTransaksiAdvanceRequest_SaveDetilRefOrder(ByRef advance_id As Object, ByVal objTbl As DataTable, ByVal MasterDataState As System.Data.DataRowState, _
    ByRef dbconn As OleDb.OleDbConnection, ByRef dbtrans As OleDb.OleDbTransaction) As Boolean
        '''' udah
        ''''Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbCmdInsert As OleDb.OleDbCommand
        Dim dbCmdUpdate As OleDb.OleDbCommand
        Dim dbCmdDelete As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        objTbl.PrimaryKey = Nothing

        ' Save data: transaksi_requestdetil
        'dbCmdInsert = New OleDb.OleDbCommand("vq_TrnOrderadvance_Insert", dbconn, dbtrans)
        dbCmdInsert = New OleDb.OleDbCommand("vq_TrnTraveladvanceRef_Insert", dbconn, dbtrans)
        dbCmdInsert.CommandType = CommandType.StoredProcedure
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_id", System.Data.OleDb.OleDbType.VarWChar, 30))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advancedetil_line", System.Data.OleDb.OleDbType.Integer, 4, "advancedetil_line"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@budgetdetil_line", System.Data.OleDb.OleDbType.Integer, 4, "budgetdetil_line"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_id", System.Data.OleDb.OleDbType.VarWChar, 100, "order_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_line", System.Data.OleDb.OleDbType.Integer, 4, "orderdetil_line"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@budget_id", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "budget_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@budgetdetil_id", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "budgetdetil_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@currency_id", System.Data.OleDb.OleDbType.VarWChar, 20, "currency_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@amount_order", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "amount_order", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@amount_advance", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "amount_advance", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@amount_sisa", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "amount_sisa", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_qty", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "orderdetil_qty", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_pphpercent", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderdetil_pphpercent", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_ppnpercent", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderdetil_ppnpercent", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_pphamount", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderdetil_pphamount", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_ppnamount", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderdetil_ppnamount", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_days", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "orderdetil_days", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_discount", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderdetil_discount", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@item_id", System.Data.OleDb.OleDbType.VarWChar, 60, "item_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_foreignrate", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderdetil_foreignrate", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@acc_id", System.Data.OleDb.OleDbType.VarWChar, 60, "acc_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@account", System.Data.OleDb.OleDbType.VarWChar, 500, "account"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@amount_ppnpphdisc", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "amount_ppnpphdisc", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@iscanceled", System.Data.OleDb.OleDbType.Integer, 4, "iscanceled"))
        dbCmdInsert.Parameters("@advance_id").Value = advance_id


        'dbCmdUpdate = New OleDb.OleDbCommand("vq_TrnOrderadvance_Update", dbconn, dbtrans)
        dbCmdUpdate = New OleDb.OleDbCommand("vq_TrnTraveladvanceRef_update", dbconn, dbtrans)
        dbCmdUpdate.CommandType = CommandType.StoredProcedure
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_id", System.Data.OleDb.OleDbType.VarWChar, 30))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advancedetil_line", System.Data.OleDb.OleDbType.Integer, 4, "advancedetil_line"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@budgetdetil_line", System.Data.OleDb.OleDbType.Integer, 4, "budgetdetil_line"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_id", System.Data.OleDb.OleDbType.VarWChar, 100, "order_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_line", System.Data.OleDb.OleDbType.Integer, 4, "orderdetil_line"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@budget_id", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "budget_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@budgetdetil_id", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "budgetdetil_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@currency_id", System.Data.OleDb.OleDbType.VarWChar, 20, "currency_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@amount_order", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "amount_order", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@amount_advance", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "amount_advance", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@amount_sisa", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "amount_sisa", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_qty", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "orderdetil_qty", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_pphpercent", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderdetil_pphpercent", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_ppnpercent", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderdetil_ppnpercent", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_pphamount", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderdetil_pphamount", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_ppnamount", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderdetil_ppnamount", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_days", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "orderdetil_days", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_discount", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderdetil_discount", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@item_id", System.Data.OleDb.OleDbType.VarWChar, 60, "item_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_foreignrate", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "orderdetil_foreignrate", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@acc_id", System.Data.OleDb.OleDbType.VarWChar, 60, "acc_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@account", System.Data.OleDb.OleDbType.VarWChar, 500, "account"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@amount_ppnpphdisc", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "amount_ppnpphdisc", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@iscanceled", System.Data.OleDb.OleDbType.Integer, 4, "iscanceled"))
        dbCmdUpdate.Parameters("@advance_id").Value = advance_id


        'dbCmdDelete = New OleDb.OleDbCommand("vq_TrnOrderadvance_Delete", dbconn, dbtrans)
        dbCmdDelete = New OleDb.OleDbCommand("vq_TrnTraveladvanceRef_delete", dbconn, dbtrans)
        dbCmdDelete.CommandType = CommandType.StoredProcedure
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_id", System.Data.OleDb.OleDbType.VarWChar, 30))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advancedetil_line", System.Data.OleDb.OleDbType.Integer, 4, "advancedetil_line"))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@budgetdetil_line", System.Data.OleDb.OleDbType.Integer, 4, "budgetdetil_line"))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_id", System.Data.OleDb.OleDbType.VarWChar, 100, "order_id"))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_line", System.Data.OleDb.OleDbType.Integer, 4, "orderdetil_line"))
        dbCmdDelete.Parameters("@advance_id").Value = advance_id

        dbDA = New OleDb.OleDbDataAdapter
        dbDA.UpdateCommand = dbCmdUpdate
        dbDA.InsertCommand = dbCmdInsert
        dbDA.DeleteCommand = dbCmdDelete


        Try
            ''''dbConn.Open()
            dbDA.Update(objTbl)
        Catch ex As Data.OleDb.OleDbException
            MessageBox.Show(ex.Message, "OLE DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return False
        Finally
            ''''dbConn.Close()
        End Try

        Return True
    End Function

    Private Function uiTransaksiAdvanceRequest_UpdateOrderFromAdvance(ByVal advance_id As String, _
    ByRef dbconn As OleDb.OleDbConnection, ByRef dbtrans As OleDb.OleDbTransaction) As Boolean

        Dim da As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter
        Dim datatables As DataTable = New DataTable
        Dim i, j As Integer

        Dim tbl_orderdetil As DataTable = New DataTable

        For i = 0 To Me.tbl_TrnAdvanceItemDetil.Rows.Count - 1
            For j = 0 To Me.tbl_RefOrder.Rows.Count - 1

                If Me.tbl_TrnAdvanceItemDetil.Rows(i).RowState <> DataRowState.Deleted Then
                    tbl_orderdetil.Clear()
                    Me.DataFill(dbconn, dbtrans, tbl_orderdetil, "lq_TrnAdvanceListTravelDetilDialog_Select", String.Format("order_id = '{0}' AND orderdetil_line = {1} AND advance_id <> ''", Me.tbl_TrnAdvanceItemDetil.Rows(i).Item("advance_requestid"), Me.tbl_TrnAdvanceItemDetil.Rows(i).Item("advance_requestid_line")))

                    If tbl_orderdetil.Rows.Count > 0 Then
                        Exit For
                    Else
                        If Me.tbl_TrnAdvanceItemDetil.Rows(i).RowState <> DataRowState.Deleted Then
                            If Me.tbl_RefOrder.Rows(j).RowState <> DataRowState.Deleted Then
                                If Me.tbl_RefOrder.Rows(j).Item("order_id") = Me.tbl_TrnAdvanceItemDetil.Rows(i).Item("advance_requestid") And Me.tbl_RefOrder.Rows(j).Item("orderdetil_line") = Me.tbl_TrnAdvanceItemDetil.Rows(i).Item("advance_requestid_line") Then
                                    Try
                                        ''''dbConn.Open()
                                        Dim oCm As New OleDb.OleDbCommand("lq_TrnTravelListAdvance_Update", dbconn, dbtrans)
                                        oCm.CommandType = CommandType.StoredProcedure
                                        oCm.Parameters.Add("@advance_id", System.Data.OleDb.OleDbType.VarWChar, 30).Value = advance_id
                                        oCm.Parameters.Add("@advancedetil_line", System.Data.OleDb.OleDbType.Integer, 4).Value = Me.tbl_TrnAdvanceItemDetil.Rows(i).Item("advancedetil_line")
                                        oCm.Parameters.Add("@budgetdetil_line", System.Data.OleDb.OleDbType.Integer, 4).Value = Me.tbl_TrnAdvanceItemDetil.Rows(i).Item("budgetdetil_line")
                                        oCm.Parameters.Add("@advance_requestid", System.Data.OleDb.OleDbType.VarWChar, 30).Value = Me.tbl_TrnAdvanceItemDetil.Rows(i).Item("advance_requestid")
                                        oCm.Parameters.Add("@advance_requestid_line", System.Data.OleDb.OleDbType.Integer, 4).Value = Me.tbl_TrnAdvanceItemDetil.Rows(i).Item("advance_requestid_line")

                                        oCm.ExecuteNonQuery()
                                        oCm.Dispose()
                                    Catch ex As Data.OleDb.OleDbException
                                        MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                        Return False
                                    Catch ex As Exception
                                        MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                                        Return False
                                    Finally
                                        ''''dbConn.Close()
                                    End Try

                                End If
                            End If
                        End If

                    End If

                End If
            Next
        Next
        Return True
    End Function

    Private Function uiTransaksiAdvanceRequest_Delete() As Boolean
        Dim res As String = ""
        Dim advance_id As Object = New Object

        Me.Cursor = Cursors.WaitCursor
        RaiseEvent FormBeforeDelete(advance_id)

        Me.Cursor = Cursors.WaitCursor
        If Me.DgvTrnAdvance.CurrentRow IsNot Nothing Then

            res = MessageBox.Show("Are you sure want to delete data ?", mUiName, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If res = DialogResult.Yes Then
                Me.uiTransaksiAdvanceRequest_DeleteRow(Me.DgvTrnAdvance.CurrentRow.Index)
            End If

        End If

        RaiseEvent FormAfterDelete(advance_id)
        Me.Cursor = Cursors.Arrow
    End Function

    Private Overloads Function uiTransaksiAdvanceRequest_OpenRow(ByVal rowIndex As Integer) As Boolean
        '''' udah
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim advance_id As String

        advance_id = Me.DgvTrnAdvance.Rows(rowIndex).Cells("advance_id").Value

        Me.Cursor = Cursors.WaitCursor
        RaiseEvent FormBeforeOpenRow(advance_id)

        Dim cookie As Byte() = Nothing


        Try
            dbConn.Open()
            clsApplicationRole.SetAppRole(dbConn, cookie)
            Me.uiTransaksiAdvanceRequest_OpenRowMaster(advance_id, dbConn)
            Me.uiTransaksiAdvanceRequest_OpenRowDetil(advance_id, dbConn)
            Me.uiTransaksiAdvanceRequest_OpenRowDetilEps(advance_id, dbConn)
            Me.uiTransaksiAdvanceRequest_OpenRowItemDetil(advance_id, dbConn)
            Me.uiTransaksiAdvanceRequest_OpenRowRefPv(advance_id, dbConn)
            If Me.obj_Request_active.Checked = False Then
                Me.uiTransaksiAdvanceRequest_OpenRowRefOrder(advance_id, dbConn)
            Else
                Me.uiTransaksiAdvanceRequest_OpenRowRefOrderCanceled(advance_id, dbConn)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, mUiName & ": uiTransaksiAdvanceRequest_OpenRow()", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Finally
            clsApplicationRole.UnsetAppRole(dbConn, cookie)
            dbConn.Close()
        End Try

        uiTransaksiAdvanceRequest_Lock(advance_id)

        uiTransaksiAdvanceRequest_TotalOutstanding()
        counter = 0
        m = 0
        n = 0

        RaiseEvent FormAfterOpenRow(advance_id)
        Me.Cursor = Cursors.Arrow

        Return True
    End Function

    Private Overloads Function uiTransaksiAdvanceRequest_OpenRow(ByRef dbconn As OleDb.OleDbConnection, ByRef dbtrans As OleDb.OleDbTransaction, ByVal rowIndex As Integer) As Boolean
        '''' udah
        ''''Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim advance_id As String

        advance_id = Me.DgvTrnAdvance.Rows(rowIndex).Cells("advance_id").Value

        Me.Cursor = Cursors.WaitCursor
        RaiseEvent FormBeforeOpenRow(advance_id)

        Try
            ''''dbConn.Open()
            Me.uiTransaksiAdvanceRequest_OpenRowMaster(dbconn, dbtrans, advance_id)
            Me.uiTransaksiAdvanceRequest_OpenRowDetil(dbconn, dbtrans, advance_id)
            'Me.uiTransaksiAdvanceRequest_OpenRowDetilEps(dbconn, dbtrans, advance_id)
            Me.uiTransaksiAdvanceRequest_OpenRowItemDetil(dbconn, dbtrans, advance_id)
            Me.uiTransaksiAdvanceRequest_OpenRowRefPv(dbconn, dbtrans, advance_id)
            If Me.obj_Request_active.Checked = False Then
                Me.uiTransaksiAdvanceRequest_OpenRowRefOrder(dbconn, dbtrans, advance_id)
            Else
                Me.uiTransaksiAdvanceRequest_OpenRowRefOrderCanceled(dbconn, dbtrans, advance_id)
            End If
            'Tambahan - Ref Request
            '''''Me.uiTransaksiAdvanceRequest_OpenRowDetilBudget(advance_id, dbConn)
        Catch ex As Exception
            MessageBox.Show(ex.Message, mUiName & ": uiTransaksiAdvanceRequest_OpenRow()", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Finally
            ''''dbConn.Close()
        End Try

        ''''If Me.obj_budget_id_view.SelectedValue Is Nothing Then
        ''''    Me.tbl_TrnAdvanceItemDetil.Columns("budget_id").DefaultValue = 0
        ''''Else
        ''''    Me.tbl_TrnAdvanceItemDetil.Columns("budget_id").DefaultValue = clsUtil.IsDbNull(Me.obj_budget_id_view.SelectedValue, 0)
        ''''End If
        ''''uiTransaksiAdvanceRequest_MatchDateTimeWithMask()
        'tambahan FORM MODE
        uiTransaksiAdvanceRequest_Lock(dbconn, dbtrans, advance_id)
        '=========================== Cek Hari Senin ======================================
        uiTransaksiAdvanceRequest_TotalOutstanding()
        '=================================================================================
        counter = 0
        m = 0
        n = 0
        If Me._SPLIT_ONLY = "Yes" And _USERSTRUKTURUNIT = Department.FIN Then
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_approvedbma").ReadOnly = True
            'Me.DgvTrnAdvanceDetil.Columns("bma_approved").DefaultCellStyle.BackColor = 
        End If
        RaiseEvent FormAfterOpenRow(advance_id)
        Me.Cursor = Cursors.Arrow
        ''''Me.isNew = False

        Return True
    End Function

    Private Overloads Function uiTransaksiAdvanceRequest_Lock(ByVal advance_id As String) As Boolean
        Dim col, i As Integer
        Dim activeColor As Color = Color.White
        Dim lockColor As Color = Color.Gainsboro
        Dim tbl_checkOrdered As DataTable = clsDataset.CreateTblTrnAdvancedetil
        Dim tbl_checkRequest As DataTable = clsDataset.CreateTblTrnAdvancedetil
        Dim isOrdered As Boolean = False
        Dim isRequest As Boolean = False
        Dim isApprovedBMA As Boolean = False
        Dim isApprovedProc As Boolean = False

        '''''''Lock additem
        tbl_checkOrdered.Clear()
        Me.DataFill(tbl_checkOrdered, "vq_TrnAdvancedetil_Select", String.Format("advance_id = '{0}' AND advancedetil_ordered = 1", advance_id))

        tbl_checkRequest.Clear()
        Me.DataFill(tbl_checkRequest, "vq_TrnAdvanceItemDetil_Selects", String.Format("b.advance_id = '{0}' AND advance_isrequest = 1", advance_id))

        If tbl_checkOrdered.Rows.Count > 0 Then
            isOrdered = True
        End If

        If tbl_checkRequest.Rows.Count > 0 Then
            isRequest = True
        End If

        If Me._PROGRAMTYPE = "PG" And (Me._SOURCE = "Advance Request" Or Me._SOURCE = "Reimburse Request") Then
            Me.cmdAddItemManual.Enabled = True
        Else
            Me.cmdAddItemManual.Enabled = False
        End If

        '''''''1. 1st Lock
        '''''''Lock header
        If isOrdered Or isRequest Then
            ''''''    'header
            obj_Advance_entrydt.Enabled = False
            obj_Advance_entryby.Enabled = False
            obj_strukturunit_id_dest.Enabled = False
            obj_Advance_usedby.Enabled = False
            obj_RequestType.Enabled = False

            obj_budget_id_view.Enabled = False
            obj_budget_id_code.Enabled = False

            obj_Request_formid.Enabled = False
            obj_Request_jurnalisposted.Enabled = False
            obj_Advance_epsstart.Enabled = False
            obj_Advance_epsend.Enabled = False
            obj_Advance_currency.Enabled = False
            obj_rekanan_id.Enabled = False

            Me.chkSingleBgt.Enabled = False

            obj_payment_type.Enabled = False

            'add/del item and description
            If Me._USERSTRUKTURUNIT <> Department.BMA Then
                cmdAddItemManual.Enabled = False

                cmdAddDesc.Enabled = False
                cmdDelDesc.Enabled = False

                obj_Advance_descr.ReadOnly = False
                obj_Advance_descr.BackColor = Color.White

                For l As Integer = 0 To Me.DgvTrnAdvanceDetil.RowCount - 1
                    If Me.DgvTrnAdvanceDetil.Rows(l).Cells("advancedetil_approvedbma").Value = 0 Then
                        cmdAddItemManual.Enabled = False
                        cmdAddDesc.Enabled = True
                        cmdDelDesc.Enabled = True
                        Exit For
                    End If
                Next
            Else
                cmdAddItemManual.Enabled = False
                cmdAddDesc.Enabled = False
                cmdDelDesc.Enabled = False
                obj_Advance_descr.ReadOnly = True
                obj_Advance_descr.BackColor = Color.Gainsboro
            End If

            obj_Request_active.Enabled = False

            'user info
            obj_Request_preparedt.Enabled = False
            obj_advance_prepare_dt.Enabled = False
            obj_Advance_preparedt_time.Enabled = False
            obj_Request_useddt.Enabled = False
            obj_Request_useddt_date.Enabled = False
            obj_Request_useddt_time.Enabled = False
            obj_Request_useddt2.Enabled = False
            obj_Request_useddt2_date.Enabled = False
            obj_Request_useddt2_time.Enabled = False

            obj_Advance_approved1dt.Enabled = False
            obj_Advance_modifieddt.Enabled = False
            obj_Advance_userpic.Enabled = False
            obj_Advance_approved1by.Enabled = False
            obj_Advance_modifiedby.Enabled = False
            obj_Advance_prepareloc.Enabled = False
            obj_Request_usedloc.Enabled = False

            'attachment
            obj_attach_browse.Enabled = False

            ''''' Sudah ada Request nya
            ''baru
            ''''ElseIf clsUtil.IsDbNull(Me.tbl_TrnAdvance_Temp.Rows(0).Item("isrequest"), 0) <> 0 Then
            ''''    obj_Advance_entrydt.Enabled = False
            ''''    obj_Advance_entryby.Enabled = False
            ''''    obj_strukturunit_id_dest.Enabled = False
            ''''    obj_Advance_usedby.Enabled = False
            ''''    obj_RequestType.Enabled = False

            ''''    obj_budget_id_view.Enabled = False
            ''''    obj_budget_id_code.Enabled = False

            ''''    obj_Request_formid.Enabled = False
            ''''    obj_Request_jurnalisposted.Enabled = False
            ''''    obj_Advance_epsstart.Enabled = False
            ''''    obj_Advance_epsend.Enabled = False
            ''''    obj_Advance_currency.Enabled = False
            ''''    obj_rekanan_id.Enabled = False

            ''''    obj_payment_type.Enabled = False

            ''''    'add/del item and description
            ''''    cmdAddItemManual.Enabled = False
            ''''    cmdAddDesc.Enabled = False
            ''''    cmdDelDesc.Enabled = False
            ''''    obj_Advance_descr.ReadOnly = True
            ''''    obj_Advance_descr.BackColor = Color.Gainsboro
            ''''    obj_Request_active.Enabled = False

            ''''    'user info
            ''''    obj_Request_preparedt.Enabled = False
            ''''    obj_Advance_preparedt_date.Enabled = False
            ''''    obj_Advance_preparedt_time.Enabled = False
            ''''    obj_Request_useddt.Enabled = False
            ''''    obj_Request_useddt_date.Enabled = False
            ''''    obj_Request_useddt_time.Enabled = False
            ''''    obj_Request_useddt2.Enabled = False
            ''''    obj_Request_useddt2_date.Enabled = False
            ''''    obj_Request_useddt2_time.Enabled = False

            ''''    obj_Advance_approved1dt.Enabled = False
            ''''    obj_Advance_modifieddt.Enabled = False
            ''''    obj_Advance_userpic.Enabled = False
            ''''    obj_Advance_approved1by.Enabled = False
            ''''    obj_Advance_modifiedby.Enabled = False
            ''''    obj_Advance_prepareloc.Enabled = False
            ''''    obj_Request_usedloc.Enabled = False

            ''''    'attachment
            ''''    obj_attach_browse.Enabled = False

        ElseIf Me._USERSTRUKTURUNIT = Me.tbl_TrnAdvance_Temp.Rows(0).Item("strukturunit_id") And Me.tbl_TrnAdvance_Temp.Rows(0).Item("advance_approved1") = 0 And Me.tbl_TrnAdvance_Temp.Rows(0).Item("advance_canceled") = 0 Then
            ''''''    'departmen asal dan belum di approve oleh kadept

            ''''''    'header
            obj_Advance_entrydt.Enabled = False
            obj_Advance_entryby.Enabled = False
            obj_strukturunit_id_dest.Enabled = True
            obj_Advance_usedby.Enabled = True
            obj_RequestType.Enabled = True

            obj_Request_formid.Enabled = True
            obj_Request_jurnalisposted.Enabled = True
            obj_Advance_epsstart.Enabled = True
            obj_Advance_epsend.Enabled = True
            obj_Advance_currency.Enabled = False
            obj_budget_id_code.Enabled = False
            obj_budget_id_view.Enabled = False
            obj_rekanan_id.Enabled = False
            Me.tbtnSave.Enabled = True
            Me.chkSingleBgt.Enabled = False

            'add/del item and description
            cmdAddDesc.Enabled = True
            cmdDelDesc.Enabled = True
            obj_Request_active.Enabled = True

            '' ''If Me._SOURCE = "Reimburse Settlement" Then
            '' ''    cmdAddItemManual.Enabled = False
            '' ''Else
            cmdAddItemManual.Enabled = True
            '' ''End If

            obj_payment_type.Enabled = True

            'user info
            obj_Request_preparedt.Enabled = True
            obj_advance_prepare_dt.Enabled = True
            obj_Advance_preparedt_time.Enabled = True
            obj_Request_useddt.Enabled = True
            obj_Request_useddt_date.Enabled = True
            obj_Request_useddt_time.Enabled = True
            obj_Request_useddt2.Enabled = True
            obj_Request_useddt2_date.Enabled = True
            obj_Request_useddt2_time.Enabled = True

            obj_Advance_approved1dt.Enabled = False
            obj_Advance_modifieddt.Enabled = False
            obj_Advance_userpic.Enabled = True
            obj_Advance_approved1by.Enabled = False
            obj_Advance_modifiedby.Enabled = False
            obj_Advance_prepareloc.Enabled = True
            obj_Request_usedloc.Enabled = True

            'attachment
            obj_attach_browse.Enabled = True

            'note
            'obj_Request_descr.Enabled = True
            obj_Advance_descr.ReadOnly = False
            obj_Advance_descr.BackColor = Color.White

            '3. 3nd Lock
        ElseIf Me._USERSTRUKTURUNIT = Me.tbl_TrnAdvance_Temp.Rows(0).Item("strukturunit_id") And (Me.tbl_TrnAdvance_Temp.Rows(0).Item("advance_approved1") = 2 Or Me.tbl_TrnAdvance_Temp.Rows(0).Item("advance_approved1") = 3) And Me.tbl_TrnAdvance_Temp.Rows(0).Item("advance_canceled") = 0 Then
            'departmen asal dan telah di disapprove oleh kadept dan di revised

            'header
            obj_Advance_entrydt.Enabled = False
            obj_Advance_entryby.Enabled = False
            obj_strukturunit_id_dest.Enabled = True
            obj_Advance_usedby.Enabled = True
            obj_RequestType.Enabled = True

            obj_Request_formid.Enabled = True
            obj_Request_jurnalisposted.Enabled = True
            obj_Advance_epsstart.Enabled = True
            obj_Advance_epsend.Enabled = True
            obj_Advance_currency.Enabled = False
            Me.chkSingleBgt.Enabled = False

            'add/del item and description
            cmdAddDesc.Enabled = True
            cmdDelDesc.Enabled = True
            obj_Request_active.Enabled = True

            '=========REMARK PTS 20131206====
            'obj_budget_id_view.Enabled = True
            'obj_budget_id_code.Enabled = True
            'obj_rekanan_id.Enabled = True
            '==========Modified PTS20131206==========
            obj_budget_id_view.Enabled = False
            obj_budget_id_code.Enabled = False
            obj_rekanan_id.Enabled = False
            '===============================
            obj_payment_type.Enabled = True
            'user info
            obj_Request_preparedt.Enabled = True
            obj_advance_prepare_dt.Enabled = True
            obj_Advance_preparedt_time.Enabled = True
            obj_Request_useddt.Enabled = True
            obj_Request_useddt_date.Enabled = True
            obj_Request_useddt_time.Enabled = True
            obj_Request_useddt2.Enabled = True
            obj_Request_useddt2_date.Enabled = True
            obj_Request_useddt2_time.Enabled = True

            obj_Advance_approved1dt.Enabled = False
            obj_Advance_modifieddt.Enabled = False
            obj_Advance_userpic.Enabled = True
            obj_Advance_approved1by.Enabled = False
            obj_Advance_modifiedby.Enabled = False
            obj_Advance_prepareloc.Enabled = True
            obj_Request_usedloc.Enabled = True

            'attachment
            obj_attach_browse.Enabled = True

            '' ''If Me._SOURCE = "Reimburse Settlement" Then
            '' ''    cmdAddItemManual.Enabled = False
            '' ''Else
            cmdAddItemManual.Enabled = True
            '' ''End If
            'note
            'obj_Request_descr.Enabled = True
            obj_Advance_descr.ReadOnly = False
            obj_Advance_descr.BackColor = Color.White

            ''''''    '4. 4nd Lock
        ElseIf Me._USERSTRUKTURUNIT = Department.BMA And Me.tbl_TrnAdvance_Temp.Rows(0).Item("advance_canceled") = 0 And Not isOrdered Then
            'department bma

            'header
            obj_Advance_entrydt.Enabled = False
            obj_Advance_entryby.Enabled = False
            obj_strukturunit_id_dest.Enabled = False
            obj_Advance_usedby.Enabled = False
            obj_RequestType.Enabled = False

            obj_Request_formid.Enabled = False
            obj_Request_jurnalisposted.Enabled = False
            obj_Advance_epsstart.Enabled = False
            obj_Advance_epsend.Enabled = False
            obj_Advance_currency.Enabled = False
            Me.chkSingleBgt.Enabled = False

            'add/del item and description
            cmdAddDesc.Enabled = True
            cmdDelDesc.Enabled = True
            If Me.isNew = True Then
                cmdAddItemManual.Enabled = True
                obj_budget_id_code.Enabled = False
                obj_budget_id_view.Enabled = False
                obj_rekanan_id.Enabled = False
                obj_Request_active.Enabled = True
                obj_payment_type.Enabled = True
            Else
                cmdAddItemManual.Enabled = False
                obj_budget_id_code.Enabled = False
                obj_budget_id_view.Enabled = False
                obj_rekanan_id.Enabled = False
                obj_Request_active.Enabled = False
                obj_payment_type.Enabled = False
            End If


            'user info
            obj_Request_preparedt.Enabled = False
            obj_advance_prepare_dt.Enabled = False
            obj_Advance_preparedt_time.Enabled = False
            obj_Request_useddt.Enabled = False
            obj_Request_useddt_date.Enabled = False
            obj_Request_useddt_time.Enabled = False
            obj_Request_useddt2.Enabled = False
            obj_Request_useddt2_date.Enabled = False
            obj_Request_useddt2_time.Enabled = False

            obj_Advance_approved1dt.Enabled = False
            obj_Advance_modifieddt.Enabled = False
            obj_Advance_userpic.Enabled = False
            obj_Advance_approved1by.Enabled = False
            obj_Advance_modifiedby.Enabled = False
            obj_Advance_prepareloc.Enabled = False
            obj_Request_usedloc.Enabled = False

            'attachment
            obj_attach_browse.Enabled = False

            'note
            'obj_Request_descr.Enabled = False
            obj_Advance_descr.ReadOnly = True
            obj_Advance_descr.BackColor = Color.Gainsboro

            ''''''    '5. 5nd Lock
        ElseIf Me._USERSTRUKTURUNIT = Me.tbl_TrnAdvance_Temp.Rows(0).Item("strukturunit_id") And Me.tbl_TrnAdvance_Temp.Rows(0).Item("advance_approved1") = 1 And Me.tbl_TrnAdvance_Temp.Rows(0).Item("advance_canceled") = 0 Then
            'department asal dan telah di approved

            'header
            obj_rekanan_id.Enabled = False
            obj_Advance_entrydt.Enabled = False
            obj_Advance_entryby.Enabled = False
            obj_strukturunit_id_dest.Enabled = False
            obj_Advance_usedby.Enabled = False
            obj_RequestType.Enabled = False

            obj_Request_formid.Enabled = False
            obj_Request_jurnalisposted.Enabled = False
            obj_Advance_currency.Enabled = False
            Me.chkSingleBgt.Enabled = False

            'add/del item and description
            cmdAddDesc.Enabled = False
            cmdDelDesc.Enabled = False
            cmdAddItemManual.Enabled = False

            obj_Request_active.Enabled = False

            obj_payment_type.Enabled = False
            obj_Request_preparedt.Enabled = False
            obj_advance_prepare_dt.Enabled = False
            obj_Advance_preparedt_time.Enabled = False
            obj_Request_useddt.Enabled = False
            obj_Request_useddt_date.Enabled = False
            obj_Request_useddt_time.Enabled = False
            obj_Request_useddt2.Enabled = False
            obj_Request_useddt2_date.Enabled = False
            obj_Request_useddt2_time.Enabled = False
            obj_Advance_prepareloc.Enabled = False
            obj_Request_usedloc.Enabled = False
            obj_Advance_epsstart.Enabled = False
            obj_Advance_epsend.Enabled = False

            obj_budget_id_view.Enabled = False
            obj_budget_id_code.Enabled = False

            obj_Advance_approved1dt.Enabled = False
            obj_Advance_modifieddt.Enabled = False
            obj_Advance_userpic.Enabled = False
            obj_Advance_approved1by.Enabled = False
            obj_Advance_modifiedby.Enabled = False
            obj_Advance_currency.Enabled = False

            'attachment
            obj_attach_browse.Enabled = False

            'note
            obj_Advance_descr.ReadOnly = True
            obj_Advance_descr.BackColor = Color.LightGray

            ''''''    '6. 6nd Lock
        Else
            'department lainnya

            'header
            obj_Advance_entrydt.Enabled = False
            obj_Advance_entryby.Enabled = False
            obj_strukturunit_id_dest.Enabled = False
            obj_Advance_usedby.Enabled = False
            obj_RequestType.Enabled = False
            Me.chkSingleBgt.Enabled = False

            obj_budget_id_view.Enabled = False
            obj_budget_id_code.Enabled = False

            obj_Request_formid.Enabled = False
            obj_Request_jurnalisposted.Enabled = False
            obj_Advance_epsstart.Enabled = False
            obj_Advance_epsend.Enabled = False
            obj_Advance_currency.Enabled = False

            'add/del item and description
            cmdAddItemManual.Enabled = False
            cmdAddDesc.Enabled = False
            cmdDelDesc.Enabled = False
            obj_Request_active.Enabled = False

            obj_payment_type.Enabled = False
            'user info
            obj_Request_preparedt.Enabled = False
            obj_advance_prepare_dt.Enabled = False
            obj_Advance_preparedt_time.Enabled = False
            obj_Request_useddt.Enabled = False
            obj_Request_useddt_date.Enabled = False
            obj_Request_useddt_time.Enabled = False
            obj_Request_useddt2.Enabled = False
            obj_Request_useddt2_date.Enabled = False
            obj_Request_useddt2_time.Enabled = False

            obj_Advance_approved1dt.Enabled = False
            obj_Advance_modifieddt.Enabled = False
            obj_Advance_userpic.Enabled = False
            obj_Advance_approved1by.Enabled = False
            obj_Advance_modifiedby.Enabled = False
            obj_Advance_prepareloc.Enabled = False
            obj_Request_usedloc.Enabled = False

            'attachment
            obj_attach_browse.Enabled = False

            'note
            'obj_Request_descr.Enabled = False
            obj_Advance_descr.ReadOnly = True
            obj_Advance_descr.BackColor = Color.Gainsboro
            obj_rekanan_id.Enabled = False
            obj_payment_addr.ReadOnly = True
            obj_payment_addr.BackColor = Color.Gainsboro
            ''''If Me.DgvTrnRequestdetilSum.Rows.Count > 0 Then
            ''''    Me.uiTransaksiRentalRequest_UpdateAfterCanceled()
            ''''End If
        End If

        '''''''Lock detail
        '''''''1. 1st Lock
        If isOrdered Or isRequest Then
            For col = 0 To Me.DgvTrnAdvanceDetil.Columns.Count - 1
                Me.DgvTrnAdvanceDetil.Columns(col).ReadOnly = True
                Me.DgvTrnAdvanceDetil.Columns(col).DefaultCellStyle.BackColor = lockColor
            Next

            Me.DgvTrnAdvanceDetil.Columns("bma_approved").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("bma_approved").DefaultCellStyle.BackColor = lockColor
            Me.DgvTrnAdvanceDetil.Columns("bma_approveddt").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("bma_approveddt").DefaultCellStyle.BackColor = lockColor
            Me.DgvTrnAdvanceDetil.Columns("bma_approvedby").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("bma_approvedby").DefaultCellStyle.BackColor = lockColor
            Me.DgvTrnAdvanceDetil.Columns("bma_memo").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("bma_memo").DefaultCellStyle.BackColor = lockColor

            Me.DgvTrnAdvanceDetil.Columns("advancedetil_canceled").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_canceled").DefaultCellStyle.BackColor = lockColor
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_canceleddt").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_canceleddt").DefaultCellStyle.BackColor = lockColor
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_canceledby").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_canceledby").DefaultCellStyle.BackColor = lockColor

            Me.DgvItemBudgetDetil.Columns("advance_id").Visible = False

            If Me._USERSTRUKTURUNIT = Department.BMA Then
                For i = 0 To Me.DgvTrnAdvanceDetil.Rows.Count - 1
                    If clsUtil.IsDbNull(Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_ordered").Value, 0) = 0 And clsUtil.IsDbNull(Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_approvedbma").Value, 0) = 0 Then
                        If Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_type").Value = 0 Then
                            Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_foreignreal").ReadOnly = True
                            Me.DgvTrnAdvanceDetil.Rows(i).Cells("currency_id").ReadOnly = True
                            ''''Me.DgvTrnAdvanceDetil.Rows(i).Cells("select_additem").ReadOnly = True
                            Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_approvedbma").ReadOnly = True
                            Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_approvedbma").Style.BackColor = Color.Gainsboro
                            Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_approveddescr").ReadOnly = True
                            Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_approveddescr").Style.BackColor = lockColor
                            Me.DgvTrnAdvanceDetil.Rows(i).Cells("select_additem").ReadOnly = True

                        Else
                            Dim lockApprove As DataTable = New DataTable

                            lockApprove.Clear()
                            Me.DataFill(lockApprove, "vq_TrnAdvanceDetilLock_Select", String.Format("b.advance_id = '{0}' AND b.advancedetil_line = {1}", clsUtil.IsDbNull(Me.DgvTrnAdvanceDetil.Rows(i).Cells("advance_id").Value, ""), Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_line").Value))

                            If lockApprove.Rows.Count > 0 Then
                                Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_approvedbma").ReadOnly = False
                                Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_approvedbma").Style.BackColor = Color.White
                            Else
                                Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_approvedbma").ReadOnly = True
                                Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_approvedbma").Style.BackColor = Color.Gainsboro
                            End If

                            Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_foreignreal").ReadOnly = True
                            Me.DgvTrnAdvanceDetil.Rows(i).Cells("currency_id").ReadOnly = True
                            ''''Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_approvedbma").ReadOnly = False
                            Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_approveddescr").ReadOnly = False
                            Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_descr").ReadOnly = False
                            Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_paymentdt").ReadOnly = False
                            Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_paymenttype").ReadOnly = False
                            Me.DgvTrnAdvanceDetil.Rows(i).Cells("select_additem").ReadOnly = False

                        End If
                    ElseIf clsUtil.IsDbNull(Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_ordered").Value, 0) = 0 And clsUtil.IsDbNull(Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_approvedbma").Value, 0) = 1 Then
                        If Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_type").Value = 0 Then
                            Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_foreignreal").ReadOnly = True
                            Me.DgvTrnAdvanceDetil.Rows(i).Cells("currency_id").ReadOnly = True
                            Me.DgvTrnAdvanceDetil.Rows(i).Cells("select_additem").ReadOnly = True
                            Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_approvedbma").ReadOnly = True
                            Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_approvedbma").Style.BackColor = Color.Gainsboro
                            Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_approveddescr").ReadOnly = True
                            Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_approveddescr").Style.BackColor = lockColor

                        Else
                            Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_foreignreal").ReadOnly = True
                            Me.DgvTrnAdvanceDetil.Rows(i).Cells("currency_id").ReadOnly = True

                            Dim lockApprove As DataTable = New DataTable

                            lockApprove.Clear()
                            Me.DataFill(lockApprove, "vq_TrnAdvanceDetilLock_Select", String.Format("b.advance_id = '{0}' AND b.advancedetil_line = {1}", clsUtil.IsDbNull(Me.DgvTrnAdvanceDetil.Rows(i).Cells("advance_id").Value, ""), Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_line").Value))

                            If lockApprove.Rows.Count > 0 Then
                                Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_approvedbma").ReadOnly = False
                                Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_approvedbma").Style.BackColor = Color.White
                            Else
                                Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_approvedbma").ReadOnly = True
                                Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_approvedbma").Style.BackColor = Color.Gainsboro
                            End If

                            ''''Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_approvedbma").ReadOnly = False
                            Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_approveddescr").ReadOnly = False

                            Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_paymentdt").ReadOnly = True
                            Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_paymenttype").ReadOnly = True
                            Me.DgvTrnAdvanceDetil.Rows(i).Cells("select_additem").ReadOnly = True

                        End If
                    ElseIf clsUtil.IsDbNull(Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_ordered").Value, 0) = 1 And clsUtil.IsDbNull(Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_approvedbma").Value, 0) = 1 Then
                        Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_foreignreal").ReadOnly = True
                        Me.DgvTrnAdvanceDetil.Rows(i).Cells("currency_id").ReadOnly = True
                        Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_approvedbma").ReadOnly = True
                        Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_approveddescr").ReadOnly = True

                        Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_paymentdt").ReadOnly = True
                        Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_paymenttype").ReadOnly = True
                        Me.DgvTrnAdvanceDetil.Rows(i).Cells("select_additem").ReadOnly = True

                    End If
                Next
            ElseIf Me._USERSTRUKTURUNIT <> Department.BMA Then
                For i = 0 To Me.DgvTrnAdvanceDetil.Rows.Count - 1
                    If clsUtil.IsDbNull(Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_ordered").Value, 0) = 0 And clsUtil.IsDbNull(Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_approvedbma").Value, 0) = 0 Then
                        If Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_type").Value = 0 Then
                            Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_foreignreal").ReadOnly = True
                            Me.DgvTrnAdvanceDetil.Rows(i).Cells("currency_id").ReadOnly = True
                            Me.DgvTrnAdvanceDetil.Rows(i).Cells("select_additem").ReadOnly = True
                            Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_approveddescr").ReadOnly = True
                            Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_approveddescr").Style.BackColor = lockColor

                        Else
                            Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_foreignreal").ReadOnly = True
                            Me.DgvTrnAdvanceDetil.Rows(i).Cells("currency_id").ReadOnly = True
                            Me.DgvTrnAdvanceDetil.Rows(i).Cells("select_additem").ReadOnly = False

                        End If

                        Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_descr").ReadOnly = False

                    ElseIf clsUtil.IsDbNull(Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_ordered").Value, 0) = 0 And clsUtil.IsDbNull(Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_approvedbma").Value, 0) = 1 Then
                        Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_foreignreal").ReadOnly = True
                        Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_descr").ReadOnly = True
                        Me.DgvTrnAdvanceDetil.Rows(i).Cells("currency_id").ReadOnly = True
                        Me.DgvTrnAdvanceDetil.Rows(i).Cells("select_additem").ReadOnly = True

                    ElseIf clsUtil.IsDbNull(Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_ordered").Value, 0) = 1 And clsUtil.IsDbNull(Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_approvedbma").Value, 0) = 1 Then
                        Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_foreignreal").ReadOnly = True
                        Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_descr").ReadOnly = True
                        Me.DgvTrnAdvanceDetil.Rows(i).Cells("currency_id").ReadOnly = True
                        Me.DgvTrnAdvanceDetil.Rows(i).Cells("select_additem").ReadOnly = True

                    End If
                Next
            End If

            Me.DgvTrnAdvanceDetil.Columns("advancedetil_idrreal").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_idrreal").DefaultCellStyle.BackColor = lockColor
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_subtotal").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_subtotal").DefaultCellStyle.BackColor = lockColor
            Me.DgvItemBudgetDetil.Columns("outstanding_budget").ReadOnly = True
            Me.DgvItemBudgetDetil.Columns("outstanding_budget").DefaultCellStyle.BackColor = lockColor

            Me.DgvTrnAdvanceDetil.AllowUserToAddRows = False
            Me.DgvTrnAdvanceDetil.AllowUserToDeleteRows = False
            Me.DgvItemBudgetDetil.AllowUserToAddRows = False
            Me.DgvItemBudgetDetil.AllowUserToDeleteRows = False

            '''''sudah ada Request nya
            'baru
            ''''ElseIf clsUtil.IsDbNull(Me.tbl_TrnAdvance_Temp.Rows(0).Item("isrequest"), 0) <> 0 Then
            ''''    For col = 0 To Me.DgvTrnAdvanceDetil.Columns.Count - 1
            ''''        Me.DgvTrnAdvanceDetil.Columns(col).ReadOnly = True
            ''''        Me.DgvTrnAdvanceDetil.Columns(col).DefaultCellStyle.BackColor = lockColor
            ''''    Next

            ''''    Me.DgvItemBudgetDetil.Columns("advance_id").Visible = False

            ''''    If Me._USERSTRUKTURUNIT = Department.BMA Then
            ''''        For i = 0 To Me.DgvTrnAdvanceDetil.Rows.Count - 1
            ''''            If clsUtil.IsDbNull(Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_ordered").Value, 0) = 0 And clsUtil.IsDbNull(Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_approvedbma").Value, 0) = 0 Then
            ''''                If Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_type").Value = 0 Then
            ''''                    Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_foreignreal").ReadOnly = True
            ''''                    Me.DgvTrnAdvanceDetil.Rows(i).Cells("currency_id").ReadOnly = True

            ''''                Else
            ''''                    Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_foreignreal").ReadOnly = True
            ''''                    Me.DgvTrnAdvanceDetil.Rows(i).Cells("currency_id").ReadOnly = True
            ''''                    Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_approvedbma").ReadOnly = False
            ''''                    Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_approveddescr").ReadOnly = False

            ''''                End If
            ''''            ElseIf clsUtil.IsDbNull(Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_ordered").Value, 0) = 0 And clsUtil.IsDbNull(Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_approvedbma").Value, 0) = 1 Then
            ''''                If Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_type").Value = 0 Then
            ''''                    Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_foreignreal").ReadOnly = True
            ''''                    Me.DgvTrnAdvanceDetil.Rows(i).Cells("currency_id").ReadOnly = True

            ''''                Else
            ''''                    Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_foreignreal").ReadOnly = True
            ''''                    Me.DgvTrnAdvanceDetil.Rows(i).Cells("currency_id").ReadOnly = True
            ''''                    Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_approvedbma").ReadOnly = False
            ''''                    Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_approveddescr").ReadOnly = False

            ''''                End If
            ''''            ElseIf clsUtil.IsDbNull(Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_ordered").Value, 0) = 1 And clsUtil.IsDbNull(Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_approvedbma").Value, 0) = 1 Then
            ''''                Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_foreignreal").ReadOnly = True
            ''''                Me.DgvTrnAdvanceDetil.Rows(i).Cells("currency_id").ReadOnly = True
            ''''                Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_approvedbma").ReadOnly = True
            ''''                Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_approveddescr").ReadOnly = True

            ''''            End If
            ''''        Next
            ''''    ElseIf Me._USERSTRUKTURUNIT <> Department.BMA Then
            ''''        For i = 0 To Me.DgvTrnAdvanceDetil.Rows.Count - 1
            ''''            If clsUtil.IsDbNull(Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_ordered").Value, 0) = 0 And clsUtil.IsDbNull(Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_approvedbma").Value, 0) = 0 Then
            ''''                If Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_type").Value = 0 Then
            ''''                    Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_foreignreal").ReadOnly = True
            ''''                    Me.DgvTrnAdvanceDetil.Rows(i).Cells("currency_id").ReadOnly = True

            ''''                Else
            ''''                    Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_foreignreal").ReadOnly = True
            ''''                    Me.DgvTrnAdvanceDetil.Rows(i).Cells("currency_id").ReadOnly = True

            ''''                End If

            ''''                Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_descr").ReadOnly = False

            ''''            ElseIf clsUtil.IsDbNull(Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_ordered").Value, 0) = 0 And clsUtil.IsDbNull(Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_approvedbma").Value, 0) = 1 Then
            ''''                Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_foreignreal").ReadOnly = True
            ''''                Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_descr").ReadOnly = True
            ''''                Me.DgvTrnAdvanceDetil.Rows(i).Cells("currency_id").ReadOnly = True

            ''''            ElseIf clsUtil.IsDbNull(Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_ordered").Value, 0) = 1 And clsUtil.IsDbNull(Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_approvedbma").Value, 0) = 1 Then
            ''''                Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_foreignreal").ReadOnly = True
            ''''                Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_descr").ReadOnly = True
            ''''                Me.DgvTrnAdvanceDetil.Rows(i).Cells("currency_id").ReadOnly = True

            ''''            End If
            ''''        Next
            ''''    End If

            ''''    Me.DgvTrnAdvanceDetil.Columns("advancedetil_idrreal").ReadOnly = True
            ''''    Me.DgvTrnAdvanceDetil.Columns("advancedetil_idrreal").DefaultCellStyle.BackColor = lockColor
            ''''    Me.DgvItemBudgetDetil.Columns("outstanding_budget").ReadOnly = True
            ''''    Me.DgvItemBudgetDetil.Columns("outstanding_budget").DefaultCellStyle.BackColor = lockColor

            ''''    Me.DgvTrnAdvanceDetil.AllowUserToAddRows = False
            ''''    Me.DgvTrnAdvanceDetil.AllowUserToDeleteRows = False
            ''''    Me.DgvItemBudgetDetil.AllowUserToAddRows = False
            ''''    Me.DgvItemBudgetDetil.AllowUserToDeleteRows = False

            ''''''    '2. 2nd Lock
        ElseIf Me._USERSTRUKTURUNIT = Me.tbl_TrnAdvance_Temp.Rows(0).Item("strukturunit_id") And Me.tbl_TrnAdvance_Temp.Rows(0).Item("advance_approved1") = 0 And Me.tbl_TrnAdvance_Temp.Rows(0).Item("advance_canceled") = 0 Then
            'departmen asal dan belum di approve oleh kadept

            For col = 0 To Me.DgvTrnAdvanceDetil.Columns.Count - 1
                Me.DgvTrnAdvanceDetil.Columns(col).ReadOnly = False
                Me.DgvTrnAdvanceDetil.Columns(col).DefaultCellStyle.BackColor = activeColor
            Next

            Me.DgvTrnAdvanceDetil.Columns("bma_approved").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("bma_approved").DefaultCellStyle.BackColor = lockColor
            Me.DgvTrnAdvanceDetil.Columns("bma_approveddt").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("bma_approveddt").DefaultCellStyle.BackColor = lockColor
            Me.DgvTrnAdvanceDetil.Columns("bma_approvedby").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("bma_approvedby").DefaultCellStyle.BackColor = lockColor
            Me.DgvTrnAdvanceDetil.Columns("bma_memo").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("bma_memo").DefaultCellStyle.BackColor = lockColor

            Me.DgvTrnAdvanceDetil.Columns("advancedetil_canceled").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_canceled").DefaultCellStyle.BackColor = lockColor
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_canceleddt").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_canceleddt").DefaultCellStyle.BackColor = lockColor
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_canceledby").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_canceledby").DefaultCellStyle.BackColor = lockColor

            Me.DgvTrnAdvanceDetil.Columns("advancedetil_type").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_type").DefaultCellStyle.BackColor = lockColor
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_line").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_line").DefaultCellStyle.BackColor = lockColor
            Me.DgvTrnAdvanceDetil.Columns("status_over").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("status_over").DefaultCellStyle.BackColor = lockColor

            Me.DgvTrnAdvanceDetil.Columns("currency_id").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("currency_id").DefaultCellStyle.BackColor = lockColor
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_idrreal").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_idrreal").DefaultCellStyle.BackColor = lockColor
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_subtotal").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_subtotal").DefaultCellStyle.BackColor = lockColor
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_foreignreal").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_foreignreal").DefaultCellStyle.BackColor = lockColor
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_foreignrate").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_foreignrate").DefaultCellStyle.BackColor = lockColor

            Me.DgvTrnAdvanceDetil.Columns("advancedetil_approvedbma").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_approvedbma").DefaultCellStyle.BackColor = lockColor
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_approvedbmadt").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_approvedbmadt").DefaultCellStyle.BackColor = lockColor
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_approvedbmaby").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_approvedbmaby").DefaultCellStyle.BackColor = lockColor
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_approveddescr").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_approveddescr").DefaultCellStyle.BackColor = lockColor

            Me.DgvItemBudgetDetil.Columns("outstanding_budget").ReadOnly = True
            Me.DgvItemBudgetDetil.Columns("outstanding_budget").DefaultCellStyle.BackColor = lockColor
            Me.DgvItemBudgetDetil.Columns("amount_advance").ReadOnly = True
            Me.DgvItemBudgetDetil.Columns("amount_advance").DefaultCellStyle.BackColor = lockColor
            Me.DgvItemBudgetDetil.Columns("budgetdetil_eps").ReadOnly = True
            Me.DgvItemBudgetDetil.Columns("budgetdetil_eps").DefaultCellStyle.BackColor = lockColor
            Me.DgvItemBudgetDetil.Columns("advance_id").Visible = False


            Dim q As Integer

            For q = 0 To Me.DgvTrnAdvanceDetil.Rows.Count - 1
                If Me.DgvTrnAdvanceDetil.Rows(q).Cells("advancedetil_type").Value = 0 Then
                    Me.DgvTrnAdvanceDetil.Rows(q).Cells("select_additem").ReadOnly = True

                Else
                    Me.DgvTrnAdvanceDetil.Rows(q).Cells("select_additem").ReadOnly = False
                End If
            Next

            Me.DgvTrnAdvanceDetil.AllowUserToDeleteRows = True
            Me.DgvTrnAdvanceDetil.AllowUserToAddRows = False
            Me.DgvItemBudgetDetil.AllowUserToAddRows = False
            Me.DgvItemBudgetDetil.AllowUserToDeleteRows = False
            ''''''    '3. 3th Lock
        ElseIf Me._USERSTRUKTURUNIT = Me.tbl_TrnAdvance_Temp.Rows(0).Item("strukturunit_id") And (Me.tbl_TrnAdvance_Temp.Rows(0).Item("advance_approved1") = 2 Or Me.tbl_TrnAdvance_Temp.Rows(0).Item("advance_approved1") = 3) And Me.tbl_TrnAdvance_Temp.Rows(0).Item("advance_canceled") = 0 Then
            'departmen asal dan telah di disapprove oleh kadept dan revised

            For col = 0 To Me.DgvTrnAdvanceDetil.Columns.Count - 1
                Me.DgvTrnAdvanceDetil.Columns(col).ReadOnly = False
                Me.DgvTrnAdvanceDetil.Columns(col).DefaultCellStyle.BackColor = activeColor
            Next

            Me.DgvTrnAdvanceDetil.Columns("bma_approved").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("bma_approved").DefaultCellStyle.BackColor = lockColor
            Me.DgvTrnAdvanceDetil.Columns("bma_approveddt").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("bma_approveddt").DefaultCellStyle.BackColor = lockColor
            Me.DgvTrnAdvanceDetil.Columns("bma_approvedby").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("bma_approvedby").DefaultCellStyle.BackColor = lockColor
            Me.DgvTrnAdvanceDetil.Columns("bma_memo").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("bma_memo").DefaultCellStyle.BackColor = lockColor

            Me.DgvTrnAdvanceDetil.Columns("advancedetil_canceled").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_canceled").DefaultCellStyle.BackColor = lockColor
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_canceleddt").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_canceleddt").DefaultCellStyle.BackColor = lockColor
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_canceledby").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_canceledby").DefaultCellStyle.BackColor = lockColor

            Me.DgvTrnAdvanceDetil.Columns("advancedetil_type").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_type").DefaultCellStyle.BackColor = lockColor
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_line").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_line").DefaultCellStyle.BackColor = lockColor
            Me.DgvTrnAdvanceDetil.Columns("status_over").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("status_over").DefaultCellStyle.BackColor = lockColor

            Me.DgvTrnAdvanceDetil.Columns("currency_id").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("currency_id").DefaultCellStyle.BackColor = lockColor
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_foreignrate").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_foreignrate").DefaultCellStyle.BackColor = lockColor
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_idrreal").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_idrreal").DefaultCellStyle.BackColor = lockColor
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_subtotal").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_subtotal").DefaultCellStyle.BackColor = lockColor
            ''''Me.DgvTrnAdvanceDetil.Columns("outstanding_budget").ReadOnly = True
            ''''Me.DgvTrnAdvanceDetil.Columns("outstanding_budget").DefaultCellStyle.BackColor = lockColor
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_foreignreal").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_foreignreal").DefaultCellStyle.BackColor = lockColor

            Me.DgvTrnAdvanceDetil.Columns("advancedetil_approvedbma").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_approvedbma").DefaultCellStyle.BackColor = lockColor
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_approvedbmadt").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_approvedbmadt").DefaultCellStyle.BackColor = lockColor
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_approvedbmaby").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_approvedbmaby").DefaultCellStyle.BackColor = lockColor

            Me.DgvItemBudgetDetil.Columns("outstanding_budget").ReadOnly = True
            Me.DgvItemBudgetDetil.Columns("outstanding_budget").DefaultCellStyle.BackColor = lockColor
            Me.DgvItemBudgetDetil.Columns("advance_id").Visible = False

            Dim q As Integer

            For q = 0 To Me.DgvTrnAdvanceDetil.Rows.Count - 1
                If Me.DgvTrnAdvanceDetil.Rows(q).Cells("advancedetil_type").Value = 0 Then
                    Me.DgvTrnAdvanceDetil.Rows(q).Cells("select_additem").ReadOnly = True
                Else
                    Me.DgvTrnAdvanceDetil.Rows(q).Cells("select_additem").ReadOnly = False
                End If
            Next

            Me.DgvTrnAdvanceDetil.AllowUserToAddRows = False
            Me.DgvTrnAdvanceDetil.AllowUserToDeleteRows = True
            Me.DgvItemBudgetDetil.AllowUserToAddRows = False
            Me.DgvItemBudgetDetil.AllowUserToDeleteRows = False

            ''''''    '4. 4th Lock
        ElseIf Me._USERSTRUKTURUNIT = Me.tbl_TrnAdvance_Temp.Rows(0).Item("strukturunit_id") And (Me.tbl_TrnAdvance_Temp.Rows(0).Item("advance_approved1") = 1 Or Me.tbl_TrnAdvance_Temp.Rows(0).Item("advance_approved2") = 1) And Me.tbl_TrnAdvance_Temp.Rows(0).Item("advance_canceled") = 0 Then
            'department asal dan sudah di approved

            For col = 0 To Me.DgvTrnAdvanceDetil.Columns.Count - 1
                Me.DgvTrnAdvanceDetil.Columns(col).ReadOnly = False
                Me.DgvTrnAdvanceDetil.Columns(col).DefaultCellStyle.BackColor = activeColor
            Next

            Me.DgvTrnAdvanceDetil.Columns("advancedetil_type").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_type").DefaultCellStyle.BackColor = lockColor
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_line").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_line").DefaultCellStyle.BackColor = lockColor

            Me.DgvTrnAdvanceDetil.Columns("bma_approved").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("bma_approved").DefaultCellStyle.BackColor = lockColor
            Me.DgvTrnAdvanceDetil.Columns("bma_approveddt").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("bma_approveddt").DefaultCellStyle.BackColor = lockColor
            Me.DgvTrnAdvanceDetil.Columns("bma_approvedby").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("bma_approvedby").DefaultCellStyle.BackColor = lockColor
            Me.DgvTrnAdvanceDetil.Columns("bma_memo").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("bma_memo").DefaultCellStyle.BackColor = lockColor

            Me.DgvTrnAdvanceDetil.Columns("advancedetil_canceled").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_canceled").DefaultCellStyle.BackColor = lockColor
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_canceleddt").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_canceleddt").DefaultCellStyle.BackColor = lockColor
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_canceledby").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_canceledby").DefaultCellStyle.BackColor = lockColor

            Me.DgvTrnAdvanceDetil.Columns("advancedetil_approvedbmadt").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_approvedbmadt").DefaultCellStyle.BackColor = lockColor
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_approvedbmaby").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_approvedbmaby").DefaultCellStyle.BackColor = lockColor

            Me.DgvTrnAdvanceDetil.Columns("advancedetil_paymentdt").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_paymentdt").DefaultCellStyle.BackColor = lockColor
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_paymenttype").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_paymenttype").DefaultCellStyle.BackColor = lockColor

            ''''Me.DgvTrnAdvanceDetil.Columns("advancedetil_approveddescr").ReadOnly = True
            ''''Me.DgvTrnAdvanceDetil.Columns("advancedetil_approveddescr").DefaultCellStyle.BackColor = lockColor

            Dim z As Integer

            For z = 0 To Me.DgvTrnAdvanceDetil.Rows.Count - 1
                If Me._USERSTRUKTURUNIT = Department.BMA Then
                    If Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_approvedbma").Value = 1 Then
                        If Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_ordered").Value = 1 Then
                            If Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_type").Value = 0 Then
                                Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_descr").ReadOnly = True
                                Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_descr").Style.BackColor = lockColor
                                Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_approvedbma").ReadOnly = True
                                Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_approvedbma").Style.BackColor = lockColor
                                Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_approveddescr").ReadOnly = True
                                Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_approveddescr").Style.BackColor = lockColor

                                Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_paymentdt").ReadOnly = True
                                Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_paymentdt").Style.BackColor = lockColor
                                Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_paymenttype").ReadOnly = True
                                Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_paymenttype").Style.BackColor = lockColor

                                Me.DgvTrnAdvanceDetil.Rows(i).Cells("select_additem").ReadOnly = True
                                ''''Me.DgvTrnAdvanceDetil.Rows(i).Cells("select_additem").Style.BackColor = lockColor
                            Else
                                Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_descr").ReadOnly = True
                                Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_descr").Style.BackColor = lockColor
                                Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_approvedbma").ReadOnly = True
                                Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_approvedbma").Style.BackColor = lockColor
                                Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_approveddescr").ReadOnly = True
                                Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_approveddescr").Style.BackColor = lockColor

                                Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_paymentdt").ReadOnly = True
                                Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_paymentdt").Style.BackColor = lockColor
                                Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_paymenttype").ReadOnly = True
                                Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_paymenttype").Style.BackColor = lockColor

                                ''''Me.DgvTrnAdvanceDetil.Rows(i).Cells("select_additem").ReadOnly = True
                                ''''Me.DgvTrnAdvanceDetil.Rows(i).Cells("select_additem").Style.BackColor = lockColor
                            End If

                        Else

                            If Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_type").Value = 0 Then
                                Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_descr").ReadOnly = False
                                Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_descr").Style.BackColor = activeColor
                                Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_approvedbma").ReadOnly = True
                                Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_approvedbma").Style.BackColor = lockColor

                                Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_approveddescr").ReadOnly = True
                                Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_approveddescr").Style.BackColor = lockColor

                                Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_paymentdt").ReadOnly = True
                                Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_paymentdt").Style.BackColor = lockColor
                                Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_paymenttype").ReadOnly = True
                                Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_paymenttype").Style.BackColor = lockColor
                                Me.DgvTrnAdvanceDetil.Rows(i).Cells("select_additem").ReadOnly = True

                            Else
                                Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_descr").ReadOnly = True
                                Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_descr").Style.BackColor = lockColor


                                Dim lockApprove As DataTable = New DataTable

                                lockApprove.Clear()
                                Me.DataFill(lockApprove, "vq_TrnAdvanceDetilLock_Select", String.Format("b.advance_id = '{0}' AND b.advancedetil_line = {1}", clsUtil.IsDbNull(Me.DgvTrnAdvanceDetil.Rows(z).Cells("advance_id").Value, ""), Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_line").Value))

                                If lockApprove.Rows.Count > 0 Then
                                    Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_approvedbma").ReadOnly = False
                                    Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_approvedbma").Style.BackColor = activeColor
                                Else
                                    Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_approvedbma").ReadOnly = True
                                    Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_approvedbma").Style.BackColor = lockColor
                                End If

                                'Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_approvedbma").ReadOnly = False
                                'Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_approvedbma").Style.BackColor = activeColor
                                Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_approveddescr").ReadOnly = False
                                Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_approveddescr").Style.BackColor = activeColor

                                Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_paymentdt").ReadOnly = False
                                Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_paymentdt").Style.BackColor = activeColor
                                Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_paymenttype").ReadOnly = False
                                Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_paymenttype").Style.BackColor = activeColor
                                Me.DgvTrnAdvanceDetil.Rows(i).Cells("select_additem").ReadOnly = False
                                ''''Me.DgvTrnAdvanceDetil.Rows(i).Cells("select_additem").Style.BackColor = activeColor

                            End If

                        End If

                    Else

                        If Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_type").Value = 0 Then
                            Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_descr").ReadOnly = False
                            Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_descr").Style.BackColor = activeColor
                            Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_approvedbma").ReadOnly = True
                            Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_approvedbma").Style.BackColor = lockColor

                            Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_approveddescr").ReadOnly = True
                            Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_approveddescr").Style.BackColor = lockColor

                            Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_paymentdt").ReadOnly = True
                            Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_paymentdt").Style.BackColor = lockColor
                            Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_paymenttype").ReadOnly = True
                            Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_paymenttype").Style.BackColor = lockColor

                            Me.DgvTrnAdvanceDetil.Rows(i).Cells("select_additem").ReadOnly = False
                            ''''Me.DgvTrnAdvanceDetil.Rows(i).Cells("select_additem").Style.BackColor = activeColor

                        Else
                            Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_descr").ReadOnly = False
                            Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_descr").Style.BackColor = activeColor

                            Dim lockApprove As DataTable = New DataTable

                            lockApprove.Clear()
                            Me.DataFill(lockApprove, "vq_TrnAdvanceDetilLock_Select", String.Format("b.advance_id = '{0}' AND b.advancedetil_line = {1}", clsUtil.IsDbNull(Me.DgvTrnAdvanceDetil.Rows(z).Cells("advance_id").Value, ""), Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_line").Value))

                            If lockApprove.Rows.Count > 0 Then
                                Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_approvedbma").ReadOnly = False
                                Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_approvedbma").Style.BackColor = activeColor
                            Else
                                Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_approvedbma").ReadOnly = True
                                Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_approvedbma").Style.BackColor = lockColor
                            End If


                            Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_approveddescr").ReadOnly = False
                            Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_approveddescr").Style.BackColor = activeColor

                            Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_paymentdt").ReadOnly = False
                            Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_paymentdt").Style.BackColor = activeColor
                            Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_paymenttype").ReadOnly = False
                            Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_paymenttype").Style.BackColor = activeColor

                            Me.DgvTrnAdvanceDetil.Rows(i).Cells("select_additem").ReadOnly = False
                            ''''Me.DgvTrnAdvanceDetil.Rows(i).Cells("select_additem").Style.BackColor = activeColor
                        End If
                    End If

                    'bukan BMA
                Else
                    If Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_approvedbma").Value = 1 Then
                        Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_descr").ReadOnly = True
                        Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_descr").Style.BackColor = lockColor
                        Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_approvedbma").ReadOnly = True
                        Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_approvedbma").Style.BackColor = lockColor
                        Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_approveddescr").ReadOnly = True
                        Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_approveddescr").Style.BackColor = lockColor

                        ''''Me.DgvTrnAdvanceDetil.Rows(i).Cells("select_additem").ReadOnly = True
                        ''''Me.DgvTrnAdvanceDetil.Rows(i).Cells("select_additem").Style.BackColor = lockColor
                    Else
                        If Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_type").Value = 0 Then
                            Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_descr").ReadOnly = False
                            Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_descr").Style.BackColor = activeColor
                            Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_approvedbma").ReadOnly = True
                            Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_approvedbma").Style.BackColor = lockColor
                            Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_approveddescr").ReadOnly = True
                            Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_approveddescr").Style.BackColor = lockColor

                            Me.DgvTrnAdvanceDetil.Rows(i).Cells("select_additem").ReadOnly = True
                            ''''Me.DgvTrnAdvanceDetil.Rows(i).Cells("select_additem").Style.BackColor = lockColor
                        Else
                            Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_descr").ReadOnly = False
                            Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_descr").Style.BackColor = activeColor
                            Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_approvedbma").ReadOnly = True
                            Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_approvedbma").Style.BackColor = lockColor
                            Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_approveddescr").ReadOnly = True
                            Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_approveddescr").Style.BackColor = lockColor

                            ''''Me.DgvTrnAdvanceDetil.Rows(i).Cells("select_additem").ReadOnly = True
                            ''''Me.DgvTrnAdvanceDetil.Rows(i).Cells("select_additem").Style.BackColor = lockColor
                        End If

                    End If
                End If

            Next


            ''''Me.DgvTrnAdvanceDetil.Columns("advancedetil_descr").ReadOnly = True
            ''''Me.DgvTrnAdvanceDetil.Columns("advancedetil_descr").DefaultCellStyle.BackColor = lockColor

            Me.DgvTrnAdvanceDetil.Columns("status_over").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("status_over").DefaultCellStyle.BackColor = lockColor

            'description
            obj_budget_id_view.Enabled = False
            obj_budget_id_code.Enabled = False
            Me.tbtnSave.Enabled = True


            Me.DgvItemBudgetDetil.Columns("amount_advance").ReadOnly = True
            Me.DgvItemBudgetDetil.Columns("amount_advance").DefaultCellStyle.BackColor = lockColor
            Me.DgvItemBudgetDetil.Columns("budgetdetil_eps").ReadOnly = True
            Me.DgvItemBudgetDetil.Columns("budgetdetil_eps").DefaultCellStyle.BackColor = lockColor

            Me.DgvTrnAdvanceDetil.Columns("currency_id").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("currency_id").DefaultCellStyle.BackColor = lockColor
            ''''Me.DgvTrnAdvanceDetil.Columns("advancedetil_descr").ReadOnly = True
            ''''Me.DgvTrnAdvanceDetil.Columns("advancedetil_descr").DefaultCellStyle.BackColor = lockColor
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_foreignreal").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_foreignreal").DefaultCellStyle.BackColor = lockColor
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_foreignrate").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_foreignrate").DefaultCellStyle.BackColor = lockColor
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_idrreal").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_idrreal").DefaultCellStyle.BackColor = lockColor
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_subtotal").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_subtotal").DefaultCellStyle.BackColor = lockColor

            Me.DgvItemBudgetDetil.Columns("advance_id").Visible = False

            Me.DgvTrnAdvanceDetil.AllowUserToAddRows = False
            Me.DgvTrnAdvanceDetil.AllowUserToDeleteRows = True
            Me.DgvItemBudgetDetil.AllowUserToAddRows = False
            Me.DgvItemBudgetDetil.AllowUserToDeleteRows = False

            ''''''    '5. 5nd Lock
        ElseIf Me._USERSTRUKTURUNIT = Department.BMA And Me.tbl_TrnAdvance_Temp.Rows(0).Item("advance_canceled") = 0 Then
            'department bma

            For col = 0 To Me.DgvTrnAdvanceDetil.Columns.Count - 1
                Me.DgvTrnAdvanceDetil.Columns(col).ReadOnly = True
                Me.DgvTrnAdvanceDetil.Columns(col).DefaultCellStyle.BackColor = lockColor
            Next

            Me.DgvItemBudgetDetil.Columns("advance_id").Visible = False

            Me.DgvTrnAdvanceDetil.Columns("bma_approved").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("bma_approved").DefaultCellStyle.BackColor = lockColor
            Me.DgvTrnAdvanceDetil.Columns("bma_approveddt").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("bma_approveddt").DefaultCellStyle.BackColor = lockColor
            Me.DgvTrnAdvanceDetil.Columns("bma_approvedby").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("bma_approvedby").DefaultCellStyle.BackColor = lockColor
            Me.DgvTrnAdvanceDetil.Columns("bma_memo").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("bma_memo").DefaultCellStyle.BackColor = lockColor

            Me.DgvTrnAdvanceDetil.Columns("advancedetil_canceled").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_canceled").DefaultCellStyle.BackColor = lockColor
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_canceleddt").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_canceleddt").DefaultCellStyle.BackColor = lockColor
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_canceledby").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_canceledby").DefaultCellStyle.BackColor = lockColor

            Dim d As Integer

            For d = 0 To Me.DgvTrnAdvanceDetil.Rows.Count - 1
                If clsUtil.IsDbNull(Me.DgvTrnAdvanceDetil.Rows(d).Cells("advancedetil_ordered").Value, False) = 0 Then
                    ''''Me.DgvTrnAdvanceDetil.Rows(d).Cells("advancedetil_approvedbma").ReadOnly = False
                    ''''Me.DgvTrnAdvanceDetil.Rows(d).Cells("advancedetil_approveddescr").ReadOnly = False
                    If clsUtil.IsDbNull(Me.DgvTrnAdvanceDetil.Rows(d).Cells("advancedetil_approvedbma").Value, False) = 0 Then
                        If Me.isNew = True Then


                            If Me.DgvTrnAdvanceDetil.Rows(d).Cells("advancedetil_type").Value = 0 Then
                                Me.DgvTrnAdvanceDetil.Rows(d).Cells("advancedetil_approvedbma").ReadOnly = True
                                Me.DgvTrnAdvanceDetil.Rows(d).Cells("advancedetil_approveddescr").ReadOnly = True
                                Me.DgvTrnAdvanceDetil.Rows(d).Cells("advancedetil_descr").ReadOnly = True
                                Me.DgvTrnAdvanceDetil.Rows(d).Cells("advancedetil_paymentdt").ReadOnly = True
                                Me.DgvTrnAdvanceDetil.Rows(d).Cells("advancedetil_paymenttype").ReadOnly = True
                                Me.DgvTrnAdvanceDetil.Rows(d).Cells("select_additem").ReadOnly = True

                            Else
                                Me.DgvTrnAdvanceDetil.Rows(d).Cells("advancedetil_approvedbma").ReadOnly = True
                                Me.DgvTrnAdvanceDetil.Rows(d).Cells("advancedetil_approveddescr").ReadOnly = True
                                Me.DgvTrnAdvanceDetil.Rows(d).Cells("advancedetil_descr").ReadOnly = False
                                Me.DgvTrnAdvanceDetil.Rows(d).Cells("advancedetil_paymentdt").ReadOnly = False
                                Me.DgvTrnAdvanceDetil.Rows(d).Cells("advancedetil_paymenttype").ReadOnly = False
                                Me.DgvTrnAdvanceDetil.Rows(d).Cells("select_additem").ReadOnly = False

                            End If

                            ''''Me.DgvTrnAdvanceDetil.Rows(i).Cells("select_additem").ReadOnly = False

                        Else

                            Dim lockApprove As DataTable = New DataTable

                            If Me.DgvTrnAdvanceDetil.Rows(d).Cells("advancedetil_type").Value = 0 Then

                                Me.DgvTrnAdvanceDetil.Rows(d).Cells("advancedetil_approvedbma").ReadOnly = True
                                Me.DgvTrnAdvanceDetil.Rows(d).Cells("advancedetil_approvedbma").Style.BackColor = Color.Gainsboro

                                Me.DgvTrnAdvanceDetil.Rows(d).Cells("advancedetil_approveddescr").ReadOnly = True
                                Me.DgvTrnAdvanceDetil.Rows(d).Cells("advancedetil_descr").ReadOnly = True

                                Me.DgvTrnAdvanceDetil.Rows(d).Cells("advancedetil_paymentdt").ReadOnly = True
                                Me.DgvTrnAdvanceDetil.Rows(d).Cells("advancedetil_paymenttype").ReadOnly = True
                                Me.DgvTrnAdvanceDetil.Rows(d).Cells("select_additem").ReadOnly = True

                            Else

                                lockApprove.Clear()
                                Me.DataFill(lockApprove, "vq_TrnAdvanceDetilLock_Select", String.Format("b.advance_id = '{0}' AND b.advancedetil_line = {1}", clsUtil.IsDbNull(Me.DgvTrnAdvanceDetil.Rows(d).Cells("advance_id").Value, ""), Me.DgvTrnAdvanceDetil.Rows(d).Cells("advancedetil_line").Value))

                                If lockApprove.Rows.Count > 0 Then
                                    Me.DgvTrnAdvanceDetil.Rows(d).Cells("advancedetil_approvedbma").ReadOnly = False
                                    Me.DgvTrnAdvanceDetil.Rows(d).Cells("advancedetil_approvedbma").Style.BackColor = Color.White
                                Else
                                    Me.DgvTrnAdvanceDetil.Rows(d).Cells("advancedetil_approvedbma").ReadOnly = True
                                    Me.DgvTrnAdvanceDetil.Rows(d).Cells("advancedetil_approvedbma").Style.BackColor = Color.Gainsboro
                                End If

                                Me.DgvTrnAdvanceDetil.Rows(d).Cells("advancedetil_approveddescr").ReadOnly = False
                                Me.DgvTrnAdvanceDetil.Rows(d).Cells("advancedetil_descr").ReadOnly = False

                                Me.DgvTrnAdvanceDetil.Rows(d).Cells("advancedetil_paymentdt").ReadOnly = False
                                Me.DgvTrnAdvanceDetil.Rows(d).Cells("advancedetil_paymenttype").ReadOnly = False
                                Me.DgvTrnAdvanceDetil.Rows(d).Cells("select_additem").ReadOnly = False
                            End If
                        End If

                    Else

                        Dim lockApprove As DataTable = New DataTable

                        If Me.DgvTrnAdvanceDetil.Rows(d).Cells("advancedetil_type").Value = 0 Then

                            Me.DgvTrnAdvanceDetil.Rows(d).Cells("advancedetil_approvedbma").ReadOnly = True
                            Me.DgvTrnAdvanceDetil.Rows(d).Cells("advancedetil_approvedbma").Style.BackColor = Color.Gainsboro

                            Me.DgvTrnAdvanceDetil.Rows(d).Cells("advancedetil_approveddescr").ReadOnly = True
                            Me.DgvTrnAdvanceDetil.Rows(d).Cells("advancedetil_descr").ReadOnly = True

                            Me.DgvTrnAdvanceDetil.Rows(d).Cells("advancedetil_paymentdt").ReadOnly = True
                            Me.DgvTrnAdvanceDetil.Rows(d).Cells("advancedetil_paymenttype").ReadOnly = True
                            Me.DgvTrnAdvanceDetil.Rows(i).Cells("select_additem").ReadOnly = True

                        Else
                            lockApprove.Clear()
                            Me.DataFill(lockApprove, "vq_TrnAdvanceDetilLock_Select", String.Format("b.advance_id = '{0}' AND b.advancedetil_line = {1}", clsUtil.IsDbNull(Me.DgvTrnAdvanceDetil.Rows(d).Cells("advance_id").Value, ""), Me.DgvTrnAdvanceDetil.Rows(d).Cells("advancedetil_line").Value))

                            If lockApprove.Rows.Count > 0 Then
                                Me.DgvTrnAdvanceDetil.Rows(d).Cells("advancedetil_approvedbma").ReadOnly = False
                                Me.DgvTrnAdvanceDetil.Rows(d).Cells("advancedetil_approvedbma").Style.BackColor = Color.White
                            Else
                                Me.DgvTrnAdvanceDetil.Rows(d).Cells("advancedetil_approvedbma").ReadOnly = True
                                Me.DgvTrnAdvanceDetil.Rows(d).Cells("advancedetil_approvedbma").Style.BackColor = Color.Gainsboro
                            End If


                            Me.DgvTrnAdvanceDetil.Rows(d).Cells("advancedetil_approveddescr").ReadOnly = False
                            Me.DgvTrnAdvanceDetil.Rows(d).Cells("advancedetil_descr").ReadOnly = True

                            Me.DgvTrnAdvanceDetil.Rows(d).Cells("advancedetil_paymentdt").ReadOnly = True
                            Me.DgvTrnAdvanceDetil.Rows(d).Cells("advancedetil_paymenttype").ReadOnly = True
                            Me.DgvTrnAdvanceDetil.Rows(i).Cells("select_additem").ReadOnly = True

                        End If
                    End If

                Else
                    Me.DgvTrnAdvanceDetil.Rows(d).Cells("advancedetil_approvedbma").ReadOnly = True
                    Me.DgvTrnAdvanceDetil.Rows(d).Cells("advancedetil_approveddescr").ReadOnly = True
                    Me.DgvTrnAdvanceDetil.Rows(d).Cells("advancedetil_paymentdt").ReadOnly = True
                    Me.DgvTrnAdvanceDetil.Rows(d).Cells("advancedetil_paymenttype").ReadOnly = True
                    Me.DgvTrnAdvanceDetil.Rows(i).Cells("select_additem").ReadOnly = True

                End If
            Next

            Me.DgvTrnAdvanceDetil.AllowUserToAddRows = False
            Me.DgvTrnAdvanceDetil.AllowUserToDeleteRows = False
            Me.DgvItemBudgetDetil.AllowUserToAddRows = False
            Me.DgvItemBudgetDetil.AllowUserToDeleteRows = False

            ''''''    '6. 6nd Lock
        Else
            'department lainnya
            Dim odatafiller As New clsDataFiller(Me.DSN)

            For col = 0 To Me.DgvTrnAdvanceDetil.Columns.Count - 1
                Me.DgvTrnAdvanceDetil.Columns(col).ReadOnly = True
                Me.DgvTrnAdvanceDetil.Columns(col).DefaultCellStyle.BackColor = lockColor
            Next

            Me.DgvTrnAdvanceDetil.Columns("bma_approved").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("bma_approved").DefaultCellStyle.BackColor = lockColor
            Me.DgvTrnAdvanceDetil.Columns("bma_approveddt").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("bma_approveddt").DefaultCellStyle.BackColor = lockColor
            Me.DgvTrnAdvanceDetil.Columns("bma_approvedby").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("bma_approvedby").DefaultCellStyle.BackColor = lockColor
            Me.DgvTrnAdvanceDetil.Columns("bma_memo").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("bma_memo").DefaultCellStyle.BackColor = lockColor

            Me.DgvTrnAdvanceDetil.Columns("advancedetil_canceled").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_canceled").DefaultCellStyle.BackColor = lockColor
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_canceleddt").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_canceleddt").DefaultCellStyle.BackColor = lockColor
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_canceledby").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_canceledby").DefaultCellStyle.BackColor = lockColor

            Me.DgvItemBudgetDetil.Columns("advance_id").Visible = False

            Me.DgvTrnAdvanceDetil.AllowUserToAddRows = False
            Me.DgvTrnAdvanceDetil.AllowUserToDeleteRows = False
            Me.DgvItemBudgetDetil.AllowUserToAddRows = False
            Me.DgvItemBudgetDetil.AllowUserToDeleteRows = False
        End If


    End Function

    Private Overloads Function uiTransaksiAdvanceRequest_Lock(ByRef dbconn As OleDb.OleDbConnection, ByRef dbtrans As OleDb.OleDbTransaction, ByVal advance_id As String) As Boolean
        Dim col, i As Integer
        Dim activeColor As Color = Color.White
        Dim lockColor As Color = Color.Gainsboro
        Dim tbl_checkOrdered As DataTable = clsDataset.CreateTblTrnAdvancedetil
        Dim tbl_checkRequest As DataTable = clsDataset.CreateTblTrnAdvancedetil
        Dim isOrdered As Boolean = False
        Dim isRequest As Boolean = False
        Dim isApprovedBMA As Boolean = False
        Dim isApprovedProc As Boolean = False

        '''''''Lock additem
        tbl_checkOrdered.Clear()
        Me.DataFill(dbconn, dbtrans, tbl_checkOrdered, "vq_TrnAdvancedetil_Select", String.Format("advance_id = '{0}' AND advancedetil_ordered = 1", advance_id))

        tbl_checkRequest.Clear()
        Me.DataFill(dbconn, dbtrans, tbl_checkRequest, "vq_TrnAdvanceItemDetil_Selects", String.Format("b.advance_id = '{0}' AND advance_isrequest = 1", advance_id))

        If tbl_checkOrdered.Rows.Count > 0 Then
            isOrdered = True
        End If

        If tbl_checkRequest.Rows.Count > 0 Then
            isRequest = True
        End If

        If Me._PROGRAMTYPE = "PG" And (Me._SOURCE = "Advance Request" Or Me._SOURCE = "Reimburse Request") Then
            Me.cmdAddItemManual.Enabled = True
        Else
            Me.cmdAddItemManual.Enabled = False
        End If

        If Me.tbl_TrnAdvance_Temp.Rows(0).Item("advance_approved1") = 0 Or Me.tbl_TrnAdvance_Temp.Rows(0).Item("advance_approved1") = 2 Then
            Me.obj_payment_addr.Enabled = True
        Else
            Me.obj_payment_addr.Enabled = False
        End If


        '''''''1. 1st Lock
        '''''''Lock header
        If isOrdered Or isRequest Then
            ''''''    'header
            obj_Advance_entrydt.Enabled = False
            obj_Advance_entryby.Enabled = False
            obj_strukturunit_id_dest.Enabled = False
            obj_Advance_usedby.Enabled = False
            obj_RequestType.Enabled = False

            obj_budget_id_view.Enabled = False
            obj_budget_id_code.Enabled = False

            obj_Request_formid.Enabled = False
            obj_Request_jurnalisposted.Enabled = False
            obj_Advance_epsstart.Enabled = False
            obj_Advance_epsend.Enabled = False
            obj_Advance_currency.Enabled = False
            obj_rekanan_id.Enabled = False

            Me.chkSingleBgt.Enabled = False

            obj_payment_type.Enabled = False

            'add/del item and description
            If Me._USERSTRUKTURUNIT <> Department.BMA Then
                If Me._MODUL_TYPE = "bma" Then
                    cmdAddItemManual.Enabled = False
                    cmdAddDesc.Enabled = False
                    cmdDelDesc.Enabled = False
                    obj_Advance_descr.ReadOnly = True
                    obj_Advance_descr.BackColor = Color.Gainsboro
                Else
                    cmdAddItemManual.Enabled = False
                    cmdAddDesc.Enabled = False
                    cmdDelDesc.Enabled = False
                    obj_Advance_descr.ReadOnly = False
                    obj_Advance_descr.BackColor = Color.White

                    For l As Integer = 0 To Me.DgvTrnAdvanceDetil.RowCount - 1
                        If Me.DgvTrnAdvanceDetil.Rows(l).Cells("advancedetil_approvedbma").Value = 0 Then
                            cmdAddItemManual.Enabled = False
                            cmdAddDesc.Enabled = True
                            cmdDelDesc.Enabled = True
                            Exit For
                        End If
                    Next
                End If
            Else
                cmdAddItemManual.Enabled = False
                cmdAddDesc.Enabled = False
                cmdDelDesc.Enabled = False
                obj_Advance_descr.ReadOnly = True
                obj_Advance_descr.BackColor = Color.Gainsboro
            End If

            obj_Request_active.Enabled = False

            'user info
            obj_Request_preparedt.Enabled = False
            obj_advance_prepare_dt.Enabled = False
            obj_Advance_preparedt_time.Enabled = False
            obj_Request_useddt.Enabled = False
            obj_Request_useddt_date.Enabled = False
            obj_Request_useddt_time.Enabled = False
            obj_Request_useddt2.Enabled = False
            obj_Request_useddt2_date.Enabled = False
            obj_Request_useddt2_time.Enabled = False

            obj_Advance_approved1dt.Enabled = False
            obj_Advance_modifieddt.Enabled = False
            obj_Advance_userpic.Enabled = False
            obj_Advance_approved1by.Enabled = False
            obj_Advance_modifiedby.Enabled = False
            obj_Advance_prepareloc.Enabled = False
            obj_Request_usedloc.Enabled = False

            'attachment
            obj_attach_browse.Enabled = False

            ''''' Sudah ada Request nya
            ''baru
            ''''ElseIf clsUtil.IsDbNull(Me.tbl_TrnAdvance_Temp.Rows(0).Item("isrequest"), 0) <> 0 Then
            ''''    obj_Advance_entrydt.Enabled = False
            ''''    obj_Advance_entryby.Enabled = False
            ''''    obj_strukturunit_id_dest.Enabled = False
            ''''    obj_Advance_usedby.Enabled = False
            ''''    obj_RequestType.Enabled = False

            ''''    obj_budget_id_view.Enabled = False
            ''''    obj_budget_id_code.Enabled = False

            ''''    obj_Request_formid.Enabled = False
            ''''    obj_Request_jurnalisposted.Enabled = False
            ''''    obj_Advance_epsstart.Enabled = False
            ''''    obj_Advance_epsend.Enabled = False
            ''''    obj_Advance_currency.Enabled = False
            ''''    obj_rekanan_id.Enabled = False

            ''''    obj_payment_type.Enabled = False

            ''''    'add/del item and description
            ''''    cmdAddItemManual.Enabled = False
            ''''    cmdAddDesc.Enabled = False
            ''''    cmdDelDesc.Enabled = False
            ''''    obj_Advance_descr.ReadOnly = True
            ''''    obj_Advance_descr.BackColor = Color.Gainsboro
            ''''    obj_Request_active.Enabled = False

            ''''    'user info
            ''''    obj_Request_preparedt.Enabled = False
            ''''    obj_Advance_preparedt_date.Enabled = False
            ''''    obj_Advance_preparedt_time.Enabled = False
            ''''    obj_Request_useddt.Enabled = False
            ''''    obj_Request_useddt_date.Enabled = False
            ''''    obj_Request_useddt_time.Enabled = False
            ''''    obj_Request_useddt2.Enabled = False
            ''''    obj_Request_useddt2_date.Enabled = False
            ''''    obj_Request_useddt2_time.Enabled = False

            ''''    obj_Advance_approved1dt.Enabled = False
            ''''    obj_Advance_modifieddt.Enabled = False
            ''''    obj_Advance_userpic.Enabled = False
            ''''    obj_Advance_approved1by.Enabled = False
            ''''    obj_Advance_modifiedby.Enabled = False
            ''''    obj_Advance_prepareloc.Enabled = False
            ''''    obj_Request_usedloc.Enabled = False

            ''''    'attachment
            ''''    obj_attach_browse.Enabled = False

        ElseIf Me._USERSTRUKTURUNIT = Me.tbl_TrnAdvance_Temp.Rows(0).Item("strukturunit_id") And Me.tbl_TrnAdvance_Temp.Rows(0).Item("advance_approved1") = 0 And Me.tbl_TrnAdvance_Temp.Rows(0).Item("advance_canceled") = 0 Then
            ''''''    'departmen asal dan belum di approve oleh kadept

            ''''''    'header
            obj_Advance_entrydt.Enabled = False
            obj_Advance_entryby.Enabled = False
            obj_strukturunit_id_dest.Enabled = True
            obj_Advance_usedby.Enabled = True
            obj_RequestType.Enabled = True

            obj_Request_formid.Enabled = True
            obj_Request_jurnalisposted.Enabled = True
            obj_Advance_epsstart.Enabled = True
            obj_Advance_epsend.Enabled = True
            obj_Advance_currency.Enabled = False
            obj_budget_id_code.Enabled = False
            obj_budget_id_view.Enabled = False
            obj_rekanan_id.Enabled = False
            Me.tbtnSave.Enabled = True
            Me.chkSingleBgt.Enabled = False

            'add/del item and description
            cmdAddDesc.Enabled = True
            cmdDelDesc.Enabled = True
            obj_Request_active.Enabled = True

            '' ''If Me._SOURCE = "Reimburse Settlement" Then
            '' ''    cmdAddItemManual.Enabled = False
            '' ''Else
            cmdAddItemManual.Enabled = True
            '' ''End If

            obj_payment_type.Enabled = True

            'user info
            obj_Request_preparedt.Enabled = True
            obj_advance_prepare_dt.Enabled = True
            obj_Advance_preparedt_time.Enabled = True
            obj_Request_useddt.Enabled = True
            obj_Request_useddt_date.Enabled = True
            obj_Request_useddt_time.Enabled = True
            obj_Request_useddt2.Enabled = True
            obj_Request_useddt2_date.Enabled = True
            obj_Request_useddt2_time.Enabled = True

            obj_Advance_approved1dt.Enabled = False
            obj_Advance_modifieddt.Enabled = False
            obj_Advance_userpic.Enabled = True
            obj_Advance_approved1by.Enabled = False
            obj_Advance_modifiedby.Enabled = False
            obj_Advance_prepareloc.Enabled = True
            obj_Request_usedloc.Enabled = True

            'attachment
            obj_attach_browse.Enabled = True

            'note
            'obj_Request_descr.Enabled = True
            obj_Advance_descr.ReadOnly = False
            obj_Advance_descr.BackColor = Color.White

            obj_payment_addr.Enabled = True

            '3. 3nd Lock
        ElseIf Me._USERSTRUKTURUNIT = Me.tbl_TrnAdvance_Temp.Rows(0).Item("strukturunit_id") And (Me.tbl_TrnAdvance_Temp.Rows(0).Item("advance_approved1") = 2 Or Me.tbl_TrnAdvance_Temp.Rows(0).Item("advance_approved1") = 3) And Me.tbl_TrnAdvance_Temp.Rows(0).Item("advance_canceled") = 0 Then
            'departmen asal dan telah di disapprove oleh kadept dan di revised

            'header
            obj_Advance_entrydt.Enabled = False
            obj_Advance_entryby.Enabled = False
            obj_strukturunit_id_dest.Enabled = True
            obj_Advance_usedby.Enabled = True
            obj_RequestType.Enabled = True

            obj_Request_formid.Enabled = True
            obj_Request_jurnalisposted.Enabled = True
            obj_Advance_epsstart.Enabled = True
            obj_Advance_epsend.Enabled = True
            obj_Advance_currency.Enabled = False
            Me.chkSingleBgt.Enabled = False

            'add/del item and description
            cmdAddDesc.Enabled = True
            cmdDelDesc.Enabled = True
            obj_Request_active.Enabled = True

            '========remark pts 20131206
            'obj_budget_id_view.Enabled = True
            'obj_budget_id_code.Enabled = True
            'obj_rekanan_id.Enabled = True
            '==========
            '====modified by pts 20311206
            obj_budget_id_view.Enabled = False
            obj_budget_id_code.Enabled = False
            obj_rekanan_id.Enabled = False
            '=-======================

            obj_payment_type.Enabled = True
            'user info
            obj_Request_preparedt.Enabled = True
            obj_advance_prepare_dt.Enabled = True
            obj_Advance_preparedt_time.Enabled = True
            obj_Request_useddt.Enabled = True
            obj_Request_useddt_date.Enabled = True
            obj_Request_useddt_time.Enabled = True
            obj_Request_useddt2.Enabled = True
            obj_Request_useddt2_date.Enabled = True
            obj_Request_useddt2_time.Enabled = True

            obj_Advance_approved1dt.Enabled = False
            obj_Advance_modifieddt.Enabled = False
            obj_Advance_userpic.Enabled = True
            obj_Advance_approved1by.Enabled = False
            obj_Advance_modifiedby.Enabled = False
            obj_Advance_prepareloc.Enabled = True
            obj_Request_usedloc.Enabled = True

            'attachment
            obj_attach_browse.Enabled = True

            '' ''If Me._SOURCE = "Reimburse Settlement" Then
            '' ''    cmdAddItemManual.Enabled = False
            '' ''Else
            cmdAddItemManual.Enabled = True
            '' ''End If
            'note
            'obj_Request_descr.Enabled = True
            obj_Advance_descr.ReadOnly = False
            obj_Advance_descr.BackColor = Color.White


            obj_payment_addr.Enabled = True
            ''''''    '4. 4nd Lock
        ElseIf (Me._MODUL_TYPE = "bma" Or Me._USERSTRUKTURUNIT = Department.BMA) And Me.tbl_TrnAdvance_Temp.Rows(0).Item("advance_canceled") = 0 And Not isOrdered Then
            'department bma

            'header
            obj_Advance_entrydt.Enabled = False
            obj_Advance_entryby.Enabled = False
            obj_strukturunit_id_dest.Enabled = False
            obj_Advance_usedby.Enabled = False
            obj_RequestType.Enabled = False

            obj_Request_formid.Enabled = False
            obj_Request_jurnalisposted.Enabled = False
            obj_Advance_epsstart.Enabled = False
            obj_Advance_epsend.Enabled = False
            obj_Advance_currency.Enabled = False
            Me.chkSingleBgt.Enabled = False

            'add/del item and description
            cmdAddDesc.Enabled = True
            cmdDelDesc.Enabled = True
            If Me.isNew = True Then
                cmdAddItemManual.Enabled = True
                obj_budget_id_code.Enabled = False
                obj_budget_id_view.Enabled = False
                obj_rekanan_id.Enabled = False
                obj_Request_active.Enabled = True
                obj_payment_type.Enabled = True
            Else
                cmdAddItemManual.Enabled = False
                obj_budget_id_code.Enabled = False
                obj_budget_id_view.Enabled = False
                obj_rekanan_id.Enabled = False
                obj_Request_active.Enabled = False
                obj_payment_type.Enabled = False
            End If


            'user info
            obj_Request_preparedt.Enabled = False
            obj_advance_prepare_dt.Enabled = False
            obj_Advance_preparedt_time.Enabled = False
            obj_Request_useddt.Enabled = False
            obj_Request_useddt_date.Enabled = False
            obj_Request_useddt_time.Enabled = False
            obj_Request_useddt2.Enabled = False
            obj_Request_useddt2_date.Enabled = False
            obj_Request_useddt2_time.Enabled = False

            obj_Advance_approved1dt.Enabled = False
            obj_Advance_modifieddt.Enabled = False
            obj_Advance_userpic.Enabled = False
            obj_Advance_approved1by.Enabled = False
            obj_Advance_modifiedby.Enabled = False
            obj_Advance_prepareloc.Enabled = False
            obj_Request_usedloc.Enabled = False

            'attachment
            obj_attach_browse.Enabled = False

            'note
            'obj_Request_descr.Enabled = False
            obj_Advance_descr.ReadOnly = True
            obj_Advance_descr.BackColor = Color.Gainsboro

            ''''''    '5. 5nd Lock
        ElseIf Me._USERSTRUKTURUNIT = Me.tbl_TrnAdvance_Temp.Rows(0).Item("strukturunit_id") And Me.tbl_TrnAdvance_Temp.Rows(0).Item("advance_approved1") = 1 And Me.tbl_TrnAdvance_Temp.Rows(0).Item("advance_canceled") = 0 Then
            'department asal dan telah di approved

            'header
            obj_rekanan_id.Enabled = False
            obj_Advance_entrydt.Enabled = False
            obj_Advance_entryby.Enabled = False
            obj_strukturunit_id_dest.Enabled = False
            obj_Advance_usedby.Enabled = False
            obj_RequestType.Enabled = False

            obj_Request_formid.Enabled = False
            obj_Request_jurnalisposted.Enabled = False
            obj_Advance_currency.Enabled = False
            Me.chkSingleBgt.Enabled = False

            'add/del item and description
            cmdAddDesc.Enabled = False
            cmdDelDesc.Enabled = False
            cmdAddItemManual.Enabled = False

            obj_Request_active.Enabled = False

            obj_payment_type.Enabled = False
            obj_Request_preparedt.Enabled = False
            obj_advance_prepare_dt.Enabled = False
            obj_Advance_preparedt_time.Enabled = False
            obj_Request_useddt.Enabled = False
            obj_Request_useddt_date.Enabled = False
            obj_Request_useddt_time.Enabled = False
            obj_Request_useddt2.Enabled = False
            obj_Request_useddt2_date.Enabled = False
            obj_Request_useddt2_time.Enabled = False
            obj_Advance_prepareloc.Enabled = False
            obj_Request_usedloc.Enabled = False
            obj_Advance_epsstart.Enabled = False
            obj_Advance_epsend.Enabled = False

            obj_budget_id_view.Enabled = False
            obj_budget_id_code.Enabled = False

            obj_Advance_approved1dt.Enabled = False
            obj_Advance_modifieddt.Enabled = False
            obj_Advance_userpic.Enabled = False
            obj_Advance_approved1by.Enabled = False
            obj_Advance_modifiedby.Enabled = False
            obj_Advance_currency.Enabled = False

            'attachment
            obj_attach_browse.Enabled = False

            'note
            obj_Advance_descr.ReadOnly = True
            obj_Advance_descr.BackColor = Color.LightGray
            obj_payment_addr.Enabled = False
            ''''''    '6. 6nd Lock
        Else
            'department lainnya

            'header
            obj_Advance_entrydt.Enabled = False
            obj_Advance_entryby.Enabled = False
            obj_strukturunit_id_dest.Enabled = False
            obj_Advance_usedby.Enabled = False
            obj_RequestType.Enabled = False
            Me.chkSingleBgt.Enabled = False

            obj_budget_id_view.Enabled = False
            obj_budget_id_code.Enabled = False
            obj_rekanan_id.Enabled = False
            obj_Request_formid.Enabled = False
            obj_Request_jurnalisposted.Enabled = False
            obj_Advance_epsstart.Enabled = False
            obj_Advance_epsend.Enabled = False
            obj_Advance_currency.Enabled = False

            'add/del item and description
            cmdAddItemManual.Enabled = False
            cmdAddDesc.Enabled = False
            cmdDelDesc.Enabled = False
            obj_Request_active.Enabled = False

            obj_payment_type.Enabled = False
            'user info
            obj_Request_preparedt.Enabled = False
            obj_advance_prepare_dt.Enabled = False
            obj_Advance_preparedt_time.Enabled = False
            obj_Request_useddt.Enabled = False
            obj_Request_useddt_date.Enabled = False
            obj_Request_useddt_time.Enabled = False
            obj_Request_useddt2.Enabled = False
            obj_Request_useddt2_date.Enabled = False
            obj_Request_useddt2_time.Enabled = False

            obj_Advance_approved1dt.Enabled = False
            obj_Advance_modifieddt.Enabled = False
            obj_Advance_userpic.Enabled = False
            obj_Advance_approved1by.Enabled = False
            obj_Advance_modifiedby.Enabled = False
            obj_Advance_prepareloc.Enabled = False
            obj_Request_usedloc.Enabled = False

            'attachment
            obj_attach_browse.Enabled = False

            'note
            'obj_Request_descr.Enabled = False
            obj_Advance_descr.ReadOnly = True
            obj_Advance_descr.BackColor = Color.Gainsboro
            obj_rekanan_id.Enabled = False
            obj_payment_addr.ReadOnly = True
            obj_payment_addr.BackColor = Color.Gainsboro
            ''''If Me.DgvTrnRequestdetilSum.Rows.Count > 0 Then
            ''''    Me.uiTransaksiRentalRequest_UpdateAfterCanceled()
            ''''End If

            obj_payment_addr.Enabled = False



        End If

        If Me.tbl_TrnAdvance_Temp.Rows(0).Item("advance_approved1") = 0 Or Me.tbl_TrnAdvance_Temp.Rows(0).Item("advance_approved1") = 2 Then
            Me.obj_payment_addr.Enabled = True
        Else
            Me.obj_payment_addr.Enabled = False
        End If

        '''''''Lock detail
        '''''''1. 1st Lock
        If isOrdered Or isRequest Then
            For col = 0 To Me.DgvTrnAdvanceDetil.Columns.Count - 1
                Me.DgvTrnAdvanceDetil.Columns(col).ReadOnly = True
                Me.DgvTrnAdvanceDetil.Columns(col).DefaultCellStyle.BackColor = lockColor
            Next

            Me.DgvTrnAdvanceDetil.Columns("bma_approved").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("bma_approved").DefaultCellStyle.BackColor = lockColor
            Me.DgvTrnAdvanceDetil.Columns("bma_approveddt").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("bma_approveddt").DefaultCellStyle.BackColor = lockColor
            Me.DgvTrnAdvanceDetil.Columns("bma_approvedby").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("bma_approvedby").DefaultCellStyle.BackColor = lockColor
            Me.DgvTrnAdvanceDetil.Columns("bma_memo").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("bma_memo").DefaultCellStyle.BackColor = lockColor

            Me.DgvTrnAdvanceDetil.Columns("advancedetil_canceled").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_canceled").DefaultCellStyle.BackColor = lockColor
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_canceleddt").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_canceleddt").DefaultCellStyle.BackColor = lockColor
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_canceledby").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_canceledby").DefaultCellStyle.BackColor = lockColor

            Me.DgvItemBudgetDetil.Columns("advance_id").Visible = False

            If Me._USERSTRUKTURUNIT = Department.BMA Or Me._MODUL_TYPE = "bma" Then
                For i = 0 To Me.DgvTrnAdvanceDetil.Rows.Count - 1
                    If clsUtil.IsDbNull(Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_ordered").Value, 0) = 0 And clsUtil.IsDbNull(Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_approvedbma").Value, 0) = 0 Then
                        If Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_type").Value = 0 Then
                            Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_foreignreal").ReadOnly = True
                            Me.DgvTrnAdvanceDetil.Rows(i).Cells("currency_id").ReadOnly = True
                            ''''Me.DgvTrnAdvanceDetil.Rows(i).Cells("select_additem").ReadOnly = True
                            Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_approvedbma").ReadOnly = True
                            Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_approvedbma").Style.BackColor = Color.Gainsboro
                            Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_approveddescr").ReadOnly = True
                            Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_approveddescr").Style.BackColor = lockColor
                            Me.DgvTrnAdvanceDetil.Rows(i).Cells("select_additem").ReadOnly = True

                        Else
                            Dim lockApprove As DataTable = New DataTable

                            lockApprove.Clear()
                            Me.DataFill(dbconn, dbtrans, lockApprove, "vq_TrnAdvanceDetilLock_Select", String.Format("b.advance_id = '{0}' AND b.advancedetil_line = {1}", clsUtil.IsDbNull(Me.DgvTrnAdvanceDetil.Rows(i).Cells("advance_id").Value, ""), Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_line").Value))

                            If lockApprove.Rows.Count > 0 Then
                                Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_approvedbma").ReadOnly = False
                                Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_approvedbma").Style.BackColor = Color.White
                            Else
                                Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_approvedbma").ReadOnly = True
                                Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_approvedbma").Style.BackColor = Color.Gainsboro
                            End If

                            Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_foreignreal").ReadOnly = True
                            Me.DgvTrnAdvanceDetil.Rows(i).Cells("currency_id").ReadOnly = True
                            ''''Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_approvedbma").ReadOnly = False
                            Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_approveddescr").ReadOnly = False
                            Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_descr").ReadOnly = False
                            Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_paymentdt").ReadOnly = False
                            Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_paymenttype").ReadOnly = False
                            Me.DgvTrnAdvanceDetil.Rows(i).Cells("select_additem").ReadOnly = False

                        End If
                    ElseIf clsUtil.IsDbNull(Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_ordered").Value, 0) = 0 And clsUtil.IsDbNull(Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_approvedbma").Value, 0) = 1 Then
                        If Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_type").Value = 0 Then
                            Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_foreignreal").ReadOnly = True
                            Me.DgvTrnAdvanceDetil.Rows(i).Cells("currency_id").ReadOnly = True
                            Me.DgvTrnAdvanceDetil.Rows(i).Cells("select_additem").ReadOnly = True
                            Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_approvedbma").ReadOnly = True
                            Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_approvedbma").Style.BackColor = Color.Gainsboro
                            Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_approveddescr").ReadOnly = True
                            Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_approveddescr").Style.BackColor = lockColor

                        Else
                            Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_foreignreal").ReadOnly = True
                            Me.DgvTrnAdvanceDetil.Rows(i).Cells("currency_id").ReadOnly = True

                            Dim lockApprove As DataTable = New DataTable

                            lockApprove.Clear()
                            Me.DataFill(dbconn, dbtrans, lockApprove, "vq_TrnAdvanceDetilLock_Select", String.Format("b.advance_id = '{0}' AND b.advancedetil_line = {1}", clsUtil.IsDbNull(Me.DgvTrnAdvanceDetil.Rows(i).Cells("advance_id").Value, ""), Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_line").Value))

                            If lockApprove.Rows.Count > 0 Then
                                Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_approvedbma").ReadOnly = False
                                Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_approvedbma").Style.BackColor = Color.White
                            Else
                                Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_approvedbma").ReadOnly = True
                                Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_approvedbma").Style.BackColor = Color.Gainsboro
                            End If

                            ''''Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_approvedbma").ReadOnly = False
                            Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_approveddescr").ReadOnly = False

                            Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_paymentdt").ReadOnly = True
                            Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_paymenttype").ReadOnly = True
                            Me.DgvTrnAdvanceDetil.Rows(i).Cells("select_additem").ReadOnly = True

                        End If
                    ElseIf clsUtil.IsDbNull(Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_ordered").Value, 0) = 1 And clsUtil.IsDbNull(Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_approvedbma").Value, 0) = 1 Then
                        Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_foreignreal").ReadOnly = True
                        Me.DgvTrnAdvanceDetil.Rows(i).Cells("currency_id").ReadOnly = True
                        Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_approvedbma").ReadOnly = True
                        Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_approveddescr").ReadOnly = True

                        Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_paymentdt").ReadOnly = True
                        Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_paymenttype").ReadOnly = True
                        Me.DgvTrnAdvanceDetil.Rows(i).Cells("select_additem").ReadOnly = True

                    End If
                Next
            ElseIf Me._USERSTRUKTURUNIT <> Department.BMA Then
                For i = 0 To Me.DgvTrnAdvanceDetil.Rows.Count - 1
                    If clsUtil.IsDbNull(Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_ordered").Value, 0) = 0 And clsUtil.IsDbNull(Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_approvedbma").Value, 0) = 0 Then
                        If Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_type").Value = 0 Then
                            Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_foreignreal").ReadOnly = True
                            Me.DgvTrnAdvanceDetil.Rows(i).Cells("currency_id").ReadOnly = True
                            Me.DgvTrnAdvanceDetil.Rows(i).Cells("select_additem").ReadOnly = True
                            Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_approveddescr").ReadOnly = True
                            Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_approveddescr").Style.BackColor = lockColor

                        Else
                            Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_foreignreal").ReadOnly = True
                            Me.DgvTrnAdvanceDetil.Rows(i).Cells("currency_id").ReadOnly = True
                            Me.DgvTrnAdvanceDetil.Rows(i).Cells("select_additem").ReadOnly = False

                        End If

                        Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_descr").ReadOnly = False

                    ElseIf clsUtil.IsDbNull(Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_ordered").Value, 0) = 0 And clsUtil.IsDbNull(Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_approvedbma").Value, 0) = 1 Then
                        Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_foreignreal").ReadOnly = True
                        Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_descr").ReadOnly = True
                        Me.DgvTrnAdvanceDetil.Rows(i).Cells("currency_id").ReadOnly = True
                        Me.DgvTrnAdvanceDetil.Rows(i).Cells("select_additem").ReadOnly = True

                    ElseIf clsUtil.IsDbNull(Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_ordered").Value, 0) = 1 And clsUtil.IsDbNull(Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_approvedbma").Value, 0) = 1 Then
                        Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_foreignreal").ReadOnly = True
                        Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_descr").ReadOnly = True
                        Me.DgvTrnAdvanceDetil.Rows(i).Cells("currency_id").ReadOnly = True
                        Me.DgvTrnAdvanceDetil.Rows(i).Cells("select_additem").ReadOnly = True

                    End If
                Next
            End If

            Me.DgvTrnAdvanceDetil.Columns("advancedetil_idrreal").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_idrreal").DefaultCellStyle.BackColor = lockColor
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_subtotal").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_subtotal").DefaultCellStyle.BackColor = lockColor
            Me.DgvItemBudgetDetil.Columns("outstanding_budget").ReadOnly = True
            Me.DgvItemBudgetDetil.Columns("outstanding_budget").DefaultCellStyle.BackColor = lockColor

            Me.DgvTrnAdvanceDetil.AllowUserToAddRows = False
            Me.DgvTrnAdvanceDetil.AllowUserToDeleteRows = False
            Me.DgvItemBudgetDetil.AllowUserToAddRows = False
            Me.DgvItemBudgetDetil.AllowUserToDeleteRows = False

            '''''sudah ada Request nya
            'baru
            ''''ElseIf clsUtil.IsDbNull(Me.tbl_TrnAdvance_Temp.Rows(0).Item("isrequest"), 0) <> 0 Then
            ''''    For col = 0 To Me.DgvTrnAdvanceDetil.Columns.Count - 1
            ''''        Me.DgvTrnAdvanceDetil.Columns(col).ReadOnly = True
            ''''        Me.DgvTrnAdvanceDetil.Columns(col).DefaultCellStyle.BackColor = lockColor
            ''''    Next

            ''''    Me.DgvItemBudgetDetil.Columns("advance_id").Visible = False

            ''''    If Me._USERSTRUKTURUNIT = Department.BMA Then
            ''''        For i = 0 To Me.DgvTrnAdvanceDetil.Rows.Count - 1
            ''''            If clsUtil.IsDbNull(Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_ordered").Value, 0) = 0 And clsUtil.IsDbNull(Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_approvedbma").Value, 0) = 0 Then
            ''''                If Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_type").Value = 0 Then
            ''''                    Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_foreignreal").ReadOnly = True
            ''''                    Me.DgvTrnAdvanceDetil.Rows(i).Cells("currency_id").ReadOnly = True

            ''''                Else
            ''''                    Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_foreignreal").ReadOnly = True
            ''''                    Me.DgvTrnAdvanceDetil.Rows(i).Cells("currency_id").ReadOnly = True
            ''''                    Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_approvedbma").ReadOnly = False
            ''''                    Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_approveddescr").ReadOnly = False

            ''''                End If
            ''''            ElseIf clsUtil.IsDbNull(Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_ordered").Value, 0) = 0 And clsUtil.IsDbNull(Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_approvedbma").Value, 0) = 1 Then
            ''''                If Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_type").Value = 0 Then
            ''''                    Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_foreignreal").ReadOnly = True
            ''''                    Me.DgvTrnAdvanceDetil.Rows(i).Cells("currency_id").ReadOnly = True

            ''''                Else
            ''''                    Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_foreignreal").ReadOnly = True
            ''''                    Me.DgvTrnAdvanceDetil.Rows(i).Cells("currency_id").ReadOnly = True
            ''''                    Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_approvedbma").ReadOnly = False
            ''''                    Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_approveddescr").ReadOnly = False

            ''''                End If
            ''''            ElseIf clsUtil.IsDbNull(Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_ordered").Value, 0) = 1 And clsUtil.IsDbNull(Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_approvedbma").Value, 0) = 1 Then
            ''''                Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_foreignreal").ReadOnly = True
            ''''                Me.DgvTrnAdvanceDetil.Rows(i).Cells("currency_id").ReadOnly = True
            ''''                Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_approvedbma").ReadOnly = True
            ''''                Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_approveddescr").ReadOnly = True

            ''''            End If
            ''''        Next
            ''''    ElseIf Me._USERSTRUKTURUNIT <> Department.BMA Then
            ''''        For i = 0 To Me.DgvTrnAdvanceDetil.Rows.Count - 1
            ''''            If clsUtil.IsDbNull(Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_ordered").Value, 0) = 0 And clsUtil.IsDbNull(Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_approvedbma").Value, 0) = 0 Then
            ''''                If Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_type").Value = 0 Then
            ''''                    Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_foreignreal").ReadOnly = True
            ''''                    Me.DgvTrnAdvanceDetil.Rows(i).Cells("currency_id").ReadOnly = True

            ''''                Else
            ''''                    Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_foreignreal").ReadOnly = True
            ''''                    Me.DgvTrnAdvanceDetil.Rows(i).Cells("currency_id").ReadOnly = True

            ''''                End If

            ''''                Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_descr").ReadOnly = False

            ''''            ElseIf clsUtil.IsDbNull(Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_ordered").Value, 0) = 0 And clsUtil.IsDbNull(Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_approvedbma").Value, 0) = 1 Then
            ''''                Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_foreignreal").ReadOnly = True
            ''''                Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_descr").ReadOnly = True
            ''''                Me.DgvTrnAdvanceDetil.Rows(i).Cells("currency_id").ReadOnly = True

            ''''            ElseIf clsUtil.IsDbNull(Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_ordered").Value, 0) = 1 And clsUtil.IsDbNull(Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_approvedbma").Value, 0) = 1 Then
            ''''                Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_foreignreal").ReadOnly = True
            ''''                Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_descr").ReadOnly = True
            ''''                Me.DgvTrnAdvanceDetil.Rows(i).Cells("currency_id").ReadOnly = True

            ''''            End If
            ''''        Next
            ''''    End If

            ''''    Me.DgvTrnAdvanceDetil.Columns("advancedetil_idrreal").ReadOnly = True
            ''''    Me.DgvTrnAdvanceDetil.Columns("advancedetil_idrreal").DefaultCellStyle.BackColor = lockColor
            ''''    Me.DgvItemBudgetDetil.Columns("outstanding_budget").ReadOnly = True
            ''''    Me.DgvItemBudgetDetil.Columns("outstanding_budget").DefaultCellStyle.BackColor = lockColor

            ''''    Me.DgvTrnAdvanceDetil.AllowUserToAddRows = False
            ''''    Me.DgvTrnAdvanceDetil.AllowUserToDeleteRows = False
            ''''    Me.DgvItemBudgetDetil.AllowUserToAddRows = False
            ''''    Me.DgvItemBudgetDetil.AllowUserToDeleteRows = False

            ''''''    '2. 2nd Lock
        ElseIf Me._USERSTRUKTURUNIT = Me.tbl_TrnAdvance_Temp.Rows(0).Item("strukturunit_id") And Me.tbl_TrnAdvance_Temp.Rows(0).Item("advance_approved1") = 0 And Me.tbl_TrnAdvance_Temp.Rows(0).Item("advance_canceled") = 0 Then
            'departmen asal dan belum di approve oleh kadept

            For col = 0 To Me.DgvTrnAdvanceDetil.Columns.Count - 1
                Me.DgvTrnAdvanceDetil.Columns(col).ReadOnly = False
                Me.DgvTrnAdvanceDetil.Columns(col).DefaultCellStyle.BackColor = activeColor
            Next

            Me.DgvTrnAdvanceDetil.Columns("bma_approved").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("bma_approved").DefaultCellStyle.BackColor = lockColor
            Me.DgvTrnAdvanceDetil.Columns("bma_approveddt").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("bma_approveddt").DefaultCellStyle.BackColor = lockColor
            Me.DgvTrnAdvanceDetil.Columns("bma_approvedby").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("bma_approvedby").DefaultCellStyle.BackColor = lockColor
            Me.DgvTrnAdvanceDetil.Columns("bma_memo").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("bma_memo").DefaultCellStyle.BackColor = lockColor

            Me.DgvTrnAdvanceDetil.Columns("advancedetil_canceled").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_canceled").DefaultCellStyle.BackColor = lockColor
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_canceleddt").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_canceleddt").DefaultCellStyle.BackColor = lockColor
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_canceledby").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_canceledby").DefaultCellStyle.BackColor = lockColor

            Me.DgvTrnAdvanceDetil.Columns("advancedetil_type").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_type").DefaultCellStyle.BackColor = lockColor
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_line").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_line").DefaultCellStyle.BackColor = lockColor
            Me.DgvTrnAdvanceDetil.Columns("status_over").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("status_over").DefaultCellStyle.BackColor = lockColor

            Me.DgvTrnAdvanceDetil.Columns("currency_id").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("currency_id").DefaultCellStyle.BackColor = lockColor
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_idrreal").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_idrreal").DefaultCellStyle.BackColor = lockColor
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_subtotal").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_subtotal").DefaultCellStyle.BackColor = lockColor
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_foreignreal").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_foreignreal").DefaultCellStyle.BackColor = lockColor
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_foreignrate").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_foreignrate").DefaultCellStyle.BackColor = lockColor

            Me.DgvTrnAdvanceDetil.Columns("advancedetil_approvedbma").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_approvedbma").DefaultCellStyle.BackColor = lockColor
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_approvedbmadt").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_approvedbmadt").DefaultCellStyle.BackColor = lockColor
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_approvedbmaby").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_approvedbmaby").DefaultCellStyle.BackColor = lockColor
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_approveddescr").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_approveddescr").DefaultCellStyle.BackColor = lockColor

            Me.DgvItemBudgetDetil.Columns("outstanding_budget").ReadOnly = True
            Me.DgvItemBudgetDetil.Columns("outstanding_budget").DefaultCellStyle.BackColor = lockColor
            Me.DgvItemBudgetDetil.Columns("amount_advance").ReadOnly = True
            Me.DgvItemBudgetDetil.Columns("amount_advance").DefaultCellStyle.BackColor = lockColor
            Me.DgvItemBudgetDetil.Columns("budgetdetil_eps").ReadOnly = True
            Me.DgvItemBudgetDetil.Columns("budgetdetil_eps").DefaultCellStyle.BackColor = lockColor
            Me.DgvItemBudgetDetil.Columns("advance_id").Visible = False


            Dim q As Integer

            For q = 0 To Me.DgvTrnAdvanceDetil.Rows.Count - 1
                If Me.DgvTrnAdvanceDetil.Rows(q).Cells("advancedetil_type").Value = 0 Then
                    Me.DgvTrnAdvanceDetil.Rows(q).Cells("select_additem").ReadOnly = True

                Else
                    Me.DgvTrnAdvanceDetil.Rows(q).Cells("select_additem").ReadOnly = False
                End If
            Next

            Me.DgvTrnAdvanceDetil.AllowUserToDeleteRows = True
            Me.DgvTrnAdvanceDetil.AllowUserToAddRows = False
            Me.DgvItemBudgetDetil.AllowUserToAddRows = False
            Me.DgvItemBudgetDetil.AllowUserToDeleteRows = False
            ''''''    '3. 3th Lock
        ElseIf Me._USERSTRUKTURUNIT = Me.tbl_TrnAdvance_Temp.Rows(0).Item("strukturunit_id") And (Me.tbl_TrnAdvance_Temp.Rows(0).Item("advance_approved1") = 2 Or Me.tbl_TrnAdvance_Temp.Rows(0).Item("advance_approved1") = 3) And Me.tbl_TrnAdvance_Temp.Rows(0).Item("advance_canceled") = 0 Then
            'departmen asal dan telah di disapprove oleh kadept dan revised

            For col = 0 To Me.DgvTrnAdvanceDetil.Columns.Count - 1
                Me.DgvTrnAdvanceDetil.Columns(col).ReadOnly = False
                Me.DgvTrnAdvanceDetil.Columns(col).DefaultCellStyle.BackColor = activeColor
            Next

            Me.DgvTrnAdvanceDetil.Columns("bma_approved").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("bma_approved").DefaultCellStyle.BackColor = lockColor
            Me.DgvTrnAdvanceDetil.Columns("bma_approveddt").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("bma_approveddt").DefaultCellStyle.BackColor = lockColor
            Me.DgvTrnAdvanceDetil.Columns("bma_approvedby").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("bma_approvedby").DefaultCellStyle.BackColor = lockColor
            Me.DgvTrnAdvanceDetil.Columns("bma_memo").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("bma_memo").DefaultCellStyle.BackColor = lockColor

            Me.DgvTrnAdvanceDetil.Columns("advancedetil_canceled").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_canceled").DefaultCellStyle.BackColor = lockColor
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_canceleddt").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_canceleddt").DefaultCellStyle.BackColor = lockColor
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_canceledby").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_canceledby").DefaultCellStyle.BackColor = lockColor

            Me.DgvTrnAdvanceDetil.Columns("advancedetil_type").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_type").DefaultCellStyle.BackColor = lockColor
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_line").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_line").DefaultCellStyle.BackColor = lockColor
            Me.DgvTrnAdvanceDetil.Columns("status_over").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("status_over").DefaultCellStyle.BackColor = lockColor

            Me.DgvTrnAdvanceDetil.Columns("currency_id").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("currency_id").DefaultCellStyle.BackColor = lockColor
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_foreignrate").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_foreignrate").DefaultCellStyle.BackColor = lockColor
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_idrreal").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_idrreal").DefaultCellStyle.BackColor = lockColor
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_subtotal").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_subtotal").DefaultCellStyle.BackColor = lockColor
            ''''Me.DgvTrnAdvanceDetil.Columns("outstanding_budget").ReadOnly = True
            ''''Me.DgvTrnAdvanceDetil.Columns("outstanding_budget").DefaultCellStyle.BackColor = lockColor
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_foreignreal").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_foreignreal").DefaultCellStyle.BackColor = lockColor

            Me.DgvTrnAdvanceDetil.Columns("advancedetil_approvedbma").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_approvedbma").DefaultCellStyle.BackColor = lockColor
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_approvedbmadt").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_approvedbmadt").DefaultCellStyle.BackColor = lockColor
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_approvedbmaby").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_approvedbmaby").DefaultCellStyle.BackColor = lockColor

            Me.DgvItemBudgetDetil.Columns("outstanding_budget").ReadOnly = True
            Me.DgvItemBudgetDetil.Columns("outstanding_budget").DefaultCellStyle.BackColor = lockColor
            Me.DgvItemBudgetDetil.Columns("advance_id").Visible = False

            Dim q As Integer

            For q = 0 To Me.DgvTrnAdvanceDetil.Rows.Count - 1
                If Me.DgvTrnAdvanceDetil.Rows(q).Cells("advancedetil_type").Value = 0 Then
                    Me.DgvTrnAdvanceDetil.Rows(q).Cells("select_additem").ReadOnly = True
                Else
                    Me.DgvTrnAdvanceDetil.Rows(q).Cells("select_additem").ReadOnly = False
                End If
            Next

            Me.DgvTrnAdvanceDetil.AllowUserToAddRows = False
            Me.DgvTrnAdvanceDetil.AllowUserToDeleteRows = True
            Me.DgvItemBudgetDetil.AllowUserToAddRows = False
            Me.DgvItemBudgetDetil.AllowUserToDeleteRows = False

            ''''''    '4. 4th Lock
        ElseIf Me._USERSTRUKTURUNIT = Me.tbl_TrnAdvance_Temp.Rows(0).Item("strukturunit_id") And (Me.tbl_TrnAdvance_Temp.Rows(0).Item("advance_approved1") = 1 Or Me.tbl_TrnAdvance_Temp.Rows(0).Item("advance_approved2") = 1) And Me.tbl_TrnAdvance_Temp.Rows(0).Item("advance_canceled") = 0 Then
            'department asal dan sudah di approved

            For col = 0 To Me.DgvTrnAdvanceDetil.Columns.Count - 1
                Me.DgvTrnAdvanceDetil.Columns(col).ReadOnly = False
                Me.DgvTrnAdvanceDetil.Columns(col).DefaultCellStyle.BackColor = activeColor
            Next

            Me.DgvTrnAdvanceDetil.Columns("advancedetil_type").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_type").DefaultCellStyle.BackColor = lockColor
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_line").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_line").DefaultCellStyle.BackColor = lockColor

            Me.DgvTrnAdvanceDetil.Columns("bma_approved").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("bma_approved").DefaultCellStyle.BackColor = lockColor
            Me.DgvTrnAdvanceDetil.Columns("bma_approveddt").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("bma_approveddt").DefaultCellStyle.BackColor = lockColor
            Me.DgvTrnAdvanceDetil.Columns("bma_approvedby").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("bma_approvedby").DefaultCellStyle.BackColor = lockColor
            Me.DgvTrnAdvanceDetil.Columns("bma_memo").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("bma_memo").DefaultCellStyle.BackColor = lockColor

            Me.DgvTrnAdvanceDetil.Columns("advancedetil_canceled").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_canceled").DefaultCellStyle.BackColor = lockColor
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_canceleddt").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_canceleddt").DefaultCellStyle.BackColor = lockColor
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_canceledby").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_canceledby").DefaultCellStyle.BackColor = lockColor

            Me.DgvTrnAdvanceDetil.Columns("advancedetil_approvedbmadt").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_approvedbmadt").DefaultCellStyle.BackColor = lockColor
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_approvedbmaby").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_approvedbmaby").DefaultCellStyle.BackColor = lockColor

            Me.DgvTrnAdvanceDetil.Columns("advancedetil_paymentdt").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_paymentdt").DefaultCellStyle.BackColor = lockColor
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_paymenttype").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_paymenttype").DefaultCellStyle.BackColor = lockColor

            ''''Me.DgvTrnAdvanceDetil.Columns("advancedetil_approveddescr").ReadOnly = True
            ''''Me.DgvTrnAdvanceDetil.Columns("advancedetil_approveddescr").DefaultCellStyle.BackColor = lockColor

            Dim z As Integer

            For z = 0 To Me.DgvTrnAdvanceDetil.Rows.Count - 1
                If Me._USERSTRUKTURUNIT = Department.BMA Or Me._MODUL_TYPE = "bma" Then
                    If Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_approvedbma").Value = 1 Then
                        If Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_ordered").Value = 1 Then
                            If Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_type").Value = 0 Then
                                Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_descr").ReadOnly = True
                                Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_descr").Style.BackColor = lockColor
                                Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_approvedbma").ReadOnly = True
                                Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_approvedbma").Style.BackColor = lockColor
                                Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_approveddescr").ReadOnly = True
                                Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_approveddescr").Style.BackColor = lockColor

                                Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_paymentdt").ReadOnly = True
                                Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_paymentdt").Style.BackColor = lockColor
                                Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_paymenttype").ReadOnly = True
                                Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_paymenttype").Style.BackColor = lockColor

                                Me.DgvTrnAdvanceDetil.Rows(i).Cells("select_additem").ReadOnly = True
                                ''''Me.DgvTrnAdvanceDetil.Rows(i).Cells("select_additem").Style.BackColor = lockColor
                            Else
                                Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_descr").ReadOnly = True
                                Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_descr").Style.BackColor = lockColor
                                Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_approvedbma").ReadOnly = True
                                Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_approvedbma").Style.BackColor = lockColor
                                Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_approveddescr").ReadOnly = True
                                Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_approveddescr").Style.BackColor = lockColor

                                Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_paymentdt").ReadOnly = True
                                Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_paymentdt").Style.BackColor = lockColor
                                Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_paymenttype").ReadOnly = True
                                Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_paymenttype").Style.BackColor = lockColor

                                ''''Me.DgvTrnAdvanceDetil.Rows(i).Cells("select_additem").ReadOnly = True
                                ''''Me.DgvTrnAdvanceDetil.Rows(i).Cells("select_additem").Style.BackColor = lockColor
                            End If

                        Else

                            If Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_type").Value = 0 Then
                                Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_descr").ReadOnly = False
                                Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_descr").Style.BackColor = activeColor
                                Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_approvedbma").ReadOnly = True
                                Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_approvedbma").Style.BackColor = lockColor

                                Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_approveddescr").ReadOnly = True
                                Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_approveddescr").Style.BackColor = lockColor

                                Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_paymentdt").ReadOnly = True
                                Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_paymentdt").Style.BackColor = lockColor
                                Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_paymenttype").ReadOnly = True
                                Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_paymenttype").Style.BackColor = lockColor
                                Me.DgvTrnAdvanceDetil.Rows(i).Cells("select_additem").ReadOnly = True

                            Else
                                Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_descr").ReadOnly = True
                                Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_descr").Style.BackColor = lockColor


                                Dim lockApprove As DataTable = New DataTable

                                lockApprove.Clear()
                                Me.DataFill(dbconn, dbtrans, lockApprove, "vq_TrnAdvanceDetilLock_Select", String.Format("b.advance_id = '{0}' AND b.advancedetil_line = {1}", clsUtil.IsDbNull(Me.DgvTrnAdvanceDetil.Rows(z).Cells("advance_id").Value, ""), Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_line").Value))

                                If lockApprove.Rows.Count > 0 Then
                                    Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_approvedbma").ReadOnly = False
                                    Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_approvedbma").Style.BackColor = activeColor
                                Else
                                    Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_approvedbma").ReadOnly = True
                                    Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_approvedbma").Style.BackColor = lockColor
                                End If

                                'Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_approvedbma").ReadOnly = False
                                'Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_approvedbma").Style.BackColor = activeColor
                                Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_approveddescr").ReadOnly = False
                                Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_approveddescr").Style.BackColor = activeColor

                                Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_paymentdt").ReadOnly = False
                                Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_paymentdt").Style.BackColor = activeColor
                                Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_paymenttype").ReadOnly = False
                                Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_paymenttype").Style.BackColor = activeColor
                                Me.DgvTrnAdvanceDetil.Rows(i).Cells("select_additem").ReadOnly = False
                                ''''Me.DgvTrnAdvanceDetil.Rows(i).Cells("select_additem").Style.BackColor = activeColor

                            End If

                        End If

                    Else

                        If Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_type").Value = 0 Then
                            Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_descr").ReadOnly = False
                            Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_descr").Style.BackColor = activeColor
                            Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_approvedbma").ReadOnly = True
                            Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_approvedbma").Style.BackColor = lockColor

                            Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_approveddescr").ReadOnly = True
                            Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_approveddescr").Style.BackColor = lockColor

                            Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_paymentdt").ReadOnly = True
                            Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_paymentdt").Style.BackColor = lockColor
                            Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_paymenttype").ReadOnly = True
                            Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_paymenttype").Style.BackColor = lockColor

                            Me.DgvTrnAdvanceDetil.Rows(i).Cells("select_additem").ReadOnly = False
                            ''''Me.DgvTrnAdvanceDetil.Rows(i).Cells("select_additem").Style.BackColor = activeColor

                        Else
                            Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_descr").ReadOnly = False
                            Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_descr").Style.BackColor = activeColor

                            Dim lockApprove As DataTable = New DataTable

                            lockApprove.Clear()
                            Me.DataFill(dbconn, dbtrans, lockApprove, "vq_TrnAdvanceDetilLock_Select", String.Format("b.advance_id = '{0}' AND b.advancedetil_line = {1}", clsUtil.IsDbNull(Me.DgvTrnAdvanceDetil.Rows(z).Cells("advance_id").Value, ""), Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_line").Value))

                            If lockApprove.Rows.Count > 0 Then
                                Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_approvedbma").ReadOnly = False
                                Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_approvedbma").Style.BackColor = activeColor
                            Else
                                Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_approvedbma").ReadOnly = True
                                Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_approvedbma").Style.BackColor = lockColor
                            End If


                            Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_approveddescr").ReadOnly = False
                            Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_approveddescr").Style.BackColor = activeColor

                            Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_paymentdt").ReadOnly = False
                            Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_paymentdt").Style.BackColor = activeColor
                            Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_paymenttype").ReadOnly = False
                            Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_paymenttype").Style.BackColor = activeColor

                            Me.DgvTrnAdvanceDetil.Rows(i).Cells("select_additem").ReadOnly = False
                            ''''Me.DgvTrnAdvanceDetil.Rows(i).Cells("select_additem").Style.BackColor = activeColor
                        End If
                    End If

                    'bukan BMA
                Else
                    If Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_approvedbma").Value = 1 Then
                        Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_descr").ReadOnly = True
                        Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_descr").Style.BackColor = lockColor
                        Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_approvedbma").ReadOnly = True
                        Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_approvedbma").Style.BackColor = lockColor
                        Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_approveddescr").ReadOnly = True
                        Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_approveddescr").Style.BackColor = lockColor

                        ''''Me.DgvTrnAdvanceDetil.Rows(i).Cells("select_additem").ReadOnly = True
                        ''''Me.DgvTrnAdvanceDetil.Rows(i).Cells("select_additem").Style.BackColor = lockColor
                    Else
                        If Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_type").Value = 0 Then
                            Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_descr").ReadOnly = False
                            Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_descr").Style.BackColor = activeColor
                            Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_approvedbma").ReadOnly = True
                            Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_approvedbma").Style.BackColor = lockColor
                            Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_approveddescr").ReadOnly = True
                            Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_approveddescr").Style.BackColor = lockColor

                            Me.DgvTrnAdvanceDetil.Rows(i).Cells("select_additem").ReadOnly = True
                            ''''Me.DgvTrnAdvanceDetil.Rows(i).Cells("select_additem").Style.BackColor = lockColor
                        Else
                            Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_descr").ReadOnly = False
                            Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_descr").Style.BackColor = activeColor
                            Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_approvedbma").ReadOnly = True
                            Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_approvedbma").Style.BackColor = lockColor
                            Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_approveddescr").ReadOnly = True
                            Me.DgvTrnAdvanceDetil.Rows(z).Cells("advancedetil_approveddescr").Style.BackColor = lockColor

                            ''''Me.DgvTrnAdvanceDetil.Rows(i).Cells("select_additem").ReadOnly = True
                            ''''Me.DgvTrnAdvanceDetil.Rows(i).Cells("select_additem").Style.BackColor = lockColor
                        End If

                    End If
                End If

            Next


            ''''Me.DgvTrnAdvanceDetil.Columns("advancedetil_descr").ReadOnly = True
            ''''Me.DgvTrnAdvanceDetil.Columns("advancedetil_descr").DefaultCellStyle.BackColor = lockColor

            Me.DgvTrnAdvanceDetil.Columns("status_over").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("status_over").DefaultCellStyle.BackColor = lockColor

            'description
            obj_budget_id_view.Enabled = False
            obj_budget_id_code.Enabled = False
            Me.tbtnSave.Enabled = True


            Me.DgvItemBudgetDetil.Columns("amount_advance").ReadOnly = True
            Me.DgvItemBudgetDetil.Columns("amount_advance").DefaultCellStyle.BackColor = lockColor
            Me.DgvItemBudgetDetil.Columns("budgetdetil_eps").ReadOnly = True
            Me.DgvItemBudgetDetil.Columns("budgetdetil_eps").DefaultCellStyle.BackColor = lockColor

            Me.DgvTrnAdvanceDetil.Columns("currency_id").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("currency_id").DefaultCellStyle.BackColor = lockColor
            ''''Me.DgvTrnAdvanceDetil.Columns("advancedetil_descr").ReadOnly = True
            ''''Me.DgvTrnAdvanceDetil.Columns("advancedetil_descr").DefaultCellStyle.BackColor = lockColor
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_foreignreal").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_foreignreal").DefaultCellStyle.BackColor = lockColor
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_foreignrate").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_foreignrate").DefaultCellStyle.BackColor = lockColor
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_idrreal").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_idrreal").DefaultCellStyle.BackColor = lockColor
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_subtotal").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_subtotal").DefaultCellStyle.BackColor = lockColor

            Me.DgvItemBudgetDetil.Columns("advance_id").Visible = False

            Me.DgvTrnAdvanceDetil.AllowUserToAddRows = False
            Me.DgvTrnAdvanceDetil.AllowUserToDeleteRows = True
            Me.DgvItemBudgetDetil.AllowUserToAddRows = False
            Me.DgvItemBudgetDetil.AllowUserToDeleteRows = False

            ''''''    '5. 5nd Lock
        ElseIf (Me._MODUL_TYPE = "bma" Or Me._USERSTRUKTURUNIT = Department.BMA) And Me.tbl_TrnAdvance_Temp.Rows(0).Item("advance_canceled") = 0 Then
            'department bma

            For col = 0 To Me.DgvTrnAdvanceDetil.Columns.Count - 1
                Me.DgvTrnAdvanceDetil.Columns(col).ReadOnly = True
                Me.DgvTrnAdvanceDetil.Columns(col).DefaultCellStyle.BackColor = lockColor
            Next

            Me.DgvItemBudgetDetil.Columns("advance_id").Visible = False

            Me.DgvTrnAdvanceDetil.Columns("bma_approved").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("bma_approved").DefaultCellStyle.BackColor = lockColor
            Me.DgvTrnAdvanceDetil.Columns("bma_approveddt").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("bma_approveddt").DefaultCellStyle.BackColor = lockColor
            Me.DgvTrnAdvanceDetil.Columns("bma_approvedby").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("bma_approvedby").DefaultCellStyle.BackColor = lockColor
            Me.DgvTrnAdvanceDetil.Columns("bma_memo").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("bma_memo").DefaultCellStyle.BackColor = lockColor

            Me.DgvTrnAdvanceDetil.Columns("advancedetil_canceled").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_canceled").DefaultCellStyle.BackColor = lockColor
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_canceleddt").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_canceleddt").DefaultCellStyle.BackColor = lockColor
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_canceledby").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_canceledby").DefaultCellStyle.BackColor = lockColor

            Dim d As Integer

            For d = 0 To Me.DgvTrnAdvanceDetil.Rows.Count - 1
                If clsUtil.IsDbNull(Me.DgvTrnAdvanceDetil.Rows(d).Cells("advancedetil_ordered").Value, False) = 0 Then
                    ''''Me.DgvTrnAdvanceDetil.Rows(d).Cells("advancedetil_approvedbma").ReadOnly = False
                    ''''Me.DgvTrnAdvanceDetil.Rows(d).Cells("advancedetil_approveddescr").ReadOnly = False
                    If clsUtil.IsDbNull(Me.DgvTrnAdvanceDetil.Rows(d).Cells("advancedetil_approvedbma").Value, False) = 0 Then
                        If Me.isNew = True Then


                            If Me.DgvTrnAdvanceDetil.Rows(d).Cells("advancedetil_type").Value = 0 Then
                                Me.DgvTrnAdvanceDetil.Rows(d).Cells("advancedetil_approvedbma").ReadOnly = True
                                Me.DgvTrnAdvanceDetil.Rows(d).Cells("advancedetil_approveddescr").ReadOnly = True
                                Me.DgvTrnAdvanceDetil.Rows(d).Cells("advancedetil_descr").ReadOnly = True
                                Me.DgvTrnAdvanceDetil.Rows(d).Cells("advancedetil_paymentdt").ReadOnly = True
                                Me.DgvTrnAdvanceDetil.Rows(d).Cells("advancedetil_paymenttype").ReadOnly = True
                                Me.DgvTrnAdvanceDetil.Rows(d).Cells("select_additem").ReadOnly = True

                            Else
                                Me.DgvTrnAdvanceDetil.Rows(d).Cells("advancedetil_approvedbma").ReadOnly = True
                                Me.DgvTrnAdvanceDetil.Rows(d).Cells("advancedetil_approveddescr").ReadOnly = True
                                Me.DgvTrnAdvanceDetil.Rows(d).Cells("advancedetil_descr").ReadOnly = False
                                Me.DgvTrnAdvanceDetil.Rows(d).Cells("advancedetil_paymentdt").ReadOnly = False
                                Me.DgvTrnAdvanceDetil.Rows(d).Cells("advancedetil_paymenttype").ReadOnly = False
                                Me.DgvTrnAdvanceDetil.Rows(d).Cells("select_additem").ReadOnly = False

                            End If

                            ''''Me.DgvTrnAdvanceDetil.Rows(i).Cells("select_additem").ReadOnly = False

                        Else

                            Dim lockApprove As DataTable = New DataTable

                            If Me.DgvTrnAdvanceDetil.Rows(d).Cells("advancedetil_type").Value = 0 Then

                                Me.DgvTrnAdvanceDetil.Rows(d).Cells("advancedetil_approvedbma").ReadOnly = True
                                Me.DgvTrnAdvanceDetil.Rows(d).Cells("advancedetil_approvedbma").Style.BackColor = Color.Gainsboro

                                Me.DgvTrnAdvanceDetil.Rows(d).Cells("advancedetil_approveddescr").ReadOnly = True
                                Me.DgvTrnAdvanceDetil.Rows(d).Cells("advancedetil_descr").ReadOnly = True

                                Me.DgvTrnAdvanceDetil.Rows(d).Cells("advancedetil_paymentdt").ReadOnly = True
                                Me.DgvTrnAdvanceDetil.Rows(d).Cells("advancedetil_paymenttype").ReadOnly = True
                                Me.DgvTrnAdvanceDetil.Rows(d).Cells("select_additem").ReadOnly = True

                            Else

                                lockApprove.Clear()
                                Me.DataFill(dbconn, dbtrans, lockApprove, "vq_TrnAdvanceDetilLock_Select", String.Format("b.advance_id = '{0}' AND b.advancedetil_line = {1}", clsUtil.IsDbNull(Me.DgvTrnAdvanceDetil.Rows(d).Cells("advance_id").Value, ""), Me.DgvTrnAdvanceDetil.Rows(d).Cells("advancedetil_line").Value))

                                If lockApprove.Rows.Count > 0 Then
                                    Me.DgvTrnAdvanceDetil.Rows(d).Cells("advancedetil_approvedbma").ReadOnly = False
                                    Me.DgvTrnAdvanceDetil.Rows(d).Cells("advancedetil_approvedbma").Style.BackColor = Color.White
                                Else
                                    Me.DgvTrnAdvanceDetil.Rows(d).Cells("advancedetil_approvedbma").ReadOnly = True
                                    Me.DgvTrnAdvanceDetil.Rows(d).Cells("advancedetil_approvedbma").Style.BackColor = Color.Gainsboro
                                End If

                                Me.DgvTrnAdvanceDetil.Rows(d).Cells("advancedetil_approveddescr").ReadOnly = False
                                Me.DgvTrnAdvanceDetil.Rows(d).Cells("advancedetil_descr").ReadOnly = False

                                Me.DgvTrnAdvanceDetil.Rows(d).Cells("advancedetil_paymentdt").ReadOnly = False
                                Me.DgvTrnAdvanceDetil.Rows(d).Cells("advancedetil_paymenttype").ReadOnly = False
                                Me.DgvTrnAdvanceDetil.Rows(d).Cells("select_additem").ReadOnly = False
                            End If
                        End If

                    Else

                        Dim lockApprove As DataTable = New DataTable

                        If Me.DgvTrnAdvanceDetil.Rows(d).Cells("advancedetil_type").Value = 0 Then

                            Me.DgvTrnAdvanceDetil.Rows(d).Cells("advancedetil_approvedbma").ReadOnly = True
                            Me.DgvTrnAdvanceDetil.Rows(d).Cells("advancedetil_approvedbma").Style.BackColor = Color.Gainsboro

                            Me.DgvTrnAdvanceDetil.Rows(d).Cells("advancedetil_approveddescr").ReadOnly = True
                            Me.DgvTrnAdvanceDetil.Rows(d).Cells("advancedetil_descr").ReadOnly = True

                            Me.DgvTrnAdvanceDetil.Rows(d).Cells("advancedetil_paymentdt").ReadOnly = True
                            Me.DgvTrnAdvanceDetil.Rows(d).Cells("advancedetil_paymenttype").ReadOnly = True
                            Me.DgvTrnAdvanceDetil.Rows(i).Cells("select_additem").ReadOnly = True

                        Else
                            lockApprove.Clear()
                            Me.DataFill(dbconn, dbtrans, lockApprove, "vq_TrnAdvanceDetilLock_Select", String.Format("b.advance_id = '{0}' AND b.advancedetil_line = {1}", clsUtil.IsDbNull(Me.DgvTrnAdvanceDetil.Rows(d).Cells("advance_id").Value, ""), Me.DgvTrnAdvanceDetil.Rows(d).Cells("advancedetil_line").Value))

                            If lockApprove.Rows.Count > 0 Then
                                Me.DgvTrnAdvanceDetil.Rows(d).Cells("advancedetil_approvedbma").ReadOnly = False
                                Me.DgvTrnAdvanceDetil.Rows(d).Cells("advancedetil_approvedbma").Style.BackColor = Color.White
                            Else
                                Me.DgvTrnAdvanceDetil.Rows(d).Cells("advancedetil_approvedbma").ReadOnly = True
                                Me.DgvTrnAdvanceDetil.Rows(d).Cells("advancedetil_approvedbma").Style.BackColor = Color.Gainsboro
                            End If


                            Me.DgvTrnAdvanceDetil.Rows(d).Cells("advancedetil_approveddescr").ReadOnly = False
                            Me.DgvTrnAdvanceDetil.Rows(d).Cells("advancedetil_descr").ReadOnly = True

                            Me.DgvTrnAdvanceDetil.Rows(d).Cells("advancedetil_paymentdt").ReadOnly = True
                            Me.DgvTrnAdvanceDetil.Rows(d).Cells("advancedetil_paymenttype").ReadOnly = True
                            Me.DgvTrnAdvanceDetil.Rows(i).Cells("select_additem").ReadOnly = True

                        End If
                    End If

                Else
                    Me.DgvTrnAdvanceDetil.Rows(d).Cells("advancedetil_approvedbma").ReadOnly = True
                    Me.DgvTrnAdvanceDetil.Rows(d).Cells("advancedetil_approveddescr").ReadOnly = True
                    Me.DgvTrnAdvanceDetil.Rows(d).Cells("advancedetil_paymentdt").ReadOnly = True
                    Me.DgvTrnAdvanceDetil.Rows(d).Cells("advancedetil_paymenttype").ReadOnly = True
                    Me.DgvTrnAdvanceDetil.Rows(i).Cells("select_additem").ReadOnly = True

                End If
            Next

            Me.DgvTrnAdvanceDetil.AllowUserToAddRows = False
            Me.DgvTrnAdvanceDetil.AllowUserToDeleteRows = False
            Me.DgvItemBudgetDetil.AllowUserToAddRows = False
            Me.DgvItemBudgetDetil.AllowUserToDeleteRows = False

            ''''''    '6. 6nd Lock
        Else
            'department lainnya
            Dim odatafiller As New clsDataFiller(Me.DSN)

            For col = 0 To Me.DgvTrnAdvanceDetil.Columns.Count - 1
                Me.DgvTrnAdvanceDetil.Columns(col).ReadOnly = True
                Me.DgvTrnAdvanceDetil.Columns(col).DefaultCellStyle.BackColor = lockColor
            Next

            Me.DgvTrnAdvanceDetil.Columns("bma_approved").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("bma_approved").DefaultCellStyle.BackColor = lockColor
            Me.DgvTrnAdvanceDetil.Columns("bma_approveddt").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("bma_approveddt").DefaultCellStyle.BackColor = lockColor
            Me.DgvTrnAdvanceDetil.Columns("bma_approvedby").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("bma_approvedby").DefaultCellStyle.BackColor = lockColor
            Me.DgvTrnAdvanceDetil.Columns("bma_memo").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("bma_memo").DefaultCellStyle.BackColor = lockColor

            Me.DgvTrnAdvanceDetil.Columns("advancedetil_canceled").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_canceled").DefaultCellStyle.BackColor = lockColor
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_canceleddt").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_canceleddt").DefaultCellStyle.BackColor = lockColor
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_canceledby").ReadOnly = True
            Me.DgvTrnAdvanceDetil.Columns("advancedetil_canceledby").DefaultCellStyle.BackColor = lockColor

            Me.DgvItemBudgetDetil.Columns("advance_id").Visible = False

            Me.DgvTrnAdvanceDetil.AllowUserToAddRows = False
            Me.DgvTrnAdvanceDetil.AllowUserToDeleteRows = False
            Me.DgvItemBudgetDetil.AllowUserToAddRows = False
            Me.DgvItemBudgetDetil.AllowUserToDeleteRows = False
        End If


    End Function

    Private Overloads Function uiTransaksiAdvanceRequest_OpenRowMaster(ByVal advance_id As String, ByVal dbConn As OleDb.OleDbConnection) As Boolean
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter
        Dim tbl_budget As DataTable = clsDataset.CreateTblTrnBudget

        attach_temp = ""

        dbCmd = New OleDb.OleDbCommand("vq_TrnAdvance_Select", dbConn)
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@Criteria").Value = String.Format("advance_id='{0}'", advance_id)
        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)
        Me.tbl_TrnAdvance_Temp.Clear()

        Try
            Me.BindingStop()
            dbDA.Fill(Me.tbl_TrnAdvance_Temp)

            Me.obj_Advance_epsstart.Text = clsUtil.IsDbNull(tbl_TrnAdvance_Temp.Rows(0).Item("advance_epsstart"), 0) 'Me.obj_Request_epsstart.Minimum
            Me.obj_Advance_epsend.Text = clsUtil.IsDbNull(tbl_TrnAdvance_Temp.Rows(0).Item("advance_epsend"), 0) 'Me.obj_Request_epsend.Minimum

            Me.BindingStart()

            Me.obj_Advance_pathfile.Text = clsUtil.IsDbNull(Me.tbl_TrnAdvance_Temp.Rows(0).Item("advance_pathfile"), String.Empty)
            Me.obj_amount.Text = Format(clsUtil.IsDbNull(tbl_TrnAdvance_Temp.Rows(0).Item("amount_itemdetil"), 0), "#,##0.00")

            If Me.obj_Advance_pathfile.Text <> "" Then
                Me.chk_Attachment.Checked = True
            Else
                Me.chk_Attachment.Checked = False
            End If
        Catch ex As Exception
            Throw New Exception(mUiName & ": uiTransaksiAdvanceRequest_OpenRowMaster()" & vbCrLf & ex.Message)
        End Try

        Try
            If Me.tbl_TrnAdvance_Temp.Rows(0).Item("advance_approved1") = 0 Then
                Me.obj_Advance_approvedstatus.Text = "New"
            ElseIf tbl_TrnAdvance_Temp.Rows(0).Item("advance_approved2") = 1 Then
                Me.obj_Advance_approvedstatus.Text = "Approved by Kadiv"
            ElseIf tbl_TrnAdvance_Temp.Rows(0).Item("advance_approved1") = 1 Then
                Me.obj_Advance_approvedstatus.Text = "Approved by User"
            ElseIf tbl_TrnAdvance_Temp.Rows(0).Item("advance_approved1") = 2 Then
                Me.obj_Advance_approvedstatus.Text = "Disapproved by User"
            ElseIf tbl_TrnAdvance_Temp.Rows(0).Item("advance_approved1") = 3 Then
                Me.obj_Advance_approvedstatus.Text = "Revised"
            End If
        Catch ex As Exception
        End Try
        'lock
    End Function

    Private Overloads Function uiTransaksiAdvanceRequest_OpenRowMaster(ByRef dbconn As OleDb.OleDbConnection, ByRef dbtrans As OleDb.OleDbTransaction, ByVal advance_id As String) As Boolean
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter
        Dim tbl_budget As DataTable = clsDataset.CreateTblTrnBudget

        attach_temp = ""

        dbCmd = New OleDb.OleDbCommand("vq_TrnAdvance_Select", dbconn, dbtrans)
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@Criteria").Value = String.Format("advance_id='{0}'", advance_id)
        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)
        Me.tbl_TrnAdvance_Temp.Clear()

        Try
            Me.BindingStop()
            dbDA.Fill(Me.tbl_TrnAdvance_Temp)

            Me.obj_Advance_epsstart.Text = clsUtil.IsDbNull(tbl_TrnAdvance_Temp.Rows(0).Item("advance_epsstart"), 0) 'Me.obj_Request_epsstart.Minimum
            Me.obj_Advance_epsend.Text = clsUtil.IsDbNull(tbl_TrnAdvance_Temp.Rows(0).Item("advance_epsend"), 0) 'Me.obj_Request_epsend.Minimum

            Me.BindingStart()

            Me.obj_Advance_pathfile.Text = clsUtil.IsDbNull(Me.tbl_TrnAdvance_Temp.Rows(0).Item("advance_pathfile"), String.Empty)
            Me.obj_amount.Text = Format(clsUtil.IsDbNull(tbl_TrnAdvance_Temp.Rows(0).Item("amount_itemdetil"), 0), "#,##0.00")

            If Me.obj_Advance_pathfile.Text <> "" Then
                Me.chk_Attachment.Checked = True
            Else
                Me.chk_Attachment.Checked = False
            End If
        Catch ex As Exception
            Throw New Exception(mUiName & ": uiTransaksiAdvanceRequest_OpenRowMaster()" & vbCrLf & ex.Message)
        End Try

        Try
            If Me.tbl_TrnAdvance_Temp.Rows(0).Item("advance_approved1") = 0 Then
                Me.obj_Advance_approvedstatus.Text = "New"
            ElseIf tbl_TrnAdvance_Temp.Rows(0).Item("advance_approved2") = 1 Then
                Me.obj_Advance_approvedstatus.Text = "Approved by Kadiv"
            ElseIf tbl_TrnAdvance_Temp.Rows(0).Item("advance_approved1") = 1 Then
                Me.obj_Advance_approvedstatus.Text = "Approved by User"
            ElseIf tbl_TrnAdvance_Temp.Rows(0).Item("advance_approved1") = 2 Then
                Me.obj_Advance_approvedstatus.Text = "Disapproved by User"
            ElseIf tbl_TrnAdvance_Temp.Rows(0).Item("advance_approved1") = 3 Then
                Me.obj_Advance_approvedstatus.Text = "Revised"
            End If
        Catch ex As Exception
        End Try
        'lock
    End Function

    Private Overloads Function uiTransaksiAdvanceRequest_OpenRowDetil(ByVal advance_id As String, ByVal dbConn As OleDb.OleDbConnection) As Boolean
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        dbCmd = New OleDb.OleDbCommand("vq_TrnAdvancedetil_Select", dbConn)
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@Criteria").Value = String.Format("advance_id = '{0}'", advance_id)
        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)
        Me.tbl_TrnAdvanceDetil.Clear()

        Me.tbl_TrnAdvanceDetil = clsDataset.CreateTblTrnAdvancedetil()
        Me.tbl_TrnAdvanceDetil.Columns("advance_id").DefaultValue = advance_id
        Me.tbl_TrnAdvanceDetil.Columns("advancedetil_line").DefaultValue = DBNull.Value
        Me.tbl_TrnAdvanceDetil.Columns("advancedetil_line").AutoIncrement = True
        Me.tbl_TrnAdvanceDetil.Columns("advancedetil_line").AutoIncrementSeed = 10
        Me.tbl_TrnAdvanceDetil.Columns("advancedetil_line").AutoIncrementStep = 10

        Try
            dbDA.Fill(Me.tbl_TrnAdvanceDetil)
            Me.DgvTrnAdvanceDetil.DataSource = Me.tbl_TrnAdvanceDetil

            '''''Me.uiTransaksiAdvanceRequest_GetBudgetInfo()
        Catch ex As Exception
            Throw New Exception(mUiName & ": uiTransaksiAdvanceRequest_OpenRowDetil()" & vbCrLf & ex.Message)
        End Try
        'lock
    End Function

    Private Overloads Function uiTransaksiAdvanceRequest_OpenRowDetil(ByRef dbconn As OleDb.OleDbConnection, ByRef dbtrans As OleDb.OleDbTransaction, ByVal advance_id As String) As Boolean
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        dbCmd = New OleDb.OleDbCommand("vq_TrnAdvancedetil_Select", dbconn, dbtrans)
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@Criteria").Value = String.Format("advance_id = '{0}'", advance_id)
        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)
        Me.tbl_TrnAdvanceDetil.Clear()

        Me.tbl_TrnAdvanceDetil = clsDataset.CreateTblTrnAdvancedetil()
        Me.tbl_TrnAdvanceDetil.Columns("advance_id").DefaultValue = advance_id
        Me.tbl_TrnAdvanceDetil.Columns("advancedetil_line").DefaultValue = DBNull.Value
        Me.tbl_TrnAdvanceDetil.Columns("advancedetil_line").AutoIncrement = True
        Me.tbl_TrnAdvanceDetil.Columns("advancedetil_line").AutoIncrementSeed = 10
        Me.tbl_TrnAdvanceDetil.Columns("advancedetil_line").AutoIncrementStep = 10

        Try
            dbDA.Fill(Me.tbl_TrnAdvanceDetil)
            Me.DgvTrnAdvanceDetil.DataSource = Me.tbl_TrnAdvanceDetil
        Catch ex As Exception
            Throw New Exception(mUiName & ": uiTransaksiAdvanceRequest_OpenRowDetil()" & vbCrLf & ex.Message)
        End Try
        'lock
    End Function

    Private Overloads Function uiTransaksiAdvanceRequest_OpenRowItemDetil(ByVal advance_id As String, ByVal dbConn As OleDb.OleDbConnection) As Boolean
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        dbCmd = New OleDb.OleDbCommand("vq_TrnAdvanceItemDetil2_Selects", dbConn)
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@Criteria").Value = String.Format("b.advance_id = '{0}'", advance_id)
        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)
        Me.tbl_TrnAdvanceItemDetil.Clear()

        Me.tbl_TrnAdvanceItemDetil = clsDataset.CreateTblTrnAdvanceItemDetilListOrder()
        Me.tbl_TrnAdvanceItemDetil.Columns("advance_id").DefaultValue = advance_id
        Me.tbl_TrnAdvanceItemDetil.Columns("budgetdetil_line").DefaultValue = DBNull.Value
        Me.tbl_TrnAdvanceItemDetil.Columns("budgetdetil_line").AutoIncrement = True
        Me.tbl_TrnAdvanceItemDetil.Columns("budgetdetil_line").AutoIncrementSeed = 10
        Me.tbl_TrnAdvanceItemDetil.Columns("budgetdetil_line").AutoIncrementStep = 10

        Try
            dbDA.Fill(Me.tbl_TrnAdvanceItemDetil)
            Me.DgvItemBudgetDetil.DataSource = Me.tbl_TrnAdvanceItemDetil
            Me.tbl_TrnAdvanceItemDetil.DefaultView.Sort = "advancedetil_line"
            Me.DgvItemBudgetDetil.Columns("advance_id").Visible = False
        Catch ex As Exception
            Throw New Exception(mUiName & ": uiTransaksiAdvanceRequest_OpenRowItemDetil()" & vbCrLf & ex.Message)
        End Try

        'lock
    End Function

    Private Overloads Function uiTransaksiAdvanceRequest_OpenRowItemDetil(ByRef dbconn As OleDb.OleDbConnection, ByRef dbtrans As OleDb.OleDbTransaction, ByVal advance_id As String) As Boolean
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        'dbCmd = New OleDb.OleDbCommand("vq_TrnAdvanceItemDetil_Selects", dbconn, dbtrans)
        dbCmd = New OleDb.OleDbCommand("vq_TrnAdvanceItemDetil2_Selects", dbconn, dbtrans)
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@Criteria").Value = String.Format("b.advance_id = '{0}'", advance_id)
        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)
        Me.tbl_TrnAdvanceItemDetil.Clear()

        Me.tbl_TrnAdvanceItemDetil = clsDataset.CreateTblTrnAdvanceItemDetilListOrder()
        Me.tbl_TrnAdvanceItemDetil.Columns("advance_id").DefaultValue = advance_id
        Me.tbl_TrnAdvanceItemDetil.Columns("budgetdetil_line").DefaultValue = DBNull.Value
        Me.tbl_TrnAdvanceItemDetil.Columns("budgetdetil_line").AutoIncrement = True
        Me.tbl_TrnAdvanceItemDetil.Columns("budgetdetil_line").AutoIncrementSeed = 10
        Me.tbl_TrnAdvanceItemDetil.Columns("budgetdetil_line").AutoIncrementStep = 10

        Try
            dbDA.Fill(Me.tbl_TrnAdvanceItemDetil)
            Me.DgvItemBudgetDetil.DataSource = Me.tbl_TrnAdvanceItemDetil
            Me.tbl_TrnAdvanceItemDetil.DefaultView.Sort = "advancedetil_line"
            Me.DgvItemBudgetDetil.Columns("advance_id").Visible = False
        Catch ex As Exception
            Throw New Exception(mUiName & ": uiTransaksiAdvanceRequest_OpenRowItemDetil()" & vbCrLf & ex.Message)
        End Try

        'lock
    End Function

    Private Overloads Function uiTransaksiAdvanceRequest_OpenRowRefPv(ByVal advance_id As String, ByVal dbConn As OleDb.OleDbConnection) As Boolean
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        dbCmd = New OleDb.OleDbCommand("vq_TrnAdvanceRefPV_Select", dbConn)
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@Criteria").Value = String.Format("b.advancedetil_ordered = 1 AND b.advancedetil_refreference != '' AND a.jurnal_id_ref = '{0}'", advance_id)
        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)
        Me.tbl_TrnAdvanceRefPV.Clear()

        Me.tbl_TrnAdvanceRefPV = clsDataset.CreateTblTrnAdvanceRefPV()

        Try
            dbDA.Fill(Me.tbl_TrnAdvanceRefPV)
            Me.DgvRefPv.DataSource = Me.tbl_TrnAdvanceRefPV
            Me.tbl_TrnAdvanceRefPV.DefaultView.Sort = "jurnal_id_refline"
        Catch ex As Exception
            Throw New Exception(mUiName & ": uiTransaksiAdvanceRequest_OpenRowRefPV()" & vbCrLf & ex.Message)
        End Try

    End Function

    Private Overloads Function uiTransaksiAdvanceRequest_OpenRowRefPv(ByRef dbconn As OleDb.OleDbConnection, ByRef dbtrans As OleDb.OleDbTransaction, ByVal advance_id As String) As Boolean
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        dbCmd = New OleDb.OleDbCommand("vq_TrnAdvanceRefPV_Select", dbconn, dbtrans)
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@Criteria").Value = String.Format("b.advancedetil_ordered = 1 AND b.advancedetil_refreference != '' AND a.jurnal_id_ref = '{0}'", advance_id)
        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)
        Me.tbl_TrnAdvanceRefPV.Clear()

        Me.tbl_TrnAdvanceRefPV = clsDataset.CreateTblTrnAdvanceRefPV()

        Try
            dbDA.Fill(Me.tbl_TrnAdvanceRefPV)
            Me.DgvRefPv.DataSource = Me.tbl_TrnAdvanceRefPV
            Me.tbl_TrnAdvanceRefPV.DefaultView.Sort = "jurnal_id_refline"
        Catch ex As Exception
            Throw New Exception(mUiName & ": uiTransaksiAdvanceRequest_OpenRowRefPV()" & vbCrLf & ex.Message)
        End Try

    End Function

    Private Overloads Function uiTransaksiAdvanceRequest_OpenRowRefOrder(ByVal advance_id As String, ByVal dbConn As OleDb.OleDbConnection) As Boolean
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        'dbCmd = New OleDb.OleDbCommand("vq_TrnOrderadvance_Select", dbConn)
        dbCmd = New OleDb.OleDbCommand("vq_TrnTraveladvanceRef_Select", dbConn)
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@Criteria").Value = String.Format("advance_id = '{0}'", advance_id)
        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)
        Me.tbl_RefOrder.Clear()

        Me.tbl_RefOrder = clsDataset.CreateTblTrnOrderadvance()
        Me.tbl_RefOrder.Columns("advance_id").DefaultValue = 0
        Me.tbl_RefOrder.Columns("budgetdetil_line").DefaultValue = DBNull.Value
        Me.tbl_RefOrder.Columns("budgetdetil_line").AutoIncrement = False
        Me.tbl_RefOrder.Columns("budgetdetil_line").AutoIncrementSeed = 10
        Me.tbl_RefOrder.Columns("budgetdetil_line").AutoIncrementStep = 10

        Try
            dbDA.Fill(Me.tbl_RefOrder)
            Me.DgvRefOrder.DataSource = Me.tbl_RefOrder
            Me.tbl_RefOrder.DefaultView.Sort = "advance_id"
        Catch ex As Exception
            Throw New Exception(mUiName & ": uiTransaksiAdvanceRequest_OpenRowRefOrder()" & vbCrLf & ex.Message)
        End Try

    End Function

    Private Overloads Function uiTransaksiAdvanceRequest_OpenRowRefOrderCanceled(ByVal advance_id As String, ByVal dbConn As OleDb.OleDbConnection) As Boolean
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        dbCmd = New OleDb.OleDbCommand("vq_TrnOrderadvance_Select2", dbConn)
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@Criteria").Value = String.Format("advance_id = '{0}'", advance_id)
        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)
        Me.tbl_RefOrder.Clear()

        Me.tbl_RefOrder = clsDataset.CreateTblTrnOrderadvance()
        Me.tbl_RefOrder.Columns("advance_id").DefaultValue = 0
        Me.tbl_RefOrder.Columns("budgetdetil_line").DefaultValue = DBNull.Value
        Me.tbl_RefOrder.Columns("budgetdetil_line").AutoIncrement = False
        Me.tbl_RefOrder.Columns("budgetdetil_line").AutoIncrementSeed = 10
        Me.tbl_RefOrder.Columns("budgetdetil_line").AutoIncrementStep = 10

        Try
            dbDA.Fill(Me.tbl_RefOrder)
            Me.DgvRefOrder.DataSource = Me.tbl_RefOrder
            Me.tbl_RefOrder.DefaultView.Sort = "advance_id"
        Catch ex As Exception
            Throw New Exception(mUiName & ": uiTransaksiAdvanceRequest_OpenRowRefOrderCanceled()" & vbCrLf & ex.Message)
        End Try

    End Function

    Private Overloads Function uiTransaksiAdvanceRequest_OpenRowRefOrder(ByRef dbconn As OleDb.OleDbConnection, ByRef dbtrans As OleDb.OleDbTransaction, ByVal advance_id As String) As Boolean
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        'dbCmd = New OleDb.OleDbCommand("vq_TrnOrderadvance_Select", dbconn, dbtrans)
        dbCmd = New OleDb.OleDbCommand("vq_TrnTraveladvanceRef_Select", dbconn, dbtrans)
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@Criteria").Value = String.Format("advance_id = '{0}'", advance_id)
        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)
        Me.tbl_RefOrder.Clear()

        Me.tbl_RefOrder = clsDataset.CreateTblTrnOrderadvance()
        Me.tbl_RefOrder.Columns("advance_id").DefaultValue = 0
        Me.tbl_RefOrder.Columns("budgetdetil_line").DefaultValue = DBNull.Value
        Me.tbl_RefOrder.Columns("budgetdetil_line").AutoIncrement = False
        Me.tbl_RefOrder.Columns("budgetdetil_line").AutoIncrementSeed = 10
        Me.tbl_RefOrder.Columns("budgetdetil_line").AutoIncrementStep = 10

        Try
            dbDA.Fill(Me.tbl_RefOrder)
            Me.DgvRefOrder.DataSource = Me.tbl_RefOrder
            Me.tbl_RefOrder.DefaultView.Sort = "advance_id"
        Catch ex As Exception
            Throw New Exception(mUiName & ": uiTransaksiAdvanceRequest_OpenRowRefOrder()" & vbCrLf & ex.Message)
        End Try

    End Function

    Private Overloads Function uiTransaksiAdvanceRequest_OpenRowRefOrderCanceled(ByRef dbconn As OleDb.OleDbConnection, ByRef dbtrans As OleDb.OleDbTransaction, ByVal advance_id As String) As Boolean
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        dbCmd = New OleDb.OleDbCommand("vq_TrnOrderadvance_Select2", dbconn, dbtrans)
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@Criteria").Value = String.Format("advance_id = '{0}'", advance_id)
        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)
        Me.tbl_RefOrder.Clear()

        Me.tbl_RefOrder = clsDataset.CreateTblTrnOrderadvance()
        Me.tbl_RefOrder.Columns("advance_id").DefaultValue = 0
        Me.tbl_RefOrder.Columns("budgetdetil_line").DefaultValue = DBNull.Value
        Me.tbl_RefOrder.Columns("budgetdetil_line").AutoIncrement = False
        Me.tbl_RefOrder.Columns("budgetdetil_line").AutoIncrementSeed = 10
        Me.tbl_RefOrder.Columns("budgetdetil_line").AutoIncrementStep = 10

        Try
            dbDA.Fill(Me.tbl_RefOrder)
            Me.DgvRefOrder.DataSource = Me.tbl_RefOrder
            Me.tbl_RefOrder.DefaultView.Sort = "advance_id"
        Catch ex As Exception
            Throw New Exception(mUiName & ": uiTransaksiAdvanceRequest_OpenRowRefOrder()" & vbCrLf & ex.Message)
        End Try

    End Function

    Private Function uiTransaksiAdvanceRequest_OutstandingBudget() As Boolean
        Dim a, b As Integer
        Dim amount_budget As Decimal
        Dim amount_idrreal As Decimal
        Dim outstanding_budget, rate, budget_accum As Decimal
        Dim budget_id, budgetdetil_id As Decimal
        Dim tbl_advance_bma As New DataTable
        Dim tbl_amount_st As New DataTable
        Dim oDataFiller As New clsDataFiller(Me.DSN)
        Dim jumlah_over As Integer
        Dim amount_approvebma As Decimal
        Dim accum_budget As Decimal
        Dim amount_advance, advancedetil_foreignrate, advancedetil_discount As Decimal
        Dim total_idr As Decimal
        Dim pph_persen, ppn_persen, pph_amount, ppn_amount As Decimal
        Dim amount_subtotal As Decimal
        Dim amount_intercompany As Decimal
        Dim amount_order As Decimal
        Dim tbl_amount_order As New DataTable

        Dim amount_subtotalforeign As Decimal
        Dim total_foreign As Decimal
        Dim pph_amountforeign, ppn_amountforeign As Decimal

        ''''Dim v As Integer
        Dim amount As Decimal
        Dim amount_foreignreal As Decimal


        Me.DgvItemBudgetDetil.EndEdit()

        For a = 0 To Me.DgvTrnAdvanceDetil.Rows.Count - 1
            jumlah_over = 0

            For b = 0 To Me.DgvItemBudgetDetil.Rows.Count - 1
                amount_budget = clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(b).Cells("amount_budget").Value, 0)
                budget_id = clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(b).Cells("budget_id").Value, 0)
                budgetdetil_id = clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(b).Cells("budgetdetil_id").Value, 0)

                rate = clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(b).Cells("advancedetil_foreignrate").Value, 0)
                amount_idrreal = clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(b).Cells("amount_advance").Value, 0) * clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(b).Cells("advancedetil_foreignrate").Value, 0)

                amount_advance = Math.Round(clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(b).Cells("amount_advance").Value, 0), 2, MidpointRounding.AwayFromZero)
                ''''CDec(String.Format("{0:#,##0.00}", (CDec(clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(b).Cells("amount_advance").Value, 0)))))
                ''''Math.Round(clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(b).Cells("amount_advance").Value, 0), 2)
                advancedetil_foreignrate = clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(b).Cells("advancedetil_foreignrate").Value, 0)
                ''''CDec(String.Format("{0:#,##0.00}", (CDec(clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(b).Cells("advancedetil_discount").Value, 0)))))
                ''''Math.Round(clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(b).Cells("advancedetil_discount").Value, 0), 2)
                pph_persen = clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(b).Cells("pph_persen").Value, 0)
                ppn_persen = clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(b).Cells("ppn_persen").Value, 0)
                amount_intercompany = Math.Round(clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(b).Cells("amount_intercompany").Value, 0), 2, MidpointRounding.AwayFromZero)
                ''''CDec(String.Format("{0:#,##0.00}", (CDec(clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(b).Cells("amount_intercompany").Value, 0)))))
                ''''Math.Round(clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(b).Cells("amount_intercompany").Value, 0), 2)

                If Mid(Me.DgvRefOrder.Rows(b).Cells("order_id").Value, 1, 2) = "RO" Then
                    advancedetil_discount = Math.Round(clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(b).Cells("advancedetil_discount").Value, 0), 2, MidpointRounding.AwayFromZero)
                Else
                    If Me.DgvItemBudgetDetil.Rows(b).Cells("advancedetil_discount").Value = Me.DgvRefOrder.Rows(b).Cells("orderdetil_discount").Value * Me.DgvRefOrder.Rows(b).Cells("orderdetil_qty").Value Then
                        advancedetil_discount = Math.Round(clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(b).Cells("advancedetil_discount").Value, 0), 2, MidpointRounding.AwayFromZero)
                    Else
                        advancedetil_discount = Math.Round((Math.Round(clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(b).Cells("advancedetil_discount").Value, 0), 2) * Me.DgvRefOrder.Rows(b).Cells("orderdetil_qty").Value), 2, MidpointRounding.AwayFromZero) 'Math.Round((clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(b).Cells("advancedetil_discount").Value, 0) * Me.DgvRefOrder.Rows(b).Cells("orderdetil_qty").Value), 2, MidpointRounding.AwayFromZero)
                    End If
                End If

                pph_amount = Math.Round((((amount_advance - advancedetil_discount) * advancedetil_foreignrate) * (pph_persen / 100)), 2, MidpointRounding.AwayFromZero)
                ppn_amount = Math.Round((((amount_advance - advancedetil_discount) * advancedetil_foreignrate) * (ppn_persen / 100)), 2, MidpointRounding.AwayFromZero)

                Dim accum_advanceinter As Decimal
                accum_advanceinter = (amount_advance + amount_intercompany)



                total_idr = Math.Round((((amount_advance * advancedetil_foreignrate) + (amount_intercompany * advancedetil_foreignrate)) - (advancedetil_discount * advancedetil_foreignrate)), 2, MidpointRounding.AwayFromZero)


                amount_idrreal = ((amount_advance * advancedetil_foreignrate) + (amount_intercompany * advancedetil_foreignrate)) ''''Math.Round(((amount_advance * advancedetil_foreignrate) + (amount_intercompany * advancedetil_foreignrate)), 2, MidpointRounding.AwayFromZero)
                amount_subtotal = Math.Round(((amount_idrreal - (advancedetil_discount * advancedetil_foreignrate)) - pph_amount + ppn_amount), 2, MidpointRounding.AwayFromZero)

                total_foreign = Math.Round((((amount_advance) + (amount_intercompany)) - (advancedetil_discount)), 2, MidpointRounding.AwayFromZero)

                pph_amountforeign = Math.Round((((accum_advanceinter - advancedetil_discount) * (pph_persen / 100))), 2, MidpointRounding.AwayFromZero)
                ppn_amountforeign = Math.Round((((accum_advanceinter - advancedetil_discount) * (ppn_persen / 100))), 2, MidpointRounding.AwayFromZero)


                'If Me.DgvItemBudgetDetil.Rows(b).Cells("currency_id").Value = 1 Then
                '    amount_subtotalforeign = Math.Round((total_foreign - pph_amountforeign + ppn_amountforeign), 2, MidpointRounding.AwayFromZero)
                'Else
                amount_subtotalforeign = Math.Round((total_foreign - pph_amountforeign + ppn_amountforeign), 2, MidpointRounding.AwayFromZero)
                'End If

                Me.DgvItemBudgetDetil.Rows(b).Cells("pph_amount").Value = pph_amount
                Me.DgvItemBudgetDetil.Rows(b).Cells("ppn_amount").Value = ppn_amount
                Me.DgvItemBudgetDetil.Rows(b).Cells("amount_idrreal").Value = amount_idrreal
                Me.DgvItemBudgetDetil.Rows(b).Cells("amount_subtotal").Value = amount_subtotal
                Me.DgvItemBudgetDetil.Rows(b).Cells("amount_subtotalforeign").Value = amount_subtotalforeign

                amount_approvebma = Me.DgvItemBudgetDetil.Rows(b).Cells("amount_approvebma").Value
                accum_budget = Me.DgvItemBudgetDetil.Rows(b).Cells("budget_accum").Value

                amount += amount_subtotal
                amount_foreignreal += amount_advance


                Try


                    amount_order = Me.DgvItemBudgetDetil.Rows(b).Cells("amount_sum").Value

                Catch ex As Exception
                    MsgBox("Test 5" & ex.Message)
                End Try

                budget_accum = clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(b).Cells("budget_accum").Value, 0)



                outstanding_budget = 0 ''''amount_budget - amount_approvebma - amount_order + budget_accum

                Me.DgvItemBudgetDetil.Rows(b).Cells("outstanding_budget").Value = outstanding_budget

                If Me.DgvTrnAdvanceDetil.Rows(a).Cells("advancedetil_line").Value = Me.DgvItemBudgetDetil.Rows(b).Cells("advancedetil_line").Value Then

                    If clsUtil.IsDbNull(Me.DgvTrnAdvanceDetil.Rows(a).Cells("advancedetil_approvedbma").Value, False) = 1 Then
                        Me.DgvItemBudgetDetil.Rows(b).Cells("outstanding_approved").Value = Me.tbl_TrnAdvanceItemDetil.Rows(b).Item("outstanding_approved")
                        Me.DgvItemBudgetDetil.Rows(b).Cells("outstanding_check").Value = True
                    Else
                        Me.DgvItemBudgetDetil.Rows(b).Cells("outstanding_approved").Value = outstanding_budget
                        Me.DgvItemBudgetDetil.Rows(b).Cells("outstanding_check").Value = False
                    End If


                    If Me.DgvItemBudgetDetil.Rows(b).Cells("outstanding_approved").Value < 0 Then
                        jumlah_over = jumlah_over + 1
                    End If
                End If
            Next

            If jumlah_over > 0 Then
                Me.DgvTrnAdvanceDetil.Rows(a).Cells("status_over").Value = "OVER"
            Else
                Me.DgvTrnAdvanceDetil.Rows(a).Cells("status_over").Value = "OK"
            End If
        Next

        Me.obj_amount.Text = Format(amount, "#,##0.00")
        Me.obj_foreignreal.Text = Format(amount_foreignreal, "#,##0.00")
    End Function

    'Tambahan - Ref Request
    Private Function uiTransaksiAdvanceRequest_OpenRowRefRequest(ByVal advance_id As String, ByVal dbConn As OleDb.OleDbConnection) As Boolean
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        dbCmd = New OleDb.OleDbCommand(" ", dbConn)
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@Criteria").Value = String.Format("advancedetil_refreference='{0}'", advance_id)
        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)

        Me.tbl_TrnAdvanceItemDetil.Clear()
        Me.tbl_TrnAdvanceItemDetil = clsDataset.CreateTblTrnAdvanceItemDetilListOrder()
        Me.tbl_TrnAdvanceItemDetil.Columns("advance_id").DefaultValue = advance_id
        Me.tbl_TrnAdvanceItemDetil.Columns("advancedetil_line").DefaultValue = DBNull.Value
        Me.tbl_TrnAdvanceItemDetil.Columns("advancedetil_line").AutoIncrement = True
        Me.tbl_TrnAdvanceItemDetil.Columns("advancedetil_line").AutoIncrementSeed = 10
        Me.tbl_TrnAdvanceItemDetil.Columns("advancedetil_line").AutoIncrementStep = 10

        Try
            dbDA.Fill(Me.tbl_TrnAdvanceItemDetil)
            Me.DgvItemBudgetDetil.DataSource = Me.tbl_TrnAdvanceItemDetil
        Catch ex As Exception
            Throw New Exception(mUiName & ": uiTransaksiAdvanceRequest_OpenRowDetilBudget()" & vbCrLf & ex.Message)
        End Try

    End Function

    Private Overloads Function uiTransaksiAdvanceRequest_OpenRowDetilEps(ByVal advance_id As String, ByVal dbConn As OleDb.OleDbConnection) As Boolean
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        dbCmd = New OleDb.OleDbCommand("vq_TrnAdvanceDetilEps_Select", dbConn)
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@Criteria").Value = String.Format("b.advance_id = '{0}'", advance_id)
        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)
        Me.tbl_Advancedetileps.Clear()

        Me.tbl_Advancedetileps = clsDataset.CreateTblTrnAdvanceItemDetilEps()
        Me.tbl_Advancedetileps.Columns("advance_id").DefaultValue = advance_id
        Me.tbl_Advancedetileps.Columns("budgetdetiluse_line").DefaultValue = DBNull.Value
        Me.tbl_Advancedetileps.Columns("budgetdetiluse_line").AutoIncrement = True
        Me.tbl_Advancedetileps.Columns("budgetdetiluse_line").AutoIncrementSeed = 10
        Me.tbl_Advancedetileps.Columns("budgetdetiluse_line").AutoIncrementStep = 10

        Try
            dbDA.Fill(Me.tbl_Advancedetileps)
            Me.DgvEps.DataSource = Me.tbl_Advancedetileps
            Me.tbl_Advancedetileps.DefaultView.RowFilter = "checked=1"
        Catch ex As Exception
            Throw New Exception(mUiName & ": uiTransaksiAdvanceRequest_OpenRowDetilEps()" & vbCrLf & ex.Message)
        End Try
    End Function

    Private Overloads Function uiTransaksiAdvanceRequest_OpenRowDetilEps(ByRef dbconn As OleDb.OleDbConnection, ByRef dbtrans As OleDb.OleDbTransaction, ByVal advance_id As String) As Boolean
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        dbCmd = New OleDb.OleDbCommand("vq_TrnAdvanceDetilEps_Select", dbconn, dbtrans)
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@Criteria").Value = String.Format("b.advance_id = '{0}'", advance_id)
        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)
        Me.tbl_Advancedetileps.Clear()

        Me.tbl_Advancedetileps = clsDataset.CreateTblTrnAdvanceItemDetilEps()
        Me.tbl_Advancedetileps.Columns("advance_id").DefaultValue = advance_id
        Me.tbl_Advancedetileps.Columns("budgetdetiluse_line").DefaultValue = DBNull.Value
        Me.tbl_Advancedetileps.Columns("budgetdetiluse_line").AutoIncrement = True
        Me.tbl_Advancedetileps.Columns("budgetdetiluse_line").AutoIncrementSeed = 10
        Me.tbl_Advancedetileps.Columns("budgetdetiluse_line").AutoIncrementStep = 10

        Try
            dbDA.Fill(Me.tbl_Advancedetileps)
            Me.DgvEps.DataSource = Me.tbl_Advancedetileps
            Me.tbl_Advancedetileps.DefaultView.RowFilter = "checked=1"
        Catch ex As Exception
            Throw New Exception(mUiName & ": uiTransaksiAdvanceRequest_OpenRowDetilEps()" & vbCrLf & ex.Message)
        End Try
    End Function

    Private Function uiTransaksiAdvanceRequest_First() As Boolean
        'goto first record found
        If Me.DgvTrnAdvance.SelectedRows.Count <= 0 Then
            MsgBox("Belum ada data yang dipilih")
            Exit Function
        End If

        Dim move As Boolean
        Dim Message As String = "Data has been changed. " & vbCrLf & "Save data changes before move to first record ?"
        Dim iTab As Integer = Me.ftabMain.SelectedIndex

        If iTab = 1 Then
            If Me.DATA_ISLOCKED Then
                move = True
            Else
                move = Me.uiTransaksiAdvanceRequest_ConfirmSaveBeforeMove(Message)
            End If
        Else
            move = True
        End If

        If move Then
            Me.DgvTrnAdvance.CurrentCell = Me.DgvTrnAdvance(0, 0)
            Me.uiTransaksiAdvanceRequest_RefreshPosition()
        End If
    End Function

    Private Function uiTransaksiAdvanceRequest_Prev() As Boolean
        'goto previous record found
        If Me.DgvTrnAdvance.SelectedRows.Count <= 0 Then
            MsgBox("Belum ada data yang dipilih")
            Exit Function
        End If

        Dim move As Boolean
        Dim Message As String = "Data has been changed. " & vbCrLf & "Save data changes before move to previous record ?"
        Dim iTab As Integer = Me.ftabMain.SelectedIndex

        If iTab = 1 Then
            If Me.DATA_ISLOCKED Then
                move = True
            Else
                move = Me.uiTransaksiAdvanceRequest_ConfirmSaveBeforeMove(Message)
            End If
        Else
            move = True
        End If

        If move Then
            If Me.DgvTrnAdvance.CurrentCell.RowIndex > 0 Then
                Me.DgvTrnAdvance.CurrentCell = Me.DgvTrnAdvance(0, DgvTrnAdvance.CurrentCell.RowIndex - 1)
                Me.uiTransaksiAdvanceRequest_RefreshPosition()
            End If
        End If

        Try
            If Me.tbl_TrnAdvance_Temp.Rows(0).Item("advance_approved1") = 0 Then
                Me.obj_Advance_approvedstatus.Text = "New"
            ElseIf tbl_TrnAdvance_Temp.Rows(0).Item("advance_approved2") = 1 Then
                Me.obj_Advance_approvedstatus.Text = "Approved by Kadiv"
            ElseIf tbl_TrnAdvance_Temp.Rows(0).Item("advance_approved1") = 1 Then
                Me.obj_Advance_approvedstatus.Text = "Approved by User"
            ElseIf tbl_TrnAdvance_Temp.Rows(0).Item("advance_approved1") = 2 Then
                Me.obj_Advance_approvedstatus.Text = "Disapproved by User"
            ElseIf tbl_TrnAdvance_Temp.Rows(0).Item("advance_approved1") = 3 Then
                Me.obj_Advance_approvedstatus.Text = "Revised"
            End If
        Catch ex As Exception
        End Try
    End Function

    Private Function uiTransaksiAdvanceRequest_Next() As Boolean
        'goto next record found
        If Me.DgvTrnAdvance.SelectedRows.Count <= 0 Then
            MsgBox("Belum ada data yang dipilih")
            Exit Function
        End If

        Dim move As Boolean
        Dim Message As String = "Data has been changed. " & vbCrLf & "Save data changes before move to next record ?"
        Dim iTab As Integer = Me.ftabMain.SelectedIndex

        If iTab = 1 Then
            If Me.DATA_ISLOCKED Then
                move = True
            Else
                move = Me.uiTransaksiAdvanceRequest_ConfirmSaveBeforeMove(Message)
            End If
        Else
            move = True
        End If

        If move Then
            If Me.DgvTrnAdvance.CurrentCell.RowIndex < Me.DgvTrnAdvance.Rows.Count - 1 Then
                Me.DgvTrnAdvance.CurrentCell = Me.DgvTrnAdvance(0, DgvTrnAdvance.CurrentCell.RowIndex + 1)
                Me.uiTransaksiAdvanceRequest_RefreshPosition()
            End If
        End If

        Try
            If Me.tbl_TrnAdvance_Temp.Rows(0).Item("advance_approved1") = 0 Then
                Me.obj_Advance_approvedstatus.Text = "New"
            ElseIf tbl_TrnAdvance_Temp.Rows(0).Item("advance_approved2") = 1 Then
                Me.obj_Advance_approvedstatus.Text = "Approved by Kadiv"
            ElseIf tbl_TrnAdvance_Temp.Rows(0).Item("advance_approved1") = 1 Then
                Me.obj_Advance_approvedstatus.Text = "Approved by User"
            ElseIf tbl_TrnAdvance_Temp.Rows(0).Item("advance_approved1") = 2 Then
                Me.obj_Advance_approvedstatus.Text = "Disapproved by User"
            ElseIf tbl_TrnAdvance_Temp.Rows(0).Item("advance_approved1") = 3 Then
                Me.obj_Advance_approvedstatus.Text = "Revised"
            End If
        Catch ex As Exception
        End Try
    End Function

    Private Function uiTransaksiAdvanceRequest_Last() As Boolean
        'goto last record found
        If Me.DgvTrnAdvance.SelectedRows.Count <= 0 Then
            MsgBox("Belum ada data yang dipilih")
            Exit Function
        End If

        Dim move As Boolean
        Dim Message As String = "Data has been changed. " & vbCrLf & "Save data changes before move to next record ?"
        Dim iTab As Integer = Me.ftabMain.SelectedIndex

        If iTab = 1 Then
            If Me.DATA_ISLOCKED Then
                move = True
            Else
                move = Me.uiTransaksiAdvanceRequest_ConfirmSaveBeforeMove(Message)
            End If
        Else
            move = True
        End If

        If move Then
            Me.DgvTrnAdvance.CurrentCell = Me.DgvTrnAdvance(0, Me.DgvTrnAdvance.Rows.Count - 1)
            Me.uiTransaksiAdvanceRequest_RefreshPosition()
        End If
    End Function

    Private Function uiTransaksiAdvanceRequest_RefreshPosition() As Boolean
        'refresh position
        Dim iTab As Integer = Me.ftabMain.SelectedIndex
        If iTab = 1 Then uiTransaksiAdvanceRequest_OpenRow(Me.DgvTrnAdvance.CurrentRow.Index)
    End Function

    Private Function uiTransaksiAdvanceRequest_ConfirmSaveBeforeMove(ByVal Message As String) As Boolean
        'confirm saving data changes before move
        Dim tbl_TrnAdvance_Temp_Changes As DataTable
        Dim tbl_TrnAdvanceDetil_Changes As DataTable
        Dim tbl_TrnAdvanceItemDetil_Changes As DataTable

        Dim res As System.Windows.Forms.DialogResult
        Dim i As Integer = 0
        Dim advance_id As Object = New Object
        Dim move As Boolean = False
        Dim isTempChanged As Boolean = False

        If Me.DgvTrnAdvance.CurrentCell IsNot Nothing Then
            Me.BindingContext(Me.tbl_TrnAdvance_Temp).EndCurrentEdit()
            tbl_TrnAdvance_Temp_Changes = Me.tbl_TrnAdvance_Temp.GetChanges()

            ''''    For i = 0 To Me.tbl_TrnRequest_TempStart.Columns.Count - 1
            ''''        'If clsUtil.IsDbNull(Me.tbl_TrnRequest_TempStart.Rows(0).Item(i), Me.tbl_TrnRequest_TempStart.Columns(i).DefaultValue) <> clsUtil.IsDbNull(Me.tbl_TrnRequest_Temp.Rows(0).Item(i), Me.tbl_TrnRequest_Temp.Columns(i).DefaultValue) Then
            ''''        If clsUtil.IsDbNull(Me.tbl_TrnRequest_TempStart.Rows(0).Item(i), String.Empty) <> clsUtil.IsDbNull(Me.tbl_TrnRequest_Temp.Rows(0).Item(i), String.Empty) Then
            ''''            isTempChanged = True
            ''''            Exit For
            ''''        End If
            ''''    Next

            Me.DgvTrnAdvanceDetil.EndEdit()
            Me.BindingContext(Me.tbl_TrnAdvanceDetil).EndCurrentEdit()
            tbl_TrnAdvanceDetil_Changes = Me.tbl_TrnAdvanceDetil.GetChanges()

            Me.DgvItemBudgetDetil.EndEdit()
            Me.BindingContext(Me.tbl_TrnAdvanceItemDetil).EndCurrentEdit()
            tbl_TrnAdvanceItemDetil_Changes = Me.tbl_TrnAdvanceItemDetil.GetChanges()

            If isTempChanged Or tbl_TrnAdvanceDetil_Changes IsNot Nothing Then
                res = MessageBox.Show(Message, mUiName, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                Select Case res
                    Case DialogResult.Yes
                        Me.uiTransaksiAdvanceRequest_Save()
                        move = True
                    Case DialogResult.No
                        move = True
                    Case DialogResult.Cancel
                        move = False
                End Select
            Else
                move = True
            End If
        End If

        Return move
    End Function

    Private Function uiTransaksiAdvanceRequest_FormError() As Boolean
        Dim ErrorMessage As String = ""
        Dim ErrorFound As Boolean = False
        ''''Dim tbl_budgetdetil As DataTable = clsDataset.CreateTblTrnRequestdetil()

        Try
            If Me.obj_Advance_usedby.Text = "" Then
                ErrorMessage = "Request by cannot be empty"
                Me.objFormError.SetError(Me.obj_Advance_usedby, ErrorMessage)
                Throw New Exception(ErrorMessage)
            Else
                Me.objFormError.SetError(Me.obj_Advance_usedby, "")
            End If

            If Me.obj_Advance_userpic.Text = "" Then
                ErrorMessage = "User PIC cannot be empty"
                Me.objFormError.SetError(Me.obj_Advance_userpic, ErrorMessage)
                Throw New Exception(ErrorMessage)
            Else
                Me.objFormError.SetError(Me.obj_Advance_userpic, "")
            End If

            '===== vendor cek disisi apa nggk==== 20160126===========
            If Me.obj_rekanan_id.SelectedValue = CType(0, Decimal) Or Me.obj_rekanan_id.SelectedValue = vbNull Then
                ErrorMessage = "Vendor cannot be empty"
                Me.objFormError.SetError(Me.obj_rekanan_id, ErrorMessage)
                Throw New Exception(ErrorMessage)
            Else
                Me.objFormError.SetError(Me.obj_rekanan_id, "")
            End If
            '=======================================================


            'baru
            If Me.obj_budget_id_view.SelectedValue = 0 Then
                If Me._PROGRAMTYPE = "PG" Then
                    ErrorMessage = "Budget must be selected"
                    Me.objFormError.SetError(Me.obj_budget_id_view, ErrorMessage)
                    Throw New Exception(ErrorMessage)
                End If
            Else
                Me.objFormError.SetError(Me.obj_budget_id_view, "")
            End If

            Dim k As Integer
            Dim countdetil As Integer

            countdetil = Me.DgvItemBudgetDetil.Rows.Count - 1

            For k = 0 To countdetil
                If Me.DgvItemBudgetDetil.Rows(k).Cells("budgetdetil_id").Value = 0 Then
                    ErrorMessage = "Budget detail must be selected"
                    Me.objFormError.SetError(Me.DgvItemBudgetDetil, ErrorMessage)
                    Throw New Exception(ErrorMessage)
                Else
                    Me.objFormError.SetError(Me.DgvItemBudgetDetil, "")
                End If
            Next

            ''''If Me._USERSTRUKTURUNIT = Department.BMA Then
            ''''    Me.objFormError.SetError(Me.obj_budget_id_view, "")

            ''''    Dim k As Integer
            ''''    Dim countdetil As Integer

            ''''    countdetil = Me.tbl_TrnAdvanceDetil.Rows.Count - 1

            ''''    For k = 0 To countdetil
            ''''        If Me.tbl_TrnAdvanceItemDetil.Rows(k).Item("budgetdetil_id") = 0 Then
            ''''            ErrorMessage = "Budget detail must be selected"
            ''''            Me.objFormError.SetError(Me.DgvItemBudgetDetil, ErrorMessage)
            ''''            Throw New Exception(ErrorMessage)
            ''''        Else
            ''''            Me.objFormError.SetError(Me.DgvItemBudgetDetil, "")
            ''''        End If
            ''''    Next
            ''''End If

            ''''Dim z As Integer
            ''''Dim OutstandItemdetil As Integer

            ''''OutstandItemdetil = Me.DgvItemBudgetDetil.Rows.Count - 1

            ''''For z = 0 To OutstandItemdetil
            ''''    If Me.DgvItemBudgetDetil.Rows(z).Cells("outstanding_budget").Value < 0 Then
            ''''        ErrorMessage = "Over Budget"
            ''''        Me.objFormError.SetError(Me.DgvItemBudgetDetil, ErrorMessage)
            ''''        Throw New Exception(ErrorMessage)
            ''''    Else
            ''''        Me.objFormError.SetError(Me.DgvItemBudgetDetil, "")
            ''''    End If
            ''''Next

            If Me.obj_strukturunit_id_dest.SelectedValue = 0 Then
                ErrorMessage = "Dept. To must be selected"
                Me.objFormError.SetError(Me.obj_strukturunit_id_dest, ErrorMessage)
                Throw New Exception(ErrorMessage)
            Else
                Me.objFormError.SetError(Me.obj_strukturunit_id_dest, "")
            End If

            ''''If Me._PROGRAMTYPE = "PG" And Me._TYPEID = "VQ" Then
            ''''    If Me.obj_Advance_epsstart.Text = 0 Then
            ''''        If Me.obj_Advance_epsend.Text = 0 Then
            ''''            ErrorMessage = "Overturn episode entry"
            ''''            Me.objFormError.SetError(Me.obj_Advance_epsend, ErrorMessage)
            ''''            Throw New Exception(ErrorMessage)
            ''''        End If
            ''''    Else
            ''''        Me.objFormError.SetError(Me.obj_Advance_epsend, "")
            ''''    End If
            ''''Else
            ''''    Me.objFormError.SetError(Me.obj_Advance_epsend, "")
            ''''End If


            If Me.obj_Advance_currency.SelectedValue = "0" Then
                ErrorMessage = "Currency must be selected"
                Me.objFormError.SetError(Me.obj_Advance_currency, ErrorMessage)
                Throw New Exception(ErrorMessage)
            Else
                Me.objFormError.SetError(Me.obj_Advance_currency, "")
            End If

            ' ''If DateDiff(DateInterval.Second, CDate(Me.obj_Request_useddt.Text), CDate(Me.obj_Request_useddt2.Text)) < 0 Then
            ' ''    ErrorMessage = "Overturn date entry"
            ' ''    Me.objFormError.SetError(Me.obj_Request_useddt2_time, ErrorMessage)
            ' ''    Throw New Exception(ErrorMessage)
            ' ''Else
            ' ''    Me.objFormError.SetError(Me.obj_Request_useddt2_time, "")
            ' ''End If

            If Me._USERSTRUKTURUNIT = Department.BMA Then
                Dim table_advance As DataTable = New DataTable
                Dim advance_idrrealuser As Decimal = 0
                Dim advance_idrreal As Decimal = 0
                Dim advance_idrreal_approved As Decimal = 0
                Dim advance_idrreal_notapproved As Decimal = 0
                Dim i As Integer

                Dim criteria_advance As String = String.Empty

                criteria_advance &= String.Format(" advance_id = '{0}'", Me.obj_Advance_id.Text)
                Me.DataFill(table_advance, "vq_TrnAdvance_Select", String.Format(" advance_id = '{0}'", Me.obj_Advance_id.Text))
                If table_advance.Rows.Count > 0 Then
                    advance_idrrealuser = table_advance.Rows(0).Item("advance_idrrealuser")
                    'advance_idrreal = table_advance.Rows(0).Item("advance_idrreal")
                    advance_idrreal = table_advance.Rows(0).Item("advance_subtotal")
                Else
                    advance_idrrealuser = 0
                    advance_idrreal = 0
                End If

                For i = 0 To Me.tbl_TrnAdvanceDetil.Rows.Count - 1
                    If Me.tbl_TrnAdvanceDetil.Rows(i).Item("advancedetil_approvedbma") = 1 Then
                        'advance_idrreal_approved += Me.tbl_TrnAdvanceDetil.Rows(i).Item("advancedetil_idrreal")
                        advance_idrreal_approved += Me.tbl_TrnAdvanceDetil.Rows(i).Item("advancedetil_subtotal")
                    Else
                        'advance_idrreal_notapproved += Me.tbl_TrnAdvanceDetil.Rows(i).Item("advancedetil_idrreal")
                        advance_idrreal_notapproved += Me.tbl_TrnAdvanceDetil.Rows(i).Item("advancedetil_subtotal")
                    End If
                Next

                If (advance_idrrealuser - advance_idrreal_approved) < advance_idrreal_notapproved Then
                    ErrorMessage = "Amount melebihi batas awal" & vbCrLf & "Nilai Awal = " & String.Format("{0:#,##0}", advance_idrrealuser)
                    Me.objFormError.SetError(Me.obj_Advance_foreignreal, ErrorMessage)
                    Throw New Exception(ErrorMessage)
                Else
                    Me.objFormError.SetError(Me.obj_Advance_foreignreal, "")
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, mUiName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return True
        End Try

        Return False
    End Function

    Private Function uiTransaksiAdvanceRequest_DeleteRow(ByVal rowIndex As Integer) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbCmdDelete As OleDb.OleDbCommand
        Dim advance_id As String
        Dim NewRowIndex As Integer

        advance_id = Me.DgvTrnAdvance.Rows(rowIndex).Cells("advance_id").Value

        dbCmdDelete = New OleDb.OleDbCommand("vq_TrnAdvance_Delete", dbConn)
        dbCmdDelete.CommandType = CommandType.StoredProcedure
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advance_id", System.Data.OleDb.OleDbType.VarWChar, 30))
        dbCmdDelete.Parameters("@advance_id").Value = advance_id

        Dim cookie As Byte() = Nothing

        Try
            dbConn.Open()
            clsApplicationRole.SetAppRole(dbConn, cookie)
            dbCmdDelete.ExecuteNonQuery()

            If Me.DgvTrnAdvance.Rows.Count > 1 Then

                If rowIndex = 0 Then
                    NewRowIndex = rowIndex + 1
                    Me.uiTransaksiAdvanceRequest_OpenRow(NewRowIndex)
                    Me.tbl_TrnAdvance.Rows.RemoveAt(rowIndex)
                ElseIf rowIndex = Me.DgvTrnAdvance.Rows.Count - 1 Then
                    NewRowIndex = rowIndex - 1
                    Me.uiTransaksiAdvanceRequest_OpenRow(NewRowIndex)
                    Me.tbl_TrnAdvance.Rows.RemoveAt(rowIndex)
                Else
                    Me.tbl_TrnAdvance.Rows.RemoveAt(rowIndex)
                    Me.uiTransaksiAdvanceRequest_OpenRow(rowIndex)
                End If
            Else
                Me.tbl_TrnAdvance_Temp.Clear()
                Me.tbl_TrnAdvance.Rows.RemoveAt(rowIndex)
            End If

        Catch ex As Data.OleDb.OleDbException
            MessageBox.Show(ex.Message, "OLE DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Function
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Exit Function
        Finally
            clsApplicationRole.UnsetAppRole(dbConn, cookie)
            dbConn.Close()
        End Try
    End Function

#End Region

    Private Sub uiTransaksiAdvanceRequest_FormBeforeNew() Handles Me.FormBeforeNew
        Me.objFormError.Clear()
    End Sub

    Private Sub uiTransaksiAdvanceRequest_FormBeforeOpenRow(ByRef id As Object) Handles Me.FormBeforeOpenRow
        Me.objFormError.Clear()
    End Sub

    Private Sub uiTransaksiAdvanceRequest_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Me.IsDevelopment = True Then Me.Form_Load(sender)
    End Sub

    Public Sub Form_Load(ByVal sender As Object)
        Dim objParameters As Collection = New Collection
        If Me.Browser IsNot Nothing Then
            objParameters = Me.GetParameterCollection(Me.Parameter)
            Me._CHANNEL = Me.GetValueFromParameter(objParameters, "CHANNEL")
            Me._CHANNEL_CANBE_CHANGED = Me.GetBolValueFromParameter(objParameters, "CHANNELCHANGED")
            Me._CHANNEL_CANBE_BROWSED = Me.GetBolValueFromParameter(objParameters, "CHANNELBROWSED")
            Me._SOURCE = Me.GetValueFromParameter(objParameters, "SOURCE")
            Me._TYPEID = Me.GetValueFromParameter(objParameters, "TYPE_ID")
            Me.DataFill(Me.tbl_MstUser, "ms_MstUserInsosys_Select", String.Format("username = '{0}'", Me.UserName))
            Me._USERSTRUKTURUNIT = Me.tbl_MstUser.Rows(0)("strukturunit_id")
            Me._USERFULLNAME = Me.tbl_MstUser.Rows(0)("user_fullname")
            Me._PROGRAMTYPE = Me.GetValueFromParameter(objParameters, "PROGRAMTYPE")
            Me._SPLIT_ONLY = Me.GetValueFromParameter(objParameters, "SPLIT_ONLY")

            '========== ADD PTS 20150424 == Untuk keperluan authorisasi sekre biar bisa approve bma ==
            Me._MODUL_TYPE = Me.GetValueFromParameter(objParameters, "MODUL_TYPE")
            Me._AUTH_APPBMA_STRUKTURUNIT = Me.GetValueFromParameter(objParameters, "AUTH_APPBMA_STRUKTURUNIT")
            Me._USER_AUTHBMA = Me.GetValueFromParameter(objParameters, "USER_AUTHBMA")
            '=========================================================================================
        End If

        If (Me.Browser IsNot Nothing And MyBase.Name = _Name) Or (Me.Browser Is Nothing And Application.ProductName <> _ProductName) Then
            Me.locking = New clsLockingTransaction(Me._CHANNEL, Me.UserName, Me, Me.ftabMain)
            Me.chkSrchTop.Checked = True
            Me.btnlock.Visible = False
            Me.DgvTrnAdvance.DataSource = Me.tbl_TrnAdvance
            Me.uiTrnJurnal_isBackgroudWorker()
            Me.uiAdvanceRequest_LoadData()
            Me.InitLayoutUI()
            Me.BindingStop()
            Me.BindingStart()
            Me.BindingCheckBoxStop()
            Me.BindingCheckBoxStart()

            For Each tsItem As ToolStripItem In Me.ToolStrip1.Items
                If tsItem.GetType.ToString = "System.Windows.Forms.ToolStripSeparator" Then
                    tsItem.Enabled = True
                Else
                    tsItem.Enabled = False
                End If
            Next

            Me.ftabMain.Dock = DockStyle.Fill

            If Me._USERSTRUKTURUNIT = Department.FIN And Me._SPLIT_ONLY = "Yes" Then
                Me.ContextMenuStrip1.Items("SplitUnsplitAmountToolStripMenuItem").Enabled = True
                Me.ContextMenuStrip1.Items("CopyRowToolStripMenuItem").Enabled = False
            Else
                Me.ContextMenuStrip1.Items("SplitUnsplitAmountToolStripMenuItem").Enabled = False
                Me.ContextMenuStrip1.Items("CopyRowToolStripMenuItem").Enabled = True
            End If

            If Me._USERSTRUKTURUNIT = Department.FIN And Me._SPLIT_ONLY = "Yes" Then
                Me.tbtnNew.Enabled = False
            End If

            '============= ADD PTS 20150507 ==================
            'If Me._USERSTRUKTURUNIT <> Department.BMA And Me._SPLIT_ONLY = "No" And Me._MODUL_TYPE = "bma" Then
            Me.tbtnNew.Visible = False
            Me.tbtnSave.Visible = False
            Me.tbtnDel.Visible = False
            'End If
            Me.tbtnPrev.Visible = False
            Me.tbtnNext.Visible = False
            Me.tbtnFirst.Visible = False
            Me.tbtnLast.Visible = False
            Me.tbtnRefresh.Visible = False
            Me.tbtnQuery.PerformClick()

            Me.btnCreatePaymentVoucher.Name = "btnCreatePaymentVoucher"
            Me.btnCreatePaymentVoucher.Text = "Create PV"
            Me.btnCreatePaymentVoucher.Visible = False
            Me.btnCreatePaymentVoucher.ToolTipText = "Create PV by selected list"
            Me.ToolStrip1.Items.Add(Me.btnCreatePaymentVoucher)
        End If
    End Sub

    Private Sub uiAdvanceRequest_LoadData()
        Dim oDataFiller As New clsDataFiller(Me.DSN)
        Dim objParameters As Collection = New Collection
        Dim row_type As DataRow
        Dim tbl_TrnRequest_Status As New DataTable

        If Me.isLoad = False Then

            'Function: fill data for combo on grid data detail
            tbl_TrnRequest_Status.Columns.Add(New DataColumn("value_type", GetType(System.Decimal)))
            tbl_TrnRequest_Status.Columns.Add(New DataColumn("display_type", GetType(System.String)))

            If tbl_TrnRequest_Status.Columns("display_type") IsNot Nothing Then
                'row_type = tbl_TrnRequest_Status.NewRow
                'row_type.Item("value_type") = 0
                'row_type.Item("display_type") = "New"
                'tbl_TrnRequest_Status.Rows.InsertAt(row_type, 0)

                row_type = tbl_TrnRequest_Status.NewRow
                row_type.Item("value_type") = 1
                row_type.Item("display_type") = "Approved"
                tbl_TrnRequest_Status.Rows.InsertAt(row_type, 1)

                'row_type = tbl_TrnRequest_Status.NewRow
                'row_type.Item("value_type") = 2
                'row_type.Item("display_type") = "Half Approved"
                'tbl_TrnRequest_Status.Rows.InsertAt(row_type, 2)

                'row_type = tbl_TrnRequest_Status.NewRow
                'row_type.Item("value_type") = 3
                'row_type.Item("display_type") = "Canceled"
                'tbl_TrnRequest_Status.Rows.InsertAt(row_type, 3)

                'row_type = tbl_TrnRequest_Status.NewRow
                'row_type.Item("value_type") = 4
                'row_type.Item("display_type") = "Void"
                'tbl_TrnRequest_Status.Rows.InsertAt(row_type, 4)
            End If

            Me.objSrchStatus.DataSource = tbl_TrnRequest_Status
            Me.objSrchStatus.ValueMember = "value_type"
            Me.objSrchStatus.DisplayMember = "display_type"

            Me.chkSrchStatus.Visible = True
            Me.objSrchStatus.Visible = True
            Me.chkSrchStatus.Checked = True

            Me.chkSingleBgt.Checked = True
            Me.chkSingleBgt.Enabled = False

            Me.objSrchStatus.SelectedValue = 1

          
            Dim loc_preparedt_label As New Point(2, 7)
            Dim loc_preparedt_date As New Point(103, 3)
            Dim loc_preparedt_time As New Point(186, 3)
            Dim loc_preparedt_tolabel As New Point(223, 7)
            Dim loc_preparedt_date2 As New Point(241, 3)
            Dim loc_preparedt_time2 As New Point(324, 3)
            Dim loc_preparedt_loclabel As New Point(374, 7)
            Dim loc_preparedt_loctext As New Point(446, 3)

            Dim loc_useddt_label As New Point(2, 29)
            Dim loc_useddt_date As New Point(103, 27)
            Dim loc_useddt_time As New Point(186, 27)
            Dim loc_useddt_tolabel As New Point(223, 32)
            Dim loc_useddt_date2 As New Point(241, 27)
            Dim loc_useddt_time2 As New Point(324, 27)
            Dim loc_useddt_loclabel As New Point(374, 29)
            Dim loc_useddt_loctext As New Point(446, 27)

            Select Case Me._PROGRAMTYPE
                Case "PG"
                    Me.lblProgramType.Text = "PROGRAM"
                    Me.PnlDataMaster.Height = 195
                    Me.Panel6.Visible = False

                    Me.lbl_Request_useddt.Text = "Shooting Date From"
                    Me.lbl_Request_usedloc.Text = "Shooting Loc"

                    Me.lbl_Request_useddt.Location = loc_useddt_label
                    Me.obj_Request_useddt_date.Location = loc_useddt_date
                    Me.obj_Request_useddt_time.Location = loc_useddt_time
                    Me.Label11.Location = loc_useddt_tolabel
                    Me.obj_Request_useddt2_date.Location = loc_useddt_date2
                    Me.obj_Request_useddt2_time.Location = loc_useddt_time2
                    Me.lbl_Request_usedloc.Location = loc_useddt_loclabel
                    Me.obj_Request_usedloc.Location = loc_useddt_loctext
            End Select

            Me.lbl_Request_approved1dt.Visible = True
            Me.obj_Advance_approved1dt.Visible = True
            Me.lbl_Request_modifieddt.Visible = True
            Me.obj_Advance_modifieddt.Visible = True
            Me.lbl_Request_approved2dt.Visible = False
            Me.obj_Advance_approved1by.Visible = True
            Me.obj_Advance_modifiedby.Visible = True

            Me.obj_Request_idref.Visible = True
            Me.lbl_Request_bookdt.Visible = False
            Me.obj_Request_bookdt.Visible = False
            Me.lbl_Request_duedt.Visible = False
            Me.obj_Request_duedt.Visible = False
            Me.lbl_Request_checkdt.Visible = False
            Me.obj_Request_checkdt.Visible = False
            Me.lbl_Request_checkby.Visible = False
            Me.obj_Request_checkby.Visible = False
            Me.lbl_Request_season.Visible = False
            Me.obj_Request_season.Visible = False
            Me.lbl_Request_eps.Visible = False
            Me.obj_Request_eps.Visible = False
            Me.lbl_Request_jurnalisposted.Visible = False
            Me.lbl_Request_regionid.Visible = False
            Me.obj_Request_regionid.Visible = False
            Me.lbl_Request_brandid.Visible = False
            Me.obj_Request_brandid.Visible = False
            Me.obj_strukturunit_id_dest.Visible = True
            Me.lbl_rekanan_id.Visible = False
            Me.obj_rekanan_id.Visible = True
            Me.lbl_Request_sub1.Visible = False
            Me.obj_Request_sub1.Visible = False
            Me.lbl_Request_sub2.Visible = False
            Me.obj_Request_sub2.Visible = False
            Me.lbl_periode_id.Visible = False
            Me.obj_periode_id.Visible = False
            Me.lbl_acctype_id.Visible = False
            Me.obj_acctype_id.Visible = False

            Me.lbl_Request_idr.Visible = False
            Me.obj_Request_idr.Visible = False
            Me.lbl_Request_idrsaldo.Visible = False
            Me.obj_Request_idrsaldo.Visible = False
            Me.lbl_Request_idrreal.Visible = True
            Me.obj_Advance_foreignreal.Visible = True
            Me.lbl_Request_foreignrate.Visible = False
            Me.obj_currency_id.Visible = False
            Me.obj_Advance_foreignrate.Visible = True
            Me.lbl_Request_foreign.Visible = False
            Me.obj_Request_foreign.Visible = False
            Me.lbl_Request_foreignreal.Visible = False
            Me.obj_Request_foreignreal.Visible = False
            Me.lbl_Request_foreignratereal.Visible = False
            Me.obj_Request_foreignratereal.Visible = False
            Me.lbl_Request_foreignratesaldo.Visible = False
            Me.obj_Request_foreignratesaldo.Visible = False
            Me.lbl_Request_foreignsaldo.Visible = False
            Me.obj_Request_foreignsaldo.Visible = False

            Me.lbl_Request_postdt.Visible = False
            Me.obj_Request_postdt.Visible = False
            Me.lbl_Request_postby.Visible = False
            Me.obj_Request_postby.Visible = False
            Me.obj_Advance_pathfile.Visible = True

            Me.lbl_Request_formid.Visible = False
            Me.obj_Request_formid.Visible = False

            'Tambahan - Componen yang sudah digantikan dengan view - Visible = false
            Me.obj_budget_id.Visible = False

            Me.obj_Request_latereason.Visible = True

            'Tambahan - Lock Componen yang sudah diisi otomatis
            Me.obj_Advance_id.Enabled = False
            Me.obj_source_id.Enabled = False
            Me.obj_type_id.Enabled = False
            Me.obj_channel_id.Enabled = False
            Me.obj_Advance_entryby.Enabled = False

            Me.obj_Advance_approved1.Enabled = False

            'Tambahan - Application Info
            Me.obj_source_id.Text = Me._SOURCE
            Me.obj_type_id.Text = Me._TYPEID
            Me.obj_channel_id.Text = Me._CHANNEL

            tbl_Trnrequestdetil_type.Clear()
            tbl_Trnrequestdetil_type.Columns.Add(New DataColumn("value_type", GetType(System.Decimal)))
            tbl_Trnrequestdetil_type.Columns.Add(New DataColumn("display_type", GetType(System.String)))

            If tbl_Trnrequestdetil_type.Columns("display_type") IsNot Nothing Then
                row_type = tbl_Trnrequestdetil_type.NewRow
                row_type.Item("value_type") = 1
                row_type.Item("display_type") = "Item"
                tbl_Trnrequestdetil_type.Rows.InsertAt(row_type, 0)

                row_type = tbl_Trnrequestdetil_type.NewRow
                row_type.Item("value_type") = 0
                row_type.Item("display_type") = "Description"
                tbl_Trnrequestdetil_type.Rows.InsertAt(row_type, 1)
            End If

            ComboFill(obj_Advance_currency, "currency_id", "currency_shortname", tbl_MstCurrencyHeader, "ms_MstCurrency_Select", "currency_active = 1")
            tbl_MstCurrencyHeader.DefaultView.Sort = "currency_shortname"
            ComboFill(obj_strukturunit_id, "strukturunit_id", "strukturunit_namereport", tbl_MstStrukturunit, "cq_MstStrukturUnitRequest_Select", "strukturunit_active = 1")
            tbl_MstStrukturunit.DefaultView.Sort = "strukturunit_namereport"
            tbl_MstStrukturunit_dest = tbl_MstStrukturunit.Copy
            oDataFiller.ComboFillNoSP(obj_strukturunit_id_dest, "strukturunit_id", "strukturunit_namereport", tbl_MstStrukturunit_dest)
            tbl_MstStrukturunit_dest.DefaultView.Sort = "strukturunit_namereport"

            tbl_MstCurrencyDetil = tbl_MstCurrencyHeader.Copy
            tbl_MstCurrencyDetil.DefaultView.Sort = "currency_shortname"
            Me.ComboFill(Me.obj_payment_type, "paymenttype_id", "paymenttype_name", Me.tbl_MstPaymentType, "cp_MstPaymenttype_Select", " ")
            Me.tbl_MstPaymentType.DefaultView.Sort = "paymenttype_name"
            Me.tbl_MstPaymentTypeGrid = Me.tbl_MstPaymentType.Copy
            Me.tbl_MstPaymentTypeGrid.DefaultView.Sort = "paymenttype_name"

            'Search Filler
            tbl_MstStrukturunitSrch = tbl_MstStrukturunit.Copy
            oDataFiller.ComboFillNoSP(objSrchDept, "strukturunit_id", "strukturunit_namereport", tbl_MstStrukturunitSrch)
            tbl_MstStrukturunitSrch.DefaultView.Sort = "strukturunit_namereport"

            'Default Value
            Me.tbl_TrnAdvance.Columns("source_id").DefaultValue = Me._SOURCE
            Me.tbl_TrnAdvance_Temp.Columns("source_id").DefaultValue = Me._SOURCE
            Me.tbl_TrnAdvance.Columns("type_id").DefaultValue = Me._TYPEID
            Me.tbl_TrnAdvance_Temp.Columns("type_id").DefaultValue = Me._TYPEID
            Me.tbl_TrnAdvance.Columns("channel_id").DefaultValue = Me._CHANNEL
            Me.tbl_TrnAdvance_Temp.Columns("channel_id").DefaultValue = Me._CHANNEL
            Me.tbl_TrnAdvance.Columns("advance_entryby").DefaultValue = Me._USERFULLNAME
            Me.tbl_TrnAdvance_Temp.Columns("advance_entryby").DefaultValue = Me._USERFULLNAME
            Me.tbl_TrnAdvance.Columns("advance_usedby").DefaultValue = Me._USERFULLNAME
            Me.tbl_TrnAdvance_Temp.Columns("advance_usedby").DefaultValue = Me._USERFULLNAME
            Me.tbl_TrnAdvance.Columns("advance_prepareby").DefaultValue = Me._USERFULLNAME
            Me.tbl_TrnAdvance_Temp.Columns("advance_prepareby").DefaultValue = Me._USERFULLNAME
            Me.tbl_TrnAdvance.Columns("advance_userpic").DefaultValue = Me._USERFULLNAME
            Me.tbl_TrnAdvance_Temp.Columns("advance_userpic").DefaultValue = Me._USERFULLNAME
            Me.tbl_TrnAdvance.Columns("strukturunit_id").DefaultValue = Me._USERSTRUKTURUNIT
            Me.tbl_TrnAdvance_Temp.Columns("strukturunit_id").DefaultValue = Me._USERSTRUKTURUNIT
            Me.tbl_TrnAdvance.Columns("advance_programtype").DefaultValue = Me._PROGRAMTYPE
            Me.tbl_TrnAdvance_Temp.Columns("advance_programtype").DefaultValue = Me._PROGRAMTYPE
            Me.tbl_TrnAdvance.Columns("strukturunit_id_dest").DefaultValue = Department.BMA
            Me.tbl_TrnAdvance_Temp.Columns("strukturunit_id_dest").DefaultValue = Department.BMA

            Dim myCI As New System.Globalization.CultureInfo("en-GB", False)
            Dim myCIclone As System.Globalization.CultureInfo = CType(myCI.Clone(), System.Globalization.CultureInfo)
            myCIclone.DateTimeFormat.AMDesignator = "a.m."
            myCIclone.DateTimeFormat.DateSeparator = "/"
            myCIclone.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy"
            myCIclone.NumberFormat.CurrencySymbol = "$"
            myCIclone.NumberFormat.NumberDecimalDigits = 4
            System.Threading.Thread.CurrentThread.CurrentCulture = myCIclone

            'If Me._USERSTRUKTURUNIT = Department.BMA Then 'Or Me._USERSTRUKTURUNIT = Department.Procurement Then
            '    Me.chkSrchDept.Checked = False
            '    Me.objSrchDept.SelectedValue = 0
            'Else
            '    If Me._USERSTRUKTURUNIT = Department.FIN And Me._SPLIT_ONLY = "Yes" Then
            '        Me.chkSrchDept.Checked = False
            '        Me.objSrchDept.SelectedValue = 0
            '    Else
            '        Me.chkSrchDept.Checked = True
            '        Me.objSrchDept.SelectedValue = Me._USERSTRUKTURUNIT
            '    End If

            'End If

            Me.btnlock.ToolTipText = "Lock Transaction"
            Me.ToolStrip1.Items.Add(Me.btnlock)
            Me.isLoad = True
        End If
    End Sub

    Private Sub ftabMain_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ftabMain.SelectedIndexChanged
        Select Case ftabMain.SelectedIndex
            Case 0
                Me.tbtnSave.Enabled = False
                Me.tbtnDel.Enabled = False
                Me.tbtnLoad.Enabled = True
                Me.tbtnQuery.Enabled = True
                Me.ftabMain.TabPages.Item(0).BackColor = Color.White
                Me.ftabMain.TabPages.Item(1).BackColor = Color.Gainsboro

                If Me.isRetrieve = True Then
                    Me.uiTransaksiAdvanceRequest_Retrieve()
                    Me.isRetrieve = False
                End If

            Case 1
                If Me._USERSTRUKTURUNIT = Department.FIN And Me._SPLIT_ONLY = "Yes" Then
                    Me.tbtnSave.Enabled = False
                    Me.DgvTrnAdvanceDetil.Columns("advancedetil_approvedbma").ReadOnly = True

                Else
                    Me.tbtnSave.Enabled = True
                End If


                Me.tbtnDel.Enabled = False
                Me.tbtnLoad.Enabled = False
                Me.tbtnQuery.Enabled = False
                Me.ftabMain.TabPages.Item(0).BackColor = Color.Gainsboro
                Me.ftabMain.TabPages.Item(1).BackColor = Color.White

                Me.terors = 0
                Me.guard = True

                If Me.isNew = True Then
                    Me.uiTransaksiAdvanceRequest_NewData()
                Else
                    If Me.DgvTrnAdvance.CurrentRow IsNot Nothing Then
                        Dim dbconn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
                        Dim dbTrans As OleDb.OleDbTransaction
                        Dim cookie As Byte() = Nothing

                        Try
                            dbconn.Open()
                            dbTrans = dbconn.BeginTransaction
                            clsApplicationRole.SetAppRole(dbconn, dbTrans, cookie)
                            Me.uiTransaksiAdvanceRequest_OpenRow(dbconn, dbTrans, Me.DgvTrnAdvance.CurrentRow.Index)
                            dbTrans.Commit()
                        Catch ex As Exception
                            dbTrans.Rollback()
                        Finally
                            clsApplicationRole.UnsetAppRole(dbconn, dbTrans, cookie)
                            dbconn.Close()
                        End Try

                    Else
                        Me.uiTransaksiAdvanceRequest_NewData()
                    End If
                End If

                If Me._USERSTRUKTURUNIT = Department.BMA Then
                    If Me.isNew = True Then
                        Me.obj_Request_active.Enabled = True
                    Else
                        Me.obj_Request_active.Enabled = False
                    End If

                End If
        End Select
    End Sub

    Private Sub DgvTrnRequest_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvTrnAdvance.CellDoubleClick
        If e.ColumnIndex < 0 Or e.RowIndex < 0 Then
            Exit Sub
        End If
        If Me.DgvTrnAdvance.CurrentRow IsNot Nothing Then
            Me.ftabMain.SelectedIndex = 1
        End If
    End Sub

    Private Sub DgvTrnRequest_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DgvTrnAdvance.CellFormatting
        Dim objRow As System.Windows.Forms.DataGridViewRow = DgvTrnAdvance.Rows(e.RowIndex)

        Try

            If objRow.Cells("ispulled_pv").Value = 2 Then
                objRow.DefaultCellStyle.BackColor = Color.PaleGreen
            ElseIf objRow.Cells("ispulled_pv").Value = 1 Then
                objRow.DefaultCellStyle.BackColor = Color.LightYellow
            ElseIf objRow.Cells("ispulled_pv").Value = 0 Then
                objRow.DefaultCellStyle.BackColor = Color.White
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub chkbox_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSrchId.CheckedChanged, chkSrchEntryBy.CheckedChanged, chkSrchDept.CheckedChanged, chkSrchBudget.CheckedChanged, chkSrchStatus.CheckedChanged
        Dim chkbox As CheckBox = sender

        If chkbox.Checked Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub obj_budget_id_view_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles obj_budget_id_view.SelectionChangeCommitted
        Dim rowIndex As Integer
        Dim substract As Integer
        Dim tbl_budget As DataTable = clsDataset.CreateTblTrnBudget
        Dim tbl_budgetdetil As DataTable = clsDataset.CreateTblTrnBudgetDetil()
        Dim budget_name As String
        Dim jumlah_over As Integer
        Dim i As Integer

        If Me.DgvItemBudgetDetil.AllowUserToAddRows Then
            substract = 2
        Else
            substract = 1
        End If

        tbl_budget.Clear()
        Me.DataFill(tbl_budget, "pr_TrnBudget_Select", String.Format("budget_id = {0}", Me.obj_budget_id_view.SelectedValue))
        If tbl_budget.Rows.Count > 0 Then
            Me.obj_Advance_epsstart.Text = clsUtil.IsDbNull(tbl_budget.Rows(0).Item("budget_epsstart"), 0)
            Me.obj_Advance_epsend.Text = clsUtil.IsDbNull(tbl_budget.Rows(0).Item("budget_epsend"), 0)
            budget_name = clsUtil.IsDbNull(tbl_budget.Rows(0).Item("budget_nameshort"), 0)
        Else
            Me.obj_Advance_epsend.Text = 0
            Me.obj_Advance_epsstart.Text = 0
            budget_name = ""
        End If

        For rowIndex = 0 To Me.DgvItemBudgetDetil.Rows.Count - substract
            Me.DgvItemBudgetDetil.Rows(rowIndex).Cells("budget_id").Value = Me.obj_budget_id_view.SelectedValue
            Me.DgvItemBudgetDetil.Rows(rowIndex).Cells("budget_name").Value = budget_name

            Me.DgvItemBudgetDetil.Rows(rowIndex).Cells("budgetdetil_id").Value = 0

            tbl_budgetdetil.Clear()
            Me.DataFill(tbl_budgetdetil, "pr_TrnBudgetDetil_Select", String.Format("budgetdetil_id = {0}", 0))

            If tbl_budgetdetil.Rows.Count > 0 Then
                Me.DgvItemBudgetDetil.Rows(rowIndex).Cells("budgetdetil_name").Value = tbl_budgetdetil.Rows(0)("budgetdetil_desc")
                Me.DgvItemBudgetDetil.Rows(rowIndex).Cells("amount_budget").Value = tbl_budgetdetil.Rows(0)("budgetdetil_amount")
                Me.DgvItemBudgetDetil.Rows(rowIndex).Cells("acc_id").Value = tbl_budgetdetil.Rows(0)("acc_id")


            Else
                Me.DgvItemBudgetDetil.Rows(rowIndex).Cells("budgetdetil_name").Value = String.Empty
                Me.DgvItemBudgetDetil.Rows(rowIndex).Cells("amount_budget").Value = 0
                Me.DgvItemBudgetDetil.Rows(rowIndex).Cells("amount_budget").Value = 0
            End If

            Me.uiTransaksiAdvanceRequest_OutstandingBudget()

            If Me.DgvItemBudgetDetil.Rows(rowIndex).Cells("outstanding_approved").Value < 0 Then
                jumlah_over = jumlah_over + 1
            End If
        Next

        For i = 0 To Me.DgvTrnAdvanceDetil.Rows.Count - 1
            If jumlah_over > 0 Then
                Me.DgvTrnAdvanceDetil.Rows(i).Cells("status_over").Value = "OVER"
            Else
                Me.DgvTrnAdvanceDetil.Rows(i).Cells("status_over").Value = "OK"
            End If
        Next

        ''''Me.tbl_TrnAdvanceItemDetil.Columns("budget_id").DefaultValue = Me.obj_budget_id_view.SelectedValue

    End Sub

    Private Sub obj_budget_id_code_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles obj_budget_id_code.Validated
        Dim rowIndex As Integer
        Dim substract As Integer
        Dim tbl_budget As DataTable = clsDataset.CreateTblTrnBudget

        If Me.DgvTrnAdvanceDetil.AllowUserToAddRows Then
            substract = 2
        Else
            substract = 1
        End If

        If Me.obj_budget_id_view.SelectedValue Is Nothing Then
            Me.obj_budget_id_view.SelectedValue = clsUtil.IsDbNull(Me.tbl_TrnAdvanceItemDetil.Columns("budget_id").DefaultValue, 0)
        End If

        For rowIndex = 0 To Me.DgvItemBudgetDetil.Rows.Count - substract
            Me.DgvItemBudgetDetil.Rows(rowIndex).Cells("budget_id").Value = Me.obj_budget_id_view.SelectedValue
        Next

        Me.tbl_TrnAdvanceItemDetil.Columns("budget_id").DefaultValue = Me.obj_budget_id_view.SelectedValue

        tbl_budget.Clear()
        Me.DataFill(tbl_budget, "pr_TrnBudget_Select", String.Format("budget_id = {0}", Me.obj_budget_id_view.SelectedValue))
        If tbl_budget.Rows.Count > 0 Then
            Me.obj_Advance_epsstart.Text = clsUtil.IsDbNull(tbl_budget.Rows(0).Item("budget_epsstart"), 0)
            Me.obj_Advance_epsend.Text = clsUtil.IsDbNull(tbl_budget.Rows(0).Item("budget_epsend"), 0)
        Else
            Me.obj_Advance_epsend.Text = 0
            Me.obj_Advance_epsstart.Text = 0
        End If

    End Sub

    Private Sub ftabDataDetil_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ftabDataDetil.SelectedIndexChanged
        Select Case Me.ftabDataDetil.SelectedTab.Name
            Case "ftabDataDetil_Detil"
                Me.ftabDataDetil.Height = 272
                Me.PnlDataFooter.Height = 88
            Case "ftabDataDetil_UserInfo"
                Me.ftabDataDetil.Height = 272
                Me.PnlDataFooter.Height = 88
            Case "ftabDataDetil_RefReq"
                Me.ftabDataDetil.Height = 272
                Me.PnlDataFooter.Height = 88
            Case "ftabDataDetil_ItemBudgetDetil"
                Me.ftabDataDetil.Height = 272
                Me.PnlDataFooter.Height = 88
                ''''Me.uiTransaksiAdvanceRequest_OutstandingBudget()
                'uiTransaksiAdvanceRequest_OutstandingAdvanceOrder()
        End Select
    End Sub

    Private Sub obj_attach_browse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles obj_attach_browse.Click
        attach_temp = ""
    End Sub

    Private Sub cmdAddDesc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddDesc.Click
        Dim i As Integer
        Dim line As Integer

        If guard = True Then
            terors += 1
        End If

        Try
            'If Me.DgvTrnAdvanceDetil.Rows.Count = 0 Then
            '    MsgBox("Cannot insert description, no row in datagrid")
            'Else
            Me.tbl_TrnAdvanceDetil.Rows.Add()
            Me.tbl_TrnAdvanceDetil.Rows(Me.tbl_TrnAdvanceDetil.Rows.Count - 1).Item("advancedetil_type") = 0
            Me.tbl_TrnAdvanceDetil.Rows(Me.tbl_TrnAdvanceDetil.Rows.Count - 1).Item("advancedetil_line") = Me.tbl_TrnAdvanceDetil.Rows(Me.tbl_TrnAdvanceDetil.Rows.Count - 1).Item("advancedetil_line") ''''+ 10

            line = Me.tbl_TrnAdvanceDetil.Rows(Me.tbl_TrnAdvanceDetil.Rows.Count - 1).Item("advancedetil_line")

            For i = 0 To Me.DgvTrnAdvanceDetil.Rows.Count - 1
                If Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_line").Value = line Then
                    Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_line").ReadOnly = True
                    Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_line").Style.BackColor = Color.Gainsboro

                    Me.DgvTrnAdvanceDetil.Rows(i).Cells("currency_id").Value = Me.obj_Advance_currency.SelectedValue
                    Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_paymenttype").Value = Me.obj_payment_type.SelectedValue
                    Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_paymentdt").ReadOnly = True
                    Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_paymenttype").ReadOnly = True
                    Me.DgvTrnAdvanceDetil.Rows(i).Cells("select_additem").ReadOnly = True
                    Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_approvedbma").ReadOnly = True
                    Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_approvedbmadt").Value = DBNull.Value
                    Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_approveddescr").ReadOnly = True
                    Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_approveddescr").Style.BackColor = Color.Gainsboro
                End If
            Next
            'End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub cmdDelDesc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelDesc.Click
        Try
            If Me.DgvTrnAdvanceDetil.Rows(Me.DgvTrnAdvanceDetil.CurrentRow.Index).Cells("advancedetil_type").Value = 0 Then
                Me.DgvTrnAdvanceDetil.Rows.RemoveAt(Me.DgvTrnAdvanceDetil.CurrentRow.Index)
                If guard = True Then
                    terors -= 1
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

#Region "Dgvdetil cell click ASLI"
    'Private Sub DgvTrnAdvanceDetil_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvTrnAdvanceDetil.CellClick

    '    Dim Message As String = "Data is OVER " & vbCrLf & " Are you sure want to save? "
    '    Dim response As System.Windows.Forms.DialogResult

    '    Dim tbl_Advancedetil_Changes As DataTable
    '    Dim MasterDataState As System.Data.DataRowState

    '    If e.RowIndex >= 0 Then
    '        Select Case e.ColumnIndex
    '            Case Me.DgvTrnAdvanceDetil.Columns("advancedetil_approvedbma").Index
    '                Try
    '                    If Me._USERSTRUKTURUNIT = Department.BMA And Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells("advancedetil_ordered").Value = 0 And Me.tbl_TrnAdvance_Temp.Rows(0).Item("advance_canceled") = 0 Then
    '                        If Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells("advancedetil_approvedbma").ReadOnly = False Then

    '                            If Me.tbl_TrnAdvance_Temp.Rows(0).Item("advance_approved1") = 1 Then

    '                                Me.DgvTrnAdvanceDetil.EndEdit()
    '                                Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells("advancedetil_approvedbma").ReadOnly = False
    '                                Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells("advancedetil_approvedbma").Value = Not clsUtil.IsDbNull(Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells("advancedetil_approvedbma").Value, False)

    '                                If Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells("status_over").Value = "OVER" Then

    '                                    Select Case Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells("advancedetil_approvedbma").Value
    '                                        Case 255
    '                                            response = MessageBox.Show(Message, mUiName, MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
    '                                            Select Case response
    '                                                Case DialogResult.OK
    '                                                    Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells("advancedetil_approvedbma").Value = 1
    '                                                    Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells("advancedetil_approvedbmadt").Value = Format(Now(), "dd/MM/yyyy HH:mm")
    '                                                    Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells("advancedetil_approvedbmaby").Value = Me._USERFULLNAME

    '                                                Case DialogResult.Cancel
    '                                                    Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells("advancedetil_approvedbma").Value = 0
    '                                                    Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells("advancedetil_approvedbmadt").Value = DBNull.Value
    '                                                    Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells("advancedetil_approvedbmaby").Value = String.Empty

    '                                                    Exit Sub
    '                                            End Select
    '                                        Case Else
    '                                            If Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells("advancedetil_approvedbmaby").Value <> Me._USERFULLNAME Then
    '                                                MsgBox("You don't have the authority to disapprove data")
    '                                                Exit Sub
    '                                            Else
    '                                                Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells("advancedetil_approvedbma").Value = 0
    '                                                Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells("advancedetil_approvedbmadt").Value = DBNull.Value
    '                                                Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells("advancedetil_approvedbmaby").Value = String.Empty
    '                                            End If

    '                                    End Select

    '                                    Me.DgvTrnAdvanceDetil.EndEdit()
    '                                    Me.BindingContext(Me.tbl_TrnAdvanceDetil).EndCurrentEdit()
    '                                    tbl_Advancedetil_Changes = Me.tbl_TrnAdvanceDetil.GetChanges()
    '                                    If Me.tbl_TrnAdvanceDetil.GetChanges IsNot Nothing Then
    '                                        Me.uiTransaksiAdvanceRequest_saveOutStanding_Approved(Me.obj_Advance_id.Text, Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells("advancedetil_line").Value, e.RowIndex)
    '                                        Me.uiTransaksiAdvanceRequest_SaveDetil(Me.obj_Advance_id.Text, tbl_Advancedetil_Changes, MasterDataState)
    '                                        Me.isRetrieve = True
    '                                    End If
    '                                    'gak over
    '                                Else
    '                                    Select Case Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells("advancedetil_approvedbma").Value
    '                                        Case 255
    '                                            Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells("advancedetil_approvedbma").Value = 1
    '                                            Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells("advancedetil_approvedbmadt").Value = Format(Now(), "dd/MM/yyyy HH:mm")
    '                                            Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells("advancedetil_approvedbmaby").Value = Me._USERFULLNAME

    '                                            'Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells("bma_approved").Value = 1
    '                                            'Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells("bma_approveddt").Value = Format(Now(), "dd/MM/yyyy HH:mm")
    '                                            'Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells("bma_approvedby").Value = Me._USERFULLNAME

    '                                        Case Else

    '                                            If Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells("advancedetil_approvedbmaby").Value <> Me._USERFULLNAME Then
    '                                                MsgBox("You don't have the authority to disapprove data")
    '                                                Exit Sub
    '                                            Else
    '                                                Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells("advancedetil_approvedbma").Value = 0
    '                                                Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells("advancedetil_approvedbmadt").Value = DBNull.Value
    '                                                Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells("advancedetil_approvedbmaby").Value = String.Empty

    '                                                'Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells("bma_approved").Value = 0
    '                                                'Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells("bma_approveddt").Value = DBNull.Value
    '                                                'Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells("bma_approvedby").Value = String.Empty
    '                                            End If

    '                                    End Select

    '                                    Me.DgvTrnAdvanceDetil.EndEdit()
    '                                    Me.BindingContext(Me.tbl_TrnAdvanceDetil).EndCurrentEdit()
    '                                    tbl_Advancedetil_Changes = Me.tbl_TrnAdvanceDetil.GetChanges()
    '                                    If Me.tbl_TrnAdvanceDetil.GetChanges IsNot Nothing Then
    '                                        Me.uiTransaksiAdvanceRequest_saveOutStanding_Approved(Me.obj_Advance_id.Text, Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells("advancedetil_line").Value, e.RowIndex)
    '                                        Me.uiTransaksiAdvanceRequest_SaveDetil(Me.obj_Advance_id.Text, tbl_Advancedetil_Changes, MasterDataState)
    '                                        Me.isRetrieve = True
    '                                    End If
    '                                End If
    '                                'belom di approve
    '                            Else
    '                                Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells("advancedetil_approvedbma").ReadOnly = True
    '                                Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells("advancedetil_approvedbma").Style.BackColor = Color.Gainsboro
    '                            End If

    '                        Else
    '                            Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells("advancedetil_approvedbma").ReadOnly = True
    '                        End If

    '                    ElseIf Me._USERSTRUKTURUNIT = Department.BMA And Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells("advancedetil_ordered").Value = 1 Then
    '                        Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells("advancedetil_approvedbma").ReadOnly = True
    '                    ElseIf Me._USERSTRUKTURUNIT <> Department.BMA Then
    '                        Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells("advancedetil_approvedbma").ReadOnly = True
    '                    End If

    '                    Dim d As Integer

    '                    For d = 0 To Me.DgvItemBudgetDetil.Rows.Count - 1
    '                        If Me.DgvItemBudgetDetil.Rows(d).Cells("advancedetil_line").Value = Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells("advancedetil_line").Value And Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells("advancedetil_approvedbma").Value = 1 Then
    '                            Me.DgvItemBudgetDetil.Rows(d).Cells("outstanding_check").Value = 1
    '                        Else
    '                            Me.DgvItemBudgetDetil.Rows(d).Cells("outstanding_check").Value = 0
    '                        End If
    '                    Next
    '                    ''''Me.uiTalentRequest_GetBudgetInfo()

    '                Catch ex As Exception
    '                End Try

    '            Case Me.DgvTrnAdvanceDetil.Columns("select_additem").Index
    '                If Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells("select_additem").ReadOnly = False Then
    '                    Me.uiAdvanceRequest_Additem(e.RowIndex)
    '                End If

    '        End Select
    '    End If
    'End Sub
#End Region

    Private Sub DgvTrnAdvanceDetil_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvTrnAdvanceDetil.CellClick

        Dim Message As String = "Data is OVER " & vbCrLf & " Are you sure want to save? "
        Dim response As System.Windows.Forms.DialogResult

        Dim tbl_Advancedetil_Changes As DataTable
        Dim MasterDataState As System.Data.DataRowState

        If e.RowIndex >= 0 Then
            Select Case e.ColumnIndex
                Case Me.DgvTrnAdvanceDetil.Columns("advancedetil_approvedbma").Index
                    Dim dbconn As New OleDb.OleDbConnection(Me.DSN)
                    Dim dbTrans As OleDb.OleDbTransaction
                    Dim cookie As Byte() = Nothing

                    Try
                        dbconn.Open()
                        dbTrans = dbconn.BeginTransaction
                        clsApplicationRole.SetAppRole(dbconn, dbTrans, cookie)

                        If Me.tbl_TrnAdvance_Temp.Rows.Count > 0 Then
                            Try
                                If (Me._MODUL_TYPE = "bma" Or Me._USERSTRUKTURUNIT = Department.BMA) _
                                    And Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells("advancedetil_ordered").Value = 0 _
                                    And Me.tbl_TrnAdvance_Temp.Rows(0).Item("advance_canceled") = 0 Then

                                    If Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells("advancedetil_approvedbma").ReadOnly = False Then

                                        If Me.tbl_TrnAdvance_Temp.Rows(0).Item("advance_approved1") = 1 Then
                                            Me.DgvTrnAdvanceDetil.EndEdit()
                                            Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells("advancedetil_approvedbma").ReadOnly = False
                                            Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells("advancedetil_approvedbma").Value = Not clsUtil.IsDbNull(Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells("advancedetil_approvedbma").Value, False)

                                            If Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells("status_over").Value = "OVER" Then

                                                Select Case Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells("advancedetil_approvedbma").Value
                                                    Case 255
                                                        response = MessageBox.Show(Message, mUiName, MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
                                                        Select Case response
                                                            Case DialogResult.OK
                                                                Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells("advancedetil_approvedbma").Value = 1
                                                                Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells("advancedetil_approvedbmadt").Value = Format(Now(), "dd/MM/yyyy HH:mm")
                                                                Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells("advancedetil_approvedbmaby").Value = Me._USERFULLNAME


                                                            Case DialogResult.Cancel
                                                                Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells("advancedetil_approvedbma").Value = 0
                                                                Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells("advancedetil_approvedbmadt").Value = DBNull.Value
                                                                Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells("advancedetil_approvedbmaby").Value = String.Empty

                                                                Exit Sub
                                                        End Select

                                                        Me.DgvTrnAdvanceDetil.EndEdit()
                                                        Me.BindingContext(Me.tbl_TrnAdvanceDetil).EndCurrentEdit()
                                                        tbl_Advancedetil_Changes = Me.tbl_TrnAdvanceDetil.GetChanges()
                                                        If Me.tbl_TrnAdvanceDetil.GetChanges IsNot Nothing Then
                                                            If Me.uiTransaksiAdvanceRequest_saveOutStanding_Approved(Me.obj_Advance_id.Text, Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells("advancedetil_line").Value, e.RowIndex, dbconn, dbTrans) = False Then
                                                                GoTo rollback
                                                            End If

                                                            If Me.uiTransaksiAdvanceRequest_SaveDetil(Me.obj_Advance_id.Text, tbl_Advancedetil_Changes, MasterDataState, dbconn, dbTrans) = False Then
                                                                GoTo rollback
                                                            End If
                                                            Me.isRetrieve = True
                                                        End If

                                                    Case Else
                                                        If Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells("advancedetil_approvedbmaby").Value <> Me._USERFULLNAME Then
                                                            MsgBox("You don't have the authority to disapprove data")
                                                            Exit Sub
                                                        Else

                                                            If Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells("bma_approved").Value = 1 Then
                                                                Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells("advancedetil_approvedbma").Value = 0
                                                                Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells("advancedetil_approvedbmadt").Value = DBNull.Value
                                                                Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells("advancedetil_approvedbmaby").Value = String.Empty

                                                                Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells("bma_approved").Value = 0
                                                                Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells("bma_approveddt").Value = DBNull.Value
                                                                Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells("bma_approvedby").Value = String.Empty

                                                                If Me.uiTransaksiAdvanceRequest_saveMemo_ApprovedStatusOver(Me.obj_Advance_id.Text, Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells("advancedetil_line").Value, e.RowIndex, dbconn, dbTrans) = False Then
                                                                    GoTo rollback
                                                                End If
                                                            Else
                                                                Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells("advancedetil_approvedbma").Value = 0
                                                                Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells("advancedetil_approvedbmadt").Value = DBNull.Value
                                                                Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells("advancedetil_approvedbmaby").Value = String.Empty
                                                            End If

                                                            Me.DgvTrnAdvanceDetil.EndEdit()
                                                            Me.BindingContext(Me.tbl_TrnAdvanceDetil).EndCurrentEdit()
                                                            tbl_Advancedetil_Changes = Me.tbl_TrnAdvanceDetil.GetChanges()
                                                            If Me.tbl_TrnAdvanceDetil.GetChanges IsNot Nothing Then
                                                                If Me.uiTransaksiAdvanceRequest_saveOutStanding_Approved(Me.obj_Advance_id.Text, Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells("advancedetil_line").Value, e.RowIndex, dbconn, dbTrans) = False Then
                                                                    GoTo rollback
                                                                End If
                                                                If Me.uiTransaksiAdvanceRequest_SaveDetil(Me.obj_Advance_id.Text, tbl_Advancedetil_Changes, MasterDataState, dbconn, dbTrans) = False Then
                                                                    GoTo rollback
                                                                End If
                                                                Me.isRetrieve = True
                                                            End If

                                                        End If

                                                End Select

                                                'gak over
                                            Else
                                                Select Case Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells("advancedetil_approvedbma").Value
                                                    Case 255
                                                        Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells("advancedetil_approvedbma").Value = 1
                                                        Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells("advancedetil_approvedbmadt").Value = Format(Now(), "dd/MM/yyyy HH:mm")
                                                        Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells("advancedetil_approvedbmaby").Value = Me._USERFULLNAME

                                                        Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells("bma_approved").Value = 1
                                                        Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells("bma_approveddt").Value = Format(Now(), "dd/MM/yyyy HH:mm")
                                                        Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells("bma_approvedby").Value = Me._USERFULLNAME

                                                    Case Else

                                                        If Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells("advancedetil_approvedbmaby").Value <> Me._USERFULLNAME Then
                                                            MsgBox("You don't have the authority to disapprove data")
                                                            Exit Sub
                                                        Else
                                                            Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells("advancedetil_approvedbma").Value = 0
                                                            Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells("advancedetil_approvedbmadt").Value = DBNull.Value
                                                            Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells("advancedetil_approvedbmaby").Value = String.Empty

                                                            Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells("bma_approved").Value = 0
                                                            Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells("bma_approveddt").Value = DBNull.Value
                                                            Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells("bma_approvedby").Value = String.Empty
                                                        End If

                                                End Select

                                                Me.DgvTrnAdvanceDetil.EndEdit()
                                                Me.BindingContext(Me.tbl_TrnAdvanceDetil).EndCurrentEdit()
                                                tbl_Advancedetil_Changes = Me.tbl_TrnAdvanceDetil.GetChanges()
                                                If Me.tbl_TrnAdvanceDetil.GetChanges IsNot Nothing Then
                                                    If Me.uiTransaksiAdvanceRequest_saveMemo_Approved(Me.obj_Advance_id.Text, Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells("advancedetil_line").Value, e.RowIndex, dbconn, dbTrans) = False Then
                                                        GoTo rollback
                                                    End If

                                                    If Me.uiTransaksiAdvanceRequest_saveOutStanding_Approved(Me.obj_Advance_id.Text, Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells("advancedetil_line").Value, e.RowIndex, dbconn, dbTrans) = False Then
                                                        GoTo rollback
                                                    End If

                                                    If Me.uiTransaksiAdvanceRequest_SaveDetil(Me.obj_Advance_id.Text, tbl_Advancedetil_Changes, MasterDataState, dbconn, dbTrans) = False Then
                                                        GoTo rollback
                                                    End If

                                                    Me.isRetrieve = True
                                                End If
                                            End If

                                            'belom di approve
                                        Else
                                            Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells("advancedetil_approvedbma").ReadOnly = True
                                            Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells("advancedetil_approvedbma").Style.BackColor = Color.Gainsboro
                                        End If

                                    Else
                                        Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells("advancedetil_approvedbma").ReadOnly = True
                                    End If

                                ElseIf (Me._MODUL_TYPE = "bma" Or Me._USERSTRUKTURUNIT = Department.BMA) And Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells("advancedetil_ordered").Value = 1 Then
                                    Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells("advancedetil_approvedbma").ReadOnly = True
                                ElseIf (Me._MODUL_TYPE <> "bma" Or Me._USERSTRUKTURUNIT <> Department.BMA) Then
                                    Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells("advancedetil_approvedbma").ReadOnly = True
                                End If

                                Dim d As Integer

                                For d = 0 To Me.DgvItemBudgetDetil.Rows.Count - 1
                                    If Me.DgvItemBudgetDetil.Rows(d).Cells("advancedetil_line").Value = Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells("advancedetil_line").Value And Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells("advancedetil_approvedbma").Value = 1 Then
                                        Me.DgvItemBudgetDetil.Rows(d).Cells("outstanding_check").Value = 1
                                    Else
                                        Me.DgvItemBudgetDetil.Rows(d).Cells("outstanding_check").Value = 0
                                    End If
                                Next

                            Catch ex As Exception
                                dbTrans.Rollback()
                                'clsApplicationRole.UnsetAppRole(dbconn, dbTrans, cookie)
                                'dbconn.Close()
                                MsgBox(ex.Message)
                                Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells("advancedetil_approvedbma").Value = 0
                                Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells("advancedetil_approvedbmadt").Value = DBNull.Value
                                Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells("advancedetil_approvedbmaby").Value = String.Empty

                                Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells("bma_approved").Value = 0
                                Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells("bma_approveddt").Value = DBNull.Value
                                Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells("bma_approvedby").Value = String.Empty

                                Exit Sub
                            End Try
                        End If

                        dbTrans.Commit()
                        MsgBox("Item has been saved")
                        'clsApplicationRole.UnsetAppRole(dbconn, dbTrans, cookie)
                        'dbconn.Close()

                        '==================================================================================================
                        'Add by Khafit Bimo - 15 Agustus 2018
                        Dim totalRow As Integer = Me.DgvTrnAdvanceDetil.Rows.Count
                        Dim totalIsAppBMA As Integer = 0
                        Dim emailTo As String = clsUtil.GetEmailDept(Department.FIN, Me.DSN).ToString.ToLower.Replace(" ", "")
                        For i As Integer = 0 To totalRow - 1
                            If Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_approvedbma").Value = 1 Then
                                totalIsAppBMA += 1
                            End If
                        Next

                        If totalRow - totalIsAppBMA = 0 Then
                            If Me.uiTrnAdvanceRequest_SentEmail("VQListLQ_BMAAppToFin", emailTo) Then
                                MessageBox.Show("Notification email sent successfully to Finance Head", "NET. Email Center", MessageBoxButtons.OK)
                            End If
                        End If

                        '==================================================================================================

                        Exit Sub
rollback:
                        dbTrans.Rollback()
                       
                        MsgBox("Data Rollback", MsgBoxStyle.Critical)
                        Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells("advancedetil_approvedbma").Value = 0
                        Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells("advancedetil_approvedbmadt").Value = DBNull.Value
                        Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells("advancedetil_approvedbmaby").Value = String.Empty
                        Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells("bma_approved").Value = 0
                        Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells("bma_approveddt").Value = DBNull.Value
                        Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells("bma_approvedby").Value = String.Empty

                    Catch ex As Exception
                        MsgBox(ex.Message)
                    Finally
                        clsApplicationRole.UnsetAppRole(dbconn, dbTrans, cookie)
                        dbconn.Close()
                    End Try

                    


                Case Me.DgvTrnAdvanceDetil.Columns("select_additem").Index
                    If Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells("select_additem").ReadOnly = False Then
                        Me.uiAdvanceRequest_Additem(e.RowIndex)
                    End If
                Case Me.DgvTrnAdvanceDetil.Columns("bma_approved").Index
                    Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells("bma_approved").ReadOnly = True
            End Select
        End If
    End Sub

    Private Function uiAdvanceRequest_Additem(ByVal Rowindex As Integer) As Boolean

        Dim tbl_TrnAdvanceItemDetils As DataTable = New DataTable
        Dim tbl_RefOrder2 As DataTable = New DataTable

        Me.DgvItemBudgetDetil.EndEdit()
        Me.BindingContext(Me.tbl_TrnAdvanceItemDetil).EndCurrentEdit()

        Me.DgvRefOrder.EndEdit()
        Me.BindingContext(Me.tbl_RefOrder).EndCurrentEdit()

        tbl_TrnAdvanceItemDetils = Me.tbl_TrnAdvanceItemDetil.Copy
        'Me.tbl_TrnAdvanceItemDetil.DefaultView.Sort = "budgetdetil_line"
        'tbl_TrnAdvanceItemDetils = Me.tbl_TrnAdvanceItemDetil.DefaultView.ToTable

        tbl_RefOrder2 = Me.tbl_RefOrder.Copy

        Dim dlg As dlgTrnSelectItemChildListOrder = New dlgTrnSelectItemChildListOrder(Me.DSN, tbl_TrnAdvanceItemDetils, _
        Me.DgvTrnAdvanceDetil.Rows(Rowindex).Cells("advancedetil_line").Value, _
        Me.tbl_MstCurrencyDetil.Copy, Me.obj_budget_id_code.Text, Me.obj_budget_id_view.Text, Me._CHANNEL, _
        Me.obj_Advance_currency.SelectedValue, Me._USERSTRUKTURUNIT, Me.tbl_Advancedetileps.Copy, Me.tbl_TrnAdvance_Temp.Copy, _
        Me.obj_Advance_epsend.Text, Me.obj_Advance_epsstart.Text, Me.obj_Advance_id.Text, Me.DgvTrnAdvanceDetil.Rows(Rowindex).Cells("advancedetil_line").Value, tbl_RefOrder2)

        Dim retObj As Object
        Dim row_indexDetil As Integer
        Dim total_perRow, total_subtotal As Decimal
        Dim retData As Collection
        Dim tbl_TrnAdvanceItemDetil_temps As DataTable = New DataTable
        Dim id As String

        Dim tbl_refOrder_temp As DataTable = New DataTable

        '''' baru tgl 05-03-2010

        Dim approve_user, approve_bma As Integer

        If Me.obj_Advance_id.Text <> String.Empty Then
            If Me._USERSTRUKTURUNIT = Department.BMA Then
                approve_bma = clsUtil.IsDbNull(Me.DgvTrnAdvanceDetil.Rows(Rowindex).Cells("advancedetil_approvedbma").Value, False)
                approve_user = clsUtil.IsDbNull(Me.DgvTrnAdvance.Rows(Me.DgvTrnAdvance.CurrentRow.Index).Cells("advance_approved1").Value, False)
                id = Me.obj_Advance_id.Text

                retObj = dlg.OpenDialog(Me._USERSTRUKTURUNIT, approve_user, approve_bma, id, Me)

                tbl_TrnAdvanceItemDetil_temps = dlg.DgvAdvanceItemDetil.DataSource
                tbl_refOrder_temp = dlg.DgvRefOrder.DataSource

                If retObj IsNot Nothing Then
                    retData = CType(retObj, Collection)
                    Me.tbl_Advancedetileps = CType(retData.Item("tblAdvanceEps"), DataTable)

                    Me.tbl_TrnAdvanceItemDetil = tbl_TrnAdvanceItemDetil_temps.Copy
                    Me.DgvItemBudgetDetil.DataSource = Me.tbl_TrnAdvanceItemDetil

                    Me.tbl_RefOrder = tbl_refOrder_temp.Copy

                    If tbl_refOrder_temp.Rows.Count > 0 Then
                        For t As Integer = 0 To tbl_refOrder_temp.Rows.Count - 1
                            If tbl_refOrder_temp.Rows(t).RowState <> DataRowState.Deleted Then
                                Me.tbl_RefOrder.Rows(t).Item("amount_advance") = tbl_refOrder_temp.Rows(t).Item("amount_advance")
                                Me.tbl_RefOrder.Rows(t).Item("amount_sisa") = tbl_refOrder_temp.Rows(t).Item("amount_sisa")
                            End If
                        Next
                    End If

                    Me.DgvRefOrder.DataSource = Me.tbl_RefOrder

                    'For row_index = 0 To Me.DgvTrnAdvanceDetil.Rows.Count - 1
                    total_perRow = 0
                    total_subtotal = 0
                    For row_indexDetil = 0 To Me.tbl_TrnAdvanceItemDetil.Rows.Count - 1
                        If Me.tbl_TrnAdvanceItemDetil.Rows(row_indexDetil).RowState <> DataRowState.Deleted Then
                            If Me.tbl_TrnAdvanceItemDetil.Rows(row_indexDetil).Item("advancedetil_line") = Me.DgvTrnAdvanceDetil.Rows(Rowindex).Cells("advancedetil_line").Value Then
                                total_perRow += clsUtil.IsDbNull(Me.tbl_TrnAdvanceItemDetil.Rows(row_indexDetil).Item("amount_advance"), 0)
                                total_subtotal += clsUtil.IsDbNull(Me.tbl_TrnAdvanceItemDetil.Rows(row_indexDetil).Item("amount_subtotal"), 0)
                            End If
                        End If
                    Next
                   
                    If Me.DgvTrnAdvanceDetil.Rows(Rowindex).Cells("currency_id").Value = 1 Then
                        Me.DgvTrnAdvanceDetil.Rows(Rowindex).Cells("advancedetil_foreignrate").Value = clsUtil.IsDbNull(Me.tbl_TrnAdvanceItemDetil.Rows(0).Item("advancedetil_foreignrate"), 0)
                        Me.DgvTrnAdvanceDetil.Rows(Rowindex).Cells("advancedetil_foreignreal").Value = Math.Round((total_perRow), 2, MidpointRounding.AwayFromZero)
                        Me.DgvTrnAdvanceDetil.Rows(Rowindex).Cells("advancedetil_idrreal").Value = Math.Round((Me.DgvTrnAdvanceDetil.Rows(Rowindex).Cells("advancedetil_foreignrate").Value * total_perRow), 2, MidpointRounding.AwayFromZero)
                        Me.DgvTrnAdvanceDetil.Rows(Rowindex).Cells("advancedetil_subtotal").Value = Math.Round((total_subtotal), 2, MidpointRounding.AwayFromZero)

                    Else
                        Me.DgvTrnAdvanceDetil.Rows(Rowindex).Cells("advancedetil_foreignrate").Value = clsUtil.IsDbNull(Me.tbl_TrnAdvanceItemDetil.Rows(0).Item("advancedetil_foreignrate"), 0)
                        Me.DgvTrnAdvanceDetil.Rows(Rowindex).Cells("advancedetil_foreignreal").Value = Math.Round((total_perRow), 2, MidpointRounding.AwayFromZero)
                        Me.DgvTrnAdvanceDetil.Rows(Rowindex).Cells("advancedetil_idrreal").Value = Math.Round((Me.DgvTrnAdvanceDetil.Rows(Rowindex).Cells("advancedetil_foreignrate").Value * total_perRow), 2, MidpointRounding.AwayFromZero)
                        Me.DgvTrnAdvanceDetil.Rows(Rowindex).Cells("advancedetil_subtotal").Value = Math.Round((total_subtotal), 2, MidpointRounding.AwayFromZero)

                    End If

                    
                    'Next
                    ''''End If
                End If

                'selain BMA
            Else
                ''''If clsUtil.IsDbNull(Me.DgvTrnAdvance.Rows(Me.DgvTrnAdvance.CurrentRow.Index).Cells("advance_approved1").Value, False) = 1 Then
                ''''    MsgBox("Data has been approved by SPV" & vbCrLf & "Cannot add item")
                ''''    Exit Function
                ''''Else

                If Me.tbl_TrnAdvance_Temp.Rows.Count > 0 Then

                    If clsUtil.IsDbNull(Me.DgvTrnAdvance.Rows(Me.DgvTrnAdvance.CurrentRow.Index).Cells("strukturunit_id").Value, 0) = Me._USERSTRUKTURUNIT Then
                        approve_user = clsUtil.IsDbNull(Me.DgvTrnAdvance.Rows(Me.DgvTrnAdvance.CurrentRow.Index).Cells("advance_approved1").Value, False)
                        approve_bma = clsUtil.IsDbNull(Me.DgvTrnAdvanceDetil.Rows(Rowindex).Cells("advancedetil_approvedbma").Value, False)
                        id = Me.obj_Advance_id.Text

                        retObj = dlg.OpenDialog(Me._USERSTRUKTURUNIT, approve_user, approve_bma, id, Me)

                        tbl_TrnAdvanceItemDetil_temps = dlg.DgvAdvanceItemDetil.DataSource
                        tbl_refOrder_temp = dlg.DgvRefOrder.DataSource

                        If retObj IsNot Nothing Then


                            retData = CType(retObj, Collection)
                            Me.tbl_Advancedetileps = CType(retData.Item("tblAdvanceEps"), DataTable)

                            Me.tbl_TrnAdvanceItemDetil = tbl_TrnAdvanceItemDetil_temps.Copy
                            Me.DgvItemBudgetDetil.DataSource = Me.tbl_TrnAdvanceItemDetil

                            Me.tbl_RefOrder = tbl_refOrder_temp.Copy

                            If tbl_refOrder_temp.Rows.Count > 0 Then
                                For t As Integer = 0 To tbl_refOrder_temp.Rows.Count - 1
                                    If tbl_refOrder_temp.Rows(t).RowState <> DataRowState.Deleted Then
                                        Me.tbl_RefOrder.Rows(t).Item("amount_advance") = tbl_refOrder_temp.Rows(t).Item("amount_advance")
                                        Me.tbl_RefOrder.Rows(t).Item("amount_sisa") = tbl_refOrder_temp.Rows(t).Item("amount_sisa")
                                    End If
                                Next
                            End If

                            Me.DgvRefOrder.DataSource = Me.tbl_RefOrder

                            'For row_index = 0 To Me.DgvTrnAdvanceDetil.Rows.Count - 1
                            total_perRow = 0
                            total_subtotal = 0

                            For row_indexDetil = 0 To Me.tbl_TrnAdvanceItemDetil.Rows.Count - 1
                                If Me.tbl_TrnAdvanceItemDetil.Rows(row_indexDetil).RowState <> DataRowState.Deleted Then
                                    If Me.tbl_TrnAdvanceItemDetil.Rows(row_indexDetil).Item("advancedetil_line") = Me.DgvTrnAdvanceDetil.Rows(Rowindex).Cells("advancedetil_line").Value Then
                                        'total_perRow += Me.tbl_TrnAdvanceItemDetil.Rows(row_indexDetil).Item("amount_idrreal")
                                        total_perRow += clsUtil.IsDbNull(Me.tbl_TrnAdvanceItemDetil.Rows(row_indexDetil).Item("amount_advance"), 0)
                                        total_subtotal += clsUtil.IsDbNull(Me.tbl_TrnAdvanceItemDetil.Rows(row_indexDetil).Item("amount_subtotal"), 0)
                                    End If
                                End If
                            Next
                           
                            If Me.DgvTrnAdvanceDetil.Rows(Rowindex).Cells("currency_id").Value = 1 Then
                                Me.DgvTrnAdvanceDetil.Rows(Rowindex).Cells("advancedetil_foreignrate").Value = clsUtil.IsDbNull(Me.tbl_TrnAdvanceItemDetil.Rows(0).Item("advancedetil_foreignrate"), 0)
                                Me.DgvTrnAdvanceDetil.Rows(Rowindex).Cells("advancedetil_foreignreal").Value = Math.Round((total_perRow), 2, MidpointRounding.AwayFromZero)
                                Me.DgvTrnAdvanceDetil.Rows(Rowindex).Cells("advancedetil_idrreal").Value = Math.Round((Me.DgvTrnAdvanceDetil.Rows(Rowindex).Cells("advancedetil_foreignrate").Value * total_perRow), 2, MidpointRounding.AwayFromZero)
                                Me.DgvTrnAdvanceDetil.Rows(Rowindex).Cells("advancedetil_subtotal").Value = Math.Round((total_subtotal), 2, MidpointRounding.AwayFromZero)

                            Else
                                Me.DgvTrnAdvanceDetil.Rows(Rowindex).Cells("advancedetil_foreignrate").Value = clsUtil.IsDbNull(Me.tbl_TrnAdvanceItemDetil.Rows(0).Item("advancedetil_foreignrate"), 0)
                                Me.DgvTrnAdvanceDetil.Rows(Rowindex).Cells("advancedetil_foreignreal").Value = Math.Round((total_perRow), 2, MidpointRounding.AwayFromZero)
                                Me.DgvTrnAdvanceDetil.Rows(Rowindex).Cells("advancedetil_idrreal").Value = Math.Round((Me.DgvTrnAdvanceDetil.Rows(Rowindex).Cells("advancedetil_foreignrate").Value * total_perRow), 2, MidpointRounding.AwayFromZero)
                                Me.DgvTrnAdvanceDetil.Rows(Rowindex).Cells("advancedetil_subtotal").Value = Math.Round((total_subtotal), 2, MidpointRounding.AwayFromZero)

                            End If
                            'Next
                        End If
                    Else
                        MsgBox("You don't have the authority to change data!!!" & vbCrLf & "Your Department is defferent")
                    End If
                End If
            End If

            'ID KOSONG
        Else
            'If clsUtil.IsDbNull(Me.DgvTrnAdvanceDetil.Rows(Rowindex).Cells("advancedetil_approvedbma").Value, False) = 1 Then
            '    MsgBox("Data has been approved" & vbCrLf & "Cannot add item")
            '    Exit Function
            'Else

            id = Me.obj_Advance_id.Text

            retObj = dlg.OpenDialog(Me._USERSTRUKTURUNIT, approve_user, approve_bma, id, Me)

            tbl_TrnAdvanceItemDetil_temps = dlg.DgvAdvanceItemDetil.DataSource

            tbl_refOrder_temp = dlg.DgvRefOrder.DataSource

            If retObj IsNot Nothing Then
                retData = CType(retObj, Collection)
                Me.tbl_Advancedetileps = CType(retData.Item("tblAdvanceEps"), DataTable)

                ''''tbl_RefOrder = CType(retData.Item("tblRefOrder2"), DataTable)

                Me.tbl_TrnAdvanceItemDetil = tbl_TrnAdvanceItemDetil_temps.Copy
                Me.DgvItemBudgetDetil.DataSource = Me.tbl_TrnAdvanceItemDetil

                Me.tbl_RefOrder = tbl_refOrder_temp.Copy

                If tbl_refOrder_temp.Rows.Count > 0 Then
                    For t As Integer = 0 To tbl_refOrder_temp.Rows.Count - 1
                        If tbl_refOrder_temp.Rows(t).RowState <> DataRowState.Deleted Then
                            Me.tbl_RefOrder.Rows(t).Item("amount_advance") = tbl_refOrder_temp.Rows(t).Item("amount_advance")
                            Me.tbl_RefOrder.Rows(t).Item("amount_sisa") = tbl_refOrder_temp.Rows(t).Item("amount_sisa")
                        End If
                    Next
                End If

                Me.DgvRefOrder.DataSource = Me.tbl_RefOrder

                ''''Me.DgvRefOrder.DataSource = tbl_RefOrder

                'For row_index = 0 To Me.DgvTrnAdvanceDetil.Rows.Count - 1
                total_perRow = 0
                total_subtotal = 0
                For row_indexDetil = 0 To Me.tbl_TrnAdvanceItemDetil.Rows.Count - 1
                    If Me.tbl_TrnAdvanceItemDetil.Rows(row_indexDetil).RowState <> DataRowState.Deleted Then
                        If Me.tbl_TrnAdvanceItemDetil.Rows(row_indexDetil).Item("advancedetil_line") = Me.DgvTrnAdvanceDetil.Rows(Rowindex).Cells("advancedetil_line").Value Then
                            'total_perRow += Me.tbl_TrnAdvanceItemDetil.Rows(row_indexDetil).Item("amount_idrreal")
                            total_perRow += clsUtil.IsDbNull(Me.tbl_TrnAdvanceItemDetil.Rows(row_indexDetil).Item("amount_advance"), 0)
                            total_subtotal += clsUtil.IsDbNull(Me.tbl_TrnAdvanceItemDetil.Rows(row_indexDetil).Item("amount_subtotal"), 0)
                        End If
                    End If
                Next
                'Me.DgvTrnAdvanceDetil.Rows(Rowindex).Cells("advancedetil_foreignreal").Value = total_perRow
                'Me.DgvTrnAdvanceDetil.Rows(Rowindex).Cells("advancedetil_idrreal").Value = Math.Round((Me.DgvTrnAdvanceDetil.Rows(Rowindex).Cells("advancedetil_foreignrate").Value * total_perRow), 2, MidpointRounding.AwayFromZero)
                'Me.DgvTrnAdvanceDetil.Rows(Rowindex).Cells("advancedetil_subtotal").Value = total_subtotal
                If Me.DgvTrnAdvanceDetil.Rows(Rowindex).Cells("currency_id").Value = 1 Then
                    Me.DgvTrnAdvanceDetil.Rows(Rowindex).Cells("advancedetil_foreignrate").Value = clsUtil.IsDbNull(Me.tbl_TrnAdvanceItemDetil.Rows(0).Item("advancedetil_foreignrate"), 0)
                    Me.DgvTrnAdvanceDetil.Rows(Rowindex).Cells("advancedetil_foreignreal").Value = Math.Round((total_perRow), 2, MidpointRounding.AwayFromZero)
                    Me.DgvTrnAdvanceDetil.Rows(Rowindex).Cells("advancedetil_idrreal").Value = Math.Round((Me.DgvTrnAdvanceDetil.Rows(Rowindex).Cells("advancedetil_foreignrate").Value * total_perRow), 2, MidpointRounding.AwayFromZero)
                    Me.DgvTrnAdvanceDetil.Rows(Rowindex).Cells("advancedetil_subtotal").Value = Math.Round((total_subtotal), 2, MidpointRounding.AwayFromZero)

                Else
                    Me.DgvTrnAdvanceDetil.Rows(Rowindex).Cells("advancedetil_foreignrate").Value = clsUtil.IsDbNull(Me.tbl_TrnAdvanceItemDetil.Rows(0).Item("advancedetil_foreignrate"), 0)
                    Me.DgvTrnAdvanceDetil.Rows(Rowindex).Cells("advancedetil_foreignreal").Value = Math.Round((total_perRow), 2, MidpointRounding.AwayFromZero)
                    Me.DgvTrnAdvanceDetil.Rows(Rowindex).Cells("advancedetil_idrreal").Value = Math.Round((Me.DgvTrnAdvanceDetil.Rows(Rowindex).Cells("advancedetil_foreignrate").Value * total_perRow), 2, MidpointRounding.AwayFromZero)
                    Me.DgvTrnAdvanceDetil.Rows(Rowindex).Cells("advancedetil_subtotal").Value = Math.Round((total_subtotal), 2, MidpointRounding.AwayFromZero)

                End If
                'Next
            End If
        End If
        'End If

        ''''uiTransaksiAdvanceRequest_TotalOutstanding()
        uiTransaksiAdvanceRequest_OutstandingBudget()
    End Function

    Private Sub DgvTrnAdvanceDetil_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DgvTrnAdvanceDetil.CellFormatting
        If Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells("status_over").Value = "OVER" Then
            'di tarik di PV walaupun data OVER
            If Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells("advancedetil_ordered").Value = 1 Then
                If Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells(e.ColumnIndex).ReadOnly = True Then
                    Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = Color.PaleVioletRed
                Else
                    Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = Color.MistyRose
                End If

                'belom di tarik di PV karna data over
            Else
                If Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells(e.ColumnIndex).ReadOnly = True Then
                    Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = Color.MistyRose
                Else
                    Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = Color.LavenderBlush
                End If
            End If

        Else
            If Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells("advancedetil_ordered").Value = 1 Then
                If Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells(e.ColumnIndex).ReadOnly = True Then
                    Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = Color.Bisque
                Else
                    Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = Color.Linen
                End If
            Else
                If Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells(e.ColumnIndex).ReadOnly = True Then
                    Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = Color.LightGray
                Else
                    Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = Color.White
                End If
            End If

        End If
    End Sub

    Private Sub DgvTrnAdvancedetil_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvTrnAdvanceDetil.CellValueChanged
        'Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        ''''Dim dbCmd As OleDb.OleDbCommand
        ''''Dim dbDA As OleDb.OleDbDataAdapter

        Dim oDataFiller As New clsDataFiller(Me.DSN)
        Dim tbl_currency As DataTable '''', tbl_budget As DataTable
        Dim tbl_exrate As DataTable
        ''''Dim tbl_budgetsum, tbl_getitemprice As DataTable
        Dim tbl_request_bma As New DataTable
        Dim exrate_currency, currency_id As Decimal '''', budget_id, budgetdetil_id As Decimal
        Dim i As Integer
        Dim amount_subtotal, amount_advance As Decimal
        Dim advancedetil_foreignrate, advancedetil_discount, pph_persen As Decimal
        Dim ppn_persen, total_idr, pph_amount, ppn_amount As Decimal
        Dim amount_approvebma As Decimal
        Dim budget_accum As Decimal
        Dim amount_budget As Decimal
        Dim jumlah_over As Integer
        Dim outstanding As Decimal
        Dim amount_intercompany As Decimal
        Dim tbl_amount_order As New DataTable
        Dim amount_order As Decimal

        Dim amount_subtotalforeign As Decimal
        Dim total_foreign As Decimal
        Dim pph_amountforeign, ppn_amountforeign As Decimal

        Select Case e.ColumnIndex
            Case Me.DgvTrnAdvanceDetil.Columns("currency_id").Index
                tbl_currency = New DataTable
                tbl_exrate = New DataTable

                tbl_currency.Clear()
                currency_id = Me.obj_Advance_currency.SelectedValue
                oDataFiller.DataFill(tbl_currency, "ms_MstCurrency_Select", String.Format("currency_id = {0}", currency_id))

                tbl_exrate.Clear()
                exrate_currency = Me.obj_Advance_currency.SelectedValue
                If exrate_currency <> 0 Then
                    oDataFiller.DataFill(tbl_exrate, "pr_MstXRate_Select", String.Format("exrate_currency = '{0}'", tbl_currency.Rows(0).Item("currency_shortname")))
                End If
                Try
                    If tbl_exrate.Rows.Count > 0 Then
                        Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells("advancedetil_foreignrate").Value = tbl_exrate.Rows(0)("exrate_mid")
                    Else
                        Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells("advancedetil_foreignrate").Value = 0
                    End If
                Catch ex As Exception
                End Try

                Try
                    For i = 0 To Me.DgvItemBudgetDetil.Rows.Count - 1
                        jumlah_over = 0
                        If Me.DgvItemBudgetDetil.Rows(i).Cells("advancedetil_line").Value = Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells("advancedetil_line").Value Then
                            amount_approvebma = clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(i).Cells("amount_approvebma").Value, 0)
                            budget_accum = clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(i).Cells("budget_accum").Value, 0)
                            amount_budget = clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(i).Cells("amount_budget").Value, 0)

                            amount_advance = Math.Round(clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(i).Cells("amount_advance").Value, 0), 2, MidpointRounding.AwayFromZero)
                            ''''CDec(String.Format("{0:#,##0.00}", (CDec(clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(i).Cells("amount_advance").Value, 0)))))
                            ''''Math.Round(clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(i).Cells("amount_advance").Value, 0), 2)
                            advancedetil_foreignrate = clsUtil.IsDbNull(Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells("advancedetil_foreignrate").Value, 0)

                            'advancedetil_discount = Math.Round(clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(i).Cells("advancedetil_discount").Value, 0), 2, MidpointRounding.AwayFromZero)

                            If Mid(Me.DgvRefOrder.Rows(i).Cells("order_id").Value, 1, 2) = "RO" Then
                                advancedetil_discount = Math.Round(clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(i).Cells("advancedetil_discount").Value, 0), 2, MidpointRounding.AwayFromZero)
                            Else
                                If Me.DgvItemBudgetDetil.Rows(i).Cells("advancedetil_discount").Value = Me.DgvRefOrder.Rows(i).Cells("orderdetil_discount").Value * Me.DgvRefOrder.Rows(i).Cells("orderdetil_qty").Value Then
                                    advancedetil_discount = Math.Round(clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(i).Cells("advancedetil_discount").Value, 0), 2, MidpointRounding.AwayFromZero)
                                Else
                                    advancedetil_discount = Math.Round((Math.Round(clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(i).Cells("advancedetil_discount").Value, 0), 2) * Me.DgvRefOrder.Rows(i).Cells("orderdetil_qty").Value), 2, MidpointRounding.AwayFromZero) 'Math.Round((clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(b).Cells("advancedetil_discount").Value, 0) * Me.DgvRefOrder.Rows(b).Cells("orderdetil_qty").Value), 2, MidpointRounding.AwayFromZero)
                                End If
                            End If

                            ''''CDec(String.Format("{0:#,##0.00}", (CDec(clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(i).Cells("advancedetil_discount").Value, 0)))))
                            ''''Math.Round(clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(i).Cells("advancedetil_discount").Value, 0), 2)
                            pph_persen = clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(i).Cells("pph_persen").Value, 0)
                            ppn_persen = clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(i).Cells("ppn_persen").Value, 0)
                            amount_intercompany = Math.Round(clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(i).Cells("amount_intercompany").Value, 0), 2, MidpointRounding.AwayFromZero)
                            ''''CDec(String.Format("{0:#,##0.00}", (CDec(clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(i).Cells("amount_intercompany").Value, 0)))))
                            ''''Math.Round(clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(i).Cells("amount_intercompany").Value, 0), 2)

                            total_idr = Math.Round((((amount_advance * advancedetil_foreignrate) + (amount_intercompany * advancedetil_foreignrate)) - (advancedetil_discount * advancedetil_foreignrate)), 2, MidpointRounding.AwayFromZero)
                            ''''CDec(Format((((amount_advance * advancedetil_foreignrate) + (amount_intercompany * advancedetil_foreignrate)) - (advancedetil_discount * advancedetil_foreignrate)), "#,##0"))
                            ''''Math.Round(((Math.Round((amount_advance * advancedetil_foreignrate), 0) + Math.Round((amount_intercompany * advancedetil_foreignrate), 0)) - Math.Round((advancedetil_discount * advancedetil_foreignrate), 0)), 2, MidpointRounding.AwayFromZero)
                            ''''Math.Round(((amount_advance * advancedetil_foreignrate) - (advancedetil_discount * advancedetil_foreignrate)), 2, MidpointRounding.AwayFromZero)
                            pph_amount = Math.Round((((amount_advance - advancedetil_discount) * (pph_persen / 100)) * advancedetil_foreignrate), 2, MidpointRounding.AwayFromZero)
                            ppn_amount = Math.Round((((amount_advance - advancedetil_discount) * (ppn_persen / 100)) * advancedetil_foreignrate), 2, MidpointRounding.AwayFromZero)

                            Dim accum_advanceinter As Decimal
                            accum_advanceinter = (amount_advance + amount_intercompany)

                            pph_amount = Math.Round((((accum_advanceinter - advancedetil_discount) * (pph_persen / 100)) * advancedetil_foreignrate), 2, MidpointRounding.AwayFromZero)
                            ppn_amount = Math.Round((((accum_advanceinter - advancedetil_discount) * (ppn_persen / 100)) * advancedetil_foreignrate), 2, MidpointRounding.AwayFromZero)

                            Me.DgvItemBudgetDetil.Rows(i).Cells("amount_idrreal").Value = Math.Round((amount_advance * advancedetil_foreignrate), 2, MidpointRounding.AwayFromZero)
                            Me.DgvItemBudgetDetil.Rows(i).Cells("amount_subtotal").Value = Math.Round(((Me.DgvItemBudgetDetil.Rows(i).Cells("amount_idrreal").Value - (advancedetil_discount * advancedetil_foreignrate)) - pph_amount + ppn_amount), 2, MidpointRounding.AwayFromZero)

                            total_foreign = Math.Round((((amount_advance) + (amount_intercompany)) - (advancedetil_discount)), 2, MidpointRounding.AwayFromZero)
                            pph_amountforeign = Math.Round((((accum_advanceinter - advancedetil_discount) * (pph_persen / 100))), 2, MidpointRounding.AwayFromZero)
                            ppn_amountforeign = Math.Round((((accum_advanceinter - advancedetil_discount) * (ppn_persen / 100))), 2, MidpointRounding.AwayFromZero)

                            'If Me.DgvItemBudgetDetil.Rows(i).Cells("currency_id").Value = 1 Then
                            '    Me.DgvItemBudgetDetil.Rows(i).Cells("amount_subtotalforeign").Value = Math.Round((total_foreign - pph_amountforeign + ppn_amountforeign), 2, MidpointRounding.AwayFromZero)
                            'Else
                            Me.DgvItemBudgetDetil.Rows(i).Cells("amount_subtotalforeign").Value = Math.Round((total_foreign - pph_amountforeign + ppn_amountforeign), 2, MidpointRounding.AwayFromZero)
                            'End If


                            Try

                                amount_order = Me.DgvItemBudgetDetil.Rows(i).Cells("amount_sum").Value
                            Catch ex As Exception
                            End Try
                            ''''8273
                            amount_subtotal += Math.Round(clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(i).Cells("amount_subtotal").Value, 0), 2, MidpointRounding.AwayFromZero)
                            'If Me.DgvItemBudgetDetil.Rows(i).Cells("currency_id").Value = 1 Then
                            '    amount_subtotalforeign += Math.Round(clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(i).Cells("amount_subtotalforeign").Value, 0), 2, MidpointRounding.AwayFromZero)
                            'Else
                            amount_subtotalforeign += Math.Round(clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(i).Cells("amount_subtotalforeign").Value, 0), 2, MidpointRounding.AwayFromZero)
                            'End If


                            Me.DgvItemBudgetDetil.Rows(i).Cells("outstanding_budget").Value = 0 ''''amount_budget - amount_approvebma - amount_order + budget_accum

                            outstanding = Me.DgvItemBudgetDetil.Rows(i).Cells("outstanding_budget").Value

                            If clsUtil.IsDbNull(Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells("advancedetil_approvedbma").Value, False) = 1 Then
                                Me.DgvItemBudgetDetil.Rows(i).Cells("outstanding_approved").Value = Me.tbl_TrnAdvanceItemDetil.Rows(i).Item("outstanding_approved")
                                Me.DgvItemBudgetDetil.Rows(i).Cells("outstanding_check").Value = True
                            Else
                                Me.DgvItemBudgetDetil.Rows(i).Cells("outstanding_approved").Value = outstanding ''''Me.DgvItemBudgetDetil.Rows(h).Cells("outstanding_budget").Value
                                Me.DgvItemBudgetDetil.Rows(i).Cells("outstanding_check").Value = False
                            End If

                            If Me.DgvItemBudgetDetil.Rows(i).Cells("outstanding_approved").Value < 0 Then
                                jumlah_over = jumlah_over + 1
                            End If
                        End If
                    Next
                Catch ex As Exception
                End Try

                If jumlah_over > 0 Then
                    Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells("status_over").Value = "OVER"
                Else
                    Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells("status_over").Value = "OK"
                End If

                Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells("advancedetil_idrreal").Value = Math.Round((clsUtil.IsDbNull(Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells("advancedetil_foreignreal").Value, 0) * clsUtil.IsDbNull(Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells("advancedetil_foreignrate").Value, 0)), 2, MidpointRounding.AwayFromZero)
                Me.DgvTrnAdvanceDetil.Rows(e.RowIndex).Cells("advancedetil_subtotal").Value = Math.Round(amount_subtotal, 2, MidpointRounding.AwayFromZero)

            Case Me.DgvTrnAdvanceDetil.Columns("advancedetil_foreignreal").Index

        End Select
    End Sub

    Private Sub obj_Request_currency_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles obj_Advance_currency.SelectionChangeCommitted
        Dim rowIndex, k As Integer
        Dim substract As Integer
        Dim tbl_currency As DataTable
        Dim tbl_exrate As DataTable

        If Me.DgvTrnAdvanceDetil.AllowUserToAddRows Then
            substract = 2
        Else
            substract = 1
        End If

        tbl_currency = New DataTable
        tbl_exrate = New DataTable

        tbl_currency.Clear()
        Me.DataFill(tbl_currency, "ms_MstCurrency_Select", String.Format("currency_id = {0}", Me.obj_Advance_currency.SelectedValue))

        tbl_exrate.Clear()
        If Me.obj_Advance_currency.SelectedValue <> 0 Then
            Me.DataFill(tbl_exrate, "pr_MstXRate_Select", String.Format("exrate_currency = '{0}'", tbl_currency.Rows(0).Item("currency_shortname")))
        End If
        Try
            If tbl_exrate.Rows.Count > 0 Then
                Me.obj_Advance_foreignrate.Text = tbl_exrate.Rows(0)("exrate_mid")
                Try
                    For rowIndex = 0 To Me.DgvTrnAdvanceDetil.Rows.Count - substract
                        If Me.DgvTrnAdvanceDetil.Rows(rowIndex).Cells("advancedetil_type").Value = 1 Then
                            Me.DgvTrnAdvanceDetil.Rows(rowIndex).Cells("currency_id").Value = Me.obj_Advance_currency.SelectedValue
                            Me.DgvTrnAdvanceDetil.Rows(rowIndex).Cells("advancedetil_foreignrate").Value = tbl_exrate.Rows(0)("exrate_mid")
                        End If
                    Next
                Catch ex As Exception
                End Try

                Try
                    For k = 0 To Me.DgvItemBudgetDetil.Rows.Count - 1
                        If Me.DgvItemBudgetDetil.Rows(k).Cells("advancedetil_type").Value = 1 Then
                            Me.DgvItemBudgetDetil.Rows(k).Cells("currency_id").Value = Me.obj_Advance_currency.SelectedValue
                            Me.DgvItemBudgetDetil.Rows(k).Cells("advancedetil_foreignrate").Value = tbl_exrate.Rows(0)("exrate_mid")
                        End If
                    Next
                Catch ex As Exception
                End Try
            Else
                Me.obj_Advance_foreignrate.Text = 0
                Try
                    For rowIndex = 0 To Me.DgvTrnAdvanceDetil.Rows.Count - substract
                        If Me.DgvTrnAdvanceDetil.Rows(rowIndex).Cells("advancedetil_type").Value = 1 Then
                            Me.DgvTrnAdvanceDetil.Rows(rowIndex).Cells("currency_id").Value = Me.obj_Advance_currency.SelectedValue
                            Me.DgvTrnAdvanceDetil.Rows(rowIndex).Cells("advancedetil_foreignrate").Value = 0
                        End If
                    Next
                Catch ex As Exception
                End Try

                Try
                    For k = 0 To Me.DgvItemBudgetDetil.Rows.Count - 1
                        If Me.DgvItemBudgetDetil.Rows(k).Cells("advancedetil_type").Value = 1 Then
                            Me.DgvItemBudgetDetil.Rows(k).Cells("currency_id").Value = Me.obj_Advance_currency.SelectedValue
                            Me.DgvItemBudgetDetil.Rows(k).Cells("advancedetil_foreignrate").Value = 0
                        End If
                    Next
                Catch ex As Exception
                End Try
            End If
        Catch ex As Exception
        End Try


    End Sub

    Private Sub obj_Request_prepareloc_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles obj_Advance_prepareloc.TextChanged
        Me.obj_Request_usedloc.Text = Me.obj_Advance_prepareloc.Text
    End Sub

    Private Sub obj_Request_preparedt_Changed(ByVal sender As Object, ByVal e As System.EventArgs) Handles obj_Advance_preparedt_time.TextChanged
        If Me.isTimeValidating = False Then
            Me.obj_Request_preparedt.Text = Me.obj_advance_prepare_dt.Value & " " & Me.obj_Advance_preparedt_time.Text
        End If
    End Sub

    Private Sub obj_Request_useddt_Changed(ByVal sender As Object, ByVal e As System.EventArgs) Handles obj_Request_useddt_time.TextChanged, obj_Request_useddt_date.ValueChanged
        If Me.isTimeValidating = False Then
            Me.obj_Request_useddt.Text = Me.obj_Request_useddt_date.Value & " " & Me.obj_Request_useddt_time.Text
        End If
    End Sub

    Private Sub obj_Request_useddt2_Changed(ByVal sender As Object, ByVal e As System.EventArgs) Handles obj_Request_useddt2_time.TextChanged, obj_Request_useddt2_date.ValueChanged
        If Me.isTimeValidating = False Then
            Me.obj_Request_useddt2.Text = Me.obj_Request_useddt2_date.Value & " " & Me.obj_Request_useddt2_time.Text
        End If
    End Sub

    Private Sub obj_Request_time_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles obj_Request_useddt_time.Validating, obj_Request_useddt2_time.Validating, obj_Advance_preparedt_time.Validating
        Dim time As MaskedTextBox = sender
        Dim hour As String

        If Trim(time.Text) = ":" Or time.Text.Length < 5 Or CInt(clsUtil.IsEmptyText(Trim(Split(time.Text, ":")(0)), 25)) >= 24 Then
            If time.Text.Length < 5 Then
                time.Text = "00:00"
            ElseIf CInt(clsUtil.IsEmptyText(Trim(Split(time.Text, ":")(0)), 25)) >= 24 Then
                hour = CInt(clsUtil.IsEmptyText(Trim(Split(time.Text, ":")(0)), 0)) Mod 24
                If hour.Length < 2 Then
                    hour = "0" & hour
                End If
                time.Text = hour & ":" & clsUtil.IsEmptyText(Trim(Split(time.Text, ":")(1)), 0)
            End If
        End If
    End Sub

    Private Sub DgvTrnAdvancedetil_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DgvTrnAdvanceDetil.MouseUp
        Me.CopyRowToolStripMenuItem.Visible = True
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim hit As DataGridView.HitTestInfo = Me.DgvTrnAdvanceDetil.HitTest(e.X, e.Y)

            If hit.Type = Windows.Forms.DataGrid.HitTestType.Cell Then
                Me.DgvTrnAdvanceDetil.CurrentCell = Me.DgvTrnAdvanceDetil.Rows(hit.RowIndex).Cells(hit.ColumnIndex)
            End If
        End If
    End Sub

    Private Sub cmdAddItemManual_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddItemManual.Click
        uiTransaksiAdvanceRequest_DataItem()
    End Sub

    Private Sub uiTransaksiAdvanceRequest_DataItem()
        Dim l, i As Integer
        Dim line As Integer
        Dim tbl_currency, tbl_exrate As DataTable

        Try
            Me.tbl_TrnAdvanceDetil.Rows.Add()
            Me.tbl_TrnAdvanceDetil.Rows(Me.tbl_TrnAdvanceDetil.Rows.Count - 1).Item("advancedetil_type") = 1
            Me.tbl_TrnAdvanceDetil.Rows(Me.tbl_TrnAdvanceDetil.Rows.Count - 1).Item("advancedetil_line") = Me.tbl_TrnAdvanceDetil.Rows(Me.tbl_TrnAdvanceDetil.Rows.Count - 1).Item("advancedetil_line") '+ 10

            line = Me.tbl_TrnAdvanceDetil.Rows(Me.tbl_TrnAdvanceDetil.Rows.Count - 1).Item("advancedetil_line")

            If Me.DgvTrnAdvanceDetil.Rows.Count > 0 Then
                For l = 0 To Me.DgvTrnAdvanceDetil.Rows.Count - 1
                    If Me.DgvTrnAdvanceDetil.Rows(l).Cells("advancedetil_line").Value = line Then
                        Me.DgvTrnAdvanceDetil.Rows(l).Cells("currency_id").Value = Me.obj_Advance_currency.SelectedValue
                        Me.DgvTrnAdvanceDetil.Rows(l).Cells("advancedetil_approvedbmadt").Value = DBNull.Value
                        Me.DgvTrnAdvanceDetil.Rows(l).Cells("advancedetil_approvedbma").Value = 0
                        Me.DgvTrnAdvanceDetil.Rows(l).Cells("advancedetil_paymentdt").Value = Format(Now(), "dd/MM/yyyy")
                        Me.DgvTrnAdvanceDetil.Rows(l).Cells("advancedetil_paymenttype").Value = Me.obj_payment_type.SelectedValue

                        Try
                            tbl_currency = New DataTable
                            Me.DataFill(tbl_currency, "ms_MstCurrency_Select", String.Format("currency_id = {0}", Me.obj_Advance_currency.SelectedValue))

                            tbl_exrate = New DataTable
                            If Me.obj_Advance_currency.SelectedValue <> 0 Then
                                Me.DataFill(tbl_exrate, "pr_MstXRate_Select", String.Format("exrate_currency = '{0}'", tbl_currency.Rows(0).Item("currency_shortname")))
                            End If
                            Try
                                If tbl_exrate.Rows.Count > 0 Then
                                    Me.DgvTrnAdvanceDetil.Rows(l).Cells("advancedetil_foreignrate").Value = tbl_exrate.Rows(0)("exrate_mid")
                                Else
                                    Me.DgvTrnAdvanceDetil.Rows(l).Cells("advancedetil_foreignrate").Value = 0
                                End If
                            Catch ex As Exception
                            End Try

                            Me.DgvTrnAdvanceDetil.Rows(l).Cells("status_over").Value = "OK"
                        Catch ex As Exception
                        End Try
                    End If
                Next
            End If

            'tambahan baru 01/06/2009
            For i = 0 To Me.tbl_TrnAdvanceDetil.Rows.Count - 1
                If Me._USERSTRUKTURUNIT = Department.BMA Then
                    If Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_type").Value = 0 Then
                        Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_foreignreal").ReadOnly = True
                        Me.DgvTrnAdvanceDetil.Rows(i).Cells("currency_id").ReadOnly = True
                        Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_line").ReadOnly = True
                        Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_approvedbma").ReadOnly = True
                        Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_approveddescr").ReadOnly = True
                        Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_descr").ReadOnly = False
                        Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_paymentdt").ReadOnly = True
                        Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_paymenttype").ReadOnly = True

                    Else
                        Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_foreignreal").ReadOnly = True
                        Me.DgvTrnAdvanceDetil.Rows(i).Cells("currency_id").ReadOnly = True
                        Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_line").ReadOnly = True
                        Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_approvedbma").ReadOnly = True
                        Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_approveddescr").ReadOnly = False
                        Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_descr").ReadOnly = False
                        Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_paymentdt").ReadOnly = False
                        Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_paymenttype").ReadOnly = False
                    End If

                Else
                    If Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_type").Value = 0 Then
                        Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_foreignreal").ReadOnly = True
                        Me.DgvTrnAdvanceDetil.Rows(i).Cells("currency_id").ReadOnly = True
                        Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_line").ReadOnly = True
                        Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_approvedbma").ReadOnly = True
                        Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_approveddescr").ReadOnly = True
                        Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_descr").ReadOnly = False
                        Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_paymentdt").ReadOnly = True
                        Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_paymenttype").ReadOnly = True

                    Else
                        Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_foreignreal").ReadOnly = True
                        Me.DgvTrnAdvanceDetil.Rows(i).Cells("currency_id").ReadOnly = True
                        Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_line").ReadOnly = True
                        Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_approvedbma").ReadOnly = True
                        Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_approveddescr").ReadOnly = True
                        Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_descr").ReadOnly = False
                        Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_paymentdt").ReadOnly = False
                        Me.DgvTrnAdvanceDetil.Rows(i).Cells("advancedetil_paymenttype").ReadOnly = False
                    End If

                End If

            Next

            Me.addManual = True
            Me.addManual = False
        Catch ex As Exception
        End Try
    End Sub

    Private Sub uiTransaksiAdvanceRequest_UpdateAfterCanceled()
        Dim query As String = String.Empty

        Try
            Me.uiTransaksiAdvanceRequest_OpenRow(Me.DgvTrnAdvance.CurrentRow.Index)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub DgvTrnAdvancedetil_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles DgvTrnAdvanceDetil.UserDeletingRow
        Dim obj As DataGridView = sender
        ''''Dim selisih, jumlah As Decimal

        If e.Row.Index < 0 Then Exit Sub

        '=======================================================================================
        Dim advanceDetil_lineH As String = DgvTrnAdvanceDetil.Item("advancedetil_line", DgvTrnAdvanceDetil.CurrentCell.RowIndex).Value
        Dim advanceDetil_lineD As String = String.Empty

        ''''If clsUtil.IsDbNull(e.Row.Cells("ref_id").Value, "") <> "" Then
        ''''    e.Cancel = True
        ''''End If
        Dim jml As Integer = 0
        For i As Integer = 0 To DgvTrnAdvanceDetil.Rows.Count - 1
            If DgvTrnAdvanceDetil.Item("advancedetil_line", i).Value = advanceDetil_lineH Then
                jml = jml + 1
            End If
        Next

        If jml = 1 Then
ulang:
            For i As Integer = 0 To DgvItemBudgetDetil.Rows.Count - 1
                advanceDetil_lineD = DgvItemBudgetDetil.Item("advancedetil_line", i).Value
                If advanceDetil_lineH = advanceDetil_lineD Then
                    DgvItemBudgetDetil.Rows.RemoveAt(i)
                    GoTo ulang
                End If
            Next
        End If
        '====================================================================================
    End Sub

    Private Function uiTransaksiAdvanceRequest_GetRequestStatus() As Boolean
        'Dim oDataFiller As New clsDataFiller(Me.DSN)
        Dim tbl_apprproc As DataTable
        Dim tbl_apprbma As DataTable
        Dim i, var As Integer

        Try
            var = Me.DgvTrnAdvance.Rows.Count - 1
            For i = 0 To var
                tbl_apprproc = New DataTable
                tbl_apprbma = New DataTable
                Me.DgvTrnAdvance.Rows(i).Cells("advance_approvedproc").Value = tbl_apprproc.Rows.Count
                Me.DgvTrnAdvance.Rows(i).Cells("advance_approvedbma").Value = tbl_apprbma.Rows.Count
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Private Sub obj_attach_open_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles obj_attach_open.Click
        Dim Proc As New System.Diagnostics.Process

        Try
            Proc.StartInfo.FileName = Me.obj_Advance_pathfile.Text 'Me.tbl_TrnRequest_Temp.Rows(0).Item("advance_pathfile")
            Proc.Start()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, mUiName)
        End Try
    End Sub

    Private Sub obj_Request_useddt_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles obj_Request_useddt.TextChanged
        If Me._PROGRAMTYPE = "NP" Then
            Me.obj_Request_preparedt.Text = Me.obj_Request_useddt.Text
        End If
    End Sub

    Private Function uiTransaksiAdvanceRequest_saveOutStanding_Approved(ByVal advance_id As String, _
        ByVal advancedetil_line As Integer, ByVal row_index As Integer, _
        ByRef dbconn As OleDb.OleDbConnection, ByRef dbTrans As OleDb.OleDbTransaction) As Boolean

        System.Windows.Forms.Cursor.Current = Cursors.WaitCursor
        Dim row_count As Integer
        Dim outstanding_approved As Decimal
        Dim budgetdetil_line As Integer
        row_count = Me.DgvTrnAdvanceDetil.Rows.Count

        If Me.DgvTrnAdvanceDetil.Rows(row_index).Cells("advancedetil_approvedbma").Value = 0 Then
            Dim c As Integer

            For c = 0 To Me.DgvItemBudgetDetil.Rows.Count - 1
                If Me.DgvItemBudgetDetil.Rows(c).Cells("advancedetil_line").Value = advancedetil_line Then
                    outstanding_approved = 0
                    budgetdetil_line = Me.DgvItemBudgetDetil.Rows(c).Cells("budgetdetil_line").Value

                    If Me.uiTransaksiAdvanceRequest_saveApprovedOutStanding(advance_id, advancedetil_line, budgetdetil_line, _
                    outstanding_approved, _
                    Me.DgvTrnAdvanceDetil.Rows(row_index).Cells("advancedetil_approvedbma").Value, _
                    row_index, _
                    Me.DgvTrnAdvanceDetil.Rows(row_index).Cells("advancedetil_approvedbmaby").Value, _
                    Me.DgvTrnAdvanceDetil.Rows(row_index).Cells("advancedetil_approveddescr").Value, dbconn, dbTrans) = False Then
                        Return False
                    End If
                End If
            Next

        ElseIf Me.DgvTrnAdvanceDetil.Rows(row_index).Cells("advancedetil_approvedbma").Value = 1 Then
            Dim x As Integer

            For x = 0 To Me.DgvItemBudgetDetil.Rows.Count - 1
                If Me.DgvItemBudgetDetil.Rows(x).Cells("advancedetil_line").Value = advancedetil_line Then
                    outstanding_approved = Me.DgvItemBudgetDetil.Rows(x).Cells("outstanding_approved").Value
                    budgetdetil_line = Me.DgvItemBudgetDetil.Rows(x).Cells("budgetdetil_line").Value

                    If Me.uiTransaksiAdvanceRequest_saveApprovedOutStanding(advance_id, advancedetil_line, budgetdetil_line, _
                    outstanding_approved, _
                    Me.DgvTrnAdvanceDetil.Rows(row_index).Cells("advancedetil_approvedbma").Value, _
                    row_index, _
                    Me.DgvTrnAdvanceDetil.Rows(row_index).Cells("advancedetil_approvedbmaby").Value, _
                    clsUtil.IsDbNull(Me.DgvTrnAdvanceDetil.Rows(row_index).Cells("advancedetil_approveddescr").Value, String.Empty), dbconn, dbTrans) = False Then
                        Return False
                    End If
                End If
            Next
        End If

        If Me.DgvItemBudgetDetil.Rows.Count <= 0 Then
            outstanding_approved = 0
            budgetdetil_line = 0

            If Me.uiTransaksiAdvanceRequest_saveApprovedOutStanding(advance_id, advancedetil_line, budgetdetil_line, _
            outstanding_approved, _
            Me.DgvTrnAdvanceDetil.Rows(row_index).Cells("advancedetil_approvedbma").Value, _
            row_index, _
            Me.DgvTrnAdvanceDetil.Rows(row_index).Cells("advancedetil_approvedbmaby").Value, _
            clsUtil.IsDbNull(Me.DgvTrnAdvanceDetil.Rows(row_index).Cells("advancedetil_approveddescr").Value, String.Empty), dbconn, dbTrans) = False Then
                Return False
            End If
        End If

        'MsgBox("Item has been saved")
        Me.uiTransaksiAdvanceRequest_OpenRowMaster(dbconn, dbTrans, advance_id)
        Me.uiTransaksiAdvanceRequest_OpenRowDetil(dbconn, dbTrans, advance_id)
        'Me.uiTransaksiAdvanceRequest_OpenRowDetilEps(dbconn, dbTrans, advance_id)
        Me.uiTransaksiAdvanceRequest_OpenRowItemDetil(dbconn, dbTrans, advance_id)
        Me.uiTransaksiAdvanceRequest_OpenRowRefPv(dbconn, dbTrans, advance_id)
        Me.uiTransaksiAdvanceRequest_TotalOutstanding()
        Me.uiTransaksiAdvanceRequest_Lock(dbconn, dbTrans, advance_id)
        Return True
        System.Windows.Forms.Cursor.Current = Cursors.Default
    End Function

    Private Function uiTransaksiAdvanceRequest_saveApprovedOutStanding(ByVal advance_id As String, _
        ByVal advancedetil_line As Integer, ByVal budgetdetil_line As Integer, ByVal outstanding_approved As Decimal, ByVal advancedetil_approvedbma As Boolean, _
        ByVal row_index As Integer, ByVal advancedetil_approvedbmaby As String, _
        ByVal advancedetil_approveddescr As String, _
        ByRef dbconn As OleDb.OleDbConnection, ByRef dbtrans As OleDb.OleDbTransaction) As Boolean

        Try
            ''''dbConn.Open()
            Dim oCm As New OleDb.OleDbCommand("vq_TrnAdvancedetil_Update_OutstandingApp", dbconn, dbtrans)
            oCm.CommandType = CommandType.StoredProcedure
            oCm.Parameters.Add("@advance_id", System.Data.OleDb.OleDbType.VarWChar, 30).Value = advance_id
            oCm.Parameters.Add("@advancedetil_line", System.Data.OleDb.OleDbType.Integer, 4).Value = advancedetil_line
            oCm.Parameters.Add("@budgetdetil_line", System.Data.OleDb.OleDbType.Integer, 4).Value = budgetdetil_line
            oCm.Parameters.Add("@outstanding_approved", System.Data.OleDb.OleDbType.Decimal, 9).Value = outstanding_approved
            oCm.Parameters.Add("@advancedetil_approvedbma", System.Data.OleDb.OleDbType.TinyInt, 1).Value = advancedetil_approvedbma
            oCm.Parameters.Add("@advancedetil_approvedbmadt", System.Data.OleDb.OleDbType.DBTimeStamp, 4).Value = Me.DgvTrnAdvanceDetil.Rows(row_index).Cells("advancedetil_approvedbmadt").Value
            oCm.Parameters.Add("@advancedetil_approvedbmaby", System.Data.OleDb.OleDbType.VarWChar, 100).Value = advancedetil_approvedbmaby
            oCm.Parameters.Add("@advancedetil_approveddescr", System.Data.OleDb.OleDbType.VarWChar, 50).Value = advancedetil_approveddescr

            oCm.ExecuteNonQuery()
            oCm.Dispose()
        Catch ex As Data.OleDb.OleDbException
            MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Catch ex As Exception
            MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Finally
            ''''dbConn.Close()
        End Try

        Return True
    End Function

    Private Function uiTransaksiAdvanceRequest_saveMemo_Approved(ByVal advance_id As String, _
        ByVal advancedetil_line As Integer, ByVal row_index As Integer, _
        ByRef dbconn As OleDb.OleDbConnection, ByRef dbtrans As OleDb.OleDbTransaction) As Boolean

        System.Windows.Forms.Cursor.Current = Cursors.WaitCursor
        Dim row_count As Integer
        row_count = Me.DgvTrnAdvanceDetil.Rows.Count

        Dim j As Integer

        If Me.DgvTrnAdvanceDetil.Rows(row_index).Cells("bma_approved").Value = 0 Then

            For j = 0 To Me.DgvItemBudgetDetil.Rows.Count - 1
                If Me.DgvItemBudgetDetil.Rows(j).Cells("advancedetil_line").Value = Me.DgvTrnAdvanceDetil.Rows(row_index).Cells("advancedetil_line").Value Then
                    If Me.uiTransaksiAdvanceRequest_saveMemoApprovalItem(advance_id, advancedetil_line, _
                                clsUtil.IsDbNull(Me.DgvTrnAdvanceDetil.Rows(row_index).Cells("bma_approved").Value, 0), _
                                j, _
                                clsUtil.IsDbNull(Me.DgvTrnAdvanceDetil.Rows(row_index).Cells("bma_approvedby").Value, String.Empty), _
                                row_index, _
                                clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(j).Cells("budgetdetil_line").Value, 0), dbconn, dbtrans) = False Then
                        Return False
                    End If
                End If
            Next

            If Me.uiTransaksiAdvanceRequest_saveMemoApprovalBmaOver(advance_id, advancedetil_line, _
            clsUtil.IsDbNull(Me.DgvTrnAdvanceDetil.Rows(row_index).Cells("bma_approved").Value, 0), _
            row_index, _
            clsUtil.IsDbNull(Me.DgvTrnAdvanceDetil.Rows(row_index).Cells("bma_approvedby").Value, String.Empty), dbconn, dbtrans) = False Then
                Return False
            End If

        ElseIf Me.DgvTrnAdvanceDetil.Rows(row_index).Cells("bma_approved").Value = 1 Then

            For j = 0 To Me.DgvItemBudgetDetil.Rows.Count - 1
                If Me.DgvItemBudgetDetil.Rows(j).Cells("advancedetil_line").Value = Me.DgvTrnAdvanceDetil.Rows(row_index).Cells("advancedetil_line").Value Then
                    If Me.uiTransaksiAdvanceRequest_saveMemoApprovalItem(advance_id, advancedetil_line, _
                              clsUtil.IsDbNull(Me.DgvTrnAdvanceDetil.Rows(row_index).Cells("bma_approved").Value, 0), _
                                j, _
                                clsUtil.IsDbNull(Me.DgvTrnAdvanceDetil.Rows(row_index).Cells("bma_approvedby").Value, String.Empty), _
                                row_index, _
                                clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(j).Cells("budgetdetil_line").Value, 0), dbconn, dbtrans) = False Then
                        Return False
                    End If
                End If
            Next

            If Me.uiTransaksiAdvanceRequest_saveMemoApprovalBmaOver(advance_id, advancedetil_line, _
              clsUtil.IsDbNull(Me.DgvTrnAdvanceDetil.Rows(row_index).Cells("bma_approved").Value, 0), _
              row_index, _
              clsUtil.IsDbNull(Me.DgvTrnAdvanceDetil.Rows(row_index).Cells("bma_approvedby").Value, String.Empty), dbconn, dbtrans) = False Then
                Return False
            End If

        End If

        Return True
        System.Windows.Forms.Cursor.Current = Cursors.Default
    End Function

    Private Function uiTransaksiAdvanceRequest_saveMemo_ApprovedStatusOver(ByVal advance_id As String, _
        ByVal advancedetil_line As Integer, ByVal row_index As Integer, _
        ByRef dbconn As OleDb.OleDbConnection, ByRef dbtrans As OleDb.OleDbTransaction) As Boolean

        '''' udah
        System.Windows.Forms.Cursor.Current = Cursors.WaitCursor
        Dim row_count As Integer
        row_count = Me.DgvTrnAdvanceDetil.Rows.Count
        ''''Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)

        Dim j As Integer

        ''''Dim Message As String = "Data is OVER " & vbCrLf & " Are you sure want to save? "
        ''''Dim response As System.Windows.Forms.DialogResult

        If Me.DgvTrnAdvanceDetil.Rows(row_index).Cells("advancedetil_approvedbma").Value = 0 Then

            For j = 0 To Me.DgvItemBudgetDetil.Rows.Count - 1
                If Me.DgvItemBudgetDetil.Rows(j).Cells("advancedetil_line").Value = Me.DgvTrnAdvanceDetil.Rows(row_index).Cells("advancedetil_line").Value Then

                    If Me.uiTransaksiAdvanceRequest_saveMemoApprovalItem(advance_id, advancedetil_line, _
                                clsUtil.IsDbNull(Me.DgvTrnAdvanceDetil.Rows(row_index).Cells("bma_approved").Value, 0), _
                                j, _
                                clsUtil.IsDbNull(Me.DgvTrnAdvanceDetil.Rows(row_index).Cells("bma_approvedby").Value, String.Empty), _
                                row_index, _
                                clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(j).Cells("budgetdetil_line").Value, 0), dbconn, dbtrans) = False Then
                        Return False
                    End If
                End If
            Next

            If Me.uiTransaksiAdvanceRequest_saveMemoApprovalBmaStatusOver(advance_id, advancedetil_line, _
            clsUtil.IsDbNull(Me.DgvTrnAdvanceDetil.Rows(row_index).Cells("bma_approved").Value, 0), _
            row_index, _
            clsUtil.IsDbNull(Me.DgvTrnAdvanceDetil.Rows(row_index).Cells("bma_approvedby").Value, String.Empty), dbconn, dbtrans) = False Then
                Return False
            End If

        ElseIf Me.DgvTrnAdvanceDetil.Rows(row_index).Cells("bma_approved").Value = 1 Then

            For j = 0 To Me.DgvItemBudgetDetil.Rows.Count - 1
                If Me.DgvItemBudgetDetil.Rows(j).Cells("advancedetil_line").Value = Me.DgvTrnAdvanceDetil.Rows(row_index).Cells("advancedetil_line").Value Then

                    If Me.uiTransaksiAdvanceRequest_saveMemoApprovalItem(advance_id, advancedetil_line, _
                              clsUtil.IsDbNull(Me.DgvTrnAdvanceDetil.Rows(row_index).Cells("bma_approved").Value, 0), _
                                j, _
                                clsUtil.IsDbNull(Me.DgvTrnAdvanceDetil.Rows(row_index).Cells("bma_approvedby").Value, String.Empty), _
                                row_index, _
                                clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(j).Cells("budgetdetil_line").Value, 0), dbconn, dbtrans) = False Then
                        Return False
                    End If
                End If
            Next

            If Me.uiTransaksiAdvanceRequest_saveMemoApprovalBmaStatusOver(advance_id, advancedetil_line, _
              clsUtil.IsDbNull(Me.DgvTrnAdvanceDetil.Rows(row_index).Cells("bma_approved").Value, 0), _
              row_index, _
              clsUtil.IsDbNull(Me.DgvTrnAdvanceDetil.Rows(row_index).Cells("bma_approvedby").Value, String.Empty), dbconn, dbtrans) = False Then
                Return False
            End If

        End If

        Return True
        System.Windows.Forms.Cursor.Current = Cursors.Default
    End Function

    Private Function uiTransaksiAdvanceRequest_saveMemoApprovalItem(ByVal advance_id As String, _
        ByVal advancedetil_line As Integer, ByVal bma_approved As Boolean, _
        ByVal j As Integer, ByVal bma_approvedby As String, ByVal row_index As Integer, _
        ByVal budgetdetil_line As Integer, _
        ByRef dbconn As OleDb.OleDbConnection, ByRef dbtrans As OleDb.OleDbTransaction) As Boolean

        Dim tbl_ApprovebmaMemo As DataTable = clsDataset.CreateTblTrnApprovebmaMemoItem()

        Try

            Me.DataFill(dbconn, dbtrans, tbl_ApprovebmaMemo, "cq_TrnApprovebmaMemo_Select", String.Format("request_id = '{0}' and requestdetil_line = {1} and bma_line = {2}", advance_id, advancedetil_line, budgetdetil_line))

            If tbl_ApprovebmaMemo.Rows.Count > 0 Then

                ''''dbConn.Open()
                Dim oCm As New OleDb.OleDbCommand("cq_TrnApprovebmaMemo_Update", dbconn, dbtrans)
                oCm.CommandType = CommandType.StoredProcedure
                oCm.Parameters.Add("@request_id", System.Data.OleDb.OleDbType.VarWChar, 30).Value = advance_id
                oCm.Parameters.Add("@requestdetil_line", System.Data.OleDb.OleDbType.Integer, 4).Value = advancedetil_line
                oCm.Parameters.Add("@bma_approved", System.Data.OleDb.OleDbType.TinyInt, 1).Value = bma_approved
                oCm.Parameters.Add("@bma_approveddt", System.Data.OleDb.OleDbType.DBTimeStamp, 4).Value = Me.DgvTrnAdvanceDetil.Rows(row_index).Cells("bma_approveddt").Value
                oCm.Parameters.Add("@bma_approvedby", System.Data.OleDb.OleDbType.VarWChar, 200).Value = bma_approvedby
                oCm.Parameters.Add("@bma_memo", System.Data.OleDb.OleDbType.VarWChar, 200).Value = Me.DgvItemBudgetDetil.Rows(j).Cells("bma_memo").Value
                oCm.Parameters.Add("@budget_id", System.Data.OleDb.OleDbType.Decimal, 5).Value = Me.DgvItemBudgetDetil.Rows(j).Cells("budget_id").Value
                oCm.Parameters.Add("@budgetdetil_id", System.Data.OleDb.OleDbType.Decimal, 9).Value = Me.DgvItemBudgetDetil.Rows(j).Cells("budgetdetil_id").Value
                oCm.Parameters.Add("@bma_line", System.Data.OleDb.OleDbType.Decimal, 5).Value = Me.DgvItemBudgetDetil.Rows(j).Cells("budgetdetil_line").Value

                oCm.ExecuteNonQuery()
                oCm.Dispose()


            Else


                ''''dbConn.Open()
                Dim oCm As New OleDb.OleDbCommand("cq_TrnApprovebmaMemo_Insert", dbconn, dbtrans)
                oCm.CommandType = CommandType.StoredProcedure
                oCm.Parameters.Add("@request_id", System.Data.OleDb.OleDbType.VarWChar, 30).Value = advance_id
                oCm.Parameters.Add("@requestdetil_line", System.Data.OleDb.OleDbType.Integer, 4).Value = advancedetil_line
                oCm.Parameters.Add("@bma_approved", System.Data.OleDb.OleDbType.TinyInt, 1).Value = bma_approved
                oCm.Parameters.Add("@bma_approveddt", System.Data.OleDb.OleDbType.DBTimeStamp, 4).Value = Me.DgvTrnAdvanceDetil.Rows(row_index).Cells("bma_approveddt").Value
                oCm.Parameters.Add("@bma_approvedby", System.Data.OleDb.OleDbType.VarWChar, 200).Value = bma_approvedby
                oCm.Parameters.Add("@bma_memo", System.Data.OleDb.OleDbType.VarWChar, 200).Value = clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(j).Cells("bma_memo").Value, String.Empty)
                oCm.Parameters.Add("@budget_id", System.Data.OleDb.OleDbType.Decimal, 5).Value = Me.DgvItemBudgetDetil.Rows(j).Cells("budget_id").Value
                oCm.Parameters.Add("@budgetdetil_id", System.Data.OleDb.OleDbType.Decimal, 9).Value = Me.DgvItemBudgetDetil.Rows(j).Cells("budgetdetil_id").Value
                oCm.Parameters.Add("@bma_line", System.Data.OleDb.OleDbType.Decimal, 5).Value = Me.DgvItemBudgetDetil.Rows(j).Cells("budgetdetil_line").Value
                oCm.ExecuteNonQuery()
                oCm.Dispose()

            End If
        Catch ex As Data.OleDb.OleDbException
            MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Catch ex As Exception
            MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Finally
            ''''dbConn.Close()
        End Try

        Return True
    End Function

    Private Function uiTransaksiAdvanceRequest_saveMemoApprovalBmaOver(ByVal advance_id As String, _
        ByVal advancedetil_line As Integer, ByVal bma_approved As Boolean, _
        ByVal j As Integer, ByVal bma_approvedby As String, _
        ByRef dbconn As OleDb.OleDbConnection, ByRef dbtrans As OleDb.OleDbTransaction) As Boolean

        Dim tbl_ApprovebmaMemo As DataTable = clsDataset.CreateTblTrnAdvanceApproveBmaOver()

        Try

            Me.DataFill(dbconn, dbtrans, tbl_ApprovebmaMemo, "vq_TrnAdvanceApproveBmaOver_Select", String.Format("advance_id = '{0}' and advancedetil_line = {1}", advance_id, advancedetil_line))

            If tbl_ApprovebmaMemo.Rows.Count > 0 Then

                ''''dbConn.Open()
                Dim oCm As New OleDb.OleDbCommand("vq_TrnAdvanceApprovebmaOver_Update", dbconn, dbtrans)
                oCm.CommandType = CommandType.StoredProcedure
                oCm.Parameters.Add("@advance_id", System.Data.OleDb.OleDbType.VarWChar, 30).Value = advance_id
                oCm.Parameters.Add("@advancedetil_line", System.Data.OleDb.OleDbType.Integer, 4).Value = advancedetil_line
                oCm.Parameters.Add("@bma_approved", System.Data.OleDb.OleDbType.TinyInt, 1).Value = bma_approved
                oCm.Parameters.Add("@bma_approveddt", System.Data.OleDb.OleDbType.DBTimeStamp, 4).Value = Me.DgvTrnAdvanceDetil.Rows(j).Cells("bma_approveddt").Value
                oCm.Parameters.Add("@bma_approvedby", System.Data.OleDb.OleDbType.VarWChar, 200).Value = bma_approvedby
                oCm.Parameters.Add("@bma_memo", System.Data.OleDb.OleDbType.VarWChar, 200).Value = "" 'Me.DgvTrnAdvanceDetil.Rows(j).Cells("bma_memo").Value

                oCm.ExecuteNonQuery()
                oCm.Dispose()
            Else

                ''''dbConn.Open()
                Dim oCm As New OleDb.OleDbCommand("vq_TrnAdvanceApprovebmaOver_Insert", dbconn, dbtrans)
                oCm.CommandType = CommandType.StoredProcedure
                oCm.Parameters.Add("@advance_id", System.Data.OleDb.OleDbType.VarWChar, 30).Value = advance_id
                oCm.Parameters.Add("@advancedetil_line", System.Data.OleDb.OleDbType.Integer, 4).Value = advancedetil_line
                oCm.Parameters.Add("@bma_approved", System.Data.OleDb.OleDbType.TinyInt, 1).Value = bma_approved
                oCm.Parameters.Add("@bma_approveddt", System.Data.OleDb.OleDbType.DBTimeStamp, 4).Value = Me.DgvTrnAdvanceDetil.Rows(j).Cells("bma_approveddt").Value
                oCm.Parameters.Add("@bma_approvedby", System.Data.OleDb.OleDbType.VarWChar, 200).Value = bma_approvedby
                oCm.Parameters.Add("@bma_memo", System.Data.OleDb.OleDbType.VarWChar, 200).Value = "" 'Me.DgvTrnAdvanceDetil.Rows(j).Cells("bma_memo").Value

                oCm.ExecuteNonQuery()
                oCm.Dispose()

            End If
        Catch ex As Data.OleDb.OleDbException
            MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Catch ex As Exception
            MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Finally
            ''''dbConn.Close()
        End Try

        Return True
    End Function

    Private Function uiTransaksiAdvanceRequest_saveMemoApprovalBmaStatusOver(ByVal advance_id As String, _
        ByVal advancedetil_line As Integer, ByVal bma_approved As Boolean, _
        ByVal j As Integer, ByVal bma_approvedby As String, _
        ByRef dbconn As OleDb.OleDbConnection, ByRef dbtrans As OleDb.OleDbTransaction) As Boolean

        Dim tbl_ApprovebmaMemo As DataTable = clsDataset.CreateTblTrnAdvanceApproveBmaOver()

        Try

            Me.DataFill(dbconn, dbtrans, tbl_ApprovebmaMemo, "vq_TrnAdvanceApproveBmaOver_Select", String.Format("advance_id = '{0}' and advancedetil_line = {1}", advance_id, advancedetil_line))

            If tbl_ApprovebmaMemo.Rows.Count > 0 Then

                ''''dbConn.Open()
                Dim oCm As New OleDb.OleDbCommand("vq_TrnAdvanceApprovebmaOver_Update", dbconn, dbtrans)
                oCm.CommandType = CommandType.StoredProcedure
                oCm.Parameters.Add("@advance_id", System.Data.OleDb.OleDbType.VarWChar, 30).Value = advance_id
                oCm.Parameters.Add("@advancedetil_line", System.Data.OleDb.OleDbType.Integer, 4).Value = advancedetil_line
                oCm.Parameters.Add("@bma_approved", System.Data.OleDb.OleDbType.TinyInt, 1).Value = bma_approved
                oCm.Parameters.Add("@bma_approveddt", System.Data.OleDb.OleDbType.DBTimeStamp, 4).Value = Me.DgvTrnAdvanceDetil.Rows(j).Cells("bma_approveddt").Value
                oCm.Parameters.Add("@bma_approvedby", System.Data.OleDb.OleDbType.VarWChar, 200).Value = bma_approvedby
                oCm.Parameters.Add("@bma_memo", System.Data.OleDb.OleDbType.VarWChar, 200).Value = Me.DgvTrnAdvanceDetil.Rows(j).Cells("bma_memo").Value

                oCm.ExecuteNonQuery()
                oCm.Dispose()

            Else
                ''''dbConn.Open()
                Dim oCm As New OleDb.OleDbCommand("vq_TrnAdvanceApprovebmaOver_Insert", dbconn, dbtrans)
                oCm.CommandType = CommandType.StoredProcedure
                oCm.Parameters.Add("@advance_id", System.Data.OleDb.OleDbType.VarWChar, 30).Value = advance_id
                oCm.Parameters.Add("@advancedetil_line", System.Data.OleDb.OleDbType.Integer, 4).Value = advancedetil_line
                oCm.Parameters.Add("@bma_approved", System.Data.OleDb.OleDbType.TinyInt, 1).Value = bma_approved
                oCm.Parameters.Add("@bma_approveddt", System.Data.OleDb.OleDbType.DBTimeStamp, 4).Value = Me.DgvTrnAdvanceDetil.Rows(j).Cells("bma_approveddt").Value
                oCm.Parameters.Add("@bma_approvedby", System.Data.OleDb.OleDbType.VarWChar, 200).Value = bma_approvedby
                oCm.Parameters.Add("@bma_memo", System.Data.OleDb.OleDbType.VarWChar, 200).Value = Me.DgvTrnAdvanceDetil.Rows(j).Cells("bma_memo").Value

                oCm.ExecuteNonQuery()
                oCm.Dispose()

            End If
        Catch ex As Data.OleDb.OleDbException
            MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Catch ex As Exception
            MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Finally
            ''''dbConn.Close()
        End Try

        Return True
    End Function

    Private Sub addBudgetDetil_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles addBudgetDetil.Click
        Dim l As Integer
        Dim line As Integer
        Dim retTbl As DataTable = clsDataset.CreateTblTrnBudgetDetil()
        Dim dlg As New dlgSelectBudgetDetil(Me.DSN)
        Dim budget_id, budgetdetil_id As Integer
        Dim tbl_currency As DataTable
        Dim tbl_exrate As DataTable
        Dim amount_advance, advancedetil_foreignrate, advancedetil_discount As Decimal
        Dim total_idr, pph_amount, ppn_amount As Decimal
        Dim pph_persen, ppn_persen As Decimal
        Dim amount_intercompany As Decimal

        Dim amount_subtotalforeign As Decimal
        Dim total_foreign As Decimal
        Dim pph_amountforeign, ppn_amountforeign As Decimal

        Try
            If Me.obj_budget_id_code.Text <> 0 Then
                budget_id = Me.obj_budget_id_code.Text
                budgetdetil_id = 0 'clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("budgetdetil_id").Value, 0)
                retTbl.Clear()
                Me.Cursor = Cursors.WaitCursor
                retTbl = dlg.OpenDialog(budget_id, budgetdetil_id, Me)
                Me.Cursor = Cursors.Arrow

                If retTbl IsNot Nothing Then
                    Me.tbl_TrnAdvanceItemDetil.Rows.Add()
                    Me.tbl_TrnAdvanceItemDetil.Rows(Me.tbl_TrnAdvanceItemDetil.Rows.Count - 1).Item("budgetdetil_line") = Me.tbl_TrnAdvanceItemDetil.Rows(Me.tbl_TrnAdvanceItemDetil.Rows.Count - 1).Item("budgetdetil_line") '+ 10

                    line = Me.tbl_TrnAdvanceItemDetil.Rows(Me.tbl_TrnAdvanceItemDetil.Rows.Count - 1).Item("budgetdetil_line")

                    If Me.DgvItemBudgetDetil.Rows.Count > 0 Then
                        For l = 0 To Me.DgvItemBudgetDetil.Rows.Count - 1
                            If Me.DgvItemBudgetDetil.Rows(l).Cells("budgetdetil_line").Value = line Then
                                If retTbl.Rows.Count <> 0 Then
                                    Me.DgvItemBudgetDetil.Rows(l).Cells("budgetdetil_id").Value = retTbl.Rows(0).Item("budgetdetil_id")
                                    Me.DgvItemBudgetDetil.Rows(l).Cells("budgetdetil_name").Value = retTbl.Rows(0).Item("budgetdetil_desc")
                                    Me.DgvItemBudgetDetil.Rows(l).Cells("amount_budget").Value = retTbl.Rows(0).Item("budgetdetil_amount")
                                    Me.DgvItemBudgetDetil.Rows(l).Cells("amount_advance").Value = retTbl.Rows(0).Item("budgetdetil_amount")
                                    Me.DgvItemBudgetDetil.Rows(l).Cells("acc_id").Value = retTbl.Rows(0).Item("account")
                                    Me.DgvItemBudgetDetil.Rows(l).Cells("currency_id").Value = Me.obj_Advance_currency.SelectedValue
                                    Me.DgvItemBudgetDetil.Rows(l).Cells("budget_name").Value = Me.obj_budget_id_view.Text
                                    Me.DgvItemBudgetDetil.Rows(l).Cells("budget_id").Value = Me.obj_budget_id_code.Text
                                    Me.DgvItemBudgetDetil.Rows(l).Cells("strukturunit_id").Value = Me._USERSTRUKTURUNIT
                                    Me.DgvItemBudgetDetil.Rows(l).Cells("channel_id").Value = Me._CHANNEL

                                    Try
                                        tbl_currency = New DataTable
                                        Me.DataFill(tbl_currency, "ms_MstCurrency_Select", String.Format("currency_id = {0}", Me.obj_Advance_currency.SelectedValue))

                                        tbl_exrate = New DataTable
                                        If Me.obj_Advance_currency.SelectedValue <> 0 Then
                                            Me.DataFill(tbl_exrate, "pr_MstXRate_Select", String.Format("exrate_currency = '{0}'", tbl_currency.Rows(0).Item("currency_shortname")))
                                        End If
                                        Try
                                            If tbl_exrate.Rows.Count > 0 Then
                                                Me.DgvItemBudgetDetil.Rows(l).Cells("advancedetil_foreignrate").Value = tbl_exrate.Rows(0)("exrate_mid")
                                            Else
                                                Me.DgvItemBudgetDetil.Rows(l).Cells("advancedetil_foreignrate").Value = 0
                                            End If
                                        Catch ex As Exception
                                        End Try
                                    Catch ex As Exception
                                    End Try

                                    amount_advance = clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(l).Cells("amount_advance").Value, 0)
                                    advancedetil_foreignrate = clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(l).Cells("advancedetil_foreignrate").Value, 0)
                                    advancedetil_discount = clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(l).Cells("advancedetil_discount").Value, 0)
                                    pph_persen = clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(l).Cells("pph_persen").Value, 0)
                                    ppn_persen = clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(l).Cells("ppn_persen").Value, 0)
                                    amount_intercompany = clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(l).Cells("amount_intercompany").Value, 0)

                                    total_idr = Math.Round((((amount_advance * advancedetil_foreignrate) + (amount_intercompany * advancedetil_foreignrate)) - (advancedetil_discount * advancedetil_foreignrate)), 2, MidpointRounding.AwayFromZero) ''''Math.Round(((amount_advance * advancedetil_foreignrate) - (advancedetil_discount * advancedetil_foreignrate)), 2, MidpointRounding.AwayFromZero)
                                    pph_amount = clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(l).Cells("pph_amount").Value, 0) ''''Math.Round((Math.Round(((amount_advance - advancedetil_discount) * (pph_persen / 100)), 2, MidpointRounding.AwayFromZero) * advancedetil_foreignrate), 2, MidpointRounding.AwayFromZero) 'total_idr * (pph_persen / 100)
                                    ppn_amount = clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(l).Cells("ppn_amount").Value, 0) ''''Math.Round((Math.Round(((amount_advance - advancedetil_discount) * (ppn_persen / 100)), 2, MidpointRounding.AwayFromZero) * advancedetil_foreignrate), 2, MidpointRounding.AwayFromZero) 'total_idr * (ppn_persen / 100)


                                    'Me.DgvItemBudgetDetil.Rows(l).Cells("amount_idrreal").Value =  amount_advance * advancedetil_foreignrate
                                    Me.DgvItemBudgetDetil.Rows(l).Cells("pph_amount").Value = pph_amount
                                    Me.DgvItemBudgetDetil.Rows(l).Cells("ppn_amount").Value = ppn_amount
                                    Me.DgvItemBudgetDetil.Rows(l).Cells("amount_idrreal").Value = ((amount_advance * advancedetil_foreignrate) + (amount_intercompany * advancedetil_foreignrate)) ''''Math.Round((amount_advance * advancedetil_foreignrate), 2, MidpointRounding.AwayFromZero)

                                    Me.DgvItemBudgetDetil.Rows(l).Cells("amount_subtotal").Value = (Me.DgvItemBudgetDetil.Rows(l).Cells("amount_idrreal").Value - advancedetil_discount) - pph_amount + ppn_amount ''''Math.Round((total_idr - pph_amount + ppn_amount), 2, MidpointRounding.AwayFromZero)

                                    total_foreign = Math.Round((((amount_advance) + (amount_intercompany)) - (advancedetil_discount)), 2, MidpointRounding.AwayFromZero)
                                    'pph_amountforeign = Math.Round((Math.Round(((amount_advance - advancedetil_discount) * (pph_persen / 100)), 2, MidpointRounding.AwayFromZero)), 2, MidpointRounding.AwayFromZero) 'total_idr * (pph_persen / 100)
                                    'ppn_amountforeign = Math.Round((Math.Round(((amount_advance - advancedetil_discount) * (ppn_persen / 100)), 2, MidpointRounding.AwayFromZero)), 2, MidpointRounding.AwayFromZero) 'total_idr * (ppn_persen / 100)
                                    pph_amountforeign = ((amount_advance - advancedetil_discount) * (pph_persen / 100)) 'total_idr * (pph_persen / 100)
                                    ppn_amountforeign = ((amount_advance - advancedetil_discount) * (ppn_persen / 100)) 'total_idr * (ppn_persen / 100)

                                    'If Me.DgvItemBudgetDetil.Rows(l).Cells("currency_id").Value = 1 Then
                                    '    amount_subtotalforeign = Math.Round((total_foreign - pph_amountforeign + ppn_amountforeign), 2, MidpointRounding.AwayFromZero)
                                    'Else
                                    amount_subtotalforeign = Math.Round((total_foreign - pph_amountforeign + ppn_amountforeign), 2, MidpointRounding.AwayFromZero)
                                    'End If

                                    Me.DgvItemBudgetDetil.Rows(l).Cells("amount_subtotalforeign").Value = amount_subtotalforeign

                                    ''''Me.DgvItemBudgetDetil.Rows(l).Cells("amount_subtotal").Value = Me.DgvItemBudgetDetil.Rows(l).Cells("amount_idrreal").Value ''''Math.Round((total_idr - pph_amount + ppn_amount), 2, MidpointRounding.AwayFromZero)

                                End If
                            End If
                        Next
                    End If
                Else
                    Exit Sub
                End If
            Else
                Dim ErrorMessage As String = ""
                Dim ErrorFound As Boolean = False

                Try
                    If Me.obj_budget_id_code.Text = 0 Then
                        ErrorMessage = "Budget name cannot be empty"
                        Me.objFormError.SetError(Me.obj_budget_id_view, ErrorMessage)
                        Throw New Exception(ErrorMessage)
                    Else
                        Me.objFormError.SetError(Me.obj_budget_id_view, "")
                    End If
                Catch ex As Exception
                End Try
                'tambahan baru 01/06/2009
            End If
        Catch ex As Exception
        End Try

        Dim a As Integer
        Dim amount As Decimal
        Dim amount_foreignreal As Decimal

        For a = 0 To Me.DgvItemBudgetDetil.Rows.Count - 1
            'amount += clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(a).Cells("amount_idrreal").Value, 0)
            amount += clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(a).Cells("amount_subtotal").Value, 0)
            amount_foreignreal += clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(a).Cells("amount_advance").Value, 0)
        Next

        Me.obj_amount.Text = Format(amount, "#,##0.00")
        Me.obj_foreignreal.Text = Format(amount_foreignreal, "#,##0.00")
    End Sub

    Private Sub DgvItemBudgetDetil_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvItemBudgetDetil.CellClick
        If e.RowIndex >= 0 Then
            Select Case e.ColumnIndex
                Case Me.DgvItemBudgetDetil.Columns("select_budget_detil").Index
                    If Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("advancedetil_type").Value = 1 And Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("select_budget_detil").ReadOnly = False Then
                        Dim retTbl As DataTable = clsDataset.CreateTblTrnBudgetDetil()
                        Dim dlg As New dlgSelectBudgetDetil(Me.DSN)
                        Dim budget_id, budgetdetil_id As Integer

                        budget_id = clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("budget_id").Value, 0)
                        budgetdetil_id = clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("budgetdetil_id").Value, 0)
                        retTbl.Clear()
                        Me.Cursor = Cursors.WaitCursor
                        retTbl = dlg.OpenDialog(budget_id, budgetdetil_id, Me)
                        Me.Cursor = Cursors.Arrow

                        If retTbl IsNot Nothing Then
                            If retTbl.Rows.Count <> 0 Then
                                Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("budgetdetil_id").Value = retTbl.Rows(0).Item("budgetdetil_id")
                                Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("budgetdetil_name").Value = retTbl.Rows(0).Item("budgetdetil_desc")
                                Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("amount_budget").Value = retTbl.Rows(0).Item("budgetdetil_amount")
                                Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("acc_id").Value = retTbl.Rows(0).Item("account")
                            End If
                        End If

                        Dim a As Integer
                        Dim amount As Decimal

                        For a = 0 To Me.DgvItemBudgetDetil.Rows.Count - 1
                            amount += Me.DgvItemBudgetDetil.Rows(a).Cells("amount_subtotal").Value
                        Next

                        Me.obj_amount.Text = Format(amount, "#,##0.00")

                        '''''Else
                        '''''    If Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("advancedetil_ordered").Value = 0 And Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("advancedetil_approvedbma").Value = 0 And Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("advancedetil_approvedproc").Value = 0 Then

                        '''''        Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("select_budget_detil").ReadOnly = False

                        '''''        '''Dim retTbl As DataTable = clsDataset.CreateTblTrnBudgetDetil()
                        '''''        '''Dim dlg As New dlgSelectBudgetDetil(Me.DSN)
                        '''''        Dim budget_id, budgetdetil_id As Decimal

                        '''''        budget_id = clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("budget_id").Value, 0)
                        '''''        budgetdetil_id = clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("budgetdetil_id").Value, 0)
                        '''''        '''retTbl.Clear()
                        '''''        Me.Cursor = Cursors.WaitCursor
                        '''''        '''retTbl = dlg.OpenDialog(budget_id, budgetdetil_id, Me)
                        '''''        Me.Cursor = Cursors.Arrow

                        '''''        '''If retTbl IsNot Nothing Then
                        '''''        '''    If retTbl.Rows.Count <> 0 Then
                        '''''        '''        Me.Dgvitembudgetdetil.Rows(e.RowIndex).Cells("budgetdetil_id").Value = retTbl.Rows(0).Item("budgetdetil_id")
                        '''''        '''    End If
                        '''''        '''End If
                        '''''End If
                    End If

                Case Me.DgvItemBudgetDetil.Columns("select_eps").Index
                    Dim obj As SelectEpsDialogReturn
                    Dim budgetdetil_line As Integer = Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("budgetdetil_line").Value
                    Dim budget_name As String = clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("budget_name").Value, "")
                    Dim advancedetil_line As Integer = Me.DgvTrnAdvanceDetil.Rows(0).Cells("advancedetil_line").Value

                    obj = Me.dlgTrnAdvance_Open(Me.tbl_Advancedetileps, budgetdetil_line, budget_name, advancedetil_line)

                    If obj IsNot Nothing Then
                        Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("budgetdetil_eps").Value = "Eps. " & obj.budgetdetil_eps
                    End If

                    Me.DgvEps.DataSource = Me.tbl_Advancedetileps
                    Me.tbl_Advancedetileps.DefaultView.RowFilter = "checked=1"
                    Me.tbl_Advancedetileps.DefaultView.Sort = "budgetdetil_line"

            End Select
        End If
    End Sub

    Private Function dlgTrnAdvance_Open(ByRef tbl_Advancedetileps As DataTable, ByRef budgetdetil_line As Integer, ByRef budget_name As String, ByRef advancedetil_line As Integer) As SelectEpsDialogReturn
        Dim frmSelectEps As dlgTrnAdvance_SelectEps = New dlgTrnAdvance_SelectEps()
        Dim obj As SelectEpsDialogReturn
        Dim epsstart As Integer
        Dim epsend As Integer

        frmSelectEps.ShowInTaskbar = False
        frmSelectEps.StartPosition = FormStartPosition.CenterParent
        frmSelectEps.FormBorderStyle = FormBorderStyle.FixedDialog
        frmSelectEps.MinimizeBox = False
        frmSelectEps.MaximizeBox = False

        If Me.tbl_TrnAdvance_Temp.Rows.Count > 0 Then
            epsstart = Me.tbl_TrnAdvance_Temp.Rows(0).Item("advance_epsstart")
            epsend = Me.tbl_TrnAdvance_Temp.Rows(0).Item("advance_epsend")
        Else
            epsstart = Me.obj_Advance_epsstart.Text
            epsend = Me.obj_Advance_epsend.Text
        End If

        obj = frmSelectEps.OpenDialog(Me.tbl_Advancedetileps, epsstart, epsend, budgetdetil_line, budget_name, advancedetil_line, Me)
        If obj IsNot Nothing Then
            Me.obj_Advance_epsstart.Text = obj.epsstart
            Me.obj_Advance_epsend.Text = obj.epsend
        End If

        Dim tblChanges As DataTable = Me.tbl_Advancedetileps.GetChanges()
        If tblChanges IsNot Nothing Then
        End If

        Return obj

    End Function

    Private Sub DgvItemBudgetDetil_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DgvItemBudgetDetil.CellFormatting
        If Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("outstanding_approved").Value < 0 Then
            If Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells(e.ColumnIndex).ReadOnly = True Then
                Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = Color.MistyRose
            Else
                Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = Color.LavenderBlush
            End If
        Else
            If Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells(e.ColumnIndex).ReadOnly = True Then
                Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = Color.Gainsboro
            End If
        End If
    End Sub

    Private Sub DgvItemBudgetDetil_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvItemBudgetDetil.CellValueChanged
        Dim amount, amount_foreignreal As Decimal
        Dim a As Integer
        Dim amount_advance, advancedetil_foreignrate As Decimal
        Dim total_idr, advancedetil_discount As Decimal
        Dim pph_persen, ppn_persen, pph_amount, ppn_amount As Decimal
        Dim amount_budget, budget_accum, amount_approvebma As Decimal
        Dim amount_intercompany As Decimal
        Dim tbl_amount_order As New DataTable
        Dim amount_order As Decimal
        Dim oDataFiller As New clsDataFiller(Me.DSN)

        Dim amount_subtotalforeign As Decimal
        Dim total_foreign As Decimal
        Dim pph_amountforeign, ppn_amountforeign As Decimal

        Select Case e.ColumnIndex
            Case Me.DgvItemBudgetDetil.Columns("amount_advance").Index
                uiTransaksiAdvanceRequest_OutstandingBudget()

                amount_advance = Math.Round(clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("amount_advance").Value, 0), 2, MidpointRounding.AwayFromZero)
                ''''CDec(String.Format("{0:#,##0.00}", (CDec(clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("amount_advance").Value, 0)))))
                ''''Math.Round(clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("amount_advance").Value, 0), 2)
                advancedetil_foreignrate = clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("advancedetil_foreignrate").Value, 0)
                pph_persen = clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("pph_persen").Value, 0)
                ppn_persen = clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("ppn_persen").Value, 0)
                advancedetil_discount = Math.Round(clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("advancedetil_discount").Value, 0), 2, MidpointRounding.AwayFromZero)
                ''''CDec(String.Format("{0:#,##0.00}", (CDec(clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("advancedetil_discount").Value, 0)))))
                ''''Math.Round(clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("advancedetil_discount").Value, 0), 2)
                amount_budget = clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("amount_budget").Value, 0)
                amount_approvebma = clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("amount_approvebma").Value, 0)
                budget_accum = clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("budget_accum").Value, 0)
                amount_intercompany = Math.Round(clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("amount_intercompany").Value, 0), 2, MidpointRounding.AwayFromZero)
                ''''CDec(String.Format("{0:#,##0.00}", (CDec(clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("amount_intercompany").Value, 0)))))
                ''''Math.Round(clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("amount_intercompany").Value, 0), 2)

                total_idr = Math.Round((((amount_advance * advancedetil_foreignrate) + (amount_intercompany * advancedetil_foreignrate)) - (advancedetil_discount * advancedetil_foreignrate)), 2, MidpointRounding.AwayFromZero)
                ''''CDec(Format((((amount_advance * advancedetil_foreignrate) + (amount_intercompany * advancedetil_foreignrate)) - (advancedetil_discount * advancedetil_foreignrate)), "#,##0"))
                ''''Math.Round(((Math.Round((amount_advance * advancedetil_foreignrate), 0) + Math.Round((amount_intercompany * advancedetil_foreignrate), 0)) - Math.Round((advancedetil_discount * advancedetil_foreignrate), 0)), 2, MidpointRounding.AwayFromZero)
                ''''Math.Round(((amount_advance * advancedetil_foreignrate) - (advancedetil_discount * advancedetil_foreignrate)), 2, MidpointRounding.AwayFromZero)
                'pph_amount = Math.Round((((amount_advance - advancedetil_discount) * (pph_persen / 100)) * advancedetil_foreignrate), 2, MidpointRounding.AwayFromZero)
                'ppn_amount = Math.Round((((amount_advance - advancedetil_discount) * (ppn_persen / 100)) * advancedetil_foreignrate), 2, MidpointRounding.AwayFromZero)

                Dim accum_advanceinter As Decimal
                accum_advanceinter = (amount_advance + amount_intercompany)

                pph_amount = Math.Round((((accum_advanceinter - advancedetil_discount) * (pph_persen / 100)) * advancedetil_foreignrate), 2, MidpointRounding.AwayFromZero)
                ppn_amount = Math.Round((((accum_advanceinter - advancedetil_discount) * (ppn_persen / 100)) * advancedetil_foreignrate), 2, MidpointRounding.AwayFromZero)



                total_foreign = Math.Round((((amount_advance) + (amount_intercompany)) - (advancedetil_discount)), 2, MidpointRounding.AwayFromZero)
                ''''CDec(Format((((amount_advance) + (amount_intercompany)) - (advancedetil_discount)), "#,##0.00"))
                ''''Math.Round((((amount_advance) + (amount_intercompany)) - (advancedetil_discount)), 2, MidpointRounding.AwayFromZero)
                ''''Math.Round(((amount_advance * advancedetil_foreignrate) - (advancedetil_discount * advancedetil_foreignrate)), 2, MidpointRounding.AwayFromZero)
                'pph_amountforeign = Math.Round((((amount_advance - advancedetil_discount) * (pph_persen / 100))), 2, MidpointRounding.AwayFromZero)
                'ppn_amountforeign = Math.Round((((amount_advance - advancedetil_discount) * (ppn_persen / 100))), 2, MidpointRounding.AwayFromZero)

                pph_amountforeign = Math.Round((((accum_advanceinter - advancedetil_discount) * (pph_persen / 100))), 2, MidpointRounding.AwayFromZero)
                ppn_amountforeign = Math.Round((((accum_advanceinter - advancedetil_discount) * (ppn_persen / 100))), 2, MidpointRounding.AwayFromZero)

                Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("pph_amount").Value = pph_amount
                Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("ppn_amount").Value = ppn_amount
                Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("amount_idrreal").Value = ((amount_advance * advancedetil_foreignrate) + (amount_intercompany * advancedetil_foreignrate)) ''''Math.Round((amount_advance * advancedetil_foreignrate), 2, MidpointRounding.AwayFromZero)
                ''''CDec(Format((amount_advance * advancedetil_foreignrate), "#,##0"))
                ''''Math.Round((amount_advance * advancedetil_foreignrate), 2, MidpointRounding.AwayFromZero)

                Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("amount_subtotal").Value = Math.Round(((Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("amount_idrreal").Value - (advancedetil_discount * advancedetil_foreignrate)) - pph_amount + ppn_amount), 2, MidpointRounding.AwayFromZero)
                ''''CDec(Format(((Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("amount_idrreal").Value - Format((advancedetil_discount * advancedetil_foreignrate), "#,##0")) - pph_amount + ppn_amount), "#,##0"))
                ''''Math.Round(((Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("amount_idrreal").Value - Math.Round((advancedetil_discount * advancedetil_foreignrate), 0)) - pph_amount + ppn_amount), 0)
                ''''Math.Round((total_idr - pph_amount + ppn_amount), 2, MidpointRounding.AwayFromZero)

                'If Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("currency_id").Value = 1 Then
                '    amount_subtotalforeign = Math.Round((total_foreign - pph_amountforeign + ppn_amountforeign), 2, MidpointRounding.AwayFromZero)
                'Else
                amount_subtotalforeign = Math.Round((total_foreign - pph_amountforeign + ppn_amountforeign), 2, MidpointRounding.AwayFromZero)
                'End If

                ''''CDec(Format((total_foreign - pph_amountforeign + ppn_amountforeign), "#,##0.00"))
                ''''Math.Round((total_foreign - pph_amountforeign + ppn_amountforeign), 2, MidpointRounding.AwayFromZero)
                Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("amount_subtotalforeign").Value = amount_subtotalforeign

                ''''Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("amount_subtotal").Value = Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("amount_idrreal").Value ''''Math.Round((total_idr - pph_amount + ppn_amount), 2, MidpointRounding.AwayFromZero)

                Try
                    '' ''tbl_amount_order.Clear()

                    '' ''oDataFiller.DataFillAmountAdvance(tbl_amount_order, "pr_TrnOrderdetil_AmtSum", clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("budget_id").Value, 0), clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("budgetdetil_id").Value, 0))
                    '' ''If tbl_amount_order.Rows.Count > 0 Then
                    '' ''    amount_order = clsUtil.IsDbNull(tbl_amount_order.Rows(0)("amount_sum"), 0)
                    '' ''Else
                    '' ''    amount_order = clsUtil.IsDbNull(tbl_amount_order.Columns("amount_sum").DefaultValue, 0)
                    '' ''End If

                    amount_order = Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("amount_sum").Value

                Catch ex As Exception
                End Try


                'Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("outstanding_budget").Value = amount_budget - amount_approvebma - clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("amount_subtotal").Value, 0) + budget_accum
                Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("outstanding_budget").Value = 0 '''' amount_budget - amount_approvebma - amount_order + budget_accum
                Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("outstanding_approved").Value = Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("outstanding_budget").Value

                For a = 0 To Me.DgvItemBudgetDetil.Rows.Count - 1
                    'amount += clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(a).Cells("amount_idrreal").Value, 0)
                    amount += Math.Round(clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(a).Cells("amount_subtotal").Value, 0), 2, MidpointRounding.AwayFromZero)
                    ''''CDec(String.Format("{0:#,##0.00}", (CDec(clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(a).Cells("amount_subtotal").Value, 0)))))
                    ''''Math.Round(clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(a).Cells("amount_subtotal").Value, 0), 0)
                    amount_foreignreal += Math.Round(clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(a).Cells("amount_advance").Value, 0), 2, MidpointRounding.AwayFromZero)
                    ''''CDec(String.Format("{0:#,##0.00}", (CDec(clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(a).Cells("amount_advance").Value, 0)))))
                    ''''Math.Round(clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(a).Cells("amount_advance").Value, 0), 2)
                Next
                Me.obj_amount.Text = Format(amount, "#,##0.00")
                Me.obj_foreignreal.Text = Format(amount_foreignreal, "#,##0.00")

            Case Me.DgvItemBudgetDetil.Columns("currency_id").Index
                'Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("amount_idrreal").Value = clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("amount_advance").Value, 0) * clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("advancedetil_foreignrate").Value, 0)

                Dim tbl_currency As DataTable
                Dim tbl_exrate As DataTable

                Try
                    tbl_currency = New DataTable
                    Me.DataFill(tbl_currency, "ms_MstCurrency_Select", String.Format("currency_id = {0}", Me.obj_Advance_currency.SelectedValue))

                    tbl_exrate = New DataTable
                    If Me.obj_Advance_currency.SelectedValue <> 0 Then
                        Me.DataFill(tbl_exrate, "pr_MstXRate_Select", String.Format("exrate_currency = '{0}'", tbl_currency.Rows(0).Item("currency_shortname")))
                    End If
                    Try
                        If tbl_exrate.Rows.Count > 0 Then
                            Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("advancedetil_foreignrate").Value = tbl_exrate.Rows(0)("exrate_mid")
                        Else
                            Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("advancedetil_foreignrate").Value = 0
                        End If
                    Catch ex As Exception
                    End Try

                Catch ex As Exception
                End Try

                amount_advance = Math.Round(clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("amount_advance").Value, 0), 2, MidpointRounding.AwayFromZero)
                ''''CDec(String.Format("{0:#,##0.00}", (CDec(clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("amount_advance").Value, 0)))))
                ''''Math.Round(clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("amount_advance").Value, 0), 2)
                advancedetil_foreignrate = clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("advancedetil_foreignrate").Value, 0)
                pph_persen = clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("pph_persen").Value, 0)
                ppn_persen = clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("ppn_persen").Value, 0)
                advancedetil_discount = Math.Round(clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("advancedetil_discount").Value, 0), 2, MidpointRounding.AwayFromZero)
                ''''CDec(String.Format("{0:#,##0.00}", (CDec(clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("advancedetil_discount").Value, 0)))))
                ''''Math.Round(clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("advancedetil_discount").Value, 0), 2)
                amount_budget = clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("amount_budget").Value, 0)
                amount_approvebma = clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("amount_approvebma").Value, 0)
                budget_accum = clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("budget_accum").Value, 0)
                amount_intercompany = Math.Round(clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("amount_intercompany").Value, 0), 2, MidpointRounding.AwayFromZero)
                ''''CDec(String.Format("{0:#,##0.00}", (CDec(clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("amount_intercompany").Value, 0)))))
                ''''Math.Round(clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("amount_intercompany").Value, 0), 2)

                total_idr = Math.Round((((amount_advance * advancedetil_foreignrate) + (amount_intercompany * advancedetil_foreignrate)) - (advancedetil_discount * advancedetil_foreignrate)), 2, MidpointRounding.AwayFromZero)
                ''''CDec(Format((((amount_advance * advancedetil_foreignrate) + (amount_intercompany * advancedetil_foreignrate)) - (advancedetil_discount * advancedetil_foreignrate)), "#,##0"))
                ''''Math.Round(((Math.Round((amount_advance * advancedetil_foreignrate), 0) + Math.Round((amount_intercompany * advancedetil_foreignrate), 0)) - Math.Round((advancedetil_discount * advancedetil_foreignrate), 0)), 2, MidpointRounding.AwayFromZero)
                ''''Math.Round(((amount_advance * advancedetil_foreignrate) - (advancedetil_discount * advancedetil_foreignrate)), 2, MidpointRounding.AwayFromZero)

                'pph_amount = Math.Round(clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("pph_amount").Value, 0), 2, MidpointRounding.AwayFromZero)
                'ppn_amount = Math.Round(clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("ppn_amount").Value, 0), 2, MidpointRounding.AwayFromZero)

                pph_amount = clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("pph_amount").Value, 0)
                ppn_amount = clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("ppn_amount").Value, 0)


                Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("pph_amount").Value = pph_amount
                Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("ppn_amount").Value = ppn_amount
                Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("amount_idrreal").Value = ((amount_advance * advancedetil_foreignrate) + (amount_intercompany * advancedetil_foreignrate)) ''''Math.Round((amount_advance * advancedetil_foreignrate), 2, MidpointRounding.AwayFromZero)
                ''''CDec(Format((amount_advance * advancedetil_foreignrate), "#,##0"))
                ''''Math.Round((amount_advance * advancedetil_foreignrate), 2, MidpointRounding.AwayFromZero)

                Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("amount_subtotal").Value = Math.Round(((Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("amount_idrreal").Value - (advancedetil_discount * advancedetil_foreignrate)) - pph_amount + ppn_amount), 2, MidpointRounding.AwayFromZero)
                ''''CDec(Format(((Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("amount_idrreal").Value - Format((advancedetil_discount * advancedetil_foreignrate), "#,##0")) - pph_amount + ppn_amount), "#,##0"))
                ''''Math.Round(((Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("amount_idrreal").Value - Math.Round((advancedetil_discount * advancedetil_foreignrate), 0)) - pph_amount + ppn_amount), 0)
                ''''Math.Round((total_idr - pph_amount + ppn_amount), 2, MidpointRounding.AwayFromZero)

                total_foreign = Math.Round((((amount_advance) + (amount_intercompany)) - (advancedetil_discount)), 2, MidpointRounding.AwayFromZero)
                ''''CDec(Format((((amount_advance) + (amount_intercompany)) - (advancedetil_discount)), "#,##0.00"))
                ''''Math.Round((((amount_advance) + (amount_intercompany)) - (advancedetil_discount)), 2, MidpointRounding.AwayFromZero)
                pph_amountforeign = Math.Round((((amount_advance - advancedetil_discount) * (pph_persen / 100))), 2, MidpointRounding.AwayFromZero)
                ''''CDec(Format((((amount_advance - advancedetil_discount) * (pph_persen / 100))), "#,##0.00"))
                ''''Math.Round((Math.Round(((amount_advance - advancedetil_discount) * (pph_persen / 100)), 2, MidpointRounding.AwayFromZero)), 2, MidpointRounding.AwayFromZero)
                '(total_idr * (pph_persen / 100))
                ppn_amountforeign = Math.Round((((amount_advance - advancedetil_discount) * (ppn_persen / 100))), 2, MidpointRounding.AwayFromZero)
                ''''CDec(Format((((amount_advance - advancedetil_discount) * (ppn_persen / 100))), "#,##0.00"))
                ''''Math.Round((Math.Round(((amount_advance - advancedetil_discount) * (ppn_persen / 100)), 2, MidpointRounding.AwayFromZero)), 2, MidpointRounding.AwayFromZero)
                '(total_idr * (ppn_persen / 100))

                'If Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("currency_id").Value = 1 Then
                '    amount_subtotalforeign = Math.Round((total_foreign - pph_amountforeign + ppn_amountforeign), 2, MidpointRounding.AwayFromZero)
                'Else
                amount_subtotalforeign = Math.Round((total_foreign - pph_amountforeign + ppn_amountforeign), 2, MidpointRounding.AwayFromZero)
                'End If

                ''''CDec(Format((total_foreign - pph_amountforeign + ppn_amountforeign), "#,##0.00"))
                ''''Math.Round((total_foreign - pph_amountforeign + ppn_amountforeign), 2, MidpointRounding.AwayFromZero)
                Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("amount_subtotalforeign").Value = amount_subtotalforeign

                ''''Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("amount_subtotal").Value = Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("amount_idrreal").Value ''''Math.Round((total_idr - pph_amount + ppn_amount), 2, MidpointRounding.AwayFromZero)

                Try
                    '' ''tbl_amount_order.Clear()

                    '' ''oDataFiller.DataFillAmountAdvance(tbl_amount_order, "pr_TrnOrderdetil_AmtSum", clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("budget_id").Value, 0), clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("budgetdetil_id").Value, 0))
                    '' ''If tbl_amount_order.Rows.Count > 0 Then
                    '' ''    amount_order = clsUtil.IsDbNull(tbl_amount_order.Rows(0)("amount_sum"), 0)
                    '' ''Else
                    '' ''    amount_order = clsUtil.IsDbNull(tbl_amount_order.Columns("amount_sum").DefaultValue, 0)
                    '' ''End If

                    amount_order = Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("amount_sum").Value

                Catch ex As Exception
                End Try

                'Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("outstanding_budget").Value = amount_budget - amount_approvebma - clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("amount_subtotal").Value, 0) + budget_accum
                Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("outstanding_budget").Value = 0 ''''amount_budget - amount_approvebma - amount_order + budget_accum
                Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("outstanding_approved").Value = Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("outstanding_budget").Value
                ''''CDec(String.Format("{0:#,##0.00}", (CDec(Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("outstanding_budget").Value))))
                ''''Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("outstanding_budget").Value

                For a = 0 To Me.DgvItemBudgetDetil.Rows.Count - 1
                    'amount += clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(a).Cells("amount_idrreal").Value, 0)
                    amount += Math.Round(clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(a).Cells("amount_subtotal").Value, 0), 2, MidpointRounding.AwayFromZero)
                    ''''CDec(String.Format("{0:#,##0}", (CDec(clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(a).Cells("amount_subtotal").Value, 0)))))
                    ''''Math.Round(clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(a).Cells("amount_subtotal").Value, 0), 0)
                    amount_foreignreal += Math.Round(clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(a).Cells("amount_advance").Value, 0), 2, MidpointRounding.AwayFromZero)
                    ''''CDec(String.Format("{0:#,##0.00}", (CDec(clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(a).Cells("amount_advance").Value, 0)))))
                    ''''Math.Round(clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(a).Cells("amount_advance").Value, 0), 2)
                Next
                Me.obj_amount.Text = Format(amount, "#,##0.00")
                Me.obj_foreignreal.Text = Format(amount_foreignreal, "#,##0.00")

            Case Me.DgvItemBudgetDetil.Columns("amount_intercompany").Index
                uiTransaksiAdvanceRequest_OutstandingBudget()

                amount_advance = Math.Round(clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("amount_advance").Value, 0), 2, MidpointRounding.AwayFromZero)
                ''''CDec(String.Format("{0:#,##0.00}", (CDec(clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("amount_advance").Value, 0)))))
                ''''Math.Round(clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("amount_advance").Value, 0), 2)
                advancedetil_foreignrate = clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("advancedetil_foreignrate").Value, 0)
                pph_persen = clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("pph_persen").Value, 0)
                ppn_persen = clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("ppn_persen").Value, 0)
                advancedetil_discount = Math.Round(clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("advancedetil_discount").Value, 0), 2, MidpointRounding.AwayFromZero)
                ''''CDec(String.Format("{0:#,##0.00}", (CDec(clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("advancedetil_discount").Value, 0)))))
                ''''Math.Round(clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("advancedetil_discount").Value, 0), 2)
                amount_budget = clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("amount_budget").Value, 0)
                amount_approvebma = clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("amount_approvebma").Value, 0)
                budget_accum = clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("budget_accum").Value, 0)
                amount_intercompany = Math.Round(clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("amount_intercompany").Value, 0), 2, MidpointRounding.AwayFromZero)
                ''''CDec(String.Format("{0:#,##0.00}", (CDec(clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("amount_intercompany").Value, 0)))))
                ''''Math.Round(clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("amount_intercompany").Value, 0), 2)

                total_idr = Math.Round((((amount_advance * advancedetil_foreignrate) + (amount_intercompany * advancedetil_foreignrate)) - (advancedetil_discount * advancedetil_foreignrate)), 2, MidpointRounding.AwayFromZero)
                ''''CDec(Format((((amount_advance * advancedetil_foreignrate) + (amount_intercompany * advancedetil_foreignrate)) - (advancedetil_discount * advancedetil_foreignrate)), "#,##0"))
                ''''Math.Round(((Math.Round((amount_advance * advancedetil_foreignrate), 0) + Math.Round((amount_intercompany * advancedetil_foreignrate), 0)) - Math.Round((advancedetil_discount * advancedetil_foreignrate), 0)), 2, MidpointRounding.AwayFromZero)
                ''''Math.Round(((amount_advance * advancedetil_foreignrate) - (advancedetil_discount * advancedetil_foreignrate)), 2, MidpointRounding.AwayFromZero)
                pph_amount = Math.Round(clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("pph_amount").Value, 0), 2, MidpointRounding.AwayFromZero)
                ''''CDec(Format(clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("pph_amount").Value, 0), "#,##0"))
                ''''Math.Round(clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("pph_amount").Value, 0), 0)
                ''''Math.Round((Math.Round(((amount_advance - advancedetil_discount) * (pph_persen / 100)), 2, MidpointRounding.AwayFromZero) * advancedetil_foreignrate), 2, MidpointRounding.AwayFromZero) 
                '(total_idr * (pph_persen / 100))
                ppn_amount = Math.Round(clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("ppn_amount").Value, 0), 2, MidpointRounding.AwayFromZero)
                ''''CDec(Format(clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("ppn_amount").Value, 0), "#,##0"))
                ''''Math.Round(clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("ppn_amount").Value, 0), 0)
                ''''Math.Round((Math.Round(((amount_advance - advancedetil_discount) * (ppn_persen / 100)), 2, MidpointRounding.AwayFromZero) * advancedetil_foreignrate), 2, MidpointRounding.AwayFromZero) 
                '(total_idr * (ppn_persen / 100))

                'Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("amount_idrreal").Value = clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("amount_advance").Value, 0) * clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("advancedetil_foreignrate").Value, 0)

                Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("pph_amount").Value = pph_amount
                Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("ppn_amount").Value = ppn_amount
                Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("amount_idrreal").Value = ((amount_advance * advancedetil_foreignrate) + (amount_intercompany * advancedetil_foreignrate)) ''''Math.Round((amount_advance * advancedetil_foreignrate), 2, MidpointRounding.AwayFromZero)
                ''''CDec(Format((amount_advance * advancedetil_foreignrate), "#,##0"))
                ''''Math.Round((amount_advance * advancedetil_foreignrate), 2, MidpointRounding.AwayFromZero)

                Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("amount_subtotal").Value = Math.Round(((Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("amount_idrreal").Value - (advancedetil_discount * advancedetil_foreignrate)) - pph_amount + ppn_amount), 2, MidpointRounding.AwayFromZero)
                ''''CDec(Format(((Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("amount_idrreal").Value - Format((advancedetil_discount * advancedetil_foreignrate), "#,##0")) - pph_amount + ppn_amount), "#,##0"))
                ''''Math.Round(((Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("amount_idrreal").Value - Math.Round((advancedetil_discount * advancedetil_foreignrate), 0)) - pph_amount + ppn_amount), 0)
                ''''Math.Round((total_idr - pph_amount + ppn_amount), 2, MidpointRounding.AwayFromZero)

                ''''Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("amount_subtotal").Value = Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("amount_idrreal").Value ''''Math.Round((total_idr - pph_amount + ppn_amount), 2, MidpointRounding.AwayFromZero)

                total_foreign = Math.Round((((amount_advance) + (amount_intercompany)) - (advancedetil_discount)), 2, MidpointRounding.AwayFromZero)
                ''''CDec(Format((((amount_advance) + (amount_intercompany)) - (advancedetil_discount)), "#,##0.00"))
                ''''Math.Round((((amount_advance) + (amount_intercompany)) - (advancedetil_discount)), 2, MidpointRounding.AwayFromZero)
                pph_amountforeign = Math.Round((((amount_advance - advancedetil_discount) * (pph_persen / 100))), 2, MidpointRounding.AwayFromZero)
                ''''CDec(Format((((amount_advance - advancedetil_discount) * (pph_persen / 100))), "#,##0.00"))
                ''''Math.Round((Math.Round(((amount_advance - advancedetil_discount) * (pph_persen / 100)), 2, MidpointRounding.AwayFromZero)), 2, MidpointRounding.AwayFromZero)
                ppn_amountforeign = Math.Round((((amount_advance - advancedetil_discount) * (ppn_persen / 100))), 2, MidpointRounding.AwayFromZero)
                ''''CDec(Format((((amount_advance - advancedetil_discount) * (ppn_persen / 100))), "#,##0.00"))
                ''''Math.Round((Math.Round(((amount_advance - advancedetil_discount) * (ppn_persen / 100)), 2, MidpointRounding.AwayFromZero)), 2, MidpointRounding.AwayFromZero)

                'If Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("currency_id").Value = 1 Then
                '    amount_subtotalforeign = Math.Round((total_foreign - pph_amountforeign + ppn_amountforeign), 2, MidpointRounding.AwayFromZero)
                'Else
                amount_subtotalforeign = Math.Round((total_foreign - pph_amountforeign + ppn_amountforeign), 2, MidpointRounding.AwayFromZero)
                'End If

                ''''CDec(Format((total_foreign - pph_amountforeign + ppn_amountforeign), "#,##0.00"))
                ''''Math.Round((total_foreign - pph_amountforeign + ppn_amountforeign), 2, MidpointRounding.AwayFromZero)
                Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("amount_subtotalforeign").Value = amount_subtotalforeign

                Try
                    '' ''tbl_amount_order.Clear()

                    '' ''oDataFiller.DataFillAmountAdvance(tbl_amount_order, "pr_TrnOrderdetil_AmtSum", clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("budget_id").Value, 0), clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("budgetdetil_id").Value, 0))
                    '' ''If tbl_amount_order.Rows.Count > 0 Then
                    '' ''    amount_order = clsUtil.IsDbNull(tbl_amount_order.Rows(0)("amount_sum"), 0)
                    '' ''Else
                    '' ''    amount_order = clsUtil.IsDbNull(tbl_amount_order.Columns("amount_sum").DefaultValue, 0)
                    '' ''End If

                    amount_order = Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("amount_sum").Value

                Catch ex As Exception
                End Try

                'Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("outstanding_budget").Value = amount_budget - amount_approvebma - clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("amount_subtotal").Value, 0) + budget_accum
                Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("outstanding_budget").Value = 0 ''''amount_budget - amount_approvebma - amount_order + budget_accum
                Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("outstanding_approved").Value = Me.DgvItemBudgetDetil.Rows(e.RowIndex).Cells("outstanding_budget").Value

                For a = 0 To Me.DgvItemBudgetDetil.Rows.Count - 1
                    'amount += clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(a).Cells("amount_idrreal").Value, 0)
                    amount += Math.Round(clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(a).Cells("amount_subtotal").Value, 0), 2, MidpointRounding.AwayFromZero)
                    ''''CDec(String.Format("{0:#,##0}", (CDec(clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(a).Cells("amount_subtotal").Value, 0)))))
                    ''''Math.Round(clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(a).Cells("amount_subtotal").Value, 0), 0)
                    amount_foreignreal += Math.Round(clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(a).Cells("amount_advance").Value, 0), 2, MidpointRounding.AwayFromZero)
                    ''''CDec(String.Format("{0:#,##0.00}", (CDec(clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(a).Cells("amount_advance").Value, 0)))))
                    ''''Math.Round(clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(a).Cells("amount_advance").Value, 0), 2)
                Next
                Me.obj_amount.Text = Format(amount, "#,##0.00")
                Me.obj_foreignreal.Text = Format(amount_foreignreal, "#,##0.00")

        End Select

        ''''uiTransaksiAdvanceRequest_OutstandingBudget()
    End Sub

#Region " AddItemBudgetDetilToolStripMenuItem_Click BARU tgl 05-03-1020"
    Private Sub CopyRowToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyRowToolStripMenuItem.Click
        Dim i, j, k, c As Integer
        Dim columnName, columnName_eps As String
        Dim row, row_eps As DataRow
        Dim table_temps As DataTable = New DataTable
        Dim table_epsTemps As DataTable = New DataTable
        Dim line_temps, line_budgetTemps As Integer
        Dim amount_subtotal, amount_advance As Decimal
        Dim advancedetil_foreignrate, advancedetil_discount, pph_persen As Decimal
        Dim ppn_persen, total_idr, pph_amount, ppn_amount As Decimal
        Dim amount_approvebma As Decimal
        Dim budget_accum As Decimal
        Dim amount_budget As Decimal
        Dim jumlah_over As Integer
        Dim outstanding_budget As Decimal
        Dim amount_intercompany As Decimal

        Dim amount_subtotalforeign As Decimal
        Dim total_foreign As Decimal
        Dim pph_amountforeign, ppn_amountforeign As Decimal

        line_temps = tbl_TrnAdvanceDetil.Rows(Me.tbl_TrnAdvanceDetil.Rows.Count - 1).Item("advancedetil_line") + 10

        row = Me.tbl_TrnAdvanceDetil.NewRow
        For i = 0 To tbl_TrnAdvanceDetil.Columns.Count - 1
            columnName = tbl_TrnAdvanceDetil.Columns(i).ColumnName
            If columnName = "advancedetil_line" Then
                row.Item(columnName) = line_temps 'tbl_TrnAdvanceDetil.Rows(Me.tbl_TrnAdvanceDetil.Rows.Count - 1).Item("advancedetil_line") + 10
            Else
                row.Item(columnName) = tbl_TrnAdvanceDetil.Rows(Me.DgvTrnAdvanceDetil.CurrentRow.Index).Item(columnName)
            End If
        Next
        Me.tbl_TrnAdvanceDetil.Rows.Add(row)

        table_temps.Clear()
        table_temps = Me.tbl_TrnAdvanceItemDetil.Copy()
        table_temps.DefaultView.RowFilter = String.Format(" advancedetil_line = {0} ", Me.tbl_TrnAdvanceDetil.Rows(Me.DgvTrnAdvanceDetil.CurrentRow.Index).Item("advancedetil_line"))


        For j = 0 To table_temps.DefaultView.Count - 1
            line_budgetTemps = Me.tbl_TrnAdvanceItemDetil.Rows(Me.tbl_TrnAdvanceItemDetil.Rows.Count - 1).Item("budgetdetil_line") + 10

            row = Me.tbl_TrnAdvanceItemDetil.NewRow
            For i = 0 To table_temps.Columns.Count - 1
                columnName = table_temps.Columns(i).ColumnName
                If columnName = "advancedetil_line" Then
                    row.Item(columnName) = line_temps
                ElseIf columnName = "budgetdetil_line" Then
                    row.Item(columnName) = line_budgetTemps 'Me.tbl_TrnAdvanceItemDetil.Rows(Me.tbl_TrnAdvanceItemDetil.Rows.Count - 1).Item("budgetdetil_line") + 10
                Else
                    row.Item(columnName) = table_temps.DefaultView.Item(j).Item(columnName)
                End If
            Next
            Me.tbl_TrnAdvanceItemDetil.Rows.Add(row)

            table_epsTemps.Clear()
            table_epsTemps = Me.tbl_Advancedetileps.Copy()
            table_epsTemps.DefaultView.RowFilter = String.Format(" advancedetil_line = {0} AND budgetdetil_line = {1} ", table_temps.DefaultView.Item(j).Item("advancedetil_line"), table_temps.DefaultView.Item(j).Item("budgetdetil_line"))

            For k = 0 To table_epsTemps.DefaultView.Count - 1
                row_eps = Me.tbl_Advancedetileps.NewRow
                For i = 0 To table_epsTemps.Columns.Count - 1
                    columnName_eps = table_epsTemps.Columns(i).ColumnName
                    If columnName_eps = "budgetdetiluse_line" Then
                        row_eps.Item(columnName_eps) = Me.tbl_Advancedetileps.Rows(Me.tbl_Advancedetileps.Rows.Count - 1).Item("budgetdetiluse_line") + 10
                    ElseIf columnName_eps = "advancedetil_line" Then
                        row_eps.Item(columnName_eps) = line_temps
                    ElseIf columnName_eps = "budgetdetil_line" Then
                        row_eps.Item(columnName_eps) = line_budgetTemps
                    Else
                        row_eps.Item(columnName_eps) = table_epsTemps.DefaultView.Item(k).Item(columnName_eps)
                    End If
                Next
                Me.tbl_Advancedetileps.Rows.Add(row_eps)
            Next
        Next

        Try
            Dim g As Integer
            For g = 0 To Me.DgvTrnAdvanceDetil.Rows.Count - 1
                For c = 0 To Me.DgvItemBudgetDetil.Rows.Count - 1
                    jumlah_over = 0
                    If Me.DgvItemBudgetDetil.Rows(c).Cells("advancedetil_line").Value = Me.DgvTrnAdvanceDetil.Rows(g).Cells("advancedetil_line").Value Then
                        amount_approvebma = clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(c).Cells("amount_approvebma").Value, 0)
                        budget_accum = clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(c).Cells("budget_accum").Value, 0)
                        amount_budget = clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(c).Cells("amount_budget").Value, 0)

                        amount_advance = Math.Round(clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(c).Cells("amount_advance").Value, 0), 2, MidpointRounding.AwayFromZero)
                        ''''CDec(String.Format("{0:#,##0.00}", (CDec(clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(c).Cells("amount_advance").Value, 0)))))
                        ''''clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(c).Cells("amount_advance").Value, 0)
                        advancedetil_foreignrate = clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(c).Cells("advancedetil_foreignrate").Value, 0)
                        'advancedetil_discount = Math.Round(clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(c).Cells("advancedetil_discount").Value, 0), 2, MidpointRounding.AwayFromZero)

                        If Mid(Me.DgvRefOrder.Rows(c).Cells("order_id").Value, 1, 2) = "RO" Then
                            advancedetil_discount = Math.Round(clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(c).Cells("advancedetil_discount").Value, 0), 2, MidpointRounding.AwayFromZero)
                        Else
                            If Me.DgvItemBudgetDetil.Rows(c).Cells("advancedetil_discount").Value = Me.DgvRefOrder.Rows(c).Cells("orderdetil_discount").Value * Me.DgvRefOrder.Rows(c).Cells("orderdetil_qty").Value Then
                                advancedetil_discount = Math.Round(clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(c).Cells("advancedetil_discount").Value, 0), 2, MidpointRounding.AwayFromZero)
                            Else
                                advancedetil_discount = Math.Round((Math.Round(clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(c).Cells("advancedetil_discount").Value, 0), 2) * Me.DgvRefOrder.Rows(c).Cells("orderdetil_qty").Value), 2, MidpointRounding.AwayFromZero) 'Math.Round((clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(b).Cells("advancedetil_discount").Value, 0) * Me.DgvRefOrder.Rows(b).Cells("orderdetil_qty").Value), 2, MidpointRounding.AwayFromZero)
                            End If
                        End If

                        ''''CDec(String.Format("{0:#,##0.00}", (CDec(clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(c).Cells("advancedetil_discount").Value, 0)))))
                        ''''clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(c).Cells("advancedetil_discount").Value, 0)
                        pph_persen = clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(c).Cells("pph_persen").Value, 0)
                        ppn_persen = clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(c).Cells("ppn_persen").Value, 0)
                        amount_intercompany = Math.Round(clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(c).Cells("amount_intercompany").Value, 0), 2, MidpointRounding.AwayFromZero)
                        ''''CDec(String.Format("{0:#,##0.00}", (CDec(clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(c).Cells("amount_intercompany").Value, 0)))))
                        ''''clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(c).Cells("amount_intercompany").Value, 0)

                        total_idr = Math.Round((((amount_advance * advancedetil_foreignrate) + (amount_intercompany * advancedetil_foreignrate)) - (advancedetil_discount * advancedetil_foreignrate)), 0, MidpointRounding.AwayFromZero)
                        ''''CDec(Format((((amount_advance * advancedetil_foreignrate) + (amount_intercompany * advancedetil_foreignrate)) - (advancedetil_discount * advancedetil_foreignrate)), "#,##0"))
                        ''''Math.Round((((amount_advance * advancedetil_foreignrate) + (amount_intercompany * advancedetil_foreignrate)) - (advancedetil_discount * advancedetil_foreignrate)), 2, MidpointRounding.AwayFromZero)
                        ''''Math.Round(((amount_advance * advancedetil_foreignrate) - (advancedetil_discount * advancedetil_foreignrate)), 2, MidpointRounding.AwayFromZero)
                        'pph_amount = Math.Round((((amount_advance - advancedetil_discount) * (pph_persen / 100)) * advancedetil_foreignrate), 0, MidpointRounding.AwayFromZero)
                        'ppn_amount = Math.Round((((amount_advance - advancedetil_discount) * (ppn_persen / 100)) * advancedetil_foreignrate), 0, MidpointRounding.AwayFromZero)

                        Dim accum_advanceinter As Decimal
                        accum_advanceinter = (amount_advance + amount_intercompany)

                        pph_amount = Math.Round((((accum_advanceinter - advancedetil_discount) * (pph_persen / 100)) * advancedetil_foreignrate), 0, MidpointRounding.AwayFromZero)
                        ppn_amount = Math.Round((((accum_advanceinter - advancedetil_discount) * (ppn_persen / 100)) * advancedetil_foreignrate), 0, MidpointRounding.AwayFromZero)

                        Me.DgvItemBudgetDetil.Rows(c).Cells("amount_idrreal").Value = ((amount_advance * advancedetil_foreignrate) + (amount_intercompany * advancedetil_foreignrate)) ''''Math.Round((amount_advance * advancedetil_foreignrate), 0, MidpointRounding.AwayFromZero)
                        ''''CDec(Format((amount_advance * advancedetil_foreignrate), "#,##0"))
                        ''''Math.Round((amount_advance * advancedetil_foreignrate), 2, MidpointRounding.AwayFromZero)

                        Me.DgvItemBudgetDetil.Rows(c).Cells("amount_subtotal").Value = Math.Round(((Me.DgvItemBudgetDetil.Rows(c).Cells("amount_idrreal").Value - advancedetil_discount) - pph_amount + ppn_amount), 0, MidpointRounding.AwayFromZero)
                        ''''CDec(Format(((Me.DgvItemBudgetDetil.Rows(c).Cells("amount_idrreal").Value - advancedetil_discount) - pph_amount + ppn_amount), "#,##0"))
                        ''''(Me.DgvItemBudgetDetil.Rows(c).Cells("amount_idrreal").Value - advancedetil_discount) - pph_amount + ppn_amount
                        ''''Math.Round((total_idr - pph_amount + ppn_amount), 2, MidpointRounding.AwayFromZero)

                        total_foreign = Math.Round((((amount_advance) + (amount_intercompany)) - (advancedetil_discount)), 2, MidpointRounding.AwayFromZero)
                        ''''CDec(Format((((amount_advance) + (amount_intercompany)) - (advancedetil_discount)), "#,##0.00"))
                        ''''Math.Round((((amount_advance) + (amount_intercompany)) - (advancedetil_discount)), 2, MidpointRounding.AwayFromZero)
                        'pph_amountforeign = Math.Round((((amount_advance - advancedetil_discount) * (pph_persen / 100))), 2, MidpointRounding.AwayFromZero)
                        'ppn_amountforeign = Math.Round((((amount_advance - advancedetil_discount) * (ppn_persen / 100))), 2, MidpointRounding.AwayFromZero)

                        pph_amountforeign = Math.Round((((accum_advanceinter - advancedetil_discount) * (pph_persen / 100))), 2, MidpointRounding.AwayFromZero)
                        ppn_amountforeign = Math.Round((((accum_advanceinter - advancedetil_discount) * (ppn_persen / 100))), 2, MidpointRounding.AwayFromZero)


                        If Me.DgvItemBudgetDetil.Rows(c).Cells("currency_id").Value = 1 Then
                            amount_subtotalforeign = Math.Round((total_foreign - pph_amountforeign + ppn_amountforeign), 0, MidpointRounding.AwayFromZero)
                        Else
                            amount_subtotalforeign = Math.Round((total_foreign - pph_amountforeign + ppn_amountforeign), 2, MidpointRounding.AwayFromZero)
                        End If

                        ''''CDec(Format((total_foreign - pph_amountforeign + ppn_amountforeign), "#,##0.00"))
                        ''''Math.Round((total_foreign - pph_amountforeign + ppn_amountforeign), 2, MidpointRounding.AwayFromZero)
                        Me.DgvItemBudgetDetil.Rows(c).Cells("amount_subtotalforeign").Value = amount_subtotalforeign

                        ''''Me.DgvItemBudgetDetil.Rows(c).Cells("amount_subtotal").Value = Me.DgvItemBudgetDetil.Rows(c).Cells("amount_idrreal").Value ''''Math.Round((total_idr - pph_amount + ppn_amount), 2, MidpointRounding.AwayFromZero)

                        amount_subtotal += Math.Round(clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(c).Cells("amount_subtotal").Value, 0), 0, MidpointRounding.AwayFromZero)
                        ''''CDec(String.Format("{0:#,##0}", (CDec(clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(c).Cells("amount_subtotal").Value, 0)))))
                        ''''clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(c).Cells("amount_subtotal").Value, 0)
                        'amount_advance += clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(i).Cells("amount_advance").Value, 0)
                    End If
                Next

                '' ''If Me._SOURCE = "Reimburse Settlement" Then
                '' ''    outstanding_budget = amount_budget - amount_approvebma + budget_accum
                '' ''Else

                '''' dirubah tgl 26-08-2010
                '''' outstanding_budget = amount_budget - amount_approvebma - amount_subtotal + budget_accum

                outstanding_budget = 0

                '' ''End If

                If outstanding_budget < 0 Then
                    jumlah_over = jumlah_over + 1
                End If

                If jumlah_over > 0 Then
                    Me.DgvTrnAdvanceDetil.Rows(g).Cells("status_over").Value = "OVER"
                Else
                    Me.DgvTrnAdvanceDetil.Rows(g).Cells("status_over").Value = "OK"
                End If
            Next

        Catch ex As Exception
        End Try



    End Sub

#End Region

#Region " AddItemBudgetDetilToolStripMenuItem_Click Lama"
    'Private Sub AddItemBudgetDetilToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddItemBudgetDetilToolStripMenuItem.Click
    '    Dim tbl_TrnAdvanceItemDetils As DataTable = New DataTable
    '    tbl_TrnAdvanceItemDetils = Me.tbl_TrnAdvanceItemDetil.Copy
    '    Dim dlg As dlgTrnSelectItemChild = New dlgTrnSelectItemChild(Me.DSN, tbl_TrnAdvanceItemDetils, _
    '    Me.DgvTrnAdvanceDetil.Rows(Me.DgvTrnAdvanceDetil.CurrentRow.Index).Cells("advancedetil_line").Value, _
    '    Me.tbl_MstCurrencyDetil.Copy, Me.obj_budget_id_code.Text, Me.obj_budget_id_view.Text, Me._CHANNEL, _
    '    Me.obj_Advance_currency.SelectedValue, Me._USERSTRUKTURUNIT, Me.tbl_Advancedetileps.Copy, Me.tbl_TrnAdvance_Temp.Copy, _
    '    Me.obj_Advance_epsend.Text, Me.obj_Advance_epsstart.Text, Me.obj_Advance_id.Text, Me.DgvTrnAdvanceDetil.Rows(Me.DgvTrnAdvanceDetil.CurrentRow.Index).Cells("advancedetil_line").Value)

    '    '''Dim retObj As DataTable
    '    Dim retObj As Object
    '    Dim row_index As Integer
    '    Dim row_indexDetil As Integer
    '    Dim total_perRow As Decimal
    '    Dim retData As Collection
    '    Dim tbl_TrnAdvanceItemDetil_temps As DataTable = New DataTable

    '    If Me.obj_Advance_id.Text <> String.Empty Then
    '        If Me._USERSTRUKTURUNIT = Department.BMA Then
    '            If clsUtil.IsDbNull(Me.DgvTrnAdvanceDetil.Rows(Me.DgvTrnAdvanceDetil.CurrentRow.Index).Cells("advancedetil_approvedbma").Value, False) = 1 Then
    '                MsgBox("Data has been approved by BMA" & vbCrLf & "Cannot add item")
    '            Else
    '                retObj = dlg.OpenDialog(Me)

    '                tbl_TrnAdvanceItemDetil_temps = dlg.DgvAdvanceItemDetil.DataSource
    '                If retObj IsNot Nothing Then
    '                    '''Me.tbl_TrnAdvanceItemDetil.Clear()
    '                    retData = CType(retObj, Collection)
    '                    '''tbl_TrnAdvanceItemDetil_temps = CType(retData.Item("tblAdvanceItemDetil"), DataTable)
    '                    Me.tbl_Advancedetileps = CType(retData.Item("tblAdvanceEps"), DataTable)

    '                    Me.tbl_TrnAdvanceItemDetil = tbl_TrnAdvanceItemDetil_temps.Copy
    '                    Me.DgvItemBudgetDetil.DataSource = Me.tbl_TrnAdvanceItemDetil

    '                    For row_index = 0 To Me.DgvTrnAdvanceDetil.Rows.Count - 1
    '                        total_perRow = 0
    '                        For row_indexDetil = 0 To Me.tbl_TrnAdvanceItemDetil.Rows.Count - 1
    '                            If Me.tbl_TrnAdvanceItemDetil.Rows(row_indexDetil).RowState <> DataRowState.Deleted Then
    '                                If Me.tbl_TrnAdvanceItemDetil.Rows(row_indexDetil).Item("advancedetil_line") = Me.DgvTrnAdvanceDetil.Rows(row_index).Cells("advancedetil_line").Value Then
    '                                    total_perRow += Me.tbl_TrnAdvanceItemDetil.Rows(row_indexDetil).Item("amount_advance")
    '                                End If
    '                            End If
    '                            Me.DgvTrnAdvanceDetil.Rows(row_index).Cells("advancedetil_foreignreal").Value = total_perRow
    '                        Next
    '                    Next
    '                End If
    '            End If

    '            'selain BMA
    '        Else
    '            If clsUtil.IsDbNull(Me.DgvTrnAdvance.Rows(Me.DgvTrnAdvance.CurrentRow.Index).Cells("advance_approved1").Value, False) = 1 Then
    '                MsgBox("Data has been approved by SPV" & vbCrLf & "Cannot add item")
    '            Else
    '                retObj = dlg.OpenDialog(Me)

    '                tbl_TrnAdvanceItemDetil_temps = dlg.DgvAdvanceItemDetil.DataSource
    '                If retObj IsNot Nothing Then
    '                    '''Me.tbl_TrnAdvanceItemDetil.Clear()
    '                    retData = CType(retObj, Collection)
    '                    '''tbl_TrnAdvanceItemDetil_temps = CType(retData.Item("tblAdvanceItemDetil"), DataTable)
    '                    Me.tbl_Advancedetileps = CType(retData.Item("tblAdvanceEps"), DataTable)

    '                    Me.tbl_TrnAdvanceItemDetil = tbl_TrnAdvanceItemDetil_temps.Copy
    '                    Me.DgvItemBudgetDetil.DataSource = Me.tbl_TrnAdvanceItemDetil

    '                    For row_index = 0 To Me.DgvTrnAdvanceDetil.Rows.Count - 1
    '                        total_perRow = 0
    '                        For row_indexDetil = 0 To Me.tbl_TrnAdvanceItemDetil.Rows.Count - 1
    '                            If Me.tbl_TrnAdvanceItemDetil.Rows(row_indexDetil).RowState <> DataRowState.Deleted Then
    '                                If Me.tbl_TrnAdvanceItemDetil.Rows(row_indexDetil).Item("advancedetil_line") = Me.DgvTrnAdvanceDetil.Rows(row_index).Cells("advancedetil_line").Value Then
    '                                    total_perRow += Me.tbl_TrnAdvanceItemDetil.Rows(row_indexDetil).Item("amount_advance")
    '                                End If
    '                            End If
    '                            Me.DgvTrnAdvanceDetil.Rows(row_index).Cells("advancedetil_foreignreal").Value = total_perRow
    '                        Next
    '                    Next
    '                End If
    '            End If
    '        End If

    '        'ID KOSONG
    '    Else
    '        If clsUtil.IsDbNull(Me.DgvTrnAdvanceDetil.Rows(Me.DgvTrnAdvanceDetil.CurrentRow.Index).Cells("advancedetil_approvedbma").Value, False) = 1 Then
    '            MsgBox("Data has been approved" & vbCrLf & "Cannot add item")
    '        Else
    '            retObj = dlg.OpenDialog(Me)

    '            tbl_TrnAdvanceItemDetil_temps = dlg.DgvAdvanceItemDetil.DataSource
    '            If retObj IsNot Nothing Then
    '                '''Me.tbl_TrnAdvanceItemDetil.Clear()
    '                retData = CType(retObj, Collection)
    '                '''tbl_TrnAdvanceItemDetil_temps = CType(retData.Item("tblAdvanceItemDetil"), DataTable)
    '                Me.tbl_Advancedetileps = CType(retData.Item("tblAdvanceEps"), DataTable)

    '                Me.tbl_TrnAdvanceItemDetil = tbl_TrnAdvanceItemDetil_temps.Copy
    '                Me.DgvItemBudgetDetil.DataSource = Me.tbl_TrnAdvanceItemDetil

    '                For row_index = 0 To Me.DgvTrnAdvanceDetil.Rows.Count - 1
    '                    total_perRow = 0
    '                    For row_indexDetil = 0 To Me.tbl_TrnAdvanceItemDetil.Rows.Count - 1
    '                        If Me.tbl_TrnAdvanceItemDetil.Rows(row_indexDetil).RowState <> DataRowState.Deleted Then
    '                            If Me.tbl_TrnAdvanceItemDetil.Rows(row_indexDetil).Item("advancedetil_line") = Me.DgvTrnAdvanceDetil.Rows(row_index).Cells("advancedetil_line").Value Then
    '                                total_perRow += Me.tbl_TrnAdvanceItemDetil.Rows(row_indexDetil).Item("amount_advance")
    '                            End If
    '                        End If
    '                        Me.DgvTrnAdvanceDetil.Rows(row_index).Cells("advancedetil_foreignreal").Value = total_perRow
    '                    Next
    '                Next
    '            End If
    '        End If
    '    End If

    '    ' yang awal
    '    ''''If Me.obj_Advance_id.Text <> String.Empty Then
    '    ''''    If clsUtil.IsDbNull(Me.DgvTrnAdvanceDetil.Rows(Me.DgvTrnAdvanceDetil.CurrentRow.Index).Cells("advancedetil_approvedbma").Value, False) = 1 Or clsUtil.IsDbNull(Me.DgvTrnAdvance.Rows(Me.DgvTrnAdvance.CurrentRow.Index).Cells("advance_approved1").Value, False) = 1 Then
    '    ''''        MsgBox("Data has been approved" & vbCrLf & "Cannot add item")
    '    ''''    Else
    '    ''''        retObj = dlg.OpenDialog(Me)

    '    ''''        tbl_TrnAdvanceItemDetil_temps = dlg.DgvAdvanceItemDetil.DataSource
    '    ''''        If retObj IsNot Nothing Then
    '    ''''            '''Me.tbl_TrnAdvanceItemDetil.Clear()
    '    ''''            retData = CType(retObj, Collection)
    '    ''''            '''tbl_TrnAdvanceItemDetil_temps = CType(retData.Item("tblAdvanceItemDetil"), DataTable)
    '    ''''            Me.tbl_Advancedetileps = CType(retData.Item("tblAdvanceEps"), DataTable)

    '    ''''            Me.tbl_TrnAdvanceItemDetil = tbl_TrnAdvanceItemDetil_temps.Copy
    '    ''''            Me.DgvItemBudgetDetil.DataSource = Me.tbl_TrnAdvanceItemDetil

    '    ''''            For row_index = 0 To Me.DgvTrnAdvanceDetil.Rows.Count - 1
    '    ''''                total_perRow = 0
    '    ''''                For row_indexDetil = 0 To Me.tbl_TrnAdvanceItemDetil.Rows.Count - 1
    '    ''''                    If Me.tbl_TrnAdvanceItemDetil.Rows(row_indexDetil).RowState <> DataRowState.Deleted Then
    '    ''''                        If Me.tbl_TrnAdvanceItemDetil.Rows(row_indexDetil).Item("advancedetil_line") = Me.DgvTrnAdvanceDetil.Rows(row_index).Cells("advancedetil_line").Value Then
    '    ''''                            total_perRow += Me.tbl_TrnAdvanceItemDetil.Rows(row_indexDetil).Item("amount_advance")
    '    ''''                        End If
    '    ''''                    End If
    '    ''''                    Me.DgvTrnAdvanceDetil.Rows(row_index).Cells("advancedetil_foreignreal").Value = total_perRow
    '    ''''                Next
    '    ''''            Next
    '    ''''        End If
    '    ''''    End If
    '    ''''Else
    '    ''''    If clsUtil.IsDbNull(Me.DgvTrnAdvanceDetil.Rows(Me.DgvTrnAdvanceDetil.CurrentRow.Index).Cells("advancedetil_approvedbma").Value, False) = 1 Then
    '    ''''        MsgBox("Data has been approved" & vbCrLf & "Cannot add item")
    '    ''''    Else
    '    ''''        retObj = dlg.OpenDialog(Me)

    '    ''''        tbl_TrnAdvanceItemDetil_temps = dlg.DgvAdvanceItemDetil.DataSource
    '    ''''        If retObj IsNot Nothing Then
    '    ''''            '''Me.tbl_TrnAdvanceItemDetil.Clear()
    '    ''''            retData = CType(retObj, Collection)
    '    ''''            '''tbl_TrnAdvanceItemDetil_temps = CType(retData.Item("tblAdvanceItemDetil"), DataTable)
    '    ''''            Me.tbl_Advancedetileps = CType(retData.Item("tblAdvanceEps"), DataTable)

    '    ''''            Me.tbl_TrnAdvanceItemDetil = tbl_TrnAdvanceItemDetil_temps.Copy
    '    ''''            Me.DgvItemBudgetDetil.DataSource = Me.tbl_TrnAdvanceItemDetil

    '    ''''            For row_index = 0 To Me.DgvTrnAdvanceDetil.Rows.Count - 1
    '    ''''                total_perRow = 0
    '    ''''                For row_indexDetil = 0 To Me.tbl_TrnAdvanceItemDetil.Rows.Count - 1
    '    ''''                    If Me.tbl_TrnAdvanceItemDetil.Rows(row_indexDetil).RowState <> DataRowState.Deleted Then
    '    ''''                        If Me.tbl_TrnAdvanceItemDetil.Rows(row_indexDetil).Item("advancedetil_line") = Me.DgvTrnAdvanceDetil.Rows(row_index).Cells("advancedetil_line").Value Then
    '    ''''                            total_perRow += Me.tbl_TrnAdvanceItemDetil.Rows(row_indexDetil).Item("amount_advance")
    '    ''''                        End If
    '    ''''                    End If
    '    ''''                    Me.DgvTrnAdvanceDetil.Rows(row_index).Cells("advancedetil_foreignreal").Value = total_perRow
    '    ''''                Next
    '    ''''            Next
    '    ''''        End If
    '    ''''    End If
    '    ''''End If

    '    uiTransaksiAdvanceRequest_TotalOutstanding()
    'End Sub
#End Region

    Private Function uiTransaksiAdvanceRequest_TotalOutstanding() As Boolean
        Dim oDataFiller As New clsDataFiller(Me.DSN)
        Dim f, h As Integer
        Dim jumlah_over As Integer
        Dim tbl_advance_bma As New DataTable
        Dim tbl_amount_st As New DataTable
        Dim budget_id, budgetdetil_id As Decimal
        Dim outstanding As Decimal
        Dim amount_approvebma As Decimal
        Dim budget_accum As Decimal
        Dim amount_budget As Decimal

        Dim amount_advance, advancedetil_foreignrate, advancedetil_discount As Decimal
        Dim total_idr As Decimal
        Dim pph_persen, ppn_persen, pph_amount, ppn_amount As Decimal
        Dim amount_subtotal As Decimal
        Dim amount_idrreal As Decimal
        Dim amount_intercompany As Decimal
        Dim tbl_amount_order As New DataTable
        Dim amount_order As Decimal

        Dim amount_subtotalforeign As Decimal
        Dim total_foreign As Decimal
        Dim pph_amountforeign, ppn_amountforeign As Decimal

        For f = 0 To Me.DgvTrnAdvanceDetil.Rows.Count - 1
            jumlah_over = 0

            For h = 0 To Me.DgvItemBudgetDetil.Rows.Count - 1
                budget_id = clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(h).Cells("budget_id").Value, 0)
                budgetdetil_id = clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(h).Cells("budgetdetil_id").Value, 0)

                'tambahan baru 17-02-2010
                amount_approvebma = clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(h).Cells("amount_approvebma").Value, 0)
                budget_accum = clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(h).Cells("budget_accum").Value, 0)
                amount_budget = clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(h).Cells("amount_budget").Value, 0)

                advancedetil_foreignrate = clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(h).Cells("advancedetil_foreignrate").Value, 0)
                ''''advancedetil_discount = clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(h).Cells("advancedetil_discount").Value, 0)
                If Me.DgvRefOrder.RowCount > 1 Then
                    If Mid(Me.DgvRefOrder.Rows(h).Cells("order_id").Value, 1, 2) = "RO" Then
                        advancedetil_discount = Math.Round(clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(h).Cells("advancedetil_discount").Value, 0), 2, MidpointRounding.AwayFromZero)
                    Else
                        If Me.DgvItemBudgetDetil.Rows(h).Cells("advancedetil_discount").Value = Me.DgvRefOrder.Rows(h).Cells("orderdetil_discount").Value * Me.DgvRefOrder.Rows(h).Cells("orderdetil_qty").Value Then
                            advancedetil_discount = Math.Round(clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(h).Cells("advancedetil_discount").Value, 0), 2, MidpointRounding.AwayFromZero)
                        Else
                            advancedetil_discount = Math.Round((clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(h).Cells("advancedetil_discount").Value, 0) * Me.DgvRefOrder.Rows(h).Cells("orderdetil_qty").Value), 2, MidpointRounding.AwayFromZero)
                        End If
                    End If
                End If

                

                amount_advance = Math.Round(clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(h).Cells("amount_advance").Value, 0), 2, MidpointRounding.AwayFromZero)
                pph_persen = clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(h).Cells("pph_persen").Value, 0)
                ppn_persen = clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(h).Cells("ppn_persen").Value, 0)
                amount_intercompany = Math.Round(clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(h).Cells("amount_intercompany").Value, 0), 2, MidpointRounding.AwayFromZero)

                total_idr = Math.Round((((amount_advance * advancedetil_foreignrate) + (amount_intercompany * advancedetil_foreignrate)) - (advancedetil_discount * advancedetil_foreignrate)), 2, MidpointRounding.AwayFromZero)

                Dim accum_advanceinter As Decimal
                accum_advanceinter = (amount_advance + amount_intercompany)

                pph_amount = Math.Round((((accum_advanceinter - advancedetil_discount) * (pph_persen / 100)) * advancedetil_foreignrate), 2, MidpointRounding.AwayFromZero)
                ppn_amount = Math.Round((((accum_advanceinter - advancedetil_discount) * (ppn_persen / 100)) * advancedetil_foreignrate), 2, MidpointRounding.AwayFromZero)

                'pph_amount = ((accum_advanceinter - advancedetil_discount) * (pph_persen / 100)) * advancedetil_foreignrate
                'ppn_amount = ((accum_advanceinter - advancedetil_discount) * (ppn_persen / 100)) * advancedetil_foreignrate

                amount_idrreal = ((amount_advance * advancedetil_foreignrate) + (amount_intercompany * advancedetil_foreignrate)) ''''Math.Round(((amount_advance * advancedetil_foreignrate) + (amount_intercompany * advancedetil_foreignrate)), 2, MidpointRounding.AwayFromZero)
                amount_subtotal = Math.Round(((amount_idrreal - (advancedetil_discount * advancedetil_foreignrate)) - pph_amount + ppn_amount), 2, MidpointRounding.AwayFromZero)

                total_foreign = Math.Round((((amount_advance) + (amount_intercompany)) - (advancedetil_discount)), 2, MidpointRounding.AwayFromZero)
                pph_amountforeign = Math.Round((((accum_advanceinter - advancedetil_discount) * (pph_persen / 100))), 2, MidpointRounding.AwayFromZero)
                ppn_amountforeign = Math.Round((((accum_advanceinter - advancedetil_discount) * (ppn_persen / 100))), 2, MidpointRounding.AwayFromZero)
                amount_subtotalforeign = Math.Round((total_foreign - pph_amountforeign + ppn_amountforeign), 2, MidpointRounding.AwayFromZero)


                Me.DgvItemBudgetDetil.Rows(h).Cells("pph_amount").Value = pph_amount
                Me.DgvItemBudgetDetil.Rows(h).Cells("ppn_amount").Value = ppn_amount
                Me.DgvItemBudgetDetil.Rows(h).Cells("amount_idrreal").Value = amount_idrreal
                Me.DgvItemBudgetDetil.Rows(h).Cells("amount_subtotal").Value = amount_subtotal
                Me.DgvItemBudgetDetil.Rows(h).Cells("amount_subtotalforeign").Value = amount_subtotalforeign

                Try

                Catch ex As Exception
                    MsgBox("Test 4" & ex.Message)
                End Try

                Try


                    amount_order = Me.DgvItemBudgetDetil.Rows(h).Cells("amount_sum").Value

                Catch ex As Exception
                    MsgBox("Test 5" & ex.Message)
                End Try

                If Me.DgvItemBudgetDetil.Rows(h).Cells("advancedetil_line").Value = Me.DgvTrnAdvanceDetil.Rows(f).Cells("advancedetil_line").Value Then


                    Me.DgvItemBudgetDetil.Rows(h).Cells("outstanding_budget").Value = 0 ''''amount_budget - amount_approvebma - amount_order + budget_accum

                    outstanding = Me.DgvItemBudgetDetil.Rows(h).Cells("outstanding_budget").Value

                    If clsUtil.IsDbNull(Me.DgvTrnAdvanceDetil.Rows(f).Cells("advancedetil_approvedbma").Value, False) = 1 Then
                        Me.DgvItemBudgetDetil.Rows(h).Cells("outstanding_approved").Value = Me.tbl_TrnAdvanceItemDetil.Rows(h).Item("outstanding_approved")
                        Me.DgvItemBudgetDetil.Rows(h).Cells("outstanding_check").Value = True
                    Else
                        Me.DgvItemBudgetDetil.Rows(h).Cells("outstanding_approved").Value = outstanding ''''Me.DgvItemBudgetDetil.Rows(h).Cells("outstanding_budget").Value
                        Me.DgvItemBudgetDetil.Rows(h).Cells("outstanding_check").Value = False
                    End If

                    If Me.DgvItemBudgetDetil.Rows(h).Cells("outstanding_approved").Value < 0 Then
                        jumlah_over = jumlah_over + 1
                    End If
                End If
            Next

            If jumlah_over > 0 Then
                Me.DgvTrnAdvanceDetil.Rows(f).Cells("status_over").Value = "OVER"
            Else
                Me.DgvTrnAdvanceDetil.Rows(f).Cells("status_over").Value = "OK"
            End If




        Next
    End Function

    Private Sub uiTransaksiAdvanceRequest_openDialogSettlement_Advance()
        Dim dlg As dlgTrnReimburseSettlement_Select_ST = New dlgTrnReimburseSettlement_Select_ST(Me.DSN, Me.obj_rekanan_id.SelectedValue, Me.tbl_MstRekanan.Copy, Me.tbl_MstAcc.Copy)

        Dim retObj As Object
        Dim retData As Collection
        Dim tblRef, tblAdvanceHeader, tblAdvanceDetil, tblAdvanceItem_Detil As DataTable
        Dim row As DataRow
        Dim k, l As Integer
        Dim totalIDR As Decimal = 0
        Dim IDR As Decimal = 0
        Dim totalForeign As Decimal = 0
        Dim totalRate As Decimal = 0
        Dim descr As String = ""
        Dim descrH As String = ""
        Dim f As Integer
        Dim table_advancedetil_temps As DataTable = New DataTable

        retObj = dlg.OpenDialog(Me, Me.obj_channel_id.Text, Me._SOURCE)

        If retObj IsNot Nothing Then
            retData = CType(retObj, Collection)
            tblRef = CType(retData.Item("tblRef"), DataTable)
            tblAdvanceHeader = CType(retData.Item("tblAdvanceHeader"), DataTable)
            tblAdvanceDetil = CType(retData.Item("tblAdvanceDetil"), DataTable)
            tblAdvanceItem_Detil = CType(retData.Item("tblAdvanceItemDetil"), DataTable)


            table_advancedetil_temps = tblAdvanceDetil.Copy
            table_advancedetil_temps.Clear()
            'Extract data for item budget
            For k = 0 To tblAdvanceItem_Detil.Rows.Count - 1
                Dim kondisi_item As String = String.Empty
                row = Me.tbl_TrnAdvanceItemDetil.NewRow
                If Me.tbl_TrnAdvanceItemDetil.Rows.Count > 0 Then
                    For l = 0 To Me.tbl_TrnAdvanceItemDetil.Rows.Count - 1
                        If Me.tbl_TrnAdvanceItemDetil.Rows(k).Item("advance_requestid") = Me.tbl_TrnAdvanceItemDetil.Rows(l).Item("advance_requestid") Then
                            row.Item("advancedetil_line") = Me.tbl_TrnAdvanceItemDetil.Rows(l).Item("advancedetil_line")
                            kondisi_item = "yes"
                            Exit For
                        Else
                            row.Item("advancedetil_line") = Me.tbl_TrnAdvanceItemDetil.Rows(l).Item("advancedetil_line") + 10
                            kondisi_item = "no"
                        End If
                    Next
                Else
                    row.Item("advancedetil_line") = 10
                    kondisi_item = "no"
                End If

                If Me.tbl_TrnAdvanceItemDetil.Rows.Count > 0 Then
                    If kondisi_item = "yes" Then
                        row.Item("budgetdetil_line") = Me.tbl_TrnAdvanceItemDetil.Rows(Me.tbl_TrnAdvanceItemDetil.Rows.Count - 1).Item("budgetdetil_line") + 10
                    Else
                        row.Item("budgetdetil_line") = 10
                    End If
                Else
                    row.Item("budgetdetil_line") = 10
                End If
                row.Item("advancedetil_foreignrate") = tblAdvanceItem_Detil.Rows(k).Item("advancedetil_foreignrate")
                row.Item("amount_advance") = tblAdvanceItem_Detil.Rows(k).Item("amount_advance")
                row.Item("amount_idrreal") = tblAdvanceItem_Detil.Rows(k).Item("amount_idrreal")
                row.Item("budget_id") = tblAdvanceItem_Detil.Rows(k).Item("budget_id")
                row.Item("budget_name") = tblAdvanceItem_Detil.Rows(k).Item("budget_name")
                row.Item("budgetdetil_id") = tblAdvanceItem_Detil.Rows(k).Item("budgetdetil_id")
                row.Item("budgetdetil_name") = tblAdvanceItem_Detil.Rows(k).Item("budgetdetil_name")
                row.Item("budgetdetil_eps") = tblAdvanceItem_Detil.Rows(k).Item("budgetdetil_eps")
                row.Item("acc_id") = tblAdvanceItem_Detil.Rows(k).Item("acc_id")
                row.Item("currency_id") = tblAdvanceItem_Detil.Rows(k).Item("currency_id")
                row.Item("advance_requestid") = tblAdvanceItem_Detil.Rows(k).Item("advance_requestid")
                row.Item("advance_requestid_line") = tblAdvanceItem_Detil.Rows(k).Item("advance_requestid_line")
                row.Item("advancedetil_discount") = 0
                row.Item("pph_persen") = 0
                row.Item("ppn_persen") = 0
                row.Item("pph_amount") = 0
                row.Item("ppn_amount") = 0
                row.Item("amount_subtotal") = tblAdvanceItem_Detil.Rows(k).Item("amount_idrreal")
                'If tblAdvanceItem_Detil.Rows(k).Item("currency_id") = 1 Then
                '    row.Item("amount_subtotalforeign") = Math.Round(tblAdvanceItem_Detil.Rows(k).Item("amount_subtotalforeign"), 2, MidpointRounding.AwayFromZero)
                'Else
                row.Item("amount_subtotalforeign") = Math.Round(tblAdvanceItem_Detil.Rows(k).Item("amount_subtotalforeign"), 2, MidpointRounding.AwayFromZero)
                'End If
                row.Item("channel_id") = tblAdvanceItem_Detil.Rows(k).Item("channel_id")
                Me.tbl_TrnAdvanceItemDetil.Rows.Add(row)

                Dim s As Integer
                Dim kondisi As String = String.Empty
                If table_advancedetil_temps.Rows.Count > 0 Then
                    For s = 0 To table_advancedetil_temps.Rows.Count - 1
                        If tblAdvanceItem_Detil.Rows(k).Item("advance_id") = table_advancedetil_temps.Rows(s).Item("advance_id") And tblAdvanceItem_Detil.Rows(k).Item("advancedetil_line") = table_advancedetil_temps.Rows(s).Item("advancedetil_line") Then
                            table_advancedetil_temps.Rows(s).Item("advancedetil_foreignreal") += tblAdvanceItem_Detil.Rows(k).Item("amount_advance")
                            table_advancedetil_temps.Rows(s).Item("advancedetil_idrreal") += tblAdvanceItem_Detil.Rows(k).Item("amount_idrreal")
                            table_advancedetil_temps.Rows(s).Item("advancedetil_subtotal") += tblAdvanceItem_Detil.Rows(k).Item("amount_idrreal") ''''tblAdvanceItem_Detil.Rows(k).Item("amount_subtotal")
                            kondisi = "terpenuhi"
                            Exit For
                        Else
                            kondisi = "nda terpenuhi"
                        End If
                    Next

                    If kondisi = "nda terpenuhi" Then
                        row = table_advancedetil_temps.NewRow
                        row.Item("advance_id") = tblAdvanceItem_Detil.Rows(k).Item("advance_id")
                        row.Item("advancedetil_line") = tblAdvanceItem_Detil.Rows(k).Item("advancedetil_line")
                        row.Item("advancedetil_type") = 1
                        row.Item("advancedetil_descr") = "Reimburse - " & tblAdvanceItem_Detil.Rows(k).Item("advance_requestid")
                        row.Item("currency_id") = tblAdvanceItem_Detil.Rows(k).Item("currency_id")
                        row.Item("advancedetil_foreignrate") = tblAdvanceItem_Detil.Rows(k).Item("advancedetil_foreignrate")
                        row.Item("advancedetil_foreignreal") = tblAdvanceItem_Detil.Rows(k).Item("amount_advance")
                        row.Item("advancedetil_idrreal") = tblAdvanceItem_Detil.Rows(k).Item("amount_idrreal")
                        row.Item("advancedetil_subtotal") = tblAdvanceItem_Detil.Rows(k).Item("amount_idrreal") ''''tblAdvanceItem_Detil.Rows(k).Item("amount_subtotal")
                        row.Item("advancedetil_approvedbmadt") = DBNull.Value
                        table_advancedetil_temps.Rows.Add(row)
                    End If

                Else
                    row = table_advancedetil_temps.NewRow
                    row.Item("advancedetil_line") = Me.tbl_TrnAdvanceItemDetil.Rows(Me.tbl_TrnAdvanceItemDetil.Rows.Count - 1).Item("advancedetil_line")
                    row.Item("advancedetil_type") = 1
                    row.Item("advancedetil_descr") = "Reimburse - " & tblAdvanceItem_Detil.Rows(k).Item("advance_requestid")
                    row.Item("currency_id") = tblAdvanceItem_Detil.Rows(k).Item("currency_id")
                    row.Item("advancedetil_foreignrate") = tblAdvanceItem_Detil.Rows(k).Item("advancedetil_foreignrate")
                    row.Item("advancedetil_foreignreal") = tblAdvanceItem_Detil.Rows(k).Item("amount_advance")
                    row.Item("advancedetil_idrreal") = tblAdvanceItem_Detil.Rows(k).Item("amount_idrreal")
                    row.Item("advancedetil_subtotal") = tblAdvanceItem_Detil.Rows(k).Item("amount_idrreal") ''''tblAdvanceItem_Detil.Rows(k).Item("amount_subtotal")
                    row.Item("advancedetil_approvedbmadt") = DBNull.Value
                    table_advancedetil_temps.Rows.Add(row)
                End If
            Next

            Me.DgvItemBudgetDetil.DataSource = Me.tbl_TrnAdvanceItemDetil

            For f = 0 To table_advancedetil_temps.Rows.Count - 1
                row = Me.tbl_TrnAdvanceDetil.NewRow
                row.Item("advance_id") = String.Empty
                row.Item("advancedetil_line") = table_advancedetil_temps.Rows(f).Item("advancedetil_line")
                row.Item("advancedetil_type") = 1
                row.Item("advancedetil_descr") = table_advancedetil_temps.Rows(f).Item("advancedetil_descr")
                row.Item("currency_id") = table_advancedetil_temps.Rows(f).Item("currency_id")
                row.Item("advancedetil_foreignrate") = table_advancedetil_temps.Rows(f).Item("advancedetil_foreignrate")
                row.Item("advancedetil_foreignreal") = table_advancedetil_temps.Rows(f).Item("advancedetil_foreignreal")
                row.Item("advancedetil_idrreal") = table_advancedetil_temps.Rows(f).Item("advancedetil_idrreal")
                row.Item("advancedetil_subtotal") = table_advancedetil_temps.Rows(f).Item("advancedetil_subtotal")
                row.Item("advancedetil_approvedbmadt") = DBNull.Value
                Me.tbl_TrnAdvanceDetil.Rows.Add(row)
            Next

            If Not DATADETIL_OPENED Then
                Me.obj_rekanan_id.SelectedValue = tblAdvanceHeader.Rows(0).Item("rekanan_id")
                Me.obj_budget_id_code.Text = tblAdvanceHeader.Rows(0).Item("budget_id")
                Me.obj_budget_id_view.SelectedValue = tblAdvanceHeader.Rows(0).Item("budget_id")
                code_budget_view()
                Me.obj_strukturunit_id.SelectedValue = Me._USERSTRUKTURUNIT ''''tblRef.Rows(0).Item("strukturunit_id")
                Me.obj_Advance_descr.Text = tblAdvanceHeader.Rows(0).Item("advance_descr")
            End If
            uiTransaksiAdvanceRequest_TotalOutstandingListST()
        End If

    End Sub

    Private Sub uiTransaksiAdvanceRequest_openDialogSPD_Advance()
        Dim dlg As dlgSelectTravel_Advance = New dlgSelectTravel_Advance(Me.DSN, Me._CHANNEL, "", 0, Me.UserName)

        Dim retObj As Object
        Dim retData As Collection

        Dim tbl_TrnAdvanceForTravel_result, tbl_TrnAdvanceForTravel_result2, tbl_TrnAdvanceForTravelDetil_result, tbl_TrnAdvanceForTravelOther_result As DataTable

        Dim row As DataRow
        Dim k, l As Integer
        Dim totalIDR As Decimal = 0
        Dim IDR As Decimal = 0
        Dim totalForeign As Decimal = 0
        Dim totalRate As Decimal = 0
        Dim descr As String = ""
        Dim descrH As String = ""
        Dim f As Integer
        Dim table_advancedetil_temps As DataTable = New DataTable
        Dim h As Integer

        retObj = dlg.OpenDialog(Me)


    End Sub

    Private Sub uiTransaksiAdvanceRequest_openDialogOrder_Advance()
        Dim dlg As dlgSelectTravel_Advance = New dlgSelectTravel_Advance(Me.DSN, Me._CHANNEL, "", "", Me.UserName) ''''New dlgTrnAdvanceOrder_Select_Order(Me.DSN, Me.obj_rekanan_id.SelectedValue, Me.tbl_MstRekanan.Copy, Me.tbl_MstAcc.Copy)

        Dim retObj As Object
        Dim retData As Collection
        ''''Dim tblRef As DataTable
        Dim tbl_TrnAdvanceForOrder_result, tbl_TrnAdvanceForOrder_result2, tbl_TrnAdvanceForOrderDetil_result As DataTable
        Dim tbl_TrnAdvanceForTravelDetil_perdiems, tbl_TrnAdvanceForTravelDetil_other As DataTable
        Dim datarowselectperdiems As DataRow() = Nothing
        Dim datarowselectdetil As DataRow() = Nothing
        Dim row As DataRow
        Dim k, l As Integer
        Dim totalIDR As Decimal = 0
        Dim IDR As Decimal = 0
        Dim totalForeign As Decimal = 0
        Dim totalRate As Decimal = 0
        Dim descr As String = ""
        Dim descrH As String = ""
        Dim f As Integer
        Dim table_advancedetil_temps As DataTable = New DataTable
        Dim h As Integer


        retObj = dlg.OpenDialog(Me)

        If retObj IsNot Nothing Then

            retData = CType(retObj, Collection)
            ''''tblRef = CType(retData.Item("tblRef"), DataTable)
            tbl_TrnAdvanceForOrder_result = CType(retData.Item("tbl_TrnAdvanceForOrder_result"), DataTable)
            tbl_TrnAdvanceForOrder_result2 = CType(retData.Item("tbl_TrnAdvanceForOrder_result2"), DataTable)
            tbl_TrnAdvanceForOrderDetil_result = CType(retData.Item("tbl_TrnAdvanceForOrderDetil_result"), DataTable)


            tbl_TrnAdvanceForTravelDetil_perdiems = New DataTable
            tbl_TrnAdvanceForTravelDetil_perdiems.Clear()
            datarowselectperdiems = tbl_TrnAdvanceForOrderDetil_result.Select("item_id = '0'")
            If datarowselectperdiems.Length > 0 Then
                tbl_TrnAdvanceForTravelDetil_perdiems = tbl_TrnAdvanceForOrderDetil_result.Select("item_id = '0'").CopyToDataTable
            End If


            tbl_TrnAdvanceForTravelDetil_other = New DataTable
            tbl_TrnAdvanceForTravelDetil_other.Clear()
            datarowselectdetil = tbl_TrnAdvanceForOrderDetil_result.Select("item_id <> '0'")
            If datarowselectdetil.Length > 0 Then
                tbl_TrnAdvanceForTravelDetil_other = tbl_TrnAdvanceForOrderDetil_result.Select("item_id <> '0'").CopyToDataTable
            End If


            table_advancedetil_temps = clsDataset.CreateTblTrnAdvancedetil()
            table_advancedetil_temps.Clear()

            'Extract data for item budget
            For k = 0 To tbl_TrnAdvanceForOrderDetil_result.Rows.Count - 1
                Dim kondisi_item As String = String.Empty
                row = Me.tbl_TrnAdvanceItemDetil.NewRow
                If Me.tbl_TrnAdvanceItemDetil.Rows.Count > 0 Then
                    For l = 0 To Me.tbl_TrnAdvanceItemDetil.Rows.Count - 1
                        If tbl_TrnAdvanceForOrderDetil_result.Rows(k).Item("order_id") = Me.tbl_TrnAdvanceItemDetil.Rows(l).Item("advance_requestid") And _
                            tbl_TrnAdvanceForOrderDetil_result.Rows(k).Item("item_id") = 0 Then
                            row.Item("advancedetil_line") = Me.tbl_TrnAdvanceItemDetil.Rows(l).Item("advancedetil_line")
                            kondisi_item = "yes"
                            Exit For
                        Else
                            row.Item("advancedetil_line") = Me.tbl_TrnAdvanceItemDetil.Rows(l).Item("advancedetil_line") + 10
                            kondisi_item = "yes"

                        End If
                    Next
                Else
                    row.Item("advancedetil_line") = 10
                    kondisi_item = "no"
                End If

                If Me.tbl_TrnAdvanceItemDetil.Rows.Count > 0 Then
                    If kondisi_item = "yes" Then
                        row.Item("budgetdetil_line") = Me.tbl_TrnAdvanceItemDetil.Rows(Me.tbl_TrnAdvanceItemDetil.Rows.Count - 1).Item("budgetdetil_line") + 10
                    Else
                        row.Item("budgetdetil_line") = 10
                    End If
                Else
                    row.Item("budgetdetil_line") = 10
                End If
                row.Item("advancedetil_foreignrate") = tbl_TrnAdvanceForOrderDetil_result.Rows(k).Item("orderdetil_foreignrate")
                row.Item("amount_advance") = tbl_TrnAdvanceForOrderDetil_result.Rows(k).Item("amount")
                row.Item("amount_idrreal") = tbl_TrnAdvanceForOrderDetil_result.Rows(k).Item("amount") * tbl_TrnAdvanceForOrderDetil_result.Rows(k).Item("orderdetil_foreignrate")
                row.Item("advance_id") = String.Empty
                row.Item("budget_id") = tbl_TrnAdvanceForOrderDetil_result.Rows(k).Item("budget_id")
                row.Item("budget_name") = tbl_TrnAdvanceForOrderDetil_result.Rows(k).Item("budget_name")
                row.Item("budgetdetil_id") = tbl_TrnAdvanceForOrderDetil_result.Rows(k).Item("budgetdetil_id")
                row.Item("budgetdetil_name") = tbl_TrnAdvanceForOrderDetil_result.Rows(k).Item("budgetdetil_name")
                row.Item("budgetdetil_eps") = ""
                row.Item("acc_id") = tbl_TrnAdvanceForOrderDetil_result.Rows(k).Item("account_oth")
                row.Item("account") = tbl_TrnAdvanceForOrderDetil_result.Rows(k).Item("account")
                row.Item("currency_id") = tbl_TrnAdvanceForOrderDetil_result.Rows(k).Item("currency_id")
                row.Item("advance_requestid") = tbl_TrnAdvanceForOrderDetil_result.Rows(k).Item("order_id")
                row.Item("advance_requestid_line") = tbl_TrnAdvanceForOrderDetil_result.Rows(k).Item("orderdetil_line")
                row.Item("pph_persen") = tbl_TrnAdvanceForOrderDetil_result.Rows(k).Item("orderdetil_pphpercent")
                row.Item("ppn_persen") = tbl_TrnAdvanceForOrderDetil_result.Rows(k).Item("orderdetil_ppnpercent")

                Dim qty, days, foreign, pph_persen, ppn_persen As Decimal
                ''Dim qty, days, foreign, discount As Decimal
                Dim pph_amount, ppn_amount As Decimal

                qty = tbl_TrnAdvanceForOrderDetil_result.Rows(k).Item("orderdetil_qty")
                days = tbl_TrnAdvanceForOrderDetil_result.Rows(k).Item("orderdetil_days")
                foreign = tbl_TrnAdvanceForOrderDetil_result.Rows(k).Item("amount")
                ' discount = tbl_TrnAdvanceForOrderDetil_result.Rows(k).Item("orderdetil_discount")
                pph_persen = tbl_TrnAdvanceForOrderDetil_result.Rows(k).Item("orderdetil_pphpercent")
                ppn_persen = tbl_TrnAdvanceForOrderDetil_result.Rows(k).Item("orderdetil_ppnpercent")

                pph_amount = ((foreign) * (pph_persen / 100))
                ppn_amount = ((foreign) * (ppn_persen / 100))

                row.Item("advancedetil_discount") = 0 ''tbl_TrnAdvanceForOrderDetil_result.Rows(k).Item("orderdetil_discount") * qty
                row.Item("amount_subtotal") = ((foreign) - pph_amount + ppn_amount)
                'If tbl_TrnAdvanceForOrderDetil_result.Rows(k).Item("currency_id") = 1 Then
                '    row.Item("amount_subtotalforeign") = Math.Round((((foreign) - pph_amount + ppn_amount)), 2, MidpointRounding.AwayFromZero)
                'Else
                row.Item("amount_subtotalforeign") = Math.Round((((foreign) - pph_amount + ppn_amount)), 2, MidpointRounding.AwayFromZero)
                'End If



                row.Item("pph_amount") = pph_amount
                row.Item("ppn_amount") = ppn_amount

                row.Item("qty") = qty

                row.Item("channel_id") = tbl_TrnAdvanceForOrder_result.Rows(0).Item("channel_id")
                If tbl_TrnAdvanceForOrderDetil_result.Rows(k).Item("currency_id") = 1 Then
                    row.Item("amount_sisa") = tbl_TrnAdvanceForOrderDetil_result.Rows(k).Item("amount_sisa") - tbl_TrnAdvanceForOrderDetil_result.Rows(k).Item("amount") ''''tbl_TrnAdvanceForOrderDetil_result.Rows(k).Item("subtotal_idr") - tbl_TrnAdvanceForOrderDetil_result.Rows(k).Item("amount")
                    row.Item("amount_order") = tbl_TrnAdvanceForOrderDetil_result.Rows(k).Item("subtotal_incldisc_idr")  '("subtotal_idr")
                Else
                    row.Item("amount_sisa") = tbl_TrnAdvanceForOrderDetil_result.Rows(k).Item("amount_sisa") - tbl_TrnAdvanceForOrderDetil_result.Rows(k).Item("amount") ''''tbl_TrnAdvanceForOrderDetil_result.Rows(k).Item("subtotal_foreign") - tbl_TrnAdvanceForOrderDetil_result.Rows(k).Item("amount")
                    row.Item("amount_order") = tbl_TrnAdvanceForOrderDetil_result.Rows(k).Item("subtotal_incldisc_foreign") '("subtotal_foreign")
                End If

                Me.tbl_TrnAdvanceItemDetil.Rows.Add(row)

                Dim s As Integer
                Dim kondisi As String = String.Empty


                If table_advancedetil_temps.Rows.Count > 0 Then
                    For s = 0 To table_advancedetil_temps.Rows.Count - 1
                        If Me.tbl_TrnAdvanceItemDetil.Rows(k).Item("advance_id") = table_advancedetil_temps.Rows(s).Item("advance_id") And Me.tbl_TrnAdvanceItemDetil.Rows(k).Item("advancedetil_line") = table_advancedetil_temps.Rows(s).Item("advancedetil_line") Then
                            table_advancedetil_temps.Rows(s).Item("advancedetil_foreignreal") += tbl_TrnAdvanceForOrderDetil_result.Rows(k).Item("amount")
                            table_advancedetil_temps.Rows(s).Item("advancedetil_idrreal") += tbl_TrnAdvanceForOrderDetil_result.Rows(k).Item("amount") * tbl_TrnAdvanceForOrderDetil_result.Rows(k).Item("orderdetil_foreignrate")
                            table_advancedetil_temps.Rows(s).Item("advancedetil_subtotal") += tbl_TrnAdvanceItemDetil.Rows(k).Item("amount_subtotal") ''''tbl_TrnAdvanceForOrderDetil_result.Rows(k).Item("amount") * tbl_TrnAdvanceForOrderDetil_result.Rows(k).Item("orderdetil_foreignrate") ''''tblAdvanceItem_Detil.Rows(k).Item("amount_subtotal")
                            kondisi = "terpenuhi"
                            Exit For
                        Else
                            kondisi = "nda terpenuhi"
                        End If
                    Next

                    If kondisi = "nda terpenuhi" Then

                        row = table_advancedetil_temps.NewRow
                        row.Item("advancedetil_line") = Me.tbl_TrnAdvanceItemDetil.Rows(Me.tbl_TrnAdvanceItemDetil.Rows.Count - 1).Item("advancedetil_line")
                        row.Item("advancedetil_type") = 1
                        row.Item("advancedetil_descr") = "Travel - " & tbl_TrnAdvanceForOrderDetil_result.Rows(k).Item("item_name") & " (" & tbl_TrnAdvanceForOrderDetil_result.Rows(k).Item("order_id") & ")"
                        row.Item("currency_id") = tbl_TrnAdvanceForOrderDetil_result.Rows(k).Item("currency_id")
                        row.Item("advancedetil_foreignrate") = tbl_TrnAdvanceForOrderDetil_result.Rows(k).Item("orderdetil_foreignrate")
                        row.Item("advancedetil_foreignreal") = tbl_TrnAdvanceForOrderDetil_result.Rows(k).Item("amount")
                        row.Item("advancedetil_idrreal") = tbl_TrnAdvanceForOrderDetil_result.Rows(k).Item("amount") * tbl_TrnAdvanceForOrderDetil_result.Rows(k).Item("orderdetil_foreignrate")
                        row.Item("advancedetil_subtotal") = tbl_TrnAdvanceItemDetil.Rows(k).Item("amount_subtotal") ''''tbl_TrnAdvanceForOrderDetil_result.Rows(k).Item("amount") * tbl_TrnAdvanceForOrderDetil_result.Rows(k).Item("orderdetil_foreignrate")
                        row.Item("advancedetil_approvedbmadt") = DBNull.Value
                        table_advancedetil_temps.Rows.Add(row)


                        'row = table_advancedetil_temps.NewRow
                        'row.Item("advance_id") = tbl_TrnAdvanceForOrderDetil_result.Rows(k).Item("advance_id")
                        'row.Item("advancedetil_line") = tbl_TrnAdvanceForOrderDetil_result.Rows(k).Item("advancedetil_line")
                        'row.Item("advancedetil_type") = 1
                        'row.Item("advancedetil_descr") = "Travel/SPD - " & tbl_TrnAdvanceForOrderDetil_result.Rows(k).Item("advance_requestid")
                        'row.Item("currency_id") = tbl_TrnAdvanceForOrderDetil_result.Rows(k).Item("currency_id")
                        'row.Item("advancedetil_foreignrate") = tbl_TrnAdvanceForOrderDetil_result.Rows(k).Item("advancedetil_foreignrate")
                        'row.Item("advancedetil_foreignreal") = tbl_TrnAdvanceForOrderDetil_result.Rows(k).Item("amount_advance")
                        'row.Item("advancedetil_idrreal") = tbl_TrnAdvanceForOrderDetil_result.Rows(k).Item("amount_idrreal")
                        'row.Item("advancedetil_subtotal") = tbl_TrnAdvanceItemDetil.Rows(k).Item("amount_subtotal") ''''tbl_TrnAdvanceForOrderDetil_result.Rows(k).Item("amount_idrreal") ''''tblAdvanceItem_Detil.Rows(k).Item("amount_subtotal")
                        'row.Item("advancedetil_approvedbmadt") = DBNull.Value
                        'table_advancedetil_temps.Rows.Add(row)
                    End If

                Else
                    row = table_advancedetil_temps.NewRow
                    row.Item("advancedetil_line") = Me.tbl_TrnAdvanceItemDetil.Rows(Me.tbl_TrnAdvanceItemDetil.Rows.Count - 1).Item("advancedetil_line")
                    row.Item("advancedetil_type") = 1
                    row.Item("advancedetil_descr") = "Travel/SPD Perdiems - " & tbl_TrnAdvanceForOrderDetil_result.Rows(k).Item("order_id")
                    row.Item("currency_id") = tbl_TrnAdvanceForOrderDetil_result.Rows(k).Item("currency_id")
                    row.Item("advancedetil_foreignrate") = tbl_TrnAdvanceForOrderDetil_result.Rows(k).Item("orderdetil_foreignrate")
                    row.Item("advancedetil_foreignreal") = tbl_TrnAdvanceForOrderDetil_result.Rows(k).Item("amount")
                    row.Item("advancedetil_idrreal") = tbl_TrnAdvanceForOrderDetil_result.Rows(k).Item("amount") * tbl_TrnAdvanceForOrderDetil_result.Rows(k).Item("orderdetil_foreignrate")
                    row.Item("advancedetil_subtotal") = tbl_TrnAdvanceItemDetil.Rows(k).Item("amount_subtotal") ''''tbl_TrnAdvanceForOrderDetil_result.Rows(k).Item("amount") * tbl_TrnAdvanceForOrderDetil_result.Rows(k).Item("orderdetil_foreignrate")
                    row.Item("advancedetil_approvedbmadt") = DBNull.Value
                    table_advancedetil_temps.Rows.Add(row)
                End If
            Next

            Me.DgvItemBudgetDetil.DataSource = Me.tbl_TrnAdvanceItemDetil

            For f = 0 To table_advancedetil_temps.Rows.Count - 1
                row = Me.tbl_TrnAdvanceDetil.NewRow
                row.Item("advance_id") = String.Empty
                row.Item("advancedetil_line") = table_advancedetil_temps.Rows(f).Item("advancedetil_line")
                row.Item("advancedetil_type") = 1
                row.Item("advancedetil_descr") = table_advancedetil_temps.Rows(f).Item("advancedetil_descr")
                row.Item("currency_id") = table_advancedetil_temps.Rows(f).Item("currency_id")
                row.Item("advancedetil_foreignrate") = table_advancedetil_temps.Rows(f).Item("advancedetil_foreignrate")
                row.Item("advancedetil_foreignreal") = table_advancedetil_temps.Rows(f).Item("advancedetil_foreignreal")
                row.Item("advancedetil_idrreal") = table_advancedetil_temps.Rows(f).Item("advancedetil_idrreal")
                row.Item("advancedetil_subtotal") = table_advancedetil_temps.Rows(f).Item("advancedetil_subtotal")
                row.Item("advancedetil_approvedbmadt") = DBNull.Value
                Me.tbl_TrnAdvanceDetil.Rows.Add(row)
            Next

            If Not DATADETIL_OPENED Then
                Me.obj_rekanan_id.SelectedValue = tbl_TrnAdvanceForOrder_result.Rows(0).Item("rekanan_id")
                If tbl_TrnAdvanceForOrder_result.Rows(0).Item("rekanan_id") = 0 Then
                    Me.obj_rekanan_id.Enabled = True
                End If
                Me.obj_Advance_currency.SelectedValue = tbl_TrnAdvanceForOrder_result.Rows(0).Item("currency_id")
                obj_rekanan_id_SelectionChangeCommitted(Nothing, Nothing)

                Me.obj_budget_id_code.Text = tbl_TrnAdvanceForOrderDetil_result.Rows(0).Item("budget_id")
                Me.obj_budget_id_view.SelectedValue = tbl_TrnAdvanceForOrderDetil_result.Rows(0).Item("budget_id")
                code_budget_view()
                Me.obj_strukturunit_id.SelectedValue = Me._USERSTRUKTURUNIT ''''tblRef.Rows(0).Item("strukturunit_id")
                Me.obj_Advance_descr.Text = tbl_TrnAdvanceForOrder_result.Rows(0).Item("order_descr")
            End If

            ''''''Me.uiTransaksiAdvanceRequest_OutstandingAdvanceOrder()

            ''''uiTransaksiAdvanceRequest_TotalOutstandingListST()

            If tbl_TrnAdvanceForOrderDetil_result.Rows.Count > 0 Then
                For h = 0 To tbl_TrnAdvanceForOrderDetil_result.Rows.Count - 1
                    row = Me.tbl_RefOrder.NewRow
                    row.Item("advance_id") = Me.tbl_TrnAdvanceItemDetil.Rows(0).Item("advance_id")
                    row.Item("advancedetil_line") = Me.tbl_TrnAdvanceItemDetil.Rows(0).Item("advancedetil_line")
                    row.Item("budgetdetil_line") = Me.tbl_TrnAdvanceItemDetil.Rows(h).Item("budgetdetil_line")
                    row.Item("order_id") = tbl_TrnAdvanceForOrderDetil_result.Rows(h).Item("order_id")
                    row.Item("orderdetil_line") = tbl_TrnAdvanceForOrderDetil_result.Rows(h).Item("orderdetil_line")
                    row.Item("item_id") = tbl_TrnAdvanceForOrderDetil_result.Rows(h).Item("item_id")
                    row.Item("currency_id") = tbl_TrnAdvanceForOrderDetil_result.Rows(h).Item("currency_id")
                    row.Item("budget_id") = tbl_TrnAdvanceForOrderDetil_result.Rows(h).Item("budget_id")
                    row.Item("budgetdetil_id") = tbl_TrnAdvanceForOrderDetil_result.Rows(h).Item("budgetdetil_id")
                    row.Item("amount_advance") = tbl_TrnAdvanceForOrderDetil_result.Rows(h).Item("amount")

                    row.Item("orderdetil_discount") = tbl_TrnAdvanceForOrderDetil_result.Rows(h).Item("orderdetil_discount")

                    row.Item("acc_id") = tbl_TrnAdvanceForOrderDetil_result.Rows(h).Item("account_oth")
                    row.Item("account") = tbl_TrnAdvanceForOrderDetil_result.Rows(h).Item("account")
                    row.Item("orderdetil_qty") = tbl_TrnAdvanceForOrderDetil_result.Rows(h).Item("orderdetil_qty")

                    If tbl_TrnAdvanceForOrderDetil_result.Rows(h).Item("currency_id") = 1 Then
                        row.Item("amount_order") = tbl_TrnAdvanceForOrderDetil_result.Rows(h).Item("subtotal_idr")

                        If tbl_TrnAdvanceForOrderDetil_result.Rows(h).Item("isadvance") = 1 Then
                            row.Item("amount_sisa") = (tbl_TrnAdvanceForOrderDetil_result.Rows(h).Item("amount_sisa") - tbl_TrnAdvanceForOrderDetil_result.Rows(h).Item("amount")) ''''(tbl_TrnAdvanceForOrderDetil_result.Rows(h).Item("subtotal_idr") - tbl_TrnAdvanceForOrderDetil_result.Rows(h).Item("amount") - tbl_TrnAdvanceForOrderDetil_result.Rows(h).Item("amount_sisa"))
                        Else
                            row.Item("amount_sisa") = (tbl_TrnAdvanceForOrderDetil_result.Rows(h).Item("amount_sisa") - tbl_TrnAdvanceForOrderDetil_result.Rows(h).Item("amount")) ''''(tbl_TrnAdvanceForOrderDetil_result.Rows(h).Item("subtotal_idr") - tbl_TrnAdvanceForOrderDetil_result.Rows(h).Item("amount"))
                        End If

                        row.Item("orderdetil_pphamount") = tbl_TrnAdvanceForOrderDetil_result.Rows(h).Item("pph_amount_idr")
                        row.Item("orderdetil_ppnamount") = tbl_TrnAdvanceForOrderDetil_result.Rows(h).Item("ppn_amount_idr")
                    Else
                        row.Item("amount_order") = tbl_TrnAdvanceForOrderDetil_result.Rows(h).Item("subtotal_foreign")

                        If tbl_TrnAdvanceForOrderDetil_result.Rows(h).Item("isadvance") = 1 Then
                            row.Item("amount_sisa") = (tbl_TrnAdvanceForOrderDetil_result.Rows(h).Item("amount_sisa") - tbl_TrnAdvanceForOrderDetil_result.Rows(h).Item("amount")) ''''(tbl_TrnAdvanceForOrderDetil_result.Rows(h).Item("subtotal_foreign") - tbl_TrnAdvanceForOrderDetil_result.Rows(h).Item("amount") - tbl_TrnAdvanceForOrderDetil_result.Rows(h).Item("amount_sisa"))
                        Else
                            row.Item("amount_sisa") = (tbl_TrnAdvanceForOrderDetil_result.Rows(h).Item("amount_sisa") - tbl_TrnAdvanceForOrderDetil_result.Rows(h).Item("amount")) ''''(tbl_TrnAdvanceForOrderDetil_result.Rows(h).Item("subtotal_foreign") - tbl_TrnAdvanceForOrderDetil_result.Rows(h).Item("amount"))
                        End If

                        row.Item("orderdetil_pphamount") = tbl_TrnAdvanceForOrderDetil_result.Rows(h).Item("pph_amount_foreign")
                        row.Item("orderdetil_ppnamount") = tbl_TrnAdvanceForOrderDetil_result.Rows(h).Item("ppn_amount_foreign")
                    End If
                    row.Item("orderdetil_pphpercent") = tbl_TrnAdvanceForOrderDetil_result.Rows(h).Item("orderdetil_pphpercent")
                    row.Item("orderdetil_ppnpercent") = tbl_TrnAdvanceForOrderDetil_result.Rows(h).Item("orderdetil_ppnpercent")
                    row.Item("orderdetil_days") = tbl_TrnAdvanceForOrderDetil_result.Rows(h).Item("orderdetil_days")
                    row.Item("orderdetil_foreignrate") = tbl_TrnAdvanceForOrderDetil_result.Rows(h).Item("orderdetil_foreignrate")
                    row.Item("amount_ppnpphdisc") = tbl_TrnAdvanceForOrderDetil_result.Rows(h).Item("total")
                    Me.tbl_RefOrder.Rows.Add(row)
                Next

                Me.DgvRefOrder.DataSource = Me.tbl_RefOrder
                Me.FormatDgvTrnRefOrder(Me.DgvRefOrder)

                'Me.uiTransaksiAdvanceRequest_OutstandingAdvanceOrder()
            End If

        End If


    End Sub

    Private Function uiTransaksiAdvanceRequest_OutstandingAdvanceOrder() As Boolean
        Dim oDataFiller As New clsDataFiller(Me.DSN)
        Dim p, q As Integer
        Dim jumlah_over As Integer
        Dim tbl_advance_bma As New DataTable
        Dim tbl_amount_st As New DataTable
        Dim tbl_trnBudget As DataTable = New DataTable
        Dim budget_id, budgetdetil_id As Decimal
        Dim tbl_amount_order As New DataTable
        Dim outstanding As Decimal
        ''''Dim amount_order As Decimal

        Dim amount As Decimal
        Dim amount_foreignreal As Decimal


        For p = 0 To Me.DgvTrnAdvanceDetil.Rows.Count - 1
            jumlah_over = 0

            For q = 0 To Me.DgvItemBudgetDetil.Rows.Count - 1
                budget_id = clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(q).Cells("budget_id").Value, 0)
                budgetdetil_id = clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(q).Cells("budgetdetil_id").Value, 0)

                Try
                    tbl_trnBudget.Clear()

                    oDataFiller.DataFill(tbl_trnBudget, "pr_TrnBudgetDetil_Select", String.Format("budget_id = {0} and budgetdetil_id = {1}", budget_id, budgetdetil_id))
                    If tbl_trnBudget.Rows.Count > 0 Then
                        Me.DgvItemBudgetDetil.Rows(q).Cells("amount_budget").Value = clsUtil.IsDbNull(tbl_trnBudget.Rows(0)("budgetdetil_amount"), 0)
                    Else
                        Me.DgvItemBudgetDetil.Rows(q).Cells("amount_budget").Value = clsUtil.IsDbNull(tbl_trnBudget.Columns("budgetdetil_amount").DefaultValue, 0)
                    End If
                Catch ex As Exception
                    MsgBox("Test 4" & ex.Message)
                End Try


                If Me.DgvItemBudgetDetil.Rows(q).Cells("advancedetil_line").Value = Me.DgvTrnAdvanceDetil.Rows(p).Cells("advancedetil_line").Value Then
                    ''''Me.DgvItemBudgetDetil.Rows(q).Cells("outstanding_budget").Value = clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(q).Cells("amount_budget").Value, 0) - clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(q).Cells("amount_approvebma").Value, 0) - amount_order + clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(q).Cells("budget_accum").Value, 0)
                    outstanding = 0 ''''Me.DgvItemBudgetDetil.Rows(q).Cells("outstanding_budget").Value

                    If clsUtil.IsDbNull(Me.DgvTrnAdvanceDetil.Rows(p).Cells("advancedetil_approvedbma").Value, False) = 1 Then
                        Me.DgvItemBudgetDetil.Rows(q).Cells("outstanding_approved").Value = Me.tbl_TrnAdvanceItemDetil.Rows(q).Item("outstanding_approved")
                        Me.DgvItemBudgetDetil.Rows(q).Cells("outstanding_check").Value = True
                    Else
                        Me.DgvItemBudgetDetil.Rows(q).Cells("outstanding_approved").Value = outstanding ''''Me.DgvItemBudgetDetil.Rows(h).Cells("outstanding_budget").Value
                        Me.DgvItemBudgetDetil.Rows(q).Cells("outstanding_check").Value = False
                    End If

                    If Me.DgvItemBudgetDetil.Rows(q).Cells("outstanding_approved").Value < 0 Then
                        jumlah_over = jumlah_over + 1
                    End If

                    If Me.DgvItemBudgetDetil.Rows(q).Cells("outstanding_approved").Value Then

                    End If

                    Dim amount_advance, amount_intercompany, advancedetil_discount, advancedetil_foreignrate, pph_persen, ppn_persen As Decimal
                    Dim pph_amount, ppn_amount, amount_idrreal, amount_subtotal As Decimal
                    Dim amount_budget As Decimal
                    Dim pph_amountforeign, ppn_amountforeign As Decimal
                    Dim amount_foreign As Decimal

                    Dim accum_advanceinter As Decimal


                    amount_budget = clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(q).Cells("amount_budget").Value, 0)
                    advancedetil_foreignrate = clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(q).Cells("advancedetil_foreignrate").Value, 0)
                    amount_advance = Math.Round(clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(q).Cells("amount_advance").Value, 0), 2, MidpointRounding.AwayFromZero)
                    advancedetil_foreignrate = clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(q).Cells("advancedetil_foreignrate").Value, 0)

                    pph_persen = clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(q).Cells("pph_persen").Value, 0)
                    ppn_persen = clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(q).Cells("ppn_persen").Value, 0)
                    amount_intercompany = Math.Round(clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(q).Cells("amount_intercompany").Value, 0), 2, MidpointRounding.AwayFromZero)

                    If Mid(Me.DgvRefOrder.Rows(q).Cells("order_id").Value, 1, 2) = "RO" Then
                        advancedetil_discount = Math.Round(clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(q).Cells("advancedetil_discount").Value, 0), 2, MidpointRounding.AwayFromZero)
                    Else
                        If Me.DgvItemBudgetDetil.Rows(q).Cells("advancedetil_discount").Value = Me.DgvRefOrder.Rows(q).Cells("orderdetil_discount").Value * Me.DgvRefOrder.Rows(q).Cells("orderdetil_qty").Value Then
                            advancedetil_discount = Math.Round(clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(q).Cells("advancedetil_discount").Value, 0), 2, MidpointRounding.AwayFromZero)
                        Else
                            advancedetil_discount = Math.Round((Math.Round(clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(q).Cells("advancedetil_discount").Value, 0), 2) * Me.DgvRefOrder.Rows(q).Cells("orderdetil_qty").Value), 2, MidpointRounding.AwayFromZero) 'Math.Round((clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(b).Cells("advancedetil_discount").Value, 0) * Me.DgvRefOrder.Rows(b).Cells("orderdetil_qty").Value), 2, MidpointRounding.AwayFromZero)
                        End If
                    End If

                    accum_advanceinter = (amount_advance + amount_intercompany)

                    amount_idrreal = ((amount_advance * advancedetil_foreignrate) + (amount_intercompany * advancedetil_foreignrate))

                    pph_amount = Math.Round((((accum_advanceinter - advancedetil_discount) * advancedetil_foreignrate) * (pph_persen / 100)), 2, MidpointRounding.AwayFromZero)
                    ppn_amount = Math.Round((((accum_advanceinter - advancedetil_discount) * advancedetil_foreignrate) * (ppn_persen / 100)), 2, MidpointRounding.AwayFromZero)

                    pph_amountforeign = Math.Round((((accum_advanceinter - advancedetil_discount)) * (pph_persen / 100)), 2, MidpointRounding.AwayFromZero)
                    ppn_amountforeign = Math.Round((((accum_advanceinter - advancedetil_discount)) * (ppn_persen / 100)), 2, MidpointRounding.AwayFromZero)


                    'If Me.DgvItemBudgetDetil.Rows(q).Cells("currency_id").Value = 1 Then '

                    '    pph_amount = Math.Round((((accum_advanceinter - advancedetil_discount) * advancedetil_foreignrate) * (pph_persen / 100)), 2, MidpointRounding.AwayFromZero)
                    '    ppn_amount = Math.Round((((accum_advanceinter - advancedetil_discount) * advancedetil_foreignrate) * (ppn_persen / 100)), 2, MidpointRounding.AwayFromZero)


                    'Else


                    '    pph_amount = Math.Round((((accum_advanceinter - advancedetil_discount)) * (pph_persen / 100)), 2, MidpointRounding.AwayFromZero)
                    '    ppn_amount = Math.Round((((accum_advanceinter - advancedetil_discount)) * (ppn_persen / 100)), 2, MidpointRounding.AwayFromZero)
                    '    '
                    '    ' amount_idrreal = ((amount_advance) + (amount_intercompany))
                    'End If


                    If Mid(Me.DgvRefOrder.Rows(q).Cells("order_id").Value, 1, 2) = "RO" Then
                        amount_subtotal = Math.Round(((amount_idrreal - (advancedetil_discount * advancedetil_foreignrate)) - pph_amount + ppn_amount), 2, MidpointRounding.AwayFromZero)
                    Else
                        amount_subtotal = Math.Round(((amount_idrreal - (advancedetil_discount * advancedetil_foreignrate)) - pph_amount + ppn_amount), 2, MidpointRounding.AwayFromZero)
                    End If

                    Dim total_ppnamount As Decimal

                    total_ppnamount += ppn_amount

                    amount_foreign = Math.Round(((accum_advanceinter - (advancedetil_discount)) - pph_amountforeign + ppn_amountforeign), 2, MidpointRounding.AwayFromZero)

                    amount += Math.Round(clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(q).Cells("amount_subtotal").Value, 0), 2, MidpointRounding.AwayFromZero)
                    amount_foreignreal += Math.Round(clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(q).Cells("amount_advance").Value, 0), 2, MidpointRounding.AwayFromZero)


                End If
            Next

            Me.obj_amount.Text = Format(amount, "#,##0.00")
            Me.obj_foreignreal.Text = Format(amount_foreignreal, "#,##0.00")

            If jumlah_over > 0 Then
                Me.DgvTrnAdvanceDetil.Rows(p).Cells("status_over").Value = "OVER"
            Else
                Me.DgvTrnAdvanceDetil.Rows(p).Cells("status_over").Value = "OK"
            End If
        Next
    End Function

    Private Function uiTransaksiAdvanceRequest_TotalOutstandingListST() As Boolean
        Dim oDataFiller As New clsDataFiller(Me.DSN)
        Dim f, h As Integer
        Dim jumlah_over As Integer
        Dim tbl_advance_bma As New DataTable
        Dim tbl_amount_st As New DataTable
        Dim tbl_trnBudget As DataTable = New DataTable
        Dim budget_id, budgetdetil_id As Decimal
        Dim tbl_amount_order As New DataTable
        Dim outstanding As Decimal
        Dim amount_order As Decimal


        For f = 0 To Me.DgvTrnAdvanceDetil.Rows.Count - 1
            jumlah_over = 0

            For h = 0 To Me.DgvItemBudgetDetil.Rows.Count - 1
                budget_id = clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(h).Cells("budget_id").Value, 0)
                budgetdetil_id = clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(h).Cells("budgetdetil_id").Value, 0)


                Try
                    tbl_advance_bma.Clear()

                    oDataFiller.DataFillAmountAdvance(tbl_advance_bma, "vq_TrnAdvanceItemDetil_ApprovedBma", budget_id, budgetdetil_id)
                    If tbl_advance_bma.Rows.Count > 0 Then
                        Me.DgvItemBudgetDetil.Rows(h).Cells("amount_approvebma").Value = clsUtil.IsDbNull(tbl_advance_bma.Rows(0)("amount_bma_approved"), 0)
                    Else
                        Me.DgvItemBudgetDetil.Rows(h).Cells("amount_approvebma").Value = clsUtil.IsDbNull(tbl_advance_bma.Columns("amount_bma_approved").DefaultValue, 0)
                    End If
                Catch ex As Exception
                    MsgBox("Test 4" & ex.Message)
                End Try

                Try
                    tbl_trnBudget.Clear()

                    oDataFiller.DataFill(tbl_trnBudget, "pr_TrnBudgetDetil_Select", String.Format("budget_id = {0} and budgetdetil_id = {1}", budget_id, budgetdetil_id))
                    If tbl_trnBudget.Rows.Count > 0 Then
                        Me.DgvItemBudgetDetil.Rows(h).Cells("amount_budget").Value = clsUtil.IsDbNull(tbl_trnBudget.Rows(0)("budgetdetil_amount"), 0)
                    Else
                        Me.DgvItemBudgetDetil.Rows(h).Cells("amount_budget").Value = clsUtil.IsDbNull(tbl_trnBudget.Columns("budgetdetil_amount").DefaultValue, 0)
                    End If
                Catch ex As Exception
                    MsgBox("Test 4" & ex.Message)
                End Try

                Try
                    tbl_amount_st.Clear()

                    oDataFiller.DataFillAmountAdvance(tbl_amount_st, "vq_TrnAdvanceItemDetil_AmountST", budget_id, budgetdetil_id)
                    If tbl_amount_st.Rows.Count > 0 Then
                        Me.DgvItemBudgetDetil.Rows(h).Cells("budget_accum").Value = clsUtil.IsDbNull(tbl_amount_st.Rows(0)("budget_accum"), 0)
                    Else
                        Me.DgvItemBudgetDetil.Rows(h).Cells("budget_accum").Value = clsUtil.IsDbNull(tbl_amount_st.Columns("budget_accum").DefaultValue, 0)
                    End If

                    tbl_amount_order.Clear()

                    oDataFiller.DataFillAmountAdvance(tbl_amount_order, "pr_TrnOrderdetil_AmtSum", budget_id, budgetdetil_id)
                    If tbl_amount_order.Rows.Count > 0 Then
                        amount_order = clsUtil.IsDbNull(tbl_amount_order.Rows(0)("amount_sum"), 0)
                    Else
                        amount_order = clsUtil.IsDbNull(tbl_amount_order.Columns("amount_sum").DefaultValue, 0)
                    End If

                    Me.DgvItemBudgetDetil.Rows(h).Cells("amount_sum").Value = amount_order

                Catch ex As Exception
                    MsgBox("Test 5" & ex.Message)
                End Try

                If Me.DgvItemBudgetDetil.Rows(h).Cells("advancedetil_line").Value = Me.DgvTrnAdvanceDetil.Rows(f).Cells("advancedetil_line").Value Then
                    '' ''If Me._SOURCE = "Reimburse Settlement" Then
                    Me.DgvItemBudgetDetil.Rows(h).Cells("outstanding_budget").Value = 0 ''''clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(h).Cells("amount_budget").Value, 0) - clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(h).Cells("amount_approvebma").Value, 0) - amount_order + clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(h).Cells("budget_accum").Value, 0)
                    '' ''Else
                    'Me.DgvItemBudgetDetil.Rows(h).Cells("outstanding_budget").Value = clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(h).Cells("amount_budget").Value, 0) - clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(h).Cells("amount_approvebma").Value, 0) - clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(h).Cells("amount_idrreal").Value, 0) + clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(h).Cells("budget_accum").Value, 0)
                    'Me.DgvItemBudgetDetil.Rows(h).Cells("outstanding_budget").Value = clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(h).Cells("amount_budget").Value, 0) - clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(h).Cells("amount_approvebma").Value, 0) - clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(h).Cells("amount_subtotal").Value, 0) + clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(h).Cells("budget_accum").Value, 0)
                    ''''Me.DgvItemBudgetDetil.Rows(h).Cells("outstanding_budget").Value = clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(h).Cells("amount_budget").Value, 0) - clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(h).Cells("amount_approvebma").Value, 0) - (clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(h).Cells("amount_idrreal").Value, 0) - (clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(h).Cells("advancedetil_discount").Value, 0) * clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(h).Cells("advancedetil_foreignrate").Value, 0))) + clsUtil.IsDbNull(Me.DgvItemBudgetDetil.Rows(h).Cells("budget_accum").Value, 0)
                    '' ''End If

                    outstanding = Me.DgvItemBudgetDetil.Rows(h).Cells("outstanding_budget").Value

                    If clsUtil.IsDbNull(Me.DgvTrnAdvanceDetil.Rows(f).Cells("advancedetil_approvedbma").Value, False) = 1 Then
                        Me.DgvItemBudgetDetil.Rows(h).Cells("outstanding_approved").Value = Me.tbl_TrnAdvanceItemDetil.Rows(h).Item("outstanding_approved")
                        Me.DgvItemBudgetDetil.Rows(h).Cells("outstanding_check").Value = True
                    Else
                        Me.DgvItemBudgetDetil.Rows(h).Cells("outstanding_approved").Value = outstanding ''''Me.DgvItemBudgetDetil.Rows(h).Cells("outstanding_budget").Value
                        Me.DgvItemBudgetDetil.Rows(h).Cells("outstanding_check").Value = False
                    End If

                    If Me.DgvItemBudgetDetil.Rows(h).Cells("outstanding_approved").Value < 0 Then
                        jumlah_over = jumlah_over + 1
                    End If
                End If
            Next

            If jumlah_over > 0 Then
                Me.DgvTrnAdvanceDetil.Rows(f).Cells("status_over").Value = "OVER"
            Else
                Me.DgvTrnAdvanceDetil.Rows(f).Cells("status_over").Value = "OK"
            End If

        Next
    End Function

    Private Sub code_budget_view()
        Dim rowIndex As Integer
        Dim substract As Integer
        Dim tbl_budget As DataTable = clsDataset.CreateTblTrnBudget

        If Me.DgvTrnAdvanceDetil.AllowUserToAddRows Then
            substract = 2
        Else
            substract = 1
        End If

        If Me.obj_budget_id_view.SelectedValue Is Nothing Then
            Me.obj_budget_id_view.SelectedValue = clsUtil.IsDbNull(Me.tbl_TrnAdvanceItemDetil.Columns("budget_id").DefaultValue, 0)
        End If

        For rowIndex = 0 To Me.DgvItemBudgetDetil.Rows.Count - substract
            Me.DgvItemBudgetDetil.Rows(rowIndex).Cells("budget_id").Value = Me.obj_budget_id_view.SelectedValue
        Next

        Me.tbl_TrnAdvanceItemDetil.Columns("budget_id").DefaultValue = Me.obj_budget_id_view.SelectedValue

        tbl_budget.Clear()
        Me.DataFill(tbl_budget, "pr_TrnBudget_Select", String.Format("budget_id = {0}", Me.obj_budget_id_view.SelectedValue))
        If tbl_budget.Rows.Count > 0 Then
            Me.obj_Advance_epsstart.Text = clsUtil.IsDbNull(tbl_budget.Rows(0).Item("budget_epsstart"), 0)
            Me.obj_Advance_epsend.Text = clsUtil.IsDbNull(tbl_budget.Rows(0).Item("budget_epsend"), 0)
        Else
            Me.obj_Advance_epsend.Text = 0
            Me.obj_Advance_epsstart.Text = 0
        End If
    End Sub

    Private Function uiTransaksiAdvanceRequest_PrintPreview() As Boolean
        If Me.DgvTrnAdvance.SelectedRows.Count <= 0 Then
            MsgBox("Belum ada data yang dipilih")
            Exit Function
        End If

        Dim advance_id As String
        Dim budget_id As Decimal

        advance_id = DgvTrnAdvance.CurrentRow.Cells("advance_id").Value
        budget_id = DgvTrnAdvance.CurrentRow.Cells("budget_id").Value

        Dim frmPrintAdvance As dlgTrnAdvancePrintListSPD = New dlgTrnAdvancePrintListSPD(Me.DSN, Me.SptServer, advance_id, Me._CHANNEL, budget_id)
        Dim criteria As String = String.Empty

        frmPrintAdvance.ShowInTaskbar = False
        frmPrintAdvance.StartPosition = FormStartPosition.CenterParent

        criteria = "  advance_id = '" & advance_id & "'"

        frmPrintAdvance.SetIDCriteria(criteria)
        frmPrintAdvance.ShowDialog(Me)
    End Function

    Private Function uiTransaksiAdvanceRequest_Print() As Boolean
        If Me.DgvTrnAdvance.SelectedRows.Count <= 0 Then
            MsgBox("Belum ada data yang dipilih")
            Exit Function
        End If

        'Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim oDataFiller As New clsDataFiller(Me.DSN)
        Dim advance_id As String
        Dim criteria As String = String.Empty
        Dim budget_id As Decimal

        advance_id = DgvTrnAdvance.CurrentRow.Cells("advance_id").Value
        budget_id = DgvTrnAdvance.CurrentRow.Cells("budget_id").Value

        Dim realization As Decimal = Me.GetRealization(budget_id)

        Me.tbl_TrnAdvance.Clear()
        Me.tbl_TrnAdvanceDetil.Clear()
        criteria = "  advance_id = '" & advance_id & "'"
        oDataFiller.DataFill(Me.tbl_TrnAdvance, "vq_RptAdvance_Select", criteria)

        If Me.tbl_TrnAdvance.Rows.Count = 0 Then
            MsgBox("No data")
            Exit Function
        End If

        Dim objRdsH As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Dim objReportH As Microsoft.Reporting.WinForms.LocalReport = New Microsoft.Reporting.WinForms.LocalReport
        Dim objRdsD As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Dim objReportD As Microsoft.Reporting.WinForms.LocalReport = New Microsoft.Reporting.WinForms.LocalReport
        Dim objDatalistHeader As ArrayList = New ArrayList()
        Dim objReportViewer As Microsoft.Reporting.WinForms.ReportViewer = New Microsoft.Reporting.WinForms.ReportViewer

        objDatalistHeader = Me.GenerateDataHeader()

        Dim parRptImageURL As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("imageURL", Me.SptServer)
        Dim parRptChannelID As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("channelID", Me._CHANNEL)
        Dim parRptChannel_namereport As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("channelName", Me.sptChannel_nameReport)
        Dim parRptChannel_address As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("channelAddress", Me.sptChannel_address)
        Dim parRptID As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("id", Me.id)
        Dim parRptDomain As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("p_domain_name", Me.sptDomain)
        Dim parRptRealization As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("p_realization", realization)
        Dim parRptApproved1By As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("p_approved1by", approved1_by)
        Dim parRptApproved2By As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("p_approved2by", approved2_by)
        Dim parRptTitleApp1 As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("p_titleapp1", titleapp1)
        Dim parRptTitleApp2 As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("p_titleapp2", titleapp2)

        Dim parRptApproved3By As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("p_approved3by", approved3_by)
        Dim parRptTitleApp3 As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("p_titleapp3", titleapp3)

        objRdsH.Name = "NewAdvance_DataSource_ClsRptAdvanceHeader"

        objRdsH.Value = objDatalistHeader


        objReportH.ReportEmbeddedResource = "NewAdvance.rptAdvancePrint_HeaderListSPD.rdlc"
        objReportH.DataSources.Add(objRdsH)



        objReportH.EnableExternalImages = True

        objReportH.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter() {parRptImageURL, parRptChannelID, parRptChannel_namereport, parRptChannel_address, parRptID, parRptDomain, parRptRealization, parRptApproved1By, parRptApproved2By, parRptTitleApp1, parRptTitleApp2, parRptApproved3By, parRptTitleApp3})
        AddHandler objReportH.SubreportProcessing, AddressOf SubreportProcessing

        Using report As New clsQuickPrint(objReportH)
            report.Print()
        End Using

        'Export(objReportH)

        'm_currentPageIndex = 0
        'Print()
    End Function

    Private Sub Export(ByVal report As Microsoft.Reporting.WinForms.LocalReport)
        Dim deviceInfo As String = _
          "<DeviceInfo>" & _
        "  <OutputFormat>EMF</OutputFormat>" & _
        "  <PageWidth>8.5in</PageWidth>" & _
        "  <PageHeight>11 in</PageHeight>" & _
        "  <MarginTop>0.2in</MarginTop>" & _
        "  <MarginLeft>0.1in</MarginLeft>" & _
        "  <MarginRight>0.01in</MarginRight>" & _
        "  <MarginBottom>0.2in</MarginBottom>" & _
        "</DeviceInfo>"
        Dim warnings() As Microsoft.Reporting.WinForms.Warning = Nothing
        m_streams = New List(Of System.IO.Stream)()
        'Try
        report.Render("Image", deviceInfo, AddressOf CreateStream, warnings)

        Dim stream As System.IO.Stream
        For Each stream In m_streams
            stream.Position = 0
        Next

        'Catch ex As Exception
        'MsgBox("Cannot print the document directly. " & ex.Message & vbCrLf & vbCrLf & _
        ' "                                   Please use the PrintPreview metode.")

        'End Try
    End Sub

    Private Function CreateStream(ByVal name As String, _
       ByVal fileNameExtension As String, _
       ByVal encoding As System.Text.Encoding, ByVal mimeType As String, _
       ByVal willSeek As Boolean) As System.IO.Stream
        Dim stream As System.IO.Stream = _
            New System.IO.FileStream(AppDomain.CurrentDomain.BaseDirectory & "Temp\" + _
             name + "." + fileNameExtension, System.IO.FileMode.Create)
        m_streams.Add(stream)
        Return stream
    End Function

    Private Sub Print()
        Dim printerName As String = ""
        Dim aPrinterSettings As New System.Drawing.Printing.PrinterSettings

        printerName = aPrinterSettings.PrinterName

        If m_streams Is Nothing Or m_streams.Count = 0 Then
            Return
        End If

        Dim printDoc As New System.Drawing.Printing.PrintDocument()
        printDoc.PrinterSettings.PrinterName = printerName
        If Not printDoc.PrinterSettings.IsValid Then
            Dim msg As String = String.Format( _
                "Can't find printer ""{0}"".", printerName)
            Console.WriteLine(msg)
            Return
        End If
        AddHandler printDoc.PrintPage, AddressOf PrintPage

        printDoc.Print()
        m_streams.Clear()
    End Sub

    Private Sub PrintPage(ByVal sender As Object, _
    ByVal ev As System.Drawing.Printing.PrintPageEventArgs)
        Dim pageImage As New System.Drawing.Imaging.Metafile(m_streams(m_currentPageIndex))
        ev.Graphics.DrawImage(pageImage, ev.PageBounds)

        m_currentPageIndex += 1
        ev.HasMorePages = (m_currentPageIndex < m_streams.Count)
    End Sub

    Private Function GenerateDataHeader() As ArrayList
        Dim objDatalistHeader As ArrayList = New ArrayList()
        Dim oDataFiller As New clsDataFiller(Me.DSN)
        Dim tbl_approved As DataTable = New DataTable

        Dim criteria2 As String
        Dim i As Integer

        objPrintHeader = New DataSource.ClsRptAdvanceHeader(Me.DSN)
        With objPrintHeader

            criteria2 = String.Format("advance_id='{0}'", Me.tbl_TrnAdvance.Rows(0).Item("advance_id"))

            .ref_no = clsUtil.IsDbNull(Me.tbl_TrnAdvance.Rows(i).Item("advance_id"), String.Empty)
            .request_date = clsUtil.IsDbNull(Me.tbl_TrnAdvance.Rows(i).Item("advance_entrydt"), String.Empty)
            .request_by = clsUtil.IsDbNull(Me.tbl_TrnAdvance.Rows(i).Item("advance_usedby"), String.Empty)
            .payment_to = clsUtil.IsDbNull(Me.tbl_TrnAdvance.Rows(i).Item("advance_userpic"), String.Empty)
            .payment_address = clsUtil.IsDbNull(Me.tbl_TrnAdvance.Rows(i).Item("advance_prepareloc"), String.Empty)
            .Budget_id = clsUtil.IsDbNull(Me.tbl_TrnAdvance.Rows(i).Item("budget_id"), 0)
            .channel_id = clsUtil.IsDbNull(Me.tbl_TrnAdvance.Rows(i).Item("channel_id"), String.Empty)
            '.adv_req = clsUtil.IsDbNull(Me.tbl_TrnAdvance.Rows(i).Item("advance_idrreal"), String.Empty)

            .eps_start = clsUtil.IsDbNull(Me.tbl_TrnAdvance.Rows(i).Item("advance_epsstart"), String.Empty)
            .eps_end = clsUtil.IsDbNull(Me.tbl_TrnAdvance.Rows(i).Item("advance_epsend"), String.Empty)


            .Department = clsUtil.IsDbNull(Me.tbl_TrnAdvance.Rows(i).Item("strukturunit_name"), String.Empty)
            .Program = clsUtil.IsDbNull(Me.tbl_TrnAdvance.Rows(i).Item("budget_name"), String.Empty)
            .currency_name = clsUtil.IsDbNull(Me.tbl_TrnAdvance.Rows(i).Item("currency_shortname"), String.Empty)
            .Budget_name = clsUtil.IsDbNull(Me.tbl_TrnAdvance.Rows(i).Item("budget_name"), String.Empty)
            .budget_amount = clsUtil.IsDbNull(Me.tbl_TrnAdvance.Rows(i).Item("budget_amount"), String.Empty)

            .rekanan_id = clsUtil.IsDbNull(Me.tbl_TrnAdvance.Rows(i).Item("rekanan_name"), String.Empty)

            .Payment_type = clsUtil.IsDbNull(Me.tbl_TrnAdvance.Rows(i).Item("paymenttype_name"), String.Empty)

            .Payment_date = clsUtil.IsDbNull(Me.tbl_TrnAdvance.Rows(i).Item("advance_preparedt"), String.Empty)

            tbl_approved.Clear()
            tbl_approved = Me.getApprovedFromTravel(clsUtil.IsDbNull(Me.tbl_TrnAdvance.Rows(i).Item("advance_id"), String.Empty))

            Me.approved1_by = tbl_approved.Rows(0).Item("approved1_by")
            Me.approved2_by = tbl_approved.Rows(0).Item("approved2_by")
            Me.titleapp1 = tbl_approved.Rows(0).Item("titleapp1")
            Me.titleapp2 = tbl_approved.Rows(0).Item("titleapp2")

            Me.approved3_by = tbl_approved.Rows(0).Item("approved3_by")
            Me.titleapp3 = tbl_approved.Rows(0).Item("titleapp3")

            Me.id = .ref_no
            Me.total_amount = .adv_req
            Me.strchannel_id = .channel_id
            Me.sptChannel_nameReport = .channel_namereport
            Me.sptChannel_address = .channel_address
            Me.sptDomain = .domain_name

            oDataFiller.DataFill(Me.tbl_TrnAdvanceDetil, "vq_TrnAdvanceDetil_Select", criteria2)
            GenerateDataDetail()

            .adv_req = Me.adv_req
            .balance = .budget_amount - .adv_req


        End With
        objDatalistHeader.Add(objPrintHeader)

        Return objDatalistHeader
    End Function

    Private Function GenerateDataDetail() As ArrayList
        Dim oDataFiller As New clsDataFiller(Me.DSN)
        Dim tbl_departement_temp As DataTable = New DataTable
        Dim tbl_program_temp As DataTable = New DataTable
        Dim tbl_currency As DataTable = New DataTable
        Dim tbl_budget As DataTable = New DataTable
        Dim amount_real, pph_amount, ppn_amount, subtotal, total_pphamount, total_ppnamount, total_subtotal, total_discount As Decimal
        'Dim amount_intercompany As Decimal
        Dim i, k As Integer
        Dim no As Integer = 1
        Dim pph_persen, ppn_persen, amount_advance, advancedetil_discount, advancedetil_foreignrate As Decimal
        Dim amount_intercompay As Decimal
        Dim budget_amountdetail As Decimal
        Dim Budget_amountforeign As Decimal
        Dim currency As Decimal
        Dim total_discountAdv As Decimal = 0

        objDatalistDetil = New ArrayList()


        For i = 0 To Me.tbl_TrnAdvanceDetil.Rows.Count - 1
            objPrintDetil = New DataSource.ClsRptAdvanceDetil(Me.DSN)

            With objPrintDetil
                .no = no
                .descr = clsUtil.IsDbNull(Me.tbl_TrnAdvanceDetil.Rows(i).Item("advancedetil_descr"), String.Empty)
                .budget_amountdetail = clsUtil.IsDbNull(Me.tbl_TrnAdvanceDetil.Rows(i).Item("advancedetil_idrreal"), 0)
                .Budget_amountforeign = clsUtil.IsDbNull(Me.tbl_TrnAdvanceDetil.Rows(i).Item("advancedetil_foreignreal"), 0)
                .rate = clsUtil.IsDbNull(Me.tbl_TrnAdvanceDetil.Rows(i).Item("advancedetil_foreignrate"), 0)
                .currency = clsUtil.IsDbNull(Me.tbl_TrnAdvanceDetil.Rows(i).Item("currency_id"), 0)
                .total_amount = Me.total_amount
                .amount_intercompany = clsUtil.IsDbNull(Me.tbl_TrnAdvanceDetil.Rows(i).Item("amount_intercompany_sum"), 0)
                amount_intercompay = .amount_intercompany

                If clsUtil.IsDbNull(Me.tbl_TrnAdvanceDetil.Rows(i).Item("advancedetil_type"), String.Empty) = 1 Then

                    total_pphamount = 0
                    total_ppnamount = 0
                    total_subtotal = 0
                    total_discount = 0

                    ''''Me.tbl_TrnAdvanceItemDetil.Clear()
                    ''''oDataFiller.DataFill(Me.tbl_TrnAdvanceItemDetil, "vq_TrnAdvanceItemDetil_Selects", String.Format("a.advance_id='{0}' and a.advancedetil_line={1}", Me.tbl_TrnAdvanceDetil.Rows(i).Item("advance_id"), Me.tbl_TrnAdvanceDetil.Rows(i).Item("advancedetil_line")))
                    Me.tbl_PrintAdvanceListOrderDetil.Clear()
                    oDataFiller.DataFill(Me.tbl_PrintAdvanceListOrderDetil, "vq_TrnPrintAdvanceListOrder_Select", String.Format("advance_id='{0}' and advancedetil_line={1}", Me.tbl_TrnAdvanceDetil.Rows(i).Item("advance_id"), Me.tbl_TrnAdvanceDetil.Rows(i).Item("advancedetil_line")))

                    For k = 0 To Me.tbl_PrintAdvanceListOrderDetil.Rows.Count - 1

                        If Mid(Me.tbl_PrintAdvanceListOrderDetil.Rows(k).Item("order_id"), 1, 2) = "RO" Then
                            advancedetil_discount = clsUtil.IsDbNull(Me.tbl_PrintAdvanceListOrderDetil.Rows(k).Item("advancedetil_discount"), 0)
                        Else
                            If clsUtil.IsDbNull(Me.tbl_PrintAdvanceListOrderDetil.Rows(k).Item("advancedetil_discount"), 0) = (clsUtil.IsDbNull(Me.tbl_PrintAdvanceListOrderDetil.Rows(k).Item("advancedetil_discount"), 0) * clsUtil.IsDbNull(Me.tbl_PrintAdvanceListOrderDetil.Rows(k).Item("orderdetil_qty"), 0)) Then
                                advancedetil_discount = Math.Round(clsUtil.IsDbNull(Me.tbl_PrintAdvanceListOrderDetil.Rows(k).Item("advancedetil_discount"), 0), 0, MidpointRounding.ToEven)
                            Else
                                advancedetil_discount = (clsUtil.IsDbNull(Me.tbl_PrintAdvanceListOrderDetil.Rows(k).Item("advancedetil_discount"), 0) * clsUtil.IsDbNull(Me.tbl_PrintAdvanceListOrderDetil.Rows(k).Item("orderdetil_qty"), 0))
                            End If
                        End If

                        amount_real = (clsUtil.IsDbNull(Me.tbl_PrintAdvanceListOrderDetil.Rows(k).Item("amount_advance"), 0) _
                       * clsUtil.IsDbNull(Me.tbl_PrintAdvanceListOrderDetil.Rows(k).Item("advancedetil_foreignrate"), 0)) _
                       - (advancedetil_discount * _
                       clsUtil.IsDbNull(Me.tbl_PrintAdvanceListOrderDetil.Rows(k).Item("advancedetil_foreignrate"), 0))

                        pph_persen = clsUtil.IsDbNull(Me.tbl_PrintAdvanceListOrderDetil.Rows(k).Item("pph_persen"), 0)
                        ppn_persen = clsUtil.IsDbNull(Me.tbl_PrintAdvanceListOrderDetil.Rows(k).Item("ppn_persen"), 0)
                        amount_advance = clsUtil.IsDbNull(Me.tbl_PrintAdvanceListOrderDetil.Rows(k).Item("amount_advance"), 0)
                        ''''advancedetil_discount = clsUtil.IsDbNull(Me.tbl_PrintAdvanceListOrderDetil.Rows(k).Item("advancedetil_discount"), 0)
                        advancedetil_foreignrate = clsUtil.IsDbNull(Me.tbl_PrintAdvanceListOrderDetil.Rows(k).Item("advancedetil_foreignrate"), 0)
                        pph_amount = Math.Round((((amount_advance - advancedetil_discount) * (pph_persen / 100)) * advancedetil_foreignrate), 2, MidpointRounding.AwayFromZero)
                        ppn_amount = Math.Round((((amount_advance - advancedetil_discount) * (ppn_persen / 100)) * advancedetil_foreignrate), 2, MidpointRounding.AwayFromZero)

                        subtotal = clsUtil.IsDbNull(Me.tbl_PrintAdvanceListOrderDetil.Rows(k).Item("amount_subtotal"), 0) ''''(amount_real + amount_intercompay) + ppn_amount - pph_amount
                        total_pphamount += pph_amount
                        total_ppnamount += ppn_amount
                        total_subtotal += subtotal
                        total_discount += advancedetil_discount ''''clsUtil.IsDbNull(Me.tbl_PrintAdvanceListOrderDetil.Rows(k).Item("advancedetil_discount"), 0)
                        total_discountAdv += advancedetil_discount

                    Next

                    budget_amountdetail += .budget_amountdetail
                    Budget_amountforeign += .Budget_amountforeign

                    currency = .currency

                    'If .currency <> 1 Then
                    '    total_pphamount = total_pphamount / .rate
                    '    total_ppnamount = total_ppnamount / .rate
                    '    'total_discount = total_discount / .rate
                    '    total_subtotal = total_subtotal / .rate
                    '    'Me.adv_req = (.Budget_amountforeign - total_discount) * advancedetil_foreignrate
                    'Else
                    '    'Me.adv_req = (.budget_amountdetail - total_discount)
                    'End If

                ElseIf clsUtil.IsDbNull(Me.tbl_TrnAdvanceDetil.Rows(i).Item("advancedetil_type"), String.Empty) = 0 Then

                    total_pphamount = 0
                    total_ppnamount = 0
                    total_subtotal = 0
                    total_discount = 0

                End If

                .total_discount = total_discount
                .total_pphamount = total_pphamount
                .total_ppnamount = total_ppnamount
                .total_subtotal = total_subtotal
                no = no + 1
            End With
            objDatalistDetil.Add(objPrintDetil)
        Next

        If currency <> 1 Then
            Me.adv_req = (Budget_amountforeign - total_discountAdv) * advancedetil_foreignrate
        Else
            Me.adv_req = (budget_amountdetail - total_discountAdv)

        End If

        Return objDatalistDetil
    End Function

    Public Sub SubreportProcessing(ByVal sender As Object, ByVal e As Microsoft.Reporting.WinForms.SubreportProcessingEventArgs)
        e.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("NewAdvance_DataSource_ClsRptAdvanceDetil", objDatalistDetil))
    End Sub

    'buat narik budget
    Public Function DataFillLimit1(ByRef datatable As DataTable, ByVal procedure As String, ByVal channel_id As String, ByVal criteria As String) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        dbCmd = New OleDb.OleDbCommand(procedure, dbConn)
        If channel_id <> "" Then
            dbCmd.Parameters.Add("@channel_id", Data.OleDb.OleDbType.VarChar)
            dbCmd.Parameters("@channel_id").Value = channel_id
        End If
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@Criteria").Value = criteria

        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)

        Dim cookie As Byte() = Nothing

        Try
            dbConn.Open()
            clsApplicationRole.SetAppRole(dbConn, cookie)
            dbDA.Fill(datatable)
        Catch ex As Exception
            Throw ex
        Finally
            clsApplicationRole.UnsetAppRole(dbConn, cookie)
            dbConn.Close()
        End Try

        Return True

    End Function

    Private Sub obj_payment_type_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles obj_payment_type.SelectionChangeCommitted
        Dim a As Integer
        Dim payment_type As String

        payment_type = Me.obj_payment_type.SelectedValue

        If Me.DgvTrnAdvanceDetil.Rows.Count > 0 Then
            For a = 0 To Me.DgvTrnAdvanceDetil.Rows.Count - 1
                Me.DgvTrnAdvanceDetil.Rows(a).Cells("advancedetil_paymenttype").Value = payment_type
            Next
        End If
    End Sub

    Private Sub obj_rekanan_id_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles obj_rekanan_id.SelectionChangeCommitted
        Dim tbl_rekanan As DataTable = clsDataset.CreateTblMstRekanan
        Dim rekananAddress, rekanan_address2, rekanan_telp, rekanan_fax As String
        Dim criteria As String = ""
        Dim txtSearchCriteria As String = ""
        Dim txtCondition As String = ""

        Dim rekanan_id As Decimal

        rekanan_id = Me.obj_rekanan_id.SelectedValue


        tbl_rekanan.Clear()

        Me.DataFill(tbl_rekanan, "ms_MstRekanan_Select", String.Format("rekanan_id = {0}", rekanan_id))

        If tbl_rekanan.Rows.Count > 0 Then
            'ms_MstRekananAddress_Select
            rekananAddress = Trim(clsUtil.IsDbNull(tbl_rekanan.Rows(0).Item("rekanan_address").ToString, String.Empty))
            rekanan_address2 = Trim(clsUtil.IsDbNull(tbl_rekanan.Rows(0).Item("rekanan_address2").ToString, String.Empty))
            rekanan_telp = Trim(clsUtil.IsDbNull(tbl_rekanan.Rows(0).Item("rekanan_telp").ToString, String.Empty))
            rekanan_fax = Trim(clsUtil.IsDbNull(tbl_rekanan.Rows(0).Item("rekanan_fax").ToString, String.Empty))
        Else
            rekananAddress = String.Empty
            rekanan_address2 = String.Empty
            rekanan_telp = String.Empty
            rekanan_fax = String.Empty
            Me.obj_payment_addr.Text = String.Empty
        End If

        If rekananAddress <> String.Empty Then
            If txtCondition = "" Then
                txtCondition = rekananAddress
            Else
                txtCondition = txtCondition & rekananAddress
            End If
        End If

        '-- OrderID
        If rekanan_address2 <> String.Empty Then
            If txtCondition = "" Then
                txtCondition = rekanan_address2
            Else
                txtCondition = txtCondition & " " & rekanan_address2
            End If
        End If

        If rekanan_telp <> String.Empty Then
            If txtCondition = "" Then
                txtCondition = rekanan_telp
            Else
                txtCondition = txtCondition & " Telp. " & rekanan_telp
            End If
        End If

        If rekanan_fax <> String.Empty Then
            If txtCondition = "" Then
                txtCondition = rekanan_fax
            Else
                txtCondition = txtCondition & " Fax. " & rekanan_fax
            End If
        End If

        criteria = txtCondition

        Me.obj_payment_addr.Text = criteria
    End Sub

#Region "mencoba tuning (yanuar)"

#Region " Untuk BackgroundWorker"
    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Dim BG_Worker As BackgroundWorker = CType(sender, BackgroundWorker)
        ' ''Dim AddToComboSearch As System.Delegate = New delegate_UpdateUI(AddressOf uiTrnSalesOrder_CollectionData_with_BackgroundWorker)
        If BG_Worker.CancellationPending Then
            e.Cancel = True
        Else
            Me.uiTrnJurnal_CollectionData_with_BackgroundWorker(BG_Worker)
            ' ''Invoke(AddToComboSearch, BG_Worker)         
        End If
    End Sub
    Private Sub BackgroundWorker1_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        obj_ProgressBar_backGroundWorker.Value = e.ProgressPercentage
        Me.lblLoading.Text = "Please Wait... Loading data " & Me.label_thread & "..."
    End Sub
    Private Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        'Untuk Finishing BackgroundWorker
        Me.obj_ProgressBar_backGroundWorker.Visible = False
        Me.lblLoading.Visible = False
        Me.Panel11.Visible = False

        Me.FormatDgvTrnAdvance(Me.DgvTrnAdvance)
        Me.FormatDgvTrnAdvanceDetil(Me.DgvTrnAdvanceDetil)
        Me.FormatDgvTrnAdvanceItemDetil(Me.DgvItemBudgetDetil)
        Me.FormatDgvTrnRefOrder(Me.DgvRefOrder)

        For Each tsItem As ToolStripItem In Me.ToolStrip1.Items
            If tsItem.GetType.ToString = "System.Windows.Forms.ToolStripSeparator" Or (tsItem.Name = "tbtnSave") Or (tsItem.Name = "tbtnDel") Then
                tsItem.Enabled = False
            Else
                tsItem.Enabled = True
            End If
        Next

        Me.Cursor = Cursors.Arrow

    End Sub

    Public Sub uiTrnJurnal_newBackgroundWorker()
        Me.BackgroundWorker1 = New BackgroundWorker
        BackgroundWorker1.RunWorkerAsync()
    End Sub

    Private Sub uiTrnJurnal_CollectionData_with_BackgroundWorker(ByVal worker As BackgroundWorker)
        Dim oDataFiller As New clsDataFiller(Me.DSN)

        worker.WorkerReportsProgress = True
        Me.label_thread = "Rekanan"
        worker.ReportProgress(0)

        '===============REMARK BY PTS Me.obj_Advance_usedby--> NGAMBIL DARI USER NAME FULL======== 20141003 ==================================================
        'Me.ComboFill(Me.obj_Advance_usedby, "rekanan_name", "rekanan_name", Me.tbl_RekananUseBy, "ms_MstRekanan_Select2", "rekanantype_id = 7", Me._CHANNEL)
        'Me.tbl_RekananUseBy.DefaultView.Sort = "rekanan_name"
        '=====================================================================================================================================================


        Me.ComboFill(Me.obj_rekanan_id, "rekanan_id", "rekanan_name", Me.tbl_MstRekanan, "ms_MstRekanan_Select2", "", Me._CHANNEL)
        Me.tbl_MstRekanan.DefaultView.Sort = "rekanan_name"

        Me.label_thread = "Budget"
        worker.ReportProgress(50)
        Me.ComboFill(Me.obj_budget_id_view, "budget_id", "budget_nameshort", Me.tbl_TrnBudget, "ms_TrnBudgetCombo_Select", "budget_isactive = 1 and channel_id = '" & Me._CHANNEL & "' ")
        Me.tbl_TrnBudgetMain = Me.tbl_TrnBudget.Copy
        Me.tbl_TrnBudgetSearch = Me.tbl_TrnBudget.Copy
        Me.tbl_TrnBudget.DefaultView.Sort = "budget_nameshort"
        Me.tbl_TrnBudgetMain.DefaultView.Sort = "budget_nameshort"
        Me.tbl_TrnBudgetSearch.DefaultView.Sort = "budget_nameshort"

        Me.label_thread = "Account"
        worker.ReportProgress(75)
        oDataFiller.DataFillForCombo("acc_id", "acc_nameshort", Me.tbl_MstAcc, "ms_MstAccountCombo_Select", " acc_isdisabled = 0 ")
        Me.tbl_MstAcc.DefaultView.Sort = "acc_nameshort"

        worker.ReportProgress(100)

    End Sub

    Private Sub uiTrnJurnal_isBackgroudWorker()

        Me.Cursor = Cursors.WaitCursor
        If Me.isBackGroundWorker_isWork = False Then
            Me.isBackGroundWorker_isWork = True
            If Me.isBackgroundWorker = False Then

                Me.Panel11.Visible = True
                Me.obj_ProgressBar_backGroundWorker.Value = 0
                Me.obj_ProgressBar_backGroundWorker.Visible = True
                Me.lblLoading.Visible = True

                If Me.BackgroundWorker1.IsBusy Then
                    Me.BackgroundWorker1.Dispose()
                    Me.uiTrnJurnal_newBackgroundWorker()
                Else
                    Me.BackgroundWorker1.RunWorkerAsync()
                End If
                Me.isBackgroundWorker = True
            End If
        End If
        Me.Cursor = Cursors.Arrow
    End Sub
#End Region

#End Region

    Private Sub btn_Budget_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Budget.Click
        '' ''Dim budget_id As String
        '' ''Dim dlg As dlgSearch = New dlgSearch()
        '' ''Dim retData As String
        '' ''retData = dlg.OpenDialog(Me, Me.tbl_TrnBudgetSearch, "budget")
        '' ''budget_id = retData

        '' ''If budget_id IsNot Nothing Then
        '' ''    Me.objSrchBudget.Text = budget_id
        '' ''End If

        Dim dlg As dlgSearch = New dlgSearch()
        Dim retData As Collection
        Dim retObj As Object
        Dim budget_id As String

        retObj = dlg.OpenDialog(Me, Me.tbl_TrnBudgetSearch, "budget")
        If retObj IsNot Nothing Then
            retData = CType(retObj, Collection)
            budget_id = CType(retData.Item("retId"), Decimal)
            Me.objSrchBudget.Text = budget_id
        End If
    End Sub

    Private Function uiTrnAdvanceRequestListOrder_UpdateAfterCanceled(ByRef dbconn As OleDb.OleDbConnection, ByRef dbtrans As OleDb.OleDbTransaction) As Boolean
        Dim query As String = String.Empty
        Dim i As Integer
        Dim advance_id As String = String.Empty
        Dim order_id As String = String.Empty
        Dim advancedetil_line, budgetdetil_line, orderdetil_line As Integer

        Try
            For i = 0 To Me.DgvRefOrder.Rows.Count - 1
                advance_id = Me.DgvRefOrder.Rows(i).Cells("advance_id").Value
                advancedetil_line = Me.DgvRefOrder.Rows(i).Cells("advancedetil_line").Value
                budgetdetil_line = Me.DgvRefOrder.Rows(i).Cells("budgetdetil_line").Value
                order_id = Me.DgvRefOrder.Rows(i).Cells("order_id").Value
                orderdetil_line = Me.DgvRefOrder.Rows(i).Cells("orderdetil_line").Value

                If Me.obj_Request_active.Checked = True Then
                    If advance_id <> String.Empty Then
                        Try
                            ''''dbConn.Open()
                            Dim oCm As New OleDb.OleDbCommand("lq_TrnTraveladvanceCanceled_Update", dbconn, dbtrans)
                            oCm.CommandType = CommandType.StoredProcedure
                            oCm.Parameters.Add("@advance_id", System.Data.OleDb.OleDbType.VarWChar, 30).Value = advance_id
                            oCm.Parameters.Add("@advancedetil_line", System.Data.OleDb.OleDbType.Integer, 4).Value = advancedetil_line
                            oCm.Parameters.Add("@budgetdetil_line", System.Data.OleDb.OleDbType.Integer, 4).Value = budgetdetil_line
                            oCm.Parameters.Add("@order_id", System.Data.OleDb.OleDbType.VarWChar, 100).Value = order_id
                            oCm.Parameters.Add("@orderdetil_line", System.Data.OleDb.OleDbType.Integer, 4).Value = orderdetil_line

                            oCm.ExecuteNonQuery()
                            oCm.Dispose()
                        Catch ex As Exception
                            MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Return False
                        Finally
                            ''''dbConn.Close()
                        End Try

                    End If
                End If
            Next

        Catch ex As Data.OleDb.OleDbException
            MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Catch ex As Exception
            MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Finally
            ''''dbConn.Close()
        End Try

        Me.uiTransaksiAdvanceRequest_OpenRow(dbconn, dbtrans, Me.DgvTrnAdvance.CurrentRow.Index)
        Return True
    End Function

    Private Sub btn_Rekanan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Rekanan.Click
        Dim dlg As dlgSearch = New dlgSearch()
        Dim retData As Collection
        Dim retObj As Object
        Dim rekanan_id As Decimal

        retObj = dlg.OpenDialog(Me, Me.tbl_MstRekanan, "rekanan")
        If retObj IsNot Nothing Then
            retData = CType(retObj, Collection)
            rekanan_id = CType(retData.Item("retId"), Decimal)
            Me.txtSearchRekananID.Text = rekanan_id
        End If
    End Sub

    Private Function GetRealization(ByVal budget_id As String) As Decimal
        Dim dbConn As New OleDb.OleDbConnection(Me.DSN)
        Dim cmd As OleDb.OleDbCommand
        Dim res As Decimal
        Dim cookie As Byte() = Nothing

        Try
            dbConn.Open()
            clsApplicationRole.SetAppRole(dbConn, cookie)
            cmd = New OleDb.OleDbCommand("vq_RptBudgetRealization", dbConn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@channel_id", OleDb.OleDbType.VarWChar, 10).Value = Me._CHANNEL
            cmd.Parameters.Add("@budget_id", OleDb.OleDbType.Numeric, 8).Value = budget_id

            res = cmd.ExecuteScalar()

            Return res
        Catch ex As Exception
            Throw ex
        Finally
            If dbConn.State = ConnectionState.Open Then
                clsApplicationRole.UnsetAppRole(dbConn, cookie)
                dbConn.Close()
            End If
        End Try
    End Function

    Private Sub SplitUnsplitAmountToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SplitUnsplitAmountToolStripMenuItem.Click
        Dim isSplit As Boolean = True
        Dim Advance_id As String
        'Dim i As Integer
        'Dim columnName, columnName_eps As String
        'Dim row, row_eps As DataRow
        'Dim line_temps, budgetdetil_line_temps As Integer

        'Dim foreign_real, idr_real, total As Decimal
        'Dim foreign_real2, idr_real2, total2 As Decimal
        'Dim amount_idrreal, amount_advance, amount_subtotalforeign, amount_subtotal As Decimal

        Dim line, description, currency As String
        Dim amount, rate, subtotal As Decimal

        Dim tbl_cur As DataTable = New DataTable
        Dim tbl_temp_AdvanceItemDetil As DataTable = New DataTable
        Dim tbl_temp_AdvanceItemDetilEps As DataTable = New DataTable
        Dim tbl_temp_AdvanceDetil As DataTable = New DataTable
        Dim tbl_temp_AdvanceItemDetil2 As DataTable = New DataTable
        Dim currLine As Integer
        'Dim amount_advance2, amount_idrreal2, amount_subtotalforeign2, amount_subtotal2 As Decimal

        Advance_id = Me.DgvTrnAdvanceDetil.CurrentRow.Cells("advance_id").Value
        currLine = Me.DgvTrnAdvanceDetil.CurrentRow.Cells("advancedetil_line").Value

        Dim tbl_cekPV As DataTable = New DataTable()
        tbl_cekPV.Clear()
        DataFill(tbl_cekPV, "vq_TrnAdvanceRefPV_Select", String.Format("b.advancedetil_ordered = 1 AND b.advancedetil_refreference != '' AND a.jurnal_id_ref = '{0}' AND (a.jurnal_id_refline >= '{1}' AND a.jurnal_id_refline <= '{2}') ", Advance_id, currLine, currLine + 9))

        If Me.DgvTrnAdvanceDetil.CurrentRow.Cells("advancedetil_type").Value = 0 Then
            MsgBox("Sorry, Description cannot Split or Unsplit", MsgBoxStyle.Critical, "Critical")
            Exit Sub
        End If

        '=============================CEK Boleh di split atau tidak ==================
        If Strings.Right(currLine, 1) <> 0 Then
            MsgBox("Sorry cannot split this line")
            Exit Sub
        End If

        For g As Integer = 0 To Me.tbl_TrnAdvanceDetil.Rows.Count - 1
            If Me.tbl_TrnAdvanceDetil.Rows(g).Item("Advance_id") = Advance_id And Me.tbl_TrnAdvanceDetil.Rows(g).Item("advancedetil_line") = currLine + 1 Then
                isSplit = False
                Exit For
                'Else
                '    If Me.tbl_TrnAdvanceDetil.Rows(g).Item("Advance_id") = Advance_id And Me.tbl_TrnAdvanceDetil.Rows(g).Item("advancedetil_line") = currLine Then
                '        isSplit = True
                '        Exit For
                '    End If

            End If
        Next
        '=============================================================================

        '====================================================================================================================================================
        If isSplit = True Then '================== Di Split ==========================
            'If Me.tbl_TrnAdvanceRefPV.Rows.Count <> 0 Then
            '    For f As Integer = 0 To Me.tbl_TrnAdvanceRefPV.Rows.Count - 1
            '        If Me.tbl_TrnAdvanceRefPV.Rows(f).Item("advance_id") = Advance_id And Me.tbl_TrnAdvanceRefPV.Rows(f).Item("jurnal_id_refline") = currLine Then
            '            MsgBox("Cannot split, because this line have a PV", MsgBoxStyle.Critical, "Critical")
            '            Exit Sub
            '        End If
            '    Next
            'End If
            '==============================CEK apa sudah punya PV  =========
            If tbl_cekPV.Rows.Count <> 0 Then
                MsgBox("Cannot split, because this line or split line have a PV", MsgBoxStyle.Critical, "Critical")
                Exit Sub
            End If
            '===============================================================
            tbl_cur.Clear()
            Me.DataFill(tbl_cur, "ms_MstCurrency_Select", " currency_id = '" & Me.DgvTrnAdvanceDetil.CurrentRow.Cells("currency_id").Value & "'", "")

            line = Me.DgvTrnAdvanceDetil.CurrentRow.Cells("advancedetil_line").Value.ToString
            description = Me.DgvTrnAdvanceDetil.CurrentRow.Cells("advancedetil_descr").Value.ToString
            currency = tbl_cur.Rows(0).Item("currency_shortname").ToString
            amount = Format(Me.DgvTrnAdvanceDetil.CurrentRow.Cells("advancedetil_foreignreal").Value, "#,##0.00")
            rate = Format(Me.DgvTrnAdvanceDetil.CurrentRow.Cells("advancedetil_foreignrate").Value, "#,##0.00")
            subtotal = Format(Me.DgvTrnAdvanceDetil.CurrentRow.Cells("advancedetil_subtotal").Value, "#,##0.00")

            Dim dlgSplitRow As dlgSplitRowAdvanceDetil_ManySplit = New dlgSplitRowAdvanceDetil_ManySplit(line, description, currency, rate, amount, subtotal)
            dlgSplitRow.ShowDialog()

            Dim split_1, split_2, split_3, split_4, split_5, split_6, split_7, split_8, split_9, split_10 As Boolean
            Dim SplitPercent1, SplitPercent2, SplitPercent3, SplitPercent4, SplitPercent5, _
                SplitPercent6, SplitPercent7, SplitPercent8, SplitPercent9, SplitPercent10 As Integer

            split_1 = dlgSplitRow.chk_split1.Checked
            split_2 = dlgSplitRow.chk_split2.Checked
            split_3 = dlgSplitRow.chk_split3.Checked
            split_4 = dlgSplitRow.chk_split4.Checked
            split_5 = dlgSplitRow.chk_split5.Checked
            split_6 = dlgSplitRow.chk_split6.Checked
            split_7 = dlgSplitRow.chk_split7.Checked
            split_8 = dlgSplitRow.chk_split8.Checked
            split_9 = dlgSplitRow.chk_split9.Checked
            split_10 = dlgSplitRow.chk_split10.Checked

            SplitPercent1 = dlgSplitRow.obj_split1.Text
            SplitPercent2 = dlgSplitRow.obj_split2.Text
            SplitPercent3 = dlgSplitRow.obj_split3.Text
            SplitPercent4 = dlgSplitRow.obj_split4.Text
            SplitPercent5 = dlgSplitRow.obj_split5.Text
            SplitPercent6 = dlgSplitRow.obj_split6.Text
            SplitPercent7 = dlgSplitRow.obj_split7.Text
            SplitPercent8 = dlgSplitRow.obj_split8.Text
            SplitPercent9 = dlgSplitRow.obj_split9.Text
            SplitPercent10 = dlgSplitRow.obj_split10.Text


            If dlgSplitRow.DialogResult = DialogResult.OK Then

                Dim splitline As Integer
                Dim line_current As Integer = Me.DgvTrnAdvanceDetil.CurrentRow.Cells("advancedetil_line").Value
                Dim foreignreal_current As Decimal = Me.DgvTrnAdvanceDetil.CurrentRow.Cells("advancedetil_foreignreal").Value
                Dim idrreal_currenct As Decimal = Me.DgvTrnAdvanceDetil.CurrentRow.Cells("advancedetil_idrreal").Value
                Dim total_currenct As Decimal = Me.DgvTrnAdvanceDetil.CurrentRow.Cells("advancedetil_subtotal").Value

                Dim tbl_lastbudgetdetilline As DataTable = New DataTable
                tbl_lastbudgetdetilline.Clear()
                Dim budgetdetilline_last As Integer
                DataFill(tbl_lastbudgetdetilline, "vq_TrnAdvance_SelectLastBudgetdetil_line", " advance_id = '" & Advance_id & "' ", "")
                budgetdetilline_last = tbl_lastbudgetdetilline.Rows(0).Item("budgetdetil_line")
                Me.budgetdetil_line_temps = budgetdetilline_last

                If split_2 = True Then
                    splitline = 1

                    Me.SplitRow(Advance_id, splitline, SplitPercent2, line_current, foreignreal_current, idrreal_currenct, total_currenct)
                End If

                If split_3 = True Then
                    splitline = 2

                    Me.SplitRow(Advance_id, splitline, SplitPercent3, line_current, foreignreal_current, idrreal_currenct, total_currenct)
                End If

                If split_4 = True Then
                    splitline = 3

                    Me.SplitRow(Advance_id, splitline, SplitPercent4, line_current, foreignreal_current, idrreal_currenct, total_currenct)
                End If

                If split_5 = True Then
                    splitline = 4

                    Me.SplitRow(Advance_id, splitline, SplitPercent5, line_current, foreignreal_current, idrreal_currenct, total_currenct)
                End If

                If split_6 = True Then
                    splitline = 5

                    Me.SplitRow(Advance_id, splitline, SplitPercent6, line_current, foreignreal_current, idrreal_currenct, total_currenct)
                End If

                If split_7 = True Then
                    splitline = 6

                    Me.SplitRow(Advance_id, splitline, SplitPercent7, line_current, foreignreal_current, idrreal_currenct, total_currenct)
                End If

                If split_8 = True Then
                    splitline = 7

                    Me.SplitRow(Advance_id, splitline, SplitPercent8, line_current, foreignreal_current, idrreal_currenct, total_currenct)
                End If

                If split_9 = True Then
                    splitline = 8
                    Me.SplitRow(Advance_id, splitline, SplitPercent9, line_current, foreignreal_current, idrreal_currenct, total_currenct)
                End If

                If split_10 = True Then
                    splitline = 9
                    Me.SplitRow(Advance_id, splitline, SplitPercent10, line_current, foreignreal_current, idrreal_currenct, total_currenct)
                End If

                If split_1 = True Then
                    splitline = 0
                    Me.SplitRow(Advance_id, splitline, SplitPercent1, line_current, foreignreal_current, idrreal_currenct, total_currenct)
                End If


                Dim split As Integer = -(split_1 + split_2 + split_3 + split_4 + split_5 + split_6 + split_7 + split_7 + split_8 + split_9 + split_10)

                Me.uiTransaksiAdvanceRequest_Save()
                Me.AdvanceRequest_SplitApprove(Advance_id, currLine, split)
                Me.uiTransaksiAdvanceRequest_OpenRow(Me.DgvTrnAdvance.CurrentRow.Index)

            End If

        Else '====================== Di Unsplit ======================================================================
            '=====cek apakah punya PV apa nggk====
            'If Me.tbl_TrnAdvanceRefPV.Rows.Count <> 0 Then
            '    For f As Integer = 0 To Me.tbl_TrnAdvanceRefPV.Rows.Count - 1
            '        If Me.tbl_TrnAdvanceRefPV.Rows(f).Item("advance_id") = Advance_id And Me.tbl_TrnAdvanceRefPV.Rows(f).Item("jurnal_id_refline") = currLine Then
            '            MsgBox("Cannot split, because this line have a PV", MsgBoxStyle.Critical, "Critical")
            '            Exit Sub
            '        End If
            '    Next
            'End If
            If tbl_cekPV.Rows.Count <> 0 Then
                MsgBox("Cannot split, because this line or split line have a PV", MsgBoxStyle.Critical, "Critical")
                Exit Sub
            End If
            '==========================================================================================================

            '==============unsplit yg advancedetil ====================================================================
            Dim foreignreal_Unsplit, idrreal_Unsplit, subtotal_Insplit As Decimal

            foreignreal_Unsplit = Me.tbl_TrnAdvanceDetil.Compute _
                            ("sum(advancedetil_foreignreal)", " advancedetil_line >= '" & currLine & "' AND advancedetil_line <= '" & currLine + 9 & "' ")
            idrreal_Unsplit = Me.tbl_TrnAdvanceDetil.Compute _
                            ("sum(advancedetil_idrreal)", " advancedetil_line >= '" & currLine & "' AND advancedetil_line <= '" & currLine + 9 & "' ")
            subtotal_Insplit = Me.tbl_TrnAdvanceDetil.Compute _
                            ("sum(advancedetil_subtotal)", " advancedetil_line >= '" & currLine & "' AND advancedetil_line <= '" & currLine + 9 & "' ")

            Me.DgvTrnAdvanceDetil.CurrentRow.Cells("advancedetil_foreignreal").Value = foreignreal_Unsplit
            Me.DgvTrnAdvanceDetil.CurrentRow.Cells("advancedetil_idrreal").Value = idrreal_Unsplit
            Me.DgvTrnAdvanceDetil.CurrentRow.Cells("advancedetil_subtotal").Value = subtotal_Insplit

            Dim rows As DataRow() = Me.tbl_TrnAdvanceDetil.Select _
                                    (String.Format(" advance_id = '{0}' and (advancedetil_line > {1} and advancedetil_line <= {2})", Advance_id, currLine, currLine + 9))
            For Each r As DataRow In rows
                r.Delete()
            Next

            '======================================unsplit advance_itemdetil =======================

            Dim amount_advance_Unsplit, amount_idrreal_Unsplit, amount_subtotalforeign_Unsplit, amount_subtotal_Unsplit As Decimal
            Dim budgetdetil_line As Integer

            For s As Integer = 0 To Me.tbl_TrnAdvanceItemDetil.Rows.Count - 1
                If Me.tbl_TrnAdvanceItemDetil.Rows(s).Item("advancedetil_line") = currLine Then

                    budgetdetil_line = Me.tbl_TrnAdvanceItemDetil.Rows(s).Item("budgetdetil_line")

                    amount_advance_Unsplit = Me.tbl_TrnAdvanceItemDetil.Compute _
                                             ("sum(amount_advance)", " advance_id = '" & Advance_id _
                                              & "' AND (advancedetil_line >= " & currLine _
                                              & " and advancedetil_line <= " & currLine + 9 _
                                              & ") AND (budgetdetil_line >= " & budgetdetil_line _
                                              & " and budgetdetil_line <= " & budgetdetil_line + 9 & ")")

                    amount_idrreal_Unsplit = Me.tbl_TrnAdvanceItemDetil.Compute _
                                             ("sum(amount_idrreal)", " advance_id = '" & Advance_id _
                                              & "' AND (advancedetil_line >= " & currLine _
                                              & " and advancedetil_line <= " & currLine + 9 _
                                              & ") AND (budgetdetil_line >= " & budgetdetil_line _
                                              & " and budgetdetil_line <= " & budgetdetil_line + 9 & ")")

                    amount_subtotalforeign_Unsplit = Me.tbl_TrnAdvanceItemDetil.Compute _
                                             ("sum(amount_subtotalforeign)", " advance_id = '" & Advance_id _
                                              & "' AND (advancedetil_line >= " & currLine _
                                              & " and advancedetil_line <= " & currLine + 9 _
                                              & ") AND (budgetdetil_line >= " & budgetdetil_line _
                                              & " and budgetdetil_line <= " & budgetdetil_line + 9 & ")")

                    amount_subtotal_Unsplit = Me.tbl_TrnAdvanceItemDetil.Compute _
                                             ("sum(amount_subtotal)", " advance_id = '" & Advance_id _
                                              & "' AND (advancedetil_line >= " & currLine _
                                              & " and advancedetil_line <= " & currLine + 9 _
                                              & ") AND (budgetdetil_line >= " & budgetdetil_line _
                                              & " and budgetdetil_line <= " & budgetdetil_line + 9 & ")")


                    Me.tbl_TrnAdvanceItemDetil.Rows(s).Item("amount_advance") = amount_advance_Unsplit
                    Me.tbl_TrnAdvanceItemDetil.Rows(s).Item("amount_idrreal") = amount_idrreal_Unsplit
                    Me.tbl_TrnAdvanceItemDetil.Rows(s).Item("amount_subtotalforeign") = amount_subtotalforeign_Unsplit
                    Me.tbl_TrnAdvanceItemDetil.Rows(s).Item("amount_subtotal") = amount_subtotal_Unsplit


                End If

            Next

            Dim rowsitemdetil As DataRow() = Me.tbl_TrnAdvanceItemDetil.Select _
                                    (String.Format(" advance_id = '{0}' and (advancedetil_line > {1} and advancedetil_line <= {2})", Advance_id, currLine, currLine + 9))
            For Each r As DataRow In rowsitemdetil
                r.Delete()
            Next

            '===========================UNsplit transaksi_orderadvance====================================
            Dim amount_advance_Unsplit1 As Decimal
            Dim budgetdetil_line1 As Integer

            For x As Integer = 0 To Me.tbl_RefOrder.Rows.Count - 1
                If Me.tbl_RefOrder.Rows(x).Item("advancedetil_line") = currLine Then

                    budgetdetil_line1 = Me.tbl_RefOrder.Rows(x).Item("budgetdetil_line")

                    amount_advance_Unsplit1 = Me.tbl_RefOrder.Compute _
                                             ("sum(amount_advance)", " advance_id = '" & Advance_id _
                                              & "' AND (advancedetil_line >= " & currLine _
                                              & " and advancedetil_line <= " & currLine + 9 _
                                              & ") AND (budgetdetil_line >= " & budgetdetil_line _
                                              & " and budgetdetil_line <= " & budgetdetil_line + 9 & ")")

                    'amount_idrreal_Unsplit = Me.tbl_TrnAdvanceItemDetil.Compute _
                    '                         ("sum(amount_idrreal)", " advance_id = '" & Advance_id _
                    '                          & "' AND (advancedetil_line >= " & currLine _
                    '                          & " and advancedetil_line <= " & currLine + 9 _
                    '                          & ") AND (budgetdetil_line >= " & budgetdetil_line _
                    '                          & " and budgetdetil_line <= " & budgetdetil_line + 9 & ")")

                    'amount_subtotalforeign_Unsplit = Me.tbl_TrnAdvanceItemDetil.Compute _
                    '                         ("sum(amount_subtotalforeign)", " advance_id = '" & Advance_id _
                    '                          & "' AND (advancedetil_line >= " & currLine _
                    '                          & " and advancedetil_line <= " & currLine + 9 _
                    '                          & ") AND (budgetdetil_line >= " & budgetdetil_line _
                    '                          & " and budgetdetil_line <= " & budgetdetil_line + 9 & ")")

                    'amount_subtotal_Unsplit = Me.tbl_TrnAdvanceItemDetil.Compute _
                    '                         ("sum(amount_subtotal)", " advance_id = '" & Advance_id _
                    '                          & "' AND (advancedetil_line >= " & currLine _
                    '                          & " and advancedetil_line <= " & currLine + 9 _
                    '                          & ") AND (budgetdetil_line >= " & budgetdetil_line _
                    '                          & " and budgetdetil_line <= " & budgetdetil_line + 9 & ")")


                    Me.tbl_RefOrder.Rows(x).Item("amount_advance") = amount_advance_Unsplit



                End If

            Next

            Dim rowsitemdetil1 As DataRow() = Me.tbl_RefOrder.Select _
                                    (String.Format(" advance_id = '{0}' and (advancedetil_line > {1} and advancedetil_line <= {2})", Advance_id, currLine, currLine + 9))
            For Each rw As DataRow In rowsitemdetil1
                rw.Delete()
            Next

            '======================================================

            Me.uiTransaksiAdvanceRequest_Save()
            Me.AdvanceRequest_UnsplitApprove(Advance_id, currLine)
            Me.uiTransaksiAdvanceRequest_OpenRow(Me.DgvTrnAdvance.CurrentRow.Index)


        End If
    End Sub

    Sub AdvanceRequest_SplitApprove(ByVal advance_id As String, ByVal line_current As Integer, ByVal split As Integer)
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim cookie As Byte() = Nothing

        Try
            dbConn.Open()
            clsApplicationRole.SetAppRole(dbConn, cookie)
            Dim oCm As New OleDb.OleDbCommand("vq_TrnAdvanceListOrder_ApproveSplitDetil", dbConn)
            oCm.CommandType = CommandType.StoredProcedure
            oCm.Parameters.Add("@advance_id", System.Data.OleDb.OleDbType.VarWChar, 30).Value = advance_id
            oCm.Parameters.Add("@line_current", System.Data.OleDb.OleDbType.Integer).Value = line_current
            oCm.Parameters.Add("@Split", System.Data.OleDb.OleDbType.Integer).Value = split

            oCm.ExecuteNonQuery()
            oCm.Dispose()
        Catch ex As Data.OleDb.OleDbException
            MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            clsApplicationRole.UnsetAppRole(dbConn, cookie)
            dbConn.Close()
        End Try



    End Sub

    Sub AdvanceRequest_UnsplitApprove(ByVal advance_id As String, ByVal line_current As Integer)
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim cookie As Byte() = Nothing

        Try
            dbConn.Open()
            clsApplicationRole.SetAppRole(dbConn, cookie)
            Dim oCm As New OleDb.OleDbCommand("vq_TrnAdvance_ApproveUnSplitDetil_ListOrder", dbConn)
            oCm.CommandType = CommandType.StoredProcedure
            oCm.Parameters.Add("@advance_id", System.Data.OleDb.OleDbType.VarWChar, 30).Value = advance_id
            oCm.Parameters.Add("@line_current", System.Data.OleDb.OleDbType.Integer).Value = line_current

            oCm.ExecuteNonQuery()
            oCm.Dispose()
        Catch ex As Data.OleDb.OleDbException
            MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            clsApplicationRole.UnsetAppRole(dbConn, cookie)
            dbConn.Close()
        End Try



    End Sub

    Sub SplitRow(ByVal Advance_id As String, ByVal Split_Line As Integer, ByVal Split_Percent As Integer, ByVal line_current As Integer, ByVal foreignreal_current As Decimal, ByVal idrreal_currenct As Decimal, ByVal total_currenct As Decimal)
        Dim i As Integer
        Dim columnName, columnName_eps As String
        Dim row, row_eps, row_advanceorder As DataRow
        Dim line_temps As Integer
        'Dim budgetdetil_line_temps As Integer

        Dim foreign_real, idr_real, total As Decimal
        'Dim foreign_real2, idr_real2, total2 As Decimal
        Dim amount_idrreal, amount_advance, amount_subtotalforeign, amount_subtotal As Decimal

        'Dim line, description, currency As String
        'Dim amount, rate, subtotal As Decimal

        Dim tbl_cur As DataTable = New DataTable
        Dim tbl_temp_AdvanceItemDetil As DataTable = New DataTable
        Dim tbl_temp_AdvanceItemDetilEps As DataTable = New DataTable
        Dim tbl_temp_AdvanceDetil As DataTable = New DataTable
        Dim tbl_temp_AdvanceItemDetil2 As DataTable = New DataTable
        Dim tbl_temp_RefOrder As DataTable = clsDataset.CreateTblTrnOrderadvance()
        Dim tbl_temp_RefOrder2 As DataTable = clsDataset.CreateTblTrnOrderadvance()
        'Dim currLine As Integer
        'Dim amount_advance2, amount_idrreal2, amount_subtotalforeign2, amount_subtotal2 As Decimal


        line_temps = line_current + Split_Line
        foreign_real = foreignreal_current * Split_Percent / 100
        idr_real = idrreal_currenct * Split_Percent / 100
        total = total_currenct * Split_Percent / 100



        If Split_Line = 0 Then '=====================Rows yang di split nilainya dikali sesuai dengan percent split nya===================
            '============================================================== Split AdvanceDetil =======================================================

            For d As Integer = 0 To Me.tbl_TrnAdvanceDetil.Rows.Count - 1
                If Me.tbl_TrnAdvanceDetil.Rows(d).Item("advancedetil_line") = Me.DgvTrnAdvanceDetil.CurrentRow.Cells("advancedetil_line").Value Then
                    Me.tbl_TrnAdvanceDetil.Rows(d).Item("advancedetil_foreignreal") = foreign_real
                    Me.tbl_TrnAdvanceDetil.Rows(d).Item("advancedetil_idrreal") = idr_real
                    Me.tbl_TrnAdvanceDetil.Rows(d).Item("advancedetil_subtotal") = total
                End If
            Next

            '============================================================== Split AdvanceItemDetil ===================================================
            tbl_temp_AdvanceItemDetil2.Clear()
            tbl_temp_AdvanceItemDetil2 = Me.tbl_TrnAdvanceItemDetil.Copy()
            tbl_temp_AdvanceItemDetil2.DefaultView.RowFilter = String.Format(" advancedetil_line = {0} ", line_current) 'Me.DgvTrnAdvanceDetil.Rows(Me.DgvTrnAdvanceDetil.CurrentRow.Index).Cells("advancedetil_line").Value)


            Dim amount_advance2, amount_idrreal2, amount_subtotalforeign2, amount_subtotal2 As Decimal

            For p As Integer = 0 To Me.tbl_TrnAdvanceItemDetil.Rows.Count - 1

                If Me.tbl_TrnAdvanceItemDetil.Rows(p).Item("advancedetil_line") = line_current Then
                    For w As Integer = 0 To tbl_temp_AdvanceItemDetil2.Rows.Count - 1

                        If tbl_temp_AdvanceItemDetil2.Rows(w).Item("advancedetil_line") = Me.tbl_TrnAdvanceItemDetil.Rows(p).Item("advancedetil_line") And _
                           tbl_temp_AdvanceItemDetil2.Rows(w).Item("budgetdetil_line") = Me.tbl_TrnAdvanceItemDetil.Rows(p).Item("budgetdetil_line") Then

                            amount_advance2 = tbl_temp_AdvanceItemDetil2.Rows(w).Item("amount_advance") * Split_Percent / 100
                            amount_idrreal2 = tbl_temp_AdvanceItemDetil2.Rows(w).Item("amount_idrreal") * Split_Percent / 100
                            amount_subtotalforeign2 = tbl_temp_AdvanceItemDetil2.Rows(w).Item("amount_subtotalforeign") * Split_Percent / 100
                            amount_subtotal2 = tbl_temp_AdvanceItemDetil2.Rows(w).Item("amount_subtotal") * Split_Percent / 100

                            Me.tbl_TrnAdvanceItemDetil.Rows(p).Item("amount_advance") = amount_advance2
                            Me.tbl_TrnAdvanceItemDetil.Rows(p).Item("amount_idrreal") = amount_idrreal2
                            Me.tbl_TrnAdvanceItemDetil.Rows(p).Item("amount_subtotalforeign") = amount_subtotalforeign2
                            Me.tbl_TrnAdvanceItemDetil.Rows(p).Item("amount_subtotal") = amount_subtotal2

                        End If

                    Next
                End If
            Next


            '=====================untuk tabel transaksi_orderadvance nyaaaa======================================================
            tbl_temp_RefOrder2.Clear()
            tbl_temp_RefOrder2 = Me.tbl_RefOrder.Copy()
            tbl_temp_RefOrder2.DefaultView.RowFilter = String.Format(" advancedetil_line = {0} ", line_current) 'Me.DgvTrnAdvanceDetil.Rows(Me.DgvTrnAdvanceDetil.Curren

            Dim amount_advanceOrder As Decimal
            For p As Integer = 0 To Me.tbl_RefOrder.Rows.Count - 1

                If Me.tbl_RefOrder.Rows(p).Item("advancedetil_line") = line_current Then
                    For w As Integer = 0 To tbl_temp_RefOrder2.Rows.Count - 1

                        If tbl_temp_RefOrder2.Rows(w).Item("advancedetil_line") = Me.tbl_RefOrder.Rows(p).Item("advancedetil_line") And _
                           tbl_temp_RefOrder2.Rows(w).Item("budgetdetil_line") = Me.tbl_RefOrder.Rows(p).Item("budgetdetil_line") Then

                            amount_advanceOrder = tbl_temp_RefOrder2.Rows(w).Item("amount_advance") * Split_Percent / 100
                            Me.tbl_RefOrder.Rows(p).Item("amount_advance") = amount_advanceOrder
                        End If

                    Next
                End If
            Next


        Else '============= untuk rows split nya =========================================================================================

            '================================================== Split AdvanceDetil =======================================================

            row = Me.tbl_TrnAdvanceDetil.NewRow
            For i = 0 To tbl_TrnAdvanceDetil.Columns.Count - 1
                columnName = tbl_TrnAdvanceDetil.Columns(i).ColumnName
                If columnName = "advancedetil_line" Then
                    row.Item(columnName) = line_temps
                ElseIf columnName = "advancedetil_foreignreal" Then
                    row.Item(columnName) = foreign_real
                ElseIf columnName = "advancedetil_idrreal" Then
                    row.Item(columnName) = idr_real
                ElseIf columnName = "advancedetil_subtotal" Then
                    row.Item(columnName) = total
                Else
                    row.Item(columnName) = tbl_TrnAdvanceDetil.Rows(Me.DgvTrnAdvanceDetil.CurrentRow.Index).Item(columnName)
                End If
            Next
            Me.tbl_TrnAdvanceDetil.Rows.Add(row)

            '============================================== Split AdvanceItemDetil ===================================================

            tbl_temp_AdvanceItemDetil.Clear()
            tbl_temp_RefOrder.Clear()
            '===================REMARK SEMENTARA 20140624=========================
            'tbl_temp_AdvanceItemDetil = Me.tbl_TrnAdvanceItemDetil.Copy()
            'tbl_temp_AdvanceItemDetil.DefaultView.RowFilter = String.Format(" advancedetil_line = {0} ", line_current) ' Me.DgvTrnAdvanceDetil.Rows(Me.DgvTrnAdvanceDetil.CurrentRow.Index).Cells("advancedetil_line").Value)
            '====================================================================
            DataFill(tbl_temp_AdvanceItemDetil, "vq_TrnAdvanceItemDetil2_Selects", " a.advance_id = '" & Advance_id & "' AND a.advancedetil_line = '" & line_current & "' ", "")
            'vq_TrnAdvanceItemDetil_SelectSplit
            DataFill(tbl_temp_RefOrder, "vq_TrnOrderadvance_Select", " advance_id = '" & Advance_id & "' AND advancedetil_line = '" & line_current & "' ", "")

            For j As Integer = 0 To tbl_temp_AdvanceItemDetil.DefaultView.Count - 1

                If j = 0 Then
                    Me.budgetdetil_line_temps = Me.budgetdetil_line_temps + 10 'budgetdetilline_last + 10
                Else
                    Me.budgetdetil_line_temps = Me.tbl_TrnAdvanceItemDetil.Rows(Me.tbl_TrnAdvanceItemDetil.Rows.Count - 1).Item("budgetdetil_line") + 10
                End If

                amount_advance = tbl_temp_AdvanceItemDetil.Rows(j).Item("amount_advance") * Split_Percent / 100
                amount_idrreal = tbl_temp_AdvanceItemDetil.Rows(j).Item("amount_idrreal") * Split_Percent / 100
                amount_subtotalforeign = tbl_temp_AdvanceItemDetil.Rows(j).Item("amount_subtotalforeign") * Split_Percent / 100
                amount_subtotal = tbl_temp_AdvanceItemDetil.Rows(j).Item("amount_subtotal") * Split_Percent / 100


                row = Me.tbl_TrnAdvanceItemDetil.NewRow
                For i = 0 To tbl_temp_AdvanceItemDetil.Columns.Count - 1
                    columnName = tbl_temp_AdvanceItemDetil.Columns(i).ColumnName
                    If columnName = "advancedetil_line" Then
                        row.Item(columnName) = line_temps
                    ElseIf columnName = "budgetdetil_line" Then
                        row.Item(columnName) = tbl_temp_AdvanceItemDetil.DefaultView.Item(j).Item(columnName) + Split_Line 'budgetdetil_line_temps 'Me.tbl_TrnAdvanceItemDetil.Rows(Me.tbl_TrnAdvanceItemDetil.Rows.Count - 1).Item("budgetdetil_line") + 10
                    ElseIf columnName = "amount_advance" Then
                        row.Item(columnName) = amount_advance
                    ElseIf columnName = "amount_idrreal" Then
                        row.Item(columnName) = amount_idrreal
                    ElseIf columnName = "amount_subtotalforeign" Then
                        row.Item(columnName) = amount_subtotalforeign
                    ElseIf columnName = "amount_subtotal" Then
                        row.Item(columnName) = amount_subtotal
                    Else
                        row.Item(columnName) = tbl_temp_AdvanceItemDetil.DefaultView.Item(j).Item(columnName)
                    End If
                Next
                Me.tbl_TrnAdvanceItemDetil.Rows.Add(row)



                '===========================ADD 20140624============transaksais_orderadvance===============================
                row_advanceorder = Me.tbl_RefOrder.NewRow
                For i = 0 To tbl_temp_RefOrder.Columns.Count - 1
                    columnName = tbl_temp_RefOrder.Columns(i).ColumnName
                    If columnName = "advancedetil_line" Then
                        row_advanceorder.Item(columnName) = line_temps
                    ElseIf columnName = "budgetdetil_line" Then
                        row_advanceorder.Item(columnName) = tbl_temp_RefOrder.DefaultView.Item(j).Item(columnName) + Split_Line 'budgetdetil_line_temps 'Me.tbl_TrnAdvanceItemDetil.Rows(Me.tbl_TrnAdvanceItemDetil.Rows.Count - 1).Item("budgetdetil_line") + 10
                    ElseIf columnName = "amount_advance" Then
                        row_advanceorder.Item(columnName) = amount_advance
                        'ElseIf columnName = "amount_idrreal" Then
                        '    row_advanceorder.Item(columnName) = amount_idrreal
                        'ElseIf columnName = "amount_subtotalforeign" Then
                        '    row_advanceorder.Item(columnName) = amount_subtotalforeign
                        'ElseIf columnName = "amount_subtotal" Then
                        '    row_advanceorder.Item(columnName) = amount_subtotal
                    Else
                        row_advanceorder.Item(columnName) = tbl_temp_RefOrder.DefaultView.Item(j).Item(columnName)
                    End If
                Next
                Me.tbl_RefOrder.Rows.Add(row_advanceorder)
                '===================================================================================

                '============================================== Split AdvanceDetilEps ===================================================
                tbl_temp_AdvanceItemDetilEps.Clear()
                tbl_temp_AdvanceItemDetilEps = Me.tbl_Advancedetileps.Copy()
                tbl_temp_AdvanceItemDetilEps.DefaultView.RowFilter = String.Format(" advancedetil_line = {0} AND budgetdetil_line = {1} ", _
                        tbl_temp_AdvanceItemDetil.DefaultView.Item(j).Item("advancedetil_line"), tbl_temp_AdvanceItemDetil.DefaultView.Item(j).Item("budgetdetil_line"))

                For k As Integer = 0 To tbl_temp_AdvanceItemDetilEps.DefaultView.Count - 1
                    row_eps = Me.tbl_Advancedetileps.NewRow
                    For i = 0 To tbl_temp_AdvanceItemDetilEps.Columns.Count - 1
                        columnName_eps = tbl_temp_AdvanceItemDetilEps.Columns(i).ColumnName
                        If columnName_eps = "budgetdetiluse_line" Then
                            row_eps.Item(columnName_eps) = Me.tbl_Advancedetileps.Rows(Me.tbl_Advancedetileps.Rows.Count - 1).Item("budgetdetiluse_line") + 10
                        ElseIf columnName_eps = "advancedetil_line" Then
                            row_eps.Item(columnName_eps) = line_temps
                        ElseIf columnName_eps = "budgetdetil_line" Then
                            row_eps.Item(columnName_eps) = budgetdetil_line_temps
                        Else
                            row_eps.Item(columnName_eps) = tbl_temp_AdvanceItemDetilEps.DefaultView.Item(k).Item(columnName_eps)
                        End If
                    Next
                    Me.tbl_Advancedetileps.Rows.Add(row_eps)
                Next

            Next

        End If

    End Sub

    Private Function getApprovedFromTravel(ByVal _advance_id As String) As DataTable
        Dim tbl As DataTable = New DataTable


        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter



        dbCmd = New OleDb.OleDbCommand("vq_TrnAdvanceListSPD_SelectApprove_Report", dbConn)

        dbCmd.Parameters.Add("@advance_id", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@advance_id").Value = _advance_id
        dbCmd.CommandType = CommandType.StoredProcedure
        dbCmd.CommandTimeout = 0

        dbDA = New OleDb.OleDbDataAdapter(dbCmd)
        Dim cookie As Byte() = Nothing


        Try
            tbl.Clear()
            dbConn.Open()
            clsApplicationRole.SetAppRole(dbConn, cookie)
            dbDA.Fill(tbl)
        Catch ex As Exception
            Throw ex
        Finally
            clsApplicationRole.UnsetAppRole(dbConn, cookie)
            dbConn.Close()
        End Try

        Return tbl
    End Function

    Private Function uiTrnAdvanceRequest_SentEmail(ByVal nameEmailBody As String, ByVal emailTo As String, Optional ByVal emailCC As String = "", Optional ByVal emailBCC As String = "") As Boolean
        Dim myMail As New System.Net.Mail.MailMessage
        Dim tblEmailUser As DataTable = clsDataset.CreateTblUserEmail()
        Dim sendEmail As clsKirimEmail = New clsKirimEmail(Me.DSN)

        Dim emailFrom, emailFromPassword, subjectEmail, isiEmail, channelName As String

        emailFrom = "gamba@netmedia.co.id"
        emailFromPassword = "GA123$%^"
        subjectEmail = String.Empty
        isiEmail = String.Empty

        Me.tbl_BodyEmail.Clear()
        Me.FillTblBodyEmail(Me.tbl_BodyEmail, "VQ", nameEmailBody)

        isiEmail = Me.tbl_BodyEmail.Rows(0).Item("email_bodypath")
        subjectEmail = Me.tbl_BodyEmail.Rows(0).Item("email_subject")
        isiEmail = isiEmail.Replace("@advance_id", Me.obj_Advance_id.Text).Replace("@advance_budget", Me.obj_budget_id_view.Text).Replace("@advance_vendor", Me.obj_rekanan_id.Text).Replace("@advance_description", Me.obj_Advance_descr.Text). _
            Replace("@advance_total", Me.obj_Advance_foreignreal.Text)


        subjectEmail = subjectEmail.Replace("@advance_id", Me.obj_Advance_id.Text)
        If sendEmail.SendEmail_SQL(emailTo, emailCC, emailBCC, subjectEmail, isiEmail) Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Function FillTblBodyEmail(ByRef DataTable As DataTable, ByVal id_type As String, ByVal typeEmail As String, Optional ByVal channel_id As String = "") As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter
        Dim criteria As String

        criteria = String.Format("id_type = '{0}' and name = '{1}' and isdisabled = 0", id_type, typeEmail)

        dbCmd = New OleDb.OleDbCommand("ms_MstEmailBodyPath_Select", dbConn)
        If channel_id <> "" Then
            dbCmd.Parameters.Add("@channel_id", Data.OleDb.OleDbType.VarChar)
            dbCmd.Parameters("@channel_id").Value = channel_id
        End If
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@Criteria").Value = criteria

        dbCmd.CommandType = CommandType.StoredProcedure
        dbCmd.CommandTimeout = 0
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)
        Dim cookie As Byte() = Nothing

        Try
            dbConn.Open()
            clsApplicationRole.SetAppRole(dbConn, cookie)
            dbDA.Fill(DataTable)
        Catch ex As Exception
            Throw ex
        Finally
            clsApplicationRole.UnsetAppRole(dbConn, cookie)
            dbConn.Close()
        End Try

        Return True
    End Function

    Private Function GetDetilAdvance(ByVal advance_id As String, ByVal channel_id As String) As Object
        Me.Cursor = Cursors.WaitCursor
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter
        Dim criteria = ""
        Dim rekanan As String = ""
        Dim retObj As Object = Nothing

        Dim tblH As DataTable = clsDataset.CreateTblTrnJurnal()
        Dim tblDetil As DataTable

        tblDetil = CreateTblTrnJurnalDetil2()

        Dim row As DataRow
        Dim Descr As String = ""
        Dim thisRetObj As Collection = New Collection

        Dim tbl_TrnJurnal_temp As DataTable = CreateTblTrnJurnalDetilPVListVQ()

        Dim txtSearchCriteria As String = ""

        dbCmd = New OleDb.OleDbCommand("act_TrnJurnaldetil_PV_Select_VQ_Travel", dbConn)
        dbCmd.Parameters.Add("@channel_id", Data.OleDb.OleDbType.VarWChar)
        dbCmd.Parameters("@channel_id").Value = channel_id
        dbCmd.Parameters.Add("@advance_id", Data.OleDb.OleDbType.VarWChar)
        dbCmd.Parameters("@advance_id").Value = advance_id
        dbCmd.CommandTimeout = 0

        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)
        Me.tbl_TrnJurnalPV.Clear()

        Dim cookie As Byte() = Nothing

        Try
            dbConn.Open()
            clsApplicationRole.SetAppRole(dbConn, cookie)
            dbDA.Fill(Me.tbl_TrnJurnalPV)

            If Me.tbl_TrnJurnalPV.Rows.Count <= 0 Then
                Throw New Exception(String.Concat("Advance Id : ", advance_id, Chr(13), Chr(13), "Tidak ada data detail !!"))
            End If


            For i = 0 To tbl_TrnJurnalPV.DefaultView.Count - 1
                row = tblH.NewRow()
                row.Item("currency_id") = tbl_TrnJurnalPV.DefaultView.Item(i).Item("currency_id")
                row.Item("jurnal_descr") = tbl_TrnJurnalPV.DefaultView.Item(i).Item("advance_descr")
                row.Item("rekanan_id") = tbl_TrnJurnalPV.DefaultView.Item(i).Item("rekanan_id")
                row.Item("budget_id") = tbl_TrnJurnalPV.DefaultView.Item(i).Item("budget_id")
                row.Item("currency_rate") = tbl_TrnJurnalPV.DefaultView.Item(i).Item("jurnaldetil_rate")
                tblH.Rows.Add(row)

                row = tblDetil.NewRow()
                row.Item("jurnal_id") = tbl_TrnJurnalPV.DefaultView.Item(i).Item("jurnal_id")
                row.Item("channel_id") = tbl_TrnJurnalPV.DefaultView.Item(i).Item("channel_id")
                row.Item("jurnaldetil_descr") = tbl_TrnJurnalPV.DefaultView.Item(i).Item("jurnaldetil_descr")
                row.Item("jurnaldetil_idr") = tbl_TrnJurnalPV.DefaultView.Item(i).Item("jurnaldetil_idr_outstanding")
                row.Item("jurnaldetil_foreign") = tbl_TrnJurnalPV.DefaultView.Item(i).Item("jurnaldetil_foreign_outstanding")
                row.Item("jurnaldetil_foreignrate") = tbl_TrnJurnalPV.DefaultView.Item(i).Item("jurnaldetil_rate")
                row.Item("currency_id") = tbl_TrnJurnalPV.DefaultView.Item(i).Item("currency_id")
                row.Item("currency_name") = tbl_TrnJurnalPV.DefaultView.Item(i).Item("currency_name")
                row.Item("ref_id") = tbl_TrnJurnalPV.DefaultView.Item(i).Item("jurnal_id")
                row.Item("ref_line") = tbl_TrnJurnalPV.DefaultView.Item(i).Item("jurnaldetil_line")
                row.Item("rekanan_id") = tbl_TrnJurnalPV.DefaultView.Item(i).Item("rekanan_id")
                row.Item("rekanan_name") = tbl_TrnJurnalPV.DefaultView.Item(i).Item("rekanan_name")
                row.Item("strukturunit_id") = tbl_TrnJurnalPV.DefaultView.Item(i).Item("strukturunit_id")
                row.Item("strukturunit_name") = tbl_TrnJurnalPV.DefaultView.Item(i).Item("strukturunit_name")
                row.Item("advance_descr") = tbl_TrnJurnalPV.DefaultView.Item(i).Item("advance_descr")
                row.Item("amount_idr") = String.Format("{0:#,##0}", CDec(-tbl_TrnJurnalPV.DefaultView.Item(i).Item("jurnaldetil_idr")))
                row.Item("amount_foreign") = String.Format("{0:#,##0.00}", CDec(-tbl_TrnJurnalPV.DefaultView.Item(i).Item("jurnaldetil_foreign")))
                row.Item("rate") = String.Format("{0:#,##0}", CDec(tbl_TrnJurnalPV.DefaultView.Item(i).Item("jurnaldetil_rate")))
                row.Item("budget_id") = String.Format("{0:#,##0}", CDec(tbl_TrnJurnalPV.DefaultView.Item(i).Item("budget_id")))
                row.Item("budget_name") = tbl_TrnJurnalPV.DefaultView.Item(i).Item("budget_name")

                'If Me.Source = "PV-ListAdvanceOrder" Then
                row.Item("ppn_foreign") = tbl_TrnJurnalPV.DefaultView.Item(i).Item("ppn_foreign")
                row.Item("pph_foreign") = tbl_TrnJurnalPV.DefaultView.Item(i).Item("pph_foreign")
                row.Item("ppn_idr") = tbl_TrnJurnalPV.DefaultView.Item(i).Item("ppn_idr")
                row.Item("pph_idr") = tbl_TrnJurnalPV.DefaultView.Item(i).Item("pph_idr")
                ' End If

                tblDetil.Rows.Add(row)
            Next

            thisRetObj.Add(tblH.Copy(), "tblH")
            thisRetObj.Add(tblDetil.Copy(), "tblJDetil")
            retObj = thisRetObj

            Return retObj
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function uiTrnJurnalPV_Travel_SaveNEW() As Boolean
        'save data
        Dim i As Integer = 0
        Dim success As Boolean = Nothing
        Dim jurnal_id As Object = New Object
        Dim result As FormSaveResult
        Dim SaveSQL As clsSQLUDTableTypes = New clsSQLUDTableTypes(Me.DSNLinq)
        Dim dbConn As New SqlClient.SqlConnection(Me.DSNLinq)
        Dim cookie As Byte() = Nothing

        Try
            Dim tbl_TrnJurnal_Temp_changes As DataTable = clsDataset.CreateTblFromUDTableTypes(Me.DSNLinq, "transaksi_jurnal_list")
            Dim tbl_TrnJurnaldetil_Debit_changes As DataTable = clsDataset.CreateTblFromUDTableTypes(Me.DSNLinq, "transaksi_jurnaldetil_list")
            Dim tbl_TrnJurnaldetilandbilyet_Credit_changes As DataTable = clsDataset.CreateTblFromUDTableTypes(Me.DSNLinq, "transaksi_jurnaldetilandbilyet_list")
            Dim tbl_TrnJurnalReference_changes As DataTable = clsDataset.CreateTblFromUDTableTypes(Me.DSNLinq, "transaksi_jurnalreference_list")
            ' Dim tbl_TrnJurnalBilyet_changes As DataTable = clsDataset.CreateTblFromUDTableTypes(Me.DSNLinq, "transaksi_jurnalbilyet_list")

            'Table transaksi_jurnal
            '=======================================================================================================================================================================================
            Me.BindingContext(Me.tbl_TrnJurnal_Temp).EndCurrentEdit()
            tbl_TrnJurnal_Temp_changes = SaveSQL.CopyToDatatable(Me.tbl_TrnJurnal_Temp.GetChanges, "flag_execute", tbl_TrnJurnal_Temp_changes)
            '=======================================================================================================================================================================================

            'Table transaksi_jurnaldetil (debit)
            '=======================================================================================================================================================================================
            Me.BindingContext(Me.tbl_TrnJurnaldetil_Debit).EndCurrentEdit()
            tbl_TrnJurnaldetil_Debit_changes = SaveSQL.CopyToDatatable(Me.tbl_TrnJurnaldetil_Debit.GetChanges, "flag_execute", tbl_TrnJurnaldetil_Debit_changes)
            '=======================================================================================================================================================================================

            'Table transaksi_jurnaldetil (credit)
            '=======================================================================================================================================================================================
            Me.BindingContext(Me.tbl_TrnJurnaldetilandbilyet_Credit).EndCurrentEdit()
            tbl_TrnJurnaldetilandbilyet_Credit_changes = SaveSQL.CopyToDatatable(Me.tbl_TrnJurnaldetilandbilyet_Credit.GetChanges, "flag_execute", tbl_TrnJurnaldetilandbilyet_Credit_changes)
            '=======================================================================================================================================================================================

            'Table transaksi_jurnalreference
            '=======================================================================================================================================================================================
            Me.BindingContext(Me.tbl_TrnJurnalReference).EndCurrentEdit()
            tbl_TrnJurnalReference_changes = SaveSQL.CopyToDatatable(Me.tbl_TrnJurnalReference.GetChanges, "flag_execute", tbl_TrnJurnalReference_changes)
            '=======================================================================================================================================================================================

            ''Table transaksi_jurnalbilyet
            ''=======================================================================================================================================================================================
            'Me.BindingContext(Me.tbl_TrnJurnalBilyet).EndCurrentEdit()
            'tbl_TrnJurnalBilyet_changes = SaveSQL.CopyToDatatable(Me.tbl_TrnJurnalBilyet.GetChanges, "flag_execute", tbl_TrnJurnalBilyet_changes)
            ''=======================================================================================================================================================================================

            If tbl_TrnJurnal_Temp_changes IsNot Nothing Or tbl_TrnJurnaldetil_Debit_changes IsNot Nothing Or tbl_TrnJurnaldetilandbilyet_Credit_changes IsNot Nothing Or tbl_TrnJurnalReference_changes IsNot Nothing Then
                dbConn.Open()
                clsApplicationRole.SetAppRoles(dbConn, cookie)

                jurnal_id = SaveSQL.SaveDataPaymentVoucher(dbConn, Me._CHANNEL, ConstMyJurnalType, Me.ConstMyJurnalSource, tbl_TrnJurnal_Temp_changes, tbl_TrnJurnaldetil_Debit_changes, _
                    tbl_TrnJurnaldetilandbilyet_Credit_changes, tbl_TrnJurnalReference_changes, Me._USERSTRUKTURUNIT)

                result = FormSaveResult.SaveSuccess
                If SHOW_SAVE_CONFIRMATION Then
                    counter = 0
                    m = 0
                    n = 0
                    'MessageBox.Show("Data Saved", mUiName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Else
                result = FormSaveResult.Nochanges
                'If SHOW_SAVE_CONFIRMATION Then
                '    MessageBox.Show("All changes has been saved", mUiName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                'End If

            End If
        Catch ex As Exception
            result = FormSaveResult.SaveError
            MessageBox.Show("Data Cannot Be Saved" & vbCrLf & ex.Message, mUiName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Throw ex
        Finally
            clsApplicationRole.UnsetAppRoles(dbConn, cookie)
            dbConn.Close()
        End Try
    End Function

    Private Function GetProdTypeBudgetID(ByVal budget_id As Decimal) As Decimal
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbCmd As OleDb.OleDbCommand

        dbCmd = New OleDb.OleDbCommand(String.Format("select b.prodtype_name from transaksi_budget as a left join master_prodtype as b on a.prodtype_id = b.prodtype_id where a.budget_id = '{0}'", budget_id), dbConn)
        dbCmd.CommandType = CommandType.Text

        Dim cookie As Byte() = Nothing
        Dim prodtype_name As String = ""
        Dim retAccId As Decimal = 0
        Try
            dbConn.Open()
            clsApplicationRole.SetAppRole(dbConn, cookie)
            prodtype_name = dbCmd.ExecuteScalar()

            If prodtype_name = "Production" Then
                retAccId = 1161111
            ElseIf prodtype_name = "News" Then
                retAccId = 1161112
            ElseIf prodtype_name = "Join" Then
                retAccId = 0
            ElseIf prodtype_name = "Others" Then
                retAccId = 1161132
            ElseIf prodtype_name = "Innovation" Then
                retAccId = 1161132
            End If

            Return retAccId
        Catch ex As Exception
            Return retAccId
            Throw ex
        Finally
            clsApplicationRole.UnsetAppRole(dbConn, cookie)
            dbConn.Close()
        End Try
    End Function

    Private Sub btnCreatePaymentVoucher_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreatePaymentVoucher.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            Me.DgvTrnAdvance.EndEdit()
            Me.tbl_TrnAdvance.AcceptChanges()

            Dim objTblTemp As DataTable = Nothing
            Dim checkRows = Me.tbl_TrnAdvance.Select("pilih = true")

            If checkRows.Length > 0 Then
                objTblTemp = Me.tbl_TrnAdvance.Select("pilih = true").CopyToDataTable
            Else
                Exit Sub
            End If

            For Each dtrow As DataRow In objTblTemp.Rows
                Dim retObj As Object = Nothing
                Dim retData As Collection
                Dim tblH, tblJDetil As DataTable
                Dim row As DataRow
                Dim amountForeign_total As Decimal = 0
                Dim amountIDR_total As Decimal = 0
                Dim amountForeign_pphTotal As Decimal = 0
                Dim amountIDR_pphTotal As Decimal = 0

                Me.tbl_TrnJurnal_Temp.Clear()
                Me.tbl_TrnJurnal_Temp = clsDataset.CreateTblTrnJurnal
                Me.tbl_TrnJurnalReference.Clear()
                Me.tbl_TrnJurnalReference = clsDataset.CreateTblTrnJurnalreference()

                ' TODO: Set Default Value for tbl_TrnJurnaldetil_Debit
                Me.tbl_TrnJurnaldetil_Debit.Clear()
                Me.tbl_TrnJurnaldetil_Debit = clsDataset.CreateTblTrnJurnaldetil()
                Me.tbl_TrnJurnaldetil_Debit.Columns("jurnal_id").DefaultValue = 0
                Me.tbl_TrnJurnaldetil_Debit.Columns("jurnaldetil_line").DefaultValue = DBNull.Value
                Me.tbl_TrnJurnaldetil_Debit.Columns("jurnaldetil_line").AutoIncrement = True
                Me.tbl_TrnJurnaldetil_Debit.Columns("jurnaldetil_line").AutoIncrementSeed = 10
                Me.tbl_TrnJurnaldetil_Debit.Columns("jurnaldetil_line").AutoIncrementStep = 10
                Me.tbl_TrnJurnaldetil_Debit.Columns("currency_id").DefaultValue = 1
                Me.tbl_TrnJurnaldetil_Debit.Columns("jurnaldetil_foreignrate").DefaultValue = 1
                Me.tbl_TrnJurnaldetil_Debit.Columns("channel_id").DefaultValue = Me._CHANNEL
                Me.tbl_TrnJurnaldetil_Debit.Columns("jurnaldetil_dk").DefaultValue = "D"

                ' TODO: Set Default Value for tbl_TrnJurnaldetil_Credit
                Me.tbl_TrnJurnaldetilandbilyet_Credit.Clear()
                Me.tbl_TrnJurnaldetilandbilyet_Credit = clsDataset.CreateTblTrnJurnaldetilBilyet()
                Me.tbl_TrnJurnaldetilandbilyet_Credit.Columns("jurnal_id").DefaultValue = 0
                Me.tbl_TrnJurnaldetilandbilyet_Credit.Columns("jurnaldetil_line").DefaultValue = DBNull.Value
                Me.tbl_TrnJurnaldetilandbilyet_Credit.Columns("jurnaldetil_line").AutoIncrement = True
                Me.tbl_TrnJurnaldetilandbilyet_Credit.Columns("jurnaldetil_line").AutoIncrementSeed = 15
                Me.tbl_TrnJurnaldetilandbilyet_Credit.Columns("jurnaldetil_line").AutoIncrementStep = 10
                Me.tbl_TrnJurnaldetilandbilyet_Credit.Columns("currency_id").DefaultValue = 1
                Me.tbl_TrnJurnaldetilandbilyet_Credit.Columns("jurnaldetil_foreignrate").DefaultValue = 1
                Me.tbl_TrnJurnaldetilandbilyet_Credit.Columns("channel_id").DefaultValue = Me._CHANNEL
                Me.tbl_TrnJurnaldetilandbilyet_Credit.Columns("jurnaldetil_dk").DefaultValue = "K"
                Me.tbl_TrnJurnaldetilandbilyet_Credit.Columns("paymenttype_id").DefaultValue = "0"
                Me.tbl_TrnJurnaldetilandbilyet_Credit.Columns("jurnalbilyet_bank").DefaultValue = 0

                retObj = Me.GetDetilAdvance(dtrow.Item("advance_id"), Me._CHANNEL)
                '================================================================================================================================================================
                If retObj IsNot Nothing Then
                    locking.TryLocking(dtrow.Item("advance_id"))

                    If locking.Status = clsLockingTransaction.LockStatus.Locked Then
                        Throw New Exception("Transaction used by " & locking.LockedBy)
                    Else
                        retData = CType(retObj, Collection)
                        tblH = CType(retData.Item("tblH"), DataTable)
                        tblJDetil = CType(retData.Item("tblJDetil"), DataTable)

                        '=============================================================================================================================================================
                        Dim TrnJurnal_Rows As DataRow
                        TrnJurnal_Rows = Me.tbl_TrnJurnal_Temp.NewRow
                        TrnJurnal_Rows.Item("jurnal_id") = ""
                        TrnJurnal_Rows.Item("jurnal_bookdate") = Now.Date
                        TrnJurnal_Rows.Item("jurnal_duedate") = Now.Date
                        TrnJurnal_Rows.Item("jurnal_billdate") = Now.Date
                        TrnJurnal_Rows.Item("jurnal_descr") = tblH.Rows(0).Item("jurnal_descr")
                        TrnJurnal_Rows.Item("jurnal_invoice_id") = ""
                        TrnJurnal_Rows.Item("jurnal_invoice_descr") = ""
                        TrnJurnal_Rows.Item("jurnal_source") = ConstMyJurnalSource
                        TrnJurnal_Rows.Item("jurnaltype_id") = ConstMyJurnalType
                        TrnJurnal_Rows.Item("rekanan_id") = tblH.Rows(0).Item("rekanan_id")
                        TrnJurnal_Rows.Item("periode_id") = ""
                        TrnJurnal_Rows.Item("channel_id") = Me._CHANNEL
                        TrnJurnal_Rows.Item("budget_id") = tblH.Rows(0).Item("budget_id")
                        TrnJurnal_Rows.Item("budget_name") = "-- PILIH --"
                        TrnJurnal_Rows.Item("currency_id") = tblH.Rows(0).Item("currency_id")
                        TrnJurnal_Rows.Item("currency_rate") = tblH.Rows(0).Item("currency_rate")
                        TrnJurnal_Rows.Item("strukturunit_id") = 0
                        TrnJurnal_Rows.Item("acc_ca_id") = 0
                        TrnJurnal_Rows.Item("region_id") = 0
                        TrnJurnal_Rows.Item("branch_id") = 0
                        TrnJurnal_Rows.Item("advertiser_id") = 0
                        TrnJurnal_Rows.Item("brand_id") = 0
                        TrnJurnal_Rows.Item("ae_id") = 0
                        TrnJurnal_Rows.Item("jurnal_iscreated") = 1
                        TrnJurnal_Rows.Item("jurnal_iscreatedby") = UserName
                        TrnJurnal_Rows.Item("jurnal_iscreatedate") = Now.Date
                        TrnJurnal_Rows.Item("jurnal_isposted") = 0
                        TrnJurnal_Rows.Item("jurnal_ispostedby") = ""
                        TrnJurnal_Rows.Item("jurnal_isposteddate") = DBNull.Value
                        TrnJurnal_Rows.Item("jurnal_isdisabled") = 0
                        TrnJurnal_Rows.Item("jurnal_isdisabledby") = ""
                        TrnJurnal_Rows.Item("jurnal_isdisableddt") = DBNull.Value
                        TrnJurnal_Rows.Item("created_by") = UserName
                        TrnJurnal_Rows.Item("created_dt") = Now.Date
                        TrnJurnal_Rows.Item("modified_by") = ""
                        TrnJurnal_Rows.Item("modified_dt") = DBNull.Value
                        Me.tbl_TrnJurnal_Temp.Rows.Add(TrnJurnal_Rows)
                        '====================================================================================================================================================

                        '=================================EXTRACT DEBIT AMOUNT ADVANCE========================================================================
                        'Extract data for detil D
                        For k = 0 To tblJDetil.Rows.Count - 1
                            Dim amount_ppn_foreign As Decimal = 0
                            Dim amount_ppn_real As Decimal = 0

                            row = Me.tbl_TrnJurnaldetil_Debit.NewRow
                            row.Item("jurnaldetil_dk") = "D"
                            row.Item("currency_id") = tblJDetil.Rows(k).Item("currency_id")
                            row.Item("jurnaldetil_descr") = tblJDetil.Rows(k).Item("advance_descr")

                            If tblJDetil.Rows(k).Item("currency_id") = 1 Then
                                row.Item("jurnaldetil_idr") = String.Format("{0:#,##0}", Math.Round(CDec(tblJDetil.Rows(k).Item("jurnaldetil_foreign")), 0, MidpointRounding.AwayFromZero) _
                                                                       * Math.Round(CDec(tblJDetil.Rows(k).Item("jurnaldetil_foreignrate")), 2, MidpointRounding.AwayFromZero))

                                row.Item("jurnaldetil_foreign") = String.Format("{0:#,##0.00}", Math.Round(CDec(tblJDetil.Rows(k).Item("jurnaldetil_foreign")), 0, MidpointRounding.AwayFromZero))

                                amountForeign_total += String.Format("{0:#,##0.00}", Math.Round(Math.Round(CDec(tblJDetil.Rows(k).Item("jurnaldetil_foreign")), 0, MidpointRounding.AwayFromZero) _
                                                                               + Math.Round(CDec(tblJDetil.Rows(k).Item("ppn_foreign")), 2, MidpointRounding.AwayFromZero) _
                                                                               - Math.Round(CDec(tblJDetil.Rows(k).Item("pph_foreign"))), 0, MidpointRounding.AwayFromZero))

                                amountIDR_total += String.Format("{0:#,##0.00}", Math.Round(Math.Round(CDec(tblJDetil.Rows(k).Item("jurnaldetil_foreign")), 0, MidpointRounding.AwayFromZero) _
                                                                            + Math.Round(CDec(tblJDetil.Rows(k).Item("ppn_foreign")), 2, MidpointRounding.AwayFromZero) _
                                                                            - Math.Round(CDec(tblJDetil.Rows(k).Item("pph_foreign")), 2, MidpointRounding.AwayFromZero) _
                                                                            * Math.Round(CDec(tblJDetil.Rows(k).Item("jurnaldetil_foreignrate")), 2, MidpointRounding.AwayFromZero), 0, MidpointRounding.AwayFromZero))
                            Else
                                row.Item("jurnaldetil_idr") = String.Format("{0:#,##0}", CDec(tblJDetil.Rows(k).Item("jurnaldetil_foreign")) _
                                                                      * Math.Round(CDec(tblJDetil.Rows(k).Item("jurnaldetil_foreignrate")), 2, MidpointRounding.AwayFromZero))
                                row.Item("jurnaldetil_foreign") = String.Format("{0:#,##0.00}", CDec(tblJDetil.Rows(k).Item("jurnaldetil_foreign")))

                                amountForeign_total += String.Format("{0:#,##0.00}", CDec(tblJDetil.Rows(k).Item("jurnaldetil_foreign")) _
                                                                               + Math.Round(CDec(tblJDetil.Rows(k).Item("ppn_foreign")), 2, MidpointRounding.AwayFromZero) _
                                                                               - Math.Round(CDec(tblJDetil.Rows(k).Item("pph_foreign")), 2, MidpointRounding.AwayFromZero))

                                amountIDR_total += String.Format("{0:#,##0.00}", CDec(tblJDetil.Rows(k).Item("jurnaldetil_foreign")) _
                                                                            + Math.Round(CDec(tblJDetil.Rows(k).Item("ppn_foreign")), 2, MidpointRounding.AwayFromZero) _
                                                                            - Math.Round(CDec(tblJDetil.Rows(k).Item("pph_foreign")), 2, MidpointRounding.AwayFromZero)) _
                                                                            * Math.Round(CDec(tblJDetil.Rows(k).Item("jurnaldetil_foreignrate")), 2, MidpointRounding.AwayFromZero)
                            End If

                            row.Item("jurnaldetil_foreignrate") = String.Format("{0:#,##0.00}", CDec(tblJDetil.Rows(k).Item("jurnaldetil_foreignrate")))
                            row.Item("acc_id") = GetProdTypeBudgetID(tblJDetil.Rows(k).Item("budget_id"))
                            row.Item("jurnaldetil_descr") = tblJDetil.Rows(k).Item("jurnaldetil_descr")
                            row.Item("ref_id") = tblJDetil.Rows(k).Item("ref_id")
                            row.Item("ref_line") = tblJDetil.Rows(k).Item("ref_line")
                            row.Item("ref_budgetline") = 0
                            row.Item("region_id") = clsUtil.IsDbNull(tblJDetil.Rows(k).Item("region_id"), 0)
                            row.Item("branch_id") = clsUtil.IsDbNull(tblJDetil.Rows(k).Item("branch_id"), 0)
                            row.Item("strukturunit_id") = clsUtil.IsDbNull(tblJDetil.Rows(k).Item("strukturunit_id"), 0)
                            row.Item("rekanan_id") = tblJDetil.Rows(k).Item("rekanan_id") '==========" REKANAN DI DI Debit UM dikosongkan" ======20140922===============
                            row.Item("rekanan_name") = tblJDetil.Rows(k).Item("rekanan_name") '==========" REKANAN DI DI Debit UM dikosongkan" ===20140922==================
                            row.Item("budget_id") = tblJDetil.Rows(k).Item("budget_id")
                            row.Item("budget_name") = tblJDetil.Rows(k).Item("budget_name")
                            row.Item("budgetdetil_id") = 0
                            row.Item("budgetdetil_name") = "-- PILIH --"
                            Me.tbl_TrnJurnaldetil_Debit.Rows.Add(row)

                            'Extract data for tabel Reference
                            row = Me.tbl_TrnJurnalReference.NewRow
                            row.Item("jurnaldetil_line") = Me.tbl_TrnJurnaldetil_Debit.Rows(Me.tbl_TrnJurnaldetil_Debit.Rows.Count - 1).Item("jurnaldetil_line")
                            row.Item("jurnal_id_ref") = tblJDetil.Rows(k).Item("ref_id")
                            row.Item("jurnal_id_refline") = tblJDetil.Rows(k).Item("ref_line")
                            row.Item("jurnal_id_budgetline") = 0
                            row.Item("referencetype") = "PAYMENT"

                            Me.tbl_TrnJurnalReference.Rows.Add(row)
                        Next

                        '=========================================================EXTRACT CREDIT AMOUNT ADVANCE========================================================
                        'Extract data for detil K
                        row = Me.tbl_TrnJurnaldetilandbilyet_Credit.NewRow
                        row.Item("jurnaldetil_dk") = "K"
                        row.Item("currency_id") = tblH.Rows(0).Item("currency_id")
                        row.Item("jurnaldetil_descr") = tblH.Rows(0).Item("jurnal_descr")
                        row.Item("jurnaldetil_idr") = String.Format("{0:#,##0.00}", CDec(amountIDR_total))
                        row.Item("jurnaldetil_foreign") = String.Format("{0:#,##0.00}", CDec(amountForeign_total))
                        row.Item("jurnaldetil_foreignrate") = String.Format("{0:#,##0.00}", CDec(tblJDetil.Rows(0).Item("jurnaldetil_foreignrate")))
                        row.Item("acc_id") = IIf(amountIDR_total <= 5000000, 1111110, 1112106) '1111110 = Kas Umum, 1112106 = Danamon IDR
                        row.Item("jurnaldetil_descr") = tblH.Rows(0).Item("jurnal_descr")
                        row.Item("ref_id") = String.Empty
                        row.Item("ref_line") = 0
                        row.Item("ref_budgetline") = 0
                        row.Item("region_id") = 0
                        row.Item("branch_id") = 0
                        row.Item("strukturunit_id") = tblH.Rows(0).Item("strukturunit_id")
                        row.Item("rekanan_id") = tblJDetil.Rows(0).Item("rekanan_id") 'tblH.Rows(0).Item("rekanan_id")
                        row.Item("rekanan_name") = tblJDetil.Rows(0).Item("rekanan_name") 'Me.obj_rekanan_id.Text
                        row.Item("budget_id") = 0
                        row.Item("budget_name") = "-- PILIH --"
                        row.Item("budgetdetil_id") = 0
                        row.Item("budgetdetil_name") = "-- PILIH --"
                        row.Item("paymenttype_id") = IIf(amountIDR_total <= 5000000, 1, 2)
                        row.Item("jurnalbilyet_bank") = IIf(Me._CHANNEL = "TAS", IIf(amountIDR_total <= 5000000, 42, 23), 0)
                        row.Item("jurnalbilyet_date") = Now.Date
                        row.Item("jurnalbilyet_dateeffective") = Now.Date

                        Me.tbl_TrnJurnaldetilandbilyet_Credit.Rows.Add(row)
                        '==============================================================================================================================================

                        '=============================================EXTRACT DEBIT AMOUNT PPN ADVANCE ================================================================
                        For u As Integer = 0 To tblJDetil.Rows.Count - 1
                            If tblJDetil.Rows(u).Item("ppn_foreign") <> 0 Then
                                Dim amount_ppn_foreign As Decimal = 0
                                Dim amount_ppn_real As Decimal = 0

                                row = Me.tbl_TrnJurnaldetil_Debit.NewRow
                                row.Item("currency_id") = tblJDetil.Rows(u).Item("currency_id")
                                row.Item("jurnaldetil_descr") = tblJDetil.Rows(u).Item("advance_descr")
                                '============remark pts 20140922=====================
                                'row.Item("jurnaldetil_idr") = CDec(tblJDetil.Rows(u).Item("ppn_idr")) 'String.Format("{0:#,##0}", CDec(tblJDetil.Rows(u).Item("ppn_idr")))
                                '==============PTS roundingan 20140922===============
                                If tblJDetil.Rows(u).Item("currency_id") = 1 Then
                                    row.Item("jurnaldetil_idr") = String.Format("{0:#,##0}", Math.Round(CDec(tblJDetil.Rows(u).Item("ppn_foreign")), 0, MidpointRounding.AwayFromZero) * _
                                                                                         CDec(tblJDetil.Rows(u).Item("jurnaldetil_foreignrate")))
                                    row.Item("jurnaldetil_foreign") = String.Format("{0:#,##0.00}", Math.Round(CDec(tblJDetil.Rows(u).Item("ppn_foreign")), 0, MidpointRounding.AwayFromZero))
                                Else
                                    row.Item("jurnaldetil_idr") = String.Format("{0:#,##0}", CDec(tblJDetil.Rows(u).Item("ppn_foreign")) * _
                                                                                         CDec(tblJDetil.Rows(u).Item("jurnaldetil_foreignrate")))
                                    row.Item("jurnaldetil_foreign") = String.Format("{0:#,##0.00}", CDec(tblJDetil.Rows(u).Item("ppn_foreign")))
                                End If
                                '================================================================================================

                                row.Item("jurnaldetil_foreignrate") = String.Format("{0:#,##0.00}", CDec(tblJDetil.Rows(u).Item("jurnaldetil_foreignrate")))
                                row.Item("acc_id") = GetProdTypeBudgetID(tblJDetil.Rows(u).Item("budget_id"))
                                row.Item("jurnaldetil_descr") = "PPN" 'tblJDetil.Rows(u).Item("jurnaldetil_descr")
                                row.Item("ref_id") = tblJDetil.Rows(u).Item("ref_id")
                                row.Item("ref_line") = tblJDetil.Rows(u).Item("ref_line")
                                row.Item("ref_budgetline") = 0
                                row.Item("region_id") = clsUtil.IsDbNull(tblJDetil.Rows(u).Item("region_id"), 0)
                                row.Item("branch_id") = clsUtil.IsDbNull(tblJDetil.Rows(u).Item("branch_id"), 0)
                                row.Item("strukturunit_id") = clsUtil.IsDbNull(tblJDetil.Rows(u).Item("strukturunit_id"), 0)
                                row.Item("rekanan_id") = tblJDetil.Rows(u).Item("rekanan_id")
                                row.Item("rekanan_name") = tblJDetil.Rows(u).Item("rekanan_name")
                                row.Item("budget_id") = tblJDetil.Rows(u).Item("budget_id")
                                row.Item("budget_name") = tblJDetil.Rows(u).Item("budget_name")
                                row.Item("budgetdetil_id") = 0
                                row.Item("budgetdetil_name") = "-- PILIH --"
                                Me.tbl_TrnJurnaldetil_Debit.Rows.Add(row)


                                '=====================UNTUK REFERENCE NYA PPN=====
                                'Extract data for tabel Reference
                                row = Me.tbl_TrnJurnalReference.NewRow
                                row.Item("jurnaldetil_line") = Me.tbl_TrnJurnaldetil_Debit.Rows(Me.tbl_TrnJurnaldetil_Debit.Rows.Count - 1).Item("jurnaldetil_line")
                                row.Item("jurnal_id_ref") = tblJDetil.Rows(u).Item("ref_id")
                                row.Item("jurnal_id_refline") = tblJDetil.Rows(u).Item("ref_line")
                                row.Item("jurnal_id_budgetline") = 0
                                row.Item("referencetype") = "PAYMENT"

                                Me.tbl_TrnJurnalReference.Rows.Add(row)
                                '============================================================
                            End If
                        Next

                        '=============================================EXTRACT Credit AMOUNT PPH ADVANCE =============================================================
                        For u As Integer = 0 To tblJDetil.Rows.Count - 1

                            If tblJDetil.Rows(u).Item("pph_foreign") <> 0 Then
                                Dim amount_ppn_foreign As Decimal = 0
                                Dim amount_ppn_real As Decimal = 0

                                row = Me.tbl_TrnJurnaldetilandbilyet_Credit.NewRow
                                row.Item("currency_id") = tblJDetil.Rows(u).Item("currency_id")
                                row.Item("jurnaldetil_descr") = tblJDetil.Rows(u).Item("advance_descr")

                                '============remark pts 20140922=====================
                                'row.Item("jurnaldetil_idr") = String.Format("{0:#,##0}", CDec(tblJDetil.Rows(u).Item("pph_idr")))
                                '==============PTS roundingan 20140922===============
                                If tblJDetil.Rows(u).Item("currency_id") = 1 Then
                                    row.Item("jurnaldetil_idr") = String.Format("{0:#,##0}", Math.Round(CDec(tblJDetil.Rows(u).Item("pph_foreign")), 0, MidpointRounding.AwayFromZero) * _
                                                                                         Math.Round(CDec(tblJDetil.Rows(u).Item("jurnaldetil_foreignrate")), 2, MidpointRounding.AwayFromZero))
                                    row.Item("jurnaldetil_foreign") = String.Format("{0:#,##0.00}", Math.Round(CDec(tblJDetil.Rows(u).Item("pph_foreign")), 0, MidpointRounding.AwayFromZero))

                                Else
                                    row.Item("jurnaldetil_idr") = String.Format("{0:#,##0}", CDec(tblJDetil.Rows(u).Item("pph_foreign")) * _
                                                                                         Math.Round(CDec(tblJDetil.Rows(u).Item("jurnaldetil_foreignrate")), 2, MidpointRounding.AwayFromZero))
                                    row.Item("jurnaldetil_foreign") = String.Format("{0:#,##0.00}", CDec(tblJDetil.Rows(u).Item("pph_foreign")))
                                End If


                                '====================================================
                                row.Item("jurnaldetil_foreignrate") = String.Format("{0:#,##0.00}", CDec(tblJDetil.Rows(u).Item("jurnaldetil_foreignrate")))
                                row.Item("acc_id") = IIf(amountIDR_total <= 5000000, 1111110, 1112106) '1111110 = Kas Umum, 1112106 = Danamon IDR
                                row.Item("jurnaldetil_descr") = "PPH" 'tblJDetil.Rows(u).Item("jurnaldetil_descr")
                                row.Item("ref_id") = tblJDetil.Rows(u).Item("ref_id")
                                row.Item("ref_line") = tblJDetil.Rows(u).Item("ref_line")
                                row.Item("ref_budgetline") = 0
                                row.Item("region_id") = clsUtil.IsDbNull(tblJDetil.Rows(u).Item("region_id"), 0)
                                row.Item("branch_id") = clsUtil.IsDbNull(tblJDetil.Rows(u).Item("branch_id"), 0)
                                row.Item("strukturunit_id") = clsUtil.IsDbNull(tblJDetil.Rows(u).Item("strukturunit_id"), 0)
                                row.Item("rekanan_id") = tblJDetil.Rows(u).Item("rekanan_id")
                                row.Item("rekanan_name") = tblJDetil.Rows(u).Item("rekanan_name")
                                row.Item("budget_id") = tblJDetil.Rows(u).Item("budget_id")
                                row.Item("budget_name") = tblJDetil.Rows(u).Item("budget_name")
                                row.Item("budgetdetil_id") = 0
                                row.Item("budgetdetil_name") = "-- PILIH --"
                                Me.tbl_TrnJurnaldetilandbilyet_Credit.Rows.Add(row)

                                '=====================UNTUK REFERENCE NYA PPH=====
                                'Extract data for tabel Reference
                                row = Me.tbl_TrnJurnalReference.NewRow
                                row.Item("jurnaldetil_line") = Me.tbl_TrnJurnaldetilandbilyet_Credit.Rows(Me.tbl_TrnJurnaldetilandbilyet_Credit.Rows.Count - 1).Item("jurnaldetil_line")
                                row.Item("jurnal_id_ref") = tblJDetil.Rows(u).Item("ref_id")
                                row.Item("jurnal_id_refline") = tblJDetil.Rows(u).Item("ref_line")
                                row.Item("jurnal_id_budgetline") = 0
                                row.Item("referencetype") = "PAYMENT"

                                Me.tbl_TrnJurnalReference.Rows.Add(row)
                                '============================================================
                            End If
                        Next
                        '=============================================================================================================================================================

                        '================================================================================================================================================================
                        Me.uiTrnJurnalPV_Travel_SaveNEW()
                    End If

                    locking.Clear()
                End If
            Next

            MsgBox("Done")
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Me.uiTransaksiAdvanceRequest_Retrieve()
            Me.Cursor = Cursors.Arrow
        End Try
    End Sub

    Function CreateTblTrnJurnalDetil2() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("jurnal_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("jurnaldetil_line", GetType(System.Int64)))
        tbl.Columns.Add(New DataColumn("jurnaldetil_dk", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("jurnaldetil_descr", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("rekanan_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("rekanan_name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("acc_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("currency_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("currency_name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("jurnaldetil_foreign", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("jurnaldetil_foreignrate", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("jurnaldetil_idr", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("channel_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("strukturunit_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("strukturunit_name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("ref_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("ref_line", GetType(System.Int64)))
        tbl.Columns.Add(New DataColumn("region_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("branch_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("budget_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("budget_name", GetType(System.String)))

        tbl.Columns.Add(New DataColumn("advance_descr", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("amount_foreign", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("rate", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("amount_idr", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("ppn_foreign", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("pph_foreign", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("ppn_idr", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("pph_idr", GetType(System.Decimal)))

        '-------------------------------
        'Default Value: 
        tbl.Columns("jurnal_id").DefaultValue = ""
        tbl.Columns("jurnaldetil_line").DefaultValue = 0
        tbl.Columns("jurnaldetil_dk").DefaultValue = ""
        tbl.Columns("jurnaldetil_descr").DefaultValue = ""
        tbl.Columns("rekanan_id").DefaultValue = 0
        tbl.Columns("rekanan_name").DefaultValue = ""
        tbl.Columns("acc_id").DefaultValue = "0"
        tbl.Columns("currency_id").DefaultValue = 0
        tbl.Columns("currency_name").DefaultValue = ""
        tbl.Columns("jurnaldetil_foreign").DefaultValue = 0
        tbl.Columns("jurnaldetil_foreignrate").DefaultValue = 0
        tbl.Columns("jurnaldetil_idr").DefaultValue = 0
        tbl.Columns("channel_id").DefaultValue = ""
        tbl.Columns("strukturunit_id").DefaultValue = 0
        tbl.Columns("strukturunit_name").DefaultValue = ""
        tbl.Columns("ref_id").DefaultValue = ""
        tbl.Columns("ref_line").DefaultValue = 0
        tbl.Columns("region_id").DefaultValue = 0
        tbl.Columns("branch_id").DefaultValue = 0
        tbl.Columns("budget_id").DefaultValue = 0
        tbl.Columns("budget_name").DefaultValue = ""

        tbl.Columns("advance_descr").DefaultValue = String.Empty
        tbl.Columns("amount_foreign").DefaultValue = 0
        tbl.Columns("rate").DefaultValue = 0
        tbl.Columns("amount_idr").DefaultValue = 0
        tbl.Columns("ppn_foreign").DefaultValue = 0
        tbl.Columns("pph_foreign").DefaultValue = 0
        tbl.Columns("ppn_idr").DefaultValue = 0
        tbl.Columns("pph_idr").DefaultValue = 0

        Return tbl

    End Function

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Public Sub SetControls_LockingTransactionTryLocking() Implements ILocking.SetControls_LockingTransactionTryLocking
        'Dim status As clsLockingTransaction.LockStatus

        'status = clsLockingTransaction.LockStatus.LockedByMe

        'If Me._USER_TYPE = "STAFF" Then
        '    Select Case status
        '        Case clsLockingTransaction.LockStatus.Locked
        '            Me.tbtnDel.Enabled = False
        '            Me.tbtnSave.Enabled = False
        '        Case clsLockingTransaction.LockStatus.LockedByMe
        '            If Me.tbl_TrnJurnal_Temp.Rows(0).Item("jurnal_isdisabled").ToString = "1" Then
        '                Me.tbtnDel.Enabled = False
        '                Me.tbtnSave.Enabled = False
        '                Me.locking.Clear()
        '            ElseIf Me.tbl_TrnJurnal_Temp.Rows(0).Item("jurnal_isposted").ToString = "1" Then
        '                Me.tbtnDel.Enabled = False
        '                Me.tbtnSave.Enabled = False
        '                Me.locking.Clear()
        '            Else
        '                Me.tbtnDel.Enabled = False
        '                Me.tbtnSave.Enabled = True
        '            End If
        '    End Select
        'ElseIf Me._USER_TYPE = "SPV" Then
        '    Select Case status
        '        Case clsLockingTransaction.LockStatus.Locked
        '            Me.tbtnDel.Enabled = False
        '            Me.tbtnSave.Enabled = False
        '        Case clsLockingTransaction.LockStatus.LockedByMe
        '            Me.tbtnDel.Enabled = False
        '            Me.tbtnSave.Enabled = True
        '    End Select
        'End If
    End Sub

    Private Sub chkSelectAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkSelectAll.CheckedChanged
        If Me.chkSelectAll.CheckState = CheckState.Checked Then
            For i As Integer = 0 To Me.DgvTrnAdvance.RowCount - 1
                Me.DgvTrnAdvance.Rows(i).Cells("pilih").Value = True
            Next
        Else
            For i As Integer = 0 To Me.DgvTrnAdvance.RowCount - 1
                Me.DgvTrnAdvance.Rows(i).Cells("pilih").Value = False
            Next
        End If
    End Sub

End Class
