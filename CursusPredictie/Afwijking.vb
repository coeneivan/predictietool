<Serializable()> Public Class Afwijking
    Private tverdWaarde As Double
    Private afw As Double


    ''' <summary>
    ''' Maak een nieuw object aan voor welke tverdelingen een afwijking voor moet worden berekend
    ''' </summary>
    ''' <param name="tver">Geef een van de betrouwbaarheidspercentages die in de t-verdeling voorkomen</param>
    ''' <param name="afw">De afwijking die gerekend mag worden voor het gegeven betrouwbaarheidspercentage</param>
    Public Sub New(tver As Double, afw As Double)
        tverdWaarde = tver
        Me.afw = afw
    End Sub

    ''' <summary>
    ''' Geef een string waarde terug om in een UI het betrouwbaarheidspercentage terug te geven
    ''' 0.95 geeft 95% terug
    ''' </summary>
    ''' <returns>een string waarde in procent voor de tverdeling om in een UI terug te geven</returns>
    Public Function getText() As String
        Return (tverdWaarde * 100).ToString + "%"
    End Function

    ''' <summary>
    ''' Krijg het betrouwbaarheidsinterval terug voor welke de afwijking berekend zal worden
    ''' </summary>
    ''' <returns>double als betrouwbaarheidsinterval</returns>
    Public Function getTverdelingswaarde() As Double
        Return tverdWaarde
    End Function


    ''' <summary>
    ''' Krijg de afwijking terug voor het gegeven betrouwbaarheidsinterval
    ''' </summary>
    ''' <returns>Double als afwijking die berekend werd</returns>
    Public Function getAfwijkingswaarde() As Double
        Return afw
    End Function

    ''' <summary>
    ''' Stel het betrouwbaarheidsinterval in voor de gewenste waarde
    ''' </summary>
    ''' <param name="t">Comma getal die het betrouwbaarheidspercentage voorsteld, deze moet voorkomen in de tabel van de T-Verdeling</param>
    Public Sub setTverdelingswaarde(t As Double)
        tverdWaarde = t
    End Sub

    ''' <summary>
    ''' Stelt het afwijkspercentage in
    ''' </summary>
    ''' <param name="a">Het percentage van de afwijking</param>
    Public Sub setAfwijking(a As Double)
        afw = a
    End Sub
End Class
