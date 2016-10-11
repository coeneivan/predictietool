Public Class SubAfdDao
    ''' <summary>
    ''' Telt het aantal cursussen in een bepaalde sub afdeling voor een bepaald jaar.
    ''' Geeft ze terug in een arraylyst gegroepeerd per jaar
    ''' </summary>
    ''' <param name="jaar">Integer, het resultaat zal zal plaatsvinden voor dit jaar</param>
    ''' <param name="subAfd">String van de geselecteerde subafdeling</param>
    ''' <returns>Arralyst met het aantal cursussen gegroepeerd per jaar</returns>
    Public Function getAantalCursussenPerJaarPerSubAfd(jaar As Integer, subAfd As String) As ArrayList
        Dim s As New SQLUtil
        Dim toRet = s.Execute("SELECT count(Opleidingsnr) FROM Cursussen WHERE CodeSubafdeling = '" + subAfd + "'AND year(StartDatum) < " + jaar.ToString + " GROUP BY year(StartDatum)")
        Return toRet
    End Function
    ''' <summary>
    ''' Telt het aantal cursussen in een bepaalde sub afdeling voor een bepaald jaar die niet geschrapt zijn.
    ''' Geeft ze terug in een arraylyst gegroepeerd per jaar
    ''' </summary>
    ''' <param name="jaar">Integer, het resultaat zal plaatsvinden voor dit jaar</param>
    ''' <param name="subAfd">String van de geselecteerde subafdeling</param>
    ''' <returns>Arralyst met het aantal cursussen die neit geschrapt werden gegroepeerd per jaar</returns>
    Public Function getAantalNietGeschrapteCurussenPerJaarPerSubAfd(jaar As Integer, subAfd As String) As ArrayList
        Dim s As New SQLUtil
        Dim toRet = s.Execute("SELECT count(Opleidingsnr) FROM Cursussen WHERE CodeSubafdeling = '" + subAfd + "' AND codeIngetrokken ='nee' AND year(StartDatum) < " + jaar.ToString + " GROUP BY year(StartDatum)")
        Return toRet
    End Function
    ''' <summary>
    ''' Geeft de gekende jaren voor een bepaalde sub afdeling
    ''' </summary>
    ''' <param name="jaar">Integer, het resultaat zal plaatsvinden voor dit jaar</param>
    ''' <param name="subAfd">String van de geselecteerde subafdeling</param>
    ''' <returns>Arralyst met de gekende jaren voor de meegegeven subafdeling</returns>
    Public Function getGekendeJarenPerSubAfd(jaar As Integer, subAfd As String) As ArrayList
        Dim s As New SQLUtil
        Dim toRet = s.Execute("SELECT Distinct YEAR(startdatum) FROM Cursussen WHERE CodeSubafdeling = '" + subAfd + "'AND year(StartDatum) < " + jaar.ToString)
        Return toRet
    End Function

    ''' <summary>
    ''' Geeft alle codes van de gekende subafdelingen 1 keer terug
    ''' </summary>
    ''' <returns>Geeft een array met alle gekende subafdelingen 1 keer in de lijst terug</returns>
    Public Function getAlleSubafdelingen() As ArrayList
        Dim s As New SQLUtil
        Dim toRet = s.Execute("SELECT DISTINCT CodeSubafdeling FROM Cursussen")
        Return toRet
    End Function

    ''' <summary>
    ''' Geeft een lijst terug van alle subafdelingen voor een bepaald jaar
    ''' </summary>
    ''' <param name="jaar">Het jaar waarvoor de subafdelingen gezocht moeten worden</param>
    ''' <returns>ArrayList met alle subafdelingen van het gegeven jaar</returns>
    Public Function getAlleSubafdelingenPerJaar(jaar As Integer) As ArrayList
        Dim s As New SQLUtil
        Dim toRet = s.Execute("SELECT DISTINCT CodeSubafdeling FROM Cursussen where year(StartDatum) = " + jaar.ToString)
        Return toRet
    End Function
End Class
