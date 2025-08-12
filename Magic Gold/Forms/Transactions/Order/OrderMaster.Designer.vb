<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OrderMaster
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(OrderMaster))
        Me.TXTSRNO = New System.Windows.Forms.TextBox()
        Me.lblsrno = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ORDERDATE = New System.Windows.Forms.DateTimePicker()
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
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbname = New System.Windows.Forms.ComboBox()
        Me.DELDATE = New System.Windows.Forms.DateTimePicker()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.LBLDELDAYS = New System.Windows.Forms.Label()
        Me.TXTDELDAYS = New System.Windows.Forms.TextBox()
        Me.cmddelete = New System.Windows.Forms.Button()
        Me.cmdclear = New System.Windows.Forms.Button()
        Me.cmdok = New System.Windows.Forms.Button()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.CMDVIEW = New System.Windows.Forms.Button()
        Me.TXTNEWIMGPATH = New System.Windows.Forms.TextBox()
        Me.TXTFILENAME = New System.Windows.Forms.TextBox()
        Me.txtimgpath = New System.Windows.Forms.TextBox()
        Me.cmdupload = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CMBITEMNAME = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TXTGOLDWT = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TXTCTWT = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TXTSIZE = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TXTQUOTATION = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.TXTREMARKS = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TXTORDERNO = New System.Windows.Forms.TextBox()
        Me.EP = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.CMDCLOSE = New System.Windows.Forms.Button()
        Me.CMDREMOVE = New System.Windows.Forms.Button()
        Me.LBLCLOSED = New System.Windows.Forms.Label()
        Me.PBSoftCopy = New System.Windows.Forms.PictureBox()
        Me.LBLLOCKED = New System.Windows.Forms.PictureBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TXTMELTING = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.CMBPRIORITY = New System.Windows.Forms.ComboBox()
        Me.TXTITEMDESC = New System.Windows.Forms.TextBox()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PBSoftCopy, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LBLLOCKED, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TXTSRNO
        '
        Me.TXTSRNO.BackColor = System.Drawing.Color.Linen
        Me.TXTSRNO.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTSRNO.Location = New System.Drawing.Point(224, 66)
        Me.TXTSRNO.Name = "TXTSRNO"
        Me.TXTSRNO.ReadOnly = True
        Me.TXTSRNO.Size = New System.Drawing.Size(33, 23)
        Me.TXTSRNO.TabIndex = 315
        Me.TXTSRNO.TabStop = False
        Me.TXTSRNO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblsrno
        '
        Me.lblsrno.AutoSize = True
        Me.lblsrno.BackColor = System.Drawing.Color.Transparent
        Me.lblsrno.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblsrno.Location = New System.Drawing.Point(182, 70)
        Me.lblsrno.Name = "lblsrno"
        Me.lblsrno.Size = New System.Drawing.Size(39, 15)
        Me.lblsrno.TabIndex = 316
        Me.lblsrno.Text = "Sr No."
        Me.lblsrno.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(310, 42)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(31, 15)
        Me.Label5.TabIndex = 314
        Me.Label5.Text = "Date"
        '
        'ORDERDATE
        '
        Me.ORDERDATE.CustomFormat = "dd/MM/yyyy  hh:mm:ss tt"
        Me.ORDERDATE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ORDERDATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.ORDERDATE.Location = New System.Drawing.Point(345, 38)
        Me.ORDERDATE.Name = "ORDERDATE"
        Me.ORDERDATE.Size = New System.Drawing.Size(179, 23)
        Me.ORDERDATE.TabIndex = 0
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ToolStrip1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenToolStripButton, Me.SaveToolStripButton, Me.PrintToolStripButton, Me.ToolStripdelete, Me.ToolStripSeparator3, Me.toolprevious, Me.ToolStripSeparator1, Me.toolnext, Me.ToolStripSeparator2})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(548, 25)
        Me.ToolStrip1.TabIndex = 313
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
        Me.toolprevious.Size = New System.Drawing.Size(68, 22)
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
        Me.toolnext.Size = New System.Drawing.Size(50, 22)
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
        Me.tstxtbillno.Location = New System.Drawing.Point(244, 2)
        Me.tstxtbillno.Name = "tstxtbillno"
        Me.tstxtbillno.Size = New System.Drawing.Size(58, 22)
        Me.tstxtbillno.TabIndex = 21
        Me.tstxtbillno.TabStop = False
        Me.tstxtbillno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(30, 42)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(68, 15)
        Me.Label6.TabIndex = 576
        Me.Label6.Text = "Party Name"
        '
        'cmbname
        '
        Me.cmbname.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbname.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbname.BackColor = System.Drawing.Color.LemonChiffon
        Me.cmbname.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbname.FormattingEnabled = True
        Me.cmbname.Location = New System.Drawing.Point(99, 38)
        Me.cmbname.MaxDropDownItems = 14
        Me.cmbname.Name = "cmbname"
        Me.cmbname.Size = New System.Drawing.Size(202, 23)
        Me.cmbname.TabIndex = 2
        '
        'DELDATE
        '
        Me.DELDATE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DELDATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DELDATE.Location = New System.Drawing.Point(99, 94)
        Me.DELDATE.Name = "DELDATE"
        Me.DELDATE.Size = New System.Drawing.Size(86, 23)
        Me.DELDATE.TabIndex = 4
        Me.DELDATE.TabStop = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(47, 98)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(51, 15)
        Me.Label11.TabIndex = 633
        Me.Label11.Text = "Del Date"
        '
        'LBLDELDAYS
        '
        Me.LBLDELDAYS.AutoSize = True
        Me.LBLDELDAYS.BackColor = System.Drawing.Color.Transparent
        Me.LBLDELDAYS.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLDELDAYS.ForeColor = System.Drawing.Color.Black
        Me.LBLDELDAYS.Location = New System.Drawing.Point(46, 70)
        Me.LBLDELDAYS.Name = "LBLDELDAYS"
        Me.LBLDELDAYS.Size = New System.Drawing.Size(52, 15)
        Me.LBLDELDAYS.TabIndex = 658
        Me.LBLDELDAYS.Text = "Del Days"
        '
        'TXTDELDAYS
        '
        Me.TXTDELDAYS.BackColor = System.Drawing.Color.White
        Me.TXTDELDAYS.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTDELDAYS.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTDELDAYS.Location = New System.Drawing.Point(99, 66)
        Me.TXTDELDAYS.Name = "TXTDELDAYS"
        Me.TXTDELDAYS.Size = New System.Drawing.Size(44, 23)
        Me.TXTDELDAYS.TabIndex = 3
        Me.TXTDELDAYS.Text = "0"
        Me.TXTDELDAYS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmddelete
        '
        Me.cmddelete.BackColor = System.Drawing.Color.Transparent
        Me.cmddelete.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmddelete.FlatAppearance.BorderSize = 0
        Me.cmddelete.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmddelete.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmddelete.Location = New System.Drawing.Point(122, 426)
        Me.cmddelete.Name = "cmddelete"
        Me.cmddelete.Size = New System.Drawing.Size(80, 28)
        Me.cmddelete.TabIndex = 19
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
        Me.cmdclear.Location = New System.Drawing.Point(169, 392)
        Me.cmdclear.Name = "cmdclear"
        Me.cmdclear.Size = New System.Drawing.Size(80, 28)
        Me.cmdclear.TabIndex = 17
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
        Me.cmdok.Location = New System.Drawing.Point(79, 392)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(80, 28)
        Me.cmdok.TabIndex = 16
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
        Me.cmdexit.Location = New System.Drawing.Point(208, 426)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 28)
        Me.cmdexit.TabIndex = 20
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'CMDVIEW
        '
        Me.CMDVIEW.BackColor = System.Drawing.Color.Transparent
        Me.CMDVIEW.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDVIEW.FlatAppearance.BorderSize = 0
        Me.CMDVIEW.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDVIEW.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CMDVIEW.Location = New System.Drawing.Point(437, 99)
        Me.CMDVIEW.Name = "CMDVIEW"
        Me.CMDVIEW.Size = New System.Drawing.Size(80, 27)
        Me.CMDVIEW.TabIndex = 14
        Me.CMDVIEW.Text = "&View"
        Me.CMDVIEW.UseVisualStyleBackColor = False
        '
        'TXTNEWIMGPATH
        '
        Me.TXTNEWIMGPATH.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTNEWIMGPATH.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.TXTNEWIMGPATH.Location = New System.Drawing.Point(239, 94)
        Me.TXTNEWIMGPATH.Multiline = True
        Me.TXTNEWIMGPATH.Name = "TXTNEWIMGPATH"
        Me.TXTNEWIMGPATH.Size = New System.Drawing.Size(27, 22)
        Me.TXTNEWIMGPATH.TabIndex = 668
        Me.TXTNEWIMGPATH.Visible = False
        '
        'TXTFILENAME
        '
        Me.TXTFILENAME.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTFILENAME.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.TXTFILENAME.Location = New System.Drawing.Point(214, 94)
        Me.TXTFILENAME.Multiline = True
        Me.TXTFILENAME.Name = "TXTFILENAME"
        Me.TXTFILENAME.Size = New System.Drawing.Size(10, 22)
        Me.TXTFILENAME.TabIndex = 667
        Me.TXTFILENAME.Visible = False
        '
        'txtimgpath
        '
        Me.txtimgpath.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtimgpath.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.txtimgpath.Location = New System.Drawing.Point(230, 94)
        Me.txtimgpath.Multiline = True
        Me.txtimgpath.Name = "txtimgpath"
        Me.txtimgpath.Size = New System.Drawing.Size(12, 22)
        Me.txtimgpath.TabIndex = 666
        Me.txtimgpath.Visible = False
        '
        'cmdupload
        '
        Me.cmdupload.BackColor = System.Drawing.Color.Transparent
        Me.cmdupload.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdupload.FlatAppearance.BorderSize = 0
        Me.cmdupload.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdupload.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdupload.Location = New System.Drawing.Point(351, 99)
        Me.cmdupload.Name = "cmdupload"
        Me.cmdupload.Size = New System.Drawing.Size(80, 27)
        Me.cmdupload.TabIndex = 13
        Me.cmdupload.Text = "&Upload"
        Me.cmdupload.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(38, 126)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 15)
        Me.Label1.TabIndex = 670
        Me.Label1.Text = "Design No"
        '
        'CMBITEMNAME
        '
        Me.CMBITEMNAME.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBITEMNAME.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBITEMNAME.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBITEMNAME.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBITEMNAME.FormattingEnabled = True
        Me.CMBITEMNAME.Location = New System.Drawing.Point(99, 122)
        Me.CMBITEMNAME.MaxDropDownItems = 14
        Me.CMBITEMNAME.Name = "CMBITEMNAME"
        Me.CMBITEMNAME.Size = New System.Drawing.Size(202, 23)
        Me.CMBITEMNAME.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(16, 154)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 15)
        Me.Label2.TabIndex = 672
        Me.Label2.Text = "App. Gold Wt."
        '
        'TXTGOLDWT
        '
        Me.TXTGOLDWT.BackColor = System.Drawing.Color.White
        Me.TXTGOLDWT.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTGOLDWT.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTGOLDWT.Location = New System.Drawing.Point(99, 150)
        Me.TXTGOLDWT.Name = "TXTGOLDWT"
        Me.TXTGOLDWT.Size = New System.Drawing.Size(65, 23)
        Me.TXTGOLDWT.TabIndex = 6
        Me.TXTGOLDWT.Text = "0"
        Me.TXTGOLDWT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(27, 182)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 15)
        Me.Label3.TabIndex = 674
        Me.Label3.Text = "App. Ct. Wt."
        '
        'TXTCTWT
        '
        Me.TXTCTWT.BackColor = System.Drawing.Color.White
        Me.TXTCTWT.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTCTWT.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCTWT.Location = New System.Drawing.Point(99, 178)
        Me.TXTCTWT.Name = "TXTCTWT"
        Me.TXTCTWT.Size = New System.Drawing.Size(65, 23)
        Me.TXTCTWT.TabIndex = 7
        Me.TXTCTWT.Text = "0"
        Me.TXTCTWT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(204, 154)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(27, 15)
        Me.Label4.TabIndex = 676
        Me.Label4.Text = "Size"
        '
        'TXTSIZE
        '
        Me.TXTSIZE.BackColor = System.Drawing.Color.White
        Me.TXTSIZE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTSIZE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTSIZE.Location = New System.Drawing.Point(235, 150)
        Me.TXTSIZE.Name = "TXTSIZE"
        Me.TXTSIZE.Size = New System.Drawing.Size(65, 23)
        Me.TXTSIZE.TabIndex = 8
        Me.TXTSIZE.Text = "0"
        Me.TXTSIZE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(20, 210)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(78, 15)
        Me.Label7.TabIndex = 678
        Me.Label7.Text = "Quote Details"
        '
        'TXTQUOTATION
        '
        Me.TXTQUOTATION.BackColor = System.Drawing.Color.White
        Me.TXTQUOTATION.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTQUOTATION.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTQUOTATION.Location = New System.Drawing.Point(99, 206)
        Me.TXTQUOTATION.MaxLength = 255
        Me.TXTQUOTATION.Name = "TXTQUOTATION"
        Me.TXTQUOTATION.Size = New System.Drawing.Size(202, 23)
        Me.TXTQUOTATION.TabIndex = 10
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.TXTREMARKS)
        Me.GroupBox3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GroupBox3.Location = New System.Drawing.Point(17, 277)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(284, 88)
        Me.GroupBox3.TabIndex = 12
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Remarks"
        '
        'TXTREMARKS
        '
        Me.TXTREMARKS.Location = New System.Drawing.Point(8, 17)
        Me.TXTREMARKS.Multiline = True
        Me.TXTREMARKS.Name = "TXTREMARKS"
        Me.TXTREMARKS.Size = New System.Drawing.Size(270, 62)
        Me.TXTREMARKS.TabIndex = 0
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(287, 70)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(57, 15)
        Me.Label8.TabIndex = 680
        Me.Label8.Text = "Order No"
        '
        'TXTORDERNO
        '
        Me.TXTORDERNO.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTORDERNO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTORDERNO.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTORDERNO.Location = New System.Drawing.Point(345, 66)
        Me.TXTORDERNO.Name = "TXTORDERNO"
        Me.TXTORDERNO.Size = New System.Drawing.Size(179, 23)
        Me.TXTORDERNO.TabIndex = 1
        '
        'EP
        '
        Me.EP.BlinkRate = 0
        Me.EP.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.EP.ContainerControl = Me
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'CMDCLOSE
        '
        Me.CMDCLOSE.BackColor = System.Drawing.Color.Transparent
        Me.CMDCLOSE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDCLOSE.FlatAppearance.BorderSize = 0
        Me.CMDCLOSE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDCLOSE.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CMDCLOSE.Location = New System.Drawing.Point(36, 426)
        Me.CMDCLOSE.Name = "CMDCLOSE"
        Me.CMDCLOSE.Size = New System.Drawing.Size(80, 29)
        Me.CMDCLOSE.TabIndex = 18
        Me.CMDCLOSE.Text = "Close"
        Me.CMDCLOSE.UseVisualStyleBackColor = False
        '
        'CMDREMOVE
        '
        Me.CMDREMOVE.BackColor = System.Drawing.Color.Transparent
        Me.CMDREMOVE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDREMOVE.FlatAppearance.BorderSize = 0
        Me.CMDREMOVE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDREMOVE.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CMDREMOVE.Location = New System.Drawing.Point(397, 132)
        Me.CMDREMOVE.Name = "CMDREMOVE"
        Me.CMDREMOVE.Size = New System.Drawing.Size(80, 27)
        Me.CMDREMOVE.TabIndex = 15
        Me.CMDREMOVE.Text = "&Remove"
        Me.CMDREMOVE.UseVisualStyleBackColor = False
        '
        'LBLCLOSED
        '
        Me.LBLCLOSED.AutoSize = True
        Me.LBLCLOSED.BackColor = System.Drawing.Color.Transparent
        Me.LBLCLOSED.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLCLOSED.ForeColor = System.Drawing.Color.Red
        Me.LBLCLOSED.Location = New System.Drawing.Point(358, 424)
        Me.LBLCLOSED.Name = "LBLCLOSED"
        Me.LBLCLOSED.Size = New System.Drawing.Size(80, 24)
        Me.LBLCLOSED.TabIndex = 684
        Me.LBLCLOSED.Text = "Closed"
        Me.LBLCLOSED.Visible = False
        '
        'PBSoftCopy
        '
        Me.PBSoftCopy.BackColor = System.Drawing.Color.Transparent
        Me.PBSoftCopy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PBSoftCopy.Location = New System.Drawing.Point(351, 167)
        Me.PBSoftCopy.Name = "PBSoftCopy"
        Me.PBSoftCopy.Size = New System.Drawing.Size(166, 198)
        Me.PBSoftCopy.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PBSoftCopy.TabIndex = 664
        Me.PBSoftCopy.TabStop = False
        '
        'LBLLOCKED
        '
        Me.LBLLOCKED.BackColor = System.Drawing.Color.Transparent
        Me.LBLLOCKED.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LBLLOCKED.Image = Global.Magic_Gold.My.Resources.Resources.lock_copy
        Me.LBLLOCKED.Location = New System.Drawing.Point(437, 397)
        Me.LBLLOCKED.Name = "LBLLOCKED"
        Me.LBLLOCKED.Size = New System.Drawing.Size(59, 58)
        Me.LBLLOCKED.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.LBLLOCKED.TabIndex = 685
        Me.LBLLOCKED.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(184, 182)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(47, 15)
        Me.Label9.TabIndex = 687
        Me.Label9.Text = "Melting"
        '
        'TXTMELTING
        '
        Me.TXTMELTING.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTMELTING.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTMELTING.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTMELTING.Location = New System.Drawing.Point(236, 178)
        Me.TXTMELTING.Name = "TXTMELTING"
        Me.TXTMELTING.Size = New System.Drawing.Size(65, 23)
        Me.TXTMELTING.TabIndex = 9
        Me.TXTMELTING.Text = "0"
        Me.TXTMELTING.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(16, 239)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(82, 15)
        Me.Label10.TabIndex = 689
        Me.Label10.Text = "Order Priority"
        '
        'CMBPRIORITY
        '
        Me.CMBPRIORITY.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMBPRIORITY.FormattingEnabled = True
        Me.CMBPRIORITY.Items.AddRange(New Object() {"Normal", "Urgent"})
        Me.CMBPRIORITY.Location = New System.Drawing.Point(99, 235)
        Me.CMBPRIORITY.Name = "CMBPRIORITY"
        Me.CMBPRIORITY.Size = New System.Drawing.Size(103, 23)
        Me.CMBPRIORITY.TabIndex = 11
        '
        'TXTITEMDESC
        '
        Me.TXTITEMDESC.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTITEMDESC.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.TXTITEMDESC.Location = New System.Drawing.Point(269, 222)
        Me.TXTITEMDESC.Multiline = True
        Me.TXTITEMDESC.Name = "TXTITEMDESC"
        Me.TXTITEMDESC.Size = New System.Drawing.Size(10, 22)
        Me.TXTITEMDESC.TabIndex = 690
        Me.TXTITEMDESC.Visible = False
        '
        'OrderMaster
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(548, 466)
        Me.Controls.Add(Me.TXTITEMDESC)
        Me.Controls.Add(Me.CMBPRIORITY)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.TXTMELTING)
        Me.Controls.Add(Me.LBLLOCKED)
        Me.Controls.Add(Me.LBLCLOSED)
        Me.Controls.Add(Me.CMDREMOVE)
        Me.Controls.Add(Me.CMDCLOSE)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.TXTORDERNO)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TXTQUOTATION)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TXTSIZE)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TXTCTWT)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TXTGOLDWT)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CMBITEMNAME)
        Me.Controls.Add(Me.CMDVIEW)
        Me.Controls.Add(Me.TXTNEWIMGPATH)
        Me.Controls.Add(Me.TXTFILENAME)
        Me.Controls.Add(Me.txtimgpath)
        Me.Controls.Add(Me.cmdupload)
        Me.Controls.Add(Me.PBSoftCopy)
        Me.Controls.Add(Me.cmddelete)
        Me.Controls.Add(Me.cmdclear)
        Me.Controls.Add(Me.cmdok)
        Me.Controls.Add(Me.cmdexit)
        Me.Controls.Add(Me.LBLDELDAYS)
        Me.Controls.Add(Me.TXTDELDAYS)
        Me.Controls.Add(Me.DELDATE)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cmbname)
        Me.Controls.Add(Me.tstxtbillno)
        Me.Controls.Add(Me.TXTSRNO)
        Me.Controls.Add(Me.lblsrno)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.ORDERDATE)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "OrderMaster"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Order Master"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PBSoftCopy, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LBLLOCKED, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TXTSRNO As System.Windows.Forms.TextBox
    Friend WithEvents lblsrno As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ORDERDATE As System.Windows.Forms.DateTimePicker
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents OpenToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents SaveToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents PrintToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripdelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolprevious As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolnext As System.Windows.Forms.ToolStripButton
    Friend WithEvents tstxtbillno As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbname As System.Windows.Forms.ComboBox
    Friend WithEvents DELDATE As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents LBLDELDAYS As System.Windows.Forms.Label
    Friend WithEvents TXTDELDAYS As System.Windows.Forms.TextBox
    Friend WithEvents cmddelete As System.Windows.Forms.Button
    Friend WithEvents cmdclear As System.Windows.Forms.Button
    Friend WithEvents cmdok As System.Windows.Forms.Button
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents CMDVIEW As System.Windows.Forms.Button
    Friend WithEvents TXTNEWIMGPATH As System.Windows.Forms.TextBox
    Friend WithEvents TXTFILENAME As System.Windows.Forms.TextBox
    Friend WithEvents txtimgpath As System.Windows.Forms.TextBox
    Friend WithEvents cmdupload As System.Windows.Forms.Button
    Friend WithEvents PBSoftCopy As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CMBITEMNAME As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TXTGOLDWT As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TXTCTWT As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TXTSIZE As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TXTQUOTATION As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents TXTREMARKS As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TXTORDERNO As System.Windows.Forms.TextBox
    Friend WithEvents EP As System.Windows.Forms.ErrorProvider
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents CMDCLOSE As System.Windows.Forms.Button
    Friend WithEvents CMDREMOVE As System.Windows.Forms.Button
    Friend WithEvents LBLCLOSED As System.Windows.Forms.Label
    Friend WithEvents LBLLOCKED As System.Windows.Forms.PictureBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TXTMELTING As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents CMBPRIORITY As System.Windows.Forms.ComboBox
    Friend WithEvents TXTITEMDESC As System.Windows.Forms.TextBox
End Class
