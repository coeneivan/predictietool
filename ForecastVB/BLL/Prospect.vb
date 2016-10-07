Public Class Prospect
    ''' <summary>
    ''' Estimates the value, using 2 arraylists.
    ''' </summary>
    ''' <param name="knownY">Arraylist for known X values</param>
    ''' <param name="knownX">Arraylist for known Y values</param>
    ''' <param name="toEstimate">Double X value to estimate</param>
    ''' <returns>The estimated value for Y</returns>
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
    ''' Calculates a range of 95% certainty of the average.
    ''' </summary>
    ''' <param name="knownY">Arraylist from all the knwon Y values</param>
    ''' <param name="average">Double predicted average</param>
    ''' <returns>Arraylist with 2 values, 0 --> Lowest value; 1 --> Highest value</returns>
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
