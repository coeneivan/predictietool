Imports System.Data.Odbc
Imports System.Data.SqlClient
Public Class SQLUtil
    Private myConn As SqlConnection
    Private myCmd As SqlCommand
    Private myReader As SqlDataReader
    Private sDatabaseLocatie As String = "Data Source=USER-PC\SQLEXPRESS;Initial Catalog=SyntraTest;Integrated Security=True"

    Public Function Execute(command As String) As ArrayList
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

End Class