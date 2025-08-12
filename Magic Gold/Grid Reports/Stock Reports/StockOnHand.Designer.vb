<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StockOnHand
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(StockOnHand))
        Me.BlendPanel1 = New VbPowerPack.BlendPanel
        Me.CMDOK = New System.Windows.Forms.Button
        Me.gridStock = New DevExpress.XtraGrid.GridControl
        Me.GRIDDETAILS = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GITEMCODE = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GNARRATION = New DevExpress.XtraGrid.Columns.GridColumn
        Me.gpurity = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GGROSSWT = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GNETTWT = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.PrintToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.EXCEL_ICON = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.TOOLREFRESH = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.cmdexit = New System.Windows.Forms.Button
        Me.lbl = New System.Windows.Forms.Label
        Me.BlendPanel1.SuspendLayout()
        CType(Me.gridStock, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GRIDDETAILS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.CMDOK)
        Me.BlendPanel1.Controls.Add(Me.gridStock)
        Me.BlendPanel1.Controls.Add(Me.ToolStrip1)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.lbl)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(834, 592)
        Me.BlendPanel1.TabIndex = 1
        '
        'CMDOK
        '
        Me.CMDOK.BackColor = System.Drawing.Color.Transparent
        Me.CMDOK.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDOK.FlatAppearance.BorderSize = 0
        Me.CMDOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CMDOK.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDOK.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CMDOK.Image = Global.Magic_Gold.My.Resources.Resources.ok
        Me.CMDOK.Location = New System.Drawing.Point(342, 562)
        Me.CMDOK.Name = "CMDOK"
        Me.CMDOK.Size = New System.Drawing.Size(72, 25)
        Me.CMDOK.TabIndex = 482
        Me.CMDOK.UseVisualStyleBackColor = False
        '
        'gridStock
        '
        Me.gridStock.EmbeddedNavigator.Appearance.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridStock.EmbeddedNavigator.Appearance.Options.UseFont = True
        Me.gridStock.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridStock.Location = New System.Drawing.Point(20, 53)
        Me.gridStock.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridStock.MainView = Me.GRIDDETAILS
        Me.gridStock.Name = "gridStock"
        Me.gridStock.Size = New System.Drawing.Size(794, 503)
        Me.gridStock.TabIndex = 481
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
        Me.GRIDDETAILS.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GITEMCODE, Me.GNARRATION, Me.gpurity, Me.GGROSSWT, Me.GNETTWT})
        Me.GRIDDETAILS.GridControl = Me.gridStock
        Me.GRIDDETAILS.Name = "GRIDDETAILS"
        Me.GRIDDETAILS.OptionsBehavior.AllowIncrementalSearch = True
        Me.GRIDDETAILS.OptionsBehavior.Editable = False
        Me.GRIDDETAILS.OptionsBehavior.SummariesIgnoreNullValues = True
        Me.GRIDDETAILS.OptionsCustomization.AllowColumnMoving = False
        Me.GRIDDETAILS.OptionsCustomization.AllowColumnResizing = False
        Me.GRIDDETAILS.OptionsCustomization.AllowGroup = False
        Me.GRIDDETAILS.OptionsCustomization.AllowQuickHideColumns = False
        Me.GRIDDETAILS.OptionsMenu.EnableColumnMenu = False
        Me.GRIDDETAILS.OptionsMenu.EnableGroupPanelMenu = False
        Me.GRIDDETAILS.OptionsMenu.ShowGroupSortSummaryItems = False
        Me.GRIDDETAILS.OptionsView.ColumnAutoWidth = False
        Me.GRIDDETAILS.OptionsView.EnableAppearanceEvenRow = True
        Me.GRIDDETAILS.OptionsView.EnableAppearanceOddRow = True
        Me.GRIDDETAILS.OptionsView.ShowFooter = True
        Me.GRIDDETAILS.OptionsView.ShowGroupPanel = False
        '
        'GITEMCODE
        '
        Me.GITEMCODE.AppearanceHeader.Options.UseTextOptions = True
        Me.GITEMCODE.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GITEMCODE.Caption = "Item Code"
        Me.GITEMCODE.FieldName = "ITEMCODE"
        Me.GITEMCODE.Name = "GITEMCODE"
        Me.GITEMCODE.Visible = True
        Me.GITEMCODE.VisibleIndex = 0
        Me.GITEMCODE.Width = 200
        '
        'GNARRATION
        '
        Me.GNARRATION.Caption = "Narration"
        Me.GNARRATION.FieldName = "NARRATION"
        Me.GNARRATION.Name = "GNARRATION"
        Me.GNARRATION.Visible = True
        Me.GNARRATION.VisibleIndex = 1
        Me.GNARRATION.Width = 250
        '
        'gpurity
        '
        Me.gpurity.AppearanceCell.Options.UseTextOptions = True
        Me.gpurity.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.gpurity.AppearanceHeader.Options.UseTextOptions = True
        Me.gpurity.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gpurity.Caption = "Purity"
        Me.gpurity.DisplayFormat.FormatString = "0.00"
        Me.gpurity.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.gpurity.FieldName = "PURITY"
        Me.gpurity.Name = "gpurity"
        Me.gpurity.Visible = True
        Me.gpurity.VisibleIndex = 2
        Me.gpurity.Width = 90
        '
        'GGROSSWT
        '
        Me.GGROSSWT.AppearanceCell.Options.UseTextOptions = True
        Me.GGROSSWT.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GGROSSWT.AppearanceHeader.Options.UseTextOptions = True
        Me.GGROSSWT.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GGROSSWT.Caption = "Gross Wt."
        Me.GGROSSWT.DisplayFormat.FormatString = "0.000"
        Me.GGROSSWT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GGROSSWT.FieldName = "GROSSWT"
        Me.GGROSSWT.Name = "GGROSSWT"
        Me.GGROSSWT.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Me.GGROSSWT.Visible = True
        Me.GGROSSWT.VisibleIndex = 3
        Me.GGROSSWT.Width = 100
        '
        'GNETTWT
        '
        Me.GNETTWT.AppearanceCell.Options.UseTextOptions = True
        Me.GNETTWT.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GNETTWT.AppearanceHeader.Options.UseTextOptions = True
        Me.GNETTWT.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GNETTWT.Caption = "Nett Wt."
        Me.GNETTWT.DisplayFormat.FormatString = "0.000"
        Me.GNETTWT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GNETTWT.FieldName = "NETTWT"
        Me.GNETTWT.Name = "GNETTWT"
        Me.GNETTWT.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Me.GNETTWT.Visible = True
        Me.GNETTWT.VisibleIndex = 4
        Me.GNETTWT.Width = 100
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrintToolStripButton, Me.EXCEL_ICON, Me.ToolStripSeparator1, Me.TOOLREFRESH, Me.ToolStripSeparator2})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(834, 25)
        Me.ToolStrip1.TabIndex = 480
        Me.ToolStrip1.Text = "ToolStrip1"
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
        'EXCEL_ICON
        '
        Me.EXCEL_ICON.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.EXCEL_ICON.Image = Global.Magic_Gold.My.Resources.Resources.Excel_icon
        Me.EXCEL_ICON.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.EXCEL_ICON.Name = "EXCEL_ICON"
        Me.EXCEL_ICON.Size = New System.Drawing.Size(23, 22)
        Me.EXCEL_ICON.Text = "Excel Report"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'TOOLREFRESH
        '
        Me.TOOLREFRESH.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TOOLREFRESH.Image = Global.Magic_Gold.My.Resources.Resources.refreshimage
        Me.TOOLREFRESH.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TOOLREFRESH.Name = "TOOLREFRESH"
        Me.TOOLREFRESH.Size = New System.Drawing.Size(23, 22)
        Me.TOOLREFRESH.Text = "ToolStripButton1"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
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
        Me.cmdexit.Location = New System.Drawing.Point(420, 562)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(72, 25)
        Me.cmdexit.TabIndex = 7
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'lbl
        '
        Me.lbl.AutoSize = True
        Me.lbl.BackColor = System.Drawing.Color.Transparent
        Me.lbl.Font = New System.Drawing.Font("Calibri", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbl.Location = New System.Drawing.Point(12, 27)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(114, 21)
        Me.lbl.TabIndex = 394
        Me.lbl.Text = "Stock On Hand"
        '
        'StockOnHand
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(834, 592)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "StockOnHand"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Stock On Hand"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.gridStock, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GRIDDETAILS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents PrintToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents EXCEL_ICON As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents lbl As System.Windows.Forms.Label
    Private WithEvents gridStock As DevExpress.XtraGrid.GridControl
    Friend WithEvents GRIDDETAILS As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GITEMCODE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gpurity As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GGROSSWT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GNETTWT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CMDOK As System.Windows.Forms.Button
    Friend WithEvents TOOLREFRESH As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents GNARRATION As DevExpress.XtraGrid.Columns.GridColumn
End Class
