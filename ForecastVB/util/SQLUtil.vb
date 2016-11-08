Imports System.Data.Odbc
Imports System.Configuration
Imports System.Data.SqlClient
Imports ForecastVB
'TODO: CLEAN UP!
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
    Public Function getArrayList2(command As String) As ArrayList
        myConn = New SqlConnection(sDatabaseLocatie)
        myCmd = myConn.CreateCommand
        myCmd.CommandText = command
        Try
            Dim arr As New ArrayList
            myConn.Open()
            myReader = myCmd.ExecuteReader()
            While myReader.Read()
                arr.Add({myReader.GetValue(0), myReader.GetValue(1), myReader.GetValue(2), myReader.GetValue(3), myReader.GetValue(4)})
            End While
            Return arr
        Catch ex As Exception
            Throw New Exception
        Finally
            myConn.Close()
        End Try
    End Function

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

    Friend Function getParameterForYear(script As String) As Parameter
        myConn = New SqlConnection(sDatabaseLocatie)
        myCmd = myConn.CreateCommand
        myCmd.CommandText = script

        Try
            Dim param As New Parameter
            Dim arr As New Dictionary(Of String, Parameter)
            myConn.Open()
            myReader = myCmd.ExecuteReader()
            While myReader.Read()
                param.setTotaal(myReader.GetValue(1))
                param.setNietGeschrapt(myReader.GetValue(2))
            End While
            Return param
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
    ''' <summary>
    ''' Geeft het aantal entries terug die geteld worden in de connection string (voorzie de count functie in de connectionstring)
    ''' </summary>
    ''' <param name="script">een SQL script die enkel de count terug geeft van het gewenste resultaat</param>
    ''' <returns></returns>
    Friend Function getCount(script As String) As Integer
        myConn = New SqlConnection(sDatabaseLocatie)
        myCmd = myConn.CreateCommand
        myCmd.CommandText = Command()

        Try
            myConn.Open()
            myReader = myCmd.ExecuteReader()
            Return myReader.Read()
        Finally
            myConn.Close()
        End Try
    End Function

    ''' <summary>
    ''' Maakt verbinding met DB en voert sql commando uit
    ''' </summary>
    ''' <param name="command">String, sql commando</param>
    ''' <returns>Parameter met key --> 1ste kolom, Value --> 2de en 3de kolom</returns>
    Public Function getDictionary(command As String) As Dictionary(Of String, Parameter)
        myConn = New SqlConnection(sDatabaseLocatie)
        myCmd = myConn.CreateCommand
        myCmd.CommandText = command
        Try
            Dim arr As New Dictionary(Of String, Parameter)
            myConn.Open()
            myReader = myCmd.ExecuteReader()
            While myReader.Read()
                Dim param As New Parameter(myReader.GetValue(1), myReader.GetValue(2))
                arr.Add(myReader.GetValue(0), param)
            End While
            Return arr
        Catch ex As Exception
            Throw New Exception
        Finally
            myConn.Close()
        End Try
    End Function
    Public Function getAll(command As String) As List(Of List(Of String))
        myConn = New SqlConnection(sDatabaseLocatie)
        myCmd = myConn.CreateCommand
        myCmd.CommandText = command

        Try
            Dim arr As New List(Of List(Of String))
            myConn.Open()
            myReader = myCmd.ExecuteReader()
            Dim dt As New DataTable()
            dt.Load(myReader)

            For i As Integer = 0 To dt.Rows.Count - 1
                Dim toAdd As New List(Of String)
                For k As Integer = 0 To dt.Columns.Count - 1
                    toAdd.Add(dt.Rows(i)(k))
                Next
                arr.Add(toAdd)
            Next
            Return arr
        Catch ex As Exception
            Throw New Exception
        Finally
            myConn.Close()
        End Try
    End Function


    Friend Function getDictionaryWithInteger(command As String) As Dictionary(Of Integer, Parameter)
        myConn = New SqlConnection(sDatabaseLocatie)
        myCmd = myConn.CreateCommand
        myCmd.CommandText = command

        Try
            Dim arr As New Dictionary(Of Integer, Parameter)
            myConn.Open()
            myReader = myCmd.ExecuteReader()
            While myReader.Read()
                Dim param As New Parameter(myReader.GetValue(1), myReader.GetValue(2))
                arr.Add(myReader.GetValue(0), param)
            End While
            Return arr
        Finally
            myConn.Close()
        End Try

        Return Nothing
    End Function
End Class