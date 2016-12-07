Imports CursusPredictie

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
    Public Function getListExtraInfo(filters As ArrayList) As List(Of CursusExtraInfo)
        'COPY FROM TestDao
        Dim query As String = ""
        query += "Select"
        query += "[Opleidingsnr]"
        query += ", [OmschrijvingComm]"
        query += ", [StartDatum]"
        query += ", [dag]"
        query += ", [EindDatum]"
        query += ", [TotalePrijs]"
        query += ", [Merk]"
        query += ", [UitvCentrumOmsch]"
        query += ", [Aard]"
        query += ", [CaM]"
        query += ", [CuB]"
        query += ", [OpC]"
        query += ", [Ont]"
        query += ", [CoC]"
        query += ", [CodeSubafdeling]"
        query += ", [CodeIngetrokken]"
        query += ", [Lesplaats]"
        query += ", [OpInternet]"
        query += ", [LesroosterGevalideerd]"
        query += ", [AtlCursisten]"

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

        'TODO: in nieuwe classe steken
        Dim sql As New SQLUtil
        Dim results As DataTable = sql.getAlles(query)

        Dim theList As New List(Of CursusExtraInfo)

        For Each row As DataRow In results.Rows
            Dim ont As String
            Dim einddatum As String
            Dim aard As String
            If IsDBNull(row.Item("ont")) Then
                ont = "NIEMAND"
            Else
                ont = row.Item("ont")
            End If
            If IsDBNull(row.Item("EindDatum")) Then
                einddatum = " "
            Else
                einddatum = row.Item("EindDatum")
            End If
            If IsDBNull(row.Item("Aard")) Then
                aard = " "
            Else
                aard = row.Item("Aard")
            End If
            Dim cam As String
            If IsDBNull(row.Item("CaM")) Then
                cam = " "
            Else
                cam = row.Item("CaM")
            End If
            Dim CuB As String

            If IsDBNull(row.Item("CuB")) Then
                CuB = " "
            Else
                CuB = row.Item("CuB")
            End If
            Dim OpC As String
            If IsDBNull(row.Item("OpC")) Then
                OpC = " "
            Else
                OpC = row.Item("OpC")
            End If
            Dim CoC As String
            If IsDBNull(row.Item("CoC")) Then
                CoC = " "
            Else
                CoC = row.Item("CoC")
            End If
            Dim Lesplaats As String
            If IsDBNull(row.Item("Lesplaats")) Then
                Lesplaats = " "
            Else
                Lesplaats = row.Item("Lesplaats")
            End If
            Dim OpInternet As String
            If IsDBNull(row.Item("OpInternet")) Then
                OpInternet = " "
            Else
                OpInternet = row.Item("OpInternet")
            End If
            Dim LesroosterGevalideerd As String
            If IsDBNull(row.Item("LesroosterGevalideerd")) Then
                LesroosterGevalideerd = " "
            Else
                LesroosterGevalideerd = row.Item("LesroosterGevalideerd")
            End If
            Dim AtlCursisten As String
            If IsDBNull(row.Item("AtlCursisten")) Then
                AtlCursisten = " "
            Else
                AtlCursisten = row.Item("AtlCursisten")
            End If

            Dim c As New CursusExtraInfo(row.Item("Opleidingsnr"), row.Item("OmschrijvingComm"), row.Item("dag"),
                                         row.Item("StartDatum"), einddatum, row.Item("TotalePrijs"), row.Item("Merk"),
                                         row.Item("UitvCentrumOmsch"), aard, cam, CuB, OpC,
                                         ont, CoC, row.Item("CodeSubafdeling"), row.Item("CodeIngetrokken"), Lesplaats,
                                         OpInternet, LesroosterGevalideerd, AtlCursisten)
            theList.Add(c)
        Next row

        Return theList
    End Function
End Class