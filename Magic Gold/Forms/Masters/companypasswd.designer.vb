<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class companypasswd
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cmdback = New System.Windows.Forms.Button
        Me.cmdnext = New System.Windows.Forms.Button
        Me.txtretypepassword = New System.Windows.Forms.TextBox
        Me.lblretype = New System.Windows.Forms.Label
        Me.txtpassword = New System.Windows.Forms.TextBox
        Me.lblgroup = New System.Windows.Forms.Label
        Me.lbl = New System.Windows.Forms.Label
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Location = New System.Drawing.Point(4, 28)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(281, 120)
        Me.GroupBox1.TabIndex = 161
        Me.GroupBox1.TabStop = False
        '
        'cmdback
        '
        Me.cmdback.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdback.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdback.Location = New System.Drawing.Point(109, 113)
        Me.cmdback.Name = "cmdback"
        Me.cmdback.Size = New System.Drawing.Size(80, 26)
        Me.cmdback.TabIndex = 3
        Me.cmdback.Text = "< &Back"
        Me.cmdback.UseVisualStyleBackColor = True
        '
        'cmdnext
        '
        Me.cmdnext.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdnext.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdnext.Location = New System.Drawing.Point(195, 113)
        Me.cmdnext.Name = "cmdnext"
        Me.cmdnext.Size = New System.Drawing.Size(80, 26)
        Me.cmdnext.TabIndex = 2
        Me.cmdnext.Text = "&Next >"
        Me.cmdnext.UseVisualStyleBackColor = True
        '
        'txtretypepassword
        '
        Me.txtretypepassword.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtretypepassword.Location = New System.Drawing.Point(130, 80)
        Me.txtretypepassword.MaxLength = 8
        Me.txtretypepassword.Name = "txtretypepassword"
        Me.txtretypepassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtretypepassword.Size = New System.Drawing.Size(129, 22)
        Me.txtretypepassword.TabIndex = 1
        '
        'lblretype
        '
        Me.lblretype.AutoSize = True
        Me.lblretype.BackColor = System.Drawing.Color.Transparent
        Me.lblretype.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblretype.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblretype.Location = New System.Drawing.Point(25, 84)
        Me.lblretype.Name = "lblretype"
        Me.lblretype.Size = New System.Drawing.Size(104, 14)
        Me.lblretype.TabIndex = 164
        Me.lblretype.Text = "Re-Type Password"
        '
        'txtpassword
        '
        Me.txtpassword.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtpassword.Location = New System.Drawing.Point(130, 51)
        Me.txtpassword.MaxLength = 8
        Me.txtpassword.Name = "txtpassword"
        Me.txtpassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtpassword.Size = New System.Drawing.Size(129, 22)
        Me.txtpassword.TabIndex = 0
        '
        'lblgroup
        '
        Me.lblgroup.AutoSize = True
        Me.lblgroup.BackColor = System.Drawing.Color.Transparent
        Me.lblgroup.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblgroup.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblgroup.Location = New System.Drawing.Point(30, 55)
        Me.lblgroup.Name = "lblgroup"
        Me.lblgroup.Size = New System.Drawing.Size(98, 14)
        Me.lblgroup.TabIndex = 163
        Me.lblgroup.Text = "Access Password"
        Me.lblgroup.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl
        '
        Me.lbl.BackColor = System.Drawing.Color.Transparent
        Me.lbl.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbl.Location = New System.Drawing.Point(1, 10)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(258, 22)
        Me.lbl.TabIndex = 168
        Me.lbl.Text = "Enter Password Used To Access Company"
        '
        'PictureBox2
        '
        Me.PictureBox2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox2.Image = Global.Magic_Gold.My.Resources.Resources.Close
        Me.PictureBox2.Location = New System.Drawing.Point(271, 3)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(13, 13)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 196
        Me.PictureBox2.TabStop = False
        '
        'companypasswd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(290, 152)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.lbl)
        Me.Controls.Add(Me.cmdback)
        Me.Controls.Add(Me.cmdnext)
        Me.Controls.Add(Me.txtretypepassword)
        Me.Controls.Add(Me.lblretype)
        Me.Controls.Add(Me.txtpassword)
        Me.Controls.Add(Me.lblgroup)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "companypasswd"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Password For Company"
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdback As System.Windows.Forms.Button
    Friend WithEvents cmdnext As System.Windows.Forms.Button
    Friend WithEvents txtretypepassword As System.Windows.Forms.TextBox
    Friend WithEvents lblretype As System.Windows.Forms.Label
    Friend WithEvents txtpassword As System.Windows.Forms.TextBox
    Friend WithEvents lblgroup As System.Windows.Forms.Label
    Friend WithEvents lbl As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
End Class
