Public Class AddFile
    Private settings As Settings
    Dim r As DialogResult
    Public Sub New(file As String, s As Settings)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        txtFileName.Text = file
        settings = s
    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click

        If (txtFileName.Text = "") Then
            Throw New ApplicationException("Gelieve een bestandsnaam in te stellen")
        End If

        If My.Computer.FileSystem.FileExists(settings.getSaveDirectory + txtFileName.Text + ".json") Then
            Throw New ApplicationException("Filternaam bestaat al, gelieve de filter een andere naam te geven.")
        End If

        settings.setNewFileName(txtFileName.Text)
        Me.Close()

        r = DialogResult.OK
    End Sub

    Private Sub txtFileName_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFileName.KeyPress
        settings.filenameKeyPressCheck(settings, e)
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        r = DialogResult.Cancel
    End Sub
End Class