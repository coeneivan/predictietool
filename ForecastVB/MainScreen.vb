Public Class MainScreen
    Private Sub MainScreen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim s As New SQLUtil
        'Load all cursussen
        Dim subAfds = s.Execute("SELECT distinct CodeSubafdeling FROM Cursussen")
        For Each row As Object In subAfds
            cboSubAfd.Items.Add(row.ToString)
        Next

        'Load dagen
        Dim dagen = {"Maandag", "Dinsdag", "Woensdag", "Donderdag", "Vrijdag", "Zaterdag", "Zondag"}
        For Each row As Object In dagen
            cboLesdag.Items.Add(row.ToString)
        Next

        'Load merken
        Dim merken = s.Execute("SELECT distinct merk FROM Cursussen")
        For Each row As Object In merken
            cboMerk.Items.Add(row.ToString)
        Next

        'Calculate main percentage
        Dim knownX, knownY As New ArrayList
        knownY.Add(79.55)
        knownY.Add(75.93)
        knownY.Add(75.75)
        knownY.Add(77.53)
        knownY.Add(75.5)
        knownY.Add(75.91)
        knownY.Add(76.3)
        knownY.Add(74.55)
        knownY.Add(71.06)
        knownX.Add(2006)
        knownX.Add(2007)
        knownX.Add(2008)
        knownX.Add(2009)
        knownX.Add(2010)
        knownX.Add(2011)
        knownX.Add(2012)
        knownX.Add(2013)
        knownX.Add(2014)
        Dim p As New Prospect
        Dim range = p.certainty(knownY, p.prospect(knownY, knownX, CDbl(2015)))
        txtRestultJaar.Text = "[" + Math.Round(range(0), 2).ToString + " - " + Math.Round(range(1), 2).ToString + "]"
    End Sub

    Private Sub cboSubAfd_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSubAfd.SelectedIndexChanged
        Dim s As New SQLUtil
        Dim subAfdsAll = s.Execute("SELECT Opleidingsnr FROM Cursussen WHERE CodeSubafdeling = '" + cboSubAfd.SelectedItem + "'")
        Dim subAfdsGeschrapt = s.Execute("SELECT Opleidingsnr FROM Cursussen WHERE CodeSubafdeling = '" + cboSubAfd.SelectedItem + "'and codeIngetrokken ='ja'")
        Dim knownX = s.Execute("SELECT Distinct YEAR(startdatum) FROM Cursussen WHERE CodeSubafdeling = '" + cboSubAfd.SelectedItem + "'and year(StartDatum)<2015 ")
        Dim knownY = s.Execute("")

        Dim p As New Prospect
        Dim range = p.certainty(knownY, p.prospect(knownY, knownX, CDbl(2015)))
        txtResultSubAfd.Text = "[" + Math.Round(range(0), 2).ToString + " - " + Math.Round(range(1), 2).ToString + "]"

    End Sub
End Class