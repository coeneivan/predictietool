Public Class Prospect
    ''' <summary>
    ''' Berekent een verwachte gemiddelde voor een bepaalde jaar
    ''' </summary>
    ''' <param name="allValuesAndKeys">Dictionary(string, parameter) key = jaar, value=parameter(totaal, nietGeschrapte)</param>
    ''' <param name="toEstimate">Double X waarde dat insgeschat moet woorden</param>
    ''' <returns>De ingeschatte waarde voor Y</returns>
    Public Function prospect(allValuesAndKeys As Dictionary(Of String, Parameter), toEstimate As Double) As Double
        Dim n = allValuesAndKeys.Count

        'Calculate averages and others
        Dim avgY, avgX, avgXY, avgXX As Double
        For Each kvp As KeyValuePair(Of String, Parameter) In allValuesAndKeys
            Dim x = CDbl(kvp.Key)
            Dim y = Math.Log(kvp.Value.berekenPercentage)
            avgY += y
            avgX += x
            avgXY += x * y
            avgXX += x * x
        Next
        avgY = avgY / n
        avgX = avgX / n
        avgXY = avgXY / n
        avgXX = avgXX / n

        'Linear regression coefficients
        Dim beta As Double = (avgXY - avgX * avgY) / (avgXX - avgX * avgX)
        Dim alpha = avgY - beta * avgX
        If Not Double.IsNaN(Math.Exp(alpha + beta * toEstimate)) Then
            Return Math.Exp(alpha + beta * toEstimate)
        Else
            Return 1
        End If

    End Function
    ''' <summary>
    ''' Berekent een bereik waar het gemiddelde zich zal bevinden.
    ''' Er wordt met een nauwkeurigheidsgraad van 95% gewerkt
    ''' </summary>
    ''' <param name="allValuesAndKeys">Dictionary(string, parameter) key = jaar, value=parameter(totaal, nietGeschrapte)</param>
    ''' <param name="average">Double voorspelde gemiddelde</param>
    ''' <returns>Bereik met ondergrens, midden en bovengrens</returns>
    Public Function certainty(allValuesAndKeys As Dictionary(Of String, Parameter), average As Double) As Bereik
        'Dim toRet As New ArrayList
        Dim n = allValuesAndKeys.Count

        Dim sumOfSquaresOfDifferences As Double
        For Each kvp As KeyValuePair(Of String, Parameter) In allValuesAndKeys
            sumOfSquaresOfDifferences += (kvp.Value.berekenPercentage - average) ^ 2
        Next
        Dim sd As Double = Math.Sqrt(sumOfSquaresOfDifferences / n)
        Dim t As New tVerdeling
        Dim difference As Double = t.getTwaarde(0.995, n) * (sd / Math.Sqrt(n))
        Return New Bereik(average - difference, average, average + difference)
    End Function
    Public Function certainty(values As ArrayList, average As Double) As Bereik
        Dim sumOfSquaresOfDifferences As Double
        Dim n = values.Count
        For Each value In values
            If Not Double.IsNaN(value) Then
                sumOfSquaresOfDifferences += (value - average) ^ 2
            Else
                n -= 1
            End If
        Next
        Dim sd As Double = Math.Sqrt(sumOfSquaresOfDifferences / n)
        Dim difference As Double = 1.96 * (sd / Math.Sqrt(n))
        Return New Bereik((average - difference) * 100, (average) * 100, (average + difference) * 100)
    End Function
End Class
