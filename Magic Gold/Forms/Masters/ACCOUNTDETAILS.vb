Imports System.Data.oledb

Public Class ACCOUNTDETAILS

    Dim tempuse As Boolean 'for fillgridname
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub newcustomer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles newcustomer.Click
        Try
            If USERADD = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            Dim OBJVENDOR As New ACCOUNTMASTER
            OBJVENDOR.MdiParent = MDIMain
            OBJVENDOR.EDIT = False
            OBJVENDOR.ActiveControl = OBJVENDOR.txtname
            OBJVENDOR.txtname.Focus()
            OBJVENDOR.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgridname()

        dt = New DataTable()
        If tempconn.State = ConnectionState.Open Then
            tempconn.Close()
        End If
        tempconn.Open()

        'THIS CODE DOES NOT RETRIEVE LEDGERS WHICH DOES NOT HAVE DATA
        'tempcmd = New OleDbCommand("SELECT trialbalance.code, ledgermaster.ledger_name, Sum(trialbalance.nettwt) AS SumOfnettwt, Sum(trialbalance.amount) AS SumOfamount FROM trialbalance INNER JOIN ledgermaster ON trialbalance.code = ledgermaster.ledger_code GROUP BY trialbalance.code, ledgermaster.ledger_name ", tempconn)
        tempcmd = New OleDbCommand("SELECT LEDGER_code, ledgermaster.ledger_name FROM LEDGERMASTER ORDER BY LEDGER_CODE ", tempconn)

        da = New OleDbDataAdapter(tempcmd)
        da.Fill(dt)
        gridname.DataSource = dt
        tempconn.Close()
        da.Dispose()
        With gridname
            .Columns(0).HeaderText = "Code"
            .Columns(0).Width = 130

            .Columns(1).HeaderText = "Ledger"
            .Columns(1).Width = 200
        End With
        ' gridname.FirstDisplayedScrollingRowIndex = gridname.RowCount - 1
    End Sub

    Sub gettingdetails(ByVal a As String)

        'getting detials
        cmd = New OleDbCommand("select * from ledgermaster where ledger_name = '" & a & "'", conn)
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If
        conn.Open()
        dr = cmd.ExecuteReader()
        While (dr.Read())

            tempnameid = dr(0)
            txtname.Text = dr(1).ToString
            txtcode.Text = dr(2).ToString

            'getting groupname
            tempcmd = New OleDbCommand("select group_name from groupmaster where group_id  = " & Val(dr(3).ToString), tempconn)
            If tempconn.State = ConnectionState.Open Then
                tempconn.Close()
            End If
            tempconn.Open()
            tempdr = tempcmd.ExecuteReader
            If tempdr.HasRows Then
                tempdr.Read()
                txtgroup.Text = tempdr(0)
            End If
            tempconn.Close()
            tempdr.Close()

            txtopbalrs.Text = Val(dr(4).ToString)
            txtdrcrrs.Text = Val(dr(5).ToString)
            txtopbalwt.Text = Val(dr(6).ToString)
            txtdrcrwt.Text = dr(7).ToString

            'details
            txtadd1.Text = dr(8).ToString
            txtadd2.Text = dr(9).ToString


            'getting area
            tempcmd = New OleDbCommand("select area_name from areamaster where area_id  = " & Val(dr(10).ToString), tempconn)
            If tempconn.State = ConnectionState.Open Then
                tempconn.Close()
            End If
            tempconn.Open()
            tempdr = tempcmd.ExecuteReader
            If tempdr.HasRows Then
                tempdr.Read()
                txtarea.Text = tempdr(0)
            End If
            tempconn.Close()
            tempdr.Close()


            'getting city
            tempcmd = New OleDbCommand("select city_name from citymaster where city_id  = " & Val(dr(11).ToString), tempconn)
            If tempconn.State = ConnectionState.Open Then
                tempconn.Close()
            End If
            tempconn.Open()
            tempdr = tempcmd.ExecuteReader
            If tempdr.HasRows Then
                tempdr.Read()
                txtcity.Text = tempdr(0)
            End If
            tempconn.Close()
            tempdr.Close()

            txtzipcode.Text = dr(12).ToString


            'getting state
            tempcmd = New OleDbCommand("select state_name from statemaster where state_id  = " & Val(dr(13).ToString), tempconn)
            If tempconn.State = ConnectionState.Open Then
                tempconn.Close()
            End If
            tempconn.Open()
            tempdr = tempcmd.ExecuteReader
            If tempdr.HasRows Then
                tempdr.Read()
                txtstate.Text = tempdr(0)
            End If
            tempconn.Close()
            tempdr.Close()


            'getting country
            tempcmd = New OleDbCommand("select country_name from countrymaster where country_id  = " & Val(dr(14).ToString), tempconn)
            If tempconn.State = ConnectionState.Open Then
                tempconn.Close()
            End If
            tempconn.Open()
            tempdr = tempcmd.ExecuteReader
            If tempdr.HasRows Then
                tempdr.Read()
                txtcountry.Text = tempdr(0)
            End If
            tempconn.Close()
            tempdr.Close()


            txtstd.Text = dr(15).ToString
            txtresino.Text = dr(16).ToString
            txtaltno.Text = dr(17).ToString
            txttel1.Text = dr(18).ToString
            txtmobile.Text = dr(19).ToString
            txtfax.Text = dr(20).ToString
            txtwebsite.Text = dr(21).ToString
            txtemail.Text = dr(22).ToString
            txtcrdays.Text = dr(23).ToString
            txtcrlimit.Text = dr(24).ToString
            txtpanno.Text = dr(25).ToString
            txtexciseno.Text = dr(26).ToString
            txtcstno.Text = dr(27).ToString
            txttinno.Text = dr(28).ToString
            txtstno.Text = dr(29).ToString
            txtvatno.Text = dr(30).ToString
            txtkstno.Text = dr(31).ToString
            txtadd.Text = dr(32).ToString
            txtshipadd.Text = dr(33).ToString
            txtnotes.Text = dr(34).ToString

            If IsDBNull(dr(39)) = False Then TXTOPBALGROSSWT.Text = Val(dr(39))
            If IsDBNull(dr(40)) = False Then TXTDRCRGROSSWT.Text = dr(40).ToString


        End While
        conn.Close()
        dr.Close()

        tempcondition = ""
        'filltrans(tempcondition)

    End Sub

    Private Sub gridname_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridname.CellDoubleClick
        Try
            tempname = gridname.Item(1, e.RowIndex).Value.ToString()
            'tempgroupname = gridname.Item(1, e.RowIndex).Value.ToString()

            If USEREDIT = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If (chldvendormaster.IsMdiChild = False) Then
                If chldvendormaster.IsDisposed = True Then
                    chldvendormaster = New ACCOUNTMASTER
                End If
                chldvendormaster.cmdedit.Enabled = False
                chldvendormaster.EDIT = True
                chldvendormaster.MdiParent = MDIMain
                chldvendormaster.cmdedit.Enabled = False
                chldvendormaster.Show()
            Else
                chldvendormaster.BringToFront()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub clear()
        For i = 1 To 100
            tempcol(i) = ""
            tempval(i) = ""
        Next

        For Each txt As Control In Me.Controls
            txt.Text = ""
        Next

    End Sub

    Private Sub gridname_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridname.CellEnter
        If tempuse = False Then
            For Each row As DataGridViewRow In gridname.SelectedRows
                lbltotal.Text = "0.00"
                gettingdetails(row.Cells(1).Value.ToString)
                'Call cmbtransactions_LostFocus(sender, e)
            Next
        End If
    End Sub

    Private Sub chkdate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkdate.CheckedChanged
        fromdate.Enabled = chkdate.Checked
        todate.Enabled = chkdate.Checked
        If chkdate.Checked = True Then fromdate.Focus()
    End Sub

    Private Sub cmbtransactions_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbtransactions.KeyPress
        enterkeypress(e, Me)
    End Sub

    Private Sub fromdate_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles fromdate.KeyDown
        If e.KeyCode = 13 Then
            SendKeys.Send("{Tab}")
            e.Handled = False
        End If
    End Sub

    Private Sub todate_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles todate.KeyDown
        If e.KeyCode = 13 Then
            SendKeys.Send("{Tab}")
            e.Handled = False
        End If
    End Sub

    Private Sub cmbtransactions_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbtransactions.LostFocus

        dt = New DataTable()
        If tempconn.State = ConnectionState.Open Then
            tempconn.Close()
        End If
        tempconn.Open()

        If cmbtransactions.Text.Trim = "All..." Or cmbtransactions.Text.Trim = "" Then
            tempcmd = New OleDbCommand("select 'Purchase Bill'as Type, purchasemaster.bill_no, ledgermaster.ledger_name,purchasemaster.bill_date, purchasemaster.bill_qty, purchasemaster.bill_gtotal,'Purchasemaster' as tablename from purchasemaster inner join ledgermaster on ledgermaster.ledger_id = purchasemaster.bill_ledgerid where purchasemaster.bill_ledgerid = " & tempnameid & " union select 'Order'as Type, ordermaster.order_no, ledgermaster.ledger_name,ordermaster.order_date, ordermaster.order_qty,ordermaster.order_total, 'ordermaster' as tablename from ordermaster inner join ledgermaster on ledgermaster.ledger_id = ordermaster.order_ledgerid where ordermaster.order_ledgerid =" & tempnameid & " union select 'Invoice'as Type, invoicemaster.invoice_no, ledgermaster.ledger_name,invoicemaster.invoice_date, invoicemaster.invoice_qty,invoicemaster.invoice_grandtotal,'invoicemaster' as tablename from invoicemaster inner join ledgermaster on ledgermaster.ledger_id = invoicemaster.invoice_deliveryid where invoicemaster.invoice_deliveryid =" & tempnameid & " union select 'Invoice Challan' as type, challanmaster.challan_no, ledgermaster.ledger_name, challanmaster.challan_date, challanmaster.challan_qty, '0' as challantotal,'challanmaster' as tablename from challanmaster inner join ledgermaster on ledgermaster.ledger_id = challanmaster.challan_ledgerid where challanmaster.challan_ledgerid = " & tempnameid, tempconn)
        ElseIf cmbtransactions.Text.Trim = "Purchase Bill..." Then
            tempcmd = New OleDbCommand("select 'Purchase Bill'as Type, purchasemaster.bill_no, ledgermaster.ledger_name,purchasemaster.bill_date, purchasemaster.bill_qty, purchasemaster.bill_gtotal,'purchasemaster' as tablename from purchasemaster inner join ledgermaster on ledgermaster.ledger_id = purchasemaster.bill_ledgerid where purchasemaster.bill_ledgerid = " & tempnameid, tempconn)
        ElseIf cmbtransactions.Text.Trim = "Order..." Then
            tempcmd = New OleDbCommand("select 'Order'as Type, ordermaster.order_no, ledgermaster.ledger_name, ordermaster.order_date, ordermaster.order_qty, ordermaster.order_total,'ordermaster' as tablename from ordermaster inner join ledgermaster on ledgermaster.ledger_id = ordermaster.order_ledgerid where ordermaster.order_ledgerid = " & tempnameid, tempconn)
        ElseIf cmbtransactions.Text.Trim = "Invoice Challan..." Then
            tempcmd = New OleDbCommand("select 'Invoice Challan'as Type, Challanmaster.Challan_no, ledgermaster.ledger_name, Challanmaster.Challan_date, Challanmaster.challan_qty, '0' as challanqty,'challanmaster' as tablename from challanmaster inner join ledgermaster on ledgermaster.ledger_id = challanmaster.challan_ledgerid where challanmaster.challan_ledgerid = " & tempnameid, tempconn)
        ElseIf cmbtransactions.Text.Trim = "Invoice..." Then
            tempcmd = New OleDbCommand("select 'Invoice'as Type, invoicemaster.invoice_no, ledgermaster.ledger_name, invoicemaster.invoice_date, invoicemaster.invoice_qty, invoicemaster.invoice_grandtotal, 'invoicemaster' as tablename from invoicemaster inner join ledgermaster on ledgermaster.ledger_id = invoicemaster.invoice_deliveryid where invoicemaster.invoice_deliveryid =" & tempnameid, tempconn)
        End If

        da = New OledbDataAdapter(tempcmd)
        da.Fill(dt)

        gridtransactions.DataSource = dt

        gridtransactions.Columns(0).HeaderText = "Trans. Type"
        gridtransactions.Columns(1).HeaderText = "No."
        gridtransactions.Columns(2).HeaderText = "Cmp. Name"
        gridtransactions.Columns(3).HeaderText = "Date"
        gridtransactions.Columns(4).HeaderText = "Total Qty."
        gridtransactions.Columns(5).HeaderText = "Total Amt."
        gridtransactions.Columns(6).HeaderText = "tablename"

        gridtransactions.Columns(0).Width = 110
        gridtransactions.Columns(1).Width = 70
        gridtransactions.Columns(2).Width = 200
        gridtransactions.Columns(3).Width = 80
        gridtransactions.Columns(4).Width = 100
        gridtransactions.Columns(5).Width = 100
        gridtransactions.Columns(6).Width = 100

        gridtransactions.Columns(6).Visible = False

        lbltotal.Text = "0"
        For Each row As DataGridViewRow In gridtransactions.Rows
            lbltotal.Text = Format(Val(lbltotal.Text) + row.Cells(5).Value, "0.00")
        Next

        da.Dispose()
        dt.Dispose()
        tempconn.Close()
        tempcmd.Dispose()

    End Sub

    Private Sub txtcmp_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcmp.KeyPress
        enterkeypress(e, Me)
    End Sub

    Private Sub txtcmp_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcmp.TextChanged
        Dim rowno, b As Integer

        fillgridname()
        ' gridname.Sort(namecmp, System.ComponentModel.ListSortDirection.Ascending)
        rowno = 0
        For b = 1 To gridname.RowCount

            txttempname.Text = gridname.Item(0, rowno).Value.ToString()

            txttempname.SelectionStart = 0
            txttempname.SelectionLength = txtcmp.TextLength
            If LCase(txtcmp.Text.Trim) <> LCase(txttempname.SelectedText.Trim) Then
                gridname.Rows.RemoveAt(rowno)
            Else
                rowno = rowno + 1
            End If

        Next
    End Sub

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub vendordetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Alt = True And e.KeyCode = Windows.Forms.Keys.E Then       'for EDIT
            Call cmdedit_Click(sender, e)
        ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.D Then       'for DELETRE
            Call CMDDELETE_Click(sender, e)
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            Me.Close()
        End If

        '*********** CTRL + N ************
        If (e.Control = True And e.KeyCode = Keys.N) Or (e.Alt = True And e.KeyCode = Keys.A) Then
            'adding new account
            If USERADD = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If (chldvendormaster.IsMdiChild = False) Then
                If chldvendormaster.IsDisposed = True Then
                    chldvendormaster = New ACCOUNTMASTER
                End If
                chldvendormaster.MdiParent = MDIMain
                chldvendormaster.Show()
                chldvendormaster.cmdedit.Enabled = True
                chldvendormaster.EDIT = False
            Else
                chldvendormaster.BringToFront()
            End If
        End If
    End Sub

    Private Sub cmdedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdedit.Click
        If Me.gridname.SelectedRows.Count > 0 Then
            For Each row As DataGridViewRow In gridname.SelectedRows
                tempname = row.Cells(1).Value.ToString
                'tempgroupname = row.Cells(1).Value.ToString
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                If (chldvendormaster.IsMdiChild = False) Then
                    If chldvendormaster.IsDisposed = True Then
                        chldvendormaster = New ACCOUNTMASTER
                    End If
                    chldvendormaster.cmdedit.Enabled = False
                    chldvendormaster.EDIT = True
                    chldvendormaster.MdiParent = MDIMain
                    chldvendormaster.cmdedit.Enabled = False
                    chldvendormaster.Show()
                Else
                    chldvendormaster.BringToFront()
                End If

            Next
        End If

    End Sub

    Private Sub ToolStripdelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Call CMDDELETE_Click(sender, e)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PBEXCEL_Click(sender As Object, e As EventArgs) Handles PBEXCEL.Click
        Try
            Dim OBJACC As New LedgerDetailsReport
            OBJACC.MdiParent = MDIMain
            OBJACC.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridname_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridname.KeyDown
        If e.KeyCode = Keys.Delete Then

            If USERDELETE = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If


            tempcmd = New OleDbCommand("select ledger_id from ledgermaster where ledger_code = '" & tempname & "'", tempconn)
            If tempconn.State = ConnectionState.Open Then
                tempconn.Close()
            End If
            tempconn.Open()
            tempdr = tempcmd.ExecuteReader()
            If tempdr.HasRows Then
                tempdr.Read()
                tempnameid = tempdr(0)
            End If
            tempmsg = MsgBox("Wish To Delete Ledger?", MsgBoxStyle.YesNo)
            If tempmsg = vbYes Then
                If gridname.Rows(gridname.CurrentRow.Index).Cells(2).Value <> 0 Then
                    tempmsg = MsgBox("Ledger Contain transactions Wish to Continue?", MsgBoxStyle.YesNo)
                End If
                If tempmsg = vbYes Then
                    cmd = New OleDbCommand("delete from accountmaster where account_ledgerid = " & tempnameid, conn)
                    If conn.State = ConnectionState.Open Then
                        conn.Close()
                    End If
                    conn.Open()
                    cmd.ExecuteNonQuery()

                    cmd = New OleDbCommand("delete from vouchers where voucher_ledgerid = " & tempnameid, conn)
                    If conn.State = ConnectionState.Open Then
                        conn.Close()
                    End If
                    conn.Open()
                    cmd.ExecuteNonQuery()

                    cmd = New OleDbCommand("delete from ledgermaster where ledger_id = " & tempnameid, conn)
                    If conn.State = ConnectionState.Open Then
                        conn.Close()
                    End If
                    conn.Open()
                    cmd.ExecuteNonQuery()
                End If
            End If
            MsgBox("Ledger Deleted")
            fillgridname()
            gridname.Refresh()
            clear()
        End If
    End Sub

    Private Sub CMDDELETE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try

            If USERDELETE = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If


            tempcmd = New OleDbCommand("select ledger_id from ledgermaster where ledger_code = '" & tempname & "'", tempconn)
            If tempconn.State = ConnectionState.Open Then
                tempconn.Close()
            End If
            tempconn.Open()
            tempdr = tempcmd.ExecuteReader()
            If tempdr.HasRows Then
                tempdr.Read()
                tempnameid = tempdr(0)
            End If
            tempmsg = MsgBox("Wish To Delete Ledger?", MsgBoxStyle.YesNo)
            If tempmsg = vbYes Then
                If gridname.Rows(gridname.CurrentRow.Index).Cells(2).Value <> 0 Then
                    tempmsg = MsgBox("Ledger Contain transactions Wish to Continue?", MsgBoxStyle.YesNo)
                End If
                If tempmsg = vbYes Then
                    cmd = New OleDbCommand("delete from accountmaster where account_ledgerid = " & tempnameid, conn)
                    If conn.State = ConnectionState.Open Then
                        conn.Close()
                    End If
                    conn.Open()
                    cmd.ExecuteNonQuery()

                    cmd = New OleDbCommand("delete from vouchers where voucher_ledgerid = " & tempnameid, conn)
                    If conn.State = ConnectionState.Open Then
                        conn.Close()
                    End If
                    conn.Open()
                    cmd.ExecuteNonQuery()

                    cmd = New OleDbCommand("delete from ledgermaster where ledger_id = " & tempnameid, conn)
                    If conn.State = ConnectionState.Open Then
                        conn.Close()
                    End If
                    conn.Open()
                    cmd.ExecuteNonQuery()
                End If
            End If
            MsgBox("Ledger Deleted")
            fillgridname()
            gridname.Refresh()
            clear()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub vendordetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'ACCOUNTS MASTER'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            clear()
            fillgridname()
            ' gridname.Sort(namecmp, System.ComponentModel.ListSortDirection.Ascending)
            tempuse = False
            cmbtransactions.SelectedIndex = (0)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class