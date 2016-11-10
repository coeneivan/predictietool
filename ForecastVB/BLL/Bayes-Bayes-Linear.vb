Imports ForecastVB

Public Class Bayes_Bayes_Linear


    'TODO Hoe houden we bij welk algoritme van de 2 gekozen moet worden voor welke parameters?
    'TODO Bijde algoritmes testen voor alle te testen parameters en bijhouden welke het beste resultaat geeft?
    'TODO Uitbreiden voor andere algoritmes?

#Region "Global variables"
    Private root As MainScreen

    Private f As String = ""
    Private listOfAllItems As New List(Of Cursus)
    Private listOfAllItemsWithYear As New List(Of Cursus)
    Private startTime = Now

    ' Lijst om te tellen hoeveel cursussen van elk item niet geschrapt werden
    Private dicMerkW As New Dictionary(Of String, Integer)
    Private dicUitvW As New Dictionary(Of String, Integer)
    Private dicMaandW As New Dictionary(Of String, Integer)
    Private dicDagW As New Dictionary(Of String, Integer)
    Private dicSubW As New Dictionary(Of String, Integer)

    ' Lijst om te tellen hoeveel cursussen van elk item wel geschrapt werden
    Private dicMerkN As New Dictionary(Of String, Integer)
    Private dicUitvN As New Dictionary(Of String, Integer)
    Private dicMaandN As New Dictionary(Of String, Integer)
    Private dicDagN As New Dictionary(Of String, Integer)
    Private dicSubN As New Dictionary(Of String, Integer)

    Private atlDoorgg As Integer
    Private atlNietDgg As Integer
    Private listMetAfwijking As New List(Of Double)

    Private cIn As Integer = 0
    Private cOut As Integer = 0
    Private ligtTussen As Integer = 10
    Private getdeviatie As Double

#End Region
    Public Sub New(main As MainScreen)
        root = main
        Try
            listOfAllItems = root.getAllItems
            listOfAllItemsWithYear = root.getAllItemsWithYear
            berekenAantalDoorgegaanEnNietDoorgegaan()
            BerekenKans()
        Catch ex As Exception
            'TODO: Als bestand nog niets bestaat, geeft dit een exception
        End Try
    End Sub
    Public Sub BerekenKans()


        berekenBayesVoorIederItem()

        calcBayesWithLinear()

        bayesWanneerMerkSterkAfwijkt()

        root.setDeviatie(getdeviatie)
    End Sub


#Region "Algoritmes"

    Public Sub alleAfwijkingenVerwerken()
        getdeviatie = Math.Round(CalculateStandardDeviation(listMetAfwijking), 3)
        afwijkingBerekenen()
        isVoorspellingsLijstCorrect()
        listMetAfwijking = New List(Of Double)
    End Sub

    Private Sub bayesWanneerMerkSterkAfwijkt()
        Dim t1CursList As New List(Of Cursus)
        Dim t2CursList As New List(Of Cursus)
        Dim subAfdList As New List(Of String)
        Dim minAantalCursPerMerk As Integer = 20
        Dim minPercVerschil As Double = 0.1 ' uitgedrukt /100

        For Each item As Cursus In listOfAllItems
            Dim gevonden As Boolean = False


            If Not t1CursList.Count = 0 Then
                For Each item2 As Cursus In t1CursList
                    If item.getCodeSubAfdeling.Equals(item2.getCodeSubAfdeling) And item.getMerk.Equals(item2.getMerk) Then
                        item2.setTotaal(item.getTotaal + item2.getTotaal)
                        item2.SetDoorgegaan(item.getDoorgegaan + item2.getDoorgegaan)
                        gevonden = True
                    End If
                Next
            End If

            If Not gevonden Or t1CursList.Count = 0 Then
                Dim curs As New Cursus(item.getMerk, Nothing, Nothing, Nothing, item.getCodeSubAfdeling, item.getTotaal, item.getDoorgegaan)
                t1CursList.Add(curs)
            End If
        Next


        For Each item As Cursus In t1CursList
            If (item.getTotaal >= minAantalCursPerMerk) Then
                For Each item2 As Cursus In t1CursList
                    If Not item.Equals(item2) And item2.getTotaal >= minAantalCursPerMerk And item.getCodeSubAfdeling().Equals(item2.getCodeSubAfdeling()) And
                        Math.Abs(item.getDoorgegaan() / item.getTotaal - item2.getDoorgegaan / item2.getTotaal) >= minPercVerschil Then
                        t2CursList.Add(item2)
                    End If
                Next
            End If
        Next

        For Each item1 As Cursus In listOfAllItems
            For Each item2 As Cursus In t2CursList
                If Not item1.isCorrect And Not item2.isCorrect Then
                    If (item1.getMerk.Equals(item2.getMerk()) And item1.getCodeSubAfdeling().Equals(item2.getCodeSubAfdeling())) Then
                        baycalculation(item1, True)
                    Else
                        baycalculation(item1, False)
                    End If
                End If
            Next
        Next

        For Each item As Cursus In listOfAllItems
            If Not item.isCorrect Then
                berekenBayes(item)
                item.algoritme = Algoritmes.BayesMerk
                voegToeAanAfwijkingLijst(item)
            End If
        Next

        alleAfwijkingenVerwerken()
    End Sub

    Private Sub calcBayesWithLinear()

        ' berekend kans van iedere entry dat deze door gaat en plaatst dit vervolgens in de listview
        For Each item As Cursus In listOfAllItems
            If Not item.isCorrect Then

                'Bereken Bayes voor item, mocht Linear eerst worden opgeropen
                berekenBayes(item)

                Dim kansBayes = item.getKans

                Dim xSum As Double = 0
                Dim ySum As Double = 0
                Dim xSquareSum As Double = 1
                Dim xySum As Double = 1
                Dim aantal As Integer = 0
                Dim a As Double
                Dim b As Double

                For Each itemWithYear As Cursus In listOfAllItemsWithYear
                    If item.getCodeSubAfdeling = itemWithYear.getCodeSubAfdeling And item.getMaand = itemWithYear.getMaand And item.getUitvoerCentrum = itemWithYear.getUitvoerCentrum And
                        item.getDag = itemWithYear.getDag And item.getMerk = itemWithYear.getMerk Then

                        Dim x = itemWithYear.getJaar
                        Dim y = (itemWithYear.getDoorgegaan / itemWithYear.getTotaal)

                        aantal += 1
                        xySum += (x * y)
                        xSum += x
                        ySum += y
                        xSquareSum += x ^ 2
                    End If
                Next

                a = (((aantal * xySum) - (xSum * ySum)) / ((aantal * xSquareSum) - xSum ^ 2))
                b = (((xSquareSum * ySum) - (xSum * xySum)) / ((aantal * xSquareSum) - (xSum ^ 2)))

                item.setKans(((kansBayes * 1) + (a * Now.Year + b) * 1) / (1 + 1))
                If (item.getKans > 1) Then item.setKans(1)
                If (item.getKans < 0) Then item.setKans(0)
                'item.setKans(kansBayes)
                item.setJaar(a)
                item.setB = b

                item.algoritme = Algoritmes.BayesLinear

                voegToeAanAfwijkingLijst(item)
            End If
        Next

        alleAfwijkingenVerwerken()
    End Sub

    Friend Function getKansVoorCursus(c As Cursus) As Bereik
        Dim found = False
        For Each cu In listOfAllItems
            If cu.getMerk.Equals(c.getMerk) And cu.getUitvoerCentrum.Equals(c.getUitvoerCentrum) And cu.getMaand.Equals(c.getMaand) And cu.getCodeSubAfdeling.Equals(c.getCodeSubAfdeling) And cu.getDag.Equals(c.getDag) Then
                c.setKans(cu.getKans)
                c.afwijking = cu.afwijking
                found = True
                GoTo stopAndReturn
            End If
        Next
        If Not found Then
            berekenBayes(c)
        End If
stopAndReturn:
        Return c.getBereik
    End Function

    Private Sub baycalculation(item As Cursus, merkRekenen As Boolean)
        Dim merk = item.getMerk()
        Dim uitvCentr = item.getUitvoerCentrum
        Dim maand = item.getMaand
        Dim dag = item.getDag
        Dim codeSubAfd = item.getCodeSubAfdeling
        Dim nietDoor = item.getTotaal - item.getDoorgegaan
        Dim doorgegaan = item.getDoorgegaan

        If merkRekenen Then
            ' Lijst per merk aanvullen
            If Not dicMerkW.ContainsKey(merk) Then
                dicMerkW.Add(merk, doorgegaan)

            Else
                dicMerkW(merk) += doorgegaan
            End If

            If Not dicMerkN.ContainsKey(merk) Then
                dicMerkN.Add(merk, nietDoor)
            Else
                dicMerkN(merk) += nietDoor
            End If
        End If

        ' Lijst per uitvoercentrum aanvullen
        If Not dicUitvW.ContainsKey(uitvCentr) Then
            dicUitvW.Add(uitvCentr, doorgegaan)
        Else
            dicUitvW(uitvCentr) += doorgegaan
        End If

        If Not dicUitvN.ContainsKey(uitvCentr) Then
            dicUitvN.Add(uitvCentr, nietDoor)
        Else
            dicUitvN(uitvCentr) += nietDoor
        End If


        ' Lijst per maand aanvullen
        If Not dicMaandW.ContainsKey(maand) Then
            dicMaandW.Add(maand, doorgegaan)
        Else
            dicMaandW(maand) += doorgegaan
        End If

        If Not dicMaandN.ContainsKey(maand) Then
            dicMaandN.Add(maand, nietDoor)
        Else
            dicMaandN(maand) += nietDoor
        End If


        ' Lijst per Dag aanvullen
        If Not dicDagW.ContainsKey(dag) Then
            dicDagW.Add(dag, doorgegaan)
        Else
            dicDagW(dag) += doorgegaan
        End If

        If Not dicDagN.ContainsKey(dag) Then
            dicDagN.Add(dag, nietDoor)
        Else
            dicDagN(dag) += nietDoor
        End If


        ' Lijst per subafdeling aanvullen
        If Not dicSubW.ContainsKey(codeSubAfd) Then
            dicSubW.Add(codeSubAfd, doorgegaan)
        Else
            dicSubW(codeSubAfd) += doorgegaan
        End If

        If Not dicSubN.ContainsKey(codeSubAfd) Then
            dicSubN.Add(codeSubAfd, nietDoor)
        Else
            dicSubN(codeSubAfd) += nietDoor
        End If


        ' Som van aantal doorgegane cursussen
        atlDoorgg += doorgegaan
        ' Som van aantal Geschrapte cursussen
        atlNietDgg += nietDoor
    End Sub


    Private Sub berekenBayes(item As Cursus)
        If dicMerkW.ContainsKey(item.getMerk) And dicMerkN.ContainsKey(item.getMerk) Then
            Dim j1, j2, j3, j4, j5, j6 As Double
            Dim n1, n2, n3, n4, n5, n6 As Double

            'TODO wat als er bv. een Subcategorie niet voorkomt? 

            j1 = (dicMerkW(item.getMerk) / atlDoorgg)
            j2 = (dicSubW(item.getCodeSubAfdeling) / atlDoorgg)
            j3 = (dicMaandW(item.getMaand) / atlDoorgg)
            j4 = (dicDagW(item.getDag) / atlDoorgg)
            j5 = (dicUitvW(item.getUitvoerCentrum) / atlDoorgg)
            j6 = (atlDoorgg / (atlDoorgg + atlNietDgg))


            n1 = (dicMerkN(item.getMerk) / atlNietDgg)
            n2 = (dicSubN(item.getCodeSubAfdeling) / atlNietDgg)
            n3 = (dicMaandN(item.getMaand) / atlNietDgg)
            n4 = (dicDagN(item.getDag) / atlNietDgg)
            n5 = (dicUitvN(item.getUitvoerCentrum) / atlNietDgg)
            n6 = (atlNietDgg / (atlDoorgg + atlNietDgg))

            Dim wel As Double = 0
            Dim niet As Double = 0
            If (item.getTotaal <= 12) Then
                wel = j2 * j3 * j4 * j5 * j6
                niet = n2 * n3 * n4 * n5 * n6
            ElseIf item.getTotaal <= 15 Then
                wel = j1 * j2 * j3 * j5 * j6
                niet = n1 * n2 * n3 * n5 * n6
            Else
                wel = j1 * j2 * j3 * j4 * j5 * j6
                niet = n1 * n2 * n3 * n4 * n5 * n6
            End If
            Dim totaal = wel + niet
            item.setKans(wel / (wel + niet))
        End If
    End Sub
    Private Sub berekenBayesVoorIederItem()

        berekenAantalDoorgegaanEnNietDoorgegaan()

        ' berekend kans van iedere entry dat deze door gaat en plaatst dit vervolgens in de listview
        For Each item As Cursus In listOfAllItems
            If Not item.isCorrect Then
                berekenBayes(item)

                item.algoritme = Algoritmes.Bayes

                voegToeAanAfwijkingLijst(item)
            End If
        Next
        alleAfwijkingenVerwerken()
    End Sub

#End Region

#Region "Diverse berekeningen, geen algoritmes"

    Private Function CalculateStandardDeviation(data As List(Of Double)) As Double
        Dim mean As Double = data.Average()
        Dim squares As New List(Of Double)
        Dim squareAvg As Double

        For Each value As Double In data
            squares.Add(Math.Pow(value - mean, 2))
        Next

        squareAvg = squares.Average()

        Return Math.Sqrt(squareAvg)
    End Function
    Private Sub berekenAantalDoorgegaanEnNietDoorgegaan()
        For Each item As Cursus In listOfAllItems
            baycalculation(item, True)
        Next
    End Sub

    ''' <summary>
    ''' Checkt als voorspelde waarde overeen komt met echte waarde en bewaart dit in .isCorrect
    ''' </summary>
    Private Sub isVoorspellingsCorrect(item As Cursus)
        Dim echt = Math.Round((item.getDoorgegaan / item.getTotaal), 2) * 100
        Dim schatting = item.getKans * 100
        Dim afwijking = item.afwijking
        Dim schattingsbereik = New Bereik(afwijking, schatting)

        item.isCorrect = schattingsbereik.valtTussen(echt)
    End Sub

    Private Sub afwijkingBerekenen()
        Dim tVerd As New tVerdeling
        For Each item As Cursus In listOfAllItems
            item.afwijking = tVerd.getTwaarde(0.995, item.getTotaal) * getdeviatie / Math.Sqrt(item.getTotaal)
        Next
    End Sub

    ''' <summary>
    ''' Checkt als voorspelde waarde overeen komt met echte waarde en bewaart dit in .isCorrect
    ''' </summary>
    Private Sub isVoorspellingsLijstCorrect()
        For Each item As Cursus In listOfAllItems
            Dim echt = Math.Round((item.getDoorgegaan / item.getTotaal), 2) * 100
            Dim schatting = item.getKans * 100
            Dim afwijking = item.afwijking
            Dim schattingsbereik = New Bereik(afwijking, schatting)

            item.isCorrect = schattingsbereik.valtTussen(echt)
        Next
    End Sub

    Private Sub voegToeAanAfwijkingLijst(item As Cursus)
        listMetAfwijking.Add(Math.Round((((item.getDoorgegaan / item.getTotaal) - (item.getKans)) * 100), 2))
    End Sub
#End Region

#Region "Getters/Setters"
    ''' <summary>
    ''' Hallt data van de database en geeft dictionary weer met lists van cursussen
    ''' </summary>
    ''' <param name="filterlist">Toe te passen parameters in een arraylist</param>
    ''' <returns>Dictinary met 2 waardes allItems en withYear (Spreekt voro zich zeker?)</returns>
    Public Function getData(filterlist As ArrayList) As Dictionary(Of String, List(Of Cursus))
        Dim lists As New Dictionary(Of String, List(Of Cursus))
        f = createFilterString(filterlist)
        listOfAllItems = TestBLL.GetAllCursForAllVar(f)
        listOfAllItemsWithYear = TestBLL.GetAllCursForAllVarWithYear(f)
        lists.Add("allItems", listOfAllItems)
        lists.Add("withYear", listOfAllItemsWithYear)
        BerekenKans()
        Return lists
    End Function
    ''' <summary>
    ''' Berekend de waarde voor het te berekenen jaar wanneer lastYear het laatste jaar is met waarde
    ''' </summary>
    ''' <param name="filters">Geef een ArrayList mee met de filters</param>
    ''' <returns>Geeft de voorspelde waarde terug volgens een niet linaire functie verkregen door de gegeven data</returns>
    Private Function createFilterString(filters As ArrayList) As String
        Return root.createFilterString(filters)
    End Function


    Public Property deviatie() As Double
        Get
            Return getdeviatie
        End Get
        Set(ByVal dev As Double)
            getdeviatie = dev
        End Set
    End Property

    ''' <summary>
    ''' Geeft alle items terug 
    ''' </summary>
    ''' <returns>Geeft een list terug met alle items</returns>
    Public Function getItems() As List(Of Cursus)
        Return listOfAllItems
    End Function
    ''' <summary>
    ''' Geeft alle merken terug
    ''' </summary>
    ''' <returns>List met alle mekern</returns>
    Public Function getMerken() As List(Of String)
        Dim merkenDictionay As New Dictionary(Of String, Cursus)
        For Each cursus In listOfAllItems
            If Not merkenDictionay.ContainsKey(cursus.getMerk) Then
                merkenDictionay.Add(cursus.getMerk, cursus)
            End If
        Next
        Dim list As New List(Of String)
        For Each k In merkenDictionay
            list.Add(k.Key)
        Next
        Return list
    End Function
    ''' <summary>
    ''' Geeft alle centra terug
    ''' </summary>
    ''' <returns>List met alle centra</returns>
    Public Function getCentra() As List(Of String)
        Dim centraDictionay As New Dictionary(Of String, Cursus)
        For Each cursus In listOfAllItems
            If Not centraDictionay.ContainsKey(cursus.getUitvoerCentrum) Then
                centraDictionay.Add(cursus.getUitvoerCentrum, cursus)
            End If
        Next
        Dim list As New List(Of String)
        For Each k In centraDictionay
            list.Add(k.Key)
        Next
        Return list
    End Function
    ''' <summary>
    ''' Geeft alle subafdelingen terug
    ''' </summary>
    ''' <returns>List met alle subafdelingen</returns>
    Public Function getSubafdelingen() As List(Of String)
        Dim subafdelingenDictionay As New Dictionary(Of String, Cursus)
        For Each cursus In listOfAllItems
            If Not subafdelingenDictionay.ContainsKey(cursus.getCodeSubAfdeling.ToUpper) Then
                subafdelingenDictionay.Add(cursus.getCodeSubAfdeling.ToUpper, cursus)
            End If
        Next
        Dim list As New List(Of String)
        For Each k In subafdelingenDictionay
            list.Add(k.Key)
        Next
        Return list
    End Function
#End Region
End Class
