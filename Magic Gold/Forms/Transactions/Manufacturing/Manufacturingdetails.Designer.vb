<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Manufacturingdetails
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Manufacturingdetails))
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.gridmfg = New System.Windows.Forms.DataGridView()
        Me.cmdok = New System.Windows.Forms.Button()
        Me.lbl = New System.Windows.Forms.Label()
        Me.newmfg = New System.Windows.Forms.ToolStripLabel()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.PrintToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.cmbselect = New System.Windows.Forms.ComboBox()
        Me.txttempname = New System.Windows.Forms.TextBox()
        Me.txtname = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.RBALL = New System.Windows.Forms.RadioButton()
        Me.RBINCOMPLETE = New System.Windows.Forms.RadioButton()
        Me.RBCOMPLETED = New System.Windows.Forms.RadioButton()
        Me.TXTTOTAL = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.chkdate = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dtpto = New System.Windows.Forms.DateTimePicker()
        Me.dtpfrom = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TXTTOTALNETT = New System.Windows.Forms.TextBox()
        Me.TXTTOTALLOTS = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.RBLOTFAIL = New System.Windows.Forms.RadioButton()
        Me.TXTBARCODE = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        CType(Me.gridmfg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'gridmfg
        '
        Me.gridmfg.AllowUserToAddRows = False
        Me.gridmfg.AllowUserToDeleteRows = False
        Me.gridmfg.AllowUserToResizeColumns = False
        Me.gridmfg.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer))
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Black
        Me.gridmfg.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.gridmfg.BackgroundColor = System.Drawing.Color.White
        Me.gridmfg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.gridmfg.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gridmfg.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.gridmfg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gridmfg.DefaultCellStyle = DataGridViewCellStyle3
        Me.gridmfg.GridColor = System.Drawing.SystemColors.ControlText
        Me.gridmfg.Location = New System.Drawing.Point(18, 107)
        Me.gridmfg.Margin = New System.Windows.Forms.Padding(2)
        Me.gridmfg.MultiSelect = False
        Me.gridmfg.Name = "gridmfg"
        Me.gridmfg.ReadOnly = True
        Me.gridmfg.RowHeadersVisible = False
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Black
        Me.gridmfg.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.gridmfg.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.gridmfg.Size = New System.Drawing.Size(975, 419)
        Me.gridmfg.TabIndex = 7
        '
        'cmdok
        '
        Me.cmdok.BackColor = System.Drawing.Color.Transparent
        Me.cmdok.FlatAppearance.BorderSize = 0
        Me.cmdok.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdok.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdok.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdok.Image = Global.Magic_Gold.My.Resources.Resources.ok
        Me.cmdok.Location = New System.Drawing.Point(419, 531)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(80, 24)
        Me.cmdok.TabIndex = 8
        Me.cmdok.UseVisualStyleBackColor = False
        '
        'lbl
        '
        Me.lbl.AutoSize = True
        Me.lbl.BackColor = System.Drawing.Color.Transparent
        Me.lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbl.Location = New System.Drawing.Point(12, 31)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(120, 25)
        Me.lbl.TabIndex = 306
        Me.lbl.Text = "Mfg Details"
        '
        'newmfg
        '
        Me.newmfg.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.newmfg.Image = Global.Magic_Gold.My.Resources.Resources.Be_Navigator
        Me.newmfg.Name = "newmfg"
        Me.newmfg.Size = New System.Drawing.Size(71, 22)
        Me.newmfg.Text = "&Add New"
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdexit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdexit.Image = Global.Magic_Gold.My.Resources.Resources._Exit
        Me.cmdexit.Location = New System.Drawing.Point(505, 531)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 24)
        Me.cmdexit.TabIndex = 9
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.newmfg, Me.ToolStripSeparator1, Me.PrintToolStripButton})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1004, 25)
        Me.ToolStrip1.TabIndex = 307
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
        'cmbselect
        '
        Me.cmbselect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbselect.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbselect.FormattingEnabled = True
        Me.cmbselect.Items.AddRange(New Object() {"", "Lot No.", "Ref No", "Name", "Process", "Purity", "Mfg No."})
        Me.cmbselect.Location = New System.Drawing.Point(18, 86)
        Me.cmbselect.Name = "cmbselect"
        Me.cmbselect.Size = New System.Drawing.Size(73, 22)
        Me.cmbselect.TabIndex = 0
        '
        'txttempname
        '
        Me.txttempname.BackColor = System.Drawing.Color.White
        Me.txttempname.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txttempname.ForeColor = System.Drawing.Color.Black
        Me.txttempname.Location = New System.Drawing.Point(298, 86)
        Me.txttempname.Multiline = True
        Me.txttempname.Name = "txttempname"
        Me.txttempname.ReadOnly = True
        Me.txttempname.Size = New System.Drawing.Size(72, 21)
        Me.txttempname.TabIndex = 311
        Me.txttempname.TabStop = False
        Me.txttempname.Visible = False
        '
        'txtname
        '
        Me.txtname.BackColor = System.Drawing.Color.White
        Me.txtname.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtname.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtname.ForeColor = System.Drawing.Color.Black
        Me.txtname.Location = New System.Drawing.Point(91, 86)
        Me.txtname.Multiline = True
        Me.txtname.Name = "txtname"
        Me.txtname.Size = New System.Drawing.Size(201, 21)
        Me.txtname.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(15, 67)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(116, 14)
        Me.Label1.TabIndex = 308
        Me.Label1.Text = "Select a Lot to Change"
        '
        'RBALL
        '
        Me.RBALL.AutoSize = True
        Me.RBALL.Location = New System.Drawing.Point(376, 84)
        Me.RBALL.Name = "RBALL"
        Me.RBALL.Size = New System.Drawing.Size(38, 18)
        Me.RBALL.TabIndex = 2
        Me.RBALL.Text = "All"
        Me.RBALL.UseVisualStyleBackColor = True
        '
        'RBINCOMPLETE
        '
        Me.RBINCOMPLETE.AutoSize = True
        Me.RBINCOMPLETE.Checked = True
        Me.RBINCOMPLETE.Location = New System.Drawing.Point(422, 84)
        Me.RBINCOMPLETE.Name = "RBINCOMPLETE"
        Me.RBINCOMPLETE.Size = New System.Drawing.Size(74, 18)
        Me.RBINCOMPLETE.TabIndex = 3
        Me.RBINCOMPLETE.TabStop = True
        Me.RBINCOMPLETE.Text = "In Process"
        Me.RBINCOMPLETE.UseVisualStyleBackColor = True
        '
        'RBCOMPLETED
        '
        Me.RBCOMPLETED.AutoSize = True
        Me.RBCOMPLETED.Location = New System.Drawing.Point(508, 84)
        Me.RBCOMPLETED.Name = "RBCOMPLETED"
        Me.RBCOMPLETED.Size = New System.Drawing.Size(78, 18)
        Me.RBCOMPLETED.TabIndex = 4
        Me.RBCOMPLETED.Text = "Completed"
        Me.RBCOMPLETED.UseVisualStyleBackColor = True
        '
        'TXTTOTAL
        '
        Me.TXTTOTAL.BackColor = System.Drawing.Color.White
        Me.TXTTOTAL.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTTOTAL.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTTOTAL.ForeColor = System.Drawing.Color.Black
        Me.TXTTOTAL.Location = New System.Drawing.Point(667, 529)
        Me.TXTTOTAL.Multiline = True
        Me.TXTTOTAL.Name = "TXTTOTAL"
        Me.TXTTOTAL.Size = New System.Drawing.Size(124, 21)
        Me.TXTTOTAL.TabIndex = 315
        Me.TXTTOTAL.TabStop = False
        Me.TXTTOTAL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(630, 532)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(31, 14)
        Me.Label2.TabIndex = 316
        Me.Label2.Text = "Total"
        '
        'chkdate
        '
        Me.chkdate.AutoSize = True
        Me.chkdate.BackColor = System.Drawing.Color.Transparent
        Me.chkdate.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkdate.Location = New System.Drawing.Point(760, 42)
        Me.chkdate.Name = "chkdate"
        Me.chkdate.Size = New System.Drawing.Size(49, 18)
        Me.chkdate.TabIndex = 5
        Me.chkdate.Text = "Date"
        Me.chkdate.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.dtpto)
        Me.GroupBox1.Controls.Add(Me.dtpfrom)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(749, 42)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(244, 60)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        '
        'dtpto
        '
        Me.dtpto.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpto.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpto.Location = New System.Drawing.Point(147, 23)
        Me.dtpto.Name = "dtpto"
        Me.dtpto.Size = New System.Drawing.Size(81, 22)
        Me.dtpto.TabIndex = 1
        '
        'dtpfrom
        '
        Me.dtpfrom.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpfrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpfrom.Location = New System.Drawing.Point(42, 23)
        Me.dtpfrom.Name = "dtpfrom"
        Me.dtpfrom.Size = New System.Drawing.Size(81, 22)
        Me.dtpfrom.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(7, 27)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(33, 14)
        Me.Label3.TabIndex = 272
        Me.Label3.Text = "From"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(126, 27)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(18, 14)
        Me.Label4.TabIndex = 273
        Me.Label4.Text = "To"
        '
        'TXTTOTALNETT
        '
        Me.TXTTOTALNETT.BackColor = System.Drawing.Color.White
        Me.TXTTOTALNETT.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTTOTALNETT.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTTOTALNETT.ForeColor = System.Drawing.Color.Black
        Me.TXTTOTALNETT.Location = New System.Drawing.Point(815, 529)
        Me.TXTTOTALNETT.Multiline = True
        Me.TXTTOTALNETT.Name = "TXTTOTALNETT"
        Me.TXTTOTALNETT.Size = New System.Drawing.Size(124, 21)
        Me.TXTTOTALNETT.TabIndex = 317
        Me.TXTTOTALNETT.TabStop = False
        Me.TXTTOTALNETT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTTOTALLOTS
        '
        Me.TXTTOTALLOTS.BackColor = System.Drawing.Color.White
        Me.TXTTOTALLOTS.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTTOTALLOTS.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTTOTALLOTS.ForeColor = System.Drawing.Color.Black
        Me.TXTTOTALLOTS.Location = New System.Drawing.Point(90, 531)
        Me.TXTTOTALLOTS.Multiline = True
        Me.TXTTOTALLOTS.Name = "TXTTOTALLOTS"
        Me.TXTTOTALLOTS.Size = New System.Drawing.Size(57, 21)
        Me.TXTTOTALLOTS.TabIndex = 318
        Me.TXTTOTALLOTS.TabStop = False
        Me.TXTTOTALLOTS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(30, 535)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(54, 14)
        Me.Label5.TabIndex = 319
        Me.Label5.Text = "Total Lots"
        '
        'RBLOTFAIL
        '
        Me.RBLOTFAIL.AutoSize = True
        Me.RBLOTFAIL.Location = New System.Drawing.Point(598, 84)
        Me.RBLOTFAIL.Name = "RBLOTFAIL"
        Me.RBLOTFAIL.Size = New System.Drawing.Size(61, 18)
        Me.RBLOTFAIL.TabIndex = 320
        Me.RBLOTFAIL.Text = "Lot Fail"
        Me.RBLOTFAIL.UseVisualStyleBackColor = True
        '
        'TXTBARCODE
        '
        Me.TXTBARCODE.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTBARCODE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTBARCODE.Location = New System.Drawing.Point(209, 58)
        Me.TXTBARCODE.Name = "TXTBARCODE"
        Me.TXTBARCODE.Size = New System.Drawing.Size(161, 22)
        Me.TXTBARCODE.TabIndex = 471
        Me.TXTBARCODE.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(152, 62)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(51, 14)
        Me.Label9.TabIndex = 470
        Me.Label9.Text = "Bar Code"
        '
        'Manufacturingdetails
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1004, 562)
        Me.Controls.Add(Me.TXTBARCODE)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.RBLOTFAIL)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TXTTOTALLOTS)
        Me.Controls.Add(Me.TXTTOTALNETT)
        Me.Controls.Add(Me.chkdate)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TXTTOTAL)
        Me.Controls.Add(Me.RBCOMPLETED)
        Me.Controls.Add(Me.RBINCOMPLETE)
        Me.Controls.Add(Me.RBALL)
        Me.Controls.Add(Me.cmbselect)
        Me.Controls.Add(Me.txttempname)
        Me.Controls.Add(Me.txtname)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.gridmfg)
        Me.Controls.Add(Me.cmdok)
        Me.Controls.Add(Me.lbl)
        Me.Controls.Add(Me.cmdexit)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "Manufacturingdetails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Mfg Details"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.gridmfg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents gridmfg As System.Windows.Forms.DataGridView
    Friend WithEvents cmdok As System.Windows.Forms.Button
    Friend WithEvents lbl As System.Windows.Forms.Label
    Friend WithEvents newmfg As System.Windows.Forms.ToolStripLabel
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Private WithEvents cmbselect As System.Windows.Forms.ComboBox
    Friend WithEvents txttempname As System.Windows.Forms.TextBox
    Friend WithEvents txtname As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PrintToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents RBALL As System.Windows.Forms.RadioButton
    Friend WithEvents RBINCOMPLETE As System.Windows.Forms.RadioButton
    Friend WithEvents RBCOMPLETED As System.Windows.Forms.RadioButton
    Friend WithEvents TXTTOTAL As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents chkdate As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dtpto As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpfrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TXTTOTALNETT As System.Windows.Forms.TextBox
    Friend WithEvents TXTTOTALLOTS As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents RBLOTFAIL As System.Windows.Forms.RadioButton
    Friend WithEvents TXTBARCODE As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
End Class
