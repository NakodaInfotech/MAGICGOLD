
Imports System.Data.OleDb

Public Class PrePolish

    Dim GRIDDOUBLECLICK As Boolean
    Dim GRIDDOUBLECLICKISSUE As Boolean
    Dim TEMPROW As Integer
    Dim TEMPROWISSUE As Integer
    Public EDIT As Boolean
    Public TEMPPREPOLISHNO As Integer

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Sub GETMAX_PREPOLISH_NO()
        'getting PREPOLISHID from database
        cmd = New OleDbCommand("select IIF(ISNULL(max(PREPOLISH_NO)) = TRUE, 0,max(PREPOLISH_NO)) + 1 from PREPOLISH", conn)
        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Open()
        dr = cmd.ExecuteReader
        If dr.HasRows Then
            dr.Read()
            TXTPREPOLISHNO.Text = Val(dr(0).ToString)
        End If
        conn.Close()
        dr.Close()
    End Sub

    Sub clear()
        Try

            tstxtbillno.Clear()
            CMBTYPE.SelectedIndex = 0

            TXTPREPOLISHNO.Clear()
            PREPOLISHDATE.Value = Now.Date
            CMBITEMNAME.Text = ""
            TXTGROSS.Clear()
            TXTPURITY.Clear()
            TXTNETT.Clear()
            TXTWASTAGE.Clear()
            TXTNARR.Clear()

            GRIDISSUE.RowCount = 0
            GRIDREC.ClearSelection()
            GRIDREC.RowCount = 0
            GRIDREC.ClearSelection()

            LBLISSGROSSWT.Text = "0.000"
            LBLISSNETTWT.Text = "0.000"
            LBLRECGROSSWT.Text = "0.000"
            LBLRECNETTWT.Text = "0.000"
            LBLRECWAST.Text = "0.000"

            TXTREMARKS.Clear()
            TXTLOSS.Clear()
            TXTBALANCE.Clear()


            EP.Clear()
            GRIDDOUBLECLICK = False
            GRIDDOUBLECLICKISSUE = False
            TEMPROW = 0
            TEMPROWISSUE = 0
            GETMAX_PREPOLISH_NO()

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub cmdclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        clear()
        EDIT = False
        PREPOLISHDATE.Focus()
    End Sub

    Private Sub PREPOLISH_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNoCancel)
                If tempmsg = vbYes Then
                    If errorvalid() = True Then cmdok_Click(sender, e)
                ElseIf tempmsg = vbCancel Then
                    Exit Sub
                End If
                Me.Close()
            ElseIf e.KeyCode = Keys.Oemcomma Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.OemQuotes Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            ElseIf e.KeyCode = Keys.F2 Then
                tstxtbillno.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillcmb()
        Try
            If CMBITEMNAME.Text.Trim = "" Then If CMBITEMNAME.Text.Trim = "" Then FILLITEMCODE(Me, CMBITEMNAME, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PREPOLISH_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Cursor.Current = Cursors.WaitCursor
            fillcmb()
            clear()

            If EDIT = True Then
                dt = New DataTable
                If conn.State = ConnectionState.Open Then conn.Close()
                conn.Open()
                cmd = New OleDbCommand(" SELECT PREPOLISH.PREPOLISH_DATE as CASTDATE, PREPOLISH.PREPOLISH_TYPE AS CASTTYPE, PREPOLISH.PREPOLISH_SRNO AS SRNO, ItemMaster.item_CODE AS ITEMCODE, PREPOLISH.PREPOLISH_GROSSWT AS GROSSWT, PREPOLISH.PREPOLISH_PURITY AS PURITY, PREPOLISH.PREPOLISH_NETTWT AS NETTWT, PREPOLISH.PREPOLISH_WASTAGE AS WASTAGE, PREPOLISH.PREPOLISH_NARR AS NARR, PREPOLISH.PREPOLISH_REMARKS AS REMARKS, PREPOLISH.PREPOLISH_LOSS AS LOSS, PREPOLISH.PREPOLISH_BALANCE AS BALANCE FROM PREPOLISH INNER JOIN ItemMaster ON PREPOLISH.PREPOLISH_ITEMID = ItemMaster.item_id  WHERE PREPOLISH.PREPOLISH_NO =  " & TEMPPREPOLISHNO, conn)
                da = New OleDbDataAdapter(cmd)
                da.Fill(dt)
                If dt.Rows.Count > 0 Then
                    For Each dr As DataRow In dt.Rows

                        TXTPREPOLISHNO.Text = TEMPPREPOLISHNO
                        PREPOLISHDATE.Value = Convert.ToDateTime(dr("CASTDATE"))

                        TXTREMARKS.Text = dr("REMARKS")
                        TXTLOSS.Text = Format(Val(dr("LOSS")), "0.000")
                        TXTBALANCE.Text = Format(Val(dr("BALANCE")), "0.000")

                        If dr("CASTTYPE") = "Issue" Then
                            GRIDISSUE.Rows.Add(dr("SRNO"), dr("ITEMCODE").ToString, Format(Val(dr("GROSSWT")), "0.000"), Format(Val(dr("PURITY")), "0.00"), Format(Val(dr("NETTWT")), "0.000"), Format(Val(dr("WASTAGE")), "0.000"), dr("NARR").ToString)
                        Else
                            GRIDREC.Rows.Add(dr("SRNO"), dr("ITEMCODE").ToString, Format(Val(dr("GROSSWT")), "0.000"), Format(Val(dr("PURITY")), "0.00"), Format(Val(dr("NETTWT")), "0.000"), Format(Val(dr("WASTAGE")), "0.000"), dr("NARR").ToString)
                        End If

                    Next
                    If GRIDREC.RowCount > 0 Then GRIDREC.FirstDisplayedScrollingRowIndex = GRIDREC.RowCount - 1
                    If GRIDISSUE.RowCount > 0 Then GRIDISSUE.FirstDisplayedScrollingRowIndex = GRIDISSUE.RowCount - 1
                    total()
                Else
                    'IF ROWCOUNT = 0
                    clear()
                    EDIT = False
                    PREPOLISHDATE.Focus()
                End If

            End If

        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub PREPOLISH_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If ClientName <> "MIMARAGEMS" Then Me.Close()
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

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            Cursor.Current = Cursors.WaitCursor

            EP.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            'DELETE DATA FROM CATING
            If EDIT = True Then
                cmd = New OleDbCommand("delete from PREPOLISH where PREPOLISH_NO = " & TEMPPREPOLISHNO, conn)
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
                conn.Open()
                cmd.ExecuteNonQuery()
            End If

            For i = 0 To 100
                tempcol(i) = ""
                tempval(i) = ""
            Next

            tempcol(0) = "PREPOLISH_NO"
            tempcol(1) = "PREPOLISH_DATE"
            tempcol(2) = "PREPOLISH_TYPE"
            tempcol(3) = "PREPOLISH_SRNO"
            tempcol(4) = "PREPOLISH_ITEMID"
            tempcol(5) = "PREPOLISH_GROSSWT"
            tempcol(6) = "PREPOLISH_PURITY"
            tempcol(7) = "PREPOLISH_NETTWT"
            tempcol(8) = "PREPOLISH_WASTAGE"
            tempcol(9) = "PREPOLISH_NARR"
            tempcol(10) = "PREPOLISH_REMARKS"
            tempcol(11) = "PREPOLISH_LOSS"
            tempcol(12) = "PREPOLISH_BALANCE"
            tempcol(13) = "PREPOLISH_TOTALISSGROSS"
            tempcol(14) = "PREPOLISH_TOTALISSNETT"
            tempcol(15) = "PREPOLISH_TOTALISSWASTAGE"
            tempcol(16) = "PREPOLISH_TOTALRECGROSS"
            tempcol(17) = "PREPOLISH_TOTALRECNETT"
            tempcol(18) = "PREPOLISH_TOTALRECWASTAGE"

            For Each ROW As DataGridViewRow In GRIDISSUE.Rows

                tempval(0) = Val(TXTPREPOLISHNO.Text.Trim)
                tempval(1) = "'" & Format(PREPOLISHDATE.Value, "dd/MM/yyyy") & "'"
                tempval(2) = "'Issue'"
                tempval(3) = Val(ROW.Cells(GISSSRNO.Index).Value)

                'getting itemid
                tempcmd = New OleDbCommand("select item_id from itemmaster where item_code = '" & ROW.Cells(GISSITEMCODE.Index).Value & "'", tempconn)
                If tempconn.State = ConnectionState.Open Then tempconn.Close()
                tempconn.Open()
                tempdr = tempcmd.ExecuteReader
                If tempdr.HasRows Then
                    tempdr.Read()
                    tempval(4) = Val(tempdr(0))
                Else
                    tempval(4) = 0
                End If
                tempconn.Close()
                tempdr.Close()

                tempval(5) = Format(Val(ROW.Cells(GISSGROSSWT.Index).Value), "0.000")
                tempval(6) = Format(Val(ROW.Cells(GISSPURITY.Index).Value), "0.00")
                tempval(7) = Format(Val(ROW.Cells(GISSNETTWT.Index).Value), "0.000")
                tempval(8) = Format(Val(ROW.Cells(GISSWASTAGE.Index).Value), "0.000")
                tempval(9) = "'" & ROW.Cells(GISSNARR.Index).Value & "'"
                tempval(10) = "'" & TXTREMARKS.Text.Trim & "'"
                tempval(11) = Format(Val(TXTLOSS.Text.Trim), "0.000")
                tempval(12) = Format(Val(TXTBALANCE.Text.Trim), "0.000")
                tempval(13) = Format(Val(LBLISSGROSSWT.Text.Trim), "0.000")
                tempval(14) = Format(Val(LBLISSNETTWT.Text.Trim), "0.000")
                tempval(15) = 0 'ISS WASTAGE
                tempval(16) = Format(Val(LBLRECGROSSWT.Text.Trim), "0.000")
                tempval(17) = Format(Val(LBLRECNETTWT.Text.Trim), "0.000")
                tempval(18) = Format(Val(LBLRECWAST.Text.Trim), "0.000")

                insert("PREPOLISH", tempcol, tempval)

            Next


            For Each ROW As DataGridViewRow In GRIDREC.Rows

                tempval(0) = Val(TXTPREPOLISHNO.Text.Trim)
                tempval(1) = "'" & Format(PREPOLISHDATE.Value, "dd/MM/yyyy") & "'"
                tempval(2) = "'Jama'"
                tempval(3) = Val(ROW.Cells(GRECSRNO.Index).Value)

                'getting itemid
                tempcmd = New OleDbCommand("select item_id from itemmaster where item_code = '" & ROW.Cells(GRECITEMCODE.Index).Value & "'", tempconn)
                If tempconn.State = ConnectionState.Open Then
                    tempconn.Close()
                End If
                tempconn.Open()
                tempdr = tempcmd.ExecuteReader
                If tempdr.HasRows Then
                    tempdr.Read()
                    tempval(4) = Val(tempdr(0))
                Else
                    tempval(4) = 0
                End If
                tempconn.Close()
                tempdr.Close()

                tempval(5) = Format(Val(ROW.Cells(GRECGROSSWT.Index).Value), "0.000")
                tempval(6) = Format(Val(ROW.Cells(GRECPURITY.Index).Value), "0.00")
                tempval(7) = Format(Val(ROW.Cells(GRECNETTWT.Index).Value), "0.000")
                tempval(8) = Format(Val(ROW.Cells(GRECWASTAGE.Index).Value), "0.000")
                tempval(9) = "'" & ROW.Cells(GRECNARR.Index).Value & "'"
                tempval(10) = "'" & TXTREMARKS.Text.Trim & "'"
                tempval(11) = Format(Val(TXTLOSS.Text.Trim), "0.000")
                tempval(12) = Format(Val(TXTBALANCE.Text.Trim), "0.000")
                tempval(13) = Format(Val(LBLISSGROSSWT.Text.Trim), "0.000")
                tempval(14) = Format(Val(LBLISSNETTWT.Text.Trim), "0.000")
                tempval(15) = 0
                tempval(16) = Format(Val(LBLRECGROSSWT.Text.Trim), "0.000")
                tempval(17) = Format(Val(LBLRECNETTWT.Text.Trim), "0.000")
                tempval(18) = Format(Val(LBLRECWAST.Text.Trim), "0.000")

                insert("PREPOLISH", tempcol, tempval)

            Next


            MessageBox.Show("Details Added")

            clear()
            EDIT = False
            PREPOLISHDATE.Focus()
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True

        If GRIDREC.RowCount = 0 And GRIDISSUE.RowCount = 0 Then
            EP.SetError(CMBTYPE, "Enter Item Details")
            bln = False
        End If

        Return bln
    End Function

    Sub total()

        TXTBALANCE.Text = "0.000"
        LBLISSGROSSWT.Text = "0.000"
        LBLISSNETTWT.Text = "0.000"
        LBLRECGROSSWT.Text = "0.000"
        LBLRECNETTWT.Text = "0.000"
        LBLRECWAST.Text = "0.000"

        If GRIDREC.RowCount > 0 Then
            For Each ROW As DataGridViewRow In GRIDREC.Rows
                LBLRECGROSSWT.Text = Format(Val(LBLRECGROSSWT.Text.Trim) + Val(ROW.Cells(GRECGROSSWT.Index).Value), "0.000")
                LBLRECNETTWT.Text = Format(Val(LBLRECNETTWT.Text.Trim) + Val(ROW.Cells(GRECNETTWT.Index).Value), "0.000")
                LBLRECWAST.Text = Format(Val(LBLRECWAST.Text.Trim) + Val(ROW.Cells(GRECWASTAGE.Index).Value), "0.000")
            Next
        End If

        If GRIDISSUE.RowCount > 0 Then
            For Each ROW As DataGridViewRow In GRIDISSUE.Rows
                LBLISSGROSSWT.Text = Format(Val(LBLISSGROSSWT.Text.Trim) + Val(ROW.Cells(GISSGROSSWT.Index).Value), "0.000")
                LBLISSNETTWT.Text = Format(Val(LBLISSNETTWT.Text.Trim) + Val(ROW.Cells(GISSNETTWT.Index).Value), "0.000")
            Next
        End If

        TXTBALANCE.Text = Format(Val(LBLISSGROSSWT.Text.Trim) - Val(LBLRECGROSSWT.Text.Trim) - Val(LBLRECWAST.Text.Trim) - Val(TXTLOSS.Text.Trim), "0.000")

    End Sub

    Sub getsrno(ByRef grid As System.Windows.Forms.DataGridView)
        Try
            For Each row As DataGridViewRow In grid.Rows
                row.Cells(0).Value = row.Index + 1
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLGRIDISSUEUE()

        GRIDISSUE.Enabled = True
        If GRIDDOUBLECLICKISSUE = False Then
            GRIDISSUE.Rows.Add(0, CMBITEMNAME.Text.Trim, Format(Val(TXTGROSS.Text.Trim), "0.000"), Format(Val(TXTPURITY.Text.Trim), "0.00"), Format(Val(TXTNETT.Text.Trim), "0.000"), Format(Val(TXTWASTAGE.Text.Trim), "0.000"), TXTNARR.Text.Trim)
            getsrno(GRIDISSUE)
        ElseIf GRIDDOUBLECLICKISSUE = True Then
            GRIDISSUE.Item(GISSITEMCODE.Index, TEMPROWISSUE).Value = CMBITEMNAME.Text.Trim
            GRIDISSUE.Item(GISSGROSSWT.Index, TEMPROWISSUE).Value = Format(Val(TXTGROSS.Text.Trim), "0.000")
            GRIDISSUE.Item(GISSPURITY.Index, TEMPROWISSUE).Value = Format(Val(TXTPURITY.Text.Trim), "0.00")
            GRIDISSUE.Item(GISSNETTWT.Index, TEMPROWISSUE).Value = Format(Val(TXTNETT.Text.Trim), "0.00")
            GRIDISSUE.Item(GISSWASTAGE.Index, TEMPROWISSUE).Value = Format(Val(TXTWASTAGE.Text.Trim), "0.00")
            GRIDISSUE.Item(GISSNARR.Index, TEMPROWISSUE).Value = TXTNARR.Text.Trim

            GRIDDOUBLECLICKISSUE = False
        End If

        GRIDISSUE.FirstDisplayedScrollingRowIndex = GRIDISSUE.RowCount - 1

        CMBITEMNAME.Text = ""
        TXTGROSS.Clear()
        TXTPURITY.Clear()
        TXTNETT.Clear()
        TXTWASTAGE.Clear()
        TXTNARR.Clear()
        total()

        CMBTYPE.Focus()

    End Sub

    Sub FILLGRIDJAMA()

        GRIDREC.Enabled = True
        If GRIDDOUBLECLICK = False Then
            GRIDREC.Rows.Add(0, CMBITEMNAME.Text.Trim, Format(Val(TXTGROSS.Text.Trim), "0.000"), Format(Val(TXTPURITY.Text.Trim), "0.00"), Format(Val(TXTNETT.Text.Trim), "0.000"), Format(Val(TXTWASTAGE.Text.Trim), "0.000"), TXTNARR.Text.Trim)
            getsrno(GRIDREC)
        ElseIf GRIDDOUBLECLICK = True Then
            GRIDREC.Item(GRECITEMCODE.Index, TEMPROW).Value = CMBITEMNAME.Text.Trim
            GRIDREC.Item(GRECGROSSWT.Index, TEMPROW).Value = Format(Val(TXTGROSS.Text.Trim), "0.000")
            GRIDREC.Item(GRECPURITY.Index, TEMPROW).Value = Format(Val(TXTPURITY.Text.Trim), "0.00")
            GRIDREC.Item(GRECNETTWT.Index, TEMPROW).Value = Format(Val(TXTNETT.Text.Trim), "0.00")
            GRIDREC.Item(GRECWASTAGE.Index, TEMPROW).Value = Format(Val(TXTWASTAGE.Text.Trim), "0.00")
            GRIDREC.Item(GRECNARR.Index, TEMPROW).Value = TXTNARR.Text.Trim

            GRIDDOUBLECLICK = False
        End If

        GRIDREC.FirstDisplayedScrollingRowIndex = GRIDREC.RowCount - 1

        CMBITEMNAME.Text = ""
        TXTGROSS.Clear()
        TXTPURITY.Clear()
        TXTNETT.Clear()
        TXTWASTAGE.Clear()
        TXTNARR.Clear()
        total()

        CMBTYPE.Focus()

    End Sub

    Private Sub GRIDREC_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDREC.CellDoubleClick
        Try
            If e.RowIndex >= 0 And GRIDREC.Item(GRECSRNO.Index, e.RowIndex).Value <> Nothing Then

                GRIDDOUBLECLICK = True
                CMBTYPE.Text = "Jama"
                CMBITEMNAME.Text = GRIDREC.Item(GRECITEMCODE.Index, e.RowIndex).Value.ToString
                TXTGROSS.Text = Val(GRIDREC.Item(GRECGROSSWT.Index, e.RowIndex).Value)
                TXTPURITY.Text = Val(GRIDREC.Item(GRECPURITY.Index, e.RowIndex).Value)
                TXTNETT.Text = Val(GRIDREC.Item(GRECNETTWT.Index, e.RowIndex).Value)
                TXTWASTAGE.Text = Val(GRIDREC.Item(GRECWASTAGE.Index, e.RowIndex).Value)
                TXTNARR.Text = GRIDREC.Item(GRECNARR.Index, e.RowIndex).Value

                TEMPROW = e.RowIndex
                CMBITEMNAME.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDREC_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDREC.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDREC.RowCount > 0 Then

                'dont allow user if any of the grid line is in edit mode.....
                If GRIDDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                'end of block

                GRIDREC.Rows.RemoveAt(GRIDREC.CurrentRow.Index)
                getsrno(GRIDREC)
                total()

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub tstxtbillno_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tstxtbillno.Validating
        Try
            If tstxtbillno.Text.Trim.Length = 0 Then Exit Sub
            GRIDREC.RowCount = 0
            GRIDISSUE.RowCount = 0
            TEMPPREPOLISHNO = Val(tstxtbillno.Text)
            If TEMPPREPOLISHNO > 0 Then
                EDIT = True
                PREPOLISH_Load(sender, e)
            Else
                clear()
                EDIT = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub OpenToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripButton.Click
        Try
            Dim OBJCAST As New PrePolishDetails
            OBJCAST.MdiParent = MDIMain
            OBJCAST.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SaveToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripButton.Click
        Call cmdok_Click(sender, e)
    End Sub

    Private Sub toolprevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolprevious.Click
        Try
            GRIDREC.RowCount = 0
            GRIDISSUE.RowCount = 0
LINE1:
            TEMPPREPOLISHNO = Val(TXTPREPOLISHNO.Text) - 1
            If TEMPPREPOLISHNO > 0 Then
                EDIT = True
                PREPOLISH_Load(sender, e)
            Else
                clear()
                EDIT = False
            End If
            If GRIDREC.RowCount = 0 And GRIDISSUE.RowCount = 0 And TEMPPREPOLISHNO > 1 Then
                TXTPREPOLISHNO.Text = TEMPPREPOLISHNO
                GoTo LINE1
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub toolnext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolnext.Click
        Try
            GRIDREC.RowCount = 0
            GRIDISSUE.RowCount = 0
LINE1:
            TEMPPREPOLISHNO = Val(TXTPREPOLISHNO.Text) + 1
            GETMAX_PREPOLISH_NO()
            Dim MAXNO As Integer = TXTPREPOLISHNO.Text.Trim
            clear()
            If Val(TXTPREPOLISHNO.Text) - 1 >= TEMPPREPOLISHNO Then
                edit = True
                PREPOLISH_Load(sender, e)
            Else
                clear()
                edit = False
            End If
            If GRIDREC.RowCount = 0 And GRIDISSUE.RowCount = 0 And TEMPPREPOLISHNO < MAXNO Then
                TXTPREPOLISHNO.Text = TEMPPREPOLISHNO
                GoTo LINE1
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDDELETE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddelete.Click
        Try
            If edit = True Then
                Dim tempmsg As Integer = MsgBox("Delete PREPOLISH Entry Permanently?", MsgBoxStyle.YesNo, "Magic Gold")
                If tempmsg = vbYes Then

                    'deleting data from PREPOLISH
                    cmd = New OleDbCommand("delete from PREPOLISH where PREPOLISH_NO = " & TEMPPREPOLISHNO, conn)
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Open()
                    cmd.ExecuteNonQuery()
                    MsgBox("PREPOLISH Entry Deleted")
                    clear()
                    edit = False
                End If

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try
            If edit = True Then PRINTREPORT(TEMPPREPOLISHNO)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub PRINTREPORT(ByVal BOOKNO As Integer)
        Try
            'Dim TEMPMSG As Integer = MsgBox("Wish to Print Invoice?", MsgBoxStyle.YesNo)
            'If TEMPMSG = vbYes Then
            '    Dim OBJINV As New RailBookingVoucherDesign
            '    OBJINV.MdiParent = MDIMain
            '    OBJINV.BOOKINGNO = BOOKNO
            '    OBJINV.Show()
            'End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDISSUE_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDISSUE.CellDoubleClick
        Try
            If e.RowIndex >= 0 And GRIDISSUE.Item(GISSSRNO.Index, e.RowIndex).Value <> Nothing Then

                GridDoubleClickIssue = True
                CMBTYPE.Text = "Issue"
                CMBITEMNAME.Text = GRIDISSUE.Item(GISSITEMCODE.Index, e.RowIndex).Value.ToString
                TXTGROSS.Text = Val(GRIDISSUE.Item(GISSGROSSWT.Index, e.RowIndex).Value)
                TXTPURITY.Text = Val(GRIDISSUE.Item(GISSPURITY.Index, e.RowIndex).Value)
                TXTNETT.Text = Val(GRIDISSUE.Item(GISSNETTWT.Index, e.RowIndex).Value)
                TXTWASTAGE.Text = Val(GRIDISSUE.Item(GISSWASTAGE.Index, e.RowIndex).Value)
                TXTNARR.Text = GRIDISSUE.Item(GISSNARR.Index, e.RowIndex).Value

                TempRowIssue = e.RowIndex
                CMBITEMNAME.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDISSUE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDISSUE.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDISSUE.RowCount > 0 Then

                'dont allow user if any of the grid line is in edit mode.....
                If GridDoubleClickIssue = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                'end of block

                GRIDISSUE.Rows.RemoveAt(GRIDISSUE.CurrentRow.Index)
                getsrno(GRIDISSUE)
                total()

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTNARR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTNARR.Validated
        Try
            If CMBTYPE.Text.Trim <> "" And CMBITEMNAME.Text.Trim <> "" And Val(TXTGROSS.Text.Trim) > 0 And Val(TXTPURITY.Text.Trim) > 0 And Val(TXTNETT.Text.Trim) > 0 Then
                If CMBTYPE.Text.Trim = "Issue" Then
                    FILLGRIDISSUEUE()
                Else
                    FILLGRIDJAMA()
                End If
            Else
                MsgBox("Enter Proper Details", MsgBoxStyle.Critical)
                Exit Sub
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub CALC()
        Try
            If Val(TXTPURITY.Text.Trim) > 0 And Val(TXTGROSS.Text.Trim) > 0 Then TXTNETT.Text = Format((Val(TXTGROSS.Text.Trim) * Val(TXTPURITY.Text.Trim)) / 100, "0.000")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTPURITY_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTPURITY.KeyPress
        numdotkeypress(e, TXTPURITY, Me)
    End Sub

    Private Sub TXTPURITY_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTPURITY.Validated
        Try
            CALC()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTGROSS_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTGROSS.KeyPress
        numdotkeypress(e, TXTGROSS, Me)
    End Sub

    Private Sub TXTGROSS_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTGROSS.Validated
        CALC()
    End Sub

    Private Sub TXTWASTAGE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTWASTAGE.KeyPress
        numdotkeypress(e, TXTWASTAGE, Me)
    End Sub

    Private Sub TXTLOSS_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTLOSS.KeyPress
        numdotkeypress(e, TXTLOSS, Me)
    End Sub

    Private Sub TXTLOSS_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTLOSS.Validated
        total()
    End Sub

End Class