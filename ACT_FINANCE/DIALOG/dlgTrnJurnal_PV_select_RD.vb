Imports System.Windows.Forms
Imports System.Data.OleDb


Public Class dlgTrnJurnal_PV_select_RD
    Private DSN As String
    Private dataFiller As clsDataFiller
    Private channel_id As String
    Private rekanan_id As Decimal
    Private tbl_tandaTerima_detil As New DataTable

    Sub New(ByVal DSN As String, ByVal rekanan_id As Decimal, ByVal channel_id As String)
        Me.InitializeComponent()
        Me.DSN = DSN
        Me.dataFiller = New clsDataFiller(DSN)
        Me.rekanan_id = rekanan_id
        Me.channel_id = channel_id
    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Function dlgTrnJurnal_PV_select_RD_Load() As Boolean

        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter
        Dim criteria = " rekanan_id = " + Me.rekanan_id.ToString


        dbCmd = New OleDb.OleDbCommand("act_TrnJurnaldetil_PV_Select_RD", dbConn)
        dbCmd.Parameters.Add("@channel_id", Data.OleDb.OleDbType.VarWChar)
        dbCmd.Parameters("@channel_id").Value = channel_id
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarWChar)
        dbCmd.Parameters("@Criteria").Value = criteria


        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)
        Me.tbl_tandaTerima_detil.Clear()
        Dim cookie As Byte() = Nothing

        Try
            dbConn.Open()
            clsApplicationRole.SetAppRole(dbConn, cookie)
            dbDA.Fill(Me.tbl_tandaTerima_detil)
            Me.gridControlSelectRD.DataSource = Me.tbl_tandaTerima_detil
        Catch ex As Exception
            MessageBox.Show(ex.Message, "dlgTrnJurnalSelect" & ": dlgTrnJurnalDetilSelect_LoadDetil()", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            clsApplicationRole.UnsetAppRole(dbConn, cookie)
            dbConn.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Function

    Private Sub dlgTrnJurnal_PV_select_RD_Load1(sender As Object, e As EventArgs) Handles Me.Load
        dlgTrnJurnal_PV_select_RD_Load()
    End Sub
End Class
