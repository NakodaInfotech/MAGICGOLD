Imports System.Data.OleDb

Public Class vouchers

    Dim m_EditingRow As Integer = -1
    Dim types As String
    Public EDIT As Boolean = False
    Public FRMSTRING As String = ""
    Public TEMPBILLNO As String = ""

    Private Sub vouchers_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            If frmdailykhata = True Then
                ' Me.Close()
                'If (chlddailykhata.IsMdiChild = False) Then 
                '    If chlddailykhata.IsDisposed = True Then
                '        chlddailykhata = New dailykhata
                '    End If
                '    chlddailykhata.MdiParent = MDIMain
                '    chlddailykhata.Show()
                'Else
                '    chlddailykhata.BringToFront()
                'End If
                Dim OBJVOUCHER As New Voucherdetails
                OBJVOUCHER.MdiParent = MdiParent
                OBJVOUCHER.FRMSTRING = "ISSUE"
                OBJVOUCHER.Show()

            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub vouchers_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Alt = True And e.KeyCode = Windows.Forms.Keys.S Then       'for Saving
            Call cmdok_Click(sender, e)
        ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            If cmbname.Text.Trim <> "" And griddetails.RowCount > 0 And txtbillno.Text.Trim <> "" And chkchange.CheckState = CheckState.Checked Then
                tempmsg = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                If tempmsg = vbYes Then cmdok_Click(sender, e)
            End If
            Me.Close()
        ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.D0 Then       'for clear
            txtnarration.Focus()
        ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.Left Then       'for DELETE
            Call toolprevious_Click(sender, e)
        ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.Right Then       'for DELETE
            Call toolnext_Click(sender, e)
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        ElseIf e.Control = True And e.KeyCode = Keys.N Then
            If cmbname.Text.Trim <> "" And griddetails.RowCount > 0 And txtbillno.Text.Trim <> "" And chkchange.CheckState = CheckState.Checked Then
                tempmsg = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                If tempmsg = vbYes Then cmdok_Click(sender, e)
            End If
            clear()
        End If
    End Sub

    Private Sub vouchers_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        'esc
        If AscW(e.KeyChar) <> 33 Then
            chkchange.CheckState = CheckState.Checked
        End If
    End Sub

    Private Sub vouchers_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

        If ClientName = "CNC" Then GFINEWT.ReadOnly = True
        clear()
        If FRMSTRING = "ISSUE" Then
            lbl.Text = "Invoice"
            types = "I"
            Me.Text = "Issue Voucher"
        Else
            lbl.Text = "Reciept"
            types = "R"
            Me.Text = "Reciept Voucher"
        End If

        tempcondition = ""
        fillexpense()
        fillcmbless()
        fillitem()
        fillcmbsalesmen()

        tempcondition = ""


        If cmbname.Text.Trim = "" Then fillname(Me, cmbname, tempcondition)


        If cmdedit.Enabled = True Then EDIT = False
        If cmdedit.Enabled = False Then EDIT = True

        If EDIT = True Then

            cmd = New OleDbCommand("select vouchers.*,salesmenmaster.salesmen_name from vouchers left join salesmenmaster on salesmenmaster.salesmen_id=vouchers.voucher_salesmenid where voucher_id = " & TEMPBILLNO & "and voucher_type='" & types & "' ORDER BY VOUCHERS.VOUCHER_GRIDSRNO", conn)
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
            conn.Open()
            dr = cmd.ExecuteReader
            If dr.HasRows = True Then

                While (dr.Read)

                    txtbillno.Text = Val(dr(0))
                    DTPicker.Value = dr(1).ToString

                    'gettign ledgername
                    tempcmd = New OleDbCommand("select ledger_code,ledger_name,ledger_id,ledgermaster.ledger_opbalrs, IIF(ISNULL(ledgermaster.ledger_drcrrs) = TRUE , 'Cr.', ledgermaster.ledger_drcrrs), ledgermaster.ledger_opbalwt, IIF(ISNULL(ledgermaster.ledger_drcrWT) = TRUE , 'Cr.', ledgermaster.ledger_drcrWT) from ledgermaster where ledger_id = " & dr(2), tempconn)
                    If tempconn.State = ConnectionState.Open Then
                        tempconn.Close()
                    End If
                    tempconn.Open()
                    tempdr = tempcmd.ExecuteReader
                    While (tempdr.Read)
                        tempname = tempdr(0).ToString
                        cmbname.Text = tempdr(0).ToString
                        lblname.Text = tempdr(1).ToString
                    End While
                    tempdr.Close()
                    tempconn.Close()

                    lblfinebal.Text = GETBALANCEWT(cmbname.Text.Trim, DTPicker.Value.Date)
                    lblamtbal.Text = GETBALANCEAMT(cmbname.Text.Trim, DTPicker.Value.Date)

                    If dr(3) <> 0 Then
                        'gettign itemcode
                        tempcmd = New OleDbCommand("select item_code from itemmaster where item_id = " & Val(dr(3)), tempconn)
                        If tempconn.State = ConnectionState.Open Then
                            tempconn.Close()
                        End If
                        tempconn.Open()
                        tempdr = tempcmd.ExecuteReader
                        While (tempdr.Read)
                            tempitemcode = tempdr(0).ToString
                        End While
                        tempdr.Close()
                        tempconn.Close()

                        griddetails.Rows.Add(i, tempitemcode, dr("VOUCHER_ITEMDESC"), Format(Val(dr(4)), "0.000"), Format(Val(dr("VOUCHER_LESSWT")), "0.000"), Format(Val(dr("VOUCHER_GROSSLESS")), "0.000"), Format(Val(dr(5)), "0.00"), Format(Val(dr(6)), "0.00"), Format(Val(dr(7)), "0.000"), Format(Val(dr(8)), "0.00"), Format(Val(dr("VOUCHER_STONERATE")), "0.00"), Val(dr(9)), Format(Val(dr(10)), "0.000"), Format(Val(dr(11)), "0.00"), Format(Val(dr("VOUCHER_DIFF")), "0.000"))
                    End If

                    txtbhavcut.Text = Format(Val(dr(12)), "0.00")
                    txtrate.Text = Format(Val(dr(13)), "0.00")
                    txtperwt.Text = Val(dr(14))
                    txtbalwt.Text = Format(Val(dr(16)), "0.000")
                    txtamount.Text = Format(Val(dr(17)), "0.00")
                    txtsubtotal.Text = Format(Val(dr(18)), "0.00")
                    txtcashrec.Text = Format(Val(dr(19)), "0.00")
                    txtbalamt.Text = Format(Val(dr(20)), "0.00")
                    txtnarration.Text = dr(24).ToString
                    If FRMSTRING = "RECEIPT" Then
                        types = "R"
                    Else
                        types = "I"
                    End If
                    txtaddtotal.Text = Format(Val(dr(26)), "0.00")
                    txtlesstotal.Text = Format(Val(dr(27)), "0.00")
                    txtinwords.Text = dr(28).ToString
                    txtcrdays.Text = Val(dr(29))

                    'gettign expensename
                    tempcmd = New OleDbCommand("select ledger_name from ledgermaster where ledger_id = " & Val(dr(30)), tempconn)
                    If tempconn.State = ConnectionState.Open Then
                        tempconn.Close()
                    End If
                    tempconn.Open()
                    tempdr = tempcmd.ExecuteReader
                    While (tempdr.Read)
                        tempexpname = tempdr(0).ToString
                    End While
                    tempdr.Close()
                    tempconn.Close()

                    If Val(dr(30)) <> "0" Then
                        gridadd.Rows.Add(tempexpname, dr(31).ToString, Format(Val(dr(32)), "0.00"))
                    End If


                    'gettign expensename
                    tempcmd = New OleDbCommand("select ledger_name from ledgermaster where ledger_id = " & Val(dr(33)), tempconn)
                    If tempconn.State = ConnectionState.Open Then
                        tempconn.Close()
                    End If
                    tempconn.Open()
                    tempdr = tempcmd.ExecuteReader
                    While (tempdr.Read)
                        templessname = tempdr(0).ToString
                    End While
                    tempdr.Close()
                    tempconn.Close()

                    If Val(dr(33)) <> "0" Then
                        gridless.Rows.Add(templessname, dr(34).ToString, Format(Val(dr(35)), "0.00"))
                    End If
                    cmbsalesmen.Text = dr(37).ToString
                End While

                If griddetails.RowCount > 0 Then griddetails.FirstDisplayedScrollingRowIndex = griddetails.RowCount - 1

            End If

            TOTAL()
        End If
    End Sub

    Sub fillexpense()

        cmb_add.Items.Clear()
        cmd = New OleDbCommand("select ledger_name from ledgermaster INNER JOIN GROUPMASTER ON ledgermaster.ledger_groupid = GROUPMASTER.GROUP_ID where (group_name = 'Indirect Expenses' or group_name = 'Indirect Income' OR group_name = 'Direct Expenses' OR group_name = 'Direct Income' OR group_name = 'Duties & Taxes')", conn)
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If
        conn.Open()
        dr = cmd.ExecuteReader
        If dr.HasRows Then
            While (dr.Read)
                cmb_add.Items.Add(dr(0))
            End While
        End If

    End Sub

    Sub fillcmbless()

        cmb_less.Items.Clear()

        cmd = New OleDbCommand("select ledger_name from ledgermaster INNER JOIN GROUPMASTER ON ledgermaster.ledger_groupid = GROUPMASTER.GROUP_ID where (group_name = 'Indirect Expenses' or group_name = 'Indirect Income' OR group_name = 'Direct Expenses' OR group_name = 'Direct Income'  OR group_name = 'Duties & Taxes')", conn)
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If
        conn.Open()
        dr = cmd.ExecuteReader
        If dr.HasRows Then
            While (dr.Read)
                cmb_less.Items.Add(dr(0))
            End While
        End If

    End Sub

    Sub clear()

        EP.Clear()
        For i = 1 To 100
            tempcol(i) = ""
            tempval(i) = ""
        Next

        'clearing textboxes
        lblname.Text = ""
        cmbsalesmen.Text = ""
        cmbname.Text = ""
        txtbhavcut.Text = "0.000"
        txtamount.Text = "0.00"
        txtperwt.Text = "0.00"
        txtrate.Text = "0.00"
        txtbalamt.Text = "0.00"
        txtbalwt.Text = "0.000"
        DTPicker.Value = GLOBALDATE
        txtcashrec.Text = "0.00"
        'txtdiscount.Text = "0"
        gridadd.RowCount = 1
        gridless.RowCount = 1
        griddetails.RowCount = 1

        'getting voucher_id from database
        GETMAX_VOUCHER_NO()


        EDIT = False

    End Sub

    Sub GETMAX_VOUCHER_NO()
        If FRMSTRING = "ISSUE" Then
            cmd = New OleDbCommand("select max(voucher_id) from vouchers where voucher_type ='I'", conn)
        ElseIf FRMSTRING = "RECEIPT" Then
            cmd = New OleDbCommand("select max(voucher_id) from vouchers where voucher_type ='R'", conn)
        End If
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If
        conn.Open()
        dr = cmd.ExecuteReader
        If dr.HasRows Then
            dr.Read()
            txtbillno.Text = Val(dr(0).ToString)
            txtbillno.Text = Val(txtbillno.Text) + 1
        End If
        conn.Close()
        dr.Close()
    End Sub

    Sub TOTAL()

        Dim a As Integer
        lblamounttotal.Text = "0.00"
        lblgrosswttotal.Text = "0.000"
        LBLTOTALLESSWT.Text = 0.00
        LBLTOTALNETTWT.Text = 0.00
        LBLTOTALFINEWT.Text = "0.000"
        lblpiecestotal.Text = "0"
        LBLDIFF.Text = "0.000"
        txtamount.Text = "0"
        txtbalwt.Text = "0.000"
        txtlesstotal.Text = "0.00"
        txtaddtotal.Text = "0.00"
        LBLTOTALLABOURAMT.Text = 0.00
        LBLTOTALSTONEAMT.Text = 0.00
        a = 0

        For Each row As DataGridViewRow In griddetails.Rows
            If row.Cells(1).Value <> Nothing Then
                lblamounttotal.Text = Format(Val(lblamounttotal.Text) + Val(row.Cells(GAMT.Index).EditedFormattedValue), "0.00")
                lblgrosswttotal.Text = Format(Val(lblgrosswttotal.Text) + Val(row.Cells(GGROSSWT.Index).EditedFormattedValue), "0.000")
                LBLTOTALLESSWT.Text = Format(Val(LBLTOTALLESSWT.Text) + Val(row.Cells(GLESSWT.Index).EditedFormattedValue), "0.000")
                LBLTOTALNETTWT.Text = Format(Val(LBLTOTALNETTWT.Text) + Val(row.Cells(GGROSSLESS.Index).EditedFormattedValue), "0.000")
                LBLTOTALFINEWT.Text = Format(Val(LBLTOTALFINEWT.Text) + Val(row.Cells(GFINEWT.Index).EditedFormattedValue), "0.000")
                lblpiecestotal.Text = Format(Val(lblpiecestotal.Text) + Val(row.Cells(GPCS.Index).EditedFormattedValue), "0.000")
                row.Cells(GDIFFWT.Index).Value = Format(Val(row.Cells(GFINEWT.Index).EditedFormattedValue) - (((Val(row.Cells(GGROSSWT.Index).EditedFormattedValue) - Val(row.Cells(GLESSWT.Index).EditedFormattedValue)) * Val(row.Cells(GPURITY.Index).EditedFormattedValue)) / 100), "0.000")
                LBLDIFF.Text = Format(Val(LBLDIFF.Text) + Val(row.Cells(GDIFFWT.Index).EditedFormattedValue), "0.000")


                'GIVE BIFFURCATION OF LABOUR AMT AND STONE AMT
                If Val(row.Cells(GSTONERATE.Index).EditedFormattedValue) > 0 Then
                    LBLTOTALSTONEAMT.Text = Format(Val(LBLTOTALSTONEAMT.Text) + Val(row.Cells(GAMT.Index).EditedFormattedValue), "0.00")
                Else
                    LBLTOTALLABOURAMT.Text = Format(Val(LBLTOTALLABOURAMT.Text) + Val(row.Cells(GAMT.Index).EditedFormattedValue), "0.00")
                End If

            End If
            a = a + 1
            row.Cells(0).Value = a
        Next

        For Each row As DataGridViewRow In gridadd.Rows
            If row.Cells(0).Value <> Nothing Then
                txtaddtotal.Text = Format(Val(txtaddtotal.Text) + Val(row.Cells(GADDAMT.Index).EditedFormattedValue), "0.00")
            End If
        Next

        For Each row As DataGridViewRow In gridless.Rows
            If row.Cells(0).Value <> Nothing Then
                txtlesstotal.Text = Format(Val(txtlesstotal.Text) + Val(row.Cells(lessamt.Index).EditedFormattedValue), "0.00")
            End If
        Next

        'IF RATE IS WRITTEN THEN CALC BHAVUT ON FULL AMOUNT
        If Val(txtrate.Text.Trim) > 0 Then
            If Val(txtbhavcut.Text.Trim) > 0 Then txtamount.Text = Format((Val(txtrate.Text) * Val(txtbhavcut.Text.Trim)) / Val(txtperwt.Text), "0.00") Else If Val(txtrate.Text.Trim) > 0 Then txtamount.Text = Format((Val(txtrate.Text) * Val(LBLTOTALFINEWT.Text.Trim)) / Val(txtperwt.Text), "0.00")
        End If
        txtsubtotal.Text = Format(Val(Val(txtamount.Text) + Val(txtaddtotal.Text) + Val(lblamounttotal.Text) - Val(txtlesstotal.Text)), "0.00")
        txtbalamt.Text = Format(Val(txtsubtotal.Text) - (Val(txtcashrec.Text)), "0.00")
        txtbalwt.Text = Format(Val(LBLTOTALFINEWT.Text) - Val((txtbhavcut.Text)), "0.000")
        If Val(txtbalamt.Text) > 0 Then txtinwords.Text = CurrencyToWord(txtbalamt.Text)

    End Sub

    Private Sub cmbname_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbname.KeyDown
        Try
            If e.KeyCode = Keys.F1 And e.Alt = True Then
                Dim OBJSELECT As New SelectLedger
                'OBJSELECT.STRSEARCH = " AND (GROUPMASTER.GROUP_NAME = 'Sundry Debtor' or GROUPMASTER.GROUP_NAME = 'Sundry Creditors')"
                OBJSELECT.STRSEARCH = ""
                OBJSELECT.ShowDialog()
                cmbname.Text = OBJSELECT.TEMPCODE
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbname.Validating
        If cmbname.Text.Trim <> "" Then

            cmbname.Text = uppercase(cmbname.Text)

            'cmd = New OleDbCommand("SELECT ledgermaster.ledger_code,ledgermaster.ledger_id,ledgermaster.ledger_name,ledgermaster.ledger_opbalrs, IIF(ISNULL(ledgermaster.ledger_drcrrs) = TRUE , '',ledgermaster.ledger_drcrrs), ledgermaster.ledger_opbalwt, IIF(ISNULL(ledgermaster.ledger_drcrwt) = TRUE , '',ledgermaster.ledger_drcrwt) from ledgermaster inner join groupmaster on groupmaster.group_id = ledgermaster.ledger_groupid where ledgermaster.ledger_code = '" & cmbname.Text.Trim & "' and ( groupmaster.group_name = 'Sundry Creditors' or groupmaster.group_name = 'Sundry Debtors'  )", conn)
            cmd = New OleDbCommand("SELECT ledgermaster.ledger_code,ledgermaster.ledger_id,ledgermaster.ledger_name,ledgermaster.ledger_opbalrs, IIF(ISNULL(ledgermaster.ledger_drcrrs) = TRUE , '',ledgermaster.ledger_drcrrs), ledgermaster.ledger_opbalwt, IIF(ISNULL(ledgermaster.ledger_drcrwt) = TRUE , '',ledgermaster.ledger_drcrwt) from ledgermaster inner join groupmaster on groupmaster.group_id = ledgermaster.ledger_groupid where ledgermaster.ledger_code = '" & cmbname.Text.Trim & "'", conn)
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
            conn.Open()

            dr = cmd.ExecuteReader
            If dr.HasRows Then
                dr.Read()
                tempnameid = dr(1)
                lblname.Text = uppercase(dr(2).ToString)
                lblfinebal.Text = 0
                lblamtbal.Text = 0
                'OLD CODE CHANGED BY GULKIT FOR TESTING
                'If dr(4) = "Cr." Then
                '    lblamtbal.Text = Val(dr(3))
                'Else
                '    lblamtbal.Text = -1 * Val(dr(3))
                'End If

                'If dr(6) = "Cr." Then
                '    lblfinebal.Text = Val(dr(5))

                'Else
                '    lblfinebal.Text = -1 * Val(dr(5))

                'End If

                'tempcmd = New OleDbCommand("select code,nettwt,amount,type from ledgeraccounts where code='" & dr(0).ToString & "' order by type", tempconn)
                'If tempconn.State = ConnectionState.Open Then
                '    tempconn.Close()
                'End If
                'tempconn.Open()
                'tempdr = tempcmd.ExecuteReader
                'If tempdr.HasRows = True Then
                '    While (tempdr.Read)
                '        If tempdr(3) = "Jama" Then
                '            lblfinebal.Text = Val(lblfinebal.Text) + Val(tempdr(1))
                '            lblamtbal.Text = Val(lblamtbal.Text) + Val(tempdr(2))
                '        ElseIf tempdr(3) = "Balance" Then
                '            lblfinebal.Text = Val(lblfinebal.Text) - Val(tempdr(1))
                '            lblamtbal.Text = Val(lblamtbal.Text) - Val(tempdr(2))
                '        ElseIf tempdr(3) = "I" Then
                '            lblfinebal.Text = Val(lblfinebal.Text) - Val(tempdr(1))
                '            lblamtbal.Text = Val(lblamtbal.Text) - Val(tempdr(2))
                '        ElseIf tempdr(3) = "R" Then
                '            lblfinebal.Text = Val(lblfinebal.Text) + Val(tempdr(1))
                '            lblamtbal.Text = Val(lblamtbal.Text) + Val(tempdr(2))
                '        ElseIf tempdr(3) = "RAMT" Or tempdr(3) = "IWT" Then
                '            lblfinebal.Text = Val(lblfinebal.Text) + Val(tempdr(1))
                '            lblamtbal.Text = Val(lblamtbal.Text) - Val(tempdr(2))
                '        ElseIf tempdr(3) = "RWT" Or tempdr(3) = "IAMT" Then
                '            lblfinebal.Text = Val(lblfinebal.Text) - Val(tempdr(1))
                '            lblamtbal.Text = Val(lblamtbal.Text) + Val(tempdr(2))
                '        End If
                '    End While
                'End If
                '******************* END OF CODE *******************

                '************* START OF NEW CODE **********
                lblfinebal.Text = GETBALANCEWT(cmbname.Text.Trim, DTPicker.Value.Date)
                lblamtbal.Text = GETBALANCEAMT(cmbname.Text.Trim, DTPicker.Value.Date)
                '************* END OF NEW CODE **********

            Else
                tempmsg = MsgBox("Ledger Not Present, Add New?", MsgBoxStyle.YesNo)
                If tempmsg = vbYes Then

                    If (chldvendormaster.IsMdiChild = False) Then
                        If chldvendormaster.IsDisposed = True Then
                            chldvendormaster = New ACCOUNTMASTER
                        End If
                        chldvendormaster.txtname.Text = cmbname.Text
                        chldvendormaster.cmdedit.Enabled = True
                        EDIT = False
                        e.Cancel = True
                        chldvendormaster.Show(Me)
                        chldvendormaster.ActiveControl = (chldvendormaster.txtname)
                        chldvendormaster.txtname.Focus()
                    Else
                        chldvendormaster.BringToFront()
                    End If
                Else
                    cmbname.Focus()
                End If
            End If

        End If
    End Sub

    Function ERRORVALID() As Boolean
        Try
            Dim BLN As Boolean = True
            For Each ROW As DataGridViewRow In griddetails.Rows
                If ROW.Index = griddetails.RowCount - 1 Then Exit For
                If ROW.Cells(cmbitemcode.Index).Value = Nothing Then
                    EP.SetError(cmbname, "Item Name Cannot be Blank in Grid Below")
                    BLN = False
                End If
                If Val(ROW.Cells(GPURITY.Index).Value = 0) And ClientName = "ADITYA" Then
                    EP.SetError(cmbname, "Purity Cannot be 0")
                    BLN = False
                End If
            Next

            If cmbname.Text.Trim = "" Then
                EP.SetError(cmbname, "Select Party")
                BLN = False
            End If

            If Val(lblgrosswttotal.Text.Trim) = 0 Then
                EP.SetError(cmbname, "Gross Wt cannot be 0")
                BLN = False
            End If

            If Val(LBLTOTALFINEWT.Text.Trim) = 0 And ClientName <> "KHUSHALI" Then
                EP.SetError(cmbname, "Nett Wt cannot be 0")
                BLN = False
            End If

            If griddetails.RowCount = 1 Then
                EP.SetError(cmbname, "Insert Item Details")
                BLN = False
            End If


            'CHECK CR LIMIT FROM ACCOUNTMASTER AND THEN VALIDATE
            If FRMSTRING = "ISSUE" Then
                dt = New DataTable()
                If tempconn.State = ConnectionState.Open Then tempconn.Close()
                tempconn.Open()
                tempcmd = New OleDbCommand("SELECT LEDGERMASTER.LEDGER_CRLIMIT AS CRLIMIT, CODE, SUM(GROSSDR) - SUM(GROSSCR) AS GROSSWT, SUM(DR) - SUM(CR) AS BALWT, SUM(AMTDR) - SUM(AMTCR) AS BALAMT FROM (SELECT ACCOUNT_LEDGERCODE AS CODE, SUM(ACCOUNT_GROSSWT) AS GROSSDR, 0 AS GROSSCR, SUM(ACCOUNT_NETTWT) AS DR, 0 AS CR, SUM(ACCOUNT_AMOUNT) AS AMTDR, 0 AS AMTCR FROM ACCOUNTMAST WHERE ACCOUNT_BALORJAMAORPAID= 'Jama' AND ACCOUNT_LEDGERCODE = '" & cmbname.Text.Trim & "' GROUP BY ACCOUNT_LEDGERCODE UNION ALL SELECT LEDGER_CODE AS CODE, ROUND(LEDGER_OPBALGROSSWT,3) AS GROSSDR, 0 AS GROSSCR, 0 AS DR, 0 AS CR, 0 AS AMTDR, 0 AS AMTCR FROM LEDGERMASTER WHERE LEDGER_DRCRGROSSWT= 'Cr.' AND LEDGER_CODE = '" & cmbname.Text.Trim & "' UNION ALL SELECT LEDGER_CODE AS CODE, 0 AS GROSSDR, 0 AS GROSSCR, ROUND(LEDGER_OPBALWT,3) AS DR, 0 AS CR, 0 AS AMTDR, 0 AS AMTCR FROM LEDGERMASTER WHERE LEDGER_DRCRWT= 'Cr.' AND LEDGER_CODE = '" & cmbname.Text.Trim & "' UNION ALL SELECT LEDGER_CODE AS CODE, 0 AS GROSSDR, 0 AS GROSSCR, 0 AS DR, 0 AS CR, ROUND(LEDGER_OPBALRS,2) AS AMTDR, 0 AS AMTCR FROM LEDGERMASTER WHERE LEDGER_DRCRRS= 'Cr.' AND LEDGER_CODE = '" & cmbname.Text.Trim & "' UNION ALL SELECT LEDGER_CODE AS CODE, 0 AS GROSSDR, ROUND(LEDGER_OPBALGROSSWT,3) AS GROSSCR, 0 AS DR, 0 AS CR, 0 AS AMTDR, 0 AS AMTCR FROM LEDGERMASTER WHERE LEDGER_DRCRGROSSWT= 'Dr.' AND LEDGER_CODE = '" & cmbname.Text.Trim & "' UNION ALL SELECT LEDGER_CODE AS CODE, 0 AS GROSSDR, 0 AS GROSSCR, 0 AS DR, ROUND(LEDGER_OPBALWT,3) AS CR, 0 AS AMTDR, 0 AS AMTCR FROM LEDGERMASTER WHERE LEDGER_DRCRWT= 'Dr.' AND LEDGER_CODE = '" & cmbname.Text.Trim & "' UNION ALL SELECT LEDGER_CODE AS CODE, 0 AS GROSSDR, 0 AS GROSSCR, 0 AS DR, 0 AS CR, 0 AS AMTDR, ROUND(LEDGER_OPBALRS,2) AS AMTCR FROM LEDGERMASTER WHERE LEDGER_DRCRRS= 'Dr.' AND LEDGER_CODE = '" & cmbname.Text.Trim & "' UNION ALL SELECT ACCOUNT_LEDGERCODE AS CODE, 0 AS GROSSDR, SUM(ACCOUNT_GROSSWT) AS GROSSCR, 0 AS DR, SUM(ACCOUNT_NETTWT) AS CR, 0 AS AMTDR, SUM(ACCOUNT_AMOUNT) AS AMTCR FROM ACCOUNTMAST WHERE ACCOUNT_BALORJAMAORPAID = 'Balance' AND ACCOUNT_LEDGERCODE = '" & cmbname.Text.Trim & "' GROUP BY ACCOUNT_LEDGERCODE ) AS T INNER JOIN LEDGERMASTER ON T.CODE = LEDGERMASTER.LEDGER_CODE GROUP BY T.CODE, LEDGERMASTER.LEDGER_CRLIMIT", tempconn)
                da = New OleDbDataAdapter(tempcmd)
                da.Fill(dt)
                If dt.Rows.Count > 0 Then
                    If Val(dt.Rows(0).Item("CRLIMIT")) > 0 AndAlso Val(dt.Rows(0).Item("BALWT")) < 0 Then
                        If (Val(dt.Rows(0).Item("BALWT")) * -1) > Val(dt.Rows(0).Item("CRLIMIT")) Then
                            EP.SetError(cmbname, "Fine Wt Greater then Credit Limit")
                            BLN = False
                        End If
                    End If
                End If
                tempconn.Close()
                da.Dispose()
            End If

            Return BLN
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Sub GETSRNO(GRID As DataGridView)
        Try
            Dim I As Integer = 1
            For Each ROW As DataGridViewRow In GRID.Rows
                ROW.Cells(0).Value = I
                I += 1
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click

        GETSRNO(griddetails)


        'IF BACK DATED ENTRY IS TO BE SAVED THEN CHECK ENTRYPASSWORD
        If APPLYBLOCKDATE = True And DTPicker.Value.Date <= BLOCKEDDATE.Date Then
            Dim OBJPASS As New PasswordEntry
            OBJPASS.ShowDialog()
            If ENTRYPASSWORD <> OBJPASS.TXTDATERETYPE.Text.Trim Then
                MsgBox("Invaid Password", MsgBoxStyle.Critical)
                Exit Sub
            End If
        End If

        If cmbname.Text.Trim <> "" And txtbillno.Text.Trim <> "" Then

            If cmdedit.Enabled = False Then EDIT = True
            If cmdedit.Enabled = True Then EDIT = False


            EP.Clear()
            If Not ERRORVALID() Then
                Exit Sub
            End If



            'clearing array
            For i = 1 To 100
                tempcol(i) = ""
                tempval(i) = ""
            Next

            If EDIT = True Then
                cmd = New OleDbCommand("delete from vouchers where voucher_id = " & txtbillno.Text & " and voucher_type ='" & types & "'", conn)
                If conn.State = ConnectionState.Open Then conn.Close()
                conn.Open()
                cmd.ExecuteNonQuery()
                conn.Close()
            Else
                'IF MULTIPLE USERS ARE WORKING ON THE SAME FORM THEN WE NEED THIS
                GETMAX_VOUCHER_NO()
            End If

            tempcol(0) = "voucher_id"
            tempcol(1) = "voucher_date"
            tempcol(2) = "voucher_ledgerid"
            tempcol(3) = "voucher_itemid"
            tempcol(4) = "voucher_grosswt"
            tempcol(5) = "voucher_purity"
            tempcol(6) = "voucher_wastage"
            tempcol(7) = "voucher_nettwt"
            tempcol(8) = "voucher_labour"
            tempcol(9) = "voucher_pieces"
            tempcol(10) = "voucher_bullion"
            tempcol(11) = "voucher_amount"
            tempcol(12) = "voucher_bhavcut"
            tempcol(13) = "voucher_goldrate"
            tempcol(14) = "voucher_perwt"
            tempcol(15) = "voucher_othercharge"
            tempcol(16) = "voucher_balancewt"
            tempcol(17) = "voucher_amt"
            tempcol(18) = "voucher_totalamt"
            tempcol(19) = "voucher_cashrecieved"
            tempcol(20) = "voucher_balance"
            tempcol(21) = "voucher_balorjamaorpaid"
            tempcol(22) = "voucher_totalgrosswt"
            tempcol(23) = "voucher_totalnettwt"
            tempcol(24) = "voucher_narration"
            tempcol(25) = "voucher_type"
            tempcol(26) = "voucher_addtotal"
            tempcol(27) = "voucher_lesstotal"
            tempcol(28) = "voucher_inwords"
            tempcol(29) = "voucher_crdays"
            tempcol(30) = "voucher_expenseid"
            tempcol(31) = "voucher_expmemo"
            tempcol(32) = "voucher_expamt"
            tempcol(33) = "voucher_lessid"
            tempcol(34) = "voucher_lessmemo"
            tempcol(35) = "voucher_lessamt"
            tempcol(36) = "voucher_salesmenid"
            tempcol(37) = "VOUCHER_ITEMDESC"
            tempcol(38) = "VOUCHER_LESSWT"
            tempcol(39) = "VOUCHER_DIFF"
            tempcol(40) = "VOUCHER_USERID"
            tempcol(41) = "VOUCHER_DEPARTMENTID"
            tempcol(42) = "VOUCHER_GRIDSRNO"
            tempcol(43) = "VOUCHER_STONERATE"
            tempcol(44) = "VOUCHER_TOTALLABAMT"
            tempcol(45) = "VOUCHER_TOTALSTONEAMT"
            tempcol(46) = "VOUCHER_GROSSLESS"

            For i = 0 To griddetails.RowCount - 2


                tempval(0) = Val(txtbillno.Text)
                tempval(1) = "'" & Format(DTPicker.Value, "dd/MM/yyyy") & "'"

                'getting nameid
                cmd = New OleDbCommand("select ledger_id,ledger_code from ledgermaster where ledger_code = '" & cmbname.Text.Trim & "'", conn)
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
                conn.Open()
                dr = cmd.ExecuteReader()
                If dr.HasRows Then
                    dr.Read()
                    tempval(2) = Val(dr(0))
                    tempnameid = dr(0)
                    tempname = dr(1).ToString
                Else
                    tempval(2) = Val(0)
                End If
                conn.Close()

                'getting itemid
                cmd = New OleDbCommand("select item_id from itemmaster where item_code =  '" & griddetails.Item(cmbitemcode.Index, i).Value.ToString & "'", conn)
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
                conn.Open()
                dr = cmd.ExecuteReader()
                If dr.HasRows Then
                    dr.Read()
                    tempval(3) = Val(dr(0))
                Else
                    tempval(3) = Val(0)
                End If
                conn.Close()

                tempval(4) = Val(griddetails.Item(GGROSSWT.Index, i).Value)
                tempval(5) = Val(griddetails.Item(GPURITY.Index, i).Value)
                tempval(6) = Val(griddetails.Item(GWASTAGE.Index, i).Value)
                tempval(7) = Val(griddetails.Item(GFINEWT.Index, i).Value)
                tempval(8) = Val(griddetails.Item(GLABOUR.Index, i).Value)
                tempval(9) = Val(griddetails.Item(GPCS.Index, i).Value)
                tempval(10) = Val(griddetails.Item(GBULLION.Index, i).Value)
                tempval(11) = Val(griddetails.Item(GAMT.Index, i).Value)


                tempval(12) = Val(txtbhavcut.Text)
                tempval(13) = Val(txtrate.Text)
                tempval(14) = Val(txtperwt.Text)
                tempval(15) = Val(0)

                tempval(16) = Val(txtbalwt.Text)
                tempval(20) = Val(txtbalamt.Text)

                'If i = 0 Then
                '    tempval(16) = Val(txtbalwt.Text)
                '    tempval(20) = Val(txtbalamt.Text)
                'Else
                '    tempval(16) = Val(0)
                '    tempval(20) = Val(0)
                'End If
                tempval(17) = Val(txtamount.Text)
                tempval(18) = Val(lblamounttotal.Text)
                tempval(19) = Val(txtcashrec.Text)



                If FRMSTRING = "ISSUE" Then
                    tempval(21) = "'Balance'"
                Else
                    tempval(21) = "'Jama'"
                End If

                tempval(22) = Val(lblgrosswttotal.Text)
                tempval(23) = Val(LBLTOTALFINEWT.Text)

                tempval(24) = "'" & txtnarration.Text & "'"

                If FRMSTRING = "ISSUE" Then
                    tempval(25) = "'I'"
                ElseIf FRMSTRING = "RECEIPT" Then
                    tempval(25) = "'R'"
                End If
                tempval(26) = Val(txtaddtotal.Text)
                tempval(27) = Val(txtlesstotal.Text)
                tempval(28) = "'" & txtinwords.Text & "'"
                tempval(29) = Val(txtcrdays.Text)
                tempval(30) = Val(0)
                tempval(31) = "'0'"
                tempval(32) = Val(0)
                tempval(33) = Val(0)
                tempval(34) = "'0'"
                tempval(35) = Val(0)

                cmd = New OleDbCommand("select salesmen_id from salesmenmaster where salesmen_name =  '" & cmbsalesmen.Text.Trim & "'", conn)
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
                conn.Open()
                dr = cmd.ExecuteReader()
                If dr.HasRows Then
                    dr.Read()
                    tempval(36) = Val(dr(0))
                Else
                    tempval(36) = Val(0)
                End If
                conn.Close()

                If griddetails.Item(GITEMDESC.Index, i).Value = Nothing Then tempval(37) = "''" Else tempval(37) = "'" & griddetails.Item(GITEMDESC.Index, i).Value & "'"
                If griddetails.Item(GLESSWT.Index, i).Value = Nothing Then tempval(38) = "0" Else tempval(38) = Val(griddetails.Item(GLESSWT.Index, i).Value)
                If griddetails.Item(GDIFFWT.Index, i).Value = Nothing Then tempval(39) = "0" Else tempval(39) = Val(griddetails.Item(GDIFFWT.Index, i).Value)
                tempval(40) = Val(USERID)
                tempval(41) = Val(USERDEPARTMENTID)
                tempval(42) = Val(griddetails.Item(GSRNO.Index, i).Value)
                tempval(43) = Val(griddetails.Item(GSTONERATE.Index, i).Value)
                tempval(44) = Val(LBLTOTALLABOURAMT.Text.Trim)
                tempval(45) = Val(LBLTOTALSTONEAMT.Text.Trim)
                If griddetails.Item(GGROSSLESS.Index, i).Value = Nothing Then tempval(46) = 0 Else tempval(46) = Format(Val(griddetails.Item(GGROSSLESS.Index, i).Value), "0.000")


                insert("vouchers", tempcol, tempval)

            Next


            'ADD GRIDADD
            For i = 0 To gridadd.RowCount - 2

                tempval(0) = Val(txtbillno.Text)
                tempval(1) = "'" & Format(DTPicker.Value, "dd/MM/yyyy") & "'"

                'getting nameid
                cmd = New OleDbCommand("select ledger_id,ledger_CODE from ledgermaster where ledger_NAME = '" & gridadd.Rows(i).Cells(1).Value & "'", conn)
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
                conn.Open()
                dr = cmd.ExecuteReader()
                If dr.HasRows Then
                    dr.Read()
                    tempval(2) = Val(dr(0))
                Else
                    tempval(2) = Val(0)
                End If
                conn.Close()

                cmd = New OleDbCommand("select salesmen_id from salesmenmaster where salesmen_name =  '" & cmbsalesmen.Text.Trim & "'", conn)
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
                conn.Open()
                dr = cmd.ExecuteReader()
                If dr.HasRows Then
                    dr.Read()
                    tempval(36) = Val(dr(0))
                Else
                    tempval(36) = Val(0)
                End If
                conn.Close()


                tempval(3) = Val(0)
                tempval(4) = Val(0)
                tempval(5) = Val(0)
                tempval(6) = Val(0)
                tempval(7) = Val(0)
                tempval(8) = Val(0)
                tempval(9) = Val(0)
                tempval(10) = Val(0)
                tempval(11) = Val(0)
                tempval(12) = Val(txtbhavcut.Text)
                tempval(13) = Val(txtrate.Text)
                tempval(14) = Val(txtperwt.Text)
                tempval(15) = Val(0)
                tempval(16) = Val(txtbalwt.Text)
                tempval(17) = Val(txtamount.Text)
                tempval(18) = Val(lblamounttotal.Text)
                tempval(19) = Val(txtcashrec.Text)
                tempval(20) = Val(txtbalamt.Text)

                If FRMSTRING = "ISSUE" Then
                    tempval(21) = "'Balance'"
                Else
                    tempval(21) = "'Jama'"
                End If

                tempval(22) = Val(lblgrosswttotal.Text)
                tempval(23) = Val(LBLTOTALFINEWT.Text)

                tempval(24) = "'" & txtnarration.Text & "'"

                If FRMSTRING = "ISSUE" Then
                    tempval(25) = "'I'"
                ElseIf FRMSTRING = "RECEIPT" Then
                    tempval(25) = "'R'"
                End If
                tempval(26) = Val(txtaddtotal.Text)
                tempval(27) = Val(txtlesstotal.Text)
                tempval(28) = "'" & txtinwords.Text & "'"
                tempval(29) = Val(txtcrdays.Text)


                'getting ledgerid
                cmd = New OleDbCommand("select ledger_id from ledgermaster where ledger_name =  '" & gridadd.Item(0, i).Value.ToString & "'", conn)
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
                conn.Open()
                dr = cmd.ExecuteReader()
                If dr.HasRows Then
                    dr.Read()
                    tempval(30) = Val(dr(0))
                Else
                    tempval(30) = Val(0)
                End If
                conn.Close()

                tempval(31) = "'" & gridadd.Rows(i).Cells(1).Value & "'"
                tempval(32) = "'" & gridadd.Item(2, i).Value.ToString & "'"
                tempval(33) = Val(0)
                tempval(34) = "''"
                tempval(35) = Val(0)
                tempval(37) = "''"
                tempval(38) = "'0'"
                tempval(39) = "'0'"
                tempval(40) = Val(USERID)
                tempval(41) = Val(USERDEPARTMENTID)
                tempval(42) = Val(gridadd.Rows(i).Cells(0).Value)
                tempval(43) = Val(0)
                tempval(44) = Val(LBLTOTALLABOURAMT.Text.Trim)
                tempval(45) = Val(LBLTOTALSTONEAMT.Text.Trim)
                tempval(46) = Val(0)    'GROSSLESS

                insert("vouchers", tempcol, tempval)

            Next


            'ADD GRIDLESS
            For i = 0 To gridless.RowCount - 2

                tempval(0) = Val(txtbillno.Text)
                tempval(1) = "'" & Format(DTPicker.Value, "dd/MM/yyyy") & "'"

                'getting nameid
                cmd = New OleDbCommand("select ledger_id,ledger_name from ledgermaster where ledger_code = '" & cmbname.Text.Trim & "'", conn)
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
                conn.Open()
                dr = cmd.ExecuteReader()
                If dr.HasRows Then
                    dr.Read()
                    tempval(2) = Val(dr(0))

                Else
                    tempval(2) = Val(0)
                End If
                conn.Close()

                cmd = New OleDbCommand("select salesmen_id from salesmenmaster where salesmen_name =  '" & cmbsalesmen.Text.Trim & "'", conn)
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
                conn.Open()
                dr = cmd.ExecuteReader()
                If dr.HasRows Then
                    dr.Read()
                    tempval(36) = Val(dr(0))
                Else
                    tempval(36) = Val(0)
                End If
                conn.Close()

                tempval(3) = Val(0)
                tempval(4) = Val(0)
                tempval(5) = Val(0)
                tempval(6) = Val(0)
                tempval(7) = Val(0)
                tempval(8) = Val(0)
                tempval(9) = Val(0)
                tempval(10) = Val(0)
                tempval(11) = Val(0)
                tempval(12) = Val(txtbhavcut.Text)
                tempval(13) = Val(txtrate.Text)
                tempval(14) = Val(txtperwt.Text)
                tempval(15) = Val(0)
                tempval(16) = Val(txtbalwt.Text)
                tempval(17) = Val(txtamount.Text)
                tempval(18) = Val(lblamounttotal.Text)
                tempval(19) = Val(txtcashrec.Text)
                tempval(20) = Val(txtbalamt.Text)

                If FRMSTRING = "ISSUE" Then
                    tempval(21) = "'Balance'"
                Else
                    tempval(21) = "'Jama'"
                End If

                tempval(22) = Val(lblgrosswttotal.Text)
                tempval(23) = Val(LBLTOTALFINEWT.Text)

                tempval(24) = "'" & txtnarration.Text & "'"

                If FRMSTRING = "ISSUE" Then
                    tempval(25) = "'I'"
                ElseIf FRMSTRING = "RECEIPT" Then
                    tempval(25) = "'R'"
                End If
                tempval(26) = Val(txtaddtotal.Text)
                tempval(27) = Val(txtlesstotal.Text)
                tempval(28) = "'" & txtinwords.Text & "'"
                tempval(29) = Val(txtcrdays.Text)


                tempval(30) = Val(0)
                tempval(31) = "''"
                tempval(32) = Val(0)

                'getting ledgerid
                cmd = New OleDbCommand("select ledger_id from ledgermaster where ledger_name =  '" & gridless.Item(0, i).Value.ToString & "'", conn)
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
                conn.Open()
                dr = cmd.ExecuteReader()
                If dr.HasRows Then
                    dr.Read()
                    tempval(33) = Val(dr(0))
                Else
                    tempval(33) = Val(0)
                End If
                conn.Close()

                tempval(34) = "'" & gridless.Item(1, i).EditedFormattedValue.ToString & "'"
                tempval(35) = Val(gridless.Item(2, i).EditedFormattedValue)
                tempval(37) = "''"
                tempval(38) = "'0'"
                tempval(39) = "'0'"
                tempval(40) = Val(USERID)
                tempval(41) = Val(USERDEPARTMENTID)
                tempval(42) = Val(gridless.Rows(i).Cells(0).Value)
                tempval(43) = Val(0)
                tempval(44) = Val(LBLTOTALLABOURAMT.Text.Trim)
                tempval(45) = Val(LBLTOTALSTONEAMT.Text.Trim)
                tempval(46) = Val(0)    'GROSSLESS

                insert("vouchers", tempcol, tempval)

            Next



            'clearing array
            For i = 1 To 100
                tempcol(i) = ""
                tempval(i) = ""
            Next


            'adding data in accountmasrer
            If EDIT = True Then

                cmd = New OleDbCommand("delete from accountmaster where account_voucherid = " & txtbillno.Text & " and account_type ='" & types & "'", conn)
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If

                conn.Open()
                cmd.ExecuteNonQuery()
                conn.Close()

            End If

            tempcol(0) = "account_date"
            tempcol(1) = "account_ledgerid"
            tempcol(2) = "account_grosswt"
            tempcol(3) = "account_nettwt"
            tempcol(4) = "account_amount"
            tempcol(5) = "account_narration"
            tempcol(6) = "account_balorjamaorpaid"
            tempcol(7) = "account_voucherid"
            tempcol(8) = "account_type"
            tempcol(9) = "account_ledgercode"
            tempcol(10) = "account_USERID"
            tempcol(11) = "account_DEPARTMENTID"
            tempcol(12) = "account_PROCESS"
            tempcol(13) = "account_GROSSLESS"
            tempcol(14) = "ACCOUNT_PIECES"
            tempcol(15) = "ACCOUNT_LESSWT"


            'ACCOUNTS POSTING (NORMAL)
            If (Val(Val(LBLTOTALFINEWT.Text) - Val(txtbhavcut.Text)) <> 0 Or ClientName = "KHUSHALI") And Val(txtamount.Text) = "0" Then

                tempval(0) = "'" & Format(DTPicker.Value, "dd/MM/yyyy") & "'"
                tempval(1) = tempnameid
                tempval(2) = Format(Val(lblgrosswttotal.Text), "0.000")
                tempval(3) = Format(Val(LBLTOTALFINEWT.Text), "0.000")
                tempval(4) = 0
                tempval(5) = "'" & txtnarration.Text & "'"

                If FRMSTRING = "ISSUE" Then
                    tempval(6) = "'Balance'"
                ElseIf FRMSTRING = "RECEIPT" Then
                    tempval(6) = "'Jama'"
                End If

                tempval(7) = txtbillno.Text
                tempval(8) = "'" & types & "'"
                tempval(9) = "'" & tempname & "'"
                tempval(10) = Val(USERID)
                tempval(11) = Val(USERDEPARTMENTID)
                tempval(12) = "''"  'PROCESSNAME
                tempval(13) = Format(Val(LBLTOTALNETTWT.Text), "0.000") 'GROSSLESS
                tempval(14) = Val(lblpiecestotal.Text)
                tempval(15) = Format(Val(LBLTOTALLESSWT.Text), "0.000") 'GROSSLESS

                insert("accountmaster", tempcol, tempval)

            End If


            'IF LBLAMOUNTTOTAL > 0 (GRIDAMOUNT) THEN
            'WE NEED TO ADD POSTING IN LABOUR LEDGER
            'IF POSTING IS FOR ISSUE
            '   LABOUR JAMA FOR AMOUNT
            '   PARTY NAAME FOR AMOUNT
            'ELSE POSTING FOR ISSUE
            '   LABOUR NAAME FOR AMOUNT
            '   PARTY JAMA FOR AMOUNT


            'LABOUR POSTING (ADD ONLY LABOUR AMT)
            If Val(LBLTOTALLABOURAMT.Text) > 0 Then

                'LABOUR POSTING
                tempval(0) = "'" & Format(DTPicker.Value, "dd/MM/yyyy") & "'"
                If FRMSTRING = "ISSUE" Then
                    cmd = New OleDbCommand("select ledger_id from ledgermaster where ledger_name =  'Labour Charges Received'", conn)
                Else
                    cmd = New OleDbCommand("select ledger_id from ledgermaster where ledger_name =  'Labour Charges Paid'", conn)
                End If
                If conn.State = ConnectionState.Open Then conn.Close()
                conn.Open()
                dr = cmd.ExecuteReader()
                If dr.HasRows Then
                    dr.Read()
                    tempval(1) = Val(dr(0))
                Else
                    tempval(1) = Val(0)
                End If

                tempval(2) = 0
                tempval(3) = 0
                tempval(4) = Format(Val(LBLTOTALLABOURAMT.Text), "0.00")
                tempval(5) = "'" & txtnarration.Text & "'"

                If FRMSTRING = "ISSUE" Then
                    tempval(6) = "'Jama'"
                ElseIf FRMSTRING = "RECEIPT" Then
                    tempval(6) = "'Balance'"
                End If

                tempval(7) = txtbillno.Text
                tempval(8) = "'" & types & "'"
                If FRMSTRING = "ISSUE" Then
                    tempval(9) = "'Labour Charges Received'"
                Else
                    tempval(9) = "'Labour Charges Paid'"
                End If
                tempval(10) = Val(USERID)
                tempval(11) = Val(USERDEPARTMENTID)
                tempval(12) = "''"  'PROCESSNAME
                tempval(13) = 0     'GROSSLESS 
                tempval(14) = Val(lblpiecestotal.Text)
                tempval(15) = 0     'LESSWT


                insert("accountmaster", tempcol, tempval)


                'PARTY POSTING
                tempval(1) = tempnameid
                If FRMSTRING = "ISSUE" Then
                    tempval(6) = "'Balance'"
                ElseIf FRMSTRING = "RECEIPT" Then
                    tempval(6) = "'Jama'"
                End If
                tempval(9) = "'" & tempname & "'"
                tempval(10) = Val(USERID)
                tempval(11) = Val(USERDEPARTMENTID)
                tempval(12) = "''"  'PROCESSNAME
                tempval(13) = 0     'GROSSLESS 
                tempval(14) = Val(lblpiecestotal.Text)
                tempval(15) = 0     'LESSWT

                insert("accountmaster", tempcol, tempval)

            End If




            'STONE AMT POSTING (ADD ONLY STONE AMT)
            If Val(LBLTOTALSTONEAMT.Text) > 0 Then

                'STONE POSTING
                tempval(0) = "'" & Format(DTPicker.Value, "dd/MM/yyyy") & "'"
                cmd = New OleDbCommand("select ledger_id from ledgermaster where ledger_name = 'STONE'", conn)
                If conn.State = ConnectionState.Open Then conn.Close()
                conn.Open()
                dr = cmd.ExecuteReader()
                If dr.HasRows Then
                    dr.Read()
                    tempval(1) = Val(dr(0))
                Else
                    tempval(1) = Val(0)
                End If

                tempval(2) = 0
                tempval(3) = 0
                tempval(4) = Format(Val(LBLTOTALSTONEAMT.Text), "0.00")
                tempval(5) = "'" & txtnarration.Text & "'"

                If FRMSTRING = "ISSUE" Then
                    tempval(6) = "'Jama'"
                ElseIf FRMSTRING = "RECEIPT" Then
                    tempval(6) = "'Balance'"
                End If

                tempval(7) = txtbillno.Text
                tempval(8) = "'" & types & "'"
                tempval(9) = "'STONE'"
                tempval(10) = Val(USERID)
                tempval(11) = Val(USERDEPARTMENTID)
                tempval(12) = "''"  'PROCESSNAME
                tempval(13) = 0     'GROSSLESS 
                tempval(14) = Val(lblpiecestotal.Text)
                tempval(15) = 0     'LESSWT


                insert("accountmaster", tempcol, tempval)


                'PARTY POSTING
                tempval(1) = tempnameid
                If FRMSTRING = "ISSUE" Then
                    tempval(6) = "'Balance'"
                ElseIf FRMSTRING = "RECEIPT" Then
                    tempval(6) = "'Jama'"
                End If
                tempval(9) = "'" & tempname & "'"
                tempval(10) = Val(USERID)
                tempval(11) = Val(USERDEPARTMENTID)
                tempval(12) = "''"  'PROCESSNAME
                tempval(13) = 0     'GROSSLESS 
                tempval(14) = Val(lblpiecestotal.Text)
                tempval(15) = 0     'LESSWT

                insert("accountmaster", tempcol, tempval)

            End If





            'IF LESSTOTAL > 0  THEN
            'WE NEED TO ADD POSTING IN GRID LEDGER
            'IF POSTING IS FOR ISSUE
            '   GRID LEDGER NAAME FOR AMOUNT
            '   PARTY NAAME FOR AMOUNT*(-1)
            'ELSE POSTING FOR ISSUE
            '   GRID LEDGER JAMA FOR AMOUNT
            '   PARTY JAMA FOR AMOUNT*(-1)
            'LABOUR POSTING
            If Val(txtlesstotal.Text) > 0 Then
                For Each ROW As DataGridViewRow In gridless.Rows

                    If ROW.Cells(lessamt.Index).Value <> Nothing Then
                        'POSTING
                        tempval(0) = "'" & Format(DTPicker.Value, "dd/MM/yyyy") & "'"

                        cmd = New OleDbCommand("select ledger_id, LEDGER_CODE from ledgermaster where ledger_name =  '" & ROW.Cells(cmb_less.Index).Value & "'", conn)
                        If conn.State = ConnectionState.Open Then conn.Close()
                        conn.Open()
                        dr = cmd.ExecuteReader()
                        If dr.HasRows Then
                            dr.Read()
                            tempval(1) = Val(dr(0))
                            tempval(9) = "'" & dr(1) & "'"
                        Else
                            tempval(1) = Val(0)
                            tempval(9) = "''"
                        End If

                        tempval(2) = 0
                        tempval(3) = 0
                        tempval(4) = Format(Val(ROW.Cells(lessamt.Index).Value), "0.00")
                        tempval(5) = "'" & txtnarration.Text & "'"

                        If FRMSTRING = "ISSUE" Then
                            tempval(6) = "'Balance'"
                        ElseIf FRMSTRING = "RECEIPT" Then
                            tempval(6) = "'Jama'"
                        End If

                        tempval(7) = txtbillno.Text
                        tempval(8) = "'" & types & "'"
                        tempval(10) = Val(USERID)
                        tempval(11) = Val(USERDEPARTMENTID)
                        tempval(12) = "''"  'PROCESSNAME
                        tempval(13) = 0     'GROSSLESS 
                        tempval(14) = 0
                        tempval(15) = 0     'LESSWT

                        insert("accountmaster", tempcol, tempval)


                        'PARTY POSTING
                        tempval(1) = tempnameid
                        tempval(4) = Format(Val(ROW.Cells(lessamt.Index).Value) * (-1), "0.00")
                        If FRMSTRING = "ISSUE" Then
                            tempval(6) = "'Balance'"
                        ElseIf FRMSTRING = "RECEIPT" Then
                            tempval(6) = "'Jama'"
                        End If
                        tempval(9) = "'" & tempname & "'"
                        tempval(10) = Val(USERID)
                        tempval(11) = Val(USERDEPARTMENTID)
                        tempval(12) = "''"  'PROCESSNAME
                        tempval(13) = 0     'GROSSLESS 
                        tempval(14) = 0
                        tempval(15) = 0     'LESSWT

                        insert("accountmaster", tempcol, tempval)
                    End If
                Next

            End If




            'IF ADDTOTAL > 0  THEN
            'WE NEED TO ADD POSTING IN GRID LEDGER
            'IF POSTING IS FOR ISSUE
            '   GRID LEDGER JAMA FOR AMOUNT
            '   PARTY NAAME FOR AMOUNT
            'ELSE POSTING FOR ISSUE
            '   GRID LEDGER NAAME FOR AMOUNT
            '   PARTY JAMA FOR AMOUNT
            'LABOUR POSTING
            If Val(txtaddtotal.Text) > 0 Then
                For Each ROW As DataGridViewRow In gridadd.Rows

                    If ROW.Cells(GADDAMT.Index).Value <> Nothing Then
                        'POSTING
                        tempval(0) = "'" & Format(DTPicker.Value, "dd/MM/yyyy") & "'"

                        cmd = New OleDbCommand("select ledger_id, LEDGER_CODE from ledgermaster where ledger_name =  '" & ROW.Cells(cmb_add.Index).Value & "'", conn)
                        If conn.State = ConnectionState.Open Then conn.Close()
                        conn.Open()
                        dr = cmd.ExecuteReader()
                        If dr.HasRows Then
                            dr.Read()
                            tempval(1) = Val(dr(0))
                            tempval(9) = "'" & dr(1) & "'"
                        Else
                            tempval(1) = Val(0)
                            tempval(9) = "''"
                        End If

                        tempval(2) = 0
                        tempval(3) = 0
                        tempval(4) = Format(Val(ROW.Cells(GADDAMT.Index).Value), "0.00")
                        tempval(5) = "'" & txtnarration.Text & "'"

                        If FRMSTRING = "ISSUE" Then
                            tempval(6) = "'Jama'"
                        ElseIf FRMSTRING = "RECEIPT" Then
                            tempval(6) = "'Balance'"
                        End If

                        tempval(7) = txtbillno.Text
                        tempval(8) = "'" & types & "'"
                        tempval(10) = Val(USERID)
                        tempval(11) = Val(USERDEPARTMENTID)
                        tempval(12) = "''"  'PROCESSNAME
                        tempval(13) = 0     'GROSSLESS 
                        tempval(14) = 0     'PCS
                        tempval(15) = 0     'LESSWT

                        insert("accountmaster", tempcol, tempval)


                        'PARTY POSTING
                        tempval(1) = tempnameid
                        tempval(4) = Format(Val(ROW.Cells(GADDAMT.Index).Value), "0.00")
                        If FRMSTRING = "ISSUE" Then
                            tempval(6) = "'Balance'"
                        ElseIf FRMSTRING = "RECEIPT" Then
                            tempval(6) = "'Jama'"
                        End If
                        tempval(9) = "'" & tempname & "'"
                        tempval(10) = Val(USERID)
                        tempval(11) = Val(USERDEPARTMENTID)
                        tempval(12) = "''"  'PROCESSNAME
                        tempval(13) = 0     'GROSSLESS 
                        tempval(14) = 0     'PCS
                        tempval(15) = 0     'LESSWT

                        insert("accountmaster", tempcol, tempval)
                    End If
                Next

            End If




            'IF BHAVCUTWT > 0 THEN
            'WE NEED TO ADD POSTING IN LEDGER 
            'IF POSTING IS FOR ISSUE
            '   PARTY JAMA FOR BHAVCUTWT
            '   PARTY NAAME FOR TOTALGROSSWT
            'ELSE POSTING FOR ISSUE
            '   PARTY NAAME FOR BHAVCUTWT
            '   PARTY JAMA FOR TOTALGROSSWT
            'LABOUR POSTING
            If Val(txtbhavcut.Text.Trim) > 0 Then

                'PARTY JAMA POSTING
                tempval(0) = "'" & Format(DTPicker.Value, "dd/MM/yyyy") & "'"
                tempval(1) = tempnameid

                If FRMSTRING = "ISSUE" Then
                    tempval(2) = Format(Val(txtbhavcut.Text.Trim), "0.000")
                    tempval(3) = Format(Val(txtbhavcut.Text.Trim), "0.000")
                    tempval(6) = "'Jama'"
                ElseIf FRMSTRING = "RECEIPT" Then
                    tempval(2) = Format(Val(lblgrosswttotal.Text.Trim), "0.000")
                    tempval(3) = Format(Val(LBLTOTALFINEWT.Text.Trim), "0.000")
                    tempval(6) = "'Balance'"
                End If

                tempval(4) = 0
                tempval(5) = "'" & txtnarration.Text & "'"

                tempval(7) = txtbillno.Text
                tempval(8) = "'" & types & "'"
                tempval(9) = "'" & tempname & "'"
                tempval(10) = Val(USERID)
                tempval(11) = Val(USERDEPARTMENTID)
                tempval(12) = "''"  'PROCESSNAME
                tempval(13) = 0     'GROSSLESS 
                tempval(14) = Val(lblpiecestotal.Text.Trim)
                tempval(15) = 0     'LESSWT

                insert("accountmaster", tempcol, tempval)


                'PARTY NAAME POSTING
                If FRMSTRING = "ISSUE" Then
                    tempval(2) = Format(Val(lblgrosswttotal.Text.Trim), "0.000")
                    tempval(3) = Format(Val(LBLTOTALFINEWT.Text.Trim), "0.000")
                    tempval(6) = "'Balance'"
                ElseIf FRMSTRING = "RECEIPT" Then
                    tempval(2) = Format(Val(txtbhavcut.Text.Trim), "0.000")
                    tempval(3) = Format(Val(txtbhavcut.Text.Trim), "0.000")
                    tempval(6) = "'Jama'"
                End If
                tempval(10) = Val(USERID)
                tempval(11) = Val(USERDEPARTMENTID)
                tempval(12) = "''"  'PROCESSNAME
                tempval(13) = 0     'GROSSLESS 
                tempval(14) = Val(lblpiecestotal.Text.Trim)
                tempval(15) = 0     'LESSWT

                insert("accountmaster", tempcol, tempval)

            End If





            'IF RATE IS PRESENT THIS MEANS BHAVCUT IS DONE
            'THIS IS FOR BHAVCUT POSTING
            'THERE ARE 3 POSTINGS HERE

            'THIS POSTING IS FOR ISSUE
            '   SALE JAMA FOR AMOUNT
            '   SALE NAAME FOR GOLD
            '   PARTY NAAME FOR AMOUNT
            'ELSE POSTING FOR JAMA
            '   PURCHASE JAMA FOR GOLD
            '   PURCHASE NAAME FOR AMOUNT
            '   PARTY JAMA FOR AMOUNT
            If Val(txtrate.Text.Trim) > 0 Then

                'POSTINGS FOR ISSUE 
                If types = "I" Then

                    '1ST POSTING
                    'SALE JAMA FOR AMOUNT
                    tempval(0) = "'" & Format(DTPicker.Value, "dd/MM/yyyy") & "'"

                    cmd = New OleDbCommand("select ledger_id from ledgermaster where ledger_name =  'SALE'", conn)
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Open()
                    dr = cmd.ExecuteReader()
                    If dr.HasRows Then
                        dr.Read()
                        tempval(1) = Val(dr(0))
                    Else
                        tempval(1) = Val(0)
                    End If
                    conn.Close()
                    tempval(2) = 0
                    tempval(3) = 0
                    tempval(4) = Format(Val(txtamount.Text.Trim), "0.00")
                    tempval(5) = "'" & txtnarration.Text & "'"
                    tempval(6) = "'Jama'"
                    tempval(7) = txtbillno.Text
                    tempval(8) = "'" & types & "'"
                    tempval(9) = "'SALE'"
                    tempval(10) = Val(USERID)
                    tempval(11) = Val(USERDEPARTMENTID)
                    tempval(12) = "''"  'PROCESSNAME
                    tempval(13) = 0     'GROSSLESS 
                    tempval(14) = 0     'PCS
                    tempval(15) = 0     'LESS WT

                    insert("accountmaster", tempcol, tempval)


                    '2ND POSTING
                    'SALE NAAME FOR GOLD
                    If Val(txtbhavcut.Text.Trim) = 0 Then tempval(2) = Val(lblgrosswttotal.Text.Trim) Else tempval(2) = Val(txtbhavcut.Text.Trim)
                    If Val(txtbhavcut.Text.Trim) = 0 Then tempval(3) = Val(LBLTOTALFINEWT.Text.Trim) Else tempval(3) = Val(txtbhavcut.Text.Trim)
                    tempval(4) = 0
                    tempval(6) = "'Balance'"
                    tempval(10) = Val(USERID)
                    tempval(11) = Val(USERDEPARTMENTID)
                    tempval(12) = "''"  'PROCESSNAME
                    tempval(13) = 0     'GROSSLESS 
                    tempval(14) = 0     'PCS
                    tempval(15) = 0     'LESSWT

                    insert("accountmaster", tempcol, tempval)


                    '3RD POSTING
                    'PARTY NAAME FOR AMOUNT
                    tempval(1) = tempnameid
                    tempval(2) = 0
                    tempval(3) = 0
                    tempval(4) = Format(Val(txtamount.Text.Trim), "0.00")
                    tempval(5) = "'" & txtnarration.Text & "'"
                    tempval(6) = "'Balance'"
                    tempval(7) = txtbillno.Text
                    tempval(8) = "'" & types & "'"
                    tempval(9) = "'" & tempname & "'"
                    tempval(10) = Val(USERID)
                    tempval(11) = Val(USERDEPARTMENTID)
                    tempval(12) = "''"  'PROCESSNAME
                    tempval(13) = 0     'GROSSLESS 
                    tempval(14) = 0     'PCS
                    tempval(15) = 0     'LESSWT

                    insert("accountmaster", tempcol, tempval)

                Else
                    'ENTRIES FOR RECEIPT
                    '1ST POSTING
                    'PURCHASE JAMA FOR GOLD
                    tempval(0) = "'" & Format(DTPicker.Value, "dd/MM/yyyy") & "'"

                    cmd = New OleDbCommand("select ledger_id from ledgermaster where ledger_name =  'PURCHASE'", conn)
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Open()
                    dr = cmd.ExecuteReader()
                    If dr.HasRows Then
                        dr.Read()
                        tempval(1) = Val(dr(0))
                    Else
                        tempval(1) = Val(0)
                    End If
                    conn.Close()
                    If Val(txtbhavcut.Text.Trim) = 0 Then tempval(2) = Val(lblgrosswttotal.Text.Trim) Else tempval(2) = Val(txtbhavcut.Text.Trim)
                    If Val(txtbhavcut.Text.Trim) = 0 Then tempval(3) = Val(LBLTOTALFINEWT.Text.Trim) Else tempval(3) = Val(txtbhavcut.Text.Trim)
                    tempval(4) = 0
                    tempval(5) = "'" & txtnarration.Text & "'"
                    tempval(6) = "'Jama'"
                    tempval(7) = txtbillno.Text
                    tempval(8) = "'" & types & "'"
                    tempval(9) = "'PURCHASE'"
                    tempval(10) = Val(USERID)
                    tempval(11) = Val(USERDEPARTMENTID)
                    tempval(12) = "''"  'PROCESSNAME
                    tempval(13) = 0     'GROSSLESS 
                    tempval(14) = 0     'PCS
                    tempval(15) = 0     'LESSWT

                    insert("accountmaster", tempcol, tempval)


                    '2ND POSTING
                    'PURCHASE NAAME FOR AMOUNT
                    tempval(2) = 0
                    tempval(3) = 0
                    tempval(4) = Format(Val(txtamount.Text.Trim), "0.00")
                    tempval(6) = "'Balance'"
                    tempval(10) = Val(USERID)
                    tempval(11) = Val(USERDEPARTMENTID)
                    tempval(12) = "''"  'PROCESSNAME
                    tempval(13) = 0     'GROSSLESS 
                    tempval(14) = 0     'PCS
                    tempval(15) = 0     'LESSWT

                    insert("accountmaster", tempcol, tempval)


                    '3RD POSTING
                    'PARTY JAMA FOR AMOUNT
                    tempval(1) = tempnameid
                    tempval(2) = 0
                    tempval(3) = 0
                    tempval(4) = Format(Val(txtamount.Text.Trim), "0.00")
                    tempval(5) = "'" & txtnarration.Text & "'"
                    tempval(6) = "'Jama'"
                    tempval(7) = txtbillno.Text
                    tempval(8) = "'" & types & "'"
                    tempval(9) = "'" & tempname & "'"
                    tempval(10) = Val(USERID)
                    tempval(11) = Val(USERDEPARTMENTID)
                    tempval(12) = "''"  'PROCESSNAME
                    tempval(13) = 0     'GROSSLESS 
                    tempval(14) = 0     'PCS
                    tempval(15) = 0     'LESSWT

                    insert("accountmaster", tempcol, tempval)
                End If
            End If



            'IF CASHAMOUNT > 0 THEN
            'WE NEED TO ADD POSTING IN LEDGER 
            'IF POSTING IS FOR ISSUE
            '   PARTY JAMA FOR CASH
            '   CASHPARTY NAAME FOR CASH
            'ELSE POSTING FOR ISSUE
            '   PARTY NAAME FOR CASH
            '   CASHPARTY JAMA FOR CASH
            'LABOUR POSTING
            If Val(txtcashrec.Text.Trim) > 0 Then

                'PARTY JAMA POSTING
                tempval(0) = "'" & Format(DTPicker.Value, "dd/MM/yyyy") & "'"
                tempval(1) = tempnameid
                tempval(2) = 0
                tempval(3) = 0
                tempval(4) = Format(Val(txtcashrec.Text.Trim), "0.00")
                tempval(5) = "'" & txtnarration.Text & "'"

                If FRMSTRING = "ISSUE" Then
                    tempval(6) = "'Jama'"
                ElseIf FRMSTRING = "RECEIPT" Then
                    tempval(6) = "'Balance'"
                End If

                tempval(7) = txtbillno.Text
                tempval(8) = "'" & types & "'"
                tempval(9) = "'" & tempname & "'"
                tempval(10) = Val(USERID)
                tempval(11) = Val(USERDEPARTMENTID)
                tempval(12) = "''"  'PROCESSNAME
                tempval(13) = 0     'GROSSLESS 
                tempval(14) = 0     'PCS
                tempval(15) = 0     'LESSWT

                insert("accountmaster", tempcol, tempval)


                'CASHPARTY NAAME POSTING
                cmd = New OleDbCommand("select ledger_id from ledgermaster where ledger_name =  'CASH'", conn)
                If conn.State = ConnectionState.Open Then conn.Close()
                conn.Open()
                dr = cmd.ExecuteReader()
                If dr.HasRows Then
                    dr.Read()
                    tempval(1) = Val(dr(0))
                Else
                    tempval(1) = Val(0)
                End If
                conn.Close()
                If FRMSTRING = "ISSUE" Then
                    tempval(6) = "'Balance'"
                ElseIf FRMSTRING = "RECEIPT" Then
                    tempval(6) = "'Jama'"
                End If
                tempval(9) = "'CASH'"
                tempval(10) = Val(USERID)
                tempval(11) = Val(USERDEPARTMENTID)
                tempval(12) = "''"  'PROCESSNAME
                tempval(13) = 0     'GROSSLESS 
                tempval(14) = 0     'PCS
                tempval(15) = 0     'LESSWT

                insert("accountmaster", tempcol, tempval)

            End If


            If EDIT = False Then
                MessageBox.Show("Details Added")
                If ClientName = "SHASHAWAT" Or ClientName = "SANGAM" Or ClientName = "KHUSHALI" Or ClientName = "ADITYA" Then PRINTREPORT()
                Call vouchers_Shown(sender, e)
                cmbname.Focus()
            Else

                'If frmdailykhata = True Then
                '    MessageBox.Show("Details Updated")
                '    Me.Close()
                '    If (chlddailykhata.IsMdiChild = False) Then
                '        If chlddailykhata.IsDisposed = True Then
                '            chlddailykhata = New dailykhata
                '        End If
                '        chlddailykhata.MdiParent = MDIMain
                '        chlddailykhata.Show()
                '    Else
                '        chlddailykhata.BringToFront()
                '    End If
                'Else

                '    'voucherdetails
                '    Me.Close()
                '    If (chldvoucherdetails.IsMdiChild = False) Then
                '        If chldvoucherdetails.IsDisposed = True Then
                '            chldvoucherdetails = New Voucherdetails
                '        End If
                '        chldvoucherdetails.MdiParent = MDIMain
                '        chldvoucherdetails.Show()
                '    Else
                '        chldvoucherdetails.BringToFront()
                '    End If

                'End If

                MessageBox.Show("Details Updated")
                If ClientName = "SHASHAWAT" Or ClientName = "SANGAM" Or ClientName = "KHUSHALI" Or ClientName = "ADITYA" Then PRINTREPORT()
                EDIT = False
                clear()
                cmbname.Focus()
            End If

        Else
            MsgBox("Enter Valid Details")
            cmbname.Focus()
        End If

    End Sub

    Sub fillitem()

        cmd = New OleDbCommand("select item_code from itemmaster ORDER BY ITEM_CODE", conn)
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If
        conn.Open()
        dr = cmd.ExecuteReader
        If dr.HasRows = True Then
            cmbitemcode.Items.Clear()
            While dr.Read
                cmbitemcode.Items.Add(dr(0).ToString)
            End While
        End If
        dr.Close()
        cmd.Dispose()
        conn.Close()
    End Sub

    Private Sub griddetails_CellValidated(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles griddetails.CellValidated


        'If e.ColumnIndex = CMBITEMCODE.INDEX Or e.ColumnIndex = GGROSSWT.INDEX or Then
        If griddetails.Item(cmbitemcode.Index, e.RowIndex).ToString <> "" Then

            If e.ColumnIndex = cmbitemcode.Index Then fillitem()
            griddetails.Item(GGROSSLESS.Index, e.RowIndex).Value = Format(Val(griddetails.Item(GGROSSWT.Index, e.RowIndex).Value) - Val(griddetails.Item(GLESSWT.Index, e.RowIndex).Value), "0.000")
            If griddetails.Item(GBULLION.Index, e.RowIndex).Value <> 0 Then

                'DEDUCT LESSWT AND CALC FINE
                If ClientName = "KHUSHALI" Or ClientName = "ADITYA" Or ClientName = "SHWETA" Then
                    griddetails.Item(GFINEWT.Index, e.RowIndex).Value = Format(Val(griddetails.Item(GGROSSLESS.Index, e.RowIndex).EditedFormattedValue) * (Val(griddetails.Item(GBULLION.Index, e.RowIndex).EditedFormattedValue) + Val(griddetails.Item(GWASTAGE.Index, e.RowIndex).EditedFormattedValue)) / 100, "0.000")
                Else
                    griddetails.Item(GFINEWT.Index, e.RowIndex).Value = Format(Val(griddetails.Item(GGROSSWT.Index, e.RowIndex).Value) * (Val(griddetails.Item(GBULLION.Index, e.RowIndex).Value) + Val(griddetails.Item(GWASTAGE.Index, e.RowIndex).Value)) / 100, "0.000")
                End If
            Else
                'DEDUCT LESSWT AND CALC NETT
                If ClientName = "KHUSHALI" Or ClientName = "ADITYA" Or ClientName = "SHWETA" Then
                    griddetails.Item(GFINEWT.Index, e.RowIndex).Value = Format(Val(griddetails.Item(GGROSSLESS.Index, e.RowIndex).EditedFormattedValue) * (Val(griddetails.Item(GPURITY.Index, e.RowIndex).EditedFormattedValue) + Val(griddetails.Item(GWASTAGE.Index, e.RowIndex).EditedFormattedValue)) / 100, "0.000")
                Else
                    griddetails.Item(GFINEWT.Index, e.RowIndex).Value = Format(Val(griddetails.Item(GGROSSWT.Index, e.RowIndex).Value) * (Val(griddetails.Item(GPURITY.Index, e.RowIndex).Value) + Val(griddetails.Item(GWASTAGE.Index, e.RowIndex).Value)) / 100, "0.000")
                End If
                'griddetails.CurrentCell.Value = Convert.ToDecimal(griddetails.CurrentCell.Value)
            End If

            If griddetails.Item(GPCS.Index, e.RowIndex).Value <> 0 And Val(griddetails.Item(GLABOUR.Index, e.RowIndex).Value) <> 0 Then

                'THIS IS DONE COZ WE NEED TO MANUALLY CHANGE THE AMOUNT
                If Val(griddetails.Item(GAMT.Index, e.RowIndex).EditedFormattedValue) = 0 Then griddetails.Item(GAMT.Index, e.RowIndex).Value = Format(Val(griddetails.Item(GPCS.Index, e.RowIndex).Value) * Val(griddetails.Item(GLABOUR.Index, e.RowIndex).Value), "0.00")
            ElseIf Val(griddetails.Item(GLABOUR.Index, e.RowIndex).Value) <> 0 Then

                'THIS IS DONE COZ WE NEED TO MANUALLY CHANGE THE AMOUNT
                'THIS CODE IS REMOVED AS PER SANDEEP BHAI AS ON 12-11-20
                'If Val(griddetails.Item(GAMT.Index, e.RowIndex).EditedFormattedValue) = 0 Then griddetails.Item(GAMT.Index, e.RowIndex).Value = Format(Val(griddetails.Item(GGROSSWT.Index, e.RowIndex).Value) * Val(griddetails.Item(GLABOUR.Index, e.RowIndex).Value), "0.00")
                griddetails.Item(GAMT.Index, e.RowIndex).Value = Format(Val(griddetails.Item(GGROSSWT.Index, e.RowIndex).Value) * Val(griddetails.Item(GLABOUR.Index, e.RowIndex).Value), "0")

            ElseIf Val(griddetails.Item(GSTONERATE.Index, e.RowIndex).Value) <> 0 Then

                griddetails.Item(GAMT.Index, e.RowIndex).Value = Format(Val(griddetails.Item(GGROSSWT.Index, e.RowIndex).Value) * Val(griddetails.Item(GSTONERATE.Index, e.RowIndex).Value), "0")
            End If


            If e.ColumnIndex = GITEMDESC.Index Then griddetails.Item(GITEMDESC.Index, e.RowIndex).Value = UCase(griddetails.Item(GITEMDESC.Index, e.RowIndex).Value)

            'txtnettwt.Text = ((Val(txtboolean.Text) + Val(txtwastage.Text)) * Val(txtgrosswt.Text)) / 100
            ' End If
            If e.ColumnIndex = GGROSSWT.Index Or e.ColumnIndex = GPURITY.Index Or e.ColumnIndex = GWASTAGE.Index Or e.ColumnIndex = GFINEWT.Index Or e.ColumnIndex = GLABOUR.Index Or e.ColumnIndex = GPCS.Index Then
                If griddetails.Item(cmbitemcode.Index, e.RowIndex).Value = Nothing Then

                    griddetails.Item(GGROSSWT.Index, griddetails.CurrentRow.Index).Value = Nothing
                    griddetails.Item(GPURITY.Index, griddetails.CurrentRow.Index).Value = Nothing
                    griddetails.Item(GWASTAGE.Index, griddetails.CurrentRow.Index).Value = Nothing

                    griddetails.Item(GFINEWT.Index, griddetails.CurrentRow.Index).Value = Nothing
                    griddetails.Item(GLABOUR.Index, griddetails.CurrentRow.Index).Value = Nothing
                    griddetails.Item(GSTONERATE.Index, griddetails.CurrentRow.Index).Value = Nothing
                    griddetails.Item(GPCS.Index, griddetails.CurrentRow.Index).Value = Nothing
                    griddetails.Item(GBULLION.Index, griddetails.CurrentRow.Index).Value = Nothing
                    'End If
                End If

            End If

            'DEFAULT WASTAGE
            Dim NEWDT As New DataTable
            If e.ColumnIndex = cmbitemcode.Index And cmbname.Text.Trim <> "" And griddetails.Item(cmbitemcode.Index, e.RowIndex).Value <> "" Then
                'gettig DEFAULT WASTAGE
                tempcmd = New OleDbCommand("SELECT CustomerWastage.wastage AS WASTAGE, CustomerWastage.labour AS LABOUR FROM (CustomerWastage INNER JOIN ItemMaster ON CustomerWastage.itemid = ItemMaster.item_id) INNER JOIN ledgermaster ON CustomerWastage.ledgerid = ledgermaster.ledger_id WHERE ITEM_CODE = '" & griddetails.Item(cmbitemcode.Index, e.RowIndex).EditedFormattedValue & "' AND LEDGER_CODE = '" & cmbname.Text.Trim & "'", tempconn)
                da = New OleDbDataAdapter(tempcmd)
                da.Fill(NEWDT)
                If NEWDT.Rows.Count > 0 Then
                    griddetails.Item(GWASTAGE.Index, e.RowIndex).Value = Format(Val(NEWDT.Rows(0).Item("WASTAGE")), "0.00")
                    griddetails.Item(GLABOUR.Index, e.RowIndex).Value = Format(Val(NEWDT.Rows(0).Item("LABOUR")), "0.00")
                End If
            ElseIf e.ColumnIndex = GWASTAGE.Index And cmbname.Text.Trim <> "" And griddetails.Item(cmbitemcode.Index, e.RowIndex).EditedFormattedValue <> "" Then
                tempcmd = New OleDbCommand("SELECT CustomerWastage.wastage AS WASTAGE, CustomerWastage.labour AS LABOUR FROM (CustomerWastage INNER JOIN ItemMaster ON CustomerWastage.itemid = ItemMaster.item_id) INNER JOIN ledgermaster ON CustomerWastage.ledgerid = ledgermaster.ledger_id WHERE ITEM_CODE = '" & griddetails.Item(cmbitemcode.Index, e.RowIndex).EditedFormattedValue & "' AND LEDGER_CODE = '" & cmbname.Text.Trim & "'", tempconn)
                da = New OleDbDataAdapter(tempcmd)
                da.Fill(NEWDT)
                If NEWDT.Rows.Count = 0 Then
                    'ADDING DEFAULT WASTAGE
                    If Val(griddetails.Item(GWASTAGE.Index, e.RowIndex).EditedFormattedValue) > 0 Then
                        Dim TEMPMSG As Integer = MsgBox("Add this as Default Wastage?", MsgBoxStyle.YesNo)
                        If TEMPMSG = vbNo Then Exit Sub
                        ADDWASTAGE()
                    End If
                Else
                    'UPDATE WASTAGE
                    If Val(griddetails.Item(GWASTAGE.Index, e.RowIndex).EditedFormattedValue) > 0 Then
                        UPDATEWASTAGE()
                    End If
                End If
            End If


        End If
        TOTAL()

    End Sub

    Sub ADDWASTAGE()
        Try
            '********************* ADDING VALUES IN CUSTOMERWASTAGE TABLE **********************'
            'clearing array
            For i = 1 To 100
                tempcol(i) = ""
                tempval(i) = ""
            Next


            tempcol(0) = "ledgerid"
            tempcol(1) = "itemid"
            tempcol(2) = "wastage"
            tempcol(3) = "labour"
            tempcol(4) = "cus_default"


            'getting nameid
            cmd = New OleDbCommand("select ledger_id from ledgermaster where ledger_code = '" & cmbname.Text.Trim & "'", conn)
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
            conn.Open()
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                dr.Read()
                tempval(0) = Val(dr(0))
            Else
                tempval(0) = Val(0)
            End If
            conn.Close()


            'getting itemid
            cmd = New OleDbCommand("select item_id from itemmaster where item_code =  '" & griddetails.Item(cmbitemcode.Index, griddetails.CurrentRow.Index).EditedFormattedValue & "'", conn)
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
            conn.Open()
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                dr.Read()
                tempval(1) = Val(dr(0))
            Else
                tempval(1) = Val(0)
            End If
            conn.Close()

            tempval(2) = Val(griddetails.Item(GWASTAGE.Index, griddetails.CurrentRow.Index).EditedFormattedValue)
            tempval(3) = Val(griddetails.Item(GLABOUR.Index, griddetails.CurrentRow.Index).EditedFormattedValue)
            tempval(4) = 1

            insert("CustomerWastage", tempcol, tempval)
            '********************* END OF CODE **********************'
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub UPDATEWASTAGE()
        Try

            'CHECK WHETHER THE WASTAGE IS SAME OR NOT, IF NOT THEN UPDATE
            'getting nameid
            cmd = New OleDbCommand("select wastage from CustomerWastage INNER JOIN ledgermaster ON CustomerWastage.LEDGERID = ledgermaster.LEDGER_ID where ledgermaster.ledger_code = '" & cmbname.Text.Trim & "'", conn)
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Open()
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                dr.Read()
                If Val(dr(0)) <> Val(griddetails.Item(GWASTAGE.Index, griddetails.CurrentRow.Index).EditedFormattedValue) Then
                    Dim TEMPMSG As Integer = MsgBox("Add this as Default Wastage?", MsgBoxStyle.YesNo)
                    If TEMPMSG = vbNo Then Exit Sub
                End If
                conn.Close()
            End If


            '********************* ADDING VALUES IN CUSTOMERWASTAGE TABLE **********************'
            'clearing array
            For i = 1 To 100
                tempcol(i) = ""
                tempval(i) = ""
            Next


            tempcol(0) = "ledgerid"
            tempcol(1) = "itemid"
            tempcol(2) = "wastage"
            tempcol(3) = "labour"
            tempcol(4) = "cus_default"


            'getting nameid
            cmd = New OleDbCommand("select ledger_id from ledgermaster where ledger_code = '" & cmbname.Text.Trim & "'", conn)
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
            conn.Open()
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                dr.Read()
                tempval(0) = Val(dr(0))
            Else
                tempval(0) = Val(0)
            End If
            conn.Close()


            'getting itemid
            cmd = New OleDbCommand("select item_id from itemmaster where item_code =  '" & griddetails.Item(cmbitemcode.Index, griddetails.CurrentRow.Index).EditedFormattedValue & "'", conn)
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
            conn.Open()
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                dr.Read()
                tempval(1) = Val(dr(0))
            Else
                tempval(1) = Val(0)
            End If
            conn.Close()

            tempval(2) = Val(griddetails.Item(GWASTAGE.Index, griddetails.CurrentRow.Index).EditedFormattedValue)
            tempval(3) = Val(griddetails.Item(GLABOUR.Index, griddetails.CurrentRow.Index).EditedFormattedValue)
            tempval(4) = 1

            modify("CustomerWastage", tempcol, tempval, " WHERE LEDGERID = " & tempval(0) & " AND ITEMID = " & tempval(1))
            '********************* END OF CODE **********************'
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub griddetails_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles griddetails.CellValidating

        If (TypeOf CType(sender, DataGridView).EditingControl Is DataGridViewComboBoxEditingControl) Then
            Dim cmb As DataGridViewComboBoxEditingControl = CType(CType(sender, DataGridView).EditingControl, DataGridViewComboBoxEditingControl)
            If Not cmb Is Nothing Then
                Dim grid As DataGridView = cmb.EditingControlDataGridView
                Dim value As Object = uppercase(cmb.Text)
                If cmb.Text.Trim <> "" Then

                    cmd = New OleDbCommand("Select item_id, ITEM_NAME AS ITEMNAME, ITEM_RATE AS PURITY from itemmaster where item_code = '" & cmb.Text.Trim & "'", conn)
                    If conn.State = ConnectionState.Open Then
                        conn.Close()
                    End If
                    conn.Open()
                    dr = cmd.ExecuteReader
                    If dr.HasRows = False Then

                        'ask to save new entry
                        tempmsg = MsgBox("Item Not Present, Add New?", MsgBoxStyle.YesNo)
                        If tempmsg = vbYes Then

                            If (chlditemmaster.IsMdiChild = False) Then
                                If chlditemmaster.IsDisposed = True Then
                                    chlditemmaster = New Itemmaster
                                End If
                                chlditemmaster.cmdedit.Enabled = True
                                chlditemmaster.EDIT = False
                                e.Cancel = True
                                chlditemmaster.cmdaddnew.Enabled = False
                                chlditemmaster.GPITEM.Enabled = True
                                chlditemmaster.txttype.Visible = False
                                chlditemmaster.txtcategory.Visible = False
                                chlditemmaster.Show(Me)
                                chlditemmaster.cmbcode.Text = UCase(cmb.Text)
                                chlditemmaster.cmbitemname.Text = UCase(cmb.Text)
                                chlditemmaster.ActiveControl = (chlditemmaster.cmbcode)
                                chlditemmaster.cmbitemname.Focus()
                            Else
                                chlditemmaster.BringToFront()
                            End If
                        Else
                            cmb.Text = cmb.Text
                            cmb.Focus()
                            e.Cancel = True
                        End If

                    Else
                        dr.Read()
                        If griddetails.CurrentRow.Cells(GITEMDESC.Index).Value = "" Or griddetails.CurrentRow.Cells(GITEMDESC.Index).Value = Nothing Then griddetails.CurrentRow.Cells(GITEMDESC.Index).Value = dr("ITEMNAME")
                        If Val(griddetails.CurrentRow.Cells(GPURITY.Index).Value) = 0 And Val(dr("PURITY")) > 0 Then griddetails.CurrentRow.Cells(GPURITY.Index).Value = Format(Val(dr("PURITY")), "0.00")

                        If cmb.Items.IndexOf(value) = -1 Then
                            cmb.Items.Add(value)
                            Dim cmbCol As DataGridViewComboBoxColumn = CType(grid.Columns(grid.CurrentCell.ColumnIndex), DataGridViewComboBoxColumn)
                            If Not cmbCol Is Nothing Then
                                cmbCol.Items.Add(value)
                            End If
                        End If
                        grid.CurrentCell.Value = value
                        Dim objstockform As New Stockform
                        objstockform.ht = griddetails.Top + Group.Top + 22 + (griddetails.CurrentRow.Height * e.RowIndex)
                        objstockform.wd = griddetails.Left + Group.Left + 70
                        objstockform.item = griddetails.CurrentRow.Cells(cmbitemcode.Index).EditedFormattedValue.ToString
                        objstockform.ShowDialog()

                        If Val(objstockform.GROSSWT) > 0 Then griddetails.CurrentRow.Cells(GGROSSWT.Index).Value = objstockform.GROSSWT
                        If Val(objstockform.PURITY) > 0 Then griddetails.CurrentRow.Cells(GPURITY.Index).Value = objstockform.PURITY

                    End If

                End If

            End If
        End If



        If e.ColumnIndex <> cmbitemcode.Index Then

            Dim strName As String = griddetails.Columns(e.ColumnIndex).Name
            If String.IsNullOrEmpty(e.FormattedValue.ToString) Then Return
            Select Case strName
                Case "griddetailgrosswt"
                    Dim dDebit As Decimal
                    Dim bValid As Boolean = Decimal.TryParse(e.FormattedValue.ToString, dDebit)

                    If bValid Then
                        griddetails.CurrentCell.Value = Convert.ToDecimal(griddetails.Item(GGROSSWT.Index, e.RowIndex).Value)
                    Else
                        MessageBox.Show("Invalid number")
                        e.Cancel = True
                    End If

                Case "GLESSWT"
                    Dim dDebit As Decimal
                    Dim bValid As Boolean = Decimal.TryParse(e.FormattedValue.ToString, dDebit)

                    If bValid Then
                        griddetails.CurrentCell.Value = Convert.ToDecimal(griddetails.Item(GLESSWT.Index, e.RowIndex).Value)

                    Else
                        MessageBox.Show("Invalid number")
                        e.Cancel = True
                    End If

                Case "GSTONERATE"
                    Dim dDebit As Decimal
                    Dim bValid As Boolean = Decimal.TryParse(e.FormattedValue.ToString, dDebit)

                    If bValid Then
                        griddetails.CurrentCell.Value = Convert.ToDecimal(griddetails.Item(GSTONERATE.Index, e.RowIndex).Value)

                    Else
                        MessageBox.Show("Invalid number")
                        e.Cancel = True
                    End If

                Case "griddetailpurity"
                    Dim dDebit As Decimal
                    Dim bValid As Boolean = Decimal.TryParse(e.FormattedValue.ToString, dDebit)

                    If bValid Then
                        griddetails.CurrentCell.Value = Convert.ToDecimal(griddetails.Item(GPURITY.Index, e.RowIndex).Value)
                        ' everything is good
                    Else
                        MessageBox.Show("Invalid number")
                        e.Cancel = True
                    End If

                Case "griddetailwastage"
                    Dim dDebit As Decimal
                    Dim bValid As Boolean = Decimal.TryParse(e.FormattedValue.ToString, dDebit)

                    If bValid Then
                        griddetails.CurrentCell.Value = Convert.ToDecimal(griddetails.Item(GWASTAGE.Index, e.RowIndex).Value)
                        ' everything is good
                    Else
                        MessageBox.Show("Invalid number")
                        e.Cancel = True
                    End If

                Case "griddetailnettwt"
                    Dim dDebit As Decimal
                    Dim bValid As Boolean = Decimal.TryParse(e.FormattedValue.ToString, dDebit)

                    If bValid Then
                        griddetails.CurrentCell.Value = Convert.ToDecimal(griddetails.Item(GFINEWT.Index, e.RowIndex).Value)
                        ' everything is good
                    Else
                        MessageBox.Show("Invalid number")
                        e.Cancel = True
                    End If

                Case "griddetaillabour"
                    Dim dDebit As Decimal
                    Dim bValid As Boolean = Decimal.TryParse(e.FormattedValue.ToString, dDebit)

                    If bValid Then
                        griddetails.CurrentCell.Value = Convert.ToDecimal(griddetails.Item(GLABOUR.Index, e.RowIndex).Value)
                        ' everything is good
                    Else
                        MessageBox.Show("Invalid number")
                        e.Cancel = True
                    End If
                Case "griddetailpieces"
                    Dim dDebit As Decimal
                    Dim bValid As Boolean = Decimal.TryParse(e.FormattedValue.ToString, dDebit)

                    If bValid Then
                        griddetails.CurrentCell.Value = Convert.ToDecimal(griddetails.Item(GPCS.Index, e.RowIndex).Value)
                        ' everything is good
                    Else
                        MessageBox.Show("Invalid number")
                        e.Cancel = True
                    End If

                Case "griddetailbullion"
                    Dim dDebit As Decimal
                    Dim bValid As Boolean = Decimal.TryParse(e.FormattedValue.ToString, dDebit)

                    If bValid Then
                        griddetails.CurrentCell.Value = Convert.ToDecimal(griddetails.Item(GBULLION.Index, e.RowIndex).Value)
                        ' everything is good
                    Else
                        MessageBox.Show("Invalid number")
                        e.Cancel = True
                    End If

                Case "griddetailamount"
                    Dim dDebit As Decimal
                    Dim bValid As Boolean = Decimal.TryParse(e.FormattedValue.ToString, dDebit)

                    If bValid Then
                        griddetails.CurrentCell.Value = Convert.ToDecimal(griddetails.Item(GAMT.Index, e.RowIndex).Value)
                        ' everything is good
                    Else
                        MessageBox.Show("Invalid number")
                        e.Cancel = True
                    End If
            End Select
        End If
    End Sub

    Private Sub griddetails_CurrentCellDirtyStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles griddetails.CurrentCellDirtyStateChanged
        If griddetails.IsCurrentCellDirty Then
            griddetails.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Sub griddetails_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles griddetails.EditingControlShowing
        If (TypeOf e.Control Is DataGridViewComboBoxEditingControl) Then
            Dim cmb As DataGridViewComboBoxEditingControl = CType(e.Control, DataGridViewComboBoxEditingControl)
            If Not cmb Is Nothing Then
                cmb.DropDownStyle = ComboBoxStyle.DropDown
            End If
        End If
        m_EditingRow = griddetails.CurrentRow.Index

    End Sub

    Private Sub griddetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles griddetails.KeyDown
        If e.KeyCode = Keys.Delete Then
            If griddetails.Rows(griddetails.CurrentRow.Index).IsNewRow <> True Then griddetails.Rows.RemoveAt(griddetails.CurrentRow.Index)
            ' total()
        End If


        If e.KeyCode = Keys.F12 Then
            If griddetails.CurrentRow.Index - 1 < 0 Then Exit Sub
            If IsDBNull(griddetails.Rows(griddetails.CurrentRow.Index - 1).Cells(GITEMDESC.Index).Value) = False Then
                griddetails.Rows(griddetails.CurrentRow.Index).Cells(GITEMDESC.Index).Value = griddetails.Rows(griddetails.CurrentRow.Index - 1).Cells(GITEMDESC.Index).Value
            End If
        End If

        If e.KeyCode = Keys.Return Then

            Dim cur_cell As DataGridViewCell = griddetails.CurrentCell
            Dim col As Integer = cur_cell.ColumnIndex

            If col = griddetails.Columns.Count - 1 And griddetails.CurrentRow.Index < griddetails.RowCount - 1 Then
                cur_cell = griddetails.Rows(griddetails.CurrentRow.Index + 1).Cells(GSRNO.Index)
            Else
                col = (col + 1) Mod griddetails.Columns.Count
                cur_cell = griddetails.CurrentRow.Cells(col)
            End If


            griddetails.CurrentCell = cur_cell

            e.Handled = True
        End If

        If e.KeyCode = Keys.F2 Then
            If griddetails.CurrentCell.ColumnIndex = cmbitemcode.Index Then
                Dim OBJITEM As New SelectItem
                OBJITEM.ShowDialog()
                griddetails.CurrentCell.Value = OBJITEM.TEMPCODE
            End If
        End If
    End Sub

    Private Sub griddetails_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles griddetails.SelectionChanged

        If m_EditingRow >= 0 Then
            Dim new_row As Integer = m_EditingRow
            m_EditingRow = -1
            griddetails.CurrentCell = griddetails.Rows(new_row).Cells(griddetails.CurrentCell.ColumnIndex)
        End If
        TOTAL()
    End Sub

    Private Sub txtamount_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtamount.KeyPress, txtcashrec.KeyPress, txtbhavcut.KeyPress, txtperwt.KeyPress, txtrate.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub

    Private Sub txtcrdays_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcrdays.KeyPress
        numkeypress(e, txtcrdays, Me)
    End Sub

    Private Sub DTPicker_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DTPicker.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
            e.Handled = False
        End If
    End Sub

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        If cmbname.Text.Trim <> "" And griddetails.RowCount > 0 And txtbillno.Text.Trim <> "" And chkchange.CheckState = CheckState.Checked Then
            tempmsg = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
            If tempmsg = vbYes Then cmdok_Click(sender, e)
        End If
        Me.Close()

        If frmdailykhata = True Then

            If (chlddailykhata.IsMdiChild = False) Then
                If chlddailykhata.IsDisposed = True Then
                    chlddailykhata = New dailykhata
                End If
                chlddailykhata.MdiParent = MDIMain
                chlddailykhata.Show()
            Else
                chlddailykhata.BringToFront()
            End If
        End If
    End Sub

    Private Sub cmdclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        clear()
        cmdedit.Enabled = True
        EDIT = False
    End Sub

    Private Sub SaveToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripButton.Click
        cmdok_Click(sender, e)
    End Sub

    Private Sub OpenToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripButton.Click

        'voucherdetails
        'Me.Close()
        'If (chldvoucherdetails.IsMdiChild = False) Then
        '    If chldvoucherdetails.IsDisposed = True Then
        '        chldvoucherdetails = New Voucherdetails
        '    End If
        '    chldvoucherdetails.MdiParent = MDIMain
        '    chldvoucherdetails.Show()
        'Else
        '    chldvoucherdetails.BringToFront()
        'End If
        Try
            Dim OBJVOUCHER As New Voucherdetails
            OBJVOUCHER.MdiParent = MDIMain
            OBJVOUCHER.FRMSTRING = FRMSTRING
            OBJVOUCHER.Show()
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub toolprevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolprevious.Click

        TEMPBILLNO = txtbillno.Text - 1
        If TEMPBILLNO > 0 Then
            griddetails.CurrentCell = griddetails.Rows(0).Cells(GSRNO.Index)
            cmdedit.Enabled = False
            EDIT = True
            vouchers_Shown(sender, e)
        Else
            clear()
            cmdedit.Enabled = True
            EDIT = False
        End If
    End Sub

    Private Sub toolnext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolnext.Click
        TEMPBILLNO = txtbillno.Text + 1

        dr.Close()
        If FRMSTRING = "ISSUE" Then
            cmd = New OleDbCommand("select max(voucher_id) from vouchers where voucher_type='I'", conn)
        Else
            cmd = New OleDbCommand("select max(voucher_id) from vouchers where voucher_type='R'", conn)
        End If
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If
        conn.Open()
        dr = cmd.ExecuteReader
        If dr.HasRows = True Then
            dr.Read()
            If TEMPBILLNO <= Val(dr(0)) Then
                griddetails.CurrentCell = griddetails.Rows(0).Cells(GSRNO.Index)
                cmdedit.Enabled = False
                EDIT = True
                vouchers_Shown(sender, e)
            Else
                clear()
                cmdedit.Enabled = True
                EDIT = False
            End If
        End If
    End Sub

    Private Sub txtperwt_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtperwt.Validated, txtrate.Validated, txtcashrec.Validated
        TOTAL()
    End Sub

    Private Sub txtbhavcut_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtbhavcut.Validating
        If Val(txtbhavcut.Text) > Val(LBLTOTALFINEWT.Text) Then
            MsgBox("Bhavcut Greater Than Nett Wt.!!", MsgBoxStyle.Critical)
            e.Cancel = True
        Else
            TOTAL()
        End If
    End Sub

    Private Sub cmbsalesmen_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbsalesmen.Validating
        If cmbsalesmen.Text.Trim <> "" Then
            cmd = New OleDbCommand("SELECT salesmen_name FROM salesmenMaster where salesmen_name = '" & cmbsalesmen.Text.Trim & "'", conn)
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
            conn.Open()
            dr = cmd.ExecuteReader
            If dr.HasRows = False Then

                'ask to save new entry
                tempmsg = MsgBox("SalesMen Not Present, Add New?", MsgBoxStyle.YesNo)
                If tempmsg = vbYes Then


                    If (chldSalesmenmaster.IsMdiChild = False) Then
                        If chldSalesmenmaster.IsDisposed = True Then
                            chldSalesmenmaster = New salesmenmaster
                        End If

                        EDIT = False
                        e.Cancel = True
                        chldSalesmenmaster.Show(Me)
                        chldSalesmenmaster.txtname.Text = caps(cmbsalesmen.Text.Trim)
                        chldSalesmenmaster.ActiveControl = (chldSalesmenmaster.txtname)
                        chldSalesmenmaster.txtname.Focus()
                    Else
                        chldSalesmenmaster.BringToFront()
                    End If

                Else
                    cmbsalesmen.Focus()
                    e.Cancel = True
                End If

            End If
        End If
    End Sub

    Sub fillcmbsalesmen()
        cmbsalesmen.Items.Clear()
        tempcmd = New OleDbCommand("SELECT salesmen_name FROM salesmenmaster order by salesmen_name", tempconn)
        If tempconn.State = ConnectionState.Open Then
            tempconn.Close()
        End If
        tempconn.Open()
        tempdr = tempcmd.ExecuteReader
        If tempdr.HasRows = True Then
            While (tempdr.Read)
                cmbsalesmen.Items.Add(caps(tempdr(0).ToString))
            End While
        End If
    End Sub

    Private Sub ToolStripdelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripdelete.Click
        Try
            Call CMDDELETE_Click(sender, e)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDDELETE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDDELETE.Click
        Try

            If cmdedit.Enabled = False Then

                tempmsg = MsgBox("Wish To Delete Voucher?", MsgBoxStyle.YesNo)
                If tempmsg = vbYes Then

                    'deleteing from Vouchers
                    cmd = New OleDbCommand("delete from vouchers where voucher_id = " & txtbillno.Text & " and voucher_type ='" & types & "'", conn)
                    If conn.State = ConnectionState.Open Then
                        conn.Close()
                    End If
                    conn.Open()
                    cmd.ExecuteNonQuery()


                    cmd = New OleDbCommand("delete from accountmaster where account_voucherid = " & txtbillno.Text & " and account_type ='" & types & "'", conn)
                    If conn.State = ConnectionState.Open Then
                        conn.Close()
                    End If

                    conn.Open()
                    cmd.ExecuteNonQuery()
                    conn.Close()

                    clear()

                End If

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub PRINTREPORT()
        Try
            Dim OBJVOUCHER As New VoucherDesign
            OBJVOUCHER.MdiParent = MDIMain
            If EDIT = True Then
                OBJVOUCHER.WHERECLAUSE = " {VOUCHERS.VOUCHER_ID} = " & Val(TEMPBILLNO) & " and {VOUCHERS.VOUCHER_TYPE} = '" & types & "'"
            Else
                OBJVOUCHER.WHERECLAUSE = " {VOUCHERS.VOUCHER_ID} = " & Val(txtbillno.Text.Trim) & " and {VOUCHERS.VOUCHER_TYPE} = '" & types & "'"
            End If
            If ClientName = "KHUSHALI" Then
                If MsgBox("Print small Chitti?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
                If PRINTDIALOG.ShowDialog = DialogResult.OK Then PRINTDOC.PrinterSettings = PRINTDIALOG.PrinterSettings Else Exit Sub
                OBJVOUCHER.SRNO = Val(TEMPBILLNO)
                If types = "I" Then OBJVOUCHER.ISSREC = "ISSUE" Else OBJVOUCHER.ISSREC = "RECEIPT"
                OBJVOUCHER.PARTYCODE = cmbname.Text.Trim
                OBJVOUCHER.DEPT = cmbname.Text.Trim
                If griddetails.RowCount > 0 Then OBJVOUCHER.MELTING = Val(griddetails.Rows(0).Cells(GPURITY.Index).Value) Else OBJVOUCHER.MELTING = 0.00
                OBJVOUCHER.PCS = Val(lblpiecestotal.Text.Trim)
                OBJVOUCHER.WT = Val(lblgrosswttotal.Text.Trim)
                OBJVOUCHER.LESSWT = Val(LBLTOTALLESSWT.Text.Trim)
                OBJVOUCHER.NETTWT = Val(LBLTOTALNETTWT.Text.Trim)
                OBJVOUCHER.ITEMNARR = txtnarration.Text.Trim
                OBJVOUCHER.MdiParent = MDIMain
                OBJVOUCHER.FRMSTRING = "WTCHITTI"
                OBJVOUCHER.DIRECTPRINT = True
                OBJVOUCHER.PRINTSETTING = PRINTDIALOG
                OBJVOUCHER.Show()
                OBJVOUCHER.Close()
            Else
                If Val(txtamount.Text.Trim) > 0 Then OBJVOUCHER.FRMSTRING = "ISSUEBHAVCUTCHITTI" Else OBJVOUCHER.FRMSTRING = "ISSUECHITTI"
                OBJVOUCHER.PARTYCODE = cmbname.Text.Trim
                OBJVOUCHER.Show()
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try
            If EDIT = True Then PRINTREPORT()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridadd_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles gridadd.CellValidating
        Dim colNum As Integer = gridadd.Columns(e.ColumnIndex).Index
        If String.IsNullOrEmpty(e.FormattedValue.ToString) Then Return

        Select Case colNum

            Case GADDAMT.Index
                Dim dDebit As Decimal
                Dim bValid As Boolean = Decimal.TryParse(e.FormattedValue.ToString, dDebit)

                If bValid Then
                    If gridadd.CurrentCell.Value = Nothing Then gridadd.CurrentCell.Value = "0.00"
                    gridadd.CurrentCell.Value = Convert.ToDecimal(gridadd.Item(colNum, e.RowIndex).Value)
                    '' everything is good
                    TOTAL()
                Else
                    MessageBox.Show("Invalid Number Entered")
                    e.Cancel = True
                    Exit Sub
                End If

        End Select
    End Sub

    Private Sub gridless_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles gridless.CellValidating
        Dim colNum As Integer = gridless.Columns(e.ColumnIndex).Index
        If String.IsNullOrEmpty(e.FormattedValue.ToString) Then Return

        Select Case colNum

            Case lessamt.Index
                Dim dDebit As Decimal
                Dim bValid As Boolean = Decimal.TryParse(e.FormattedValue.ToString, dDebit)

                If bValid Then
                    If gridless.CurrentCell.Value = Nothing Then gridless.CurrentCell.Value = "0.00"
                    gridless.CurrentCell.Value = Convert.ToDecimal(gridless.Item(colNum, e.RowIndex).Value)
                    '' everything is good
                    TOTAL()
                Else
                    MessageBox.Show("Invalid Number Entered")
                    e.Cancel = True
                    Exit Sub
                End If

        End Select
    End Sub

    Private Sub gridless_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridless.KeyDown
        If e.KeyCode = Keys.Delete Then
            If gridless.Rows(gridless.CurrentRow.Index).IsNewRow <> True Then gridless.Rows.RemoveAt(gridless.CurrentRow.Index)
            ' total()
        End If
    End Sub

    Private Sub gridadd_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridadd.KeyDown
        If e.KeyCode = Keys.Delete Then
            If gridadd.Rows(gridadd.CurrentRow.Index).IsNewRow <> True Then gridadd.Rows.RemoveAt(gridadd.CurrentRow.Index)
            ' total()
        End If
    End Sub

    Private Sub cmbname_Enter(sender As Object, e As EventArgs) Handles cmbname.Enter
        'If cmbname.Text.Trim = "" Then fillname(Me, cmbname, " AND (group_name = 'Sundry Creditors' OR group_name = 'Sundry Debtors')")
        'AS PER MEHUL SIR
        If cmbname.Text.Trim = "" Then fillname(Me, cmbname, "")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If EDIT = True Then PRINTREPORT()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class