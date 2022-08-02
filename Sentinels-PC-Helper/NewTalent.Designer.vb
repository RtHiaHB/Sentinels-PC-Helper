<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NewTalent
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
        Me.TalentDie = New System.Windows.Forms.ComboBox()
        Me.TalentName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.OKBtn = New System.Windows.Forms.Button()
        Me.CancelBtn = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'TalentDie
        '
        Me.TalentDie.FormattingEnabled = True
        Me.TalentDie.Items.AddRange(New Object() {"d4", "d6", "d8", "d10", "d12"})
        Me.TalentDie.Location = New System.Drawing.Point(65, 74)
        Me.TalentDie.Name = "TalentDie"
        Me.TalentDie.Size = New System.Drawing.Size(250, 24)
        Me.TalentDie.TabIndex = 1
        '
        'TalentName
        '
        Me.TalentName.Location = New System.Drawing.Point(65, 31)
        Me.TalentName.Name = "TalentName"
        Me.TalentName.Size = New System.Drawing.Size(250, 22)
        Me.TalentName.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 17)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Name"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(30, 77)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 17)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Die"
        '
        'OKBtn
        '
        Me.OKBtn.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.OKBtn.Location = New System.Drawing.Point(166, 120)
        Me.OKBtn.Name = "OKBtn"
        Me.OKBtn.Size = New System.Drawing.Size(78, 37)
        Me.OKBtn.TabIndex = 4
        Me.OKBtn.Text = "&OK"
        Me.OKBtn.UseVisualStyleBackColor = True
        '
        'CancelBtn
        '
        Me.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CancelBtn.Location = New System.Drawing.Point(250, 120)
        Me.CancelBtn.Name = "CancelBtn"
        Me.CancelBtn.Size = New System.Drawing.Size(78, 37)
        Me.CancelBtn.TabIndex = 5
        Me.CancelBtn.Text = "Cancel"
        Me.CancelBtn.UseVisualStyleBackColor = True
        '
        'NewTalent
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(356, 169)
        Me.Controls.Add(Me.CancelBtn)
        Me.Controls.Add(Me.OKBtn)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TalentName)
        Me.Controls.Add(Me.TalentDie)
        Me.Name = "NewTalent"
        Me.Text = "Add Talent"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TalentDie As ComboBox
    Friend WithEvents TalentName As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents OKBtn As Button
    Friend WithEvents CancelBtn As Button
End Class
