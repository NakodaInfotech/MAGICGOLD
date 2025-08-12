
Imports System.Data.OleDb

Public Class Manufacturingdetails

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub Manufacturingdetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Alt = True And e.KeyCode = Windows.Forms.Keys.O Then       'for oPEN
            Call cmdok_Click(sender, e)
        ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            Me.Close()
        End If

        '*********** CTRL + N ************
        If (e.Control = True And e.KeyCode = Keys.N) Or (e.Alt = True And e.KeyCode = Keys.A) Then
            If USERADD = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            Me.Close()
            If (chldmfgmaster.IsMdiChild = False) Then
                If chldmfgmaster.IsDisposed = True Then
                    chldmfgmaster = New Manufacturing
                End If
                chldmfgmaster.MdiParent = MDIMain
                chldmfgmaster.Show()
            Else
                chldmfgmaster.BringToFront()
            End If

        End If
    End Sub

    Private Sub gridmelting_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridmfg.CellDoubleClick

        If e.RowIndex < 0 Then Exit Sub
        If gridmfg.Item(0, e.RowIndex).Value <> Nothing Then
            

            If USEREDIT = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If (chldmfgmaster.IsMdiChild = False) Then
                If chldmfgmaster.IsDisposed = True Then
                    chldmfgmaster = New Manufacturing
                End If
                chldmfgmaster.MdiParent = MDIMain
                chldmfgmaster.cmdedit.Enabled = False
                chldmfgmaster.cmbpart.Text = temppartno
                chldmfgmaster.EDIT = True
                tempmfgno = gridmfg.Item(8, e.RowIndex).Value
                temppartno = gridmfg.Item(3, e.RowIndex).Value
                chldmfgmaster.Show()
            Else
                chldmfgmaster.BringToFront()
            End If
            Me.Close()

        End If

    End Sub

    Private Sub newarea_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles newmfg.Click
        If USERADD = False Then
            MsgBox("Insufficient Rights")
            Exit Sub
        End If

        Me.Close()

        If (chldmfgmaster.IsMdiChild = False) Then
            If chldmfgmaster.IsDisposed = True Then
                chldmfgmaster = New Manufacturing
            End If
            chldmfgmaster.MdiParent = MDIMain
            chldmfgmaster.Show()
        Else
            chldmfgmaster.BringToFront()
        End If
    End Sub

    Private Sub Manufacturingdetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'MANUFACTURING'")
        USERADD = DTROW(0).Item(1)
        USEREDIT = DTROW(0).Item(2)
        USERVIEW = DTROW(0).Item(3)
        USERDELETE = DTROW(0).Item(4)

        If USEREDIT = False And USERVIEW = False Then
            MsgBox("Insufficient Rights")
            Exit Sub
        End If


        TXTTOTALLOTS.Clear()
        TXTTOTAL.Clear()
        TXTTOTALNETT.Clear()
        fillgrid()
        txtname.Clear()
        cmbselect.SelectedIndex = 0
    End Sub

    Private Sub Manufacturingdetails_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If ClientName = "MIMARAGEMS" Then Me.Close()
    End Sub

    Sub fillgrid()

        'getting data from mfgmaster
        'gridmfg.RowCount = 0

        dt = New DataTable()
        If tempconn.State = ConnectionState.Open Then
            tempconn.Close()
        End If
        tempconn.Open()

        Dim CONDITION As String = ""
        Dim MFGCONDITION As String = ""
        If chkdate.CheckState = CheckState.Checked Then
            CONDITION = CONDITION & " AND mfgmaster.mfg_date >= #" & Format(dtpfrom.Value.Date, "MM/dd/yyyy") & "# AND mfgmaster.mfg_date <=# " & Format(dtpto.Value.Date, "MM/dd/yyyy") & "#"
            MFGCONDITION = MFGCONDITION & " AND mfgmaster_1.mfg_date >= #" & Format(dtpfrom.Value.Date, "MM/dd/yyyy") & "# AND mfgmaster_1.mfg_date <=# " & Format(dtpto.Value.Date, "MM/dd/yyyy") & "#"
        End If

        If RBALL.Checked = True Then
            tempcmd = New OleDbCommand("SELECT (mfgmaster.mfg_lotno) as lotno, mfgmaster.mfg_melting as REQPURITY, mfgmaster.mfg_date as date1, 'Part(' & mfgstock.mfg_partno & ')' ,iif(mfgstock.mfg_narration='',mfgstock.mfg_processname,mfgstock.mfg_narration) as name, mfgstock.mfg_inputwt as gross, iif(mfgstock.mfg_lotfail = True, IIF(MFGSTOCK.MFG_MERGED = True, 'MERGED',  'LOT FAIL'),  mfgstock.mfg_processname) as process, mfgstock.mfg_percentinput as purity, mfgmaster.mfg_no as mfgno, ((mfgstock.mfg_percentinput * mfgstock.mfg_inputwt)/100) as nettwt, mfgmaster.mfg_refno as [Ref No], MFGMASTER.MFG_BRIEF AS Brief, MFGMASTER.MFG_REMARKS AS Remarks, mfgstock.mfg_orderno as orderno, 1 AS VOUCHERNO FROM mfgmaster INNER JOIN mfgstock ON mfgmaster.mfg_no = mfgstock.mfg_no WHERE 1 = 1 " & CONDITION & " union all SELECT (mfgmaster_1.mfg_lotno) AS lotno, mfgmaster_1.MFG_MELTING AS REQPURITY, mfgmaster_1.mfg_date AS date1, 'Part(' & itemstock.item_partno & ')' AS Expr1, ItemMaster.item_name AS name, itemstock.item_grosswt AS gross, IIf(itemstock.item_grosswt<>0,'Completed','') AS process, itemstock.item_purity AS purity, mfgmaster_1.mfg_no AS mfgno, ((itemstock.item_grosswt*itemstock.item_purity)/100) AS nettwt, mfgmaster_1.mfg_refno AS [Ref No], mfgmaster_1.MFG_BRIEF AS Brief, mfgmaster_1.MFG_REMARKS AS Remarks, itemstock.ITEM_orderno AS orderno, IIF( ISNULL( MFGDIRECTISSUE.MFG_VOUCHERID) = TRUE, 0, MFGDIRECTISSUE.MFG_VOUCHERID) AS VOUCHERNO FROM (mfgmaster AS mfgmaster_1 INNER JOIN (itemstock LEFT JOIN ItemMaster ON itemstock.item_id = ItemMaster.item_id) ON mfgmaster_1.mfg_no = itemstock.item_no) LEFT JOIN MFGDIRECTISSUE ON (itemstock.item_partno = MFGDIRECTISSUE.MFG_PARTNO) AND (itemstock.item_no = MFGDIRECTISSUE.MFG_NO) WHERE 1 = 1 " & MFGCONDITION & " order by lotno", tempconn)
        ElseIf RBCOMPLETED.Checked = True Then
            tempcmd = New OleDbCommand("SELECT (mfgmaster_1.mfg_lotno) AS lotno, mfgmaster_1.MFG_MELTING AS REQPURITY, mfgmaster_1.mfg_date AS date1, 'Part(' & itemstock.item_partno & ')' AS Expr1, ItemMaster.item_name AS name, itemstock.item_grosswt AS gross, IIf(itemstock.item_grosswt<>0,'Completed','') AS process, itemstock.item_purity AS purity, mfgmaster_1.mfg_no AS mfgno, ((itemstock.item_grosswt*itemstock.item_purity)/100) AS nettwt, mfgmaster_1.mfg_refno AS [Ref No], mfgmaster_1.MFG_BRIEF AS Brief, mfgmaster_1.MFG_REMARKS AS Remarks, itemstock.ITEM_orderno AS orderno, IIF( ISNULL( MFGDIRECTISSUE.MFG_VOUCHERID) = TRUE, 0, MFGDIRECTISSUE.MFG_VOUCHERID) AS VOUCHERNO FROM (mfgmaster AS mfgmaster_1 INNER JOIN (itemstock LEFT JOIN ItemMaster ON itemstock.item_id = ItemMaster.item_id) ON mfgmaster_1.mfg_no = itemstock.item_no) LEFT JOIN MFGDIRECTISSUE ON (itemstock.item_partno = MFGDIRECTISSUE.MFG_PARTNO) AND (itemstock.item_no = MFGDIRECTISSUE.MFG_NO) WHERE 1 = 1 " & MFGCONDITION & " ORDER BY (mfgmaster_1.mfg_lotno)", tempconn)
        ElseIf RBLOTFAIL.Checked = True Then
            tempcmd = New OleDbCommand("SELECT (mfgmaster.mfg_lotno) as lotno, mfgmaster.mfg_melting as REQPURITY, mfgmaster.mfg_date as date1, 'Part(' & mfgstock.mfg_partno & ')' ,iif(mfgstock.mfg_narration='',mfgstock.mfg_processname,mfgstock.mfg_narration) as name, mfgstock.mfg_inputwt as gross, iif(mfgstock.mfg_lotfail = True, IIF(MFGSTOCK.MFG_MERGED = True, 'MERGED',  'LOT FAIL'),  mfgstock.mfg_processname) as process, mfgstock.mfg_percentinput as purity, mfgmaster.mfg_no as mfgno, ((mfgstock.mfg_percentinput * mfgstock.mfg_inputwt)/100) as nettwt, mfgmaster.mfg_refno as [Ref No], MFGMASTER.MFG_BRIEF AS Brief, MFGMASTER.MFG_REMARKS AS Remarks, mfgstock.mfg_orderno as orderno, 1 AS VOUCHERNO FROM mfgmaster INNER JOIN mfgstock ON mfgmaster.mfg_no = mfgstock.mfg_no WHERE 1 = 1 " & CONDITION & " AND MFGSTOCK.MFG_LOTFAIL = TRUE ORDER BY (mfgmaster.mfg_lotno)", tempconn)
        Else
            tempcmd = New OleDbCommand("SELECT (mfgmaster.mfg_lotno) as lotno, mfgmaster.mfg_melting as REQPURITY, mfgmaster.mfg_date as date1, 'Part(' & mfgstock.mfg_partno & ')' ,iif(mfgstock.mfg_narration='',mfgstock.mfg_processname,mfgstock.mfg_narration) as name, mfgstock.mfg_inputwt as gross, iif(mfgstock.mfg_lotfail = True, IIF(MFGSTOCK.MFG_MERGED = True, 'MERGED',  'LOT FAIL'),  mfgstock.mfg_processname) as process, mfgstock.mfg_percentinput as purity, mfgmaster.mfg_no as mfgno, ((mfgstock.mfg_percentinput * mfgstock.mfg_inputwt)/100) as nettwt, mfgmaster.mfg_refno as [Ref No], MFGMASTER.MFG_BRIEF AS Brief, MFGMASTER.MFG_REMARKS AS Remarks, mfgstock.mfg_orderno as orderno, 1 AS VOUCHERNO FROM mfgmaster INNER JOIN mfgstock ON mfgmaster.mfg_no = mfgstock.mfg_no WHERE 1 = 1 " & CONDITION & " AND MFGSTOCK.MFG_LOTFAIL = FALSE ORDER BY (mfgmaster.mfg_lotno)", tempconn)
        End If
        da = New OleDbDataAdapter(tempcmd)
        da.Fill(dt)

        gridmfg.DataSource = dt

        gridmfg.Columns(0).HeaderText = "Lot No"
        gridmfg.Columns(0).Width = 70
        gridmfg.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        gridmfg.Columns(1).HeaderText = "Req Pur"
        gridmfg.Columns(1).Width = 75
        gridmfg.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        gridmfg.Columns(1).DefaultCellStyle.Format = "N2"

        gridmfg.Columns(2).HeaderText = "Date"
        gridmfg.Columns(2).Width = 70
        gridmfg.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

        gridmfg.Columns(3).HeaderText = "Part"
        gridmfg.Columns(3).Width = 60
        gridmfg.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

        gridmfg.Columns(4).HeaderText = "Name"
        gridmfg.Columns(4).Width = 130
        gridmfg.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

        gridmfg.Columns(5).HeaderText = "Gross Wt"
        gridmfg.Columns(5).Width = 85
        gridmfg.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        gridmfg.Columns(5).DefaultCellStyle.Format = "N3"

        gridmfg.Columns(6).HeaderText = "Process Name"
        gridmfg.Columns(6).Width = 120
        gridmfg.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

        gridmfg.Columns(7).HeaderText = "Purity"
        gridmfg.Columns(7).Width = 60
        gridmfg.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        gridmfg.Columns(7).DefaultCellStyle.Format = "N2"

        gridmfg.Columns(8).HeaderText = "Mfg No"
        gridmfg.Columns(8).Width = 60
        gridmfg.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        gridmfg.Columns(9).HeaderText = "Fine Wt"
        gridmfg.Columns(9).Width = 85
        gridmfg.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        gridmfg.Columns(9).DefaultCellStyle.Format = "N3"

        gridmfg.Columns(10).HeaderText = "Ref No"
        gridmfg.Columns(10).Width = 100
        gridmfg.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft


        gridmfg.Columns(11).HeaderText = "Brief"
        gridmfg.Columns(11).Width = 265
        gridmfg.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

        gridmfg.Columns(12).HeaderText = "Remarks"
        gridmfg.Columns(12).Width = 600
        gridmfg.Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

        gridmfg.Columns(13).HeaderText = "Order No"
        gridmfg.Columns(13).Width = 80
        gridmfg.Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        
        gridmfg.Columns(14).Visible = False

        If IsDBNull(dt.Compute("SUM(GROSS)", "")) = False Then TXTTOTAL.Text = Format(Val(dt.Compute("SUM(GROSS)", "")), "0.000")
        If IsDBNull(dt.Compute("SUM(NETTWT)", "")) = False Then TXTTOTALNETT.Text = Format(Val(dt.Compute("SUM(NETTWT)", "")), "0.000")
        If IsDBNull(dt.Compute("COUNT(LOTNO)", "")) = False Then TXTTOTALLOTS.Text = Format(Val(dt.Compute("COUNT(LOTNO)", "")), "0.000")

        If RBCOMPLETED.Checked = True Then
            For Each ROW As DataGridViewRow In gridmfg.Rows
                If Val(ROW.Cells("VOUCHERNO").Value) = 0 Then ROW.DefaultCellStyle.BackColor = Color.Yellow
            Next
        End If

        'If gridmfg.RowCount > 15 Then gridmfg.FirstDisplayedScrollingRowIndex = gridmfg.RowCount

        da.Dispose()
        dt.Dispose()
        tempconn.Close()
        tempcmd.Dispose()

    End Sub

    Private Sub txtname_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtname.Validated
        Dim rowno, b As Integer

        If cmbselect.Text.Trim <> "" Then

            fillgrid()

            rowno = 0
            For b = 1 To gridmfg.RowCount

                If cmbselect.Text.Trim = "Lot No." Then
                    txttempname.Text = gridmfg.Item(0, rowno).Value.ToString()
                ElseIf cmbselect.Text.Trim = "Ref No" Then
                    txttempname.Text = gridmfg.Item(10, rowno).Value.ToString()
                ElseIf cmbselect.Text.Trim = "Name" Then
                    txttempname.Text = gridmfg.Item(4, rowno).Value.ToString()
                ElseIf cmbselect.Text.Trim = "Process" Then
                    txttempname.Text = gridmfg.Item(6, rowno).Value.ToString()
                ElseIf cmbselect.Text.Trim = "Purity" Then
                    txttempname.Text = gridmfg.Item(7, rowno).Value.ToString()
                ElseIf cmbselect.Text.Trim = "Mfg No." Then
                    txttempname.Text = gridmfg.Item(8, rowno).Value.ToString()
                End If
                txttempname.SelectionStart = 0
                txttempname.SelectionLength = txtname.TextLength
                If LCase(txtname.Text.Trim) <> LCase(txttempname.SelectedText.Trim) Then
                    gridmfg.Rows.RemoveAt(rowno)
                Else
                    rowno = rowno + 1
                End If

            Next
        ElseIf cmbselect.Text.Trim = "" Then
            fillgrid()
        End If
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click

        If gridmfg.Item(0, gridmfg.CurrentRow.Index).Value <> Nothing Then
            

            If USEREDIT = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If



            If (chldmfgmaster.IsMdiChild = False) Then
                If chldmfgmaster.IsDisposed = True Then
                    chldmfgmaster = New Manufacturing
                End If
                chldmfgmaster.MdiParent = MDIMain
                chldmfgmaster.cmdedit.Enabled = False
                'chldmfgmaster.cmbpart.Text = temppartno
                chldmfgmaster.EDIT = True
                tempmfgno = gridmfg.Item(8, gridmfg.CurrentRow.Index).Value
                temppartno = gridmfg.Item(3, gridmfg.CurrentRow.Index).Value
                chldmfgmaster.Show()
            Else
                chldmfgmaster.BringToFront()
            End If
            Me.Close()

        End If

    End Sub

    Private Sub gridmfg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridmfg.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then cmdok_Click(sender, e)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub RBALL_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBALL.CheckedChanged
        fillgrid()
    End Sub

    Private Sub RBCOMPLETED_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBCOMPLETED.CheckedChanged
        fillgrid()
    End Sub

    Private Sub dtpto_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpto.Validated
        Try
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try
            Dim CONDITION As String = ""
            Dim MFGCONDITION As String = ""
            Dim PERIOD As String = ""

            dt = New DataTable()
            If tempconn.State = ConnectionState.Open Then tempconn.Close()
            tempconn.Open()
            If chkdate.CheckState = CheckState.Checked Then
                CONDITION = CONDITION & " AND mfgmaster.mfg_date >= #" & Format(dtpfrom.Value.Date, "MM/dd/yyyy") & "# AND mfgmaster.mfg_date <=# " & Format(dtpto.Value.Date, "MM/dd/yyyy") & "#"
                MFGCONDITION = MFGCONDITION & " AND mfgmaster_1.mfg_date >= #" & Format(dtpfrom.Value.Date, "MM/dd/yyyy") & "# AND mfgmaster_1.mfg_date <=# " & Format(dtpto.Value.Date, "MM/dd/yyyy") & "#"
                PERIOD = Format(dtpfrom.Value.Date, "dd/MM/yyyy") & " To " & Format(dtpto.Value.Date, "dd/MM/yyyy")
            Else
                PERIOD = Format(startdate, "dd/MM/yyyy") & " To " & Format(enddate, "dd/MM/yyyy")
            End If
            If RBALL.Checked = True Then
                tempcmd = New OleDbCommand("SELECT (mfgmaster.mfg_lotno) as lotno, mfgmaster.mfg_melting as REQPURITY, mfgmaster.mfg_date as date1, 'Part(' & mfgstock.mfg_partno & ')' AS PARTNO ,iif(mfgstock.mfg_narration='',mfgstock.mfg_processname,mfgstock.mfg_narration) as name, mfgstock.mfg_inputwt as gross, iif(mfgstock.mfg_lotfail = True, 'Lot Fail',  mfgstock.mfg_processname) as process, mfgstock.mfg_percentinput as purity, mfgmaster.mfg_no as mfgno, MFGMASTER.MFG_BRIEF AS Brief, MFGMASTER.MFG_REMARKS AS Remarks, ((mfgstock.mfg_percentinput * mfgstock.mfg_inputwt)/100) as nettwt, MFGMASTER.MFG_refno as [Ref No], mfgstock.mfg_orderno as [ORDERNO] FROM mfgmaster INNER JOIN mfgstock ON mfgmaster.mfg_no = mfgstock.mfg_no WHERE 1 = 1 " & CONDITION & " union all SELECT mfgmaster_1.mfg_lotno AS lotno, MFGMASTER_1.MFG_MELTING AS REQMELTING, mfgmaster_1.mfg_date AS date1 , 'Part(' & itemstock.item_partno & ')', ItemMaster.item_name AS name, itemstock.item_grosswt AS gross, IIf(itemstock.item_grosswt<>0,'Completed','') AS process, itemstock.item_purity AS purity, mfgmaster_1.mfg_no AS mfgno, MFGMASTER_1.MFG_BRIEF AS Brief, MFGMASTER_1.MFG_REMARKS AS Remarks, ((itemstock.item_grosswt*itemstock.item_purity)/100) as nettwt, MFGMASTER_1.MFG_refno as [Ref No], itemstock.item_orderno as [ORDERNO] FROM mfgmaster AS mfgmaster_1 INNER JOIN (itemstock LEFT JOIN ItemMaster ON itemstock.item_id = ItemMaster.item_id) ON mfgmaster_1.mfg_no = itemstock.item_no WHERE 1 = 1 " & MFGCONDITION & " order by lotno", tempconn)
            ElseIf RBCOMPLETED.Checked = True Then
                tempcmd = New OleDbCommand("SELECT (mfgmaster_1.mfg_lotno) AS lotno, MFGMASTER_1.MFG_MELTING AS REQPURITY, mfgmaster_1.mfg_date AS date1, 'Part(' & itemstock.item_partno & ')' AS PARTNO, ItemMaster.item_name AS name, itemstock.item_grosswt AS gross, IIf(itemstock.item_grosswt<>0,'Completed','') AS process, itemstock.item_purity AS purity, mfgmaster_1.mfg_no AS mfgno,  MFGMASTER_1.MFG_BRIEF AS Brief, MFGMASTER_1.MFG_REMARKS AS Remarks, ((itemstock.item_grosswt * itemstock.item_purity)/100) as nettwt, MFGMASTER_1.MFG_refno as [Ref No], itemstock.item_orderno as [ORDERNO] FROM mfgmaster AS mfgmaster_1 INNER JOIN (itemstock LEFT JOIN ItemMaster ON itemstock.item_id = ItemMaster.item_id) ON mfgmaster_1.mfg_no = itemstock.item_no WHERE 1 = 1 " & MFGCONDITION & " ORDER BY (mfgmaster_1.mfg_lotno)", tempconn)
            ElseIf RBLOTFAIL.Checked = True Then
                tempcmd = New OleDbCommand("SELECT (mfgmaster.mfg_lotno) as lotno, mfgmaster.mfg_melting as REQPURITY, mfgmaster.mfg_date as date1, 'Part(' & mfgstock.mfg_partno & ')' AS PARTNO,iif(mfgstock.mfg_narration='',mfgstock.mfg_processname,mfgstock.mfg_narration) as name, mfgstock.mfg_inputwt as gross, iif(mfgstock.mfg_lotfail = True, 'Lot Fail',  mfgstock.mfg_processname) as process, mfgstock.mfg_percentinput as purity, mfgmaster.mfg_no as mfgno, MFGMASTER.MFG_BRIEF AS Brief, MFGMASTER.MFG_REMARKS AS Remarks, ((mfgstock.mfg_percentinput * mfgstock.mfg_inputwt)/100) as nettwt, MFGMASTER.MFG_refno as [Ref No], mfgstock.mfg_orderno as [ORDERNO] FROM mfgmaster INNER JOIN mfgstock ON mfgmaster.mfg_no = mfgstock.mfg_no WHERE 1 = 1 " & CONDITION & " AND MFGSTOCK.MFG_LOTFAIL = TRUE ORDER BY (mfgmaster.mfg_lotno)", tempconn)
            Else
                tempcmd = New OleDbCommand("SELECT (mfgmaster.mfg_lotno) as lotno, mfgmaster.mfg_melting as REQPURITY, mfgmaster.mfg_date as date1, 'Part(' & mfgstock.mfg_partno & ')' AS PARTNO,iif(mfgstock.mfg_narration='',mfgstock.mfg_processname,mfgstock.mfg_narration) as name, mfgstock.mfg_inputwt as gross, iif(mfgstock.mfg_lotfail = True, 'Lot Fail',  mfgstock.mfg_processname) as process, mfgstock.mfg_percentinput as purity, mfgmaster.mfg_no as mfgno, MFGMASTER.MFG_BRIEF AS Brief, MFGMASTER.MFG_REMARKS AS Remarks, ((mfgstock.mfg_percentinput * mfgstock.mfg_inputwt)/100) as nettwt, MFGMASTER.MFG_refno as [Ref No], mfgstock.mfg_orderno as [ORDERNO] FROM mfgmaster INNER JOIN mfgstock ON mfgmaster.mfg_no = mfgstock.mfg_no WHERE 1 = 1 " & CONDITION & " AND MFGSTOCK.MFG_LOTFAIL = FALSE ORDER BY (mfgmaster.mfg_lotno)", tempconn)
            End If
            da = New OleDbDataAdapter(tempcmd)
            da.Fill(dt)

            tempconn.Close()
            da.Dispose()

            If dt.Rows.Count = 0 Then
                MsgBox("No Records In Manufacturing Process", MsgBoxStyle.Critical, "Magic Gold")
                Exit Sub
            End If
            Dim objrep As New clsReportDesigner("Pending Lot", System.AppDomain.CurrentDomain.BaseDirectory & "Pending Lot.xlsx", 2)
            objrep.PENDINGLOT_REPORT_EXCEL(dt, PERIOD)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub RBLOTFAIL_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBLOTFAIL.CheckedChanged
        fillgrid()
    End Sub

    Private Sub TXTBARCODE_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTBARCODE.TextChanged
        Try
            If TXTBARCODE.Text.Trim.Length > 0 Then

                dt = New DataTable
                If tempconn.State = ConnectionState.Open Then
                    tempconn.Close()
                End If
                tempconn.Open()

                tempcmd = New OleDbCommand("SELECT MFG_NO AS MFGNO, MFG_PARTNO AS PARTNO FROM MFGBARCODE WHERE MFG_BARCODE = '" & TXTBARCODE.Text.Trim & "'", tempconn)
                da = New OleDbDataAdapter(tempcmd)
                da.Fill(dt)

                If dt.Rows.Count > 0 Then
                    tempmfgno = Val(dt.Rows(0).Item("MFGNO"))
                    temppartno = "Part(" & Val(dt.Rows(0).Item("PARTNO")) & ")"

                    If (chldmfgmaster.IsMdiChild = False) Then
                        If chldmfgmaster.IsDisposed = True Then
                            chldmfgmaster = New Manufacturing
                        End If
                        chldmfgmaster.MdiParent = MDIMain
                        chldmfgmaster.cmdedit.Enabled = False
                        chldmfgmaster.EDIT = True
                        chldmfgmaster.Show()
                    Else
                        chldmfgmaster.BringToFront()
                    End If
                    TXTBARCODE.Clear()
                End If
            End If


        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class