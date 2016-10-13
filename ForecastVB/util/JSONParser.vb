Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports System.Web.Script.Serialization
Imports System.Web
Public Class JSONParser
    Private fileReader As String
    Public Function read(filePath As String) As ArrayList
        Dim json As String = filePath
        Dim ser As JObject = JObject.Parse(json)
        Dim data As List(Of JToken) = ser.Children().ToList
        Dim list As New ArrayList

        For Each item As JProperty In data
            item.CreateReader()
            If item.Name = "filter" Then
                For Each comment As JObject In item.Values
                    Dim k As String = comment("kolom")
                    Dim fa As String = comment("factor")
                    Dim fi As String = comment("filter")
                    list.Add(New FilterItem(k, fa, fi))
                Next
            End If
        Next
        Return list
    End Function
    Public Function save(filters As ArrayList, filepath As String) As Boolean
        Dim serializer As New JavaScriptSerializer()
        serializer.Serialize(filters.ToArray)
        Return True
    End Function
End Class
