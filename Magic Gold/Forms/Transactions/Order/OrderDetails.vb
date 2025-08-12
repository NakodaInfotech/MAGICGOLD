
Imports System.Windows.Forms
Imports System.Data.OleDb
Imports System.ComponentModel.Component
Imports System.Diagnostics
Imports DevExpress.XtraGrid.Views.Grid

Public Class OrderDetails

    Private Sub OrderDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then Me.Close()
    End Sub

    Sub fillgrid(ByVal tempcondition)
        Try
            dt = New DataTable()
            If tempconn.State = ConnectionState.Open Then tempconn.Close()
            tempconn.Open()
            tempcmd = New OleDbCommand(" SELECT OrderMaster.ORDER_SRNO AS SRNO, OrderMaster.ORDER_NO AS ORDERNO, OrderMaster.ORDER_DATE AS [DATE] , ledgermaster.ledger_code AS [NAME], ItemMaster.item_code AS ITEMNAME, OrderMaster.ORDER_GOLDWT AS GOLDWT, ORDERMASTER.ORDER_MELTING AS MELTING, OrderMaster.ORDER_CTWT AS CTWT, IIF(OrderMaster.ORDER_GOLDWT - OrderMaster.ORDER_MFGWT > 0, OrderMaster.ORDER_GOLDWT - OrderMaster.ORDER_MFGWT, 0) AS PENDING, OrderMaster.ORDER_REMARKS AS [REMARKS], OrderMaster.ORDER_CLOSE AS [CLOSED], OrderMaster.ORDER_DONE AS [DONE] FROM (OrderMaster INNER JOIN ledgermaster ON OrderMaster.ORDER_LEDGERID = ledgermaster.ledger_id) INNER JOIN ItemMaster ON OrderMaster.ORDER_ITEMID = ItemMaster.item_id  order by ORDER_SRNO", tempconn)
            da = New OleDbDataAdapter(tempcmd)
            da.Fill(dt)
            griddetails.DataSource = dt

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform(ByVal editval As Boolean, ByVal billno As Integer)
        Try
            If (editval = False) Or (editval = True And gridbill.RowCount > 0) Then
                Dim OBJORDER As New OrderMaster
                OBJORDER.MdiParent = MDIMain
                OBJORDER.edit = editval
                OBJORDER.TEMPORDERNO = billno
                OBJORDER.Show()
                Me.Close()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Try
            showform(False, 0)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridcontra_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridbill.DoubleClick
        Try
            showform(True, gridbill.GetFocusedRowCellValue("SRNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub OrderDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        fillgrid("")
    End Sub

    Private Sub cmdcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancel.Click
        Me.Close()
    End Sub

    Private Sub CMDOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDOK.Click
        Try
            showform(True, gridbill.GetFocusedRowCellValue("SRNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ExcelExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExcelExport.Click
        Try
            Dim PATH As String = ""
            If FileIO.FileSystem.FileExists(PATH) = True Then FileIO.FileSystem.DeleteFile(PATH)
            PATH = Application.StartupPath & "\Order Details.XLS"

            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            For Each proc As System.Diagnostics.Process In System.Diagnostics.Process.GetProcessesByName("Excel")
                proc.Kill()
            Next

            opti.SheetName = "Order Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Order Details", gridbill.VisibleColumns.Count + gridbill.GroupCount)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub OrderDetails_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If ClientName <> "MIMARAGEMS" And ClientName <> "JAINAM" Then Me.Close()
    End Sub

    Private Sub gridcontra_RowStyle(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles gridbill.RowStyle
        Try
            Dim DT As DataTable = griddetails.DataSource
            If gridbill.RowFilter = "" Then
                If e.RowHandle >= 0 Then
                    Dim ROW As DataRow = DT.Rows(e.RowHandle)
                    Dim View As GridView = sender
                    If View.GetRowCellDisplayText(e.RowHandle, View.Columns("CLOSED")) = "Checked" Then
                        e.Appearance.Font = New System.Drawing.Font("CALIBRI", 9.0F, System.Drawing.FontStyle.Regular)
                        e.Appearance.BackColor = Color.Yellow
                    ElseIf View.GetRowCellDisplayText(e.RowHandle, View.Columns("DONE")) = "Checked" Then
                        e.Appearance.Font = New System.Drawing.Font("CALIBRI", 9.0F, System.Drawing.FontStyle.Regular)
                        e.Appearance.BackColor = Color.LightGreen
                    ElseIf View.GetRowCellDisplayText(e.RowHandle, View.Columns("PENDING")) > 0 Then
                        e.Appearance.Font = New System.Drawing.Font("CALIBRI", 9.0F, System.Drawing.FontStyle.Regular)
                        e.Appearance.BackColor = Color.Thistle
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TOOLREFRESH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLREFRESH.Click
        fillgrid("")
    End Sub
End Class