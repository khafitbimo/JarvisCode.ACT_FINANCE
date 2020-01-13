Imports System.Windows.Forms

Public Class dlgTrnCirculationRekanan
    Private rekananList As List(Of CirculationRekananItem)

    Public Class CirculationRekananItem
        Public Property pv_id As String
        Public Property rekanan_id As String
        Public Property rekanan_name As String
        Public Property deskripsi As String
    End Class

    Sub New(rekananList As List(Of CirculationRekananItem))
        Me.InitializeComponent()

        Me.rekananList = rekananList
    End Sub

    Private Sub dlgTrnCirculationRekanan_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.DGVRekananList.AutoGenerateColumns = False
        Me.DGVRekananList.DataSource = Me.rekananList
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class
