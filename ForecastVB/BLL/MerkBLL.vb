Public Class MerkBLL
    Private parent As ParameterParent
    Public Sub New()
        parent = New ParameterParent("Merk")
    End Sub
    Public Function berekenVerwachtingsBereikVoorMerk(jaar As Integer, merk As String) As Bereik
        Return parent.berekenVerwachtingsBereik(jaar, merk)
    End Function
    Public Function getAll(jaar As Integer) As ArrayList
        Return parent.getAall(jaar)
    End Function
End Class
