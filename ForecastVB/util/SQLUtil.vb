Imports System.Data.SqlClient
Imports System.IO
Imports System.Web
Imports CursusPredictie

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
        Dim s As String

        If (HttpContext.Current IsNot Nothing) Then
            s = HttpContext.Current.Server.MapPath("\")
        Else
            s = "..\..\"
        End If

        fileReader = My.Computer.FileSystem.ReadAllText(s + "conn.txt")
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
    Public Function GetAllCursForAllVar(query As String) As List(Of Cursus)
        myConn = New SqlConnection(sDatabaseLocatie)
        myCmd = myConn.CreateCommand
        myCmd.CommandText = query

        Try
            Dim predic As New List(Of Cursus)
            myConn.Open()
            myReader = myCmd.ExecuteReader()

            While myReader.Read()
                Dim param As New Cursus(myReader.GetValue(0), myReader.GetValue(1), myReader.GetValue(2), myReader.GetValue(3), myReader.GetValue(4), myReader.GetValue(5), myReader.GetValue(6),
                                                 Nothing, Nothing, Nothing, Nothing, Algoritmes.Niets, False, Nothing)
                predic.Add(param)
            End While

            Return predic
        Finally
            myConn.Close()
        End Try
    End Function
    Public Function GetAllCursForAllVarWithYear(query As String) As List(Of Cursus)
        myConn = New SqlConnection(sDatabaseLocatie)
        myCmd = myConn.CreateCommand
        myCmd.CommandText = query

        Try
            Dim predic As New List(Of Cursus)
            myConn.Open()
            myReader = myCmd.ExecuteReader()

            While myReader.Read()
                Dim param As New Cursus(myReader.GetValue(0), myReader.GetValue(1), myReader.GetValue(2), myReader.GetValue(3), myReader.GetValue(4), myReader.GetValue(5), myReader.GetValue(6),
                                                 Nothing, myReader.GetValue(7), Nothing, Nothing, Algoritmes.Niets, False, Nothing)
                predic.Add(param)
            End While

            Return predic
        Finally
            myConn.Close()
        End Try
    End Function
    'Voor ontwikkelaar
    Public Function getAlles(script As String) As DataTable
        myConn = New SqlConnection(sDatabaseLocatie)
        myCmd = myConn.CreateCommand
        myCmd.CommandText = script
        Dim dt As New DataTable

        Try
            myConn.Open()
            myReader = myCmd.ExecuteReader()
            dt.Load(myReader)
            Return dt
        Finally
            myConn.Close()
        End Try
    End Function
End Class