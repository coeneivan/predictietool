Imports System.Windows.Forms.DataVisualization.Charting

Public Class Test
    Private root As MainScreen
    Dim a As Double = 1
    Dim b As Double = 1
    Dim c As Double = 1
    Dim som As Double = 0
    Dim alleMerken, alleDagen, alleMaanden, alleCentra As ArrayList
    Dim nodata As Double

    Public Sub New(main As MainScreen)
        ' This call is required by the designer.
        InitializeComponent()
        root = main
        ' Add any initialization after the InitializeComponent() call.


    End Sub

    Private Sub Test_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: misschien beter om filters toe te passen (bv. Merk/centrum/...) om enkel daar de data van te tonen

    End Sub



    ''' <summary>
    ''' Berekend de waarde voor het te berekenen jaar wanneer lastYear het laatste jaar is met waarde
    ''' </summary>
    ''' <param name="findForX">het te brekenen jaar</param>
    ''' <param name="y_data">De Y waardes met het aantal cursussen dat is kunnen door gaan</param>
    ''' <param name="x_data">De X waardes voor het jaar waarin de cursussen zijn doorgegeaan</param>
    ''' <returns>Geeft de voorspelde waarde terug volgens een niet linaire functie verkregen door de gegeven data</returns>
    Private Function createFilterString(filters As ArrayList) As String
        Dim f As String = ""
        For Each s As FilterItem In filters
            If f.Equals("") Then
                f = s.kolom + " " + s.factor + " " + s.filter
            Else
                f += " and " + s.kolom + " " + s.factor + " " + s.filter
            End If
        Next
        Return f
    End Function

    Private Sub drawBarGraph(ver As Series)

        chartBerekend.Titles.Clear()
        chartBerekend.Series.Clear()

        chartBerekend.Series.Add(ver)
        Dim Title1 As New Title
        Dim Title2 As New Title
        Title1.BackImageAlignment = System.Windows.Forms.DataVisualization.Charting.ChartImageAlignmentStyle.Left
        Title1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Left
        Title1.Name = "Aantal"
        Title1.Text = "Aantal"
        Title2.Alignment = System.Drawing.ContentAlignment.BottomCenter
        Title2.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom
        Title2.Name = "Verschil"
        Title2.Text = "Verschil"
        Me.chartBerekend.Titles.Add(Title1)
        Me.chartBerekend.Titles.Add(Title2)
        Me.Width = 1460
        chartBerekend.ChartAreas(0).AxisX.Interval = 20
        chartBerekend.ChartAreas(0).AxisY.Interval = 10
        chartBerekend.ChartAreas(0).AxisX.Minimum = -100
        chartBerekend.ChartAreas(0).AxisX.Maximum = 100
    End Sub

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

    Private Sub dgvResult_SortCompare(sender As Object, e As DataGridViewSortCompareEventArgs) Handles dgvResult.SortCompare
        If e.Column.Index = 8 Then
            Try
                e.SortResult = If(CInt(e.CellValue1) < CInt(e.CellValue2), -1, 1)
                e.Handled = True
            Catch
                Throw New Exception()
                'TODO catch!
            End Try
        End If
    End Sub

    'TODO: implement cellclick!
    'Private Sub dgvResult_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvResult.CellClick
    '    '    If (e.ColumnIndex == dataGridViewSoftware.Columns["uninstall_button"].Index)
    '    If e.ColumnIndex = 0 And grouped IsNot Nothing Then
    '        Dim theKey = dgvResult(e.ColumnIndex, e.RowIndex).Value.ToString
    '        Dim groep = grouped(theKey)
    '        Dim toDraw = New SortedDictionary(Of Double, Parameter)
    '        For Each item In groep
    '            toDraw.Add(CDbl(item.Key), item.Value)
    '        Next
    '        Dim ver3 As New Series
    '        Dim verB As New Series
    '        Dim verO As New Series
    '        Dim verR As New Series
    '        verB.Color = Color.Black
    '        verO.Color = Color.Black
    '        verR.Color = Color.Red
    '        For Each s As KeyValuePair(Of Double, Parameter) In toDraw
    '            verR.Points.AddXY(CDbl(s.Key), s.Value.berekenPercentage)
    '            If (s.Key = (2015 - 1)) Then
    '                verB.Points.AddXY(s.Key, s.Value.berekenPercentage)
    '                verO.Points.AddXY(s.Key, s.Value.berekenPercentage)
    '                verR.Points.AddXY(s.Key, s.Value.berekenPercentage)
    '                ver3.Points.AddXY(s.Key, s.Value.berekenPercentage)
    '            End If
    '        Next
    '        Dim lin As New Linear
    '        'ver3.Points.AddXY(2015, lin.berekenVoor(2015, toDraw))
    '        ver3.Points.AddXY(2015, voorspellingen(theKey).getAvg / 100)
    '        ver3.Points.AddXY(2016, lin.berekenVoor(2016, toDraw))
    '        ver3.Points.AddXY(2017, lin.berekenVoor(2017, toDraw))
    '        ver3.Points.AddXY(2018, lin.berekenVoor(2018, toDraw))
    '        ver3.Points.AddXY(2019, lin.berekenVoor(2019, toDraw))
    '        verB.Points.AddXY(2015, voorspellingen(theKey).getBovengrens / 100)
    '        verO.Points.AddXY(2015, voorspellingen(theKey).getOndergrens / 100)
    '        'ECHTE WAARDES
    '        Dim ec3 As Double = 0
    '        Dim et3 As Double = 0
    '        'For Each c As KeyValuePair(Of String, List(Of Cursus)) In echteWaardes
    '        For Each cc In echteWaardes(theKey)
    '            'If cc.merkVanCursus = ftd3 Then
    '            et3 += 1
    '            If Not cc.codeIngetrokken Then
    '                ec3 += 1
    '            End If
    '            'End If
    '        Next
    '        'Next
    '        verR.Points.AddXY(2015, (ec3 / et3))
    '        ver3.ChartType = SeriesChartType.FastLine
    '        verB.ChartType = SeriesChartType.FastLine
    '        verO.ChartType = SeriesChartType.FastLine
    '        verR.ChartType = SeriesChartType.FastLine
    '        chartBerekend.Titles.Clear()
    '        chartBerekend.Series.Clear()

    '        chartBerekend.Series.Add(ver3)
    '        chartBerekend.Series.Add(verB)
    '        chartBerekend.Series.Add(verO)
    '        chartBerekend.Series.Add(verR)
    '        Dim Title1 As New Title
    '        Dim Title2 As New Title
    '        Title1.BackImageAlignment = System.Windows.Forms.DataVisualization.Charting.ChartImageAlignmentStyle.Left
    '        Title1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Left
    '        Title1.Name = "Aantal"
    '        Title1.Text = "Aantal"
    '        Title2.Alignment = System.Drawing.ContentAlignment.BottomCenter
    '        Title2.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom
    '        Title2.Name = "Verschil"
    '        Title2.Text = "Verschil"
    '        Me.chartBerekend.Titles.Add(Title1)
    '        Me.chartBerekend.Titles.Add(Title2)
    '        Me.Width = 1460
    '        chartBerekend.ChartAreas(0).AxisY.Maximum = 1
    '        chartBerekend.ChartAreas(0).AxisY.Interval = 0.05
    '    End If
    '    '{
    '    '    //Do Something with your button.
    '    '}
    'End Sub

    Private Sub addColumns(list As ArrayList)
        For Each item In list
            Me.dgvResult.Columns.Add(item.ToString, item.ToString)
        Next
    End Sub

    Private Sub bgwDataLoader_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgwDataLoader.DoWork

    End Sub

    Private Sub bayesAndBayesLinear()
        Dim trues = 0
        Dim falses = 0
        Dim f As String
        Dim listOfAllItems As New List(Of DataMiningPrediction2)
        Dim listOfAllItemsWithYear As New List(Of DataMiningPrediction2)
        Dim startTime = Now
        Dim versch As New Dictionary(Of Double, Integer)

        ' Lijst om te tellen hoeveel cursussen van elk item niet geschrapt werden
        Dim dicMerkW As New Dictionary(Of String, Int32)
        Dim dicUitvW As New Dictionary(Of String, Int32)
        Dim dicMaandW As New Dictionary(Of Int16, Int32)
        Dim dicDagW As New Dictionary(Of String, Int32)
        Dim dicSubW As New Dictionary(Of String, Int32)

        ' Lijst om te tellen hoeveel cursussen van elk item wel geschrapt werden
        Dim dicMerkN As New Dictionary(Of String, Int32)
        Dim dicUitvN As New Dictionary(Of String, Int32)
        Dim dicMaandN As New Dictionary(Of Int16, Int32)
        Dim dicDagN As New Dictionary(Of String, Int32)
        Dim dicSubN As New Dictionary(Of String, Int32)

        Dim atlDoorgg As Int32
        Dim atlNietDgg As Int32
        Dim standaardAfwijking As New List(Of Double)

        Dim cIn As Integer = 0
        Dim cOut As Integer = 0
        Dim ligtTussen As Integer = 10

        ' Kolom naam aanmaken
        initDataGridView()


        f = createFilterString(root.getFilters())

        listOfAllItems = TestBLL.GetAllCursForAllVar(f)
        listOfAllItemsWithYear = TestBLL.GetAllCursForAllVarWithYear(f)

        pgb.Value = 0
        pgb.Minimum = 0
        pgb.Maximum = (listOfAllItems.Count) * 2

        ' Steek het aantal doorgegaan en aantal niet doorgegaan van ieder item in een dictionary
        For Each item As DataMiningPrediction2 In listOfAllItems
            Dim merk = item.getMerk()
            Dim uitvCentr = item.getUitvoerCentrum
            Dim maand = item.getMaand
            Dim dag = item.getDag
            Dim codeSubAfd = item.getCodeSubAfdeling
            Dim nietDoor = item.getTotaal - item.getDoorgegaan
            Dim doorgegaan = item.getDoorgegaan
            ' Lijst per merk aanvullen
            If Not dicMerkW.ContainsKey(merk) Then
                dicMerkW.Add(merk, doorgegaan)

                ' Som van aantal doorgegane cursussen
                atlDoorgg += doorgegaan
            Else
                dicMerkW(merk) += doorgegaan

                ' Som van aantal doorgegane cursussen
                atlDoorgg += doorgegaan
            End If

            ' Lijst per merk aanvullen
            If Not dicMerkN.ContainsKey(merk) Then
                dicMerkN.Add(merk, nietDoor)

                ' Som van aantal Geschrapte cursussen
                atlNietDgg += nietDoor
            Else
                dicMerkN(merk) += nietDoor

                ' Som van aantal Geschrapte cursussen
                atlNietDgg += nietDoor
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

            pgb.Value += 1
        Next

        ' berekend kans van iedere entry dat deze door gaat en plaatst dit vervolgens in de listview
        For Each item As DataMiningPrediction2 In listOfAllItems
            Dim j1, j2, j3, j4, j5, j6 As Double
            Dim n1, n2, n3, n4, n5, n6 As Double

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
                wel = ((dicSubW(item.getCodeSubAfdeling) / atlDoorgg) * (dicMaandW(item.getMaand) / atlDoorgg) * (dicDagW(item.getDag) / atlDoorgg) * (dicUitvW(item.getUitvoerCentrum) / atlDoorgg) * (atlDoorgg / (atlDoorgg + atlNietDgg)))
                niet = ((dicSubN(item.getCodeSubAfdeling) / atlNietDgg) * (dicMaandN(item.getMaand) / atlNietDgg) * (dicDagN(item.getDag) / atlNietDgg) * (dicUitvN(item.getUitvoerCentrum) / atlNietDgg) * (atlNietDgg / (atlDoorgg + atlNietDgg)))
            ElseIf item.getTotaal <= 15 Then
                wel = ((dicMerkW(item.getMerk) / atlDoorgg) * (dicSubW(item.getCodeSubAfdeling) / atlDoorgg) * (dicMaandW(item.getMaand) / atlDoorgg) * (dicUitvW(item.getUitvoerCentrum) / atlDoorgg) * (atlDoorgg / (atlDoorgg + atlNietDgg)))
                niet = ((dicMerkN(item.getMerk) / atlNietDgg) * (dicSubN(item.getCodeSubAfdeling) / atlNietDgg) * (dicMaandN(item.getMaand) / atlNietDgg) * (dicUitvN(item.getUitvoerCentrum) / atlNietDgg) * (atlNietDgg / (atlDoorgg + atlNietDgg)))
            Else
                wel = ((dicMerkW(item.getMerk) / atlDoorgg) * (dicSubW(item.getCodeSubAfdeling) / atlDoorgg) * (dicMaandW(item.getMaand) / atlDoorgg) * (dicDagW(item.getDag) / atlDoorgg) * (dicUitvW(item.getUitvoerCentrum) / atlDoorgg) * (atlDoorgg / (atlDoorgg + atlNietDgg)))
                niet = ((dicMerkN(item.getMerk) / atlNietDgg) * (dicSubN(item.getCodeSubAfdeling) / atlNietDgg) * (dicMaandN(item.getMaand) / atlNietDgg) * (dicDagN(item.getDag) / atlNietDgg) * (dicUitvN(item.getUitvoerCentrum) / atlNietDgg) * (atlNietDgg / (atlDoorgg + atlNietDgg)))

            End If
            Dim totaal = wel + niet
            item.setKans(wel / (wel + niet))


            ' Verschil
            Dim verschil = Math.Round((((item.getDoorgegaan / item.getTotaal) - (item.getKans)) * 100), 2)

            standaardAfwijking.Add(Math.Round((((item.getDoorgegaan / item.getTotaal) - (item.getKans)) * 100), 2))

            verschil = (Math.Round(item.getDoorgegaan / item.getTotaal * 100) - Math.Round(item.getKans * 100))
            If Not versch.ContainsKey(verschil) Then
                versch.Add(verschil, 1)
            Else
                versch(verschil) += 1
            End If

            If verschil > ligtTussen Or verschil < -ligtTussen Then
                cOut += 1
            Else
                cIn += 1
            End If

            pgb.Value += 1
        Next



        ' Standaard afwijking berekenen
        Dim deviatie = Math.Round(CalculateStandardDeviation(standaardAfwijking), 3)
        Dim remove As Double = 0
        Dim remove2 As Double = 0
        Dim remove3 As String = ""
        Dim tVerd As New tVerdeling

        standaardAfwijking = New List(Of Double)

        For Each item As DataMiningPrediction2 In listOfAllItems
            item.isCorrect = True
            Dim afw = tVerd.getTwaarde(0.99, item.getTotaal) * deviatie / Math.Sqrt(item.getTotaal)

            Dim verschil = Math.Round((((item.getDoorgegaan / item.getTotaal) - (item.getKans)) * 100), 2)
            standaardAfwijking.Add(Math.Round((((item.getDoorgegaan / item.getTotaal) - (item.getKans)) * 100), 2))
            Dim echt = (Math.Round(((item.getDoorgegaan / item.getTotaal) * 10000)) / 100)

            ' Bereken de top waarde en onderste waarde van de afwijking, controlleer of deze boven 100 of onder 0 zit en pas deze aan indien nodig
            Dim bEdge = Math.Round(item.getKans * 100 - afw, 2)
            Dim tEdge = Math.Round(item.getKans * 100 + afw, 2)
            If bEdge < 0 Then bEdge = 0
            If tEdge > 100 Then tEdge = 100

            Dim result = "[" + bEdge.ToString + " - " + Math.Round(item.getKans * 100, 2).ToString + " - " + tEdge.ToString + "]"

            Dim kleur As Color
            If echt <= item.getKans * 100 + afw And echt >= item.getKans * 100 - afw Then
                trues += 1
                kleur = Color.LightGreen
                verschil = item.getKans * 100 - echt
                dgvResult.Rows.Add(item.getMerk, item.getUitvoerCentrum, item.getCodeSubAfdeling, item.getMaand.ToString, item.getDag, item.getTotaal.ToString, echt.ToString, result, Math.Round(verschil, 2).ToString)
                dgvResult.Rows(dgvResult.RowCount - 1).DefaultCellStyle.BackColor = kleur

                remove += afw
            Else
                kleur = Color.OrangeRed
                If echt < bEdge Then
                    verschil = bEdge - echt
                Else
                    verschil = tEdge - echt
                End If

                item.isCorrect = False
            End If
        Next


        ' berekend kans van iedere entry dat deze door gaat en plaatst dit vervolgens in de listview
        For Each item As DataMiningPrediction2 In listOfAllItems
            If Not item.isCorrect Then
                Dim j1, j2, j3, j4, j5, j6 As Double
                Dim n1, n2, n3, n4, n5, n6 As Double

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
                    wel = ((dicSubW(item.getCodeSubAfdeling) / atlDoorgg) * (dicMaandW(item.getMaand) / atlDoorgg) * (dicUitvW(item.getUitvoerCentrum) / atlDoorgg) * (atlDoorgg / (atlDoorgg + atlNietDgg)))
                    niet = ((dicSubN(item.getCodeSubAfdeling) / atlNietDgg) * (dicMaandN(item.getMaand) / atlNietDgg) * (dicUitvN(item.getUitvoerCentrum) / atlNietDgg) * (atlNietDgg / (atlDoorgg + atlNietDgg)))
                ElseIf item.getTotaal <= 15 Then
                    wel = ((dicMerkW(item.getMerk) / atlDoorgg) * (dicSubW(item.getCodeSubAfdeling) / atlDoorgg) * (dicMaandW(item.getMaand) / atlDoorgg) * (dicUitvW(item.getUitvoerCentrum) / atlDoorgg) * (atlDoorgg / (atlDoorgg + atlNietDgg)))
                    niet = ((dicMerkN(item.getMerk) / atlNietDgg) * (dicSubN(item.getCodeSubAfdeling) / atlNietDgg) * (dicMaandN(item.getMaand) / atlNietDgg) * (dicUitvN(item.getUitvoerCentrum) / atlNietDgg) * (atlNietDgg / (atlDoorgg + atlNietDgg)))
                Else
                    wel = ((dicMerkW(item.getMerk) / atlDoorgg) * (dicSubW(item.getCodeSubAfdeling) / atlDoorgg) * (dicMaandW(item.getMaand) / atlDoorgg) * (dicUitvW(item.getUitvoerCentrum) / atlDoorgg) * (atlDoorgg / (atlDoorgg + atlNietDgg)))
                    niet = ((dicMerkN(item.getMerk) / atlNietDgg) * (dicSubN(item.getCodeSubAfdeling) / atlNietDgg) * (dicMaandN(item.getMaand) / atlNietDgg) * (dicUitvN(item.getUitvoerCentrum) / atlNietDgg) * (atlNietDgg / (atlDoorgg + atlNietDgg)))

                End If
                Dim totaal = wel + niet
                Dim kansBayes = wel / totaal

                Dim xSum As Double = 0
                Dim ySum As Double = 0
                Dim xSquareSum As Double = 1
                Dim xySum As Double = 1
                Dim aantal As Integer = 0
                Dim a As Double
                Dim b As Double

                For Each itemWithYear As DataMiningPrediction2 In listOfAllItemsWithYear
                    If (item.getCodeSubAfdeling = itemWithYear.getCodeSubAfdeling) Then
                        If (item.getMaand = itemWithYear.getMaand) Then
                            If (item.getUitvoerCentrum = itemWithYear.getUitvoerCentrum) Then
                                If (item.getDag = itemWithYear.getDag) Then
                                    If item.getMerk = itemWithYear.getMerk Then
                                        Dim x = itemWithYear.getJaar
                                        Dim y = (itemWithYear.getDoorgegaan / itemWithYear.getTotaal)

                                        aantal += 1
                                        xySum += (x * y)
                                        xSum += x
                                        ySum += y
                                        xSquareSum += x ^ 2

                                    End If
                                End If
                            End If
                        End If
                    End If
                Next



                a = (((aantal * xySum) - (xSum * ySum)) / ((aantal * xSquareSum) - xSum ^ 2))
                b = (((xSquareSum * ySum) - (xSum * xySum)) / ((aantal * xSquareSum) - (xSum ^ 2)))

                item.setKans(((kansBayes * 1) + (a * Now.Year + b) * 1) / (1 + 1))
                If (item.getKans > 1) Then item.setKans(1)
                If (item.getKans < 0) Then item.setKans(0)
                'item.setKans(kansBayes)
                item.setJaar(a)
                item.temp = b

                ' Verschil
                Dim verschil = Math.Round((((item.getDoorgegaan / item.getTotaal) - (item.getKans)) * 100), 2)

                standaardAfwijking.Add(Math.Round((((item.getDoorgegaan / item.getTotaal) - (item.getKans)) * 100), 2))

                verschil = (Math.Round(item.getDoorgegaan / item.getTotaal * 100) - Math.Round(item.getKans * 100))
                If Not versch.ContainsKey(verschil) Then
                    versch.Add(verschil, 1)
                Else
                    versch(verschil) += 1
                End If

                If verschil > ligtTussen Or verschil < -ligtTussen Then
                    cOut += 1
                Else
                    cIn += 1
                End If

            End If
        Next



        ' Standaard afwijking berekenen
        deviatie = Math.Round(CalculateStandardDeviation(standaardAfwijking), 3)
        remove3 = ""

        For Each item As DataMiningPrediction2 In listOfAllItems
            If Not item.isCorrect Then
                Dim afw = tVerd.getTwaarde(0.995, item.getTotaal) * deviatie / Math.Sqrt(item.getTotaal)

                Dim verschil = Math.Round((((item.getDoorgegaan / item.getTotaal) - (item.getKans)) * 100), 2)

                Dim echt = (Math.Round(((item.getDoorgegaan / item.getTotaal) * 10000)) / 100)

                ' Bereken de top waarde en onderste waarde van de afwijking, controlleer of deze boven 100 of onder 0 zit en pas deze aan indien nodig
                Dim bEdge = Math.Round(item.getKans * 100 - afw, 2)
                Dim tEdge = Math.Round(item.getKans * 100 + afw, 2)
                If bEdge < 0 Then bEdge = 0
                If tEdge > 100 Then tEdge = 100

                Dim result = "[" + bEdge.ToString + " - " + Math.Round(item.getKans * 100, 2).ToString + " - " + tEdge.ToString + "]"

                Dim kleur As Color
                If echt <= item.getKans * 100 + afw And echt >= item.getKans * 100 - afw Then
                    trues += 1
                    kleur = Color.LightGreen
                    item.isCorrect = True

                    remove += afw
                Else
                    falses += 1
                    kleur = Color.OrangeRed
                    If echt < bEdge Then
                        verschil = bEdge - echt
                    Else
                        verschil = tEdge - echt
                    End If

                    remove2 += afw

                    remove3 += " or (Merk = '" + item.getMerk + "' and UitvCentrumOmsch = '" + item.getUitvoerCentrum + "' and CodeSubafdeling = '" + item.getCodeSubAfdeling + "' "
                    remove3 += " and Month(StartDatum) = " + item.getMaand.ToString + " and dag = '" + item.getDag + "')"
                End If

                dgvResult.Rows.Add(item.getMerk, item.getUitvoerCentrum, item.getCodeSubAfdeling, item.getMaand.ToString, item.getDag, item.getTotaal.ToString, echt.ToString, result, verschil.ToString, item.getJaar, item.temp)
                dgvResult.Rows(dgvResult.RowCount - 1).DefaultCellStyle.BackColor = kleur
            End If
        Next

        dgvResult.Refresh()


        ' Teken grafiek
        Dim ver As New Series
        For Each s As KeyValuePair(Of Double, Integer) In versch
            ver.Points.AddXY(s.Key, s.Value)
        Next
        drawBarGraph(ver)


        remove = remove / trues
        remove2 = remove2 / falses
        'remove2 = remove / listOfAllItems.Count

        pgb.Value = pgb.Maximum

        lblInfo2.Text = "Binnen -" + ligtTussen.ToString + " en " + ligtTussen.ToString + ": " + cIn.ToString + "    Buiten -" + ligtTussen.ToString + " en " + ligtTussen.ToString + ": " + cOut.ToString + "      Standaardafwijking: " + deviatie.ToString
        Label1.Text = "Totaal = " + (trues + falses).ToString + " waarvan " + trues.ToString + " (" + Math.Round((trues / (trues + falses) * 100), 2).ToString + "%) correct voorspeld waren en " + falses.ToString + " (" + Math.Round((falses / (trues + falses) * 100), 2).ToString + "%) niet"
    End Sub
    Private Sub initDataGridView()
        dgvResult.DataSource = Nothing
        dgvResult.Columns.Clear()
        addColumns(New ArrayList({"merk", "Uitvoerend centrum", "Sub afdeling", "Maand", "Dag", "Totaal", "% Doorgeg", "% Berekend", "verschil", "Temp", "Temp2"}))
        dgvResult.Columns(0).Width = 65
        dgvResult.Columns(1).Width = 100
        dgvResult.Columns(2).Width = 50
        dgvResult.Columns(3).Width = 50
        dgvResult.Columns(4).Width = 50
        dgvResult.Columns(5).Width = 40
        dgvResult.Columns(6).Width = 50
        dgvResult.Columns(7).Width = 115
        dgvResult.Columns(8).Width = 50
    End Sub

    Private Sub Test_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        System.Threading.Thread.Sleep(100)
        Application.DoEvents()
        bayesAndBayesLinear()
    End Sub
End Class