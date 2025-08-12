
Imports System.Data.OleDb
Imports System.IO

Public Class OrderMaster

    Public edit As Boolean
    Public TEMPORDERNO As Integer
    Dim OLDORDERNO As String = ""
    Dim OLDIMGPATH As String = ""

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub OrderMaster_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub OrderMaster_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If ClientName <> "MIMARAGEMS" And ClientName <> "JAINAM" And ClientName <> "SHASHAWAT" And ClientName <> "SANGAM" And ClientName <> "CNJ" Then Me.Close()
    End Sub

    Sub GETMAX_ORDER_NO()
        'getting melting_id from database
        cmd = New OleDbCommand("select IIF(ISNULL(max(ORDER_SRNO)) = TRUE, 0,max(ORDER_SRNO)) + 1 from ORDERMASTER", conn)
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If
        conn.Open()
        dr = cmd.ExecuteReader
        If dr.HasRows Then
            dr.Read()
            TXTSRNO.Text = Val(dr(0).ToString)
            TXTORDERNO.Text = Val(dr(0).ToString)
        End If
        conn.Close()
        dr.Close()
    End Sub

    Sub clear()

        tstxtbillno.Clear()
        cmbname.Text = ""
        TXTORDERNO.Clear()
        OLDORDERNO = ""
        ORDERDATE.Value = Format(Now, "dd/MM/yyyy  hh:mm:ss tt")
        TXTDELDAYS.Clear()
        DELDATE.Value = Now.Date
        CMBITEMNAME.Text = ""
        TXTGOLDWT.Clear()
        TXTMELTING.Clear()
        TXTCTWT.Clear()
        TXTSIZE.Clear()
        TXTQUOTATION.Clear()
        CMBPRIORITY.SelectedIndex = 0
        TXTREMARKS.Clear()

        TXTFILENAME.Clear()
        txtimgpath.Clear()
        TXTNEWIMGPATH.Clear()
        PBSoftCopy.ImageLocation = ""

        LBLLOCKED.Visible = False
        LBLCLOSED.Visible = False

        EP.Clear()

        GETMAX_ORDER_NO()

    End Sub

    Private Sub cmdclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        clear()
        edit = False
        TXTORDERNO.Focus()
    End Sub

    Sub fillcmb()
        Try
            If cmbname.Text.Trim = "" Then fillname(Me, cmbname, " AND (GROUPMASTER.GROUP_NAME = 'Sundry Creditors' OR GROUPMASTER.GROUP_NAME = 'Sundry Debtors')")
            If CMBITEMNAME.Text.Trim = "" Then If CMBITEMNAME.Text.Trim = "" Then FILLITEMCODE(Me, CMBITEMNAME, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub OrderMaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Cursor.Current = Cursors.WaitCursor
            fillcmb()
            clear()

            If edit = True Then

                If conn.State = ConnectionState.Open Then conn.Close()
                conn.Open()
                cmd = New OleDbCommand(" SELECT OrderMaster.ORDER_NO AS ORDERNO, OrderMaster.ORDER_DATE AS ORDERDATE , ledgermaster.ledger_code AS LEDGERCODE, OrderMaster.ORDER_DELDAYS AS [DELDAYS], OrderMaster.ORDER_DELDATE AS [DELDATE], ItemMaster.item_code AS ITEMCODE, OrderMaster.ORDER_GOLDWT AS GOLDWT, ORDERMASTER.ORDER_MELTING AS MELTING, OrderMaster.ORDER_CTWT AS CTWT, OrderMaster.ORDER_SIZE AS [ORDERSIZE], OrderMaster.ORDER_QUOTEDTLS AS QUOTDTLS, OrderMaster.ORDER_REMARKS AS [ORDERREMARKS], OrderMaster.ORDER_FILENAME AS [ORDERFILENAME], OrderMaster.ORDER_IMGPATH AS IMGPATH, OrderMaster.ORDER_NEWIMGPATH AS NEWIMGPATH, OrderMaster.ORDER_CLOSE AS [ORDERCLOSED], OrderMaster.ORDER_DONE AS [ORDERDONE], ORDERMASTER.ORDER_PRIORITY AS [PRIORITY], ORDERMASTER.ORDER_MFGWT AS MFGWT FROM (OrderMaster INNER JOIN ledgermaster ON OrderMaster.ORDER_LEDGERID = ledgermaster.ledger_id) INNER JOIN ItemMaster ON OrderMaster.ORDER_ITEMID = ItemMaster.item_id where ORDERMASTER.ORDER_SRNO = " & TEMPORDERNO, conn)
                dr = cmd.ExecuteReader
                If dr.HasRows Then
                    dr.Read()

                    TXTSRNO.Text = TEMPORDERNO
                    TXTORDERNO.Text = dr("ORDERNO")
                    OLDORDERNO = dr("ORDERNO")
                    ORDERDATE.Value = Convert.ToDateTime(dr("ORDERDATE"))
                    cmbname.Text = dr("LEDGERCODE")
                    TXTDELDAYS.Text = Val(dr("DELDAYS"))
                    DELDATE.Value = Convert.ToDateTime(dr("DELDATE"))
                    CMBITEMNAME.Text = Convert.ToString(dr("ITEMCODE"))
                    TXTGOLDWT.Text = Convert.ToString(dr("GOLDWT"))
                    TXTMELTING.Text = Val(dr("MELTING"))
                    TXTCTWT.Text = Convert.ToString(dr("CTWT"))
                    TXTSIZE.Text = Convert.ToString(dr("ORDERSIZE"))
                    TXTQUOTATION.Text = Convert.ToString(dr("QUOTDTLS"))
                    CMBPRIORITY.Text = dr("PRIORITY")
                    TXTREMARKS.Text = Convert.ToString(dr("ORDERREMARKS"))

                    TXTFILENAME.Text = dr("ORDERFILENAME")
                    txtimgpath.Text = dr("IMGPATH")
                    TXTNEWIMGPATH.Text = dr("NEWIMGPATH")
                    OLDIMGPATH = dr("NEWIMGPATH")

                    PBSoftCopy.ImageLocation = TXTNEWIMGPATH.Text.Trim

                    If Convert.ToBoolean(dr("ORDERCLOSED")) = True Or Convert.ToBoolean(dr("ORDERDONE")) = True Or Val(dr("MFGWT")) > 0 Then LBLLOCKED.Visible = True
                    If Convert.ToBoolean(dr("ORDERCLOSED")) = True Then LBLCLOSED.Visible = True

                    conn.Close()
                    cmd.Dispose()

                End If
            End If

        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub cmdupload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdupload.Click

        OpenFileDialog1.Filter = "Pictures (*.bmp;*.jpeg;*.png;*.pdf)|*.bmp;*.jpg;*.png;*.pdf"
        OpenFileDialog1.ShowDialog()

        OpenFileDialog1.AddExtension = True
        TXTFILENAME.Text = OpenFileDialog1.SafeFileName
        txtimgpath.Text = OpenFileDialog1.FileName
        TXTNEWIMGPATH.Text = Application.StartupPath & "\ORDERS\" & TXTORDERNO.Text.Trim & TXTFILENAME.Text.Trim
        On Error Resume Next

        If txtimgpath.Text.Trim.Length <> 0 Then
            PBSoftCopy.ImageLocation = txtimgpath.Text.Trim
            PBSoftCopy.Load(txtimgpath.Text.Trim)
        End If

    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            Cursor.Current = Cursors.WaitCursor

            EP.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If


            'IF BACK DATED ENTRY IS TO BE SAVED THEN CHECK ENTRYPASSWORD
            If APPLYBLOCKDATE = True And ORDERDATE.Value.Date <= BLOCKEDDATE Then
                Dim OBJPASS As New PasswordEntry
                OBJPASS.ShowDialog()
                If ENTRYPASSWORD <> OBJPASS.TXTDATERETYPE.Text.Trim Then
                    MsgBox("Invaid Password", MsgBoxStyle.Critical)
                    Exit Sub
                End If
            End If


            If edit = False Then
                'IF MULTIPLE USERS ARE WORKING ON THE SAME FORM THEN WE NEED THIS
                GETMAX_ORDER_NO()
            End If


            For i = 0 To 100
                tempcol(i) = ""
                tempval(i) = ""
            Next

            tempcol(0) = "ORDER_SRNO"
            tempcol(1) = "ORDER_NO"
            tempcol(2) = "ORDER_DATE"
            tempcol(3) = "ORDER_LEDGERID"
            tempcol(4) = "ORDER_DELDAYS"
            tempcol(5) = "ORDER_DELDATE"
            tempcol(6) = "ORDER_ITEMID"
            tempcol(7) = "ORDER_GOLDWT"
            tempcol(8) = "ORDER_CTWT"
            tempcol(9) = "ORDER_SIZE"
            tempcol(10) = "ORDER_QUOTEDTLS"
            tempcol(11) = "ORDER_REMARKS"
            tempcol(12) = "ORDER_FILENAME"
            tempcol(13) = "ORDER_IMGPATH"
            tempcol(14) = "ORDER_NEWIMGPATH"
            tempcol(15) = "ORDER_CLOSE"
            tempcol(16) = "ORDER_DONE"
            tempcol(17) = "ORDER_MELTING"
            tempcol(18) = "ORDER_PRIORITY"
            tempcol(19) = "ORDER_MFGWT"
            tempcol(20) = "ORDER_USERID"


            tempval(0) = Val(TXTSRNO.Text.Trim)
            tempval(1) = "'" & TXTORDERNO.Text.Trim & "'"
            tempval(2) = "'" & Format(ORDERDATE.Value, "dd/MM/yyyy  hh:mm:ss tt") & "'"


            'getting LEDGERID
            tempcmd = New OleDbCommand("select LEDGER_id from LEDGERMASTER where LEDGER_code = '" & cmbname.Text.Trim & "'", tempconn)
            If tempconn.State = ConnectionState.Open Then
                tempconn.Close()
            End If
            tempconn.Open()
            tempdr = tempcmd.ExecuteReader
            If tempdr.HasRows Then
                tempdr.Read()
                tempval(3) = Val(tempdr(0))
            Else
                tempval(3) = 0
            End If
            tempconn.Close()
            tempdr.Close()

            tempval(4) = Val(TXTDELDAYS.Text.Trim)
            tempval(5) = "'" & Format(DELDATE.Value, "dd/MM/yyyy") & "'"

            'getting itemid
            tempcmd = New OleDbCommand("select item_id from itemmaster where item_code = '" & CMBITEMNAME.Text.Trim & "'", tempconn)
            If tempconn.State = ConnectionState.Open Then
                tempconn.Close()
            End If
            tempconn.Open()
            tempdr = tempcmd.ExecuteReader
            If tempdr.HasRows Then
                tempdr.Read()
                tempval(6) = Val(tempdr(0))
            Else
                tempval(6) = 0
            End If
            tempconn.Close()
            tempdr.Close()

            tempval(7) = Val(TXTGOLDWT.Text.Trim)
            tempval(8) = Val(TXTCTWT.Text.Trim)
            tempval(9) = Val(TXTSIZE.Text.Trim)
            tempval(10) = "'" & TXTQUOTATION.Text.Trim & "'"
            tempval(11) = "'" & TXTREMARKS.Text.Trim & "'"
            tempval(12) = "'" & TXTFILENAME.Text.Trim & "'"
            tempval(13) = "'" & txtimgpath.Text.Trim & "'"
            tempval(14) = "'" & TXTNEWIMGPATH.Text.Trim & "'"
            tempval(15) = 0
            tempval(16) = 0
            tempval(17) = Val(TXTMELTING.Text.Trim)
            tempval(18) = "'" & CMBPRIORITY.Text.Trim & "'"
            tempval(19) = 0
            tempval(20) = Val(Userid)

            If edit = False Then
                insert("ORDERMASTER", tempcol, tempval)
                MessageBox.Show("Details Added")
                PRINTREPORT(TXTSRNO.Text.Trim)
            Else
                modify("ORDERMASTER", tempcol, tempval, " WHERE ORDER_SRNO = " & TEMPORDERNO)
            End If

            'REMOVE OLD IMAGE
            If OLDIMGPATH <> TXTNEWIMGPATH.Text.Trim Then If FileIO.FileSystem.FileExists(OLDIMGPATH) = True Then FileIO.FileSystem.DeleteFile(OLDIMGPATH)


            'SAVING IMAGE
            If FileIO.FileSystem.DirectoryExists(Application.StartupPath & "\ORDERS") = False Then FileIO.FileSystem.CreateDirectory(Application.StartupPath & "\ORDERS")
            If txtimgpath.Text.Trim <> "" Then FileIO.FileSystem.CopyFile(txtimgpath.Text.Trim, TXTNEWIMGPATH.Text.Trim, True)

            If edit = False Then
                Dim TEMPMSG As Integer = MsgBox("Wish to create New Order for Same Party?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbNo Then
                    clear()
                    cmbname.Focus()
                Else
                    LBLLOCKED.Visible = False
                    LBLCLOSED.Visible = False
                    EP.Clear()
                    GETMAX_ORDER_NO()
                    CMBITEMNAME.Text = ""
                    TXTGOLDWT.Clear()
                    TXTMELTING.Clear()
                    CMBITEMNAME.Focus()
                End If
            Else
                clear()
                cmbname.Focus()
            End If
            edit = False
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub cmbname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbname.Enter
        Try
            If cmbname.Text.Trim = "" Then fillname(Me, cmbname, " AND (GROUPMASTER.GROUP_NAME = 'Sundry Creditors' OR GROUPMASTER.GROUP_NAME = 'Sundry Debtors')")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbname.KeyDown
        Try
            If e.KeyCode = Keys.F1 And e.Alt = True Then
                Dim OBJSELECT As New SelectLedger
                OBJSELECT.STRSEARCH = " AND (GROUPMASTER.GROUP_NAME = 'Sundry Creditors' OR GROUPMASTER.GROUP_NAME = 'Sundry Debtors')"
                OBJSELECT.ShowDialog()
                cmbname.Text = OBJSELECT.TEMPCODE
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbname.Validating
        Try
            If cmbname.Text.Trim <> "" Then namevalidate(cmbname, e, Me, " AND (GROUPMASTER.GROUP_NAME = 'Sundry Creditors' OR GROUPMASTER.GROUP_NAME = 'Sundry Debtors')")
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

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True

        If Not CHECKDUPLICATE() Then
            EP.SetError(TXTORDERNO, " Order No Already Exists")
            bln = False
        End If

        If cmbname.Text.Trim.Length = 0 Then
            EP.SetError(cmbname, " Please Fill Party Name ")
            bln = False
        End If

        If ClientName <> "MIMARAGEMS" Then
            If Val(TXTMELTING.Text.Trim) = 0 Then
                EP.SetError(TXTMELTING, " Please Enter Melting")
                bln = False
            End If
        End If

        If TXTORDERNO.Text.Trim.Length = 0 Then
            EP.SetError(TXTORDERNO, " Please Fill Order No")
            bln = False
        End If

        If CMBITEMNAME.Text.Trim.Length = 0 Then
            EP.SetError(CMBITEMNAME, " Please Fill Item Name")
            bln = False
        End If

        If Val(TXTGOLDWT.Text.Trim) = 0 Then
            EP.SetError(TXTGOLDWT, " Please Fill Gold Wt")
            bln = False
        End If

        If LBLCLOSED.Visible = True Then
            EP.SetError(LBLCLOSED, "Order Closed")
            bln = False
        ElseIf LBLLOCKED.Visible = True Then
            EP.SetError(LBLLOCKED, "Rec Raised, Delete Rec First")
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
            If edit = True Then

                If LBLCLOSED.Visible = True Then
                    MsgBox("Order Closed", MsgBoxStyle.Critical)
                    Exit Sub
                ElseIf LBLLOCKED.Visible = True Then
                    MsgBox("Rec Raised, Delete Rec First", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                tempmsg = MsgBox("Delete Order ?", MsgBoxStyle.YesNo)
                If tempmsg = vbYes Then
                    'deleting data from ORDERMASTER
                    cmd = New OleDbCommand("delete from ORDERMASTER where ORDER_SRNO = " & TEMPORDERNO, conn)
                    If conn.State = ConnectionState.Open Then
                        conn.Close()
                    End If
                    conn.Open()
                    cmd.ExecuteNonQuery()
                    MsgBox("Order Deleted")
                    clear()
                    edit = False
                End If
            Else
                MsgBox("Delete is only in Edit Mode")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdclose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMDCLOSE.Click
        Try
            If edit = True Then
                If LBLCLOSED.Visible = True Then
                    MsgBox("Order Already Closed", MsgBoxStyle.Critical)
                    Exit Sub
                ElseIf LBLLOCKED.Visible = True Then
                    MsgBox("Rec Raised, Delete Rec First", MsgBoxStyle.Critical)
                    Exit Sub
                End If
                tempmsg = MsgBox("Wish to Close Order?", MsgBoxStyle.YesNo)
                If tempmsg = vbYes Then
                    tempmsg = MsgBox("Are you Sure?", MsgBoxStyle.YesNo)
                    If tempmsg = vbYes Then
                        'CLOSE ORDERMASTER
                        cmd = New OleDbCommand(" UPDATE ORDERMASTER SET ORDER_CLOSE = 1 where ORDER_SRNO = " & TEMPORDERNO, conn)
                        If conn.State = ConnectionState.Open Then
                            conn.Close()
                        End If
                        conn.Open()
                        cmd.ExecuteNonQuery()
                        MsgBox("Order Closed")
                        clear()
                    End If
                End If
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub tstxtbillno_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tstxtbillno.Validating
        Try
            TEMPORDERNO = Val(tstxtbillno.Text)
            If TEMPORDERNO > 0 Then
                edit = True
                OrderMaster_Load(sender, e)
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
            Dim OBJORDER As New OrderDetails
            OBJORDER.MdiParent = MDIMain
            OBJORDER.Show()
            OBJORDER.BringToFront()
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SaveToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripButton.Click
        Call cmdok_Click(sender, e)
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try
            If edit = True Then PRINTREPORT(TEMPORDERNO)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub toolprevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolprevious.Click
        Try
            TEMPORDERNO = Val(TXTSRNO.Text) - 1
            If TEMPORDERNO > 0 Then
                edit = True
                OrderMaster_Load(sender, e)
            Else
                clear()
                edit = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub toolnext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolnext.Click
        Try
            TEMPORDERNO = Val(TXTSRNO.Text) + 1
            GETMAX_ORDER_NO()
            clear()
            If Val(TXTSRNO.Text) - 1 >= TEMPORDERNO Then
                edit = True
                OrderMaster_Load(sender, e)
            Else
                clear()
                edit = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub PRINTREPORT(ByVal PONO As Integer)
        Try
            'tempmsg = MsgBox("Wish to Print PO?", MsgBoxStyle.YesNo)
            'If tempmsg = vbYes Then
            '    Dim obhpurchorderform As New PurchaseOrderDesign
            '    obhpurchorderform.PONo = TEMPORDERNO
            '    obhpurchorderform.MdiParent = MDIMain
            '    obhpurchorderform.selfor_po = "{PURCHASEORDER.po_no}=" & TEMPORDERNO & " and {PURCHASEORDER.po_cmpid}=" & CmpId & " and {PURCHASEORDER.po_locationid}=" & Locationid & " and {PURCHASEORDER.po_yearid}=" & YearId
            '    obhpurchorderform.vendorname = cmbname.Text.Trim
            '    obhpurchorderform.FRMSTRING = "PURCHASEORDER"
            '    obhpurchorderform.Show()
            'End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTDELDAYS_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTDELDAYS.Validated
        Try
            If Val(TXTDELDAYS.Text.Trim) > 0 Then DELDATE.Value = ORDERDATE.Value.AddDays(Val(TXTDELDAYS.Text.Trim))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DELDATE_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles DELDATE.Validated
        Try
            TXTDELDAYS.Text = DateDiff(DateInterval.Day, ORDERDATE.Value.Date, DELDATE.Value.Date)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTSIZE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTSIZE.KeyPress
        numdotkeypress(e, TXTSIZE, Me)
    End Sub

    Private Sub TXTCTWT_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTCTWT.KeyPress
        numdotkeypress(e, TXTCTWT, Me)
    End Sub

    Private Sub TXTGOLDWT_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTGOLDWT.KeyPress
        numdotkeypress(e, TXTGOLDWT, Me)
    End Sub

    Function CHECKDUPLICATE() As Boolean
        Try
            Dim BLN As Boolean = True
            'CHECK DUPLICATE ORDERNO
            tempcmd = New OleDbCommand("select ORDER_SRNO from ORDERMASTER where ORDER_NO = '" & TXTORDERNO.Text.Trim & "'", tempconn)
            If tempconn.State = ConnectionState.Open Then
                tempconn.Close()
            End If
            tempconn.Open()
            tempdr = tempcmd.ExecuteReader
            If tempdr.HasRows Then
                MsgBox("Order No Already Present", MsgBoxStyle.Critical)
                BLN = False
            End If
            tempconn.Close()
            tempdr.Close()
            Return BLN
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub TXTORDERNO_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTORDERNO.Validating
        Try
            If (edit = False) Or (edit = True And OLDORDERNO <> TXTORDERNO.Text.Trim) Then
                If Not CHECKDUPLICATE() Then
                    e.Cancel = True
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDVIEW_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMDVIEW.Click
        Try
            If txtimgpath.Text.Trim <> "" Then
                If Path.GetExtension(txtimgpath.Text.Trim) = ".pdf" Then
                    System.Diagnostics.Process.Start(txtimgpath.Text.Trim)
                Else
                    Dim objVIEW As New ViewImage
                    objVIEW.pbsoftcopy.ImageLocation = PBSoftCopy.ImageLocation
                    objVIEW.ShowDialog()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDREMOVE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDREMOVE.Click
        Try
            PBSoftCopy.ImageLocation = ""
            txtimgpath.Clear()
            TXTFILENAME.Clear()
            TXTNEWIMGPATH.Clear()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTMELTING_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTMELTING.KeyPress
        numdotkeypress(e, TXTMELTING, Me)
    End Sub
End Class