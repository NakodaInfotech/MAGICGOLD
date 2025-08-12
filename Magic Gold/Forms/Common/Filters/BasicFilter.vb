
Imports System.Data.OleDb

Public Class basicfilter

    Public FRMSTRING As String = ""

    Private Sub cmdShowReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShowReport.Click
        'Main()
        strsearch = ""

        'Getting Party-Wise-Wastage Report
        If frmpartyitemwast = True Then
            Dim OBJRPT As New PartyWiseWastageDetailsReport
            OBJRPT.MdiParent = MDIMain
            If cmb.Text.Trim <> "" Then OBJRPT.WHERECLAUSE = " AND LEDGERDETAILVIEW.Item_Code = '" & cmb.Text.Trim & "'"
            If cmb1.Text.Trim <> "" Then OBJRPT.WHERECLAUSE = OBJRPT.WHERECLAUSE & " AND LEDGERDETAILVIEW.ACCOUNT_LEDGERCODE = '" & cmb1.Text.Trim & "'"
            If chkdate.CheckState = CheckState.Checked Then OBJRPT.WHERECLAUSE = OBJRPT.WHERECLAUSE & " AND LEDGERDETAILVIEW.ACCOUNT_DATE >= #" & Format(dtpfrom.Value.Date, "MM/dd/yyyy") & "# AND LEDGERDETAILVIEW.ACCOUNT_DATE <= #" & Format(dtpto.Value.Date, "MM/dd/yyyy") & "#"
            OBJRPT.Show()
        End If

        If frmavgsalepur = True Then
            If chkdate.Checked = True Then
                getFromToDate()
                If strsearch <> "" Then
                    strsearch = strsearch & " and {avgsalepurchase.account_date} in date" & fromD & " to date" & toD
                Else
                    strsearch = strsearch & " {avgsalepurchase.account_date} in date" & fromD & " to date" & toD
                End If
            End If
            AvgSalePurDesign.Show()
        End If


        'Getting Vaccum Report
        If frmmfgvaccum = True Then
            Dim CONDITION As String = " WHERE 1 = 1 "
            Dim PERIOD As String = ""
            If chkdate.CheckState = CheckState.Checked Then
                CONDITION = CONDITION & " AND DATE >= #" & Format(dtpfrom.Value.Date, "MM/dd/yyyy") & "# AND DATE <=# " & Format(dtpto.Value.Date, "MM/dd/yyyy") & "#"
                PERIOD = Format(dtpfrom.Value.Date, "dd/MM/yyyy") & " To " & Format(dtpto.Value.Date, "dd/MM/yyyy")
            Else
                PERIOD = Format(startdate, "dd/MM/yyyy") & " To " & Format(enddate, "dd/MM/yyyy")
            End If
            If Val(txtlotno.Text.Trim) > 0 Then CONDITION = CONDITION & " AND LOTNO = '" & Val(txtlotno.Text.Trim) & "'"
            If cmbprocess.Text.Trim <> "" Then CONDITION = CONDITION & " AND PROCESSNAME = '" & cmbprocess.Text.Trim & "'"

            dt = New DataTable()
            If tempconn.State = ConnectionState.Open Then tempconn.Close()
            tempconn.Open()
            tempcmd = New OleDbCommand("SELECT DATE, ITEMCODE, JAMAPURITY, JAMAGROSSWT, JAMANETTWT, LOTNO, INWT, OUTWT, VACCUMWT, NETTWT, VACCUMPURITY, PARTNO, MELTING, PROCESSNAME  FROM VACCUMREPORT " & CONDITION & " ORDER BY DATE, LOTNO", tempconn)
            da = New OleDbDataAdapter(tempcmd)
            da.Fill(dt)
            tempconn.Close()
            da.Dispose()

            If dt.Rows.Count = 0 Then
                MsgBox("No Records In Vaccum", MsgBoxStyle.Critical, "Magic Gold")
                Exit Sub
            End If
            Dim objrep As New clsReportDesigner("Vaccum Report", System.AppDomain.CurrentDomain.BaseDirectory & "Vaccum Report.xlsx", 2)
            objrep.VACCUM_REPORT_EXCEL(dt, PERIOD)

        End If


        'Getting Process Report
        If frmmfgprocessreport = True Then
            If chkdate.Checked = True Then
                getFromToDate()
                If strsearch <> "" Then
                    strsearch = strsearch & " and {mfgdescription.mfg_processdate} in date" & fromD & " to date" & toD
                Else
                    strsearch = strsearch & " {mfgdescription.mfg_processdate} in date" & fromD & " to date" & toD
                End If
            End If
            If strsearch = "" Then strsearch = "1=1"
            If cmbprocess.Text.Trim <> "" Then strsearch = strsearch & " and {mfgdescription.mfg_processname} = '" & cmbprocess.Text.Trim & "'"

            If Val(txtlotno.Text.Trim) <> 0 Then
                If strsearch <> "" Then
                    strsearch = strsearch & " and {mfgmaster.mfg_no} = " & Val(txtlotno.Text.Trim)
                Else
                    strsearch = strsearch & " {mfgmaster.mfg_no} = " & Val(txtlotno.Text.Trim)
                End If
            End If
            Dim OBJ As New ProcessReportDesign
            OBJ.MdiParent = MDIMain
            OBJ.Show()
        End If



        'Getting Sample Report
        If frmsamplereport = True Then
            Dim CONDITION As String = " WHERE 1 = 1 "
            Dim PERIOD As String = ""
            If chkdate.CheckState = CheckState.Checked Then
                CONDITION = CONDITION & " AND DATE >= #" & Format(dtpfrom.Value.Date, "MM/dd/yyyy") & "# AND DATE <=# " & Format(dtpto.Value.Date, "MM/dd/yyyy") & "#"
                PERIOD = Format(dtpfrom.Value.Date, "dd/MM/yyyy") & " To " & Format(dtpto.Value.Date, "dd/MM/yyyy")
            End If
            If Val(txtlotno.Text.Trim) > 0 Then CONDITION = CONDITION & " AND LOTNO = '" & Val(txtlotno.Text.Trim) & "'"

            dt = New DataTable()
            If tempconn.State = ConnectionState.Open Then tempconn.Close()
            tempconn.Open()
            tempcmd = New OleDbCommand("SELECT * FROM SAMPLEREPORT " & CONDITION & " ORDER BY DATE, LOTNO", tempconn)
            da = New OleDbDataAdapter(tempcmd)
            da.Fill(dt)
            tempconn.Close()
            da.Dispose()

            If dt.Rows.Count = 0 Then
                MsgBox("No Records In Sample", MsgBoxStyle.Critical, "Magic Gold")
                Exit Sub
            End If
            Dim objrep As New clsReportDesigner("Sample Report", System.AppDomain.CurrentDomain.BaseDirectory & "Sample Report.xlsx", 2)

            If chkitem.Checked = False Then
                objrep.item = False
            End If
            If CHKRECPUR.Checked = False Then
                objrep.recpur = False
            End If
            If chkgross.Checked = False Then
                objrep.grosswt = False
            End If
            If CHKNETT.Checked = False Then
                objrep.nettwt = False
            End If
            If CHKLOT.Checked = False Then
                objrep.lotno = False
            End If
            If chkinwt.Checked = False Then
                objrep.inwt = False
            End If
            If chkoutwt.Checked = False Then
                objrep.outwt = False
            End If
            If CHKSMPLWT.Checked = False Then
                objrep.smplwt = False
            End If
            If CHKISSUEPUR.Checked = False Then
                objrep.issupur = False
            End If
            If CHKFINE.Checked = False Then
                objrep.fine = False
            End If
            If CHKPART.Checked = False Then
                objrep.partno = False
            End If
            If CHKPROCESS.Checked = False Then
                objrep.process = False
            End If

            objrep.SAMPLE_REPORT_EXCEL(dt, PERIOD)

        End If

        If FRMSTRING = "FACTISSDIFF" Then
            Dim CONDITION As String = " WHERE 1 = 1 "
            Dim PERIOD As String = ""
            If chkdate.CheckState = CheckState.Checked Then
                CONDITION = CONDITION & " AND DATE1 >= #" & Format(dtpfrom.Value.Date, "MM/dd/yyyy") & "# AND DATE1 <=# " & Format(dtpto.Value.Date, "MM/dd/yyyy") & "#"
                PERIOD = Format(dtpfrom.Value.Date, "dd/MM/yyyy") & " To " & Format(dtpto.Value.Date, "dd/MM/yyyy")
            End If
            If Val(txtlotno.Text.Trim) > 0 Then CONDITION = CONDITION & " AND LOTNO = '" & Val(txtlotno.Text.Trim) & "'"

            dt = New DataTable()
            If tempconn.State = ConnectionState.Open Then tempconn.Close()
            tempconn.Open()
            tempcmd = New OleDbCommand("SELECT * FROM FACTISSDIFF " & CONDITION & " ORDER BY DATE1, LOTNO", tempconn)
            da = New OleDbDataAdapter(tempcmd)
            da.Fill(dt)
            tempconn.Close()
            da.Dispose()

            If dt.Rows.Count = 0 Then
                MsgBox("No Records In Difference Report", MsgBoxStyle.Critical, "Magic Gold")
                Exit Sub
            End If
            Dim objrep As New clsReportDesigner("Factory Issue Diff Report", System.AppDomain.CurrentDomain.BaseDirectory & "Factory Issue Diff Report.xlsx", 2)
            objrep.FACTISSDIFF_REPORT_EXCEL(dt, PERIOD)
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

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub

    Private Sub basicfilter_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            Me.Close()
        ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.S Then       'for sHOIW rEPORT
            Call cmdShowReport_Click(sender, e)
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub basicfilter_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If frmavgsalepur = True Then
            lbl.Visible = False
            lbl1.Visible = False
            cmb.Visible = False
            cmb1.Visible = False
            Me.Text = "Avg Sale Report"
        ElseIf frmpartyitemwast = True Then
            lbl.Visible = True
            lbl1.Visible = True
            cmb.Visible = True
            cmb1.Visible = True
            tempcondition = ""
            fillcmb(cmb, "item_code", "itemmaster", tempcondition)
            tempcondition = ""
            fillcmb(cmb1, "ledger_code", "ledgermaster", tempcondition)
            lbl.Text = "Item Code :"
            lbl1.Text = "Code :"
            Me.Text = "Item Wastage Report"

        ElseIf frmmfgvaccum = True Or frmmfgprocessreport = True Or frmsamplereport = True Then

            lbl.Visible = False
            lbl1.Visible = False
            cmb.Visible = False
            cmb1.Visible = False
            lbllotno.Visible = True
            txtlotno.Visible = True
            If frmmfgvaccum = True Then
                Me.Text = "Vaccum Filter"
                fillcmb(cmbprocess, "Process_name", "processmaster", tempcondition)
                LBLPROCESS.Visible = True
                cmbprocess.Visible = True
            ElseIf frmmfgprocessreport = True Then
                Me.Text = "Process Filter"
                fillcmb(cmbprocess, "Process_name", "processmaster", tempcondition)
                LBLPROCESS.Visible = True
                cmbprocess.Visible = True
            ElseIf frmsamplereport = True Then
                Me.Text = "Sample Filter"
                chkitem.Visible = True
                CHKRECPUR.Visible = True
                chkgross.Visible = True
                CHKNETT.Visible = True
                CHKLOT.Visible = True
                chkinwt.Visible = True
                chkoutwt.Visible = True
                CHKSMPLWT.Visible = True
                CHKISSUEPUR.Visible = True
                CHKFINE.Visible = True
                CHKPART.Visible = True
                CHKPROCESS.Visible = True
            End If
        ElseIf FRMSTRING = "FACTISSDIFF" Then
            Me.Text = "Factory / Party Issue Diff Report"
            lbl.Visible = False
            lbl1.Visible = False
            cmb.Visible = False
            cmb1.Visible = False
            lbllotno.Visible = False
            txtlotno.Visible = False
        End If
    End Sub

    Private Sub txtlotno_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtlotno.KeyPress
        numkeypress(e, txtlotno, Me)
    End Sub

End Class