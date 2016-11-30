Imports System.Text
Imports DotFPE


Public Class FormatPreservingEncryption
    Const key As Integer = 365
    Private Sub btnEncrypt_Click(sender As Object, e As EventArgs) Handles btnEncrypt.Click
        'lblEncrypted.Text = FE1.Encrypt(key, key, Encoding.UTF8.GetBytes(txtTInput.Text), Encoding.UTF8.GetBytes(txtCharacter.Text)).ToString
    End Sub
End Class