Imports System.Globalization

Public Class _Default
    Inherits System.Web.UI.Page
    Private b As ForecastVB.Bayes_Bayes_Linear
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        b = New ForecastVB.Bayes_Bayes_Linear(Nothing, False)
        Dim lists = b.getData(New ArrayList)
        If Not Page.IsPostBack Then
            loadComboboxes()
        End If
    End Sub
    Private Sub loadComboboxes()
        'TODO:load comboboxes with real data
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
        Dim cursus As ForecastVB.Cursus 'TODO select cursus
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
                    Dim c As New ForecastVB.Cursus(ddlMerk.SelectedItem.ToString, ddlCentrum.SelectedItem.ToString, startDate.Month.ToString, startDate.ToString("dddd", New CultureInfo("nl-BE")), ddlSubAfd.SelectedItem.ToString, 0, 0, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)
                    c = b.getKansVoorCursus(c)
                    txtTotaal.Text = c.getBereik(0.995).ToString

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