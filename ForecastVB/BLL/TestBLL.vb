Imports CursusPredictie
Public Class TestBLL
    Public Shared Function GetAllCursForAllVar(f As String) As List(Of Cursus)
        Dim test As New TestDAO
        Return test.GetAllCursForAllVar(f)
    End Function

    Public Shared Function GetAllCursForAllVarWithYear(f As String) As List(Of Cursus)
        Dim test As New TestDAO
        Return test.GetAllCursForAllVarWithYear(f)
    End Function

    Public Shared Sub GetCursusByOpleidingsnummer(nr As Integer, ByRef cursus As Cursus, ByRef startDatum As Date)
        Dim test As New TestDAO
        Dim curs = test.GetCursusByOpleidingsnummer(nr)

        If curs.Rows.Count <> 0 Then
            For Each row As DataRow In curs.Rows
                startDatum = row.Item("startdatum")
                cursus = New Cursus(row.Item("Merk"), row.Item("UitvCentrumOmsch"), row.Item("maand"), row.Item("dag"), row.Item("codeSubafdeling"), 1, 1, 1, 1, 1, Nothing, Nothing, False, "")
            Next
        Else
            Throw New ApplicationException("Opleidingsnummer werd niet teruggevonden")
        End If
    End Sub
End Class
