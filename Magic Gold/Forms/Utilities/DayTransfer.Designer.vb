<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DayTransfer
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
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.DTFROM = New System.Windows.Forms.DateTimePicker()
        Me.CMDTRANSFER = New System.Windows.Forms.Button()
        Me.CMDEXIT = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DTTO = New System.Windows.Forms.DateTimePicker()
        Me.CMDB2BUPLOAD = New System.Windows.Forms.Button()
        Me.TXTPATH = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.TXTFILENAME = New System.Windows.Forms.TextBox()
        Me.BlendPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.TXTFILENAME)
        Me.BlendPanel1.Controls.Add(Me.CMDB2BUPLOAD)
        Me.BlendPanel1.Controls.Add(Me.TXTPATH)
        Me.BlendPanel1.Controls.Add(Me.Label6)
        Me.BlendPanel1.Controls.Add(Me.Label1)
        Me.BlendPanel1.Controls.Add(Me.DTTO)
        Me.BlendPanel1.Controls.Add(Me.CMDEXIT)
        Me.BlendPanel1.Controls.Add(Me.CMDTRANSFER)
        Me.BlendPanel1.Controls.Add(Me.Label16)
        Me.BlendPanel1.Controls.Add(Me.DTFROM)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(842, 116)
        Me.BlendPanel1.TabIndex = 0
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(22, 28)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(35, 15)
        Me.Label16.TabIndex = 355
        Me.Label16.Text = "From"
        '
        'DTFROM
        '
        Me.DTFROM.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTFROM.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTFROM.Location = New System.Drawing.Point(61, 24)
        Me.DTFROM.Name = "DTFROM"
        Me.DTFROM.Size = New System.Drawing.Size(89, 23)
        Me.DTFROM.TabIndex = 0
        '
        'CMDTRANSFER
        '
        Me.CMDTRANSFER.Location = New System.Drawing.Point(381, 50)
        Me.CMDTRANSFER.Name = "CMDTRANSFER"
        Me.CMDTRANSFER.Size = New System.Drawing.Size(80, 28)
        Me.CMDTRANSFER.TabIndex = 3
        Me.CMDTRANSFER.Text = "&Transfer"
        Me.CMDTRANSFER.UseVisualStyleBackColor = True
        '
        'CMDEXIT
        '
        Me.CMDEXIT.Location = New System.Drawing.Point(467, 50)
        Me.CMDEXIT.Name = "CMDEXIT"
        Me.CMDEXIT.Size = New System.Drawing.Size(80, 28)
        Me.CMDEXIT.TabIndex = 4
        Me.CMDEXIT.Text = "E&xit"
        Me.CMDEXIT.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(38, 57)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(19, 15)
        Me.Label1.TabIndex = 359
        Me.Label1.Text = "To"
        '
        'DTTO
        '
        Me.DTTO.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTTO.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTTO.Location = New System.Drawing.Point(61, 53)
        Me.DTTO.Name = "DTTO"
        Me.DTTO.Size = New System.Drawing.Size(89, 23)
        Me.DTTO.TabIndex = 1
        '
        'CMDB2BUPLOAD
        '
        Me.CMDB2BUPLOAD.BackColor = System.Drawing.Color.Transparent
        Me.CMDB2BUPLOAD.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDB2BUPLOAD.FlatAppearance.BorderSize = 0
        Me.CMDB2BUPLOAD.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDB2BUPLOAD.ForeColor = System.Drawing.Color.Black
        Me.CMDB2BUPLOAD.Location = New System.Drawing.Point(295, 50)
        Me.CMDB2BUPLOAD.Name = "CMDB2BUPLOAD"
        Me.CMDB2BUPLOAD.Size = New System.Drawing.Size(80, 28)
        Me.CMDB2BUPLOAD.TabIndex = 2
        Me.CMDB2BUPLOAD.Text = "Select File"
        Me.CMDB2BUPLOAD.UseVisualStyleBackColor = False
        '
        'TXTPATH
        '
        Me.TXTPATH.BackColor = System.Drawing.Color.Linen
        Me.TXTPATH.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTPATH.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.TXTPATH.Location = New System.Drawing.Point(201, 24)
        Me.TXTPATH.Name = "TXTPATH"
        Me.TXTPATH.ReadOnly = True
        Me.TXTPATH.Size = New System.Drawing.Size(629, 22)
        Me.TXTPATH.TabIndex = 576
        Me.TXTPATH.TabStop = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(166, 28)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(32, 15)
        Me.Label6.TabIndex = 577
        Me.Label6.Text = "Path"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'TXTFILENAME
        '
        Me.TXTFILENAME.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTFILENAME.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.TXTFILENAME.Location = New System.Drawing.Point(820, 57)
        Me.TXTFILENAME.Multiline = True
        Me.TXTFILENAME.Name = "TXTFILENAME"
        Me.TXTFILENAME.Size = New System.Drawing.Size(10, 22)
        Me.TXTFILENAME.TabIndex = 578
        Me.TXTFILENAME.Visible = False
        '
        'DayTransfer
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(842, 116)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "DayTransfer"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Day Transfer"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents CMDEXIT As Button
    Friend WithEvents CMDTRANSFER As Button
    Friend WithEvents Label16 As Label
    Friend WithEvents DTFROM As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents DTTO As DateTimePicker
    Friend WithEvents CMDB2BUPLOAD As Button
    Friend WithEvents TXTPATH As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents TXTFILENAME As TextBox
End Class
