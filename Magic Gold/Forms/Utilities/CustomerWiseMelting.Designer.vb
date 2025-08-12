<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CustomerWiseMelting
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CustomerWiseMelting))
        Me.BlendPanel1 = New VbPowerPack.BlendPanel
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmbname = New System.Windows.Forms.ComboBox
        Me.lblname = New System.Windows.Forms.Label
        Me.grouppayment = New System.Windows.Forms.GroupBox
        Me.txtlabour = New System.Windows.Forms.TextBox
        Me.txtwastage = New System.Windows.Forms.TextBox
        Me.cmbitemcode = New System.Windows.Forms.ComboBox
        Me.griddetails = New System.Windows.Forms.DataGridView
        Me.GCHK = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.GSRNO = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GITEMNAME = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GWASTAGE = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLABOUR = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.txtsrno = New System.Windows.Forms.TextBox
        Me.cmdclear = New System.Windows.Forms.Button
        Me.cmdexit = New System.Windows.Forms.Button
        Me.lbl = New System.Windows.Forms.Label
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripdelete = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.BlendPanel1.SuspendLayout()
        Me.grouppayment.SuspendLayout()
        CType(Me.griddetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.Label11)
        Me.BlendPanel1.Controls.Add(Me.Label12)
        Me.BlendPanel1.Controls.Add(Me.Label4)
        Me.BlendPanel1.Controls.Add(Me.cmbname)
        Me.BlendPanel1.Controls.Add(Me.lblname)
        Me.BlendPanel1.Controls.Add(Me.grouppayment)
        Me.BlendPanel1.Controls.Add(Me.cmdclear)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.lbl)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 25)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(520, 537)
        Me.BlendPanel1.TabIndex = 0
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Red
        Me.Label11.Location = New System.Drawing.Point(52, 512)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(48, 14)
        Me.Label11.TabIndex = 462
        Me.Label11.Text = "Default"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label12.Location = New System.Drawing.Point(33, 510)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(18, 16)
        Me.Label12.TabIndex = 461
        Me.Label12.Text = "   "
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(25, 37)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 14)
        Me.Label4.TabIndex = 381
        Me.Label4.Text = "Party Code"
        '
        'cmbname
        '
        Me.cmbname.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbname.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbname.BackColor = System.Drawing.Color.White
        Me.cmbname.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbname.Items.AddRange(New Object() {""})
        Me.cmbname.Location = New System.Drawing.Point(90, 33)
        Me.cmbname.Name = "cmbname"
        Me.cmbname.Size = New System.Drawing.Size(90, 22)
        Me.cmbname.TabIndex = 0
        '
        'lblname
        '
        Me.lblname.AutoSize = True
        Me.lblname.BackColor = System.Drawing.Color.Transparent
        Me.lblname.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblname.ForeColor = System.Drawing.Color.Green
        Me.lblname.Location = New System.Drawing.Point(192, 37)
        Me.lblname.Name = "lblname"
        Me.lblname.Size = New System.Drawing.Size(0, 14)
        Me.lblname.TabIndex = 382
        '
        'grouppayment
        '
        Me.grouppayment.BackColor = System.Drawing.Color.Transparent
        Me.grouppayment.Controls.Add(Me.txtlabour)
        Me.grouppayment.Controls.Add(Me.txtwastage)
        Me.grouppayment.Controls.Add(Me.cmbitemcode)
        Me.grouppayment.Controls.Add(Me.griddetails)
        Me.grouppayment.Controls.Add(Me.txtsrno)
        Me.grouppayment.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grouppayment.ForeColor = System.Drawing.Color.Black
        Me.grouppayment.Location = New System.Drawing.Point(29, 52)
        Me.grouppayment.Name = "grouppayment"
        Me.grouppayment.Size = New System.Drawing.Size(470, 448)
        Me.grouppayment.TabIndex = 1
        Me.grouppayment.TabStop = False
        '
        'txtlabour
        '
        Me.txtlabour.BackColor = System.Drawing.Color.White
        Me.txtlabour.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtlabour.ForeColor = System.Drawing.Color.Black
        Me.txtlabour.Location = New System.Drawing.Point(334, 15)
        Me.txtlabour.Name = "txtlabour"
        Me.txtlabour.Size = New System.Drawing.Size(100, 22)
        Me.txtlabour.TabIndex = 3
        '
        'txtwastage
        '
        Me.txtwastage.BackColor = System.Drawing.Color.White
        Me.txtwastage.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtwastage.ForeColor = System.Drawing.Color.Black
        Me.txtwastage.Location = New System.Drawing.Point(234, 15)
        Me.txtwastage.Name = "txtwastage"
        Me.txtwastage.Size = New System.Drawing.Size(100, 22)
        Me.txtwastage.TabIndex = 2
        '
        'cmbitemcode
        '
        Me.cmbitemcode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbitemcode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbitemcode.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbitemcode.FormattingEnabled = True
        Me.cmbitemcode.Items.AddRange(New Object() {"Advance", "Against Bill", "On Account"})
        Me.cmbitemcode.Location = New System.Drawing.Point(84, 15)
        Me.cmbitemcode.MaxDropDownItems = 14
        Me.cmbitemcode.Name = "cmbitemcode"
        Me.cmbitemcode.Size = New System.Drawing.Size(150, 22)
        Me.cmbitemcode.TabIndex = 1
        '
        'griddetails
        '
        Me.griddetails.AllowUserToAddRows = False
        Me.griddetails.AllowUserToDeleteRows = False
        Me.griddetails.AllowUserToResizeColumns = False
        Me.griddetails.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer))
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        Me.griddetails.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.griddetails.BackgroundColor = System.Drawing.Color.White
        Me.griddetails.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.griddetails.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.griddetails.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.griddetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.griddetails.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.GCHK, Me.GSRNO, Me.GITEMNAME, Me.GWASTAGE, Me.GLABOUR})
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.griddetails.DefaultCellStyle = DataGridViewCellStyle7
        Me.griddetails.GridColor = System.Drawing.SystemColors.ControlText
        Me.griddetails.Location = New System.Drawing.Point(5, 37)
        Me.griddetails.Margin = New System.Windows.Forms.Padding(2)
        Me.griddetails.MultiSelect = False
        Me.griddetails.Name = "griddetails"
        Me.griddetails.RowHeadersVisible = False
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.Black
        Me.griddetails.RowsDefaultCellStyle = DataGridViewCellStyle8
        Me.griddetails.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.griddetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.griddetails.Size = New System.Drawing.Size(460, 406)
        Me.griddetails.TabIndex = 4
        Me.griddetails.TabStop = False
        '
        'GCHK
        '
        Me.GCHK.HeaderText = ""
        Me.GCHK.Name = "GCHK"
        Me.GCHK.ReadOnly = True
        Me.GCHK.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GCHK.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.GCHK.Width = 40
        '
        'GSRNO
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.GSRNO.DefaultCellStyle = DataGridViewCellStyle3
        Me.GSRNO.HeaderText = "Sr."
        Me.GSRNO.Name = "GSRNO"
        Me.GSRNO.ReadOnly = True
        Me.GSRNO.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GSRNO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GSRNO.Width = 40
        '
        'GITEMNAME
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.GITEMNAME.DefaultCellStyle = DataGridViewCellStyle4
        Me.GITEMNAME.HeaderText = "Item Code"
        Me.GITEMNAME.Name = "GITEMNAME"
        Me.GITEMNAME.ReadOnly = True
        Me.GITEMNAME.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GITEMNAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GITEMNAME.Width = 150
        '
        'GWASTAGE
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.GWASTAGE.DefaultCellStyle = DataGridViewCellStyle5
        Me.GWASTAGE.HeaderText = "Wastage"
        Me.GWASTAGE.Name = "GWASTAGE"
        Me.GWASTAGE.ReadOnly = True
        Me.GWASTAGE.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GWASTAGE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'GLABOUR
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.GLABOUR.DefaultCellStyle = DataGridViewCellStyle6
        Me.GLABOUR.HeaderText = "Labour (Amt)"
        Me.GLABOUR.Name = "GLABOUR"
        Me.GLABOUR.ReadOnly = True
        Me.GLABOUR.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GLABOUR.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'txtsrno
        '
        Me.txtsrno.BackColor = System.Drawing.Color.White
        Me.txtsrno.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtsrno.Location = New System.Drawing.Point(44, 15)
        Me.txtsrno.Name = "txtsrno"
        Me.txtsrno.ReadOnly = True
        Me.txtsrno.Size = New System.Drawing.Size(40, 22)
        Me.txtsrno.TabIndex = 0
        '
        'cmdclear
        '
        Me.cmdclear.BackColor = System.Drawing.Color.Transparent
        Me.cmdclear.FlatAppearance.BorderSize = 0
        Me.cmdclear.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdclear.ForeColor = System.Drawing.Color.Black
        Me.cmdclear.Location = New System.Drawing.Point(177, 506)
        Me.cmdclear.Name = "cmdclear"
        Me.cmdclear.Size = New System.Drawing.Size(80, 28)
        Me.cmdclear.TabIndex = 2
        Me.cmdclear.Text = "&Clear"
        Me.cmdclear.UseVisualStyleBackColor = False
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.Black
        Me.cmdexit.Location = New System.Drawing.Point(263, 506)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 28)
        Me.cmdexit.TabIndex = 3
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'lbl
        '
        Me.lbl.AutoSize = True
        Me.lbl.BackColor = System.Drawing.Color.Transparent
        Me.lbl.Font = New System.Drawing.Font("Calibri", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbl.Location = New System.Drawing.Point(12, 9)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(177, 21)
        Me.lbl.TabIndex = 306
        Me.lbl.Text = "Customer Wise Melting"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ToolStrip1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripdelete, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(520, 25)
        Me.ToolStrip1.TabIndex = 307
        Me.ToolStrip1.Text = "ToolStrip1"
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
        'CustomerWiseMelting
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(520, 562)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "CustomerWiseMelting"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Customer Wise Melting"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        Me.grouppayment.ResumeLayout(False)
        Me.grouppayment.PerformLayout()
        CType(Me.griddetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents lbl As System.Windows.Forms.Label
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripdelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmdclear As System.Windows.Forms.Button
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents grouppayment As System.Windows.Forms.GroupBox
    Friend WithEvents txtwastage As System.Windows.Forms.TextBox
    Friend WithEvents cmbitemcode As System.Windows.Forms.ComboBox
    Friend WithEvents griddetails As System.Windows.Forms.DataGridView
    Friend WithEvents txtsrno As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbname As System.Windows.Forms.ComboBox
    Friend WithEvents lblname As System.Windows.Forms.Label
    Friend WithEvents txtlabour As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents GCHK As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents GSRNO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GITEMNAME As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GWASTAGE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLABOUR As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
End Class
