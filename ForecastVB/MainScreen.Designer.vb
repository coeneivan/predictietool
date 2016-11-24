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
        Me.txtOpleidingsnummer = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.pnlPijl = New System.Windows.Forms.Panel()
        Me.pnlBackground = New System.Windows.Forms.Panel()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.btnFilter = New System.Windows.Forms.Button()
        Me.lblOplNr = New System.Windows.Forms.Label()
        Me.cbbValtTussen = New System.Windows.Forms.ComboBox()
        Me.StatusStrip1.SuspendLayout()
        Me.pnlBackground.SuspendLayout()
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
        Me.btnTest.Location = New System.Drawing.Point(273, 872)
        Me.btnTest.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnTest.Name = "btnTest"
        Me.btnTest.Size = New System.Drawing.Size(202, 69)
        Me.btnTest.TabIndex = 5
        Me.btnTest.Text = "Test it!"
        Me.btnTest.UseVisualStyleBackColor = True
        '
        'txtTotaal
        '
        Me.txtTotaal.Location = New System.Drawing.Point(52, 552)
        Me.txtTotaal.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtTotaal.Name = "txtTotaal"
        Me.txtTotaal.ReadOnly = True
        Me.txtTotaal.Size = New System.Drawing.Size(422, 26)
        Me.txtTotaal.TabIndex = 15
        Me.txtTotaal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnBerekenen
        '
        Me.btnBerekenen.Location = New System.Drawing.Point(52, 438)
        Me.btnBerekenen.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnBerekenen.Name = "btnBerekenen"
        Me.btnBerekenen.Size = New System.Drawing.Size(426, 98)
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
        'dtpStartcursus
        '
        Me.dtpStartcursus.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpStartcursus.Location = New System.Drawing.Point(240, 322)
        Me.dtpStartcursus.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dtpStartcursus.Name = "dtpStartcursus"
        Me.dtpStartcursus.Size = New System.Drawing.Size(235, 26)
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
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 972)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(2, 0, 21, 0)
        Me.StatusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.StatusStrip1.Size = New System.Drawing.Size(537, 5)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.Stretch = False
        Me.StatusStrip1.TabIndex = 16
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'btnOnt
        '
        Me.btnOnt.Location = New System.Drawing.Point(52, 872)
        Me.btnOnt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnOnt.Name = "btnOnt"
        Me.btnOnt.Size = New System.Drawing.Size(196, 69)
        Me.btnOnt.TabIndex = 5
        Me.btnOnt.Text = "Per Ontwikkelaar"
        Me.btnOnt.UseVisualStyleBackColor = True
        '
        'LblPercBereik
        '
        Me.LblPercBereik.Location = New System.Drawing.Point(12, 359)
        Me.LblPercBereik.Name = "LblPercBereik"
        Me.LblPercBereik.Size = New System.Drawing.Size(213, 60)
        Me.LblPercBereik.TabIndex = 17
        Me.LblPercBereik.Text = "% valt tussen bereik:"
        Me.LblPercBereik.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtOpleidingsnummer
        '
        Me.txtOpleidingsnummer.Location = New System.Drawing.Point(240, 109)
        Me.txtOpleidingsnummer.Name = "txtOpleidingsnummer"
        Me.txtOpleidingsnummer.Size = New System.Drawing.Size(169, 26)
        Me.txtOpleidingsnummer.TabIndex = 17
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(416, 105)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(60, 38)
        Me.Button1.TabIndex = 18
        Me.Button1.Text = "GET"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'pnlPijl
        '
        Me.pnlPijl.BackColor = System.Drawing.Color.Transparent
        Me.pnlPijl.Location = New System.Drawing.Point(51, 12)
        Me.pnlPijl.Name = "pnlPijl"
        Me.pnlPijl.Size = New System.Drawing.Size(423, 231)
        Me.pnlPijl.TabIndex = 20
        '
        'pnlBackground
        '
        Me.pnlBackground.BackColor = System.Drawing.Color.Transparent
        Me.pnlBackground.Controls.Add(Me.pnlPijl)
        Me.pnlBackground.Location = New System.Drawing.Point(0, 594)
        Me.pnlBackground.Name = "pnlBackground"
        Me.pnlBackground.Size = New System.Drawing.Size(537, 243)
        Me.pnlBackground.TabIndex = 0
        '
        'Timer1
        '
        Me.Timer1.Interval = 25
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
        'lblOplNr
        '
        Me.lblOplNr.Location = New System.Drawing.Point(12, 104)
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
        Me.cbbValtTussen.Items.AddRange(New Object() {"99.5%", "97.5%", "95%", "90%"})
        Me.cbbValtTussen.Location = New System.Drawing.Point(240, 375)
        Me.cbbValtTussen.Name = "cbbValtTussen"
        Me.cbbValtTussen.Size = New System.Drawing.Size(236, 28)
        Me.cbbValtTussen.TabIndex = 18
        '
        'MainScreen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(537, 977)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txtOpleidingsnummer)
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
        Me.Controls.Add(Me.pnlBackground)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MaximizeBox = False
        Me.Name = "MainScreen"
        Me.Text = "Cursus realiseerbaarheid prospectie tool"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.pnlBackground.ResumeLayout(False)
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
    Friend WithEvents txtOpleidingsnummer As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents pnlPijl As Panel
    Friend WithEvents Timer1 As Timer
    Friend WithEvents pnlBackground As Panel
End Class
