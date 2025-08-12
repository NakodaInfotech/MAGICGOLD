<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class groupdetails
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(groupdetails))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.gridgroup = New System.Windows.Forms.DataGridView
        Me.group = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.under = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Label7 = New System.Windows.Forms.Label
        Me.cmdedit = New System.Windows.Forms.Button
        Me.cmdexit = New System.Windows.Forms.Button
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.newgroup = New System.Windows.Forms.ToolStripLabel
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripdelete = New System.Windows.Forms.ToolStripButton
        Me.GroupBox1.SuspendLayout()
        CType(Me.gridgroup, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.gridgroup)
        Me.GroupBox1.Location = New System.Drawing.Point(19, 47)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(455, 355)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'gridgroup
        '
        Me.gridgroup.AllowUserToAddRows = False
        Me.gridgroup.AllowUserToDeleteRows = False
        Me.gridgroup.AllowUserToResizeColumns = False
        Me.gridgroup.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.gridgroup.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.gridgroup.BackgroundColor = System.Drawing.Color.White
        Me.gridgroup.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gridgroup.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.gridgroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridgroup.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.group, Me.under})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gridgroup.DefaultCellStyle = DataGridViewCellStyle4
        Me.gridgroup.GridColor = System.Drawing.SystemColors.Control
        Me.gridgroup.Location = New System.Drawing.Point(8, 13)
        Me.gridgroup.Margin = New System.Windows.Forms.Padding(2)
        Me.gridgroup.MultiSelect = False
        Me.gridgroup.Name = "gridgroup"
        Me.gridgroup.ReadOnly = True
        Me.gridgroup.RowHeadersVisible = False
        Me.gridgroup.RowHeadersWidth = 30
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Black
        Me.gridgroup.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.gridgroup.RowTemplate.Height = 20
        Me.gridgroup.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.gridgroup.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridgroup.Size = New System.Drawing.Size(439, 337)
        Me.gridgroup.TabIndex = 2
        '
        'group
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.group.DefaultCellStyle = DataGridViewCellStyle3
        Me.group.HeaderText = "Name"
        Me.group.Name = "group"
        Me.group.ReadOnly = True
        Me.group.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.group.Width = 200
        '
        'under
        '
        Me.under.HeaderText = "Under"
        Me.under.Name = "under"
        Me.under.ReadOnly = True
        Me.under.Width = 200
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.DarkCyan
        Me.Label7.Location = New System.Drawing.Point(9, 30)
        Me.Label7.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(103, 14)
        Me.Label7.TabIndex = 85
        Me.Label7.Text = "Double Click to Edit"
        '
        'cmdedit
        '
        Me.cmdedit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdedit.ForeColor = System.Drawing.Color.Black
        Me.cmdedit.Location = New System.Drawing.Point(249, 408)
        Me.cmdedit.Name = "cmdedit"
        Me.cmdedit.Size = New System.Drawing.Size(78, 26)
        Me.cmdedit.TabIndex = 1
        Me.cmdedit.Text = "&Edit Group..."
        Me.cmdedit.UseVisualStyleBackColor = True
        '
        'cmdexit
        '
        Me.cmdexit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.Black
        Me.cmdexit.Location = New System.Drawing.Point(165, 408)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(78, 26)
        Me.cmdexit.TabIndex = 3
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = True
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.newgroup, Me.ToolStripSeparator1, Me.ToolStripdelete})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(492, 25)
        Me.ToolStrip1.TabIndex = 90
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'newgroup
        '
        Me.newgroup.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.newgroup.Image = Global.Magic_Gold.My.Resources.Resources.Be_Navigator
        Me.newgroup.Name = "newgroup"
        Me.newgroup.Size = New System.Drawing.Size(83, 22)
        Me.newgroup.Text = "&New Group"
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
        'groupdetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.BackgroundImage = Global.Magic_Gold.My.Resources.Resources.lgn_pnl
        Me.ClientSize = New System.Drawing.Size(492, 446)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.cmdexit)
        Me.Controls.Add(Me.cmdedit)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "groupdetails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Group Details"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.gridgroup, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents gridgroup As System.Windows.Forms.DataGridView
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmdedit As System.Windows.Forms.Button
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents newgroup As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripdelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents group As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents under As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
