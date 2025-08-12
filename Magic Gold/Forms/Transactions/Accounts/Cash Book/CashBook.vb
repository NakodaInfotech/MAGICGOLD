
Imports System.Data.OleDb
Imports System.IO

Public Class CashBook

    Public EDIT As Boolean
    Public TEMPCASHNO As Integer, FRMSTRING As String
    Dim GRIDDOUBLECLICK As Boolean = False

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub CashBank_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try
            If (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                If errorvalid() = True Then
                    Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                    If tempmsg = vbYes Then cmdok_Click(sender, e)
                End If
                Me.Close()
            ElseIf e.KeyCode = Keys.OemQuotes Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.Left Then       'for DELETE
                Call toolprevious_Click(sender, e)
            ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.Right Then       'for DELETE
                Call toolnext_Click(sender, e)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub GETMAX_CASH_NO()
        cmd = New OleDbCommand("select IIF(ISNULL(max(CASH_NO)) = TRUE, 0,max(CASH_NO)) + 1 from CASHENTRY", conn)
        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Open()
        dr = cmd.ExecuteReader
        If dr.HasRows Then
            dr.Read()
            TXTENTRYNO.Text = Val(dr(0).ToString)
        End If
        conn.Close()
        dr.Close()
    End Sub

    Sub clear()

        tstxtbillno.Clear()
        CMBNAME.Text = ""
        ENTRYDATE.Value = GLOBALDATE

        TXTSRNO.Text = 1
        CMBCODE.Text = ""
        TXTNARR.Clear()
        TXTAMOUNT.Clear()
        GRIDCASH.RowCount = 0

        TXTTOTALAMT.Clear()
        lblamtbal.Text = 0
        lblfinebal.Text = 0
        LBLGRIDBALAMT.Text = 0
        LBLGRIDBALFINEWT.Text = 0


        EP.Clear()

        GETMAX_CASH_NO()

    End Sub

    Private Sub cmdclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        clear()
        EDIT = False
        ENTRYDATE.Focus()
    End Sub

    Sub fillcmb()
        Try
            fillname(Me, CMBNAME, " AND (GROUPMASTER.GROUP_NAME = 'Sundry Debtors' OR GROUPMASTER.GROUP_NAME = 'Sundry Creditors' or GROUPMASTER.GROUP_NAME = 'Bank A/C' OR GROUPMASTER.GROUP_NAME = 'Bank OD A/C' OR GROUPMASTER.GROUP_NAME = 'Cash In Hand')")
            fillname(Me, CMBCODE, " AND (GROUPMASTER.GROUP_NAME = 'Sundry Debtors' OR GROUPMASTER.GROUP_NAME = 'Sundry Creditors' or GROUPMASTER.GROUP_NAME = 'Bank A/C' OR GROUPMASTER.GROUP_NAME = 'Bank OD A/C' OR GROUPMASTER.GROUP_NAME = 'Cash In Hand')")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CashBank_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Cursor.Current = Cursors.WaitCursor
            fillcmb()
            clear()


            If EDIT = True Then
                Dim DT As New DataTable
                If conn.State = ConnectionState.Open Then conn.Close()
                conn.Open()
                cmd = New OleDbCommand(" SELECT CASHENTRY.CASH_NO AS CASHNO, CASHENTRY.CASH_DATE AS CASHDATE, CASHENTRY.CASH_TYPE AS TYPE, ledgermaster.ledger_code AS NAME, CASHENTRY.CASH_SRNO AS SRNO, TOLEDGERMASTER.ledger_code AS TONAME, CASHENTRY.CASH_NARR AS NARR, CASHENTRY.CASH_AMOUNT AS AMOUNT FROM (CASHENTRY INNER JOIN ledgermaster ON CASHENTRY.CASH_LEDGERID = ledgermaster.ledger_id) INNER JOIN ledgermaster AS TOLEDGERMASTER ON CASHENTRY.CASH_TOLEDGERID = TOLEDGERMASTER.ledger_id where CASHENTRY.CASH_NO = " & TEMPCASHNO, conn)
                da = New OleDbDataAdapter(cmd)
                da.Fill(DT)
                For Each DTROW As DataRow In DT.Rows
                    TXTENTRYNO.Text = TEMPCASHNO
                    FRMSTRING = DTROW("TYPE")
                    fillcmb()

                    ENTRYDATE.Value = Convert.ToDateTime(DTROW("CASHDATE"))
                    CMBNAME.Text = DTROW("NAME")

                    lblfinebal.Text = GETBALANCEWT(CMBNAME.Text.Trim, ENTRYDATE.Value.Date)
                    lblamtbal.Text = GETBALANCEAMT(CMBNAME.Text.Trim, ENTRYDATE.Value.Date)

                    GRIDCASH.Rows.Add(DTROW("SRNO"), DTROW("TONAME"), DTROW("NARR"), Format(Val(DTROW("AMOUNT")), "0.00"), Format(Val(GETBALANCEWT(DTROW("TONAME"), ENTRYDATE.Value.Date)), "0.00"), Format(Val(GETBALANCEAMT(DTROW("TONAME"), ENTRYDATE.Value.Date)), "0.00"))

                    conn.Close()
                    cmd.Dispose()
                Next
                TOTAL()
            End If

            'KEEP THIS HERE ONLY DONE BY GULKIT
            If FRMSTRING = "CASHREC" Then Me.Text = "Receipt" Else Me.Text = "Issue"

        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub TOTAL()
        Try
            GBALFINEWT.DefaultCellStyle.BackColor = Color.Linen
            GBALAMOUNT.DefaultCellStyle.BackColor = Color.Linen
            TXTTOTALAMT.Clear()
            For Each ROW As DataGridViewRow In GRIDCASH.Rows
                TXTTOTALAMT.Text = Format(Val(TXTTOTALAMT.Text.Trim) + Val(ROW.Cells(GAMOUNT.Index).Value), "0.00")
            Next
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

            'IF BACK DATED ENTRY IS TO BE SAVED THEN CHECK ENTRYPASSWORD
            If APPLYBLOCKDATE = True And ENTRYDATE.Value.Date <= BLOCKEDDATE Then
                Dim OBJPASS As New PasswordEntry
                OBJPASS.ShowDialog()
                If ENTRYPASSWORD <> OBJPASS.TXTDATERETYPE.Text.Trim Then
                    MsgBox("Invaid Password", MsgBoxStyle.Critical)
                    Exit Sub
                End If
            End If

            For i = 0 To 100
                tempcol(i) = ""
                tempval(i) = ""
            Next

            'DELETE DATA FROM CASHENTRY
            If EDIT = True Then
                cmd = New OleDbCommand("DELETE FROM CASHENTRY WHERE CASH_NO = " & TEMPCASHNO, conn)
                If conn.State = ConnectionState.Open Then conn.Close()
                conn.Open()
                cmd.ExecuteNonQuery()


                cmd = New OleDbCommand("DELETE FROM ACCOUNTMASTER WHERE ACCOUNT_VOUCHERID = " & TEMPCASHNO & " AND ACCOUNT_TYPE ='CASH'", conn)
                If conn.State = ConnectionState.Open Then conn.Close()
                conn.Open()
                cmd.ExecuteNonQuery()
                conn.Close()
            Else
                'IF MULTIPLE USERS ARE WORKING ON THE SAME FORM THEN WE NEED THIS
                GETMAX_CASH_NO()
            End If


            For Each ROW As DataGridViewRow In GRIDCASH.Rows

                For i = 0 To 20
                    tempcol(i) = ""
                    tempval(i) = ""
                Next

                tempcol(0) = "CASH_NO"
                tempcol(1) = "CASH_DATE"
                tempcol(2) = "CASH_LEDGERID"
                tempcol(3) = "CASH_TOTALAMT"
                tempcol(4) = "CASH_SRNO"
                tempcol(5) = "CASH_TOLEDGERID"
                tempcol(6) = "CASH_NARR"
                tempcol(7) = "CASH_AMOUNT"
                tempcol(8) = "CASH_TYPE"
                tempcol(9) = "CASH_USERID"
                tempcol(10) = "CASH_DEPARTMENTID"

                tempval(0) = Val(TXTENTRYNO.Text.Trim)
                tempval(1) = "'" & Format(ENTRYDATE.Value, "dd/MM/yyyy") & "'"


                'getting LEDGERID
                tempcmd = New OleDbCommand("select LEDGER_id from LEDGERMASTER where LEDGER_CODE = '" & CMBNAME.Text.Trim & "'", tempconn)
                If tempconn.State = ConnectionState.Open Then tempconn.Close()
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

                tempval(3) = Val(TXTTOTALAMT.Text.Trim)
                tempval(4) = Val(ROW.Cells(GSRNO.Index).Value)

                'getting TOLEDGERID
                tempcmd = New OleDbCommand("select LEDGER_id from LEDGERMASTER where LEDGER_CODE = '" & ROW.Cells(GCODE.Index).Value & "'", tempconn)
                If tempconn.State = ConnectionState.Open Then tempconn.Close()
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

                tempval(6) = "'" & ROW.Cells(GNARR.Index).Value & "'"
                tempval(7) = Val(ROW.Cells(GAMOUNT.Index).Value)
                tempval(8) = "'" & FRMSTRING & "'"
                tempval(9) = Val(USERID)
                tempval(10) = Val(USERDEPARTMENTID)


                insert("CASHENTRY", tempcol, tempval)



                'ADD IN ACCOUNTMASTER
                tempcol(0) = "ACCOUNT_DATE"
                tempcol(1) = "ACCOUNT_LEDGERID"
                tempcol(2) = "ACCOUNT_GROSSWT"
                tempcol(3) = "ACCOUNT_NETTWT"
                tempcol(4) = "ACCOUNT_AMOUNT"
                tempcol(5) = "ACCOUNT_NARRATION"
                tempcol(6) = "account_balorjamaorpaid"
                tempcol(7) = "account_voucherid"
                tempcol(8) = "account_type"
                tempcol(9) = "account_ledgercode"
                tempcol(10) = "account_USERID"
                tempcol(11) = "account_DEPARTMENTID"
                tempcol(12) = "account_PROCESS"
                tempcol(13) = "account_ITEMDESC"



                'IF CASHREC THEN
                '   CASH NAAME
                '   GRIDPARTY JAMA
                'ELSEIF CASHISSUE THEN
                '   CASH JAMA
                '   GRIDPARTY NAAME
                'POSTING FOR JAMA
                '****************
                tempval(0) = "'" & Format(ENTRYDATE.Value, "dd/MM/yyyy") & "'"

                'getting LEDGERID
                tempcmd = New OleDbCommand("select LEDGER_id from LEDGERMASTER where LEDGER_CODE = '" & CMBNAME.Text.Trim & "'", tempconn)
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

                tempval(2) = 0
                tempval(3) = 0
                tempval(4) = Format(Val(ROW.Cells(GAMOUNT.Index).Value), "0.00")
                tempval(5) = "'" & ROW.Cells(GNARR.Index).Value & "'"
                If FRMSTRING = "CASHREC" Then tempval(6) = "'Balance'" Else tempval(6) = "'Jama'"
                tempval(7) = Val(TXTENTRYNO.Text.Trim)
                tempval(8) = "'CASH'"
                tempval(9) = "'" & CMBNAME.Text.Trim & "'"
                tempval(10) = Val(USERID)
                tempval(11) = Val(USERDEPARTMENTID)
                tempval(12) = "''"  'PROCESSNAME
                tempval(13) = "'" & ROW.Cells(GCODE.Index).Value & "'"

                insert("accountmaster", tempcol, tempval)
                '******** END OF CODE FOR JAMA **********



                'POSTING FOR NAAME
                '****************
                tempval(0) = "'" & Format(ENTRYDATE.Value, "dd/MM/yyyy") & "'"

                'getting LEDGERID
                tempcmd = New OleDbCommand("select LEDGER_id from LEDGERMASTER where LEDGER_CODE = '" & ROW.Cells(GCODE.Index).Value & "'", tempconn)
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

                tempval(2) = 0
                tempval(3) = 0
                tempval(4) = Format(Val(ROW.Cells(GAMOUNT.Index).Value), "0.00")
                tempval(5) = "'" & ROW.Cells(GNARR.Index).Value & "'"
                If FRMSTRING = "CASHREC" Then tempval(6) = "'Jama'" Else tempval(6) = "'Balance'"
                tempval(7) = Val(TXTENTRYNO.Text.Trim)
                tempval(8) = "'CASH'"
                tempval(9) = "'" & ROW.Cells(GCODE.Index).Value & "'"
                tempval(10) = Val(Userid)
                tempval(11) = Val(USERDEPARTMENTID)
                tempval(12) = "''"  'PROCESSNAME
                tempval(13) = "'" & ROW.Cells(GCODE.Index).Value & "'"

                insert("accountmaster", tempcol, tempval)
                '******** END OF CODE FOR JAMA **********
            Next

            EDIT = False
            clear()
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub CMBNAME_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBNAME.Enter
        Try
            If CMBNAME.Text.Trim = "" Then fillname(Me, CMBNAME, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNAME_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBNAME.KeyDown
        Try
            If e.KeyCode = Keys.F1 And e.Alt = True Then
                Dim OBJSELECT As New SelectLedger
                If FRMSTRING = "CASHREC" Then
                    OBJSELECT.STRSEARCH = ""
                ElseIf FRMSTRING = "CASHISSUE" Then
                    OBJSELECT.STRSEARCH = ""
                End If
                OBJSELECT.ShowDialog()
                CMBNAME.Text = OBJSELECT.TEMPCODE
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNAME_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBNAME.Validating
        Try
            If CMBNAME.Text.Trim <> "" Then namevalidate(CMBNAME, e, Me, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCODE_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBCODE.Enter
        Try
            If CMBCODE.Text.Trim = "" Then fillname(Me, CMBCODE, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCODE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBCODE.KeyDown
        Try
            If e.KeyCode = Keys.F1 And e.Alt = True Then
                Dim OBJSELECT As New SelectLedger
                If FRMSTRING = "CASHREC" Then
                    OBJSELECT.STRSEARCH = ""
                ElseIf FRMSTRING = "CASHISSUE" Then
                    OBJSELECT.STRSEARCH = ""
                End If
                OBJSELECT.ShowDialog()
                CMBCODE.Text = OBJSELECT.TEMPCODE
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub GETSRNO(ByRef grid As System.Windows.Forms.DataGridView)
        Try
            For Each row As DataGridViewRow In grid.Rows
                row.Cells(GSRNO.Index).Value = row.Index + 1
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLGRID()
        Try
            If GRIDDOUBLECLICK = False Then
                GRIDCASH.Rows.Add(Val(TXTSRNO.Text.Trim), CMBCODE.Text.Trim, TXTNARR.Text.Trim, Format(Val(TXTAMOUNT.Text.Trim), "0.00"), Format(Val(GETBALANCEWT(CMBCODE.Text.Trim, ENTRYDATE.Value.Date)), "0.00"), Format(Val(GETBALANCEAMT(CMBCODE.Text.Trim, ENTRYDATE.Value.Date)), "0.00"))
                GETSRNO(GRIDCASH)

            ElseIf GRIDDOUBLECLICK = True Then
                GRIDCASH.Item(GSRNO.Index, temprow).Value = Val(TXTSRNO.Text.Trim)
                GRIDCASH.Item(GCODE.Index, temprow).Value = CMBCODE.Text.Trim
                GRIDCASH.Item(GNARR.Index, temprow).Value = TXTNARR.Text.Trim
                GRIDCASH.Item(GAMOUNT.Index, temprow).Value = Format(Val(TXTAMOUNT.Text.Trim), "0.00")

                GRIDDOUBLECLICK = False
            End If

            GRIDCASH.FirstDisplayedScrollingRowIndex = GRIDCASH.RowCount - 1

            TXTSRNO.Clear()
            CMBCODE.Text = ""
            TXTNARR.Clear()
            TXTAMOUNT.Clear()
            CMBCODE.Focus()
            TOTAL()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCODE_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBCODE.Validated
        Try
            If CMBCODE.Text.Trim = "" Then cmdok.Focus()
            If CMBCODE.Text.Trim <> "" Then

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCODE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBCODE.Validating
        Try
            If CMBCODE.Text.Trim <> "" Then namevalidate(CMBCODE, e, Me, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True

        If CMBNAME.Text.Trim.Length = 0 Then
            EP.SetError(CMBCODE, " Please Fill Party Name ")
            bln = False
        End If

        If GRIDCASH.RowCount = 0 Then
            EP.SetError(CMBCODE, " Enter Details below")
            bln = False
        End If

        'THIS IS DONE TO STOP DUPLICATE ENTRIES IF ANY USER IS USING THE SAME FORM
        If EDIT = False Then GETMAX_CASH_NO()
        Return bln
    End Function

    Private Sub tooldelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripdelete.Click
        Try
            Call cmddelete_Click(sender, e)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddelete.Click
        Try
            If EDIT = True Then

                tempmsg = MsgBox("Delete Entry ?", MsgBoxStyle.YesNo)
                If tempmsg = vbYes Then
                    'deleting data from CASHENTRY
                    cmd = New OleDbCommand("delete from CASHENTRY where CASH_NO = " & TEMPCASHNO, conn)
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Open()
                    cmd.ExecuteNonQuery()

                    cmd = New OleDbCommand("DELETE FROM ACCOUNTMASTER where ACCOUNT_VOUCHERID = " & TEMPCASHNO & " AND ACCOUNT_TYPE = 'CASH'", conn)
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Open()
                    cmd.ExecuteNonQuery()

                    MsgBox("Entry Deleted")
                    clear()
                    EDIT = False
                End If
            Else
                MsgBox("Delete is only in Edit Mode")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub OpenToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripButton.Click
        Try
            Dim OBJCASH As New CashBookDetails
            OBJCASH.MdiParent = MDIMain
            OBJCASH.FRMSTRING = FRMSTRING
            OBJCASH.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SaveToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripButton.Click
        Call cmdok_Click(sender, e)
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try
            If EDIT = True Then PRINTREPORT(TEMPCASHNO)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub toolprevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolprevious.Click
        Try
            TEMPCASHNO = Val(TXTENTRYNO.Text) - 1
            If TEMPCASHNO > 0 Then
                EDIT = True
                CashBank_Load(sender, e)
            Else
                clear()
                EDIT = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub toolnext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolnext.Click
        Try
            TEMPCASHNO = Val(TXTENTRYNO.Text) + 1
            GETMAX_CASH_NO()
            clear()
            If Val(TXTENTRYNO.Text) - 1 >= TEMPCASHNO Then
                EDIT = True
                CashBank_Load(sender, e)
            Else
                clear()
                EDIT = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub PRINTREPORT(ByVal PONO As Integer)
        Try
            Dim OBJVOUCHER As New VoucherDesign
            If EDIT = True Then
                OBJVOUCHER.WHERECLAUSE = " {CASHENTRY.CASH_NO} = " & Val(TEMPCASHNO)
            Else
                OBJVOUCHER.WHERECLAUSE = " {CASHENTRY.CASH_NO} = " & Val(TXTENTRYNO.Text.Trim)
            End If
            OBJVOUCHER.FRMSTRING = "CASH"
            OBJVOUCHER.MdiParent = MDIMain
            OBJVOUCHER.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDCASH_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDCASH.CellDoubleClick
        Try
            If e.RowIndex >= 0 And GRIDCASH.Item(GSRNO.Index, e.RowIndex).Value <> Nothing Then

                GRIDDOUBLECLICK = True
                TXTSRNO.Text = Val(GRIDCASH.Item(GSRNO.Index, e.RowIndex).Value)
                CMBCODE.Text = GRIDCASH.Item(GCODE.Index, e.RowIndex).Value.ToString
                TXTNARR.Text = GRIDCASH.Item(GNARR.Index, e.RowIndex).Value.ToString
                TXTAMOUNT.Text = Val(GRIDCASH.Item(GAMOUNT.Index, e.RowIndex).Value)

                temprow = e.RowIndex
                CMBCODE.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTAMOUNT_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTAMOUNT.Validated
        Try
            If CMBCODE.Text.Trim <> CMBNAME.Text.Trim And Val(TXTAMOUNT.Text.Trim) > 0 And CMBCODE.Text.Trim <> "" Then
                FILLGRID()
            Else
                MsgBox("Enter Proper Details")
                Exit Sub
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNAME_Validated(sender As Object, e As EventArgs) Handles CMBNAME.Validated
        Try
            If CMBNAME.Text.Trim = "" Then Exit Sub
            LBLGRIDBALFINEWT.Text = GETBALANCEWT(CMBNAME.Text.Trim, ENTRYDATE.Value.Date)
            LBLGRIDBALAMT.Text = GETBALANCEAMT(CMBNAME.Text.Trim, ENTRYDATE.Value.Date)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDCASH_KeyDown(sender As Object, e As KeyEventArgs) Handles GRIDCASH.KeyDown
        Try
            If e.KeyCode = Keys.Delete Then
                If GRIDDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If

                GRIDCASH.Rows.RemoveAt(GRIDCASH.CurrentRow.Index)
                TOTAL()
                GETSRNO(GRIDCASH)
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class