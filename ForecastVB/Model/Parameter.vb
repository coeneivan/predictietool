''' <summary>
''' Houdt de gegevens van een parameter bij (voor 1 jaar)
''' </summary>
Public Class Parameter
    Private totaalAantal, nietGeschrapt As Double
    ''' <summary>
    ''' Initialiseert de klasse
    ''' </summary>
    ''' <param name="pTotaal">Hoeveel cursussen werden er in totaal ingepland</param>
    ''' <param name="pNietGeschrapt">Hoeveel van de cursussen zijn er gerealiseerd</param>
    Public Sub New(pTotaal As Double, pNietGeschrapt As Double)
        totaalAantal = pTotaal
        nietGeschrapt = pNietGeschrapt
    End Sub
    ''' <summary>
    ''' Berekent het percentage van de gerealiseerde cursussen
    ''' </summary>
    ''' <returns>Double met een percentage waarde bv: 100</returns>
    Public Function berekenPercentage() As Double
        Return Math.Round((nietGeschrapt / totaalAantal * 100), 2)
    End Function

    Public Function getTotaal() As Double
        Return totaalAantal
    End Function
End Class
