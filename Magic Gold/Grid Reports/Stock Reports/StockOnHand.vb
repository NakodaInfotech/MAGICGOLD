
Imports System.Data.OleDb
Imports System.IO

Public Class StockOnHand

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub StockOnHand_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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

    Private Sub StockOnHand_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            FILLGRID()
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
            tempcmd = New OleDbCommand("SELECT STOCKS.ITEM_CODE AS ITEMCODE, STOCKS.NARRATION, STOCKS.ITEM_PURITY AS PURITY, ROUND(Sum(STOCKS.ITEM_GROSSWT),3) AS GROSSWT, ROUND(Sum(STOCKS.ITEM_NETTWT),3) AS NETTWT  FROM Stocks WHERE 1=1 " & WHERECLAUSE & " GROUP BY STOCKS.ITEM_CODE, STOCKS.NARRATION, STOCKS.ITEM_PURITY " & GROUPBYCLAUSE & " HAVING(ROUND(Sum(STOCKS.ITEM_GROSSWT),2) <> 0 Or ROUND(Sum(STOCKS.ITEM_NETTWT),2)) ORDER BY STOCKS.ITEM_CODE", tempconn)
            da = New OleDbDataAdapter(tempcmd)
            da.Fill(dt)
            gridStock.DataSource = dt
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EXCEL_ICON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EXCEL_ICON.Click
        Try
            Dim PATH As String = Application.StartupPath & "\Stock On Hand.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True

            Dim proc As New System.Diagnostics.Process
            For Each proc In System.Diagnostics.Process.GetProcessesByName("Excel")
                proc.Kill()
            Next
            opti.SheetName = "Stock On Hand"
            GRIDDETAILS.ExportToXls(PATH, opti)

            EXCELCMPHEADER(PATH, "Stock On Hand", GRIDDETAILS.VisibleColumns.Count + GRIDDETAILS.GroupCount, "", "REPORT AS ON " & Now)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDOK.Click
        Try
            SHOWFORM()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub SHOWFORM()
        Try
            Dim OBJSTSUMM As New StockSummary
            OBJSTSUMM.MdiParent = MDIMain
            OBJSTSUMM.TITEM = GRIDDETAILS.GetFocusedRowCellValue("ITEMCODE")
            OBJSTSUMM.TPURITY = GRIDDETAILS.GetFocusedRowCellValue("PURITY")
            OBJSTSUMM.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDDETAILS_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GRIDDETAILS.DoubleClick
        Try
            SHOWFORM()
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