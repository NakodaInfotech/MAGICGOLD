
Imports System.Data.OleDb

Public Class ACCOUNTMASTER

    Dim TEMPCODE As String
    Dim TEMPLEDGERID As Integer
    Public TEMPACCNAME As String = ""
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public EDIT As Boolean = False

    Sub clear()
        'clearing array
        For i = 1 To 100
            tempcol(i) = ""
            tempval(i) = ""
        Next

        txtname.Clear()
        txtcode.Clear()
        txtopbalrs.Text = "0"
        txtopbalwt.Text = "0"
        TXTOPBALGROSSWT.Text = 0
        cmbdrcrrs.SelectedIndex = 0
        cmbdrcrwt.SelectedIndex = 0
        CMBDRCRGROSSWT.SelectedIndex = 0
        cmbgroup.Text = ""
        GroupBox1.Enabled = True
        txtadd.Clear()
        txtshipadd.Clear()
        txtadd1.Clear()
        txtadd2.Clear()
        cmbarea.Text = ""
        cmbcity.Text = ""
        txtzipcode.Clear()
        cmbstate.Text = ""
        cmbcountry.Text = ""
        txtstd.Clear()
        txtresino.Clear()
        txtaltno.Clear()
        txttel1.Clear()
        txtcrdays.Clear()
        txtmobile.Clear()
        txtfax.Clear()
        txtwebsite.Clear()
        txtemail.Clear()
        txtcrlimit.Text = "0"
        txtpanno.Clear()
        TXTSALARY.Clear()
        txtcstno.Clear()
        txttinno.Clear()
        txtstno.Clear()
        txtvatno.Clear()
        txtkstno.Clear()
        txtnotes.Clear()
        CHKLOSS.CheckState = CheckState.Unchecked
        CHKKARIGAR.CheckState = CheckState.Unchecked

    End Sub

    Private Sub txttel1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtshipadd.GotFocus, txtresino.GotFocus, txtaltno.GotFocus, txtstd.GotFocus, txtwebsite.GotFocus, txtvatno.GotFocus, txtstno.GotFocus, txtadd.GotFocus, txtadd1.GotFocus, txtadd2.GotFocus, txtzipcode.GotFocus, txtkstno.GotFocus, txtcrdays.GotFocus, txttel1.GotFocus, txtfax.GotFocus, txtmobile.GotFocus, txtcode.GotFocus, cmbgroup.GotFocus, txttinno.GotFocus, txtpanno.GotFocus, txtnotes.GotFocus, TXTSALARY.GotFocus, txtemail.GotFocus, txtcstno.GotFocus, txtname.GotFocus
        Dim OBJ As Object = sender
        OBJ.SelectAll()
    End Sub

    Private Sub txttel1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtmobile.KeyPress, txtfax.KeyPress, txttel1.KeyPress, txtcrdays.KeyPress
        numkeypress(e, sender, Me)
    End Sub

    Private Sub txtcrlimit_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcrlimit.KeyPress
        numdot(e, txtcrlimit, Me)
    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True

        If ISMASTER = False Then bln = False

        If txtname.Text.Trim.Length = 0 Then
            EP.SetError(txtname, "Fill Name")
            bln = False
        End If

        If txtcode.Text.Trim.Length = 0 Then
            EP.SetError(txtcode, "Fill Code")
            bln = False
        End If

        If cmbgroup.Text.Trim.Length = 0 Then
            EP.SetError(cmbgroup, "Select Group")
            bln = False
        End If

        Return bln
    End Function

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click

        Ep.Clear()
        If Not errorvalid() Then
            Exit Sub
        End If

        If txtname.Text.Trim <> "" And cmbgroup.Text.Trim <> "" Then
            If cmdedit.Enabled = False Then edit = True
            If cmdedit.Enabled = True Then edit = False

            duplicate = False
            If (edit = False) Or (edit = True And LCase(tempname) <> LCase(txtname.Text.Trim)) Then
                tempcondition = ""
                duplication("ledgermaster", "ledger_name", Trim(txtname.Text.Trim), tempcondition)
            End If
            If duplicate = False Then

                tempcol(0) = "ledger_name"
                tempcol(1) = "ledger_code"
                tempcol(2) = "ledger_groupid"
                tempcol(3) = "ledger_opbalrs"
                tempcol(4) = "ledger_drcrrs"
                tempcol(5) = "ledger_opbalwt"
                tempcol(6) = "ledger_drcrwt"
                tempcol(7) = "ledger_add1"
                tempcol(8) = "ledger_add2"
                tempcol(9) = "ledger_areaid"
                tempcol(10) = "ledger_cityid"
                tempcol(11) = "ledger_zipcode"
                tempcol(12) = "ledger_stateid"
                tempcol(13) = "ledger_countryid"
                tempcol(14) = "ledger_std"
                tempcol(15) = "ledger_resi"
                tempcol(16) = "ledger_altno"
                tempcol(17) = "ledger_tel1"
                tempcol(18) = "ledger_mobile"
                tempcol(19) = "ledger_fax"
                tempcol(20) = "ledger_website"
                tempcol(21) = "ledger_email"
                tempcol(22) = "ledger_crdays"
                tempcol(23) = "ledger_crlimit"
                tempcol(24) = "ledger_panno"
                tempcol(25) = "LEDGER_SALARY"
                tempcol(26) = "ledger_cstno"
                tempcol(27) = "ledger_tinno"
                tempcol(28) = "ledger_stno"
                tempcol(29) = "ledger_vatno"
                tempcol(30) = "ledger_kstno"
                tempcol(31) = "ledger_add"
                tempcol(32) = "ledger_shipadd"
                tempcol(33) = "ledger_notes"
                tempcol(34) = "ledger_userid"
                tempcol(35) = "LEDGER_LOSSAC"
                tempcol(36) = "LEDGER_KARIGAR"
                tempcol(37) = "LEDGER_OPBALGROSSWT"
                tempcol(38) = "LEDGER_DRCRGROSSWT"


                tempval(0) = "'" & txtname.Text.Trim & "'"
                tempval(1) = "'" & txtcode.Text.Trim & "'"

                'getting groupid
                tempcmd = New OleDbCommand("select group_id from groupmaster where group_name = '" & cmbgroup.Text.Trim & "'", tempconn)
                If tempconn.State = ConnectionState.Open Then
                    tempconn.Close()
                End If
                tempconn.Open()
                tempdr = tempcmd.ExecuteReader
                If tempdr.HasRows Then
                    tempdr.Read()
                    tempval(2) = tempdr(0)
                Else
                    tempval(2) = "0"
                End If
                tempconn.Close()
                tempdr.Close()


                tempval(3) = Val(txtopbalrs.Text)
                tempval(4) = "'" & cmbdrcrrs.Text.Trim & "'"
                tempval(5) = Val(txtopbalwt.Text)
                tempval(6) = "'" & cmbdrcrwt.Text.Trim & "'"

                tempval(7) = "'" & txtadd1.Text.Trim & "'"
                tempval(8) = "'" & txtadd2.Text.Trim & "'"

                'getting area
                tempcmd = New OleDbCommand("select area_id from areamaster where area_name = '" & cmbarea.Text.Trim & "'", tempconn)
                If tempconn.State = ConnectionState.Open Then
                    tempconn.Close()
                End If
                tempconn.Open()
                tempdr = tempcmd.ExecuteReader
                If tempdr.HasRows Then
                    tempdr.Read()
                    tempval(9) = tempdr(0)
                Else
                    tempval(9) = "0"
                End If
                tempconn.Close()
                tempdr.Close()


                'getting city
                tempcmd = New OleDbCommand("select city_id from citymaster where city_name = '" & cmbcity.Text.Trim & "'", tempconn)
                If tempconn.State = ConnectionState.Open Then
                    tempconn.Close()
                End If
                tempconn.Open()
                tempdr = tempcmd.ExecuteReader
                If tempdr.HasRows Then
                    tempdr.Read()
                    tempval(10) = tempdr(0)
                Else
                    tempval(10) = "0"
                End If
                tempconn.Close()
                tempdr.Close()


                'getting state
                tempcmd = New OleDbCommand("select state_id from statemaster where state_name = '" & cmbstate.Text.Trim & "'", tempconn)
                If tempconn.State = ConnectionState.Open Then
                    tempconn.Close()
                End If
                tempconn.Open()
                tempdr = tempcmd.ExecuteReader
                If tempdr.HasRows Then
                    tempdr.Read()
                    tempval(11) = tempdr(0)
                Else
                    tempval(11) = "0"
                End If
                tempconn.Close()
                tempdr.Close()


                'getting country
                tempcmd = New OleDbCommand("select country_id from countrymaster where country_name  = '" & cmbcountry.Text.Trim & "'", tempconn)
                If tempconn.State = ConnectionState.Open Then
                    tempconn.Close()
                End If
                tempconn.Open()
                tempdr = tempcmd.ExecuteReader
                If tempdr.HasRows Then
                    tempdr.Read()
                    tempval(12) = tempdr(0)
                Else
                    tempval(12) = "0"
                End If
                tempconn.Close()
                tempdr.Close()


                tempval(13) = "'" & Val(txtzipcode.Text) & "'"
                tempval(14) = Val(txtstd.Text.Trim)
                tempval(15) = Val(txtresino.Text.Trim)
                tempval(16) = Val(txtaltno.Text.Trim)
                tempval(17) = Val(txttel1.Text.Trim)
                tempval(18) = Val(txtmobile.Text.Trim)
                tempval(19) = Val(txtfax.Text.Trim)
                tempval(20) = "'" & txtwebsite.Text.Trim & "'"
                tempval(21) = "'" & txtemail.Text.Trim & "'"
                tempval(22) = Val(txtcrdays.Text)
                tempval(23) = Val(txtcrlimit.Text)
                tempval(24) = "'" & txtpanno.Text.Trim & "'"
                tempval(25) = Val(TXTSALARY.Text.Trim)
                tempval(26) = "'" & txtcstno.Text.Trim & "'"
                tempval(27) = "'" & txttinno.Text.Trim & "'"
                tempval(28) = "'" & txtstno.Text.Trim & "'"
                tempval(29) = "'" & txtvatno.Text.Trim & "'"
                tempval(30) = "'" & txtkstno.Text.Trim & "'"
                tempval(31) = "'" & txtadd.Text.Trim & "'"
                tempval(32) = "'" & txtshipadd.Text.Trim & "'"
                tempval(33) = "'" & txtnotes.Text.Trim & "'"
                tempval(34) = Val(tempuserid)
                tempval(35) = CHKLOSS.Checked
                tempval(36) = CHKKARIGAR.Checked
                tempval(37) = Val(TXTOPBALGROSSWT.Text.Trim)
                tempval(38) = "'" & CMBDRCRGROSSWT.Text.Trim & "'"


                If cmdedit.Enabled = True Then edit = False
                If cmdedit.Enabled = False Then edit = True

                tempcondition = " where ledger_name = '" & tempname & "'"

                If edit = False Then

                    If USERADD = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If

                    tempcol(35) = "ledger_settlement"
                    tempval(35) = "'01/01/2006'"
                    insert("ledgermaster", tempcol, tempval)
                    MessageBox.Show("Account Added")
                ElseIf edit = True Then

                    If USEREDIT = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If

                    modify("ledgermaster", tempcol, tempval, tempcondition)


                    'UPDATE IN ALL TABLES
                    For i = 0 To 50
                        tempcol(i) = ""
                        tempval(i) = ""
                    Next
                    tempcol(0) = "ACCOUNT_LEDGERCODE"
                    tempval(0) = "'" & txtcode.Text.Trim & "'"
                    modify("ACCOUNTMASTER", tempcol, tempval, " WHERE ACCOUNT_LEDGERCODE = '" & tempname & "'")

                    MessageBox.Show("Account Updated")
                    Me.Close()
                End If

                clear()
                txtname.Focus()

            Else
                MsgBox("Company Name already Exists")
            End If

        Else
            MsgBox("Enter Valid Details")
        End If
        txtname.Focus()
    End Sub

    Private Sub cmdexit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        If txtname.Text.Trim <> "" And chkchange.CheckState = CheckState.Checked Then
            tempmsg = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
            If tempmsg = vbYes Then cmdok_Click(sender, e)
        End If
        Me.Close()
    End Sub

    Private Sub txtopbal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtopbalrs.KeyPress, TXTOPBALGROSSWT.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub

    Private Sub txtcmpname_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtname.Validated
        txtname.Text = uppercase(txtname.Text.Trim)
    End Sub

    Private Sub txtcusname_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcode.Validated
        txtcode.Text = uppercase(txtcode.Text.Trim)
    End Sub

    Private Sub cmbgroup_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbgroup.TextChanged
        cmbtextchanged(sender, Me, cmbgroup)
    End Sub

    Private Sub cmbgroup_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbgroup.Validated
        'If cmbgroup.Text.Trim = "Bank A/C" Or cmbgroup.Text.Trim = "Bank OD A/C" Or cmbgroup.Text.Trim = "Branch/Division" Or cmbgroup.Text.Trim = "Capital A/C" Or cmbgroup.Text.Trim = "Loans & Advances" Or cmbgroup.Text.Trim = "Loans" Or cmbgroup.Text.Trim = "Reserves & Surplus" Or cmbgroup.Text.Trim = "Retained Earnings" Or cmbgroup.Text.Trim = "Secured Loans" Or cmbgroup.Text.Trim = "Sundry Creditors" Or cmbgroup.Text.Trim = "Sundry Debtors" Or cmbgroup.Text.Trim = "Unsecured Loans" Then
        '    GroupBox1.Enabled = True
        'Else
        '    GroupBox1.Enabled = False
        'End If
    End Sub

    Private Sub txtadd1_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtadd1.Validated
        txtadd1.Text = caps(txtadd1.Text.Trim)
    End Sub

    Private Sub txtadd2_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtadd2.Validated
        txtadd2.Text = caps(txtadd2.Text.Trim)
    End Sub

    Private Sub cmbarea_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbarea.GotFocus
        cmbarea.SelectAll()
        tempcondition = ""
        fillcmb(cmbarea, "area_name", "areamaster", tempcondition)
        cmbarea.SelectAll()
    End Sub

    Private Sub cmbarea_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbarea.TextChanged
        cmbtextchanged(sender, Me, cmbarea)
    End Sub

    Private Sub cmbarea_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbarea.Validated
        cmbarea.Text = caps(cmbarea.Text.Trim)
        'If cmbarea.Text.Trim <> "" Then txtadd.Text = txtcmpname.Text.Trim & vbNewLine & txtcusname.Text.Trim & vbNewLine & txtadd1.Text.Trim & vbNewLine & txtadd2.Text.Trim & vbNewLine & cmbarea.Text.Trim & ", " & cmbcity.Text.Trim & ": " & txtzipcode.Text.Trim & vbNewLine & cmbstate.Text.Trim & ", " & cmbcountry.Text.Trim
        If cmbarea.Text.Trim <> "" Then

            If tempmsg1 = False Then
                cmd = New OleDbCommand("select area_id from areamaster where area_name = '" & cmbarea.Text.Trim & "'", conn)
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
                conn.Open()
                dr = cmd.ExecuteReader
                If dr.HasRows = False Then
                    tempmsg = MsgBox("Area Not Present, Add New?", MsgBoxStyle.YesNo)
                    If tempmsg = vbYes Then
                        tempmsg1 = True

                        tempcol(0) = "area_name"
                        tempcol(1) = "area_userid"

                        tempval(0) = "'" & cmbarea.Text.Trim & "'"
                        tempval(1) = tempuserid

                        insert("areamaster", tempcol, tempval)
                        tempmsg1 = False
                    Else
                        cmbarea.Focus()
                    End If
                Else
                    tempmsg1 = False
                End If
            End If

        End If
    End Sub

    Private Sub cmbcity_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbcity.GotFocus
        cmbcity.SelectAll()
        tempcondition = ""
        fillcmb(cmbcity, "city_name", "citymaster", tempcondition)
        cmbcity.SelectAll()
    End Sub

    Private Sub cmbcity_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbcity.TextChanged
        cmbtextchanged(sender, Me, cmbcity)
    End Sub

    Private Sub cmbcity_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbcity.Validated
        cmbcity.Text = caps(cmbcity.Text.Trim)
        'If cmbcity.Text.Trim <> "" Then txtadd.Text = txtcmpname.Text.Trim & vbNewLine & txtcusname.Text.Trim & vbNewLine & txtadd1.Text.Trim & vbNewLine & txtadd2.Text.Trim & vbNewLine & cmbarea.Text.Trim & ", " & cmbcity.Text.Trim & ": " & txtzipcode.Text.Trim & vbNewLine & cmbstate.Text.Trim & ", " & cmbcountry.Text.Trim
        If cmbcity.Text.Trim <> "" Then

            If tempmsg1 = False Then
                cmd = New OleDbCommand("select city_id from citymaster where city_name = '" & cmbcity.Text.Trim & "'", conn)
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
                conn.Open()
                dr = cmd.ExecuteReader
                If dr.HasRows = False Then
                    tempmsg = MsgBox("City Not Present, Add New?", MsgBoxStyle.YesNo)
                    If tempmsg = vbYes Then
                        tempmsg1 = True

                        tempcol(0) = "city_name"
                        tempcol(1) = "city_userid"

                        tempval(0) = "'" & cmbcity.Text.Trim & "'"
                        tempval(1) = tempuserid

                        insert("citymaster", tempcol, tempval)
                        tempmsg1 = False
                    Else
                        cmbcity.Focus()
                    End If
                Else
                    tempmsg1 = False
                End If
            End If
        End If
    End Sub

    Private Sub cmbcountry_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbcountry.GotFocus
        cmbcountry.SelectAll()
        tempcondition = ""
        fillcmb(cmbcity, "country_name", "countrymaster", tempcondition)
        cmbcountry.SelectAll()
    End Sub

    Private Sub cmbcountry_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbcountry.TextChanged
        cmbtextchanged(sender, Me, cmbcountry)
    End Sub

    Private Sub cmbcountry_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbcountry.Validated
        cmbcountry.Text = caps(cmbcountry.Text.Trim)
        'If cmbcountry.Text.Trim <> "" Then txtadd.Text = txtcmpname.Text.Trim & vbNewLine & txtcusname.Text.Trim & vbNewLine & txtadd1.Text.Trim & vbNewLine & txtadd2.Text.Trim & vbNewLine & cmbarea.Text.Trim & ", " & cmbcity.Text.Trim & ": " & txtzipcode.Text.Trim & vbNewLine & cmbstate.Text.Trim & ", " & cmbcountry.Text.Trim
        If cmbcountry.Text.Trim <> "" Then

            If tempmsg1 = False Then
                cmd = New OleDbCommand("select country_id from countrymaster where country_name = '" & cmbcountry.Text.Trim & "'", conn)
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
                conn.Open()
                dr = cmd.ExecuteReader
                If dr.HasRows = False Then
                    tempmsg = MsgBox("Country Not Present, Add New?", MsgBoxStyle.YesNo)
                    If tempmsg = vbYes Then
                        tempmsg1 = True

                        tempcol(0) = "country_name"
                        tempcol(1) = "country_userid"

                        tempval(0) = "'" & cmbcountry.Text.Trim & "'"
                        tempval(1) = tempuserid

                        insert("countrymaster", tempcol, tempval)
                        tempmsg1 = False
                    Else
                        cmbcountry.Focus()
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub cmbstate_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbstate.GotFocus
        cmbstate.SelectAll()
        tempcondition = ""
        fillcmb(cmbcity, "state_name", "statemaster", tempcondition)
        cmbstate.SelectAll()
    End Sub

    Private Sub cmbstate_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbstate.TextChanged
        cmbtextchanged(sender, Me, cmbstate)
    End Sub

    Private Sub cmbstate_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbstate.Validated
        cmbstate.Text = caps(cmbstate.Text.Trim)
        'If cmbstate.Text.Trim <> "" Then txtadd.Text = txtcmpname.Text.Trim & vbNewLine & txtcusname.Text.Trim & vbNewLine & txtadd1.Text.Trim & vbNewLine & txtadd2.Text.Trim & vbNewLine & cmbarea.Text.Trim & ", " & cmbcity.Text.Trim & ": " & txtzipcode.Text.Trim & vbNewLine & cmbstate.Text.Trim & ", " & cmbcountry.Text.Trim
        If cmbstate.Text.Trim <> "" Then

            If tempmsg1 = False Then
                cmd = New OleDbCommand("select state_id from statemaster where state_name = '" & cmbstate.Text.Trim & "'", conn)
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
                conn.Open()
                dr = cmd.ExecuteReader
                If dr.HasRows = False Then
                    tempmsg = MsgBox("State Not Present, Add New?", MsgBoxStyle.YesNo)
                    If tempmsg = vbYes Then
                        tempmsg1 = True

                        tempcol(0) = "State_name"
                        tempcol(1) = "State_userid"

                        tempval(0) = "'" & cmbstate.Text.Trim & "'"
                        tempval(1) = tempuserid

                        insert("Statemaster", tempcol, tempval)
                        tempmsg1 = False
                    Else
                        cmbstate.Focus()
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub txtstd_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtstd.KeyPress
        numkeypress(e, txtstd, Me)
    End Sub

    Private Sub txtaltno_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtaltno.KeyPress
        numkeypress(e, txtaltno, Me)
    End Sub

    Private Sub txtresino_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtresino.KeyPress
        numkeypress(e, txtresino, Me)
    End Sub

    Private Sub vendormaster_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Alt = True And e.KeyCode = Windows.Forms.Keys.S Then       'for Saving
            Call cmdok_Click(sender, e)
        ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            If txtname.Text.Trim <> "" And cmbgroup.Text.Trim <> "" And chkchange.CheckState = CheckState.Checked Then
                tempmsg = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                If tempmsg = vbYes Then cmdok_Click(sender, e)
            End If
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If

        '****** CTRL + N *************
        If e.Control = True And e.KeyCode = Keys.N Then
            If txtname.Text.Trim <> "" And cmbgroup.Text.Trim <> "" And chkchange.CheckState = CheckState.Checked Then
                tempmsg = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                If tempmsg = vbYes Then cmdok_Click(sender, e)
            End If
            clear()
        End If

    End Sub

    Private Sub vendormaster_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        'esc
        If AscW(e.KeyChar) <> 33 Then
            chkchange.CheckState = CheckState.Checked
        End If
    End Sub

    Private Sub txtcmpname_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtname.LostFocus
        duplicate = False
        If (edit = False) Or (edit = True And LCase(tempname) <> LCase(txtname.Text.Trim)) Then
            tempcondition = ""
            duplication("ledgermaster", "ledger_name", Trim(txtname.Text.Trim), tempcondition)
        End If
        If duplicate = True Then
            MessageBox.Show("Company Name Already Exists.")
            txtname.Clear()
            txtname.Focus()
        Else
            'If txtname.Text <> "" And cmdedit.Enabled = True Then
            '    If Len(txtname.Text) > 3 Then
            '        'getting 3 alphabets of name as code
            '        txtname.SelectionStart = 0
            '        txtname.SelectionLength = 3
            '    Else
            '        txtname.SelectionStart = 0
            '        txtname.SelectionLength = Len(txtname.Text)
            '    End If
            '    txtcode.Text = UCase(txtname.SelectedText)
            'End If
        End If
    End Sub

    Private Sub txtadd_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtadd.Validated
        If txtadd.Text.Trim <> "" Then txtshipadd.Text = txtadd.Text.Trim
    End Sub

    Private Sub txtopbalwt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtopbalwt.KeyPress
        numdot(e, txtopbalwt, Me)
    End Sub

    Private Sub chkcopy_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkcopy.CheckedChanged
        Try
            txtadd.Clear()
            If chkcopy.CheckState = CheckState.Checked Then
                If txtadd1.Text.Trim <> "" Then txtadd.Text = txtadd.Text & txtadd1.Text.Trim & vbNewLine
                If txtadd2.Text.Trim <> "" Then txtadd.Text = txtadd.Text & txtadd2.Text.Trim & vbNewLine

                If cmbarea.Text.Trim <> "" Then txtadd.Text = txtadd.Text & "" & cmbarea.Text.Trim

                If cmbcity.Text.Trim <> "" Then txtadd.Text = txtadd.Text & ", " & cmbcity.Text.Trim

                If txtzipcode.Text.Trim <> "" Then
                    txtadd.Text = txtadd.Text & " - " & txtzipcode.Text.Trim & "," & vbNewLine
                Else
                    txtadd.Text = txtadd.Text & vbNewLine
                End If

                If cmbstate.Text.Trim <> "" Then
                    txtadd.Text = txtadd.Text & "" & cmbstate.Text.Trim & ","
                Else
                    txtadd.Text = txtadd.Text & vbNewLine
                End If

                If cmbcountry.Text.Trim <> "" Then
                    txtadd.Text = txtadd.Text & " " & cmbcountry.Text.Trim & "."
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtcode_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtcode.Validating
        Try
            duplicate = False
            If (edit = False) Or (edit = True And LCase(TEMPCODE) <> LCase(txtcode.Text.Trim)) Then
                duplication("LEDGERMASTER", "LEDGER_CODE", txtcode.Text.Trim, "")
            End If
            If duplicate = True Then
                e.Cancel = True
                MsgBox("Code Already Present", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddelete.Click
        Try
            If cmdedit.Enabled = False Then
                If USERDELETE = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If


                'before deleting CHECK IN ALL RELATED TABLE FOR REFERENCE

                'getting Accountmaster
                tempcmd = New OleDbCommand("select 'Accounts' as TABLENAME, ACCOUNT_DATE AS [DATE] from ACCOUNTMASTER where ACCOUNT_LEDGERID = " & TEMPLEDGERID, tempconn)
                If tempconn.State = ConnectionState.Open Then tempconn.Close()
                tempconn.Open()
                tempdr = tempcmd.ExecuteReader
                If tempdr.HasRows Then
                    tempdr.Read()
                    MsgBox("Unable to Delete Item, First Delete data from " & tempdr(0), MsgBoxStyle.Critical)
                    Exit Sub
                End If
                tempconn.Close()
                tempdr.Close()

                'getting bhavcutmaster
                tempcmd = New OleDbCommand("select 'BhavCut' as TABLENAME, bhavcut_DATE AS [DATE] from BHAVCUTMASTER where BHAVCUT_LEDGERID = " & TEMPLEDGERID, tempconn)
                If tempconn.State = ConnectionState.Open Then tempconn.Close()
                tempconn.Open()
                tempdr = tempcmd.ExecuteReader
                If tempdr.HasRows Then
                    tempdr.Read()
                    MsgBox("Unable to Delete Item, First Delete data from " & tempdr(0), MsgBoxStyle.Critical)
                    Exit Sub
                End If
                tempconn.Close()
                tempdr.Close()

                'getting CustomerWastage
                tempcmd = New OleDbCommand("select 'Customer Wastage' as TABLENAME from CUSTOMERWASTAGE where LEDGERID = " & TEMPLEDGERID, tempconn)
                If tempconn.State = ConnectionState.Open Then tempconn.Close()
                tempconn.Open()
                tempdr = tempcmd.ExecuteReader
                If tempdr.HasRows Then
                    tempdr.Read()
                    MsgBox("Unable to Delete Item, First Delete data from " & tempdr(0), MsgBoxStyle.Critical)
                    Exit Sub
                End If
                tempconn.Close()
                tempdr.Close()

                'getting KARIGARISSUE
                tempcmd = New OleDbCommand("select 'Manufacturing - Karigar' as TABLENAME from KARIGARISSUE where MFG_ITEMID = " & TEMPLEDGERID, tempconn)
                If tempconn.State = ConnectionState.Open Then tempconn.Close()
                tempconn.Open()
                tempdr = tempcmd.ExecuteReader
                If tempdr.HasRows Then
                    tempdr.Read()
                    MsgBox("Unable to Delete Item, First Delete data from " & tempdr(0), MsgBoxStyle.Critical)
                    Exit Sub
                End If
                tempconn.Close()
                tempdr.Close()


                'getting PROCESSMASTER
                tempcmd = New OleDbCommand("select 'ProcessMaster' as TABLENAME from PROCESSMASTER where PROCESS_LEDGERID = " & TEMPLEDGERID, tempconn)
                If tempconn.State = ConnectionState.Open Then tempconn.Close()
                tempconn.Open()
                tempdr = tempcmd.ExecuteReader
                If tempdr.HasRows Then
                    tempdr.Read()
                    MsgBox("Unable to Delete Item, First Delete data from " & tempdr(0), MsgBoxStyle.Critical)
                    Exit Sub
                End If
                tempconn.Close()
                tempdr.Close()


                'getting VOUCHERS
                tempcmd = New OleDbCommand("select 'Daily Khata' as TABLENAME from VOUCHERS where VOUCHER_LEDGERID = " & TEMPLEDGERID, tempconn)
                If tempconn.State = ConnectionState.Open Then tempconn.Close()
                tempconn.Open()
                tempdr = tempcmd.ExecuteReader
                If tempdr.HasRows Then
                    tempdr.Read()
                    MsgBox("Unable to Delete Item, First Delete data from " & tempdr(0), MsgBoxStyle.Critical)
                    Exit Sub
                End If
                tempconn.Close()
                tempdr.Close()


                'IF EVERYTHING IS PERFECT THEN DLEETE
                Dim TEMPMSG As Integer = MsgBox("Wish to Delete Ledger?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbNo Then Exit Sub
                tempcmd = New OleDbCommand("DELETE FROM LEDGERMASTER where LEDGER_ID = " & TEMPLEDGERID, tempconn)
                If tempconn.State = ConnectionState.Open Then tempconn.Close()
                tempconn.Open()
                tempdr = tempcmd.ExecuteReader
                MsgBox("Ledger Deleted Successfully", MsgBoxStyle.Information, "Magic Gold")
                clear()
                tempconn.Close()
                tempdr.Close()

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub vendormaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'ACCOUNTS MASTER'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)


            chkchange.CheckState = CheckState.Unchecked

            tempcondition = ""
            fillgroup(Me, cmbgroup, cmbgroupid, tempcondition)
            fillcmb(cmbarea, "area_name", "areamaster", tempcondition)
            fillcmb(cmbcity, "city_name", "citymaster", tempcondition)
            fillcmb(cmbcity, "state_name", "statemaster", tempcondition)
            fillcmb(cmbcity, "country_name", "countrymaster", tempcondition)

            cmbgroup.Text = "Sundry Creditors"

            cmbarea.Text = ""
            cmbcity.Text = ""
            cmbstate.Text = ""
            cmbcountry.Text = ""

            If TEMPACCNAME <> "" Then txtname.Text = TEMPACCNAME
            If TEMPACCNAME <> "" Then txtcode.Text = TEMPACCNAME


            'getting data from database
            If edit = True Then

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If


                If tempname <> "Other Charges" And tempname <> "SALE" And tempname <> "PURCHASE" Then

                    Me.Text = "Edit Account"

                    cmd = New OleDbCommand("select * from ledgermaster where ledger_name = '" & tempname & "'", conn)
                    If conn.State = ConnectionState.Open Then
                        conn.Close()
                    End If
                    conn.Open()
                    dr = cmd.ExecuteReader()
                    While (dr.Read())

                        TEMPLEDGERID = dr(0)
                        txtname.Text = dr(1)
                        txtcode.Text = dr(2)

                        TEMPCODE = txtcode.Text.Trim

                        'getting group
                        tempcmd = New OleDbCommand("select group_name from groupmaster where group_id  = " & Val(dr(3).ToString), tempconn)
                        If tempconn.State = ConnectionState.Open Then
                            tempconn.Close()
                        End If
                        tempconn.Open()
                        tempdr = tempcmd.ExecuteReader
                        If tempdr.HasRows Then
                            tempdr.Read()
                            cmbgroup.Text = tempdr(0)
                        End If
                        tempconn.Close()
                        tempdr.Close()

                        txtopbalrs.Text = dr(4).ToString
                        cmbdrcrrs.Text = dr(5).ToString
                        txtopbalwt.Text = dr(6).ToString
                        cmbdrcrwt.Text = dr(7).ToString

                        'details
                        txtadd1.Text = dr(8).ToString
                        txtadd2.Text = dr(9).ToString

                        'getting area
                        tempcmd = New OleDbCommand("select area_name from areamaster where area_id  = " & Val(dr(10).ToString), tempconn)
                        If tempconn.State = ConnectionState.Open Then
                            tempconn.Close()
                        End If
                        tempconn.Open()
                        tempdr = tempcmd.ExecuteReader
                        If tempdr.HasRows Then
                            tempdr.Read()
                            cmbarea.Text = tempdr(0)
                        End If
                        tempconn.Close()
                        tempdr.Close()


                        'getting city
                        tempcmd = New OleDbCommand("select city_name from citymaster where city_id  = " & Val(dr(11).ToString), tempconn)
                        If tempconn.State = ConnectionState.Open Then
                            tempconn.Close()
                        End If
                        tempconn.Open()
                        tempdr = tempcmd.ExecuteReader
                        If tempdr.HasRows Then
                            tempdr.Read()
                            cmbcity.Text = tempdr(0)
                        End If
                        tempconn.Close()
                        tempdr.Close()

                        txtzipcode.Text = dr(12).ToString


                        'getting state
                        tempcmd = New OleDbCommand("select state_name from statemaster where state_id  = " & Val(dr(13).ToString), tempconn)
                        If tempconn.State = ConnectionState.Open Then
                            tempconn.Close()
                        End If
                        tempconn.Open()
                        tempdr = tempcmd.ExecuteReader
                        If tempdr.HasRows Then
                            tempdr.Read()
                            cmbstate.Text = tempdr(0)
                        End If
                        tempconn.Close()
                        tempdr.Close()


                        'getting country
                        tempcmd = New OleDbCommand("select country_name from countrymaster where country_id  = " & Val(dr(14).ToString), tempconn)
                        If tempconn.State = ConnectionState.Open Then
                            tempconn.Close()
                        End If
                        tempconn.Open()
                        tempdr = tempcmd.ExecuteReader
                        If tempdr.HasRows Then
                            tempdr.Read()
                            cmbcountry.Text = tempdr(0)
                        End If
                        tempconn.Close()
                        tempdr.Close()

                        txtstd.Text = dr(15).ToString
                        txtresino.Text = dr(16).ToString
                        txtaltno.Text = dr(17).ToString
                        txttel1.Text = dr(18).ToString
                        txtmobile.Text = dr(19).ToString
                        txtfax.Text = dr(20).ToString
                        txtwebsite.Text = dr(21).ToString
                        txtemail.Text = dr(22).ToString
                        txtcrdays.Text = dr(23).ToString
                        txtcrlimit.Text = dr(24).ToString
                        txtpanno.Text = dr(25).ToString
                        TXTSALARY.Text = Val(dr(26))
                        txtcstno.Text = dr(27).ToString
                        txttinno.Text = dr(28).ToString
                        txtstno.Text = dr(29).ToString
                        txtvatno.Text = dr(30).ToString
                        txtkstno.Text = dr(31).ToString
                        txtadd.Text = dr(32).ToString
                        txtshipadd.Text = dr(33).ToString
                        txtnotes.Text = dr(34).ToString
                        CHKLOSS.Checked = Convert.ToBoolean(dr(37))
                        CHKKARIGAR.Checked = Convert.ToBoolean(dr(38))

                        If IsDBNull(dr(39)) = False Then TXTOPBALGROSSWT.Text = Val(dr(39))
                        If IsDBNull(dr(40)) = False Then CMBDRCRGROSSWT.Text = dr(40).ToString

                    End While
                    conn.Close()
                    dr.Close()

                Else
                    MessageBox.Show("Fixed Ledgers, Can't Edit")
                    clear()
                    txtname.Focus()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTSALARY_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTSALARY.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub

    Private Sub ACCOUNTMASTER_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Try
            If ISMASTER = False Then
                cmdok.Enabled = False
                cmddelete.Enabled = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class