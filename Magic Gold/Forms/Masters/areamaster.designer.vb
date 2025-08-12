<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class areamaster
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(areamaster))
        Me.cmdedit = New System.Windows.Forms.Button()
        Me.lbl = New System.Windows.Forms.Label()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.cmdok = New System.Windows.Forms.Button()
        Me.txtname = New System.Windows.Forms.TextBox()
        Me.lblgroup = New System.Windows.Forms.Label()
        Me.cmddelete = New System.Windows.Forms.Button()
        Me.chkchange = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'cmdedit
        '
        Me.cmdedit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdedit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdedit.Location = New System.Drawing.Point(221, 65)
        Me.cmdedit.Name = "cmdedit"
        Me.cmdedit.Size = New System.Drawing.Size(67, 24)
        Me.cmdedit.TabIndex = 83
        Me.cmdedit.Text = "&Edit"
        Me.cmdedit.UseVisualStyleBackColor = True
        Me.cmdedit.Visible = False
        '
        'lbl
        '
        Me.lbl.BackColor = System.Drawing.Color.Transparent
        Me.lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbl.Location = New System.Drawing.Point(16, 40)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(197, 44)
        Me.lbl.TabIndex = 82
        Me.lbl.Text = "Enter Area                                            (e.g.  Kalbadevi,Santacruz." &
    ".., etc. )"
        '
        'cmdexit
        '
        Me.cmdexit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdexit.Location = New System.Drawing.Point(221, 35)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(67, 24)
        Me.cmdexit.TabIndex = 2
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = True
        '
        'cmdok
        '
        Me.cmdok.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdok.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdok.Location = New System.Drawing.Point(221, 5)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(67, 24)
        Me.cmdok.TabIndex = 1
        Me.cmdok.Text = "&Save"
        Me.cmdok.UseVisualStyleBackColor = True
        '
        'txtname
        '
        Me.txtname.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtname.Location = New System.Drawing.Point(50, 9)
        Me.txtname.Name = "txtname"
        Me.txtname.Size = New System.Drawing.Size(124, 20)
        Me.txtname.TabIndex = 0
        '
        'lblgroup
        '
        Me.lblgroup.BackColor = System.Drawing.Color.Transparent
        Me.lblgroup.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblgroup.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblgroup.Location = New System.Drawing.Point(3, 9)
        Me.lblgroup.Name = "lblgroup"
        Me.lblgroup.Size = New System.Drawing.Size(41, 20)
        Me.lblgroup.TabIndex = 81
        Me.lblgroup.Text = "Area"
        Me.lblgroup.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmddelete
        '
        Me.cmddelete.BackgroundImage = Global.Magic_Gold.My.Resources.Resources.WASTE
        Me.cmddelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.cmddelete.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmddelete.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmddelete.Location = New System.Drawing.Point(180, 8)
        Me.cmddelete.Name = "cmddelete"
        Me.cmddelete.Size = New System.Drawing.Size(28, 23)
        Me.cmddelete.TabIndex = 84
        Me.cmddelete.UseVisualStyleBackColor = True
        '
        'chkchange
        '
        Me.chkchange.AutoSize = True
        Me.chkchange.Location = New System.Drawing.Point(6, 75)
        Me.chkchange.Name = "chkchange"
        Me.chkchange.Size = New System.Drawing.Size(15, 14)
        Me.chkchange.TabIndex = 138
        Me.chkchange.UseVisualStyleBackColor = True
        Me.chkchange.Visible = False
        '
        'areamaster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.BackgroundImage = Global.Magic_Gold.My.Resources.Resources.lgn_pnl
        Me.ClientSize = New System.Drawing.Size(292, 95)
        Me.Controls.Add(Me.chkchange)
        Me.Controls.Add(Me.cmddelete)
        Me.Controls.Add(Me.cmdedit)
        Me.Controls.Add(Me.lbl)
        Me.Controls.Add(Me.cmdexit)
        Me.Controls.Add(Me.cmdok)
        Me.Controls.Add(Me.txtname)
        Me.Controls.Add(Me.lblgroup)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "areamaster"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "New Area"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdedit As System.Windows.Forms.Button
    Friend WithEvents lbl As System.Windows.Forms.Label
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents cmdok As System.Windows.Forms.Button
    Friend WithEvents txtname As System.Windows.Forms.TextBox
    Friend WithEvents lblgroup As System.Windows.Forms.Label
    Friend WithEvents cmddelete As System.Windows.Forms.Button
    Friend WithEvents chkchange As System.Windows.Forms.CheckBox
End Class
