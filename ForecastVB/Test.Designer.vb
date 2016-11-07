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
        Dim ChartArea2 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Series2 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Title3 As System.Windows.Forms.DataVisualization.Charting.Title = New System.Windows.Forms.DataVisualization.Charting.Title()
        Dim Title4 As System.Windows.Forms.DataVisualization.Charting.Title = New System.Windows.Forms.DataVisualization.Charting.Title()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Test))
        Me.pgb = New System.Windows.Forms.ProgressBar()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chartBerekend = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.dgvResult = New System.Windows.Forms.DataGridView()
        Me.lblInfo2 = New System.Windows.Forms.Label()
        Me.bgwDataLoader = New System.ComponentModel.BackgroundWorker()
        CType(Me.chartBerekend, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvResult, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pgb
        '
        Me.pgb.Location = New System.Drawing.Point(11, 772)
        Me.pgb.Margin = New System.Windows.Forms.Padding(2)
        Me.pgb.Name = "pgb"
        Me.pgb.Size = New System.Drawing.Size(642, 19)
        Me.pgb.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 802)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(0, 13)
        Me.Label1.TabIndex = 0
        '
        'chartBerekend
        '
        Me.chartBerekend.BackColor = System.Drawing.Color.Transparent
        ChartArea2.Name = "ChartArea1"
        Me.chartBerekend.ChartAreas.Add(ChartArea2)
        Me.chartBerekend.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.chartBerekend.Location = New System.Drawing.Point(658, 0)
        Me.chartBerekend.Margin = New System.Windows.Forms.Padding(0)
        Me.chartBerekend.Name = "chartBerekend"
        Me.chartBerekend.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None
        Series2.ChartArea = "ChartArea1"
        Series2.Name = "Series1"
        Me.chartBerekend.Series.Add(Series2)
        Me.chartBerekend.Size = New System.Drawing.Size(772, 854)
        Me.chartBerekend.TabIndex = 7
        Me.chartBerekend.Text = "Chart1"
        Title3.BackImageAlignment = System.Windows.Forms.DataVisualization.Charting.ChartImageAlignmentStyle.Left
        Title3.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Left
        Title3.Name = "Aantal"
        Title3.Text = "Aantal"
        Title4.Alignment = System.Drawing.ContentAlignment.BottomCenter
        Title4.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom
        Title4.Name = "Verschil"
        Title4.Text = "Verschil"
        Me.chartBerekend.Titles.Add(Title3)
        Me.chartBerekend.Titles.Add(Title4)
        '
        'dgvResult
        '
        Me.dgvResult.AllowUserToAddRows = False
        Me.dgvResult.AllowUserToOrderColumns = True
        Me.dgvResult.AllowUserToResizeRows = False
        Me.dgvResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvResult.Location = New System.Drawing.Point(11, 12)
        Me.dgvResult.Name = "dgvResult"
        Me.dgvResult.ReadOnly = True
        Me.dgvResult.Size = New System.Drawing.Size(642, 755)
        Me.dgvResult.TabIndex = 8
        '
        'lblInfo2
        '
        Me.lblInfo2.AutoSize = True
        Me.lblInfo2.Location = New System.Drawing.Point(15, 815)
        Me.lblInfo2.Name = "lblInfo2"
        Me.lblInfo2.Size = New System.Drawing.Size(0, 13)
        Me.lblInfo2.TabIndex = 9
        '
        'bgwDataLoader
        '
        '
        'Test
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(662, 851)
        Me.Controls.Add(Me.lblInfo2)
        Me.Controls.Add(Me.dgvResult)
        Me.Controls.Add(Me.chartBerekend)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.pgb)
        Me.HelpButton = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "Test"
        Me.Text = "Test"
        CType(Me.chartBerekend, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvResult, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pgb As ProgressBar
    Friend WithEvents Label1 As Label
    Friend WithEvents chartBerekend As DataVisualization.Charting.Chart
    Friend WithEvents dgvResult As DataGridView
    Friend WithEvents lblInfo2 As Label
    Friend WithEvents bgwDataLoader As System.ComponentModel.BackgroundWorker
End Class
