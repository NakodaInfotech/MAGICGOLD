<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SelectEntryforPrint
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.BlendPanel1 = New VbPowerPack.BlendPanel
        Me.CHKALL = New System.Windows.Forms.CheckBox
        Me.GRIDENTRY = New System.Windows.Forms.DataGridView
        Me.LBLNAME = New System.Windows.Forms.Label
        Me.cmbcode = New System.Windows.Forms.ComboBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.dtpto = New System.Windows.Forms.DateTimePicker
        Me.dtpfrom = New System.Windows.Forms.DateTimePicker
        Me.cmdexit = New System.Windows.Forms.Button
        Me.cmdok = New System.Windows.Forms.Button
        Me.BlendPanel1.SuspendLayout()
        CType(Me.GRIDENTRY, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.CHKALL)
        Me.BlendPanel1.Controls.Add(Me.GRIDENTRY)
        Me.BlendPanel1.Controls.Add(Me.LBLNAME)
        Me.BlendPanel1.Controls.Add(Me.cmbcode)
        Me.BlendPanel1.Controls.Add(Me.Label9)
        Me.BlendPanel1.Controls.Add(Me.Label17)
        Me.BlendPanel1.Controls.Add(Me.Label16)
        Me.BlendPanel1.Controls.Add(Me.dtpto)
        Me.BlendPanel1.Controls.Add(Me.dtpfrom)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.cmdok)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(589, 562)
        Me.BlendPanel1.TabIndex = 0
        '
        'CHKALL
        '
        Me.CHKALL.AutoSize = True
        Me.CHKALL.BackColor = System.Drawing.Color.Transparent
        Me.CHKALL.Location = New System.Drawing.Point(390, 43)
        Me.CHKALL.Name = "CHKALL"
        Me.CHKALL.Size = New System.Drawing.Size(76, 19)
        Me.CHKALL.TabIndex = 390
        Me.CHKALL.Text = "Select All"
        Me.CHKALL.UseVisualStyleBackColor = False
        '
        'GRIDENTRY
        '
        Me.GRIDENTRY.AllowUserToAddRows = False
        Me.GRIDENTRY.AllowUserToDeleteRows = False
        Me.GRIDENTRY.AllowUserToResizeColumns = False
        Me.GRIDENTRY.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(248, Byte), Integer))
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Black
        Me.GRIDENTRY.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.GRIDENTRY.BackgroundColor = System.Drawing.Color.White
        Me.GRIDENTRY.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GRIDENTRY.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.GRIDENTRY.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GRIDENTRY.DefaultCellStyle = DataGridViewCellStyle3
        Me.GRIDENTRY.GridColor = System.Drawing.SystemColors.Control
        Me.GRIDENTRY.Location = New System.Drawing.Point(29, 63)
        Me.GRIDENTRY.Margin = New System.Windows.Forms.Padding(2)
        Me.GRIDENTRY.MultiSelect = False
        Me.GRIDENTRY.Name = "GRIDENTRY"
        Me.GRIDENTRY.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GRIDENTRY.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.GRIDENTRY.RowHeadersVisible = False
        Me.GRIDENTRY.RowHeadersWidth = 30
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White
        Me.GRIDENTRY.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.GRIDENTRY.RowTemplate.Height = 20
        Me.GRIDENTRY.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GRIDENTRY.Size = New System.Drawing.Size(531, 457)
        Me.GRIDENTRY.TabIndex = 389
        '
        'LBLNAME
        '
        Me.LBLNAME.BackColor = System.Drawing.Color.Transparent
        Me.LBLNAME.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLNAME.ForeColor = System.Drawing.Color.Maroon
        Me.LBLNAME.Location = New System.Drawing.Point(131, 38)
        Me.LBLNAME.Name = "LBLNAME"
        Me.LBLNAME.Size = New System.Drawing.Size(123, 22)
        Me.LBLNAME.TabIndex = 388
        Me.LBLNAME.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbcode
        '
        Me.cmbcode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbcode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbcode.BackColor = System.Drawing.Color.White
        Me.cmbcode.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbcode.Items.AddRange(New Object() {""})
        Me.cmbcode.Location = New System.Drawing.Point(31, 38)
        Me.cmbcode.Name = "cmbcode"
        Me.cmbcode.Size = New System.Drawing.Size(93, 22)
        Me.cmbcode.TabIndex = 382
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(32, 22)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(34, 14)
        Me.Label9.TabIndex = 383
        Me.Label9.Text = "Code"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.Label17.Location = New System.Drawing.Point(277, 43)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(19, 14)
        Me.Label17.TabIndex = 381
        Me.Label17.Text = "To"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.Label16.Location = New System.Drawing.Point(263, 19)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(34, 14)
        Me.Label16.TabIndex = 380
        Me.Label16.Text = "From"
        '
        'dtpto
        '
        Me.dtpto.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.dtpto.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpto.Location = New System.Drawing.Point(300, 40)
        Me.dtpto.Name = "dtpto"
        Me.dtpto.Size = New System.Drawing.Size(84, 22)
        Me.dtpto.TabIndex = 379
        '
        'dtpfrom
        '
        Me.dtpfrom.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.dtpfrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpfrom.Location = New System.Drawing.Point(300, 16)
        Me.dtpfrom.Name = "dtpfrom"
        Me.dtpfrom.Size = New System.Drawing.Size(84, 22)
        Me.dtpfrom.TabIndex = 378
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdexit.Location = New System.Drawing.Point(297, 528)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(68, 24)
        Me.cmdexit.TabIndex = 377
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'cmdok
        '
        Me.cmdok.BackColor = System.Drawing.Color.Transparent
        Me.cmdok.FlatAppearance.BorderSize = 0
        Me.cmdok.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdok.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdok.Location = New System.Drawing.Point(223, 528)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(68, 24)
        Me.cmdok.TabIndex = 376
        Me.cmdok.Text = "&Print"
        Me.cmdok.UseVisualStyleBackColor = False
        '
        'SelectEntryforPrint
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(589, 562)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "SelectEntryforPrint"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Select Entry"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.GRIDENTRY, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents cmdok As System.Windows.Forms.Button
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents dtpto As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpfrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmbcode As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents LBLNAME As System.Windows.Forms.Label
    Friend WithEvents GRIDENTRY As System.Windows.Forms.DataGridView
    Friend WithEvents CHKALL As System.Windows.Forms.CheckBox
End Class
