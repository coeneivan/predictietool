Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports System.Web.Script.Serialization
Imports System.Web
Public Class JSONParser
    Private fileReader As String
    Public Function read(filePath As String) As ArrayList
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

    Public Function save(filters As ArrayList) As String
        Dim serializer As New JavaScriptSerializer()
        Return serializer.Serialize(filters.ToArray)
    End Function
End Class
