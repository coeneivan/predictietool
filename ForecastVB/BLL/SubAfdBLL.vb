''' <summary>
''' Alle ophalingen en dergelijken ivm Dag
''' </summary>
Public Class subAfdBll
    Private parent As ParameterParent
    ''' <summary>
    ''' Initialiseren van klasse.
    ''' Maakt parent "wakker"
    ''' </summary>
    Public Sub New()
        parent = New ParameterParent("CodeSubafdeling")
    End Sub
    ''' <summary>
    ''' Geeft een inschatting van de realisatiegraad voor een bepaalde sub afdeling
    ''' </summary>
    ''' <param name="jaar">Integer tot welk jaar er gezocht moet worden</param>
    ''' <param name="subAfd">String met subafdeling waarvoor er waarde moet opgehaald worden</param>
    ''' <returns>Bereik</returns>
    Public Function berekenVerwachtingsBereikVoorSubAfd(jaar As Integer, subAfd As String, filters As ArrayList) As Bereik
        Return parent.berekenVerwachtingsBereik(jaar, subAfd, filters)
    End Function
    ''' <summary>
    ''' Geeft een arraylist weer met alle gekende subafdelingen
    ''' Ideaal voor in een Dropdownlist of dergelijken
    ''' </summary>
    ''' <param name="jaar">Tot welke jaar moet er gezocht worden?</param>
    ''' <returns>Arraylist met 1 kolom, de gekende subafdelingen</returns>
    Public Function getAallSubAfds(jaar As Integer, filters As ArrayList) As ArrayList
        parent = New ParameterParent("CodeSubafdeling")
        Return parent.getAall(jaar, filters)
    End Function

End Class
