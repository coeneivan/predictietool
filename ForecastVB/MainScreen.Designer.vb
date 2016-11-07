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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainScreen))
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboSubAfd = New System.Windows.Forms.ComboBox()
        Me.cboLesdag = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtResultMerk = New System.Windows.Forms.TextBox()
        Me.txtResultSubAfd = New System.Windows.Forms.TextBox()
        Me.txtRestultLesDag = New System.Windows.Forms.TextBox()
        Me.txtResultDatum = New System.Windows.Forms.TextBox()
        Me.cboMerk = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnFilter = New System.Windows.Forms.Button()
        Me.cboFiltersList = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txtTotaal = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cboUitvCent = New System.Windows.Forms.ComboBox()
        Me.txtResultCentrum = New System.Windows.Forms.TextBox()
        Me.dtpStartcursus = New System.Windows.Forms.DateTimePicker()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(61, 267)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Sub afdeling;"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(82, 314)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(48, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Les dag:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(28, 361)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(102, 13)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Start van de cursus:"
        '
        'cboSubAfd
        '
        Me.cboSubAfd.FormattingEnabled = True
        Me.cboSubAfd.Location = New System.Drawing.Point(156, 264)
        Me.cboSubAfd.Margin = New System.Windows.Forms.Padding(2)
        Me.cboSubAfd.Name = "cboSubAfd"
        Me.cboSubAfd.Size = New System.Drawing.Size(158, 21)
        Me.cboSubAfd.TabIndex = 2
        '
        'cboLesdag
        '
        Me.cboLesdag.FormattingEnabled = True
        Me.cboLesdag.Location = New System.Drawing.Point(156, 311)
        Me.cboLesdag.Margin = New System.Windows.Forms.Padding(2)
        Me.cboLesdag.Name = "cboLesdag"
        Me.cboLesdag.Size = New System.Drawing.Size(158, 21)
        Me.cboLesdag.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(140, 423)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(52, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Resultaat"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtResultMerk
        '
        Me.txtResultMerk.Location = New System.Drawing.Point(32, 443)
        Me.txtResultMerk.Margin = New System.Windows.Forms.Padding(2)
        Me.txtResultMerk.Name = "txtResultMerk"
        Me.txtResultMerk.ReadOnly = True
        Me.txtResultMerk.Size = New System.Drawing.Size(282, 20)
        Me.txtResultMerk.TabIndex = 11
        Me.txtResultMerk.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtResultSubAfd
        '
        Me.txtResultSubAfd.Location = New System.Drawing.Point(32, 485)
        Me.txtResultSubAfd.Margin = New System.Windows.Forms.Padding(2)
        Me.txtResultSubAfd.Name = "txtResultSubAfd"
        Me.txtResultSubAfd.ReadOnly = True
        Me.txtResultSubAfd.Size = New System.Drawing.Size(282, 20)
        Me.txtResultSubAfd.TabIndex = 11
        Me.txtResultSubAfd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtRestultLesDag
        '
        Me.txtRestultLesDag.Location = New System.Drawing.Point(32, 506)
        Me.txtRestultLesDag.Margin = New System.Windows.Forms.Padding(2)
        Me.txtRestultLesDag.Name = "txtRestultLesDag"
        Me.txtRestultLesDag.ReadOnly = True
        Me.txtRestultLesDag.Size = New System.Drawing.Size(282, 20)
        Me.txtRestultLesDag.TabIndex = 11
        Me.txtRestultLesDag.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtResultDatum
        '
        Me.txtResultDatum.Location = New System.Drawing.Point(32, 527)
        Me.txtResultDatum.Margin = New System.Windows.Forms.Padding(2)
        Me.txtResultDatum.Name = "txtResultDatum"
        Me.txtResultDatum.ReadOnly = True
        Me.txtResultDatum.Size = New System.Drawing.Size(282, 20)
        Me.txtResultDatum.TabIndex = 11
        Me.txtResultDatum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cboMerk
        '
        Me.cboMerk.FormattingEnabled = True
        Me.cboMerk.Location = New System.Drawing.Point(156, 170)
        Me.cboMerk.Margin = New System.Windows.Forms.Padding(2)
        Me.cboMerk.Name = "cboMerk"
        Me.cboMerk.Size = New System.Drawing.Size(158, 21)
        Me.cboMerk.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(96, 173)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Merk:"
        '
        'btnFilter
        '
        Me.btnFilter.Image = CType(resources.GetObject("btnFilter.Image"), System.Drawing.Image)
        Me.btnFilter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnFilter.Location = New System.Drawing.Point(222, 11)
        Me.btnFilter.Margin = New System.Windows.Forms.Padding(2)
        Me.btnFilter.Name = "btnFilter"
        Me.btnFilter.Size = New System.Drawing.Size(123, 40)
        Me.btnFilter.TabIndex = 6
        Me.btnFilter.Text = "Filters toevoegen"
        Me.btnFilter.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnFilter.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnFilter.UseVisualStyleBackColor = False
        '
        'cboFiltersList
        '
        Me.cboFiltersList.FormattingEnabled = True
        Me.cboFiltersList.Location = New System.Drawing.Point(77, 22)
        Me.cboFiltersList.Margin = New System.Windows.Forms.Padding(2)
        Me.cboFiltersList.Name = "cboFiltersList"
        Me.cboFiltersList.Size = New System.Drawing.Size(124, 21)
        Me.cboFiltersList.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 25)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Active filter:"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(32, 618)
        Me.Button1.Margin = New System.Windows.Forms.Padding(2)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(282, 55)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "Test it!"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txtTotaal
        '
        Me.txtTotaal.Location = New System.Drawing.Point(32, 572)
        Me.txtTotaal.Name = "txtTotaal"
        Me.txtTotaal.ReadOnly = True
        Me.txtTotaal.Size = New System.Drawing.Size(282, 20)
        Me.txtTotaal.TabIndex = 15
        Me.txtTotaal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(32, 548)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(282, 23)
        Me.Button2.TabIndex = 5
        Me.Button2.Text = "Calculate"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(27, 220)
        Me.Label7.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(103, 13)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "Uitvoerend centrum:"
        '
        'cboUitvCent
        '
        Me.cboUitvCent.FormattingEnabled = True
        Me.cboUitvCent.Location = New System.Drawing.Point(156, 217)
        Me.cboUitvCent.Margin = New System.Windows.Forms.Padding(2)
        Me.cboUitvCent.Name = "cboUitvCent"
        Me.cboUitvCent.Size = New System.Drawing.Size(158, 21)
        Me.cboUitvCent.TabIndex = 1
        '
        'txtResultCentrum
        '
        Me.txtResultCentrum.Location = New System.Drawing.Point(32, 464)
        Me.txtResultCentrum.Margin = New System.Windows.Forms.Padding(2)
        Me.txtResultCentrum.Name = "txtResultCentrum"
        Me.txtResultCentrum.ReadOnly = True
        Me.txtResultCentrum.Size = New System.Drawing.Size(282, 20)
        Me.txtResultCentrum.TabIndex = 11
        Me.txtResultCentrum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'dtpStartcursus
        '
        Me.dtpStartcursus.Location = New System.Drawing.Point(156, 355)
        Me.dtpStartcursus.Margin = New System.Windows.Forms.Padding(2)
        Me.dtpStartcursus.Name = "dtpStartcursus"
        Me.dtpStartcursus.Size = New System.Drawing.Size(158, 20)
        Me.dtpStartcursus.TabIndex = 4
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(32, 684)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(282, 41)
        Me.Button3.TabIndex = 16
        Me.Button3.Text = "Per ontwikkelaar"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'MainScreen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(356, 737)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.txtTotaal)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.cboFiltersList)
        Me.Controls.Add(Me.btnFilter)
        Me.Controls.Add(Me.cboUitvCent)
        Me.Controls.Add(Me.cboMerk)
        Me.Controls.Add(Me.txtResultDatum)
        Me.Controls.Add(Me.txtRestultLesDag)
        Me.Controls.Add(Me.txtResultSubAfd)
        Me.Controls.Add(Me.txtResultCentrum)
        Me.Controls.Add(Me.txtResultMerk)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.dtpStartcursus)
        Me.Controls.Add(Me.cboLesdag)
        Me.Controls.Add(Me.cboSubAfd)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
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
    Friend WithEvents Label6 As Label
    Friend WithEvents txtResultMerk As TextBox
    Friend WithEvents txtResultSubAfd As TextBox
    Friend WithEvents txtRestultLesDag As TextBox
    Friend WithEvents txtResultDatum As TextBox
    Friend WithEvents cboMerk As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents btnFilter As Button
    Friend WithEvents cboFiltersList As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents txtTotaal As TextBox
    Friend WithEvents Button2 As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents cboUitvCent As ComboBox
    Friend WithEvents txtResultCentrum As TextBox
    Friend WithEvents dtpStartcursus As DateTimePicker
    Friend WithEvents Button3 As Button
End Class
