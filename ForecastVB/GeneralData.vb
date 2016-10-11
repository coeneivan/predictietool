Public Class GeneralData
    'Ik ga lekker moeilijk doen!
    Dim berekeningsjaar As Int16 = 2015

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        createForm()
        AutoScroll = True

    End Sub

    Private Sub createForm()
        Dim allAfd = getAllSubafdelingenVoorJaar(berekeningsjaar)
        Dim x As Long = 0
        Dim jumpX = 250
        Dim y As Long = 0
        Dim jumpY = 250

        For Each afd As String In allAfd
            createBlock(x, y, afd)
            x += jumpX

            ' Hoeveel pixels breed mag er gegaan worden voor nieuwe lijn gestart moet worden?
            ' Pas aan volgens resolutie van scherm
            If (x >= 1800) Then
                x = 0
                y += jumpY
            End If
        Next


    End Sub

    ''' <summary>
    ''' Haalt de lijst op met alle subafdelingen
    ''' </summary>
    ''' <returns>Geeft de lijst met alle subafdelingen in een ArrayList terug</returns>
    Private Function getAllSubafdelingenVoorJaar(jaar As Int16) As ArrayList
        Dim allAfd = New subAfdBll
        Return allAfd.getAallSubAfds(jaar)
    End Function

    ''' <summary>
    ''' Creeërt blok waar alle info van 1 subafdeling in geplaatst wordt. Deze worden dan vervolgens voor elke subafdeling herhaald
    ''' </summary>
    ''' <param name="startX">Wat is de X waarde van waar de gegevens moeten beginnen. Dit om overlapping met een vorige blok te voorkomen</param>
    ''' <param name="startY">Wat is de Y waarde van waar de gegevens moeten beginnen. Dit om overlapping met een vorige blok te voorkomen</param>
    ''' <param name="subAfd">Om welke subafdeling gaat het?</param>
    Private Sub createBlock(startX As Long, startY As Long, subAfd As String)
        Dim allAfd = New subAfdBll
        Dim jaar As Int16 = 2015
        Dim subafdljaar = allAfd.getAantalCursussenPerJaarPerSubAfd(berekeningsjaar, subAfd)


        ' Creeër label titel
        Dim lblTitel = New Label()
        lblTitel.Size = New System.Drawing.Size(159, 23)
        lblTitel.Location = New System.Drawing.Point(startX + 12, startY + 12)
        lblTitel.Text = (subAfd)
        lblTitel.Font = New Font(lblTitel.Font, FontStyle.Bold)
        Me.Controls.Add(lblTitel)

        ' Creeër label jaar
        Dim lblJaar = New Label()
        lblJaar.Size = New System.Drawing.Size(159, 23)
        lblJaar.Location = New System.Drawing.Point(startX + 12, startY + 33)
        lblJaar.Text = ("Jaar: " + berekeningsjaar.ToString)
        Me.Controls.Add(lblJaar)

        ' Creeër label Werkelijke percentage voor de subafdeling
        Dim lblSlaag = New Label()
        lblSlaag.Size = New System.Drawing.Size(159, 23)
        lblSlaag.Location = New System.Drawing.Point(startX + 12, startY + 54)
        lblSlaag.Text = ("iets")
        Me.Controls.Add(lblSlaag)
    End Sub
End Class