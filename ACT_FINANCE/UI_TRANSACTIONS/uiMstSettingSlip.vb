Imports Microsoft.Win32
Public Class uiMstSettingSlip
    Private Const mUiName As String = "MstSlipformat"
    Private Const SHOW_SAVE_CONFIRMATION As Boolean = True

    Private FILTER_QUERY_MODE As Boolean
    Private DATA_ISLOCKED As Boolean
    Private obj_error As Windows.Forms.ErrorProvider = New Windows.Forms.ErrorProvider

    'Private tbl_MstSlipformat As DataTable = CreateTblMstSlipformat()
    'Private tbl_MstSlipformat_Temp As DataTable = CreateTblMstSlipformat()
    'Private tbl_MstSlipformatfield As DataTable = CreateTblMstSlipformatfield()
    'Private tbl_MstSlipUsingOnProgram As DataTable

    Const m_UserRoot As String = "HKEY_CURRENT_USER"
    Const m_Subkey As String = "Software\SlipBank"
    Const m_KeyName As String = m_UserRoot & "\" & m_Subkey

    Private m_PrinterName As String
    Public Overrides Function btnSave_Click() As Boolean

        Me.Cursor = Cursors.WaitCursor
        Me.UserControl1_Save()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnSave_Click()
    End Function

    Private Sub btnFindPrinter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindPrinter.Click
        Dim dlgPrinter As New PrintDialog()

        dlgPrinter.ShowDialog()
        m_PrinterName = dlgPrinter.PrinterSettings.PrinterName
        txtPrinterName.Text = m_PrinterName

    End Sub
    Private Function UserControl1_Save() As Boolean


        Try
            Registry.SetValue(m_KeyName, "Printer Dot Matrix", txtPrinterName.Text)
            MsgBox("saved")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try



    End Function

    Public Sub Form_Load(ByVal sender As Object)
        If (Me.Browser IsNot Nothing And MyBase.Name = _Name) Or (Me.Browser Is Nothing And Application.ProductName <> _ProductName) Then
            txtPrinterName.Text = GetRegistryValue(m_Subkey, "Printer Dot Matrix")
        End If
    End Sub

    Private Sub uiMstSettingSlip_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Me.IsDevelopment = True Then Me.Form_Load(sender)

    End Sub

    Private Function GetRegistryValue(ByVal RootRegnya As String, ByVal NamaValuenya As String) As String
        Dim reg As RegistryKey
        Dim strTemp As String = ""
        reg = Registry.CurrentUser.OpenSubKey(RootRegnya)
        If reg IsNot Nothing Then
            reg.OpenSubKey(m_Subkey)
            'reg.Name
            If Not (reg Is Nothing) Then
                strTemp = reg.GetValue(NamaValuenya)
                reg.Close()
            End If
        Else
            strTemp = "[ Setting Slip Belum Ada ]"
        End If
        Return strTemp
    End Function
End Class
