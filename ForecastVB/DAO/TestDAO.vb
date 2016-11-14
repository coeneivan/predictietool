Public Class TestDAO
    Public Function GetAllCursForAllVarWithYear(f As String) As List(Of Cursus)
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
            Dim vandaag = Date.Now
            query += "WHERE startdatum <  CAST('01/01/" + vandaag.Year.ToString + "' AS DATETIME) AND " + f
        End If

        query += "group by "
        query += "Merk"
        query += ", UitvCentrumOmsch"
        query += ", Month(StartDatum)"
        query += ", YEAR(StartDatum)"
        query += ", dag"
        query += ", CodeSubafdeling "
        Return getData(query)
    End Function
    Private Function getData(query As String)
        Dim sql As New SQLUtil
        Return sql.GetAllCursForAllVarWithYear(query)
    End Function
    Public Function GetAllCursForAllVar(f As String) As List(Of Cursus)
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
            Dim vandaag = Date.Now
            query += "WHERE startdatum <  CAST('01/01/" + vandaag.Year.ToString + "' AS DATETIME) AND " + f
        End If

        query += "group by "
        query += "Merk"
        query += ", UitvCentrumOmsch"
        query += ", Month(StartDatum)"
        query += ", YEAR(StartDatum)"
        query += ", dag"
        query += ", CodeSubafdeling "
        'query += "Having count(*) > 5" 
        Return getData(query)
    End Function
End Class
