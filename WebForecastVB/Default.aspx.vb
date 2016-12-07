Imports System.Globalization
Imports CursusPredictie
Imports System.Windows

Public Class _Default
    Inherits System.Web.UI.Page
    Private b As CursusKansBerekening
    Private allItems As List(Of Cursus)
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim f = " Aard NOT IN (15,29,14,58,12,13) and OmschrijvingComm NOT LIKE '%SELOR%' and OmschrijvingComm NOT LIKE '%Bekwaamheidsattest%' and OmschrijvingComm NOT LIKE"
        f += " '%stage%' and OmschrijvingComm NOT LIKE '%proef%' and OmschrijvingComm NOT LIKE '%attest%' and OmschrijvingComm NOT LIKE '%aanvullende praktijk%' and OmschrijvingComm"
        f += " Not Like '%eindwerk%' and OmschrijvingComm NOT LIKE '%AP%' Collate SQL_Latin1_General_CP1_CS_AS and OmschrijvingComm NOT LIKE 'POC%' Collate SQL_Latin1_General_CP1_CS_AS"
        f += " And OmschrijvingComm Not Like 'C.I.%' Collate SQL_Latin1_General_CP1_CS_AS and OmschrijvingComm NOT LIKE 'P.S.%' Collate SQL_Latin1_General_CP1_CS_AS and OmschrijvingComm"
        f += " Not Like 'LeReN%' Collate SQL_Latin1_General_CP1_CS_AS and OmschrijvingComm NOT LIKE 'Lerend%' Collate SQL_Latin1_General_CP1_CS_AS and OmschrijvingComm NOT LIKE 'Iedereen"
        f += " leert%' and OmschrijvingComm NOT LIKE 'Bedrijvig Brugge%' and OmschrijvingComm NOT LIKE '%testavond%' and OmschrijvingComm NOT LIKE 'Talent%' and OmschrijvingComm NOT LIKE"
        f += "  '%Spoor 1%' and OmschrijvingComm NOT LIKE '%Spoor 2%' and OmschrijvingComm NOT LIKE '%Spoor 3%' and OmschrijvingComm NOT LIKE '%Spoor 4%' and OmschrijvingComm"
        f += "  NOT LIKE '%Spoor 5%' and OmschrijvingComm NOT LIKE '%examen%' and Jaar NOT LIKE '%proef%' and Jaar NOT LIKE '%stage%' "

        allItems = ForecastVB.TestBLL.GetAllCursForAllVar(f)
        b = New CursusKansBerekening(allItems)
        allItems = b.BerekenKans()
        If Not Page.IsPostBack Then
            loadComboboxes()
        End If
    End Sub
    Private Sub loadComboboxes()

        Dim merk = b.getMerken().ToArray
        Dim centra = b.getCentra().ToArray
        Dim subafdelingen = b.getSubafdelingen().ToArray
        linkDataToDDL(ddlMerk, merk)
        linkDataToDDL(ddlCentrum, centra)
        linkDataToDDL(ddlSubAfd, subafdelingen)
    End Sub
    Private Sub linkDataToDDL(ddl As DropDownList, data As Array)
        Array.Sort(data)
        ddl.DataSource = data
        ddl.DataBind()
    End Sub

    Protected Sub btnGetOpleiding_Click(sender As Object, e As EventArgs) Handles btnGetOpleiding.Click
        Dim cursus As CursusPredictie.Cursus 'TODO select cursus
        Dim testBLL As New ForecastVB.TestBLL
        Dim startDatum As New Date

        Try
            If txtOpleidingsnummer.Text = Nothing Then Throw New ApplicationException("Gelieve een opleidsingsnummer in te geven")
            testBLL.GetCursusByOpleidingsnummer(txtOpleidingsnummer.Text.Trim, cursus, startDatum)
            selectFromDLL(cursus.getMerk, ddlMerk)
            selectFromDLL(cursus.getUitvoerCentrum, ddlCentrum)
            selectFromDLL(cursus.getCodeSubafdeling, ddlSubAfd)

            txtDatum.Text = startDatum.ToShortDateString
        Catch ex As ApplicationException
            'MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub selectFromDLL(toSelect As String, ddl As DropDownList)
        ddl.ClearSelection()
        ddl.Items.FindByText(toSelect).Selected = True
    End Sub

    Protected Sub btnBeterken_Click(sender As Object, e As EventArgs) Handles btnBeterken.Click
        If ddlCentrum.SelectedItem Is Nothing Then
            Throw New ApplicationException("Gelieve een merk te selecteren aub")
        Else
            If ddlCentrum.SelectedItem Is Nothing Then
                Throw New ApplicationException("Gelieve een uitvoerend centrum te selecteren aub")
            Else
                If ddlSubAfd.SelectedItem Is Nothing Then
                    Throw New ApplicationException("Gelieve een code subafdeling te selecteren aub")
                Else
                    Dim edate = txtDatum.Text
                    Dim startDate As Date = Date.ParseExact(edate, "dd/MM/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo)
                    Dim c As New CursusPredictie.Cursus(ddlMerk.SelectedItem.ToString, ddlCentrum.SelectedItem.ToString, startDate.Month.ToString, startDate.ToString("dddd", New CultureInfo("nl-BE")), ddlSubAfd.SelectedItem.ToString, 0, 0, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)
                    Dim gevonden As Boolean = False

                    For Each item As Cursus In allItems
                        If item.getMerk = c.getMerk Then
                            If item.getUitvoerCentrum = c.getUitvoerCentrum Then
                                If item.getMaand = c.getMaand Then
                                    If item.getDag = c.getDag Then
                                        If item.getCodeSubafdeling = c.getCodeSubafdeling Then
                                            c = item
                                            gevonden = True
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    Next

                    If Not gevonden Then
                        c = b.BerekenVoorCursus(c)

                        Dim t As New tVerdeling
                        For i As Integer = 0 To t.getBetrouwbaarheidsIntervallen.Count - 1
                            c = c.setAfwijkingValue(100, i)
                        Next
                    End If

                    txtTotaal.Text = c.getBereik(0).ToString

                    If c.getTotaal > 0 Then
                        If c.getTotaal = 1 Then
                            lblRealisatie.Text = "Realisatiegraad bepaald met 1 enkele cursus:"
                        Else
                            lblRealisatie.Text = "Realisatiegraad bepaald met " + c.getTotaal.ToString + " cursussen:"
                        End If
                    Else
                        lblRealisatie.Text = "Realisatiegraad met nieuwe situatie"
                    End If
                End If
            End If
        End If
    End Sub
End Class