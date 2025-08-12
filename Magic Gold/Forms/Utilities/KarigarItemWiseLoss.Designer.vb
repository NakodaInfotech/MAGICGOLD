<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class KarigarItemWiseLoss
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
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(KarigarItemWiseLoss))
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.BlendPanel1 = New VbPowerPack.BlendPanel
        Me.TXTLOSS = New System.Windows.Forms.TextBox
        Me.griddetails = New System.Windows.Forms.DataGridView
        Me.CMBITEMNAME = New System.Windows.Forms.ComboBox
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripdelete = New System.Windows.Forms.ToolStripButton
        Me.TXTLABOUR = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.TXTSRNO = New System.Windows.Forms.TextBox
        Me.CMBNAME = New System.Windows.Forms.ComboBox
        Me.lblname = New System.Windows.Forms.Label
        Me.cmdclear = New System.Windows.Forms.Button
        Me.cmdexit = New System.Windows.Forms.Button
        Me.GSRNO = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GITEMCODE = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLOSS = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLABOUR = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BlendPanel1.SuspendLayout()
        CType(Me.griddetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.TXTLOSS)
        Me.BlendPanel1.Controls.Add(Me.griddetails)
        Me.BlendPanel1.Controls.Add(Me.CMBITEMNAME)
        Me.BlendPanel1.Controls.Add(Me.ToolStrip1)
        Me.BlendPanel1.Controls.Add(Me.TXTLABOUR)
        Me.BlendPanel1.Controls.Add(Me.Label4)
        Me.BlendPanel1.Controls.Add(Me.TXTSRNO)
        Me.BlendPanel1.Controls.Add(Me.CMBNAME)
        Me.BlendPanel1.Controls.Add(Me.lblname)
        Me.BlendPanel1.Controls.Add(Me.cmdclear)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(484, 562)
        Me.BlendPanel1.TabIndex = 0
        '
        'TXTLOSS
        '
        Me.TXTLOSS.BackColor = System.Drawing.Color.White
        Me.TXTLOSS.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTLOSS.ForeColor = System.Drawing.Color.Black
        Me.TXTLOSS.Location = New System.Drawing.Point(220, 63)
        Me.TXTLOSS.Name = "TXTLOSS"
        Me.TXTLOSS.Size = New System.Drawing.Size(100, 22)
        Me.TXTLOSS.TabIndex = 2
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
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.griddetails.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.griddetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.griddetails.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.GSRNO, Me.GITEMCODE, Me.GLOSS, Me.GLABOUR})
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.griddetails.DefaultCellStyle = DataGridViewCellStyle7
        Me.griddetails.GridColor = System.Drawing.SystemColors.ControlText
        Me.griddetails.Location = New System.Drawing.Point(30, 85)
        Me.griddetails.Margin = New System.Windows.Forms.Padding(2)
        Me.griddetails.MultiSelect = False
        Me.griddetails.Name = "griddetails"
        Me.griddetails.RowHeadersVisible = False
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.Black
        Me.griddetails.RowsDefaultCellStyle = DataGridViewCellStyle8
        Me.griddetails.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.griddetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.griddetails.Size = New System.Drawing.Size(425, 438)
        Me.griddetails.TabIndex = 3
        Me.griddetails.TabStop = False
        '
        'CMBITEMNAME
        '
        Me.CMBITEMNAME.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBITEMNAME.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBITEMNAME.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBITEMNAME.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBITEMNAME.FormattingEnabled = True
        Me.CMBITEMNAME.Location = New System.Drawing.Point(70, 63)
        Me.CMBITEMNAME.MaxDropDownItems = 14
        Me.CMBITEMNAME.Name = "CMBITEMNAME"
        Me.CMBITEMNAME.Size = New System.Drawing.Size(150, 23)
        Me.CMBITEMNAME.TabIndex = 1
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ToolStrip1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripdelete})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(484, 25)
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
        'TXTLABOUR
        '
        Me.TXTLABOUR.BackColor = System.Drawing.Color.White
        Me.TXTLABOUR.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTLABOUR.ForeColor = System.Drawing.Color.Black
        Me.TXTLABOUR.Location = New System.Drawing.Point(320, 63)
        Me.TXTLABOUR.Name = "TXTLABOUR"
        Me.TXTLABOUR.Size = New System.Drawing.Size(100, 22)
        Me.TXTLABOUR.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(25, 38)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 14)
        Me.Label4.TabIndex = 381
        Me.Label4.Text = "Party Code"
        '
        'TXTSRNO
        '
        Me.TXTSRNO.BackColor = System.Drawing.Color.Linen
        Me.TXTSRNO.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTSRNO.Location = New System.Drawing.Point(30, 63)
        Me.TXTSRNO.Name = "TXTSRNO"
        Me.TXTSRNO.ReadOnly = True
        Me.TXTSRNO.Size = New System.Drawing.Size(40, 22)
        Me.TXTSRNO.TabIndex = 0
        Me.TXTSRNO.TabStop = False
        '
        'CMBNAME
        '
        Me.CMBNAME.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBNAME.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBNAME.BackColor = System.Drawing.Color.White
        Me.CMBNAME.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBNAME.Items.AddRange(New Object() {""})
        Me.CMBNAME.Location = New System.Drawing.Point(90, 34)
        Me.CMBNAME.Name = "CMBNAME"
        Me.CMBNAME.Size = New System.Drawing.Size(150, 22)
        Me.CMBNAME.TabIndex = 0
        '
        'lblname
        '
        Me.lblname.AutoSize = True
        Me.lblname.BackColor = System.Drawing.Color.Transparent
        Me.lblname.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblname.ForeColor = System.Drawing.Color.Green
        Me.lblname.Location = New System.Drawing.Point(246, 38)
        Me.lblname.Name = "lblname"
        Me.lblname.Size = New System.Drawing.Size(0, 14)
        Me.lblname.TabIndex = 382
        '
        'cmdclear
        '
        Me.cmdclear.BackColor = System.Drawing.Color.Transparent
        Me.cmdclear.FlatAppearance.BorderSize = 0
        Me.cmdclear.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdclear.ForeColor = System.Drawing.Color.Black
        Me.cmdclear.Location = New System.Drawing.Point(159, 528)
        Me.cmdclear.Name = "cmdclear"
        Me.cmdclear.Size = New System.Drawing.Size(80, 28)
        Me.cmdclear.TabIndex = 4
        Me.cmdclear.Text = "&Clear"
        Me.cmdclear.UseVisualStyleBackColor = False
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.Black
        Me.cmdexit.Location = New System.Drawing.Point(245, 528)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 28)
        Me.cmdexit.TabIndex = 5
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
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
        'GITEMCODE
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.GITEMCODE.DefaultCellStyle = DataGridViewCellStyle4
        Me.GITEMCODE.HeaderText = "Item Code"
        Me.GITEMCODE.Name = "GITEMCODE"
        Me.GITEMCODE.ReadOnly = True
        Me.GITEMCODE.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GITEMCODE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GITEMCODE.Width = 150
        '
        'GLOSS
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.GLOSS.DefaultCellStyle = DataGridViewCellStyle5
        Me.GLOSS.HeaderText = "Loss %"
        Me.GLOSS.Name = "GLOSS"
        Me.GLOSS.ReadOnly = True
        Me.GLOSS.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GLOSS.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'GLABOUR
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.GLABOUR.DefaultCellStyle = DataGridViewCellStyle6
        Me.GLABOUR.HeaderText = "Labour / Gm"
        Me.GLABOUR.Name = "GLABOUR"
        Me.GLABOUR.ReadOnly = True
        Me.GLABOUR.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GLABOUR.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'KarigarItemWiseLoss
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(484, 562)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "KarigarItemWiseLoss"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Karigar - Item Wise Loss"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.griddetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripdelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CMBNAME As System.Windows.Forms.ComboBox
    Friend WithEvents lblname As System.Windows.Forms.Label
    Friend WithEvents TXTLABOUR As System.Windows.Forms.TextBox
    Friend WithEvents griddetails As System.Windows.Forms.DataGridView
    Friend WithEvents TXTSRNO As System.Windows.Forms.TextBox
    Friend WithEvents cmdclear As System.Windows.Forms.Button
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents TXTLOSS As System.Windows.Forms.TextBox
    Friend WithEvents CMBITEMNAME As System.Windows.Forms.ComboBox
    Friend WithEvents GSRNO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GITEMCODE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLOSS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLABOUR As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
