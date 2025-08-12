
Imports System.Data.OleDb

Public Class LabFilter

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub

    Private Sub LabFilter_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                Me.Close()
            ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.S Then       'for SHOW REPORT
                Call cmdShowReport_Click(sender, e)
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub LabFilter_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        TXTLOTNO.Text = ""
        CMBPART.Text = ""
    End Sub

    Private Sub cmdShowReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShowReport.Click
        Try

            Dim WHERE As String = " WHERE 1=1"
            If Val(TXTLOTNO.Text.Trim) <> 0 Then WHERE = WHERE & " AND LOTNO = '" & Val(TXTLOTNO.Text.Trim) & "'"
            If CMBPART.Text.Trim <> "" Then WHERE = WHERE & " AND PARTNO = '" & Val(TXTLOTNO.Text.Trim) & "'"
            
            Dim PERIOD As String = ""
            If chkdate.CheckState = CheckState.Checked Then
                WHERE = WHERE & " AND DATE >= #" & Format(dtpfrom.Value.Date, "MM/dd/yyyy") & "# AND DATE <=# " & Format(dtpto.Value.Date, "MM/dd/yyyy") & "#"
                PERIOD = Format(dtpfrom.Value.Date, "dd/MM/yyyy") & " To " & Format(dtpto.Value.Date, "dd/MM/yyyy")
            Else
                PERIOD = Format(startdate, "dd/MM/yyyy") & " To " & Format(enddate, "dd/MM/yyyy")
            End If

            dt = New DataTable()
            If tempconn.State = ConnectionState.Open Then tempconn.Close()
            tempconn.Open()

            If RBDETAILS.Checked = True Then

                dt = New DataTable()
                If tempconn.State = ConnectionState.Open Then
                    tempconn.Close()
                End If
                tempconn.Open()

                tempcmd = New OleDbCommand("SELECT A.ACCNO AS LOTNO, A.PARTNO, A.NARRATION AS REFNO, '' AS NARRATION, A.SAMPLE AS WT, A.NETTWT, VAL(A.OUTWT) AS PARTYWT, A.LEDGERNAME, A.DATE AS ISSDATE, A.DATE AS RECDATE, A.SAMPLEPURITY AS MELTING, VAL(0.00) AS LABREP, VAL(0.00) AS PARTYREP, VAL(0.00) AS FACLAB, VAL(0.00) AS FACPARTY, VAL(0.00) AS LABPARTY, VAL(0.00) AS FACLABWTDIFF,VAL(0.00) AS FACPARTYWTDIFF,VAL(0.00) AS LABPARTYWTDIFF, A.TYPE  FROM LABSMPREPORT A  " & WHERE & " order by A.ACCNO, A.PARTNO", tempconn)
                da = New OleDbDataAdapter(tempcmd)
                da.Fill(dt)

                If Val(TXTLOTNO.Text.Trim) <> 0 Then tempcmd = New OleDbCommand("SELECT B.LAB_LOTNO AS LOTNO, B.LAB_PARTNO AS PARTNO, B.LAB_TYPE AS TYPE, B.LAB_REFNO AS REFNO FROM LABREPORT B WHERE B.LAB_LOTNO = " & Val(TXTLOTNO.Text.Trim) & " Order by B.LAB_LOTNO ", tempconn) Else tempcmd = New OleDbCommand("SELECT B.LAB_LOTNO AS LOTNO, B.LAB_PARTNO AS PARTNO, B.LAB_TYPE AS TYPE, B.LAB_REFNO AS REFNO FROM LABREPORT B order by B.LAB_LOTNO, B.LAB_PARTNO", tempconn)
                Dim DA1 As New OleDbDataAdapter(tempcmd)
                Dim DT1 As New DataTable
                DA1.Fill(DT1)


                Dim rows_to_remove As New List(Of DataRow)()
                For Each row1 As DataRow In dt.Rows
                    For Each row2 As DataRow In DT1.Rows
                        If IsDBNull(row2("PARTNO")) = True Then row2("PARTNO") = ""
                        If row1("LOTNO") = row2("LOTNO") And row1("TYPE").ToString = row2("TYPE").ToString And row1("REFNO") = row2("REFNO") And row1("PARTNO") = row2("PARTNO") Then
                            rows_to_remove.Add(row1)
                        End If
                    Next
                Next

                For Each row As DataRow In rows_to_remove
                    dt.Rows.Remove(row)
                    dt.AcceptChanges()
                Next

                For Each DTROW As DataRow In dt.Rows
                    DTROW("RECDATE") = DBNull.Value
                    If ClientName = "JAINAM" Then DTROW("LEDGERNAME") = "OUR TUNCH" Else DTROW("LEDGERNAME") = DBNull.Value
                Next

                'OLD CODE
                'tempcmd = New OleDbCommand("SELECT mfgmaster.mfg_lotno AS LOTNO, mfgmaster.MFG_REFNO AS REFNO,itemstock.item_grosswt AS WT, itemstock.item_NETTWT AS NETTWT, VAL(0.00) AS PARTYWT, itemstock.item_purity AS MELTING, VAL(0.00) AS LABREP, VAL(0.00) AS PARTYREP, VAL(0.00) AS FACLAB, VAL(0.00) AS FACPARTY, VAL(0.00) AS LABPARTY, VAL(0.00) AS WTDIFF FROM itemstock INNER JOIN mfgmaster ON itemstock.item_no = mfgmaster.mfg_no where MFG_LOTNO NOT IN (SELECT LAB_LOTNO FROM LABREPORT ) order by MFG_LOTNO UNION ALL SELECT LAB_LOTNO AS LOTNO, LAB_REFNO AS REFNO, LAB_WT AS WT, LAB_NETTWT AS NETTWT, LAB_PARTYWT AS PARTYWT, LAB_MELTING AS MELTING, LAB_LABREP AS LABREP, LAB_PARTYREP AS PARTYREP, LAB_FACLAB AS FACLAB, LAB_FACPARTY AS FACPARTY, LAB_LABPARTY AS LABPARTY, LAB_WTDIFF AS WTDIFF  FROM LABREPORT ORDER BY LOTNO", tempconn)
                Dim NEWTEMPCMD As New OleDbCommand
                If Val(TXTLOTNO.Text.Trim) <> 0 Then NEWTEMPCMD = New OleDbCommand("SELECT LABREPORT.LAB_LOTNO AS LOTNO, LABREPORT.LAB_PARTNO AS PARTNO, LABREPORT.LAB_REFNO AS REFNO, LABREPORT.LAB_NARRATION AS NARRATION, LABREPORT.LAB_WT AS WT, LABREPORT.LAB_NETTWT AS NETTWT, LABREPORT.LAB_PARTYWT AS PARTYWT, ledgermaster.ledger_code AS LEDGERNAME, LABREPORT.LAB_ISSDATE AS ISSDATE, LABREPORT.LAB_RECDATE AS RECDATE, LABREPORT.LAB_MELTING AS MELTING, LABREPORT.LAB_LABREP AS LABREP, LABREPORT.LAB_PARTYREP AS PARTYREP, LABREPORT.LAB_FACLAB AS FACLAB, LABREPORT.LAB_FACPARTY AS FACPARTY, LABREPORT.LAB_LABPARTY AS LABPARTY, LABREPORT.LAB_FACLABWTDIFF AS FACLABWTDIFF, LABREPORT.LAB_FACPARTYWTDIFF AS FACPARTYWTDIFF, LABREPORT.LAB_LABPARTYWTDIFF AS LABPARTYWTDIFF, LABREPORT.LAB_TYPE AS TYPE FROM LABREPORT INNER JOIN ledgermaster ON LABREPORT.LAB_LEDGERID = ledgermaster.ledger_id WHERE LABREPORT.LAB_LOTNO = " & Val(TXTLOTNO.Text.Trim), tempconn) Else NEWTEMPCMD = New OleDbCommand("SELECT LABREPORT.LAB_LOTNO AS LOTNO, LABREPORT.LAB_PARTNO AS PARTNO, LABREPORT.LAB_REFNO AS REFNO, LABREPORT.LAB_NARRATION AS NARRATION, LABREPORT.LAB_WT AS WT, LABREPORT.LAB_NETTWT AS NETTWT, LABREPORT.LAB_PARTYWT AS PARTYWT, ledgermaster.ledger_code AS LEDGERNAME, LABREPORT.LAB_ISSDATE AS ISSDATE, LABREPORT.LAB_RECDATE AS RECDATE, LABREPORT.LAB_MELTING AS MELTING, LABREPORT.LAB_LABREP AS LABREP, LABREPORT.LAB_PARTYREP AS PARTYREP, LABREPORT.LAB_FACLAB AS FACLAB, LABREPORT.LAB_FACPARTY AS FACPARTY, LABREPORT.LAB_LABPARTY AS LABPARTY, LABREPORT.LAB_FACLABWTDIFF AS FACLABWTDIFF, LABREPORT.LAB_FACPARTYWTDIFF AS FACPARTYWTDIFF, LABREPORT.LAB_LABPARTYWTDIFF AS LABPARTYWTDIFF, LABREPORT.LAB_TYPE AS TYPE FROM LABREPORT INNER JOIN ledgermaster ON LABREPORT.LAB_LEDGERID = ledgermaster.ledger_id ORDER BY LABREPORT.LAB_LOTNO , LABREPORT.LAB_PARTNO", tempconn)
                If tempconn.State = ConnectionState.Open Then tempconn.Close()
                tempconn.Open()
                Dim DANEW As OleDbDataAdapter = New OleDbDataAdapter(NEWTEMPCMD)
                Dim NEWDT As New DataTable
                DANEW.Fill(NEWDT)
                For Each NEWDTROW As DataRow In NEWDT.Rows
                    dt.ImportRow(NEWDTROW)
                Next

                Dim objrep As New clsReportDesigner("Running Lab Report", System.AppDomain.CurrentDomain.BaseDirectory & "Running Lab Report.xlsx", 2)
                objrep.RUNNINGLABREPORT_EXCEL(dt, PERIOD)


            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPART_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBPART.Enter
        Try
            Dim dt As New DataTable
            CMBPART.Items.Clear()
            CMBPART.Text = ""
            'FILL PART NO WITH RESPECT TO ENTERED LOTNO
            tempcmd = New OleDbCommand("SELECT MFG_TOTALPARTS AS TOTALPARTS FROM MFGMASTER WHERE MFG_LOTNO = " & Val(TXTLOTNO.Text.Trim), tempconn)
            da = New OleDbDataAdapter(tempcmd)
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For I As Integer = 1 To Val(dt.Rows(0).Item("TOTALPARTS"))
                    CMBPART.Items.Add("Part(" & I & ")")
                Next
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class