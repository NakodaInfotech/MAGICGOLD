
Imports System.Data.OleDb

Public Class LabellingDetails

    Private Sub LabellingDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then Me.Close()
    End Sub

    Sub fillgrid(ByVal tempcondition)
        Try
            dt = New DataTable()
            If tempconn.State = ConnectionState.Open Then tempconn.Close()
            tempconn.Open()
            tempcmd = New OleDbCommand(" SELECT LABELLING.LABEL_NO AS LABELNO, LABELLING.LABEL_DATE AS [DATE], LABELLING.LABEL_SRNO AS SRNO, ItemMaster.item_code AS ITEMNAME, LABELLING.LABEL_ITEMDESC AS ITEMDESC, LABELLING.LABEL_PCS AS PCS, LABELLING.LABEL_GROSSWT AS GROSSWT, LABELLING.LABEL_LESSWT AS LESSWT, LABELLING.LABEL_NETTWT AS NETTWT, LABELLING.LABEL_PURITY AS PURITY, LABELLING.LABEL_FINEWT AS FINEWT, LABELLING.LABEL_REMARKS AS REMARKS, LABEL_PEARLWT AS PEARLWT, LABEL_STONEWT AS STONEWT, LABEL_KUNDANWT AS KUNDANWT FROM LABELLING INNER JOIN ItemMaster ON LABELLING.LABEL_ITEMID = ItemMaster.item_id ORDER BY LABELLING.LABEL_NO, LABELLING.LABEL_SRNO ", tempconn)
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

    Sub showform(ByVal editval As Boolean, ByVal LABELNO As Integer)
        Try
            If (editval = False) Or (editval = True And GRIDBILL.RowCount > 0) Then
                Dim OBJJV As New Labelling
                OBJJV.MdiParent = MDIMain
                OBJJV.EDIT = editval
                OBJJV.TEMPLABELNO = LABELNO
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

    Private Sub LabellingDetails_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
            showform(True, GRIDBILL.GetFocusedRowCellValue("LABELNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ExcelExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExcelExport.Click
        Try
            Dim PATH As String = ""
            If FileIO.FileSystem.FileExists(PATH) = True Then FileIO.FileSystem.DeleteFile(PATH)
            PATH = Application.StartupPath & "\Labelling Details.XLS"

            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            For Each proc As System.Diagnostics.Process In System.Diagnostics.Process.GetProcessesByName("Excel")
                proc.Kill()
            Next

            opti.SheetName = "Labelling Details"
            GRIDBILL.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Labelling Details", GRIDBILL.VisibleColumns.Count + GRIDBILL.GroupCount)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDBILL_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GRIDBILL.DoubleClick
        Try
            showform(True, GRIDBILL.GetFocusedRowCellValue("LABELNO"))
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