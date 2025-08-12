
Imports System.Data.OleDb

Public Class StockTransferDetails

    Private Sub StockTransferDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then Me.Close()
    End Sub

    Sub fillgrid(ByVal tempcondition)
        Try
            dt = New DataTable()
            If tempconn.State = ConnectionState.Open Then tempconn.Close()
            tempconn.Open()
            tempcmd = New OleDbCommand(" SELECT STOCKTRANSFER.ST_NO AS STNO, STOCKTRANSFER.ST_DATE AS STDATE, STOCKTRANSFER.ST_SRNO AS SRNO, ItemMaster.item_code AS ITEMNAME, STOCKTRANSFER.ST_ITEMDESC AS ITEMDESC, STOCKTRANSFER.ST_PCS AS PCS, STOCKTRANSFER.ST_GROSSWT AS GROSSWT, STOCKTRANSFER.ST_PURITY AS PURITY, STOCKTRANSFER.ST_WASTAGE AS WASTAGE, STOCKTRANSFER.ST_FINEWT AS FINEWT, STOCKTRANSFER.ST_REMARKS AS REMARKS, IIF(ISNULL(FROMDEPARTMENTMASTER.DEPARTMENT_NAME) = 'TRUE', '', FROMDEPARTMENTMASTER.DEPARTMENT_NAME) AS FROMDEPARTMENT , IIF(ISNULL(TODEPARTMENTMASTER.DEPARTMENT_NAME) = 'TRUE', '', TODEPARTMENTMASTER.DEPARTMENT_NAME) AS TODEPARTMENT, STOCKTRANSFER.ST_ACCEPTED AS ACCEPTED FROM ((STOCKTRANSFER INNER JOIN ItemMaster ON STOCKTRANSFER.ST_ITEMID = ItemMaster.item_id) LEFT JOIN DEPARTMENTMASTER AS FROMDEPARTMENTMASTER ON STOCKTRANSFER.ST_FROMDEPARTMENTID = FROMDEPARTMENTMASTER.DEPARTMENT_ID) LEFT JOIN DEPARTMENTMASTER AS TODEPARTMENTMASTER ON STOCKTRANSFER.ST_TODEPARTMENTID = TODEPARTMENTMASTER.DEPARTMENT_ID  ORDER BY STOCKTRANSFER.ST_NO ", tempconn)
            da = New OleDbDataAdapter(tempcmd)
            da.Fill(dt)
            griddetails.DataSource = dt
            If dt.Rows.Count > 0 Then
                GRIDBILL.FocusedRowHandle = GRIDBILL.RowCount - 1
                GRIDBILL.TopRowIndex = GRIDBILL.RowCount - 15
            End If
            tempconn.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform(ByVal editval As Boolean, ByVal STNO As Integer)
        Try
            If (editval = False) Or (editval = True And GRIDBILL.RowCount > 0) Then
                Dim OBJJV As New StockTransferMaster
                OBJJV.MdiParent = MDIMain
                OBJJV.EDIT = editval
                OBJJV.TEMPSTNO = STNO
                OBJJV.Show()
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

    Private Sub StockTransferDetails_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            fillgrid("")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancel.Click
        Me.Close()
    End Sub

    Private Sub CMDOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDOK.Click
        Try
            showform(True, GRIDBILL.GetFocusedRowCellValue("STNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ExcelExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExcelExport.Click
        Try
            Dim PATH As String = ""
            If FileIO.FileSystem.FileExists(PATH) = True Then FileIO.FileSystem.DeleteFile(PATH)
            PATH = Application.StartupPath & "\Stock Transfer Details.XLS"

            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            For Each proc As System.Diagnostics.Process In System.Diagnostics.Process.GetProcessesByName("Excel")
                proc.Kill()
            Next

            opti.SheetName = "Stock Transfer Details"
            GRIDBILL.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Stock Transfer Details", GRIDBILL.VisibleColumns.Count + GRIDBILL.GroupCount)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDBILL_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GRIDBILL.DoubleClick
        Try
            showform(True, GRIDBILL.GetFocusedRowCellValue("STNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TOOLREFRESH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLREFRESH.Click
        Try
            fillgrid("")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class