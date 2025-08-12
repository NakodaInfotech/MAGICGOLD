<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LedgerDetailsReport
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
        Me.CMDSAVE = New System.Windows.Forms.Button()
        Me.CMDPRINT = New System.Windows.Forms.Button()
        Me.gridbilldetails = New DevExpress.XtraGrid.GridControl()
        Me.gridbill = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCODE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GGROUP = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GOPBAL = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDRCR = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GAREA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCITY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSTATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCOUNTRY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GRESINO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GALTNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPHONE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GMOBILENO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPANNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSALARY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GADD = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cmdcancel = New System.Windows.Forms.Button()
        Me.BlendPanel1.SuspendLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.CMDSAVE)
        Me.BlendPanel1.Controls.Add(Me.CMDPRINT)
        Me.BlendPanel1.Controls.Add(Me.gridbilldetails)
        Me.BlendPanel1.Controls.Add(Me.cmdcancel)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1134, 581)
        Me.BlendPanel1.TabIndex = 6
        '
        'CMDSAVE
        '
        Me.CMDSAVE.Location = New System.Drawing.Point(484, 547)
        Me.CMDSAVE.Name = "CMDSAVE"
        Me.CMDSAVE.Size = New System.Drawing.Size(80, 28)
        Me.CMDSAVE.TabIndex = 502
        Me.CMDSAVE.Text = "&Refresh"
        Me.CMDSAVE.UseVisualStyleBackColor = True
        '
        'CMDPRINT
        '
        Me.CMDPRINT.BackColor = System.Drawing.Color.Transparent
        Me.CMDPRINT.BackgroundImage = Global.Magic_Gold.My.Resources.Resources.Excel_icon
        Me.CMDPRINT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.CMDPRINT.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDPRINT.FlatAppearance.BorderSize = 0
        Me.CMDPRINT.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CMDPRINT.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDPRINT.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CMDPRINT.Location = New System.Drawing.Point(453, 551)
        Me.CMDPRINT.Name = "CMDPRINT"
        Me.CMDPRINT.Size = New System.Drawing.Size(25, 21)
        Me.CMDPRINT.TabIndex = 501
        Me.CMDPRINT.UseVisualStyleBackColor = False
        '
        'gridbilldetails
        '
        Me.gridbilldetails.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbilldetails.Location = New System.Drawing.Point(16, 14)
        Me.gridbilldetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridbilldetails.MainView = Me.gridbill
        Me.gridbilldetails.Name = "gridbilldetails"
        Me.gridbilldetails.Size = New System.Drawing.Size(1103, 526)
        Me.gridbilldetails.TabIndex = 494
        Me.gridbilldetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridbill})
        '
        'gridbill
        '
        Me.gridbill.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbill.Appearance.Row.Options.UseFont = True
        Me.gridbill.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GNAME, Me.GCODE, Me.GGROUP, Me.GOPBAL, Me.GDRCR, Me.GAREA, Me.GCITY, Me.GSTATE, Me.GCOUNTRY, Me.GRESINO, Me.GALTNO, Me.GPHONE, Me.GMOBILENO, Me.GPANNO, Me.GSALARY, Me.GADD})
        Me.gridbill.GridControl = Me.gridbilldetails
        Me.gridbill.Name = "gridbill"
        Me.gridbill.OptionsBehavior.AllowIncrementalSearch = True
        Me.gridbill.OptionsBehavior.Editable = False
        Me.gridbill.OptionsView.ColumnAutoWidth = False
        Me.gridbill.OptionsView.ShowAutoFilterRow = True
        '
        'GNAME
        '
        Me.GNAME.Caption = "Name"
        Me.GNAME.FieldName = "LEDGERNAME"
        Me.GNAME.Name = "GNAME"
        Me.GNAME.Visible = True
        Me.GNAME.VisibleIndex = 0
        Me.GNAME.Width = 150
        '
        'GCODE
        '
        Me.GCODE.Caption = "Code"
        Me.GCODE.FieldName = "CODE"
        Me.GCODE.Name = "GCODE"
        Me.GCODE.Width = 100
        '
        'GGROUP
        '
        Me.GGROUP.Caption = "Group Name"
        Me.GGROUP.FieldName = "GROUPNAME"
        Me.GGROUP.Name = "GGROUP"
        Me.GGROUP.Visible = True
        Me.GGROUP.VisibleIndex = 1
        Me.GGROUP.Width = 100
        '
        'GOPBAL
        '
        Me.GOPBAL.Caption = "O/P Bal"
        Me.GOPBAL.FieldName = "OPBAL"
        Me.GOPBAL.Name = "GOPBAL"
        '
        'GDRCR
        '
        Me.GDRCR.Caption = "Dr/Cr"
        Me.GDRCR.FieldName = "DRCR"
        Me.GDRCR.Name = "GDRCR"
        Me.GDRCR.Width = 40
        '
        'GAREA
        '
        Me.GAREA.Caption = "Area"
        Me.GAREA.FieldName = "AREA"
        Me.GAREA.Name = "GAREA"
        Me.GAREA.Visible = True
        Me.GAREA.VisibleIndex = 2
        '
        'GCITY
        '
        Me.GCITY.Caption = "City"
        Me.GCITY.FieldName = "CITY"
        Me.GCITY.Name = "GCITY"
        Me.GCITY.Visible = True
        Me.GCITY.VisibleIndex = 3
        Me.GCITY.Width = 90
        '
        'GSTATE
        '
        Me.GSTATE.Caption = "State"
        Me.GSTATE.FieldName = "STATE"
        Me.GSTATE.Name = "GSTATE"
        Me.GSTATE.Visible = True
        Me.GSTATE.VisibleIndex = 4
        Me.GSTATE.Width = 90
        '
        'GCOUNTRY
        '
        Me.GCOUNTRY.Caption = "Country"
        Me.GCOUNTRY.FieldName = "COUNTRY"
        Me.GCOUNTRY.Name = "GCOUNTRY"
        Me.GCOUNTRY.Visible = True
        Me.GCOUNTRY.VisibleIndex = 5
        '
        'GRESINO
        '
        Me.GRESINO.Caption = "Resi No"
        Me.GRESINO.FieldName = "RESINO"
        Me.GRESINO.Name = "GRESINO"
        Me.GRESINO.Visible = True
        Me.GRESINO.VisibleIndex = 6
        Me.GRESINO.Width = 90
        '
        'GALTNO
        '
        Me.GALTNO.Caption = "Alt No"
        Me.GALTNO.FieldName = "ALTNO"
        Me.GALTNO.Name = "GALTNO"
        Me.GALTNO.Visible = True
        Me.GALTNO.VisibleIndex = 7
        '
        'GPHONE
        '
        Me.GPHONE.Caption = "Tel No"
        Me.GPHONE.FieldName = "PHONENO"
        Me.GPHONE.Name = "GPHONE"
        Me.GPHONE.Visible = True
        Me.GPHONE.VisibleIndex = 8
        Me.GPHONE.Width = 90
        '
        'GMOBILENO
        '
        Me.GMOBILENO.Caption = "Mobile No"
        Me.GMOBILENO.FieldName = "MOBILE"
        Me.GMOBILENO.Name = "GMOBILENO"
        Me.GMOBILENO.Visible = True
        Me.GMOBILENO.VisibleIndex = 9
        Me.GMOBILENO.Width = 90
        '
        'GPANNO
        '
        Me.GPANNO.Caption = "PAN No"
        Me.GPANNO.FieldName = "PANNO"
        Me.GPANNO.Name = "GPANNO"
        Me.GPANNO.Visible = True
        Me.GPANNO.VisibleIndex = 10
        Me.GPANNO.Width = 100
        '
        'GSALARY
        '
        Me.GSALARY.Caption = "Salary"
        Me.GSALARY.FieldName = "SALARY"
        Me.GSALARY.Name = "GSALARY"
        Me.GSALARY.Visible = True
        Me.GSALARY.VisibleIndex = 12
        '
        'GADD
        '
        Me.GADD.Caption = "Address"
        Me.GADD.FieldName = "LEDGERADD"
        Me.GADD.Name = "GADD"
        Me.GADD.Visible = True
        Me.GADD.VisibleIndex = 11
        Me.GADD.Width = 200
        '
        'cmdcancel
        '
        Me.cmdcancel.BackColor = System.Drawing.Color.Transparent
        Me.cmdcancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdcancel.FlatAppearance.BorderSize = 0
        Me.cmdcancel.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdcancel.ForeColor = System.Drawing.Color.Black
        Me.cmdcancel.Location = New System.Drawing.Point(570, 546)
        Me.cmdcancel.Name = "cmdcancel"
        Me.cmdcancel.Size = New System.Drawing.Size(80, 28)
        Me.cmdcancel.TabIndex = 316
        Me.cmdcancel.Text = "&Exit"
        Me.cmdcancel.UseVisualStyleBackColor = False
        '
        'LedgerDetailsReport
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1134, 581)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "LedgerDetailsReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Ledger Details Report"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents CMDSAVE As Button
    Friend WithEvents CMDPRINT As Button
    Private WithEvents gridbilldetails As DevExpress.XtraGrid.GridControl
    Private WithEvents gridbill As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCODE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GGROUP As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GOPBAL As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDRCR As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GAREA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCITY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSTATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCOUNTRY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GRESINO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GALTNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPHONE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GMOBILENO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPANNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GADD As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cmdcancel As Button
    Friend WithEvents GSALARY As DevExpress.XtraGrid.Columns.GridColumn
End Class
