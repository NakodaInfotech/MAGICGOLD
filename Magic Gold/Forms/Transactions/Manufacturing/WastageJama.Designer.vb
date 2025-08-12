<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WastageJama
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
        Me.cmdexit = New System.Windows.Forms.Button
        Me.cmdok = New System.Windows.Forms.Button
        Me.txtnettwt = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtgrosswt = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.TXTPURITY = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmbcode = New System.Windows.Forms.ComboBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.DTJAMA = New System.Windows.Forms.DateTimePicker
        Me.txtbillno = New System.Windows.Forms.TextBox
        Me.BlendPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.cmdok)
        Me.BlendPanel1.Controls.Add(Me.txtnettwt)
        Me.BlendPanel1.Controls.Add(Me.Label4)
        Me.BlendPanel1.Controls.Add(Me.txtgrosswt)
        Me.BlendPanel1.Controls.Add(Me.Label3)
        Me.BlendPanel1.Controls.Add(Me.TXTPURITY)
        Me.BlendPanel1.Controls.Add(Me.Label2)
        Me.BlendPanel1.Controls.Add(Me.Label1)
        Me.BlendPanel1.Controls.Add(Me.cmbcode)
        Me.BlendPanel1.Controls.Add(Me.Label16)
        Me.BlendPanel1.Controls.Add(Me.DTJAMA)
        Me.BlendPanel1.Controls.Add(Me.txtbillno)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(231, 209)
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
        Me.cmdexit.Location = New System.Drawing.Point(116, 161)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(68, 24)
        Me.cmdexit.TabIndex = 6
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'cmdok
        '
        Me.cmdok.BackColor = System.Drawing.Color.Transparent
        Me.cmdok.FlatAppearance.BorderSize = 0
        Me.cmdok.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdok.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdok.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdok.Image = Global.Magic_Gold.My.Resources.Resources.Save
        Me.cmdok.Location = New System.Drawing.Point(46, 161)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(68, 24)
        Me.cmdok.TabIndex = 5
        Me.cmdok.UseVisualStyleBackColor = False
        '
        'txtnettwt
        '
        Me.txtnettwt.BackColor = System.Drawing.Color.White
        Me.txtnettwt.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtnettwt.ForeColor = System.Drawing.Color.Black
        Me.txtnettwt.Location = New System.Drawing.Point(88, 124)
        Me.txtnettwt.Name = "txtnettwt"
        Me.txtnettwt.ReadOnly = True
        Me.txtnettwt.Size = New System.Drawing.Size(93, 22)
        Me.txtnettwt.TabIndex = 4
        Me.txtnettwt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(35, 128)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 14)
        Me.Label4.TabIndex = 393
        Me.Label4.Text = "Nett Wt."
        '
        'txtgrosswt
        '
        Me.txtgrosswt.BackColor = System.Drawing.Color.White
        Me.txtgrosswt.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtgrosswt.ForeColor = System.Drawing.Color.Black
        Me.txtgrosswt.Location = New System.Drawing.Point(88, 96)
        Me.txtgrosswt.Name = "txtgrosswt"
        Me.txtgrosswt.Size = New System.Drawing.Size(93, 22)
        Me.txtgrosswt.TabIndex = 3
        Me.txtgrosswt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(27, 100)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 14)
        Me.Label3.TabIndex = 391
        Me.Label3.Text = "Gross Wt."
        '
        'TXTPURITY
        '
        Me.TXTPURITY.BackColor = System.Drawing.Color.White
        Me.TXTPURITY.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTPURITY.ForeColor = System.Drawing.Color.Black
        Me.TXTPURITY.Location = New System.Drawing.Point(88, 68)
        Me.TXTPURITY.Name = "TXTPURITY"
        Me.TXTPURITY.Size = New System.Drawing.Size(93, 22)
        Me.TXTPURITY.TabIndex = 2
        Me.TXTPURITY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(49, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 14)
        Me.Label2.TabIndex = 389
        Me.Label2.Text = "Purity"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.Label1.Location = New System.Drawing.Point(61, 43)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(25, 14)
        Me.Label1.TabIndex = 378
        Me.Label1.Text = "A/C"
        '
        'cmbcode
        '
        Me.cmbcode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbcode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbcode.BackColor = System.Drawing.Color.White
        Me.cmbcode.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbcode.Items.AddRange(New Object() {""})
        Me.cmbcode.Location = New System.Drawing.Point(88, 40)
        Me.cmbcode.Name = "cmbcode"
        Me.cmbcode.Size = New System.Drawing.Size(93, 22)
        Me.cmbcode.TabIndex = 1
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.Label16.Location = New System.Drawing.Point(53, 15)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(33, 14)
        Me.Label16.TabIndex = 376
        Me.Label16.Text = "Date"
        '
        'DTJAMA
        '
        Me.DTJAMA.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.DTJAMA.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTJAMA.Location = New System.Drawing.Point(88, 12)
        Me.DTJAMA.Name = "DTJAMA"
        Me.DTJAMA.Size = New System.Drawing.Size(93, 22)
        Me.DTJAMA.TabIndex = 0
        '
        'txtbillno
        '
        Me.txtbillno.BackColor = System.Drawing.Color.White
        Me.txtbillno.Location = New System.Drawing.Point(3, 3)
        Me.txtbillno.Name = "txtbillno"
        Me.txtbillno.ReadOnly = True
        Me.txtbillno.Size = New System.Drawing.Size(21, 22)
        Me.txtbillno.TabIndex = 374
        Me.txtbillno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtbillno.Visible = False
        '
        'WastageJama
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(231, 209)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "WastageJama"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Wastage Jama"
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents txtbillno As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents DTJAMA As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbcode As System.Windows.Forms.ComboBox
    Friend WithEvents TXTPURITY As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtnettwt As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtgrosswt As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents cmdok As System.Windows.Forms.Button
End Class
