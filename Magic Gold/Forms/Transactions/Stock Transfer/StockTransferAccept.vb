
Imports System.Data.OleDb
Imports DevExpress.XtraEditors.Controls

Public Class StockTransferAccept

    Private Sub StockTransferAccept_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then Me.Close()
    End Sub

    Sub fillgrid()
        Try
            Dim WHERECLAUSE As String = " WHERE 1 =1 "
            If RBPENDING.Checked = True Then WHERECLAUSE = WHERECLAUSE & " AND STOCKTRANSFER.ST_ACCEPTED = 0 " Else WHERECLAUSE = WHERECLAUSE & " AND STOCKTRANSFER.ST_ACCEPTED <> 0"
            If USERDEPARTMENT <> "" Then WHERECLAUSE = WHERECLAUSE & " AND TODEPARTMENTMASTER.DEPARTMENT_NAME = '" & USERDEPARTMENT & "'"
            dt = New DataTable()
            If tempconn.State = ConnectionState.Open Then tempconn.Close()
            tempconn.Open()
            tempcmd = New OleDbCommand(" SELECT STOCKTRANSFER.ST_ACCEPTED AS ACCEPTED, STOCKTRANSFER.ST_NO AS STNO, STOCKTRANSFER.ST_DATE AS STDATE, STOCKTRANSFER.ST_SRNO AS GRIDSRNO, ItemMaster.item_code AS ITEMNAME, STOCKTRANSFER.ST_ITEMDESC AS ITEMDESC, STOCKTRANSFER.ST_PCS AS PCS, STOCKTRANSFER.ST_GROSSWT AS GROSSWT, STOCKTRANSFER.ST_PURITY AS PURITY, STOCKTRANSFER.ST_WASTAGE AS WASTAGE, STOCKTRANSFER.ST_FINEWT AS FINEWT, STOCKTRANSFER.ST_REMARKS AS REMARKS, IIF(ISNULL(FROMDEPARTMENTMASTER.DEPARTMENT_NAME) = 'TRUE', '', FROMDEPARTMENTMASTER.DEPARTMENT_NAME) AS FROMDEPARTMENT , IIF(ISNULL(TODEPARTMENTMASTER.DEPARTMENT_NAME) = 'TRUE', '', TODEPARTMENTMASTER.DEPARTMENT_NAME) AS TODEPARTMENT FROM ((STOCKTRANSFER INNER JOIN ItemMaster ON STOCKTRANSFER.ST_ITEMID = ItemMaster.item_id) LEFT JOIN DEPARTMENTMASTER AS FROMDEPARTMENTMASTER ON STOCKTRANSFER.ST_FROMDEPARTMENTID = FROMDEPARTMENTMASTER.DEPARTMENT_ID) LEFT JOIN DEPARTMENTMASTER AS TODEPARTMENTMASTER ON STOCKTRANSFER.ST_TODEPARTMENTID = TODEPARTMENTMASTER.DEPARTMENT_ID " & WHERECLAUSE & " ORDER BY STOCKTRANSFER.ST_NO ", tempconn)
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

    Private Sub StockTransferAccept_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancel.Click
        Me.Close()
    End Sub

    Private Sub CMDOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDOK.Click
        Try
            If RBPENDING.Checked = True Then
                For i As Integer = 0 To GRIDBILL.RowCount - 1
                    Dim dtrow As DataRow = GRIDBILL.GetDataRow(i)
                    If Convert.ToBoolean(dtrow("ACCEPTED")) = True Then
                        cmd = New OleDbCommand(" UPDATE STOCKTRANSFER SET ST_ACCEPTED = 1 WHERE STOCKTRANSFER.ST_NO = " & Val(dtrow("STNO")) & " AND STOCKTRANSFER.ST_SRNO = " & Val(dtrow("GRIDSRNO")), conn)
                        If conn.State = ConnectionState.Open Then conn.Close()
                        conn.Open()
                        cmd.ExecuteNonQuery()
                        cmd.Dispose()
                        conn.Close()
                    End If
                Next
                fillgrid()
                GRIDBILL.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridbill_InvalidRowException(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) Handles GRIDBILL.InvalidRowException
        e.ExceptionMode = ExceptionMode.NoAction
    End Sub

    Private Sub gridbill_ValidateRow(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles GRIDBILL.ValidateRow
        Try
            If RBPENDING.Checked = True AndAlso Convert.ToBoolean(GRIDBILL.GetRowCellValue(e.RowHandle, "ACCEPTED")) = True Then
                If MsgBox("Save Entry?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then Call CMDOK_Click(sender, e)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDREFRESH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDREFRESH.Click
        Try
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDDELETE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDDELETE.Click
        Try

            Dim ROW As DataRow = GRIDBILL.GetFocusedDataRow
            If MsgBox("Delete Data?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            If tempconn.State = ConnectionState.Open Then tempconn.Close()
            tempconn.Open()
            tempcmd = New OleDbCommand(" UPDATE STOCKTRANSFER SET ST_ACCEPTED = 0 WHERE STOCKTRANSFER.ST_NO = " & Val(ROW("STNO")) & " AND STOCKTRANSFER.ST_SRNO = " & Val(ROW("GRIDSRNO")), tempconn)
            tempcmd.ExecuteNonQuery()
            tempcmd.Dispose()
            tempconn.Close()
            fillgrid()
            GRIDBILL.Focus()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class