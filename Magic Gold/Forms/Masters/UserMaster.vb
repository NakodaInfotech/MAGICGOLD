
Imports System.ComponentModel
Imports System.Data.OleDb
Imports System.IO

Public Class UserMaster

    Public Uname As String
    Public edit As Boolean

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub UserMaster_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.Alt = True And e.KeyCode = Windows.Forms.Keys.S Then       'for Saving
                Call cmdok_Click(sender, e)
            ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                If errorvalid() = True Then
                    Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                    If tempmsg = vbYes Then cmdok_Click(sender, e)
                End If
                Me.Close()
            ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.D Then       'for Delete
                'Call cmddelete_Click(sender, e)
            ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.C Then       'for Clear
                Call cmdclear_Click(sender, e)
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            ElseIf e.KeyCode = Keys.Oemcomma Then
                'e.SuppressKeyPress = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillUSER(ByRef CMBUSER As ComboBox, Optional ByVal CONDITION As String = "")
        Try
            cmd = New OleDbCommand("select DISTINCT User_Name as [USERNAME] from USERMASTER WHERE USERMASTER.USER_cmpid= " & CMPID & " ORDER BY USER_NAME", OGCONN)
            If OGCONN.State = ConnectionState.Open Then OGCONN.Close()
            OGCONN.Open()
            dr = cmd.ExecuteReader
            While dr.Read()
                CMBUSER.Items.Add(dr(0))
            End While
            CMBUSER.SelectAll()
            OGCONN.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub UserMaster_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            Dim dt As New DataTable
            If edit = False Then
                fillUSER(CMBUSER)
            Else
                CMBUSER.Enabled = False
            End If
            FILLDEPARTMENT(Me, CMBDEPARTMENT, "")
            fillgrid()

            cmd = New OleDbCommand("select CMP_NAME from CMPMASTER", OGCONN)
            If OGCONN.State = ConnectionState.Open Then OGCONN.Close()
            OGCONN.Open()
            dr = cmd.ExecuteReader
            While (dr.Read())
                LSTCMP.Items.Add(dr(0).ToString)
                If dr(0) = CmpName Then LSTCMP.SetItemChecked(LSTCMP.Items.Count - 1, True)
            End While
            OGCONN.Close()

            If edit = True Then
                cmd = New OleDbCommand("select User_Password,User_email, User_tel, User_smtp, User_pop, User_smtpemail, User_smtppass, IIF(ISNULL(DEPARTMENT_NAME) = 'TRUE', '', DEPARTMENT_NAME) AS DEPARTMENT from UserMaster LEFT OUTER JOIN DEPARTMENTMASTER ON DEPARTMENTMASTER.DEPARTMENT_ID = USERMASTER.USER_DEPARTMENTID WHERE user_name = '" & Uname & "' and user_cmpid = " & CMPID, OGCONN)
                If OGCONN.State = ConnectionState.Open Then OGCONN.Close()
                OGCONN.Open()
                dr = cmd.ExecuteReader
                dr.Read()
                txtusername.Text = Uname
                txtpassword.Text = dr(0).ToString
                txtconfirmpass.Text = txtpassword.Text
                txtemail.Text = dr(1).ToString
                txttel.Text = dr(2).ToString
                txtsmtp.Text = dr(3).ToString
                txtpop.Text = dr(4).ToString
                txtsmtpemail.Text = dr(5).ToString
                txtsmtppass.Text = dr(6).ToString
                CMBDEPARTMENT.Text = dr("DEPARTMENT").ToString
                OGCONN.Close()

                LSTCMP.Enabled = False


                Dim DTUSER As New DataTable
                cmd = New OleDbCommand(" SELECT DISTINCT  User_formName as [FormName], User_add as Addf, User_Edit as Editf, User_View as Viewf, User_Delete as Deletef FROM USERMASTER_RIGHTS INNER JOIN USERMASTER ON USERMASTER.USER_ID = USERMASTER_RIGHTS.USER_ID AND USERMASTER.USER_CMPID = USERMASTER_RIGHTS.USER_CMPID  WHERE  USERMASTER.USER_NAME = '" & Uname & "' and Usermaster.User_cmpid = " & CMPID & " ORDER BY USERMASTER_rights.USER_FORMNAME", OGCONN)
                If OGCONN.State = ConnectionState.Open Then OGCONN.Close()
                OGCONN.Open()
                da = New OleDbDataAdapter(cmd)
                da.Fill(DTUSER)
                griddetails.DataSource = DTUSER
                OGCONN.Close()

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid()
        Try
            Dim dt As New DataTable
            cmd = New OleDbCommand("select Form_Name as FormName, FORM_ADD as Addf, FORM_EDIT as Editf, FORM_VIEW as Viewf, FORM_DELETE as Deletef  from FormMaster ORDER BY FORM_NAME ", OGCONN)
            If OGCONN.State = ConnectionState.Open Then OGCONN.Close()
            OGCONN.Open()
            da = New OleDbDataAdapter(cmd)
            da.Fill(dt)
            griddetails.DataSource = dt
            OGCONN.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgriduser(ByVal name As String)
        Try
            Dim dtuser As New DataTable
            cmd = New OleDbCommand(" SELECT DISTINCT  User_formName as [FormName], User_add as Addf, User_Edit as Editf, User_View as Viewf, User_Delete as Deletef FROM USERMASTER_RIGHTS INNER JOIN USERMASTER ON USERMASTER.USER_ID = USERMASTER_RIGHTS.USER_ID AND USERMASTER.USER_CMPID = USERMASTER_RIGHTS.USER_CMPID  WHERE  USERMASTER.USER_NAME = '" & CMBUSER.Text.Trim & "' and Usermaster.User_cmpid = " & CMPID & " ORDER BY USERMASTER_rights.USER_FORMNAME", OGCONN)
            If OGCONN.State = ConnectionState.Open Then OGCONN.Close()
            OGCONN.Open()
            da = New OleDbDataAdapter(cmd)
            da.Fill(dtuser)
            griddetails.DataSource = dtuser
            OGCONN.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub griduser_ValidateRow(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles griduser.ValidateRow
        Try
            Dim DTROW As DataRowView = e.Row
            If (DTROW(0).ToString = "") Or (DTROW(1).ToString = "" And DTROW(2).ToString = "" And DTROW(3).ToString = "" And DTROW(4).ToString = "") Then
                MsgBox("Enter Details", MsgBoxStyle.Exclamation)
                e.Valid = False
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            EP.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            For i = 0 To 100
                tempcol(i) = ""
                tempval(i) = ""
            Next

            tempcol(0) = "USER_NAME"
            tempcol(1) = "USER_PASSWORD"
            tempcol(2) = "USER_EMAIL"
            tempcol(3) = "USER_TEL"
            tempcol(4) = "USER_SMTP"
            tempcol(5) = "USER_POP"
            tempcol(6) = "USER_SMTPEMAIL"
            tempcol(7) = "USER_SMTPPASS"
            tempcol(8) = "USER_DEPARTMENTID"
            tempcol(9) = "USER_CMPID"

            tempval(0) = "'" & txtusername.Text.Trim & "'"
            tempval(1) = "'" & txtpassword.Text.Trim & "'"
            tempval(2) = "'" & txtemail.Text.Trim & "'"
            tempval(3) = "'" & txttel.Text.Trim & "'"
            tempval(4) = "'" & txtsmtp.Text.Trim & "'"
            tempval(5) = "'" & txtpop.Text.Trim & "'"
            tempval(6) = "'" & txtsmtpemail.Text.Trim & "'"
            tempval(7) = "'" & txtsmtppass.Text.Trim & "'"

            'GET DEPTID
            tempcmd = New OleDbCommand("select DEPARTMENT_ID from DEPARTMENTMASTER where DEPARTMENT_NAME = '" & CMBDEPARTMENT.Text.Trim & "'", OGCONN)
            If OGCONN.State = ConnectionState.Open Then OGCONN.Close()
            OGCONN.Open()
            tempdr = tempcmd.ExecuteReader
            If tempdr.HasRows Then
                tempdr.Read()
                tempval(8) = Val(tempdr(0))
            Else
                tempval(8) = 0
            End If
            OGCONN.Close()
            tempdr.Close()


            Dim CHK As CheckedListBox.CheckedItemCollection = LSTCMP.CheckedItems
            For Each obj As Object In CHK
                cmd = New OleDbCommand("select CMP_NO from cmpmaster WHERE CMP_NAME ='" & CHK.Item(0) & "'", OGCONN)
                If OGCONN.State = ConnectionState.Open Then OGCONN.Close()
                OGCONN.Open()
                dr = cmd.ExecuteReader
                If dr.HasRows Then
                    dr.Read()
                    tempval(9) = dr(0)
                Else
                    tempval(9) = 0
                End If
                OGCONN.Close()
            Next


            'INSERT IN USERMASTER
            If edit = False Then
                If UserName <> "Admin" Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                INSERTOG("USERMASTER", tempcol, tempval)
                MessageBox.Show("Details Added")
            Else
                If UserName <> "Admin" Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                MODIFYOG("USERMASTER", tempcol, tempval, " WHERE USER_NAME = '" & Uname & "' AND USER_CMPID = " & tempval(9))
                MsgBox("Details Updated")
                edit = False
            End If


            'ADDING USER RIGHTS
            For i = 0 To 10
                tempcol(i) = ""
                tempval(i) = ""
            Next
            tempcol(0) = "USER_ID"
            tempcol(1) = "USER_FORMNAME"
            tempcol(2) = "USER_ADD"
            tempcol(3) = "USER_EDIT"
            tempcol(4) = "USER_VIEW"
            tempcol(5) = "USER_DELETE"
            tempcol(6) = "USER_CMPID"


            'GET USERID
            cmd = New OleDbCommand("select USER_ID from USERMASTER WHERE USER_NAME ='" & txtusername.Text.Trim & "'", OGCONN)
            If OGCONN.State = ConnectionState.Open Then OGCONN.Close()
            OGCONN.Open()
            dr = cmd.ExecuteReader
            If dr.HasRows Then
                dr.Read()
                tempval(0) = dr(0)
            End If

            For i As Integer = 0 To griduser.RowCount - 1
                Dim dtrow As DataRow = griduser.GetDataRow(i)
                tempval(1) = "'" & dtrow(0).ToString & "'"

                If Convert.ToBoolean(dtrow(1)) = False Then
                    tempval(2) = "False"
                Else
                    tempval(2) = dtrow(1)
                End If
                If Convert.ToBoolean(dtrow(2)) = False Then
                    tempval(3) = "False"
                Else
                    tempval(3) = dtrow(2)
                End If
                If Convert.ToBoolean(dtrow(3)) = False Then
                    tempval(4) = "False"
                Else
                    tempval(4) = dtrow(3)
                End If
                If Convert.ToBoolean(dtrow(4)) = False Then
                    tempval(5) = "False"
                Else
                    tempval(5) = dtrow(4)
                End If
                tempval(6) = CMPID

                INSERTOG("USERMASTER_RIGHTS", tempcol, tempval)

            Next
            clear()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub clear()
        Try
            EP.Clear()
            txtusername.Clear()
            txtpassword.Clear()
            txtconfirmpass.Clear()
            txtemail.Clear()
            txttel.Clear()
            txtsmtp.Clear()
            txtpop.Clear()
            txtsmtpemail.Clear()
            txtsmtppass.Clear()
            CMBDEPARTMENT.Text = ""
            CMBUSER.Text = ""

            LSTCMP.Enabled = True

            griddetails.DataSource = Nothing
            For i As Integer = 0 To LSTCMP.Items.Count - 1
                LSTCMP.SetItemChecked(i, False)
            Next
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True

        If txtusername.Text.Trim.Length = 0 Then
            EP.SetError(txtusername, "Enter User Name")
            bln = False
        End If

        If txtpassword.Text.Trim.Length = 0 Then
            EP.SetError(txtpassword, "Enter Password")
            bln = False
        End If

        If txtpassword.Text.Trim <> txtconfirmpass.Text.Trim Then
            EP.SetError(txtconfirmpass, "Password Does not Match")
            txtpassword.Clear()
            txtconfirmpass.Clear()
            bln = False
        End If

        If griduser.RowCount <= 0 Then
            EP.SetError(txtusername, "Assign atleast 1 Right")
            bln = False
        End If

        If LSTCMP.CheckedItems.Count <= 0 Then
            EP.SetError(LSTCMP, "Select Company")
            bln = False
        End If

        If (edit = False) Or (edit = True And Uname <> txtusername.Text.Trim) Then
            Dim CHK As CheckedListBox.CheckedItemCollection = LSTCMP.CheckedItems
            For Each obj As Object In CHK

                Dim TCID As Integer
                cmd = New OleDbCommand("select CMP_NO from cmpmaster WHERE CMP_NAME ='" & CHK.Item(0) & "'", OGCONN)
                If OGCONN.State = ConnectionState.Open Then OGCONN.Close()
                OGCONN.Open()
                dr = cmd.ExecuteReader
                If dr.HasRows Then
                    dr.Read()
                    TCID = dr(0)
                End If
                OGCONN.Close()

                cmd = New OleDbCommand("select user_id from USERMASTER WHERE USER_NAME ='" & txtusername.Text.Trim & "' AND USER_CMPID = " & TCID, OGCONN)
                If OGCONN.State = ConnectionState.Open Then OGCONN.Close()
                OGCONN.Open()
                dr = cmd.ExecuteReader
                If dr.HasRows Then
                    EP.SetError(txtusername, "User Already Exists In selected Company")
                    bln = False
                End If
                OGCONN.Close()

            Next
        End If

        Return bln

    End Function

    Private Sub OpenToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripButton.Click
        Try
            Dim objudet As New UserDetails
            objudet.MdiParent = MDIMain
            objudet.Show()
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SaveToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripButton.Click
        Call cmdok_Click(sender, e)
    End Sub

    Private Sub LSTCMP_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles LSTCMP.ItemCheck
        Try
            If e.NewValue = CheckState.Checked And LSTCMP.CheckedItems.Count > 0 Then
                e.NewValue = CheckState.Unchecked
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        clear()
        edit = False
        txtusername.Focus()
    End Sub

    Private Sub ToolStripdelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripdelete.Click
        'Try
        '    If edit = True Then
        '        Dim tempmsg As Integer = MsgBox("Delete User Permanently?", MsgBoxStyle.YesNo, "TRAVELMATE")
        '        If tempmsg = vbYes Then

        '            Dim OBJUser As New ClsUserMaster
        '            Dim ALPARAVAL As New ArrayList

        '            ALPARAVAL.Add(txtusername.Text.Trim)
        '            ALPARAVAL.Add(CmpId)

        '            OBJUser.alParaval = ALPARAVAL
        '            Dim DT As DataTable = OBJUser.DELETE()
        '            MsgBox(DT.Rows(0).Item(0).ToString)

        '            clear()

        '        End If

        '    End If
        'Catch ex As Exception
        '    Throw ex
        'End Try
    End Sub

    Private Sub chkall_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkall.CheckedChanged
        Try
            Dim dt As DataTable = griddetails.DataSource
            For Each row As DataRow In dt.Rows
                row.Item("Addf") = chkall.CheckState
                row.Item("Editf") = chkall.CheckState
                row.Item("Viewf") = chkall.CheckState
                row.Item("Deletef") = chkall.CheckState
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBUSER_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBUSER.Validated
        Try
            If CMBUSER.Text.Trim <> "" Then
                Dim TEMPMSG As Integer = MsgBox("Copy Rights of " & CMBUSER.Text.Trim & "?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbYes Then fillgriduser(CMBUSER.Text.Trim)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBDEPARTMENT_Enter(sender As Object, e As EventArgs) Handles CMBDEPARTMENT.Enter
        Try
            If CMBDEPARTMENT.Text.Trim = "" Then FILLDEPARTMENT(Me, CMBDEPARTMENT, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBDEPARTMENT_Validating(sender As Object, e As CancelEventArgs) Handles CMBDEPARTMENT.Validating
        Try
            If CMBDEPARTMENT.Text.Trim <> "" Then DEPARTMENTVALIDATE(CMBDEPARTMENT, e, Me, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class