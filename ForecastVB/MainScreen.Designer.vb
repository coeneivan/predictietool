<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainScreen
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboSubAfd = New System.Windows.Forms.ComboBox()
        Me.cboLesdag = New System.Windows.Forms.ComboBox()
        Me.dtpStartcursus = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtResultMerk = New System.Windows.Forms.TextBox()
        Me.txtResultSubAfd = New System.Windows.Forms.TextBox()
        Me.txtRestultLesDag = New System.Windows.Forms.TextBox()
        Me.txtResultDatum = New System.Windows.Forms.TextBox()
        Me.cboMerk = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtRestultJaar = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
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
        'cboSubAfd
        '
        Me.cboSubAfd.FormattingEnabled = True
        Me.cboSubAfd.Location = New System.Drawing.Point(316, 378)
        Me.cboSubAfd.Name = "cboSubAfd"
        Me.cboSubAfd.Size = New System.Drawing.Size(311, 33)
        Me.cboSubAfd.TabIndex = 1
        '
        'cboLesdag
        '
        Me.cboLesdag.FormattingEnabled = True
        Me.cboLesdag.Location = New System.Drawing.Point(316, 490)
        Me.cboLesdag.Name = "cboLesdag"
        Me.cboLesdag.Size = New System.Drawing.Size(311, 33)
        Me.cboLesdag.TabIndex = 2
        '
        'dtpStartcursus
        '
        Me.dtpStartcursus.Location = New System.Drawing.Point(316, 605)
        Me.dtpStartcursus.Name = "dtpStartcursus"
        Me.dtpStartcursus.Size = New System.Drawing.Size(311, 31)
        Me.dtpStartcursus.TabIndex = 3
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
        Me.txtResultMerk.Location = New System.Drawing.Point(66, 784)
        Me.txtResultMerk.Name = "txtResultMerk"
        Me.txtResultMerk.ReadOnly = True
        Me.txtResultMerk.Size = New System.Drawing.Size(561, 31)
        Me.txtResultMerk.TabIndex = 11
        Me.txtResultMerk.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtResultSubAfd
        '
        Me.txtResultSubAfd.Location = New System.Drawing.Point(66, 821)
        Me.txtResultSubAfd.Name = "txtResultSubAfd"
        Me.txtResultSubAfd.ReadOnly = True
        Me.txtResultSubAfd.Size = New System.Drawing.Size(561, 31)
        Me.txtResultSubAfd.TabIndex = 11
        Me.txtResultSubAfd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtRestultLesDag
        '
        Me.txtRestultLesDag.Location = New System.Drawing.Point(66, 858)
        Me.txtRestultLesDag.Name = "txtRestultLesDag"
        Me.txtRestultLesDag.ReadOnly = True
        Me.txtRestultLesDag.Size = New System.Drawing.Size(561, 31)
        Me.txtRestultLesDag.TabIndex = 11
        Me.txtRestultLesDag.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtResultDatum
        '
        Me.txtResultDatum.Location = New System.Drawing.Point(66, 895)
        Me.txtResultDatum.Name = "txtResultDatum"
        Me.txtResultDatum.ReadOnly = True
        Me.txtResultDatum.Size = New System.Drawing.Size(561, 31)
        Me.txtResultDatum.TabIndex = 11
        Me.txtResultDatum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cboMerk
        '
        Me.cboMerk.FormattingEnabled = True
        Me.cboMerk.Location = New System.Drawing.Point(316, 266)
        Me.cboMerk.Name = "cboMerk"
        Me.cboMerk.Size = New System.Drawing.Size(311, 33)
        Me.cboMerk.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(205, 269)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 25)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Merk:"
        '
        'txtRestultJaar
        '
        Me.txtRestultJaar.Location = New System.Drawing.Point(66, 747)
        Me.txtRestultJaar.Name = "txtRestultJaar"
        Me.txtRestultJaar.ReadOnly = True
        Me.txtRestultJaar.Size = New System.Drawing.Size(561, 31)
        Me.txtRestultJaar.TabIndex = 11
        Me.txtRestultJaar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'MainScreen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(712, 991)
        Me.Controls.Add(Me.cboMerk)
        Me.Controls.Add(Me.txtResultDatum)
        Me.Controls.Add(Me.txtRestultLesDag)
        Me.Controls.Add(Me.txtResultSubAfd)
        Me.Controls.Add(Me.txtRestultJaar)
        Me.Controls.Add(Me.txtResultMerk)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.dtpStartcursus)
        Me.Controls.Add(Me.cboLesdag)
        Me.Controls.Add(Me.cboSubAfd)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Name = "MainScreen"
        Me.Text = "Cursus realiseerbaarheid prospectie tool"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents cboSubAfd As ComboBox
    Friend WithEvents cboLesdag As ComboBox
    Friend WithEvents dtpStartcursus As DateTimePicker
    Friend WithEvents Label6 As Label
    Friend WithEvents txtResultMerk As TextBox
    Friend WithEvents txtResultSubAfd As TextBox
    Friend WithEvents txtRestultLesDag As TextBox
    Friend WithEvents txtResultDatum As TextBox
    Friend WithEvents cboMerk As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtRestultJaar As TextBox
End Class
