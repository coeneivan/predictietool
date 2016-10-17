Imports System.IO
Imports Microsoft.VisualBasic.FileIO

Public Class MainScreen
    Private Const jaar = 2015
    Private Shared filters As New ArrayList
    Private filterlist As ArrayList
    Private saveDirectory As String = SpecialDirectories.MyDocuments + "//Predictie Filters//"
    Private Sub MainScreen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Load all cursussen
        Dim subafds As New subAfdBll
        cboSubAfd.Items.AddRange(subafds.getAallSubAfds(jaar, filters).ToArray)

        'Load dagen
        cboLesdag.Items.AddRange({"Maandag", "Dinsdag", "Woensdag", "Donderdag", "Vrijdag", "Zaterdag", "Zondag"})

        'Load merken
        Dim merken As New MerkBLL
        cboMerk.Items.AddRange(merken.getAll(jaar, filters).ToArray)

        'Hardcode test
        Dim knownX, knownY As New ArrayList
        Dim dictionary As New Dictionary(Of String, Parameter)
        dictionary.Add("2006", New Parameter(100, 92.31))
        dictionary.Add("2007", New Parameter(100, 90))
        dictionary.Add("2008", New Parameter(100, 77.78))
        dictionary.Add("2009", New Parameter(100, 68.18))
        dictionary.Add("2010", New Parameter(100, 53.13))
        dictionary.Add("2011", New Parameter(100, 48))
        dictionary.Add("2012", New Parameter(100, 47.62))
        dictionary.Add("2013", New Parameter(100, 73.68))
        dictionary.Add("2014", New Parameter(100, 48.15))

        Dim p As New Prospect
        Dim pros = p.prospect(dictionary, CDbl(jaar))
        Dim range = p.certainty(dictionary, pros)
        txtRestultJaar.Text = range.ToString

        Try
            filterlist = New ArrayList
            cboFiltersList.Items.Clear()
            Dim filterFiles As String() = Directory.GetFiles(saveDirectory)
            For Each file As String In filterFiles
                Dim filterNames As String = System.IO.Path.GetFileNameWithoutExtension(file)
                filterlist.Add(filterNames)
            Next
            cboFiltersList.Items.AddRange(filterlist.ToArray)
        Catch ex As Exception
            'TODO: catch it!
        End Try
    End Sub

    Private Sub cboSubAfd_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSubAfd.SelectedIndexChanged
        Dim subafd As New subAfdBll
        txtResultSubAfd.Text = subafd.berekenVerwachtingsBereikVoorSubAfd(jaar, cboSubAfd.SelectedItem, filters).ToString
    End Sub

    Private Sub cboMerk_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboMerk.SelectedIndexChanged
        Dim merken As New MerkBLL
        txtResultMerk.Text = merken.berekenVerwachtingsBereikVoorMerk(jaar, cboMerk.SelectedItem, filters).ToString
    End Sub

    Private Sub cboLesdag_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboLesdag.SelectedIndexChanged
        Dim dag As New DagBll
        txtRestultLesDag.Text = dag.berekenVerwachtingsBereikVoorDag(jaar, cboLesdag.SelectedItem, filters).ToString
    End Sub

    Private Sub dtpStartcursus_ValueChanged(sender As Object, e As EventArgs) Handles dtpStartcursus.ValueChanged
        Dim datum As New DatumBLL
        txtResultDatum.Text = datum.berekenVerwachtingsBereikVoorDatum(jaar, dtpStartcursus.Value.Month.ToString, filters).ToString
    End Sub

    Private Sub btnFilter_Click(sender As Object, e As EventArgs) Handles btnFilter.Click
        Dim settings As New Settings(Me)
        settings.Show()
    End Sub

    Public Sub addFilters(filters As ArrayList)
        filters.AddRange(filters)
    End Sub
    Public Sub addFilter(filter As FilterItem)
        filters.Add(filter)
    End Sub
    Public Function getFilters() As ArrayList
        Return filters
    End Function
    Public Sub setFilterlist(fl As ArrayList)
        filterlist = fl
    End Sub
    Public Function getFilterList() As ArrayList
        Return filterlist
    End Function
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim t As New Test
        t.Show()
    End Sub

    Private Sub cboFiltersList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboFiltersList.SelectedIndexChanged
        Dim j As New JSONParser
        readFilterFile(New ArrayList(j.read(saveDirectory + cboFiltersList.SelectedItem.ToString() + ".json")))
    End Sub
    Private Sub readFilterFile(filters As ArrayList)
        filters.Clear()
        For Each f As FilterItem In filters
            filters.Add(f)
        Next
    End Sub


    ' TODO Filters laten werken op berekende resultaat
End Class