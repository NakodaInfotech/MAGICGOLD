<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class progressbar
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
        Me.components = New System.ComponentModel.Container
        Me.bar = New System.Windows.Forms.ProgressBar
        Me.lbl = New System.Windows.Forms.Label
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'bar
        '
        Me.bar.Location = New System.Drawing.Point(25, 25)
        Me.bar.Name = "bar"
        Me.bar.Size = New System.Drawing.Size(397, 25)
        Me.bar.TabIndex = 0
        '
        'lbl
        '
        Me.lbl.Location = New System.Drawing.Point(22, 53)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(230, 21)
        Me.lbl.TabIndex = 1
        Me.lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 200
        '
        'progressbar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(447, 83)
        Me.Controls.Add(Me.lbl)
        Me.Controls.Add(Me.bar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "progressbar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "progressbar"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents bar As System.Windows.Forms.ProgressBar
    Friend WithEvents lbl As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
End Class
