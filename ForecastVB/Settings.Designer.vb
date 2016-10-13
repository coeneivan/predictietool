<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Settings
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lsvFilter = New System.Windows.Forms.ListView()
        Me.txtOmschrijving = New System.Windows.Forms.TextBox()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnRemove = New System.Windows.Forms.Button()
        Me.cbbKolom = New System.Windows.Forms.ComboBox()
        Me.cbbFactor = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(170, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "SQL waarop gefilterd moet worden"
        '
        'lsvFilter
        '
        Me.lsvFilter.FullRowSelect = True
        Me.lsvFilter.Location = New System.Drawing.Point(12, 29)
        Me.lsvFilter.Name = "lsvFilter"
        Me.lsvFilter.Size = New System.Drawing.Size(612, 126)
        Me.lsvFilter.TabIndex = 3
        Me.lsvFilter.UseCompatibleStateImageBehavior = False
        Me.lsvFilter.View = System.Windows.Forms.View.Details
        '
        'txtOmschrijving
        '
        Me.txtOmschrijving.Location = New System.Drawing.Point(424, 161)
        Me.txtOmschrijving.Name = "txtOmschrijving"
        Me.txtOmschrijving.Size = New System.Drawing.Size(200, 20)
        Me.txtOmschrijving.TabIndex = 6
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(548, 187)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(75, 23)
        Me.btnAdd.TabIndex = 7
        Me.btnAdd.Text = "Toevoegen"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnRemove
        '
        Me.btnRemove.Location = New System.Drawing.Point(12, 187)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(75, 23)
        Me.btnRemove.TabIndex = 8
        Me.btnRemove.Text = "Verwijderen"
        Me.btnRemove.UseVisualStyleBackColor = True
        '
        'cbbKolom
        '
        Me.cbbKolom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbbKolom.FormattingEnabled = True
        Me.cbbKolom.Location = New System.Drawing.Point(12, 161)
        Me.cbbKolom.Name = "cbbKolom"
        Me.cbbKolom.Size = New System.Drawing.Size(250, 21)
        Me.cbbKolom.TabIndex = 9
        '
        'cbbFactor
        '
        Me.cbbFactor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbbFactor.FormattingEnabled = True
        Me.cbbFactor.Location = New System.Drawing.Point(269, 160)
        Me.cbbFactor.Name = "cbbFactor"
        Me.cbbFactor.Size = New System.Drawing.Size(149, 21)
        Me.cbbFactor.TabIndex = 10
        '
        'Settings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(635, 215)
        Me.Controls.Add(Me.cbbFactor)
        Me.Controls.Add(Me.cbbKolom)
        Me.Controls.Add(Me.btnRemove)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.txtOmschrijving)
        Me.Controls.Add(Me.lsvFilter)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "Settings"
        Me.Text = "Settings"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents lsvFilter As ListView
    Friend WithEvents txtOmschrijving As TextBox
    Friend WithEvents btnAdd As Button
    Friend WithEvents btnRemove As Button
    Friend WithEvents cbbKolom As ComboBox
    Friend WithEvents cbbFactor As ComboBox
End Class
