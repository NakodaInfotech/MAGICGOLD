<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MeltingDetails
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MeltingDetails))
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.newarea = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.PrintToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.lbl = New System.Windows.Forms.Label()
        Me.cmdok = New System.Windows.Forms.Button()
        Me.griddetails = New DevExpress.XtraGrid.GridControl()
        Me.GRIDBILL = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GLOTNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GREQMELTING = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTOTALGROSSWT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GALLOYWT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTOTALWT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GOUTPUTWT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GLOSSWT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GMFG = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GREFNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GREMARKS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.griddetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GRIDBILL, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.Black
        Me.cmdexit.Location = New System.Drawing.Point(562, 562)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 28)
        Me.cmdexit.TabIndex = 299
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.newarea, Me.ToolStripSeparator1, Me.PrintToolStripButton})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1119, 25)
        Me.ToolStrip1.TabIndex = 302
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'newarea
        '
        Me.newarea.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.newarea.Image = Global.Magic_Gold.My.Resources.Resources.Be_Navigator
        Me.newarea.Name = "newarea"
        Me.newarea.Size = New System.Drawing.Size(71, 22)
        Me.newarea.Text = "&Add New"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'PrintToolStripButton
        '
        Me.PrintToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PrintToolStripButton.Image = CType(resources.GetObject("PrintToolStripButton.Image"), System.Drawing.Image)
        Me.PrintToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PrintToolStripButton.Name = "PrintToolStripButton"
        Me.PrintToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.PrintToolStripButton.Text = "&Print"
        '
        'lbl
        '
        Me.lbl.AutoSize = True
        Me.lbl.BackColor = System.Drawing.Color.Transparent
        Me.lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbl.Location = New System.Drawing.Point(12, 36)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(154, 25)
        Me.lbl.TabIndex = 301
        Me.lbl.Text = "Melting Details"
        '
        'cmdok
        '
        Me.cmdok.BackColor = System.Drawing.Color.Transparent
        Me.cmdok.FlatAppearance.BorderSize = 0
        Me.cmdok.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdok.ForeColor = System.Drawing.Color.Black
        Me.cmdok.Location = New System.Drawing.Point(476, 562)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(80, 28)
        Me.cmdok.TabIndex = 298
        Me.cmdok.Text = "&Ok"
        Me.cmdok.UseVisualStyleBackColor = False
        '
        'griddetails
        '
        Me.griddetails.Location = New System.Drawing.Point(15, 69)
        Me.griddetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.griddetails.MainView = Me.GRIDBILL
        Me.griddetails.Name = "griddetails"
        Me.griddetails.Size = New System.Drawing.Size(1089, 487)
        Me.griddetails.TabIndex = 316
        Me.griddetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GRIDBILL})
        '
        'GRIDBILL
        '
        Me.GRIDBILL.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRIDBILL.Appearance.Row.Options.UseFont = True
        Me.GRIDBILL.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GLOTNO, Me.GDATE, Me.GREQMELTING, Me.GTOTALGROSSWT, Me.GALLOYWT, Me.GTOTALWT, Me.GOUTPUTWT, Me.GLOSSWT, Me.GMFG, Me.GREFNO, Me.GREMARKS})
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
        'GLOTNO
        '
        Me.GLOTNO.Caption = "Lot No"
        Me.GLOTNO.FieldName = "LOTNO"
        Me.GLOTNO.Name = "GLOTNO"
        Me.GLOTNO.Visible = True
        Me.GLOTNO.VisibleIndex = 0
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
        '
        'GREQMELTING
        '
        Me.GREQMELTING.Caption = "Req Melting"
        Me.GREQMELTING.DisplayFormat.FormatString = "0.00"
        Me.GREQMELTING.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GREQMELTING.FieldName = "REQMELTING"
        Me.GREQMELTING.Name = "GREQMELTING"
        Me.GREQMELTING.Visible = True
        Me.GREQMELTING.VisibleIndex = 2
        '
        'GTOTALGROSSWT
        '
        Me.GTOTALGROSSWT.Caption = "Total Gross Wt"
        Me.GTOTALGROSSWT.DisplayFormat.FormatString = "0.000"
        Me.GTOTALGROSSWT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GTOTALGROSSWT.FieldName = "TOTALGROSSWT"
        Me.GTOTALGROSSWT.Name = "GTOTALGROSSWT"
        Me.GTOTALGROSSWT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TOTALGROSSWT", "{0:0.000}")})
        Me.GTOTALGROSSWT.Visible = True
        Me.GTOTALGROSSWT.VisibleIndex = 3
        Me.GTOTALGROSSWT.Width = 100
        '
        'GALLOYWT
        '
        Me.GALLOYWT.Caption = "Alloy Wt"
        Me.GALLOYWT.DisplayFormat.FormatString = "0.000"
        Me.GALLOYWT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GALLOYWT.FieldName = "ALLOYWT"
        Me.GALLOYWT.Name = "GALLOYWT"
        Me.GALLOYWT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ALLOYWT", "{0:0.000}")})
        Me.GALLOYWT.Visible = True
        Me.GALLOYWT.VisibleIndex = 4
        Me.GALLOYWT.Width = 85
        '
        'GTOTALWT
        '
        Me.GTOTALWT.Caption = "Total Wt"
        Me.GTOTALWT.DisplayFormat.FormatString = "0.000"
        Me.GTOTALWT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GTOTALWT.FieldName = "TOTALWT"
        Me.GTOTALWT.Name = "GTOTALWT"
        Me.GTOTALWT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TOTALWT", "{0:0.000}")})
        Me.GTOTALWT.Visible = True
        Me.GTOTALWT.VisibleIndex = 5
        Me.GTOTALWT.Width = 100
        '
        'GOUTPUTWT
        '
        Me.GOUTPUTWT.Caption = "Output Wt"
        Me.GOUTPUTWT.DisplayFormat.FormatString = "0.000"
        Me.GOUTPUTWT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GOUTPUTWT.FieldName = "OUTPUTWT"
        Me.GOUTPUTWT.Name = "GOUTPUTWT"
        Me.GOUTPUTWT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "OUTPUTWT", "{0:0.000}")})
        Me.GOUTPUTWT.Visible = True
        Me.GOUTPUTWT.VisibleIndex = 6
        Me.GOUTPUTWT.Width = 100
        '
        'GLOSSWT
        '
        Me.GLOSSWT.Caption = "Loss Wt"
        Me.GLOSSWT.DisplayFormat.FormatString = "0.000"
        Me.GLOSSWT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GLOSSWT.FieldName = "LOSSWT"
        Me.GLOSSWT.Name = "GLOSSWT"
        Me.GLOSSWT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "LOSSWT", "{0:0.000}")})
        Me.GLOSSWT.Visible = True
        Me.GLOSSWT.VisibleIndex = 7
        Me.GLOSSWT.Width = 85
        '
        'GMFG
        '
        Me.GMFG.Caption = "Mfg"
        Me.GMFG.FieldName = "MFGDONE"
        Me.GMFG.Name = "GMFG"
        Me.GMFG.Visible = True
        Me.GMFG.VisibleIndex = 8
        Me.GMFG.Width = 65
        '
        'GREFNO
        '
        Me.GREFNO.Caption = "Ref No"
        Me.GREFNO.FieldName = "REFNO"
        Me.GREFNO.Name = "GREFNO"
        Me.GREFNO.Visible = True
        Me.GREFNO.VisibleIndex = 9
        '
        'GREMARKS
        '
        Me.GREMARKS.Caption = "Remarks"
        Me.GREMARKS.FieldName = "REMARKS"
        Me.GREMARKS.Name = "GREMARKS"
        Me.GREMARKS.Visible = True
        Me.GREMARKS.VisibleIndex = 10
        Me.GREMARKS.Width = 200
        '
        'MeltingDetails
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1119, 591)
        Me.Controls.Add(Me.griddetails)
        Me.Controls.Add(Me.cmdok)
        Me.Controls.Add(Me.cmdexit)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.lbl)
        Me.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "MeltingDetails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Melting Details"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.griddetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GRIDBILL, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents PrintToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents lbl As System.Windows.Forms.Label
    Friend WithEvents cmdok As System.Windows.Forms.Button
    Friend WithEvents newarea As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents griddetails As DevExpress.XtraGrid.GridControl
    Friend WithEvents GRIDBILL As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GLOTNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GREQMELTING As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTOTALGROSSWT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GALLOYWT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTOTALWT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GOUTPUTWT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GLOSSWT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GMFG As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GREFNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GREMARKS As DevExpress.XtraGrid.Columns.GridColumn
End Class
