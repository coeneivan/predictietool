Public Class Cursus
    Dim ont As String
    Dim merk As String
    Dim uitvCentr As String
    Dim maand As Int16
    Dim dag As String
    Dim codeSubAfd As String
    Dim totaal As Int32
    Dim doorgegaan As Int32
    Dim kans As Double
    Dim jaar As Double
    Dim afwijkingValue As Double

    Public Sub New(mer As String, u As String, ma As Int16, da As String, subAf As String, tot As Int32, doorg As Int32)
        merk = mer
        uitvCentr = u
        maand = ma
        dag = da
        codeSubAfd = subAf
        totaal = tot
        doorgegaan = doorg
    End Sub
    Public Sub New(mer As String, u As String, ma As Int16, da As String, subAf As String, tot As Int32, doorg As Int32, j As Integer)
        merk = mer
        uitvCentr = u
        maand = ma
        dag = da
        codeSubAfd = subAf
        totaal = tot
        doorgegaan = doorg
        jaar = j
    End Sub
    Public Sub New(o As String, mer As String, subAf As String, doorg As Int32, j As String)
        jaar = j
        merk = mer
        codeSubAfd = subAf
        doorgegaan = doorg
        ont = o
        Correct = True
    End Sub
    Public Function getOnt() As String
        Return ont
    End Function
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

    Public Sub setTotaal(t As Int32)
        totaal = t
    End Sub

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

    Public Sub setJaar(j As Double)
        jaar = j
    End Sub

    Public Function getJaar() As Double
        Return jaar
    End Function

    Private b As Double
    Public Property setB() As Double
        Get
            Return b
        End Get
        Set(ByVal value As Double)
            b = value
        End Set
    End Property

    Private Correct As Boolean
    Public Property isCorrect() As Boolean
        Get
            Return Correct
        End Get
        Set(ByVal value As Boolean)
            Correct = value
        End Set
    End Property

    Friend Sub setMaand(m As Int32)
        maand = m
    End Sub

    Public Property afwijking() As Double
        Get
            Return afwijkingValue
        End Get
        Set(ByVal value As Double)
            afwijkingValue = value
        End Set
    End Property

    Private algoritmeProp As Algoritmes
    Public Property algoritme() As Algoritmes
        Get
            Return algoritmeProp
        End Get
        Set(ByVal value As Algoritmes)
            algoritmeProp = value
        End Set
    End Property

    Friend Sub SetDoorgegaan(v As Integer)
        doorgegaan = v
    End Sub
End Class
