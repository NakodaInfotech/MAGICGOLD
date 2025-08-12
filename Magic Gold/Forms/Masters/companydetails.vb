Imports System.Data.OleDb
Imports System.IO

Public Class companydetails


    Sub fillcmp(ByVal condition As String)
        Try
            Dim whereclause As String = ""
            cmd = New OleDbCommand("select distinct user_cmpid from UserMaster WHERE User_Name = '" & UserName & "'" & condition, OGCONN)
            If OGCONN.State = ConnectionState.Open Then OGCONN.Close()
            OGCONN.Open()
            dr = cmd.ExecuteReader
            If dr.HasRows Then
                While (dr.Read)
                    If whereclause = "" Then
                        whereclause = " AND CMP_NO IN (" & dr(0)
                    Else
                        whereclause = whereclause & "," & dr(0)
                    End If
                End While
                whereclause = whereclause & ")"
            End If
            OGCONN.Close()
            dr.Close()


            cmd = New OleDbCommand("select cmp_no,cmp_name from cmpmaster WHERE 1 = 1 " & whereclause & " ORDER BY CMP_NAME", OGCONN)
            If OGCONN.State = ConnectionState.Open Then OGCONN.Close()
            OGCONN.Open()
            dr = cmd.ExecuteReader
            If dr.HasRows Then
                gridcmp.RowCount = 0
                While (dr.Read)
                    gridcmp.Rows.Add(dr(1), dr(0))
                End While
            End If
            OGCONN.Close()
            dr.Close()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        End
    End Sub

    Sub OPENCMP()
        Try
            For Each row As DataGridViewRow In gridcmp.SelectedRows

                tempcmpname = row.Cells(0).Value.ToString
                CmpName = row.Cells(0).Value.ToString
                tempcmpid = row.Cells(1).Value.ToString
                CMPID = row.Cells(1).Value.ToString


                'getting tempyearid
                cmd = New OleDbCommand("select * from yearmaster where year_cmpno = " & tempcmpid, OGCONN)
                If OGCONN.State = ConnectionState.Open Then
                    OGCONN.Close()
                End If
                OGCONN.Open()
                dr = cmd.ExecuteReader
                dr.Read()
                tempyearid = dr(0)
                tempyear = dr(2) & "  " & dr(3)
                startdate = dr(2)
                enddate = dr(3)
                OGCONN.Close()
                dr.Close()


                'getting USERID WITH RESPECT TO COMPANY SELECTED
                cmd = New OleDbCommand("select USER_ID, IIF(ISNULL(DEPARTMENT_NAME) = 'TRUE','', DEPARTMENT_NAME) AS DEPARTMENT , IIF(ISNULL(DEPARTMENT_ID) = 'TRUE',0, DEPARTMENT_ID) AS DEPARTMENTID from USERMASTER LEFT OUTER JOIN DEPARTMENTMASTER ON  DEPARTMENTMASTER.DEPARTMENT_ID = USERMASTER.USER_DEPARTMENTID  where USER_CMPID = " & tempcmpid & " AND USER_NAME = '" & tempusername & "'", OGCONN)
                If OGCONN.State = ConnectionState.Open Then OGCONN.Close()
                OGCONN.Open()
                dr = cmd.ExecuteReader
                dr.Read()
                tempuserid = dr(0)
                USERID = dr(0)
                If IsDBNull(dr("DEPARTMENT")) = True Then USERDEPARTMENT = "" Else USERDEPARTMENT = dr("DEPARTMENT")
                If IsDBNull(dr("DEPARTMENTID")) = True Then USERDEPARTMENTID = 0 Else USERDEPARTMENTID = dr("DEPARTMENTID")
                OGCONN.Close()
                dr.Close()


                'GETTING RIGHTS IN DATATABLE
                If OGCONN.State = ConnectionState.Open Then OGCONN.Close()
                OGCONN.Open()
                tempcmd = New OleDbCommand(" SELECT User_formName as [FormName], User_add as [Add], User_Edit as [Edit], User_View as [View], User_Delete as [Delete] FROM USERMASTER_RIGHTS  WHERE USER_ID = " & Userid & " AND USER_CMPID = " & CMPID, OGCONN)
                da = New OleDbDataAdapter(tempcmd)
                da.Fill(USERRIGHTS)


               


                'add companypassword 
                Dim objcmppass As New companypasswd
                objcmppass.lblretype.Visible = False
                objcmppass.txtretypepassword.Visible = False
                objcmppass.cmdnext.Text = "&Ok"
                objcmppass.cmdback.Visible = False
                objcmppass.Show()

                openconn(tempcmpname)

                'GETTING BLOCKDATE DATA
                If conn.State = ConnectionState.Open Then conn.Close()
                conn.Open()
                tempcmd = New OleDbCommand(" SELECT BLOCKDATE, APPLYBLOCK FROM BLOCKDATE", conn)
                tempdr = tempcmd.ExecuteReader
                If tempdr.HasRows = True Then
                    While (tempdr.Read)
                        BLOCKEDDATE = Format(tempdr(0), "dd/MM/yyyy")
                        APPLYBLOCKDATE = tempdr(1)
                    End While
                End If

                'GETTING ENTRY PASSWORD
                If conn.State = ConnectionState.Open Then conn.Close()
                conn.Open()
                tempcmd = New OleDbCommand(" SELECT ENTRYPASS FROM DATEPASS", conn)
                tempdr = tempcmd.ExecuteReader
                If tempdr.HasRows = True Then
                    While (tempdr.Read)
                        ENTRYPASSWORD = tempdr(0)
                    End While
                End If

                Me.Close()
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdopen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdopen.Click
        OPENCMP()
    End Sub

    Private Sub gridcmp_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridcmp.CellDoubleClick
        If e.RowIndex >= 0 And e.RowIndex < gridcmp.RowCount Then OPENCMP()
    End Sub

    Private Sub cmdcreate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcreate.Click
        Try
            Dim obj As New companymaster
            obj.ShowDialog()
            fillcmp("")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub companydetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.Alt = True And e.KeyCode = Windows.Forms.Keys.N) Then
                Dim objcmpmaster As New companymaster
                objcmpmaster.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdedit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdedit.Click
        Try
            Dim OBJCMP As New companymaster
            OBJCMP.cmdedit.Enabled = False
            OBJCMP.EDIT = True
            Dim ROW As DataGridViewRow = gridcmp.CurrentRow
            tempcmpname = ROW.Cells(0).Value.ToString
            CmpName = ROW.Cells(0).Value.ToString
            tempcmpid = ROW.Cells(1).Value.ToString
            CMPID = ROW.Cells(1).Value.ToString
            OBJCMP.ShowDialog()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridcmp_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridcmp.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then If gridcmp.SelectedRows.Count > 0 Then Call cmdopen_Click(sender, e)
        Catch ex As Exception

            Throw ex
        End Try
    End Sub

    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddelete.Click
        Try
            If gridcmp.RowCount <= 0 Then Exit Sub
            If gridcmp.SelectedRows.Count <= 0 Then Exit Sub
            If MsgBox("Wish to Delete Company?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            If MsgBox("Are you sure Delete Company?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            cmd = New OleDbCommand("DELETE FROM YEARMASTER WHERE YEAR_CMPNO = " & gridcmp.CurrentRow.Cells(GCMPID.Index).Value, OGCONN)
            If OGCONN.State = ConnectionState.Open Then OGCONN.Close()
            OGCONN.Open()
            cmd.ExecuteNonQuery()

            cmd = New OleDbCommand("DELETE FROM CMPMASTER WHERE CMP_NO = " & gridcmp.CurrentRow.Cells(GCMPID.Index).Value, OGCONN)
            If OGCONN.State = ConnectionState.Open Then OGCONN.Close()
            OGCONN.Open()
            cmd.ExecuteNonQuery()

            'DELETE FOLDER ALSO
            If Directory.Exists(Application.StartupPath & "\Database\" & gridcmp.CurrentRow.Cells(GCMPNAME.Index).Value) Then Directory.Delete(Application.StartupPath & "\Database\" & gridcmp.CurrentRow.Cells(GCMPNAME.Index).Value, True)

            fillcmp("")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub companydetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim tempdate As Date
        tempcondition = ""

        If UserName <> "Admin" Then
            cmdedit.Enabled = False
            cmddelete.Enabled = False
            cmdcreate.Enabled = False
            cmdbackup.Enabled = False
        End If

        fillcmp("")

        '********************** FOR SECURITY ***************************************
        cmd = New OleDbCommand("select name,dated from security where name = 'IRFAN'", conn)
        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Open()
        dr = cmd.ExecuteReader
        dr.Read()
        tempdate = Format(Date.Now, "dd/MM/yyyy")
        If dr.HasRows = True Then

            If tempdate = Format(dr(1), "dd/MM/yyyy") Then
                'clearing array
                For i = 1 To 100
                    tempcol(i) = ""
                    tempval(i) = ""
                Next
                tempcol(0) = "name"
                tempcol(1) = "dated"
                tempval(0) = "'GULKIT'"
                tempval(1) = "'" & Format(Date.Now, "dd/MM/yyyy") & "'"
                tempcondition = " where name='IRFAN'"
                modify("security", tempcol, tempval, tempcondition)
            ElseIf dr(0).ToString = "GULKIT" Then
                MsgBox("Trial Version Expired")
                End
            End If
        Else
            MsgBox("Trial Version Expired")
            End
        End If
        '********************** FOR SECURITY ***************************************
    End Sub
End Class