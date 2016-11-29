﻿''' <summary>
''' DB filtreren a.d.h.v. kolom filters
''' </summary>
Public Class FilterItem
    Private k As String ' Kollom waarop de filter moet worden toegepast
    Private fa As String ' Factor waarmee wordt gefilterd (=, <=, <>, ...)
    Private fi As String ' Filter waarde zelf


    Public Property kolom() As String
        Get
            Return k
        End Get
        Set(ByVal value As String)
            k = value
        End Set
    End Property

    Public Property factor() As String
        Get
            Return fa
        End Get
        Set(ByVal value As String)
            fa = value
        End Set
    End Property


    Public Property filter() As String
        Get
            Return fi
        End Get
        Set(ByVal value As String)
            fi = value
        End Set
    End Property


    ''' <summary>
    ''' DB filtreren a.d.h.v. kolom filters
    ''' </summary>
    ''' <param name="k">String, Kolom naam waarop er gefilterd moet worden</param>
    ''' <param name="fa">String, factor (bv: = of !=)</param>
    ''' <param name="fi">String, filter-waarde</param>
    Public Sub New(k As String, fa As String, fi As String)
        kolom = k
        factor = fa
        filter = fi
    End Sub
    ''' <summary>
    ''' Intialiseert klasse zonder parameters (gebruik setters)
    ''' </summary>
    Public Sub New()

    End Sub
    ''' <summary>
    ''' String weergave van filter item
    ''' </summary>
    ''' <returns>String weergave van filter om te gebruiken in sql script</returns>
    Public Overrides Function toString() As String
        Return k + " " + fa + " " + fi + " "
    End Function
End Class
