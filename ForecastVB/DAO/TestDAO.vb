Imports ForecastVB
'TODO: clean up!
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

    Public Function ALL(f As String) As List(Of Cursus)
        Dim query As String
        query = "SELECT [Opleidingsnr], [dag],[StartDatum] ,[Merk] ,[UitvCentrumOmsch] ,[CodeAnalytischPlanSubafdeling] ,[CodeIngetrokken]"
        query += " FROM Cursussen"
        query += " WHERE " + f
        query += " AND year(startdatum)<2016 "
        Dim sql As New SQLUtil
        Dim data = sql.getAlles(query)
        Dim theList As New List(Of Cursus)

        For Each row As DataRow In data.Rows
            Dim cursus As New Cursus()
            cursus.nummer = row.Item("Opleidingsnr")
            cursus.datum = row.Item("StartDatum")
            cursus.lesdag = row.Item("dag")
            cursus.merkVanCursus = row.Item("Merk")
            cursus.uitvoerendCentrum = row.Item("UitvCentrumOmsch")
            cursus.codeSubafdeling = row.Item("CodeAnalytischPlanSubafdeling")
            cursus.codeIngetrokken = row.Item("CodeIngetrokken") = "Ja"
            theList.Add(cursus)
        Next row

        Return theList
    End Function

    Friend Shared Function GetAllCursForAllVarWithYear(f As String) As List(Of DataMiningPrediction2)
        Dim query As String = ""
        query += "Select Distinct Merk"
        query += ", UitvCentrumOmsch"
        query += ", Month(StartDatum) as Maand"
        query += ", dag as Dag"
        query += ", [CodeSubafdeling]"
        query += ", count(*) as totaal"
        query += ", SUM(CASE WHEN CodeIngetrokken='Nee' THEN 1 ELSE 0 END) as doorgegaan "
        query += ", YEAR(StartDatum) as Jaar "
        query += "From SyntraTest.dbo.Cursussen "

        If Not f.Equals("") Then
            query += "WHERE startdatum < CAST('2016-10-01' AS DATETIME) AND " + f
        End If

        query += "group by "
        query += "Merk"
        query += ", UitvCentrumOmsch"
        query += ", Month(StartDatum)"
        query += ", YEAR(StartDatum)"
        query += ", dag"
        query += ", CodeSubafdeling "
        'query += " Having "
        'query += "SUM(case when year(StartDatum) = 2016 then 1 else 0 end) <> 0"
        'query += " And SUM(case when year(StartDatum) = 2015 then 1 else 0 end) <> 0"
        'query += " And SUM(case when year(StartDatum) = 2014 then 1 else 0 end) <> 0"
        'query += " And SUM(case when year(StartDatum) = 2013 then 1 else 0 end) <> 0"

        Dim sql As New SQLUtil
        Return sql.GetAllCursForAllVarWithYear(query)
    End Function

    Friend Shared Function GetAllCursForAllVar(s As String) As List(Of DataMiningPrediction2)
        Dim query As String = ""
        query += "Select Distinct Merk"
        query += ", UitvCentrumOmsch"
        query += ", Month(StartDatum) as Maand"
        query += ", Dag as Dag"
        query += ", [CodeSubafdeling]"
        query += ", count(*) as totaal"
        query += ", SUM(CASE WHEN CodeIngetrokken='Nee' THEN 1 ELSE 0 END) as doorgegaan "
        query += "From Cursussen "

        If Not s.Equals("") Then
            query += "WHERE startdatum < CAST('2016-10-01' AS DATETIME) AND " + s 'TODO: 2016 automatisch aanpassen
        End If

        query += "group by "
        query += "Merk"
        query += ", UitvCentrumOmsch"
        query += ", Month(StartDatum)"
        query += ", Dag"
        query += ", [CodeSubafdeling] "
        query += "Having count(*) > 5"
        'query += " and SUM(case when year(StartDatum) = 2016 then 1 else 0 end) <> 0"
        'query += " And SUM(case when year(StartDatum) = 2015 then 1 else 0 end) <> 0"
        'query += " And SUM(case when year(StartDatum) = 2014 then 1 else 0 end) <> 0"
        'query += " And SUM(case when year(StartDatum) = 2013 then 1 else 0 end) <> 0"
        Dim sql As New SQLUtil
        Return sql.GetAllCursForAllVar(query)
    End Function

    Friend Shared Function GetAllCursForAllVarByOnt(s As String) As List(Of DataMiningPrediction2)
        Dim query As String = ""
        query += "Select Ont"
        query += ", Merk"
        query += ", CodeSubafdeling"
        query += ", (CASE WHEN CodeIngetrokken='Nee' THEN 1 ELSE 0 END) as ingetrokken"
        query += ", YEAR(Startdatum) as jaar"
        query += " From Cursussen "

        If Not s.Equals("") Then
            query += "WHERE YEAR(Startdatum) <2015 AND " + s
        End If
        query += " AND ont is not null "

        Dim sql As New SQLUtil
        Return sql.GetAllCursForAllVarWithOnt(query)
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
