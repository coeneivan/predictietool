Public Class Parameter
    Private totaalAantal, nietGeschrapt As Double
    Public Sub New(pTotaal As Double, pNietGeschrapt As Double)
        totaalAantal = pTotaal
        nietGeschrapt = pNietGeschrapt
    End Sub
    Public Function berekenPercentage() As Double
        Return Math.Round((nietGeschrapt / totaalAantal * 100), 2)
    End Function
End Class
