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
        Me.dtpStartcursus = New System.Windows.Forms.DateTimePicker()
        Me.tslblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.btnOnt = New System.Windows.Forms.Button()
        Me.LblPercBereik = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.btnFilter = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.lblOplNr = New System.Windows.Forms.Label()
        Me.cbbValtTussen = New System.Windows.Forms.ComboBox()
        Me.mtbOplNummer = New System.Windows.Forms.MaskedTextBox()
        Me.pcbPijl = New System.Windows.Forms.PictureBox()
        Me.StatusStrip1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.pcbPijl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LblSubAfd
        '
        Me.LblSubAfd.Location = New System.Drawing.Point(8, 163)
        Me.LblSubAfd.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblSubAfd.Name = "LblSubAfd"
        Me.LblSubAfd.Size = New System.Drawing.Size(142, 39)
        Me.LblSubAfd.TabIndex = 3
        Me.LblSubAfd.Text = "Sub afdeling:"
        Me.LblSubAfd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblStartDatum
        '
        Me.LblStartDatum.Location = New System.Drawing.Point(8, 208)
        Me.LblStartDatum.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblStartDatum.Name = "LblStartDatum"
        Me.LblStartDatum.Size = New System.Drawing.Size(142, 20)
        Me.LblStartDatum.TabIndex = 5
        Me.LblStartDatum.Text = "Start van de cursus:"
        Me.LblStartDatum.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboSubAfd
        '
        Me.cboSubAfd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSubAfd.FormattingEnabled = True
        Me.cboSubAfd.Location = New System.Drawing.Point(160, 174)
        Me.cboSubAfd.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.cboSubAfd.Name = "cboSubAfd"
        Me.cboSubAfd.Size = New System.Drawing.Size(158, 21)
        Me.cboSubAfd.TabIndex = 2
        '
        'cboMerk
        '
        Me.cboMerk.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMerk.FormattingEnabled = True
        Me.cboMerk.Location = New System.Drawing.Point(160, 104)
        Me.cboMerk.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.cboMerk.Name = "cboMerk"
        Me.cboMerk.Size = New System.Drawing.Size(158, 21)
        Me.cboMerk.TabIndex = 0
        '
        'LblMerk
        '
        Me.LblMerk.Location = New System.Drawing.Point(8, 103)
        Me.LblMerk.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblMerk.Name = "LblMerk"
        Me.LblMerk.Size = New System.Drawing.Size(142, 20)
        Me.LblMerk.TabIndex = 2
        Me.LblMerk.Text = "Merk:"
        Me.LblMerk.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboFiltersList
        '
        Me.cboFiltersList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFiltersList.FormattingEnabled = True
        Me.cboFiltersList.Location = New System.Drawing.Point(77, 22)
        Me.cboFiltersList.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.cboFiltersList.Name = "cboFiltersList"
        Me.cboFiltersList.Size = New System.Drawing.Size(124, 21)
        Me.cboFiltersList.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(11, 15)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 32)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Active filter:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnTest
        '
        Me.btnTest.Location = New System.Drawing.Point(182, 567)
        Me.btnTest.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.btnTest.Name = "btnTest"
        Me.btnTest.Size = New System.Drawing.Size(135, 45)
        Me.btnTest.TabIndex = 5
        Me.btnTest.Text = "Test it!"
        Me.btnTest.UseVisualStyleBackColor = True
        '
        'txtTotaal
        '
        Me.txtTotaal.Location = New System.Drawing.Point(35, 364)
        Me.txtTotaal.Name = "txtTotaal"
        Me.txtTotaal.ReadOnly = True
        Me.txtTotaal.Size = New System.Drawing.Size(283, 20)
        Me.txtTotaal.TabIndex = 15
        Me.txtTotaal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnBerekenen
        '
        Me.btnBerekenen.Location = New System.Drawing.Point(35, 285)
        Me.btnBerekenen.Name = "btnBerekenen"
        Me.btnBerekenen.Size = New System.Drawing.Size(284, 64)
        Me.btnBerekenen.TabIndex = 5
        Me.btnBerekenen.Text = "Bereken"
        Me.btnBerekenen.UseVisualStyleBackColor = True
        '
        'LblUivCentr
        '
        Me.LblUivCentr.Location = New System.Drawing.Point(8, 128)
        Me.LblUivCentr.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblUivCentr.Name = "LblUivCentr"
        Me.LblUivCentr.Size = New System.Drawing.Size(142, 39)
        Me.LblUivCentr.TabIndex = 2
        Me.LblUivCentr.Text = "Uitvoerend centrum:"
        Me.LblUivCentr.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboUitvCent
        '
        Me.cboUitvCent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboUitvCent.FormattingEnabled = True
        Me.cboUitvCent.Location = New System.Drawing.Point(160, 139)
        Me.cboUitvCent.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.cboUitvCent.Name = "cboUitvCent"
        Me.cboUitvCent.Size = New System.Drawing.Size(158, 21)
        Me.cboUitvCent.TabIndex = 1
        '
        'dtpStartcursus
        '
        Me.dtpStartcursus.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpStartcursus.Location = New System.Drawing.Point(160, 209)
        Me.dtpStartcursus.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.dtpStartcursus.Name = "dtpStartcursus"
        Me.dtpStartcursus.Size = New System.Drawing.Size(158, 20)
        Me.dtpStartcursus.TabIndex = 4
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
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 630)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.StatusStrip1.Size = New System.Drawing.Size(357, 5)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.Stretch = False
        Me.StatusStrip1.TabIndex = 16
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'btnOnt
        '
        Me.btnOnt.Location = New System.Drawing.Point(35, 567)
        Me.btnOnt.Name = "btnOnt"
        Me.btnOnt.Size = New System.Drawing.Size(131, 45)
        Me.btnOnt.TabIndex = 5
        Me.btnOnt.Text = "Per Ontwikkelaar"
        Me.btnOnt.UseVisualStyleBackColor = True
        '
        'LblPercBereik
        '
        Me.LblPercBereik.Location = New System.Drawing.Point(8, 233)
        Me.LblPercBereik.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblPercBereik.Name = "LblPercBereik"
        Me.LblPercBereik.Size = New System.Drawing.Size(142, 39)
        Me.LblPercBereik.TabIndex = 17
        Me.LblPercBereik.Text = "% valt tussen bereik:"
        Me.LblPercBereik.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(256, 68)
        Me.Button1.Margin = New System.Windows.Forms.Padding(2)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(61, 25)
        Me.Button1.TabIndex = 18
        Me.Button1.Text = "GET"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Location = New System.Drawing.Point(37, 6)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(282, 150)
        Me.Panel1.TabIndex = 20
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.GhostWhite
        Me.Panel2.Controls.Add(Me.Panel1)
        Me.Panel2.Location = New System.Drawing.Point(491, 387)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(355, 158)
        Me.Panel2.TabIndex = 0
        '
        'Timer1
        '
        Me.Timer1.Interval = 10
        '
        'btnFilter
        '
        Me.btnFilter.Image = CType(resources.GetObject("btnFilter.Image"), System.Drawing.Image)
        Me.btnFilter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnFilter.Location = New System.Drawing.Point(222, 12)
        Me.btnFilter.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.btnFilter.Name = "btnFilter"
        Me.btnFilter.Size = New System.Drawing.Size(123, 40)
        Me.btnFilter.TabIndex = 6
        Me.btnFilter.Text = "Filters toevoegen"
        Me.btnFilter.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnFilter.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnFilter.UseVisualStyleBackColor = False
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(462, 318)
        Me.TextBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(152, 20)
        Me.TextBox1.TabIndex = 19
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(462, 348)
        Me.Button2.Margin = New System.Windows.Forms.Padding(2)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(151, 23)
        Me.Button2.TabIndex = 20
        Me.Button2.Text = "Button2"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(462, 201)
        Me.TextBox2.Margin = New System.Windows.Forms.Padding(2)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(152, 20)
        Me.TextBox2.TabIndex = 19
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(462, 222)
        Me.TextBox3.Margin = New System.Windows.Forms.Padding(2)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(152, 20)
        Me.TextBox3.TabIndex = 19
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(462, 257)
        Me.TextBox4.Margin = New System.Windows.Forms.Padding(2)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(152, 20)
        Me.TextBox4.TabIndex = 19
        '
        'TextBox5
        '
        Me.TextBox5.Location = New System.Drawing.Point(462, 278)
        Me.TextBox5.Margin = New System.Windows.Forms.Padding(2)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(152, 20)
        Me.TextBox5.TabIndex = 19
        '
        'lblOplNr
        '
        Me.lblOplNr.Location = New System.Drawing.Point(8, 68)
        Me.lblOplNr.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblOplNr.Name = "lblOplNr"
        Me.lblOplNr.Size = New System.Drawing.Size(142, 20)
        Me.lblOplNr.TabIndex = 2
        Me.lblOplNr.Text = "Opleidngsnummer:"
        Me.lblOplNr.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cbbValtTussen
        '
        Me.cbbValtTussen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbbValtTussen.FormattingEnabled = True
        Me.cbbValtTussen.Items.AddRange(New Object() {"99.5%", "97.5%", "95%", "90%"})
        Me.cbbValtTussen.Location = New System.Drawing.Point(160, 244)
        Me.cbbValtTussen.Margin = New System.Windows.Forms.Padding(2)
        Me.cbbValtTussen.Name = "cbbValtTussen"
        Me.cbbValtTussen.Size = New System.Drawing.Size(159, 21)
        Me.cbbValtTussen.TabIndex = 18
        '
        'mtbOplNummer
        '
        Me.mtbOplNummer.Location = New System.Drawing.Point(160, 71)
        Me.mtbOplNummer.Mask = "000000"
        Me.mtbOplNummer.Name = "mtbOplNummer"
        Me.mtbOplNummer.Size = New System.Drawing.Size(74, 20)
        Me.mtbOplNummer.TabIndex = 21
        '
        'pcbPijl
        '
        Me.pcbPijl.Location = New System.Drawing.Point(0, 387)
        Me.pcbPijl.Name = "pcbPijl"
        Me.pcbPijl.Size = New System.Drawing.Size(357, 174)
        Me.pcbPijl.TabIndex = 22
        Me.pcbPijl.TabStop = False
        '
        'MainScreen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(357, 635)
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
        Me.Controls.Add(Me.dtpStartcursus)
        Me.Controls.Add(Me.cboSubAfd)
        Me.Controls.Add(Me.LblStartDatum)
        Me.Controls.Add(Me.LblSubAfd)
        Me.Controls.Add(Me.LblUivCentr)
        Me.Controls.Add(Me.lblOplNr)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LblMerk)
        Me.Controls.Add(Me.Panel2)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(1)
        Me.MaximizeBox = False
        Me.Name = "MainScreen"
        Me.Text = "Cursus realiseerbaarheid prospectie tool"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
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
    Friend WithEvents dtpStartcursus As DateTimePicker
    Friend WithEvents tslblStatus As ToolStripStatusLabel
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents btnOnt As Button
    Friend WithEvents LblPercBereik As Label
    Friend WithEvents lblOplNr As Label
    Friend WithEvents cbbValtTussen As ComboBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Panel2 As Panel
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Button2 As Button
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents TextBox5 As TextBox
    Friend WithEvents mtbOplNummer As MaskedTextBox
    Friend WithEvents pcbPijl As PictureBox
End Class
