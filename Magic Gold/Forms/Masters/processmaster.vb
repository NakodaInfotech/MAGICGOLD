
Imports System.Data.OleDb

Public Class processmaster

    Public EDIT As Boolean = False
    Dim m_EditingRow As Integer = -1

    Sub clear()

        'clearing array
        For i = 1 To 100
            tempcol(i) = ""
            tempval(i) = ""
        Next

        gridmelting.RowCount = 1

    End Sub

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        If gridmelting.RowCount > 0 And chkchange.CheckState = CheckState.Checked Then
            tempmsg = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
            If tempmsg = vbYes Then cmdok_Click(sender, e)
        End If
        Me.Close()
    End Sub

    Private Sub cmdclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        clear()
    End Sub

    Private Sub cmdok_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdok.Click

        If gridmelting.RowCount > 40 Then
            MsgBox("Process Exceeds Maximum Limit, Limit for 40 Processses", MsgBoxStyle.Critical)
            Exit Sub
        End If

        If lbllock.Visible = True Then
            MsgBox("Unable to Edit, Process Locked", MsgBoxStyle.Critical)
            Exit Sub
        End If

        If gridmelting.RowCount > 0 Then

            For Each row As DataGridViewRow In gridmelting.Rows
                If row.Index < gridmelting.RowCount - 1 Then
                    If row.Cells(1).Value = Nothing Or row.Cells(2).Value = Nothing Then
                        MsgBox("Enter Proper Values In Grid")
                        Exit Sub
                    End If
                End If
            Next

            tempmsg = MsgBox("Wish to Add the Sequence of Processes?", MsgBoxStyle.YesNo)
            If tempmsg = vbYes Then

                tempmsg = MsgBox("Are You Sure?", MsgBoxStyle.YesNo)
                If tempmsg = vbYes Then


                    If EDIT = True Then
                        'delete from processmaster
                        tempcmd = New OleDbCommand("delete from processmaster", tempconn)
                        If tempconn.State = ConnectionState.Open Then
                            tempconn.Close()
                        End If
                        tempconn.Open()
                        tempcmd.ExecuteNonQuery()
                    End If


                    For i = 0 To 100
                        tempcol(i) = ""
                        tempval(i) = ""
                    Next

                    tempcol(0) = "process_seq"
                    tempcol(1) = "process_no"
                    tempcol(2) = "process_name"
                    tempcol(3) = "process_ledgerid"
                    tempcol(4) = "process_userid"
                    tempcol(5) = "process_loss"
                    tempcol(6) = "process_vaccum"
                    tempcol(7) = "process_karigar"
                    tempcol(8) = "process_excess"
                    tempcol(9) = "PROCESS_MAXLOSS"


                    For i = 0 To gridmelting.RowCount - 2

                        If rbsequence.Checked = True Then
                            tempval(0) = True
                        Else
                            tempval(0) = False
                        End If

                        tempval(1) = i + 1 '"'" & gridmelting.Item(0, i).Value.ToString & "'"
                        tempval(2) = "'" & gridmelting.Item(1, i).Value.ToString & "'"

                        'getting ledgerid
                        tempcmd = New OleDbCommand("select ledger_id from ledgermaster where ledger_name = '" & gridmelting.Item(2, i).Value.ToString & "'", tempconn)
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

                        tempval(4) = tempuserid

                        If gridmelting.Rows(i).Cells(3).Value = False Then
                            tempval(5) = "False"
                        Else
                            tempval(5) = "True"
                        End If

                        If gridmelting.Rows(i).Cells(4).Value = False Then
                            tempval(6) = "False"
                        Else
                            tempval(6) = "True"
                        End If

                        If gridmelting.Rows(i).Cells(5).Value = False Then
                            tempval(7) = "False"
                        Else
                            tempval(7) = "True"
                        End If

                        If gridmelting.Rows(i).Cells(6).Value = False Then
                            tempval(8) = "False"
                        Else
                            tempval(8) = "True"
                        End If


                        If gridmelting.Item(GMAX.Index, i).EditedFormattedValue = Nothing Then
                            tempval(9) = 0.0
                        Else
                            tempval(9) = Val(gridmelting.Item(GMAX.Index, i).EditedFormattedValue)
                        End If

                        insert("processmaster", tempcol, tempval)

                    Next

                    MessageBox.Show("Details Added")
                    Call processmaster_Shown(sender, e)
                    Me.Close()

                End If

            End If
        Else
            MsgBox("Enter Valid Details")
        End If

    End Sub

    Private Sub processmaster_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Alt = True And e.KeyCode = Windows.Forms.Keys.S Then       'for Saving
            Call cmdok_Click(sender, e)
        ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            If gridmelting.RowCount > 0 And chkchange.CheckState = CheckState.Checked Then
                tempmsg = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                If tempmsg = vbYes Then cmdok_Click(sender, e)
            End If
            Me.Close()
        ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.C Then       'for clear
            Call cmdclear_Click(sender, e)
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub processmaster_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        'esc
        If AscW(e.KeyChar) <> 33 Then
            chkchange.CheckState = CheckState.Checked
        End If
    End Sub

    Sub fillacc()

        tempcondition = ""
        'getting name as stock in hand
        tempcmd = New OleDbCommand("select group_id from groupmaster where group_name = 'Stock In Hand'", tempconn)
        If tempconn.State = ConnectionState.Open Then
            tempconn.Close()
        End If
        tempconn.Open()
        tempdr = tempcmd.ExecuteReader
        If tempdr.HasRows Then
            tempdr.Read()

            cmd = New OleDbCommand("select ledger_name from ledgermaster where ledger_groupid = " & tempdr(0), conn)
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
            conn.Open()
            dr = cmd.ExecuteReader
            If dr.HasRows Then
                cmbacc.Items.Clear()
                While (dr.Read)
                    cmbacc.Items.Add(dr(0).ToString)
                End While
            End If
        End If

    End Sub

    Private Sub processmaster_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

        clear()
        fillacc()


        'checking whether process is present or not if present then edit = true
        cmd = New OleDbCommand("select processmaster.process_no,processmaster.process_name,ledgermaster.ledger_name,processmaster.process_loss,processmaster.process_vaccum,processmaster.process_karigar,processmaster.process_excess,processmaster.process_seq from processmaster inner join ledgermaster on ledgermaster.ledger_id = processmaster.process_ledgerid order by processmaster.process_no", conn)
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If
        conn.Open()
        dr = cmd.ExecuteReader
        If dr.HasRows = True Then
            While (dr.Read())

                'filling gridmelting
                gridmelting.Rows.Add(dr(0), dr(1).ToString, dr(2).ToString, dr(3), dr(4), dr(5), dr(6))

                If dr(7).ToString = True Then
                    rbsequence.Checked = True
                Else
                    rbrandom.Checked = True
                End If

            End While
            cmdedit.Enabled = False
            edit = True
            'groupprocess.Enabled = False
        End If

        'disable the save btn. and show locked lbl
        If cmdedit.Enabled = False Then
            cmd = New OleDbCommand("select * from mfgmaster", conn)
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
            conn.Open()
            dr = cmd.ExecuteReader
            If dr.HasRows = True Then
                dr.Read()
                cmdok.Enabled = False
                cmdclear.Enabled = False
                lbllock.Visible = True
            End If
        End If


    End Sub

    Private Sub gridmelting_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridmelting.CellClick
        If e.RowIndex >= 0 Then
            If e.ColumnIndex = 3 Then
                With gridmelting.Rows(e.RowIndex).Cells(3)
                    If .Value = True Then
                        .Value = False
                        gridmelting.Rows(e.RowIndex).Cells(4).Value = True
                        gridmelting.Rows(e.RowIndex).Cells(6).Value = False
                    Else
                        .Value = True
                        gridmelting.Rows(e.RowIndex).Cells(4).Value = False
                        gridmelting.Rows(e.RowIndex).Cells(6).Value = False
                    End If
                End With
            End If

            If e.ColumnIndex = 4 Then
                With gridmelting.Rows(e.RowIndex).Cells(4)
                    If .Value = True Then
                        .Value = False
                        gridmelting.Rows(e.RowIndex).Cells(3).Value = True
                        gridmelting.Rows(e.RowIndex).Cells(6).Value = False
                    Else
                        .Value = True
                        gridmelting.Rows(e.RowIndex).Cells(3).Value = False
                        gridmelting.Rows(e.RowIndex).Cells(6).Value = False
                    End If
                End With
            End If

            If e.ColumnIndex = 6 Then
                With gridmelting.Rows(e.RowIndex).Cells(6)
                    If .Value = True Then
                        .Value = False
                        gridmelting.Rows(e.RowIndex).Cells(3).Value = True
                        gridmelting.Rows(e.RowIndex).Cells(4).Value = False
                    Else
                        .Value = True
                        gridmelting.Rows(e.RowIndex).Cells(3).Value = False
                        gridmelting.Rows(e.RowIndex).Cells(4).Value = False
                    End If
                End With
            End If


            'With gridmelting.Rows(e.RowIndex).Cells(3)
            '    If .Value = True Then
            '        .Value = False
            '        gridmelting.Rows(e.RowIndex).Cells(4).Value = True
            '    Else
            '        .Value = True
            '        gridmelting.Rows(e.RowIndex).Cells(4).Value = False
            '    End If
            'End With

            'With gridmelting.Rows(e.RowIndex).Cells(4)
            '    If .Value = True Then
            '        .Value = False
            '        gridmelting.Rows(e.RowIndex).Cells(3).Value = True
            '    Else
            '        .Value = True
            '        gridmelting.Rows(e.RowIndex).Cells(3).Value = False
            '    End If
            'End With

            'With gridmelting.Rows(e.RowIndex).Cells(5)
            '    If .Value = True Then
            '        .Value = False
            '    Else
            '        .Value = True
            '    End If
            'End With

            'With gridmelting.Rows(e.RowIndex).Cells(6)
            '    If .Value = True Then
            '        .Value = False
            '    Else
            '        .Value = True
            '    End If
            'End With

        End If
    End Sub

    Private Sub gridmelting_CellValidated(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridmelting.CellValidated
        If e.ColumnIndex = 2 Then fillacc()
    End Sub

    Private Sub gridmelting_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles gridmelting.CellValidating

        If e.ColumnIndex = 1 And gridmelting.CurrentCell.Value <> Nothing Then
            gridmelting.CurrentCell.Value = uppercase(gridmelting.CurrentCell.Value)
        End If

        'FOR CORRECT NUM FORMAT 
        Dim colNum As Integer = gridmelting.Columns(e.ColumnIndex).Index
        If String.IsNullOrEmpty(e.FormattedValue.ToString) Then Return
        Select Case colNum
            Case GMAX.Index
                Dim dDebit As Decimal
                Dim bValid As Boolean = Decimal.TryParse(e.FormattedValue.ToString, dDebit)

                If bValid Then
                    If gridmelting.CurrentCell.Value = Nothing Then gridmelting.CurrentCell.Value = "0.000"
                    gridmelting.CurrentCell.Value = Convert.ToDecimal(gridmelting.Item(colNum, e.RowIndex).Value)
                    '' everything is good
                Else
                    MessageBox.Show("Invalid Number Entered")
                    e.Cancel = True
                    Exit Sub
                End If
        End Select


        'FOR CMB
        If (TypeOf CType(sender, DataGridView).EditingControl Is DataGridViewComboBoxEditingControl) Then
            Dim cmb As DataGridViewComboBoxEditingControl = CType(CType(sender, DataGridView).EditingControl, DataGridViewComboBoxEditingControl)
            If Not cmb Is Nothing Then
                Dim grid As DataGridView = cmb.EditingControlDataGridView
                Dim value As Object = uppercase(cmb.Text)
                If cmb.Text.Trim <> "" Then

                    cmd = New OleDbCommand("SELECT ledgermaster.ledger_id from ledgermaster inner join groupmaster on groupmaster.group_id = ledgermaster.ledger_groupid where ledgermaster.ledger_name = '" & cmb.Text.Trim & "' and ( groupmaster.group_name = 'Stock In Hand')", conn)
                    If conn.State = ConnectionState.Open Then
                        conn.Close()
                    End If
                    conn.Open()
                    dr = cmd.ExecuteReader
                    If dr.HasRows = False Then
                        '// Must add to both the current combobox as well as the template, to avoid duplicate entries...
                        'cmb.Items.Add(value)
                        'Dim cmbCol As DataGridViewComboBoxColumn = CType(grid.Columns(grid.CurrentCell.ColumnIndex), DataGridViewComboBoxColumn)
                        'If Not cmbCol Is Nothing Then
                        '    'cmbCol.Items.Add(value)
                        'End If

                        'ask to save new entry
                        tempmsg = MsgBox("Ledger Not Present, Add New?", MsgBoxStyle.YesNo)
                        If tempmsg = vbYes Then

                            Dim OBJVENDOR As New ACCOUNTMASTER
                            OBJVENDOR.MdiParent = MDIMain
                            edit = False
                            e.Cancel = True
                            OBJVENDOR.ActiveControl = OBJVENDOR.txtname
                            OBJVENDOR.txtname.Focus()
                            OBJVENDOR.Show()
                            
                        Else
                            cmb.Text = cmb.Text
                            cmb.Focus()
                            e.Cancel = True
                        End If

                    Else
                        If cmb.Items.IndexOf(value) = -1 Then
                            cmb.Items.Add(value)
                            Dim cmbCol As DataGridViewComboBoxColumn = CType(grid.Columns(grid.CurrentCell.ColumnIndex), DataGridViewComboBoxColumn)
                            If Not cmbCol Is Nothing Then
                                cmbCol.Items.Add(value)
                            End If
                        End If
                        grid.CurrentCell.Value = value
                    End If

                End If

            End If
        End If

    End Sub

    Sub total()
        For Each row As DataGridViewRow In gridmelting.Rows
            If row.Cells(1).Value <> Nothing Or row.Cells(2).Value <> Nothing Then
                row.Cells(0).Value = row.Index + 1
            End If
        Next
    End Sub

    Private Sub gridmelting_CurrentCellDirtyStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridmelting.CurrentCellDirtyStateChanged
        If gridmelting.IsCurrentCellDirty Then
            gridmelting.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
        total()
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

    Private Sub gridmelting_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridmelting.KeyDown

        If e.KeyCode = Keys.Delete Then
            If gridmelting.Rows(gridmelting.CurrentRow.Index).IsNewRow <> True Then gridmelting.Rows.RemoveAt(gridmelting.CurrentRow.Index)
            total()
        End If

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
    End Sub

    Private Sub gridmelting_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridmelting.SelectionChanged
        If m_EditingRow >= 0 Then
            Dim new_row As Integer = m_EditingRow
            m_EditingRow = -1
            gridmelting.CurrentCell = gridmelting.Rows(new_row).Cells(gridmelting.CurrentCell.ColumnIndex)
        End If
    End Sub


End Class