<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MergeItem
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MergeItem))
        Me.BlendPanel1 = New VbPowerPack.BlendPanel
        Me.Label1 = New System.Windows.Forms.Label
        Me.CMBITEMCODE = New System.Windows.Forms.ComboBox
        Me.CMBMERGEITEMCODE = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmdclear = New System.Windows.Forms.Button
        Me.cmdsave = New System.Windows.Forms.Button
        Me.cmdexit = New System.Windows.Forms.Button
        Me.EP = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.BlendPanel1.SuspendLayout()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        resources.ApplyResources(Me.BlendPanel1, "BlendPanel1")
        Me.BlendPanel1.Controls.Add(Me.cmdclear)
        Me.BlendPanel1.Controls.Add(Me.cmdsave)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.CMBMERGEITEMCODE)
        Me.BlendPanel1.Controls.Add(Me.Label2)
        Me.BlendPanel1.Controls.Add(Me.CMBITEMCODE)
        Me.BlendPanel1.Controls.Add(Me.Label1)
        Me.BlendPanel1.Name = "BlendPanel1"
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.Name = "Label1"
        '
        'CMBITEMCODE
        '
        Me.CMBITEMCODE.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBITEMCODE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBITEMCODE.BackColor = System.Drawing.Color.LemonChiffon
        resources.ApplyResources(Me.CMBITEMCODE, "CMBITEMCODE")
        Me.CMBITEMCODE.FormattingEnabled = True
        Me.CMBITEMCODE.Items.AddRange(New Object() {resources.GetString("CMBITEMCODE.Items"), resources.GetString("CMBITEMCODE.Items1"), resources.GetString("CMBITEMCODE.Items2")})
        Me.CMBITEMCODE.Name = "CMBITEMCODE"
        '
        'CMBMERGEITEMCODE
        '
        Me.CMBMERGEITEMCODE.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBMERGEITEMCODE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBMERGEITEMCODE.BackColor = System.Drawing.Color.LemonChiffon
        resources.ApplyResources(Me.CMBMERGEITEMCODE, "CMBMERGEITEMCODE")
        Me.CMBMERGEITEMCODE.FormattingEnabled = True
        Me.CMBMERGEITEMCODE.Items.AddRange(New Object() {resources.GetString("CMBMERGEITEMCODE.Items"), resources.GetString("CMBMERGEITEMCODE.Items1"), resources.GetString("CMBMERGEITEMCODE.Items2")})
        Me.CMBMERGEITEMCODE.Name = "CMBMERGEITEMCODE"
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Name = "Label2"
        '
        'cmdclear
        '
        resources.ApplyResources(Me.cmdclear, "cmdclear")
        Me.cmdclear.ForeColor = System.Drawing.Color.Black
        Me.cmdclear.Name = "cmdclear"
        Me.cmdclear.UseVisualStyleBackColor = True
        '
        'cmdsave
        '
        resources.ApplyResources(Me.cmdsave, "cmdsave")
        Me.cmdsave.ForeColor = System.Drawing.Color.Black
        Me.cmdsave.Name = "cmdsave"
        Me.cmdsave.UseVisualStyleBackColor = True
        '
        'cmdexit
        '
        resources.ApplyResources(Me.cmdexit, "cmdexit")
        Me.cmdexit.ForeColor = System.Drawing.Color.Black
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.UseVisualStyleBackColor = True
        '
        'EP
        '
        Me.EP.BlinkRate = 0
        Me.EP.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.EP.ContainerControl = Me
        '
        'MergeItem
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.BlendPanel1)
        Me.KeyPreview = True
        Me.Name = "MergeItem"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CMBMERGEITEMCODE As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CMBITEMCODE As System.Windows.Forms.ComboBox
    Friend WithEvents cmdclear As System.Windows.Forms.Button
    Friend WithEvents cmdsave As System.Windows.Forms.Button
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents EP As System.Windows.Forms.ErrorProvider
End Class
