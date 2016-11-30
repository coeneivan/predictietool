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
    Private ang As New Bereik(0, 50, 100)
    Private zwart, accent, accent2, wit, rood, geel, groen As Color
    Private afwijkinsIndex As Double = 0.995
    Private newAng As New Bereik(0, 50, 100)
    Private Sub MainScreen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        style()
#If DEBUG Then
        ' For testing purposes
        setRandomOplNr()
#Else
        btnTest.Hide()
        btnOnt.Width = 284
#End If


        Dim start As DateTime = DateTime.Now
        s = New SplashScreen1()
        s.Show()
        Me.Visible = False
        refreshFilterList()
        s.Close()
        ready = True

        ' Dropdown voor afwijking initialiseren
        Dim curs As New Cursus("", "", Nothing, "", "", Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Algoritmes.Niets, Nothing, "")
        For i As Integer = 0 To curs.getAantalAfwijkingen - 1
            cbbValtTussen.Items.Insert(i, curs.getAfwijkingsString(i))
        Next
        cbbValtTussen.SelectedIndex = curs.getAantalAfwijkingen - 1
        setTVerdeling(curs.getAantalAfwijkingen - 1)

        refreshPanel()
        Me.Visible = True

        Dim j As New JSONParser
        filters = j.readFilters(saveDirectory + cboFiltersList.SelectedItem.ToString() + ".json")
    End Sub

    Private Sub setRandomOplNr()
        Randomize()
        mtbOplNummer.Text = CInt(Math.Floor((188000 - 75000 + 1) * Rnd())) + 75000
    End Sub

    Private Sub style()
        zwart = Color.FromArgb(52, 73, 94)
        wit = Color.FromArgb(236, 240, 241)
        accent = Color.FromArgb(52, 152, 219)
        accent2 = Color.FromArgb(41, 128, 185)
        rood = Color.FromArgb(231, 76, 60)
        geel = Color.FromArgb(230, 126, 34)
        groen = Color.FromArgb(39, 174, 96)

        Me.BackColor = wit
        Me.ForeColor = zwart
        For Each ctrl As Control In Me.Controls
            'THE BUTTONS
            If TypeOf ctrl Is Button Then
                Dim btn As Button = ctrl
                btn.BackColor = accent
                btn.ForeColor = wit
                btn.Font = New System.Drawing.Font("Roboto Bold", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                btn.Text = btn.Text.ToUpper

                btn.FlatStyle = FlatStyle.Flat
                btn.FlatAppearance.BorderColor = accent2

                btn.FlatAppearance.BorderSize = 1
            End If

            'THE COMBOBOXES
            If TypeOf ctrl Is ComboBox Then
                Dim cbb As ComboBox = ctrl
                cbb.BackColor = accent
                cbb.ForeColor = wit
                cbb.FlatStyle = FlatStyle.Flat
                cbb.Font = New System.Drawing.Font("Roboto Bold", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                cbb.Text = cbb.Text.ToUpper

            End If

            'THE LABELS
            If TypeOf ctrl Is Label Then
                Dim lbl As Label = ctrl
                'lbl.Text = lbl.Text.ToUpper
                lbl.Font = New System.Drawing.Font("Roboto Bold", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                If Not (ctrl.Name = "lblMinMax" Or ctrl.Name = "lblRealisatie") Then
                    lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
                End If
                lbl.FlatStyle = FlatStyle.Flat
            End If

            'THE DATETIMEPICKER
            If TypeOf ctrl Is DateTimePicker Then
                Dim dtp As DateTimePicker = ctrl
                dtp.BackColor = accent
                dtp.CalendarForeColor = wit
                dtp.CalendarMonthBackground = Color.Red
            End If
        Next
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
                    setTVerdeling(cbbValtTussen.SelectedIndex)

                    Dim c As New Cursus(cboMerk.SelectedItem.ToString, cboUitvCent.SelectedItem.ToString, dtpStartcursus.Value.Month.ToString, dtpStartcursus.Value.ToString("dddd", New CultureInfo("nl-BE")),
                                                 cboSubAfd.SelectedItem.ToString, 0, 0, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)
                    c = b.getKansVoorCursus(c)
                    txtTotaal.Text = c.getBereik(afwijkinsIndex).ToString

                    If c.getTotaal > 0 Then
                        If c.getTotaal = 1 Then
                            lblRealisatie.Text = "Realisatiegraad bepaald met 1 enkele cursus:"
                        Else
                            lblRealisatie.Text = "Realisatiegraad bepaald met " + c.getTotaal.ToString + " cursussen:"
                        End If
                    Else
                        lblRealisatie.Text = "Realisatiegraad met nieuwe situatie"
                    End If

                    newAng = c.getBereik(afwijkinsIndex)
                        pnlAvg.Refresh()
                        pnlBack.Refresh()
                        tmrAvg.Start()
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
        Dim cursus As Cursus
        Dim startDatum As New Date

        Try
            If mtbOplNummer.Text = Nothing Then Throw New ApplicationException("Gelieve een opleidsingsnummer in te geven")
            TestBLL.GetCursusByOpleidingsnummer(mtbOplNummer.Text.Trim, cursus, startDatum)
            cboMerk.SelectedItem = cursus.getMerk
            cboUitvCent.SelectedItem = cursus.getUitvoerCentrum
            cboSubAfd.SelectedItem = cursus.getCodeSubafdeling
            dtpStartcursus.Value = startDatum

        Catch ex As ApplicationException
            MessageBox.Show(ex.Message)
        Finally
#If DEBUG Then
            setRandomOplNr()
            Button2_Click(Nothing, Nothing)
#End If
        End Try
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles pnlAvg.Paint
        Const min As Integer = 100
        Const max As Integer = 260

        'AVG
        Dim gr As Graphics = e.Graphics
        Dim m As Matrix = New Matrix

        m.RotateAt((Math.Round(ang.getAvg) * ((max - min) / 100)) + min, New Point(140, 150))
        m.Scale(0.25, 0.25)

        gr.Transform = m
        'gr.SmoothingMode = SmoothingMode.AntiAlias
        gr.DrawImage(My.Resources.DashArrow, New Point(220, 370))
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles tmrAvg.Tick
        Dim stap = 1
        If Math.Round(newAng.getAvg) > ang.getAvg Then
            ang.setAvg(ang.getAvg + stap)
        ElseIf Math.Round(newAng.getAvg) < ang.getAvg Then
            ang.setAvg(ang.getAvg - stap)
        ElseIf Math.Round(newAng.getAvg) = ang.getAvg Then
            tmrAvg.Stop()
        End If

        refreshPanel()
    End Sub

    Private Sub refreshPanel()
        pnlAvg.Refresh()

        Dim bmp = New Bitmap(pnlBack.Width, pnlBack.Height)
        pnlBack.DrawToBitmap(bmp, pnlBack.ClientRectangle)
        pcbPijl.Image = bmp
        pcbPijl.Refresh()
    End Sub
    ''' <summary>
    ''' Tekenen van achtergrond
    ''' </summary>
    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles pnlBack.Paint

        pnlBack.BackColor = wit

        Dim dif As Integer = 10 'AFSTAND VAN ZIJKANT
        Dim Ypunt = pnlBack.Height - dif * 3 'ONDERSTE PUNT VAN TEKENING
        Dim strokeWidth = 10 'BREEDTE VAN HALFCIRCLE
        Dim gr = e.Graphics
        gr.SmoothingMode = SmoothingMode.AntiAlias
        Dim myRec As New Rectangle(New Point(dif, dif), New Size(pnlBack.Width - dif * 2, Ypunt * 2)) ' hoogte was Panel2.Height - dif * 2
        Dim myRec2 As New Rectangle(New Point(dif + strokeWidth, dif + strokeWidth), New Size((myRec.Size.Width) - strokeWidth * 2, (myRec.Size.Height) - strokeWidth * 2))
        Dim myClip As New Rectangle(New Point(dif, dif), New Size(myRec.Size.Width, myRec.Size.Height / 2))
        'BG
        Dim bg As New Rectangle(New Point(0, 0), New Size(pnlBack.Width, pnlBack.Height - dif))
        gr.FillRectangle(New SolidBrush(accent), bg)

        gr.SetClip(bg)

        gr.SetClip(myClip)
        'Eerste stuk (ROOD)
        Dim myClip2 As New Rectangle(New Point(dif + myClip.Size.Width * 1 / 6, dif), New Size(myClip.Size))
        gr.FillEllipse(New SolidBrush(rood), myRec)
        gr.SetClip(myClip2)

        'Tweede stuk (GEEL)
        Dim myClip3 As New Rectangle(New Point(dif + myClip2.Size.Width * 5 / 6, dif), New Size(myClip.Size))
        gr.FillEllipse(New SolidBrush(geel), myRec)
        gr.SetClip(myClip3)

        'Tweede stuk (GROEN)
        Dim myClip4 As New Rectangle(New Point(dif + myClip3.Size.Width * 6 / 6, dif), New Size(myClip.Size))
        gr.FillEllipse(New SolidBrush(groen), myRec)
        gr.SetClip(myClip4)

        'e.Graphics.FillRectangle(New SolidBrush(Color.Green), myRec)
        'e.Graphics.FillRectangle(New SolidBrush(Color.Blue), myClip)

        gr.ResetClip()
        gr.SetClip(bg)
        gr.FillEllipse(New SolidBrush(accent), myRec2)

    End Sub

    Public Sub setTVerdeling(index As String)
        afwijkinsIndex = index
    End Sub

    Public Function getAfwijkinsindex() As Double
        Return afwijkinsIndex
    End Function

    Private Sub cbbValtTussen_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbbValtTussen.SelectionChangeCommitted
        setTVerdeling(cbbValtTussen.SelectedIndex)
    End Sub
End Class