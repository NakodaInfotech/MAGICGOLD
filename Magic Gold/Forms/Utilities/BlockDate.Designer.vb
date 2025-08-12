<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BlockDate
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
        Me.Label16 = New System.Windows.Forms.Label
        Me.DTBLOCKDATE = New System.Windows.Forms.DateTimePicker
        Me.cmdexit = New System.Windows.Forms.Button
        Me.cmdok = New System.Windows.Forms.Button
        Me.BlendPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.cmdok)
        Me.BlendPanel1.Controls.Add(Me.Label16)
        Me.BlendPanel1.Controls.Add(Me.DTBLOCKDATE)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(284, 114)
        Me.BlendPanel1.TabIndex = 199
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(57, 35)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(86, 14)
        Me.Label16.TabIndex = 355
        Me.Label16.Text = "Block Date Till"
        '
        'DTBLOCKDATE
        '
        Me.DTBLOCKDATE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTBLOCKDATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTBLOCKDATE.Location = New System.Drawing.Point(145, 32)
        Me.DTBLOCKDATE.Name = "DTBLOCKDATE"
        Me.DTBLOCKDATE.Size = New System.Drawing.Size(83, 22)
        Me.DTBLOCKDATE.TabIndex = 354
        '
        'cmdexit
        '
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdexit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdexit.Image = Global.Magic_Gold.My.Resources.Resources._Exit
        Me.cmdexit.Location = New System.Drawing.Point(143, 67)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(68, 26)
        Me.cmdexit.TabIndex = 379
        Me.cmdexit.UseVisualStyleBackColor = True
        '
        'cmdok
        '
        Me.cmdok.FlatAppearance.BorderSize = 0
        Me.cmdok.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdok.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdok.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdok.Image = Global.Magic_Gold.My.Resources.Resources.ok
        Me.cmdok.Location = New System.Drawing.Point(73, 65)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(68, 26)
        Me.cmdok.TabIndex = 378
        Me.cmdok.UseVisualStyleBackColor = True
        '
        'BlockDate
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(284, 114)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "BlockDate"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Block Date"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents DTBLOCKDATE As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents cmdok As System.Windows.Forms.Button
End Class
