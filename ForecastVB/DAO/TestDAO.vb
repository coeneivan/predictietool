Imports ForecastVB

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

        ' TODO: Datum beperking op finale versie verwijderen
        ' Tijdens ontwikkelen werd met een locale database gewerkt waar alle gegevens van werden afgehaald op onderstaande datum
        ' Om te voorkomen dat cursussen niet geschrapt stonden toen deze nog moesten worden gegeven hebben we onze datum beperkt tot het moment dat de database werd aangemaakt
        ' Datum moet veranderd worden naar de vandaag

        If Not f.Equals("") Then
            Dim vandaag = Date.Now
            query += "WHERE startdatum <  CAST('10-01-2016' AS DATETIME) AND " + f
        End If

        query += "group by "
        query += "Merk"
        query += ", UitvCentrumOmsch"
        query += ", Month(StartDatum)"
        query += ", YEAR(StartDatum)"
        query += ", dag"
        query += ", CodeSubafdeling "
        Dim sql As New SQLUtil
        Return sql.GetAllCursForAllVarWithYear(query)
    End Function

    Friend Function GetCursusByOpleidingsnummer(nr As Integer) As DataTable
        Dim sql As New SQLUtil
        Return sql.getAlles("SELECT *, month(startdatum) as maand FROM Cursussen WHERE [Opleidingsnr] = '" + nr.ToString + "'")
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
        query += "From SyntraTest.dbo.Cursussen "

        ' TODO: Datum beperking op finale versie verwijderen
        ' Tijdens ontwikkelen werd met een locale database gewerkt waar alle gegevens van werden afgehaald op onderstaande datum
        ' Om te voorkomen dat cursussen niet geschrapt stonden toen deze nog moesten worden gegeven hebben we onze datum beperkt tot het moment dat de database werd aangemaakt
        ' Datum moet veranderd worden naar de vandaag

        If Not f.Equals("") Then
            Dim vandaag = Date.Now
            query += "WHERE startdatum <  CAST('10-01-2016' AS DATETIME) AND " + f
        End If

        query += "group by "
        query += "Merk"
        query += ", UitvCentrumOmsch"
        query += ", Month(StartDatum)"
        query += ", dag"
        query += ", CodeSubafdeling "
        'query += "Having count(*) > 5"
        Dim sql As New SQLUtil
        Return sql.GetAllCursForAllVar(query)
    End Function
End Class
