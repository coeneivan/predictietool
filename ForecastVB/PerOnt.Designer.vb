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
        Me.btnBereken = New System.Windows.Forms.Button()
        Me.cbbCentrum = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbbSubafdeling = New System.Windows.Forms.ComboBox()
        Me.cbbMerk = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dgvResult = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbbOnt = New System.Windows.Forms.ComboBox()
        Me.btnClearOnt = New System.Windows.Forms.Button()
        Me.cbbValtTussen = New System.Windows.Forms.ComboBox()
        Me.LblPercBereik = New System.Windows.Forms.Label()
        Me.cbbMaand = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnClearMaand = New System.Windows.Forms.Button()
        Me.dgvExtraInfo = New System.Windows.Forms.DataGridView()
        CType(Me.dgvResult, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvExtraInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnClearCenturm
        '
        Me.btnClearCenturm.BackgroundImage = CType(resources.GetObject("btnClearCenturm.BackgroundImage"), System.Drawing.Image)
        Me.btnClearCenturm.Location = New System.Drawing.Point(291, 63)
        Me.btnClearCenturm.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnClearCenturm.Name = "btnClearCenturm"
        Me.btnClearCenturm.Size = New System.Drawing.Size(40, 38)
        Me.btnClearCenturm.TabIndex = 33
        Me.btnClearCenturm.UseVisualStyleBackColor = True
        '
        'btnClearSubafdeling
        '
        Me.btnClearSubafdeling.BackgroundImage = CType(resources.GetObject("btnClearSubafdeling.BackgroundImage"), System.Drawing.Image)
        Me.btnClearSubafdeling.Location = New System.Drawing.Point(636, 18)
        Me.btnClearSubafdeling.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnClearSubafdeling.Name = "btnClearSubafdeling"
        Me.btnClearSubafdeling.Size = New System.Drawing.Size(40, 38)
        Me.btnClearSubafdeling.TabIndex = 30
        Me.btnClearSubafdeling.UseVisualStyleBackColor = True
        '
        'btnClearMerk
        '
        Me.btnClearMerk.BackgroundImage = CType(resources.GetObject("btnClearMerk.BackgroundImage"), System.Drawing.Image)
        Me.btnClearMerk.Location = New System.Drawing.Point(291, 18)
        Me.btnClearMerk.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnClearMerk.Name = "btnClearMerk"
        Me.btnClearMerk.Size = New System.Drawing.Size(40, 38)
        Me.btnClearMerk.TabIndex = 29
        Me.btnClearMerk.UseVisualStyleBackColor = True
        '
        'btnBereken
        '
        Me.btnBereken.Location = New System.Drawing.Point(718, 63)
        Me.btnBereken.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnBereken.Name = "btnBereken"
        Me.btnBereken.Size = New System.Drawing.Size(270, 32)
        Me.btnBereken.TabIndex = 28
        Me.btnBereken.Text = "Bereken"
        Me.btnBereken.UseVisualStyleBackColor = True
        '
        'cbbCentrum
        '
        Me.cbbCentrum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbbCentrum.FormattingEnabled = True
        Me.cbbCentrum.Location = New System.Drawing.Point(116, 65)
        Me.cbbCentrum.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cbbCentrum.Name = "cbbCentrum"
        Me.cbbCentrum.Size = New System.Drawing.Size(164, 28)
        Me.cbbCentrum.TabIndex = 27
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(33, 71)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 20)
        Me.Label3.TabIndex = 23
        Me.Label3.Text = "Centrum:"
        '
        'cbbSubafdeling
        '
        Me.cbbSubafdeling.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbbSubafdeling.FormattingEnabled = True
        Me.cbbSubafdeling.Location = New System.Drawing.Point(460, 23)
        Me.cbbSubafdeling.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cbbSubafdeling.Name = "cbbSubafdeling"
        Me.cbbSubafdeling.Size = New System.Drawing.Size(168, 28)
        Me.cbbSubafdeling.TabIndex = 25
        '
        'cbbMerk
        '
        Me.cbbMerk.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbbMerk.FormattingEnabled = True
        Me.cbbMerk.Location = New System.Drawing.Point(92, 23)
        Me.cbbMerk.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cbbMerk.Name = "cbbMerk"
        Me.cbbMerk.Size = New System.Drawing.Size(190, 28)
        Me.cbbMerk.TabIndex = 24
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(354, 29)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(98, 20)
        Me.Label4.TabIndex = 20
        Me.Label4.Text = "Subafdeling:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(33, 29)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 20)
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
        Me.dgvResult.Location = New System.Drawing.Point(38, 111)
        Me.dgvResult.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.dgvResult.Name = "dgvResult"
        Me.dgvResult.ReadOnly = True
        Me.dgvResult.Size = New System.Drawing.Size(951, 649)
        Me.dgvResult.TabIndex = 17
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(354, 69)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 20)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "Ontwikkelaar:"
        '
        'cbbOnt
        '
        Me.cbbOnt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbbOnt.FormattingEnabled = True
        Me.cbbOnt.Location = New System.Drawing.Point(466, 63)
        Me.cbbOnt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cbbOnt.Name = "cbbOnt"
        Me.cbbOnt.Size = New System.Drawing.Size(160, 28)
        Me.cbbOnt.TabIndex = 25
        '
        'btnClearOnt
        '
        Me.btnClearOnt.BackgroundImage = CType(resources.GetObject("btnClearOnt.BackgroundImage"), System.Drawing.Image)
        Me.btnClearOnt.Location = New System.Drawing.Point(636, 60)
        Me.btnClearOnt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnClearOnt.Name = "btnClearOnt"
        Me.btnClearOnt.Size = New System.Drawing.Size(40, 38)
        Me.btnClearOnt.TabIndex = 30
        Me.btnClearOnt.UseVisualStyleBackColor = True
        '
        'cbbValtTussen
        '
        Me.cbbValtTussen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbbValtTussen.FormattingEnabled = True
        Me.cbbValtTussen.Location = New System.Drawing.Point(876, 1217)
        Me.cbbValtTussen.Name = "cbbValtTussen"
        Me.cbbValtTussen.Size = New System.Drawing.Size(112, 28)
        Me.cbbValtTussen.TabIndex = 34
        '
        'LblPercBereik
        '
        Me.LblPercBereik.Location = New System.Drawing.Point(658, 1202)
        Me.LblPercBereik.Name = "LblPercBereik"
        Me.LblPercBereik.Size = New System.Drawing.Size(213, 60)
        Me.LblPercBereik.TabIndex = 35
        Me.LblPercBereik.Text = "% valt tussen bereik:"
        Me.LblPercBereik.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cbbMaand
        '
        Me.cbbMaand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbbMaand.FormattingEnabled = True
        Me.cbbMaand.Location = New System.Drawing.Point(788, 23)
        Me.cbbMaand.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cbbMaand.Name = "cbbMaand"
        Me.cbbMaand.Size = New System.Drawing.Size(150, 28)
        Me.cbbMaand.TabIndex = 36
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(714, 29)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(62, 20)
        Me.Label5.TabIndex = 37
        Me.Label5.Text = "Maand:"
        '
        'btnClearMaand
        '
        Me.btnClearMaand.BackgroundImage = CType(resources.GetObject("btnClearMaand.BackgroundImage"), System.Drawing.Image)
        Me.btnClearMaand.Location = New System.Drawing.Point(948, 20)
        Me.btnClearMaand.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnClearMaand.Name = "btnClearMaand"
        Me.btnClearMaand.Size = New System.Drawing.Size(40, 38)
        Me.btnClearMaand.TabIndex = 38
        Me.btnClearMaand.UseVisualStyleBackColor = True
        '
        'dgvExtraInfo
        '
        Me.dgvExtraInfo.AllowUserToAddRows = False
        Me.dgvExtraInfo.AllowUserToOrderColumns = True
        Me.dgvExtraInfo.AllowUserToResizeRows = False
        Me.dgvExtraInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader
        Me.dgvExtraInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvExtraInfo.Location = New System.Drawing.Point(37, 805)
        Me.dgvExtraInfo.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.dgvExtraInfo.Name = "dgvExtraInfo"
        Me.dgvExtraInfo.ReadOnly = True
        Me.dgvExtraInfo.Size = New System.Drawing.Size(951, 373)
        Me.dgvExtraInfo.TabIndex = 17
        '
        'PerOnt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1023, 1268)
        Me.Controls.Add(Me.btnClearMaand)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cbbMaand)
        Me.Controls.Add(Me.LblPercBereik)
        Me.Controls.Add(Me.cbbValtTussen)
        Me.Controls.Add(Me.btnClearCenturm)
        Me.Controls.Add(Me.btnClearOnt)
        Me.Controls.Add(Me.btnClearSubafdeling)
        Me.Controls.Add(Me.btnClearMerk)
        Me.Controls.Add(Me.btnBereken)
        Me.Controls.Add(Me.cbbCentrum)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cbbOnt)
        Me.Controls.Add(Me.cbbSubafdeling)
        Me.Controls.Add(Me.cbbMerk)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dgvExtraInfo)
        Me.Controls.Add(Me.dgvResult)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "PerOnt"
        Me.Text = "Per ontwikkelaar"
        CType(Me.dgvResult, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvExtraInfo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnClearCenturm As Button
    Friend WithEvents btnClearSubafdeling As Button
    Friend WithEvents btnClearMerk As Button
    Friend WithEvents btnBereken As Button
    Friend WithEvents cbbCentrum As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents cbbSubafdeling As ComboBox
    Friend WithEvents cbbMerk As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents dgvResult As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents cbbOnt As ComboBox
    Friend WithEvents btnClearOnt As Button
    Friend WithEvents cbbValtTussen As ComboBox
    Friend WithEvents LblPercBereik As Label
    Friend WithEvents cbbMaand As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents btnClearMaand As Button
    Friend WithEvents dgvExtraInfo As DataGridView
End Class
