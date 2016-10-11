Public Class DagBll
    Private parent As ParameterParent
    Public Sub New()
        parent = New ParameterParent("dag")
    End Sub
    Public Function berekenVerwachtingsBereikVoorMerk(jaar As Integer, lesdag As String) As Bereik
        Return parent.berekenVerwachtingsBereik(jaar, lesdag)
    End Function
    Public Function getAll(jaar As Integer) As ArrayList
        Return parent.getAall(jaar)
    End Function
End Class
