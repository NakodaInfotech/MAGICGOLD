
Imports System.Data.OleDb

Public Class PrePolishDetails

    Private Sub PREPOLISHDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then Me.Close()
    End Sub

    Sub fillgrid()
        Try
            dt = New DataTable()
            If tempconn.State = ConnectionState.Open Then tempconn.Close()
            tempconn.Open()
            tempcmd = New OleDbCommand(" SELECT DISTINCT PREPOLISH.PREPOLISH_NO AS PREPOLISHNO, ledgermaster.ledger_code AS [NAME], PREPOLISH.PREPOLISH_TOTALISSGROSS AS ISSGROSSWT, PREPOLISH.PREPOLISH_TOTALISSNETT AS ISSNETTWT, PREPOLISH.PREPOLISH_TOTALRECGROSS AS RECGROSSWT, PREPOLISH.PREPOLISH_TOTALRECNETT AS RECNETTWT, PREPOLISH.PREPOLISH_TOTALRECWASTAGE AS RECWASTAGE, PREPOLISH.PREPOLISH_BALANCE AS [BALANCE], PREPOLISH.PREPOLISH_REMARKS AS [REMARKS], PREPOLISH.PREPOLISH_SETTLED AS [SETTLED] FROM PREPOLISH INNER JOIN ledgermaster ON PREPOLISH.PREPOLISH_LEDGERID = ledgermaster.ledger_id order by PREPOLISH.PREPOLISH_NO", tempconn)
            da = New OleDbDataAdapter(tempcmd)
            da.Fill(dt)
            griddetails.DataSource = dt

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform(ByVal EDITVAL As Boolean, ByVal PREPOLISHNO As Integer)
        Try
            If (EDITVAL = False) Or (EDITVAL = True And gridbill.RowCount > 0) Then
                Dim OBJPREPOLISH As New PrePolish
                OBJPREPOLISH.MdiParent = MDIMain
                OBJPREPOLISH.EDIT = EDITVAL
                OBJPREPOLISH.TEMPPREPOLISHNO = PREPOLISHNO
                OBJPREPOLISH.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TOOLADDNEW_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TOOLADDNEW.Click
        Try
            showform(False, 0)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridbill_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridbill.DoubleClick
        Try
            showform(True, gridbill.GetFocusedRowCellValue("PREPOLISHNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PREPOLISHDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        fillgrid()
    End Sub

    Private Sub cmdcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancel.Click
        Me.Close()
    End Sub

    Private Sub CMDOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDOK.Click
        Try
            showform(True, gridbill.GetFocusedRowCellValue("PREPOLISHNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ExcelExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLEXCEL.Click
        Try
            Dim PATH As String = ""
            If FileIO.FileSystem.FileExists(PATH) = True Then FileIO.FileSystem.DeleteFile(PATH)
            PATH = Application.StartupPath & "\PREPOLISH Details.XLS"

            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            For Each proc As System.Diagnostics.Process In System.Diagnostics.Process.GetProcessesByName("Excel")
                proc.Kill()
            Next

            opti.SheetName = "PREPOLISH Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "PREPOLISH Details", gridbill.VisibleColumns.Count + gridbill.GroupCount)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PREPOLISHDetails_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If ClientName <> "MIMARAGEMS" Then Me.Close()
    End Sub

    Private Sub TOOLREFRESH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLREFRESH.Click
        fillgrid()
    End Sub

End Class


