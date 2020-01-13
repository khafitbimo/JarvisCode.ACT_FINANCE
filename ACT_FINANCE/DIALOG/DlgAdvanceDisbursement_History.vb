Imports System.Windows.Forms

Public Class DlgAdvanceDisbursement_History

    Private _DSN As String
    Private _advancedisbursement_id As String

    Private tbl_TrnAdvanceDisbursementLog As DataTable = DatabaseUtils.CreateTbl(Of transaksi_advancedisbursementlog)()

    Sub New(ByVal advanceDisbursementID As String, ByVal dsn As String)
        Me.InitializeComponent()

        Me._DSN = dsn
        Me._advancedisbursement_id = advanceDisbursementID
    End Sub

    Private Sub Retrieve()
        Dim db As New DataClassesFrmDataContext(Me._DSN)
        Dim query As IQueryable(Of transaksi_advancedisbursementlog)

        db.OpenConnectionWithRole()

        Me.Cursor = Cursors.WaitCursor
        Try
            Me.tbl_TrnAdvanceDisbursementLog.Clear()

            query = db.transaksi_advancedisbursementlogs.Where(Function(p) p.advancedisbursement_id = Me._advancedisbursement_id)
            query = query.OrderByDescending(Function(p) p.log_userdt)

            DatabaseUtils.DataFill(Me.tbl_TrnAdvanceDisbursementLog, query)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        Finally
            db.CloseConnectionWithRole()
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub DlgAdvanceDisbursement_History_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.GCLogHistory.DataSource = Me.tbl_TrnAdvanceDisbursementLog

        Me.Retrieve()
    End Sub
End Class
