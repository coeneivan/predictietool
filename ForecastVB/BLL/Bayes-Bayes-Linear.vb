Imports ForecastVB
Imports System.Collections.Immutable

Public Class Bayes_Bayes_Linear



    'TODO Hoe houden we bij welk algoritme van de 2 gekozen moet worden voor welke parameters?
    'TODO Bijde algoritmes testen voor alle te testen parameters en bijhouden welke het beste resultaat geeft?
    'TODO Uitbreiden voor andere algoritmes?

#Region "Global variables"
    Private root As MainScreen

    Private f As String = ""
    Private listOfAllItems As New List(Of Cursus)
    Private listOfAllItemsWithYear As New List(Of Cursus)
    Private listForBayes As New List(Of ImmutableCursus)
    Private listForBayesLin As New List(Of ImmutableCursus)
    Private listForBayesMerk As New List(Of ImmutableCursus)
    Private emptyCursusList As ImmutableList(Of ImmutableCursus)

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

        emptyCursusList = resetCursusList(root.getAllItems()).ToImmutableList

        berekenBayesVoorIederItem()
        calcBayesWithLinear()
        bayesWanneerMerkSterkAfwijkt()

        Dim bestList = getBestAlgoritme()

        root.setDeviatie(getdeviatie)

        root.setAllItems(bestList)
    End Sub


#Region "Algoritmes"

    Public Sub alleAfwijkingenVerwerken(list As List(Of Cursus))
        For Each item As Cursus In list
            voegToeAanAfwijkingLijst(item)
        Next

        getdeviatie = Math.Round(CalculateStandardDeviation(listMetAfwijking), 3)
        afwijkingBerekenen(list)
        isVoorspellingsLijstCorrect(list)
        listMetAfwijking = New List(Of Double)
    End Sub
    Public Sub alleAfwijkingenVerwerkenImmutable(list As List(Of ImmutableCursus))
        For Each item As ImmutableCursus In list
            voegToeAanAfwijkingLijstImmutable(item)
        Next

        getdeviatie = Math.Round(CalculateStandardDeviation(listMetAfwijking), 3)
        afwijkingBerekenenImmutable(list)
        isVoorspellingsLijstCorrectImmutable(list)
        listMetAfwijking = New List(Of Double)
    End Sub

    Private Sub bayesWanneerMerkSterkAfwijkt()
        Dim t1CursList As New List(Of Cursus)
        Dim t2CursList As New List(Of Cursus)
        Dim subAfdList As New List(Of String)
        Dim minAantalCursPerMerk As Integer = 20
        Dim minPercVerschil As Double = 0.1 ' uitgedrukt /100

        listForBayesMerk = emptyCursusList.ToList

        For Each item As ImmutableCursus In listForBayesMerk
            Dim gevonden As Boolean = False


            If Not t1CursList.Count = 0 Then
                For Each item2 As Cursus In t1CursList
                    If item.getCodeSubafdeling.Equals(item2.getCodeSubAfdeling) And item.getMerk.Equals(item2.getMerk) Then
                        item2.setTotaal(item.getTotaal + item2.getTotaal)
                        item2.SetDoorgegaan(item.getAantalDoorgegaan + item2.getDoorgegaan)
                        gevonden = True
                    End If
                Next
            End If

            If Not gevonden Or t1CursList.Count = 0 Then
                Dim curs As New Cursus(item.getMerk, Nothing, Nothing, Nothing, item.getCodeSubafdeling, item.getTotaal, item.getAantalDoorgegaan)
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

        For i As Integer = 0 To listForBayesMerk.Count - 1
            If Not listForBayesMerk(i).getIsCorrect Then
                Dim nieuweKans = berekenBayes(listOfAllItems(i))

                listForBayesMerk(i) = kansToevoegenImmutable(listForBayesMerk(i), nieuweKans, Algoritmes.BayesMerk)
            End If
        Next

        alleAfwijkingenVerwerkenImmutable(listForBayesMerk)
    End Sub

    Private Sub calcBayesWithLinear()

        listForBayesLin = emptyCursusList.ToList
        ' berekend kans van iedere entry dat deze door gaat en plaatst dit vervolgens in de listview
        For i As Integer = 0 To listForBayesLin.Count - 1
            If Not listForBayesLin(i).getIsCorrect Then

                'Bereken Bayes voor item, mocht Linear eerst worden opgeropen
                listForBayesLin(i) = listForBayesLin(i).setKans(berekenBayesImmutable(listForBayesLin(i)))

                Dim kansBayes = listForBayesLin(i).getKans

                Dim xSum As Double = 0
                Dim ySum As Double = 0
                Dim xSquareSum As Double = 1
                Dim xySum As Double = 1
                Dim aantal As Integer = 0
                Dim a As Double
                Dim b As Double

                For Each itemWithYear As Cursus In listOfAllItemsWithYear
                    If listForBayesLin(i).getCodeSubafdeling = itemWithYear.getCodeSubAfdeling And listForBayesLin(i).getMaand = itemWithYear.getMaand And
                        listForBayesLin(i).getUitvoerCentrum = itemWithYear.getUitvoerCentrum And listForBayesLin(i).getDag = itemWithYear.getDag And
                        listForBayesLin(i).getMerk = itemWithYear.getMerk Then

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

                Dim nieuweKans = (((kansBayes * 1) + (a * Now.Year + b) * 1) / (1 + 1))
                If (listForBayesLin(i).getKans > 1) Then nieuweKans = 1
                If (listForBayesLin(i).getKans < 0) Then nieuweKans = 0
                'item.setKans(kansBayes)
                listForBayesLin(i) = listForBayesLin(i).setJaar(a)
                listForBayesLin(i) = listForBayesLin(i).setB(b)

                listForBayesLin(i) = kansToevoegenImmutable(listForBayesLin(i), nieuweKans, Algoritmes.BayesLinear)
            End If
        Next

        alleAfwijkingenVerwerkenImmutable(listForBayesLin)
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
            c.setKans(berekenBayes(c))
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


    Private Function berekenBayes(item As Cursus) As Double
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
            Return (wel / (wel + niet))
        End If
        Return Nothing
    End Function

    Private Function berekenBayesImmutable(item As ImmutableCursus) As Double
        If dicMerkW.ContainsKey(item.getMerk) And dicMerkN.ContainsKey(item.getMerk) Then
            Dim j1, j2, j3, j4, j5, j6 As Double
            Dim n1, n2, n3, n4, n5, n6 As Double

            'TODO wat als er bv. een Subcategorie niet voorkomt? 

            j1 = (dicMerkW(item.getMerk) / atlDoorgg)
            j2 = (dicSubW(item.getCodeSubafdeling) / atlDoorgg)
            j3 = (dicMaandW(item.getMaand) / atlDoorgg)
            j4 = (dicDagW(item.getDag) / atlDoorgg)
            j5 = (dicUitvW(item.getUitvoerCentrum) / atlDoorgg)
            j6 = (atlDoorgg / (atlDoorgg + atlNietDgg))


            n1 = (dicMerkN(item.getMerk) / atlNietDgg)
            n2 = (dicSubN(item.getCodeSubafdeling) / atlNietDgg)
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
            Return (wel / (wel + niet))
        End If
        Return Nothing
    End Function

    Private Sub kansToevoegen(item As Cursus, nieuweKans As Double, algo As Algoritmes)

        item.setKans(nieuweKans)
        item.algoritme = algo

        voegToeAanAfwijkingLijst(item)
    End Sub
    Private Function kansToevoegenImmutable(item As ImmutableCursus, nieuweKans As Double, algo As Algoritmes) As ImmutableCursus

        item = item.setKans(nieuweKans)
        item = item.setAlgoritme(algo)

        voegToeAanAfwijkingLijstImmutable(item)
        Return item
    End Function

    Private Sub berekenBayesVoorIederItem()

        berekenAantalDoorgegaanEnNietDoorgegaan()

        listForBayes = emptyCursusList.ToList

        ' berekend kans van iedere entry dat deze door gaat en plaatst dit vervolgens in de listview
        For i As Integer = 0 To listForBayes.Count - 1
            If Not listForBayes(i).getIsCorrect Then
                Dim nieuweKans = berekenBayesImmutable(listForBayes(i))
                listForBayes(i) = kansToevoegenImmutable(listForBayes(i), nieuweKans, Algoritmes.Bayes)
            End If
        Next

        alleAfwijkingenVerwerkenImmutable(listForBayes)
    End Sub

#End Region

#Region "Diverse berekeningen, geen algoritmes"

    Private Function resetCursusList(list As List(Of Cursus)) As List(Of ImmutableCursus)
        Dim immutCurs
        Dim immutCursList As New List(Of ImmutableCursus)

        For Each item As Cursus In list
            item.afwijking = -1
            item.setKans(-1.01) ' is in procent uit gedrukt en iedere berekende waar is zo altijd groter dan dit
            item.algoritme = Algoritmes.Niets

            immutCurs = New ImmutableCursus(item.getMerk, item.getUitvoerCentrum, item.getMaand, item.getDag, item.getCodeSubAfdeling,
                                            item.getTotaal, item.getDoorgegaan, item.getKans, item.getJaar, item.setB, item.afwijking, item.algoritme, item.isCorrect)


            immutCursList.Add(immutCurs)
        Next
        Return immutCursList
    End Function

    Private Function getBestAlgoritme() As List(Of Cursus)

        Dim newList = listForBayes

        For i As Integer = 0 To newList.Count - 1
            For Each item2 As ImmutableCursus In listForBayesLin
                ' is item dezelfde en is voorspelling correct?
                If newList(i).getMerk().Equals(item2.getMerk()) Then
                    If newList(i).getCodeSubafdeling().Equals(item2.getCodeSubafdeling()) Then
                        If newList(i).getUitvoerCentrum().Equals(item2.getUitvoerCentrum()) Then
                            If newList(i).getDag().Equals(item2.getDag()) Then
                                If newList(i).getMaand = item2.getMaand Then
                                    If item2.getIsCorrect Then

                                        Dim temp1 = Math.Abs(newList(i).getKans - (newList(i).getAantalDoorgegaan / newList(i).getTotaal))
                                        Dim temp2 = Math.Abs(item2.getKans - (newList(i).getAantalDoorgegaan / newList(i).getTotaal))

                                        ' is nieuwe voorspelling naukeuriger dan oude voorspelling?
                                        If Math.Abs(newList(i).getKans - (newList(i).getAantalDoorgegaan / newList(i).getTotaal)) > Math.Abs(item2.getKans - (newList(i).getAantalDoorgegaan / newList(i).getTotaal)) Then
                                            newList(i) = item2
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            Next
            For Each item2 As ImmutableCursus In listForBayesMerk
                ' is item dezelfde en is voorspelling correct?
                If (newList(i).getMerk().Equals(item2.getMerk()) And newList(i).getCodeSubafdeling().Equals(item2.getCodeSubafdeling()) And newList(i).getUitvoerCentrum().Equals(item2.getUitvoerCentrum()) And
                newList(i).getDag().Equals(item2.getDag()) And newList(i).getMaand = item2.getMaand) And item2.getIsCorrect Then

                    ' is nieuwe voorspelling naukeuriger dan oude voorspelling?
                    If Math.Abs(newList(i).getKans - (newList(i).getAantalDoorgegaan / newList(i).getTotaal)) > Math.Abs(item2.getKans - (newList(i).getAantalDoorgegaan / newList(i).getTotaal)) Then
                        newList(i) = item2
                    End If
                End If
            Next
        Next

        Dim newListCursus As New List(Of Cursus)
        For i As Integer = 0 To newList.Count - 1
            If newList(i).getAlgoritme = Algoritmes.Niets Then
                Dim stopdat = ""
            End If
            Dim c = New Cursus(newList(i).getMerk, newList(i).getUitvoerCentrum, newList(i).getMaand, newList(i).getDag, newList(i).getCodeSubafdeling, newList(i).getTotaal, newList(i).getAantalDoorgegaan)
            c.setB = newList(i).getB
            c.isCorrect = newList(i).getIsCorrect
            c.setKans(newList(i).getKans)
            c.afwijking = newList(i).getAfwijkingswaarde
            c.algoritme = newList(i).getAlgoritme
            newListCursus.Add(c)
        Next

        Return newListCursus
    End Function

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

    Private Sub afwijkingBerekenen(list As List(Of Cursus))
        Dim tVerd As New tVerdeling
        For i As Integer = 0 To list.Count - 1
            list(i).afwijking = tVerd.getTwaarde(0.995, list(i).getTotaal) * getdeviatie / Math.Sqrt(list(i).getTotaal)
        Next
    End Sub

    Private Sub afwijkingBerekenenImmutable(list As List(Of ImmutableCursus))
        Dim tVerd As New tVerdeling
        For i As Integer = 0 To list.Count - 1
            Dim t = tVerd.getTwaarde(0.995, list(i).getTotaal) * getdeviatie / Math.Sqrt(list(i).getTotaal)
            list(i) = list(i).setAfwijkingValue(t)
        Next
    End Sub

    ''' <summary>
    ''' Checkt als voorspelde waarde overeen komt met echte waarde en bewaart dit in .isCorrect
    ''' </summary>
    Private Sub isVoorspellingsLijstCorrect(list As List(Of Cursus))
        For Each item As Cursus In list
            Dim echt = Math.Round((item.getDoorgegaan / item.getTotaal), 2) * 100
            Dim schatting = item.getKans * 100
            Dim afwijking = item.afwijking
            Dim schattingsbereik = New Bereik(afwijking, schatting)

            item.isCorrect = schattingsbereik.valtTussen(echt)
        Next
    End Sub


    ''' <summary>
    ''' Checkt als voorspelde waarde overeen komt met echte waarde en bewaart dit in .isCorrect
    ''' </summary>
    Private Sub isVoorspellingsLijstCorrectImmutable(list As List(Of ImmutableCursus))
        For i As Integer = 0 To list.Count - 1
            Dim echt = Math.Round((list(i).getAantalDoorgegaan / list(i).getTotaal), 2) * 100
            Dim schatting = list(i).getKans * 100
            Dim afwijking = list(i).getAfwijkingswaarde
            Dim schattingsbereik = New Bereik(afwijking, schatting)

            list(i) = list(i).setIsCorrect(schattingsbereik.valtTussen(echt))
        Next
    End Sub

    Private Sub voegToeAanAfwijkingLijst(item As Cursus)
        listMetAfwijking.Add(Math.Round((((item.getDoorgegaan / item.getTotaal) - (item.getKans)) * 100), 2))
    End Sub

    Private Sub voegToeAanAfwijkingLijstImmutable(item As ImmutableCursus)
        listMetAfwijking.Add(Math.Round((((item.getAantalDoorgegaan / item.getTotaal) - (item.getKans)) * 100), 2))
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
