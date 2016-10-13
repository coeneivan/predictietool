''' <summary>
''' DB filtreren a.d.h.v. kolom filters
''' </summary>
Public Class FilterItem
    Private kolom As String
    Private factor As String
    Private filter As String
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
    ''' Geeft kolomnaam terug waarop er gefilterd word
    ''' </summary>
    ''' <returns>String, kolom naam</returns>
    Public Function getKolom() As String
        Return kolom
    End Function
    ''' <summary>
    ''' Geeft de factor van de filter terug
    ''' </summary>
    ''' <returns>String, factor (bv = of !=)</returns>
    Public Function getFactor() As String
        Return factor
    End Function
    ''' <summary>
    ''' Geeft filterwaarde terug
    ''' </summary>
    ''' <returns>String, filterwaarde</returns>
    Public Function getFilter() As String
        Return filter
    End Function
    ''' <summary>
    ''' Zet de waarde van kolom
    ''' </summary>
    ''' <param name="k">String, kolomnaam waarop er gefilterd moet worden</param>
    Public Sub setKolom(k As String)
        kolom = k
    End Sub
    ''' <summary>
    ''' Zet waarde van de factor
    ''' </summary>
    ''' <param name="f">String, factor (bv = of !=)</param>
    Public Sub setFactor(f As String)
        factor = f
    End Sub
    ''' <summary>
    ''' Zet waarde van filter
    ''' </summary>
    ''' <param name="f">String, filterwaarde</param>
    Public Sub setFilter(f As String)
        filter = f
    End Sub
End Class
