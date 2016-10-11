Public Class Bereik
    Private ondergrens, average, bovengrens As Double
    Public Sub New(pOndergrens As Double, pAverage As Double, pBovengrens As Double)
        ondergrens = pOndergrens
        bovengrens = pBovengrens
        average = pAverage
    End Sub
    Public Overrides Function ToString() As String
        Return "[" + Math.Round(ondergrens, 2).ToString + " - " + Math.Round(average, 2).ToString + " - " + Math.Round(bovengrens, 2).ToString + "]"
    End Function
End Class
