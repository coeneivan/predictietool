﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
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
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Title1 As System.Windows.Forms.DataVisualization.Charting.Title = New System.Windows.Forms.DataVisualization.Charting.Title()
        Dim Title2 As System.Windows.Forms.DataVisualization.Charting.Title = New System.Windows.Forms.DataVisualization.Charting.Title()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Test))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chartBerekend = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.dgvResult = New System.Windows.Forms.DataGridView()
        Me.lblInfo2 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbbMerk = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbbCentrum = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cbbSubafdeling = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cbbLesdag = New System.Windows.Forms.ComboBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnClearMerk = New System.Windows.Forms.Button()
        Me.btnClearCenturm = New System.Windows.Forms.Button()
        Me.btnClearSubafdeling = New System.Windows.Forms.Button()
        Me.btnClearMaand = New System.Windows.Forms.Button()
        Me.btnClearDag = New System.Windows.Forms.Button()
        Me.cbbMaand = New System.Windows.Forms.ComboBox()
        CType(Me.chartBerekend, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvResult, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(20, 987)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(0, 17)
        Me.Label1.TabIndex = 0
        '
        'chartBerekend
        '
        Me.chartBerekend.BackColor = System.Drawing.Color.Transparent
        ChartArea1.Name = "ChartArea1"
        Me.chartBerekend.ChartAreas.Add(ChartArea1)
        Me.chartBerekend.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.chartBerekend.Location = New System.Drawing.Point(877, 0)
        Me.chartBerekend.Margin = New System.Windows.Forms.Padding(0)
        Me.chartBerekend.Name = "chartBerekend"
        Me.chartBerekend.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None
        Series1.ChartArea = "ChartArea1"
        Series1.Name = "Series1"
        Me.chartBerekend.Series.Add(Series1)
        Me.chartBerekend.Size = New System.Drawing.Size(1029, 1051)
        Me.chartBerekend.TabIndex = 7
        Me.chartBerekend.Text = "Chart1"
        Title1.BackImageAlignment = System.Windows.Forms.DataVisualization.Charting.ChartImageAlignmentStyle.Left
        Title1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Left
        Title1.Name = "Aantal"
        Title1.Text = "Aantal"
        Title2.Alignment = System.Drawing.ContentAlignment.BottomCenter
        Title2.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom
        Title2.Name = "Verschil"
        Title2.Text = "Verschil"
        Me.chartBerekend.Titles.Add(Title1)
        Me.chartBerekend.Titles.Add(Title2)
        '
        'dgvResult
        '
        Me.dgvResult.AllowUserToAddRows = False
        Me.dgvResult.AllowUserToOrderColumns = True
        Me.dgvResult.AllowUserToResizeRows = False
        Me.dgvResult.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader
        Me.dgvResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvResult.Location = New System.Drawing.Point(21, 78)
        Me.dgvResult.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.dgvResult.Name = "dgvResult"
        Me.dgvResult.ReadOnly = True
        Me.dgvResult.Size = New System.Drawing.Size(845, 866)
        Me.dgvResult.TabIndex = 8
        '
        'lblInfo2
        '
        Me.lblInfo2.AutoSize = True
        Me.lblInfo2.Location = New System.Drawing.Point(20, 1003)
        Me.lblInfo2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblInfo2.Name = "lblInfo2"
        Me.lblInfo2.Size = New System.Drawing.Size(0, 17)
        Me.lblInfo2.TabIndex = 9
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(17, 16)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 17)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Merk:"
        '
        'cbbMerk
        '
        Me.cbbMerk.FormattingEnabled = True
        Me.cbbMerk.Location = New System.Drawing.Point(71, 11)
        Me.cbbMerk.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cbbMerk.Name = "cbbMerk"
        Me.cbbMerk.Size = New System.Drawing.Size(169, 24)
        Me.cbbMerk.TabIndex = 11
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(17, 49)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 17)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Centrum:"
        '
        'cbbCentrum
        '
        Me.cbbCentrum.FormattingEnabled = True
        Me.cbbCentrum.Location = New System.Drawing.Point(91, 44)
        Me.cbbCentrum.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cbbCentrum.Name = "cbbCentrum"
        Me.cbbCentrum.Size = New System.Drawing.Size(149, 24)
        Me.cbbCentrum.TabIndex = 11
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(304, 15)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(87, 17)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Subafdeling:"
        '
        'cbbSubafdeling
        '
        Me.cbbSubafdeling.FormattingEnabled = True
        Me.cbbSubafdeling.Location = New System.Drawing.Point(400, 11)
        Me.cbbSubafdeling.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cbbSubafdeling.Name = "cbbSubafdeling"
        Me.cbbSubafdeling.Size = New System.Drawing.Size(148, 24)
        Me.cbbSubafdeling.TabIndex = 11
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(304, 49)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(81, 17)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Startdatum:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(623, 15)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(38, 17)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Dag:"
        '
        'cbbLesdag
        '
        Me.cbbLesdag.FormattingEnabled = True
        Me.cbbLesdag.Location = New System.Drawing.Point(671, 11)
        Me.cbbLesdag.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cbbLesdag.Name = "cbbLesdag"
        Me.cbbLesdag.Size = New System.Drawing.Size(151, 24)
        Me.cbbLesdag.TabIndex = 11
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(627, 42)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(240, 28)
        Me.Button1.TabIndex = 13
        Me.Button1.Text = "Bereken"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btnClearMerk
        '
        Me.btnClearMerk.BackgroundImage = CType(resources.GetObject("btnClearMerk.BackgroundImage"), System.Drawing.Image)
        Me.btnClearMerk.Location = New System.Drawing.Point(249, 9)
        Me.btnClearMerk.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnClearMerk.Name = "btnClearMerk"
        Me.btnClearMerk.Size = New System.Drawing.Size(36, 31)
        Me.btnClearMerk.TabIndex = 14
        Me.btnClearMerk.UseVisualStyleBackColor = True
        '
        'btnClearCenturm
        '
        Me.btnClearCenturm.BackgroundImage = CType(resources.GetObject("btnClearCenturm.BackgroundImage"), System.Drawing.Image)
        Me.btnClearCenturm.Location = New System.Drawing.Point(249, 42)
        Me.btnClearCenturm.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnClearCenturm.Name = "btnClearCenturm"
        Me.btnClearCenturm.Size = New System.Drawing.Size(36, 31)
        Me.btnClearCenturm.TabIndex = 14
        Me.btnClearCenturm.UseVisualStyleBackColor = True
        '
        'btnClearSubafdeling
        '
        Me.btnClearSubafdeling.BackgroundImage = CType(resources.GetObject("btnClearSubafdeling.BackgroundImage"), System.Drawing.Image)
        Me.btnClearSubafdeling.Location = New System.Drawing.Point(557, 9)
        Me.btnClearSubafdeling.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnClearSubafdeling.Name = "btnClearSubafdeling"
        Me.btnClearSubafdeling.Size = New System.Drawing.Size(36, 31)
        Me.btnClearSubafdeling.TabIndex = 14
        Me.btnClearSubafdeling.UseVisualStyleBackColor = True
        '
        'btnClearMaand
        '
        Me.btnClearMaand.BackgroundImage = CType(resources.GetObject("btnClearMaand.BackgroundImage"), System.Drawing.Image)
        Me.btnClearMaand.Location = New System.Drawing.Point(557, 42)
        Me.btnClearMaand.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnClearMaand.Name = "btnClearMaand"
        Me.btnClearMaand.Size = New System.Drawing.Size(36, 31)
        Me.btnClearMaand.TabIndex = 14
        Me.btnClearMaand.UseVisualStyleBackColor = True
        '
        'btnClearDag
        '
        Me.btnClearDag.BackgroundImage = CType(resources.GetObject("btnClearDag.BackgroundImage"), System.Drawing.Image)
        Me.btnClearDag.Location = New System.Drawing.Point(831, 9)
        Me.btnClearDag.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnClearDag.Name = "btnClearDag"
        Me.btnClearDag.Size = New System.Drawing.Size(36, 31)
        Me.btnClearDag.TabIndex = 14
        Me.btnClearDag.UseVisualStyleBackColor = True
        '
        'cbbMaand
        '
        Me.cbbMaand.FormattingEnabled = True
        Me.cbbMaand.Location = New System.Drawing.Point(388, 44)
        Me.cbbMaand.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cbbMaand.Name = "cbbMaand"
        Me.cbbMaand.Size = New System.Drawing.Size(160, 24)
        Me.cbbMaand.TabIndex = 15
        '
        'Test
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(883, 1047)
        Me.Controls.Add(Me.cbbMaand)
        Me.Controls.Add(Me.btnClearCenturm)
        Me.Controls.Add(Me.btnClearDag)
        Me.Controls.Add(Me.btnClearMaand)
        Me.Controls.Add(Me.btnClearSubafdeling)
        Me.Controls.Add(Me.btnClearMerk)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.cbbCentrum)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cbbLesdag)
        Me.Controls.Add(Me.cbbSubafdeling)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cbbMerk)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblInfo2)
        Me.Controls.Add(Me.dgvResult)
        Me.Controls.Add(Me.chartBerekend)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.HelpButton = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.MaximizeBox = False
        Me.Name = "Test"
        Me.Text = "Test"
        CType(Me.chartBerekend, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvResult, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents chartBerekend As DataVisualization.Charting.Chart
    Friend WithEvents dgvResult As DataGridView
    Friend WithEvents lblInfo2 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents cbbMerk As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents cbbCentrum As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents cbbSubafdeling As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents cbbLesdag As ComboBox
    Friend WithEvents Button1 As Button
    Friend WithEvents btnClearMerk As Button
    Friend WithEvents btnClearCenturm As Button
    Friend WithEvents btnClearSubafdeling As Button
    Friend WithEvents btnClearMaand As Button
    Friend WithEvents btnClearDag As Button
    Friend WithEvents cbbMaand As ComboBox
End Class
