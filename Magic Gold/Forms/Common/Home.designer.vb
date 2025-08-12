<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Home
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Home))
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.btaccounts = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(12, 208)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(25, 87)
        Me.Button2.TabIndex = 1
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(12, 404)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(25, 87)
        Me.Button3.TabIndex = 2
        Me.Button3.UseVisualStyleBackColor = True
        '
        'btaccounts
        '
        Me.btaccounts.Location = New System.Drawing.Point(12, 12)
        Me.btaccounts.Name = "btaccounts"
        Me.btaccounts.Size = New System.Drawing.Size(25, 87)
        Me.btaccounts.TabIndex = 3
        Me.btaccounts.UseVisualStyleBackColor = True
        '
        'Home
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.ClientSize = New System.Drawing.Size(915, 504)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.btaccounts)
        Me.Controls.Add(Me.Button3)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Home"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Home"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents btaccounts As System.Windows.Forms.Button
End Class
