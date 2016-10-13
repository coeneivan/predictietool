''' <summary>
''' Alle ophalingen en dergelijken voor alle parameters 
''' </summary>
Public Class ParameterParent
    Private parameternaam As String
    ''' <summary>
    ''' Initialisaitie van klasse
    ''' </summary>
    ''' <param name="pParameternaam">String met de naam van de paramater</param>
    Public Sub New(pParameternaam As String)
        parameternaam = pParameternaam
    End Sub
    ''' <summary>
    ''' Geeft een arraylist weer met de data van de gekozen paramater
    ''' Ideaal voor in een Dropdownlist of dergelijken
    ''' </summary>
    ''' <param name="jaar">Tot welke jaar moet er gezocht worden?</param>
    ''' <returns>Arraylist met 1 kolom, de gekende data</returns>
    Public Function getAall(jaar As Integer) As ArrayList
        Dim dao As New ParametersDAO
        Return dao.getAll(jaar, parameternaam)
    End Function
    ''' <summary>
    ''' Geeft een inschatting van de realisatiegraad voor een bepaalde parameter
    ''' </summary>
    ''' <param name="jaar">Integer tot welk jaar er gezocht moet worden</param>
    ''' <param name="parameterwaarde">String met parameterwaarde waarvoor er waarde moet opgehaald worden</param>
    ''' <returns></returns>
    Public Function berekenVerwachtingsBereik(jaar As Integer, parameterwaarde As String) As Bereik
        Dim dao As New ParametersDAO
        Dim all = dao.getCursussen(jaar, parameternaam, parameterwaarde, Nothing)
        Dim p As New Prospect
        Dim pros = p.prospect(all, jaar)
        Dim range = p.certainty(all, pros)
        Return range
    End Function
End Class
