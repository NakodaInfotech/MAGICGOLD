<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class taxmaster
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(taxmaster))
        Me.cmdedit = New System.Windows.Forms.Button
        Me.cmdexit = New System.Windows.Forms.Button
        Me.cmdok = New System.Windows.Forms.Button
        Me.txtname = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txttax = New System.Windows.Forms.TextBox
        Me.txtdescription = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.lbl = New System.Windows.Forms.Label
        Me.lbltax = New System.Windows.Forms.Label
        Me.lblpercent = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'cmdedit
        '
        Me.cmdedit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdedit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdedit.Location = New System.Drawing.Point(260, 124)
        Me.cmdedit.Name = "cmdedit"
        Me.cmdedit.Size = New System.Drawing.Size(67, 24)
        Me.cmdedit.TabIndex = 92
        Me.cmdedit.Text = "&Edit"
        Me.cmdedit.UseVisualStyleBackColor = True
        Me.cmdedit.Visible = False
        '
        'cmdexit
        '
        Me.cmdexit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdexit.Location = New System.Drawing.Point(176, 124)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(78, 24)
        Me.cmdexit.TabIndex = 4
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = True
        '
        'cmdok
        '
        Me.cmdok.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdok.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdok.Location = New System.Drawing.Point(92, 124)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(78, 24)
        Me.cmdok.TabIndex = 3
        Me.cmdok.Text = "&Save"
        Me.cmdok.UseVisualStyleBackColor = True
        '
        'txtname
        '
        Me.txtname.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtname.Location = New System.Drawing.Point(86, 21)
        Me.txtname.Name = "txtname"
        Me.txtname.Size = New System.Drawing.Size(133, 20)
        Me.txtname.TabIndex = 0
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(49, 25)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(35, 13)
        Me.Label8.TabIndex = 90
        Me.Label8.Text = "Name"
        '
        'txttax
        '
        Me.txttax.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txttax.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txttax.Location = New System.Drawing.Point(299, 21)
        Me.txttax.Name = "txttax"
        Me.txttax.Size = New System.Drawing.Size(70, 20)
        Me.txttax.TabIndex = 1
        Me.txttax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtdescription
        '
        Me.txtdescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdescription.Location = New System.Drawing.Point(86, 47)
        Me.txtdescription.Multiline = True
        Me.txtdescription.Name = "txtdescription"
        Me.txtdescription.Size = New System.Drawing.Size(308, 20)
        Me.txtdescription.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(24, 54)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 13)
        Me.Label1.TabIndex = 96
        Me.Label1.Text = "Description"
        '
        'lbl
        '
        Me.lbl.BackColor = System.Drawing.Color.Transparent
        Me.lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbl.Location = New System.Drawing.Point(85, 77)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(249, 34)
        Me.lbl.TabIndex = 97
        Me.lbl.Text = "Used to Calculate Tax at a specific rate that You pay to a Tax agency"
        '
        'lbltax
        '
        Me.lbltax.AutoSize = True
        Me.lbltax.BackColor = System.Drawing.Color.Transparent
        Me.lbltax.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltax.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbltax.Location = New System.Drawing.Point(271, 25)
        Me.lbltax.Name = "lbltax"
        Me.lbltax.Size = New System.Drawing.Size(25, 13)
        Me.lbltax.TabIndex = 94
        Me.lbltax.Text = "Tax"
        '
        'lblpercent
        '
        Me.lblpercent.AutoSize = True
        Me.lblpercent.BackColor = System.Drawing.Color.Transparent
        Me.lblpercent.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblpercent.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblpercent.Location = New System.Drawing.Point(371, 21)
        Me.lblpercent.Name = "lblpercent"
        Me.lblpercent.Size = New System.Drawing.Size(21, 17)
        Me.lblpercent.TabIndex = 98
        Me.lblpercent.Text = "%"
        '
        'taxmaster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.BackgroundImage = Global.Magic_Gold.My.Resources.Resources.lgn_pnl
        Me.ClientSize = New System.Drawing.Size(418, 160)
        Me.Controls.Add(Me.lblpercent)
        Me.Controls.Add(Me.lbl)
        Me.Controls.Add(Me.txtdescription)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txttax)
        Me.Controls.Add(Me.lbltax)
        Me.Controls.Add(Me.cmdedit)
        Me.Controls.Add(Me.cmdexit)
        Me.Controls.Add(Me.cmdok)
        Me.Controls.Add(Me.txtname)
        Me.Controls.Add(Me.Label8)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MinimumSize = New System.Drawing.Size(426, 194)
        Me.Name = "taxmaster"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "New Tax "
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdedit As System.Windows.Forms.Button
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents cmdok As System.Windows.Forms.Button
    Friend WithEvents txtname As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txttax As System.Windows.Forms.TextBox
    Friend WithEvents txtdescription As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lbl As System.Windows.Forms.Label
    Friend WithEvents lbltax As System.Windows.Forms.Label
    Friend WithEvents lblpercent As System.Windows.Forms.Label
End Class
