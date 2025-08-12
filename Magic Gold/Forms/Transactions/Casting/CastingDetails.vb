
Imports System.Windows.Forms
Imports System.Data.OleDb
Imports System.ComponentModel.Component
Imports System.Diagnostics

Public Class CastingDetails

    Private Sub CastingDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then Me.Close()
    End Sub

    Sub fillgrid(ByVal tempcondition)
        Try
            dt = New DataTable()
            If tempconn.State = ConnectionState.Open Then tempconn.Close()
            tempconn.Open()
            tempcmd = New OleDbCommand(" SELECT DISTINCT  Casting.CASTING_NO AS CASTINGNO, Casting.CASTING_DATE AS CASTDATE, Casting.CASTING_TOTALISSGROSS AS TOTALGROSSISS, Casting.CASTING_TOTALISSNETT AS TOTALNETTISS, Casting.CASTING_TOTALRECGROSS AS TOTALGROSSREC,  Casting.CASTING_TOTALRECNETT AS TOTALNETTREC, Casting.CASTING_LOSS AS LOSS, Casting.CASTING_BALANCE AS BALANCE, Casting.CASTING_REMARKS AS REMARKS FROM Casting ORDER BY CASTING_NO", tempconn)
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

    Sub showform(ByVal editval As Boolean, ByVal CASTNO As Integer)
        Try
            If (editval = False) Or (editval = True And gridbill.RowCount > 0) Then
                Dim OBJCAST As New Casting
                OBJCAST.MdiParent = MDIMain
                OBJCAST.edit = editval
                OBJCAST.TEMPCASTINGNO = CASTNO
                OBJCAST.Show()
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

    Private Sub CastingDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            fillgrid("")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CastingDetails_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If ClientName <> "MIMARAGEMS" Then Me.Close()
    End Sub

    Private Sub cmdcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancel.Click
        Me.Close()
    End Sub

    Private Sub CMDOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDOK.Click
        Try
            showform(True, gridbill.GetFocusedRowCellValue("CASTINGNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ExcelExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExcelExport.Click
        Try
            Dim PATH As String = ""
            If FileIO.FileSystem.FileExists(PATH) = True Then FileIO.FileSystem.DeleteFile(PATH)
            PATH = Application.StartupPath & "\Casting Details.XLS"

            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            For Each proc As System.Diagnostics.Process In System.Diagnostics.Process.GetProcessesByName("Excel")
                proc.Kill()
            Next

            opti.SheetName = "Casting Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Casting Details", gridbill.VisibleColumns.Count + gridbill.GroupCount)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridbill_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridbill.DoubleClick
        Try
            showform(True, gridbill.GetFocusedRowCellValue("CASTINGNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub toolrefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolrefresh.Click
        Try
            fillgrid("")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class