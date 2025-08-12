<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LabFilter
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
        Me.CMBPART = New System.Windows.Forms.ComboBox
        Me.TXTLOTNO = New System.Windows.Forms.TextBox
        Me.RBDETAILS = New System.Windows.Forms.RadioButton
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.chkdate = New System.Windows.Forms.CheckBox
        Me.cmdShowReport = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.dtpto = New System.Windows.Forms.DateTimePicker
        Me.dtpfrom = New System.Windows.Forms.DateTimePicker
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmdExit = New System.Windows.Forms.Button
        Me.BlendPanel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.CMBPART)
        Me.BlendPanel1.Controls.Add(Me.TXTLOTNO)
        Me.BlendPanel1.Controls.Add(Me.RBDETAILS)
        Me.BlendPanel1.Controls.Add(Me.Label2)
        Me.BlendPanel1.Controls.Add(Me.Label1)
        Me.BlendPanel1.Controls.Add(Me.chkdate)
        Me.BlendPanel1.Controls.Add(Me.cmdShowReport)
        Me.BlendPanel1.Controls.Add(Me.GroupBox1)
        Me.BlendPanel1.Controls.Add(Me.cmdExit)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(289, 221)
        Me.BlendPanel1.TabIndex = 0
        '
        'CMBPART
        '
        Me.CMBPART.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBPART.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBPART.BackColor = System.Drawing.Color.White
        Me.CMBPART.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMBPART.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBPART.Items.AddRange(New Object() {""})
        Me.CMBPART.Location = New System.Drawing.Point(98, 46)
        Me.CMBPART.Name = "CMBPART"
        Me.CMBPART.Size = New System.Drawing.Size(87, 22)
        Me.CMBPART.TabIndex = 1
        '
        'TXTLOTNO
        '
        Me.TXTLOTNO.BackColor = System.Drawing.Color.White
        Me.TXTLOTNO.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTLOTNO.ForeColor = System.Drawing.Color.Black
        Me.TXTLOTNO.Location = New System.Drawing.Point(98, 18)
        Me.TXTLOTNO.Name = "TXTLOTNO"
        Me.TXTLOTNO.Size = New System.Drawing.Size(87, 22)
        Me.TXTLOTNO.TabIndex = 0
        Me.TXTLOTNO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'RBDETAILS
        '
        Me.RBDETAILS.AutoSize = True
        Me.RBDETAILS.BackColor = System.Drawing.Color.Transparent
        Me.RBDETAILS.Checked = True
        Me.RBDETAILS.Location = New System.Drawing.Point(98, 74)
        Me.RBDETAILS.Name = "RBDETAILS"
        Me.RBDETAILS.Size = New System.Drawing.Size(64, 19)
        Me.RBDETAILS.TabIndex = 2
        Me.RBDETAILS.TabStop = True
        Me.RBDETAILS.Text = "Details"
        Me.RBDETAILS.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(50, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 14)
        Me.Label2.TabIndex = 382
        Me.Label2.Text = "Part No"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(55, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 14)
        Me.Label1.TabIndex = 367
        Me.Label1.Text = "Lot No"
        '
        'chkdate
        '
        Me.chkdate.AutoSize = True
        Me.chkdate.BackColor = System.Drawing.Color.Transparent
        Me.chkdate.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkdate.Location = New System.Drawing.Point(36, 103)
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
        Me.cmdShowReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdShowReport.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdShowReport.Image = Global.Magic_Gold.My.Resources.Resources.showreport
        Me.cmdShowReport.Location = New System.Drawing.Point(65, 174)
        Me.cmdShowReport.Name = "cmdShowReport"
        Me.cmdShowReport.Size = New System.Drawing.Size(74, 26)
        Me.cmdShowReport.TabIndex = 5
        Me.cmdShowReport.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.dtpto)
        Me.GroupBox1.Controls.Add(Me.dtpfrom)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(22, 103)
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
        Me.cmdExit.Location = New System.Drawing.Point(140, 174)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(84, 26)
        Me.cmdExit.TabIndex = 6
        Me.cmdExit.UseVisualStyleBackColor = False
        '
        'LabFilter
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(289, 221)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "LabFilter"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Lab Filter"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents RBDETAILS As System.Windows.Forms.RadioButton
    Friend WithEvents chkdate As System.Windows.Forms.CheckBox
    Friend WithEvents cmdShowReport As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dtpto As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpfrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TXTLOTNO As System.Windows.Forms.TextBox
    Friend WithEvents CMBPART As System.Windows.Forms.ComboBox
End Class
