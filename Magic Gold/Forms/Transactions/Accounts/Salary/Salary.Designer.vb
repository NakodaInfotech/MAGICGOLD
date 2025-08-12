<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Salary
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Salary))
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.TXTOT = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TXTBALAMT = New System.Windows.Forms.TextBox()
        Me.TXTTOTALCASH = New System.Windows.Forms.TextBox()
        Me.TXTTOTALAMT = New System.Windows.Forms.TextBox()
        Me.TXTTOTALDEDUCTION = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TXTNAME = New System.Windows.Forms.TextBox()
        Me.TXTCASH = New System.Windows.Forms.TextBox()
        Me.TXTAMOUNT = New System.Windows.Forms.TextBox()
        Me.TXTDEDUCTION = New System.Windows.Forms.TextBox()
        Me.TXTCALCDAYS = New System.Windows.Forms.TextBox()
        Me.TXTGROSSAMT = New System.Windows.Forms.TextBox()
        Me.TXTNIGHTS = New System.Windows.Forms.TextBox()
        Me.TXTABSENT = New System.Windows.Forms.TextBox()
        Me.TXTDAYS = New System.Windows.Forms.TextBox()
        Me.TODATE = New System.Windows.Forms.DateTimePicker()
        Me.FROMDATE = New System.Windows.Forms.DateTimePicker()
        Me.tstxtbillno = New System.Windows.Forms.TextBox()
        Me.TXTTOTALGROSSAMT = New System.Windows.Forms.TextBox()
        Me.TXTSALARY = New System.Windows.Forms.TextBox()
        Me.TXTNARR = New System.Windows.Forms.TextBox()
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
        Me.GRIDSALARY = New System.Windows.Forms.DataGridView()
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
        Me.TXTHOURS = New System.Windows.Forms.TextBox()
        Me.TXTHOURRATE = New System.Windows.Forms.TextBox()
        Me.GSRNO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GCODE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GSALARY = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GFROM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GTO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GDAYS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GABSENT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GNIGHTS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GOT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GHOURRATE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GHOURS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GGROSSAMT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GDEDUCTION = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GAMOUNT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GCASH = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GNARR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BlendPanel1.SuspendLayout()
        CType(Me.GRIDSALARY, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.Color.White)
        Me.BlendPanel1.Controls.Add(Me.TXTHOURRATE)
        Me.BlendPanel1.Controls.Add(Me.TXTHOURS)
        Me.BlendPanel1.Controls.Add(Me.TXTOT)
        Me.BlendPanel1.Controls.Add(Me.Label5)
        Me.BlendPanel1.Controls.Add(Me.TXTBALAMT)
        Me.BlendPanel1.Controls.Add(Me.TXTTOTALCASH)
        Me.BlendPanel1.Controls.Add(Me.TXTTOTALAMT)
        Me.BlendPanel1.Controls.Add(Me.TXTTOTALDEDUCTION)
        Me.BlendPanel1.Controls.Add(Me.Label4)
        Me.BlendPanel1.Controls.Add(Me.Label2)
        Me.BlendPanel1.Controls.Add(Me.TXTNAME)
        Me.BlendPanel1.Controls.Add(Me.TXTCASH)
        Me.BlendPanel1.Controls.Add(Me.TXTAMOUNT)
        Me.BlendPanel1.Controls.Add(Me.TXTDEDUCTION)
        Me.BlendPanel1.Controls.Add(Me.TXTCALCDAYS)
        Me.BlendPanel1.Controls.Add(Me.TXTGROSSAMT)
        Me.BlendPanel1.Controls.Add(Me.TXTNIGHTS)
        Me.BlendPanel1.Controls.Add(Me.TXTABSENT)
        Me.BlendPanel1.Controls.Add(Me.TXTDAYS)
        Me.BlendPanel1.Controls.Add(Me.TODATE)
        Me.BlendPanel1.Controls.Add(Me.FROMDATE)
        Me.BlendPanel1.Controls.Add(Me.tstxtbillno)
        Me.BlendPanel1.Controls.Add(Me.TXTTOTALGROSSAMT)
        Me.BlendPanel1.Controls.Add(Me.TXTSALARY)
        Me.BlendPanel1.Controls.Add(Me.TXTNARR)
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
        Me.BlendPanel1.Controls.Add(Me.GRIDSALARY)
        Me.BlendPanel1.Controls.Add(Me.ToolStrip1)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1154, 572)
        Me.BlendPanel1.TabIndex = 0
        '
        'TXTOT
        '
        Me.TXTOT.BackColor = System.Drawing.Color.White
        Me.TXTOT.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTOT.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.TXTOT.Location = New System.Drawing.Point(622, 89)
        Me.TXTOT.Name = "TXTOT"
        Me.TXTOT.Size = New System.Drawing.Size(40, 23)
        Me.TXTOT.TabIndex = 6
        Me.TXTOT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(308, 47)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(49, 15)
        Me.Label5.TabIndex = 775
        Me.Label5.Text = "Bal Amt"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TXTBALAMT
        '
        Me.TXTBALAMT.BackColor = System.Drawing.Color.Linen
        Me.TXTBALAMT.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTBALAMT.Location = New System.Drawing.Point(292, 65)
        Me.TXTBALAMT.Name = "TXTBALAMT"
        Me.TXTBALAMT.ReadOnly = True
        Me.TXTBALAMT.Size = New System.Drawing.Size(90, 23)
        Me.TXTBALAMT.TabIndex = 774
        Me.TXTBALAMT.TabStop = False
        Me.TXTBALAMT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTTOTALCASH
        '
        Me.TXTTOTALCASH.BackColor = System.Drawing.Color.Linen
        Me.TXTTOTALCASH.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTTOTALCASH.Location = New System.Drawing.Point(902, 491)
        Me.TXTTOTALCASH.Name = "TXTTOTALCASH"
        Me.TXTTOTALCASH.ReadOnly = True
        Me.TXTTOTALCASH.Size = New System.Drawing.Size(80, 23)
        Me.TXTTOTALCASH.TabIndex = 773
        Me.TXTTOTALCASH.TabStop = False
        Me.TXTTOTALCASH.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTTOTALAMT
        '
        Me.TXTTOTALAMT.BackColor = System.Drawing.Color.Linen
        Me.TXTTOTALAMT.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTTOTALAMT.Location = New System.Drawing.Point(822, 491)
        Me.TXTTOTALAMT.Name = "TXTTOTALAMT"
        Me.TXTTOTALAMT.ReadOnly = True
        Me.TXTTOTALAMT.Size = New System.Drawing.Size(80, 23)
        Me.TXTTOTALAMT.TabIndex = 772
        Me.TXTTOTALAMT.TabStop = False
        Me.TXTTOTALAMT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTTOTALDEDUCTION
        '
        Me.TXTTOTALDEDUCTION.BackColor = System.Drawing.Color.Linen
        Me.TXTTOTALDEDUCTION.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTTOTALDEDUCTION.Location = New System.Drawing.Point(742, 491)
        Me.TXTTOTALDEDUCTION.Name = "TXTTOTALDEDUCTION"
        Me.TXTTOTALDEDUCTION.ReadOnly = True
        Me.TXTTOTALDEDUCTION.Size = New System.Drawing.Size(80, 23)
        Me.TXTTOTALDEDUCTION.TabIndex = 771
        Me.TXTTOTALDEDUCTION.TabStop = False
        Me.TXTTOTALDEDUCTION.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(410, 65)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 15)
        Me.Label4.TabIndex = 770
        Me.Label4.Text = "Narration"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(409, 39)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 15)
        Me.Label2.TabIndex = 769
        Me.Label2.Text = "Calc Days"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TXTNAME
        '
        Me.TXTNAME.BackColor = System.Drawing.Color.Linen
        Me.TXTNAME.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTNAME.Location = New System.Drawing.Point(62, 65)
        Me.TXTNAME.Name = "TXTNAME"
        Me.TXTNAME.ReadOnly = True
        Me.TXTNAME.Size = New System.Drawing.Size(229, 23)
        Me.TXTNAME.TabIndex = 768
        Me.TXTNAME.TabStop = False
        '
        'TXTCASH
        '
        Me.TXTCASH.BackColor = System.Drawing.Color.White
        Me.TXTCASH.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCASH.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.TXTCASH.Location = New System.Drawing.Point(1022, 89)
        Me.TXTCASH.Name = "TXTCASH"
        Me.TXTCASH.Size = New System.Drawing.Size(80, 23)
        Me.TXTCASH.TabIndex = 10
        Me.TXTCASH.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTAMOUNT
        '
        Me.TXTAMOUNT.BackColor = System.Drawing.Color.Linen
        Me.TXTAMOUNT.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTAMOUNT.Location = New System.Drawing.Point(942, 89)
        Me.TXTAMOUNT.Name = "TXTAMOUNT"
        Me.TXTAMOUNT.ReadOnly = True
        Me.TXTAMOUNT.Size = New System.Drawing.Size(80, 23)
        Me.TXTAMOUNT.TabIndex = 766
        Me.TXTAMOUNT.TabStop = False
        Me.TXTAMOUNT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTDEDUCTION
        '
        Me.TXTDEDUCTION.BackColor = System.Drawing.Color.White
        Me.TXTDEDUCTION.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTDEDUCTION.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.TXTDEDUCTION.Location = New System.Drawing.Point(862, 89)
        Me.TXTDEDUCTION.Name = "TXTDEDUCTION"
        Me.TXTDEDUCTION.Size = New System.Drawing.Size(80, 23)
        Me.TXTDEDUCTION.TabIndex = 9
        Me.TXTDEDUCTION.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTCALCDAYS
        '
        Me.TXTCALCDAYS.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTCALCDAYS.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCALCDAYS.Location = New System.Drawing.Point(472, 35)
        Me.TXTCALCDAYS.Name = "TXTCALCDAYS"
        Me.TXTCALCDAYS.ReadOnly = True
        Me.TXTCALCDAYS.Size = New System.Drawing.Size(50, 23)
        Me.TXTCALCDAYS.TabIndex = 764
        Me.TXTCALCDAYS.TabStop = False
        Me.TXTCALCDAYS.Text = "30"
        Me.TXTCALCDAYS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTGROSSAMT
        '
        Me.TXTGROSSAMT.BackColor = System.Drawing.Color.Linen
        Me.TXTGROSSAMT.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTGROSSAMT.Location = New System.Drawing.Point(782, 89)
        Me.TXTGROSSAMT.Name = "TXTGROSSAMT"
        Me.TXTGROSSAMT.ReadOnly = True
        Me.TXTGROSSAMT.Size = New System.Drawing.Size(80, 23)
        Me.TXTGROSSAMT.TabIndex = 763
        Me.TXTGROSSAMT.TabStop = False
        Me.TXTGROSSAMT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTNIGHTS
        '
        Me.TXTNIGHTS.BackColor = System.Drawing.Color.White
        Me.TXTNIGHTS.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTNIGHTS.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.TXTNIGHTS.Location = New System.Drawing.Point(572, 89)
        Me.TXTNIGHTS.Name = "TXTNIGHTS"
        Me.TXTNIGHTS.Size = New System.Drawing.Size(50, 23)
        Me.TXTNIGHTS.TabIndex = 5
        Me.TXTNIGHTS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTABSENT
        '
        Me.TXTABSENT.BackColor = System.Drawing.Color.White
        Me.TXTABSENT.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTABSENT.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.TXTABSENT.Location = New System.Drawing.Point(522, 89)
        Me.TXTABSENT.Name = "TXTABSENT"
        Me.TXTABSENT.Size = New System.Drawing.Size(50, 23)
        Me.TXTABSENT.TabIndex = 4
        Me.TXTABSENT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTDAYS
        '
        Me.TXTDAYS.BackColor = System.Drawing.Color.Linen
        Me.TXTDAYS.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTDAYS.Location = New System.Drawing.Point(472, 89)
        Me.TXTDAYS.Name = "TXTDAYS"
        Me.TXTDAYS.ReadOnly = True
        Me.TXTDAYS.Size = New System.Drawing.Size(50, 23)
        Me.TXTDAYS.TabIndex = 760
        Me.TXTDAYS.TabStop = False
        Me.TXTDAYS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TODATE
        '
        Me.TODATE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TODATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TODATE.Location = New System.Drawing.Point(382, 89)
        Me.TODATE.Name = "TODATE"
        Me.TODATE.Size = New System.Drawing.Size(90, 23)
        Me.TODATE.TabIndex = 3
        '
        'FROMDATE
        '
        Me.FROMDATE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FROMDATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.FROMDATE.Location = New System.Drawing.Point(292, 89)
        Me.FROMDATE.Name = "FROMDATE"
        Me.FROMDATE.Size = New System.Drawing.Size(90, 23)
        Me.FROMDATE.TabIndex = 2
        '
        'tstxtbillno
        '
        Me.tstxtbillno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tstxtbillno.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tstxtbillno.Location = New System.Drawing.Point(245, 2)
        Me.tstxtbillno.Name = "tstxtbillno"
        Me.tstxtbillno.Size = New System.Drawing.Size(58, 22)
        Me.tstxtbillno.TabIndex = 16
        Me.tstxtbillno.TabStop = False
        Me.tstxtbillno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTTOTALGROSSAMT
        '
        Me.TXTTOTALGROSSAMT.BackColor = System.Drawing.Color.Linen
        Me.TXTTOTALGROSSAMT.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTTOTALGROSSAMT.Location = New System.Drawing.Point(662, 491)
        Me.TXTTOTALGROSSAMT.Name = "TXTTOTALGROSSAMT"
        Me.TXTTOTALGROSSAMT.ReadOnly = True
        Me.TXTTOTALGROSSAMT.Size = New System.Drawing.Size(80, 23)
        Me.TXTTOTALGROSSAMT.TabIndex = 757
        Me.TXTTOTALGROSSAMT.TabStop = False
        Me.TXTTOTALGROSSAMT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTSALARY
        '
        Me.TXTSALARY.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTSALARY.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTSALARY.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.TXTSALARY.Location = New System.Drawing.Point(212, 89)
        Me.TXTSALARY.Name = "TXTSALARY"
        Me.TXTSALARY.Size = New System.Drawing.Size(80, 23)
        Me.TXTSALARY.TabIndex = 1
        Me.TXTSALARY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTNARR
        '
        Me.TXTNARR.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTNARR.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.TXTNARR.Location = New System.Drawing.Point(472, 61)
        Me.TXTNARR.Name = "TXTNARR"
        Me.TXTNARR.Size = New System.Drawing.Size(310, 23)
        Me.TXTNARR.TabIndex = 3
        Me.TXTNARR.TabStop = False
        '
        'cmddelete
        '
        Me.cmddelete.BackColor = System.Drawing.Color.Transparent
        Me.cmddelete.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmddelete.FlatAppearance.BorderSize = 0
        Me.cmddelete.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmddelete.ForeColor = System.Drawing.Color.Black
        Me.cmddelete.Location = New System.Drawing.Point(505, 537)
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
        Me.cmdexit.Location = New System.Drawing.Point(596, 537)
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
        Me.Label3.Location = New System.Drawing.Point(847, 65)
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
        Me.Label1.Location = New System.Drawing.Point(626, 495)
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
        Me.TXTENTRYNO.Location = New System.Drawing.Point(882, 35)
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
        Me.lblsrno.Location = New System.Drawing.Point(825, 39)
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
        Me.ENTRYDATE.Location = New System.Drawing.Point(882, 61)
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
        Me.CMBCODE.Location = New System.Drawing.Point(62, 89)
        Me.CMBCODE.MaxDropDownItems = 14
        Me.CMBCODE.Name = "CMBCODE"
        Me.CMBCODE.Size = New System.Drawing.Size(150, 23)
        Me.CMBCODE.TabIndex = 0
        '
        'cmdclear
        '
        Me.cmdclear.BackColor = System.Drawing.Color.Transparent
        Me.cmdclear.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdclear.FlatAppearance.BorderSize = 0
        Me.cmdclear.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdclear.ForeColor = System.Drawing.Color.Black
        Me.cmdclear.Location = New System.Drawing.Point(414, 537)
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
        Me.cmdok.Location = New System.Drawing.Point(323, 537)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(85, 28)
        Me.cmdok.TabIndex = 12
        Me.cmdok.Text = "&Save"
        Me.cmdok.UseVisualStyleBackColor = False
        '
        'TXTSRNO
        '
        Me.TXTSRNO.BackColor = System.Drawing.Color.Linen
        Me.TXTSRNO.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTSRNO.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.TXTSRNO.Location = New System.Drawing.Point(22, 89)
        Me.TXTSRNO.Name = "TXTSRNO"
        Me.TXTSRNO.ReadOnly = True
        Me.TXTSRNO.Size = New System.Drawing.Size(40, 23)
        Me.TXTSRNO.TabIndex = 724
        Me.TXTSRNO.TabStop = False
        '
        'GRIDSALARY
        '
        Me.GRIDSALARY.AllowUserToAddRows = False
        Me.GRIDSALARY.AllowUserToDeleteRows = False
        Me.GRIDSALARY.AllowUserToResizeColumns = False
        Me.GRIDSALARY.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(248, Byte), Integer))
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Black
        Me.GRIDSALARY.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.GRIDSALARY.BackgroundColor = System.Drawing.Color.White
        Me.GRIDSALARY.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.GRIDSALARY.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.GRIDSALARY.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.GRIDSALARY.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GRIDSALARY.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.GSRNO, Me.GCODE, Me.GSALARY, Me.GFROM, Me.GTO, Me.GDAYS, Me.GABSENT, Me.GNIGHTS, Me.GOT, Me.GHOURRATE, Me.GHOURS, Me.GGROSSAMT, Me.GDEDUCTION, Me.GAMOUNT, Me.GCASH, Me.GNARR})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GRIDSALARY.DefaultCellStyle = DataGridViewCellStyle5
        Me.GRIDSALARY.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.GRIDSALARY.GridColor = System.Drawing.SystemColors.Control
        Me.GRIDSALARY.Location = New System.Drawing.Point(22, 112)
        Me.GRIDSALARY.MultiSelect = False
        Me.GRIDSALARY.Name = "GRIDSALARY"
        Me.GRIDSALARY.RowHeadersVisible = False
        Me.GRIDSALARY.RowHeadersWidth = 30
        Me.GRIDSALARY.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White
        Me.GRIDSALARY.RowsDefaultCellStyle = DataGridViewCellStyle6
        Me.GRIDSALARY.RowTemplate.Height = 20
        Me.GRIDSALARY.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GRIDSALARY.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.GRIDSALARY.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GRIDSALARY.Size = New System.Drawing.Size(1110, 373)
        Me.GRIDSALARY.TabIndex = 11
        Me.GRIDSALARY.TabStop = False
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ToolStrip1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenToolStripButton, Me.SaveToolStripButton, Me.PrintToolStripButton, Me.ToolStripdelete, Me.ToolStripSeparator3, Me.toolprevious, Me.ToolStripSeparator1, Me.toolnext, Me.ToolStripSeparator2})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1154, 25)
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
        'TXTHOURS
        '
        Me.TXTHOURS.BackColor = System.Drawing.Color.White
        Me.TXTHOURS.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTHOURS.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.TXTHOURS.Location = New System.Drawing.Point(722, 89)
        Me.TXTHOURS.Name = "TXTHOURS"
        Me.TXTHOURS.Size = New System.Drawing.Size(60, 23)
        Me.TXTHOURS.TabIndex = 8
        Me.TXTHOURS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTHOURRATE
        '
        Me.TXTHOURRATE.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTHOURRATE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTHOURRATE.Location = New System.Drawing.Point(662, 89)
        Me.TXTHOURRATE.Name = "TXTHOURRATE"
        Me.TXTHOURRATE.ReadOnly = True
        Me.TXTHOURRATE.Size = New System.Drawing.Size(60, 23)
        Me.TXTHOURRATE.TabIndex = 7
        Me.TXTHOURRATE.Text = "50"
        Me.TXTHOURRATE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.GCODE.DefaultCellStyle = DataGridViewCellStyle3
        Me.GCODE.HeaderText = "Name"
        Me.GCODE.Name = "GCODE"
        Me.GCODE.ReadOnly = True
        Me.GCODE.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GCODE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GCODE.Width = 150
        '
        'GSALARY
        '
        Me.GSALARY.HeaderText = "Salary"
        Me.GSALARY.Name = "GSALARY"
        Me.GSALARY.ReadOnly = True
        Me.GSALARY.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GSALARY.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GSALARY.Width = 80
        '
        'GFROM
        '
        Me.GFROM.HeaderText = "From"
        Me.GFROM.Name = "GFROM"
        Me.GFROM.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GFROM.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GFROM.Width = 90
        '
        'GTO
        '
        Me.GTO.HeaderText = "To"
        Me.GTO.Name = "GTO"
        Me.GTO.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GTO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GTO.Width = 90
        '
        'GDAYS
        '
        Me.GDAYS.HeaderText = "Days"
        Me.GDAYS.Name = "GDAYS"
        Me.GDAYS.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GDAYS.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GDAYS.Width = 50
        '
        'GABSENT
        '
        Me.GABSENT.HeaderText = "Absent"
        Me.GABSENT.Name = "GABSENT"
        Me.GABSENT.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GABSENT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GABSENT.Width = 50
        '
        'GNIGHTS
        '
        Me.GNIGHTS.HeaderText = "Nights"
        Me.GNIGHTS.Name = "GNIGHTS"
        Me.GNIGHTS.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GNIGHTS.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GNIGHTS.Width = 50
        '
        'GOT
        '
        Me.GOT.HeaderText = "OT"
        Me.GOT.Name = "GOT"
        Me.GOT.ReadOnly = True
        Me.GOT.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GOT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GOT.Width = 40
        '
        'GHOURRATE
        '
        Me.GHOURRATE.HeaderText = "H Rate"
        Me.GHOURRATE.Name = "GHOURRATE"
        Me.GHOURRATE.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GHOURRATE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.GHOURRATE.Width = 60
        '
        'GHOURS
        '
        Me.GHOURS.HeaderText = "Hours"
        Me.GHOURS.Name = "GHOURS"
        Me.GHOURS.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GHOURS.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GHOURS.Width = 60
        '
        'GGROSSAMT
        '
        Me.GGROSSAMT.HeaderText = "Gross Amt"
        Me.GGROSSAMT.Name = "GGROSSAMT"
        Me.GGROSSAMT.Width = 80
        '
        'GDEDUCTION
        '
        Me.GDEDUCTION.HeaderText = "Deduction"
        Me.GDEDUCTION.Name = "GDEDUCTION"
        Me.GDEDUCTION.Width = 80
        '
        'GAMOUNT
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.GAMOUNT.DefaultCellStyle = DataGridViewCellStyle4
        Me.GAMOUNT.HeaderText = "Amount"
        Me.GAMOUNT.Name = "GAMOUNT"
        Me.GAMOUNT.ReadOnly = True
        Me.GAMOUNT.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GAMOUNT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GAMOUNT.Width = 80
        '
        'GCASH
        '
        Me.GCASH.HeaderText = "Cash Paid"
        Me.GCASH.Name = "GCASH"
        Me.GCASH.Width = 80
        '
        'GNARR
        '
        Me.GNARR.HeaderText = "Narration"
        Me.GNARR.Name = "GNARR"
        Me.GNARR.ReadOnly = True
        Me.GNARR.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GNARR.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GNARR.Visible = False
        Me.GNARR.Width = 500
        '
        'Salary
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1154, 572)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "Salary"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Salary"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.GRIDSALARY, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents TXTDAYS As System.Windows.Forms.TextBox
    Friend WithEvents TODATE As System.Windows.Forms.DateTimePicker
    Friend WithEvents FROMDATE As System.Windows.Forms.DateTimePicker
    Friend WithEvents tstxtbillno As System.Windows.Forms.TextBox
    Friend WithEvents TXTTOTALGROSSAMT As System.Windows.Forms.TextBox
    Friend WithEvents TXTSALARY As System.Windows.Forms.TextBox
    Friend WithEvents TXTNARR As System.Windows.Forms.TextBox
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
    Friend WithEvents GRIDSALARY As System.Windows.Forms.DataGridView
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
    Friend WithEvents TXTGROSSAMT As System.Windows.Forms.TextBox
    Friend WithEvents TXTNIGHTS As System.Windows.Forms.TextBox
    Friend WithEvents TXTABSENT As System.Windows.Forms.TextBox
    Friend WithEvents TXTCASH As System.Windows.Forms.TextBox
    Friend WithEvents TXTAMOUNT As System.Windows.Forms.TextBox
    Friend WithEvents TXTDEDUCTION As System.Windows.Forms.TextBox
    Friend WithEvents TXTCALCDAYS As System.Windows.Forms.TextBox
    Friend WithEvents TXTNAME As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TXTTOTALCASH As System.Windows.Forms.TextBox
    Friend WithEvents TXTTOTALAMT As System.Windows.Forms.TextBox
    Friend WithEvents TXTTOTALDEDUCTION As System.Windows.Forms.TextBox
    Friend WithEvents EP As System.Windows.Forms.ErrorProvider
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TXTBALAMT As System.Windows.Forms.TextBox
    Friend WithEvents TXTOT As TextBox
    Friend WithEvents TXTHOURRATE As TextBox
    Friend WithEvents TXTHOURS As TextBox
    Friend WithEvents GSRNO As DataGridViewTextBoxColumn
    Friend WithEvents GCODE As DataGridViewTextBoxColumn
    Friend WithEvents GSALARY As DataGridViewTextBoxColumn
    Friend WithEvents GFROM As DataGridViewTextBoxColumn
    Friend WithEvents GTO As DataGridViewTextBoxColumn
    Friend WithEvents GDAYS As DataGridViewTextBoxColumn
    Friend WithEvents GABSENT As DataGridViewTextBoxColumn
    Friend WithEvents GNIGHTS As DataGridViewTextBoxColumn
    Friend WithEvents GOT As DataGridViewTextBoxColumn
    Friend WithEvents GHOURRATE As DataGridViewTextBoxColumn
    Friend WithEvents GHOURS As DataGridViewTextBoxColumn
    Friend WithEvents GGROSSAMT As DataGridViewTextBoxColumn
    Friend WithEvents GDEDUCTION As DataGridViewTextBoxColumn
    Friend WithEvents GAMOUNT As DataGridViewTextBoxColumn
    Friend WithEvents GCASH As DataGridViewTextBoxColumn
    Friend WithEvents GNARR As DataGridViewTextBoxColumn
End Class
