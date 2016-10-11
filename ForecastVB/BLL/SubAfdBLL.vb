Public Class subAfdBll
    Private parent As ParameterParent
    Public Sub New()
        parent = New ParameterParent("CodeSubafdeling")
    End Sub
    Public Function berekenVerwachtingsBereikVoorSubAfd(jaar As Integer, subAfd As String) As Bereik
        Return parent.berekenVerwachtingsBereik(jaar, subAfd)
    End Function

    Public Function getAallSubAfds(jaar As Integer) As ArrayList
        parent = New ParameterParent("CodeSubafdeling")
        Return parent.getAall(jaar)
    End Function

End Class
