Imports System.IO
Imports Microsoft.VisualBasic.FileIO

Public Class MainScreen
    Private Const jaar = 2015 'TODO: veranderen naar gewenste jaar
    Private filters As New ArrayList
    Private filterlist As ArrayList
    Private selectedFilterList As String
    Private saveDirectory As String = SpecialDirectories.MyDocuments + "//Predictie Filters//"
    Private m, d, s, sd As Double
    Private Sub MainScreen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Load all cursussen
        Dim subafds As New subAfdBll
        cboSubAfd.Items.AddRange(subafds.getAallSubAfds(jaar, filters).ToArray)

        'Load dagen
        cboLesdag.Items.AddRange({"Maandag", "Dinsdag", "Woensdag", "Donderdag", "Vrijdag", "Zaterdag", "Zondag"})

        'Load merken
        Dim merken As New MerkBLL
        cboMerk.Items.AddRange(merken.getAll(jaar, filters).ToArray)

        refreshFilterList()
    End Sub
    Public Sub refreshFilterList()
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
        selectedFilterList = My.Settings.selectedFilterList
        cboFiltersList.SelectedItem = selectedFilterList
    End Sub
    Private Sub cboSubAfd_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSubAfd.SelectedIndexChanged
        Dim subafd As New subAfdBll
        Dim sb = subafd.berekenVerwachtingsBereikVoorSubAfd(jaar, cboSubAfd.SelectedItem, filters)
        txtResultSubAfd.Text = sb.ToString()
        s = sb.getAvg
    End Sub

    Private Sub cboMerk_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboMerk.SelectedIndexChanged
        Dim merken As New MerkBLL
        Dim mb = merken.berekenVerwachtingsBereikVoorMerk(jaar, cboMerk.SelectedItem, filters)
        txtResultMerk.Text = mb.ToString
        m = mb.getAvg
    End Sub

    Private Sub cboLesdag_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboLesdag.SelectedIndexChanged
        Dim dag As New DagBll
        Dim db = dag.berekenVerwachtingsBereikVoorDag(jaar, cboLesdag.SelectedItem, filters)
        txtRestultLesDag.Text = db.ToString
        d = db.getAvg.ToString
    End Sub

    Private Sub dtpStartcursus_ValueChanged(sender As Object, e As EventArgs) Handles dtpStartcursus.ValueChanged
        Dim datum As New DatumBLL
        Dim sdb = datum.berekenVerwachtingsBereikVoorDatum(jaar, dtpStartcursus.Value.Month.ToString, filters)
        txtResultDatum.Text = sdb.ToString
        sd = sdb.getAvg
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
        Dim t As New Test(Me)
        t.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        txtTotaal.Text = ((d * 0.4846 / 100) * (m * 0.4547 / 100) * (s * 0.5541 / 100) * (sd * 0.538 / 100) * 100).ToString
    End Sub

    Public Function getSelectedList() As String
        Return selectedFilterList
    End Function

    Private Sub cboFiltersList_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboFiltersList.SelectedValueChanged
        Dim j As New JSONParser
        filters = j.read(saveDirectory + cboFiltersList.SelectedItem.ToString() + ".json")
        My.Settings.selectedFilterList = cboFiltersList.SelectedItem
        My.Settings.Save()
    End Sub

End Class