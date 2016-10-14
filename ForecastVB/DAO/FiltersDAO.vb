
Public Class FiltersDAO

    Private tabelNaam = "dbo.Cursussen" 'De tabel naam waarin de kolomen moeten worden gezocht

    Public Function getKolomkopCursussen() As ArrayList
        Dim sqlUtil As New SQLUtil
        Return sqlUtil.getArrayList("SELECT name FROM Sys.columns WHERE object_id = OBJECT_ID('" + tabelNaam + "');")
    End Function
End Class
