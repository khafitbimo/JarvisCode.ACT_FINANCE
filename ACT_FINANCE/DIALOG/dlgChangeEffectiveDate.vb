Public Class dlgChangeEffectiveDate 
    Private mDSN As String
    Private retObj As Object = Nothing
    Private _channel As String = ""

    Private tbl_JurnalPVEffectiveDate As DataTable = New DataTable
    Private tbl_PaymentType As DataTable = New DataTable
    Private tbl_MstBankACC As DataTable = New DataTable
    Private tbl_MstAccCaName As DataTable = New DataTable

#Region " Properties "
    Public ReadOnly Property DSN() As String
        Get
            Return mDSN
        End Get
    End Property
#End Region

#Region " Constructor & Default Function"
    Public Sub New(ByVal dsn As String, _
            ByVal tbl_JurnalPVEffectiveDate As DataTable, ByVal tbl_PaymentType As DataTable, ByVal tbl_MstBankACC As DataTable, ByVal tbl_MstAccCaName As DataTable, ByVal channel As String)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.mDSN = dsn
        Me._channel = channel

        Me.tbl_JurnalPVEffectiveDate = tbl_JurnalPVEffectiveDate.Copy
        Me.tbl_PaymentType = tbl_PaymentType.Copy
        Me.tbl_MstBankACC = tbl_MstBankACC.Copy
        Me.tbl_MstAccCaName = tbl_MstAccCaName.Copy
        Me.ComboFillDXFromDataTable(Me.lueBankName, "bankacc_id", "bankacc_name", Me.tbl_MstBankACC)
        Me.ComboFillDXFromDataTable(Me.luePaymentType, "paymenttype_id", "paymenttype_name", Me.tbl_PaymentType)
        Me.ComboFillDXFromDataTable(Me.lueAccCaName, "acc_ca_id", "acc_ca_name", Me.tbl_MstAccCaName)

        BindingStop()
        BindingStart()
    End Sub

    Public Shadows Function OpenDialog(ByVal owner As System.Windows.Forms.IWin32Window) As Object
        MyBase.ShowDialog(owner)
        Return retObj
    End Function

    Private Function BindingStart() As Boolean
        Me.txtJurnalID.DataBindings.Add(New Binding("Text", Me.tbl_JurnalPVEffectiveDate, "jurnal_id"))
        Me.txtLine.DataBindings.Add(New Binding("Text", Me.tbl_JurnalPVEffectiveDate, "jurnaldetil_line"))
        Me.txtBilyetNo.DataBindings.Add(New Binding("Text", Me.tbl_JurnalPVEffectiveDate, "jurnalbilyet_no"))
        Me.txtEffectiveDate.DataBindings.Add(New Binding("Text", Me.tbl_JurnalPVEffectiveDate, "jurnalbilyet_dateeffective", True, DataSourceUpdateMode.OnPropertyChanged))
        Me.lueBankName.DataBindings.Add(New Binding("EditValue", Me.tbl_JurnalPVEffectiveDate, "jurnalbilyet_bank"))
        Me.luePaymentType.DataBindings.Add(New Binding("EditValue", Me.tbl_JurnalPVEffectiveDate, "paymenttype_id"))
        Me.txtCurrencyID.DataBindings.Add(New Binding("Text", Me.tbl_JurnalPVEffectiveDate, "currency_shortname"))
        Me.txtAmount.DataBindings.Add(New Binding("Text", Me.tbl_JurnalPVEffectiveDate, "jurnaldetil_foreign"))
        Me.txtRate.DataBindings.Add(New Binding("Text", Me.tbl_JurnalPVEffectiveDate, "jurnaldetil_foreignrate"))
        Me.txtAmountIDR.DataBindings.Add(New Binding("Text", Me.tbl_JurnalPVEffectiveDate, "jurnaldetil_idr"))
        Me.lueAccCaName.DataBindings.Add(New Binding("EditValue", Me.tbl_JurnalPVEffectiveDate, "region_id"))

        Return True
    End Function

    Private Function BindingStop() As Boolean
        'stop binding
        Me.txtJurnalID.DataBindings.Clear()
        Me.txtLine.DataBindings.Clear()
        Me.txtBilyetNo.DataBindings.Clear()
        Me.txtEffectiveDate.DataBindings.Clear()
        Me.lueBankName.DataBindings.Clear()
        Me.luePaymentType.DataBindings.Clear()
        Me.txtCurrencyID.DataBindings.Clear()
        Me.txtAmount.DataBindings.Clear()
        Me.txtRate.DataBindings.Clear()
        Me.txtAmountIDR.DataBindings.Clear()
        Me.lueAccCaName.DataBindings.Clear()
        Return True
    End Function

    Public Function ComboFillDXFromDataTable(ByRef combobox As DevExpress.XtraEditors.LookUpEdit, ByVal valuemember As String, ByVal displaymember As String, ByRef dt As DataTable) As Boolean
        combobox.Properties.DataSource = dt
        combobox.Properties.ValueMember = valuemember
        combobox.Properties.DisplayMember = displaymember

        combobox.Properties.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo(displaymember, 100, ""))
        combobox.Properties.ShowHeader = False
    End Function
#End Region

    Private Sub deEffectiveDate_TextChanged(sender As Object, e As EventArgs) Handles deEffectiveDate.TextChanged
        Me.txtEffectiveDate.Text = Me.deEffectiveDate.EditValue
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.retObj = Nothing
        Me.Close()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim thisRetObj As Collection = New Collection
        Dim success As Boolean

        Try
            success = Save()
            If success = True Then
                Me.tbl_JurnalPVEffectiveDate.AcceptChanges()
                thisRetObj.Add(Me.tbl_JurnalPVEffectiveDate.Copy(), "tbl_JurnalPVEffectiveDate")
                retObj = thisRetObj

                Me.Close()
            Else
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error Message")
        End Try

    End Sub

    Private Function Save() As Boolean
        Dim tbl_JurnalPVEffectiveDate_Changes As DataTable
        Dim success As Boolean
        Dim MasterDataState As System.Data.DataRowState
        Me.Cursor = Cursors.WaitCursor

        Me.BindingContext(Me.tbl_JurnalPVEffectiveDate).EndCurrentEdit()
        tbl_JurnalPVEffectiveDate_Changes = Me.tbl_JurnalPVEffectiveDate.GetChanges()

        If tbl_JurnalPVEffectiveDate_Changes IsNot Nothing Then
            MasterDataState = Me.tbl_JurnalPVEffectiveDate.Rows(0).RowState

            success = uiTrnJurnal_PV_EffectiveDate_Save(tbl_JurnalPVEffectiveDate_Changes, MasterDataState)

            If success Then
                Return True
            Else
                Return False
            End If
        Else
            Return False
        End If
    End Function

    Private Function uiTrnJurnal_PV_EffectiveDate_Save(ByVal objTbl As DataTable, ByVal MasterDataState As System.Data.DataRowState) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbCmdUpdate As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        dbCmdUpdate = New OleDb.OleDbCommand("act_TrnPVEffectiveData_Update2", dbConn)
        dbCmdUpdate.CommandType = CommandType.StoredProcedure
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_id", System.Data.OleDb.OleDbType.VarWChar, 24, "jurnal_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnaldetil_line", System.Data.OleDb.OleDbType.Integer, 4, "jurnaldetil_line"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnalbilyet_no", System.Data.OleDb.OleDbType.VarWChar, 24, "jurnalbilyet_no"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnalbilyet_dateeffective", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "jurnalbilyet_dateeffective"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@region_id", System.Data.OleDb.OleDbType.Integer, 12, "region_id"))

        dbDA = New OleDb.OleDbDataAdapter
        dbDA.UpdateCommand = dbCmdUpdate

        Dim cookie As Byte() = Nothing

        Try
            dbConn.Open()
            clsApplicationRole.SetAppRole(dbConn, cookie)
            dbDA.Update(objTbl)
            MsgBox("Data has been saved !", MsgBoxStyle.Information, "Information")

            Return True

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
    End Function
End Class