<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EnterPassword
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
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.CMDEXIT = New System.Windows.Forms.Button()
        Me.CMDOK = New System.Windows.Forms.Button()
        Me.TXTPASSWORD = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.BlendPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.CMDEXIT)
        Me.BlendPanel1.Controls.Add(Me.CMDOK)
        Me.BlendPanel1.Controls.Add(Me.TXTPASSWORD)
        Me.BlendPanel1.Controls.Add(Me.Label16)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(342, 108)
        Me.BlendPanel1.TabIndex = 0
        '
        'CMDEXIT
        '
        Me.CMDEXIT.Location = New System.Drawing.Point(174, 57)
        Me.CMDEXIT.Name = "CMDEXIT"
        Me.CMDEXIT.Size = New System.Drawing.Size(80, 28)
        Me.CMDEXIT.TabIndex = 2
        Me.CMDEXIT.Text = "E&xit"
        Me.CMDEXIT.UseVisualStyleBackColor = True
        '
        'CMDOK
        '
        Me.CMDOK.Location = New System.Drawing.Point(88, 57)
        Me.CMDOK.Name = "CMDOK"
        Me.CMDOK.Size = New System.Drawing.Size(80, 28)
        Me.CMDOK.TabIndex = 1
        Me.CMDOK.Text = "&Ok"
        Me.CMDOK.UseVisualStyleBackColor = True
        '
        'TXTPASSWORD
        '
        Me.TXTPASSWORD.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTPASSWORD.Location = New System.Drawing.Point(123, 22)
        Me.TXTPASSWORD.Name = "TXTPASSWORD"
        Me.TXTPASSWORD.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TXTPASSWORD.Size = New System.Drawing.Size(146, 23)
        Me.TXTPASSWORD.TabIndex = 0
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(28, 25)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(92, 15)
        Me.Label16.TabIndex = 355
        Me.Label16.Text = "Enter Password"
        '
        'EnterPassword
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(342, 108)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "EnterPassword"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Enter Password"
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents Label16 As Label
    Friend WithEvents TXTPASSWORD As TextBox
    Friend WithEvents CMDOK As Button
    Friend WithEvents CMDEXIT As Button
End Class
