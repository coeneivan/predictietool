Public Class CursusExtraInfo
    Private opleidingsnr As String
    Private OmschrijvingComm As String
    Private dag As String
    Private EindDatum As String
    Private StartDatum As String
    Private TotalePrijs As String
    Private Merk As String
    Private UitvCentrumOmsch As String
    Private Aard As String
    Private CaM As String
    Private CuB As String
    Private OpC As String
    Private Ont As String
    Private CoC As String
    Private CodeSubafdeling As String
    Private CodeIngetrokken As String
    Private Lesplaats As String
    Private OpInternet As String
    Private LesroosterGevalideerd As String
    Private AtlCursisten As String
    Public Sub New(o As String, omsch As String, d As String, start As String, eind As String, tprijs As String, m As String, uc As String, a As String, ca As String, cu As String, op As String, ontwikkelaar As String, co As String, sa As String, ingetrokken As String, lp As String, internet As String, lesrooster As String, atl As String)
        opleidingsnr = o
        OmschrijvingComm = omsch
        dag = d
        StartDatum = start
        EindDatum = eind
        TotalePrijs = tprijs
        Merk = m
        UitvCentrumOmsch = uc
        Aard = a
        CaM = ca
        CuB = cu
        OpC = op
        Ont = ontwikkelaar
        CoC = co
        CodeSubafdeling = deSubAfd
        CodeIngetrokken = ingetrokken
        Lesplaats = plaats
        OpInternet = internet
        LesroosterGevalideerd = lesrooster
        AtlCursisten = atl

    End Sub


    Public Property oNr() As String
        Get
            Return opleidingsnr
        End Get
        Set(ByVal value As String)
            opleidingsnr = value
        End Set
    End Property

    Public Property omschrijving() As String
        Get
            Return OmschrijvingComm
        End Get
        Set(ByVal value As String)
            OmschrijvingComm = value
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

    Public Property datumStart() As String
        Get
            Return EindDatum
        End Get
        Set(ByVal value As String)
            EindDatum = value
        End Set
    End Property
    Public Property datumEinde() As String
        Get
            Return StartDatum
        End Get
        Set(ByVal value As String)
            StartDatum = value
        End Set
    End Property

    Public Property prijs() As String
        Get
            Return TotalePrijs
        End Get
        Set(ByVal value As String)
            TotalePrijs = value
        End Set
    End Property

    Public Property hetMerk() As String
        Get
            Return Merk
        End Get
        Set(ByVal value As String)
            Merk = value
        End Set
    End Property

    Public Property centrum() As String
        Get
            Return UitvCentrumOmsch
        End Get
        Set(ByVal value As String)
            UitvCentrumOmsch = value
        End Set
    End Property

    Public Property deAard() As String
        Get
            Return Aard
        End Get
        Set(ByVal value As String)
            Aard = value
        End Set
    End Property

    Public Property deCaM() As String
        Get
            Return CaM
        End Get
        Set(ByVal value As String)
            CaM = value
        End Set
    End Property

    Public Property deCuB() As String
        Get
            Return CuB
        End Get
        Set(ByVal value As String)
            CuB = value
        End Set
    End Property
    Public Property deOpC() As String
        Get
            Return OpC
        End Get
        Set(ByVal value As String)
            OpC = value
        End Set
    End Property
    Public Property deOnt() As String
        Get
            Return Ont
        End Get
        Set(ByVal value As String)
            Ont = value
        End Set
    End Property
    Public Property deCoc() As String
        Get
            Return CoC
        End Get
        Set(ByVal value As String)
            CoC = value
        End Set
    End Property
    Public Property deSubAfd() As String
        Get
            Return CodeSubafdeling
        End Get
        Set(ByVal value As String)
            CodeSubafdeling = value
        End Set
    End Property
    Public Property isIngetrokken() As String
        Get
            Return CodeIngetrokken
        End Get
        Set(ByVal value As String)
            CodeIngetrokken = value
        End Set
    End Property
    Public Property plaats() As String
        Get
            Return Lesplaats
        End Get
        Set(ByVal value As String)
            Lesplaats = value
        End Set
    End Property
    Public Property isOpInternet() As String
        Get
            Return OpInternet
        End Get
        Set(ByVal value As String)
            OpInternet = value
        End Set
    End Property
    Public Property gevalideerd() As String
        Get
            Return LesroosterGevalideerd
        End Get
        Set(ByVal value As String)
            LesroosterGevalideerd = value
        End Set
    End Property
    Public Property aantalCursisten() As String
        Get
            Return AtlCursisten
        End Get
        Set(ByVal value As String)
            AtlCursisten = value
        End Set
    End Property
End Class
