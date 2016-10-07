Public Class Prospect
    ''' <summary>
    ''' Berekent een verwachte gemiddelde voor een bepaalde jaar
    ''' </summary>
    ''' <param name="knownY">Arraylist voor de gekende X parameters</param>
    ''' <param name="knownX">Arraylist voor de gekende Y parameters</param>
    ''' <param name="toEstimate">Double X waarde dat insgeschat moet woorden</param>
    ''' <returns>De ingeschatte waarde voor Y</returns>
    ''' <example>prospect(Ywaarden, jaren, 2015)</example>
    Public Function prospect(knownY As ArrayList, knownX As ArrayList, toEstimate As Double) As Double
        Dim n As Integer
        n = knownY.Count()

        'Calculate averages and others
        Dim avgY, avgX, avgXY, avgXX As Double
        For i As Integer = 0 To n - 1
            Dim x As Double = knownX(i)
            Dim y As Double = Math.Log(knownY(i))
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

        Return Math.Exp(alpha + beta * toEstimate)
    End Function
    ''' <summary>
    ''' Berekent een bereik waar het gemiddelde zich zal bevinden.
    ''' Er wordt met een nauwkeurigheidsgraad van 95% gewerkt
    ''' </summary>
    ''' <param name="knownY">Arraylist voor de gekende Y waarden</param>
    ''' <param name="average">Double voorspelde gemiddelde</param>
    ''' <returns>Arraylist met 2 waarden, 0 --> Ondergrens; 1 --> Bovengrens</returns>
    Public Function certainty(knownY As ArrayList, average As Double) As ArrayList
        Dim toRet As New ArrayList
        Dim sumOfSquaresOfDifferences As Double
        For i As Integer = 0 To knownY.Count - 1
            sumOfSquaresOfDifferences += (knownY(i) - average) ^ 2
        Next
        Dim sd As Double = Math.Sqrt(sumOfSquaresOfDifferences / knownY.Count)
        Dim difference As Double = 1.96 * (sd / Math.Sqrt(knownY.Count))
        toRet.Add(average - difference)
        toRet.Add(average + difference)
        Return toRet
    End Function
End Class
