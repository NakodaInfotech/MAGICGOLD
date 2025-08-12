<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dailykhatafilter
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
        Me.chknarr = New System.Windows.Forms.CheckBox()
        Me.chkitem = New System.Windows.Forms.CheckBox()
        Me.chkpurity = New System.Windows.Forms.CheckBox()
        Me.chkbullion = New System.Windows.Forms.CheckBox()
        Me.chkwastage = New System.Windows.Forms.CheckBox()
        Me.chkgrosswt = New System.Windows.Forms.CheckBox()
        Me.cmdExit = New System.Windows.Forms.Button()
        Me.cmdShowReport = New System.Windows.Forms.Button()
        Me.chknettwt = New System.Windows.Forms.CheckBox()
        Me.chkamount = New System.Windows.Forms.CheckBox()
        Me.cmbname = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chkdate = New System.Windows.Forms.CheckBox()
        Me.dtpto = New System.Windows.Forms.DateTimePicker()
        Me.dtpfrom = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.RDSUMM = New System.Windows.Forms.RadioButton()
        Me.RDDTLS = New System.Windows.Forms.RadioButton()
        Me.lbl = New System.Windows.Forms.Label()
        Me.txtpurity = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbitemcode = New System.Windows.Forms.ComboBox()
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.CHKALLPARTY = New System.Windows.Forms.CheckBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.BlendPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'chknarr
        '
        Me.chknarr.AutoSize = True
        Me.chknarr.BackColor = System.Drawing.Color.Transparent
        Me.chknarr.Checked = True
        Me.chknarr.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chknarr.Location = New System.Drawing.Point(21, 44)
        Me.chknarr.Name = "chknarr"
        Me.chknarr.Size = New System.Drawing.Size(51, 18)
        Me.chknarr.TabIndex = 252
        Me.chknarr.Text = "Narr."
        Me.chknarr.UseVisualStyleBackColor = False
        '
        'chkitem
        '
        Me.chkitem.AutoSize = True
        Me.chkitem.BackColor = System.Drawing.Color.Transparent
        Me.chkitem.Checked = True
        Me.chkitem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkitem.Location = New System.Drawing.Point(21, 69)
        Me.chkitem.Name = "chkitem"
        Me.chkitem.Size = New System.Drawing.Size(51, 18)
        Me.chkitem.TabIndex = 253
        Me.chkitem.Text = "Item"
        Me.chkitem.UseVisualStyleBackColor = False
        '
        'chkpurity
        '
        Me.chkpurity.AutoSize = True
        Me.chkpurity.BackColor = System.Drawing.Color.Transparent
        Me.chkpurity.Checked = True
        Me.chkpurity.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkpurity.Location = New System.Drawing.Point(21, 94)
        Me.chkpurity.Name = "chkpurity"
        Me.chkpurity.Size = New System.Drawing.Size(56, 18)
        Me.chkpurity.TabIndex = 254
        Me.chkpurity.Text = "Purity"
        Me.chkpurity.UseVisualStyleBackColor = False
        '
        'chkbullion
        '
        Me.chkbullion.AutoSize = True
        Me.chkbullion.BackColor = System.Drawing.Color.Transparent
        Me.chkbullion.Location = New System.Drawing.Point(21, 119)
        Me.chkbullion.Name = "chkbullion"
        Me.chkbullion.Size = New System.Drawing.Size(66, 18)
        Me.chkbullion.TabIndex = 255
        Me.chkbullion.Text = "Bullion"
        Me.chkbullion.UseVisualStyleBackColor = False
        '
        'chkwastage
        '
        Me.chkwastage.AutoSize = True
        Me.chkwastage.BackColor = System.Drawing.Color.Transparent
        Me.chkwastage.Checked = True
        Me.chkwastage.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkwastage.Location = New System.Drawing.Point(21, 143)
        Me.chkwastage.Name = "chkwastage"
        Me.chkwastage.Size = New System.Drawing.Size(74, 18)
        Me.chkwastage.TabIndex = 256
        Me.chkwastage.Text = "Wastage"
        Me.chkwastage.UseVisualStyleBackColor = False
        '
        'chkgrosswt
        '
        Me.chkgrosswt.AutoSize = True
        Me.chkgrosswt.BackColor = System.Drawing.Color.Transparent
        Me.chkgrosswt.Checked = True
        Me.chkgrosswt.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkgrosswt.Location = New System.Drawing.Point(21, 168)
        Me.chkgrosswt.Name = "chkgrosswt"
        Me.chkgrosswt.Size = New System.Drawing.Size(78, 18)
        Me.chkgrosswt.TabIndex = 257
        Me.chkgrosswt.Text = "Gross Wt."
        Me.chkgrosswt.UseVisualStyleBackColor = False
        '
        'cmdExit
        '
        Me.cmdExit.BackColor = System.Drawing.Color.Transparent
        Me.cmdExit.FlatAppearance.BorderSize = 0
        Me.cmdExit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdExit.Location = New System.Drawing.Point(199, 258)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(85, 28)
        Me.cmdExit.TabIndex = 281
        Me.cmdExit.Text = "E&xit"
        Me.cmdExit.UseVisualStyleBackColor = False
        '
        'cmdShowReport
        '
        Me.cmdShowReport.BackColor = System.Drawing.Color.Transparent
        Me.cmdShowReport.FlatAppearance.BorderSize = 0
        Me.cmdShowReport.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdShowReport.Location = New System.Drawing.Point(108, 258)
        Me.cmdShowReport.Name = "cmdShowReport"
        Me.cmdShowReport.Size = New System.Drawing.Size(85, 28)
        Me.cmdShowReport.TabIndex = 280
        Me.cmdShowReport.Text = "&Show Report"
        Me.cmdShowReport.UseVisualStyleBackColor = False
        '
        'chknettwt
        '
        Me.chknettwt.AutoSize = True
        Me.chknettwt.BackColor = System.Drawing.Color.Transparent
        Me.chknettwt.Checked = True
        Me.chknettwt.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chknettwt.Location = New System.Drawing.Point(21, 193)
        Me.chknettwt.Name = "chknettwt"
        Me.chknettwt.Size = New System.Drawing.Size(70, 18)
        Me.chknettwt.TabIndex = 286
        Me.chknettwt.Text = "Nett Wt."
        Me.chknettwt.UseVisualStyleBackColor = False
        '
        'chkamount
        '
        Me.chkamount.AutoSize = True
        Me.chkamount.BackColor = System.Drawing.Color.Transparent
        Me.chkamount.Checked = True
        Me.chkamount.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkamount.Location = New System.Drawing.Point(21, 218)
        Me.chkamount.Name = "chkamount"
        Me.chkamount.Size = New System.Drawing.Size(68, 18)
        Me.chkamount.TabIndex = 287
        Me.chkamount.Text = "Amount"
        Me.chkamount.UseVisualStyleBackColor = False
        '
        'cmbname
        '
        Me.cmbname.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbname.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbname.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbname.FormattingEnabled = True
        Me.cmbname.Location = New System.Drawing.Point(163, 29)
        Me.cmbname.Name = "cmbname"
        Me.cmbname.Size = New System.Drawing.Size(209, 22)
        Me.cmbname.TabIndex = 295
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(25, 56)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(19, 14)
        Me.Label4.TabIndex = 293
        Me.Label4.Text = "To"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(10, 30)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(34, 14)
        Me.Label3.TabIndex = 292
        Me.Label3.Text = "From"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(122, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 14)
        Me.Label1.TabIndex = 291
        Me.Label1.Text = "Name"
        '
        'chkdate
        '
        Me.chkdate.AutoSize = True
        Me.chkdate.BackColor = System.Drawing.Color.Transparent
        Me.chkdate.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkdate.Location = New System.Drawing.Point(120, 91)
        Me.chkdate.Name = "chkdate"
        Me.chkdate.Size = New System.Drawing.Size(52, 18)
        Me.chkdate.TabIndex = 288
        Me.chkdate.Text = "Date"
        Me.chkdate.UseVisualStyleBackColor = False
        '
        'dtpto
        '
        Me.dtpto.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpto.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpto.Location = New System.Drawing.Point(45, 52)
        Me.dtpto.Name = "dtpto"
        Me.dtpto.Size = New System.Drawing.Size(82, 22)
        Me.dtpto.TabIndex = 290
        '
        'dtpfrom
        '
        Me.dtpfrom.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpfrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpfrom.Location = New System.Drawing.Point(45, 26)
        Me.dtpfrom.Name = "dtpfrom"
        Me.dtpfrom.Size = New System.Drawing.Size(82, 22)
        Me.dtpfrom.TabIndex = 289
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.dtpto)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.dtpfrom)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(109, 91)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(133, 83)
        Me.GroupBox1.TabIndex = 294
        Me.GroupBox1.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.RDSUMM)
        Me.GroupBox2.Controls.Add(Me.RDDTLS)
        Me.GroupBox2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(248, 91)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(124, 83)
        Me.GroupBox2.TabIndex = 296
        Me.GroupBox2.TabStop = False
        '
        'RDSUMM
        '
        Me.RDSUMM.AutoSize = True
        Me.RDSUMM.Checked = True
        Me.RDSUMM.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RDSUMM.Location = New System.Drawing.Point(17, 47)
        Me.RDSUMM.Name = "RDSUMM"
        Me.RDSUMM.Size = New System.Drawing.Size(113, 18)
        Me.RDSUMM.TabIndex = 1
        Me.RDSUMM.TabStop = True
        Me.RDSUMM.Text = "WithOut Details"
        Me.RDSUMM.UseVisualStyleBackColor = True
        '
        'RDDTLS
        '
        Me.RDDTLS.AutoSize = True
        Me.RDDTLS.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RDDTLS.Location = New System.Drawing.Point(17, 23)
        Me.RDDTLS.Name = "RDDTLS"
        Me.RDDTLS.Size = New System.Drawing.Size(65, 18)
        Me.RDDTLS.TabIndex = 0
        Me.RDDTLS.Text = "Details"
        Me.RDDTLS.UseVisualStyleBackColor = True
        '
        'lbl
        '
        Me.lbl.AutoSize = True
        Me.lbl.BackColor = System.Drawing.Color.Transparent
        Me.lbl.Font = New System.Drawing.Font("Arial", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbl.Location = New System.Drawing.Point(12, 10)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(130, 24)
        Me.lbl.TabIndex = 361
        Me.lbl.Text = "Ledger Filter"
        '
        'txtpurity
        '
        Me.txtpurity.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtpurity.Location = New System.Drawing.Point(183, 219)
        Me.txtpurity.Name = "txtpurity"
        Me.txtpurity.Size = New System.Drawing.Size(59, 22)
        Me.txtpurity.TabIndex = 365
        Me.txtpurity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(144, 222)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(37, 14)
        Me.Label5.TabIndex = 364
        Me.Label5.Text = "Purity"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(119, 192)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 14)
        Me.Label2.TabIndex = 362
        Me.Label2.Text = "Item Code"
        '
        'cmbitemcode
        '
        Me.cmbitemcode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbitemcode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbitemcode.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbitemcode.FormattingEnabled = True
        Me.cmbitemcode.Location = New System.Drawing.Point(183, 188)
        Me.cmbitemcode.Name = "cmbitemcode"
        Me.cmbitemcode.Size = New System.Drawing.Size(135, 22)
        Me.cmbitemcode.TabIndex = 363
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.CHKALLPARTY)
        Me.BlendPanel1.Controls.Add(Me.Label5)
        Me.BlendPanel1.Controls.Add(Me.Label2)
        Me.BlendPanel1.Controls.Add(Me.chknarr)
        Me.BlendPanel1.Controls.Add(Me.GroupBox2)
        Me.BlendPanel1.Controls.Add(Me.chkitem)
        Me.BlendPanel1.Controls.Add(Me.cmdExit)
        Me.BlendPanel1.Controls.Add(Me.cmdShowReport)
        Me.BlendPanel1.Controls.Add(Me.chkpurity)
        Me.BlendPanel1.Controls.Add(Me.chkdate)
        Me.BlendPanel1.Controls.Add(Me.chkbullion)
        Me.BlendPanel1.Controls.Add(Me.chkwastage)
        Me.BlendPanel1.Controls.Add(Me.GroupBox1)
        Me.BlendPanel1.Controls.Add(Me.chkgrosswt)
        Me.BlendPanel1.Controls.Add(Me.chkamount)
        Me.BlendPanel1.Controls.Add(Me.chknettwt)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(382, 296)
        Me.BlendPanel1.TabIndex = 366
        '
        'CHKALLPARTY
        '
        Me.CHKALLPARTY.AutoSize = True
        Me.CHKALLPARTY.BackColor = System.Drawing.Color.Transparent
        Me.CHKALLPARTY.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKALLPARTY.Location = New System.Drawing.Point(163, 57)
        Me.CHKALLPARTY.Name = "CHKALLPARTY"
        Me.CHKALLPARTY.Size = New System.Drawing.Size(70, 18)
        Me.CHKALLPARTY.TabIndex = 365
        Me.CHKALLPARTY.Text = "All Party"
        Me.CHKALLPARTY.UseVisualStyleBackColor = False
        Me.CHKALLPARTY.Visible = False
        '
        'dailykhatafilter
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(382, 296)
        Me.Controls.Add(Me.txtpurity)
        Me.Controls.Add(Me.cmbitemcode)
        Me.Controls.Add(Me.lbl)
        Me.Controls.Add(Me.cmbname)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "dailykhatafilter"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Ledger Filter"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents chknarr As System.Windows.Forms.CheckBox
    Friend WithEvents chkitem As System.Windows.Forms.CheckBox
    Friend WithEvents chkpurity As System.Windows.Forms.CheckBox
    Friend WithEvents chkbullion As System.Windows.Forms.CheckBox
    Friend WithEvents chkwastage As System.Windows.Forms.CheckBox
    Friend WithEvents chkgrosswt As System.Windows.Forms.CheckBox
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents cmdShowReport As System.Windows.Forms.Button
    Friend WithEvents chknettwt As System.Windows.Forms.CheckBox
    Friend WithEvents chkamount As System.Windows.Forms.CheckBox
    Friend WithEvents cmbname As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkdate As System.Windows.Forms.CheckBox
    Friend WithEvents dtpto As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpfrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents RDSUMM As System.Windows.Forms.RadioButton
    Friend WithEvents RDDTLS As System.Windows.Forms.RadioButton
    Friend WithEvents lbl As System.Windows.Forms.Label
    Friend WithEvents txtpurity As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbitemcode As System.Windows.Forms.ComboBox
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents CHKALLPARTY As System.Windows.Forms.CheckBox
End Class
