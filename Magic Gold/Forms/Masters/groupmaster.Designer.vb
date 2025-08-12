<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class groupmaster
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(groupmaster))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.chkchange = New System.Windows.Forms.CheckBox
        Me.cmddelete = New System.Windows.Forms.Button
        Me.cmbgrouptype = New System.Windows.Forms.ComboBox
        Me.cmbunder = New System.Windows.Forms.ComboBox
        Me.lblunder = New System.Windows.Forms.Label
        Me.cmdedit = New System.Windows.Forms.Button
        Me.lbl = New System.Windows.Forms.Label
        Me.cmdexit = New System.Windows.Forms.Button
        Me.cmdok = New System.Windows.Forms.Button
        Me.txtgroupname = New System.Windows.Forms.TextBox
        Me.lblgroup = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.chkchange)
        Me.GroupBox1.Controls.Add(Me.cmddelete)
        Me.GroupBox1.Controls.Add(Me.cmbgrouptype)
        Me.GroupBox1.Controls.Add(Me.cmbunder)
        Me.GroupBox1.Controls.Add(Me.lblunder)
        Me.GroupBox1.Controls.Add(Me.cmdedit)
        Me.GroupBox1.Controls.Add(Me.lbl)
        Me.GroupBox1.Controls.Add(Me.cmdexit)
        Me.GroupBox1.Controls.Add(Me.cmdok)
        Me.GroupBox1.Controls.Add(Me.txtgroupname)
        Me.GroupBox1.Controls.Add(Me.lblgroup)
        Me.GroupBox1.Location = New System.Drawing.Point(-1, -2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(324, 122)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'chkchange
        '
        Me.chkchange.AutoSize = True
        Me.chkchange.Location = New System.Drawing.Point(278, 102)
        Me.chkchange.Name = "chkchange"
        Me.chkchange.Size = New System.Drawing.Size(15, 14)
        Me.chkchange.TabIndex = 138
        Me.chkchange.UseVisualStyleBackColor = True
        Me.chkchange.Visible = False
        '
        'cmddelete
        '
        Me.cmddelete.BackgroundImage = Global.Magic_Gold.My.Resources.Resources.WASTE
        Me.cmddelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.cmddelete.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmddelete.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmddelete.Location = New System.Drawing.Point(216, 16)
        Me.cmddelete.Name = "cmddelete"
        Me.cmddelete.Size = New System.Drawing.Size(28, 23)
        Me.cmddelete.TabIndex = 129
        Me.cmddelete.UseVisualStyleBackColor = True
        Me.cmddelete.Visible = False
        '
        'cmbgrouptype
        '
        Me.cmbgrouptype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbgrouptype.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbgrouptype.FormattingEnabled = True
        Me.cmbgrouptype.Location = New System.Drawing.Point(138, 70)
        Me.cmbgrouptype.MaxDropDownItems = 14
        Me.cmbgrouptype.Name = "cmbgrouptype"
        Me.cmbgrouptype.Size = New System.Drawing.Size(75, 22)
        Me.cmbgrouptype.TabIndex = 128
        Me.cmbgrouptype.Visible = False
        '
        'cmbunder
        '
        Me.cmbunder.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbunder.FormattingEnabled = True
        Me.cmbunder.Location = New System.Drawing.Point(77, 43)
        Me.cmbunder.Name = "cmbunder"
        Me.cmbunder.Size = New System.Drawing.Size(136, 22)
        Me.cmbunder.TabIndex = 1
        '
        'lblunder
        '
        Me.lblunder.AutoSize = True
        Me.lblunder.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblunder.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblunder.Location = New System.Drawing.Point(40, 51)
        Me.lblunder.Name = "lblunder"
        Me.lblunder.Size = New System.Drawing.Size(36, 14)
        Me.lblunder.TabIndex = 127
        Me.lblunder.Text = "Under"
        '
        'cmdedit
        '
        Me.cmdedit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdedit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdedit.Location = New System.Drawing.Point(250, 75)
        Me.cmdedit.Name = "cmdedit"
        Me.cmdedit.Size = New System.Drawing.Size(67, 24)
        Me.cmdedit.TabIndex = 77
        Me.cmdedit.Text = "&Edit"
        Me.cmdedit.UseVisualStyleBackColor = True
        Me.cmdedit.Visible = False
        '
        'lbl
        '
        Me.lbl.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbl.Location = New System.Drawing.Point(6, 81)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(200, 44)
        Me.lbl.TabIndex = 76
        Me.lbl.Text = "Enter Group Name                         (e.g.  Debtor,Creditor..., etc. )"
        '
        'cmdexit
        '
        Me.cmdexit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdexit.Location = New System.Drawing.Point(250, 45)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(67, 24)
        Me.cmdexit.TabIndex = 3
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = True
        '
        'cmdok
        '
        Me.cmdok.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdok.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdok.Location = New System.Drawing.Point(250, 15)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(67, 24)
        Me.cmdok.TabIndex = 2
        Me.cmdok.Text = "&Save"
        Me.cmdok.UseVisualStyleBackColor = True
        '
        'txtgroupname
        '
        Me.txtgroupname.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtgroupname.Location = New System.Drawing.Point(77, 17)
        Me.txtgroupname.Name = "txtgroupname"
        Me.txtgroupname.Size = New System.Drawing.Size(136, 20)
        Me.txtgroupname.TabIndex = 0
        '
        'lblgroup
        '
        Me.lblgroup.AutoSize = True
        Me.lblgroup.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblgroup.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblgroup.Location = New System.Drawing.Point(9, 23)
        Me.lblgroup.Name = "lblgroup"
        Me.lblgroup.Size = New System.Drawing.Size(67, 14)
        Me.lblgroup.TabIndex = 75
        Me.lblgroup.Text = "Group Name"
        Me.lblgroup.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'groupmaster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.BackgroundImage = Global.Magic_Gold.My.Resources.Resources.lgn_pnl
        Me.ClientSize = New System.Drawing.Size(324, 122)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MinimumSize = New System.Drawing.Size(305, 134)
        Me.Name = "groupmaster"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "New Group"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents cmdok As System.Windows.Forms.Button
    Friend WithEvents txtgroupname As System.Windows.Forms.TextBox
    Friend WithEvents lblgroup As System.Windows.Forms.Label
    Friend WithEvents lbl As System.Windows.Forms.Label
    Friend WithEvents cmdedit As System.Windows.Forms.Button
    Friend WithEvents cmbgrouptype As System.Windows.Forms.ComboBox
    Friend WithEvents cmbunder As System.Windows.Forms.ComboBox
    Friend WithEvents lblunder As System.Windows.Forms.Label
    Friend WithEvents cmddelete As System.Windows.Forms.Button
    Friend WithEvents chkchange As System.Windows.Forms.CheckBox
End Class
