Imports System.Data.OleDb

Public Class companymaster

    Public EDIT As Boolean = False

    Private Sub cmdnext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdnext.Click
        If txtcmpname.Text.Trim <> "" And txtdisplayedname.Text.Trim <> "" Then

            'getting values in variables
            tempcmpname = txtcmpname.Text.Trim
            cmplegalname = txtlegalname.Text.Trim
            If rbprop.Checked = True Then
                cmpprop = "1"
            Else
                cmpprop = "0"
            End If

            If rbautho.Checked = True Then
                cmpautho = "1"
            Else
                cmpautho = "0"
            End If

            If rbpartner.Checked = True Then
                cmppartner = "1"
            Else
                cmppartner = "0"
            End If

            If rbpropautho.Checked = True Then
                cmppropautho = "1"
            Else
                cmppropautho = "0"
            End If

            cmpdisplayedname = txtdisplayedname.Text.Trim
            cmpinvinitials = txtinvinitials.Text.Trim
            cmpcstno = txtcstno.Text.Trim
            cmpvatno = txtvatno.Text.Trim
            cmppanno = txtpanno.Text.Trim
            cmpadd1 = txtadd1.Text.Trim
            cmpadd2 = txtadd2.Text.Trim

            'getting cityid
            cmd = New OleDbCommand("select city_id from citymaster where city_name = '" & cmbcity.Text.Trim & "'", conn)
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
            conn.Open()
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                dr.Read()
                tempcityid = dr(0)
            Else
                tempcityid = "0"
            End If
            conn.Close()


            'getting stateid
            cmd = New OleDbCommand("select state_id from statemaster where state_name = '" & cmbstate.Text.Trim & "'", conn)
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
            conn.Open()
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                dr.Read()
                tempstateid = dr(0)
            Else
                tempstateid = "0"
            End If
            conn.Close()

            cmpzip = txtzipcode.Text.Trim

            'getting countryid
            cmd = New OleDbCommand("select country_id from countrymaster where country_name = '" & cmbcountry.Text.Trim & "'", conn)
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
            conn.Open()
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                dr.Read()
                tempcountryid = dr(0)
            Else
                tempcountryid = "0"
            End If
            conn.Close()

            cmptel1 = txttel1.Text.Trim
            cmpfax = txtfax.Text.Trim
            cmpemail = txtemail.Text.Trim
            cmpwebsite = txtwebsite.Text.Trim

            Me.Hide()
            Dim objcmppass As New companypasswd
            objcmppass.EDIT = EDIT
            objcmppass.ShowDialog()
            'add companypassword    
            'If (chldcmppassword.IsMdiChild = False) Then
            '    If chldcmppassword.IsDisposed = True Then
            '        chldcmppassword = New companypasswd
            '    End If
            '    chldcmppassword.MdiParent = MDIParent1
            '    chldcmppassword.Show()
            'Else
            '    chldcmppassword.BringToFront()
            '    chldcmppassword.Show()
            'End If
        Else
            MessageBox.Show("Enter Proper Company Name", "Textile Manufacturing", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtcmpname.Focus()
        End If
    End Sub

    Private Sub cmdleave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdleave.Click
        Me.Close()
    End Sub

    Private Sub txtcmpname_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcmpname.GotFocus
        txtcmpname.SelectAll()
    End Sub

    Private Sub txtcmpname_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcmpname.KeyPress
        enterkeypress(e, Me)
    End Sub

    Private Sub txtcmpname_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcmpname.Validated

        If txtcmpname.Text.Trim <> "" Then
            txtlegalname.Text = caps(txtcmpname.Text.Trim)
            txtdisplayedname.Text = txtcmpname.Text.Trim
        End If

        duplicate = False
        If cmdedit.Enabled = False Then edit = True
        If cmdedit.Enabled = True Then edit = False

        If (edit = False) Or (edit = True And LCase(tempcmpname) <> LCase(txtcmpname.Text.Trim)) Then
            tempcondition = ""
            duplication("cmpmaster", "cmp_name", txtcmpname.Text.Trim, tempcondition)
        End If
        If duplicate = True Then
            MessageBox.Show("Company Name Already Exists.")
            txtcmpname.Focus()
        End If
    End Sub

    Private Sub txtlegalname_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtlegalname.GotFocus
        txtlegalname.SelectAll()
    End Sub

    Private Sub txtlegalname_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtlegalname.KeyPress
        enterkeypress(e, Me)
    End Sub

    Private Sub txtlegalname_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtlegalname.Validated
        txtlegalname.Text = caps(txtlegalname.Text.Trim)
    End Sub

    Private Sub cmbcity_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbcity.GotFocus
        cmbcity.SelectAll()
        tempcondition = ""
        fillcmb(cmbcity, "city_name", "citymaster", tempcondition)
    End Sub

    Private Sub cmbcity_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbcity.KeyPress
        enterkeypress(e, Me)
    End Sub

    Private Sub cmbcity_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbcity.TextChanged
        cmbtextchanged(sender, Me, cmbcity)
    End Sub

    Private Sub cmbcity_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbcity.Validated
        cmbcity.Text = caps(cmbcity.Text.Trim)

        If cmbcity.Text.Trim <> "" Then
            cmd = New OleDbCommand("select city_id from citymaster where city_name = '" & cmbcity.Text.Trim & "'", conn)
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
            conn.Open()
            dr = cmd.ExecuteReader
            If dr.HasRows = False Then
                tempmsg = MsgBox("City Not Present, Add New?", MsgBoxStyle.YesNo)
                If tempmsg = vbYes Then

                    For i = 0 To 50
                        tempcol(i) = ""
                        tempval(i) = ""
                    Next

                    tempcol(0) = "city_name"
                    tempcol(1) = "city_userid"

                    tempval(0) = "'" & cmbcity.Text.Trim & "'"
                    tempval(1) = "'" & tempuserid & "'"

                    insert("citymaster", tempcol, tempval)
                Else
                    cmbcity.Focus()
                End If
            End If
        End If
    End Sub

    Private Sub cmbcountry_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbcountry.GotFocus
        cmbcountry.SelectAll()
        tempcondition = ""
        fillcmb(cmbcountry, "country_name", "countrymaster", tempcondition)
    End Sub

    Private Sub cmbcountry_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbcountry.KeyPress
        enterkeypress(e, Me)
    End Sub

    Private Sub cmbcountry_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbcountry.TextChanged
        cmbtextchanged(sender, Me, cmbcountry)
    End Sub

    Private Sub cmbcountry_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbcountry.Validated
        cmbcountry.Text = caps(cmbcountry.Text.Trim)

        If cmbcountry.Text.Trim <> "" Then


            cmd = New OleDbCommand("select country_id from countrymaster where country_name = '" & cmbcountry.Text.Trim & "'", conn)
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
            conn.Open()
            dr = cmd.ExecuteReader
            If dr.HasRows = False Then
                tempmsg = MsgBox("Country Not Present, Add New?", MsgBoxStyle.YesNo)
                If tempmsg = vbYes Then

                    For i = 0 To 50
                        tempcol(i) = ""
                        tempval(i) = ""
                    Next

                    tempcol(0) = "country_name"
                    tempcol(1) = "country_userid"

                    tempval(0) = "'" & cmbcountry.Text.Trim & "'"
                    tempval(1) = "'" & tempuserid & "'"

                    insert("countrymaster", tempcol, tempval)
                Else
                    cmbcountry.Focus()
                End If
            End If
        End If
    End Sub

    Private Sub cmbstate_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbstate.GotFocus
        cmbstate.SelectAll()
        tempcondition = ""
        fillcmb(cmbstate, "state_name", "statemaster", tempcondition)
    End Sub

    Private Sub cmbstate_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbstate.KeyPress
        enterkeypress(e, Me)
    End Sub

    Private Sub cmbstate_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbstate.TextChanged
        cmbtextchanged(sender, Me, cmbstate)
    End Sub

    Private Sub cmbstate_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbstate.Validated
        cmbstate.Text = caps(cmbstate.Text.Trim)

        If cmbstate.Text.Trim <> "" Then


            cmd = New OleDbCommand("select state_id from statemaster where state_name = '" & cmbstate.Text.Trim & "'", conn)
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
            conn.Open()
            dr = cmd.ExecuteReader
            If dr.HasRows = False Then
                tempmsg = MsgBox("State Not Present, Add New?", MsgBoxStyle.YesNo)
                If tempmsg = vbYes Then

                    For i = 0 To 50
                        tempcol(i) = ""
                        tempval(i) = ""
                    Next

                    tempcol(0) = "State_name"
                    tempcol(1) = "State_userid"

                    tempval(0) = "'" & cmbstate.Text.Trim & "'"
                    tempval(1) = "'" & tempuserid & "'"

                    insert("Statemaster", tempcol, tempval)
                Else
                    cmbstate.Focus()
                End If
            End If
        End If
    End Sub

    Private Sub txtadd1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtadd1.GotFocus
        txtadd1.SelectAll()
    End Sub

    Private Sub txtadd1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtadd1.KeyPress
        enterkeypress(e, Me)
    End Sub

    Private Sub txtadd1_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtadd1.Validated
        txtadd1.Text = caps(txtadd1.Text.Trim)
    End Sub

    Private Sub txtadd2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtadd2.GotFocus
        txtadd2.SelectAll()
    End Sub

    Private Sub txtadd2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtadd2.KeyPress
        enterkeypress(e, Me)
    End Sub

    Private Sub txtadd2_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtadd2.Validated
        txtadd2.Text = caps(txtadd2.Text.Trim)
    End Sub

    Private Sub txtcstno_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcstno.GotFocus
        txtcstno.SelectAll()
    End Sub

    Private Sub txtcstno_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcstno.KeyPress
        enterkeypress(e, Me)
    End Sub

    Private Sub txtemail_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtemail.GotFocus
        txtemail.SelectAll()
    End Sub

    Private Sub txtemail_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtemail.KeyPress
        enterkeypress(e, Me)
    End Sub

    Private Sub txtfax_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtfax.GotFocus
        txtfax.SelectAll()
    End Sub

    Private Sub txtfax_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtfax.KeyPress
        enterkeypress(e, Me)
    End Sub

    Private Sub txtpanno_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtpanno.GotFocus
        txtpanno.SelectAll()
    End Sub

    Private Sub txtpanno_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtpanno.KeyPress
        enterkeypress(e, Me)
    End Sub

    Private Sub txttel1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txttel1.GotFocus
        txttel1.SelectAll()
    End Sub

    Private Sub txttel1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txttel1.KeyPress
        enterkeypress(e, Me)
    End Sub

    Private Sub txtvatno_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtvatno.GotFocus
        txtvatno.SelectAll()
    End Sub

    Private Sub txtvatno_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtvatno.KeyPress
        enterkeypress(e, Me)
    End Sub

    Private Sub txtwebsite_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtwebsite.GotFocus
        txtwebsite.SelectAll()
    End Sub

    Private Sub txtwebsite_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtwebsite.KeyPress
        enterkeypress(e, Me)
    End Sub

    Private Sub txtzipcode_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtzipcode.GotFocus
        txtzipcode.SelectAll()
    End Sub

    Private Sub txtzipcode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtzipcode.KeyPress
        enterkeypress(e, Me)
    End Sub

    Private Sub companymaster_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub companymaster_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

        tempcondition = ""
        fillcmb(cmbcity, "city_name", "citymaster", tempcondition)
        fillcmb(cmbstate, "state_name", "statemaster", tempcondition)
        fillcmb(cmbcountry, "country_name", "countrymaster", tempcondition)

        If cmdedit.Enabled = False Then edit = True
        If cmdedit.Enabled = True Then edit = False

        If edit = True Then

            cmd = New OleDbCommand("select * from cmpmaster where cmp_no = " & tempcmpid, OGCONN)
            If OGCONN.State = ConnectionState.Open Then
                OGCONN.Close()
            End If
            OGCONN.Open()
            dr = cmd.ExecuteReader
            dr.Read()
            txtcmpname.Text = dr(1).ToString
            txtlegalname.Text = dr(2).ToString

            If Val(dr("cmp_prop")) = 1 Then rbprop.Checked = True
            If Val(dr("cmp_autho")) = 1 Then rbautho.Checked = True
            If Val(dr("cmp_partner")) = 1 Then rbpartner.Checked = True
            If Val(dr("cmp_propautho")) = 1 Then rbpropautho.Checked = True

            txtcstno.Text = dr(3).ToString
            txtvatno.Text = dr(4).ToString
            txtpanno.Text = dr(5).ToString
            txtadd1.Text = dr(6).ToString
            txtadd2.Text = dr(7).ToString

            'getting city
            tempcmd = New OleDbCommand("select city_name from citymaster where city_id = " & dr(8), tempconn)
            If tempconn.State = ConnectionState.Open Then
                tempconn.Close()
            End If
            tempconn.Open()
            tempdr = tempcmd.ExecuteReader
            If tempdr.HasRows = True Then
                While (tempdr.Read)
                    cmbcity.Text = tempdr(0).ToString
                End While
            End If
            tempdr.Close()

            txtzipcode.Text = dr(10).ToString

            'getting state
            tempcmd = New OleDbCommand("select state_name from statemaster where state_id = " & dr(9), tempconn)
            If tempconn.State = ConnectionState.Open Then
                tempconn.Close()
            End If
            tempconn.Open()
            tempdr = tempcmd.ExecuteReader
            If tempdr.HasRows = True Then
                While (tempdr.Read)
                    cmbstate.Text = tempdr(0).ToString
                End While
            End If
            tempdr.Close()

            'getting country
            tempcmd = New OleDbCommand("select country_name from countrymaster where country_id = " & dr(11), tempconn)
            If tempconn.State = ConnectionState.Open Then
                tempconn.Close()
            End If
            tempconn.Open()
            tempdr = tempcmd.ExecuteReader
            If tempdr.HasRows = True Then
                While (tempdr.Read)
                    cmbcountry.Text = tempdr(0).ToString
                End While
            End If
            tempdr.Close()

            txttel1.Text = dr(12).ToString
            txtfax.Text = dr(13).ToString
            txtemail.Text = dr(14).ToString
            txtwebsite.Text = dr(15).ToString
            txtdisplayedname.Text = dr(21).ToString
            txtinvinitials.Text = dr(22).ToString

        End If

    End Sub

End Class