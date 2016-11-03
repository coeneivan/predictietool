Imports ForecastVB

Public Class TestBLL
    Friend Shared Function GetAantalCursussenPerSubAfdelingPerJaarTotJaar(v As String, fil As String, j As Int16) As Dictionary(Of Integer, Parameter)
        Return TestDAO.GetAantalCursussenPerSubAfdelingPerJaarTotJaar(v, fil, j)
    End Function
    Friend Shared Function GetAantalCursussenPerSubAfdelingVoorJaar(s As String, fil As String, j As Int16) As Parameter
        Return TestDAO.GetAantalCursussenPerSubAfdelingVoorJaar(s, fil, j)
    End Function

    Friend Shared Function GetAantalCursussen(v As String, fil As String) As Integer
        Dim testDAO As New TestDAO
        Return testDAO.GetAantalCursussen(v)
    End Function

    Friend Shared Function GetAllCursForAllVar(f As String) As List(Of DataMiningPrediction2)
        Return TestDAO.GetAllCursForAllVar(f)
    End Function

    Friend Shared Function GetAllCursForAllVarWithYear(f As String) As List(Of DataMiningPrediction2)
        Return TestDAO.GetAllCursForAllVarWithYear(f)
    End Function
    Public Function GetAllCursForAllVarByOnt(f As String) As List(Of DataMiningPrediction2)
        Return TestDAO.GetAllCursForAllVarByOnt(f)
    End Function
    Public Function getALL(f As String) As List(Of Cursus)
        Dim test As New TestDAO
        Return test.ALL(f)
    End Function
End Class
