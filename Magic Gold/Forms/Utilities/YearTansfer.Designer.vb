<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class YearTansfer
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
        Me.BlendPanel1 = New VbPowerPack.BlendPanel
        Me.CMDOK = New System.Windows.Forms.Button
        Me.CMDEXIT = New System.Windows.Forms.Button
        Me.GRIDCMP = New System.Windows.Forms.DataGridView
        Me.GCMP = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GCMPPATH = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.lbl = New System.Windows.Forms.Label
        Me.BlendPanel1.SuspendLayout()
        CType(Me.GRIDCMP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.CMDOK)
        Me.BlendPanel1.Controls.Add(Me.CMDEXIT)
        Me.BlendPanel1.Controls.Add(Me.GRIDCMP)
        Me.BlendPanel1.Controls.Add(Me.lbl)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(334, 352)
        Me.BlendPanel1.TabIndex = 18
        '
        'CMDOK
        '
        Me.CMDOK.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDOK.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CMDOK.Location = New System.Drawing.Point(93, 316)
        Me.CMDOK.Name = "CMDOK"
        Me.CMDOK.Size = New System.Drawing.Size(71, 26)
        Me.CMDOK.TabIndex = 184
        Me.CMDOK.Text = "&OK"
        Me.CMDOK.UseVisualStyleBackColor = True
        '
        'CMDEXIT
        '
        Me.CMDEXIT.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDEXIT.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CMDEXIT.Location = New System.Drawing.Point(170, 316)
        Me.CMDEXIT.Name = "CMDEXIT"
        Me.CMDEXIT.Size = New System.Drawing.Size(71, 26)
        Me.CMDEXIT.TabIndex = 183
        Me.CMDEXIT.Text = "&Exit"
        Me.CMDEXIT.UseVisualStyleBackColor = True
        '
        'GRIDCMP
        '
        Me.GRIDCMP.AllowUserToAddRows = False
        Me.GRIDCMP.AllowUserToDeleteRows = False
        Me.GRIDCMP.AllowUserToResizeColumns = False
        Me.GRIDCMP.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(248, Byte), Integer))
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        Me.GRIDCMP.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.GRIDCMP.BackgroundColor = System.Drawing.Color.White
        Me.GRIDCMP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.GRIDCMP.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.GRIDCMP.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Transparent
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(248, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GRIDCMP.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.GRIDCMP.ColumnHeadersHeight = 22
        Me.GRIDCMP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.GRIDCMP.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.GCMP, Me.GCMPPATH})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(248, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GRIDCMP.DefaultCellStyle = DataGridViewCellStyle3
        Me.GRIDCMP.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.GRIDCMP.GridColor = System.Drawing.SystemColors.Control
        Me.GRIDCMP.Location = New System.Drawing.Point(26, 36)
        Me.GRIDCMP.MultiSelect = False
        Me.GRIDCMP.Name = "GRIDCMP"
        Me.GRIDCMP.RowHeadersVisible = False
        Me.GRIDCMP.RowHeadersWidth = 30
        Me.GRIDCMP.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White
        Me.GRIDCMP.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.GRIDCMP.RowTemplate.Height = 20
        Me.GRIDCMP.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GRIDCMP.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.GRIDCMP.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GRIDCMP.Size = New System.Drawing.Size(283, 274)
        Me.GRIDCMP.TabIndex = 18
        '
        'GCMP
        '
        Me.GCMP.HeaderText = "Company Name"
        Me.GCMP.Name = "GCMP"
        Me.GCMP.Width = 250
        '
        'GCMPPATH
        '
        Me.GCMPPATH.HeaderText = "PATH"
        Me.GCMPPATH.Name = "GCMPPATH"
        Me.GCMPPATH.Visible = False
        '
        'lbl
        '
        Me.lbl.AutoSize = True
        Me.lbl.BackColor = System.Drawing.Color.Transparent
        Me.lbl.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl.ForeColor = System.Drawing.Color.Black
        Me.lbl.Location = New System.Drawing.Point(20, 11)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(213, 14)
        Me.lbl.TabIndex = 182
        Me.lbl.Text = "Select Company To Transfer Data From"
        '
        'YearTansfer
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(334, 352)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "YearTansfer"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Year Tansfer"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.GRIDCMP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents CMDOK As System.Windows.Forms.Button
    Friend WithEvents CMDEXIT As System.Windows.Forms.Button
    Friend WithEvents GRIDCMP As System.Windows.Forms.DataGridView
    Friend WithEvents lbl As System.Windows.Forms.Label
    Friend WithEvents GCMP As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GCMPPATH As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
