<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StockTransferMaster
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(StockTransferMaster))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.lbllock = New System.Windows.Forms.Label()
        Me.CMBTODEPARTMENT = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CMBFROMDEPARTMENT = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
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
        Me.tstxtbillno = New System.Windows.Forms.TextBox()
        Me.TXTTOTALFINEWT = New System.Windows.Forms.TextBox()
        Me.TXTWASTAGE = New System.Windows.Forms.TextBox()
        Me.TXTPURITY = New System.Windows.Forms.TextBox()
        Me.TXTFINEWT = New System.Windows.Forms.TextBox()
        Me.TXTITEMDESC = New System.Windows.Forms.TextBox()
        Me.cmddelete = New System.Windows.Forms.Button()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.TXTREMARKS = New System.Windows.Forms.TextBox()
        Me.TXTTOTALPCS = New System.Windows.Forms.TextBox()
        Me.TXTTOTALGROSSWT = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TXTSTNO = New System.Windows.Forms.TextBox()
        Me.lblsrno = New System.Windows.Forms.Label()
        Me.CMBITEMCODE = New System.Windows.Forms.ComboBox()
        Me.STDATE = New System.Windows.Forms.DateTimePicker()
        Me.cmdclear = New System.Windows.Forms.Button()
        Me.cmdok = New System.Windows.Forms.Button()
        Me.TXTPCS = New System.Windows.Forms.TextBox()
        Me.TXTGROSSWT = New System.Windows.Forms.TextBox()
        Me.TXTSRNO = New System.Windows.Forms.TextBox()
        Me.GRIDST = New System.Windows.Forms.DataGridView()
        Me.GSRNO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GITEMCODE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GITEMDESC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GPCS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GGROSSWT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GMELTING = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GWASTAGE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GFINEWT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GACCEPTED = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EP = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.BlendPanel1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.GRIDST, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.Color.White)
        Me.BlendPanel1.Controls.Add(Me.lbllock)
        Me.BlendPanel1.Controls.Add(Me.CMBTODEPARTMENT)
        Me.BlendPanel1.Controls.Add(Me.Label2)
        Me.BlendPanel1.Controls.Add(Me.CMBFROMDEPARTMENT)
        Me.BlendPanel1.Controls.Add(Me.Label12)
        Me.BlendPanel1.Controls.Add(Me.ToolStrip1)
        Me.BlendPanel1.Controls.Add(Me.tstxtbillno)
        Me.BlendPanel1.Controls.Add(Me.TXTTOTALFINEWT)
        Me.BlendPanel1.Controls.Add(Me.TXTWASTAGE)
        Me.BlendPanel1.Controls.Add(Me.TXTPURITY)
        Me.BlendPanel1.Controls.Add(Me.TXTFINEWT)
        Me.BlendPanel1.Controls.Add(Me.TXTITEMDESC)
        Me.BlendPanel1.Controls.Add(Me.cmddelete)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.Label3)
        Me.BlendPanel1.Controls.Add(Me.GroupBox3)
        Me.BlendPanel1.Controls.Add(Me.TXTTOTALPCS)
        Me.BlendPanel1.Controls.Add(Me.TXTTOTALGROSSWT)
        Me.BlendPanel1.Controls.Add(Me.Label1)
        Me.BlendPanel1.Controls.Add(Me.TXTSTNO)
        Me.BlendPanel1.Controls.Add(Me.lblsrno)
        Me.BlendPanel1.Controls.Add(Me.CMBITEMCODE)
        Me.BlendPanel1.Controls.Add(Me.STDATE)
        Me.BlendPanel1.Controls.Add(Me.cmdclear)
        Me.BlendPanel1.Controls.Add(Me.cmdok)
        Me.BlendPanel1.Controls.Add(Me.TXTPCS)
        Me.BlendPanel1.Controls.Add(Me.TXTGROSSWT)
        Me.BlendPanel1.Controls.Add(Me.TXTSRNO)
        Me.BlendPanel1.Controls.Add(Me.GRIDST)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(815, 561)
        Me.BlendPanel1.TabIndex = 0
        '
        'lbllock
        '
        Me.lbllock.AutoSize = True
        Me.lbllock.BackColor = System.Drawing.Color.Transparent
        Me.lbllock.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbllock.ForeColor = System.Drawing.Color.Red
        Me.lbllock.Location = New System.Drawing.Point(686, 485)
        Me.lbllock.Name = "lbllock"
        Me.lbllock.Size = New System.Drawing.Size(85, 24)
        Me.lbllock.TabIndex = 763
        Me.lbllock.Text = "Locked"
        Me.lbllock.Visible = False
        '
        'CMBTODEPARTMENT
        '
        Me.CMBTODEPARTMENT.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBTODEPARTMENT.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBTODEPARTMENT.FormattingEnabled = True
        Me.CMBTODEPARTMENT.Location = New System.Drawing.Point(162, 64)
        Me.CMBTODEPARTMENT.Name = "CMBTODEPARTMENT"
        Me.CMBTODEPARTMENT.Size = New System.Drawing.Size(121, 23)
        Me.CMBTODEPARTMENT.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(74, 68)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(86, 15)
        Me.Label2.TabIndex = 762
        Me.Label2.Text = "To Department"
        '
        'CMBFROMDEPARTMENT
        '
        Me.CMBFROMDEPARTMENT.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBFROMDEPARTMENT.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBFROMDEPARTMENT.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBFROMDEPARTMENT.FormattingEnabled = True
        Me.CMBFROMDEPARTMENT.Location = New System.Drawing.Point(162, 35)
        Me.CMBFROMDEPARTMENT.Name = "CMBFROMDEPARTMENT"
        Me.CMBFROMDEPARTMENT.Size = New System.Drawing.Size(121, 23)
        Me.CMBFROMDEPARTMENT.TabIndex = 1
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Location = New System.Drawing.Point(58, 39)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(102, 15)
        Me.Label12.TabIndex = 760
        Me.Label12.Text = "From Department"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ToolStrip1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenToolStripButton, Me.SaveToolStripButton, Me.PrintToolStripButton, Me.ToolStripdelete, Me.ToolStripSeparator3, Me.toolprevious, Me.ToolStripSeparator1, Me.toolnext, Me.ToolStripSeparator2})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(815, 25)
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
        'tstxtbillno
        '
        Me.tstxtbillno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tstxtbillno.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tstxtbillno.Location = New System.Drawing.Point(245, 2)
        Me.tstxtbillno.Name = "tstxtbillno"
        Me.tstxtbillno.Size = New System.Drawing.Size(58, 22)
        Me.tstxtbillno.TabIndex = 759
        Me.tstxtbillno.TabStop = False
        Me.tstxtbillno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTTOTALFINEWT
        '
        Me.TXTTOTALFINEWT.BackColor = System.Drawing.Color.Linen
        Me.TXTTOTALFINEWT.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTTOTALFINEWT.Location = New System.Drawing.Point(682, 459)
        Me.TXTTOTALFINEWT.Name = "TXTTOTALFINEWT"
        Me.TXTTOTALFINEWT.ReadOnly = True
        Me.TXTTOTALFINEWT.Size = New System.Drawing.Size(80, 23)
        Me.TXTTOTALFINEWT.TabIndex = 756
        Me.TXTTOTALFINEWT.TabStop = False
        Me.TXTTOTALFINEWT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTWASTAGE
        '
        Me.TXTWASTAGE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTWASTAGE.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.TXTWASTAGE.Location = New System.Drawing.Point(602, 100)
        Me.TXTWASTAGE.Name = "TXTWASTAGE"
        Me.TXTWASTAGE.Size = New System.Drawing.Size(80, 23)
        Me.TXTWASTAGE.TabIndex = 8
        Me.TXTWASTAGE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTPURITY
        '
        Me.TXTPURITY.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTPURITY.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.TXTPURITY.Location = New System.Drawing.Point(522, 100)
        Me.TXTPURITY.Name = "TXTPURITY"
        Me.TXTPURITY.Size = New System.Drawing.Size(80, 23)
        Me.TXTPURITY.TabIndex = 7
        Me.TXTPURITY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTFINEWT
        '
        Me.TXTFINEWT.BackColor = System.Drawing.Color.White
        Me.TXTFINEWT.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTFINEWT.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.TXTFINEWT.Location = New System.Drawing.Point(682, 100)
        Me.TXTFINEWT.Name = "TXTFINEWT"
        Me.TXTFINEWT.Size = New System.Drawing.Size(80, 23)
        Me.TXTFINEWT.TabIndex = 9
        Me.TXTFINEWT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTITEMDESC
        '
        Me.TXTITEMDESC.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTITEMDESC.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.TXTITEMDESC.Location = New System.Drawing.Point(182, 100)
        Me.TXTITEMDESC.Name = "TXTITEMDESC"
        Me.TXTITEMDESC.Size = New System.Drawing.Size(200, 23)
        Me.TXTITEMDESC.TabIndex = 4
        '
        'cmddelete
        '
        Me.cmddelete.BackColor = System.Drawing.Color.Transparent
        Me.cmddelete.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmddelete.FlatAppearance.BorderSize = 0
        Me.cmddelete.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmddelete.ForeColor = System.Drawing.Color.Black
        Me.cmddelete.Location = New System.Drawing.Point(505, 513)
        Me.cmddelete.Name = "cmddelete"
        Me.cmddelete.Size = New System.Drawing.Size(85, 28)
        Me.cmddelete.TabIndex = 14
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
        Me.cmdexit.Location = New System.Drawing.Point(596, 513)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(85, 28)
        Me.cmdexit.TabIndex = 15
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(646, 68)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(32, 15)
        Me.Label3.TabIndex = 746
        Me.Label3.Text = "Date"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.TXTREMARKS)
        Me.GroupBox3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GroupBox3.Location = New System.Drawing.Point(18, 462)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(265, 88)
        Me.GroupBox3.TabIndex = 11
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Remarks"
        '
        'TXTREMARKS
        '
        Me.TXTREMARKS.Location = New System.Drawing.Point(8, 17)
        Me.TXTREMARKS.MaxLength = 250
        Me.TXTREMARKS.Multiline = True
        Me.TXTREMARKS.Name = "TXTREMARKS"
        Me.TXTREMARKS.Size = New System.Drawing.Size(247, 62)
        Me.TXTREMARKS.TabIndex = 0
        '
        'TXTTOTALPCS
        '
        Me.TXTTOTALPCS.BackColor = System.Drawing.Color.Linen
        Me.TXTTOTALPCS.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTTOTALPCS.Location = New System.Drawing.Point(382, 459)
        Me.TXTTOTALPCS.Name = "TXTTOTALPCS"
        Me.TXTTOTALPCS.ReadOnly = True
        Me.TXTTOTALPCS.Size = New System.Drawing.Size(60, 23)
        Me.TXTTOTALPCS.TabIndex = 743
        Me.TXTTOTALPCS.TabStop = False
        Me.TXTTOTALPCS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTTOTALGROSSWT
        '
        Me.TXTTOTALGROSSWT.BackColor = System.Drawing.Color.Linen
        Me.TXTTOTALGROSSWT.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTTOTALGROSSWT.Location = New System.Drawing.Point(442, 459)
        Me.TXTTOTALGROSSWT.Name = "TXTTOTALGROSSWT"
        Me.TXTTOTALGROSSWT.ReadOnly = True
        Me.TXTTOTALGROSSWT.Size = New System.Drawing.Size(80, 23)
        Me.TXTTOTALGROSSWT.TabIndex = 741
        Me.TXTTOTALGROSSWT.TabStop = False
        Me.TXTTOTALGROSSWT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(342, 463)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 15)
        Me.Label1.TabIndex = 742
        Me.Label1.Text = "Total"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TXTSTNO
        '
        Me.TXTSTNO.BackColor = System.Drawing.Color.Linen
        Me.TXTSTNO.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTSTNO.Location = New System.Drawing.Point(681, 35)
        Me.TXTSTNO.Name = "TXTSTNO"
        Me.TXTSTNO.ReadOnly = True
        Me.TXTSTNO.Size = New System.Drawing.Size(90, 23)
        Me.TXTSTNO.TabIndex = 739
        Me.TXTSTNO.TabStop = False
        Me.TXTSTNO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblsrno
        '
        Me.lblsrno.AutoSize = True
        Me.lblsrno.BackColor = System.Drawing.Color.Transparent
        Me.lblsrno.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblsrno.Location = New System.Drawing.Point(639, 39)
        Me.lblsrno.Name = "lblsrno"
        Me.lblsrno.Size = New System.Drawing.Size(40, 15)
        Me.lblsrno.TabIndex = 740
        Me.lblsrno.Text = "ST No."
        Me.lblsrno.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CMBITEMCODE
        '
        Me.CMBITEMCODE.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBITEMCODE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBITEMCODE.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBITEMCODE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBITEMCODE.FormattingEnabled = True
        Me.CMBITEMCODE.Location = New System.Drawing.Point(62, 100)
        Me.CMBITEMCODE.MaxDropDownItems = 14
        Me.CMBITEMCODE.Name = "CMBITEMCODE"
        Me.CMBITEMCODE.Size = New System.Drawing.Size(120, 23)
        Me.CMBITEMCODE.TabIndex = 3
        '
        'STDATE
        '
        Me.STDATE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.STDATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.STDATE.Location = New System.Drawing.Point(681, 64)
        Me.STDATE.Name = "STDATE"
        Me.STDATE.Size = New System.Drawing.Size(90, 23)
        Me.STDATE.TabIndex = 0
        '
        'cmdclear
        '
        Me.cmdclear.BackColor = System.Drawing.Color.Transparent
        Me.cmdclear.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdclear.FlatAppearance.BorderSize = 0
        Me.cmdclear.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdclear.ForeColor = System.Drawing.Color.Black
        Me.cmdclear.Location = New System.Drawing.Point(414, 513)
        Me.cmdclear.Name = "cmdclear"
        Me.cmdclear.Size = New System.Drawing.Size(85, 28)
        Me.cmdclear.TabIndex = 13
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
        Me.cmdok.Location = New System.Drawing.Point(323, 513)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(85, 28)
        Me.cmdok.TabIndex = 12
        Me.cmdok.Text = "&Save"
        Me.cmdok.UseVisualStyleBackColor = False
        '
        'TXTPCS
        '
        Me.TXTPCS.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTPCS.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.TXTPCS.Location = New System.Drawing.Point(382, 100)
        Me.TXTPCS.Name = "TXTPCS"
        Me.TXTPCS.Size = New System.Drawing.Size(60, 23)
        Me.TXTPCS.TabIndex = 5
        Me.TXTPCS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTGROSSWT
        '
        Me.TXTGROSSWT.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTGROSSWT.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTGROSSWT.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.TXTGROSSWT.Location = New System.Drawing.Point(442, 100)
        Me.TXTGROSSWT.Name = "TXTGROSSWT"
        Me.TXTGROSSWT.Size = New System.Drawing.Size(80, 23)
        Me.TXTGROSSWT.TabIndex = 6
        Me.TXTGROSSWT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        'GRIDST
        '
        Me.GRIDST.AllowUserToAddRows = False
        Me.GRIDST.AllowUserToDeleteRows = False
        Me.GRIDST.AllowUserToResizeColumns = False
        Me.GRIDST.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Black
        Me.GRIDST.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.GRIDST.BackgroundColor = System.Drawing.Color.White
        Me.GRIDST.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.GRIDST.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.GRIDST.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.GRIDST.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GRIDST.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.GSRNO, Me.GITEMCODE, Me.GITEMDESC, Me.GPCS, Me.GGROSSWT, Me.GMELTING, Me.GWASTAGE, Me.GFINEWT, Me.GACCEPTED})
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GRIDST.DefaultCellStyle = DataGridViewCellStyle8
        Me.GRIDST.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.GRIDST.GridColor = System.Drawing.SystemColors.Control
        Me.GRIDST.Location = New System.Drawing.Point(22, 123)
        Me.GRIDST.MultiSelect = False
        Me.GRIDST.Name = "GRIDST"
        Me.GRIDST.ReadOnly = True
        Me.GRIDST.RowHeadersVisible = False
        Me.GRIDST.RowHeadersWidth = 30
        Me.GRIDST.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.Black
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.White
        Me.GRIDST.RowsDefaultCellStyle = DataGridViewCellStyle9
        Me.GRIDST.RowTemplate.Height = 20
        Me.GRIDST.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GRIDST.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.GRIDST.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GRIDST.Size = New System.Drawing.Size(771, 333)
        Me.GRIDST.TabIndex = 10
        Me.GRIDST.TabStop = False
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
        'GITEMCODE
        '
        Me.GITEMCODE.HeaderText = "Item Code"
        Me.GITEMCODE.Name = "GITEMCODE"
        Me.GITEMCODE.ReadOnly = True
        Me.GITEMCODE.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GITEMCODE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GITEMCODE.Width = 120
        '
        'GITEMDESC
        '
        Me.GITEMDESC.HeaderText = "Item Desc"
        Me.GITEMDESC.Name = "GITEMDESC"
        Me.GITEMDESC.ReadOnly = True
        Me.GITEMDESC.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GITEMDESC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GITEMDESC.Width = 200
        '
        'GPCS
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.GPCS.DefaultCellStyle = DataGridViewCellStyle3
        Me.GPCS.HeaderText = "Pcs"
        Me.GPCS.Name = "GPCS"
        Me.GPCS.ReadOnly = True
        Me.GPCS.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GPCS.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GPCS.Width = 60
        '
        'GGROSSWT
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.GGROSSWT.DefaultCellStyle = DataGridViewCellStyle4
        Me.GGROSSWT.HeaderText = "Gross Wt"
        Me.GGROSSWT.Name = "GGROSSWT"
        Me.GGROSSWT.ReadOnly = True
        Me.GGROSSWT.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GGROSSWT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GGROSSWT.Width = 80
        '
        'GMELTING
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.GMELTING.DefaultCellStyle = DataGridViewCellStyle5
        Me.GMELTING.HeaderText = "Melting"
        Me.GMELTING.Name = "GMELTING"
        Me.GMELTING.ReadOnly = True
        Me.GMELTING.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GMELTING.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GMELTING.Width = 80
        '
        'GWASTAGE
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.GWASTAGE.DefaultCellStyle = DataGridViewCellStyle6
        Me.GWASTAGE.HeaderText = "Wastage"
        Me.GWASTAGE.Name = "GWASTAGE"
        Me.GWASTAGE.ReadOnly = True
        Me.GWASTAGE.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GWASTAGE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GWASTAGE.Width = 80
        '
        'GFINEWT
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.GFINEWT.DefaultCellStyle = DataGridViewCellStyle7
        Me.GFINEWT.HeaderText = "Fine Wt"
        Me.GFINEWT.Name = "GFINEWT"
        Me.GFINEWT.ReadOnly = True
        Me.GFINEWT.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GFINEWT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GFINEWT.Width = 80
        '
        'GACCEPTED
        '
        Me.GACCEPTED.HeaderText = "Accepted"
        Me.GACCEPTED.Name = "GACCEPTED"
        Me.GACCEPTED.ReadOnly = True
        Me.GACCEPTED.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GACCEPTED.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GACCEPTED.Visible = False
        '
        'EP
        '
        Me.EP.BlinkRate = 0
        Me.EP.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.EP.ContainerControl = Me
        '
        'StockTransferMaster
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(815, 561)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "StockTransferMaster"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Stock Transfer"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.GRIDST, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents OpenToolStripButton As ToolStripButton
    Friend WithEvents SaveToolStripButton As ToolStripButton
    Friend WithEvents PrintToolStripButton As ToolStripButton
    Friend WithEvents ToolStripdelete As ToolStripButton
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents toolprevious As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents toolnext As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents tstxtbillno As TextBox
    Friend WithEvents TXTTOTALFINEWT As TextBox
    Friend WithEvents TXTWASTAGE As TextBox
    Friend WithEvents TXTPURITY As TextBox
    Friend WithEvents TXTFINEWT As TextBox
    Friend WithEvents TXTITEMDESC As TextBox
    Friend WithEvents cmddelete As Button
    Friend WithEvents cmdexit As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents TXTREMARKS As TextBox
    Friend WithEvents TXTTOTALPCS As TextBox
    Friend WithEvents TXTTOTALGROSSWT As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TXTSTNO As TextBox
    Friend WithEvents lblsrno As Label
    Friend WithEvents CMBITEMCODE As ComboBox
    Friend WithEvents STDATE As DateTimePicker
    Friend WithEvents cmdclear As Button
    Friend WithEvents cmdok As Button
    Friend WithEvents TXTPCS As TextBox
    Friend WithEvents TXTGROSSWT As TextBox
    Friend WithEvents TXTSRNO As TextBox
    Friend WithEvents GRIDST As DataGridView
    Friend WithEvents EP As ErrorProvider
    Friend WithEvents CMBTODEPARTMENT As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents CMBFROMDEPARTMENT As ComboBox
    Friend WithEvents Label12 As Label
    Friend WithEvents GSRNO As DataGridViewTextBoxColumn
    Friend WithEvents GITEMCODE As DataGridViewTextBoxColumn
    Friend WithEvents GITEMDESC As DataGridViewTextBoxColumn
    Friend WithEvents GPCS As DataGridViewTextBoxColumn
    Friend WithEvents GGROSSWT As DataGridViewTextBoxColumn
    Friend WithEvents GMELTING As DataGridViewTextBoxColumn
    Friend WithEvents GWASTAGE As DataGridViewTextBoxColumn
    Friend WithEvents GFINEWT As DataGridViewTextBoxColumn
    Friend WithEvents GACCEPTED As DataGridViewTextBoxColumn
    Friend WithEvents lbllock As Label
End Class
