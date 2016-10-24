Public Class DataMiningPrediction2
    Dim merk As String
    Dim uitvCentr As String
    Dim maand As Int16
    Dim dag As String
    Dim codeSubAfd As String
    Dim totaal As Int32
    Dim doorgegaan As Int32
    Dim kans As Double

    Public Sub New(mer As String, u As String, ma As Int16, da As String, subAf As String, tot As Int32, doorg As Int32)
        merk = mer
        uitvCentr = u
        maand = ma
        dag = da
        codeSubAfd = subAf
        totaal = tot
        doorgegaan = doorg
    End Sub

    Public Function getMerk() As String
        Return merk
    End Function

    Public Function getUitvoerCentrum() As String
        Return uitvCentr
    End Function

    Public Function getMaand() As Int16
        Return maand
    End Function

    Public Function getDag() As String
        Return dag
    End Function

    Public Function getCodeSubAfdeling() As String
        Return codeSubAfd
    End Function

    Public Function getTotaal() As Int32
        Return totaal
    End Function

    Public Function getDoorgegaan() As Int32
        Return doorgegaan
    End Function

    Public Sub setKans(k As Double)
        kans = k
    End Sub

    Public Function getKans() As Double
        Return kans
    End Function
End Class
