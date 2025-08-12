<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class settlementdate
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
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.dtppreviousdate = New System.Windows.Forms.DateTimePicker
        Me.dtpsettledate = New System.Windows.Forms.DateTimePicker
        Me.Label10 = New System.Windows.Forms.Label
        Me.cmbyesno = New System.Windows.Forms.ComboBox
        Me.txtbalamt = New System.Windows.Forms.TextBox
        Me.txtbalwt = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cmdexit = New System.Windows.Forms.Button
        Me.cmdok = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(57, 84)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(88, 14)
        Me.Label17.TabIndex = 354
        Me.Label17.Text = "Previous Date :"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(43, 27)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(102, 14)
        Me.Label16.TabIndex = 353
        Me.Label16.Text = "Settlement Date :"
        '
        'dtppreviousdate
        '
        Me.dtppreviousdate.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtppreviousdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtppreviousdate.Location = New System.Drawing.Point(147, 81)
        Me.dtppreviousdate.Name = "dtppreviousdate"
        Me.dtppreviousdate.Size = New System.Drawing.Size(83, 22)
        Me.dtppreviousdate.TabIndex = 352
        '
        'dtpsettledate
        '
        Me.dtpsettledate.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpsettledate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpsettledate.Location = New System.Drawing.Point(147, 24)
        Me.dtpsettledate.Name = "dtpsettledate"
        Me.dtpsettledate.Size = New System.Drawing.Size(83, 22)
        Me.dtpsettledate.TabIndex = 351
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(28, 56)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(115, 14)
        Me.Label10.TabIndex = 356
        Me.Label10.Text = "Delete Transaction :"
        '
        'cmbyesno
        '
        Me.cmbyesno.BackColor = System.Drawing.Color.White
        Me.cmbyesno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbyesno.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbyesno.Items.AddRange(New Object() {"NO", "YES"})
        Me.cmbyesno.Location = New System.Drawing.Point(147, 52)
        Me.cmbyesno.Name = "cmbyesno"
        Me.cmbyesno.Size = New System.Drawing.Size(83, 22)
        Me.cmbyesno.TabIndex = 357
        '
        'txtbalamt
        '
        Me.txtbalamt.BackColor = System.Drawing.Color.White
        Me.txtbalamt.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbalamt.Location = New System.Drawing.Point(89, -4)
        Me.txtbalamt.Name = "txtbalamt"
        Me.txtbalamt.ReadOnly = True
        Me.txtbalamt.Size = New System.Drawing.Size(73, 20)
        Me.txtbalamt.TabIndex = 359
        Me.txtbalamt.Text = "0.00"
        Me.txtbalamt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtbalamt.Visible = False
        '
        'txtbalwt
        '
        Me.txtbalwt.BackColor = System.Drawing.Color.White
        Me.txtbalwt.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbalwt.Location = New System.Drawing.Point(15, -4)
        Me.txtbalwt.Name = "txtbalwt"
        Me.txtbalwt.ReadOnly = True
        Me.txtbalwt.Size = New System.Drawing.Size(73, 20)
        Me.txtbalwt.TabIndex = 358
        Me.txtbalwt.Text = "0.000"
        Me.txtbalwt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtbalwt.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmbyesno)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.dtppreviousdate)
        Me.GroupBox1.Controls.Add(Me.dtpsettledate)
        Me.GroupBox1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(18, 13)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(244, 117)
        Me.GroupBox1.TabIndex = 360
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Settlement"
        '
        'cmdexit
        '
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdexit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdexit.Image = Global.Magic_Gold.My.Resources.Resources._Exit
        Me.cmdexit.Location = New System.Drawing.Point(141, 137)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(68, 26)
        Me.cmdexit.TabIndex = 377
        Me.cmdexit.UseVisualStyleBackColor = True
        '
        'cmdok
        '
        Me.cmdok.FlatAppearance.BorderSize = 0
        Me.cmdok.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdok.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdok.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdok.Image = Global.Magic_Gold.My.Resources.Resources.ok
        Me.cmdok.Location = New System.Drawing.Point(71, 135)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(68, 26)
        Me.cmdok.TabIndex = 376
        Me.cmdok.UseVisualStyleBackColor = True
        '
        'settlementdate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(280, 174)
        Me.Controls.Add(Me.cmdexit)
        Me.Controls.Add(Me.cmdok)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txtbalamt)
        Me.Controls.Add(Me.txtbalwt)
        Me.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "settlementdate"
        Me.Text = "Settlement Date"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents dtppreviousdate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpsettledate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cmbyesno As System.Windows.Forms.ComboBox
    Friend WithEvents txtbalamt As System.Windows.Forms.TextBox
    Friend WithEvents txtbalwt As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents cmdok As System.Windows.Forms.Button
End Class
