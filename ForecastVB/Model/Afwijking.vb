﻿<Serializable()> Public Class Afwijking
    Private tverdWaarde As Double
    Private afw As Double

    Public Sub New(tver As Double, afw As Double)
        tverdWaarde = tver
        Me.afw = afw
    End Sub

    Public Function getText() As String
        Return (tverdWaarde * 100).ToString + "%"
    End Function

    Public Function getTverdelingswaarde() As Double
        Return tverdWaarde
    End Function

    Public Function getAfwijkingswaarde() As Double
        Return afw
    End Function

    Public Sub setTverdelingswaarde(t As Double)
        tverdWaarde = t
    End Sub

    Public Sub setAfwijking(a As Double)
        afw = a
    End Sub
End Class