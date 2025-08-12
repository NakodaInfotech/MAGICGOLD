<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PasswordEntry
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
        Me.BlendPanel1 = New VbPowerPack.BlendPanel
        Me.TXTDATERETYPE = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmdok = New System.Windows.Forms.Button
        Me.BlendPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.TXTDATERETYPE)
        Me.BlendPanel1.Controls.Add(Me.Label1)
        Me.BlendPanel1.Controls.Add(Me.cmdok)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(284, 108)
        Me.BlendPanel1.TabIndex = 0
        '
        'TXTDATERETYPE
        '
        Me.TXTDATERETYPE.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTDATERETYPE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTDATERETYPE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTDATERETYPE.Location = New System.Drawing.Point(138, 21)
        Me.TXTDATERETYPE.MaxLength = 8
        Me.TXTDATERETYPE.Name = "TXTDATERETYPE"
        Me.TXTDATERETYPE.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TXTDATERETYPE.Size = New System.Drawing.Size(105, 22)
        Me.TXTDATERETYPE.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(47, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(90, 14)
        Me.Label1.TabIndex = 385
        Me.Label1.Text = "Enter Password"
        '
        'cmdok
        '
        Me.cmdok.FlatAppearance.BorderSize = 0
        Me.cmdok.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdok.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdok.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdok.Image = Global.Magic_Gold.My.Resources.Resources.ok
        Me.cmdok.Location = New System.Drawing.Point(108, 65)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(68, 26)
        Me.cmdok.TabIndex = 1
        Me.cmdok.UseVisualStyleBackColor = True
        '
        'PasswordEntry
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(284, 108)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "PasswordEntry"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Entry Password"
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents cmdok As System.Windows.Forms.Button
    Friend WithEvents TXTDATERETYPE As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
