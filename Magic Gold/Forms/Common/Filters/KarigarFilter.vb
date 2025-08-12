
Imports System.Data.OleDb

Public Class KarigarFilter

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub

    Sub FILL()
        Try
            fillname(Me, cmbname, " AND (GROUP_NAME  = 'Sundry Creditors' or GROUP_NAME  = 'Sundry Debtors')")
            If CMBITEMNAME.Text.Trim = "" Then If CMBITEMNAME.Text.Trim = "" Then FILLITEMCODE(Me, CMBITEMNAME, "")
            FILLGM()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLGM()
        Try
            dt = New DataTable()
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
            conn.Open()
            cmd = New OleDbCommand("select DISTINCT MFG_GM FROM KARIGARISSUE ", conn)
            da = New OleDbDataAdapter(cmd)
            da.Fill(dt)
            CMBGM.DataSource = dt
            CMBGM.DisplayMember = "MFG_GM"
            CMBGM.Text = ""
            conn.Close()
            da.Dispose()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub KarigarFilter_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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

    Private Sub KarigarFilter_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        FILL()
        cmbname.Text = ""
        CMBITEMNAME.Text = ""
        CMBGM.Text = ""
    End Sub

    Private Sub cmbname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbname.Enter
        Try
            If cmbname.Text.Trim = "" Then fillname(Me, cmbname, " and ( groupmaster.group_name = 'Sundry Creditors' or groupmaster.group_name = 'Sundry Debtors') ")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbname.Validating
        Try
            If cmbname.Text.Trim <> "" Then

                cmbname.Text = uppercase(cmbname.Text)
                cmd = New OleDbCommand("SELECT ledgermaster.ledger_code from ledgermaster inner join groupmaster on groupmaster.group_id = ledgermaster.ledger_groupid where ledgermaster.ledger_code = '" & cmbname.Text.Trim & "' and ( groupmaster.group_name = 'Sundry Creditors' or groupmaster.group_name = 'Sundry Debtors')", conn)
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

            Dim WHERE As String = " WHERE 1=1"
            If cmbname.Text.Trim <> "" Then
                WHERE = WHERE & " AND CODE = '" & cmbname.Text.Trim & "'"
            Else
                MsgBox("Select Karigar Name", MsgBoxStyle.Critical)
                cmbname.Focus()
                Exit Sub
            End If
            If CMBITEMNAME.Text.Trim <> "" Then WHERE = WHERE & " AND ITEMCODE = '" & CMBITEMNAME.Text.Trim & "'"
            If CMBGM.Text.Trim <> "" Then WHERE = WHERE & " AND GM = '" & CMBGM.Text.Trim & "'"

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
                tempcmd = New OleDbCommand("SELECT GM, DATE, ITEMCODE, OUTPUTWT, FINALPERCENT, LOTNO, PARTNO,  LABOUR, AMOUNT FROM KARIGARACCOUNT " & WHERE & " GROUP BY KARIGARACCOUNT.GM, KARIGARACCOUNT.Date, KARIGARACCOUNT.ITEMCODE, KARIGARACCOUNT.OUTPUTWT, KARIGARACCOUNT.FINALPERCENT, KARIGARACCOUNT.LOTNO, KARIGARACCOUNT.PARTNO, KARIGARACCOUNT.LABOUR, KARIGARACCOUNT.AMOUNT ORDER BY GM , KARIGARACCOUNT.Date, KARIGARACCOUNT.LOTNO ", tempconn)
                da = New OleDbDataAdapter(tempcmd)
                da.Fill(dt)
                tempconn.Close()
                da.Dispose()
                If dt.Rows.Count = 0 Then
                    MsgBox("No Records In Karigar Account", MsgBoxStyle.Critical, "Magic Gold")
                    Exit Sub
                End If
                Dim objrep As New clsReportDesigner("Karigar Report (Detailed)", System.AppDomain.CurrentDomain.BaseDirectory & "Karigar Report.xlsx", 2)
                objrep.KARIGARDETAILS_REPORT_EXCEL(cmbname.Text.Trim, dt, PERIOD)

            ElseIf RBSUMMARY.Checked = True Then
                tempcmd = New OleDbCommand("SELECT GM, '' AS [DATE], '' AS ITEMCODE, Sum(KarigarAccount.OUTPUTWT) AS OUTPUTWT, '' AS FINALPERCENT, 0 AS LOTNO, '' AS PARTNO,  '' AS LABOUR, Sum(KarigarAccount.AMOUNT)  AS AMOUNT FROM KARIGARACCOUNT " & WHERE & " GROUP BY KarigarAccount.GM ORDER BY GM ", tempconn)
                da = New OleDbDataAdapter(tempcmd)
                da.Fill(dt)
                tempconn.Close()
                da.Dispose()
                If dt.Rows.Count = 0 Then
                    MsgBox("No Records In Karigar Account", MsgBoxStyle.Critical, "Magic Gold")
                    Exit Sub
                End If
                Dim objrep As New clsReportDesigner("Karigar Report (Summary)", System.AppDomain.CurrentDomain.BaseDirectory & "Karigar Report.xlsx", 2)
                objrep.KARIGARDETAILS_REPORT_EXCEL(cmbname.Text.Trim, dt, PERIOD)

            ElseIf RBLEDGER.Checked = True Then
                If cmbname.Text.Trim = "" Then
                    MsgBox("Select Karigar Name", MsgBoxStyle.Critical)
                    Exit Sub
                End If
                tempcmd = New OleDbCommand(" SELECT * FROM (SELECT DISTINCT mfgmaster.MFG_LOTNO AS LOTNO,  mfgmaster.MFG_DATE AS [DATE], mfgdescription.mfg_percentfinal AS RECPUR, mfgdescription.mfg_outputwt AS RECGROSS, ((mfgdescription.mfg_percentfinal * mfgdescription.mfg_outputwt)/100) AS RECNETT, '' AS ITEMCODE, 0 as EXTRAITEMPUR, 0 AS EXTRAITEMGROSS, 0 AS EXTRAITEMNETT, mfgdescription.mfg_percentinput AS ISSITEMPUR, mfgdescription.mfg_inputwt AS ISSITEMWT,((mfgdescription.mfg_percentinput * mfgdescription.mfg_inputwt)/100) AS ISSITEMNETT, mfgdescription.mfg_part AS PARTNO, KarigarAccount.CODE , mfgdescription.mfg_excess AS EXCESSWT,  mfgdescription.mfg_WASTAGE AS WASTAGE FROM (mfgdescription INNER JOIN (KarigarAccount INNER JOIN mfgmaster ON KarigarAccount.LOTNO = mfgmaster.mfg_lotno) ON mfgdescription.mfg_no = mfgmaster.mfg_no) INNER JOIN processmaster ON mfgdescription.mfg_processname = processmaster.process_name " & WHERE & " AND processmaster.PROCESS_KARIGAR=True   UNION  ALL  SELECT karigarissue.MFG_LOTNO AS LOTNO, karigarissue.mfg_processdate AS [DATE], 0 AS RECPUR, 0 AS RECGROSS, 0 AS RECNETT, ItemMaster.item_code AS ITEMCODE,  karigarissue.mfg_purity AS EXTRAITEMPUR, karigarissue.mfg_grosswt AS EXTRAITEMGROSS, karigarissue.mfg_nettwt AS EXTRAITEMNETT, karigarissue.MFG_PERCENTFINAL AS ISSITEMPUR, karigarissue.MFG_INPUTWT AS ISSITEMWT, ((karigarissue.MFG_INPUTWT *karigarissue.MFG_PERCENTFINAL )/100) AS ISSITEMNETT, 'Part(' & karigarissue.mfg_part & ')' AS PARTNO, ledgermaster.ledger_code AS CODE, 0 AS EXCESSWT, 0 AS WASTAGE FROM (karigarissue LEFT JOIN ItemMaster ON karigarissue.mfg_itemid = ItemMaster.item_id) LEFT JOIN ledgermaster ON karigarissue.mfg_ledgerid = ledgermaster.ledger_id WHERE KARIGARISSUE.MFG_RECD = FALSE) AS T " & WHERE & " ORDER BY LOTNO", tempconn)
                da = New OleDbDataAdapter(tempcmd)
                da.Fill(dt)
                tempconn.Close()
                da.Dispose()
                If dt.Rows.Count = 0 Then
                    MsgBox("No Records In Karigar Account", MsgBoxStyle.Critical, "Magic Gold")
                    Exit Sub
                End If
                Dim objrep As New clsReportDesigner("Karigar Ledger (" & cmbname.Text.Trim & ")", System.AppDomain.CurrentDomain.BaseDirectory & "Karigar Ledger.xlsx", 2)
                objrep.KARIGARLEDGER_REPORT_EXCEL(cmbname.Text.Trim, dt, PERIOD)
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class