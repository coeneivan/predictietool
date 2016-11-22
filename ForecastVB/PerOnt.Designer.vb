<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class PerOnt
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PerOnt))
        Me.btnClearCenturm = New System.Windows.Forms.Button()
        Me.btnClearSubafdeling = New System.Windows.Forms.Button()
        Me.btnClearMerk = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.cbbCentrum = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbbSubafdeling = New System.Windows.Forms.ComboBox()
        Me.cbbMerk = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dgvResult = New System.Windows.Forms.DataGridView()
        Me.lblInfo = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbbOnt = New System.Windows.Forms.ComboBox()
        Me.btnClearOnt = New System.Windows.Forms.Button()
        CType(Me.dgvResult, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnClearCenturm
        '
        Me.btnClearCenturm.BackgroundImage = CType(resources.GetObject("btnClearCenturm.BackgroundImage"), System.Drawing.Image)
        Me.btnClearCenturm.Location = New System.Drawing.Point(194, 41)
        Me.btnClearCenturm.Name = "btnClearCenturm"
        Me.btnClearCenturm.Size = New System.Drawing.Size(27, 25)
        Me.btnClearCenturm.TabIndex = 33
        Me.btnClearCenturm.UseVisualStyleBackColor = True
        '
        'btnClearSubafdeling
        '
        Me.btnClearSubafdeling.BackgroundImage = CType(resources.GetObject("btnClearSubafdeling.BackgroundImage"), System.Drawing.Image)
        Me.btnClearSubafdeling.Location = New System.Drawing.Point(424, 12)
        Me.btnClearSubafdeling.Name = "btnClearSubafdeling"
        Me.btnClearSubafdeling.Size = New System.Drawing.Size(27, 25)
        Me.btnClearSubafdeling.TabIndex = 30
        Me.btnClearSubafdeling.UseVisualStyleBackColor = True
        '
        'btnClearMerk
        '
        Me.btnClearMerk.BackgroundImage = CType(resources.GetObject("btnClearMerk.BackgroundImage"), System.Drawing.Image)
        Me.btnClearMerk.Location = New System.Drawing.Point(194, 12)
        Me.btnClearMerk.Name = "btnClearMerk"
        Me.btnClearMerk.Size = New System.Drawing.Size(27, 25)
        Me.btnClearMerk.TabIndex = 29
        Me.btnClearMerk.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(479, 14)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(180, 46)
        Me.Button1.TabIndex = 28
        Me.Button1.Text = "Bereken"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'cbbCentrum
        '
        Me.cbbCentrum.FormattingEnabled = True
        Me.cbbCentrum.Location = New System.Drawing.Point(77, 42)
        Me.cbbCentrum.Name = "cbbCentrum"
        Me.cbbCentrum.Size = New System.Drawing.Size(111, 21)
        Me.cbbCentrum.TabIndex = 27
        Me.cbbCentrum.DropDownStyle = ComboBoxStyle.DropDownList
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(22, 46)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 13)
        Me.Label3.TabIndex = 23
        Me.Label3.Text = "Centrum:"
        '
        'cbbSubafdeling
        '
        Me.cbbSubafdeling.FormattingEnabled = True
        Me.cbbSubafdeling.Location = New System.Drawing.Point(307, 15)
        Me.cbbSubafdeling.Name = "cbbSubafdeling"
        Me.cbbSubafdeling.Size = New System.Drawing.Size(113, 21)
        Me.cbbSubafdeling.TabIndex = 25
        '
        'cbbMerk
        '
        Me.cbbMerk.FormattingEnabled = True
        Me.cbbMerk.Location = New System.Drawing.Point(61, 15)
        Me.cbbMerk.Name = "cbbMerk"
        Me.cbbMerk.Size = New System.Drawing.Size(128, 21)
        Me.cbbMerk.TabIndex = 24
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(236, 19)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(66, 13)
        Me.Label4.TabIndex = 20
        Me.Label4.Text = "Subafdeling:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(22, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 13)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "Merk:"
        '
        'dgvResult
        '
        Me.dgvResult.AllowUserToAddRows = False
        Me.dgvResult.AllowUserToOrderColumns = True
        Me.dgvResult.AllowUserToResizeRows = False
        Me.dgvResult.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader
        Me.dgvResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvResult.Location = New System.Drawing.Point(25, 72)
        Me.dgvResult.Name = "dgvResult"
        Me.dgvResult.ReadOnly = True
        Me.dgvResult.Size = New System.Drawing.Size(634, 704)
        Me.dgvResult.TabIndex = 17
        '
        'lblInfo
        '
        Me.lblInfo.AutoSize = True
        Me.lblInfo.Location = New System.Drawing.Point(26, 791)
        Me.lblInfo.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblInfo.Name = "lblInfo"
        Me.lblInfo.Size = New System.Drawing.Size(0, 13)
        Me.lblInfo.TabIndex = 16
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(236, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 13)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "Ontwikkelaar:"
        '
        'cbbOnt
        '
        Me.cbbOnt.FormattingEnabled = True
        Me.cbbOnt.Location = New System.Drawing.Point(311, 41)
        Me.cbbOnt.Name = "cbbOnt"
        Me.cbbOnt.Size = New System.Drawing.Size(108, 21)
        Me.cbbOnt.TabIndex = 25
        '
        'btnClearOnt
        '
        Me.btnClearOnt.BackgroundImage = CType(resources.GetObject("btnClearOnt.BackgroundImage"), System.Drawing.Image)
        Me.btnClearOnt.Location = New System.Drawing.Point(424, 39)
        Me.btnClearOnt.Name = "btnClearOnt"
        Me.btnClearOnt.Size = New System.Drawing.Size(27, 25)
        Me.btnClearOnt.TabIndex = 30
        Me.btnClearOnt.UseVisualStyleBackColor = True
        '
        'PerOnt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(686, 824)
        Me.Controls.Add(Me.btnClearCenturm)
        Me.Controls.Add(Me.btnClearOnt)
        Me.Controls.Add(Me.btnClearSubafdeling)
        Me.Controls.Add(Me.btnClearMerk)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.cbbCentrum)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cbbOnt)
        Me.Controls.Add(Me.cbbSubafdeling)
        Me.Controls.Add(Me.cbbMerk)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dgvResult)
        Me.Controls.Add(Me.lblInfo)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "PerOnt"
        Me.Text = "Per ontwikkelaar"
        CType(Me.dgvResult, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnClearCenturm As Button
    Friend WithEvents btnClearSubafdeling As Button
    Friend WithEvents btnClearMerk As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents cbbCentrum As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents cbbSubafdeling As ComboBox
    Friend WithEvents cbbMerk As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents dgvResult As DataGridView
    Friend WithEvents lblInfo As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents cbbOnt As ComboBox
    Friend WithEvents btnClearOnt As Button
End Class
