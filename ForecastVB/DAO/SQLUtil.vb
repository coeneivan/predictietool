Imports System.Data.SqlClient
Public Class SQLUtil
    Private myConn As SqlConnection
    Private myCmd As SqlCommand
    Private myReader As SqlDataReader
    Private results As String
    Private sDatabaseLocatie As String = "Data Source=USER-PC\SQLEXPRESS;Initial Catalog=SyntraTest;Integrated Security=True"


    Public Sub SQLUtil()
        myConn = New SqlConnection(sDatabaseLocatie)
        myCmd = myConn.CreateCommand
        myCmd.CommandText = "SELECT * FROM Cursussen"
        myConn.Open()
        myReader = myCmd.ExecuteReader()
    End Sub
End Class
