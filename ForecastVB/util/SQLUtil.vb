Imports System.Data.SqlClient
''' <summary>
''' Maakt verbinding met DB
''' Zorgt er voor dat sql scripts kunnen uitgevoerd worden
''' </summary>
Public Class SQLUtil
    Private myConn As SqlConnection
    Private myCmd As SqlCommand
    Private myReader As SqlDataReader
    Private sDatabaseLocatie As String
    ''' <summary>
    ''' Initialiseert de klasse
    ''' Leest de connectionstring uit de file conn.txt die zich in de root bevindt
    ''' </summary>
    Public Sub New()
        Dim fileReader As String
        fileReader = My.Computer.FileSystem.ReadAllText("..\..\conn.txt")
        sDatabaseLocatie = fileReader.ToString
    End Sub

    ''' <summary>
    ''' Maakt verbinding met DB en voert sql commando uit
    ''' </summary>
    ''' <param name="command">String, sql commando</param>
    ''' <returns>Arraylist met eerste kolom</returns>
    Public Function getArrayList(command As String) As ArrayList
        myConn = New SqlConnection(sDatabaseLocatie)
        myCmd = myConn.CreateCommand
        myCmd.CommandText = command
        Try
            Dim arr As New ArrayList
            myConn.Open()
            myReader = myCmd.ExecuteReader()
            While myReader.Read()
                arr.Add(myReader.GetValue(0))
            End While
            Return arr
        Catch ex As Exception
            Throw New Exception
        Finally
            myConn.Close()
        End Try
    End Function
    Friend Function GetAllCursForAllVar(query As String) As List(Of Cursus)
        myConn = New SqlConnection(sDatabaseLocatie)
        myCmd = myConn.CreateCommand
        myCmd.CommandText = query

        Try
            Dim predic As New List(Of Cursus)
            Dim arr As New Dictionary(Of String, Parameter)
            myConn.Open()
            myReader = myCmd.ExecuteReader()

            While myReader.Read()
                Dim param As New Cursus(myReader.GetValue(0), myReader.GetValue(1), myReader.GetValue(2), myReader.GetValue(3), myReader.GetValue(4), myReader.GetValue(5), myReader.GetValue(6))
                predic.Add(param)
            End While

            Return predic
        Finally
            myConn.Close()
        End Try
    End Function
    Friend Function GetAllCursForAllVarWithYear(query As String) As List(Of Cursus)
        myConn = New SqlConnection(sDatabaseLocatie)
        myCmd = myConn.CreateCommand
        myCmd.CommandText = query

        Try
            Dim predic As New List(Of Cursus)
            Dim arr As New Dictionary(Of String, Parameter)
            myConn.Open()
            myReader = myCmd.ExecuteReader()

            While myReader.Read()
                Dim param As New Cursus(myReader.GetValue(0), myReader.GetValue(1), myReader.GetValue(2), myReader.GetValue(3), myReader.GetValue(4), myReader.GetValue(5), myReader.GetValue(6), myReader.GetValue(7))
                predic.Add(param)
            End While

            Return predic
        Finally
            myConn.Close()
        End Try
    End Function
    Friend Function GetAllCursForAllVarWithOnt(query As String) As List(Of Cursus)
        myConn = New SqlConnection(sDatabaseLocatie)
        myCmd = myConn.CreateCommand
        myCmd.CommandText = query

        Try
            Dim predic As New List(Of Cursus)
            Dim arr As New Dictionary(Of String, Parameter)
            myConn.Open()
            myReader = myCmd.ExecuteReader()

            While myReader.Read()
                Dim param As New Cursus(myReader.GetValue(0), myReader.GetValue(1), myReader.GetValue(2), myReader.GetValue(3), myReader.GetValue(4))
                predic.Add(param)
            End While

            Return predic
        Finally
            myConn.Close()
        End Try
    End Function
End Class