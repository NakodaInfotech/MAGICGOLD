<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StockDetails
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(StockDetails))
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.PrintToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.EXCEL_ICON = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.TOOLREFRESH = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.txtbalnett = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtbalgross = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.lbl = New System.Windows.Forms.Label()
        Me.gridStock = New DevExpress.XtraGrid.GridControl()
        Me.gridbandstock = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.gridBand1 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.gpartyname = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gpurity = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand2 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.grecgrosswt = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.grecnettwt = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand3 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.gissuegrosswt = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gissuenettwt = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BlendPanel1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.gridStock, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridbandstock, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.ToolStrip1)
        Me.BlendPanel1.Controls.Add(Me.txtbalnett)
        Me.BlendPanel1.Controls.Add(Me.Label5)
        Me.BlendPanel1.Controls.Add(Me.txtbalgross)
        Me.BlendPanel1.Controls.Add(Me.Label3)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.lbl)
        Me.BlendPanel1.Controls.Add(Me.gridStock)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(675, 593)
        Me.BlendPanel1.TabIndex = 1
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrintToolStripButton, Me.EXCEL_ICON, Me.ToolStripSeparator1, Me.TOOLREFRESH, Me.ToolStripSeparator2})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(675, 25)
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
        Me.EXCEL_ICON.Text = "ToolStripButton1"
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
        'txtbalnett
        '
        Me.txtbalnett.BackColor = System.Drawing.Color.White
        Me.txtbalnett.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbalnett.ForeColor = System.Drawing.Color.Black
        Me.txtbalnett.Location = New System.Drawing.Point(146, 562)
        Me.txtbalnett.Name = "txtbalnett"
        Me.txtbalnett.ReadOnly = True
        Me.txtbalnett.Size = New System.Drawing.Size(66, 22)
        Me.txtbalnett.TabIndex = 392
        Me.txtbalnett.TabStop = False
        Me.txtbalnett.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(46, 566)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(98, 14)
        Me.Label5.TabIndex = 393
        Me.Label5.Text = "Balance Nett Wt."
        '
        'txtbalgross
        '
        Me.txtbalgross.BackColor = System.Drawing.Color.White
        Me.txtbalgross.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbalgross.ForeColor = System.Drawing.Color.Black
        Me.txtbalgross.Location = New System.Drawing.Point(146, 534)
        Me.txtbalgross.Name = "txtbalgross"
        Me.txtbalgross.ReadOnly = True
        Me.txtbalgross.Size = New System.Drawing.Size(66, 22)
        Me.txtbalgross.TabIndex = 478
        Me.txtbalgross.TabStop = False
        Me.txtbalgross.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(37, 538)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(106, 14)
        Me.Label3.TabIndex = 479
        Me.Label3.Text = "Balance Gross Wt."
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
        Me.cmdexit.Location = New System.Drawing.Point(302, 554)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(72, 27)
        Me.cmdexit.TabIndex = 7
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'lbl
        '
        Me.lbl.AutoSize = True
        Me.lbl.BackColor = System.Drawing.Color.Transparent
        Me.lbl.Font = New System.Drawing.Font("Calibri", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbl.Location = New System.Drawing.Point(15, 31)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(101, 21)
        Me.lbl.TabIndex = 394
        Me.lbl.Text = "Stock Details"
        '
        'gridStock
        '
        Me.gridStock.EmbeddedNavigator.Appearance.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridStock.EmbeddedNavigator.Appearance.Options.UseFont = True
        Me.gridStock.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridStock.Location = New System.Drawing.Point(27, 58)
        Me.gridStock.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridStock.MainView = Me.gridbandstock
        Me.gridStock.Name = "gridStock"
        Me.gridStock.Size = New System.Drawing.Size(623, 470)
        Me.gridStock.TabIndex = 319
        Me.gridStock.TabStop = False
        Me.gridStock.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridbandstock})
        '
        'gridbandstock
        '
        Me.gridbandstock.Appearance.BandPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.gridbandstock.Appearance.BandPanel.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.gridbandstock.Appearance.BandPanel.BorderColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.gridbandstock.Appearance.BandPanel.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbandstock.Appearance.BandPanel.ForeColor = System.Drawing.Color.Black
        Me.gridbandstock.Appearance.BandPanel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.gridbandstock.Appearance.BandPanel.Options.UseBackColor = True
        Me.gridbandstock.Appearance.BandPanel.Options.UseBorderColor = True
        Me.gridbandstock.Appearance.BandPanel.Options.UseFont = True
        Me.gridbandstock.Appearance.BandPanel.Options.UseForeColor = True
        Me.gridbandstock.Appearance.BandPanelBackground.BackColor = System.Drawing.Color.White
        Me.gridbandstock.Appearance.BandPanelBackground.Options.UseBackColor = True
        Me.gridbandstock.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.gridbandstock.Appearance.ColumnFilterButton.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.gridbandstock.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.gridbandstock.Appearance.ColumnFilterButton.ForeColor = System.Drawing.Color.Black
        Me.gridbandstock.Appearance.ColumnFilterButton.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.gridbandstock.Appearance.ColumnFilterButton.Options.UseBackColor = True
        Me.gridbandstock.Appearance.ColumnFilterButton.Options.UseBorderColor = True
        Me.gridbandstock.Appearance.ColumnFilterButton.Options.UseForeColor = True
        Me.gridbandstock.Appearance.ColumnFilterButtonActive.BackColor = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.gridbandstock.Appearance.ColumnFilterButtonActive.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(154, Byte), Integer), CType(CType(190, Byte), Integer), CType(CType(243, Byte), Integer))
        Me.gridbandstock.Appearance.ColumnFilterButtonActive.BorderColor = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.gridbandstock.Appearance.ColumnFilterButtonActive.ForeColor = System.Drawing.Color.Black
        Me.gridbandstock.Appearance.ColumnFilterButtonActive.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.gridbandstock.Appearance.ColumnFilterButtonActive.Options.UseBackColor = True
        Me.gridbandstock.Appearance.ColumnFilterButtonActive.Options.UseBorderColor = True
        Me.gridbandstock.Appearance.ColumnFilterButtonActive.Options.UseForeColor = True
        Me.gridbandstock.Appearance.Empty.BackColor = System.Drawing.Color.White
        Me.gridbandstock.Appearance.Empty.Options.UseBackColor = True
        Me.gridbandstock.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.gridbandstock.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black
        Me.gridbandstock.Appearance.EvenRow.Options.UseBackColor = True
        Me.gridbandstock.Appearance.EvenRow.Options.UseForeColor = True
        Me.gridbandstock.Appearance.FilterCloseButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.gridbandstock.Appearance.FilterCloseButton.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.gridbandstock.Appearance.FilterCloseButton.BorderColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.gridbandstock.Appearance.FilterCloseButton.ForeColor = System.Drawing.Color.Black
        Me.gridbandstock.Appearance.FilterCloseButton.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.gridbandstock.Appearance.FilterCloseButton.Options.UseBackColor = True
        Me.gridbandstock.Appearance.FilterCloseButton.Options.UseBorderColor = True
        Me.gridbandstock.Appearance.FilterCloseButton.Options.UseForeColor = True
        Me.gridbandstock.Appearance.FilterPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(62, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.gridbandstock.Appearance.FilterPanel.ForeColor = System.Drawing.Color.White
        Me.gridbandstock.Appearance.FilterPanel.Options.UseBackColor = True
        Me.gridbandstock.Appearance.FilterPanel.Options.UseForeColor = True
        Me.gridbandstock.Appearance.FixedLine.BackColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(97, Byte), Integer), CType(CType(156, Byte), Integer))
        Me.gridbandstock.Appearance.FixedLine.Options.UseBackColor = True
        Me.gridbandstock.Appearance.FocusedCell.BackColor = System.Drawing.Color.White
        Me.gridbandstock.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black
        Me.gridbandstock.Appearance.FocusedCell.Options.UseBackColor = True
        Me.gridbandstock.Appearance.FocusedCell.Options.UseForeColor = True
        Me.gridbandstock.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.gridbandstock.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White
        Me.gridbandstock.Appearance.FocusedRow.Options.UseBackColor = True
        Me.gridbandstock.Appearance.FocusedRow.Options.UseForeColor = True
        Me.gridbandstock.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.gridbandstock.Appearance.FooterPanel.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.gridbandstock.Appearance.FooterPanel.BorderColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.gridbandstock.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Black
        Me.gridbandstock.Appearance.FooterPanel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.gridbandstock.Appearance.FooterPanel.Options.UseBackColor = True
        Me.gridbandstock.Appearance.FooterPanel.Options.UseBorderColor = True
        Me.gridbandstock.Appearance.FooterPanel.Options.UseForeColor = True
        Me.gridbandstock.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.gridbandstock.Appearance.GroupButton.BorderColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.gridbandstock.Appearance.GroupButton.ForeColor = System.Drawing.Color.Black
        Me.gridbandstock.Appearance.GroupButton.Options.UseBackColor = True
        Me.gridbandstock.Appearance.GroupButton.Options.UseBorderColor = True
        Me.gridbandstock.Appearance.GroupButton.Options.UseForeColor = True
        Me.gridbandstock.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.gridbandstock.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.gridbandstock.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Black
        Me.gridbandstock.Appearance.GroupFooter.Options.UseBackColor = True
        Me.gridbandstock.Appearance.GroupFooter.Options.UseBorderColor = True
        Me.gridbandstock.Appearance.GroupFooter.Options.UseForeColor = True
        Me.gridbandstock.Appearance.GroupPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(62, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.gridbandstock.Appearance.GroupPanel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.gridbandstock.Appearance.GroupPanel.Options.UseBackColor = True
        Me.gridbandstock.Appearance.GroupPanel.Options.UseForeColor = True
        Me.gridbandstock.Appearance.GroupRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.gridbandstock.Appearance.GroupRow.BorderColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.gridbandstock.Appearance.GroupRow.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.gridbandstock.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black
        Me.gridbandstock.Appearance.GroupRow.Options.UseBackColor = True
        Me.gridbandstock.Appearance.GroupRow.Options.UseBorderColor = True
        Me.gridbandstock.Appearance.GroupRow.Options.UseFont = True
        Me.gridbandstock.Appearance.GroupRow.Options.UseForeColor = True
        Me.gridbandstock.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.gridbandstock.Appearance.HeaderPanel.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.gridbandstock.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.gridbandstock.Appearance.HeaderPanel.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbandstock.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black
        Me.gridbandstock.Appearance.HeaderPanel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.gridbandstock.Appearance.HeaderPanel.Options.UseBackColor = True
        Me.gridbandstock.Appearance.HeaderPanel.Options.UseBorderColor = True
        Me.gridbandstock.Appearance.HeaderPanel.Options.UseFont = True
        Me.gridbandstock.Appearance.HeaderPanel.Options.UseForeColor = True
        Me.gridbandstock.Appearance.HeaderPanelBackground.BackColor = System.Drawing.Color.White
        Me.gridbandstock.Appearance.HeaderPanelBackground.Options.UseBackColor = True
        Me.gridbandstock.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(106, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.gridbandstock.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.gridbandstock.Appearance.HideSelectionRow.Options.UseBackColor = True
        Me.gridbandstock.Appearance.HideSelectionRow.Options.UseForeColor = True
        Me.gridbandstock.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(CType(CType(99, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.gridbandstock.Appearance.HorzLine.Options.UseBackColor = True
        Me.gridbandstock.Appearance.OddRow.BackColor = System.Drawing.Color.White
        Me.gridbandstock.Appearance.OddRow.ForeColor = System.Drawing.Color.Black
        Me.gridbandstock.Appearance.OddRow.Options.UseBackColor = True
        Me.gridbandstock.Appearance.OddRow.Options.UseForeColor = True
        Me.gridbandstock.Appearance.Preview.BackColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.gridbandstock.Appearance.Preview.ForeColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.gridbandstock.Appearance.Preview.Options.UseBackColor = True
        Me.gridbandstock.Appearance.Preview.Options.UseForeColor = True
        Me.gridbandstock.Appearance.Row.BackColor = System.Drawing.Color.White
        Me.gridbandstock.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbandstock.Appearance.Row.ForeColor = System.Drawing.Color.Black
        Me.gridbandstock.Appearance.Row.Options.UseBackColor = True
        Me.gridbandstock.Appearance.Row.Options.UseFont = True
        Me.gridbandstock.Appearance.Row.Options.UseForeColor = True
        Me.gridbandstock.Appearance.RowSeparator.BackColor = System.Drawing.Color.White
        Me.gridbandstock.Appearance.RowSeparator.Options.UseBackColor = True
        Me.gridbandstock.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(126, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.gridbandstock.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White
        Me.gridbandstock.Appearance.SelectedRow.Options.UseBackColor = True
        Me.gridbandstock.Appearance.SelectedRow.Options.UseForeColor = True
        Me.gridbandstock.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(CType(CType(99, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.gridbandstock.Appearance.VertLine.Options.UseBackColor = True
        Me.gridbandstock.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.gridBand1, Me.gridBand2, Me.gridBand3})
        Me.gridbandstock.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.gpartyname, Me.gpurity, Me.grecgrosswt, Me.grecnettwt, Me.gissuegrosswt, Me.gissuenettwt})
        Me.gridbandstock.GridControl = Me.gridStock
        Me.gridbandstock.Name = "gridbandstock"
        Me.gridbandstock.OptionsBehavior.AllowIncrementalSearch = True
        Me.gridbandstock.OptionsBehavior.Editable = False
        Me.gridbandstock.OptionsBehavior.SummariesIgnoreNullValues = True
        Me.gridbandstock.OptionsCustomization.AllowBandMoving = False
        Me.gridbandstock.OptionsCustomization.AllowBandResizing = False
        Me.gridbandstock.OptionsCustomization.AllowChangeColumnParent = True
        Me.gridbandstock.OptionsCustomization.AllowColumnMoving = False
        Me.gridbandstock.OptionsCustomization.AllowColumnResizing = False
        Me.gridbandstock.OptionsCustomization.AllowGroup = False
        Me.gridbandstock.OptionsCustomization.AllowQuickHideColumns = False
        Me.gridbandstock.OptionsMenu.EnableColumnMenu = False
        Me.gridbandstock.OptionsMenu.EnableGroupPanelMenu = False
        Me.gridbandstock.OptionsMenu.ShowGroupSortSummaryItems = False
        Me.gridbandstock.OptionsView.ColumnAutoWidth = False
        Me.gridbandstock.OptionsView.EnableAppearanceEvenRow = True
        Me.gridbandstock.OptionsView.EnableAppearanceOddRow = True
        Me.gridbandstock.OptionsView.ShowFooter = True
        Me.gridbandstock.OptionsView.ShowGroupPanel = False
        Me.gridbandstock.PaintStyleName = "MixedXP"
        '
        'gridBand1
        '
        Me.gridBand1.Columns.Add(Me.gpartyname)
        Me.gridBand1.Columns.Add(Me.gpurity)
        Me.gridBand1.Name = "gridBand1"
        Me.gridBand1.OptionsBand.AllowMove = False
        Me.gridBand1.OptionsBand.AllowSize = False
        Me.gridBand1.OptionsBand.FixedWidth = True
        Me.gridBand1.VisibleIndex = 0
        Me.gridBand1.Width = 260
        '
        'gpartyname
        '
        Me.gpartyname.AppearanceHeader.Options.UseTextOptions = True
        Me.gpartyname.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gpartyname.Caption = "Name"
        Me.gpartyname.FieldName = "NAME"
        Me.gpartyname.Name = "gpartyname"
        Me.gpartyname.Visible = True
        Me.gpartyname.Width = 180
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
        Me.gpurity.Width = 80
        '
        'gridBand2
        '
        Me.gridBand2.AppearanceHeader.Options.UseTextOptions = True
        Me.gridBand2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gridBand2.Caption = "Receipt"
        Me.gridBand2.Columns.Add(Me.grecgrosswt)
        Me.gridBand2.Columns.Add(Me.grecnettwt)
        Me.gridBand2.Name = "gridBand2"
        Me.gridBand2.OptionsBand.AllowHotTrack = False
        Me.gridBand2.OptionsBand.AllowMove = False
        Me.gridBand2.OptionsBand.AllowSize = False
        Me.gridBand2.OptionsBand.FixedWidth = True
        Me.gridBand2.VisibleIndex = 1
        Me.gridBand2.Width = 160
        '
        'grecgrosswt
        '
        Me.grecgrosswt.AppearanceCell.Options.UseTextOptions = True
        Me.grecgrosswt.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.grecgrosswt.AppearanceHeader.Options.UseTextOptions = True
        Me.grecgrosswt.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.grecgrosswt.Caption = "Gross Wt."
        Me.grecgrosswt.DisplayFormat.FormatString = "0.000"
        Me.grecgrosswt.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.grecgrosswt.FieldName = "RECGROSS"
        Me.grecgrosswt.Name = "grecgrosswt"
        Me.grecgrosswt.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "RECGROSS", "{0:0.000}")})
        Me.grecgrosswt.Visible = True
        Me.grecgrosswt.Width = 80
        '
        'grecnettwt
        '
        Me.grecnettwt.AppearanceCell.Options.UseTextOptions = True
        Me.grecnettwt.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.grecnettwt.AppearanceHeader.Options.UseTextOptions = True
        Me.grecnettwt.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.grecnettwt.Caption = "Nett Wt."
        Me.grecnettwt.DisplayFormat.FormatString = "0.000"
        Me.grecnettwt.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.grecnettwt.FieldName = "RECNETT"
        Me.grecnettwt.Name = "grecnettwt"
        Me.grecnettwt.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "RECNETT", "{0:0.000}")})
        Me.grecnettwt.Visible = True
        Me.grecnettwt.Width = 80
        '
        'gridBand3
        '
        Me.gridBand3.AppearanceHeader.Options.UseTextOptions = True
        Me.gridBand3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gridBand3.Caption = "Issue"
        Me.gridBand3.Columns.Add(Me.gissuegrosswt)
        Me.gridBand3.Columns.Add(Me.gissuenettwt)
        Me.gridBand3.Name = "gridBand3"
        Me.gridBand3.OptionsBand.AllowHotTrack = False
        Me.gridBand3.OptionsBand.AllowMove = False
        Me.gridBand3.OptionsBand.AllowSize = False
        Me.gridBand3.OptionsBand.FixedWidth = True
        Me.gridBand3.VisibleIndex = 2
        Me.gridBand3.Width = 160
        '
        'gissuegrosswt
        '
        Me.gissuegrosswt.AppearanceCell.Options.UseTextOptions = True
        Me.gissuegrosswt.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.gissuegrosswt.AppearanceHeader.Options.UseTextOptions = True
        Me.gissuegrosswt.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gissuegrosswt.Caption = "Gross Wt."
        Me.gissuegrosswt.DisplayFormat.FormatString = "0.000"
        Me.gissuegrosswt.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.gissuegrosswt.FieldName = "ISSGROSS"
        Me.gissuegrosswt.Name = "gissuegrosswt"
        Me.gissuegrosswt.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ISSGROSS", "{0:0.000}")})
        Me.gissuegrosswt.Visible = True
        Me.gissuegrosswt.Width = 80
        '
        'gissuenettwt
        '
        Me.gissuenettwt.AppearanceCell.Options.UseTextOptions = True
        Me.gissuenettwt.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.gissuenettwt.AppearanceHeader.Options.UseTextOptions = True
        Me.gissuenettwt.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gissuenettwt.Caption = "Nett Wt."
        Me.gissuenettwt.DisplayFormat.FormatString = "0.000"
        Me.gissuenettwt.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.gissuenettwt.FieldName = "ISSNETT"
        Me.gissuenettwt.Name = "gissuenettwt"
        Me.gissuenettwt.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ISSNETT", "{0:0.000}")})
        Me.gissuenettwt.Visible = True
        Me.gissuenettwt.Width = 80
        '
        'StockDetails
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(675, 593)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "StockDetails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Stock Details"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.gridStock, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridbandstock, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents PrintToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents txtbalnett As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtbalgross As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents lbl As System.Windows.Forms.Label
    Private WithEvents gridStock As DevExpress.XtraGrid.GridControl
    Friend WithEvents gridbandstock As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents gridBand1 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gpartyname As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents gpurity As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents gridBand2 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents grecgrosswt As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents grecnettwt As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents gridBand3 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gissuegrosswt As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents gissuenettwt As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents EXCEL_ICON As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TOOLREFRESH As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
End Class
