<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StockFilter
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
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.griditem = New System.Windows.Forms.DataGridView
        Me.gridcategory = New System.Windows.Forms.DataGridView
        Me.DataGridViewCheckBoxColumn1 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.txtpurity = New System.Windows.Forms.TextBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.txtcategory = New System.Windows.Forms.TextBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txtitemname = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.chkdate = New System.Windows.Forms.CheckBox
        Me.dtpto = New System.Windows.Forms.DateTimePicker
        Me.dtpfrom = New System.Windows.Forms.DateTimePicker
        Me.cmdExit = New System.Windows.Forms.Button
        Me.cmdShowReport = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cmbname = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.chkcategory = New System.Windows.Forms.CheckBox
        Me.chkitem = New System.Windows.Forms.CheckBox
        Me.txtTempName = New System.Windows.Forms.TextBox
        Me.BlendPanel1 = New VbPowerPack.BlendPanel
        Me.GCHK = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.GITEMNAME = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.griditem, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridcategory, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.BlendPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'griditem
        '
        Me.griditem.AllowUserToAddRows = False
        Me.griditem.AllowUserToDeleteRows = False
        Me.griditem.AllowUserToResizeColumns = False
        Me.griditem.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.griditem.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.griditem.BackgroundColor = System.Drawing.Color.White
        Me.griditem.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.griditem.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.griditem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.griditem.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.GCHK, Me.GITEMNAME})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.griditem.DefaultCellStyle = DataGridViewCellStyle3
        Me.griditem.GridColor = System.Drawing.SystemColors.Control
        Me.griditem.Location = New System.Drawing.Point(8, 47)
        Me.griditem.Margin = New System.Windows.Forms.Padding(2)
        Me.griditem.MultiSelect = False
        Me.griditem.Name = "griditem"
        Me.griditem.RowHeadersVisible = False
        Me.griditem.RowHeadersWidth = 30
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Black
        Me.griditem.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.griditem.RowTemplate.Height = 20
        Me.griditem.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.griditem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.griditem.Size = New System.Drawing.Size(212, 271)
        Me.griditem.TabIndex = 1
        Me.griditem.TabStop = False
        '
        'gridcategory
        '
        Me.gridcategory.AllowUserToAddRows = False
        Me.gridcategory.AllowUserToDeleteRows = False
        Me.gridcategory.AllowUserToResizeColumns = False
        Me.gridcategory.AllowUserToResizeRows = False
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.gridcategory.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.gridcategory.BackgroundColor = System.Drawing.Color.White
        Me.gridcategory.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gridcategory.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.gridcategory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridcategory.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewCheckBoxColumn1, Me.DataGridViewTextBoxColumn1})
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gridcategory.DefaultCellStyle = DataGridViewCellStyle7
        Me.gridcategory.GridColor = System.Drawing.SystemColors.Control
        Me.gridcategory.Location = New System.Drawing.Point(8, 47)
        Me.gridcategory.Margin = New System.Windows.Forms.Padding(2)
        Me.gridcategory.MultiSelect = False
        Me.gridcategory.Name = "gridcategory"
        Me.gridcategory.RowHeadersVisible = False
        Me.gridcategory.RowHeadersWidth = 30
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.Black
        Me.gridcategory.RowsDefaultCellStyle = DataGridViewCellStyle8
        Me.gridcategory.RowTemplate.Height = 20
        Me.gridcategory.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.gridcategory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridcategory.Size = New System.Drawing.Size(212, 271)
        Me.gridcategory.TabIndex = 1
        Me.gridcategory.TabStop = False
        '
        'DataGridViewCheckBoxColumn1
        '
        Me.DataGridViewCheckBoxColumn1.HeaderText = ""
        Me.DataGridViewCheckBoxColumn1.Name = "DataGridViewCheckBoxColumn1"
        Me.DataGridViewCheckBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewCheckBoxColumn1.Width = 35
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "Category Name"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 150
        '
        'txtpurity
        '
        Me.txtpurity.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtpurity.Location = New System.Drawing.Point(325, 422)
        Me.txtpurity.Name = "txtpurity"
        Me.txtpurity.Size = New System.Drawing.Size(59, 22)
        Me.txtpurity.TabIndex = 5
        Me.txtpurity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.txtcategory)
        Me.GroupBox3.Controls.Add(Me.gridcategory)
        Me.GroupBox3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.ForeColor = System.Drawing.Color.Black
        Me.GroupBox3.Location = New System.Drawing.Point(280, 83)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(227, 324)
        Me.GroupBox3.TabIndex = 1
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Category"
        '
        'txtcategory
        '
        Me.txtcategory.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcategory.Location = New System.Drawing.Point(8, 26)
        Me.txtcategory.Name = "txtcategory"
        Me.txtcategory.Size = New System.Drawing.Size(185, 22)
        Me.txtcategory.TabIndex = 0
        Me.txtcategory.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.txtitemname)
        Me.GroupBox2.Controls.Add(Me.griditem)
        Me.GroupBox2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.Black
        Me.GroupBox2.Location = New System.Drawing.Point(26, 83)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(227, 324)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Item"
        '
        'txtitemname
        '
        Me.txtitemname.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtitemname.Location = New System.Drawing.Point(8, 26)
        Me.txtitemname.Name = "txtitemname"
        Me.txtitemname.Size = New System.Drawing.Size(185, 22)
        Me.txtitemname.TabIndex = 0
        Me.txtitemname.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(133, 28)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(20, 14)
        Me.Label4.TabIndex = 274
        Me.Label4.Text = "To"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(14, 28)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(34, 14)
        Me.Label3.TabIndex = 273
        Me.Label3.Text = "From"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(275, 426)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 14)
        Me.Label1.TabIndex = 272
        Me.Label1.Text = "Purity"
        '
        'chkdate
        '
        Me.chkdate.AutoSize = True
        Me.chkdate.BackColor = System.Drawing.Color.Transparent
        Me.chkdate.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkdate.Location = New System.Drawing.Point(34, 413)
        Me.chkdate.Name = "chkdate"
        Me.chkdate.Size = New System.Drawing.Size(52, 18)
        Me.chkdate.TabIndex = 267
        Me.chkdate.Text = "Date"
        Me.chkdate.UseVisualStyleBackColor = False
        '
        'dtpto
        '
        Me.dtpto.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpto.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpto.Location = New System.Drawing.Point(169, 437)
        Me.dtpto.Name = "dtpto"
        Me.dtpto.Size = New System.Drawing.Size(83, 22)
        Me.dtpto.TabIndex = 4
        '
        'dtpfrom
        '
        Me.dtpfrom.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpfrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpfrom.Location = New System.Drawing.Point(64, 437)
        Me.dtpfrom.Name = "dtpfrom"
        Me.dtpfrom.Size = New System.Drawing.Size(83, 22)
        Me.dtpfrom.TabIndex = 3
        '
        'cmdExit
        '
        Me.cmdExit.BackColor = System.Drawing.Color.Transparent
        Me.cmdExit.FlatAppearance.BorderSize = 0
        Me.cmdExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdExit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdExit.Image = Global.Magic_Gold.My.Resources.Resources._Exit
        Me.cmdExit.Location = New System.Drawing.Point(392, 446)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(87, 27)
        Me.cmdExit.TabIndex = 7
        Me.cmdExit.UseVisualStyleBackColor = False
        '
        'cmdShowReport
        '
        Me.cmdShowReport.BackColor = System.Drawing.Color.Transparent
        Me.cmdShowReport.FlatAppearance.BorderSize = 0
        Me.cmdShowReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdShowReport.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdShowReport.Image = Global.Magic_Gold.My.Resources.Resources.showreport
        Me.cmdShowReport.Location = New System.Drawing.Point(392, 417)
        Me.cmdShowReport.Name = "cmdShowReport"
        Me.cmdShowReport.Size = New System.Drawing.Size(87, 27)
        Me.cmdShowReport.TabIndex = 6
        Me.cmdShowReport.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(16, 413)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(244, 60)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        '
        'cmbname
        '
        Me.cmbname.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbname.FormattingEnabled = True
        Me.cmbname.Location = New System.Drawing.Point(63, 21)
        Me.cmbname.Name = "cmbname"
        Me.cmbname.Size = New System.Drawing.Size(185, 22)
        Me.cmbname.TabIndex = 280
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(18, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 14)
        Me.Label2.TabIndex = 279
        Me.Label2.Text = "Ledger"
        '
        'chkcategory
        '
        Me.chkcategory.AutoSize = True
        Me.chkcategory.BackColor = System.Drawing.Color.Transparent
        Me.chkcategory.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkcategory.Location = New System.Drawing.Point(286, 57)
        Me.chkcategory.Name = "chkcategory"
        Me.chkcategory.Size = New System.Drawing.Size(77, 18)
        Me.chkcategory.TabIndex = 347
        Me.chkcategory.Text = "Select All"
        Me.chkcategory.UseVisualStyleBackColor = False
        '
        'chkitem
        '
        Me.chkitem.AutoSize = True
        Me.chkitem.BackColor = System.Drawing.Color.Transparent
        Me.chkitem.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkitem.Location = New System.Drawing.Point(31, 57)
        Me.chkitem.Name = "chkitem"
        Me.chkitem.Size = New System.Drawing.Size(77, 18)
        Me.chkitem.TabIndex = 347
        Me.chkitem.Text = "Select All"
        Me.chkitem.UseVisualStyleBackColor = False
        '
        'txtTempName
        '
        Me.txtTempName.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTempName.Location = New System.Drawing.Point(274, 21)
        Me.txtTempName.Name = "txtTempName"
        Me.txtTempName.Size = New System.Drawing.Size(231, 22)
        Me.txtTempName.TabIndex = 348
        Me.txtTempName.Visible = False
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.chkdate)
        Me.BlendPanel1.Controls.Add(Me.GroupBox1)
        Me.BlendPanel1.Controls.Add(Me.GroupBox2)
        Me.BlendPanel1.Controls.Add(Me.Label1)
        Me.BlendPanel1.Controls.Add(Me.GroupBox3)
        Me.BlendPanel1.Controls.Add(Me.cmdExit)
        Me.BlendPanel1.Controls.Add(Me.cmdShowReport)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(522, 485)
        Me.BlendPanel1.TabIndex = 349
        '
        'GCHK
        '
        Me.GCHK.HeaderText = ""
        Me.GCHK.Name = "GCHK"
        Me.GCHK.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GCHK.Width = 35
        '
        'GITEMNAME
        '
        Me.GITEMNAME.HeaderText = "Item Name"
        Me.GITEMNAME.Name = "GITEMNAME"
        Me.GITEMNAME.ReadOnly = True
        Me.GITEMNAME.Width = 150
        '
        'StockFilter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(522, 485)
        Me.Controls.Add(Me.txtTempName)
        Me.Controls.Add(Me.chkitem)
        Me.Controls.Add(Me.chkcategory)
        Me.Controls.Add(Me.cmbname)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtpurity)
        Me.Controls.Add(Me.dtpto)
        Me.Controls.Add(Me.dtpfrom)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "StockFilter"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Stock Filter"
        CType(Me.griditem, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridcategory, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents griditem As System.Windows.Forms.DataGridView
    Friend WithEvents gridcategory As System.Windows.Forms.DataGridView
    Friend WithEvents txtpurity As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkdate As System.Windows.Forms.CheckBox
    Friend WithEvents dtpto As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpfrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents cmdShowReport As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbname As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DataGridViewCheckBoxColumn1 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chkcategory As System.Windows.Forms.CheckBox
    Friend WithEvents chkitem As System.Windows.Forms.CheckBox
    Friend WithEvents txtcategory As System.Windows.Forms.TextBox
    Friend WithEvents txtitemname As System.Windows.Forms.TextBox
    Friend WithEvents txtTempName As System.Windows.Forms.TextBox
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents GCHK As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents GITEMNAME As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
