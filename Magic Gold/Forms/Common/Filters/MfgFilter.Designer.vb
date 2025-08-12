<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class mfgfilter
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
        Me.gridac = New System.Windows.Forms.DataGridView
        Me.CHK = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.GNAME = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.cmdExit = New System.Windows.Forms.Button
        Me.cmdShowReport = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.dtpto = New System.Windows.Forms.DateTimePicker
        Me.dtpfrom = New System.Windows.Forms.DateTimePicker
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.chkdate = New System.Windows.Forms.CheckBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmbprocess = New System.Windows.Forms.ComboBox
        Me.lbllotno = New System.Windows.Forms.Label
        Me.txtlotno = New System.Windows.Forms.TextBox
        Me.chkall = New System.Windows.Forms.CheckBox
        Me.BlendPanel1 = New VbPowerPack.BlendPanel
        Me.GPLOSS = New System.Windows.Forms.GroupBox
        Me.RBALL = New System.Windows.Forms.RadioButton
        Me.RBPARTYLOSS = New System.Windows.Forms.RadioButton
        Me.RBMFGLOSS = New System.Windows.Forms.RadioButton
        CType(Me.gridac, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.BlendPanel1.SuspendLayout()
        Me.GPLOSS.SuspendLayout()
        Me.SuspendLayout()
        '
        'gridac
        '
        Me.gridac.AllowUserToAddRows = False
        Me.gridac.AllowUserToDeleteRows = False
        Me.gridac.AllowUserToResizeColumns = False
        Me.gridac.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.gridac.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.gridac.BackgroundColor = System.Drawing.Color.White
        Me.gridac.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gridac.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.gridac.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridac.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CHK, Me.GNAME})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gridac.DefaultCellStyle = DataGridViewCellStyle3
        Me.gridac.GridColor = System.Drawing.SystemColors.Control
        Me.gridac.Location = New System.Drawing.Point(8, 19)
        Me.gridac.Margin = New System.Windows.Forms.Padding(2)
        Me.gridac.MultiSelect = False
        Me.gridac.Name = "gridac"
        Me.gridac.RowHeadersVisible = False
        Me.gridac.RowHeadersWidth = 30
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Black
        Me.gridac.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.gridac.RowTemplate.Height = 20
        Me.gridac.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.gridac.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridac.Size = New System.Drawing.Size(212, 272)
        Me.gridac.TabIndex = 0
        '
        'CHK
        '
        Me.CHK.HeaderText = ""
        Me.CHK.Name = "CHK"
        Me.CHK.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.CHK.Width = 35
        '
        'GNAME
        '
        Me.GNAME.HeaderText = "A/C's"
        Me.GNAME.Name = "GNAME"
        Me.GNAME.ReadOnly = True
        Me.GNAME.Width = 150
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.gridac)
        Me.GroupBox2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.Black
        Me.GroupBox2.Location = New System.Drawing.Point(29, 42)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(227, 299)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "A/C"
        '
        'cmdExit
        '
        Me.cmdExit.BackColor = System.Drawing.Color.Transparent
        Me.cmdExit.FlatAppearance.BorderSize = 0
        Me.cmdExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdExit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdExit.Image = Global.Magic_Gold.My.Resources.Resources._Exit
        Me.cmdExit.Location = New System.Drawing.Point(135, 492)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(84, 26)
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
        Me.cmdShowReport.Location = New System.Drawing.Point(65, 491)
        Me.cmdShowReport.Name = "cmdShowReport"
        Me.cmdShowReport.Size = New System.Drawing.Size(73, 26)
        Me.cmdShowReport.TabIndex = 6
        Me.cmdShowReport.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.dtpto)
        Me.GroupBox1.Controls.Add(Me.dtpfrom)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(19, 426)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(244, 60)
        Me.GroupBox1.TabIndex = 5
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
        Me.Label3.Size = New System.Drawing.Size(34, 14)
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
        Me.Label4.Size = New System.Drawing.Size(19, 14)
        Me.Label4.TabIndex = 273
        Me.Label4.Text = "To"
        '
        'chkdate
        '
        Me.chkdate.AutoSize = True
        Me.chkdate.BackColor = System.Drawing.Color.Transparent
        Me.chkdate.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkdate.Location = New System.Drawing.Point(30, 426)
        Me.chkdate.Name = "chkdate"
        Me.chkdate.Size = New System.Drawing.Size(52, 18)
        Me.chkdate.TabIndex = 4
        Me.chkdate.Text = "Date"
        Me.chkdate.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(15, 354)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 14)
        Me.Label1.TabIndex = 271
        Me.Label1.Text = "Process"
        '
        'cmbprocess
        '
        Me.cmbprocess.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbprocess.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbprocess.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbprocess.FormattingEnabled = True
        Me.cmbprocess.Location = New System.Drawing.Point(65, 350)
        Me.cmbprocess.Name = "cmbprocess"
        Me.cmbprocess.Size = New System.Drawing.Size(185, 22)
        Me.cmbprocess.TabIndex = 1
        '
        'lbllotno
        '
        Me.lbllotno.AutoSize = True
        Me.lbllotno.BackColor = System.Drawing.Color.Transparent
        Me.lbllotno.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbllotno.Location = New System.Drawing.Point(135, 17)
        Me.lbllotno.Name = "lbllotno"
        Me.lbllotno.Size = New System.Drawing.Size(41, 14)
        Me.lbllotno.TabIndex = 345
        Me.lbllotno.Text = "Lot No"
        '
        'txtlotno
        '
        Me.txtlotno.BackColor = System.Drawing.Color.White
        Me.txtlotno.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtlotno.ForeColor = System.Drawing.Color.Black
        Me.txtlotno.Location = New System.Drawing.Point(180, 13)
        Me.txtlotno.Multiline = True
        Me.txtlotno.Name = "txtlotno"
        Me.txtlotno.Size = New System.Drawing.Size(39, 23)
        Me.txtlotno.TabIndex = 1
        Me.txtlotno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chkall
        '
        Me.chkall.AutoSize = True
        Me.chkall.BackColor = System.Drawing.Color.Transparent
        Me.chkall.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkall.Location = New System.Drawing.Point(40, 15)
        Me.chkall.Name = "chkall"
        Me.chkall.Size = New System.Drawing.Size(77, 18)
        Me.chkall.TabIndex = 0
        Me.chkall.Text = "Select All"
        Me.chkall.UseVisualStyleBackColor = False
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.GPLOSS)
        Me.BlendPanel1.Controls.Add(Me.chkdate)
        Me.BlendPanel1.Controls.Add(Me.chkall)
        Me.BlendPanel1.Controls.Add(Me.cmdExit)
        Me.BlendPanel1.Controls.Add(Me.lbllotno)
        Me.BlendPanel1.Controls.Add(Me.GroupBox1)
        Me.BlendPanel1.Controls.Add(Me.txtlotno)
        Me.BlendPanel1.Controls.Add(Me.cmdShowReport)
        Me.BlendPanel1.Controls.Add(Me.GroupBox2)
        Me.BlendPanel1.Controls.Add(Me.Label1)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(284, 531)
        Me.BlendPanel1.TabIndex = 0
        '
        'GPLOSS
        '
        Me.GPLOSS.BackColor = System.Drawing.Color.Transparent
        Me.GPLOSS.Controls.Add(Me.RBALL)
        Me.GPLOSS.Controls.Add(Me.RBPARTYLOSS)
        Me.GPLOSS.Controls.Add(Me.RBMFGLOSS)
        Me.GPLOSS.Location = New System.Drawing.Point(27, 378)
        Me.GPLOSS.Name = "GPLOSS"
        Me.GPLOSS.Size = New System.Drawing.Size(231, 42)
        Me.GPLOSS.TabIndex = 3
        Me.GPLOSS.TabStop = False
        Me.GPLOSS.Visible = False
        '
        'RBALL
        '
        Me.RBALL.AutoSize = True
        Me.RBALL.BackColor = System.Drawing.Color.Transparent
        Me.RBALL.Checked = True
        Me.RBALL.Location = New System.Drawing.Point(2, 16)
        Me.RBALL.Name = "RBALL"
        Me.RBALL.Size = New System.Drawing.Size(40, 18)
        Me.RBALL.TabIndex = 0
        Me.RBALL.TabStop = True
        Me.RBALL.Text = "All"
        Me.RBALL.UseVisualStyleBackColor = False
        '
        'RBPARTYLOSS
        '
        Me.RBPARTYLOSS.AutoSize = True
        Me.RBPARTYLOSS.BackColor = System.Drawing.Color.Transparent
        Me.RBPARTYLOSS.Location = New System.Drawing.Point(150, 16)
        Me.RBPARTYLOSS.Name = "RBPARTYLOSS"
        Me.RBPARTYLOSS.Size = New System.Drawing.Size(78, 18)
        Me.RBPARTYLOSS.TabIndex = 2
        Me.RBPARTYLOSS.TabStop = True
        Me.RBPARTYLOSS.Text = "Party Loss"
        Me.RBPARTYLOSS.UseVisualStyleBackColor = False
        '
        'RBMFGLOSS
        '
        Me.RBMFGLOSS.AutoSize = True
        Me.RBMFGLOSS.BackColor = System.Drawing.Color.Transparent
        Me.RBMFGLOSS.Location = New System.Drawing.Point(60, 16)
        Me.RBMFGLOSS.Name = "RBMFGLOSS"
        Me.RBMFGLOSS.Size = New System.Drawing.Size(72, 18)
        Me.RBMFGLOSS.TabIndex = 1
        Me.RBMFGLOSS.TabStop = True
        Me.RBMFGLOSS.Text = "Mfg Loss"
        Me.RBMFGLOSS.UseVisualStyleBackColor = False
        '
        'mfgfilter
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(284, 531)
        Me.Controls.Add(Me.cmbprocess)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "mfgfilter"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Mfg Filter"
        CType(Me.gridac, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        Me.GPLOSS.ResumeLayout(False)
        Me.GPLOSS.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gridac As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents cmdShowReport As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dtpfrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpto As System.Windows.Forms.DateTimePicker
    Friend WithEvents chkdate As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbprocess As System.Windows.Forms.ComboBox
    Friend WithEvents lbllotno As System.Windows.Forms.Label
    Friend WithEvents txtlotno As System.Windows.Forms.TextBox
    Friend WithEvents chkall As System.Windows.Forms.CheckBox
    Friend WithEvents CHK As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents GNAME As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents GPLOSS As System.Windows.Forms.GroupBox
    Friend WithEvents RBALL As System.Windows.Forms.RadioButton
    Friend WithEvents RBPARTYLOSS As System.Windows.Forms.RadioButton
    Friend WithEvents RBMFGLOSS As System.Windows.Forms.RadioButton
End Class
