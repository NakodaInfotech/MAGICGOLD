<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProcessGridReport
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
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.gridStock = New DevExpress.XtraGrid.GridControl()
        Me.GRIDDETAILS = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GLOTNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPART = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPROCESS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GINWT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GOUTWT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GWASTAGE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GWASTAGEFINE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSAMPLE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSAMPLEFINE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GLOSS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GLOSSFINE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GVACCUM = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GVACCUMFINE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GEXCESS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GEXCESSFINE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPERCENTIN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPERCENTOUT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPERCENTFINAL = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GLAB = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CMBTOUCHNAME = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.CMDEXPORT = New System.Windows.Forms.Button()
        Me.dtto = New System.Windows.Forms.DateTimePicker()
        Me.lblto = New System.Windows.Forms.Label()
        Me.dtfrom = New System.Windows.Forms.DateTimePicker()
        Me.chkdate = New System.Windows.Forms.CheckBox()
        Me.lblfrom = New System.Windows.Forms.Label()
        Me.CMDSHOW = New System.Windows.Forms.Button()
        CType(Me.gridStock, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GRIDDETAILS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CMBTOUCHNAME, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.Black
        Me.cmdexit.Location = New System.Drawing.Point(577, 547)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 28)
        Me.cmdexit.TabIndex = 489
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'gridStock
        '
        Me.gridStock.EmbeddedNavigator.Appearance.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridStock.EmbeddedNavigator.Appearance.Options.UseFont = True
        Me.gridStock.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridStock.Location = New System.Drawing.Point(12, 38)
        Me.gridStock.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridStock.MainView = Me.GRIDDETAILS
        Me.gridStock.Name = "gridStock"
        Me.gridStock.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.CMBTOUCHNAME})
        Me.gridStock.Size = New System.Drawing.Size(1210, 503)
        Me.gridStock.TabIndex = 488
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
        Me.GRIDDETAILS.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GLOTNO, Me.GPART, Me.GPROCESS, Me.GNAME, Me.GDATE, Me.GINWT, Me.GOUTWT, Me.GWASTAGE, Me.GWASTAGEFINE, Me.GSAMPLE, Me.GSAMPLEFINE, Me.GLOSS, Me.GLOSSFINE, Me.GVACCUM, Me.GVACCUMFINE, Me.GEXCESS, Me.GEXCESSFINE, Me.GPERCENTIN, Me.GPERCENTOUT, Me.GPERCENTFINAL, Me.GLAB})
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
        'GLOTNO
        '
        Me.GLOTNO.Caption = "Lot No"
        Me.GLOTNO.FieldName = "LOTNO"
        Me.GLOTNO.Name = "GLOTNO"
        Me.GLOTNO.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "LOTNO", "{0}")})
        Me.GLOTNO.Visible = True
        Me.GLOTNO.VisibleIndex = 0
        '
        'GPART
        '
        Me.GPART.Caption = "Part"
        Me.GPART.FieldName = "PART"
        Me.GPART.Name = "GPART"
        Me.GPART.Visible = True
        Me.GPART.VisibleIndex = 1
        '
        'GPROCESS
        '
        Me.GPROCESS.Caption = "Process"
        Me.GPROCESS.FieldName = "PROCESS"
        Me.GPROCESS.Name = "GPROCESS"
        Me.GPROCESS.Visible = True
        Me.GPROCESS.VisibleIndex = 2
        Me.GPROCESS.Width = 100
        '
        'GNAME
        '
        Me.GNAME.Caption = "Name"
        Me.GNAME.FieldName = "NAME"
        Me.GNAME.Name = "GNAME"
        Me.GNAME.Visible = True
        Me.GNAME.VisibleIndex = 3
        Me.GNAME.Width = 200
        '
        'GDATE
        '
        Me.GDATE.Caption = "Date"
        Me.GDATE.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.GDATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GDATE.FieldName = "PDATE"
        Me.GDATE.Name = "GDATE"
        Me.GDATE.Visible = True
        Me.GDATE.VisibleIndex = 4
        '
        'GINWT
        '
        Me.GINWT.Caption = "In Wt."
        Me.GINWT.DisplayFormat.FormatString = "0.000"
        Me.GINWT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GINWT.FieldName = "INWT"
        Me.GINWT.Name = "GINWT"
        Me.GINWT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "INWT", "{0:0.000}")})
        Me.GINWT.Visible = True
        Me.GINWT.VisibleIndex = 5
        '
        'GOUTWT
        '
        Me.GOUTWT.Caption = "Out Wt"
        Me.GOUTWT.DisplayFormat.FormatString = "0.000"
        Me.GOUTWT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GOUTWT.FieldName = "OUTWT"
        Me.GOUTWT.Name = "GOUTWT"
        Me.GOUTWT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "OUTWT", "{0:0.000}")})
        Me.GOUTWT.Visible = True
        Me.GOUTWT.VisibleIndex = 6
        '
        'GWASTAGE
        '
        Me.GWASTAGE.Caption = "Wastage"
        Me.GWASTAGE.DisplayFormat.FormatString = "0.000"
        Me.GWASTAGE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GWASTAGE.FieldName = "WASTAGE"
        Me.GWASTAGE.Name = "GWASTAGE"
        Me.GWASTAGE.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "WASTAGE", "{0:0.000}")})
        Me.GWASTAGE.Visible = True
        Me.GWASTAGE.VisibleIndex = 7
        '
        'GWASTAGEFINE
        '
        Me.GWASTAGEFINE.Caption = "Was (Fine)"
        Me.GWASTAGEFINE.DisplayFormat.FormatString = "0.000"
        Me.GWASTAGEFINE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GWASTAGEFINE.FieldName = "WASTAGEFINE"
        Me.GWASTAGEFINE.Name = "GWASTAGEFINE"
        Me.GWASTAGEFINE.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "WASTAGEFINE", "{0:0.000}")})
        Me.GWASTAGEFINE.Visible = True
        Me.GWASTAGEFINE.VisibleIndex = 8
        '
        'GSAMPLE
        '
        Me.GSAMPLE.Caption = "Sample"
        Me.GSAMPLE.DisplayFormat.FormatString = "0.000"
        Me.GSAMPLE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GSAMPLE.FieldName = "SAMPLE"
        Me.GSAMPLE.Name = "GSAMPLE"
        Me.GSAMPLE.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "SAMPLE", "{0:0.000}")})
        Me.GSAMPLE.Visible = True
        Me.GSAMPLE.VisibleIndex = 9
        '
        'GSAMPLEFINE
        '
        Me.GSAMPLEFINE.Caption = "Smp (Fine)"
        Me.GSAMPLEFINE.DisplayFormat.FormatString = "0.000"
        Me.GSAMPLEFINE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GSAMPLEFINE.FieldName = "SAMPLEFINE"
        Me.GSAMPLEFINE.Name = "GSAMPLEFINE"
        Me.GSAMPLEFINE.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "SAMPLEFINE", "{0:0.000}")})
        Me.GSAMPLEFINE.Visible = True
        Me.GSAMPLEFINE.VisibleIndex = 10
        '
        'GLOSS
        '
        Me.GLOSS.Caption = "Loss"
        Me.GLOSS.DisplayFormat.FormatString = "0.000"
        Me.GLOSS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GLOSS.FieldName = "LOSS"
        Me.GLOSS.Name = "GLOSS"
        Me.GLOSS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "LOSS", "{0:0.000}")})
        Me.GLOSS.Visible = True
        Me.GLOSS.VisibleIndex = 11
        '
        'GLOSSFINE
        '
        Me.GLOSSFINE.Caption = "Loss (Fine)"
        Me.GLOSSFINE.DisplayFormat.FormatString = "0.000"
        Me.GLOSSFINE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GLOSSFINE.FieldName = "LOSSFINE"
        Me.GLOSSFINE.Name = "GLOSSFINE"
        Me.GLOSSFINE.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "LOSSFINE", "{0:0.000}")})
        Me.GLOSSFINE.Visible = True
        Me.GLOSSFINE.VisibleIndex = 12
        '
        'GVACCUM
        '
        Me.GVACCUM.Caption = "Vaccum"
        Me.GVACCUM.DisplayFormat.FormatString = "0.000"
        Me.GVACCUM.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GVACCUM.FieldName = "VACCUM"
        Me.GVACCUM.Name = "GVACCUM"
        Me.GVACCUM.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "VACCUM", "{0:0.000}")})
        Me.GVACCUM.Visible = True
        Me.GVACCUM.VisibleIndex = 13
        '
        'GVACCUMFINE
        '
        Me.GVACCUMFINE.Caption = "Vac (Fine)"
        Me.GVACCUMFINE.DisplayFormat.FormatString = "0.000"
        Me.GVACCUMFINE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GVACCUMFINE.FieldName = "VACCUMFINE"
        Me.GVACCUMFINE.Name = "GVACCUMFINE"
        Me.GVACCUMFINE.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "VACCUMFINE", "{0:0.000}")})
        Me.GVACCUMFINE.Visible = True
        Me.GVACCUMFINE.VisibleIndex = 14
        '
        'GEXCESS
        '
        Me.GEXCESS.Caption = "Excess"
        Me.GEXCESS.DisplayFormat.FormatString = "0.000"
        Me.GEXCESS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GEXCESS.FieldName = "EXCESS"
        Me.GEXCESS.Name = "GEXCESS"
        Me.GEXCESS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "EXCESS", "{0:0.000}")})
        Me.GEXCESS.Visible = True
        Me.GEXCESS.VisibleIndex = 15
        '
        'GEXCESSFINE
        '
        Me.GEXCESSFINE.Caption = "Excess Fine"
        Me.GEXCESSFINE.DisplayFormat.FormatString = "0.000"
        Me.GEXCESSFINE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GEXCESSFINE.FieldName = "EXCESSFINE"
        Me.GEXCESSFINE.Name = "GEXCESSFINE"
        Me.GEXCESSFINE.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "EXCESSFINE", "{0:0.000}")})
        Me.GEXCESSFINE.Visible = True
        Me.GEXCESSFINE.VisibleIndex = 16
        '
        'GPERCENTIN
        '
        Me.GPERCENTIN.Caption = "% In"
        Me.GPERCENTIN.DisplayFormat.FormatString = "0.00"
        Me.GPERCENTIN.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GPERCENTIN.FieldName = "PERCENTIN"
        Me.GPERCENTIN.Name = "GPERCENTIN"
        Me.GPERCENTIN.Visible = True
        Me.GPERCENTIN.VisibleIndex = 17
        '
        'GPERCENTOUT
        '
        Me.GPERCENTOUT.Caption = "% Out"
        Me.GPERCENTOUT.DisplayFormat.FormatString = "0.00"
        Me.GPERCENTOUT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GPERCENTOUT.FieldName = "PERCENTOUT"
        Me.GPERCENTOUT.Name = "GPERCENTOUT"
        Me.GPERCENTOUT.Visible = True
        Me.GPERCENTOUT.VisibleIndex = 18
        '
        'GPERCENTFINAL
        '
        Me.GPERCENTFINAL.Caption = "% Final"
        Me.GPERCENTFINAL.DisplayFormat.FormatString = "0.00"
        Me.GPERCENTFINAL.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GPERCENTFINAL.FieldName = "PERCENTFINAL"
        Me.GPERCENTFINAL.Name = "GPERCENTFINAL"
        Me.GPERCENTFINAL.Visible = True
        Me.GPERCENTFINAL.VisibleIndex = 19
        '
        'GLAB
        '
        Me.GLAB.Caption = "Lab"
        Me.GLAB.DisplayFormat.FormatString = "0.00"
        Me.GLAB.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GLAB.FieldName = "LAB"
        Me.GLAB.Name = "GLAB"
        Me.GLAB.Visible = True
        Me.GLAB.VisibleIndex = 20
        '
        'CMBTOUCHNAME
        '
        Me.CMBTOUCHNAME.AutoHeight = False
        Me.CMBTOUCHNAME.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CMBTOUCHNAME.Name = "CMBTOUCHNAME"
        '
        'CMDEXPORT
        '
        Me.CMDEXPORT.BackColor = System.Drawing.Color.Transparent
        Me.CMDEXPORT.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDEXPORT.FlatAppearance.BorderSize = 0
        Me.CMDEXPORT.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDEXPORT.ForeColor = System.Drawing.Color.Black
        Me.CMDEXPORT.Location = New System.Drawing.Point(414, 6)
        Me.CMDEXPORT.Name = "CMDEXPORT"
        Me.CMDEXPORT.Size = New System.Drawing.Size(80, 28)
        Me.CMDEXPORT.TabIndex = 490
        Me.CMDEXPORT.Text = "Ex&port"
        Me.CMDEXPORT.UseVisualStyleBackColor = False
        '
        'dtto
        '
        Me.dtto.CustomFormat = "dd/MM/yyyy"
        Me.dtto.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtto.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtto.Location = New System.Drawing.Point(229, 10)
        Me.dtto.Name = "dtto"
        Me.dtto.Size = New System.Drawing.Size(88, 23)
        Me.dtto.TabIndex = 493
        '
        'lblto
        '
        Me.lblto.AutoSize = True
        Me.lblto.BackColor = System.Drawing.Color.Transparent
        Me.lblto.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblto.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblto.Location = New System.Drawing.Point(207, 14)
        Me.lblto.Name = "lblto"
        Me.lblto.Size = New System.Drawing.Size(19, 15)
        Me.lblto.TabIndex = 495
        Me.lblto.Text = "To"
        '
        'dtfrom
        '
        Me.dtfrom.CustomFormat = "dd/MM/yyyy"
        Me.dtfrom.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtfrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtfrom.Location = New System.Drawing.Point(108, 10)
        Me.dtfrom.Name = "dtfrom"
        Me.dtfrom.Size = New System.Drawing.Size(89, 23)
        Me.dtfrom.TabIndex = 492
        '
        'chkdate
        '
        Me.chkdate.AutoSize = True
        Me.chkdate.BackColor = System.Drawing.Color.Transparent
        Me.chkdate.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkdate.Location = New System.Drawing.Point(23, 12)
        Me.chkdate.Name = "chkdate"
        Me.chkdate.Size = New System.Drawing.Size(50, 19)
        Me.chkdate.TabIndex = 491
        Me.chkdate.Text = "Date"
        Me.chkdate.UseVisualStyleBackColor = False
        '
        'lblfrom
        '
        Me.lblfrom.AutoSize = True
        Me.lblfrom.BackColor = System.Drawing.Color.Transparent
        Me.lblfrom.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblfrom.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblfrom.Location = New System.Drawing.Point(72, 14)
        Me.lblfrom.Name = "lblfrom"
        Me.lblfrom.Size = New System.Drawing.Size(35, 15)
        Me.lblfrom.TabIndex = 494
        Me.lblfrom.Text = "From"
        '
        'CMDSHOW
        '
        Me.CMDSHOW.BackColor = System.Drawing.Color.Transparent
        Me.CMDSHOW.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDSHOW.FlatAppearance.BorderSize = 0
        Me.CMDSHOW.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDSHOW.ForeColor = System.Drawing.Color.Black
        Me.CMDSHOW.Location = New System.Drawing.Point(323, 6)
        Me.CMDSHOW.Name = "CMDSHOW"
        Me.CMDSHOW.Size = New System.Drawing.Size(85, 28)
        Me.CMDSHOW.TabIndex = 496
        Me.CMDSHOW.Text = "&Show Report"
        Me.CMDSHOW.UseVisualStyleBackColor = False
        '
        'ProcessGridReport
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1234, 581)
        Me.Controls.Add(Me.CMDSHOW)
        Me.Controls.Add(Me.dtto)
        Me.Controls.Add(Me.lblto)
        Me.Controls.Add(Me.dtfrom)
        Me.Controls.Add(Me.chkdate)
        Me.Controls.Add(Me.lblfrom)
        Me.Controls.Add(Me.CMDEXPORT)
        Me.Controls.Add(Me.cmdexit)
        Me.Controls.Add(Me.gridStock)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "ProcessGridReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Process Grid Report"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.gridStock, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GRIDDETAILS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CMBTOUCHNAME, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cmdexit As Button
    Private WithEvents gridStock As DevExpress.XtraGrid.GridControl
    Friend WithEvents GRIDDETAILS As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents CMBTOUCHNAME As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents CMDEXPORT As Button
    Friend WithEvents GPART As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPROCESS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GINWT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GOUTWT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GWASTAGE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GWASTAGEFINE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSAMPLE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSAMPLEFINE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GLOSS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GLOSSFINE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GVACCUM As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GVACCUMFINE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GEXCESS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GEXCESSFINE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPERCENTIN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPERCENTOUT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPERCENTFINAL As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GLAB As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GLOTNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents dtto As DateTimePicker
    Friend WithEvents lblto As Label
    Friend WithEvents dtfrom As DateTimePicker
    Friend WithEvents chkdate As CheckBox
    Friend WithEvents lblfrom As Label
    Friend WithEvents CMDSHOW As Button
End Class
