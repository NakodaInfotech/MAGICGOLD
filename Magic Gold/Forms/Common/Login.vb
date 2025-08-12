Imports System.Data.oledb

Public Class LoginForm

    ' TODO: Insert code to perform custom authentication using the provided username and password 
    ' (See http://go.microsoft.com/fwlink/?LinkId=35339).  
    ' The custom principal can then be attached to the current thread's principal as follows: 
    '     My.User.CurrentPrincipal = CustomPrincipal
    ' where CustomPrincipal is the IPrincipal implementation used to perform authentication. 
    ' Subsequently, My.User will return identity information encapsulated in the CustomPrincipal object
    ' such as the username, display name, etc.

    Sub CHECKVERSION()
        Try

            Dim dt As New DataTable()
            If tempconn.State = ConnectionState.Open Then tempconn.Close()
            tempconn.Open()
            tempcmd = New OleDbCommand("select VERSION_NO AS VERSION, VERSION_CLIENTNAME AS CLIENTNAME from VERSION ", tempconn)
            da = New OleDbDataAdapter(tempcmd)
            da.Fill(dt)
            Dim TEMPDATE As Date
            ClientName = dt.Rows(0).Item("CLIENTNAME")

            If ClientName = "ADITYA" Then
                If Now.Date > DateTime.Parse("15.03.2026 00:00") Then
                    tempcmd = New OleDbCommand("UPDATE VERSION SET VERSION_NO=1.0.0000", tempconn)
                    tempcmd.ExecuteNonQuery()
                    GoTo LINE1
                End If
            ElseIf ClientName = "BHAVANI" Then
                If Now.Date > DateTime.Parse("15.10.2025 00:00") Then
                    tempcmd = New OleDbCommand("UPDATE VERSION SET VERSION_NO=1.0.0000", tempconn)
                    tempcmd.ExecuteNonQuery()
                    GoTo LINE1
                End If
            ElseIf ClientName = "CHAINCRAFTS" Then  'GIRISH BHAI CHENNAI)
                If Now.Date > DateTime.Parse("15.06.2026 00:00") Then
                    tempcmd = New OleDbCommand("UPDATE VERSION SET VERSION_NO=1.0.0000", tempconn)
                    tempcmd.ExecuteNonQuery()
                    GoTo LINE1
                End If
                'ElseIf ClientName = "CHETANCHAINS" Then
                'If Now.Date > DateTime.Parse("15.11.2024 00:00") Then
                '    tempcmd = New OleDbCommand("UPDATE VERSION SET VERSION_NO=1.0.0000", tempconn)
                '    tempcmd.ExecuteNonQuery()
                '    GoTo LINE1
                'End If

                'ElseIf ClientName = "DEEPAK" Then
                '    HIDEMFG = True
                '    If Now.Date > DateTime.Parse("15.11.2025 00:00") Then
                '        tempcmd = New OleDbCommand("UPDATE VERSION SET VERSION_NO=1.0.0000", tempconn)
                '        tempcmd.ExecuteNonQuery()
                '        GoTo LINE1
                '    End If
                'ElseIf ClientName = "CNC" Then
                '    If Now.Date > DateTime.Parse("15.09.2023 00:00") Then
                '        tempcmd = New OleDbCommand("UPDATE VERSION SET VERSION_NO=1.0.0000", tempconn)
                '        tempcmd.ExecuteNonQuery()
                '        GoTo LINE1
                '    End If

                'ElseIf ClientName = "CNJ" Then
                '    If Now.Date > DateTime.Parse("15.04.2025 00:00") Then
                '        tempcmd = New OleDbCommand("UPDATE VERSION SET VERSION_NO=1.0.0000", tempconn)
                '        tempcmd.ExecuteNonQuery()
                '        GoTo LINE1
                '    End If
            ElseIf ClientName = "GAUTAM" Then
                If Now.Date > DateTime.Parse("15.06.2026 00:00") Then
                    tempcmd = New OleDbCommand("UPDATE VERSION SET VERSION_NO=1.0.0000", tempconn)
                    tempcmd.ExecuteNonQuery()
                    GoTo LINE1
                End If
                'ElseIf ClientName = "GR" Then
                '    If Now.Date > DateTime.Parse("15.04.2024 00:00") Then
                '        tempcmd = New OleDbCommand("UPDATE VERSION SET VERSION_NO=1.0.0000", tempconn)
                '        tempcmd.ExecuteNonQuery()
                '        GoTo LINE1
                '    End If
            ElseIf ClientName = "KANAK" Then
                If Now.Date > DateTime.Parse("15.04.2026 00:00") Then
                    tempcmd = New OleDbCommand("UPDATE VERSION SET VERSION_NO=1.0.0000", tempconn)
                    tempcmd.ExecuteNonQuery()
                    GoTo LINE1
                End If
            ElseIf ClientName = "KHUSHALI" Then
                ALLOWLABELLING = True
                If Now.Date > DateTime.Parse("15.03.2026 00:00") Then
                    tempcmd = New OleDbCommand("UPDATE VERSION SET VERSION_NO=1.0.0000", tempconn)
                    tempcmd.ExecuteNonQuery()
                    GoTo LINE1
                End If
            ElseIf ClientName = "MIMARA" Then
                If Now.Date > DateTime.Parse("15.01.2026 00:00") Then
                    tempcmd = New OleDbCommand("UPDATE VERSION SET VERSION_NO=1.0.0000", tempconn)
                    tempcmd.ExecuteNonQuery()
                    GoTo LINE1
                End If
                'ElseIf ClientName = "MIMARAGEMS" Then
                '    If Now.Date > DateTime.Parse("15.01.2023 00:00") Then
                '        tempcmd = New OleDbCommand("UPDATE VERSION SET VERSION_NO=1.0.0000", tempconn)
                '        tempcmd.ExecuteNonQuery()
                '        GoTo LINE1
                '    End If
            ElseIf ClientName = "MONOGRAM" Then
                If Now.Date > DateTime.Parse("15.09.2025 00:00") Then
                    tempcmd = New OleDbCommand("UPDATE VERSION SET VERSION_NO=1.0.0000", tempconn)
                    tempcmd.ExecuteNonQuery()
                    GoTo LINE1
                End If
            ElseIf ClientName = "ORIENTAL" Then
                If Now.Date > DateTime.Parse("15.05.2026 00:00") Then
                    tempcmd = New OleDbCommand("UPDATE VERSION SET VERSION_NO=1.0.0000", tempconn)
                    tempcmd.ExecuteNonQuery()
                    GoTo LINE1
                End If
            ElseIf ClientName = "PREM" Then
                If Now.Date > DateTime.Parse("15.04.2026 00:00") Then
                    tempcmd = New OleDbCommand("UPDATE VERSION SET VERSION_NO=1.0.0000", tempconn)
                    tempcmd.ExecuteNonQuery()
                    GoTo LINE1
                End If
            ElseIf ClientName = "SANGAM" Then '(VIKASJI)
                If Now.Date > DateTime.Parse("15.08.2026 00:00") Then
                    tempcmd = New OleDbCommand("UPDATE VERSION SET VERSION_NO=1.0.0000", tempconn)
                    tempcmd.ExecuteNonQuery()
                    GoTo LINE1
                End If
            ElseIf ClientName = "SHASHAWAT" Then '(SUSHIL BHAI)
                If Now.Date > DateTime.Parse("15.05.2026 00:00") Then
                    tempcmd = New OleDbCommand("UPDATE VERSION SET VERSION_NO=1.0.0000", tempconn)
                    tempcmd.ExecuteNonQuery()
                    GoTo LINE1
                End If
            ElseIf ClientName = "SHWETA" Then '(KAMLESH PARMAR)
                ALLOWLABELLING = True
                If Now.Date > DateTime.Parse("15.10.2025 00:00") Then
                    tempcmd = New OleDbCommand("UPDATE VERSION SET VERSION_NO=1.0.0000", tempconn)
                    tempcmd.ExecuteNonQuery()
                    GoTo LINE1
                End If
            ElseIf ClientName = "SKYLINE" Then
                If Now.Date > DateTime.Parse("15.03.2026 00:00") Then
                    tempcmd = New OleDbCommand("UPDATE VERSION SET VERSION_NO=1.0.0000", tempconn)
                    tempcmd.ExecuteNonQuery()
                    GoTo LINE1
                End If
                'ElseIf ClientName = "TANASHA" Then
                '    ALLOWLABELLING = True
                '    If Now.Date > DateTime.Parse("15.06.2025 00:00") Then
                '        tempcmd = New OleDbCommand("UPDATE VERSION SET VERSION_NO=1.0.0000", tempconn)
                '        tempcmd.ExecuteNonQuery()
                '        GoTo LINE1
                '    End If
            ElseIf ClientName = "DEMO" Then
                If Now.Date > DateTime.Parse("15.05.2022 00:00") Then
                    tempcmd = New OleDbCommand("UPDATE VERSION SET VERSION_NO=1.0.0000", tempconn)
                    tempcmd.ExecuteNonQuery()
                    GoTo LINE1
                End If

            Else
                GoTo LINE1
            End If

            If dt.Rows.Count > 0 Then
                ClientName = dt.Rows(0).Item("CLIENTNAME")
                If dt.Rows(0).Item("VERSION") <> "1.0.009" Then
                    MsgBox("Please Install New Version", MsgBoxStyle.Critical)
LINE1:
                    MsgBox(" VERSION EXPIRED PLEASE CONTACT NAKODA INFOTECH ON 9987603607", MsgBoxStyle.Critical)
                    End
                End If
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            openconn("MagicGold")
            CHECKVERSION()
            EP.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If
            companydetails.Show()
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True
        If txtusername.Text.Trim.Length = 0 Then
            EP.SetError(txtusername, "Fill User Name")
            bln = False
        End If

        If txtpassword.Text.Trim.Length = 0 Then
            EP.SetError(txtpassword, "Fill Password")
            bln = False
        End If


        Dim dt As New DataTable()
        If tempconn.State = ConnectionState.Open Then tempconn.Close()
        tempconn.Open()
        tempcmd = New OleDbCommand("select User_id AS USERID, User_password AS UPASSWORD from UserMaster WHERE USER_NAME= '" & txtusername.Text.Trim & "'", tempconn)
        da = New OleDbDataAdapter(tempcmd)
        da.Fill(dt)
        If dt.Rows.Count > 0 Then
            For Each DTROW As DataRow In dt.Rows
                If txtpassword.Text.Trim <> DTROW(1).ToString Then
                    bln = False
                Else
                    Userid = DTROW(0)
                    tempuserid = DTROW(0)
                    UserName = txtusername.Text.Trim
                    tempusername = txtusername.Text.Trim
                    bln = True
                    Exit For
                End If
            Next
        Else
            EP.SetError(txtusername, "Invalid User")
            bln = False
        End If
        If bln = False Then EP.SetError(txtpassword, "Incorrect User \ Password")

        Return bln
    End Function

    Private Sub cmdcancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdcancel.Click
        End
    End Sub

    Private Sub txtusername_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtusername.KeyPress
        enterkeypress(e, Me)
    End Sub

    Private Sub txtusername_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtusername.Validated
        txtusername.Text = caps(txtusername.Text)
    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        End
    End Sub

    Private Sub txtpassword_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtpassword.KeyPress
        enterkeypress(e, Me)
    End Sub

    Private Sub LoginForm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                Me.Close()
            ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.L Then       'for SHOW REPORT
                Call cmdok_Click(sender, e)
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtpassword_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtpassword.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then If txtusername.Text.Trim <> "" And txtpassword.Text.Trim <> "" Then Call cmdok_Click(sender, e)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class