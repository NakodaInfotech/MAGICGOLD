
Imports System.Data.OleDb

Public Class StockDetails

    Public STRCONDITION As String

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub StockDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                Me.Close()
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub StockDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLGRID()
        Try

            Dim WHERECLAUSE As String = ""
            Dim GROUPBYCLAUSE As String = ""
            If USERDEPARTMENT <> "" Then WHERECLAUSE = WHERECLAUSE & " AND STOCKS.DEPARTMENT = '" & USERDEPARTMENT & "'"
            If USERDEPARTMENT <> "" Then GROUPBYCLAUSE = GROUPBYCLAUSE & ", STOCKS.DEPARTMENT "

            'getting DETAILS
            Dim dt As New DataTable()
            If tempconn.State = ConnectionState.Open Then tempconn.Close()
            tempconn.Open()
            tempcmd = New OleDbCommand(" SELECT * FROM (select  ITEM_CODE AS NAME, ITEM_PURITY AS  PURITY, IIF( SUM(ITEM_GROSSWT) >= 0 , SUM(ITEM_GROSSWT) , 0.00 ) AS  RECGROSS, IIF( SUM(ITEM_NETTWT) >= 0 , SUM(ITEM_NETTWT) , 0.00 ) AS  RECNETT, IIF( SUM(ITEM_GROSSWT) < 0 , (SUM(ITEM_GROSSWT) * (-1)) , 0.00 ) AS  ISSGROSS, IIF( SUM(ITEM_NETTWT) < 0 , (SUM(ITEM_NETTWT) * (-1)) , 0.00 ) AS  ISSNETT , SUM(ITEM_NETTWT) AS NETT from STOCKS " & STRCONDITION & WHERECLAUSE & " GROUP BY ITEM_CODE, ITEM_PURITY " & GROUPBYCLAUSE & " ) AS T  WHERE T.NETT <> 0  order by T.NAME", tempconn)
            da = New OleDbDataAdapter(tempcmd)
            da.Fill(dt)
            gridStock.DataSource = dt

            total()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub total()
        Try
            txtbalgross.Text = Format(Val(grecgrosswt.SummaryText) - Val(gissuegrosswt.SummaryText), "0.000")
            txtbalnett.Text = Format(Val(grecnettwt.SummaryText) - Val(gissuenettwt.SummaryText), "0.000")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridbandstock_ColumnFilterChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridbandstock.ColumnFilterChanged
        Try
            total()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try

            'Dim CONDITION As String = ""

            'Dim objrep As New clsReportDesigner("Stock Details", System.AppDomain.CurrentDomain.BaseDirectory & "Stock Details.xlsx", 2)
            'objrep.STOCK_SUMMARY_EXCEL(gridStock.DataSource, CONDITION)

            Dim PATH As String = ""
            If FileIO.FileSystem.FileExists(PATH) = True Then FileIO.FileSystem.DeleteFile(PATH)
            PATH = Application.StartupPath & "\Stock Details.XLS"

            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            For Each Proc As System.Diagnostics.Process In System.Diagnostics.Process.GetProcessesByName("Excel")
                Proc.Kill()
            Next

            Dim PERIOD As String = ""
            PERIOD = startdate & " - " & enddate

            opti.SheetName = "Stock Details"
            gridbandstock.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Stock Details", gridbandstock.VisibleColumns.Count + gridbandstock.GroupCount, "", PERIOD)



        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EXCEL_ICON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EXCEL_ICON.Click
        Try
            Dim PATH As String = Application.StartupPath & "\Stock Details.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True

            Dim proc As New System.Diagnostics.Process
            For Each proc In System.Diagnostics.Process.GetProcessesByName("Excel")
                proc.Kill()
            Next
            opti.SheetName = "Stock Details"
            gridbandstock.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Stock Details", gridbandstock.VisibleColumns.Count + gridbandstock.GroupCount)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TOOLREFRESH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLREFRESH.Click
        Try
            FILLGRID()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class