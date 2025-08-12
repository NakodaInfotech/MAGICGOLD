<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class companydetails
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.gridcmp = New System.Windows.Forms.DataGridView
        Me.GCMPNAME = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GCMPID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmdedit = New System.Windows.Forms.Button
        Me.cmddelete = New System.Windows.Forms.Button
        Me.cmdbackup = New System.Windows.Forms.Button
        Me.cmdopen = New System.Windows.Forms.Button
        Me.cmdcreate = New System.Windows.Forms.Button
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        CType(Me.gridcmp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gridcmp
        '
        Me.gridcmp.AllowUserToAddRows = False
        Me.gridcmp.AllowUserToDeleteRows = False
        Me.gridcmp.AllowUserToResizeColumns = False
        Me.gridcmp.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.gridcmp.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.gridcmp.BackgroundColor = System.Drawing.Color.White
        Me.gridcmp.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.gridcmp.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.gridcmp.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Transparent
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gridcmp.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.gridcmp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridcmp.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.GCMPNAME, Me.GCMPID})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gridcmp.DefaultCellStyle = DataGridViewCellStyle4
        Me.gridcmp.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.gridcmp.GridColor = System.Drawing.SystemColors.Control
        Me.gridcmp.Location = New System.Drawing.Point(93, 98)
        Me.gridcmp.MultiSelect = False
        Me.gridcmp.Name = "gridcmp"
        Me.gridcmp.RowHeadersVisible = False
        Me.gridcmp.RowHeadersWidth = 30
        Me.gridcmp.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Black
        Me.gridcmp.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.gridcmp.RowTemplate.Height = 20
        Me.gridcmp.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gridcmp.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.gridcmp.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridcmp.Size = New System.Drawing.Size(245, 162)
        Me.gridcmp.TabIndex = 0
        '
        'GCMPNAME
        '
        Me.GCMPNAME.HeaderText = "Company Name"
        Me.GCMPNAME.MinimumWidth = 2
        Me.GCMPNAME.Name = "GCMPNAME"
        Me.GCMPNAME.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GCMPNAME.Width = 270
        '
        'GCMPID
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.GCMPID.DefaultCellStyle = DataGridViewCellStyle3
        Me.GCMPID.HeaderText = "Company ID"
        Me.GCMPID.Name = "GCMPID"
        Me.GCMPID.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GCMPID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.GCMPID.Visible = False
        Me.GCMPID.Width = 150
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.White
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(201, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(171, 25)
        Me.Label2.TabIndex = 187
        Me.Label2.Text = "Select Company"
        '
        'cmdedit
        '
        Me.cmdedit.Location = New System.Drawing.Point(235, 347)
        Me.cmdedit.Name = "cmdedit"
        Me.cmdedit.Size = New System.Drawing.Size(104, 76)
        Me.cmdedit.TabIndex = 2
        Me.cmdedit.Text = "&Edit Existing Company"
        Me.cmdedit.UseVisualStyleBackColor = True
        '
        'cmddelete
        '
        Me.cmddelete.Image = Global.Magic_Gold.My.Resources.Resources.trash
        Me.cmddelete.Location = New System.Drawing.Point(454, 347)
        Me.cmddelete.Name = "cmddelete"
        Me.cmddelete.Size = New System.Drawing.Size(104, 76)
        Me.cmddelete.TabIndex = 4
        Me.cmddelete.Text = "&Delete Existing Company"
        Me.cmddelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmddelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.cmddelete.UseVisualStyleBackColor = True
        '
        'cmdbackup
        '
        Me.cmdbackup.Image = Global.Magic_Gold.My.Resources.Resources.backupb
        Me.cmdbackup.Location = New System.Drawing.Point(344, 347)
        Me.cmdbackup.Name = "cmdbackup"
        Me.cmdbackup.Size = New System.Drawing.Size(104, 76)
        Me.cmdbackup.TabIndex = 3
        Me.cmdbackup.Text = "Backup Company"
        Me.cmdbackup.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.cmdbackup.UseVisualStyleBackColor = True
        '
        'cmdopen
        '
        Me.cmdopen.Image = Global.Magic_Gold.My.Resources.Resources.openg
        Me.cmdopen.Location = New System.Drawing.Point(125, 347)
        Me.cmdopen.Name = "cmdopen"
        Me.cmdopen.Size = New System.Drawing.Size(104, 76)
        Me.cmdopen.TabIndex = 1
        Me.cmdopen.Text = "&Open Existing Company"
        Me.cmdopen.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.cmdopen.UseVisualStyleBackColor = True
        '
        'cmdcreate
        '
        Me.cmdcreate.Image = Global.Magic_Gold.My.Resources.Resources.Be_Navigator
        Me.cmdcreate.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdcreate.Location = New System.Drawing.Point(15, 347)
        Me.cmdcreate.Name = "cmdcreate"
        Me.cmdcreate.Size = New System.Drawing.Size(104, 76)
        Me.cmdcreate.TabIndex = 5
        Me.cmdcreate.Text = "Create &New Company"
        Me.cmdcreate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.cmdcreate.UseVisualStyleBackColor = True
        '
        'PictureBox2
        '
        Me.PictureBox2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox2.ErrorImage = Nothing
        Me.PictureBox2.Image = Global.Magic_Gold.My.Resources.Resources.Close
        Me.PictureBox2.Location = New System.Drawing.Point(543, 13)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(15, 17)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 195
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Magic_Gold.My.Resources.Resources.hand
        Me.PictureBox1.Location = New System.Drawing.Point(4, 6)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(562, 337)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 193
        Me.PictureBox1.TabStop = False
        '
        'companydetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(570, 432)
        Me.Controls.Add(Me.cmdbackup)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.cmddelete)
        Me.Controls.Add(Me.cmdedit)
        Me.Controls.Add(Me.cmdopen)
        Me.Controls.Add(Me.cmdcreate)
        Me.Controls.Add(Me.gridcmp)
        Me.Controls.Add(Me.PictureBox1)
        Me.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "companydetails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Company Details"
        CType(Me.gridcmp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gridcmp As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmdcreate As System.Windows.Forms.Button
    Friend WithEvents cmdopen As System.Windows.Forms.Button
    Friend WithEvents cmdedit As System.Windows.Forms.Button
    Friend WithEvents cmddelete As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents cmdbackup As System.Windows.Forms.Button
    Friend WithEvents GCMPNAME As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GCMPID As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
