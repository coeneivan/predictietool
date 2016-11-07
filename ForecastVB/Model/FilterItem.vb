''' <summary>
''' DB filtreren a.d.h.v. kolom filters
''' </summary>
Public Class FilterItem
    Public kolom As String
    Public factor As String
    Public filter As String
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
