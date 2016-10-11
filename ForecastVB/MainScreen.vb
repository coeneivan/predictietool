﻿Public Class MainScreen
    Private Const jaar = 2015
    Private Sub MainScreen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Load all cursussen
        Dim subafds As New subAfdBll
        cboSubAfd.Items.AddRange(subafds.getAallSubAfds(jaar).ToArray)

        'Load dagen
        cboLesdag.Items.AddRange({"Maandag", "Dinsdag", "Woensdag", "Donderdag", "Vrijdag", "Zaterdag", "Zondag"})

        'Load merken
        Dim merken As New MerkBLL
        cboMerk.Items.AddRange(merken.getAll(jaar).ToArray)

        'Calculate main percentage
        Dim knownX, knownY As New ArrayList
        Dim dictionary As New Dictionary(Of String, Parameter)
        dictionary.Add("2006", New Parameter(100, 92.31))
        dictionary.Add("2007", New Parameter(100, 90))
        dictionary.Add("2008", New Parameter(100, 77.78))
        dictionary.Add("2009", New Parameter(100, 68.18))
        dictionary.Add("2010", New Parameter(100, 53.13))
        dictionary.Add("2011", New Parameter(100, 48))
        dictionary.Add("2012", New Parameter(100, 47.62))
        dictionary.Add("2013", New Parameter(100, 73.68))
        dictionary.Add("2014", New Parameter(100, 48.15))

        Dim p As New Prospect
        Dim pros = p.prospect(dictionary, CDbl(jaar))
        Dim range = p.certainty(dictionary, pros)
        txtRestultJaar.Text = range.ToString
    End Sub

    Private Sub cboSubAfd_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSubAfd.SelectedIndexChanged
        Dim subafd As New subAfdBll
        txtResultSubAfd.Text = subafd.berekenVerwachtingsBereikVoorSubAfd(jaar, cboSubAfd.SelectedItem).ToString
    End Sub

    Private Sub cboMerk_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboMerk.SelectedIndexChanged
        Dim merken As New MerkBLL
        txtResultMerk.Text = merken.berekenVerwachtingsBereikVoorMerk(jaar, cboMerk.SelectedItem).ToString
    End Sub
End Class