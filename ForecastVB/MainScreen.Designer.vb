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
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboSubAfd = New System.Windows.Forms.ComboBox()
        Me.cboMerk = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboFiltersList = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnTest = New System.Windows.Forms.Button()
        Me.txtTotaal = New System.Windows.Forms.TextBox()
        Me.btnBerekenen = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cboUitvCent = New System.Windows.Forms.ComboBox()
        Me.dtpStartcursus = New System.Windows.Forms.DateTimePicker()
        Me.tslblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.btnOnt = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtOpleidingsnummer = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.btnFilter = New System.Windows.Forms.Button()
        Me.StatusStrip1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(20, 305)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(213, 35)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Sub afdeling;"
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(20, 369)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(213, 53)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Start van de cursus:"
        '
        'cboSubAfd
        '
        Me.cboSubAfd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSubAfd.FormattingEnabled = True
        Me.cboSubAfd.Location = New System.Drawing.Point(240, 311)
        Me.cboSubAfd.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cboSubAfd.Name = "cboSubAfd"
        Me.cboSubAfd.Size = New System.Drawing.Size(235, 28)
        Me.cboSubAfd.TabIndex = 2
        '
        'cboMerk
        '
        Me.cboMerk.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMerk.FormattingEnabled = True
        Me.cboMerk.Location = New System.Drawing.Point(240, 166)
        Me.cboMerk.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cboMerk.Name = "cboMerk"
        Me.cboMerk.Size = New System.Drawing.Size(235, 28)
        Me.cboMerk.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(20, 161)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(213, 35)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Merk:"
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
        Me.Label1.Location = New System.Drawing.Point(20, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(90, 61)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Active filter:"
        '
        'btnTest
        '
        Me.btnTest.Location = New System.Drawing.Point(273, 872)
        Me.btnTest.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnTest.Name = "btnTest"
        Me.btnTest.Size = New System.Drawing.Size(202, 70)
        Me.btnTest.TabIndex = 5
        Me.btnTest.Text = "Test it!"
        Me.btnTest.UseVisualStyleBackColor = True
        '
        'txtTotaal
        '
        Me.txtTotaal.Location = New System.Drawing.Point(52, 560)
        Me.txtTotaal.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtTotaal.Name = "txtTotaal"
        Me.txtTotaal.ReadOnly = True
        Me.txtTotaal.Size = New System.Drawing.Size(423, 26)
        Me.txtTotaal.TabIndex = 15
        Me.txtTotaal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnBerekenen
        '
        Me.btnBerekenen.Location = New System.Drawing.Point(52, 439)
        Me.btnBerekenen.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnBerekenen.Name = "btnBerekenen"
        Me.btnBerekenen.Size = New System.Drawing.Size(426, 99)
        Me.btnBerekenen.TabIndex = 5
        Me.btnBerekenen.Text = "Bereken"
        Me.btnBerekenen.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(21, 225)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(213, 56)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "Uitvoerend centrum:"
        '
        'cboUitvCent
        '
        Me.cboUitvCent.BackColor = System.Drawing.Color.Red
        Me.cboUitvCent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboUitvCent.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboUitvCent.FormattingEnabled = True
        Me.cboUitvCent.Location = New System.Drawing.Point(240, 239)
        Me.cboUitvCent.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cboUitvCent.Name = "cboUitvCent"
        Me.cboUitvCent.Size = New System.Drawing.Size(235, 28)
        Me.cboUitvCent.TabIndex = 1
        '
        'dtpStartcursus
        '
        Me.dtpStartcursus.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpStartcursus.Location = New System.Drawing.Point(240, 381)
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
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 976)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(1, 0, 21, 0)
        Me.StatusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.StatusStrip1.Size = New System.Drawing.Size(533, 5)
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
        Me.btnOnt.Size = New System.Drawing.Size(196, 70)
        Me.btnOnt.TabIndex = 5
        Me.btnOnt.Text = "Per Ontwikkelaar"
        Me.btnOnt.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(20, 103)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(213, 35)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Opleidngsnummer:"
        '
        'txtOpleidingsnummer
        '
        Me.txtOpleidingsnummer.Location = New System.Drawing.Point(240, 110)
        Me.txtOpleidingsnummer.Name = "txtOpleidingsnummer"
        Me.txtOpleidingsnummer.Size = New System.Drawing.Size(142, 26)
        Me.txtOpleidingsnummer.TabIndex = 17
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(388, 104)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(87, 39)
        Me.Button1.TabIndex = 18
        Me.Button1.Text = "GET"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Location = New System.Drawing.Point(54, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(423, 231)
        Me.Panel1.TabIndex = 20
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.Panel1)
        Me.Panel2.Location = New System.Drawing.Point(0, 605)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(533, 243)
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
        Me.btnFilter.Location = New System.Drawing.Point(333, 18)
        Me.btnFilter.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnFilter.Name = "btnFilter"
        Me.btnFilter.Size = New System.Drawing.Size(184, 61)
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
        Me.ClientSize = New System.Drawing.Size(533, 981)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txtOpleidingsnummer)
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
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.MaximizeBox = False
        Me.Name = "MainScreen"
        Me.Text = "Cursus realiseerbaarheid prospectie tool"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label3 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents cboSubAfd As ComboBox
    Friend WithEvents cboMerk As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents btnFilter As Button
    Friend WithEvents cboFiltersList As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnTest As Button
    Friend WithEvents txtTotaal As TextBox
    Friend WithEvents btnBerekenen As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents cboUitvCent As ComboBox
    Friend WithEvents dtpStartcursus As DateTimePicker
    Friend WithEvents tslblStatus As ToolStripStatusLabel
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents btnOnt As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents txtOpleidingsnummer As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Panel2 As Panel
End Class
