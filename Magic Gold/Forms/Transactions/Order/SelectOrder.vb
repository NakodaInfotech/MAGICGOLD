
Imports System.Data.OleDb

Public Class SelectOrder

    Dim ROW As Integer = 0
    Public DTORDER As New DataTable
    Public FRMSTRING As String
    Public PARTYNAME As String = ""

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub SelectOrder_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Or (e.KeyCode = Keys.X And e.Alt = True) Then
                Me.Close()
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            ElseIf e.KeyCode = Keys.O And e.Alt = True Then
                cmdok_Click(sender, e)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SelectOrder_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If FRMSTRING = "RECEIPT" Then
                fillgrid(" WHERE ORDERMASTER.ORDER_CLOSE = FALSE AND ORDERMASTER.ORDER_DONE = FALSE AND (ORDERMASTER.ORDER_GOLDWT - ORDERMASTER.ORDER_MFGWT) > 0")
            ElseIf FRMSTRING = "RETURN" Then
                fillgrid(" WHERE ORDERMASTER.ORDER_CLOSE = FALSE AND ORDERMASTER.ORDER_DONE = TRUE ")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid(ByVal WHERECLAUSE)
        Try
            If PARTYNAME <> "" Then WHERECLAUSE = WHERECLAUSE & " AND ledgermaster.ledger_code = '" & PARTYNAME & "' "
            dt = New DataTable
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Open()
            cmd = New OleDbCommand(" SELECT 0 AS CHK, OrderMaster.ORDER_SRNO AS SRNO, OrderMaster.ORDER_NO AS ORDERNO, OrderMaster.ORDER_DATE AS [DATE], OrderMaster.ORDER_DELDATE AS DELDATE ,  ledgermaster.ledger_code AS [NAME], ItemMaster.item_code AS ITEMNAME, ORDERMASTER.ORDER_MELTING AS PURITY, (OrderMaster.ORDER_GOLDWT - OrderMaster.ORDER_MFGWT) AS GOLDWT, OrderMaster.ORDER_CTWT AS CTWT, OrderMaster.ORDER_SIZE AS ORDERSIZE, OrderMaster.ORDER_REMARKS AS [REMARKS], OrderMaster.ORDER_CLOSE AS [CLOSED], OrderMaster.ORDER_DONE AS [DONE] FROM (OrderMaster INNER JOIN ledgermaster ON OrderMaster.ORDER_LEDGERID = ledgermaster.ledger_id) INNER JOIN ItemMaster ON OrderMaster.ORDER_ITEMID = ItemMaster.item_id " & WHERECLAUSE & " order by ORDER_SRNO ", conn)
            da = New OleDbDataAdapter(cmd)
            da.Fill(dt)
            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
            dt.Dispose()
            conn.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            DTORDER.Columns.Add("NAME")
            DTORDER.Columns.Add("ORDERNO")
            DTORDER.Columns.Add("SRNO")
            DTORDER.Columns.Add("ITEMNAME")

            For i As Integer = 0 To gridbill.RowCount - 1
                Dim dtrow As DataRow = gridbill.GetDataRow(i)
                If Convert.ToBoolean(dtrow("CHK")) = True Then
                    DTORDER.Rows.Add(dtrow("NAME"), dtrow("ORDERNO"), dtrow("SRNO"), dtrow("ITEMNAME"))
                End If
            Next
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridbill_InvalidRowException(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) Handles gridbill.InvalidRowException
        Try
            e.ErrorText = "Only 1 row can be selected at a time"
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridbill_ValidateRow(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles gridbill.ValidateRow
        Try

LINE1:
            If ROW = 0 Then
                For I As Integer = 0 To gridbill.RowCount - 1
                    Dim dtrow As DataRow = gridbill.GetDataRow(I)
                    If Convert.ToBoolean(dtrow("CHK")) = True Then
                        ROW = I
                        Exit For
                    End If
                Next
            Else
                Dim dtrow As DataRow = gridbill.GetDataRow(ROW)
                If Convert.ToBoolean(dtrow("CHK")) = False Then
                    ROW = 0
                    GoTo LINE1
                End If
            End If

            If Convert.ToBoolean(gridbill.GetFocusedRowCellValue("CHK")) = True And e.RowHandle <> ROW Then
                e.Valid = False
                gridbill.SetColumnError(gridbill.Columns("CHK"), "Only 1 row can be selected at a time", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical)
            ElseIf Convert.ToBoolean(gridbill.GetFocusedRowCellValue("CHK")) = False And e.RowHandle = ROW Then
                ROW = 0
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class