Public Class Cursus
    Private opleidingsnr As String
    Private startDatum As Date
    Private dag As String
    Private merk As String
    Private centrum As String
    Private subafdeling As String
    Private ingetrokken As Boolean
    Public Sub New()

    End Sub
    Public Sub New(o As String, sd As Date, d As String, m As String, c As String, sa As String, i As Boolean)
        opleidingsnr = o
        startDatum = sd
        dag = d
        merk = m
        centrum = c
        subafdeling = sa
        ingetrokken = i
    End Sub
    Public Property nummer() As String
        Get
            Return opleidingsnr
        End Get
        Set(ByVal value As String)
            opleidingsnr = value
        End Set
    End Property

    Public Property datum() As String
        Get
            Return startDatum
        End Get
        Set(ByVal value As String)
            startDatum = value
        End Set
    End Property
    Public Property lesdag() As String
        Get
            Return dag
        End Get
        Set(ByVal value As String)
            dag = value
        End Set
    End Property

    Public Property merkVanCursus() As String
        Get
            Return merk
        End Get
        Set(ByVal value As String)
            merk = value
        End Set
    End Property
    Public Property uitvoerendCentrum() As String
        Get
            Return centrum
        End Get
        Set(ByVal value As String)
            centrum = value
        End Set
    End Property
    Public Property codeSubafdeling() As String
        Get
            Return subafdeling
        End Get
        Set(ByVal value As String)
            subafdeling = value
        End Set
    End Property

    Public Property codeIngetrokken() As Boolean
        Get
            Return ingetrokken
        End Get
        Set(ByVal value As Boolean)
            ingetrokken = value
        End Set
    End Property
End Class