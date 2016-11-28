Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports ForecastVB

<TestClass()> Public Class TestTestBLL
    Dim testBLL As New TestBLL
    Dim cursList1 = TestBLL.GetAllCursForAllVar("Opleidingsnr = 154727")
    Dim cursList2 = TestBLL.GetAllCursForAllVar("Opleidingsnr = 135277")
    Dim cursList3 = TestBLL.GetAllCursForAllVar("Opleidingsnr = 86442")
    Dim cursList4 = TestBLL.GetAllCursForAllVarWithYear("Opleidingsnr = 179622")
    Dim cursList5 = TestBLL.GetAllCursForAllVarWithYear("Opleidingsnr = 122560")
    Dim cursList6 = TestBLL.GetAllCursForAllVarWithYear("Opleidingsnr = 117437")

    <TestMethod()> Public Sub Test_GetAllCursForAllVarMerkCheck1()
        Assert.AreEqual("Syntra West", cursList1(0).getMerk)
    End Sub

    <TestMethod()> Public Sub Test_GetAllCursForAllVarUitvoerCentrumCheck1()
        Assert.AreEqual("Syntra West Brugge", cursList1(0).getUitvoerCentrum)
    End Sub

    <TestMethod()> Public Sub Test_GetAllCursForAllVarSubAfdelingCheck1()
        Assert.AreEqual("CAD", cursList1(0).getCodeSubafdeling)
    End Sub

    <TestMethod()> Public Sub Test_GetAllCursForAllVarMaandCheck1()
        Assert.AreEqual(5, cursList1(0).getMaand)
    End Sub

    <TestMethod()> Public Sub Test_GetAllCursForAllVarDagCheck1()
        Assert.AreEqual("woensdag", cursList1(0).getDag)
    End Sub
    <TestMethod()> Public Sub Test_GetAllCursForAllVarMerkCheck2()
        testBLL = New TestBLL
        Assert.AreEqual("Syntra West", cursList2(0).getMerk)
    End Sub

    <TestMethod()> Public Sub Test_GetAllCursForAllVarUitvoerCentrumCheck2()
        Assert.AreEqual("Syntra West Brugge", cursList2(0).getUitvoerCentrum)
    End Sub

    <TestMethod()> Public Sub Test_GetAllCursForAllVarSubAfdelingCheck2()
        Assert.AreEqual("GLK", cursList2(0).getCodeSubafdeling)
    End Sub

    <TestMethod()> Public Sub Test_GetAllCursForAllVarMaandCheck2()
        Assert.AreEqual(9, cursList2(0).getMaand)
    End Sub

    <TestMethod()> Public Sub Test_GetAllCursForAllVarDagCheck2()
        Assert.AreEqual("donderdag", cursList2(0).getDag)
    End Sub

    <TestMethod()> Public Sub Test_GetAllCursForAllVarMerkCheck3()
        Assert.AreEqual("Syntra West", cursList3(0).getMerk)
    End Sub

    <TestMethod()> Public Sub Test_GetAllCursForAllVarUitvoerCentrumCheck3()
        Assert.AreEqual("Syntra West Roeselare", cursList3(0).getUitvoerCentrum)
    End Sub

    <TestMethod()> Public Sub Test_GetAllCursForAllVarSubAfdelingCheck3()
        Assert.AreEqual("BU ", cursList3(0).getCodeSubafdeling)
    End Sub

    <TestMethod()> Public Sub Test_GetAllCursForAllVarMaandCheck3()
        Assert.AreEqual(6, cursList3(0).getMaand)
    End Sub

    <TestMethod()> Public Sub Test_GetAllCursForAllVarDagCheck3()
        Assert.AreEqual("donderdag", cursList3(0).getDag)
    End Sub

    <TestMethod()> Public Sub Test_GetAllCursForAllVarWithYearMerkCheck1()
        Assert.AreEqual("Syntra West", cursList4(0).getMerk)
    End Sub

    <TestMethod()> Public Sub Test_GetAllCursForAllVarWithYearUitvoerCentrumCheck1()
        Assert.AreEqual("Syntra West Roeselare", cursList4(0).getUitvoerCentrum)
    End Sub

    <TestMethod()> Public Sub Test_GetAllCursForAllVarWithYearSubAfdelingCheck1()
        Assert.AreEqual("TXT", cursList4(0).getCodeSubafdeling)
    End Sub

    <TestMethod()> Public Sub Test_GetAllCursForAllVarWithYearMaandCheck1()
        Assert.AreEqual(9, cursList4(0).getMaand)
    End Sub

    <TestMethod()> Public Sub Test_GetAllCursForAllVarWithYearDagCheck1()
        Assert.AreEqual("dinsdag", cursList4(0).getDag)
    End Sub

    <TestMethod()> Public Sub Test_GetAllCursForAllVarWithYearYearCheck1()
        Assert.AreEqual(2016, cursList4(0).getJaar)
    End Sub

    <TestMethod()> Public Sub Test_GetAllCursForAllVarWithYearMerkCheck2()
        Assert.AreEqual("Syntra West", cursList5(0).getMerk)
    End Sub

    <TestMethod()> Public Sub Test_GetAllCursForAllVarWithYearUitvoerCentrumCheck2()
        Assert.AreEqual("Syntra West Brugge", cursList5(0).getUitvoerCentrum)
    End Sub

    <TestMethod()> Public Sub Test_GetAllCursForAllVarWithYearSubAfdelingCheck2()
        Assert.AreEqual("RET", cursList5(0).getCodeSubafdeling)
    End Sub

    <TestMethod()> Public Sub Test_GetAllCursForAllVarWithYearMaandCheck2()
        Assert.AreEqual(11, cursList5(0).getMaand)
    End Sub

    <TestMethod()> Public Sub Test_GetAllCursForAllVarWithYearDagCheck2()
        Assert.AreEqual("donderdag", cursList5(0).getDag)
    End Sub

    <TestMethod()> Public Sub Test_GetAllCursForAllVarWithYearYearCheck2()
        Assert.AreEqual(2011, cursList5(0).getJaar)
    End Sub

    <TestMethod()> Public Sub Test_GetAllCursForAllVarWithYearMerkCheck3()
        Assert.AreEqual("Escala", cursList6(0).getMerk)
    End Sub

    <TestMethod()> Public Sub Test_GetAllCursForAllVarWithYearUitvoerCentrumCheck3()
        Assert.AreEqual("Syntra West Brugge", cursList6(0).getUitvoerCentrum)
    End Sub

    <TestMethod()> Public Sub Test_GetAllCursForAllVarWithYearSubAfdelingCheck3()
        Assert.AreEqual("JUR", cursList6(0).getCodeSubafdeling)
    End Sub

    <TestMethod()> Public Sub Test_GetAllCursForAllVarWithYearMaandCheck3()
        Assert.AreEqual(11, cursList6(0).getMaand)
    End Sub

    <TestMethod()> Public Sub Test_GetAllCursForAllVarWithYearDagCheck3()
        Assert.AreEqual("donderdag", cursList6(0).getDag)
    End Sub

    <TestMethod()> Public Sub Test_GetAllCursForAllVarWithYearYearCheck3()
        Assert.AreEqual(2010, cursList6(0).getJaar)
    End Sub


End Class