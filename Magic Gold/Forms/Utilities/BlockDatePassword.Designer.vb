<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BlockDatePassword
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
        Me.components = New System.ComponentModel.Container
        Me.BlendPanel1 = New VbPowerPack.BlendPanel
        Me.TXTOLDDATEPASS = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.TXTOLDENTRYPASS = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.TXTENTRYRETYPE = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.TXTENTRYPASS = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.TXTDATERETYPE = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.TXTDATEPASS = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmdexit = New System.Windows.Forms.Button
        Me.cmdok = New System.Windows.Forms.Button
        Me.EP = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.BlendPanel1.SuspendLayout()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.TXTOLDDATEPASS)
        Me.BlendPanel1.Controls.Add(Me.Label6)
        Me.BlendPanel1.Controls.Add(Me.TXTOLDENTRYPASS)
        Me.BlendPanel1.Controls.Add(Me.Label5)
        Me.BlendPanel1.Controls.Add(Me.TXTENTRYRETYPE)
        Me.BlendPanel1.Controls.Add(Me.Label2)
        Me.BlendPanel1.Controls.Add(Me.TXTENTRYPASS)
        Me.BlendPanel1.Controls.Add(Me.Label3)
        Me.BlendPanel1.Controls.Add(Me.TXTDATERETYPE)
        Me.BlendPanel1.Controls.Add(Me.Label1)
        Me.BlendPanel1.Controls.Add(Me.TXTDATEPASS)
        Me.BlendPanel1.Controls.Add(Me.Label4)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.cmdok)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(284, 242)
        Me.BlendPanel1.TabIndex = 0
        '
        'TXTOLDDATEPASS
        '
        Me.TXTOLDDATEPASS.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTOLDDATEPASS.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTOLDDATEPASS.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTOLDDATEPASS.Location = New System.Drawing.Point(156, 13)
        Me.TXTOLDDATEPASS.MaxLength = 8
        Me.TXTOLDDATEPASS.Name = "TXTOLDDATEPASS"
        Me.TXTOLDDATEPASS.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TXTOLDDATEPASS.Size = New System.Drawing.Size(105, 22)
        Me.TXTOLDDATEPASS.TabIndex = 0
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(73, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(81, 14)
        Me.Label6.TabIndex = 391
        Me.Label6.Text = "Old Password"
        '
        'TXTOLDENTRYPASS
        '
        Me.TXTOLDENTRYPASS.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTOLDENTRYPASS.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTOLDENTRYPASS.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTOLDENTRYPASS.Location = New System.Drawing.Point(156, 114)
        Me.TXTOLDENTRYPASS.MaxLength = 8
        Me.TXTOLDENTRYPASS.Name = "TXTOLDENTRYPASS"
        Me.TXTOLDENTRYPASS.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TXTOLDENTRYPASS.Size = New System.Drawing.Size(105, 22)
        Me.TXTOLDENTRYPASS.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(73, 117)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(81, 14)
        Me.Label5.TabIndex = 389
        Me.Label5.Text = "Old Password"
        '
        'TXTENTRYRETYPE
        '
        Me.TXTENTRYRETYPE.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTENTRYRETYPE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTENTRYRETYPE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTENTRYRETYPE.Location = New System.Drawing.Point(156, 170)
        Me.TXTENTRYRETYPE.MaxLength = 8
        Me.TXTENTRYRETYPE.Name = "TXTENTRYRETYPE"
        Me.TXTENTRYRETYPE.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TXTENTRYRETYPE.Size = New System.Drawing.Size(105, 22)
        Me.TXTENTRYRETYPE.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(55, 173)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(99, 14)
        Me.Label2.TabIndex = 387
        Me.Label2.Text = "Retype Password"
        '
        'TXTENTRYPASS
        '
        Me.TXTENTRYPASS.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTENTRYPASS.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTENTRYPASS.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTENTRYPASS.Location = New System.Drawing.Point(156, 142)
        Me.TXTENTRYPASS.MaxLength = 8
        Me.TXTENTRYPASS.Name = "TXTENTRYPASS"
        Me.TXTENTRYPASS.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TXTENTRYPASS.Size = New System.Drawing.Size(105, 22)
        Me.TXTENTRYPASS.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(23, 145)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(131, 14)
        Me.Label3.TabIndex = 385
        Me.Label3.Text = "Entry Change Password"
        '
        'TXTDATERETYPE
        '
        Me.TXTDATERETYPE.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTDATERETYPE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTDATERETYPE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTDATERETYPE.Location = New System.Drawing.Point(156, 69)
        Me.TXTDATERETYPE.MaxLength = 8
        Me.TXTDATERETYPE.Name = "TXTDATERETYPE"
        Me.TXTDATERETYPE.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TXTDATERETYPE.Size = New System.Drawing.Size(105, 22)
        Me.TXTDATERETYPE.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(55, 72)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(99, 14)
        Me.Label1.TabIndex = 383
        Me.Label1.Text = "Retype Password"
        '
        'TXTDATEPASS
        '
        Me.TXTDATEPASS.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTDATEPASS.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTDATEPASS.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTDATEPASS.Location = New System.Drawing.Point(156, 41)
        Me.TXTDATEPASS.MaxLength = 8
        Me.TXTDATEPASS.Name = "TXTDATEPASS"
        Me.TXTDATEPASS.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TXTDATEPASS.Size = New System.Drawing.Size(105, 22)
        Me.TXTDATEPASS.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(23, 44)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(131, 14)
        Me.Label4.TabIndex = 381
        Me.Label4.Text = "Date Change Password"
        '
        'cmdexit
        '
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdexit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdexit.Image = Global.Magic_Gold.My.Resources.Resources._Exit
        Me.cmdexit.Location = New System.Drawing.Point(143, 204)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(68, 26)
        Me.cmdexit.TabIndex = 7
        Me.cmdexit.UseVisualStyleBackColor = True
        '
        'cmdok
        '
        Me.cmdok.FlatAppearance.BorderSize = 0
        Me.cmdok.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdok.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdok.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdok.Image = Global.Magic_Gold.My.Resources.Resources.ok
        Me.cmdok.Location = New System.Drawing.Point(73, 202)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(68, 26)
        Me.cmdok.TabIndex = 6
        Me.cmdok.UseVisualStyleBackColor = True
        '
        'EP
        '
        Me.EP.BlinkRate = 0
        Me.EP.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.EP.ContainerControl = Me
        '
        'BlockDatePassword
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(284, 242)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "BlockDatePassword"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Block Date Password"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents cmdok As System.Windows.Forms.Button
    Friend WithEvents TXTDATEPASS As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TXTDATERETYPE As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TXTENTRYRETYPE As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TXTENTRYPASS As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TXTOLDDATEPASS As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TXTOLDENTRYPASS As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents EP As System.Windows.Forms.ErrorProvider
End Class
