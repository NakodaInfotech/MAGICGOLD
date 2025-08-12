<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class wastagedesign
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(wastagedesign))
        Me.CRPO = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.SuspendLayout()
        '
        'CRPO
        '
        Me.CRPO.ActiveViewIndex = -1
        Me.CRPO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.CRPO, "CRPO")
        Me.CRPO.Name = "CRPO"
        Me.CRPO.SelectionFormula = ""
        Me.CRPO.ViewTimeSelectionFormula = ""
        '
        'wastagedesign
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.CRPO)
        Me.KeyPreview = True
        Me.Name = "wastagedesign"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CRPO As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
