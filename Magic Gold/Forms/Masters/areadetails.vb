Imports System.Data.oledb

Public Class areadetails

    Private Sub areadetails_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        fillgrid()
    End Sub

    Sub fillgrid()

        dt = New DataTable()
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If
        conn.Open()

        If frmareamaster = True And frmcitymaster = False And frmstatemaster = False And frmcountrymaster = False And frmcategorymaster = False And frmtypemaster = False Then
            tempcmd = New OleDbCommand("select areamaster.area_name, areamaster.area_id from areamaster order by area_name ", tempconn)
        ElseIf frmareamaster = False And frmcitymaster = True And frmstatemaster = False And frmcountrymaster = False And frmcategorymaster = False And frmtypemaster = False Then
            tempcmd = New OleDbCommand("select citymaster.city_name, citymaster.city_id from citymaster order by city_name", tempconn)
        ElseIf frmareamaster = False And frmcitymaster = False And frmstatemaster = True And frmcountrymaster = False And frmcategorymaster = False And frmtypemaster = False Then
            tempcmd = New OleDbCommand("select statemaster.state_name, statemaster.state_id from statemaster order by state_name", tempconn)
        ElseIf frmareamaster = False And frmcitymaster = False And frmstatemaster = False And frmcountrymaster = True And frmcategorymaster = False And frmtypemaster = False Then
            tempcmd = New OleDbCommand("select countrymaster.country_name, countrymaster.country_id from countrymaster order by country_name ", tempconn)
        ElseIf frmareamaster = False And frmcitymaster = False And frmstatemaster = False And frmcountrymaster = False And frmcategorymaster = True And frmtypemaster = False Then
            tempcmd = New OleDbCommand("select categorymaster.category_name, categorymaster.category_id from categorymaster order by category_name ", tempconn)
        ElseIf frmareamaster = False And frmcitymaster = False And frmstatemaster = False And frmcountrymaster = False And frmcategorymaster = False And frmtypemaster = True Then
            tempcmd = New OleDbCommand("select typemaster.type_name, typemaster.type_id from typemaster order by type_name", tempconn)
        End If



        da = New OleDbDataAdapter(tempcmd)
        da.Fill(dt)

        gridlocation.DataSource = dt
        If frmareamaster = True And frmcitymaster = False And frmstatemaster = False And frmcountrymaster = False And frmcategorymaster = False And frmtypemaster = False Then

            Me.Text = "Area Details"
            cmdedit.Text = "Edit Area..."
            newarea.Text = "New Area"
            gridlocation.Columns(0).HeaderText = "Area"

        ElseIf frmareamaster = False And frmcitymaster = True And frmstatemaster = False And frmcountrymaster = False And frmcategorymaster = False And frmtypemaster = False Then

            Me.Text = "City Details"
            cmdedit.Text = "Edit City..."
            newarea.Text = "New City"
            gridlocation.Columns(0).HeaderText = "City"

        ElseIf frmareamaster = False And frmcitymaster = False And frmstatemaster = True And frmcountrymaster = False And frmcategorymaster = False And frmtypemaster = False Then

            Me.Text = "State Details"
            cmdedit.Text = "Edit State..."
            newarea.Text = "New State"
            gridlocation.Columns(0).HeaderText = "State"

        ElseIf frmareamaster = False And frmcitymaster = True And frmstatemaster = False And frmcountrymaster = True And frmcategorymaster = False And frmtypemaster = False Then

            Me.Text = "Country Details"
            cmdedit.Text = "Edit Country..."
            newarea.Text = "New Country"
            gridlocation.Columns(0).HeaderText = "Country"

        ElseIf frmareamaster = False And frmcitymaster = True And frmstatemaster = False And frmcountrymaster = False And frmcategorymaster = True And frmtypemaster = False Then

            Me.Text = "Category Details"
            cmdedit.Text = "Edit Category..."
            newarea.Text = "New Category"
            gridlocation.Columns(0).HeaderText = "Category"

        ElseIf frmareamaster = False And frmcitymaster = True And frmstatemaster = False And frmcountrymaster = False And frmcategorymaster = False And frmtypemaster = True Then

            Me.Text = "Item Type Details"
            cmdedit.Text = "Edit Item Type..."
            newarea.Text = "New Item Type"
            gridlocation.Columns(0).HeaderText = "Item Type"

        End If

        gridlocation.Columns(1).Visible = False
        gridlocation.Columns(0).Width = 330


        da.Dispose()
        dt.Dispose()
        tempconn.Close()
        tempcmd.Dispose()

        'gridlocation.Sort(group, System.ComponentModel.ListSortDirection.Ascending)


    End Sub

    Private Sub gridlocation_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridlocation.CellDoubleClick
        If e.RowIndex >= 0 Then Call cmdedit_Click(sender, e)
    End Sub

    Private Sub newarea_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles newarea.Click

        If (chldareamaster.IsMdiChild = False) Then
            If chldareamaster.IsDisposed = True Then
                chldareamaster = New areamaster
            End If
            Me.Close()
            chldareamaster.MdiParent = MDIMain
            chldareamaster.Show()
        Else
            chldareamaster.BringToFront()
        End If

    End Sub

    Private Sub cmdedit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdedit.Click
        Try
            Dim OBJAREA As New areamaster
            OBJAREA.MdiParent = MDIMain
            OBJAREA.txtname.Text = gridlocation.CurrentRow.Cells(0).Value
            OBJAREA.TEMPID = gridlocation.CurrentRow.Cells(1).Value
            OBJAREA.EDIT = True
            OBJAREA.cmdedit.Enabled = False
            OBJAREA.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub txtname_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtname.KeyPress
        enterkeypress(e, Me)
    End Sub

    Private Sub txtname_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtname.TextChanged
        Dim rowno, b As Integer

        fillgrid()
        rowno = 0
        For b = 1 To gridlocation.RowCount
            txttempname.Text = gridlocation.Item(0, rowno).Value.ToString()
            txttempname.SelectionStart = 0
            txttempname.SelectionLength = txtname.TextLength
            If LCase(txtname.Text.Trim) <> LCase(txttempname.SelectedText.Trim) Then
                gridlocation.Rows.RemoveAt(rowno)
            Else
                rowno = rowno + 1
            End If
        Next

    End Sub

    Private Sub ToolStripdelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripdelete.Click

        For Each row As DataGridViewRow In gridlocation.SelectedRows

            If frmareamaster = True Then

                tempmsg = MsgBox("Delete Area?", MsgBoxStyle.YesNo)
                If tempmsg = vbYes Then

                    'getting its id
                    cmd = New OleDbCommand("select area_id from areamaster where area_name = '" & row.Cells(0).Value.ToString & "'", conn)
                    If conn.State = ConnectionState.Open Then
                        conn.Close()
                    End If
                    conn.Open()
                    dr = cmd.ExecuteReader
                    If dr.HasRows = True Then
                        dr.Read()
                        tempareaid = dr(0).ToString
                    End If


                    'checking related records
                    'from ledgermaster
                    cmd = New OleDbCommand("select ledger_id from ledgermaster where ledger_areaid = " & tempareaid, conn)
                    If conn.State = ConnectionState.Open Then
                        conn.Close()
                    End If
                    conn.Open()
                    dr = cmd.ExecuteReader()
                    If dr.HasRows = True Then
                        MessageBox.Show("First Delete all Related Records from Accounts")
                        Exit Sub
                    End If


                    'deleteing from areamaster
                    cmd = New OleDbCommand("delete from areamaster where area_id = " & tempareaid, conn)
                    If conn.State = ConnectionState.Open Then
                        conn.Close()
                    End If
                    conn.Open()
                    cmd.ExecuteNonQuery()

                End If

            ElseIf frmcitymaster = True Then

                tempmsg = MsgBox("Delete City?", MsgBoxStyle.YesNo)
                If tempmsg = vbYes Then

                    'getting its id
                    cmd = New OleDbCommand("select city_id from citymaster where city_name = '" & row.Cells(0).Value.ToString & "'", conn)
                    If conn.State = ConnectionState.Open Then
                        conn.Close()
                    End If
                    conn.Open()
                    dr = cmd.ExecuteReader
                    If dr.HasRows = True Then
                        dr.Read()
                        tempcityid = dr(0).ToString
                    End If


                    'checking related records
                    'from challanmaster
                    cmd = New OleDbCommand("select challan_no from challanmaster where challan_cityid = " & tempcityid, conn)
                    If conn.State = ConnectionState.Open Then
                        conn.Close()
                    End If
                    conn.Open()
                    dr = cmd.ExecuteReader()
                    If dr.HasRows = True Then
                        MessageBox.Show("First Delete all Related Records from Challan")
                        Exit Sub
                    End If


                    'from ledgermaster
                    cmd = New OleDbCommand("select ledger_id from ledgermaster where ledger_cityid = " & tempcityid, conn)
                    If conn.State = ConnectionState.Open Then
                        conn.Close()
                    End If
                    conn.Open()
                    dr = cmd.ExecuteReader()
                    If dr.HasRows = True Then
                        MessageBox.Show("First Delete all Related Records from Accounts")
                        Exit Sub
                    End If


                    'from purchasemaster
                    cmd = New OleDbCommand("select bill_no from purchasemaster where bill_cityid = " & tempcityid, conn)
                    If conn.State = ConnectionState.Open Then
                        conn.Close()
                    End If
                    conn.Open()
                    dr = cmd.ExecuteReader()
                    If dr.HasRows = True Then
                        MessageBox.Show("First Delete all Related Records from Purchase Invoice")
                        Exit Sub
                    End If


                    'deleteing from citymaster
                    cmd = New OleDbCommand("delete from citymaster where city_id = " & tempcityid, conn)
                    If conn.State = ConnectionState.Open Then
                        conn.Close()
                    End If
                    conn.Open()
                    cmd.ExecuteNonQuery()


                ElseIf frmstatemaster = True Then

                    tempmsg = MsgBox("Delete State?", MsgBoxStyle.YesNo)
                    If tempmsg = vbYes Then

                        'getting its id
                        cmd = New OleDbCommand("select state_id from statemaster where state_name = '" & row.Cells(0).Value.ToString & "'", conn)
                        If conn.State = ConnectionState.Open Then
                            conn.Close()
                        End If
                        conn.Open()
                        dr = cmd.ExecuteReader
                        If dr.HasRows = True Then
                            dr.Read()
                            tempstateid = dr(0).ToString
                        End If


                        'checking related records
                        'from ledgermaster
                        cmd = New OleDbCommand("select ledger_id from ledgermaster where ledger_stateid = " & tempstateid, conn)
                        If conn.State = ConnectionState.Open Then
                            conn.Close()
                        End If
                        conn.Open()
                        dr = cmd.ExecuteReader()
                        If dr.HasRows = True Then
                            MessageBox.Show("First Delete all Related Records from Accounts")
                            Exit Sub
                        End If


                        'deleteing from statemaster
                        cmd = New OleDbCommand("delete from statemaster where state_id = " & tempstateid, conn)
                        If conn.State = ConnectionState.Open Then
                            conn.Close()
                        End If
                        conn.Open()
                        cmd.ExecuteNonQuery()

                    End If

                ElseIf frmcountrymaster = True Then

                    tempmsg = MsgBox("Delete Country?", MsgBoxStyle.YesNo)
                    If tempmsg = vbYes Then

                        'getting its id
                        cmd = New OleDbCommand("select country_id from countrymaster where country_name = '" & row.Cells(0).Value.ToString & "'", conn)
                        If conn.State = ConnectionState.Open Then
                            conn.Close()
                        End If
                        conn.Open()
                        dr = cmd.ExecuteReader
                        If dr.HasRows = True Then
                            dr.Read()
                            tempcountryid = dr(0).ToString
                        End If


                        'checking related records
                        'from ledgermaster
                        cmd = New OleDbCommand("select ledger_id from ledgermaster where ledger_countryid = " & tempcountryid, conn)
                        If conn.State = ConnectionState.Open Then
                            conn.Close()
                        End If
                        conn.Open()
                        dr = cmd.ExecuteReader()
                        If dr.HasRows = True Then
                            MessageBox.Show("First Delete all Related Records from Accounts")
                            Exit Sub
                        End If


                        'deleteing from countrymaster
                        cmd = New OleDbCommand("delete from countrymaster where country_id = " & tempcountryid, conn)
                        If conn.State = ConnectionState.Open Then
                            conn.Close()
                        End If
                        conn.Open()
                        cmd.ExecuteNonQuery()

                    End If

                ElseIf frmcategorymaster = True Then

                    tempmsg = MsgBox("Delete Category?", MsgBoxStyle.YesNo)
                    If tempmsg = vbYes Then

                        'getting its id
                        cmd = New OleDbCommand("select Category_id from Categorymaster where Category_name = '" & row.Cells(0).Value.ToString & "'", conn)
                        If conn.State = ConnectionState.Open Then
                            conn.Close()
                        End If
                        conn.Open()
                        dr = cmd.ExecuteReader
                        If dr.HasRows = True Then
                            dr.Read()
                            tempcategoryid = dr(0).ToString
                        End If


                        'checking related records
                        'from itemmaster
                        cmd = New OleDbCommand("select item_id from itemmaster where item_Categoryid = " & tempcategoryid, conn)
                        If conn.State = ConnectionState.Open Then
                            conn.Close()
                        End If
                        conn.Open()
                        dr = cmd.ExecuteReader()
                        If dr.HasRows = True Then
                            MessageBox.Show("First Delete all Related Records from Item")
                            Exit Sub
                        End If


                        'deleteing from Categorymaster
                        cmd = New OleDbCommand("delete from Categorymaster where Category_id = " & tempcategoryid, conn)
                        If conn.State = ConnectionState.Open Then
                            conn.Close()
                        End If
                        conn.Open()
                        cmd.ExecuteNonQuery()

                    End If

                ElseIf frmtypemaster = True Then

                    tempmsg = MsgBox("Delete Item Type?", MsgBoxStyle.YesNo)
                    If tempmsg = vbYes Then

                        'getting its id
                        cmd = New OleDbCommand("select type_id from typemaster where type_name = '" & row.Cells(0).Value.ToString & "'", conn)
                        If conn.State = ConnectionState.Open Then
                            conn.Close()
                        End If
                        conn.Open()
                        dr = cmd.ExecuteReader
                        If dr.HasRows = True Then
                            dr.Read()
                            temptypeid = dr(0).ToString
                        End If


                        'checking related records
                        'from itemmaster
                        cmd = New OleDbCommand("select item_id from itemmaster where item_typeid = " & temptypeid, conn)
                        If conn.State = ConnectionState.Open Then
                            conn.Close()
                        End If
                        conn.Open()
                        dr = cmd.ExecuteReader()
                        If dr.HasRows = True Then
                            MessageBox.Show("First Delete all Related Records from Item")
                            Exit Sub
                        End If


                        'deleteing from Categorymaster
                        cmd = New OleDbCommand("delete from typemaster where type_id = " & temptypeid, conn)
                        If conn.State = ConnectionState.Open Then
                            conn.Close()
                        End If
                        conn.Open()
                        cmd.ExecuteNonQuery()

                    End If

                End If

            End If
        Next

    End Sub

    Private Sub areadetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If

        '*********** CTRL + N ************
        If e.Control = True Then
            If e.KeyCode = Keys.N Then

                If (chldareamaster.IsMdiChild = False) Then
                    If chldareamaster.IsDisposed = True Then
                        chldareamaster = New areamaster
                    End If
                    chldareamaster.MdiParent = MDIMain
                    chldareamaster.Show()
                Else
                    chldareamaster.BringToFront()
                End If
            End If
        End If
    End Sub


End Class