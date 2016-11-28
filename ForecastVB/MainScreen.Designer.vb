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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainScreen))
        Me.LblSubAfd = New System.Windows.Forms.Label()
        Me.LblStartDatum = New System.Windows.Forms.Label()
        Me.cboSubAfd = New System.Windows.Forms.ComboBox()
        Me.cboMerk = New System.Windows.Forms.ComboBox()
        Me.LblMerk = New System.Windows.Forms.Label()
        Me.cboFiltersList = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnTest = New System.Windows.Forms.Button()
        Me.txtTotaal = New System.Windows.Forms.TextBox()
        Me.btnBerekenen = New System.Windows.Forms.Button()
        Me.LblUivCentr = New System.Windows.Forms.Label()
        Me.cboUitvCent = New System.Windows.Forms.ComboBox()
        Me.tslblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.btnOnt = New System.Windows.Forms.Button()
        Me.LblPercBereik = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.pnlAvg = New System.Windows.Forms.Panel()
        Me.pnlBack = New System.Windows.Forms.Panel()
        Me.tmrAvg = New System.Windows.Forms.Timer(Me.components)
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.lblOplNr = New System.Windows.Forms.Label()
        Me.cbbValtTussen = New System.Windows.Forms.ComboBox()
        Me.mtbOplNummer = New System.Windows.Forms.MaskedTextBox()
        Me.dtpStartcursus = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pcbPijl = New System.Windows.Forms.PictureBox()
        Me.btnFilter = New System.Windows.Forms.Button()
        Me.StatusStrip1.SuspendLayout()
        Me.pnlBack.SuspendLayout()
        CType(Me.pcbPijl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LblSubAfd
        '
        Me.LblSubAfd.Location = New System.Drawing.Point(12, 251)
        Me.LblSubAfd.Name = "LblSubAfd"
        Me.LblSubAfd.Size = New System.Drawing.Size(213, 60)
        Me.LblSubAfd.TabIndex = 3
        Me.LblSubAfd.Text = "Sub afdeling:"
        Me.LblSubAfd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblStartDatum
        '
        Me.LblStartDatum.Location = New System.Drawing.Point(12, 320)
        Me.LblStartDatum.Name = "LblStartDatum"
        Me.LblStartDatum.Size = New System.Drawing.Size(213, 31)
        Me.LblStartDatum.TabIndex = 5
        Me.LblStartDatum.Text = "Start van de cursus:"
        Me.LblStartDatum.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboSubAfd
        '
        Me.cboSubAfd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSubAfd.FormattingEnabled = True
        Me.cboSubAfd.Location = New System.Drawing.Point(240, 268)
        Me.cboSubAfd.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cboSubAfd.Name = "cboSubAfd"
        Me.cboSubAfd.Size = New System.Drawing.Size(235, 28)
        Me.cboSubAfd.TabIndex = 2
        '
        'cboMerk
        '
        Me.cboMerk.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMerk.FormattingEnabled = True
        Me.cboMerk.Location = New System.Drawing.Point(240, 160)
        Me.cboMerk.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cboMerk.Name = "cboMerk"
        Me.cboMerk.Size = New System.Drawing.Size(235, 28)
        Me.cboMerk.TabIndex = 0
        '
        'LblMerk
        '
        Me.LblMerk.Location = New System.Drawing.Point(12, 158)
        Me.LblMerk.Name = "LblMerk"
        Me.LblMerk.Size = New System.Drawing.Size(213, 31)
        Me.LblMerk.TabIndex = 2
        Me.LblMerk.Text = "Merk:"
        Me.LblMerk.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboFiltersList
        '
        Me.cboFiltersList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFiltersList.FormattingEnabled = True
        Me.cboFiltersList.Location = New System.Drawing.Point(116, 34)
        Me.cboFiltersList.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cboFiltersList.Name = "cboFiltersList"
        Me.cboFiltersList.Size = New System.Drawing.Size(184, 28)
        Me.cboFiltersList.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(16, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(94, 49)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Active filter:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnTest
        '
        Me.btnTest.Location = New System.Drawing.Point(272, 857)
        Me.btnTest.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnTest.Name = "btnTest"
        Me.btnTest.Size = New System.Drawing.Size(202, 60)
        Me.btnTest.TabIndex = 5
        Me.btnTest.Text = "Test it!"
        Me.btnTest.UseVisualStyleBackColor = True
        '
        'txtTotaal
        '
        Me.txtTotaal.Location = New System.Drawing.Point(51, 559)
        Me.txtTotaal.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtTotaal.Name = "txtTotaal"
        Me.txtTotaal.ReadOnly = True
        Me.txtTotaal.Size = New System.Drawing.Size(426, 26)
        Me.txtTotaal.TabIndex = 15
        Me.txtTotaal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnBerekenen
        '
        Me.btnBerekenen.Location = New System.Drawing.Point(51, 423)
        Me.btnBerekenen.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnBerekenen.Name = "btnBerekenen"
        Me.btnBerekenen.Size = New System.Drawing.Size(426, 71)
        Me.btnBerekenen.TabIndex = 5
        Me.btnBerekenen.Text = "Bereken"
        Me.btnBerekenen.UseVisualStyleBackColor = True
        '
        'LblUivCentr
        '
        Me.LblUivCentr.Location = New System.Drawing.Point(12, 197)
        Me.LblUivCentr.Name = "LblUivCentr"
        Me.LblUivCentr.Size = New System.Drawing.Size(213, 60)
        Me.LblUivCentr.TabIndex = 2
        Me.LblUivCentr.Text = "Uitvoerend centrum:"
        Me.LblUivCentr.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboUitvCent
        '
        Me.cboUitvCent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboUitvCent.FormattingEnabled = True
        Me.cboUitvCent.Location = New System.Drawing.Point(240, 214)
        Me.cboUitvCent.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cboUitvCent.Name = "cboUitvCent"
        Me.cboUitvCent.Size = New System.Drawing.Size(235, 28)
        Me.cboUitvCent.TabIndex = 1
        '
        'tslblStatus
        '
        Me.tslblStatus.ActiveLinkColor = System.Drawing.Color.DarkGray
        Me.tslblStatus.LinkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.tslblStatus.Name = "tslblStatus"
        Me.tslblStatus.Size = New System.Drawing.Size(0, 0)
        '
        'StatusStrip1
        '
        Me.StatusStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tslblStatus})
        Me.StatusStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 972)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(2, 0, 21, 0)
        Me.StatusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.StatusStrip1.Size = New System.Drawing.Size(532, 5)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.Stretch = False
        Me.StatusStrip1.TabIndex = 16
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'btnOnt
        '
        Me.btnOnt.Location = New System.Drawing.Point(51, 857)
        Me.btnOnt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnOnt.Name = "btnOnt"
        Me.btnOnt.Size = New System.Drawing.Size(196, 60)
        Me.btnOnt.TabIndex = 5
        Me.btnOnt.Text = "Per Ontwikkelaar"
        Me.btnOnt.UseVisualStyleBackColor = True
        '
        'LblPercBereik
        '
        Me.LblPercBereik.Font = New System.Drawing.Font("Roboto Thin", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPercBereik.Location = New System.Drawing.Point(12, 358)
        Me.LblPercBereik.Name = "LblPercBereik"
        Me.LblPercBereik.Size = New System.Drawing.Size(213, 60)
        Me.LblPercBereik.TabIndex = 17
        Me.LblPercBereik.Text = "% valt tussen bereik:"
        Me.LblPercBereik.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(382, 101)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(92, 38)
        Me.Button1.TabIndex = 18
        Me.Button1.Text = "GET"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'pnlAvg
        '
        Me.pnlAvg.BackColor = System.Drawing.Color.Transparent
        Me.pnlAvg.Location = New System.Drawing.Point(57, 31)
        Me.pnlAvg.Name = "pnlAvg"
        Me.pnlAvg.Size = New System.Drawing.Size(423, 231)
        Me.pnlAvg.TabIndex = 20
        '
        'pnlBack
        '
        Me.pnlBack.BackColor = System.Drawing.Color.GhostWhite
        Me.pnlBack.Controls.Add(Me.pnlAvg)
        Me.pnlBack.Location = New System.Drawing.Point(590, 595)
        Me.pnlBack.Name = "pnlBack"
        Me.pnlBack.Size = New System.Drawing.Size(532, 243)
        Me.pnlBack.TabIndex = 0
        '
        'tmrAvg
        '
        Me.tmrAvg.Interval = 10
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(693, 489)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(226, 26)
        Me.TextBox1.TabIndex = 19
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(693, 535)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(226, 35)
        Me.Button2.TabIndex = 20
        Me.Button2.Text = "Button2"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(693, 309)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(226, 26)
        Me.TextBox2.TabIndex = 19
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(693, 342)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(226, 26)
        Me.TextBox3.TabIndex = 19
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(693, 395)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(226, 26)
        Me.TextBox4.TabIndex = 19
        '
        'TextBox5
        '
        Me.TextBox5.Location = New System.Drawing.Point(693, 428)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(226, 26)
        Me.TextBox5.TabIndex = 19
        '
        'lblOplNr
        '
        Me.lblOplNr.Location = New System.Drawing.Point(12, 105)
        Me.lblOplNr.Name = "lblOplNr"
        Me.lblOplNr.Size = New System.Drawing.Size(213, 31)
        Me.lblOplNr.TabIndex = 2
        Me.lblOplNr.Text = "Opleidngsnummer:"
        Me.lblOplNr.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cbbValtTussen
        '
        Me.cbbValtTussen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbbValtTussen.FormattingEnabled = True
        Me.cbbValtTussen.Location = New System.Drawing.Point(240, 375)
        Me.cbbValtTussen.Name = "cbbValtTussen"
        Me.cbbValtTussen.Size = New System.Drawing.Size(236, 28)
        Me.cbbValtTussen.TabIndex = 18
        '
        'mtbOplNummer
        '
        Me.mtbOplNummer.Location = New System.Drawing.Point(240, 109)
        Me.mtbOplNummer.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.mtbOplNummer.Mask = "000000"
        Me.mtbOplNummer.Name = "mtbOplNummer"
        Me.mtbOplNummer.Size = New System.Drawing.Size(109, 26)
        Me.mtbOplNummer.TabIndex = 21
        '
        'dtpStartcursus
        '
        Me.dtpStartcursus.CalendarMonthBackground = System.Drawing.Color.Yellow
        Me.dtpStartcursus.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpStartcursus.Location = New System.Drawing.Point(240, 318)
        Me.dtpStartcursus.Name = "dtpStartcursus"
        Me.dtpStartcursus.Size = New System.Drawing.Size(235, 26)
        Me.dtpStartcursus.TabIndex = 23
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(54, 530)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(423, 24)
        Me.Label2.TabIndex = 24
        Me.Label2.Text = "min - voorspeld - max"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(54, 506)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(423, 24)
        Me.Label3.TabIndex = 24
        Me.Label3.Text = "Realisatiegraad:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pcbPijl
        '
        Me.pcbPijl.Location = New System.Drawing.Point(0, 595)
        Me.pcbPijl.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.pcbPijl.Name = "pcbPijl"
        Me.pcbPijl.Size = New System.Drawing.Size(536, 243)
        Me.pcbPijl.TabIndex = 22
        Me.pcbPijl.TabStop = False
        '
        'btnFilter
        '
        Me.btnFilter.Image = CType(resources.GetObject("btnFilter.Image"), System.Drawing.Image)
        Me.btnFilter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnFilter.Location = New System.Drawing.Point(333, 18)
        Me.btnFilter.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnFilter.Name = "btnFilter"
        Me.btnFilter.Size = New System.Drawing.Size(184, 62)
        Me.btnFilter.TabIndex = 6
        Me.btnFilter.Text = "Filters toevoegen"
        Me.btnFilter.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnFilter.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnFilter.UseVisualStyleBackColor = False
        '
        'MainScreen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(532, 977)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dtpStartcursus)
        Me.Controls.Add(Me.pcbPijl)
        Me.Controls.Add(Me.mtbOplNummer)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.TextBox5)
        Me.Controls.Add(Me.TextBox4)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.cbbValtTussen)
        Me.Controls.Add(Me.LblPercBereik)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.btnOnt)
        Me.Controls.Add(Me.btnBerekenen)
        Me.Controls.Add(Me.txtTotaal)
        Me.Controls.Add(Me.btnTest)
        Me.Controls.Add(Me.cboFiltersList)
        Me.Controls.Add(Me.btnFilter)
        Me.Controls.Add(Me.cboUitvCent)
        Me.Controls.Add(Me.cboMerk)
        Me.Controls.Add(Me.cboSubAfd)
        Me.Controls.Add(Me.LblStartDatum)
        Me.Controls.Add(Me.LblSubAfd)
        Me.Controls.Add(Me.LblUivCentr)
        Me.Controls.Add(Me.lblOplNr)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LblMerk)
        Me.Controls.Add(Me.pnlBack)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MaximizeBox = False
        Me.Name = "MainScreen"
        Me.Text = "Cursus realiseerbaarheid prospectie tool"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.pnlBack.ResumeLayout(False)
        CType(Me.pcbPijl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LblSubAfd As Label
    Friend WithEvents LblStartDatum As Label
    Friend WithEvents cboSubAfd As ComboBox
    Friend WithEvents cboMerk As ComboBox
    Friend WithEvents LblMerk As Label
    Friend WithEvents btnFilter As Button
    Friend WithEvents cboFiltersList As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnTest As Button
    Friend WithEvents txtTotaal As TextBox
    Friend WithEvents btnBerekenen As Button
    Friend WithEvents LblUivCentr As Label
    Friend WithEvents cboUitvCent As ComboBox
    Friend WithEvents tslblStatus As ToolStripStatusLabel
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents btnOnt As Button
    Friend WithEvents LblPercBereik As Label
    Friend WithEvents lblOplNr As Label
    Friend WithEvents cbbValtTussen As ComboBox
    Friend WithEvents Button1 As Button
    Friend WithEvents pnlAvg As Panel
    Friend WithEvents tmrAvg As Timer
    Friend WithEvents pnlBack As Panel
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Button2 As Button
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents TextBox5 As TextBox
    Friend WithEvents mtbOplNummer As MaskedTextBox
    Friend WithEvents pcbPijl As PictureBox
    Friend WithEvents dtpStartcursus As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
End Class
