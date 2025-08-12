<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LabellingDetails
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
        Me.CMDOK = New System.Windows.Forms.Button()
        Me.cmdcancel = New System.Windows.Forms.Button()
        Me.griddetails = New DevExpress.XtraGrid.GridControl()
        Me.GRIDBILL = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GLABELNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GITEMNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPCS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GGROSSWT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPEARLWT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSTONEWT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GKUNDANWT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GLESSWT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GNETTWT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPURITY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GFINEWT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GREMARKS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.ExcelExport = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.TOOLREFRESH = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.lbl = New System.Windows.Forms.Label()
        Me.BlendPanel1.SuspendLayout()
        CType(Me.griddetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GRIDBILL, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.BlendPanel1.Size = New System.Drawing.Size(1234, 581)
        Me.BlendPanel1.TabIndex = 6
        '
        'CMDOK
        '
        Me.CMDOK.BackColor = System.Drawing.Color.Transparent
        Me.CMDOK.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDOK.FlatAppearance.BorderSize = 0
        Me.CMDOK.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDOK.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CMDOK.Location = New System.Drawing.Point(542, 543)
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
        Me.cmdcancel.Location = New System.Drawing.Point(620, 543)
        Me.cmdcancel.Name = "cmdcancel"
        Me.cmdcancel.Size = New System.Drawing.Size(72, 26)
        Me.cmdcancel.TabIndex = 322
        Me.cmdcancel.Text = "E&xit"
        Me.cmdcancel.UseVisualStyleBackColor = False
        '
        'griddetails
        '
        Me.griddetails.Location = New System.Drawing.Point(21, 61)
        Me.griddetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.griddetails.MainView = Me.GRIDBILL
        Me.griddetails.Name = "griddetails"
        Me.griddetails.Size = New System.Drawing.Size(1201, 476)
        Me.griddetails.TabIndex = 315
        Me.griddetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GRIDBILL})
        '
        'GRIDBILL
        '
        Me.GRIDBILL.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRIDBILL.Appearance.Row.Options.UseFont = True
        Me.GRIDBILL.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GLABELNO, Me.GDATE, Me.GITEMNAME, Me.GPCS, Me.GGROSSWT, Me.GPEARLWT, Me.GSTONEWT, Me.GKUNDANWT, Me.GLESSWT, Me.GNETTWT, Me.GPURITY, Me.GFINEWT, Me.GREMARKS})
        Me.GRIDBILL.GridControl = Me.griddetails
        Me.GRIDBILL.Name = "GRIDBILL"
        Me.GRIDBILL.OptionsBehavior.AutoExpandAllGroups = True
        Me.GRIDBILL.OptionsBehavior.Editable = False
        Me.GRIDBILL.OptionsView.ColumnAutoWidth = False
        Me.GRIDBILL.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.GRIDBILL.OptionsView.ShowAutoFilterRow = True
        Me.GRIDBILL.OptionsView.ShowFooter = True
        Me.GRIDBILL.OptionsView.ShowGroupPanel = False
        '
        'GLABELNO
        '
        Me.GLABELNO.Caption = "Sr No"
        Me.GLABELNO.FieldName = "LABELNO"
        Me.GLABELNO.ImageIndex = 1
        Me.GLABELNO.Name = "GLABELNO"
        Me.GLABELNO.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GLABELNO.Visible = True
        Me.GLABELNO.VisibleIndex = 0
        '
        'GDATE
        '
        Me.GDATE.Caption = "Date"
        Me.GDATE.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.GDATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GDATE.FieldName = "DATE"
        Me.GDATE.Name = "GDATE"
        Me.GDATE.Visible = True
        Me.GDATE.VisibleIndex = 1
        Me.GDATE.Width = 80
        '
        'GITEMNAME
        '
        Me.GITEMNAME.Caption = "Item Name"
        Me.GITEMNAME.FieldName = "ITEMNAME"
        Me.GITEMNAME.Name = "GITEMNAME"
        Me.GITEMNAME.Visible = True
        Me.GITEMNAME.VisibleIndex = 2
        Me.GITEMNAME.Width = 200
        '
        'GPCS
        '
        Me.GPCS.Caption = "Pcs"
        Me.GPCS.DisplayFormat.FormatString = "0"
        Me.GPCS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GPCS.FieldName = "PCS"
        Me.GPCS.Name = "GPCS"
        Me.GPCS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GPCS.Visible = True
        Me.GPCS.VisibleIndex = 3
        '
        'GGROSSWT
        '
        Me.GGROSSWT.Caption = "Gross Wt"
        Me.GGROSSWT.DisplayFormat.FormatString = "0.000"
        Me.GGROSSWT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GGROSSWT.FieldName = "GROSSWT"
        Me.GGROSSWT.Name = "GGROSSWT"
        Me.GGROSSWT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GGROSSWT.Visible = True
        Me.GGROSSWT.VisibleIndex = 4
        Me.GGROSSWT.Width = 85
        '
        'GPEARLWT
        '
        Me.GPEARLWT.Caption = "Moti Wt"
        Me.GPEARLWT.DisplayFormat.FormatString = "0.000"
        Me.GPEARLWT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GPEARLWT.FieldName = "PEARLWT"
        Me.GPEARLWT.Name = "GPEARLWT"
        Me.GPEARLWT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GPEARLWT.Visible = True
        Me.GPEARLWT.VisibleIndex = 5
        Me.GPEARLWT.Width = 85
        '
        'GSTONEWT
        '
        Me.GSTONEWT.Caption = "Stone Wt"
        Me.GSTONEWT.DisplayFormat.FormatString = "0.000"
        Me.GSTONEWT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GSTONEWT.FieldName = "STONEWT"
        Me.GSTONEWT.Name = "GSTONEWT"
        Me.GSTONEWT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GSTONEWT.Visible = True
        Me.GSTONEWT.VisibleIndex = 6
        Me.GSTONEWT.Width = 85
        '
        'GKUNDANWT
        '
        Me.GKUNDANWT.Caption = "Cz Wt"
        Me.GKUNDANWT.DisplayFormat.FormatString = "0.000"
        Me.GKUNDANWT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GKUNDANWT.FieldName = "KUNDANWT"
        Me.GKUNDANWT.Name = "GKUNDANWT"
        Me.GKUNDANWT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GKUNDANWT.Visible = True
        Me.GKUNDANWT.VisibleIndex = 7
        Me.GKUNDANWT.Width = 85
        '
        'GLESSWT
        '
        Me.GLESSWT.Caption = "Less Wt"
        Me.GLESSWT.DisplayFormat.FormatString = "0.000"
        Me.GLESSWT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GLESSWT.FieldName = "LESSWT"
        Me.GLESSWT.Name = "GLESSWT"
        Me.GLESSWT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GLESSWT.Visible = True
        Me.GLESSWT.VisibleIndex = 8
        Me.GLESSWT.Width = 85
        '
        'GNETTWT
        '
        Me.GNETTWT.Caption = "Nett Wt"
        Me.GNETTWT.DisplayFormat.FormatString = "0.000"
        Me.GNETTWT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GNETTWT.FieldName = "NETTWT"
        Me.GNETTWT.Name = "GNETTWT"
        Me.GNETTWT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GNETTWT.Visible = True
        Me.GNETTWT.VisibleIndex = 9
        Me.GNETTWT.Width = 85
        '
        'GPURITY
        '
        Me.GPURITY.Caption = "Purity"
        Me.GPURITY.DisplayFormat.FormatString = "0.00"
        Me.GPURITY.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GPURITY.FieldName = "PURITY"
        Me.GPURITY.Name = "GPURITY"
        Me.GPURITY.Visible = True
        Me.GPURITY.VisibleIndex = 10
        Me.GPURITY.Width = 85
        '
        'GFINEWT
        '
        Me.GFINEWT.Caption = "Fine Wt"
        Me.GFINEWT.DisplayFormat.FormatString = "0.000"
        Me.GFINEWT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GFINEWT.FieldName = "FINEWT"
        Me.GFINEWT.Name = "GFINEWT"
        Me.GFINEWT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GFINEWT.Visible = True
        Me.GFINEWT.VisibleIndex = 11
        Me.GFINEWT.Width = 85
        '
        'GREMARKS
        '
        Me.GREMARKS.Caption = "Remarks"
        Me.GREMARKS.FieldName = "REMARKS"
        Me.GREMARKS.Name = "GREMARKS"
        Me.GREMARKS.Visible = True
        Me.GREMARKS.VisibleIndex = 12
        Me.GREMARKS.Width = 150
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.toolStripSeparator, Me.ExcelExport, Me.ToolStripSeparator2, Me.TOOLREFRESH, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1234, 25)
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
        'TOOLREFRESH
        '
        Me.TOOLREFRESH.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TOOLREFRESH.Image = Global.Magic_Gold.My.Resources.Resources.refreshimage
        Me.TOOLREFRESH.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TOOLREFRESH.Name = "TOOLREFRESH"
        Me.TOOLREFRESH.Size = New System.Drawing.Size(23, 22)
        Me.TOOLREFRESH.Text = "ToolStripButton2"
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
        Me.lbl.Size = New System.Drawing.Size(143, 14)
        Me.lbl.TabIndex = 319
        Me.lbl.Text = "Select an Entry to Change"
        '
        'LabellingDetails
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1234, 581)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "LabellingDetails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Labelling Details"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.griddetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GRIDBILL, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents CMDOK As Button
    Friend WithEvents cmdcancel As Button
    Friend WithEvents griddetails As DevExpress.XtraGrid.GridControl
    Friend WithEvents GRIDBILL As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GLABELNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GITEMNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPCS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GGROSSWT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GLESSWT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GNETTWT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPURITY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GFINEWT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GREMARKS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ToolStripButton1 As ToolStripButton
    Friend WithEvents toolStripSeparator As ToolStripSeparator
    Friend WithEvents ExcelExport As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents TOOLREFRESH As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents lbl As Label
    Friend WithEvents GPEARLWT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSTONEWT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GKUNDANWT As DevExpress.XtraGrid.Columns.GridColumn
End Class
