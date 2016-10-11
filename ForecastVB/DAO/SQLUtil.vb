Imports System.Data.Odbc
Imports System.Data.SqlClient
Public Class SQLUtil
    Private myConn As SqlConnection
    Private myCmd As SqlCommand
    Private myReader As SqlDataReader
    'Private sDatabaseLocatie As String = "Data Source=USER-PC\SQLEXPRESS;Initial Catalog=SyntraTest;Integrated Security=True"
    Private sDatabaseLocatie As String = "Data Source=laptop-BEN_ASUS\;Initial Catalog=SyntraTest;Integrated Security=True"

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
            MessageBox.Show(ex.ToString(), "ERROR Please contact Developer", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'TODO Throw exception instead
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
            MessageBox.Show(ex.ToString(), "ERROR Please contact Developer", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'TODO Throw exception instead
        Finally
            myConn.Close()
        End Try
    End Function

End Class