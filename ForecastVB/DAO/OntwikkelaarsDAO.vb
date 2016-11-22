Public Class OntwikkelaarsDAO
    Public Function getList(filters As ArrayList) As List(Of Cursus)
        'COPY FROM TestDao
        Dim query As String = ""
        query += "Select Distinct upper(ont) as ont"
        query += ", merk"
        query += ", UitvCentrumOmsch"
        query += ", upper(CodeSubafdeling) as CodeSubafdeling"
        query += ", count(*) as totaal"
        query += ", SUM(CASE WHEN CodeIngetrokken='Nee' THEN 1 ELSE 0 END) as doorgegaan "
        'query += ", YEAR(StartDatum) as Jaar "
        query += "From SyntraTest.dbo.Cursussen "

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
        query += ", UitvCentrumOmsch"
        query += ", CodeSubafdeling "
        Dim sql As New SQLUtil
        Dim results As DataTable = sql.getAlles(query)

        Dim theList As New List(Of Cursus)

        For Each row As DataRow In results.Rows
            Dim ont As String
            Try
                ont = row.Item("ont")
            Catch ex As InvalidCastException
                'Als het niet lukt om waarde toe te kennen is waarde null
                ont = "Niemand"
            End Try

            Dim cursus As New Cursus(row.Item("Merk"), row.Item("UitvCentrumOmsch"), row.Item("codeSubafdeling"), row.Item("totaal"), row.Item("doorgegaan"), ont)
            theList.Add(cursus)
        Next row

        Return theList
    End Function
End Class