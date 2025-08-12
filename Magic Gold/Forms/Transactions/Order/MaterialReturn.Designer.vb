<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MaterialReturn
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MaterialReturn))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
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
        Me.Label3 = New System.Windows.Forms.Label
        Me.GRIDDATE = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.TXTNAME = New System.Windows.Forms.TextBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.TXTREMARKS = New System.Windows.Forms.TextBox
        Me.TXTTOTALPCS = New System.Windows.Forms.TextBox
        Me.TXTTOTALCTWT = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.TXTRETURNNO = New System.Windows.Forms.TextBox
        Me.lblsrno = New System.Windows.Forms.Label
        Me.CMBITEMNAME = New System.Windows.Forms.ComboBox
        Me.RETURNDATE = New System.Windows.Forms.DateTimePicker
        Me.Label8 = New System.Windows.Forms.Label
        Me.TXTORDERNO = New System.Windows.Forms.TextBox
        Me.CMBCOLOR = New System.Windows.Forms.ComboBox
        Me.CMBSIZE = New System.Windows.Forms.ComboBox
        Me.CMBTYPE = New System.Windows.Forms.ComboBox
        Me.CMDSELECTORDER = New System.Windows.Forms.Button
        Me.cmdclear = New System.Windows.Forms.Button
        Me.cmdok = New System.Windows.Forms.Button
        Me.lbl = New System.Windows.Forms.Label
        Me.TXTPCS = New System.Windows.Forms.TextBox
        Me.TXTCTWT = New System.Windows.Forms.TextBox
        Me.TXTSRNO = New System.Windows.Forms.TextBox
        Me.GRIDRETURN = New System.Windows.Forms.DataGridView
        Me.GSRNO = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.gdate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GITEMNAME = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GTYPE = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GSIZE = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GCOLOR = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GPCS = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GCTWT = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cmddelete = New System.Windows.Forms.Button
        Me.cmdexit = New System.Windows.Forms.Button
        Me.tstxtbillno = New System.Windows.Forms.TextBox
        Me.EP = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.GRIDRETURN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ToolStrip1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenToolStripButton, Me.SaveToolStripButton, Me.PrintToolStripButton, Me.ToolStripdelete, Me.ToolStripSeparator3, Me.toolprevious, Me.ToolStripSeparator1, Me.toolnext, Me.ToolStripSeparator2})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(782, 25)
        Me.ToolStrip1.TabIndex = 316
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
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(529, 69)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(32, 15)
        Me.Label3.TabIndex = 718
        Me.Label3.Text = "Date"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GRIDDATE
        '
        Me.GRIDDATE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRIDDATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.GRIDDATE.Location = New System.Drawing.Point(63, 97)
        Me.GRIDDATE.Name = "GRIDDATE"
        Me.GRIDDATE.Size = New System.Drawing.Size(90, 23)
        Me.GRIDDATE.TabIndex = 697
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(22, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 15)
        Me.Label2.TabIndex = 717
        Me.Label2.Text = "Name"
        '
        'TXTNAME
        '
        Me.TXTNAME.BackColor = System.Drawing.Color.Linen
        Me.TXTNAME.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTNAME.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTNAME.Location = New System.Drawing.Point(63, 68)
        Me.TXTNAME.Name = "TXTNAME"
        Me.TXTNAME.ReadOnly = True
        Me.TXTNAME.Size = New System.Drawing.Size(180, 23)
        Me.TXTNAME.TabIndex = 716
        Me.TXTNAME.TabStop = False
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.TXTREMARKS)
        Me.GroupBox3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GroupBox3.Location = New System.Drawing.Point(22, 289)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(381, 88)
        Me.GroupBox3.TabIndex = 704
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
        'TXTTOTALPCS
        '
        Me.TXTTOTALPCS.BackColor = System.Drawing.Color.Linen
        Me.TXTTOTALPCS.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTTOTALPCS.Location = New System.Drawing.Point(603, 285)
        Me.TXTTOTALPCS.Name = "TXTTOTALPCS"
        Me.TXTTOTALPCS.ReadOnly = True
        Me.TXTTOTALPCS.Size = New System.Drawing.Size(60, 23)
        Me.TXTTOTALPCS.TabIndex = 715
        Me.TXTTOTALPCS.TabStop = False
        Me.TXTTOTALPCS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTTOTALCTWT
        '
        Me.TXTTOTALCTWT.BackColor = System.Drawing.Color.Linen
        Me.TXTTOTALCTWT.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTTOTALCTWT.Location = New System.Drawing.Point(663, 285)
        Me.TXTTOTALCTWT.Name = "TXTTOTALCTWT"
        Me.TXTTOTALCTWT.ReadOnly = True
        Me.TXTTOTALCTWT.Size = New System.Drawing.Size(80, 23)
        Me.TXTTOTALCTWT.TabIndex = 713
        Me.TXTTOTALCTWT.TabStop = False
        Me.TXTTOTALCTWT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(567, 289)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 15)
        Me.Label1.TabIndex = 714
        Me.Label1.Text = "Total"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TXTRETURNNO
        '
        Me.TXTRETURNNO.BackColor = System.Drawing.Color.Linen
        Me.TXTRETURNNO.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTRETURNNO.Location = New System.Drawing.Point(564, 39)
        Me.TXTRETURNNO.Name = "TXTRETURNNO"
        Me.TXTRETURNNO.ReadOnly = True
        Me.TXTRETURNNO.Size = New System.Drawing.Size(88, 23)
        Me.TXTRETURNNO.TabIndex = 711
        Me.TXTRETURNNO.TabStop = False
        Me.TXTRETURNNO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblsrno
        '
        Me.lblsrno.AutoSize = True
        Me.lblsrno.BackColor = System.Drawing.Color.Transparent
        Me.lblsrno.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblsrno.Location = New System.Drawing.Point(497, 43)
        Me.lblsrno.Name = "lblsrno"
        Me.lblsrno.Size = New System.Drawing.Size(64, 15)
        Me.lblsrno.TabIndex = 712
        Me.lblsrno.Text = "Return No."
        Me.lblsrno.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CMBITEMNAME
        '
        Me.CMBITEMNAME.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBITEMNAME.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBITEMNAME.BackColor = System.Drawing.Color.White
        Me.CMBITEMNAME.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBITEMNAME.FormattingEnabled = True
        Me.CMBITEMNAME.Location = New System.Drawing.Point(153, 97)
        Me.CMBITEMNAME.MaxDropDownItems = 14
        Me.CMBITEMNAME.Name = "CMBITEMNAME"
        Me.CMBITEMNAME.Size = New System.Drawing.Size(150, 23)
        Me.CMBITEMNAME.TabIndex = 698
        '
        'RETURNDATE
        '
        Me.RETURNDATE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RETURNDATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.RETURNDATE.Location = New System.Drawing.Point(564, 65)
        Me.RETURNDATE.Name = "RETURNDATE"
        Me.RETURNDATE.Size = New System.Drawing.Size(90, 23)
        Me.RETURNDATE.TabIndex = 694
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(257, 72)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(57, 15)
        Me.Label8.TabIndex = 710
        Me.Label8.Text = "Order No"
        '
        'TXTORDERNO
        '
        Me.TXTORDERNO.BackColor = System.Drawing.Color.Linen
        Me.TXTORDERNO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTORDERNO.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTORDERNO.Location = New System.Drawing.Point(316, 68)
        Me.TXTORDERNO.Name = "TXTORDERNO"
        Me.TXTORDERNO.ReadOnly = True
        Me.TXTORDERNO.Size = New System.Drawing.Size(152, 23)
        Me.TXTORDERNO.TabIndex = 709
        Me.TXTORDERNO.TabStop = False
        '
        'CMBCOLOR
        '
        Me.CMBCOLOR.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBCOLOR.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBCOLOR.BackColor = System.Drawing.Color.White
        Me.CMBCOLOR.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBCOLOR.FormattingEnabled = True
        Me.CMBCOLOR.Location = New System.Drawing.Point(503, 97)
        Me.CMBCOLOR.MaxDropDownItems = 14
        Me.CMBCOLOR.Name = "CMBCOLOR"
        Me.CMBCOLOR.Size = New System.Drawing.Size(100, 23)
        Me.CMBCOLOR.TabIndex = 701
        '
        'CMBSIZE
        '
        Me.CMBSIZE.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBSIZE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBSIZE.BackColor = System.Drawing.Color.White
        Me.CMBSIZE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBSIZE.FormattingEnabled = True
        Me.CMBSIZE.Location = New System.Drawing.Point(403, 97)
        Me.CMBSIZE.MaxDropDownItems = 14
        Me.CMBSIZE.Name = "CMBSIZE"
        Me.CMBSIZE.Size = New System.Drawing.Size(100, 23)
        Me.CMBSIZE.TabIndex = 700
        '
        'CMBTYPE
        '
        Me.CMBTYPE.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBTYPE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBTYPE.BackColor = System.Drawing.Color.White
        Me.CMBTYPE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBTYPE.FormattingEnabled = True
        Me.CMBTYPE.Location = New System.Drawing.Point(303, 97)
        Me.CMBTYPE.MaxDropDownItems = 14
        Me.CMBTYPE.Name = "CMBTYPE"
        Me.CMBTYPE.Size = New System.Drawing.Size(100, 23)
        Me.CMBTYPE.TabIndex = 699
        '
        'CMDSELECTORDER
        '
        Me.CMDSELECTORDER.BackColor = System.Drawing.Color.Transparent
        Me.CMDSELECTORDER.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDSELECTORDER.FlatAppearance.BorderSize = 0
        Me.CMDSELECTORDER.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDSELECTORDER.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CMDSELECTORDER.Location = New System.Drawing.Point(476, 318)
        Me.CMDSELECTORDER.Name = "CMDSELECTORDER"
        Me.CMDSELECTORDER.Size = New System.Drawing.Size(85, 28)
        Me.CMDSELECTORDER.TabIndex = 695
        Me.CMDSELECTORDER.Text = "Select Order"
        Me.CMDSELECTORDER.UseVisualStyleBackColor = False
        '
        'cmdclear
        '
        Me.cmdclear.BackColor = System.Drawing.Color.Transparent
        Me.cmdclear.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdclear.FlatAppearance.BorderSize = 0
        Me.cmdclear.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdclear.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdclear.Location = New System.Drawing.Point(654, 318)
        Me.cmdclear.Name = "cmdclear"
        Me.cmdclear.Size = New System.Drawing.Size(85, 28)
        Me.cmdclear.TabIndex = 706
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
        Me.cmdok.Location = New System.Drawing.Point(565, 318)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(85, 28)
        Me.cmdok.TabIndex = 705
        Me.cmdok.Text = "&Save"
        Me.cmdok.UseVisualStyleBackColor = False
        '
        'lbl
        '
        Me.lbl.AutoSize = True
        Me.lbl.BackColor = System.Drawing.Color.Transparent
        Me.lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbl.Location = New System.Drawing.Point(12, 31)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(151, 24)
        Me.lbl.TabIndex = 708
        Me.lbl.Text = "Material Return"
        '
        'TXTPCS
        '
        Me.TXTPCS.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTPCS.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.TXTPCS.Location = New System.Drawing.Point(603, 97)
        Me.TXTPCS.Name = "TXTPCS"
        Me.TXTPCS.Size = New System.Drawing.Size(60, 22)
        Me.TXTPCS.TabIndex = 702
        Me.TXTPCS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTCTWT
        '
        Me.TXTCTWT.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCTWT.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.TXTCTWT.Location = New System.Drawing.Point(663, 97)
        Me.TXTCTWT.Name = "TXTCTWT"
        Me.TXTCTWT.Size = New System.Drawing.Size(80, 22)
        Me.TXTCTWT.TabIndex = 703
        Me.TXTCTWT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTSRNO
        '
        Me.TXTSRNO.BackColor = System.Drawing.Color.Linen
        Me.TXTSRNO.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTSRNO.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.TXTSRNO.Location = New System.Drawing.Point(23, 97)
        Me.TXTSRNO.Name = "TXTSRNO"
        Me.TXTSRNO.ReadOnly = True
        Me.TXTSRNO.Size = New System.Drawing.Size(40, 22)
        Me.TXTSRNO.TabIndex = 696
        Me.TXTSRNO.TabStop = False
        '
        'GRIDRETURN
        '
        Me.GRIDRETURN.AllowUserToAddRows = False
        Me.GRIDRETURN.AllowUserToDeleteRows = False
        Me.GRIDRETURN.AllowUserToResizeColumns = False
        Me.GRIDRETURN.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(248, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Black
        Me.GRIDRETURN.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.GRIDRETURN.BackgroundColor = System.Drawing.Color.White
        Me.GRIDRETURN.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.GRIDRETURN.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.GRIDRETURN.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.GRIDRETURN.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GRIDRETURN.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.GSRNO, Me.gdate, Me.GITEMNAME, Me.GTYPE, Me.GSIZE, Me.GCOLOR, Me.GPCS, Me.GCTWT})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GRIDRETURN.DefaultCellStyle = DataGridViewCellStyle5
        Me.GRIDRETURN.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.GRIDRETURN.GridColor = System.Drawing.SystemColors.Control
        Me.GRIDRETURN.Location = New System.Drawing.Point(23, 120)
        Me.GRIDRETURN.MultiSelect = False
        Me.GRIDRETURN.Name = "GRIDRETURN"
        Me.GRIDRETURN.RowHeadersVisible = False
        Me.GRIDRETURN.RowHeadersWidth = 30
        Me.GRIDRETURN.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White
        Me.GRIDRETURN.RowsDefaultCellStyle = DataGridViewCellStyle6
        Me.GRIDRETURN.RowTemplate.Height = 20
        Me.GRIDRETURN.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GRIDRETURN.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.GRIDRETURN.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GRIDRETURN.Size = New System.Drawing.Size(747, 164)
        Me.GRIDRETURN.TabIndex = 707
        Me.GRIDRETURN.TabStop = False
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
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.GPCS.DefaultCellStyle = DataGridViewCellStyle3
        Me.GPCS.HeaderText = "Pcs"
        Me.GPCS.Name = "GPCS"
        Me.GPCS.ReadOnly = True
        Me.GPCS.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GPCS.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GPCS.Width = 60
        '
        'GCTWT
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.GCTWT.DefaultCellStyle = DataGridViewCellStyle4
        Me.GCTWT.HeaderText = "Ct. Wt."
        Me.GCTWT.Name = "GCTWT"
        Me.GCTWT.ReadOnly = True
        Me.GCTWT.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GCTWT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GCTWT.Width = 80
        '
        'cmddelete
        '
        Me.cmddelete.BackColor = System.Drawing.Color.Transparent
        Me.cmddelete.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmddelete.FlatAppearance.BorderSize = 0
        Me.cmddelete.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmddelete.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmddelete.Location = New System.Drawing.Point(527, 352)
        Me.cmddelete.Name = "cmddelete"
        Me.cmddelete.Size = New System.Drawing.Size(85, 28)
        Me.cmddelete.TabIndex = 719
        Me.cmddelete.Text = "&Delete"
        Me.cmddelete.UseVisualStyleBackColor = False
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdexit.Location = New System.Drawing.Point(616, 352)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(85, 28)
        Me.cmdexit.TabIndex = 720
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'tstxtbillno
        '
        Me.tstxtbillno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tstxtbillno.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tstxtbillno.Location = New System.Drawing.Point(245, 1)
        Me.tstxtbillno.Name = "tstxtbillno"
        Me.tstxtbillno.Size = New System.Drawing.Size(58, 22)
        Me.tstxtbillno.TabIndex = 721
        Me.tstxtbillno.TabStop = False
        Me.tstxtbillno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'EP
        '
        Me.EP.BlinkRate = 0
        Me.EP.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.EP.ContainerControl = Me
        '
        'MaterialReturn
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(782, 388)
        Me.Controls.Add(Me.tstxtbillno)
        Me.Controls.Add(Me.cmddelete)
        Me.Controls.Add(Me.cmdexit)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.GRIDDATE)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TXTNAME)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.TXTTOTALPCS)
        Me.Controls.Add(Me.TXTTOTALCTWT)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TXTRETURNNO)
        Me.Controls.Add(Me.lblsrno)
        Me.Controls.Add(Me.CMBITEMNAME)
        Me.Controls.Add(Me.RETURNDATE)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.TXTORDERNO)
        Me.Controls.Add(Me.CMBCOLOR)
        Me.Controls.Add(Me.CMBSIZE)
        Me.Controls.Add(Me.CMBTYPE)
        Me.Controls.Add(Me.CMDSELECTORDER)
        Me.Controls.Add(Me.cmdclear)
        Me.Controls.Add(Me.cmdok)
        Me.Controls.Add(Me.lbl)
        Me.Controls.Add(Me.TXTPCS)
        Me.Controls.Add(Me.TXTCTWT)
        Me.Controls.Add(Me.TXTSRNO)
        Me.Controls.Add(Me.GRIDRETURN)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "MaterialReturn"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Material Return"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.GRIDRETURN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
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
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GRIDDATE As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TXTNAME As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents TXTREMARKS As System.Windows.Forms.TextBox
    Friend WithEvents TXTTOTALPCS As System.Windows.Forms.TextBox
    Friend WithEvents TXTTOTALCTWT As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TXTRETURNNO As System.Windows.Forms.TextBox
    Friend WithEvents lblsrno As System.Windows.Forms.Label
    Friend WithEvents CMBITEMNAME As System.Windows.Forms.ComboBox
    Friend WithEvents RETURNDATE As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TXTORDERNO As System.Windows.Forms.TextBox
    Friend WithEvents CMBCOLOR As System.Windows.Forms.ComboBox
    Friend WithEvents CMBSIZE As System.Windows.Forms.ComboBox
    Friend WithEvents CMBTYPE As System.Windows.Forms.ComboBox
    Friend WithEvents CMDSELECTORDER As System.Windows.Forms.Button
    Friend WithEvents cmdclear As System.Windows.Forms.Button
    Friend WithEvents cmdok As System.Windows.Forms.Button
    Friend WithEvents lbl As System.Windows.Forms.Label
    Friend WithEvents TXTPCS As System.Windows.Forms.TextBox
    Friend WithEvents TXTCTWT As System.Windows.Forms.TextBox
    Friend WithEvents TXTSRNO As System.Windows.Forms.TextBox
    Friend WithEvents GRIDRETURN As System.Windows.Forms.DataGridView
    Friend WithEvents GSRNO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gdate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GITEMNAME As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GTYPE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GSIZE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GCOLOR As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GPCS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GCTWT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cmddelete As System.Windows.Forms.Button
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents tstxtbillno As System.Windows.Forms.TextBox
    Friend WithEvents EP As System.Windows.Forms.ErrorProvider
End Class
