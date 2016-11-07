Public Class FiltersBLL
    ''' <summary>
    ''' Geeft kolom koppen terug 
    ''' </summary>
    ''' <returns>Arraylist met alle namen van de kolommen</returns>
    Public Function getKolomkopCursussen() As ArrayList
        Dim filtersDAO As New FiltersDAO
        Return filtersDAO.getKolomkopCursussen()
    End Function
End Class
