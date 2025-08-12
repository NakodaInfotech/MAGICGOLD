
Imports System.Data.OleDb

Public Class MaterialReceipt

    Dim gridDoubleClick As Boolean
    Dim temprow As Integer
    Public edit As Boolean
    Public TEMPRECNO As Integer

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Sub GETMAX_REC_NO()
        'getting melting_id from database
        cmd = New OleDbCommand("select IIF(ISNULL(max(REC_NO)) = TRUE, 0,max(REC_NO)) + 1 from ORDERREC", conn)
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If
        conn.Open()
        dr = cmd.ExecuteReader
        If dr.HasRows Then
            dr.Read()
            TXTRECNO.Text = Val(dr(0).ToString)
        End If
        conn.Close()
        dr.Close()
    End Sub

    Sub clear()
        Try

            tstxtbillno.Clear()
            TXTNAME.Clear()
            TXTORDERNO.Clear()
            TXTRECNO.Clear()
            TXTTOTALCTWT.Clear()
            TXTTOTALPCS.Clear()

            TXTSRNO.Clear()
            GRIDDATE.Value = Now.Date
            CMBITEMNAME.Text = ""
            CMBTYPE.Text = ""
            CMBSIZE.Text = ""
            CMBCOLOR.Text = ""
            TXTPCS.Clear()
            TXTCTWT.Clear()
            RECDATE.Value = Now.Date

            GRIDREC.RowCount = 0
            GRIDREC.ClearSelection()

            TXTREMARKS.Clear()

            EP.Clear()
            gridDoubleClick = False
            GETMAX_REC_NO()

            If GRIDREC.RowCount > 0 Then
                TXTSRNO.Text = Val(GRIDREC.Rows(GRIDREC.RowCount - 1).Cells(GSRNO.Index).Value) + 1
            Else
                TXTSRNO.Text = 1
            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub cmdclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        clear()
        edit = False
        RECDATE.Focus()
    End Sub

    Private Sub MaterialReceipt_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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
            If CMBTYPE.Text.Trim = "" Then FILLSHAPE(Me, CMBTYPE, "")
            If CMBSIZE.Text.Trim = "" Then FILLSIZE(Me, CMBSIZE, "")
            If CMBCOLOR.Text.Trim = "" Then FILLCOLOR(Me, CMBCOLOR, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub MaterialReceipt_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Cursor.Current = Cursors.WaitCursor
            fillcmb()
            clear()

            If edit = True Then
                dt = New DataTable
                If conn.State = ConnectionState.Open Then conn.Close()
                conn.Open()
                cmd = New OleDbCommand(" SELECT ledgermaster.ledger_code AS [NAME], OrderRec.REC_ORDERNO AS [ORDERNO], OrderRec.REC_DATE AS [RECDATE],  OrderRec.REC_TOTALPCS AS [TOTALPCS], OrderRec.REC_TOTALCTWT AS TOTALCTWT, OrderRec.REC_SRNO AS [SRNO], OrderRec.REC_GRIDDATE AS [GRIDDATE], ItemMaster.item_code AS ITEMCODE, IIF(ISNULL(ShapeMaster.shape_name) = TRUE, '',ShapeMaster.shape_name)  AS [SHAPE], IIF(ISNULL(SizeMaster.size_name) = TRUE, '', SizeMaster.size_name) AS [ORDERSIZE], IIF(ISNULL(ColorMaster.color_name) = TRUE, '', ColorMaster.color_name) AS [COLOR], OrderRec.REC_PCS AS PCS, OrderRec.REC_CTWT AS CTWT, OrderRec.REC_REMARKS AS REMARKS FROM ((((OrderRec INNER JOIN ItemMaster ON OrderRec.REC_ITEMID = ItemMaster.item_id) LEFT JOIN ShapeMaster ON OrderRec.REC_SHAPEID = ShapeMaster.shape_id) LEFT JOIN SizeMaster ON OrderRec.REC_SIZEID = SizeMaster.size_id) LEFT JOIN ColorMaster ON OrderRec.REC_COLORID = ColorMaster.color_id) INNER JOIN ledgermaster ON OrderRec.REC_LEDGERID = ledgermaster.ledger_id where OrderRec.REC_NO = " & TEMPRECNO, conn)
                da = New OleDbDataAdapter(cmd)
                da.Fill(dt)
                If dt.Rows.Count > 0 Then
                    For Each dr As DataRow In dt.Rows

                        TXTRECNO.Text = TEMPRECNO
                        TXTNAME.Text = dr("NAME")
                        TXTORDERNO.Text = dr("ORDERNO")
                        RECDATE.Value = Convert.ToDateTime(dr("RECDATE"))

                        TXTREMARKS.Text = dr("REMARKS")
                        GRIDREC.Rows.Add(dr("SRNO").ToString, Format(Convert.ToDateTime(dr("GRIDDATE")).Date, "dd/MM/yyyy"), dr("ITEMCODE").ToString, dr("SHAPE").ToString, dr("ORDERSIZE").ToString, dr("COLOR").ToString, Format(Val(dr("PCS")), "0.00"), Format(Val(dr("CTWT")), "0.000"))

                    Next
                    GRIDREC.FirstDisplayedScrollingRowIndex = GRIDREC.RowCount - 1
                    total()
                Else
                    'IF ROWCOUNT = 0
                    clear()
                    edit = False
                    RECDATE.Focus()
                End If

            End If

        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub MaterialReceipt_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
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

    Private Sub CMBCOLOR_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBCOLOR.Enter
        Try
            If CMBCOLOR.Text.Trim = "" Then FILLCOLOR(Me, CMBCOLOR, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCOLOR_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBCOLOR.Validating
        Try
            If CMBCOLOR.Text.Trim <> "" Then COLORVALIDATE(CMBCOLOR, e, Me, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBSIZE_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBSIZE.Enter
        Try
            If CMBSIZE.Text.Trim = "" Then FILLSIZE(Me, CMBSIZE, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBSIZE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBSIZE.Validating
        Try
            If CMBSIZE.Text.Trim <> "" Then SIZEVALIDATE(CMBSIZE, e, Me, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBTYPE_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBTYPE.Enter
        Try
            If CMBTYPE.Text.Trim = "" Then FILLSHAPE(Me, CMBTYPE, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBTYPE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBTYPE.Validating
        Try
            If CMBTYPE.Text.Trim <> "" Then SHAPEVALIDATE(CMBTYPE, e, Me, "")
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

            'DELETE DATA FROM ORDERREC
            If edit = True Then
                cmd = New OleDbCommand("delete from ORDERREC where REC_NO = " & TEMPRECNO, conn)
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

            tempcol(0) = "REC_NO"
            tempcol(1) = "REC_LEDGERID"
            tempcol(2) = "REC_ORDERNO"
            tempcol(3) = "REC_DATE"
            tempcol(4) = "REC_TOTALPCS"
            tempcol(5) = "REC_TOTALCTWT"
            tempcol(6) = "REC_SRNO"
            tempcol(7) = "REC_GRIDDATE"
            tempcol(8) = "REC_ITEMID"
            tempcol(9) = "REC_SHAPEID"
            tempcol(10) = "REC_SIZEID"
            tempcol(11) = "REC_COLORID"
            tempcol(12) = "REC_PCS"
            tempcol(13) = "REC_CTWT"
            tempcol(14) = "REC_REMARKS"
            

            For Each ROW As DataGridViewRow In GRIDREC.Rows

                tempval(0) = Val(TXTRECNO.Text.Trim)

                'getting LEDGERID
                tempcmd = New OleDbCommand("select LEDGER_id from LEDGERmaster where LEDGER_code = '" & TXTNAME.Text.Trim & "'", tempconn)
                If tempconn.State = ConnectionState.Open Then
                    tempconn.Close()
                End If
                tempconn.Open()
                tempdr = tempcmd.ExecuteReader
                If tempdr.HasRows Then
                    tempdr.Read()
                    tempval(1) = Val(tempdr(0))
                End If
                tempconn.Close()
                tempdr.Close()

                tempval(2) = "'" & TXTORDERNO.Text.Trim & "'"
                tempval(3) = "'" & Format(RECDATE.Value, "dd/MM/yyyy") & "'"
                tempval(4) = Val(TXTTOTALPCS.Text.Trim)
                tempval(5) = Val(TXTTOTALCTWT.Text.Trim)

                tempval(6) = Val(ROW.Cells(GSRNO.Index).Value)
                tempval(7) = "'" & Format(Convert.ToDateTime(ROW.Cells(gdate.Index).Value).Date, "dd/MM/yyyy") & "'"


                'getting itemid
                tempcmd = New OleDbCommand("select item_id from itemmaster where item_code = '" & ROW.Cells(GITEMNAME.Index).Value & "'", tempconn)
                If tempconn.State = ConnectionState.Open Then
                    tempconn.Close()
                End If
                tempconn.Open()
                tempdr = tempcmd.ExecuteReader
                If tempdr.HasRows Then
                    tempdr.Read()
                    tempval(8) = Val(tempdr(0))
                Else
                    tempval(8) = 0
                End If
                tempconn.Close()
                tempdr.Close()


                'getting SHAPEID
                tempcmd = New OleDbCommand("select SHAPE_id from SHAPEmaster where SHAPE_NAME = '" & ROW.Cells(GTYPE.Index).Value & "'", tempconn)
                If tempconn.State = ConnectionState.Open Then
                    tempconn.Close()
                End If
                tempconn.Open()
                tempdr = tempcmd.ExecuteReader
                If tempdr.HasRows Then
                    tempdr.Read()
                    tempval(9) = Val(tempdr(0))
                Else
                    tempval(9) = 0
                End If
                tempconn.Close()
                tempdr.Close()


                'getting SIZEid
                tempcmd = New OleDbCommand("select SIZE_id from SIZEmaster where SIZE_NAME = '" & ROW.Cells(GSIZE.Index).Value & "'", tempconn)
                If tempconn.State = ConnectionState.Open Then
                    tempconn.Close()
                End If
                tempconn.Open()
                tempdr = tempcmd.ExecuteReader
                If tempdr.HasRows Then
                    tempdr.Read()
                    tempval(10) = Val(tempdr(0))
                Else
                    tempval(10) = 0
                End If
                tempconn.Close()
                tempdr.Close()


                'getting COLORid
                tempcmd = New OleDbCommand("select COLOR_id from COLORmaster where COLOR_NAME = '" & ROW.Cells(GCOLOR.Index).Value & "'", tempconn)
                If tempconn.State = ConnectionState.Open Then
                    tempconn.Close()
                End If
                tempconn.Open()
                tempdr = tempcmd.ExecuteReader
                If tempdr.HasRows Then
                    tempdr.Read()
                    tempval(11) = Val(tempdr(0))
                Else
                    tempval(11) = 0
                End If
                tempconn.Close()
                tempdr.Close()


                tempval(12) = Val(ROW.Cells(GPCS.Index).Value)
                tempval(13) = Val(ROW.Cells(GCTWT.Index).Value)

                tempval(14) = "'" & TXTREMARKS.Text.Trim & "'"
                
                insert("ORDERREC", tempcol, tempval)

            Next

            'UDPATE ORDERMASTER
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Open()
            cmd = New OleDbCommand(" UPDATE ORDERMASTER SET ORDER_DONE  = 1 where ORDER_NO = '" & TXTORDERNO.Text.Trim & "'", conn)
            cmd.ExecuteNonQuery()
            
            PRINTREPORT(TXTRECNO.Text.Trim)
            MessageBox.Show("Details Added")

            clear()
            edit = False
            RECDATE.Focus()
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True

        If TXTNAME.Text.Trim.Length = 0 Then
            EP.SetError(TXTNAME, " Please Select Order")
            bln = False
        End If

        If TXTORDERNO.Text.Trim.Length = 0 Then
            EP.SetError(TXTORDERNO, " Please Select Order")
            bln = False
        End If

        If Val(TXTTOTALPCS.Text.Trim) = 0 Then
            EP.SetError(TXTORDERNO, " Please Enter Item Details")
            bln = False
        End If

        If Val(TXTTOTALCTWT.Text.Trim) = 0 Then
            EP.SetError(TXTORDERNO, " Please Enter Item Details")
            bln = False
        End If

        If GRIDREC.RowCount = 0 Then
            EP.SetError(TXTORDERNO, "Enter Item Details")
            bln = False
        End If

        Return bln
    End Function

    Sub total()

        TXTTOTALPCS.Text = "0.00"
        TXTTOTALCTWT.Text = "0.000"

        If GRIDREC.RowCount > 0 Then
            For Each ROW As DataGridViewRow In GRIDREC.Rows
                TXTTOTALPCS.Text = Format(Val(TXTTOTALPCS.Text.Trim) + Val(ROW.Cells(GPCS.Index).Value), "0.00")
                TXTTOTALCTWT.Text = Format(Val(TXTTOTALCTWT.Text.Trim) + Val(ROW.Cells(GCTWT.Index).Value), "0.000")
            Next
        End If

    End Sub

    Private Sub txtsrno_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTSRNO.GotFocus
        If gridDoubleClick = False Then
            If GRIDREC.RowCount > 0 Then
                TXTSRNO.Text = Val(GRIDREC.Rows(GRIDREC.RowCount - 1).Cells(GSRNO.Index).Value) + 1
            Else
                TXTSRNO.Text = 1
            End If
        End If
    End Sub

    Private Sub TXTCTWT_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTCTWT.Validating
        If CMBITEMNAME.Text.Trim <> "" And Val(TXTPCS.Text.Trim) > 0 And Val(TXTCTWT.Text.Trim) > 0 Then
            fillgrid()
        Else
            MsgBox("Enter Proper Details", MsgBoxStyle.Critical, "Magic Gold")
            Exit Sub
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

    Sub fillgrid()

        GRIDREC.Enabled = True
        If gridDoubleClick = False Then
            GRIDREC.Rows.Add(Val(TXTSRNO.Text.Trim), Format(GRIDDATE.Value.Date, "dd/MM/yyyy"), CMBITEMNAME.Text.Trim, CMBTYPE.Text.Trim, CMBSIZE.Text.Trim, CMBCOLOR.Text.Trim, Format(Val(TXTPCS.Text.Trim), "0.00"), Format(Val(TXTCTWT.Text.Trim), "0.000"))
            getsrno(GRIDREC)

        ElseIf gridDoubleClick = True Then
            GRIDREC.Item(GSRNO.Index, temprow).Value = Val(TXTSRNO.Text.Trim)
            GRIDREC.Item(gdate.Index, temprow).Value = Format(GRIDDATE.Value.Date, "dd/MM/yyyy")
            GRIDREC.Item(GITEMNAME.Index, temprow).Value = CMBITEMNAME.Text.Trim
            GRIDREC.Item(GTYPE.Index, temprow).Value = CMBTYPE.Text.Trim
            GRIDREC.Item(GSIZE.Index, temprow).Value = CMBSIZE.Text.Trim
            GRIDREC.Item(GCOLOR.Index, temprow).Value = CMBCOLOR.Text.Trim
            GRIDREC.Item(GPCS.Index, temprow).Value = Format(Val(TXTPCS.Text.Trim), "0.000")
            GRIDREC.Item(GCTWT.Index, temprow).Value = Format(Val(TXTCTWT.Text.Trim), "0.000")

            gridDoubleClick = False
        End If

        GRIDREC.FirstDisplayedScrollingRowIndex = GRIDREC.RowCount - 1

        TXTSRNO.Clear()
        GRIDDATE.Value = globaldate
        CMBITEMNAME.Text = ""
        CMBTYPE.Text = ""
        CMBSIZE.Text = ""
        CMBCOLOR.Text = ""
        TXTPCS.Clear()
        TXTCTWT.Clear()
        total()

        TXTSRNO.Focus()

    End Sub

    Private Sub GRIDREC_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDREC.CellDoubleClick
        Try
            If e.RowIndex >= 0 And GRIDREC.Item(GSRNO.Index, e.RowIndex).Value <> Nothing Then

                gridDoubleClick = True
                TXTSRNO.Text = GRIDREC.Item(GSRNO.Index, e.RowIndex).Value.ToString
                GRIDDATE.Value = Convert.ToDateTime(GRIDREC.Item(gdate.Index, e.RowIndex).Value).Date
                CMBITEMNAME.Text = GRIDREC.Item(GITEMNAME.Index, e.RowIndex).Value.ToString
                CMBTYPE.Text = GRIDREC.Item(GTYPE.Index, e.RowIndex).Value.ToString
                CMBSIZE.Text = GRIDREC.Item(GSIZE.Index, e.RowIndex).Value.ToString
                CMBCOLOR.Text = GRIDREC.Item(GCOLOR.Index, e.RowIndex).Value.ToString
                TXTPCS.Text = GRIDREC.Item(GPCS.Index, e.RowIndex).Value.ToString
                TXTCTWT.Text = GRIDREC.Item(GCTWT.Index, e.RowIndex).Value.ToString

                temprow = e.RowIndex
                TXTSRNO.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDREC_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDREC.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDREC.RowCount > 0 Then

                'dont allow user if any of the grid line is in edit mode.....
                'cmbitemname.Text.Trim <> Val(txtqty.Text) <> 0 And Val(txtamount.Text.Trim) <> 0 And cmbqtyunit.Text.Trim <> 
                If gridDoubleClick = True Then
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
            TEMPRECNO = Val(tstxtbillno.Text)
            If TEMPRECNO > 0 Then
                edit = True
                MaterialReceipt_Load(sender, e)
            Else
                clear()
                edit = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub OpenToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripButton.Click
        Try
            Dim OBJREC As New MaterialReceiptDetails
            OBJREC.MdiParent = MDIMain
            OBJREC.Show()
            OBJREC.BringToFront()
            Me.Close()
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
LINE1:
            TEMPRECNO = Val(TXTRECNO.Text) - 1
            If TEMPRECNO > 0 Then
                edit = True
                MaterialReceipt_Load(sender, e)
            Else
                clear()
                edit = False
            End If
            If GRIDREC.RowCount = 0 And TEMPRECNO > 1 Then
                TXTRECNO.Text = TEMPRECNO
                GoTo LINE1
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub toolnext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolnext.Click
        Try
            GRIDREC.RowCount = 0
LINE1:
            TEMPRECNO = Val(TXTRECNO.Text) + 1
            GETMAX_REC_NO()
            Dim MAXNO As Integer = TXTRECNO.Text.Trim
            clear()
            If Val(TXTRECNO.Text) - 1 >= TEMPRECNO Then
                edit = True
                MaterialReceipt_Load(sender, e)
            Else
                clear()
                edit = False
            End If
            If GRIDREC.RowCount = 0 And TEMPRECNO < MAXNO Then
                TXTRECNO.Text = TEMPRECNO
                GoTo LINE1
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDDELETE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddelete.Click
        Try
            If edit = True Then
                Dim tempmsg As Integer = MsgBox("Delete Material Receipt Permanently?", MsgBoxStyle.YesNo, "Magic Gold")
                If tempmsg = vbYes Then

                    'UNDO ORDERMASTER 
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Open()
                    cmd = New OleDbCommand(" UPDATE ORDERMASTER SET ORDER_DONE  = 0 where ORDER_NO = '" & TXTORDERNO.Text.Trim & "'", conn)
                    cmd.ExecuteNonQuery()

                    'deleting data from ORDERMASTER
                    cmd = New OleDbCommand("delete from ORDERREC where REC_NO = " & TEMPRECNO, conn)
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Open()
                    cmd.ExecuteNonQuery()
                    MsgBox("Material Receipt Deleted")
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
            If edit = True Then PRINTREPORT(TEMPRECNO)
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

    Private Sub CMDSELECTORDER_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDSELECTORDER.Click
        Try
            Dim dt As New DataTable
            Dim OBJORDER As New SelectOrder
            If TXTNAME.Text.Trim <> "" Then OBJORDER.PARTYNAME = TXTNAME.Text.Trim
            OBJORDER.FRMSTRING = "RECEIPT"
            OBJORDER.ShowDialog()
            dt = OBJORDER.DTORDER
            If dt.Rows.Count > 0 Then
                TXTNAME.Text = dt.Rows(0).Item("NAME")
                TXTORDERNO.Text = dt.Rows(0).Item("ORDERNO")
                GRIDDATE.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class