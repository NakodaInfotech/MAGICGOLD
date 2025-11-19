
Imports System.Data.OleDb

Public Class JournalVoucherGridDetails

    Private Sub JournalVoucherGridDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then Me.Close()
    End Sub

    Sub fillgrid(ByVal tempcondition)
        Try
            dt = New DataTable()
            If tempconn.State = ConnectionState.Open Then tempconn.Close()
            tempconn.Open()
            tempcmd = New OleDbCommand(" SELECT JOURNALMASTER.JV_NO AS JVNO, JOURNALMASTER.JV_DATE AS [DATE], ledgermaster.LEDGER_CODE AS NAME, JOURNALMASTER.JV_PCS AS PCS, JOURNALMASTER.JV_GROSSWT AS GROSSWT, JOURNALMASTER.JV_LESSWT AS LESSWT, JOURNALMASTER.JV_NETTWT AS NETTWT, JOURNALMASTER.JV_FINEWT AS FINEWT, JV_AMOUNT AS AMT, JOURNALMASTER.JV_REMARKS AS REMARKS, ItemMaster.item_code AS ITEMNAME, JOURNALMASTER.JV_ITEMDESC AS ITEMDESC, TOLEDGERMMASTER.ledger_code AS TONAME FROM ((JOURNALMASTER INNER JOIN ledgermaster ON JOURNALMASTER.JV_LEDGERID = ledgermaster.ledger_id) INNER JOIN ledgermaster AS TOLEDGERMMASTER ON JOURNALMASTER.JV_TOLEDGERID = TOLEDGERMMASTER.ledger_id) INNER JOIN ItemMaster ON JOURNALMASTER.JV_ITEMID = ItemMaster.item_id ORDER BY JOURNALMASTER.JV_NO;", tempconn)
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

    Sub showform(ByVal editval As Boolean, ByVal JVNO As Integer)
        Try
            If (editval = False) Or (editval = True And GRIDBILL.RowCount > 0) Then
                Dim OBJJV As New JournalVoucher
                OBJJV.MdiParent = MDIMain
                OBJJV.EDIT = editval
                OBJJV.TEMPJVNO = JVNO
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

    Private Sub JournalVoucherGridDetails_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
            showform(True, GRIDBILL.GetFocusedRowCellValue("JVNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ExcelExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExcelExport.Click
        Try
            Dim PATH As String = ""
            If FileIO.FileSystem.FileExists(PATH) = True Then FileIO.FileSystem.DeleteFile(PATH)
            PATH = Application.StartupPath & "\Journal Details.XLS"

            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            For Each proc As System.Diagnostics.Process In System.Diagnostics.Process.GetProcessesByName("Excel")
                proc.Kill()
            Next

            opti.SheetName = "Journal Details"
            GRIDBILL.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Journal Details", GRIDBILL.VisibleColumns.Count + GRIDBILL.GroupCount)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDBILL_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GRIDBILL.DoubleClick
        Try
            showform(True, GRIDBILL.GetFocusedRowCellValue("JVNO"))
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

    Private Sub JournalVoucherGridDetails_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Try
            If ClientName = "BALAJI" Then
                GGROSSWT.Caption = "Rate"
                GLESSWT.Visible = False
                GNETTWT.Visible = False
                GFINEWT.Visible = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class