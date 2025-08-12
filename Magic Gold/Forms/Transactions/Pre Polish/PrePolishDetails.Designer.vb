<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PrePolishDetails
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
        Me.lbl = New System.Windows.Forms.Label()
        Me.TOOLREFRESH = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.TOOLEXCEL = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.TOOLADDNEW = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.gremarks = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GBALANCEWT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GRECWATAGE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GRECNETTWT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GISSNETTWT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GISSGROSSWT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gname = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gsrno = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gridbill = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GRECGROSSWT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.griddetails = New DevExpress.XtraGrid.GridControl()
        Me.CMDOK = New System.Windows.Forms.Button()
        Me.cmdcancel = New System.Windows.Forms.Button()
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.griddetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BlendPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbl
        '
        Me.lbl.AutoSize = True
        Me.lbl.BackColor = System.Drawing.Color.Transparent
        Me.lbl.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbl.Location = New System.Drawing.Point(20, 41)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(132, 14)
        Me.lbl.TabIndex = 319
        Me.lbl.Text = "Select an Entry to Change"
        '
        'TOOLREFRESH
        '
        Me.TOOLREFRESH.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TOOLREFRESH.Image = Global.Magic_Gold.My.Resources.Resources.refreshimage
        Me.TOOLREFRESH.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TOOLREFRESH.Name = "TOOLREFRESH"
        Me.TOOLREFRESH.Size = New System.Drawing.Size(23, 22)
        Me.TOOLREFRESH.Text = "ToolStripButton2"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'TOOLEXCEL
        '
        Me.TOOLEXCEL.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TOOLEXCEL.Image = Global.Magic_Gold.My.Resources.Resources.Excel_icon
        Me.TOOLEXCEL.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TOOLEXCEL.Name = "TOOLEXCEL"
        Me.TOOLEXCEL.Size = New System.Drawing.Size(23, 22)
        Me.TOOLEXCEL.Text = "&Export to Excel"
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'TOOLADDNEW
        '
        Me.TOOLADDNEW.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TOOLADDNEW.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TOOLADDNEW.Name = "TOOLADDNEW"
        Me.TOOLADDNEW.Size = New System.Drawing.Size(62, 22)
        Me.TOOLADDNEW.Text = "Add New"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TOOLADDNEW, Me.toolStripSeparator, Me.TOOLEXCEL, Me.ToolStripSeparator2, Me.TOOLREFRESH, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1087, 25)
        Me.ToolStrip1.TabIndex = 318
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'gremarks
        '
        Me.gremarks.Caption = "Remarks"
        Me.gremarks.FieldName = "REMARKS"
        Me.gremarks.Name = "gremarks"
        Me.gremarks.Visible = True
        Me.gremarks.VisibleIndex = 8
        Me.gremarks.Width = 200
        '
        'GBALANCEWT
        '
        Me.GBALANCEWT.Caption = "Balance Wt"
        Me.GBALANCEWT.DisplayFormat.FormatString = "0.000"
        Me.GBALANCEWT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GBALANCEWT.FieldName = "BALANCE"
        Me.GBALANCEWT.Name = "GBALANCEWT"
        Me.GBALANCEWT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GBALANCEWT.Visible = True
        Me.GBALANCEWT.VisibleIndex = 7
        Me.GBALANCEWT.Width = 90
        '
        'GRECWATAGE
        '
        Me.GRECWATAGE.Caption = "Rec Wastage"
        Me.GRECWATAGE.DisplayFormat.FormatString = "0.000"
        Me.GRECWATAGE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GRECWATAGE.FieldName = "RECWASTAGE"
        Me.GRECWATAGE.Name = "GRECWATAGE"
        Me.GRECWATAGE.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GRECWATAGE.Visible = True
        Me.GRECWATAGE.VisibleIndex = 6
        Me.GRECWATAGE.Width = 90
        '
        'GRECNETTWT
        '
        Me.GRECNETTWT.Caption = "Rec Nett Wt"
        Me.GRECNETTWT.DisplayFormat.FormatString = "0.000"
        Me.GRECNETTWT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GRECNETTWT.FieldName = "RECNETTWT"
        Me.GRECNETTWT.Name = "GRECNETTWT"
        Me.GRECNETTWT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GRECNETTWT.Visible = True
        Me.GRECNETTWT.VisibleIndex = 5
        Me.GRECNETTWT.Width = 90
        '
        'GISSNETTWT
        '
        Me.GISSNETTWT.Caption = "Iss Nett Wt"
        Me.GISSNETTWT.DisplayFormat.FormatString = "0.000"
        Me.GISSNETTWT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GISSNETTWT.FieldName = "ISSNETTWT"
        Me.GISSNETTWT.Name = "GISSNETTWT"
        Me.GISSNETTWT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GISSNETTWT.Visible = True
        Me.GISSNETTWT.VisibleIndex = 3
        Me.GISSNETTWT.Width = 90
        '
        'GISSGROSSWT
        '
        Me.GISSGROSSWT.Caption = "Iss Gross Wt"
        Me.GISSGROSSWT.DisplayFormat.FormatString = "0.000"
        Me.GISSGROSSWT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GISSGROSSWT.FieldName = "ISSGROSSWT"
        Me.GISSGROSSWT.Name = "GISSGROSSWT"
        Me.GISSGROSSWT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GISSGROSSWT.Visible = True
        Me.GISSGROSSWT.VisibleIndex = 2
        Me.GISSGROSSWT.Width = 90
        '
        'gname
        '
        Me.gname.Caption = "Name"
        Me.gname.FieldName = "NAME"
        Me.gname.ImageIndex = 0
        Me.gname.Name = "gname"
        Me.gname.Visible = True
        Me.gname.VisibleIndex = 1
        Me.gname.Width = 200
        '
        'gsrno
        '
        Me.gsrno.Caption = "Sr. No"
        Me.gsrno.FieldName = "PREPOLISHNO"
        Me.gsrno.ImageIndex = 1
        Me.gsrno.Name = "gsrno"
        Me.gsrno.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.gsrno.Visible = True
        Me.gsrno.VisibleIndex = 0
        Me.gsrno.Width = 50
        '
        'gridbill
        '
        Me.gridbill.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbill.Appearance.Row.Options.UseFont = True
        Me.gridbill.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.gsrno, Me.gname, Me.GISSGROSSWT, Me.GISSNETTWT, Me.GRECGROSSWT, Me.GRECNETTWT, Me.GRECWATAGE, Me.GBALANCEWT, Me.gremarks})
        Me.gridbill.GridControl = Me.griddetails
        Me.gridbill.Name = "gridbill"
        Me.gridbill.OptionsBehavior.AutoExpandAllGroups = True
        Me.gridbill.OptionsBehavior.Editable = False
        Me.gridbill.OptionsView.ColumnAutoWidth = False
        Me.gridbill.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.gridbill.OptionsView.ShowAutoFilterRow = True
        Me.gridbill.OptionsView.ShowFooter = True
        Me.gridbill.OptionsView.ShowGroupPanel = False
        '
        'GRECGROSSWT
        '
        Me.GRECGROSSWT.Caption = "Rec Gross Wt"
        Me.GRECGROSSWT.DisplayFormat.FormatString = "0.000"
        Me.GRECGROSSWT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GRECGROSSWT.FieldName = "RECGROSSWT"
        Me.GRECGROSSWT.Name = "GRECGROSSWT"
        Me.GRECGROSSWT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GRECGROSSWT.Visible = True
        Me.GRECGROSSWT.VisibleIndex = 4
        Me.GRECGROSSWT.Width = 90
        '
        'griddetails
        '
        Me.griddetails.Location = New System.Drawing.Point(19, 61)
        Me.griddetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.griddetails.MainView = Me.gridbill
        Me.griddetails.Name = "griddetails"
        Me.griddetails.Size = New System.Drawing.Size(1048, 463)
        Me.griddetails.TabIndex = 315
        Me.griddetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridbill})
        '
        'CMDOK
        '
        Me.CMDOK.BackColor = System.Drawing.Color.Transparent
        Me.CMDOK.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDOK.FlatAppearance.BorderSize = 0
        Me.CMDOK.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDOK.ForeColor = System.Drawing.Color.Black
        Me.CMDOK.Location = New System.Drawing.Point(460, 529)
        Me.CMDOK.Name = "CMDOK"
        Me.CMDOK.Size = New System.Drawing.Size(80, 28)
        Me.CMDOK.TabIndex = 323
        Me.CMDOK.Text = "&Ok"
        Me.CMDOK.UseVisualStyleBackColor = False
        '
        'cmdcancel
        '
        Me.cmdcancel.BackColor = System.Drawing.Color.Transparent
        Me.cmdcancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdcancel.FlatAppearance.BorderSize = 0
        Me.cmdcancel.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdcancel.ForeColor = System.Drawing.Color.Black
        Me.cmdcancel.Location = New System.Drawing.Point(546, 529)
        Me.cmdcancel.Name = "cmdcancel"
        Me.cmdcancel.Size = New System.Drawing.Size(80, 28)
        Me.cmdcancel.TabIndex = 322
        Me.cmdcancel.Text = "E&xit"
        Me.cmdcancel.UseVisualStyleBackColor = False
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.CMDOK)
        Me.BlendPanel1.Controls.Add(Me.cmdcancel)
        Me.BlendPanel1.Controls.Add(Me.griddetails)
        Me.BlendPanel1.Controls.Add(Me.ToolStrip1)
        Me.BlendPanel1.Controls.Add(Me.lbl)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1087, 581)
        Me.BlendPanel1.TabIndex = 4
        '
        'PrePolishDetails
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1087, 581)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "PrePolishDetails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Pre Polish Details"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.griddetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lbl As Label
    Friend WithEvents TOOLREFRESH As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents TOOLEXCEL As ToolStripButton
    Friend WithEvents toolStripSeparator As ToolStripSeparator
    Friend WithEvents TOOLADDNEW As ToolStripButton
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents gremarks As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GBALANCEWT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GRECWATAGE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GRECNETTWT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GISSNETTWT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GISSGROSSWT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gname As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gsrno As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gridbill As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GRECGROSSWT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents griddetails As DevExpress.XtraGrid.GridControl
    Friend WithEvents CMDOK As Button
    Friend WithEvents cmdcancel As Button
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
End Class
