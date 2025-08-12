
Imports System.Data.OleDb

Public Class mfgfilter

    Private Sub mfgfilter_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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

    Private Sub mfgfilter_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

        tempcondition = ""
        fillcmb(cmbprocess, "Process_name", "processmaster", tempcondition)
        If frmmfgloss = False Then fillac() Else GPLOSS.Visible = True

    End Sub

    Sub fillac()
        'filling all groups and subgroups
        If frmmfgloss = False Then
            cmd = New OleDbCommand("select distinct ledger_name from mfgwastage", conn)
        Else
            cmd = New OleDbCommand("select distinct LEDGERNAME from PARTYLOSSREPORT", conn)
        End If
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If
        conn.Open()
        dr = cmd.ExecuteReader()
        If dr.HasRows Then

            While (dr.Read())
                gridac.Rows.Add(0, dr(0))
            End While

        End If
    End Sub

    Sub getFromToDate()
        a1 = DatePart(DateInterval.Day, dtpfrom.Value)
        a2 = DatePart(DateInterval.Month, dtpfrom.Value)
        a3 = DatePart(DateInterval.Year, dtpfrom.Value)
        fromD = "(" & a3 & "," & a2 & "," & a1 & ")"

        a11 = DatePart(DateInterval.Day, dtpto.Value)
        a12 = DatePart(DateInterval.Month, dtpto.Value)
        a13 = DatePart(DateInterval.Year, dtpto.Value)
        toD = "(" & a13 & "," & a12 & "," & a11 & ")"
    End Sub

    Private Sub cmdShowReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShowReport.Click
        Try
            Main()
            If frmmfgwastage = True Then

                Dim CONDITION As String = ""
                Dim HEADER As String = ""
                For Each ROW As DataGridViewRow In gridac.Rows
                    If Convert.ToBoolean(ROW.Cells("CHK").Value) = True Then
                        If CONDITION = "" Then
                            CONDITION = " WHERE (LEDGERNAME = '" & ROW.Cells("GNAME").Value & "'"
                            HEADER = " (" & ROW.Cells("GNAME").Value
                        Else
                            CONDITION = CONDITION & " OR LEDGERNAME = '" & ROW.Cells("GNAME").Value & "'"
                            HEADER = HEADER & ", " & ROW.Cells("GNAME").Value
                        End If
                    End If
                Next
                If CONDITION <> "" Then
                    CONDITION = CONDITION & ")"
                    HEADER = HEADER & ")"
                Else
                    CONDITION = " WHERE 1 = 1"
                End If

                If txtlotno.Text.Trim <> "" Then CONDITION = CONDITION & " AND LOTNO = '" & txtlotno.Text.Trim & "'"
                If cmbprocess.Text.Trim <> "" Then CONDITION = CONDITION & " AND PROCESSNAME = '" & cmbprocess.Text.Trim & "'"
                If chkdate.CheckState = CheckState.Checked Then CONDITION = CONDITION & " AND DATE >= #" & Format(dtpfrom.Value.Date, "MM/dd/yyyy") & "# AND DATE <=# " & Format(dtpto.Value.Date, "MM/dd/yyyy") & "#"

                dt = New DataTable()
                If tempconn.State = ConnectionState.Open Then tempconn.Close()
                tempconn.Open()
                tempcmd = New OleDbCommand("SELECT DATE, ITEMCODE, JAMAPURITY, JAMAGROSSWT, JAMANETTWT, LOTNO, PROCESSNAME, INWT, OUTWT, WASTAGE, NETTWT, WASTAGEPURITY , PARTNO, REQMELTING FROM WASTAGEREPORT " & CONDITION & " ORDER BY DATE, LOTNO", tempconn)
                da = New OleDbDataAdapter(tempcmd)
                da.Fill(dt)
                tempconn.Close()
                da.Dispose()

                If dt.Rows.Count = 0 Then
                    MsgBox("No Records In Wastage", MsgBoxStyle.Critical, "Magic Gold")
                    Exit Sub
                End If

                Dim objrep As New clsReportDesigner("Wastage Report", System.AppDomain.CurrentDomain.BaseDirectory & "Wastage Report.xlsx", 2)
                objrep.WASTAGE_REPORT_EXCEL(dt, HEADER)

            Else

                Dim CONDITION As String = ""
                For Each ROW As DataGridViewRow In gridac.Rows
                    If Convert.ToBoolean(ROW.Cells("CHK").Value) = True Then
                        If CONDITION = "" Then
                            CONDITION = " WHERE (LEDGERNAME = '" & ROW.Cells("GNAME").Value & "'"
                        Else
                            CONDITION = CONDITION & " OR LEDGERNAME = '" & ROW.Cells("GNAME").Value & "'"
                        End If
                    End If
                Next
                If CONDITION <> "" Then
                    CONDITION = CONDITION & ")"
                Else
                    CONDITION = " WHERE 1 = 1"
                End If

                If txtlotno.Text.Trim <> "" Then CONDITION = CONDITION & " AND LOTNO = " & txtlotno.Text.Trim
                If cmbprocess.Text.Trim <> "" Then CONDITION = CONDITION & " AND PROCESSNAME = '" & cmbprocess.Text.Trim & "'"
                If chkdate.CheckState = CheckState.Checked Then CONDITION = CONDITION & " AND DATE >= #" & Format(dtpfrom.Value.Date, "MM/dd/yyyy") & "# AND DATE <=# " & Format(dtpto.Value.Date, "MM/dd/yyyy") & "#"

                dt = New DataTable()
                If tempconn.State = ConnectionState.Open Then tempconn.Close()
                tempconn.Open()
                If RBMFGLOSS.Checked = True Then
                    tempcmd = New OleDbCommand("SELECT DATE, LOTNO, PROCESSNAME, INWT, OUTWT, LOSS, NETTWT, LOSSPURITY, PARTNO, MAXLOSS, [EXTRA LOSS] AS EXTRALOSS, REQPURITY  FROM LOSSREPORT " & CONDITION & " ORDER BY DATE, LOTNO", tempconn)
                ElseIf RBPARTYLOSS.Checked = True Then
                    tempcmd = New OleDbCommand("SELECT DATE, LOTNO, PROCESSNAME, INWT, OUTWT, LOSS, NETTWT, LOSSPURITY, PARTNO, MAXLOSS, [EXTRA LOSS] AS EXTRALOSS, REQPURITY  FROM PARTYLOSSREPORT " & CONDITION & " ORDER BY DATE, LOTNO", tempconn)
                ElseIf RBALL.Checked = True Then
                    tempcmd = New OleDbCommand("SELECT DATE, LOTNO, PROCESSNAME, INWT, OUTWT, LOSS, NETTWT, LOSSPURITY, PARTNO, MAXLOSS, [EXTRA LOSS] AS EXTRALOSS, REQPURITY  FROM PARTYLOSSREPORT " & CONDITION & " ORDER BY DATE, LOTNO UNION ALL SELECT DATE, LOTNO, PROCESSNAME, INWT, OUTWT, LOSS, NETTWT, LOSSPURITY, PARTNO, MAXLOSS, [EXTRA LOSS] AS EXTRALOSS, REQPURITY  FROM LOSSREPORT " & CONDITION & " ORDER BY DATE, LOTNO", tempconn)
                End If
                da = New OleDbDataAdapter(tempcmd)
                da.Fill(dt)
                tempconn.Close()
                da.Dispose()
                If dt.Rows.Count = 0 Then
                    MsgBox("No Records In Loss", MsgBoxStyle.Critical, "Magic Gold")
                    Exit Sub
                End If

                Dim objrep As New clsReportDesigner("Loss Report", System.AppDomain.CurrentDomain.BaseDirectory & "Loss Report.xlsx", 2)
                objrep.LOSS_REPORT_EXCEL(dt)

            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub

    Private Sub chkall_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkall.CheckedChanged
        If chkall.Checked = True Then
            For i = 0 To gridac.RowCount - 1
                If gridac.CurrentRow.Index >= 0 Then
                    With gridac.Rows(i).Cells(0)
                        .Value = True
                    End With
                End If
            Next
        Else
            For i = 0 To gridac.RowCount - 1
                If gridac.CurrentRow.Index >= 0 Then
                    With gridac.Rows(i).Cells(0)
                        .Value = False
                    End With
                End If
            Next
        End If
    End Sub

    Private Sub txtlotno_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtlotno.KeyPress
        numkeypress(e, txtlotno, Me)
    End Sub

    Private Sub RBPARTYLOSS_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBPARTYLOSS.CheckedChanged
        Try
            If RBPARTYLOSS.Checked = True Then fillac() Else gridac.RowCount = 0
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class