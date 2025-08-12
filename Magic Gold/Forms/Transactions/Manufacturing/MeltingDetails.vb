Imports System.Data.OleDb

Public Class MeltingDetails

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub MeltingDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Alt = True And e.KeyCode = Windows.Forms.Keys.O Then       'for oPEN
            Call cmdok_Click(sender, e)
        ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            Me.Close()
        End If

        '*********** CTRL + N ************
        If (e.Control = True And e.KeyCode = Keys.N) Or (e.Alt = True And e.KeyCode = Keys.A) Then

            Me.Close()
            If (chldmelting.IsMdiChild = False) Then
                If chldmelting.IsDisposed = True Then
                    chldmelting = New Melting
                End If
                chldmelting.MdiParent = MDIMain
                chldmelting.Show()
            Else
                chldmelting.BringToFront()
            End If

        End If
    End Sub

    Private Sub MeltingDetails_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

        dt = New DataTable()
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If
        conn.Open()

        tempcmd = New OleDbCommand("select distinct meltingmaster.melting_id AS LOTNO, meltingmaster.melting_date AS [DATE], meltingmaster.melting_reqmelting AS REQMELTING, meltingmaster.melting_totalgrosswt AS TOTALGROSSWT, meltingmaster.melting_alloy AS ALLOYWT, meltingmaster.melting_gtotalwt AS TOTALWT, meltingmaster.melting_output AS OUTPUTWT, meltingmaster.melting_loss AS LOSSWT, meltingmaster.melting_mfg AS MFGDONE, meltingmaster.melting_REFNO AS REFNO, MELTINGMASTER.melting_narration AS REMARKS from meltingmaster order by melting_id", tempconn)

        da = New OleDbDataAdapter(tempcmd)
        da.Fill(dt)
        griddetails.DataSource = dt
                If dt.Rows.Count > 0 Then
            GRIDBILL.FocusedRowHandle = GRIDBILL.RowCount - 1
            GRIDBILL.TopRowIndex = GRIDBILL.RowCount - 15
        End If
        da.Dispose()
        dt.Dispose()
        tempconn.Close()
        tempcmd.Dispose()

    End Sub

    Sub SHOWFORM(ByVal MELTINGNO As Integer)
        Try
            tempmeltingid = GRIDBILL.GetFocusedRowCellValue("LOTNO")
            Me.Close()

            If (chldmelting.IsMdiChild = False) Then
                If chldmelting.IsDisposed = True Then
                    chldmelting = New Melting
                End If
                chldmelting.MdiParent = MDIMain
                chldmelting.cmdedit.Enabled = False
                chldmelting.EDIT = True
                chldmelting.Show()
            Else
                chldmelting.BringToFront()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub newarea_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles newarea.Click

        Me.Close()
        If (chldmelting.IsMdiChild = False) Then
            If chldmelting.IsDisposed = True Then
                chldmelting = New Melting
            End If
            chldmelting.MdiParent = MDIMain
            chldmelting.Show()
        Else
            chldmelting.BringToFront()
        End If

    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        SHOWFORM(GRIDBILL.GetFocusedRowCellValue("LOTNO"))
    End Sub

    Private Sub gridmelting_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDBILL.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then cmdok_Click(sender, e)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try
            Dim PATH As String = ""
            If FileIO.FileSystem.FileExists(PATH) = True Then FileIO.FileSystem.DeleteFile(PATH)
            PATH = Application.StartupPath & "\Melting Details.XLS"

            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            For Each proc As System.Diagnostics.Process In System.Diagnostics.Process.GetProcessesByName("Excel")
                proc.Kill()
            Next

            opti.SheetName = "Melting Details"
            GRIDBILL.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Melting Details", GRIDBILL.VisibleColumns.Count + GRIDBILL.GroupCount)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub griddetails_DoubleClick(sender As Object, e As EventArgs) Handles griddetails.DoubleClick
        Try
            SHOWFORM(GRIDBILL.GetFocusedRowCellValue("LOTNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class