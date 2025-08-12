Imports System.Data.oledb

Public Class areamaster

    Public EDIT As Boolean = False
    Public TEMPID As Integer = 0

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click

        If txtname.Text.Trim <> "" And chkchange.CheckState = CheckState.Checked Then
            tempmsg = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
            If tempmsg = vbYes Then cmdok_Click(sender, e)
        End If
        Me.Close()

        If cmdedit.Enabled = False Then

            If (chldareadetails.IsMdiChild = False) Then
                If chldareadetails.IsDisposed = True Then
                    chldareadetails = New areadetails
                End If
                chldareadetails.MdiParent = MDIMain
                chldareadetails.Show()
            Else
                chldareadetails.BringToFront()
            End If

        End If
    End Sub

    Sub CLEAR()
        For i = 1 To 100
            tempcol(i) = ""
            tempval(i) = ""
        Next
        txtname.Clear()
    End Sub

    Private Sub cmdok_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdok.Click
        If ISMASTER = False Then Exit Sub


        If txtname.Text.Trim <> "" Then

            If frmareamaster = True And frmcitymaster = False And frmstatemaster = False And frmcountrymaster = False And frmcategorymaster = False Then

                duplicate = False
                If (EDIT = False) Or (EDIT = True And LCase(templocation) <> LCase(txtname.Text.Trim)) Then
                    tempcondition = ""
                    duplication("areamaster", "area_name", txtname.Text.Trim, tempcondition)
                End If
                If duplicate = False Then
                    tempcol(0) = "area_name"
                    tempcol(1) = "area_userid"

                    tempval(0) = "'" & txtname.Text.Trim & "'"
                    tempval(1) = tempuserid


                    If cmdedit.Enabled = True Then EDIT = False
                    If cmdedit.Enabled = False Then EDIT = True

                    If EDIT = False Then
                        insert("areamaster", tempcol, tempval)
                        MessageBox.Show("Area Added")
                    ElseIf EDIT = True Then
                        tempcondition = " where area_name = '" + templocation + "'"
                        modify("areamaster", tempcol, tempval, tempcondition)
                        MessageBox.Show("Area Updated")
                    End If
                Else
                    MessageBox.Show("Area Already Exists")
                    txtname.Focus()
                End If

            ElseIf frmareamaster = False And frmcitymaster = True And frmstatemaster = False And frmcountrymaster = False And frmcategorymaster = False Then

                duplicate = False
                If (EDIT = False) Or (EDIT = True And LCase(templocation) <> LCase(txtname.Text.Trim)) Then
                    tempcondition = ""
                    duplication("citymaster", "city_name", txtname.Text.Trim, tempcondition)
                End If
                If duplicate = False Then
                    tempcol(0) = "city_name"
                    tempcol(1) = "city_userid"

                    tempval(0) = "'" & txtname.Text.Trim & "'"
                    tempval(1) = tempuserid

                    If cmdedit.Enabled = True Then EDIT = False
                    If cmdedit.Enabled = False Then EDIT = True

                    If EDIT = False Then
                        insert("citymaster", tempcol, tempval)
                        MessageBox.Show("City Added")
                    ElseIf EDIT = True Then
                        tempcondition = " where city_name = '" + templocation + "'"
                        modify("citymaster", tempcol, tempval, tempcondition)
                        MessageBox.Show("City Updated")
                    End If
                Else
                    MessageBox.Show("City Already Exists")
                    txtname.Focus()
                End If

            ElseIf frmareamaster = False And frmcitymaster = False And frmstatemaster = True And frmcountrymaster = False And frmcategorymaster = False Then

                duplicate = False
                If (EDIT = False) Or (EDIT = True And LCase(templocation) <> LCase(txtname.Text.Trim)) Then
                    tempcondition = ""
                    duplication("Statemaster", "state_name", txtname.Text.Trim, tempcondition)
                End If
                If duplicate = False Then
                    tempcol(0) = "state_name"
                    tempcol(1) = "state_userid"

                    tempval(0) = "'" & txtname.Text.Trim & "'"
                    tempval(1) = tempuserid

                    If cmdedit.Enabled = True Then EDIT = False
                    If cmdedit.Enabled = False Then EDIT = True

                    If EDIT = False Then
                        insert("statemaster", tempcol, tempval)
                        MessageBox.Show("State Added")
                    ElseIf EDIT = True Then
                        tempcondition = " where state_name = '" + templocation + "'"
                        modify("statemaster", tempcol, tempval, tempcondition)
                        MessageBox.Show("State Updated")
                    End If
                Else
                    MsgBox("State Already Exists")
                    txtname.Focus()
                End If

            ElseIf frmareamaster = False And frmcitymaster = False And frmstatemaster = False And frmcountrymaster = True And frmcategorymaster = False Then

                duplicate = False
                If (EDIT = False) Or (EDIT = True And LCase(templocation) <> LCase(txtname.Text.Trim)) Then
                    tempcondition = ""
                    duplication("countrymaster", "Country_name", txtname.Text.Trim, tempcondition)
                End If
                If duplicate = False Then
                    tempcol(0) = "country_name"
                    tempcol(1) = "country_userid"

                    tempval(0) = "'" & txtname.Text.Trim & "'"
                    tempval(1) = tempuserid

                    If cmdedit.Enabled = True Then EDIT = False
                    If cmdedit.Enabled = False Then EDIT = True

                    If EDIT = False Then
                        insert("countrymaster", tempcol, tempval)
                        MessageBox.Show("Country Added")
                    ElseIf EDIT = True Then
                        tempcondition = " where country_name = '" + templocation + "'"
                        modify("countrymaster", tempcol, tempval, tempcondition)
                        MessageBox.Show("Country Updated")
                    End If
                Else
                    MsgBox("Country Already Exists")
                    txtname.Focus()
                End If

            ElseIf frmareamaster = False And frmcitymaster = False And frmstatemaster = False And frmcountrymaster = False And frmcategorymaster = True Then

                duplicate = False
                If (EDIT = False) Or (EDIT = True And LCase(templocation) <> LCase(txtname.Text.Trim)) Then
                    tempcondition = ""
                    duplication("categorymaster", "category_name", txtname.Text.Trim, tempcondition)
                End If
                If duplicate = False Then
                    tempcol(0) = "category_name"
                    tempcol(1) = "category_userid"

                    tempval(0) = "'" & txtname.Text.Trim & "'"
                    tempval(1) = tempuserid

                    If cmdedit.Enabled = True Then EDIT = False
                    If cmdedit.Enabled = False Then EDIT = True

                    If EDIT = False Then
                        insert("categorymaster", tempcol, tempval)
                        MessageBox.Show("Category Added")
                    ElseIf EDIT = True Then
                        tempcondition = " where category_name = '" + templocation + "'"
                        modify("categorymaster", tempcol, tempval, tempcondition)
                        MessageBox.Show("Category Updated")
                    End If
                Else
                    MsgBox("Category Already Exists")
                    txtname.Focus()
                End If

            End If
        Else
            MsgBox("Enter Valid Name")
        End If
        CLEAR()
        txtname.Focus()
    End Sub

    Private Sub txtname_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtname.GotFocus
        txtname.SelectAll()
    End Sub

    Private Sub txtname_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtname.KeyPress
        enterkeypress(e, Me)
    End Sub

    Private Sub txtname_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtname.LostFocus
        txtname.Text = caps(txtname.Text)
    End Sub

    Private Sub areamaster_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            If txtname.Text.Trim <> "" And chkchange.CheckState = CheckState.Checked Then
                tempmsg = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                If tempmsg = vbYes Then cmdok_Click(sender, e)
            End If
            Me.Close()
        End If

        '****** CTRL + N *************
        If e.Control = True Then
            If e.KeyCode = Keys.N Then
                If txtname.Text.Trim <> "" And chkchange.CheckState = CheckState.Checked Then
                    tempmsg = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                    If tempmsg = vbYes Then cmdok_Click(sender, e)
                End If
                CLEAR()
            End If
        End If
    End Sub

    Private Sub areamaster_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        'esc
        If AscW(e.KeyChar) <> 33 Then
            chkchange.CheckState = CheckState.Checked
        End If
    End Sub

    Private Sub areamaster_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        'CLEAR()
        If frmareamaster = True And frmcitymaster = False And frmstatemaster = False And frmcountrymaster = False And frmcategorymaster = False Then
            Me.Text = "Add New Area"
            lblgroup.Text = "Area"
            lbl.Text = "Enter Area" & vbNewLine & "(e.g. Kalbadevi,Santacruz...., etc.)"
        ElseIf frmareamaster = False And frmcitymaster = True And frmstatemaster = False And frmcountrymaster = False And frmcategorymaster = False Then
            Me.Text = "Add New City"
            lblgroup.Text = "City"
            lbl.Text = "Enter City" & vbNewLine & "(e.g. Mumbai,Pune...., etc.)"
        ElseIf frmareamaster = False And frmcitymaster = False And frmstatemaster = True And frmcountrymaster = False And frmcategorymaster = False Then
            Me.Text = "Add New State"
            lblgroup.Text = "State"
            lbl.Text = "Enter State" & vbNewLine & "(e.g. Maharashtra,Gujrat...., etc.)"
        ElseIf frmareamaster = False And frmcitymaster = False And frmstatemaster = False And frmcountrymaster = True And frmcategorymaster = False Then
            Me.Text = "Add New Country"
            lblgroup.Text = "Country"
            lbl.Text = "Enter Country" & vbNewLine & "(e.g. India,China...., etc.)"
        ElseIf frmareamaster = False And frmcitymaster = False And frmstatemaster = False And frmcountrymaster = False And frmcategorymaster = True Then
            Me.Text = "Add New Category"
            lblgroup.Text = "Category"
            lbl.Text = "Enter Category" & vbNewLine & "(e.g. Metal,Chains...., etc.)"
        End If
        If ISMASTER = False Then
            cmdok.Enabled = False
            cmddelete.Enabled = False
        End If
    End Sub

    Private Sub cmddelete_Click(sender As Object, e As EventArgs) Handles cmddelete.Click
        Try
            If EDIT = False Then Exit Sub
            If MsgBox("Wish to Delete Entry?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub


            If frmareamaster = True And frmcitymaster = False And frmstatemaster = False And frmcountrymaster = False And frmcategorymaster = False Then
                'CHECK WHETHER AREA IS USED OR NOT
                cmd = New OleDbCommand("delete from AREAMASTER where AREA_ID = " & TEMPID, conn)
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
                conn.Open()
                cmd.ExecuteNonQuery()

            ElseIf frmareamaster = False And frmcitymaster = True And frmstatemaster = False And frmcountrymaster = False And frmcategorymaster = False Then
                'CHECK WHETHER CITY IS USED OR NOT
                cmd = New OleDbCommand("delete from CITYMASTER where CITY_ID = " & TEMPID, conn)
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
                conn.Open()
                cmd.ExecuteNonQuery()

            ElseIf frmareamaster = False And frmcitymaster = False And frmstatemaster = True And frmcountrymaster = False And frmcategorymaster = False Then
                'CHECK WHETHER STATE IS USED OR NOT
                cmd = New OleDbCommand("delete from STATEMASTER where STATE_ID = " & TEMPID, conn)
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
                conn.Open()
                cmd.ExecuteNonQuery()

            ElseIf frmareamaster = False And frmcitymaster = False And frmstatemaster = False And frmcountrymaster = True And frmcategorymaster = False Then
                'CHECK WHETHER COUNTRY IS USED OR NOT
                cmd = New OleDbCommand("delete from COUNTRYMASTER where COUNTRY_ID = " & TEMPID, conn)
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
                conn.Open()
                cmd.ExecuteNonQuery()

            ElseIf frmareamaster = False And frmcitymaster = False And frmstatemaster = False And frmcountrymaster = False And frmcategorymaster = True Then
                cmd = New OleDbCommand("delete from CATEGORYMASTER where CATEGORY_ID = " & TEMPID, conn)
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
                conn.Open()
                cmd.ExecuteNonQuery()
            End If
            MsgBox("Entry Deleted Successfully")
            CLEAR()
            txtname.Focus()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub areamaster_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class