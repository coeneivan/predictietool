Public Class DatumBLL
    Private parent As ParameterParent
    Public Sub New()
        parent = New ParameterParent("Month(StartDatum)")
    End Sub
    ''' <summary>
    ''' Geeft een inschatting van de realisatiegraad voor een bepaalde maand
    ''' </summary>
    ''' <param name="jaar">Integer tot welk jaar er gezocht moet worden</param>
    ''' <param name="maand">String met maand waarvoor er waarde moet opgehaald worden</param>
    ''' <returns>Bereik</returns>
    Public Function berekenVerwachtingsBereikVoorDatum(jaar As Integer, maand As String) As Bereik
        Return parent.berekenVerwachtingsBereik(jaar, maand)
    End Function
End Class