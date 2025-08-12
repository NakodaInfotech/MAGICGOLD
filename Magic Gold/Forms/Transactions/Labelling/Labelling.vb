
Imports System.Data.OleDb
Imports System.IO

Public Class Labelling

    Public EDIT As Boolean
    Public TEMPLABELNO As Integer
    Dim GRIDDOUBLECLICK As Boolean = False

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Sub CALC()
        Try
            If Val(TXTSTONEWT.Text.Trim) > 0 Or Val(TXTPEARLWT.Text.Trim) > 0 Or Val(TXTKUNDANWT.Text.Trim) > 0 Then TXTLESSWT.Text = Format(Val(TXTPEARLWT.Text.Trim) + Val(TXTSTONEWT.Text.Trim) + Val(TXTKUNDANWT.Text.Trim), "0.000")
            TXTNETTWT.Text = Format(Val(TXTGROSSWT.Text.Trim) - Val(TXTLESSWT.Text.Trim), "0.000")
            TXTFINEWT.Text = Format(((Val(TXTGROSSWT.Text.Trim) * Val(TXTPURITY.Text.Trim)) / 100), "0.000")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Labelling_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
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

    Sub GETMAX_LABEL_NO()
        cmd = New OleDbCommand("select IIF(ISNULL(max(LABEL_NO)) = TRUE, 0,max(LABEL_NO)) + 1 from LABELLING", conn)
        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Open()
        dr = cmd.ExecuteReader
        If dr.HasRows Then
            dr.Read()
            TXTLABELNO.Text = Val(dr(0).ToString)
        End If
        conn.Close()
        dr.Close()
    End Sub

    Sub CLEAR()

        tstxtbillno.Clear()
        LABELDATE.Value = GLOBALDATE

        TXTSRNO.Text = 1
        CMBITEMCODE.Text = ""
        TXTITEMDESC.Clear()
        TXTPCS.Text = 1
        TXTGROSSWT.Clear()
        TXTPEARLWT.Clear()
        TXTSTONEWT.Clear()
        TXTKUNDANWT.Clear()
        TXTLESSWT.Clear()
        TXTNETTWT.Clear()
        TXTPURITY.Clear()
        TXTFINEWT.Clear()
        GRIDLABEL.RowCount = 0

        TXTTOTALPCS.Clear()
        TXTTOTALGROSSWT.Clear()
        TXTTOTALPEARLWT.Clear()
        TXTTOTALSTONEWT.Clear()
        TXTTOTALKUNDANWT.Clear()
        TXTTOTALLESSWT.Clear()
        TXTTOTALNETTWT.Clear()
        TXTTOTALFINEWT.Clear()

        TXTREMARKS.Clear()

        EP.Clear()

        GETMAX_LABEL_NO()

    End Sub

    Private Sub cmdclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        CLEAR()
        EDIT = False
        LABELDATE.Focus()
    End Sub

    Sub FILLCMB()
        Try
            If CMBITEMCODE.Text.Trim = "" Then FILLITEMCODE(Me, CMBITEMCODE, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Labelling_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Cursor.Current = Cursors.WaitCursor
            FILLCMB()
            CLEAR()

            If EDIT = True Then
                Dim DT As New DataTable
                If conn.State = ConnectionState.Open Then conn.Close()
                conn.Open()
                cmd = New OleDbCommand(" SELECT LABELLING.LABEL_NO AS LABELNO, LABELLING.LABEL_DATE AS LABELDATE, LABELLING.LABEL_SRNO AS SRNO, ItemMaster.item_code AS ITEMCODE, LABELLING.LABEL_ITEMDESC AS ITEMDESC, LABELLING.LABEL_PCS AS PCS, LABELLING.LABEL_GROSSWT AS GROSSWT, LABELLING.LABEL_PEARLWT AS PEARLWT, LABELLING.LABEL_STONEWT AS STONEWT, LABELLING.LABEL_KUNDANWT AS KUNDANWT, LABELLING.LABEL_LESSWT AS LESSWT, LABELLING.LABEL_NETTWT AS NETTWT, LABELLING.LABEL_PURITY AS PURITY, LABELLING.LABEL_FINEWT AS FINEWT, LABELLING.LABEL_REMARKS AS REMARKS FROM LABELLING INNER JOIN ItemMaster ON LABELLING.LABEL_ITEMID = ItemMaster.item_id where LABELLING.LABEL_NO = " & TEMPLABELNO, conn)
                da = New OleDbDataAdapter(cmd)
                da.Fill(DT)
                For Each DTROW As DataRow In DT.Rows
                    TXTLABELNO.Text = TEMPLABELNO
                    LABELDATE.Value = Convert.ToDateTime(DTROW("LABELDATE"))

                    GRIDLABEL.Rows.Add(DTROW("SRNO"), DTROW("ITEMCODE"), DTROW("ITEMDESC"), Val(DTROW("PCS")), Format(Val(DTROW("GROSSWT")), "0.000"), Format(Val(DTROW("PEARLWT")), "0.000"), Format(Val(DTROW("STONEWT")), "0.000"), Format(Val(DTROW("KUNDANWT")), "0.000"), Format(Val(DTROW("LESSWT")), "0.000"), Format(Val(DTROW("NETTWT")), "0.000"), Format(Val(DTROW("PURITY")), "0.00"), Format(Val(DTROW("FINEWT")), "0.000"))
                    TXTREMARKS.Text = DTROW("REMARKS")

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
            TXTTOTALPEARLWT.Clear()
            TXTTOTALSTONEWT.Clear()
            TXTTOTALKUNDANWT.Clear()
            TXTTOTALLESSWT.Clear()
            TXTTOTALNETTWT.Clear()
            TXTTOTALFINEWT.Clear()

            For Each ROW As DataGridViewRow In GRIDLABEL.Rows
                TXTTOTALPCS.Text = Format(Val(TXTTOTALPCS.Text.Trim) + Val(ROW.Cells(GPCS.Index).EditedFormattedValue), "0")
                TXTTOTALGROSSWT.Text = Format(Val(TXTTOTALGROSSWT.Text.Trim) + Val(ROW.Cells(GGROSSWT.Index).EditedFormattedValue), "0.000")
                TXTTOTALPEARLWT.Text = Format(Val(TXTTOTALPEARLWT.Text.Trim) + Val(ROW.Cells(GPEARLWT.Index).EditedFormattedValue), "0.000")
                TXTTOTALSTONEWT.Text = Format(Val(TXTTOTALSTONEWT.Text.Trim) + Val(ROW.Cells(GSTONEWT.Index).EditedFormattedValue), "0.000")
                TXTTOTALKUNDANWT.Text = Format(Val(TXTTOTALKUNDANWT.Text.Trim) + Val(ROW.Cells(GKUNDANWT.Index).EditedFormattedValue), "0.000")
                TXTTOTALLESSWT.Text = Format(Val(TXTTOTALLESSWT.Text.Trim) + Val(ROW.Cells(GLESSWT.Index).EditedFormattedValue), "0.000")
                TXTTOTALNETTWT.Text = Format(Val(TXTTOTALNETTWT.Text.Trim) + Val(ROW.Cells(GNETTWT.Index).EditedFormattedValue), "0.000")
                TXTTOTALFINEWT.Text = Format(Val(TXTTOTALFINEWT.Text.Trim) + Val(ROW.Cells(GFINEWT.Index).EditedFormattedValue), "0.000")
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
            If APPLYBLOCKDATE = True And LABELDATE.Value.Date <= BLOCKEDDATE Then
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

            'DELETE DATA FROM LABELLING
            If EDIT = True Then
                cmd = New OleDbCommand("DELETE FROM LABELLING WHERE LABEL_NO = " & TEMPLABELNO, conn)
                If conn.State = ConnectionState.Open Then conn.Close()
                conn.Open()
                cmd.ExecuteNonQuery()
            Else
                'IF MULTIPLE USERS ARE WORKING ON THE SAME FORM THEN WE NEED THIS
                GETMAX_LABEL_NO()
            End If


            For Each ROW As DataGridViewRow In GRIDLABEL.Rows

                tempcol(0) = "LABEL_NO"
                tempcol(1) = "LABEL_DATE"
                tempcol(2) = "LABEL_TOTALPCS"
                tempcol(3) = "LABEL_TOTALGROSSWT"
                tempcol(4) = "LABEL_TOTALLESSWT"
                tempcol(5) = "LABEL_TOTALNETTWT"
                tempcol(6) = "LABEL_TOTALFINEWT"
                tempcol(7) = "LABEL_REMARKS"
                tempcol(8) = "LABEL_SRNO"
                tempcol(9) = "LABEL_ITEMID"
                tempcol(10) = "LABEL_ITEMDESC"
                tempcol(11) = "LABEL_PCS"
                tempcol(12) = "LABEL_GROSSWT"
                tempcol(13) = "LABEL_LESSWT"
                tempcol(14) = "LABEL_NETTWT"
                tempcol(15) = "LABEL_PURITY"
                tempcol(16) = "LABEL_FINEWT"
                tempcol(17) = "LABEL_USERID"
                tempcol(18) = "LABEL_DEPARTMENTID"
                tempcol(19) = "LABEL_PEARLWT"
                tempcol(20) = "LABEL_STONEWT"
                tempcol(21) = "LABEL_KUNDANWT"
                tempcol(22) = "LABEL_TOTALPEARLWT"
                tempcol(23) = "LABEL_TOTALSTONEWT"
                tempcol(24) = "LABEL_TOTALKUNDANWT"

                tempval(0) = Val(TXTLABELNO.Text.Trim)
                tempval(1) = "'" & Format(LABELDATE.Value, "dd/MM/yyyy") & "'"
                tempval(2) = Val(TXTTOTALPCS.Text.Trim)
                tempval(3) = Val(TXTTOTALGROSSWT.Text.Trim)
                tempval(4) = Val(TXTTOTALLESSWT.Text.Trim)
                tempval(5) = Val(TXTTOTALNETTWT.Text.Trim)
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
                tempval(13) = Format(Val(ROW.Cells(GLESSWT.Index).Value), "0.000")
                tempval(14) = Format(Val(ROW.Cells(GNETTWT.Index).Value), "0.000")
                tempval(15) = Format(Val(ROW.Cells(GPURITY.Index).Value), "0.00")
                tempval(16) = Format(Val(ROW.Cells(GFINEWT.Index).Value), "0.000")

                tempval(17) = Val(USERID)
                tempval(18) = Val(USERDEPARTMENTID)

                tempval(19) = Format(Val(ROW.Cells(GPEARLWT.Index).Value), "0.000")
                tempval(20) = Format(Val(ROW.Cells(GSTONEWT.Index).Value), "0.000")
                tempval(21) = Format(Val(ROW.Cells(GKUNDANWT.Index).Value), "0.000")
                tempval(22) = Format(Val(TXTTOTALPEARLWT.Text.Trim), "0.000")
                tempval(23) = Format(Val(TXTTOTALSTONEWT.Text.Trim), "0.000")
                tempval(24) = Format(Val(TXTTOTALKUNDANWT.Text.Trim), "0.000")

                insert("LABELLING", tempcol, tempval)

            Next
            PRINTBARCODE(Val(TXTLABELNO.Text.Trim))
            EDIT = False
            CLEAR()
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
                GRIDLABEL.Rows.Add(Val(TXTSRNO.Text.Trim), CMBITEMCODE.Text.Trim, TXTITEMDESC.Text.Trim, Format(Val(TXTPCS.Text.Trim), "0"), Format(Val(TXTGROSSWT.Text.Trim), "0.000"), Format(Val(TXTPEARLWT.Text.Trim), "0.000"), Format(Val(TXTSTONEWT.Text.Trim), "0.000"), Format(Val(TXTKUNDANWT.Text.Trim), "0.000"), Format(Val(TXTLESSWT.Text.Trim), "0.000"), Format(Val(TXTNETTWT.Text.Trim), "0.000"), Format(Val(TXTPURITY.Text.Trim), "0.00"), Format(Val(TXTFINEWT.Text.Trim), "0.000"))
                GETSRNO(GRIDLABEL)

            ElseIf GRIDDOUBLECLICK = True Then
                GRIDLABEL.Item(GSRNO.Index, temprow).Value = Val(TXTSRNO.Text.Trim)
                GRIDLABEL.Item(GITEMCODE.Index, temprow).Value = CMBITEMCODE.Text.Trim
                GRIDLABEL.Item(GITEMDESC.Index, temprow).Value = TXTITEMDESC.Text.Trim
                GRIDLABEL.Item(GPCS.Index, temprow).Value = Format(Val(TXTPCS.Text.Trim), "0")
                GRIDLABEL.Item(GGROSSWT.Index, temprow).Value = Format(Val(TXTGROSSWT.Text.Trim), "0.000")
                GRIDLABEL.Item(GPEARLWT.Index, temprow).Value = Format(Val(TXTPEARLWT.Text.Trim), "0.000")
                GRIDLABEL.Item(GSTONEWT.Index, temprow).Value = Format(Val(TXTSTONEWT.Text.Trim), "0.000")
                GRIDLABEL.Item(GKUNDANWT.Index, temprow).Value = Format(Val(TXTKUNDANWT.Text.Trim), "0.000")
                GRIDLABEL.Item(GLESSWT.Index, temprow).Value = Format(Val(TXTLESSWT.Text.Trim), "0.000")
                GRIDLABEL.Item(GNETTWT.Index, temprow).Value = Format(Val(TXTNETTWT.Text.Trim), "0.000")
                GRIDLABEL.Item(GPURITY.Index, temprow).Value = Format(Val(TXTPURITY.Text.Trim), "0.00")
                GRIDLABEL.Item(GFINEWT.Index, temprow).Value = Format(Val(TXTFINEWT.Text.Trim), "0.000")

                GRIDDOUBLECLICK = False
            End If

            GRIDLABEL.FirstDisplayedScrollingRowIndex = GRIDLABEL.RowCount - 1

            TXTSRNO.Clear()
            CMBITEMCODE.Text = ""
            TXTITEMDESC.Clear()
            TXTPCS.Clear()
            TXTGROSSWT.Clear()
            TXTPEARLWT.Clear()
            TXTSTONEWT.Clear()
            TXTKUNDANWT.Clear()
            TXTLESSWT.Clear()
            TXTNETTWT.Clear()
            TXTPURITY.Clear()
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

        If GRIDLABEL.RowCount = 0 Then
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

                tempmsg = MsgBox("Delete Entry ?", MsgBoxStyle.YesNo)
                If tempmsg = vbYes Then
                    'deleting data from LABELLING
                    cmd = New OleDbCommand("delete from LABELLING where LABEL_NO = " & TEMPLABELNO, conn)
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Open()
                    cmd.ExecuteNonQuery()

                    MsgBox("Entry Deleted")
                    CLEAR()
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
            Dim OBJLABEL As New LabellingDetails
            OBJLABEL.MdiParent = MDIMain
            OBJLABEL.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SaveToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripButton.Click
        Call cmdok_Click(sender, e)
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try
            If EDIT = True Then PRINTBARCODE(TEMPLABELNO)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub toolprevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolprevious.Click
        Try
            TEMPLABELNO = Val(TXTLABELNO.Text) - 1
            If TEMPLABELNO > 0 Then
                EDIT = True
                Labelling_Load(sender, e)
            Else
                CLEAR()
                EDIT = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub toolnext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolnext.Click
        Try
            TEMPLABELNO = Val(TXTLABELNO.Text) + 1
            GETMAX_LABEL_NO()
            CLEAR()
            If Val(TXTLABELNO.Text) - 1 >= TEMPLABELNO Then
                EDIT = True
                Labelling_Load(sender, e)
            Else
                CLEAR()
                EDIT = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub PRINTBARCODE(ByVal LABELNO As Integer)
        Try
            If MsgBox("Print Labels?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

            For Each ROW As DataGridViewRow In GRIDLABEL.Rows

                'TO PRINT BARCODE FROM SELECTED SRNO
                If (Val(TXTFROM.Text.Trim) > 0 And Val(TXTTO.Text.Trim) > 0) Then
                    If Val(ROW.Cells(GSRNO.Index).Value) < Val(TXTFROM.Text.Trim) Or Val(ROW.Cells(GSRNO.Index).Value) > Val(TXTTO.Text.Trim) Then GoTo NEXTLINE
                End If

                Dim dirresults As String = ""
                Dim oWrite As System.IO.StreamWriter
                oWrite = File.CreateText(Application.StartupPath & "\Barcode.txt")
                'oWrite = File.CreateText("D:\Barcode.txt")


                If ClientName = "SHWETA" Then

                    oWrite.WriteLine("CT~~CD,~CC^~CT~")
                    oWrite.WriteLine("^XA")
                    oWrite.WriteLine("~TA000")
                    oWrite.WriteLine("~JSN")
                    oWrite.WriteLine("^LT0")
                    oWrite.WriteLine("^MNW")
                    oWrite.WriteLine("^MTT")
                    oWrite.WriteLine("^PON")
                    oWrite.WriteLine("^PMN")
                    oWrite.WriteLine("^LH0,0")
                    oWrite.WriteLine("^JMA")
                    oWrite.WriteLine("^PR14,14")
                    oWrite.WriteLine("~SD15")
                    oWrite.WriteLine("^JUS")
                    oWrite.WriteLine("^LRN")
                    oWrite.WriteLine("^CI27")
                    oWrite.WriteLine("^PA0,1,1,0")
                    oWrite.WriteLine("^XZ")
                    oWrite.WriteLine("^XA")
                    oWrite.WriteLine("^MMT")
                    oWrite.WriteLine("^PW679")
                    oWrite.WriteLine("^LL320")
                    oWrite.WriteLine("^LS0")

                    oWrite.WriteLine("^FT16,31^A0N,20,20^FH\^CI28^FDGr. Wt^FS^CI27")
                    oWrite.WriteLine("^FT16,63^A0N,20,20^FH\^CI28^FDLess Wt^FS^CI27")
                    oWrite.WriteLine("^FT16,94^A0N,20,20^FH\^CI28^FDNet Wt^FS^CI27")
                    oWrite.WriteLine("^FT89,31^A0N,20,20^FH\^CI28^FD:^FS^CI27")
                    oWrite.WriteLine("^FT89,63^A0N,20,20^FH\^CI28^FD:^FS^CI27")
                    oWrite.WriteLine("^FT89,94^A0N,20,20^FH\^CI28^FD:^FS^CI27")

                    oWrite.WriteLine("^FT107,31^A0N,20,20^FH\^CI28^FD" & Format(Val(ROW.Cells(GGROSSWT.Index).Value), "0.000") & "^FS^CI27")
                    oWrite.WriteLine("^FT107,63^A0N,20,20^FH\^CI28^FD" & Format(Val(ROW.Cells(GLESSWT.Index).Value), "0.000") & "^FS^CI27")
                    oWrite.WriteLine("^FT107,94^A0N,20,20^FH\^CI28^FD" & Format(Val(ROW.Cells(GNETTWT.Index).Value), "0.000") & "^FS^CI27")

                    oWrite.WriteLine("^FT16,138^A0N,20,20^FH\^CI28^FDPurity^FS^CI27")
                    oWrite.WriteLine("^FT89,138^A0N,20,20^FH\^CI28^FD:^FS^CI27")
                    oWrite.WriteLine("^FT107,138^A0N,20,20^FH\^CI28^FD" & Format(Val(ROW.Cells(GPURITY.Index).Value), "0.00") & "^FS^CI27")

                    oWrite.WriteLine("^FT20,297^A0N,20,20^FH\^CI28^FDCode^FS^CI27")
                    oWrite.WriteLine("^FT123,297^A0N,20,20^FH\^CI28^FD:^FS^CI27")
                    oWrite.WriteLine("^FT141,297^A0N,20,20^FH\^CI28^FD" & ROW.Cells(GITEMDESC.Index).Value & "^FS^CI27")

                    oWrite.WriteLine("^FT20,197^A0N,20,20^FH\^CI28^FDPearl Wt^FS^CI27")
                    oWrite.WriteLine("^FT20,230^A0N,20,20^FH\^CI28^FDStone Wt^FS^CI27")
                    oWrite.WriteLine("^FT20,264^A0N,20,20^FH\^CI28^FDKundan Wt^FS^CI27")
                    oWrite.WriteLine("^FT123,197^A0N,20,20^FH\^CI28^FD:^FS^CI27")
                    oWrite.WriteLine("^FT123,230^A0N,20,20^FH\^CI28^FD:^FS^CI27")
                    oWrite.WriteLine("^FT123,264^A0N,20,20^FH\^CI28^FD:^FS^CI27")
                    oWrite.WriteLine("^FT141,197^A0N,20,20^FH\^CI28^FD" & Format(Val(ROW.Cells(GPEARLWT.Index).Value), "0.000") & "^FS^CI27")
                    oWrite.WriteLine("^FT141,230^A0N,20,20^FH\^CI28^FD" & Format(Val(ROW.Cells(GSTONEWT.Index).Value), "0.000") & "^FS^CI27")
                    oWrite.WriteLine("^FT141,264^A0N,20,20^FH\^CI28^FD" & Format(Val(ROW.Cells(GKUNDANWT.Index).Value), "0.000") & "^FS^CI27")
                    oWrite.WriteLine("^PQ1,0,1,Y")
                    oWrite.WriteLine("^XZ")

                    oWrite.Dispose()

                ElseIf ClientName = "KHUSHALI" Then

                    oWrite.WriteLine("SIZE 69.10 mm, 10 mm")
                    oWrite.WriteLine("GAP 3.8 mm, 0 mm")
                    oWrite.WriteLine("DIRECTION 0,0")
                    oWrite.WriteLine("REFERENCE 0,0")
                    oWrite.WriteLine("OFFSET 0 mm")
                    oWrite.WriteLine("SET PEEL OFF")
                    oWrite.WriteLine("SET CUTTER OFF")
                    oWrite.WriteLine("SET PARTIAL_CUTTER OFF")
                    oWrite.WriteLine("SET TEAR ON")
                    oWrite.WriteLine("ON")
                    oWrite.WriteLine("CLS")
                    oWrite.WriteLine("CODEPAGE 1252")
                    oWrite.WriteLine("TEXT 292,37,""ROMAN.TTF"",180,1,6,""Gr. Wt""")
                    oWrite.WriteLine("TEXT 238,37,""ROMAN.TTF"",180,1,6,"":""")
                    oWrite.WriteLine("TEXT 228,37,""ROMAN.TTF"",180,1,6,""" & Format(Val(ROW.Cells(GGROSSWT.Index).Value), "0.000") & """")
                    oWrite.WriteLine("TEXT 290,18,""ROMAN.TTF"",180,1,6,""Nt. Wt""")
                    oWrite.WriteLine("TEXT 238,18,""ROMAN.TTF"",180,1,6,"":""")
                    oWrite.WriteLine("TEXT 228,18,""ROMAN.TTF"",180,1,6,""" & Format(Val(ROW.Cells(GNETTWT.Index).Value), "0.000") & """")
                    oWrite.WriteLine("TEXT 134,77,""ROMAN.TTF"",180,1,6,""Cz. Wt""")
                    oWrite.WriteLine("TEXT 78,77,""ROMAN.TTF"",180,1,6,"":""")
                    oWrite.WriteLine("TEXT 68,77,""ROMAN.TTF"",180,1,6,""" & Format(Val(ROW.Cells(GKUNDANWT.Index).Value), "0.000") & """")
                    oWrite.WriteLine("TEXT 132,57,""ROMAN.TTF"",180,1,6,""Mt. Wt""")
                    oWrite.WriteLine("TEXT 78,57,""ROMAN.TTF"",180,1,6,"":""")
                    oWrite.WriteLine("TEXT 68,57,""ROMAN.TTF"",180,1,6,""" & Format(Val(ROW.Cells(GPEARLWT.Index).Value), "0.000") & """")
                    oWrite.WriteLine("TEXT 291,77,""ROMAN.TTF"",180,1,6,""Sr. No""")
                    oWrite.WriteLine("TEXT 238,77,""ROMAN.TTF"",180,1,6,"":""")
                    oWrite.WriteLine("TEXT 228,77,""ROMAN.TTF"",180,1,6,""" & Format(Val(ROW.Cells(GSRNO.Index).Value), "0") & """")
                    oWrite.WriteLine("TEXT 286,57,""ROMAN.TTF"",180,1,6,""D. No""")
                    oWrite.WriteLine("TEXT 238,57,""ROMAN.TTF"",180,1,6,"":""")
                    oWrite.WriteLine("TEXT 228,57,""ROMAN.TTF"",180,1,6,""" & ROW.Cells(GITEMDESC.Index).Value & """")
                    oWrite.WriteLine("TEXT 129,18,""ROMAN.TTF"",180,1,6,""Purity""")
                    oWrite.WriteLine("TEXT 78,18,""ROMAN.TTF"",180,1,6,"":""")
                    oWrite.WriteLine("TEXT 68,18,""ROMAN.TTF"",180,1,6,""" & Format(Val(ROW.Cells(GPURITY.Index).Value), "0.00") & """")
                    oWrite.WriteLine("TEXT 144,37,""ROMAN.TTF"",180,1,6,""C St. Wt""")
                    oWrite.WriteLine("TEXT 78,37,""ROMAN.TTF"",180,1,6,"":""")
                    oWrite.WriteLine("TEXT 68,37,""ROMAN.TTF"",180,1,6,""" & Format(Val(ROW.Cells(GSTONEWT.Index).Value), "0.000") & """")
                    oWrite.WriteLine("PRINT 1,1")
                    oWrite.Dispose()

                End If

                'Printing Barcode
                Dim psi As New ProcessStartInfo()
                psi.FileName = "cmd.exe"
                psi.RedirectStandardInput = False
                psi.RedirectStandardOutput = True
                psi.Arguments = "/c print " & Application.StartupPath & "\Barcode.txt"    ' specify your command
                'psi.Arguments = "/c print D:\Barcode.txt"    ' specify your command
                'psi.Arguments = "print /d:\\admin-pc\ARGOX D:\Barcode.txt"    ' specify your command
                psi.UseShellExecute = False

                Dim proc As Process
                proc = Process.Start(psi)
                dirresults = proc.StandardOutput.ReadToEnd() ' // read from stdout
                '// do something with result stream
                proc.WaitForExit()
                proc.Dispose()

NEXTLINE:

                'THIS LINE IS WRITTEN TO DISPOSE THE BARCODE NOTEPAD OBJECT, WHEN CURSOR COMES DIRECTLY ON NEXTLINE CODE
                oWrite.Dispose()


            Next

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTGROSSWT_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTGROSSWT.KeyPress, TXTPURITY.KeyPress, TXTFINEWT.KeyPress, TXTLESSWT.KeyPress, TXTNETTWT.KeyPress, TXTPEARLWT.KeyPress, TXTSTONEWT.KeyPress, TXTKUNDANWT.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub

    Private Sub TXTPCS_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTPCS.KeyPress, TXTFROM.KeyPress, TXTTO.KeyPress
        numkeypress(e, sender, Me)
    End Sub

    Private Sub TXTGROSSWT_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTGROSSWT.Validated, TXTPEARLWT.Validated, TXTSTONEWT.Validated, TXTKUNDANWT.Validated, TXTPURITY.Validated, TXTLESSWT.Validated, TXTNETTWT.Validated
        CALC()
    End Sub

    Private Sub GRIDLABEL_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDLABEL.CellDoubleClick
        Try
            If e.RowIndex >= 0 And GRIDLABEL.Item(GSRNO.Index, e.RowIndex).Value <> Nothing Then

                GRIDDOUBLECLICK = True
                TXTSRNO.Text = Val(GRIDLABEL.Item(GSRNO.Index, e.RowIndex).Value)
                CMBITEMCODE.Text = GRIDLABEL.Item(GITEMCODE.Index, e.RowIndex).Value.ToString
                TXTITEMDESC.Text = GRIDLABEL.Item(GITEMDESC.Index, e.RowIndex).Value.ToString
                TXTPCS.Text = Val(GRIDLABEL.Item(GPCS.Index, e.RowIndex).Value)
                TXTGROSSWT.Text = Val(GRIDLABEL.Item(GGROSSWT.Index, e.RowIndex).Value)
                TXTPEARLWT.Text = Val(GRIDLABEL.Item(GPEARLWT.Index, e.RowIndex).Value)
                TXTSTONEWT.Text = Val(GRIDLABEL.Item(GSTONEWT.Index, e.RowIndex).Value)
                TXTKUNDANWT.Text = Val(GRIDLABEL.Item(GKUNDANWT.Index, e.RowIndex).Value)
                TXTLESSWT.Text = Val(GRIDLABEL.Item(GLESSWT.Index, e.RowIndex).Value)
                TXTNETTWT.Text = Val(GRIDLABEL.Item(GNETTWT.Index, e.RowIndex).Value)
                TXTPURITY.Text = Val(GRIDLABEL.Item(GPURITY.Index, e.RowIndex).Value)
                TXTFINEWT.Text = Val(GRIDLABEL.Item(GFINEWT.Index, e.RowIndex).Value)

                temprow = e.RowIndex
                CMBITEMCODE.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDLABEL_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDLABEL.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDLABEL.RowCount > 0 Then
                If GRIDDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If

                'end of block
                GRIDLABEL.Rows.RemoveAt(GRIDLABEL.CurrentRow.Index)
                GETSRNO(GRIDLABEL)
                TOTAL()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


End Class