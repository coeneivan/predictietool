Imports System.Windows.Forms.DataVisualization.Charting

Public Class Test
    Dim root As MainScreen
    Dim a As Double = 1
    Dim b As Double = 1
    Dim c As Double = 1
    Dim som As Double = 0
    Dim nodata As Double

    Public Sub New(main As MainScreen)
        root = main
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.

        initDataGridView()
    End Sub

    Private Sub Test_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim b As New Bayes_Bayes_Linear()
        b.setFilters(root.getFilters)
        b.getData()
        cbbMerk.Items.AddRange(b.getMerken.ToArray)
        cbbCentrum.Items.AddRange(b.getCentra.ToArray)
        cbbSubafdeling.Items.AddRange(b.getSubafdelingen.ToArray)
        cbbLesdag.Items.AddRange({"Maandag", "Dinsdag", "Woensdag", "Donderdag", "Vrijdag", "Zaterdag", "Zondag"})
        cbbMaand.Items.AddRange({"Januari", "Februari", "Maart", "April", "Mei", "Juni", "Juli", "Augustus", "September", "Oktober", "November", "December"})
    End Sub

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

    Private Sub dgvResult_SortCompare(sender As Object, e As DataGridViewSortCompareEventArgs) Handles dgvResult.SortCompare
        If e.Column.Index = 8 Then
            Try
                e.SortResult = If(CDbl(e.CellValue1) < CDbl(e.CellValue2), -1, 1)
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

    Private Sub bayesAndBayesLinear()
        Dim filters = root.getFilters()
        Dim trues = 0
        Dim falses = 0
        Dim cIn As Integer = 0
        Dim cOut As Integer = 0
        Dim ligtTussen As Integer = 10
        Dim versch As New Dictionary(Of Double, Integer)
        Dim bayesBayesLinear As New Bayes_Bayes_Linear()
        bayesBayesLinear.setFilters(filters)
        bayesBayesLinear.BerekenKans()

        ' Standaard afwijking berekenen
        Dim deviatie = bayesBayesLinear.deviatie


        For Each item As Cursus In bayesBayesLinear.getItems
            Dim dag As String = ""
            If (cbbLesdag.SelectedItem IsNot Nothing) Then dag = cbbLesdag.SelectedItem.ToLower()

            If (cbbMerk.SelectedItem Is Nothing Or item.getMerk.Equals(cbbMerk.SelectedItem)) And (cbbCentrum.SelectedItem Is Nothing Or item.getUitvoerCentrum.Equals(cbbCentrum.SelectedItem)) And
            (cbbLesdag.SelectedItem Is Nothing Or item.getDag.Equals(dag)) And (cbbSubafdeling.SelectedItem Is Nothing Or item.getCodeSubAfdeling.Equals(cbbSubafdeling.SelectedItem)) And
            (cbbMaand.SelectedItem Is Nothing Or item.getMaand.Equals(cbbMaand.SelectedIndex + 1)) Then

                Dim echt = (Math.Round(((item.getDoorgegaan / item.getTotaal) * 10000)) / 100)

                ' Bereken de top waarde en onderste waarde van de afwijking, controlleer of deze boven 100 of onder 0 zit en pas deze aan indien nodig
                Dim bereik = New Bereik(item.afwijking, item.getKans * 100)

                Dim kleur As Color
                If bereik.valtTussen(echt) Then
                    trues += 1
                    kleur = Color.LightGreen
                    item.isCorrect = True
                Else
                    falses += 1
                    kleur = Color.OrangeRed
                End If

                'Verschil
                Dim verschil = Math.Round(((item.getDoorgegaan / item.getTotaal) - (item.getKans)) * 100)
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

                dgvResult.Rows.Add(item.getMerk, item.getUitvoerCentrum, item.getCodeSubAfdeling, item.getMaand.ToString, item.getDag, item.getTotaal.ToString, echt.ToString, bereik.ToString, bereik.verschilMet(echt).ToString, item.getJaar, item.temp)
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        initDataGridView()
        bayesAndBayesLinear()
    End Sub

    Private Sub btnClearMerk_Click(sender As Object, e As EventArgs) Handles btnClearMerk.Click
        cbbMerk.SelectedItem = Nothing
    End Sub

    Private Sub btnClearCenturm_Click(sender As Object, e As EventArgs) Handles btnClearCenturm.Click
        cbbCentrum.SelectedItem = Nothing
    End Sub

    Private Sub btnClearSubafdeling_Click(sender As Object, e As EventArgs) Handles btnClearSubafdeling.Click
        cbbSubafdeling.SelectedItem = Nothing
    End Sub

    Private Sub btnClearDag_Click(sender As Object, e As EventArgs) Handles btnClearDag.Click
        cbbLesdag.SelectedItem = Nothing
    End Sub

    Private Sub btnClearMaand_Click(sender As Object, e As EventArgs) Handles btnClearMaand.Click
        cbbMaand.SelectedItem = Nothing
    End Sub
End Class