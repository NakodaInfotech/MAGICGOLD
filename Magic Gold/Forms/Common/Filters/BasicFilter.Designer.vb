<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class basicfilter
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
        Me.cmb = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.lbl = New System.Windows.Forms.Label
        Me.chkdate = New System.Windows.Forms.CheckBox
        Me.dtpto = New System.Windows.Forms.DateTimePicker
        Me.dtpfrom = New System.Windows.Forms.DateTimePicker
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cmb1 = New System.Windows.Forms.ComboBox
        Me.lbl1 = New System.Windows.Forms.Label
        Me.lbllotno = New System.Windows.Forms.Label
        Me.txtlotno = New System.Windows.Forms.TextBox
        Me.cmdExit = New System.Windows.Forms.Button
        Me.cmdShowReport = New System.Windows.Forms.Button
        Me.BlendPanel1 = New VbPowerPack.BlendPanel
        Me.cmbprocess = New System.Windows.Forms.ComboBox
        Me.LBLPROCESS = New System.Windows.Forms.Label
        Me.CHKPROCESS = New System.Windows.Forms.CheckBox
        Me.CHKPART = New System.Windows.Forms.CheckBox
        Me.CHKFINE = New System.Windows.Forms.CheckBox
        Me.CHKISSUEPUR = New System.Windows.Forms.CheckBox
        Me.CHKSMPLWT = New System.Windows.Forms.CheckBox
        Me.CHKLOT = New System.Windows.Forms.CheckBox
        Me.CHKNETT = New System.Windows.Forms.CheckBox
        Me.chkgross = New System.Windows.Forms.CheckBox
        Me.CHKRECPUR = New System.Windows.Forms.CheckBox
        Me.chkitem = New System.Windows.Forms.CheckBox
        Me.chkoutwt = New System.Windows.Forms.CheckBox
        Me.chkinwt = New System.Windows.Forms.CheckBox
        Me.GroupBox1.SuspendLayout()
        Me.BlendPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmb
        '
        Me.cmb.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmb.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmb.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb.FormattingEnabled = True
        Me.cmb.Location = New System.Drawing.Point(74, 70)
        Me.cmb.Name = "cmb"
        Me.cmb.Size = New System.Drawing.Size(185, 22)
        Me.cmb.TabIndex = 273
        Me.cmb.Visible = False
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
        'chkdate
        '
        Me.chkdate.AutoSize = True
        Me.chkdate.BackColor = System.Drawing.Color.Transparent
        Me.chkdate.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkdate.Location = New System.Drawing.Point(69, 245)
        Me.chkdate.Name = "chkdate"
        Me.chkdate.Size = New System.Drawing.Size(52, 18)
        Me.chkdate.TabIndex = 266
        Me.chkdate.Text = "Date"
        Me.chkdate.UseVisualStyleBackColor = False
        '
        'dtpto
        '
        Me.dtpto.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpto.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpto.Location = New System.Drawing.Point(146, 24)
        Me.dtpto.Name = "dtpto"
        Me.dtpto.Size = New System.Drawing.Size(83, 22)
        Me.dtpto.TabIndex = 268
        '
        'dtpfrom
        '
        Me.dtpfrom.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpfrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpfrom.Location = New System.Drawing.Point(41, 24)
        Me.dtpfrom.Name = "dtpfrom"
        Me.dtpfrom.Size = New System.Drawing.Size(83, 22)
        Me.dtpfrom.TabIndex = 267
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.lbl)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.dtpto)
        Me.GroupBox1.Controls.Add(Me.dtpfrom)
        Me.GroupBox1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(58, 245)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(244, 60)
        Me.GroupBox1.TabIndex = 272
        Me.GroupBox1.TabStop = False
        '
        'cmb1
        '
        Me.cmb1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmb1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmb1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb1.FormattingEnabled = True
        Me.cmb1.Location = New System.Drawing.Point(74, 41)
        Me.cmb1.Name = "cmb1"
        Me.cmb1.Size = New System.Drawing.Size(185, 22)
        Me.cmb1.TabIndex = 277
        Me.cmb1.Visible = False
        '
        'lbl1
        '
        Me.lbl1.BackColor = System.Drawing.Color.Transparent
        Me.lbl1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl1.ForeColor = System.Drawing.Color.Black
        Me.lbl1.Location = New System.Drawing.Point(13, 43)
        Me.lbl1.Name = "lbl1"
        Me.lbl1.Size = New System.Drawing.Size(61, 18)
        Me.lbl1.TabIndex = 276
        Me.lbl1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbllotno
        '
        Me.lbllotno.AutoSize = True
        Me.lbllotno.BackColor = System.Drawing.Color.Transparent
        Me.lbllotno.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbllotno.Location = New System.Drawing.Point(35, 74)
        Me.lbllotno.Name = "lbllotno"
        Me.lbllotno.Size = New System.Drawing.Size(41, 14)
        Me.lbllotno.TabIndex = 343
        Me.lbllotno.Text = "Lot No"
        Me.lbllotno.Visible = False
        '
        'txtlotno
        '
        Me.txtlotno.BackColor = System.Drawing.Color.White
        Me.txtlotno.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtlotno.ForeColor = System.Drawing.Color.Black
        Me.txtlotno.Location = New System.Drawing.Point(74, 70)
        Me.txtlotno.Name = "txtlotno"
        Me.txtlotno.Size = New System.Drawing.Size(39, 22)
        Me.txtlotno.TabIndex = 342
        Me.txtlotno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtlotno.Visible = False
        '
        'cmdExit
        '
        Me.cmdExit.BackColor = System.Drawing.Color.Transparent
        Me.cmdExit.FlatAppearance.BorderSize = 0
        Me.cmdExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdExit.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdExit.Image = Global.Magic_Gold.My.Resources.Resources._Exit
        Me.cmdExit.Location = New System.Drawing.Point(174, 317)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(84, 26)
        Me.cmdExit.TabIndex = 275
        Me.cmdExit.UseVisualStyleBackColor = False
        '
        'cmdShowReport
        '
        Me.cmdShowReport.BackColor = System.Drawing.Color.Transparent
        Me.cmdShowReport.FlatAppearance.BorderSize = 0
        Me.cmdShowReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdShowReport.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdShowReport.Image = Global.Magic_Gold.My.Resources.Resources.showreport
        Me.cmdShowReport.Location = New System.Drawing.Point(99, 317)
        Me.cmdShowReport.Name = "cmdShowReport"
        Me.cmdShowReport.Size = New System.Drawing.Size(74, 26)
        Me.cmdShowReport.TabIndex = 274
        Me.cmdShowReport.UseVisualStyleBackColor = False
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.cmbprocess)
        Me.BlendPanel1.Controls.Add(Me.LBLPROCESS)
        Me.BlendPanel1.Controls.Add(Me.CHKPROCESS)
        Me.BlendPanel1.Controls.Add(Me.CHKPART)
        Me.BlendPanel1.Controls.Add(Me.CHKFINE)
        Me.BlendPanel1.Controls.Add(Me.CHKISSUEPUR)
        Me.BlendPanel1.Controls.Add(Me.CHKSMPLWT)
        Me.BlendPanel1.Controls.Add(Me.CHKLOT)
        Me.BlendPanel1.Controls.Add(Me.CHKNETT)
        Me.BlendPanel1.Controls.Add(Me.chkgross)
        Me.BlendPanel1.Controls.Add(Me.CHKRECPUR)
        Me.BlendPanel1.Controls.Add(Me.chkitem)
        Me.BlendPanel1.Controls.Add(Me.chkoutwt)
        Me.BlendPanel1.Controls.Add(Me.chkinwt)
        Me.BlendPanel1.Controls.Add(Me.chkdate)
        Me.BlendPanel1.Controls.Add(Me.lbllotno)
        Me.BlendPanel1.Controls.Add(Me.cmdShowReport)
        Me.BlendPanel1.Controls.Add(Me.GroupBox1)
        Me.BlendPanel1.Controls.Add(Me.lbl1)
        Me.BlendPanel1.Controls.Add(Me.cmdExit)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(370, 365)
        Me.BlendPanel1.TabIndex = 344
        '
        'cmbprocess
        '
        Me.cmbprocess.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbprocess.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbprocess.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbprocess.FormattingEnabled = True
        Me.cmbprocess.Location = New System.Drawing.Point(99, 218)
        Me.cmbprocess.Name = "cmbprocess"
        Me.cmbprocess.Size = New System.Drawing.Size(185, 22)
        Me.cmbprocess.TabIndex = 356
        Me.cmbprocess.Visible = False
        '
        'LBLPROCESS
        '
        Me.LBLPROCESS.AutoSize = True
        Me.LBLPROCESS.BackColor = System.Drawing.Color.Transparent
        Me.LBLPROCESS.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLPROCESS.ForeColor = System.Drawing.Color.Black
        Me.LBLPROCESS.Location = New System.Drawing.Point(49, 222)
        Me.LBLPROCESS.Name = "LBLPROCESS"
        Me.LBLPROCESS.Size = New System.Drawing.Size(48, 14)
        Me.LBLPROCESS.TabIndex = 357
        Me.LBLPROCESS.Text = "Process"
        Me.LBLPROCESS.Visible = False
        '
        'CHKPROCESS
        '
        Me.CHKPROCESS.AutoSize = True
        Me.CHKPROCESS.BackColor = System.Drawing.Color.Transparent
        Me.CHKPROCESS.Checked = True
        Me.CHKPROCESS.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CHKPROCESS.Location = New System.Drawing.Point(199, 218)
        Me.CHKPROCESS.Name = "CHKPROCESS"
        Me.CHKPROCESS.Size = New System.Drawing.Size(103, 19)
        Me.CHKPROCESS.TabIndex = 355
        Me.CHKPROCESS.Text = "Process Name"
        Me.CHKPROCESS.UseVisualStyleBackColor = False
        Me.CHKPROCESS.Visible = False
        '
        'CHKPART
        '
        Me.CHKPART.AutoSize = True
        Me.CHKPART.BackColor = System.Drawing.Color.Transparent
        Me.CHKPART.Checked = True
        Me.CHKPART.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CHKPART.Location = New System.Drawing.Point(74, 218)
        Me.CHKPART.Name = "CHKPART"
        Me.CHKPART.Size = New System.Drawing.Size(67, 19)
        Me.CHKPART.TabIndex = 354
        Me.CHKPART.Text = "Part No"
        Me.CHKPART.UseVisualStyleBackColor = False
        Me.CHKPART.Visible = False
        '
        'CHKFINE
        '
        Me.CHKFINE.AutoSize = True
        Me.CHKFINE.BackColor = System.Drawing.Color.Transparent
        Me.CHKFINE.Checked = True
        Me.CHKFINE.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CHKFINE.Location = New System.Drawing.Point(199, 194)
        Me.CHKFINE.Name = "CHKFINE"
        Me.CHKFINE.Size = New System.Drawing.Size(49, 19)
        Me.CHKFINE.TabIndex = 353
        Me.CHKFINE.Text = "Fine"
        Me.CHKFINE.UseVisualStyleBackColor = False
        Me.CHKFINE.Visible = False
        '
        'CHKISSUEPUR
        '
        Me.CHKISSUEPUR.AutoSize = True
        Me.CHKISSUEPUR.BackColor = System.Drawing.Color.Transparent
        Me.CHKISSUEPUR.Checked = True
        Me.CHKISSUEPUR.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CHKISSUEPUR.Location = New System.Drawing.Point(201, 170)
        Me.CHKISSUEPUR.Name = "CHKISSUEPUR"
        Me.CHKISSUEPUR.Size = New System.Drawing.Size(77, 19)
        Me.CHKISSUEPUR.TabIndex = 352
        Me.CHKISSUEPUR.Text = "Issue Pur"
        Me.CHKISSUEPUR.UseVisualStyleBackColor = False
        Me.CHKISSUEPUR.Visible = False
        '
        'CHKSMPLWT
        '
        Me.CHKSMPLWT.AutoSize = True
        Me.CHKSMPLWT.BackColor = System.Drawing.Color.Transparent
        Me.CHKSMPLWT.Checked = True
        Me.CHKSMPLWT.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CHKSMPLWT.Location = New System.Drawing.Point(201, 146)
        Me.CHKSMPLWT.Name = "CHKSMPLWT"
        Me.CHKSMPLWT.Size = New System.Drawing.Size(75, 19)
        Me.CHKSMPLWT.TabIndex = 351
        Me.CHKSMPLWT.Text = "Smpl Wt."
        Me.CHKSMPLWT.UseVisualStyleBackColor = False
        Me.CHKSMPLWT.Visible = False
        '
        'CHKLOT
        '
        Me.CHKLOT.AutoSize = True
        Me.CHKLOT.BackColor = System.Drawing.Color.Transparent
        Me.CHKLOT.Checked = True
        Me.CHKLOT.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CHKLOT.Location = New System.Drawing.Point(74, 194)
        Me.CHKLOT.Name = "CHKLOT"
        Me.CHKLOT.Size = New System.Drawing.Size(60, 19)
        Me.CHKLOT.TabIndex = 350
        Me.CHKLOT.Text = "Lot No"
        Me.CHKLOT.UseVisualStyleBackColor = False
        Me.CHKLOT.Visible = False
        '
        'CHKNETT
        '
        Me.CHKNETT.AutoSize = True
        Me.CHKNETT.BackColor = System.Drawing.Color.Transparent
        Me.CHKNETT.Checked = True
        Me.CHKNETT.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CHKNETT.Location = New System.Drawing.Point(74, 170)
        Me.CHKNETT.Name = "CHKNETT"
        Me.CHKNETT.Size = New System.Drawing.Size(48, 19)
        Me.CHKNETT.TabIndex = 349
        Me.CHKNETT.Text = "Nett"
        Me.CHKNETT.UseVisualStyleBackColor = False
        Me.CHKNETT.Visible = False
        '
        'chkgross
        '
        Me.chkgross.AutoSize = True
        Me.chkgross.BackColor = System.Drawing.Color.Transparent
        Me.chkgross.Checked = True
        Me.chkgross.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkgross.Location = New System.Drawing.Point(74, 146)
        Me.chkgross.Name = "chkgross"
        Me.chkgross.Size = New System.Drawing.Size(58, 19)
        Me.chkgross.TabIndex = 348
        Me.chkgross.Text = "Gross"
        Me.chkgross.UseVisualStyleBackColor = False
        Me.chkgross.Visible = False
        '
        'CHKRECPUR
        '
        Me.CHKRECPUR.AutoSize = True
        Me.CHKRECPUR.BackColor = System.Drawing.Color.Transparent
        Me.CHKRECPUR.Checked = True
        Me.CHKRECPUR.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CHKRECPUR.Location = New System.Drawing.Point(74, 122)
        Me.CHKRECPUR.Name = "CHKRECPUR"
        Me.CHKRECPUR.Size = New System.Drawing.Size(70, 19)
        Me.CHKRECPUR.TabIndex = 347
        Me.CHKRECPUR.Text = "Rec. Pur"
        Me.CHKRECPUR.UseVisualStyleBackColor = False
        Me.CHKRECPUR.Visible = False
        '
        'chkitem
        '
        Me.chkitem.AutoSize = True
        Me.chkitem.BackColor = System.Drawing.Color.Transparent
        Me.chkitem.Checked = True
        Me.chkitem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkitem.Location = New System.Drawing.Point(74, 98)
        Me.chkitem.Name = "chkitem"
        Me.chkitem.Size = New System.Drawing.Size(50, 19)
        Me.chkitem.TabIndex = 346
        Me.chkitem.Text = "Item"
        Me.chkitem.UseVisualStyleBackColor = False
        Me.chkitem.Visible = False
        '
        'chkoutwt
        '
        Me.chkoutwt.AutoSize = True
        Me.chkoutwt.BackColor = System.Drawing.Color.Transparent
        Me.chkoutwt.Checked = True
        Me.chkoutwt.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkoutwt.Location = New System.Drawing.Point(201, 122)
        Me.chkoutwt.Name = "chkoutwt"
        Me.chkoutwt.Size = New System.Drawing.Size(68, 19)
        Me.chkoutwt.TabIndex = 345
        Me.chkoutwt.Text = "Out Wt."
        Me.chkoutwt.UseVisualStyleBackColor = False
        Me.chkoutwt.Visible = False
        '
        'chkinwt
        '
        Me.chkinwt.AutoSize = True
        Me.chkinwt.BackColor = System.Drawing.Color.Transparent
        Me.chkinwt.Checked = True
        Me.chkinwt.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkinwt.Location = New System.Drawing.Point(201, 98)
        Me.chkinwt.Name = "chkinwt"
        Me.chkinwt.Size = New System.Drawing.Size(59, 19)
        Me.chkinwt.TabIndex = 344
        Me.chkinwt.Text = "In Wt."
        Me.chkinwt.UseVisualStyleBackColor = False
        Me.chkinwt.Visible = False
        '
        'basicfilter
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(370, 365)
        Me.Controls.Add(Me.txtlotno)
        Me.Controls.Add(Me.cmb1)
        Me.Controls.Add(Me.cmb)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "basicfilter"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Filter"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmb As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lbl As System.Windows.Forms.Label
    Friend WithEvents chkdate As System.Windows.Forms.CheckBox
    Friend WithEvents dtpto As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpfrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents cmdShowReport As System.Windows.Forms.Button
    Friend WithEvents cmb1 As System.Windows.Forms.ComboBox
    Friend WithEvents lbl1 As System.Windows.Forms.Label
    Friend WithEvents lbllotno As System.Windows.Forms.Label
    Friend WithEvents txtlotno As System.Windows.Forms.TextBox
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents chkoutwt As System.Windows.Forms.CheckBox
    Friend WithEvents chkinwt As System.Windows.Forms.CheckBox
    Friend WithEvents CHKRECPUR As System.Windows.Forms.CheckBox
    Friend WithEvents chkitem As System.Windows.Forms.CheckBox
    Friend WithEvents CHKNETT As System.Windows.Forms.CheckBox
    Friend WithEvents chkgross As System.Windows.Forms.CheckBox
    Friend WithEvents CHKISSUEPUR As System.Windows.Forms.CheckBox
    Friend WithEvents CHKSMPLWT As System.Windows.Forms.CheckBox
    Friend WithEvents CHKLOT As System.Windows.Forms.CheckBox
    Friend WithEvents CHKPROCESS As System.Windows.Forms.CheckBox
    Friend WithEvents CHKPART As System.Windows.Forms.CheckBox
    Friend WithEvents CHKFINE As System.Windows.Forms.CheckBox
    Friend WithEvents cmbprocess As System.Windows.Forms.ComboBox
    Friend WithEvents LBLPROCESS As System.Windows.Forms.Label
End Class
