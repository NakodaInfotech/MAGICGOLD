
Imports System.Data.OleDb

Public Class Salary

    Public EDIT As Boolean
    Public TEMPSALNO As Integer
    Dim GRIDDOUBLECLICK As Boolean = False

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub Salary_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                If errorvalid() = True Then
                    Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                    If tempmsg = vbYes Then cmdok_Click(sender, e)
                End If
                Me.Close()
            ElseIf e.KeyCode = Keys.Oemcomma Then
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

    Private Sub Salary_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Cursor.Current = Cursors.WaitCursor
            fillcmb()
            clear()


            If EDIT = True Then
                Dim DT As New DataTable
                If conn.State = ConnectionState.Open Then conn.Close()
                conn.Open()
                cmd = New OleDbCommand(" SELECT SALARYENTRY.SAL_NO AS SALNO, SALARYENTRY.SAL_DATE AS SALDATE, SALARYENTRY.SAL_SRNO AS SRNO, ledgermaster.ledger_CODE AS TONAME, SALARYENTRY.SAL_SALARY AS SALARY, SALARYENTRY.SAL_FROMDATE AS FROMDATE, SALARYENTRY.SAL_TODATE AS TODATE, SALARYENTRY.SAL_DAYS AS DAYS,  SALARYENTRY.SAL_ABSENT AS ABSENT, SALARYENTRY.SAL_NIGHTS AS NIGHTS, IIF(ISNULL(SALARYENTRY.SAL_OT) = TRUE,0, SALARYENTRY.SAL_OT) AS OT, IIF(ISNULL(SALARYENTRY.SAL_HOURRATE) = TRUE,0, SALARYENTRY.SAL_HOURRATE) AS HOURRATE, IIF(ISNULL(SALARYENTRY.SAL_HOURS) = TRUE,0, SALARYENTRY.SAL_HOURS) AS HOURS, SALARYENTRY.SAL_GROSSAMT AS GROSSAMT,    SALARYENTRY.SAL_DEDUCTION AS DEDUCTION, SALARYENTRY.SAL_AMOUNT AS AMOUNT, SALARYENTRY.SAL_CASH AS CASH, SALARYENTRY.SAL_NARR AS NARR FROM SALARYENTRY INNER JOIN ledgermaster ON SALARYENTRY.SAL_TOLEDGERID = ledgermaster.ledger_id  where SALARYENTRY.SAL_NO = " & TEMPSALNO, conn)
                da = New OleDbDataAdapter(cmd)
                da.Fill(DT)
                For Each DTROW As DataRow In DT.Rows
                    TXTENTRYNO.Text = TEMPSALNO
                    TXTDAYS.Text = Val(DTROW("DAYS"))
                    TXTNARR.Text = DTROW("NARR")
                    ENTRYDATE.Value = Convert.ToDateTime(DTROW("SALDATE"))
                    GRIDSALARY.Rows.Add(DTROW("SRNO"), DTROW("TONAME"), Format(Val(DTROW("SALARY")), "0.00"), Format(Convert.ToDateTime(DTROW("FROMDATE")).Date, "dd/MM/yyyy"), Format(Convert.ToDateTime(DTROW("TODATE")).Date, "dd/MM/yyyy"), Format(Val(DTROW("DAYS")), "0"), Format(Val(DTROW("ABSENT")), "0"), Format(Val(DTROW("NIGHTS")), "0"), Format(Val(DTROW("OT")), "0"), Format(Val(DTROW("HOURRATE")), "0.00"), Format(Val(DTROW("HOURS")), "0.00"), Format(Val(DTROW("GROSSAMT")), "0.00"), Format(Val(DTROW("DEDUCTION")), "0.00"), Format(Val(DTROW("AMOUNT")), "0.00"), Format(Val(DTROW("CASH")), "0.00"), DTROW("NARR"))
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
            TXTTOTALGROSSAMT.Clear()
            TXTTOTALDEDUCTION.Clear()
            TXTTOTALAMT.Clear()
            TXTTOTALCASH.Clear()
            For Each ROW As DataGridViewRow In GRIDSALARY.Rows
                TXTTOTALGROSSAMT.Text = Format(Val(TXTTOTALGROSSAMT.Text.Trim) + Val(ROW.Cells(GGROSSAMT.Index).Value), "0.00")
                TXTTOTALDEDUCTION.Text = Format(Val(TXTTOTALDEDUCTION.Text.Trim) + Val(ROW.Cells(GDEDUCTION.Index).Value), "0.00")
                TXTTOTALAMT.Text = Format(Val(TXTTOTALAMT.Text.Trim) + Val(ROW.Cells(GAMOUNT.Index).Value), "0.00")
                TXTTOTALCASH.Text = Format(Val(TXTTOTALCASH.Text.Trim) + Val(ROW.Cells(GCASH.Index).Value), "0.00")
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

            'DELETE DATA FROM SALARYENTRY
            If EDIT = True Then
                cmd = New OleDbCommand("DELETE FROM SALARYENTRY WHERE SAL_NO = " & TEMPSALNO, conn)
                If conn.State = ConnectionState.Open Then conn.Close()
                conn.Open()
                cmd.ExecuteNonQuery()


                cmd = New OleDbCommand("DELETE FROM ACCOUNTMASTER WHERE ACCOUNT_VOUCHERID = " & TEMPSALNO & " AND ACCOUNT_TYPE ='SALARY'", conn)
                If conn.State = ConnectionState.Open Then conn.Close()
                conn.Open()
                cmd.ExecuteNonQuery()
                conn.Close()
            Else
                'IF MULTIPLE USERS ARE WORKING ON THE SAME FORM THEN WE NEED THIS
                GETMAX_SAL_NO()
            End If


            For Each ROW As DataGridViewRow In GRIDSALARY.Rows

                For i = 0 To 20
                    tempcol(i) = ""
                    tempval(i) = ""
                Next

                i = 0
                tempcol(I) = "SAL_NO"
                I += 1
                tempcol(I) = "SAL_DATE"
                I += 1
                tempcol(I) = "SAL_TOTALGROSSAMT"
                I += 1
                tempcol(I) = "SAL_TOTALDEDUCTION"
                I += 1
                tempcol(I) = "SAL_TOTALAMT"
                I += 1
                tempcol(I) = "SAL_TOTALCASH"
                I += 1
                tempcol(I) = "SAL_SRNO"
                I += 1
                tempcol(I) = "SAL_TOLEDGERID"
                I += 1
                tempcol(I) = "SAL_SALARY"
                I += 1
                tempcol(I) = "SAL_FROMDATE"
                I += 1
                tempcol(I) = "SAL_TODATE"
                I += 1
                tempcol(I) = "SAL_DAYS"
                I += 1
                tempcol(I) = "SAL_ABSENT"
                I += 1
                tempcol(I) = "SAL_NIGHTS"
                I += 1
                tempcol(I) = "SAL_OT"
                I += 1
                tempcol(I) = "SAL_HOURRATE"
                I += 1
                tempcol(I) = "SAL_HOURS"
                I += 1
                tempcol(I) = "SAL_GROSSAMT"
                I += 1
                tempcol(I) = "SAL_DEDUCTION"
                I += 1
                tempcol(I) = "SAL_AMOUNT"
                I += 1
                tempcol(I) = "SAL_CASH"
                I += 1
                tempcol(I) = "SAL_NARR"
                I += 1
                tempcol(I) = "SAL_USERID"
                I += 1
                tempcol(I) = "SAL_DEPARTMENTID"
                I += 1


                I = 0
                tempval(I) = Val(TXTENTRYNO.Text.Trim)
                I += 1
                tempval(I) = "'" & Format(ENTRYDATE.Value, "dd/MM/yyyy") & "'"
                I += 1
                tempval(I) = Val(TXTTOTALGROSSAMT.Text.Trim)
                I += 1
                tempval(I) = Val(TXTTOTALDEDUCTION.Text.Trim)
                I += 1
                tempval(I) = Val(TXTTOTALAMT.Text.Trim)
                I += 1
                tempval(I) = Val(TXTTOTALCASH.Text.Trim)
                I += 1

                tempval(I) = Val(ROW.Cells(GSRNO.Index).Value)
                I += 1

                'getting TOLEDGERID
                tempcmd = New OleDbCommand("select LEDGER_id from LEDGERMASTER where LEDGER_CODE = '" & ROW.Cells(GCODE.Index).Value & "'", tempconn)
                If tempconn.State = ConnectionState.Open Then tempconn.Close()
                tempconn.Open()
                tempdr = tempcmd.ExecuteReader
                If tempdr.HasRows Then
                    tempdr.Read()
                    tempval(I) = Val(tempdr(0))
                Else
                    tempval(I) = 0
                End If
                I += 1
                tempconn.Close()
                tempdr.Close()

                tempval(I) = Val(ROW.Cells(GSALARY.Index).Value)
                I += 1
                tempval(I) = "'" & Format(Convert.ToDateTime(ROW.Cells(GFROM.Index).Value).Date, "dd/MM/yyyy") & "'"
                I += 1
                tempval(I) = "'" & Format(Convert.ToDateTime(ROW.Cells(GTO.Index).Value).Date, "dd/MM/yyyy") & "'"
                I += 1
                tempval(I) = Val(ROW.Cells(GDAYS.Index).Value)
                I += 1
                tempval(I) = Val(ROW.Cells(GABSENT.Index).Value)
                I += 1
                tempval(I) = Val(ROW.Cells(GNIGHTS.Index).Value)
                I += 1
                tempval(I) = Val(ROW.Cells(GOT.Index).Value)
                I += 1
                tempval(I) = Val(ROW.Cells(GHOURRATE.Index).Value)
                I += 1
                tempval(I) = Val(ROW.Cells(GHOURS.Index).Value)
                I += 1
                tempval(I) = Val(ROW.Cells(GGROSSAMT.Index).Value)
                I += 1
                tempval(I) = Val(ROW.Cells(GDEDUCTION.Index).Value)
                I += 1
                tempval(I) = Val(ROW.Cells(GAMOUNT.Index).Value)
                I += 1
                tempval(I) = Val(ROW.Cells(GCASH.Index).Value)
                I += 1
                tempval(I) = "'" & ROW.Cells(GNARR.Index).Value & "'"
                I += 1
                tempval(I) = Val(USERID)
                I += 1
                tempval(I) = Val(USERDEPARTMENTID)
                I += 1

                insert("SALARYENTRY", tempcol, tempval)

                For i = 0 To 40
                    tempcol(i) = ""
                    tempval(i) = ""
                Next

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


                'THIS POSTING IS FOR SALARY, SALARY IS A FIXED ACCOUNT
                'SALARY NAAME
                'PARTY JAMA


                'POSTING FOR NAAME
                '****************
                tempval(0) = "'" & Format(ENTRYDATE.Value, "dd/MM/yyyy") & "'"

                'getting LEDGERID
                tempcmd = New OleDbCommand("select LEDGER_id from LEDGERMASTER where LEDGER_CODE = 'SALARY'", tempconn)
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
                tempval(6) = "'Balance'"
                tempval(7) = Val(TXTENTRYNO.Text.Trim)
                tempval(8) = "'SALARY'"
                tempval(9) = "'SALARY'"
                tempval(10) = Val(Userid)
                tempval(11) = Val(USERDEPARTMENTID)
                tempval(12) = "''"  'PROCESSNAME

                insert("accountmaster", tempcol, tempval)
                '******** END OF CODE FOR NAAME **********


                'POSTING FOR JAMA
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
                tempval(6) = "'Jama'"
                tempval(7) = Val(TXTENTRYNO.Text.Trim)
                tempval(8) = "'SALARY'"
                tempval(9) = "'" & ROW.Cells(GCODE.Index).Value & "'"
                tempval(10) = Val(Userid)
                tempval(11) = Val(USERDEPARTMENTID)
                tempval(12) = "''"  'PROCESSNAME

                insert("accountmaster", tempcol, tempval)
                '******** END OF CODE FOR JAMA **********




                'THIS IS EXTRA POSTING IF CASHPAID > 0
                '   PARTY NAAME
                '   CASH JAMA

                If Val(ROW.Cells(GCASH.Index).Value) > 0 Then

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
                    tempval(4) = Format(Val(ROW.Cells(GCASH.Index).Value), "0.00")
                    tempval(5) = "'" & ROW.Cells(GNARR.Index).Value & "'"
                    tempval(6) = "'Balance'"
                    tempval(7) = Val(TXTENTRYNO.Text.Trim)
                    tempval(8) = "'SALARY'"
                    tempval(9) = "'" & ROW.Cells(GCODE.Index).Value & "'"
                    tempval(10) = Val(Userid)
                    tempval(11) = Val(USERDEPARTMENTID)
                    tempval(12) = "''"  'PROCESSNAME

                    insert("accountmaster", tempcol, tempval)
                    '******** END OF CODE FOR NAAME **********


                    'POSTING FOR JAMA
                    '****************
                    tempval(0) = "'" & Format(ENTRYDATE.Value, "dd/MM/yyyy") & "'"

                    'getting LEDGERID
                    tempcmd = New OleDbCommand("select LEDGER_id from LEDGERMASTER where LEDGER_CODE = 'CASH'", tempconn)
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
                    tempval(4) = Format(Val(ROW.Cells(GCASH.Index).Value), "0.00")
                    tempval(5) = "'" & ROW.Cells(GNARR.Index).Value & "'"
                    tempval(6) = "'Jama'"
                    tempval(7) = Val(TXTENTRYNO.Text.Trim)
                    tempval(8) = "'SALARY'"
                    tempval(9) = "'CASH'"
                    tempval(10) = Val(Userid)
                    tempval(11) = Val(USERDEPARTMENTID)
                    tempval(12) = "''"  'PROCESSNAME

                    insert("accountmaster", tempcol, tempval)
                    '******** END OF CODE FOR JAMA **********
                End If



            Next

            EDIT = False
            clear()
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub GETMAX_SAL_NO()
        cmd = New OleDbCommand("select IIF(ISNULL(max(SAL_NO)) = TRUE, 0,max(SAL_NO)) + 1 from SALARYENTRY", conn)
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
        ENTRYDATE.Value = globaldate

        TXTSRNO.Text = 1
        TXTNAME.Clear()
        TXTBALAMT.Clear()
        CMBCODE.Text = ""
        TXTSALARY.Clear()
        FROMDATE.Value = Now.Date
        TODATE.Value = Now.Date
        TXTDAYS.Clear()
        TXTABSENT.Clear()
        TXTNIGHTS.Clear()
        TXTOT.Clear()
        TXTHOURRATE.Text = 50
        TXTHOURS.Clear()
        TXTGROSSAMT.Clear()
        TXTDEDUCTION.Clear()
        TXTAMOUNT.Clear()
        TXTCASH.Clear()
        TXTNARR.Clear()
        GRIDSALARY.RowCount = 0


        TXTTOTALGROSSAMT.Clear()
        TXTTOTALDEDUCTION.Clear()
        TXTTOTALAMT.Clear()
        TXTTOTALCASH.Clear()

        EP.Clear()

        GETMAX_SAL_NO()

    End Sub

    Private Sub cmdclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        clear()
        EDIT = False
        ENTRYDATE.Focus()
    End Sub

    Sub fillcmb()
        Try
            fillname(Me, CMBCODE, "")
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
                GRIDSALARY.Rows.Add(Val(TXTSRNO.Text.Trim), CMBCODE.Text.Trim, Val(TXTSALARY.Text.Trim), Format(FROMDATE.Value.Date, "dd/MM/yyyy"), Format(TODATE.Value.Date, "dd/MM/yyyy"), Val(TXTDAYS.Text.Trim), Val(TXTABSENT.Text.Trim), Val(TXTNIGHTS.Text.Trim), Val(TXTOT.Text.Trim), Val(TXTHOURRATE.Text.Trim), Val(TXTHOURS.Text.Trim), Format(Val(TXTGROSSAMT.Text.Trim), "0.00"), Format(Val(TXTDEDUCTION.Text.Trim), "0.00"), Format(Val(TXTAMOUNT.Text.Trim), "0.00"), Format(Val(TXTCASH.Text.Trim), "0.00"), TXTNARR.Text.Trim)
                GETSRNO(GRIDSALARY)

            ElseIf GRIDDOUBLECLICK = True Then
                GRIDSALARY.Item(GSRNO.Index, temprow).Value = Val(TXTSRNO.Text.Trim)
                GRIDSALARY.Item(GCODE.Index, temprow).Value = CMBCODE.Text.Trim
                GRIDSALARY.Item(GSALARY.Index, temprow).Value = Val(TXTSALARY.Text.Trim)
                GRIDSALARY.Item(GFROM.Index, temprow).Value = Format(FROMDATE.Value.Date, "dd/MM/yyyy")
                GRIDSALARY.Item(GTO.Index, temprow).Value = Format(TODATE.Value.Date, "dd/MM/yyyy")
                GRIDSALARY.Item(GDAYS.Index, temprow).Value = Val(TXTDAYS.Text.Trim)
                GRIDSALARY.Item(GABSENT.Index, temprow).Value = Val(TXTABSENT.Text.Trim)
                GRIDSALARY.Item(GNIGHTS.Index, temprow).Value = Val(TXTNIGHTS.Text.Trim)
                GRIDSALARY.Item(GOT.Index, temprow).Value = Val(TXTOT.Text.Trim)
                GRIDSALARY.Item(GHOURRATE.Index, temprow).Value = Val(TXTHOURRATE.Text.Trim)
                GRIDSALARY.Item(GHOURS.Index, temprow).Value = Val(TXTHOURS.Text.Trim)
                GRIDSALARY.Item(GGROSSAMT.Index, temprow).Value = Format(Val(TXTGROSSAMT.Text.Trim), "0.00")
                GRIDSALARY.Item(GDEDUCTION.Index, temprow).Value = Format(Val(TXTDEDUCTION.Text.Trim), "0.00")
                GRIDSALARY.Item(GAMOUNT.Index, temprow).Value = Format(Val(TXTAMOUNT.Text.Trim), "0.00")
                GRIDSALARY.Item(GCASH.Index, temprow).Value = Format(Val(TXTCASH.Text.Trim), "0.00")
                GRIDSALARY.Item(GNARR.Index, temprow).Value = TXTNARR.Text.Trim

                GRIDDOUBLECLICK = False
            End If

            GRIDSALARY.FirstDisplayedScrollingRowIndex = GRIDSALARY.RowCount - 1

            TXTSRNO.Clear()
            CMBCODE.Text = ""
            TXTSALARY.Clear()
            TXTABSENT.Clear()
            TXTNIGHTS.Clear()
            TXTOT.Clear()
            TXTHOURS.Clear()
            TXTGROSSAMT.Clear()
            TXTDEDUCTION.Clear()
            TXTAMOUNT.Clear()
            TXTCASH.Clear()
            TXTNARR.Clear()
            CMBCODE.Focus()
            TOTAL()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCODE_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBCODE.Validated
        Try
            If CMBCODE.Text.Trim = "" Then
                cmdok.Focus()
            Else
                TXTNAME.Clear()
                TXTBALAMT.Text = 0
                TXTSALARY.Clear()
                If Val(TXTSALARY.Text.Trim) = 0 Then
                    'GET SALARY FROM LEDGERMASTER
                    tempcmd = New OleDbCommand("select LEDGER_NAME AS NAME, IIF(ISNULL(LEDGER_SALARY) = TRUE, 0,LEDGER_SALARY)  AS SALARY from LEDGERMASTER where LEDGER_CODE = '" & CMBCODE.Text.Trim & "'", tempconn)
                    If tempconn.State = ConnectionState.Open Then tempconn.Close()
                    tempconn.Open()
                    tempdr = tempcmd.ExecuteReader
                    If tempdr.HasRows Then
                        tempdr.Read()
                        TXTNAME.Text = tempdr("NAME")
                        TXTSALARY.Text = Val(tempdr("SALARY"))
                        CALC()
                    End If
                    tempconn.Close()
                    tempdr.Close()
                End If

                'GET BALANCE AMT
                tempcmd = New OleDbCommand("select IIF(ISNULL(SUM(AMOUNT))=TRUE,0,SUM(AMOUNT)) AS AMOUNT from TRIALBALANCE where CODE = '" & CMBCODE.Text.Trim & "'", tempconn)
                If tempconn.State = ConnectionState.Open Then tempconn.Close()
                tempconn.Open()
                tempdr = tempcmd.ExecuteReader
                If tempdr.HasRows Then
                    tempdr.Read()
                    TXTBALAMT.Text = Format(Val(tempdr("AMOUNT")), "0.00")
                End If
                tempconn.Close()
                tempdr.Close()

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub CALC()
        Try
            TXTDAYS.Text = DateDiff(DateInterval.Day, FROMDATE.Value.Date, TODATE.Value.Date) + 1
            If Val(TXTSALARY.Text.Trim) > 0 And Val(TXTDAYS.Text.Trim) > 0 Then
                'IF WE HAVE SELECTED LAST DAY OF THE MONTH IN TODATE THEN CALCULATE WITH CALCDAYS ELSE CALCULATE WITH TXTDAYS
                'CHECKING WHETHER WE HAVE SELECTED LAST DAY OF THE MONTH IN TODATE OR NOT
                If TODATE.Value.Date = TODATE.Value.Date.AddDays(-(TODATE.Value.Day - 1)).AddMonths(1).AddDays(-1) Then
                    TXTGROSSAMT.Text = Format((Val(TXTSALARY.Text.Trim) / Val(TXTCALCDAYS.Text.Trim)) * (Val(TXTCALCDAYS.Text.Trim) + Val(TXTNIGHTS.Text.Trim) + (Val(TXTOT.Text.Trim) / 2) - Val(TXTABSENT.Text.Trim)), "0.00")
                Else
                    TXTGROSSAMT.Text = Format((Val(TXTSALARY.Text.Trim) / Val(TXTCALCDAYS.Text.Trim)) * (Val(TXTDAYS.Text.Trim) + Val(TXTNIGHTS.Text.Trim) + (Val(TXTOT.Text.Trim) / 2) - Val(TXTABSENT.Text.Trim)), "0.00")
                End If
                TXTAMOUNT.Text = Format(Val(TXTGROSSAMT.Text.Trim) - Val(TXTDEDUCTION.Text.Trim) + (Val(TXTHOURRATE.Text.Trim) * Val(TXTHOURS.Text.Trim)), "0.00")
                TXTCASH.Text = Format(Val(TXTAMOUNT.Text.Trim) + Val(TXTBALAMT.Text.Trim), "0.00")
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
        If GRIDSALARY.RowCount = 0 Then
            EP.SetError(CMBCODE, " Enter Details below")
            bln = False
        End If

        'THIS IS DONE TO STOP DUPLICATE ENTRIES IF ANY USER IS USING THE SAME FORM
        If EDIT = False Then GETMAX_SAL_NO()
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
                    'deleting data from SALARYENTRY
                    cmd = New OleDbCommand("delete from SALARYENTRY where SAL_NO = " & TEMPSALNO, conn)
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Open()
                    cmd.ExecuteNonQuery()

                    cmd = New OleDbCommand("DELETE FROM ACCOUNTMASTER where ACCOUNT_VOUCHERID = " & TEMPSALNO & " AND ACCOUNT_TYPE = 'SALARY'", conn)
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
            Dim OBJSAL As New SalaryDetails
            OBJSAL.MdiParent = MDIMain
            OBJSAL.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SaveToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripButton.Click
        Call cmdok_Click(sender, e)
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try
            If EDIT = True Then PRINTREPORT(TEMPSALNO)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub toolprevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolprevious.Click
        Try
            TEMPSALNO = Val(TXTENTRYNO.Text) - 1
            If TEMPSALNO > 0 Then
                EDIT = True
                Salary_Load(sender, e)
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
            TEMPSALNO = Val(TXTENTRYNO.Text) + 1
            GETMAX_SAL_NO()
            clear()
            If Val(TXTENTRYNO.Text) - 1 >= TEMPSALNO Then
                EDIT = True
                Salary_Load(sender, e)
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
                OBJVOUCHER.WHERECLAUSE = " {SALARYENTRY.SAL_NO} = " & Val(TEMPSALNO)
            Else
                OBJVOUCHER.WHERECLAUSE = " {SALARYENTRY.SAL_NO} = " & Val(TXTENTRYNO.Text.Trim)
            End If
            OBJVOUCHER.FRMSTRING = "SALARY"
            OBJVOUCHER.MdiParent = MDIMain
            OBJVOUCHER.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDSAL_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDSALARY.CellDoubleClick
        Try
            If e.RowIndex >= 0 And GRIDSALARY.Item(GSRNO.Index, e.RowIndex).Value <> Nothing Then

                GRIDDOUBLECLICK = True
                TXTSRNO.Text = Val(GRIDSALARY.Item(GSRNO.Index, e.RowIndex).Value)
                CMBCODE.Text = GRIDSALARY.Item(GCODE.Index, e.RowIndex).Value.ToString
                TXTSALARY.Text = Val(GRIDSALARY.Item(GSALARY.Index, e.RowIndex).Value)
                FROMDATE.Value = Format(Convert.ToDateTime(GRIDSALARY.Item(GFROM.Index, e.RowIndex).Value).Date, "dd/MM/yyyy")
                TODATE.Value = Format(Convert.ToDateTime(GRIDSALARY.Item(GTO.Index, e.RowIndex).Value).Date, "dd/MM/yyyy")

                TXTDAYS.Text = Val(GRIDSALARY.Item(GDAYS.Index, e.RowIndex).Value)
                TXTABSENT.Text = Val(GRIDSALARY.Item(GABSENT.Index, e.RowIndex).Value)
                TXTNIGHTS.Text = Val(GRIDSALARY.Item(GNIGHTS.Index, e.RowIndex).Value)
                TXTOT.Text = Val(GRIDSALARY.Item(GOT.Index, e.RowIndex).Value)
                TXTHOURRATE.Text = Val(GRIDSALARY.Item(GHOURRATE.Index, e.RowIndex).Value)
                TXTHOURS.Text = Val(GRIDSALARY.Item(GHOURS.Index, e.RowIndex).Value)
                TXTGROSSAMT.Text = Val(GRIDSALARY.Item(GGROSSAMT.Index, e.RowIndex).Value)
                TXTDEDUCTION.Text = Val(GRIDSALARY.Item(GDEDUCTION.Index, e.RowIndex).Value)
                TXTAMOUNT.Text = Val(GRIDSALARY.Item(GAMOUNT.Index, e.RowIndex).Value)
                TXTCASH.Text = Val(GRIDSALARY.Item(GCASH.Index, e.RowIndex).Value)
                TXTNARR.Text = GRIDSALARY.Item(GNARR.Index, e.RowIndex).Value.ToString

                temprow = e.RowIndex
                CMBCODE.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTCASH_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTCASH.Validated
        Try
            If CMBCODE.Text.Trim <> "" And Val(TXTDAYS.Text.Trim) > 0 And Val(TXTAMOUNT.Text.Trim) > 0 Then
                FILLGRID()
            Else
                MsgBox("Enter Proper Details")
                Exit Sub
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTSALARY_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTSALARY.KeyPress, TXTDEDUCTION.KeyPress, TXTCASH.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub

    Private Sub TXTABSENT_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTABSENT.KeyPress, TXTNIGHTS.KeyPress, TXTCALCDAYS.KeyPress, TXTOT.KeyPress
        numkeypress(e, sender, Me)
    End Sub

    Private Sub TXTABSENT_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTABSENT.Validated, TXTNIGHTS.Validated, TXTDEDUCTION.Validated, FROMDATE.Validated, TODATE.Validated, TXTOT.Validated, TXTHOURS.Validated, TXTHOURRATE.Validated
        If FROMDATE.Value.Date > TODATE.Value.Date Then
            MsgBox("Invalida Date Selected", MsgBoxStyle.Critical)
            Exit Sub
        End If
        CALC()
    End Sub

    Private Sub GRIDSALARY_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDSALARY.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDSALARY.RowCount > 0 Then
                If GRIDDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                'end of block
                GRIDSALARY.Rows.RemoveAt(GRIDSALARY.CurrentRow.Index)
                GETSRNO(GRIDSALARY)
                TOTAL()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class