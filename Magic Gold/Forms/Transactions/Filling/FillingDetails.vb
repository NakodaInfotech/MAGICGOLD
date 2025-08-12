
Imports System.Data.OleDb
Imports DevExpress.XtraGrid.Views.Grid

Public Class FillingDetails

    Private Sub FillingDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then Me.Close()
    End Sub

    Sub fillgrid()
        Try
            dt = New DataTable()
            If tempconn.State = ConnectionState.Open Then tempconn.Close()
            tempconn.Open()
            tempcmd = New OleDbCommand(" SELECT DISTINCT FILLING.FILLING_NO AS FILLINGNO, ledgermaster.ledger_code AS [NAME], FILLING.FILLING_TOTALISSGROSS AS ISSGROSSWT, FILLING.FILLING_TOTALISSNETT AS ISSNETTWT, FILLING.FILLING_TOTALRECGROSS AS RECGROSSWT, FILLING.FILLING_TOTALRECNETT AS RECNETTWT, FILLING.FILLING_TOTALRECWASTAGE AS RECWASTAGE, FILLING.FILLING_BALANCE AS [BALANCE], FILLING.FILLING_REMARKS AS [REMARKS], FILLING.FILLING_SETTLED AS [SETTLED] FROM FILLING INNER JOIN ledgermaster ON FILLING.FILLING_LEDGERID = ledgermaster.ledger_id order by FILLING.FILLING_NO", tempconn)
            da = New OleDbDataAdapter(tempcmd)
            da.Fill(dt)
            griddetails.DataSource = dt

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform(ByVal EDITVAL As Boolean, ByVal FILLINGNO As Integer)
        Try
            If (EDITVAL = False) Or (EDITVAL = True And gridbill.RowCount > 0) Then
                Dim OBJFILLING As New Filling
                OBJFILLING.MdiParent = MDIMain
                OBJFILLING.edit = EDITVAL
                OBJFILLING.TEMPFILLINGNO = FILLINGNO
                OBJFILLING.Show()
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
            showform(True, gridbill.GetFocusedRowCellValue("FILLINGNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub FillingDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        fillgrid()
    End Sub

    Private Sub cmdcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancel.Click
        Me.Close()
    End Sub

    Private Sub CMDOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDOK.Click
        Try
            showform(True, gridbill.GetFocusedRowCellValue("FILLINGNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ExcelExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLEXCEL.Click
        Try
            Dim PATH As String = ""
            If FileIO.FileSystem.FileExists(PATH) = True Then FileIO.FileSystem.DeleteFile(PATH)
            PATH = Application.StartupPath & "\Filling Details.XLS"

            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            For Each proc As System.Diagnostics.Process In System.Diagnostics.Process.GetProcessesByName("Excel")
                proc.Kill()
            Next

            opti.SheetName = "Filling Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Filling Details", gridbill.VisibleColumns.Count + gridbill.GroupCount)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub FillingDetails_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If ClientName <> "MIMARAGEMS" Then Me.Close()
    End Sub

    Private Sub gridcontra_RowStyle(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles gridbill.RowStyle
        Try
            Dim DT As DataTable = griddetails.DataSource
            If gridbill.RowFilter = "" Then
                If e.RowHandle >= 0 Then
                    Dim ROW As DataRow = DT.Rows(e.RowHandle)
                    Dim View As GridView = sender
                    If View.GetRowCellDisplayText(e.RowHandle, View.Columns("SETTLED")) = "Checked" Then
                        e.Appearance.Font = New System.Drawing.Font("CALIBRI", 10.0F, System.Drawing.FontStyle.Regular)
                        e.Appearance.BackColor = Color.Yellow
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TOOLREFRESH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLREFRESH.Click
        fillgrid()
    End Sub
End Class