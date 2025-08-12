<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LoginForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub
    Friend WithEvents LogoPictureBox As System.Windows.Forms.PictureBox

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.txtpassword = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmdcancel = New System.Windows.Forms.Button
        Me.txtusername = New System.Windows.Forms.TextBox
        Me.lblgroup = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.BlendPanel1 = New VbPowerPack.BlendPanel
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.LogoPictureBox = New System.Windows.Forms.PictureBox
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.cmdok = New System.Windows.Forms.Button
        Me.EP = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.BlendPanel1.SuspendLayout()
        CType(Me.LogoPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtpassword
        '
        Me.txtpassword.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtpassword.Location = New System.Drawing.Point(213, 58)
        Me.txtpassword.MaxLength = 8
        Me.txtpassword.Name = "txtpassword"
        Me.txtpassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtpassword.Size = New System.Drawing.Size(124, 22)
        Me.txtpassword.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(152, 61)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 14)
        Me.Label4.TabIndex = 93
        Me.Label4.Text = "Password"
        '
        'cmdcancel
        '
        Me.cmdcancel.FlatAppearance.BorderSize = 0
        Me.cmdcancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdcancel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdcancel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdcancel.Image = Global.Magic_Gold.My.Resources.Resources._Exit
        Me.cmdcancel.Location = New System.Drawing.Point(288, 86)
        Me.cmdcancel.Name = "cmdcancel"
        Me.cmdcancel.Size = New System.Drawing.Size(64, 26)
        Me.cmdcancel.TabIndex = 3
        Me.cmdcancel.UseVisualStyleBackColor = True
        '
        'txtusername
        '
        Me.txtusername.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtusername.Location = New System.Drawing.Point(213, 30)
        Me.txtusername.Name = "txtusername"
        Me.txtusername.Size = New System.Drawing.Size(124, 22)
        Me.txtusername.TabIndex = 0
        '
        'lblgroup
        '
        Me.lblgroup.AutoSize = True
        Me.lblgroup.BackColor = System.Drawing.Color.Transparent
        Me.lblgroup.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblgroup.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblgroup.Location = New System.Drawing.Point(141, 33)
        Me.lblgroup.Name = "lblgroup"
        Me.lblgroup.Size = New System.Drawing.Size(70, 14)
        Me.lblgroup.TabIndex = 92
        Me.lblgroup.Text = "User Name "
        Me.lblgroup.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(142, 6)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 17)
        Me.Label2.TabIndex = 197
        Me.Label2.Text = "Login"
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.Label6)
        Me.BlendPanel1.Controls.Add(Me.Label5)
        Me.BlendPanel1.Controls.Add(Me.Label3)
        Me.BlendPanel1.Controls.Add(Me.cmdcancel)
        Me.BlendPanel1.Controls.Add(Me.Label2)
        Me.BlendPanel1.Controls.Add(Me.LogoPictureBox)
        Me.BlendPanel1.Controls.Add(Me.PictureBox2)
        Me.BlendPanel1.Controls.Add(Me.lblgroup)
        Me.BlendPanel1.Controls.Add(Me.txtpassword)
        Me.BlendPanel1.Controls.Add(Me.txtusername)
        Me.BlendPanel1.Controls.Add(Me.Label4)
        Me.BlendPanel1.Controls.Add(Me.cmdok)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(358, 183)
        Me.BlendPanel1.TabIndex = 198
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.SlateGray
        Me.Label6.Location = New System.Drawing.Point(142, 159)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(137, 14)
        Me.Label6.TabIndex = 203
        Me.Label6.Text = "Nakoda Infotech Pvt Ltd."
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.SlateGray
        Me.Label5.Location = New System.Drawing.Point(142, 140)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(134, 14)
        Me.Label5.TabIndex = 202
        Me.Label5.Text = "Copyright (c) 2010 - 2013"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.SlateGray
        Me.Label3.Location = New System.Drawing.Point(142, 121)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(151, 14)
        Me.Label3.TabIndex = 201
        Me.Label3.Text = "Manufacturing Application"
        '
        'LogoPictureBox
        '
        Me.LogoPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.LogoPictureBox.Image = Global.Magic_Gold.My.Resources.Resources.key
        Me.LogoPictureBox.Location = New System.Drawing.Point(1, 3)
        Me.LogoPictureBox.Name = "LogoPictureBox"
        Me.LogoPictureBox.Size = New System.Drawing.Size(137, 179)
        Me.LogoPictureBox.TabIndex = 0
        Me.LogoPictureBox.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox2.Image = Global.Magic_Gold.My.Resources.Resources.Close
        Me.PictureBox2.Location = New System.Drawing.Point(336, 6)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(15, 15)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 196
        Me.PictureBox2.TabStop = False
        '
        'cmdok
        '
        Me.cmdok.FlatAppearance.BorderSize = 0
        Me.cmdok.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdok.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdok.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdok.Image = Global.Magic_Gold.My.Resources.Resources.Login
        Me.cmdok.Location = New System.Drawing.Point(213, 87)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(73, 26)
        Me.cmdok.TabIndex = 2
        Me.cmdok.UseVisualStyleBackColor = True
        '
        'EP
        '
        Me.EP.BlinkRate = 0
        Me.EP.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.EP.ContainerControl = Me
        '
        'LoginForm
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(358, 183)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "LoginForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Login"
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.LogoPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtpassword As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmdcancel As System.Windows.Forms.Button
    Friend WithEvents cmdok As System.Windows.Forms.Button
    Friend WithEvents txtusername As System.Windows.Forms.TextBox
    Friend WithEvents lblgroup As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents EP As System.Windows.Forms.ErrorProvider

End Class
