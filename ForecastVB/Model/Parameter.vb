''' <summary>
''' Houdt de gegevens van een parameter bij (voor 1 jaar)
''' </summary>
Public Class Parameter
    Private totaalAantal, nietGeschrapt As Double
    Private totaalAantalGeschrapt, totaalAantalDoorgegaan, geschrapt, doorgegaan As Double
    ''' <summary>
    ''' Initialiseert de klasse
    ''' </summary>
    ''' <param name="pTotaal">Hoeveel cursussen werden er in totaal ingepland</param>
    ''' <param name="pNietGeschrapt">Hoeveel van de cursussen zijn er gerealiseerd</param>
    Public Sub New(pTotaal As Double, pNietGeschrapt As Double)
        totaalAantal = pTotaal
        nietGeschrapt = pNietGeschrapt
    End Sub
    Public Sub New(aantalGeschrapt As Double, aantaldoorgegaan As Double, pGeschrapt As Double, pDoorgegaan As Double)
        totaalAantalGeschrapt = aantalGeschrapt
        totaalAantalDoorgegaan = aantaldoorgegaan
        geschrapt = pGeschrapt
        doorgegaan = pDoorgegaan
        nietGeschrapt = pDoorgegaan
        totaalAantal = doorgegaan + geschrapt
    End Sub
    Public Sub New()

    End Sub
    ''' <summary>
    ''' Berekent het percentage van de gerealiseerde cursussen
    ''' </summary>
    ''' <returns>Double met een percentage waarde bv: 100</returns>
    Public Function berekenPercentage() As Double
        Return CDbl(nietGeschrapt / totaalAantal)
    End Function
    Public Function percentageDoorgegaan() As Double
        Return doorgegaan / totaalAantalDoorgegaan
    End Function
    Public Function percentageGeschrapt() As Double
        Return geschrapt / totaalAantalGeschrapt
    End Function

    Public Function getTotaal() As Double
        Return totaalAantal
    End Function

    Public Function getNietGeschrapt() As Double
        Return nietGeschrapt
    End Function

    Public Sub setTotaal(t As Double)
        totaalAantal = t
    End Sub

    Public Sub setNietGeschrapt(n As Double)
        nietGeschrapt = n
    End Sub
End Class
