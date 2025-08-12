
Imports System.Data.OleDb

Public Class Voucherdetails

    Dim ADDCOL As Boolean = False
    Dim CHKCOL As New DataGridViewCheckBoxColumn
    Dim PRINTCOL As New DataGridViewCheckBoxColumn
    Public FRMSTRING As String = ""

    Sub fillgrid()

        dt = New DataTable()
        If tempconn.State = ConnectionState.Open Then
            tempconn.Close()
        End If
        tempconn.Open()
        If FRMSTRING = "RECEIPT" Then
            tempcmd = New OleDbCommand("select distinct VOUCHERS.VOUCHER_PRINT AS PRINT, vouchers.voucher_id AS VOUCHERNO, vouchers.voucher_date AS VOUCHERDATE, ledgermaster.ledger_name AS NAME, vouchers.voucher_balance AS BALANCE,vouchers.voucher_balancewt AS BALANCEWT, VOUCHERS.VOUCHER_CHK AS CHECKED, VOUCHERS.VOUCHER_TOTALGROSSWT AS TOTALGROSSWT from vouchers inner join ledgermaster on ledgermaster.ledger_id = vouchers.voucher_ledgerid where vouchers.voucher_type  ='R'", tempconn)
        ElseIf FRMSTRING = "ISSUE" Then
            tempcmd = New OleDbCommand("select distinct VOUCHERS.VOUCHER_PRINT AS PRINT, vouchers.voucher_id AS VOUCHERNO, vouchers.voucher_date AS VOUCHERDATE, ledgermaster.ledger_name AS NAME, vouchers.voucher_balance AS BALANCE,vouchers.voucher_balancewt AS BALANCEWT, VOUCHERS.VOUCHER_CHK AS CHECKED, VOUCHERS.VOUCHER_TOTALGROSSWT AS TOTALGROSSWT from vouchers inner join ledgermaster on ledgermaster.ledger_id = vouchers.voucher_ledgerid where vouchers.voucher_type  ='I'", tempconn)
        End If
        da = New OleDbDataAdapter(tempcmd)
        da.Fill(dt)
        gridbill.RowCount = 0
        For Each TDR As DataRow In dt.Rows
            gridbill.Rows.Add(TDR("PRINT"), TDR("VOUCHERNO"), Format(TDR("VOUCHERDATE"), "dd/MM/yyyy"), TDR("NAME"), Format(Val(TDR("BALANCE")), "0.00"), Format(Val(TDR("TOTALGROSSWT")), "0.000"), Format(Val(TDR("BALANCEWT")), "0.000"), TDR("CHECKED"))
            If TDR("CHECKED") = True Then gridbill.Rows(gridbill.RowCount - 1).DefaultCellStyle.BackColor = Color.Yellow
        Next


        'gridbill.DataSource = dt

        'If ADDCOL = False Then
        '    gridbill.Columns.Insert(0, CHKCOL)
        '    gridbill.Columns.Insert(6, PRINTCOL)
        '    ADDCOL = True
        'End If

        'Dim A As Integer = 0
        'gridbill.Columns(A).Width = 50 'CHECK BOK
        'gridbill.Columns(A).Name = "PRINT" 'CHECK BOK
        'A += 1


        'gridbill.Columns(A).HeaderText = "Bill No."
        'gridbill.Columns(A).ReadOnly = True
        'gridbill.Columns(A).Width = 70
        ''gridchallan.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        'gridbill.Columns(0).Resizable = DataGridViewTriState.False
        'A += 1

        'gridbill.Columns(A).HeaderText = "Date"
        'gridbill.Columns(A).ReadOnly = True
        'gridbill.Columns(A).Width = 100
        ''gridchallan.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        'gridbill.Columns(1).Resizable = DataGridViewTriState.False
        'A += 1

        'gridbill.Columns(A).HeaderText = "Name"
        'gridbill.Columns(A).ReadOnly = True
        'gridbill.Columns(A).Width = 200
        'gridbill.Columns(A).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        'gridbill.Columns(A).Resizable = DataGridViewTriState.False
        'A += 1

        'gridbill.Columns(A).HeaderText = "Total Amt"
        'gridbill.Columns(A).ReadOnly = True
        'gridbill.Columns(A).Width = 100
        'gridbill.Columns(A).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'gridbill.Columns(A).Resizable = DataGridViewTriState.False
        'A += 1

        'gridbill.Columns(A).HeaderText = "Total Wt."
        'gridbill.Columns(A).ReadOnly = True
        'gridbill.Columns(A).Width = 95
        'gridbill.Columns(A).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'gridbill.Columns(A).Resizable = DataGridViewTriState.False
        'A += 1

        'gridbill.Columns(A).Width = 40 'CHECK BOK
        'gridbill.Columns(A).Name = "CHK" 'CHECK BOK
        'A += 1

        If gridbill.RowCount > 0 Then gridbill.FirstDisplayedScrollingRowIndex = gridbill.RowCount - 1


        'For Each ROW As DataGridViewRow In gridbill.Rows
        '    If frminvoicemaster = False And frmrecieptmaster = True Then
        '        tempcmd = New OleDbCommand("select VOUCHER_PRINT AS PRINT, VOUCHER_CHK AS CHECKED from VOUCHERS WHERE VOUCHER_ID = " & ROW.Cells(1).Value & " AND VOUCHER_TYPE = 'R'", tempconn)
        '    Else
        '        tempcmd = New OleDbCommand("select VOUCHER_PRINT AS PRINT, VOUCHER_CHK AS CHECKED from VOUCHERS WHERE VOUCHER_ID = " & ROW.Cells(1).Value & " AND VOUCHER_TYPE = 'I'", tempconn)
        '    End If
        '    If tempconn.State = ConnectionState.Open Then tempconn.Close()
        '    tempconn.Open()
        '    tempdr = tempcmd.ExecuteReader
        '    If tempdr.HasRows Then
        '        tempdr.Read()
        '        ROW.Cells(6).Value = tempdr("PRINT")
        '        ROW.Cells("CHK").Value = Convert.ToBoolean(tempdr("CHECKED"))
        '    End If
        '    tempconn.Close()
        '    tempdr.Close()
        'Next

        da.Dispose()
        dt.Dispose()
        tempconn.Close()
        tempcmd.Dispose()

    End Sub

    Private Sub gridbill_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridbill.CellClick
        If e.RowIndex >= 0 Then
            If e.ColumnIndex = GPRINT.Index Then
                With gridbill.Rows(e.RowIndex).Cells("GPRINT")
                    If .Value = True Then
                        .Value = False
                        If FRMSTRING = "ISSUE" Then
                            cmd = New OleDbCommand("UPDATE vouchers SET VOUCHER_PRINT = 0 where voucher_id = " & Val(gridbill.Rows(e.RowIndex).Cells("GVOUCHERID").Value) & " and voucher_type ='I'", conn)
                        Else
                            cmd = New OleDbCommand("UPDATE vouchers SET VOUCHER_PRINT = 0 where voucher_id = " & Val(gridbill.Rows(e.RowIndex).Cells("GVOUCHERID").Value) & " and voucher_type ='R'", conn)
                        End If
                        If conn.State = ConnectionState.Open Then conn.Close()
                        conn.Open()
                        cmd.ExecuteNonQuery()
                    Else
                        .Value = True
                        If FRMSTRING = "ISSUE" Then
                            cmd = New OleDbCommand("UPDATE vouchers SET VOUCHER_PRINT = 1 where voucher_id = " & Val(gridbill.Rows(e.RowIndex).Cells("GVOUCHERID").Value) & " and voucher_type ='I'", conn)
                        Else
                            cmd = New OleDbCommand("UPDATE vouchers SET VOUCHER_PRINT = 1 where voucher_id = " & Val(gridbill.Rows(e.RowIndex).Cells("GVOUCHERID").Value) & " and voucher_type ='R'", conn)
                        End If
                        If conn.State = ConnectionState.Open Then conn.Close()
                        conn.Open()
                        cmd.ExecuteNonQuery()
                    End If
                End With
            ElseIf e.ColumnIndex = GCHK.Index Then
                With gridbill.Rows(e.RowIndex).Cells("GCHK")
                    If .Value = True Then
                        .Value = False
                        gridbill.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Empty
                        If FRMSTRING = "ISSUE" Then
                            cmd = New OleDbCommand("UPDATE vouchers SET VOUCHER_CHK = 0 where voucher_id = " & Val(gridbill.Rows(e.RowIndex).Cells("GVOUCHERID").Value) & " and voucher_type ='I'", conn)
                        Else
                            cmd = New OleDbCommand("UPDATE vouchers SET VOUCHER_CHK = 0 where voucher_id = " & Val(gridbill.Rows(e.RowIndex).Cells("GVOUCHERID").Value) & " and voucher_type ='R'", conn)
                        End If
                        If conn.State = ConnectionState.Open Then conn.Close()
                        conn.Open()
                        cmd.ExecuteNonQuery()
                    Else
                        .Value = True
                        gridbill.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Yellow
                        If FRMSTRING = "ISSUE" Then
                            cmd = New OleDbCommand("UPDATE vouchers SET VOUCHER_CHK = 1 where voucher_id = " & Val(gridbill.Rows(e.RowIndex).Cells("GVOUCHERID").Value) & " and voucher_type ='I'", conn)
                        Else
                            cmd = New OleDbCommand("UPDATE vouchers SET VOUCHER_CHK = 1 where voucher_id = " & Val(gridbill.Rows(e.RowIndex).Cells("GVOUCHERID").Value) & " and voucher_type ='R'", conn)
                        End If
                        If conn.State = ConnectionState.Open Then conn.Close()
                        conn.Open()
                        cmd.ExecuteNonQuery()
                    End If
                End With
            End If
        End If
    End Sub

    Private Sub gridbill_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridbill.CellDoubleClick
        If e.RowIndex = -1 Then Exit Sub
        'If gridbill.Item("GVOUCHERID", e.RowIndex).Value <> Nothing Then
        '    tempbillno = gridbill.Item("GVOUCHERID", e.RowIndex).Value
        '    Me.Close()

        '    If (chldvouchers.IsMdiChild = False) Then
        '        If chldvouchers.IsDisposed = True Then
        '            chldvouchers = New vouchers
        '        End If
        '        chldvouchers.MdiParent = MDIMain
        '        chldvouchers.cmdedit.Enabled = False
        '        chldvouchers.EDIT = True
        '        chldvouchers.Show()
        '    Else
        '        chldvouchers.BringToFront()
        '    End If

        'End If
        Call cmdok_Click(sender, e)
    End Sub

    Private Sub cmdcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancel.Click
        Me.Close()
    End Sub

    Private Sub cmdok_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdok.Click

        If gridbill.Item("GVOUCHERID", gridbill.CurrentRow.Index).Value <> Nothing Then
            'tempbillno = gridbill.Item(0, gridbill.CurrentRow.Index).Value
            'Me.Close()

            'If (chldvouchers.IsMdiChild = False) Then
            '    If chldvouchers.IsDisposed = True Then
            '        chldvouchers = New vouchers
            '    End If
            '    chldvouchers.MdiParent = MDIMain
            '    chldvouchers.cmdedit.Enabled = False
            '    chldvouchers.EDIT = True
            '    chldvouchers.Show()
            'Else
            '    chldvouchers.BringToFront()
            'End If
            Try
                Dim OBJVOUCHER As New vouchers
                OBJVOUCHER.MdiParent = MDIMain
                OBJVOUCHER.TEMPBILLNO = gridbill.Item("GVOUCHERID", gridbill.CurrentRow.Index).Value
                OBJVOUCHER.FRMSTRING = FRMSTRING
                OBJVOUCHER.cmdedit.Enabled = False
                OBJVOUCHER.EDIT = True
                OBJVOUCHER.Show()
            Catch ex As Exception
                Throw ex
            End Try

        End If

    End Sub

    Private Sub txtname_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtname.KeyPress
        enterkeypress(e, Me)
    End Sub


    Private Sub TOOLADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLADD.Click

        'Me.Close()
        'If (chldvouchers.IsMdiChild = False) Then
        '    If chldvouchers.IsDisposed = True Then
        '        chldvouchers = New vouchers
        '    End If
        '    chldvouchers.MdiParent = MDIMain
        '    chldvouchers.Show()
        'Else
        '    chldvouchers.BringToFront()
        'End If
        Try
            Dim OBJVOUCHER As New vouchers
            OBJVOUCHER.MdiParent = MDIMain
            OBJVOUCHER.FRMSTRING = FRMSTRING
            OBJVOUCHER.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbselect_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbselect.KeyPress
        enterkeypress(e, Me)
    End Sub

    Private Sub Voucherdetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Alt = True And e.KeyCode = Windows.Forms.Keys.S Then       'for Saving
            Call cmdok_Click(sender, e)
        ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            Me.Close()
        ElseIf (e.Control = True And e.KeyCode = Keys.N) Or (e.Alt = True And e.KeyCode = Keys.A) Then
            Call TOOLADD_Click(sender, e)
        End If
    End Sub

    Private Sub Voucherdetails_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = FRMSTRING & " VOUCHER"
        fillgrid()
    End Sub

    Private Sub TOOLREFRESH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLREFRESH.Click
        Try
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TOOLPRINT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLPRINT.Click
        Try
            If Val(TXTFROM.Text.Trim) = 0 Or Val(TXTTO.Text.Trim) = 0 Or (Val(TXTFROM.Text.Trim) > Val(TXTTO.Text.Trim)) Then
                MsgBox("Enter Proper Voucher Nos", MsgBoxStyle.Critical)
            Else
                For I As Integer = Val(TXTFROM.Text.Trim) To Val(TXTTO.Text.Trim)
                    Dim OBJVOUCHER As New VoucherDesign
                    If FRMSTRING = "ISSUE" Then
                        OBJVOUCHER.WHERECLAUSE = " {VOUCHERS.VOUCHER_ID} = " & Val(I) & " and {VOUCHERS.VOUCHER_TYPE} = 'I'"
                    ElseIf FRMSTRING = "RECEIPT" Then
                        OBJVOUCHER.WHERECLAUSE = " {VOUCHERS.VOUCHER_ID} = " & Val(I) & " and {VOUCHERS.VOUCHER_TYPE} = 'R'"
                    End If
                    OBJVOUCHER.FRMSTRING = "ISSUECHITTI"
                    OBJVOUCHER.MdiParent = MDIMain
                    OBJVOUCHER.Show()
                Next
                TXTFROM.Clear()
                TXTTO.Clear()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTFROM_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTFROM.KeyPress
        numkeypress(e, TXTFROM, Me)
    End Sub

    Private Sub TXTTO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTTO.KeyPress
        numkeypress(e, TXTTO, Me)
    End Sub

    Private Sub txtname_Validated(sender As Object, e As EventArgs) Handles txtname.Validated
        Dim rowno, b As Integer

        If cmbselect.Text.Trim <> "" Then

            fillgrid()

            rowno = 0
            For b = 1 To gridbill.RowCount
                If cmbselect.Text.Trim = "Bill No." Then
                    txttempname.Text = gridbill.Item(GVOUCHERID.Index, rowno).Value.ToString()
                ElseIf cmbselect.Text.Trim = "Name" Then
                    txttempname.Text = gridbill.Item(GNAME.Index, rowno).Value.ToString()
                End If
                txttempname.SelectionStart = 0
                txttempname.SelectionLength = txtname.TextLength
                If LCase(txtname.Text.Trim) <> LCase(txttempname.SelectedText.Trim) Then
                    gridbill.Rows.RemoveAt(rowno)
                Else
                    rowno = rowno + 1
                End If

            Next
        ElseIf cmbselect.Text.Trim = "" Then
            fillgrid()
        End If
    End Sub
End Class