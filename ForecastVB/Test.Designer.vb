<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
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
        Me.SuspendLayout()
        '
        'cboMerk
        '
        Me.cboMerk.FormattingEnabled = True
        Me.cboMerk.Location = New System.Drawing.Point(10, 12)
        Me.cboMerk.Name = "cboMerk"
        Me.cboMerk.Size = New System.Drawing.Size(365, 24)
        Me.cboMerk.TabIndex = 0
        Me.cboMerk.Text = "Merk"
        '
        'cboDag
        '
        Me.cboDag.FormattingEnabled = True
        Me.cboDag.Location = New System.Drawing.Point(381, 13)
        Me.cboDag.Name = "cboDag"
        Me.cboDag.Size = New System.Drawing.Size(365, 24)
        Me.cboDag.TabIndex = 0
        Me.cboDag.Text = "Dag"
        '
        'lvResult
        '
        Me.lvResult.GridLines = True
        Me.lvResult.HoverSelection = True
        Me.lvResult.Location = New System.Drawing.Point(10, 43)
        Me.lvResult.Name = "lvResult"
        Me.lvResult.Size = New System.Drawing.Size(860, 871)
        Me.lvResult.TabIndex = 1
        Me.lvResult.UseCompatibleStateImageBehavior = False
        Me.lvResult.View = System.Windows.Forms.View.Details
        '
        'btnCheck
        '
        Me.btnCheck.Location = New System.Drawing.Point(752, 13)
        Me.btnCheck.Name = "btnCheck"
        Me.btnCheck.Size = New System.Drawing.Size(118, 24)
        Me.btnCheck.TabIndex = 2
        Me.btnCheck.Text = "GO"
        Me.btnCheck.UseVisualStyleBackColor = True
        '
        'pgb
        '
        Me.pgb.Location = New System.Drawing.Point(10, 950)
        Me.pgb.Name = "pgb"
        Me.pgb.Size = New System.Drawing.Size(860, 23)
        Me.pgb.TabIndex = 3
        '
        'Test
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(882, 1047)
        Me.Controls.Add(Me.pgb)
        Me.Controls.Add(Me.btnCheck)
        Me.Controls.Add(Me.lvResult)
        Me.Controls.Add(Me.cboDag)
        Me.Controls.Add(Me.cboMerk)
        Me.Name = "Test"
        Me.Text = "Test"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents cboMerk As ComboBox
    Friend WithEvents cboDag As ComboBox
    Friend WithEvents lvResult As ListView
    Friend WithEvents btnCheck As Button
    Friend WithEvents pgb As ProgressBar
End Class
