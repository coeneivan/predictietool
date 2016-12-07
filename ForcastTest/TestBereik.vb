Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports CursusPredictie

<TestClass()> Public Class TestBereik

    <TestMethod()> Public Sub TestMidden1()
        Dim ber As New Bereik(13.61982, 43.74194)
        Assert.AreEqual(43.74194, ber.getAvg())
    End Sub

    <TestMethod()> Public Sub TestMidden2()
        Dim ber As New Bereik(13.61982, 50.0)
        Assert.AreEqual(50.0, ber.getAvg())
    End Sub

    <TestMethod()> Public Sub TestMidden3()
        Dim ber As New Bereik(13.61982, 43.74194, 62.154)
        Assert.AreEqual(43.74194, ber.getAvg())
    End Sub

    <TestMethod()> Public Sub TestOnderwaarde1()
        Dim ber As New Bereik(13.61982, 43.74194, 62.154)
        Assert.AreEqual(13.62, ber.getOndergrens())
    End Sub

    <TestMethod()> Public Sub TestOnderwaarde2()
        Dim ber As New Bereik(13.61982, 43.74194)
        Assert.AreEqual(30.12, ber.getOndergrens())
    End Sub

    <TestMethod()> Public Sub TestOnderwaarde3()
        Dim ber As New Bereik(13.61982, 5.14)
        Assert.AreEqual(0.0, ber.getOndergrens())
    End Sub

    <TestMethod()> Public Sub TestBovengrens1()
        Dim ber As New Bereik(13.61982, 35.14)
        Assert.AreEqual(48.76, ber.getBovengrens())
    End Sub

    <TestMethod()> Public Sub TestBovengrens2()
        Dim ber As New Bereik(13.61982, 89.14)
        Assert.AreEqual(100.0, ber.getBovengrens())
    End Sub

    <TestMethod()> Public Sub TestBovengrens3()
        Dim ber As New Bereik(13.61982, 89.14, 98.1658)
        Assert.AreEqual(98.17, ber.getBovengrens())
    End Sub

    <TestMethod()> Public Sub TestToString1()
        Dim ber As New Bereik(13.61982, 89.14, 98.1658)
        Assert.AreEqual("[13,62% - 89,14% - 98,17%]", ber.ToString())
    End Sub

    <TestMethod()> Public Sub TestToString2()
        Dim ber As New Bereik(13.61982, 89.14)
        Assert.AreEqual("[75,52% - 89,14% - 100%]", ber.ToString())
    End Sub
End Class