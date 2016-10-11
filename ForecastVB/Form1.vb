Public Class Form1
    Private knownX, knownY As New ArrayList
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        knownX.Add(txtNewX.Text)
        knownY.Add(txtNewY.Text)
        lbX.Items.Add(txtNewX.Text)
        lbY.Items.Add(txtNewY.Text)
        txtNewX.Text = CInt(txtNewX.Text) + 1
        txtCalculateX.Text = txtNewX.Text
        txtCalculateY.Text = ""
        txtNewY.Text = ""
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    'MAIN
    Private Sub btnTest_Click(sender As Object, e As EventArgs) Handles btnTest.Click
        clearList()
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
        updateList()
    End Sub
    'WEB
    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        clearList()
        knownY.Add(100)
        knownY.Add(100)
        knownY.Add(85.71)
        knownY.Add(66.67)
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
        updateList()
    End Sub
    ''MONDAY
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        clearList()
        knownY.Add(78.68)
        knownY.Add(74.93)
        knownY.Add(75.89)
        knownY.Add(78.96)
        knownY.Add(78.31)
        knownY.Add(77.72)
        knownY.Add(77.4)
        knownY.Add(77.67)
        knownY.Add(69.76)
        knownX.Add(2006)
        knownX.Add(2007)
        knownX.Add(2008)
        knownX.Add(2009)
        knownX.Add(2010)
        knownX.Add(2011)
        knownX.Add(2012)
        knownX.Add(2013)
        knownX.Add(2014)
        updateList()
    End Sub

    Private Sub btnCalc_Click(sender As Object, e As EventArgs) Handles btnCalc.Click
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        clearList()
    End Sub

    Private Sub updateList()
        For i As Integer = 0 To knownX.Count - 1
            lbX.Items.Add(knownX(i))
            lbY.Items.Add(knownY(i))
        Next
        txtCalculateY.Text = ""
    End Sub
    Private Sub clearList()
        knownY.Clear()
        knownX.Clear()
        lbX.Items.Clear()
        lbY.Items.Clear()
        txtResult.Text = ""
    End Sub
End Class