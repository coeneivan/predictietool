Imports System.IO
Imports Microsoft.VisualBasic.FileIO

Public Class MainScreen
    Private filters As New ArrayList
    Private filterlist As ArrayList
    Private selectedFilterList As String
    Private saveDirectory As String = SpecialDirectories.MyDocuments + "//Predictie Filters//"

    Private Sub MainScreen_Load(sender As Object, e As EventArgs) Handles MyBase.Load


    End Sub
    Public Sub refreshFilterList()
        Try
            filterlist = New ArrayList
            cboFiltersList.Items.Clear()
            Dim filterFiles As String() = Directory.GetFiles(saveDirectory)
            For Each file As String In filterFiles
                Dim filterNames As String = System.IO.Path.GetFileNameWithoutExtension(file)
                filterlist.Add(filterNames)
            Next
            cboFiltersList.Items.AddRange(filterlist.ToArray)
        Catch ex As Exception
            'TODO: catch it!
            Throw ex
        End Try
        selectedFilterList = My.Settings.selectedFilterList
        cboFiltersList.SelectedItem = selectedFilterList
    End Sub

    Private Sub cboMerk_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboMerk.SelectedIndexChanged

    End Sub
    Private Sub cboUitvCent_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboUitvCent.SelectedIndexChanged

    End Sub
    Private Sub cboSubAfd_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSubAfd.SelectedIndexChanged

    End Sub
    Private Sub dtpStartcursus_ValueChanged(sender As Object, e As EventArgs) Handles dtpStartcursus.ValueChanged
        'dtpStartcursus.Value.Month.ToString
    End Sub
    Private Sub cboLesdag_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboLesdag.SelectedIndexChanged

    End Sub

    Private Sub btnFilter_Click(sender As Object, e As EventArgs) Handles btnFilter.Click
        Dim settings As New Settings(Me)
        settings.Show()
    End Sub

    Public Sub addFilters(filters As ArrayList)
        filters.AddRange(filters)
    End Sub
    Public Function getFilters() As ArrayList
        Return filters
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim t As New Test(Me)
        t.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        txtTotaal.Text = "ERROR"
    End Sub

    Public Function getSelectedList() As String
        Return selectedFilterList
    End Function
    Public Function getFilterList() As ArrayList
        Return filterlist
    End Function

    Private Sub cboFiltersList_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboFiltersList.SelectedValueChanged
        Dim j As New JSONParser
        filters = j.read(saveDirectory + cboFiltersList.SelectedItem.ToString() + ".json")
        My.Settings.selectedFilterList = cboFiltersList.SelectedItem
        My.Settings.Save()
    End Sub

End Class