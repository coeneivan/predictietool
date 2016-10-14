﻿Public Class Test
    Private Sub Test_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim m As New MerkBLL
        cboMerk.Items.AddRange(m.getAll(2015, Nothing).ToArray)
        cboDag.Items.AddRange({"Maandag", "Dinsdag", "Woensdag", "Donderdag", "Vrijdag", "Zaterdag", "Zondag"})
        startUp()
    End Sub
    Private Sub startUp()
        lvResult.Columns.Add("SubAfdeling", 150)
        lvResult.Columns.Add("Voorspeld", 150)
        lvResult.Columns.Add("Echt", 150)
        lvResult.Columns.Add("Check", 150)
    End Sub

    Private Sub btnCheck_Click(sender As Object, e As EventArgs) Handles btnCheck.Click
        Dim sql As New SQLUtil
        Dim subAfds As New ArrayList
        Dim subBll As New subAfdBll
        subAfds.AddRange(sql.getArrayList("select distinct top 10 CodeSubafdeling from Cursussen where Merk = '" + cboMerk.SelectedItem.ToString + "' and dag='" + cboDag.SelectedItem.ToString + "'").ToArray())
        'TODO: delete top 10


        pgb.Minimum = 0
        pgb.Maximum = subAfds.Count - 1

        For i As Integer = 0 To subAfds.Count - 1
            Dim lvi As New ListViewItem(subAfds(i).ToString)
            Dim bereik = subBll.berekenVerwachtingsBereikVoorSubAfd(2015, subAfds(i), Nothing)
            lvi.SubItems.Add(bereik.ToString)
            Dim dick = sql.getDictionary("SELECT YEAR(c.startdatum) as jaar,count(*) as totaal,(SELECT count(*) FROM [SyntraTest].[dbo].[Cursussen] as cc WHERE cc.CodeIngetrokken = 'nee' AND CodeSubafdeling = '" + subAfds(i) + "' AND year(cc.StartDatum) = year(c.StartDatum) AND Merk = '" + cboMerk.SelectedItem.ToString + "' and dag='" + cboDag.SelectedItem.ToString + "') as nietGeschrapt FROM [SyntraTest].[dbo].[Cursussen] as c WHERE CodeSubafdeling = '" + subAfds(i) + "' AND year(c.StartDatum) =  2015 and Merk = '" + cboMerk.SelectedItem.ToString + "' and dag='" + cboDag.SelectedItem.ToString + "' group by year(startdatum)")
            Dim y As Double
            If dick IsNot Nothing Then
                For Each kvp As KeyValuePair(Of String, Parameter) In dick
                    y = CDbl(kvp.Value.berekenPercentage)
                Next

                lvi.SubItems.Add(y.ToString)
            End If
            lvi.SubItems.Add(bereik.valtTussen(y))
            lvResult.Items.AddRange(New ListViewItem() {lvi})

            pgb.Value = i
        Next
    End Sub
End Class