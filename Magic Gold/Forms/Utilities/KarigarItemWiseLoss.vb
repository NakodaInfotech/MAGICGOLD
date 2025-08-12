
Imports System.Data.OleDb

Public Class KarigarItemWiseLoss

    Dim gridDoubleClick As Boolean
    Dim tempRow As Integer
    Public edit As Boolean              'Used for edit
    Dim EDITITEMCODE As String          'Used for edit

    Private Sub ToolStripdelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripdelete.Click
        Try
            If griddetails.RowCount > 0 Then
                If griddetails.CurrentRow.Index >= 0 Then
                    Dim TEMPMSG As Integer = MsgBox("Wish to Delete Entry?", MsgBoxStyle.YesNo)
                    If TEMPMSG = vbNo Then Exit Sub
                    cmd = New OleDbCommand("delete KARIGARLOSSDETAILS.* FROM (KARIGARLOSSDETAILS INNER JOIN ItemMaster ON KARIGARLOSSDETAILS.ITEMID = ItemMaster.item_id) INNER JOIN ledgermaster ON KARIGARLOSSDETAILS.LEDGERID = ledgermaster.ledger_id where ITEMMASTER.ITEM_CODE = '" & griddetails.Rows(griddetails.CurrentRow.Index).Cells(GITEMCODE.Index).Value & "' and LEDGERMASTER.LEDGER_CODE ='" & CMBNAME.Text.Trim & "'", conn)
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Open()
                    cmd.ExecuteNonQuery()
                    conn.Close()
                    griddetails.RowCount = 0
                    fillgrid_onevents()
                    getsrno(griddetails)
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub KarigarItemWiseLoss_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub

    Private Sub KarigarItemWiseLoss_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If CMBNAME.Text.Trim = "" Then fillname(Me, CMBNAME, " AND (GROUPMASTER.GROUP_NAME = 'Sundry Creditors') and LEDGERMASTER.LEDGER_KARIGAR = TRUE")
        If CMBITEMNAME.Text.Trim = "" Then If CMBITEMNAME.Text.Trim = "" Then FILLITEMCODE(Me, CMBITEMNAME, "")
    End Sub


    Private Sub CMBITEMNAME_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBITEMNAME.Enter
        Try
            If CMBITEMNAME.Text.Trim = "" Then If CMBITEMNAME.Text.Trim = "" Then FILLITEMCODE(Me, CMBITEMNAME, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBITEMNAME_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBITEMNAME.KeyDown
        Try
            If e.KeyCode = Keys.F1 And e.Alt = True Then
                Dim OBJITEM As New SelectItem
                OBJITEM.ShowDialog()
                CMBITEMNAME.Text = OBJITEM.TEMPCODE
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBITEMNAME_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBITEMNAME.Validating
        Try
            If CMBITEMNAME.Text.Trim <> "" Then ITEMVALIDATE(CMBITEMNAME, e, Me, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Try
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        Try
            clear()
            edit = False
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub clear()
        Try
            cmbname.Text = ""
            lblname.Text = ""
            txtsrno.Clear()
            CMBITEMNAME.Text = ""
            TXTLOSS.Clear()
            txtlabour.Clear()
            griddetails.RowCount = 0
            griddetails.ClearSelection()
            gridDoubleClick = 0
            tempRow = 0
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub GETDATA()
        Try
            griddetails.RowCount = 0
            dt = New DataTable()
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
            conn.Open()
            cmd = New OleDbCommand("SELECT ITEMMASTER.ITEM_CODE AS ITEMCODE, KARIGARLOSSDETAILS.LOSS AS LOSS, KARIGARLOSSDETAILS.labour AS LABOUR FROM (KARIGARLOSSDETAILS INNER JOIN ItemMaster ON KARIGARLOSSDETAILS.ITEMID = ItemMaster.item_id) INNER JOIN ledgermaster ON KARIGARLOSSDETAILS.LEDGERID = ledgermaster.ledger_id WHERE 1=1 AND LEDGERMASTER.LEDGER_CODE = '" & CMBNAME.Text.Trim & "'", conn)
            da = New OleDbDataAdapter(cmd)
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For Each DTROW As DataRow In dt.Rows
                    griddetails.Rows.Add(0, DTROW("ITEMCODE"), Val(DTROW("LOSS")), Val(DTROW("LABOUR")))
                Next
            End If
            conn.Close()
            da.Dispose()
            getsrno(griddetails)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBNAME.Enter
        Try
            If CMBNAME.Text.Trim = "" Then fillname(Me, CMBNAME, " AND LEDGERMASTER.LEDGER_KARIGAR = TRUE")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNAME_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBNAME.KeyDown
        Try
            If e.KeyCode = Keys.F1 And e.Alt = True Then
                Dim OBJSELECT As New SelectLedger
                OBJSELECT.STRSEARCH = " AND LEDGERMASTER.LEDGER_KARIGAR = TRUE"
                OBJSELECT.ShowDialog()
                CMBNAME.Text = OBJSELECT.TEMPCODE
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBNAME.Validating
        Try
            If CMBNAME.Text.Trim <> "" Then namevalidate(CMBNAME, e, Me, " AND LEDGERMASTER.LEDGER_KARIGAR = TRUE ")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBNAME.Validated
        Try
            If CMBNAME.Text.Trim <> "" Then GETDATA()
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub txtlabour_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTLABOUR.KeyPress
        Try
            numdotkeypress(e, TXTLABOUR, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtlabour_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTLABOUR.Validated

        If (CMBITEMNAME.Text.Trim.Length > 0) And (Val(TXTLABOUR.Text.Trim) > 0 Or Val(TXTLOSS.Text.Trim) > 0) Then

            'checking for duplication
            If griddetails.RowCount > 0 Then
                If (gridDoubleClick = False) Or (gridDoubleClick = True And Val(griddetails.Rows(tempRow).Cells(GSRNO.Index).Value) <> Val(TXTSRNO.Text.Trim)) Then
                    For Each row As DataGridViewRow In griddetails.Rows
                        If row.Cells(GITEMCODE.Index).Value = CMBITEMNAME.Text.Trim Then
                            MsgBox("Duplicate Entry")
                            CMBITEMNAME.Focus()
                            Exit Sub
                        End If
                    Next
                End If
            End If

            '********************* ADDING VALUES IN KARIGARLOSSDETAILS TABLE **********************'
            'clearing array
            For i = 1 To 100
                tempcol(i) = ""
                tempval(i) = ""
            Next


            'EDIT MODE THEN DELETE CURRECT ENTRY AND RE-ENTER
            If gridDoubleClick = True Then
                cmd = New OleDbCommand("delete KARIGARLOSSDETAILS.* FROM (KARIGARLOSSDETAILS INNER JOIN ItemMaster ON KARIGARLOSSDETAILS.ITEMID = ItemMaster.item_id) INNER JOIN ledgermaster ON KARIGARLOSSDETAILS.LEDGERID = ledgermaster.ledger_id where ITEMMASTER.ITEM_CODE = '" & EDITITEMCODE & "' and LEDGERMASTER.LEDGER_CODE ='" & CMBNAME.Text.Trim & "'", conn)
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If

                conn.Open()
                cmd.ExecuteNonQuery()
                conn.Close()
                gridDoubleClick = False
            End If


            tempcol(0) = "LEDGERID"
            tempcol(1) = "ITEMID"
            tempcol(2) = "LOSS"
            tempcol(3) = "LABOUR"


            'getting nameid
            cmd = New OleDbCommand("select ledger_id from ledgermaster where ledger_code = '" & CMBNAME.Text.Trim & "'", conn)
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
            conn.Open()
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                dr.Read()
                tempval(0) = Val(dr(0))
            Else
                tempval(0) = Val(0)
            End If
            conn.Close()


            'getting ITEMID
            cmd = New OleDbCommand("select ITEM_id from ITEMMASTER where ITEM_code = '" & CMBITEMNAME.Text.Trim & "'", conn)
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
            conn.Open()
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                dr.Read()
                tempval(1) = Val(dr(0))
            Else
                tempval(1) = Val(0)
            End If
            conn.Close()


            tempval(2) = Val(TXTLOSS.Text.Trim)
            tempval(3) = Val(TXTLABOUR.Text.Trim)

            insert("KARIGARLOSSDETAILS", tempcol, tempval)
            '********************* END OF CODE **********************'


            'If txtwtid.Text.Trim = Nothing Then ' this mean that in fresh entry mode 
            If CMBITEMNAME.Text.Trim.Length > 0 And (Val(TXTLOSS.Text.Trim) > 0 Or Val(TXTLABOUR.Text.Trim) > 0) Then
                griddetails.RowCount = 0
                fillgrid_onevents()
                getsrno(griddetails)
                gridDoubleClick = False
                griddetails.ClearSelection()
                CMBITEMNAME.Text = ""
                TXTLOSS.Clear()
                TXTLABOUR.Clear()
                CMBITEMNAME.Focus()
            End If
        End If
    End Sub

    Sub fillgrid_onevents()

        Dim dt1 As New DataTable()
        If tempconn.State = ConnectionState.Open Then
            tempconn.Close()
        End If
        tempconn.Open()
        tempcmd = New OleDbCommand("SELECT ITEMMASTER.ITEM_CODE AS ITEMCODE, KARIGARLOSSDETAILS.LOSS, KARIGARLOSSDETAILS.labour FROM (KARIGARLOSSDETAILS INNER JOIN ItemMaster ON KARIGARLOSSDETAILS.ITEMID = ItemMaster.item_id) INNER JOIN ledgermaster ON KARIGARLOSSDETAILS.LEDGERID = ledgermaster.ledger_id where LEDGERMASTER.LEDGER_CODE = '" & CMBNAME.Text.Trim & "'", tempconn)
        da = New OleDbDataAdapter(tempcmd)
        da.Fill(dt1)
        If dt1.Rows.Count > 0 Then
            For Each DTROW As DataRow In dt1.Rows
                griddetails.Rows.Add(0, DTROW("ITEMCODE"), Val(DTROW("LOSS")), Val(DTROW("LABOUR")))
            Next
        End If

    End Sub

    Private Sub txtsrno_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTSRNO.GotFocus
        If gridDoubleClick = False Then
            If griddetails.RowCount > 0 Then
                txtsrno.Text = Val(griddetails.Rows(griddetails.RowCount - 1).Cells(GSRNO.Index).Value) + 1
            Else
                txtsrno.Text = 1
            End If
        End If
    End Sub

    Sub getsrno(ByRef grid As System.Windows.Forms.DataGridView)
        Try
            For Each row As DataGridViewRow In grid.Rows
                row.Cells(GSRNO.Index).Value = row.Index + 1
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub griddetails_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles griddetails.CellDoubleClick
        Try
            If griddetails.CurrentRow.Cells(GITEMCODE.Index).Value <> "" Then
                gridDoubleClick = True
                TXTSRNO.Text = griddetails.Rows(e.RowIndex).Cells(GSRNO.Index).Value
                CMBITEMNAME.Text = griddetails.Rows(e.RowIndex).Cells(GITEMCODE.Index).Value
                EDITITEMCODE = griddetails.Rows(e.RowIndex).Cells(GITEMCODE.Index).Value
                TXTLOSS.Text = griddetails.Rows(e.RowIndex).Cells(GLOSS.Index).Value
                TXTLABOUR.Text = griddetails.Rows(e.RowIndex).Cells(GLABOUR.Index).Value
                tempRow = e.RowIndex
                CMBITEMNAME.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class