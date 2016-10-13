Imports ForecastVB.FilterItem


''' <summary>
''' Zorgt voor het opmaken van sql scripts en geeft ze door aan sqlutil
''' </summary>
Public Class ParametersDAO
    ''' <summary>
    ''' Geeft alle data in een Dictionary terug voor een bepaalde parameter
    ''' </summary>
    ''' <param name="jaar">Integer, het resultaat zal plaatsvinden voor dit jaar</param>
    ''' <param name="paramaeter">String naam van een bepaalde parameter</param>
    ''' <param name="value">String met waarde van de parameter</param>
    ''' <returns>Arralyst met de gekende jaren voor de meegegeven parameterwaarde</returns>
    Public Function getCursussen(jaar As Integer, paramaeter As String, value As String, filter As ArrayList) As Dictionary(Of String, Parameter)
        Dim s As New SQLUtil

        If filter Is Nothing Then
            Return s.getDictionary("SELECT YEAR(c.startdatum) as jaar,count(*) as totaal,(SELECT count(*) FROM [SyntraTest].[dbo].[Cursussen] as cc WHERE cc.CodeIngetrokken = 'nee' AND " + paramaeter + " = '" + value + "' AND year(cc.StartDatum) = year(c.StartDatum)) as nietGeschrapt FROM [SyntraTest].[dbo].[Cursussen] as c WHERE " + paramaeter + " = '" + value + "' AND year(c.StartDatum) < " + jaar.ToString + " GROUP BY year(c.startDatum)")
        Else
            Dim fil As String
            fil = ""

            For i As Integer = 0 To filter.Count - 1
                Dim filIt As FilterItem
                filIt = filter.Item(i)
                fil += " AND " + filIt.getKolom + " " + filIt.getFactor + " " + filIt.getFilter

            Next

            Return s.getDictionary("SELECT YEAR(c.startdatum) as jaar,count(*) as totaal,(SELECT count(*) FROM [SyntraTest].[dbo].[Cursussen] as cc WHERE cc.CodeIngetrokken = 'nee' AND " + paramaeter + " = '" + value + "' AND year(cc.StartDatum) = year(c.StartDatum)) as nietGeschrapt FROM [SyntraTest].[dbo].[Cursussen] as c WHERE " + paramaeter + " = '" + value + "' AND year(c.StartDatum) < " + jaar.ToString + fil + " GROUP BY year(c.startDatum)")
        End If
    End Function
    ''' <summary>
    ''' Geeft een arraylist weer met alle gekende data
    ''' </summary>
    ''' <param name="jaar">Tot welke jaar moet er gezocht worden?</param>
    ''' <param name="parameter">String met de naam van de parameter</param>
    ''' <returns>Arraylist met 1 kolom, de gekende data</returns>
    Public Function getAll(jaar As Integer, parameter As String)
        Dim s As New SQLUtil
        Return s.getArrayList("SELECT distinct " + parameter + "  FROM [SyntraTest].[dbo].[Cursussen]")
    End Function
End Class
