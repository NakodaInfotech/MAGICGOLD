
Imports System.Data.OleDb
Imports System.IO

Public Class JournalVoucher

    Public EDIT As Boolean
    Public TEMPJVNO As Integer
    Dim GRIDDOUBLECLICK As Boolean = False

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Sub CALC()
        Try
            TXTNETTWT.Text = Format(Val(TXTGROSSWT.Text.Trim) - Val(TXTLESSWT.Text.Trim), "0.000")
            TXTFINEWT.Text = Format(Val(TXTNETTWT.Text.Trim) * ((Val(TXTPURITY.Text.Trim) + Val(TXTWASTAGE.Text.Trim)) / 100), "0.000")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub JournalVoucher_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try
            If (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                If errorvalid() = True Then
                    Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                    If tempmsg = vbYes Then cmdok_Click(sender, e)
                End If
                Me.Close()
            ElseIf e.KeyCode = Keys.Oemcomma Then
                'e.SuppressKeyPress = True
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

    Sub GETMAX_JV_NO()
        cmd = New OleDbCommand("select IIF(ISNULL(max(JV_NO)) = TRUE, 0,max(JV_NO)) + 1 from JOURNALMASTER", conn)
        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Open()
        dr = cmd.ExecuteReader
        If dr.HasRows Then
            dr.Read()
            TXTJVNO.Text = Val(dr(0).ToString)
        End If
        conn.Close()
        dr.Close()
    End Sub

    Sub CLEAR()

        tstxtbillno.Clear()
        TXTPRINTSRNO.Clear()
        CMBNAME.Text = ""
        JVDATE.Value = GLOBALDATE


        TXTSRNO.Text = 1
        CMBITEMCODE.Text = ""
        TXTITEMDESC.Clear()
        TXTPCS.Clear()
        TXTGROSSWT.Clear()
        TXTLESSWT.Clear()
        TXTNETTWT.Clear()
        TXTPURITY.Clear()
        TXTWASTAGE.Clear()
        TXTFINEWT.Clear()
        TXTAMOUNT.Clear()
        CMBCODE.Text = ""
        GRIDJV.RowCount = 0

        TXTTOTALPCS.Clear()
        TXTTOTALGROSSWT.Clear()
        TXTTOTALLESSWT.Clear()
        TXTTOTALNETTWT.Clear()
        TXTTOTALFINEWT.Clear()
        TXTTOTALAMT.Clear()
        lblamtbal.Text = 0
        lblfinebal.Text = 0

        TXTREMARKS.Clear()

        EP.Clear()

        GETMAX_JV_NO()

    End Sub

    Private Sub cmdclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        clear()
        edit = False
        TXTJVNO.Focus()
    End Sub

    Sub fillcmb()
        Try
            If CMBNAME.Text.Trim = "" Then fillname(Me, CMBNAME, "")
            If CMBCODE.Text.Trim = "" Then fillname(Me, CMBCODE, "")
            If CMBITEMCODE.Text.Trim = "" Then FILLITEMCODE(Me, CMBITEMCODE, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub JournalVoucher_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Cursor.Current = Cursors.WaitCursor
            fillcmb()
            clear()

            If edit = True Then
                Dim DT As New DataTable
                If conn.State = ConnectionState.Open Then conn.Close()
                conn.Open()
                cmd = New OleDbCommand(" SELECT JOURNALMASTER.JV_NO AS JVNO, JOURNALMASTER.JV_DATE AS JVDATE, ledgermaster.ledger_CODE AS NAME, JOURNALMASTER.JV_SRNO AS SRNO, ItemMaster.item_code AS ITEMCODE, JOURNALMASTER.JV_ITEMDESC AS ITEMDESC, JOURNALMASTER.JV_PCS AS PCS, JOURNALMASTER.JV_GROSSWT AS GROSSWT, JOURNALMASTER.JV_LESSWT AS LESSWT, JOURNALMASTER.JV_NETTWT AS NETTWT, JOURNALMASTER.JV_PURITY AS PURITY, JOURNALMASTER.JV_WASTAGE AS WASTAGE, JOURNALMASTER.JV_FINEWT AS FINEWT, JOURNALMASTER.JV_AMOUNT AS AMOUNT, TOLEDGERMASTER.ledger_code AS TONAME, JOURNALMASTER.JV_REMARKS AS REMARKS FROM ((JOURNALMASTER INNER JOIN ledgermaster ON JOURNALMASTER.JV_LEDGERID = ledgermaster.ledger_id) INNER JOIN ledgermaster AS TOLEDGERMASTER ON JOURNALMASTER.JV_TOLEDGERID = TOLEDGERMASTER.ledger_id) INNER JOIN ItemMaster ON JOURNALMASTER.JV_ITEMID = ItemMaster.item_id where JOURNALMASTER.JV_NO = " & TEMPJVNO, conn)
                da = New OleDbDataAdapter(cmd)
                da.Fill(dt)
                For Each DTROW As DataRow In DT.Rows
                    TXTJVNO.Text = TEMPJVNO
                    JVDATE.Value = Convert.ToDateTime(DTROW("JVDATE"))
                    CMBNAME.Text = DTROW("NAME")

                    lblfinebal.Text = GETBALANCEWT(CMBNAME.Text.Trim, JVDATE.Value.Date)
                    lblamtbal.Text = GETBALANCEAMT(CMBNAME.Text.Trim, JVDATE.Value.Date)

                    GRIDJV.Rows.Add(DTROW("SRNO"), DTROW("ITEMCODE"), DTROW("ITEMDESC"), Val(DTROW("PCS")), Format(Val(DTROW("GROSSWT")), "0.000"), Format(Val(DTROW("LESSWT")), "0.000"), Format(Val(DTROW("NETTWT")), "0.000"), Format(Val(DTROW("PURITY")), "0.00"), Format(Val(DTROW("WASTAGE")), "0.00"), Format(Val(DTROW("FINEWT")), "0.000"), Format(Val(DTROW("AMOUNT")), "0.00"), DTROW("TONAME"), Format(Val(GETBALANCEWT(DTROW("TONAME"), JVDATE.Value.Date)), "0.00"), Format(Val(GETBALANCEAMT(DTROW("TONAME"), JVDATE.Value.Date)), "0.00"))
                    TXTREMARKS.Text = DTROW("REMARKS")

                    conn.Close()
                    cmd.Dispose()
                Next
                TOTAL()
            End If

        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub TOTAL()
        Try
            TXTTOTALPCS.Clear()
            TXTTOTALGROSSWT.Clear()
            TXTTOTALLESSWT.Clear()
            TXTTOTALNETTWT.Clear()
            TXTTOTALFINEWT.Clear()
            TXTTOTALAMT.Clear()

            For Each ROW As DataGridViewRow In GRIDJV.Rows
                TXTTOTALPCS.Text = Format(Val(TXTTOTALPCS.Text.Trim) + Val(ROW.Cells(GPCS.Index).Value), "0")
                TXTTOTALGROSSWT.Text = Format(Val(TXTTOTALGROSSWT.Text.Trim) + Val(ROW.Cells(GGROSSWT.Index).Value), "0.000")
                TXTTOTALLESSWT.Text = Format(Val(TXTTOTALLESSWT.Text.Trim) + Val(ROW.Cells(GLESSWT.Index).Value), "0.000")
                TXTTOTALNETTWT.Text = Format(Val(TXTTOTALNETTWT.Text.Trim) + Val(ROW.Cells(GNETTWT.Index).Value), "0.000")
                TXTTOTALFINEWT.Text = Format(Val(TXTTOTALFINEWT.Text.Trim) + Val(ROW.Cells(GFINEWT.Index).Value), "0.000")
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
            If APPLYBLOCKDATE = True And JVDATE.Value.Date <= BLOCKEDDATE Then
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

            'DELETE DATA FROM JOURNALMASTER
            If EDIT = True Then
                cmd = New OleDbCommand("DELETE FROM JOURNALMASTER WHERE JV_NO = " & TEMPJVNO, conn)
                If conn.State = ConnectionState.Open Then conn.Close()
                conn.Open()
                cmd.ExecuteNonQuery()


                cmd = New OleDbCommand("DELETE FROM ACCOUNTMASTER WHERE ACCOUNT_VOUCHERID = " & TEMPJVNO & " AND ACCOUNT_TYPE ='JV'", conn)
                If conn.State = ConnectionState.Open Then conn.Close()
                conn.Open()
                cmd.ExecuteNonQuery()
                conn.Close()
            Else
                'IF MULTIPLE USERS ARE WORKING ON THE SAME FORM THEN WE NEED THIS
                GETMAX_JV_NO()
            End If


           

            For Each ROW As DataGridViewRow In GRIDJV.Rows


                tempcol(0) = "JV_NO"
                tempcol(1) = "JV_DATE"
                tempcol(2) = "JV_LEDGERID"
                tempcol(3) = "JV_TOTALPCS"
                tempcol(4) = "JV_TOTALGROSSWT"
                tempcol(5) = "JV_TOTALLESSWT"
                tempcol(6) = "JV_TOTALNETTWT"
                tempcol(7) = "JV_TOTALFINEWT"
                tempcol(8) = "JV_TOTALAMT"
                tempcol(9) = "JV_REMARKS"
                tempcol(10) = "JV_SRNO"
                tempcol(11) = "JV_ITEMID"
                tempcol(12) = "JV_ITEMDESC"
                tempcol(13) = "JV_PCS"
                tempcol(14) = "JV_GROSSWT"
                tempcol(15) = "JV_LESSWT"
                tempcol(16) = "JV_NETTWT"
                tempcol(17) = "JV_PURITY"
                tempcol(18) = "JV_WASTAGE"
                tempcol(19) = "JV_FINEWT"
                tempcol(20) = "JV_AMOUNT"
                tempcol(21) = "JV_TOLEDGERID"
                tempcol(22) = "JV_USERID"
                tempcol(23) = "JV_DEPARTMENTID"

                tempval(0) = Val(TXTJVNO.Text.Trim)
                tempval(1) = "'" & Format(JVDATE.Value, "dd/MM/yyyy") & "'"


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

                tempval(3) = Val(TXTTOTALPCS.Text.Trim)
                tempval(4) = Val(TXTTOTALGROSSWT.Text.Trim)
                tempval(5) = Val(TXTTOTALLESSWT.Text.Trim)
                tempval(6) = Val(TXTTOTALNETTWT.Text.Trim)
                tempval(7) = Val(TXTTOTALFINEWT.Text.Trim)
                tempval(8) = Val(TXTTOTALAMT.Text.Trim)
                tempval(9) = "'" & TXTREMARKS.Text.Trim & "'"


                tempval(10) = Val(ROW.Cells(GSRNO.Index).Value)

                'getting itemid
                tempcmd = New OleDbCommand("select item_id from itemmaster where item_code = '" & ROW.Cells(GITEMCODE.Index).Value & "'", tempconn)
                If tempconn.State = ConnectionState.Open Then tempconn.Close()
                tempconn.Open()
                tempdr = tempcmd.ExecuteReader
                If tempdr.HasRows Then
                    tempdr.Read()
                    tempval(11) = Val(tempdr(0))
                Else
                    tempval(11) = 0
                End If
                tempconn.Close()
                tempdr.Close()

                tempval(12) = "'" & ROW.Cells(GITEMDESC.Index).Value & "'"
                tempval(13) = Val(ROW.Cells(GPCS.Index).Value)
                tempval(14) = Format(Val(ROW.Cells(GGROSSWT.Index).Value), "0.000")
                tempval(15) = Format(Val(ROW.Cells(GLESSWT.Index).Value), "0.000")
                tempval(16) = Format(Val(ROW.Cells(GNETTWT.Index).Value), "0.000")
                tempval(17) = Format(Val(ROW.Cells(GMELTING.Index).Value), "0.00")
                tempval(18) = Format(Val(ROW.Cells(GWASTAGE.Index).Value), "0.00")
                tempval(19) = Format(Val(ROW.Cells(GFINEWT.Index).Value), "0.000")
                tempval(20) = Format(Val(ROW.Cells(GAMOUNT.Index).Value), "0.00")

                'getting TOLEDGERID
                tempcmd = New OleDbCommand("select LEDGER_id from LEDGERMASTER where LEDGER_code = '" & ROW.Cells(GCODE.Index).Value & "'", tempconn)
                If tempconn.State = ConnectionState.Open Then tempconn.Close()
                tempconn.Open()
                tempdr = tempcmd.ExecuteReader
                If tempdr.HasRows Then
                    tempdr.Read()
                    tempval(21) = Val(tempdr(0))
                Else
                    tempval(21) = 0
                End If
                tempconn.Close()
                tempdr.Close()

                tempval(22) = Val(USERID)
                tempval(23) = Val(USERDEPARTMENTID)

                insert("JOURNALMASTER", tempcol, tempval)





                'ADD IN ACCOUNTMASTER
                'FOR THE PARTY CODE IT WILL BE JAMA 
                'FOR THE PARTY CODE IN GRID IT WILL BE BALANCE (NAAME)
                'THERE WILL BE 2 POSTINGS FOR EACH ROW 1ST FOR JAMA AND 2ND FOR NAAME
                'clearing array
                For i = 1 To 25
                    tempcol(i) = ""
                    tempval(i) = ""
                Next

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
                tempcol(13) = "account_GROSSLESS"



                'POSTING FOR JAMA
                '****************
                tempval(0) = "'" & Format(JVDATE.Value, "dd/MM/yyyy") & "'"

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

                tempval(2) = Format(Val(ROW.Cells(GGROSSWT.Index).Value), "0.000")
                tempval(3) = Format(Val(ROW.Cells(GFINEWT.Index).Value), "0.000")
                tempval(4) = Format(Val(ROW.Cells(GAMOUNT.Index).Value), "0.00")
                tempval(5) = "'" & ROW.Cells(GITEMDESC.Index).Value & "'"
                tempval(6) = "'Jama'"
                tempval(7) = Val(TXTJVNO.Text.Trim)
                tempval(8) = "'JV'"
                tempval(9) = "'" & CMBNAME.Text.Trim & "'"
                tempval(10) = Val(Userid)
                tempval(11) = Val(USERDEPARTMENTID)
                tempval(12) = "''"  'PROCESSNAME
                tempval(13) = Format(Val(ROW.Cells(GNETTWT.Index).Value), "0.000")

                insert("accountmaster", tempcol, tempval)
                '******** END OF CODE FOR JAMA **********

                'POSTING FOR NAAME
                '****************
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

                tempval(6) = "'Balance'"
                tempval(9) = "'" & ROW.Cells(GCODE.Index).Value & "'"
                tempval(10) = Val(Userid)
                tempval(11) = Val(USERDEPARTMENTID)
                tempval(12) = "''"  'PROCESSNAME
                tempval(13) = Format(Val(ROW.Cells(GNETTWT.Index).Value), "0.000")

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
                OBJSELECT.STRSEARCH = ""
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
                OBJSELECT.STRSEARCH = ""
                OBJSELECT.ShowDialog()
                CMBCODE.Text = OBJSELECT.TEMPCODE
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCODE_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBCODE.Validated
        Try
            If CMBITEMCODE.Text.Trim <> "" And CMBCODE.Text.Trim <> CMBNAME.Text.Trim And (Val(TXTFINEWT.Text.Trim) > 0 Or Val(TXTAMOUNT.Text.Trim) > 0 Or Val(TXTGROSSWT.Text.Trim) > 0) And CMBCODE.Text.Trim <> "" Then
                FILLGRID()
            Else
                MsgBox("Enter Proper Details")
                Exit Sub
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
            If griddoubleclick = False Then
                GRIDJV.Rows.Add(Val(TXTSRNO.Text.Trim), CMBITEMCODE.Text.Trim, TXTITEMDESC.Text.Trim, Format(Val(TXTPCS.Text.Trim), "0"), Format(Val(TXTGROSSWT.Text.Trim), "0.000"), Format(Val(TXTLESSWT.Text.Trim), "0.000"), Format(Val(TXTNETTWT.Text.Trim), "0.000"), Format(Val(TXTPURITY.Text.Trim), "0.00"), Format(Val(TXTWASTAGE.Text.Trim), "0.00"), Format(Val(TXTFINEWT.Text.Trim), "0.000"), Format(Val(TXTAMOUNT.Text.Trim), "0.00"), CMBCODE.Text.Trim, Format(Val(GETBALANCEWT(CMBCODE.Text.Trim, JVDATE.Value.Date)), "0.00"), Format(Val(GETBALANCEAMT(CMBCODE.Text.Trim, JVDATE.Value.Date)), "0.00"))
                GETSRNO(GRIDJV)

            ElseIf GRIDDOUBLECLICK = True Then
                GRIDJV.Item(GSRNO.Index, temprow).Value = Val(TXTSRNO.Text.Trim)
                GRIDJV.Item(GITEMCODE.Index, temprow).Value = CMBITEMCODE.Text.Trim
                GRIDJV.Item(GITEMDESC.Index, temprow).Value = TXTITEMDESC.Text.Trim
                GRIDJV.Item(GPCS.Index, temprow).Value = Format(Val(TXTPCS.Text.Trim), "0")
                GRIDJV.Item(GGROSSWT.Index, temprow).Value = Format(Val(TXTGROSSWT.Text.Trim), "0.000")
                GRIDJV.Item(GLESSWT.Index, temprow).Value = Format(Val(TXTLESSWT.Text.Trim), "0.000")
                GRIDJV.Item(GNETTWT.Index, temprow).Value = Format(Val(TXTNETTWT.Text.Trim), "0.000")
                GRIDJV.Item(GMELTING.Index, temprow).Value = Format(Val(TXTPURITY.Text.Trim), "0.00")
                GRIDJV.Item(GWASTAGE.Index, temprow).Value = Format(Val(TXTWASTAGE.Text.Trim), "0.00")
                GRIDJV.Item(GFINEWT.Index, temprow).Value = Format(Val(TXTFINEWT.Text.Trim), "0.000")
                GRIDJV.Item(GAMOUNT.Index, temprow).Value = Format(Val(TXTAMOUNT.Text.Trim), "0.00")
                GRIDJV.Item(GCODE.Index, temprow).Value = CMBCODE.Text.Trim

                GRIDDOUBLECLICK = False
            End If

            GRIDJV.FirstDisplayedScrollingRowIndex = GRIDJV.RowCount - 1

            TXTSRNO.Clear()
            CMBITEMCODE.Text = ""
            TXTITEMDESC.Clear()
            TXTPCS.Clear()
            TXTGROSSWT.Clear()
            TXTLESSWT.Clear()
            TXTNETTWT.Clear()
            TXTPURITY.Clear()
            TXTWASTAGE.Clear()
            TXTFINEWT.Clear()
            TXTAMOUNT.Clear()
            CMBCODE.Text = ""
            TOTAL()
            CMBITEMCODE.Focus()

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

    Private Sub CMBITEMCODE_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBITEMCODE.Enter
        Try
            If CMBITEMCODE.Text.Trim = "" Then If CMBITEMCODE.Text.Trim = "" Then FILLITEMCODE(Me, CMBITEMCODE, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBITEMCODE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBITEMCODE.KeyDown
        Try
            If e.KeyCode = Keys.F1 And e.Alt = True Then
                Dim OBJITEM As New SelectItem
                OBJITEM.ShowDialog()
                CMBITEMCODE.Text = OBJITEM.TEMPCODE
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBITEMCODE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBITEMCODE.Validating
        Try
            If CMBITEMCODE.Text.Trim <> "" Then ITEMVALIDATE(CMBITEMCODE, e, Me, "", TXTITEMDESC)
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

        If GRIDJV.RowCount = 0 Then
            EP.SetError(CMBCODE, " Enter Details below")
            bln = False
        End If

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
                    'deleting data from JOURNALMASTER
                    cmd = New OleDbCommand("delete from JOURNALMASTER where JV_NO = " & TEMPJVNO, conn)
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Open()
                    cmd.ExecuteNonQuery()

                    cmd = New OleDbCommand("DELETE FROM ACCOUNTMASTER where ACCOUNT_VOUCHERID = " & TEMPJVNO & " AND ACCOUNT_TYPE = 'JV'", conn)
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
            Dim OBJJV As New JournalVoucherDetails
            OBJJV.MdiParent = MDIMain
            OBJJV.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SaveToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripButton.Click
        Call cmdok_Click(sender, e)
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try
            If EDIT = True Then PRINTREPORT(TEMPJVNO)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub toolprevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolprevious.Click
        Try
            TEMPJVNO = Val(TXTJVNO.Text) - 1
            If TEMPJVNO > 0 Then
                EDIT = True
                JournalVoucher_Load(sender, e)
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
            TEMPJVNO = Val(TXTJVNO.Text) + 1
            GETMAX_JV_NO()
            clear()
            If Val(TXTJVNO.Text) - 1 >= TEMPJVNO Then
                EDIT = True
                JournalVoucher_Load(sender, e)
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
                OBJVOUCHER.WHERECLAUSE = " {JOURNALMASTER.JV_NO} = " & Val(TEMPJVNO)
            Else
                OBJVOUCHER.WHERECLAUSE = " {JOURNALMASTER.JV_NO} = " & Val(TXTJVNO.Text.Trim)
            End If

            If TXTPRINTSRNO.Text.Trim <> "" Then OBJVOUCHER.WHERECLAUSE = OBJVOUCHER.WHERECLAUSE & " AND {JOURNALMASTER.JV_SRNO} IN [" & TXTPRINTSRNO.Text.Trim & "]"

            OBJVOUCHER.FRMSTRING = "JOURNAL"
            OBJVOUCHER.MdiParent = MDIMain
            OBJVOUCHER.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTGROSSWT_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTGROSSWT.KeyPress, TXTPURITY.KeyPress, TXTFINEWT.KeyPress, TXTWASTAGE.KeyPress, TXTAMOUNT.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub

    Private Sub TXTPCS_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTPCS.KeyPress
        numkeypress(e, sender, Me)
    End Sub

    Private Sub TXTGROSSWT_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTGROSSWT.Validated, TXTPURITY.Validated, TXTWASTAGE.Validated, TXTLESSWT.Validated
        CALC()
    End Sub

    Private Sub GRIDJV_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDJV.CellDoubleClick
        Try
            If e.RowIndex >= 0 And GRIDJV.Item(GSRNO.Index, e.RowIndex).Value <> Nothing Then

                GRIDDOUBLECLICK = True
                TXTSRNO.Text = Val(GRIDJV.Item(GSRNO.Index, e.RowIndex).Value)
                CMBITEMCODE.Text = GRIDJV.Item(GITEMCODE.Index, e.RowIndex).Value.ToString
                TXTITEMDESC.Text = GRIDJV.Item(GITEMDESC.Index, e.RowIndex).Value.ToString
                TXTPCS.Text = Val(GRIDJV.Item(GPCS.Index, e.RowIndex).Value)
                TXTGROSSWT.Text = Val(GRIDJV.Item(GGROSSWT.Index, e.RowIndex).Value)
                TXTLESSWT.Text = Val(GRIDJV.Item(GLESSWT.Index, e.RowIndex).Value)
                TXTNETTWT.Text = Val(GRIDJV.Item(GNETTWT.Index, e.RowIndex).Value)
                TXTPURITY.Text = Val(GRIDJV.Item(GMELTING.Index, e.RowIndex).Value)
                TXTWASTAGE.Text = Val(GRIDJV.Item(GWASTAGE.Index, e.RowIndex).Value)
                TXTFINEWT.Text = Val(GRIDJV.Item(GFINEWT.Index, e.RowIndex).Value)
                TXTAMOUNT.Text = Val(GRIDJV.Item(GAMOUNT.Index, e.RowIndex).Value)
                CMBCODE.Text = GRIDJV.Item(GCODE.Index, e.RowIndex).Value.ToString

                temprow = e.RowIndex
                CMBITEMCODE.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDJV_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDJV.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDJV.RowCount > 0 Then
                If GRIDDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                'end of block
                GRIDJV.Rows.RemoveAt(GRIDJV.CurrentRow.Index)
                GETSRNO(GRIDJV)
                TOTAL()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNAME_Validated(sender As Object, e As EventArgs) Handles CMBNAME.Validated
        Try
            lblfinebal.Text = GETBALANCEWT(CMBNAME.Text.Trim, JVDATE.Value.Date)
            lblamtbal.Text = GETBALANCEAMT(CMBNAME.Text.Trim, JVDATE.Value.Date)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class