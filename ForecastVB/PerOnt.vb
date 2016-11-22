Public Class PerOnt
    Private root As MainScreen
    Private trues As Double = 0
    Private falses As Double = 0
    Private verschil As Double = 0
    Private ontwikkelaars As New Dictionary(Of String, Cursus)

    Public Sub New(main As MainScreen)
        InitializeComponent()
        root = main
    End Sub
    Private Sub PerOnt_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim columns As New ArrayList({"Ontwikkelaar", "Merk", "Subafdeling", "Uitvoerend centrum", "Aantal geweest", "Doorgegaan", "Kans", "Verschil"})
        addColumns(columns)
        Dim bll As New OntwikkelaarsBLL
        Dim rows = bll.getAll(root.getFilters)
        Dim bayes As New Bayes_Bayes_Linear(root, False)
        bayes.resetDictionaries()

        For i As Integer = 0 To rows.Count - 1
            bayes.baycalculation(rows(i), True)
        Next

        For i As Integer = 0 To rows.Count - 1
            rows(i) = rows(i).setKans(bayes.berekenBayes(rows(i)))
        Next

        bayes.alleAfwijkingenVerwerken(rows)

        For Each cursus In rows
            Dim kleur As Color
            If cursus.getBereik.valtTussen(Math.Round((cursus.getAantalDoorgegaan / cursus.getTotaal) * 100, 2)) Then
                trues += 1
                kleur = Color.LightGreen
                cursus = cursus.setIsCorrect(True)
            Else
                falses += 1
                kleur = Color.OrangeRed
            End If

            dgvResult.Rows.Add(cursus.getOntw, cursus.getMerk, cursus.getCodeSubafdeling, cursus.getUitvoerCentrum, cursus.getTotaal, Math.Round((cursus.getAantalDoorgegaan / cursus.getTotaal) * 100, 2).ToString, cursus.getBereik, cursus.getBereik.verschilMet(Math.Round((cursus.getAantalDoorgegaan / cursus.getTotaal) * 100, 2)).ToString)
            dgvResult.Rows(dgvResult.RowCount - 1).DefaultCellStyle.BackColor = kleur
            verschil += cursus.getBereik().getBreedte


            If Not ontwikkelaars.ContainsKey(cursus.getCodeSubafdeling.ToUpper) Then
                ontwikkelaars.Add(cursus.getCodeSubafdeling.ToUpper, cursus)
            End If
        Next
        lblInfo.Text = (trues + falses).ToString + " items waarvan " + trues.ToString + " juist ingeschat met een gemiddelde afwijking van " + Math.Round(verschil / (trues + falses), 2).ToString
        fillComboboxen()
    End Sub

    Private Sub fillComboboxen()
        cbbMerk.Items.AddRange(root.getMerken)
        cbbCentrum.Items.AddRange(root.getCentra)
        cbbSubafdeling.Items.AddRange(root.getSubafdeling)

        Dim list As New List(Of String)
        For Each k In ontwikkelaars
            list.Add(k.Key)
        Next
        Dim arr As Array = list.ToArray
        Array.Sort(arr)

        cbbOnt.Items.AddRange(arr)
    End Sub

    Private Sub addColumns(list As ArrayList)
        For Each item In list
            Me.dgvResult.Columns.Add(item.ToString, item.ToString)
        Next
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

    Private Sub btnClearOnt_Click(sender As Object, e As EventArgs) Handles btnClearOnt.Click
        cbbOnt.SelectedItem = Nothing
    End Sub
End Class