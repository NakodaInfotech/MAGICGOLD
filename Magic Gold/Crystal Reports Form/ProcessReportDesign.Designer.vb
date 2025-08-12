<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProcessReportDesign
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
        Me.CRPO = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.SuspendLayout()
        '
        'CRPO
        '
        Me.CRPO.ActiveViewIndex = -1
        Me.CRPO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CRPO.DisplayGroupTree = False
        Me.CRPO.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CRPO.Location = New System.Drawing.Point(0, 0)
        Me.CRPO.Name = "CRPO"
        Me.CRPO.SelectionFormula = ""
        Me.CRPO.Size = New System.Drawing.Size(448, 396)
        Me.CRPO.TabIndex = 4
        Me.CRPO.ViewTimeSelectionFormula = ""
        '
        'ProcessReportDesign
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(448, 396)
        Me.Controls.Add(Me.CRPO)
        Me.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "ProcessReportDesign"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "ProcessReportDesign"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CRPO As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
