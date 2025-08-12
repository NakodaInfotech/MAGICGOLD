<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Voucherdetails
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
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.TOOLADD = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.TOOLREFRESH = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.TOOLPRINT = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel3 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.cmbselect = New System.Windows.Forms.ComboBox()
        Me.txttempname = New System.Windows.Forms.TextBox()
        Me.txtname = New System.Windows.Forms.TextBox()
        Me.cmdcancel = New System.Windows.Forms.Button()
        Me.cmdok = New System.Windows.Forms.Button()
        Me.gridbill = New System.Windows.Forms.DataGridView()
        Me.GPRINT = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.GVOUCHERID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GDATE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GNAME = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GTOTALAMT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GTOTALGROSS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GTOTALWT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GCHK = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.TXTFROM = New System.Windows.Forms.TextBox()
        Me.TXTTO = New System.Windows.Forms.TextBox()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TOOLADD, Me.toolStripSeparator, Me.TOOLREFRESH, Me.ToolStripSeparator1, Me.TOOLPRINT, Me.ToolStripSeparator2, Me.ToolStripLabel1, Me.ToolStripLabel3, Me.ToolStripLabel2})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(832, 25)
        Me.ToolStrip1.TabIndex = 247
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'TOOLADD
        '
        Me.TOOLADD.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.TOOLADD.Image = Global.Magic_Gold.My.Resources.Resources.Be_Navigator
        Me.TOOLADD.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TOOLADD.Name = "TOOLADD"
        Me.TOOLADD.Size = New System.Drawing.Size(75, 22)
        Me.TOOLADD.Text = "Add New"
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'TOOLREFRESH
        '
        Me.TOOLREFRESH.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TOOLREFRESH.Image = Global.Magic_Gold.My.Resources.Resources.refreshimage
        Me.TOOLREFRESH.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TOOLREFRESH.Name = "TOOLREFRESH"
        Me.TOOLREFRESH.Size = New System.Drawing.Size(23, 22)
        Me.TOOLREFRESH.Text = "ToolStripButton2"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'TOOLPRINT
        '
        Me.TOOLPRINT.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TOOLPRINT.Image = Global.Magic_Gold.My.Resources.Resources._1_Normal_Printer_icon
        Me.TOOLPRINT.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TOOLPRINT.Name = "TOOLPRINT"
        Me.TOOLPRINT.Size = New System.Drawing.Size(23, 22)
        Me.TOOLPRINT.Text = "ToolStripButton2"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(63, 22)
        Me.ToolStripLabel1.Text = "Print From"
        '
        'ToolStripLabel3
        '
        Me.ToolStripLabel3.AutoSize = False
        Me.ToolStripLabel3.Name = "ToolStripLabel3"
        Me.ToolStripLabel3.Size = New System.Drawing.Size(65, 22)
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(19, 22)
        Me.ToolStripLabel2.Text = "To"
        '
        'cmbselect
        '
        Me.cmbselect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbselect.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbselect.FormattingEnabled = True
        Me.cmbselect.Items.AddRange(New Object() {"", "Bill No.", "Name", "Ref No."})
        Me.cmbselect.Location = New System.Drawing.Point(14, 36)
        Me.cmbselect.Name = "cmbselect"
        Me.cmbselect.Size = New System.Drawing.Size(72, 22)
        Me.cmbselect.TabIndex = 244
        '
        'txttempname
        '
        Me.txttempname.BackColor = System.Drawing.Color.White
        Me.txttempname.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txttempname.ForeColor = System.Drawing.Color.Black
        Me.txttempname.Location = New System.Drawing.Point(299, 37)
        Me.txttempname.Name = "txttempname"
        Me.txttempname.ReadOnly = True
        Me.txttempname.Size = New System.Drawing.Size(150, 22)
        Me.txttempname.TabIndex = 246
        Me.txttempname.TabStop = False
        Me.txttempname.Visible = False
        '
        'txtname
        '
        Me.txtname.BackColor = System.Drawing.Color.White
        Me.txtname.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtname.ForeColor = System.Drawing.Color.Black
        Me.txtname.Location = New System.Drawing.Point(92, 37)
        Me.txtname.Name = "txtname"
        Me.txtname.Size = New System.Drawing.Size(201, 22)
        Me.txtname.TabIndex = 245
        '
        'cmdcancel
        '
        Me.cmdcancel.BackColor = System.Drawing.Color.Transparent
        Me.cmdcancel.FlatAppearance.BorderSize = 0
        Me.cmdcancel.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdcancel.ForeColor = System.Drawing.Color.Black
        Me.cmdcancel.Location = New System.Drawing.Point(419, 526)
        Me.cmdcancel.Name = "cmdcancel"
        Me.cmdcancel.Size = New System.Drawing.Size(80, 28)
        Me.cmdcancel.TabIndex = 242
        Me.cmdcancel.Text = "E&xit"
        Me.cmdcancel.UseVisualStyleBackColor = False
        '
        'cmdok
        '
        Me.cmdok.BackColor = System.Drawing.Color.Transparent
        Me.cmdok.FlatAppearance.BorderSize = 0
        Me.cmdok.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdok.ForeColor = System.Drawing.Color.Black
        Me.cmdok.Location = New System.Drawing.Point(333, 526)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(80, 28)
        Me.cmdok.TabIndex = 241
        Me.cmdok.Text = "&Ok"
        Me.cmdok.UseVisualStyleBackColor = False
        '
        'gridbill
        '
        Me.gridbill.AllowUserToAddRows = False
        Me.gridbill.AllowUserToDeleteRows = False
        Me.gridbill.AllowUserToResizeColumns = False
        Me.gridbill.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.gridbill.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.gridbill.BackgroundColor = System.Drawing.Color.White
        Me.gridbill.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gridbill.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.gridbill.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridbill.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.GPRINT, Me.GVOUCHERID, Me.GDATE, Me.GNAME, Me.GTOTALAMT, Me.GTOTALGROSS, Me.GTOTALWT, Me.GCHK})
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gridbill.DefaultCellStyle = DataGridViewCellStyle6
        Me.gridbill.GridColor = System.Drawing.SystemColors.Control
        Me.gridbill.Location = New System.Drawing.Point(14, 59)
        Me.gridbill.Margin = New System.Windows.Forms.Padding(2)
        Me.gridbill.MultiSelect = False
        Me.gridbill.Name = "gridbill"
        Me.gridbill.ReadOnly = True
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gridbill.RowHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.gridbill.RowHeadersVisible = False
        Me.gridbill.RowHeadersWidth = 30
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.Black
        Me.gridbill.RowsDefaultCellStyle = DataGridViewCellStyle8
        Me.gridbill.RowTemplate.Height = 20
        Me.gridbill.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.gridbill.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridbill.Size = New System.Drawing.Size(804, 462)
        Me.gridbill.TabIndex = 240
        '
        'GPRINT
        '
        Me.GPRINT.HeaderText = "Print"
        Me.GPRINT.Name = "GPRINT"
        Me.GPRINT.ReadOnly = True
        Me.GPRINT.Width = 50
        '
        'GVOUCHERID
        '
        Me.GVOUCHERID.HeaderText = "Bill No"
        Me.GVOUCHERID.Name = "GVOUCHERID"
        Me.GVOUCHERID.ReadOnly = True
        Me.GVOUCHERID.Width = 70
        '
        'GDATE
        '
        Me.GDATE.HeaderText = "Date"
        Me.GDATE.Name = "GDATE"
        Me.GDATE.ReadOnly = True
        '
        'GNAME
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.GNAME.DefaultCellStyle = DataGridViewCellStyle3
        Me.GNAME.HeaderText = "Name"
        Me.GNAME.Name = "GNAME"
        Me.GNAME.ReadOnly = True
        Me.GNAME.Width = 200
        '
        'GTOTALAMT
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.GTOTALAMT.DefaultCellStyle = DataGridViewCellStyle4
        Me.GTOTALAMT.HeaderText = "Total Amt"
        Me.GTOTALAMT.Name = "GTOTALAMT"
        Me.GTOTALAMT.ReadOnly = True
        '
        'GTOTALGROSS
        '
        Me.GTOTALGROSS.HeaderText = "Gross Wt"
        Me.GTOTALGROSS.Name = "GTOTALGROSS"
        Me.GTOTALGROSS.ReadOnly = True
        '
        'GTOTALWT
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.GTOTALWT.DefaultCellStyle = DataGridViewCellStyle5
        Me.GTOTALWT.HeaderText = "Nett Wt."
        Me.GTOTALWT.Name = "GTOTALWT"
        Me.GTOTALWT.ReadOnly = True
        '
        'GCHK
        '
        Me.GCHK.HeaderText = "Chk"
        Me.GCHK.Name = "GCHK"
        Me.GCHK.ReadOnly = True
        Me.GCHK.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GCHK.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.GCHK.Width = 50
        '
        'TXTFROM
        '
        Me.TXTFROM.BackColor = System.Drawing.Color.White
        Me.TXTFROM.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTFROM.ForeColor = System.Drawing.Color.Black
        Me.TXTFROM.Location = New System.Drawing.Point(215, 2)
        Me.TXTFROM.Name = "TXTFROM"
        Me.TXTFROM.Size = New System.Drawing.Size(54, 22)
        Me.TXTFROM.TabIndex = 248
        Me.TXTFROM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTTO
        '
        Me.TXTTO.BackColor = System.Drawing.Color.White
        Me.TXTTO.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTTO.ForeColor = System.Drawing.Color.Black
        Me.TXTTO.Location = New System.Drawing.Point(302, 2)
        Me.TXTTO.Name = "TXTTO"
        Me.TXTTO.Size = New System.Drawing.Size(54, 22)
        Me.TXTTO.TabIndex = 249
        Me.TXTTO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Voucherdetails
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(832, 562)
        Me.Controls.Add(Me.TXTTO)
        Me.Controls.Add(Me.TXTFROM)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.cmbselect)
        Me.Controls.Add(Me.txttempname)
        Me.Controls.Add(Me.txtname)
        Me.Controls.Add(Me.cmdcancel)
        Me.Controls.Add(Me.cmdok)
        Me.Controls.Add(Me.gridbill)
        Me.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "Voucherdetails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Voucher Details"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents TOOLADD As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Private WithEvents cmbselect As System.Windows.Forms.ComboBox
    Friend WithEvents txttempname As System.Windows.Forms.TextBox
    Friend WithEvents txtname As System.Windows.Forms.TextBox
    Friend WithEvents cmdcancel As System.Windows.Forms.Button
    Friend WithEvents cmdok As System.Windows.Forms.Button
    Friend WithEvents gridbill As System.Windows.Forms.DataGridView
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TOOLREFRESH As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents TXTFROM As System.Windows.Forms.TextBox
    Friend WithEvents ToolStripLabel3 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents TXTTO As System.Windows.Forms.TextBox
    Friend WithEvents TOOLPRINT As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents GPRINT As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents GVOUCHERID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GDATE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GNAME As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GTOTALAMT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GTOTALGROSS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GTOTALWT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GCHK As System.Windows.Forms.DataGridViewCheckBoxColumn
End Class
