Imports ForecastVB

<Serializable()> Public NotInheritable Class Cursus
    Private merk As String
    Private uitvCentr As String
    Private maand As Integer
    Private dag As String
    Private codeSubAfd As String
    Private totaal As Integer
    Private doorgegaan As Integer
    Private kans As Double
    Private jaar As Integer
    Private b As Double
    Private afwijkingValue As List(Of Afwijking)
    Private algoritmeProp As Algoritmes
    Private correct As Boolean
    Private ont As String


    Public Sub New(merk As String, uitvoerCentrum As String, maand As String, dag As String, codeSubAfdeling As String,
                   totaal As Integer, doorgegaan As Integer, kans As Double, jaar As Integer, b As Double, afwijking As List(Of Afwijking),
                   algoritme As Algoritmes, correct As Boolean, ont As String)

        If afwijking Is Nothing Then
            ' Lijst voor verschillende afwijkingen aanmaken
            afwijkingValue = New List(Of Afwijking)
            Dim betrwbGev = New tVerdeling()
            For Each bet As Double In betrwbGev.getBetrouwbaarheidsIntervallen
                afwijkingValue.Add(New Afwijking(bet, -101))
            Next
        Else
            Me.afwijkingValue = afwijking
        End If


        Me.merk = merk
        Me.uitvCentr = uitvoerCentrum
        Me.maand = maand
        Me.dag = dag
        Me.codeSubAfd = codeSubAfdeling.ToUpper
        Me.totaal = totaal
        Me.doorgegaan = doorgegaan
        Me.kans = kans
        Me.jaar = jaar
        Me.algoritmeProp = algoritme
        Me.correct = correct
        Me.b = b
        Me.ont = ont
    End Sub


#Region "Getters/Setters"
    Public Function setMerk(merk As String) As Cursus
        Return New Cursus(merk, Me.uitvCentr, Me.maand, Me.dag, Me.codeSubAfd, Me.totaal, Me.doorgegaan,
                                   Me.kans, Me.jaar, Me.b, Me.afwijkingValue, Me.algoritmeProp, Me.correct, Me.ont)
    End Function

    Public Function setUitvoerCentrum(uitvoercentrum As String) As Cursus
        Return New Cursus(Me.merk, uitvCentr, Me.maand, Me.dag, Me.codeSubAfd, Me.totaal, Me.doorgegaan,
                           Me.kans, Me.jaar, Me.b, Me.afwijkingValue, Me.algoritmeProp, Me.correct, Me.ont)
    End Function

    Public Function setMaand(maand As Integer) As Cursus
        Return New Cursus(Me.merk, Me.uitvCentr, maand, Me.dag, Me.codeSubAfd, Me.totaal, Me.doorgegaan,
                           Me.kans, Me.jaar, Me.b, Me.afwijkingValue, Me.algoritmeProp, Me.correct, Me.ont)
    End Function

    Public Function setDag(dag As String) As Cursus
        Return New Cursus(Me.merk, Me.uitvCentr, Me.maand, dag, Me.codeSubAfd, Me.totaal, Me.doorgegaan,
                           Me.kans, Me.jaar, Me.b, Me.afwijkingValue, Me.algoritmeProp, Me.correct, Me.ont)
    End Function

    Public Function setCodeSubafdeling(codeSubAfd As String) As Cursus
        Return New Cursus(Me.merk, Me.uitvCentr, Me.maand, Me.dag, codeSubAfd.ToUpper, Me.totaal, Me.doorgegaan,
                           Me.kans, Me.jaar, Me.b, Me.afwijkingValue, Me.algoritmeProp, Me.correct, Me.ont)
    End Function

    Public Function setTotaal(totaal As Integer) As Cursus
        Return New Cursus(Me.merk, Me.uitvCentr, Me.maand, Me.dag, Me.codeSubAfd, totaal, Me.doorgegaan,
                           Me.kans, Me.jaar, Me.b, Me.afwijkingValue, Me.algoritmeProp, Me.correct, Me.ont)
    End Function

    Public Function setDoorgegaan(doorgegaan As Integer) As Cursus
        Return New Cursus(Me.merk, Me.uitvCentr, Me.maand, Me.dag, Me.codeSubAfd, Me.totaal, doorgegaan,
                           Me.kans, Me.jaar, Me.b, Me.afwijkingValue, Me.algoritmeProp, Me.correct, Me.ont)
    End Function

    Public Function setKans(kans As Double) As Cursus
        Return New Cursus(Me.merk, Me.uitvCentr, Me.maand, Me.dag, Me.codeSubAfd, Me.totaal, Me.doorgegaan,
                           kans, Me.jaar, Me.b, Me.afwijkingValue, Me.algoritmeProp, Me.correct, Me.ont)
    End Function

    Public Function setJaar(jaar As Integer) As Cursus
        Return New Cursus(Me.merk, Me.uitvCentr, Me.maand, Me.dag, Me.codeSubAfd, Me.totaal, Me.doorgegaan,
                           Me.kans, jaar, Me.b, Me.afwijkingValue, Me.algoritmeProp, Me.correct, Me.ont)
    End Function

    Public Function setB(b As Double) As Cursus
        Return New Cursus(Me.merk, Me.uitvCentr, Me.maand, Me.dag, Me.codeSubAfd, Me.totaal, Me.doorgegaan,
                               Me.kans, Me.jaar, b, Me.afwijkingValue, Me.algoritmeProp, Me.correct, Me.ont)
    End Function

    Public Function setAfwijkingValue(afwijkingswaarde As Double, index As Integer) As Cursus
        afwijkingValue(index).setAfwijking(afwijkingswaarde)

        Return New Cursus(Me.merk, Me.uitvCentr, Me.maand, Me.dag, Me.codeSubAfd, Me.totaal, Me.doorgegaan,
                           Me.kans, Me.jaar, Me.b, afwijkingValue, Me.algoritmeProp, Me.correct, Me.ont)
    End Function

    Public Function setAlgoritme(algoritmeProp As Algoritmes) As Cursus
        Return New Cursus(Me.merk, Me.uitvCentr, Me.maand, Me.dag, Me.codeSubAfd, Me.totaal, Me.doorgegaan,
                           Me.kans, Me.jaar, Me.b, Me.afwijkingValue, algoritmeProp, Me.correct, Me.ont)
    End Function

    Public Function setIsCorrect(correct As Boolean) As Cursus
        Return New Cursus(Me.merk, Me.uitvCentr, Me.maand, Me.dag, Me.codeSubAfd, Me.totaal, Me.doorgegaan,
                               Me.kans, Me.jaar, Me.b, Me.afwijkingValue, Me.algoritmeProp, correct, Me.ont)
    End Function

    Public Function getMerk() As String
        Return merk
    End Function

    Public Function getUitvoerCentrum() As String
        Return uitvCentr
    End Function

    Public Function getMaand() As Integer
        Return maand
    End Function

    Public Function getDag() As String
        Return dag
    End Function

    Public Function getCodeSubafdeling() As String
        Return codeSubAfd
    End Function

    Public Function getTotaal() As Integer
        Return totaal
    End Function

    Public Function getAantalDoorgegaan() As Integer
        Return doorgegaan
    End Function

    Public Function getKans() As Double
        Return kans
    End Function

    Public Function getJaar() As Integer
        Return jaar
    End Function

    Public Function getB() As Double
        Return b
    End Function

    Public Function getAfwijkingswaarde(index As Integer) As Double
        Return afwijkingValue(index).getAfwijkingswaarde
    End Function

    Public Function getTverdelingsWaarde(index As Integer) As Double
        Return afwijkingValue(index).getTverdelingswaarde
    End Function

    Public Function getAfwijkingsString(index As Integer) As String
        Return afwijkingValue(index).getText
    End Function

    Public Function getAantalAfwijkingen() As Integer
        Return afwijkingValue.Count()
    End Function

    Public Function getAlgoritme() As Algoritmes
        Return algoritmeProp
    End Function

    Public Function getIsCorrect() As Boolean
        Return correct
    End Function
    Public Function getBereik(index As Integer) As Bereik
        Return New Bereik(afwijkingValue(index).getAfwijkingswaarde, kans * 100)
    End Function

    Public Function getOntw() As String
        Return ont
    End Function
#End Region
End Class

