<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CashBook
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CashBook))
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.lblamtbal = New System.Windows.Forms.Label()
        Me.lblfinebal = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.tstxtbillno = New System.Windows.Forms.TextBox()
        Me.TXTTOTALAMT = New System.Windows.Forms.TextBox()
        Me.TXTAMOUNT = New System.Windows.Forms.TextBox()
        Me.TXTNARR = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.CMBNAME = New System.Windows.Forms.ComboBox()
        Me.cmddelete = New System.Windows.Forms.Button()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TXTENTRYNO = New System.Windows.Forms.TextBox()
        Me.lblsrno = New System.Windows.Forms.Label()
        Me.ENTRYDATE = New System.Windows.Forms.DateTimePicker()
        Me.CMBCODE = New System.Windows.Forms.ComboBox()
        Me.cmdclear = New System.Windows.Forms.Button()
        Me.cmdok = New System.Windows.Forms.Button()
        Me.TXTSRNO = New System.Windows.Forms.TextBox()
        Me.GRIDCASH = New System.Windows.Forms.DataGridView()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.OpenToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.SaveToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.PrintToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripdelete = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolprevious = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolnext = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.EP = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.LBLGRIDBALAMT = New System.Windows.Forms.Label()
        Me.LBLGRIDBALFINEWT = New System.Windows.Forms.Label()
        Me.GSRNO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GCODE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GNARR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GAMOUNT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GBALFINEWT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GBALAMOUNT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BlendPanel1.SuspendLayout()
        CType(Me.GRIDCASH, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.Color.White)
        Me.BlendPanel1.Controls.Add(Me.LBLGRIDBALFINEWT)
        Me.BlendPanel1.Controls.Add(Me.LBLGRIDBALAMT)
        Me.BlendPanel1.Controls.Add(Me.lblamtbal)
        Me.BlendPanel1.Controls.Add(Me.lblfinebal)
        Me.BlendPanel1.Controls.Add(Me.Label8)
        Me.BlendPanel1.Controls.Add(Me.Label7)
        Me.BlendPanel1.Controls.Add(Me.tstxtbillno)
        Me.BlendPanel1.Controls.Add(Me.TXTTOTALAMT)
        Me.BlendPanel1.Controls.Add(Me.TXTAMOUNT)
        Me.BlendPanel1.Controls.Add(Me.TXTNARR)
        Me.BlendPanel1.Controls.Add(Me.Label6)
        Me.BlendPanel1.Controls.Add(Me.CMBNAME)
        Me.BlendPanel1.Controls.Add(Me.cmddelete)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.Label3)
        Me.BlendPanel1.Controls.Add(Me.Label1)
        Me.BlendPanel1.Controls.Add(Me.TXTENTRYNO)
        Me.BlendPanel1.Controls.Add(Me.lblsrno)
        Me.BlendPanel1.Controls.Add(Me.ENTRYDATE)
        Me.BlendPanel1.Controls.Add(Me.CMBCODE)
        Me.BlendPanel1.Controls.Add(Me.cmdclear)
        Me.BlendPanel1.Controls.Add(Me.cmdok)
        Me.BlendPanel1.Controls.Add(Me.TXTSRNO)
        Me.BlendPanel1.Controls.Add(Me.GRIDCASH)
        Me.BlendPanel1.Controls.Add(Me.ToolStrip1)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1034, 562)
        Me.BlendPanel1.TabIndex = 0
        '
        'lblamtbal
        '
        Me.lblamtbal.BackColor = System.Drawing.Color.Transparent
        Me.lblamtbal.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblamtbal.Location = New System.Drawing.Point(558, 68)
        Me.lblamtbal.Name = "lblamtbal"
        Me.lblamtbal.Size = New System.Drawing.Size(70, 15)
        Me.lblamtbal.TabIndex = 761
        Me.lblamtbal.Text = "0.000"
        Me.lblamtbal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblfinebal
        '
        Me.lblfinebal.BackColor = System.Drawing.Color.Transparent
        Me.lblfinebal.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblfinebal.Location = New System.Drawing.Point(558, 39)
        Me.lblfinebal.Name = "lblfinebal"
        Me.lblfinebal.Size = New System.Drawing.Size(70, 15)
        Me.lblfinebal.TabIndex = 760
        Me.lblfinebal.Text = "0.000"
        Me.lblfinebal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(526, 68)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(34, 14)
        Me.Label8.TabIndex = 759
        Me.Label8.Text = "Amt :"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(523, 39)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(37, 14)
        Me.Label7.TabIndex = 758
        Me.Label7.Text = "Fine :"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tstxtbillno
        '
        Me.tstxtbillno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tstxtbillno.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tstxtbillno.Location = New System.Drawing.Point(245, 2)
        Me.tstxtbillno.Name = "tstxtbillno"
        Me.tstxtbillno.Size = New System.Drawing.Size(58, 22)
        Me.tstxtbillno.TabIndex = 9
        Me.tstxtbillno.TabStop = False
        Me.tstxtbillno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTTOTALAMT
        '
        Me.TXTTOTALAMT.BackColor = System.Drawing.Color.Linen
        Me.TXTTOTALAMT.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTTOTALAMT.Location = New System.Drawing.Point(708, 502)
        Me.TXTTOTALAMT.Name = "TXTTOTALAMT"
        Me.TXTTOTALAMT.ReadOnly = True
        Me.TXTTOTALAMT.Size = New System.Drawing.Size(80, 23)
        Me.TXTTOTALAMT.TabIndex = 757
        Me.TXTTOTALAMT.TabStop = False
        Me.TXTTOTALAMT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTAMOUNT
        '
        Me.TXTAMOUNT.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTAMOUNT.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTAMOUNT.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.TXTAMOUNT.Location = New System.Drawing.Point(712, 100)
        Me.TXTAMOUNT.Name = "TXTAMOUNT"
        Me.TXTAMOUNT.Size = New System.Drawing.Size(80, 23)
        Me.TXTAMOUNT.TabIndex = 4
        Me.TXTAMOUNT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTNARR
        '
        Me.TXTNARR.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTNARR.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.TXTNARR.Location = New System.Drawing.Point(212, 100)
        Me.TXTNARR.Name = "TXTNARR"
        Me.TXTNARR.Size = New System.Drawing.Size(500, 23)
        Me.TXTNARR.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(67, 43)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 15)
        Me.Label6.TabIndex = 750
        Me.Label6.Text = "A/C Code"
        '
        'CMBNAME
        '
        Me.CMBNAME.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBNAME.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBNAME.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBNAME.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBNAME.FormattingEnabled = True
        Me.CMBNAME.Location = New System.Drawing.Point(124, 39)
        Me.CMBNAME.MaxDropDownItems = 14
        Me.CMBNAME.Name = "CMBNAME"
        Me.CMBNAME.Size = New System.Drawing.Size(254, 23)
        Me.CMBNAME.TabIndex = 1
        '
        'cmddelete
        '
        Me.cmddelete.BackColor = System.Drawing.Color.Transparent
        Me.cmddelete.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmddelete.FlatAppearance.BorderSize = 0
        Me.cmddelete.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmddelete.ForeColor = System.Drawing.Color.Black
        Me.cmddelete.Location = New System.Drawing.Point(428, 513)
        Me.cmddelete.Name = "cmddelete"
        Me.cmddelete.Size = New System.Drawing.Size(85, 28)
        Me.cmddelete.TabIndex = 7
        Me.cmddelete.Text = "&Delete"
        Me.cmddelete.UseVisualStyleBackColor = False
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.Black
        Me.cmdexit.Location = New System.Drawing.Point(519, 513)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(85, 28)
        Me.cmdexit.TabIndex = 8
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(667, 65)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(32, 15)
        Me.Label3.TabIndex = 746
        Me.Label3.Text = "Date"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(674, 506)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 15)
        Me.Label1.TabIndex = 742
        Me.Label1.Text = "Total"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TXTENTRYNO
        '
        Me.TXTENTRYNO.BackColor = System.Drawing.Color.Linen
        Me.TXTENTRYNO.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTENTRYNO.Location = New System.Drawing.Point(702, 35)
        Me.TXTENTRYNO.Name = "TXTENTRYNO"
        Me.TXTENTRYNO.ReadOnly = True
        Me.TXTENTRYNO.Size = New System.Drawing.Size(88, 23)
        Me.TXTENTRYNO.TabIndex = 739
        Me.TXTENTRYNO.TabStop = False
        Me.TXTENTRYNO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblsrno
        '
        Me.lblsrno.AutoSize = True
        Me.lblsrno.BackColor = System.Drawing.Color.Transparent
        Me.lblsrno.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblsrno.Location = New System.Drawing.Point(645, 39)
        Me.lblsrno.Name = "lblsrno"
        Me.lblsrno.Size = New System.Drawing.Size(56, 15)
        Me.lblsrno.TabIndex = 740
        Me.lblsrno.Text = "Entry No."
        Me.lblsrno.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ENTRYDATE
        '
        Me.ENTRYDATE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ENTRYDATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.ENTRYDATE.Location = New System.Drawing.Point(702, 61)
        Me.ENTRYDATE.Name = "ENTRYDATE"
        Me.ENTRYDATE.Size = New System.Drawing.Size(90, 23)
        Me.ENTRYDATE.TabIndex = 0
        '
        'CMBCODE
        '
        Me.CMBCODE.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBCODE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBCODE.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBCODE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBCODE.FormattingEnabled = True
        Me.CMBCODE.Location = New System.Drawing.Point(62, 100)
        Me.CMBCODE.MaxDropDownItems = 14
        Me.CMBCODE.Name = "CMBCODE"
        Me.CMBCODE.Size = New System.Drawing.Size(150, 23)
        Me.CMBCODE.TabIndex = 2
        '
        'cmdclear
        '
        Me.cmdclear.BackColor = System.Drawing.Color.Transparent
        Me.cmdclear.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdclear.FlatAppearance.BorderSize = 0
        Me.cmdclear.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdclear.ForeColor = System.Drawing.Color.Black
        Me.cmdclear.Location = New System.Drawing.Point(337, 513)
        Me.cmdclear.Name = "cmdclear"
        Me.cmdclear.Size = New System.Drawing.Size(85, 28)
        Me.cmdclear.TabIndex = 6
        Me.cmdclear.Text = "&Clear"
        Me.cmdclear.UseVisualStyleBackColor = False
        '
        'cmdok
        '
        Me.cmdok.BackColor = System.Drawing.Color.Transparent
        Me.cmdok.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdok.FlatAppearance.BorderSize = 0
        Me.cmdok.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdok.ForeColor = System.Drawing.Color.Black
        Me.cmdok.Location = New System.Drawing.Point(246, 513)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(85, 28)
        Me.cmdok.TabIndex = 5
        Me.cmdok.Text = "&Save"
        Me.cmdok.UseVisualStyleBackColor = False
        '
        'TXTSRNO
        '
        Me.TXTSRNO.BackColor = System.Drawing.Color.Linen
        Me.TXTSRNO.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTSRNO.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.TXTSRNO.Location = New System.Drawing.Point(22, 100)
        Me.TXTSRNO.Name = "TXTSRNO"
        Me.TXTSRNO.ReadOnly = True
        Me.TXTSRNO.Size = New System.Drawing.Size(40, 23)
        Me.TXTSRNO.TabIndex = 724
        Me.TXTSRNO.TabStop = False
        '
        'GRIDCASH
        '
        Me.GRIDCASH.AllowUserToAddRows = False
        Me.GRIDCASH.AllowUserToDeleteRows = False
        Me.GRIDCASH.AllowUserToResizeColumns = False
        Me.GRIDCASH.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Empty
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Black
        Me.GRIDCASH.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.GRIDCASH.BackgroundColor = System.Drawing.Color.White
        Me.GRIDCASH.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.GRIDCASH.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.GRIDCASH.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.GRIDCASH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GRIDCASH.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.GSRNO, Me.GCODE, Me.GNARR, Me.GAMOUNT, Me.GBALFINEWT, Me.GBALAMOUNT})
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GRIDCASH.DefaultCellStyle = DataGridViewCellStyle6
        Me.GRIDCASH.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.GRIDCASH.GridColor = System.Drawing.SystemColors.Control
        Me.GRIDCASH.Location = New System.Drawing.Point(22, 123)
        Me.GRIDCASH.MultiSelect = False
        Me.GRIDCASH.Name = "GRIDCASH"
        Me.GRIDCASH.RowHeadersVisible = False
        Me.GRIDCASH.RowHeadersWidth = 30
        Me.GRIDCASH.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.White
        Me.GRIDCASH.RowsDefaultCellStyle = DataGridViewCellStyle7
        Me.GRIDCASH.RowTemplate.Height = 20
        Me.GRIDCASH.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GRIDCASH.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.GRIDCASH.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GRIDCASH.Size = New System.Drawing.Size(1002, 373)
        Me.GRIDCASH.TabIndex = 735
        Me.GRIDCASH.TabStop = False
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ToolStrip1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenToolStripButton, Me.SaveToolStripButton, Me.PrintToolStripButton, Me.ToolStripdelete, Me.ToolStripSeparator3, Me.toolprevious, Me.ToolStripSeparator1, Me.toolnext, Me.ToolStripSeparator2})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1034, 25)
        Me.ToolStrip1.TabIndex = 721
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
        'PrintToolStripButton
        '
        Me.PrintToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PrintToolStripButton.Image = CType(resources.GetObject("PrintToolStripButton.Image"), System.Drawing.Image)
        Me.PrintToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PrintToolStripButton.Name = "PrintToolStripButton"
        Me.PrintToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.PrintToolStripButton.Text = "&Print"
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
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'toolprevious
        '
        Me.toolprevious.AccessibleDescription = " "
        Me.toolprevious.Image = Global.Magic_Gold.My.Resources.Resources.POINT02
        Me.toolprevious.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolprevious.Name = "toolprevious"
        Me.toolprevious.Size = New System.Drawing.Size(73, 22)
        Me.toolprevious.Text = "Previous"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.AccessibleDescription = " "
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'toolnext
        '
        Me.toolnext.Image = Global.Magic_Gold.My.Resources.Resources.POINT04
        Me.toolnext.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolnext.Name = "toolnext"
        Me.toolnext.Size = New System.Drawing.Size(51, 22)
        Me.toolnext.Text = "Next"
        Me.toolnext.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'EP
        '
        Me.EP.BlinkRate = 0
        Me.EP.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.EP.ContainerControl = Me
        '
        'LBLGRIDBALAMT
        '
        Me.LBLGRIDBALAMT.BackColor = System.Drawing.Color.Transparent
        Me.LBLGRIDBALAMT.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLGRIDBALAMT.Location = New System.Drawing.Point(897, 104)
        Me.LBLGRIDBALAMT.Name = "LBLGRIDBALAMT"
        Me.LBLGRIDBALAMT.Size = New System.Drawing.Size(94, 15)
        Me.LBLGRIDBALAMT.TabIndex = 762
        Me.LBLGRIDBALAMT.Text = "0.000"
        Me.LBLGRIDBALAMT.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LBLGRIDBALFINEWT
        '
        Me.LBLGRIDBALFINEWT.BackColor = System.Drawing.Color.Transparent
        Me.LBLGRIDBALFINEWT.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLGRIDBALFINEWT.Location = New System.Drawing.Point(794, 104)
        Me.LBLGRIDBALFINEWT.Name = "LBLGRIDBALFINEWT"
        Me.LBLGRIDBALFINEWT.Size = New System.Drawing.Size(94, 15)
        Me.LBLGRIDBALFINEWT.TabIndex = 763
        Me.LBLGRIDBALFINEWT.Text = "0.000"
        Me.LBLGRIDBALFINEWT.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GSRNO
        '
        Me.GSRNO.HeaderText = "Sr."
        Me.GSRNO.Name = "GSRNO"
        Me.GSRNO.ReadOnly = True
        Me.GSRNO.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GSRNO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GSRNO.Width = 40
        '
        'GCODE
        '
        Me.GCODE.HeaderText = "To (A/C Code)"
        Me.GCODE.Name = "GCODE"
        Me.GCODE.ReadOnly = True
        Me.GCODE.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GCODE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GCODE.Width = 150
        '
        'GNARR
        '
        Me.GNARR.HeaderText = "Narration"
        Me.GNARR.Name = "GNARR"
        Me.GNARR.ReadOnly = True
        Me.GNARR.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GNARR.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GNARR.Width = 500
        '
        'GAMOUNT
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.GAMOUNT.DefaultCellStyle = DataGridViewCellStyle3
        Me.GAMOUNT.HeaderText = "Amount"
        Me.GAMOUNT.Name = "GAMOUNT"
        Me.GAMOUNT.ReadOnly = True
        Me.GAMOUNT.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GAMOUNT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GAMOUNT.Width = 80
        '
        'GBALFINEWT
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.Linen
        Me.GBALFINEWT.DefaultCellStyle = DataGridViewCellStyle4
        Me.GBALFINEWT.HeaderText = "Bal Fine Wt"
        Me.GBALFINEWT.Name = "GBALFINEWT"
        Me.GBALFINEWT.ReadOnly = True
        Me.GBALFINEWT.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GBALFINEWT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'GBALAMOUNT
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.Linen
        Me.GBALAMOUNT.DefaultCellStyle = DataGridViewCellStyle5
        Me.GBALAMOUNT.HeaderText = "Bal Amount"
        Me.GBALAMOUNT.Name = "GBALAMOUNT"
        Me.GBALAMOUNT.ReadOnly = True
        Me.GBALAMOUNT.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GBALAMOUNT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'CashBook
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1034, 562)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "CashBook"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Cash Book"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.GRIDCASH, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents tstxtbillno As System.Windows.Forms.TextBox
    Friend WithEvents TXTTOTALAMT As System.Windows.Forms.TextBox
    Friend WithEvents TXTAMOUNT As System.Windows.Forms.TextBox
    Friend WithEvents TXTNARR As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents CMBNAME As System.Windows.Forms.ComboBox
    Friend WithEvents cmddelete As System.Windows.Forms.Button
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TXTENTRYNO As System.Windows.Forms.TextBox
    Friend WithEvents lblsrno As System.Windows.Forms.Label
    Friend WithEvents ENTRYDATE As System.Windows.Forms.DateTimePicker
    Friend WithEvents CMBCODE As System.Windows.Forms.ComboBox
    Friend WithEvents cmdclear As System.Windows.Forms.Button
    Friend WithEvents cmdok As System.Windows.Forms.Button
    Friend WithEvents TXTSRNO As System.Windows.Forms.TextBox
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents OpenToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents SaveToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents PrintToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripdelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolprevious As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolnext As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents EP As System.Windows.Forms.ErrorProvider
    Friend WithEvents GRIDCASH As System.Windows.Forms.DataGridView
    Friend WithEvents lblamtbal As Label
    Friend WithEvents lblfinebal As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents LBLGRIDBALFINEWT As Label
    Friend WithEvents LBLGRIDBALAMT As Label
    Friend WithEvents GSRNO As DataGridViewTextBoxColumn
    Friend WithEvents GCODE As DataGridViewTextBoxColumn
    Friend WithEvents GNARR As DataGridViewTextBoxColumn
    Friend WithEvents GAMOUNT As DataGridViewTextBoxColumn
    Friend WithEvents GBALFINEWT As DataGridViewTextBoxColumn
    Friend WithEvents GBALAMOUNT As DataGridViewTextBoxColumn
End Class
