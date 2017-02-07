﻿''' <summary>
''' Met welke t waarde moet er gewerkt worden?
''' </summary>
''' 
Public Class tVerdeling
    Dim betrwBArray = {0.995, 0.99, 0.975, 0.95, 0.9}


    Private tbl = {{63.66, 31.82, 12.71, 6.31, 3.08}, '1
                   {9.92, 6.96, 4.3, 2.92, 1.89}, '2
                   {5.84, 4.54, 3.18, 2.35, 1.64},'3
                   {4.6, 3.75, 2.78, 2.13, 1.53},'4
                   {4.03, 3.36, 2.57, 2.02, 1.48},'5
                   {3.71, 3.14, 2.45, 1.94, 1.44},'6
                   {3.5, 3, 2.36, 1.89, 1.41},'7
                   {3.36, 2.9, 2.31, 1.86, 1.4},'8
                   {3.25, 2.82, 2.26, 1.83, 1.38},'9
                   {3.17, 2.76, 2.23, 1.81, 1.37},'10
                   {3.11, 2.72, 2.2, 1.8, 1.36},'11
                   {3.05, 2.68, 2.18, 1.78, 1.36},'12
                   {3.01, 2.65, 2.16, 1.77, 1.35},'13
                   {2.98, 2.62, 2.14, 1.76, 1.35},'14
                   {2.95, 2.6, 2.13, 1.75, 1.34},'15
                   {2.92, 2.58, 2.12, 1.75, 1.34},'16
                   {2.9, 2.57, 2.11, 1.74, 1.33},'17
                   {2.88, 2.55, 2.1, 1.73, 1.33},'18
                   {2.86, 2.54, 2.09, 1.73, 1.33},'19
                   {2.85, 2.53, 2.09, 1.72, 1.33},'20
                   {2.83, 2.52, 2.08, 1.72, 1.32},'21
                   {2.82, 2.51, 2.07, 1.72, 1.32},'22
                   {2.81, 2.5, 2.07, 1.71, 1.32},'23
                   {2.8, 2.49, 2.06, 1.71, 1.32},'24
                   {2.79, 2.49, 2.06, 1.71, 1.32},'25
                   {2.78, 2.48, 2.06, 1.71, 1.31},'26
                   {2.77, 2.47, 2.05, 1.7, 1.31},'27
                   {2.76, 2.47, 2.05, 1.7, 1.31},'28
                   {2.76, 2.46, 2.05, 1.7, 1.31},'29
                   {2.75, 2.46, 2.04, 1.7, 1.31},'30
                   {2.72, 2.44, 2.03, 1.69, 1.31},'35
                   {2.7, 2.42, 2.02, 1.68, 1.3},'40
                   {2.68, 2.4, 2.01, 1.68, 1.3},'50
                   {2.66, 2.39, 2, 1.67, 1.3},'60
                   {2.64, 2.37, 1.99, 1.66, 1.29},'80
                   {2.63, 2.36, 1.98, 1.66, 1.29},'100
                   {2.62, 2.36, 1.98, 1.66, 1.29},'120
                   {2.61, 2.35, 1.98, 1.66, 1.29},'150
                   {2.58, 2.33, 1.96, 1.645, 1.28}} '>150

    ''' <summary>
    ''' Haalt de gepaste tWaarde
    ''' </summary>
    ''' <param name="betrouwbaarheidspercentage">Welk percentage? 0.995/0.99/0.975/0.95/0.9</param>
    ''' <param name="aantal">Met hoeveel data heb je te maken?</param>
    ''' <returns>Double, tWaarde waarmee er gewerkt moet worden</returns>
    Public Function getTwaarde(betrouwbaarheidspercentage As Double, aantal As Double) As Double
        Dim x, y As Integer
        Dim foundX As Boolean = False

        ' Overloop de mogelijke betrouwbaarheidspercentage en hou index bij wanneer deze gevonden wordt
        For i As Integer = 0 To betrwBArray.Length - 1
            If (betrwBArray(i) = betrouwbaarheidspercentage) Then
                x = i
                foundX = True
            End If
        Next

        ' Wanneer betrouwbaarheidspercentage niet werd gevonden is gooi een exception
        If Not foundX Then Throw New NotSupportedException("Gegeven betrouwbaarheidspercentage werd niet terug gevonden")

        ' controle of geldig aantal werd meegegeven
        If aantal <= 0 Then Throw New NotSupportedException("Aantal is negatief getal of 0")


        Select Case aantal
            Case < 30
                y = aantal - 1
            Case 30 To 34
                y = 30 - 1
            Case 35 To 39
                y = 31 - 1
            Case 40 To 49
                y = 32 - 1
            Case 50 To 59
                y = 33 - 1
            Case 60 To 79
                y = 34 - 1
            Case 80 To 99
                y = 35 - 1
            Case 100 To 119
                y = 36 - 1
            Case 120 To 149
                y = 37 - 1
            Case 150
                y = 38 - 1
            Case > 150
                y = 39 - 1
        End Select
        Return tbl(y, x)
    End Function


    ''' <summary>
    ''' Geef de verschillende mogelijk percentages terug hoeveel procent van de T-Verdeling
    ''' </summary>
    ''' <returns>Geeft de percentages terug in een array, deze percentages worden in kommagetallen teruggeven</returns>
    Public Function getBetrouwbaarheidsIntervallen() As Double()
        Return betrwBArray
    End Function

End Class