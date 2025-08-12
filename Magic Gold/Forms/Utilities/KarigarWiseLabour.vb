Imports System.Data.OleDb

Public Class KarigarWiseLabour

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
                    cmd = New OleDbCommand("delete LABOURDETAILS.* from (LABOURDETAILS INNER JOIN ledgermaster ON LABOURDETAILS.ledgerid = ledgermaster.ledger_id) where LABOURDETAILS.GM = '" & griddetails.Rows(griddetails.CurrentRow.Index).Cells(GGM.Index).Value & "' and LEDGERMASTER.LEDGER_CODE ='" & cmbname.Text.Trim & "'", conn)
                    If conn.State = ConnectionState.Open Then
                        conn.Close()
                    End If

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

    Private Sub KarigarWiseLabour_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub

    Private Sub KarigarWiseLabour_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If cmbname.Text.Trim = "" Then fillname(Me, cmbname, " AND (GROUPMASTER.GROUP_NAME = 'Sundry Creditors')")
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
            TXTGM.Text = ""
            txtlabour.Clear()
            griddetails.RowCount = 0
            griddetails.ClearSelection()
            gridDoubleClick = 0
            tempRow = 0
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbname.Enter
        Try
            If cmbname.Text.Trim = "" Then fillname(Me, cmbname, " AND (GROUPMASTER.GROUP_NAME = 'Sundry Creditors')")
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
            cmd = New OleDbCommand("SELECT LabourDetails.cus_default AS CUSDEFAULT, LabourDetails.gm AS GM,LabourDetails.labour AS LABOUR FROM LabourDetails  INNER JOIN ledgermaster ON LabourDetails.ledgerid = ledgermaster.ledger_id WHERE 1=1 AND LEDGERMASTER.LEDGER_CODE = '" & cmbname.Text.Trim & "'", conn)
            da = New OleDbDataAdapter(cmd)
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For Each DTROW As DataRow In dt.Rows
                    griddetails.Rows.Add(Convert.ToBoolean(DTROW("CUSDEFAULT")), 0, DTROW("GM"), Val(DTROW("LABOUR")))
                Next
            End If
            conn.Close()
            da.Dispose()
            getsrno(griddetails)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbname.KeyDown
        Try
            If e.KeyCode = Keys.F2 Then
                Dim OBJLEDGER As New SelectLedger
                OBJLEDGER.ShowDialog()
                cmbname.Text = OBJLEDGER.TEMPCODE
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbname.Validated
        Try
            If cmbname.Text.Trim <> "" Then GETDATA()
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub cmbname_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbname.Validating
        Try
            If cmbname.Text.Trim <> "" Then

                cmbname.Text = uppercase(cmbname.Text)

                cmd = New OleDbCommand("SELECT ledgermaster.ledger_code,ledgermaster.ledger_id,ledgermaster.ledger_name from ledgermaster where ledgermaster.ledger_code = '" & cmbname.Text.Trim & "'", conn)
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
                conn.Open()
                dr = cmd.ExecuteReader
                If dr.HasRows Then
                    dr.Read()
                    lblname.Text = dr("ledger_name")
                Else
                    tempmsg = MsgBox("Ledger Not Present, Add New?", MsgBoxStyle.YesNo)
                    If tempmsg = vbYes Then

                        If (chldvendormaster.IsMdiChild = False) Then
                            If chldvendormaster.IsDisposed = True Then
                                chldvendormaster = New ACCOUNTMASTER
                            End If
                            chldvendormaster.txtcode.Text = cmbname.Text
                            chldvendormaster.cmdedit.Enabled = True
                            edit = False
                            e.Cancel = True
                            chldvendormaster.Show(Me)
                            chldvendormaster.ActiveControl = (chldvendormaster.txtcode)
                            chldvendormaster.txtcode.Focus()
                        Else
                            chldvendormaster.BringToFront()
                        End If

                    Else
                        cmbname.Focus()

                    End If
                End If

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtlabour_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtlabour.KeyPress
        Try
            numdotkeypress(e, txtlabour, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtlabour_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtlabour.Validated

        If (TXTGM.Text.Trim.Length > 0) Or (Val(txtlabour.Text.Trim) > 0) Then

            'checking for duplication
            If griddetails.RowCount > 0 Then
                If (gridDoubleClick = False) Or (gridDoubleClick = True And Val(griddetails.Rows(tempRow).Cells(GSRNO.Index).Value) <> Val(txtsrno.Text.Trim)) Then
                    For Each row As DataGridViewRow In griddetails.Rows
                        If row.Cells(GGM.Index).Value = TXTGM.Text.Trim Then
                            MsgBox("Duplicate Entry")
                            TXTGM.Focus()
                            Exit Sub
                        End If
                    Next
                End If
            End If

            '********************* ADDING VALUES IN LabourDetails TABLE **********************'
            'clearing array
            For i = 1 To 100
                tempcol(i) = ""
                tempval(i) = ""
            Next


            'EDIT MODE THEN DELETE CURRECT ENTRY AND RE-ENTER
            If gridDoubleClick = True Then
                cmd = New OleDbCommand("delete LabourDetails.* from (LabourDetails INNER JOIN ledgermaster ON LabourDetails.ledgerid = ledgermaster.ledger_id) INNER JOIN ItemMaster ON LabourDetails.itemid = ItemMaster.item_id where ITEMMASTER.ITEM_CODE = '" & EDITITEMCODE & "' and LEDGERMASTER.LEDGER_CODE ='" & cmbname.Text.Trim & "'", conn)
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If

                conn.Open()
                cmd.ExecuteNonQuery()
                conn.Close()
                gridDoubleClick = False
            End If


            tempcol(0) = "ledgerid"
            tempcol(1) = "GM"
            tempcol(2) = "labour"
            tempcol(3) = "cus_default"


            'getting nameid
            cmd = New OleDbCommand("select ledger_id from ledgermaster where ledger_code = '" & cmbname.Text.Trim & "'", conn)
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


            tempval(1) = "'" & TXTGM.Text.Trim & "'"
            tempval(2) = Val(txtlabour.Text.Trim)
            tempval(3) = 1

            insert("LabourDetails", tempcol, tempval)
            '********************* END OF CODE **********************'


            'If txtwtid.Text.Trim = Nothing Then ' this mean that in fresh entry mode 
            If TXTGM.Text.Trim.Length > 0 Or (Val(txtlabour.Text.Trim) > 0) Then
                griddetails.RowCount = 0
                fillgrid_onevents()
                getsrno(griddetails)
                gridDoubleClick = False
                griddetails.ClearSelection()
                TXTGM.Clear()
                txtlabour.Clear()
                txtsrno.Focus()
            End If
        End If
    End Sub

    Sub fillgrid_onevents()

        Dim dt1 As New DataTable()
        If tempconn.State = ConnectionState.Open Then
            tempconn.Close()
        End If
        tempconn.Open()
        tempcmd = New OleDbCommand("SELECT LabourDetails.cus_default, LabourDetails.GM AS GM, LabourDetails.labour FROM (LabourDetails INNER JOIN ledgermaster ON LabourDetails.ledgerid = ledgermaster.ledger_id) where LEDGERMASTER.LEDGER_CODE = '" & cmbname.Text.Trim & "'", tempconn)
        da = New OleDbDataAdapter(tempcmd)
        da.Fill(dt1)
        If dt1.Rows.Count > 0 Then
            For Each DTROW As DataRow In dt1.Rows
                griddetails.Rows.Add(Convert.ToBoolean(DTROW("cus_DEFAULT")), 0, DTROW("GM"), DTROW("LABOUR"))
            Next
        End If

    End Sub

    Private Sub txtsrno_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtsrno.GotFocus
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
            If griddetails.CurrentRow.Cells(GGM.Index).Value <> "" Then
                gridDoubleClick = True
                txtsrno.Text = griddetails.Rows(e.RowIndex).Cells(GSRNO.Index).Value
                TXTGM.Text = griddetails.Rows(e.RowIndex).Cells(GGM.Index).Value
                EDITITEMCODE = griddetails.Rows(e.RowIndex).Cells(GGM.Index).Value
                txtlabour.Text = griddetails.Rows(e.RowIndex).Cells(GLABOUR.Index).Value
                tempRow = e.RowIndex
                TXTGM.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class