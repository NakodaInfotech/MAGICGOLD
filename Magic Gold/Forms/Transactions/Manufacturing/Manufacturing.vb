
Imports System.Data.OleDb
Imports System.IO

Public Class Manufacturing

    Dim m_EditingRow As Integer = -1
    Dim ORDERITEMNAME As String = ""
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim STOPVALIDATE As Boolean = False
    Public EDIT As Boolean = False

    Sub clear()

        'clearing array
        For i = 1 To 100
            tempcol(i) = ""
            tempval(i) = ""
        Next

        'clearing arrays
        For i = 0 To 50
            mfgprocessno(i) = 0
            MFGORDERNO(i) = 0
            MFGBARCODE(i) = ""
            partname(i) = 0
            tempnarration(i) = ""
            mfgitemname(i) = ""
            percentinput(i) = 0
            lotfail(i) = False
            LOTFAILMERGED(i) = False
        Next

        CHKMERGE.CheckState = CheckState.Checked

        'CLEARING TEMPSPLIT
        cmd = New OleDbCommand("delete from tempsplit WHERE MFG_NO=  " & Val(txtmfgno.Text.Trim), conn)
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If
        conn.Open()
        cmd.ExecuteNonQuery()


        'deleting data from tempkarigarissue
        tempcmd = New OleDbCommand("delete from tempkarigarissue WHERE MFG_NO = " & Val(txtmfgno.Text.Trim), tempconn)
        If tempconn.State = ConnectionState.Open Then
            tempconn.Close()
        End If
        tempconn.Open()
        tempcmd.ExecuteNonQuery()


        TXTNAME.Clear()
        TXTITEMNAME.Clear()
        LBLNAME.Text = ""
        TXTORDERNO.Clear()
        txtmelting.Clear()
        txtlotno.Clear()
        txtlotno.Enabled = True
        TXTREFNO.Clear()
        TXTREFNO.Enabled = True
        txtnarration.Clear()
        cmbpart.Text = ""

        TXTIRON.Clear()
        TXTIRONRETWT.Clear()
        txtinput.Clear()
        txtoutput.Clear()
        txtsample.Clear()
        txtwastage.Clear()
        txtloss.Clear()
        txtvaccum.Clear()
        txtexcess.Clear()
        txtpurity.Clear()
        txtpercentin.Clear()
        txtpercentout.Clear()
        txtpercentfinal.Clear()
        mfgdate.Value = GLOBALDATE
        processdate.Value = GLOBALDATE
        gridkarigar.RowCount = 1
        gridmfg.RowCount = 1
        lblfailed.Visible = False
        groupkarigar.Enabled = False
        groupgrid.Enabled = False
        groupmfg.Enabled = False


        TXTBARCODE.Clear()
        TXTREMARKS.Clear()
        TXTBRIEF.Clear()

        mfgprocessno(1) = 1
        splitno = 1

        selectprocess(mfgprocessno(1))


        edit = False

        'getting mfg_no from database
        GETMAX_MFG_NO()
        MFGBARCODE(1) = "MFG-" & Val(txtmfgno.Text.Trim) & "/1/" & Val(CMPID)

        If ClientName = "SHASHAWAT" Or ClientName = "SANGAM" Then TXTBARCODE.Focus() Else txtlotno.Focus()

    End Sub

    Sub GETMAX_MFG_NO()
        cmd = New OleDbCommand("Select IIF(ISNULL(max(MFG_NO)) = True, 0,max(MFG_NO)) + 1 from mfgmaster", conn)
        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Open()
        dr = cmd.ExecuteReader
        If dr.HasRows Then
            dr.Read()
            txtmfgno.Text = Val(dr(0).ToString)
        End If
        conn.Close()
        dr.Close()



        tempcmd = New OleDbCommand("Select IIF(ISNULL(max(MFG_NO)) = True, 0,max(MFG_NO)) + 1 from TEMPSPLIT ", tempconn)
        If tempconn.State = ConnectionState.Open Then tempconn.Close()
        tempconn.Open()
        tempdr = tempcmd.ExecuteReader
        If tempdr.HasRows Then
            tempdr.Read()
            If Val(tempdr(0)) > Val(txtmfgno.Text.Trim) Then txtmfgno.Text = Val(tempdr(0).ToString)
        End If
        tempconn.Close()
        tempdr.Close()


        'CHECK SAME CODE IN TEMPKARIGARISSUE
        cmd = New OleDbCommand("Select IIF(ISNULL(max(MFG_NO)) = True, 0,max(MFG_NO)) + 1 from TEMPKARIGARISSUE WHERE MFG_LOTNO = " & Val(txtlotno.Text.Trim), conn)
        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Open()
        dr = cmd.ExecuteReader
        If dr.HasRows Then
            dr.Read()
            If Val(dr(0)) > Val(txtmfgno.Text.Trim) Then txtmfgno.Text = Val(dr(0).ToString)
        End If
        conn.Close()
        dr.Close()

    End Sub

    Sub selectprocess(ByVal no As Integer)
        If tempprocessno(no) <> 0 Then

            lblprocess.Text = "Process :  " & tempprocess(no)

            lblloss.Visible = tempprocessloss(no)
            txtloss.Visible = tempprocessloss(no)

            lblvaccum.Visible = tempprocessvaccum(no)
            txtvaccum.Visible = tempprocessvaccum(no)

            lblexcess.Visible = tempprocessexcess(no)
            txtexcess.Visible = tempprocessexcess(no)
            lblpurity.Visible = tempprocessexcess(no)
            txtpurity.Visible = tempprocessexcess(no)

            groupkarigar.Enabled = tempprocesskarigar(no)
            gridkarigar.Enabled = tempprocesskarigar(no)

        Else
            lblprocess.Text = "Process : Completed"
            'mfgitemname(txtpart.SelectedText) = ""
        End If
    End Sub

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        If Val(txtlotno.Text) <> 0 And gridmfg.RowCount > 1 And Val(txtmelting.Text) <> 0 And chkchange.CheckState = CheckState.Checked Then
            tempmsg = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
            If tempmsg = vbYes Then cmdsave_Click(sender, e)
        End If
        Me.Close()
    End Sub

    Private Sub txtlotno_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtlotno.KeyDown
        If e.KeyCode = Keys.F1 Then

            If (chldselectlotno.IsMdiChild = False) Then
                If chldselectlotno.IsDisposed = True Then
                    chldselectlotno = New Selectlotno
                End If
                chldselectlotno.MdiParent = MDIMain
                chldselectlotno.Show()
            Else
                chldselectlotno.BringToFront()
            End If

        End If
    End Sub

    Private Sub txtlotno_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtlotno.KeyPress
        numkeypress(e, txtlotno, Me)
    End Sub

    Private Sub mfgdate_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles mfgdate.KeyDown
        If e.KeyCode = 13 Then
            SendKeys.Send("{Tab}")
            e.Handled = False
        End If
    End Sub

    Private Sub processdate_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles processdate.KeyDown
        If e.KeyCode = 13 Then
            SendKeys.Send("{Tab}")
            e.Handled = False
        End If
    End Sub

    Private Sub txtnarration_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtnarration.KeyPress
        enterkeypress(e, Me)
    End Sub

    Private Sub cmbpart_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbpart.KeyPress
        enterkeypress(e, Me)
    End Sub

    Private Sub txtinput_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtinput.KeyPress, TXTIRON.KeyPress, TXTIRONRETWT.KeyPress
        AMOUNTNUMDOTKYEPRESS(e, sender, Me)
    End Sub

    Private Sub txtoutput_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtoutput.KeyPress
        numdot(e, txtoutput, Me)
    End Sub

    Private Sub txtsample_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtsample.KeyPress
        numdot(e, txtsample, Me)
    End Sub

    Private Sub txtwastage_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtwastage.KeyPress
        numdot(e, txtwastage, Me)
    End Sub

    Private Sub txtvaccum_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtvaccum.KeyPress
        numdot(e, txtvaccum, Me)
    End Sub

    Private Sub txtloss_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtloss.KeyPress
        numdot(e, txtloss, Me)
    End Sub

    Private Sub txtexcess_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtexcess.KeyPress
        numdot(e, txtexcess, Me)
    End Sub

    Private Sub txtpurity_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtpurity.KeyPress
        numdotkeypress(e, txtpurity, Me)
    End Sub

    Private Sub txtpercentfinal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtpercentfinal.KeyPress
        enterkeypress(e, Me)
    End Sub

    Private Sub txtpercentin_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtpercentin.KeyPress
        enterkeypress(e, Me)
    End Sub

    Private Sub txtpercentout_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtpercentout.KeyPress
        enterkeypress(e, Me)
    End Sub

    Private Sub cmdclear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        clear()
        cmdedit.Enabled = True
    End Sub

    Private Sub Manufcaturing_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        If e.KeyCode <> Keys.Escape Then chkchange.CheckState = CheckState.Checked

        If (e.Alt = True And e.KeyCode = Windows.Forms.Keys.N) Then       'for Saving
            Call cmdsave_Click(sender, e)
            txtlotno.Focus()
        ElseIf e.KeyCode = Keys.Escape Then
            If Val(txtlotno.Text) <> 0 And gridmfg.RowCount > 1 And Val(txtmelting.Text) <> 0 And chkchange.CheckState = CheckState.Checked Then
                tempmsg = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                If tempmsg = vbYes Then cmdsave_Click(sender, e)
            End If
            Me.Close()

            'manufacturing details
            If (chldmfgdetails.IsMdiChild = False) Then
                If chldmfgdetails.IsDisposed = True Then
                    chldmfgdetails = New Manufacturingdetails
                End If
                chldmfgdetails.MdiParent = MDIMain
                chldmfgdetails.Show()
            Else
                chldmfgdetails.BringToFront()
            End If
        ElseIf e.KeyCode = Keys.B And e.Alt = True Then
            TXTBARCODE.Focus()
        ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.Left Then       'for DELETE
            Call toolprevious_Click(sender, e)
        ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.Right Then       'for DELETE
            Call toolnext_Click(sender, e)
        End If


        ''****** CTRL + N *************
        'If e.Control = True And e.KeyCode = Keys.N Then
        '    If Val(txtlotno.Text) <> 0 And gridmfg.RowCount > 1 And Val(txtmelting.Text) <> 0 And chkchange.CheckState = CheckState.Checked Then
        '        tempmsg = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
        '        If tempmsg = vbYes Then cmdsave_Click(sender, e)
        '    End If
        '    clear()
        'End If

    End Sub

    Sub SAMPLEACCOUNTS(ByVal ROWNO As Integer)
        Try
            Dim tempc(15), tempv(15) As String
            For i = 0 To 15
                tempc(i) = ""
                tempv(i) = ""
            Next

            tempc(0) = "account_id"
            tempc(1) = "account_date"
            tempc(2) = "account_ledgerid"
            tempc(3) = "account_itemid"
            tempc(4) = "account_purity"
            tempc(5) = "account_wastage"
            tempc(6) = "account_grosswt"
            tempc(7) = "account_nettwt"
            tempc(8) = "account_amount"
            tempc(9) = "account_balorjamaorpaid"
            tempc(10) = "account_narration"
            tempc(11) = "account_type"
            tempc(12) = "account_voucherid"
            tempc(13) = "account_SUBtype"
            tempc(14) = "account_ledgercode"
            tempc(15) = "account_USERID"
            tempc(16) = "account_DEPARTMENTID"
            tempc(17) = "account_PROCESS"


            'GET MAXNUMBE FROM ACCOUNTMASTER
            tempcmd = New OleDbCommand("select max(account_id) AS [ACCOUNTSID] from accountmaster", tempconn)
            If tempconn.State = ConnectionState.Open Then tempconn.Close()
            tempconn.Open()
            tempdr = tempcmd.ExecuteReader
            If tempdr.HasRows Then
                tempdr.Read()
                tempv(0) = Val(tempdr("ACCOUNTSID")) + 1
            End If
            tempconn.Close()
            tempdr.Close()

            tempv(1) = "'" & Format(Convert.ToDateTime(gridmfg.Rows(ROWNO).Cells("PDATE").Value).Date, "dd/MM/yyyy") & "'"


            'getting nameid
            cmd = New OleDbCommand("select LEDGERMASTER.LEDGER_ID AS LEDGERID, LEDGERMASTER.LEDGER_CODE AS LEDGERCODE  from PROCESSMASTER INNER JOIN LEDGERMASTER ON LEDGERMASTER.LEDGER_ID = PROCESSMASTER.PROCESS_LEDGERID where PROCESSMASTER.PROCESS_NAME = '" & gridmfg.Rows(ROWNO).Cells("PROCESSNAME").Value & "'", conn)
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Open()
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                dr.Read()
                tempv(2) = Val(dr("LEDGERID"))
                tempv(14) = "'" & dr("LEDGERCODE") & "'"
            Else
                tempv(2) = Val(0)
            End If
            conn.Close()


            'getting ITEMID
            cmd = New OleDbCommand("select ITEM_ID AS ITEMID from ITEMMASTER where ITEM_NAME = 'BAR'", conn)
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Open()
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                dr.Read()
                tempv(3) = Val(dr("ITEMID"))
            Else
                tempv(3) = Val(0)
            End If
            conn.Close()

            tempv(4) = Val(gridmfg.Rows(ROWNO).Cells("PEROUT").Value)
            tempv(5) = Val(0)
            tempv(6) = Val(gridmfg.Rows(ROWNO).Cells("SAMPLE").Value)
            tempv(7) = ((Val(gridmfg.Rows(ROWNO).Cells("SAMPLE").Value) * Val(gridmfg.Rows(ROWNO).Cells("PEROUT").Value)) / 100)
            tempv(8) = Val(0)
            tempv(9) = "'Balance'"
            tempv(10) = "''"
            tempv(11) = "'M'"
            tempv(12) = Val(txtmfgno.Text)
            tempv(13) = "'MFG'"
            tempv(15) = Val(USERID)
            tempv(16) = Val(USERDEPARTMENTID)
            tempv(17) = "'" & gridmfg.Rows(ROWNO).Cells("PROCESSNAME").Value & "'"

            insert("accountmaster", tempc, tempv)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub WASTAGEACCOUNTS(ByVal ROWNO As Integer)
        Try
            Try
                Dim tempc(15), tempv(15) As String
                For i = 0 To 15
                    tempc(i) = ""
                    tempv(i) = ""
                Next

                tempc(0) = "account_id"
                tempc(1) = "account_date"
                tempc(2) = "account_ledgerid"
                tempc(3) = "account_itemid"
                tempc(4) = "account_purity"
                tempc(5) = "account_wastage"
                tempc(6) = "account_grosswt"
                tempc(7) = "account_nettwt"
                tempc(8) = "account_amount"
                tempc(9) = "account_balorjamaorpaid"
                tempc(10) = "account_narration"
                tempc(11) = "account_type"
                tempc(12) = "account_voucherid"
                tempc(13) = "account_SUBtype"
                tempc(14) = "account_ledgercode"
                tempc(15) = "account_USERID"
                tempc(16) = "account_DEPARTMENTID"
                tempc(17) = "account_PROCESS"


                'GET MAXNUMBE FROM ACCOUNTMASTER
                tempcmd = New OleDbCommand("select max(account_id) AS [ACCOUNTSID] from accountmaster", tempconn)
                If tempconn.State = ConnectionState.Open Then tempconn.Close()
                tempconn.Open()
                tempdr = tempcmd.ExecuteReader
                If tempdr.HasRows Then
                    tempdr.Read()
                    tempv(0) = Val(tempdr("ACCOUNTSID")) + 1
                End If
                tempconn.Close()
                tempdr.Close()

                tempv(1) = "'" & Format(Convert.ToDateTime(gridmfg.Rows(ROWNO).Cells("PDATE").Value).Date, "dd/MM/yyyy") & "'"


                'getting nameid
                cmd = New OleDbCommand("select LEDGERMASTER.LEDGER_ID AS LEDGERID, LEDGERMASTER.LEDGER_CODE AS LEDGERCODE  from PROCESSMASTER INNER JOIN LEDGERMASTER ON LEDGERMASTER.LEDGER_ID = PROCESSMASTER.PROCESS_LEDGERID where PROCESSMASTER.PROCESS_NAME = '" & gridmfg.Rows(ROWNO).Cells("PROCESSNAME").Value & "'", conn)
                If conn.State = ConnectionState.Open Then conn.Close()
                conn.Open()
                dr = cmd.ExecuteReader()
                If dr.HasRows Then
                    dr.Read()
                    tempv(2) = Val(dr("LEDGERID"))
                    tempv(14) = "'" & dr("LEDGERCODE") & "'"
                Else
                    tempv(2) = Val(0)
                End If
                conn.Close()

                'getting ITEMID
                cmd = New OleDbCommand("select ITEM_ID AS ITEMID from ITEMMASTER where ITEM_NAME = 'BAR'", conn)
                If conn.State = ConnectionState.Open Then conn.Close()
                conn.Open()
                dr = cmd.ExecuteReader()
                If dr.HasRows Then
                    dr.Read()
                    tempv(3) = Val(dr("ITEMID"))
                Else
                    tempv(3) = Val(0)
                End If
                conn.Close()

                tempv(4) = Val(gridmfg.Rows(ROWNO).Cells("PEROUT").Value)
                tempv(5) = Val(0)
                tempv(6) = Val(gridmfg.Rows(ROWNO).Cells("WAS").Value)
                tempv(7) = ((Val(gridmfg.Rows(ROWNO).Cells("WAS").Value) * Val(gridmfg.Rows(ROWNO).Cells("PEROUT").Value)) / 100)
                tempv(8) = Val(0)
                tempv(9) = "'Balance'"
                tempv(10) = "''"
                tempv(11) = "'M'"
                tempv(12) = Val(txtmfgno.Text)
                tempv(13) = "'MFG'"
                tempv(15) = Val(USERID)
                tempv(16) = Val(USERDEPARTMENTID)
                tempv(17) = "'" & gridmfg.Rows(ROWNO).Cells("PROCESSNAME").Value & "'"

                insert("accountmaster", tempc, tempv)

            Catch ex As Exception
                Throw ex
            End Try
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub VACCUMACCOUNTS(ByVal ROWNO As Integer)
        Try
            Try
                Dim tempc(15), tempv(15) As String
                For i = 0 To 15
                    tempc(i) = ""
                    tempv(i) = ""
                Next

                tempc(0) = "account_id"
                tempc(1) = "account_date"
                tempc(2) = "account_ledgerid"
                tempc(3) = "account_itemid"
                tempc(4) = "account_purity"
                tempc(5) = "account_wastage"
                tempc(6) = "account_grosswt"
                tempc(7) = "account_nettwt"
                tempc(8) = "account_amount"
                tempc(9) = "account_balorjamaorpaid"
                tempc(10) = "account_narration"
                tempc(11) = "account_type"
                tempc(12) = "account_voucherid"
                tempc(13) = "account_SUBtype"
                tempc(14) = "account_ledgercode"
                tempc(15) = "account_USERID"
                tempc(16) = "account_DEPARTMENTID"
                tempc(17) = "account_PROCESS"


                'GET MAXNUMBE FROM ACCOUNTMASTER
                tempcmd = New OleDbCommand("select max(account_id) AS [ACCOUNTSID] from accountmaster", tempconn)
                If tempconn.State = ConnectionState.Open Then tempconn.Close()
                tempconn.Open()
                tempdr = tempcmd.ExecuteReader
                If tempdr.HasRows Then
                    tempdr.Read()
                    tempv(0) = Val(tempdr("ACCOUNTSID")) + 1
                End If
                tempconn.Close()
                tempdr.Close()

                tempv(1) = "'" & Format(Convert.ToDateTime(gridmfg.Rows(ROWNO).Cells("PDATE").Value).Date, "dd/MM/yyyy") & "'"


                'getting nameid
                cmd = New OleDbCommand("select LEDGERMASTER.LEDGER_ID AS LEDGERID, LEDGERMASTER.LEDGER_CODE AS LEDGERCODE  from PROCESSMASTER INNER JOIN LEDGERMASTER ON LEDGERMASTER.LEDGER_ID = PROCESSMASTER.PROCESS_LEDGERID where PROCESSMASTER.PROCESS_NAME = '" & gridmfg.Rows(ROWNO).Cells("PROCESSNAME").Value & "'", conn)
                If conn.State = ConnectionState.Open Then conn.Close()
                conn.Open()
                dr = cmd.ExecuteReader()
                If dr.HasRows Then
                    dr.Read()
                    tempv(2) = Val(dr("LEDGERID"))
                    tempv(14) = "'" & dr("LEDGERCODE") & "'"
                Else
                    tempv(2) = Val(0)
                End If
                conn.Close()

                'getting ITEMID
                cmd = New OleDbCommand("select ITEM_ID AS ITEMID from ITEMMASTER where ITEM_NAME = 'BAR'", conn)
                If conn.State = ConnectionState.Open Then conn.Close()
                conn.Open()
                dr = cmd.ExecuteReader()
                If dr.HasRows Then
                    dr.Read()
                    tempv(3) = Val(dr("ITEMID"))
                Else
                    tempv(3) = Val(0)
                End If
                conn.Close()


                tempv(4) = Val(gridmfg.Rows(ROWNO).Cells("PEROUT").Value)
                tempv(5) = Val(0)
                tempv(6) = Val(gridmfg.Rows(ROWNO).Cells("VACCUM").Value)
                tempv(7) = ((Val(gridmfg.Rows(ROWNO).Cells("VACCUM").Value) * Val(gridmfg.Rows(ROWNO).Cells("PEROUT").Value)) / 100)
                tempv(8) = Val(0)
                tempv(9) = "'Balance'"
                tempv(10) = "''"
                tempv(11) = "'M'"
                tempv(12) = Val(txtmfgno.Text)
                tempv(13) = "'MFG'"
                tempv(15) = Val(USERID)
                tempv(16) = Val(USERDEPARTMENTID)
                tempv(17) = "'" & gridmfg.Rows(ROWNO).Cells("PROCESSNAME").Value & "'"

                insert("accountmaster", tempc, tempv)

            Catch ex As Exception
                Throw ex
            End Try
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdsave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdsave.Click
        Try
            Dim j As Integer    'for loop
            Dim TEMPD As Date   'FOR DATE FROM GRID

            ''IF BACK DATED ENTRY IS TO BE SAVED THEN CHECK ENTRYPASSWORD
            ''THIS WILL BE DONE ON FINALPURITY'S VALIDATING EVENT
            'If APPLYBLOCKDATE = True And mfgdate.Value.Date <= BLOCKEDDATE.Date Then
            '    Dim OBJPASS As New PasswordEntry
            '    OBJPASS.ShowDialog()
            '    If ENTRYPASSWORD <> OBJPASS.TXTDATERETYPE.Text.Trim Then
            '        MsgBox("Invaid Password", MsgBoxStyle.Critical)
            '        Exit Sub
            '    End If
            'End If

            If Val(txtlotno.Text) <> 0 And gridmfg.RowCount > 1 Then

                If cmdedit.Enabled = False Then edit = True
                If cmdedit.Enabled = True Then edit = False


                For i = 0 To 100
                    tempcol(i) = ""
                    tempval(i) = ""
                Next



                'FOR UPDATING ORDERMASTER
                cmd = New OleDbCommand("SELECT mfgstock.MFG_ORDERNO  FROM mfgmaster INNER JOIN mfgstock ON mfgmaster.mfg_no = mfgstock.mfg_no  WHERE MFGMASTER.MFG_NO = " & Val(txtmfgno.Text.Trim), conn)
                If conn.State = ConnectionState.Open Then conn.Close()
                conn.Open()
                dr = cmd.ExecuteReader
                If dr.HasRows = True Then
                    While (dr.Read)
                        If Val(dr(0)) > 0 Then
                            tempcmd = New OleDbCommand("update ORDERMASTER SET ORDER_DONE = 0 where ORDER_SRNO = " & Val(dr(0)), tempconn)
                            If tempconn.State = ConnectionState.Open Then tempconn.Close()
                            tempconn.Open()
                            tempcmd.ExecuteNonQuery()
                        End If
                    End While
                End If


                If edit = True Then

                    If USEREDIT = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    '********** DONE BY GULKIT FOR TESTING *********************************
                    'IF WE DWELETE FIRST AND ANY ERROR COMES WHILE SAVING THEN WHOLE LOT GETS DELETED AND NEW LOT DOES NOT GET SAVED
                    'TO OVERCOME THIS PROBLEM WE HAVE COME WITH A SOLUTION
                    'WE WILL NOT DELETE THE ENTRIES HERE, WE WILL JUST MARK THEM FOR DELETION AND IF NEW DATA ENTERED SUCCESSFULLY THEN DELETE THESE ENTRIES 
                    'IF THERE IS ANY ERROR then we will undo the deleted entry

                    'deleting data from mfgmaster
                    tempcmd = New OleDbCommand("update mfgmaster set MFG_DELETE = True where mfg_no = " & Val(txtmfgno.Text), tempconn)
                    If tempconn.State = ConnectionState.Open Then
                        tempconn.Close()
                    End If
                    tempconn.Open()
                    tempcmd.ExecuteNonQuery()


                    'deleting data from mfgdescription
                    tempcmd = New OleDbCommand("UPDATE mfgdescription SET MFG_DELETE = True where mfg_no = " & Val(txtmfgno.Text), tempconn)
                    If tempconn.State = ConnectionState.Open Then
                        tempconn.Close()
                    End If
                    tempconn.Open()
                    tempcmd.ExecuteNonQuery()


                    'deleting data from MFGBARCODE
                    tempcmd = New OleDbCommand("UPDATE MFGBARCODE SET MFG_DELETE = TRUE where mfg_no = " & Val(txtmfgno.Text), tempconn)
                    If tempconn.State = ConnectionState.Open Then
                        tempconn.Close()
                    End If
                    tempconn.Open()
                    tempcmd.ExecuteNonQuery()


                    'deleting data from karigarissue
                    tempcmd = New OleDbCommand("UPDATE karigarissue SET MFG_DELETE = TRUE where mfg_no = " & Val(txtmfgno.Text), tempconn)
                    If tempconn.State = ConnectionState.Open Then
                        tempconn.Close()
                    End If
                    tempconn.Open()
                    tempcmd.ExecuteNonQuery()


                    'deleting data from mfgdstock
                    tempcmd = New OleDbCommand("UPDATE mfgstock SET MFG_DELETE = TRUE where mfg_no = " & Val(txtmfgno.Text), tempconn)
                    If tempconn.State = ConnectionState.Open Then
                        tempconn.Close()
                    End If
                    tempconn.Open()
                    tempcmd.ExecuteNonQuery()


                    'deleting data from lotfail
                    tempcmd = New OleDbCommand("UPDATE lotfail SET MFG_DELETE = TRUE where mfg_no = " & Val(txtmfgno.Text), tempconn)
                    If tempconn.State = ConnectionState.Open Then
                        tempconn.Close()
                    End If
                    tempconn.Open()
                    tempcmd.ExecuteNonQuery()


                    'deleting data from splitmaster
                    tempcmd = New OleDbCommand("UPDATE splitmaster SET MFG_DELETE = TRUE where mfg_no = " & Val(txtmfgno.Text), tempconn)
                    If tempconn.State = ConnectionState.Open Then
                        tempconn.Close()
                    End If
                    tempconn.Open()
                    tempcmd.ExecuteNonQuery()


                    'deleting data from itemstock
                    tempcmd = New OleDbCommand("UPDATE itemstock SET ITEM_DELETE = TRUE where item_no = " & Val(txtmfgno.Text) & " and item_partno <> 0 ", tempconn)
                    If tempconn.State = ConnectionState.Open Then
                        tempconn.Close()
                    End If
                    tempconn.Open()
                    tempcmd.ExecuteNonQuery()


                    'deleting data from ACCOUNTMASTER (CODE ADDED TO ADD WASTAGE AND VACCUM IN ACCOUNTSMASTETR)
                    tempcmd = New OleDbCommand("UPDATE ACCOUNTMASTER SET ACCOUNT_DELETE = TRUE where ACCOUNT_VOUCHERID = " & Val(txtmfgno.Text) & " and ACCOUNT_TYPE = 'M' AND ACCOUNT_SUBTYPE ='MFG'", tempconn)
                    If tempconn.State = ConnectionState.Open Then
                        tempconn.Close()
                    End If
                    tempconn.Open()
                    tempcmd.ExecuteNonQuery()

                    '*********************** END OF TEST CODE *************************


                ElseIf edit = False Then

                    If USERADD = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If

                    'IF MULTIPLE USERS ARE WORKING ON THE SAME FORM THEN WE NEED THIS
                    'CHECK SAME CODE IN TEMPSPLIT IF LOTNO IS PRESENT IN TEMPSPLIT THEN DONT CHECK MAX NO
                    cmd = New OleDbCommand("Select MFG_NO from TEMPSPLIT WHERE MFG_LOTNO = " & Val(txtlotno.Text.Trim), conn)
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Open()
                    dr = cmd.ExecuteReader
                    If dr.HasRows = False Then
                        cmd.Dispose()

                        cmd = New OleDbCommand("Select MFG_NO from TEMPKARIGARISSUE WHERE MFG_LOTNO = " & Val(txtlotno.Text.Trim), conn)
                        If conn.State = ConnectionState.Open Then conn.Close()
                        conn.Open()
                        dr = cmd.ExecuteReader
                        If dr.HasRows = False Then
                            GETMAX_MFG_NO()
                        End If

                    End If
                End If



                'writing mfg in melting table
                tempcol(0) = "melting_mfg"
                tempval(0) = "1"
                tempcondition = " where melting_id = " & Val(txtlotno.Text)
                modify("meltingmaster", tempcol, tempval, tempcondition)



                '**************** MFG MASTER ********************
                'adding data to mfgmaster
                tempcol(0) = "mfg_no"
                tempcol(1) = "mfg_date"
                tempcol(2) = "mfg_lotno"
                tempcol(3) = "mfg_melting"
                tempcol(4) = "mfg_totalparts"
                tempcol(5) = "MFG_REMARKS"
                tempcol(6) = "MFG_BRIEF"
                tempcol(7) = "MFG_REFNO"
                tempcol(8) = "MFG_USERID"
                tempcol(9) = "MFG_DEPARTMENTID"

                tempval(0) = Val(txtmfgno.Text)
                tempval(1) = "'" & Format(mfgdate.Value, "dd/MM/yyyy") & "'"
                tempval(2) = Val(txtlotno.Text)
                tempval(3) = Val(txtmelting.Text)
                If splitno <= 0 Then splitno = 1
                tempval(4) = Val(splitno)
                tempval(5) = "'" & TXTREMARKS.Text.Trim & "'"
                tempval(6) = "'" & TXTBRIEF.Text.Trim & "'"
                tempval(7) = "'" & TXTREFNO.Text.Trim & "'"
                tempval(8) = Val(USERID)
                tempval(9) = Val(USERDEPARTMENTID)


                insert("mfgmaster", tempcol, tempval)


                '**************** SPLIT MASTER ********************
                'adding values in splitmaster from split table
                tempcmd = New OleDbCommand("INSERT INTO splitmaster SELECT * FROM(tempsplit) WHERE MFG_NO = " & Val(txtmfgno.Text.Trim), tempconn)
                If tempconn.State = ConnectionState.Open Then
                    tempconn.Close()
                End If
                tempconn.Open()
                tempcmd.ExecuteNonQuery()



                '**************** MFG DESCRIPTION ********************
                'adding data to manufacturingdescription
                tempcol(0) = "mfg_no"
                tempcol(1) = "mfg_part"
                tempcol(2) = "mfg_processname"
                tempcol(3) = "mfg_name"
                tempcol(4) = "mfg_inputwt"
                tempcol(5) = "mfg_outputwt"
                tempcol(6) = "mfg_sample"
                tempcol(7) = "mfg_wastage"
                tempcol(8) = "mfg_loss"
                tempcol(9) = "mfg_vaccum"
                tempcol(10) = "mfg_processdate"
                tempcol(11) = "mfg_excess"
                tempcol(12) = "mfg_percentinput"
                tempcol(13) = "mfg_percentoutput"
                tempcol(14) = "mfg_percentfinal"
                tempcol(15) = "mfg_lab"
                tempcol(16) = "mfg_lineno"
                tempcol(17) = "MFG_IRONWT"
                tempcol(18) = "MFG_IRONRETWT"


                For j = 0 To gridmfg.RowCount - 2
                    tempval(0) = Val(txtmfgno.Text)
                    tempval(1) = "'" & gridmfg.Item(0, j).Value.ToString & "'"
                    tempval(2) = "'" & gridmfg.Item(1, j).Value.ToString & "'"
                    tempval(3) = "'" & gridmfg.Item(2, j).Value.ToString & "'"
                    tempval(4) = Val(gridmfg.Item(3, j).Value.ToString)
                    tempval(5) = Val(gridmfg.Item(4, j).Value.ToString)
                    tempval(6) = Val(gridmfg.Item(5, j).Value.ToString)
                    tempval(7) = Val(gridmfg.Item(6, j).Value.ToString)
                    tempval(8) = Val(gridmfg.Item(7, j).Value.ToString)
                    tempval(9) = Val(gridmfg.Item(8, j).Value.ToString)

                    TEMPD = Convert.ToDateTime(gridmfg.Item(9, j).Value)

                    tempval(10) = "'" & Format(TEMPD, "dd/MM/yyyy") & "'"
                    tempval(11) = Val(gridmfg.Item(10, j).Value.ToString)
                    tempval(12) = Val(gridmfg.Item(11, j).Value.ToString)
                    tempval(13) = Val(gridmfg.Item(12, j).Value.ToString)
                    tempval(14) = Val(gridmfg.Item(13, j).Value.ToString)
                    tempval(15) = Val(gridmfg.Item(14, j).Value.ToString)
                    tempval(16) = j
                    tempval(17) = Val(gridmfg.Item(GIRONWT.Index, j).Value.ToString)
                    tempval(18) = Val(gridmfg.Item(GIRONRETWT.Index, j).Value.ToString)


                    'NO USE OF ADDING ENTRIES IN ACCOUNTSMASTER...IT CREATES PROBLEM IN STOCK\]
                    'If Val(gridmfg.Item(5, j).Value.ToString) <> 0 Then SAMPLEACCOUNTS(j)
                    'If Val(gridmfg.Item(6, j).Value.ToString) <> 0 Then WASTAGEACCOUNTS(j)
                    'If Val(gridmfg.Item(8, j).Value.ToString) <> 0 Then VACCUMACCOUNTS(j)



                    insert("mfgdescription", tempcol, tempval)
                Next


                '**************** ADDING IN KARIGARISSUE FROM TEMPKARIGARISSUE ********************
                cmd = New OleDbCommand("insert into karigarissue select * from tempkarigarissue WHERE MFG_NO = " & Val(txtmfgno.Text.Trim), conn)
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
                conn.Open()
                cmd.ExecuteNonQuery()

                'NEW CODE BY IRFAN
                ACCOUNTENTRY()



                'checking whether part has reached final tiem or not
                For i = 1 To 50
                    If partname(i) <> 0 Then

                        If MFGORDERNO(i) > 0 Then
                            'ADDING IN ORDERMASTER'
                            tempcmd = New OleDbCommand("update ORDERMASTER Set ORDER_DONE = 1 where ORDER_SRNO = " & Val(MFGORDERNO(i)), tempconn)
                            If tempconn.State = ConnectionState.Open Then
                                tempconn.Close()
                            End If
                            tempconn.Open()
                            tempcmd.ExecuteNonQuery()
                        End If



                        'ADDING IN NEW TABLE MFGBARCODE
                        If MFGBARCODE(i) <> "" Then
                            'ADDING IN MFGBARCODE
                            tempcmd = New OleDbCommand("INSERT INTO MFGBARCODE VALUES (" & Val(txtmfgno.Text.Trim) & ", " & Val(txtlotno.Text.Trim) & ", " & i & ",'MFG-" & Val(txtmfgno.Text.Trim) & "-" & i & "/" & CMPID & "',0)", tempconn)
                            If tempconn.State = ConnectionState.Open Then
                                tempconn.Close()
                            End If
                            tempconn.Open()
                            tempcmd.ExecuteNonQuery()
                        End If


                        If tempprocessno(mfgprocessno(i)) = 0 Then        'process compltede

                            'adding in itemstock coz it is completed
                            For j = 0 To 50
                                tempcol(j) = ""
                                tempval(j) = ""
                            Next

                            tempcol(0) = "item_id"
                            tempcol(1) = "item_purity"
                            tempcol(2) = "item_grosswt"
                            tempcol(3) = "item_nettwt"
                            tempcol(4) = "item_no"
                            tempcol(5) = "item_date"
                            tempcol(6) = "item_partno"
                            tempcol(7) = "item_ORDERNO"
                            tempcol(8) = "item_USERID"
                            tempcol(9) = "item_DEPARTMENTID"

                            'getting itemid
                            tempcmd = New OleDbCommand("select item_id from itemmaster where lcase(item_name) = '" & LCase(mfgitemname(i)) & "'", tempconn)
                            If tempconn.State = ConnectionState.Open Then
                                tempconn.Close()
                            End If
                            tempconn.Open()
                            tempdr = tempcmd.ExecuteReader
                            If tempdr.HasRows = True Then
                                tempdr.Read()
                                tempval(0) = Val(tempdr(0).ToString)
                            Else
                                tempval(0) = "0"
                            End If
                            tempval(1) = Val(percentinput(i))
                            tempval(2) = Val(partname(i))
                            tempval(3) = Val(Val(percentinput(i)) * Val(partname(i))) / 100
                            tempval(4) = Val(txtmfgno.Text)
                            tempval(5) = "'" & Format(processdate.Value, "dd/MM/yyyy") & "'"
                            tempval(6) = i
                            tempval(7) = Val(MFGORDERNO(i))
                            tempval(8) = Val(USERID)
                            tempval(9) = Val(USERDEPARTMENTID)

                            insert("itemstock", tempcol, tempval)


                            If MFGORDERNO(i) > 0 Then
                                'ADDING IN ORDERMASTER'
                                tempcmd = New OleDbCommand("update ORDERMASTER SET ORDER_DONE = 0, ORDER_MFGWT = " & Val(partname(i)) & " where ORDER_SRNO = " & Val(MFGORDERNO(i)), tempconn)
                                If tempconn.State = ConnectionState.Open Then
                                    tempconn.Close()
                                End If
                                tempconn.Open()
                                tempcmd.ExecuteNonQuery()
                            End If


                            'for direct adding in VOUCHERS BUT ONLY 1ST TIME
                            If MFGORDERNO(i) > 0 Then

                                'CHECKING WHETHER THIS PART IS ALREADY ISSUED OR NOT IF NOT ISSUED THEN ONLY ADD
                                tempcmd = New OleDbCommand("SELECT MFG_VOUCHERID AS ACCID from MFGDIRECTISSUE where MFG_NO = " & Val(txtmfgno.Text) & " AND MFG_PARTNO = " & i, tempconn)
                                If tempconn.State = ConnectionState.Open Then tempconn.Close()
                                tempconn.Open()
                                tempdr = tempcmd.ExecuteReader
                                If tempdr.HasRows = False Then

                                    Dim TEMPMSG As Integer = MsgBox("Wish to Issue Lot Directly?", MsgBoxStyle.YesNo)
                                    If TEMPMSG = vbYes Then
                                        DIRECTACCOUNTENTRY()

                                        'UPDATE ACCOUNT ID IN ITEMSTOCK FOR FURTHER REFERENCE
                                        'GET MAX ACCOUNTID
                                        Dim TEMPAID As Integer = 0
                                        tempcmd = New OleDbCommand("SELECT MAX(VOUCHER_ID) AS ACCID from VOUCHERS where VOUCHER_TYPE = 'I'", tempconn)
                                        If tempconn.State = ConnectionState.Open Then tempconn.Close()
                                        tempconn.Open()
                                        tempdr = tempcmd.ExecuteReader
                                        If tempdr.HasRows Then
                                            tempdr.Read()
                                            TEMPAID = tempdr("ACCID")
                                        End If
                                        tempconn.Close()

                                        tempcmd = New OleDbCommand("update ITEMSTOCK SET ITEM_ACCOUNTID = " & TEMPAID & " where ITEM_NO = " & Val(txtmfgno.Text) & " AND item_partno = " & i, tempconn)
                                        If tempconn.State = ConnectionState.Open Then
                                            tempconn.Close()
                                        End If
                                        tempconn.Open()
                                        tempcmd.ExecuteNonQuery()

                                    End If
                                End If

                            End If


                        ElseIf tempprocessno(mfgprocessno(i)) <> 0 Then   'process incompltede

                            'adding in mfgstock coz it is incomplete
                            For j = 0 To 50
                                tempcol(j) = ""
                                tempval(j) = ""
                            Next

                            tempcol(0) = "mfg_no"
                            tempcol(1) = "mfg_processname"
                            tempcol(2) = "mfg_inputwt"
                            tempcol(3) = "mfg_processdate"
                            tempcol(4) = "mfg_partno"
                            tempcol(5) = "mfg_percentinput"
                            tempcol(6) = "mfg_narration"
                            tempcol(7) = "mfg_lotfail"
                            tempcol(8) = "mfg_ORDERNO"
                            tempcol(9) = "MFG_MERGED"
                            tempcol(10) = "MFG_USERID"
                            tempcol(11) = "MFG_DEPARTMENTID"

                            tempval(0) = Val(txtmfgno.Text)
                            tempval(1) = "'" & tempprocess(mfgprocessno(i)) & "'"
                            tempval(2) = Val(partname(i))
                            tempval(3) = "'" & Format(processdate.Value, "dd/MM/yyyy") & "'"
                            tempval(4) = i

                            'CHANGED BY GULKIT
                            '****OG******
                            'tempval(5) = Val(percentinput(i))
                            '****OG******
                            If Val(LOTFAILPERCENT(i)) = 0 Then
                                tempval(5) = Val(percentinput(i))
                            Else
                                tempval(5) = Val(LOTFAILPERCENT(i))
                            End If


                            tempval(6) = "'" & tempnarration(i) & "'"
                            tempval(7) = lotfail(i)
                            tempval(8) = MFGORDERNO(i)
                            tempval(9) = LOTFAILMERGED(i)
                            tempval(10) = Val(USERID)
                            tempval(11) = Val(USERDEPARTMENTID)

                            insert("mfgstock", tempcol, tempval)


                            '**************** LOT FAIL MASTER *************
                            'adding in lotfailmaster if lotfail = true
                            If lotfail(i) = True Then
                                For j = 0 To 50
                                    tempcol(j) = ""
                                    tempval(j) = ""
                                Next

                                tempcol(0) = "mfg_no"
                                tempcol(1) = "mfg_processdate"
                                tempcol(2) = "mfg_processname"
                                tempcol(3) = "mfg_inputwt"
                                tempcol(4) = "mfg_percentinput"
                                tempcol(5) = "mfg_narration"
                                tempcol(6) = "mfg_itemid"
                                tempcol(7) = "mfg_purity"
                                tempcol(8) = "mfg_ORDERNO"
                                tempcol(9) = "mfg_MERGED"
                                tempcol(10) = "mfg_USERID"
                                tempcol(11) = "mfg_DEPARTMENTID"

                                tempval(0) = Val(txtmfgno.Text)
                                tempval(1) = "'" & Format(processdate.Value, "dd/MM/yyyy") & "'"
                                tempval(2) = "'" & tempprocess(mfgprocessno(i)) & "'"
                                tempval(3) = Val(partname(i))

                                'CHANGED BY GULKIT
                                '****OG******
                                'tempval(4) = Val(percentinput(i))
                                '****OG******
                                If Val(LOTFAILPERCENT(i)) = 0 Then
                                    tempval(4) = Val(percentinput(i))
                                Else
                                    tempval(4) = Val(LOTFAILPERCENT(i))
                                End If

                                tempval(5) = "'" & tempnarration(i) & "'"

                                'getting itemid as processname as itemname
                                tempcmd = New OleDbCommand("select item_id from itemmaster where item_name = '" & tempprocess(mfgprocessno(i)) & "'", tempconn)
                                If tempconn.State = ConnectionState.Open Then
                                    tempconn.Close()
                                End If
                                tempconn.Open()
                                tempdr = tempcmd.ExecuteReader
                                If tempdr.HasRows = True Then
                                    tempdr.Read()
                                    tempval(6) = Val(tempdr(0).ToString)
                                Else
                                    tempval(6) = "0"
                                End If

                                tempval(7) = Val(percentinput(i))
                                tempval(8) = MFGORDERNO(i)
                                tempval(9) = LOTFAILMERGED(i)
                                tempval(10) = Val(USERID)
                                tempval(11) = Val(USERDEPARTMENTID)

                                insert("lotfail", tempcol, tempval)

                            End If

                        End If
                    End If
                Next

                'IF SOMEONE NEEDS BARCODE THEN OPEN THE BELOW CODE
                'If edit = False Then PRINTBARCODE()
                If edit = False Then Call Manufacturing_Load(sender, e)

                'when EDIT IS TRUE AND USER WANT TO PRINT BARCODE THEN THEY WILL AMNUALLY CLICK ON THE ICON AND PRINT
                'THIS IS DONE COZ ALWAYS IT WILL PROMPT TO PRINT BARCODE, WHICH WILL BE ANNOYING


                clear()
                txtlotno.Focus()

            End If
        Catch ex As Exception

            'IF ERROR COMES THEN REVERSE ALL THE DELETED ENTRIES AND REMOVE HALF INSERTED ENTRIES, JUST UNMARK THE DELETE TICK
            tempcmd = New OleDbCommand("DELETE FROM mfgmaster where mfg_no = " & Val(txtmfgno.Text) & " AND MFG_DELETE = FALSE", tempconn)
            If tempconn.State = ConnectionState.Open Then
                tempconn.Close()
            End If
            tempconn.Open()
            tempcmd.ExecuteNonQuery()
            tempcmd = New OleDbCommand("update mfgmaster set MFG_DELETE = FALSE where mfg_no = " & Val(txtmfgno.Text), tempconn)
            If tempconn.State = ConnectionState.Open Then
                tempconn.Close()
            End If
            tempconn.Open()
            tempcmd.ExecuteNonQuery()



            'deleting data from mfgdescription
            tempcmd = New OleDbCommand("DELETE FROM mfgdescription where mfg_no = " & Val(txtmfgno.Text) & " AND MFG_DELETE = FALSE", tempconn)
            If tempconn.State = ConnectionState.Open Then
                tempconn.Close()
            End If
            tempconn.Open()
            tempcmd.ExecuteNonQuery()
            tempcmd = New OleDbCommand("UPDATE mfgdescription SET MFG_DELETE = FALSE where mfg_no = " & Val(txtmfgno.Text), tempconn)
            If tempconn.State = ConnectionState.Open Then
                tempconn.Close()
            End If
            tempconn.Open()
            tempcmd.ExecuteNonQuery()


            'deleting data from MFGBARCODE
            tempcmd = New OleDbCommand("DELETE FROM MFGBARCODE where mfg_no = " & Val(txtmfgno.Text) & " AND MFG_DELETE = FALSE ", tempconn)
            If tempconn.State = ConnectionState.Open Then
                tempconn.Close()
            End If
            tempconn.Open()
            tempcmd.ExecuteNonQuery()
            tempcmd = New OleDbCommand("UPDATE MFGBARCODE SET MFG_DELETE = FALSE where mfg_no = " & Val(txtmfgno.Text), tempconn)
            If tempconn.State = ConnectionState.Open Then
                tempconn.Close()
            End If
            tempconn.Open()
            tempcmd.ExecuteNonQuery()


            'deleting data from karigarissue
            tempcmd = New OleDbCommand("DELETE FROM karigarissue where mfg_no = " & Val(txtmfgno.Text) & " AND MFG_DELETE = FALSE ", tempconn)
            If tempconn.State = ConnectionState.Open Then
                tempconn.Close()
            End If
            tempconn.Open()
            tempcmd.ExecuteNonQuery()
            tempcmd = New OleDbCommand("UPDATE karigarissue SET MFG_DELETE = FALSE where mfg_no = " & Val(txtmfgno.Text), tempconn)
            If tempconn.State = ConnectionState.Open Then
                tempconn.Close()
            End If
            tempconn.Open()
            tempcmd.ExecuteNonQuery()


            'deleting data from mfgdstock
            tempcmd = New OleDbCommand("DELETE FROM mfgstock where mfg_no = " & Val(txtmfgno.Text) & " AND MFG_DELETE = FALSE ", tempconn)
            If tempconn.State = ConnectionState.Open Then
                tempconn.Close()
            End If
            tempconn.Open()
            tempcmd.ExecuteNonQuery()
            tempcmd = New OleDbCommand("UPDATE mfgstock SET MFG_DELETE = FALSE where mfg_no = " & Val(txtmfgno.Text), tempconn)
            If tempconn.State = ConnectionState.Open Then
                tempconn.Close()
            End If
            tempconn.Open()
            tempcmd.ExecuteNonQuery()


            'deleting data from lotfail
            tempcmd = New OleDbCommand("DELETE FROM lotfail where mfg_no = " & Val(txtmfgno.Text) & " AND MFG_DELETE = FALSE ", tempconn)
            If tempconn.State = ConnectionState.Open Then
                tempconn.Close()
            End If
            tempconn.Open()
            tempcmd.ExecuteNonQuery()
            tempcmd = New OleDbCommand("UPDATE lotfail SET MFG_DELETE = FALSE where mfg_no = " & Val(txtmfgno.Text), tempconn)
            If tempconn.State = ConnectionState.Open Then
                tempconn.Close()
            End If
            tempconn.Open()
            tempcmd.ExecuteNonQuery()


            'deleting data from splitmaster
            tempcmd = New OleDbCommand("DELETE FROM splitmaster where mfg_no = " & Val(txtmfgno.Text) & " AND MFG_DELETE = FALSE ", tempconn)
            If tempconn.State = ConnectionState.Open Then
                tempconn.Close()
            End If
            tempconn.Open()
            tempcmd.ExecuteNonQuery()
            tempcmd = New OleDbCommand("UPDATE splitmaster SET MFG_DELETE = FALSE where mfg_no = " & Val(txtmfgno.Text), tempconn)
            If tempconn.State = ConnectionState.Open Then
                tempconn.Close()
            End If
            tempconn.Open()
            tempcmd.ExecuteNonQuery()


            'deleting data from itemstock
            tempcmd = New OleDbCommand("DELETE FROM itemstock where item_no = " & Val(txtmfgno.Text) & " and item_partno <> 0 AND ITEM_DELETE = FALSE ", tempconn)
            If tempconn.State = ConnectionState.Open Then
                tempconn.Close()
            End If
            tempconn.Open()
            tempcmd.ExecuteNonQuery()
            tempcmd = New OleDbCommand("UPDATE itemstock SET ITEM_DELETE = FALSE where item_no = " & Val(txtmfgno.Text) & " and item_partno <> 0 ", tempconn)
            If tempconn.State = ConnectionState.Open Then
                tempconn.Close()
            End If
            tempconn.Open()
            tempcmd.ExecuteNonQuery()


            'deleting data from ACCOUNTMASTER (CODE ADDED TO ADD WASTAGE AND VACCUM IN ACCOUNTSMASTETR)
            tempcmd = New OleDbCommand("DELETE FROM ACCOUNTMASTER where ACCOUNT_VOUCHERID = " & Val(txtmfgno.Text) & " and ACCOUNT_TYPE = 'M' AND ACCOUNT_SUBTYPE ='MFG' AND ACCOUNT_DELETE = FALSE ", tempconn)
            If tempconn.State = ConnectionState.Open Then
                tempconn.Close()
            End If
            tempconn.Open()
            tempcmd.ExecuteNonQuery()
            tempcmd = New OleDbCommand("UPDATE ACCOUNTMASTER SET ACCOUNT_DELETE = FALSE where ACCOUNT_VOUCHERID = " & Val(txtmfgno.Text) & " and ACCOUNT_TYPE = 'M' AND ACCOUNT_SUBTYPE ='MFG'", tempconn)
            If tempconn.State = ConnectionState.Open Then
                tempconn.Close()
            End If
            tempconn.Open()
            tempcmd.ExecuteNonQuery()


            Throw ex

        Finally

            tempcmd = New OleDbCommand("DELETE FROM mfgmaster where mfg_no = " & Val(tempmfgno) & " AND MFG_DELETE = True", tempconn)
            If tempconn.State = ConnectionState.Open Then
                tempconn.Close()
            End If
            tempconn.Open()
            tempcmd.ExecuteNonQuery()

            'deleting data from mfgdescription
            tempcmd = New OleDbCommand("delete from mfgdescription where mfg_no = " & Val(tempmfgno) & " AND MFG_DELETE = True", tempconn)
            If tempconn.State = ConnectionState.Open Then
                tempconn.Close()
            End If
            tempconn.Open()
            tempcmd.ExecuteNonQuery()


            'deleting data from MFGBARCODE
            tempcmd = New OleDbCommand("delete from MFGBARCODE where mfg_no = " & Val(tempmfgno) & " AND MFG_DELETE = True", tempconn)
            If tempconn.State = ConnectionState.Open Then
                tempconn.Close()
            End If
            tempconn.Open()
            tempcmd.ExecuteNonQuery()


            'deleting data from karigarissue
            tempcmd = New OleDbCommand("delete from karigarissue where mfg_no = " & Val(tempmfgno) & " AND MFG_DELETE = True", tempconn)
            If tempconn.State = ConnectionState.Open Then
                tempconn.Close()
            End If
            tempconn.Open()
            tempcmd.ExecuteNonQuery()


            'deleting data from mfgdstock
            tempcmd = New OleDbCommand("delete from mfgstock where mfg_no = " & Val(tempmfgno) & " AND MFG_DELETE = True", tempconn)
            If tempconn.State = ConnectionState.Open Then
                tempconn.Close()
            End If
            tempconn.Open()
            tempcmd.ExecuteNonQuery()


            'deleting data from lotfail
            tempcmd = New OleDbCommand("delete from lotfail where mfg_no = " & Val(tempmfgno) & " AND MFG_DELETE = True", tempconn)
            If tempconn.State = ConnectionState.Open Then
                tempconn.Close()
            End If
            tempconn.Open()
            tempcmd.ExecuteNonQuery()


            'deleting data from splitmaster
            tempcmd = New OleDbCommand("delete from splitmaster where mfg_no = " & Val(tempmfgno) & " AND MFG_DELETE = True", tempconn)
            If tempconn.State = ConnectionState.Open Then
                tempconn.Close()
            End If
            tempconn.Open()
            tempcmd.ExecuteNonQuery()


            'deleting data from itemstock
            tempcmd = New OleDbCommand("delete from itemstock where item_no = " & Val(tempmfgno) & " and item_partno <> 0  AND ITEM_DELETE = True", tempconn)
            If tempconn.State = ConnectionState.Open Then
                tempconn.Close()
            End If
            tempconn.Open()
            tempcmd.ExecuteNonQuery()


            'deleting data from ACCOUNTMASTER (CODE ADDED TO ADD WASTAGE AND VACCUM IN ACCOUNTSMASTETR)
            tempcmd = New OleDbCommand("delete from ACCOUNTMASTER where ACCOUNT_VOUCHERID = " & Val(tempmfgno) & " and ACCOUNT_TYPE = 'M' AND ACCOUNT_SUBTYPE ='MFG' AND ACCOUNT_DELETE = True", tempconn)
            If tempconn.State = ConnectionState.Open Then
                tempconn.Close()
            End If
            tempconn.Open()
            tempcmd.ExecuteNonQuery()

        End Try

    End Sub

    Sub PRINTBARCODE()
        Try
            If MsgBox("Print Barcode?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

            If MsgBox("Print Barcodes For all Parts?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                For i As Integer = 1 To 50
                    If partname(i) <> 0 Then
                        Dim dirresults As String = ""

                        'OLD CODE FOR TSC
                        'Dim oWrite As System.IO.StreamWriter
                        'oWrite = File.CreateText("D:\Barcode.txt")
                        'oWrite.WriteLine("<xpml><page quantity='0' pitch='17.9 mm'></xpml>SIZE 104.2 mm, 17.9 mm")
                        'oWrite.WriteLine("DIRECTION 0,0")
                        'oWrite.WriteLine("REFERENCE 0,0")
                        'oWrite.WriteLine("OFFSET 0 mm")
                        'oWrite.WriteLine("SET PEEL OFF")
                        'oWrite.WriteLine("SET CUTTER OFF")
                        'oWrite.WriteLine("SET PARTIAL_CUTTER OFF")
                        'oWrite.WriteLine("<xpml></page></xpml><xpml><page quantity='1' pitch='17.9 mm'></xpml>SET TEAR ON")
                        'oWrite.WriteLine("CLS")
                        'oWrite.WriteLine("CODEPAGE 1252")
                        'oWrite.WriteLine("TEXT 352,26,""0"",180,8,8,""" & tempnarration(i) & """")
                        'oWrite.WriteLine("BARCODE 423,104,""128M"",50,0,180,2,4,""!104MFG-9!09" & Val(txtmfgno.Text.Trim) & "!100-" & i & "/" & CMPID & """")
                        'oWrite.WriteLine("TEXT 298,46,""1"",180,1,1,""MFG-" & Val(txtmfgno.Text.Trim) & "-" & i & "/" & CMPID & """")
                        'oWrite.WriteLine("PRINT 1,1")
                        'oWrite.WriteLine("<xpml></page></xpml><xpml><end/></xpml>")
                        'oWrite.Dispose()


                        'CODE FOR GODEX
                        Dim oWrite As System.IO.StreamWriter
                        oWrite = File.CreateText("D:\Barcode.txt")
                        oWrite.WriteLine("^Q17,3")
                        oWrite.WriteLine("^W106")
                        oWrite.WriteLine("^H8")
                        oWrite.WriteLine("^P1")
                        oWrite.WriteLine("^S3")
                        oWrite.WriteLine("^AD")
                        oWrite.WriteLine("^C1")
                        oWrite.WriteLine("^R10")
                        oWrite.WriteLine("~Q+0")
                        oWrite.WriteLine("^O0")
                        oWrite.WriteLine("^D0")
                        oWrite.WriteLine("^E12")
                        oWrite.WriteLine("~R200")
                        oWrite.WriteLine("^XSET,ROTATION,0")
                        oWrite.WriteLine("^L")
                        oWrite.WriteLine("Dy2-me-dd")
                        oWrite.WriteLine("Th:m:s")
                        oWrite.WriteLine("BQ,405,55,2,2,53,0,0,MFG-" & Val(txtmfgno.Text.Trim) & "-" & i & "/" & CMPID & "")
                        oWrite.WriteLine("AB,405,32,1,1,0,0," & tempnarration(i) & "")
                        oWrite.WriteLine("AB,405,108,1,1,0,0,MFG-" & Val(txtmfgno.Text.Trim) & "-" & i & "/" & CMPID & "")
                        oWrite.WriteLine("E")
                        oWrite.Dispose()

                        'Printing Barcode
                        Dim psi As New ProcessStartInfo()
                        psi.FileName = "cmd.exe"
                        psi.RedirectStandardInput = False
                        psi.RedirectStandardOutput = True
                        'psi.Arguments = "/c print " & Application.StartupPath & "\Barcode.txt"    ' specify your command
                        psi.Arguments = "/c print D:\Barcode.txt"    ' specify your command
                        'psi.Arguments = "print /d:\\admin-pc\ARGOX D:\Barcode.txt"    ' specify your command
                        psi.UseShellExecute = False

                        Dim proc As Process
                        proc = Process.Start(psi)
                        dirresults = proc.StandardOutput.ReadToEnd() ' // read from stdout
                        '// do something with result stream
                        proc.WaitForExit()
                        proc.Dispose()
                    End If
                Next
            Else

                find = InStr(cmbpart.Text.Trim, "(")
                findend = InStr(cmbpart.Text.Trim, ")")
                txtpart.Text = cmbpart.Text.Trim
                txtpart.SelectionStart = find
                txtpart.SelectionLength = findend - find - 1
                txtinput.Text = Format(partname(txtpart.SelectedText), "0.000")
                i = txtpart.SelectedText
                If partname(i) <> 0 Then
                    Dim dirresults As String = ""

                    'OLD CODE FOR TSC
                    'Dim oWrite As System.IO.StreamWriter
                    'oWrite = File.CreateText("D:\Barcode.txt")
                    'oWrite.WriteLine("<xpml><page quantity='0' pitch='17.9 mm'></xpml>SIZE 104.2 mm, 17.9 mm")
                    'oWrite.WriteLine("DIRECTION 0,0")
                    'oWrite.WriteLine("REFERENCE 0,0")
                    'oWrite.WriteLine("OFFSET 0 mm")
                    'oWrite.WriteLine("SET PEEL OFF")
                    'oWrite.WriteLine("SET CUTTER OFF")
                    'oWrite.WriteLine("SET PARTIAL_CUTTER OFF")
                    'oWrite.WriteLine("<xpml></page></xpml><xpml><page quantity='1' pitch='17.9 mm'></xpml>SET TEAR ON")
                    'oWrite.WriteLine("CLS")
                    'oWrite.WriteLine("CODEPAGE 1252")
                    'oWrite.WriteLine("TEXT 352,26,""0"",180,8,8,""" & tempnarration(i) & """")
                    'oWrite.WriteLine("BARCODE 423,104,""128M"",50,0,180,2,4,""!104MFG-9!09" & Val(txtmfgno.Text.Trim) & "!100-" & i & "/" & CMPID & """")
                    'oWrite.WriteLine("TEXT 298,46,""1"",180,1,1,""MFG-" & Val(txtmfgno.Text.Trim) & "-" & i & "/" & CMPID & """")
                    'oWrite.WriteLine("PRINT 1,1")
                    'oWrite.WriteLine("<xpml></page></xpml><xpml><end/></xpml>")
                    'oWrite.Dispose()


                    'CODE FOR GODEX
                    Dim oWrite As System.IO.StreamWriter
                    oWrite = File.CreateText("D:\Barcode.txt")
                    oWrite.WriteLine("^Q17,3")
                    oWrite.WriteLine("^W106")
                    oWrite.WriteLine("^H8")
                    oWrite.WriteLine("^P1")
                    oWrite.WriteLine("^S3")
                    oWrite.WriteLine("^AD")
                    oWrite.WriteLine("^C1")
                    oWrite.WriteLine("^R10")
                    oWrite.WriteLine("~Q+0")
                    oWrite.WriteLine("^O0")
                    oWrite.WriteLine("^D0")
                    oWrite.WriteLine("^E12")
                    oWrite.WriteLine("~R200")
                    oWrite.WriteLine("^XSET,ROTATION,0")
                    oWrite.WriteLine("^L")
                    oWrite.WriteLine("Dy2-me-dd")
                    oWrite.WriteLine("Th:m:s")
                    oWrite.WriteLine("BQ,405,55,2,2,53,0,0,MFG-" & Val(txtmfgno.Text.Trim) & "-" & i & "/" & CMPID & "")
                    oWrite.WriteLine("AB,405,32,1,1,0,0," & tempnarration(i) & "")
                    oWrite.WriteLine("AB,405,108,1,1,0,0,MFG-" & Val(txtmfgno.Text.Trim) & "-" & i & "/" & CMPID & "")
                    oWrite.WriteLine("E")
                    oWrite.Dispose()

                    'Printing Barcode
                    Dim psi As New ProcessStartInfo()
                    psi.FileName = "cmd.exe"
                    psi.RedirectStandardInput = False
                    psi.RedirectStandardOutput = True
                    'psi.Arguments = "/c print " & Application.StartupPath & "\Barcode.txt"    ' specify your command
                    psi.Arguments = "/c print D:\Barcode.txt"    ' specify your command
                    'psi.Arguments = "print /d:\\admin-pc\ARGOX D:\Barcode.txt"    ' specify your command
                    psi.UseShellExecute = False

                    Dim proc As Process
                    proc = Process.Start(psi)
                    dirresults = proc.StandardOutput.ReadToEnd() ' // read from stdout
                    '// do something with result stream
                    proc.WaitForExit()
                    proc.Dispose()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Manufcaturing_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If AscW(e.KeyChar) <> 33 Then chkchange.CheckState = CheckState.Checked
    End Sub

    Private Sub Manufcaturing_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If ClientName = "MIMARAGEMS" Then Me.Close()

        If ClientName = "CNJ" Or ClientName = "CNC" Or ClientName = "BHARAT" Or ClientName = "CHAINSKART" Then
            LBLIRON.Visible = True
            TXTIRON.Visible = True
            TXTIRON.ReadOnly = False
            LBLIRONRETWT.Visible = True
            TXTIRONRETWT.Visible = True
            TXTIRONRETWT.ReadOnly = False
        End If

        If ClientName = "ADITYA" Then lblwastage.Text = "Scrap"
    End Sub

    Sub AMOUNTNUMDOTKYEPRESS(ByVal han As KeyPressEventArgs, ByVal sen As Control, ByVal frm As System.Windows.Forms.Form)
        Try
            Dim mypos As Integer

            If AscW(han.KeyChar) >= 48 And AscW(han.KeyChar) <= 57 Or AscW(han.KeyChar) = 8 Or AscW(han.KeyChar) = 45 Then
                han.KeyChar = han.KeyChar
            ElseIf AscW(han.KeyChar) = 46 Or AscW(han.KeyChar) = 45 Then
                mypos = InStr(1, sen.Text, ".")
                If mypos = 0 Then
                    han.KeyChar = han.KeyChar
                Else
                    han.KeyChar = ""
                End If
            Else
                han.KeyChar = ""
            End If

            If AscW(han.KeyChar) = Keys.Escape Then
                frm.Close()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub toolprevious_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles toolprevious.Click
        'ASK TO SAVE
        If Val(txtlotno.Text) <> 0 And gridmfg.RowCount > 1 And Val(txtmelting.Text) <> 0 And chkchange.CheckState = CheckState.Checked Then
            tempmsg = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
            If tempmsg = vbYes Then cmdsave_Click(sender, e)
            chkchange.CheckState = CheckState.Unchecked
        End If
        tempmfgno = txtmfgno.Text - 1
        If tempmfgno > 0 Then
            cmdedit.Enabled = False
            edit = True
            gridmfg.CurrentCell = gridmfg.Rows(0).Cells(0)
            Manufacturing_Load(sender, e)
        Else
            clear()
            cmdedit.Enabled = True
            edit = False
        End If
    End Sub

    Private Sub toolnext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles toolnext.Click

        'ASK TO SAVE
        If Val(txtlotno.Text) <> 0 And gridmfg.RowCount > 1 And Val(txtmelting.Text) <> 0 And chkchange.CheckState = CheckState.Checked Then
            tempmsg = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
            If tempmsg = vbYes Then cmdsave_Click(sender, e)
            chkchange.CheckState = CheckState.Unchecked
        End If

        tempmfgno = txtmfgno.Text + 1

        dr.Close()
        cmd = New OleDbCommand("select max(mfg_no) from mfgmaster", conn)
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If
        conn.Open()
        dr = cmd.ExecuteReader
        If dr.HasRows = True Then
            dr.Read()
            If tempmfgno <= Val(dr(0)) Then
                cmdedit.Enabled = False
                edit = True
                gridmfg.CurrentCell = gridmfg.Rows(0).Cells(0)
                Manufacturing_Load(sender, e)
            Else
                clear()
                cmdedit.Enabled = True
                edit = False
            End If
        End If

    End Sub

    Private Sub OpenToolStripButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles OpenToolStripButton.Click

        If USEREDIT = False Then
            MsgBox("Insufficient Rights")
            Exit Sub
        End If


        'ASK TO SAVE
        If Val(txtlotno.Text) <> 0 And gridmfg.RowCount > 1 And Val(txtmelting.Text) <> 0 And chkchange.CheckState = CheckState.Checked Then
            tempmsg = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
            If tempmsg = vbYes Then cmdsave_Click(sender, e)
        End If

        'MANUFCATUIRIUg details
        Me.Close()
        If (chldmfgdetails.IsMdiChild = False) Then
            If chldmfgdetails.IsDisposed = True Then
                chldmfgdetails = New Manufacturingdetails
            End If
            chldmfgdetails.MdiParent = MDIMain
            chldmfgdetails.Show()
        Else
            chldmfgdetails.BringToFront()
        End If

    End Sub

    Private Sub SaveToolStripButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SaveToolStripButton.Click
        Call cmdsave_Click(sender, e)
    End Sub

    Private Sub gridkarigar_CellValidated(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridkarigar.CellValidated

        tempcondition = ""
        If e.ColumnIndex = 0 Then fillgridcmb("itemmaster", "item_code", cmbitemname, tempcondition)
        If e.ColumnIndex = 4 Then fillgridcmb("ledgermaster", "ledger_code", cmbcode, tempcondition)

        If e.ColumnIndex = 1 And Val(gridkarigar.Item(1, e.RowIndex).Value) <> 0 Then
            'getting stock if gross is 0
            If Val(gridkarigar.Item(2, e.RowIndex).Value) = 0 And gridkarigar.Item(0, e.RowIndex).Value <> Nothing Then
                cmd = New OleDbCommand("select sum(item_grosswt) from stocks where item_code = '" & gridkarigar.Item(0, e.RowIndex).Value.ToString & "' and item_purity = " & gridkarigar.Item(1, e.RowIndex).Value, conn)
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
                conn.Open()
                dr = cmd.ExecuteReader
                If dr.HasRows = True Then
                    dr.Read()
                    gridkarigar.Item(2, e.RowIndex).Value = Val(dr(0).ToString)
                End If
            End If
        ElseIf e.ColumnIndex = GGM.Index Or e.ColumnIndex = cmbcode.Index Then

            'GET LABOUR FROM LABOURDETAILS
            cmd = New OleDbCommand("  SELECT LABOURDETAILS.LABOUR FROM LABOURDETAILS inner join ledgermaster on LABOURDETAILS.LEDGERID = ledgermaster.LEDGER_ID where ledgermaster.ledger_CODE = '" & gridkarigar.Item(cmbcode.Index, e.RowIndex).Value & "' and  LABOURDETAILS.GM = '" & gridkarigar.Item(GGM.Index, e.RowIndex).Value & "'", conn)
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
            conn.Open()
            dr = cmd.ExecuteReader
            If dr.HasRows = True Then
                dr.Read()
                gridkarigar.Item(GLABOUR.Index, e.RowIndex).Value = dr("LABOUR")
            End If

        End If

        If e.ColumnIndex = 1 Or e.ColumnIndex = 2 Then
            gridkarigar.Item(3, e.RowIndex).Value = Val(gridkarigar.Item(1, e.RowIndex).Value) * Val(gridkarigar.Item(2, e.RowIndex).Value) / 100
            gridkarigar.CurrentCell.Value = Convert.ToDecimal(gridkarigar.CurrentCell.Value)
            calculations()
        End If


        If gridkarigar.Item(cmbcode.Index, e.RowIndex).Value <> "" Then
            Dim NEWDT As New DataTable
            Dim WHERE As String = ""
            'gettig DEFAULT LABOUR
            If (e.ColumnIndex = cmbcode.Index Or e.ColumnIndex = cmbitemname.Index) And gridkarigar.Item(cmbcode.Index, e.RowIndex).EditedFormattedValue <> "" Then
                If gridkarigar.Item(cmbitemname.Index, e.RowIndex).EditedFormattedValue <> "" Then WHERE = " AND ITEM_CODE = '" & gridkarigar.Item(cmbitemname.Index, e.RowIndex).EditedFormattedValue & "'"
                tempcmd = New OleDbCommand("SELECT CustomerWastage.wastage AS WASTAGE, CustomerWastage.labour AS LABOUR FROM (CustomerWastage INNER JOIN ItemMaster ON CustomerWastage.itemid = ItemMaster.item_id) INNER JOIN ledgermaster ON CustomerWastage.ledgerid = ledgermaster.ledger_id WHERE LEDGER_CODE = '" & gridkarigar.Item(cmbcode.Index, e.RowIndex).EditedFormattedValue & "' " & WHERE, tempconn)
                da = New OleDbDataAdapter(tempcmd)
                da.Fill(NEWDT)
                If NEWDT.Rows.Count > 0 Then
                    gridkarigar.Item(GLABOUR.Index, e.RowIndex).Value = Format(Val(NEWDT.Rows(0).Item("LABOUR")), "0.00")
                End If
            End If
        End If


        'If e.ColumnIndex = 1 Or e.ColumnIndex = 2 Or e.ColumnIndex = 3 Or e.ColumnIndex = 4 Or e.ColumnIndex = 5 Then
        '    If gridkarigar.Item(0, e.RowIndex).Value = Nothing Then
        '        gridkarigar.Item(0, gridkarigar.CurrentRow.Index).Value = Nothing
        '        gridkarigar.Item(1, gridkarigar.CurrentRow.Index).Value = Nothing
        '        gridkarigar.Item(2, gridkarigar.CurrentRow.Index).Value = Nothing
        '        gridkarigar.Item(3, gridkarigar.CurrentRow.Index).Value = Nothing
        '        gridkarigar.Item(4, gridkarigar.CurrentRow.Index).Value = Nothing
        '        gridkarigar.Item(5, gridkarigar.CurrentRow.Index).Value = Nothing
        '    End If
        'End If

    End Sub

    Private Sub gridkarigar_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles gridkarigar.CellValidating

        If (TypeOf CType(sender, DataGridView).EditingControl Is DataGridViewComboBoxEditingControl) Then
            Dim cmb As DataGridViewComboBoxEditingControl = CType(CType(sender, DataGridView).EditingControl, DataGridViewComboBoxEditingControl)
            If Not cmb Is Nothing Then
                Dim grid As DataGridView = cmb.EditingControlDataGridView
                Dim value As Object = uppercase(cmb.Text)
                If cmb.Text.Trim <> "" Then

                    If e.ColumnIndex = 0 Then

                        cmd = New OleDbCommand("select item_id from itemmaster where item_code = '" & cmb.Text.Trim & "'", conn)
                        If conn.State = ConnectionState.Open Then
                            conn.Close()
                        End If
                        conn.Open()
                        dr = cmd.ExecuteReader
                        If dr.HasRows = False Then

                            'ask to save new entry
                            tempmsg = MsgBox("Item Not Present, Add New?", MsgBoxStyle.YesNo)
                            If tempmsg = vbYes Then

                                If (chlditemmaster.IsMdiChild = False) Then
                                    If chlditemmaster.IsDisposed = True Then
                                        chlditemmaster = New Itemmaster
                                    End If
                                    chlditemmaster.cmdedit.Enabled = True
                                    edit = False
                                    e.Cancel = True
                                    chlditemmaster.cmdaddnew.Enabled = False
                                    chlditemmaster.GPITEM.Enabled = True
                                    chlditemmaster.txttype.Visible = False
                                    chlditemmaster.txtcategory.Visible = False
                                    chlditemmaster.Show(Me)
                                    chlditemmaster.cmbcode.Text = cmb.Text
                                    chlditemmaster.cmbitemname.Text = cmb.Text
                                    chlditemmaster.ActiveControl = (chlditemmaster.cmbcode)
                                    chlditemmaster.cmbitemname.Focus()
                                Else
                                    chlditemmaster.BringToFront()
                                End If
                            Else
                                cmb.Text = cmb.Text
                                cmb.Focus()
                                e.Cancel = True
                            End If

                        Else
                            If cmb.Items.IndexOf(value) = -1 Then
                                cmb.Items.Add(value)
                                Dim cmbCol As DataGridViewComboBoxColumn = CType(grid.Columns(grid.CurrentCell.ColumnIndex), DataGridViewComboBoxColumn)
                                If Not cmbCol Is Nothing Then
                                    cmbCol.Items.Add(value)
                                End If
                            End If
                            grid.CurrentCell.Value = value
                            Dim objstockform As New Stockform
                            objstockform.ht = gridkarigar.Top + groupkarigar.Top + (gridkarigar.CurrentRow.Height * e.RowIndex)
                            objstockform.wd = gridkarigar.Left + groupkarigar.Left + 10
                            objstockform.item = gridkarigar.CurrentRow.Cells(0).Value.ToString
                            objstockform.ShowDialog()
                        End If


                    ElseIf e.ColumnIndex = 4 Then   'for name

                        cmd = New OleDbCommand("SELECT ledgermaster.ledger_code from ledgermaster inner join groupmaster on groupmaster.group_id = ledgermaster.ledger_groupid where ledgermaster.ledger_code = '" & cmb.Text.Trim & "' and ( groupmaster.group_name = 'Sundry Creditors' or groupmaster.group_name = 'Sundry Debtors'  )", conn)
                        If conn.State = ConnectionState.Open Then
                            conn.Close()
                        End If
                        conn.Open()
                        dr = cmd.ExecuteReader
                        If dr.HasRows = False Then

                            'ask to save new entry
                            tempmsg = MsgBox("Ledger Not Present, Add New?", MsgBoxStyle.YesNo)
                            If tempmsg = vbYes Then

                                If (chldvendormaster.IsMdiChild = False) Then
                                    If chldvendormaster.IsDisposed = True Then
                                        chldvendormaster = New ACCOUNTMASTER
                                    End If
                                    chldvendormaster.txtname.Text = cmb.Text
                                    chldvendormaster.cmdedit.Enabled = True
                                    edit = False
                                    e.Cancel = True
                                    chldvendormaster.Show(Me)
                                    chldvendormaster.ActiveControl = (chldvendormaster.txtname)
                                    chldvendormaster.txtname.Focus()
                                Else
                                    chldvendormaster.BringToFront()
                                End If

                            Else
                                cmb.Text = cmb.Text
                                cmb.Focus()
                                e.Cancel = True
                            End If

                        Else
                            If cmb.Items.IndexOf(value) = -1 Then
                                cmb.Items.Add(value)
                                Dim cmbCol As DataGridViewComboBoxColumn = CType(grid.Columns(grid.CurrentCell.ColumnIndex), DataGridViewComboBoxColumn)
                                If Not cmbCol Is Nothing Then
                                    cmbCol.Items.Add(value)
                                End If
                            End If
                            grid.CurrentCell.Value = value


                        End If

                    End If

                End If

            End If
        End If


        If e.ColumnIndex <> 0 Then
            Dim strName As String = gridkarigar.Columns(e.ColumnIndex).Name
            If String.IsNullOrEmpty(e.FormattedValue.ToString) Then Return
            Select Case strName
                'Case "Date"
                '    Dim dt As Date
                '    If Not DateTime.TryParse(e.FormattedValue.ToString, dt) Then
                '        MessageBox.Show("Invalid Date")
                '        e.Cancel = True
                '    End If
                Case "karigarpurity"
                    Dim dDebit As Decimal
                    Dim bValid As Boolean = Decimal.TryParse(e.FormattedValue.ToString, dDebit)
                    'Dim strCredit As String
                    'strCredit = gridkarigar.Item("meltinggrosswt", e.RowIndex).FormattedValue.ToString
                    'If String.IsNullOrEmpty(e.FormattedValue.ToString) Then Return
                    'If bValid And strCredit.Length < 1 Then
                    If bValid Then
                        gridkarigar.CurrentCell.Value = Convert.ToDecimal(gridkarigar.Item(1, e.RowIndex).Value)
                        ' everything is good
                    Else
                        MessageBox.Show("Invalid number")
                        e.Cancel = True
                    End If

                Case "karigargrosswt"
                    Dim dDebit As Decimal
                    Dim bValid As Boolean = Decimal.TryParse(e.FormattedValue.ToString, dDebit)
                    'Dim strCredit As String
                    'strCredit = gridkarigar.Item("meltingpurity", e.RowIndex).FormattedValue.ToString
                    'If String.IsNullOrEmpty(e.FormattedValue.ToString) Then Return
                    'If bValid And strCredit.Length < 1 Then
                    If bValid Then
                        ' everything is good
                    Else
                        MessageBox.Show("Invalid number")
                        e.Cancel = True
                    End If

                Case "karigarlab"
                    Dim dDebit As Decimal
                    Dim bValid As Boolean = Decimal.TryParse(e.FormattedValue.ToString, dDebit)
                    'Dim strCredit As String
                    'strCredit = gridkarigar.Item("meltingpurity", e.RowIndex).FormattedValue.ToString
                    'If String.IsNullOrEmpty(e.FormattedValue.ToString) Then Return
                    'If bValid And strCredit.Length < 1 Then
                    If bValid Then
                        ' everything is good
                    Else
                        MessageBox.Show("Invalid number")
                        e.Cancel = True
                    End If
            End Select
        End If


    End Sub

    Private Sub gridkarigar_CurrentCellDirtyStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridkarigar.CurrentCellDirtyStateChanged
        If gridkarigar.IsCurrentCellDirty Then
            gridkarigar.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Sub gridkarigar_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles gridkarigar.EditingControlShowing
        If (TypeOf e.Control Is DataGridViewComboBoxEditingControl) Then
            Dim cmb As DataGridViewComboBoxEditingControl = CType(e.Control, DataGridViewComboBoxEditingControl)
            If Not cmb Is Nothing Then
                cmb.DropDownStyle = ComboBoxStyle.DropDown
            End If
        End If
        m_EditingRow = gridkarigar.CurrentRow.Index
    End Sub

    Private Sub gridkarigar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridkarigar.KeyDown
        If e.KeyCode = Keys.Delete Then
            If gridkarigar.Rows(gridkarigar.CurrentRow.Index).IsNewRow <> True Then gridkarigar.Rows.RemoveAt(gridkarigar.CurrentRow.Index)
            ' total()
        End If

        If e.KeyCode = Keys.Return Then

            Dim cur_cell As DataGridViewCell = gridkarigar.CurrentCell
            Dim col As Integer = cur_cell.ColumnIndex

            If col = gridkarigar.Columns.Count - 1 And gridkarigar.CurrentRow.Index < gridkarigar.RowCount - 1 Then
                cur_cell = gridkarigar.Rows(gridkarigar.CurrentRow.Index + 1).Cells(0)
            Else
                col = (col + 1) Mod gridkarigar.Columns.Count
                cur_cell = gridkarigar.CurrentRow.Cells(col)
            End If

            gridkarigar.CurrentCell = cur_cell

            e.Handled = True
        End If
    End Sub

    Private Sub gridkarigar_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridkarigar.SelectionChanged
        If m_EditingRow >= 0 Then
            Dim new_row As Integer = m_EditingRow
            m_EditingRow = -1
            gridkarigar.CurrentCell = gridkarigar.Rows(new_row).Cells(gridkarigar.CurrentCell.ColumnIndex)
        End If
    End Sub

    Private Sub cmbpart_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbpart.Validated

        txtpart.Text = cmbpart.Text.Trim

        'clearing txtboxes
        TXTORDERNO.Clear()
        TXTNAME.Clear()
        TXTITEMNAME.Clear()
        TXTIRON.Clear()
        TXTIRONRETWT.Clear()
        txtoutput.Clear()
        txtsample.Clear()
        txtwastage.Clear()
        txtloss.Clear()
        txtvaccum.Clear()
        txtexcess.Clear()
        txtpurity.Clear()
        txtpercentout.Clear()
        txtpercentfinal.Clear()
        processdate.Value = GLOBALDATE
        gridkarigar.RowCount = 1

        If cmbpart.Text.Trim <> "" Then
            find = InStr(cmbpart.Text.Trim, "(")
            findend = InStr(cmbpart.Text.Trim, ")")
            txtpart.Text = cmbpart.Text.Trim
            txtpart.SelectionStart = find
            txtpart.SelectionLength = findend - find - 1
            txtinput.Text = Format(partname(txtpart.SelectedText), "0.000")


            'filling karigar grid from tempkarigarissue
            cmd = New OleDbCommand("SELECT ItemMaster.item_code, tempkarigarissue.mfg_purity, tempkarigarissue.mfg_grosswt, tempkarigarissue.mfg_nettwt, ledgermaster.ledger_code, tempkarigarissue.mfg_labour, IIF(ISNULL(tempkarigarissue.mfg_GM) = TRUE, '',tempkarigarissue.mfg_GM) AS GM FROM (tempkarigarissue LEFT JOIN ItemMaster ON tempkarigarissue.mfg_itemid = ItemMaster.item_id) LEFT JOIN ledgermaster ON tempkarigarissue.mfg_ledgerid = ledgermaster.ledger_id where tempkarigarissue.mfg_part = '" & txtpart.SelectedText & "' AND TEMPKARIGARISSUE.MFG_NO =" & Val(txtmfgno.Text.Trim), conn)
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
            conn.Open()
            dr = cmd.ExecuteReader
            If dr.HasRows = True Then
                gridkarigar.CurrentCell = gridkarigar.Rows(0).Cells(1)
                While (dr.Read())
                    gridkarigar.Rows.Add(uppercase(dr(0).ToString), Val(dr(1).ToString), Val(dr(2).ToString), Val(dr(3).ToString), uppercase(dr(4).ToString), Val(dr(5).ToString), dr("GM"))
                End While
            Else
                gridkarigar.RowCount = 1
            End If


            'GETTING ORDERNO AND NAME
            TXTORDERNO.Text = MFGORDERNO(txtpart.SelectedText)
            If Val(TXTORDERNO.Text.Trim) > 0 Then
                cmd = New OleDbCommand("SELECT ledgermaster.ledger_code AS NAME, ITEMMASTER.ITEM_CODE AS ITEMNAME FROM (OrderMaster INNER JOIN ledgermaster ON OrderMaster.ORDER_LEDGERID = ledgermaster.ledger_id) INNER JOIN ITEMMASTER ON OrderMaster.ORDER_ITEMID = ITEMMASTER.ITEM_id where ORDERMASTER.ORDER_SRNO = " & Val(TXTORDERNO.Text.Trim), conn)
                If conn.State = ConnectionState.Open Then conn.Close()
                conn.Open()
                dr = cmd.ExecuteReader
                If dr.HasRows = True Then
                    dr.Read()
                    TXTNAME.Text = dr("NAME")
                    TXTITEMNAME.Text = dr("ITEMNAME")
                End If
            End If



            'getting its narration & percentinput
            txtnarration.Text = tempnarration(txtpart.SelectedText)
            txtpercentin.Text = percentinput(txtpart.SelectedText)

            'getting processno
            selectprocess(mfgprocessno(txtpart.SelectedText))



            'chekcing whether fail or not
            If lotfail(txtpart.SelectedText) = True Then
                lblfailed.Visible = True
                If LOTFAILMERGED(txtpart.SelectedText) = True Then
                    lblfailed.Text = "MERGED"
                    CHKMERGE.CheckState = CheckState.Checked
                Else
                    lblfailed.Text = "FAILED"
                    CHKMERGE.CheckState = CheckState.Unchecked
                End If
            Else
                lblfailed.Visible = False
                CHKMERGE.CheckState = CheckState.Unchecked
            End If
        End If

    End Sub

    Sub fillcmbpart()

        cmbpart.Items.Clear()

        For i = 1 To 50
            If partname(i) <> "0" Then
                cmbpart.Items.Add("Part(" & i & ")")
            End If
        Next
        cmbpart.SelectedIndex = 0
        txtpart.Text = cmbpart.Text.Trim


        'If cmdedit.Enabled = False Then

        'Else
        '    For i = 1 To 50
        '        If partname(i) <> "0" Then
        '            cmbpart.Items.Add("Part(" & i & ")")
        '        End If
        '    Next
        '    cmbpart.SelectedIndex = 0
        '    txtpart.Text = cmbpart.Text.Trim
        'End If


    End Sub

    Sub calculations()

        'IF LOT COMPLETED THEN EXIT SUB
        If txtpart.SelectedText = "" Then
            find = InStr(cmbpart.Text.Trim, "(")
            findend = InStr(cmbpart.Text.Trim, ")")
            txtpart.Text = cmbpart.Text.Trim
            txtpart.SelectionStart = find
            txtpart.SelectionLength = findend - find - 1
        End If

        If tempprocessno(mfgprocessno(txtpart.SelectedText)) = 0 Then Exit Sub

        'getting loss
        If txtloss.Visible = True Then
            txtloss.Text = Format(Val(txtinput.Text) - (Val(txtoutput.Text) + Val(txtsample.Text) + Val(txtwastage.Text)), "0.000")
        Else
            txtloss.Text = 0.0
        End If

        'getting vaccum
        If txtvaccum.Visible = True Then
            txtvaccum.Text = Format(Val(txtinput.Text) - (Val(txtoutput.Text) + Val(txtsample.Text) + Val(txtwastage.Text)), "0.000")
        Else
            txtvaccum.Text = 0.0
        End If

        'getting excess
        If txtexcess.Visible = True Then
            txtexcess.Text = Format((Val(txtoutput.Text) + Val(txtsample.Text) + Val(txtwastage.Text)) - Val(txtinput.Text), "0.000")
        Else
            txtexcess.Text = 0.0
        End If


        'getting %In as melting else getting from last process from grid
        If gridmfg.RowCount = 1 Then
            txtpercentin.Text = Format(Val(txtmelting.Text), "0.00")
        Else

        End If

        'getting %Out  and %final
        'if karigargrid is = 0
        If Val(txtoutput.Text) <> 0 Then

            find = InStr(cmbpart.Text.Trim, "(")
            findend = InStr(cmbpart.Text.Trim, ")")
            txtpart.Text = cmbpart.Text.Trim
            txtpart.SelectionStart = find
            txtpart.SelectionLength = findend - find - 1

            If tempprocesskarigar(mfgprocessno(txtpart.SelectedText)) = False And tempprocessexcess(mfgprocessno(txtpart.SelectedText)) = False Then    'if excess is false for all other processes
                txtexcess.Text = 0
                txtpercentout.Text = (((Val(txtinput.Text) * Val(txtpercentin.Text)) / 100) / (Val(txtinput.Text) + Val(txtexcess.Text))) * 100
            ElseIf tempprocesskarigar(mfgprocessno(txtpart.SelectedText)) = False And tempprocessexcess(mfgprocessno(txtpart.SelectedText)) = True Then 'for solder process
                txtpercentout.Text = Format(((((Val(txtinput.Text) * Val(txtpercentin.Text)) / 100) + ((Val(txtexcess.Text) * Val(txtpurity.Text)) / 100)) / (Val(txtoutput.Text) + Val(txtwastage.Text) + Val(txtsample.Text.Trim))) * 100, "0.00")
            Else


                'getting tempkarigarpercent
                Dim tempp, tempg, tempn As Double   'for purity, gross, nett in gridkarigar
                tempp = 0
                tempg = 0
                tempn = 0

                For Each row As DataGridViewRow In gridkarigar.Rows
                    tempg = Val(row.Cells(2).Value) + tempg
                    tempn = Val(row.Cells(3).Value) + tempn
                    tempp = Val((Val(tempn) / Val(tempg)) * 100)
                Next


                'THIS WILL BE APPLICABLE ONLY WHEN WE ISSUE SOMETING EXTRA IN KARIGAR PROCESS 
                'AS PER MEHUL BHAI
                If ClientName = "SHASHAWAT" Or ClientName = "SANGAM" Then
                    If tempn = 0 Then
                        txtpercentout.Text = Format(Val(txtpercentin.Text), "0.00")
                        txtpercentfinal.Text = Format(Val(txtpercentin.Text), "0.00")
                        Exit Sub
                    End If
                Else
                    txtpercentout.Text = Format(Val(txtpercentin.Text), "0.00")
                    txtpercentfinal.Text = Format(Val(txtpercentin.Text), "0.00")
                End If


                'IF WE HAVE SELECTED KARIGAR AND WE HAVE NOT SELECTED EXCESS THEN LOSS WILL COME NEGATIVE
                'IN THIS SCENARION WE DONT WANT TO CHANGE THE REPORT
                If tempprocesskarigar(mfgprocessno(txtpart.SelectedText)) = True And tempprocessexcess(mfgprocessno(txtpart.SelectedText)) = False Then Exit Sub


                txtpercentout.Text = ((Val(txtinput.Text) * Val(txtpercentin.Text)) / 100)
                If Val(txtpurity.Text) = 0 Then
                    'txtpercentout.Text = tempn + Val(txtpercentout.Text) + (Val(txtexcess.Text) - Val(tempg))
                    txtpercentout.Text = tempn + Val(txtpercentout.Text)
                Else
                    txtpercentout.Text = tempn + Val(txtpercentout.Text) + (Val(txtexcess.Text) * Val(txtpurity.Text) / 100)
                End If
                txtpercentout.Text = Format((Val(txtpercentout.Text) / ((Val(txtoutput.Text)) + Val(txtwastage.Text) + Val(txtsample.Text))) * 100, "0.00")

                'getting excess
                If txtexcess.Visible = True Then txtexcess.Text = Format((Val(txtoutput.Text) + Val(txtsample.Text) + Val(txtwastage.Text)) - Val(txtinput.Text) - Val(tempg), "0.000")

            End If
            txtpercentfinal.Text = Format(Val(txtpercentout.Text), "0.00")

        End If

    End Sub

    Sub gridcalculations()
        If ClientName = "MIMARA" Then
            For Each row1 As DataGridViewRow In gridmfg.Rows

                If row1.IsNewRow = False Then

                    If row1.Cells("GPARTNO").Value = gridmfg.CurrentRow.Cells("GPARTNO").Value And row1.Index >= gridmfg.CurrentRow.Index Then

                        If row1.Cells(1).Value <> Nothing Then
                            'getting loss
                            If tempprocessloss(Array.IndexOf(tempprocess, row1.Cells(1).Value.ToString)) = True Then
                                row1.Cells(7).Value = Val(row1.Cells(3).EditedFormattedValue) - (Val(row1.Cells(4).EditedFormattedValue) + Val(row1.Cells(5).EditedFormattedValue) + Val(row1.Cells(6).EditedFormattedValue))
                            End If


                            'CHECK MAX LOSS FROM PROCESSMASTER IF MAX THEN COLOR CODE
                            If Val(row1.Cells(7).Value) > 0 Then
                                cmd = New OleDbCommand("select PROCESS_MAXLOSS from PROCESSMASTER where PROCESS_NAME  = '" & row1.Cells(1).Value & "'", conn)
                                If conn.State = ConnectionState.Open Then conn.Close()
                                conn.Open()
                                dr = cmd.ExecuteReader
                                If dr.HasRows = True Then
                                    dr.Read()
                                    If Val(row1.Cells(7).Value) > Format((Val(dr(0)) * Val(row1.Cells(4).Value)) / 100, "0.000") Then
                                        row1.DefaultCellStyle.BackColor = Color.Yellow
                                    Else
                                        row1.DefaultCellStyle.BackColor = Color.Empty
                                    End If
                                End If
                            Else
                                row1.DefaultCellStyle.BackColor = Color.Empty
                            End If

                            'getting vaccum
                            If tempprocessvaccum(Array.IndexOf(tempprocess, row1.Cells(1).Value.ToString)) = True Then
                                row1.Cells(8).Value = Val(row1.Cells(3).EditedFormattedValue) - (Val(row1.Cells(4).EditedFormattedValue) + Val(row1.Cells(5).EditedFormattedValue) + Val(row1.Cells(6).EditedFormattedValue))
                            End If

                            'getting excess
                            If tempprocessexcess(Array.IndexOf(tempprocess, row1.Cells(1).Value.ToString)) = True Then
                                row1.Cells(10).Value = (Val(row1.Cells(4).EditedFormattedValue) + Val(row1.Cells(5).EditedFormattedValue) + Val(row1.Cells(6).EditedFormattedValue)) - Val(row1.Cells(3).EditedFormattedValue)
                            End If

                            'getting KARIGAR
                            If tempprocesskarigar(Array.IndexOf(tempprocess, row1.Cells(1).Value.ToString)) = True Then
                                Dim TOTALKARIGARGROSS As Double = 0.0
                                For Each ROW As DataGridViewRow In gridkarigar.Rows
                                    TOTALKARIGARGROSS = TOTALKARIGARGROSS + Format(Convert.ToDouble(ROW.Cells("karigargrosswt").Value), "0.00")
                                Next

                                row1.Cells(10).Value = (Val(row1.Cells(4).EditedFormattedValue) + Val(row1.Cells(5).EditedFormattedValue) + Val(row1.Cells(6).EditedFormattedValue)) - (Val(row1.Cells(3).EditedFormattedValue) + TOTALKARIGARGROSS)
                            End If


                            'getting %In as melting else getting from last process from grid
                            If tempprocessno(Array.IndexOf(tempprocess, row1.Cells(1).Value.ToString)) = 1 Then
                                row1.Cells(11).Value = Val(txtmelting.Text)
                            End If


                            'getting %Out  and %final
                            If tempprocesskarigar(Array.IndexOf(tempprocess, row1.Cells(1).Value.ToString)) = False And tempprocessexcess(Array.IndexOf(tempprocess, row1.Cells(1).Value.ToString)) = False Then

                                row1.Cells(12).Value = (((Val(row1.Cells(3).EditedFormattedValue) * Val(row1.Cells(11).EditedFormattedValue)) / 100) / (Val(row1.Cells(3).EditedFormattedValue) + Val(row1.Cells(10).EditedFormattedValue))) * 100
                                row1.Cells(13).Value = row1.Cells(12).EditedFormattedValue

                            ElseIf tempprocesskarigar(Array.IndexOf(tempprocess, row1.Cells(1).Value.ToString)) = True And tempprocessexcess(Array.IndexOf(tempprocess, row1.Cells(1).Value.ToString)) = True Then

                                'getting tempkarigarpercent
                                Dim tempp, tempg, tempn As Double   'for purity, gross, nett in gridkarigar
                                tempp = 0
                                tempg = 0
                                tempn = 0

                                For Each row As DataGridViewRow In gridkarigar.Rows
                                    tempg = Val(row.Cells(2).Value) + tempg
                                    tempn = Val(row.Cells(3).Value) + tempn
                                    tempp = Val((Val(tempn) / Val(tempg)) * 100)
                                Next
                                row1.Cells(13).Value = (((Val(row1.Cells(3).EditedFormattedValue) * Val(row1.Cells(11).EditedFormattedValue)) / 100) / (Val(row1.Cells(3).EditedFormattedValue) + Val(row1.Cells(10).EditedFormattedValue))) * 100
                                row1.Cells(12).Value = row1.Cells(13).Value

                            ElseIf tempprocesskarigar(Array.IndexOf(tempprocess, row1.Cells(1).Value.ToString)) = False And tempprocessexcess(Array.IndexOf(tempprocess, row1.Cells(1).Value.ToString)) = True Then

                                row1.Cells(13).Value = (((Val(row1.Cells(3).EditedFormattedValue) * Val(row1.Cells(11).EditedFormattedValue)) / 100) / (Val(row1.Cells(4).EditedFormattedValue) + Val(row1.Cells(6).EditedFormattedValue))) * 100
                                row1.Cells(12).Value = row1.Cells(13).Value

                            End If


                            'setting partname and percentinput of particular part
                            find = InStr(row1.Cells(0).Value.ToString, "(")
                            findend = InStr(row1.Cells(0).Value.ToString, ")")
                            txtpart.Text = row1.Cells(0).Value.ToString
                            txtpart.SelectionStart = find
                            txtpart.SelectionLength = findend - find - 1

                            partname(txtpart.SelectedText) = Val(row1.Cells(4).EditedFormattedValue)

                            'if there is split on that particular line then partname(selected part) would be subtracted by the amt splitted
                            cmd = New OleDbCommand("select mfg_wt from tempsplit where mfg_no = " & Val(txtmfgno.Text) & " and mfg_lineno = " & row1.Index, conn)
                            If conn.State = ConnectionState.Open Then
                                conn.Close()
                            End If
                            conn.Open()
                            dr = cmd.ExecuteReader
                            If dr.HasRows = True Then
                                dr.Read()
                                partname(txtpart.SelectedText) = Format(partname(txtpart.SelectedText) - Val(dr(0).ToString), "0.000")
                            End If

                            percentinput(txtpart.SelectedText) = row1.Cells(12).EditedFormattedValue
                            'changing inputwt in grid where PART() is same
                            If gridmfg.CurrentRow.IsNewRow = False Then

                                For i = row1.Index To gridmfg.RowCount - 2
                                    If gridmfg.Rows(i + 1).Cells(0).Value = gridmfg.Rows(row1.Index).Cells(0).Value Then
                                        gridmfg.Rows(i + 1).Cells(3).Value = partname(txtpart.SelectedText)
                                        gridmfg.Rows(i + 1).Cells(11).Value = percentinput(txtpart.SelectedText)
                                    End If
                                Next
                            End If

                        End If
                    End If

                End If

            Next
        End If
    End Sub

    Private Sub cmdskip_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdskip.Click

        find = InStr(cmbpart.Text.Trim, "(")
        findend = InStr(cmbpart.Text.Trim, ")")
        txtpart.Text = cmbpart.Text.Trim
        txtpart.SelectionStart = find
        txtpart.SelectionLength = findend - find - 1

        If partname(txtpart.SelectedText) = 0 Then
            MsgBox("Input Wt cannot be 0", MsgBoxStyle.Critical)
            txtinput.Focus()
            Exit Sub
        End If

        'if lotfail then exit
        If lotfail(txtpart.SelectedText) = True Then Exit Sub

        'IF LOT COMPLETED THE EXIT SUB
        If tempprocessno(mfgprocessno(txtpart.SelectedText)) = 0 Then Exit Sub


        'if process is completed then ask for itemname and exit
        If tempprocessno(txtpart.SelectedText) = 0 Then
            If mfgitemname(txtpart.SelectedText) = "" Then
Line1:
                mfgitemname(txtpart.SelectedText) = InputBox("Enter Item Name")
                If mfgitemname(txtpart.SelectedText) = "" Then GoTo Line1

                'checkiung wherther item is present or not
                cmd = New OleDbCommand("select item_id from itemmaster where item_name = '" & mfgitemname(txtpart.SelectedText) & "'", conn)
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
                conn.Open()
                dr = cmd.ExecuteReader
                If dr.HasRows = False Then

                    'adding item in itemmaster
                    For i = 0 To 50
                        tempcol(i) = ""
                        tempval(i) = ""
                    Next
                    tempcol(0) = "item_name"
                    tempcol(1) = "item_code"
                    tempcol(2) = "item_typeid"
                    tempcol(3) = "item_categoryid"
                    tempcol(4) = "item_rate"
                    tempcol(5) = "item_imagepath"
                    tempcol(6) = "item_userid"

                    tempval(0) = "'" & UCase(mfgitemname(txtpart.SelectedText)) & "'"
                    tempval(1) = "'" & UCase(mfgitemname(txtpart.SelectedText)) & "'"
                    tempval(2) = "1"
                    tempval(3) = "1"
                    tempval(4) = "0"
                    tempval(5) = "''"
                    tempval(6) = tempuserid
                    percentinput(txtpart.SelectedText) = Val(txtpercentfinal.Text)

                    insert("itemmaster", tempcol, tempval)

                    Exit Sub
                End If

            Else
                MsgBox("Process Completed!", MsgBoxStyle.Critical)
                Exit Sub
            End If

        End If


        txtoutput.Text = Format(Val(txtinput.Text), "0.000")
        partname(txtpart.SelectedText) = Val(txtoutput.Text)

        calculations()
        fillgrid()

        'if the process was karigar then update tempkarigarissue and mark mfg_recd as yes if this is not done then the gold will s\be shown in trialbalance against the selected party(Karigar)
        If gridkarigar.RowCount > 1 Then
            For i = 0 To 100
                tempcol(i) = ""
                tempval(i) = ""
            Next
            tempcol(0) = "mfg_recd"
            tempval(0) = "True"
            tempcondition = " where mfg_no = " & Val(txtmfgno.Text) & " and mfg_part = '" & txtpart.SelectedText & "'"
            modify("tempkarigarissue", tempcol, tempval, tempcondition)
        End If

        mfgprocessno(txtpart.SelectedText) = mfgprocessno(txtpart.SelectedText) + 1
        selectprocess(mfgprocessno(txtpart.SelectedText))

        'clearing txtboxes
        TXTIRON.Clear()
        TXTIRONRETWT.Clear()
        txtoutput.Clear()
        txtsample.Clear()
        txtwastage.Clear()
        txtloss.Clear()
        txtvaccum.Clear()
        txtexcess.Clear()
        txtpurity.Clear()
        txtpercentout.Clear()
        txtpercentfinal.Clear()

        'DONE BY GULKIT....IT GIVES ERROR DO NOT OPEN
        'processdate.Value = globaldate

        If gridkarigar.Enabled = True Then gridkarigar.Focus() Else txtinput.Focus()

    End Sub

    Sub DIRECTACCOUNTENTRY()

        Dim TEMPWASTAGE As Double = 0

        find = InStr(cmbpart.Text.Trim, "(")
        findend = InStr(cmbpart.Text.Trim, ")")
        txtpart.Text = cmbpart.Text.Trim
        txtpart.SelectionStart = find
        txtpart.SelectionLength = findend - find - 1

        If lotfail(i) = True Then Exit Sub

        For j As Integer = 0 To 36
            tempcol(j) = ""
            tempval(j) = ""
        Next


        tempcol(0) = "VOUCHER_ID"
        tempcol(1) = "VOUCHER_date"
        tempcol(2) = "VOUCHER_ledgerid"
        tempcol(3) = "VOUCHER_ITEMID"
        tempcol(4) = "VOUCHER_grosswt"
        tempcol(5) = "VOUCHER_PURITY"
        tempcol(6) = "VOUCHER_WASTAGE"
        tempcol(7) = "VOUCHER_nettwt"
        tempcol(8) = "VOUCHER_balorjamaorpaid"
        tempcol(9) = "VOUCHER_TOTALGROSSWT"
        tempcol(10) = "VOUCHER_TOTALNETTWT"
        tempcol(11) = "VOUCHER_BALANCEWT"
        tempcol(12) = "VOUCHER_NARRATION"
        tempcol(13) = "VOUCHER_type"
        tempcol(14) = "VOUCHER_LESSWT"
        tempcol(15) = "VOUCHER_DIFF"
        tempcol(16) = "VOUCHER_USERID"
        tempcol(17) = "VOUCHER_DEPARTMENTID"
        tempcol(18) = "VOUCHER_GRIDSRNO"


        Dim TEMPVOUCHERID As Integer = 0
        Dim TITEMID As Integer = 0

        'GETMAX VOUCHERID THEN SAVE
        tempcmd = New OleDbCommand("SELECT MAX(VOUCHER_ID)  AS ACCID from VOUCHERS WHERE VOUCHER_TYPE = 'I'", tempconn)
        If tempconn.State = ConnectionState.Open Then tempconn.Close()
        tempconn.Open()
        tempdr = tempcmd.ExecuteReader
        If tempdr.HasRows Then
            tempdr.Read()
            If IsDBNull(tempdr("ACCID")) = True Then
                tempval(0) = 1
                TEMPVOUCHERID = 1
            Else
                tempval(0) = tempdr("ACCID") + 1
                TEMPVOUCHERID = tempdr("ACCID") + 1
            End If

        Else
            tempval(0) = 1
            TEMPVOUCHERID = 1
        End If
        tempconn.Close()

        tempval(1) = "'" & Format(processdate.Value.Date, "dd/MM/yyyy") & "'"

        'GET LEDGERID, ITEMID FROM ORDER
        cmd = New OleDbCommand("SELECT ORDER_LEDGERID AS LEDGERID, ORDER_ITEMID AS ITEMID, LEDGERMASTER.LEDGER_CODE AS LEDGERCODE from ORDERMASTER INNER JOIN LEDGERMASTER ON ORDERMASTER.ORDER_LEDGERID = LEDGERMASTER.LEDGER_ID WHERE ORDER_SRNO = " & MFGORDERNO(i), conn)
        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Open()
        dr = cmd.ExecuteReader
        If dr.HasRows Then
            dr.Read()
            tempval(2) = dr("LEDGERID")
            tempval(3) = dr("ITEMID")
            TITEMID = dr("ITEMID")
        Else
            tempval(2) = 0
            tempval(3) = 0
            TITEMID = 0
        End If
        conn.Close()


        tempval(4) = Val(partname(i))       'GROSSWT
        tempval(5) = Val(percentinput(i))   'PURITY


        'WASTAGE FROM PARTY WASTAGE TABLE
        cmd = New OleDbCommand("SELECT WASTAGE from CUSTOMERWASTAGE WHERE LEDGERID = " & tempval(2) & " AND ITEMID = " & tempval(3), conn)
        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Open()
        dr = cmd.ExecuteReader
        If dr.HasRows Then
            dr.Read()
            tempval(6) = Val(dr("WASTAGE"))
            TEMPWASTAGE = Val(dr("WASTAGE"))
        Else
            tempval(6) = 0
        End If
        conn.Close()


        tempval(7) = Format(Val((Val(percentinput(i)) + Val(tempval(6))) * Val(partname(i))) / 100, "0.000") 'NETTWT

        tempval(8) = "'Balance'"
        tempval(9) = Val(partname(i))
        tempval(10) = Format(Val((Val(percentinput(i)) + Val(TEMPWASTAGE)) * Val(partname(i))) / 100, "0.000")
        tempval(11) = Format(Val((Val(percentinput(i)) + Val(TEMPWASTAGE)) * Val(partname(i))) / 100, "0.000")
        tempval(12) = "''"
        tempval(13) = "'I'"
        tempval(14) = "'0'"
        tempval(15) = "'0'"
        tempval(16) = Val(USERID)
        tempval(17) = Val(USERDEPARTMENTID)
        tempval(18) = 1 'GRIDSRNO

        insert("VOUCHERS", tempcol, tempval)
        '********************************************************



        '******************** 'ADDING IN ACCOUNTSMASTER ALSO' *******************
        For j As Integer = 0 To 36
            tempcol(j) = ""
            tempval(j) = ""
        Next


        tempcol(0) = "account_date"
        tempcol(1) = "account_ledgerid"
        tempcol(2) = "account_grosswt"
        tempcol(3) = "account_nettwt"
        tempcol(4) = "account_amount"
        tempcol(5) = "account_narration"
        tempcol(6) = "account_balorjamaorpaid"
        tempcol(7) = "account_voucherid"
        tempcol(8) = "account_type"
        tempcol(9) = "account_ledgercode"
        tempcol(10) = "account_ITEMID"
        tempcol(11) = "account_PURITY"
        tempcol(12) = "account_USERID"
        tempcol(13) = "account_DEPARTMENTID"
        tempcol(14) = "account_PROCESS"



        tempval(0) = "'" & Format(processdate.Value.Date, "dd/MM/yyyy") & "'"

        'GET LEDGERID, ITEMID FROM ORDER
        cmd = New OleDbCommand("SELECT ORDER_LEDGERID AS LEDGERID, ORDER_ITEMID AS ITEMID, LEDGERMASTER.LEDGER_CODE AS LEDGERCODE from ORDERMASTER INNER JOIN LEDGERMASTER ON ORDERMASTER.ORDER_LEDGERID = LEDGERMASTER.LEDGER_ID WHERE ORDER_SRNO = " & MFGORDERNO(i), conn)
        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Open()
        dr = cmd.ExecuteReader
        If dr.HasRows Then
            dr.Read()
            tempval(1) = dr("LEDGERID")
            tempval(9) = "'" & dr("LEDGERCODE") & "'"
        Else
            tempval(1) = 0
            tempval(9) = "''"
        End If
        conn.Close()


        tempval(2) = Val(partname(i))       'GROSSWT
        tempval(3) = Format(Val((Val(percentinput(i)) + Val(TEMPWASTAGE)) * Val(partname(i))) / 100, "0.000") 'NETTWT
        tempval(4) = 0                  'AMOUNT
        tempval(5) = "''"
        tempval(6) = "'Balance'"
        tempval(7) = TEMPVOUCHERID
        tempval(8) = "'I'"
        tempval(10) = TITEMID
        tempval(11) = Val(percentinput(i))   'PURITY
        tempval(12) = Val(USERID)
        tempval(13) = Val(USERDEPARTMENTID)
        tempval(14) = "''"  'PROCESSNAME

        insert("ACCOUNTMASTER", tempcol, tempval)
        '********************************************************



        '******************** 'ADDING IN MFGDIRECTISSUE ALSO' *******************
        For j As Integer = 0 To 15
            tempcol(j) = ""
            tempval(j) = ""
        Next


        tempcol(0) = "MFG_NO"
        tempcol(1) = "MFG_LOTNO"
        tempcol(2) = "MFG_PARTNO"
        tempcol(3) = "MFG_VOUCHERID"
        tempcol(4) = "MFG_GROSSWT"
        tempcol(5) = "MFG_MELTING"
        tempcol(6) = "MFG_NETTWT"



        tempval(0) = Val(txtmfgno.Text.Trim)
        tempval(1) = Val(txtlotno.Text.Trim)
        tempval(2) = i
        tempval(3) = TEMPVOUCHERID
        tempval(4) = Val(partname(i))
        tempval(5) = Val(percentinput(i))
        tempval(6) = Format(Val((Val(percentinput(i)) + Val(TEMPWASTAGE)) * Val(partname(i))) / 100, "0.000")

        insert("MFGDIRECTISSUE", tempcol, tempval)
        '********************************************************

    End Sub

    Sub ACCOUNTENTRY()
        For i = 0 To 36
            tempcol(i) = ""
            tempval(i) = ""
        Next

        'USED FOR CALCULATING LABOUR 
        Dim OUTWT As Double = 0

        'delete data from acc master
        cmd = New OleDbCommand("delete from accountmaster where account_voucherid = " & txtmfgno.Text & " and account_type ='MFG'", conn)
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If

        conn.Open()
        cmd.ExecuteNonQuery()
        conn.Close()


        tempcol(0) = "account_date"
        tempcol(1) = "account_ledgerid"
        tempcol(2) = "account_grosswt"
        tempcol(3) = "account_nettwt"
        tempcol(4) = "account_amount"
        tempcol(5) = "account_narration"
        tempcol(6) = "account_balorjamaorpaid"
        tempcol(7) = "account_voucherid"
        tempcol(8) = "account_type"
        tempcol(9) = "account_ledgercode"
        tempcol(10) = "account_USERID"
        tempcol(11) = "account_DEPARTMENTID"
        tempcol(12) = "account_PROCESS"


        'GETOUTPUTWT FOR CALCULATION
        dt = New DataTable()
        Dim A = New OleDbCommand("SELECT MFG_OUTPUTWT AS OUTPUTWT FROM KARIGARISSUE where mfg_no = " & Val(txtmfgno.Text) & " and mfg_part = '" & txtpart.SelectedText & "'", tempconn)
        Dim TEMPDA = New OleDbDataAdapter(A)
        TEMPDA.Fill(dt)
        If dt.Rows.Count > 0 Then OUTWT = Val(dt.Rows(0).Item("OUTPUTWT"))


        For i = 0 To gridkarigar.RowCount - 2

            If Val(gridkarigar.Rows(i).Cells(GLABOUR.Index).Value) > 0 Then

                '******************** PATRY NAME (JAMA) ************************
                tempval(0) = "'" & Format(mfgdate.Value, "dd/MM/yyyy") & "'"
                'getting nameid
                cmd = New OleDbCommand("select ledger_id,ledger_code from ledgermaster where ledger_code = '" & gridkarigar.Rows(i).Cells(4).Value & "'", conn)
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
                conn.Open()
                dr = cmd.ExecuteReader()
                If dr.HasRows Then
                    dr.Read()
                    tempval(1) = Val(dr(0))
                    tempname = dr(1)
                Else
                    tempval(1) = Val(0)
                End If
                conn.Close()
                'DONE BY GULKIT
                'tempval(2) = Val(gridkarigar.Rows(i).Cells(2).Value)
                'tempval(3) = Val(gridkarigar.Rows(i).Cells(3).Value)
                'tempval(4) = Val(gridkarigar.Rows(i).Cells(5).Value) * Val(gridkarigar.Rows(i).Cells(2).Value)
                tempval(2) = OUTWT
                tempval(3) = Val(0)
                tempval(4) = Val(gridkarigar.Rows(i).Cells(5).Value) * Val(OUTWT)
                tempval(5) = "''"
                tempval(6) = "'Jama'"
                tempval(7) = Val(txtmfgno.Text)
                tempval(8) = "'MFG'"
                tempval(9) = "'" & tempname & "'"
                tempval(10) = Val(USERID)
                tempval(11) = Val(USERDEPARTMENTID)
                tempval(12) = "''"  'PROCESSNAME

                insert("accountmaster", tempcol, tempval)
                '********************************************************

                '******************** LABOUR CHARGES (BALANCE) ************************
                'getting labourid
                cmd = New OleDbCommand("select ledger_id,ledger_code from ledgermaster where ledger_code = 'Labour Charges'", conn)
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
                conn.Open()
                dr = cmd.ExecuteReader()
                If dr.HasRows Then
                    dr.Read()
                    tempval(1) = Val(dr(0))
                    tempname = dr(1)
                Else
                    tempval(1) = Val(0)
                End If
                conn.Close()
                tempval(2) = 0
                tempval(3) = 0
                'DONE BY GULKIT
                'tempval(4) = Val(gridkarigar.Rows(i).Cells(5).Value) * Val(gridkarigar.Rows(i).Cells(2).Value)
                tempval(4) = Val(gridkarigar.Rows(i).Cells(5).Value) * Val(OUTWT)
                tempval(5) = "''"
                tempval(6) = "'Balance'"
                tempval(7) = Val(txtmfgno.Text)
                tempval(8) = "'MFG'"
                tempval(9) = "'" & tempname & "'"
                tempval(10) = Val(USERID)
                tempval(11) = Val(USERDEPARTMENTID)
                tempval(12) = "''"  'PROCESSNAME

                insert("accountmaster", tempcol, tempval)
                '********************************************************
            End If
        Next
    End Sub

    Private Sub txtnarration_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtnarration.Validated
        If txtnarration.Text.Trim <> "" Then
            find = InStr(cmbpart.Text.Trim, "(")
            findend = InStr(cmbpart.Text.Trim, ")")
            txtpart.Text = cmbpart.Text.Trim
            txtpart.SelectionStart = find
            txtpart.SelectionLength = findend - find - 1

            tempnarration(txtpart.SelectedText) = txtnarration.Text.Trim
        End If
    End Sub

    Private Sub txtoutput_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtoutput.Validated
        txtoutput.Text = Format(Val(txtoutput.Text), "0.000")
        calculations()
    End Sub

    Private Sub txtsample_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtsample.Validated
        txtsample.Text = Format(Val(txtsample.Text), "0.000")
        calculations()
    End Sub

    Private Sub txtwastage_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtwastage.Validated
        txtwastage.Text = Format(Val(txtwastage.Text), "0.000")
        calculations()
    End Sub

    Private Sub txtvaccum_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtvaccum.Validated
        txtvaccum.Text = Format(Val(txtvaccum.Text), "0.000")
        calculations()
    End Sub

    Private Sub txtloss_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtloss.Validated
        txtloss.Text = Format(Val(txtloss.Text), "0.000")
        calculations()
    End Sub

    Private Sub txtlotno_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtlotno.Validating
        'If txtlotno.Text.Trim.Length = 0 Then e.Cancel = True

        If Val(txtlotno.Text) <> 0 Then

            cmd = New OleDbCommand("select melting_reqmelting,melting_output,MELTING_NARRATION AS REMARKS, MELTING_REFNO AS REFNO from meltingmaster where melting_id = " & Val(txtlotno.Text) & " and melting_mfg =" & False, conn)
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
            conn.Open()
            dr = cmd.ExecuteReader
            If dr.HasRows = True Then

                dr.Read()
                txtlotno.Enabled = False
                TXTREFNO.Text = dr("REFNO")

                groupgrid.Enabled = True
                groupmfg.Enabled = True
                txtmelting.Text = Format(Val(dr(0).ToString), "0.000")
                txtinput.Text = Format(Val(dr(1).ToString), "0.000")
                txtpercentin.Text = Format(Val(dr(0).ToString), "0.00")
                percentinput(splitno) = Format(Val(txtpercentin.Text), "0.00")
                partname(splitno) = Val(txtinput.Text)
                If ClientName = "JAINAM" Then
                    txtnarration.Text = dr("REMARKS")
                Else
                    TXTBRIEF.Text = dr("REMARKS")
                End If
                fillcmbpart()

            Else

                'checking in mfgmaster and opening in edit moDe 
                cmd = New OleDbCommand("select mfg_no from mfgmaster where mfg_LOTno = " & Val(txtlotno.Text), conn)
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
                conn.Open()
                dr = cmd.ExecuteReader
                If dr.HasRows = True Then

                    dr.Read()
                    tempmfgno = dr(0).ToString
                    cmdedit.Enabled = False
                    edit = True
                    Manufacturing_Load(sender, e)
                    Exit Sub

                Else
                    MsgBox("Invalid Lot No", MsgBoxStyle.Critical)
                    e.Cancel = True
                End If
            End If
        End If

    End Sub

    Sub fillgrid()
        If Val(txtlotno.Text) <> 0 And Val(txtmelting.Text) <> 0 And Val(txtinput.Text) <> 0 And Val(txtoutput.Text) <> 0 And Val(txtpercentin.Text) <> 0 And Val(txtpercentout.Text) <> 0 And Val(txtpercentfinal.Text) <> 0 Then


            find = InStr(cmbpart.Text.Trim, "(")
            findend = InStr(cmbpart.Text.Trim, ")")
            txtpart.Text = cmbpart.Text.Trim
            txtpart.SelectionStart = find
            txtpart.SelectionLength = findend - find - 1

            STOPVALIDATE = True
            Dim GRIDNAME As String = mfgitemname(txtpart.SelectedText)

            If GRIDNAME = "" And ClientName = "KANAK" Then GRIDNAME = txtnarration.Text.Trim

            gridmfg.Rows.Add(cmbpart.Text.Trim, tempprocess(mfgprocessno(txtpart.SelectedText)), GRIDNAME, Val(txtinput.Text), Val(txtoutput.Text), Val(txtsample.Text), Val(txtwastage.Text), Val(txtloss.Text), Val(txtvaccum.Text), Format(processdate.Value, "dd/MM/yyyy"), Val(txtexcess.Text), Val(txtpercentin.Text), Val(txtpercentout.Text), Val(txtpercentfinal.Text), templabour, Val(TXTIRON.Text.Trim), Val(TXTIRONRETWT.Text.Trim))
            STOPVALIDATE = False

            'CHECK MAX LOSS FROM PROCESSMASTER IF MAX THEN COLOR CODE
            If Val(txtloss.Text.Trim) > 0 Then
                cmd = New OleDbCommand("select PROCESS_MAXLOSS from PROCESSMASTER where PROCESS_NAME  = '" & tempprocess(mfgprocessno(txtpart.SelectedText)) & "'", conn)
                If conn.State = ConnectionState.Open Then conn.Close()
                conn.Open()
                dr = cmd.ExecuteReader
                If dr.HasRows = True Then
                    dr.Read()
                    If Val(txtloss.Text.Trim) > Format((Val(dr(0)) * Val(txtoutput.Text.Trim)) / 100, "0.000") Then
                        gridmfg.Rows(gridmfg.RowCount - 2).DefaultCellStyle.BackColor = Color.Yellow
                    Else
                        gridmfg.Rows(gridmfg.RowCount - 2).DefaultCellStyle.BackColor = Color.Empty
                    End If
                End If
            Else
                gridmfg.Rows(gridmfg.RowCount - 2).DefaultCellStyle.BackColor = Color.Empty
            End If


            gridmfg.FirstDisplayedScrollingRowIndex = gridmfg.RowCount - 1
        End If
    End Sub

    Private Sub txtpercentfinal_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtpercentfinal.Validated

        'IF BACK DATED ENTRY IS TO BE SAVED THEN CHECK ENTRYPASSWORD
        If APPLYBLOCKDATE = True And processdate.Value.Date <= BLOCKEDDATE.Date Then
            Dim OBJPASS As New PasswordEntry
            OBJPASS.ShowDialog()
            If ENTRYPASSWORD <> OBJPASS.TXTDATERETYPE.Text.Trim Then
                MsgBox("Invaid Password", MsgBoxStyle.Critical)
                Exit Sub
            End If
        End If

        txtpercentfinal.Text = Format(Val(txtpercentfinal.Text), "0.00")

        find = InStr(cmbpart.Text.Trim, "(")
        findend = InStr(cmbpart.Text.Trim, ")")
        txtpart.Text = cmbpart.Text.Trim
        txtpart.SelectionStart = find
        txtpart.SelectionLength = findend - find - 1

        If partname(txtpart.SelectedText) = 0 Then
            MsgBox("Input Wt cannot be 0", MsgBoxStyle.Critical)
            txtinput.Focus()
            Exit Sub
        End If


        'if lot failed then exit
        If lotfail(txtpart.SelectedText) = True Then Exit Sub


        'IF LOT COMPLETED THE EXIT SUB
        If tempprocessno(mfgprocessno(txtpart.SelectedText)) = 0 Then Exit Sub


        'if OUTPUT = 0 THEN EXIT SUB
        If Val(txtlotno.Text) = 0 Or Val(txtmelting.Text) = 0 Or Val(txtinput.Text) = 0 Or Val(txtoutput.Text) = 0 Or Val(txtpercentin.Text) = 0 Or Val(txtpercentout.Text) = 0 Or Val(txtpercentfinal.Text) = 0 Then Exit Sub



        If tempprocessno(mfgprocessno(txtpart.SelectedText) + 1) = 0 Then
            If mfgitemname(txtpart.SelectedText) = "" Then
Line3:
                'GET ITEMNAME FROM TEXTBOX (ORDER)
                If Val(TXTORDERNO.Text.Trim) > 0 And TXTITEMNAME.Text.Trim <> "" Then
                    mfgitemname(txtpart.SelectedText) = TXTITEMNAME.Text.Trim
                Else
                    mfgitemname(txtpart.SelectedText) = InputBox("Enter Item Name")
                End If
                If mfgitemname(txtpart.SelectedText) = "" Then GoTo Line3
            End If
        End If

        'first let it go throught these processes then add in itemmaster
        If tempprocessno(mfgprocessno(txtpart.SelectedText)) <> 0 Then
            fillgrid()

            'if the process was karigar then update tempkarigarissue and mark mfg_recd as yes if this is not done then the gold will s\be shown in trialbalance against the selected party(Karigar)
            If gridkarigar.RowCount > 1 And tempprocesskarigar(mfgprocessno(txtpart.SelectedText)) = True Then
                For i = 0 To 100
                    tempcol(i) = ""
                    tempval(i) = ""
                Next
                tempcol(0) = "mfg_recd"
                tempcol(1) = "mfg_OUTPUTWT"
                tempcol(2) = "mfg_PERCENTFINAL"

                tempval(0) = "True"
                tempval(1) = Val(txtoutput.Text.Trim)
                tempval(2) = Val(txtpercentfinal.Text.Trim)
                tempcondition = " where mfg_no = " & Val(txtmfgno.Text) & " and mfg_part = '" & txtpart.SelectedText & "'"
                modify("tempkarigarissue", tempcol, tempval, tempcondition)
            End If

            mfgprocessno(txtpart.SelectedText) = mfgprocessno(txtpart.SelectedText) + 1
            selectprocess(mfgprocessno(txtpart.SelectedText))
        End If




        'if process is completed then ask for itemname and exit
        If tempprocessno(mfgprocessno(txtpart.SelectedText)) = 0 Then
            'If mfgitemname(txtpart.SelectedText) = "" Then
            'Line2:
            'mfgitemname(txtpart.SelectedText) = InputBox("Enter Item Name")
            'If mfgitemname(txtpart.SelectedText) = "" Then GoTo Line2

            'checkiung wherther item is present or not
            cmd = New OleDbCommand("select item_id from itemmaster where item_name = '" & mfgitemname(txtpart.SelectedText) & "'", conn)
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
            conn.Open()
            dr = cmd.ExecuteReader
            If dr.HasRows = False Then

                partname(txtpart.SelectedText) = Val(txtoutput.Text)
                percentinput(txtpart.SelectedText) = Val(txtpercentfinal.Text)

                'adding item in itemmaster
                For i = 0 To 50
                    tempcol(i) = ""
                    tempval(i) = ""
                Next
                tempcol(0) = "item_name"
                tempcol(1) = "item_code"
                tempcol(2) = "item_typeid"
                tempcol(3) = "item_categoryid"
                tempcol(4) = "item_rate"
                tempcol(5) = "item_imagepath"
                tempcol(6) = "item_userid"

                tempval(0) = "'" & UCase(mfgitemname(txtpart.SelectedText)) & "'"
                tempval(1) = "'" & UCase(mfgitemname(txtpart.SelectedText)) & "'"
                tempval(2) = "1"
                tempval(3) = "1"
                tempval(4) = "0"
                tempval(5) = "''"
                tempval(6) = tempuserid

                insert("itemmaster", tempcol, tempval)
                Exit Sub

            End If

            'Else
            '    MsgBox("Process Completed!", MsgBoxStyle.Critical)
            '    Exit Sub
            'End If

        End If



        partname(txtpart.SelectedText) = Val(txtoutput.Text)    'if quoted then gives error on saving it gives wrong output
        'partname(txtpart.SelectedText) = Val(txtinput.Text)

        'IF PROCESS COMPLETED THEN SET PERCENT FINAL
        'IF CLIENTNAME = 'BHARAT' THEN CHANGE PERCENTINPUT AS PERCENTFINAL
        If tempprocessno(mfgprocessno(txtpart.SelectedText)) = 0 Then
            percentinput(txtpart.SelectedText) = Val(txtpercentfinal.Text)
        Else
            If ClientName = "BHARAT" Then percentinput(txtpart.SelectedText) = Val(txtpercentfinal.Text.Trim) Else percentinput(txtpart.SelectedText) = Val(txtpercentout.Text)
        End If
        txtinput.Text = Format(Val(txtoutput.Text), "0.000")
        If ClientName = "BHARAT" Then txtpercentin.Text = Format(Val(txtpercentfinal.Text), "0.00") Else txtpercentin.Text = Format(Val(txtpercentout.Text), "0.00")


        'clearing txtboxes
        TXTIRON.Clear()
        TXTIRONRETWT.Clear()
        txtoutput.Clear()
        txtsample.Clear()
        txtwastage.Clear()
        txtloss.Clear()
        txtvaccum.Clear()
        txtexcess.Clear()
        txtpurity.Clear()
        txtpercentout.Clear()
        txtpercentfinal.Clear()
        processdate.Value = GLOBALDATE

        If gridkarigar.Enabled = True Then gridkarigar.Focus() Else txtinput.Focus()

    End Sub

    Private Sub gridmfg_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles gridmfg.CellValidating
        'IF ERROR COMES CLOSE THIS SET OF CODE
        '***************************************************************
        '***************************************************************
        If ClientName = "MIMARA" And STOPVALIDATE = False Then
            If e.ColumnIndex = 4 Or e.ColumnIndex = 5 Or e.ColumnIndex = 6 Or e.ColumnIndex = 14 Then
                gridcalculations()

                cmbpart_Validated(sender, e)
                gridmfg.CurrentCell.Value = Convert.ToDecimal(Val(gridmfg.CurrentCell.Value))
            End If
        End If
        '***************************************************************
        '***************************************************************

        ''  CODE FOR NUMERIC CHECK ONLY
        Dim colNum As Integer = gridmfg.Columns(e.ColumnIndex).Index
        If String.IsNullOrEmpty(e.FormattedValue.ToString) Then Return

        Select Case colNum
            Case 3, 4, 5, 6, 10, 13, 14
                Dim dDebit As Decimal

                ''below code will convert empty or spaces into "0.00"
                'If gridpo.CurrentCell.Value.ToString.Trim = "" Then gridpo.CurrentCell.Value = "0.00"
                ''
                Dim bValid As Boolean = Decimal.TryParse(e.FormattedValue.ToString, dDebit)
                If bValid Then
                    If gridmfg.CurrentCell.Value = Nothing Then gridmfg.CurrentCell.Value = "0"
                    gridmfg.CurrentCell.Value = Convert.ToDecimal(gridmfg.Item(colNum, e.RowIndex).Value)
                    '' everything is good
                Else
                    MessageBox.Show("Invalid Number Entered")
                    e.Cancel = True
                End If
        End Select

        If e.ColumnIndex = 14 And e.RowIndex < gridmfg.RowCount - 1 Then
            If tempprocesskarigar(Array.IndexOf(tempprocess, gridmfg.CurrentRow.Cells(1).Value.ToString)) = False Then
                If Val(gridmfg.CurrentRow.Cells(14).EditedFormattedValue.ToString) > 0 Then
                    MessageBox.Show("Labour Not Allowed")
                    e.Cancel = True
                End If
            End If
        End If

    End Sub

    Private Sub cmdsplit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsplit.Click
        Dim tempcmblistindex As Long

        If partname(txtpart.SelectedText) = 0 Then
            MsgBox("Input Wt cannot be 0", MsgBoxStyle.Critical)
            txtinput.Focus()
            Exit Sub
        End If

        'if lotfail then exit
        If lotfail(txtpart.SelectedText) = True Then Exit Sub


        If txtinput.Text <> "" And txtlotno.Text <> "" Then

            splitno = splitno + 1

Line1:
            partname(splitno) = 0
            On Error Resume Next
            partname(splitno) = InputBox("Enter Input Weight")

            'getting partno
            find = InStr(cmbpart.Text.Trim, "(")
            findend = InStr(cmbpart.Text.Trim, ")")
            txtpart.Text = cmbpart.Text.Trim
            txtpart.SelectionStart = find
            txtpart.SelectionLength = findend - find - 1

            'txtinputwt.Text = partname(txtpartname.SelText)

            If partname(splitno) < 0 Or partname(splitno) >= partname(txtpart.SelectedText) Then
                MsgBox("Enter Proper Weight")
                GoTo Line1
            ElseIf partname(splitno) <> "0" Then
                'Split = True

                'If edit = True Then
                '    editsplit = True
                'End If

                partname(txtpart.SelectedText) = partname(txtpart.SelectedText) - partname(splitno)
                percentinput(splitno) = percentinput(txtpart.SelectedText)

                'DONE BY GULKIT
                'IF THERE IS AN ISSUE WITH THE PURITY (SOMETIMES THE PURITY CHANGES AUTO), THEN IT WILL INTIMATE
                If percentinput(splitno) <> txtpercentin.Text.Trim Then
                    MsgBox("Issue with Split Percent", MsgBoxStyle.Critical)
                    Exit Sub
                End If


                mfgprocessno(splitno) = mfgprocessno(txtpart.SelectedText)
                MFGBARCODE(splitno) = "MFG-" & Val(txtmfgno.Text.Trim) & "/" & splitno & "/" & CMPID


                'adding in split (tempsplit table for splitting)


                '*********** CODE BY GULKIT **************
                If EDIT = False Then
                        'CHECK SAME CODE IN TEMPSPLIT IF LOTNO IS PRESENT IN TEMPSPLIT THEN DONT CHECK MAX NO
                        cmd = New OleDbCommand("Select MFG_NO from TEMPSPLIT WHERE MFG_LOTNO = " & Val(txtlotno.Text.Trim), conn)
                        If conn.State = ConnectionState.Open Then conn.Close()
                        conn.Open()
                        dr = cmd.ExecuteReader
                        If dr.HasRows = False Then
                            GETMAX_MFG_NO()
                        End If
                    End If
                    '********** END OF CODE*****************



                    For i = 0 To 50
                        tempcol(i) = ""
                        tempval(i) = ""
                    Next

                    tempcol(0) = "mfg_no"
                    tempcol(1) = "mfg_splitfrom"
                    tempcol(2) = "mfg_splitto"
                    tempcol(3) = "mfg_date"
                    tempcol(4) = "mfg_wt"
                    tempcol(5) = "mfg_lineno"
                    tempcol(6) = "mfg_LOTNO"

                    tempval(0) = Val(txtmfgno.Text)
                    tempval(1) = Val(txtpart.SelectedText)
                    tempval(2) = Val(splitno)
                    tempval(3) = "'" & Format(processdate.Value, "dd/MM/yyyy") & "'"
                    tempval(4) = Val(partname(splitno))
                    tempval(5) = Val(gridmfg.RowCount - 2)
                    tempval(6) = Val(txtlotno.Text.Trim)

                    insert("tempsplit", tempcol, tempval)

                    fillcmbpart()
                    cmbpart_Validated(sender, e)

                End If

                If partname(splitno) = 0 Then
                splitno = splitno - 1
            End If

        End If
        txtinput.Focus()
    End Sub

    Private Sub txtinput_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtinput.Validated
        txtinput.Text = Format(Val(txtinput.Text), "0.000")
    End Sub

    Private Sub txtexcess_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtexcess.Validated
        txtexcess.Text = Format(Val(txtexcess.Text), "0.000")
        calculations()
    End Sub

    Private Sub txtpurity_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtpurity.Validated
        txtpurity.Text = Format(Val(txtpurity.Text), "0.000")
        calculations()
    End Sub

    Private Sub txtpercentin_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtpercentin.Validated
        txtpercentin.Text = Format(Val(txtpercentin.Text), "0.00")
    End Sub

    Private Sub txtpercentout_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtpercentout.Validated
        txtpercentout.Text = Format(Val(txtpercentout.Text), "0.00")
    End Sub

    Private Sub cmdlotfail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdlotfail.Click

        find = InStr(cmbpart.Text.Trim, "(")
        findend = InStr(cmbpart.Text.Trim, ")")
        txtpart.Text = cmbpart.Text.Trim
        txtpart.SelectionStart = find
        txtpart.SelectionLength = findend - find - 1

        If partname(txtpart.SelectedText) = 0 Then
            MsgBox("Input Wt cannot be 0", MsgBoxStyle.Critical)
            txtinput.Focus()
            Exit Sub
        End If


        'IF THERE IS NOTHING (I.E. CLEARED) THEN EXIT SUB
        If cmbpart.Text.Trim = "" Then Exit Sub
        If tempprocess(mfgprocessno(txtpart.SelectedText)) = Nothing Then
            MsgBox("Lot Completed", MsgBoxStyle.Critical)
            Exit Sub
        End If
        tempmsg = MsgBox("Mark Part No. " & Val(txtpart.SelectedText) & " as Failed ?", vbYesNo)
        If tempmsg = vbYes Then
            tempmsg = MsgBox("Are You sure?, Wish to Proceed", vbYesNo)
            If tempmsg = vbYes Then

                lotfail(txtpart.SelectedText) = True
                LOTFAILPERCENT(txtpart.SelectedText) = Format(Val(txtpercentfinal.Text.Trim), "0.00")
                lblfailed.Visible = True
                If CHKMERGE.CheckState = CheckState.Checked Then
                    lblfailed.Text = "MERGED"
                    LOTFAILMERGED(txtpart.SelectedText) = True
                Else
                    lblfailed.Text = "FAILED"
                    LOTFAILMERGED(txtpart.SelectedText) = False
                End If


                'THIS IS DONE COZ WHEN WE MERGE IN STOCK IT SHOWS MULTIPLE LINES COZ NARRATION IS IN GROUP BY CLAUSE 
                'IN STOCKVIEW
                TXTREMARKS.Text = TXTREMARKS.Text & " " & txtnarration.Text.Trim
                tempnarration(txtpart.SelectedText) = ""


                'checkiung wherther item is present or not
                cmd = New OleDbCommand("select item_id from itemmaster where item_name = '" & tempprocess(mfgprocessno(txtpart.SelectedText)) & "'", conn)
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
                conn.Open()
                dr = cmd.ExecuteReader
                If dr.HasRows = False Then

                    'adding in itemmaster with processname as itemname and code
                    For i = 0 To 50
                        tempcol(i) = ""
                        tempval(i) = ""
                    Next
                    tempcol(0) = "item_name"
                    tempcol(1) = "item_code"
                    tempcol(2) = "item_typeid"
                    tempcol(3) = "item_categoryid"
                    tempcol(4) = "item_rate"
                    tempcol(5) = "item_imagepath"
                    tempcol(6) = "item_userid"

                    tempval(0) = "'" & UCase(tempprocess(mfgprocessno(txtpart.SelectedText))) & "'"
                    tempval(1) = "'" & UCase(tempprocess(mfgprocessno(txtpart.SelectedText))) & "'"
                    tempval(2) = "1"
                    tempval(3) = "1"
                    tempval(4) = "0"
                    tempval(5) = "''"
                    tempval(6) = tempuserid

                    insert("itemmaster", tempcol, tempval)

                    cmbpart.Focus()
                End If
            End If
        End If

    End Sub

    Private Sub gridmfg_CurrentCellDirtyStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridmfg.CurrentCellDirtyStateChanged
        Try
            'IF ERROR COMES CLOSE THIS SET OF CODE
            '***************************************************************
            ''***************************************************************
            'If gridmfg.CurrentCell.ColumnIndex = 4 Or gridmfg.CurrentCell.ColumnIndex = 5 Or gridmfg.CurrentCell.ColumnIndex = 6 Or gridmfg.CurrentCell.ColumnIndex = 14 Then
            '    gridcalculations()


            '    cmbpart_Validated(sender, e)
            '    gridmfg.CurrentCell.Value = Convert.ToDecimal(Val(gridmfg.CurrentCell.Value))
            'End If
            '***************************************************************
            '***************************************************************
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridmfg_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridmfg.KeyDown

        If e.KeyCode = Keys.Delete Then
            If gridmfg.CurrentRow.Index = gridmfg.RowCount - 2 Then

                'getting partname
                find = InStr(gridmfg.Item(0, gridmfg.CurrentRow.Index).Value.ToString, "(")
                findend = InStr(gridmfg.Item(0, gridmfg.CurrentRow.Index).Value.ToString, ")")
                txtpart.Text = gridmfg.Item(0, gridmfg.CurrentRow.Index).Value.ToString
                txtpart.SelectionStart = find
                txtpart.SelectionLength = findend - find - 1


                mfgitemname(txtpart.SelectedText) = ""

                'removing split if done on line above line checking from tempsplit
                cmd = New OleDbCommand("select * from tempsplit where mfg_no = " & Val(txtmfgno.Text) & " and mfg_lineno = " & gridmfg.CurrentRow.Index - 1, conn)
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
                conn.Open()
                dr = cmd.ExecuteReader
                If dr.HasRows = True Then
                    While (dr.Read)
                        partname(Val(dr(1).ToString)) = partname(Val(dr(1).ToString)) + partname(Val(dr(2).ToString))
                        partname(Val(dr(2).ToString)) = 0

                        splitno = splitno - 1
                        fillcmbpart()
                    End While
                End If



                'CHECKING IF LOTFAIL OR NOT IF FAIL THEN EXIT
                cmd = New OleDbCommand("select * from mfgstock where mfg_no = " & Val(txtmfgno.Text) & " and mfg_partno = " & txtpart.SelectedText & " and mfg_lotfail = " & True, conn)
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
                conn.Open()
                dr = cmd.ExecuteReader
                If dr.HasRows = True Then
                    While (dr.Read)
                        lotfail(txtpart.SelectedText) = False
                    End While
                End If




                'if karigar from preocess is true for thst [articular part then delete data from tempkarigar
                'If tempprocesskarigar(txtpart.SelectedText) = True Then
                If tempprocesskarigar(mfgprocessno(txtpart.SelectedText)) <> Nothing Then
                    If tempprocesskarigar(mfgprocessno(txtpart.SelectedText)) = True Then
                        cmd = New OleDbCommand("delete from tempkarigarissue where mfg_no = " & Val(txtmfgno.Text), conn)
                        If conn.State = ConnectionState.Open Then
                            conn.Close()
                        End If
                        conn.Open()
                        cmd.ExecuteNonQuery()
                        gridkarigar.RowCount = 1
                    End If
                End If

                'getting partname of the txtpart.selectedtext
                If gridmfg.CurrentRow.IsNewRow = False Then
                    For i = (gridmfg.CurrentRow.Index - 1) To 1 Step -1
                        If gridmfg.Rows(i).Cells(0).Value = gridmfg.Rows(gridmfg.CurrentRow.Index).Cells(0).Value Then
                            partname(txtpart.SelectedText) = gridmfg.Rows(i).Cells(4).Value
                            GoTo line1
                        End If
                    Next
                End If
line1:
                mfgprocessno(txtpart.SelectedText) = mfgprocessno(txtpart.SelectedText) - 1
                percentinput(txtpart.SelectedText) = Val(gridmfg.Item(11, gridmfg.CurrentRow.Index).Value.ToString)
                gridmfg.Rows.RemoveAt(gridmfg.CurrentRow.Index)
                cmbpart_Validated(sender, e)

            Else
                MsgBox("Invalid Command")
            End If
            calculations()
        End If


        If e.KeyCode = Keys.Return Then
            Dim cur_cell As DataGridViewCell = gridmfg.CurrentCell
            Dim col As Integer = cur_cell.ColumnIndex

            If col = gridmfg.Columns.Count - 1 And gridmfg.CurrentRow.Index < gridmfg.RowCount - 1 Then
                cur_cell = gridmfg.Rows(gridmfg.CurrentRow.Index + 1).Cells(0)
            Else
                col = (col + 1) Mod gridmfg.Columns.Count
                cur_cell = gridmfg.CurrentRow.Cells(col)
            End If
            gridmfg.CurrentCell = cur_cell
            e.Handled = True
        End If

    End Sub

    Private Sub gridkarigar_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gridkarigar.Leave

        Dim j As Integer    'for loop

        '**************** SAVING IN TEMPKARIGARISSUE ********************

        '*********** CODE BY GULKIT **************
        If edit = False Then
            cmd = New OleDbCommand("Select MFG_NO from TEMPKARIGARISSUE WHERE MFG_LOTNO = " & Val(txtlotno.Text.Trim), conn)
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Open()
            dr = cmd.ExecuteReader
            If dr.HasRows = False Then
                GETMAX_MFG_NO()
            End If
            conn.Close()
            dr.Close()
        End If
        '********** END OF CODE*****************



        For i = 0 To 100
            tempcol(i) = ""
            tempval(i) = ""
        Next

        'adding data IN tempkaigarissue
        tempcol(0) = "mfg_no"
        tempcol(1) = "mfg_processdate"
        tempcol(2) = "mfg_itemid"
        tempcol(3) = "mfg_purity"
        tempcol(4) = "mfg_grosswt"
        tempcol(5) = "mfg_nettwt"
        tempcol(6) = "mfg_ledgerid"
        tempcol(7) = "mfg_labour"
        tempcol(8) = "mfg_part"
        tempcol(9) = "mfg_OUTPUTWT"
        tempcol(10) = "mfg_LOTNO"
        tempcol(11) = "mfg_GM"
        tempcol(12) = "mfg_INPUTWT"
        tempcol(13) = "mfg_PERCENTFINAL"
        tempcol(14) = "mfg_USERID"
        tempcol(15) = "mfg_DEPARTMENTID"


        For j = 0 To gridkarigar.RowCount - 2
            tempval(0) = Val(txtmfgno.Text)
            tempval(1) = "'" & Format(processdate.Value, "dd/MM/yyyy") & "'"

            If gridkarigar.Item(0, j).Value <> "" Then

                'getting itemid
                tempcmd = New OleDbCommand("select item_id from itemmaster where item_code = '" & gridkarigar.Item(0, j).Value.ToString & "'", tempconn)
                If tempconn.State = ConnectionState.Open Then
                    tempconn.Close()
                End If
                tempconn.Open()
                tempdr = tempcmd.ExecuteReader
                If tempdr.HasRows = True Then
                    tempdr.Read()
                    tempval(2) = Val(tempdr(0).ToString)
                Else
                    tempval(2) = "0"
                End If
            Else
                tempval(2) = "0"
            End If

            tempval(3) = Val(gridkarigar.Item(1, j).Value)
            tempval(4) = Val(gridkarigar.Item(2, j).Value)
            tempval(5) = Val(gridkarigar.Item(3, j).Value)


            If gridkarigar.Item(4, j).Value <> "" Then

                'getting ledgerid
                tempcmd = New OleDbCommand("select ledger_id from ledgermaster where ledger_code = '" & gridkarigar.Item(4, j).Value & "'", tempconn)
                If tempconn.State = ConnectionState.Open Then
                    tempconn.Close()
                End If
                tempconn.Open()
                tempdr = tempcmd.ExecuteReader
                If tempdr.HasRows = True Then
                    tempdr.Read()
                    tempval(6) = Val(tempdr(0).ToString)
                Else
                    tempval(6) = "0"
                End If
            Else
                tempval(6) = "0"
            End If

            tempval(7) = Val(gridkarigar.Item(5, j).Value)

            find = InStr(cmbpart.Text.Trim, "(")
            findend = InStr(cmbpart.Text.Trim, ")")
            txtpart.Text = cmbpart.Text.Trim
            txtpart.SelectionStart = find
            txtpart.SelectionLength = findend - find - 1
            tempval(8) = txtpart.SelectedText
            tempval(9) = Val(txtoutput.Text.Trim)
            tempval(10) = Val(txtlotno.Text.Trim)
            tempval(11) = "'" & gridkarigar.Item(GGM.Index, j).Value & "'"
            tempval(12) = Val(txtinput.Text.Trim)
            If Val(txtpercentfinal.Text.Trim) = 0 Then tempval(13) = Val(txtpercentin.Text.Trim) Else tempval(13) = Val(txtpercentfinal.Text.Trim)
            tempval(14) = Val(USERID)
            tempval(15) = Val(tempuserid)

            insert("tempkarigarissue", tempcol, tempval)
        Next
    End Sub

    Private Sub gridkarigar_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridkarigar.Enter

        find = InStr(cmbpart.Text.Trim, "(")
        findend = InStr(cmbpart.Text.Trim, ")")
        txtpart.Text = cmbpart.Text.Trim
        txtpart.SelectionStart = find
        txtpart.SelectionLength = findend - find - 1

        'deleting data from tempkarigarissue
        tempcmd = New OleDbCommand("delete from tempkarigarissue where mfg_no = " & Val(txtmfgno.Text) & " and mfg_part = '" & txtpart.SelectedText & "'", tempconn)
        If tempconn.State = ConnectionState.Open Then
            tempconn.Close()
        End If
        tempconn.Open()
        tempcmd.ExecuteNonQuery()

    End Sub

    Private Sub ToolStripdelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripdelete.Click
        Try
            If USERDELETE = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            If cmdedit.Enabled = False Then
                tempmsg = MsgBox("Delete Lot?", MsgBoxStyle.YesNo)
                If tempmsg = vbYes Then deletemfg()
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub deletemfg()
        Try

            'delete from itemstock
            tempcmd = New OleDbCommand("delete from itemstock where item_no = " & Val(txtmfgno.Text) & " and item_partno <> 0 ", tempconn)
            If tempconn.State = ConnectionState.Open Then
                tempconn.Close()
            End If
            tempconn.Open()
            tempcmd.ExecuteNonQuery()


            'delete from karigarissue
            tempcmd = New OleDbCommand("delete from karigarissue where mfg_no = " & Val(txtmfgno.Text), tempconn)
            If tempconn.State = ConnectionState.Open Then
                tempconn.Close()
            End If
            tempconn.Open()
            tempcmd.ExecuteNonQuery()


            'delete from lotfail
            tempcmd = New OleDbCommand("delete from lotfail where mfg_no = " & Val(txtmfgno.Text), tempconn)
            If tempconn.State = ConnectionState.Open Then
                tempconn.Close()
            End If
            tempconn.Open()
            tempcmd.ExecuteNonQuery()


            'delete from MFGDIRECTISSUE
            tempcmd = New OleDbCommand("delete from MFGDIRECTISSUE where mfg_no = " & Val(txtmfgno.Text), tempconn)
            If tempconn.State = ConnectionState.Open Then
                tempconn.Close()
            End If
            tempconn.Open()
            tempcmd.ExecuteNonQuery()



            'Update MeltingMaster
            tempcol(0) = "melting_mfg"
            tempval(0) = "False"
            tempcondition = " where melting_id = " & Val(txtlotno.Text)
            modify("MeltingMaster", tempcol, tempval, tempcondition)


            'delete from mfgdescription
            tempcmd = New OleDbCommand("delete from mfgdescription where mfg_no = " & Val(txtmfgno.Text), tempconn)
            If tempconn.State = ConnectionState.Open Then
                tempconn.Close()
            End If
            tempconn.Open()
            tempcmd.ExecuteNonQuery()


            'delete from MFGBARCODE
            tempcmd = New OleDbCommand("delete from MFGBARCODE where mfg_no = " & Val(txtmfgno.Text), tempconn)
            If tempconn.State = ConnectionState.Open Then
                tempconn.Close()
            End If
            tempconn.Open()
            tempcmd.ExecuteNonQuery()


            'delete from mfgmaster
            tempcmd = New OleDbCommand("delete from mfgmaster where mfg_no = " & Val(txtmfgno.Text), tempconn)
            If tempconn.State = ConnectionState.Open Then
                tempconn.Close()
            End If
            tempconn.Open()
            tempcmd.ExecuteNonQuery()


            'delete from mfgstock
            'deleting data from mfgdstock
            tempcmd = New OleDbCommand("delete from mfgstock where mfg_no = " & Val(txtmfgno.Text), tempconn)
            If tempconn.State = ConnectionState.Open Then
                tempconn.Close()
            End If
            tempconn.Open()
            tempcmd.ExecuteNonQuery()


            'delete from splitmaster
            tempcmd = New OleDbCommand("delete from splitmaster where mfg_no = " & Val(txtmfgno.Text), tempconn)
            If tempconn.State = ConnectionState.Open Then
                tempconn.Close()
            End If
            tempconn.Open()
            tempcmd.ExecuteNonQuery()

            MsgBox("Lot Deleted")
            clear()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try
            If PRINTDIALOG.ShowDialog = DialogResult.OK Then PRINTDOC.PrinterSettings = PRINTDIALOG.PrinterSettings Else Exit Sub

            Dim OBJPRINT As New VoucherDesign
            OBJPRINT.LOTNO = Val(txtlotno.Text)
            OBJPRINT.PARTNO = cmbpart.Text
            OBJPRINT.WT = Val(txtinput.Text)
            OBJPRINT.MELTING = Val(txtmelting.Text)
            OBJPRINT.ITEMNARR = txtnarration.Text.Trim
            OBJPRINT.MdiParent = MDIMain
            OBJPRINT.FRMSTRING = "MFGCHITTI"
            OBJPRINT.PRINTSETTING = PRINTDIALOG
            OBJPRINT.Show()
            OBJPRINT.Close()


            If ClientName <> "CNC" And ClientName <> "KHUSHALI" Then PRINTBARCODE()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtloss_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtloss.Validating
        Try
            'CHECK MAX LOSS FROM PROCESSMASTER 
            If Val(txtloss.Text.Trim) > 0 Then
                cmd = New OleDbCommand("select iif(isnull(PROCESS_MAXLOSS) = true, 0, PROCESS_MAXLOSS) from PROCESSMASTER where PROCESS_NAME  = '" & tempprocess(mfgprocessno(txtpart.SelectedText)) & "'", conn)
                If conn.State = ConnectionState.Open Then conn.Close()
                conn.Open()
                dr = cmd.ExecuteReader
                If dr.HasRows = True Then
                    dr.Read()
                    If Val(dr(0)) > 0 And Val(txtloss.Text.Trim) > Format((Val(dr(0)) * Val(txtoutput.Text.Trim)) / 100, "0.000") Then
                        Dim TMSG As Integer = MsgBox("Loss is Greater, Maximum " & Format((Val(dr(0)) * Val(txtoutput.Text.Trim)) / 100, "0.000") & " Allowed, Wish to Proceed?", MsgBoxStyle.YesNo)
                        If TMSG = vbNo Then
                            e.Cancel = True
                            Exit Sub
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Manufacturing_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'MANUFACTURING'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            Dim j As Integer 'for loop
            Dim TEMPD As Date   'FOR DATE FROM GRID

            'getting processes in array
            cmd = New OleDbCommand("select * from processmaster ORDER BY PROCESS_NO", conn)
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
            conn.Open()
            dr = cmd.ExecuteReader
            If dr.HasRows = True Then
                i = 1
                While (dr.Read)
                    tempprocess(i) = caps(dr(2).ToString)
                    tempprocessno(i) = dr(1).ToString
                    tempprocessloss(i) = dr(5).ToString
                    tempprocessvaccum(i) = dr(6).ToString
                    tempprocesskarigar(i) = dr(7).ToString
                    tempprocessexcess(i) = dr(8).ToString
                    i = i + 1
                End While
            Else
                MsgBox("Process Not Added!, Please Add process from Process Master", MsgBoxStyle.Critical)
                Me.Close()
                Exit Sub
            End If

            clear()


            tempcondition = ""
            fillgridcmb("itemmaster", "item_code", cmbitemname, tempcondition)
            fillgridcmb("ledgermaster", "ledger_code", cmbcode, tempcondition)

            If cmdedit.Enabled = True Then edit = False
            If cmdedit.Enabled = False Then edit = True

            If edit = True Then

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If


                'FIRST DELETE TEMPKARIGARISSUE THEN RE INSERT THE DATA
                'deleting data from tempkarigarissue
                tempcmd = New OleDbCommand("delete from tempkarigarissue WHERE MFG_NO = " & Val(tempmfgno), tempconn)
                If tempconn.State = ConnectionState.Open Then
                    tempconn.Close()
                End If
                tempconn.Open()
                tempcmd.ExecuteNonQuery()


                'adding in tempkarigarissue
                cmd = New OleDbCommand("insert into tempkarigarissue select * from karigarissue where mfg_no = " & tempmfgno, conn)
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
                conn.Open()
                cmd.ExecuteNonQuery()


                cmd = New OleDbCommand("select * from mfgmaster where mfg_no= " & Val(tempmfgno), conn)
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
                conn.Open()
                dr = cmd.ExecuteReader
                While (dr.Read())

                    txtlotno.Enabled = False
                    TXTREFNO.Enabled = True
                    TXTREFNO.Text = dr("MFG_REFNO")
                    groupgrid.Enabled = True
                    groupmfg.Enabled = True

                    txtmfgno.Text = Val(dr(0).ToString)
                    mfgdate.Value = dr(1)
                    txtlotno.Text = Val(dr(2).ToString)
                    txtmelting.Text = Format(Val(dr(3).ToString), "0.00")
                    splitno = Val(dr(4).ToString)
                    TXTREMARKS.Text = dr("MFG_REMARKS").ToString
                    TXTBRIEF.Text = dr("MFG_BRIEF").ToString

                    For j = 1 To Val(dr(4).ToString)
                        partname(j) = 0
                    Next


                    'getting data from MFGBARCODE
                    tempcmd = New OleDbCommand("select MFG_PARTNO AS PARTNO, MFG_BARCODE AS BARCODE from MFGBARCODE where mfg_no = " & Val(txtmfgno.Text) & " order by mfg_partno", tempconn)
                    If tempconn.State = ConnectionState.Open Then
                        tempconn.Close()
                    End If
                    tempconn.Open()
                    tempdr = tempcmd.ExecuteReader
                    If tempdr.HasRows = True Then
                        While (tempdr.Read())
                            MFGBARCODE(Val(tempdr("PARTNO"))) = tempdr("BARCODE").ToString
                        End While
                    End If



                    'getting data from mfgstock
                    tempcmd = New OleDbCommand("select * from mfgstock where mfg_no = " & Val(txtmfgno.Text) & " order by mfg_partno", tempconn)
                    If tempconn.State = ConnectionState.Open Then
                        tempconn.Close()
                    End If
                    tempconn.Open()
                    tempdr = tempcmd.ExecuteReader
                    If tempdr.HasRows = True Then
                        While (tempdr.Read())
                            partname(Val(tempdr(4).ToString)) = Val(tempdr(2).ToString)
                            tempnarration(Val(tempdr(4).ToString)) = tempdr(6).ToString
                            mfgprocessno(Val(tempdr(4).ToString)) = Val(tempprocessno(Array.IndexOf(tempprocess, tempdr(1).ToString)))
                            mfgitemname(Val(tempdr(4).ToString)) = ""
                            percentinput(Val(tempdr(4).ToString)) = Val(tempdr(5).ToString)
                            lotfail(Val(tempdr(4).ToString)) = tempdr(7).ToString
                            MFGORDERNO(Val(tempdr(4).ToString)) = tempdr(8).ToString
                            LOTFAILMERGED(Val(tempdr(4).ToString)) = tempdr(9).ToString
                        End While
                    End If


                    'getting data from ITEMstock
                    tempcmd = New OleDbCommand("SELECT itemstock.item_grosswt, ItemMaster.item_name, itemstock.item_purity, itemstock.item_partno AS PARTNO, ITEMSTOCK.ITEM_ORDERNO AS ORDERNO  FROM ItemMaster RIGHT OUTER JOIN itemstock ON ItemMaster.item_id = itemstock.item_id where item_no = " & Val(txtmfgno.Text) & " and item_partno <> 0 order by item_partno", tempconn)
                    If tempconn.State = ConnectionState.Open Then
                        tempconn.Close()
                    End If
                    tempconn.Open()
                    tempdr = tempcmd.ExecuteReader
                    If tempdr.HasRows = True Then
                        While (tempdr.Read())
                            partname(Val(tempdr("PARTNO").ToString)) = Val(tempdr(0).ToString)
                            tempnarration(Val(tempdr("PARTNO").ToString)) = tempdr(1).ToString
                            'mfgprocessno(Val(tempdr(3).ToString)) = Val(tempprocessno(Array.IndexOf(tempprocess, Nothing)))
                            mfgprocessno(Val(tempdr("PARTNO").ToString)) = tempprocessno(Array.IndexOf(tempprocess, "Final")) + 1

                            mfgitemname(Val(tempdr("PARTNO").ToString)) = tempdr(1).ToString
                            percentinput(Val(tempdr("PARTNO").ToString)) = Val(tempdr(2).ToString)
                            lotfail(Val(tempdr("PARTNO").ToString)) = False
                            MFGORDERNO(Val(tempdr("PARTNO").ToString)) = tempdr("ORDERNO").ToString
                            LOTFAILMERGED(Val(tempdr("PARTNO").ToString)) = False
                        End While
                    End If


                    fillcmbpart()
                    If temppartno = Nothing Then temppartno = "Part(1)"
                    If temppartno = "" Then temppartno = "Part(1)"
                    cmbpart.Text = temppartno
                    cmbpart_Validated(sender, e)


                    tempcmd = New OleDbCommand("select * from mfgdescription where mfg_no = " & Val(txtmfgno.Text) & " order by mfg_lineno", tempconn)
                    If tempconn.State = ConnectionState.Open Then
                        tempconn.Close()
                    End If
                    tempconn.Open()
                    tempdr = tempcmd.ExecuteReader
                    If tempdr.HasRows = True Then
                        While (tempdr.Read())
                            TEMPD = tempdr(10).ToString
                            gridmfg.Rows.Add(tempdr(1).ToString, tempdr(2).ToString, tempdr(3).ToString, Val(tempdr(4).ToString), Val(tempdr(5).ToString), Val(tempdr(6).ToString), Val(tempdr(7).ToString), Val(tempdr(8).ToString), Val(tempdr(9).ToString), Format(TEMPD, "dd/MM/yyyy"), Val(tempdr(11).ToString), Val(tempdr(12).ToString), Val(tempdr(13).ToString), Val(tempdr(14).ToString), Val(tempdr(15).ToString), Val(tempdr("MFG_IRONWT")), Val(tempdr("MFG_IRONRETWT")))
                        End While
                        gridmfg.FirstDisplayedScrollingRowIndex = gridmfg.RowCount - 1
                    End If


                    'NO NEED FOR FILLING GRID COZ IT IS BEEN FILLED ON CMBPART_VALIDATED
                    'filling gridkarigar
                    'tempcmd = New OleDbCommand("SELECT ItemMaster.item_code, karigarissue.mfg_purity, karigarissue.mfg_grosswt, karigarissue.mfg_nettwt, ledgermaster.ledger_name, karigarissue.mfg_labour FROM (karigarissue LEFT JOIN ItemMaster ON karigarissue.mfg_itemid = ItemMaster.item_id) LEFT JOIN ledgermaster ON karigarissue.mfg_ledgerid = ledgermaster.ledger_id where mfg_no = " & Val(txtmfgno.Text), tempconn)
                    'If tempconn.State = ConnectionState.Open Then
                    '    tempconn.Close()
                    'End If
                    'tempconn.Open()
                    'tempdr = tempcmd.ExecuteReader
                    'If tempdr.HasRows = True Then
                    '    gridkarigar.CurrentCell = gridkarigar.Rows(0).Cells(1)
                    '    While (tempdr.Read())
                    '        gridkarigar.Rows.Add(uppercase(tempdr(0).ToString), Val(tempdr(1).ToString), Val(tempdr(2).ToString), Val(tempdr(3).ToString), uppercase(tempdr(4).ToString), Val(tempdr(5).ToString))
                    '    End While
                    'End If


                    'adding values in tempsplit from splitmaster table
                    tempcmd = New OleDbCommand("INSERT INTO tempsplit SELECT * FROM(splitmaster) where mfg_no = " & Val(txtmfgno.Text), tempconn)
                    If tempconn.State = ConnectionState.Open Then
                        tempconn.Close()
                    End If
                    tempconn.Open()
                    tempcmd.ExecuteNonQuery()


                    If temppartno = Nothing Then temppartno = "Part(1)"
                    If temppartno = "" Then temppartno = "Part(1)"
                    cmbpart.Text = temppartno
                    cmbpart_Validated(sender, e)

                End While

            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridkarigar_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridkarigar.Validated
        txtoutput.Focus()
    End Sub

    Private Sub TXTREFNO_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTREFNO.Validating
        If TXTREFNO.Text.Trim <> "" Then

            cmd = New OleDbCommand("select melting_reqmelting,melting_output,MELTING_NARRATION AS REMARKS, MELTING_ID AS LOTNO from meltingmaster where melting_REFNO = '" & TXTREFNO.Text.Trim & "' and melting_mfg =" & False, conn)
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
            conn.Open()
            dr = cmd.ExecuteReader
            If dr.HasRows = True Then

                dr.Read()
                txtlotno.Enabled = False
                groupgrid.Enabled = True
                groupmfg.Enabled = True
                txtlotno.Text = Format(Val(dr("LOTNO").ToString), "0.000")
                txtmelting.Text = Format(Val(dr(0).ToString), "0.000")
                txtinput.Text = Format(Val(dr(1).ToString), "0.000")
                txtpercentin.Text = Format(Val(dr(0).ToString), "0.00")
                percentinput(splitno) = Format(Val(txtpercentin.Text), "0.00")
                partname(splitno) = Val(txtinput.Text)
                TXTBRIEF.Text = dr("REMARKS")
                fillcmbpart()

            Else

                'checking in mfgmaster and opening in edit moDe 
                cmd = New OleDbCommand("select mfg_no from mfgmaster where mfg_REFNO = '" & TXTREFNO.Text.Trim & "'", conn)
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
                conn.Open()
                dr = cmd.ExecuteReader
                If dr.HasRows = True Then

                    dr.Read()
                    tempmfgno = dr(0).ToString
                    cmdedit.Enabled = False
                    edit = True
                    Manufacturing_Load(sender, e)
                    Exit Sub

                Else
                    MsgBox("Invalid Lot No", MsgBoxStyle.Critical)
                    e.Cancel = True
                End If
            End If
        End If

    End Sub

    Private Sub TXTORDERNO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TXTORDERNO.KeyDown
        Try
            If e.KeyCode = Keys.F1 Then
                Dim OBJORDER As New SelectOrder
                OBJORDER.FRMSTRING = "RECEIPT"
                OBJORDER.ShowDialog()

                Dim DT As DataTable = OBJORDER.DTORDER
                If DT.Rows.Count > 0 Then
                    TXTNAME.Text = DT.Rows(0).Item("NAME")
                    TXTORDERNO.Text = DT.Rows(0).Item("SRNO")
                    TXTITEMNAME.Text = DT.Rows(0).Item("ITEMNAME")
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTORDERNO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTORDERNO.KeyPress
        numkeypress(e, TXTORDERNO, Me)
    End Sub

    Private Sub TXTORDERNO_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTORDERNO.Validated
        Try
            If Val(TXTORDERNO.Text.Trim) > 0 Then
                'GET ORDER DETAILS
                dt = New DataTable
                If conn.State = ConnectionState.Open Then conn.Close()
                conn.Open()
                cmd = New OleDbCommand(" SELECT 0 AS CHK, OrderMaster.ORDER_SRNO AS SRNO, OrderMaster.ORDER_NO AS ORDERNO, OrderMaster.ORDER_DATE AS [DATE], OrderMaster.ORDER_DELDATE AS DELDATE ,  ledgermaster.ledger_code AS [NAME], ItemMaster.item_code AS ITEMNAME, OrderMaster.ORDER_GOLDWT AS GOLDWT, OrderMaster.ORDER_CTWT AS CTWT, OrderMaster.ORDER_SIZE AS ORDERSIZE, OrderMaster.ORDER_REMARKS AS [REMARKS], OrderMaster.ORDER_CLOSE AS [CLOSED], OrderMaster.ORDER_DONE AS [DONE] FROM (OrderMaster INNER JOIN ledgermaster ON OrderMaster.ORDER_LEDGERID = ledgermaster.ledger_id) INNER JOIN ItemMaster ON OrderMaster.ORDER_ITEMID = ItemMaster.item_id WHERE ORDERMASTER.ORDER_CLOSE = FALSE AND ORDERMASTER.ORDER_DONE = FALSE  AND ORDER_SRNO = " & Val(TXTORDERNO.Text.Trim) & " order by ORDER_SRNO ", conn)
                da = New OleDbDataAdapter(cmd)
                da.Fill(dt)
                If dt.Rows.Count > 0 Then
                    TXTNAME.Text = dt.Rows(0).Item("NAME")
                    TXTITEMNAME.Text = dt.Rows(0).Item("ITEMNAME")
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTIRON_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TXTIRON.Validating
        Try
            If Val(TXTIRON.Text.Trim) <> 0 Then txtoutput.Text = Format(Val(txtinput.Text.Trim) + Val(TXTIRON.Text.Trim) - Val(TXTIRONRETWT.Text.Trim), "0.000")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTORDERNO_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTORDERNO.Validating
        If Val(TXTORDERNO.Text.Trim) > 0 Then
            find = InStr(cmbpart.Text.Trim, "(")
            findend = InStr(cmbpart.Text.Trim, ")")
            txtpart.Text = cmbpart.Text.Trim
            txtpart.SelectionStart = find
            txtpart.SelectionLength = findend - find - 1

            MFGORDERNO(txtpart.SelectedText) = TXTORDERNO.Text.Trim
        ElseIf cmbpart.Text.Trim <> "" Then
            find = InStr(cmbpart.Text.Trim, "(")
            findend = InStr(cmbpart.Text.Trim, ")")
            txtpart.Text = cmbpart.Text.Trim
            txtpart.SelectionStart = find
            txtpart.SelectionLength = findend - find - 1

            If MFGORDERNO(txtpart.SelectedText) > 0 Then
                Dim TEMPMSG As Integer = MsgBox("Remove Order Tagging?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbYes Then
                    MFGORDERNO(txtpart.SelectedText) = 0
                    TXTNAME.Clear()
                    TXTITEMNAME.Clear()
                End If
            End If

        End If
    End Sub

    Private Sub TXTBARCODE_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTBARCODE.TextChanged
        Try
            If TXTBARCODE.Text.Trim.Length > 0 And edit = False Then

                dt = New DataTable
                If tempconn.State = ConnectionState.Open Then
                    tempconn.Close()
                End If
                tempconn.Open()

                tempcmd = New OleDbCommand("SELECT MFG_NO AS MFGNO, MFG_PARTNO AS PARTNO FROM MFGBARCODE WHERE MFG_BARCODE = '" & TXTBARCODE.Text.Trim & "'", tempconn)
                da = New OleDbDataAdapter(tempcmd)
                da.Fill(dt)

                If dt.Rows.Count > 0 Then
                    tempmfgno = Val(dt.Rows(0).Item("MFGNO"))
                    temppartno = "Part(" & Val(dt.Rows(0).Item("PARTNO")) & ")"
                    cmdedit.Enabled = False
                    edit = True
                    Call Manufacturing_Load(sender, e)
                    txtoutput.Focus()
                End If
            End If


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TOOLBARCODE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLBARCODE.Click
        PRINTBARCODE()
    End Sub
End Class