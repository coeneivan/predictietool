Imports System.ComponentModel
Imports System.IO
Imports Microsoft.VisualBasic.FileIO

Public Class Settings

    ' Directory waar alle filter bestanden worden in opgeslaan
    Dim saveDirectory As String = SpecialDirectories.MyDocuments + "//Predictie Filters//"
    Private filters As ArrayList
    Private root As MainScreen
    Dim selectedIndex As Integer = -1
    Dim newFileName As String

    Public Sub New(main As MainScreen)
        filters = main.getFilters()
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        root = main
        makeFilterFileList()
        setKolomNaam()
        setFactorLijst()
        ListViewStarter()
    End Sub

    Friend Function getSaveDirectory() As String
        Return saveDirectory
    End Function
    ''' <summary>
    ''' Alle factoren worden in een list gestoken om deze eenvoudig te selecteren.
    ''' Zo wordt voorkomen dat de gebruiker een verkeerde factor in geeft
    ''' </summary>
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
    ''' Zo wordt voorkomen dat de gebruiker de verkeerde naam in geeft voor een kolomn kop
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

    ''' <summary>
    ''' Haalt de volledige filterlist en steek ze in de gepaste combobox
    ''' </summary>
    Private Sub makeFilterFileList()
        doesDirectoryExistifNotCreate()

        cbbFilterFiles.Items.Clear()
        Try
            If root.getFilterList().Count > 0 Then
                cbbFilterFiles.Items.AddRange(root.getFilterList.ToArray)
            End If
        Catch ex As Exception
            'TODO: catch null exception
            Throw ex
        End Try


    End Sub

    ''' <summary>
    ''' Ingestelde parameters worden door op de toevoegen knop te drukken toegevoegd aan de te filteren lijst
    ''' </summary>
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click

        ' TODO Voeg controlle toe of filter correct is. Regular expression?

        Dim lvi As New ListViewItem(cbbKolom.Text, 0)
        lvi.SubItems.Add(cbbFactor.Text)
        lvi.SubItems.Add(txtOmschrijving.Text)

        lsvFilter.Items.AddRange(New ListViewItem() {lvi})

        saveListToCurrentFilter()

        txtOmschrijving.Clear()
    End Sub
    ''' <summary>
    ''' Slaat lijst op in de huidige filterlist
    ''' </summary>
    Private Sub saveListToCurrentFilter()
        Dim j As New JSONParser()
        Dim filters As New ArrayList
        filters = createFilterList()
        'My.Computer.FileSystem.WriteAllText(SaveFileDialog1.FileName, j.save(filters), False)

        If (cbbFilterFiles.SelectedItem <> "") Then
            My.Computer.FileSystem.WriteAllText(saveDirectory + cbbFilterFiles.SelectedItem.ToString + ".json", j.save(filters), False)
        End If
        txtFileName.Clear()

        root.refreshFilterList()
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

            saveListToCurrentFilter()
        End If
    End Sub
    ''' <summary>
    ''' Opent een dialoog venster om een bestand te selecteren en openen
    ''' </summary>
    Private Sub btnOpen_Click(sender As Object, e As EventArgs) Handles btnOpen.Click
        OpenFileDialog1.Filter = "JSON file|*.json"
        OpenFileDialog1.Title = "Open a JSON File"
        OpenFileDialog1.ShowDialog()

        If OpenFileDialog1.FileName <> "" And My.Computer.FileSystem.FileExists(OpenFileDialog1.FileName) Then
            Try
                ' Creeër een input box om het op te slaan bestand een naam te geven
                Dim addFile As AddFile = New AddFile(System.IO.Path.GetFileNameWithoutExtension(OpenFileDialog1.FileName), Me)
                addFile.ShowDialog()

                If (addFile.DialogResult = DialogResult.OK) Then
                    Dim geefNaamInputbox As String = newFileName


                    Dim j As New JSONParser()
                    Dim filters = j.readFilters(OpenFileDialog1.FileName)
                    readFilterFile(filters)

                    My.Computer.FileSystem.WriteAllText(saveDirectory + geefNaamInputbox + ".json", j.save(filters), False)

                    root.refreshFilterList()

                    ' Reset listview met filterbestanden en filterlist
                    makeFilterFileList()
                    ListViewStarter()

                End If
            Catch ex As ApplicationException
                MessageBox.Show(ex.Message)
            End Try
        End If

    End Sub
    ''' <summary>
    ''' Leest filters uit het bestand en steekt ze in een listview
    ''' </summary>
    ''' <param name="filters">Arraylist van filteritems die in de listview moet komen</param>
    Private Sub readFilterFile(filters As ArrayList)
        lsvFilter.Clear()
        ListViewStarter()

        For Each f As FilterItem In filters
            Dim lvi As New ListViewItem(f.kolom, 0)
            lvi.SubItems.Add(f.factor)
            lvi.SubItems.Add(f.filter)

            lsvFilter.Items.Add(lvi)
        Next

    End Sub
    ''' <summary>
    ''' Slaat huidige lijst op in een bestand
    ''' </summary>
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        Try
            Dim fileName As String = txtFileName.Text

            If (txtFileName.Text = "") Then
                Throw New ApplicationException("Gelieve een bestandsnaam in te stellen")
            End If

            If My.Computer.FileSystem.FileExists(saveDirectory + fileName + ".json") Then
                Throw New ApplicationException("Filternaam bestaat al, gelieve de filter een andere naam te geven.")
            End If

            Dim j As New JSONParser()
            Dim filters As New ArrayList
            filters = createFilterList()
            'My.Computer.FileSystem.WriteAllText(SaveFileDialog1.FileName, j.save(filters), False)

            doesDirectoryExistifNotCreate()

            My.Computer.FileSystem.WriteAllText(saveDirectory + fileName + ".json", j.save(filters), False)
            txtFileName.Clear()

            root.refreshFilterList()

            ' Reset listview met filterbestanden en filterlist
            makeFilterFileList()
            ListViewStarter()

            cbbFilterFiles.SelectedItem = fileName

        Catch ex As ApplicationException
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub txtFileName_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFileName.KeyPress
        filenameKeyPressCheck(sender, e)
    End Sub

    Private Sub cbbFilterFiles_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbbFilterFiles.SelectedIndexChanged
        Dim j As New JSONParser
        If cbbFilterFiles.SelectedItem <> "" Then
            readFilterFile(j.readFilters(saveDirectory + cbbFilterFiles.SelectedItem.ToString() + ".json"))
        End If

    End Sub

    Private Sub Settings_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If filters.Count <> 0 Then
            root.addFilters(filters)
        End If
        root.refreshFilterList()
        root.refreshCombobox()
    End Sub

    Private Sub btnRemoveFilter_Click(sender As Object, e As EventArgs) Handles btnRemoveFilter.Click
        Try
            Dim resultaat As Integer = MessageBox.Show("Weet u zeker dat u de filter " + Chr(34) + cbbFilterFiles.SelectedItem.ToString + Chr(34) + " wilt verwijderen?", "Filter verwijderen", MessageBoxButtons.YesNo)

            If (resultaat = 6) Then
                My.Computer.FileSystem.DeleteFile(saveDirectory + cbbFilterFiles.SelectedItem.ToString + ".json")
                makeFilterFileList()
                ListViewStarter()
                root.refreshFilterList()
                makeFilterFileList()
            End If
        Catch ex As FileNotFoundException
            MessageBox.Show("Het bestand werd niet terug gevonden")
        Catch ex As IOException
            MessageBox.Show("Er werd een probleem met het apparaat ondervonden.")
        Catch ex As NullReferenceException
            MessageBox.Show("Gelieve een filter te selecteren om te verwijderen.")
        End Try
    End Sub

    ''' <summary>
    ''' Bestaat directory? bestaat hij niet, maak hem aan
    ''' </summary>
    Private Sub doesDirectoryExistifNotCreate()
        If Not (My.Computer.FileSystem.DirectoryExists(saveDirectory)) Then
            My.Computer.FileSystem.CreateDirectory(saveDirectory)
        End If
    End Sub

    Public Sub filenameKeyPressCheck(sender As Object, e As KeyPressEventArgs)
        If Not (Char.IsLetterOrDigit(e.KeyChar) OrElse e.KeyChar = "."c) Then
            If e.KeyChar = CChar(ChrW(Keys.Back)) Or e.KeyChar = CChar(ChrW(Keys.Space)) Then
                e.Handled = False
            Else
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub Settings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cbbFilterFiles.SelectedItem = root.getSelectedList
    End Sub
    ''' <summary>
    ''' Maakt de listview leeg 
    ''' Klaar om een nieuwe filter list aan te maken
    ''' </summary>
    Private Sub btnAddNewList_Click(sender As Object, e As EventArgs) Handles btnAddNewList.Click
        ListViewStarter()
        cbbFilterFiles.Items.Add("")
        cbbFilterFiles.SelectedIndex = cbbFilterFiles.Items.Count - 1
    End Sub
    ''' <summary>
    ''' Zet de naam van huidige file
    ''' </summary>
    ''' <param name="f"></param>
    Public Sub setNewFileName(f As String)
        newFileName = f
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class