
Imports System.Data.OleDb

Public Class KarigarAccountMaster

    Dim GRIDDOUBLECLICK As Boolean
    Dim GRIDDOUBLECLICKISSUE As Boolean
    Dim TEMPROW As Integer
    Dim TEMPROWISSUE As Integer
    Public edit As Boolean
    Dim TEMPSETTINGNO As Integer

    Sub GETMAX_SETTING_NO()
        cmd = New OleDbCommand("select IIF(ISNULL(max(SETTING_NO)) = TRUE, 0,max(SETTING_NO)) + 1 from SETTING", conn)
        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Open()
        dr = cmd.ExecuteReader
        If dr.HasRows Then
            dr.Read()
            TEMPSETTINGNO = Val(dr(0).ToString)
        End If
        conn.Close()
        dr.Close()
    End Sub

    Private Sub KarigarAccountMaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Cursor.Current = Cursors.WaitCursor
            fillcmb()
            clear()
            FILLGRID()
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub clear()
        Try

            CMBTYPE.SelectedIndex = 0
            SETTINGDATE.Value = Now.Date
            CMBNAME.Text = ""
            CMBITEMNAME.Text = ""
            TXTGROSSWT.Clear()
            TXTSTONEWT.Clear()
            TXTNETTWT.Clear()
            TXTPURITY.Clear()
            TXTFINEWT.Clear()
            CHKREADY.CheckState = CheckState.Unchecked
            TXTNARR.Clear()

            GRIDISSUE.RowCount = 0
            GRIDREC.ClearSelection()
            GRIDREC.RowCount = 0
            GRIDREC.ClearSelection()

            LBLISSGROSSWT.Text = "0.000"
            LBLISSNETTWT.Text = "0.000"
            LBLISSSTONEWT.Text = "0.000"
            LBLISSFINEWT.Text = "0.000"

            LBLRECGROSSWT.Text = "0.000"
            LBLRECNETTWT.Text = "0.000"
            LBLRECSTONEWT.Text = "0.000"
            LBLRECFINEWT.Text = "0.000"

            EP.Clear()
            GRIDDOUBLECLICK = False
            GRIDDOUBLECLICKISSUE = False
            TEMPROW = 0
            TEMPROWIssue = 0
            TXTNO.Clear()

            GETMAX_SETTING_NO()

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub cmdclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        clear()
        edit = False
        FILLGRID()
        SETTINGDATE.Focus()
    End Sub

    Private Sub Casting_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillcmb()
        Try
            If CMBITEMNAME.Text.Trim = "" Then If CMBITEMNAME.Text.Trim = "" Then FILLITEMCODE(Me, CMBITEMNAME, "")
            If CMBNAME.Text.Trim = "" Then fillname(Me, CMBNAME, " AND LEDGERMASTER.LEDGER_KARIGAR = TRUE")
        Catch ex As Exception
            Throw ex
        End Try
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

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Try
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True
        If CMBTYPE.Text.Trim = "" Then
            EP.SetError(CMBTYPE, "Enter Type")
            bln = False
        End If

        If CMBITEMNAME.Text.Trim = "" Then
            EP.SetError(CMBITEMNAME, "Enter Item Code")
            bln = False
        End If

        If CMBNAME.Text.Trim = "" Then
            EP.SetError(CMBNAME, "Enter Name")
            bln = False
        End If

        If Val(TXTGROSSWT.Text.Trim) = 0 And Val(TXTSTONEWT.Text.Trim) = 0 Then
            EP.SetError(TXTGROSSWT, "Enter Gross")
            bln = False
        End If

        'NOT MANDATE COZ WE CAN ISSUE ONLY STONES WITH 0 PURITY
        'If Val(TXTPURITY.Text.Trim) = 0 Then
        '    EP.SetError(TXTPURITY, "Enter Melting")
        '    bln = False
        'End If

        Return bln
    End Function

    Sub CALC()
        Try
            TXTNETTWT.Text = Format(Val(TXTGROSSWT.Text.Trim), "0.000")
            If Val(TXTPURITY.Text.Trim) > 0 And Val(TXTNETTWT.Text.Trim) > 0 Then TXTFINEWT.Text = Format((Val(TXTNETTWT.Text.Trim) * Val(TXTPURITY.Text.Trim)) / 100, "0.000")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTPURITY_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTPURITY.KeyPress, TXTGROSSWT.KeyPress, TXTSTONEWT.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub

    Private Sub TXTGROSS_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTGROSSWT.Validated, TXTPURITY.Validated, TXTSTONEWT.Validated
        CALC()
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try

            Cursor.Current = Cursors.WaitCursor

            EP.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            For i = 0 To 100
                tempcol(i) = ""
                tempval(i) = ""
            Next
            i = 0
            tempcol(I) = "SETTING_NO"
            I += 1
            tempcol(I) = "SETTING_DATE"
            I += 1
            tempcol(I) = "SETTING_TYPE"
            I += 1
            tempcol(i) = "SETTING_LEDGERID"
            I += 1
            tempcol(i) = "SETTING_ITEMID"
            I += 1
            tempcol(i) = "SETTING_GROSSWT"
            I += 1
            tempcol(i) = "SETTING_STONEWT"
            i += 1
            tempcol(i) = "SETTING_NETTWT"
            i += 1
            tempcol(i) = "SETTING_PURITY"
            I += 1
            tempcol(i) = "SETTING_FINEWT"
            i += 1
            tempcol(i) = "SETTING_READY"
            i += 1
            tempcol(i) = "SETTING_NARR"
            I += 1
            tempcol(i) = "SETTING_USERID"
            i += 1
            tempcol(i) = "SETTING_DEPARTMENTID"
            i += 1



            i = 0
            tempval(i) = TEMPSETTINGNO
            I += 1
            tempval(i) = "'" & Format(SETTINGDATE.Value, "dd/MM/yyyy") & "'"
            I += 1
            tempval(i) = "'" & CMBTYPE.Text.Trim & "'"
            I += 1

            'getting LEDGERID
            tempcmd = New OleDbCommand("select LEDGER_id from LEDGERMASTER where LEDGER_code = '" & CMBNAME.Text.Trim & "'", tempconn)
            If tempconn.State = ConnectionState.Open Then
                tempconn.Close()
            End If
            tempconn.Open()
            tempdr = tempcmd.ExecuteReader
            If tempdr.HasRows Then
                tempdr.Read()
                tempval(i) = Val(tempdr(0))
            Else
                tempval(i) = 0
            End If
            I += 1
            tempconn.Close()
            tempdr.Close()

            'getting itemid
            tempcmd = New OleDbCommand("select item_id from itemmaster where item_code = '" & CMBITEMNAME.Text.Trim & "'", tempconn)
            If tempconn.State = ConnectionState.Open Then tempconn.Close()
            tempconn.Open()
            tempdr = tempcmd.ExecuteReader
            If tempdr.HasRows Then
                tempdr.Read()
                tempval(i) = Val(tempdr(0))
            Else
                tempval(i) = 0
            End If
            I += 1
            tempconn.Close()
            tempdr.Close()

            tempval(i) = Format(Val(TXTGROSSWT.Text.Trim), "0.000")
            i += 1
            tempval(i) = Format(Val(TXTSTONEWT.Text.Trim), "0.000")
            i += 1
            tempval(i) = Format(Val(TXTNETTWT.Text.Trim), "0.000")
            i += 1
            tempval(i) = Format(Val(TXTPURITY.Text.Trim), "0.00")
            I += 1
            tempval(i) = Format(Val(TXTFINEWT.Text.Trim), "0.000")
            i += 1
            tempval(i) = CHKREADY.Checked
            i += 1
            tempval(i) = "'" & TXTNARR.Text.Trim & "'"
            i += 1
            tempval(i) = Val(USERID)
            i += 1
            tempval(i) = Val(USERDEPARTMENTID)
            i += 1

            If edit = False Then insert("SETTING", tempcol, tempval) Else modify("SETTING", tempcol, tempval, " WHERE SETTING_NO = " & Val(TXTNO.Text.Trim))
            MessageBox.Show("Details Added")

            clear()
            edit = False
            FILLGRID()
            SETTINGDATE.Focus()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub total()

        LBLISSGROSSWT.Text = "0.000"
        LBLISSNETTWT.Text = "0.000"
        LBLISSSTONEWT.Text = "0.000"
        LBLISSFINEWT.Text = "0.000"
        LBLRECGROSSWT.Text = "0.000"
        LBLRECNETTWT.Text = "0.000"
        LBLRECSTONEWT.Text = "0.000"
        LBLRECFINEWT.Text = "0.000"


        If GRIDREC.RowCount > 0 Then
            For Each ROW As DataGridViewRow In GRIDREC.Rows
                LBLRECGROSSWT.Text = Format(Val(LBLRECGROSSWT.Text.Trim) + Val(ROW.Cells(GRECGROSSWT.Index).Value), "0.000")
                LBLRECSTONEWT.Text = Format(Val(LBLRECSTONEWT.Text.Trim) + Val(ROW.Cells(GRECSTONEWT.Index).Value), "0.000")
                LBLRECNETTWT.Text = Format(Val(LBLRECNETTWT.Text.Trim) + Val(ROW.Cells(GRECNETTWT.Index).Value), "0.000")
                LBLRECFINEWT.Text = Format(Val(LBLRECFINEWT.Text.Trim) + Val(ROW.Cells(GRECFINEWT.Index).Value), "0.000")
            Next
        End If

        If GRIDISSUE.RowCount > 0 Then
            For Each ROW As DataGridViewRow In GRIDISSUE.Rows
                LBLISSGROSSWT.Text = Format(Val(LBLISSGROSSWT.Text.Trim) + Val(ROW.Cells(GISSGROSSWT.Index).Value), "0.000")
                LBLISSSTONEWT.Text = Format(Val(LBLISSSTONEWT.Text.Trim) + Val(ROW.Cells(GISSSTONEWT.Index).Value), "0.000")
                LBLISSNETTWT.Text = Format(Val(LBLISSNETTWT.Text.Trim) + Val(ROW.Cells(GISSNETTWT.Index).Value), "0.000")
                LBLISSFINEWT.Text = Format(Val(LBLISSFINEWT.Text.Trim) + Val(ROW.Cells(GISSFINEWT.Index).Value), "0.000")
            Next
        End If

    End Sub

    Sub FILLGRID()
        Try
            dt = New DataTable
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Open()
            cmd = New OleDbCommand(" SELECT SETTING.SETTING_NO AS [NO], SETTING.SETTING_DATE as SETTINGDATE, SETTING.SETTING_TYPE AS [TYPE],  ledgermaster.ledger_code  AS NAME, ItemMaster.item_CODE AS ITEMCODE, SETTING.SETTING_GROSSWT AS GROSSWT, SETTING.SETTING_STONEWT AS STONEWT, SETTING.SETTING_NETTWT AS NETTWT, SETTING.SETTING_PURITY AS PURITY, SETTING.SETTING_FINEWT AS FINEWT, SETTING.SETTING_READY AS READY, SETTING.SETTING_NARR AS NARR FROM (SETTING INNER JOIN ItemMaster ON SETTING.SETTING_ITEMID = ItemMaster.item_id) INNER JOIN ledgermaster ON SETTING.SETTING_LEDGERID = ledgermaster.ledger_id ", conn)
            da = New OleDbDataAdapter(cmd)
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For Each dr As DataRow In dt.Rows
                    If dr("TYPE") = "Issue" Then
                        GRIDISSUE.Rows.Add(dr("NO"), Format(Convert.ToDateTime(dr("SETTINGDATE")), "dd/MM/yyyy"), dr("NAME").ToString, dr("ITEMCODE").ToString, Format(Val(dr("GROSSWT")), "0.000"), Format(Val(dr("STONEWT")), "0.000"), Format(Val(dr("NETTWT")), "0.000"), Format(Val(dr("PURITY")), "0.00"), Format(Val(dr("FINEWT")), "0.000"), dr("NARR").ToString)
                    Else
                        GRIDREC.Rows.Add(dr("NO"), Format(Convert.ToDateTime(dr("SETTINGDATE")), "dd/MM/yyyy"), dr("NAME").ToString, dr("ITEMCODE").ToString, Format(Val(dr("GROSSWT")), "0.000"), Format(Val(dr("STONEWT")), "0.000"), Format(Val(dr("NETTWT")), "0.000"), Format(Val(dr("PURITY")), "0.00"), Format(Val(dr("FINEWT")), "0.000"), dr("READY"), dr("NARR").ToString)
                        If Convert.ToBoolean(dr("READY")) = True Then GRIDREC.Rows(GRIDREC.RowCount - 1).DefaultCellStyle.BackColor = Color.Yellow
                    End If
                Next
                If GRIDREC.RowCount > 0 Then GRIDREC.FirstDisplayedScrollingRowIndex = GRIDREC.RowCount - 1
                If GRIDISSUE.RowCount > 0 Then GRIDISSUE.FirstDisplayedScrollingRowIndex = GRIDISSUE.RowCount - 1

                'DESELECT ALL ROWS
                If GRIDISSUE.RowCount > 0 Then GRIDISSUE.Rows(GRIDISSUE.CurrentRow.Index).Selected = False
                If GRIDREC.RowCount > 0 Then GRIDREC.Rows(GRIDREC.CurrentRow.Index).Selected = False
                total()
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SaveToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripButton.Click
        Call cmdok_Click(sender, e)
    End Sub

    Private Sub GRIDISSUE_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDISSUE.CellDoubleClick
        Try
            If e.RowIndex >= 0 And GRIDISSUE.Item(GISSSRNO.Index, e.RowIndex).Value <> Nothing Then

                CMBTYPE.Text = "Issue"
                SETTINGDATE.Value = GRIDISSUE.Item(GISSDATE.Index, e.RowIndex).Value.ToString
                CMBNAME.Text = GRIDISSUE.Item(GISSNAME.Index, e.RowIndex).Value.ToString
                CMBITEMNAME.Text = GRIDISSUE.Item(GISSITEMCODE.Index, e.RowIndex).Value.ToString
                TXTGROSSWT.Text = Val(GRIDISSUE.Item(GISSGROSSWT.Index, e.RowIndex).Value)
                TXTSTONEWT.Text = Val(GRIDISSUE.Item(GISSSTONEWT.Index, e.RowIndex).Value)
                TXTNETTWT.Text = Val(GRIDISSUE.Item(GISSNETTWT.Index, e.RowIndex).Value)
                TXTPURITY.Text = Val(GRIDISSUE.Item(GISSPURITY.Index, e.RowIndex).Value)
                TXTFINEWT.Text = Val(GRIDISSUE.Item(GISSFINEWT.Index, e.RowIndex).Value)
                TXTNARR.Text = GRIDISSUE.Item(GISSNARR.Index, e.RowIndex).Value
                TXTNO.Text = Val(GRIDISSUE.Item(GISSSRNO.Index, e.RowIndex).Value)
                edit = True
                SETTINGDATE.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDREC_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDREC.CellClick
        If GRIDISSUE.RowCount > 0 Then GRIDISSUE.Rows(GRIDISSUE.CurrentRow.Index).Selected = False
    End Sub

    Private Sub GRIDREC_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDREC.CellDoubleClick
        Try
            If e.RowIndex >= 0 And GRIDREC.Item(GRECSRNO.Index, e.RowIndex).Value <> Nothing Then

                CMBTYPE.Text = "Jama"
                SETTINGDATE.Value = GRIDREC.Item(GRECDATE.Index, e.RowIndex).Value.ToString
                CMBNAME.Text = GRIDREC.Item(GRECNAME.Index, e.RowIndex).Value.ToString
                CMBITEMNAME.Text = GRIDREC.Item(GRECITEMCODE.Index, e.RowIndex).Value.ToString
                TXTGROSSWT.Text = Val(GRIDREC.Item(GRECGROSSWT.Index, e.RowIndex).Value)
                TXTSTONEWT.Text = Val(GRIDREC.Item(GRECSTONEWT.Index, e.RowIndex).Value)
                TXTNETTWT.Text = Val(GRIDREC.Item(GRECNETTWT.Index, e.RowIndex).Value)
                TXTPURITY.Text = Val(GRIDREC.Item(GRECPURITY.Index, e.RowIndex).Value)
                TXTFINEWT.Text = Val(GRIDREC.Item(GRECFINEWT.Index, e.RowIndex).Value)
                TXTNARR.Text = GRIDREC.Item(GRECNARR.Index, e.RowIndex).Value
                TXTNO.Text = Val(GRIDREC.Item(GRECSRNO.Index, e.RowIndex).Value)
                edit = True
                SETTINGDATE.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try
            If edit = True Then PRINTREPORT(TEMPSETTINGNO)
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

    Private Sub ToolStripdelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripdelete.Click
        Call cmddelete_Click(sender, e)
    End Sub

    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddelete.Click
        Try
            Dim TEMPBILLNO As Integer = 0

            If GRIDISSUE.SelectedRows.Count > 0 Then TEMPBILLNO = Val(GRIDISSUE.SelectedRows(0).Cells(GISSSRNO.Index).Value)
            If GRIDREC.SelectedRows.Count > 0 Then TEMPBILLNO = Val(GRIDREC.SelectedRows(0).Cells(GRECSRNO.Index).Value)

            If TEMPBILLNO = 0 Then Exit Sub

            If MsgBox("Wish To Delete Entry?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            cmd = New OleDbCommand("delete from SETTING where SETTING_NO = " & TEMPBILLNO, conn)
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Open()
            cmd.ExecuteNonQuery()
            clear()
            edit = False
            FILLGRID()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDISSUE_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDISSUE.CellClick
        If GRIDREC.RowCount > 0 Then GRIDREC.Rows(GRIDREC.CurrentRow.Index).Selected = False
    End Sub

    Private Sub CMBTYPE_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBTYPE.Validated
        Try
            If CMBTYPE.Text = "Jama" Then
                CHKREADY.Enabled = True
            Else
                CHKREADY.Enabled = False
                CHKREADY.CheckState = CheckState.Unchecked
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class