<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MaterialReceipt
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MaterialReceipt))
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.tstxtbillno = New System.Windows.Forms.TextBox
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.OpenToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.SaveToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.PrintToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.ToolStripdelete = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.toolprevious = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.toolnext = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.TXTSRNO = New System.Windows.Forms.TextBox
        Me.GRIDREC = New System.Windows.Forms.DataGridView
        Me.GSRNO = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.gdate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GITEMNAME = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GTYPE = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GSIZE = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GCOLOR = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GPCS = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GCTWT = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TXTCTWT = New System.Windows.Forms.TextBox
        Me.TXTPCS = New System.Windows.Forms.TextBox
        Me.lbl = New System.Windows.Forms.Label
        Me.cmddelete = New System.Windows.Forms.Button
        Me.cmdclear = New System.Windows.Forms.Button
        Me.cmdok = New System.Windows.Forms.Button
        Me.cmdexit = New System.Windows.Forms.Button
        Me.CMDSELECTORDER = New System.Windows.Forms.Button
        Me.CMBTYPE = New System.Windows.Forms.ComboBox
        Me.CMBSIZE = New System.Windows.Forms.ComboBox
        Me.CMBCOLOR = New System.Windows.Forms.ComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.TXTORDERNO = New System.Windows.Forms.TextBox
        Me.RECDATE = New System.Windows.Forms.DateTimePicker
        Me.CMBITEMNAME = New System.Windows.Forms.ComboBox
        Me.TXTRECNO = New System.Windows.Forms.TextBox
        Me.lblsrno = New System.Windows.Forms.Label
        Me.TXTTOTALCTWT = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.TXTTOTALPCS = New System.Windows.Forms.TextBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.TXTREMARKS = New System.Windows.Forms.TextBox
        Me.EP = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Label2 = New System.Windows.Forms.Label
        Me.TXTNAME = New System.Windows.Forms.TextBox
        Me.GRIDDATE = New System.Windows.Forms.DateTimePicker
        Me.Label3 = New System.Windows.Forms.Label
        Me.ToolStrip1.SuspendLayout()
        CType(Me.GRIDREC, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tstxtbillno
        '
        Me.tstxtbillno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tstxtbillno.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tstxtbillno.Location = New System.Drawing.Point(245, 1)
        Me.tstxtbillno.Name = "tstxtbillno"
        Me.tstxtbillno.Size = New System.Drawing.Size(58, 22)
        Me.tstxtbillno.TabIndex = 15
        Me.tstxtbillno.TabStop = False
        Me.tstxtbillno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ToolStrip1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenToolStripButton, Me.SaveToolStripButton, Me.PrintToolStripButton, Me.ToolStripdelete, Me.ToolStripSeparator3, Me.toolprevious, Me.ToolStripSeparator1, Me.toolnext, Me.ToolStripSeparator2})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(782, 25)
        Me.ToolStrip1.TabIndex = 315
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
        'TXTSRNO
        '
        Me.TXTSRNO.BackColor = System.Drawing.Color.Linen
        Me.TXTSRNO.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.TXTSRNO.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.TXTSRNO.Location = New System.Drawing.Point(18, 90)
        Me.TXTSRNO.Name = "TXTSRNO"
        Me.TXTSRNO.ReadOnly = True
        Me.TXTSRNO.Size = New System.Drawing.Size(40, 23)
        Me.TXTSRNO.TabIndex = 2
        Me.TXTSRNO.TabStop = False
        '
        'GRIDREC
        '
        Me.GRIDREC.AllowUserToAddRows = False
        Me.GRIDREC.AllowUserToDeleteRows = False
        Me.GRIDREC.AllowUserToResizeColumns = False
        Me.GRIDREC.AllowUserToResizeRows = False
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(248, Byte), Integer))
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.Black
        Me.GRIDREC.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle7
        Me.GRIDREC.BackgroundColor = System.Drawing.Color.White
        Me.GRIDREC.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.GRIDREC.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.GRIDREC.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.GRIDREC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GRIDREC.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.GSRNO, Me.gdate, Me.GITEMNAME, Me.GTYPE, Me.GSIZE, Me.GCOLOR, Me.GPCS, Me.GCTWT})
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GRIDREC.DefaultCellStyle = DataGridViewCellStyle11
        Me.GRIDREC.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.GRIDREC.GridColor = System.Drawing.SystemColors.Control
        Me.GRIDREC.Location = New System.Drawing.Point(18, 113)
        Me.GRIDREC.MultiSelect = False
        Me.GRIDREC.Name = "GRIDREC"
        Me.GRIDREC.RowHeadersVisible = False
        Me.GRIDREC.RowHeadersWidth = 30
        Me.GRIDREC.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.Black
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.White
        Me.GRIDREC.RowsDefaultCellStyle = DataGridViewCellStyle12
        Me.GRIDREC.RowTemplate.Height = 20
        Me.GRIDREC.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GRIDREC.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.GRIDREC.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GRIDREC.Size = New System.Drawing.Size(747, 164)
        Me.GRIDREC.TabIndex = 319
        Me.GRIDREC.TabStop = False
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
        'gdate
        '
        Me.gdate.HeaderText = "Date"
        Me.gdate.Name = "gdate"
        Me.gdate.ReadOnly = True
        Me.gdate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gdate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.gdate.Width = 90
        '
        'GITEMNAME
        '
        Me.GITEMNAME.HeaderText = "Item Name"
        Me.GITEMNAME.Name = "GITEMNAME"
        Me.GITEMNAME.ReadOnly = True
        Me.GITEMNAME.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GITEMNAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GITEMNAME.Width = 150
        '
        'GTYPE
        '
        Me.GTYPE.HeaderText = "Type"
        Me.GTYPE.Name = "GTYPE"
        Me.GTYPE.ReadOnly = True
        Me.GTYPE.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GTYPE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'GSIZE
        '
        Me.GSIZE.HeaderText = "Size"
        Me.GSIZE.Name = "GSIZE"
        Me.GSIZE.ReadOnly = True
        Me.GSIZE.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GSIZE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'GCOLOR
        '
        Me.GCOLOR.HeaderText = "Color"
        Me.GCOLOR.Name = "GCOLOR"
        Me.GCOLOR.ReadOnly = True
        Me.GCOLOR.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GCOLOR.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'GPCS
        '
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.GPCS.DefaultCellStyle = DataGridViewCellStyle9
        Me.GPCS.HeaderText = "Pcs"
        Me.GPCS.Name = "GPCS"
        Me.GPCS.ReadOnly = True
        Me.GPCS.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GPCS.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GPCS.Width = 60
        '
        'GCTWT
        '
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.GCTWT.DefaultCellStyle = DataGridViewCellStyle10
        Me.GCTWT.HeaderText = "Ct. Wt."
        Me.GCTWT.Name = "GCTWT"
        Me.GCTWT.ReadOnly = True
        Me.GCTWT.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GCTWT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GCTWT.Width = 80
        '
        'TXTCTWT
        '
        Me.TXTCTWT.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCTWT.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.TXTCTWT.Location = New System.Drawing.Point(658, 90)
        Me.TXTCTWT.Name = "TXTCTWT"
        Me.TXTCTWT.Size = New System.Drawing.Size(80, 23)
        Me.TXTCTWT.TabIndex = 9
        Me.TXTCTWT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTPCS
        '
        Me.TXTPCS.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTPCS.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.TXTPCS.Location = New System.Drawing.Point(598, 90)
        Me.TXTPCS.Name = "TXTPCS"
        Me.TXTPCS.Size = New System.Drawing.Size(60, 23)
        Me.TXTPCS.TabIndex = 8
        Me.TXTPCS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbl
        '
        Me.lbl.AutoSize = True
        Me.lbl.BackColor = System.Drawing.Color.Transparent
        Me.lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbl.Location = New System.Drawing.Point(7, 28)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(160, 24)
        Me.lbl.TabIndex = 324
        Me.lbl.Text = "Material Receipt"
        '
        'cmddelete
        '
        Me.cmddelete.BackColor = System.Drawing.Color.Transparent
        Me.cmddelete.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmddelete.FlatAppearance.BorderSize = 0
        Me.cmddelete.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmddelete.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmddelete.Location = New System.Drawing.Point(501, 345)
        Me.cmddelete.Name = "cmddelete"
        Me.cmddelete.Size = New System.Drawing.Size(85, 28)
        Me.cmddelete.TabIndex = 13
        Me.cmddelete.Text = "&Delete"
        Me.cmddelete.UseVisualStyleBackColor = False
        '
        'cmdclear
        '
        Me.cmdclear.BackColor = System.Drawing.Color.Transparent
        Me.cmdclear.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdclear.FlatAppearance.BorderSize = 0
        Me.cmdclear.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdclear.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdclear.Location = New System.Drawing.Point(649, 311)
        Me.cmdclear.Name = "cmdclear"
        Me.cmdclear.Size = New System.Drawing.Size(85, 28)
        Me.cmdclear.TabIndex = 12
        Me.cmdclear.Text = "&Clear"
        Me.cmdclear.UseVisualStyleBackColor = False
        '
        'cmdok
        '
        Me.cmdok.BackColor = System.Drawing.Color.Transparent
        Me.cmdok.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdok.FlatAppearance.BorderSize = 0
        Me.cmdok.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdok.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdok.Location = New System.Drawing.Point(560, 311)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(85, 28)
        Me.cmdok.TabIndex = 11
        Me.cmdok.Text = "&Save"
        Me.cmdok.UseVisualStyleBackColor = False
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdexit.Location = New System.Drawing.Point(590, 345)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(85, 28)
        Me.cmdexit.TabIndex = 14
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'CMDSELECTORDER
        '
        Me.CMDSELECTORDER.BackColor = System.Drawing.Color.Transparent
        Me.CMDSELECTORDER.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDSELECTORDER.FlatAppearance.BorderSize = 0
        Me.CMDSELECTORDER.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDSELECTORDER.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CMDSELECTORDER.Location = New System.Drawing.Point(471, 311)
        Me.CMDSELECTORDER.Name = "CMDSELECTORDER"
        Me.CMDSELECTORDER.Size = New System.Drawing.Size(85, 28)
        Me.CMDSELECTORDER.TabIndex = 1
        Me.CMDSELECTORDER.Text = "Select Order"
        Me.CMDSELECTORDER.UseVisualStyleBackColor = False
        '
        'CMBTYPE
        '
        Me.CMBTYPE.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBTYPE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBTYPE.BackColor = System.Drawing.Color.White
        Me.CMBTYPE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBTYPE.FormattingEnabled = True
        Me.CMBTYPE.Location = New System.Drawing.Point(298, 90)
        Me.CMBTYPE.MaxDropDownItems = 14
        Me.CMBTYPE.Name = "CMBTYPE"
        Me.CMBTYPE.Size = New System.Drawing.Size(100, 23)
        Me.CMBTYPE.TabIndex = 5
        '
        'CMBSIZE
        '
        Me.CMBSIZE.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBSIZE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBSIZE.BackColor = System.Drawing.Color.White
        Me.CMBSIZE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBSIZE.FormattingEnabled = True
        Me.CMBSIZE.Location = New System.Drawing.Point(398, 90)
        Me.CMBSIZE.MaxDropDownItems = 14
        Me.CMBSIZE.Name = "CMBSIZE"
        Me.CMBSIZE.Size = New System.Drawing.Size(100, 23)
        Me.CMBSIZE.TabIndex = 6
        '
        'CMBCOLOR
        '
        Me.CMBCOLOR.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBCOLOR.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBCOLOR.BackColor = System.Drawing.Color.White
        Me.CMBCOLOR.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBCOLOR.FormattingEnabled = True
        Me.CMBCOLOR.Location = New System.Drawing.Point(498, 90)
        Me.CMBCOLOR.MaxDropDownItems = 14
        Me.CMBCOLOR.Name = "CMBCOLOR"
        Me.CMBCOLOR.Size = New System.Drawing.Size(100, 23)
        Me.CMBCOLOR.TabIndex = 7
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(252, 65)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(57, 15)
        Me.Label8.TabIndex = 682
        Me.Label8.Text = "Order No"
        '
        'TXTORDERNO
        '
        Me.TXTORDERNO.BackColor = System.Drawing.Color.Linen
        Me.TXTORDERNO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTORDERNO.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTORDERNO.Location = New System.Drawing.Point(311, 61)
        Me.TXTORDERNO.Name = "TXTORDERNO"
        Me.TXTORDERNO.ReadOnly = True
        Me.TXTORDERNO.Size = New System.Drawing.Size(152, 23)
        Me.TXTORDERNO.TabIndex = 681
        Me.TXTORDERNO.TabStop = False
        '
        'RECDATE
        '
        Me.RECDATE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RECDATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.RECDATE.Location = New System.Drawing.Point(559, 58)
        Me.RECDATE.Name = "RECDATE"
        Me.RECDATE.Size = New System.Drawing.Size(90, 23)
        Me.RECDATE.TabIndex = 0
        '
        'CMBITEMNAME
        '
        Me.CMBITEMNAME.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBITEMNAME.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBITEMNAME.BackColor = System.Drawing.Color.White
        Me.CMBITEMNAME.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBITEMNAME.FormattingEnabled = True
        Me.CMBITEMNAME.Location = New System.Drawing.Point(148, 90)
        Me.CMBITEMNAME.MaxDropDownItems = 14
        Me.CMBITEMNAME.Name = "CMBITEMNAME"
        Me.CMBITEMNAME.Size = New System.Drawing.Size(150, 23)
        Me.CMBITEMNAME.TabIndex = 4
        '
        'TXTRECNO
        '
        Me.TXTRECNO.BackColor = System.Drawing.Color.Linen
        Me.TXTRECNO.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTRECNO.Location = New System.Drawing.Point(559, 32)
        Me.TXTRECNO.Name = "TXTRECNO"
        Me.TXTRECNO.ReadOnly = True
        Me.TXTRECNO.Size = New System.Drawing.Size(90, 23)
        Me.TXTRECNO.TabIndex = 685
        Me.TXTRECNO.TabStop = False
        Me.TXTRECNO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblsrno
        '
        Me.lblsrno.AutoSize = True
        Me.lblsrno.BackColor = System.Drawing.Color.Transparent
        Me.lblsrno.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblsrno.Location = New System.Drawing.Point(509, 36)
        Me.lblsrno.Name = "lblsrno"
        Me.lblsrno.Size = New System.Drawing.Size(47, 15)
        Me.lblsrno.TabIndex = 686
        Me.lblsrno.Text = "Rec No."
        Me.lblsrno.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TXTTOTALCTWT
        '
        Me.TXTTOTALCTWT.BackColor = System.Drawing.Color.Linen
        Me.TXTTOTALCTWT.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTTOTALCTWT.Location = New System.Drawing.Point(658, 278)
        Me.TXTTOTALCTWT.Name = "TXTTOTALCTWT"
        Me.TXTTOTALCTWT.ReadOnly = True
        Me.TXTTOTALCTWT.Size = New System.Drawing.Size(80, 23)
        Me.TXTTOTALCTWT.TabIndex = 687
        Me.TXTTOTALCTWT.TabStop = False
        Me.TXTTOTALCTWT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(562, 282)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 15)
        Me.Label1.TabIndex = 688
        Me.Label1.Text = "Total"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TXTTOTALPCS
        '
        Me.TXTTOTALPCS.BackColor = System.Drawing.Color.Linen
        Me.TXTTOTALPCS.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTTOTALPCS.Location = New System.Drawing.Point(598, 278)
        Me.TXTTOTALPCS.Name = "TXTTOTALPCS"
        Me.TXTTOTALPCS.ReadOnly = True
        Me.TXTTOTALPCS.Size = New System.Drawing.Size(60, 23)
        Me.TXTTOTALPCS.TabIndex = 689
        Me.TXTTOTALPCS.TabStop = False
        Me.TXTTOTALPCS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.TXTREMARKS)
        Me.GroupBox3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GroupBox3.Location = New System.Drawing.Point(17, 282)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(381, 88)
        Me.GroupBox3.TabIndex = 10
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Remarks"
        '
        'TXTREMARKS
        '
        Me.TXTREMARKS.Location = New System.Drawing.Point(8, 17)
        Me.TXTREMARKS.Multiline = True
        Me.TXTREMARKS.Name = "TXTREMARKS"
        Me.TXTREMARKS.Size = New System.Drawing.Size(364, 62)
        Me.TXTREMARKS.TabIndex = 0
        '
        'EP
        '
        Me.EP.BlinkRate = 0
        Me.EP.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.EP.ContainerControl = Me
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(17, 66)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 15)
        Me.Label2.TabIndex = 691
        Me.Label2.Text = "Name"
        '
        'TXTNAME
        '
        Me.TXTNAME.BackColor = System.Drawing.Color.Linen
        Me.TXTNAME.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTNAME.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTNAME.Location = New System.Drawing.Point(58, 62)
        Me.TXTNAME.Name = "TXTNAME"
        Me.TXTNAME.ReadOnly = True
        Me.TXTNAME.Size = New System.Drawing.Size(180, 23)
        Me.TXTNAME.TabIndex = 690
        Me.TXTNAME.TabStop = False
        '
        'GRIDDATE
        '
        Me.GRIDDATE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRIDDATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.GRIDDATE.Location = New System.Drawing.Point(58, 90)
        Me.GRIDDATE.Name = "GRIDDATE"
        Me.GRIDDATE.Size = New System.Drawing.Size(90, 23)
        Me.GRIDDATE.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(524, 62)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(32, 15)
        Me.Label3.TabIndex = 693
        Me.Label3.Text = "Date"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'MaterialReceipt
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(782, 388)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.GRIDDATE)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TXTNAME)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.TXTTOTALPCS)
        Me.Controls.Add(Me.TXTTOTALCTWT)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TXTRECNO)
        Me.Controls.Add(Me.lblsrno)
        Me.Controls.Add(Me.CMBITEMNAME)
        Me.Controls.Add(Me.RECDATE)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.TXTORDERNO)
        Me.Controls.Add(Me.CMBCOLOR)
        Me.Controls.Add(Me.CMBSIZE)
        Me.Controls.Add(Me.CMBTYPE)
        Me.Controls.Add(Me.CMDSELECTORDER)
        Me.Controls.Add(Me.cmddelete)
        Me.Controls.Add(Me.cmdclear)
        Me.Controls.Add(Me.cmdok)
        Me.Controls.Add(Me.cmdexit)
        Me.Controls.Add(Me.lbl)
        Me.Controls.Add(Me.TXTPCS)
        Me.Controls.Add(Me.TXTCTWT)
        Me.Controls.Add(Me.TXTSRNO)
        Me.Controls.Add(Me.GRIDREC)
        Me.Controls.Add(Me.tstxtbillno)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "MaterialReceipt"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Material Receipt"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.GRIDREC, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tstxtbillno As System.Windows.Forms.TextBox
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
    Friend WithEvents TXTSRNO As System.Windows.Forms.TextBox
    Friend WithEvents GRIDREC As System.Windows.Forms.DataGridView
    Friend WithEvents TXTCTWT As System.Windows.Forms.TextBox
    Friend WithEvents TXTPCS As System.Windows.Forms.TextBox
    Friend WithEvents lbl As System.Windows.Forms.Label
    Friend WithEvents cmddelete As System.Windows.Forms.Button
    Friend WithEvents cmdclear As System.Windows.Forms.Button
    Friend WithEvents cmdok As System.Windows.Forms.Button
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents CMDSELECTORDER As System.Windows.Forms.Button
    Friend WithEvents CMBTYPE As System.Windows.Forms.ComboBox
    Friend WithEvents CMBSIZE As System.Windows.Forms.ComboBox
    Friend WithEvents CMBCOLOR As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TXTORDERNO As System.Windows.Forms.TextBox
    Friend WithEvents RECDATE As System.Windows.Forms.DateTimePicker
    Friend WithEvents CMBITEMNAME As System.Windows.Forms.ComboBox
    Friend WithEvents TXTRECNO As System.Windows.Forms.TextBox
    Friend WithEvents lblsrno As System.Windows.Forms.Label
    Friend WithEvents TXTTOTALCTWT As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TXTTOTALPCS As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents TXTREMARKS As System.Windows.Forms.TextBox
    Friend WithEvents EP As System.Windows.Forms.ErrorProvider
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TXTNAME As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GRIDDATE As System.Windows.Forms.DateTimePicker
    Friend WithEvents GSRNO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gdate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GITEMNAME As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GTYPE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GSIZE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GCOLOR As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GPCS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GCTWT As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
