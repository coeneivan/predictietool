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


        Dim columns As New ArrayList({"Ontwikkelaar", "Merk", "Maand", "Subafdeling", "Uitvoerend centrum", "Aantal geweest", "Doorgegaan", "Kans", "Verschil"})
        addColumns(columns)

        cbbMaand.Items.AddRange({"Januari", "Februari", "Maart", "April", "Mei", "Juni", "Juli", "Augustus", "September", "Oktober", "November", "December"})

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
        verschil = 0

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
                (cbbOnt.SelectedItem Is Nothing Or cursus.getOntw.Equals(cbbOnt.SelectedItem)) And (cbbMaand.SelectedItem Is Nothing Or cursus.getMaand.Equals(cbbMaand.SelectedIndex + 1)) And
                (cbbSubafdeling.SelectedItem Is Nothing Or cursus.getCodeSubafdeling.Equals(cbbSubafdeling.SelectedItem)) Then

                If cursus.getBereik(root.getAfwijkinsindex).valtTussen(Math.Round((cursus.getAantalDoorgegaan / cursus.getTotaal) * 100, 2)) Then
                    trues += 1
                    cursus = cursus.setIsCorrect(True)
                Else
                    falses += 1
                End If

                dgvResult.Rows.Add(cursus.getOntw, cursus.getMerk, cursus.getMaand, cursus.getCodeSubafdeling, cursus.getUitvoerCentrum, cursus.getTotaal,
                                   Math.Round((cursus.getAantalDoorgegaan / cursus.getTotaal) * 100, 2).ToString, cursus.getBereik(root.getAfwijkinsindex),
                                   cursus.getBereik(root.getAfwijkinsindex).verschilMet(Math.Round((cursus.getAantalDoorgegaan / cursus.getTotaal) * 100, 2)).ToString)

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

    Private Sub btnClearMaand_Click(sender As Object, e As EventArgs) Handles btnClearMaand.Click
        cbbMaand.SelectedItem = Nothing
    End Sub


    Private Sub dgvResult_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvResult.CellClick
        If Not e.RowIndex = -1 Then
            Try
                Me.Cursor = Cursors.WaitCursor


                dgvExtraInfo.Columns.Clear()
                Dim ont = dgvResult.Rows(e.RowIndex).Cells(0).Value.ToString
                Dim merk = dgvResult.Rows(e.RowIndex).Cells(1).Value.ToString
                Dim maand = dgvResult.Rows(e.RowIndex).Cells(2).Value.ToString
                Dim Subafdeling = dgvResult.Rows(e.RowIndex).Cells(3).Value.ToString
                Dim uc = dgvResult.Rows(e.RowIndex).Cells(4).Value.ToString
                Dim cursus As New Cursus(merk, uc, maand, "", Subafdeling, 0, 0, 0, 0, 0, Nothing, Nothing, False, ont)

                Dim ontwikkelaars As New OntwikkelaarsBLL()
                Dim listOfSelected = ontwikkelaars.getList(cursus, root.getFilters)

                If listOfSelected.Count > 0 Then
                    Dim listOfNames As New ArrayList({"Opleidingsnr", "omschrijving", "StartDatum", "dag", "EindDatum", "TotalePrijs", "Merk", "UitvCentrumOmsch", "Aard", "CaM", "CuB", "OpC", "Ont", "CoC", "CodeSubafdeling", "CodeIngetrokken", "Lesplaats", "OpInternet", "LesroosterGevalideerd", "AtlCursisten"})
                    For Each item In listOfNames
                        Me.dgvExtraInfo.Columns.Add(item.ToString, item.ToString)
                    Next
                    For Each c As CursusExtraInfo In listOfSelected
                        dgvExtraInfo.Rows.Add(c.oNr, c.omschrijving, c.datumStart, c.datumEinde, c.lesdag, c.prijs, c.hetMerk, c.centrum, c.deAard, c.deCaM, c.deCuB, c.deOpC, c.deOnt, c.deCoc, c.deSubAfd, c.isIngetrokken, c.plaats, c.isOpInternet, c.gevalideerd, c.aantalCursisten)
                    Next
                End If
            Finally
                Me.Cursor = Cursors.Default
            End Try

        End If
    End Sub
End Class