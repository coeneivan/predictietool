Public Class TestBLL
    Friend Shared Function GetAllCursForAllVar(f As String) As List(Of Cursus)
        Dim test As New TestDAO
        Return test.GetAllCursForAllVar(f)
    End Function

    Friend Shared Function GetAllCursForAllVarWithYear(f As String) As List(Of Cursus)
        Dim test As New TestDAO
        Return test.GetAllCursForAllVarWithYear(f)
    End Function
End Class
