<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Test
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
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim ChartArea2 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend2 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series2 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Test))
        Me.cboMerk = New System.Windows.Forms.ComboBox()
        Me.cboDag = New System.Windows.Forms.ComboBox()
        Me.lvResult = New System.Windows.Forms.ListView()
        Me.btnCheck = New System.Windows.Forms.Button()
        Me.pgb = New System.Windows.Forms.ProgressBar()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.cursusChart = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.chartBerekend = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.cboUitvoerendCentrum = New System.Windows.Forms.ComboBox()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.cbbMonth = New System.Windows.Forms.ComboBox()
        CType(Me.cursusChart, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chartBerekend, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cboMerk
        '
        Me.cboMerk.FormattingEnabled = True
        Me.cboMerk.Location = New System.Drawing.Point(11, 10)
        Me.cboMerk.Margin = New System.Windows.Forms.Padding(2)
        Me.cboMerk.Name = "cboMerk"
        Me.cboMerk.Size = New System.Drawing.Size(199, 21)
        Me.cboMerk.TabIndex = 1
        Me.cboMerk.Text = "Merk"
        '
        'cboDag
        '
        Me.cboDag.FormattingEnabled = True
        Me.cboDag.Location = New System.Drawing.Point(213, 10)
        Me.cboDag.Margin = New System.Windows.Forms.Padding(2)
        Me.cboDag.Name = "cboDag"
        Me.cboDag.Size = New System.Drawing.Size(136, 21)
        Me.cboDag.TabIndex = 2
        Me.cboDag.Text = "Dag"
        '
        'lvResult
        '
        Me.lvResult.GridLines = True
        Me.lvResult.HoverSelection = True
        Me.lvResult.Location = New System.Drawing.Point(8, 60)
        Me.lvResult.Margin = New System.Windows.Forms.Padding(2)
        Me.lvResult.Name = "lvResult"
        Me.lvResult.Size = New System.Drawing.Size(646, 683)
        Me.lvResult.TabIndex = 0
        Me.lvResult.UseCompatibleStateImageBehavior = False
        Me.lvResult.View = System.Windows.Forms.View.Details
        '
        'btnCheck
        '
        Me.btnCheck.Location = New System.Drawing.Point(566, 10)
        Me.btnCheck.Margin = New System.Windows.Forms.Padding(2)
        Me.btnCheck.Name = "btnCheck"
        Me.btnCheck.Size = New System.Drawing.Size(88, 46)
        Me.btnCheck.TabIndex = 6
        Me.btnCheck.Text = "GO"
        Me.btnCheck.UseVisualStyleBackColor = True
        '
        'pgb
        '
        Me.pgb.Location = New System.Drawing.Point(8, 772)
        Me.pgb.Margin = New System.Windows.Forms.Padding(2)
        Me.pgb.Name = "pgb"
        Me.pgb.Size = New System.Drawing.Size(645, 19)
        Me.pgb.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 816)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Label1"
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"Linear regression", "Decision tree", "Lagrange Interpolating Polynomial", "Data mining algorithms: Prediction"})
        Me.ComboBox1.Location = New System.Drawing.Point(355, 21)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(205, 21)
        Me.ComboBox1.TabIndex = 5
        Me.ComboBox1.Text = "Algoritme"
        '
        'cursusChart
        '
        ChartArea1.Name = "ChartArea1"
        Me.cursusChart.ChartAreas.Add(ChartArea1)
        Legend1.Name = "Legend1"
        Me.cursusChart.Legends.Add(Legend1)
        Me.cursusChart.Location = New System.Drawing.Point(660, 10)
        Me.cursusChart.Name = "cursusChart"
        Series1.ChartArea = "ChartArea1"
        Series1.Legend = "Legend1"
        Series1.Name = "Series1"
        Me.cursusChart.Series.Add(Series1)
        Me.cursusChart.Size = New System.Drawing.Size(772, 400)
        Me.cursusChart.TabIndex = 9
        Me.cursusChart.Text = "Chart1"
        '
        'chartBerekend
        '
        ChartArea2.Name = "ChartArea1"
        Me.chartBerekend.ChartAreas.Add(ChartArea2)
        Legend2.Name = "Legend1"
        Me.chartBerekend.Legends.Add(Legend2)
        Me.chartBerekend.Location = New System.Drawing.Point(660, 416)
        Me.chartBerekend.Name = "chartBerekend"
        Series2.ChartArea = "ChartArea1"
        Series2.Legend = "Legend1"
        Series2.Name = "Series1"
        Me.chartBerekend.Series.Add(Series2)
        Me.chartBerekend.Size = New System.Drawing.Size(772, 400)
        Me.chartBerekend.TabIndex = 7
        Me.chartBerekend.Text = "Chart1"
        '
        'cboUitvoerendCentrum
        '
        Me.cboUitvoerendCentrum.FormattingEnabled = True
        Me.cboUitvoerendCentrum.Location = New System.Drawing.Point(11, 35)
        Me.cboUitvoerendCentrum.Margin = New System.Windows.Forms.Padding(2)
        Me.cboUitvoerendCentrum.Name = "cboUitvoerendCentrum"
        Me.cboUitvoerendCentrum.Size = New System.Drawing.Size(199, 21)
        Me.cboUitvoerendCentrum.TabIndex = 3
        Me.cboUitvoerendCentrum.Text = "Uitvoerend centrum"
        '
        'ComboBox2
        '
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Location = New System.Drawing.Point(668, 424)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(121, 21)
        Me.ComboBox2.TabIndex = 10
        '
        'cbbMonth
        '
        Me.cbbMonth.DisplayMember = "Key"
        Me.cbbMonth.FormattingEnabled = True
        Me.cbbMonth.Items.AddRange(New Object() {CType(resources.GetObject("cbbMonth.Items"), Object), CType(resources.GetObject("cbbMonth.Items1"), Object), CType(resources.GetObject("cbbMonth.Items2"), Object), CType(resources.GetObject("cbbMonth.Items3"), Object), CType(resources.GetObject("cbbMonth.Items4"), Object), CType(resources.GetObject("cbbMonth.Items5"), Object), CType(resources.GetObject("cbbMonth.Items6"), Object), CType(resources.GetObject("cbbMonth.Items7"), Object), CType(resources.GetObject("cbbMonth.Items8"), Object), CType(resources.GetObject("cbbMonth.Items9"), Object), CType(resources.GetObject("cbbMonth.Items10"), Object), CType(resources.GetObject("cbbMonth.Items11"), Object)})
        Me.cbbMonth.Location = New System.Drawing.Point(213, 35)
        Me.cbbMonth.Name = "cbbMonth"
        Me.cbbMonth.Size = New System.Drawing.Size(136, 21)
        Me.cbbMonth.TabIndex = 4
        Me.cbbMonth.Text = "Maand"
        Me.cbbMonth.ValueMember = "Value"
        '
        'Test
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(1444, 851)
        Me.Controls.Add(Me.cbbMonth)
        Me.Controls.Add(Me.ComboBox2)
        Me.Controls.Add(Me.chartBerekend)
        Me.Controls.Add(Me.cursusChart)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.pgb)
        Me.Controls.Add(Me.btnCheck)
        Me.Controls.Add(Me.lvResult)
        Me.Controls.Add(Me.cboDag)
        Me.Controls.Add(Me.cboUitvoerendCentrum)
        Me.Controls.Add(Me.cboMerk)
        Me.HelpButton = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "Test"
        Me.Text = "Test"
        CType(Me.cursusChart, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chartBerekend, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cboMerk As ComboBox
    Friend WithEvents cboDag As ComboBox
    Friend WithEvents lvResult As ListView
    Friend WithEvents btnCheck As Button
    Friend WithEvents pgb As ProgressBar
    Friend WithEvents Label1 As Label
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents cboUitvoerendCentrum As ComboBox
    Friend WithEvents cursusChart As DataVisualization.Charting.Chart
    Friend WithEvents chartBerekend As DataVisualization.Charting.Chart
    Friend WithEvents ComboBox2 As ComboBox
    Friend WithEvents cbbMonth As ComboBox
End Class
