Public Class OntwikkelaarsDAO
    Public Function getList(filters As ArrayList) As List(Of Cursus)
        'COPY FROM TestDao
        Dim query As String = ""
        query += "Select Distinct upper(ont) as ont"
        query += ", merk"
        query += ", UitvCentrumOmsch"
        query += ", upper(CodeSubafdeling) as CodeSubafdeling"
        query += ", count(*) as totaal"
        query += ", Month(Startdatum) as maand"
        query += ", SUM(CASE WHEN CodeIngetrokken='Nee' THEN 1 ELSE 0 END) as doorgegaan "
        'query += ", YEAR(StartDatum) as Jaar "
        query += "From SyntraTest.dbo.Cursussen "

        ' TODO: Datum beperking op finale versie verwijderen
        ' Tijdens ontwikkelen werd met een locale database gewerkt waar alle gegevens van werden afgehaald op onderstaande datum
        ' Om te voorkomen dat cursussen niet geschrapt stonden toen deze nog moesten worden gegeven hebben we onze datum beperkt tot het moment dat de database werd aangemaakt
        ' Datum moet veranderd worden naar de vandaag

        Dim vandaag = Date.Now
        query += "WHERE startdatum <  CAST('10-01-" + vandaag.Year.ToString + "' AS DATETIME) "
        Dim f As String = ""

        For Each fi In filters
            f += " AND " + fi.ToString
        Next

        If Not f.Equals("") Then
            query += f
        End If

        query += " group by "
        query += " ont"
        query += ", Merk"
        query += ", Month(startdatum)"
        query += ", UitvCentrumOmsch"
        query += ", CodeSubafdeling "
        Dim sql As New SQLUtil
        Dim results As DataTable = sql.getAlles(query)

        Dim theList As New List(Of Cursus)

        For Each row As DataRow In results.Rows
            Dim ont As String

            If IsDBNull(row.Item("ont")) Then
                ont = "NIEMAND"
            Else
                ont = row.Item("ont")
            End If

            Dim cursus As New Cursus(row.Item("Merk"), row.Item("UitvCentrumOmsch"), row.Item("maand"), "", row.Item("codeSubafdeling"), row.Item("totaal"), row.Item("doorgegaan"), -1, -1, -1, Nothing, Algoritmes.Niets,
                                     False, ont)
            theList.Add(cursus)
        Next row

        Return theList
    End Function
End Class