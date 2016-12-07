Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports CursusPredictie

<TestClass()> Public Class TestAfwijking

    <TestMethod()> Public Sub TestGetText1()
        Dim afw As New Afwijking(0.995, 22.35)

        Assert.AreEqual("99,5%", afw.getText())
    End Sub

    <TestMethod()> Public Sub TestGetText2()
        Dim afw As New Afwijking(0.99, 27.74)

        Assert.AreEqual("99%", afw.getText())
    End Sub

    <TestMethod()> Public Sub TestGetText3()
        Dim afw As New Afwijking(0.975, 11.47)

        Assert.AreEqual("97,5%", afw.getText())
    End Sub

    <TestMethod()> Public Sub TestGetText4()
        Dim afw As New Afwijking(0.95, 16.75)

        Assert.AreEqual("95%", afw.getText())
    End Sub

    <TestMethod()> Public Sub TestGetText5()
        Dim afw As New Afwijking(0.9, 16.75)

        Assert.AreEqual("90%", afw.getText())
    End Sub

    <TestMethod()> Public Sub TestGetText6()
        Dim afw As New Afwijking(0.995, 5.78)
        afw.setAfwijking(73.2)
        afw.setTverdelingswaarde(0.95)

        Assert.AreEqual("95%", afw.getText())
    End Sub

    <TestMethod()> Public Sub TestGetAfwijking1()
        Dim afw As New Afwijking(0.975, 16.75)

        Assert.AreEqual(16.75, afw.getAfwijkingswaarde())
    End Sub

    <TestMethod()> Public Sub TestGetAfwijking2()
        Dim afw As New Afwijking(0.9, 23.75)

        Assert.AreEqual(23.75, afw.getAfwijkingswaarde())
    End Sub

    <TestMethod()> Public Sub TestGetAfwijking3()
        Dim afw As New Afwijking(0.995, 5.78)

        Assert.AreEqual(5.78, afw.getAfwijkingswaarde())
    End Sub

    <TestMethod()> Public Sub TestGetAfwijking4()
        Dim afw As New Afwijking(0.995, 5.78)
        afw.setAfwijking(27.3)

        Assert.AreEqual(27.3, afw.getAfwijkingswaarde())
    End Sub

    <TestMethod()> Public Sub TestGetAfwijking5()
        Dim afw As New Afwijking(0.995, 5.78)
        afw.setAfwijking(73.2)

        Assert.AreEqual(73.2, afw.getAfwijkingswaarde())
    End Sub

    <TestMethod()> Public Sub TestGetAfwijking6()
        Dim afw As New Afwijking(0.995, 5.78)
        afw.setAfwijking(73.2)
        afw.setTverdelingswaarde(0.95)

        Assert.AreEqual(73.2, afw.getAfwijkingswaarde())
    End Sub
End Class