Imports System.ComponentModel
Imports System.IO
Imports ForecastVB.FilterItem
Imports Microsoft.VisualBasic.FileIO

Public Class Settings

    ' Directory waar alle filter bestanden worden in opgeslaan
    Dim saveDirectory As String = SpecialDirectories.MyDocuments + "//Predictie Filters//"
    Private filters As ArrayList
    Private root As MainScreen

    Public Sub New(main As MainScreen)
        filters = main.getFilters()
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.

        makeFilterFileList()
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
        Dim kolommen As New ArrayList
        Dim filtersBLL As New FiltersBLL

        kolommen = filtersBLL.getKolomkopCursussen()

        cbbKolom.Items.AddRange(kolommen.ToArray)
    End Sub

    ''' <summary>
    ''' Genereert de kolom koppen van de tabel op het settings scherm
    ''' </summary>
    Private Sub ListViewStarter()
        lsvFilter.Clear()
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

    Private Sub makeFilterFileList()
        cbbFilterFiles.Items.Clear()
        Dim filterFiles As String() = Directory.GetFiles(saveDirectory)
        For Each file As String In filterFiles
            Dim filterNames As String = System.IO.Path.GetFileNameWithoutExtension(file)
            cbbFilterFiles.Items.Add(filterNames)
        Next
    End Sub

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

    Private Sub btnOpen_Click(sender As Object, e As EventArgs) Handles btnOpen.Click
        OpenFileDialog1.Filter = "JSON file|*.json"
        OpenFileDialog1.Title = "Open a JSON File"
        OpenFileDialog1.ShowDialog()
        'todo: auto save list
        If OpenFileDialog1.FileName <> "" And My.Computer.FileSystem.FileExists(OpenFileDialog1.FileName) Then
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

            makeFilterFileList()
        End If

    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        Try
            'SaveFileDialog1.Filter = "JSON file|*.json"
            'SaveFileDialog1.Title = "Save a JSON File"
            'SaveFileDialog1.ShowDialog()

            'TODO Test of naam reeds in folder bestaat
            If txtFileName.Text <> "" Then
                Dim j As New JSONParser()
                Dim filters As New ArrayList
                filters = createFilterList()
                'My.Computer.FileSystem.WriteAllText(SaveFileDialog1.FileName, j.save(filters), False)

                If Not (My.Computer.FileSystem.DirectoryExists(saveDirectory)) Then
                    My.Computer.FileSystem.CreateDirectory(saveDirectory)
                End If

                My.Computer.FileSystem.WriteAllText(saveDirectory + txtFileName.Text + ".json", j.save(filters), False)
                txtFileName.Clear()

                ' Reset listview met filterbestanden
                makeFilterFileList()
            Else
                Throw New ApplicationException("Gelieve een bestandsnaam in te stellen")
            End If
        Catch ex As ApplicationException
            MessageBox.Show(ex.Message)
        End Try




    End Sub

    Private Sub txtFileName_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFileName.KeyPress
        If Not (Char.IsLetterOrDigit(e.KeyChar) OrElse e.KeyChar = "."c) Then
            If e.KeyChar = CChar(ChrW(Keys.Back)) Or e.KeyChar = CChar(ChrW(Keys.Space)) Then
                e.Handled = False
            Else
                e.Handled = True
            End If
        End If
    End Sub



    Private Sub Settings_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        root.addFilters(filters)
    End Sub
End Class