
Imports System.Data.OleDb

Public Class SalaryDetails

    Private Sub SalaryDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then Me.Close()
    End Sub

    Sub fillgrid(ByVal tempcondition)
        Try
            dt = New DataTable()
            If tempconn.State = ConnectionState.Open Then tempconn.Close()
            tempconn.Open()
            tempcmd = New OleDbCommand(" SELECT DISTINCT SALARYENTRY.SAL_NO AS ENTRYNO, SALARYENTRY.SAL_DATE AS [DATE], SALARYENTRY.SAL_TOTALAMT AS TOTALAMT, SALARYENTRY.SAL_TOTALCASH AS TOTALCASH FROM SALARYENTRY order by SAL_NO", tempconn)
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
                Dim OBJCASH As New Salary
                OBJCASH.MdiParent = MDIMain
                OBJCASH.EDIT = editval
                OBJCASH.TEMPSALNO = CASHNO
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

    Private Sub SalaryDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            fillgrid("")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SalaryDetails_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If ClientName <> "MIMARAGEMS" And ClientName <> "JAINAM" And ClientName <> "SHASHAWAT" And ClientName <> "SANGAM" Then Me.Close()
    End Sub

    Private Sub cmdcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancel.Click
        Me.Close()
    End Sub

    Private Sub CMDOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDOK.Click
        Try
            showform(True, GRIDBILL.GetFocusedRowCellValue("ENTRYNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ExcelExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExcelExport.Click
        Try
            Dim PATH As String = ""
            If FileIO.FileSystem.FileExists(PATH) = True Then FileIO.FileSystem.DeleteFile(PATH)
            PATH = Application.StartupPath & "\Salary Details.XLS"

            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            For Each proc As System.Diagnostics.Process In System.Diagnostics.Process.GetProcessesByName("Excel")
                proc.Kill()
            Next

            opti.SheetName = "Salary Details"
            GRIDBILL.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Salary Details", GRIDBILL.VisibleColumns.Count + GRIDBILL.GroupCount)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDBILL_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GRIDBILL.DoubleClick
        Try
            showform(True, GRIDBILL.GetFocusedRowCellValue("ENTRYNO"))
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