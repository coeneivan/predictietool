<Serializable()> Public Class Afwijking
    Private text As String
    Private tverdWaarde As Double
    Private afw As Double

    Public Sub New(t As String, tver As Double, afw As Double)
        text = t
        tverdWaarde = tver
        Me.afw = afw
    End Sub

    Public Function getText() As String
        Return text
    End Function

    Public Function getTverdelingswaarde() As Double
        Return tverdWaarde
    End Function

    Public Function getAfwijkingswaarde() As Double
        Return afw
    End Function

    Public Sub setText(t As String)
        text = t
    End Sub

    Public Sub setTverdelingswaarde(t As Double)
        tverdWaarde = t
    End Sub

    Public Sub setAfwijking(a As Double)
        afw = a
    End Sub
End Class
