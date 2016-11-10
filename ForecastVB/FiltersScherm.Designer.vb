<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FiltersScherm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FiltersScherm))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lsvFilter = New System.Windows.Forms.ListView()
        Me.txtOmschrijving = New System.Windows.Forms.TextBox()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnRemove = New System.Windows.Forms.Button()
        Me.cbbKolom = New System.Windows.Forms.ComboBox()
        Me.cbbFactor = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnOpen = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtFileName = New System.Windows.Forms.TextBox()
        Me.cbbFilterFiles = New System.Windows.Forms.ComboBox()
        Me.btnRemoveFilter = New System.Windows.Forms.Button()
        Me.btnAddNewList = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 78)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Filters lijst"
        '
        'lsvFilter
        '
        Me.lsvFilter.FullRowSelect = True
        Me.lsvFilter.Location = New System.Drawing.Point(11, 94)
        Me.lsvFilter.Name = "lsvFilter"
        Me.lsvFilter.Size = New System.Drawing.Size(612, 114)
        Me.lsvFilter.TabIndex = 3
        Me.lsvFilter.UseCompatibleStateImageBehavior = False
        Me.lsvFilter.View = System.Windows.Forms.View.Details
        '
        'txtOmschrijving
        '
        Me.txtOmschrijving.Location = New System.Drawing.Point(423, 214)
        Me.txtOmschrijving.Name = "txtOmschrijving"
        Me.txtOmschrijving.Size = New System.Drawing.Size(200, 20)
        Me.txtOmschrijving.TabIndex = 6
        '
        'btnAdd
        '
        Me.btnAdd.Image = Global.ForecastVB.My.Resources.Resources._1476715277_add
        Me.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAdd.Location = New System.Drawing.Point(488, 240)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(135, 40)
        Me.btnAdd.TabIndex = 7
        Me.btnAdd.Text = "Filter toevoegen"
        Me.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnRemove
        '
        Me.btnRemove.Image = Global.ForecastVB.My.Resources.Resources._1476721606_Close
        Me.btnRemove.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRemove.Location = New System.Drawing.Point(367, 240)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(115, 40)
        Me.btnRemove.TabIndex = 8
        Me.btnRemove.Text = "Verwijder filter"
        Me.btnRemove.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnRemove.UseVisualStyleBackColor = True
        '
        'cbbKolom
        '
        Me.cbbKolom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbbKolom.FormattingEnabled = True
        Me.cbbKolom.Location = New System.Drawing.Point(11, 214)
        Me.cbbKolom.Name = "cbbKolom"
        Me.cbbKolom.Size = New System.Drawing.Size(250, 21)
        Me.cbbKolom.TabIndex = 9
        '
        'cbbFactor
        '
        Me.cbbFactor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbbFactor.FormattingEnabled = True
        Me.cbbFactor.Location = New System.Drawing.Point(268, 213)
        Me.cbbFactor.Name = "cbbFactor"
        Me.cbbFactor.Size = New System.Drawing.Size(149, 21)
        Me.cbbFactor.TabIndex = 10
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(392, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(90, 13)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Kies filter bestand"
        '
        'btnOpen
        '
        Me.btnOpen.Image = Global.ForecastVB.My.Resources.Resources._1476715240_BT_folder_file_open
        Me.btnOpen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnOpen.Location = New System.Drawing.Point(11, 11)
        Me.btnOpen.Margin = New System.Windows.Forms.Padding(2)
        Me.btnOpen.Name = "btnOpen"
        Me.btnOpen.Size = New System.Drawing.Size(115, 40)
        Me.btnOpen.TabIndex = 13
        Me.btnOpen.Text = "Open filterfile"
        Me.btnOpen.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnOpen.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnOpen.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Image = Global.ForecastVB.My.Resources.Resources._1476715262_multimedia_27
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSave.Location = New System.Drawing.Point(488, 285)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(2)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(135, 40)
        Me.btnSave.TabIndex = 14
        Me.btnSave.Text = "Lijst opslaan"
        Me.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 299)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 13)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Naam"
        '
        'txtFileName
        '
        Me.txtFileName.Location = New System.Drawing.Point(53, 296)
        Me.txtFileName.Name = "txtFileName"
        Me.txtFileName.Size = New System.Drawing.Size(429, 20)
        Me.txtFileName.TabIndex = 16
        '
        'cbbFilterFiles
        '
        Me.cbbFilterFiles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbbFilterFiles.FormattingEnabled = True
        Me.cbbFilterFiles.Location = New System.Drawing.Point(488, 22)
        Me.cbbFilterFiles.Name = "cbbFilterFiles"
        Me.cbbFilterFiles.Size = New System.Drawing.Size(135, 21)
        Me.cbbFilterFiles.TabIndex = 17
        '
        'btnRemoveFilter
        '
        Me.btnRemoveFilter.Image = Global.ForecastVB.My.Resources.Resources._1476721606_Close
        Me.btnRemoveFilter.Location = New System.Drawing.Point(252, 11)
        Me.btnRemoveFilter.Name = "btnRemoveFilter"
        Me.btnRemoveFilter.Size = New System.Drawing.Size(134, 40)
        Me.btnRemoveFilter.TabIndex = 18
        Me.btnRemoveFilter.Text = "Verwijder filterfile"
        Me.btnRemoveFilter.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnRemoveFilter.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnRemoveFilter.UseVisualStyleBackColor = True
        '
        'btnAddNewList
        '
        Me.btnAddNewList.Image = Global.ForecastVB.My.Resources.Resources._1476715277_add
        Me.btnAddNewList.Location = New System.Drawing.Point(131, 11)
        Me.btnAddNewList.Name = "btnAddNewList"
        Me.btnAddNewList.Size = New System.Drawing.Size(115, 40)
        Me.btnAddNewList.TabIndex = 18
        Me.btnAddNewList.Text = "Nieuw filterfile"
        Me.btnAddNewList.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAddNewList.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnAddNewList.UseVisualStyleBackColor = True
        '
        'Settings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(635, 334)
        Me.Controls.Add(Me.btnAddNewList)
        Me.Controls.Add(Me.btnRemoveFilter)
        Me.Controls.Add(Me.cbbFilterFiles)
        Me.Controls.Add(Me.txtFileName)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnOpen)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cbbFactor)
        Me.Controls.Add(Me.cbbKolom)
        Me.Controls.Add(Me.btnRemove)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.txtOmschrijving)
        Me.Controls.Add(Me.lsvFilter)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
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
    Friend WithEvents Label2 As Label
    Friend WithEvents btnOpen As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents Label3 As Label
    Friend WithEvents txtFileName As TextBox
    Friend WithEvents cbbFilterFiles As ComboBox
    Friend WithEvents btnRemoveFilter As Button
    Friend WithEvents btnAddNewList As Button
End Class
