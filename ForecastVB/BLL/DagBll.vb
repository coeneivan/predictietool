''' <summary>
''' Alle ophalingen en dergelijken ivm Dag
''' </summary>
Public Class DagBll
    Private parent As ParameterParent
    ''' <summary>
    ''' Initialiseren van klasse.
    ''' Maakt parent "wakker"
    ''' </summary>
    Public Sub New()
        parent = New ParameterParent("dag")
    End Sub
    ''' <summary>
    ''' Geeft een inschatting van de realisatiegraad voor een bepaalde dag
    ''' </summary>
    ''' <param name="jaar">Integer tot welk jaar er gezocht moet worden</param>
    ''' <param name="lesdag">String met dag waarvoor er waarde moet opgehaald worden</param>
    ''' <returns>Bereik</returns>
    Public Function berekenVerwachtingsBereikVoorMerk(jaar As Integer, lesdag As String) As Bereik
        Return parent.berekenVerwachtingsBereik(jaar, lesdag)
    End Function
    ''' <summary>
    ''' Geeft een arraylist weer met alle gekende dagen
    ''' Ideaal voor in een Dropdownlist of dergelijken
    ''' </summary>
    ''' <param name="jaar">Tot welke jaar moet er gezocht worden?</param>
    ''' <returns>Arraylist met 1 kolom, de gekende dagen</returns>
    Public Function getAll(jaar As Integer) As ArrayList
        Return parent.getAall(jaar)
    End Function
End Class
