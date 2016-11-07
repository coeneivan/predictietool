Imports System.IO
Imports Microsoft.VisualBasic.FileIO

Public Class MainScreen
    Private filters As New ArrayList
    Private filterlist As ArrayList
    Private selectedFilterList As String
    Private saveDirectory As String = SpecialDirectories.MyDocuments + "//Predictie Filters//"

    Private Sub MainScreen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        refreshFilterList()
    End Sub
    ''' <summary>
    ''' Refresht de lijst met filters
    ''' Indien de map niet bestaat, maakt die aan en steek er de defaultlist in
    ''' </summary>
    Public Sub refreshFilterList()

        filterlist = New ArrayList
        cboFiltersList.Items.Clear()
        Dim filterFiles As String()
        Try
            filterFiles = Directory.GetFiles(saveDirectory)
            'TODO: Controleren als map leeg is
            If filterFiles.Count > 0 Then
                For Each file As String In filterFiles
                    'Enkel json bestanden
                    If System.IO.Path.GetExtension(file).ToUpper = ".JSON" Then
                        Dim filterNames As String = System.IO.Path.GetFileNameWithoutExtension(file)
                        filterlist.Add(filterNames)
                    End If
                Next
            Else
                'Als map leeg is steek de bijgeleverde defaultList in 
                Throw New DirectoryNotFoundException
            End If

            cboFiltersList.Items.AddRange(filterlist.ToArray)
            'Auto select last selected list
            selectedFilterList = My.Settings.selectedFilterList
            cboFiltersList.SelectedItem = selectedFilterList
        Catch ex As DirectoryNotFoundException
            'Als map niet bestaat is -> map aanmaken en bijgeleverde defaultList kopieren 
            My.Computer.FileSystem.CopyFile("..\..\Filters\defaultList.json", saveDirectory + "\DafaultList.json")
            refreshFilterList()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Foutje")
        End Try
    End Sub

    Private Sub cboMerk_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboMerk.SelectedIndexChanged

    End Sub
    Private Sub cboUitvCent_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboUitvCent.SelectedIndexChanged

    End Sub
    Private Sub cboSubAfd_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSubAfd.SelectedIndexChanged

    End Sub
    Private Sub dtpStartcursus_ValueChanged(sender As Object, e As EventArgs) Handles dtpStartcursus.ValueChanged
        'dtpStartcursus.Value.Month.ToString
        'dtpStartcursus.Value.Year.ToString
    End Sub
    Private Sub cboLesdag_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboLesdag.SelectedIndexChanged

    End Sub

    ''' <summary>
    ''' Toont settings scherm waar je parameters kan toevoegen
    ''' </summary>
    Private Sub btnFilter_Click(sender As Object, e As EventArgs) Handles btnFilter.Click
        Dim settings As New Settings(Me)
        settings.Show()
    End Sub
    ''' <summary>
    ''' Toont test scherm
    ''' </summary>
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim t As New Test(Me)
        t.Show()
    End Sub
    ''' <summary>
    ''' Bereken de kans voor de geselecteerde parameters
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        txtTotaal.Text = "We hebben het algoritme nog nodig"
    End Sub
    ''' <summary>
    ''' Voegt filters toe aan active lijst
    ''' </summary>
    ''' <param name="filters">Arraylist van filteritems die toegevoegd dienen te worden</param>
    Public Sub addFilters(filters As ArrayList)
        filters.AddRange(filters)
    End Sub
    ''' <summary>
    ''' Geeft alle filters terug die actief zijn
    ''' </summary>
    ''' <returns>Arraylist van filter-items met alle active filters </returns>
    Public Function getFilters() As ArrayList
        Return filters
    End Function
    ''' <summary>
    ''' Geeft geselecteerde filter lijst terug
    ''' </summary>
    ''' <returns>Naam van de geselcteerde lijst (dit is ook de naam van het document zonder extensie)</returns>
    Public Function getSelectedList() As String
        Return selectedFilterList
    End Function
    ''' <summary>
    ''' Geeft alle filterlijsten terug
    ''' </summary>
    ''' <returns>Arraylist met namen van lijsten</returns>
    Public Function getFilterList() As ArrayList
        Return filterlist
    End Function

    Private Sub cboFiltersList_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboFiltersList.SelectedValueChanged
        Dim j As New JSONParser
        filters = j.readFilters(saveDirectory + cboFiltersList.SelectedItem.ToString() + ".json")
        'Opslaan in my.settings om later automatisch te selecteren
        My.Settings.selectedFilterList = cboFiltersList.SelectedItem
        My.Settings.Save()
    End Sub
End Class