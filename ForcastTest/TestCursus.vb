Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports ForecastVB

<TestClass()> Public Class TestCursus

    <TestMethod()> Public Sub TestCursusMerk1()
        Dim afw As New List(Of Afwijking)
        afw.Add(New Afwijking(0.995, 3.24))
        afw.Add(New Afwijking(0.99, 7.84))
        afw.Add(New Afwijking(0.975, 12.87))
        afw.Add(New Afwijking(0.95, 20.79))
        afw.Add(New Afwijking(0.9, 30.94))
        Dim curs = New Cursus("Syntra West", "Syntra West Brugge", 9, "dinsdag", "MGV", 102, 84, 0.74, 2014, 12.36, afw, Algoritmes.Bayes, True, "HND")

        Assert.AreEqual("Syntra West", curs.getMerk)
    End Sub

    <TestMethod()> Public Sub TestUitvoerCentrum1()
        Dim afw As New List(Of Afwijking)
        afw.Add(New Afwijking(0.995, 3.24))
        afw.Add(New Afwijking(0.99, 7.84))
        afw.Add(New Afwijking(0.975, 12.87))
        afw.Add(New Afwijking(0.95, 20.79))
        afw.Add(New Afwijking(0.9, 30.94))
        Dim curs = New Cursus("Syntra West", "Syntra West Brugge", 9, "dinsdag", "MGV", 102, 84, 0.74, 2014, 12.36, afw, Algoritmes.Bayes, True, "HND")

        Assert.AreEqual("Syntra West Brugge", curs.getUitvoerCentrum)
    End Sub

    <TestMethod()> Public Sub TestMaand()
        Dim afw As New List(Of Afwijking)
        afw.Add(New Afwijking(0.995, 3.24))
        afw.Add(New Afwijking(0.99, 7.84))
        afw.Add(New Afwijking(0.975, 12.87))
        afw.Add(New Afwijking(0.95, 20.79))
        afw.Add(New Afwijking(0.9, 30.94))
        Dim curs = New Cursus("Syntra West", "Syntra West Brugge", 9, "dinsdag", "MGV", 102, 84, 0.74, 2014, 12.36, afw, Algoritmes.Bayes, True, "HND")

        Assert.AreEqual(9, curs.getMaand)
    End Sub

    <TestMethod()> Public Sub TestDag()
        Dim afw As New List(Of Afwijking)
        afw.Add(New Afwijking(0.995, 3.24))
        afw.Add(New Afwijking(0.99, 7.84))
        afw.Add(New Afwijking(0.975, 12.87))
        afw.Add(New Afwijking(0.95, 20.79))
        afw.Add(New Afwijking(0.9, 30.94))
        Dim curs = New Cursus("Syntra West", "Syntra West Brugge", 9, "dinsdag", "MGV", 102, 84, 0.74, 2014, 12.36, afw, Algoritmes.Bayes, True, "HND")

        Assert.AreEqual("dinsdag", curs.getDag)
    End Sub

    <TestMethod()> Public Sub TestCodeSubafdeling1()
        Dim afw As New List(Of Afwijking)
        afw.Add(New Afwijking(0.995, 3.24))
        afw.Add(New Afwijking(0.99, 7.84))
        afw.Add(New Afwijking(0.975, 12.87))
        afw.Add(New Afwijking(0.95, 20.79))
        afw.Add(New Afwijking(0.9, 30.94))
        Dim curs = New Cursus("Syntra West", "Syntra West Brugge", 9, "dinsdag", "MGV", 102, 84, 0.74, 2014, 12.36, afw, Algoritmes.Bayes, True, "HND")

        Assert.AreEqual("MGV", curs.getCodeSubafdeling)
    End Sub

    <TestMethod()> Public Sub TestTotaal()
        Dim afw As New List(Of Afwijking)
        afw.Add(New Afwijking(0.995, 3.24))
        afw.Add(New Afwijking(0.99, 7.84))
        afw.Add(New Afwijking(0.975, 12.87))
        afw.Add(New Afwijking(0.95, 20.79))
        afw.Add(New Afwijking(0.9, 30.94))
        Dim curs = New Cursus("Syntra West", "Syntra West Brugge", 9, "dinsdag", "MGV", 102, 84, 0.74, 2014, 12.36, afw, Algoritmes.Bayes, True, "HND")

        Assert.AreEqual(102, curs.getTotaal)
    End Sub

    <TestMethod()> Public Sub TestDoorgegaan()
        Dim afw As New List(Of Afwijking)
        afw.Add(New Afwijking(0.995, 3.24))
        afw.Add(New Afwijking(0.99, 7.84))
        afw.Add(New Afwijking(0.975, 12.87))
        afw.Add(New Afwijking(0.95, 20.79))
        afw.Add(New Afwijking(0.9, 30.94))
        Dim curs = New Cursus("Syntra West", "Syntra West Brugge", 9, "dinsdag", "MGV", 102, 84, 0.74, 2014, 12.36, afw, Algoritmes.Bayes, True, "HND")

        Assert.AreEqual(84, curs.getAantalDoorgegaan)
    End Sub

    <TestMethod()> Public Sub TestKans()
        Dim afw As New List(Of Afwijking)
        afw.Add(New Afwijking(0.995, 3.24))
        afw.Add(New Afwijking(0.99, 7.84))
        afw.Add(New Afwijking(0.975, 12.87))
        afw.Add(New Afwijking(0.95, 20.79))
        afw.Add(New Afwijking(0.9, 30.94))
        Dim curs = New Cursus("Syntra West", "Syntra West Brugge", 9, "dinsdag", "MGV", 102, 84, 0.74, 2014, 12.36, afw, Algoritmes.Bayes, True, "HND")

        Assert.AreEqual(0.74, curs.getKans)
    End Sub

    <TestMethod()> Public Sub TestJaar()
        Dim afw As New List(Of Afwijking)
        afw.Add(New Afwijking(0.995, 3.24))
        afw.Add(New Afwijking(0.99, 7.84))
        afw.Add(New Afwijking(0.975, 12.87))
        afw.Add(New Afwijking(0.95, 20.79))
        afw.Add(New Afwijking(0.9, 30.94))
        Dim curs = New Cursus("Syntra West", "Syntra West Brugge", 9, "dinsdag", "MGV", 102, 84, 0.74, 2014, 12.36, afw, Algoritmes.Bayes, True, "HND")

        Assert.AreEqual(2014, curs.getJaar)
    End Sub

    <TestMethod()> Public Sub TestB()
        Dim afw As New List(Of Afwijking)
        afw.Add(New Afwijking(0.995, 3.24))
        afw.Add(New Afwijking(0.99, 7.84))
        afw.Add(New Afwijking(0.975, 12.87))
        afw.Add(New Afwijking(0.95, 20.79))
        afw.Add(New Afwijking(0.9, 30.94))
        Dim curs = New Cursus("Syntra West", "Syntra West Brugge", 9, "dinsdag", "MGV", 102, 84, 0.74, 2014, 12.36, afw, Algoritmes.Bayes, True, "HND")

        Assert.AreEqual(12.36, curs.getB)
    End Sub

    <TestMethod()> Public Sub TestAfwijking1()
        Dim afw As New List(Of Afwijking)
        afw.Add(New Afwijking(0.995, 3.24))
        afw.Add(New Afwijking(0.99, 7.84))
        afw.Add(New Afwijking(0.975, 12.87))
        afw.Add(New Afwijking(0.95, 20.79))
        afw.Add(New Afwijking(0.9, 30.94))
        Dim curs = New Cursus("Syntra West", "Syntra West Brugge", 9, "dinsdag", "MGV", 102, 84, 0.74, 2014, 12.36, afw, Algoritmes.Bayes, True, "HND")

        Assert.AreEqual(3.24, curs.getAfwijkingswaarde(0))
    End Sub

    <TestMethod()> Public Sub TestAfwijking2()
        Dim afw As New List(Of Afwijking)
        afw.Add(New Afwijking(0.995, 3.24))
        afw.Add(New Afwijking(0.99, 7.84))
        afw.Add(New Afwijking(0.975, 12.87))
        afw.Add(New Afwijking(0.95, 20.79))
        afw.Add(New Afwijking(0.9, 30.94))
        Dim curs = New Cursus("Syntra West", "Syntra West Brugge", 9, "dinsdag", "MGV", 102, 84, 0.74, 2014, 12.36, afw, Algoritmes.Bayes, True, "HND")

        Assert.AreEqual(7.84, curs.getAfwijkingswaarde(1))
    End Sub

    <TestMethod()> Public Sub TestAfwijking3()
        Dim afw As New List(Of Afwijking)
        afw.Add(New Afwijking(0.995, 3.24))
        afw.Add(New Afwijking(0.99, 7.84))
        afw.Add(New Afwijking(0.975, 12.87))
        afw.Add(New Afwijking(0.95, 20.79))
        afw.Add(New Afwijking(0.9, 30.94))
        Dim curs = New Cursus("Syntra West", "Syntra West Brugge", 9, "dinsdag", "MGV", 102, 84, 0.74, 2014, 12.36, afw, Algoritmes.Bayes, True, "HND")

        Assert.AreEqual(12.87, curs.getAfwijkingswaarde(2))
    End Sub

    <TestMethod()> Public Sub TestAfwijking4()
        Dim afw As New List(Of Afwijking)
        afw.Add(New Afwijking(0.995, 3.24))
        afw.Add(New Afwijking(0.99, 7.84))
        afw.Add(New Afwijking(0.975, 12.87))
        afw.Add(New Afwijking(0.95, 20.79))
        afw.Add(New Afwijking(0.9, 30.94))
        Dim curs = New Cursus("Syntra West", "Syntra West Brugge", 9, "dinsdag", "MGV", 102, 84, 0.74, 2014, 12.36, afw, Algoritmes.Bayes, True, "HND")

        Assert.AreEqual(20.79, curs.getAfwijkingswaarde(3))
    End Sub

    <TestMethod()> Public Sub TestAfwijking5()
        Dim afw As New List(Of Afwijking)
        afw.Add(New Afwijking(0.995, 3.24))
        afw.Add(New Afwijking(0.99, 7.84))
        afw.Add(New Afwijking(0.975, 12.87))
        afw.Add(New Afwijking(0.95, 20.79))
        afw.Add(New Afwijking(0.9, 30.94))
        Dim curs = New Cursus("Syntra West", "Syntra West Brugge", 9, "dinsdag", "MGV", 102, 84, 0.74, 2014, 12.36, afw, Algoritmes.Bayes, True, "HND")

        Assert.AreEqual(30.94, curs.getAfwijkingswaarde(4))
    End Sub

End Class