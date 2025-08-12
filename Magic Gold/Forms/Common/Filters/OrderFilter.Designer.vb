<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OrderFilter
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
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmbitemcode = New System.Windows.Forms.ComboBox
        Me.CHKINDEX = New System.Windows.Forms.CheckBox
        Me.CHKNEWPAGE = New System.Windows.Forms.CheckBox
        Me.CMDOK = New System.Windows.Forms.Button
        Me.cmbname = New System.Windows.Forms.ComboBox
        Me.cmdcancel = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.RBCOMPLETE = New System.Windows.Forms.RadioButton
        Me.RBCLOSED = New System.Windows.Forms.RadioButton
        Me.RBISSUED = New System.Windows.Forms.RadioButton
        Me.RBPENDING = New System.Windows.Forms.RadioButton
        Me.RBALL = New System.Windows.Forms.RadioButton
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.dtpto = New System.Windows.Forms.DateTimePicker
        Me.Label4 = New System.Windows.Forms.Label
        Me.dtpfrom = New System.Windows.Forms.DateTimePicker
        Me.Label3 = New System.Windows.Forms.Label
        Me.chkdate = New System.Windows.Forms.CheckBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtpurity = New System.Windows.Forms.TextBox
        Me.Label23 = New System.Windows.Forms.Label
        Me.CMBCATEGORY = New System.Windows.Forms.ComboBox
        Me.BlendPanel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.CMBCATEGORY)
        Me.BlendPanel1.Controls.Add(Me.Label23)
        Me.BlendPanel1.Controls.Add(Me.Label5)
        Me.BlendPanel1.Controls.Add(Me.Label2)
        Me.BlendPanel1.Controls.Add(Me.cmbitemcode)
        Me.BlendPanel1.Controls.Add(Me.txtpurity)
        Me.BlendPanel1.Controls.Add(Me.CHKINDEX)
        Me.BlendPanel1.Controls.Add(Me.CHKNEWPAGE)
        Me.BlendPanel1.Controls.Add(Me.CMDOK)
        Me.BlendPanel1.Controls.Add(Me.cmbname)
        Me.BlendPanel1.Controls.Add(Me.cmdcancel)
        Me.BlendPanel1.Controls.Add(Me.Label1)
        Me.BlendPanel1.Controls.Add(Me.GroupBox2)
        Me.BlendPanel1.Controls.Add(Me.GroupBox1)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(334, 403)
        Me.BlendPanel1.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(29, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 14)
        Me.Label2.TabIndex = 367
        Me.Label2.Text = "Item Code"
        '
        'cmbitemcode
        '
        Me.cmbitemcode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbitemcode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbitemcode.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbitemcode.FormattingEnabled = True
        Me.cmbitemcode.Location = New System.Drawing.Point(93, 50)
        Me.cmbitemcode.Name = "cmbitemcode"
        Me.cmbitemcode.Size = New System.Drawing.Size(135, 22)
        Me.cmbitemcode.TabIndex = 1
        '
        'CHKINDEX
        '
        Me.CHKINDEX.AutoSize = True
        Me.CHKINDEX.BackColor = System.Drawing.Color.Transparent
        Me.CHKINDEX.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKINDEX.Location = New System.Drawing.Point(40, 266)
        Me.CHKINDEX.Name = "CHKINDEX"
        Me.CHKINDEX.Size = New System.Drawing.Size(88, 18)
        Me.CHKINDEX.TabIndex = 6
        Me.CHKINDEX.Text = "Show Index"
        Me.CHKINDEX.UseVisualStyleBackColor = False
        '
        'CHKNEWPAGE
        '
        Me.CHKNEWPAGE.AutoSize = True
        Me.CHKNEWPAGE.BackColor = System.Drawing.Color.Transparent
        Me.CHKNEWPAGE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKNEWPAGE.Location = New System.Drawing.Point(40, 242)
        Me.CHKNEWPAGE.Name = "CHKNEWPAGE"
        Me.CHKNEWPAGE.Size = New System.Drawing.Size(186, 18)
        Me.CHKNEWPAGE.TabIndex = 5
        Me.CHKNEWPAGE.Text = "Show Each Party On New Page"
        Me.CHKNEWPAGE.UseVisualStyleBackColor = False
        '
        'CMDOK
        '
        Me.CMDOK.BackColor = System.Drawing.Color.Transparent
        Me.CMDOK.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDOK.FlatAppearance.BorderSize = 0
        Me.CMDOK.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDOK.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CMDOK.Location = New System.Drawing.Point(76, 364)
        Me.CMDOK.Name = "CMDOK"
        Me.CMDOK.Size = New System.Drawing.Size(72, 26)
        Me.CMDOK.TabIndex = 8
        Me.CMDOK.Text = "&Ok"
        Me.CMDOK.UseVisualStyleBackColor = False
        '
        'cmbname
        '
        Me.cmbname.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbname.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbname.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbname.FormattingEnabled = True
        Me.cmbname.Location = New System.Drawing.Point(93, 22)
        Me.cmbname.Name = "cmbname"
        Me.cmbname.Size = New System.Drawing.Size(209, 22)
        Me.cmbname.TabIndex = 0
        '
        'cmdcancel
        '
        Me.cmdcancel.BackColor = System.Drawing.Color.Transparent
        Me.cmdcancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdcancel.FlatAppearance.BorderSize = 0
        Me.cmdcancel.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdcancel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdcancel.Location = New System.Drawing.Point(154, 364)
        Me.cmdcancel.Name = "cmdcancel"
        Me.cmdcancel.Size = New System.Drawing.Size(72, 26)
        Me.cmdcancel.TabIndex = 9
        Me.cmdcancel.Text = "E&xit"
        Me.cmdcancel.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(52, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 14)
        Me.Label1.TabIndex = 366
        Me.Label1.Text = "Name"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.RBCOMPLETE)
        Me.GroupBox2.Controls.Add(Me.RBCLOSED)
        Me.GroupBox2.Controls.Add(Me.RBISSUED)
        Me.GroupBox2.Controls.Add(Me.RBPENDING)
        Me.GroupBox2.Controls.Add(Me.RBALL)
        Me.GroupBox2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(20, 127)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(264, 99)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        '
        'RBCOMPLETE
        '
        Me.RBCOMPLETE.AutoSize = True
        Me.RBCOMPLETE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RBCOMPLETE.Location = New System.Drawing.Point(132, 19)
        Me.RBCOMPLETE.Name = "RBCOMPLETE"
        Me.RBCOMPLETE.Size = New System.Drawing.Size(123, 18)
        Me.RBCOMPLETE.TabIndex = 4
        Me.RBCOMPLETE.Text = "Completed Orders"
        Me.RBCOMPLETE.UseVisualStyleBackColor = True
        '
        'RBCLOSED
        '
        Me.RBCLOSED.AutoSize = True
        Me.RBCLOSED.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RBCLOSED.Location = New System.Drawing.Point(17, 67)
        Me.RBCLOSED.Name = "RBCLOSED"
        Me.RBCLOSED.Size = New System.Drawing.Size(101, 18)
        Me.RBCLOSED.TabIndex = 3
        Me.RBCLOSED.Text = "Closed Orders"
        Me.RBCLOSED.UseVisualStyleBackColor = True
        '
        'RBISSUED
        '
        Me.RBISSUED.AutoSize = True
        Me.RBISSUED.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RBISSUED.Location = New System.Drawing.Point(132, 43)
        Me.RBISSUED.Name = "RBISSUED"
        Me.RBISSUED.Size = New System.Drawing.Size(101, 18)
        Me.RBISSUED.TabIndex = 2
        Me.RBISSUED.Text = "Issued Orders"
        Me.RBISSUED.UseVisualStyleBackColor = True
        '
        'RBPENDING
        '
        Me.RBPENDING.AutoSize = True
        Me.RBPENDING.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RBPENDING.Location = New System.Drawing.Point(17, 43)
        Me.RBPENDING.Name = "RBPENDING"
        Me.RBPENDING.Size = New System.Drawing.Size(108, 18)
        Me.RBPENDING.TabIndex = 1
        Me.RBPENDING.Text = "Pending Orders"
        Me.RBPENDING.UseVisualStyleBackColor = True
        '
        'RBALL
        '
        Me.RBALL.AutoSize = True
        Me.RBALL.Checked = True
        Me.RBALL.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RBALL.Location = New System.Drawing.Point(17, 19)
        Me.RBALL.Name = "RBALL"
        Me.RBALL.Size = New System.Drawing.Size(79, 18)
        Me.RBALL.TabIndex = 0
        Me.RBALL.TabStop = True
        Me.RBALL.Text = "All Orders"
        Me.RBALL.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.dtpto)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.dtpfrom)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.chkdate)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(23, 299)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(264, 55)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        '
        'dtpto
        '
        Me.dtpto.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpto.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpto.Location = New System.Drawing.Point(166, 23)
        Me.dtpto.Name = "dtpto"
        Me.dtpto.Size = New System.Drawing.Size(82, 22)
        Me.dtpto.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(145, 27)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(19, 14)
        Me.Label4.TabIndex = 293
        Me.Label4.Text = "To"
        '
        'dtpfrom
        '
        Me.dtpfrom.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpfrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpfrom.Location = New System.Drawing.Point(38, 23)
        Me.dtpfrom.Name = "dtpfrom"
        Me.dtpfrom.Size = New System.Drawing.Size(82, 22)
        Me.dtpfrom.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(3, 27)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(34, 14)
        Me.Label3.TabIndex = 292
        Me.Label3.Text = "From"
        '
        'chkdate
        '
        Me.chkdate.AutoSize = True
        Me.chkdate.BackColor = System.Drawing.Color.Transparent
        Me.chkdate.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkdate.Location = New System.Drawing.Point(3, -1)
        Me.chkdate.Name = "chkdate"
        Me.chkdate.Size = New System.Drawing.Size(52, 18)
        Me.chkdate.TabIndex = 0
        Me.chkdate.Text = "Date"
        Me.chkdate.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(54, 108)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(37, 14)
        Me.Label5.TabIndex = 366
        Me.Label5.Text = "Purity"
        '
        'txtpurity
        '
        Me.txtpurity.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtpurity.Location = New System.Drawing.Point(93, 105)
        Me.txtpurity.Name = "txtpurity"
        Me.txtpurity.Size = New System.Drawing.Size(59, 22)
        Me.txtpurity.TabIndex = 3
        Me.txtpurity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(10, 80)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(81, 14)
        Me.Label23.TabIndex = 369
        Me.Label23.Text = "Item Category"
        '
        'CMBCATEGORY
        '
        Me.CMBCATEGORY.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBCATEGORY.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBCATEGORY.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBCATEGORY.FormattingEnabled = True
        Me.CMBCATEGORY.Location = New System.Drawing.Point(93, 77)
        Me.CMBCATEGORY.Name = "CMBCATEGORY"
        Me.CMBCATEGORY.Size = New System.Drawing.Size(135, 22)
        Me.CMBCATEGORY.TabIndex = 2
        '
        'OrderFilter
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(334, 403)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "OrderFilter"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "OrderFilter"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents RBPENDING As System.Windows.Forms.RadioButton
    Friend WithEvents RBALL As System.Windows.Forms.RadioButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents chkdate As System.Windows.Forms.CheckBox
    Friend WithEvents dtpfrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dtpto As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbname As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents RBISSUED As System.Windows.Forms.RadioButton
    Friend WithEvents CMDOK As System.Windows.Forms.Button
    Friend WithEvents cmdcancel As System.Windows.Forms.Button
    Friend WithEvents CHKINDEX As System.Windows.Forms.CheckBox
    Friend WithEvents CHKNEWPAGE As System.Windows.Forms.CheckBox
    Friend WithEvents RBCOMPLETE As System.Windows.Forms.RadioButton
    Friend WithEvents RBCLOSED As System.Windows.Forms.RadioButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbitemcode As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtpurity As System.Windows.Forms.TextBox
    Friend WithEvents CMBCATEGORY As System.Windows.Forms.ComboBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
End Class
