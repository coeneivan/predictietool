Public Class TestBLL
    Public Shared Function GetAllCursForAllVar(f As String) As List(Of Cursus)
        Dim test As New TestDAO
        Return test.GetAllCursForAllVar(f)
    End Function

    Public Shared Function GetAllCursForAllVarWithYear(f As String) As List(Of Cursus)
        Dim test As New TestDAO
        Return test.GetAllCursForAllVarWithYear(f)
    End Function
End Class
