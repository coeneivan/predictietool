''' <summary>
''' DB filtreren a.d.h.v. kolom filters
''' </summary>
Public Class FilterItem
    Private k As String
    Public Property kolom() As String
        Get
            Return k
        End Get
        Set(ByVal value As String)
            k = value
        End Set
    End Property
    Private fa As String
    Public Property factor() As String
        Get
            Return fa
        End Get
        Set(ByVal value As String)
            fa = value
        End Set
    End Property
    Private fi As String
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
End Class
