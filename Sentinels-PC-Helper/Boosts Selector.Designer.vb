<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Boosts_Selector
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BoostHinderLvl = New System.Windows.Forms.NumericUpDown()
        Me.PersistentChk = New System.Windows.Forms.CheckBox()
        Me.OKBtn = New System.Windows.Forms.Button()
        Me.CancelBtn = New System.Windows.Forms.Button()
        CType(Me.BoostHinderLvl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 11)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(218, 29)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Boost/Hinder Level"
        '
        'BoostHinderLvl
        '
        Me.BoostHinderLvl.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BoostHinderLvl.Location = New System.Drawing.Point(288, 9)
        Me.BoostHinderLvl.Margin = New System.Windows.Forms.Padding(4)
        Me.BoostHinderLvl.Maximum = New Decimal(New Integer() {5, 0, 0, 0})
        Me.BoostHinderLvl.Minimum = New Decimal(New Integer() {5, 0, 0, -2147483648})
        Me.BoostHinderLvl.Name = "BoostHinderLvl"
        Me.BoostHinderLvl.Size = New System.Drawing.Size(73, 34)
        Me.BoostHinderLvl.TabIndex = 1
        Me.BoostHinderLvl.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'PersistentChk
        '
        Me.PersistentChk.AutoSize = True
        Me.PersistentChk.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PersistentChk.Location = New System.Drawing.Point(73, 65)
        Me.PersistentChk.Margin = New System.Windows.Forms.Padding(4)
        Me.PersistentChk.Name = "PersistentChk"
        Me.PersistentChk.Size = New System.Drawing.Size(142, 33)
        Me.PersistentChk.TabIndex = 2
        Me.PersistentChk.Text = "Persistent"
        Me.PersistentChk.UseVisualStyleBackColor = True
        '
        'OKBtn
        '
        Me.OKBtn.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.OKBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OKBtn.Location = New System.Drawing.Point(149, 107)
        Me.OKBtn.Margin = New System.Windows.Forms.Padding(4)
        Me.OKBtn.Name = "OKBtn"
        Me.OKBtn.Size = New System.Drawing.Size(116, 42)
        Me.OKBtn.TabIndex = 3
        Me.OKBtn.Text = "&OK"
        Me.OKBtn.UseVisualStyleBackColor = True
        '
        'CancelBtn
        '
        Me.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CancelBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CancelBtn.Location = New System.Drawing.Point(273, 107)
        Me.CancelBtn.Margin = New System.Windows.Forms.Padding(4)
        Me.CancelBtn.Name = "CancelBtn"
        Me.CancelBtn.Size = New System.Drawing.Size(116, 42)
        Me.CancelBtn.TabIndex = 4
        Me.CancelBtn.Text = "&Cancel"
        Me.CancelBtn.UseVisualStyleBackColor = True
        '
        'Boosts_Selector
        '
        Me.AcceptButton = Me.OKBtn
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.CancelBtn
        Me.ClientSize = New System.Drawing.Size(405, 164)
        Me.ControlBox = False
        Me.Controls.Add(Me.CancelBtn)
        Me.Controls.Add(Me.OKBtn)
        Me.Controls.Add(Me.PersistentChk)
        Me.Controls.Add(Me.BoostHinderLvl)
        Me.Controls.Add(Me.Label1)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Boosts_Selector"
        Me.ShowInTaskbar = False
        Me.Text = "Boost/Hinder"
        Me.TopMost = True
        CType(Me.BoostHinderLvl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents BoostHinderLvl As NumericUpDown
    Friend WithEvents PersistentChk As CheckBox
    Friend WithEvents OKBtn As Button
    Friend WithEvents CancelBtn As Button
End Class
