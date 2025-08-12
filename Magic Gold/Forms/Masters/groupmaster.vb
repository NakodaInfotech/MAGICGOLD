Imports System.Data.OleDb

Public Class groupmaster

    Public EDIT As Boolean = False
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click

        If txtgroupname.Text.Trim <> "" And chkchange.CheckState = CheckState.Checked Then
            tempmsg = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
            If tempmsg = vbYes Then cmdok_Click(sender, e)
        End If
        Me.Close()

        If cmdedit.Enabled = False Then

            If (chldgroupdetails.IsMdiChild = False) Then
                If chldgroupdetails.IsDisposed = True Then
                    chldgroupdetails = New groupdetails
                End If
                chldgroupdetails.MdiParent = MDIMain
                chldgroupdetails.Show()
            Else
                chldgroupdetails.BringToFront()
            End If

        End If
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        If ISMASTER = False Then Exit Sub

        If txtgroupname.Text.Trim <> "" Then

            duplicate = False
            If (edit = False) Or (edit = True And LCase(tempgroupname) <> LCase(txtgroupname.Text.Trim)) Then
                tempcondition = ""
                duplication("groupmaster", "group_name", txtgroupname.Text.Trim, tempcondition)
            End If
            If duplicate = False Then
                tempcol(0) = "group_type"
                tempcol(1) = "group_name"
                tempcol(2) = "group_under"
                tempcol(3) = "group_userid"

                'getting grouptype 
                tempcmd = New OleDbCommand("select group_type from groupmaster where group_name = '" & cmbunder.Text.Trim & "'", tempconn)
                If tempconn.State = ConnectionState.Open Then
                    tempconn.Close()
                End If
                tempconn.Open()
                tempdr = tempcmd.ExecuteReader
                If tempdr.HasRows = True Then
                    tempdr.Read()
                    tempval(0) = "'" & tempdr(0).ToString & "'"
                End If

                tempval(1) = "'" & txtgroupname.Text.Trim & "'"
                tempval(2) = "'" & cmbunder.Text.Trim & "'"
                tempval(3) = tempuserid

                If cmdedit.Enabled = True Then edit = False
                If cmdedit.Enabled = False Then edit = True

                If edit = False Then
                    If USERADD = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    insert("groupmaster", tempcol, tempval)
                    MessageBox.Show("Group Added")
                ElseIf edit = True Then
                    If USEREDIT = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    tempcondition = " where group_name = '" & tempgroupname & "'"
                    modify("groupmaster", tempcol, tempval, tempcondition)
                    MessageBox.Show("Group Updated")
                End If

                If cmdedit.Enabled = False Then
                    Me.Close()
                    If (chldgroupdetails.IsMdiChild = False) Then
                        If chldgroupdetails.IsDisposed = True Then
                            chldgroupdetails = New groupdetails
                        End If
                        chldgroupdetails.MdiParent = MDIMain
                        chldgroupdetails.Show()
                    Else
                        chldgroupdetails.BringToFront()
                    End If
                Else
                    clear()
                    txtgroupname.Focus()
                End If
            Else
                MsgBox("Group Name Already Exists")
                txtgroupname.Focus()
            End If

        Else
            MsgBox("Enter Valid Name")
        End If
        clear()
        txtgroupname.Focus()

    End Sub

    Sub fillcmb()

        cmd = New OleDbCommand("select * from groupmaster", conn)
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If
        conn.Open()
        dr = cmd.ExecuteReader
        If dr.HasRows Then
            cmbunder.Items.Clear()
            cmbgrouptype.Items.Clear()
            While dr.Read
                cmbunder.Items.Add(dr(2))
                cmbgrouptype.Items.Add(dr(1))
            End While
        End If
        cmbunder.SelectedIndex = (0)
        cmbgrouptype.SelectedIndex = (0)

    End Sub

    Sub clear()
        For i = 1 To 100
            tempcol(i) = ""
            tempval(i) = ""
        Next
        txtgroupname.Clear()

    End Sub

    Private Sub txtgroupname_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtgroupname.GotFocus
        txtgroupname.SelectAll()
    End Sub

    Private Sub txtgroupname_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtgroupname.KeyPress
        enterkeypress(e, Me)
    End Sub

    Private Sub cmbunder_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbunder.GotFocus
        cmbunder.SelectAll()
    End Sub

    Private Sub cmbunder_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbunder.KeyPress
        enterkeypress(e, Me)
    End Sub

    Private Sub txtgroupname_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtgroupname.Validated
        txtgroupname.Text = caps(txtgroupname.Text)
    End Sub

    Private Sub groupmaster_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            If txtgroupname.Text.Trim <> "" And chkchange.CheckState = CheckState.Checked Then
                tempmsg = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                If tempmsg = vbYes Then cmdok_Click(sender, e)
            End If
            Me.Close()
        End If

        '****** CTRL + N *************
        If e.Control = True Then
            If e.KeyCode = Keys.N Then
                If txtgroupname.Text.Trim <> "" And chkchange.CheckState = CheckState.Checked Then
                    tempmsg = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                    If tempmsg = vbYes Then cmdok_Click(sender, e)
                End If
                clear()
            End If
        End If
    End Sub

    Private Sub groupmaster_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        'esc
        If AscW(e.KeyChar) <> 33 Then
            chkchange.CheckState = CheckState.Checked
        End If
    End Sub

    Private Sub groupmaster_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'GROUP MASTER'")
        USERADD = DTROW(0).Item(1)
        USEREDIT = DTROW(0).Item(2)
        USERVIEW = DTROW(0).Item(3)
        USERDELETE = DTROW(0).Item(4)

        If USEREDIT = False And USERVIEW = False Then
            MsgBox("Insufficient Rights")
            Exit Sub
        End If

        'clear()
        fillcmb()
        lblunder.Visible = True
        cmbunder.Visible = True
        Me.Text = "Group Master"
        lblgroup.Text = "Group Name"
        If cmdedit.Enabled = False Then cmbunder.Text = tempgrouptype
    End Sub

    Private Sub cmbunder_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbunder.TextChanged
        cmbtextchanged(sender, Me, cmbunder)
    End Sub

    Private Sub cmbunder_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbunder.Validating
        If cmbunder.Text.Trim <> "" Then
            cmd = New OleDbCommand("select group_id from groupmaster where group_name = '" & cmbunder.Text.Trim & "'", conn)
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
            conn.Open()
            dr = cmd.ExecuteReader
            If dr.HasRows = False Then
                MessageBox.Show("Select Valid Group Type")
                cmbunder.SelectedIndex = (0)
                e.Cancel = True
            End If
        Else
            MessageBox.Show("Enter Valid Group Type")
            cmbunder.Focus()
        End If
    End Sub

    Private Sub cmddelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmddelete.Click
        Try
            If USERDELETE = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub groupmaster_Shown(sender As Object, e As EventArgs) Handles Me.Shown
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