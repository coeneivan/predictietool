Public Class Settings

    Private tabelNaam = "dbo.Cursussen" 'De tabel naam waarin de kolomen moeten worden gezocht
    Private kolommen As ArrayList
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        setKolomNaam()
        ListViewStarter()
    End Sub

    Private Sub setKolomNaam()
        Dim sqlUtil As New SQLUtil
        kolommen = sqlUtil.getArrayList("SELECT name FROM Sys.columns WHERE object_id = OBJECT_ID('" + tabelNaam + "');")

        cbbKolom.Items.AddRange(kolommen.ToArray)
    End Sub

    Private Sub ListViewStarter()
        lsvFilter.Columns.Add("Kolom", 250)
        lsvFilter.Columns.Add("Factor", 150)
        lsvFilter.Columns.Add("Filter", 200)

    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click

        Dim lvi As New ListViewItem(cbbKolom.Text, 0)
        lvi.SubItems.Add(txtFactor.Text)
        lvi.SubItems.Add(txtOmschrijving.Text)

        lsvFilter.Items.AddRange(New ListViewItem() {lvi})

    End Sub

    Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
        If lsvFilter.SelectedItems.Count = 0 Then
            MessageBox.Show("Geen item geselecteerd")
        Else
            For Each i As ListViewItem In lsvFilter.SelectedItems
                lsvFilter.Items.Remove(i)
            Next
        End If
    End Sub
End Class