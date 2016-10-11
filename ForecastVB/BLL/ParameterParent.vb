Public Class ParameterParent
    Private parameternaam As String
    Public Sub New(pParameternaam As String)
        parameternaam = pParameternaam
    End Sub
    Public Function getAall(jaar As Integer) As ArrayList
        Dim dao As New ParametersDAO
        Return  dao.getAll(jaar, parameternaam)
    End Function
    Public Function berekenVerwachtingsBereik(jaar As Integer, parameterwaarde As String) As Bereik
        Dim dao As New ParametersDAO
        Dim all = dao.getCursussen(jaar, parameternaam, parameterwaarde)
        Dim p As New Prospect
        Dim pros = p.prospect(all, jaar)
        Dim range = p.certainty(all, pros)
        Return range
    End Function
End Class
