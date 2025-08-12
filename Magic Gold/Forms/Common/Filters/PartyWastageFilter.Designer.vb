<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PartyWastageFilter
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
        Me.BlendPanel1 = New VbPowerPack.BlendPanel
        Me.RBSUMMARY = New System.Windows.Forms.RadioButton
        Me.RBDETAILS = New System.Windows.Forms.RadioButton
        Me.lblname = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.CMBNAME = New System.Windows.Forms.ComboBox
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
        Me.BlendPanel1.Controls.Add(Me.RBSUMMARY)
        Me.BlendPanel1.Controls.Add(Me.RBDETAILS)
        Me.BlendPanel1.Controls.Add(Me.lblname)
        Me.BlendPanel1.Controls.Add(Me.Label1)
        Me.BlendPanel1.Controls.Add(Me.CMBNAME)
        Me.BlendPanel1.Controls.Add(Me.chkdate)
        Me.BlendPanel1.Controls.Add(Me.cmdShowReport)
        Me.BlendPanel1.Controls.Add(Me.GroupBox1)
        Me.BlendPanel1.Controls.Add(Me.cmdExit)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(284, 278)
        Me.BlendPanel1.TabIndex = 0
        '
        'RBSUMMARY
        '
        Me.RBSUMMARY.AutoSize = True
        Me.RBSUMMARY.BackColor = System.Drawing.Color.Transparent
        Me.RBSUMMARY.Location = New System.Drawing.Point(138, 62)
        Me.RBSUMMARY.Name = "RBSUMMARY"
        Me.RBSUMMARY.Size = New System.Drawing.Size(76, 19)
        Me.RBSUMMARY.TabIndex = 2
        Me.RBSUMMARY.Text = "Summary"
        Me.RBSUMMARY.UseVisualStyleBackColor = False
        '
        'RBDETAILS
        '
        Me.RBDETAILS.AutoSize = True
        Me.RBDETAILS.BackColor = System.Drawing.Color.Transparent
        Me.RBDETAILS.Checked = True
        Me.RBDETAILS.Location = New System.Drawing.Point(68, 62)
        Me.RBDETAILS.Name = "RBDETAILS"
        Me.RBDETAILS.Size = New System.Drawing.Size(64, 19)
        Me.RBDETAILS.TabIndex = 1
        Me.RBDETAILS.TabStop = True
        Me.RBDETAILS.Text = "Details"
        Me.RBDETAILS.UseVisualStyleBackColor = False
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
        Me.Label1.Location = New System.Drawing.Point(22, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 14)
        Me.Label1.TabIndex = 367
        Me.Label1.Text = "Name"
        '
        'CMBNAME
        '
        Me.CMBNAME.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBNAME.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBNAME.BackColor = System.Drawing.Color.White
        Me.CMBNAME.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBNAME.Items.AddRange(New Object() {""})
        Me.CMBNAME.Location = New System.Drawing.Point(63, 25)
        Me.CMBNAME.Name = "CMBNAME"
        Me.CMBNAME.Size = New System.Drawing.Size(201, 22)
        Me.CMBNAME.TabIndex = 0
        '
        'chkdate
        '
        Me.chkdate.AutoSize = True
        Me.chkdate.BackColor = System.Drawing.Color.Transparent
        Me.chkdate.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkdate.Location = New System.Drawing.Point(31, 106)
        Me.chkdate.Name = "chkdate"
        Me.chkdate.Size = New System.Drawing.Size(52, 18)
        Me.chkdate.TabIndex = 3
        Me.chkdate.Text = "Date"
        Me.chkdate.UseVisualStyleBackColor = False
        '
        'cmdShowReport
        '
        Me.cmdShowReport.BackColor = System.Drawing.Color.Transparent
        Me.cmdShowReport.FlatAppearance.BorderSize = 0
        Me.cmdShowReport.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdShowReport.Location = New System.Drawing.Point(60, 187)
        Me.cmdShowReport.Name = "cmdShowReport"
        Me.cmdShowReport.Size = New System.Drawing.Size(80, 28)
        Me.cmdShowReport.TabIndex = 5
        Me.cmdShowReport.Text = "&Show Rep"
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
        Me.GroupBox1.Location = New System.Drawing.Point(17, 106)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(244, 60)
        Me.GroupBox1.TabIndex = 4
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
        Me.cmdExit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdExit.Location = New System.Drawing.Point(146, 187)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(80, 28)
        Me.cmdExit.TabIndex = 6
        Me.cmdExit.Text = "E&xit"
        Me.cmdExit.UseVisualStyleBackColor = False
        '
        'PartyWastageFilter
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(284, 278)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "PartyWastageFilter"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Party Wastage Filter"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents RBSUMMARY As System.Windows.Forms.RadioButton
    Friend WithEvents RBDETAILS As System.Windows.Forms.RadioButton
    Friend WithEvents lblname As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CMBNAME As System.Windows.Forms.ComboBox
    Friend WithEvents chkdate As System.Windows.Forms.CheckBox
    Friend WithEvents cmdShowReport As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dtpto As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpfrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lbl As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmdExit As System.Windows.Forms.Button
End Class
