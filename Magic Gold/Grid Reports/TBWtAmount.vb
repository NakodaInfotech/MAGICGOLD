
Imports System.Data.OleDb

Public Class TBWtAmount

    Sub FILLGRID(Optional ByVal WHERECLAUSE As String = "")
        Try
            Dim TOTALOPBALDR, TOTALOPBALCR, TOTALDR, TOTALCR, TOTALCLODR, TOTALCLOCR, CLODR, CLOCR, OPDR, OPCR, CURRDR, CURRCR As Double
            Dim TOTALOPBALDRRS, TOTALOPBALCRRS, TOTALDRRS, TOTALCRRS, TOTALCLODRRS, TOTALCLOCRRS, CLODRRS, CLOCRRS, OPDRRS, OPCRRS, CURRDRRS, CURRCRRS As Double
            GRIDTRIALBALANCE.RowCount = 1
            Dim DTLEDGERS As New DataTable


            'IF THERE ARE NO TRNSACTION IN THIS YEAR THEN CHECK THOSE LEDGERS WHETHER WE HAVE OPENING OR NOT
            'cmd = New OleDbCommand("SELECT CODE AS NAME, GROUP_NAME AS GROUPNAME FROM TRIALBALANCE WHERE CODE NOT IN (SELECT accountmaster.account_ledgercode FROM accountmaster) " & WHERECLAUSE, conn)
            'If conn.State = ConnectionState.Open Then conn.Close()
            'conn.Open()
            'da = New OleDbDataAdapter(cmd)
            'da.Fill(DTLEDGERS)
            'For Each LEDGERROW As DataRow In DTLEDGERS.Rows

            '    'FOR WT
            '    Dim DTOPBAL As New DataTable
            '    If chkdate.CheckState = CheckState.Unchecked Then tempcmd = New OleDbCommand("SELECT IIF(LEDGER_DRCRWT = 'Cr.', LEDGER_OPBALWT,0) AS OPBALDR, IIF(LEDGER_DRCRWT = 'Dr.', LEDGER_OPBALWT,0) AS OPBALCR FROM LEDGERMASTER WHERE LEDGER_CODE = '" & LEDGERROW("NAME") & "'", tempconn) Else tempcmd = New OleDbCommand("SELECT ROUND( IIF(SUM(NETTWT) < 0 , SUM(NETTWT) , 0),3) AS OPBALDR,  ROUND(IIF(SUM(NETTWT) > 0 , SUM(NETTWT) , 0),3) AS OPBALCR FROM TRIALBALANCE WHERE CODE = '" & LEDGERROW("NAME") & "' AND SDATE < #" & Format(dtfrom.Value, "MM/dd/yyyy") & "#", tempconn)
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



            '    'FOR AMOUNT
            '    Dim DTOPBALRS As New DataTable
            '    If chkdate.CheckState = CheckState.Unchecked Then tempcmd = New OleDbCommand("SELECT IIF(LEDGER_DRCRRS = 'Cr.', LEDGER_OPBALRS,0) AS OPBALDR, IIF(LEDGER_DRCRRS = 'Dr.', LEDGER_OPBALRS,0) AS OPBALCR FROM LEDGERMASTER WHERE LEDGER_CODE = '" & LEDGERROW("NAME") & "'", tempconn) Else tempcmd = New OleDbCommand("SELECT ROUND( IIF(SUM(AMOUNT) < 0 , SUM(AMOUNT) , 0),2) AS OPBALDR,  ROUND(IIF(SUM(AMOUNT) > 0 , SUM(AMOUNT) , 0),2) AS OPBALCR FROM TRIALBALANCE WHERE CODE = '" & LEDGERROW("NAME") & "' AND SDATE < #" & Format(dtfrom.Value, "MM/dd/yyyy") & "#", tempconn)
            '    If tempconn.State = ConnectionState.Open Then tempconn.Close()
            '    tempconn.Open()
            '    da = New OleDbDataAdapter(tempcmd)
            '    da.Fill(DTOPBALRS)

            '    If Val(DTOPBALRS.Rows(0).Item("OPBALDR")) - Val(DTOPBALRS.Rows(0).Item("OPBALCR")) > 0 Then
            '        CLODRRS = Val(DTOPBALRS.Rows(0).Item("OPBALDR")) - Val(DTOPBALRS.Rows(0).Item("OPBALCR"))
            '        CLOCRRS = 0
            '    Else
            '        CLODRRS = 0
            '        CLOCRRS = Val(DTOPBALRS.Rows(0).Item("OPBALCR")) - Val(DTOPBALRS.Rows(0).Item("OPBALDR"))
            '    End If


            '    If Val(DTOPBAL.Rows(0).Item("OPBALDR")) > 0 Or Val(DTOPBAL.Rows(0).Item("OPBALCR")) > 0 Or Val(CLODR) > 0 Or Val(CLOCR) > 0 Or Val(DTOPBALRS.Rows(0).Item("OPBALDR")) > 0 Or Val(DTOPBALRS.Rows(0).Item("OPBALCR")) > 0 Or Val(CLODRRS) > 0 Or Val(CLOCRRS) > 0 Then
            '        GRIDTRIALBALANCE.Rows.Add(LEDGERROW("NAME"), Format(Val(DTOPBAL.Rows(0).Item("OPBALDR")), "0.000"), Format(Val(DTOPBAL.Rows(0).Item("OPBALCR")), "0.000"), Format(Val(DTOPBALRS.Rows(0).Item("OPBALDR")), "0.00"), Format(Val(DTOPBALRS.Rows(0).Item("OPBALCR")), "0.00"), 0.0, 0.0, 0.0, 0.0, Format(Val(CLODR), "0.000"), Format(Val(CLOCR), "0.000"), Format(Val(CLODRRS), "0.00"), Format(Val(CLOCRRS), "0.00"), LEDGERROW("GROUPNAME"))
            '        GRIDTRIALBALANCE.Rows(GRIDTRIALBALANCE.RowCount - 2).DefaultCellStyle.Font = New Font("CALIBRI", 9, FontStyle.Regular)
            '    End If
            '    TOTALOPBALDR += Val(DTOPBAL.Rows(0).Item("OPBALDR"))
            '    TOTALOPBALCR += Val(DTOPBAL.Rows(0).Item("OPBALCR"))
            '    TOTALOPBALDRRS += Val(DTOPBALRS.Rows(0).Item("OPBALDR"))
            '    TOTALOPBALCRRS += Val(DTOPBALRS.Rows(0).Item("OPBALCR"))

            '    TOTALDR += 0
            '    TOTALCR += 0
            '    TOTALDRRS += 0
            '    TOTALCRRS += 0

            '    TOTALCLODR += Val(CLODR)
            '    TOTALCLOCR += Val(CLOCR)
            '    TOTALCLODRRS += Val(CLODRRS)
            '    TOTALCLOCRRS += Val(CLOCRRS)
            'Next


            'GET ALL LEDGERS AND LOOP
            DTLEDGERS.Clear()
            cmd = New OleDbCommand("SELECT LEDGER_CODE AS NAME, GROUP_NAME AS GROUPNAME FROM  (ledgermaster INNER JOIN groupmaster ON ledgermaster.ledger_groupid = groupmaster.group_id) LEFT JOIN areamaster ON ledgermaster.ledger_areaid = areamaster.area_id WHERE 1=1 " & WHERECLAUSE & " AND GROUPMASTER.GROUP_NAME <> 'Stock In Hand' ORDER BY LEDGERMASTER.LEDGER_CODE", conn)
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

                OPDRRS = 0
                OPCRRS = 0
                CURRDRRS = 0
                CURRCRRS = 0
                CLODRRS = 0
                CLOCRRS = 0


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
                        TOTALOPBALDR += OPDR
                    Else
                        OPCR = OPCR - OPDR
                        OPDR = 0
                        TOTALOPBALDR += OPCR
                    End If
                    tempcmd.Dispose()


                    'FIRST GET OPENINGBALANCE
                    DTOPBAL.Clear()
                    tempcmd = New OleDbCommand("SELECT IIF(ISNULL(SUM(ACCOUNT_AMOUNT)) = TRUE,0, ROUND(SUM(ACCOUNT_AMOUNT),2)) AS OPBALDR FROM ACCOUNTMAST WHERE ACCOUNT_LEDGERCODE = '" & DTROWLEDGER("NAME") & "' AND ACCOUNT_BALORJAMAORPAID = 'Jama' AND ACCOUNT_DATE < #" & Format(dtfrom.Value, "MM/dd/yyyy") & "#", tempconn)
                    If tempconn.State = ConnectionState.Open Then tempconn.Close()
                    tempconn.Open()
                    DAOP = New OleDbDataAdapter(tempcmd)
                    DAOP.Fill(DTOPBAL)
                    If DTOPBAL.Rows.Count > 0 Then
                        OPDRRS = Format(Val(DTOPBAL.Rows(0).Item("OPBALDR")), "0.000")
                    End If
                    tempcmd.Dispose()
                    DTOPBAL = New DataTable
                    DAOP = New OleDbDataAdapter

                    tempcmd = New OleDbCommand("SELECT IIF(ISNULL(SUM(ACCOUNT_AMOUNT)) = TRUE,0, ROUND(SUM(ACCOUNT_AMOUNT),2))  AS OPBALCR FROM ACCOUNTMAST WHERE ACCOUNT_LEDGERCODE = '" & DTROWLEDGER("NAME") & "' AND ACCOUNT_BALORJAMAORPAID = 'Balance' AND ACCOUNT_DATE < #" & Format(dtfrom.Value, "MM/dd/yyyy") & "#", tempconn)
                    If tempconn.State = ConnectionState.Open Then tempconn.Close()
                    tempconn.Open()
                    DAOP = New OleDbDataAdapter(tempcmd)
                    DAOP.Fill(DTOPBAL)
                    If DTOPBAL.Rows.Count > 0 Then
                        OPCRRS = Format(Val(DTOPBAL.Rows(0).Item("OPBALCR")), "0.000")
                    End If
                    tempcmd.Dispose()

                    If OPDRRS - OPCRRS > 0 Then
                        OPDRRS = OPDRRS - OPCRRS
                        OPCRRS = 0
                        TOTALOPBALDRRS += OPDRRS
                    Else
                        OPCRRS = OPCRRS - OPDRRS
                        OPDRRS = 0
                        TOTALOPBALDRRS += OPCRRS
                    End If
                    tempcmd.Dispose()

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
                    If OPDR > 0 And OPCR > 0 Then
                        If Val(OPDR) - Val(OPCR) > 0 Then
                            OPDR = Val(OPDR) - Val(OPCR)
                            TOTALOPBALCR -= OPCR
                            OPCR = 0
                        Else
                            TOTALOPBALDR -= OPDR
                            OPCR = Val(OPCR) - Val(OPDR)
                            OPDR = 0
                        End If
                    End If

                    If Val(DTOPBAL.Rows(0).Item("OPBALDR")) > 0 Then TOTALOPBALDR += OPDR
                    If Val(DTOPBAL.Rows(0).Item("OPBALCR")) > 0 Then TOTALOPBALCR += OPCR
                End If



                'ADD OPBAL FROM LEDGERMASTER ALSO IN THE ABOVE VARIABLES
                DTOPBAL.Clear()
                tempcmd = New OleDbCommand("SELECT IIF(LEDGER_DRCRRS = 'Cr.', LEDGER_OPBALRS,0) AS OPBALDR, IIF(LEDGER_DRCRRS = 'Dr.', LEDGER_OPBALRS,0) AS OPBALCR FROM LEDGERMASTER WHERE LEDGER_CODE = '" & DTROWLEDGER("NAME") & "'", tempconn)
                If tempconn.State = ConnectionState.Open Then tempconn.Close()
                tempconn.Open()
                DAOP = New OleDbDataAdapter(tempcmd)
                DAOP.Fill(DTOPBAL)
                If DTOPBAL.Rows.Count > 0 Then
                    OPDRRS += Format(Val(DTOPBAL.Rows(0).Item("OPBALDR")), "0.00")
                    OPCRRS += Format(Val(DTOPBAL.Rows(0).Item("OPBALCR")), "0.00")
                    If OPDRRS > 0 And OPCRRS > 0 Then
                        If Val(OPDRRS) - Val(OPCRRS) > 0 Then
                            OPDRRS = Val(OPDRRS) - Val(OPCRRS)
                            TOTALOPBALCRRS -= OPCRRS
                            OPCRRS = 0
                        Else
                            TOTALOPBALDRRS -= OPDRRS
                            OPCRRS = Val(OPCRRS) - Val(OPDRRS)
                            OPDRRS = 0
                        End If
                    End If

                    If Val(DTOPBAL.Rows(0).Item("OPBALDR")) > 0 Then TOTALOPBALDRRS += OPDRRS
                    If Val(DTOPBAL.Rows(0).Item("OPBALCR")) > 0 Then TOTALOPBALCRRS += OPCRRS
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


                DT = New DataTable
                'NOW GET THE TRANSACTIONS AND THEN COMPARE FOR SELECTED DATES
                If chkdate.CheckState = CheckState.Unchecked Then cmd = New OleDbCommand("SELECT T.NAME, SUM(T.DR) AS DR, SUM(T.CR) AS CR FROM (SELECT ACCOUNT_LEDGERCODE AS NAME, SUM(ACCOUNT_AMOUNT) AS DR, 0 AS CR FROM ACCOUNTMAST WHERE ACCOUNT_BALORJAMAORPAID= 'Jama' " & WHERECLAUSE & " AND ACCOUNT_LEDGERCODE = '" & DTROWLEDGER("NAME") & "' GROUP BY ACCOUNT_LEDGERCODE UNION ALL SELECT ACCOUNT_LEDGERCODE AS NAME, 0 AS DR, SUM(ACCOUNT_AMOUNT) AS CR FROM ACCOUNTMAST WHERE ACCOUNT_BALORJAMAORPAID = 'Balance' " & WHERECLAUSE & " AND ACCOUNT_LEDGERCODE = '" & DTROWLEDGER("NAME") & "'  GROUP BY ACCOUNT_LEDGERCODE) AS T WHERE NAME <> '' GROUP BY T.NAME", conn) Else cmd = New OleDbCommand("SELECT T.NAME, SUM(DR) AS DR, SUM(CR) AS CR FROM (SELECT ACCOUNT_LEDGERCODE AS NAME, SUM(ACCOUNT_AMOUNT) AS DR, 0 AS CR FROM ACCOUNTMAST WHERE ACCOUNT_BALORJAMAORPAID= 'Jama' AND ACCOUNT_DATE BETWEEN #" & Format(dtfrom.Value, "MM/dd/yyyy") & "# AND #" & Format(dtto.Value, "MM/dd/yyyy") & "# AND ACCOUNT_LEDGERCODE = '" & DTROWLEDGER("NAME") & "' " & WHERECLAUSE & " GROUP BY ACCOUNT_LEDGERCODE UNION ALL SELECT ACCOUNT_LEDGERCODE AS NAME, 0 AS DR, SUM(ACCOUNT_AMOUNT) AS CR FROM ACCOUNTMAST WHERE ACCOUNT_BALORJAMAORPAID = 'Balance' AND ACCOUNT_DATE BETWEEN #" & Format(dtfrom.Value, "MM/dd/yyyy") & "# AND #" & Format(dtto.Value, "MM/dd/yyyy") & "# AND ACCOUNT_LEDGERCODE = '" & DTROWLEDGER("NAME") & "' " & WHERECLAUSE & "  GROUP BY ACCOUNT_LEDGERCODE) AS T WHERE NAME <> '' GROUP BY T.NAME", conn)
                If conn.State = ConnectionState.Open Then conn.Close()
                conn.Open()
                da = New OleDbDataAdapter(cmd)
                da.Fill(DT)
                cmd.Dispose()
                If DT.Rows.Count > 0 Then
                    CURRDRRS = Format(Val(DT.Rows(0).Item("DR")), "0.00")
                    CURRCRRS = Format(Val(DT.Rows(0).Item("CR")), "0.00")
                    TOTALDRRS += CURRDRRS
                    TOTALCRRS += CURRCRRS
                End If
                If (OPDRRS + CURRDRRS) - (OPCRRS + CURRCRRS) > 0 Then
                    CLODRRS = (OPDRRS + CURRDRRS) - (OPCRRS + CURRCRRS)
                    CLOCRRS = 0
                    TOTALCLODRRS += CLODRRS
                Else
                    CLODRRS = 0
                    CLOCRRS = (OPCRRS + CURRCRRS) - (OPDRRS + CURRDRRS)
                    TOTALCLOCRRS += CLOCRRS
                End If

                If CHKREMOVE0.Checked = True AndAlso Val(CLODR) = 0 And Val(CLOCR) = 0 And Val(CLODRRS) = 0 And Val(CLOCRRS) = 0 Then GoTo SKIPLINE
                If Val(OPDR) <> 0 Or Val(OPCR) <> 0 Or Val(CURRDR) <> 0 Or Val(CURRCR) <> 0 Or Val(CLODR) <> 0 Or Val(CLOCR) <> 0 Or Val(OPDRRS) <> 0 Or Val(OPCRRS) <> 0 Or Val(CURRDRRS) <> 0 Or Val(CURRCRRS) <> 0 Or Val(CLODRRS) <> 0 Or Val(CLOCRRS) <> 0 Then GRIDTRIALBALANCE.Rows.Add(DTROWLEDGER("NAME"), Format(Val(OPDR), "0.000"), Format(Val(OPCR), "0.000"), Format(Val(OPDRRS), "0.00"), Format(Val(OPCRRS), "0.00"), Format(Val(CURRDR), "0.000"), Format(Val(CURRCR), "0.000"), Format(Val(CURRDRRS), "0.00"), Format(Val(CURRCRRS), "0.00"), Format(Val(CLODR), "0.000"), Format(Val(CLOCR), "0.000"), Format(Val(CLODRRS), "0.00"), Format(Val(CLOCRRS), "0.00"), DTROWLEDGER("GROUPNAME"))
SKIPLINE:
                DT.Clear()
                DTOPBAL.Clear()
                da.Dispose()

            Next


            'If chkdate.CheckState = CheckState.Unchecked Then cmd = New OleDbCommand("SELECT T.NAME, SUM(DR) AS DR, SUM(CR) AS CR, SUM(DRRS) AS DRRS, SUM(CRRS) AS CRRS FROM (SELECT ACCOUNT_LEDGERCODE AS NAME, SUM(ACCOUNT_NETTWT) AS DR, 0 AS CR, SUM(ACCOUNT_AMOUNT) AS DRRS, 0 AS CRRS FROM ACCOUNTMAST WHERE ACCOUNT_BALORJAMAORPAID= 'Jama' " & WHERECLAUSE & " GROUP BY ACCOUNT_LEDGERCODE UNION ALL SELECT ACCOUNT_LEDGERCODE AS NAME, 0 AS DR, SUM(ACCOUNT_NETTWT) AS CR, 0 AS DRRS, SUM(ACCOUNT_AMOUNT) AS CRRS FROM ACCOUNTMAST WHERE ACCOUNT_BALORJAMAORPAID = 'Balance' " & WHERECLAUSE & " GROUP BY ACCOUNT_LEDGERCODE) AS T WHERE NAME <> '' GROUP BY T.NAME", conn) Else cmd = New OleDbCommand("SELECT T.NAME, SUM(DR) AS DR, SUM(CR) AS CR, SUM(DRRS) AS DRRS, SUM(CRRS) AS CRRS FROM (SELECT ACCOUNT_LEDGERCODE AS NAME, SUM(ACCOUNT_NETTWT) AS DR, 0 AS CR, SUM(ACCOUNT_AMOUNT) AS DRRS, 0 AS CRRS FROM ACCOUNTMAST WHERE ACCOUNT_BALORJAMAORPAID= 'Jama' AND ACCOUNT_DATE BETWEEN #" & Format(dtfrom.Value, "MM/dd/yyyy") & "# AND #" & Format(dtto.Value, "MM/dd/yyyy") & "# " & WHERECLAUSE & " GROUP BY ACCOUNT_LEDGERCODE UNION ALL SELECT ACCOUNT_LEDGERCODE AS NAME, 0 AS DR, SUM(ACCOUNT_NETTWT) AS CR, 0 AS DRRS, SUM(ACCOUNT_AMOUNT) AS CRRS FROM ACCOUNTMAST WHERE ACCOUNT_BALORJAMAORPAID = 'Balance' AND ACCOUNT_DATE BETWEEN #" & Format(dtfrom.Value, "MM/dd/yyyy") & "# AND #" & Format(dtto.Value, "MM/dd/yyyy") & "#  " & WHERECLAUSE & " GROUP BY ACCOUNT_LEDGERCODE) AS T WHERE NAME <> '' GROUP BY T.NAME", conn)
            'If conn.State = ConnectionState.Open Then conn.Close()
            'conn.Open()
            'da = New OleDbDataAdapter(cmd)
            'da.Fill(DT)

            'For Each DTROW As DataRow In DT.Rows

            '    Dim DTOPBAL As New DataTable
            '    If chkdate.CheckState = CheckState.Unchecked Then tempcmd = New OleDbCommand("SELECT IIF(LEDGER_DRCRWT = 'Cr.', LEDGER_OPBALWT,0) AS OPBALDR, IIF(LEDGER_DRCRWT = 'Dr.', LEDGER_OPBALWT,0) AS OPBALCR, IIF(LEDGER_DRCRRS = 'Cr.', LEDGER_OPBALRS,0) AS OPBALDRRS, IIF(LEDGER_DRCRRS = 'Dr.', LEDGER_OPBALRS,0) AS OPBALCRRS FROM LEDGERMASTER WHERE LEDGER_CODE = '" & DTROW("NAME") & "'", tempconn) Else tempcmd = New OleDbCommand("SELECT ROUND( IIF(SUM(NETTWT) < 0 , SUM(NETTWT) , 0),3) AS OPBALDR,  ROUND(IIF(SUM(NETTWT) > 0 , SUM(NETTWT) , 0),3) AS OPBALCR, ROUND( IIF(SUM(AMOUNT) < 0 , SUM(AMOUNT) , 0),3) AS OPBALDRRS,  ROUND(IIF(SUM(AMOUNT) > 0 , SUM(AMOUNT) , 0),3) AS OPBALCRRS FROM TRIALBALANCE WHERE CODE = '" & DTROW("NAME") & "' AND SDATE < #" & Format(dtfrom.Value, "MM/dd/yyyy") & "#", tempconn)
            '    If tempconn.State = ConnectionState.Open Then tempconn.Close()
            '    tempconn.Open()
            '    da = New OleDbDataAdapter(tempcmd)
            '    da.Fill(DTOPBAL)

            '    If DTOPBAL.Rows.Count > 0 Then
            '        If (Val(DTROW("DR")) + Val(DTOPBAL.Rows(0).Item("OPBALDR"))) - (Val(DTROW("CR")) + Val(DTOPBAL.Rows(0).Item("OPBALCR"))) > 0 Then
            '            CLODR = (Val(DTROW("DR")) + Val(DTOPBAL.Rows(0).Item("OPBALDR"))) - (Val(DTROW("CR")) + Val(DTOPBAL.Rows(0).Item("OPBALCR")))
            '            CLOCR = 0
            '        Else
            '            CLODR = 0
            '            CLOCR = (Val(DTROW("CR")) + Val(DTOPBAL.Rows(0).Item("OPBALCR"))) - (Val(DTROW("DR")) + Val(DTOPBAL.Rows(0).Item("OPBALDR")))
            '        End If

            '        If (Val(DTROW("DRRS")) + Val(DTOPBAL.Rows(0).Item("OPBALDRRS"))) - (Val(DTROW("CRRS")) + Val(DTOPBAL.Rows(0).Item("OPBALCRRS"))) > 0 Then
            '            CLODRRS = (Val(DTROW("DRRS")) + Val(DTOPBAL.Rows(0).Item("OPBALDRRS"))) - (Val(DTROW("CRRS")) + Val(DTOPBAL.Rows(0).Item("OPBALCRRS")))
            '            CLOCRRS = 0
            '        Else
            '            CLODRRS = 0
            '            CLOCRRS = (Val(DTROW("CRRS")) + Val(DTOPBAL.Rows(0).Item("OPBALCRRS"))) - (Val(DTROW("DRRS")) + Val(DTOPBAL.Rows(0).Item("OPBALDRRS")))
            '        End If

            '        If Val(DTOPBAL.Rows(0).Item("OPBALDR")) > 0 Or Val(DTOPBAL.Rows(0).Item("OPBALCR")) > 0 Or Val(DTROW("DR")) > 0 Or Val(DTROW("CR")) > 0 Or Val(CLODR) > 0 Or Val(CLOCR) > 0 Or Val(DTOPBAL.Rows(0).Item("OPBALDRRS")) > 0 Or Val(DTOPBAL.Rows(0).Item("OPBALCRRS")) > 0 Or Val(DTROW("DRRS")) > 0 Or Val(DTROW("CRRS")) > 0 Or Val(CLODRRS) > 0 Or Val(CLOCRRS) > 0 Then
            '            GRIDTRIALBALANCE.Rows.Add(DTROW("NAME"), Format(Val(DTOPBAL.Rows(0).Item("OPBALDR")), "0.000"), Format(Val(DTOPBAL.Rows(0).Item("OPBALCR")), "0.000"), Format(Val(DTOPBAL.Rows(0).Item("OPBALDRRS")), "0.00"), Format(Val(DTOPBAL.Rows(0).Item("OPBALCRRS")), "0.00"), Format(Val(DTROW("DR")), "0.000"), Format(Val(DTROW("CR")), "0.000"), Format(Val(DTROW("DRRS")), "0.00"), Format(Val(DTROW("CRRS")), "0.00"), Format(Val(CLODR), "0.000"), Format(Val(CLOCR), "0.000"), Format(Val(CLODRRS), "0.00"), Format(Val(CLOCRRS), "0.00"))
            '            GRIDTRIALBALANCE.Rows(GRIDTRIALBALANCE.RowCount - 2).DefaultCellStyle.Font = New Font("CALIBRI", 9, FontStyle.Regular)
            '            TOTALOPBALDR += Val(DTOPBAL.Rows(0).Item("OPBALDR"))
            '            TOTALOPBALCR += Val(DTOPBAL.Rows(0).Item("OPBALCR"))
            '            TOTALOPBALDRRS += Val(DTOPBAL.Rows(0).Item("OPBALDRRS"))
            '            TOTALOPBALCRRS += Val(DTOPBAL.Rows(0).Item("OPBALCRRS"))

            '            TOTALDR += Val(DTROW("DR"))
            '            TOTALCR += Val(DTROW("CR"))
            '            TOTALDRRS += Val(DTROW("DRRS"))
            '            TOTALCRRS += Val(DTROW("CRRS"))

            '            TOTALCLODR += Val(CLODR)
            '            TOTALCLOCR += Val(CLOCR)
            '            TOTALCLODRRS += Val(CLODRRS)
            '            TOTALCLOCRRS += Val(CLOCRRS)
            '        End If
            '    End If

            'Next




            GRIDTRIALBALANCE.Rows.Add("==================================", "============", "============", "===============", "===============", "============", "============", "===============", "===============", "============", "============", "===============", "===============")
            GRIDTRIALBALANCE.Rows(GRIDTRIALBALANCE.RowCount - 2).DefaultCellStyle.Font = New Font("CALIBRI", 9, FontStyle.Regular)
            GRIDTRIALBALANCE.Rows.Add("TOTAL", Format(TOTALOPBALDR, "0.000"), Format(TOTALOPBALCR, "0.000"), Format(TOTALOPBALDRRS, "0.00"), Format(TOTALOPBALCRRS, "0.00"), Format(TOTALDR, "0.000"), Format(TOTALCR, "0.000"), Format(TOTALDRRS, "0.00"), Format(TOTALCRRS, "0.00"), Format(TOTALCLODR, "0.000"), Format(TOTALCLOCR, "0.000"), Format(TOTALCLODRRS, "0.00"), Format(TOTALCLOCRRS, "0.00"))
            GRIDTRIALBALANCE.Rows.Add("==================================", "============", "============", "===============", "===============", "============", "============", "===============", "===============", "============", "============", "===============", "===============")
            GRIDTRIALBALANCE.Rows(GRIDTRIALBALANCE.RowCount - 2).DefaultCellStyle.Font = New Font("CALIBRI", 9, FontStyle.Regular)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TBWtAmount_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Keys.Escape Then
                Me.Close()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TBWtAmount_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try
            If GRIDTRIALBALANCE.RowCount = 0 Then Exit Sub
            For i = 0 To 100
                tempcol(i) = ""
                tempval(i) = ""
            Next


            Dim NEWDT As New DataTable
            If tempconn.State = ConnectionState.Open Then tempconn.Close()
            tempconn.Open()
            tempcmd = New OleDbCommand("DELETE FROM TEMPTBWTAMT", tempconn)
            da = New OleDbDataAdapter(tempcmd)
            da.Fill(NEWDT)
            tempcmd.Dispose()

            If MsgBox("Wish to Print?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub


            tempcol(0) = "NAME"
            tempcol(1) = "OPDR"
            tempcol(2) = "OPCR"
            tempcol(3) = "OPDRRS"
            tempcol(4) = "OPCRRS"
            tempcol(5) = "DEBIT"
            tempcol(6) = "CREDIT"
            tempcol(7) = "DEBITRS"
            tempcol(8) = "CREDITRS"
            tempcol(9) = "CLDR"
            tempcol(10) = "CLCR"
            tempcol(11) = "CLDRRS"
            tempcol(12) = "CLCRRS"
            tempcol(13) = "GROUPNAME"


            For Each ROW As DataGridViewRow In GRIDTRIALBALANCE.Rows

                If ROW.Cells(GNAME.Index).Value = "==================================" Then Exit For

                tempval(0) = "'" & ROW.Cells(GNAME.Index).Value & "'"
                tempval(1) = Val(ROW.Cells(GOPDR.Index).Value)
                tempval(2) = Val(ROW.Cells(GOPCR.Index).Value)
                tempval(3) = Val(ROW.Cells(GOPDRRS.Index).Value)
                tempval(4) = Val(ROW.Cells(GOPCRRS.Index).Value)
                tempval(5) = Val(ROW.Cells(GDR.Index).Value)
                tempval(6) = Val(ROW.Cells(GCR.Index).Value)
                tempval(7) = Val(ROW.Cells(GDRRS.Index).Value)
                tempval(8) = Val(ROW.Cells(GCRRS.Index).Value)
                tempval(9) = Val(ROW.Cells(GCLODR.Index).Value)
                tempval(10) = Val(ROW.Cells(GCLOCR.Index).Value)
                tempval(11) = Val(ROW.Cells(GCLODRRS.Index).Value)
                tempval(12) = Val(ROW.Cells(GCLOCRRS.Index).Value)
                tempval(13) = "'" & ROW.Cells(GGROUPNAME.Index).Value & "'"

                insert("TEMPTBWTAMT", tempcol, tempval)
            Next

            Dim OBJTB As New TrialBalanceDesign
            OBJTB.MdiParent = MDIMain
            OBJTB.FRMSTRING = "TBWTAMT"
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
End Class