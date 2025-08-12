Imports System.Data.OleDb
Imports System.Net.Mail
Imports System.Net.Configuration
Imports System.Net.NetworkInformation
Imports System.Net.Security

Module functions

    Function GETBALANCEWT(NAME As String, TILLDATE As Date) As Double
        Try
            Dim NETTWT As Double = 0
            dt = New DataTable()
            If tempconn.State = ConnectionState.Open Then
                tempconn.Close()
            End If
            tempconn.Open()

            tempcmd = New OleDbCommand("SELECT SUM(DR) AS DR, SUM(CR) AS CR, SUM(AMTDR) AS AMTDR, SUM(AMTCR) AS AMTCR FROM (SELECT SUM(ACCOUNT_NETTWT) AS DR, 0 AS CR, SUM(ACCOUNT_AMOUNT) AS AMTDR, 0 AS AMTCR FROM ACCOUNTMAST WHERE ACCOUNT_BALORJAMAORPAID= 'Jama' AND ACCOUNT_DATE <= #" & Format(TILLDATE.Date, "MM/dd/yyyy") & "# AND ACCOUNT_LEDGERCODE = '" & NAME & "' UNION ALL SELECT 0 AS DR, SUM(ACCOUNT_NETTWT) AS CR, 0 AS AMTDR, SUM(ACCOUNT_AMOUNT) AS AMTCR FROM ACCOUNTMAST WHERE ACCOUNT_BALORJAMAORPAID = 'Balance' AND ACCOUNT_DATE <= #" & Format(TILLDATE.Date, "MM/dd/yyyy") & "# AND ACCOUNT_LEDGERCODE = '" & NAME & "') AS T ", tempconn)
            If tempconn.State = ConnectionState.Open Then
                tempconn.Close()
            End If
            da = New OleDbDataAdapter(tempcmd)
            da.Fill(dt)
            NETTWT = Format(Val(dt.Rows(0).Item("DR")) - Val(dt.Rows(0).Item("CR")), "0.000")
            tempconn.Close()
            da.Dispose()
            Return NETTWT
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Function GETBALANCEAMT(NAME As String, TILLDATE As Date) As Double
        Try
            Dim AMT As Double = 0
            dt = New DataTable()
            If tempconn.State = ConnectionState.Open Then
                tempconn.Close()
            End If
            tempconn.Open()

            tempcmd = New OleDbCommand("SELECT SUM(DR) AS DR, SUM(CR) AS CR, SUM(AMTDR) AS AMTDR, SUM(AMTCR) AS AMTCR FROM (SELECT SUM(ACCOUNT_NETTWT) AS DR, 0 AS CR, SUM(ACCOUNT_AMOUNT) AS AMTDR, 0 AS AMTCR FROM ACCOUNTMAST WHERE ACCOUNT_BALORJAMAORPAID= 'Jama' AND ACCOUNT_DATE <= #" & Format(TILLDATE.Date, "MM/dd/yyyy") & "# AND ACCOUNT_LEDGERCODE = '" & NAME & "' UNION ALL SELECT 0 AS DR, SUM(ACCOUNT_NETTWT) AS CR, 0 AS AMTDR, SUM(ACCOUNT_AMOUNT) AS AMTCR FROM ACCOUNTMAST WHERE ACCOUNT_BALORJAMAORPAID = 'Balance' AND ACCOUNT_DATE <= #" & Format(TILLDATE.Date, "MM/dd/yyyy") & "# AND ACCOUNT_LEDGERCODE = '" & NAME & "') AS T ", tempconn)
            If tempconn.State = ConnectionState.Open Then
                tempconn.Close()
            End If
            da = New OleDbDataAdapter(tempcmd)
            da.Fill(dt)
            AMT = Format(Val(dt.Rows(0).Item("AMTDR")) - Val(dt.Rows(0).Item("AMTCR")), "0.000")
            tempconn.Close()
            da.Dispose()
            Return AMT
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Sub fillcmb(ByVal cmb As ComboBox, ByVal fieldname As String, ByVal tablename As String, ByVal condition As String)

        cmd = New OleDbCommand("select " & fieldname & " from " & tablename & condition, conn)
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If
        conn.Open()
        dr = cmd.ExecuteReader
        If dr.HasRows Then
            cmb.Items.Clear()
            While (dr.Read)
                cmb.Items.Add(dr(0))
            End While

        End If

    End Sub

    Sub fillgridcmb(ByVal tablename As String, ByVal columnname As String, ByVal cmb As DataGridViewComboBoxColumn, ByVal condition As String)

        tempcmd = New OleDbCommand("select " & columnname & " from " & tablename & condition, tempconn)
        If tempconn.State = ConnectionState.Open Then
            tempconn.Close()
        End If
        tempconn.Open()
        tempdr = tempcmd.ExecuteReader
        If tempdr.HasRows Then
            cmb.Items.Clear()
            'cmb.Items.Add("")
            While (tempdr.Read())
                cmb.Items.Add(uppercase(tempdr(0).ToString))
            End While
        End If
        tempconn.Close()
    End Sub

    Sub FILLDEPARTMENT(ByVal FRM As System.Windows.Forms.Form, ByVal CMB As ComboBox, ByVal CONDITION As String)
        Try
            dt = New DataTable()
            If OGCONN.State = ConnectionState.Open Then OGCONN.Close()
            OGCONN.Open()
            cmd = New OleDbCommand("select DEPARTMENTMASTER.DEPARTMENT_NAME AS DEPT FROM DEPARTMENTMASTER WHERE 1=1 " & CONDITION, OGCONN)
            da = New OleDbDataAdapter(cmd)
            da.Fill(dt)
            CMB.DataSource = dt
            CMB.DisplayMember = "DEPT"
            CMB.Text = ""
            OGCONN.Close()
            da.Dispose()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub DEPARTMENTVALIDATE(ByRef CMBDEPARTMENT As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form, ByVal WHERECLAUSE As String)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBDEPARTMENT.Text.Trim <> "" Then
                CMBDEPARTMENT.Text = UCase(CMBDEPARTMENT.Text)
                dt = New DataTable
                cmd = New OleDbCommand("select DEPARTMENTMASTER.DEPARTMENT_NAME AS DEPARTMENT from DEPARTMENTMASTER WHERE 1=1 AND DEPARTMENTMASTER.DEPARTMENT_NAME = '" & CMBDEPARTMENT.Text.Trim & "'" & WHERECLAUSE, OGCONN)
                da = New OleDbDataAdapter(cmd)
                da.Fill(dt)
                If dt.Rows.Count = 0 Then
                    Dim a As String = CMBDEPARTMENT.Text.Trim
                    Dim tempmsg As Integer = MsgBox("DEPARTMENT not present, Add New?", MsgBoxStyle.YesNo, "")
                    If tempmsg = vbYes Then
                        CMBDEPARTMENT.Text = a
                        Dim OBJDEPARTMENT As New SizeMaster
                        OBJDEPARTMENT.FRMSTRING = "DEPARTMENT"
                        OBJDEPARTMENT.txtname.Text = CMBDEPARTMENT.Text.Trim()
                        OBJDEPARTMENT.ShowDialog()

                        dt = New DataTable
                        cmd = New OleDbCommand("select DEPARTMENTMASTER.DEPARTMENT_NAME AS DEPARTMENT from DEPARTMENTMASTER WHERE 1=1 AND DEPARTMENTMASTER.DEPARTMENT_NAME = '" & CMBDEPARTMENT.Text.Trim & "'" & WHERECLAUSE, OGCONN)
                        da = New OleDbDataAdapter(cmd)
                        da.Fill(dt)
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As New DataTable
                            dt1 = CMBDEPARTMENT.DataSource
                            If CMBDEPARTMENT.DataSource <> Nothing Then
line1:
                                If dt1.Rows.Count > 0 Then
                                    dt1.Rows.Add(CMBDEPARTMENT.Text.Trim)
                                    CMBDEPARTMENT.Text = a
                                End If
                            End If
                        End If
                        e.Cancel = True
                    Else
                        e.Cancel = True
                        Exit Sub
                    End If
                End If
            End If
        Catch ex As Exception
            GoTo line1
            Throw ex
        End Try
    End Sub

    Sub fillname(ByVal frm As System.Windows.Forms.Form, ByVal cmb As ComboBox, ByVal condition As String)
        Try
            dt = New DataTable()
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
            conn.Open()
            cmd = New OleDbCommand("select ledgermaster.ledger_code AS CODE from ledgermaster inner join groupmaster on groupmaster.group_id = ledgermaster.ledger_groupid WHERE 1=1 " & condition, conn)
            da = New OleDbDataAdapter(cmd)
            da.Fill(dt)
            cmb.DataSource = dt
            cmb.DisplayMember = "CODE"
            cmb.Text = ""
            conn.Close()
            da.Dispose()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub namevalidate(ByRef cmbname As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form, ByVal WHERECLAUSE As String)
        Try
            Cursor.Current = Cursors.WaitCursor
            If cmbname.Text.Trim <> "" Then
                cmbname.Text = UCase(cmbname.Text)
                dt = New DataTable
                cmd = New OleDbCommand("select ledgermaster.ledger_code AS LEDGERCODE from ledgermaster inner join groupmaster on groupmaster.group_id = ledgermaster.ledger_groupid WHERE 1=1 AND LEDGERMASTER.LEDGER_CODE = '" & cmbname.Text.Trim & "'" & WHERECLAUSE, conn)
                da = New OleDbDataAdapter(cmd)
                da.Fill(dt)
                If dt.Rows.Count = 0 Then
                    Dim a As String = cmbname.Text.Trim
                    Dim tempmsg As Integer = MsgBox("Ledger not present, Add New?", MsgBoxStyle.YesNo, "")
                    If tempmsg = vbYes Then
                        cmbname.Text = a
                        Dim objVendormaster As New ACCOUNTMASTER
                        objVendormaster.TEMPACCNAME = cmbname.Text.Trim()
                        objVendormaster.ShowDialog()

                        dt = New DataTable
                        cmd = New OleDbCommand("select ledgermaster.ledger_code AS LEDGERCODE from ledgermaster inner join groupmaster on groupmaster.group_id = ledgermaster.ledger_groupid WHERE 1=1 AND LEDGERMASTER.LEDGER_CODE = '" & cmbname.Text.Trim & "'" & WHERECLAUSE, conn)
                        da = New OleDbDataAdapter(cmd)
                        da.Fill(dt)
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As New DataTable
                            dt1 = cmbname.DataSource
                            If cmbname.DataSource <> Nothing Then
line1:
                                If dt1.Rows.Count > 0 Then
                                    dt1.Rows.Add(cmbname.Text.Trim)
                                    cmbname.Text = a
                                End If
                            End If
                        End If
                        e.Cancel = True
                    Else
                        e.Cancel = True
                        Exit Sub
                    End If
                Else
                    tempname = dt.Rows(0).Item("LEDGERCODE").ToString
                End If
            End If
        Catch ex As Exception
            GoTo line1
            Throw ex
        End Try
    End Sub

    Sub FILLITEMCODE(ByVal frm As System.Windows.Forms.Form, ByVal cmb As ComboBox, ByVal condition As String)

        dt = New DataTable()
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If
        conn.Open()
        cmd = New OleDbCommand("select ITEM_code from ITEMMASTER " & condition, conn)
        da = New OleDbDataAdapter(cmd)
        da.Fill(dt)
        cmb.DataSource = dt
        cmb.DisplayMember = "ITEM_CODE"
        cmb.Text = ""
        'cmb.Text = tempitemname
        conn.Close()
        da.Dispose()

    End Sub

    Sub ITEMVALIDATE(ByRef CMBITEMNAME As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form, ByVal WHERECLAUSE As String, Optional ByRef TXTITEMDESC As Object = Nothing)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBITEMNAME.Text.Trim <> "" Then
                CMBITEMNAME.Text = UCase(CMBITEMNAME.Text)
                dt = New DataTable
                cmd = New OleDbCommand("select ITEMMASTER.ITEM_code AS ITEMCODE, ITEMMASTER.ITEM_NAME AS ITEMNAME from ITEMMASTER WHERE 1=1 AND ITEMMASTER.ITEM_CODE = '" & CMBITEMNAME.Text.Trim & "'" & WHERECLAUSE, conn)
                da = New OleDbDataAdapter(cmd)
                da.Fill(dt)
                If dt.Rows.Count = 0 Then
                    Dim a As String = CMBITEMNAME.Text.Trim
                    Dim tempmsg As Integer = MsgBox("Item not present, Add New?", MsgBoxStyle.YesNo, "")
                    If tempmsg = vbYes Then
                        CMBITEMNAME.Text = a
                        Dim OBJITEM As New Itemmaster
                        OBJITEM.TEMPITEMCODE = CMBITEMNAME.Text.Trim()
                        OBJITEM.ShowDialog()

                        dt = New DataTable
                        cmd = New OleDbCommand("select ITEMMASTER.ITEM_code AS ITEMCODE, ITEMMASTER.ITEM_NAME AS ITEMNAME from ITEMMASTER WHERE 1=1 AND ITEMMASTER.ITEM_CODE = '" & CMBITEMNAME.Text.Trim & "'" & WHERECLAUSE, conn)
                        da = New OleDbDataAdapter(cmd)
                        da.Fill(dt)
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As New DataTable
                            dt1 = CMBITEMNAME.DataSource
                            If CMBITEMNAME.DataSource <> Nothing Then
line1:
                                If dt1.Rows.Count > 0 Then
                                    dt1.Rows.Add(CMBITEMNAME.Text.Trim)
                                    CMBITEMNAME.Text = a
                                End If
                            End If
                        End If
                        e.Cancel = True
                    Else
                        e.Cancel = True
                        Exit Sub
                    End If
                Else
                    tempitemcode = dt.Rows(0).Item("ITEMCODE").ToString
                    If TypeOf TXTITEMDESC Is TextBox Then If TXTITEMDESC.TEXT.TRIM = "" Then TXTITEMDESC.TEXT = dt.Rows(0).Item("ITEMNAME").ToString
                End If
            End If
        Catch ex As Exception
            GoTo line1
            Throw ex
        End Try
    End Sub

    Sub FILLCOLOR(ByVal frm As System.Windows.Forms.Form, ByVal cmb As ComboBox, ByVal condition As String)

        dt = New DataTable()
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If
        conn.Open()
        cmd = New OleDbCommand("select COLOR_NAME from COLORMASTER " & condition, conn)
        da = New OleDbDataAdapter(cmd)
        da.Fill(dt)
        cmb.DataSource = dt
        cmb.DisplayMember = "COLOR_NAME"
        conn.Close()
        da.Dispose()

    End Sub

    Sub COLORVALIDATE(ByRef CMBCOLOR As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form, ByVal WHERECLAUSE As String)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBCOLOR.Text.Trim <> "" Then
                CMBCOLOR.Text = UCase(CMBCOLOR.Text)
                dt = New DataTable
                cmd = New OleDbCommand("select COLORMASTER.COLOR_NAME AS COLOR from COLORMASTER WHERE 1=1 AND COLORMASTER.COLOR_NAME = '" & CMBCOLOR.Text.Trim & "'" & WHERECLAUSE, conn)
                da = New OleDbDataAdapter(cmd)
                da.Fill(dt)
                If dt.Rows.Count = 0 Then
                    Dim a As String = CMBCOLOR.Text.Trim
                    Dim tempmsg As Integer = MsgBox("COLOR not present, Add New?", MsgBoxStyle.YesNo, "")
                    If tempmsg = vbYes Then
                        CMBCOLOR.Text = a
                        Dim OBJCOLOR As New SizeMaster
                        OBJCOLOR.FRMSTRING = "COLOR"
                        OBJCOLOR.txtname.Text = CMBCOLOR.Text.Trim()
                        OBJCOLOR.ShowDialog()

                        dt = New DataTable
                        cmd = New OleDbCommand("select COLORMASTER.COLOR_NAME AS COLORCODE from COLORMASTER WHERE 1=1 AND COLORMASTER.COLOR_NAME = '" & CMBCOLOR.Text.Trim & "'" & WHERECLAUSE, conn)
                        da = New OleDbDataAdapter(cmd)
                        da.Fill(dt)
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As New DataTable
                            dt1 = CMBCOLOR.DataSource
                            If CMBCOLOR.DataSource <> Nothing Then
line1:
                                If dt1.Rows.Count > 0 Then
                                    dt1.Rows.Add(CMBCOLOR.Text.Trim)
                                    CMBCOLOR.Text = a
                                End If
                            End If
                        End If
                        e.Cancel = True
                    Else
                        e.Cancel = True
                        Exit Sub
                    End If
                End If
            End If
        Catch ex As Exception
            GoTo line1
            Throw ex
        End Try
    End Sub

    Sub FILLSHAPE(ByVal frm As System.Windows.Forms.Form, ByVal cmb As ComboBox, ByVal condition As String)

        dt = New DataTable()
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If
        conn.Open()
        cmd = New OleDbCommand("select SHAPE_NAME from SHAPEMASTER " & condition, conn)
        da = New OleDbDataAdapter(cmd)
        da.Fill(dt)
        cmb.DataSource = dt
        cmb.DisplayMember = "SHAPE_NAME"
        conn.Close()
        da.Dispose()

    End Sub

    Sub SHAPEVALIDATE(ByRef CMBSHAPE As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form, ByVal WHERECLAUSE As String)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBSHAPE.Text.Trim <> "" Then
                CMBSHAPE.Text = UCase(CMBSHAPE.Text)
                dt = New DataTable
                cmd = New OleDbCommand("select SHAPEMASTER.SHAPE_NAME AS SHAPE from SHAPEMASTER WHERE 1=1 AND SHAPEMASTER.SHAPE_NAME = '" & CMBSHAPE.Text.Trim & "'" & WHERECLAUSE, conn)
                da = New OleDbDataAdapter(cmd)
                da.Fill(dt)
                If dt.Rows.Count = 0 Then
                    Dim a As String = CMBSHAPE.Text.Trim
                    Dim tempmsg As Integer = MsgBox("SHAPE not present, Add New?", MsgBoxStyle.YesNo, "")
                    If tempmsg = vbYes Then
                        CMBSHAPE.Text = a
                        Dim OBJSHAPE As New SizeMaster
                        OBJSHAPE.FRMSTRING = "SHAPE"
                        OBJSHAPE.txtname.Text = CMBSHAPE.Text.Trim()
                        OBJSHAPE.ShowDialog()

                        dt = New DataTable
                        cmd = New OleDbCommand("select SHAPEMASTER.SHAPE_NAME AS SHAPECODE from SHAPEMASTER WHERE 1=1 AND SHAPEMASTER.SHAPE_NAME = '" & CMBSHAPE.Text.Trim & "'" & WHERECLAUSE, conn)
                        da = New OleDbDataAdapter(cmd)
                        da.Fill(dt)
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As New DataTable
                            dt1 = CMBSHAPE.DataSource
                            If CMBSHAPE.DataSource <> Nothing Then
line1:
                                If dt1.Rows.Count > 0 Then
                                    dt1.Rows.Add(CMBSHAPE.Text.Trim)
                                    CMBSHAPE.Text = a
                                End If
                            End If
                        End If
                        e.Cancel = True
                    Else
                        e.Cancel = True
                        Exit Sub
                    End If
                End If
            End If
        Catch ex As Exception
            GoTo line1
            Throw ex
        End Try
    End Sub

    Sub FILLSIZE(ByVal frm As System.Windows.Forms.Form, ByVal cmb As ComboBox, ByVal condition As String)

        dt = New DataTable()
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If
        conn.Open()
        cmd = New OleDbCommand("select SIZE_NAME from SIZEMASTER " & condition, conn)
        da = New OleDbDataAdapter(cmd)
        da.Fill(dt)
        cmb.DataSource = dt
        cmb.DisplayMember = "SIZE_NAME"
        conn.Close()
        da.Dispose()

    End Sub

    Sub SIZEVALIDATE(ByRef CMBSIZE As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form, ByVal WHERECLAUSE As String)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBSIZE.Text.Trim <> "" Then
                CMBSIZE.Text = UCase(CMBSIZE.Text)
                dt = New DataTable
                cmd = New OleDbCommand("select SIZEMASTER.SIZE_NAME AS SIZENAME from SIZEMASTER WHERE 1=1 AND SIZEMASTER.SIZE_NAME = '" & CMBSIZE.Text.Trim & "'" & WHERECLAUSE, conn)
                da = New OleDbDataAdapter(cmd)
                da.Fill(dt)
                If dt.Rows.Count = 0 Then
                    Dim a As String = CMBSIZE.Text.Trim
                    Dim tempmsg As Integer = MsgBox("SIZE not present, Add New?", MsgBoxStyle.YesNo, "")
                    If tempmsg = vbYes Then
                        CMBSIZE.Text = a
                        Dim OBJSIZE As New SizeMaster
                        OBJSIZE.FRMSTRING = "SIZE"
                        OBJSIZE.txtname.Text = CMBSIZE.Text.Trim()
                        OBJSIZE.ShowDialog()

                        dt = New DataTable
                        cmd = New OleDbCommand("select SIZEMASTER.SIZE_NAME AS SIZENAME from SIZEMASTER WHERE 1=1 AND SIZEMASTER.SIZE_NAME = '" & CMBSIZE.Text.Trim & "'" & WHERECLAUSE, conn)
                        da = New OleDbDataAdapter(cmd)
                        da.Fill(dt)
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As New DataTable
                            dt1 = CMBSIZE.DataSource
                            If CMBSIZE.DataSource <> Nothing Then
line1:
                                If dt1.Rows.Count > 0 Then
                                    dt1.Rows.Add(CMBSIZE.Text.Trim)
                                    CMBSIZE.Text = a
                                End If
                            End If
                        End If
                        e.Cancel = True
                    Else
                        e.Cancel = True
                        Exit Sub
                    End If
                End If
            End If
        Catch ex As Exception
            GoTo line1
            Throw ex
        End Try
    End Sub

    Sub cmbtextchanged(ByVal sen As Object, ByVal frm As System.Windows.Forms.Form, ByVal cmb As ComboBox)
        Dim boxIndex As Integer, lExst As Boolean
        Dim box As ComboBox = sen
        Dim txt As String = box.Text
        Dim posCursor As Integer = box.SelectionStart

        ' If Cursor does not stay on the beginning of text box.
        If posCursor <> 0 Then
            lExst = False
            index = -1
            ' Go in cycle through the combo box list to find the appropriate entry in the list
            For boxIndex = 0 To box.Items.Count - 1
                If UCase(Mid(box.Items(boxIndex), 1, posCursor)) = UCase(Mid(txt, 1, posCursor)) Then
                    'If cmb.Name = "cmbitemname" Then index = boxIndex
                    box.Text = box.Items(boxIndex)
                    box.SelectionStart = posCursor
                    lExst = True
                    Exit For
                End If
            Next
            ' We didn't find appropriate entry and return previous value to text box
            If Not lExst Then
                box.SelectionStart = 0
                box.SelectionLength = posCursor
                box.Text = box.SelectedText
                box.SelectionStart = posCursor
                '    box.Text = Mid(txt, 1, posCursor - 1) + Mid(txt, posCursor + 1)
                '    box.SelectionStart = posCursor - 1
            End If
        End If
        'Return boxIndex
    End Sub

    Sub fillgroup(ByVal frm As System.Windows.Forms.Form, ByVal cmb As System.Windows.Forms.ComboBox, ByVal cmb1 As System.Windows.Forms.ComboBox, ByVal condition As String)

        'filling all groups and subgroups
        cmd = New OleDbCommand("select * from groupmaster" & condition, conn)
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If

        conn.Open()
        dr = cmd.ExecuteReader()
        If dr.HasRows Then
            cmb1.Items.Clear()
            cmb.Items.Clear()
            'cmb.Items.Add("Add New")
            While (dr.Read())
                cmb1.Items.Add(dr(0))
                cmb.Items.Add(dr(2))
            End While
            cmb1.SelectedIndex = (0)
            cmb.SelectedIndex = (0)
        End If

    End Sub

    Sub enterkeypress(ByVal han As KeyPressEventArgs, ByVal frm As System.Windows.Forms.Form)
        'If AscW(han.KeyChar) = 13 Then
        '    SendKeys.Send("{Tab}")
        '    han.KeyChar = ""
        'End If
    End Sub

    Sub numdotkeypress(ByVal han As KeyPressEventArgs, ByVal sen As Object, ByVal frm As System.Windows.Forms.Form)
        Dim mypos As Integer
        If AscW(han.KeyChar) >= 48 And AscW(han.KeyChar) <= 57 Or AscW(han.KeyChar) = 8 Then
            han.KeyChar = han.KeyChar
        ElseIf AscW(han.KeyChar) = 46 Then
            mypos = InStr(1, sen.Text, ".")
            If mypos = 0 Then
                han.KeyChar = han.KeyChar
            Else
                han.KeyChar = ""
            End If
        Else
            han.KeyChar = ""
        End If
    End Sub

    Sub numkeypress(ByVal han As KeyPressEventArgs, ByVal sen As Object, ByVal frm As System.Windows.Forms.Form)
        If AscW(han.KeyChar) >= 48 And AscW(han.KeyChar) <= 57 Or AscW(han.KeyChar) = 8 Then
            han.KeyChar = han.KeyChar
        Else
            han.KeyChar = ""
        End If
    End Sub

    Sub numdot(ByVal han As KeyPressEventArgs, ByVal txt As Object, ByVal frm As System.Windows.Forms.Form)

        Dim mypos As Integer

        If txt.Text = "" Or Val(txt.Text) = "0" Then
            txt.Text = ".000"
        End If

        'If AscW(han.KeyChar) = 13 Then
        '    SendKeys.Send("{Tab}")
        '    han.KeyChar = ""
        'End If


        mypos = InStr(1, txt.Text, ".")

        If AscW(han.KeyChar) > 47 And AscW(han.KeyChar) < 58 Or AscW(han.KeyChar) = 8 Or AscW(han.KeyChar) = 46 Then
            han.KeyChar = han.KeyChar
        Else
            han.KeyChar = ""
        End If

        If AscW(han.KeyChar) > 47 And AscW(han.KeyChar) < 58 Then
            If txt.SelectionStart = mypos + 3 Then
                han.KeyChar = ""
            End If
        End If

        If txt.SelectionStart >= mypos Then
            txt.SelectionLength = 1
            han.KeyChar = han.KeyChar
        End If

        If AscW(han.KeyChar) = 46 Then

            mypos = InStr(1, txt.Text, ".")
            If mypos = 0 Then
                han.KeyChar = han.KeyChar
            Else
                txt.SelectionStart = mypos
                han.KeyChar = ""
            End If

        End If

    End Sub

#Region "IN WORDS FUNCTION"

    Function CurrencyToWord(ByVal Num As Decimal) As String

        'I have created this function for converting amount in indian rupees (INR). 
        'You can manipulate as you wish like decimal setting, Doller (any currency) Prefix.

        Dim strNum As String
        Dim strNumDec As String
        Dim StrWord As String
        strNum = Num

        If InStr(1, strNum, ".") <> 0 Then
            strNumDec = Mid(strNum, InStr(1, strNum, ".") + 1)

            If Len(strNumDec) = 1 Then
                strNumDec = strNumDec + "0"
            End If
            If Len(strNumDec) > 2 Then
                strNumDec = Mid(strNumDec, 1, 2)
            End If

            strNum = Mid(strNum, 1, InStr(1, strNum, ".") - 1)
            StrWord = IIf(CDbl(strNum) = 1, " Rupee ", " Rupees ") + NumToWord(CDbl(strNum)) + IIf(CDbl(strNumDec) > 0, " and Paise" + cWord3(CDbl(strNumDec)), "")
        Else
            StrWord = IIf(CDbl(strNum) = 1, " Rupee ", " Rupees ") + NumToWord(CDbl(strNum))
        End If
        CurrencyToWord = StrWord & " Only"
        Return CurrencyToWord

    End Function

    Function NumToWord(ByVal Num As Decimal) As String

        'I divided this function in two part.
        '1. Three or less digit number.
        '2. more than three digit number.
        Dim strNum As String
        Dim StrWord As String
        strNum = Num

        If Len(strNum) <= 3 Then
            StrWord = cWord3(CDbl(strNum))
        Else
            StrWord = cWordG3(CDbl(Mid(strNum, 1, Len(strNum) - 3))) + " " + cWord3(CDbl(Mid(strNum, Len(strNum) - 2)))
        End If
        NumToWord = StrWord

    End Function

    Function cWordG3(ByVal Num As Decimal) As String

        '2. more than three digit number.
        Dim strNum As String = ""
        Dim StrWord As String = ""
        Dim readNum As String = ""
        strNum = Num
        If Len(strNum) Mod 2 <> 0 Then
            readNum = CDbl(Mid(strNum, 1, 1))
            If readNum <> "0" Then
                StrWord = retWord(readNum)
                readNum = CDbl("1" + strReplicate("0", Len(strNum) - 1) + "000")
                StrWord = StrWord + " " + retWord(readNum)
            End If
            strNum = Mid(strNum, 2)
        End If
        While Not Len(strNum) = 0
            readNum = CDbl(Mid(strNum, 1, 2))
            If readNum <> "0" Then
                StrWord = StrWord + " " + cWord3(readNum)
                readNum = CDbl("1" + strReplicate("0", Len(strNum) - 2) + "000")
                StrWord = StrWord + " " + retWord(readNum)
            End If
            strNum = Mid(strNum, 3)
        End While
        cWordG3 = StrWord
        Return cWordG3

    End Function

    Function strReplicate(ByVal str As String, ByVal intD As Integer) As String

        'This fucntion padded "0" after the number to evaluate hundred, thousand and on....
        'using this function you can replicate any Charactor with given string.
        strReplicate = ""
        For i As Integer = 1 To intD
            strReplicate = strReplicate + str
        Next
        Return strReplicate

    End Function

    Function cWord3(ByVal Num As Decimal) As String

        '1. Three or less digit number.
        Dim strNum As String = ""
        Dim StrWord As String = ""
        Dim readNum As String = ""
        If Num < 0 Then Num = Num * -1
        strNum = Num

        If Len(strNum) = 3 Then
            readNum = CDbl(Mid(strNum, 1, 1))
            StrWord = retWord(readNum) + " Hundred"
            strNum = Mid(strNum, 2, Len(strNum))
        End If

        If Len(strNum) <= 2 Then
            If CDbl(strNum) >= 0 And CDbl(strNum) <= 20 Then
                StrWord = StrWord + " " + retWord(CDbl(strNum))
            Else
                StrWord = StrWord + " " + retWord(CDbl(Mid(strNum, 1, 1) + "0")) + " " + retWord(CDbl(Mid(strNum, 2, 1)))
            End If
        End If

        strNum = CStr(Num)
        cWord3 = StrWord
        Return cWord3

    End Function

    Function retWord(ByVal Num As Decimal) As String
        'This two dimensional array store the primary word convertion of number.
        retWord = ""
        Dim ArrWordList(,) As Object = {{0, ""}, {1, "One"}, {2, "Two"}, {3, "Three"}, {4, "Four"},
                                        {5, "Five"}, {6, "Six"}, {7, "Seven"}, {8, "Eight"}, {9, "Nine"},
                                        {10, "Ten"}, {11, "Eleven"}, {12, "Twelve"}, {13, "Thirteen"}, {14, "Fourteen"},
                                        {15, "Fifteen"}, {16, "Sixteen"}, {17, "Seventeen"}, {18, "Eighteen"}, {19, "Nineteen"},
                                        {20, "Twenty"}, {30, "Thirty"}, {40, "Forty"}, {50, "Fifty"}, {60, "Sixty"},
                                        {70, "Seventy"}, {80, "Eighty"}, {90, "Ninety"}, {100, "Hundred"}, {1000, "Thousand"},
                                        {100000, "Lakh"}, {10000000, "Crore"}}

        For i As Integer = 0 To UBound(ArrWordList)
            If Num = ArrWordList(i, 0) Then
                retWord = ArrWordList(i, 1)
                Exit For
            End If
        Next
        Return retWord

    End Function

#End Region

    Sub sendemail(ByVal toMail As String, ByVal tempattachment As String, ByVal mailbody As String)

        'Dim mailBody As String
        Try
            Cursor.Current = Cursors.WaitCursor

            'create the mail message
            Dim mail As New MailMessage
            Dim MAILATTACHMENT As Attachment

            'set the addresses
            mail.From = New MailAddress("shahandcotax@gmail.com", "SHAH & CO.")
            mail.To.Add(toMail)
            'mail.To.Add("gulkit_jain@yahoo.co.in")
            'mail.To.Add("irfan_shaikh83@yahoo.com")


            'set the content
            mail.Subject = tempattachment

            'mailBody = "Dear " + titleMail + " " + fnameMail + " " + lnameMail + " <br><br>"
            'mailBody = "To " + toMail + " <br><br>"
            'mailBody = mailBody & "Please find the document as an attachment. <br><br>"
            'mailBody = mailBody & "From, <br>"
            'mailBody = mailBody & "J.J. INDUSTRIES <br>"
            'mailBody = mailBody & "+91 022-23073375/23088600 <br>"
            'mailBody = mailBody & "jjindustries@vsnl.net <br>"

            mail.Body = mailbody
            mail.IsBodyHtml = True

            'Dim s As String
            's = Application.StartupPath & "\" & tempattachment & ".pdf"
            MAILATTACHMENT = New Attachment(Application.StartupPath & "\" & tempattachment & ".pdf")
            mail.Attachments.Add(MAILATTACHMENT)
            'mail.fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "1") 'basic authentication


            Dim nc As New System.Net.NetworkCredential
            nc.UserName = "shahandcotax@gmail.com"
            nc.Password = "rakesh20"


            'send the message
            Dim smtp As New SmtpClient
            smtp.Host = "smtp.gmail.com"
            smtp.Port = (25)
            smtp.EnableSsl = True

            'Dim iauto As System.Net.IAuthenticationModule
            'iauto.Authenticate("", "", nc)

            'SmtpClient(smtp = New SmtpClient("216.185.43.235", 25))



            'nc.UserName = "gulkitjain@gmail.com"
            'nc.Password = "infosys123"

            'System.Net.NetworkCredential(nc = New System.Net.NetworkCredential("customerservice@thecareerspectrum.com", "12345678"))
            smtp.Credentials = nc

            smtp.Send(mail)
            mail.Dispose()

        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

End Module
