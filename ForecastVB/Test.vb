﻿Public Class Test
    Private root As MainScreen
    Public Sub New(main As MainScreen)
        ' This call is required by the designer.
        InitializeComponent()
        root = main
        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Private Sub Test_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim m As New MerkBLL
        cboMerk.Items.AddRange(m.getAll(2015, Nothing).ToArray)
        cboDag.Items.AddRange({"Maandag", "Dinsdag", "Woensdag", "Donderdag", "Vrijdag", "Zaterdag", "Zondag"})
        startUp()
    End Sub
    Private Sub startUp()
        lvResult.Clear()
        lvResult.Columns.Add("SubAfdeling", 150)
        lvResult.Columns.Add("Voorspeld", 150)
        lvResult.Columns.Add("Echt", 150)
        lvResult.Columns.Add("Check", 150)
    End Sub

    Private Sub btnCheck_Click(sender As Object, e As EventArgs) Handles btnCheck.Click
        startUp()
        Dim sql As New SQLUtil
        Dim subAfds As New ArrayList
        Dim subBll As New subAfdBll
        Dim ja = 0
        Dim nee = 0
        Dim filters = root.getFilters
        If filters Is Nothing Then
            subAfds.AddRange(sql.getArrayList("select distinct CodeSubafdeling from Cursussen where Merk = '" + cboMerk.SelectedItem.ToString + "' and dag='" + cboDag.SelectedItem.ToString + "' and year(StartDatum) = 2015 group by codesubafdeling having count(*) > 5").ToArray())
        Else
            Dim fil As String
            fil = ""

            For Each filIt As FilterItem In filters
                fil += " AND " + filIt.kolom + " " + filIt.factor + " " + filIt.filter
            Next
            subAfds.AddRange(sql.getArrayList("select distinct CodeSubafdeling from Cursussen where Merk = '" + cboMerk.SelectedItem.ToString + "' and dag='" + cboDag.SelectedItem.ToString + "' and year(StartDatum) = 2015 " + fil + "group by codesubafdeling having count(*) > 5").ToArray())

        End If
        pgb.Minimum = 0
        If subAfds.Count = 0 Then
            pgb.Maximum = 1
        Else
            pgb.Maximum = subAfds.Count - 1
        End If

        For i As Integer = 0 To subAfds.Count - 1
            Dim merk As New MerkBLL
            Dim dag As New DagBll
            Dim lvi As New ListViewItem(subAfds(i).ToString)
            Dim subA As Bereik = subBll.berekenVerwachtingsBereikVoorSubAfd(2015, subAfds(i), Nothing)
            Dim dagA As Bereik = dag.berekenVerwachtingsBereikVoorDag(2015, cboDag.SelectedItem.ToString, Nothing)
            Dim merkA As Bereik = merk.berekenVerwachtingsBereikVoorMerk(2015, cboMerk.SelectedItem.ToString, Nothing)
            Dim min As Double = 100
            Dim max As Double = 0
            Dim bereiken As New ArrayList()
            bereiken.AddRange({subA, dagA, merkA})
            For j As Integer = 0 To bereiken.Count - 1
                Dim ber As Bereik = bereiken(j)
                If ber.getBovengrens > max Then
                    max = ber.getBovengrens
                End If
                If ber.getOndergrens < min Then
                    min = ber.getOndergrens
                End If
            Next
            Dim bereik As New Bereik(min, 0, max)
            lvi.SubItems.Add(bereik.ToString)
            Dim dick
            If filters Is Nothing Then
                dick = sql.getDictionary("SELECT YEAR(c.startdatum) as jaar,count(*) as totaal,(SELECT count(*) FROM [SyntraTest].[dbo].[Cursussen] as cc WHERE cc.CodeIngetrokken = 'nee' AND CodeSubafdeling = '" + subAfds(i) + "' AND year(cc.StartDatum) = year(c.StartDatum) AND Merk = '" + cboMerk.SelectedItem.ToString + "' and dag='" + cboDag.SelectedItem.ToString + "') as nietGeschrapt FROM [SyntraTest].[dbo].[Cursussen] as c WHERE CodeSubafdeling = '" + subAfds(i) + "' AND year(c.StartDatum) =  2015 and Merk = '" + cboMerk.SelectedItem.ToString + "' and dag='" + cboDag.SelectedItem.ToString + "' group by year(startdatum)")
            Else
                Dim fil As String
                fil = ""

                For Each filIt As FilterItem In filters
                    fil += " AND " + filIt.kolom + " " + filIt.factor + " " + filIt.filter
                Next
                dick = sql.getDictionary("SELECT YEAR(c.startdatum) as jaar,count(*) as totaal,(SELECT count(*) FROM [SyntraTest].[dbo].[Cursussen] as cc WHERE cc.CodeIngetrokken = 'nee' AND CodeSubafdeling = '" + subAfds(i) + "' AND year(cc.StartDatum) = year(c.StartDatum) AND Merk = '" + cboMerk.SelectedItem.ToString + "' and dag='" + cboDag.SelectedItem.ToString + "' " + fil + ") as nietGeschrapt FROM [SyntraTest].[dbo].[Cursussen] as c WHERE CodeSubafdeling = '" + subAfds(i) + "' AND year(c.StartDatum) =  2015 and Merk = '" + cboMerk.SelectedItem.ToString + "' and dag='" + cboDag.SelectedItem.ToString + "' " + fil + " group by year(startdatum)")
            End If
            Dim y As Double
            If dick IsNot Nothing Then
                For Each kvp As KeyValuePair(Of String, Parameter) In dick
                    y = CDbl(kvp.Value.berekenPercentage)
                Next

                lvi.SubItems.Add(y.ToString)
            End If
            Dim tf = bereik.valtTussen(y)
            If tf Then
                lvi.BackColor = Color.FromArgb(255, 46, 204, 113)
                ja += 1
            Else
                lvi.BackColor = Color.FromArgb(255, 231, 76, 60)
                nee += 1
            End If
            lvi.SubItems.Add(tf)
            lvResult.Items.AddRange(New ListViewItem() {lvi})

            pgb.Value = i
        Next
        Label1.Text = "TRUE: " + ja.ToString() + " FALSE: " + nee.ToString()
    End Sub
End Class