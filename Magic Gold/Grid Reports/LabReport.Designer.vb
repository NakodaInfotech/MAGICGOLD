<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LabReport
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
        Me.gridStock = New DevExpress.XtraGrid.GridControl()
        Me.GRIDDETAILS = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GLOTNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPARTNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GREFNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GNARRATION = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GWT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GNETTWT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPARTYWT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTOUCHNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CMBTOUCHNAME = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.GISSDATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GRECDATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GMELTING = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GLAB = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPARTYREP = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GFACLAB = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GFACPARTY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GLABPARTY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GFACLABWTDIFF = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GFACPARTYWTDIFF = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GLABPARTYWTDIFF = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTYPE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.CMDOK = New System.Windows.Forms.Button()
        Me.RBPENDING = New System.Windows.Forms.RadioButton()
        Me.RBALL = New System.Windows.Forms.RadioButton()
        Me.PBEXCEL = New System.Windows.Forms.PictureBox()
        Me.TXTPURITY = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        CType(Me.gridStock, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GRIDDETAILS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CMBTOUCHNAME, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PBEXCEL, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gridStock
        '
        Me.gridStock.EmbeddedNavigator.Appearance.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridStock.EmbeddedNavigator.Appearance.Options.UseFont = True
        Me.gridStock.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridStock.Location = New System.Drawing.Point(13, 32)
        Me.gridStock.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridStock.MainView = Me.GRIDDETAILS
        Me.gridStock.Name = "gridStock"
        Me.gridStock.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.CMBTOUCHNAME})
        Me.gridStock.Size = New System.Drawing.Size(1036, 510)
        Me.gridStock.TabIndex = 482
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
        Me.GRIDDETAILS.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GLOTNO, Me.GPARTNO, Me.GDATE, Me.GREFNO, Me.GNARRATION, Me.GWT, Me.GNETTWT, Me.GPARTYWT, Me.GTOUCHNAME, Me.GISSDATE, Me.GRECDATE, Me.GMELTING, Me.GLAB, Me.GPARTYREP, Me.GFACLAB, Me.GFACPARTY, Me.GLABPARTY, Me.GFACLABWTDIFF, Me.GFACPARTYWTDIFF, Me.GLABPARTYWTDIFF, Me.GTYPE})
        Me.GRIDDETAILS.GridControl = Me.gridStock
        Me.GRIDDETAILS.Name = "GRIDDETAILS"
        Me.GRIDDETAILS.OptionsBehavior.AllowIncrementalSearch = True
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
        'GLOTNO
        '
        Me.GLOTNO.Caption = "Lot No"
        Me.GLOTNO.DisplayFormat.FormatString = "0"
        Me.GLOTNO.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GLOTNO.FieldName = "LOTNO"
        Me.GLOTNO.Name = "GLOTNO"
        Me.GLOTNO.OptionsColumn.AllowEdit = False
        Me.GLOTNO.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count)})
        Me.GLOTNO.Visible = True
        Me.GLOTNO.VisibleIndex = 0
        Me.GLOTNO.Width = 60
        '
        'GPARTNO
        '
        Me.GPARTNO.Caption = "Part No"
        Me.GPARTNO.FieldName = "PARTNO"
        Me.GPARTNO.Name = "GPARTNO"
        Me.GPARTNO.Visible = True
        Me.GPARTNO.VisibleIndex = 1
        Me.GPARTNO.Width = 55
        '
        'GDATE
        '
        Me.GDATE.Caption = "Date"
        Me.GDATE.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.GDATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GDATE.FieldName = "ADATE"
        Me.GDATE.Name = "GDATE"
        Me.GDATE.OptionsColumn.AllowEdit = False
        '
        'GREFNO
        '
        Me.GREFNO.Caption = "Status"
        Me.GREFNO.FieldName = "REFNO"
        Me.GREFNO.Name = "GREFNO"
        Me.GREFNO.OptionsColumn.AllowEdit = False
        Me.GREFNO.Visible = True
        Me.GREFNO.VisibleIndex = 2
        '
        'GNARRATION
        '
        Me.GNARRATION.Caption = "Narration"
        Me.GNARRATION.FieldName = "NARRATION"
        Me.GNARRATION.Name = "GNARRATION"
        Me.GNARRATION.Visible = True
        Me.GNARRATION.VisibleIndex = 3
        Me.GNARRATION.Width = 70
        '
        'GWT
        '
        Me.GWT.Caption = "Gross Wt."
        Me.GWT.DisplayFormat.FormatString = "0.000"
        Me.GWT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GWT.FieldName = "WT"
        Me.GWT.Name = "GWT"
        Me.GWT.OptionsColumn.AllowEdit = False
        Me.GWT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "WT", "{0:0.000}")})
        Me.GWT.Visible = True
        Me.GWT.VisibleIndex = 4
        Me.GWT.Width = 70
        '
        'GNETTWT
        '
        Me.GNETTWT.Caption = "Nett Wt"
        Me.GNETTWT.DisplayFormat.FormatString = "0.000"
        Me.GNETTWT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GNETTWT.FieldName = "NETTWT"
        Me.GNETTWT.Name = "GNETTWT"
        Me.GNETTWT.OptionsColumn.AllowEdit = False
        Me.GNETTWT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "NETTWT", "{0:0.000}")})
        Me.GNETTWT.Visible = True
        Me.GNETTWT.VisibleIndex = 5
        Me.GNETTWT.Width = 70
        '
        'GPARTYWT
        '
        Me.GPARTYWT.Caption = "Party Wt"
        Me.GPARTYWT.DisplayFormat.FormatString = "0.000"
        Me.GPARTYWT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GPARTYWT.FieldName = "PARTYWT"
        Me.GPARTYWT.Name = "GPARTYWT"
        Me.GPARTYWT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PARTYWT", "{0:0.000}")})
        Me.GPARTYWT.Visible = True
        Me.GPARTYWT.VisibleIndex = 6
        Me.GPARTYWT.Width = 70
        '
        'GTOUCHNAME
        '
        Me.GTOUCHNAME.Caption = "Touch Name"
        Me.GTOUCHNAME.ColumnEdit = Me.CMBTOUCHNAME
        Me.GTOUCHNAME.FieldName = "LEDGERNAME"
        Me.GTOUCHNAME.Name = "GTOUCHNAME"
        Me.GTOUCHNAME.Visible = True
        Me.GTOUCHNAME.VisibleIndex = 7
        Me.GTOUCHNAME.Width = 100
        '
        'CMBTOUCHNAME
        '
        Me.CMBTOUCHNAME.AutoHeight = False
        Me.CMBTOUCHNAME.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CMBTOUCHNAME.Name = "CMBTOUCHNAME"
        '
        'GISSDATE
        '
        Me.GISSDATE.Caption = "Iss Date"
        Me.GISSDATE.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.GISSDATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GISSDATE.FieldName = "ISSDATE"
        Me.GISSDATE.Name = "GISSDATE"
        Me.GISSDATE.Visible = True
        Me.GISSDATE.VisibleIndex = 8
        Me.GISSDATE.Width = 80
        '
        'GRECDATE
        '
        Me.GRECDATE.Caption = "Rec Date"
        Me.GRECDATE.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.GRECDATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GRECDATE.FieldName = "RECDATE"
        Me.GRECDATE.Name = "GRECDATE"
        Me.GRECDATE.Visible = True
        Me.GRECDATE.VisibleIndex = 9
        Me.GRECDATE.Width = 80
        '
        'GMELTING
        '
        Me.GMELTING.Caption = "Fact Rep"
        Me.GMELTING.DisplayFormat.FormatString = "0.00"
        Me.GMELTING.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GMELTING.FieldName = "MELTING"
        Me.GMELTING.Name = "GMELTING"
        Me.GMELTING.OptionsColumn.AllowEdit = False
        Me.GMELTING.Visible = True
        Me.GMELTING.VisibleIndex = 10
        Me.GMELTING.Width = 60
        '
        'GLAB
        '
        Me.GLAB.Caption = "Lab Rep"
        Me.GLAB.DisplayFormat.FormatString = "0.00"
        Me.GLAB.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GLAB.FieldName = "LABREP"
        Me.GLAB.Name = "GLAB"
        Me.GLAB.Visible = True
        Me.GLAB.VisibleIndex = 11
        Me.GLAB.Width = 60
        '
        'GPARTYREP
        '
        Me.GPARTYREP.Caption = "Party Rep"
        Me.GPARTYREP.DisplayFormat.FormatString = "0.00"
        Me.GPARTYREP.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GPARTYREP.FieldName = "PARTYREP"
        Me.GPARTYREP.Name = "GPARTYREP"
        Me.GPARTYREP.Visible = True
        Me.GPARTYREP.VisibleIndex = 12
        Me.GPARTYREP.Width = 60
        '
        'GFACLAB
        '
        Me.GFACLAB.Caption = "Fac / Lab Diff"
        Me.GFACLAB.DisplayFormat.FormatString = "0.00"
        Me.GFACLAB.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GFACLAB.FieldName = "FACLAB"
        Me.GFACLAB.Name = "GFACLAB"
        Me.GFACLAB.OptionsColumn.AllowEdit = False
        Me.GFACLAB.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "FACLAB", "{0:0.000}")})
        Me.GFACLAB.Visible = True
        Me.GFACLAB.VisibleIndex = 13
        Me.GFACLAB.Width = 60
        '
        'GFACPARTY
        '
        Me.GFACPARTY.Caption = "Fac / Party Diff"
        Me.GFACPARTY.DisplayFormat.FormatString = "0.00"
        Me.GFACPARTY.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GFACPARTY.FieldName = "FACPARTY"
        Me.GFACPARTY.Name = "GFACPARTY"
        Me.GFACPARTY.OptionsColumn.AllowEdit = False
        Me.GFACPARTY.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "FACPARTY", "{0:0.000}")})
        Me.GFACPARTY.Visible = True
        Me.GFACPARTY.VisibleIndex = 14
        Me.GFACPARTY.Width = 60
        '
        'GLABPARTY
        '
        Me.GLABPARTY.Caption = "Lab / Party Diff"
        Me.GLABPARTY.DisplayFormat.FormatString = "0.00"
        Me.GLABPARTY.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GLABPARTY.FieldName = "LABPARTY"
        Me.GLABPARTY.Name = "GLABPARTY"
        Me.GLABPARTY.OptionsColumn.AllowEdit = False
        Me.GLABPARTY.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "LABPARTY", "{0:0.000}")})
        Me.GLABPARTY.Visible = True
        Me.GLABPARTY.VisibleIndex = 15
        Me.GLABPARTY.Width = 60
        '
        'GFACLABWTDIFF
        '
        Me.GFACLABWTDIFF.Caption = "Fac / Lab Wt Diff"
        Me.GFACLABWTDIFF.DisplayFormat.FormatString = "0.000"
        Me.GFACLABWTDIFF.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GFACLABWTDIFF.FieldName = "FACLABWTDIFF"
        Me.GFACLABWTDIFF.Name = "GFACLABWTDIFF"
        Me.GFACLABWTDIFF.OptionsColumn.AllowEdit = False
        Me.GFACLABWTDIFF.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "FACLABWTDIFF", "{0:0.000}")})
        Me.GFACLABWTDIFF.Visible = True
        Me.GFACLABWTDIFF.VisibleIndex = 16
        Me.GFACLABWTDIFF.Width = 60
        '
        'GFACPARTYWTDIFF
        '
        Me.GFACPARTYWTDIFF.Caption = "Fac / Party Wt Diff"
        Me.GFACPARTYWTDIFF.DisplayFormat.FormatString = "0.000"
        Me.GFACPARTYWTDIFF.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GFACPARTYWTDIFF.FieldName = "FACPARTYWTDIFF"
        Me.GFACPARTYWTDIFF.Name = "GFACPARTYWTDIFF"
        Me.GFACPARTYWTDIFF.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "FACPARTYWTDIFF", "{0:0.000}")})
        Me.GFACPARTYWTDIFF.Visible = True
        Me.GFACPARTYWTDIFF.VisibleIndex = 17
        Me.GFACPARTYWTDIFF.Width = 60
        '
        'GLABPARTYWTDIFF
        '
        Me.GLABPARTYWTDIFF.Caption = "Lab / Party Wt Diff"
        Me.GLABPARTYWTDIFF.DisplayFormat.FormatString = "0.000"
        Me.GLABPARTYWTDIFF.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GLABPARTYWTDIFF.FieldName = "LABPARTYWTDIFF"
        Me.GLABPARTYWTDIFF.Name = "GLABPARTYWTDIFF"
        Me.GLABPARTYWTDIFF.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "LABPARTYWTDIFF", "{0:0.000}")})
        Me.GLABPARTYWTDIFF.Visible = True
        Me.GLABPARTYWTDIFF.VisibleIndex = 18
        Me.GLABPARTYWTDIFF.Width = 60
        '
        'GTYPE
        '
        Me.GTYPE.Caption = "Type"
        Me.GTYPE.FieldName = "TYPE"
        Me.GTYPE.Name = "GTYPE"
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdexit.Image = Global.Magic_Gold.My.Resources.Resources._Exit
        Me.cmdexit.Location = New System.Drawing.Point(534, 547)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(72, 25)
        Me.cmdexit.TabIndex = 483
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'CMDOK
        '
        Me.CMDOK.BackColor = System.Drawing.Color.Transparent
        Me.CMDOK.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDOK.FlatAppearance.BorderSize = 0
        Me.CMDOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CMDOK.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDOK.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CMDOK.Image = Global.Magic_Gold.My.Resources.Resources.Save
        Me.CMDOK.Location = New System.Drawing.Point(456, 547)
        Me.CMDOK.Name = "CMDOK"
        Me.CMDOK.Size = New System.Drawing.Size(72, 25)
        Me.CMDOK.TabIndex = 484
        Me.CMDOK.UseVisualStyleBackColor = False
        '
        'RBPENDING
        '
        Me.RBPENDING.AutoSize = True
        Me.RBPENDING.Checked = True
        Me.RBPENDING.Location = New System.Drawing.Point(61, 8)
        Me.RBPENDING.Name = "RBPENDING"
        Me.RBPENDING.Size = New System.Drawing.Size(108, 19)
        Me.RBPENDING.TabIndex = 486
        Me.RBPENDING.TabStop = True
        Me.RBPENDING.Text = "Pending Report"
        Me.RBPENDING.UseVisualStyleBackColor = True
        '
        'RBALL
        '
        Me.RBALL.AutoSize = True
        Me.RBALL.Location = New System.Drawing.Point(15, 8)
        Me.RBALL.Name = "RBALL"
        Me.RBALL.Size = New System.Drawing.Size(40, 19)
        Me.RBALL.TabIndex = 485
        Me.RBALL.Text = "All"
        Me.RBALL.UseVisualStyleBackColor = True
        '
        'PBEXCEL
        '
        Me.PBEXCEL.BackColor = System.Drawing.Color.Transparent
        Me.PBEXCEL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PBEXCEL.Image = Global.Magic_Gold.My.Resources.Resources.Excel_icon
        Me.PBEXCEL.Location = New System.Drawing.Point(175, 3)
        Me.PBEXCEL.Name = "PBEXCEL"
        Me.PBEXCEL.Size = New System.Drawing.Size(25, 25)
        Me.PBEXCEL.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PBEXCEL.TabIndex = 686
        Me.PBEXCEL.TabStop = False
        '
        'TXTPURITY
        '
        Me.TXTPURITY.BackColor = System.Drawing.Color.Linen
        Me.TXTPURITY.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTPURITY.Location = New System.Drawing.Point(259, 547)
        Me.TXTPURITY.Name = "TXTPURITY"
        Me.TXTPURITY.ReadOnly = True
        Me.TXTPURITY.Size = New System.Drawing.Size(50, 22)
        Me.TXTPURITY.TabIndex = 688
        Me.TXTPURITY.TabStop = False
        Me.TXTPURITY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(220, 551)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(37, 14)
        Me.Label5.TabIndex = 687
        Me.Label5.Text = "Purity"
        '
        'LabReport
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1063, 575)
        Me.Controls.Add(Me.TXTPURITY)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.PBEXCEL)
        Me.Controls.Add(Me.RBPENDING)
        Me.Controls.Add(Me.RBALL)
        Me.Controls.Add(Me.CMDOK)
        Me.Controls.Add(Me.cmdexit)
        Me.Controls.Add(Me.gridStock)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "LabReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Lab Report"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.gridStock, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GRIDDETAILS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CMBTOUCHNAME, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PBEXCEL, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents gridStock As DevExpress.XtraGrid.GridControl
    Friend WithEvents GRIDDETAILS As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GLOTNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GWT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GMELTING As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents CMDOK As System.Windows.Forms.Button
    Friend WithEvents GLAB As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPARTYREP As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GFACLAB As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GFACPARTY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GLABPARTY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RBPENDING As System.Windows.Forms.RadioButton
    Friend WithEvents RBALL As System.Windows.Forms.RadioButton
    Friend WithEvents GREFNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GNETTWT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPARTYWT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GFACLABWTDIFF As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTYPE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTOUCHNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CMBTOUCHNAME As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents GISSDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GRECDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GFACPARTYWTDIFF As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GLABPARTYWTDIFF As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PBEXCEL As System.Windows.Forms.PictureBox
    Friend WithEvents GDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TXTPURITY As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GPARTNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GNARRATION As DevExpress.XtraGrid.Columns.GridColumn
End Class
