Public Class dlgTrnJurnal_PV_List_AP_MessageBox_PostingListResult

    Private tblResult As DataTable = New DataTable
    Private success, failed, total As Integer

    Sub New(ByVal _tbl As DataTable, ByVal _totalData As Integer, ByVal _totalSuccess As Integer, ByVal _totalFailed As Integer)

        ' This call is required by the designer.
        InitializeComponent()
        Me.tblResult = _tbl.Copy
        Me.total = _totalData
        Me.success = _totalSuccess
        Me.failed = _totalFailed
        ' Add any initialization after the InitializeComponent() call.

    End Sub



    Private Sub dlgTrnJurnal_PV_List_AP_MessageBox_PostingListResult_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.dgvResultPosting.DataSource = Me.tblResult
        Me.FormatDgvTrnJurnal(Me.dgvResultPosting)

        Me.obj_txTotal.Text = Me.total
        Me.obj_txSuccess.Text = Me.success
        Me.obj_txFailed.Text = Me.failed
    End Sub

    Private Function FormatDgvTrnJurnal(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        Dim cJurnal_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnal_status As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnal_event As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn

        cJurnal_id.Name = "jurnal_id"
        cJurnal_id.HeaderText = "Jurnal ID"
        cJurnal_id.DataPropertyName = "jurnal_id"
        cJurnal_id.Width = 100
        cJurnal_id.Visible = True
        cJurnal_id.ReadOnly = True

        cJurnal_event.Name = "event"
        cJurnal_event.HeaderText = "Event"
        cJurnal_event.DataPropertyName = "event"
        cJurnal_event.Width = 100
        cJurnal_event.Visible = True
        cJurnal_event.ReadOnly = True

        cJurnal_status.Name = "status"
        cJurnal_status.HeaderText = "Status Failed"
        cJurnal_status.DataPropertyName = "status"
        cJurnal_status.Width = 500
        cJurnal_status.Visible = True
        cJurnal_status.ReadOnly = True


        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
        {cJurnal_id, cJurnal_event, cJurnal_status})


        ' DgvTrnJurnal Behaviours: 
        objDgv.AllowUserToAddRows = False
        objDgv.AllowUserToDeleteRows = False
        objDgv.AllowUserToResizeRows = False
        objDgv.AutoGenerateColumns = False
        objDgv.ReadOnly = True

    End Function

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub
End Class