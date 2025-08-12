<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Stockform
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
        Me.cmdexit = New System.Windows.Forms.Button
        Me.gridkarigar = New System.Windows.Forms.DataGridView
        Me.BlendPanel1.SuspendLayout()
        CType(Me.gridkarigar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.Khaki, System.Drawing.Color.Khaki)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.gridkarigar)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(387, 244)
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
        Me.cmdexit.Location = New System.Drawing.Point(158, 208)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(71, 24)
        Me.cmdexit.TabIndex = 23
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'gridkarigar
        '
        Me.gridkarigar.AllowUserToResizeColumns = False
        Me.gridkarigar.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer))
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Black
        Me.gridkarigar.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.gridkarigar.BackgroundColor = System.Drawing.Color.White
        Me.gridkarigar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.gridkarigar.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gridkarigar.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.gridkarigar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gridkarigar.DefaultCellStyle = DataGridViewCellStyle3
        Me.gridkarigar.GridColor = System.Drawing.SystemColors.ControlText
        Me.gridkarigar.Location = New System.Drawing.Point(11, 11)
        Me.gridkarigar.Margin = New System.Windows.Forms.Padding(2)
        Me.gridkarigar.MultiSelect = False
        Me.gridkarigar.Name = "gridkarigar"
        Me.gridkarigar.ReadOnly = True
        Me.gridkarigar.RowHeadersVisible = False
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Black
        Me.gridkarigar.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.gridkarigar.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.gridkarigar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.gridkarigar.Size = New System.Drawing.Size(366, 188)
        Me.gridkarigar.TabIndex = 21
        '
        'Stockform
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.ClientSize = New System.Drawing.Size(387, 244)
        Me.Controls.Add(Me.BlendPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "Stockform"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Stockform"
        Me.BlendPanel1.ResumeLayout(False)
        CType(Me.gridkarigar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents gridkarigar As System.Windows.Forms.DataGridView
    Friend WithEvents cmdexit As System.Windows.Forms.Button
End Class
