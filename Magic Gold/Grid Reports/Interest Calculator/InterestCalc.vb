
Imports System.Data.OleDb

Public Class InterestCalc

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub cmdshowdetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdshowdetails.Click
        fillgrid()
    End Sub

    Sub fillgrid()
        Try
            EP.Clear()
            If cmbname.Text.Trim.Length = 0 Then
                EP.SetError(cmbname, "Select Party")
                Exit Sub
            End If

            If Val(TXTPERCENT.Text.Trim) = 0 Then
                EP.SetError(TXTPERCENT, "Enter Rate Of Interest")
                Exit Sub
            End If

            If Val(TXTDAYS.Text.Trim) = 0 Then
                EP.SetError(TXTDAYS, "Enter Days")
                Exit Sub
            End If



            Dim WHERE As String = ""
            Dim OPWHERE As String = ""
            If CHKDATE.Checked = True Then
                WHERE = WHERE & " AND DATE >= #" & Format(dtfrom.Value.Date, "MM/dd/yyyy") & "# AND DATE <=#" & Format(dtto.Value.Date, "MM/dd/yyyy") & "#"
                OPWHERE = OPWHERE & " AND DATE < #" & Format(dtfrom.Value.Date, "MM/dd/yyyy") & "#"
            Else
                WHERE = WHERE & " AND DATE >= #" & Format(startdate.Date, "MM/dd/yyyy") & "# AND DATE <=#" & Format(Now.Date, "MM/dd/yyyy") & "#"
                OPWHERE = OPWHERE & " AND DATE < #" & Format(startdate.Date, "MM/dd/yyyy") & "#"
            End If



            Dim dt As New DataTable
            If tempconn.State = ConnectionState.Open Then tempconn.Close()
            tempconn.Open()
            tempcmd = New OleDbCommand("SELECT 1 AS SORTNO, SRNO, TYPE, NAME, DATE, DEBIT, CREDIT, REMARKS, 0 AS [DAYS], 0.0 AS NETTBALANCE, 0.0 AS TOPAY, 0.0 AS TOREC FROM INTERESTVIEW WHERE TYPE <> 'OPENING' " & WHERE & " AND NAME = '" & cmbname.Text.Trim & "' ORDER BY NAME, DATE  ", tempconn)
            da = New OleDbDataAdapter(tempcmd)
            da.Fill(dt)





            Dim DTROW() As DataRow
            Dim DTOPENING As New DataTable
            If tempconn.State = ConnectionState.Open Then tempconn.Close()
            tempconn.Open()
            tempcmd = New OleDbCommand(" SELECT IIF((SUM(DEBIT) - SUM(CREDIT)> 0),(SUM(DEBIT) - SUM(CREDIT)),0)AS DEBITBAL, IIF((SUM(CREDIT) - SUM(DEBIT)> 0),(SUM(CREDIT) - SUM(DEBIT)),0) AS CREDITBAL FROM INTERESTVIEW WHERE 1=1 " & OPWHERE & " AND NAME = '" & cmbname.Text.Trim & "'", tempconn)
            da = New OleDbDataAdapter(tempcmd)
            da.Fill(DTOPENING)
            If DTOPENING.Rows.Count > 0 Then
                If CHKDATE.CheckState = CheckState.Checked Then
                    If (Val(DTOPENING.Rows(0).Item("DEBITBAL")) > 0 Or Val(DTOPENING.Rows(0).Item("CREDITBAL")) > 0) Then dt.Rows.Add(0, 0, "OPENING", "", dtfrom.Value.Date, Val(DTOPENING.Rows(0).Item("DEBITBAL")), Val(DTOPENING.Rows(0).Item("CREDITBAL")), "", 0, 0, 0, 0)
                Else
                    If (Val(DTOPENING.Rows(0).Item("DEBITBAL")) > 0 Or Val(DTOPENING.Rows(0).Item("CREDITBAL")) > 0) Then dt.Rows.Add(0, 0, "OPENING", "", Format(startdate.Date, "MM/dd/yyyy"), Val(DTOPENING.Rows(0).Item("DEBITBAL")), Val(DTOPENING.Rows(0).Item("CREDITBAL")), "", 0, 0, 0, 0)
                End If
            End If

            If dt.Rows.Count > 0 Then
                Dim CLODAYS As Integer = 0

                DTROW = dt.Select("DATE = MAX(DATE)")
                Dim NETBAL As Double = dt.Compute("(SUM(DEBIT) - SUM(CREDIT))", "")
                If Val(NETBAL) <> 0 Then CLODAYS = 1
                If CHKDATE.CheckState = CheckState.Checked Then
                    CLODAYS = CLODAYS + DateDiff(DateInterval.Day, DTROW(0).Item("DATE"), dtto.Value.Date)
                    If CLODAYS > 0 Then dt.Rows.Add(2, 0, "CLOSING", "", dtto.Value.Date, 0, 0, "", CLODAYS, 0, 0, 0)
                Else
                    CLODAYS = CLODAYS + DateDiff(DateInterval.Day, DTROW(0).Item("DATE"), Now.Date)
                    If CLODAYS > 0 Then dt.Rows.Add(2, 0, "CLOSING", "", Now.Date, 0, 0, "", CLODAYS, 0, 0, 0)
                End If
            End If

            Dim DV As New DataView(dt)
            DV.Sort = "SORTNO ASC, NAME ASC,DATE ASC"

            griddetails.DataSource = DV
            TOTAL()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TOTAL()
        Try

            txttotal.Text = 0.0

            'FOR RUNNING BALANCE
            Dim dtrow As DataRow
            Dim i As Integer
            Dim RUNNINGBAL As Double
            For i = 0 To gridregister.RowCount - 1
                dtrow = gridregister.GetDataRow(i)
                dtrow("NETTBALANCE") = (Val(dtrow("DEBIT")) + Val(RUNNINGBAL)) - Val(dtrow("CREDIT"))
                RUNNINGBAL = dtrow("NETTBALANCE")
            Next


            RUNNINGBAL = 0
            For i = 0 To gridregister.RowCount - 1
                dtrow = gridregister.GetDataRow(i)
                Dim NEWDTROW As DataRow = gridregister.GetDataRow(i + 1)
                'If dtrow("TYPE") = "OPENING" Then
                If NEWDTROW IsNot Nothing AndAlso NEWDTROW("TYPE") <> "CLOSING" Then
                    NEWDTROW("DAYS") = DateDiff(DateInterval.Day, dtrow("DATE"), NEWDTROW("DATE"))
                End If
                'End If

                If dtrow("TYPE") = "CLOSING" Then
                    'IF LAST DATE IS SAME AS CLOSING DATE THEN THERE WILL BE NOT CALCULATIONS OF DATS IN CLOSING
                    'THIS IS DONE BY GULKIT DO NOT CHANGE 
                    Dim TEMPDTROW As DataRow = gridregister.GetDataRow(i - 1)
                    If dtrow("DATE") = TEMPDTROW("DATE") And TEMPDTROW("TYPE") <> "OPENING" Then
                        TEMPDTROW("DAYS") = TEMPDTROW("DAYS") + 1
                        Dim TEMPDTROW1 As DataRow = gridregister.GetDataRow(i - 2)
                        If TEMPDTROW("NETTBALANCE") > 0 Then
                            TEMPDTROW("TOREC") = (((Val(TXTPERCENT.Text.Trim) * Val(TEMPDTROW1("NETTBALANCE"))) / 100) / Val(TXTDAYS.Text.Trim) * Val(TEMPDTROW("DAYS")))
                        Else
                            TEMPDTROW("TOPAY") = (((Val(TXTPERCENT.Text.Trim) * (Val(TEMPDTROW1("NETTBALANCE")) * (-1))) / 100) / Val(TXTDAYS.Text.Trim) * Val(TEMPDTROW("DAYS")))
                        End If
                        dtrow("DAYS") = 0
                    End If

                End If

                If Val(dtrow("DAYS")) > 0 Then
                    If Val(RUNNINGBAL) > 0 Then
                        dtrow("TOREC") = (((Val(TXTPERCENT.Text.Trim) * RUNNINGBAL) / 100) / Val(TXTDAYS.Text.Trim) * Val(dtrow("DAYS")))
                    Else
                        dtrow("TOPAY") = (((Val(TXTPERCENT.Text.Trim) * (RUNNINGBAL * (-1))) / 100) / Val(TXTDAYS.Text.Trim) * Val(dtrow("DAYS")))
                    End If
                End If
                RUNNINGBAL = dtrow("NETTBALANCE")

            Next


            If Val(GTOPAY.SummaryText) > Val(GTOREC.SummaryText) Then
                txttotal.Text = Format(Val(GTOPAY.SummaryText) - Val(GTOREC.SummaryText), "0.00")
                lbldrcrclosing.Text = "Cr"
            Else
                txttotal.Text = Format(Val(GTOREC.SummaryText) - Val(GTOPAY.SummaryText), "0.00")
                lbldrcrclosing.Text = "Dr"
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbname.Enter
        Try
            If cmbname.Text.Trim = "" Then fillname(Me, cmbname, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbname.KeyDown
        Try
            If e.KeyCode = Keys.F1 And e.Alt = True Then
                Dim OBJSELECT As New SelectLedger
                OBJSELECT.STRSEARCH = ""
                OBJSELECT.ShowDialog()
                cmbname.Text = OBJSELECT.TEMPCODE
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbname.Validated
        Try
            If cmbname.Text.Trim <> "" Then
                cmd = New OleDbCommand("select LEDGER_CSTNO AS INTPER from LEDGERMASTER WHERE LEDGER_CODE = '" & cmbname.Text.Trim & "'", conn)
                If conn.State = ConnectionState.Open Then conn.Close()
                conn.Open()
                dr = cmd.ExecuteReader
                If dr.HasRows Then
                    dr.Read()
                    TXTPERCENT.Text = Val(dr("INTPER"))
                End If
                conn.Close()
                dr.Close()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbname.Validating
        Try
            If cmbname.Text.Trim <> "" Then namevalidate(cmbname, e, Me, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub InterestCalc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Then Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub InterestCalc_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            fillname(Me, cmbname, "")
            If cmbname.Text.Trim <> "" Then fillgrid()
            FILLCMB()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLCMB()
        Try
            If cmbname.Text.Trim = "" Then fillname(Me, cmbname, "")
            fillgroup(Me, cmbgroup, cmbgroupid, tempcondition)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub chkdate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKDATE.CheckedChanged
        Try
            dtfrom.Enabled = CHKDATE.CheckState
            dtto.Enabled = CHKDATE.CheckState
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ExcelExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExcelExport.Click
        Try
            Dim PATH As String = Application.StartupPath & "\Interest Calculator.XLS"
            If FileIO.FileSystem.FileExists(PATH) = True Then FileIO.FileSystem.DeleteFile(PATH)
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            Dim PERIOD As String = ""
            If CHKDATE.Checked = True Then PERIOD = dtfrom.Value.Date & " - " & dtto.Value.Date

            opti.SheetName = "Interest Calculator"
            griddetails.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Interest Calculator", gridregister.VisibleColumns.Count + gridregister.GroupCount, cmbname.Text.Trim, PERIOD)
        Catch ex As Exception
            MsgBox("Interest Calculator Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub TXTDAYS_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTDAYS.KeyPress
        numkeypress(e, sender, Me)
    End Sub

    Private Sub TXTPERCENT_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTPERCENT.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub

    Private Sub TOOLPRINT_Click(sender As Object, e As EventArgs) Handles TOOLPRINT.Click
        Try
            'EP.Clear()
            'If Val(TXTPERCENT.Text.Trim) = 0 Then
            '    EP.SetError(TXTPERCENT, "Enter Rate Of Interest")
            '    Exit Sub
            'End If

            'If Val(TXTDAYS.Text.Trim) = 0 Then
            '    EP.SetError(TXTDAYS, "Enter Days")
            '    Exit Sub
            'End If

            'If MsgBox("Wish to Print?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub


            ''FIRST DELETE TEMPINTRESTTABLE
            'Dim OBJCMN As New ClsCommon
            'Dim DTTEMP As DataTable = OBJCMN.Execute_Any_String("DELETE FROM TEMPINTERESTDTLS ", "", "")


            'Dim WHERECLAUSE As String = " AND LEDGERS.ACC_YEARID = " & YearId
            'If cmbname.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " AND LEDGERS.ACC_CMPNAME = '" & cmbname.Text.Trim & "'"
            'If cmbgroup.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " AND GROUPMASTER.GROUP_NAME = '" & cmbgroup.Text.Trim & "'"
            'Dim DTNAME As DataTable = OBJCMN.search(" ISNULL(LEDGERS.ACC_CMPNAME,'') AS NAME", "", " LEDGERS INNER JOIN GROUPMASTER ON LEDGERS.ACC_GROUPID = GROUPMASTER.GROUP_ID ", WHERECLAUSE & " ORDER BY LEDGERS.ACC_CMPNAME ")
            'For Each DRNAME As DataRow In DTNAME.Rows

            '    If cmbgroup.Text.Trim <> "" Then
            '        cmbname.Text = DRNAME("NAME")
            '        cmdshowdetails_Click(sender, e)
            '    End If


            '    Dim OBJINTCALC As New ClsInterestCalc
            '    Dim ALPARAVAL As New ArrayList
            '    If CHKDATE.CheckState = CheckState.Checked Then ALPARAVAL.Add("Interest Statement From : " & Format(dtfrom.Value.Date, "dd/MM/yyyy").ToString & " To " & Format(dtto.Value.Date, "dd/MM/yyyy").ToString) Else ALPARAVAL.Add("Interest Statement From : " & Format(AccFrom, "dd/MM/yyyy").ToString & " To " & Format(AccTo, "dd/MM/yyyy").ToString)
            '    ALPARAVAL.Add(Val(TXTPERCENT.Text.Trim))
            '    ALPARAVAL.Add(cmbname.Text.Trim)

            '    Dim DTTDS As DataTable = OBJCMN.search("ISNULL(ACC_TDSPER,0) AS TDSPER, ISNULL(ACC_TDSFORM,'TDS') AS TDSFORM, ISNULL(ACC_PANNO,'') AS PANNO ", "", " LEDGERS INNER JOIN ACCOUNTSMASTER_TDS ON LEDGERS.Acc_id = ACCOUNTSMASTER_TDS.ACC_ID  ", " AND ACC_CMPNAME = '" & cmbname.Text.Trim & "' AND LEDGERS.ACC_YEARID = " & YearId)
            '    If DTTDS.Rows.Count > 0 Then
            '        ALPARAVAL.Add(Val(DTTDS.Rows(0).Item("TDSPER")))
            '        ALPARAVAL.Add(DTTDS.Rows(0).Item("TDSFORM"))
            '        ALPARAVAL.Add(DTTDS.Rows(0).Item("PANNO"))
            '    Else
            '        ALPARAVAL.Add(0)
            '        ALPARAVAL.Add("")
            '        ALPARAVAL.Add("")
            '    End If

            '    Dim BILLNO As String = ""
            '    Dim TYPE As String = ""
            '    Dim SIDE As String = ""
            '    Dim BILLDATE As String = ""
            '    Dim DRBAL As String = ""
            '    Dim CRBAL As String = ""
            '    Dim NETTBALANCE As String = ""
            '    Dim DAYS As String = ""
            '    Dim INTTOPAY As String = ""
            '    Dim INTTOREC As String = ""
            '    Dim GRIDREMARKS As String = ""
            '    Dim LINENO As String = ""

            '    For I As Integer = 0 To gridregister.RowCount - 1
            '        Dim DTROW As DataRow = gridregister.GetDataRow(I)
            '        Dim DTTERM As New DataTable
            '        If DTROW("TYPE") = "SALE" Then DTTERM = OBJCMN.search("INVOICE_CRDAYS AS CRDAYS", "", " INVOICEMASTER ", " AND INVOICE_INITIALS = '" & DTROW("BILLINITIALS") & "' AND INVOICE_YEARID = " & YearId)

            '        If BILLNO = "" Then
            '            BILLNO = DTROW("BILLINITIALS")
            '            TYPE = DTROW("TYPE")
            '            If DTTERM.Rows.Count > 0 Then SIDE = Val(DTTERM.Rows(0).Item("CRDAYS")) Else SIDE = 0
            '            If RBBILLDATE.Checked = True Then BILLDATE = Format(Convert.ToDateTime(DTROW("DATE")).Date, "MM/dd/yyyy") Else BILLDATE = Format(Convert.ToDateTime(DTROW("DUEDATE")).Date, "MM/dd/yyyy")
            '            DRBAL = Val(DTROW("DEBIT"))
            '            CRBAL = Val(DTROW("CREDIT"))
            '            NETTBALANCE = Val(DTROW("NETTBALANCE"))
            '            DAYS = Val(DTROW("DAYS"))
            '            If IsDBNull(DTROW("TOPAY")) = False Then INTTOPAY = Val(DTROW("TOPAY")) Else INTTOPAY = 0
            '            If IsDBNull(DTROW("TOREC")) = False Then INTTOREC = Val(DTROW("TOREC")) Else INTTOREC = 0
            '            GRIDREMARKS = DTROW("REMARKS")
            '            LINENO = Val(I) + 1
            '        Else
            '            BILLNO = BILLNO & "|" & DTROW("BILLINITIALS")
            '            TYPE = TYPE & "|" & DTROW("TYPE")
            '            If DTTERM.Rows.Count > 0 Then SIDE = SIDE & "|" & Val(DTTERM.Rows(0).Item("CRDAYS")) Else SIDE = SIDE & "|" & 0
            '            If RBBILLDATE.Checked = True Then BILLDATE = BILLDATE & "|" & Format(Convert.ToDateTime(DTROW("DATE")).Date, "MM/dd/yyyy") Else BILLDATE = BILLDATE & "|" & Format(Convert.ToDateTime(DTROW("DUEDATE")).Date, "MM/dd/yyyy")
            '            DRBAL = DRBAL & "|" & Val(DTROW("DEBIT"))
            '            CRBAL = CRBAL & "|" & Val(DTROW("CREDIT"))
            '            NETTBALANCE = NETTBALANCE & "|" & Val(DTROW("NETTBALANCE"))
            '            DAYS = DAYS & "|" & Val(DTROW("DAYS"))
            '            If IsDBNull(DTROW("TOPAY")) = False Then INTTOPAY = INTTOPAY & "|" & Val(DTROW("TOPAY")) Else INTTOPAY = INTTOPAY & "|" & 0
            '            If IsDBNull(DTROW("TOREC")) = False Then INTTOREC = INTTOREC & "|" & Val(DTROW("TOREC")) Else INTTOREC = INTTOREC & "|" & 0
            '            GRIDREMARKS = GRIDREMARKS & "|" & DTROW("REMARKS")
            '            LINENO = LINENO & "|" & Val(I) + 1
            '        End If

            '    Next

            '    ALPARAVAL.Add(BILLNO)
            '    ALPARAVAL.Add(TYPE)
            '    ALPARAVAL.Add(SIDE)
            '    ALPARAVAL.Add(BILLDATE)
            '    ALPARAVAL.Add(DRBAL)
            '    ALPARAVAL.Add(CRBAL)
            '    ALPARAVAL.Add(NETTBALANCE)
            '    ALPARAVAL.Add(DAYS)
            '    ALPARAVAL.Add(INTTOPAY)
            '    ALPARAVAL.Add(INTTOREC)
            '    ALPARAVAL.Add(GRIDREMARKS)
            '    ALPARAVAL.Add(LINENO)
            '    ALPARAVAL.Add(cmbgroup.Text.Trim)
            '    ALPARAVAL.Add(CMPID)
            '    ALPARAVAL.Add(YearId)

            '    OBJINTCALC.alParaval = ALPARAVAL
            '    OBJINTCALC.SAVEDETAILS()

            'Next




            'Dim OBJPLPRINT As New PLDesign
            'OBJPLPRINT.MdiParent = MDIMain
            'OBJPLPRINT.frmstring = "INTERESTDTLS"
            'OBJPLPRINT.INTPER = Val(TXTPERCENT.Text.Trim)
            'OBJPLPRINT.CALCDAYS = Val(TXTDAYS.Text.Trim)
            'If MsgBox("Show Narration", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then OBJPLPRINT.SHOWNARR = 1
            'OBJPLPRINT.Show()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub


End Class