<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Selectlotno
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.lbl = New System.Windows.Forms.Label
        Me.cmdcancel = New System.Windows.Forms.Button
        Me.cmdok = New System.Windows.Forms.Button
        Me.gridlotno = New System.Windows.Forms.DataGridView
        Me.BlendPanel1 = New VbPowerPack.BlendPanel
        CType(Me.gridlotno, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BlendPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbl
        '
        Me.lbl.AutoSize = True
        Me.lbl.BackColor = System.Drawing.Color.Transparent
        Me.lbl.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbl.Location = New System.Drawing.Point(20, 14)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(109, 14)
        Me.lbl.TabIndex = 247
        Me.lbl.Text = "Select a Lot to Mfg."
        '
        'cmdcancel
        '
        Me.cmdcancel.BackColor = System.Drawing.Color.Transparent
        Me.cmdcancel.FlatAppearance.BorderSize = 0
        Me.cmdcancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdcancel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdcancel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdcancel.Image = Global.Magic_Gold.My.Resources.Resources._Exit
        Me.cmdcancel.Location = New System.Drawing.Point(234, 453)
        Me.cmdcancel.Name = "cmdcancel"
        Me.cmdcancel.Size = New System.Drawing.Size(80, 26)
        Me.cmdcancel.TabIndex = 246
        Me.cmdcancel.UseVisualStyleBackColor = False
        '
        'cmdok
        '
        Me.cmdok.BackColor = System.Drawing.Color.Transparent
        Me.cmdok.FlatAppearance.BorderSize = 0
        Me.cmdok.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdok.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdok.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdok.Image = Global.Magic_Gold.My.Resources.Resources.ok
        Me.cmdok.Location = New System.Drawing.Point(148, 453)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(80, 26)
        Me.cmdok.TabIndex = 245
        Me.cmdok.UseVisualStyleBackColor = False
        '
        'gridlotno
        '
        Me.gridlotno.AllowUserToAddRows = False
        Me.gridlotno.AllowUserToDeleteRows = False
        Me.gridlotno.AllowUserToResizeColumns = False
        Me.gridlotno.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.gridlotno.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.gridlotno.BackgroundColor = System.Drawing.Color.White
        Me.gridlotno.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gridlotno.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.gridlotno.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gridlotno.DefaultCellStyle = DataGridViewCellStyle3
        Me.gridlotno.GridColor = System.Drawing.SystemColors.Control
        Me.gridlotno.Location = New System.Drawing.Point(23, 37)
        Me.gridlotno.Margin = New System.Windows.Forms.Padding(2)
        Me.gridlotno.MultiSelect = False
        Me.gridlotno.Name = "gridlotno"
        Me.gridlotno.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gridlotno.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.gridlotno.RowHeadersVisible = False
        Me.gridlotno.RowHeadersWidth = 30
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Black
        Me.gridlotno.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.gridlotno.RowTemplate.Height = 20
        Me.gridlotno.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.gridlotno.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridlotno.Size = New System.Drawing.Size(420, 409)
        Me.gridlotno.TabIndex = 244
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.cmdcancel)
        Me.BlendPanel1.Controls.Add(Me.cmdok)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(462, 491)
        Me.BlendPanel1.TabIndex = 248
        '
        'Selectlotno
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(462, 491)
        Me.Controls.Add(Me.lbl)
        Me.Controls.Add(Me.gridlotno)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "Selectlotno"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Select Lot No"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.gridlotno, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BlendPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbl As System.Windows.Forms.Label
    Friend WithEvents cmdcancel As System.Windows.Forms.Button
    Friend WithEvents cmdok As System.Windows.Forms.Button
    Friend WithEvents gridlotno As System.Windows.Forms.DataGridView
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
End Class
