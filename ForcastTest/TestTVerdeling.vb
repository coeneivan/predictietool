Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports ForecastVB

<TestClass()> Public Class TestTVerdeling

    Dim tVerd As New tVerdeling

    <TestMethod()> Public Sub TestTVerd_995_1()
        Dim result = tVerd.getTwaarde(0.995, 1)
        Assert.AreEqual(63.66, result)
    End Sub

    <TestMethod()> Public Sub TestTVerd_99_1()
        Dim result = tVerd.getTwaarde(0.99, 1)
        Assert.AreEqual(31.82, result)
    End Sub

    <TestMethod()> Public Sub TestTVerd_975_1()
        Dim result = tVerd.getTwaarde(0.975, 1)
        Assert.AreEqual(12.71, result)
    End Sub

    <TestMethod()> Public Sub TestTVerd_95_1()
        Dim result = tVerd.getTwaarde(0.95, 1)
        Assert.AreEqual(6.31, result)
    End Sub

    <TestMethod()> Public Sub TestTVerd_9_1()
        Dim result = tVerd.getTwaarde(0.9, 1)
        Assert.AreEqual(3.08, result)
    End Sub

    <TestMethod()> Public Sub TestTVerd_995_2()
        Dim result = tVerd.getTwaarde(0.995, 2)
        Assert.AreEqual(9.92, result)
    End Sub

    <TestMethod()> Public Sub TestTVerd_99_2()
        Dim result = tVerd.getTwaarde(0.99, 2)
        Assert.AreEqual(6.96, result)
    End Sub

    <TestMethod()> Public Sub TestTVerd_975_2()
        Dim result = tVerd.getTwaarde(0.975, 2)
        Assert.AreEqual(4.3, result)
    End Sub

    <TestMethod()> Public Sub TestTVerd_95_2()
        Dim result = tVerd.getTwaarde(0.95, 2)
        Assert.AreEqual(2.92, result)
    End Sub

    <TestMethod()> Public Sub TestTVerd_9_2()
        Dim result = tVerd.getTwaarde(0.9, 2)
        Assert.AreEqual(1.89, result)
    End Sub

    <TestMethod()> Public Sub TestTVerd_995_10()
        Dim result = tVerd.getTwaarde(0.995, 10)
        Assert.AreEqual(3.17, result)
    End Sub

    <TestMethod()> Public Sub TestTVerd_99_10()
        Dim result = tVerd.getTwaarde(0.99, 10)
        Assert.AreEqual(2.76, result)
    End Sub

    <TestMethod()> Public Sub TestTVerd_975_10()
        Dim result = tVerd.getTwaarde(0.975, 10)
        Assert.AreEqual(2.23, result)
    End Sub

    <TestMethod()> Public Sub TestTVerd_95_10()
        Dim result = tVerd.getTwaarde(0.95, 10)
        Assert.AreEqual(1.81, result)
    End Sub

    <TestMethod()> Public Sub TestTVerd_9_10()
        Dim result = tVerd.getTwaarde(0.9, 10)
        Assert.AreEqual(1.37, result)
    End Sub
    <TestMethod()> Public Sub TestTVerd_995_30()
        Dim result = tVerd.getTwaarde(0.995, 30)
        Assert.AreEqual(2.75, result)
    End Sub

    <TestMethod()> Public Sub TestTVerd_99_30()
        Dim result = tVerd.getTwaarde(0.99, 30)
        Assert.AreEqual(2.46, result)
    End Sub

    <TestMethod()> Public Sub TestTVerd_975_30()
        Dim result = tVerd.getTwaarde(0.975, 30)
        Assert.AreEqual(2.04, result)
    End Sub

    <TestMethod()> Public Sub TestTVerd_95_30()
        Dim result = tVerd.getTwaarde(0.95, 30)
        Assert.AreEqual(1.7, result)
    End Sub

    <TestMethod()> Public Sub TestTVerd_9_30()
        Dim result = tVerd.getTwaarde(0.9, 30)
        Assert.AreEqual(1.31, result)
    End Sub

    <TestMethod()> Public Sub TestTVerdTussenWaardes_995_32()
        Dim result = tVerd.getTwaarde(0.995, 32)
        Assert.AreEqual(2.75, result)
    End Sub

    <TestMethod()> Public Sub TestTVerdTussenWaardes_99_32()
        Dim result = tVerd.getTwaarde(0.99, 32)
        Assert.AreEqual(2.46, result)
    End Sub

    <TestMethod()> Public Sub TestTVerdTussenWaardes_975_32()
        Dim result = tVerd.getTwaarde(0.975, 32)
        Assert.AreEqual(2.04, result)
    End Sub

    <TestMethod()> Public Sub TestTVerdTussenWaardes_95_32()
        Dim result = tVerd.getTwaarde(0.95, 32)
        Assert.AreEqual(1.7, result)
    End Sub

    <TestMethod()> Public Sub TestTVerdTussenWaardes_9_32()
        Dim result = tVerd.getTwaarde(0.9, 32)
        Assert.AreEqual(1.31, result)
    End Sub

    <TestMethod()> Public Sub TestTVerdTussenWaardes_995_55()
        Dim result = tVerd.getTwaarde(0.995, 55)
        Assert.AreEqual(2.68, result)
    End Sub

    <TestMethod()> Public Sub TestTVerdTussenWaardes_99_55()
        Dim result = tVerd.getTwaarde(0.99, 55)
        Assert.AreEqual(2.4, result)
    End Sub

    <TestMethod()> Public Sub TestTVerdTussenWaardes_975_55()
        Dim result = tVerd.getTwaarde(0.975, 55)
        Assert.AreEqual(2.01, result)
    End Sub

    <TestMethod()> Public Sub TestTVerdTussenWaardes_95_55()
        Dim result = tVerd.getTwaarde(0.95, 55)
        Assert.AreEqual(1.68, result)
    End Sub

    <TestMethod()> Public Sub TestTVerdTussenWaardes_9_55()
        Dim result = tVerd.getTwaarde(0.9, 55)
        Assert.AreEqual(1.3, result)
    End Sub

    <TestMethod()> Public Sub TestTVerdTussenWaardes_995_140()
        Dim result = tVerd.getTwaarde(0.995, 140)
        Assert.AreEqual(2.62, result)
    End Sub

    <TestMethod()> Public Sub TestTVerdTussenWaardes_99_140()
        Dim result = tVerd.getTwaarde(0.99, 140)
        Assert.AreEqual(2.36, result)
    End Sub

    <TestMethod()> Public Sub TestTVerdTussenWaardes_975_140()
        Dim result = tVerd.getTwaarde(0.975, 140)
        Assert.AreEqual(1.98, result)
    End Sub

    <TestMethod()> Public Sub TestTVerdTussenWaardes_95_140()
        Dim result = tVerd.getTwaarde(0.95, 140)
        Assert.AreEqual(1.66, result)
    End Sub

    <TestMethod()> Public Sub TestTVerdTussenWaardes_9_140()
        Dim result = tVerd.getTwaarde(0.9, 140)
        Assert.AreEqual(1.29, result)
    End Sub

    <TestMethod()> Public Sub TestTVerdGroterDanLaatste_995_175()
        Dim result = tVerd.getTwaarde(0.995, 175)
        Assert.AreEqual(2.58, result)
    End Sub

    <TestMethod()> Public Sub TestTVerdGroterDanLaatste_99_175()
        Dim result = tVerd.getTwaarde(0.99, 175)
        Assert.AreEqual(2.33, result)
    End Sub

    <TestMethod()> Public Sub TestTVerdGroterDanLaatste_975_175()
        Dim result = tVerd.getTwaarde(0.975, 175)
        Assert.AreEqual(1.96, result)
    End Sub

    <TestMethod()> Public Sub TestTVerdGroterDanLaatste_95_175()
        Dim result = tVerd.getTwaarde(0.95, 175)
        Assert.AreEqual(1.645, result)
    End Sub

    <TestMethod()> Public Sub TestTVerdGroterDanLaatste_9_175()
        Dim result = tVerd.getTwaarde(0.9, 175)
        Assert.AreEqual(1.28, result)
    End Sub

    <TestMethod(), ExpectedException(GetType(NotSupportedException))>
    Public Sub Test_betrouwbaarheidspercentage_Niet_Gevonden_Tussen()
        Try
            Dim result = tVerd.getTwaarde(0.91, 50)
        Catch ex As NotSupportedException
            Assert.AreEqual(ex.Message, "Gegeven betrouwbaarheidspercentage werd niet terug gevonden")
            Throw
        End Try
    End Sub

    <TestMethod(), ExpectedException(GetType(NotSupportedException))>
    Public Sub Test_betrouwbaarheidspercentage_Niet_Gevonden_Onder()
        Try
            Dim result = tVerd.getTwaarde(0.85, 50)
        Catch ex As NotSupportedException
            Assert.AreEqual(ex.Message, "Gegeven betrouwbaarheidspercentage werd niet terug gevonden")
            Throw
        End Try
    End Sub

    <TestMethod(), ExpectedException(GetType(NotSupportedException))>
    Public Sub Test_betrouwbaarheidspercentage_Niet_Gevonden_Boven()
        Try
            Dim result = tVerd.getTwaarde(0.999, 50)
        Catch ex As NotSupportedException
            Assert.AreEqual(ex.Message, "Gegeven betrouwbaarheidspercentage werd niet terug gevonden")
            Throw
        End Try
    End Sub

    <TestMethod(), ExpectedException(GetType(NotSupportedException))>
    Public Sub Test_AantalIs0()
        Try
            Dim result = tVerd.getTwaarde(0.99, 0)
        Catch ex As NotSupportedException
            Assert.AreEqual(ex.Message, "Aantal is negatief getal of 0")
            Throw
        End Try
    End Sub

    <TestMethod(), ExpectedException(GetType(NotSupportedException))>
    Public Sub Test_AantalIsNegatief()
        Try
            Dim result = tVerd.getTwaarde(0.99, -10)
        Catch ex As NotSupportedException
            Assert.AreEqual(ex.Message, "Aantal is negatief getal of 0")
            Throw
        End Try
    End Sub



    <TestMethod(), ExpectedException(GetType(NotSupportedException))>
    Public Sub Test_betrouwbaarheidspercentage_Niet_Gevonden_Tussen_En_NegatiefAantal()
        Try
            Dim result = tVerd.getTwaarde(0.91, -2)
        Catch ex As NotSupportedException
            Assert.AreEqual(ex.Message, "Gegeven betrouwbaarheidspercentage werd niet terug gevonden")
            Throw
        End Try
    End Sub
End Class


