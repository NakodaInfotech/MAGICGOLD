
Imports System.Data.OleDb

Public Class Itemmaster

    Public EDIT As Boolean = False
    Dim tempuse As Boolean 'for fillgridname
    Dim tempdateforedit As Date 'for editing in opstock
    Public TEMPITEMCODE As String = ""
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim GRIDDOUBLECLICK As Boolean = False
    Dim TEMPROW As Integer = 0

    Sub clear()

        'clearing array
        For i = 1 To 100
            tempcol(i) = ""
            tempval(i) = ""
        Next

        'clearing textboxes

        cmbitemname.Text = ""
        cmbcode.Text = ""
        cmbtype.Text = ""
        cmbitemname.Text = ""
        txtcategory.Clear()
        txttype.Clear()
        cmbcategory.Text = ""
        txtrate.Clear()
        txtpurity.Clear()
        txtgrosswt.Clear()
        txtnettwt.Clear()


        tempimagepath = ""
        PictureBox.ImageLocation = ""

        gridopstocks.RowCount = 0

        'gridname.RowCount = 0
        griddoubleclick = False

        cmdaddnew.Enabled = True
        GPITEM.Enabled = False
        txtcategory.Visible = True
        txttype.Visible = True
        groupstocks.Enabled = False
        cmdedit.Enabled = True

        TXTSRNO.Clear()
        CMBGRIDITEMNAME.Text = ""
        CMBGRIDTYPE.Text = ""
        CMBSIZE.Text = ""
        CMBCOLOR.Text = ""
        TXTPCS.Clear()
        TXTCTWT.Clear()
        TXTTOTALPCS.Clear()
        TXTTOTALCTWT.Clear()
        GRIDBOM.RowCount = 0

        EDIT = False

    End Sub

    Private Sub txtresort_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtitem.GotFocus
        txtitem.SelectAll()
    End Sub

    Private Sub txtnoofrooms_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtpurity.GotFocus
        txtpurity.SelectAll()
    End Sub

    Private Sub txtnoofrooms_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtpurity.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub

    Private Sub txtrateperroom_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtgrosswt.GotFocus
        txtgrosswt.SelectAll()
    End Sub

    Private Sub txtrateperroom_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtgrosswt.KeyPress, txtrate.KeyPress, TXTCTWT.KeyPress
        numdot(e, sender, Me)
    End Sub

    Private Sub txtzipcode_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtrate.GotFocus
        txtrate.SelectAll()
    End Sub

    Private Sub Itemmaster_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            If cmbitemname.Text.Trim <> "" And cmbtype.Text.Trim <> "" And cmbcategory.Text.Trim <> "" And chkchange.CheckState = CheckState.Checked Then
                tempmsg = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                If tempmsg = vbYes Then cmdok_Click(sender, e)
            End If
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If

        '****** CTRL + N *************
        If (e.Control = True And e.KeyCode = Keys.N) Then
            If USERADD = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            If cmbitemname.Text.Trim <> "" And cmbtype.Text.Trim <> "" And cmbcategory.Text.Trim <> "" And chkchange.CheckState = CheckState.Checked Then
                tempmsg = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                If tempmsg = vbYes Then cmdok_Click(sender, e)
            End If
            cmdaddnew_Click(sender, e)
        End If
    End Sub

    Private Sub Itemmaster_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        'esc
        If AscW(e.KeyChar) <> 33 Then
            chkchange.CheckState = CheckState.Checked
        End If
    End Sub

    Private Sub Itemmaster_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'ITEM MASTER'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        If cmbitemname.Text.Trim <> "" And cmbtype.Text.Trim <> "" And cmbcategory.Text.Trim <> "" And chkchange.CheckState = CheckState.Checked Then
            tempmsg = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
            If tempmsg = vbYes Then cmdok_Click(sender, e)
        End If
        Me.Close()
    End Sub

    Sub fillgridname()

        'gridname.RowCount = 0
        dt = New DataTable()
        If tempconn.State = ConnectionState.Open Then
            tempconn.Close()
        End If
        tempconn.Open()
        tempcmd = New OleDbCommand("select itemmaster.item_name, itemmaster.item_code from itemmaster order by item_name", tempconn)

        da = New OleDbDataAdapter(tempcmd)
        da.Fill(dt)

        gridname.DataSource = dt

        gridname.Columns(0).HeaderText = "Item Name"
        gridname.Columns(0).ReadOnly = True
        gridname.Columns(0).Width = 170
        gridname.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        gridname.Columns(0).Resizable = DataGridViewTriState.False


        gridname.Columns(1).HeaderText = "Item Code"
        gridname.Columns(1).ReadOnly = True
        gridname.Columns(1).Width = 100
        gridname.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        gridname.Columns(1).Resizable = DataGridViewTriState.False

        da.Dispose()
        dt.Dispose()
        tempconn.Close()
        tempcmd.Dispose()

        gridname.FirstDisplayedScrollingRowIndex = gridname.RowCount - 1


    End Sub

    Private Sub txtresort_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtitem.TextChanged
        Dim rowno, b As Integer

        fillgridname()
        'gridname.Sort(resortname, System.ComponentModel.ListSortDirection.Ascending)
        rowno = 0
        For b = 1 To gridname.RowCount

            txttempname.Text = gridname.Item(0, rowno).Value.ToString()

            txttempname.SelectionStart = 0
            txttempname.SelectionLength = txtitem.TextLength
            If LCase(txtitem.Text.Trim) <> LCase(txttempname.SelectedText.Trim) Then
                gridname.Rows.RemoveAt(rowno)
            Else
                rowno = rowno + 1
            End If

        Next
    End Sub

    Private Sub cmdclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        clear()
    End Sub

    Private Sub cmdaddnew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdaddnew.Click

        If USERADD = False Then
            MsgBox("Insufficient Rights")
            Exit Sub
        End If

        clear()
        cmdaddnew.Enabled = False
        GPITEM.Enabled = True
        txtcategory.Visible = False
        txttype.Visible = False
        groupstocks.Enabled = True


        tempcondition = ""
        fillcmb(cmbcategory, "category_name", "categorymaster", tempcondition)
        fillcmb(cmbtype, "type_name", "typemaster", tempcondition)
        fillcmb(cmbitemname, "item_name", "itemmaster", tempcondition)
        fillcmb(cmbcode, "item_code", "itemmaster", tempcondition)
        FILLITEMCODE(Me, CMBGRIDITEMNAME, "")
        FILLSHAPE(Me, CMBGRIDTYPE, "")
        FILLSIZE(Me, CMBSIZE, "")
        FILLCOLOR(Me, CMBCOLOR, "")

        cmbtype.Text = "GOLD"


        cmbitemname.Text = ""
        cmbcode.Text = ""
        cmbitemname.Focus()

    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        If ISMASTER = False Then Exit Sub

        If cmbitemname.Text.Trim <> "" And cmbtype.Text.Trim <> "" And cmbcategory.Text.Trim <> "" Then

            If cmdedit.Enabled = False Then edit = True
            If cmdedit.Enabled = True Then edit = False

            duplicate = False
            If (edit = False) Or (edit = True And LCase(tempitemname) <> LCase(cmbitemname.Text.Trim)) Then
                tempcondition = ""
                duplication("itemmaster", "item_name", cmbitemname.Text.Trim, tempcondition)
            End If
            For i = 1 To 100
                tempcol(i) = ""
                tempval(i) = ""
            Next


            'FIRST DELETE ALL DATA FROM DESC AND REINSERT
            If EDIT = True Then
                cmd = New OleDbCommand("DELETE FROM ITEMMASTER_DESC WHERE ITEM_ID = " & tempitemid, conn)
                If conn.State = ConnectionState.Open Then conn.Close()
                conn.Open()
                cmd.ExecuteNonQuery()
            End If


            If duplicate = False Then

                tempcol(0) = "item_name"
                tempcol(1) = "item_code"
                tempcol(2) = "item_typeid"
                tempcol(3) = "item_categoryid"
                tempcol(4) = "item_rate"
                tempcol(5) = "item_imagepath"
                tempcol(6) = "item_totalpcs"
                tempcol(7) = "item_totalctwt"
                tempcol(8) = "item_userid"

                tempval(0) = "'" & UCase(cmbitemname.Text.Trim) & "'"
                tempval(1) = "'" & UCase(cmbcode.Text.Trim) & "'"

                'getting typeid
                tempcmd = New OleDbCommand("select type_id from typemaster where type_name = '" & cmbtype.Text.Trim & "'", tempconn)
                If tempconn.State = ConnectionState.Open Then
                    tempconn.Close()
                End If
                tempconn.Open()
                tempdr = tempcmd.ExecuteReader
                If tempdr.HasRows Then
                    tempdr.Read()
                    tempval(2) = tempdr(0)
                Else
                    tempval(2) = "0"
                End If
                tempconn.Close()
                tempdr.Close()


                'getting categoryid
                tempcmd = New OleDbCommand("select category_id from categorymaster where category_name = '" & cmbcategory.Text.Trim & "'", tempconn)
                If tempconn.State = ConnectionState.Open Then
                    tempconn.Close()
                End If
                tempconn.Open()
                tempdr = tempcmd.ExecuteReader
                If tempdr.HasRows Then
                    tempdr.Read()
                    tempval(3) = tempdr(0)
                Else
                    tempval(3) = "0"
                End If
                tempconn.Close()
                tempdr.Close()

                tempval(4) = Val(txtrate.Text)
                tempval(5) = "'" & tempimagepath & "'"
                tempval(6) = Val(TXTTOTALPCS.Text)
                tempval(7) = Val(TXTTOTALCTWT.Text)
                tempval(8) = tempuserid

                If cmdedit.Enabled = True Then edit = False
                If cmdedit.Enabled = False Then edit = True

                If edit = False Then

                    If USERADD = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If

                    insert("itemmaster", tempcol, tempval)
                    MessageBox.Show("Item Details Added")

                ElseIf edit = True Then

                    If USEREDIT = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If

                    tempcondition = " where item_name = '" & tempitemname & "'"
                    modify("itemmaster", tempcol, tempval, tempcondition)


                    'UPDATE IN ALL TABLES
                    For i = 1 To 100
                        tempcol(i) = ""
                        tempval(i) = ""
                    Next
                    tempcol(0) = "MFG_NAME"
                    tempval(0) = "'" & cmbitemname.Text.Trim & "'"
                    tempcondition = " where mfg_name = '" & tempitemname & "'"
                    modify("MFGDESCRIPTION", tempcol, tempval, tempcondition)

                    MessageBox.Show("Item Details Updated")

                End If


                '****************** ITEM STOCK ************************
                If edit = True Then
                    'deleting old data from itemstock
                    tempcmd = New OleDbCommand("delete from itemstock where item_id = " & tempitemid & " and item_no = 0", tempconn)
                    If tempconn.State = ConnectionState.Open Then
                        tempconn.Close()
                    End If
                    tempconn.Open()
                    tempcmd.ExecuteNonQuery()
                End If


                If gridopstocks.RowCount > 0 Then
                    For i = 0 To 20
                        tempcol(i) = ""
                        tempval(i) = ""
                    Next


                    tempcol(0) = "item_id"
                    tempcol(1) = "item_purity"
                    tempcol(2) = "item_grosswt"
                    tempcol(3) = "item_nettwt"
                    tempcol(4) = "item_date"


                    'gettinmg itemid if edit = false
                    If edit = False Then

                        tempcmd = New OleDbCommand("select item_id from itemmaster where item_name = '" & cmbitemname.Text.Trim & "'", tempconn)
                        If tempconn.State = ConnectionState.Open Then
                            tempconn.Close()
                        End If
                        tempconn.Open()
                        tempdr = tempcmd.ExecuteReader
                        If tempdr.HasRows Then
                            tempdr.Read()
                            tempitemid = tempdr(0)
                        End If
                        tempconn.Close()
                        tempdr.Close()

                    ElseIf edit = True Then

                        'deleting old data from itemstock
                        tempcmd = New OleDbCommand("delete from itemstock where item_id = " & tempitemid & " and item_no = 0", tempconn)
                        If tempconn.State = ConnectionState.Open Then
                            tempconn.Close()
                        End If
                        tempconn.Open()
                        tempcmd.ExecuteNonQuery()

                    End If


                    'adding opening stocks
                    For i = 0 To gridopstocks.RowCount - 1
                        tempval(0) = tempitemid
                        tempval(1) = gridopstocks.Item(0, i).Value
                        tempval(2) = gridopstocks.Item(1, i).Value
                        tempval(3) = gridopstocks.Item(2, i).Value
                        If edit = False Then
                            tempval(4) = "'" & Format(Now.Date, "dd/MM/yyyy") & "'"
                        Else
                            tempval(4) = "'" & Format(tempdateforedit, "dd/MM/yyyy") & "'"
                        End If

                        tempcondition = ""
                        insert("itemstock", tempcol, tempval)
                    Next
                End If


                For i = 0 To 20
                    tempcol(i) = ""
                    tempval(i) = ""
                Next

                'ADD ITEMMASTER_DESC 
                If GRIDBOM.RowCount > 0 Then

                    Dim I As Integer = 0
                    tempcol(I) = "ITEM_ID"
                    I += 1
                    tempcol(I) = "ITEM_SRNO"
                    I += 1
                    tempcol(I) = "ITEM_GRIDITEMID"
                    I += 1
                    tempcol(I) = "ITEM_SHAPEID"
                    I += 1
                    tempcol(I) = "ITEM_SIZEID"
                    I += 1
                    tempcol(I) = "ITEM_COLORID"
                    I += 1
                    tempcol(I) = "ITEM_PCS"
                    I += 1
                    tempcol(I) = "ITEM_CTWT"
                    I += 1




                    For Each ROW As DataGridViewRow In GRIDBOM.Rows
                        I = 0


                        tempcmd = New OleDbCommand("select item_id from itemmaster where item_name = '" & cmbitemname.Text.Trim & "'", tempconn)
                        If tempconn.State = ConnectionState.Open Then tempconn.Close()
                        tempconn.Open()
                        tempdr = tempcmd.ExecuteReader
                        If tempdr.HasRows Then
                            tempdr.Read()
                            tempval(I) = tempdr(0)
                            I += 1
                        End If
                        tempconn.Close()
                        tempdr.Close()


                        tempval(I) = Val(ROW.Cells(GSRNO.Index).Value)
                        I += 1


                        'GRIDITEMID
                        tempcmd = New OleDbCommand("select item_id from itemmaster where item_CODE = '" & ROW.Cells(GITEMCODE.Index).Value & "'", tempconn)
                        If tempconn.State = ConnectionState.Open Then tempconn.Close()
                        tempconn.Open()
                        tempdr = tempcmd.ExecuteReader
                        If tempdr.HasRows Then
                            tempdr.Read()
                            tempval(I) = tempdr(0)
                            I += 1
                        End If
                        tempconn.Close()
                        tempdr.Close()


                        'SHAPE
                        tempcmd = New OleDbCommand("select SHAPE_id from SHAPEMASTER where SHAPE_NAME = '" & ROW.Cells(GTYPE.Index).Value & "'", tempconn)
                        If tempconn.State = ConnectionState.Open Then tempconn.Close()
                        tempconn.Open()
                        tempdr = tempcmd.ExecuteReader
                        If tempdr.HasRows Then
                            tempdr.Read()
                            tempval(I) = tempdr(0)
                            I += 1
                        Else
                            tempval(I) = 0
                            I += 1
                        End If
                        tempconn.Close()
                        tempdr.Close()


                        'SHAPE
                        tempcmd = New OleDbCommand("select SIZE_id from SIZEMASTER where SIZE_NAME = '" & ROW.Cells(GSIZE.Index).Value & "'", tempconn)
                        If tempconn.State = ConnectionState.Open Then tempconn.Close()
                        tempconn.Open()
                        tempdr = tempcmd.ExecuteReader
                        If tempdr.HasRows Then
                            tempdr.Read()
                            tempval(I) = tempdr(0)
                            I += 1
                        Else
                            tempval(I) = 0
                            I += 1
                        End If
                        tempconn.Close()
                        tempdr.Close()


                        'COLOR
                        tempcmd = New OleDbCommand("select COLOR_id from COLORMASTER where COLOR_NAME = '" & ROW.Cells(GCOLOR.Index).Value & "'", tempconn)
                        If tempconn.State = ConnectionState.Open Then tempconn.Close()
                        tempconn.Open()
                        tempdr = tempcmd.ExecuteReader
                        If tempdr.HasRows Then
                            tempdr.Read()
                            tempval(I) = tempdr(0)
                            I += 1
                        Else
                            tempval(I) = 0
                            I += 1
                        End If
                        tempconn.Close()
                        tempdr.Close()


                        tempval(I) = Val(ROW.Cells(GPCS.Index).Value)
                        I += 1
                        tempval(I) = Val(ROW.Cells(GCTWT.Index).Value)
                        I += 1

                        insert("ITEMMASTER_DESC", tempcol, tempval)

                    Next
                End If



                clear()
                If edit = False Then
                    fillgridname()
                    gridname.Select()
                    For Each row As DataGridViewRow In gridname.SelectedRows
                        gettingdetails(row.Cells(0).Value.ToString)
                    Next
                End If
            Else
                MsgBox("Item Name already Exists")
            End If

        Else
            MsgBox("Enter Valid Details")
            cmbitemname.Focus()
        End If

    End Sub

    Private Sub txtrateperroom_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtgrosswt.Validated
        If Val(txtgrosswt.Text) <> 0 And Val(txtpurity.Text) <> 0 Then
            txtnettwt.Text = Format(((Val(txtpurity.Text) * Val(txtgrosswt.Text)) / 100), "0.000")
        End If
    End Sub

    Sub fillgrid()

        If griddoubleclick = False Then

            gridopstocks.Rows.Add(txtpurity.Text, Val(txtgrosswt.Text), Val(txtnettwt.Text))

        ElseIf griddoubleclick = True Then

            gridopstocks.Item(0, temprow).Value = Val(txtpurity.Text)
            gridopstocks.Item(1, temprow).Value = Format(Val(txtgrosswt.Text), "0.000")
            gridopstocks.Item(2, temprow).Value = Format(Val(txtnettwt.Text), "0.000")
            griddoubleclick = False

        End If
        gridopstocks.FirstDisplayedScrollingRowIndex = gridopstocks.RowCount - 1

    End Sub

    Private Sub cmbcity_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbtype.GotFocus
        tempcondition = ""
        fillcmb(cmbtype, "type_name", "typemaster", tempcondition)
    End Sub

    Private Sub cmbcity_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbtype.KeyPress
        enterkeypress(e, Me)
    End Sub

    Private Sub cmbcity_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbtype.Validated
        cmbtype.Text = caps(cmbtype.Text.Trim)

        If cmbtype.Text.Trim <> "" Then

            If tempmsg1 = False Then
                cmd = New OleDbCommand("select type_id from typemaster where type_name = '" & cmbtype.Text.Trim & "'", conn)
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
                conn.Open()
                dr = cmd.ExecuteReader
                If dr.HasRows = False Then
                    tempmsg = MsgBox("Item Type Not Present, Add New?", MsgBoxStyle.YesNo)
                    If tempmsg = vbYes Then
                        tempmsg1 = True

                        tempcol(0) = "type_name"
                        tempcol(1) = "type_userid"
                        
                        tempval(0) = "'" & cmbtype.Text.Trim & "'"
                        tempval(1) = tempuserid


                        insert("typemaster", tempcol, tempval)
                        tempmsg1 = False
                    Else
                        cmbtype.Focus()
                    End If
                End If
            End If

        End If
    End Sub

    Sub gettingdetails(ByVal a As String)

        If USERVIEW = False Then
            MsgBox("Insufficient Rights")
            Exit Sub
        End If

        'getting detals
        cmd = New OleDbCommand("SELECT ItemMaster.item_id, ItemMaster.item_name, typemaster.type_name, CategoryMaster.category_name,ItemMaster.item_rate, ItemMaster.item_imagepath,itemmaster.item_code FROM (ItemMaster INNER JOIN typemaster ON ItemMaster.item_typeid = typemaster.type_id) INNER JOIN CategoryMaster ON ItemMaster.item_categoryid = CategoryMaster.category_id where item_name = '" & a & "'", conn)
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If
        conn.Open()
        dr = cmd.ExecuteReader()
        If dr.HasRows Then
            While (dr.Read())

                tempitemid = dr(0)
                tempitemname = dr(1).ToString
                cmbitemname.Text = dr(1).ToString
                txttype.Text = dr(2).ToString
                txtcategory.Text = dr(3).ToString
                txtrate.Text = Format(dr(4), "0.00")

                If dr(5).ToString <> "" Then
                    PictureBox.ImageLocation = dr(5).ToString
                    tempimagepath = dr(5).ToString
                Else
                    PictureBox.ImageLocation = ""
                    tempimagepath = ""
                End If

                tempitemcode = dr(6).ToString
                cmbcode.Text = dr(6).ToString

            End While
            conn.Close()
            dr.Close()


            'FILLING ITEMMASTER_DESC
            cmd = New OleDbCommand("SELECT ITEMMASTER_DESC.ITEM_SRNO AS [SRNO], ItemMaster.item_code AS [ITEMCODE], ShapeMaster.shape_name AS [SHAPE], SizeMaster.size_name AS [SIZE], ColorMaster.color_name AS [COLOR], ITEMMASTER_DESC.ITEM_PCS AS [PCS], ITEMMASTER_DESC.ITEM_CTWT AS [CTWT] FROM (((ITEMMASTER_DESC INNER JOIN ItemMaster ON ITEMMASTER_DESC.ITEM_GRIDITEMID = ItemMaster.item_id) LEFT JOIN ShapeMaster ON ITEMMASTER_DESC.ITEM_SHAPEID = ShapeMaster.shape_id) LEFT JOIN SizeMaster ON ITEMMASTER_DESC.ITEM_SIZEID = SizeMaster.size_id) LEFT JOIN ColorMaster ON ITEMMASTER_DESC.ITEM_COLORID = ColorMaster.color_id where ITEMMASTER_DESC.ITEM_ID = " & tempitemid, conn)
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Open()
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                While (dr.Read())
                    GRIDBOM.Rows.Add(Val(dr("SRNO")), dr("ITEMCODE"), dr("SHAPE"), dr("SIZE"), dr("COLOR"), Val(dr("PCS")), Val(dr("CTWT")))
                End While
                TOTAL()
                GRIDBOM.FirstDisplayedScrollingRowIndex = GRIDBOM.RowCount - 1
                conn.Close()
                dr.Close()
            End If

        End If


        'filling opening stock
        cmd = New OleDbCommand("SELECT * FROM Itemstock where item_id = " & tempitemid & " AND ITEM_NO = 0", conn)
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If
        conn.Open()
        dr = cmd.ExecuteReader()
        If dr.HasRows Then
            While (dr.Read())
                gridopstocks.Rows.Add(dr(1), dr(2), dr(3))
                If dr(5).ToString <> "" Then tempdateforedit = dr(5)
            End While
            gridopstocks.FirstDisplayedScrollingRowIndex = gridopstocks.RowCount - 1

            conn.Close()
            dr.Close()
        End If

    End Sub

    Sub TOTAL()
        Try
            TXTTOTALPCS.Clear()
            TXTTOTALCTWT.Clear()

            For Each ROW As DataGridViewRow In GRIDBOM.Rows
                TXTTOTALPCS.Text = Val(TXTTOTALPCS.Text) + Val(ROW.Cells(GPCS.Index).Value)
                TXTTOTALCTWT.Text = Val(TXTTOTALCTWT.Text.Trim) + Val(ROW.Cells(GCTWT.Index).Value)
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbstate_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbcategory.GotFocus
        tempcondition = ""
        fillcmb(cmbcategory, "category_name", "categorymaster", tempcondition)
    End Sub

    Private Sub cmbcategory_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbcategory.Validated
        cmbcategory.Text = caps(cmbcategory.Text.Trim)

        If cmbcategory.Text.Trim <> "" Then

            If tempmsg1 = False Then
                cmd = New OleDbCommand("select category_id from categorymaster where category_name = '" & cmbcategory.Text.Trim & "'", conn)
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
                conn.Open()
                dr = cmd.ExecuteReader
                If dr.HasRows = False Then
                    tempmsg = MsgBox("Category Not Present, Add New?", MsgBoxStyle.YesNo)
                    If tempmsg = vbYes Then

                        For i = 0 To 100
                            tempcol(i) = ""
                            tempval(i) = ""
                        Next

                        tempmsg1 = True

                        tempcol(0) = "category_name"
                        tempcol(1) = "category_userid"

                        tempval(0) = "'" & cmbcategory.Text.Trim & "'"
                        tempval(1) = tempuserid


                        insert("categorymaster", tempcol, tempval)
                        tempmsg1 = False
                    Else
                        cmbcategory.Focus()
                    End If
                End If
            End If

        End If
    End Sub

    Private Sub gridname_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridname.CellClick
        If tempuse = False Then
            For Each row As DataGridViewRow In gridname.SelectedRows
                clear()
                gettingdetails(row.Cells(0).Value.ToString)
            Next
        End If
    End Sub

    Private Sub gridname_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridname.CellDoubleClick

        If USEREDIT = False Then
            MsgBox("Insufficient Rights")
            Exit Sub
        End If

        cmdedit.Enabled = False
        edit = True
        GPITEM.Enabled = True
        groupstocks.Enabled = True
        cmdaddnew.Enabled = False

        txtcategory.Visible = False
        cmbcategory.Text = txtcategory.Text
        txttype.Visible = False
        cmbtype.Text = txttype.Text
        cmbitemname.Focus()

    End Sub

    Private Sub gridname_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridname.CellEnter
        If tempuse = False Then
            For Each row As DataGridViewRow In gridname.SelectedRows
                clear()
                gettingdetails(row.Cells(0).Value.ToString)
            Next
        End If
    End Sub

    Sub filltransactions()

        'dt = New DataTable()
        'If tempconn.State = ConnectionState.Open Then
        '    tempconn.Close()
        'End If
        'tempconn.Open()
        'tempcmd = New OleDbCommand("select bookingmaster.booking_id,ledgermaster.ledger_name,bookingmaster.booking_date,bookingmaster.booking_balance FROM bookingmaster INNER JOIN ledgermaster ON bookingmaster.booking_ledgerid = ledgermaster.ledger_id where booking_resortid= " & Val(tempresortid) & " and booking_cmpid = " & tempcmpid, tempconn)
        'da = New OleDbDataAdapter(tempcmd)
        'da.Fill(dt)
        'gridtransactions.DataSource = dt

        'gridtransactions.Columns(0).HeaderText = "Booking No."
        'gridtransactions.Columns(1).HeaderText = "Name"
        'gridtransactions.Columns(2).HeaderText = "Booking Date"
        'gridtransactions.Columns(3).HeaderText = "Balance"

        'gridtransactions.Columns(0).ReadOnly = True
        'gridtransactions.Columns(0).Width = 100
        'gridtransactions.Columns(0).Resizable = DataGridViewTriState.False
        'gridtransactions.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        'gridtransactions.Columns(1).ReadOnly = True
        'gridtransactions.Columns(1).Width = 200
        'gridtransactions.Columns(1).Resizable = DataGridViewTriState.False
        'gridtransactions.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

        'gridtransactions.Columns(2).ReadOnly = True
        'gridtransactions.Columns(2).Width = 100
        'gridtransactions.Columns(2).Resizable = DataGridViewTriState.False

        'gridtransactions.Columns(3).ReadOnly = True
        'gridtransactions.Columns(3).Width = 100
        'gridtransactions.Columns(3).Resizable = DataGridViewTriState.False
        'gridtransactions.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

    End Sub

    Private Sub gridname_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridname.GotFocus
        clear()
    End Sub

    Private Sub newcustomer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles newcustomer.Click

        clear()
        cmdaddnew.Enabled = False
        GPITEM.Enabled = True
        txtcategory.Visible = False
        txttype.Visible = False
        groupstocks.Enabled = True

        tempcondition = ""
        fillcmb(cmbtype, "type_name", "typemaster", tempcondition)
        fillcmb(cmbcategory, "category_name", "categorymaster", tempcondition)
        fillcmb(cmbitemname, "item_name", "itemmaster", tempcondition)
        fillcmb(cmbcode, "item_code", "itemmaster", tempcondition)
        cmbitemname.Focus()

    End Sub

    Private Sub cmdedit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdedit.Click

        If USEREDIT = False Then
            MsgBox("Insufficient Rights")
            Exit Sub
        End If

        For Each row As DataGridViewRow In gridname.SelectedRows
            gridopstocks.RowCount = 0
            gettingdetails(row.Cells(0).Value.ToString)
        Next
        cmdedit.Enabled = False
        edit = True
        GPITEM.Enabled = True
        groupstocks.Enabled = True
        cmdaddnew.Enabled = False

        txtcategory.Visible = False
        cmbcategory.Text = txtcategory.Text
        txttype.Visible = False
        cmbtype.Text = txttype.Text
        cmbitemname.Focus()

    End Sub

    Private Sub CMBGRIDITEMNAME_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBGRIDITEMNAME.Enter
        Try
            If CMBGRIDITEMNAME.Text.Trim = "" Then If CMBGRIDITEMNAME.Text.Trim = "" Then FILLITEMCODE(Me, CMBGRIDITEMNAME, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBGRIDITEMNAME_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBGRIDITEMNAME.KeyDown
        Try
            If e.KeyCode = Keys.F1 And e.Alt = True Then
                Dim OBJITEM As New SelectItem
                OBJITEM.ShowDialog()
                CMBGRIDITEMNAME.Text = OBJITEM.TEMPCODE
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBGRIDITEMNAME_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBGRIDITEMNAME.Validating
        Try
            If CMBGRIDITEMNAME.Text.Trim <> "" Then ITEMVALIDATE(CMBGRIDITEMNAME, e, Me, "")
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

    Private Sub CMBGRIDTYPE_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBGRIDTYPE.Enter
        Try
            If CMBGRIDTYPE.Text.Trim = "" Then FILLSHAPE(Me, CMBGRIDTYPE, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBGRIDTYPE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBGRIDTYPE.Validating
        Try
            If CMBGRIDTYPE.Text.Trim <> "" Then SHAPEVALIDATE(CMBGRIDTYPE, e, Me, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub cmbitemname_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbitemname.GotFocus
        tempcondition = ""
        fillcmb(cmbitemname, "item_name", "itemmaster", tempcondition)
    End Sub

    Private Sub cmbitemname_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbitemname.KeyPress
        enterkeypress(e, Me)
    End Sub

    Private Sub cmbitemname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbitemname.Validating
        If cmbitemname.Text.Trim <> "" Then
            cmbitemname.Text = uppercase(cmbitemname.Text.Trim)
            duplicate = False
            If (edit = False) Or (edit = True And LCase(tempitemname) <> LCase(cmbitemname.Text.Trim)) Then
                tempcondition = ""
                duplication("itemmaster", "item_name", cmbitemname.Text.Trim, tempcondition)
            End If
            If duplicate = True Then
                MsgBox("Item Name Already Exists")
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub txtnettwt_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtnettwt.Validated
        If Val(txtpurity.Text) <> 0 And Val(txtgrosswt.Text) <> 0 And Val(txtnettwt.Text) <> 0 Then
            fillgrid()

            txtpurity.Clear()
            txtgrosswt.Clear()
            txtnettwt.Clear()
            txtpurity.Focus()
        End If
    End Sub

    Private Sub cmdimage_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdimage.Click
        OpenFileDialog1.Filter = "*.jpg|*.jpg|*.bmp|*.bmp"
        OpenFileDialog1.ShowDialog()
        tempimagepath = OpenFileDialog1.FileName
        PictureBox.ImageLocation = OpenFileDialog1.FileName
    End Sub

    Private Sub cmdremove_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdremove.Click
        tempmsg = MsgBox("Remove Image?...", MsgBoxStyle.YesNo)
        If tempmsg = vbYes Then
            tempimagepath = ""
            PictureBox.ImageLocation = ""
        End If
    End Sub

    Private Sub cmbcode_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbcode.GotFocus
        tempcondition = ""
        fillcmb(cmbcode, "item_code", "itemmaster", tempcondition)
    End Sub

    Private Sub cmbcode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbcode.KeyPress
        enterkeypress(e, Me)
    End Sub

    Private Sub cmbcode_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbcode.Validating
        If cmbcode.Text.Trim <> "" Then
            cmbcode.Text = uppercase(cmbcode.Text.Trim)
            duplicate = False
            If (edit = False) Or (edit = True And LCase(tempitemcode) <> LCase(cmbcode.Text.Trim)) Then
                tempcondition = ""
                duplication("itemmaster", "item_code", cmbcode.Text.Trim, tempcondition)
            End If
            If duplicate = True Then
                MsgBox("Item Code Already Exists")
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub gridopstocks_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridopstocks.CellDoubleClick
        Try
            If e.RowIndex >= 0 And gridopstocks.Item(0, e.RowIndex).Value <> Nothing Then

                griddoubleclick = True
                txtpurity.Text = gridopstocks.Item(0, e.RowIndex).Value.ToString
                txtgrosswt.Text = gridopstocks.Item(1, e.RowIndex).Value
                txtnettwt.Text = gridopstocks.Item(2, e.RowIndex).Value
                temprow = e.RowIndex
                txtpurity.Focus()

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTCTWT_Validated(sender As Object, e As EventArgs) Handles TXTCTWT.Validated
        Try
            If CMBGRIDITEMNAME.Text.Trim <> "" And Val(TXTPCS.Text.Trim) > 0 Then FILLBOM()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLBOM()
        Try
            If GRIDDOUBLECLICK = False Then
                GRIDBOM.Rows.Add(0, CMBGRIDITEMNAME.Text.Trim, CMBGRIDTYPE.Text.Trim, CMBSIZE.Text.Trim, CMBCOLOR.Text.Trim, Val(TXTPCS.Text.Trim), Val(TXTCTWT.Text.Trim))
                getsrno(GRIDBOM)
            Else
                GRIDBOM.Item(GSRNO.Index, TEMPROW).Value = Val(TXTSRNO.Text.Trim)
                GRIDBOM.Item(GITEMCODE.Index, TEMPROW).Value = CMBGRIDITEMNAME.Text.Trim
                GRIDBOM.Item(GTYPE.Index, TEMPROW).Value = CMBGRIDTYPE.Text.Trim
                GRIDBOM.Item(GSIZE.Index, TEMPROW).Value = CMBSIZE.Text.Trim
                GRIDBOM.Item(GCOLOR.Index, TEMPROW).Value = CMBCOLOR.Text.Trim
                GRIDBOM.Item(GPCS.Index, TEMPROW).Value = Val(TXTPCS.Text.Trim)
                GRIDBOM.Item(GCTWT.Index, TEMPROW).Value = Val(TXTCTWT.Text.Trim)

                GRIDDOUBLECLICK = False
            End If

            GRIDBOM.FirstDisplayedScrollingRowIndex = GRIDBOM.RowCount - 1

            TXTSRNO.Clear()
            CMBGRIDITEMNAME.Text = ""
            CMBGRIDTYPE.Text = ""
            CMBSIZE.Text = ""
            CMBCOLOR.Text = ""
            TXTPCS.Clear()
            TXTCTWT.Clear()
            TOTAL()

            CMBGRIDITEMNAME.Focus()

        Catch ex As Exception
            Throw ex
        End Try
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

    Private Sub gridopstocks_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridopstocks.KeyDown
        Try
            If e.KeyCode = Keys.Delete Then
                gridopstocks.Rows.RemoveAt(gridopstocks.CurrentRow.Index)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDDELETE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDDELETE.Click
        Try
            If cmdedit.Enabled = False Then

                If USERDELETE = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                'before deleting CHECK IN ALL RELATED TABLE FOR REFERENCE

                'getting Accountmaster
                tempcmd = New OleDbCommand("select 'Accounts' as TABLENAME, ACCOUNT_DATE AS [DATE] from ACCOUNTMASTER where ACCOUNT_ITEMID = " & tempitemid, tempconn)
                If tempconn.State = ConnectionState.Open Then tempconn.Close()
                tempconn.Open()
                tempdr = tempcmd.ExecuteReader
                If tempdr.HasRows Then
                    tempdr.Read()
                    MsgBox("Unable to Delete Item, First Delete data from " & tempdr(0), MsgBoxStyle.Critical)
                    Exit Sub
                End If
                tempconn.Close()
                tempdr.Close()

                'getting bhavcutmaster
                tempcmd = New OleDbCommand("select 'BhavCut' as TABLENAME, bhavcut_DATE AS [DATE] from BHAVCUTMASTER where BHAVCUT_ITEMID = " & tempitemid, tempconn)
                If tempconn.State = ConnectionState.Open Then tempconn.Close()
                tempconn.Open()
                tempdr = tempcmd.ExecuteReader
                If tempdr.HasRows Then
                    tempdr.Read()
                    MsgBox("Unable to Delete Item, First Delete data from " & tempdr(0), MsgBoxStyle.Critical)
                    Exit Sub
                End If
                tempconn.Close()
                tempdr.Close()

                'getting CustomerWastage
                tempcmd = New OleDbCommand("select 'Customer Wastage' as TABLENAME from CUSTOMERWASTAGE where ITEMID = " & tempitemid, tempconn)
                If tempconn.State = ConnectionState.Open Then tempconn.Close()
                tempconn.Open()
                tempdr = tempcmd.ExecuteReader
                If tempdr.HasRows Then
                    tempdr.Read()
                    MsgBox("Unable to Delete Item, First Delete data from " & tempdr(0), MsgBoxStyle.Critical)
                    Exit Sub
                End If
                tempconn.Close()
                tempdr.Close()

                'getting INVOICEMASTER
                tempcmd = New OleDbCommand("select 'Invoice' as TABLENAME, Invoice_ID AS INVOICENO from INVOICEDESCRIPTION where INVOICE_ITEMID = " & tempitemid, tempconn)
                If tempconn.State = ConnectionState.Open Then tempconn.Close()
                tempconn.Open()
                tempdr = tempcmd.ExecuteReader
                If tempdr.HasRows Then
                    tempdr.Read()
                    MsgBox("Unable to Delete Item, First Delete data from " & tempdr(0) & " No. " & tempdr(1), MsgBoxStyle.Critical)
                    Exit Sub
                End If
                tempconn.Close()
                tempdr.Close()


                'getting ITEMSTOCK
                tempcmd = New OleDbCommand("select 'Manufacturing' as TABLENAME, ITEM_NO AS LOTNO from ITEMSTOCK where ITEM_ID = " & tempitemid, tempconn)
                If tempconn.State = ConnectionState.Open Then tempconn.Close()
                tempconn.Open()
                tempdr = tempcmd.ExecuteReader
                If tempdr.HasRows Then
                    tempdr.Read()
                    MsgBox("Unable to Delete Item, First Delete data from " & tempdr(0) & " Lot No " & tempdr(1), MsgBoxStyle.Critical)
                    Exit Sub
                End If
                tempconn.Close()
                tempdr.Close()


                'getting KARIGARISSUE
                tempcmd = New OleDbCommand("select 'Manufacturing - Karigar' as TABLENAME from KARIGARISSUE where MFG_ITEMID = " & tempitemid, tempconn)
                If tempconn.State = ConnectionState.Open Then tempconn.Close()
                tempconn.Open()
                tempdr = tempcmd.ExecuteReader
                If tempdr.HasRows Then
                    tempdr.Read()
                    MsgBox("Unable to Delete Item, First Delete data from " & tempdr(0), MsgBoxStyle.Critical)
                    Exit Sub
                End If
                tempconn.Close()
                tempdr.Close()


                'getting LOTFAIL
                tempcmd = New OleDbCommand("select 'Manufacturing - Lotfail' as TABLENAME from LOTFAIL where MFG_ITEMID = " & tempitemid, tempconn)
                If tempconn.State = ConnectionState.Open Then tempconn.Close()
                tempconn.Open()
                tempdr = tempcmd.ExecuteReader
                If tempdr.HasRows Then
                    tempdr.Read()
                    MsgBox("Unable to Delete Item, First Delete data from " & tempdr(0), MsgBoxStyle.Critical)
                    Exit Sub
                End If
                tempconn.Close()
                tempdr.Close()


                'getting MELTINGMASTER
                tempcmd = New OleDbCommand("select 'Melting' as TABLENAME, MELTING_ID AS LOTNO from MELTINGMASTER where MELTING_ITEMID = " & tempitemid, tempconn)
                If tempconn.State = ConnectionState.Open Then tempconn.Close()
                tempconn.Open()
                tempdr = tempcmd.ExecuteReader
                If tempdr.HasRows Then
                    tempdr.Read()
                    MsgBox("Unable to Delete Item, First Delete data from " & tempdr(0) & " Lot No " & tempdr(1), MsgBoxStyle.Critical)
                    Exit Sub
                End If
                tempconn.Close()
                tempdr.Close()


                'getting RECEIPTDESCRIPTON
                tempcmd = New OleDbCommand("select 'Reciept' as TABLENAME, RECIEPT_ID AS RECIEPTNO from RECIEPTDESCRIPTION where RECIEPT_ITEMID = " & tempitemid, tempconn)
                If tempconn.State = ConnectionState.Open Then tempconn.Close()
                tempconn.Open()
                tempdr = tempcmd.ExecuteReader
                If tempdr.HasRows Then
                    tempdr.Read()
                    MsgBox("Unable to Delete Item, First Delete data from " & tempdr(0) & " No " & tempdr(1), MsgBoxStyle.Critical)
                    Exit Sub
                End If
                tempconn.Close()
                tempdr.Close()


                'getting VOUCHERS
                tempcmd = New OleDbCommand("select 'Daily Khata' as TABLENAME from VOUCHERS where VOUCHER_ITEMID = " & tempitemid, tempconn)
                If tempconn.State = ConnectionState.Open Then tempconn.Close()
                tempconn.Open()
                tempdr = tempcmd.ExecuteReader
                If tempdr.HasRows Then
                    tempdr.Read()
                    MsgBox("Unable to Delete Item, First Delete data from " & tempdr(0), MsgBoxStyle.Critical)
                    Exit Sub
                End If
                tempconn.Close()
                tempdr.Close()


                'IF EVERYTHING IS PERFECT THEN DLEETE
                Dim TEMPMSG As Integer = MsgBox("Wish to Delete Item?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbNo Then Exit Sub
                tempcmd = New OleDbCommand("DELETE FROM ITEMMASTER where ITEM_ID = " & tempitemid, tempconn)
                If tempconn.State = ConnectionState.Open Then tempconn.Close()
                tempconn.Open()
                tempdr = tempcmd.ExecuteReader
                MsgBox("Item Deleted Successfully", MsgBoxStyle.Information, "Magic Gold")
                clear()
                fillgridname()
                tempconn.Close()
                tempdr.Close()

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ToolStripdelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripdelete.Click
        Try
            Call CMDDELETE_Click(sender, e)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDBOM_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRIDBOM.CellDoubleClick
        Try
            If e.RowIndex >= 0 And GRIDBOM.Item(GSRNO.Index, e.RowIndex).Value <> Nothing Then

                GRIDDOUBLECLICK = True
                TXTSRNO.Text = GRIDBOM.Item(GSRNO.Index, e.RowIndex).Value.ToString
                CMBGRIDITEMNAME.Text = GRIDBOM.Item(GITEMCODE.Index, e.RowIndex).Value.ToString
                CMBGRIDTYPE.Text = GRIDBOM.Item(GTYPE.Index, e.RowIndex).Value.ToString
                CMBSIZE.Text = GRIDBOM.Item(GSIZE.Index, e.RowIndex).Value.ToString
                CMBCOLOR.Text = GRIDBOM.Item(GCOLOR.Index, e.RowIndex).Value.ToString
                TXTPCS.Text = GRIDBOM.Item(GPCS.Index, e.RowIndex).Value.ToString
                TXTCTWT.Text = GRIDBOM.Item(GCTWT.Index, e.RowIndex).Value.ToString

                TEMPROW = e.RowIndex
                CMBGRIDITEMNAME.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDBOM_KeyDown(sender As Object, e As KeyEventArgs) Handles GRIDBOM.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDBOM.RowCount > 0 Then

                'dont allow user if any of the grid line is in edit mode.....
                'cmbitemname.Text.Trim <> Val(txtqty.Text) <> 0 And Val(txtamount.Text.Trim) <> 0 And cmbqtyunit.Text.Trim <> 
                If GRIDDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                'end of block

                GRIDBOM.Rows.RemoveAt(GRIDBOM.CurrentRow.Index)
                getsrno(GRIDBOM)
                TOTAL()

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Itemmaster_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Try
            EDIT = False
            gridname.RowCount = 0
            fillgridname()
            tempuse = False
            If TEMPITEMCODE <> "" Then Call cmdaddnew_Click(sender, e)
            cmbtype.Text = "GOLD"

            If ISMASTER = False Then
                cmdaddnew.Enabled = False
                cmdok.Enabled = False
                CMDDELETE.Enabled = False
            End If


        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class