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
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboSubAfd = New System.Windows.Forms.ComboBox()
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
        Me.dtpStartcursus = New System.Windows.Forms.DateTimePicker()
        Me.tslblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripSplitButton1 = New System.Windows.Forms.ToolStripSplitButton()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(65, 205)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Sub afdeling;"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(32, 254)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(102, 13)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Start van de cursus:"
        '
        'cboSubAfd
        '
        Me.cboSubAfd.FormattingEnabled = True
        Me.cboSubAfd.Location = New System.Drawing.Point(160, 202)
        Me.cboSubAfd.Margin = New System.Windows.Forms.Padding(2)
        Me.cboSubAfd.Name = "cboSubAfd"
        Me.cboSubAfd.Size = New System.Drawing.Size(158, 21)
        Me.cboSubAfd.TabIndex = 2
        '
        'cboMerk
        '
        Me.cboMerk.FormattingEnabled = True
        Me.cboMerk.Location = New System.Drawing.Point(160, 108)
        Me.cboMerk.Margin = New System.Windows.Forms.Padding(2)
        Me.cboMerk.Name = "cboMerk"
        Me.cboMerk.Size = New System.Drawing.Size(158, 21)
        Me.cboMerk.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(100, 111)
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
        Me.Button1.Location = New System.Drawing.Point(103, 431)
        Me.Button1.Margin = New System.Windows.Forms.Padding(2)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(141, 41)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "Test it!"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txtTotaal
        '
        Me.txtTotaal.Location = New System.Drawing.Point(34, 391)
        Me.txtTotaal.Name = "txtTotaal"
        Me.txtTotaal.ReadOnly = True
        Me.txtTotaal.Size = New System.Drawing.Size(282, 20)
        Me.txtTotaal.TabIndex = 15
        Me.txtTotaal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(34, 294)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(284, 64)
        Me.Button2.TabIndex = 5
        Me.Button2.Text = "Calculate"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(31, 158)
        Me.Label7.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(103, 13)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "Uitvoerend centrum:"
        '
        'cboUitvCent
        '
        Me.cboUitvCent.FormattingEnabled = True
        Me.cboUitvCent.Location = New System.Drawing.Point(160, 155)
        Me.cboUitvCent.Margin = New System.Windows.Forms.Padding(2)
        Me.cboUitvCent.Name = "cboUitvCent"
        Me.cboUitvCent.Size = New System.Drawing.Size(158, 21)
        Me.cboUitvCent.TabIndex = 1
        '
        'dtpStartcursus
        '
        Me.dtpStartcursus.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpStartcursus.Location = New System.Drawing.Point(160, 248)
        Me.dtpStartcursus.Margin = New System.Windows.Forms.Padding(2)
        Me.dtpStartcursus.Name = "dtpStartcursus"
        Me.dtpStartcursus.Size = New System.Drawing.Size(158, 20)
        Me.dtpStartcursus.TabIndex = 4
        '
        'tslblStatus
        '
        Me.tslblStatus.ActiveLinkColor = System.Drawing.Color.DarkGray
        Me.tslblStatus.LinkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.tslblStatus.Name = "tslblStatus"
        Me.tslblStatus.Size = New System.Drawing.Size(0, 14)
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tslblStatus, Me.ToolStripSplitButton1})
        Me.StatusStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 486)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.StatusStrip1.Size = New System.Drawing.Size(356, 22)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.Stretch = False
        Me.StatusStrip1.TabIndex = 16
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripSplitButton1
        '
        Me.ToolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripSplitButton1.Image = CType(resources.GetObject("ToolStripSplitButton1.Image"), System.Drawing.Image)
        Me.ToolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripSplitButton1.Name = "ToolStripSplitButton1"
        Me.ToolStripSplitButton1.Size = New System.Drawing.Size(32, 20)
        Me.ToolStripSplitButton1.Text = "Refresh"
        '
        'MainScreen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(356, 508)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.txtTotaal)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.cboFiltersList)
        Me.Controls.Add(Me.btnFilter)
        Me.Controls.Add(Me.cboUitvCent)
        Me.Controls.Add(Me.cboMerk)
        Me.Controls.Add(Me.dtpStartcursus)
        Me.Controls.Add(Me.cboSubAfd)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MaximizeBox = False
        Me.Name = "MainScreen"
        Me.Text = "Cursus realiseerbaarheid prospectie tool"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
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
    Friend WithEvents Button1 As Button
    Friend WithEvents txtTotaal As TextBox
    Friend WithEvents Button2 As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents cboUitvCent As ComboBox
    Friend WithEvents dtpStartcursus As DateTimePicker
    Friend WithEvents tslblStatus As ToolStripStatusLabel
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStripSplitButton1 As ToolStripSplitButton
End Class
