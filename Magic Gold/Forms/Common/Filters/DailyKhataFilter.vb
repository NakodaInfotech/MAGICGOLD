Imports System.Data.oledb

Public Class dailykhatafilter

    Sub fillac()
        'filling all groups and subgroups
        cmd = New OleDbCommand("select distinct account_ledgercode from accountmaster", conn)
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If
        conn.Open()
        dr = cmd.ExecuteReader()
        If dr.HasRows Then
            While (dr.Read())
                cmbname.Items.Add(dr(0).ToString)
            End While
        End If
    End Sub

    Private Sub cmdShowReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShowReport.Click
        strsearch = ""
        Main()
        Try
            Dim CONDITION As String = " WHERE 1 = 1  AND ACCOUNT_DATE > LEDGER_SETTLEMENT "
            If CHKALLPARTY.CheckState = CheckState.Unchecked Then
                If cmbname.Text.Trim <> "" Then

                    If cmbname.Text.Trim <> "" Then CONDITION = CONDITION & " AND  ACCOUNT_LEDGERCODE = '" & cmbname.Text.Trim & "'"
                    If cmbitemcode.Text.Trim <> "" Then CONDITION = CONDITION & " AND  ITEM_CODE = '" & cmbitemcode.Text.Trim & "'"
                    If txtpurity.Text.Trim.Length > 0 Then CONDITION = CONDITION & " AND  ACCOUNT_PURITY = " & Val(txtpurity.Text.Trim)
                    Dim FROMDATE As Date
                    If chkdate.CheckState = CheckState.Checked Then
                        FROMDATE = dtpfrom.Value.Date
                        CONDITION = CONDITION & " AND  ACCOUNT_DATE >= #" & Format(dtpfrom.Value.Date, "MM/dd/yyyy") & "# AND ACCOUNT_DATE <= #" & Format(dtpto.Value.Date, "MM/dd/yyyy") & "#"
                    Else
                        FROMDATE = Now.Date
                    End If

                    Dim objrep As New clsReportDesigner("Ledger Accounts", System.AppDomain.CurrentDomain.BaseDirectory & "Ledger Accounts.xlsx", 2)
                    If RDSUMM.Checked = True Then
                        objrep.PARTY_ACCOUNTS_EXCEL(cmbname.Text.Trim, chknarr.CheckState, chkitem.CheckState, chkpurity.CheckState, chkbullion.CheckState, chkwastage.CheckState, chkgrosswt.CheckState, chknettwt.CheckState, chkamount.CheckState, FROMDATE, chkdate.Checked, CONDITION)
                    Else
                        objrep.PARTY_DETAILACCOUNTS_EXCEL(cmbname.Text.Trim, chknarr.CheckState, chkitem.CheckState, chkpurity.CheckState, chkbullion.CheckState, chkwastage.CheckState, chkgrosswt.CheckState, chknettwt.CheckState, chkamount.CheckState, FROMDATE, chkdate.Checked, CONDITION)
                    End If

                Else
                        MsgBox("Select Party Name")
                End If

            Else
                Dim objrep As New clsReportDesigner("Ledger Accounts (All)", System.AppDomain.CurrentDomain.BaseDirectory & "Ledger Accounts All.xlsx", 2)
                objrep.ALL_PARTY_ACCOUNTS_EXCEL(cmbname.Text.Trim, chknarr.CheckState, chkitem.CheckState, chkpurity.CheckState, chkbullion.CheckState, chkwastage.CheckState, chkgrosswt.CheckState, chknettwt.CheckState, chkamount.CheckState, CONDITION)
            End If
        Catch ex As Exception
            Throw ex
        End Try

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

    Private Sub dailykhatafilter_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                Me.Close()
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub dailykhatafilter_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        fillac()
        If ClientName = "MONOGRAM" Or ClientName = "ORIENTAL" Then
            chkitem.CheckState = CheckState.Unchecked
            chkpurity.CheckState = CheckState.Unchecked
            chkwastage.CheckState = CheckState.Unchecked
            chkgrosswt.CheckState = CheckState.Unchecked
            chknettwt.CheckState = CheckState.Unchecked
        End If
    End Sub

    Private Sub cmbname_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbname.KeyDown
        Try
            If e.KeyCode = Keys.F1 And e.Alt = True Then
                Dim OBJSELECT As New SelectLedger
                OBJSELECT.STRSEARCH = " AND (GROUPMASTER.GROUP_NAME = 'Sundry Debtor' or GROUPMASTER.GROUP_NAME = 'Sundry Creditors')"
                OBJSELECT.ShowDialog()
                cmbname.Text = OBJSELECT.TEMPCODE
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbname.Validating
        tempname = cmbname.Text.Trim
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub

    Private Sub cmbitemcode_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbitemcode.Enter
        Try
            'filling all groups and subgroups
            cmd = New OleDbCommand("select item_code from itemmaster", conn)
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
            conn.Open()
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                While (dr.Read())
                    cmbitemcode.Items.Add(dr(0).ToString)
                End While
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbitemcode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbitemcode.KeyDown
        Try
            If e.KeyCode = Keys.F1 And e.Alt = True Then
                Dim OBJITEM As New SelectItem
                OBJITEM.ShowDialog()
                cmbitemcode.Text = OBJITEM.TEMPCODE
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class