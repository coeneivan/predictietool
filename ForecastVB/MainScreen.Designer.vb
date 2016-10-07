<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainScreen
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.RadioButton3 = New System.Windows.Forms.RadioButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtJaar = New System.Windows.Forms.TextBox()
        Me.cboSubAfd = New System.Windows.Forms.ComboBox()
        Me.cboLesdag = New System.Windows.Forms.ComboBox()
        Me.dtpStartcursus = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtResultMerk = New System.Windows.Forms.TextBox()
        Me.txtRestultJaar = New System.Windows.Forms.TextBox()
        Me.txtResultSubAfd = New System.Windows.Forms.TextBox()
        Me.txtRestultLesDag = New System.Windows.Forms.TextBox()
        Me.txtResultDatum = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(199, 157)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 25)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Merk:"
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Location = New System.Drawing.Point(316, 118)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(149, 29)
        Me.RadioButton1.TabIndex = 1
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Tag = "merk"
        Me.RadioButton1.Text = "Syntrawest"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(316, 153)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(89, 29)
        Me.RadioButton2.TabIndex = 1
        Me.RadioButton2.TabStop = True
        Me.RadioButton2.Tag = "merk"
        Me.RadioButton2.Text = "SBM"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton3
        '
        Me.RadioButton3.AutoSize = True
        Me.RadioButton3.Location = New System.Drawing.Point(316, 188)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(108, 29)
        Me.RadioButton3.TabIndex = 1
        Me.RadioButton3.TabStop = True
        Me.RadioButton3.Tag = "merk"
        Me.RadioButton3.Text = "Escala"
        Me.RadioButton3.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(205, 269)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 25)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Jaar:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(115, 381)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(150, 25)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Sub afdeeling;"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(170, 493)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(95, 25)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Les dag:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(61, 605)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(204, 25)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Start van de cursus:"
        '
        'txtJaar
        '
        Me.txtJaar.Location = New System.Drawing.Point(316, 266)
        Me.txtJaar.Name = "txtJaar"
        Me.txtJaar.Size = New System.Drawing.Size(311, 31)
        Me.txtJaar.TabIndex = 6
        '
        'cboSubAfd
        '
        Me.cboSubAfd.FormattingEnabled = True
        Me.cboSubAfd.Location = New System.Drawing.Point(316, 378)
        Me.cboSubAfd.Name = "cboSubAfd"
        Me.cboSubAfd.Size = New System.Drawing.Size(311, 33)
        Me.cboSubAfd.TabIndex = 7
        '
        'cboLesdag
        '
        Me.cboLesdag.FormattingEnabled = True
        Me.cboLesdag.Location = New System.Drawing.Point(316, 490)
        Me.cboLesdag.Name = "cboLesdag"
        Me.cboLesdag.Size = New System.Drawing.Size(311, 33)
        Me.cboLesdag.TabIndex = 8
        '
        'dtpStartcursus
        '
        Me.dtpStartcursus.Location = New System.Drawing.Point(316, 605)
        Me.dtpStartcursus.Name = "dtpStartcursus"
        Me.dtpStartcursus.Size = New System.Drawing.Size(311, 31)
        Me.dtpStartcursus.TabIndex = 9
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(284, 709)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(103, 25)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Resultaat"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtResultMerk
        '
        Me.txtResultMerk.Location = New System.Drawing.Point(66, 755)
        Me.txtResultMerk.Name = "txtResultMerk"
        Me.txtResultMerk.Size = New System.Drawing.Size(561, 31)
        Me.txtResultMerk.TabIndex = 11
        '
        'txtRestultJaar
        '
        Me.txtRestultJaar.Location = New System.Drawing.Point(66, 792)
        Me.txtRestultJaar.Name = "txtRestultJaar"
        Me.txtRestultJaar.Size = New System.Drawing.Size(561, 31)
        Me.txtRestultJaar.TabIndex = 11
        '
        'txtResultSubAfd
        '
        Me.txtResultSubAfd.Location = New System.Drawing.Point(66, 829)
        Me.txtResultSubAfd.Name = "txtResultSubAfd"
        Me.txtResultSubAfd.Size = New System.Drawing.Size(561, 31)
        Me.txtResultSubAfd.TabIndex = 11
        '
        'txtRestultLesDag
        '
        Me.txtRestultLesDag.Location = New System.Drawing.Point(66, 866)
        Me.txtRestultLesDag.Name = "txtRestultLesDag"
        Me.txtRestultLesDag.Size = New System.Drawing.Size(561, 31)
        Me.txtRestultLesDag.TabIndex = 11
        '
        'txtResultDatum
        '
        Me.txtResultDatum.Location = New System.Drawing.Point(66, 903)
        Me.txtResultDatum.Name = "txtResultDatum"
        Me.txtResultDatum.Size = New System.Drawing.Size(561, 31)
        Me.txtResultDatum.TabIndex = 11
        '
        'MainScreen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(712, 991)
        Me.Controls.Add(Me.txtResultDatum)
        Me.Controls.Add(Me.txtRestultLesDag)
        Me.Controls.Add(Me.txtResultSubAfd)
        Me.Controls.Add(Me.txtRestultJaar)
        Me.Controls.Add(Me.txtResultMerk)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.dtpStartcursus)
        Me.Controls.Add(Me.cboLesdag)
        Me.Controls.Add(Me.cboSubAfd)
        Me.Controls.Add(Me.txtJaar)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.RadioButton3)
        Me.Controls.Add(Me.RadioButton2)
        Me.Controls.Add(Me.RadioButton1)
        Me.Controls.Add(Me.Label1)
        Me.Name = "MainScreen"
        Me.Text = "Cursus realiseerbaarheid prospectie tool"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents RadioButton1 As RadioButton
    Friend WithEvents RadioButton2 As RadioButton
    Friend WithEvents RadioButton3 As RadioButton
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents txtJaar As TextBox
    Friend WithEvents cboSubAfd As ComboBox
    Friend WithEvents cboLesdag As ComboBox
    Friend WithEvents dtpStartcursus As DateTimePicker
    Friend WithEvents Label6 As Label
    Friend WithEvents txtResultMerk As TextBox
    Friend WithEvents txtRestultJaar As TextBox
    Friend WithEvents txtResultSubAfd As TextBox
    Friend WithEvents txtRestultLesDag As TextBox
    Friend WithEvents txtResultDatum As TextBox
End Class
