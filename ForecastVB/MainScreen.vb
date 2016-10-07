Public Class MainScreen
    Private Const jaar = 2015
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
        knownY.Add(92.31)
        knownY.Add(90)
        knownY.Add(77.78)
        knownY.Add(68.18)
        knownY.Add(53.13)
        knownY.Add(48)
        knownY.Add(47.62)
        knownY.Add(73.68)
        knownY.Add(48.15)
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
        Dim pros = p.prospect(knownY, knownX, CDbl(jaar))
        Dim range = p.certainty(knownY, pros)
        txtRestultJaar.Text = "[" + Math.Round(range(0), 2).ToString + " - " + Math.Round(range(1), 2).ToString + "]"
    End Sub

    Private Sub cboSubAfd_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSubAfd.SelectedIndexChanged
        Dim subafd As New SubAfdBLL
        Dim range = subafd.berekenVerwachtingsBereikVoorSubAfd(jaar, cboSubAfd.SelectedItem)
        txtResultSubAfd.Text = "[" + Math.Round(range(0), 2).ToString + " - " + Math.Round(range(1), 2).ToString + "]"
    End Sub
End Class