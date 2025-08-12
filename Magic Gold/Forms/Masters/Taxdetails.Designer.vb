<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Taxdetails
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Taxdetails))
        Me.gridtax = New System.Windows.Forms.DataGridView
        Me.taxname = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Description = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Tax = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Label7 = New System.Windows.Forms.Label
        Me.cmdexit = New System.Windows.Forms.Button
        Me.cmdedit = New System.Windows.Forms.Button
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.newtax = New System.Windows.Forms.ToolStripLabel
        CType(Me.gridtax, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'gridtax
        '
        Me.gridtax.AllowUserToAddRows = False
        Me.gridtax.AllowUserToDeleteRows = False
        Me.gridtax.AllowUserToResizeColumns = False
        Me.gridtax.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.gridtax.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.gridtax.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gridtax.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.gridtax.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridtax.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.taxname, Me.Description, Me.Tax})
        Me.gridtax.GridColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.gridtax.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.gridtax.Location = New System.Drawing.Point(14, 72)
        Me.gridtax.MultiSelect = False
        Me.gridtax.Name = "gridtax"
        Me.gridtax.ReadOnly = True
        Me.gridtax.RowHeadersVisible = False
        Me.gridtax.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridtax.Size = New System.Drawing.Size(429, 231)
        Me.gridtax.TabIndex = 0
        '
        'taxname
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.taxname.DefaultCellStyle = DataGridViewCellStyle3
        Me.taxname.HeaderText = "Name"
        Me.taxname.Name = "taxname"
        Me.taxname.ReadOnly = True
        Me.taxname.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'Description
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Description.DefaultCellStyle = DataGridViewCellStyle4
        Me.Description.HeaderText = "Description"
        Me.Description.Name = "Description"
        Me.Description.ReadOnly = True
        Me.Description.Width = 220
        '
        'Tax
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Tax.DefaultCellStyle = DataGridViewCellStyle5
        Me.Tax.HeaderText = "Tax"
        Me.Tax.Name = "Tax"
        Me.Tax.ReadOnly = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.DarkCyan
        Me.Label7.Location = New System.Drawing.Point(11, 48)
        Me.Label7.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(112, 14)
        Me.Label7.TabIndex = 88
        Me.Label7.Text = "Double Click to Edit"
        '
        'cmdexit
        '
        Me.cmdexit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.Location = New System.Drawing.Point(190, 310)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(75, 24)
        Me.cmdexit.TabIndex = 90
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = True
        '
        'cmdedit
        '
        Me.cmdedit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdedit.Location = New System.Drawing.Point(356, 42)
        Me.cmdedit.Name = "cmdedit"
        Me.cmdedit.Size = New System.Drawing.Size(87, 24)
        Me.cmdedit.TabIndex = 91
        Me.cmdedit.Text = "&Edit Tax..."
        Me.cmdedit.UseVisualStyleBackColor = True
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.newtax})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(455, 25)
        Me.ToolStrip1.TabIndex = 92
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'newtax
        '
        Me.newtax.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.newtax.Image = Global.Magic_Gold.My.Resources.Resources.Be_Navigator
        Me.newtax.Name = "newtax"
        Me.newtax.Size = New System.Drawing.Size(70, 22)
        Me.newtax.Text = "&New Tax"
        '
        'Taxdetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.BackgroundImage = Global.Magic_Gold.My.Resources.Resources.lgn_pnl
        Me.ClientSize = New System.Drawing.Size(455, 351)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.cmdedit)
        Me.Controls.Add(Me.cmdexit)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.gridtax)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "Taxdetails"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Tax Details"
        CType(Me.gridtax, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gridtax As System.Windows.Forms.DataGridView
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents cmdedit As System.Windows.Forms.Button
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents newtax As System.Windows.Forms.ToolStripLabel
    Friend WithEvents taxname As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Description As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Tax As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
