Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports System.Web.Script.Serialization
Imports System.Web
''' <summary>
''' Lezen en schrijven van JSONfiles
''' </summary>
Public Class JSONParser
    Private fileReader As String
    ''' <summary>
    ''' Leest het JSON bestand en geeft een arraylist terug
    ''' </summary>
    ''' <param name="filePath">Bestands pad en naam met extensie</param>
    ''' <returns>Arraylist met alle filter-items uit het bestand</returns>
    Public Function readFilters(filePath As String) As ArrayList
        'Dim json As String = filePath
        Dim ser As JArray = JArray.Parse(My.Computer.FileSystem.ReadAllText(filePath))
        Dim data As List(Of JToken) = ser.Children().ToList
        Dim list As New ArrayList

        For Each item As JObject In data
            item.CreateReader()
            Dim k As String = item("kolom")
            Dim fa As String = item("factor")
            Dim fi As String = item("filter")
            list.Add(New FilterItem(k, fa, fi))
        Next
        Return list
    End Function

    ''' <summary>
    ''' Maakt arraylist klaar om in een JSON bestand op te slaan
    ''' </summary>
    ''' <param name="filters">Arraylist met alle filter-items</param>
    ''' <returns>String die in het bestand zal komen</returns>
    Public Function save(filters As ArrayList) As String
        Dim serializer As New JavaScriptSerializer()
        Return serializer.Serialize(filters.ToArray)
    End Function
End Class
