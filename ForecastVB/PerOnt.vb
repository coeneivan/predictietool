﻿Public Class PerOnt
    Private root As MainScreen
    Public Sub New(main As MainScreen)
        InitializeComponent()
        root = main
    End Sub
    Private Sub PerOnt_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim columns As New ArrayList({"Ontwikkelaar", "Merk", "Subafdeling", "Uitvoerend centrum", "Aantal geweest", "Doorgegaan", "Kans", "Echt"})
        addColumns(columns)
        Dim bll As New OntwikkelaarsBLL
        Dim rows = bll.getAll(root.getFilters)
        Dim bayes As New Bayes_Bayes_Linear(root, False)
        bayes.alleAfwijkingenVerwerken(rows)
        For Each cursus In rows
            'bayes.resetDictionary
            bayes.baycalculation(cursus, True)
            cursus.setKans(bayes.berekenBayes(cursus))
            dgvResult.Rows.Add(cursus.getOntw, cursus.getMerk, cursus.getCodeSubafdeling, cursus.getUitvoerCentrum, cursus.getTotaal, Math.Round((cursus.getAantalDoorgegaan / cursus.getTotaal) * 100, 2).ToString, cursus.getBereik, "0")
        Next


    End Sub
    Private Sub addColumns(list As ArrayList)
        For Each item In list
            Me.dgvResult.Columns.Add(item.ToString, item.ToString)
        Next
    End Sub
End Class