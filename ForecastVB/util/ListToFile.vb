Imports System.IO
Imports System.Runtime.Serialization
''' <summary>
''' Openen en opslaan van lijsten
''' </summary>
Public Class ListToFile
    ''' <summary>
    ''' Slaat een lijst op in een bepaalde plaats
    ''' </summary>
    ''' <param name="theList">De lijst van cursusen dat opgeslaan moet worden</param>
    ''' <param name="path">Het pad waar de lijst moet opgeslaan worden</param>
    ''' <example>saveTheList(cursussen, "c:/temp/data.xml")</example>
    Friend Sub saveTheList(theList As Dictionary(Of String, List(Of Cursus)), path As String)
        Dim stream As Stream
        Try
            stream = File.Open(path, FileMode.Create)
            Dim formatter As New Formatters.Binary.BinaryFormatter()
            formatter.Serialize(stream, theList)
        Catch ex As Exception
            'TODO: fixme
            Throw ex
        Finally
            stream.Close()
        End Try


    End Sub
    ''' <summary>
    ''' Leest een bestand uit en zet het om naar een lijst
    ''' </summary>
    ''' <param name="path">Het pad waar de lijst zich bevindt</param>
    ''' <returns>De ingelezen lijst van Cursussen</returns>
    ''' <example>Dim cursussen as List(Of Cursus) = openTheList("c:/temp/data.xml")</example>
    Friend Function openTheList(path As String) As Dictionary(Of String, List(Of Cursus))
        Dim theList As Dictionary(Of String, List(Of Cursus))
        Try
            Dim stream As Stream = File.Open(path, FileMode.Open)
            Dim Formatter = New Formatters.Binary.BinaryFormatter()
            theList = CType(Formatter.Deserialize(stream), Dictionary(Of String, List(Of Cursus)))
            stream.Close()

            Return theList
        Catch ex As Exception
            'TODO: fixen
            Throw ex
        End Try

    End Function

End Class
