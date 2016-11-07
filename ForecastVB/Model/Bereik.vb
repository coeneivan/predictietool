''' <summary>
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
        If Not Double.IsNaN(pOndergrens) Then
            ondergrens = pOndergrens
        Else
            ondergrens = 0
        End If
        If Not Double.IsNaN(pBovengrens) Then
            bovengrens = pBovengrens
        Else
            bovengrens = 100
        End If
        If Not Double.IsNaN(pAverage) Then
            average = pAverage
        Else
            average = 0
        End If
    End Sub
    ''' <summary>
    ''' Een stringweergave van het bereik
    ''' </summary>
    ''' <returns>Een string om aan de eindgebruike te tonen</returns>
    Public Overrides Function ToString() As String
        Return "[" + IIf(ondergrens > 0, Math.Round(ondergrens, 2), 0).ToString + " - " + IIf(Math.Round(average, 2) > 0, IIf(Math.Round(average, 2) < 100, Math.Round(average, 2).ToString, 100), 0).ToString + " - " + IIf(bovengrens < 100, Math.Round(bovengrens, 2), 100).ToString + "]"
    End Function
    Public Function valtTussen(x As Double) As Boolean
        Return x >= ondergrens And x <= bovengrens
    End Function
    Public Function getAvg() As Double
        Return average
    End Function
    Public Function getOndergrens() As Double
        Return ondergrens
    End Function
    Public Function getBovengrens() As Double
        Return bovengrens
    End Function
End Class
