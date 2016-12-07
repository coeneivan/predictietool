Imports CursusPredictie
Imports System.Collections.Immutable

Public Class CursusKansBerekening

#Region "Global variables"
    Private f As String = ""
    Private listOfAllItems As New List(Of Cursus)
    Private listOfAllItemsWithYear As New List(Of Cursus)

    Private listForBayes As New List(Of Cursus)
    Private listForBayesLin As New List(Of Cursus)
    Private listForBayesMerk As New List(Of Cursus)
    Private emptyCursusList As ImmutableList(Of Cursus)

    ' Lijst om te tellen hoeveel cursussen van elk item niet geschrapt werden
    Private dicMerkW As New Dictionary(Of String, Integer)
    Private dicUitvW As New Dictionary(Of String, Integer)
    Private dicMaandW As New Dictionary(Of String, Integer)
    Private dicDagW As New Dictionary(Of String, Integer)
    Private dicSubW As New Dictionary(Of String, Integer)
    Private dicOntwW = New Dictionary(Of String, Integer)

    ' Lijst om te tellen hoeveel cursussen van elk item wel geschrapt werden
    Private dicMerkN As New Dictionary(Of String, Integer)
    Private dicUitvN As New Dictionary(Of String, Integer)
    Private dicMaandN As New Dictionary(Of String, Integer)
    Private dicDagN As New Dictionary(Of String, Integer)
    Private dicSubN As New Dictionary(Of String, Integer)
    Private dicOntwN = New Dictionary(Of String, Integer)

    Private atlDoorgg As Integer
    Private atlNietDgg As Integer
    Private listMetAfwijking As New List(Of Double)
    Private getdeviatie As Double
    Private alleAlgoritmesGebruiken As Boolean = False
    Private afwijkingsIndex As Integer

#End Region
    ''' <summary>
    ''' Aanmaken van object
    ''' Heeft een lijst van alle cursussen nodig. Wanneer een cursus per subafdeling moet worden voorspeld moet het cursus object een Merk, uitvoercentrum, maand, dag, subafdeling,
    ''' totaal aantal cursussen en aantal doorgegane cursussen hebben. Wanneer er per ontwikkelaar moet worden berekend moet deze worden toegevoegd en de dag weggelaten
    ''' </summary>
    ''' <param name="cursusList">Lijst van alle cursussen met de eigenschappen zoals ze hierboven zijn beschreven</param>
    Public Sub New(cursusList As List(Of Cursus))
        listOfAllItems = cursusList
        listOfAllItemsWithYear = cursusList
        berekenAantalDoorgegaanEnNietDoorgegaan()
    End Sub
    Public Function BerekenKans()
        emptyCursusList = resetCursusList(listOfAllItems).ToImmutableList

        If alleAlgoritmesGebruiken Then
            bayesWanneerMerkSterkAfwijkt()
            calcBayesWithLinear()
        End If
        berekenBayesVoorIederItem()

        listOfAllItems = getBestAlgoritme()
        Return listOfAllItems
    End Function

    Public Sub reset()
        ' Lijst om te tellen hoeveel cursussen van elk item niet geschrapt werden
        dicMerkW = New Dictionary(Of String, Integer)
        dicUitvW = New Dictionary(Of String, Integer)
        dicMaandW = New Dictionary(Of String, Integer)
        dicDagW = New Dictionary(Of String, Integer)
        dicSubW = New Dictionary(Of String, Integer)
        dicOntwW = New Dictionary(Of String, Integer)

        ' Lijst om te tellen hoeveel cursussen van elk item wel geschrapt werden
        dicMerkN = New Dictionary(Of String, Integer)
        dicUitvN = New Dictionary(Of String, Integer)
        dicMaandN = New Dictionary(Of String, Integer)
        dicDagN = New Dictionary(Of String, Integer)
        dicSubN = New Dictionary(Of String, Integer)
        dicOntwN = New Dictionary(Of String, Integer)

        atlDoorgg = 0
        atlNietDgg = 0
    End Sub

    Public Function BerekenVoorCursus(cursus As Cursus) As Cursus
        berekenAantalDoorgegaanEnNietDoorgegaan()
        cursus = cursus.setKans(berekenBayes(cursus))
        Return cursus
    End Function

#Region "Algoritmes"

    Private Sub alleAfwijkingenVerwerken(list As List(Of Cursus))
        For Each item As Cursus In list
            voegToeAanAfwijkingLijst(item)
        Next

        getdeviatie = Math.Round(CalculateStandardDeviation(listMetAfwijking), 3)
        afwijkingBerekenen(list)
        isVoorspellingsLijstCorrect(list)

        listMetAfwijking = New List(Of Double)
        reset()

        Console.WriteLine("Standaardafwijking: " + getdeviatie.ToString)
    End Sub

    Private Sub bayesWanneerMerkSterkAfwijkt()
        Dim t1CursList As New List(Of Cursus)
        Dim t2CursList As New List(Of Cursus)
        Dim minAantalCursPerMerk As Integer = 20
        Dim minPercVerschil As Double = 0.1 ' uitgedrukt /100

        listForBayesMerk = emptyCursusList.ToList

        For j As Integer = 0 To listForBayesMerk.Count - 1
            Dim gevonden As Boolean = False


            If Not t1CursList.Count = 0 Then
                For i As Integer = 0 To t1CursList.Count - 1
                    If listForBayesMerk(j).getCodeSubafdeling.Equals(t1CursList(i).getCodeSubafdeling) And listForBayesMerk(j).getMerk.Equals(t1CursList(i).getMerk) Then
                        t1CursList(i) = t1CursList(i).setTotaal(listForBayesMerk(j).getTotaal + t1CursList(i).getTotaal)
                        t1CursList(i) = t1CursList(i).setDoorgegaan(listForBayesMerk(j).getAantalDoorgegaan + t1CursList(i).getAantalDoorgegaan)
                        gevonden = True
                    End If
                Next
            End If

            If Not gevonden Or t1CursList.Count = 0 Then
                Dim curs As New Cursus(listForBayesMerk(j).getMerk, listForBayesMerk(j).getUitvoerCentrum, Nothing, listForBayesMerk(j).getDag, listForBayesMerk(j).getCodeSubafdeling,
                                       listForBayesMerk(j).getTotaal, listForBayesMerk(j).getAantalDoorgegaan, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)
                t1CursList.Add(curs)
            End If
        Next


        For i As Integer = 0 To t1CursList.Count - 1
            If (t1CursList(i).getTotaal >= minAantalCursPerMerk) Then
                For j As Integer = 0 To t1CursList.Count - 1

                    If Not t1CursList(i).Equals(t1CursList(j)) And t1CursList(i).getCodeSubafdeling().Equals(t1CursList(j).getCodeSubafdeling()) And
                        Math.Abs(t1CursList(i).getAantalDoorgegaan() / t1CursList(i).getTotaal - t1CursList(j).getAantalDoorgegaan / t1CursList(j).getTotaal) >= minPercVerschil And
                        t1CursList(j).getTotaal >= minAantalCursPerMerk Then
                        t2CursList.Add(t1CursList(j))
                    End If
                Next
            End If
        Next

        For i As Integer = 0 To emptyCursusList.Count - 1
            For j As Integer = 0 To t2CursList.Count - 1
                If Not emptyCursusList(i).getIsCorrect And Not t2CursList(j).getIsCorrect Then
                    If emptyCursusList(i).getMerk.Equals(t2CursList(j).getMerk()) And emptyCursusList(i).getCodeSubafdeling().Equals(t2CursList(j).getCodeSubafdeling()) Then
                        baycalculation(emptyCursusList(i), True)
                    Else
                        baycalculation(emptyCursusList(i), False)
                    End If
                End If
            Next
        Next

        For i As Integer = 0 To listForBayesMerk.Count - 1
            'If Not listForBayesMerk(i).getIsCorrect Then
            Dim nieuweKans = berekenBayes(listForBayesMerk(i))

            listForBayesMerk(i) = kansToevoegen(listForBayesMerk(i), nieuweKans, Algoritmes.BayesMerk)
            'End If
        Next

        alleAfwijkingenVerwerken(listForBayesMerk)
    End Sub

    Private Sub calcBayesWithLinear()

        listForBayesLin = emptyCursusList.ToList

        berekenAantalDoorgegaanEnNietDoorgegaan()

        ' berekend kans van iedere entry dat deze door gaat en plaatst dit vervolgens in de listview
        For i As Integer = 0 To listForBayesLin.Count - 1
            If Not listForBayesLin(i).getIsCorrect Then

                'Bereken Bayes voor item, mocht Linear eerst worden opgeropen
                listForBayesLin(i) = listForBayesLin(i).setKans(berekenBayes(listForBayesLin(i)))

                Dim kansBayes = listForBayesLin(i).getKans

                Dim xSum As Double = 0
                Dim ySum As Double = 0
                Dim xSquareSum As Double = 1
                Dim xySum As Double = 1
                Dim aantal As Integer = 0
                Dim a As Double
                Dim b As Double

                For Each itemWithYear As Cursus In listOfAllItemsWithYear
                    If listForBayesLin(i).getCodeSubafdeling = itemWithYear.getCodeSubafdeling And listForBayesLin(i).getMaand = itemWithYear.getMaand And
                        listForBayesLin(i).getUitvoerCentrum = itemWithYear.getUitvoerCentrum And listForBayesLin(i).getDag = itemWithYear.getDag And
                        listForBayesLin(i).getMerk = itemWithYear.getMerk Then

                        Dim x = itemWithYear.getJaar
                        Dim y = (itemWithYear.getAantalDoorgegaan / itemWithYear.getTotaal)

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

                If Double.IsNaN(nieuweKans) Then
                    Stop
                End If

                If (nieuweKans > 1) Then nieuweKans = 1
                If (nieuweKans < 0) Then nieuweKans = 0

                listForBayesLin(i) = listForBayesLin(i).setJaar(a)
                listForBayesLin(i) = listForBayesLin(i).setB(b)

                listForBayesLin(i) = kansToevoegen(listForBayesLin(i), nieuweKans, Algoritmes.BayesLinear)
            End If
        Next

        alleAfwijkingenVerwerken(listForBayesLin)
    End Sub

    Private Function getKansVoorCursus(ByRef c As Cursus, afwijkingsIndex As Integer) As Cursus
        Dim found = False
        For Each cu In listOfAllItems
            If cu.getMerk.Equals(c.getMerk) And cu.getUitvoerCentrum.Equals(c.getUitvoerCentrum) And cu.getMaand.Equals(c.getMaand) And cu.getCodeSubafdeling.Equals(c.getCodeSubafdeling) And
                cu.getDag.Equals(c.getDag) Then
                c = c.setKans(cu.getKans)
                Dim afijwijkingsindex As Double
                Try
                    afijwijkingsindex = afwijkingsIndex
                Catch ex As Exception
                    afijwijkingsindex = 0.995
                End Try
                c = c.setAfwijkingValue(cu.getAfwijkingswaarde(afijwijkingsindex), afijwijkingsindex)
                c = c.setTotaal(cu.getTotaal)
                found = True
                GoTo stopAndReturn
            End If
        Next
        If Not found Then
            c = c.setKans(berekenBayes(c))

            Dim t As New tVerdeling
            For i As Integer = 0 To t.getBetrouwbaarheidsIntervallen.Count - 1
                c = c.setAfwijkingValue(100, i)
            Next
        End If
stopAndReturn:
        Return c
    End Function

    Private Sub baycalculation(item As Cursus, merkRekenen As Boolean)
        Dim merk = item.getMerk()
        Dim uitvCentr = item.getUitvoerCentrum
        Dim maand = item.getMaand
        Dim dag = item.getDag
        Dim codeSubAfd = item.getCodeSubafdeling
        Dim nietDoor = item.getTotaal - item.getAantalDoorgegaan
        Dim doorgegaan = item.getAantalDoorgegaan
        Dim ontwikkelaar = item.getOntw

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

        If Not ontwikkelaar Is Nothing Then
            ' Lijst per ontwikkelaar aanvullen
            If Not dicOntwW.ContainsKey(ontwikkelaar) Then
                dicOntwW.Add(ontwikkelaar, doorgegaan)
            Else
                dicOntwW(ontwikkelaar) += doorgegaan
            End If

            If Not dicOntwN.ContainsKey(ontwikkelaar) Then
                dicOntwN.Add(ontwikkelaar, nietDoor)
            Else
                dicOntwN(ontwikkelaar) += nietDoor
            End If
        End If



        ' Som van aantal doorgegane cursussen
        atlDoorgg += doorgegaan
        ' Som van aantal Geschrapte cursussen
        atlNietDgg += nietDoor
    End Sub


    Private Function berekenBayes(item As Cursus) As Double
        If dicMerkW.ContainsKey(item.getMerk) And dicMerkN.ContainsKey(item.getMerk) And dicSubW.ContainsKey(item.getCodeSubafdeling) And dicSubN.ContainsKey(item.getCodeSubafdeling) And
            dicUitvW.ContainsKey(item.getUitvoerCentrum) And dicUitvN.ContainsKey(item.getUitvoerCentrum) And dicDagW.ContainsKey(item.getDag) And dicDagN.ContainsKey(item.getDag) And
            dicMaandW.ContainsKey(item.getMaand) And dicMaandN.ContainsKey(item.getMaand) Then
            Dim j1, j2, j3, j4, j5, j6, j7 As Double
            Dim n1, n2, n3, n4, n5, n6, n7 As Double

            If Not item.getOntw Is Nothing Then
                j7 = dicOntwW(item.getOntw) / atlDoorgg
                n7 = dicOntwN(item.getOntw) / atlNietDgg
            Else
                j7 = 1
                n7 = 1
            End If

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

            wel = j1 * j2 * j3 * j4 * j5 * j6 * j7
            niet = n1 * n2 * n3 * n4 * n5 * n6 * n7

            'Als geen enkel item geschrapt wordt, is 'niet' NaN
            If Double.IsNaN(niet) Then
                niet = 0
            End If

            'Als geen enkel item doorgaat, is 'wel' NaN
            If Double.IsNaN(wel) Then
                wel = 0
            End If

            ' Anders wordt gedeeld door 0 en een exception gethrowed
            If niet = 0 And wel = 0 Then niet = 1

            Return (wel / (wel + niet))
        End If
        Return Nothing
    End Function

    Private Function kansToevoegen(item As Cursus, nieuweKans As Double, algo As Algoritmes) As Cursus

        item = item.setKans(nieuweKans)
        item = item.setAlgoritme(algo)

        Return item
    End Function

    Private Sub berekenBayesVoorIederItem()

        berekenAantalDoorgegaanEnNietDoorgegaan()

        listForBayes = emptyCursusList.ToList

        ' berekend kans van iedere entry dat deze door gaat en plaatst dit vervolgens in de listview
        For i As Integer = 0 To listForBayes.Count - 1
            If Not listForBayes(i).getIsCorrect Then
                Dim nieuweKans = berekenBayes(listForBayes(i))
                listForBayes(i) = kansToevoegen(listForBayes(i), nieuweKans, Algoritmes.Bayes)
            End If
        Next

        alleAfwijkingenVerwerken(listForBayes)
    End Sub

#End Region

#Region "Diverse berekeningen, geen algoritmes"

    Private Function resetCursusList(list As List(Of Cursus)) As List(Of Cursus)
        Dim immutCurs
        Dim immutCursList As New List(Of Cursus)

        For Each item As Cursus In list
            immutCurs = New Cursus(item.getMerk, item.getUitvoerCentrum, item.getMaand, item.getDag, item.getCodeSubafdeling, item.getTotaal, item.getAantalDoorgegaan, -1.01, item.getJaar,
                                   item.getB, Nothing, Algoritmes.Niets, False, item.getOntw)
            immutCursList.Add(immutCurs)
        Next

        Return immutCursList
    End Function

    Private Function getBestAlgoritme() As List(Of Cursus)

        Dim newList = listForBayes

        If alleAlgoritmesGebruiken Then
            For i As Integer = 0 To newList.Count - 1
                For Each item2 As Cursus In listForBayesLin
                    ' is item dezelfde en is voorspelling correct?
                    If newList(i).getMerk().Equals(item2.getMerk()) And newList(i).getCodeSubafdeling().Equals(item2.getCodeSubafdeling()) And
                        newList(i).getUitvoerCentrum().Equals(item2.getUitvoerCentrum()) And newList(i).getDag().Equals(item2.getDag()) And newList(i).getMaand = item2.getMaand And item2.getIsCorrect Then

                        ' is nieuwe voorspelling naukeuriger dan oude voorspelling?
                        If newList(i).getAfwijkingswaarde(afwijkingsIndex) > item2.getAfwijkingswaarde(afwijkingsIndex) Or Not newList(i).getIsCorrect Then
                            newList(i) = item2
                        End If
                    End If
                Next

                For Each item2 As Cursus In listForBayesMerk
                    ' is item dezelfde en is voorspelling correct?
                    If (newList(i).getMerk().Equals(item2.getMerk()) And newList(i).getCodeSubafdeling().Equals(item2.getCodeSubafdeling()) And
                        newList(i).getUitvoerCentrum().Equals(item2.getUitvoerCentrum()) And newList(i).getDag().Equals(item2.getDag()) And newList(i).getMaand = item2.getMaand) And item2.getIsCorrect Then

                        ' is nieuwe voorspelling naukeuriger dan oude voorspelling?
                        If newList(i).getAfwijkingswaarde(afwijkingsIndex) > item2.getAfwijkingswaarde(afwijkingsIndex) Or Not newList(i).getIsCorrect Then
                            newList(i) = item2
                        End If
                    End If
                Next
            Next
        End If

        Return newList
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

    Private Sub afwijkingBerekenen(list As List(Of Cursus))
        For i As Integer = 0 To list.Count - 1
            afwijkingCursusBerekenen(list(i))
        Next
    End Sub

    Private Sub afwijkingCursusBerekenen(cursus As Cursus)
        Dim tVerd As New tVerdeling
        For j As Integer = 0 To cursus.getAantalAfwijkingen - 1
            Dim t = tVerd.getTwaarde(cursus.getTverdelingsWaarde(j), cursus.getTotaal) * getdeviatie / Math.Sqrt(cursus.getTotaal)
            cursus = cursus.setAfwijkingValue(t, j)
        Next
    End Sub

    ''' <summary>
    ''' Checkt als voorspelde waarde overeen komt met echte waarde en bewaart dit in .isCorrect
    ''' </summary>
    Private Sub isVoorspellingsLijstCorrect(list As List(Of Cursus))
        Dim afijwijkingsindex As Double
        Try
            afijwijkingsindex = afwijkingsIndex
        Catch ex As Exception
            afijwijkingsindex = 0.995
        End Try
        For i As Integer = 0 To list.Count - 1
            Dim echt = Math.Round((list(i).getAantalDoorgegaan / list(i).getTotaal), 2) * 100
            Dim schatting = list(i).getKans * 100
            Dim afwijking = list(i).getAfwijkingswaarde(afijwijkingsindex)
            Dim schattingsbereik = New Bereik(afwijking, schatting)

            list(i) = list(i).setIsCorrect(schattingsbereik.valtTussen(echt))
        Next
    End Sub

    Private Sub voegToeAanAfwijkingLijst(item As Cursus)
        listMetAfwijking.Add(Math.Round((((item.getAantalDoorgegaan / item.getTotaal) - (item.getKans)) * 100), 2))
    End Sub
#End Region

#Region "Getters/Setters"
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
            If Not subafdelingenDictionay.ContainsKey(cursus.getCodeSubafdeling.ToUpper) Then
                subafdelingenDictionay.Add(cursus.getCodeSubafdeling.ToUpper, cursus)
            End If
        Next
        Dim list As New List(Of String)
        For Each k In subafdelingenDictionay
            list.Add(k.Key)
        Next
        Return list
    End Function
#End Region

#Region "Public functions voor test klasses"
#If DEBUG Then

    Public Function TestGetSubafdelingen(curs As List(Of Cursus))
        listOfAllItems = curs
        Return getSubafdelingen()
    End Function

    Public Function TestGetUitvoercentrum(curs As List(Of Cursus))
        listOfAllItems = curs
        Return getCentra()
    End Function

    Public Sub setListOfAllItems(curs As List(Of Cursus))
        listOfAllItems = curs
    End Sub

    Public Function TestIsVoorspellingsLijstCorrect(curs As List(Of Cursus))
        isVoorspellingsLijstCorrect(curs)
        Return curs
    End Function

    Public Function TestAfwijkingBerekenen(curs As List(Of Cursus))
        afwijkingBerekenen(curs)
        Return curs
    End Function

    Public Function TestCalculateStandardDeviation(data As List(Of Double))
        Return CalculateStandardDeviation(data)
    End Function

    Public Function TestResetCursusList(list As List(Of Cursus)) As List(Of Cursus)
        Return resetCursusList(list)
    End Function

    Public Function TestBerekenBayesVoorIederItem(list As List(Of Cursus)) As List(Of Cursus)
        emptyCursusList = resetCursusList(list).ToImmutableList
        setListOfAllItems(list)
        berekenAantalDoorgegaanEnNietDoorgegaan()
        berekenBayesVoorIederItem()
        Return listForBayes
    End Function
#End If
#End Region



End Class
