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
End Class