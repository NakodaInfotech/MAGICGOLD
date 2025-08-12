Imports System.Data.OleDb

Public Class StockFilter

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub

    Sub getFromToDate()
        a1 = DatePart(DateInterval.Day, dtpfrom.Value)
        a2 = DatePart(DateInterval.Month, dtpfrom.Value)
        a3 = DatePart(DateInterval.Year, dtpfrom.Value)
        fromD = "(" & a3 & "," & a2 & "," & a1 & ")"

        a11 = DatePart(DateInterval.Day, dtpto.Value)
        a12 = DatePart(DateInterval.Month, dtpto.Value)
        a13 = DatePart(DateInterval.Year, dtpto.Value)
        toD = "(" & a13 & "," & a12 & "," & a11 & ")"
    End Sub

    Private Sub cmdShowReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShowReport.Click

        strsearch = ""
        If frmstring = "" Then

            Dim CONDITION As String = ""

            For Each ROW As DataGridViewRow In griditem.Rows
                If Convert.ToBoolean(ROW.Cells(GCHK.Index).Value) = True Then
                    If CONDITION = "" Then
                        CONDITION = " AND (STOCKS.ITEM_CODE = '" & ROW.Cells(GITEMNAME.Index).Value & "'"
                    Else
                        CONDITION = CONDITION & " OR STOCKS.ITEM_CODE = '" & ROW.Cells(GITEMNAME.Index).Value & "'"
                    End If
                End If
            Next

            If CONDITION <> "" Then CONDITION = CONDITION & ")"

            CONDITION = " WHERE 1=1 " & CONDITION

            If cmbname.Text.Trim <> "" Then CONDITION = CONDITION & " AND STOCKS.LEDGER = '" & cmbname.Text.Trim & "'"
            If chkdate.CheckState = CheckState.Checked Then CONDITION = CONDITION & " AND STOCKS.ITEM_DATE BETWEEN #" & Format(dtpfrom.Value, "MM/dd/yyyy") & "# AND #" & Format(dtpto.Value, "MM/dd/yyyy") & "#"
            If Val(txtpurity.Text.Trim) > 0 Then CONDITION = CONDITION & " AND STOCKS.ITEM_PURITY = " & Format(Val(txtpurity.Text), "0.00")


            Dim OBJSTOCK As New StockDetails
            OBJSTOCK.MdiParent = MDIMain
            OBJSTOCK.STRCONDITION = CONDITION
            OBJSTOCK.Show()

            'For i = 0 To griditem.RowCount - 1
            '    If griditem.Item(0, i).Value = True Then
            '        If strsearch = "" Then

            '            strsearch = strsearch & "  {stocks.item_code}= '" & griditem.Item(1, i).Value.ToString & "'"
            '            If cmbname.Text.Trim <> "" Then
            '                If strsearch = "" Then
            '                    strsearch = strsearch & " {stocks.ledger} = '" & cmbname.Text.Trim & "'"
            '                Else
            '                    strsearch = strsearch & " and {stocks.ledger} = '" & cmbname.Text.Trim & "'"

            '                End If
            '            End If
            '            If txtpurity.Text.Trim <> "" Then
            '                If strsearch = "" Then
            '                    strsearch = strsearch & " {stocks.item_purity} = " & Val(txtpurity.Text.Trim) & ""
            '                Else
            '                    strsearch = strsearch & " and {stocks.item_purity} = " & Val(txtpurity.Text.Trim) & ""
            '                End If
            '            End If
            '            If chkdate.Checked = True Then

            '                getFromToDate()
            '                If strsearch <> "" Then
            '                    strsearch = strsearch & " and {stocks.item_date} in date" & fromD & " to date" & toD
            '                Else
            '                    strsearch = strsearch & " {stocks.item_date} in date" & fromD & " to date" & toD
            '                End If
            '            End If
            '        Else
            '            strsearch = strsearch & " or {stocks.item_code}= '" & griditem.Item(1, i).Value.ToString & "'"
            '            If cmbname.Text.Trim <> "" Then
            '                If strsearch = "" Then
            '                    strsearch = strsearch & " {stocks.ledger} = '" & cmbname.Text.Trim & "'"
            '                Else
            '                    strsearch = strsearch & " and {stocks.ledger} = '" & cmbname.Text.Trim & "'"

            '                End If
            '            End If
            '            If txtpurity.Text.Trim <> "" Then
            '                If strsearch = "" Then
            '                    strsearch = strsearch & " {stocks.item_purity} = " & Val(txtpurity.Text.Trim) & ""
            '                Else
            '                    strsearch = strsearch & " and {stocks.item_purity} = " & Val(txtpurity.Text.Trim) & ""
            '                End If
            '            End If
            '            If chkdate.Checked = True Then

            '                getFromToDate()
            '                If strsearch <> "" Then
            '                    strsearch = strsearch & " and {stocks.item_date} in date" & fromD & " to date" & toD
            '                Else
            '                    strsearch = strsearch & " {stocks.item_date} in date" & fromD & " to date" & toD
            '                End If
            '            End If
            '        End If
            '    End If
            'Next


            'For i = 0 To gridcategory.RowCount - 1
            '    If gridcategory.Item(0, i).Value = True Then
            '        If strsearch = "" Then
            '            strsearch = strsearch & "  {stocks.category_name}= '" & gridcategory.Item(1, i).Value.ToString & "'"
            '        Else
            '            strsearch = strsearch & " and {stocks.category_name}= '" & gridcategory.Item(1, i).Value.ToString & "'"
            '        End If
            '    End If
            'Next

            'If cmbname.Text.Trim <> "" Then
            '    If strsearch = "" Then
            '        strsearch = strsearch & " {stocks.ledger} = '" & cmbname.Text.Trim & "'"
            '    Else
            '        strsearch = strsearch & " and {stocks.ledger} = '" & cmbname.Text.Trim & "'"

            '    End If
            'End If

            'If chkdate.Checked = True Then

            '    getFromToDate()
            '    If strsearch <> "" Then
            '        strsearch = strsearch & " and {stocks.item_date} in date" & fromD & " to date" & toD
            '    Else
            '        strsearch = strsearch & " {stocks.item_date} in date" & fromD & " to date" & toD
            '    End If
            'End If

            'If Val(txtpurity.Text.Trim) <> 0 Then
            '    If strsearch = "" Then
            '        strsearch = strsearch & " {stocks.item_purity} = " & Val(txtpurity.Text.Trim) & ""
            '    Else
            '        strsearch = strsearch & " and {stocks.item_purity} = " & Val(txtpurity.Text.Trim) & ""
            '    End If
            'End If
            'StocksDesign.Show()

        Else
            getFromToDate()
            For i = 0 To griditem.RowCount - 1
                If griditem.Item(0, i).Value = True Then
                    If strsearch = "" Then

                        strsearch = strsearch & "  {accounts.item_code}= '" & griditem.Item(1, i).Value.ToString & "'"
                    Else
                        strsearch = strsearch & " or {accounts.item_code}= '" & griditem.Item(1, i).Value.ToString & "'"
                    End If
                End If
            Next
            If strsearch <> "" Then
                strsearch = "(" & strsearch & ")"
            End If
            If cmbname.Text.Trim <> "" Then
                If strsearch = "" Then
                    strsearch = strsearch & " {accounts.ledger} = '" & cmbname.Text.Trim & "'"
                Else
                    strsearch = strsearch & " and {accounts.ledger} = '" & cmbname.Text.Trim & "'"

                End If
            End If
            If txtpurity.Text.Trim <> "" Then
                If strsearch = "" Then
                    strsearch = strsearch & " ({accounts.item_purity} = " & Val(txtpurity.Text.Trim) & ")"
                Else
                    strsearch = strsearch & " and ({accounts.item_purity} = " & Val(txtpurity.Text.Trim) & ")"
                End If
            End If
            If chkdate.Checked = True Then


                If strsearch <> "" Then
                    strsearch = strsearch & " and ({accounts.item_date} in date" & fromD & " to date" & toD & ")"
                Else
                    strsearch = strsearch & " ({accounts.item_date} in date" & fromD & " to date" & toD & ")"
                End If
            End If
            accountdesign.Show()
        End If

    End Sub

    Private Sub StockFilter_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                Me.Close()
            ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.S Then       'for SHOW REPORT
                Call cmdShowReport_Click(sender, e)
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub StockFilter_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        tempcondition = ""
        'getting name as sundry creditors and sundry debitors
        tempcmd = New OleDbCommand("select group_id from groupmaster where group_name = 'Sundry Debtors'", tempconn)
        If tempconn.State = ConnectionState.Open Then
            tempconn.Close()
        End If
        tempconn.Open()
        tempdr = tempcmd.ExecuteReader
        If tempdr.HasRows Then
            tempdr.Read()
            tempcondition = " and( ledger_groupid = " & tempdr(0)
        End If

        tempcmd = New OleDbCommand("select group_id from groupmaster where group_name = 'Sundry Creditors'", tempconn)
        If tempconn.State = ConnectionState.Open Then
            tempconn.Close()
        End If
        tempconn.Open()
        tempdr = tempcmd.ExecuteReader
        If tempdr.HasRows Then
            tempdr.Read()
            tempcondition = tempcondition & " or ledger_groupid = " & tempdr(0) & ")"
        End If

        If cmbname.Text.Trim = "" Then fillname(Me, cmbname, tempcondition)
        tempcondition = ""

        fillitem()
        fillcategory()
        If frmstring <> "" Then
            GroupBox3.Visible = False
            chkcategory.Visible = False
        End If

    End Sub

    Sub fillitem()

        'filling all item
        griditem.RowCount = 0
        cmd = New OleDbCommand("select distinct item_code from itemmaster order by item_code", conn)
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If

        conn.Open()
        dr = cmd.ExecuteReader()
        If dr.HasRows Then

            While (dr.Read())
                griditem.Rows.Add(0, dr(0))
            End While

        End If

    End Sub

    Sub fillcategory()

        'filling all category
        cmd = New OleDbCommand("select category_name from categorymaster order by category_name", conn)
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If

        conn.Open()
        dr = cmd.ExecuteReader()
        If dr.HasRows Then

            While (dr.Read())
                gridcategory.Rows.Add(0, dr(0))
            End While

        End If

    End Sub

    Private Sub Chkitem_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkitem.CheckedChanged
        For i = 0 To griditem.RowCount - 1
            If griditem.CurrentRow.Index >= 0 Then
                With griditem.Rows(i).Cells(0)
                    .Value = chkitem.CheckState
                End With
            End If
        Next
    End Sub

    Private Sub chkcategory_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkcategory.CheckedChanged
        For i = 0 To gridcategory.RowCount - 1
            If gridcategory.CurrentRow.Index >= 0 Then
                With gridcategory.Rows(i).Cells(0)
                    .Value = chkcategory.CheckState
                End With
            End If
        Next
    End Sub

    Private Sub txtitemname_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtitemname.Validated
        Dim rowno, b As Integer
        fillitem()
        rowno = 0
        For b = 1 To griditem.RowCount
            txtTempName.Text = griditem.Item(1, rowno).Value.ToString()
            txtTempName.SelectionStart = 0
            txtTempName.SelectionLength = txtitemname.TextLength
            If LCase(txtitemname.Text.Trim) <> LCase(txtTempName.SelectedText.Trim) Then
                griditem.Rows.RemoveAt(rowno)
            Else
                rowno = rowno + 1
            End If
        Next
    End Sub

    Private Sub cmbname_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbname.KeyDown
        Try
            If e.KeyCode = Keys.F1 And e.Alt = True Then
                Dim OBJSELECT As New SelectLedger
                OBJSELECT.STRSEARCH = " AND (GROUPMASTER.GROUP_NAME = 'Sundry Debtor' or GROUPMASTER.GROUP_NAME = 'Sundry Creditors')"
                OBJSELECT.ShowDialog()
                cmbname.Text = OBJSELECT.TEMPCODE
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class