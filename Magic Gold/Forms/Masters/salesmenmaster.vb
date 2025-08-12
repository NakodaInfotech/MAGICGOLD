Imports System.Data.oledb

Public Class salesmenmaster

    Public EDIT As Boolean = False

    Private Sub cmdcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click

        If txtmobileno.Text.Trim <> "" And txtname.Text.Trim <> "" And chkchange.CheckState = CheckState.Checked Then
            tempmsg = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
            If tempmsg = vbYes Then cmdok_Click(sender, e)
        End If
        Me.Close()

        If cmdedit.Enabled = False Then
            If (chldsalesmendetails.IsMdiChild = False) Then
                If chldsalesmendetails.IsDisposed = True Then
                    chldsalesmendetails = New salesmendetails
                End If
                chldsalesmendetails.MdiParent = MDIMain
                chldsalesmendetails.Show()
            Else
                chldsalesmendetails.BringToFront()
            End If
        End If

    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        If ISMASTER = False Then Exit Sub
        If txtmobileno.Text.Trim <> "" And txtname.Text.Trim <> "" Then

            duplicate = False
            If (EDIT = False) Or (EDIT = True And LCase(tempsalesman) <> LCase(txtname.Text.Trim)) Then
                tempcondition = ""
                duplication("SalesMenmaster", "SalesMen_name", txtname.Text.Trim, tempcondition)
            End If
            If duplicate = False Then

                For i = 1 To 100
                    tempcol(i) = ""
                    tempval(i) = ""
                Next

                tempcol(0) = "SalesMen_name"
                tempcol(1) = "SalesMen_desc"
                tempcol(2) = "SalesMen_mobileno"


                tempval(0) = "'" & txtname.Text.Trim & "'"
                tempval(1) = "'" & txtdescription.Text.Trim & "'"
                tempval(2) = Val(txtmobileno.Text)


                If cmdedit.Enabled = True Then EDIT = False
                If cmdedit.Enabled = False Then EDIT = True

                If EDIT = False Then
                    insert("SalesMenmaster", tempcol, tempval)
                    MessageBox.Show("SalesMen Added")
                ElseIf EDIT = True Then
                    tempcondition = " where SalesMen_name = '" + tempsalesman + "'"
                    modify("SalesMenmaster", tempcol, tempval, tempcondition)
                    MessageBox.Show("SalesMen Updated")
                End If

                If cmdedit.Enabled = False Then
                    If (chldsalesmendetails.IsMdiChild = False) Then
                        If chldsalesmendetails.IsDisposed = True Then

                            chldsalesmendetails = New salesmendetails
                        End If
                        Me.Close()
                        chldsalesmendetails.MdiParent = MDIMain
                        chldsalesmendetails.Show()
                    Else
                        chldsalesmendetails.BringToFront()
                    End If
                End If
            Else
                MsgBox("Driver Name Already Exists")
                txtname.Focus()
            End If


        Else
            MsgBox("Enter Valid Details")
            txtname.Focus()
        End If
        clear()
    End Sub

    Sub clear()

        'clearing array
        For i = 0 To 100
            tempcol(i) = ""
            tempval(i) = ""
        Next
        txtname.Clear()
        txtdescription.Clear()
        txtmobileno.Clear()

    End Sub

    Private Sub txtname_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtname.GotFocus
        txtname.SelectAll()
    End Sub

    Private Sub txtname_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtname.KeyPress
        enterkeypress(e, Me)
    End Sub

    Private Sub txtdescription_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtdescription.GotFocus
        txtdescription.SelectAll()
    End Sub

    Private Sub txtdescription_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdescription.KeyPress
        enterkeypress(e, Me)
    End Sub

    Private Sub txtname_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtname.LostFocus
        txtname.Text = caps(txtname.Text.Trim)
    End Sub

    Private Sub txtname_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtname.Validated
        If txtname.Text.Trim <> "" Then
            duplicate = False
            If (edit = False) Or (edit = True And LCase(tempsalesman) <> LCase(txtname.Text.Trim)) Then
                tempcondition = ""
                duplication("SalesMenmaster", "SalesMen_name", txtname.Text.Trim, tempcondition)
            End If
            If duplicate = True Then
                MessageBox.Show("SalesMen Name Already Exists.")
                txtname.Clear()
                txtname.Focus()
            End If
        End If
    End Sub

    Private Sub txtmobileno_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtmobileno.KeyPress
        numkeypress(e, txtmobileno, Me)
    End Sub

    Private Sub Drivermaster_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Or (e.Control = True And e.KeyCode = Keys.N) Then
            If txtmobileno.Text.Trim <> "" And txtname.Text.Trim <> "" And chkchange.CheckState = CheckState.Checked Then
                tempmsg = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                If tempmsg = vbYes Then cmdok_Click(sender, e)
            End If
            If e.KeyCode = Keys.Escape Then Me.Close()
        End If
    End Sub

    Private Sub Drivermaster_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

        Me.Text = "New SalesMen"
        'getting data from database
        If edit = True Then

            Me.Text = "Edit SalesMen"
            cmd = New OleDbCommand("select * from SalesMenmaster where SalesMen_name = '" & tempsalesman & "'", conn)
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If

            conn.Open()
            dr = cmd.ExecuteReader()
            While (dr.Read())

                txtname.Text = dr(1).ToString
                txtdescription.Text = dr(2).ToString
                txtmobileno.Text = Val(dr(3).ToString)

            End While
            conn.Close()
            dr.Close()

        End If

        If ISMASTER = False Then
            cmdok.Enabled = False
        End If
    End Sub

    Private Sub SaveToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripButton.Click
        Call cmdok_Click(sender, e)
    End Sub

    Private Sub OpenToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripButton.Click
        If (chldsalesmendetails.IsMdiChild = False) Then
            If chldsalesmendetails.IsDisposed = True Then

                chldsalesmendetails = New salesmendetails
            End If
            Me.Close()
            chldsalesmendetails.MdiParent = MDIMain
            chldsalesmendetails.Show()
        Else
            chldsalesmendetails.BringToFront()
        End If
    End Sub
End Class