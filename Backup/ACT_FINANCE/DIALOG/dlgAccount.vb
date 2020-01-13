Imports System.Windows.Forms
'Imports System.Data.OleDb

Public Class dlgAccount
    Private DSN As String
    Private combo As clsDataFiller
    Private tblCurrency As DataTable = clsDataset.CreateTblMstCurrency
    Private tblAccount As DataTable = clsDataset.CreateTblMstAccountCombo

    Sub New(ByVal DSN As String)
        Me.InitializeComponent()
        Me.DSN = DSN
        Me.combo = New clsDataFiller(DSN)
    End Sub


    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Function ComboForCurrency(ByVal ID As String) As Boolean
        If ID <> String.Empty Then
            Me.combo.ComboFill(Me.cmbCurrency, "currency_id", "currency_shortname", tblCurrency, "ms_mstBankCur_ComboSelect", String.Empty, String.Empty)
            Me.cmbCurrency.SelectedValue = ID
        Else
            Me.combo.ComboFill(Me.cmbCurrency, "currency_id", "currency_shortname", tblCurrency, "ms_mstBankCur_ComboSelect", String.Empty, String.Empty)
        End If
    End Function

    Private Function ComboForAccount(ByVal IDS As String) As Boolean
        Dim criteria As String
        criteria = "acc_id LIKE '1002%'"
        If IDS <> String.Empty Then
            Me.combo.ComboFill(Me.cmbAccount, "acc_id", "acc_name", tblAccount, "ms_MstAcc_Select", criteria, String.Empty)
            Me.cmbAccount.SelectedValue = IDS
        Else
            Me.combo.ComboFill(Me.cmbAccount, "acc_id", "acc_name", tblAccount, "ms_MstAcc_Select", criteria, String.Empty)
        End If
    End Function

    Private Sub dlgAccount_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ID As String
        Dim IDS As String


        ID = txtIdCurrencyforCombo.Text
        IDS = txtAccountforCombo.Text

        Me.ComboForAccount(IDS)
        Me.ComboForCurrency(ID)

    End Sub
End Class
