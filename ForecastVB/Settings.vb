﻿Imports ForecastVB.FilterItem

Public Class Settings

    Private tabelNaam = "dbo.Cursussen" 'De tabel naam waarin de kolomen moeten worden gezocht
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.

        setKolomNaam()
        setFactorLijst()
        ListViewStarter()
    End Sub

    Private Sub setFactorLijst()
        cbbFactor.Items.Add("=")
        cbbFactor.Items.Add("<>")
        cbbFactor.Items.Add("<")
        cbbFactor.Items.Add("<=")
        cbbFactor.Items.Add(">")
        cbbFactor.Items.Add(">=")
        cbbFactor.Items.Add("BETWEEN")
        cbbFactor.Items.Add("NOT BETWEEN")
        cbbFactor.Items.Add("LIKE")
        cbbFactor.Items.Add("NOT LIKE")
        cbbFactor.Items.Add("IN")
        cbbFactor.Items.Add("NOT IN")
    End Sub

    ''' <summary>
    ''' Alle kolom koppen van de lijst in de database worden opgehaald en in een dropdown list gestoken om deze eenvoudig te selecteren.
    ''' Zo wordt voorkomen dat de gebruiker de verkeerde naamin geeft voor een kolomn kop
    ''' </summary>
    Private Sub setKolomNaam()
        Dim sqlUtil As New SQLUtil
        Dim kolommen As ArrayList

        kolommen = sqlUtil.getArrayList("SELECT name FROM Sys.columns WHERE object_id = OBJECT_ID('" + tabelNaam + "');")

        cbbKolom.Items.AddRange(kolommen.ToArray)
    End Sub

    ''' <summary>
    ''' Genereert de kolom koppen van de tabel op het settings scherm
    ''' </summary>
    Private Sub ListViewStarter()
        lsvFilter.Columns.Add("Kolom", 250)
        lsvFilter.Columns.Add("Factor", 100)
        lsvFilter.Columns.Add("Filter", 225)
    End Sub

    Private Function createFilterList() As ArrayList
        Dim itemList As New ArrayList

        For Each item As ListViewItem In lsvFilter.Items
            Dim f As New FilterItem
            f.kolom = item.SubItems.Item(0).Text
            f.factor = item.SubItems.Item(1).Text
            f.filter = item.SubItems.Item(2).Text
            itemList.Add(f)
        Next

        Return itemList
    End Function

    ''' <summary>
    ''' Ingestelde parameters worden door op de toevoegen knop te drukken toegevoegd aan de te filteren lijst
    ''' </summary>
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click

        Dim lvi As New ListViewItem(cbbKolom.Text, 0)
        lvi.SubItems.Add(cbbFactor.Text)
        lvi.SubItems.Add(txtOmschrijving.Text)

        lsvFilter.Items.AddRange(New ListViewItem() {lvi})

    End Sub

    ''' <summary>
    ''' Geselecteerde item, of geselecteerde items worden verwijderd uit de lijst door op de verwijder knop te drukken
    ''' </summary>
    Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
        If lsvFilter.SelectedItems.Count = 0 Then
            MessageBox.Show("Geen item geselecteerd")
        Else
            For Each i As ListViewItem In lsvFilter.SelectedItems
                lsvFilter.Items.Remove(i)
            Next
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        OpenFileDialog1.Filter = "JSON file|*.json"
        OpenFileDialog1.Title = "Open a JSON File"
        OpenFileDialog1.ShowDialog()
        Dim j As New JSONParser()
        Dim filters = j.read(OpenFileDialog1.FileName)

        lsvFilter.Clear()
        ListViewStarter()

        For Each f As FilterItem In filters
            Dim lvi As New ListViewItem(f.kolom, 0)
            lvi.SubItems.Add(f.factor)
            lvi.SubItems.Add(f.filter)

            lsvFilter.Items.Add(lvi)
        Next
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        SaveFileDialog1.Filter = "JSON file|*.json"
        SaveFileDialog1.Title = "Save a JSON File"
        SaveFileDialog1.ShowDialog()

        If SaveFileDialog1.FileName <> "" Then
            Dim j As New JSONParser()
            Dim filters As New ArrayList
            filters = createFilterList()
            My.Computer.FileSystem.WriteAllText(SaveFileDialog1.FileName, j.save(filters), False)
        End If
    End Sub
End Class