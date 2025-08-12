
Imports System.Data.OleDb

Public Class PartyWastageFilter

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
                CMBNAME.Items.Add(dr(0).ToString)
            End While
        End If
    End Sub

    Private Sub PartyWastageFilter_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            fillac()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub

    Private Sub CMDOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShowReport.Click
        Try
            Dim CONDITION As String = " WHERE 1 = 1  AND VOUCHER_DIFF <> 0 "
            If CMBNAME.Text.Trim <> "" Then CONDITION = CONDITION & " AND  LEDGER_CODE = '" & CMBNAME.Text.Trim & "'"
            If chkdate.CheckState = CheckState.Checked Then CONDITION = CONDITION & " AND  VOUCHER_DATE >= #" & Format(dtpfrom.Value.Date, "MM/dd/yyyy") & "# AND VOUCHER_DATE <= #" & Format(dtpto.Value.Date, "MM/dd/yyyy") & "#"

            If RBDETAILS.Checked = True Then
                Dim objrep As New clsReportDesigner("Diff Details Report", System.AppDomain.CurrentDomain.BaseDirectory & "Diff Details.xlsx", 2)
                objrep.PARTY_DIFFDETAILS_EXCEL(CMBNAME.Text.Trim, CONDITION)
            Else
                Dim objrep As New clsReportDesigner("Diff Summary Report", System.AppDomain.CurrentDomain.BaseDirectory & "Diff Summary.xlsx", 2)
                objrep.PARTY_DIFFSUMM_EXCEL(CMBNAME.Text.Trim, CONDITION)
            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

End Class