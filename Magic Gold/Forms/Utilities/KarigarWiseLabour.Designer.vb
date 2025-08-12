<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class KarigarWiseLabour
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(KarigarWiseLabour))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.BlendPanel1 = New VbPowerPack.BlendPanel
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripdelete = New System.Windows.Forms.ToolStripButton
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmbname = New System.Windows.Forms.ComboBox
        Me.lblname = New System.Windows.Forms.Label
        Me.grouppayment = New System.Windows.Forms.GroupBox
        Me.TXTGM = New System.Windows.Forms.TextBox
        Me.txtlabour = New System.Windows.Forms.TextBox
        Me.griddetails = New System.Windows.Forms.DataGridView
        Me.GCHK = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.GSRNO = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GGM = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLABOUR = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.txtsrno = New System.Windows.Forms.TextBox
        Me.cmdclear = New System.Windows.Forms.Button
        Me.cmdexit = New System.Windows.Forms.Button
        Me.lbl = New System.Windows.Forms.Label
        Me.BlendPanel1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.grouppayment.SuspendLayout()
        CType(Me.griddetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.ToolStrip1)
        Me.BlendPanel1.Controls.Add(Me.Label4)
        Me.BlendPanel1.Controls.Add(Me.cmbname)
        Me.BlendPanel1.Controls.Add(Me.lblname)
        Me.BlendPanel1.Controls.Add(Me.grouppayment)
        Me.BlendPanel1.Controls.Add(Me.cmdclear)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.lbl)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(399, 562)
        Me.BlendPanel1.TabIndex = 0
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ToolStrip1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripdelete})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(399, 25)
        Me.ToolStrip1.TabIndex = 383
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripdelete
        '
        Me.ToolStripdelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripdelete.Image = CType(resources.GetObject("ToolStripdelete.Image"), System.Drawing.Image)
        Me.ToolStripdelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripdelete.Name = "ToolStripdelete"
        Me.ToolStripdelete.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripdelete.Text = "C&ut"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(25, 53)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 14)
        Me.Label4.TabIndex = 381
        Me.Label4.Text = "Party Code"
        '
        'cmbname
        '
        Me.cmbname.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbname.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbname.BackColor = System.Drawing.Color.White
        Me.cmbname.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbname.Items.AddRange(New Object() {""})
        Me.cmbname.Location = New System.Drawing.Point(90, 49)
        Me.cmbname.Name = "cmbname"
        Me.cmbname.Size = New System.Drawing.Size(102, 22)
        Me.cmbname.TabIndex = 0
        '
        'lblname
        '
        Me.lblname.AutoSize = True
        Me.lblname.BackColor = System.Drawing.Color.Transparent
        Me.lblname.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblname.ForeColor = System.Drawing.Color.Green
        Me.lblname.Location = New System.Drawing.Point(192, 53)
        Me.lblname.Name = "lblname"
        Me.lblname.Size = New System.Drawing.Size(0, 14)
        Me.lblname.TabIndex = 382
        '
        'grouppayment
        '
        Me.grouppayment.BackColor = System.Drawing.Color.Transparent
        Me.grouppayment.Controls.Add(Me.TXTGM)
        Me.grouppayment.Controls.Add(Me.txtlabour)
        Me.grouppayment.Controls.Add(Me.griddetails)
        Me.grouppayment.Controls.Add(Me.txtsrno)
        Me.grouppayment.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grouppayment.ForeColor = System.Drawing.Color.Black
        Me.grouppayment.Location = New System.Drawing.Point(15, 67)
        Me.grouppayment.Name = "grouppayment"
        Me.grouppayment.Size = New System.Drawing.Size(369, 456)
        Me.grouppayment.TabIndex = 1
        Me.grouppayment.TabStop = False
        '
        'TXTGM
        '
        Me.TXTGM.BackColor = System.Drawing.Color.White
        Me.TXTGM.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTGM.ForeColor = System.Drawing.Color.Black
        Me.TXTGM.Location = New System.Drawing.Point(84, 13)
        Me.TXTGM.Name = "TXTGM"
        Me.TXTGM.Size = New System.Drawing.Size(150, 22)
        Me.TXTGM.TabIndex = 1
        '
        'txtlabour
        '
        Me.txtlabour.BackColor = System.Drawing.Color.White
        Me.txtlabour.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtlabour.ForeColor = System.Drawing.Color.Black
        Me.txtlabour.Location = New System.Drawing.Point(234, 13)
        Me.txtlabour.Name = "txtlabour"
        Me.txtlabour.Size = New System.Drawing.Size(100, 22)
        Me.txtlabour.TabIndex = 2
        '
        'griddetails
        '
        Me.griddetails.AllowUserToAddRows = False
        Me.griddetails.AllowUserToDeleteRows = False
        Me.griddetails.AllowUserToResizeColumns = False
        Me.griddetails.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer))
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        Me.griddetails.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.griddetails.BackgroundColor = System.Drawing.Color.White
        Me.griddetails.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.griddetails.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.griddetails.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.griddetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.griddetails.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.GCHK, Me.GSRNO, Me.GGM, Me.GLABOUR})
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.griddetails.DefaultCellStyle = DataGridViewCellStyle6
        Me.griddetails.GridColor = System.Drawing.SystemColors.ControlText
        Me.griddetails.Location = New System.Drawing.Point(5, 35)
        Me.griddetails.Margin = New System.Windows.Forms.Padding(2)
        Me.griddetails.MultiSelect = False
        Me.griddetails.Name = "griddetails"
        Me.griddetails.RowHeadersVisible = False
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.Black
        Me.griddetails.RowsDefaultCellStyle = DataGridViewCellStyle7
        Me.griddetails.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.griddetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.griddetails.Size = New System.Drawing.Size(360, 417)
        Me.griddetails.TabIndex = 3
        Me.griddetails.TabStop = False
        '
        'GCHK
        '
        Me.GCHK.HeaderText = ""
        Me.GCHK.Name = "GCHK"
        Me.GCHK.ReadOnly = True
        Me.GCHK.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GCHK.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.GCHK.Width = 40
        '
        'GSRNO
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.GSRNO.DefaultCellStyle = DataGridViewCellStyle3
        Me.GSRNO.HeaderText = "Sr."
        Me.GSRNO.Name = "GSRNO"
        Me.GSRNO.ReadOnly = True
        Me.GSRNO.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GSRNO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GSRNO.Width = 40
        '
        'GGM
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.GGM.DefaultCellStyle = DataGridViewCellStyle4
        Me.GGM.HeaderText = "GM"
        Me.GGM.Name = "GGM"
        Me.GGM.ReadOnly = True
        Me.GGM.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GGM.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GGM.Width = 150
        '
        'GLABOUR
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.GLABOUR.DefaultCellStyle = DataGridViewCellStyle5
        Me.GLABOUR.HeaderText = "Labour (Amt)"
        Me.GLABOUR.Name = "GLABOUR"
        Me.GLABOUR.ReadOnly = True
        Me.GLABOUR.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GLABOUR.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'txtsrno
        '
        Me.txtsrno.BackColor = System.Drawing.Color.White
        Me.txtsrno.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtsrno.Location = New System.Drawing.Point(44, 13)
        Me.txtsrno.Name = "txtsrno"
        Me.txtsrno.ReadOnly = True
        Me.txtsrno.Size = New System.Drawing.Size(40, 22)
        Me.txtsrno.TabIndex = 0
        '
        'cmdclear
        '
        Me.cmdclear.BackColor = System.Drawing.Color.Transparent
        Me.cmdclear.FlatAppearance.BorderSize = 0
        Me.cmdclear.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdclear.ForeColor = System.Drawing.Color.Black
        Me.cmdclear.Location = New System.Drawing.Point(116, 528)
        Me.cmdclear.Name = "cmdclear"
        Me.cmdclear.Size = New System.Drawing.Size(80, 28)
        Me.cmdclear.TabIndex = 2
        Me.cmdclear.Text = "&Clear"
        Me.cmdclear.UseVisualStyleBackColor = False
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.Black
        Me.cmdexit.Location = New System.Drawing.Point(202, 528)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 28)
        Me.cmdexit.TabIndex = 3
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'lbl
        '
        Me.lbl.AutoSize = True
        Me.lbl.BackColor = System.Drawing.Color.Transparent
        Me.lbl.Font = New System.Drawing.Font("Calibri", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbl.Location = New System.Drawing.Point(12, 24)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(150, 21)
        Me.lbl.TabIndex = 306
        Me.lbl.Text = "Karigar Wise Labour"
        '
        'KarigarWiseLabour
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(399, 562)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "KarigarWiseLabour"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Karigar Wise Labour"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.grouppayment.ResumeLayout(False)
        Me.grouppayment.PerformLayout()
        CType(Me.griddetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbname As System.Windows.Forms.ComboBox
    Friend WithEvents lblname As System.Windows.Forms.Label
    Friend WithEvents grouppayment As System.Windows.Forms.GroupBox
    Friend WithEvents txtlabour As System.Windows.Forms.TextBox
    Friend WithEvents griddetails As System.Windows.Forms.DataGridView
    Friend WithEvents txtsrno As System.Windows.Forms.TextBox
    Friend WithEvents cmdclear As System.Windows.Forms.Button
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents lbl As System.Windows.Forms.Label
    Friend WithEvents GCHK As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents GSRNO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GGM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLABOUR As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TXTGM As System.Windows.Forms.TextBox
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripdelete As System.Windows.Forms.ToolStripButton
End Class
