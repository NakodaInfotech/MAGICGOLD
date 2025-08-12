<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ChangeDate
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
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.cmdok = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.LBLPREVIOUS = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.dtppreviousdate = New System.Windows.Forms.DateTimePicker()
        Me.NEWDATE = New System.Windows.Forms.DateTimePicker()
        Me.BlendPanel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.cmdok)
        Me.BlendPanel1.Controls.Add(Me.GroupBox1)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(267, 137)
        Me.BlendPanel1.TabIndex = 0
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdexit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdexit.Image = Global.Magic_Gold.My.Resources.Resources._Exit
        Me.cmdexit.Location = New System.Drawing.Point(134, 104)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(68, 26)
        Me.cmdexit.TabIndex = 380
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'cmdok
        '
        Me.cmdok.BackColor = System.Drawing.Color.Transparent
        Me.cmdok.FlatAppearance.BorderSize = 0
        Me.cmdok.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdok.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdok.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdok.Image = Global.Magic_Gold.My.Resources.Resources.ok
        Me.cmdok.Location = New System.Drawing.Point(64, 102)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(68, 26)
        Me.cmdok.TabIndex = 379
        Me.cmdok.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.LBLPREVIOUS)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.dtppreviousdate)
        Me.GroupBox1.Controls.Add(Me.NEWDATE)
        Me.GroupBox1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(11, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(244, 86)
        Me.GroupBox1.TabIndex = 378
        Me.GroupBox1.TabStop = False
        '
        'LBLPREVIOUS
        '
        Me.LBLPREVIOUS.AutoSize = True
        Me.LBLPREVIOUS.BackColor = System.Drawing.Color.Transparent
        Me.LBLPREVIOUS.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLPREVIOUS.Location = New System.Drawing.Point(36, 59)
        Me.LBLPREVIOUS.Name = "LBLPREVIOUS"
        Me.LBLPREVIOUS.Size = New System.Drawing.Size(80, 14)
        Me.LBLPREVIOUS.TabIndex = 354
        Me.LBLPREVIOUS.Text = "Previous Date :"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(58, 27)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(62, 14)
        Me.Label16.TabIndex = 353
        Me.Label16.Text = "New Date :"
        '
        'dtppreviousdate
        '
        Me.dtppreviousdate.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtppreviousdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtppreviousdate.Location = New System.Drawing.Point(126, 56)
        Me.dtppreviousdate.Name = "dtppreviousdate"
        Me.dtppreviousdate.Size = New System.Drawing.Size(83, 22)
        Me.dtppreviousdate.TabIndex = 352
        '
        'NEWDATE
        '
        Me.NEWDATE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NEWDATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.NEWDATE.Location = New System.Drawing.Point(126, 24)
        Me.NEWDATE.Name = "NEWDATE"
        Me.NEWDATE.Size = New System.Drawing.Size(83, 22)
        Me.NEWDATE.TabIndex = 351
        '
        'ChangeDate
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(267, 137)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "ChangeDate"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Change Date"
        Me.BlendPanel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents cmdok As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents LBLPREVIOUS As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents dtppreviousdate As System.Windows.Forms.DateTimePicker
    Friend WithEvents NEWDATE As System.Windows.Forms.DateTimePicker
End Class
