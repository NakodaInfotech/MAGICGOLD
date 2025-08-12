<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StockWithKarigarWastageFine
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
        Me.TILLDATE = New System.Windows.Forms.DateTimePicker()
        Me.lblto = New System.Windows.Forms.Label()
        Me.TXTLOSS = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TXTTOTALGROSS = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GRIDKARIGAR = New DevExpress.XtraGrid.GridControl()
        Me.GRIDKARIGARDETAILS = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GKARIGARFINE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GRIDWASTAGE = New DevExpress.XtraGrid.GridControl()
        Me.GRIDWASTAGEDETAILS = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GWASTAGE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GWASTAGEFINE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CMDOK = New System.Windows.Forms.Button()
        Me.gridStock = New DevExpress.XtraGrid.GridControl()
        Me.GRIDDETAILS = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GITEMCODE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GNARRATION = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gpurity = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GGROSSWT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GNETTWT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.TOOLREFRESH = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.TOOLPRINT = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.BlendPanel1.SuspendLayout()
        CType(Me.GRIDKARIGAR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GRIDKARIGARDETAILS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GRIDWASTAGE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GRIDWASTAGEDETAILS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridStock, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GRIDDETAILS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.TILLDATE)
        Me.BlendPanel1.Controls.Add(Me.lblto)
        Me.BlendPanel1.Controls.Add(Me.TXTLOSS)
        Me.BlendPanel1.Controls.Add(Me.Label1)
        Me.BlendPanel1.Controls.Add(Me.TXTTOTALGROSS)
        Me.BlendPanel1.Controls.Add(Me.Label3)
        Me.BlendPanel1.Controls.Add(Me.GRIDKARIGAR)
        Me.BlendPanel1.Controls.Add(Me.GRIDWASTAGE)
        Me.BlendPanel1.Controls.Add(Me.CMDOK)
        Me.BlendPanel1.Controls.Add(Me.gridStock)
        Me.BlendPanel1.Controls.Add(Me.ToolStrip1)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1234, 581)
        Me.BlendPanel1.TabIndex = 3
        '
        'TILLDATE
        '
        Me.TILLDATE.CustomFormat = "dd/MM/yyyy"
        Me.TILLDATE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TILLDATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TILLDATE.Location = New System.Drawing.Point(96, 2)
        Me.TILLDATE.Name = "TILLDATE"
        Me.TILLDATE.Size = New System.Drawing.Size(90, 23)
        Me.TILLDATE.TabIndex = 489
        '
        'lblto
        '
        Me.lblto.AutoSize = True
        Me.lblto.BackColor = System.Drawing.Color.Transparent
        Me.lblto.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblto.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblto.Location = New System.Drawing.Point(75, 6)
        Me.lblto.Name = "lblto"
        Me.lblto.Size = New System.Drawing.Size(19, 15)
        Me.lblto.TabIndex = 490
        Me.lblto.Text = "To"
        '
        'TXTLOSS
        '
        Me.TXTLOSS.BackColor = System.Drawing.Color.Linen
        Me.TXTLOSS.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTLOSS.ForeColor = System.Drawing.Color.Black
        Me.TXTLOSS.Location = New System.Drawing.Point(822, 560)
        Me.TXTLOSS.Name = "TXTLOSS"
        Me.TXTLOSS.ReadOnly = True
        Me.TXTLOSS.Size = New System.Drawing.Size(70, 22)
        Me.TXTLOSS.TabIndex = 487
        Me.TXTLOSS.TabStop = False
        Me.TXTLOSS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(759, 564)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 14)
        Me.Label1.TabIndex = 488
        Me.Label1.Text = "Total Loss"
        '
        'TXTTOTALGROSS
        '
        Me.TXTTOTALGROSS.BackColor = System.Drawing.Color.Linen
        Me.TXTTOTALGROSS.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTTOTALGROSS.ForeColor = System.Drawing.Color.Black
        Me.TXTTOTALGROSS.Location = New System.Drawing.Point(1030, 560)
        Me.TXTTOTALGROSS.Name = "TXTTOTALGROSS"
        Me.TXTTOTALGROSS.ReadOnly = True
        Me.TXTTOTALGROSS.Size = New System.Drawing.Size(111, 22)
        Me.TXTTOTALGROSS.TabIndex = 485
        Me.TXTTOTALGROSS.TabStop = False
        Me.TXTTOTALGROSS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(962, 564)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 14)
        Me.Label3.TabIndex = 486
        Me.Label3.Text = "Total Stock"
        '
        'GRIDKARIGAR
        '
        Me.GRIDKARIGAR.EmbeddedNavigator.Appearance.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRIDKARIGAR.EmbeddedNavigator.Appearance.Options.UseFont = True
        Me.GRIDKARIGAR.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRIDKARIGAR.Location = New System.Drawing.Point(822, 265)
        Me.GRIDKARIGAR.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GRIDKARIGAR.MainView = Me.GRIDKARIGARDETAILS
        Me.GRIDKARIGAR.Name = "GRIDKARIGAR"
        Me.GRIDKARIGAR.Size = New System.Drawing.Size(340, 284)
        Me.GRIDKARIGAR.TabIndex = 484
        Me.GRIDKARIGAR.TabStop = False
        Me.GRIDKARIGAR.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GRIDKARIGARDETAILS})
        '
        'GRIDKARIGARDETAILS
        '
        Me.GRIDKARIGARDETAILS.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.GRIDKARIGARDETAILS.Appearance.ColumnFilterButton.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.GRIDKARIGARDETAILS.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.GRIDKARIGARDETAILS.Appearance.ColumnFilterButton.ForeColor = System.Drawing.Color.Black
        Me.GRIDKARIGARDETAILS.Appearance.ColumnFilterButton.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.GRIDKARIGARDETAILS.Appearance.ColumnFilterButton.Options.UseBackColor = True
        Me.GRIDKARIGARDETAILS.Appearance.ColumnFilterButton.Options.UseBorderColor = True
        Me.GRIDKARIGARDETAILS.Appearance.ColumnFilterButton.Options.UseForeColor = True
        Me.GRIDKARIGARDETAILS.Appearance.ColumnFilterButtonActive.BackColor = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GRIDKARIGARDETAILS.Appearance.ColumnFilterButtonActive.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(154, Byte), Integer), CType(CType(190, Byte), Integer), CType(CType(243, Byte), Integer))
        Me.GRIDKARIGARDETAILS.Appearance.ColumnFilterButtonActive.BorderColor = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GRIDKARIGARDETAILS.Appearance.ColumnFilterButtonActive.ForeColor = System.Drawing.Color.Black
        Me.GRIDKARIGARDETAILS.Appearance.ColumnFilterButtonActive.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.GRIDKARIGARDETAILS.Appearance.ColumnFilterButtonActive.Options.UseBackColor = True
        Me.GRIDKARIGARDETAILS.Appearance.ColumnFilterButtonActive.Options.UseBorderColor = True
        Me.GRIDKARIGARDETAILS.Appearance.ColumnFilterButtonActive.Options.UseForeColor = True
        Me.GRIDKARIGARDETAILS.Appearance.Empty.BackColor = System.Drawing.Color.White
        Me.GRIDKARIGARDETAILS.Appearance.Empty.Options.UseBackColor = True
        Me.GRIDKARIGARDETAILS.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.GRIDKARIGARDETAILS.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black
        Me.GRIDKARIGARDETAILS.Appearance.EvenRow.Options.UseBackColor = True
        Me.GRIDKARIGARDETAILS.Appearance.EvenRow.Options.UseForeColor = True
        Me.GRIDKARIGARDETAILS.Appearance.FilterCloseButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.GRIDKARIGARDETAILS.Appearance.FilterCloseButton.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.GRIDKARIGARDETAILS.Appearance.FilterCloseButton.BorderColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.GRIDKARIGARDETAILS.Appearance.FilterCloseButton.ForeColor = System.Drawing.Color.Black
        Me.GRIDKARIGARDETAILS.Appearance.FilterCloseButton.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.GRIDKARIGARDETAILS.Appearance.FilterCloseButton.Options.UseBackColor = True
        Me.GRIDKARIGARDETAILS.Appearance.FilterCloseButton.Options.UseBorderColor = True
        Me.GRIDKARIGARDETAILS.Appearance.FilterCloseButton.Options.UseForeColor = True
        Me.GRIDKARIGARDETAILS.Appearance.FilterPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(62, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.GRIDKARIGARDETAILS.Appearance.FilterPanel.ForeColor = System.Drawing.Color.White
        Me.GRIDKARIGARDETAILS.Appearance.FilterPanel.Options.UseBackColor = True
        Me.GRIDKARIGARDETAILS.Appearance.FilterPanel.Options.UseForeColor = True
        Me.GRIDKARIGARDETAILS.Appearance.FixedLine.BackColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(97, Byte), Integer), CType(CType(156, Byte), Integer))
        Me.GRIDKARIGARDETAILS.Appearance.FixedLine.Options.UseBackColor = True
        Me.GRIDKARIGARDETAILS.Appearance.FocusedCell.BackColor = System.Drawing.Color.White
        Me.GRIDKARIGARDETAILS.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black
        Me.GRIDKARIGARDETAILS.Appearance.FocusedCell.Options.UseBackColor = True
        Me.GRIDKARIGARDETAILS.Appearance.FocusedCell.Options.UseForeColor = True
        Me.GRIDKARIGARDETAILS.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.GRIDKARIGARDETAILS.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White
        Me.GRIDKARIGARDETAILS.Appearance.FocusedRow.Options.UseBackColor = True
        Me.GRIDKARIGARDETAILS.Appearance.FocusedRow.Options.UseForeColor = True
        Me.GRIDKARIGARDETAILS.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.GRIDKARIGARDETAILS.Appearance.FooterPanel.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.GRIDKARIGARDETAILS.Appearance.FooterPanel.BorderColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.GRIDKARIGARDETAILS.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Black
        Me.GRIDKARIGARDETAILS.Appearance.FooterPanel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.GRIDKARIGARDETAILS.Appearance.FooterPanel.Options.UseBackColor = True
        Me.GRIDKARIGARDETAILS.Appearance.FooterPanel.Options.UseBorderColor = True
        Me.GRIDKARIGARDETAILS.Appearance.FooterPanel.Options.UseForeColor = True
        Me.GRIDKARIGARDETAILS.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.GRIDKARIGARDETAILS.Appearance.GroupButton.BorderColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.GRIDKARIGARDETAILS.Appearance.GroupButton.ForeColor = System.Drawing.Color.Black
        Me.GRIDKARIGARDETAILS.Appearance.GroupButton.Options.UseBackColor = True
        Me.GRIDKARIGARDETAILS.Appearance.GroupButton.Options.UseBorderColor = True
        Me.GRIDKARIGARDETAILS.Appearance.GroupButton.Options.UseForeColor = True
        Me.GRIDKARIGARDETAILS.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.GRIDKARIGARDETAILS.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.GRIDKARIGARDETAILS.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Black
        Me.GRIDKARIGARDETAILS.Appearance.GroupFooter.Options.UseBackColor = True
        Me.GRIDKARIGARDETAILS.Appearance.GroupFooter.Options.UseBorderColor = True
        Me.GRIDKARIGARDETAILS.Appearance.GroupFooter.Options.UseForeColor = True
        Me.GRIDKARIGARDETAILS.Appearance.GroupPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(62, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.GRIDKARIGARDETAILS.Appearance.GroupPanel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.GRIDKARIGARDETAILS.Appearance.GroupPanel.Options.UseBackColor = True
        Me.GRIDKARIGARDETAILS.Appearance.GroupPanel.Options.UseForeColor = True
        Me.GRIDKARIGARDETAILS.Appearance.GroupRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.GRIDKARIGARDETAILS.Appearance.GroupRow.BorderColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.GRIDKARIGARDETAILS.Appearance.GroupRow.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.GRIDKARIGARDETAILS.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black
        Me.GRIDKARIGARDETAILS.Appearance.GroupRow.Options.UseBackColor = True
        Me.GRIDKARIGARDETAILS.Appearance.GroupRow.Options.UseBorderColor = True
        Me.GRIDKARIGARDETAILS.Appearance.GroupRow.Options.UseFont = True
        Me.GRIDKARIGARDETAILS.Appearance.GroupRow.Options.UseForeColor = True
        Me.GRIDKARIGARDETAILS.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.GRIDKARIGARDETAILS.Appearance.HeaderPanel.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.GRIDKARIGARDETAILS.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.GRIDKARIGARDETAILS.Appearance.HeaderPanel.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.GRIDKARIGARDETAILS.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black
        Me.GRIDKARIGARDETAILS.Appearance.HeaderPanel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.GRIDKARIGARDETAILS.Appearance.HeaderPanel.Options.UseBackColor = True
        Me.GRIDKARIGARDETAILS.Appearance.HeaderPanel.Options.UseBorderColor = True
        Me.GRIDKARIGARDETAILS.Appearance.HeaderPanel.Options.UseFont = True
        Me.GRIDKARIGARDETAILS.Appearance.HeaderPanel.Options.UseForeColor = True
        Me.GRIDKARIGARDETAILS.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(106, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.GRIDKARIGARDETAILS.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.GRIDKARIGARDETAILS.Appearance.HideSelectionRow.Options.UseBackColor = True
        Me.GRIDKARIGARDETAILS.Appearance.HideSelectionRow.Options.UseForeColor = True
        Me.GRIDKARIGARDETAILS.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(CType(CType(99, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.GRIDKARIGARDETAILS.Appearance.HorzLine.Options.UseBackColor = True
        Me.GRIDKARIGARDETAILS.Appearance.OddRow.BackColor = System.Drawing.Color.White
        Me.GRIDKARIGARDETAILS.Appearance.OddRow.ForeColor = System.Drawing.Color.Black
        Me.GRIDKARIGARDETAILS.Appearance.OddRow.Options.UseBackColor = True
        Me.GRIDKARIGARDETAILS.Appearance.OddRow.Options.UseForeColor = True
        Me.GRIDKARIGARDETAILS.Appearance.Preview.BackColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GRIDKARIGARDETAILS.Appearance.Preview.ForeColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.GRIDKARIGARDETAILS.Appearance.Preview.Options.UseBackColor = True
        Me.GRIDKARIGARDETAILS.Appearance.Preview.Options.UseForeColor = True
        Me.GRIDKARIGARDETAILS.Appearance.Row.BackColor = System.Drawing.Color.White
        Me.GRIDKARIGARDETAILS.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.GRIDKARIGARDETAILS.Appearance.Row.ForeColor = System.Drawing.Color.Black
        Me.GRIDKARIGARDETAILS.Appearance.Row.Options.UseBackColor = True
        Me.GRIDKARIGARDETAILS.Appearance.Row.Options.UseFont = True
        Me.GRIDKARIGARDETAILS.Appearance.Row.Options.UseForeColor = True
        Me.GRIDKARIGARDETAILS.Appearance.RowSeparator.BackColor = System.Drawing.Color.White
        Me.GRIDKARIGARDETAILS.Appearance.RowSeparator.Options.UseBackColor = True
        Me.GRIDKARIGARDETAILS.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(126, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.GRIDKARIGARDETAILS.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White
        Me.GRIDKARIGARDETAILS.Appearance.SelectedRow.Options.UseBackColor = True
        Me.GRIDKARIGARDETAILS.Appearance.SelectedRow.Options.UseForeColor = True
        Me.GRIDKARIGARDETAILS.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(CType(CType(99, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.GRIDKARIGARDETAILS.Appearance.VertLine.Options.UseBackColor = True
        Me.GRIDKARIGARDETAILS.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GNAME, Me.GKARIGARFINE})
        Me.GRIDKARIGARDETAILS.GridControl = Me.GRIDKARIGAR
        Me.GRIDKARIGARDETAILS.Name = "GRIDKARIGARDETAILS"
        Me.GRIDKARIGARDETAILS.OptionsBehavior.AllowIncrementalSearch = True
        Me.GRIDKARIGARDETAILS.OptionsBehavior.Editable = False
        Me.GRIDKARIGARDETAILS.OptionsBehavior.SummariesIgnoreNullValues = True
        Me.GRIDKARIGARDETAILS.OptionsCustomization.AllowColumnMoving = False
        Me.GRIDKARIGARDETAILS.OptionsCustomization.AllowColumnResizing = False
        Me.GRIDKARIGARDETAILS.OptionsCustomization.AllowGroup = False
        Me.GRIDKARIGARDETAILS.OptionsCustomization.AllowQuickHideColumns = False
        Me.GRIDKARIGARDETAILS.OptionsMenu.EnableColumnMenu = False
        Me.GRIDKARIGARDETAILS.OptionsMenu.EnableGroupPanelMenu = False
        Me.GRIDKARIGARDETAILS.OptionsMenu.ShowGroupSortSummaryItems = False
        Me.GRIDKARIGARDETAILS.OptionsView.ColumnAutoWidth = False
        Me.GRIDKARIGARDETAILS.OptionsView.EnableAppearanceEvenRow = True
        Me.GRIDKARIGARDETAILS.OptionsView.EnableAppearanceOddRow = True
        Me.GRIDKARIGARDETAILS.OptionsView.ShowFooter = True
        Me.GRIDKARIGARDETAILS.OptionsView.ShowGroupPanel = False
        '
        'GNAME
        '
        Me.GNAME.Caption = "Karigar Name"
        Me.GNAME.FieldName = "NAME"
        Me.GNAME.Name = "GNAME"
        Me.GNAME.Visible = True
        Me.GNAME.VisibleIndex = 0
        Me.GNAME.Width = 190
        '
        'GKARIGARFINE
        '
        Me.GKARIGARFINE.Caption = "Fine Wt"
        Me.GKARIGARFINE.DisplayFormat.FormatString = "0.000"
        Me.GKARIGARFINE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GKARIGARFINE.FieldName = "FINEWT"
        Me.GKARIGARFINE.Name = "GKARIGARFINE"
        Me.GKARIGARFINE.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GKARIGARFINE.Visible = True
        Me.GKARIGARFINE.VisibleIndex = 1
        Me.GKARIGARFINE.Width = 100
        '
        'GRIDWASTAGE
        '
        Me.GRIDWASTAGE.EmbeddedNavigator.Appearance.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRIDWASTAGE.EmbeddedNavigator.Appearance.Options.UseFont = True
        Me.GRIDWASTAGE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRIDWASTAGE.Location = New System.Drawing.Point(822, 28)
        Me.GRIDWASTAGE.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GRIDWASTAGE.MainView = Me.GRIDWASTAGEDETAILS
        Me.GRIDWASTAGE.Name = "GRIDWASTAGE"
        Me.GRIDWASTAGE.Size = New System.Drawing.Size(340, 231)
        Me.GRIDWASTAGE.TabIndex = 483
        Me.GRIDWASTAGE.TabStop = False
        Me.GRIDWASTAGE.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GRIDWASTAGEDETAILS})
        '
        'GRIDWASTAGEDETAILS
        '
        Me.GRIDWASTAGEDETAILS.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.GRIDWASTAGEDETAILS.Appearance.ColumnFilterButton.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.GRIDWASTAGEDETAILS.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.GRIDWASTAGEDETAILS.Appearance.ColumnFilterButton.ForeColor = System.Drawing.Color.Black
        Me.GRIDWASTAGEDETAILS.Appearance.ColumnFilterButton.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.GRIDWASTAGEDETAILS.Appearance.ColumnFilterButton.Options.UseBackColor = True
        Me.GRIDWASTAGEDETAILS.Appearance.ColumnFilterButton.Options.UseBorderColor = True
        Me.GRIDWASTAGEDETAILS.Appearance.ColumnFilterButton.Options.UseForeColor = True
        Me.GRIDWASTAGEDETAILS.Appearance.ColumnFilterButtonActive.BackColor = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GRIDWASTAGEDETAILS.Appearance.ColumnFilterButtonActive.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(154, Byte), Integer), CType(CType(190, Byte), Integer), CType(CType(243, Byte), Integer))
        Me.GRIDWASTAGEDETAILS.Appearance.ColumnFilterButtonActive.BorderColor = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GRIDWASTAGEDETAILS.Appearance.ColumnFilterButtonActive.ForeColor = System.Drawing.Color.Black
        Me.GRIDWASTAGEDETAILS.Appearance.ColumnFilterButtonActive.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.GRIDWASTAGEDETAILS.Appearance.ColumnFilterButtonActive.Options.UseBackColor = True
        Me.GRIDWASTAGEDETAILS.Appearance.ColumnFilterButtonActive.Options.UseBorderColor = True
        Me.GRIDWASTAGEDETAILS.Appearance.ColumnFilterButtonActive.Options.UseForeColor = True
        Me.GRIDWASTAGEDETAILS.Appearance.Empty.BackColor = System.Drawing.Color.White
        Me.GRIDWASTAGEDETAILS.Appearance.Empty.Options.UseBackColor = True
        Me.GRIDWASTAGEDETAILS.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.GRIDWASTAGEDETAILS.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black
        Me.GRIDWASTAGEDETAILS.Appearance.EvenRow.Options.UseBackColor = True
        Me.GRIDWASTAGEDETAILS.Appearance.EvenRow.Options.UseForeColor = True
        Me.GRIDWASTAGEDETAILS.Appearance.FilterCloseButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.GRIDWASTAGEDETAILS.Appearance.FilterCloseButton.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.GRIDWASTAGEDETAILS.Appearance.FilterCloseButton.BorderColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.GRIDWASTAGEDETAILS.Appearance.FilterCloseButton.ForeColor = System.Drawing.Color.Black
        Me.GRIDWASTAGEDETAILS.Appearance.FilterCloseButton.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.GRIDWASTAGEDETAILS.Appearance.FilterCloseButton.Options.UseBackColor = True
        Me.GRIDWASTAGEDETAILS.Appearance.FilterCloseButton.Options.UseBorderColor = True
        Me.GRIDWASTAGEDETAILS.Appearance.FilterCloseButton.Options.UseForeColor = True
        Me.GRIDWASTAGEDETAILS.Appearance.FilterPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(62, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.GRIDWASTAGEDETAILS.Appearance.FilterPanel.ForeColor = System.Drawing.Color.White
        Me.GRIDWASTAGEDETAILS.Appearance.FilterPanel.Options.UseBackColor = True
        Me.GRIDWASTAGEDETAILS.Appearance.FilterPanel.Options.UseForeColor = True
        Me.GRIDWASTAGEDETAILS.Appearance.FixedLine.BackColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(97, Byte), Integer), CType(CType(156, Byte), Integer))
        Me.GRIDWASTAGEDETAILS.Appearance.FixedLine.Options.UseBackColor = True
        Me.GRIDWASTAGEDETAILS.Appearance.FocusedCell.BackColor = System.Drawing.Color.White
        Me.GRIDWASTAGEDETAILS.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black
        Me.GRIDWASTAGEDETAILS.Appearance.FocusedCell.Options.UseBackColor = True
        Me.GRIDWASTAGEDETAILS.Appearance.FocusedCell.Options.UseForeColor = True
        Me.GRIDWASTAGEDETAILS.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.GRIDWASTAGEDETAILS.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White
        Me.GRIDWASTAGEDETAILS.Appearance.FocusedRow.Options.UseBackColor = True
        Me.GRIDWASTAGEDETAILS.Appearance.FocusedRow.Options.UseForeColor = True
        Me.GRIDWASTAGEDETAILS.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.GRIDWASTAGEDETAILS.Appearance.FooterPanel.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.GRIDWASTAGEDETAILS.Appearance.FooterPanel.BorderColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.GRIDWASTAGEDETAILS.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Black
        Me.GRIDWASTAGEDETAILS.Appearance.FooterPanel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.GRIDWASTAGEDETAILS.Appearance.FooterPanel.Options.UseBackColor = True
        Me.GRIDWASTAGEDETAILS.Appearance.FooterPanel.Options.UseBorderColor = True
        Me.GRIDWASTAGEDETAILS.Appearance.FooterPanel.Options.UseForeColor = True
        Me.GRIDWASTAGEDETAILS.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.GRIDWASTAGEDETAILS.Appearance.GroupButton.BorderColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.GRIDWASTAGEDETAILS.Appearance.GroupButton.ForeColor = System.Drawing.Color.Black
        Me.GRIDWASTAGEDETAILS.Appearance.GroupButton.Options.UseBackColor = True
        Me.GRIDWASTAGEDETAILS.Appearance.GroupButton.Options.UseBorderColor = True
        Me.GRIDWASTAGEDETAILS.Appearance.GroupButton.Options.UseForeColor = True
        Me.GRIDWASTAGEDETAILS.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.GRIDWASTAGEDETAILS.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.GRIDWASTAGEDETAILS.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Black
        Me.GRIDWASTAGEDETAILS.Appearance.GroupFooter.Options.UseBackColor = True
        Me.GRIDWASTAGEDETAILS.Appearance.GroupFooter.Options.UseBorderColor = True
        Me.GRIDWASTAGEDETAILS.Appearance.GroupFooter.Options.UseForeColor = True
        Me.GRIDWASTAGEDETAILS.Appearance.GroupPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(62, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.GRIDWASTAGEDETAILS.Appearance.GroupPanel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.GRIDWASTAGEDETAILS.Appearance.GroupPanel.Options.UseBackColor = True
        Me.GRIDWASTAGEDETAILS.Appearance.GroupPanel.Options.UseForeColor = True
        Me.GRIDWASTAGEDETAILS.Appearance.GroupRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.GRIDWASTAGEDETAILS.Appearance.GroupRow.BorderColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.GRIDWASTAGEDETAILS.Appearance.GroupRow.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.GRIDWASTAGEDETAILS.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black
        Me.GRIDWASTAGEDETAILS.Appearance.GroupRow.Options.UseBackColor = True
        Me.GRIDWASTAGEDETAILS.Appearance.GroupRow.Options.UseBorderColor = True
        Me.GRIDWASTAGEDETAILS.Appearance.GroupRow.Options.UseFont = True
        Me.GRIDWASTAGEDETAILS.Appearance.GroupRow.Options.UseForeColor = True
        Me.GRIDWASTAGEDETAILS.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.GRIDWASTAGEDETAILS.Appearance.HeaderPanel.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.GRIDWASTAGEDETAILS.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.GRIDWASTAGEDETAILS.Appearance.HeaderPanel.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.GRIDWASTAGEDETAILS.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black
        Me.GRIDWASTAGEDETAILS.Appearance.HeaderPanel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.GRIDWASTAGEDETAILS.Appearance.HeaderPanel.Options.UseBackColor = True
        Me.GRIDWASTAGEDETAILS.Appearance.HeaderPanel.Options.UseBorderColor = True
        Me.GRIDWASTAGEDETAILS.Appearance.HeaderPanel.Options.UseFont = True
        Me.GRIDWASTAGEDETAILS.Appearance.HeaderPanel.Options.UseForeColor = True
        Me.GRIDWASTAGEDETAILS.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(106, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.GRIDWASTAGEDETAILS.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.GRIDWASTAGEDETAILS.Appearance.HideSelectionRow.Options.UseBackColor = True
        Me.GRIDWASTAGEDETAILS.Appearance.HideSelectionRow.Options.UseForeColor = True
        Me.GRIDWASTAGEDETAILS.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(CType(CType(99, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.GRIDWASTAGEDETAILS.Appearance.HorzLine.Options.UseBackColor = True
        Me.GRIDWASTAGEDETAILS.Appearance.OddRow.BackColor = System.Drawing.Color.White
        Me.GRIDWASTAGEDETAILS.Appearance.OddRow.ForeColor = System.Drawing.Color.Black
        Me.GRIDWASTAGEDETAILS.Appearance.OddRow.Options.UseBackColor = True
        Me.GRIDWASTAGEDETAILS.Appearance.OddRow.Options.UseForeColor = True
        Me.GRIDWASTAGEDETAILS.Appearance.Preview.BackColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GRIDWASTAGEDETAILS.Appearance.Preview.ForeColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.GRIDWASTAGEDETAILS.Appearance.Preview.Options.UseBackColor = True
        Me.GRIDWASTAGEDETAILS.Appearance.Preview.Options.UseForeColor = True
        Me.GRIDWASTAGEDETAILS.Appearance.Row.BackColor = System.Drawing.Color.White
        Me.GRIDWASTAGEDETAILS.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.GRIDWASTAGEDETAILS.Appearance.Row.ForeColor = System.Drawing.Color.Black
        Me.GRIDWASTAGEDETAILS.Appearance.Row.Options.UseBackColor = True
        Me.GRIDWASTAGEDETAILS.Appearance.Row.Options.UseFont = True
        Me.GRIDWASTAGEDETAILS.Appearance.Row.Options.UseForeColor = True
        Me.GRIDWASTAGEDETAILS.Appearance.RowSeparator.BackColor = System.Drawing.Color.White
        Me.GRIDWASTAGEDETAILS.Appearance.RowSeparator.Options.UseBackColor = True
        Me.GRIDWASTAGEDETAILS.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(126, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.GRIDWASTAGEDETAILS.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White
        Me.GRIDWASTAGEDETAILS.Appearance.SelectedRow.Options.UseBackColor = True
        Me.GRIDWASTAGEDETAILS.Appearance.SelectedRow.Options.UseForeColor = True
        Me.GRIDWASTAGEDETAILS.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(CType(CType(99, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.GRIDWASTAGEDETAILS.Appearance.VertLine.Options.UseBackColor = True
        Me.GRIDWASTAGEDETAILS.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GWASTAGE, Me.GWASTAGEFINE})
        Me.GRIDWASTAGEDETAILS.GridControl = Me.GRIDWASTAGE
        Me.GRIDWASTAGEDETAILS.Name = "GRIDWASTAGEDETAILS"
        Me.GRIDWASTAGEDETAILS.OptionsBehavior.AllowIncrementalSearch = True
        Me.GRIDWASTAGEDETAILS.OptionsBehavior.Editable = False
        Me.GRIDWASTAGEDETAILS.OptionsBehavior.SummariesIgnoreNullValues = True
        Me.GRIDWASTAGEDETAILS.OptionsCustomization.AllowColumnMoving = False
        Me.GRIDWASTAGEDETAILS.OptionsCustomization.AllowColumnResizing = False
        Me.GRIDWASTAGEDETAILS.OptionsCustomization.AllowGroup = False
        Me.GRIDWASTAGEDETAILS.OptionsCustomization.AllowQuickHideColumns = False
        Me.GRIDWASTAGEDETAILS.OptionsMenu.EnableColumnMenu = False
        Me.GRIDWASTAGEDETAILS.OptionsMenu.EnableGroupPanelMenu = False
        Me.GRIDWASTAGEDETAILS.OptionsMenu.ShowGroupSortSummaryItems = False
        Me.GRIDWASTAGEDETAILS.OptionsView.ColumnAutoWidth = False
        Me.GRIDWASTAGEDETAILS.OptionsView.EnableAppearanceEvenRow = True
        Me.GRIDWASTAGEDETAILS.OptionsView.EnableAppearanceOddRow = True
        Me.GRIDWASTAGEDETAILS.OptionsView.ShowFooter = True
        Me.GRIDWASTAGEDETAILS.OptionsView.ShowGroupPanel = False
        '
        'GWASTAGE
        '
        Me.GWASTAGE.Caption = "Wastage/Vaccum"
        Me.GWASTAGE.FieldName = "WASTAGE"
        Me.GWASTAGE.Name = "GWASTAGE"
        Me.GWASTAGE.Visible = True
        Me.GWASTAGE.VisibleIndex = 0
        Me.GWASTAGE.Width = 190
        '
        'GWASTAGEFINE
        '
        Me.GWASTAGEFINE.Caption = "Fine Wt"
        Me.GWASTAGEFINE.DisplayFormat.FormatString = "0.000"
        Me.GWASTAGEFINE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GWASTAGEFINE.FieldName = "FINEWT"
        Me.GWASTAGEFINE.Name = "GWASTAGEFINE"
        Me.GWASTAGEFINE.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GWASTAGEFINE.Visible = True
        Me.GWASTAGEFINE.VisibleIndex = 1
        Me.GWASTAGEFINE.Width = 100
        '
        'CMDOK
        '
        Me.CMDOK.BackColor = System.Drawing.Color.Transparent
        Me.CMDOK.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDOK.FlatAppearance.BorderSize = 0
        Me.CMDOK.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDOK.ForeColor = System.Drawing.Color.Black
        Me.CMDOK.Location = New System.Drawing.Point(505, 556)
        Me.CMDOK.Name = "CMDOK"
        Me.CMDOK.Size = New System.Drawing.Size(80, 28)
        Me.CMDOK.TabIndex = 482
        Me.CMDOK.Text = "&Ok"
        Me.CMDOK.UseVisualStyleBackColor = False
        '
        'gridStock
        '
        Me.gridStock.EmbeddedNavigator.Appearance.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridStock.EmbeddedNavigator.Appearance.Options.UseFont = True
        Me.gridStock.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridStock.Location = New System.Drawing.Point(15, 28)
        Me.gridStock.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridStock.MainView = Me.GRIDDETAILS
        Me.gridStock.Name = "gridStock"
        Me.gridStock.Size = New System.Drawing.Size(794, 521)
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
        Me.GGROSSWT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
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
        Me.GNETTWT.Caption = "Fine Wt."
        Me.GNETTWT.DisplayFormat.FormatString = "0.000"
        Me.GNETTWT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GNETTWT.FieldName = "NETTWT"
        Me.GNETTWT.Name = "GNETTWT"
        Me.GNETTWT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GNETTWT.Visible = True
        Me.GNETTWT.VisibleIndex = 4
        Me.GNETTWT.Width = 100
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TOOLREFRESH, Me.ToolStripSeparator1, Me.TOOLPRINT, Me.ToolStripSeparator2})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1234, 25)
        Me.ToolStrip1.TabIndex = 480
        Me.ToolStrip1.Text = "ToolStrip1"
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
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'TOOLPRINT
        '
        Me.TOOLPRINT.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TOOLPRINT.Image = Global.Magic_Gold.My.Resources.Resources._1_Normal_Printer_icon
        Me.TOOLPRINT.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TOOLPRINT.Name = "TOOLPRINT"
        Me.TOOLPRINT.Size = New System.Drawing.Size(23, 22)
        Me.TOOLPRINT.Text = "ToolStripButton1"
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
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.Black
        Me.cmdexit.Location = New System.Drawing.Point(591, 555)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 28)
        Me.cmdexit.TabIndex = 7
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'StockWithKarigarWastageFine
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1234, 581)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "StockWithKarigarWastageFine"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Stock With Karigar Wastage Fine"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.GRIDKARIGAR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GRIDKARIGARDETAILS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GRIDWASTAGE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GRIDWASTAGEDETAILS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridStock, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GRIDDETAILS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents TILLDATE As DateTimePicker
    Friend WithEvents lblto As Label
    Friend WithEvents TXTLOSS As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TXTTOTALGROSS As TextBox
    Friend WithEvents Label3 As Label
    Private WithEvents GRIDKARIGAR As DevExpress.XtraGrid.GridControl
    Friend WithEvents GRIDKARIGARDETAILS As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GKARIGARFINE As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents GRIDWASTAGE As DevExpress.XtraGrid.GridControl
    Friend WithEvents GRIDWASTAGEDETAILS As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GWASTAGE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GWASTAGEFINE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CMDOK As Button
    Private WithEvents gridStock As DevExpress.XtraGrid.GridControl
    Friend WithEvents GRIDDETAILS As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GITEMCODE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GNARRATION As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gpurity As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GGROSSWT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GNETTWT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents TOOLREFRESH As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents TOOLPRINT As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents cmdexit As Button
End Class
