Imports System.Data.oledb

Public Class settlementdate

    Private Sub settlementdate_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        dtpsettledate.Value = Now.Date
        tempcmd = New OleDbCommand("select ledger_settlement from ledgermaster where ledger_id=" & Val(tempnameid), tempconn)
        If tempconn.State = ConnectionState.Open Then
            tempconn.Close()
        End If
        tempconn.Open()
        tempdr = tempcmd.ExecuteReader
        If tempdr.HasRows = True Then
            While (tempdr.Read)
                dtppreviousdate.Value = Format(tempdr(0), "dd/MM/yyyy")
            End While
        End If
        cmbyesno.SelectedIndex = (0)

    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click

        Dim tempbal, tempamt As Double
        Dim sdate As Date

        cmd = New OleDbCommand("SELECT ledgermaster.ledger_code,ledgermaster.ledger_id,ledgermaster.ledger_name,ledgermaster.ledger_opbalrs, ledgermaster.ledger_drcrrs, ledgermaster.ledger_opbalwt, ledgermaster.ledger_drcrwt,ledgermaster.ledger_settlement from ledgermaster inner join groupmaster on groupmaster.group_id = ledgermaster.ledger_groupid where ledgermaster.ledger_code = '" & tempname & "' and ( groupmaster.group_name = 'Sundry Creditors' or groupmaster.group_name = 'Sundry Debtors'  )", conn)
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If
        conn.Open()
        dr = cmd.ExecuteReader

        If dr.HasRows = True Then

            dr.Read()
            tempbal = 0
            tempamt = 0
            If dr(4) = "Cr." Then
                tempamt = Val(dr(3))
            Else
                tempamt = -1 * Val(dr(3))
            End If

            If dr(6) = "Cr." Then
                tempbal = Val(dr(5))
            Else
                tempbal = -1 * Val(dr(5))
            End If

            sdate = dr(7)

            tempcmd = New OleDbCommand("select code,nettwt,amount,type from ledgeraccounts where code='" & dr(0).ToString & "' and sdate >#" & Format(dtpsettledate.Value, "dd/MM/yyyy") & "# order by type", tempconn)
            If tempconn.State = ConnectionState.Open Then
                tempconn.Close()
            End If
            tempconn.Open()
            tempdr = tempcmd.ExecuteReader
            If tempdr.HasRows = True Then
                While (tempdr.Read)
                    If tempdr(3) = "Jama" Then
                        tempbal = tempbal + Val(tempdr(1))
                        tempamt = tempamt + Val(tempdr(2))
                    ElseIf tempdr(3) = "Balance" Then
                        tempbal = tempbal - Val(tempdr(1))
                        tempamt = tempamt - Val(tempdr(2))
                    ElseIf tempdr(3) = "I" Then
                        tempbal = tempbal - Val(tempdr(1))
                        tempamt = tempamt - Val(tempdr(2))
                    ElseIf tempdr(3) = "R" Then
                        tempbal = tempbal + Val(tempdr(1))
                        tempamt = tempamt + Val(tempdr(2))
                    ElseIf tempdr(3) = "RAMT" Or tempdr(3) = "IWT" Then
                        tempbal = tempbal + Val(tempdr(1))
                        tempamt = tempamt - Val(tempdr(2))
                    ElseIf tempdr(3) = "RWT" Or tempdr(3) = "IAMT" Then
                        tempbal = tempbal - Val(tempdr(1))
                        tempamt = tempamt + Val(tempdr(2))
                    End If

                End While
            End If
            tempdr.Close()
            tempconn.Close()
        End If
      

        dr.Close()
        conn.Close()
        'clearing array
        For i = 1 To 100
            tempcol(i) = ""
            tempval(i) = ""
        Next
        'tempcol(0) = "ledger_opbalrs"
        'tempcol(1) = "ledger_drcrrs"
        'tempcol(2) = "ledger_opbalwt"
        'tempcol(3) = "ledger_drcrwt"
        tempcol(0) = "ledger_settlement"


        'If tempamt > 0 Then
        '    tempval(1) = "'Cr.'"
        '    tempval(0) = tempamt
        'Else
        '    tempval(1) = "'Dr.'"
        '    tempval(0) = -1 * tempamt
        'End If

        'If tempbal > 0 Then
        '    tempval(3) = "'Cr.'"
        '    tempval(2) = tempbal
        'Else
        '    tempval(3) = "'Dr.'"
        '    tempval(2) = -1 * tempbal
        'End If
        tempval(0) = "'" & Format(dtpsettledate.Value, "dd/MM/yyyy") & "'"
        tempcondition = " where ledger_code = '" & tempname & "'"

        modify("ledgermaster", tempcol, tempval, tempcondition)
        If cmbyesno.Text = "YES" Then
            cmd = New OleDbCommand("delete from accountmaster where account_ledgerid = " & tempnameid, conn)
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
            conn.Open()
            cmd.ExecuteNonQuery()

            cmd = New OleDbCommand("delete from vouchers where voucher_ledgerid = " & tempnameid, conn)
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
            conn.Open()
            cmd.ExecuteNonQuery()

            cmd = New OleDbCommand("delete from BHAVCUTMaster where bhavcut_ledgerid = " & tempnameid, conn)
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
            conn.Open()
            cmd.ExecuteNonQuery()
        End If
        Me.Close()

    End Sub

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub
End Class