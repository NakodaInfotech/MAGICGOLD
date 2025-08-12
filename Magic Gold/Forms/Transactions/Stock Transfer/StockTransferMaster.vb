
Imports System.ComponentModel
Imports System.Data.OleDb

Public Class StockTransferMaster

    Public EDIT As Boolean
    Public TEMPSTNO As Integer
    Dim GRIDDOUBLECLICK As Boolean = False

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Sub CALC()
        Try
            TXTFINEWT.Text = Format(Val(TXTGROSSWT.Text.Trim) * ((Val(TXTPURITY.Text.Trim) + Val(TXTWASTAGE.Text.Trim)) / 100), "0.000")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub StockTransferMaster_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try
            If (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                If errorvalid() = True Then
                    Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                    If tempmsg = vbYes Then cmdok_Click(sender, e)
                End If
                Me.Close()
            ElseIf e.KeyCode = Keys.Oemcomma Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.Left Then       'for DELETE
                Call toolprevious_Click(sender, e)
            ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.Right Then       'for DELETE
                Call toolnext_Click(sender, e)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub GETMAX_ST_NO()
        cmd = New OleDbCommand("select IIF(ISNULL(max(ST_NO)) = TRUE, 0,max(ST_NO)) + 1 from STOCKTRANSFER", conn)
        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Open()
        dr = cmd.ExecuteReader
        If dr.HasRows Then
            dr.Read()
            TXTSTNO.Text = Val(dr(0).ToString)
        End If
        conn.Close()
        dr.Close()
    End Sub

    Sub clear()

        lbllock.Visible = False
        tstxtbillno.Clear()
        STDATE.Value = globaldate
        CMBFROMDEPARTMENT.Text = ""
        CMBTODEPARTMENT.Text = ""

        TXTSRNO.Text = 1
        CMBITEMCODE.Text = ""
        TXTITEMDESC.Clear()
        TXTPCS.Clear()
        TXTGROSSWT.Clear()
        TXTPURITY.Clear()
        TXTWASTAGE.Clear()
        TXTFINEWT.Clear()
        GRIDST.RowCount = 0

        TXTTOTALPCS.Clear()
        TXTTOTALGROSSWT.Clear()
        TXTTOTALFINEWT.Clear()

        TXTREMARKS.Clear()

        EP.Clear()

        GETMAX_ST_NO()

    End Sub

    Private Sub cmdclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        clear()
        EDIT = False
        CMBFROMDEPARTMENT.Focus()
    End Sub

    Sub fillcmb()
        Try
            If CMBITEMCODE.Text.Trim = "" Then FILLITEMCODE(Me, CMBITEMCODE, "")
            If CMBFROMDEPARTMENT.Text.Trim = "" Then FILLDEPARTMENT(Me, CMBFROMDEPARTMENT, "")
            If CMBTODEPARTMENT.Text.Trim = "" Then FILLDEPARTMENT(Me, CMBTODEPARTMENT, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub StockTransferMaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Cursor.Current = Cursors.WaitCursor
            fillcmb()
            clear()

            If EDIT = True Then
                Dim DT As New DataTable
                If conn.State = ConnectionState.Open Then conn.Close()
                conn.Open()
                cmd = New OleDbCommand(" SELECT STOCKTRANSFER.ST_NO AS STNO, STOCKTRANSFER.ST_DATE AS STDATE, STOCKTRANSFER.ST_SRNO AS SRNO, ItemMaster.item_code AS ITEMCODE, STOCKTRANSFER.ST_ITEMDESC AS ITEMDESC, STOCKTRANSFER.ST_PCS AS PCS, STOCKTRANSFER.ST_GROSSWT AS GROSSWT, STOCKTRANSFER.ST_PURITY AS PURITY, STOCKTRANSFER.ST_WASTAGE AS WASTAGE, STOCKTRANSFER.ST_FINEWT AS FINEWT, STOCKTRANSFER.ST_REMARKS AS REMARKS, IIF(ISNULL(FROMDEPARTMENTMASTER.DEPARTMENT_NAME) = 'TRUE', '', FROMDEPARTMENTMASTER.DEPARTMENT_NAME) AS FROMDEPARTMENT , IIF(ISNULL(TODEPARTMENTMASTER.DEPARTMENT_NAME) = 'TRUE', '', TODEPARTMENTMASTER.DEPARTMENT_NAME) AS TODEPARTMENT, STOCKTRANSFER.ST_ACCEPTED AS  ACCEPTED FROM ((STOCKTRANSFER INNER JOIN ItemMaster ON STOCKTRANSFER.ST_ITEMID = ItemMaster.item_id) LEFT JOIN DEPARTMENTMASTER AS FROMDEPARTMENTMASTER ON STOCKTRANSFER.ST_FROMDEPARTMENTID = FROMDEPARTMENTMASTER.DEPARTMENT_ID) LEFT JOIN DEPARTMENTMASTER AS TODEPARTMENTMASTER ON STOCKTRANSFER.ST_TODEPARTMENTID = TODEPARTMENTMASTER.DEPARTMENT_ID  where STOCKTRANSFER.ST_NO = " & TEMPSTNO, conn)
                da = New OleDbDataAdapter(cmd)
                da.Fill(DT)
                For Each DTROW As DataRow In DT.Rows
                    TXTSTNO.Text = TEMPSTNO
                    STDATE.Value = Convert.ToDateTime(DTROW("STDATE"))
                    If IsDBNull(DTROW("FROMDEPARTMENT")) = False Then CMBFROMDEPARTMENT.Text = DTROW("FROMDEPARTMENT")
                    If IsDBNull(DTROW("TODEPARTMENT")) = False Then CMBTODEPARTMENT.Text = DTROW("TODEPARTMENT")

                    GRIDST.Rows.Add(DTROW("SRNO"), DTROW("ITEMCODE"), DTROW("ITEMDESC"), Val(DTROW("PCS")), Format(Val(DTROW("GROSSWT")), "0.000"), Format(Val(DTROW("PURITY")), "0.00"), Format(Val(DTROW("WASTAGE")), "0.00"), Format(Val(DTROW("FINEWT")), "0.000"), DTROW("ACCEPTED"))
                    TXTREMARKS.Text = DTROW("REMARKS")

                    If Convert.ToBoolean(DTROW("ACCEPTED")) = True Then
                        GRIDST.Rows(GRIDST.RowCount - 1).DefaultCellStyle.BackColor = Color.Yellow
                        lbllock.Visible = True
                    End If

                    conn.Close()
                    cmd.Dispose()
                Next
                TOTAL()
            End If

        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub TOTAL()
        Try
            TXTTOTALPCS.Clear()
            TXTTOTALGROSSWT.Clear()
            TXTTOTALFINEWT.Clear()

            For Each ROW As DataGridViewRow In GRIDST.Rows
                TXTTOTALPCS.Text = Format(Val(TXTTOTALPCS.Text.Trim) + Val(ROW.Cells(GPCS.Index).Value), "0")
                TXTTOTALGROSSWT.Text = Format(Val(TXTTOTALGROSSWT.Text.Trim) + Val(ROW.Cells(GGROSSWT.Index).Value), "0.000")
                TXTTOTALFINEWT.Text = Format(Val(TXTTOTALFINEWT.Text.Trim) + Val(ROW.Cells(GFINEWT.Index).Value), "0.000")
            Next

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

            'IF BACK DATED ENTRY IS TO BE SAVED THEN CHECK ENTRYPASSWORD
            If APPLYBLOCKDATE = True And STDATE.Value.Date <= BLOCKEDDATE Then
                Dim OBJPASS As New PasswordEntry
                OBJPASS.ShowDialog()
                If ENTRYPASSWORD <> OBJPASS.TXTDATERETYPE.Text.Trim Then
                    MsgBox("Invaid Password", MsgBoxStyle.Critical)
                    Exit Sub
                End If
            End If

            For i = 0 To 100
                tempcol(i) = ""
                tempval(i) = ""
            Next

            'DELETE DATA FROM STOCKTRANSFER
            If EDIT = True Then
                cmd = New OleDbCommand("DELETE FROM STOCKTRANSFER WHERE ST_NO = " & TEMPSTNO, conn)
                If conn.State = ConnectionState.Open Then conn.Close()
                conn.Open()
                cmd.ExecuteNonQuery()
            Else
                'IF MULTIPLE USERS ARE WORKING ON THE SAME FORM THEN WE NEED THIS
                GETMAX_ST_NO()
            End If


            For Each ROW As DataGridViewRow In GRIDST.Rows

                tempcol(0) = "ST_NO"
                tempcol(1) = "ST_DATE"
                tempcol(2) = "ST_FROMDEPARTMENTID"
                tempcol(3) = "ST_TODEPARTMENTID"
                tempcol(4) = "ST_TOTALPCS"
                tempcol(5) = "ST_TOTALGROSSWT"
                tempcol(6) = "ST_TOTALFINEWT"
                tempcol(7) = "ST_REMARKS"
                tempcol(8) = "ST_SRNO"
                tempcol(9) = "ST_ITEMID"
                tempcol(10) = "ST_ITEMDESC"
                tempcol(11) = "ST_PCS"
                tempcol(12) = "ST_GROSSWT"
                tempcol(13) = "ST_PURITY"
                tempcol(14) = "ST_WASTAGE"
                tempcol(15) = "ST_FINEWT"
                tempcol(16) = "ST_ACCEPTED"
                tempcol(17) = "ST_USERID"
                tempcol(18) = "ST_DEPARTMENTID"

                tempval(0) = Val(TXTSTNO.Text.Trim)
                tempval(1) = "'" & Format(STDATE.Value, "dd/MM/yyyy") & "'"


                'GET FROMDEPTID
                tempcmd = New OleDbCommand("select DEPARTMENT_ID from DEPARTMENTMASTER where DEPARTMENT_NAME = '" & CMBFROMDEPARTMENT.Text.Trim & "'", conn)
                If conn.State = ConnectionState.Open Then conn.Close()
                conn.Open()
                tempdr = tempcmd.ExecuteReader
                If tempdr.HasRows Then
                    tempdr.Read()
                    tempval(2) = Val(tempdr(0))
                Else
                    tempval(2) = 0
                End If
                conn.Close()
                tempdr.Close()

                'GET TODEPTID
                tempcmd = New OleDbCommand("select DEPARTMENT_ID from DEPARTMENTMASTER where DEPARTMENT_NAME = '" & CMBTODEPARTMENT.Text.Trim & "'", conn)
                If conn.State = ConnectionState.Open Then conn.Close()
                conn.Open()
                tempdr = tempcmd.ExecuteReader
                If tempdr.HasRows Then
                    tempdr.Read()
                    tempval(3) = Val(tempdr(0))
                Else
                    tempval(3) = 0
                End If
                conn.Close()
                tempdr.Close()


                tempval(4) = Val(TXTTOTALPCS.Text.Trim)
                tempval(5) = Val(TXTTOTALGROSSWT.Text.Trim)
                tempval(6) = Val(TXTTOTALFINEWT.Text.Trim)
                tempval(7) = "'" & TXTREMARKS.Text.Trim & "'"
                tempval(8) = Val(ROW.Cells(GSRNO.Index).Value)

                'getting itemid
                tempcmd = New OleDbCommand("select item_id from itemmaster where item_code = '" & ROW.Cells(GITEMCODE.Index).Value & "'", tempconn)
                If tempconn.State = ConnectionState.Open Then tempconn.Close()
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

                tempval(10) = "'" & ROW.Cells(GITEMDESC.Index).Value & "'"
                tempval(11) = Val(ROW.Cells(GPCS.Index).Value)
                tempval(12) = Format(Val(ROW.Cells(GGROSSWT.Index).Value), "0.000")
                tempval(13) = Format(Val(ROW.Cells(GMELTING.Index).Value), "0.00")
                tempval(14) = Format(Val(ROW.Cells(GWASTAGE.Index).Value), "0.00")
                tempval(15) = Format(Val(ROW.Cells(GFINEWT.Index).Value), "0.000")

                If Convert.ToBoolean(ROW.Cells(GACCEPTED.Index).Value) = True Then tempval(16) = 1 Else tempval(16) = 0

                tempval(17) = Val(USERID)
                tempval(18) = Val(USERDEPARTMENTID)

                insert("STOCKTRANSFER", tempcol, tempval)

            Next

            EDIT = False
            clear()
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub TXTFINEWT_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTFINEWT.Validated
        Try
            If CMBITEMCODE.Text.Trim <> "" And Val(TXTGROSSWT.Text.Trim) > 0 Then
                FILLGRID()
            Else
                MsgBox("Enter Proper Details")
                Exit Sub
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub GETSRNO(ByRef grid As System.Windows.Forms.DataGridView)
        Try
            For Each row As DataGridViewRow In grid.Rows
                row.Cells(GSRNO.Index).Value = row.Index + 1
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLGRID()
        Try
            If GRIDDOUBLECLICK = False Then
                GRIDST.Rows.Add(Val(TXTSRNO.Text.Trim), CMBITEMCODE.Text.Trim, TXTITEMDESC.Text.Trim, Format(Val(TXTPCS.Text.Trim), "0"), Format(Val(TXTGROSSWT.Text.Trim), "0.000"), Format(Val(TXTPURITY.Text.Trim), "0.00"), Format(Val(TXTWASTAGE.Text.Trim), "0.00"), Format(Val(TXTFINEWT.Text.Trim), "0.000"), 0)
                GETSRNO(GRIDST)

            ElseIf GRIDDOUBLECLICK = True Then
                GRIDST.Item(GSRNO.Index, temprow).Value = Val(TXTSRNO.Text.Trim)
                GRIDST.Item(GITEMCODE.Index, temprow).Value = CMBITEMCODE.Text.Trim
                GRIDST.Item(GITEMDESC.Index, temprow).Value = TXTITEMDESC.Text.Trim
                GRIDST.Item(GPCS.Index, temprow).Value = Format(Val(TXTPCS.Text.Trim), "0")
                GRIDST.Item(GGROSSWT.Index, temprow).Value = Format(Val(TXTGROSSWT.Text.Trim), "0.000")
                GRIDST.Item(GMELTING.Index, temprow).Value = Format(Val(TXTPURITY.Text.Trim), "0.00")
                GRIDST.Item(GWASTAGE.Index, temprow).Value = Format(Val(TXTWASTAGE.Text.Trim), "0.00")
                GRIDST.Item(GFINEWT.Index, temprow).Value = Format(Val(TXTFINEWT.Text.Trim), "0.000")

                GRIDDOUBLECLICK = False
            End If

            GRIDST.FirstDisplayedScrollingRowIndex = GRIDST.RowCount - 1

            TXTSRNO.Clear()
            CMBITEMCODE.Text = ""
            TXTITEMDESC.Clear()
            TXTPCS.Clear()
            TXTGROSSWT.Clear()
            TXTPURITY.Clear()
            TXTWASTAGE.Clear()
            TXTFINEWT.Clear()
            CMBITEMCODE.Focus()
            TOTAL()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBITEMCODE_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBITEMCODE.Enter
        Try
            If CMBITEMCODE.Text.Trim = "" Then FILLITEMCODE(Me, CMBITEMCODE, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBITEMCODE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBITEMCODE.KeyDown
        Try
            If e.KeyCode = Keys.F1 And e.Alt = True Then
                Dim OBJITEM As New SelectItem
                OBJITEM.ShowDialog()
                CMBITEMCODE.Text = OBJITEM.TEMPCODE
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBITEMCODE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBITEMCODE.Validating
        Try
            If CMBITEMCODE.Text.Trim <> "" Then ITEMVALIDATE(CMBITEMCODE, e, Me, "", TXTITEMDESC)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True

        If CMBFROMDEPARTMENT.Text.Trim = "" Then
            EP.SetError(CMBFROMDEPARTMENT, " Please select your department")
            bln = False
        End If

        If CMBFROMDEPARTMENT.Text.Trim <> USERDEPARTMENT Then
            EP.SetError(CMBFROMDEPARTMENT, " Please select your department")
            bln = False
        End If


        If CMBFROMDEPARTMENT.Text.Trim = CMBTODEPARTMENT.Text.Trim Then
            EP.SetError(CMBFROMDEPARTMENT, " Same Department Not Allowed")
            bln = False
        End If

        If GRIDST.RowCount = 0 Then
            EP.SetError(TXTFINEWT, " Enter Details below")
            bln = False
        End If

        Return bln
    End Function

    Private Sub tooldelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripdelete.Click
        Try
            Call cmddelete_Click(sender, e)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddelete.Click
        Try
            If EDIT = True Then

                If lbllock.Visible = True Then
                    MsgBox("Entry Accepted, Cannot Delete", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                tempmsg = MsgBox("Delete Entry ?", MsgBoxStyle.YesNo)
                If tempmsg = vbYes Then
                    'deleting data from STOCKTRANSFER
                    cmd = New OleDbCommand("delete from STOCKTRANSFER where ST_NO = " & TEMPSTNO, conn)
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Open()
                    cmd.ExecuteNonQuery()

                    MsgBox("Entry Deleted")
                    clear()
                    EDIT = False
                End If
            Else
                MsgBox("Delete is only in Edit Mode")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub OpenToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripButton.Click
        Try
            Dim OBJST As New StockTransferDetails
            OBJST.MdiParent = MDIMain
            OBJST.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SaveToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripButton.Click
        Call cmdok_Click(sender, e)
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try
            If EDIT = True Then PRINTREPORT(TEMPSTNO)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub toolprevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolprevious.Click
        Try
            TEMPSTNO = Val(TXTSTNO.Text) - 1
            If TEMPSTNO > 0 Then
                EDIT = True
                StockTransferMaster_Load(sender, e)
            Else
                clear()
                EDIT = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub toolnext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolnext.Click
        Try
            TEMPSTNO = Val(TXTSTNO.Text) + 1
            GETMAX_ST_NO()
            clear()
            If Val(TXTSTNO.Text) - 1 >= TEMPSTNO Then
                EDIT = True
                StockTransferMaster_Load(sender, e)
            Else
                clear()
                EDIT = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub PRINTREPORT(ByVal PONO As Integer)
        Try
            Dim OBJVOUCHER As New VoucherDesign
            If EDIT = True Then
                OBJVOUCHER.WHERECLAUSE = " {STOCKTRANSFER.ST_NO} = " & Val(TEMPSTNO)
            Else
                OBJVOUCHER.WHERECLAUSE = " {STOCKTRANSFER.ST_NO} = " & Val(TXTSTNO.Text.Trim)
            End If
            OBJVOUCHER.FRMSTRING = "STOCKTRANSFER"
            OBJVOUCHER.MdiParent = MDIMain
            OBJVOUCHER.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTGROSSWT_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTGROSSWT.KeyPress, TXTPURITY.KeyPress, TXTFINEWT.KeyPress, TXTWASTAGE.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub

    Private Sub TXTPCS_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTPCS.KeyPress
        numkeypress(e, sender, Me)
    End Sub

    Private Sub TXTGROSSWT_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTGROSSWT.Validated, TXTPURITY.Validated, TXTWASTAGE.Validated
        CALC()
    End Sub

    Private Sub GRIDST_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDST.CellDoubleClick
        Try
            If e.RowIndex >= 0 And GRIDST.Item(GSRNO.Index, e.RowIndex).Value <> Nothing Then

                If Convert.ToBoolean(GRIDST.CurrentRow.Cells(GACCEPTED.Index).Value) = True Then
                    MessageBox.Show("Entry Accepted, You Cannot Modify This Row")
                    Exit Sub
                End If

                GRIDDOUBLECLICK = True
                TXTSRNO.Text = Val(GRIDST.Item(GSRNO.Index, e.RowIndex).Value)
                CMBITEMCODE.Text = GRIDST.Item(GITEMCODE.Index, e.RowIndex).Value.ToString
                TXTITEMDESC.Text = GRIDST.Item(GITEMDESC.Index, e.RowIndex).Value.ToString
                TXTPCS.Text = Val(GRIDST.Item(GPCS.Index, e.RowIndex).Value)
                TXTGROSSWT.Text = Val(GRIDST.Item(GGROSSWT.Index, e.RowIndex).Value)
                TXTPURITY.Text = Val(GRIDST.Item(GMELTING.Index, e.RowIndex).Value)
                TXTWASTAGE.Text = Val(GRIDST.Item(GWASTAGE.Index, e.RowIndex).Value)
                TXTFINEWT.Text = Val(GRIDST.Item(GFINEWT.Index, e.RowIndex).Value)

                temprow = e.RowIndex
                CMBITEMCODE.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDST_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDST.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDST.RowCount > 0 Then
                If GRIDDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If

                If Convert.ToBoolean(GRIDST.CurrentRow.Cells(GACCEPTED.Index).Value) = True Then
                    MessageBox.Show("Entry Accepted, You Cannot Delete This Row")
                    Exit Sub
                End If

                'end of block
                GRIDST.Rows.RemoveAt(GRIDST.CurrentRow.Index)
                GETSRNO(GRIDST)
                TOTAL()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBFROMDEPARTMENT_Enter(sender As Object, e As EventArgs) Handles CMBFROMDEPARTMENT.Enter
        Try
            If CMBFROMDEPARTMENT.Text.Trim = "" Then FILLDEPARTMENT(Me, CMBFROMDEPARTMENT, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBTODEPARTMENT_Enter(sender As Object, e As EventArgs) Handles CMBTODEPARTMENT.Enter
        Try
            If CMBTODEPARTMENT.Text.Trim = "" Then FILLDEPARTMENT(Me, CMBTODEPARTMENT, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBFROMDEPARTMENT_Validating(sender As Object, e As CancelEventArgs) Handles CMBFROMDEPARTMENT.Validating
        Try
            If CMBFROMDEPARTMENT.Text.Trim <> "" Then DEPARTMENTVALIDATE(CMBFROMDEPARTMENT, e, Me, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBTODEPARTMENT_Validating(sender As Object, e As CancelEventArgs) Handles CMBTODEPARTMENT.Validating
        Try
            If CMBTODEPARTMENT.Text.Trim <> "" Then DEPARTMENTVALIDATE(CMBTODEPARTMENT, e, Me, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBITEMCODE_Validated(sender As Object, e As EventArgs) Handles CMBITEMCODE.Validated
        If CMBITEMCODE.Text.Trim <> "" Then
            Dim OBJSTOCK As New Stockform
            OBJSTOCK.item = CMBITEMCODE.Text.Trim
            OBJSTOCK.ShowDialog()

            If Val(OBJSTOCK.GROSSWT) > 0 Then TXTGROSSWT.Text = Val(OBJSTOCK.GROSSWT)
            If Val(OBJSTOCK.PURITY) > 0 Then TXTPURITY.Text = Val(OBJSTOCK.PURITY)
        End If
    End Sub
End Class