Imports System.Globalization
Imports System.IO
Imports System.Drawing.Drawing2D
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
    Private tverdelingsPerc As Double = 0.995


    Private ang As Double = 50
    Private Sub MainScreen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim start As DateTime = DateTime.Now
        s = New SplashScreen1()
        s.Show()
        Me.Visible = False
        refreshFilterList()
        s.Close()
        ready = True
        cbbValtTussen.SelectedIndex = 0
        setTVerdeling(cbbValtTussen.SelectedItem)
        Me.Visible = True

        Dim j As New JSONParser
        filters = j.readFilters(saveDirectory + cboFiltersList.SelectedItem.ToString() + ".json")
    End Sub

    ''' <summary>
    ''' Data herlezen en comboboxen refreshen
    ''' </summary>
    Private Sub startup()
        Dim start = DateTime.Now
        readData()
        b = New Bayes_Bayes_Linear(Me, True)
        refreshCombobox()
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
                    If dagenoud = 1 Then
                        tslblStatus.Text = "U heeft gisteren uw data gerefresht, click om opnieuw te refreshen"
                    Else
                        tslblStatus.Text = "Uw data is " + dagenoud.ToString + " dagen oud, click om te refreshen"
                    End If

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
                    ang = b.getKansVoorCursus(c).getAvg
                    Panel1.Refresh()
                    Timer1.Start()
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
        resetData()

    End Sub

    Private Sub resetData()
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
    Private Sub MainScreen_VisibleChanged(sender As Object, e As EventArgs) Handles MyBase.VisibleChanged
        'Alleen visible maken als het klaar is met laden
        Me.Visible = ready
    End Sub
    Private Sub MainScreen_BindingContextChanged(sender As Object, e As EventArgs) Handles MyBase.BindingContextChanged
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
    ''' <returns>Gesorteerde array met alle merken</returns>
    Public Function getMerken() As Array
        Dim merken = b.getMerken().ToArray
        Array.Sort(merken)
        Return merken
    End Function
    ''' <summary>
    ''' Alle gekende subafdelingen terug geven
    ''' </summary>
    ''' <returns>Gesorteerde array met alle subafdelingen</returns>
    Public Function getSubafdeling() As Array
        Dim sa = b.getSubafdelingen().ToArray
        Array.Sort(sa)
        Return sa
    End Function
    ''' <summary>
    ''' Alle gekende centra terug geven
    ''' </summary>
    ''' <returns>Gesorteerde array met alle centra</returns>
    Public Function getCentra() As Array
        Dim centra = b.getCentra().ToArray
        Array.Sort(centra)
        Return centra
    End Function

    Private Sub btnOnt_Click(sender As Object, e As EventArgs) Handles btnOnt.Click
        Dim ontScherm As New PerOnt(Me)
        ontScherm.Show()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim sql As New SQLUtil
        Dim DTcursus = sql.getAlles("SELECT *, month(startdatum) as maand FROM Cursussen WHERE [Opleidingsnr] = '" + txtOpleidingsnummer.Text.Trim + "'")
        If DTcursus.Rows.Count <> 0 Then
            Dim cursus As Cursus
            Dim startdatum As Date
            For Each row As DataRow In DTcursus.Rows
                startdatum = row.Item("startdatum")
                cursus = New Cursus(row.Item("Merk"), row.Item("UitvCentrumOmsch"), row.Item("maand"), row.Item("dag"), row.Item("codeSubafdeling"), 1, 1, 1, 1, 1, 1, Nothing, False, "")
            Next
            cboMerk.SelectedItem = cursus.getMerk
            cboUitvCent.SelectedItem = cursus.getUitvoerCentrum
            cboSubAfd.SelectedItem = cursus.getCodeSubafdeling
            dtpStartcursus.Value = startdatum
        Else
            MessageBox.Show("Opleidingsnummer werd niet teruggevonden")
        End If
    End Sub

    Const min As Integer = 100
    Const max As Integer = 260
    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
        Const min As Integer = 100
        Const max As Integer = 260

        Dim W As Integer = My.Resources.DashArrow.Width / 4
        Dim H As Integer = My.Resources.DashArrow.Height / 4
        Dim gr As Graphics = e.Graphics
        Dim m As Matrix = New Matrix
        m.RotateAt((ang * ((max - min) / 100)) + min, New Point(140, 150))
        m.Scale(0.25, 0.25)
        gr.Transform = m
        gr.DrawImage(My.Resources.DashArrow, New Point(220, 370))
    End Sub
    Dim down As Boolean
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        'Dim a = ((ang - 1) * ((max - min) / 100)) + min
        If Not down Then
            Dim a = ((ang - 1) * ((max - min) / 100)) + min
            If a <= max And a >= min Then
                ang -= 1
            Else
                down = True
            End If
        Else
            Dim a = ((ang + 1) * ((max - min) / 100)) + min
            If a <= max And a >= min Then
                ang += 1
            Else
                down = False
            End If
        End If

        Panel1.Refresh()
    End Sub
    Private Ba As Point
    Private F As Point
    Private DistanceFromBF As Integer = 1
    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint
        Dim height = 100
        Ba = New Point(DistanceFromBF, height)
        F = New Point(Panel2.Width - DistanceFromBF, height)

        If Ba.Y = F.Y Then
            Dim C As New Point(Ba.X + (F.X - Ba.X) / 2, Ba.Y - DistanceFromBF)
            Dim ctr As Point
            Dim rad As Double
            CircleFromPointsOnCircumference(Ba, C, F, ctr, rad)

            Dim rc As New Rectangle(ctr, New Size(Panel2.Width - DistanceFromBF, Panel2.Height - DistanceFromBF))
            rc.Inflate(rad, rad)
            e.Graphics.DrawRectangle(Pens.Black, rc)
            Dim dif As Integer = 10
            Dim Width = Panel2.Width - 10
            Console.WriteLine(Width.ToString)
            Dim myRec As New Rectangle(New Point(dif, dif), New Size(Width, 140))
            e.Graphics.DrawRectangle(Pens.Black, myRec)
            'Dim clip As New Rectangle(New Point(Ba.X, Ba.Y - DistanceFromBF), New Size(F.X - Ba.X, DistanceFromBF))
            'e.Graphics.SetClip(clip)
            e.Graphics.DrawEllipse(Pens.Green, rc)

            e.Graphics.ResetClip()
            DrawPoint(Ba, e.Graphics, Color.Red)
            DrawPoint(C, e.Graphics, Color.Red)
            DrawPoint(F, e.Graphics, Color.Red)
        End If
    End Sub
    Private Sub DrawPoint(ByVal pt As Point, ByVal G As Graphics, ByVal clr As Color)
        Dim rc As New Rectangle(pt, New Size(1, 1))
        rc.Inflate(3, 3)
        Using brsh As New SolidBrush(clr)
            G.FillEllipse(brsh, rc)
        End Using
        Console.WriteLine("PUNT: " + pt.X.ToString + " " + pt.Y.ToString)
    End Sub

    Private Sub CircleFromPointsOnCircumference(ByVal ptA As Point, ByVal ptB As Point, ByVal ptC As Point, ByRef Center As Point, ByRef Radius As Double)
        Dim mR As Double = CDbl(ptA.Y - ptB.Y) / CDbl(ptA.X - ptB.X)
        Dim mT As Double = CDbl(ptC.Y - ptB.Y) / CDbl(ptC.X - ptB.X)
        Dim X As Double = (mR * mT * (ptC.Y - ptA.Y) + mR * (ptB.X + ptC.X) - mT * (ptA.X + ptB.X)) / CDbl(2) * (mR - mT)
        Dim Y As Double = CDbl(-1) / mR * (X - CDbl(ptA.X + ptB.X) / CDbl(2)) + (CDbl(ptA.Y + ptB.Y) / CDbl(2))
        Center = New Point(X, Y)
        Radius = Math.Sqrt(Math.Pow(ptA.X - Center.X, 2) + Math.Pow(ptA.Y - Center.Y, 2))
    End Sub
    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        Panel2.Refresh()
    End Sub

    Friend Sub setTVerdeling(waarde As String)
        If waarde = "99.5%" Then
            tverdelingsPerc = 0.995
        ElseIf waarde = "99%" Then
            tverdelingsPerc = 0.99
        ElseIf waarde = "97.5%" Then
            tverdelingsPerc = 0.975
        ElseIf waarde = "95%" Then
            tverdelingsPerc = 0.95
        ElseIf waarde = "90%" Then
            tverdelingsPerc = 0.9
        Else
            Throw New ArgumentOutOfRangeException("Gegeven percentage niet beschikbaar.")
        End If
        resetData()
    End Sub

    Public Function getTVerdelingPercentage() As Double
        Return tverdelingsPerc
    End Function

    Private Sub cbbValtTussen_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbbValtTussen.SelectionChangeCommitted
        setTVerdeling(cbbValtTussen.SelectedItem)
    End Sub

    Private Sub txtOpleidingsnummer_KeyPress(sender As Object, e As KeyPressEventArgs)

    End Sub
End Class