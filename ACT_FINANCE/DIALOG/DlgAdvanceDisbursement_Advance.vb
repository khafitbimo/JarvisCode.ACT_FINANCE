Imports System.Windows.Forms
Imports System.Data.Linq

Public Class DlgAdvanceDisbursement_Advance

    Private _DSN As String
    Private _advancedisbursement_id As String

    Private tbl_TrnAdvance As DataTable = DatabaseUtils.CreateTbl(Of act_TrnAdvanceDisbursement_AdvanceSelectResult)()

    Sub New(ByVal advancedisbursement_id As String, ByVal DSN As String)
        Me.InitializeComponent()

        Me._advancedisbursement_id = advancedisbursement_id
        Me._DSN = DSN
    End Sub

    Private Sub Retrieve()
        Dim db As New DataClassesFrmDataContext(Me._DSN)
        Dim advances As ISingleResult(Of act_TrnAdvanceDisbursement_AdvanceSelectResult)

        db.OpenConnectionWithRole()

        Try
            advances = db.act_TrnAdvanceDisbursement_AdvanceSelect(Me._advancedisbursement_id)

            Me.tbl_TrnAdvance.Clear()

            DatabaseUtils.DataFill(Me.tbl_TrnAdvance, advances.GetEnumerator())
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        Finally
            db.CloseConnectionWithRole()
        End Try
    End Sub

    Private Sub DlgAdvanceDisbursement_Advance_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Cursor = Cursors.WaitCursor

        Me.GCAdvance.DataSource = Me.tbl_TrnAdvance

        Me.Retrieve()

        Me.Cursor = Cursors.Default
    End Sub
End Class
