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
            ondergrens = Math.Round(pOndergrens, 2)
        Else
            ondergrens = 0
        End If
        If Not Double.IsNaN(pBovengrens) Then
            bovengrens = Math.Round(pBovengrens, 2)
        Else
            bovengrens = 100
        End If
        If Not Double.IsNaN(pAverage) Then
            average = pAverage
        Else
            average = 0
        End If
    End Sub
    Public Sub New(pAfwijking As Double, pAverage As Double)
        If pAverage - pAfwijking < 0 Then
            ondergrens = 0
        Else
            ondergrens = Math.Round(pAverage - pAfwijking, 2)
        End If
        average = pAverage
        If pAverage + pAfwijking > 100 Then
            bovengrens = 100
        Else
            bovengrens = Math.Round(pAverage + pAfwijking, 2)
        End If

    End Sub
    ''' <summary>
    ''' Een stringweergave van het bereik
    ''' </summary>
    ''' <returns>Een string om aan de eindgebruike te tonen afgerond op 2 cijfers na de komma</returns>
    Public Overrides Function ToString() As String
        Return "[" + IIf(ondergrens > 0, Math.Round(ondergrens, 2), 0).ToString + " - " + IIf(Math.Round(average, 2) > 0, IIf(Math.Round(average, 2) < 100, Math.Round(average, 2).ToString, 100), 0).ToString + " - " + IIf(bovengrens < 100, Math.Round(bovengrens, 2), 100).ToString + "]"
    End Function
    ''' <summary>
    ''' Controleert of mee geleverde waarde tussen dit bereik valt
    ''' </summary>
    ''' <param name="x">Waarde die gecontroleerd moet worden</param>
    ''' <returns>Ture = waarde valt tussen dit bereik, False = waarde valt er buiten</returns>
    Public Function valtTussen(x As Double) As Boolean
        Return x >= ondergrens And x <= bovengrens
    End Function
    ''' <summary>
    ''' Geeft gemiddelde terug
    ''' </summary>
    ''' <returns>Gemiddelde van dit bereik</returns>
    Public Function getAvg() As Double
        Return average
    End Function
    ''' <summary>
    ''' Geeft ondergrens terug
    ''' </summary>
    ''' <returns>Ondergrens van dit bereik</returns>
    Public Function getOndergrens() As Double
        Return ondergrens
    End Function
    ''' <summary>
    ''' Geeft bovengrens terug
    ''' </summary>
    ''' <returns>Bovengrens van dit bereik</returns>
    Public Function getBovengrens() As Double
        Return bovengrens
    End Function
    ''' <summary>
    ''' Berekent het verschil met de mee geleverde parameter
    ''' </summary>
    ''' <param name="x">Waarde waarmee het verschil berekend moet worden</param>
    ''' <returns>Als parameter binnen bereik--> verschil met gemiddelde. Als Parameter buiten bereik --> Verschil met dichtste grens</returns>
    Public Function verschilMet(x As Double) As Double
        Dim verschil As Double
        If valtTussen(x) Then
            If x < average Then
                verschil = average - x
            Else
                verschil = x - average
            End If
        Else
            If x < ondergrens Then
                verschil = ondergrens - x
            Else
                verschil = x - bovengrens
            End If
        End If
        Return Math.Round(verschil, 2)
    End Function
    Public Function getBreedte() As Double
        Return bovengrens - ondergrens
    End Function
End Class
