Imports System.Data.oledb

Public Class companypasswd

    Public EDIT As Boolean = False

    Private Sub cmdback_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdback.Click
        'add company    
        Me.Hide()
        If (chldcmpmaster.IsMdiChild = False) Then
            If chldcmpmaster.IsDisposed = True Then
                chldcmpmaster = New companymaster
            End If
            chldcmpmaster.MdiParent = MDIMain
            chldcmpmaster.Show()
        Else
            chldcmpmaster.BringToFront()
            chldcmpmaster.Show()
        End If
    End Sub

    Private Sub cmdnext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdnext.Click
        If cmdnext.Text = "&Ok" Then

            'checking password for company
            cmd = New OleDbCommand("select cmp_password from cmpmaster where cmp_name  = '" & tempcmpname & "'", OGCONN)
            If OGCONN.State = ConnectionState.Open Then OGCONN.Close()
            OGCONN.Open()
            dr = cmd.ExecuteReader
            dr.Read()
            If txtpassword.Text.Trim <> dr(0) Then
                MessageBox.Show("Company Access Password Inorrect", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtpassword.Clear()
                txtpassword.Focus()
            Else

                Main()
                MDIMain.Show()
                MDIMain.Text = "MagicGold     (" & tempcmpname & "   " & tempyear & ")          USER : " & USERNAME

                MDIMain.ToolStrip1.Enabled = True
                MDIMain.Mastersmenu.Enabled = True
                MDIMain.Transactionsmenu.Enabled = True
                MDIMain.Reportsmenu.Enabled = True
                MDIMain.Utilitiesmenu.Enabled = True
                MDIMain.HelpMenu.Enabled = True

                Me.Close()

            End If
        Else
            If LCase(txtpassword.Text.Trim) = LCase(txtretypepassword.Text.Trim) Then
                tempmsg = vbYes
                If txtpassword.Text.Trim = "" Then tempmsg = MessageBox.Show("Password Disabled, Continue?", "", MessageBoxButtons.YesNo)
                If tempmsg = vbYes Then

                    'getting values in variable
                    cmppassword = txtpassword.Text.Trim

                    'add yearmaster
                    Me.Hide()
                    Dim objyear As New yearmaster
                    objyear.EDIT = EDIT
                    objyear.ShowDialog()
                    'If (chldyearmaster.IsMdiChild = False) Then
                    '    If chldyearmaster.IsDisposed = True Then
                    '        chldyearmaster = New yearmaster
                    '    End If
                    '    chldyearmaster.MdiParent = MDIParent1
                    '    chldyearmaster.Show()
                    'Else
                    '    chldyearmaster.BringToFront()
                    '    chldyearmaster.Show()
                    'End If
                End If
            Else
                MessageBox.Show("Password Incorrect")
                txtpassword.Clear()
                txtretypepassword.Clear()
                txtpassword.Focus()
            End If
        End If
    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        End
    End Sub

    Private Sub txtpassword_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtpassword.KeyPress
        enterkeypress(e, Me)
    End Sub

    Private Sub txtretypepassword_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtretypepassword.KeyPress
        enterkeypress(e, Me)
    End Sub

    Private Sub companypasswd_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub txtpassword_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtpassword.KeyDown
        Try
            If e.KeyCode = Keys.Enter And cmdback.Visible = False Then Call cmdnext_Click(sender, e)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class