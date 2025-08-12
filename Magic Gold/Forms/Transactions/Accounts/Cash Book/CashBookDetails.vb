
Imports System.Data.OleDb

Public Class CashBookDetails

    Public FRMSTRING As String

    Private Sub JournalVoucherDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then Me.Close()
    End Sub

    Sub fillgrid(ByVal tempcondition)
        Try
            dt = New DataTable()
            If tempconn.State = ConnectionState.Open Then tempconn.Close()
            tempconn.Open()
            tempcmd = New OleDbCommand(" SELECT DISTINCT CASHENTRY.CASH_NO AS CASHNO, CASHENTRY.CASH_DATE AS [DATE], ledgermaster.LEDGER_CODE AS [NAME], CASHENTRY.CASH_TOTALAMT AS TOTALAMT FROM CASHENTRY INNER JOIN ledgermaster ON CASHENTRY.CASH_LEDGERID = ledgermaster.ledger_id order by CASH_NO", tempconn)
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

    Sub showform(ByVal editval As Boolean, ByVal CASHNO As Integer)
        Try
            If (editval = False) Or (editval = True And GRIDBILL.RowCount > 0) Then
                Dim OBJCASH As New CashBook
                OBJCASH.MdiParent = MDIMain
                OBJCASH.FRMSTRING = FRMSTRING
                OBJCASH.EDIT = editval
                OBJCASH.TEMPCASHNO = CASHNO
                OBJCASH.Show()
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

    Private Sub JournalVoucherDetails_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            fillgrid("")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub JournalVoucherDetails_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If ClientName <> "MIMARAGEMS" And ClientName <> "JAINAM" And ClientName <> "SHASHAWAT" And ClientName <> "SANGAM" Then Me.Close()
    End Sub

    Private Sub cmdcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancel.Click
        Me.Close()
    End Sub

    Private Sub CMDOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDOK.Click
        Try
            showform(True, GRIDBILL.GetFocusedRowCellValue("CASHNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ExcelExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExcelExport.Click
        Try
            Dim PATH As String = ""
            If FileIO.FileSystem.FileExists(PATH) = True Then FileIO.FileSystem.DeleteFile(PATH)
            PATH = Application.StartupPath & "\Cash/Bank Details.XLS"

            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            For Each proc As System.Diagnostics.Process In System.Diagnostics.Process.GetProcessesByName("Excel")
                proc.Kill()
            Next

            opti.SheetName = "Cash/Bank Details"
            GRIDBILL.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Cash/Bank Details", GRIDBILL.VisibleColumns.Count + GRIDBILL.GroupCount)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDBILL_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GRIDBILL.DoubleClick
        Try
            showform(True, GRIDBILL.GetFocusedRowCellValue("CASHNO"))
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