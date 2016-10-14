Public Class FiltersBLL

    Public Function getKolomkopCursussen() As ArrayList
        Dim filtersDAO As New FiltersDAO
        Return filtersDAO.getKolomkopCursussen()
    End Function
End Class
