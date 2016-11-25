Imports System.Windows.Forms
Imports ForecastVB

Public Class PerOnt
    Private root As MainScreen
    Private trues As Double = 0
    Private falses As Double = 0
    Private verschil As Double = 0
    Private merken As New Dictionary(Of String, Cursus)
    Private centra As New Dictionary(Of String, Cursus)
    Private subafdelingen As New Dictionary(Of String, Cursus)
    Private ontwikkelaars As New Dictionary(Of String, Cursus)
    Dim rows

    Public Sub New(main As MainScreen)
        InitializeComponent()
        root = main
        Dim bll As New OntwikkelaarsBLL
        Try
            root.Cursor = Cursors.WaitCursor
            rows = bll.getAll(root.getFilters)
        Catch ex As Exception
            Throw ex
        Finally
            root.Cursor = Cursors.Default
        End Try


        Dim columns As New ArrayList({"Ontwikkelaar", "Merk", "Subafdeling", "Uitvoerend centrum", "Aantal geweest", "Doorgegaan", "Kans", "Verschil"})
        addColumns(columns)

        ' Dropdown voor afwijking initialiseren
        Dim curs As New Cursus("", "", Nothing, "", "", Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Algoritmes.Niets, Nothing, "")
        For i As Integer = 0 To curs.getAantalAfwijkingen - 1
            cbbValtTussen.Items.Insert(i, curs.getAfwijkingsString(i))
        Next
        cbbValtTussen.SelectedIndex = curs.getAantalAfwijkingen - 1
        root.setTVerdeling(curs.getAantalAfwijkingen - 1)
    End Sub
    Private Sub PerOnt_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        vulTable(rows)
        fillComboboxen()
    End Sub

    Private Sub vulTable(rows As List(Of Cursus))
        root.setTVerdeling(cbbValtTussen.SelectedIndex)
        trues = 0
        falses = 0

        dgvResult.Rows.Clear()

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
            If (cbbCentrum.SelectedItem Is Nothing Or cursus.getUitvoerCentrum.Equals(cbbCentrum.SelectedItem)) And (cbbMerk.SelectedItem Is Nothing Or cursus.getMerk.Equals(cbbMerk.SelectedItem)) And
                (cbbOnt.SelectedItem Is Nothing Or cursus.getOntw.Equals(cbbOnt.SelectedItem)) And
                (cbbSubafdeling.SelectedItem Is Nothing Or cursus.getCodeSubafdeling.Equals(cbbSubafdeling.SelectedItem)) Then

                Dim kleur As Color
                If cursus.getBereik(root.getAfwijkinsindex).valtTussen(Math.Round((cursus.getAantalDoorgegaan / cursus.getTotaal) * 100, 2)) Then
                    trues += 1
                    kleur = Color.LightGreen
                    cursus = cursus.setIsCorrect(True)
                Else
                    falses += 1
                    kleur = Color.OrangeRed
                End If

                dgvResult.Rows.Add(cursus.getOntw, cursus.getMerk, cursus.getCodeSubafdeling, cursus.getUitvoerCentrum, cursus.getTotaal,
                                   Math.Round((cursus.getAantalDoorgegaan / cursus.getTotaal) * 100, 2).ToString, cursus.getBereik(root.getAfwijkinsindex),
                                   cursus.getBereik(root.getAfwijkinsindex).verschilMet(Math.Round((cursus.getAantalDoorgegaan / cursus.getTotaal) * 100, 2)).ToString)
                dgvResult.Rows(dgvResult.RowCount - 1).DefaultCellStyle.BackColor = kleur
                verschil += cursus.getBereik(root.getAfwijkinsindex).getBreedte

                If Not merken.ContainsKey(cursus.getMerk) Then
                    merken.Add(cursus.getMerk, cursus)
                End If
                If Not centra.ContainsKey(cursus.getUitvoerCentrum) Then
                    centra.Add(cursus.getUitvoerCentrum, cursus)
                End If
                If Not subafdelingen.ContainsKey(cursus.getCodeSubafdeling.ToUpper) Then
                    subafdelingen.Add(cursus.getCodeSubafdeling.ToUpper, cursus)
                End If
                If Not ontwikkelaars.ContainsKey(cursus.getOntw.ToUpper) Then
                    ontwikkelaars.Add(cursus.getOntw.ToUpper, cursus)
                End If
            End If
        Next
        lblInfo.Text = (trues + falses).ToString + " items waarvan " + trues.ToString + " juist ingeschat met een gemiddelde afwijking van " + Math.Round(verschil / (trues + falses), 2).ToString

    End Sub

    Private Sub fillComboboxen()
        cbbMerk.Items.AddRange(getAndOrder(merken))
        cbbCentrum.Items.AddRange(getAndOrder(centra))
        cbbSubafdeling.Items.AddRange(getAndOrder(subafdelingen))
        cbbOnt.Items.AddRange(getAndOrder(ontwikkelaars))
    End Sub
    Private Function getAndOrder(dic As Dictionary(Of String, Cursus)) As Array
        Dim list As New List(Of String)
        For Each k In dic
            list.Add(k.Key)
        Next
        Dim arr As Array = list.ToArray
        Array.Sort(arr)
        Return arr
    End Function
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

    Private Sub btnBereken_Click(sender As Object, e As EventArgs) Handles btnBereken.Click
        vulTable(rows)
    End Sub
End Class