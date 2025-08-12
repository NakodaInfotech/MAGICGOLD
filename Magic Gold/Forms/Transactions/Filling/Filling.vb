
Imports System.Data.OleDb

Public Class Filling

    Dim GridDoubleClick As Boolean
    Dim GridDoubleClickIssue As Boolean
    Dim TempRow As Integer
    Dim TempRowIssue As Integer
    Public edit As Boolean
    Public TEMPFILLINGNO As Integer

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Sub GETMAX_FILLING_NO()
        'getting FILLINGID from database
        cmd = New OleDbCommand("select IIF(ISNULL(max(FILLING_NO)) = TRUE, 0,max(FILLING_NO)) + 1 from FILLING", conn)
        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Open()
        dr = cmd.ExecuteReader
        If dr.HasRows Then
            dr.Read()
            TXTFILLINGNO.Text = Val(dr(0).ToString)
        End If
        conn.Close()
        dr.Close()
    End Sub

    Sub clear()
        Try

            tstxtbillno.Clear()
            CMBTYPE.SelectedIndex = 0
            CMBTYPE.Enabled = True

            TXTFILLINGNO.Clear()
            FILLINGDATE.Value = Now.Date
            CMBNAME.Text = ""
            CMBITEMNAME.Text = ""
            TXTGROSS.Clear()
            TXTPURITY.Clear()
            TXTNETT.Clear()
            TXTWASTAGE.Clear()
            TXTNARR.Clear()

            GRIDISSUE.RowCount = 0
            GRIDREC.ClearSelection()
            GRIDREC.RowCount = 0
            GRIDREC.ClearSelection()

            LBLISSGROSSWT.Text = "0.000"
            LBLISSNETTWT.Text = "0.000"
            LBLRECGROSSWT.Text = "0.000"
            LBLRECNETTWT.Text = "0.000"
            LBLRECWAST.Text = "0.000"

            TXTREMARKS.Clear()
            TXTLOSS.Clear()
            TXTBALANCE.Clear()


            EP.Clear()
            GridDoubleClick = False
            GridDoubleClickIssue = False

            LBLLOCKED.Visible = False
            LBLCLOSED.Visible = False

            TempRow = 0
            TempRowIssue = 0
            GETMAX_FILLING_NO()

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub cmbname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBNAME.Enter
        Try
            If CMBNAME.Text.Trim = "" Then fillname(Me, CMBNAME, " AND LEDGERMASTER.LEDGER_KARIGAR = TRUE")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNAME_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBNAME.KeyDown
        Try
            If e.KeyCode = Keys.F1 And e.Alt = True Then
                Dim OBJSELECT As New SelectLedger
                OBJSELECT.STRSEARCH = " AND (GROUPMASTER.GROUP_NAME = 'Sundry Debtor' or GROUPMASTER.GROUP_NAME = 'Sundry Creditors')"
                OBJSELECT.ShowDialog()
                CMBNAME.Text = OBJSELECT.TEMPCODE
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBNAME.Validating
        Try
            If cmbname.Text.Trim <> "" Then namevalidate(cmbname, e, Me, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        clear()
        edit = False
        FILLINGDATE.Focus()
    End Sub

    Private Sub Filling_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNoCancel)
                If tempmsg = vbYes Then
                    If errorvalid() = True Then cmdok_Click(sender, e)
                ElseIf tempmsg = vbCancel Then
                    Exit Sub
                End If
                Me.Close()
            ElseIf e.KeyCode = Keys.Oemcomma Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.OemQuotes Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            ElseIf e.KeyCode = Keys.F2 Then
                tstxtbillno.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillcmb()
        Try
            If CMBITEMNAME.Text.Trim = "" Then If CMBITEMNAME.Text.Trim = "" Then FILLITEMCODE(Me, CMBITEMNAME, "")
            If CMBNAME.Text.Trim = "" Then fillname(Me, CMBNAME, " AND LEDGERMASTER.LEDGER_KARIGAR = TRUE")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Filling_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Cursor.Current = Cursors.WaitCursor
            fillcmb()
            clear()

            If edit = True Then
                dt = New DataTable
                If conn.State = ConnectionState.Open Then conn.Close()
                conn.Open()
                cmd = New OleDbCommand(" SELECT ledgermaster.ledger_code  AS NAME, FILLING.FILLING_DATE AS FILLINGDATE, FILLING.FILLING_TYPE AS FILLINGTYPE, FILLING.FILLING_SRNO AS SRNO, ItemMaster.item_CODE AS ITEMCODE, FILLING.FILLING_GROSSWT AS GROSSWT, FILLING.FILLING_PURITY AS PURITY, FILLING.FILLING_NETTWT AS NETTWT, FILLING.FILLING_WASTAGE AS WASTAGE, FILLING.FILLING_NARR AS NARR, FILLING.FILLING_REMARKS AS REMARKS, FILLING.FILLING_LOSS AS LOSS, FILLING.FILLING_BALANCE AS BALANCE, FILLING.FILLING_SETTLED AS SETTLED FROM (FILLING INNER JOIN ItemMaster ON FILLING.FILLING_ITEMID = ItemMaster.item_id) INNER JOIN ledgermaster ON FILLING.FILLING_LEDGERID = ledgermaster.ledger_id  WHERE FILLING.FILLING_NO =  " & TEMPFILLINGNO, conn)
                da = New OleDbDataAdapter(cmd)
                da.Fill(dt)
                If dt.Rows.Count > 0 Then
                    For Each dr As DataRow In dt.Rows

                        TXTFILLINGNO.Text = TEMPFILLINGNO
                        CMBNAME.Text = dr("NAME")
                        FILLINGDATE.Value = Convert.ToDateTime(dr("FILLINGDATE"))

                        TXTREMARKS.Text = dr("REMARKS")
                        TXTLOSS.Text = Format(Val(dr("LOSS")), "0.000")
                        TXTBALANCE.Text = Format(Val(dr("BALANCE")), "0.000")

                        If dr("FILLINGTYPE") = "Issue" Then
                            GRIDISSUE.Rows.Add(dr("SRNO"), dr("ITEMCODE").ToString, Format(Val(dr("GROSSWT")), "0.000"), Format(Val(dr("PURITY")), "0.00"), Format(Val(dr("NETTWT")), "0.000"), Format(Val(dr("WASTAGE")), "0.000"), dr("NARR").ToString)
                        Else
                            GRIDREC.Rows.Add(dr("SRNO"), dr("ITEMCODE").ToString, Format(Val(dr("GROSSWT")), "0.000"), Format(Val(dr("PURITY")), "0.00"), Format(Val(dr("NETTWT")), "0.000"), Format(Val(dr("WASTAGE")), "0.000"), dr("NARR").ToString)
                        End If
                        If Convert.ToBoolean(dr("SETTLED")) = True Then
                            LBLLOCKED.Visible = True
                            LBLCLOSED.Visible = True
                        End If
                    Next
                    If GRIDREC.RowCount > 0 Then GRIDREC.FirstDisplayedScrollingRowIndex = GRIDREC.RowCount - 1
                    If GRIDISSUE.RowCount > 0 Then GRIDISSUE.FirstDisplayedScrollingRowIndex = GRIDISSUE.RowCount - 1
                    total()
                Else
                    'IF ROWCOUNT = 0
                    clear()
                    edit = False
                    FILLINGDATE.Focus()
                End If

            End If

        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub Filling_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If ClientName <> "MIMARAGEMS" And ClientName <> "SANGAMGEMS" Then Me.Close()
    End Sub

    Private Sub CMBITEMNAME_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBITEMNAME.Enter
        Try
            If CMBITEMNAME.Text.Trim = "" Then If CMBITEMNAME.Text.Trim = "" Then FILLITEMCODE(Me, CMBITEMNAME, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBITEMNAME_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBITEMNAME.KeyDown
        Try
            If e.KeyCode = Keys.F1 And e.Alt = True Then
                Dim OBJITEM As New SelectItem
                OBJITEM.ShowDialog()
                CMBITEMNAME.Text = OBJITEM.TEMPCODE
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBITEMNAME_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBITEMNAME.Validating
        Try
            If CMBITEMNAME.Text.Trim <> "" Then ITEMVALIDATE(CMBITEMNAME, e, Me, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            Cursor.Current = Cursors.WaitCursor

            EP.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            'DELETE DATA FROM FILLING
            If edit = True Then
                cmd = New OleDbCommand("delete from FILLING where FILLING_NO = " & TEMPFILLINGNO, conn)
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
                conn.Open()
                cmd.ExecuteNonQuery()
            End If

            For i = 0 To 100
                tempcol(i) = ""
                tempval(i) = ""
            Next

            tempcol(0) = "FILLING_NO"
            tempcol(1) = "FILLING_DATE"
            tempcol(2) = "FILLING_LEDGERID"
            tempcol(3) = "FILLING_TYPE"
            tempcol(4) = "FILLING_SRNO"
            tempcol(5) = "FILLING_ITEMID"
            tempcol(6) = "FILLING_GROSSWT"
            tempcol(7) = "FILLING_PURITY"
            tempcol(8) = "FILLING_NETTWT"
            tempcol(9) = "FILLING_WASTAGE"
            tempcol(10) = "FILLING_NARR"
            tempcol(11) = "FILLING_REMARKS"
            tempcol(12) = "FILLING_LOSS"
            tempcol(13) = "FILLING_BALANCE"
            tempcol(14) = "FILLING_TOTALISSGROSS"
            tempcol(15) = "FILLING_TOTALISSNETT"
            tempcol(16) = "FILLING_TOTALISSWASTAGE"
            tempcol(17) = "FILLING_TOTALRECGROSS"
            tempcol(18) = "FILLING_TOTALRECNETT"
            tempcol(19) = "FILLING_TOTALRECWASTAGE"
            tempcol(20) = "FILLING_SETTLED"
            tempcol(21) = "FILLING_USERID"
            tempcol(22) = "FILLING_DEPARTMENTID"

            For Each ROW As DataGridViewRow In GRIDISSUE.Rows

                tempval(0) = Val(TXTFILLINGNO.Text.Trim)
                tempval(1) = "'" & Format(FILLINGDATE.Value, "dd/MM/yyyy") & "'"

                'getting LEDGERID
                tempcmd = New OleDbCommand("select LEDGER_id from LEDGERMASTER where LEDGER_code = '" & CMBNAME.Text.Trim & "'", tempconn)
                If tempconn.State = ConnectionState.Open Then
                    tempconn.Close()
                End If
                tempconn.Open()
                tempdr = tempcmd.ExecuteReader
                If tempdr.HasRows Then
                    tempdr.Read()
                    tempval(2) = Val(tempdr(0))
                Else
                    tempval(2) = 0
                End If
                tempconn.Close()
                tempdr.Close()

                tempval(3) = "'Issue'"
                tempval(4) = Val(ROW.Cells(GISSSRNO.Index).Value)

                'getting itemid
                tempcmd = New OleDbCommand("select item_id from itemmaster where item_code = '" & ROW.Cells(GISSITEMCODE.Index).Value & "'", tempconn)
                If tempconn.State = ConnectionState.Open Then
                    tempconn.Close()
                End If
                tempconn.Open()
                tempdr = tempcmd.ExecuteReader
                If tempdr.HasRows Then
                    tempdr.Read()
                    tempval(5) = Val(tempdr(0))
                Else
                    tempval(5) = 0
                End If
                tempconn.Close()
                tempdr.Close()

                tempval(6) = Format(Val(ROW.Cells(GISSGROSSWT.Index).Value), "0.000")
                tempval(7) = Format(Val(ROW.Cells(GISSPURITY.Index).Value), "0.00")
                tempval(8) = Format(Val(ROW.Cells(GISSNETTWT.Index).Value), "0.000")
                tempval(9) = Format(Val(ROW.Cells(GISSWASTAGE.Index).Value), "0.000")
                tempval(10) = "'" & ROW.Cells(GISSNARR.Index).Value & "'"
                tempval(11) = "'" & TXTREMARKS.Text.Trim & "'"
                tempval(12) = Format(Val(TXTLOSS.Text.Trim), "0.000")
                tempval(13) = Format(Val(TXTBALANCE.Text.Trim), "0.000")
                tempval(14) = Format(Val(LBLISSGROSSWT.Text.Trim), "0.000")
                tempval(15) = Format(Val(LBLISSNETTWT.Text.Trim), "0.000")
                tempval(16) = 0 'ISS WASTAGE
                tempval(17) = Format(Val(LBLRECGROSSWT.Text.Trim), "0.000")
                tempval(18) = Format(Val(LBLRECNETTWT.Text.Trim), "0.000")
                tempval(19) = Format(Val(LBLRECWAST.Text.Trim), "0.000")
                tempval(20) = 0
                tempval(21) = USERID
                tempval(22) = USERDEPARTMENTID

                insert("FILLING", tempcol, tempval)

            Next


            For Each ROW As DataGridViewRow In GRIDREC.Rows

                tempval(0) = Val(TXTFILLINGNO.Text.Trim)
                tempval(1) = "'" & Format(FILLINGDATE.Value, "dd/MM/yyyy") & "'"

                'getting LEDGERID
                tempcmd = New OleDbCommand("select LEDGER_id from LEDGERMASTER where LEDGER_code = '" & CMBNAME.Text.Trim & "'", tempconn)
                If tempconn.State = ConnectionState.Open Then
                    tempconn.Close()
                End If
                tempconn.Open()
                tempdr = tempcmd.ExecuteReader
                If tempdr.HasRows Then
                    tempdr.Read()
                    tempval(2) = Val(tempdr(0))
                Else
                    tempval(2) = 0
                End If
                tempconn.Close()
                tempdr.Close()

                tempval(3) = "'Jama'"
                tempval(4) = Val(ROW.Cells(GRECSRNO.Index).Value)

                'getting itemid
                tempcmd = New OleDbCommand("select item_id from itemmaster where item_code = '" & ROW.Cells(GRECITEMCODE.Index).Value & "'", tempconn)
                If tempconn.State = ConnectionState.Open Then
                    tempconn.Close()
                End If
                tempconn.Open()
                tempdr = tempcmd.ExecuteReader
                If tempdr.HasRows Then
                    tempdr.Read()
                    tempval(5) = Val(tempdr(0))
                Else
                    tempval(5) = 0
                End If
                tempconn.Close()
                tempdr.Close()

                tempval(6) = Format(Val(ROW.Cells(GRECGROSSWT.Index).Value), "0.000")
                tempval(7) = Format(Val(ROW.Cells(GRECPURITY.Index).Value), "0.00")
                tempval(8) = Format(Val(ROW.Cells(GRECNETTWT.Index).Value), "0.000")
                tempval(9) = Format(Val(ROW.Cells(GRECWASTAGE.Index).Value), "0.000")
                tempval(10) = "'" & ROW.Cells(GRECNARR.Index).Value & "'"
                tempval(11) = "'" & TXTREMARKS.Text.Trim & "'"
                tempval(12) = Format(Val(TXTLOSS.Text.Trim), "0.000")
                tempval(13) = Format(Val(TXTBALANCE.Text.Trim), "0.000")
                tempval(14) = Format(Val(LBLISSGROSSWT.Text.Trim), "0.000")
                tempval(15) = Format(Val(LBLISSNETTWT.Text.Trim), "0.000")
                tempval(16) = 0
                tempval(17) = Format(Val(LBLRECGROSSWT.Text.Trim), "0.000")
                tempval(18) = Format(Val(LBLRECNETTWT.Text.Trim), "0.000")
                tempval(19) = Format(Val(LBLRECWAST.Text.Trim), "0.000")
                tempval(20) = 0
                tempval(21) = USERID
                tempval(22) = USERDEPARTMENTID

                insert("FILLING", tempcol, tempval)

            Next



            'clearing array
            For i = 1 To 100
                tempcol(i) = ""
                tempval(i) = ""
            Next

            'adding data in accountmasrer
            If edit = True Then
                cmd = New OleDbCommand("delete from accountmaster where account_voucherid = " & TXTFILLINGNO.Text & " and account_type ='FILLING'", conn)
                If conn.State = ConnectionState.Open Then conn.Close()
                conn.Open()
                cmd.ExecuteNonQuery()
                conn.Close()
            End If

            'ADD 2 POSTINGS FOR JAMA AND ISSUE
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


            'ACCOUNTS POSTING (JAMA)
            If GRIDREC.RowCount > 0 Then
                tempval(0) = "'" & Format(FILLINGDATE.Value, "dd/MM/yyyy") & "'"

                'getting LEDGERID
                tempcmd = New OleDbCommand("select LEDGER_id from LEDGERMASTER where LEDGER_code = '" & CMBNAME.Text.Trim & "'", tempconn)
                If tempconn.State = ConnectionState.Open Then tempconn.Close()
                tempconn.Open()
                tempdr = tempcmd.ExecuteReader
                If tempdr.HasRows Then
                    tempdr.Read()
                    tempval(1) = Val(tempdr(0))
                Else
                    tempval(1) = 0
                End If
                tempconn.Close()
                tempdr.Close()

                tempval(2) = Format(Val(LBLRECGROSSWT.Text), "0.000")
                tempval(3) = Format(Val(LBLRECNETTWT.Text), "0.000")
                tempval(4) = 0
                tempval(5) = "'" & TXTREMARKS.Text & "'"
                tempval(6) = "'Jama'"
                tempval(7) = TXTFILLINGNO.Text
                tempval(8) = "'FILLING'"
                tempval(9) = "'" & CMBNAME.Text.Trim & "'"
                tempval(10) = Val(USERID)
                tempval(11) = Val(USERDEPARTMENTID)
                tempval(12) = "''"  'PROCESSNAME

                insert("accountmaster", tempcol, tempval)
            End If



            'ACCOUNTS POSTING (ISSUE)
            If GRIDISSUE.RowCount > 0 Then
                tempval(0) = "'" & Format(FILLINGDATE.Value, "dd/MM/yyyy") & "'"

                'getting LEDGERID
                tempcmd = New OleDbCommand("select LEDGER_id from LEDGERMASTER where LEDGER_code = '" & CMBNAME.Text.Trim & "'", tempconn)
                If tempconn.State = ConnectionState.Open Then tempconn.Close()
                tempconn.Open()
                tempdr = tempcmd.ExecuteReader
                If tempdr.HasRows Then
                    tempdr.Read()
                    tempval(1) = Val(tempdr(0))
                Else
                    tempval(1) = 0
                End If
                tempconn.Close()
                tempdr.Close()

                tempval(2) = Format(Val(LBLISSGROSSWT.Text), "0.000")
                tempval(3) = Format(Val(LBLISSNETTWT.Text), "0.000")
                tempval(4) = 0
                tempval(5) = "'" & TXTREMARKS.Text & "'"
                tempval(6) = "'Balance'"
                tempval(7) = TXTFILLINGNO.Text
                tempval(8) = "'FILLING'"
                tempval(9) = "'" & CMBNAME.Text.Trim & "'"
                tempval(10) = Val(USERID)
                tempval(11) = Val(USERDEPARTMENTID)
                tempval(12) = "''"  'PROCESSNAME

                insert("accountmaster", tempcol, tempval)
            End If


            MessageBox.Show("Details Added")

            clear()
            edit = False
            FILLINGDATE.Focus()
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True

        If LBLLOCKED.Visible = True Then
            EP.SetError(LBLLOCKED, "Job Card Settled")
            bln = False
        End If

        If GRIDREC.RowCount = 0 And GRIDISSUE.RowCount = 0 Then
            EP.SetError(CMBTYPE, "Enter Item Details")
            bln = False
        End If

        Return bln
    End Function

    Sub total()

        TXTBALANCE.Text = "0.000"
        LBLISSGROSSWT.Text = "0.000"
        LBLISSNETTWT.Text = "0.000"
        LBLRECGROSSWT.Text = "0.000"
        LBLRECNETTWT.Text = "0.000"
        LBLRECWAST.Text = "0.000"

        If GRIDREC.RowCount > 0 Then
            For Each ROW As DataGridViewRow In GRIDREC.Rows
                LBLRECGROSSWT.Text = Format(Val(LBLRECGROSSWT.Text.Trim) + Val(ROW.Cells(GRECGROSSWT.Index).Value), "0.000")
                LBLRECNETTWT.Text = Format(Val(LBLRECNETTWT.Text.Trim) + Val(ROW.Cells(GRECNETTWT.Index).Value), "0.000")
                LBLRECWAST.Text = Format(Val(LBLRECWAST.Text.Trim) + Val(ROW.Cells(GRECWASTAGE.Index).Value), "0.000")
            Next
        End If

        If GRIDISSUE.RowCount > 0 Then
            For Each ROW As DataGridViewRow In GRIDISSUE.Rows
                LBLISSGROSSWT.Text = Format(Val(LBLISSGROSSWT.Text.Trim) + Val(ROW.Cells(GISSGROSSWT.Index).Value), "0.000")
                LBLISSNETTWT.Text = Format(Val(LBLISSNETTWT.Text.Trim) + Val(ROW.Cells(GISSNETTWT.Index).Value), "0.000")
            Next
        End If

        TXTBALANCE.Text = Format(Val(LBLISSGROSSWT.Text.Trim) - Val(LBLRECGROSSWT.Text.Trim) - Val(LBLRECWAST.Text.Trim) - Val(TXTLOSS.Text.Trim), "0.000")

    End Sub

    Sub getsrno(ByRef grid As System.Windows.Forms.DataGridView)
        Try
            For Each row As DataGridViewRow In grid.Rows
                row.Cells(0).Value = row.Index + 1
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLGRIDISSUEUE()

        GRIDISSUE.Enabled = True
        If GridDoubleClickIssue = False Then
            GRIDISSUE.Rows.Add(0, CMBITEMNAME.Text.Trim, Format(Val(TXTGROSS.Text.Trim), "0.000"), Format(Val(TXTPURITY.Text.Trim), "0.00"), Format(Val(TXTNETT.Text.Trim), "0.000"), Format(Val(TXTWASTAGE.Text.Trim), "0.000"), TXTNARR.Text.Trim)
            getsrno(GRIDISSUE)
        ElseIf GridDoubleClickIssue = True Then
            GRIDISSUE.Item(GISSITEMCODE.Index, TempRowIssue).Value = CMBITEMNAME.Text.Trim
            GRIDISSUE.Item(GISSGROSSWT.Index, TempRowIssue).Value = Format(Val(TXTGROSS.Text.Trim), "0.000")
            GRIDISSUE.Item(GISSPURITY.Index, TempRowIssue).Value = Format(Val(TXTPURITY.Text.Trim), "0.00")
            GRIDISSUE.Item(GISSNETTWT.Index, TempRowIssue).Value = Format(Val(TXTNETT.Text.Trim), "0.00")
            GRIDISSUE.Item(GISSWASTAGE.Index, TempRowIssue).Value = Format(Val(TXTWASTAGE.Text.Trim), "0.00")
            GRIDISSUE.Item(GISSNARR.Index, TempRowIssue).Value = TXTNARR.Text.Trim

            GridDoubleClickIssue = False
        End If

        GRIDISSUE.FirstDisplayedScrollingRowIndex = GRIDISSUE.RowCount - 1

        CMBITEMNAME.Text = ""
        TXTGROSS.Clear()
        TXTPURITY.Clear()
        TXTNETT.Clear()
        TXTWASTAGE.Clear()
        TXTNARR.Clear()
        total()

        CMBTYPE.Focus()
        CMBTYPE.Enabled = True

    End Sub

    Sub FILLGRIDJAMA()

        GRIDREC.Enabled = True
        If GridDoubleClick = False Then
            GRIDREC.Rows.Add(0, CMBITEMNAME.Text.Trim, Format(Val(TXTGROSS.Text.Trim), "0.000"), Format(Val(TXTPURITY.Text.Trim), "0.00"), Format(Val(TXTNETT.Text.Trim), "0.000"), Format(Val(TXTWASTAGE.Text.Trim), "0.000"), TXTNARR.Text.Trim)
            getsrno(GRIDREC)
        ElseIf GridDoubleClick = True Then
            GRIDREC.Item(GRECITEMCODE.Index, TempRow).Value = CMBITEMNAME.Text.Trim
            GRIDREC.Item(GRECGROSSWT.Index, TempRow).Value = Format(Val(TXTGROSS.Text.Trim), "0.000")
            GRIDREC.Item(GRECPURITY.Index, TempRow).Value = Format(Val(TXTPURITY.Text.Trim), "0.00")
            GRIDREC.Item(GRECNETTWT.Index, TempRow).Value = Format(Val(TXTNETT.Text.Trim), "0.00")
            GRIDREC.Item(GRECWASTAGE.Index, TempRow).Value = Format(Val(TXTWASTAGE.Text.Trim), "0.00")
            GRIDREC.Item(GRECNARR.Index, TempRow).Value = TXTNARR.Text.Trim

            GridDoubleClick = False
        End If

        GRIDREC.FirstDisplayedScrollingRowIndex = GRIDREC.RowCount - 1

        CMBITEMNAME.Text = ""
        TXTGROSS.Clear()
        TXTPURITY.Clear()
        TXTNETT.Clear()
        TXTWASTAGE.Clear()
        TXTNARR.Clear()
        total()

        CMBTYPE.Focus()
        CMBTYPE.Enabled = True

    End Sub

    Private Sub GRIDREC_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDREC.CellDoubleClick
        Try
            If e.RowIndex >= 0 And GRIDREC.Item(GRECSRNO.Index, e.RowIndex).Value <> Nothing Then

                GridDoubleClick = True
                CMBTYPE.Text = "Jama"
                CMBTYPE.Enabled = False
                CMBITEMNAME.Text = GRIDREC.Item(GRECITEMCODE.Index, e.RowIndex).Value.ToString
                TXTGROSS.Text = Val(GRIDREC.Item(GRECGROSSWT.Index, e.RowIndex).Value)
                TXTPURITY.Text = Val(GRIDREC.Item(GRECPURITY.Index, e.RowIndex).Value)
                TXTNETT.Text = Val(GRIDREC.Item(GRECNETTWT.Index, e.RowIndex).Value)
                TXTWASTAGE.Text = Val(GRIDREC.Item(GRECWASTAGE.Index, e.RowIndex).Value)
                TXTNARR.Text = GRIDREC.Item(GRECNARR.Index, e.RowIndex).Value

                TempRow = e.RowIndex
                CMBITEMNAME.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDREC_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDREC.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDREC.RowCount > 0 Then

                'dont allow user if any of the grid line is in edit mode.....
                If GridDoubleClick = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                'end of block

                GRIDREC.Rows.RemoveAt(GRIDREC.CurrentRow.Index)
                getsrno(GRIDREC)
                total()

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub tstxtbillno_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tstxtbillno.Validating
        Try
            If tstxtbillno.Text.Trim.Length = 0 Then Exit Sub
            GRIDREC.RowCount = 0
            GRIDISSUE.RowCount = 0
            TEMPFILLINGNO = Val(tstxtbillno.Text)
            If TEMPFILLINGNO > 0 Then
                edit = True
                Filling_Load(sender, e)
            Else
                clear()
                edit = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub OpenToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripButton.Click
        Try
            Dim OBJCAST As New FillingDetails
            OBJCAST.MdiParent = MDIMain
            OBJCAST.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SaveToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripButton.Click
        Call cmdok_Click(sender, e)
    End Sub

    Private Sub toolprevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolprevious.Click
        Try
            GRIDREC.RowCount = 0
            GRIDISSUE.RowCount = 0
LINE1:
            TEMPFILLINGNO = Val(TXTFILLINGNO.Text) - 1
            If TEMPFILLINGNO > 0 Then
                edit = True
                Filling_Load(sender, e)
            Else
                clear()
                edit = False
            End If
            If GRIDREC.RowCount = 0 And GRIDISSUE.RowCount = 0 And TEMPFILLINGNO > 1 Then
                TXTFILLINGNO.Text = TEMPFILLINGNO
                GoTo LINE1
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub toolnext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolnext.Click
        Try
            GRIDREC.RowCount = 0
            GRIDISSUE.RowCount = 0
LINE1:
            TEMPFILLINGNO = Val(TXTFILLINGNO.Text) + 1
            GETMAX_FILLING_NO()
            Dim MAXNO As Integer = TXTFILLINGNO.Text.Trim
            clear()
            If Val(TXTFILLINGNO.Text) - 1 >= TEMPFILLINGNO Then
                edit = True
                Filling_Load(sender, e)
            Else
                clear()
                edit = False
            End If
            If GRIDREC.RowCount = 0 And GRIDISSUE.RowCount = 0 And TEMPFILLINGNO < MAXNO Then
                TXTFILLINGNO.Text = TEMPFILLINGNO
                GoTo LINE1
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDDELETE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddelete.Click
        Try
            If edit = True Then
                Dim tempmsg As Integer = MsgBox("Delete FILLING Entry Permanently?", MsgBoxStyle.YesNo, "Magic Gold")
                If tempmsg = vbYes Then

                    'deleting data from ACCOUNTMASTER
                    cmd = New OleDbCommand("delete from accountmaster where account_voucherid = " & TEMPFILLINGNO & " and account_type ='FILLING'", conn)
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Open()
                    cmd.ExecuteNonQuery()
                    conn.Close()


                    'deleting data from FILLING
                    cmd = New OleDbCommand("delete from FILLING where FILLING_NO = " & TEMPFILLINGNO, conn)
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Open()
                    cmd.ExecuteNonQuery()
                    MsgBox("FILLING Entry Deleted")
                    clear()
                    edit = False
                End If

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try
            If edit = True Then PRINTREPORT(TEMPFILLINGNO)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub PRINTREPORT(ByVal BOOKNO As Integer)
        Try
            'Dim TEMPMSG As Integer = MsgBox("Wish to Print Invoice?", MsgBoxStyle.YesNo)
            'If TEMPMSG = vbYes Then
            '    Dim OBJINV As New RailBookingVoucherDesign
            '    OBJINV.MdiParent = MDIMain
            '    OBJINV.BOOKINGNO = BOOKNO
            '    OBJINV.Show()
            'End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDISSUE_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDISSUE.CellDoubleClick
        Try
            If e.RowIndex >= 0 And GRIDISSUE.Item(GISSSRNO.Index, e.RowIndex).Value <> Nothing Then

                GridDoubleClickIssue = True
                CMBTYPE.Text = "Issue"
                CMBTYPE.Enabled = False
                CMBITEMNAME.Text = GRIDISSUE.Item(GISSITEMCODE.Index, e.RowIndex).Value.ToString
                TXTGROSS.Text = Val(GRIDISSUE.Item(GISSGROSSWT.Index, e.RowIndex).Value)
                TXTPURITY.Text = Val(GRIDISSUE.Item(GISSPURITY.Index, e.RowIndex).Value)
                TXTNETT.Text = Val(GRIDISSUE.Item(GISSNETTWT.Index, e.RowIndex).Value)
                TXTWASTAGE.Text = Val(GRIDISSUE.Item(GISSWASTAGE.Index, e.RowIndex).Value)
                TXTNARR.Text = GRIDISSUE.Item(GISSNARR.Index, e.RowIndex).Value

                TempRowIssue = e.RowIndex
                CMBITEMNAME.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDISSUE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDISSUE.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDISSUE.RowCount > 0 Then

                'dont allow user if any of the grid line is in edit mode.....
                If GridDoubleClickIssue = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                'end of block

                GRIDISSUE.Rows.RemoveAt(GRIDISSUE.CurrentRow.Index)
                getsrno(GRIDISSUE)
                total()

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTNARR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTNARR.Validated
        Try
            If CMBTYPE.Text.Trim <> "" And CMBITEMNAME.Text.Trim <> "" And Val(TXTGROSS.Text.Trim) > 0 And Val(TXTPURITY.Text.Trim) > 0 And Val(TXTNETT.Text.Trim) > 0 Then
                If CMBTYPE.Text.Trim = "Issue" Then
                    FILLGRIDISSUEUE()
                Else
                    FILLGRIDJAMA()
                End If
            Else
                MsgBox("Enter Proper Details", MsgBoxStyle.Critical)
                Exit Sub
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub CALC()
        Try
            If Val(TXTPURITY.Text.Trim) > 0 And Val(TXTGROSS.Text.Trim) > 0 Then TXTNETT.Text = Format((Val(TXTGROSS.Text.Trim) * Val(TXTPURITY.Text.Trim)) / 100, "0.000")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTPURITY_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTPURITY.KeyPress
        numdotkeypress(e, TXTPURITY, Me)
    End Sub

    Private Sub TXTPURITY_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTPURITY.Validated
        Try
            CALC()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTGROSS_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTGROSS.KeyPress
        numdotkeypress(e, TXTGROSS, Me)
    End Sub

    Private Sub TXTGROSS_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTGROSS.Validated
        CALC()
    End Sub

    Private Sub TXTWASTAGE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTWASTAGE.KeyPress
        numdotkeypress(e, TXTWASTAGE, Me)
    End Sub

    Private Sub TXTLOSS_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTLOSS.KeyPress
        numdotkeypress(e, TXTLOSS, Me)
    End Sub

    Private Sub TXTLOSS_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTLOSS.Validated
        total()
    End Sub

    Private Sub CMDSETTLE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDSETTLE.Click
        Try
            If edit = True Then
                For i = 0 To 100
                    tempcol(i) = ""
                    tempval(i) = ""
                Next

                'IF ALREADY SETTLED THEN ASK FOR UNSETTLE ACCOUNT, THIS WILL BE USED WHEN WE NEED TO RECTIFY THE ACCCOUT
                If LBLCLOSED.Visible = False Then

                    If MsgBox("Wish to Settle Account?", MsgBoxStyle.YesNo) = vbNo Then Exit Sub
                    tempcol(0) = "FILLING_SETTLED"
                    tempval(0) = 1

                    modify("FILLING", tempcol, tempval, " AND FILLING_NO = " & TEMPFILLINGNO)
                    MsgBox("Account Settled")

                Else

                    If MsgBox("Wish to Un-Settle Account?", MsgBoxStyle.YesNo) = vbNo Then Exit Sub
                    tempcol(0) = "FILLING_SETTLED"
                    tempval(0) = 0

                    modify("FILLING", tempcol, tempval, " AND FILLING_NO = " & TEMPFILLINGNO)
                    MsgBox("Account Un-Settled")

                End If

                clear()

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class