Imports System.Data.OleDb

Public Class Melting

    Public EDIT As Boolean = False
    Dim m_EditingRow As Integer = -1
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Sub clear()

        EP.Clear()
        'clearing array
        For i = 1 To 100
            tempcol(i) = ""
            tempval(i) = ""
        Next

        TXTREFNO.Clear()
        TXTREFNO.ReadOnly = False

        txtreqmelting.Clear()
        txttotalnettwt.Clear()
        txttotalgrosswt.Clear()
        txtcopper.Clear()
        lblcopper.Text = ""
        txtsilver.Clear()
        lblsilver.Text = ""
        TXTBRASS.Clear()
        LBLBRASS.Text = ""
        gridmelting.RowCount = 1
        gridmelting.Rows(0).Cells(cmbitemname.Index).Selected = True
        txtalloy.Clear()
        txtgtotalwt.Clear()
        txtnotes.Clear()
        txtloss.Clear()
        txtoutput.Clear()

        lbllock.Visible = False
        cmdok.Enabled = True  'coz while edit mode we disable the btn. if mfg is made


        'getting melting_id from database
        GETMAX_MELTING_NO()

        edit = False

        meltingdate.Value = GLOBALDATE
        griddoubleclick = False
        txtreqmelting.Focus()

    End Sub

    Sub GETMAX_MELTING_NO()
        cmd = New OleDbCommand("select max(melting_id) from meltingmaster", conn)
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If
        conn.Open()
        dr = cmd.ExecuteReader
        If dr.HasRows Then
            dr.Read()
            txtmeltingno.Text = Val(dr(0).ToString)
            txtmeltingno.Text = Val(txtmeltingno.Text) + 1
            If ClientName = "JAINAM" Then
                If Month(meltingdate.Value.Date) = 1 Then
                    TXTREFNO.Text = "J/"
                ElseIf Month(meltingdate.Value.Date) = 2 Then
                    TXTREFNO.Text = "F/"
                ElseIf Month(meltingdate.Value.Date) = 3 Then
                    TXTREFNO.Text = "M/"
                ElseIf Month(meltingdate.Value.Date) = 4 Then
                    TXTREFNO.Text = "A/"
                ElseIf Month(meltingdate.Value.Date) = 5 Then
                    TXTREFNO.Text = "MY/"
                ElseIf Month(meltingdate.Value.Date) = 6 Then
                    TXTREFNO.Text = "JN/"
                ElseIf Month(meltingdate.Value.Date) = 7 Then
                    TXTREFNO.Text = "JL/"
                ElseIf Month(meltingdate.Value.Date) = 8 Then
                    TXTREFNO.Text = "AG/"
                ElseIf Month(meltingdate.Value.Date) = 9 Then
                    TXTREFNO.Text = "S/"
                ElseIf Month(meltingdate.Value.Date) = 10 Then
                    TXTREFNO.Text = "O/"
                ElseIf Month(meltingdate.Value.Date) = 11 Then
                    TXTREFNO.Text = "N/"
                ElseIf Month(meltingdate.Value.Date) = 12 Then
                    TXTREFNO.Text = "D/"
                End If
                TXTREFNO.Text = TXTREFNO.Text & txtmeltingno.Text.Trim
            End If
        End If
        conn.Close()
        dr.Close()
    End Sub

    Private Sub meltingdate_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles meltingdate.KeyDown
        If e.KeyCode = 13 Then
            SendKeys.Send("{Tab}")
            e.Handled = False
        End If
    End Sub

    Private Sub cmdclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        clear()
        cmdedit.Enabled = True
        edit = False
        tempmeltingid = 0
    End Sub

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click

        If gridmelting.RowCount > 0 And Val(txtreqmelting.Text) <> 0 And chkchange.CheckState = CheckState.Checked Then
            tempmsg = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
            If tempmsg = vbYes Then cmdok_Click(sender, e)
        End If
        Me.Close()

        'add meltingdetails
        If (chldmeltingdetails.IsMdiChild = False) Then
            If chldmeltingdetails.IsDisposed = True Then
                chldmeltingdetails = New MeltingDetails
            End If
            chldmeltingdetails.MdiParent = MDIMain
            chldmeltingdetails.Show()
        Else
            chldmeltingdetails.BringToFront()
        End If
    End Sub

    Private Sub Melting_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        If e.KeyCode <> Keys.Escape Then chkchange.CheckState = CheckState.Checked
        If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            If gridmelting.RowCount > 0 And Val(txtreqmelting.Text) <> 0 And chkchange.CheckState = CheckState.Checked Then
                tempmsg = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                If tempmsg = vbYes Then SAVE()
            End If
            Me.Close()
            If USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            'meltingdetails
            If (chldmeltingdetails.IsMdiChild = False) Then
                If chldmeltingdetails.IsDisposed = True Then
                    chldmeltingdetails = New MeltingDetails
                End If
                chldmeltingdetails.MdiParent = MDIMain
                chldmeltingdetails.Show()
            Else
                chldmeltingdetails.BringToFront()
            End If
        ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.Left Then       'for DELETE
            Call toolprevious_Click(sender, e)
        ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.Right Then       'for DELETE
            Call toolnext_Click(sender, e)
        ElseIf e.KeyCode = Keys.Enter Then
            'SendKeys.Send("{Tab}")
        End If


        '****** CTRL + N *************
        'If e.Control = True And e.KeyCode = Keys.N Then
        '    If gridmelting.RowCount > 0 And Val(txtreqmelting.Text) <> 0 And chkchange.CheckState = CheckState.Checked Then
        '        tempmsg = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
        '        If tempmsg = vbYes Then cmdok_Click(sender, e)
        '    End If
        '    clear()
        'End If

    End Sub

    Private Sub Melting_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        'esc
        If AscW(e.KeyChar) <> 33 Then
            chkchange.CheckState = CheckState.Checked
        End If
    End Sub

    Private Sub Melting_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'MANUFACTURING'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            clear()

            tempcondition = ""
            fillgridcmb("itemmaster", "item_code", cmbitemname, tempcondition)

            If cmdedit.Enabled = True Then edit = False
            If cmdedit.Enabled = False Then edit = True

            If edit = True Then

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                cmd = New OleDbCommand("select melting_mfg from meltingmaster where melting_id = " & tempmeltingid & " and melting_mfg = True", conn)
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
                conn.Open()
                dr = cmd.ExecuteReader
                If dr.HasRows = True Then
                    dr.Read()
                    cmdok.Enabled = False
                    lbllock.Visible = True
                End If

                cmd = New OleDbCommand("select * from meltingmaster where melting_id = " & Val(tempmeltingid), conn)
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
                conn.Open()
                dr = cmd.ExecuteReader
                While (dr.Read())

                    txtmeltingno.Text = tempmeltingid
                    TXTREFNO.Text = dr("MELTING_REFNO")
                    TXTREFNO.ReadOnly = True

                    meltingdate.Value = dr(1)
                    txtreqmelting.Text = Format(dr(2), "0.00")


                    'filling gridmelting
                    'getting itemcode
                    tempcmd = New OleDbCommand("select item_code from itemmaster where item_id = " & dr(3), tempconn)
                    If tempconn.State = ConnectionState.Open Then
                        tempconn.Close()
                    End If
                    tempconn.Open()
                    tempdr = tempcmd.ExecuteReader
                    If tempdr.HasRows = True Then
                        tempdr.Read()
                        tempitemcode = tempdr(0).ToString
                    End If

                    txttotalnettwt.Text = Format(Val(dr(7)), "0.000")
                    txttotalgrosswt.Text = Format(Val(dr(8)), "0.000")
                    txtalloy.Text = Format(Val(dr(9)), "0.000")
                    txtgtotalwt.Text = Format(Val(dr(10)), "0.000")
                    txtcopper.Text = Val(dr(11))
                    txtsilver.Text = Val(dr(12))
                    txtnotes.Text = dr(13).ToString
                    txtoutput.Text = Format(Val(dr(16)), "0.000")
                    txtloss.Text = Format(Val(dr(17)), "0.000")

                    gridmelting.Rows.Add(UCase(tempitemcode), Val(dr(4)), Val(dr(5)), Val(dr(6)))

                End While
                If gridmelting.RowCount > 0 Then gridmelting.FirstDisplayedScrollingRowIndex = gridmelting.RowCount - 1

            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtcopper_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcopper.KeyPress
        numdotkeypress(e, txtcopper, Me)
    End Sub

    Private Sub txtreqmelting_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtreqmelting.KeyPress
        numdotkeypress(e, txtreqmelting, Me)
    End Sub

    Private Sub txtsilver_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtsilver.KeyPress
        numdotkeypress(e, txtsilver, Me)
    End Sub

    Sub total()

        txttotalnettwt.Text = 0
        txttotalgrosswt.Text = 0

        For Each row As DataGridViewRow In gridmelting.Rows
            txttotalgrosswt.Text = Format(Val(txttotalgrosswt.Text) + Val(row.Cells(2).Value), "0.000")
            txttotalnettwt.Text = Format(Val(txttotalnettwt.Text) + Val(row.Cells(3).Value), "0.000")
        Next

        If Val(txtreqmelting.Text) <> 0 And Val(txttotalgrosswt.Text) <> 0 And Val(txttotalnettwt.Text) <> 0 Then calculatealloy()
        txtgtotalwt.Text = Format(Val(txttotalgrosswt.Text) + Val(txtalloy.Text), "0.000")

        If Val(txtloss.Text) = 0 Then
            txtoutput.Text = Format(Val(txtgtotalwt.Text), "0.000")
            txtloss.Text = "0.000"
        Else
            txtloss.Text = Format(Val(txtgtotalwt.Text) - Val(txtoutput.Text), "0.000")
        End If

    End Sub

    Private Sub cmdok_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdok.Click
        If gridmelting.RowCount > 1 And Val(txtreqmelting.Text) <> 0 Then

            'IF BACK DATED ENTRY IS TO BE SAVED THEN CHECK ENTRYPASSWORD
            If APPLYBLOCKDATE = True And meltingdate.Value.Date <= BLOCKEDDATE.Date Then
                Dim OBJPASS As New PasswordEntry
                OBJPASS.ShowDialog()
                If ENTRYPASSWORD <> OBJPASS.TXTDATERETYPE.Text.Trim Then
                    MsgBox("Invaid Password", MsgBoxStyle.Critical)
                    Exit Sub
                End If
            End If

            SAVE()
            cmdedit.Enabled = True
            EDIT = False
            tempmeltingid = 0
        Else
            MsgBox("Invalid Entry")
        End If
    End Sub

    Sub SAVE()
        Try

            EP.Clear()
            If Not ERRORVALID() Then
                Exit Sub
            End If

            If lblalloy.Text = "Gold Required" Then
                MsgBox("Gold Required, Entry Not Allowed")
                txtreqmelting.Focus()
                Exit Sub
            End If

            If cmdedit.Enabled = False Then edit = True
            If cmdedit.Enabled = True Then edit = False

            If edit = True Then

                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                cmd = New OleDbCommand("select melting_mfg from meltingmaster where melting_id = " & tempmeltingid, conn)
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
                conn.Open()
                dr = cmd.ExecuteReader
                dr.Read()
                If dr(0) = True Then
                    MsgBox("Lot Manufactured Can't Edit, Remove from Mfg 1st")
                    Exit Sub
                End If

                'deleting data from melting
                cmd = New OleDbCommand("delete from meltingmaster where melting_id = " & tempmeltingid, conn)
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
                conn.Open()
                cmd.ExecuteNonQuery()

            Else
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                'IF MULTIPLE USERS ARE WORKING ON THE SAME FORM THEN WE NEED THIS
                GETMAX_MELTING_NO()

            End If

            For i = 0 To 100
                tempcol(i) = ""
                tempval(i) = ""
            Next

            tempcol(0) = "melting_id"
            tempcol(1) = "melting_date"
            tempcol(2) = "melting_reqmelting"
            tempcol(3) = "melting_itemid"
            tempcol(4) = "melting_purity"
            tempcol(5) = "melting_grosswt"
            tempcol(6) = "melting_nettwt"
            tempcol(7) = "melting_totalnettwt"
            tempcol(8) = "melting_totalgrosswt"
            tempcol(9) = "melting_alloy"
            tempcol(10) = "melting_gtotalwt"
            tempcol(11) = "melting_copper"
            tempcol(12) = "melting_silver"
            tempcol(13) = "melting_narration"
            tempcol(14) = "melting_mfg"
            tempcol(15) = "melting_userid"
            tempcol(16) = "melting_output"
            tempcol(17) = "melting_loss"
            tempcol(18) = "MELTING_REFNO"
            tempcol(19) = "MELTING_DEPARTMENTID"


            For i = 0 To gridmelting.RowCount - 2

                tempval(0) = Val(txtmeltingno.Text)
                tempval(1) = "'" & Format(meltingdate.Value, "dd/MM/yyyy") & "'"
                tempval(2) = Val(txtreqmelting.Text)


                'getting itemid
                tempcmd = New OleDbCommand("select item_id from itemmaster where item_code = '" & gridmelting.Item(cmbitemname.Index, i).Value.ToString & "'", tempconn)
                If tempconn.State = ConnectionState.Open Then
                    tempconn.Close()
                End If
                tempconn.Open()
                tempdr = tempcmd.ExecuteReader
                If tempdr.HasRows Then
                    tempdr.Read()
                    tempval(3) = Val(tempdr(0))
                End If
                tempconn.Close()
                tempdr.Close()

                tempval(4) = gridmelting.Item(1, i).Value.ToString
                tempval(5) = gridmelting.Item(2, i).Value.ToString
                tempval(6) = gridmelting.Item(3, i).Value.ToString

                tempval(7) = Val(txttotalnettwt.Text)
                tempval(8) = Val(txttotalgrosswt.Text)
                tempval(9) = Val(txtalloy.Text)
                tempval(10) = Val(txtgtotalwt.Text)
                tempval(11) = Val(txtcopper.Text)
                tempval(12) = Val(txtsilver.Text)
                tempval(13) = "'" & txtnotes.Text.Trim & "'"
                tempval(14) = 0
                tempval(15) = Val(USERID)
                tempval(16) = Val(txtoutput.Text)
                tempval(17) = Val(txtloss.Text)
                tempval(18) = "'" & TXTREFNO.Text.Trim & "'"
                tempval(19) = Val(USERDEPARTMENTID)

                insert("meltingmaster", tempcol, tempval)

            Next

            clear()
            txtreqmelting.Focus()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Function ERRORVALID() As Boolean
        Try
            Dim BLN As Boolean = True

            If gridmelting.RowCount <= 1 Then
                EP.SetError(txtreqmelting, "Enter Item Details")
                BLN = False
            End If

            If ClientName = "JAINAM" And TXTREFNO.Text.Trim = "" And edit = False Then
                TXTREFNO.Text = "A/" & txtmeltingno.Text.Trim
            End If

            For Each ROW As DataGridViewRow In gridmelting.Rows
                If ROW.Index < gridmelting.RowCount - 1 Then
                    If Val(ROW.Cells(GPURITY.Index).Value) = 0 Then
                        EP.SetError(txtreqmelting, "Enter Purity")
                        BLN = False
                    End If
                    If Val(ROW.Cells(GGROSSWT.Index).Value) = 0 Then
                        EP.SetError(txtreqmelting, "Enter Gross Wt")
                        BLN = False
                    End If
                    If Val(ROW.Cells(GNETTWT.Index).Value) = 0 Then
                        EP.SetError(txtreqmelting, "Enter Nett Wt")
                        BLN = False
                    End If
                End If
            Next
            

            Return BLN
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub toolprevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolprevious.Click

        'ask to save changes
        If gridmelting.RowCount > 0 And Val(txtreqmelting.Text) <> 0 And chkchange.CheckState = CheckState.Checked Then
            tempmsg = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
            If tempmsg = vbYes Then SAVE()
            chkchange.CheckState = CheckState.Unchecked
        End If

        tempmeltingid = txtmeltingno.Text - 1
        If tempmeltingid > 0 Then
            gridmelting.CurrentCell = gridmelting.Rows(0).Cells(1)
            cmdedit.Enabled = False
            edit = True
            Melting_Load(sender, e)
        Else
            clear()
            cmdedit.Enabled = True
            edit = False
        End If

    End Sub

    Private Sub toolnext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolnext.Click

        'ask to save changes
        If gridmelting.RowCount > 0 And Val(txtreqmelting.Text) > 0 And chkchange.CheckState = CheckState.Checked Then
            tempmsg = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
            If tempmsg = vbYes Then SAVE()
            chkchange.CheckState = CheckState.Unchecked
        End If
        tempmeltingid = txtmeltingno.Text + 1

        dr.Close()
        cmd = New OleDbCommand("select max(melting_id) from meltingmaster", conn)
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If
        conn.Open()
        dr = cmd.ExecuteReader
        If dr.HasRows = True Then
            dr.Read()
            If tempmeltingid <= Val(dr(0)) Then
                gridmelting.CurrentCell = gridmelting.Rows(0).Cells(1)
                cmdedit.Enabled = False
                edit = True
                Melting_Load(sender, e)
            Else
                clear()
                cmdedit.Enabled = True
                edit = False
            End If
        End If
    End Sub

    Private Sub OpenToolStripButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles OpenToolStripButton.Click

        If USERVIEW = False Then
            MsgBox("Insufficient Rights")
            Exit Sub
        End If

        'ask to save changes
        If gridmelting.RowCount > 0 And Val(txtreqmelting.Text) <> 0 And chkchange.CheckState = CheckState.Checked Then
            tempmsg = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
            If tempmsg = vbYes Then SAVE()
        End If

        'MELTING details
        Me.Close()
        If (chldmeltingdetails.IsMdiChild = False) Then
            If chldmeltingdetails.IsDisposed = True Then
                chldmeltingdetails = New MeltingDetails
            End If
            chldmeltingdetails.MdiParent = MDIMain
            chldmeltingdetails.Show()
        Else
            chldmeltingdetails.BringToFront()
        End If
    End Sub

    Private Sub SaveToolStripButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SaveToolStripButton.Click
        Call cmdok_Click(sender, e)
    End Sub

    Private Sub txtreqmelting_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtreqmelting.Validated
        total()
    End Sub

    Sub calculatealloy()

        Dim tempbar, tempalloy As Double 'used to calculate aLLOY

        'calculating alloy or gold required
        tempbar = Format((Val(txttotalnettwt.Text) / Val(txtreqmelting.Text)) * 100, "0.000")
        tempalloy = Format(Val(tempbar) - Val(txttotalgrosswt.Text), "0.0000")

        If tempalloy < 0 Then

            'calculating gold required

            lblalloy.Text = "Gold Required"
            tempbar = (Val(txttotalnettwt.Text) / Val(txtreqmelting.Text)) * 100
            tempbar = Val(txttotalgrosswt.Text) - Val(tempbar)

            On Error Resume Next
            tempbar = (Val(tempbar) * Val(txtreqmelting.Text)) / (100 - Val(txtreqmelting.Text))
            txtalloy.Text = Format(Val(tempbar), "0.000")

        Else

            lblalloy.Text = "Alloy"
            txtalloy.Text = Format(Val(tempalloy), "0.000")

        End If

    End Sub

    Private Sub ToolStripdelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripdelete.Click
        Try
            Call CMDDELETE_Click(sender, e)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtcopper_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcopper.TextChanged
        If Val(txtcopper.Text) <> 0 And Val(txtgtotalwt.Text) <> 0 Then
            lblcopper.Text = Format((Val(txtcopper.Text) / 100) * Val(txtalloy.Text), "0.000")
            'txtsilver.Text = 100 - Val(txtcopper.Text)
        End If
    End Sub

    Private Sub txtsilver_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtsilver.TextChanged
        If Val(txtsilver.Text) <> 0 And Val(txtgtotalwt.Text) <> 0 Then
            lblsilver.Text = Format((Val(txtsilver.Text) / 100) * Val(txtalloy.Text), "0.000")
            'txtcopper.Text = 100 - Val(txtsilver.Text)
        End If
    End Sub

    Private Sub gridmelting_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles gridmelting.EditingControlShowing
        If (TypeOf e.Control Is DataGridViewComboBoxEditingControl) Then
            Dim cmb As DataGridViewComboBoxEditingControl = CType(e.Control, DataGridViewComboBoxEditingControl)
            If Not cmb Is Nothing Then
                cmb.DropDownStyle = ComboBoxStyle.DropDown
            End If
        End If
        m_EditingRow = gridmelting.CurrentRow.Index

    End Sub

    Private Sub gridmelting_CellValidated(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridmelting.CellValidated

        If gridmelting.RowCount > 1 Then

            tempcondition = ""
            If e.ColumnIndex = 0 Then fillgridcmb("itemmaster", "item_code", cmbitemname, tempcondition)


            If e.ColumnIndex = 1 Or e.ColumnIndex = 2 Then
                gridmelting.Item(3, e.RowIndex).Value = Val(gridmelting.Item(1, e.RowIndex).Value) * Val(gridmelting.Item(2, e.RowIndex).Value) / 100
                gridmelting.CurrentCell.Value = Convert.ToDecimal(gridmelting.CurrentCell.Value)


                Dim WHERECLAUSE As String = ""
                If USERDEPARTMENT <> "" Then WHERECLAUSE = WHERECLAUSE & " AND STOCKS.DEPARTMENT = '" & USERDEPARTMENT & "'"

                'getting stock if gross is 0
                If Val(gridmelting.Item(2, e.RowIndex).Value) = 0 And gridmelting.Item(0, e.RowIndex).Value <> Nothing Then
                    cmd = New OleDbCommand("select sum(item_grosswt) from stocks where item_code = '" & gridmelting.Item(0, e.RowIndex).Value.ToString & "' and item_purity = " & gridmelting.Item(1, e.RowIndex).Value & WHERECLAUSE, conn)
                    If conn.State = ConnectionState.Open Then
                        conn.Close()
                    End If
                    conn.Open()
                    dr = cmd.ExecuteReader
                    If dr.HasRows = True Then
                        dr.Read()
                        gridmelting.Item(GGROSSWT.Index, e.RowIndex).Value = Val(dr(0).ToString)
                        gridmelting.Item(GNETTWT.Index, e.RowIndex).Value = Format((Val(dr(0).ToString) * Val(gridmelting.Item(GPURITY.Index, e.RowIndex).Value) / 100), "0.000")
                    End If
                End If
            End If

            If e.ColumnIndex = 1 Or e.ColumnIndex = 2 Or e.ColumnIndex = 3 Then
                If gridmelting.Item(0, e.RowIndex).Value = Nothing Then
                    gridmelting.Item(0, gridmelting.CurrentRow.Index).Value = Nothing
                    gridmelting.Item(1, gridmelting.CurrentRow.Index).Value = Nothing
                    gridmelting.Item(2, gridmelting.CurrentRow.Index).Value = Nothing
                    gridmelting.Item(3, gridmelting.CurrentRow.Index).Value = Nothing
                End If
            End If
        End If
    End Sub

    Private Sub gridmelting_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles gridmelting.CellValidating

        '*************************DONE BY GULKIT *****************************
        'If e.ColumnIndex = cmbitemname.Index And gridmelting.RowCount > 1 Then
        '    If (TypeOf CType(sender, DataGridView).EditingControl Is DataGridViewComboBoxEditingControl) Then
        '        Dim cmb As DataGridViewComboBoxEditingControl = CType(CType(sender, DataGridView).EditingControl, DataGridViewComboBoxEditingControl)
        '        If Not cmb Is Nothing Then
        '            Dim grid As DataGridView = cmb.EditingControlDataGridView
        '            Dim value As Object = uppercase(cmb.Text)
        '            If cmb.Text.Trim <> "" Then

        '                cmd = New OleDbCommand("select item_id from itemmaster where item_code = '" & cmb.Text.Trim & "'", conn)
        '                If conn.State = ConnectionState.Open Then
        '                    conn.Close()
        '                End If
        '                conn.Open()
        '                dr = cmd.ExecuteReader
        '                If dr.HasRows = False Then
        '                    '// Must add to both the current combobox as well as the template, to avoid duplicate entries...
        '                    'cmb.Items.Add(value)
        '                    'Dim cmbCol As DataGridViewComboBoxColumn = CType(grid.Columns(grid.CurrentCell.ColumnIndex), DataGridViewComboBoxColumn)
        '                    'If Not cmbCol Is Nothing Then
        '                    '    'cmbCol.Items.Add(value)
        '                    'End If

        '                    'ask to save new entry
        '                    tempmsg = MsgBox("Item Not Present, Add New?", MsgBoxStyle.YesNo)
        '                    If tempmsg = vbYes Then

        '                        If (chlditemmaster.IsMdiChild = False) Then
        '                            If chlditemmaster.IsDisposed = True Then
        '                                chlditemmaster = New Itemmaster
        '                            End If
        '                            chlditemmaster.cmdedit.Enabled = True
        '                            edit = False
        '                            e.Cancel = True
        '                            chlditemmaster.cmdaddnew.Enabled = False
        '                            chlditemmaster.groupdetails.Enabled = True
        '                            chlditemmaster.txttype.Visible = False
        '                            chlditemmaster.txtcategory.Visible = False
        '                            chlditemmaster.Show(Me)
        '                            chlditemmaster.cmbcode.Text = cmb.Text
        '                            chlditemmaster.cmbitemname.Text = cmb.Text
        '                            chlditemmaster.ActiveControl = (chlditemmaster.cmbcode)
        '                            chlditemmaster.cmbitemname.Focus()
        '                        Else
        '                            chlditemmaster.BringToFront()
        '                        End If
        '                    Else
        '                        cmb.Text = cmb.Text
        '                        cmb.Focus()
        '                        e.Cancel = True
        '                    End If

        '                Else
        '                    If cmb.Items.IndexOf(value) = -1 Then
        '                        cmb.Items.Add(value)
        '                        Dim cmbCol As DataGridViewComboBoxColumn = CType(grid.Columns(grid.CurrentCell.ColumnIndex), DataGridViewComboBoxColumn)
        '                        If Not cmbCol Is Nothing Then
        '                            cmbCol.Items.Add(value)
        '                        End If
        '                    End If
        '                    grid.CurrentCell.Value = value
        '                End If

        '            End If

        '        End If
        '    End If
        'End If
        '******************************* END OF CODE **********************************


       If (TypeOf CType(sender, DataGridView).EditingControl Is DataGridViewComboBoxEditingControl) Then
            Dim cmb As DataGridViewComboBoxEditingControl = CType(CType(sender, DataGridView).EditingControl, DataGridViewComboBoxEditingControl)
            If Not cmb Is Nothing Then
                Dim grid As DataGridView = cmb.EditingControlDataGridView
                Dim value As Object = uppercase(cmb.Text.Trim)
                If cmb.Text.Trim <> "" Then

                    cmd = New OleDbCommand("select item_id from itemmaster where item_code = '" & cmb.Text.Trim & "'", conn)
                    If conn.State = ConnectionState.Open Then
                        conn.Close()
                    End If
                    conn.Open()
                    dr = cmd.ExecuteReader
                    If dr.HasRows = False Then

                        tempmsg = MsgBox("Item Not Present, Add New?", MsgBoxStyle.YesNo)
                        If tempmsg = vbYes Then
                            item = 0
                            If (chlditemmaster.IsMdiChild = False) Then
                                If chlditemmaster.IsDisposed = True Then
                                    chlditemmaster = New Itemmaster
                                End If
                                chlditemmaster.cmdedit.Enabled = True
                                edit = False
                                e.Cancel = True
                                chlditemmaster.cmdaddnew.Enabled = False
                                chlditemmaster.GPITEM.Enabled = True
                                chlditemmaster.txttype.Visible = False
                                chlditemmaster.txtcategory.Visible = False
                                chlditemmaster.Show(Me)
                                chlditemmaster.cmbcode.Text = cmb.Text
                                chlditemmaster.cmbitemname.Text = cmb.Text
                                chlditemmaster.ActiveControl = (chlditemmaster.cmbcode)
                                chlditemmaster.cmbitemname.Focus()
                            Else
                                chlditemmaster.BringToFront()
                            End If
                        Else
                            cmb.Text = UCase(cmb.Text.Trim)
                            cmb.Focus()
                            e.Cancel = True
                        End If

                    Else
                        Dim objstockform As New Stockform
                        objstockform.ht = gridmelting.Top + 22 + (gridmelting.CurrentRow.Height * e.RowIndex)
                        objstockform.wd = gridmelting.Left + 10
                        objstockform.item = gridmelting.CurrentRow.Cells(0).EditedFormattedValue.ToString
                        objstockform.ShowDialog()


                        gridmelting.CurrentRow.Cells(GGROSSWT.Index).Value = objstockform.GROSSWT
                        gridmelting.CurrentRow.Cells(GPURITY.Index).Value = objstockform.PURITY


                        'If cmb.Items.IndexOf(value) = -1 Then
                        '    cmb.Items.Add(value)
                        '    Dim cmbCol As DataGridViewComboBoxColumn = CType(grid.Columns(grid.CurrentCell.ColumnIndex), DataGridViewComboBoxColumn)
                        '    If Not cmbCol Is Nothing Then
                        '        cmbCol.Items.Add(value)
                        '    End If
                        'End If
                        'grid.CurrentCell.Value = value
                    End If

                End If

            End If
        End If



        If e.ColumnIndex <> 0 And gridmelting.RowCount > 1 Then
            Dim strName As String = gridmelting.Columns(e.ColumnIndex).Name
            If String.IsNullOrEmpty(e.FormattedValue.ToString) Then Return
            Select Case strName
                'Case "Date"
                '    Dim dt As Date
                '    If Not DateTime.TryParse(e.FormattedValue.ToString, dt) Then
                '        MessageBox.Show("Invalid Date")
                '        e.Cancel = True
                '    End If
                Case "GPURITY"
                    Dim dDebit As Decimal
                    Dim bValid As Boolean = Decimal.TryParse(e.FormattedValue.ToString, dDebit)
                    'Dim strCredit As String
                    'strCredit = gridmelting.Item("meltinggrosswt", e.RowIndex).FormattedValue.ToString
                    'If String.IsNullOrEmpty(e.FormattedValue.ToString) Then Return
                    'If bValid And strCredit.Length < 1 Then
                    If bValid Then
                        gridmelting.CurrentCell.Value = Convert.ToDecimal(gridmelting.Item(1, e.RowIndex).Value)
                        ' everything is good
                    Else
                        MessageBox.Show("Invalid number")
                        e.Cancel = True
                    End If

                Case "GGROSSWT"
                    Dim dDebit As Decimal
                    Dim bValid As Boolean = Decimal.TryParse(e.FormattedValue.ToString, dDebit)
                    'Dim strCredit As String
                    'strCredit = gridmelting.Item("meltingpurity", e.RowIndex).FormattedValue.ToString
                    'If String.IsNullOrEmpty(e.FormattedValue.ToString) Then Return
                    'If bValid And strCredit.Length < 1 Then
                    If bValid Then
                        gridmelting.CurrentCell.Value = Convert.ToDecimal(gridmelting.Item(GGROSSWT.Index, e.RowIndex).Value)
                        gridmelting.Rows(gridmelting.CurrentRow.Index).Cells(GNETTWT.Index).Value = Convert.ToDecimal((gridmelting.Rows(gridmelting.CurrentRow.Index).Cells(GGROSSWT.Index).EditedFormattedValue * gridmelting.Rows(gridmelting.CurrentRow.Index).Cells(GPURITY.Index).Value) / 100)
                        ' everything is good
                    Else
                        MessageBox.Show("Invalid number")
                        e.Cancel = True
                    End If
            End Select
        End If

    End Sub

    Private Sub gridmelting_CurrentCellDirtyStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridmelting.CurrentCellDirtyStateChanged
        If gridmelting.IsCurrentCellDirty Then
            gridmelting.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Sub gridmelting_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridmelting.KeyDown

        If e.Alt = True And e.KeyCode = Keys.N Then
            gridmelting.Rows(0).Cells(GNETTWT.Index).Selected = True
            Call cmdok_Click(sender, e)
        End If

        If e.KeyCode = Keys.Delete Then
            If gridmelting.Rows(gridmelting.CurrentRow.Index).IsNewRow <> True Then gridmelting.Rows.RemoveAt(gridmelting.CurrentRow.Index)
            ' total()
        End If
        'If e.KeyCode = Keys.F2 Then
        '    dgdetails.Visible = True
        '    dt = New DataTable()
        '    If tempconn.State = ConnectionState.Open Then
        '        tempconn.Close()
        '    End If
        '    tempconn.Open()
        '    'tempcmd = New OleDbCommand("select item_productcode, lot_name, item_lp,  item_mrp,  AvgOfbill_lcost, SumOfbill_recqty,SumOfbill_setrecqty,  SumOfbill_freeqty,SumOfbill_packfreeqty,item_stockid from purchasetotal where item_code= '" & gridBill.Rows(gridBill.CurrentRow.Index).Cells(0).Value & "'", tempconn)
        '    tempcmd = New OleDbCommand("select where code= '" & gridmelting.Rows(gridmelting.CurrentRow.Index).Cells(0).Value & "'", tempconn)
        '    da = New OleDbDataAdapter(tempcmd)
        '    da.Fill(dt)
        '    dgdetails.DataSource = dt
        '    dgdetails.Focus()
        '    dgdetails.CurrentCell = dgdetails.Rows(0).Cells(1)

        '    dgdetails.Columns(0).Width = 100
        '    dgdetails.Columns(0).HeaderText = "Product Code"
        '    dgdetails.Columns(0).ReadOnly = True
        '    dgdetails.Columns(0).Resizable = DataGridViewTriState.False

        '    dgdetails.Columns(1).Width = 80
        '    dgdetails.Columns(1).HeaderText = "Lot Name"
        '    dgdetails.Columns(1).ReadOnly = True
        '    dgdetails.Columns(1).Resizable = DataGridViewTriState.False

        '    dgdetails.Columns(2).Width = 70
        '    dgdetails.Columns(2).HeaderText = "L.P"
        '    dgdetails.Columns(2).ReadOnly = True
        '    dgdetails.Columns(2).Resizable = DataGridViewTriState.False
        '    dgdetails.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight


        'End If

        If e.KeyCode = Keys.Return Then
            Dim cur_cell As DataGridViewCell = gridmelting.CurrentCell
            Dim col As Integer = cur_cell.ColumnIndex
            If col = gridmelting.Columns.Count - 1 And gridmelting.CurrentRow.Index < gridmelting.RowCount - 1 Then
                cur_cell = gridmelting.Rows(gridmelting.CurrentRow.Index + 1).Cells(0)
            Else
                col = (col + 1) Mod gridmelting.Columns.Count
                cur_cell = gridmelting.CurrentRow.Cells(col)
            End If
            gridmelting.CurrentCell = cur_cell
            e.Handled = True
        End If

        If e.KeyCode = Keys.F2 Then
            If gridmelting.CurrentCell.ColumnIndex = cmbitemname.Index Then
                Dim OBJITEM As New SelectItem
                OBJITEM.ShowDialog()
                gridmelting.CurrentCell.Value = OBJITEM.TEMPCODE
            End If
        End If

    End Sub

    Private Sub gridmelting_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridmelting.SelectionChanged
        If m_EditingRow >= 0 Then
            Dim new_row As Integer = m_EditingRow
            m_EditingRow = -1
            gridmelting.CurrentCell = gridmelting.Rows(new_row).Cells(gridmelting.CurrentCell.ColumnIndex)
        End If
        total()
    End Sub

    Private Sub txtloss_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtloss.KeyPress
        numdot(e, txtloss, Me)
    End Sub

    Private Sub txtoutput_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtoutput.KeyPress
        numdot(e, txtoutput, Me)
    End Sub

    Private Sub txtoutput_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtoutput.Validating
        txtloss.Text = Format(Val(txtgtotalwt.Text) - Val(txtoutput.Text), "0.000")
    End Sub

    Private Sub txtloss_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtloss.Validating
        txtoutput.Text = Format(Val(txtgtotalwt.Text) - Val(txtloss.Text), "0.000")
    End Sub

    Private Sub CMDDELETE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDDELETE.Click
        Try

            If cmdedit.Enabled = False And gridmelting.RowCount > 1 Then
                If USERDELETE = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                tempmsg = MsgBox("Delete Lot No. " & Val(txtmeltingno.Text) & "?", vbYesNo)
                If tempmsg = vbYes Then

                    'checking whether it is alredy mfg or not
                    cmd = New OleDbCommand("select melting_mfg from meltingmaster where melting_id = " & tempmeltingid, conn)
                    If conn.State = ConnectionState.Open Then
                        conn.Close()
                    End If
                    conn.Open()
                    dr = cmd.ExecuteReader
                    dr.Read()
                    If dr(0) = True Then
                        MsgBox("Lot Manufactured Can't Delete, Remove from Mfg 1st")
                        Exit Sub
                    End If

                    'deleting data from melting
                    cmd = New OleDbCommand("delete from meltingmaster where melting_id = " & tempmeltingid, conn)
                    If conn.State = ConnectionState.Open Then
                        conn.Close()
                    End If
                    conn.Open()
                    cmd.ExecuteNonQuery()

                    clear()
                    cmdedit.Enabled = True
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub tstxtbillno_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tstxtbillno.Validated
        Try
            'ask to save changes
            If gridmelting.RowCount > 0 And Val(txtreqmelting.Text) > 0 And chkchange.CheckState = CheckState.Checked Then
                tempmsg = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                If tempmsg = vbYes Then SAVE()
            End If
            tempmeltingid = txtmeltingno.Text + 1

            tempmeltingid = Val(tstxtbillno.Text.Trim)
            If tempmeltingid > 0 Then
                gridmelting.CurrentCell = gridmelting.Rows(0).Cells(1)
                cmdedit.Enabled = False
                edit = True
                Melting_Load(sender, e)
            Else
                clear()
                cmdedit.Enabled = True
                edit = False
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdwastagejama_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdwastagejama.Click
        Try
            Dim OBJWASJAMA As New WastageJama
            OBJWASJAMA.MdiParent = MDIMain
            OBJWASJAMA.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTBRASS_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTBRASS.KeyPress
        numdotkeypress(e, TXTBRASS, Me)
    End Sub

    Private Sub TXTBRASS_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTBRASS.TextChanged
        If Val(TXTBRASS.Text) <> 0 And Val(txtgtotalwt.Text) <> 0 Then
            LBLBRASS.Text = Format((Val(TXTBRASS.Text) / 100) * Val(txtalloy.Text), "0.000")
            'txtsilver.Text = 100 - Val(txtcopper.Text)
        End If
    End Sub

    Private Sub TXTREFNO_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTREFNO.Validating
        Try
            If (edit = False) And TXTREFNO.Text.Trim <> "" Then
                'CHECK DUPLICATE REFNO
                tempcmd = New OleDbCommand("select MELTING_REFNO from MELTINGMASTER where MELTING_REFNO = '" & TXTREFNO.Text.Trim & "'", tempconn)
                If tempconn.State = ConnectionState.Open Then
                    tempconn.Close()
                End If
                tempconn.Open()
                tempdr = tempcmd.ExecuteReader
                If tempdr.HasRows Then
                    MsgBox("Ref No Already Present", MsgBoxStyle.Critical)
                    e.Cancel = True
                    Exit Sub
                End If
                tempconn.Close()
                tempdr.Close()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class