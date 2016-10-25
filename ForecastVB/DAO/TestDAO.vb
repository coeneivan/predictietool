Imports ForecastVB

Public Class TestDAO
    Friend Shared Function GetAantalCursussenPerSubAfdelingPerJaarTotJaar(v As String, fil As String, j As Int16) As Dictionary(Of Integer, Parameter)
        Dim script As String = "Select year(StartDatum) "
        script += ", count(*) as totaal "
        script += ", sum(CASE when CodeIngetrokken = 'Ja' then 0 else 1 end) as doorgegaan "
        script += "from SyntraTest.dbo.Cursussen "
        script += "where CodeSubafdeling = '" + v + "' "
        script += "and year(StartDatum) < 2015"
        script += fil + " "
        script += "group by year(StartDatum) "

        Dim sql As New SQLUtil
        Return sql.getDictionaryWithInteger(script)
    End Function

    Friend Shared Function GetAantalCursussenPerSubAfdelingVoorJaar(s As String, fil As String, j As Int16) As Parameter
        Dim script As String = "Select year(StartDatum) "
        script += ", count(*) as totaal "
        script += ", sum(CASE when CodeIngetrokken = 'Ja' then 0 else 1 end) as doorgegaan "
        script += "from SyntraTest.dbo.Cursussen "
        script += "where CodeSubafdeling = '" + s + "' "
        script += "and year(StartDatum) < 2015"
        script += fil + " "
        script += "group by year(StartDatum) "

        Dim sql As New SQLUtil
        Return sql.getParameterForYear(script)
    End Function

    Friend Shared Function GetAllCursForAllVar(s As String) As List(Of DataMiningPrediction2)
        Dim query As String = ""
        query += "Select Distinct Merk"
        query += ", UitvCentrumOmsch"
        query += ", Month(StartDatum) as Maand"
        query += ", dag as Dag"
        query += ", CodeSubafdeling"
        query += ", count(*) as totaal"
        query += ", SUM(CASE WHEN CodeIngetrokken='Nee' THEN 1 ELSE 0 END) as doorgegaan "
        query += "From Cursussen "

        If Not s.Equals("") Then
            query += "WHERE YEAR(Startdatum) < 2015 and " + s
        End If

        query += "group by "
        query += "Merk"
        query += ", UitvCentrumOmsch"
        query += ", Month(StartDatum)"
        query += ", dag"
        query += ", CodeSubafdeling "
        query += "Having count(*) > 5"

        Dim sql As New SQLUtil
        Return Sql.GetAllCursForAllVar(query)
    End Function

    Friend Function GetAantalCursussen(v As String) As Integer
        Throw New NotImplementedException()
    End Function

    Public Function GetAantalCursussen(v As String, fil As String) As Integer
        Dim script As String = "Select count(*) As totaal "
        script += "From SyntraTest.dbo.Cursussen "
        script += "Where CodeSubafdeling = '" + v + "' "
        script += fil + " "
        script += "group by CodeSubafdeling"

        Dim sql As New SQLUtil
        Return sql.getCount(script)
    End Function
End Class
