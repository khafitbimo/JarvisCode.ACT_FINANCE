Public Class dlgTrnJurnal_PV_List_AP_ChangeBookDatePeriode

    Private DSN As String
    Private CHANNEL As String
    Private myOwner As System.Windows.Forms.IWin32Window
    Private retObj As Object
    Private objFormError As Windows.Forms.ErrorProvider = New Windows.Forms.ErrorProvider

    Private tbl_MstPeriode As DataTable = clsDataset.CreateTblMstPeriodeCombo()
    Private tbl_MstBankacc As DataTable = clsDataset.CreateTblMstBankAccCombo()
    Private tbl_MstPaymentType As DataTable = clsDataset.CreateTblMstPaymenttypeCombo()
    Private tbl_MstAcc_ca As DataTable = clsDataset.CreateTblMstAccountCaCombo()


    Public Sub New(ByVal _dsn As String)

        ' This call is required by the designer.
        InitializeComponent()
        Me.DSN = _dsn

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Shadows Function OpenDialog(ByVal owner As System.Windows.Forms.IWin32Window, _
                ByVal _channel_id As String) As Object

        Me.CHANNEL = _channel_id
        Me.myOwner = owner
        MyBase.ShowDialog(owner)
        Return retObj
    End Function

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Dim bookDate As Date
        Dim periode As String
        Dim isbankid As Int16
        Dim bankid As Int32 = 0
        Dim ispaymenttype As Int16
        Dim paymenttype As String = "0"
        Dim isbilyetdate As Int16
        Dim bilyetdate As Date
        Dim iseffectivedate As Int16
        Dim effectivedate As Date
        Dim isacccaid As Int16
        Dim acccaid As Integer

        Dim thisRetObj As Collection = New Collection

        bookDate = Me.obj_Jurnal_bookdate.Value
        periode = Me.obj_Periode_id.SelectedValue

        isbankid = Me.chkBank.CheckState
        bankid = Me.cboBank.SelectedValue

        ispaymenttype = Me.chkPaymentType.CheckState
        paymenttype = Me.cboPaymentType.SelectedValue

        isbilyetdate = Me.chkBilyetDate.CheckState
        bilyetdate = Me.obj_Jurnal_bilyetdate.Value

        iseffectivedate = Me.chkEffectiveDate.CheckState
        effectivedate = Me.obj_Jurnal_paymentdate.Value

        isacccaid = Me.chkAccCaId.CheckState
        acccaid = Me.cboAccCaId.SelectedValue

        If Me.Check_BookDatePeriode() Then
            Exit Sub
        End If

        thisRetObj.Add(bookDate, "bookdate")
        thisRetObj.Add(periode, "periode")

        thisRetObj.Add(isbankid, "isbankid")
        thisRetObj.Add(bankid, "bankid")

        thisRetObj.Add(ispaymenttype, "ispaymenttype")
        thisRetObj.Add(paymenttype, "paymenttype")

        thisRetObj.Add(isbilyetdate, "isbilyetdate")
        thisRetObj.Add(bilyetdate, "bilyetdate")

        thisRetObj.Add(iseffectivedate, "iseffectivedate")
        thisRetObj.Add(effectivedate, "effectivedate")

        thisRetObj.Add(isacccaid, "isacccaid")
        thisRetObj.Add(acccaid, "acccaid")

        retObj = thisRetObj

        Me.Close()

    End Sub

    Private Sub dlgTrnJurnal_PV_List_AP_ChangeBookDatePeriode_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim clsDataFill As clsDataFiller = New clsDataFiller(Me.DSN)
        Dim dr() As DataRow
        clsDataFill.ComboFill(Me.obj_Periode_id, "periode_id", "periode_name", Me.tbl_MstPeriode, "ms_MstPeriodeCombo_Select", " channel_id = '" & Me.CHANNEL & "' ")
        Me.tbl_MstPeriode.DefaultView.Sort = "periode_name"

        clsDataFill.DataFillForComboAngka("bankacc_id", "bankacc_reportname", Me.tbl_MstBankacc, "ms_MstBankaccCombo_Select", " channel_id = '" & Me.CHANNEL & "' ")
        Me.tbl_MstBankacc.DefaultView.Sort = "bankacc_reportname"

        clsDataFill.ComboFillDec(Me.cboAccCaId, "acc_ca_id", "acc_ca_shortname", tbl_MstAcc_ca, "ms_MstAccountCaCombo_Select", "  acc_ca_type = 2  ")
        Me.tbl_MstAcc_ca.DefaultView.Sort = "acc_ca_shortname"

        cboBank.DisplayMember = "bankacc_reportname"
        cboBank.ValueMember = "bankacc_id"
        cboBank.DataSource = Me.tbl_MstBankacc

        clsDataFill.DataFill(Me.tbl_MstPaymentType, "cp_MstPaymenttype_Select", "")
        Me.tbl_MstPaymentType.DefaultView.Sort = "paymenttype_name"

        cboPaymentType.DataSource = Me.tbl_MstPaymentType
        cboPaymentType.ValueMember = "paymenttype_id"
        cboPaymentType.DisplayMember = "paymenttype_name"

        Dim smd As String = Now.ToString("yy") + Now.ToString("MM")
        'dr = Me.tbl_MstPeriode.Select(String.Format("periode_id like '%{0}%'", smd))
        dr = Me.tbl_MstPeriode.Select(String.Format("substring(periode_id,3,4)={0}", smd))

        If dr.Length > 0 Then
            Me.obj_Periode_id.SelectedValue = dr(0).Item("periode_id").ToString
        End If
    End Sub

    Private Function Check_BookDatePeriode() As Boolean
        Dim dr() As DataRow = Me.tbl_MstPeriode.Select(String.Format("periode_id='{0}'", Me.obj_Periode_id.SelectedValue))
        Dim tgl_start As Date = dr(0).Item("periode_datestart")
        Dim tgl_end As Date = dr(0).Item("periode_dateend")
        Dim tgl As Date = CDate(Me.obj_Jurnal_bookdate.Value).Date
        Dim message As String = ""

        Try
            If dr(0).Item("periode_isclosed") = True Then
                Me.objFormError.SetError(Me.obj_Periode_id, "period has closed! Please contact your administrator for open this period")
                Throw New Exception("period has closed!! Please contact your administrator for open this period")
            Else
                Me.objFormError.SetError(Me.obj_Periode_id, "")
            End If

            If tgl >= tgl_start And tgl <= tgl_end Then
                Me.objFormError.SetError(Me.obj_Periode_id, "")
                Me.objFormError.SetError(Me.obj_Jurnal_bookdate, "")
            Else
                message = "Bookdate does not match with the Period!!"
                Me.objFormError.SetError(Me.obj_Periode_id, message)
                Me.objFormError.SetError(Me.obj_Jurnal_bookdate, message)
                Throw New Exception(message)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return True
        End Try


    End Function

End Class