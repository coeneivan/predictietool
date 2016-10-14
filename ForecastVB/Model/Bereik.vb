﻿''' <summary>
''' Simpele klasse om bereik van verwachtingen weer te geven
''' </summary>
Public Class Bereik
    Private ondergrens, average, bovengrens As Double
    ''' <summary>
    ''' Initialiseert de klasse
    ''' </summary>
    ''' <param name="pOndergrens">Double met de waarde van de ondergrens</param>
    ''' <param name="pAverage">Double met de waarde van het gemiddelde</param>
    ''' <param name="pBovengrens">Double met de waarde van de bovengrens</param>
    Public Sub New(pOndergrens As Double, pAverage As Double, pBovengrens As Double)
        ondergrens = pOndergrens
        bovengrens = pBovengrens
        average = pAverage
    End Sub
    ''' <summary>
    ''' Een stringweergave van het bereik
    ''' </summary>
    ''' <returns>Een string om aan de eindgebruike te tonen</returns>
    Public Overrides Function ToString() As String
        Return "[" + IIf(ondergrens > 0, Math.Round(ondergrens, 2), 0).ToString + " - " + Math.Round(average, 2).ToString + " - " + IIf(bovengrens < 100, Math.Round(bovengrens, 2), 100).ToString + "]"
    End Function
    Public Function valtTussen(x As Double) As Boolean
        Return x >= ondergrens And x <= bovengrens
    End Function
    Public Function getAvg() As Double
        Return average
    End Function
End Class
