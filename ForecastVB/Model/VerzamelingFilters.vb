Public Class VerzamelingFilters
    Private filters As ArrayList
    Public Sub New()
        filters = New ArrayList
    End Sub

    Public Property NewProperty() As ArrayList
        Get
            Return filters
        End Get
        Set(ByVal value As ArrayList)
            filters = value
        End Set
    End Property
End Class
