Imports System.Globalization
Imports System.IO
Imports System.Windows.Forms
Imports Microsoft.VisualBasic.FileIO

Public Class MainScreen

    Private filters As New ArrayList
    Private filterlist As ArrayList
    Private selectedFilterList As String
    Private saveDirectory As String = SpecialDirectories.MyDocuments + "//Predictie Filters//"
    Private lists As New Dictionary(Of String, List(Of Cursus))
    Private b As Bayes_Bayes_Linear
    Private s As SplashScreen1
    Private ready As Boolean = False
    Private Sub MainScreen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim start As DateTime = DateTime.Now
        s = New SplashScreen1()
        s.Show()
        Me.Visible = False
        refreshFilterList()
        s.Close()
        ready = True
        Me.Visible = True
        Console.WriteLine("Load: " + (DateTime.Now - start).ToString)

        Dim j As New JSONParser
        filters = j.readFilters(saveDirectory + cboFiltersList.SelectedItem.ToString() + ".json")

        'Console.WriteLine("Load: " + (DateTime.Now - start).ToString)
    End Sub
    ''' <summary>
    ''' Data herlezen en comboboxen refreshen
    ''' </summary>
    Private Sub startup()
        Dim start = DateTime.Now
        readData()
        b = New Bayes_Bayes_Linear(Me, True)
        refreshCombobox()
        'Console.WriteLine("Startup: " + (DateTime.Now - start).ToString)
    End Sub
    ''' <summary>
    ''' Data uit file lezen
    ''' Als het niet bestaat, lezen van db
    ''' </summary>
    Private Sub readData()
        Dim start = DateTime.Now
        Dim ltf As New ListToFile
        Try
            Me.Cursor = Cursors.WaitCursor
            If File.Exists(saveDirectory + "/cursussen.xml") Then
                lists = ltf.openTheList(saveDirectory + "/cursussen.xml")
                Dim fileCreatedDate As DateTime = File.GetLastWriteTime(saveDirectory + "/cursussen.xml")
                Dim nu As DateTime = Now
                Dim dagenoud = nu.Subtract(fileCreatedDate).Days
                If dagenoud > 0 Then
                    tslblStatus.Text = "Uw data is " + dagenoud.ToString + " dagen oud, click om te refreshen"
                    tslblStatus.IsLink = True
                    tslblStatus.LinkColor = Color.Black
                    tslblStatus.LinkBehavior = LinkBehavior.NeverUnderline
                Else
                    tslblStatus.Text = "Uw data is up to date!"
                End If
            Else
                b = New Bayes_Bayes_Linear(Me, False)
                lists = b.getData(filters)
                ltf.saveTheList(lists, saveDirectory + "/cursussen.xml")
                tslblStatus.Text = "Uw data is up to date!"
            End If
        Finally
            Me.Cursor = Cursors.Default
            'Console.WriteLine("Read data: " + (DateTime.Now - start).ToString)
        End Try
    End Sub
    ''' <summary>
    ''' Geeft alle items weer
    ''' </summary>
    ''' <returns>Alle data in een lijst met cursussen </returns>
    Public Function getAllItems() As List(Of Cursus)
        Return lists("allItems")
    End Function

    Public Sub setAllItems(list As List(Of Cursus))
        lists("allItems") = list
        Dim ltf As New ListToFile
        My.Computer.FileSystem.DeleteFile(saveDirectory + "/cursussen.xml")
        ltf.saveTheList(lists, saveDirectory + "/cursussen.xml")
    End Sub
    ''' <summary>
    ''' Geeft alle items weer met jaar (om trend te bepalen)
    ''' </summary>
    ''' <returns>Alle data met extra veld, jaar, in een lijst met cursussen </returns>
    Public Function getAllItemsWithYear() As List(Of Cursus)
        Return lists("withYear")
    End Function
    ''' <summary>
    ''' Standaardafwijking van de gegevens berekenen
    ''' </summary>
    ''' <returns>De standaardafwijking as double</returns>
    Public Function getDeviatie() As Double
        Return My.Settings.Deviatie
    End Function
    ''' <summary>
    ''' Stel de standaardafwijking in
    ''' </summary>
    ''' <param name="dev">Nieuwe standaardafwijking</param>
    Public Sub setDeviatie(dev As Double)
        My.Settings.Deviatie = dev
    End Sub
    ''' <summary>
    ''' Comboboxen merk, uitvoerend centrum en subafdeling refreshen
    ''' Handig om te gebruiken na het instellen van filters
    ''' </summary>
    Public Sub refreshCombobox()
        cboMerk.Items.Clear()
        cboMerk.Items.AddRange(getMerken)
        cboUitvCent.Items.Clear()
        cboUitvCent.Items.AddRange(getCentra)
        cboSubAfd.Items.Clear()
        cboSubAfd.Items.AddRange(getSubafdeling)
    End Sub
    ''' <summary>
    ''' Refresht de lijst met filters
    ''' Indien de map niet bestaat, maakt die aan en steek er de defaultlist in
    ''' </summary>
    Public Sub refreshFilterList()
        Dim start = DateTime.Now
        filterlist = New ArrayList
        cboFiltersList.Items.Clear()
        Dim filterFiles As String()
        Dim bestaatFilter As Boolean = False
        Try
            filterFiles = Directory.GetFiles(saveDirectory)
            'Als map niet leeg is
            If filterFiles.Count > 0 Then
                For Each file As String In filterFiles
                    'Enkel json bestanden
                    If System.IO.Path.GetExtension(file).ToUpper = ".JSON" Then
                        Dim filterNames As String = System.IO.Path.GetFileNameWithoutExtension(file)
                        filterlist.Add(filterNames)
                        If filterNames.Equals(My.Settings.selectedFilterList) Then
                            bestaatFilter = True
                        End If
                    End If
                Next
            Else
                'Als map leeg is steek de bijgeleverde defaultList in 
                Throw New DirectoryNotFoundException
            End If
            cboFiltersList.Items.AddRange(filterlist.ToArray)

            'Auto select last selected list als die bestaat, anders defaultlist 
            If Not bestaatFilter Then
                My.Settings.selectedFilterList = "DefaultList"
                My.Settings.Save()
            End If
            selectedFilterList = My.Settings.selectedFilterList
            cboFiltersList.SelectedItem = selectedFilterList
            startup()
        Catch ex As DirectoryNotFoundException
            'Als map niet bestaat is -> map aanmaken en bijgeleverde defaultList kopieren 
            My.Computer.FileSystem.CopyFile("..\..\Filters\defaultList.json", saveDirectory + "\DefaultList.json")
            refreshFilterList()
        Finally
            'Console.WriteLine("Refresh filterlist: " + (DateTime.Now - start).ToString)
        End Try
    End Sub
    ''' <summary>
    ''' Toont settings scherm waar je parameters kan toevoegen
    ''' </summary>
    Private Sub btnFilter_Click(sender As Object, e As EventArgs) Handles btnFilter.Click
        Dim settings As New FiltersScherm(Me)
        settings.Show()
    End Sub
    ''' <summary>
    ''' Toont test scherm
    ''' </summary>
    Private Sub btnTest_Click(sender As Object, e As EventArgs) Handles btnTest.Click
        Dim t As New Test(Me)
        t.Show()
    End Sub
    ''' <summary>
    ''' Bereken de kans voor de geselecteerde parameters
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnBerekenen.Click
        If cboMerk.SelectedItem Is Nothing Then
            MessageBox.Show("Gelieve een merk te selecteren aub")
        Else
            If cboUitvCent.SelectedItem Is Nothing Then
                MessageBox.Show("Gelieve een uitvoerend centrum te selecteren aub")
            Else
                If cboSubAfd.SelectedItem Is Nothing Then
                    MessageBox.Show("Gelieve een code subafdeling te selecteren aub")
                Else
                    Dim c As New Cursus(cboMerk.SelectedItem.ToString, cboUitvCent.SelectedItem.ToString, dtpStartcursus.Value.Month.ToString, dtpStartcursus.Value.ToString("dddd", New CultureInfo("nl-BE")),
                                                 cboSubAfd.SelectedItem.ToString, 0, 0, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)
                    txtTotaal.Text = b.getKansVoorCursus(c).ToString
                End If
            End If
        End If
    End Sub
    ''' <summary>
    ''' Voegt filters toe aan active lijst
    ''' </summary>
    ''' <param name="filters">Arraylist van filteritems die toegevoegd dienen te worden</param>
    Public Sub addFilters(filters As ArrayList)
        filters.AddRange(filters)
    End Sub
    ''' <summary>
    ''' Geeft alle filters terug die actief zijn
    ''' </summary>
    ''' <returns>Arraylist van filter-items met alle active filters </returns>
    Public Function getFilters() As ArrayList
        Return filters
    End Function
    ''' <summary>
    ''' Geeft geselecteerde filter lijst terug
    ''' </summary>
    ''' <returns>Naam van de geselcteerde lijst (dit is ook de naam van het document zonder extensie)</returns>
    Public Function getSelectedList() As String
        Return selectedFilterList
    End Function
    ''' <summary>
    ''' Selecteer een ander lijst vanuit een ander scherm
    ''' </summary>
    Public Sub setSelectedList(list As String)
        Me.Cursor = Cursors.WaitCursor
        cboFiltersList.SelectedItem = list
        Me.Cursor = Cursors.Default
    End Sub
    ''' <summary>
    ''' Geeft alle filterlijsten terug
    ''' </summary>
    ''' <returns>Arraylist met namen van lijsten</returns>
    Public Function getFilterList() As ArrayList
        Return filterlist
    End Function
    Private Sub tslblStatus_Click(sender As Object, e As EventArgs) Handles tslblStatus.Click

        My.Computer.FileSystem.DeleteFile(saveDirectory + "/cursussen.xml")
        forceRefresh()

        cboMerk.ResetText()
        cboSubAfd.ResetText()
        cboUitvCent.ResetText()

    End Sub
    Private Sub cboFiltersList_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboFiltersList.SelectedValueChanged
        If Not cboFiltersList.SelectedItem.Equals(My.Settings.selectedFilterList) Then
            If File.Exists(saveDirectory + "/cursussen.xml") Then
                'Verwijderd cursussen.xml om straks weer aan te maken
                My.Computer.FileSystem.DeleteFile(saveDirectory + "/cursussen.xml")
                forceRefresh()
            End If
        Else
            If Not File.Exists(saveDirectory + "/cursussen.xml") Then
                'Maakt cursussen.xml aan als het niet bestaat
                forceRefresh()
            End If
        End If
    End Sub
    Private Sub forceRefresh()
        Dim j As New JSONParser
        filters = j.readFilters(saveDirectory + cboFiltersList.SelectedItem.ToString() + ".json")
        'Opslaan in my.settings om later automatisch te selecteren
        My.Settings.selectedFilterList = cboFiltersList.SelectedItem
        My.Settings.Save()
        startup()
    End Sub
    ''' <summary>
    ''' Geeft de directory terug waar er standaard in opgeslaan word
    ''' </summary>
    ''' <returns>Pad in een string formaat waar alles opgeslaan wordt</returns>
    Public Function getSaveDirectory() As String
        Return saveDirectory
    End Function
    Private Sub MainScreen_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged
        'Alleen visible maken als het klaar is met laden
        Me.Visible = ready
    End Sub
    Private Sub MainScreen_BindingContextChanged(sender As Object, e As EventArgs) Handles Me.BindingContextChanged
        'Scherm verbergen bij de opstart
        Me.Visible = False
    End Sub

    Friend Function createFilterString(filters As ArrayList) As String
        Dim f As String = ""
        For Each s As FilterItem In filters
            If f.Equals("") Then
                f = s.toString
            Else
                f += " and " + s.toString
            End If
        Next
        Return f
    End Function

    Private Sub ToolStripSplitButton1_ButtonClick(sender As Object, e As EventArgs)

        My.Computer.FileSystem.DeleteFile(saveDirectory + "/cursussen.xml")
        forceRefresh()
    End Sub
    ''' <summary>
    ''' Alle gekende merken terug geven
    ''' </summary>
    ''' <returns>Gesorteerd earray met alle merken</returns>
    Public Function getMerken() As Array
        Dim merken = b.getMerken().ToArray
        Array.Sort(merken)
        Return merken
    End Function
    ''' <summary>
    ''' Alle gekende subafdelingen terug geven
    ''' </summary>
    ''' <returns>Gesorteerd earray met alle subafdelingen</returns>
    Public Function getSubafdeling() As Array
        Dim sa = b.getSubafdelingen().ToArray
        Array.Sort(sa)
        Return sa
    End Function
    ''' <summary>
    ''' Alle gekende centra terug geven
    ''' </summary>
    ''' <returns>Gesorteerd earray met alle centra</returns>
    Public Function getCentra() As Array
        Dim centra = b.getCentra().ToArray
        Array.Sort(centra)
        Return centra
    End Function

    Private Sub btnOnt_Click(sender As Object, e As EventArgs) Handles btnOnt.Click
        Dim ontScherm As New PerOnt(Me)
        ontScherm.Show()
    End Sub
End Class