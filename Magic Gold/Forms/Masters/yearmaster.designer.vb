<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class yearmaster
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(yearmaster))
        Me.lbl = New System.Windows.Forms.Label
        Me.cmdback = New System.Windows.Forms.Button
        Me.cmdfinish = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.lblgroup = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.enddate = New System.Windows.Forms.DateTimePicker
        Me.startdate = New System.Windows.Forms.DateTimePicker
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbl
        '
        Me.lbl.BackColor = System.Drawing.Color.Transparent
        Me.lbl.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbl.Location = New System.Drawing.Point(4, 9)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(213, 20)
        Me.lbl.TabIndex = 176
        Me.lbl.Text = "Enter Accounting Year For Company"
        '
        'cmdback
        '
        Me.cmdback.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdback.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdback.Location = New System.Drawing.Point(63, 119)
        Me.cmdback.Name = "cmdback"
        Me.cmdback.Size = New System.Drawing.Size(71, 24)
        Me.cmdback.TabIndex = 3
        Me.cmdback.Text = "< &Back"
        Me.cmdback.UseVisualStyleBackColor = True
        '
        'cmdfinish
        '
        Me.cmdfinish.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdfinish.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdfinish.Location = New System.Drawing.Point(140, 119)
        Me.cmdfinish.Name = "cmdfinish"
        Me.cmdfinish.Size = New System.Drawing.Size(71, 24)
        Me.cmdfinish.TabIndex = 2
        Me.cmdfinish.Text = "&Finish >"
        Me.cmdfinish.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(42, 86)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 14)
        Me.Label4.TabIndex = 172
        Me.Label4.Text = "End Date"
        '
        'lblgroup
        '
        Me.lblgroup.AutoSize = True
        Me.lblgroup.BackColor = System.Drawing.Color.Transparent
        Me.lblgroup.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblgroup.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblgroup.Location = New System.Drawing.Point(37, 58)
        Me.lblgroup.Name = "lblgroup"
        Me.lblgroup.Size = New System.Drawing.Size(61, 14)
        Me.lblgroup.TabIndex = 171
        Me.lblgroup.Text = "Start Date"
        Me.lblgroup.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.enddate)
        Me.GroupBox1.Controls.Add(Me.startdate)
        Me.GroupBox1.Location = New System.Drawing.Point(7, 32)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(210, 120)
        Me.GroupBox1.TabIndex = 169
        Me.GroupBox1.TabStop = False
        '
        'enddate
        '
        Me.enddate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.enddate.Location = New System.Drawing.Point(93, 49)
        Me.enddate.Name = "enddate"
        Me.enddate.Size = New System.Drawing.Size(83, 22)
        Me.enddate.TabIndex = 1
        '
        'startdate
        '
        Me.startdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.startdate.Location = New System.Drawing.Point(93, 23)
        Me.startdate.Name = "startdate"
        Me.startdate.Size = New System.Drawing.Size(83, 22)
        Me.startdate.TabIndex = 0
        '
        'yearmaster
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(223, 163)
        Me.Controls.Add(Me.lbl)
        Me.Controls.Add(Me.cmdback)
        Me.Controls.Add(Me.cmdfinish)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lblgroup)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "yearmaster"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Account Year"
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbl As System.Windows.Forms.Label
    Friend WithEvents cmdback As System.Windows.Forms.Button
    Friend WithEvents cmdfinish As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblgroup As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents enddate As System.Windows.Forms.DateTimePicker
    Friend WithEvents startdate As System.Windows.Forms.DateTimePicker
End Class
