Public Class AllDataDAO
    Public Function getAantalJa(jaar As Integer, parameter As String, parameterValue As String, filters As ArrayList) As Double
        Return getAantalJaNee("Ja", jaar, parameter, parameterValue, filters)
    End Function
    Public Function getAantalNee(jaar As Integer, parameter As String, parameterValue As String, filters As ArrayList) As Double
        Return getAantalJaNee("Nee", jaar, parameter, parameterValue, filters)
    End Function
    Public Function getTotaalAantalJa(jaar As Integer, filters As ArrayList) As Double
        Return getTotaalAantalJaNee("Ja", jaar, filters)
    End Function
    Public Function getTotaalAantalNee(jaar As Integer, filters As ArrayList) As Double
        Return getTotaalAantalJaNee("Nee", jaar, filters)
    End Function
    Private Function getAantalJaNee(janee As String, jaar As Integer, parameter As String, parameterValue As String, filters As ArrayList) As Double
        Dim s As New SQLUtil
        If filters Is Nothing Then
            Return CDbl(s.getArrayList("SELECT count(*) FROM [SyntraTest].[dbo].[Cursussen] where codeingetrokken ='" + janee + "' AND " + parameter + " = '" + parameterValue + "' AND year(startdatum) < " + jaar.ToString)(0))
        Else
            Dim fil As String
            fil = ""

            For i As Integer = 0 To filters.Count - 1
                Dim filIt As FilterItem
                filIt = filters.Item(i)

                fil += " And "
                fil += filIt.kolom + " " + filIt.factor + " " + filIt.filter
            Next
            Return CDbl(s.getArrayList("Select count(*)  FROM [SyntraTest].[dbo].[Cursussen] WHERE codeingetrokken ='" + janee + "' " + fil + " AND " + parameter + " = '" + parameterValue + "' AND year(startdatum) < " + jaar.ToString)(0))
        End If
    End Function
    Private Function getTotaalAantalJaNee(janee As String, jaar As Integer, filters As ArrayList) As Double
        Dim s As New SQLUtil
        If filters Is Nothing Then
            Return CDbl(s.getArrayList("SELECT count(*)  FROM [SyntraTest].[dbo].[Cursussen] where codeingetrokken ='" + janee + "' AND year(startdatum) < " + jaar.ToString)(0))
        Else
            Dim fil As String
            fil = ""

            For i As Integer = 0 To filters.Count - 1
                Dim filIt As FilterItem
                filIt = filters.Item(i)

                fil += " AND "
                fil += filIt.kolom + " " + filIt.factor + " " + filIt.filter
            Next
            Return CDbl(s.getArrayList("SELECT distinct count(*) FROM [SyntraTest].[dbo].[Cursussen] where codeingetrokken ='" + janee + "'  " + fil + " AND year(startdatum) < " + jaar.ToString + " " + fil)(0))
        End If
    End Function
    Public Function getTotaalAantal(jaar As Integer, filters As ArrayList) As Double
        Dim s As New SQLUtil
        If filters Is Nothing Then
            Return CDbl(s.getArrayList("SELECT count(*)  FROM [SyntraTest].[dbo].[Cursussen] where year(startdatum) < " + jaar.ToString)(0))
        Else
            Dim fil As String
            fil = ""

            For i As Integer = 0 To filters.Count - 1
                Dim filIt As FilterItem
                filIt = filters.Item(i)

                fil += " AND "
                fil += filIt.kolom + " " + filIt.factor + " " + filIt.filter
            Next
            Return CDbl(s.getArrayList("SELECT distinct count(*) FROM [SyntraTest].[dbo].[Cursussen] where year(startdatum) < " + jaar.ToString + " " + fil)(0))
        End If
    End Function
End Class
