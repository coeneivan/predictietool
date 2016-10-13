<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.txtNewX = New System.Windows.Forms.TextBox()
        Me.txtNewY = New System.Windows.Forms.TextBox()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.lbX = New System.Windows.Forms.ListBox()
        Me.lbY = New System.Windows.Forms.ListBox()
        Me.txtCalculateX = New System.Windows.Forms.TextBox()
        Me.txtCalculateY = New System.Windows.Forms.TextBox()
        Me.btnCalc = New System.Windows.Forms.Button()
        Me.btnTest = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtResult = New System.Windows.Forms.TextBox()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.SuspendLayout()
        '
        'txtNewX
        '
        Me.txtNewX.Location = New System.Drawing.Point(27, 40)
        Me.txtNewX.Margin = New System.Windows.Forms.Padding(2)
        Me.txtNewX.Name = "txtNewX"
        Me.txtNewX.Size = New System.Drawing.Size(147, 22)
        Me.txtNewX.TabIndex = 0
        '
        'txtNewY
        '
        Me.txtNewY.Location = New System.Drawing.Point(210, 40)
        Me.txtNewY.Margin = New System.Windows.Forms.Padding(2)
        Me.txtNewY.Name = "txtNewY"
        Me.txtNewY.Size = New System.Drawing.Size(195, 22)
        Me.txtNewY.TabIndex = 1
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(449, 32)
        Me.btnAdd.Margin = New System.Windows.Forms.Padding(2)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(147, 35)
        Me.btnAdd.TabIndex = 2
        Me.btnAdd.Text = "ADD"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'lbX
        '
        Me.lbX.FormattingEnabled = True
        Me.lbX.ItemHeight = 16
        Me.lbX.Location = New System.Drawing.Point(27, 143)
        Me.lbX.Margin = New System.Windows.Forms.Padding(2)
        Me.lbX.Name = "lbX"
        Me.lbX.Size = New System.Drawing.Size(147, 276)
        Me.lbX.TabIndex = 3
        '
        'lbY
        '
        Me.lbY.FormattingEnabled = True
        Me.lbY.ItemHeight = 16
        Me.lbY.Location = New System.Drawing.Point(210, 143)
        Me.lbY.Margin = New System.Windows.Forms.Padding(2)
        Me.lbY.Name = "lbY"
        Me.lbY.Size = New System.Drawing.Size(195, 276)
        Me.lbY.TabIndex = 3
        '
        'txtCalculateX
        '
        Me.txtCalculateX.Location = New System.Drawing.Point(27, 85)
        Me.txtCalculateX.Margin = New System.Windows.Forms.Padding(2)
        Me.txtCalculateX.Name = "txtCalculateX"
        Me.txtCalculateX.Size = New System.Drawing.Size(147, 22)
        Me.txtCalculateX.TabIndex = 4
        Me.txtCalculateX.Text = "2015"
        '
        'txtCalculateY
        '
        Me.txtCalculateY.Location = New System.Drawing.Point(210, 85)
        Me.txtCalculateY.Margin = New System.Windows.Forms.Padding(2)
        Me.txtCalculateY.Name = "txtCalculateY"
        Me.txtCalculateY.ReadOnly = True
        Me.txtCalculateY.Size = New System.Drawing.Size(195, 22)
        Me.txtCalculateY.TabIndex = 6
        '
        'btnCalc
        '
        Me.btnCalc.Location = New System.Drawing.Point(449, 77)
        Me.btnCalc.Margin = New System.Windows.Forms.Padding(2)
        Me.btnCalc.Name = "btnCalc"
        Me.btnCalc.Size = New System.Drawing.Size(147, 35)
        Me.btnCalc.TabIndex = 5
        Me.btnCalc.Text = "Prospect"
        Me.btnCalc.UseVisualStyleBackColor = True
        '
        'btnTest
        '
        Me.btnTest.Location = New System.Drawing.Point(449, 188)
        Me.btnTest.Margin = New System.Windows.Forms.Padding(2)
        Me.btnTest.Name = "btnTest"
        Me.btnTest.Size = New System.Drawing.Size(147, 72)
        Me.btnTest.TabIndex = 5
        Me.btnTest.Text = "ADD TEST DAT (YEAR)"
        Me.btnTest.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(27, 20)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 17)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "New X"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(210, 20)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 17)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "New Y"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(27, 67)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(92, 17)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "X to prospect"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(27, 125)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(73, 17)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Known X's"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(210, 67)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(83, 17)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Prospection"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(210, 125)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(71, 17)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "known Y's"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(449, 265)
        Me.Button1.Margin = New System.Windows.Forms.Padding(2)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(147, 72)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "ADD TEST DATA (WEB)"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(449, 342)
        Me.Button2.Margin = New System.Windows.Forms.Padding(2)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(147, 72)
        Me.Button2.TabIndex = 5
        Me.Button2.Text = "ADD TEST DATA (MONDAY)"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(449, 125)
        Me.Button3.Margin = New System.Windows.Forms.Padding(2)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(147, 35)
        Me.Button3.TabIndex = 5
        Me.Button3.Text = "Clear list"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(27, 444)
        Me.Label7.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(148, 17)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "Result (95% certainty)"
        '
        'txtResult
        '
        Me.txtResult.Location = New System.Drawing.Point(27, 472)
        Me.txtResult.Margin = New System.Windows.Forms.Padding(2)
        Me.txtResult.Name = "txtResult"
        Me.txtResult.ReadOnly = True
        Me.txtResult.Size = New System.Drawing.Size(378, 22)
        Me.txtResult.TabIndex = 9
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        Me.OpenFileDialog1.Filter = "JSON Files|*.JSON"
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(449, 472)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(147, 22)
        Me.Button4.TabIndex = 10
        Me.Button4.Text = "Button4"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(30, 533)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(75, 23)
        Me.Button5.TabIndex = 11
        Me.Button5.Text = "Button5"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(625, 652)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.txtResult)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lbY)
        Me.Controls.Add(Me.lbX)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnTest)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.btnCalc)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.txtCalculateY)
        Me.Controls.Add(Me.txtCalculateX)
        Me.Controls.Add(Me.txtNewY)
        Me.Controls.Add(Me.txtNewX)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtNewX As TextBox
    Friend WithEvents txtNewY As TextBox
    Friend WithEvents btnAdd As Button
    Friend WithEvents lbX As ListBox
    Friend WithEvents lbY As ListBox
    Friend WithEvents txtCalculateX As TextBox
    Friend WithEvents txtCalculateY As TextBox
    Friend WithEvents btnCalc As Button
    Friend WithEvents btnTest As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents txtResult As TextBox
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents Button4 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
End Class
