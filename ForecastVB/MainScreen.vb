Imports System.IO
Imports Microsoft.VisualBasic.FileIO

Public Class MainScreen
    Private Const jaar = 2015 'TODO: veranderen naar gewenste jaar
    Private filters As New ArrayList
    Private filterlist As ArrayList
    Private selectedFilterList As String
    Private saveDirectory As String = SpecialDirectories.MyDocuments + "//Predictie Filters//"
    Private m, d, s, sd, c As Double
    Private Sub MainScreen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Load all cursussen
        Dim subafds As New subAfdBll
        cboSubAfd.Items.AddRange(subafds.getAallSubAfds(jaar, filters).ToArray)
        'Load dagen
        cboLesdag.Items.AddRange({"Maandag", "Dinsdag", "Woensdag", "Donderdag", "Vrijdag", "Zaterdag", "Zondag"})

        'Load merken
        Dim merken As New MerkBLL
        cboMerk.Items.AddRange(merken.getAll(jaar, filters).ToArray)

        Dim para As New ParameterParent("uitvCentrumOmsch")
        cboUitvCent.Items.AddRange(para.getAall(jaar, filters).ToArray)
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

    Private Sub cboUitvCent_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboUitvCent.SelectedIndexChanged
        Dim centrum As New ParameterParent("UitvCentrumOmsch")
        Dim cb = centrum.berekenVerwachtingsBereik(jaar, cboUitvCent.SelectedItem, filters)
        txtResultCentrum.Text = cb.ToString
        c = cb.getAvg
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim t As New Test(Me)
        t.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim sql As New SQLUtil
        Dim sqlcommand = "SELECT YEAR(c.startdatum) as jaar,count(*) as totaal,(SELECT count(*) FROM [SyntraTest].[dbo].[Cursussen] as cc WHERE cc.CodeIngetrokken = 'nee'  AND year(cc.StartDatum) = year(c.StartDatum)) as nietGeschrapt FROM [SyntraTest].[dbo].[Cursussen] as c WHERE  year(c.StartDatum) < 2015 GROUP BY year(c.startDatum)"
        Dim a = sql.getDictionary(sqlcommand)
        Dim p As New Prospect
        Dim pros = p.prospect(a, 2015)


        ' TODO Wegings factor aanpassen, yes bij kollom is aantal keer dat het resultaat ja was
        ' http://www.cs.ccsu.edu/~markov/ccsu_courses/DataMining-8.html
        ' hoeveel keer was resultaat ja als outlook sunny was? 2 keer van de 9 ja's

        Dim pNee = ((d / 100) * (m / 100) * (s / 100) * (sd / 100) * (c / 100) * (pros / 100))
        Dim pJa = (1 - (d / 100)) * (1 - (m / 100)) * (1 - (s / 100)) * (1 - (sd / 100) * (1 - (c / 100)) * (1 - (pros / 100)))
        Dim values As New ArrayList({d / 100, m / 100, s / 100, sd / 100, c / 100, pros / 100})
        Dim range = p.certainty(values, pNee / (pNee + pJa))
        txtTotaal.Text = range.ToString
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