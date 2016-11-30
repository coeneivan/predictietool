Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports ForecastVB

<TestClass()> Public Class TestBayesBayesLinear

    <TestMethod()> Public Sub TestCreateFilterString1()
        Dim filters As New ArrayList
        filters.Add(New FilterItem("Merk", "=", "Syntra West"))
        filters.Add(New FilterItem("CodeSubafdeling", "=", "TXT"))
        filters.Add(New FilterItem("Dag", "=", "Maandag"))

        Dim root As New MainScreen()
        Dim bbl As New Bayes_Bayes_Linear(root, False)
        Dim filt = bbl.TestCreateFilterString(filters)
        Assert.AreEqual("Merk = Syntra West  and CodeSubafdeling = TXT  and Dag = Maandag ", filt)
    End Sub

    <TestMethod()> Public Sub TestCreateFilterString2()
        Dim filters As New ArrayList
        filters.Add(New FilterItem("OmschrijvingComm", "NOT LIKE", "Spoor"))
        filters.Add(New FilterItem("MONTH(Startdatum)", "<>", "7"))
        filters.Add(New FilterItem("Dag", "=", "Maandag"))

        Dim root As New MainScreen()
        Dim bbl As New Bayes_Bayes_Linear(root, False)
        Dim filt = bbl.TestCreateFilterString(filters)
        Assert.AreEqual("OmschrijvingComm NOT LIKE Spoor  and MONTH(Startdatum) <> 7  and Dag = Maandag ", filt)
    End Sub

    <TestMethod()> Public Sub TestCreateFilterString3()
        Dim filtList = New ArrayList
        Dim root As New MainScreen()
        Dim bbl As New Bayes_Bayes_Linear(root, False)
        Dim filt = bbl.TestCreateFilterString(filtList)
        Assert.AreEqual("", filt)
    End Sub

    <TestMethod()> Public Sub TestListOfSubafdelingen1()
        Dim curs As New List(Of Cursus)
        curs.Add(New Cursus("", "", -1, "", "JUR", -1, -1, -1, -1, -1, Nothing, Nothing, Nothing, ""))
        curs.Add(New Cursus("", "", -1, "", "AB", -1, -1, -1, -1, -1, Nothing, Nothing, Nothing, ""))
        curs.Add(New Cursus("", "", -1, "", "ACC", -1, -1, -1, -1, -1, Nothing, Nothing, Nothing, ""))
        curs.Add(New Cursus("", "", -1, "", "HSD", -1, -1, -1, -1, -1, Nothing, Nothing, Nothing, ""))
        curs.Add(New Cursus("", "", -1, "", "HW", -1, -1, -1, -1, -1, Nothing, Nothing, Nothing, ""))

        Dim bbl As New Bayes_Bayes_Linear(Nothing, False)

        Assert.AreEqual(5, bbl.TestGetSubafdelingen(curs).count)
    End Sub

    <TestMethod()> Public Sub TestListOfSubafdelingenContainsKey1()
        Dim curs As New List(Of Cursus)
        curs.Add(New Cursus("", "", -1, "", "JUR", -1, -1, -1, -1, -1, Nothing, Nothing, Nothing, ""))
        curs.Add(New Cursus("", "", -1, "", "AB", -1, -1, -1, -1, -1, Nothing, Nothing, Nothing, ""))
        curs.Add(New Cursus("", "", -1, "", "ACC", -1, -1, -1, -1, -1, Nothing, Nothing, Nothing, ""))
        curs.Add(New Cursus("", "", -1, "", "HSD", -1, -1, -1, -1, -1, Nothing, Nothing, Nothing, ""))
        curs.Add(New Cursus("", "", -1, "", "HW", -1, -1, -1, -1, -1, Nothing, Nothing, Nothing, ""))

        Dim bbl As New Bayes_Bayes_Linear(Nothing, False)
        Dim test As Boolean = False
        Dim curs1 = bbl.TestGetSubafdelingen(curs)

        Assert.AreEqual("JUR", curs1(0))
    End Sub

    <TestMethod()> Public Sub TestListOfSubafdelingenContainsKey2()
        Dim curs As New List(Of Cursus)
        curs.Add(New Cursus("", "", -1, "", "JUR", -1, -1, -1, -1, -1, Nothing, Nothing, Nothing, ""))
        curs.Add(New Cursus("", "", -1, "", "AB", -1, -1, -1, -1, -1, Nothing, Nothing, Nothing, ""))
        curs.Add(New Cursus("", "", -1, "", "ACC", -1, -1, -1, -1, -1, Nothing, Nothing, Nothing, ""))
        curs.Add(New Cursus("", "", -1, "", "HSD", -1, -1, -1, -1, -1, Nothing, Nothing, Nothing, ""))
        curs.Add(New Cursus("", "", -1, "", "HW", -1, -1, -1, -1, -1, Nothing, Nothing, Nothing, ""))

        Dim bbl As New Bayes_Bayes_Linear(Nothing, False)
        Dim test As Boolean = False
        Dim curs1 = bbl.TestGetSubafdelingen(curs)

        Assert.AreEqual("ACC", curs1(2))
    End Sub

    <TestMethod()> Public Sub TestListOfSubafdelingenContainsKey3()
        Dim curs As New List(Of Cursus)
        curs.Add(New Cursus("", "", -1, "", "JUR", -1, -1, -1, -1, -1, Nothing, Nothing, Nothing, ""))
        curs.Add(New Cursus("", "", -1, "", "JUR", -1, -1, -1, -1, -1, Nothing, Nothing, Nothing, ""))
        curs.Add(New Cursus("", "", -1, "", "JUR", -1, -1, -1, -1, -1, Nothing, Nothing, Nothing, ""))
        curs.Add(New Cursus("", "", -1, "", "AB", -1, -1, -1, -1, -1, Nothing, Nothing, Nothing, ""))
        curs.Add(New Cursus("", "", -1, "", "ACC", -1, -1, -1, -1, -1, Nothing, Nothing, Nothing, ""))
        curs.Add(New Cursus("", "", -1, "", "ACC", -1, -1, -1, -1, -1, Nothing, Nothing, Nothing, ""))
        curs.Add(New Cursus("", "", -1, "", "HSD", -1, -1, -1, -1, -1, Nothing, Nothing, Nothing, ""))
        curs.Add(New Cursus("", "", -1, "", "HW", -1, -1, -1, -1, -1, Nothing, Nothing, Nothing, ""))

        Dim bbl As New Bayes_Bayes_Linear(Nothing, False)
        Dim test As Boolean = False
        Dim curs1 = bbl.TestGetSubafdelingen(curs)

        Assert.AreEqual("ACC", curs1(2))
    End Sub

    <TestMethod()> Public Sub TestListOfSubafdelingenContainsKey4()
        Dim curs As New List(Of Cursus)
        curs.Add(New Cursus("", "", -1, "", "JUR", -1, -1, -1, -1, -1, Nothing, Nothing, Nothing, ""))
        curs.Add(New Cursus("", "", -1, "", "JUR", -1, -1, -1, -1, -1, Nothing, Nothing, Nothing, ""))
        curs.Add(New Cursus("", "", -1, "", "JUR", -1, -1, -1, -1, -1, Nothing, Nothing, Nothing, ""))
        curs.Add(New Cursus("", "", -1, "", "AB", -1, -1, -1, -1, -1, Nothing, Nothing, Nothing, ""))
        curs.Add(New Cursus("", "", -1, "", "ACC", -1, -1, -1, -1, -1, Nothing, Nothing, Nothing, ""))
        curs.Add(New Cursus("", "", -1, "", "ACC", -1, -1, -1, -1, -1, Nothing, Nothing, Nothing, ""))
        curs.Add(New Cursus("", "", -1, "", "HSD", -1, -1, -1, -1, -1, Nothing, Nothing, Nothing, ""))
        curs.Add(New Cursus("", "", -1, "", "HW", -1, -1, -1, -1, -1, Nothing, Nothing, Nothing, ""))

        Dim bbl As New Bayes_Bayes_Linear(Nothing, False)
        Dim test As Boolean = False
        Dim curs1 = bbl.TestGetSubafdelingen(curs)

        Assert.AreEqual("HW", curs1(4))
    End Sub

    <TestMethod()> Public Sub TestListOfSubafdelingen2()
        Dim curs As New List(Of Cursus)
        curs.Add(New Cursus("", "", -1, "", "JUR", -1, -1, -1, -1, -1, Nothing, Nothing, Nothing, ""))
        curs.Add(New Cursus("", "", -1, "", "JUR", -1, -1, -1, -1, -1, Nothing, Nothing, Nothing, ""))
        curs.Add(New Cursus("", "", -1, "", "JUR", -1, -1, -1, -1, -1, Nothing, Nothing, Nothing, ""))
        curs.Add(New Cursus("", "", -1, "", "AB", -1, -1, -1, -1, -1, Nothing, Nothing, Nothing, ""))
        curs.Add(New Cursus("", "", -1, "", "ACC", -1, -1, -1, -1, -1, Nothing, Nothing, Nothing, ""))
        curs.Add(New Cursus("", "", -1, "", "ACC", -1, -1, -1, -1, -1, Nothing, Nothing, Nothing, ""))
        curs.Add(New Cursus("", "", -1, "", "HSD", -1, -1, -1, -1, -1, Nothing, Nothing, Nothing, ""))
        curs.Add(New Cursus("", "", -1, "", "HW", -1, -1, -1, -1, -1, Nothing, Nothing, Nothing, ""))

        Dim bbl As New Bayes_Bayes_Linear(Nothing, False)

        Assert.AreEqual(5, bbl.TestGetSubafdelingen(curs).count)
    End Sub

    <TestMethod()> Public Sub TestListOfSubafdelingenEmpty()
        Dim curs As New List(Of Cursus)
        Dim bbl As New Bayes_Bayes_Linear(Nothing, False)

        Assert.AreEqual(0, bbl.TestGetSubafdelingen(curs).count)
    End Sub

    <TestMethod()> Public Sub TestGetListOfCentra1()
        Dim curs As New List(Of Cursus)
        curs.Add(New Cursus("", "Syntra West Brugge", -1, "", "", -1, -1, -1, -1, -1, Nothing, Nothing, Nothing, ""))

        Dim bbl As New Bayes_Bayes_Linear(Nothing, False)

        Assert.AreEqual(1, bbl.TestGetSubafdelingen(curs).count)
    End Sub

    <TestMethod()> Public Sub TestGetListOfCentra2()
        Dim curs As New List(Of Cursus)
        curs.Add(New Cursus("", "Syntra West Brugge", -1, "", "", -1, -1, -1, -1, -1, Nothing, Nothing, Nothing, ""))

        Dim bbl As New Bayes_Bayes_Linear(Nothing, False)
        Dim uitv = bbl.TestGetUitvoercentrum(curs)
        Assert.AreEqual("Syntra West Brugge", uitv(0))
    End Sub

    <TestMethod()> Public Sub TestGetListOfCentra3()
        Dim curs As New List(Of Cursus)
        curs.Add(New Cursus("", "Syntra West Brugge", -1, "", "", -1, -1, -1, -1, -1, Nothing, Nothing, Nothing, ""))
        curs.Add(New Cursus("", "Syntra West Brugge", -1, "", "", -1, -1, -1, -1, -1, Nothing, Nothing, Nothing, ""))
        curs.Add(New Cursus("", "Syntra West Kortrijk", -1, "", "", -1, -1, -1, -1, -1, Nothing, Nothing, Nothing, ""))

        Dim bbl As New Bayes_Bayes_Linear(Nothing, False)
        Dim uitv = bbl.TestGetUitvoercentrum(curs)

        Assert.AreEqual("Syntra West Kortrijk", uitv(1))
    End Sub

    <TestMethod()> Public Sub TestGetListOfCentra4()
        Dim curs As New List(Of Cursus)
        curs.Add(New Cursus("", "Syntra West Brugge", -1, "", "", -1, -1, -1, -1, -1, Nothing, Nothing, Nothing, ""))
        curs.Add(New Cursus("", "Syntra West Brugge", -1, "", "", -1, -1, -1, -1, -1, Nothing, Nothing, Nothing, ""))
        curs.Add(New Cursus("", "Syntra West Brugge", -1, "", "", -1, -1, -1, -1, -1, Nothing, Nothing, Nothing, ""))
        curs.Add(New Cursus("", "Syntra West Kortrijk", -1, "", "", -1, -1, -1, -1, -1, Nothing, Nothing, Nothing, ""))
        curs.Add(New Cursus("", "Syntra West Ieper", -1, "", "", -1, -1, -1, -1, -1, Nothing, Nothing, Nothing, ""))
        curs.Add(New Cursus("", "Syntra West Kortrijk", -1, "", "", -1, -1, -1, -1, -1, Nothing, Nothing, Nothing, ""))

        Dim bbl As New Bayes_Bayes_Linear(Nothing, False)
        Dim uitv = bbl.TestGetUitvoercentrum(curs)

        Assert.AreEqual("Syntra West Kortrijk", uitv(1))
    End Sub

    <TestMethod()> Public Sub TestGetListOfCentra5()
        Dim curs As New List(Of Cursus)
        curs.Add(New Cursus("", "Syntra West Brugge", -1, "", "", -1, -1, -1, -1, -1, Nothing, Nothing, Nothing, ""))
        curs.Add(New Cursus("", "Syntra West Brugge", -1, "", "", -1, -1, -1, -1, -1, Nothing, Nothing, Nothing, ""))
        curs.Add(New Cursus("", "Syntra West Brugge", -1, "", "", -1, -1, -1, -1, -1, Nothing, Nothing, Nothing, ""))
        curs.Add(New Cursus("", "Syntra West Kortrijk", -1, "", "", -1, -1, -1, -1, -1, Nothing, Nothing, Nothing, ""))
        curs.Add(New Cursus("", "Syntra West Ieper", -1, "", "", -1, -1, -1, -1, -1, Nothing, Nothing, Nothing, ""))
        curs.Add(New Cursus("", "Syntra West Kortrijk", -1, "", "", -1, -1, -1, -1, -1, Nothing, Nothing, Nothing, ""))

        Dim bbl As New Bayes_Bayes_Linear(Nothing, False)
        Dim uitv = bbl.TestGetUitvoercentrum(curs)

        Assert.AreEqual("Syntra West Ieper", uitv(2))
    End Sub

    <TestMethod()> Public Sub TestGetListOfCentra6()
        Dim curs As New List(Of Cursus)
        curs.Add(New Cursus("", "Syntra West Brugge", -1, "", "", -1, -1, -1, -1, -1, Nothing, Nothing, Nothing, ""))
        curs.Add(New Cursus("", "Syntra West Brugge", -1, "", "", -1, -1, -1, -1, -1, Nothing, Nothing, Nothing, ""))
        curs.Add(New Cursus("", "Syntra West Brugge", -1, "", "", -1, -1, -1, -1, -1, Nothing, Nothing, Nothing, ""))
        curs.Add(New Cursus("", "Syntra West Kortrijk", -1, "", "", -1, -1, -1, -1, -1, Nothing, Nothing, Nothing, ""))
        curs.Add(New Cursus("", "Syntra West Ieper", -1, "", "", -1, -1, -1, -1, -1, Nothing, Nothing, Nothing, ""))
        curs.Add(New Cursus("", "Syntra West Kortrijk", -1, "", "", -1, -1, -1, -1, -1, Nothing, Nothing, Nothing, ""))

        Dim bbl As New Bayes_Bayes_Linear(Nothing, False)
        Dim uitv = bbl.TestGetUitvoercentrum(curs)

        Assert.AreEqual(3, bbl.TestGetUitvoercentrum(curs).count)
    End Sub

    <TestMethod()> Public Sub TestGetListOfMerk1()
        Dim curs As New List(Of Cursus)
        curs.Add(New Cursus("Syntra West", "", -1, "", "", -1, -1, -1, -1, -1, Nothing, Nothing, Nothing, ""))

        Dim bbl As New Bayes_Bayes_Linear(Nothing, False)
        bbl.setListOfAllItems(curs)
        Dim merken = bbl.getMerken()

        Assert.AreEqual(1, merken.Count)
    End Sub

    <TestMethod()> Public Sub TestGetListOfMerk2()
        Dim curs As New List(Of Cursus)

        Dim bbl As New Bayes_Bayes_Linear(Nothing, False)
        bbl.setListOfAllItems(curs)
        Dim merken = bbl.getMerken()

        Assert.AreEqual(0, merken.Count)
    End Sub

    <TestMethod()> Public Sub TestGetListOfMerk3()
        Dim curs As New List(Of Cursus)
        curs.Add(New Cursus("Syntra West", "", -1, "", "", -1, -1, -1, -1, -1, Nothing, Nothing, Nothing, ""))
        curs.Add(New Cursus("Syntra West", "", -1, "", "", -1, -1, -1, -1, -1, Nothing, Nothing, Nothing, ""))
        curs.Add(New Cursus("EVW", "", -1, "", "", -1, -1, -1, -1, -1, Nothing, Nothing, Nothing, ""))
        curs.Add(New Cursus("Escala", "", -1, "", "", -1, -1, -1, -1, -1, Nothing, Nothing, Nothing, ""))
        curs.Add(New Cursus("SBM", "", -1, "", "", -1, -1, -1, -1, -1, Nothing, Nothing, Nothing, ""))
        curs.Add(New Cursus("Syntra West", "", -1, "", "", -1, -1, -1, -1, -1, Nothing, Nothing, Nothing, ""))

        Dim bbl As New Bayes_Bayes_Linear(Nothing, False)
        bbl.setListOfAllItems(curs)
        Dim merken = bbl.getMerken()

        Assert.AreEqual(4, merken.Count)
    End Sub

    <TestMethod()> Public Sub TestGetListOfMerk4()
        Dim curs As New List(Of Cursus)
        curs.Add(New Cursus("Syntra West", "", -1, "", "", -1, -1, -1, -1, -1, Nothing, Nothing, Nothing, ""))
        curs.Add(New Cursus("Syntra West", "", -1, "", "", -1, -1, -1, -1, -1, Nothing, Nothing, Nothing, ""))
        curs.Add(New Cursus("EVW", "", -1, "", "", -1, -1, -1, -1, -1, Nothing, Nothing, Nothing, ""))
        curs.Add(New Cursus("Escala", "", -1, "", "", -1, -1, -1, -1, -1, Nothing, Nothing, Nothing, ""))
        curs.Add(New Cursus("Escala", "", -1, "", "", -1, -1, -1, -1, -1, Nothing, Nothing, Nothing, ""))
        curs.Add(New Cursus("SBM", "", -1, "", "", -1, -1, -1, -1, -1, Nothing, Nothing, Nothing, ""))
        curs.Add(New Cursus("Syntra West", "", -1, "", "", -1, -1, -1, -1, -1, Nothing, Nothing, Nothing, ""))

        Dim bbl As New Bayes_Bayes_Linear(Nothing, False)
        bbl.setListOfAllItems(curs)
        Dim merken = bbl.getMerken()

        Assert.AreEqual("EVW", merken(1))
    End Sub

    <TestMethod()> Public Sub TestGetListOfMerk5()
        Dim curs As New List(Of Cursus)
        curs.Add(New Cursus("Syntra West", "", -1, "", "", -1, -1, -1, -1, -1, Nothing, Nothing, Nothing, ""))
        curs.Add(New Cursus("Syntra West", "", -1, "", "", -1, -1, -1, -1, -1, Nothing, Nothing, Nothing, ""))
        curs.Add(New Cursus("EVW", "", -1, "", "", -1, -1, -1, -1, -1, Nothing, Nothing, Nothing, ""))
        curs.Add(New Cursus("Escala", "", -1, "", "", -1, -1, -1, -1, -1, Nothing, Nothing, Nothing, ""))
        curs.Add(New Cursus("SBM", "", -1, "", "", -1, -1, -1, -1, -1, Nothing, Nothing, Nothing, ""))
        curs.Add(New Cursus("Syntra West", "", -1, "", "", -1, -1, -1, -1, -1, Nothing, Nothing, Nothing, ""))

        Dim bbl As New Bayes_Bayes_Linear(Nothing, False)
        bbl.setListOfAllItems(curs)
        Dim merken = bbl.getMerken()

        Assert.AreEqual("Syntra West", merken(0))
    End Sub

    <TestMethod()> Public Sub TestIsVoorspellingslijstCorrect1()
        Dim curs As New List(Of Cursus)
        Dim afw As New List(Of Afwijking)
        afw.Add(New Afwijking(0.995, 2))
        afw.Add(New Afwijking(0.99, 3))
        afw.Add(New Afwijking(0.975, 5))
        afw.Add(New Afwijking(0.95, 7))
        afw.Add(New Afwijking(0.9, 10))
        curs.Add(New Cursus("", "", -1, "", "", 10, 7, 0.7, -1, -1, afw, Nothing, False, ""))

        Dim root As New MainScreen
        Dim bbl As New Bayes_Bayes_Linear(root, False)
        root.setTVerdeling(0)
        curs = bbl.TestIsVoorspellingsLijstCorrect(curs)

        Assert.IsTrue(curs(0).getIsCorrect)
    End Sub

    <TestMethod()> Public Sub TestIsVoorspellingslijstCorrect2()
        Dim curs As New List(Of Cursus)
        Dim afw As New List(Of Afwijking)
        afw.Add(New Afwijking(0.995, 2))
        afw.Add(New Afwijking(0.99, 3))
        afw.Add(New Afwijking(0.975, 5))
        afw.Add(New Afwijking(0.95, 7))
        afw.Add(New Afwijking(0.9, 10))
        curs.Add(New Cursus("", "", -1, "", "", 10, 7, 0.7, -1, -1, afw, Nothing, False, ""))

        Dim root As New MainScreen
        Dim bbl As New Bayes_Bayes_Linear(root, False)
        root.setTVerdeling(4)
        curs = bbl.TestIsVoorspellingsLijstCorrect(curs)

        Assert.IsTrue(curs(0).getIsCorrect)
    End Sub

    <TestMethod()> Public Sub TestIsVoorspellingslijstCorrect3()
        Dim curs As New List(Of Cursus)
        Dim afw As New List(Of Afwijking)
        afw.Add(New Afwijking(0.995, 2))
        afw.Add(New Afwijking(0.99, 3))
        afw.Add(New Afwijking(0.975, 5))
        afw.Add(New Afwijking(0.95, 7))
        afw.Add(New Afwijking(0.9, 10))
        curs.Add(New Cursus("", "", -1, "", "", 10, 7, 0.75, -1, -1, afw, Nothing, False, ""))

        Dim root As New MainScreen
        Dim bbl As New Bayes_Bayes_Linear(root, False)
        root.setTVerdeling(1)
        curs = bbl.TestIsVoorspellingsLijstCorrect(curs)

        Assert.IsFalse(curs(0).getIsCorrect)
    End Sub

    <TestMethod()> Public Sub TestIsVoorspellingslijstCorrect4()
        Dim curs As New List(Of Cursus)
        Dim afw As New List(Of Afwijking)
        afw.Add(New Afwijking(0.995, 2))
        afw.Add(New Afwijking(0.99, 3))
        afw.Add(New Afwijking(0.975, 5))
        afw.Add(New Afwijking(0.95, 7))
        afw.Add(New Afwijking(0.9, 10))
        curs.Add(New Cursus("", "", -1, "", "", 10, 7, 0.75, -1, -1, afw, Nothing, False, ""))

        Dim root As New MainScreen
        Dim bbl As New Bayes_Bayes_Linear(root, False)
        root.setTVerdeling(3)
        curs = bbl.TestIsVoorspellingsLijstCorrect(curs)

        Assert.IsTrue(curs(0).getIsCorrect)
    End Sub

    <TestMethod()> Public Sub TestIsVoorspellingslijstCorrect5()
        Dim curs As New List(Of Cursus)
        Dim afw As New List(Of Afwijking)
        afw.Add(New Afwijking(0.995, 20))
        afw.Add(New Afwijking(0.99, 30))
        afw.Add(New Afwijking(0.975, 50))
        afw.Add(New Afwijking(0.95, 70))
        afw.Add(New Afwijking(0.9, 100))
        curs.Add(New Cursus("", "", -1, "", "", 10, 2, 0.75, -1, -1, afw, Nothing, False, ""))

        Dim root As New MainScreen
        Dim bbl As New Bayes_Bayes_Linear(root, False)
        root.setTVerdeling(2)
        curs = bbl.TestIsVoorspellingsLijstCorrect(curs)

        Assert.IsFalse(curs(0).getIsCorrect)
    End Sub

    <TestMethod()> Public Sub TestIsVoorspellingslijstCorrect6()
        Dim curs As New List(Of Cursus)
        Dim afw As New List(Of Afwijking)
        afw.Add(New Afwijking(0.995, 20))
        afw.Add(New Afwijking(0.99, 30))
        afw.Add(New Afwijking(0.975, 50))
        afw.Add(New Afwijking(0.95, 70))
        afw.Add(New Afwijking(0.9, 100))
        curs.Add(New Cursus("", "", -1, "", "", 10, 2, 0.75, -1, -1, afw, Nothing, False, ""))

        Dim root As New MainScreen
        Dim bbl As New Bayes_Bayes_Linear(root, False)
        root.setTVerdeling(2)
        curs = bbl.TestIsVoorspellingsLijstCorrect(curs)

        Assert.IsFalse(curs(0).getIsCorrect)
    End Sub

    <TestMethod()> Public Sub TestIsVoorspellingslijstCorrect7()
        Dim curs As New List(Of Cursus)
        Dim afw As New List(Of Afwijking)
        afw.Add(New Afwijking(0.995, 20))
        afw.Add(New Afwijking(0.99, 30))
        afw.Add(New Afwijking(0.975, 50))
        afw.Add(New Afwijking(0.95, 70))
        afw.Add(New Afwijking(0.9, 100))
        curs.Add(New Cursus("", "", -1, "", "", 10, 2, 0.75, -1, -1, afw, Nothing, False, ""))

        Dim root As New MainScreen
        Dim bbl As New Bayes_Bayes_Linear(root, False)
        root.setTVerdeling(4)
        curs = bbl.TestIsVoorspellingsLijstCorrect(curs)

        Assert.IsTrue(curs(0).getIsCorrect)
    End Sub

    <TestMethod()> Public Sub TestIsVoorspellingslijstCorrect8()
        Dim curs As New List(Of Cursus)
        Dim afw As New List(Of Afwijking)
        afw.Add(New Afwijking(0.995, 20))
        afw.Add(New Afwijking(0.99, 30))
        afw.Add(New Afwijking(0.975, 50))
        afw.Add(New Afwijking(0.95, 70))
        afw.Add(New Afwijking(0.9, 100))
        curs.Add(New Cursus("", "", -1, "", "", 10, 2, 0.75, -1, -1, afw, Nothing, False, ""))

        Dim root As New MainScreen
        Dim bbl As New Bayes_Bayes_Linear(root, False)
        root.setTVerdeling(4)
        curs = bbl.TestIsVoorspellingsLijstCorrect(curs)

        Assert.IsTrue(curs(0).getIsCorrect)
    End Sub

    <TestMethod()> Public Sub TestIsVoorspellingslijstCorrect9()
        Dim curs As New List(Of Cursus)
        Dim afw As New List(Of Afwijking)
        afw.Add(New Afwijking(0.995, 10))
        afw.Add(New Afwijking(0.99, 30))
        afw.Add(New Afwijking(0.975, 50))
        afw.Add(New Afwijking(0.95, 70))
        afw.Add(New Afwijking(0.9, 100))
        curs.Add(New Cursus("", "", -1, "", "", 10, 2, 0.75, -1, -1, afw, Nothing, False, ""))
        curs.Add(New Cursus("", "", -1, "", "", 10, 8, 0.63, -1, -1, afw, Nothing, False, ""))

        Dim root As New MainScreen
        Dim bbl As New Bayes_Bayes_Linear(root, False)
        root.setTVerdeling(0)
        curs = bbl.TestIsVoorspellingsLijstCorrect(curs)

        Assert.IsFalse(curs(1).getIsCorrect)
    End Sub

    <TestMethod()> Public Sub TestIsVoorspellingslijstCorrect10()
        Dim curs As New List(Of Cursus)
        Dim afw As New List(Of Afwijking)
        afw.Add(New Afwijking(0.995, 10))
        afw.Add(New Afwijking(0.99, 30))
        afw.Add(New Afwijking(0.975, 50))
        afw.Add(New Afwijking(0.95, 70))
        afw.Add(New Afwijking(0.9, 100))
        curs.Add(New Cursus("", "", -1, "", "", 10, 2, 0.75, -1, -1, afw, Nothing, False, ""))
        curs.Add(New Cursus("", "", -1, "", "", 10, 8, 0.63, -1, -1, afw, Nothing, False, ""))

        Dim root As New MainScreen
        Dim bbl As New Bayes_Bayes_Linear(root, False)
        root.setTVerdeling(1)
        curs = bbl.TestIsVoorspellingsLijstCorrect(curs)

        Assert.IsTrue(curs(1).getIsCorrect)
    End Sub

    <TestMethod()> Public Sub TestAfwijkingBerekenen1()
        Dim curs As New List(Of Cursus)
        curs.Add(New Cursus("", "", -1, "", "", 5, 1, 0.85, -1, -1, Nothing, Nothing, False, ""))
        curs.Add(New Cursus("", "", -1, "", "", 10, 8, 0.63, -1, -1, Nothing, Nothing, False, ""))
        curs.Add(New Cursus("", "", -1, "", "", 50, 8, 0.2, -1, -1, Nothing, Nothing, False, ""))

        Dim root As New MainScreen
        Dim bbl As New Bayes_Bayes_Linear(root, False)
        root.setTVerdeling(1)
        bbl.alleAfwijkingenVerwerken(curs)
        curs = bbl.TestAfwijkingBerekenen(curs)
        curs = bbl.TestIsVoorspellingsLijstCorrect(curs)

        Assert.IsTrue(curs(2).getIsCorrect)
    End Sub

    <TestMethod()> Public Sub TestAfwijkingBerekenen2()
        Dim curs As New List(Of Cursus)
        curs.Add(New Cursus("", "", -1, "", "", 5, 1, 0.85, -1, -1, Nothing, Nothing, False, ""))
        curs.Add(New Cursus("", "", -1, "", "", 10, 8, 0.63, -1, -1, Nothing, Nothing, False, ""))
        curs.Add(New Cursus("", "", -1, "", "", 50, 8, 0.2, -1, -1, Nothing, Nothing, False, ""))

        Dim root As New MainScreen
        Dim bbl As New Bayes_Bayes_Linear(root, False)
        root.setTVerdeling(4)
        bbl.alleAfwijkingenVerwerken(curs)
        curs = bbl.TestAfwijkingBerekenen(curs)
        curs = bbl.TestIsVoorspellingsLijstCorrect(curs)

        Assert.IsFalse(curs(0).getIsCorrect)
    End Sub
    <TestMethod()> Public Sub TestCalculateStandardDeviation()
        Dim data As New List(Of Double)
        data.AddRange({0.5, 0.75, 0.948, 0.14, 0.235, 0.748})

        Assert.AreEqual(0.29079, Math.Round(New Bayes_Bayes_Linear(Nothing, False).TestCalculateStandardDeviation(data)), 5)
    End Sub

    <TestMethod()> Public Sub TestResetCursusList1()
        Dim cursList As New List(Of Cursus)
        Dim afwL As New List(Of Afwijking)
        afwL.Add(New Afwijking(0.995, 11.45))
        afwL.Add(New Afwijking(0.99, 17.84))
        afwL.Add(New Afwijking(0.975, 29.15))
        afwL.Add(New Afwijking(0.95, 40.13))
        afwL.Add(New Afwijking(0.9, 53.7))
        cursList.Add(New Cursus("Syntra West", "Syntra West Brugge", 7, "Dinsdag", "NL", 14, 11, 0.8, 2014, 12.14, afwL, Algoritmes.BayesLinear, True, Nothing))

        afwL = New List(Of Afwijking)
        afwL.Add(New Afwijking(0.995, 5.36))
        afwL.Add(New Afwijking(0.99, 6.25))
        afwL.Add(New Afwijking(0.975, 10.84))
        afwL.Add(New Afwijking(0.95, 17.3))
        afwL.Add(New Afwijking(0.9, 28.71))
        cursList.Add(New Cursus("Escala", "Syntra West Kortrijk", 1, "Vrijdag", "INS", 34, 7, 0.347, Nothing, Nothing, afwL, Algoritmes.BayesMerk, False, "HGS"))

        Dim bbl As New Bayes_Bayes_Linear(Nothing, False)
        cursList = bbl.TestResetCursusList(cursList)
        Assert.AreEqual("Syntra West", cursList(0).getMerk)
    End Sub

    <TestMethod()> Public Sub TestResetCursusList2()
        Dim cursList As New List(Of Cursus)
        Dim afwL As New List(Of Afwijking)
        afwL.Add(New Afwijking(0.995, 11.45))
        afwL.Add(New Afwijking(0.99, 17.84))
        afwL.Add(New Afwijking(0.975, 29.15))
        afwL.Add(New Afwijking(0.95, 40.13))
        afwL.Add(New Afwijking(0.9, 53.7))
        cursList.Add(New Cursus("Syntra West", "Syntra West Brugge", 7, "Dinsdag", "NL", 14, 11, 0.8, 2014, 12.14, afwL, Algoritmes.BayesLinear, True, Nothing))

        afwL = New List(Of Afwijking)
        afwL.Add(New Afwijking(0.995, 5.36))
        afwL.Add(New Afwijking(0.99, 6.25))
        afwL.Add(New Afwijking(0.975, 10.84))
        afwL.Add(New Afwijking(0.95, 17.3))
        afwL.Add(New Afwijking(0.9, 28.71))
        cursList.Add(New Cursus("Escala", "Syntra West Kortrijk", 1, "Vrijdag", "INS", 34, 7, 0.347, Nothing, Nothing, afwL, Algoritmes.BayesMerk, False, "HGS"))

        Dim bbl As New Bayes_Bayes_Linear(Nothing, False)
        cursList = bbl.TestResetCursusList(cursList)
        Assert.AreEqual("Syntra West Brugge", cursList(0).getUitvoerCentrum)
    End Sub

    <TestMethod()> Public Sub TestResetCursusList3()
        Dim cursList As New List(Of Cursus)
        Dim afwL As New List(Of Afwijking)
        afwL.Add(New Afwijking(0.995, 11.45))
        afwL.Add(New Afwijking(0.99, 17.84))
        afwL.Add(New Afwijking(0.975, 29.15))
        afwL.Add(New Afwijking(0.95, 40.13))
        afwL.Add(New Afwijking(0.9, 53.7))
        cursList.Add(New Cursus("Syntra West", "Syntra West Brugge", 7, "Dinsdag", "NL", 14, 11, 0.8, 2014, 12.14, afwL, Algoritmes.BayesLinear, True, Nothing))

        afwL = New List(Of Afwijking)
        afwL.Add(New Afwijking(0.995, 5.36))
        afwL.Add(New Afwijking(0.99, 6.25))
        afwL.Add(New Afwijking(0.975, 10.84))
        afwL.Add(New Afwijking(0.95, 17.3))
        afwL.Add(New Afwijking(0.9, 28.71))
        cursList.Add(New Cursus("Escala", "Syntra West Kortrijk", 1, "Vrijdag", "INS", 34, 7, 0.347, Nothing, Nothing, afwL, Algoritmes.BayesMerk, False, "HGS"))

        Dim bbl As New Bayes_Bayes_Linear(Nothing, False)
        cursList = bbl.TestResetCursusList(cursList)
        Assert.AreEqual(7, cursList(0).getMaand)
    End Sub

    <TestMethod()> Public Sub TestResetCursusList4()
        Dim cursList As New List(Of Cursus)
        Dim afwL As New List(Of Afwijking)
        afwL.Add(New Afwijking(0.995, 11.45))
        afwL.Add(New Afwijking(0.99, 17.84))
        afwL.Add(New Afwijking(0.975, 29.15))
        afwL.Add(New Afwijking(0.95, 40.13))
        afwL.Add(New Afwijking(0.9, 53.7))
        cursList.Add(New Cursus("Syntra West", "Syntra West Brugge", 7, "Dinsdag", "NL", 14, 11, 0.8, 2014, 12.14, afwL, Algoritmes.BayesLinear, True, Nothing))

        afwL = New List(Of Afwijking)
        afwL.Add(New Afwijking(0.995, 5.36))
        afwL.Add(New Afwijking(0.99, 6.25))
        afwL.Add(New Afwijking(0.975, 10.84))
        afwL.Add(New Afwijking(0.95, 17.3))
        afwL.Add(New Afwijking(0.9, 28.71))
        cursList.Add(New Cursus("Escala", "Syntra West Kortrijk", 1, "Vrijdag", "INS", 34, 7, 0.347, Nothing, Nothing, afwL, Algoritmes.BayesMerk, False, "HGS"))

        Dim bbl As New Bayes_Bayes_Linear(Nothing, False)
        cursList = bbl.TestResetCursusList(cursList)
        Assert.AreEqual("Dinsdag", cursList(0).getDag)
    End Sub

    <TestMethod()> Public Sub TestResetCursusList5()
        Dim cursList As New List(Of Cursus)
        Dim afwL As New List(Of Afwijking)
        afwL.Add(New Afwijking(0.995, 11.45))
        afwL.Add(New Afwijking(0.99, 17.84))
        afwL.Add(New Afwijking(0.975, 29.15))
        afwL.Add(New Afwijking(0.95, 40.13))
        afwL.Add(New Afwijking(0.9, 53.7))
        cursList.Add(New Cursus("Syntra West", "Syntra West Brugge", 7, "Dinsdag", "NL", 14, 11, 0.8, 2014, 12.14, afwL, Algoritmes.BayesLinear, True, Nothing))

        afwL = New List(Of Afwijking)
        afwL.Add(New Afwijking(0.995, 5.36))
        afwL.Add(New Afwijking(0.99, 6.25))
        afwL.Add(New Afwijking(0.975, 10.84))
        afwL.Add(New Afwijking(0.95, 17.3))
        afwL.Add(New Afwijking(0.9, 28.71))
        cursList.Add(New Cursus("Escala", "Syntra West Kortrijk", 1, "Vrijdag", "INS", 34, 7, 0.347, Nothing, Nothing, afwL, Algoritmes.BayesMerk, False, "HGS"))

        Dim bbl As New Bayes_Bayes_Linear(Nothing, False)
        cursList = bbl.TestResetCursusList(cursList)
        Assert.AreEqual("NL", cursList(0).getCodeSubafdeling)
    End Sub

    <TestMethod()> Public Sub TestResetCursusList6()
        Dim cursList As New List(Of Cursus)
        Dim afwL As New List(Of Afwijking)
        afwL.Add(New Afwijking(0.995, 11.45))
        afwL.Add(New Afwijking(0.99, 17.84))
        afwL.Add(New Afwijking(0.975, 29.15))
        afwL.Add(New Afwijking(0.95, 40.13))
        afwL.Add(New Afwijking(0.9, 53.7))
        cursList.Add(New Cursus("Syntra West", "Syntra West Brugge", 7, "Dinsdag", "NL", 14, 11, 0.8, 2014, 12.14, afwL, Algoritmes.BayesLinear, True, Nothing))

        afwL = New List(Of Afwijking)
        afwL.Add(New Afwijking(0.995, 5.36))
        afwL.Add(New Afwijking(0.99, 6.25))
        afwL.Add(New Afwijking(0.975, 10.84))
        afwL.Add(New Afwijking(0.95, 17.3))
        afwL.Add(New Afwijking(0.9, 28.71))
        cursList.Add(New Cursus("Escala", "Syntra West Kortrijk", 1, "Vrijdag", "INS", 34, 7, 0.347, Nothing, Nothing, afwL, Algoritmes.BayesMerk, False, "HGS"))

        Dim bbl As New Bayes_Bayes_Linear(Nothing, False)
        cursList = bbl.TestResetCursusList(cursList)
        Assert.AreEqual(14, cursList(0).getTotaal)
    End Sub

    <TestMethod()> Public Sub TestResetCursusList7()
        Dim cursList As New List(Of Cursus)
        Dim afwL As New List(Of Afwijking)
        afwL.Add(New Afwijking(0.995, 11.45))
        afwL.Add(New Afwijking(0.99, 17.84))
        afwL.Add(New Afwijking(0.975, 29.15))
        afwL.Add(New Afwijking(0.95, 40.13))
        afwL.Add(New Afwijking(0.9, 53.7))
        cursList.Add(New Cursus("Syntra West", "Syntra West Brugge", 7, "Dinsdag", "NL", 14, 11, 0.8, 2014, 12.14, afwL, Algoritmes.BayesLinear, True, Nothing))

        afwL = New List(Of Afwijking)
        afwL.Add(New Afwijking(0.995, 5.36))
        afwL.Add(New Afwijking(0.99, 6.25))
        afwL.Add(New Afwijking(0.975, 10.84))
        afwL.Add(New Afwijking(0.95, 17.3))
        afwL.Add(New Afwijking(0.9, 28.71))
        cursList.Add(New Cursus("Escala", "Syntra West Kortrijk", 1, "Vrijdag", "INS", 34, 7, 0.347, Nothing, Nothing, afwL, Algoritmes.BayesMerk, False, "HGS"))

        Dim bbl As New Bayes_Bayes_Linear(Nothing, False)
        cursList = bbl.TestResetCursusList(cursList)
        Assert.AreEqual(11, cursList(0).getAantalDoorgegaan)
    End Sub

    <TestMethod()> Public Sub TestResetCursusList8()
        Dim cursList As New List(Of Cursus)
        Dim afwL As New List(Of Afwijking)
        afwL.Add(New Afwijking(0.995, 11.45))
        afwL.Add(New Afwijking(0.99, 17.84))
        afwL.Add(New Afwijking(0.975, 29.15))
        afwL.Add(New Afwijking(0.95, 40.13))
        afwL.Add(New Afwijking(0.9, 53.7))
        cursList.Add(New Cursus("Syntra West", "Syntra West Brugge", 7, "Dinsdag", "NL", 14, 11, 0.8, 2014, 12.14, afwL, Algoritmes.BayesLinear, True, Nothing))

        afwL = New List(Of Afwijking)
        afwL.Add(New Afwijking(0.995, 5.36))
        afwL.Add(New Afwijking(0.99, 6.25))
        afwL.Add(New Afwijking(0.975, 10.84))
        afwL.Add(New Afwijking(0.95, 17.3))
        afwL.Add(New Afwijking(0.9, 28.71))
        cursList.Add(New Cursus("Escala", "Syntra West Kortrijk", 1, "Vrijdag", "INS", 34, 7, 0.347, Nothing, Nothing, afwL, Algoritmes.BayesMerk, False, "HGS"))

        Dim bbl As New Bayes_Bayes_Linear(Nothing, False)
        cursList = bbl.TestResetCursusList(cursList)
        Assert.AreEqual(-1.01, cursList(0).getKans)
    End Sub

    <TestMethod()> Public Sub TestResetCursusList9()
        Dim cursList As New List(Of Cursus)
        Dim afwL As New List(Of Afwijking)
        afwL.Add(New Afwijking(0.995, 11.45))
        afwL.Add(New Afwijking(0.99, 17.84))
        afwL.Add(New Afwijking(0.975, 29.15))
        afwL.Add(New Afwijking(0.95, 40.13))
        afwL.Add(New Afwijking(0.9, 53.7))
        cursList.Add(New Cursus("Syntra West", "Syntra West Brugge", 7, "Dinsdag", "NL", 14, 11, 0.8, 2014, 12.14, afwL, Algoritmes.BayesLinear, True, Nothing))

        afwL = New List(Of Afwijking)
        afwL.Add(New Afwijking(0.995, 5.36))
        afwL.Add(New Afwijking(0.99, 6.25))
        afwL.Add(New Afwijking(0.975, 10.84))
        afwL.Add(New Afwijking(0.95, 17.3))
        afwL.Add(New Afwijking(0.9, 28.71))
        cursList.Add(New Cursus("Escala", "Syntra West Kortrijk", 1, "Vrijdag", "INS", 34, 7, 0.347, Nothing, Nothing, afwL, Algoritmes.BayesMerk, False, "HGS"))

        Dim bbl As New Bayes_Bayes_Linear(Nothing, False)
        cursList = bbl.TestResetCursusList(cursList)
        Assert.AreEqual(2014, cursList(0).getJaar)
    End Sub

    <TestMethod()> Public Sub TestResetCursusList10()
        Dim cursList As New List(Of Cursus)
        Dim afwL As New List(Of Afwijking)
        afwL.Add(New Afwijking(0.995, 11.45))
        afwL.Add(New Afwijking(0.99, 17.84))
        afwL.Add(New Afwijking(0.975, 29.15))
        afwL.Add(New Afwijking(0.95, 40.13))
        afwL.Add(New Afwijking(0.9, 53.7))
        cursList.Add(New Cursus("Syntra West", "Syntra West Brugge", 7, "Dinsdag", "NL", 14, 11, 0.8, 2014, 12.14, afwL, Algoritmes.BayesLinear, True, Nothing))

        afwL = New List(Of Afwijking)
        afwL.Add(New Afwijking(0.995, 5.36))
        afwL.Add(New Afwijking(0.99, 6.25))
        afwL.Add(New Afwijking(0.975, 10.84))
        afwL.Add(New Afwijking(0.95, 17.3))
        afwL.Add(New Afwijking(0.9, 28.71))
        cursList.Add(New Cursus("Escala", "Syntra West Kortrijk", 1, "Vrijdag", "INS", 34, 7, 0.347, Nothing, Nothing, afwL, Algoritmes.BayesMerk, False, "HGS"))

        Dim bbl As New Bayes_Bayes_Linear(Nothing, False)
        cursList = bbl.TestResetCursusList(cursList)
        Assert.AreEqual(12.14, cursList(0).getB)
    End Sub

    <TestMethod()> Public Sub TestResetCursusList11()
        Dim cursList As New List(Of Cursus)
        Dim afwL As New List(Of Afwijking)
        afwL.Add(New Afwijking(0.995, 11.45))
        afwL.Add(New Afwijking(0.99, 17.84))
        afwL.Add(New Afwijking(0.975, 29.15))
        afwL.Add(New Afwijking(0.95, 40.13))
        afwL.Add(New Afwijking(0.9, 53.7))
        cursList.Add(New Cursus("Syntra West", "Syntra West Brugge", 7, "Dinsdag", "NL", 14, 11, 0.8, 2014, 12.14, afwL, Algoritmes.BayesLinear, True, Nothing))

        afwL = New List(Of Afwijking)
        afwL.Add(New Afwijking(0.995, 5.36))
        afwL.Add(New Afwijking(0.99, 6.25))
        afwL.Add(New Afwijking(0.975, 10.84))
        afwL.Add(New Afwijking(0.95, 17.3))
        afwL.Add(New Afwijking(0.9, 28.71))
        cursList.Add(New Cursus("Escala", "Syntra West Kortrijk", 1, "Vrijdag", "INS", 34, 7, 0.347, Nothing, Nothing, afwL, Algoritmes.BayesMerk, False, "HGS"))

        Dim bbl As New Bayes_Bayes_Linear(Nothing, False)
        cursList = bbl.TestResetCursusList(cursList)
        Assert.AreEqual(-101.0, cursList(0).getAfwijkingswaarde(0))
    End Sub

    <TestMethod()> Public Sub TestResetCursusList12()
        Dim cursList As New List(Of Cursus)
        Dim afwL As New List(Of Afwijking)
        afwL.Add(New Afwijking(0.995, 11.45))
        afwL.Add(New Afwijking(0.99, 17.84))
        afwL.Add(New Afwijking(0.975, 29.15))
        afwL.Add(New Afwijking(0.95, 40.13))
        afwL.Add(New Afwijking(0.9, 53.7))
        cursList.Add(New Cursus("Syntra West", "Syntra West Brugge", 7, "Dinsdag", "NL", 14, 11, 0.8, 2014, 12.14, afwL, Algoritmes.BayesLinear, True, Nothing))

        afwL = New List(Of Afwijking)
        afwL.Add(New Afwijking(0.995, 5.36))
        afwL.Add(New Afwijking(0.99, 6.25))
        afwL.Add(New Afwijking(0.975, 10.84))
        afwL.Add(New Afwijking(0.95, 17.3))
        afwL.Add(New Afwijking(0.9, 28.71))
        cursList.Add(New Cursus("Escala", "Syntra West Kortrijk", 1, "Vrijdag", "INS", 34, 7, 0.347, Nothing, Nothing, afwL, Algoritmes.BayesMerk, False, "HGS"))

        Dim bbl As New Bayes_Bayes_Linear(Nothing, False)
        cursList = bbl.TestResetCursusList(cursList)
        Assert.AreEqual(-101.0, cursList(0).getAfwijkingswaarde(3))
    End Sub

    <TestMethod()> Public Sub TestResetCursusList13()
        Dim cursList As New List(Of Cursus)
        Dim afwL As New List(Of Afwijking)
        afwL.Add(New Afwijking(0.995, 11.45))
        afwL.Add(New Afwijking(0.99, 17.84))
        afwL.Add(New Afwijking(0.975, 29.15))
        afwL.Add(New Afwijking(0.95, 40.13))
        afwL.Add(New Afwijking(0.9, 53.7))
        cursList.Add(New Cursus("Syntra West", "Syntra West Brugge", 7, "Dinsdag", "NL", 14, 11, 0.8, 2014, 12.14, afwL, Algoritmes.BayesLinear, True, Nothing))

        afwL = New List(Of Afwijking)
        afwL.Add(New Afwijking(0.995, 5.36))
        afwL.Add(New Afwijking(0.99, 6.25))
        afwL.Add(New Afwijking(0.975, 10.84))
        afwL.Add(New Afwijking(0.95, 17.3))
        afwL.Add(New Afwijking(0.9, 28.71))
        cursList.Add(New Cursus("Escala", "Syntra West Kortrijk", 1, "Vrijdag", "INS", 34, 7, 0.347, Nothing, Nothing, afwL, Algoritmes.BayesMerk, False, "HGS"))

        Dim bbl As New Bayes_Bayes_Linear(Nothing, False)
        cursList = bbl.TestResetCursusList(cursList)
        Assert.AreEqual(Algoritmes.Niets, cursList(0).getAlgoritme)
    End Sub

    <TestMethod()> Public Sub TestResetCursusList14()
        Dim cursList As New List(Of Cursus)
        Dim afwL As New List(Of Afwijking)
        afwL.Add(New Afwijking(0.995, 11.45))
        afwL.Add(New Afwijking(0.99, 17.84))
        afwL.Add(New Afwijking(0.975, 29.15))
        afwL.Add(New Afwijking(0.95, 40.13))
        afwL.Add(New Afwijking(0.9, 53.7))
        cursList.Add(New Cursus("Syntra West", "Syntra West Brugge", 7, "Dinsdag", "NL", 14, 11, 0.8, 2014, 12.14, afwL, Algoritmes.BayesLinear, True, Nothing))

        afwL = New List(Of Afwijking)
        afwL.Add(New Afwijking(0.995, 5.36))
        afwL.Add(New Afwijking(0.99, 6.25))
        afwL.Add(New Afwijking(0.975, 10.84))
        afwL.Add(New Afwijking(0.95, 17.3))
        afwL.Add(New Afwijking(0.9, 28.71))
        cursList.Add(New Cursus("Escala", "Syntra West Kortrijk", 1, "Vrijdag", "INS", 34, 7, 0.347, Nothing, Nothing, afwL, Algoritmes.BayesMerk, False, "HGS"))

        Dim bbl As New Bayes_Bayes_Linear(Nothing, False)
        cursList = bbl.TestResetCursusList(cursList)
        Assert.AreEqual(Nothing, cursList(0).getOntw)
    End Sub

    <TestMethod()> Public Sub TestResetCursusList15()
        Dim cursList As New List(Of Cursus)
        Dim afwL As New List(Of Afwijking)
        afwL.Add(New Afwijking(0.995, 11.45))
        afwL.Add(New Afwijking(0.99, 17.84))
        afwL.Add(New Afwijking(0.975, 29.15))
        afwL.Add(New Afwijking(0.95, 40.13))
        afwL.Add(New Afwijking(0.9, 53.7))
        cursList.Add(New Cursus("Syntra West", "Syntra West Brugge", 7, "Dinsdag", "NL", 14, 11, 0.8, 2014, 12.14, afwL, Algoritmes.BayesLinear, True, Nothing))

        afwL = New List(Of Afwijking)
        afwL.Add(New Afwijking(0.995, 5.36))
        afwL.Add(New Afwijking(0.99, 6.25))
        afwL.Add(New Afwijking(0.975, 10.84))
        afwL.Add(New Afwijking(0.95, 17.3))
        afwL.Add(New Afwijking(0.9, 28.71))
        cursList.Add(New Cursus("Escala", "Syntra West Kortrijk", 1, "Vrijdag", "INS", 34, 7, 0.347, Nothing, Nothing, afwL, Algoritmes.BayesMerk, False, "HGS"))

        Dim bbl As New Bayes_Bayes_Linear(Nothing, False)
        cursList = bbl.TestResetCursusList(cursList)
        Assert.AreEqual("Escala", cursList(1).getMerk)
    End Sub

    <TestMethod()> Public Sub TestResetCursusList16()
        Dim cursList As New List(Of Cursus)
        Dim afwL As New List(Of Afwijking)
        afwL.Add(New Afwijking(0.995, 11.45))
        afwL.Add(New Afwijking(0.99, 17.84))
        afwL.Add(New Afwijking(0.975, 29.15))
        afwL.Add(New Afwijking(0.95, 40.13))
        afwL.Add(New Afwijking(0.9, 53.7))
        cursList.Add(New Cursus("Syntra West", "Syntra West Brugge", 7, "Dinsdag", "NL", 14, 11, 0.8, 2014, 12.14, afwL, Algoritmes.BayesLinear, True, Nothing))

        afwL = New List(Of Afwijking)
        afwL.Add(New Afwijking(0.995, 5.36))
        afwL.Add(New Afwijking(0.99, 6.25))
        afwL.Add(New Afwijking(0.975, 10.84))
        afwL.Add(New Afwijking(0.95, 17.3))
        afwL.Add(New Afwijking(0.9, 28.71))
        cursList.Add(New Cursus("Escala", "Syntra West Kortrijk", 1, "Vrijdag", "INS", 34, 7, 0.347, Nothing, Nothing, afwL, Algoritmes.BayesMerk, False, "HGS"))

        Dim bbl As New Bayes_Bayes_Linear(Nothing, False)
        cursList = bbl.TestResetCursusList(cursList)
        Assert.AreEqual("Syntra West Kortrijk", cursList(1).getUitvoerCentrum)
    End Sub

    <TestMethod()> Public Sub TestResetCursusList17()
        Dim cursList As New List(Of Cursus)
        Dim afwL As New List(Of Afwijking)
        afwL.Add(New Afwijking(0.995, 11.45))
        afwL.Add(New Afwijking(0.99, 17.84))
        afwL.Add(New Afwijking(0.975, 29.15))
        afwL.Add(New Afwijking(0.95, 40.13))
        afwL.Add(New Afwijking(0.9, 53.7))
        cursList.Add(New Cursus("Syntra West", "Syntra West Brugge", 7, "Dinsdag", "NL", 14, 11, 0.8, 2014, 12.14, afwL, Algoritmes.BayesLinear, True, Nothing))

        afwL = New List(Of Afwijking)
        afwL.Add(New Afwijking(0.995, 5.36))
        afwL.Add(New Afwijking(0.99, 6.25))
        afwL.Add(New Afwijking(0.975, 10.84))
        afwL.Add(New Afwijking(0.95, 17.3))
        afwL.Add(New Afwijking(0.9, 28.71))
        cursList.Add(New Cursus("Escala", "Syntra West Kortrijk", 1, "Vrijdag", "INS", 34, 7, 0.347, Nothing, Nothing, afwL, Algoritmes.BayesMerk, False, "HGS"))

        Dim bbl As New Bayes_Bayes_Linear(Nothing, False)
        cursList = bbl.TestResetCursusList(cursList)
        Assert.AreEqual(0, cursList(1).getJaar)
    End Sub

    <TestMethod()> Public Sub TestResetCursusList18()
        Dim cursList As New List(Of Cursus)
        Dim afwL As New List(Of Afwijking)
        afwL.Add(New Afwijking(0.995, 11.45))
        afwL.Add(New Afwijking(0.99, 17.84))
        afwL.Add(New Afwijking(0.975, 29.15))
        afwL.Add(New Afwijking(0.95, 40.13))
        afwL.Add(New Afwijking(0.9, 53.7))
        cursList.Add(New Cursus("Syntra West", "Syntra West Brugge", 7, "Dinsdag", "NL", 14, 11, 0.8, 2014, 12.14, afwL, Algoritmes.BayesLinear, True, Nothing))

        afwL = New List(Of Afwijking)
        afwL.Add(New Afwijking(0.995, 5.36))
        afwL.Add(New Afwijking(0.99, 6.25))
        afwL.Add(New Afwijking(0.975, 10.84))
        afwL.Add(New Afwijking(0.95, 17.3))
        afwL.Add(New Afwijking(0.9, 28.71))
        cursList.Add(New Cursus("Escala", "Syntra West Kortrijk", 1, "Vrijdag", "INS", 34, 7, 0.347, Nothing, Nothing, afwL, Algoritmes.BayesMerk, False, "HGS"))

        Dim bbl As New Bayes_Bayes_Linear(Nothing, False)
        cursList = bbl.TestResetCursusList(cursList)
        Assert.AreEqual(0, cursList(1).getJaar)
    End Sub

    <TestMethod()> Public Sub TestResetCursusList19()
        Dim cursList As New List(Of Cursus)
        Dim afwL As New List(Of Afwijking)
        afwL.Add(New Afwijking(0.995, 11.45))
        afwL.Add(New Afwijking(0.99, 17.84))
        afwL.Add(New Afwijking(0.975, 29.15))
        afwL.Add(New Afwijking(0.95, 40.13))
        afwL.Add(New Afwijking(0.9, 53.7))
        cursList.Add(New Cursus("Syntra West", "Syntra West Brugge", 7, "Dinsdag", "NL", 14, 11, 0.8, 2014, 12.14, afwL, Algoritmes.BayesLinear, True, Nothing))

        afwL = New List(Of Afwijking)
        afwL.Add(New Afwijking(0.995, 5.36))
        afwL.Add(New Afwijking(0.99, 6.25))
        afwL.Add(New Afwijking(0.975, 10.84))
        afwL.Add(New Afwijking(0.95, 17.3))
        afwL.Add(New Afwijking(0.9, 28.71))
        cursList.Add(New Cursus("Escala", "Syntra West Kortrijk", 1, "Vrijdag", "INS", 34, 7, 0.347, Nothing, Nothing, afwL, Algoritmes.BayesMerk, False, "HGS"))

        Dim bbl As New Bayes_Bayes_Linear(Nothing, False)
        cursList = bbl.TestResetCursusList(cursList)
        Assert.AreEqual(False, cursList(0).getIsCorrect)
    End Sub

    <TestMethod()> Public Sub TestResetCursusList20()
        Dim cursList As New List(Of Cursus)
        Dim afwL As New List(Of Afwijking)
        afwL.Add(New Afwijking(0.995, 11.45))
        afwL.Add(New Afwijking(0.99, 17.84))
        afwL.Add(New Afwijking(0.975, 29.15))
        afwL.Add(New Afwijking(0.95, 40.13))
        afwL.Add(New Afwijking(0.9, 53.7))
        cursList.Add(New Cursus("Syntra West", "Syntra West Brugge", 7, "Dinsdag", "NL", 14, 11, 0.8, 2014, 12.14, afwL, Algoritmes.BayesLinear, True, Nothing))

        afwL = New List(Of Afwijking)
        afwL.Add(New Afwijking(0.995, 5.36))
        afwL.Add(New Afwijking(0.99, 6.25))
        afwL.Add(New Afwijking(0.975, 10.84))
        afwL.Add(New Afwijking(0.95, 17.3))
        afwL.Add(New Afwijking(0.9, 28.71))
        cursList.Add(New Cursus("Escala", "Syntra West Kortrijk", 1, "Vrijdag", "INS", 34, 7, 0.347, Nothing, Nothing, afwL, Algoritmes.BayesMerk, False, "HGS"))

        Dim bbl As New Bayes_Bayes_Linear(Nothing, False)
        cursList = bbl.TestResetCursusList(cursList)
        Assert.AreEqual(Nothing, cursList(1).getB)
    End Sub

    <TestMethod()> Public Sub TestResetCursusList21()
        Dim cursList As New List(Of Cursus)
        Dim afwL As New List(Of Afwijking)
        afwL.Add(New Afwijking(0.995, 11.45))
        afwL.Add(New Afwijking(0.99, 17.84))
        afwL.Add(New Afwijking(0.975, 29.15))
        afwL.Add(New Afwijking(0.95, 40.13))
        afwL.Add(New Afwijking(0.9, 53.7))
        cursList.Add(New Cursus("Syntra West", "Syntra West Brugge", 7, "Dinsdag", "NL", 14, 11, 0.8, 2014, 12.14, afwL, Algoritmes.BayesLinear, True, Nothing))

        afwL = New List(Of Afwijking)
        afwL.Add(New Afwijking(0.995, 5.36))
        afwL.Add(New Afwijking(0.99, 6.25))
        afwL.Add(New Afwijking(0.975, 10.84))
        afwL.Add(New Afwijking(0.95, 17.3))
        afwL.Add(New Afwijking(0.9, 28.71))
        cursList.Add(New Cursus("Escala", "Syntra West Kortrijk", 1, "Vrijdag", "INS", 34, 7, 0.347, Nothing, Nothing, afwL, Algoritmes.BayesMerk, False, "HGS"))

        Dim bbl As New Bayes_Bayes_Linear(Nothing, False)
        cursList = bbl.TestResetCursusList(cursList)
        Assert.AreEqual(Algoritmes.Niets, cursList(1).getAlgoritme)
    End Sub

    <TestMethod()> Public Sub TestResetCursusList22()
        Dim cursList As New List(Of Cursus)
        Dim afwL As New List(Of Afwijking)
        afwL.Add(New Afwijking(0.995, 11.45))
        afwL.Add(New Afwijking(0.99, 17.84))
        afwL.Add(New Afwijking(0.975, 29.15))
        afwL.Add(New Afwijking(0.95, 40.13))
        afwL.Add(New Afwijking(0.9, 53.7))
        cursList.Add(New Cursus("Syntra West", "Syntra West Brugge", 7, "Dinsdag", "NL", 14, 11, 0.8, 2014, 12.14, afwL, Algoritmes.BayesLinear, True, Nothing))

        afwL = New List(Of Afwijking)
        afwL.Add(New Afwijking(0.995, 5.36))
        afwL.Add(New Afwijking(0.99, 6.25))
        afwL.Add(New Afwijking(0.975, 10.84))
        afwL.Add(New Afwijking(0.95, 17.3))
        afwL.Add(New Afwijking(0.9, 28.71))
        cursList.Add(New Cursus("Escala", "Syntra West Kortrijk", 1, "Vrijdag", "INS", 34, 7, 0.347, Nothing, Nothing, afwL, Algoritmes.BayesMerk, False, "HGS"))

        Dim bbl As New Bayes_Bayes_Linear(Nothing, False)
        cursList = bbl.TestResetCursusList(cursList)
        Assert.AreEqual(False, cursList(1).getIsCorrect)
    End Sub

    <TestMethod()> Public Sub TestResetCursusList23()
        Dim cursList As New List(Of Cursus)
        Dim afwL As New List(Of Afwijking)
        afwL.Add(New Afwijking(0.995, 11.45))
        afwL.Add(New Afwijking(0.99, 17.84))
        afwL.Add(New Afwijking(0.975, 29.15))
        afwL.Add(New Afwijking(0.95, 40.13))
        afwL.Add(New Afwijking(0.9, 53.7))
        cursList.Add(New Cursus("Syntra West", "Syntra West Brugge", 7, "Dinsdag", "NL", 14, 11, 0.8, 2014, 12.14, afwL, Algoritmes.BayesLinear, True, Nothing))

        afwL = New List(Of Afwijking)
        afwL.Add(New Afwijking(0.995, 5.36))
        afwL.Add(New Afwijking(0.99, 6.25))
        afwL.Add(New Afwijking(0.975, 10.84))
        afwL.Add(New Afwijking(0.95, 17.3))
        afwL.Add(New Afwijking(0.9, 28.71))
        cursList.Add(New Cursus("Escala", "Syntra West Kortrijk", 1, "Vrijdag", "INS", 34, 7, 0.347, Nothing, Nothing, afwL, Algoritmes.BayesMerk, False, "HGS"))

        Dim bbl As New Bayes_Bayes_Linear(Nothing, False)
        cursList = bbl.TestResetCursusList(cursList)
        Assert.AreEqual("HGS", cursList(1).getOntw)
    End Sub

    Private Function FillCurs(cursList As List(Of Cursus)) As List(Of Cursus)

        cursList.Add(New Cursus("Syntra West", "Syntra West Brugge", 9, "dinsdag", "MGV", 102, 84, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Kortrijk", 9, "woensdag", "HLT", 92, 70, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Brugge", 9, "maandag", "VZS", 84, 80, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
#Region "Nieuwe cursussen toevoegen"
        cursList.Add(New Cursus("Syntra West", "Syntra West Brugge", 9, "donderdag", "MGV", 76, 64, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Brugge", 9, "maandag", "BOW", 75, 59, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Kortrijk", 9, "woensdag", "MGV", 75, 69, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Kortrijk", 9, "maandag", "VZS", 72, 71, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Oostende", 9, "maandag", "INS", 70, 63, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Kortrijk", 9, "maandag", "BBH", 64, 54, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Roeselare", 9, "maandag", "TXT", 62, 54, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Oostende", 9, "dinsdag", "INS", 60, 54, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Brugge", 9, "donderdag", "BOW", 59, 48, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Roeselare", 9, "woensdag", "MGV", 59, 50, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Brugge", 9, "woensdag", "BOW", 57, 51, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Kortrijk", 9, "maandag", "MGV", 57, 50, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Brugge", 9, "maandag", "PPS", 56, 51, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Brugge", 9, "woensdag", "BBH", 54, 43, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Brugge", 9, "dinsdag", "RLT", 53, 44, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Roeselare", 9, "dinsdag", "TXT", 52, 44, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Oostende", 9, "woensdag", "MGV", 52, 43, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Brugge", 9, "maandag", "FTG", 50, 45, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Brugge", 9, "dinsdag", "RES", 50, 46, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Brugge", 9, "donderdag", "BBH", 49, 32, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Brugge", 9, "maandag", "BBH", 49, 40, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Brugge", 9, "zaterdag", "GSP", 46, 31, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Oostende", 9, "maandag", "SVG", 46, 45, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Oostende", 11, "woensdag", "INS", 44, 34, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Oostende", 9, "woensdag", "INS", 43, 40, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Kortrijk", 9, "dinsdag", "SAC", 41, 38, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Brugge", 9, "dinsdag", "PPS", 41, 36, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Roeselare", 9, "woensdag", "TLT", 41, 32, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Kortrijk", 9, "maandag", "RLT", 40, 32, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Oostende", 1, "woensdag", "INS", 39, 29, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Kortrijk", 9, "maandag", "SVG", 39, 38, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Oostende", 3, "dinsdag", "INS", 39, 30, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Oostende", 2, "dinsdag", "INS", 39, 29, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Kortrijk", 9, "maandag", "OOI", 38, 36, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Brugge", 9, "maandag", "MGV", 38, 32, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Brugge", 9, "dinsdag", "BBH", 38, 31, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Brugge", 9, "donderdag", "BAL", 37, 33, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Brugge", 9, "woensdag", "PPS", 37, 35, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Roeselare", 9, "donderdag", "TXT", 36, 28, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Oostende", 9, "donderdag", "INS", 36, 27, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Oostende", 9, "woensdag", "INL", 36, 30, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Kortrijk", 9, "woensdag", "BBH", 36, 28, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Escala", "Syntra West Brugge", 11, "donderdag", "JUR", 35, 25, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Brugge", 9, "woensdag", "MGV", 35, 27, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Oostende", 3, "woensdag", "INS", 35, 29, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Kortrijk", 9, "dinsdag", "SVG", 35, 33, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Brugge", 9, "woensdag", "PED", 34, 33, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Oostende", 11, "maandag", "INS", 34, 29, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Kortrijk", 9, "dinsdag", "VZS", 34, 31, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Brugge", 9, "woensdag", "HOT", 34, 25, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Veurne", 9, "maandag", "DRL", 34, 28, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Veurne", 9, "maandag", "MGV", 34, 31, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Kortrijk", 9, "maandag", "KAP", 33, 33, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Brugge", 9, "dinsdag", "PED", 33, 33, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Brugge", 9, "dinsdag", "FTG", 32, 25, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Brugge", 9, "donderdag", "PPS", 32, 30, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Ieper", 9, "dinsdag", "MGV", 32, 27, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Oostende", 11, "donderdag", "INS", 32, 23, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Roeselare", 9, "zaterdag", "TRM", 32, 25, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Brugge", 9, "dinsdag", "KAL", 32, 29, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Oostende", 10, "dinsdag", "INS", 31, 29, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Oostende", 3, "donderdag", "INS", 31, 18, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Oostende", 11, "dinsdag", "INS", 31, 28, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Brugge", 9, "maandag", "SEC", 31, 26, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Escala", "Syntra West Brugge", 10, "donderdag", "JUR", 31, 16, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Brugge", 9, "maandag", "SCO", 31, 21, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Brugge", 9, "maandag", "KAP", 31, 31, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Oostende", 10, "woensdag", "INS", 31, 27, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Oostende", 4, "woensdag", "INS", 31, 25, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Roeselare", 9, "woensdag", "TAV", 31, 28, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Roeselare", 9, "woensdag", "FTC", 31, 24, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Kortrijk", 9, "dinsdag", "PED", 31, 29, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Kortrijk", 9, "woensdag", "BOW", 31, 28, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Escala", "Syntra West Brugge", 11, "dinsdag", "JUR", 30, 19, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Roeselare", 9, "woensdag", "TXT", 30, 24, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Oostende", 2, "maandag", "INS", 30, 23, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Kortrijk", 9, "dinsdag", "BBH", 30, 26, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Oostende", 1, "dinsdag", "INS", 30, 25, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Brugge", 9, "maandag", "GSP", 29, 26, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Escala", "Syntra West Brugge", 3, "dinsdag", "JUR", 29, 21, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Oostende", 1, "donderdag", "INS", 28, 20, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Kortrijk", 11, "donderdag", "BU ", 28, 23, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Oostende", 10, "donderdag", "INS", 28, 25, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Brugge", 9, "maandag", "OOI", 28, 26, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Roeselare", 9, "maandag", "FTC", 28, 22, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Kortrijk", 9, "woensdag", "GAL", 28, 27, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Roeselare", 9, "maandag", "TAV", 28, 25, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Roeselare", 9, "donderdag", "IIR", 28, 25, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Brugge", 1, "donderdag", "PPS", 28, 27, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Kortrijk", 9, "dinsdag", "JUW", 27, 24, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Roeselare", 9, "zaterdag", "TXT", 27, 20, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Kortrijk", 9, "dinsdag", "REL", 27, 27, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Oostende", 5, "dinsdag", "INS", 27, 22, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Brugge", 9, "maandag", "SFV", 27, 19, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Kortrijk", 9, "donderdag", "IEL", 27, 20, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Kortrijk", 9, "dinsdag", "RES", 26, 22, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Brugge", 9, "donderdag", "SEC", 26, 22, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Brugge", 9, "maandag", "RES", 26, 21, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Brugge", 10, "zaterdag", "GSP", 26, 16, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Oostende", 4, "donderdag", "INS", 26, 20, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Kortrijk", 9, "woensdag", "RES", 26, 17, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Kortrijk", 9, "dinsdag", "MGV", 26, 22, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Oostende", 3, "maandag", "INS", 26, 21, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Brugge", 9, "woensdag", "RLT", 26, 24, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Veurne", 9, "maandag", "HND", 26, 23, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Kortrijk", 9, "maandag", "JUW", 26, 24, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Oostende", 4, "dinsdag", "INS", 26, 19, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Brugge", 9, "donderdag", "SAC", 26, 25, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Kortrijk", 9, "dinsdag", "SEC", 26, 25, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Oostende", 9, "woensdag", "ELL", 26, 24, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Oostende", 1, "maandag", "INS", 25, 17, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Kortrijk", 11, "dinsdag", "BU ", 25, 19, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Brugge", 1, "dinsdag", "PPS", 25, 23, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Kortrijk", 11, "maandag", "BU ", 25, 21, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Oostende", 5, "donderdag", "INS", 25, 19, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Brugge", 9, "dinsdag", "OOI", 25, 21, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Kortrijk", 9, "maandag", "SCO", 25, 16, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Oostende", 9, "dinsdag", "SVG", 25, 19, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Oostende", 10, "donderdag", "DBO", 25, 22, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Brugge", 3, "dinsdag", "RES", 25, 24, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Brugge", 9, "dinsdag", "VZS", 25, 25, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Kortrijk", 9, "maandag", "RES", 25, 18, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Veurne", 1, "maandag", "HND", 24, 20, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Brugge", 9, "woensdag", "KNS", 24, 20, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Brugge", 9, "dinsdag", "ART", 24, 17, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Brugge", 11, "woensdag", "PPS", 24, 19, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Escala", "Syntra West Brugge", 11, "vrijdag", "JUR", 24, 13, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Veurne", 9, "maandag", "MET", 24, 19, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Brugge", 9, "vrijdag", "HOU", 24, 23, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Kortrijk", 9, "woensdag", "JUW", 24, 24, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Oostende", 4, "maandag", "INS", 23, 19, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Kortrijk", 9, "donderdag", "SCO", 23, 20, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Escala", "Syntra West Brugge", 5, "dinsdag", "JUR", 23, 14, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Kortrijk", 10, "dinsdag", "BU ", 23, 17, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Oostende", 9, "dinsdag", "SAC", 23, 19, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Brugge", 9, "woensdag", "SEC", 23, 21, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Brugge", 1, "dinsdag", "OOI", 23, 19, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Brugge", 11, "dinsdag", "PPS", 23, 19, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Oostende", 12, "dinsdag", "INS", 22, 18, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Kortrijk", 9, "dinsdag", "SFI", 22, 19, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Brugge", 9, "donderdag", "CHL", 22, 18, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Roeselare", 10, "zaterdag", "TRM", 22, 21, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Veurne", 9, "dinsdag", "HND", 22, 21, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Kortrijk", 9, "maandag", "AUT", 22, 18, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Kortrijk", 9, "maandag", "REL", 22, 19, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Escala", "Syntra West Brugge", 6, "vrijdag", "JUR", 22, 8, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Oostende", 5, "woensdag", "INS", 22, 15, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Brugge", 6, "zaterdag", "SEC", 22, 14, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Roeselare", 9, "maandag", "SAC", 22, 18, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Brugge", 9, "donderdag", "FTG", 22, 18, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Kortrijk", 9, "woensdag", "OOI", 22, 20, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Kortrijk", 9, "donderdag", "SVG", 22, 18, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Kortrijk", 9, "maandag", "DIE", 22, 20, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Kortrijk", 10, "woensdag", "IEL", 21, 12, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Brugge", 11, "maandag", "PPS", 21, 17, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Ieper", 9, "dinsdag", "DIL", 21, 18, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Kortrijk", 2, "maandag", "RES", 21, 13, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Oostende", 10, "donderdag", "FIS", 21, 20, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Kortrijk", 9, "maandag", "HRM", 21, 20, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Brugge", 11, "zaterdag", "GSP", 21, 15, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Veurne", 9, "donderdag", "PRV", 21, 12, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Kortrijk", 9, "donderdag", "MGV", 21, 14, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Roeselare", 9, "maandag", "OOI", 21, 21, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Brugge", 9, "maandag", "AFW", 21, 17, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Brugge", 1, "maandag", "PPS", 21, 16, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Brugge", 9, "maandag", "SFI", 21, 21, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Kortrijk", 3, "dinsdag", "RES", 21, 17, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Brugge", 9, "maandag", "GLK", 21, 18, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Kortrijk", 9, "dinsdag", "OOI", 21, 18, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Oostende", 2, "donderdag", "DBO", 20, 13, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Kortrijk", 9, "woensdag", "IEL", 20, 17, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Kortrijk", 10, "maandag", "BU ", 20, 12, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Brugge", 2, "dinsdag", "RES", 20, 15, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Escala", "Syntra West Brugge", 5, "donderdag", "JUR", 20, 12, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Veurne", 9, "maandag", "FIL", 20, 16, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Roeselare", 9, "woensdag", "BBH", 20, 15, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Oostende", 6, "maandag", "INS", 20, 11, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Oostende", 11, "woensdag", "DBO", 20, 17, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Kortrijk", 9, "dinsdag", "AUT", 20, 18, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Ieper", 9, "maandag", "SEC", 20, 19, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Kortrijk", 10, "maandag", "RES", 20, 17, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Kortrijk", 11, "woensdag", "IEL", 20, 11, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Escala", "Syntra West Brugge", 12, "vrijdag", "JUR", 20, 12, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Kortrijk", 9, "dinsdag", "SLA", 20, 20, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Roeselare", 9, "maandag", "SFI", 20, 20, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Roeselare", 9, "woensdag", "DIL", 20, 19, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Brugge", 10, "dinsdag", "RES", 20, 18, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Kortrijk", 9, "maandag", "SLA", 20, 18, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Kortrijk", 9, "woensdag", "HOT", 20, 15, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Brugge", 9, "donderdag", "RES", 20, 16, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Brugge", 9, "maandag", "ART", 20, 17, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Escala", "Syntra West Brugge", 4, "dinsdag", "JUR", 20, 14, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("SBM", "Syntra West Kortrijk", 10, "woensdag", "MIL", 19, 16, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Brugge", 9, "dinsdag", "BOW", 19, 18, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Brugge", 10, "dinsdag", "FIS", 19, 15, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Kortrijk", 10, "donderdag", "BU ", 19, 14, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Oostende", 11, "donderdag", "DBO", 19, 14, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Kortrijk", 9, "maandag", "INS", 19, 16, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Kortrijk", 11, "donderdag", "FIN", 19, 11, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Roeselare", 9, "dinsdag", "BBH", 19, 14, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Brugge", 10, "maandag", "RES", 19, 10, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("SBM", "Syntra West Kortrijk", 10, "donderdag", "FIN", 19, 10, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Escala", "Syntra West Brugge", 10, "donderdag", "ALD", 19, 10, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Brugge", 9, "dinsdag", "KPB", 19, 19, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Escala", "Syntra West Brugge", 5, "dinsdag", "ALD", 19, 6, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("SBM", "Syntra West Kortrijk", 6, "maandag", "BU ", 19, 19, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Kortrijk", 2, "woensdag", "IEL", 19, 14, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Oostende", 6, "donderdag", "DBO", 19, 19, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Kortrijk", 9, "donderdag", "SEC", 19, 19, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Brugge", 9, "donderdag", "KPB", 19, 17, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Brugge", 9, "woensdag", "RES", 19, 14, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Kortrijk", 10, "donderdag", "REL", 19, 14, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Brugge", 3, "maandag", "RES", 19, 17, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("SBM", "Syntra West Brugge", 5, "dinsdag", "PRD", 19, 14, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Brugge", 9, "donderdag", "CHO", 19, 19, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Kortrijk", 9, "dinsdag", "INS", 19, 14, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Roeselare", 9, "donderdag", "SVG", 19, 18, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Kortrijk", 4, "maandag", "SEC", 18, 15, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Oostende", 2, "woensdag", "DBO", 18, 15, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Brugge", 2, "donderdag", "RES", 18, 18, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Brugge", 9, "maandag", "ESD", 18, 14, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Brugge", 10, "donderdag", "BAK", 18, 15, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("SBM", "Syntra West Kortrijk", 3, "donderdag", "VEI", 18, 13, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Brugge", 1, "maandag", "OOI", 18, 17, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("SBM", "Syntra West Kortrijk", 12, "dinsdag", "BU ", 18, 18, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Kortrijk", 9, "woensdag", "CAL", 18, 18, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Kortrijk", 10, "donderdag", "FIN", 18, 14, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Roeselare", 9, "woensdag", "BMV", 18, 14, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Roeselare", 9, "maandag", "HSD", 18, 17, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Kortrijk", 9, "donderdag", "JUW", 18, 17, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Kortrijk", 9, "zaterdag", "SCO", 18, 13, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Brugge", 10, "woensdag", "RES", 18, 14, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Kortrijk", 9, "maandag", "SFI", 18, 18, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Kortrijk", 11, "maandag", "RES", 18, 16, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Brugge", 9, "maandag", "KPB", 18, 18, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Kortrijk", 3, "maandag", "RES", 18, 12, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Oostende", 1, "woensdag", "DBO", 18, 14, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Veurne", 9, "maandag", "DRN", 17, 13, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Kortrijk", 4, "donderdag", "BU ", 17, 12, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Escala", "Syntra West Brugge", 3, "donderdag", "JUR", 17, 9, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Roeselare", 9, "woensdag", "HSL", 17, 15, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Kortrijk", 9, "maandag", "SLL", 17, 16, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Oostende", 10, "maandag", "INS", 17, 16, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Brugge", 9, "donderdag", "KAP", 17, 17, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Brugge", 9, "donderdag", "PED", 17, 17, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Escala", "Syntra West Brugge", 3, "donderdag", "VEI", 17, 9, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Kortrijk", 10, "dinsdag", "IEL", 17, 8, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Brugge", 9, "dinsdag", "SEC", 17, 14, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Kortrijk", 9, "dinsdag", "SCO", 17, 15, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Kortrijk", 9, "donderdag", "INS", 17, 15, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Brugge", 3, "zaterdag", "GSP", 17, 11, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Escala", "Syntra West Brugge", 12, "dinsdag", "JUR", 17, 13, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Kortrijk", 1, "dinsdag", "LOG", 17, 14, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Brugge", 9, "vrijdag", "PPS", 17, 17, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Roeselare", 9, "dinsdag", "SEC", 17, 12, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Oostende", 5, "maandag", "INS", 17, 11, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("SBM", "Syntra West Brugge", 10, "woensdag", "PRD", 17, 14, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Brugge", 12, "donderdag", "PPS", 16, 9, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Kortrijk", 3, "donderdag", "BU ", 16, 11, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Oostende", 10, "maandag", "DBO", 16, 14, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Kortrijk", 9, "maandag", "SAC", 16, 16, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Escala", "Syntra West Roeselare", 11, "maandag", "TAV", 16, 13, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Brugge", 10, "donderdag", "BU ", 16, 10, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Ieper", 9, "dinsdag", "BBH", 16, 14, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Escala", "Syntra West Brugge", 3, "donderdag", "ALD", 16, 6, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Oostende", 3, "maandag", "DBO", 16, 14, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Brugge", 9, "dinsdag", "RUW", 16, 13, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Kortrijk", 9, "donderdag", "RES", 16, 10, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Kortrijk", 9, "vrijdag", "AUT", 16, 16, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Kortrijk", 5, "donderdag", "BU ", 16, 12, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Kortrijk", 6, "maandag", "BU ", 16, 13, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Oostende", 3, "donderdag", "DBO", 16, 12, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Brugge", 9, "dinsdag", "GSP", 16, 14, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Ieper", 9, "maandag", "TRM", 16, 15, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Brugge", 10, "dinsdag", "BU ", 16, 11, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("SBM", "Syntra West Kortrijk", 12, "donderdag", "FIN", 16, 3, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Kortrijk", 9, "woensdag", "SLA", 16, 15, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Roeselare", 9, "maandag", "BBH", 16, 15, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Oostende", 9, "woensdag", "SCL", 16, 12, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Kortrijk", 9, "woensdag", "KTA", 16, 14, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Kortrijk", 10, "maandag", "REL", 16, 12, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Escala", "Syntra West Brugge", 10, "donderdag", "VEI", 16, 2, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Escala", "Syntra West Brugge", 10, "dinsdag", "JUR", 16, 9, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Escala", "Syntra West Roeselare", 10, "dinsdag", "TAV", 16, 7, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Ieper", 9, "dinsdag", "SAC", 16, 11, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Brugge", 1, "dinsdag", "RES", 16, 13, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Oostende", 9, "woensdag", "BBH", 16, 9, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Oostende", 5, "donderdag", "DBO", 15, 15, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Oostende", 2, "woensdag", "INS", 15, 11, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Kortrijk", 9, "woensdag", "SEC", 15, 14, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Brugge", 9, "dinsdag", "SCO", 15, 10, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Brugge", 10, "maandag", "BU ", 15, 12, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Escala", "Syntra West Brugge", 10, "maandag", "JUR", 15, 8, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Escala", "Syntra West Brugge", 3, "dinsdag", "VEI", 15, 7, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Escala", "Syntra West Brugge", 12, "donderdag", "JUR", 15, 10, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Brugge", 2, "dinsdag", "RUW", 15, 11, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
        cursList.Add(New Cursus("Syntra West", "Syntra West Kortrijk", 10, "donderdag", "FIS", 15, 13, 0, 0, 0, Nothing, Algoritmes.Niets, False, Nothing))
#End Region

        Return cursList
    End Function

    <TestMethod()> Public Sub TestBerekenBayesVoorAlles1()
        Dim cursList As New List(Of Cursus)
        cursList = FillCurs(cursList)
        Dim root As New MainScreen
        Dim bbl As New Bayes_Bayes_Linear(root, False)
        cursList = bbl.TestResetCursusList(cursList)
        cursList = bbl.TestBerekenBayesVoorIederItem(cursList)


        Assert.AreEqual(4.0369, Math.Round(cursList(0).getAfwijkingswaarde(0), 4))
    End Sub

    <TestMethod()> Public Sub TestBerekenBayesVoorAlles2()
        Dim cursList As New List(Of Cursus)
        cursList = FillCurs(cursList)
        Dim root As New MainScreen
        Dim bbl As New Bayes_Bayes_Linear(root, False)
        cursList = bbl.TestResetCursusList(cursList)
        cursList = bbl.TestBerekenBayesVoorIederItem(cursList)


        Assert.AreEqual(5.1735, Math.Round(cursList(40).getAfwijkingswaarde(2), 4))
    End Sub

    <TestMethod()> Public Sub TestBerekenBayesVoorAlles3()
        Dim cursList As New List(Of Cursus)
        cursList = FillCurs(cursList)
        Dim root As New MainScreen
        Dim bbl As New Bayes_Bayes_Linear(root, False)
        cursList = bbl.TestResetCursusList(cursList)
        cursList = bbl.TestBerekenBayesVoorIederItem(cursList)


        Assert.AreEqual(6.9625, Math.Round(cursList(78).getAfwijkingswaarde(1), 4))
    End Sub

    <TestMethod()> Public Sub TestBerekenBayesVoorAlles4()
        Dim cursList As New List(Of Cursus)
        cursList = FillCurs(cursList)
        Dim root As New MainScreen
        Dim bbl As New Bayes_Bayes_Linear(root, False)
        cursList = bbl.TestResetCursusList(cursList)
        cursList = bbl.TestBerekenBayesVoorIederItem(cursList)


        Assert.AreEqual(8.7699, Math.Round(cursList(178).getAfwijkingswaarde(1), 4))
    End Sub

    <TestMethod()> Public Sub TestBerekenBayesVoorAlles5()
        Dim cursList As New List(Of Cursus)
        cursList = FillCurs(cursList)
        Dim root As New MainScreen
        Dim bbl As New Bayes_Bayes_Linear(root, False)
        cursList = bbl.TestResetCursusList(cursList)
        cursList = bbl.TestBerekenBayesVoorIederItem(cursList)


        Assert.AreEqual(5.0005, Math.Round(cursList(243).getAfwijkingswaarde(4), 4))
    End Sub

    <TestMethod()> Public Sub TestBerekenBayesVoorAlles6()
        Dim cursList As New List(Of Cursus)
        cursList = FillCurs(cursList)
        Dim root As New MainScreen
        Dim bbl As New Bayes_Bayes_Linear(root, False)
        cursList = bbl.TestResetCursusList(cursList)
        cursList = bbl.TestBerekenBayesVoorIederItem(cursList)


        Assert.AreEqual(5.1932, Math.Round(cursList(269).getAfwijkingswaarde(4), 4))
    End Sub

    <TestMethod()> Public Sub TestBerekenBayesVoorAlles7()
        Dim cursList As New List(Of Cursus)
        cursList = FillCurs(cursList)
        Dim root As New MainScreen
        Dim bbl As New Bayes_Bayes_Linear(root, False)
        cursList = bbl.TestResetCursusList(cursList)
        cursList = bbl.TestBerekenBayesVoorIederItem(cursList)


        Assert.AreEqual(0.8883, Math.Round(cursList(0).getKans, 4))
    End Sub

    <TestMethod()> Public Sub TestBerekenBayesVoorAlles8()
        Dim cursList As New List(Of Cursus)
        cursList = FillCurs(cursList)
        Dim root As New MainScreen
        Dim bbl As New Bayes_Bayes_Linear(root, False)
        cursList = bbl.TestResetCursusList(cursList)
        cursList = bbl.TestBerekenBayesVoorIederItem(cursList)


        Assert.AreEqual(0.6772, Math.Round(cursList(24).getKans, 4))
    End Sub

    <TestMethod()> Public Sub TestBerekenBayesVoorAlles9()
        Dim cursList As New List(Of Cursus)
        cursList = FillCurs(cursList)
        Dim root As New MainScreen
        Dim bbl As New Bayes_Bayes_Linear(root, False)
        cursList = bbl.TestResetCursusList(cursList)
        cursList = bbl.TestBerekenBayesVoorIederItem(cursList)


        Assert.AreEqual(0.7956, Math.Round(cursList(78).getKans, 4))
    End Sub

    <TestMethod()> Public Sub TestBerekenBayesVoorAlles10()
        Dim cursList As New List(Of Cursus)
        cursList = FillCurs(cursList)
        Dim root As New MainScreen
        Dim bbl As New Bayes_Bayes_Linear(root, False)
        cursList = bbl.TestResetCursusList(cursList)
        cursList = bbl.TestBerekenBayesVoorIederItem(cursList)


        Assert.AreEqual(0.9797, Math.Round(cursList(142).getKans, 4))
    End Sub

    <TestMethod()> Public Sub TestBerekenBayesVoorAlles11()
        Dim cursList As New List(Of Cursus)
        cursList = FillCurs(cursList)
        Dim root As New MainScreen
        Dim bbl As New Bayes_Bayes_Linear(root, False)
        cursList = bbl.TestResetCursusList(cursList)
        cursList = bbl.TestBerekenBayesVoorIederItem(cursList)


        Assert.AreEqual(0.8002, Math.Round(cursList(183).getKans, 4))
    End Sub

    <TestMethod()> Public Sub TestBerekenBayesVoorAlles12()
        Dim cursList As New List(Of Cursus)
        cursList = FillCurs(cursList)
        Dim root As New MainScreen
        Dim bbl As New Bayes_Bayes_Linear(root, False)
        cursList = bbl.TestResetCursusList(cursList)
        cursList = bbl.TestBerekenBayesVoorIederItem(cursList)


        Assert.AreEqual(0.9321, Math.Round(cursList(243).getKans, 4))
    End Sub

    <TestMethod()> Public Sub TestOntwikkelaars1()
        Dim bayes As New Bayes_Bayes_Linear(New MainScreen, False)
        Dim cursList As New List(Of Cursus)
        Dim afw As New List(Of Afwijking)

        afw.Add(New Afwijking(0.995, 0))
        afw.Add(New Afwijking(0.99, 0))
        afw.Add(New Afwijking(0.975, 0))
        afw.Add(New Afwijking(0.95, 0))
        afw.Add(New Afwijking(0.9, 0))
        cursList.Add(New Cursus("Syntra West", "Syntra West Brugge", 0, "", "Jur", 10, 7, 0, 0, 0, afw, Algoritmes.Niets, False, "MAK"))
        cursList.Add(New Cursus("Syntra West", "Syntra West Kortrijk", 0, "", "Jur", 10, 2, 0, 0, 0, afw, Algoritmes.Niets, False, "DIR"))
        cursList.Add(New Cursus("Escala", "Syntra West Brugge", 0, "", "Jur", 30, 21, 0, 0, 0, afw, Algoritmes.Niets, False, "DIR"))
        cursList.Add(New Cursus("Escala", "Syntra West Kortrijk", 0, "", "Jur", 30, 14, 0, 0, 0, afw, Algoritmes.Niets, False, "DIR"))
        cursList.Add(New Cursus("Escala", "Syntra West Kortrijk", 0, "", "Jur", 24, 14, 0, 0, 0, afw, Algoritmes.Niets, False, "MAK"))

        bayes.resetDictionaries()

        For i As Integer = 0 To cursList.Count - 1
            bayes.baycalculation(cursList(i), True)
        Next
        For i As Integer = 0 To cursList.Count - 1
            cursList(i) = cursList(i).setKans(bayes.berekenBayes(cursList(i)))
        Next

        Dim cur = bayes.getKansVoorCursus(New Cursus("Syntra West", "Syntra West Brugge", 0, "", "Jur", 30, 21, 0, 0, 0, afw, Algoritmes.Niets, False, "MAK"))
        bayes.alleAfwijkingenVerwerken(cursList)

        Assert.AreEqual(0.659844, Math.Round(cur.getKans, 6))
    End Sub

    <TestMethod()> Public Sub TestOntwikkelaars2()
        Dim bayes As New Bayes_Bayes_Linear(New MainScreen, False)
        Dim cursList As New List(Of Cursus)
        Dim afw As New List(Of Afwijking)

        afw.Add(New Afwijking(0.995, 0))
        afw.Add(New Afwijking(0.99, 0))
        afw.Add(New Afwijking(0.975, 0))
        afw.Add(New Afwijking(0.95, 0))
        afw.Add(New Afwijking(0.9, 0))
        cursList.Add(New Cursus("Syntra West", "Syntra West Brugge", 0, "", "Jur", 10, 7, 0, 0, 0, afw, Algoritmes.Niets, False, "MAK"))
        cursList.Add(New Cursus("Syntra West", "Syntra West Kortrijk", 0, "", "Jur", 10, 2, 0, 0, 0, afw, Algoritmes.Niets, False, "DIR"))
        cursList.Add(New Cursus("Escala", "Syntra West Brugge", 0, "", "Jur", 30, 21, 0, 0, 0, afw, Algoritmes.Niets, False, "DIR"))
        cursList.Add(New Cursus("Escala", "Syntra West Kortrijk", 0, "", "Jur", 30, 14, 0, 0, 0, afw, Algoritmes.Niets, False, "DIR"))
        cursList.Add(New Cursus("Escala", "Syntra West Kortrijk", 0, "", "Jur", 24, 14, 0, 0, 0, afw, Algoritmes.Niets, False, "MAK"))

        bayes.resetDictionaries()

        For i As Integer = 0 To cursList.Count - 1
            bayes.baycalculation(cursList(i), True)
        Next
        For i As Integer = 0 To cursList.Count - 1
            cursList(i) = cursList(i).setKans(bayes.berekenBayes(cursList(i)))
        Next

        Dim cur = bayes.getKansVoorCursus(New Cursus("Escala", "Syntra West Brugge", 0, "", "Jur", 30, 21, 0, 0, 0, afw, Algoritmes.Niets, False, "MAK"))
        bayes.alleAfwijkingenVerwerken(cursList)

        Assert.AreEqual(0.768479, Math.Round(cur.getKans, 6))
    End Sub
End Class