<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormatPreservingEncryption
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.txtTInput = New System.Windows.Forms.TextBox()
        Me.lblEncrypted = New System.Windows.Forms.Label()
        Me.lblDecrupypted = New System.Windows.Forms.Label()
        Me.btnEncrypt = New System.Windows.Forms.Button()
        Me.txtCharacter = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'txtTInput
        '
        Me.txtTInput.Location = New System.Drawing.Point(12, 12)
        Me.txtTInput.Name = "txtTInput"
        Me.txtTInput.Size = New System.Drawing.Size(171, 20)
        Me.txtTInput.TabIndex = 0
        Me.txtTInput.Text = "voorbeeld@email.com"
        '
        'lblEncrypted
        '
        Me.lblEncrypted.AutoSize = True
        Me.lblEncrypted.Location = New System.Drawing.Point(12, 70)
        Me.lblEncrypted.Name = "lblEncrypted"
        Me.lblEncrypted.Size = New System.Drawing.Size(0, 13)
        Me.lblEncrypted.TabIndex = 1
        '
        'lblDecrupypted
        '
        Me.lblDecrupypted.AutoSize = True
        Me.lblDecrupypted.Location = New System.Drawing.Point(12, 92)
        Me.lblDecrupypted.Name = "lblDecrupypted"
        Me.lblDecrupypted.Size = New System.Drawing.Size(0, 13)
        Me.lblDecrupypted.TabIndex = 2
        '
        'btnEncrypt
        '
        Me.btnEncrypt.Location = New System.Drawing.Point(229, 10)
        Me.btnEncrypt.Name = "btnEncrypt"
        Me.btnEncrypt.Size = New System.Drawing.Size(75, 23)
        Me.btnEncrypt.TabIndex = 3
        Me.btnEncrypt.Text = "Encrypt"
        Me.btnEncrypt.UseVisualStyleBackColor = True
        '
        'txtCharacter
        '
        Me.txtCharacter.Location = New System.Drawing.Point(12, 38)
        Me.txtCharacter.Name = "txtCharacter"
        Me.txtCharacter.Size = New System.Drawing.Size(171, 20)
        Me.txtCharacter.TabIndex = 4
        Me.txtCharacter.Text = "A"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(189, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Tekst"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(189, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(97, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Te crypteren teken"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(189, 70)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Gecrypteerd"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(189, 92)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(77, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Gedecrypteerd"
        '
        'FormatPreservingEncryption
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(316, 120)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtCharacter)
        Me.Controls.Add(Me.btnEncrypt)
        Me.Controls.Add(Me.lblDecrupypted)
        Me.Controls.Add(Me.lblEncrypted)
        Me.Controls.Add(Me.txtTInput)
        Me.Name = "FormatPreservingEncryption"
        Me.Text = "FormatPreservingEncryption"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtTInput As TextBox
    Friend WithEvents lblEncrypted As Label
    Friend WithEvents lblDecrupypted As Label
    Friend WithEvents btnEncrypt As Button
    Friend WithEvents txtCharacter As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
End Class
