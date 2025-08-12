<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class trialbalancefilter
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmdExit = New System.Windows.Forms.Button
        Me.cmdShowReport = New System.Windows.Forms.Button
        Me.gridgroup = New System.Windows.Forms.DataGridView
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.cmbarea = New System.Windows.Forms.ComboBox
        Me.chkselect = New System.Windows.Forms.CheckBox
        Me.BlendPanel1 = New VbPowerPack.BlendPanel
        Me.Column1 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.GGROUPNAME = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.gridgroup, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.BlendPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(26, 323)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(32, 14)
        Me.Label1.TabIndex = 257
        Me.Label1.Text = "Area"
        '
        'cmdExit
        '
        Me.cmdExit.BackColor = System.Drawing.Color.Transparent
        Me.cmdExit.FlatAppearance.BorderSize = 0
        Me.cmdExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdExit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdExit.Image = Global.Magic_Gold.My.Resources.Resources._Exit
        Me.cmdExit.Location = New System.Drawing.Point(135, 422)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(84, 26)
        Me.cmdExit.TabIndex = 255
        Me.cmdExit.UseVisualStyleBackColor = False
        '
        'cmdShowReport
        '
        Me.cmdShowReport.BackColor = System.Drawing.Color.Transparent
        Me.cmdShowReport.FlatAppearance.BorderSize = 0
        Me.cmdShowReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdShowReport.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdShowReport.Image = Global.Magic_Gold.My.Resources.Resources.showreport
        Me.cmdShowReport.Location = New System.Drawing.Point(55, 422)
        Me.cmdShowReport.Name = "cmdShowReport"
        Me.cmdShowReport.Size = New System.Drawing.Size(84, 26)
        Me.cmdShowReport.TabIndex = 254
        Me.cmdShowReport.UseVisualStyleBackColor = False
        '
        'gridgroup
        '
        Me.gridgroup.AllowUserToAddRows = False
        Me.gridgroup.AllowUserToDeleteRows = False
        Me.gridgroup.AllowUserToResizeColumns = False
        Me.gridgroup.AllowUserToResizeRows = False
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.gridgroup.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.gridgroup.BackgroundColor = System.Drawing.Color.White
        Me.gridgroup.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gridgroup.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.gridgroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridgroup.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.GGROUPNAME})
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gridgroup.DefaultCellStyle = DataGridViewCellStyle7
        Me.gridgroup.GridColor = System.Drawing.SystemColors.Control
        Me.gridgroup.Location = New System.Drawing.Point(5, 11)
        Me.gridgroup.Margin = New System.Windows.Forms.Padding(2)
        Me.gridgroup.MultiSelect = False
        Me.gridgroup.Name = "gridgroup"
        Me.gridgroup.RowHeadersVisible = False
        Me.gridgroup.RowHeadersWidth = 30
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.Black
        Me.gridgroup.RowsDefaultCellStyle = DataGridViewCellStyle8
        Me.gridgroup.RowTemplate.Height = 20
        Me.gridgroup.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.gridgroup.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridgroup.Size = New System.Drawing.Size(214, 256)
        Me.gridgroup.TabIndex = 264
        Me.gridgroup.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.gridgroup)
        Me.GroupBox2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.Black
        Me.GroupBox2.Location = New System.Drawing.Point(24, 41)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(227, 272)
        Me.GroupBox2.TabIndex = 264
        Me.GroupBox2.TabStop = False
        '
        'cmbarea
        '
        Me.cmbarea.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbarea.FormattingEnabled = True
        Me.cmbarea.Location = New System.Drawing.Point(62, 319)
        Me.cmbarea.Name = "cmbarea"
        Me.cmbarea.Size = New System.Drawing.Size(185, 22)
        Me.cmbarea.TabIndex = 265
        '
        'chkselect
        '
        Me.chkselect.AutoSize = True
        Me.chkselect.BackColor = System.Drawing.Color.Transparent
        Me.chkselect.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkselect.Location = New System.Drawing.Point(29, 17)
        Me.chkselect.Name = "chkselect"
        Me.chkselect.Size = New System.Drawing.Size(77, 18)
        Me.chkselect.TabIndex = 266
        Me.chkselect.Text = "Select All"
        Me.chkselect.UseVisualStyleBackColor = False
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.Label1)
        Me.BlendPanel1.Controls.Add(Me.GroupBox2)
        Me.BlendPanel1.Controls.Add(Me.cmdExit)
        Me.BlendPanel1.Controls.Add(Me.cmdShowReport)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(274, 460)
        Me.BlendPanel1.TabIndex = 267
        '
        'Column1
        '
        Me.Column1.HeaderText = ""
        Me.Column1.Name = "Column1"
        Me.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column1.Width = 35
        '
        'GGROUPNAME
        '
        Me.GGROUPNAME.HeaderText = "Group Name"
        Me.GGROUPNAME.Name = "GGROUPNAME"
        Me.GGROUPNAME.ReadOnly = True
        Me.GGROUPNAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GGROUPNAME.Width = 150
        '
        'trialbalancefilter
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(274, 460)
        Me.Controls.Add(Me.chkselect)
        Me.Controls.Add(Me.cmbarea)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "trialbalancefilter"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Trial Balance Filter"
        CType(Me.gridgroup, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents cmdShowReport As System.Windows.Forms.Button
    Friend WithEvents gridgroup As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbarea As System.Windows.Forms.ComboBox
    Friend WithEvents chkselect As System.Windows.Forms.CheckBox
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents GGROUPNAME As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
