
Imports System.Data.OleDb

Public Class MaterialReturn

    Dim gridDoubleClick As Boolean
    Dim temprow As Integer
    Public edit As Boolean
    Public TEMPRECNO As Integer

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Sub GETMAX_RETURN_NO()
        'getting melting_id from database
        cmd = New OleDbCommand("select IIF(ISNULL(max(RETURN_NO)) = TRUE, 0,max(RETURN_NO)) + 1 from ORDERRETURN", conn)
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If
        conn.Open()
        dr = cmd.ExecuteReader
        If dr.HasRows Then
            dr.Read()
            TXTRETURNNO.Text = Val(dr(0).ToString)
        End If
        conn.Close()
        dr.Close()
    End Sub

    Sub clear()
        Try

            tstxtbillno.Clear()
            TXTNAME.Clear()
            TXTORDERNO.Clear()
            TXTRETURNNO.Clear()
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
            RETURNDATE.Value = Now.Date

            GRIDRETURN.RowCount = 0
            GRIDRETURN.ClearSelection()

            TXTREMARKS.Clear()

            EP.Clear()
            gridDoubleClick = False
            GETMAX_RETURN_NO()

            If GRIDRETURN.RowCount > 0 Then
                TXTSRNO.Text = Val(GRIDRETURN.Rows(GRIDRETURN.RowCount - 1).Cells(GSRNO.Index).Value) + 1
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
        RETURNDATE.Focus()
    End Sub

    Private Sub MaterialReturn_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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

    Private Sub MaterialReturn_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Cursor.Current = Cursors.WaitCursor
            fillcmb()
            clear()

            If edit = True Then
                dt = New DataTable
                If conn.State = ConnectionState.Open Then conn.Close()
                conn.Open()
                cmd = New OleDbCommand(" SELECT ledgermaster.ledger_code AS [NAME], ORDERRETURN.RETURN_ORDERNO AS [ORDERNO], ORDERRETURN.RETURN_DATE AS [RECDATE],  ORDERRETURN.RETURN_TOTALPCS AS [TOTALPCS], ORDERRETURN.RETURN_TOTALCTWT AS TOTALCTWT, ORDERRETURN.RETURN_SRNO AS [SRNO], ORDERRETURN.RETURN_GRIDDATE AS [GRIDDATE], ItemMaster.item_code AS ITEMCODE, IIF(ISNULL(ShapeMaster.shape_name) = TRUE, '',ShapeMaster.shape_name)  AS [SHAPE], IIF(ISNULL(SizeMaster.size_name) = TRUE, '', SizeMaster.size_name) AS [ORDERSIZE], IIF(ISNULL(ColorMaster.color_name) = TRUE, '', ColorMaster.color_name) AS [COLOR], ORDERRETURN.RETURN_PCS AS PCS, ORDERRETURN.RETURN_CTWT AS CTWT, ORDERRETURN.RETURN_REMARKS AS REMARKS FROM ((((ORDERRETURN INNER JOIN ItemMaster ON ORDERRETURN.RETURN_ITEMID = ItemMaster.item_id) LEFT JOIN ShapeMaster ON ORDERRETURN.RETURN_SHAPEID = ShapeMaster.shape_id) LEFT JOIN SizeMaster ON ORDERRETURN.RETURN_SIZEID = SizeMaster.size_id) LEFT JOIN ColorMaster ON ORDERRETURN.RETURN_COLORID = ColorMaster.color_id) INNER JOIN ledgermaster ON ORDERRETURN.RETURN_LEDGERID = ledgermaster.ledger_id where ORDERRETURN.RETURN_NO = " & TEMPRECNO, conn)
                da = New OleDbDataAdapter(cmd)
                da.Fill(dt)
                If dt.Rows.Count > 0 Then
                    For Each dr As DataRow In dt.Rows

                        TXTRETURNNO.Text = TEMPRECNO
                        TXTNAME.Text = dr("NAME")
                        TXTORDERNO.Text = dr("ORDERNO")
                        RETURNDATE.Value = Convert.ToDateTime(dr("RECDATE"))

                        TXTREMARKS.Text = dr("REMARKS")
                        GRIDRETURN.Rows.Add(dr("SRNO").ToString, Format(Convert.ToDateTime(dr("GRIDDATE")).Date, "dd/MM/yyyy"), dr("ITEMCODE").ToString, dr("SHAPE").ToString, dr("ORDERSIZE").ToString, dr("COLOR").ToString, Format(Val(dr("PCS")), "0.00"), Format(Val(dr("CTWT")), "0.000"))

                    Next
                    GRIDRETURN.FirstDisplayedScrollingRowIndex = GRIDRETURN.RowCount - 1
                    total()
                Else
                    'IF ROWCOUNT = 0
                    clear()
                    edit = False
                    RETURNDATE.Focus()
                End If

            End If

        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub MaterialReturn_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If ClientName <> "MIMARAGEMS" Then Me.Close()
    End Sub

    Private Sub CMBITEMNAME_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBITEMNAME.Enter
        Try
            If CMBITEMNAME.Text.Trim = "" Then FILLITEMCODE(Me, CMBITEMNAME, "")
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

            'DELETE DATA FROM ORDERRETURN
            If edit = True Then
                cmd = New OleDbCommand("delete from ORDERRETURN where RETURN_NO = " & TEMPRECNO, conn)
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

            tempcol(0) = "RETURN_NO"
            tempcol(1) = "RETURN_LEDGERID"
            tempcol(2) = "RETURN_ORDERNO"
            tempcol(3) = "RETURN_DATE"
            tempcol(4) = "RETURN_TOTALPCS"
            tempcol(5) = "RETURN_TOTALCTWT"
            tempcol(6) = "RETURN_SRNO"
            tempcol(7) = "RETURN_GRIDDATE"
            tempcol(8) = "RETURN_ITEMID"
            tempcol(9) = "RETURN_SHAPEID"
            tempcol(10) = "RETURN_SIZEID"
            tempcol(11) = "RETURN_COLORID"
            tempcol(12) = "RETURN_PCS"
            tempcol(13) = "RETURN_CTWT"
            tempcol(14) = "RETURN_REMARKS"


            For Each ROW As DataGridViewRow In GRIDRETURN.Rows

                tempval(0) = Val(TXTRETURNNO.Text.Trim)

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
                tempval(3) = "'" & Format(RETURNDATE.Value, "dd/MM/yyyy") & "'"
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

                insert("ORDERRETURN", tempcol, tempval)

            Next

            'UDPATE ORDERMASTER
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Open()
            cmd = New OleDbCommand(" UPDATE ORDERMASTER SET ORDER_DONE  = 1 where ORDER_NO = '" & TXTORDERNO.Text.Trim & "'", conn)
            cmd.ExecuteNonQuery()

            PRINTREPORT(TXTRETURNNO.Text.Trim)
            MessageBox.Show("Details Added")

            clear()
            edit = False
            RETURNDATE.Focus()
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

        If GRIDRETURN.RowCount = 0 Then
            EP.SetError(TXTORDERNO, "Enter Item Details")
            bln = False
        End If

        Return bln
    End Function

    Sub total()

        TXTTOTALPCS.Text = "0.00"
        TXTTOTALCTWT.Text = "0.000"

        If GRIDRETURN.RowCount > 0 Then
            For Each ROW As DataGridViewRow In GRIDRETURN.Rows
                TXTTOTALPCS.Text = Format(Val(TXTTOTALPCS.Text.Trim) + Val(ROW.Cells(GPCS.Index).Value), "0.00")
                TXTTOTALCTWT.Text = Format(Val(TXTTOTALCTWT.Text.Trim) + Val(ROW.Cells(GCTWT.Index).Value), "0.000")
            Next
        End If

    End Sub

    Private Sub txtsrno_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTSRNO.GotFocus
        If gridDoubleClick = False Then
            If GRIDRETURN.RowCount > 0 Then
                TXTSRNO.Text = Val(GRIDRETURN.Rows(GRIDRETURN.RowCount - 1).Cells(GSRNO.Index).Value) + 1
            Else
                TXTSRNO.Text = 1
            End If
        End If
    End Sub

    Function CHECKITEM() As Boolean
        Try
            Dim BLN As Boolean = True
            Dim dt As New DataTable
            Dim WHERECLAUSE As String = " AND REC_ORDERNO = '" & TXTORDERNO.Text.Trim & "'"
            If CMBITEMNAME.Text.Trim <> "" Then WHERECLAUSE = " AND ITEM_CODE = '" & CMBITEMNAME.Text.Trim & "'"
            If CMBTYPE.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " AND SHAPE_NAME = '" & CMBTYPE.Text.Trim & "'"
            If CMBSIZE.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " AND SIZE_NAME = '" & CMBSIZE.Text.Trim & "'"
            If CMBCOLOR.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " AND COLOR_NAME = '" & CMBCOLOR.Text.Trim & "'"
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Open()
            cmd = New OleDbCommand(" SELECT OrderRec.REC_PCS AS PCS, OrderRec.REC_CTWT AS CTWT FROM (((OrderRec INNER JOIN ItemMaster ON OrderRec.REC_ITEMID = ItemMaster.item_id) LEFT JOIN ShapeMaster ON OrderRec.REC_SHAPEID = ShapeMaster.shape_id) LEFT JOIN SizeMaster ON OrderRec.REC_SIZEID = SizeMaster.size_id) LEFT JOIN ColorMaster ON OrderRec.REC_COLORID = ColorMaster.color_id WHERE 1 = 1 " & WHERECLAUSE, conn)
            da = New OleDbDataAdapter(cmd)
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                If Val(TXTPCS.Text.Trim) > Val(dt.Rows(0).Item("PCS")) Then
                    EP.SetError(TXTORDERNO, "Pcs Grester then Recd")
                    BLN = False
                End If
                If Val(TXTCTWT.Text.Trim) > Val(dt.Rows(0).Item("CTWT")) Then
                    EP.SetError(TXTORDERNO, "Wt Grester then Recd")
                    BLN = False
                End If
            Else
                EP.SetError(TXTORDERNO, "Item Not Present in Stock for this Order No")
                BLN = False
            End If
            dt.Dispose()
            cmd.Dispose()

            Return BLN
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub TXTCTWT_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTCTWT.Validating
        If TXTORDERNO.Text.Trim = "" Then
            MsgBox("Select Order First", MsgBoxStyle.Critical)
            CMDSELECTORDER.Focus()
            Exit Sub
        End If
        If CMBITEMNAME.Text.Trim <> "" And Val(TXTPCS.Text.Trim) > 0 And Val(TXTCTWT.Text.Trim) > 0 Then

            'checking WHETHER THIS ITEM IS PRESENT IN RECEIPT OR NOT
            EP.Clear()
            If Not CHECKITEM Then
                Exit Sub
            End If

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

        GRIDRETURN.Enabled = True
        If gridDoubleClick = False Then
            GRIDRETURN.Rows.Add(Val(TXTSRNO.Text.Trim), Format(GRIDDATE.Value.Date, "dd/MM/yyyy"), CMBITEMNAME.Text.Trim, CMBTYPE.Text.Trim, CMBSIZE.Text.Trim, CMBCOLOR.Text.Trim, Format(Val(TXTPCS.Text.Trim), "0.00"), Format(Val(TXTCTWT.Text.Trim), "0.000"))
            getsrno(GRIDRETURN)

        ElseIf gridDoubleClick = True Then
            GRIDRETURN.Item(GSRNO.Index, temprow).Value = Val(TXTSRNO.Text.Trim)
            GRIDRETURN.Item(gdate.Index, temprow).Value = Format(GRIDDATE.Value.Date, "dd/MM/yyyy")
            GRIDRETURN.Item(GITEMNAME.Index, temprow).Value = CMBITEMNAME.Text.Trim
            GRIDRETURN.Item(GTYPE.Index, temprow).Value = CMBTYPE.Text.Trim
            GRIDRETURN.Item(GSIZE.Index, temprow).Value = CMBSIZE.Text.Trim
            GRIDRETURN.Item(GCOLOR.Index, temprow).Value = CMBCOLOR.Text.Trim
            GRIDRETURN.Item(GPCS.Index, temprow).Value = Format(Val(TXTPCS.Text.Trim), "0.000")
            GRIDRETURN.Item(GCTWT.Index, temprow).Value = Format(Val(TXTCTWT.Text.Trim), "0.000")

            gridDoubleClick = False
        End If

        GRIDRETURN.FirstDisplayedScrollingRowIndex = GRIDRETURN.RowCount - 1

        TXTSRNO.Clear()
        GRIDDATE.Value = Now.Date
        CMBITEMNAME.Text = ""
        CMBTYPE.Text = ""
        CMBSIZE.Text = ""
        CMBCOLOR.Text = ""
        TXTPCS.Clear()
        TXTCTWT.Clear()
        total()

        TXTSRNO.Focus()

    End Sub

    Private Sub GRIDRETURN_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDRETURN.CellDoubleClick
        Try
            If e.RowIndex >= 0 And GRIDRETURN.Item(GSRNO.Index, e.RowIndex).Value <> Nothing Then

                gridDoubleClick = True
                TXTSRNO.Text = GRIDRETURN.Item(GSRNO.Index, e.RowIndex).Value.ToString
                GRIDDATE.Value = Convert.ToDateTime(GRIDRETURN.Item(gdate.Index, e.RowIndex).Value).Date
                CMBITEMNAME.Text = GRIDRETURN.Item(GITEMNAME.Index, e.RowIndex).Value.ToString
                CMBTYPE.Text = GRIDRETURN.Item(GTYPE.Index, e.RowIndex).Value.ToString
                CMBSIZE.Text = GRIDRETURN.Item(GSIZE.Index, e.RowIndex).Value.ToString
                CMBCOLOR.Text = GRIDRETURN.Item(GCOLOR.Index, e.RowIndex).Value.ToString
                TXTPCS.Text = GRIDRETURN.Item(GPCS.Index, e.RowIndex).Value.ToString
                TXTCTWT.Text = GRIDRETURN.Item(GCTWT.Index, e.RowIndex).Value.ToString

                temprow = e.RowIndex
                TXTSRNO.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDRETURN_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDRETURN.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDRETURN.RowCount > 0 Then

                'dont allow user if any of the grid line is in edit mode.....
                'cmbitemname.Text.Trim <> Val(txtqty.Text) <> 0 And Val(txtamount.Text.Trim) <> 0 And cmbqtyunit.Text.Trim <> 
                If gridDoubleClick = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                'end of block

                GRIDRETURN.Rows.RemoveAt(GRIDRETURN.CurrentRow.Index)
                getsrno(GRIDRETURN)
                total()

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub tstxtbillno_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tstxtbillno.Validating
        Try
            If tstxtbillno.Text.Trim.Length = 0 Then Exit Sub
            GRIDRETURN.RowCount = 0
            TEMPRECNO = Val(tstxtbillno.Text)
            If TEMPRECNO > 0 Then
                edit = True
                MaterialReturn_Load(sender, e)
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
            Dim OBJRET As New MaterialReturnDetails
            OBJRET.MdiParent = MDIMain
            OBJRET.Show()
            OBJRET.BringToFront()
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
            GRIDRETURN.RowCount = 0
LINE1:
            TEMPRECNO = Val(TXTRETURNNO.Text) - 1
            If TEMPRECNO > 0 Then
                edit = True
                MaterialReturn_Load(sender, e)
            Else
                clear()
                edit = False
            End If
            If GRIDRETURN.RowCount = 0 And TEMPRECNO > 1 Then
                TXTRETURNNO.Text = TEMPRECNO
                GoTo LINE1
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub toolnext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolnext.Click
        Try
            GRIDRETURN.RowCount = 0
LINE1:
            TEMPRECNO = Val(TXTRETURNNO.Text) + 1
            GETMAX_RETURN_NO()
            Dim MAXNO As Integer = TXTRETURNNO.Text.Trim
            clear()
            If Val(TXTRETURNNO.Text) - 1 >= TEMPRECNO Then
                edit = True
                MaterialReturn_Load(sender, e)
            Else
                clear()
                edit = False
            End If
            If GRIDRETURN.RowCount = 0 And TEMPRECNO < MAXNO Then
                TXTRETURNNO.Text = TEMPRECNO
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
                    cmd = New OleDbCommand("delete from ORDERRETURN where RETURN_NO = " & TEMPRECNO, conn)
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
            OBJORDER.FRMSTRING = "RETURN"
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