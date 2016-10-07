Public Class SubAfdBLL
    ''' <summary>
    ''' Berekent het verwachtingsbereik voor een bepaalde sub afdeling
    ''' </summary>
    ''' <param name="jaar">Integer, het resultaat zal zal plaatsvinden voor dit jaar</param>
    ''' <param name="subAfd">String van de geselecteerde subafdeling</param>
    ''' <returns>Arralyst met het aantal cursussen gegroepeerd per jaar</returns>
    Public Function berekenVerwachtingsBereikVoorSubAfd(jaar As Integer, subAfd As String) As ArrayList
        Dim dao As New SubAfdDao
        Dim subAfdsAll = dao.getAantalCursussenPerJaarPerSubAfd(jaar, subAfd)
        Dim subAfdsNietGeschrapt = dao.getAantalNietGeschrapteCurussenPerJaarPerSubAfd(jaar, subAfd)
        Dim knownX = dao.getGekendeJarenPerSubAfd(jaar, subAfd)
        Dim knownY As New ArrayList
        For i As Integer = 0 To subAfdsAll.Count - 1
            knownY.Add(Math.Round((subAfdsNietGeschrapt(i) / subAfdsAll(i) * 100), 2))
        Next

        Dim p As New Prospect
        Dim pros = p.prospect(knownY, knownX, CDbl(2015))
        Dim range = p.certainty(knownY, pros)
        Return range
    End Function
End Class
