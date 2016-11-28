Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports ForecastVB

<TestClass()> Public Class TestOntwikkelaarsBLL
    Shared ontwikkelaarsBLL As New OntwikkelaarsBLL
    Shared filters1 As New ArrayList
    Shared cursList1 = New List(Of Cursus)
    Shared filters2 As New ArrayList
    Shared cursList2 = New List(Of Cursus)
    Shared filters3 As New ArrayList
    Shared cursList3 = New List(Of Cursus)

    <ClassInitialize()>
    Public Shared Sub ClassInit(ByVal context As TestContext)
        filters1.Add(New FilterItem("Opleidingsnr", "=", "185147"))
        cursList1 = ontwikkelaarsBLL.getAll(filters1)

        filters2.Add(New FilterItem("Opleidingsnr", "=", "127848"))
        cursList2 = ontwikkelaarsBLL.getAll(filters2)

        filters3.Add(New FilterItem("Opleidingsnr", "=", "95091"))
        cursList3 = ontwikkelaarsBLL.getAll(filters3)
    End Sub

    <TestMethod()> Public Sub Test_GetAllMerkCheck1()
        Assert.AreEqual("Escala", cursList1(0).getMerk())
    End Sub

    <TestMethod()> Public Sub Test_GetAllUitvoerCentrumCheck1()
        Assert.AreEqual("Syntra West Brugge", cursList1(0).getUitvoerCentrum())
    End Sub

    <TestMethod()> Public Sub Test_GetAllCodeSubafdelingCheck1()
        Assert.AreEqual("MSR", cursList1(0).getCodeSubafdeling())
    End Sub

    <TestMethod()> Public Sub Test_GetAllOntCheck1()
        Assert.AreEqual("IDF  ", cursList1(0).getOntw())
    End Sub

    <TestMethod()> Public Sub Test_GetAllMerkCheck2()
        Assert.AreEqual("Escala", cursList2(0).getMerk())
    End Sub

    <TestMethod()> Public Sub Test_GetAllUitvoerCentrumCheck2()
        Assert.AreEqual("Syntra West Brugge", cursList2(0).getUitvoerCentrum())
    End Sub

    <TestMethod()> Public Sub Test_GetAllCodeSubafdelingCheck2()
        Assert.AreEqual("JUR", cursList2(0).getCodeSubafdeling())
    End Sub

    <TestMethod()> Public Sub Test_GetAllOntCheck2()
        Assert.AreEqual("RLM  ", cursList2(0).getOntw())
    End Sub

    <TestMethod()> Public Sub Test_GetAllMerkCheck3()
        Assert.AreEqual("Escala", cursList3(0).getMerk())
    End Sub

    <TestMethod()> Public Sub Test_GetAllUitvoerCentrumCheck3()
        Assert.AreEqual("Syntra West Kortrijk", cursList3(0).getUitvoerCentrum())
    End Sub

    <TestMethod()> Public Sub Test_GetAllCodeSubafdelingCheck3()
        Assert.AreEqual("DIE", cursList3(0).getCodeSubafdeling())
    End Sub

    <TestMethod()> Public Sub Test_GetAllOntCheck3()
        Assert.AreEqual("CDB  ", cursList3(0).getOntw())
    End Sub

End Class