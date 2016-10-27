Imports System.IO
Imports Microsoft.VisualBasic.FileIO

Public Class MainScreen
    Private Const jaar = 2015 'TODO: veranderen naar gewenste jaar
    Private filters As New ArrayList
    Private filterlist As ArrayList
    Private selectedFilterList As String
    Private saveDirectory As String = SpecialDirectories.MyDocuments + "//Predictie Filters//"
    Private m, d, s, sd, c As Double
    Private jm, jd, js, jsd, jc As Double
    Private allData As AllDataBLL
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
        allData = New AllDataBLL()
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
        s = allData.getPErcentageNee(jaar, "codesubafdeling", cboSubAfd.SelectedItem.ToString, filters)
        js = allData.getPercentageJa(jaar, "codesubafdeling", cboSubAfd.SelectedItem.ToString, filters)
    End Sub

    Private Sub cboMerk_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboMerk.SelectedIndexChanged
        Dim merken As New MerkBLL
        Dim mb = merken.berekenVerwachtingsBereikVoorMerk(jaar, cboMerk.SelectedItem, filters)
        txtResultMerk.Text = mb.ToString
        m = allData.getPErcentageNee(jaar, "merk", cboMerk.SelectedItem.ToString, filters)
        jm = allData.getPercentageJa(jaar, "merk", cboMerk.SelectedItem.ToString, filters)
    End Sub

    Private Sub cboLesdag_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboLesdag.SelectedIndexChanged
        Dim dag As New DagBll
        Dim db = dag.berekenVerwachtingsBereikVoorDag(jaar, cboLesdag.SelectedItem, filters)
        txtRestultLesDag.Text = db.ToString
        d = allData.getPErcentageNee(jaar, "dag", cboLesdag.SelectedItem.ToString, filters)
        jd = allData.getPercentageJa(jaar, "dag", cboLesdag.SelectedItem.ToString, filters)
    End Sub

    Private Sub dtpStartcursus_ValueChanged(sender As Object, e As EventArgs) Handles dtpStartcursus.ValueChanged
        Dim datum As New DatumBLL
        Dim sdb = datum.berekenVerwachtingsBereikVoorDatum(jaar, dtpStartcursus.Value.Month.ToString, filters)
        txtResultDatum.Text = sdb.ToString
        sd = allData.getPErcentageNee(jaar, "month(startdatum)", dtpStartcursus.Value.Month.ToString, filters)
        jsd = allData.getPercentageJa(jaar, "month(startdatum)", dtpStartcursus.Value.Month.ToString, filters)
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

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim ont As New PerOntwikkelaar(Me)
        ont.Show()
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
        c = allData.getPErcentageNee(jaar, "UitvCentrumOmsch", cboUitvCent.SelectedItem.ToString, filters)
        jc = allData.getPercentageJa(jaar, "UitvCentrumOmsch", cboUitvCent.SelectedItem.ToString, filters)
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim t As New Test(Me)
        t.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim p As New Prospect
        'TODO Wegings factor aanpassen, yes bij kollom is aantal keer dat het resultaat ja was
        'http://www.cs.ccsu.edu/~markov/ccsu_courses/DataMining-8.html
        'hoeveel keer was resultaat ja als outlook sunny was? 2 keer van de 9 ja's
        Dim totaal = allData.getTotaalAantal(jaar, filters)
        Dim globalNee = allData.getAllNee(jaar, filters) / totaal
        Dim globalJa = allData.getAllJa(jaar, filters) / totaal
        Dim pNee = m * c * s * d * sd * globalNee
        Dim pJa = jm * jc * js * jd * jsd * globalJa
        'Dim pJa = (1 - (d / 100)) * (1 - (m / 100)) * (1 - (s / 100)) * (1 - (sd / 100)) * (1 - (c / 100)) * (1 - (pros / 100))
        'Dim values As New ArrayList({d, m, s, sd, c, globalNee})
        'Dim range = p.certainty(values, pNee / (pNee + pJa))
        txtTotaal.Text = (pNee / (pNee + pJa)).ToString
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