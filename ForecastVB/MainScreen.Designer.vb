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
        Me.btnFilter = New System.Windows.Forms.Button()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(75, 315)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(99, 17)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Sub afdeeling;"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(111, 387)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 17)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Les dag:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(39, 458)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(135, 17)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Start van de cursus:"
        '
        'cboSubAfd
        '
        Me.cboSubAfd.FormattingEnabled = True
        Me.cboSubAfd.Location = New System.Drawing.Point(209, 313)
        Me.cboSubAfd.Margin = New System.Windows.Forms.Padding(2)
        Me.cboSubAfd.Name = "cboSubAfd"
        Me.cboSubAfd.Size = New System.Drawing.Size(209, 24)
        Me.cboSubAfd.TabIndex = 1
        '
        'cboLesdag
        '
        Me.cboLesdag.FormattingEnabled = True
        Me.cboLesdag.Location = New System.Drawing.Point(209, 385)
        Me.cboLesdag.Margin = New System.Windows.Forms.Padding(2)
        Me.cboLesdag.Name = "cboLesdag"
        Me.cboLesdag.Size = New System.Drawing.Size(209, 24)
        Me.cboLesdag.TabIndex = 2
        '
        'dtpStartcursus
        '
        Me.dtpStartcursus.Location = New System.Drawing.Point(209, 458)
        Me.dtpStartcursus.Margin = New System.Windows.Forms.Padding(2)
        Me.dtpStartcursus.Name = "dtpStartcursus"
        Me.dtpStartcursus.Size = New System.Drawing.Size(209, 22)
        Me.dtpStartcursus.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(187, 521)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(68, 17)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Resultaat"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtResultMerk
        '
        Me.txtResultMerk.Location = New System.Drawing.Point(42, 569)
        Me.txtResultMerk.Margin = New System.Windows.Forms.Padding(2)
        Me.txtResultMerk.Name = "txtResultMerk"
        Me.txtResultMerk.ReadOnly = True
        Me.txtResultMerk.Size = New System.Drawing.Size(375, 22)
        Me.txtResultMerk.TabIndex = 11
        Me.txtResultMerk.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtResultSubAfd
        '
        Me.txtResultSubAfd.Location = New System.Drawing.Point(42, 592)
        Me.txtResultSubAfd.Margin = New System.Windows.Forms.Padding(2)
        Me.txtResultSubAfd.Name = "txtResultSubAfd"
        Me.txtResultSubAfd.ReadOnly = True
        Me.txtResultSubAfd.Size = New System.Drawing.Size(375, 22)
        Me.txtResultSubAfd.TabIndex = 11
        Me.txtResultSubAfd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtRestultLesDag
        '
        Me.txtRestultLesDag.Location = New System.Drawing.Point(42, 616)
        Me.txtRestultLesDag.Margin = New System.Windows.Forms.Padding(2)
        Me.txtRestultLesDag.Name = "txtRestultLesDag"
        Me.txtRestultLesDag.ReadOnly = True
        Me.txtRestultLesDag.Size = New System.Drawing.Size(375, 22)
        Me.txtRestultLesDag.TabIndex = 11
        Me.txtRestultLesDag.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtResultDatum
        '
        Me.txtResultDatum.Location = New System.Drawing.Point(42, 640)
        Me.txtResultDatum.Margin = New System.Windows.Forms.Padding(2)
        Me.txtResultDatum.Name = "txtResultDatum"
        Me.txtResultDatum.ReadOnly = True
        Me.txtResultDatum.Size = New System.Drawing.Size(375, 22)
        Me.txtResultDatum.TabIndex = 11
        Me.txtResultDatum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cboMerk
        '
        Me.cboMerk.FormattingEnabled = True
        Me.cboMerk.Location = New System.Drawing.Point(209, 241)
        Me.cboMerk.Margin = New System.Windows.Forms.Padding(2)
        Me.cboMerk.Name = "cboMerk"
        Me.cboMerk.Size = New System.Drawing.Size(209, 24)
        Me.cboMerk.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(135, 243)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 17)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Merk:"
        '
        'txtRestultJaar
        '
        Me.txtRestultJaar.Location = New System.Drawing.Point(42, 545)
        Me.txtRestultJaar.Margin = New System.Windows.Forms.Padding(2)
        Me.txtRestultJaar.Name = "txtRestultJaar"
        Me.txtRestultJaar.ReadOnly = True
        Me.txtRestultJaar.Size = New System.Drawing.Size(375, 22)
        Me.txtRestultJaar.TabIndex = 11
        Me.txtRestultJaar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnFilter
        '
        Me.btnFilter.Location = New System.Drawing.Point(12, 12)
        Me.btnFilter.Name = "btnFilter"
        Me.btnFilter.Size = New System.Drawing.Size(164, 49)
        Me.btnFilter.TabIndex = 12
        Me.btnFilter.Text = "Filters toevoegen"
        Me.btnFilter.UseVisualStyleBackColor = True
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(299, 25)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(164, 24)
        Me.ComboBox1.TabIndex = 13
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(208, 28)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 17)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Active filter:"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(42, 707)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(375, 68)
        Me.Button1.TabIndex = 14
        Me.Button1.Text = "Test it!"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'MainScreen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(475, 907)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.btnFilter)
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
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Margin = New System.Windows.Forms.Padding(2)
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
    Friend WithEvents btnFilter As Button
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Button1 As Button
End Class
