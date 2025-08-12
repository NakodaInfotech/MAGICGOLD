Imports System.Data.oledb

Public Class yearmaster

    Public EDIT As Boolean = False
    Dim fsys As New FileIO.FileSystem

    Private Sub cmdback_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdback.Click
        Me.Hide()
        'add companypassword    
        If (chldcmppassword.IsMdiChild = False) Then
            If chldcmppassword.IsDisposed = True Then
                chldcmppassword = New companypasswd
            End If
            chldcmppassword.MdiParent = MDIMain
            chldcmppassword.EDIT = EDIT
            chldcmppassword.Show()
        Else
            chldcmppassword.BringToFront()
            chldcmppassword.Show()
        End If
    End Sub

    Private Sub yearmaster_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If edit = False Then
            startdate.Value = "1/04/" & Now.Year
            enddate.Value = "31/03/" & Now.Year + 1
        ElseIf edit = True Then

            cmd = New oledbCommand("select * from yearmaster where year_id = " & tempyearid, conn)
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
            conn.Open()
            dr = cmd.ExecuteReader
            dr.Read()
            startdate.Value = dr(2)
            enddate.Value = dr(3)

            startdate.Enabled = False
            enddate.Enabled = False

        End If
    End Sub

    Private Sub cmdfinish_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdfinish.Click

        For i = 0 To 100
            tempcol(i) = ""
            tempval(i) = ""
        Next

        'adding values in database
        tempcol(0) = "cmp_name"
        tempcol(1) = "cmp_legalname"
        tempcol(2) = "cmp_cstno"
        tempcol(3) = "cmp_vatno"
        tempcol(4) = "cmp_panno"
        tempcol(5) = "cmp_add1"
        tempcol(6) = "cmp_add2"
        tempcol(7) = "cmp_cityid"
        tempcol(8) = "cmp_stateid"
        tempcol(9) = "cmp_zipcode"
        tempcol(10) = "cmp_countryid"
        tempcol(11) = "cmp_tel1"
        tempcol(12) = "cmp_fax"
        tempcol(13) = "cmp_email"
        tempcol(14) = "cmp_website"
        tempcol(15) = "cmp_password"
        tempcol(16) = "cmp_prop"
        tempcol(17) = "cmp_autho"
        tempcol(18) = "cmp_partner"
        tempcol(19) = "cmp_propautho"
        tempcol(20) = "cmp_displayedname"
        tempcol(21) = "cmp_invinitials"
        tempcol(22) = "cmp_userid"


        tempval(0) = "'" & tempcmpname & "'"
        tempval(1) = "'" & cmplegalname & "'"
        tempval(2) = "'" & cmpcstno & "'"
        tempval(3) = "'" & cmpvatno & "'"
        tempval(4) = "'" & cmppanno & "'"
        tempval(5) = "'" & cmpadd1 & "'"
        tempval(6) = "'" & cmpadd2 & "'"
        tempval(7) = "'" & tempcityid & "'"
        tempval(8) = "'" & tempstateid & "'"
        tempval(9) = "'" & cmpzip & "'"
        tempval(10) = "'" & tempcountryid & "'"
        tempval(11) = "'" & cmptel1 & "'"
        tempval(12) = "'" & cmpfax & "'"
        tempval(13) = "'" & cmpemail & "'"
        tempval(14) = "'" & cmpwebsite & "'"
        tempval(15) = "'" & cmppassword & "'"
        tempval(16) = "'" & cmpprop & "'"
        tempval(17) = "'" & cmpautho & "'"
        tempval(18) = "'" & cmppartner & "'"
        tempval(19) = "'" & cmppropautho & "'"
        tempval(20) = "'" & cmpdisplayedname & "'"
        tempval(21) = "'" & cmpinvinitials & "'"
        tempval(22) = "'" & tempuserid & "'"

        If edit = False Then

            insert("cmpmaster", tempcol, tempval)

            'clearing array
            For i = 1 To 100
                tempcol(i) = ""
                tempval(i) = ""
            Next

            'getting tempcmpid
            cmd = New OleDbCommand("select cmp_no from cmpmaster where cmp_name = '" & tempcmpname & "'", conn)
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Open()
            dr = cmd.ExecuteReader
            dr.Read()
            tempcmpid = dr(0)
            conn.Close()
            dr.Close()


            tempcol(0) = "year_cmpno"
            tempcol(1) = "year_startdate"
            tempcol(2) = "year_enddate"
            tempcol(3) = "year_userid"


            tempval(0) = "'" & tempcmpid & "'"
            tempval(1) = "'" & Format(startdate.Value, "MM/dd/yyyy") & "'"
            tempval(2) = "'" & Format(enddate.Value, "MM/dd/yyyy") & "'"
            tempval(3) = "'" & tempuserid & "'"

            insert("yearmaster", tempcol, tempval)


            INSERTUSER()


            Me.Hide()

            'creating folder
            MkDir(Application.StartupPath & "\Database\" & tempcmpname)
            My.Computer.FileSystem.CopyFile(Application.StartupPath & "\Database\MagicGold\MagicGold.mdb", Application.StartupPath & "\Database\" & tempcmpname & "\MagicGold.mdb")
            FileIO.FileSystem.MoveFile(Application.StartupPath & "\Database\" & tempcmpname & "\MagicGold.mdb", Application.StartupPath & "\Database\" & tempcmpname & "\" & tempcmpname & ".mdb")

            progressbar.ShowDialog()

        ElseIf edit = True Then

            'getting OLDCMPNAME
            cmd = New OleDbCommand("select CMP_NAME from cmpmaster where cmp_NO = " & tempcmpid, OGCONN)
            If OGCONN.State = ConnectionState.Open Then OGCONN.Close()
            OGCONN.Open()
            dr = cmd.ExecuteReader
            dr.Read()

            'CHECK WHETHER OLDNAME <> NEW NAME
            'IF FALSE THEN RENAME THE DIRECTORY
            If tempcmpname <> dr(0) Then
                FileIO.FileSystem.RenameDirectory(Application.StartupPath & "\Database\" & dr(0), tempcmpname)
                FileIO.FileSystem.RenameFile(Application.StartupPath & "\Database\" & tempcmpname & "\" & dr(0) & ".mdb", tempcmpname & ".mdb")
            End If
            OGCONN.Close()
            dr.Close()

            tempcondition = " where cmp_no = " & tempcmpid
            modify("cmpmaster", tempcol, tempval, tempcondition)
            Me.Close()

        End If

    End Sub

    Sub INSERTUSER()
        Try
            'INSERT IN USERMASTER FOR ADMIN
            'clearing array
            For i = 0 To 10
                tempcol(i) = ""
                tempval(i) = ""
            Next
            tempcol(0) = "USER_NAME"
            tempcol(1) = "USER_PASSWORD"
            tempcol(2) = "USER_CMPID"


            tempval(0) = "'Admin'"
            tempval(1) = "'2022'"
            tempval(2) = "'" & tempcmpid & "'"

            insert("USERMASTER", tempcol, tempval)


            'getting USERID
            cmd = New OleDbCommand("select USER_ID from USERMASTER where USER_NAME = '" & tempusername & "' AND USER_CMPID = " & tempcmpid, conn)
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Open()
            dr = cmd.ExecuteReader
            dr.Read()
            tempuserid = dr(0)
            Userid = dr(0)
            conn.Close()
            dr.Close()

            For i = 0 To 5
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

            tempval(0) = Userid
            tempval(2) = "TRUE"
            tempval(3) = "TRUE"
            tempval(4) = "TRUE"
            tempval(5) = "TRUE"
            tempval(6) = tempcmpid

            'ADDING DATA IN USER_RIGHTS
            For A As Integer = 0 To 15

                If A = 0 Then
                    tempval(1) = "'GROUP MASTER'"
                    GoTo LINE1
                ElseIf A = 1 Then
                    tempval(1) = "'ACCOUNTS MASTER'"
                    GoTo LINE1
                ElseIf A = 2 Then
                    tempval(1) = "'ITEM MASTER'"
                    GoTo LINE1
                ElseIf A = 3 Then
                    tempval(1) = "'TAX MASTER'"
                    GoTo LINE1
                ElseIf A = 4 Then
                    tempval(1) = "'VOUCHERS'"
                    GoTo LINE1
                ElseIf A = 5 Then
                    tempval(1) = "'MELTING'"
                    GoTo LINE1
                ElseIf A = 6 Then
                    tempval(1) = "'MANUFACTURING'"
                    GoTo LINE1
                ElseIf A = 7 Then
                    tempval(1) = "'SALE ORDER'"
                    GoTo LINE1
                ElseIf A = 8 Then
                    tempval(1) = "'ACCOUNT REPORTS'"
                    GoTo LINE1
                ElseIf A = 9 Then
                    tempval(1) = "'STOCK REPORTS'"
                    GoTo LINE1
                ElseIf A = 10 Then
                    tempval(1) = "'MFG REPORTS'"
                    GoTo LINE1
                ElseIf A = 11 Then
                    tempval(1) = "'JOURNAL'"
                    GoTo LINE1
                ElseIf A = 12 Then
                    tempval(1) = "'CASH'"
                    GoTo LINE1
                ElseIf A = 13 Then
                    tempval(1) = "'STOCK TRANSFER'"
                    GoTo LINE1
                ElseIf A = 14 Then
                    tempval(1) = "'FILLING'"
                    GoTo LINE1
                ElseIf A = 15 Then
                    tempval(1) = "'POLISH'"
                    GoTo LINE1
                End If
LINE1:
                insert("USERMASTER_RIGHTS", tempcol, tempval)
            Next

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub enddate_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles enddate.KeyDown
        If e.KeyCode = 13 Then
            SendKeys.Send("{Tab}")
            e.Handled = False
        End If
    End Sub

    Private Sub startdate_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles startdate.KeyDown
        If e.KeyCode = 13 Then
            SendKeys.Send("{Tab}")
            e.Handled = False
        End If
    End Sub

    Private Sub yearmaster_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
End Class