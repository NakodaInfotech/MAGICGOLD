
Imports System.Data.OleDb

Public Class WastageJama

    Sub ADDWASTAGE()
        Try
            For i = 1 To 50
                tempcol(i) = ""
                tempval(i) = ""
            Next
            cmd = New OleDbCommand("select * from accountmaster where account_id = " & txtbillno.Text & " and account_type ='Jama'", conn)
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
            conn.Open()
            dr = cmd.ExecuteReader
            If dr.HasRows = True Then
                tempcmd = New OleDbCommand("delete from accountmaster where account_id = " & txtbillno.Text & " and account_type ='Jama'", tempconn)
                If tempconn.State = ConnectionState.Open Then
                    tempconn.Close()
                End If

                tempconn.Open()
                tempcmd.ExecuteNonQuery()
                tempconn.Close()
            End If
            dr.Close()
            conn.Close()

            tempcol(0) = "account_id"
            tempcol(1) = "account_date"
            tempcol(2) = "account_ledgerid"
            tempcol(3) = "account_itemid"
            tempcol(4) = "account_purity"
            tempcol(5) = "account_wastage"
            tempcol(6) = "account_grosswt"
            tempcol(7) = "account_nettwt"
            tempcol(8) = "account_amount"
            tempcol(9) = "account_balorjamaorpaid"
            tempcol(10) = "account_narration"
            tempcol(11) = "account_type"
            tempcol(12) = "account_ledgercode"
            tempcol(13) = "account_voucherid"
            tempcol(14) = "account_USERID"
            tempcol(15) = "account_DEPARTMENTID"
            tempcol(16) = "account_PROCESS"


            tempval(0) = Val(txtbillno.Text)
            tempval(1) = "'" & Format(DTJAMA.Value.Date, "dd/MM/yyyy") & "'"

            'getting nameid
            cmd = New OleDbCommand("select ledger_id,ledger_code from ledgermaster where ledger_code = '" & cmbcode.Text.Trim & "'", conn)
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
            conn.Open()
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                dr.Read()
                tempval(2) = Val(dr(0))
                tempnameid = dr(0)
                tempname = dr(1).ToString
            Else
                tempval(2) = Val(0)
            End If
            conn.Close()



            'getting itemid
            cmd = New OleDbCommand("select item_id from itemmaster where item_code =  'BAR'", conn)
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
            conn.Open()
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                dr.Read()
                tempval(3) = Val(dr(0))
            Else
                tempval(3) = Val(0)
            End If
            conn.Close()

            tempval(4) = Val(TXTPURITY.Text.Trim)
            tempval(5) = Val(0)
            tempval(6) = Val(txtgrosswt.text.trim)
            tempval(7) = Val(txtnettwt.Text.Trim)
            tempval(8) = Val(0)

            tempval(9) = "'Jama'"

            tempval(10) = "''"
            tempval(11) = "'A'"
            tempval(12) = "'" & cmbcode.Text & "'"
            tempval(13) = Val(txtbillno.Text)
            tempval(14) = Val(Userid)
            tempval(15) = Val(USERDEPARTMENTID)
            tempval(16) = "''"  'PROCESSNAME

            insert("accountmaster", tempcol, tempval)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub WastageJama_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.Alt = True And e.KeyCode = Windows.Forms.Keys.S Then       'for Saving
                Call cmdok_Click(sender, e)
            ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                If cmbcode.Text.Trim <> "" And Val(txtbillno.Text.Trim) > 0 And Val(txtgrosswt.Text.Trim) > 0 And Val(TXTPURITY.Text.Trim) > 0 And Val(txtnettwt.Text.Trim) > 0 Then
                    tempmsg = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                    If tempmsg = vbYes Then cmdok_Click(sender, e)
                End If
                Me.Close()
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub WastageJama_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            CLEAR()
            FILLCMB()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLCMB()
        Try
            tempname = ""
            If cmbcode.Text.Trim = "" Then fillname(Me, cmbcode, " and groupmaster.group_name = 'Stock In Hand'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub CLEAR()
        Try

            DTJAMA.Value = Now.Date
            cmbcode.Text = ""
            TXTPURITY.Clear()
            txtgrosswt.Clear()
            txtnettwt.Clear()


            tempcmd = New OleDbCommand("select max(account_id) AS ACCID from accountmaster", tempconn)

            If tempconn.State = ConnectionState.Open Then
                tempconn.Close()
            End If
            tempconn.Open()
            tempdr = tempcmd.ExecuteReader
            If tempdr.HasRows Then
                tempdr.Read()
                txtbillno.Text = Val(tempdr("ACCID").ToString)
                txtbillno.Text = Val(txtbillno.Text) + 1
            End If
            tempconn.Close()
            tempdr.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            If cmbcode.Text.Trim <> "" And Val(TXTPURITY.Text.Trim) > 0 And Val(txtgrosswt.Text.Trim) > 0 And Val(txtnettwt.Text.Trim) > 0 Then
                ADDWASTAGE()
                CLEAR()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub cmbcode_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbcode.GotFocus
        Try
            If cmbcode.Text.Trim = "" Then fillname(Me, cmbcode, " and groupmaster.group_name = 'Stock In Hand'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbcode_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbcode.Validating
        If cmbcode.Text.Trim <> "" Then

            cmbcode.Text = uppercase(cmbcode.Text)

            cmd = New OleDbCommand("SELECT ledgermaster.ledger_code,ledgermaster.ledger_id,ledgermaster.ledger_name from ledgermaster where ledgermaster.ledger_code = '" & cmbcode.Text.Trim & "'", conn)
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
            conn.Open()
            dr = cmd.ExecuteReader
            If dr.HasRows = False Then
                tempmsg = MsgBox("Ledger Not Present, Add New?", MsgBoxStyle.YesNo)
                If tempmsg = vbYes Then

                    If (chldvendormaster.IsMdiChild = False) Then
                        If chldvendormaster.IsDisposed = True Then
                            chldvendormaster = New ACCOUNTMASTER
                        End If
                        chldvendormaster.txtname.Text = cmbcode.Text
                        chldvendormaster.cmdedit.Enabled = True
                        chldvendormaster.EDIT = False
                        e.Cancel = True
                        chldvendormaster.Show(Me)
                        chldvendormaster.ActiveControl = (chldvendormaster.txtname)
                        chldvendormaster.txtname.Focus()
                    Else
                        chldvendormaster.BringToFront()
                    End If
                Else
                    cmbcode.Focus()
                End If
            End If

        End If

    End Sub

    Private Sub txtgrosswt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtgrosswt.KeyPress
        numdotkeypress(e, txtgrosswt, Me)
    End Sub

    Private Sub txtnettwt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtnettwt.KeyPress
        numdotkeypress(e, txtnettwt, Me)
    End Sub

    Private Sub TXTPURITY_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTPURITY.KeyPress
        numdotkeypress(e, TXTPURITY, Me)
    End Sub

    Private Sub TXTPURITY_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTPURITY.Validated
        Try
            txtnettwt.Text = Format(((Val(txtgrosswt.Text.Trim) * Val(TXTPURITY.Text.Trim)) / 100), "0.000")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtgrosswt_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtgrosswt.Validated
        Try
            txtnettwt.Text = Format(((Val(txtgrosswt.Text.Trim) * Val(TXTPURITY.Text.Trim)) / 100), "0.000")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class