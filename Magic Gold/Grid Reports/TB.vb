
Imports System.Data.OleDb

Public Class TB

    Sub FILLGRID(Optional ByVal WHERECLAUSE As String = "")
        Try
            Dim TOTALOPBALDR, TOTALOPBALCR, TOTALDR, TOTALCR, TOTALCLODR, TOTALCLOCR, CLODR, CLOCR, OPDR, OPCR, CURRDR, CURRCR As Double
            GRIDTRIALBALANCE.RowCount = 1

            'IF THERE ARE NO TRNSACTION IN THIS YEAR THEN CHECK THOSE LEDGERS WHETHER WE HAVE OPENING OR NOT
            Dim DTLEDGERS As New DataTable
            'cmd = New OleDbCommand("SELECT DISTINCT CODE AS NAME, GROUP_NAME AS GROUPNAME FROM TRIALBALANCE WHERE CODE NOT IN (SELECT accountmaster.account_ledgercode FROM accountmaster) " & WHERECLAUSE, conn)
            'If conn.State = ConnectionState.Open Then conn.Close()
            'conn.Open()
            'da = New OleDbDataAdapter(cmd)
            'da.Fill(DTLEDGERS)
            'For Each LEDGERROW As DataRow In DTLEDGERS.Rows

            '    Dim DTOPBAL As New DataTable
            '    If chkdate.CheckState = CheckState.Unchecked Then tempcmd = New OleDbCommand("SELECT IIF(LEDGER_DRCRWT = 'Cr.', LEDGER_OPBALWT,0) AS OPBALDR, IIF(LEDGER_DRCRWT = 'Dr.', LEDGER_OPBALWT,0) AS OPBALCR FROM LEDGERMASTER WHERE LEDGER_CODE = '" & LEDGERROW("NAME") & "'", tempconn) Else tempcmd = New OleDbCommand("SELECT ROUND( IIF(SUM(NETTWT) > 0 , SUM(NETTWT) , 0),3) AS OPBALDR,  ROUND(IIF(SUM(NETTWT) < 0 , SUM(NETTWT)*(-1) , 0),3) AS OPBALCR FROM TRIALBALANCE WHERE CODE = '" & LEDGERROW("NAME") & "' AND SDATE < #" & Format(dtfrom.Value, "MM/dd/yyyy") & "#", tempconn)
            '    If tempconn.State = ConnectionState.Open Then tempconn.Close()
            '    tempconn.Open()
            '    da = New OleDbDataAdapter(tempcmd)
            '    da.Fill(DTOPBAL)

            '    If Val(DTOPBAL.Rows(0).Item("OPBALDR")) - Val(DTOPBAL.Rows(0).Item("OPBALCR")) > 0 Then
            '        CLODR = Val(DTOPBAL.Rows(0).Item("OPBALDR")) - Val(DTOPBAL.Rows(0).Item("OPBALCR"))
            '        CLOCR = 0
            '    Else
            '        CLODR = 0
            '        CLOCR = Val(DTOPBAL.Rows(0).Item("OPBALCR")) - Val(DTOPBAL.Rows(0).Item("OPBALDR"))
            '    End If

            '    'If (Val(DTROW("DR")) - Val(DTROW("CR"))) > 0 Or (Val(DTROW("DR")) - Val(DTROW("CR"))) < 0 Or Val(DTROW("OPBALDR")) > 0 Or Val(DTROW("OPBALCR")) > 0 Then
            '    If Val(DTOPBAL.Rows(0).Item("OPBALDR")) > 0 Or Val(DTOPBAL.Rows(0).Item("OPBALCR")) > 0 Or Val(CLODR) > 0 Or Val(CLOCR) > 0 Then
            '        GRIDTRIALBALANCE.Rows.Add(LEDGERROW("NAME"), Format(Val(DTOPBAL.Rows(0).Item("OPBALDR")), "0.000"), Format(Val(DTOPBAL.Rows(0).Item("OPBALCR")), "0.000"), 0, 0, Format(Val(CLODR), "0.000"), Format(Val(CLOCR), "0.000"), LEDGERROW("GROUPNAME"))
            '        GRIDTRIALBALANCE.Rows(GRIDTRIALBALANCE.RowCount - 2).DefaultCellStyle.Font = New Font("CALIBRI", 9, FontStyle.Regular)
            '    End If
            '    TOTALOPBALDR += Val(DTOPBAL.Rows(0).Item("OPBALDR"))
            '    TOTALOPBALCR += Val(DTOPBAL.Rows(0).Item("OPBALCR"))

            '    TOTALDR += 0
            '    TOTALCR += 0

            '    TOTALCLODR += Val(CLODR)
            '    TOTALCLOCR += Val(CLOCR)
            'Next



            'GET ALL LEDGERS AND LOOP
            DTLEDGERS.Clear()
            cmd = New OleDbCommand("SELECT LEDGER_CODE AS NAME, GROUP_NAME AS GROUPNAME FROM  (ledgermaster INNER JOIN groupmaster ON ledgermaster.ledger_groupid = groupmaster.group_id) LEFT JOIN areamaster ON ledgermaster.ledger_areaid = areamaster.area_id WHERE 1=1 " & WHERECLAUSE & " AND GROUPMASTER.GROUP_NAME <> 'Stock In Hand' ORDER BY LEDGER_CODE", conn)
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Open()
            Dim DALEDGER = New OleDbDataAdapter(cmd)
            DALEDGER.Fill(DTLEDGERS)
            cmd.Dispose()


            For Each DTROWLEDGER As DataRow In DTLEDGERS.Rows

                OPDR = 0
                OPCR = 0
                CURRDR = 0
                CURRCR = 0
                CLODR = 0
                CLOCR = 0



                'FIRST GET OPENINGBALANCE
                Dim DTOPBAL As New DataTable
                Dim DAOP = New OleDbDataAdapter

                If chkdate.CheckState = CheckState.Checked Then
                    tempcmd = New OleDbCommand("SELECT IIF(ISNULL(SUM(ACCOUNT_NETTWT)) = TRUE,0, ROUND(SUM(ACCOUNT_NETTWT),3)) AS OPBALDR FROM ACCOUNTMAST WHERE ACCOUNT_LEDGERCODE = '" & DTROWLEDGER("NAME") & "' AND ACCOUNT_BALORJAMAORPAID = 'Jama' AND ACCOUNT_DATE < #" & Format(dtfrom.Value, "MM/dd/yyyy") & "#", tempconn)
                    If tempconn.State = ConnectionState.Open Then tempconn.Close()
                    tempconn.Open()
                    DAOP = New OleDbDataAdapter(tempcmd)
                    DAOP.Fill(DTOPBAL)
                    If DTOPBAL.Rows.Count > 0 Then
                        OPDR = Format(Val(DTOPBAL.Rows(0).Item("OPBALDR")), "0.000")
                    End If
                    tempcmd.Dispose()
                    DTOPBAL = New DataTable
                    DAOP = New OleDbDataAdapter

                    tempcmd = New OleDbCommand("SELECT IIF(ISNULL(SUM(ACCOUNT_NETTWT)) = TRUE,0, ROUND(SUM(ACCOUNT_NETTWT),3))  AS OPBALCR FROM ACCOUNTMAST WHERE ACCOUNT_LEDGERCODE = '" & DTROWLEDGER("NAME") & "' AND ACCOUNT_BALORJAMAORPAID = 'Balance' AND ACCOUNT_DATE < #" & Format(dtfrom.Value, "MM/dd/yyyy") & "#", tempconn)
                    If tempconn.State = ConnectionState.Open Then tempconn.Close()
                    tempconn.Open()
                    DAOP = New OleDbDataAdapter(tempcmd)
                    DAOP.Fill(DTOPBAL)
                    If DTOPBAL.Rows.Count > 0 Then
                        OPCR = Format(Val(DTOPBAL.Rows(0).Item("OPBALCR")), "0.000")
                    End If
                    tempcmd.Dispose()

                    If OPDR - OPCR > 0 Then
                        OPDR = OPDR - OPCR
                        OPCR = 0
                        'TOTALOPBALDR += OPDR
                    Else
                        OPCR = OPCR - OPDR
                        OPDR = 0
                        'TOTALOPBALCR += OPCR
                    End If
                    'If Val(OPDR) > 0 Then
                    '    TOTALOPBALDR += OPDR
                    'End If
                    'If Val(OPCR) > 0 Then
                    '    TOTALOPBALCR += OPCR
                    'End If

                End If


                'ADD OPBAL FROM LEDGERMASTER ALSO IN THE ABOVE VARIABLES
                DTOPBAL.Clear()
                tempcmd = New OleDbCommand("SELECT IIF(LEDGER_DRCRWT = 'Cr.', LEDGER_OPBALWT,0) AS OPBALDR, IIF(LEDGER_DRCRWT = 'Dr.', LEDGER_OPBALWT,0) AS OPBALCR FROM LEDGERMASTER WHERE LEDGER_CODE = '" & DTROWLEDGER("NAME") & "'", tempconn)
                If tempconn.State = ConnectionState.Open Then tempconn.Close()
                tempconn.Open()
                DAOP = New OleDbDataAdapter(tempcmd)
                DAOP.Fill(DTOPBAL)
                If DTOPBAL.Rows.Count > 0 Then
                    OPDR += Format(Val(DTOPBAL.Rows(0).Item("OPBALDR")), "0.000")
                    OPCR += Format(Val(DTOPBAL.Rows(0).Item("OPBALCR")), "0.000")

                    'If Val(DTOPBAL.Rows(0).Item("OPBALDR")) > 0 Then TOTALOPBALDR += OPDR
                    'If Val(DTOPBAL.Rows(0).Item("OPBALCR")) > 0 Then TOTALOPBALCR += OPCR

                    'If Val(DTOPBAL.Rows(0).Item("OPBALDR")) > 0 Then
                    '    TOTALOPBALDR += Val(DTOPBAL.Rows(0).Item("OPBALDR"))
                    'End If
                    'If Val(DTOPBAL.Rows(0).Item("OPBALCR")) > 0 Then TOTALOPBALCR += Val(DTOPBAL.Rows(0).Item("OPBALCR"))

                    If OPDR > 0 And OPCR > 0 Then
                        If Val(OPDR) - Val(OPCR) > 0 Then
                            OPDR = Val(OPDR) - Val(OPCR)
                            'TOTALOPBALCR -= OPCR
                            'TOTALOPBALDR += OPDR
                            OPCR = 0
                        Else
                            'TOTALOPBALDR -= OPDR
                            'TOTALOPBALCR += OPCR
                            OPCR = Val(OPCR) - Val(OPDR)
                            OPDR = 0
                        End If
                    End If

                End If




                'NOW GET THE TRANSACTIONS AND THEN COMPARE FOR SELECTED DATES
                Dim DT As New DataTable
                If chkdate.CheckState = CheckState.Unchecked Then cmd = New OleDbCommand("SELECT T.NAME, SUM(T.DR) AS DR, SUM(T.CR) AS CR FROM (SELECT ACCOUNT_LEDGERCODE AS NAME, SUM(ACCOUNT_NETTWT) AS DR, 0 AS CR FROM ACCOUNTMAST WHERE ACCOUNT_BALORJAMAORPAID= 'Jama' " & WHERECLAUSE & " AND ACCOUNT_LEDGERCODE = '" & DTROWLEDGER("NAME") & "' GROUP BY ACCOUNT_LEDGERCODE UNION ALL SELECT ACCOUNT_LEDGERCODE AS NAME, 0 AS DR, SUM(ACCOUNT_NETTWT) AS CR FROM ACCOUNTMAST WHERE ACCOUNT_BALORJAMAORPAID = 'Balance' " & WHERECLAUSE & " AND ACCOUNT_LEDGERCODE = '" & DTROWLEDGER("NAME") & "'  GROUP BY ACCOUNT_LEDGERCODE) AS T WHERE NAME <> '' GROUP BY T.NAME", conn) Else cmd = New OleDbCommand("SELECT T.NAME, SUM(DR) AS DR, SUM(CR) AS CR FROM (SELECT ACCOUNT_LEDGERCODE AS NAME, SUM(ACCOUNT_NETTWT) AS DR, 0 AS CR FROM ACCOUNTMAST WHERE ACCOUNT_BALORJAMAORPAID= 'Jama' AND ACCOUNT_DATE BETWEEN #" & Format(dtfrom.Value, "MM/dd/yyyy") & "# AND #" & Format(dtto.Value, "MM/dd/yyyy") & "# AND ACCOUNT_LEDGERCODE = '" & DTROWLEDGER("NAME") & "' " & WHERECLAUSE & " GROUP BY ACCOUNT_LEDGERCODE UNION ALL SELECT ACCOUNT_LEDGERCODE AS NAME, 0 AS DR, SUM(ACCOUNT_NETTWT) AS CR FROM ACCOUNTMAST WHERE ACCOUNT_BALORJAMAORPAID = 'Balance' AND ACCOUNT_DATE BETWEEN #" & Format(dtfrom.Value, "MM/dd/yyyy") & "# AND #" & Format(dtto.Value, "MM/dd/yyyy") & "# AND ACCOUNT_LEDGERCODE = '" & DTROWLEDGER("NAME") & "' " & WHERECLAUSE & "  GROUP BY ACCOUNT_LEDGERCODE) AS T WHERE NAME <> '' GROUP BY T.NAME", conn)
                If conn.State = ConnectionState.Open Then conn.Close()
                conn.Open()
                da = New OleDbDataAdapter(cmd)
                da.Fill(DT)
                cmd.Dispose()
                If DT.Rows.Count > 0 Then
                    CURRDR = Format(Val(DT.Rows(0).Item("DR")), "0.000")
                    CURRCR = Format(Val(DT.Rows(0).Item("CR")), "0.000")
                    TOTALDR += CURRDR
                    TOTALCR += CURRCR
                End If

                If (OPDR + CURRDR) - (OPCR + CURRCR) > 0 Then
                    CLODR = (OPDR + CURRDR) - (OPCR + CURRCR)
                    CLOCR = 0
                    TOTALCLODR += CLODR
                Else
                    CLODR = 0
                    CLOCR = (OPCR + CURRCR) - (OPDR + CURRDR)
                    TOTALCLOCR += CLOCR
                End If
                If CHKREMOVE0.Checked = True AndAlso (Val(CLODR) = 0 And Val(CLOCR) = 0) Then GoTo SKIPLINE
                If Val(OPDR) <> 0 Or Val(OPCR) <> 0 Or Val(CURRDR) <> 0 Or Val(CURRCR) <> 0 Or Val(CLODR) <> 0 Or Val(CLOCR) <> 0 Then GRIDTRIALBALANCE.Rows.Add(DTROWLEDGER("NAME"), Format(Val(OPDR), "0.000"), Format(Val(OPCR), "0.000"), Format(Val(CURRDR), "0.000"), Format(Val(CURRCR), "0.000"), Format(Val(CLODR), "0.000"), Format(Val(CLOCR), "0.000"), DTROWLEDGER("GROUPNAME"))

SKIPLINE:
                DT.Clear()
                DTOPBAL.Clear()
                da.Dispose()

            Next


            'GET TOTAL
            For Each ROW As DataGridViewRow In GRIDTRIALBALANCE.Rows
                TOTALOPBALDR += Val(ROW.Cells(GOPDR.Index).Value)
                TOTALOPBALCR += Val(ROW.Cells(GOPCR.Index).Value)
            Next


            ''GET ALL LEDGERS AND LOOP
            'DTLEDGERS.Clear()
            'cmd = New OleDbCommand("SELECT LEDGER_CODE AS NAME FROM LEDGERMASTER ORDER BY LEDGER_CODE", conn)
            'If conn.State = ConnectionState.Open Then conn.Close()
            'conn.Open()
            'Dim DALEDGER = New OleDbDataAdapter(cmd)
            'DALEDGER.Fill(DTLEDGERS)
            'cmd.Dispose()

            'For Each DTROWLEDGER As DataRow In DTLEDGERS.Rows

            '    Dim DT As New DataTable
            '    If chkdate.CheckState = CheckState.Unchecked Then cmd = New OleDbCommand("SELECT T.NAME, SUM(DR) AS DR, SUM(CR) AS CR FROM (SELECT ACCOUNT_LEDGERCODE AS NAME, SUM(ACCOUNT_NETTWT) AS DR, 0 AS CR FROM ACCOUNTMAST WHERE ACCOUNT_DATE > LEDGER_SETTLEMENT AND ACCOUNT_BALORJAMAORPAID= 'Jama' " & WHERECLAUSE & " AND ACCOUNT_LEDGERCODE = '" & DTROWLEDGER("NAME") & "' GROUP BY ACCOUNT_LEDGERCODE UNION ALL SELECT ACCOUNT_LEDGERCODE AS NAME, 0 AS DR, SUM(ACCOUNT_NETTWT) AS CR FROM ACCOUNTMAST WHERE ACCOUNT_DATE > LEDGER_SETTLEMENT AND ACCOUNT_BALORJAMAORPAID = 'Balance' " & WHERECLAUSE & " AND ACCOUNT_LEDGERCODE = '" & DTROWLEDGER("NAME") & "' GROUP BY ACCOUNT_LEDGERCODE) AS T WHERE NAME <> '' GROUP BY T.NAME", conn) Else cmd = New OleDbCommand("SELECT T.NAME, SUM(DR) AS DR, SUM(CR) AS CR FROM (SELECT ACCOUNT_LEDGERCODE AS NAME, SUM(ACCOUNT_NETTWT) AS DR, 0 AS CR FROM ACCOUNTMAST WHERE ACCOUNT_DATE > LEDGER_SETTLEMENT AND ACCOUNT_BALORJAMAORPAID= 'Jama' AND ACCOUNT_LEDGERCODE = '" & DTROWLEDGER("NAME") & "' AND ACCOUNT_DATE BETWEEN #" & Format(dtfrom.Value, "MM/dd/yyyy") & "# AND #" & Format(dtto.Value, "MM/dd/yyyy") & "# " & WHERECLAUSE & " GROUP BY ACCOUNT_LEDGERCODE UNION ALL SELECT ACCOUNT_LEDGERCODE AS NAME, 0 AS DR, SUM(ACCOUNT_NETTWT) AS CR FROM ACCOUNTMAST WHERE ACCOUNT_DATE > LEDGER_SETTLEMENT AND ACCOUNT_BALORJAMAORPAID = 'Balance' AND ACCOUNT_LEDGERCODE = '" & DTROWLEDGER("NAME") & "' AND ACCOUNT_DATE BETWEEN #" & Format(dtfrom.Value, "MM/dd/yyyy") & "# AND #" & Format(dtto.Value, "MM/dd/yyyy") & "# " & WHERECLAUSE & " GROUP BY ACCOUNT_LEDGERCODE) AS T WHERE NAME <> '' GROUP BY T.NAME", conn)
            '    If conn.State = ConnectionState.Open Then conn.Close()
            '    conn.Open()
            '    da = New OleDbDataAdapter(cmd)
            '    da.Fill(DT)
            '    cmd.Dispose()
            '    Dim DTROW As DataRow
            '    If DT.Rows.Count > 0 Then DTROW = DT.Rows(0)


            '    Dim DTOPBAL As New DataTable
            '    If chkdate.CheckState = CheckState.Unchecked Then tempcmd = New OleDbCommand("SELECT T.NAME, SUM(DR) AS OPBALDR, SUM(CR) AS OPBALCR FROM (SELECT ACCOUNT_LEDGERCODE AS NAME, SUM(ACCOUNT_NETTWT) AS DR, 0 AS CR FROM ACCOUNTMAST WHERE ACCOUNT_DATE <= LEDGER_SETTLEMENT AND ACCOUNT_BALORJAMAORPAID= 'Jama' " & WHERECLAUSE & " AND ACCOUNT_LEDGERCODE = '" & DTROWLEDGER("NAME") & "' GROUP BY ACCOUNT_LEDGERCODE UNION ALL SELECT ACCOUNT_LEDGERCODE AS NAME, 0 AS DR, SUM(ACCOUNT_NETTWT) AS CR FROM ACCOUNTMAST WHERE ACCOUNT_DATE <= LEDGER_SETTLEMENT AND ACCOUNT_BALORJAMAORPAID = 'Balance' " & WHERECLAUSE & " AND ACCOUNT_LEDGERCODE = '" & DTROWLEDGER("NAME") & "' GROUP BY ACCOUNT_LEDGERCODE) AS T WHERE NAME <> '' GROUP BY T.NAME", tempconn) Else tempcmd = New OleDbCommand("SELECT T.NAME, SUM(DR) AS OPBALDR, SUM(CR) AS OPBALCR FROM (SELECT ACCOUNT_LEDGERCODE AS NAME, SUM(ACCOUNT_NETTWT) AS DR, 0 AS CR FROM ACCOUNTMAST WHERE ACCOUNT_BALORJAMAORPAID= 'Jama' AND ACCOUNT_LEDGERCODE = '" & DTROWLEDGER("NAME") & "' AND ACCOUNT_DATE < #" & Format(dtfrom.Value, "MM/dd/yyyy") & "#" & WHERECLAUSE & " GROUP BY ACCOUNT_LEDGERCODE UNION ALL SELECT ACCOUNT_LEDGERCODE AS NAME, 0 AS DR, SUM(ACCOUNT_NETTWT) AS CR FROM ACCOUNTMAST WHERE ACCOUNT_BALORJAMAORPAID = 'Balance' AND ACCOUNT_LEDGERCODE = '" & DTROWLEDGER("NAME") & "' AND ACCOUNT_DATE < #" & Format(dtfrom.Value, "MM/dd/yyyy") & "# " & WHERECLAUSE & " GROUP BY ACCOUNT_LEDGERCODE) AS T WHERE NAME <> '' GROUP BY T.NAME", tempconn)
            '    'If chkdate.CheckState = CheckState.Unchecked Then tempcmd = New OleDbCommand("SELECT IIF(LEDGER_DRCRWT = 'Cr.', LEDGER_OPBALWT,0) AS OPBALDR, IIF(LEDGER_DRCRWT = 'Dr.', LEDGER_OPBALWT,0) AS OPBALCR FROM LEDGERMASTER WHERE LEDGER_CODE = '" & DTROWLEDGER("NAME") & "'", tempconn) Else tempcmd = New OleDbCommand("SELECT ROUND( IIF(SUM(NETTWT) > 0 , SUM(NETTWT) , 0),3) AS OPBALDR,  ROUND(IIF(SUM(NETTWT) < 0 , SUM(NETTWT)*(-1) , 0),3) AS OPBALCR FROM TRIALBALANCE INNER JOIN LEDGERMASTER ON TRIALBALANCE.CODE = LEDGERMASTER.LEDGER_CODE WHERE CODE = '" & DTROWLEDGER("NAME") & "' AND SDATE < #" & Format(dtfrom.Value, "MM/dd/yyyy") & "#", tempconn)
            '    If tempconn.State = ConnectionState.Open Then tempconn.Close()
            '    tempconn.Open()
            '    da = New OleDbDataAdapter(tempcmd)
            '    da.Fill(DTOPBAL)
            '    Dim OPBALDR, OPBALCR As Double

            '    If DTOPBAL.Rows.Count > 0 Then
            '        OPBALDR = DTOPBAL.Rows(0).Item("OPBALDR")
            '        OPBALCR = DTOPBAL.Rows(0).Item("OPBALCR")
            '    Else
            '        OPBALDR = 0
            '        OPBALCR = 0
            '    End If


            '    If DT.Rows.Count > 0 Then
            '        If (Val(DTROW("DR")) + Val(OPBALDR)) - (Val(DTROW("CR")) + Val(OPBALCR)) > 0 Then
            '            CLODR = (Val(DTROW("DR")) + Val(OPBALDR)) - (Val(DTROW("CR")) + Val(OPBALCR))
            '            CLOCR = 0
            '        Else
            '            CLODR = 0
            '            CLOCR = (Val(DTROW("CR")) + Val(OPBALCR)) - (Val(DTROW("DR")) + Val(OPBALDR))
            '        End If
            '    Else

            '        If Val(OPBALDR) - Val(OPBALCR) > 0 Then
            '            CLODR = Val(OPBALDR) - Val(OPBALCR)
            '            CLOCR = 0
            '        Else
            '            CLODR = 0
            '            CLOCR = Val(OPBALCR) - Val(OPBALDR)
            '        End If
            '    End If


            '    If DT.Rows.Count > 0 Then
            '        If Val(OPBALDR) > 0 Or Val(OPBALCR) > 0 Or Val(DTROW("DR")) > 0 Or Val(DTROW("CR")) > 0 Or Val(CLODR) > 0 Or Val(CLOCR) > 0 Then
            '            GRIDTRIALBALANCE.Rows.Add(DTROWLEDGER("NAME"), Format(Val(OPBALDR), "0.000"), Format(Val(OPBALCR), "0.000"), Format(Val(DTROW("DR")), "0.000"), Format(Val(DTROW("CR")), "0.000"), Format(Val(CLODR), "0.000"), Format(Val(CLOCR), "0.000"))
            '            GRIDTRIALBALANCE.Rows(GRIDTRIALBALANCE.RowCount - 2).DefaultCellStyle.Font = New Font("CALIBRI", 9, FontStyle.Regular)
            '            TOTALOPBALDR += Val(OPBALDR)
            '            TOTALOPBALCR += Val(OPBALCR)

            '            TOTALDR += Val(DTROW("DR"))
            '            TOTALCR += Val(DTROW("CR"))

            '            TOTALCLODR += Val(CLODR)
            '            TOTALCLOCR += Val(CLOCR)
            '        End If
            '    Else
            '        If Val(OPBALDR) > 0 Or Val(OPBALCR) > 0 Or Val(CLODR) > 0 Or Val(CLOCR) > 0 Then
            '            GRIDTRIALBALANCE.Rows.Add(DTROWLEDGER("NAME"), Format(Val(OPBALDR), "0.000"), Format(Val(OPBALCR), "0.000"), 0.0, 0.0, Format(Val(CLODR), "0.000"), Format(Val(CLOCR), "0.000"))
            '            GRIDTRIALBALANCE.Rows(GRIDTRIALBALANCE.RowCount - 2).DefaultCellStyle.Font = New Font("CALIBRI", 9, FontStyle.Regular)
            '            TOTALOPBALDR += Val(OPBALDR)
            '            TOTALOPBALCR += Val(OPBALCR)

            '            TOTALCLODR += Val(CLODR)
            '            TOTALCLOCR += Val(CLOCR)
            '        End If
            '    End If

            'Next




            GRIDTRIALBALANCE.Rows.Add("==================================", "===============", "===============", "===============", "===============", "===============", "===============")
            GRIDTRIALBALANCE.Rows.Add("TOTAL", Format(TOTALOPBALDR, "0.000"), Format(TOTALOPBALCR, "0.000"), Format(TOTALDR, "0.000"), Format(TOTALCR, "0.000"), Format(TOTALCLODR, "0.000"), Format(TOTALCLOCR, "0.000"))
            GRIDTRIALBALANCE.Rows.Add("==================================", "===============", "===============", "===============", "===============", "===============", "===============")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TB_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Keys.Escape Then
                Me.Close()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TB_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Call CMDSHOWDETAILS_Click(sender, e)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub CMDSHOWDETAILS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDSHOWDETAILS.Click
        FILLGRID()
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try
            If GRIDTRIALBALANCE.RowCount = 0 Then Exit Sub
            If MsgBox("Wish to Print?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            For i = 0 To 100
                tempcol(i) = ""
                tempval(i) = ""
            Next


            Dim NEWDT As New DataTable
            tempcmd = New OleDbCommand("DELETE FROM TEMPTB", tempconn)
            da = New OleDbDataAdapter(tempcmd)
            da.Fill(NEWDT)

            For Each ROW As DataGridViewRow In GRIDTRIALBALANCE.Rows

                If ROW.Cells(GNAME.Index).Value = "==================================" Then Exit For

                tempcol(0) = "NAME"
                tempcol(1) = "OPDR"
                tempcol(2) = "OPCR"
                tempcol(3) = "DEBIT"
                tempcol(4) = "CREDIT"
                tempcol(5) = "CLDR"
                tempcol(6) = "CLCR"
                tempcol(7) = "GROUPNAME"

                tempval(0) = "'" & ROW.Cells(GNAME.Index).Value & "'"
                tempval(1) = Val(ROW.Cells(GOPDR.Index).Value)
                tempval(2) = Val(ROW.Cells(GOPCR.Index).Value)
                tempval(3) = Val(ROW.Cells(GDR.Index).Value)
                tempval(4) = Val(ROW.Cells(GCR.Index).Value)
                tempval(5) = Val(ROW.Cells(GCLODR.Index).Value)
                tempval(6) = Val(ROW.Cells(GCLOCR.Index).Value)
                tempval(7) = "'" & ROW.Cells(GGROUP.Index).Value & "'"

                insert("TEMPTB", tempcol, tempval)
            Next

            Dim OBJTB As New TrialBalanceDesign
            OBJTB.MdiParent = MDIMain
            OBJTB.FRMSTRING = "TB"
            If chkdate.CheckState = CheckState.Checked Then
                OBJTB.PERIOD = Format(dtfrom.Value.Date, "dd/MM/yyyy") & "-" & Format(dtto.Value.Date, "dd/MM/yyyy")
            Else
                OBJTB.PERIOD = "Till Date - " & Format(Now.Date, "dd/MM/yyyy")
            End If
            OBJTB.Show()


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDFILTER_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDFILTER.Click
        Try
            Dim OBJFILTER As New trialbalancefilter
            OBJFILTER.ShowDialog()
            Dim WHERECLAUSE As String = OBJFILTER.WHERECLAUSE
            FILLGRID(WHERECLAUSE)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class