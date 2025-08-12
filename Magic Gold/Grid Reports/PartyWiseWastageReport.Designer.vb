<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PartyWiseWastageReport
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
        Me.gridStock = New DevExpress.XtraGrid.GridControl
        Me.GRIDDETAILS = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GNAME = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GJAMAWT = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GTOTALJAMA = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GISSUEWT = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GTOTALISSUE = New DevExpress.XtraGrid.Columns.GridColumn
        Me.CMBTOUCHNAME = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox
        Me.cmdexit = New System.Windows.Forms.Button
        CType(Me.gridStock, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GRIDDETAILS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CMBTOUCHNAME, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gridStock
        '
        Me.gridStock.EmbeddedNavigator.Appearance.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridStock.EmbeddedNavigator.Appearance.Options.UseFont = True
        Me.gridStock.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridStock.Location = New System.Drawing.Point(22, 12)
        Me.gridStock.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridStock.MainView = Me.GRIDDETAILS
        Me.gridStock.Name = "gridStock"
        Me.gridStock.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.CMBTOUCHNAME})
        Me.gridStock.Size = New System.Drawing.Size(588, 510)
        Me.gridStock.TabIndex = 483
        Me.gridStock.TabStop = False
        Me.gridStock.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GRIDDETAILS})
        '
        'GRIDDETAILS
        '
        Me.GRIDDETAILS.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.GRIDDETAILS.Appearance.ColumnFilterButton.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.GRIDDETAILS.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.GRIDDETAILS.Appearance.ColumnFilterButton.ForeColor = System.Drawing.Color.Black
        Me.GRIDDETAILS.Appearance.ColumnFilterButton.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.GRIDDETAILS.Appearance.ColumnFilterButton.Options.UseBackColor = True
        Me.GRIDDETAILS.Appearance.ColumnFilterButton.Options.UseBorderColor = True
        Me.GRIDDETAILS.Appearance.ColumnFilterButton.Options.UseForeColor = True
        Me.GRIDDETAILS.Appearance.ColumnFilterButtonActive.BackColor = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GRIDDETAILS.Appearance.ColumnFilterButtonActive.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(154, Byte), Integer), CType(CType(190, Byte), Integer), CType(CType(243, Byte), Integer))
        Me.GRIDDETAILS.Appearance.ColumnFilterButtonActive.BorderColor = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GRIDDETAILS.Appearance.ColumnFilterButtonActive.ForeColor = System.Drawing.Color.Black
        Me.GRIDDETAILS.Appearance.ColumnFilterButtonActive.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.GRIDDETAILS.Appearance.ColumnFilterButtonActive.Options.UseBackColor = True
        Me.GRIDDETAILS.Appearance.ColumnFilterButtonActive.Options.UseBorderColor = True
        Me.GRIDDETAILS.Appearance.ColumnFilterButtonActive.Options.UseForeColor = True
        Me.GRIDDETAILS.Appearance.Empty.BackColor = System.Drawing.Color.White
        Me.GRIDDETAILS.Appearance.Empty.Options.UseBackColor = True
        Me.GRIDDETAILS.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.GRIDDETAILS.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black
        Me.GRIDDETAILS.Appearance.EvenRow.Options.UseBackColor = True
        Me.GRIDDETAILS.Appearance.EvenRow.Options.UseForeColor = True
        Me.GRIDDETAILS.Appearance.FilterCloseButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.GRIDDETAILS.Appearance.FilterCloseButton.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.GRIDDETAILS.Appearance.FilterCloseButton.BorderColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.GRIDDETAILS.Appearance.FilterCloseButton.ForeColor = System.Drawing.Color.Black
        Me.GRIDDETAILS.Appearance.FilterCloseButton.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.GRIDDETAILS.Appearance.FilterCloseButton.Options.UseBackColor = True
        Me.GRIDDETAILS.Appearance.FilterCloseButton.Options.UseBorderColor = True
        Me.GRIDDETAILS.Appearance.FilterCloseButton.Options.UseForeColor = True
        Me.GRIDDETAILS.Appearance.FilterPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(62, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.GRIDDETAILS.Appearance.FilterPanel.ForeColor = System.Drawing.Color.White
        Me.GRIDDETAILS.Appearance.FilterPanel.Options.UseBackColor = True
        Me.GRIDDETAILS.Appearance.FilterPanel.Options.UseForeColor = True
        Me.GRIDDETAILS.Appearance.FixedLine.BackColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(97, Byte), Integer), CType(CType(156, Byte), Integer))
        Me.GRIDDETAILS.Appearance.FixedLine.Options.UseBackColor = True
        Me.GRIDDETAILS.Appearance.FocusedCell.BackColor = System.Drawing.Color.White
        Me.GRIDDETAILS.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black
        Me.GRIDDETAILS.Appearance.FocusedCell.Options.UseBackColor = True
        Me.GRIDDETAILS.Appearance.FocusedCell.Options.UseForeColor = True
        Me.GRIDDETAILS.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.GRIDDETAILS.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White
        Me.GRIDDETAILS.Appearance.FocusedRow.Options.UseBackColor = True
        Me.GRIDDETAILS.Appearance.FocusedRow.Options.UseForeColor = True
        Me.GRIDDETAILS.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.GRIDDETAILS.Appearance.FooterPanel.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.GRIDDETAILS.Appearance.FooterPanel.BorderColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.GRIDDETAILS.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Black
        Me.GRIDDETAILS.Appearance.FooterPanel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.GRIDDETAILS.Appearance.FooterPanel.Options.UseBackColor = True
        Me.GRIDDETAILS.Appearance.FooterPanel.Options.UseBorderColor = True
        Me.GRIDDETAILS.Appearance.FooterPanel.Options.UseForeColor = True
        Me.GRIDDETAILS.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.GRIDDETAILS.Appearance.GroupButton.BorderColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.GRIDDETAILS.Appearance.GroupButton.ForeColor = System.Drawing.Color.Black
        Me.GRIDDETAILS.Appearance.GroupButton.Options.UseBackColor = True
        Me.GRIDDETAILS.Appearance.GroupButton.Options.UseBorderColor = True
        Me.GRIDDETAILS.Appearance.GroupButton.Options.UseForeColor = True
        Me.GRIDDETAILS.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.GRIDDETAILS.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.GRIDDETAILS.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Black
        Me.GRIDDETAILS.Appearance.GroupFooter.Options.UseBackColor = True
        Me.GRIDDETAILS.Appearance.GroupFooter.Options.UseBorderColor = True
        Me.GRIDDETAILS.Appearance.GroupFooter.Options.UseForeColor = True
        Me.GRIDDETAILS.Appearance.GroupPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(62, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.GRIDDETAILS.Appearance.GroupPanel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.GRIDDETAILS.Appearance.GroupPanel.Options.UseBackColor = True
        Me.GRIDDETAILS.Appearance.GroupPanel.Options.UseForeColor = True
        Me.GRIDDETAILS.Appearance.GroupRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.GRIDDETAILS.Appearance.GroupRow.BorderColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.GRIDDETAILS.Appearance.GroupRow.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.GRIDDETAILS.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black
        Me.GRIDDETAILS.Appearance.GroupRow.Options.UseBackColor = True
        Me.GRIDDETAILS.Appearance.GroupRow.Options.UseBorderColor = True
        Me.GRIDDETAILS.Appearance.GroupRow.Options.UseFont = True
        Me.GRIDDETAILS.Appearance.GroupRow.Options.UseForeColor = True
        Me.GRIDDETAILS.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.GRIDDETAILS.Appearance.HeaderPanel.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.GRIDDETAILS.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.GRIDDETAILS.Appearance.HeaderPanel.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.GRIDDETAILS.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black
        Me.GRIDDETAILS.Appearance.HeaderPanel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.GRIDDETAILS.Appearance.HeaderPanel.Options.UseBackColor = True
        Me.GRIDDETAILS.Appearance.HeaderPanel.Options.UseBorderColor = True
        Me.GRIDDETAILS.Appearance.HeaderPanel.Options.UseFont = True
        Me.GRIDDETAILS.Appearance.HeaderPanel.Options.UseForeColor = True
        Me.GRIDDETAILS.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(106, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.GRIDDETAILS.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.GRIDDETAILS.Appearance.HideSelectionRow.Options.UseBackColor = True
        Me.GRIDDETAILS.Appearance.HideSelectionRow.Options.UseForeColor = True
        Me.GRIDDETAILS.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(CType(CType(99, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.GRIDDETAILS.Appearance.HorzLine.Options.UseBackColor = True
        Me.GRIDDETAILS.Appearance.OddRow.BackColor = System.Drawing.Color.White
        Me.GRIDDETAILS.Appearance.OddRow.ForeColor = System.Drawing.Color.Black
        Me.GRIDDETAILS.Appearance.OddRow.Options.UseBackColor = True
        Me.GRIDDETAILS.Appearance.OddRow.Options.UseForeColor = True
        Me.GRIDDETAILS.Appearance.Preview.BackColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GRIDDETAILS.Appearance.Preview.ForeColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.GRIDDETAILS.Appearance.Preview.Options.UseBackColor = True
        Me.GRIDDETAILS.Appearance.Preview.Options.UseForeColor = True
        Me.GRIDDETAILS.Appearance.Row.BackColor = System.Drawing.Color.White
        Me.GRIDDETAILS.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.GRIDDETAILS.Appearance.Row.ForeColor = System.Drawing.Color.Black
        Me.GRIDDETAILS.Appearance.Row.Options.UseBackColor = True
        Me.GRIDDETAILS.Appearance.Row.Options.UseFont = True
        Me.GRIDDETAILS.Appearance.Row.Options.UseForeColor = True
        Me.GRIDDETAILS.Appearance.RowSeparator.BackColor = System.Drawing.Color.White
        Me.GRIDDETAILS.Appearance.RowSeparator.Options.UseBackColor = True
        Me.GRIDDETAILS.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(126, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.GRIDDETAILS.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White
        Me.GRIDDETAILS.Appearance.SelectedRow.Options.UseBackColor = True
        Me.GRIDDETAILS.Appearance.SelectedRow.Options.UseForeColor = True
        Me.GRIDDETAILS.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(CType(CType(99, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.GRIDDETAILS.Appearance.VertLine.Options.UseBackColor = True
        Me.GRIDDETAILS.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GNAME, Me.GJAMAWT, Me.GTOTALJAMA, Me.GISSUEWT, Me.GTOTALISSUE})
        Me.GRIDDETAILS.GridControl = Me.gridStock
        Me.GRIDDETAILS.Name = "GRIDDETAILS"
        Me.GRIDDETAILS.OptionsBehavior.AllowIncrementalSearch = True
        Me.GRIDDETAILS.OptionsBehavior.Editable = False
        Me.GRIDDETAILS.OptionsBehavior.SummariesIgnoreNullValues = True
        Me.GRIDDETAILS.OptionsCustomization.AllowGroup = False
        Me.GRIDDETAILS.OptionsMenu.EnableColumnMenu = False
        Me.GRIDDETAILS.OptionsMenu.EnableGroupPanelMenu = False
        Me.GRIDDETAILS.OptionsMenu.ShowGroupSortSummaryItems = False
        Me.GRIDDETAILS.OptionsView.ColumnAutoWidth = False
        Me.GRIDDETAILS.OptionsView.EnableAppearanceEvenRow = True
        Me.GRIDDETAILS.OptionsView.EnableAppearanceOddRow = True
        Me.GRIDDETAILS.OptionsView.ShowAutoFilterRow = True
        Me.GRIDDETAILS.OptionsView.ShowFooter = True
        Me.GRIDDETAILS.OptionsView.ShowGroupPanel = False
        '
        'GNAME
        '
        Me.GNAME.Caption = "Party Name"
        Me.GNAME.FieldName = "NAME"
        Me.GNAME.Name = "GNAME"
        Me.GNAME.Visible = True
        Me.GNAME.VisibleIndex = 0
        Me.GNAME.Width = 200
        '
        'GJAMAWT
        '
        Me.GJAMAWT.Caption = "Jama Wt"
        Me.GJAMAWT.DisplayFormat.FormatString = "0.000"
        Me.GJAMAWT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GJAMAWT.FieldName = "JAMAWASTAGEWT"
        Me.GJAMAWT.Name = "GJAMAWT"
        Me.GJAMAWT.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Me.GJAMAWT.Visible = True
        Me.GJAMAWT.VisibleIndex = 1
        Me.GJAMAWT.Width = 85
        '
        'GTOTALJAMA
        '
        Me.GTOTALJAMA.Caption = "Total Jama"
        Me.GTOTALJAMA.DisplayFormat.FormatString = "0.000"
        Me.GTOTALJAMA.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GTOTALJAMA.FieldName = "TOTALJAMA"
        Me.GTOTALJAMA.Name = "GTOTALJAMA"
        Me.GTOTALJAMA.OptionsColumn.AllowEdit = False
        Me.GTOTALJAMA.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Me.GTOTALJAMA.Visible = True
        Me.GTOTALJAMA.VisibleIndex = 2
        Me.GTOTALJAMA.Width = 85
        '
        'GISSUEWT
        '
        Me.GISSUEWT.Caption = "Issue Wt"
        Me.GISSUEWT.DisplayFormat.FormatString = "0.000"
        Me.GISSUEWT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GISSUEWT.FieldName = "ISSUEWASTAGEWT"
        Me.GISSUEWT.Name = "GISSUEWT"
        Me.GISSUEWT.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Me.GISSUEWT.Visible = True
        Me.GISSUEWT.VisibleIndex = 3
        Me.GISSUEWT.Width = 85
        '
        'GTOTALISSUE
        '
        Me.GTOTALISSUE.Caption = "Total Issue"
        Me.GTOTALISSUE.DisplayFormat.FormatString = "0.000"
        Me.GTOTALISSUE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GTOTALISSUE.FieldName = "TOTALISSUE"
        Me.GTOTALISSUE.Name = "GTOTALISSUE"
        Me.GTOTALISSUE.OptionsColumn.AllowEdit = False
        Me.GTOTALISSUE.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Me.GTOTALISSUE.Visible = True
        Me.GTOTALISSUE.VisibleIndex = 4
        Me.GTOTALISSUE.Width = 85
        '
        'CMBTOUCHNAME
        '
        Me.CMBTOUCHNAME.AutoHeight = False
        Me.CMBTOUCHNAME.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CMBTOUCHNAME.Name = "CMBTOUCHNAME"
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.Black
        Me.cmdexit.Location = New System.Drawing.Point(276, 528)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 28)
        Me.cmdexit.TabIndex = 485
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'PartyWiseWastageReport
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(632, 562)
        Me.Controls.Add(Me.cmdexit)
        Me.Controls.Add(Me.gridStock)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "PartyWiseWastageReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Party Wise Wastage Report"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.gridStock, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GRIDDETAILS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CMBTOUCHNAME, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents gridStock As DevExpress.XtraGrid.GridControl
    Friend WithEvents GRIDDETAILS As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTOTALJAMA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTOTALISSUE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CMBTOUCHNAME As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents GJAMAWT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GISSUEWT As DevExpress.XtraGrid.Columns.GridColumn
End Class
