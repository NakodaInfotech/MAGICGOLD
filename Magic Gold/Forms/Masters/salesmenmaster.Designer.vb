<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class salesmenmaster
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(salesmenmaster))
        Me.cmdedit = New System.Windows.Forms.Button
        Me.cmdexit = New System.Windows.Forms.Button
        Me.cmdok = New System.Windows.Forms.Button
        Me.txtname = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtmobileno = New System.Windows.Forms.TextBox
        Me.txtdescription = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.lbldriver = New System.Windows.Forms.Label
        Me.chkchange = New System.Windows.Forms.CheckBox
        Me.lbl = New System.Windows.Forms.Label
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.OpenToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.SaveToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.ToolStripdelete = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdedit
        '
        Me.cmdedit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdedit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdedit.Location = New System.Drawing.Point(237, 26)
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
        Me.cmdexit.Location = New System.Drawing.Point(313, 125)
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
        Me.cmdok.Location = New System.Drawing.Point(313, 95)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(78, 24)
        Me.cmdok.TabIndex = 3
        Me.cmdok.Text = "&Save"
        Me.cmdok.UseVisualStyleBackColor = True
        '
        'txtname
        '
        Me.txtname.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtname.Location = New System.Drawing.Point(78, 65)
        Me.txtname.Name = "txtname"
        Me.txtname.Size = New System.Drawing.Size(133, 20)
        Me.txtname.TabIndex = 0
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(41, 69)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(34, 14)
        Me.Label8.TabIndex = 90
        Me.Label8.Text = "Name"
        '
        'txtmobileno
        '
        Me.txtmobileno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtmobileno.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtmobileno.Location = New System.Drawing.Point(296, 65)
        Me.txtmobileno.Name = "txtmobileno"
        Me.txtmobileno.Size = New System.Drawing.Size(95, 20)
        Me.txtmobileno.TabIndex = 1
        Me.txtmobileno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtdescription
        '
        Me.txtdescription.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdescription.Location = New System.Drawing.Point(78, 90)
        Me.txtdescription.Multiline = True
        Me.txtdescription.Name = "txtdescription"
        Me.txtdescription.Size = New System.Drawing.Size(217, 64)
        Me.txtdescription.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(27, 97)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 14)
        Me.Label1.TabIndex = 96
        Me.Label1.Text = "Remarks"
        '
        'lbldriver
        '
        Me.lbldriver.AutoSize = True
        Me.lbldriver.BackColor = System.Drawing.Color.Transparent
        Me.lbldriver.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbldriver.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbldriver.Location = New System.Drawing.Point(239, 69)
        Me.lbldriver.Name = "lbldriver"
        Me.lbldriver.Size = New System.Drawing.Size(59, 14)
        Me.lbldriver.TabIndex = 94
        Me.lbldriver.Text = "Mobile No. "
        '
        'chkchange
        '
        Me.chkchange.AutoSize = True
        Me.chkchange.Location = New System.Drawing.Point(392, 43)
        Me.chkchange.Name = "chkchange"
        Me.chkchange.Size = New System.Drawing.Size(15, 14)
        Me.chkchange.TabIndex = 443
        Me.chkchange.UseVisualStyleBackColor = True
        Me.chkchange.Visible = False
        '
        'lbl
        '
        Me.lbl.AutoSize = True
        Me.lbl.BackColor = System.Drawing.Color.Transparent
        Me.lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbl.Location = New System.Drawing.Point(5, 30)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(93, 20)
        Me.lbl.TabIndex = 444
        Me.lbl.Text = "Sales Men"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenToolStripButton, Me.SaveToolStripButton, Me.ToolStripSeparator1, Me.ToolStripdelete})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(418, 25)
        Me.ToolStrip1.TabIndex = 445
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'OpenToolStripButton
        '
        Me.OpenToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.OpenToolStripButton.Image = CType(resources.GetObject("OpenToolStripButton.Image"), System.Drawing.Image)
        Me.OpenToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.OpenToolStripButton.Name = "OpenToolStripButton"
        Me.OpenToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.OpenToolStripButton.Text = "&Open"
        '
        'SaveToolStripButton
        '
        Me.SaveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.SaveToolStripButton.Image = CType(resources.GetObject("SaveToolStripButton.Image"), System.Drawing.Image)
        Me.SaveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SaveToolStripButton.Name = "SaveToolStripButton"
        Me.SaveToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.SaveToolStripButton.Text = "&Save"
        '
        'ToolStripdelete
        '
        Me.ToolStripdelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripdelete.Image = CType(resources.GetObject("ToolStripdelete.Image"), System.Drawing.Image)
        Me.ToolStripdelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripdelete.Name = "ToolStripdelete"
        Me.ToolStripdelete.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripdelete.Text = "C&ut"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'salesmenmaster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.BackgroundImage = Global.Magic_Gold.My.Resources.Resources.lgn_pnl
        Me.ClientSize = New System.Drawing.Size(418, 171)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.lbl)
        Me.Controls.Add(Me.chkchange)
        Me.Controls.Add(Me.txtdescription)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtmobileno)
        Me.Controls.Add(Me.lbldriver)
        Me.Controls.Add(Me.cmdedit)
        Me.Controls.Add(Me.cmdexit)
        Me.Controls.Add(Me.cmdok)
        Me.Controls.Add(Me.txtname)
        Me.Controls.Add(Me.Label8)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MinimumSize = New System.Drawing.Size(10, 34)
        Me.Name = "salesmenmaster"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "New Salesmen"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdedit As System.Windows.Forms.Button
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents cmdok As System.Windows.Forms.Button
    Friend WithEvents txtname As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtmobileno As System.Windows.Forms.TextBox
    Friend WithEvents txtdescription As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lbldriver As System.Windows.Forms.Label
    Friend WithEvents chkchange As System.Windows.Forms.CheckBox
    Friend WithEvents lbl As System.Windows.Forms.Label
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents OpenToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents SaveToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripdelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
End Class
