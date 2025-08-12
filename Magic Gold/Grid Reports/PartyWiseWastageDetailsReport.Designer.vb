<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PartyWiseWastageDetailsReport
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
        Me.GJAMADATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GJAMANAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GJAMAITEMNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GJAMAGROSSWT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GJAMAPURITY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GJAMAWASTAGE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GJAMANETTWT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GJAMAWASTAGEWT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CMBTOUCHNAME = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.GRIDISSUESTOCK = New DevExpress.XtraGrid.GridControl()
        Me.GRIDISSUEDETAILS = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GISSDATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GISSNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GISSITEMNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GISSGROSSWT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GISSPURITY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GISSWASTAGE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GISSNETTWT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GISSWASTAGEWT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemComboBox1 = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        CType(Me.gridStock, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GRIDDETAILS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CMBTOUCHNAME, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GRIDISSUESTOCK, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GRIDISSUEDETAILS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'gridStock
        '
        Me.gridStock.EmbeddedNavigator.Appearance.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridStock.EmbeddedNavigator.Appearance.Options.UseFont = True
        Me.gridStock.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridStock.Location = New System.Drawing.Point(3, 3)
        Me.gridStock.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridStock.MainView = Me.GRIDDETAILS
        Me.gridStock.Name = "gridStock"
        Me.gridStock.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.CMBTOUCHNAME})
        Me.gridStock.Size = New System.Drawing.Size(666, 510)
        Me.gridStock.TabIndex = 484
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
        Me.GRIDDETAILS.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GJAMADATE, Me.GJAMANAME, Me.GJAMAITEMNAME, Me.GJAMAGROSSWT, Me.GJAMAPURITY, Me.GJAMAWASTAGE, Me.GJAMANETTWT, Me.GJAMAWASTAGEWT})
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
        'GJAMADATE
        '
        Me.GJAMADATE.Caption = "Date"
        Me.GJAMADATE.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.GJAMADATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GJAMADATE.FieldName = "DATE"
        Me.GJAMADATE.Name = "GJAMADATE"
        Me.GJAMADATE.Visible = True
        Me.GJAMADATE.VisibleIndex = 0
        '
        'GJAMANAME
        '
        Me.GJAMANAME.Caption = "Party Name"
        Me.GJAMANAME.FieldName = "NAME"
        Me.GJAMANAME.Name = "GJAMANAME"
        Me.GJAMANAME.Visible = True
        Me.GJAMANAME.VisibleIndex = 1
        Me.GJAMANAME.Width = 120
        '
        'GJAMAITEMNAME
        '
        Me.GJAMAITEMNAME.Caption = "Item Code"
        Me.GJAMAITEMNAME.FieldName = "ITEMCODE"
        Me.GJAMAITEMNAME.Name = "GJAMAITEMNAME"
        Me.GJAMAITEMNAME.Visible = True
        Me.GJAMAITEMNAME.VisibleIndex = 2
        '
        'GJAMAGROSSWT
        '
        Me.GJAMAGROSSWT.Caption = "Gross Wt"
        Me.GJAMAGROSSWT.DisplayFormat.FormatString = "0.000"
        Me.GJAMAGROSSWT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GJAMAGROSSWT.FieldName = "GROSSWT"
        Me.GJAMAGROSSWT.Name = "GJAMAGROSSWT"
        Me.GJAMAGROSSWT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GJAMAGROSSWT.Visible = True
        Me.GJAMAGROSSWT.VisibleIndex = 3
        '
        'GJAMAPURITY
        '
        Me.GJAMAPURITY.Caption = "Purity"
        Me.GJAMAPURITY.DisplayFormat.FormatString = "0.00"
        Me.GJAMAPURITY.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GJAMAPURITY.FieldName = "PURITY"
        Me.GJAMAPURITY.Name = "GJAMAPURITY"
        Me.GJAMAPURITY.Visible = True
        Me.GJAMAPURITY.VisibleIndex = 4
        Me.GJAMAPURITY.Width = 55
        '
        'GJAMAWASTAGE
        '
        Me.GJAMAWASTAGE.Caption = "Wastage"
        Me.GJAMAWASTAGE.DisplayFormat.FormatString = "0.00"
        Me.GJAMAWASTAGE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GJAMAWASTAGE.FieldName = "WASTAGE"
        Me.GJAMAWASTAGE.Name = "GJAMAWASTAGE"
        Me.GJAMAWASTAGE.OptionsColumn.AllowEdit = False
        Me.GJAMAWASTAGE.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GJAMAWASTAGE.Visible = True
        Me.GJAMAWASTAGE.VisibleIndex = 5
        Me.GJAMAWASTAGE.Width = 65
        '
        'GJAMANETTWT
        '
        Me.GJAMANETTWT.Caption = "Nett Wt"
        Me.GJAMANETTWT.DisplayFormat.FormatString = "0.000"
        Me.GJAMANETTWT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GJAMANETTWT.FieldName = "NETTWT"
        Me.GJAMANETTWT.Name = "GJAMANETTWT"
        Me.GJAMANETTWT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GJAMANETTWT.Visible = True
        Me.GJAMANETTWT.VisibleIndex = 6
        '
        'GJAMAWASTAGEWT
        '
        Me.GJAMAWASTAGEWT.Caption = "Wast Wt"
        Me.GJAMAWASTAGEWT.DisplayFormat.FormatString = "0.000"
        Me.GJAMAWASTAGEWT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GJAMAWASTAGEWT.FieldName = "WASTAGEWT"
        Me.GJAMAWASTAGEWT.Name = "GJAMAWASTAGEWT"
        Me.GJAMAWASTAGEWT.OptionsColumn.AllowEdit = False
        Me.GJAMAWASTAGEWT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GJAMAWASTAGEWT.Visible = True
        Me.GJAMAWASTAGEWT.VisibleIndex = 7
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
        Me.cmdexit.Location = New System.Drawing.Point(527, 550)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 28)
        Me.cmdexit.TabIndex = 486
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'GRIDISSUESTOCK
        '
        Me.GRIDISSUESTOCK.EmbeddedNavigator.Appearance.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRIDISSUESTOCK.EmbeddedNavigator.Appearance.Options.UseFont = True
        Me.GRIDISSUESTOCK.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRIDISSUESTOCK.Location = New System.Drawing.Point(682, 3)
        Me.GRIDISSUESTOCK.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GRIDISSUESTOCK.MainView = Me.GRIDISSUEDETAILS
        Me.GRIDISSUESTOCK.Name = "GRIDISSUESTOCK"
        Me.GRIDISSUESTOCK.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemComboBox1})
        Me.GRIDISSUESTOCK.Size = New System.Drawing.Size(666, 510)
        Me.GRIDISSUESTOCK.TabIndex = 487
        Me.GRIDISSUESTOCK.TabStop = False
        Me.GRIDISSUESTOCK.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GRIDISSUEDETAILS})
        '
        'GRIDISSUEDETAILS
        '
        Me.GRIDISSUEDETAILS.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.GRIDISSUEDETAILS.Appearance.ColumnFilterButton.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.GRIDISSUEDETAILS.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.GRIDISSUEDETAILS.Appearance.ColumnFilterButton.ForeColor = System.Drawing.Color.Black
        Me.GRIDISSUEDETAILS.Appearance.ColumnFilterButton.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.GRIDISSUEDETAILS.Appearance.ColumnFilterButton.Options.UseBackColor = True
        Me.GRIDISSUEDETAILS.Appearance.ColumnFilterButton.Options.UseBorderColor = True
        Me.GRIDISSUEDETAILS.Appearance.ColumnFilterButton.Options.UseForeColor = True
        Me.GRIDISSUEDETAILS.Appearance.ColumnFilterButtonActive.BackColor = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GRIDISSUEDETAILS.Appearance.ColumnFilterButtonActive.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(154, Byte), Integer), CType(CType(190, Byte), Integer), CType(CType(243, Byte), Integer))
        Me.GRIDISSUEDETAILS.Appearance.ColumnFilterButtonActive.BorderColor = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GRIDISSUEDETAILS.Appearance.ColumnFilterButtonActive.ForeColor = System.Drawing.Color.Black
        Me.GRIDISSUEDETAILS.Appearance.ColumnFilterButtonActive.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.GRIDISSUEDETAILS.Appearance.ColumnFilterButtonActive.Options.UseBackColor = True
        Me.GRIDISSUEDETAILS.Appearance.ColumnFilterButtonActive.Options.UseBorderColor = True
        Me.GRIDISSUEDETAILS.Appearance.ColumnFilterButtonActive.Options.UseForeColor = True
        Me.GRIDISSUEDETAILS.Appearance.Empty.BackColor = System.Drawing.Color.White
        Me.GRIDISSUEDETAILS.Appearance.Empty.Options.UseBackColor = True
        Me.GRIDISSUEDETAILS.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.GRIDISSUEDETAILS.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black
        Me.GRIDISSUEDETAILS.Appearance.EvenRow.Options.UseBackColor = True
        Me.GRIDISSUEDETAILS.Appearance.EvenRow.Options.UseForeColor = True
        Me.GRIDISSUEDETAILS.Appearance.FilterCloseButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.GRIDISSUEDETAILS.Appearance.FilterCloseButton.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.GRIDISSUEDETAILS.Appearance.FilterCloseButton.BorderColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.GRIDISSUEDETAILS.Appearance.FilterCloseButton.ForeColor = System.Drawing.Color.Black
        Me.GRIDISSUEDETAILS.Appearance.FilterCloseButton.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.GRIDISSUEDETAILS.Appearance.FilterCloseButton.Options.UseBackColor = True
        Me.GRIDISSUEDETAILS.Appearance.FilterCloseButton.Options.UseBorderColor = True
        Me.GRIDISSUEDETAILS.Appearance.FilterCloseButton.Options.UseForeColor = True
        Me.GRIDISSUEDETAILS.Appearance.FilterPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(62, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.GRIDISSUEDETAILS.Appearance.FilterPanel.ForeColor = System.Drawing.Color.White
        Me.GRIDISSUEDETAILS.Appearance.FilterPanel.Options.UseBackColor = True
        Me.GRIDISSUEDETAILS.Appearance.FilterPanel.Options.UseForeColor = True
        Me.GRIDISSUEDETAILS.Appearance.FixedLine.BackColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(97, Byte), Integer), CType(CType(156, Byte), Integer))
        Me.GRIDISSUEDETAILS.Appearance.FixedLine.Options.UseBackColor = True
        Me.GRIDISSUEDETAILS.Appearance.FocusedCell.BackColor = System.Drawing.Color.White
        Me.GRIDISSUEDETAILS.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black
        Me.GRIDISSUEDETAILS.Appearance.FocusedCell.Options.UseBackColor = True
        Me.GRIDISSUEDETAILS.Appearance.FocusedCell.Options.UseForeColor = True
        Me.GRIDISSUEDETAILS.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.GRIDISSUEDETAILS.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White
        Me.GRIDISSUEDETAILS.Appearance.FocusedRow.Options.UseBackColor = True
        Me.GRIDISSUEDETAILS.Appearance.FocusedRow.Options.UseForeColor = True
        Me.GRIDISSUEDETAILS.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.GRIDISSUEDETAILS.Appearance.FooterPanel.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.GRIDISSUEDETAILS.Appearance.FooterPanel.BorderColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.GRIDISSUEDETAILS.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Black
        Me.GRIDISSUEDETAILS.Appearance.FooterPanel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.GRIDISSUEDETAILS.Appearance.FooterPanel.Options.UseBackColor = True
        Me.GRIDISSUEDETAILS.Appearance.FooterPanel.Options.UseBorderColor = True
        Me.GRIDISSUEDETAILS.Appearance.FooterPanel.Options.UseForeColor = True
        Me.GRIDISSUEDETAILS.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.GRIDISSUEDETAILS.Appearance.GroupButton.BorderColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.GRIDISSUEDETAILS.Appearance.GroupButton.ForeColor = System.Drawing.Color.Black
        Me.GRIDISSUEDETAILS.Appearance.GroupButton.Options.UseBackColor = True
        Me.GRIDISSUEDETAILS.Appearance.GroupButton.Options.UseBorderColor = True
        Me.GRIDISSUEDETAILS.Appearance.GroupButton.Options.UseForeColor = True
        Me.GRIDISSUEDETAILS.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.GRIDISSUEDETAILS.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.GRIDISSUEDETAILS.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Black
        Me.GRIDISSUEDETAILS.Appearance.GroupFooter.Options.UseBackColor = True
        Me.GRIDISSUEDETAILS.Appearance.GroupFooter.Options.UseBorderColor = True
        Me.GRIDISSUEDETAILS.Appearance.GroupFooter.Options.UseForeColor = True
        Me.GRIDISSUEDETAILS.Appearance.GroupPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(62, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.GRIDISSUEDETAILS.Appearance.GroupPanel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.GRIDISSUEDETAILS.Appearance.GroupPanel.Options.UseBackColor = True
        Me.GRIDISSUEDETAILS.Appearance.GroupPanel.Options.UseForeColor = True
        Me.GRIDISSUEDETAILS.Appearance.GroupRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.GRIDISSUEDETAILS.Appearance.GroupRow.BorderColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.GRIDISSUEDETAILS.Appearance.GroupRow.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.GRIDISSUEDETAILS.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black
        Me.GRIDISSUEDETAILS.Appearance.GroupRow.Options.UseBackColor = True
        Me.GRIDISSUEDETAILS.Appearance.GroupRow.Options.UseBorderColor = True
        Me.GRIDISSUEDETAILS.Appearance.GroupRow.Options.UseFont = True
        Me.GRIDISSUEDETAILS.Appearance.GroupRow.Options.UseForeColor = True
        Me.GRIDISSUEDETAILS.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.GRIDISSUEDETAILS.Appearance.HeaderPanel.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.GRIDISSUEDETAILS.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.GRIDISSUEDETAILS.Appearance.HeaderPanel.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.GRIDISSUEDETAILS.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black
        Me.GRIDISSUEDETAILS.Appearance.HeaderPanel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.GRIDISSUEDETAILS.Appearance.HeaderPanel.Options.UseBackColor = True
        Me.GRIDISSUEDETAILS.Appearance.HeaderPanel.Options.UseBorderColor = True
        Me.GRIDISSUEDETAILS.Appearance.HeaderPanel.Options.UseFont = True
        Me.GRIDISSUEDETAILS.Appearance.HeaderPanel.Options.UseForeColor = True
        Me.GRIDISSUEDETAILS.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(106, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.GRIDISSUEDETAILS.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.GRIDISSUEDETAILS.Appearance.HideSelectionRow.Options.UseBackColor = True
        Me.GRIDISSUEDETAILS.Appearance.HideSelectionRow.Options.UseForeColor = True
        Me.GRIDISSUEDETAILS.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(CType(CType(99, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.GRIDISSUEDETAILS.Appearance.HorzLine.Options.UseBackColor = True
        Me.GRIDISSUEDETAILS.Appearance.OddRow.BackColor = System.Drawing.Color.White
        Me.GRIDISSUEDETAILS.Appearance.OddRow.ForeColor = System.Drawing.Color.Black
        Me.GRIDISSUEDETAILS.Appearance.OddRow.Options.UseBackColor = True
        Me.GRIDISSUEDETAILS.Appearance.OddRow.Options.UseForeColor = True
        Me.GRIDISSUEDETAILS.Appearance.Preview.BackColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GRIDISSUEDETAILS.Appearance.Preview.ForeColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.GRIDISSUEDETAILS.Appearance.Preview.Options.UseBackColor = True
        Me.GRIDISSUEDETAILS.Appearance.Preview.Options.UseForeColor = True
        Me.GRIDISSUEDETAILS.Appearance.Row.BackColor = System.Drawing.Color.White
        Me.GRIDISSUEDETAILS.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.GRIDISSUEDETAILS.Appearance.Row.ForeColor = System.Drawing.Color.Black
        Me.GRIDISSUEDETAILS.Appearance.Row.Options.UseBackColor = True
        Me.GRIDISSUEDETAILS.Appearance.Row.Options.UseFont = True
        Me.GRIDISSUEDETAILS.Appearance.Row.Options.UseForeColor = True
        Me.GRIDISSUEDETAILS.Appearance.RowSeparator.BackColor = System.Drawing.Color.White
        Me.GRIDISSUEDETAILS.Appearance.RowSeparator.Options.UseBackColor = True
        Me.GRIDISSUEDETAILS.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(126, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.GRIDISSUEDETAILS.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White
        Me.GRIDISSUEDETAILS.Appearance.SelectedRow.Options.UseBackColor = True
        Me.GRIDISSUEDETAILS.Appearance.SelectedRow.Options.UseForeColor = True
        Me.GRIDISSUEDETAILS.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(CType(CType(99, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.GRIDISSUEDETAILS.Appearance.VertLine.Options.UseBackColor = True
        Me.GRIDISSUEDETAILS.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GISSDATE, Me.GISSNAME, Me.GISSITEMNAME, Me.GISSGROSSWT, Me.GISSPURITY, Me.GISSWASTAGE, Me.GISSNETTWT, Me.GISSWASTAGEWT})
        Me.GRIDISSUEDETAILS.GridControl = Me.GRIDISSUESTOCK
        Me.GRIDISSUEDETAILS.Name = "GRIDISSUEDETAILS"
        Me.GRIDISSUEDETAILS.OptionsBehavior.AllowIncrementalSearch = True
        Me.GRIDISSUEDETAILS.OptionsBehavior.Editable = False
        Me.GRIDISSUEDETAILS.OptionsBehavior.SummariesIgnoreNullValues = True
        Me.GRIDISSUEDETAILS.OptionsCustomization.AllowGroup = False
        Me.GRIDISSUEDETAILS.OptionsMenu.EnableColumnMenu = False
        Me.GRIDISSUEDETAILS.OptionsMenu.EnableGroupPanelMenu = False
        Me.GRIDISSUEDETAILS.OptionsMenu.ShowGroupSortSummaryItems = False
        Me.GRIDISSUEDETAILS.OptionsView.ColumnAutoWidth = False
        Me.GRIDISSUEDETAILS.OptionsView.EnableAppearanceEvenRow = True
        Me.GRIDISSUEDETAILS.OptionsView.EnableAppearanceOddRow = True
        Me.GRIDISSUEDETAILS.OptionsView.ShowAutoFilterRow = True
        Me.GRIDISSUEDETAILS.OptionsView.ShowFooter = True
        Me.GRIDISSUEDETAILS.OptionsView.ShowGroupPanel = False
        '
        'GISSDATE
        '
        Me.GISSDATE.Caption = "Date"
        Me.GISSDATE.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.GISSDATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GISSDATE.FieldName = "DATE"
        Me.GISSDATE.Name = "GISSDATE"
        Me.GISSDATE.Visible = True
        Me.GISSDATE.VisibleIndex = 0
        '
        'GISSNAME
        '
        Me.GISSNAME.Caption = "Party Name"
        Me.GISSNAME.FieldName = "NAME"
        Me.GISSNAME.Name = "GISSNAME"
        Me.GISSNAME.Visible = True
        Me.GISSNAME.VisibleIndex = 1
        Me.GISSNAME.Width = 120
        '
        'GISSITEMNAME
        '
        Me.GISSITEMNAME.Caption = "Item Code"
        Me.GISSITEMNAME.FieldName = "ITEMCODE"
        Me.GISSITEMNAME.Name = "GISSITEMNAME"
        Me.GISSITEMNAME.Visible = True
        Me.GISSITEMNAME.VisibleIndex = 2
        '
        'GISSGROSSWT
        '
        Me.GISSGROSSWT.Caption = "Gross Wt"
        Me.GISSGROSSWT.DisplayFormat.FormatString = "0.000"
        Me.GISSGROSSWT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GISSGROSSWT.FieldName = "GROSSWT"
        Me.GISSGROSSWT.Name = "GISSGROSSWT"
        Me.GISSGROSSWT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GISSGROSSWT.Visible = True
        Me.GISSGROSSWT.VisibleIndex = 3
        '
        'GISSPURITY
        '
        Me.GISSPURITY.Caption = "Purity"
        Me.GISSPURITY.DisplayFormat.FormatString = "0.00"
        Me.GISSPURITY.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GISSPURITY.FieldName = "PURITY"
        Me.GISSPURITY.Name = "GISSPURITY"
        Me.GISSPURITY.Visible = True
        Me.GISSPURITY.VisibleIndex = 4
        Me.GISSPURITY.Width = 55
        '
        'GISSWASTAGE
        '
        Me.GISSWASTAGE.Caption = "Wastage"
        Me.GISSWASTAGE.DisplayFormat.FormatString = "0.00"
        Me.GISSWASTAGE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GISSWASTAGE.FieldName = "WASTAGE"
        Me.GISSWASTAGE.Name = "GISSWASTAGE"
        Me.GISSWASTAGE.OptionsColumn.AllowEdit = False
        Me.GISSWASTAGE.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GISSWASTAGE.Visible = True
        Me.GISSWASTAGE.VisibleIndex = 5
        Me.GISSWASTAGE.Width = 65
        '
        'GISSNETTWT
        '
        Me.GISSNETTWT.Caption = "Nett Wt"
        Me.GISSNETTWT.DisplayFormat.FormatString = "0.000"
        Me.GISSNETTWT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GISSNETTWT.FieldName = "NETTWT"
        Me.GISSNETTWT.Name = "GISSNETTWT"
        Me.GISSNETTWT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GISSNETTWT.Visible = True
        Me.GISSNETTWT.VisibleIndex = 6
        '
        'GISSWASTAGEWT
        '
        Me.GISSWASTAGEWT.Caption = "Wast Wt"
        Me.GISSWASTAGEWT.DisplayFormat.FormatString = "0.000"
        Me.GISSWASTAGEWT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GISSWASTAGEWT.FieldName = "WASTAGEWT"
        Me.GISSWASTAGEWT.Name = "GISSWASTAGEWT"
        Me.GISSWASTAGEWT.OptionsColumn.AllowEdit = False
        Me.GISSWASTAGEWT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GISSWASTAGEWT.Visible = True
        Me.GISSWASTAGEWT.VisibleIndex = 7
        '
        'RepositoryItemComboBox1
        '
        Me.RepositoryItemComboBox1.AutoHeight = False
        Me.RepositoryItemComboBox1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemComboBox1.Name = "RepositoryItemComboBox1"
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.Controls.Add(Me.gridStock)
        Me.Panel1.Controls.Add(Me.GRIDISSUESTOCK)
        Me.Panel1.Location = New System.Drawing.Point(9, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1340, 536)
        Me.Panel1.TabIndex = 488
        '
        'PartyWiseWastageDetailsReport
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1314, 582)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.cmdexit)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "PartyWiseWastageDetailsReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Party Wise Wastage Details Report"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.gridStock, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GRIDDETAILS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CMBTOUCHNAME, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GRIDISSUESTOCK, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GRIDISSUEDETAILS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents gridStock As DevExpress.XtraGrid.GridControl
    Friend WithEvents GRIDDETAILS As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GJAMANAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GJAMAGROSSWT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GJAMAWASTAGE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GJAMANETTWT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GJAMAWASTAGEWT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CMBTOUCHNAME As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents GJAMADATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GJAMAITEMNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GJAMAPURITY As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents GRIDISSUESTOCK As DevExpress.XtraGrid.GridControl
    Friend WithEvents GRIDISSUEDETAILS As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GISSDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GISSNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GISSITEMNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GISSGROSSWT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GISSPURITY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GISSWASTAGE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GISSNETTWT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GISSWASTAGEWT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemComboBox1 As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
End Class
