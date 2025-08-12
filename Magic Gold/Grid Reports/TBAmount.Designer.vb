<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TBAmount
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TBAmount))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.CMDFILTER = New System.Windows.Forms.Button()
        Me.CMDSHOWDETAILS = New System.Windows.Forms.Button()
        Me.dtto = New System.Windows.Forms.DateTimePicker()
        Me.lblto = New System.Windows.Forms.Label()
        Me.dtfrom = New System.Windows.Forms.DateTimePicker()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.chkdate = New System.Windows.Forms.CheckBox()
        Me.lblfrom = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.PrintToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.tabop = New System.Windows.Forms.TabControl()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.GRIDTRIALBALANCE = New System.Windows.Forms.DataGridView()
        Me.GNAME = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GOPDR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GOPCR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GDR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GCR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GCLODR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GCLOCR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GGROUPNAME = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CHKREMOVE0 = New System.Windows.Forms.CheckBox()
        Me.BlendPanel1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.tabop.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        CType(Me.GRIDTRIALBALANCE, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.CHKREMOVE0)
        Me.BlendPanel1.Controls.Add(Me.CMDFILTER)
        Me.BlendPanel1.Controls.Add(Me.CMDSHOWDETAILS)
        Me.BlendPanel1.Controls.Add(Me.dtto)
        Me.BlendPanel1.Controls.Add(Me.lblto)
        Me.BlendPanel1.Controls.Add(Me.dtfrom)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.chkdate)
        Me.BlendPanel1.Controls.Add(Me.lblfrom)
        Me.BlendPanel1.Controls.Add(Me.ToolStrip1)
        Me.BlendPanel1.Controls.Add(Me.Label13)
        Me.BlendPanel1.Controls.Add(Me.tabop)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1068, 582)
        Me.BlendPanel1.TabIndex = 2
        '
        'CMDFILTER
        '
        Me.CMDFILTER.BackColor = System.Drawing.Color.Transparent
        Me.CMDFILTER.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDFILTER.FlatAppearance.BorderSize = 0
        Me.CMDFILTER.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDFILTER.ForeColor = System.Drawing.Color.Black
        Me.CMDFILTER.Location = New System.Drawing.Point(322, 32)
        Me.CMDFILTER.Name = "CMDFILTER"
        Me.CMDFILTER.Size = New System.Drawing.Size(88, 28)
        Me.CMDFILTER.TabIndex = 459
        Me.CMDFILTER.Text = "&Filter"
        Me.CMDFILTER.UseVisualStyleBackColor = False
        '
        'CMDSHOWDETAILS
        '
        Me.CMDSHOWDETAILS.BackColor = System.Drawing.Color.Transparent
        Me.CMDSHOWDETAILS.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDSHOWDETAILS.FlatAppearance.BorderSize = 0
        Me.CMDSHOWDETAILS.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDSHOWDETAILS.ForeColor = System.Drawing.Color.Black
        Me.CMDSHOWDETAILS.Location = New System.Drawing.Point(322, 62)
        Me.CMDSHOWDETAILS.Name = "CMDSHOWDETAILS"
        Me.CMDSHOWDETAILS.Size = New System.Drawing.Size(88, 28)
        Me.CMDSHOWDETAILS.TabIndex = 446
        Me.CMDSHOWDETAILS.Text = "&Show Details"
        Me.CMDSHOWDETAILS.UseVisualStyleBackColor = False
        '
        'dtto
        '
        Me.dtto.CustomFormat = "dd/MM/yyyy"
        Me.dtto.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtto.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtto.Location = New System.Drawing.Point(229, 66)
        Me.dtto.Name = "dtto"
        Me.dtto.Size = New System.Drawing.Size(87, 22)
        Me.dtto.TabIndex = 445
        '
        'lblto
        '
        Me.lblto.AutoSize = True
        Me.lblto.BackColor = System.Drawing.Color.Transparent
        Me.lblto.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblto.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblto.Location = New System.Drawing.Point(205, 69)
        Me.lblto.Name = "lblto"
        Me.lblto.Size = New System.Drawing.Size(18, 14)
        Me.lblto.TabIndex = 447
        Me.lblto.Text = "To"
        '
        'dtfrom
        '
        Me.dtfrom.CustomFormat = "dd/MM/yyyy"
        Me.dtfrom.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtfrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtfrom.Location = New System.Drawing.Point(228, 40)
        Me.dtfrom.Name = "dtfrom"
        Me.dtfrom.Size = New System.Drawing.Size(88, 22)
        Me.dtfrom.TabIndex = 444
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.Black
        Me.cmdexit.Location = New System.Drawing.Point(429, 539)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 28)
        Me.cmdexit.TabIndex = 454
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'chkdate
        '
        Me.chkdate.AutoSize = True
        Me.chkdate.BackColor = System.Drawing.Color.Transparent
        Me.chkdate.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkdate.Location = New System.Drawing.Point(141, 42)
        Me.chkdate.Name = "chkdate"
        Me.chkdate.Size = New System.Drawing.Size(49, 18)
        Me.chkdate.TabIndex = 442
        Me.chkdate.Text = "Date"
        Me.chkdate.UseVisualStyleBackColor = False
        '
        'lblfrom
        '
        Me.lblfrom.AutoSize = True
        Me.lblfrom.BackColor = System.Drawing.Color.Transparent
        Me.lblfrom.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblfrom.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblfrom.Location = New System.Drawing.Point(190, 43)
        Me.lblfrom.Name = "lblfrom"
        Me.lblfrom.Size = New System.Drawing.Size(33, 14)
        Me.lblfrom.TabIndex = 443
        Me.lblfrom.Text = "From"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrintToolStripButton})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1068, 25)
        Me.ToolStrip1.TabIndex = 295
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'PrintToolStripButton
        '
        Me.PrintToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PrintToolStripButton.Image = CType(resources.GetObject("PrintToolStripButton.Image"), System.Drawing.Image)
        Me.PrintToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PrintToolStripButton.Name = "PrintToolStripButton"
        Me.PrintToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.PrintToolStripButton.Text = "&Print"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label13.Location = New System.Drawing.Point(8, 32)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(113, 20)
        Me.Label13.TabIndex = 293
        Me.Label13.Text = "Trial Balance"
        '
        'tabop
        '
        Me.tabop.Controls.Add(Me.TabPage3)
        Me.tabop.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabop.Location = New System.Drawing.Point(9, 94)
        Me.tabop.Name = "tabop"
        Me.tabop.SelectedIndex = 0
        Me.tabop.Size = New System.Drawing.Size(1050, 439)
        Me.tabop.TabIndex = 456
        Me.tabop.TabStop = False
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.GRIDTRIALBALANCE)
        Me.TabPage3.Location = New System.Drawing.Point(4, 23)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(1042, 412)
        Me.TabPage3.TabIndex = 0
        Me.TabPage3.Text = "Trial Balance "
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'GRIDTRIALBALANCE
        '
        Me.GRIDTRIALBALANCE.AllowUserToDeleteRows = False
        Me.GRIDTRIALBALANCE.AllowUserToResizeColumns = False
        Me.GRIDTRIALBALANCE.AllowUserToResizeRows = False
        Me.GRIDTRIALBALANCE.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.GRIDTRIALBALANCE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.GRIDTRIALBALANCE.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.GRIDTRIALBALANCE.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.GRIDTRIALBALANCE.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GRIDTRIALBALANCE.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.GNAME, Me.GOPDR, Me.GOPCR, Me.GDR, Me.GCR, Me.GCLODR, Me.GCLOCR, Me.GGROUPNAME})
        Me.GRIDTRIALBALANCE.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GRIDTRIALBALANCE.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.GRIDTRIALBALANCE.GridColor = System.Drawing.SystemColors.Control
        Me.GRIDTRIALBALANCE.Location = New System.Drawing.Point(0, 0)
        Me.GRIDTRIALBALANCE.MultiSelect = False
        Me.GRIDTRIALBALANCE.Name = "GRIDTRIALBALANCE"
        Me.GRIDTRIALBALANCE.RowHeadersVisible = False
        Me.GRIDTRIALBALANCE.RowHeadersWidth = 20
        Me.GRIDTRIALBALANCE.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.Black
        Me.GRIDTRIALBALANCE.RowsDefaultCellStyle = DataGridViewCellStyle10
        Me.GRIDTRIALBALANCE.RowTemplate.Height = 16
        Me.GRIDTRIALBALANCE.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GRIDTRIALBALANCE.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.GRIDTRIALBALANCE.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GRIDTRIALBALANCE.Size = New System.Drawing.Size(1042, 412)
        Me.GRIDTRIALBALANCE.TabIndex = 0
        '
        'GNAME
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.GNAME.DefaultCellStyle = DataGridViewCellStyle2
        Me.GNAME.HeaderText = "Name"
        Me.GNAME.Name = "GNAME"
        Me.GNAME.ReadOnly = True
        Me.GNAME.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GNAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GNAME.Width = 280
        '
        'GOPDR
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer))
        DataGridViewCellStyle3.Format = "N2"
        Me.GOPDR.DefaultCellStyle = DataGridViewCellStyle3
        Me.GOPDR.HeaderText = "O/P Dr"
        Me.GOPDR.Name = "GOPDR"
        Me.GOPDR.ReadOnly = True
        Me.GOPDR.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GOPDR.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'GOPCR
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer))
        DataGridViewCellStyle4.Format = "N2"
        Me.GOPCR.DefaultCellStyle = DataGridViewCellStyle4
        Me.GOPCR.HeaderText = "O/P Cr"
        Me.GOPCR.Name = "GOPCR"
        Me.GOPCR.ReadOnly = True
        Me.GOPCR.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GOPCR.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'GDR
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.Format = "N2"
        Me.GDR.DefaultCellStyle = DataGridViewCellStyle5
        Me.GDR.HeaderText = "Debit"
        Me.GDR.Name = "GDR"
        Me.GDR.ReadOnly = True
        Me.GDR.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GDR.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'GCR
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.Format = "N2"
        Me.GCR.DefaultCellStyle = DataGridViewCellStyle6
        Me.GCR.HeaderText = "Credit"
        Me.GCR.Name = "GCR"
        Me.GCR.ReadOnly = True
        Me.GCR.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GCR.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'GCLODR
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer))
        DataGridViewCellStyle7.Format = "N2"
        Me.GCLODR.DefaultCellStyle = DataGridViewCellStyle7
        Me.GCLODR.HeaderText = "Closing Dr."
        Me.GCLODR.Name = "GCLODR"
        Me.GCLODR.ReadOnly = True
        Me.GCLODR.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GCLODR.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'GCLOCR
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer))
        DataGridViewCellStyle8.Format = "N2"
        Me.GCLOCR.DefaultCellStyle = DataGridViewCellStyle8
        Me.GCLOCR.HeaderText = "Closing Cr."
        Me.GCLOCR.Name = "GCLOCR"
        Me.GCLOCR.ReadOnly = True
        Me.GCLOCR.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GCLOCR.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'GGROUPNAME
        '
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.GGROUPNAME.DefaultCellStyle = DataGridViewCellStyle9
        Me.GGROUPNAME.HeaderText = "Group Name"
        Me.GGROUPNAME.Name = "GGROUPNAME"
        Me.GGROUPNAME.ReadOnly = True
        Me.GGROUPNAME.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GGROUPNAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GGROUPNAME.Width = 130
        '
        'CHKREMOVE0
        '
        Me.CHKREMOVE0.AutoSize = True
        Me.CHKREMOVE0.BackColor = System.Drawing.Color.Transparent
        Me.CHKREMOVE0.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKREMOVE0.Location = New System.Drawing.Point(416, 72)
        Me.CHKREMOVE0.Name = "CHKREMOVE0"
        Me.CHKREMOVE0.Size = New System.Drawing.Size(117, 18)
        Me.CHKREMOVE0.TabIndex = 461
        Me.CHKREMOVE0.Text = "Remove 0 Balance"
        Me.CHKREMOVE0.UseVisualStyleBackColor = False
        '
        'TBAmount
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1068, 582)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "TBAmount"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Trial Balance (Amount)"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.tabop.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        CType(Me.GRIDTRIALBALANCE, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents CMDSHOWDETAILS As System.Windows.Forms.Button
    Friend WithEvents dtto As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblto As System.Windows.Forms.Label
    Friend WithEvents dtfrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents chkdate As System.Windows.Forms.CheckBox
    Friend WithEvents lblfrom As System.Windows.Forms.Label
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents PrintToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents tabop As System.Windows.Forms.TabControl
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents GRIDTRIALBALANCE As System.Windows.Forms.DataGridView
    Friend WithEvents CMDFILTER As System.Windows.Forms.Button
    Friend WithEvents GNAME As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GOPDR As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GOPCR As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GDR As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GCR As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GCLODR As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GCLOCR As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GGROUPNAME As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CHKREMOVE0 As CheckBox
End Class
