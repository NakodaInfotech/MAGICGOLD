<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class processmaster
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.groupprocess = New System.Windows.Forms.GroupBox()
        Me.gridmelting = New System.Windows.Forms.DataGridView()
        Me.srno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.meltingnettwt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmbacc = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.closs = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.cVaccum = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.cKarigar = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.cexcess = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.GMAX = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmdclear = New System.Windows.Forms.Button()
        Me.cmdok = New System.Windows.Forms.Button()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.lbl = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.chkchange = New System.Windows.Forms.CheckBox()
        Me.cmddelete = New System.Windows.Forms.Button()
        Me.cmdedit = New System.Windows.Forms.Button()
        Me.GRoupstocks = New System.Windows.Forms.GroupBox()
        Me.rbrandom = New System.Windows.Forms.RadioButton()
        Me.rbsequence = New System.Windows.Forms.RadioButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lbllock = New System.Windows.Forms.Label()
        Me.groupprocess.SuspendLayout()
        CType(Me.gridmelting, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GRoupstocks.SuspendLayout()
        Me.SuspendLayout()
        '
        'groupprocess
        '
        Me.groupprocess.BackColor = System.Drawing.Color.Transparent
        Me.groupprocess.Controls.Add(Me.gridmelting)
        Me.groupprocess.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.groupprocess.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.groupprocess.Location = New System.Drawing.Point(14, 109)
        Me.groupprocess.Name = "groupprocess"
        Me.groupprocess.Size = New System.Drawing.Size(797, 337)
        Me.groupprocess.TabIndex = 322
        Me.groupprocess.TabStop = False
        '
        'gridmelting
        '
        Me.gridmelting.AllowUserToResizeColumns = False
        Me.gridmelting.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer))
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Black
        Me.gridmelting.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.gridmelting.BackgroundColor = System.Drawing.Color.White
        Me.gridmelting.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.gridmelting.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gridmelting.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.gridmelting.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridmelting.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.srno, Me.meltingnettwt, Me.cmbacc, Me.closs, Me.cVaccum, Me.cKarigar, Me.cexcess, Me.GMAX})
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gridmelting.DefaultCellStyle = DataGridViewCellStyle6
        Me.gridmelting.GridColor = System.Drawing.SystemColors.ControlText
        Me.gridmelting.Location = New System.Drawing.Point(7, 13)
        Me.gridmelting.Margin = New System.Windows.Forms.Padding(2)
        Me.gridmelting.MultiSelect = False
        Me.gridmelting.Name = "gridmelting"
        Me.gridmelting.RowHeadersVisible = False
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.Black
        Me.gridmelting.RowsDefaultCellStyle = DataGridViewCellStyle7
        Me.gridmelting.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.gridmelting.Size = New System.Drawing.Size(785, 318)
        Me.gridmelting.TabIndex = 4
        '
        'srno
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.Format = "N0"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.srno.DefaultCellStyle = DataGridViewCellStyle3
        Me.srno.HeaderText = "Sr. No."
        Me.srno.Name = "srno"
        Me.srno.ReadOnly = True
        Me.srno.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.srno.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.srno.Width = 70
        '
        'meltingnettwt
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.Format = "N3"
        Me.meltingnettwt.DefaultCellStyle = DataGridViewCellStyle4
        Me.meltingnettwt.HeaderText = "Process Name"
        Me.meltingnettwt.Name = "meltingnettwt"
        Me.meltingnettwt.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.meltingnettwt.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.meltingnettwt.Width = 160
        '
        'cmbacc
        '
        Me.cmbacc.AutoComplete = False
        Me.cmbacc.HeaderText = "Link With (A/C Name)"
        Me.cmbacc.MaxDropDownItems = 20
        Me.cmbacc.Name = "cmbacc"
        Me.cmbacc.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.cmbacc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.cmbacc.Width = 160
        '
        'closs
        '
        Me.closs.HeaderText = "Loss"
        Me.closs.Name = "closs"
        Me.closs.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.closs.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.closs.Width = 70
        '
        'cVaccum
        '
        Me.cVaccum.HeaderText = "Vaccum"
        Me.cVaccum.Name = "cVaccum"
        Me.cVaccum.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.cVaccum.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.cVaccum.Width = 70
        '
        'cKarigar
        '
        Me.cKarigar.HeaderText = "Karigar"
        Me.cKarigar.Name = "cKarigar"
        Me.cKarigar.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.cKarigar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.cKarigar.Width = 70
        '
        'cexcess
        '
        Me.cexcess.HeaderText = "Excess"
        Me.cexcess.Name = "cexcess"
        Me.cexcess.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.cexcess.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.cexcess.Width = 70
        '
        'GMAX
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.GMAX.DefaultCellStyle = DataGridViewCellStyle5
        Me.GMAX.HeaderText = "Max Loss %"
        Me.GMAX.Name = "GMAX"
        Me.GMAX.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GMAX.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GMAX.Width = 80
        '
        'cmdclear
        '
        Me.cmdclear.BackColor = System.Drawing.Color.Transparent
        Me.cmdclear.FlatAppearance.BorderSize = 0
        Me.cmdclear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdclear.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdclear.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdclear.Image = Global.Magic_Gold.My.Resources.Resources.clear
        Me.cmdclear.Location = New System.Drawing.Point(376, 494)
        Me.cmdclear.Name = "cmdclear"
        Me.cmdclear.Size = New System.Drawing.Size(71, 26)
        Me.cmdclear.TabIndex = 324
        Me.cmdclear.UseVisualStyleBackColor = False
        '
        'cmdok
        '
        Me.cmdok.BackColor = System.Drawing.Color.Transparent
        Me.cmdok.FlatAppearance.BorderSize = 0
        Me.cmdok.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdok.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdok.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdok.Image = Global.Magic_Gold.My.Resources.Resources.Save
        Me.cmdok.Location = New System.Drawing.Point(299, 494)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(71, 26)
        Me.cmdok.TabIndex = 323
        Me.cmdok.UseVisualStyleBackColor = False
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdexit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdexit.Image = Global.Magic_Gold.My.Resources.Resources._Exit
        Me.cmdexit.Location = New System.Drawing.Point(453, 494)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(72, 26)
        Me.cmdexit.TabIndex = 325
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'lbl
        '
        Me.lbl.AutoSize = True
        Me.lbl.BackColor = System.Drawing.Color.Transparent
        Me.lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbl.Location = New System.Drawing.Point(17, 9)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(90, 25)
        Me.lbl.TabIndex = 326
        Me.lbl.Text = "Process"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(19, 94)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(159, 14)
        Me.Label1.TabIndex = 327
        Me.Label1.Text = "Add Process in Desired Manner"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Green
        Me.Label2.Location = New System.Drawing.Point(20, 449)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(397, 28)
        Me.Label2.TabIndex = 328
        Me.Label2.Text = "**Note : These Processes will be reflected in your Manufacturing Form." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "         " &
    "      Processes once saved cannot be Modified."
        '
        'chkchange
        '
        Me.chkchange.AutoSize = True
        Me.chkchange.Location = New System.Drawing.Point(701, 452)
        Me.chkchange.Name = "chkchange"
        Me.chkchange.Size = New System.Drawing.Size(15, 14)
        Me.chkchange.TabIndex = 330
        Me.chkchange.UseVisualStyleBackColor = True
        Me.chkchange.Visible = False
        '
        'cmddelete
        '
        Me.cmddelete.BackgroundImage = Global.Magic_Gold.My.Resources.Resources.WASTE
        Me.cmddelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.cmddelete.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmddelete.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmddelete.Location = New System.Drawing.Point(688, 55)
        Me.cmddelete.Name = "cmddelete"
        Me.cmddelete.Size = New System.Drawing.Size(28, 25)
        Me.cmddelete.TabIndex = 329
        Me.cmddelete.UseVisualStyleBackColor = True
        Me.cmddelete.Visible = False
        '
        'cmdedit
        '
        Me.cmdedit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdedit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdedit.Location = New System.Drawing.Point(683, 82)
        Me.cmdedit.Name = "cmdedit"
        Me.cmdedit.Size = New System.Drawing.Size(33, 26)
        Me.cmdedit.TabIndex = 331
        Me.cmdedit.Text = "edit"
        Me.cmdedit.UseVisualStyleBackColor = True
        Me.cmdedit.Visible = False
        '
        'GRoupstocks
        '
        Me.GRoupstocks.BackColor = System.Drawing.Color.Transparent
        Me.GRoupstocks.Controls.Add(Me.rbrandom)
        Me.GRoupstocks.Controls.Add(Me.rbsequence)
        Me.GRoupstocks.ForeColor = System.Drawing.Color.Black
        Me.GRoupstocks.Location = New System.Drawing.Point(115, 9)
        Me.GRoupstocks.Name = "GRoupstocks"
        Me.GRoupstocks.Size = New System.Drawing.Size(100, 79)
        Me.GRoupstocks.TabIndex = 332
        Me.GRoupstocks.TabStop = False
        Me.GRoupstocks.Text = "Process Type"
        '
        'rbrandom
        '
        Me.rbrandom.AutoSize = True
        Me.rbrandom.Location = New System.Drawing.Point(11, 50)
        Me.rbrandom.Name = "rbrandom"
        Me.rbrandom.Size = New System.Drawing.Size(66, 18)
        Me.rbrandom.TabIndex = 8
        Me.rbrandom.Text = "Random"
        Me.rbrandom.UseVisualStyleBackColor = True
        '
        'rbsequence
        '
        Me.rbsequence.AutoSize = True
        Me.rbsequence.Checked = True
        Me.rbsequence.Location = New System.Drawing.Point(11, 25)
        Me.rbsequence.Name = "rbsequence"
        Me.rbsequence.Size = New System.Drawing.Size(72, 18)
        Me.rbsequence.TabIndex = 7
        Me.rbsequence.TabStop = True
        Me.rbsequence.Text = "Sequence"
        Me.rbsequence.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Green
        Me.Label3.Location = New System.Drawing.Point(236, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(377, 28)
        Me.Label3.TabIndex = 333
        Me.Label3.Text = "*Note : This Sequence will be reflected in your Manufacturing Form." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "            " &
    "  Sequence once saved cannot be Modified."
        '
        'lbllock
        '
        Me.lbllock.AutoSize = True
        Me.lbllock.BackColor = System.Drawing.Color.Transparent
        Me.lbllock.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbllock.ForeColor = System.Drawing.Color.Red
        Me.lbllock.Location = New System.Drawing.Point(221, 58)
        Me.lbllock.Name = "lbllock"
        Me.lbllock.Size = New System.Drawing.Size(85, 24)
        Me.lbllock.TabIndex = 400
        Me.lbllock.Text = "Locked"
        Me.lbllock.Visible = False
        '
        'processmaster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.Magic_Gold.My.Resources.Resources.lgn_pnl
        Me.ClientSize = New System.Drawing.Size(824, 533)
        Me.Controls.Add(Me.lbllock)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.GRoupstocks)
        Me.Controls.Add(Me.cmdedit)
        Me.Controls.Add(Me.chkchange)
        Me.Controls.Add(Me.cmddelete)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lbl)
        Me.Controls.Add(Me.cmdclear)
        Me.Controls.Add(Me.cmdok)
        Me.Controls.Add(Me.cmdexit)
        Me.Controls.Add(Me.groupprocess)
        Me.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "processmaster"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Process Master"
        Me.groupprocess.ResumeLayout(False)
        CType(Me.gridmelting, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GRoupstocks.ResumeLayout(False)
        Me.GRoupstocks.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents groupprocess As System.Windows.Forms.GroupBox
    Friend WithEvents cmdclear As System.Windows.Forms.Button
    Friend WithEvents cmdok As System.Windows.Forms.Button
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents lbl As System.Windows.Forms.Label
    Friend WithEvents gridmelting As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents chkchange As System.Windows.Forms.CheckBox
    Friend WithEvents cmddelete As System.Windows.Forms.Button
    Friend WithEvents cmdedit As System.Windows.Forms.Button
    Friend WithEvents GRoupstocks As System.Windows.Forms.GroupBox
    Friend WithEvents rbrandom As System.Windows.Forms.RadioButton
    Friend WithEvents rbsequence As System.Windows.Forms.RadioButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lbllock As System.Windows.Forms.Label
    Friend WithEvents srno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents meltingnettwt As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cmbacc As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents closs As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents cVaccum As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents cKarigar As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents cexcess As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents GMAX As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
