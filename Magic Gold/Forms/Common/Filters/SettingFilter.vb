
Imports System.Data.OleDb

Public Class SettingFilter

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub

    Sub FILL()
        Try
            fillname(Me, cmbname, " AND GROUP_NAME  = 'Sundry Creditors' AND LEDGERMASTER.LEDGER_KARIGAR = TRUE")
            If CMBITEMNAME.Text.Trim = "" Then If CMBITEMNAME.Text.Trim = "" Then FILLITEMCODE(Me, CMBITEMNAME, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SettingFilter_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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

    Private Sub SettingFilter_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        FILL()
        cmbname.Text = ""
        CMBITEMNAME.Text = ""
    End Sub

    Private Sub cmbname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbname.Enter
        Try
            If cmbname.Text.Trim = "" Then fillname(Me, cmbname, " AND GROUP_NAME  = 'Sundry Creditors' AND LEDGERMASTER.LEDGER_KARIGAR = TRUE")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbname.Validating
        Try
            If cmbname.Text.Trim <> "" Then

                cmbname.Text = uppercase(cmbname.Text)
                cmd = New OleDbCommand("SELECT ledgermaster.ledger_code from ledgermaster inner join groupmaster on groupmaster.group_id = ledgermaster.ledger_groupid where ledgermaster.ledger_code = '" & cmbname.Text.Trim & "' and groupmaster.group_name = 'Sundry Creditors' AND LEDGERMASTER.LEDGER_KARIGAR = TRUE", conn)
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
                            chldvendormaster.txtname.Text = cmbname.Text
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
                        cmbname.Focus()
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBITEMNAME_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBITEMNAME.Enter
        Try
            If CMBITEMNAME.Text.Trim = "" Then If CMBITEMNAME.Text.Trim = "" Then FILLITEMCODE(Me, CMBITEMNAME, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBITEMNAME_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBITEMNAME.KeyDown
        Try
            If e.KeyCode = Keys.F1 And e.Alt = True Then
                Dim OBJITEM As New SelectItem
                OBJITEM.ShowDialog()
                CMBITEMNAME.Text = OBJITEM.TEMPCODE
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBITEMNAME_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBITEMNAME.Validating
        Try
            If CMBITEMNAME.Text.Trim <> "" Then

                CMBITEMNAME.Text = uppercase(CMBITEMNAME.Text)

                cmd = New OleDbCommand("SELECT itemmaster.item_code from itemmaster where itemmaster.item_code = '" & CMBITEMNAME.Text.Trim & "'", conn)
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
                conn.Open()
                dr = cmd.ExecuteReader
                If dr.HasRows = False Then
                    tempmsg = MsgBox("Item Not Present, Add New?", MsgBoxStyle.YesNo)
                    If tempmsg = vbYes Then
                        item = 0
                        If (chlditemmaster.IsMdiChild = False) Then
                            If chlditemmaster.IsDisposed = True Then
                                chlditemmaster = New Itemmaster
                            End If
                            chlditemmaster.cmdedit.Enabled = True
                            chlditemmaster.EDIT = False
                            e.Cancel = True
                            chlditemmaster.cmdaddnew.Enabled = False
                            chlditemmaster.GPITEM.Enabled = True
                            chlditemmaster.txttype.Visible = False
                            chlditemmaster.txtcategory.Visible = False
                            chlditemmaster.Show(Me)
                            chlditemmaster.cmbcode.Text = CMBITEMNAME.Text
                            chlditemmaster.cmbitemname.Text = CMBITEMNAME.Text
                            chlditemmaster.ActiveControl = (chlditemmaster.cmbcode)
                            chlditemmaster.cmbitemname.Focus()
                        Else
                            chlditemmaster.BringToFront()
                        End If
                    Else
                        CMBITEMNAME.Text = UCase(CMBITEMNAME.Text.Trim)
                        CMBITEMNAME.Focus()
                        e.Cancel = True
                    End If
                End If

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdShowReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShowReport.Click
        Try
            If cmbname.Text.Trim = "" Then
                MsgBox("Select Karigar Name", MsgBoxStyle.Critical)
                cmbname.Focus()
                Exit Sub
            End If

            Dim objrep As New clsReportDesigner("Karigar Ledger (" & cmbname.Text.Trim & ")", System.AppDomain.CurrentDomain.BaseDirectory & "Karigar Ledger.xlsx", 2)
            objrep.SETTINGLEDGER_REPORT_EXCEL(cmbname.Text.Trim, chkdate.Checked, dtpfrom.Value.Date, dtpto.Value.Date)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class