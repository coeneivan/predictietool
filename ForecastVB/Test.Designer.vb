﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Test
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.cboMerk = New System.Windows.Forms.ComboBox()
        Me.cboDag = New System.Windows.Forms.ComboBox()
        Me.lvResult = New System.Windows.Forms.ListView()
        Me.btnCheck = New System.Windows.Forms.Button()
        Me.pgb = New System.Windows.Forms.ProgressBar()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'cboMerk
        '
        Me.cboMerk.FormattingEnabled = True
        Me.cboMerk.Location = New System.Drawing.Point(8, 10)
        Me.cboMerk.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.cboMerk.Name = "cboMerk"
        Me.cboMerk.Size = New System.Drawing.Size(275, 21)
        Me.cboMerk.TabIndex = 0
        Me.cboMerk.Text = "Merk"
        '
        'cboDag
        '
        Me.cboDag.FormattingEnabled = True
        Me.cboDag.Location = New System.Drawing.Point(286, 10)
        Me.cboDag.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.cboDag.Name = "cboDag"
        Me.cboDag.Size = New System.Drawing.Size(275, 21)
        Me.cboDag.TabIndex = 0
        Me.cboDag.Text = "Dag"
        '
        'lvResult
        '
        Me.lvResult.GridLines = True
        Me.lvResult.HoverSelection = True
        Me.lvResult.Location = New System.Drawing.Point(8, 35)
        Me.lvResult.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.lvResult.Name = "lvResult"
        Me.lvResult.Size = New System.Drawing.Size(646, 708)
        Me.lvResult.TabIndex = 1
        Me.lvResult.UseCompatibleStateImageBehavior = False
        Me.lvResult.View = System.Windows.Forms.View.Details
        '
        'btnCheck
        '
        Me.btnCheck.Location = New System.Drawing.Point(566, 11)
        Me.btnCheck.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btnCheck.Name = "btnCheck"
        Me.btnCheck.Size = New System.Drawing.Size(88, 21)
        Me.btnCheck.TabIndex = 2
        Me.btnCheck.Text = "GO"
        Me.btnCheck.UseVisualStyleBackColor = True
        '
        'pgb
        '
        Me.pgb.Location = New System.Drawing.Point(8, 772)
        Me.pgb.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.pgb.Name = "pgb"
        Me.pgb.Size = New System.Drawing.Size(645, 19)
        Me.pgb.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 816)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Label1"
        '
        'Test
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(662, 851)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.pgb)
        Me.Controls.Add(Me.btnCheck)
        Me.Controls.Add(Me.lvResult)
        Me.Controls.Add(Me.cboDag)
        Me.Controls.Add(Me.cboMerk)
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Name = "Test"
        Me.Text = "Test"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cboMerk As ComboBox
    Friend WithEvents cboDag As ComboBox
    Friend WithEvents lvResult As ListView
    Friend WithEvents btnCheck As Button
    Friend WithEvents pgb As ProgressBar
    Friend WithEvents Label1 As Label
End Class
