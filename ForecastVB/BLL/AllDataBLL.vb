Public Class AllDataBLL
    Private all As AllDataDAO
    Public Sub New()
        all = New AllDataDAO
    End Sub
    Public Function getPercentageJa(jaar As Integer, parameter As String, parametervalue As String, filters As ArrayList) As Double
        Return (all.getAantalJa(jaar, parameter, parametervalue, filters) / all.getTotaalAantalJa(jaar, filters))
    End Function
    Public Function getPErcentageNee(jaar As Integer, parameter As String, parametervalue As String, filters As ArrayList) As Double
        Return (all.getAantalNee(jaar, parameter, parametervalue, filters) / all.getTotaalAantalNee(jaar, filters))
    End Function
    Public Function getAllJa(jaar As Integer, filters As ArrayList)
        Return all.getTotaalAantalJa(jaar, filters)
    End Function
    Public Function getAllNee(jaar As Integer, filters As ArrayList)
        Return all.getTotaalAantalNee(jaar, filters)
    End Function
    Public Function getTotaalAantal(jaar As Integer, filters As ArrayList)
        Return all.getTotaalAantal(jaar, filters)
    End Function
End Class