<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class areadetails
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(areadetails))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.cmdedit = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.newarea = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripdelete = New System.Windows.Forms.ToolStripButton()
        Me.gridlocation = New System.Windows.Forms.DataGridView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txttempname = New System.Windows.Forms.TextBox()
        Me.txtname = New System.Windows.Forms.TextBox()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.gridlocation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdedit
        '
        Me.cmdedit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdedit.ForeColor = System.Drawing.Color.Black
        Me.cmdedit.Location = New System.Drawing.Point(243, 36)
        Me.cmdedit.Name = "cmdedit"
        Me.cmdedit.Size = New System.Drawing.Size(78, 26)
        Me.cmdedit.TabIndex = 92
        Me.cmdedit.Text = "&Edit Area..."
        Me.cmdedit.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.DarkCyan
        Me.Label7.Location = New System.Drawing.Point(22, 42)
        Me.Label7.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(100, 13)
        Me.Label7.TabIndex = 94
        Me.Label7.Text = "Double Click to Edit"
        '
        'cmdexit
        '
        Me.cmdexit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.Black
        Me.cmdexit.Location = New System.Drawing.Point(129, 407)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(78, 26)
        Me.cmdexit.TabIndex = 93
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = True
        '
        'newarea
        '
        Me.newarea.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.newarea.Image = Global.Magic_Gold.My.Resources.Resources.Be_Navigator
        Me.newarea.Name = "newarea"
        Me.newarea.Size = New System.Drawing.Size(76, 22)
        Me.newarea.Text = "&New Area"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.newarea, Me.ToolStripSeparator1, Me.ToolStripdelete})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(337, 25)
        Me.ToolStrip1.TabIndex = 95
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
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
        'gridlocation
        '
        Me.gridlocation.AllowUserToAddRows = False
        Me.gridlocation.AllowUserToDeleteRows = False
        Me.gridlocation.AllowUserToResizeColumns = False
        Me.gridlocation.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.gridlocation.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.gridlocation.BackgroundColor = System.Drawing.Color.White
        Me.gridlocation.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gridlocation.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.gridlocation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gridlocation.DefaultCellStyle = DataGridViewCellStyle3
        Me.gridlocation.GridColor = System.Drawing.SystemColors.Control
        Me.gridlocation.Location = New System.Drawing.Point(10, 38)
        Me.gridlocation.Margin = New System.Windows.Forms.Padding(2)
        Me.gridlocation.MultiSelect = False
        Me.gridlocation.Name = "gridlocation"
        Me.gridlocation.ReadOnly = True
        Me.gridlocation.RowHeadersVisible = False
        Me.gridlocation.RowHeadersWidth = 30
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Black
        Me.gridlocation.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.gridlocation.RowTemplate.Height = 20
        Me.gridlocation.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.gridlocation.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridlocation.Size = New System.Drawing.Size(291, 295)
        Me.gridlocation.TabIndex = 2
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.gridlocation)
        Me.GroupBox1.Location = New System.Drawing.Point(15, 59)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(306, 341)
        Me.GroupBox1.TabIndex = 91
        Me.GroupBox1.TabStop = False
        '
        'txttempname
        '
        Me.txttempname.BackColor = System.Drawing.Color.White
        Me.txttempname.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txttempname.ForeColor = System.Drawing.Color.Black
        Me.txttempname.Location = New System.Drawing.Point(15, 40)
        Me.txttempname.Name = "txttempname"
        Me.txttempname.ReadOnly = True
        Me.txttempname.Size = New System.Drawing.Size(150, 20)
        Me.txttempname.TabIndex = 225
        Me.txttempname.TabStop = False
        Me.txttempname.Visible = False
        '
        'txtname
        '
        Me.txtname.BackColor = System.Drawing.Color.White
        Me.txtname.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtname.ForeColor = System.Drawing.Color.Black
        Me.txtname.Location = New System.Drawing.Point(25, 74)
        Me.txtname.Name = "txtname"
        Me.txtname.Size = New System.Drawing.Size(290, 20)
        Me.txtname.TabIndex = 224
        '
        'areadetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.BackgroundImage = Global.Magic_Gold.My.Resources.Resources.lgn_pnl
        Me.ClientSize = New System.Drawing.Size(337, 446)
        Me.Controls.Add(Me.txttempname)
        Me.Controls.Add(Me.txtname)
        Me.Controls.Add(Me.cmdedit)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.cmdexit)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "areadetails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Area Details"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.gridlocation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdedit As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents newarea As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents gridlocation As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txttempname As System.Windows.Forms.TextBox
    Friend WithEvents txtname As System.Windows.Forms.TextBox
    Friend WithEvents ToolStripdelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
End Class
