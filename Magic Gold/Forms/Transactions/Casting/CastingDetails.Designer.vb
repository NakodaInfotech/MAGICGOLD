<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CastingDetails
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
        Me.BlendPanel1 = New VbPowerPack.BlendPanel
        Me.CMDOK = New System.Windows.Forms.Button
        Me.cmdcancel = New System.Windows.Forms.Button
        Me.griddetails = New DevExpress.XtraGrid.GridControl
        Me.gridbill = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GCASTINGNO = New DevExpress.XtraGrid.Columns.GridColumn
        Me.gdate = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GTOTALISSGROSS = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GTOTALNETTISS = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GTOTALRECGROSS = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GTOTALNETTIREC = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GLOSS = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GBALANCE = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GREMARKS = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator
        Me.ExcelExport = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.toolrefresh = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.lbl = New System.Windows.Forms.Label
        Me.BlendPanel1.SuspendLayout()
        CType(Me.griddetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
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
        Me.BlendPanel1.Size = New System.Drawing.Size(1004, 562)
        Me.BlendPanel1.TabIndex = 3
        '
        'CMDOK
        '
        Me.CMDOK.BackColor = System.Drawing.Color.Transparent
        Me.CMDOK.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDOK.FlatAppearance.BorderSize = 0
        Me.CMDOK.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDOK.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CMDOK.Location = New System.Drawing.Point(427, 529)
        Me.CMDOK.Name = "CMDOK"
        Me.CMDOK.Size = New System.Drawing.Size(72, 26)
        Me.CMDOK.TabIndex = 323
        Me.CMDOK.Text = "&Ok"
        Me.CMDOK.UseVisualStyleBackColor = False
        '
        'cmdcancel
        '
        Me.cmdcancel.BackColor = System.Drawing.Color.Transparent
        Me.cmdcancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdcancel.FlatAppearance.BorderSize = 0
        Me.cmdcancel.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdcancel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdcancel.Location = New System.Drawing.Point(505, 529)
        Me.cmdcancel.Name = "cmdcancel"
        Me.cmdcancel.Size = New System.Drawing.Size(72, 26)
        Me.cmdcancel.TabIndex = 322
        Me.cmdcancel.Text = "E&xit"
        Me.cmdcancel.UseVisualStyleBackColor = False
        '
        'griddetails
        '
        Me.griddetails.Location = New System.Drawing.Point(17, 61)
        Me.griddetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.griddetails.MainView = Me.gridbill
        Me.griddetails.Name = "griddetails"
        Me.griddetails.Size = New System.Drawing.Size(971, 463)
        Me.griddetails.TabIndex = 315
        Me.griddetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridbill})
        '
        'gridbill
        '
        Me.gridbill.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbill.Appearance.Row.Options.UseFont = True
        Me.gridbill.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GCASTINGNO, Me.gdate, Me.GTOTALISSGROSS, Me.GTOTALNETTISS, Me.GTOTALRECGROSS, Me.GTOTALNETTIREC, Me.GLOSS, Me.GBALANCE, Me.GREMARKS})
        Me.gridbill.GridControl = Me.griddetails
        Me.gridbill.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.gridbill.Name = "gridbill"
        Me.gridbill.OptionsBehavior.AutoExpandAllGroups = True
        Me.gridbill.OptionsBehavior.Editable = False
        Me.gridbill.OptionsView.ColumnAutoWidth = False
        Me.gridbill.OptionsView.ShowAutoFilterRow = True
        Me.gridbill.OptionsView.ShowFooter = True
        '
        'GCASTINGNO
        '
        Me.GCASTINGNO.Caption = "Sr. No"
        Me.GCASTINGNO.FieldName = "CASTINGNO"
        Me.GCASTINGNO.ImageIndex = 1
        Me.GCASTINGNO.Name = "GCASTINGNO"
        Me.GCASTINGNO.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GCASTINGNO.Visible = True
        Me.GCASTINGNO.VisibleIndex = 0
        '
        'gdate
        '
        Me.gdate.Caption = "Date"
        Me.gdate.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.gdate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.gdate.FieldName = "CASTDATE"
        Me.gdate.Name = "gdate"
        Me.gdate.Visible = True
        Me.gdate.VisibleIndex = 1
        Me.gdate.Width = 80
        '
        'GTOTALISSGROSS
        '
        Me.GTOTALISSGROSS.AppearanceCell.BackColor = System.Drawing.Color.Honeydew
        Me.GTOTALISSGROSS.AppearanceCell.Options.UseBackColor = True
        Me.GTOTALISSGROSS.Caption = "Total Gross (Iss)"
        Me.GTOTALISSGROSS.DisplayFormat.FormatString = "0.000"
        Me.GTOTALISSGROSS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GTOTALISSGROSS.FieldName = "TOTALGROSSISS"
        Me.GTOTALISSGROSS.Name = "GTOTALISSGROSS"
        Me.GTOTALISSGROSS.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Me.GTOTALISSGROSS.Visible = True
        Me.GTOTALISSGROSS.VisibleIndex = 2
        Me.GTOTALISSGROSS.Width = 100
        '
        'GTOTALNETTISS
        '
        Me.GTOTALNETTISS.AppearanceCell.BackColor = System.Drawing.Color.Honeydew
        Me.GTOTALNETTISS.AppearanceCell.Options.UseBackColor = True
        Me.GTOTALNETTISS.Caption = "Total Nett (Iss)"
        Me.GTOTALNETTISS.DisplayFormat.FormatString = "0.000"
        Me.GTOTALNETTISS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GTOTALNETTISS.FieldName = "TOTALNETTISS"
        Me.GTOTALNETTISS.Name = "GTOTALNETTISS"
        Me.GTOTALNETTISS.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Me.GTOTALNETTISS.Visible = True
        Me.GTOTALNETTISS.VisibleIndex = 3
        Me.GTOTALNETTISS.Width = 100
        '
        'GTOTALRECGROSS
        '
        Me.GTOTALRECGROSS.AppearanceCell.BackColor = System.Drawing.Color.Linen
        Me.GTOTALRECGROSS.AppearanceCell.Options.UseBackColor = True
        Me.GTOTALRECGROSS.Caption = "Total Gross (Rec)"
        Me.GTOTALRECGROSS.DisplayFormat.FormatString = "0.000"
        Me.GTOTALRECGROSS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GTOTALRECGROSS.FieldName = "TOTALGROSSREC"
        Me.GTOTALRECGROSS.Name = "GTOTALRECGROSS"
        Me.GTOTALRECGROSS.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Me.GTOTALRECGROSS.Visible = True
        Me.GTOTALRECGROSS.VisibleIndex = 4
        Me.GTOTALRECGROSS.Width = 100
        '
        'GTOTALNETTIREC
        '
        Me.GTOTALNETTIREC.AppearanceCell.BackColor = System.Drawing.Color.Linen
        Me.GTOTALNETTIREC.AppearanceCell.Options.UseBackColor = True
        Me.GTOTALNETTIREC.Caption = "Total Nett (Rec)"
        Me.GTOTALNETTIREC.DisplayFormat.FormatString = "0.000"
        Me.GTOTALNETTIREC.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GTOTALNETTIREC.FieldName = "TOTALNETTREC"
        Me.GTOTALNETTIREC.Name = "GTOTALNETTIREC"
        Me.GTOTALNETTIREC.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Me.GTOTALNETTIREC.Visible = True
        Me.GTOTALNETTIREC.VisibleIndex = 5
        Me.GTOTALNETTIREC.Width = 100
        '
        'GLOSS
        '
        Me.GLOSS.Caption = "Loss"
        Me.GLOSS.DisplayFormat.FormatString = "0.000"
        Me.GLOSS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GLOSS.FieldName = "LOSS"
        Me.GLOSS.Name = "GLOSS"
        Me.GLOSS.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Me.GLOSS.Visible = True
        Me.GLOSS.VisibleIndex = 6
        '
        'GBALANCE
        '
        Me.GBALANCE.Caption = "Balance"
        Me.GBALANCE.DisplayFormat.FormatString = "0.000"
        Me.GBALANCE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GBALANCE.FieldName = "BALANCE"
        Me.GBALANCE.Name = "GBALANCE"
        Me.GBALANCE.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Me.GBALANCE.Visible = True
        Me.GBALANCE.VisibleIndex = 7
        '
        'GREMARKS
        '
        Me.GREMARKS.Caption = "Remarks"
        Me.GREMARKS.FieldName = "REMARKS"
        Me.GREMARKS.Name = "GREMARKS"
        Me.GREMARKS.Visible = True
        Me.GREMARKS.VisibleIndex = 8
        Me.GREMARKS.Width = 220
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.toolStripSeparator, Me.ExcelExport, Me.ToolStripSeparator2, Me.toolrefresh, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1004, 25)
        Me.ToolStrip1.TabIndex = 318
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(62, 22)
        Me.ToolStripButton1.Text = "Add New"
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'ExcelExport
        '
        Me.ExcelExport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ExcelExport.Image = Global.Magic_Gold.My.Resources.Resources.Excel_icon
        Me.ExcelExport.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ExcelExport.Name = "ExcelExport"
        Me.ExcelExport.Size = New System.Drawing.Size(23, 22)
        Me.ExcelExport.Text = "&Export to Excel"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'toolrefresh
        '
        Me.toolrefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolrefresh.Image = Global.Magic_Gold.My.Resources.Resources.refreshimage
        Me.toolrefresh.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolrefresh.Name = "toolrefresh"
        Me.toolrefresh.Size = New System.Drawing.Size(23, 22)
        Me.toolrefresh.Text = "ToolStripButton2"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'lbl
        '
        Me.lbl.AutoSize = True
        Me.lbl.BackColor = System.Drawing.Color.Transparent
        Me.lbl.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbl.Location = New System.Drawing.Point(20, 41)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(149, 14)
        Me.lbl.TabIndex = 319
        Me.lbl.Text = "Select a Casting to Change"
        '
        'CastingDetails
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1004, 562)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "CastingDetails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Casting Details"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.griddetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents CMDOK As System.Windows.Forms.Button
    Friend WithEvents cmdcancel As System.Windows.Forms.Button
    Friend WithEvents griddetails As DevExpress.XtraGrid.GridControl
    Friend WithEvents gridbill As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GCASTINGNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gdate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExcelExport As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lbl As System.Windows.Forms.Label
    Friend WithEvents GTOTALISSGROSS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTOTALNETTISS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTOTALRECGROSS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTOTALNETTIREC As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GLOSS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GBALANCE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GREMARKS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents toolrefresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
End Class
