<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StockSummary
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(StockSummary))
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.TXTCLNETT = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TXTOPNETT = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TXTCLGROSS = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TXTOPGROSS = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.PrintToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.EXCEL_ICON = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.TOOLREFRESH = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.txtbalnett = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtbalgross = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.CMDSHOWDETAILS = New System.Windows.Forms.Button()
        Me.dtto = New System.Windows.Forms.DateTimePicker()
        Me.lblto = New System.Windows.Forms.Label()
        Me.dtfrom = New System.Windows.Forms.DateTimePicker()
        Me.chkdate = New System.Windows.Forms.CheckBox()
        Me.lblfrom = New System.Windows.Forms.Label()
        Me.lbl = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbitemname = New System.Windows.Forms.ComboBox()
        Me.txtpurity = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbname = New System.Windows.Forms.ComboBox()
        Me.gridStock = New DevExpress.XtraGrid.GridControl()
        Me.gridbandstock = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.gridBand1 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.gdate = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GITEMNAME = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gpartyname = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.glotno = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GSTONWEWT = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gpurity = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand2 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.grecgrosswt = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.grecnettwt = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand3 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.gissuegrosswt = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gissuenettwt = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BlendPanel1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.gridStock, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridbandstock, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.TXTCLNETT)
        Me.BlendPanel1.Controls.Add(Me.Label9)
        Me.BlendPanel1.Controls.Add(Me.TXTOPNETT)
        Me.BlendPanel1.Controls.Add(Me.Label8)
        Me.BlendPanel1.Controls.Add(Me.TXTCLGROSS)
        Me.BlendPanel1.Controls.Add(Me.Label7)
        Me.BlendPanel1.Controls.Add(Me.TXTOPGROSS)
        Me.BlendPanel1.Controls.Add(Me.Label6)
        Me.BlendPanel1.Controls.Add(Me.ToolStrip1)
        Me.BlendPanel1.Controls.Add(Me.txtbalnett)
        Me.BlendPanel1.Controls.Add(Me.Label5)
        Me.BlendPanel1.Controls.Add(Me.txtbalgross)
        Me.BlendPanel1.Controls.Add(Me.Label3)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.CMDSHOWDETAILS)
        Me.BlendPanel1.Controls.Add(Me.dtto)
        Me.BlendPanel1.Controls.Add(Me.lblto)
        Me.BlendPanel1.Controls.Add(Me.dtfrom)
        Me.BlendPanel1.Controls.Add(Me.chkdate)
        Me.BlendPanel1.Controls.Add(Me.lblfrom)
        Me.BlendPanel1.Controls.Add(Me.lbl)
        Me.BlendPanel1.Controls.Add(Me.Label1)
        Me.BlendPanel1.Controls.Add(Me.cmbitemname)
        Me.BlendPanel1.Controls.Add(Me.txtpurity)
        Me.BlendPanel1.Controls.Add(Me.Label2)
        Me.BlendPanel1.Controls.Add(Me.Label4)
        Me.BlendPanel1.Controls.Add(Me.cmbname)
        Me.BlendPanel1.Controls.Add(Me.gridStock)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1038, 590)
        Me.BlendPanel1.TabIndex = 0
        '
        'TXTCLNETT
        '
        Me.TXTCLNETT.BackColor = System.Drawing.Color.Linen
        Me.TXTCLNETT.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCLNETT.ForeColor = System.Drawing.Color.Black
        Me.TXTCLNETT.Location = New System.Drawing.Point(401, 558)
        Me.TXTCLNETT.Name = "TXTCLNETT"
        Me.TXTCLNETT.ReadOnly = True
        Me.TXTCLNETT.Size = New System.Drawing.Size(66, 22)
        Me.TXTCLNETT.TabIndex = 487
        Me.TXTCLNETT.TabStop = False
        Me.TXTCLNETT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(349, 562)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(49, 14)
        Me.Label9.TabIndex = 488
        Me.Label9.Text = "C/L Nett"
        '
        'TXTOPNETT
        '
        Me.TXTOPNETT.BackColor = System.Drawing.Color.Linen
        Me.TXTOPNETT.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTOPNETT.ForeColor = System.Drawing.Color.Black
        Me.TXTOPNETT.Location = New System.Drawing.Point(95, 557)
        Me.TXTOPNETT.Name = "TXTOPNETT"
        Me.TXTOPNETT.ReadOnly = True
        Me.TXTOPNETT.Size = New System.Drawing.Size(66, 22)
        Me.TXTOPNETT.TabIndex = 485
        Me.TXTOPNETT.TabStop = False
        Me.TXTOPNETT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(41, 561)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(52, 14)
        Me.Label8.TabIndex = 486
        Me.Label8.Text = "O/P Nett"
        '
        'TXTCLGROSS
        '
        Me.TXTCLGROSS.BackColor = System.Drawing.Color.Linen
        Me.TXTCLGROSS.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCLGROSS.ForeColor = System.Drawing.Color.Black
        Me.TXTCLGROSS.Location = New System.Drawing.Point(401, 530)
        Me.TXTCLGROSS.Name = "TXTCLGROSS"
        Me.TXTCLGROSS.ReadOnly = True
        Me.TXTCLGROSS.Size = New System.Drawing.Size(66, 22)
        Me.TXTCLGROSS.TabIndex = 483
        Me.TXTCLGROSS.TabStop = False
        Me.TXTCLGROSS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(356, 534)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(44, 14)
        Me.Label7.TabIndex = 484
        Me.Label7.Text = "C/L Wt."
        '
        'TXTOPGROSS
        '
        Me.TXTOPGROSS.BackColor = System.Drawing.Color.Linen
        Me.TXTOPGROSS.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTOPGROSS.ForeColor = System.Drawing.Color.Black
        Me.TXTOPGROSS.Location = New System.Drawing.Point(95, 530)
        Me.TXTOPGROSS.Name = "TXTOPGROSS"
        Me.TXTOPGROSS.ReadOnly = True
        Me.TXTOPGROSS.Size = New System.Drawing.Size(66, 22)
        Me.TXTOPGROSS.TabIndex = 481
        Me.TXTOPGROSS.TabStop = False
        Me.TXTOPGROSS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(46, 534)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(47, 14)
        Me.Label6.TabIndex = 482
        Me.Label6.Text = "O/P Wt."
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrintToolStripButton, Me.EXCEL_ICON, Me.ToolStripSeparator1, Me.TOOLREFRESH, Me.ToolStripSeparator2})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1038, 25)
        Me.ToolStrip1.TabIndex = 480
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
        'EXCEL_ICON
        '
        Me.EXCEL_ICON.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.EXCEL_ICON.Image = Global.Magic_Gold.My.Resources.Resources.Excel_icon
        Me.EXCEL_ICON.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.EXCEL_ICON.Name = "EXCEL_ICON"
        Me.EXCEL_ICON.Size = New System.Drawing.Size(23, 22)
        Me.EXCEL_ICON.Text = "Excel Report"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'TOOLREFRESH
        '
        Me.TOOLREFRESH.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TOOLREFRESH.Image = Global.Magic_Gold.My.Resources.Resources.refreshimage
        Me.TOOLREFRESH.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TOOLREFRESH.Name = "TOOLREFRESH"
        Me.TOOLREFRESH.Size = New System.Drawing.Size(23, 22)
        Me.TOOLREFRESH.Text = "ToolStripButton1"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'txtbalnett
        '
        Me.txtbalnett.BackColor = System.Drawing.Color.Linen
        Me.txtbalnett.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbalnett.ForeColor = System.Drawing.Color.Black
        Me.txtbalnett.Location = New System.Drawing.Point(276, 556)
        Me.txtbalnett.Name = "txtbalnett"
        Me.txtbalnett.ReadOnly = True
        Me.txtbalnett.Size = New System.Drawing.Size(66, 22)
        Me.txtbalnett.TabIndex = 392
        Me.txtbalnett.TabStop = False
        Me.txtbalnett.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(176, 560)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(98, 14)
        Me.Label5.TabIndex = 393
        Me.Label5.Text = "Balance Nett Wt."
        '
        'txtbalgross
        '
        Me.txtbalgross.BackColor = System.Drawing.Color.Linen
        Me.txtbalgross.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbalgross.ForeColor = System.Drawing.Color.Black
        Me.txtbalgross.Location = New System.Drawing.Point(276, 530)
        Me.txtbalgross.Name = "txtbalgross"
        Me.txtbalgross.ReadOnly = True
        Me.txtbalgross.Size = New System.Drawing.Size(66, 22)
        Me.txtbalgross.TabIndex = 478
        Me.txtbalgross.TabStop = False
        Me.txtbalgross.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(167, 534)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(106, 14)
        Me.Label3.TabIndex = 479
        Me.Label3.Text = "Balance Gross Wt."
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdexit.Image = Global.Magic_Gold.My.Resources.Resources._Exit
        Me.cmdexit.Location = New System.Drawing.Point(483, 535)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(72, 25)
        Me.cmdexit.TabIndex = 7
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'CMDSHOWDETAILS
        '
        Me.CMDSHOWDETAILS.BackColor = System.Drawing.Color.Transparent
        Me.CMDSHOWDETAILS.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDSHOWDETAILS.FlatAppearance.BorderSize = 0
        Me.CMDSHOWDETAILS.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CMDSHOWDETAILS.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDSHOWDETAILS.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CMDSHOWDETAILS.Image = Global.Magic_Gold.My.Resources.Resources.showdetails2
        Me.CMDSHOWDETAILS.Location = New System.Drawing.Point(579, 79)
        Me.CMDSHOWDETAILS.Name = "CMDSHOWDETAILS"
        Me.CMDSHOWDETAILS.Size = New System.Drawing.Size(79, 25)
        Me.CMDSHOWDETAILS.TabIndex = 6
        Me.CMDSHOWDETAILS.UseVisualStyleBackColor = False
        '
        'dtto
        '
        Me.dtto.CustomFormat = "dd/MM/yyyy"
        Me.dtto.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtto.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtto.Location = New System.Drawing.Point(491, 80)
        Me.dtto.Name = "dtto"
        Me.dtto.Size = New System.Drawing.Size(82, 22)
        Me.dtto.TabIndex = 5
        '
        'lblto
        '
        Me.lblto.AutoSize = True
        Me.lblto.BackColor = System.Drawing.Color.Transparent
        Me.lblto.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblto.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblto.Location = New System.Drawing.Point(469, 84)
        Me.lblto.Name = "lblto"
        Me.lblto.Size = New System.Drawing.Size(19, 14)
        Me.lblto.TabIndex = 476
        Me.lblto.Text = "To"
        '
        'dtfrom
        '
        Me.dtfrom.CustomFormat = "dd/MM/yyyy"
        Me.dtfrom.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtfrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtfrom.Location = New System.Drawing.Point(490, 52)
        Me.dtfrom.Name = "dtfrom"
        Me.dtfrom.Size = New System.Drawing.Size(83, 22)
        Me.dtfrom.TabIndex = 4
        '
        'chkdate
        '
        Me.chkdate.AutoSize = True
        Me.chkdate.BackColor = System.Drawing.Color.Transparent
        Me.chkdate.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkdate.Location = New System.Drawing.Point(405, 54)
        Me.chkdate.Name = "chkdate"
        Me.chkdate.Size = New System.Drawing.Size(52, 18)
        Me.chkdate.TabIndex = 3
        Me.chkdate.Text = "Date"
        Me.chkdate.UseVisualStyleBackColor = False
        '
        'lblfrom
        '
        Me.lblfrom.AutoSize = True
        Me.lblfrom.BackColor = System.Drawing.Color.Transparent
        Me.lblfrom.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblfrom.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblfrom.Location = New System.Drawing.Point(454, 56)
        Me.lblfrom.Name = "lblfrom"
        Me.lblfrom.Size = New System.Drawing.Size(34, 14)
        Me.lblfrom.TabIndex = 472
        Me.lblfrom.Text = "From"
        '
        'lbl
        '
        Me.lbl.AutoSize = True
        Me.lbl.BackColor = System.Drawing.Color.Transparent
        Me.lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbl.Location = New System.Drawing.Point(15, 29)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(140, 20)
        Me.lbl.TabIndex = 394
        Me.lbl.Text = "Stock Summary"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(228, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 14)
        Me.Label1.TabIndex = 393
        Me.Label1.Text = "Item Code"
        '
        'cmbitemname
        '
        Me.cmbitemname.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbitemname.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbitemname.FormattingEnabled = True
        Me.cmbitemname.Location = New System.Drawing.Point(292, 52)
        Me.cmbitemname.Name = "cmbitemname"
        Me.cmbitemname.Size = New System.Drawing.Size(94, 22)
        Me.cmbitemname.TabIndex = 1
        '
        'txtpurity
        '
        Me.txtpurity.BackColor = System.Drawing.Color.White
        Me.txtpurity.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtpurity.ForeColor = System.Drawing.Color.Black
        Me.txtpurity.Location = New System.Drawing.Point(292, 80)
        Me.txtpurity.Name = "txtpurity"
        Me.txtpurity.Size = New System.Drawing.Size(94, 22)
        Me.txtpurity.TabIndex = 2
        Me.txtpurity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(253, 84)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 14)
        Me.Label2.TabIndex = 391
        Me.Label2.Text = "Purity"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(22, 56)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 14)
        Me.Label4.TabIndex = 390
        Me.Label4.Text = "Party Code"
        '
        'cmbname
        '
        Me.cmbname.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbname.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbname.BackColor = System.Drawing.Color.White
        Me.cmbname.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbname.Items.AddRange(New Object() {""})
        Me.cmbname.Location = New System.Drawing.Point(91, 52)
        Me.cmbname.Name = "cmbname"
        Me.cmbname.Size = New System.Drawing.Size(120, 22)
        Me.cmbname.TabIndex = 0
        '
        'gridStock
        '
        Me.gridStock.EmbeddedNavigator.Appearance.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridStock.EmbeddedNavigator.Appearance.Options.UseFont = True
        Me.gridStock.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridStock.Location = New System.Drawing.Point(23, 110)
        Me.gridStock.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridStock.MainView = Me.gridbandstock
        Me.gridStock.Name = "gridStock"
        Me.gridStock.Size = New System.Drawing.Size(993, 414)
        Me.gridStock.TabIndex = 319
        Me.gridStock.TabStop = False
        Me.gridStock.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridbandstock})
        '
        'gridbandstock
        '
        Me.gridbandstock.Appearance.BandPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.gridbandstock.Appearance.BandPanel.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.gridbandstock.Appearance.BandPanel.BorderColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.gridbandstock.Appearance.BandPanel.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbandstock.Appearance.BandPanel.ForeColor = System.Drawing.Color.Black
        Me.gridbandstock.Appearance.BandPanel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.gridbandstock.Appearance.BandPanel.Options.UseBackColor = True
        Me.gridbandstock.Appearance.BandPanel.Options.UseBorderColor = True
        Me.gridbandstock.Appearance.BandPanel.Options.UseFont = True
        Me.gridbandstock.Appearance.BandPanel.Options.UseForeColor = True
        Me.gridbandstock.Appearance.BandPanelBackground.BackColor = System.Drawing.Color.White
        Me.gridbandstock.Appearance.BandPanelBackground.Options.UseBackColor = True
        Me.gridbandstock.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.gridbandstock.Appearance.ColumnFilterButton.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.gridbandstock.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.gridbandstock.Appearance.ColumnFilterButton.ForeColor = System.Drawing.Color.Black
        Me.gridbandstock.Appearance.ColumnFilterButton.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.gridbandstock.Appearance.ColumnFilterButton.Options.UseBackColor = True
        Me.gridbandstock.Appearance.ColumnFilterButton.Options.UseBorderColor = True
        Me.gridbandstock.Appearance.ColumnFilterButton.Options.UseForeColor = True
        Me.gridbandstock.Appearance.ColumnFilterButtonActive.BackColor = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.gridbandstock.Appearance.ColumnFilterButtonActive.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(154, Byte), Integer), CType(CType(190, Byte), Integer), CType(CType(243, Byte), Integer))
        Me.gridbandstock.Appearance.ColumnFilterButtonActive.BorderColor = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.gridbandstock.Appearance.ColumnFilterButtonActive.ForeColor = System.Drawing.Color.Black
        Me.gridbandstock.Appearance.ColumnFilterButtonActive.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.gridbandstock.Appearance.ColumnFilterButtonActive.Options.UseBackColor = True
        Me.gridbandstock.Appearance.ColumnFilterButtonActive.Options.UseBorderColor = True
        Me.gridbandstock.Appearance.ColumnFilterButtonActive.Options.UseForeColor = True
        Me.gridbandstock.Appearance.Empty.BackColor = System.Drawing.Color.White
        Me.gridbandstock.Appearance.Empty.Options.UseBackColor = True
        Me.gridbandstock.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.gridbandstock.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black
        Me.gridbandstock.Appearance.EvenRow.Options.UseBackColor = True
        Me.gridbandstock.Appearance.EvenRow.Options.UseForeColor = True
        Me.gridbandstock.Appearance.FilterCloseButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.gridbandstock.Appearance.FilterCloseButton.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.gridbandstock.Appearance.FilterCloseButton.BorderColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.gridbandstock.Appearance.FilterCloseButton.ForeColor = System.Drawing.Color.Black
        Me.gridbandstock.Appearance.FilterCloseButton.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.gridbandstock.Appearance.FilterCloseButton.Options.UseBackColor = True
        Me.gridbandstock.Appearance.FilterCloseButton.Options.UseBorderColor = True
        Me.gridbandstock.Appearance.FilterCloseButton.Options.UseForeColor = True
        Me.gridbandstock.Appearance.FilterPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(62, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.gridbandstock.Appearance.FilterPanel.ForeColor = System.Drawing.Color.White
        Me.gridbandstock.Appearance.FilterPanel.Options.UseBackColor = True
        Me.gridbandstock.Appearance.FilterPanel.Options.UseForeColor = True
        Me.gridbandstock.Appearance.FixedLine.BackColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(97, Byte), Integer), CType(CType(156, Byte), Integer))
        Me.gridbandstock.Appearance.FixedLine.Options.UseBackColor = True
        Me.gridbandstock.Appearance.FocusedCell.BackColor = System.Drawing.Color.White
        Me.gridbandstock.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black
        Me.gridbandstock.Appearance.FocusedCell.Options.UseBackColor = True
        Me.gridbandstock.Appearance.FocusedCell.Options.UseForeColor = True
        Me.gridbandstock.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.gridbandstock.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White
        Me.gridbandstock.Appearance.FocusedRow.Options.UseBackColor = True
        Me.gridbandstock.Appearance.FocusedRow.Options.UseForeColor = True
        Me.gridbandstock.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.gridbandstock.Appearance.FooterPanel.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.gridbandstock.Appearance.FooterPanel.BorderColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.gridbandstock.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Black
        Me.gridbandstock.Appearance.FooterPanel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.gridbandstock.Appearance.FooterPanel.Options.UseBackColor = True
        Me.gridbandstock.Appearance.FooterPanel.Options.UseBorderColor = True
        Me.gridbandstock.Appearance.FooterPanel.Options.UseForeColor = True
        Me.gridbandstock.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.gridbandstock.Appearance.GroupButton.BorderColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.gridbandstock.Appearance.GroupButton.ForeColor = System.Drawing.Color.Black
        Me.gridbandstock.Appearance.GroupButton.Options.UseBackColor = True
        Me.gridbandstock.Appearance.GroupButton.Options.UseBorderColor = True
        Me.gridbandstock.Appearance.GroupButton.Options.UseForeColor = True
        Me.gridbandstock.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.gridbandstock.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.gridbandstock.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Black
        Me.gridbandstock.Appearance.GroupFooter.Options.UseBackColor = True
        Me.gridbandstock.Appearance.GroupFooter.Options.UseBorderColor = True
        Me.gridbandstock.Appearance.GroupFooter.Options.UseForeColor = True
        Me.gridbandstock.Appearance.GroupPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(62, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.gridbandstock.Appearance.GroupPanel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.gridbandstock.Appearance.GroupPanel.Options.UseBackColor = True
        Me.gridbandstock.Appearance.GroupPanel.Options.UseForeColor = True
        Me.gridbandstock.Appearance.GroupRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.gridbandstock.Appearance.GroupRow.BorderColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.gridbandstock.Appearance.GroupRow.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.gridbandstock.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black
        Me.gridbandstock.Appearance.GroupRow.Options.UseBackColor = True
        Me.gridbandstock.Appearance.GroupRow.Options.UseBorderColor = True
        Me.gridbandstock.Appearance.GroupRow.Options.UseFont = True
        Me.gridbandstock.Appearance.GroupRow.Options.UseForeColor = True
        Me.gridbandstock.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.gridbandstock.Appearance.HeaderPanel.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.gridbandstock.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.gridbandstock.Appearance.HeaderPanel.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbandstock.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black
        Me.gridbandstock.Appearance.HeaderPanel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.gridbandstock.Appearance.HeaderPanel.Options.UseBackColor = True
        Me.gridbandstock.Appearance.HeaderPanel.Options.UseBorderColor = True
        Me.gridbandstock.Appearance.HeaderPanel.Options.UseFont = True
        Me.gridbandstock.Appearance.HeaderPanel.Options.UseForeColor = True
        Me.gridbandstock.Appearance.HeaderPanelBackground.BackColor = System.Drawing.Color.White
        Me.gridbandstock.Appearance.HeaderPanelBackground.Options.UseBackColor = True
        Me.gridbandstock.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(106, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.gridbandstock.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.gridbandstock.Appearance.HideSelectionRow.Options.UseBackColor = True
        Me.gridbandstock.Appearance.HideSelectionRow.Options.UseForeColor = True
        Me.gridbandstock.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(CType(CType(99, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.gridbandstock.Appearance.HorzLine.Options.UseBackColor = True
        Me.gridbandstock.Appearance.OddRow.BackColor = System.Drawing.Color.White
        Me.gridbandstock.Appearance.OddRow.ForeColor = System.Drawing.Color.Black
        Me.gridbandstock.Appearance.OddRow.Options.UseBackColor = True
        Me.gridbandstock.Appearance.OddRow.Options.UseForeColor = True
        Me.gridbandstock.Appearance.Preview.BackColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.gridbandstock.Appearance.Preview.ForeColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.gridbandstock.Appearance.Preview.Options.UseBackColor = True
        Me.gridbandstock.Appearance.Preview.Options.UseForeColor = True
        Me.gridbandstock.Appearance.Row.BackColor = System.Drawing.Color.White
        Me.gridbandstock.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbandstock.Appearance.Row.ForeColor = System.Drawing.Color.Black
        Me.gridbandstock.Appearance.Row.Options.UseBackColor = True
        Me.gridbandstock.Appearance.Row.Options.UseFont = True
        Me.gridbandstock.Appearance.Row.Options.UseForeColor = True
        Me.gridbandstock.Appearance.RowSeparator.BackColor = System.Drawing.Color.White
        Me.gridbandstock.Appearance.RowSeparator.Options.UseBackColor = True
        Me.gridbandstock.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(126, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.gridbandstock.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White
        Me.gridbandstock.Appearance.SelectedRow.Options.UseBackColor = True
        Me.gridbandstock.Appearance.SelectedRow.Options.UseForeColor = True
        Me.gridbandstock.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(CType(CType(99, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.gridbandstock.Appearance.VertLine.Options.UseBackColor = True
        Me.gridbandstock.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.gridBand1, Me.gridBand2, Me.gridBand3})
        Me.gridbandstock.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.gdate, Me.GITEMNAME, Me.gpartyname, Me.glotno, Me.GSTONWEWT, Me.gpurity, Me.grecgrosswt, Me.grecnettwt, Me.gissuegrosswt, Me.gissuenettwt})
        Me.gridbandstock.GridControl = Me.gridStock
        Me.gridbandstock.Name = "gridbandstock"
        Me.gridbandstock.OptionsBehavior.AllowIncrementalSearch = True
        Me.gridbandstock.OptionsBehavior.Editable = False
        Me.gridbandstock.OptionsBehavior.SummariesIgnoreNullValues = True
        Me.gridbandstock.OptionsCustomization.AllowBandMoving = False
        Me.gridbandstock.OptionsCustomization.AllowBandResizing = False
        Me.gridbandstock.OptionsCustomization.AllowChangeColumnParent = True
        Me.gridbandstock.OptionsCustomization.AllowColumnMoving = False
        Me.gridbandstock.OptionsCustomization.AllowColumnResizing = False
        Me.gridbandstock.OptionsCustomization.AllowGroup = False
        Me.gridbandstock.OptionsCustomization.AllowQuickHideColumns = False
        Me.gridbandstock.OptionsMenu.EnableColumnMenu = False
        Me.gridbandstock.OptionsMenu.EnableGroupPanelMenu = False
        Me.gridbandstock.OptionsMenu.ShowGroupSortSummaryItems = False
        Me.gridbandstock.OptionsView.ColumnAutoWidth = False
        Me.gridbandstock.OptionsView.EnableAppearanceEvenRow = True
        Me.gridbandstock.OptionsView.EnableAppearanceOddRow = True
        Me.gridbandstock.OptionsView.ShowFooter = True
        Me.gridbandstock.OptionsView.ShowGroupPanel = False
        Me.gridbandstock.PaintStyleName = "MixedXP"
        '
        'gridBand1
        '
        Me.gridBand1.Columns.Add(Me.gdate)
        Me.gridBand1.Columns.Add(Me.GITEMNAME)
        Me.gridBand1.Columns.Add(Me.gpartyname)
        Me.gridBand1.Columns.Add(Me.glotno)
        Me.gridBand1.Columns.Add(Me.GSTONWEWT)
        Me.gridBand1.Columns.Add(Me.gpurity)
        Me.gridBand1.Name = "gridBand1"
        Me.gridBand1.OptionsBand.AllowMove = False
        Me.gridBand1.OptionsBand.AllowSize = False
        Me.gridBand1.OptionsBand.FixedWidth = True
        Me.gridBand1.VisibleIndex = 0
        Me.gridBand1.Width = 630
        '
        'gdate
        '
        Me.gdate.AppearanceHeader.Options.UseTextOptions = True
        Me.gdate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gdate.Caption = "Date"
        Me.gdate.FieldName = "DATE"
        Me.gdate.Name = "gdate"
        Me.gdate.Visible = True
        Me.gdate.Width = 80
        '
        'GITEMNAME
        '
        Me.GITEMNAME.Caption = "Item Name"
        Me.GITEMNAME.FieldName = "ITEMNAME"
        Me.GITEMNAME.Name = "GITEMNAME"
        Me.GITEMNAME.Visible = True
        Me.GITEMNAME.Width = 200
        '
        'gpartyname
        '
        Me.gpartyname.AppearanceHeader.Options.UseTextOptions = True
        Me.gpartyname.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gpartyname.Caption = "Name"
        Me.gpartyname.FieldName = "NAME"
        Me.gpartyname.Name = "gpartyname"
        Me.gpartyname.Visible = True
        Me.gpartyname.Width = 120
        '
        'glotno
        '
        Me.glotno.AppearanceHeader.Options.UseTextOptions = True
        Me.glotno.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.glotno.Caption = "Lot No"
        Me.glotno.FieldName = "LOTNO"
        Me.glotno.Name = "glotno"
        Me.glotno.Visible = True
        '
        'GSTONWEWT
        '
        Me.GSTONWEWT.AppearanceCell.Options.UseTextOptions = True
        Me.GSTONWEWT.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GSTONWEWT.AppearanceHeader.Options.UseTextOptions = True
        Me.GSTONWEWT.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GSTONWEWT.Caption = "Stone Wt"
        Me.GSTONWEWT.DisplayFormat.FormatString = "0.000"
        Me.GSTONWEWT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GSTONWEWT.FieldName = "STONEWT"
        Me.GSTONWEWT.Name = "GSTONWEWT"
        Me.GSTONWEWT.Visible = True
        '
        'gpurity
        '
        Me.gpurity.AppearanceCell.Options.UseTextOptions = True
        Me.gpurity.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.gpurity.AppearanceHeader.Options.UseTextOptions = True
        Me.gpurity.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gpurity.Caption = "Purity"
        Me.gpurity.DisplayFormat.FormatString = "0.00"
        Me.gpurity.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.gpurity.FieldName = "PURITY"
        Me.gpurity.Name = "gpurity"
        Me.gpurity.Visible = True
        Me.gpurity.Width = 80
        '
        'gridBand2
        '
        Me.gridBand2.AppearanceHeader.Options.UseTextOptions = True
        Me.gridBand2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gridBand2.Caption = "Receipt"
        Me.gridBand2.Columns.Add(Me.grecgrosswt)
        Me.gridBand2.Columns.Add(Me.grecnettwt)
        Me.gridBand2.Name = "gridBand2"
        Me.gridBand2.OptionsBand.AllowHotTrack = False
        Me.gridBand2.OptionsBand.AllowMove = False
        Me.gridBand2.OptionsBand.AllowSize = False
        Me.gridBand2.OptionsBand.FixedWidth = True
        Me.gridBand2.VisibleIndex = 1
        Me.gridBand2.Width = 180
        '
        'grecgrosswt
        '
        Me.grecgrosswt.AppearanceCell.Options.UseTextOptions = True
        Me.grecgrosswt.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.grecgrosswt.AppearanceHeader.Options.UseTextOptions = True
        Me.grecgrosswt.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.grecgrosswt.Caption = "Gross Wt."
        Me.grecgrosswt.DisplayFormat.FormatString = "0.000"
        Me.grecgrosswt.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.grecgrosswt.FieldName = "RECGROSS"
        Me.grecgrosswt.Name = "grecgrosswt"
        Me.grecgrosswt.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "RECGROSS", "{0:0.000}")})
        Me.grecgrosswt.Visible = True
        Me.grecgrosswt.Width = 90
        '
        'grecnettwt
        '
        Me.grecnettwt.AppearanceCell.Options.UseTextOptions = True
        Me.grecnettwt.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.grecnettwt.AppearanceHeader.Options.UseTextOptions = True
        Me.grecnettwt.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.grecnettwt.Caption = "Nett Wt."
        Me.grecnettwt.DisplayFormat.FormatString = "0.000"
        Me.grecnettwt.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.grecnettwt.FieldName = "RECNETT"
        Me.grecnettwt.Name = "grecnettwt"
        Me.grecnettwt.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "RECNETT", "{0:0.000}")})
        Me.grecnettwt.Visible = True
        Me.grecnettwt.Width = 90
        '
        'gridBand3
        '
        Me.gridBand3.AppearanceHeader.Options.UseTextOptions = True
        Me.gridBand3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gridBand3.Caption = "Issue"
        Me.gridBand3.Columns.Add(Me.gissuegrosswt)
        Me.gridBand3.Columns.Add(Me.gissuenettwt)
        Me.gridBand3.Name = "gridBand3"
        Me.gridBand3.OptionsBand.AllowHotTrack = False
        Me.gridBand3.OptionsBand.AllowMove = False
        Me.gridBand3.OptionsBand.AllowSize = False
        Me.gridBand3.OptionsBand.FixedWidth = True
        Me.gridBand3.VisibleIndex = 2
        Me.gridBand3.Width = 180
        '
        'gissuegrosswt
        '
        Me.gissuegrosswt.AppearanceCell.Options.UseTextOptions = True
        Me.gissuegrosswt.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.gissuegrosswt.AppearanceHeader.Options.UseTextOptions = True
        Me.gissuegrosswt.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gissuegrosswt.Caption = "Gross Wt."
        Me.gissuegrosswt.DisplayFormat.FormatString = "0.000"
        Me.gissuegrosswt.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.gissuegrosswt.FieldName = "ISSGROSS"
        Me.gissuegrosswt.Name = "gissuegrosswt"
        Me.gissuegrosswt.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ISSGROSS", "{0:0.000}")})
        Me.gissuegrosswt.Visible = True
        Me.gissuegrosswt.Width = 90
        '
        'gissuenettwt
        '
        Me.gissuenettwt.AppearanceCell.Options.UseTextOptions = True
        Me.gissuenettwt.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.gissuenettwt.AppearanceHeader.Options.UseTextOptions = True
        Me.gissuenettwt.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gissuenettwt.Caption = "Nett Wt."
        Me.gissuenettwt.DisplayFormat.FormatString = "0.000"
        Me.gissuenettwt.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.gissuenettwt.FieldName = "ISSNETT"
        Me.gissuenettwt.Name = "gissuenettwt"
        Me.gissuenettwt.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ISSNETT", "{0:0.000}")})
        Me.gissuenettwt.Visible = True
        Me.gissuenettwt.Width = 90
        '
        'StockSummary
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1038, 590)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "StockSummary"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Stock Summary"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.gridStock, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridbandstock, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Private WithEvents gridStock As DevExpress.XtraGrid.GridControl
    Friend WithEvents gridbandstock As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents gdate As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents gpartyname As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents gpurity As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents grecgrosswt As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents grecnettwt As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents gissuegrosswt As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents gissuenettwt As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents gridBand1 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand2 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand3 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents txtpurity As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbname As System.Windows.Forms.ComboBox
    Friend WithEvents cmbitemname As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CMDSHOWDETAILS As System.Windows.Forms.Button
    Friend WithEvents dtto As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblto As System.Windows.Forms.Label
    Friend WithEvents dtfrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents chkdate As System.Windows.Forms.CheckBox
    Friend WithEvents lblfrom As System.Windows.Forms.Label
    Friend WithEvents lbl As System.Windows.Forms.Label
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents txtbalnett As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtbalgross As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents PrintToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents glotno As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents EXCEL_ICON As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TOOLREFRESH As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents GITEMNAME As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents TXTCLGROSS As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TXTOPGROSS As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TXTOPNETT As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TXTCLNETT As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents GSTONWEWT As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
End Class
