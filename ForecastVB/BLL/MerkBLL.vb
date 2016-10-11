''' <summary>
''' Alle ophalingen en dergelijken ivm Merk
''' </summary>
Public Class MerkBLL
    Private parent As ParameterParent
    ''' <summary>
    ''' Initialiseren van klasse.
    ''' Maakt parent "wakker"
    ''' </summary>
    Public Sub New()
        parent = New ParameterParent("Merk")
    End Sub
    ''' <summary>
    ''' Geeft een inschatting van de realisatiegraad voor een bepaalde merk
    ''' </summary>
    ''' <param name="jaar">Integer tot welk jaar er gezocht moet worden</param>
    ''' <param name="merk">String met de merk waarvoor er waarde moet opgehaald worden</param>
    ''' <returns>Bereik</returns>
    Public Function berekenVerwachtingsBereikVoorMerk(jaar As Integer, merk As String) As Bereik
        Return parent.berekenVerwachtingsBereik(jaar, merk)
    End Function
    ''' <summary>
    ''' Geeft een arraylist weer met alle gekende merken
    ''' Ideaal voor in een Dropdownlist of dergelijken
    ''' </summary>
    ''' <param name="jaar">Tot welke jaar moet er gezocht worden?</param>
    ''' <returns>Arraylist met 1 kolom, de gekende merken</returns>
    Public Function getAll(jaar As Integer) As ArrayList
        Return parent.getAall(jaar)
    End Function
End Class
