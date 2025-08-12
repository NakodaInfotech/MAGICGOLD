<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StockTransferAccept
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
        Me.CMDDELETE = New System.Windows.Forms.Button()
        Me.CMDOK = New System.Windows.Forms.Button()
        Me.CMDREFRESH = New System.Windows.Forms.Button()
        Me.cmdcancel = New System.Windows.Forms.Button()
        Me.RBACCEPTED = New System.Windows.Forms.RadioButton()
        Me.RBPENDING = New System.Windows.Forms.RadioButton()
        Me.griddetails = New DevExpress.XtraGrid.GridControl()
        Me.GRIDBILL = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GACCEPTED = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CHKEDIT = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.GSTNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GFROMDEPT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTODEPT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GITEMNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPCS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GGROSSWT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPURITY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GWASTAGE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GFINEWT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GREMARKS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GGRIDSRNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BlendPanel1.SuspendLayout()
        CType(Me.griddetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GRIDBILL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CHKEDIT, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.CMDDELETE)
        Me.BlendPanel1.Controls.Add(Me.CMDOK)
        Me.BlendPanel1.Controls.Add(Me.CMDREFRESH)
        Me.BlendPanel1.Controls.Add(Me.cmdcancel)
        Me.BlendPanel1.Controls.Add(Me.RBACCEPTED)
        Me.BlendPanel1.Controls.Add(Me.RBPENDING)
        Me.BlendPanel1.Controls.Add(Me.griddetails)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1084, 561)
        Me.BlendPanel1.TabIndex = 6
        '
        'CMDDELETE
        '
        Me.CMDDELETE.BackColor = System.Drawing.Color.Transparent
        Me.CMDDELETE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDDELETE.FlatAppearance.BorderSize = 0
        Me.CMDDELETE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDDELETE.ForeColor = System.Drawing.Color.Black
        Me.CMDDELETE.Location = New System.Drawing.Point(460, 512)
        Me.CMDDELETE.Name = "CMDDELETE"
        Me.CMDDELETE.Size = New System.Drawing.Size(80, 28)
        Me.CMDDELETE.TabIndex = 808
        Me.CMDDELETE.Text = "&Delete"
        Me.CMDDELETE.UseVisualStyleBackColor = False
        '
        'CMDOK
        '
        Me.CMDOK.BackColor = System.Drawing.Color.Transparent
        Me.CMDOK.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDOK.FlatAppearance.BorderSize = 0
        Me.CMDOK.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDOK.ForeColor = System.Drawing.Color.Black
        Me.CMDOK.Location = New System.Drawing.Point(375, 512)
        Me.CMDOK.Name = "CMDOK"
        Me.CMDOK.Size = New System.Drawing.Size(80, 28)
        Me.CMDOK.TabIndex = 805
        Me.CMDOK.Text = "&Save"
        Me.CMDOK.UseVisualStyleBackColor = False
        '
        'CMDREFRESH
        '
        Me.CMDREFRESH.BackColor = System.Drawing.Color.Transparent
        Me.CMDREFRESH.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDREFRESH.FlatAppearance.BorderSize = 0
        Me.CMDREFRESH.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDREFRESH.ForeColor = System.Drawing.Color.Black
        Me.CMDREFRESH.Location = New System.Drawing.Point(545, 512)
        Me.CMDREFRESH.Name = "CMDREFRESH"
        Me.CMDREFRESH.Size = New System.Drawing.Size(80, 28)
        Me.CMDREFRESH.TabIndex = 806
        Me.CMDREFRESH.Text = "&Refresh"
        Me.CMDREFRESH.UseVisualStyleBackColor = False
        '
        'cmdcancel
        '
        Me.cmdcancel.BackColor = System.Drawing.Color.Transparent
        Me.cmdcancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdcancel.FlatAppearance.BorderSize = 0
        Me.cmdcancel.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdcancel.ForeColor = System.Drawing.Color.Black
        Me.cmdcancel.Location = New System.Drawing.Point(630, 512)
        Me.cmdcancel.Name = "cmdcancel"
        Me.cmdcancel.Size = New System.Drawing.Size(80, 28)
        Me.cmdcancel.TabIndex = 807
        Me.cmdcancel.Text = "E&xit"
        Me.cmdcancel.UseVisualStyleBackColor = False
        '
        'RBACCEPTED
        '
        Me.RBACCEPTED.AutoSize = True
        Me.RBACCEPTED.BackColor = System.Drawing.Color.Transparent
        Me.RBACCEPTED.Location = New System.Drawing.Point(90, 12)
        Me.RBACCEPTED.Name = "RBACCEPTED"
        Me.RBACCEPTED.Size = New System.Drawing.Size(74, 19)
        Me.RBACCEPTED.TabIndex = 802
        Me.RBACCEPTED.Text = "Accepted"
        Me.RBACCEPTED.UseVisualStyleBackColor = False
        '
        'RBPENDING
        '
        Me.RBPENDING.AutoSize = True
        Me.RBPENDING.BackColor = System.Drawing.Color.Transparent
        Me.RBPENDING.Checked = True
        Me.RBPENDING.Location = New System.Drawing.Point(15, 12)
        Me.RBPENDING.Name = "RBPENDING"
        Me.RBPENDING.Size = New System.Drawing.Size(69, 19)
        Me.RBPENDING.TabIndex = 801
        Me.RBPENDING.TabStop = True
        Me.RBPENDING.Text = "Pending"
        Me.RBPENDING.UseVisualStyleBackColor = False
        '
        'griddetails
        '
        Me.griddetails.Location = New System.Drawing.Point(15, 43)
        Me.griddetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.griddetails.MainView = Me.GRIDBILL
        Me.griddetails.Name = "griddetails"
        Me.griddetails.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.CHKEDIT})
        Me.griddetails.Size = New System.Drawing.Size(1055, 463)
        Me.griddetails.TabIndex = 315
        Me.griddetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GRIDBILL})
        '
        'GRIDBILL
        '
        Me.GRIDBILL.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRIDBILL.Appearance.Row.Options.UseFont = True
        Me.GRIDBILL.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GACCEPTED, Me.GSTNO, Me.GDATE, Me.GFROMDEPT, Me.GTODEPT, Me.GITEMNAME, Me.GPCS, Me.GGROSSWT, Me.GPURITY, Me.GWASTAGE, Me.GFINEWT, Me.GREMARKS, Me.GGRIDSRNO})
        Me.GRIDBILL.GridControl = Me.griddetails
        Me.GRIDBILL.Name = "GRIDBILL"
        Me.GRIDBILL.OptionsBehavior.AutoExpandAllGroups = True
        Me.GRIDBILL.OptionsView.ColumnAutoWidth = False
        Me.GRIDBILL.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.GRIDBILL.OptionsView.ShowAutoFilterRow = True
        Me.GRIDBILL.OptionsView.ShowFooter = True
        Me.GRIDBILL.OptionsView.ShowGroupPanel = False
        '
        'GACCEPTED
        '
        Me.GACCEPTED.Caption = "Accepted"
        Me.GACCEPTED.ColumnEdit = Me.CHKEDIT
        Me.GACCEPTED.FieldName = "ACCEPTED"
        Me.GACCEPTED.Name = "GACCEPTED"
        Me.GACCEPTED.Visible = True
        Me.GACCEPTED.VisibleIndex = 0
        '
        'CHKEDIT
        '
        Me.CHKEDIT.AutoHeight = False
        Me.CHKEDIT.Name = "CHKEDIT"
        Me.CHKEDIT.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked
        '
        'GSTNO
        '
        Me.GSTNO.Caption = "ST No"
        Me.GSTNO.FieldName = "STNO"
        Me.GSTNO.ImageIndex = 1
        Me.GSTNO.Name = "GSTNO"
        Me.GSTNO.OptionsColumn.AllowEdit = False
        Me.GSTNO.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GSTNO.Visible = True
        Me.GSTNO.VisibleIndex = 1
        Me.GSTNO.Width = 60
        '
        'GDATE
        '
        Me.GDATE.Caption = "Date"
        Me.GDATE.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.GDATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GDATE.FieldName = "STDATE"
        Me.GDATE.Name = "GDATE"
        Me.GDATE.OptionsColumn.AllowEdit = False
        Me.GDATE.Visible = True
        Me.GDATE.VisibleIndex = 2
        Me.GDATE.Width = 80
        '
        'GFROMDEPT
        '
        Me.GFROMDEPT.Caption = "From Dept"
        Me.GFROMDEPT.FieldName = "FROMDEPARTMENT"
        Me.GFROMDEPT.Name = "GFROMDEPT"
        Me.GFROMDEPT.OptionsColumn.AllowEdit = False
        Me.GFROMDEPT.Visible = True
        Me.GFROMDEPT.VisibleIndex = 3
        Me.GFROMDEPT.Width = 120
        '
        'GTODEPT
        '
        Me.GTODEPT.Caption = "To Dept"
        Me.GTODEPT.FieldName = "TODEPARTMENT"
        Me.GTODEPT.Name = "GTODEPT"
        Me.GTODEPT.OptionsColumn.AllowEdit = False
        Me.GTODEPT.Visible = True
        Me.GTODEPT.VisibleIndex = 4
        Me.GTODEPT.Width = 120
        '
        'GITEMNAME
        '
        Me.GITEMNAME.Caption = "Item Name"
        Me.GITEMNAME.FieldName = "ITEMNAME"
        Me.GITEMNAME.Name = "GITEMNAME"
        Me.GITEMNAME.OptionsColumn.AllowEdit = False
        Me.GITEMNAME.Visible = True
        Me.GITEMNAME.VisibleIndex = 5
        Me.GITEMNAME.Width = 120
        '
        'GPCS
        '
        Me.GPCS.Caption = "Pcs"
        Me.GPCS.DisplayFormat.FormatString = "0"
        Me.GPCS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GPCS.FieldName = "PCS"
        Me.GPCS.Name = "GPCS"
        Me.GPCS.OptionsColumn.AllowEdit = False
        Me.GPCS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PCS", "{0:0}")})
        Me.GPCS.Visible = True
        Me.GPCS.VisibleIndex = 6
        Me.GPCS.Width = 50
        '
        'GGROSSWT
        '
        Me.GGROSSWT.Caption = "Gross Wt"
        Me.GGROSSWT.DisplayFormat.FormatString = "0.000"
        Me.GGROSSWT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GGROSSWT.FieldName = "GROSSWT"
        Me.GGROSSWT.Name = "GGROSSWT"
        Me.GGROSSWT.OptionsColumn.AllowEdit = False
        Me.GGROSSWT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "GROSSWT", "{0:0.000}")})
        Me.GGROSSWT.Visible = True
        Me.GGROSSWT.VisibleIndex = 7
        '
        'GPURITY
        '
        Me.GPURITY.Caption = "Purity"
        Me.GPURITY.DisplayFormat.FormatString = "0.00"
        Me.GPURITY.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GPURITY.FieldName = "PURITY"
        Me.GPURITY.Name = "GPURITY"
        Me.GPURITY.OptionsColumn.AllowEdit = False
        Me.GPURITY.Visible = True
        Me.GPURITY.VisibleIndex = 8
        Me.GPURITY.Width = 60
        '
        'GWASTAGE
        '
        Me.GWASTAGE.Caption = "Wastage"
        Me.GWASTAGE.DisplayFormat.FormatString = "0.00"
        Me.GWASTAGE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GWASTAGE.FieldName = "WASTAGE"
        Me.GWASTAGE.Name = "GWASTAGE"
        Me.GWASTAGE.OptionsColumn.AllowEdit = False
        Me.GWASTAGE.Visible = True
        Me.GWASTAGE.VisibleIndex = 9
        Me.GWASTAGE.Width = 60
        '
        'GFINEWT
        '
        Me.GFINEWT.Caption = "Fine Wt"
        Me.GFINEWT.DisplayFormat.FormatString = "0.000"
        Me.GFINEWT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GFINEWT.FieldName = "FINEWT"
        Me.GFINEWT.Name = "GFINEWT"
        Me.GFINEWT.OptionsColumn.AllowEdit = False
        Me.GFINEWT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "FINEWT", "{0:0.000}")})
        Me.GFINEWT.Visible = True
        Me.GFINEWT.VisibleIndex = 10
        '
        'GREMARKS
        '
        Me.GREMARKS.Caption = "Remarks"
        Me.GREMARKS.FieldName = "REMARKS"
        Me.GREMARKS.Name = "GREMARKS"
        Me.GREMARKS.OptionsColumn.AllowEdit = False
        Me.GREMARKS.Visible = True
        Me.GREMARKS.VisibleIndex = 11
        Me.GREMARKS.Width = 110
        '
        'GGRIDSRNO
        '
        Me.GGRIDSRNO.Caption = "GRIDSRNO"
        Me.GGRIDSRNO.FieldName = "GRIDSRNO"
        Me.GGRIDSRNO.Name = "GGRIDSRNO"
        Me.GGRIDSRNO.OptionsColumn.AllowEdit = False
        '
        'StockTransferAccept
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1084, 561)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "StockTransferAccept"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Stock Transfer Accept"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.griddetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GRIDBILL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CHKEDIT, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents griddetails As DevExpress.XtraGrid.GridControl
    Friend WithEvents GRIDBILL As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GSTNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GFROMDEPT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTODEPT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GITEMNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPCS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GGROSSWT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPURITY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GWASTAGE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GFINEWT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GACCEPTED As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GREMARKS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RBACCEPTED As RadioButton
    Friend WithEvents RBPENDING As RadioButton
    Friend WithEvents CMDDELETE As Button
    Friend WithEvents CMDOK As Button
    Friend WithEvents CMDREFRESH As Button
    Friend WithEvents cmdcancel As Button
    Friend WithEvents GGRIDSRNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CHKEDIT As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
End Class
