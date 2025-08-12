<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class KarigarFilter
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
        Me.BlendPanel1 = New VbPowerPack.BlendPanel
        Me.RBLEDGER = New System.Windows.Forms.RadioButton
        Me.Label5 = New System.Windows.Forms.Label
        Me.CMBGM = New System.Windows.Forms.ComboBox
        Me.RBSUMMARY = New System.Windows.Forms.RadioButton
        Me.RBDETAILS = New System.Windows.Forms.RadioButton
        Me.Label2 = New System.Windows.Forms.Label
        Me.CMBITEMNAME = New System.Windows.Forms.ComboBox
        Me.lblname = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmbname = New System.Windows.Forms.ComboBox
        Me.chkdate = New System.Windows.Forms.CheckBox
        Me.cmdShowReport = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.dtpto = New System.Windows.Forms.DateTimePicker
        Me.dtpfrom = New System.Windows.Forms.DateTimePicker
        Me.Label4 = New System.Windows.Forms.Label
        Me.lbl = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmdExit = New System.Windows.Forms.Button
        Me.BlendPanel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.RBLEDGER)
        Me.BlendPanel1.Controls.Add(Me.Label5)
        Me.BlendPanel1.Controls.Add(Me.CMBGM)
        Me.BlendPanel1.Controls.Add(Me.RBSUMMARY)
        Me.BlendPanel1.Controls.Add(Me.RBDETAILS)
        Me.BlendPanel1.Controls.Add(Me.Label2)
        Me.BlendPanel1.Controls.Add(Me.CMBITEMNAME)
        Me.BlendPanel1.Controls.Add(Me.lblname)
        Me.BlendPanel1.Controls.Add(Me.Label1)
        Me.BlendPanel1.Controls.Add(Me.cmbname)
        Me.BlendPanel1.Controls.Add(Me.chkdate)
        Me.BlendPanel1.Controls.Add(Me.cmdShowReport)
        Me.BlendPanel1.Controls.Add(Me.GroupBox1)
        Me.BlendPanel1.Controls.Add(Me.cmdExit)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(284, 289)
        Me.BlendPanel1.TabIndex = 0
        '
        'RBLEDGER
        '
        Me.RBLEDGER.AutoSize = True
        Me.RBLEDGER.BackColor = System.Drawing.Color.Transparent
        Me.RBLEDGER.Location = New System.Drawing.Point(62, 133)
        Me.RBLEDGER.Name = "RBLEDGER"
        Me.RBLEDGER.Size = New System.Drawing.Size(102, 18)
        Me.RBLEDGER.TabIndex = 5
        Me.RBLEDGER.Text = "Karigar Ledger"
        Me.RBLEDGER.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(66, 77)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(25, 14)
        Me.Label5.TabIndex = 386
        Me.Label5.Text = "GM"
        '
        'CMBGM
        '
        Me.CMBGM.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBGM.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBGM.BackColor = System.Drawing.Color.White
        Me.CMBGM.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBGM.Items.AddRange(New Object() {""})
        Me.CMBGM.Location = New System.Drawing.Point(93, 73)
        Me.CMBGM.Name = "CMBGM"
        Me.CMBGM.Size = New System.Drawing.Size(138, 22)
        Me.CMBGM.TabIndex = 2
        '
        'RBSUMMARY
        '
        Me.RBSUMMARY.AutoSize = True
        Me.RBSUMMARY.BackColor = System.Drawing.Color.Transparent
        Me.RBSUMMARY.Location = New System.Drawing.Point(148, 109)
        Me.RBSUMMARY.Name = "RBSUMMARY"
        Me.RBSUMMARY.Size = New System.Drawing.Size(74, 18)
        Me.RBSUMMARY.TabIndex = 4
        Me.RBSUMMARY.Text = "Summary"
        Me.RBSUMMARY.UseVisualStyleBackColor = False
        '
        'RBDETAILS
        '
        Me.RBDETAILS.AutoSize = True
        Me.RBDETAILS.BackColor = System.Drawing.Color.Transparent
        Me.RBDETAILS.Checked = True
        Me.RBDETAILS.Location = New System.Drawing.Point(62, 109)
        Me.RBDETAILS.Name = "RBDETAILS"
        Me.RBDETAILS.Size = New System.Drawing.Size(65, 18)
        Me.RBDETAILS.TabIndex = 3
        Me.RBDETAILS.TabStop = True
        Me.RBDETAILS.Text = "Details"
        Me.RBDETAILS.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(59, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(32, 14)
        Me.Label2.TabIndex = 382
        Me.Label2.Text = "Item"
        '
        'CMBITEMNAME
        '
        Me.CMBITEMNAME.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBITEMNAME.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBITEMNAME.BackColor = System.Drawing.Color.White
        Me.CMBITEMNAME.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBITEMNAME.Items.AddRange(New Object() {""})
        Me.CMBITEMNAME.Location = New System.Drawing.Point(93, 45)
        Me.CMBITEMNAME.Name = "CMBITEMNAME"
        Me.CMBITEMNAME.Size = New System.Drawing.Size(138, 22)
        Me.CMBITEMNAME.TabIndex = 1
        '
        'lblname
        '
        Me.lblname.AutoSize = True
        Me.lblname.BackColor = System.Drawing.Color.Transparent
        Me.lblname.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblname.ForeColor = System.Drawing.Color.Green
        Me.lblname.Location = New System.Drawing.Point(233, 25)
        Me.lblname.Name = "lblname"
        Me.lblname.Size = New System.Drawing.Size(0, 14)
        Me.lblname.TabIndex = 380
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(52, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 14)
        Me.Label1.TabIndex = 367
        Me.Label1.Text = "Name"
        '
        'cmbname
        '
        Me.cmbname.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbname.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbname.BackColor = System.Drawing.Color.White
        Me.cmbname.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbname.Items.AddRange(New Object() {""})
        Me.cmbname.Location = New System.Drawing.Point(93, 17)
        Me.cmbname.Name = "cmbname"
        Me.cmbname.Size = New System.Drawing.Size(138, 22)
        Me.cmbname.TabIndex = 0
        '
        'chkdate
        '
        Me.chkdate.AutoSize = True
        Me.chkdate.BackColor = System.Drawing.Color.Transparent
        Me.chkdate.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkdate.Location = New System.Drawing.Point(34, 172)
        Me.chkdate.Name = "chkdate"
        Me.chkdate.Size = New System.Drawing.Size(52, 18)
        Me.chkdate.TabIndex = 6
        Me.chkdate.Text = "Date"
        Me.chkdate.UseVisualStyleBackColor = False
        '
        'cmdShowReport
        '
        Me.cmdShowReport.BackColor = System.Drawing.Color.Transparent
        Me.cmdShowReport.FlatAppearance.BorderSize = 0
        Me.cmdShowReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdShowReport.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdShowReport.Image = Global.Magic_Gold.My.Resources.Resources.showreport
        Me.cmdShowReport.Location = New System.Drawing.Point(63, 238)
        Me.cmdShowReport.Name = "cmdShowReport"
        Me.cmdShowReport.Size = New System.Drawing.Size(74, 26)
        Me.cmdShowReport.TabIndex = 8
        Me.cmdShowReport.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.dtpto)
        Me.GroupBox1.Controls.Add(Me.dtpfrom)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.lbl)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(20, 172)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(244, 60)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        '
        'dtpto
        '
        Me.dtpto.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpto.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpto.Location = New System.Drawing.Point(146, 25)
        Me.dtpto.Name = "dtpto"
        Me.dtpto.Size = New System.Drawing.Size(83, 22)
        Me.dtpto.TabIndex = 1
        '
        'dtpfrom
        '
        Me.dtpfrom.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpfrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpfrom.Location = New System.Drawing.Point(41, 25)
        Me.dtpfrom.Name = "dtpfrom"
        Me.dtpfrom.Size = New System.Drawing.Size(83, 22)
        Me.dtpfrom.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(126, 30)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(19, 14)
        Me.Label4.TabIndex = 271
        Me.Label4.Text = "To"
        '
        'lbl
        '
        Me.lbl.BackColor = System.Drawing.Color.Transparent
        Me.lbl.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl.ForeColor = System.Drawing.Color.Black
        Me.lbl.Location = New System.Drawing.Point(-16, -32)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(61, 22)
        Me.lbl.TabIndex = 269
        Me.lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(7, 30)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(34, 14)
        Me.Label3.TabIndex = 270
        Me.Label3.Text = "From"
        '
        'cmdExit
        '
        Me.cmdExit.BackColor = System.Drawing.Color.Transparent
        Me.cmdExit.FlatAppearance.BorderSize = 0
        Me.cmdExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdExit.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdExit.Image = Global.Magic_Gold.My.Resources.Resources._Exit
        Me.cmdExit.Location = New System.Drawing.Point(138, 238)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(84, 26)
        Me.cmdExit.TabIndex = 9
        Me.cmdExit.UseVisualStyleBackColor = False
        '
        'KarigarFilter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(284, 289)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "KarigarFilter"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Karigar Filter"
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents chkdate As System.Windows.Forms.CheckBox
    Friend WithEvents cmdShowReport As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lbl As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents dtpto As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpfrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbname As System.Windows.Forms.ComboBox
    Friend WithEvents lblname As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CMBITEMNAME As System.Windows.Forms.ComboBox
    Friend WithEvents RBSUMMARY As System.Windows.Forms.RadioButton
    Friend WithEvents RBDETAILS As System.Windows.Forms.RadioButton
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents CMBGM As System.Windows.Forms.ComboBox
    Friend WithEvents RBLEDGER As System.Windows.Forms.RadioButton
End Class
