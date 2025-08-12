
Imports System.Data.OleDb

Public Class dailykhata

    Dim m_EditingRow As Integer = -1
    Dim types As String
    Dim nchng As Integer
    Dim item As Integer
    Dim nos As Integer
    Public ledgeradd As Boolean
    Public clk As Boolean

    'FOR CHANGING DAILYKHATA DATE
    Public CHANGEDDATE As Date
    Public CHANGED As Boolean = False
    Dim EDIT As Boolean = False
    Dim TEMPBILLNO As Integer = 0

    Private Sub dailykhata_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Alt = True And e.KeyCode = Windows.Forms.Keys.D Then       'for DELETE
            DELETEENTRY(sender, e)
        ElseIf (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            Me.Close()
        ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.Left Then       'for DELETE
            Call toolprevious_Click(sender, e)
        ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.Right Then       'for DELETE
            Call toolnext_Click(sender, e)
        ElseIf e.KeyCode = Windows.Forms.Keys.F5 And e.Alt = True Then       'for DELETE
            Call dailykhata_Shown(sender, e)
        ElseIf e.Control = True And e.KeyCode = Keys.N Then
            clear()
            GRIDDESCRIPTION.RowCount = 1
            cmbtype.Enabled = True
            cmbcode.Enabled = True
            If chkname.Checked <> True Then
                cmbcode.Text = ""
            End If
            cmbtype.SelectedIndex = (0)
            cmbtype.Focus()
        End If
    End Sub

    Private Sub dailykhata_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dtpfrom.Enabled = False
        dtpto.Enabled = False
        If cmbcode.Text.Trim = "" Then fillname(Me, cmbcode, "")
    End Sub

    Private Sub dailykhata_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

        ''If ClientName = "CNC" Then
        ''    DGFINEWT.ReadOnly = True
        ''End If

        clear()
        enabilityfalse()

        lblbalcfamtissue.Text = "0.00"
        lblbalcfgrosswtissue.Text = "0.000"
        lblbalcfamtjama.Text = "0.00"
        lblbalcfgrosswtjama.Text = "0.000"
        lblbalbfamtissue.Text = "0.00"
        lblbalbfgrosswtissue.Text = "0.000"
        lblbalbfamtjama.Text = "0.00"
        lblbalbfgrosswtjama.Text = "0.000"
        lblbalbfnettwtissue.Text = "0.000"
        lblbalbfnettwtjama.Text = "0.000"
        lblbalcfnettwtissue.Text = "0.000"
        lblbalcfnettwtjama.Text = "0.000"
        'dtpickerkhata.Value = Now.Date

        If item <> 1 Then
            fillitem()
            item = 1
        End If

        fillbal()

        If ClientName = "BHARAT" Then
            fillcmb(CMBPROCESS, "Process_name", "processmaster", "")
            LBLPROCESS.Visible = True
            CMBPROCESS.Visible = True
        End If

        openingbal()
        fillissue()
        filljama()
        totalofgrid()
        closingbalance()
        GRIDDESCRIPTION.RowCount = 1

        If ClientName = "MONOGRAM" Or ClientName = "ORIENTAL" Then
            dggrosswt.Visible = False
            DGLESSWT.Visible = False
            DGNETTWT.Visible = False
            dgpurity.Visible = False
            dgwastage.Visible = False
            DGFINEWT.Visible = False
            dglabour.Visible = False
            dgpieces.Visible = False
            dgBullion.Visible = False
        End If

        'If account = True Then
        '    chkname.Checked = True
        'End If

        'gridjama.CurrentCell = gridjama.Rows(gridjama.RowCount - 1).Cells(1)

    End Sub

    Sub fillbal()

        Dim WHERECLAUSE As String = ""
        Dim GROUPBYCLAUSE As String = ""
        If USERDEPARTMENT <> "" Then WHERECLAUSE = WHERECLAUSE & " AND ACCOUNTMAST.DEPARTMENT = '" & USERDEPARTMENT & "'"
        If USERDEPARTMENT <> "" Then GROUPBYCLAUSE = GROUPBYCLAUSE & ", ACCOUNTMAST.DEPARTMENT "
        If chkdate.Checked = False Then

            dt = New DataTable()
            If tempconn.State = ConnectionState.Open Then
                tempconn.Close()
            End If
            tempconn.Open()
            'IF U DO NOT WANT TO SHOW LEDGERS WITH 0 BAL THEN OPEN THIS CODE
            'tempcmd = New OleDbCommand("SELECT trialbalance.code, Sum(trialbalance.nettwt) AS BalWt, Sum(trialbalance.amount) AS BalAmt  FROM(TrialBalance) GROUP BY trialbalance.code having (Sum(trialbalance.nettwt) <> 0 or Sum(trialbalance.amount)<> 0) ", tempconn)

            'THIS CODE GIVES WRONG BALANCE SO COMMENTED BY GULKIT
            'tempcmd = New OleDbCommand("SELECT trialbalance.code,  Sum(trialbalance.grosswt) AS GROSSWT, Sum(trialbalance.nettwt) AS BalWt, Sum(trialbalance.amount) AS BalAmt  FROM(TrialBalance) GROUP BY trialbalance.code ", tempconn)

            'actual code
            'done by gulkit, this code does not fetch openingbalance
            'tempcmd = New OleDbCommand("SELECT CODE, SUM(GROSSDR) - SUM(GROSSCR) AS GROSSWT, SUM(DR) - SUM(CR) AS BALWT, SUM(AMTDR) - SUM(AMTCR) AS BALAMT FROM (SELECT ACCOUNT_LEDGERCODE AS CODE, SUM(ACCOUNT_GROSSWT) AS GROSSDR, 0 AS GROSSCR, SUM(ACCOUNT_NETTWT) AS DR, 0 AS CR, SUM(ACCOUNT_AMOUNT) AS AMTDR, 0 AS AMTCR FROM ACCOUNTMAST WHERE ACCOUNT_BALORJAMAORPAID= 'Jama' " & WHERECLAUSE & " GROUP BY ACCOUNT_LEDGERCODE " & GROUPBYCLAUSE & " UNION ALL SELECT ACCOUNT_LEDGERCODE AS CODE, 0 AS GROSSDR, SUM(ACCOUNT_GROSSWT) AS GROSSCR, 0 AS DR, SUM(ACCOUNT_NETTWT) AS CR, 0 AS AMTDR, SUM(ACCOUNT_AMOUNT) AS AMTCR FROM ACCOUNTMAST WHERE ACCOUNT_BALORJAMAORPAID = 'Balance' " & WHERECLAUSE & " GROUP BY ACCOUNT_LEDGERCODE " & GROUPBYCLAUSE & ") AS T GROUP BY CODE", tempconn)
            'ADDED PCS IN LAST COLUMN
            tempcmd = New OleDbCommand("SELECT CODE, SUM(GROSSDR) - SUM(GROSSCR) AS GROSSWT, SUM(DR) - SUM(CR) AS BALWT, SUM(AMTDR) - SUM(AMTCR) AS BALAMT, SUM(PCSDR) - SUM(PCSCR) AS BALPCS FROM (SELECT ACCOUNT_LEDGERCODE AS CODE, SUM(ACCOUNT_GROSSWT) AS GROSSDR, 0 AS GROSSCR, SUM(ACCOUNT_NETTWT) AS DR, 0 AS CR, SUM(ACCOUNT_AMOUNT) AS AMTDR, 0 AS AMTCR, SUM(ACCOUNT_PIECES) AS PCSDR, 0 AS PCSCR FROM ACCOUNTMAST WHERE ACCOUNT_BALORJAMAORPAID= 'Jama' " & WHERECLAUSE & " GROUP BY ACCOUNT_LEDGERCODE " & GROUPBYCLAUSE & " UNION ALL SELECT LEDGER_CODE AS CODE, ROUND(LEDGER_OPBALGROSSWT,3) AS GROSSDR, 0 AS GROSSCR, 0 AS DR, 0 AS CR, 0 AS AMTDR, 0 AS AMTCR, 0 AS PCSDR, 0 AS PCSCR FROM LEDGERMASTER WHERE LEDGER_DRCRGROSSWT= 'Cr.' UNION ALL SELECT LEDGER_CODE AS CODE, 0 AS GROSSDR, 0 AS GROSSCR, ROUND(LEDGER_OPBALWT,3) AS DR, 0 AS CR, 0 AS AMTDR, 0 AS AMTCR, 0 AS PCSDR, 0 AS PCSCR FROM LEDGERMASTER WHERE LEDGER_DRCRWT= 'Cr.' UNION ALL SELECT LEDGER_CODE AS CODE, 0 AS GROSSDR, 0 AS GROSSCR, 0 AS DR, 0 AS CR, ROUND(LEDGER_OPBALRS,2) AS AMTDR, 0 AS AMTCR, 0 AS PCSDR, 0 AS PCSCR FROM LEDGERMASTER WHERE LEDGER_DRCRRS= 'Cr.' UNION ALL SELECT LEDGER_CODE AS CODE, 0 AS GROSSDR, ROUND(LEDGER_OPBALGROSSWT,3) AS GROSSCR, 0 AS DR, 0 AS CR, 0 AS AMTDR, 0 AS AMTCR, 0 AS PCSDR, 0 AS PCSCR FROM LEDGERMASTER WHERE LEDGER_DRCRGROSSWT= 'Dr.' UNION ALL SELECT LEDGER_CODE AS CODE, 0 AS GROSSDR, 0 AS GROSSCR, 0 AS DR, ROUND(LEDGER_OPBALWT,3) AS CR, 0 AS AMTDR, 0 AS AMTCR, 0 AS PCSDR, 0 AS PCSCR FROM LEDGERMASTER WHERE LEDGER_DRCRWT= 'Dr.' UNION ALL SELECT LEDGER_CODE AS CODE, 0 AS GROSSDR, 0 AS GROSSCR, 0 AS DR, 0 AS CR, 0 AS AMTDR, ROUND(LEDGER_OPBALRS,2) AS AMTCR, 0 AS PCSDR, 0 AS PCSCR FROM LEDGERMASTER WHERE LEDGER_DRCRRS= 'Dr.' UNION ALL SELECT ACCOUNT_LEDGERCODE AS CODE, 0 AS GROSSDR, SUM(ACCOUNT_GROSSWT) AS GROSSCR, 0 AS DR, SUM(ACCOUNT_NETTWT) AS CR, 0 AS AMTDR, SUM(ACCOUNT_AMOUNT) AS AMTCR, 0 AS PCSDR, SUM(ACCOUNT_PIECES)  AS PCSCR FROM ACCOUNTMAST WHERE ACCOUNT_BALORJAMAORPAID = 'Balance' " & WHERECLAUSE & " GROUP BY ACCOUNT_LEDGERCODE " & GROUPBYCLAUSE & ") AS T GROUP BY CODE", tempconn)

            da = New OleDbDataAdapter(tempcmd)
            da.Fill(dt)
            gridledger.DataSource = dt
            tempconn.Close()
            da.Dispose()
        Else

            dt = New DataTable()
            If tempconn.State = ConnectionState.Open Then
                tempconn.Close()
            End If
            tempconn.Open()

            'IF U DO NOT WANT TO SHOW LEDGERS WITH 0 BAL THEN OPEN THIS CODE
            'tempcmd = New OleDbCommand("SELECT trialbalance.code, Sum(trialbalance.nettwt) AS BalWt, Sum(trialbalance.amount) AS BalAmt  FROM(TrialBalance) GROUP BY trialbalance.code having (Sum(trialbalance.nettwt) <> 0 or Sum(trialbalance.amount)<> 0)  ", tempconn)

            'THIS CODE GIVES WRONG BALANCE SO COMMENTED BY GULKIT
            'tempcmd = New OleDbCommand("SELECT trialbalance.code, Sum(trialbalance.grosswt) AS GROSSWT, Sum(trialbalance.nettwt) AS BalWt, Sum(trialbalance.amount) AS BalAmt  FROM(TrialBalance) GROUP BY trialbalance.code ", tempconn)

            'actual code
            'done by gulkit, this code does not fetch openingbalance
            'tempcmd = New OleDbCommand("SELECT CODE, SUM(GROSSDR) - SUM(GROSSCR) AS GROSSWT, SUM(DR) - SUM(CR) AS BALWT, SUM(AMTDR) - SUM(AMTCR) AS BALAMT FROM ( SELECT ACCOUNT_LEDGERCODE AS CODE, SUM(ACCOUNT_GROSSWT) AS GROSSDR, 0 AS GROSSCR, SUM(ACCOUNT_NETTWT) AS DR, 0 AS CR, SUM(ACCOUNT_AMOUNT) AS AMTDR, 0 AS AMTCR FROM ACCOUNTMAST WHERE ACCOUNT_BALORJAMAORPAID= 'Jama' " & WHERECLAUSE & " AND ACCOUNT_DATE >= #" & Format(dtpfrom.Value.Date, "MM/dd/yyyy") & "# AND ACCOUNT_DATE <= #" & Format(dtpto.Value.Date, "MM/dd/yyyy") & "#  GROUP BY ACCOUNT_LEDGERCODE " & GROUPBYCLAUSE & " UNION ALL SELECT ACCOUNT_LEDGERCODE AS CODE, 0 AS GROSSDR, SUM(ACCOUNT_GROSSWT) AS GROSSCR, 0 AS DR, SUM(ACCOUNT_NETTWT) AS CR, 0 AS AMTDR, SUM(ACCOUNT_AMOUNT) AS AMTCR FROM ACCOUNTMAST WHERE ACCOUNT_BALORJAMAORPAID = 'Balance' " & WHERECLAUSE & " AND ACCOUNT_DATE >= #" & Format(dtpfrom.Value.Date, "MM/dd/yyyy") & "# AND ACCOUNT_DATE <= #" & Format(dtpto.Value.Date, "MM/dd/yyyy") & "#  GROUP BY ACCOUNT_LEDGERCODE " & GROUPBYCLAUSE & ") AS T GROUP BY CODE", tempconn)
            'ADDED PCS IN LAST COLUMN
            tempcmd = New OleDbCommand("SELECT CODE, SUM(GROSSDR) - SUM(GROSSCR) AS GROSSWT, SUM(DR) - SUM(CR) AS BALWT, SUM(AMTDR) - SUM(AMTCR) AS BALAMT, SUM(PCSDR) - SUM(PCSCR) AS BALPCS FROM ( SELECT ACCOUNT_LEDGERCODE AS CODE, SUM(ACCOUNT_GROSSWT) AS GROSSDR, 0 AS GROSSCR, SUM(ACCOUNT_NETTWT) AS DR, 0 AS CR, SUM(ACCOUNT_AMOUNT) AS AMTDR, 0 AS AMTCR, SUM(ACCOUNT_PIECES) AS PCSDR, 0 AS PCSCR FROM ACCOUNTMAST WHERE ACCOUNT_BALORJAMAORPAID= 'Jama' " & WHERECLAUSE & " AND ACCOUNT_DATE >= #" & Format(dtpfrom.Value.Date, "MM/dd/yyyy") & "# AND ACCOUNT_DATE <= #" & Format(dtpto.Value.Date, "MM/dd/yyyy") & "#  GROUP BY ACCOUNT_LEDGERCODE " & GROUPBYCLAUSE & " UNION ALL SELECT LEDGER_CODE AS CODE, ROUND(LEDGER_OPBALGROSSWT,3) AS GROSSDR, 0 AS GROSSCR, 0 AS DR, 0 AS CR, 0 AS AMTDR, 0 AS AMTCR, 0 AS PCSDR, 0 AS PCSCR FROM LEDGERMASTER WHERE LEDGER_DRCRGROSSWT= 'Cr.' UNION ALL SELECT LEDGER_CODE AS CODE, 0 AS GROSSDR, 0 AS GROSSCR, ROUND(LEDGER_OPBALWT,3) AS DR, 0 AS CR, 0 AS AMTDR, 0 AS AMTCR, 0 AS PCSDR, 0 AS PCSCR FROM LEDGERMASTER WHERE LEDGER_DRCRWT= 'Cr.' UNION ALL SELECT LEDGER_CODE AS CODE, 0 AS GROSSDR, 0 AS GROSSCR, 0 AS DR, 0 AS CR, ROUND(LEDGER_OPBALRS,2) AS AMTDR, 0 AS AMTCR, 0 AS PCSDR, 0 AS PCSCR FROM LEDGERMASTER WHERE LEDGER_DRCRRS= 'Cr.' UNION ALL SELECT LEDGER_CODE AS CODE, 0 AS GROSSDR, ROUND(LEDGER_OPBALGROSSWT,3) AS GROSSCR, 0 AS DR, 0 AS CR, 0 AS AMTDR, 0 AS AMTCR, 0 AS PCSDR, 0 AS PCSCR FROM LEDGERMASTER WHERE LEDGER_DRCRGROSSWT= 'Dr.' UNION ALL SELECT LEDGER_CODE AS CODE, 0 AS GROSSDR, 0 AS GROSSCR, 0 AS DR, ROUND(LEDGER_OPBALWT,3) AS CR, 0 AS AMTDR, 0 AS AMTCR, 0 AS PCSDR, 0 AS PCSCR FROM LEDGERMASTER WHERE LEDGER_DRCRWT= 'Dr.' UNION ALL SELECT LEDGER_CODE AS CODE, 0 AS GROSSDR, 0 AS GROSSCR, 0 AS DR, 0 AS CR, 0 AS AMTDR, ROUND(LEDGER_OPBALRS,2) AS AMTCR, 0 AS PCSDR, 0 AS PCSCR FROM LEDGERMASTER WHERE LEDGER_DRCRRS= 'Dr.' UNION ALL SELECT ACCOUNT_LEDGERCODE AS CODE, 0 AS GROSSDR, SUM(ACCOUNT_GROSSWT) AS GROSSCR, 0 AS DR, SUM(ACCOUNT_NETTWT) AS CR, 0 AS AMTDR, SUM(ACCOUNT_AMOUNT) AS AMTCR, 0 AS PCSDR, SUM(ACCOUNT_PIECES)  AS PCSCR FROM ACCOUNTMAST WHERE ACCOUNT_BALORJAMAORPAID = 'Balance' " & WHERECLAUSE & " AND ACCOUNT_DATE >= #" & Format(dtpfrom.Value.Date, "MM/dd/yyyy") & "# AND ACCOUNT_DATE <= #" & Format(dtpto.Value.Date, "MM/dd/yyyy") & "#  GROUP BY ACCOUNT_LEDGERCODE " & GROUPBYCLAUSE & ") AS T GROUP BY CODE", tempconn)

            da = New OleDbDataAdapter(tempcmd)
            da.Fill(dt)
            gridledger.DataSource = dt
            tempconn.Close()
            da.Dispose()
        End If

        'dt = New DataTable()
        'dt.Columns.Add("LEDGERCODE")
        'dt.Columns.Add("GROSSWT")
        'dt.Columns.Add("NETTWT")
        'dt.Columns.Add("AMOUNT")

        'Dim TOTALNETTJAMA, TOTALNETTBAL, TOTALGROSSJAMA, TOTALGROSSBAL, TOTALAMTJAMA, TOTALAMTBAL As Double
        'Dim LEDGERSDT As New DataTable
        'tempcmd = New OleDbCommand("SELECT DISTINCT ACCOUNTMAST.ACCOUNT_LEDGERCODE AS LEDGERCODE FROM ACCOUNTMAST ", tempconn)
        'If tempconn.State = ConnectionState.Open Then tempconn.Close()
        'tempconn.Open()
        'da = New OleDbDataAdapter(tempcmd)
        'da.Fill(LEDGERSDT)

        'For Each DTROW As DataRow In LEDGERSDT.Rows

        '    Dim DTJAMA As New DataTable
        '    Dim DTBAL As New DataTable

        '    TOTALGROSSBAL = 0
        '    TOTALGROSSJAMA = 0
        '    TOTALNETTBAL = 0
        '    TOTALNETTJAMA = 0
        '    TOTALAMTBAL = 0
        '    TOTALAMTJAMA = 0


        '    'ADD OPBAL FROM LEDGERMASTER ALSO IN THE ABOVE VARIABLES
        '    Dim DTOPBAL As New DataTable
        '    Dim DAOP = New OleDbDataAdapter
        '    DTOPBAL.Clear()
        '    tempcmd = New OleDbCommand("SELECT IIF(LEDGER_DRCRWT = 'Cr.', LEDGER_OPBALWT,0) AS OPBALDR, IIF(LEDGER_DRCRWT = 'Dr.', LEDGER_OPBALWT,0) AS OPBALCR FROM LEDGERMASTER WHERE LEDGER_CODE = '" & DTROW("LEDGERCODE") & "'", tempconn)
        '    If tempconn.State = ConnectionState.Open Then tempconn.Close()
        '    tempconn.Open()
        '    DAOP = New OleDbDataAdapter(tempcmd)
        '    DAOP.Fill(DTOPBAL)
        '    If DTOPBAL.Rows.Count > 0 Then
        '        TOTALNETTJAMA += Format(Val(DTOPBAL.Rows(0).Item("OPBALDR")), "0.00")
        '        TOTALNETTBAL += Format(Val(DTOPBAL.Rows(0).Item("OPBALCR")), "0.00")
        '    End If


        '    DTOPBAL.Clear()
        '    tempcmd = New OleDbCommand("SELECT IIF(LEDGER_DRCRRS = 'Cr.', LEDGER_OPBALRS,0) AS OPBALDR, IIF(LEDGER_DRCRRS = 'Dr.', LEDGER_OPBALRS,0) AS OPBALCR FROM LEDGERMASTER WHERE LEDGER_CODE = '" & DTROW("LEDGERCODE") & "'", tempconn)
        '    If tempconn.State = ConnectionState.Open Then tempconn.Close()
        '    tempconn.Open()
        '    DAOP = New OleDbDataAdapter(tempcmd)
        '    DAOP.Fill(DTOPBAL)
        '    If DTOPBAL.Rows.Count > 0 Then
        '        TOTALAMTJAMA += Format(Val(DTOPBAL.Rows(0).Item("OPBALDR")), "0.00")
        '        TOTALAMTBAL += Format(Val(DTOPBAL.Rows(0).Item("OPBALCR")), "0.00")
        '    End If



        '    'FOR EACH LEDGER FETCH THE TOTALBALANCE AND TOTALJAMA, THEN SUBTRACT TO GET THE FINAL BALANCE
        '    tempcmd = New OleDbCommand("SELECT Sum(ACCOUNTMAST.ACCOUNT_GROSSWT) AS GROSSWT, Sum(ACCOUNTMAST.ACCOUNT_NETTWT) AS NETTWT, Sum(ACCOUNTMAST.ACCOUNT_AMOUNT) AS AMOUNT FROM ACCOUNTMAST WHERE ACCOUNTMAST.ACCOUNT_BALORJAMAORPAID = 'Jama' AND ACCOUNTMAST.ACCOUNT_LEDGERCODE = '" & DTROW("LEDGERCODE") & "' GROUP BY ACCOUNTMAST.ACCOUNT_LEDGERCODE ", tempconn)
        '    If tempconn.State = ConnectionState.Open Then tempconn.Close()
        '    tempconn.Open()
        '    Dim DALEDGERS = New OleDbDataAdapter(tempcmd)
        '    DALEDGERS.Fill(DTJAMA)

        '    If DTJAMA.Rows.Count > 0 Then
        '        TOTALGROSSJAMA += Format(Val(DTJAMA.Rows(0).Item("GROSSWT")), "0.000")
        '        TOTALNETTJAMA += Format(Val(DTJAMA.Rows(0).Item("NETTWT")), "0.000")
        '        TOTALAMTJAMA += Format(Val(DTJAMA.Rows(0).Item("AMOUNT")), "0.00")
        '    End If

        '    tempconn.Close()
        '    DALEDGERS.Dispose()
        '    tempcmd.Dispose()


        '    tempcmd = New OleDbCommand("SELECT Sum(ACCOUNTMAST.ACCOUNT_GROSSWT) AS GROSSWT, Sum(ACCOUNTMAST.ACCOUNT_NETTWT) AS NETTWT, Sum(ACCOUNTMAST.ACCOUNT_AMOUNT) AS AMOUNT FROM ACCOUNTMAST WHERE ACCOUNTMAST.ACCOUNT_BALORJAMAORPAID = 'Balance' AND ACCOUNTMAST.ACCOUNT_LEDGERCODE = '" & DTROW("LEDGERCODE") & "' GROUP BY ACCOUNTMAST.ACCOUNT_LEDGERCODE ", tempconn)
        '    If tempconn.State = ConnectionState.Open Then tempconn.Close()
        '    tempconn.Open()
        '    DALEDGERS = New OleDbDataAdapter(tempcmd)
        '    DALEDGERS.Fill(DTBAL)

        '    If DTBAL.Rows.Count > 0 Then
        '        TOTALGROSSBAL += Format(Val(DTBAL.Rows(0).Item("GROSSWT")), "0.000")
        '        TOTALNETTBAL += Format(Val(DTBAL.Rows(0).Item("NETTWT")), "0.000")
        '        TOTALAMTBAL += Format(Val(DTBAL.Rows(0).Item("AMOUNT")), "0.00")
        '    End If

        '    tempconn.Close()
        '    DALEDGERS.Dispose()
        '    tempcmd.Dispose()

        '    dt.Rows.Add(New Object() {DTROW("LEDGERCODE"), Format((TOTALGROSSJAMA - TOTALGROSSBAL), "0.000"), Format((TOTALNETTJAMA - TOTALNETTBAL), "0.000"), Format((TOTALAMTJAMA - TOTALAMTBAL), "0.00")})


        'Next
        'gridledger.DataSource = dt


        'IF U DO NOT WANT TO SHOW LEDGERS WITH 0 BAL THEN OPEN THIS CODE
        'tempcmd = New OleDbCommand("SELECT trialbalance.code, Sum(trialbalance.nettwt) AS BalWt, Sum(trialbalance.amount) AS BalAmt  FROM(TrialBalance) GROUP BY trialbalance.code having (Sum(trialbalance.nettwt) <> 0 or Sum(trialbalance.amount)<> 0)  ", tempconn)




        With gridledger
            .Columns(0).HeaderText = "Ledger"
            .Columns(0).Width = 125

            .Columns(1).HeaderText = "Gross"
            .Columns(1).Width = 95
            .Columns(1).DefaultCellStyle.Format = "0.000"
            .Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            .Columns(2).HeaderText = "Fine Wt."
            .Columns(2).Width = 90
            .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(2).DefaultCellStyle.Format = "0.000"

            .Columns(3).HeaderText = "Bal Amt"
            .Columns(3).Width = 90
            .Columns(3).DefaultCellStyle.Format = "0.000"
            .Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            .Columns(4).HeaderText = "Pcs"
            .Columns(4).Width = 65
            .Columns(4).DefaultCellStyle.Format = "0"
            .Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            If ClientName = "KHUSHALI" Or ClientName = "SHWETA" Then .Columns(4).Visible = True Else .Columns(4).Visible = False

        End With

        tempconn.Close()

    End Sub

    Sub fillitem()

        dt = New DataTable()
        If tempconn.State = ConnectionState.Open Then
            tempconn.Close()
        End If
        tempconn.Open()
        tempcmd = New OleDbCommand("select item_code from itemmaster ORDER  BY ITEM_CODE", tempconn)
        da = New OleDbDataAdapter(tempcmd)
        da.Fill(dt)
        dgcmbitemcode.DataSource = dt
        dgcmbitemcode.DisplayMember = "item_code"
        tempconn.Close()
        da.Dispose()

    End Sub

    Sub enabilityfalse()
        txtnarration.Enabled = False
        cmbtype.Enabled = False
        cmbcode.Enabled = False
        GRIDDESCRIPTION.Enabled = False
        txtbhavcut.Enabled = False
        txtperwt.Enabled = False
        txtpurity.Enabled = False
        txtrate.Enabled = False
        TXTAMOUNT.Enabled = False
        txtcashrec.Enabled = False
        txtbalwt.Enabled = False
        txtbalamt.Enabled = False
    End Sub

    Sub totalofgrid()
        Dim tgrossjama, tnettjama, tamtjama, tgrossissue, tnettissue, tamtissue As Double
        For Each row As DataGridViewRow In gridjama.Rows
            tgrossjama = Val(tgrossjama) + Val(row.Cells(2).Value)
            tnettjama = Val(tnettjama) + Val(row.Cells(3).Value)
            tamtjama = Val(tamtjama) + Val(row.Cells(4).Value)
        Next
        For Each row As DataGridViewRow In gridissue.Rows
            tgrossissue = Val(tgrossissue) + Val(row.Cells(2).Value)
            tnettissue = Val(tnettissue) + Val(row.Cells(3).Value)
            tamtissue = Val(tamtissue) + Val(row.Cells(4).Value)
        Next
        lbltotalgrossjama.Text = Format(tgrossjama, "0.000")
        lbltotalnettjama.Text = Format(tnettjama, "0.000")
        lbltotalamtjama.Text = Format(tamtjama, "0.00")
        lbltotalgrossissue.Text = Format(tgrossissue, "0.000")
        lbltotalnettissue.Text = Format(tnettissue, "0.000")
        lbltotalamtissue.Text = Format(tamtissue, "0.00")
    End Sub

    Sub closingbalance()
        Dim temp
        temp = 0
        If chkname.Checked = False Then
            temp = (Val(lbltotalgrossjama.Text) + Val(lblbalbfgrosswtjama.Text)) - (Val(lbltotalgrossissue.Text) + Val(lblbalbfgrosswtissue.Text))
            If temp <= 0 Then
                lblbalcfgrosswtjama.Text = Format((temp * (-1)), "0.000")
            Else
                lblbalcfgrosswtissue.Text = Format(Val(temp), "0.000")
            End If


            temp = 0
            temp = (Val(lbltotalnettjama.Text) + Val(lblbalbfnettwtjama.Text)) - (Val(lbltotalnettissue.Text) + Val(lblbalbfnettwtissue.Text))
            If temp <= 0 Then
                lblbalcfnettwtjama.Text = Format((temp * (-1)), "0.000")
            Else
                lblbalcfnettwtissue.Text = Format(Val(temp), "0.000")
            End If



            temp = 0
            temp = (Val(lbltotalamtjama.Text) + Val(lblbalbfamtjama.Text)) - (Val(lbltotalamtissue.Text) + Val(lblbalbfamtissue.Text))
            If temp <= 0 Then
                lblbalcfamtjama.Text = Format((temp * (-1)), "0.00")
            Else
                lblbalcfamtissue.Text = Format(temp, "0.00")
            End If

            If Val(lblbalbfgrosswtjama.Text) <> "0" Then
                If Val(lbltotalgrossjama.Text) = "0" And Val(lbltotalgrossissue.Text) = "0" Then lblbalcfgrosswtissue.Text = Format(Val(lblbalbfgrosswtjama.Text), "0.000")
            Else
                If Val(lbltotalgrossjama.Text) = "0" And Val(lbltotalgrossissue.Text) = "0" Then lblbalcfgrosswtjama.Text = Format(Val(lblbalbfgrosswtissue.Text), "0.000")
            End If


            If Val(lblbalbfnettwtjama.Text) <> "0" Then
                If Val(lbltotalnettjama.Text) = "0" And Val(lbltotalnettissue.Text) = "0" Then lblbalcfnettwtissue.Text = Format(Val(lblbalbfnettwtjama.Text), "0.000")
            Else
                If Val(lbltotalnettjama.Text) = "0" And Val(lbltotalnettissue.Text) = "0" Then lblbalcfnettwtjama.Text = Format(Val(lblbalbfnettwtissue.Text), "0.000")
            End If

            If Val(lblbalbfamtjama.Text) <> "0" Then
                If Val(lbltotalamtjama.Text) = "0" And Val(lbltotalamtissue.Text) = "0" Then lblbalcfamtissue.Text = Format(Val(lblbalbfamtjama.Text), "0.00")
            Else
                If Val(lbltotalamtjama.Text) = "0" And Val(lbltotalamtissue.Text) = "0" Then lblbalcfamtjama.Text = Format(Val(lblbalbfamtissue.Text), "0.00")
            End If
        Else
            temp = (Val(lbltotalnettjama.Text) + Val(lblbalbfnettwtjama.Text)) - (Val(lbltotalnettissue.Text) + Val(lblbalbfnettwtissue.Text))
            If temp <= 0 Then
                lblbalcfnettwtjama.Text = Format((temp * (-1)), "0.000")
            Else
                lblbalcfnettwtissue.Text = Format(Val(temp), "0.000")
            End If


            temp = 0
            temp = (Val(lbltotalgrossjama.Text) + Val(lblbalbfgrosswtjama.Text)) - (Val(lbltotalgrossissue.Text) + Val(lblbalbfgrosswtissue.Text))
            If temp <= 0 Then
                lblbalcfgrosswtjama.Text = Format((temp * (-1)), "0.000")
            Else
                lblbalcfgrosswtissue.Text = Format(Val(temp), "0.000")
            End If

            temp = 0
            temp = (Val(lbltotalamtjama.Text) + Val(lblbalbfamtjama.Text)) - (Val(lbltotalamtissue.Text) + Val(lblbalbfamtissue.Text))
            If temp <= 0 Then
                lblbalcfamtjama.Text = Format((temp * (-1)), "0.00")
            Else
                lblbalcfamtissue.Text = Format(temp, "0.00")
            End If



            If Val(lblbalbfnettwtjama.Text) <> "0" Then
                If Val(lbltotalnettjama.Text) = "0" And Val(lbltotalnettissue.Text) = "0" Then lblbalcfnettwtissue.Text = Format(Val(lblbalbfnettwtjama.Text), "0.000")
            Else
                If Val(lbltotalnettjama.Text) = "0" And Val(lbltotalnettissue.Text) = "0" Then lblbalcfnettwtjama.Text = Format(Val(lblbalbfnettwtissue.Text), "0.000")
            End If

            If Val(lblbalbfgrosswtjama.Text) <> "0" Then
                If Val(lbltotalgrossjama.Text) = "0" And Val(lbltotalgrossissue.Text) = "0" Then lblbalcfgrosswtissue.Text = Format(Val(lblbalbfgrosswtjama.Text), "0.000")
            Else
                If Val(lbltotalgrossjama.Text) = "0" And Val(lbltotalgrossissue.Text) = "0" Then lblbalcfgrosswtjama.Text = Format(Val(lblbalbfgrosswtissue.Text), "0.000")
            End If

            If Val(lblbalbfamtjama.Text) <> "0" Then
                If Val(lbltotalamtjama.Text) = "0" And Val(lbltotalamtissue.Text) = "0" Then lblbalcfamtissue.Text = Format(Val(lblbalbfamtjama.Text), "0.00")
            Else
                If Val(lbltotalamtjama.Text) = "0" And Val(lbltotalamtissue.Text) = "0" Then lblbalcfamtjama.Text = Format(Val(lblbalbfamtissue.Text), "0.00")
            End If
        End If
    End Sub

    Sub filljama()

        dt = New DataTable()
        If tempconn.State = ConnectionState.Open Then
            tempconn.Close()
        End If
        tempconn.Open()

        Dim WHERECLAUSE As String = ""
        Dim GROUPBYCLAUSE As String = ""
        If USERDEPARTMENTID <> 0 Then WHERECLAUSE = WHERECLAUSE & " AND accountmaster.ACCOUNT_DEPARTMENTID = " & USERDEPARTMENTID
        If USERDEPARTMENTID <> 0 Then GROUPBYCLAUSE = GROUPBYCLAUSE & ", accountmaster.ACCOUNT_DEPARTMENTID "

        If chkdate.Checked = False Then

            If chkname.Checked = False Then
                'tempcmd = New OleDbCommand("SELECT IIf(accountmaster.account_type='R' Or accountmaster.account_type='I' Or accountmaster.account_type='JV' Or accountmaster.account_type='CASH' Or accountmaster.account_type='SALARY','*','') AS Expr1, accountmaster.account_ledgercode, Sum(accountmaster.account_grosswt) AS SumOfaccount_grosswt, Sum(accountmaster.account_nettwt) AS SumOfaccount_nettwt, Sum(accountmaster.account_amount) AS SumOfaccount_amount, accountmaster.account_type, accountmaster.account_voucherid from ((accountmaster INNER JOIN ledgermaster ON accountmaster.account_ledgerid = ledgermaster.ledger_id) INNER JOIN GROUPMASTER ON LEDGERMASTER.LEDGER_GROUPID = GROUPMASTER.GROUP_ID) where GROUPMASTER.GROUP_NAME <> 'Cash In Hand' AND LEDGERMASTER.LEDGER_NAME <> 'SALARY' AND accountmaster.account_balorjamaorpaid='Jama' and accountmaster.account_date=#" & Format(dtpickerkhata.Value, "MM/dd/yyyy") & "# GROUP BY accountmaster.account_date, IIf(accountmaster.account_type='R' Or accountmaster.account_type='I' Or accountmaster.account_type='JV' Or accountmaster.account_type='CASH' Or accountmaster.account_type='SALARY','*',''), accountmaster.account_ledgercode, accountmaster.account_type, accountmaster.account_voucherid order by accountmaster.account_date, accountmaster.account_type desc ,accountmaster.account_voucherid", tempconn)
                tempcmd = New OleDbCommand("SELECT IIf(accountmaster.account_type='R' Or accountmaster.account_type='I' Or accountmaster.account_type='JV' Or accountmaster.account_type='CASH' Or accountmaster.account_type='SALARY','*','') AS Expr1, accountmaster.account_ledgercode, Sum(accountmaster.account_grosswt) AS SumOfaccount_grosswt, Sum(accountmaster.account_nettwt) AS SumOfaccount_nettwt, Sum(accountmaster.account_amount) AS SumOfaccount_amount, accountmaster.account_type, accountmaster.account_voucherid from ((accountmaster INNER JOIN ledgermaster ON accountmaster.account_ledgerid = ledgermaster.ledger_id) INNER JOIN GROUPMASTER ON LEDGERMASTER.LEDGER_GROUPID = GROUPMASTER.GROUP_ID) where GROUPMASTER.GROUP_NAME <> 'Cash In Hand' AND accountmaster.account_balorjamaorpaid='Jama' " & WHERECLAUSE & " and accountmaster.account_date=#" & Format(dtpickerkhata.Value, "MM/dd/yyyy") & "# GROUP BY accountmaster.account_date, IIf(accountmaster.account_type='R' Or accountmaster.account_type='I' Or accountmaster.account_type='JV' Or accountmaster.account_type='CASH' Or accountmaster.account_type='SALARY','*',''), accountmaster.account_ledgercode, accountmaster.account_type, accountmaster.account_voucherid " & GROUPBYCLAUSE & " order by accountmaster.account_date, accountmaster.account_type ,accountmaster.account_voucherid", tempconn)
            Else
                'gridledger.Item(0, gridledger.CurrentRow.Index).Value
                'tempcmd = New OleDbCommand("select iif(accountmaster.account_type='R' or accountmaster.account_type='I','*',''), accountmaster.account_date,Accountmaster.account_grosswt,accountmaster.account_nettwt,accountmaster.account_amount,accountmaster.account_type,accountmaster.account_voucherid from accountmaster where accountmaster.account_balorjamaorpaid='Jama' and  accountmaster.account_ledgercode='" & tempname & "'   order by accountmaster.account_type desc ,accountmaster.account_voucherid", tempconn)
                'tempcmd = New OleDbCommand("SELECT IIf(accountmaster.account_type='R' Or accountmaster.account_type='I' Or accountmaster.account_type='JV' Or accountmaster.account_type='CASH' Or accountmaster.account_type='SALARY','*','') AS Expr1, accountmaster.account_date, Sum(accountmaster.account_grosswt) AS SumOfaccount_grosswt, Sum(accountmaster.account_nettwt) AS SumOfaccount_nettwt, Sum(accountmaster.account_amount) AS SumOfaccount_amount, accountmaster.account_type, accountmaster.account_voucherid FROM ((accountmaster INNER JOIN ledgermaster ON accountmaster.account_ledgerid = ledgermaster.ledger_id) INNER JOIN GROUPMASTER ON LEDGERMASTER.LEDGER_GROUPID = GROUPMASTER.GROUP_ID) WHERE GROUPMASTER.GROUP_NAME <> 'Cash In Hand' AND LEDGERMASTER.LEDGER_NAME <> 'SALARY' AND (((accountmaster.account_balorjamaorpaid)='Jama') AND ((accountmaster.account_ledgercode)='" & tempname & "')) and accountmaster.account_date>ledgermaster.ledger_settlement GROUP BY accountmaster.account_date, accountmaster.account_type, accountmaster.account_voucherid ORDER BY accountmaster.account_date, accountmaster.account_type DESC , accountmaster.account_voucherid", tempconn)
                tempcmd = New OleDbCommand("SELECT IIf(accountmaster.account_type='R' Or accountmaster.account_type='I' Or accountmaster.account_type='JV' Or accountmaster.account_type='CASH' Or accountmaster.account_type='SALARY','*','') AS Expr1, accountmaster.account_date, Sum(accountmaster.account_grosswt) AS SumOfaccount_grosswt, Sum(accountmaster.account_nettwt) AS SumOfaccount_nettwt, Sum(accountmaster.account_amount) AS SumOfaccount_amount, accountmaster.account_type, accountmaster.account_voucherid FROM ((accountmaster INNER JOIN ledgermaster ON accountmaster.account_ledgerid = ledgermaster.ledger_id) INNER JOIN GROUPMASTER ON LEDGERMASTER.LEDGER_GROUPID = GROUPMASTER.GROUP_ID) WHERE GROUPMASTER.GROUP_NAME <> 'Cash In Hand' AND (((accountmaster.account_balorjamaorpaid)='Jama')  " & WHERECLAUSE & " AND ((accountmaster.account_ledgercode)='" & tempname & "')) and accountmaster.account_date>ledgermaster.ledger_settlement GROUP BY accountmaster.account_date, accountmaster.account_type, accountmaster.account_voucherid " & GROUPBYCLAUSE & "  ORDER BY accountmaster.account_date, accountmaster.account_type , accountmaster.account_voucherid", tempconn)
            End If
        Else
            If chkname.Checked = False Then
                'tempcmd = New OleDbCommand("SELECT IIf(accountmaster.account_type='R' Or accountmaster.account_type='I' Or accountmaster.account_type='JV' Or accountmaster.account_type='CASH' Or accountmaster.account_type='SALARY','*','') AS Expr1, accountmaster.account_ledgercode, Sum(accountmaster.account_grosswt) AS SumOfaccount_grosswt, Sum(accountmaster.account_nettwt) AS SumOfaccount_nettwt, Sum(accountmaster.account_amount) AS SumOfaccount_amount, accountmaster.account_type, accountmaster.account_voucherid from ((accountmaster INNER JOIN ledgermaster ON accountmaster.account_ledgerid = ledgermaster.ledger_id) INNER JOIN GROUPMASTER ON LEDGERMASTER.LEDGER_GROUPID = GROUPMASTER.GROUP_ID) where GROUPMASTER.GROUP_NAME <> 'Cash In Hand' AND LEDGERMASTER.LEDGER_NAME <> 'SALARY' AND accountmaster.account_balorjamaorpaid='Jama' and accountmaster.account_date between #" & Format(dtpfrom.Value, "MM/dd/yyyy") & "# and #" & Format(dtpto.Value, "MM/dd/yyyy") & "# GROUP BY accountmaster.account_date, accountmaster.account_ledgercode, accountmaster.account_type, accountmaster.account_voucherid order by accountmaster.account_date, accountmaster.account_type desc ,accountmaster.account_voucherid", tempconn)
                tempcmd = New OleDbCommand("SELECT IIf(accountmaster.account_type='R' Or accountmaster.account_type='I' Or accountmaster.account_type='JV' Or accountmaster.account_type='CASH' Or accountmaster.account_type='SALARY','*','') AS Expr1, accountmaster.account_ledgercode, Sum(accountmaster.account_grosswt) AS SumOfaccount_grosswt, Sum(accountmaster.account_nettwt) AS SumOfaccount_nettwt, Sum(accountmaster.account_amount) AS SumOfaccount_amount, accountmaster.account_type, accountmaster.account_voucherid from ((accountmaster INNER JOIN ledgermaster ON accountmaster.account_ledgerid = ledgermaster.ledger_id) INNER JOIN GROUPMASTER ON LEDGERMASTER.LEDGER_GROUPID = GROUPMASTER.GROUP_ID) where GROUPMASTER.GROUP_NAME <> 'Cash In Hand' AND accountmaster.account_balorjamaorpaid='Jama'  " & WHERECLAUSE & " and accountmaster.account_date between #" & Format(dtpfrom.Value, "MM/dd/yyyy") & "# and #" & Format(dtpto.Value, "MM/dd/yyyy") & "# GROUP BY accountmaster.account_date, accountmaster.account_ledgercode, accountmaster.account_type, accountmaster.account_voucherid  " & GROUPBYCLAUSE & " order by accountmaster.account_date, accountmaster.account_type ,accountmaster.account_voucherid ", tempconn)
            Else
                'gridledger.Item(0, gridledger.CurrentRow.Index).Value
                'tempcmd = New OleDbCommand("select iif(accountmaster.account_type='R' or accountmaster.account_type='I','*',''), accountmaster.account_date,Accountmaster.account_grosswt,accountmaster.account_nettwt,accountmaster.account_amount,accountmaster.account_type,accountmaster.account_voucherid from accountmaster where accountmaster.account_balorjamaorpaid='Jama' and  accountmaster.account_ledgercode='" & tempname & "' and accountmaster.account_date between #" & Format(dtpfrom.Value, "MM/dd/yyyy") & "# and #" & Format(dtpto.Value, "MM/dd/yyyy") & "#  order by accountmaster.account_type desc ,accountmaster.account_voucherid", tempconn)
                'tempcmd = New OleDbCommand("SELECT IIf(accountmaster.account_type='R' Or accountmaster.account_type='I' Or accountmaster.account_type='JV' Or accountmaster.account_type='CASH' Or accountmaster.account_type='SALARY','*','') AS Expr1, accountmaster.account_date, Sum(accountmaster.account_grosswt) AS SumOfaccount_grosswt, Sum(accountmaster.account_nettwt) AS SumOfaccount_nettwt, Sum(accountmaster.account_amount) AS SumOfaccount_amount, accountmaster.account_type, accountmaster.account_voucherid FROM ((accountmaster INNER JOIN ledgermaster ON accountmaster.account_ledgerid = ledgermaster.ledger_id) INNER JOIN GROUPMASTER ON LEDGERMASTER.LEDGER_GROUPID = GROUPMASTER.GROUP_ID) where GROUPMASTER.GROUP_NAME <> 'Cash In Hand' AND LEDGERMASTER.LEDGER_NAME <> 'SALARY' AND accountmaster.account_balorjamaorpaid='Jama' and  accountmaster.account_ledgercode='" & tempname & "' and accountmaster.account_date>ledgermaster.ledger_settlement and accountmaster.account_date between #" & Format(dtpfrom.Value, "MM/dd/yyyy") & "# and #" & Format(dtpto.Value, "MM/dd/yyyy") & "# GROUP BY accountmaster.account_date, accountmaster.account_type, accountmaster.account_voucherid order by accountmaster.account_date, accountmaster.account_type desc ,accountmaster.account_voucherid", tempconn)
                tempcmd = New OleDbCommand("SELECT IIf(accountmaster.account_type='R' Or accountmaster.account_type='I' Or accountmaster.account_type='JV' Or accountmaster.account_type='CASH' Or accountmaster.account_type='SALARY','*','') AS Expr1, accountmaster.account_date, Sum(accountmaster.account_grosswt) AS SumOfaccount_grosswt, Sum(accountmaster.account_nettwt) AS SumOfaccount_nettwt, Sum(accountmaster.account_amount) AS SumOfaccount_amount, accountmaster.account_type, accountmaster.account_voucherid FROM ((accountmaster INNER JOIN ledgermaster ON accountmaster.account_ledgerid = ledgermaster.ledger_id) INNER JOIN GROUPMASTER ON LEDGERMASTER.LEDGER_GROUPID = GROUPMASTER.GROUP_ID) where GROUPMASTER.GROUP_NAME <> 'Cash In Hand' AND accountmaster.account_balorjamaorpaid='Jama' " & WHERECLAUSE & " and  accountmaster.account_ledgercode='" & tempname & "' and accountmaster.account_date>ledgermaster.ledger_settlement and accountmaster.account_date between #" & Format(dtpfrom.Value, "MM/dd/yyyy") & "# and #" & Format(dtpto.Value, "MM/dd/yyyy") & "# GROUP BY accountmaster.account_date, accountmaster.account_type, accountmaster.account_voucherid " & GROUPBYCLAUSE & "  order by accountmaster.account_date, accountmaster.account_type ,accountmaster.account_voucherid", tempconn)
            End If
        End If
        da = New OleDbDataAdapter(tempcmd)
        da.Fill(dt)
        gridjama.DataSource = dt
        gridposetting(gridjama)
        If gridjama.RowCount > 0 Then gridjama.FirstDisplayedScrollingRowIndex = gridjama.RowCount - 1
    End Sub

    Sub fillissue()
        dt = New DataTable()
        If tempconn.State = ConnectionState.Open Then
            tempconn.Close()
        End If
        tempconn.Open()

        Dim WHERECLAUSE As String = ""
        Dim GROUPBYCLAUSE As String = ""
        If USERDEPARTMENTID <> 0 Then WHERECLAUSE = WHERECLAUSE & " AND accountmaster.ACCOUNT_DEPARTMENTID = " & USERDEPARTMENTID
        If USERDEPARTMENTID <> 0 Then GROUPBYCLAUSE = GROUPBYCLAUSE & ", accountmaster.ACCOUNT_DEPARTMENTID "


        If chkdate.Checked = False Then
            If chkname.Checked = False Then
                'tempcmd = New OleDbCommand("select iif(accountmaster.account_type='I' or accountmaster.account_type='R' or accountmaster.account_type='JV' or accountmaster.account_type='CASH','*',''), accountmaster.account_ledgercode,Accountmaster.account_grosswt,accountmaster.account_nettwt,accountmaster.account_amount,accountmaster.account_type,accountmaster.account_voucherid from ((accountmaster INNER JOIN ledgermaster ON accountmaster.account_ledgerid = ledgermaster.ledger_id) INNER JOIN GROUPMASTER ON LEDGERMASTER.LEDGER_GROUPID = GROUPMASTER.GROUP_ID) where GROUPMASTER.GROUP_NAME <> 'Cash In Hand' AND  accountmaster.account_balorjamaorpaid='Balance' and accountmaster.account_date=#" & Format(dtpickerkhata.Value, "MM/dd/yyyy") & "#  order by accountmaster.account_date, accountmaster.account_type desc ,accountmaster.account_voucherid", tempconn)
                'tempcmd = New OleDbCommand("SELECT IIf(accountmaster.account_type='I' Or accountmaster.account_type='R' Or accountmaster.account_type='JV' Or accountmaster.account_type='CASH' Or accountmaster.account_type='SALARY','*','') AS Expr1, accountmaster.account_ledgercode, Sum(accountmaster.account_grosswt) AS Expr2, Sum(accountmaster.account_nettwt) AS Expr3, Sum(accountmaster.account_amount) AS Expr4, accountmaster.account_type, accountmaster.account_voucherId from ((accountmaster INNER JOIN ledgermaster ON accountmaster.account_ledgerid = ledgermaster.ledger_id) INNER JOIN GROUPMASTER ON LEDGERMASTER.LEDGER_GROUPID = GROUPMASTER.GROUP_ID) where GROUPMASTER.GROUP_NAME <> 'Cash In Hand' AND LEDGERMASTER.LEDGER_NAME <> 'SALARY' AND  accountmaster.account_balorjamaorpaid='Balance' and accountmaster.account_date=#" & Format(dtpickerkhata.Value, "MM/dd/yyyy") & "# GROUP BY IIf(accountmaster.account_type='I' Or accountmaster.account_type='R' Or accountmaster.account_type='JV' Or accountmaster.account_type='CASH' Or accountmaster.account_type='SALARY','*',''), accountmaster.account_ledgercode, accountmaster.account_type, accountmaster.account_voucherId, accountmaster.account_date, accountmaster.account_type, accountmaster.account_voucherid order by accountmaster.account_date, accountmaster.account_type desc ,accountmaster.account_voucherid", tempconn)
                tempcmd = New OleDbCommand("SELECT IIf(accountmaster.account_type='I' Or accountmaster.account_type='R' Or accountmaster.account_type='JV' Or accountmaster.account_type='CASH' Or accountmaster.account_type='SALARY','*','') AS Expr1, accountmaster.account_ledgercode, Sum(accountmaster.account_grosswt) AS Expr2, Sum(accountmaster.account_nettwt) AS Expr3, Sum(accountmaster.account_amount) AS Expr4, accountmaster.account_type, accountmaster.account_voucherId from ((accountmaster INNER JOIN ledgermaster ON accountmaster.account_ledgerid = ledgermaster.ledger_id) INNER JOIN GROUPMASTER ON LEDGERMASTER.LEDGER_GROUPID = GROUPMASTER.GROUP_ID) where GROUPMASTER.GROUP_NAME <> 'Cash In Hand' AND  accountmaster.account_balorjamaorpaid='Balance' " & WHERECLAUSE & " and accountmaster.account_date=#" & Format(dtpickerkhata.Value, "MM/dd/yyyy") & "# GROUP BY IIf(accountmaster.account_type='I' Or accountmaster.account_type='R' Or accountmaster.account_type='JV' Or accountmaster.account_type='CASH' Or accountmaster.account_type='SALARY','*',''), accountmaster.account_ledgercode, accountmaster.account_type, accountmaster.account_voucherId, accountmaster.account_date, accountmaster.account_type, accountmaster.account_voucherid " & GROUPBYCLAUSE & " order by accountmaster.account_date, accountmaster.account_type desc ,accountmaster.account_voucherid", tempconn)
            Else

                'tempcmd = New OleDbCommand("SELECT IIf(accountmaster.account_type='I' Or accountmaster.account_type='R' Or accountmaster.account_type='JV' Or accountmaster.account_type='CASH' Or accountmaster.account_type='SALARY','*','') AS Expr1, accountmaster.account_date, Sum(accountmaster.account_grosswt) AS SumOfaccount_grosswt, Sum(accountmaster.account_nettwt) AS SumOfaccount_nettwt, Sum(accountmaster.account_amount) AS SumOfaccount_amount, accountmaster.account_type, accountmaster.account_voucherid FROM ((accountmaster INNER JOIN ledgermaster ON accountmaster.account_ledgerid = ledgermaster.ledger_id) INNER JOIN GROUPMASTER ON LEDGERMASTER.LEDGER_GROUPID = GROUPMASTER.GROUP_ID) WHERE GROUPMASTER.GROUP_NAME <> 'Cash In Hand' AND LEDGERMASTER.LEDGER_NAME <> 'SALARY' AND (((accountmaster.account_balorjamaorpaid)='Balance') AND ((accountmaster.account_ledgercode)='" & tempname & "')) and accountmaster.account_date>ledgermaster.ledger_settlement GROUP BY IIf(accountmaster.account_type='I' Or accountmaster.account_type='R' Or accountmaster.account_type='JV' Or accountmaster.account_type='CASH' Or accountmaster.account_type='SALARY','*',''), accountmaster.account_date, accountmaster.account_type, accountmaster.account_voucherid ORDER BY accountmaster.account_date, accountmaster.account_type DESC , accountmaster.account_voucherid", tempconn)
                tempcmd = New OleDbCommand("SELECT IIf(accountmaster.account_type='I' Or accountmaster.account_type='R' Or accountmaster.account_type='JV' Or accountmaster.account_type='CASH' Or accountmaster.account_type='SALARY','*','') AS Expr1, accountmaster.account_date, Sum(accountmaster.account_grosswt) AS SumOfaccount_grosswt, Sum(accountmaster.account_nettwt) AS SumOfaccount_nettwt, Sum(accountmaster.account_amount) AS SumOfaccount_amount, accountmaster.account_type, accountmaster.account_voucherid FROM ((accountmaster INNER JOIN ledgermaster ON accountmaster.account_ledgerid = ledgermaster.ledger_id) INNER JOIN GROUPMASTER ON LEDGERMASTER.LEDGER_GROUPID = GROUPMASTER.GROUP_ID) WHERE GROUPMASTER.GROUP_NAME <> 'Cash In Hand' AND (((accountmaster.account_balorjamaorpaid)='Balance') " & WHERECLAUSE & " AND ((accountmaster.account_ledgercode)='" & tempname & "')) and accountmaster.account_date>ledgermaster.ledger_settlement GROUP BY IIf(accountmaster.account_type='I' Or accountmaster.account_type='R' Or accountmaster.account_type='JV' Or accountmaster.account_type='CASH' Or accountmaster.account_type='SALARY','*',''), accountmaster.account_date, accountmaster.account_type, accountmaster.account_voucherid " & GROUPBYCLAUSE & " ORDER BY accountmaster.account_date, accountmaster.account_type DESC , accountmaster.account_voucherid", tempconn)
                'tempcmd = New OleDbCommand("SELECT IIf(accountmaster.account_type='I' Or accountmaster.account_type='R','*','') , accountmaster.account_date, accountmaster.account_grosswt, accountmaster.account_nettwt, accountmaster.account_amount, accountmaster.account_type, accountmaster.account_voucherid FROM accountmaster INNER JOIN ledgermaster ON accountmaster.account_ledgerid = ledgermaster.ledger_id union all SELECT  Expr1, sdate,  grosswt,  nettwt,  amount,  type,  MFG_NO FROM MFGDK WHERE (((accountmaster.account_balorjamaorpaid)='Balance') AND ((accountmaster.account_ledgercode)='" & tempname & "')) and accountmaster.account_date>ledgermaster.ledger_settlement ORDER BY accountmaster.account_date, accountmaster.account_type DESC , accountmaster.account_voucherid", tempconn)

            End If
        Else
            If chkname.Checked = False Then
                'tempcmd = New OleDbCommand("SELECT IIf(accountmaster.account_type='I' Or accountmaster.account_type='R' Or accountmaster.account_type='JV' Or accountmaster.account_type='CASH' Or accountmaster.account_type='SALARY','*','') AS Expr1, accountmaster.account_ledgercode, Sum(accountmaster.account_grosswt) AS SumOfaccount_grosswt, Sum(accountmaster.account_nettwt) AS SumOfaccount_nettwt, Sum(accountmaster.account_amount) AS SumOfaccount_amount, accountmaster.account_type, accountmaster.account_voucherid from ((accountmaster INNER JOIN ledgermaster ON accountmaster.account_ledgerid = ledgermaster.ledger_id) INNER JOIN GROUPMASTER ON LEDGERMASTER.LEDGER_GROUPID = GROUPMASTER.GROUP_ID) where GROUPMASTER.GROUP_NAME <> 'Cash In Hand' AND LEDGERMASTER.LEDGER_NAME <> 'SALARY' AND accountmaster.account_balorjamaorpaid='Balance' and accountmaster.account_date between #" & Format(dtpfrom.Value, "MM/dd/yyyy") & "# and #" & Format(dtpto.Value, "MM/dd/yyyy") & "# GROUP BY IIf(accountmaster.account_type='I' Or accountmaster.account_type='R' Or accountmaster.account_type='JV' Or accountmaster.account_type='CASH' Or accountmaster.account_type='SALARY','*',''), accountmaster.account_ledgercode, accountmaster.account_type, accountmaster.account_voucherid, accountmaster.account_date, accountmaster.account_type, accountmaster.account_voucherid order by accountmaster.account_date, accountmaster.account_type desc ,accountmaster.account_voucherid", tempconn)
                tempcmd = New OleDbCommand("SELECT IIf(accountmaster.account_type='I' Or accountmaster.account_type='R' Or accountmaster.account_type='JV' Or accountmaster.account_type='CASH' Or accountmaster.account_type='SALARY','*','') AS Expr1, accountmaster.account_ledgercode, Sum(accountmaster.account_grosswt) AS SumOfaccount_grosswt, Sum(accountmaster.account_nettwt) AS SumOfaccount_nettwt, Sum(accountmaster.account_amount) AS SumOfaccount_amount, accountmaster.account_type, accountmaster.account_voucherid from ((accountmaster INNER JOIN ledgermaster ON accountmaster.account_ledgerid = ledgermaster.ledger_id) INNER JOIN GROUPMASTER ON LEDGERMASTER.LEDGER_GROUPID = GROUPMASTER.GROUP_ID) where GROUPMASTER.GROUP_NAME <> 'Cash In Hand' AND accountmaster.account_balorjamaorpaid='Balance' " & WHERECLAUSE & " and accountmaster.account_date between #" & Format(dtpfrom.Value, "MM/dd/yyyy") & "# and #" & Format(dtpto.Value, "MM/dd/yyyy") & "# GROUP BY IIf(accountmaster.account_type='I' Or accountmaster.account_type='R' Or accountmaster.account_type='JV' Or accountmaster.account_type='CASH' Or accountmaster.account_type='SALARY','*',''), accountmaster.account_ledgercode, accountmaster.account_type, accountmaster.account_voucherid, accountmaster.account_date, accountmaster.account_type, accountmaster.account_voucherid " & GROUPBYCLAUSE & " order by accountmaster.account_date, accountmaster.account_type desc ,accountmaster.account_voucherid", tempconn)
            Else
                'tempcmd = New OleDbCommand("SELECT IIf(accountmaster.account_type='I' Or accountmaster.account_type='R' Or accountmaster.account_type='JV' Or accountmaster.account_type='CASH' Or accountmaster.account_type='SALARY','*','') AS Expr1, accountmaster.account_date, Sum(accountmaster.account_grosswt) AS SumOfaccount_grosswt, Sum(accountmaster.account_nettwt) AS SumOfaccount_nettwt, Sum(accountmaster.account_amount) AS SumOfaccount_amount, accountmaster.account_type, accountmaster.account_voucherid FROM ((accountmaster INNER JOIN ledgermaster ON accountmaster.account_ledgerid = ledgermaster.ledger_id) INNER JOIN GROUPMASTER ON LEDGERMASTER.LEDGER_GROUPID = GROUPMASTER.GROUP_ID) where GROUPMASTER.GROUP_NAME <> 'Cash In Hand' AND LEDGERMASTER.LEDGER_NAME <> 'SALARY' AND accountmaster.account_balorjamaorpaid='Balance' and  accountmaster.account_ledgercode='" & tempname & "' and accountmaster.account_date>ledgermaster.ledger_settlement and accountmaster.account_date between #" & Format(dtpfrom.Value, "MM/dd/yyyy") & "# and #" & Format(dtpto.Value, "MM/dd/yyyy") & "# GROUP BY IIf(accountmaster.account_type='I' Or accountmaster.account_type='R' Or accountmaster.account_type='JV' Or accountmaster.account_type='CASH' Or accountmaster.account_type='SALARY','*',''), accountmaster.account_date, accountmaster.account_type, accountmaster.account_voucherid order by accountmaster.account_date, accountmaster.account_type desc ,accountmaster.account_voucherid", tempconn)
                tempcmd = New OleDbCommand("SELECT IIf(accountmaster.account_type='I' Or accountmaster.account_type='R' Or accountmaster.account_type='JV' Or accountmaster.account_type='CASH' Or accountmaster.account_type='SALARY','*','') AS Expr1, accountmaster.account_date, Sum(accountmaster.account_grosswt) AS SumOfaccount_grosswt, Sum(accountmaster.account_nettwt) AS SumOfaccount_nettwt, Sum(accountmaster.account_amount) AS SumOfaccount_amount, accountmaster.account_type, accountmaster.account_voucherid FROM ((accountmaster INNER JOIN ledgermaster ON accountmaster.account_ledgerid = ledgermaster.ledger_id) INNER JOIN GROUPMASTER ON LEDGERMASTER.LEDGER_GROUPID = GROUPMASTER.GROUP_ID) where GROUPMASTER.GROUP_NAME <> 'Cash In Hand' AND accountmaster.account_balorjamaorpaid='Balance' " & WHERECLAUSE & " and  accountmaster.account_ledgercode='" & tempname & "' and accountmaster.account_date>ledgermaster.ledger_settlement and accountmaster.account_date between #" & Format(dtpfrom.Value, "MM/dd/yyyy") & "# and #" & Format(dtpto.Value, "MM/dd/yyyy") & "# GROUP BY IIf(accountmaster.account_type='I' Or accountmaster.account_type='R' Or accountmaster.account_type='JV' Or accountmaster.account_type='CASH' Or accountmaster.account_type='SALARY','*',''), accountmaster.account_date, accountmaster.account_type, accountmaster.account_voucherid " & GROUPBYCLAUSE & " order by accountmaster.account_date, accountmaster.account_type desc ,accountmaster.account_voucherid", tempconn)
            End If
        End If
        da = New OleDbDataAdapter(tempcmd)
        da.Fill(dt)
        gridissue.DataSource = dt
        gridposetting(gridissue)
        If gridissue.RowCount > 0 Then gridissue.FirstDisplayedScrollingRowIndex = gridissue.RowCount - 1

    End Sub

    Sub gridposetting(ByVal gd As DataGridView)
        With gd

            .Columns(0).HeaderText = ""
            .Columns(0).Width = 20
            If chkname.Checked = False Then
                .Columns(1).HeaderText = "Code"
            Else
                .Columns(1).HeaderText = "Date"
            End If
            .Columns(1).Width = 65

            .Columns(2).HeaderText = "Gr. Wt."
            .Columns(2).Width = 75
            .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(2).DefaultCellStyle.Format = "0.000"

            .Columns(3).HeaderText = "Fn. Wt."
            .Columns(3).Width = 75
            .Columns(3).DefaultCellStyle.Format = "0.000"
            .Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            .Columns(4).HeaderText = "Amount"
            .Columns(4).DefaultCellStyle.Format = "0.00"
            .Columns(4).Width = 80
            .Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            .Columns(5).HeaderText = "type"
            .Columns(5).Width = 1000
            .Columns(5).Visible = False
            .Columns(6).HeaderText = "id"
            .Columns(6).Width = 1000
            .Columns(6).Visible = False
        End With
        da.Dispose()
        dt.Dispose()
        tempconn.Close()
        tempcmd.Dispose()

    End Sub

    'for description
    Sub posetting(ByVal gd As DataGridView)
        With gd

            .Columns(0).HeaderText = "item"
            .Columns(0).Width = 20

            .Columns(2).HeaderText = "Gr Wt."
            .Columns(2).Width = 80
            .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(2).DefaultCellStyle.Format = "0.000"

            .Columns(3).HeaderText = "Fn Wt."
            .Columns(3).Width = 80
            .Columns(3).DefaultCellStyle.Format = "0.000"
            .Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            .Columns(4).HeaderText = "Amount"
            .Columns(4).DefaultCellStyle.Format = "0.00"
            .Columns(4).Width = 80
            .Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            .Columns(5).HeaderText = "type"
            .Columns(5).Width = 1000
            .Columns(5).Visible = False
            .Columns(6).HeaderText = "id"
            .Columns(6).Width = 1000
            .Columns(6).Visible = False
        End With
        da.Dispose()
        dt.Dispose()
        tempconn.Close()
        tempcmd.Dispose()
    End Sub

    Sub clear()
        'getting voucher_id from database
        EDIT = False
        txtbhavcut.Text = "0.000"
        TXTAMOUNT.Text = "0.00"
        txtperwt.Text = "0.00"
        txtrate.Text = "0.00"
        txtpurity.Text = "100.00"
        txtbalamt.Text = "0.00"
        txtbalwt.Text = "0.000"
        txtcashrec.Text = "0.00"
        GRIDDESCRIPTION.RowCount = 1
        cmbtype.Text = ""
        txtnarration.Text = ""
        CMBPROCESS.Text = ""

        tempcmd = New OleDbCommand("select max(account_id) from accountmaster", tempconn)

        If tempconn.State = ConnectionState.Open Then
            tempconn.Close()
        End If
        tempconn.Open()
        tempdr = tempcmd.ExecuteReader
        If tempdr.HasRows Then
            tempdr.Read()
            txtbillno.Text = Val(tempdr(0).ToString)
            txtbillno.Text = Val(txtbillno.Text) + 1
        End If
        tempconn.Close()
        tempdr.Close()

        tempcmd = New OleDbCommand("select sum(item_grosswt),sum(item_nettwt) from stocks", tempconn)

        If tempconn.State = ConnectionState.Open Then
            tempconn.Close()
        End If
        tempconn.Open()
        tempdr = tempcmd.ExecuteReader
        If tempdr.HasRows = True Then
            tempdr.Read()
            If IsDBNull(tempdr(0)) <> True Then
                lblstockingross.Text = Val(tempdr(0))
                lblstockinnett.Text = Val(tempdr(1))

                lblstockingross.Text = Format(lblstockingross.Text, "0.000")
                lblstockinnett.Text = Format(lblstockinnett.Text, "0.000")
            End If
        End If
        tempconn.Close()
        tempdr.Close()

    End Sub

    Sub openingbal()

        Dim tempgrosswt, TEMPNETTWT, tempamt As Double
        If chkname.Checked = False Then
            lblbalcfamtissue.Text = "0.00"
            lblbalcfgrosswtissue.Text = "0.000"
            lblbalcfamtjama.Text = "0.00"
            lblbalcfgrosswtjama.Text = "0.000"
            lblbalbfamtissue.Text = "0.00"
            lblbalbfgrosswtissue.Text = "0.000"
            lblbalbfamtjama.Text = "0.00"
            lblbalbfgrosswtjama.Text = "0.000"
            lblbalbfnettwtissue.Text = "0.000"
            lblbalbfnettwtjama.Text = "0.000"
            lblbalcfnettwtissue.Text = "0.000"
            lblbalcfnettwtjama.Text = "0.000"


            'DONE BY GULKIT
            'If chkdate.Checked = False Then
            '    tempcmd = New OleDbCommand("SELECT  Sum(IIf(type='Balance',-1*grosswt,grosswt)) AS Expr1, Sum(IIf(type='Balance',-1*amount,amount)) AS Expr2  FROM(ledgeraccounts) where ledgeraccounts.sdate < #" & Format(dtpickerkhata.Value, "dd/MM/yyyy") & "# ", tempconn)
            'Else
            '    tempcmd = New OleDbCommand("SELECT  Sum(IIf(type='Balance',-1*grosswt,grosswt)) AS Expr1, Sum(IIf(type='Balance',-1*amount,amount)) AS Expr2  FROM(ledgeraccounts) where ledgeraccounts.sdate < #" & Format(dtpfrom.Value, "dd/MM/yyyy") & "# ", tempconn)
            'End If

            Dim WHERECLAUSE = ""

            If chkdate.Checked = False Then
                WHERECLAUSE = " AND ACCOUNTMASTER.ACCOUNT_DATE< #" & Format(dtpickerkhata.Value.Date, "MM/dd/yyyy") & "# "
            Else
                WHERECLAUSE = " AND ACCOUNTMASTER.ACCOUNT_DATE< #" & Format(dtpfrom.Value.Date, "MM/dd/yyyy") & "# "
            End If

            If USERDEPARTMENTID <> 0 Then WHERECLAUSE = WHERECLAUSE & " AND ACCOUNTMASTER.ACCOUNT_DEPARTMENTID = " & USERDEPARTMENTID


            dt = New DataTable()
            If tempconn.State = ConnectionState.Open Then
                tempconn.Close()
            End If
            tempconn.Open()

            'GET CASH OPENING
            Dim DTCASHDR As New DataTable
            Dim DTCASHCR As New DataTable
            tempcmd = New OleDbCommand("SELECT  Sum(IIF(ISNULL(LEDGERMASTER.LEDGER_OPBALRS) = 'True',0, LEDGERMASTER.LEDGER_OPBALRS)) AS AMOUNT FROM(LEDGERMASTER) where LEDGERMASTER.LEDGER_DRCRRS='Cr.' AND LEDGERMASTER.LEDGER_CODE ='CASH'", tempconn)
            da = New OleDbDataAdapter(tempcmd)
            da.Fill(DTCASHDR)

            tempcmd = New OleDbCommand("SELECT  Sum(IIF(ISNULL(LEDGERMASTER.LEDGER_OPBALRS) = 'True',0, LEDGERMASTER.LEDGER_OPBALRS*(-1))) AS AMOUNT FROM(LEDGERMASTER) where LEDGERMASTER.LEDGER_DRCRRS='Dr.' AND LEDGERMASTER.LEDGER_CODE ='CASH'", tempconn)
            da = New OleDbDataAdapter(tempcmd)
            da.Fill(DTCASHCR)

            tempcmd = New OleDbCommand("SELECT  Sum(IIF(ISNULL(ACCOUNTMASTER.ACCOUNT_GROSSWT) = 'True',0,ACCOUNTMASTER.ACCOUNT_GROSSWT)) AS GROSSWT, Sum(IIF(ISNULL(ACCOUNTMASTER.ACCOUNT_AMOUNT) = 'True',0,ACCOUNTMASTER.ACCOUNT_AMOUNT)) AS AMOUNT, Sum(IIF(ISNULL(ACCOUNTMASTER.ACCOUNT_NETTWT) = 'True',0,ACCOUNTMASTER.ACCOUNT_NETTWT)) AS nettwt FROM(ACCOUNTMASTER) where accountmaster.account_ledgercode <> 'CASH' AND accountmaster.account_balorjamaorpaid='Jama' " & WHERECLAUSE, tempconn)
            da = New OleDbDataAdapter(tempcmd)
            da.Fill(dt)

            tempcmd = New OleDbCommand("SELECT  Sum(IIF(ISNULL(ACCOUNTMASTER.ACCOUNT_GROSSWT) = 'True',0,(ACCOUNTMASTER.ACCOUNT_GROSSWT)*(-1))) AS GROSSWT, Sum(IIF(ISNULL(ACCOUNTMASTER.ACCOUNT_AMOUNT) = 'True',0,(ACCOUNTMASTER.ACCOUNT_AMOUNT)*(-1))) AS AMOUNT, Sum(IIF(ISNULL(ACCOUNTMASTER.ACCOUNT_NETTWT) = 'True',0,(ACCOUNTMASTER.ACCOUNT_NETTWT)*(-1))) AS NETTWT  FROM(ACCOUNTMASTER) where accountmaster.account_ledgercode <> 'CASH' AND accountmaster.account_balorjamaorpaid='Balance' " & WHERECLAUSE, tempconn)
            Dim DA1 As New OleDbDataAdapter(tempcmd)
            Dim DT1 As New DataTable
            DA1.Fill(DT1)

            For Each row As DataRow In DT1.Rows
                dt.ImportRow(row)
                dt.AcceptChanges()
            Next

            For Each row As DataRow In DTCASHDR.Rows
                dt.ImportRow(row)
                dt.AcceptChanges()
            Next

            For Each row As DataRow In DTCASHCR.Rows
                dt.ImportRow(row)
                dt.AcceptChanges()
            Next

            If tempconn.State = ConnectionState.Open Then
                tempconn.Close()
            End If
            tempconn.Open()
            tempdr = tempcmd.ExecuteReader
            If tempdr.HasRows Then
                While tempdr.Read
                    If IsDBNull(dt.Compute("SUM(GROSSWT)", "")) = False Then
                        tempgrosswt = tempgrosswt + Val(dt.Compute("SUM(GROSSWT)", ""))
                    Else
                        tempgrosswt = tempgrosswt
                    End If

                    If IsDBNull(dt.Compute("SUM(NETTWT)", "")) = False Then
                        TEMPNETTWT = TEMPNETTWT + Val(dt.Compute("SUM(NETTWT)", ""))
                    Else
                        TEMPNETTWT = TEMPNETTWT
                    End If

                    If IsDBNull(dt.Compute("SUM(AMOUNT)", "")) = False Then
                        tempamt = tempamt + Val(dt.Compute("SUM(AMOUNT)", ""))
                    Else
                        tempamt = tempamt
                    End If

                End While
            End If
            tempdr.Close()
            tempcmd.Dispose()
            tempconn.Close()
            If Val(tempgrosswt) < 0 Then
                lblbalbfgrosswtissue.Text = Format((tempgrosswt * (-1)), "0.000")
            Else
                lblbalbfgrosswtjama.Text = Format(tempgrosswt, "0.000")
            End If

            If Val(TEMPNETTWT) < 0 Then
                lblbalbfnettwtissue.Text = Format((TEMPNETTWT * (-1)), "0.000")
            Else
                lblbalbfnettwtjama.Text = Format(TEMPNETTWT, "0.000")
            End If

            If tempamt < 0 Then
                lblbalbfamtissue.Text = Format((tempamt * (-1)), "0.00")
            Else
                lblbalbfamtjama.Text = Format(tempamt, "0.00")
            End If

        ElseIf chkname.Checked = True And chkdate.Checked = True Then
            If lblbalbfnettwtissue.Text > 0 Then
                tempgrosswt = Val(lblbalbfnettwtissue.Text) * (-1)
                lblbalbfnettwtissue.Text = "0.000"
            End If
            If lblbalbfnettwtjama.Text > 0 Then
                tempgrosswt = Val(lblbalbfnettwtjama.Text)
                lblbalbfnettwtjama.Text = "0.000"
            End If
            If lblbalbfamtissue.Text > 0 Then
                tempamt = Val(lblbalbfamtissue.Text) * (-1)
                lblbalbfamtissue.Text = "0.00"
            End If
            If lblbalbfamtjama.Text > 0 Then
                tempamt = Val(lblbalbfamtjama.Text)
                lblbalbfamtjama.Text = "0.00"
            End If



            'GET SETTLEMENT DATE FIRST
            Dim SETTLEMENTDATE As Date
            Dim FROMDATE As Date
            Dim tempcmd As New OleDbCommand(" Select LEDGER_SETTLEMENT AS SETTLEMENTDATE FROM LEDGERMASTER WHERE LEDGERMASTER.LEDGER_CODE = '" & tempname & "'", tempconn)
            If tempconn.State = ConnectionState.Open Then tempconn.Close()
            tempconn.Open()
            dr = tempcmd.ExecuteReader()
            If dr.HasRows Then
                dr.Read()
                SETTLEMENTDATE = dr("SETTLEMENTDATE")
            End If


            Dim WHERECLAUSE As String = ""
            If USERDEPARTMENT <> "" Then WHERECLAUSE = WHERECLAUSE & " AND ACCOUNTMAST.DEPARTMENT = '" & USERDEPARTMENT & "'"


            'GET OPENING JAMA OR ISSUE
            Dim OPJAMA As Double = 0.0
            Dim OPJAMAGROSS As Double = 0.0
            Dim OPJAMAAMT As Double = 0.0
            Dim OPBALANCE As Double = 0.0
            Dim OPBALANCEGROSS As Double = 0.0
            Dim OPBALANCEAMT As Double = 0.0

            If chkdate.Checked = False Then
                FROMDATE = SETTLEMENTDATE
            Else
                FROMDATE = dtpfrom.Value.Date
            End If

            If SETTLEMENTDATE < FROMDATE Then
                tempcmd = New OleDbCommand(" Select IIF(ISNULL(Sum(account_nettwt)) = TRUE , 0, Sum(account_nettwt) ) AS Nettwt, IIF(ISNULL(Sum(account_GROSSWT)) = TRUE , 0, Sum(account_GROSSWT) ) AS GROSSWT, IIF(ISNULL(Sum(account_AMOUNT) ) = TRUE , 0, Sum(account_AMOUNT) ) AS Amt FROM ACCOUNTMAST WHERE ACCOUNTMAST.ACCOUNT_LEDGERCODE = '" & tempname & "' AND ACCOUNTMAST.ACCOUNT_DATE < #" & Format(FROMDATE, "MM/dd/yyyy") & "# and account_balorjamaorpaid = 'Jama' " & WHERECLAUSE, tempconn)
            Else
                tempcmd = New OleDbCommand(" Select IIF(ISNULL(Sum(account_nettwt)) = TRUE , 0, Sum(account_nettwt) ) AS Nettwt, IIF(ISNULL(Sum(account_GROSSWT)) = TRUE , 0, Sum(account_GROSSWT) ) AS GROSSWT, IIF(ISNULL(Sum(account_AMOUNT) ) = TRUE , 0, Sum(account_AMOUNT) ) AS Amt FROM ACCOUNTMAST WHERE ACCOUNTMAST.ACCOUNT_LEDGERCODE = '" & tempname & "' AND ACCOUNTMAST.ACCOUNT_DATE <= #" & Format(SETTLEMENTDATE, "MM/dd/yyyy") & "# and account_balorjamaorpaid = 'Jama' " & WHERECLAUSE, tempconn)
            End If
            If tempconn.State = ConnectionState.Open Then tempconn.Close()
            tempconn.Open()
            dr = tempcmd.ExecuteReader()
            If dr.HasRows Then
                dr.Read()
                OPJAMA = dr("NETTWT")
                OPJAMAGROSS = dr("GROSSWT")
                OPJAMAAMT = dr("AMT")
            End If


            If SETTLEMENTDATE < FROMDATE Then
                tempcmd = New OleDbCommand(" Select IIF(ISNULL(Sum(account_nettwt)) = TRUE , 0, Sum(account_nettwt) ) AS Nettwt, IIF(ISNULL(Sum(account_GROSSWT)) = TRUE , 0, Sum(account_GROSSWT) ) AS GROSSWT, IIF(ISNULL(Sum(account_AMOUNT) ) = TRUE , 0, Sum(account_AMOUNT) ) AS Amt FROM ACCOUNTMAST WHERE ACCOUNTMAST.ACCOUNT_LEDGERCODE = '" & tempname & "' AND ACCOUNTMAST.ACCOUNT_DATE < #" & Format(FROMDATE, "MM/dd/yyyy") & "# and account_balorjamaorpaid = 'Balance'" & WHERECLAUSE, tempconn)
            Else
                tempcmd = New OleDbCommand(" Select IIF(ISNULL(Sum(account_nettwt)) = TRUE , 0, Sum(account_nettwt) ) AS Nettwt, IIF(ISNULL(Sum(account_GROSSWT)) = TRUE , 0, Sum(account_GROSSWT) ) AS GROSSWT, IIF(ISNULL(Sum(account_AMOUNT) ) = TRUE , 0, Sum(account_AMOUNT) ) AS Amt FROM ACCOUNTMAST WHERE ACCOUNTMAST.ACCOUNT_LEDGERCODE = '" & tempname & "' AND ACCOUNTMAST.ACCOUNT_DATE <= #" & Format(SETTLEMENTDATE, "MM/dd/yyyy") & "# and account_balorjamaorpaid = 'Balance'" & WHERECLAUSE, tempconn)
            End If
            If tempconn.State = ConnectionState.Open Then tempconn.Close()
            tempconn.Open()
            dr = tempcmd.ExecuteReader()
            If dr.HasRows Then
                dr.Read()
                OPBALANCE = dr("NETTWT")
                OPBALANCEGROSS = dr("GROSSWT")
                OPBALANCEAMT = dr("AMT")
            End If


            'get PARTYOPENING AMT
            tempcmd = New OleDbCommand(" Select IIF(LEDGER_DRCRRS = 'Cr.' , LEDGER_OPBALRS, 0 ) AS OPBALDR, IIF(LEDGER_DRCRRS = 'Dr.' , LEDGER_OPBALRS, 0 ) AS OPBALCR FROM LEDGERMASTER WHERE LEDGERMASTER.LEDGER_CODE = '" & tempname & "'", tempconn)
            If tempconn.State = ConnectionState.Open Then tempconn.Close()
            tempconn.Open()
            dr = tempcmd.ExecuteReader()
            If dr.HasRows Then
                dr.Read()
                OPJAMAAMT = OPJAMAAMT + dr("OPBALDR")
                OPBALANCEAMT = OPBALANCEAMT + dr("OPBALCR")
            End If


            'get PARTYOPENING BALANCE (NETTWT)
            tempcmd = New OleDbCommand(" Select IIF(LEDGER_DRCRWT = 'Cr.' , LEDGER_OPBALWT, 0 ) AS OPBALDR, IIF(LEDGER_DRCRWT = 'Dr.' , LEDGER_OPBALWT, 0 ) AS OPBALCR FROM LEDGERMASTER WHERE LEDGERMASTER.LEDGER_CODE = '" & tempname & "'", tempconn)
            If tempconn.State = ConnectionState.Open Then tempconn.Close()
            tempconn.Open()
            dr = tempcmd.ExecuteReader()
            If dr.HasRows Then
                dr.Read()
                OPJAMA = OPJAMA + dr("OPBALDR")
                OPBALANCE = OPBALANCE + dr("OPBALCR")
            End If


            'get PARTYOPENING BALANCE (GROSSWT)
            tempcmd = New OleDbCommand(" Select IIF(LEDGER_DRCRGROSSWT = 'Cr.' , LEDGER_OPBALGROSSWT, 0 ) AS OPBALGROSSDR, IIF(LEDGER_DRCRGROSSWT = 'Dr.' , LEDGER_OPBALGROSSWT, 0 ) AS OPBALGROSSCR FROM LEDGERMASTER WHERE LEDGERMASTER.LEDGER_CODE = '" & tempname & "'", tempconn)
            If tempconn.State = ConnectionState.Open Then tempconn.Close()
            tempconn.Open()
            dr = tempcmd.ExecuteReader()
            If dr.HasRows Then
                dr.Read()
                OPJAMAGROSS = OPJAMAGROSS + dr("OPBALGROSSDR")
                OPBALANCEGROSS = OPBALANCEGROSS + dr("OPBALGROSSCR")
            End If


            'WRITE OP BAL
            If OPJAMA > OPBALANCE Then
                lblbalbfnettwtjama.Text = Format(Val(OPJAMA - OPBALANCE), "0.000")
            Else
                lblbalbfnettwtissue.Text = Format(Val(OPBALANCE - OPJAMA), "0.000")
            End If


            'WRITE OP BAL GROSS
            If OPJAMAGROSS > OPBALANCEGROSS Then
                lblbalbfgrosswtjama.Text = Format(Val(OPJAMAGROSS - OPBALANCEGROSS), "0.000")
            Else
                lblbalbfgrosswtissue.Text = Format(Val(OPBALANCEGROSS - OPJAMAGROSS), "0.000")
            End If

            'WRITE OPAMT
            If OPJAMAAMT > OPBALANCEAMT Then
                lblbalbfamtjama.Text = Format(Val(OPJAMAAMT - OPBALANCEAMT), "0.000")
            Else
                lblbalbfamtissue.Text = Format(Val(OPBALANCEAMT - OPJAMAAMT), "0.000")
            End If


            'If SETTLEMENTDATE < FROMDATE Then
            '    tempcmd = New OleDbCommand("select account_balorjamaorpaid,account_date,account_nettwt,account_amount from accountmaster where account_ledgercode= '" & tempname & "' and account_date < #" & Format(FROMDATE, "dd/MM/yyyy") & "#", tempconn)
            'Else
            '    tempcmd = New OleDbCommand("select account_balorjamaorpaid,account_date,account_nettwt,account_amount from accountmaster where account_ledgercode= '" & tempname & "' and account_date <= #" & Format(SETTLEMENTDATE, "dd/MM/yyyy") & "#", tempconn)
            'End If
            ''tempcmd = New OleDbCommand("select account_balorjamaorpaid,account_date,account_nettwt,account_amount FROM accountmaster INNER JOIN ledgermaster ON accountmaster.account_ledgercode = ledgermaster.ledger_code where accountmaster.account_ledgercode= '" & tempname & "' and accountmaster.account_date<=ledgermaster.ledger_settlement and  accountmaster.account_date <= #" & Format(dtpfrom.Value, "dd/MM/yyyy") & "#", tempconn)
            '' 
            'If tempconn.State = ConnectionState.Open Then
            '    tempconn.Close()
            'End If
            'tempconn.Open()
            'tempdr = tempcmd.ExecuteReader
            'If tempdr.HasRows Then
            '    While tempdr.Read
            '        If tempdr("account_balorjamaorpaid") = "Jama" Then
            '            '                        If tempdr("account_date") < Format(dtpfrom.Value, "dd/MM/yyyy") Then
            '            tempgrosswt = Val(tempdr("account_nettwt")) + tempgrosswt
            '            tempamt = tempamt + Val(tempdr("account_amount"))
            '            ' End If
            '        ElseIf tempdr("account_balorjamaorpaid") = "Balance" Then

            '            'If tempdr("account_date") < Format(dtpfrom.Value, "dd/MM/yyyy") Then
            '            tempgrosswt = tempgrosswt - Val(tempdr("account_nettwt"))
            '            tempamt = tempamt - Val(tempdr("account_amount"))
            '            'End If
            '        End If
            '    End While
            'End If
            tempdr.Close()
            tempcmd.Dispose()
            tempconn.Close()

            'If Val(tempgrosswt) < 0 Then
            '    lblbalbfnettwtissue.Text = Format((tempgrosswt * (-1)), "0.000")
            'Else
            '    lblbalbfnettwtjama.Text = Format(tempgrosswt, "0.000")
            'End If

            'If tempamt < 0 Then
            '    lblbalbfamtissue.Text = Format((tempamt * (-1)), "0.00")
            'Else
            '    lblbalbfamtjama.Text = Format(tempamt, "0.00")
            'End If



        ElseIf chkname.Checked = True And chkdate.Checked = False Then


            Dim WHERECLAUSE As String = ""
            If USERDEPARTMENTID <> 0 Then WHERECLAUSE = WHERECLAUSE & " AND ACCOUNTMAST.DEPARTMENT = '" & USERDEPARTMENT & "'"

            If lblbalbfnettwtissue.Text > 0 Then
                tempgrosswt = Val(lblbalbfnettwtissue.Text) * (-1)
                lblbalbfnettwtissue.Text = "0.000"
            End If
            If lblbalbfnettwtjama.Text > 0 Then
                tempgrosswt = Val(lblbalbfnettwtjama.Text)
                lblbalbfnettwtjama.Text = "0.000"
            End If
            If lblbalbfamtissue.Text > 0 Then
                tempamt = Val(lblbalbfamtissue.Text) * (-1)
                lblbalbfamtissue.Text = "0.00"
            End If
            If lblbalbfamtjama.Text > 0 Then
                tempamt = Val(lblbalbfamtjama.Text)
                lblbalbfamtjama.Text = "0.00"
            End If


            'COMMENTED BY GULKIT ON 2-1-19
            '****************************************************************
            'tempcmd = New OleDbCommand("select Sum(IIf(account_balorjamaorpaid='Balance',-1*account_nettwt,account_nettwt)) AS Expr1, Sum(IIf(account_balorjamaorpaid='Balance',-1*account_amount,account_amount)) AS Expr2 FROM accountmaster INNER JOIN ledgermaster ON accountmaster.account_ledgercode = ledgermaster.ledger_code where accountmaster.account_ledgercode= '" & tempname & "' and accountmaster.account_date<=ledgermaster.ledger_settlement " & WHERECLAUSE, tempconn)
            'If tempconn.State = ConnectionState.Open Then
            '    tempconn.Close()
            'End If
            'tempconn.Open()
            'tempdr = tempcmd.ExecuteReader
            'If tempdr.HasRows Then
            '    While tempdr.Read
            '        'If tempdr("account_balorjamaorpaid") = "Jama" Then
            '        '    '                        If tempdr("account_date") < Format(dtpfrom.Value, "dd/MM/yyyy") Then
            '        '    tempgrosswt = Val(tempdr("account_nettwt")) + tempgrosswt
            '        '    tempamt = tempamt + Val(tempdr("account_amount"))
            '        '    ' End If
            '        'ElseIf tempdr("account_balorjamaorpaid") = "Balance" Then

            '        '    'If tempdr("account_date") < Format(dtpfrom.Value, "dd/MM/yyyy") Then
            '        '    tempgrosswt = tempgrosswt - Val(tempdr("account_nettwt"))
            '        '    tempamt = tempamt - Val(tempdr("account_amount"))
            '        '    'End If
            '        'End If

            '        'If tempdr("account_balorjamaorpaid") = "Jama" Then
            '        '                        If tempdr("account_date") < Format(dtpfrom.Value, "dd/MM/yyyy") Then
            '        tempgrosswt = Val(tempdr(0).ToString) + tempgrosswt
            '        tempamt = tempamt + Val(tempdr(1).ToString)
            '        '    ' End If
            '        'ElseIf tempdr("account_balorjamaorpaid") = "Balance" Then

            '        '    'If tempdr("account_date") < Format(dtpfrom.Value, "dd/MM/yyyy") Then
            '        '    tempgrosswt = tempgrosswt - Val(tempdr("account_nettwt"))
            '        '    tempamt = tempamt - Val(tempdr("account_amount"))
            '        '    'End If
            '        'End If
            '    End While
            'End If
            'tempdr.Close()
            'tempcmd.Dispose()
            'tempconn.Close()

            'If Val(tempgrosswt) < 0 Then
            '    lblbalbfnettwtissue.Text = Format((tempgrosswt * (-1)), "0.000")
            'Else
            '    lblbalbfnettwtjama.Text = Format(tempgrosswt, "0.000")
            'End If

            'If tempamt < 0 Then
            '    lblbalbfamtissue.Text = Format((tempamt * (-1)), "0.00")
            'Else
            '    lblbalbfamtjama.Text = Format(tempamt, "0.00")
            'End If
            '*****************************************


            'GET SETTLEMENT DATE FIRST
            Dim SETTLEMENTDATE As Date
            Dim FROMDATE As Date
            Dim tempcmd As New OleDbCommand(" Select LEDGER_SETTLEMENT AS SETTLEMENTDATE FROM LEDGERMASTER WHERE LEDGERMASTER.LEDGER_CODE = '" & tempname & "'", tempconn)
            If tempconn.State = ConnectionState.Open Then tempconn.Close()
            tempconn.Open()
            dr = tempcmd.ExecuteReader()
            If dr.HasRows Then
                dr.Read()
                SETTLEMENTDATE = dr("SETTLEMENTDATE")
            End If


            'GET OPENING JAMA OR ISSUE
            Dim OPJAMA As Double = 0.0
            Dim OPJAMAGROSS As Double = 0.0
            Dim OPJAMAAMT As Double = 0.0
            Dim OPBALANCE As Double = 0.0
            Dim OPBALANCEGROSS As Double = 0.0
            Dim OPBALANCEAMT As Double = 0.0

            If chkdate.Checked = False Then
                FROMDATE = SETTLEMENTDATE
            Else
                FROMDATE = dtpfrom.Value.Date
            End If

            If SETTLEMENTDATE < FROMDATE Then
                tempcmd = New OleDbCommand(" Select IIF(ISNULL(Sum(account_nettwt)) = TRUE , 0, Sum(account_nettwt) ) AS Nettwt, IIF(ISNULL(Sum(account_GROSSWT)) = TRUE , 0, Sum(account_GROSSWT) ) AS GROSSWT, IIF(ISNULL(Sum(account_AMOUNT) ) = TRUE , 0, Sum(account_AMOUNT) ) AS Amt FROM ACCOUNTMAST WHERE ACCOUNTMAST.ACCOUNT_LEDGERCODE = '" & tempname & "' AND ACCOUNTMAST.ACCOUNT_DATE < #" & Format(FROMDATE, "MM/dd/yyyy") & "# and account_balorjamaorpaid = 'Jama' " & WHERECLAUSE, tempconn)
            Else
                tempcmd = New OleDbCommand(" Select IIF(ISNULL(Sum(account_nettwt)) = TRUE , 0, Sum(account_nettwt) ) AS Nettwt, IIF(ISNULL(Sum(account_GROSSWT)) = TRUE , 0, Sum(account_GROSSWT) ) AS GROSSWT, IIF(ISNULL(Sum(account_AMOUNT) ) = TRUE , 0, Sum(account_AMOUNT) ) AS Amt FROM ACCOUNTMAST WHERE ACCOUNTMAST.ACCOUNT_LEDGERCODE = '" & tempname & "' AND ACCOUNTMAST.ACCOUNT_DATE <= #" & Format(SETTLEMENTDATE, "MM/dd/yyyy") & "# and account_balorjamaorpaid = 'Jama' " & WHERECLAUSE, tempconn)
            End If
            If tempconn.State = ConnectionState.Open Then tempconn.Close()
            tempconn.Open()
            dr = tempcmd.ExecuteReader()
            If dr.HasRows Then
                dr.Read()
                OPJAMA = dr("NETTWT")
                OPJAMAGROSS = dr("GROSSWT")
                OPJAMAAMT = dr("AMT")
            End If


            If SETTLEMENTDATE < FROMDATE Then
                tempcmd = New OleDbCommand(" Select IIF(ISNULL(Sum(account_nettwt)) = TRUE , 0, Sum(account_nettwt) ) AS Nettwt, IIF(ISNULL(Sum(account_GROSSWT)) = TRUE , 0, Sum(account_GROSSWT) ) AS GROSSWT, IIF(ISNULL(Sum(account_AMOUNT) ) = TRUE , 0, Sum(account_AMOUNT) ) AS Amt FROM ACCOUNTMAST WHERE ACCOUNTMAST.ACCOUNT_LEDGERCODE = '" & tempname & "' AND ACCOUNTMAST.ACCOUNT_DATE < #" & Format(FROMDATE, "MM/dd/yyyy") & "# and account_balorjamaorpaid = 'Balance'" & WHERECLAUSE, tempconn)
            Else
                tempcmd = New OleDbCommand(" Select IIF(ISNULL(Sum(account_nettwt)) = TRUE , 0, Sum(account_nettwt) ) AS Nettwt, IIF(ISNULL(Sum(account_GROSSWT)) = TRUE , 0, Sum(account_GROSSWT) ) AS GROSSWT, IIF(ISNULL(Sum(account_AMOUNT) ) = TRUE , 0, Sum(account_AMOUNT) ) AS Amt FROM ACCOUNTMAST WHERE ACCOUNTMAST.ACCOUNT_LEDGERCODE = '" & tempname & "' AND ACCOUNTMAST.ACCOUNT_DATE <= #" & Format(SETTLEMENTDATE, "MM/dd/yyyy") & "# and account_balorjamaorpaid = 'Balance'" & WHERECLAUSE, tempconn)
            End If
            If tempconn.State = ConnectionState.Open Then tempconn.Close()
            tempconn.Open()
            dr = tempcmd.ExecuteReader()
            If dr.HasRows Then
                dr.Read()
                OPBALANCE = dr("NETTWT")
                OPBALANCEGROSS = dr("GROSSWT")
                OPBALANCEAMT = dr("AMT")
            End If


            'get PARTYOPENING AMT
            tempcmd = New OleDbCommand(" Select IIF(LEDGER_DRCRRS = 'Cr.' , LEDGER_OPBALRS, 0 ) AS OPBALDR, IIF(LEDGER_DRCRRS = 'Dr.' , LEDGER_OPBALRS, 0 ) AS OPBALCR FROM LEDGERMASTER WHERE LEDGERMASTER.LEDGER_CODE = '" & tempname & "'", tempconn)
            If tempconn.State = ConnectionState.Open Then tempconn.Close()
            tempconn.Open()
            dr = tempcmd.ExecuteReader()
            If dr.HasRows Then
                dr.Read()
                OPJAMAAMT = OPJAMAAMT + dr("OPBALDR")
                OPBALANCEAMT = OPBALANCEAMT + dr("OPBALCR")
            End If


            'get PARTYOPENING BALANCE (NETTWT)
            tempcmd = New OleDbCommand(" Select IIF(LEDGER_DRCRWT = 'Cr.' , LEDGER_OPBALWT, 0 ) AS OPBALDR, IIF(LEDGER_DRCRWT = 'Dr.' , LEDGER_OPBALWT, 0 ) AS OPBALCR FROM LEDGERMASTER WHERE LEDGERMASTER.LEDGER_CODE = '" & tempname & "'", tempconn)
            If tempconn.State = ConnectionState.Open Then tempconn.Close()
            tempconn.Open()
            dr = tempcmd.ExecuteReader()
            If dr.HasRows Then
                dr.Read()
                OPJAMA = OPJAMA + dr("OPBALDR")
                OPBALANCE = OPBALANCE + dr("OPBALCR")
            End If


            'get PARTYOPENING BALANCE (GROSSWT)
            tempcmd = New OleDbCommand(" Select IIF(LEDGER_DRCRGROSSWT = 'Cr.' , LEDGER_OPBALGROSSWT, 0 ) AS OPBALGROSSDR, IIF(LEDGER_DRCRGROSSWT = 'Dr.' , LEDGER_OPBALGROSSWT, 0 ) AS OPBALGROSSCR FROM LEDGERMASTER WHERE LEDGERMASTER.LEDGER_CODE = '" & tempname & "'", tempconn)
            If tempconn.State = ConnectionState.Open Then tempconn.Close()
            tempconn.Open()
            dr = tempcmd.ExecuteReader()
            If dr.HasRows Then
                dr.Read()
                OPJAMAGROSS = OPJAMAGROSS + dr("OPBALGROSSDR")
                OPBALANCEGROSS = OPBALANCEGROSS + dr("OPBALGROSSCR")
            End If


            'WRITE OP BAL
            If OPJAMA > OPBALANCE Then
                lblbalbfnettwtjama.Text = Format(Val(OPJAMA - OPBALANCE), "0.000")
            Else
                lblbalbfnettwtissue.Text = Format(Val(OPBALANCE - OPJAMA), "0.000")
            End If


            'WRITE OP BAL GROSS
            If OPJAMAGROSS > OPBALANCEGROSS Then
                lblbalbfgrosswtjama.Text = Format(Val(OPJAMAGROSS - OPBALANCEGROSS), "0.000")
            Else
                lblbalbfgrosswtissue.Text = Format(Val(OPBALANCEGROSS - OPJAMAGROSS), "0.000")
            End If

            'WRITE OPAMT
            If OPJAMAAMT > OPBALANCEAMT Then
                lblbalbfamtjama.Text = Format(Val(OPJAMAAMT - OPBALANCEAMT), "0.000")
            Else
                lblbalbfamtissue.Text = Format(Val(OPBALANCEAMT - OPJAMAAMT), "0.000")
            End If


        End If

    End Sub

    Private Sub griddescription_CellValidated(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDDESCRIPTION.CellValidated
        If GRIDDESCRIPTION.Item(dgcmbitemcode.Index, e.RowIndex).ToString <> "" Then

            GRIDDESCRIPTION.Item(DGNETTWT.Index, e.RowIndex).Value = Val(GRIDDESCRIPTION.Item(dggrosswt.Index, e.RowIndex).Value) - Val(GRIDDESCRIPTION.Item(DGLESSWT.Index, e.RowIndex).Value)


            If Val(GRIDDESCRIPTION.Item(dgBullion.Index, e.RowIndex).Value) <> 0 Then
                GRIDDESCRIPTION.Item(DGFINEWT.Index, e.RowIndex).Value = Val(GRIDDESCRIPTION.Item(DGNETTWT.Index, e.RowIndex).Value) * (Val(GRIDDESCRIPTION.Item(dgBullion.Index, e.RowIndex).Value) + Val(GRIDDESCRIPTION.Item(dgwastage.Index, e.RowIndex).Value)) / 100
            Else
                If GRIDDESCRIPTION.Item(dggrosswt.Index, e.RowIndex).Value <> 0 Then GRIDDESCRIPTION.Item(DGFINEWT.Index, e.RowIndex).Value = Val(GRIDDESCRIPTION.Item(DGNETTWT.Index, e.RowIndex).Value) * (Val(GRIDDESCRIPTION.Item(dgpurity.Index, e.RowIndex).Value) + Val(GRIDDESCRIPTION.Item(dgwastage.Index, e.RowIndex).Value)) / 100
            End If

            If Val(GRIDDESCRIPTION.Item(dgpieces.Index, e.RowIndex).Value) <> 0 And Val(GRIDDESCRIPTION.Item(dglabour.Index, e.RowIndex).Value) <> 0 Then
                GRIDDESCRIPTION.Item(dgamt.Index, e.RowIndex).Value = Val(GRIDDESCRIPTION.Item(dgpieces.Index, e.RowIndex).Value) * Val(GRIDDESCRIPTION.Item(dglabour.Index, e.RowIndex).Value)
            ElseIf Val(GRIDDESCRIPTION.Item(dglabour.Index, e.RowIndex).Value) <> 0 Then
                GRIDDESCRIPTION.Item(dgamt.Index, e.RowIndex).Value = Val(GRIDDESCRIPTION.Item(dggrosswt.Index, e.RowIndex).Value) * Val(GRIDDESCRIPTION.Item(dglabour.Index, e.RowIndex).Value)
            End If

            If e.ColumnIndex = DGITEMDESC.Index Then GRIDDESCRIPTION.Item(DGITEMDESC.Index, e.RowIndex).Value = UCase(GRIDDESCRIPTION.Item(DGITEMDESC.Index, e.RowIndex).Value)


            'txtnettwt.Text = ((Val(txtboolean.Text) + Val(txtwastage.Text)) * Val(txtgrosswt.Text)) / 100
            ' End If
            If e.ColumnIndex = dggrosswt.Index Or e.ColumnIndex = DGLESSWT.Index Or e.ColumnIndex = DGNETTWT.Index Or e.ColumnIndex = dgpurity.Index Or e.ColumnIndex = dgwastage.Index Or e.ColumnIndex = DGFINEWT.Index Or e.ColumnIndex = dglabour.Index Or e.ColumnIndex = dgpieces.Index Then
                If GRIDDESCRIPTION.Item(dgcmbitemcode.Index, e.RowIndex).Value = Nothing Then

                    GRIDDESCRIPTION.Item(dggrosswt.Index, GRIDDESCRIPTION.CurrentRow.Index).Value = Nothing
                    GRIDDESCRIPTION.Item(DGLESSWT.Index, GRIDDESCRIPTION.CurrentRow.Index).Value = Nothing
                    GRIDDESCRIPTION.Item(DGNETTWT.Index, GRIDDESCRIPTION.CurrentRow.Index).Value = Nothing
                    GRIDDESCRIPTION.Item(dgpurity.Index, GRIDDESCRIPTION.CurrentRow.Index).Value = Nothing
                    GRIDDESCRIPTION.Item(dgwastage.Index, GRIDDESCRIPTION.CurrentRow.Index).Value = Nothing
                    GRIDDESCRIPTION.Item(DGFINEWT.Index, GRIDDESCRIPTION.CurrentRow.Index).Value = Nothing
                    GRIDDESCRIPTION.Item(dglabour.Index, GRIDDESCRIPTION.CurrentRow.Index).Value = Nothing
                    GRIDDESCRIPTION.Item(dgpieces.Index, GRIDDESCRIPTION.CurrentRow.Index).Value = Nothing
                    GRIDDESCRIPTION.Item(dgBullion.Index, GRIDDESCRIPTION.CurrentRow.Index).Value = Nothing
                    'End If
                End If

            End If

            Dim NEWDT As New DataTable
            If e.ColumnIndex = dgcmbitemcode.Index And cmbcode.Text.Trim <> "" And GRIDDESCRIPTION.Item(dgcmbitemcode.Index, e.RowIndex).Value <> "" Then
                'gettig DEFAULT WASTAGE
                tempcmd = New OleDbCommand("SELECT CustomerWastage.wastage AS WASTAGE, CustomerWastage.labour AS LABOUR FROM (CustomerWastage INNER JOIN ItemMaster ON CustomerWastage.itemid = ItemMaster.item_id) INNER JOIN ledgermaster ON CustomerWastage.ledgerid = ledgermaster.ledger_id WHERE ITEM_CODE = '" & GRIDDESCRIPTION.Item(dgcmbitemcode.Index, e.RowIndex).EditedFormattedValue & "' AND LEDGER_CODE = '" & cmbcode.Text.Trim & "'", tempconn)
                da = New OleDbDataAdapter(tempcmd)
                da.Fill(NEWDT)
                If NEWDT.Rows.Count > 0 Then
                    GRIDDESCRIPTION.Item(dgwastage.Index, e.RowIndex).Value = Format(Val(NEWDT.Rows(0).Item("WASTAGE")), "0.00")
                    GRIDDESCRIPTION.Item(dglabour.Index, e.RowIndex).Value = Format(Val(NEWDT.Rows(0).Item("LABOUR")), "0.00")
                End If
            ElseIf e.ColumnIndex = dgwastage.Index And cmbcode.Text.Trim <> "" And GRIDDESCRIPTION.Item(dgcmbitemcode.Index, e.RowIndex).EditedFormattedValue <> "" Then
                tempcmd = New OleDbCommand("SELECT CustomerWastage.wastage AS WASTAGE, CustomerWastage.labour AS LABOUR FROM (CustomerWastage INNER JOIN ItemMaster ON CustomerWastage.itemid = ItemMaster.item_id) INNER JOIN ledgermaster ON CustomerWastage.ledgerid = ledgermaster.ledger_id WHERE ITEM_CODE = '" & GRIDDESCRIPTION.Item(dgcmbitemcode.Index, e.RowIndex).EditedFormattedValue & "' AND LEDGER_CODE = '" & cmbcode.Text.Trim & "'", tempconn)
                da = New OleDbDataAdapter(tempcmd)
                da.Fill(NEWDT)
                If NEWDT.Rows.Count = 0 Then
                    'ADDING DEFAULT WASTAGE
                    If Val(GRIDDESCRIPTION.Item(dgwastage.Index, e.RowIndex).EditedFormattedValue) > 0 Then
                        Dim TEMPMSG As Integer = MsgBox("Add this as Default Wastage?", MsgBoxStyle.YesNo)
                        If TEMPMSG = vbNo Then Exit Sub
                        ADDWASTAGE()
                    End If
                Else
                    'UPDATE WASTAGE
                    If Val(GRIDDESCRIPTION.Item(dgwastage.Index, e.RowIndex).EditedFormattedValue) > 0 Then
                        UPDATEWASTAGE()
                    End If
                End If
            End If

        End If
        'total()

    End Sub

    Sub ADDWASTAGE()
        Try
            '********************* ADDING VALUES IN CUSTOMERWASTAGE TABLE **********************'
            'clearing array
            For i = 1 To 100
                tempcol(i) = ""
                tempval(i) = ""
            Next


            tempcol(0) = "ledgerid"
            tempcol(1) = "itemid"
            tempcol(2) = "wastage"
            tempcol(3) = "labour"
            tempcol(4) = "cus_default"


            'getting nameid
            cmd = New OleDbCommand("select ledger_id from ledgermaster where ledger_code = '" & cmbcode.Text.Trim & "'", conn)
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


            'getting itemid
            cmd = New OleDbCommand("select item_id from itemmaster where item_code =  '" & GRIDDESCRIPTION.Item(dgcmbitemcode.Index, GRIDDESCRIPTION.CurrentRow.Index).EditedFormattedValue & "'", conn)
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
            conn.Open()
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                dr.Read()
                tempval(1) = Val(dr(0))
            Else
                tempval(1) = Val(0)
            End If
            conn.Close()

            tempval(2) = Val(GRIDDESCRIPTION.Item(dgwastage.Index, GRIDDESCRIPTION.CurrentRow.Index).EditedFormattedValue)
            tempval(3) = Val(GRIDDESCRIPTION.Item(dglabour.Index, GRIDDESCRIPTION.CurrentRow.Index).EditedFormattedValue)
            tempval(4) = 1

            insert("CustomerWastage", tempcol, tempval)
            '********************* END OF CODE **********************'
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub UPDATEWASTAGE()
        Try

            'CHECK WHETHER THE WASTAGE IS SAME OR NOT, IF NOT THEN UPDATE
            'getting nameid
            cmd = New OleDbCommand("select wastage from CustomerWastage INNER JOIN ledgermaster ON CustomerWastage.LEDGERID = ledgermaster.LEDGER_ID where ledgermaster.ledger_code = '" & cmbcode.Text.Trim & "'", conn)
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Open()
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                dr.Read()
                If Val(dr(0)) <> Val(GRIDDESCRIPTION.Item(dgwastage.Index, GRIDDESCRIPTION.CurrentRow.Index).EditedFormattedValue) Then
                    Dim TEMPMSG As Integer = MsgBox("Add this as Default Wastage?", MsgBoxStyle.YesNo)
                    If TEMPMSG = vbNo Then Exit Sub
                End If
                conn.Close()
            End If


            '********************* ADDING VALUES IN CUSTOMERWASTAGE TABLE **********************'
            'clearing array
            For i = 1 To 100
                tempcol(i) = ""
                tempval(i) = ""
            Next


            tempcol(0) = "ledgerid"
            tempcol(1) = "itemid"
            tempcol(2) = "wastage"
            tempcol(3) = "labour"
            tempcol(4) = "cus_default"


            'getting nameid
            cmd = New OleDbCommand("select ledger_id from ledgermaster where ledger_code = '" & cmbcode.Text.Trim & "'", conn)
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


            'getting itemid
            cmd = New OleDbCommand("select item_id from itemmaster where item_code =  '" & GRIDDESCRIPTION.Item(dgcmbitemcode.Index, GRIDDESCRIPTION.CurrentRow.Index).EditedFormattedValue & "'", conn)
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
            conn.Open()
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                dr.Read()
                tempval(1) = Val(dr(0))
            Else
                tempval(1) = Val(0)
            End If
            conn.Close()

            tempval(2) = Val(GRIDDESCRIPTION.Item(dgwastage.Index, GRIDDESCRIPTION.CurrentRow.Index).EditedFormattedValue)
            tempval(3) = Val(GRIDDESCRIPTION.Item(dglabour.Index, GRIDDESCRIPTION.CurrentRow.Index).EditedFormattedValue)
            tempval(4) = 1


            modify("CustomerWastage", tempcol, tempval, " WHERE LEDGERID = " & tempval(0) & " AND ITEMID = " & tempval(1))
            '********************* END OF CODE **********************'
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub griddescription_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles GRIDDESCRIPTION.CellValidating
        'If item <> 1 Then
        '    fillitem()
        '    item = 1
        'End If
        If (TypeOf CType(sender, DataGridView).EditingControl Is DataGridViewComboBoxEditingControl) Then
            Dim cmb As DataGridViewComboBoxEditingControl = CType(CType(sender, DataGridView).EditingControl, DataGridViewComboBoxEditingControl)
            If Not cmb Is Nothing Then
                Dim grid As DataGridView = cmb.EditingControlDataGridView
                Dim value As Object = uppercase(cmb.Text.Trim)
                If cmb.Text.Trim <> "" Then

                    cmd = New OleDbCommand("select item_id, ITEM_NAME AS ITEMNAME, ITEM_RATE AS PURITY from itemmaster where item_code = '" & cmb.Text.Trim & "'", conn)
                    If conn.State = ConnectionState.Open Then
                        conn.Close()
                    End If
                    conn.Open()
                    dr = cmd.ExecuteReader
                    If dr.HasRows = False Then

                        'ask to save new entry
                        tempmsg = MsgBox("Item Not Present, Add New?", MsgBoxStyle.YesNo)
                        If tempmsg = vbYes Then
                            item = 0
                            If (chlditemmaster.IsMdiChild = False) Then
                                If chlditemmaster.IsDisposed = True Then
                                    chlditemmaster = New Itemmaster
                                End If
                                chlditemmaster.cmdedit.Enabled = True
                                chlditemmaster.EDIT = False
                                e.Cancel = True
                                chlditemmaster.cmdaddnew.Enabled = False
                                chlditemmaster.GPITEM.Enabled = True
                                chlditemmaster.txttype.Visible = False
                                chlditemmaster.txtcategory.Visible = False
                                chlditemmaster.cmbcode.Text = UCase(cmb.Text)
                                chlditemmaster.cmbitemname.Text = UCase(cmb.Text)
                                chlditemmaster.ActiveControl = (chlditemmaster.cmbcode)
                                chlditemmaster.cmbtype.Focus()
                                chlditemmaster.Show(Me)
                            Else
                                chlditemmaster.BringToFront()
                            End If
                        Else
                            cmb.Text = UCase(cmb.Text.Trim)
                            cmb.Focus()
                            e.Cancel = True
                        End If

                    Else
                        dr.Read()
                        If GRIDDESCRIPTION.CurrentRow.Cells(DGITEMDESC.Index).Value = "" Or GRIDDESCRIPTION.CurrentRow.Cells(DGITEMDESC.Index).Value = Nothing Then GRIDDESCRIPTION.CurrentRow.Cells(DGITEMDESC.Index).Value = dr("ITEMNAME")
                        If Val(GRIDDESCRIPTION.CurrentRow.Cells(dgpurity.Index).Value) = 0 And Val(dr("PURITY")) > 0 Then GRIDDESCRIPTION.CurrentRow.Cells(dgpurity.Index).Value = Format(Val(dr("PURITY")), "0.00")

                        If cmb.Items.IndexOf(value) = -1 Then
                            fillitem()
                        End If
                        cmb.Text = value
                        grid.CurrentCell.Value = value

                        If ClientName <> "MONOGRAM" And ClientName <> "ORIENTAL" Then
                            Dim objstockform As New Stockform
                            objstockform.ht = GRIDDESCRIPTION.Top + 22 + (GRIDDESCRIPTION.CurrentRow.Height * e.RowIndex)
                            objstockform.wd = GRIDDESCRIPTION.Left + 10
                            objstockform.item = GRIDDESCRIPTION.CurrentRow.Cells(dgcmbitemcode.Index).EditedFormattedValue.ToString
                            objstockform.ShowDialog()


                            If Val(objstockform.GROSSWT) > 0 Then GRIDDESCRIPTION.CurrentRow.Cells(dggrosswt.Index).Value = objstockform.GROSSWT
                            If Val(objstockform.PURITY) > 0 Then GRIDDESCRIPTION.CurrentRow.Cells(dgpurity.Index).Value = objstockform.PURITY
                        End If


                        Dim NEWDT As New DataTable
                        tempcmd = New OleDbCommand("SELECT CustomerWastage.wastage AS WASTAGE, CustomerWastage.labour AS LABOUR FROM (CustomerWastage INNER JOIN ItemMaster ON CustomerWastage.itemid = ItemMaster.item_id) INNER JOIN ledgermaster ON CustomerWastage.ledgerid = ledgermaster.ledger_id WHERE ITEM_CODE = '" & GRIDDESCRIPTION.Item(dgcmbitemcode.Index, e.RowIndex).EditedFormattedValue & "' AND LEDGER_CODE = '" & cmbcode.Text.Trim & "'", tempconn)
                        da = New OleDbDataAdapter(tempcmd)
                        da.Fill(NEWDT)
                        If NEWDT.Rows.Count > 0 Then
                            GRIDDESCRIPTION.Item(dgwastage.Index, e.RowIndex).Value = Format(Val(NEWDT.Rows(0).Item("WASTAGE")), "0.00")
                            GRIDDESCRIPTION.Item(dglabour.Index, e.RowIndex).Value = Format(Val(NEWDT.Rows(0).Item("LABOUR")), "0.00")
                        End If

                        'If cmb.Items.IndexOf(value) = -1 Then
                        '    cmb.Items.Add(value)
                        '    Dim cmbCol As DataGridViewComboBoxColumn = CType(grid.Columns(grid.CurrentCell.ColumnIndex), DataGridViewComboBoxColumn)
                        '    If Not cmbCol Is Nothing Then
                        '        cmbCol.Items.Add(value)
                        '    End If
                        'End If
                        'grid.CurrentCell.Value = value
                    End If

                End If

            End If
        End If


        If e.ColumnIndex <> dgcmbitemcode.Index And e.ColumnIndex <> DGITEMDESC.Index Then
            Dim strName As String = GRIDDESCRIPTION.Columns(e.ColumnIndex).Name
            If String.IsNullOrEmpty(e.FormattedValue.ToString) Then
                GRIDDESCRIPTION.CurrentCell.Value = 0.0
                Return
            End If
            Select Case strName

                Case "dggrosswt"
                    Dim dDebit As Decimal
                    Dim bValid As Boolean = Decimal.TryParse(e.FormattedValue.ToString, dDebit)

                    If bValid Then
                        GRIDDESCRIPTION.CurrentCell.Value = Convert.ToDecimal(GRIDDESCRIPTION.Item(dggrosswt.Index, e.RowIndex).Value)
                        If GRIDDESCRIPTION.Enabled = True Then
                            total()
                        End If
                    Else
                        MessageBox.Show("Invalid number")
                        e.Cancel = True
                    End If

                Case "DGLESSWT"
                    Dim dDebit As Decimal
                    Dim bValid As Boolean = Decimal.TryParse(e.FormattedValue.ToString, dDebit)

                    If bValid Then
                        GRIDDESCRIPTION.CurrentCell.Value = Convert.ToDecimal(GRIDDESCRIPTION.Item(DGLESSWT.Index, e.RowIndex).Value)
                        If GRIDDESCRIPTION.Enabled = True Then
                            total()
                        End If
                    Else
                        MessageBox.Show("Invalid number")
                        e.Cancel = True
                    End If

                Case "DGNETTWT"
                    Dim dDebit As Decimal
                    Dim bValid As Boolean = Decimal.TryParse(e.FormattedValue.ToString, dDebit)

                    If bValid Then
                        GRIDDESCRIPTION.CurrentCell.Value = Convert.ToDecimal(GRIDDESCRIPTION.Item(DGNETTWT.Index, e.RowIndex).Value)
                        If GRIDDESCRIPTION.Enabled = True Then
                            total()
                        End If
                    Else
                        MessageBox.Show("Invalid number")
                        e.Cancel = True
                    End If

                Case "dgpurity"
                    Dim dDebit As Decimal
                    Dim bValid As Boolean = Decimal.TryParse(e.FormattedValue.ToString, dDebit)

                    If bValid Then
                        GRIDDESCRIPTION.CurrentCell.Value = Convert.ToDecimal(GRIDDESCRIPTION.Item(dgpurity.Index, e.RowIndex).Value)
                        ' everything is good
                        If GRIDDESCRIPTION.Enabled = True Then
                            total()
                        End If
                    Else
                        MessageBox.Show("Invalid number")
                        e.Cancel = True
                    End If

                Case "dgwastage"
                    Dim dDebit As Decimal
                    Dim bValid As Boolean = Decimal.TryParse(e.FormattedValue.ToString, dDebit)

                    If bValid Then
                        GRIDDESCRIPTION.CurrentCell.Value = Convert.ToDecimal(GRIDDESCRIPTION.Item(dgwastage.Index, e.RowIndex).Value)
                        ' everything is good
                        If GRIDDESCRIPTION.Enabled = True Then
                            total()
                        End If
                    Else
                        MessageBox.Show("Invalid number")
                        e.Cancel = True
                    End If

                Case "DGFINEWT"
                    Dim dDebit As Decimal
                    Dim bValid As Boolean = Decimal.TryParse(e.FormattedValue.ToString, dDebit)

                    If bValid Then
                        GRIDDESCRIPTION.CurrentCell.Value = Convert.ToDecimal(GRIDDESCRIPTION.Item(DGFINEWT.Index, e.RowIndex).Value)
                        ' everything is good
                        If GRIDDESCRIPTION.Enabled = True Then
                            total()
                        End If
                    Else
                        MessageBox.Show("Invalid number")
                        e.Cancel = True
                    End If

                Case "dglabour"
                    Dim dDebit As Decimal
                    Dim bValid As Boolean = Decimal.TryParse(e.FormattedValue.ToString, dDebit)

                    If bValid Then
                        GRIDDESCRIPTION.CurrentCell.Value = Convert.ToDecimal(GRIDDESCRIPTION.Item(dglabour.Index, e.RowIndex).Value)
                        ' everything is good
                        If GRIDDESCRIPTION.Enabled = True Then
                            total()
                        End If
                    Else
                        MessageBox.Show("Invalid number")
                        e.Cancel = True
                    End If
                Case "dgpieces"
                    Dim dDebit As Decimal
                    Dim bValid As Boolean = Decimal.TryParse(e.FormattedValue.ToString, dDebit)

                    If bValid Then
                        GRIDDESCRIPTION.CurrentCell.Value = Convert.ToDecimal(GRIDDESCRIPTION.Item(dgpieces.Index, e.RowIndex).Value)
                        ' everything is good
                        If GRIDDESCRIPTION.Enabled = True Then
                            total()
                        End If
                    Else
                        MessageBox.Show("Invalid number")
                        e.Cancel = True
                    End If

                Case "dgbullion"
                    Dim dDebit As Decimal
                    Dim bValid As Boolean = Decimal.TryParse(e.FormattedValue.ToString, dDebit)

                    If bValid Then
                        GRIDDESCRIPTION.CurrentCell.Value = Convert.ToDecimal(GRIDDESCRIPTION.Item(dgBullion.Index, e.RowIndex).Value)
                        ' everything is good
                        If GRIDDESCRIPTION.Enabled = True Then
                            total()
                        End If
                    Else
                        MessageBox.Show("Invalid number")
                        e.Cancel = True
                    End If

                Case "dgamt"
                    Dim dDebit As Decimal
                    Dim bValid As Boolean = Decimal.TryParse(e.FormattedValue.ToString, dDebit)

                    If bValid Then
                        If GRIDDESCRIPTION.Enabled = True Then
                            total()
                        End If
                        GRIDDESCRIPTION.CurrentCell.Value = Convert.ToDecimal(GRIDDESCRIPTION.Item(dgamt.Index, e.RowIndex).Value)

                        ' everything is good
                    Else
                        MessageBox.Show("Invalid number")
                        e.Cancel = True
                    End If
            End Select

        End If

    End Sub

    Sub total()

        lblamounttotal.Text = "0.00"
        LBLLESSWTTOTAL.Text = "0.000"
        LBLNETTWTTOTAL.Text = "0.000"
        LBLFINEWTTOTAL.Text = "0.000"
        lblgrosswttotal.Text = "0.000"
        lblpiecestotal.Text = "0"
        txtbalwt.Text = "0.000"
        txtbalamt.Text = "0.00"

        For Each row As DataGridViewRow In GRIDDESCRIPTION.Rows
            ' If row.Cells(0).Value <> Nothing Then
            lblamounttotal.Text = Format(Val(lblamounttotal.Text) + Val(row.Cells(dgamt.Index).Value), "0.00")
            LBLLESSWTTOTAL.Text = Format(Val(LBLLESSWTTOTAL.Text) + Val(row.Cells(DGLESSWT.Index).Value), "0.000")
            LBLNETTWTTOTAL.Text = Format(Val(LBLNETTWTTOTAL.Text) + Val(row.Cells(DGNETTWT.Index).Value), "0.000")
            LBLFINEWTTOTAL.Text = Format(Val(LBLFINEWTTOTAL.Text) + Val(row.Cells(DGFINEWT.Index).Value), "0.000")
            lblgrosswttotal.Text = Format(Val(lblgrosswttotal.Text) + Val(row.Cells(dggrosswt.Index).Value), "0.000")
            lblpiecestotal.Text = Format(Val(lblpiecestotal.Text) + Val(row.Cells(dgpieces.Index).Value), "0.000")
        Next

        txtbalamt.Text = Format(Val(TXTAMOUNT.Text) + Val(lblamounttotal.Text) - (Val(txtcashrec.Text)), "0.00")
        txtbalwt.Text = Format(Val(LBLFINEWTTOTAL.Text) - Val(txtbhavcut.Text), "0.000")

    End Sub

    Private Sub griddescription_CurrentCellDirtyStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GRIDDESCRIPTION.CurrentCellDirtyStateChanged
        If GRIDDESCRIPTION.IsCurrentCellDirty Then
            GRIDDESCRIPTION.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Sub griddescription_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles GRIDDESCRIPTION.EditingControlShowing
        If (TypeOf e.Control Is DataGridViewComboBoxEditingControl) Then
            Dim cmb As DataGridViewComboBoxEditingControl = CType(e.Control, DataGridViewComboBoxEditingControl)
            If Not cmb Is Nothing Then
                cmb.DropDownStyle = ComboBoxStyle.DropDown
            End If
        End If
        m_EditingRow = GRIDDESCRIPTION.CurrentRow.Index
    End Sub

    Private Sub griddescription_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDDESCRIPTION.KeyDown
        If e.KeyCode = Keys.Delete Then
            If GRIDDESCRIPTION.Rows(GRIDDESCRIPTION.CurrentRow.Index).IsNewRow <> True Then GRIDDESCRIPTION.Rows.RemoveAt(GRIDDESCRIPTION.CurrentRow.Index)
            ' total()
        End If

        If e.KeyCode = Keys.F12 Then
            If GRIDDESCRIPTION.CurrentRow.Index - 1 < 0 Then Exit Sub
            If IsDBNull(GRIDDESCRIPTION.Rows(GRIDDESCRIPTION.CurrentRow.Index - 1).Cells(DGITEMDESC.Index).Value) = False Then
                GRIDDESCRIPTION.Rows(GRIDDESCRIPTION.CurrentRow.Index).Cells(DGITEMDESC.Index).Value = GRIDDESCRIPTION.Rows(GRIDDESCRIPTION.CurrentRow.Index - 1).Cells(DGITEMDESC.Index).Value
            End If
        End If

        If e.KeyCode = Keys.Return Then
            On Error Resume Next
            Dim cur_cell As DataGridViewCell = GRIDDESCRIPTION.CurrentCell
            Dim col As Integer = cur_cell.ColumnIndex

            If col = GRIDDESCRIPTION.Columns.Count - 1 And GRIDDESCRIPTION.CurrentRow.Index < GRIDDESCRIPTION.RowCount - 1 Then
                cur_cell = GRIDDESCRIPTION.Rows(GRIDDESCRIPTION.CurrentRow.Index + 1).Cells(dgcmbitemcode.Index)
            Else
                col = (col + 1) Mod GRIDDESCRIPTION.Columns.Count
                cur_cell = GRIDDESCRIPTION.CurrentRow.Cells(col)
            End If

            GRIDDESCRIPTION.CurrentCell = cur_cell

            e.Handled = True
        End If

        If e.KeyCode = Keys.F2 Then
            If GRIDDESCRIPTION.CurrentCell.ColumnIndex = dgcmbitemcode.Index Then
                Dim OBJITEM As New SelectItem
                OBJITEM.ShowDialog()
                GRIDDESCRIPTION.CurrentCell.Value = OBJITEM.TEMPCODE
            End If
        End If

    End Sub

    Private Sub griddescription_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GRIDDESCRIPTION.SelectionChanged

        If m_EditingRow >= 0 Then
            Dim new_row As Integer = m_EditingRow
            m_EditingRow = -1
            GRIDDESCRIPTION.CurrentCell = GRIDDESCRIPTION.Rows(new_row).Cells(GRIDDESCRIPTION.CurrentCell.ColumnIndex)
        End If
        'total()
    End Sub

    Private Sub cmbtype_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbtype.GotFocus
        enabilitytrue()

        txtbalwt.Text = "0.000"
        txtbalamt.Text = "0.00"
        txtbhavcut.Text = "0.000"
        txtperwt.Text = "0.000"
        txtrate.Text = "0.00"
        TXTAMOUNT.Text = "0.00"
        txtcashrec.Text = "0.00"
        lblgrosswttotal.Text = "0.000"
        lblamounttotal.Text = "0.00"
        LBLFINEWTTOTAL.Text = "0.000"
    End Sub

    Sub enabilitytrue()
        txtnarration.Enabled = True
        txtbhavcut.Enabled = True
        txtperwt.Enabled = True
        txtpurity.Enabled = True
        txtrate.Enabled = True
        TXTAMOUNT.Enabled = True
        txtcashrec.Enabled = True
        txtbalwt.Enabled = True
        txtbalamt.Enabled = True
        cmbtype.Enabled = True
        cmbcode.Enabled = True
    End Sub

    Sub adding(ByVal KHATADATE As Date)

        If cmbcode.Text.Trim <> "" And cmbcode.Enabled = True And txtbillno.Text.Trim <> "" Then
            If cmbtype.Text = "Chitti Invoice" Or cmbtype.Text = "Chitti Reciept" Then
                EDIT = False
                'clearing array
                For i = 1 To 100
                    tempcol(i) = ""
                    tempval(i) = ""
                Next
                tempcmd = New OleDbCommand("select max(voucher_id) from vouchers", tempconn)

                If tempconn.State = ConnectionState.Open Then
                    tempconn.Close()
                End If
                tempconn.Open()
                tempdr = tempcmd.ExecuteReader
                If tempdr.HasRows Then
                    tempdr.Read()
                    TEMPBILLNO = Val(tempdr(0).ToString)
                    TEMPBILLNO = Val(TEMPBILLNO) + 1
                End If
                tempconn.Close()
                tempdr.Close()


                For i = 0 To GRIDDESCRIPTION.RowCount - 2

                    tempcol(0) = "voucher_id"
                    tempcol(1) = "voucher_date"
                    tempcol(2) = "voucher_ledgerid"
                    tempcol(3) = "voucher_itemid"
                    tempcol(4) = "voucher_grosswt"
                    tempcol(5) = "voucher_purity"
                    tempcol(6) = "voucher_wastage"
                    tempcol(7) = "voucher_nettwt"
                    tempcol(8) = "voucher_labour"
                    tempcol(9) = "voucher_pieces"
                    tempcol(10) = "voucher_bullion"
                    tempcol(11) = "voucher_amount"
                    tempcol(12) = "voucher_bhavcut"
                    tempcol(13) = "voucher_goldrate"
                    tempcol(14) = "voucher_perwt"
                    tempcol(15) = "voucher_othercharge"
                    tempcol(16) = "voucher_balancewt"
                    tempcol(17) = "voucher_amt"
                    tempcol(18) = "voucher_totalamt"
                    tempcol(19) = "voucher_cashrecieved"
                    tempcol(20) = "voucher_balance"
                    tempcol(21) = "voucher_balorjamaorpaid"
                    tempcol(22) = "voucher_totalgrosswt"
                    tempcol(23) = "voucher_totalnettwt"
                    tempcol(24) = "voucher_narration"
                    tempcol(25) = "voucher_type"
                    tempcol(26) = "voucher_addtotal"
                    tempcol(27) = "voucher_lesstotal"
                    tempcol(28) = "voucher_inwords"
                    tempcol(29) = "voucher_crdays"
                    tempcol(30) = "voucher_expenseid"
                    tempcol(31) = "voucher_expmemo"
                    tempcol(32) = "voucher_expamt"
                    tempcol(33) = "voucher_lessid"
                    tempcol(34) = "voucher_lessmemo"
                    tempcol(35) = "voucher_lessamt"
                    tempcol(36) = "voucher_salesmenid"
                    tempcol(37) = "VOUCHER_ITEMDESC"
                    tempcol(38) = "VOUCHER_LESSWT"
                    tempcol(39) = "VOUCHER_DIFF"
                    tempcol(40) = "VOUCHER_USERID"
                    tempcol(41) = "VOUCHER_DEPARTMENTID"
                    tempcol(42) = "VOUCHER_GRIDSRNO"
                    tempcol(43) = "VOUCHER_STONERATE"
                    tempcol(44) = "VOUCHER_TOTALLABAMT"
                    tempcol(45) = "VOUCHER_TOTALSTONEAMT"
                    tempcol(46) = "VOUCHER_GROSSLESS"



                    tempval(0) = Val(TEMPBILLNO)
                    tempval(1) = "'" & Format(KHATADATE.Date, "dd/MM/yyyy") & "'"

                    'getting nameid
                    cmd = New OleDbCommand("select ledger_id,ledger_code from ledgermaster where ledger_code = '" & cmbcode.Text.Trim & "'", conn)
                    If conn.State = ConnectionState.Open Then
                        conn.Close()
                    End If
                    conn.Open()
                    dr = cmd.ExecuteReader()
                    If dr.HasRows Then
                        dr.Read()
                        tempval(2) = Val(dr(0))
                        tempnameid = dr(0)
                        tempname = dr(1).ToString
                    Else
                        tempval(2) = Val(0)
                    End If
                    conn.Close()

                    'getting itemid
                    cmd = New OleDbCommand("select item_id from itemmaster where item_code =  '" & GRIDDESCRIPTION.Item(dgcmbitemcode.Index, i).Value.ToString & "'", conn)
                    If conn.State = ConnectionState.Open Then
                        conn.Close()
                    End If
                    conn.Open()
                    dr = cmd.ExecuteReader()
                    If dr.HasRows Then
                        dr.Read()
                        tempval(3) = Val(dr(0))
                    Else
                        tempval(3) = Val(0)
                    End If
                    conn.Close()

                    tempval(4) = Val(GRIDDESCRIPTION.Item(dggrosswt.Index, i).Value)
                    tempval(5) = Val(GRIDDESCRIPTION.Item(dgpurity.Index, i).Value)
                    tempval(6) = Val(GRIDDESCRIPTION.Item(dgwastage.Index, i).Value)
                    tempval(7) = Val(GRIDDESCRIPTION.Item(DGFINEWT.Index, i).Value)
                    tempval(8) = Val(GRIDDESCRIPTION.Item(dglabour.Index, i).Value)
                    tempval(9) = Val(GRIDDESCRIPTION.Item(dgpieces.Index, i).Value)
                    tempval(10) = Val(GRIDDESCRIPTION.Item(dgBullion.Index, i).Value)
                    tempval(11) = Val(GRIDDESCRIPTION.Item(dgamt.Index, i).Value)


                    tempval(12) = Val(txtbhavcut.Text)
                    tempval(13) = Val(txtrate.Text)
                    tempval(14) = Val(txtperwt.Text)
                    tempval(15) = Val(0)
                    If i = 0 Then
                        tempval(16) = Val(txtbalwt.Text)
                        tempval(20) = Val(txtbalamt.Text)
                    Else
                        tempval(16) = Val(0)
                        tempval(20) = Val(0)
                    End If
                    tempval(17) = Val(TXTAMOUNT.Text)
                    tempval(18) = Val(lblamounttotal.Text)
                    tempval(19) = Val(txtcashrec.Text)



                    If cmbtype.Text = "Chitti Invoice" Then
                        tempval(21) = "'Balance'"
                    Else
                        tempval(21) = "'Jama'"
                    End If

                    tempval(22) = Val(lblgrosswttotal.Text)
                    tempval(23) = Val(LBLFINEWTTOTAL.Text)

                    tempval(24) = "'" & txtnarration.Text & "'"

                    If cmbtype.Text = "Chitti Invoice" Then
                        tempval(25) = "'I'"
                    Else
                        tempval(25) = "'R'"
                    End If
                    tempval(26) = Val(0)
                    tempval(27) = Val(0)
                    tempval(28) = "''"
                    tempval(29) = Val(0)
                    tempval(30) = Val(0)
                    tempval(31) = "'0'"
                    tempval(32) = Val(0)
                    tempval(33) = Val(0)
                    tempval(34) = "'0'"
                    tempval(35) = Val(0)


                    tempval(36) = Val(0)
                    If GRIDDESCRIPTION.Item(DGITEMDESC.Index, i).Value = Nothing Then tempval(37) = "''" Else tempval(37) = "'" & GRIDDESCRIPTION.Item(DGITEMDESC.Index, i).Value & "'"
                    tempval(38) = Val(GRIDDESCRIPTION.Item(DGLESSWT.Index, i).Value)
                    tempval(39) = "'0'"
                    tempval(40) = Val(USERID)
                    tempval(41) = Val(USERDEPARTMENTID)
                    tempval(42) = Val(i) + 1    'GRIDSRNO
                    tempval(43) = Val(0)
                    tempval(44) = Val(lblamounttotal.Text)
                    tempval(45) = Val(0)
                    tempval(46) = Val(GRIDDESCRIPTION.Item(DGNETTWT.Index, i).Value)

                    insert("vouchers", tempcol, tempval)

                Next

                For i = 1 To 50
                    tempcol(i) = ""
                    tempval(i) = ""
                Next


                'adding data in accountmasrer
                If EDIT = True Then

                    cmd = New OleDbCommand("delete from accountmaster where account_voucherid = " & txtbillno.Text & " and account_type ='" & types & "'", conn)
                    If conn.State = ConnectionState.Open Then
                        conn.Close()
                    End If

                    conn.Open()
                    cmd.ExecuteNonQuery()
                    conn.Close()

                End If
                tempcol(0) = "account_date"
                tempcol(1) = "account_ledgerid"
                tempcol(2) = "account_grosswt"
                tempcol(3) = "account_nettwt"
                tempcol(4) = "account_amount"
                tempcol(5) = "account_narration"
                tempcol(6) = "account_balorjamaorpaid"
                tempcol(7) = "account_voucherid"
                tempcol(8) = "account_type"
                tempcol(9) = "account_ledgercode"
                tempcol(10) = "account_USERID"
                tempcol(11) = "account_DEPARTMENTID"
                tempcol(12) = "account_PROCESS"
                tempcol(13) = "account_GROSSLESS"
                tempcol(14) = "account_LESSWT"


                If Val(Val(LBLFINEWTTOTAL.Text) - Val(txtbhavcut.Text)) <> "0" And Val(TXTAMOUNT.Text) = "0" Then

                    tempval(0) = "'" & Format(KHATADATE.Date, "dd/MM/yyyy") & "'"
                    tempval(1) = tempnameid
                    tempval(2) = Format(Val(lblgrosswttotal.Text), "0.000")
                    tempval(3) = Format(Val(LBLFINEWTTOTAL.Text), "0.000")
                    tempval(4) = Format(Val(lblamounttotal.Text), "0.00")
                    tempval(5) = "'" & txtnarration.Text & "'"

                    If cmbtype.Text = "Chitti Invoice" Then
                        tempval(6) = "'Balance'"
                    Else
                        tempval(6) = "'Jama'"
                    End If

                    tempval(7) = TEMPBILLNO
                    tempval(8) = "'" & types & "'"
                    tempval(9) = "'" & tempname & "'"
                    tempval(10) = Val(USERID)
                    tempval(11) = Val(USERDEPARTMENTID)
                    tempval(12) = "'" & CMBPROCESS.Text.Trim & "'"
                    tempval(13) = Format(Val(LBLNETTWTTOTAL.Text), "0.000")
                    tempval(14) = Format(Val(LBLLESSWTTOTAL.Text), "0.000")

                    insert("accountmaster", tempcol, tempval)

                    If Val(lblamounttotal.Text) <> "0" Then

                        tempval(0) = "'" & Format(KHATADATE.Date, "dd/MM/yyyy") & "'"
                        tempval(1) = tempnameid
                        tempval(2) = 0
                        tempval(3) = 0
                        tempval(4) = Format(Val(lblamounttotal.Text), "0.00")
                        tempval(5) = "'" & txtnarration.Text & "'"

                        If cmbtype.Text = "Chitti Invoice" Then
                            tempval(6) = "'Jama'"
                        Else
                            tempval(6) = "'Balance'"
                        End If

                        tempval(7) = TEMPBILLNO
                        tempval(8) = "'" & types & "'"
                        tempval(9) = "'Labour'"
                        tempval(10) = Val(USERID)
                        tempval(11) = Val(USERDEPARTMENTID)
                        tempval(12) = "'" & CMBPROCESS.Text.Trim & "'"
                        tempval(13) = 0
                        tempval(14) = 0

                        insert("accountmaster", tempcol, tempval)

                    End If
                End If


                If Val(Val(LBLFINEWTTOTAL.Text) - Val(txtbhavcut.Text)) = "0" Then

                    tempval(0) = "'" & Format(KHATADATE.Date, "dd/MM/yyyy") & "'"
                    tempval(1) = tempnameid
                    tempval(2) = Format(Val(lblgrosswttotal.Text), "0.000")
                    tempval(3) = Format(Val(LBLFINEWTTOTAL.Text), "0.000")
                    tempval(4) = 0
                    tempval(5) = "'" & txtnarration.Text & "'"

                    If cmbtype.Text = "Chitti Invoice" Then
                        tempval(6) = "'Balance'"
                        tempval(9) = "'Sale'"
                    Else
                        tempval(6) = "'Jama'"
                        tempval(9) = "'Purchase'"
                    End If

                    tempval(7) = TEMPBILLNO
                    tempval(8) = "'" & types & "'"
                    tempval(10) = Val(USERID)
                    tempval(11) = Val(USERDEPARTMENTID)
                    tempval(12) = "'" & CMBPROCESS.Text.Trim & "'"
                    tempval(13) = Format(Val(LBLNETTWTTOTAL.Text), "0.000")
                    tempval(14) = Format(Val(LBLLESSWTTOTAL.Text), "0.000")

                    insert("accountmaster", tempcol, tempval)

                    'if labour is present then adding labour in issue of labour a/c
                    If Val(lblamounttotal.Text) <> "0" Then


                        tempval(0) = "'" & Format(KHATADATE.Date, "dd/MM/yyyy") & "'"
                        tempval(1) = tempnameid
                        tempval(2) = 0
                        tempval(3) = 0
                        tempval(4) = Format(Val(lblamounttotal.Text), "0.00")
                        tempval(5) = "'" & txtnarration.Text & "'"

                        If cmbtype.Text = "Chitti Invoice" Then
                            tempval(6) = "'Jama'"
                        Else
                            tempval(6) = "'Balance'"
                        End If

                        tempval(7) = TEMPBILLNO
                        tempval(8) = "'" & types & "'"
                        tempval(9) = "'Labour'"
                        tempval(10) = Val(USERID)
                        tempval(11) = Val(USERDEPARTMENTID)
                        tempval(12) = "'" & CMBPROCESS.Text.Trim & "'"
                        tempval(13) = 0
                        tempval(14) = 0

                        insert("accountmaster", tempcol, tempval)
                    End If


                    'adding amount in issue of purchase a/c without subtracting discount

                    tempval(0) = "'" & Format(KHATADATE.Date, "dd/MM/yyyy") & "'"
                    tempval(1) = tempnameid
                    tempval(2) = 0
                    tempval(3) = 0
                    tempval(4) = Format(Val(TXTAMOUNT.Text) + Val(lblamounttotal.Text), "0.00")
                    tempval(5) = "'" & txtnarration.Text & "'"

                    If cmbtype.Text = "Chitti Invoice" Then
                        tempval(6) = "'Jama'"
                        tempval(9) = "'Sale'"
                    Else
                        tempval(6) = "'Balance'"
                        tempval(9) = "'Purchase'"
                    End If

                    tempval(7) = TEMPBILLNO
                    tempval(8) = "'" & types & "'"
                    tempval(10) = Val(USERID)
                    tempval(11) = Val(USERDEPARTMENTID)
                    tempval(12) = "'" & CMBPROCESS.Text.Trim & "'"
                    tempval(13) = 0
                    tempval(14) = 0

                    insert("accountmaster", tempcol, tempval)
                End If


                'if there is any bhavcut and amount is present then ( bhavcut goes in purchase a/c of jama and issue of partyname )  and  ( amount goes in party's jama and issue of purchase a/c )  and  ( total gross and nett wt goes in part's jama ) and ( if labour is present it goes in name of labour a/c ) and ( in jama of party a/c )
                If Val(txtbhavcut.Text) <> "0" Then

                    'adding total gross and nett wt in jama of party's a/c
                    tempval(0) = "'" & Format(KHATADATE.Date, "dd/MM/yyyy") & "'"
                    tempval(1) = Val(tempnameid)
                    tempval(2) = Format(Val(lblgrosswttotal.Text), "0.000")
                    tempval(3) = Format(Val(LBLFINEWTTOTAL.Text), "0.000")
                    tempval(4) = Format(Val(lblamounttotal.Text), "0.00")
                    tempval(5) = "'" & txtnarration.Text & "'"

                    If cmbtype.Text = "Chitti Invoice" Then
                        tempval(6) = "'Balance'"
                    Else
                        tempval(6) = "'Jama'"
                    End If

                    tempval(7) = Val(TEMPBILLNO)
                    tempval(8) = "'" & types & "'"
                    tempval(9) = "'" & tempname & "'"
                    tempval(10) = Val(USERID)
                    tempval(11) = Val(USERDEPARTMENTID)
                    tempval(12) = "'" & CMBPROCESS.Text.Trim & "'"
                    tempval(13) = Format(Val(LBLNETTWTTOTAL.Text), "0.000")
                    tempval(14) = Format(Val(LBLLESSWTTOTAL.Text), "0.000")

                    insert("accountmaster", tempcol, tempval)

                    'if labour is present it goes in issue of labour a/c
                    If Val(lblamounttotal.Text) <> "0" Then

                        tempval(0) = "'" & Format(KHATADATE.Date, "dd/MM/yyyy") & "'"
                        tempval(1) = tempnameid
                        tempval(2) = 0
                        tempval(3) = 0
                        tempval(4) = Format(Val(lblamounttotal.Text), "0.00")
                        tempval(5) = "'" & txtnarration.Text & "'"

                        If cmbtype.Text = "Chitti Invoice" Then
                            tempval(6) = "'Jama'"
                        Else
                            tempval(6) = "'Balance'"
                        End If

                        tempval(7) = TEMPBILLNO
                        tempval(8) = "'" & types & "'"
                        tempval(9) = "'Labour'"
                        tempval(10) = Val(USERID)
                        tempval(11) = Val(USERDEPARTMENTID)
                        tempval(12) = "'" & CMBPROCESS.Text.Trim & "'"
                        tempval(13) = 0
                        tempval(14) = 0

                        insert("accountmaster", tempcol, tempval)

                    End If

                    'adding bhavcut in jama of purchase a/c


                    tempval(0) = "'" & Format(KHATADATE.Date, "dd/MM/yyyy") & "'"
                    tempval(1) = tempnameid
                    tempval(2) = Format(Val(txtbhavcut.Text), "0.000")
                    tempval(3) = Format(Val(txtbhavcut.Text), "0.000")
                    tempval(4) = 0
                    tempval(5) = "'" & txtnarration.Text & "'"

                    If cmbtype.Text = "Chitti Invoice" Then
                        ' tempval(9) = "'Sale'"
                        tempval(6) = "'Jama'"

                    Else
                        ' tempval(9) = "'Purchase'"
                        tempval(6) = "'Balance'"

                    End If

                    tempval(7) = TEMPBILLNO
                    tempval(8) = "'" & types & "'"
                    tempval(9) = "'" & tempname & "'"
                    tempval(10) = Val(USERID)
                    tempval(11) = Val(USERDEPARTMENTID)
                    tempval(12) = "'" & CMBPROCESS.Text.Trim & "'"
                    tempval(13) = 0
                    tempval(14) = 0

                    insert("accountmaster", tempcol, tempval)


                    If Val(0) <= Val(TXTAMOUNT.Text) Then

                        'adding amt in jama of party's a/c by subtracting discount

                        tempval(0) = "'" & Format(KHATADATE.Date, "dd/MM/yyyy") & "'"
                        tempval(1) = tempnameid
                        tempval(2) = 0
                        tempval(3) = 0
                        tempval(4) = Format(Val(TXTAMOUNT.Text) - Val(0), "0.00")
                        tempval(5) = "'" & txtnarration.Text & "'"

                        If cmbtype.Text = "Chitti Invoice" Then
                            tempval(6) = "'Balance'"
                        Else
                            tempval(6) = "'Jama'"
                        End If

                        tempval(7) = TEMPBILLNO
                        tempval(8) = "'" & types & "'"
                        tempval(9) = "'" & tempname & "'"
                        tempval(10) = Val(USERID)
                        tempval(11) = Val(USERDEPARTMENTID)
                        tempval(12) = "'" & CMBPROCESS.Text.Trim & "'"
                        tempval(13) = 0
                        tempval(14) = 0

                        insert("accountmaster", tempcol, tempval)

                        'if discount is greater than amount then amount goes in issue
                    ElseIf Val(0) > Val(lblamounttotal.Text) + Val(TXTAMOUNT.Text) Then

                        tempval(0) = "'" & Format(KHATADATE.Date, "dd/MM/yyyy") & "'"
                        tempval(1) = tempnameid
                        tempval(2) = 0
                        tempval(3) = 0
                        tempval(4) = Format(Val(0) - Val(TXTAMOUNT.Text), "0.00")
                        tempval(5) = "'" & txtnarration.Text & "'"

                        If cmbtype.Text = "Chitti Invoice" Then
                            tempval(6) = "'Jama'"
                            tempval(9) = "'Sale'"
                        Else
                            tempval(6) = "'Balance'"
                            tempval(9) = "'Purchase'"
                        End If

                        tempval(7) = TEMPBILLNO
                        tempval(8) = "'" & types & "'"
                        tempval(10) = Val(USERID)
                        tempval(11) = Val(USERDEPARTMENTID)
                        tempval(12) = "'" & CMBPROCESS.Text.Trim & "'"
                        tempval(13) = 0
                        tempval(14) = 0

                        insert("accountmaster", tempcol, tempval)

                    End If
                End If


                'if cashpaid is present then cash goes in issue of party a/c
                If Val(txtcashrec.Text) <> "0" Then

                    'adding values in issue of party a/c

                    tempval(0) = "'" & Format(KHATADATE.Date, "dd/MM/yyyy") & "'"
                    tempval(1) = tempnameid
                    tempval(2) = 0
                    tempval(3) = 0
                    tempval(4) = Format(Val(txtcashrec.Text), "0.00")
                    tempval(5) = "'" & txtnarration.Text & "'"

                    If cmbtype.Text = "Chitti Invoice" Then
                        tempval(6) = "'Jama'"
                        tempval(9) = "'Sale'"
                    Else
                        tempval(6) = "'Balance'"
                        tempval(9) = "'Purchase'"
                    End If

                    tempval(7) = TEMPBILLNO
                    tempval(8) = "'" & types & "'"
                    tempval(10) = Val(USERID)
                    tempval(11) = Val(USERDEPARTMENTID)
                    tempval(12) = "'" & CMBPROCESS.Text.Trim & "'"
                    tempval(13) = 0
                    tempval(14) = 0

                    insert("accountmaster", tempcol, tempval)

                End If


            ElseIf cmbtype.Text = "Invoice" Or cmbtype.Text = "Reciept" Then

                For i = 1 To 50
                    tempcol(i) = ""
                    tempval(i) = ""
                Next
                If EDIT = True Then
                    cmd = New OleDbCommand("select * from accountmaster where account_id = " & txtbillno.Text & " and account_type ='" & types & "'", conn)
                    If conn.State = ConnectionState.Open Then
                        conn.Close()
                    End If
                    conn.Open()
                    dr = cmd.ExecuteReader
                    If dr.HasRows = True Then
                        tempcmd = New OleDbCommand("delete from accountmaster where account_id = " & txtbillno.Text & " and account_type ='" & types & "'", tempconn)
                        If tempconn.State = ConnectionState.Open Then
                            tempconn.Close()
                        End If

                        tempconn.Open()
                        tempcmd.ExecuteNonQuery()
                        tempconn.Close()
                    End If
                    dr.Close()
                    conn.Close()
                    EDIT = False
                End If

                tempcol(0) = "account_id"
                tempcol(1) = "account_date"
                tempcol(2) = "account_ledgerid"
                tempcol(3) = "account_itemid"
                tempcol(4) = "account_purity"
                tempcol(5) = "account_wastage"
                tempcol(6) = "account_grosswt"
                tempcol(7) = "account_nettwt"
                tempcol(8) = "account_amount"
                tempcol(9) = "account_balorjamaorpaid"
                tempcol(10) = "account_narration"
                tempcol(11) = "account_type"
                tempcol(12) = "account_ledgercode"
                tempcol(13) = "account_voucherid"
                tempcol(14) = "account_BULLION"
                tempcol(15) = "account_ITEMDESC"
                tempcol(16) = "account_USERID"
                tempcol(17) = "account_DEPARTMENTID"
                tempcol(18) = "account_PROCESS"
                tempcol(19) = "account_GROSSLESS"
                tempcol(20) = "account_LESSWT"

                For i = 0 To GRIDDESCRIPTION.RowCount - 2

                    If Val(GRIDDESCRIPTION.Item(dggrosswt.Index, i).Value) = 0 And Val(GRIDDESCRIPTION.Item(DGFINEWT.Index, i).Value) = 0 And Val(GRIDDESCRIPTION.Item(dgamt.Index, i).Value) = 0 Then GoTo LINE1
                    If ClientName = "KANAK" And Val(GRIDDESCRIPTION.Item(dgpurity.Index, i).Value) = 0 Then GoTo LINE1


                    'CHECKING DUPLICATION ENTRY AS PER BHARAT BHAI
                    If ClientName = "JAINAM" Or ClientName = "KANAK" Then
                        If cmbtype.Text = "Invoice" Then
                            cmd = New OleDbCommand("select * from accountmaster INNER JOIN ITEMMASTER ON ACCOUNTMASTER.ACCOUNT_ITEMID = ITEMMASTER.ITEM_ID where account_type ='" & types & "' AND ITEMMASTER.ITEM_CODE = '" & GRIDDESCRIPTION.Item(dgcmbitemcode.Index, i).Value & "' and ACCOUNT_GROSSWT = " & Format(Val(GRIDDESCRIPTION.Item(dggrosswt.Index, i).Value), "0.000") & " AND ACCOUNT_PURITY = " & Format(Val(GRIDDESCRIPTION.Item(dgpurity.Index, i).Value), "0.00"), conn)
                        ElseIf cmbtype.Text = "Reciept" Then
                            cmd = New OleDbCommand("select * from accountmaster INNER JOIN ITEMMASTER ON ACCOUNTMASTER.ACCOUNT_ITEMID = ITEMMASTER.ITEM_ID where account_type ='" & types & "' and ITEMMASTER.ITEM_CODE = '" & GRIDDESCRIPTION.Item(dgcmbitemcode.Index, i).Value & "' AND ACCOUNT_DATE = #" & Format(KHATADATE.Date, "MM/dd/yyyy") & "# and ACCOUNT_GROSSWT = " & Format(Val(GRIDDESCRIPTION.Item(dggrosswt.Index, i).Value), "0.000") & " AND ACCOUNT_PURITY = " & Format(Val(GRIDDESCRIPTION.Item(dgpurity.Index, i).Value), "0.00"), conn)
                        End If
                        If conn.State = ConnectionState.Open Then conn.Close()
                        conn.Open()
                        dr = cmd.ExecuteReader
                        If dr.HasRows = True Then
                            dr.Read()
                            Dim TMSG As Integer = MsgBox("Duplicate Enrty, Previously done on " & Format(dr(1), "dd/MM/yyyy") & ", To Party " & dr("ACCOUNT_LEDGERCODE") & ", Wish to Proceed?", MsgBoxStyle.YesNo)
                            If TMSG = vbNo Then Exit Sub
                        End If
                        dr.Close()
                        conn.Close()
                    End If


                    tempcmd = New OleDbCommand("select max(account_id) from accountmaster", tempconn)
                    If tempconn.State = ConnectionState.Open Then tempconn.Close()
                    tempconn.Open()
                    tempdr = tempcmd.ExecuteReader
                    If tempdr.HasRows Then
                        tempdr.Read()
                        txtbillno.Text = Val(tempdr(0).ToString)
                        txtbillno.Text = Val(txtbillno.Text) + 1
                    End If
                    tempconn.Close()
                    tempdr.Close()
                    tempval(0) = Val(txtbillno.Text)
                    tempval(1) = "'" & Format(KHATADATE.Date, "dd/MM/yyyy") & "'"

                    'getting nameid
                    cmd = New OleDbCommand("select ledger_id,ledger_code from ledgermaster where ledger_code = '" & cmbcode.Text.Trim & "'", conn)
                    If conn.State = ConnectionState.Open Then
                        conn.Close()
                    End If
                    conn.Open()
                    dr = cmd.ExecuteReader()
                    If dr.HasRows Then
                        dr.Read()
                        tempval(2) = Val(dr(0))
                        tempnameid = dr(0)
                        tempname = dr(1).ToString
                    Else
                        tempval(2) = Val(0)
                    End If
                    conn.Close()

                    'getting itemid

                    cmd = New OleDbCommand("select item_id from itemmaster where item_code =  '" & GRIDDESCRIPTION.Item(dgcmbitemcode.Index, i).Value & "'", conn)
                    If conn.State = ConnectionState.Open Then
                        conn.Close()
                    End If
                    conn.Open()
                    dr = cmd.ExecuteReader()
                    If dr.HasRows Then
                        dr.Read()
                        tempval(3) = Val(dr(0))
                    Else
                        tempval(3) = Val(0)
                    End If
                    conn.Close()

                    tempval(4) = Val(GRIDDESCRIPTION.Item(dgpurity.Index, i).Value)
                    tempval(5) = Val(GRIDDESCRIPTION.Item(dgwastage.Index, i).Value)
                    tempval(6) = Val(GRIDDESCRIPTION.Item(dggrosswt.Index, i).Value)
                    tempval(7) = Val(GRIDDESCRIPTION.Item(DGFINEWT.Index, i).Value)
                    tempval(8) = Val(GRIDDESCRIPTION.Item(dgamt.Index, i).Value)


                    If cmbtype.Text = "Invoice" Then
                        tempval(9) = "'Balance'"
                    ElseIf cmbtype.Text = "Reciept" Then
                        tempval(9) = "'Jama'"
                    End If
                    tempval(10) = "'" & txtnarration.Text & "'"
                    tempval(11) = "'A'"
                    tempval(12) = "'" & cmbcode.Text & "'"
                    tempval(13) = Val(txtbillno.Text)
                    tempval(14) = Val(GRIDDESCRIPTION.Item(dgBullion.Index, i).Value)
                    If GRIDDESCRIPTION.Item(DGITEMDESC.Index, i).Value = Nothing Then
                        tempval(15) = "''"
                    Else
                        If GRIDDESCRIPTION.Item(DGITEMDESC.Index, i).Value = Nothing Then tempval(15) = "''" Else tempval(15) = "'" & GRIDDESCRIPTION.Item(DGITEMDESC.Index, i).Value & "'"
                    End If
                    tempval(16) = Val(USERID)
                    tempval(17) = Val(USERDEPARTMENTID)
                    tempval(18) = "'" & CMBPROCESS.Text.Trim & "'"
                    tempval(19) = Val(GRIDDESCRIPTION.Item(DGNETTWT.Index, i).Value)
                    tempval(20) = Val(GRIDDESCRIPTION.Item(DGLESSWT.Index, i).Value)

                    insert("accountmaster", tempcol, tempval)
LINE1:
                Next

            ElseIf cmbtype.Text = "Bhavcut On Rec Wt." Or cmbtype.Text = "Bhavcut On Inv Wt." Or cmbtype.Text = "Bhavcut On Rec Amt." Or cmbtype.Text = "Bhavcut On Inv Amt." Then
                For i = 1 To 100
                    tempcol(i) = ""
                    tempval(i) = ""
                Next

                If EDIT = True Then
                    cmd = New OleDbCommand("select * from accountmaster where account_id = " & txtbillno.Text & " and account_type ='" & types & "'", conn)
                    If conn.State = ConnectionState.Open Then
                        conn.Close()
                    End If
                    conn.Open()
                    dr = cmd.ExecuteReader
                    If dr.HasRows = True Then
                        tempcmd = New OleDbCommand("delete from accountmaster where account_id = " & txtbillno.Text & " and account_type ='" & types & "'", tempconn)
                        If tempconn.State = ConnectionState.Open Then
                            tempconn.Close()
                        End If

                        tempconn.Open()
                        tempcmd.ExecuteNonQuery()
                        tempconn.Close()
                    End If
                    dr.Close()
                    conn.Close()
                    EDIT = False
                End If

                For i = 0 To 3

                    tempcol(0) = "account_id"
                    tempcol(1) = "account_date"
                    tempcol(2) = "account_ledgerid"
                    tempcol(3) = "account_itemid"
                    tempcol(4) = "account_purity"
                    tempcol(5) = "account_wastage"
                    tempcol(6) = "account_grosswt"
                    tempcol(7) = "account_nettwt"
                    tempcol(8) = "account_amount"
                    tempcol(9) = "account_balorjamaorpaid"
                    tempcol(10) = "account_narration"
                    tempcol(11) = "account_type"
                    tempcol(12) = "account_ledgercode"
                    tempcol(13) = "account_voucherid"
                    tempcol(14) = "account_subtype"
                    tempcol(15) = "account_USERID"
                    tempcol(16) = "account_DEPARTMENTID"
                    tempcol(17) = "account_PROCESS"
                    tempcol(18) = "account_GROSSLESS"
                    tempcol(19) = "account_LESSWT"

                    tempval(0) = Val(txtbillno.Text)
                    tempval(1) = "'" & Format(KHATADATE.Date, "dd/MM/yyyy") & "'"


                    tempval(3) = Val(0)
                    tempval(4) = Val(txtpurity.Text.Trim)
                    tempval(5) = Val(0)

                    If cmbtype.Text = "Bhavcut On Rec Wt." Or cmbtype.Text = "Bhavcut On Inv Amt." Then
                        If i = 0 Then
                            'getting nameid
                            cmd = New OleDbCommand("select ledger_id,ledger_code from ledgermaster where ledger_code = 'PURCHASE'", conn)
                            If conn.State = ConnectionState.Open Then
                                conn.Close()
                            End If
                            conn.Open()
                            dr = cmd.ExecuteReader()
                            If dr.HasRows Then
                                dr.Read()
                                tempval(2) = Val(dr(0))
                                tempnameid = dr(0)
                                tempname = dr(1).ToString
                            Else
                                tempval(2) = Val(0)
                            End If
                            conn.Close()
                            tempval(6) = Val(txtbhavcut.Text)
                            tempval(7) = Val(txtbhavcut.Text)
                            tempval(8) = Val(0)
                            tempval(9) = "'Jama'"
                            tempval(12) = "'Purchase'"
                        ElseIf i = 1 Then
                            'getting nameid
                            cmd = New OleDbCommand("select ledger_id,ledger_code from ledgermaster where ledger_code = '" & cmbcode.Text.Trim & "'", conn)
                            If conn.State = ConnectionState.Open Then
                                conn.Close()
                            End If
                            conn.Open()
                            dr = cmd.ExecuteReader()
                            If dr.HasRows Then
                                dr.Read()
                                tempval(2) = Val(dr(0))
                                tempnameid = dr(0)
                                tempname = dr(1).ToString
                            Else
                                tempval(2) = Val(0)
                            End If
                            conn.Close()
                            tempval(6) = Val(txtbhavcut.Text)
                            tempval(7) = Val(txtbhavcut.Text)
                            tempval(8) = Val(0)
                            tempval(9) = "'Balance'"
                            tempval(12) = "'" & cmbcode.Text.Trim & "'"
                        ElseIf i = 2 Then
                            'getting nameid
                            cmd = New OleDbCommand("select ledger_id,ledger_code from ledgermaster where ledger_code = '" & cmbcode.Text.Trim & "'", conn)
                            If conn.State = ConnectionState.Open Then
                                conn.Close()
                            End If
                            conn.Open()
                            dr = cmd.ExecuteReader()
                            If dr.HasRows Then
                                dr.Read()
                                tempval(2) = Val(dr(0))
                                tempnameid = dr(0)
                                tempname = dr(1).ToString
                            Else
                                tempval(2) = Val(0)
                            End If
                            conn.Close()
                            tempval(6) = Val(0)
                            tempval(7) = Val(0)
                            tempval(8) = Val(TXTAMOUNT.Text)
                            tempval(9) = "'Jama'"
                            tempval(12) = "'" & cmbcode.Text.Trim & "'"
                        ElseIf i = 3 Then
                            'getting nameid
                            cmd = New OleDbCommand("select ledger_id,ledger_code from ledgermaster where ledger_code = 'PURCHASE'", conn)
                            If conn.State = ConnectionState.Open Then
                                conn.Close()
                            End If
                            conn.Open()
                            dr = cmd.ExecuteReader()
                            If dr.HasRows Then
                                dr.Read()
                                tempval(2) = Val(dr(0))
                                tempnameid = dr(0)
                                tempname = dr(1).ToString
                            Else
                                tempval(2) = Val(0)
                            End If
                            conn.Close()
                            tempval(6) = Val(0)
                            tempval(7) = Val(0)
                            tempval(8) = Val(TXTAMOUNT.Text)
                            tempval(9) = "'Balance'"
                            tempval(12) = "'Purchase'"
                        End If
                    ElseIf cmbtype.Text = "Bhavcut On Inv Wt." Or cmbtype.Text = "Bhavcut On Rec Amt." Then

                        If i = 0 Then
                            'getting nameid
                            cmd = New OleDbCommand("select ledger_id,ledger_code from ledgermaster where ledger_code = '" & cmbcode.Text.Trim & "'", conn)
                            If conn.State = ConnectionState.Open Then
                                conn.Close()
                            End If
                            conn.Open()
                            dr = cmd.ExecuteReader()
                            If dr.HasRows Then
                                dr.Read()
                                tempval(2) = Val(dr(0))
                                tempnameid = dr(0)
                                tempname = dr(1).ToString
                            Else
                                tempval(2) = Val(0)
                            End If
                            conn.Close()
                            tempval(6) = Val(txtbhavcut.Text)
                            tempval(7) = Val(txtbhavcut.Text)
                            tempval(8) = Val(0)
                            tempval(9) = "'Jama'"
                            tempval(12) = "'" & cmbcode.Text.Trim & "'"
                        ElseIf i = 1 Then
                            'getting nameid
                            cmd = New OleDbCommand("select ledger_id,ledger_code from ledgermaster where ledger_code = 'SALE'", conn)
                            If conn.State = ConnectionState.Open Then
                                conn.Close()
                            End If
                            conn.Open()
                            dr = cmd.ExecuteReader()
                            If dr.HasRows Then
                                dr.Read()
                                tempval(2) = Val(dr(0))
                                tempnameid = dr(0)
                                tempname = dr(1).ToString
                            Else
                                tempval(2) = Val(0)
                            End If
                            conn.Close()
                            tempval(6) = Val(txtbhavcut.Text)
                            tempval(7) = Val(txtbhavcut.Text)
                            tempval(8) = Val(0)
                            tempval(9) = "'Balance'"
                            tempval(12) = "'Sale'"
                        ElseIf i = 2 Then
                            'getting nameid
                            cmd = New OleDbCommand("select ledger_id,ledger_code from ledgermaster where ledger_code = 'SALE'", conn)
                            If conn.State = ConnectionState.Open Then
                                conn.Close()
                            End If
                            conn.Open()
                            dr = cmd.ExecuteReader()
                            If dr.HasRows Then
                                dr.Read()
                                tempval(2) = Val(dr(0))
                                tempnameid = dr(0)
                                tempname = dr(1).ToString
                            Else
                                tempval(2) = Val(0)
                            End If
                            conn.Close()
                            tempval(6) = Val(0)
                            tempval(7) = Val(0)
                            tempval(8) = Val(TXTAMOUNT.Text)
                            tempval(9) = "'Jama'"
                            tempval(12) = "'Sale'"
                        ElseIf i = 3 Then
                            'getting nameid
                            cmd = New OleDbCommand("select ledger_id,ledger_code from ledgermaster where ledger_code = '" & cmbcode.Text.Trim & "'", conn)
                            If conn.State = ConnectionState.Open Then
                                conn.Close()
                            End If
                            conn.Open()
                            dr = cmd.ExecuteReader()
                            If dr.HasRows Then
                                dr.Read()
                                tempval(2) = Val(dr(0))
                                tempnameid = dr(0)
                                tempname = dr(1).ToString
                            Else
                                tempval(2) = Val(0)
                            End If
                            conn.Close()
                            tempval(6) = Val(0)
                            tempval(7) = Val(0)
                            tempval(8) = Val(TXTAMOUNT.Text)
                            tempval(9) = "'Balance'"
                            tempval(12) = "'" & cmbcode.Text.Trim & "'"
                        End If
                    End If
                    tempval(10) = "'" & txtnarration.Text & "'"
                    tempval(11) = "'B'"

                    tempval(13) = Val(txtbillno.Text)
                    If cmbtype.Text = "Bhavcut On Rec Wt." Then
                        tempval(14) = "'RWT'"
                    ElseIf cmbtype.Text = "Bhavcut On Rec Amt." Then
                        tempval(14) = "'RAMT'"
                    ElseIf cmbtype.Text = "Bhavcut On Inv Wt." Then
                        tempval(14) = "'IWT'"
                    ElseIf cmbtype.Text = "Bhavcut On Inv Amt." Then
                        tempval(14) = "'IAMT'"
                    End If
                    tempval(15) = Val(USERID)
                    tempval(16) = Val(USERDEPARTMENTID)
                    tempval(17) = "'" & CMBPROCESS.Text.Trim & "'"
                    tempval(18) = Val(0)
                    tempval(19) = Val(0)

                    insert("accountmaster", tempcol, tempval)


                    'PARTY NAAME
                    'CASH JAMA
                    If Val(txtcashrec.Text.Trim) > 0 And i = 0 Then

                        For J As Integer = 0 To 20
                            tempcol(J) = ""
                            tempval(J) = ""
                        Next

                        'ADD IN ACCOUNTMASTER
                        tempcol(0) = "account_id"
                        tempcol(1) = "account_date"
                        tempcol(2) = "account_ledgerid"
                        tempcol(3) = "account_itemid"
                        tempcol(4) = "account_purity"
                        tempcol(5) = "account_wastage"
                        tempcol(6) = "account_grosswt"
                        tempcol(7) = "account_nettwt"
                        tempcol(8) = "account_amount"
                        tempcol(9) = "account_balorjamaorpaid"
                        tempcol(10) = "account_narration"
                        tempcol(11) = "account_type"
                        tempcol(12) = "account_ledgercode"
                        tempcol(13) = "account_voucherid"
                        tempcol(14) = "account_subtype"
                        tempcol(15) = "account_USERID"
                        tempcol(16) = "account_DEPARTMENTID"
                        tempcol(17) = "account_PROCESS"
                        tempcol(18) = "account_GROSSLESS"
                        tempcol(19) = "account_LESSWT"

                        'THIS IS EXTRA POSTING IF CASHPAID > 0
                        '   CASH JAMA

                        'POSTING FOR JAMA
                        '****************
                        tempval(0) = Val(txtbillno.Text)
                        tempval(1) = "'" & Format(KHATADATE.Date, "dd/MM/yyyy") & "'"

                        'getting LEDGERID
                        tempcmd = New OleDbCommand("select LEDGER_id from LEDGERMASTER where LEDGER_CODE = 'CASH'", tempconn)
                        If tempconn.State = ConnectionState.Open Then tempconn.Close()
                        tempconn.Open()
                        tempdr = tempcmd.ExecuteReader
                        If tempdr.HasRows Then
                            tempdr.Read()
                            tempval(2) = Val(tempdr(0))
                        Else
                            tempval(2) = 0
                        End If
                        tempconn.Close()
                        tempdr.Close()

                        tempval(3) = Val(0)
                        tempval(4) = Val(0)
                        tempval(5) = Val(0)
                        tempval(6) = Val(0)
                        tempval(7) = Val(0)
                        tempval(8) = Format(Val(txtcashrec.Text.Trim), "0.00")
                        If cmbtype.Text = "Bhavcut On Rec Wt." Or cmbtype.Text = "Bhavcut On Inv Amt." Then
                            tempval(9) = "'Jama'"
                        ElseIf cmbtype.Text = "Bhavcut On Inv Wt." Or cmbtype.Text = "Bhavcut On Rec Amt." Then
                            tempval(9) = "'Balance'"
                        End If
                        tempval(10) = "'" & txtnarration.Text & "'"
                        tempval(11) = "'B'"
                        tempval(12) = "'CASH'"

                        tempval(13) = Val(txtbillno.Text)
                        If cmbtype.Text = "Bhavcut On Rec Wt." Then
                            tempval(14) = "'RWT'"
                        ElseIf cmbtype.Text = "Bhavcut On Rec Amt." Then
                            tempval(14) = "'RAMT'"
                        ElseIf cmbtype.Text = "Bhavcut On Inv Wt." Then
                            tempval(14) = "'IWT'"
                        ElseIf cmbtype.Text = "Bhavcut On Inv Amt." Then
                            tempval(14) = "'IAMT'"
                        End If
                        tempval(15) = Val(USERID)
                        tempval(16) = Val(USERDEPARTMENTID)
                        tempval(17) = "'" & CMBPROCESS.Text.Trim & "'"
                        tempval(18) = Val(0)
                        tempval(19) = Val(0)


                        insert("accountmaster", tempcol, tempval)
                        '******** END OF CODE FOR JAMA **********


                        'POSTING FOR NAAME
                        '****************
                        tempval(0) = Val(txtbillno.Text)
                        tempval(1) = "'" & Format(KHATADATE.Date, "dd/MM/yyyy") & "'"

                        'getting LEDGERID
                        tempcmd = New OleDbCommand("select LEDGER_id from LEDGERMASTER where LEDGER_CODE = '" & cmbcode.Text.Trim & "'", tempconn)
                        If tempconn.State = ConnectionState.Open Then tempconn.Close()
                        tempconn.Open()
                        tempdr = tempcmd.ExecuteReader
                        If tempdr.HasRows Then
                            tempdr.Read()
                            tempval(2) = Val(tempdr(0))
                        Else
                            tempval(2) = 0
                        End If
                        tempconn.Close()
                        tempdr.Close()

                        tempval(3) = Val(0)
                        tempval(4) = Val(0)
                        tempval(5) = Val(0)
                        tempval(6) = Val(0)
                        tempval(7) = Val(0)
                        tempval(8) = Format(Val(txtcashrec.Text.Trim), "0.00")
                        If cmbtype.Text = "Bhavcut On Rec Wt." Or cmbtype.Text = "Bhavcut On Inv Amt." Then
                            tempval(9) = "'Balance'"
                        ElseIf cmbtype.Text = "Bhavcut On Inv Wt." Or cmbtype.Text = "Bhavcut On Rec Amt." Then
                            tempval(9) = "'Jama'"
                        End If
                        tempval(10) = "'" & txtnarration.Text & "'"
                        tempval(11) = "'B'"
                        tempval(12) = "'" & cmbcode.Text.Trim & "'"

                        tempval(13) = Val(txtbillno.Text)
                        If cmbtype.Text = "Bhavcut On Rec Wt." Then
                            tempval(14) = "'RWT'"
                        ElseIf cmbtype.Text = "Bhavcut On Rec Amt." Then
                            tempval(14) = "'RAMT'"
                        ElseIf cmbtype.Text = "Bhavcut On Inv Wt." Then
                            tempval(14) = "'IWT'"
                        ElseIf cmbtype.Text = "Bhavcut On Inv Amt." Then
                            tempval(14) = "'IAMT'"
                        End If
                        tempval(15) = Val(USERID)
                        tempval(16) = Val(USERDEPARTMENTID)
                        tempval(17) = "'" & CMBPROCESS.Text.Trim & "'"
                        tempval(18) = Val(0)
                        tempval(19) = Val(0)

                        insert("accountmaster", tempcol, tempval)
                        '******** END OF CODE FOR NAAME **********

                    End If


                Next

                For i = 1 To 50
                    tempcol(i) = ""
                    tempval(i) = ""
                Next
                cmd = New OleDbCommand("select * from bhavcutmaster where bhavcut_id = " & txtbillno.Text, conn)
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
                conn.Open()
                dr = cmd.ExecuteReader
                If dr.HasRows = True Then
                    tempcmd = New OleDbCommand("delete from bhavcutmaster where bhavcut_id = " & txtbillno.Text, tempconn)
                    If tempconn.State = ConnectionState.Open Then
                        tempconn.Close()
                    End If

                    tempconn.Open()
                    tempcmd.ExecuteNonQuery()
                    tempconn.Close()
                End If
                dr.Close()
                conn.Close()


                tempcol(0) = "bhavcut_id"
                tempcol(1) = "bhavcut_date"
                tempcol(2) = "bhavcut_type"
                tempcol(3) = "bhavcut_ledgerid"
                tempcol(4) = "bhavcut_itemid"
                tempcol(5) = "bhavcut_grosswt"
                tempcol(6) = "bhavcut_purity"
                tempcol(7) = "bhavcut_wastage"
                tempcol(8) = "bhavcut_nettwt"
                tempcol(9) = "bhavcut_amount"
                tempcol(10) = "bhavcut_bhavcut"

                tempcol(11) = "bhavcut_goldrate"
                tempcol(12) = "bhavcut_perwt"
                tempcol(13) = "bhavcut_totalamt"
                tempcol(14) = "bhavcut_cashreceived"
                tempcol(15) = "bhavcut_USERID"
                tempcol(16) = "bhavcut_DEPARTMENTID"

                tempval(0) = Val(txtbillno.Text)
                tempval(1) = "'" & Format(KHATADATE.Date, "dd/MM/yyyy") & "'"
                If cmbtype.Text = "Bhavcut On Rec Wt." Then
                    tempval(2) = "'RWT'"
                ElseIf cmbtype.Text = "Bhavcut On Rec Amt." Then
                    tempval(2) = "'RAMT'"
                ElseIf cmbtype.Text = "Bhavcut On Inv Wt." Then
                    tempval(2) = "'IWT'"
                ElseIf cmbtype.Text = "Bhavcut On Inv Amt." Then
                    tempval(2) = "'IAMT'"
                End If

                'getting nameid
                cmd = New OleDbCommand("select ledger_id,ledger_code from ledgermaster where ledger_code = '" & cmbcode.Text.Trim & "'", conn)
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
                conn.Open()
                dr = cmd.ExecuteReader()
                If dr.HasRows Then
                    dr.Read()
                    tempval(3) = Val(dr(0))
                    tempnameid = dr(0)
                    tempname = dr(1).ToString
                Else
                    tempval(3) = Val(0)
                End If
                conn.Close()

                tempval(4) = 0
                tempval(5) = 0
                tempval(6) = Val(txtpurity.Text.Trim)
                tempval(7) = 0
                tempval(8) = 0
                tempval(9) = 0
                tempval(10) = Val(txtbhavcut.Text)

                tempval(11) = Val(txtrate.Text)
                tempval(12) = Val(txtperwt.Text)
                tempval(13) = Val(TXTAMOUNT.Text)
                tempval(14) = Val(txtcashrec.Text)
                tempval(15) = Val(USERID)
                tempval(16) = Val(USERDEPARTMENTID)

                insert("bhavcutmaster", tempcol, tempval)


            End If


        End If
    End Sub

    Private Sub gridissue_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridissue.CellClick
        If gridissue.RowCount = 0 Then Exit Sub
        enabilityfalse()
        If gridjama.RowCount > 0 Then
            gridjama.Rows(gridjama.CurrentRow.Index).Selected = False
        End If
        txtbhavcut.Text = "0.000"
        TXTAMOUNT.Text = "0.00"
        txtperwt.Text = "0.00"
        txtpurity.Text = "0.00"
        txtrate.Text = "0.00"
        txtbalamt.Text = "0.00"
        txtbalwt.Text = "0.000"
        txtcashrec.Text = "0.00"
        If ClientName <> "MONOGRAM" And ClientName <> "ORIENTAL" Then GRIDDESCRIPTION.CurrentCell = GRIDDESCRIPTION.Rows(0).Cells(dggrosswt.Index)
        GRIDDESCRIPTION.RowCount = 1
        txtbillno.Text = Val(gridissue.Item(6, gridissue.CurrentRow.Index).Value)
        types = gridissue.Item(5, gridissue.CurrentRow.Index).Value.ToString
        If gridissue.Item(5, gridissue.CurrentRow.Index).Value.ToString = "A" Then
            cmbtype.SelectedIndex = (1)
        End If

        filldetails(gridissue)

    End Sub

    Private Sub gridissue_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridissue.CellDoubleClick
        If e.RowIndex = -1 Then Exit Sub

        ' enabilitytrue()
        If gridissue.Item(5, gridissue.CurrentRow.Index).Value.ToString = "A" Then
            EDIT = True
            GRIDDESCRIPTION.Enabled = True
        ElseIf gridissue.Item(5, gridissue.CurrentRow.Index).Value.ToString = "B" Then
            EDIT = True
            enabilitytrue()
        End If
        cmbtype.Enabled = False
        If chkname.CheckState = CheckState.Unchecked Then
            tempname = gridissue.Item(1, gridissue.CurrentRow.Index).Value
        Else
            tempname = gridledger.Item(0, gridledger.CurrentRow.Index).Value
        End If
        txtnarration.Enabled = True

        If gridissue.Item(5, gridissue.CurrentRow.Index).Value.ToString <> "CASH" And gridissue.Item(5, gridissue.CurrentRow.Index).Value.ToString <> "SALARY" And gridissue.Item(5, gridissue.CurrentRow.Index).Value.ToString <> "I" And gridissue.Item(5, gridissue.CurrentRow.Index).Value.ToString <> "R" And gridissue.Item(5, gridissue.CurrentRow.Index).Value.ToString <> "JV" Then
            cmbcode.Enabled = True
            cmbcode.Focus()
        End If


        If gridissue.Item(5, gridissue.CurrentRow.Index).Value.ToString = "R" Or gridissue.Item(5, gridissue.CurrentRow.Index).Value.ToString = "I" Then

            If gridissue.Item(6, e.RowIndex).Value <> Nothing Then
                TEMPBILLNO = gridissue.Item(6, e.RowIndex).Value
                'If gridissue.Item(5, gridissue.CurrentRow.Index).Value.ToString = "R" Then
                '    frmrecieptmaster = True
                '    frminvoicemaster = False
                'Else
                '    frmrecieptmaster = False
                '    frminvoicemaster = True
                'End If

                'If (chldvouchers.IsMdiChild = False) Then
                '    'Me.Close()
                '    If chldvouchers.IsDisposed = True Then
                '        chldvouchers = New vouchers
                '    End If
                '    chldvouchers.MdiParent = MDIMain
                '    chldvouchers.cmdedit.Enabled = False
                '    chldvouchers.EDIT = True
                '    chldvouchers.Show()
                'Else
                '    chldvouchers.BringToFront()
                'End If
                Dim OBJVOUCHER As New vouchers
                OBJVOUCHER.MdiParent = MDIMain
                If gridissue.Item(5, gridissue.CurrentRow.Index).Value.ToString = "R" Then OBJVOUCHER.FRMSTRING = "RECEIPT" Else OBJVOUCHER.FRMSTRING = "ISSUE"
                OBJVOUCHER.TEMPBILLNO = gridissue.Item(6, e.RowIndex).Value
                OBJVOUCHER.cmdedit.Enabled = False
                OBJVOUCHER.EDIT = True
                OBJVOUCHER.Show()

            End If

        ElseIf gridissue.Item(5, gridissue.CurrentRow.Index).Value.ToString = "JV" Then

            If gridissue.Item(6, e.RowIndex).Value <> Nothing Then
                Dim OBJJV As New JournalVoucher
                OBJJV.MdiParent = MDIMain
                OBJJV.EDIT = True
                OBJJV.TEMPJVNO = gridissue.Item(6, e.RowIndex).Value
                OBJJV.Show()
            End If

        ElseIf gridissue.Item(5, gridissue.CurrentRow.Index).Value.ToString = "CASH" Then

            If gridissue.Item(6, e.RowIndex).Value <> Nothing Then
                Dim OBJCASH As New CashBook
                OBJCASH.MdiParent = MDIMain
                OBJCASH.EDIT = True
                OBJCASH.TEMPCASHNO = gridissue.Item(6, e.RowIndex).Value
                OBJCASH.Show()
            End If

        ElseIf gridissue.Item(5, gridissue.CurrentRow.Index).Value.ToString = "SALARY" Then

            If gridissue.Item(6, e.RowIndex).Value <> Nothing Then
                Dim OBJSAL As New Salary
                OBJSAL.MdiParent = MDIMain
                OBJSAL.EDIT = True
                OBJSAL.TEMPSALNO = gridissue.Item(6, e.RowIndex).Value
                OBJSAL.Show()
            End If

        End If

    End Sub

    Private Sub gridissue_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridissue.KeyDown
        If gridissue.RowCount = 0 Then Exit Sub
        If (e.KeyCode = Keys.Down Or e.KeyCode = Keys.Up) Then
            enabilityfalse()
            txtbhavcut.Text = "0.000"
            TXTAMOUNT.Text = "0.00"
            txtperwt.Text = "0.00"
            txtrate.Text = "0.00"
            txtbalamt.Text = "0.00"
            txtbalwt.Text = "0.000"
            txtcashrec.Text = "0.00"
            GRIDDESCRIPTION.CurrentCell = GRIDDESCRIPTION.Rows(0).Cells(dggrosswt.Index)
            GRIDDESCRIPTION.RowCount = 1


            If e.KeyCode = Keys.Down Then
                If gridissue.RowCount > gridissue.CurrentRow.Index + 1 Then
                    txtbillno.Text = Val(gridissue.Item(6, gridissue.CurrentRow.Index + 1).Value)
                    types = gridissue.Item(5, gridissue.CurrentRow.Index + 1).Value.ToString
                End If
            Else
                If gridissue.CurrentRow.Index > 0 Then
                    txtbillno.Text = Val(gridissue.Item(6, gridissue.CurrentRow.Index - 1).Value)
                    types = gridissue.Item(5, gridissue.CurrentRow.Index - 1).Value.ToString
                End If
            End If
            If types = "A" Then
                cmbtype.SelectedIndex = (0)
            End If
            filldetails(gridissue)

        End If
        If e.KeyCode = Keys.Delete Then

            For Each row As DataGridViewRow In gridissue.SelectedRows
                TEMPBILLNO = row.Cells(6).Value.ToString
            Next

            tempmsg = MsgBox("Wish To Delete Voucher?", MsgBoxStyle.YesNo)
            If tempmsg = vbYes Then

                'IF BACK DATED ENTRY IS TO BE SAVED THEN CHECK ENTRYPASSWORD
                If APPLYBLOCKDATE = True And dtpickerkhata.Value.Date <= BLOCKEDDATE.Date Then
                    Dim OBJPASS As New PasswordEntry
                    OBJPASS.ShowDialog()
                    If ENTRYPASSWORD <> OBJPASS.TXTDATERETYPE.Text.Trim Then
                        MsgBox("Invaid Password", MsgBoxStyle.Critical)
                        Exit Sub
                    End If
                End If


                'deleteing from Vouchers
                If cmbtype.Text.Trim = "Chitti Invoice" Then
                    cmd = New OleDbCommand("delete from vouchers where voucher_id = " & TEMPBILLNO & " and voucher_type ='I'", conn)
                ElseIf cmbtype.Text.Trim = "Chitti Reciept" Then
                    cmd = New OleDbCommand("delete from vouchers where voucher_id = " & TEMPBILLNO & " and voucher_type ='R'", conn)
                ElseIf gridissue.SelectedRows(0).Cells(5).Value = "JV" Then
                    cmd = New OleDbCommand("delete from JOURNALMASTER where JV_NO = " & TEMPBILLNO, conn)
                ElseIf gridissue.SelectedRows(0).Cells(5).Value = "CASH" Then
                    cmd = New OleDbCommand("delete from CASHENTRY where CASH_NO = " & TEMPBILLNO, conn)
                ElseIf gridissue.SelectedRows(0).Cells(5).Value = "SALARY" Then
                    cmd = New OleDbCommand("delete from SALARYENTRY where SAL_NO = " & TEMPBILLNO, conn)
                End If
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
                conn.Open()
                cmd.ExecuteNonQuery()


                cmd = New OleDbCommand("delete from accountmaster where account_voucherid = " & TEMPBILLNO & " and account_type ='" & types & "'", conn)

                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If

                conn.Open()
                cmd.ExecuteNonQuery()
                conn.Close()

                If cmbtype.Text = "Bhavcut On Rec Wt." Or cmbtype.Text = "Bhavcut On Rec Amt." Or cmbtype.Text = "Bhavcut On Inv Wt." Or cmbtype.Text = "Bhavcut On Inv Amt." Then

                    tempcmd = New OleDbCommand("delete from bhavcutmaster where bhavcut_id = " & TEMPBILLNO, tempconn)
                    If tempconn.State = ConnectionState.Open Then
                        tempconn.Close()
                    End If

                    tempconn.Open()
                    tempcmd.ExecuteNonQuery()
                    tempconn.Close()
                End If

            End If
            If chkname.Checked = False Then
                Call dailykhata_Shown(sender, e)

            Else
                clear()

                dtpickerkhata.Value = Now.Date
                enabilityfalse()
                If item <> 1 Then
                    fillitem()
                    item = 1
                End If
                fillbal()
                openingbal()
                fillissue()
                filljama()

                totalofgrid()
                closingbalance()
                GRIDDESCRIPTION.RowCount = 1
            End If
        End If
    End Sub

    Private Sub gridissue_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles gridissue.KeyPress

        If AscW(e.KeyChar) = 13 Then
            clear()
            GRIDDESCRIPTION.RowCount = 1
            cmbtype.Enabled = True
            If chkname.Checked <> True Then
                cmbcode.Text = ""
            End If
            cmbcode.Enabled = True
            cmbtype.SelectedIndex = (1)
            cmbtype.Focus()

        End If
    End Sub

    Private Sub gridjama_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridjama.CellClick
        If gridjama.RowCount = 0 Then Exit Sub
        enabilityfalse()
        If gridissue.RowCount > 0 Then
            gridissue.Rows(gridissue.CurrentRow.Index).Selected = False
        End If
        txtbhavcut.Text = "0.000"
        TXTAMOUNT.Text = "0.00"
        txtperwt.Text = "0.00"
        txtpurity.Text = "0.00"
        txtrate.Text = "0.00"
        txtbalamt.Text = "0.00"
        txtbalwt.Text = "0.000"
        txtcashrec.Text = "0.00"

        GRIDDESCRIPTION.CurrentCell = GRIDDESCRIPTION.Rows(0).Cells(dggrosswt.Index)
        GRIDDESCRIPTION.RowCount = 1
        txtbillno.Text = Val(gridjama.Item(6, gridjama.CurrentRow.Index).Value)
        types = gridjama.Item(5, gridjama.CurrentRow.Index).Value.ToString
        If gridjama.Item(5, gridjama.CurrentRow.Index).Value.ToString = "A" Then
            cmbtype.SelectedIndex = (0)
        End If
        filldetails(gridjama)
    End Sub

    Sub filldetails(ByVal gd As DataGridView)

        ' If gd.Item(5, gd.CurrentRow.Index).Value.ToString = "A" Then
        If types = "A" Then
            cmd = New OleDbCommand("select * from accountmaster  where accountmaster.account_id=" & Val(txtbillno.Text), conn)
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
            conn.Open()
            dr = cmd.ExecuteReader

            If dr.HasRows = True Then


                While (dr.Read)
                    If dr(2) <> 0 Then
                        tempcmd = New OleDbCommand("select ledger_code from ledgermaster where ledger_id = " & Val(dr(2)), tempconn)
                        If tempconn.State = ConnectionState.Open Then
                            tempconn.Close()
                        End If
                        tempconn.Open()
                        tempdr = tempcmd.ExecuteReader
                        While (tempdr.Read)
                            cmbcode.Text = tempdr(0).ToString
                        End While
                        tempdr.Close()
                        tempconn.Close()
                    Else

                    End If
                    'gettign itemcode
                    If Val(dr(3)) <> 0 Then
                        tempcmd = New OleDbCommand("select item_code from itemmaster where item_id = " & Val(dr(3)), tempconn)
                        If tempconn.State = ConnectionState.Open Then
                            tempconn.Close()
                        End If
                        tempconn.Open()
                        tempdr = tempcmd.ExecuteReader
                        While (tempdr.Read)
                            tempitemcode = tempdr(0).ToString
                        End While
                        tempdr.Close()
                        tempconn.Close()
                    Else
                        tempitemcode = ""
                    End If
                    If IsDBNull(dr("account_narration")) = False Then txtnarration.Text = dr("account_narration")
                    If IsDBNull(dr("account_PROCESS")) = False Then CMBPROCESS.Text = dr("account_PROCESS")
                    dtpickerkhata.Value = Format(dr("account_date"), "dd/MM/yyyy")
                    GRIDDESCRIPTION.CurrentCell = GRIDDESCRIPTION.Rows(0).Cells(dggrosswt.Index)
                    GRIDDESCRIPTION.Rows.Add(tempitemcode, dr("ACCOUNT_ITEMDESC"), Format(Val(dr("account_grosswt")), "0.000"), Format(Val(dr("ACCOUNT_LESSWT")), "0.000"), Format(Val(dr("account_GROSSLESS")), "0.000"), Format(Val(dr("account_purity")), "0.00"), Format(Val(dr("account_wastage")), "0.00"), Format(Val(dr("account_nettwt")), "0.000"), Format(Val(dr("account_labour")), "0.00"), Val(dr("account_pieces")), Format(Val(dr("account_bullion")), "0.000"), Format(Val(dr("account_amount")), "0.00"))


                End While

            End If
            dr.Close()
            conn.Close()
        ElseIf types = "B" Then
            GRIDDESCRIPTION.RowCount = 1
            cmd = New OleDbCommand("select * from Bhavcutmaster  where bhavcut_id=" & Val(txtbillno.Text), conn)
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
            conn.Open()
            dr = cmd.ExecuteReader

            If dr.HasRows = True Then


                While (dr.Read)
                    If dr("bhavcut_ledgerid") <> 0 Then
                        tempcmd = New OleDbCommand("select ledger_code from ledgermaster where ledger_id = " & Val(dr("bhavcut_ledgerid")), tempconn)
                        If tempconn.State = ConnectionState.Open Then
                            tempconn.Close()
                        End If
                        tempconn.Open()
                        tempdr = tempcmd.ExecuteReader
                        While (tempdr.Read)
                            cmbcode.Text = tempdr(0).ToString
                        End While
                        tempdr.Close()
                        tempconn.Close()
                    Else

                    End If
                    'gettign itemcode
                    If dr("bhavcut_itemid") <> 0 Then
                        tempcmd = New OleDbCommand("select item_code from itemmaster where item_id = " & Val(dr("bhavcut_itemid")), tempconn)
                        If tempconn.State = ConnectionState.Open Then
                            tempconn.Close()
                        End If
                        tempconn.Open()
                        tempdr = tempcmd.ExecuteReader
                        While (tempdr.Read)
                            tempitemcode = tempdr(0).ToString
                        End While
                        tempdr.Close()
                        tempconn.Close()
                    Else

                    End If
                    GRIDDESCRIPTION.CurrentCell = GRIDDESCRIPTION.Rows(0).Cells(dggrosswt.Index)
                    ' griddescription.Rows.Add(tempitemcode, Format(Val(dr("bhavcut_grosswt")), "0.000"), Format(Val(dr("bhavcut_purity")), "0.00"), Format(Val(dr("bhavcut_wastage")), "0.00"), Format(Val(dr("bhavcut_nettwt")), "0.000"), "", "", "", Format(Val(dr("bhavcut_amount")), "0.00"))
                    dtpickerkhata.Value = Format(dr("bhavcut_date"), "dd/MM/yyyy")
                    txtbhavcut.Text = Val(dr("bhavcut_bhavcut"))
                    txtperwt.Text = Val(dr("bhavcut_perwt"))
                    txtpurity.Text = Val(dr("bhavcut_purity"))
                    txtrate.Text = Val(dr("bhavcut_goldrate"))
                    TXTAMOUNT.Text = Val(dr("bhavcut_totalamt"))
                    txtcashrec.Text = Val(dr("bhavcut_cashreceived"))
                    If dr("bhavcut_type") = "RWT" Then
                        cmbtype.Text = "Bhavcut On Rec Wt."
                    ElseIf dr("bhavcut_type") = "IWT" Then
                        cmbtype.Text = "Bhavcut On Inv Wt."
                    ElseIf dr("bhavcut_type") = "RAMT" Then
                        cmbtype.Text = "Bhavcut On Rec Amt."

                    ElseIf dr("bhavcut_type") = "IAMT" Then
                        cmbtype.Text = "Bhavcut On Inv Amt."
                    End If
                End While

            End If
            dr.Close()
            conn.Close()
        ElseIf types = "R" Or types = "I" Then
            If types = "R" Then
                cmbtype.SelectedIndex = (2)
                cmd = New OleDbCommand("SELECT ledgermaster.ledger_code, vouchers.voucher_date, ItemMaster.item_code, vouchers.voucher_grosswt, vouchers.voucher_purity, vouchers.voucher_wastage, vouchers.voucher_nettwt, vouchers.voucher_labour, vouchers.voucher_pieces, vouchers.voucher_bullion, vouchers.voucher_amount, vouchers.voucher_bhavcut, vouchers.voucher_goldrate, vouchers.voucher_perwt, vouchers.voucher_amt, vouchers.voucher_cashrecieved, vouchers.voucher_balancewt, vouchers.voucher_balance, vouchers.voucher_narration, VOUCHERS.VOUCHER_ITEMDESC AS ITEMDESC, VOUCHERS.VOUCHER_LESSWT AS LESSWT, VOUCHERS.VOUCHER_GROSSLESS AS GROSSLESS FROM (ledgermaster INNER JOIN vouchers ON ledgermaster.ledger_id = vouchers.voucher_ledgerid) INNER JOIN ItemMaster ON vouchers.voucher_itemid = ItemMaster.item_id where vouchers.voucher_id = " & Val(txtbillno.Text) & " and vouchers.voucher_type='R'", conn)
            Else
                cmbtype.SelectedIndex = (3)
                cmd = New OleDbCommand("SELECT ledgermaster.ledger_code, vouchers.voucher_date, ItemMaster.item_code, vouchers.voucher_grosswt, vouchers.voucher_purity, vouchers.voucher_wastage, vouchers.voucher_nettwt, vouchers.voucher_labour, vouchers.voucher_pieces, vouchers.voucher_bullion, vouchers.voucher_amount, vouchers.voucher_bhavcut, vouchers.voucher_goldrate, vouchers.voucher_perwt, vouchers.voucher_amt, vouchers.voucher_cashrecieved, vouchers.voucher_balancewt, vouchers.voucher_balance, vouchers.voucher_narration, VOUCHERS.VOUCHER_ITEMDESC AS ITEMDESC, VOUCHERS.VOUCHER_LESSWT AS LESSWT, VOUCHERS.VOUCHER_GROSSLESS AS GROSSLESS FROM (ledgermaster INNER JOIN vouchers ON ledgermaster.ledger_id = vouchers.voucher_ledgerid) INNER JOIN ItemMaster ON vouchers.voucher_itemid = ItemMaster.item_id where vouchers.voucher_id = " & Val(txtbillno.Text) & " and vouchers.voucher_type='I'", conn)
            End If
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
            conn.Open()
            dr = cmd.ExecuteReader

            If dr.HasRows = True Then
                While (dr.Read)
                    cmbcode.Text = dr(0).ToString
                    dtpickerkhata.Value = Format(dr(1), "dd/MM/yyyy")

                    txtbhavcut.Text = Val(dr(11))
                    txtrate.Text = Val(dr(12))
                    txtperwt.Text = Val(dr(13))
                    TXTAMOUNT.Text = Val(dr(14))
                    txtcashrec.Text = Val(dr(15))
                    txtbalwt.Text = Val(dr(16))
                    txtbalamt.Text = Val(dr(17))
                    If IsDBNull(dr("voucher_narration")) = True Then txtnarration.Text = "" Else txtnarration.Text = dr("voucher_narration")
                    GRIDDESCRIPTION.Rows.Add(dr(2).ToString, dr("ITEMDESC"), Val(dr(3)), Val(dr("LESSWT")), Val(dr("GROSSLESS")), Val(dr(4)), Val(dr(5)), Val(dr(6)), Val(dr(7)), Val(dr(8)), Val(dr(9)), Val(dr(10)))
                End While
            End If
            dr.Close()
            conn.Close()

        End If
        total()

    End Sub

    Private Sub gridjama_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridjama.CellDoubleClick

        If e.RowIndex = -1 Then Exit Sub

        If gridjama.Item(5, gridjama.CurrentRow.Index).Value.ToString = "A" Then
            EDIT = True
            GRIDDESCRIPTION.Enabled = True
            cmbtype.Enabled = False
            cmbcode.Enabled = True
            txtnarration.Enabled = True
            If chkname.CheckState = CheckState.Unchecked Then
                tempname = gridjama.Item(1, gridjama.CurrentRow.Index).Value
            Else
                tempname = gridledger.Item(0, gridledger.CurrentRow.Index).Value
            End If
            cmbcode.Text = tempname
            cmbcode.Focus()

        ElseIf gridjama.Item(5, gridjama.CurrentRow.Index).Value.ToString = "B" Then

            EDIT = True
            enabilitytrue()
            cmbtype.Enabled = False
            cmbcode.Enabled = True
            txtnarration.Enabled = True
            If chkname.CheckState = CheckState.Unchecked Then
                tempname = gridjama.Item(1, gridjama.CurrentRow.Index).Value
            Else
                tempname = gridledger.Item(0, gridledger.CurrentRow.Index).Value
            End If
            cmbcode.Text = tempname
            cmbcode.Focus()

        End If



        If gridjama.Item(5, gridjama.CurrentRow.Index).Value.ToString = "R" Or gridjama.Item(5, gridjama.CurrentRow.Index).Value.ToString = "I" Then

            If gridjama.Item(6, e.RowIndex).Value <> Nothing Then
                TEMPBILLNO = gridjama.Item(6, e.RowIndex).Value
                'If gridjama.Item(5, gridjama.CurrentRow.Index).Value.ToString = "R" Then
                '    frmrecieptmaster = True
                '    frminvoicemaster = False
                'Else
                '    frmrecieptmaster = False
                '    frminvoicemaster = True
                'End If

                'If (chldvouchers.IsMdiChild = False) Then
                '    'Me.Close()
                '    If chldvouchers.IsDisposed = True Then
                '        chldvouchers = New vouchers
                '    End If
                '    chldvouchers.MdiParent = MDIMain
                '    chldvouchers.cmdedit.Enabled = False
                '    chldvouchers.EDIT = True
                '    chldvouchers.Show()
                'Else
                '    chldvouchers.BringToFront()
                'End If
                Dim OBJVOUCHER As New vouchers
                OBJVOUCHER.MdiParent = MDIMain
                If gridjama.Item(5, gridjama.CurrentRow.Index).Value.ToString = "R" Then OBJVOUCHER.FRMSTRING = "RECEIPT" Else OBJVOUCHER.FRMSTRING = "ISSUE"
                OBJVOUCHER.TEMPBILLNO = gridjama.Item(6, e.RowIndex).Value
                OBJVOUCHER.cmdedit.Enabled = False
                OBJVOUCHER.EDIT = True
                OBJVOUCHER.Show()

            End If

        ElseIf gridjama.Item(5, gridjama.CurrentRow.Index).Value.ToString = "JV" Then

            If gridjama.Item(6, e.RowIndex).Value <> Nothing Then
                Dim OBJJV As New JournalVoucher
                OBJJV.MdiParent = MDIMain
                OBJJV.EDIT = True
                OBJJV.TEMPJVNO = gridjama.Item(6, e.RowIndex).Value
                OBJJV.Show()
            End If

        ElseIf gridjama.Item(5, gridjama.CurrentRow.Index).Value.ToString = "CASH" Then

            If gridjama.Item(6, e.RowIndex).Value <> Nothing Then
                Dim OBJCASH As New CashBook
                OBJCASH.MdiParent = MDIMain
                OBJCASH.EDIT = True
                OBJCASH.TEMPCASHNO = gridjama.Item(6, e.RowIndex).Value
                OBJCASH.Show()
            End If

        ElseIf gridjama.Item(5, gridjama.CurrentRow.Index).Value.ToString = "SALARY" Then

            If gridjama.Item(6, e.RowIndex).Value <> Nothing Then
                Dim OBJSAL As New Salary
                OBJSAL.MdiParent = MDIMain
                OBJSAL.EDIT = True
                OBJSAL.TEMPSALNO = gridjama.Item(6, e.RowIndex).Value
                OBJSAL.Show()
            End If
        End If

    End Sub

    Private Sub gridjama_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridjama.KeyDown
        If gridjama.RowCount = 0 Then Exit Sub
        If (e.KeyCode = Keys.Down Or e.KeyCode = Keys.Up) Then
            enabilityfalse()
            txtbhavcut.Text = "0.000"
            TXTAMOUNT.Text = "0.00"
            txtperwt.Text = "0.00"
            txtrate.Text = "0.00"
            txtbalamt.Text = "0.00"
            txtbalwt.Text = "0.000"
            txtcashrec.Text = "0.00"
            GRIDDESCRIPTION.CurrentCell = GRIDDESCRIPTION.Rows(0).Cells(dggrosswt.Index)

            GRIDDESCRIPTION.RowCount = 1
            If e.KeyCode = Keys.Down Then
                If gridjama.RowCount > gridjama.CurrentRow.Index + 1 Then
                    txtbillno.Text = Val(gridjama.Item(6, gridjama.CurrentRow.Index + 1).Value)
                    types = gridjama.Item(5, gridjama.CurrentRow.Index + 1).Value.ToString
                End If
            Else
                If gridjama.CurrentRow.Index > 0 Then
                    txtbillno.Text = Val(gridjama.Item(6, gridjama.CurrentRow.Index - 1).Value)
                    types = gridjama.Item(5, gridjama.CurrentRow.Index - 1).Value.ToString
                End If
            End If
            If types = "A" Then
                cmbtype.SelectedIndex = (0)
            End If

            filldetails(gridjama)

        End If
        If e.KeyCode = Keys.Delete Then
            For Each row As DataGridViewRow In gridjama.SelectedRows
                TEMPBILLNO = row.Cells(6).Value.ToString
            Next
            tempmsg = MsgBox("Wish To Delete Voucher?", MsgBoxStyle.YesNo)
            If tempmsg = vbYes Then

                'IF BACK DATED ENTRY IS TO BE SAVED THEN CHECK ENTRYPASSWORD
                If APPLYBLOCKDATE = True And dtpickerkhata.Value.Date <= BLOCKEDDATE.Date Then
                    Dim OBJPASS As New PasswordEntry
                    OBJPASS.ShowDialog()
                    If ENTRYPASSWORD <> OBJPASS.TXTDATERETYPE.Text.Trim Then
                        MsgBox("Invaid Password", MsgBoxStyle.Critical)
                        Exit Sub
                    End If
                End If

                'deleteing from Vouchers
                If cmbtype.Text.Trim = "Chitti Invoice" Then
                    cmd = New OleDbCommand("delete from vouchers where voucher_id = " & TEMPBILLNO & " and voucher_type ='I'", conn)
                ElseIf cmbtype.Text.Trim = "Chitti Reciept" Then
                    cmd = New OleDbCommand("delete from vouchers where voucher_id = " & TEMPBILLNO & " and voucher_type ='R'", conn)
                ElseIf gridjama.SelectedRows(0).Cells(5).Value = "JV" Then
                    cmd = New OleDbCommand("delete from JOURNALMASTER where JV_NO = " & TEMPBILLNO, conn)
                ElseIf gridjama.SelectedRows(0).Cells(5).Value = "CASH" Then
                    cmd = New OleDbCommand("delete from CASHENTRY where CASH_NO = " & TEMPBILLNO, conn)
                ElseIf gridjama.SelectedRows(0).Cells(5).Value = "SALARY" Then
                    cmd = New OleDbCommand("delete from SALARYENTRY where SAL_NO = " & TEMPBILLNO, conn)
                End If
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
                conn.Open()
                cmd.ExecuteNonQuery()


                cmd = New OleDbCommand("delete from accountmaster where account_voucherid = " & TEMPBILLNO & " and account_type ='" & types & "'", conn)

                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If

                conn.Open()
                cmd.ExecuteNonQuery()
                conn.Close()

                If cmbtype.Text = "Bhavcut On Rec Wt." Or cmbtype.Text = "Bhavcut On Rec Amt." Or cmbtype.Text = "Bhavcut On Inv Wt." Or cmbtype.Text = "Bhavcut On Inv Amt." Then

                    tempcmd = New OleDbCommand("delete from bhavcutmaster where bhavcut_id = " & TEMPBILLNO, tempconn)
                    If tempconn.State = ConnectionState.Open Then
                        tempconn.Close()
                    End If

                    tempconn.Open()
                    tempcmd.ExecuteNonQuery()
                    tempconn.Close()
                End If

            End If
            If chkname.Checked = False Then
                Call dailykhata_Shown(sender, e)

            Else
                clear()

                dtpickerkhata.Value = Now.Date
                enabilityfalse()
                If item <> 1 Then
                    fillitem()
                    item = 1
                End If
                fillbal()
                openingbal()
                fillissue()
                filljama()

                totalofgrid()
                closingbalance()
                GRIDDESCRIPTION.RowCount = 1
            End If
        End If
    End Sub

    Private Sub gridjama_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles gridjama.KeyPress
        If AscW(e.KeyChar) = 13 Then
            clear()
            GRIDDESCRIPTION.RowCount = 1
            cmbtype.Enabled = True
            cmbcode.Enabled = True
            If chkname.Checked <> True Then
                cmbcode.Text = ""
            End If
            cmbtype.SelectedIndex = (0)
            cmbtype.Focus()

        End If
    End Sub

    Private Sub cmbtype_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbtype.Validating
        GRIDDESCRIPTION.CurrentCell = GRIDDESCRIPTION.Rows(0).Cells(dgcmbitemcode.Index)
        GRIDDESCRIPTION.RowCount = 1

        TXTAMOUNT.Top = 526
        txtbhavcut.Top = 434
        lblamount.Text = "Amount :"
        lblbhavcut.Text = "Bhavcut :"
        GRIDDESCRIPTION.Enabled = True
        LBLCASHREC.Text = "Cash Rec"

        GRIDDESCRIPTION.Enabled = True
        If cmbtype.Text = "Invoice" Then
            types = "A"

            txtbhavcut.Enabled = False
            TXTAMOUNT.Enabled = False
            txtperwt.Enabled = False
            txtrate.Enabled = False

            txtbalwt.Enabled = False
            txtbalamt.Enabled = False
            txtcashrec.Enabled = False

        ElseIf cmbtype.Text = "Reciept" Then
            types = "A"

            txtbhavcut.Enabled = False
            TXTAMOUNT.Enabled = False
            txtperwt.Enabled = False
            txtrate.Enabled = False
            txtbalwt.Enabled = False
            txtbalamt.Enabled = False
            txtcashrec.Enabled = False
        ElseIf cmbtype.Text = "Chitti Invoice" Then
            types = "I"

        ElseIf cmbtype.Text = "Chitti Reciept" Then
            types = "R"

        ElseIf cmbtype.Text = "Bhavcut On Rec Wt." Then
            types = "B"
            GRIDDESCRIPTION.Enabled = False
            LBLCASHREC.Text = "Cash Issued"
        ElseIf cmbtype.Text = "Bhavcut On Inv Wt." Then
            types = "B"
            GRIDDESCRIPTION.Enabled = False
            LBLCASHREC.Text = "Cash Rec"
        ElseIf cmbtype.Text = "Bhavcut On Rec Amt." Then
            types = "B"


            GRIDDESCRIPTION.Enabled = False
            'lblamount.Text = "Bhavcut :"
            'lblbhavcut.Text = "Amount :"
            TXTAMOUNT.Top = 526
            txtbhavcut.Top = 434

        ElseIf cmbtype.Text = "Bhavcut On Inv Amt." Then
            types = "B"
            GRIDDESCRIPTION.Enabled = False

            'lblamount.Text = "Bhavcut :"
            'lblbhavcut.Text = "Amount :"
            TXTAMOUNT.Top = 434
            txtbhavcut.Top = 526

        End If

        total()
    End Sub

    Function ERRORVALID() As Boolean
        Dim BLN As Boolean = True
        Try
            'CHECK CR LIMIT FROM ACCOUNTMASTER AND THEN VALIDATE
            If cmbtype.Text = "Invoice" Or cmbtype.Text.Trim = "Chitti Invoice" Then
                dt = New DataTable()
                If tempconn.State = ConnectionState.Open Then tempconn.Close()
                tempconn.Open()
                tempcmd = New OleDbCommand("SELECT LEDGERMASTER.LEDGER_CRLIMIT AS CRLIMIT, CODE, SUM(GROSSDR) - SUM(GROSSCR) AS GROSSWT, SUM(DR) - SUM(CR) AS BALWT, SUM(AMTDR) - SUM(AMTCR) AS BALAMT FROM (SELECT ACCOUNT_LEDGERCODE AS CODE, SUM(ACCOUNT_GROSSWT) AS GROSSDR, 0 AS GROSSCR, SUM(ACCOUNT_NETTWT) AS DR, 0 AS CR, SUM(ACCOUNT_AMOUNT) AS AMTDR, 0 AS AMTCR FROM ACCOUNTMAST WHERE ACCOUNT_BALORJAMAORPAID= 'Jama' AND ACCOUNT_LEDGERCODE = '" & cmbcode.Text.Trim & "' GROUP BY ACCOUNT_LEDGERCODE UNION ALL SELECT LEDGER_CODE AS CODE, ROUND(LEDGER_OPBALGROSSWT,3) AS GROSSDR, 0 AS GROSSCR, 0 AS DR, 0 AS CR, 0 AS AMTDR, 0 AS AMTCR FROM LEDGERMASTER WHERE LEDGER_DRCRGROSSWT= 'Cr.' AND LEDGER_CODE = '" & cmbcode.Text.Trim & "' UNION ALL SELECT LEDGER_CODE AS CODE, 0 AS GROSSDR, 0 AS GROSSCR, ROUND(LEDGER_OPBALWT,3) AS DR, 0 AS CR, 0 AS AMTDR, 0 AS AMTCR FROM LEDGERMASTER WHERE LEDGER_DRCRWT= 'Cr.' AND LEDGER_CODE = '" & cmbcode.Text.Trim & "' UNION ALL SELECT LEDGER_CODE AS CODE, 0 AS GROSSDR, 0 AS GROSSCR, 0 AS DR, 0 AS CR, ROUND(LEDGER_OPBALRS,2) AS AMTDR, 0 AS AMTCR FROM LEDGERMASTER WHERE LEDGER_DRCRRS= 'Cr.' AND LEDGER_CODE = '" & cmbcode.Text.Trim & "' UNION ALL SELECT LEDGER_CODE AS CODE, 0 AS GROSSDR, ROUND(LEDGER_OPBALGROSSWT,3) AS GROSSCR, 0 AS DR, 0 AS CR, 0 AS AMTDR, 0 AS AMTCR FROM LEDGERMASTER WHERE LEDGER_DRCRGROSSWT= 'Dr.' AND LEDGER_CODE = '" & cmbcode.Text.Trim & "' UNION ALL SELECT LEDGER_CODE AS CODE, 0 AS GROSSDR, 0 AS GROSSCR, 0 AS DR, ROUND(LEDGER_OPBALWT,3) AS CR, 0 AS AMTDR, 0 AS AMTCR FROM LEDGERMASTER WHERE LEDGER_DRCRWT= 'Dr.' AND LEDGER_CODE = '" & cmbcode.Text.Trim & "' UNION ALL SELECT LEDGER_CODE AS CODE, 0 AS GROSSDR, 0 AS GROSSCR, 0 AS DR, 0 AS CR, 0 AS AMTDR, ROUND(LEDGER_OPBALRS,2) AS AMTCR FROM LEDGERMASTER WHERE LEDGER_DRCRRS= 'Dr.' AND LEDGER_CODE = '" & cmbcode.Text.Trim & "' UNION ALL SELECT ACCOUNT_LEDGERCODE AS CODE, 0 AS GROSSDR, SUM(ACCOUNT_GROSSWT) AS GROSSCR, 0 AS DR, SUM(ACCOUNT_NETTWT) AS CR, 0 AS AMTDR, SUM(ACCOUNT_AMOUNT) AS AMTCR FROM ACCOUNTMAST WHERE ACCOUNT_BALORJAMAORPAID = 'Balance' AND ACCOUNT_LEDGERCODE = '" & cmbcode.Text.Trim & "' GROUP BY ACCOUNT_LEDGERCODE ) AS T INNER JOIN LEDGERMASTER ON T.CODE = LEDGERMASTER.LEDGER_CODE GROUP BY T.CODE, LEDGERMASTER.LEDGER_CRLIMIT", tempconn)
                da = New OleDbDataAdapter(tempcmd)
                da.Fill(dt)
                If dt.Rows.Count > 0 Then
                    If Val(dt.Rows(0).Item("CRLIMIT")) > 0 AndAlso Val(dt.Rows(0).Item("BALWT")) < 0 Then
                        If (Val(dt.Rows(0).Item("BALWT")) * -1) > Val(dt.Rows(0).Item("CRLIMIT")) Then
                            EP.SetError(cmbcode, "Fine Wt Greater then Credit Limit")
                            BLN = False
                        End If
                    End If
                End If
                tempconn.Close()
                da.Dispose()
            End If
        Catch ex As Exception
            Throw ex
        End Try
        Return BLN
    End Function

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        'Dim rowno, b As Integer

        'IF BACK DATED ENTRY IS TO BE SAVED THEN CHECK ENTRYPASSWORD
        If APPLYBLOCKDATE = True And dtpickerkhata.Value.Date <= BLOCKEDDATE.Date Then
            Dim OBJPASS As New PasswordEntry
            OBJPASS.ShowDialog()
            If ENTRYPASSWORD <> OBJPASS.TXTDATERETYPE.Text.Trim Then
                MsgBox("Invaid Password", MsgBoxStyle.Critical)
                Exit Sub
            End If
        End If


        If Not ERRORVALID() Then
            Exit Sub
        End If


        adding(dtpickerkhata.Value.Date)

        If chkname.Checked = False Then
            Call dailykhata_Shown(sender, e)
        Else
            clear()

            dtpickerkhata.Value = Now.Date
            enabilityfalse()
            If item <> 1 Then
                fillitem()
                item = 1
            End If
            txttempname.Text = tempname
            fillbal()
            tempname = txttempname.Text
            openingbal()
            fillissue()
            filljama()

            totalofgrid()
            closingbalance()
            GRIDDESCRIPTION.RowCount = 1

            'DONE BY GULKIT
            '**********************************
            'If tempname <> "" Then

            '    rowno = 0
            '    For b = 1 To gridledger.RowCount - 1


            '        'txttempname.Text = tempname
            '        'gridledger.Item(0, rowno).Value.ToString()

            '        txttempname.SelectionStart = 0
            '        txttempname.SelectionLength = txtname.TextLength
            '        If LCase(tempname) <> LCase(txttempname.SelectedText.Trim) Then
            '            'gridledger.Rows.RemoveAt(rowno)
            '        Else
            '            rowno = rowno + 1
            '        End If
            '    Next
            'End If

            If Trim(tempname) <> "" Then
                For i = 0 To gridledger.RowCount - 1

                    txttempname.Text = gridledger.Rows(i).Cells(0).Value.ToString
                    txtname.Text = (tempname)
                    txttempname.SelectionStart = 0
                    txttempname.SelectionLength = Len(txtname.Text)

                    If LCase(txttempname.SelectedText) = LCase(Trim(txtname.Text)) Then
                        tempname = txttempname.Text.Trim
                        clk = False
                        gridledger.CurrentCell = gridledger.Rows(i).Cells(0)
                        'gridledger.FirstDisplayedScrollingRowIndex = (i)
                        GoTo Line1
                    End If
                Next
            End If
            '***************************************

Line1:


        End If
        gridjama.Focus()
    End Sub

    Private Sub cmbcode_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbcode.GotFocus
        If cmbcode.Text.Trim = "" Then fillname(Me, cmbcode, " AND (GROUPMASTER.GROUP_NAME <> 'Bank A/C' AND GROUPMASTER.GROUP_NAME <> 'Bank OD A/C' AND GROUPMASTER.GROUP_NAME <> 'Cash In Hand')")
        cmbcode.SelectAll()
    End Sub

    Private Sub cmbcode_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbcode.Validating
        If cmbcode.Text.Trim <> "" Then

            cmbcode.Text = uppercase(cmbcode.Text)
            cmd = New OleDbCommand("SELECT ledgermaster.ledger_code,ledgermaster.ledger_id,ledgermaster.ledger_name AS NAME from ledgermaster INNER JOIN GROUPMASTER ON LEDGERMASTER.LEDGER_GROUPID = GROUPMASTER.GROUP_ID where ledgermaster.ledger_code = '" & cmbcode.Text.Trim & "' AND (GROUPMASTER.GROUP_NAME <> 'Bank A/C' AND GROUPMASTER.GROUP_NAME <> 'Bank OD A/C' AND GROUPMASTER.GROUP_NAME <> 'Cash In Hand')", conn)
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
            conn.Open()

            'cmd = New OleDbCommand("select ledger_code,ledger_id,ledger_name from ledgermaster where ledger_code = '" & cmbname.Text.Trim & "'", conn)
            'cmd = New OleDbCommand("SELECT ledgermaster.ledger_code,ledgermaster.ledger_id,ledgermaster.ledger_name from ledgermaster inner join groupmaster on groupmaster.group_id = ledgermaster.ledger_groupid where ledgermaster.ledger_code = '" & cmbcode.Text.Trim & "' and ( groupmaster.group_name = 'Sundry Creditors' or groupmaster.group_name = 'Sundry Debtors'  )", conn)
            dr = cmd.ExecuteReader
            If dr.HasRows Then
                dr.Read()
                tempnameid = dr(1)
                LBLNAME.Text = dr("NAME")
                If ledgeradd = True Then
                    fillbal()
                    ledgeradd = False
                End If

            Else
                tempmsg = MsgBox("Ledger Not Present, Add New?", MsgBoxStyle.YesNo)
                If tempmsg = vbYes Then

                    If (chldvendormaster.IsMdiChild = False) Then
                        If chldvendormaster.IsDisposed = True Then
                            chldvendormaster = New ACCOUNTMASTER
                        End If
                        chldvendormaster.txtcode.Text = cmbcode.Text
                        chldvendormaster.cmdedit.Enabled = True
                        chldvendormaster.EDIT = False
                        ledgeradd = True
                        e.Cancel = True
                        chldvendormaster.Show(Me)
                        chldvendormaster.ActiveControl = (chldvendormaster.txtcode)
                        chldvendormaster.txtcode.Focus()
                    Else
                        chldvendormaster.BringToFront()
                    End If

                Else
                    cmbcode.Focus()

                End If
            End If

        End If

        If cmbtype.Text.Trim = "Bhavcut On Rec Amt." Or cmbtype.Text.Trim = "Bhavcut On Inv Amt." Then
            TXTAMOUNT.Focus()
        ElseIf cmbtype.Text.Trim = "Bhavcut On Rec Wt." Or cmbtype.Text.Trim = "Bhavcut On Inv Wt." Then

            'GET BALANCE OF SELECTED PARTY
            dt = New DataTable()
            dt.Columns.Add("LEDGERCODE")
            dt.Columns.Add("GROSSWT")
            dt.Columns.Add("NETTWT")
            dt.Columns.Add("AMOUNT")

            Dim TOTALNETTJAMA, TOTALNETTBAL, TOTALGROSSJAMA, TOTALGROSSBAL, TOTALAMTJAMA, TOTALAMTBAL As Double
            Dim DTJAMA As New DataTable
            Dim DTBAL As New DataTable

            TOTALGROSSBAL = 0
            TOTALGROSSJAMA = 0
            TOTALNETTBAL = 0
            TOTALNETTJAMA = 0
            TOTALAMTBAL = 0
            TOTALAMTJAMA = 0


            'ADD OPBAL FROM LEDGERMASTER ALSO IN THE ABOVE VARIABLES
            Dim DTOPBAL As New DataTable
            Dim DAOP = New OleDbDataAdapter
            DTOPBAL.Clear()
            tempcmd = New OleDbCommand("SELECT IIF(LEDGER_DRCRWT = 'Cr.', LEDGER_OPBALWT,0) AS OPBALDR, IIF(LEDGER_DRCRWT = 'Dr.', LEDGER_OPBALWT,0) AS OPBALCR FROM LEDGERMASTER WHERE LEDGER_CODE = '" & cmbcode.Text.Trim & "'", tempconn)
            If tempconn.State = ConnectionState.Open Then tempconn.Close()
            tempconn.Open()
            DAOP = New OleDbDataAdapter(tempcmd)
            DAOP.Fill(DTOPBAL)
            If DTOPBAL.Rows.Count > 0 Then
                TOTALNETTJAMA += Format(Val(DTOPBAL.Rows(0).Item("OPBALDR")), "0.00")
                TOTALNETTBAL += Format(Val(DTOPBAL.Rows(0).Item("OPBALCR")), "0.00")
            End If


            DTOPBAL.Clear()
            tempcmd = New OleDbCommand("SELECT IIF(LEDGER_DRCRRS = 'Cr.', LEDGER_OPBALRS,0) AS OPBALDR, IIF(LEDGER_DRCRRS = 'Dr.', LEDGER_OPBALRS,0) AS OPBALCR FROM LEDGERMASTER WHERE LEDGER_CODE = '" & cmbcode.Text.Trim & "'", tempconn)
            If tempconn.State = ConnectionState.Open Then tempconn.Close()
            tempconn.Open()
            DAOP = New OleDbDataAdapter(tempcmd)
            DAOP.Fill(DTOPBAL)
            If DTOPBAL.Rows.Count > 0 Then
                TOTALAMTJAMA += Format(Val(DTOPBAL.Rows(0).Item("OPBALDR")), "0.00")
                TOTALAMTBAL += Format(Val(DTOPBAL.Rows(0).Item("OPBALCR")), "0.00")
            End If



            'FOR EACH LEDGER FETCH THE TOTALBALANCE AND TOTALJAMA, THEN SUBTRACT TO GET THE FINAL BALANCE
            tempcmd = New OleDbCommand("SELECT Sum(ACCOUNTMAST.ACCOUNT_GROSSWT) AS GROSSWT, Sum(ACCOUNTMAST.ACCOUNT_NETTWT) AS NETTWT, Sum(ACCOUNTMAST.ACCOUNT_AMOUNT) AS AMOUNT FROM ACCOUNTMAST WHERE ACCOUNTMAST.ACCOUNT_BALORJAMAORPAID = 'Jama' AND ACCOUNTMAST.ACCOUNT_LEDGERCODE = '" & cmbcode.Text.Trim & "' GROUP BY ACCOUNTMAST.ACCOUNT_LEDGERCODE ", tempconn)
            If tempconn.State = ConnectionState.Open Then tempconn.Close()
            tempconn.Open()
            Dim DALEDGERS = New OleDbDataAdapter(tempcmd)
            DALEDGERS.Fill(DTJAMA)

            If DTJAMA.Rows.Count > 0 Then
                TOTALGROSSJAMA += Format(Val(DTJAMA.Rows(0).Item("GROSSWT")), "0.000")
                TOTALNETTJAMA += Format(Val(DTJAMA.Rows(0).Item("NETTWT")), "0.000")
                TOTALAMTJAMA += Format(Val(DTJAMA.Rows(0).Item("AMOUNT")), "0.00")
            End If

            tempconn.Close()
            DALEDGERS.Dispose()
            tempcmd.Dispose()


            tempcmd = New OleDbCommand("SELECT Sum(ACCOUNTMAST.ACCOUNT_GROSSWT) AS GROSSWT, Sum(ACCOUNTMAST.ACCOUNT_NETTWT) AS NETTWT, Sum(ACCOUNTMAST.ACCOUNT_AMOUNT) AS AMOUNT FROM ACCOUNTMAST WHERE ACCOUNTMAST.ACCOUNT_BALORJAMAORPAID = 'Balance' AND ACCOUNTMAST.ACCOUNT_LEDGERCODE = '" & cmbcode.Text.Trim & "' GROUP BY ACCOUNTMAST.ACCOUNT_LEDGERCODE ", tempconn)
            If tempconn.State = ConnectionState.Open Then tempconn.Close()
            tempconn.Open()
            DALEDGERS = New OleDbDataAdapter(tempcmd)
            DALEDGERS.Fill(DTBAL)

            If DTBAL.Rows.Count > 0 Then
                TOTALGROSSBAL += Format(Val(DTBAL.Rows(0).Item("GROSSWT")), "0.000")
                TOTALNETTBAL += Format(Val(DTBAL.Rows(0).Item("NETTWT")), "0.000")
                TOTALAMTBAL += Format(Val(DTBAL.Rows(0).Item("AMOUNT")), "0.00")
            End If

            tempconn.Close()
            DALEDGERS.Dispose()
            tempcmd.Dispose()

            txtbhavcut.Text = Format(Val((TOTALNETTJAMA) - Val(TOTALNETTBAL)), "0.000")




            'Dim DT As New DataTable
            'tempcmd = New OleDbCommand("SELECT IIF(ISNULL(Sum(trialbalance.nettwt)) = TRUE , 0,Sum(trialbalance.nettwt))  AS BALWT FROM(TrialBalance) WHERE trialbalance.code = '" & cmbcode.Text.Trim & "'", tempconn)
            'da = New OleDbDataAdapter(tempcmd)
            'da.Fill(dt)
            'If dt.Rows.Count > 0 Then txtbhavcut.Text = Val(dt.Rows(0).Item("BALWT"))
            'If Val(txtbhavcut.Text.Trim) < 0 Then txtbhavcut.Text = Val(txtbhavcut.Text) * (-1)
            'tempconn.Close()
            'da.Dispose()

            txtbhavcut.Focus()
        End If

    End Sub

    Private Sub gridledger_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridledger.CellContentClick
        If gridledger.RowCount = 0 Then Exit Sub
        txtname.Text = ""
        GRIDDESCRIPTION.RowCount = 1
        enabilityfalse()
        nchng = 1
    End Sub

    Private Sub chkname_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkname.CheckStateChanged
        nchng = 1
        clear()
        lblbalcfamtissue.Text = "0.00"
        lblbalcfgrosswtissue.Text = "0.000"
        lblbalcfamtjama.Text = "0.00"
        lblbalcfgrosswtjama.Text = "0.000"
        lblbalbfamtissue.Text = "0.00"
        lblbalbfgrosswtissue.Text = "0.000"
        lblbalbfamtjama.Text = "0.00"
        lblbalbfgrosswtjama.Text = "0.000"
        lblbalbfnettwtissue.Text = "0.000"
        lblbalbfnettwtjama.Text = "0.000"
        lblbalcfnettwtissue.Text = "0.000"
        lblbalcfnettwtjama.Text = "0.000"
        dtpickerkhata.Value = Now.Date
        If item <> 1 Then
            fillitem()
            item = 1
        End If
        If gridledger.RowCount > 0 Then tempname = gridledger.Rows(gridledger.CurrentRow.Index).Cells(0).Value.ToString
        'fillbal()
        If chkname.Checked = True Then
            If tempname <> "" Then
                tempcmd = New OleDbCommand("select ledger_id,ledger_code ,ledgermaster.ledger_opbalrs, IIF(ISNULL(ledgermaster.ledger_drcrrs) = True, 'Cr.' , ledgermaster.ledger_drcrrs) , ledgermaster.ledger_opbalwt, IIF(ISNULL(ledgermaster.ledger_drcrWT) = True, 'Cr.' , ledgermaster.ledger_drcrWT) from ledgermaster where ledger_code = '" & tempname & "'", tempconn)
                If tempconn.State = ConnectionState.Open Then
                    tempconn.Close()
                End If
                tempconn.Open()
                tempdr = tempcmd.ExecuteReader()
                If tempdr.HasRows Then
                    tempdr.Read()

                    tempnameid = tempdr(0)
                    cmbcode.Text = tempdr(1).ToString
                    tempname = tempdr(1).ToString
                    If tempdr(3) = "Cr." Then

                        lblbalbfamtjama.Text = Format(Val(tempdr(2)), "0.00")
                    Else

                        lblbalbfamtissue.Text = Format(Val(tempdr(2)), "0.00")
                    End If
                    If tempdr(5) = "Cr." Then

                        lblbalbfnettwtjama.Text = Format(Val(tempdr(4)), "0.000")
                    Else

                        lblbalbfnettwtissue.Text = Format(Val(tempdr(4)), "0.000")
                    End If
                Else

                End If
                tempconn.Close()

            End If
        End If
        openingbal()
        fillissue()
        filljama()

        totalofgrid()
        closingbalance()
        GRIDDESCRIPTION.RowCount = 1

    End Sub

    Private Sub gridledger_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridledger.SelectionChanged
        If nchng = 1 Then
            If gridledger.RowCount > 0 And clk = True Then
                tempname = gridledger.Item(0, gridledger.CurrentRow.Index).Value.ToString
                cmbcode.Text = tempname
            Else
                clk = True
            End If
            lblbalcfamtissue.Text = "0.00"
            lblbalcfgrosswtissue.Text = "0.000"
            lblbalcfamtjama.Text = "0.00"
            lblbalcfgrosswtjama.Text = "0.000"
            lblbalbfamtissue.Text = "0.00"
            lblbalbfgrosswtissue.Text = "0.000"
            lblbalbfamtjama.Text = "0.00"
            lblbalbfgrosswtjama.Text = "0.000"

            lblbalbfnettwtissue.Text = "0.000"
            lblbalbfnettwtjama.Text = "0.000"
            lblbalcfnettwtissue.Text = "0.000"
            lblbalcfnettwtjama.Text = "0.000"

            If chkname.Checked = True Then
                If tempname <> "" Then
                    tempcmd = New OleDbCommand("select ledger_id,ledger_code ,ledgermaster.ledger_opbalrs, IIF(ISNULL(ledgermaster.ledger_drcrrs ) = TRUE , 'Dr.',  ledgermaster.ledger_drcrrs) AS DRCR, ledgermaster.ledger_opbalwt, IIF(ISNULL( ledgermaster.ledger_drcrwt ) = TRUE , 'Dr.', ledgermaster.ledger_drcrwt) AS DRCRWT  from ledgermaster where ledger_code = '" & tempname & "'", tempconn)
                    If tempconn.State = ConnectionState.Open Then
                        tempconn.Close()
                    End If
                    tempconn.Open()
                    tempdr = tempcmd.ExecuteReader()
                    If tempdr.HasRows Then
                        tempdr.Read()

                        tempnameid = tempdr(0)
                        cmbcode.Text = tempdr(1).ToString
                        tempname = tempdr(1).ToString
                        If tempdr(3) = "Cr." Then

                            lblbalbfamtjama.Text = Format(Val(tempdr(2)), "0.00")
                        Else

                            lblbalbfamtissue.Text = Format(Val(tempdr(2)), "0.00")
                        End If
                        If tempdr(5) = "Cr." Then

                            lblbalbfnettwtjama.Text = Format(Val(tempdr(4)), "0.000")
                        Else

                            lblbalbfnettwtissue.Text = Format(Val(tempdr(4)), "0.000")
                        End If
                    Else

                    End If
                    tempconn.Close()

                End If
            End If
            clear()
            If tempnameid <> 0 Then

                openingbal()
                fillissue()
                filljama()
                totalofgrid()
                closingbalance()
            End If
        End If
    End Sub

    Private Sub txtbhavcut_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtbhavcut.Validating, txtrate.Validating
        total()
    End Sub

    Private Sub txtperwt_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtperwt.Validating, txtcashrec.Validating
        If Val(txtrate.Text) <> 0 And Val(txtperwt.Text) <> 0 And Val(txtpurity.Text) <> 0 Then
            'OG CODE
            If Val(TXTAMOUNT.Text) <> 0 And Val(txtrate.Text) <> 0 And Val(txtperwt.Text) <> 0 And (cmbtype.Text.Trim = "Bhavcut On Rec Amt." Or cmbtype.Text.Trim = "Bhavcut On Inv Amt.") Then
                txtbhavcut.Text = 0.0
                txtbhavcut.Text = Format(Val(TXTAMOUNT.Text) / (Val(txtrate.Text) / Val(txtperwt.Text)), "0.000")
                total()
                Exit Sub
            End If


            If Val(txtrate.Text) <> 0 And Val(txtpurity.Text) <> 0 And Val(txtperwt.Text) <> 0 And Val(txtbhavcut.Text) = 0 Then

                TXTAMOUNT.Text = Format(((Val(txtrate.Text) * Val(txtpurity.Text) / 100) / Val(txtperwt.Text)) * Val(LBLFINEWTTOTAL.Text), "0.000")
                TXTAMOUNT.Text = Val(TXTAMOUNT.Text)
                txtbalamt.Text = Val(lblamounttotal.Text) + Val(TXTAMOUNT.Text)
                txtbalwt.Text = 0.0

            ElseIf Val(txtrate.Text) <> 0 And Val(txtpurity.Text) <> 0 And Val(txtperwt.Text) <> 0 And Val(txtbhavcut.Text) <> 0 Then

                TXTAMOUNT.Text = ((Val(txtrate.Text) * Val(txtpurity.Text) / 100) / Val(txtperwt.Text)) * Val(txtbhavcut.Text)
                TXTAMOUNT.Text = Val(TXTAMOUNT.Text)
                txtbalamt.Text = Val(lblamounttotal.Text) + Val(TXTAMOUNT.Text)
                txtbalwt.Text = Val(LBLFINEWTTOTAL.Text) - Val(txtbhavcut.Text)

            ElseIf (txtrate.Text = "0" Or txtrate.Text = "") And (txtbhavcut.Text = "0" Or txtbhavcut.Text = "") And (txtperwt.Text = "0" Or txtperwt.Text = "") Then

                TXTAMOUNT.Text = "0"
                txtbalamt.Text = Format(Val(lblamounttotal.Text) + Val(TXTAMOUNT.Text), "0.00")
                txtbalwt.Text = Format(Val(LBLFINEWTTOTAL.Text) - Val(txtbhavcut.Text), "0.000")

            End If

        End If
        total()
    End Sub

    Private Sub txtname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtname.Validating
        'DONE BY GULKIT.... DO NOT OPEN THIS CODE... THIS CODE TAKES TIME... SO FOR PERFOMANCE OPTIMIZATION WE HAVE COMMENTED THE CODE
        'If chkname.Checked = True Then
        '    If tempname <> "" Then
        '        cmd = New OleDbCommand("select ledger_id,ledger_code from ledgermaster where ledger_code = '" & tempname & "'", conn)
        '        If conn.State = ConnectionState.Open Then
        '            conn.Close()
        '        End If
        '        conn.Open()
        '        dr = cmd.ExecuteReader()
        '        If dr.HasRows Then
        '            dr.Read()

        '            tempnameid = dr(0)
        '            cmbcode.Text = dr(1).ToString
        '            tempname = dr(1).ToString
        '        Else

        '        End If
        '        conn.Close()

        '    End If
        'End If
        'clear()
        'If tempnameid <> 0 Then
        '    openingbal()
        '    fillissue()
        '    filljama()
        '    totalofgrid()
        '    closingbalance()
        'End If
    End Sub

    Private Sub chkdate_CheckStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkdate.CheckStateChanged

        ' dailykhata_Shown(sender, e)
        clear()
        lblbalcfamtissue.Text = "0.00"
        lblbalcfgrosswtissue.Text = "0.000"
        lblbalcfamtjama.Text = "0.00"
        lblbalcfgrosswtjama.Text = "0.000"
        lblbalbfamtissue.Text = "0.00"
        lblbalbfgrosswtissue.Text = "0.000"
        lblbalbfamtjama.Text = "0.00"
        lblbalbfgrosswtjama.Text = "0.000"
        lblbalbfnettwtissue.Text = "0.000"
        lblbalbfnettwtjama.Text = "0.000"
        lblbalcfnettwtissue.Text = "0.000"
        lblbalcfnettwtjama.Text = "0.000"
        dtpickerkhata.Value = Now.Date
        If item <> 1 Then
            fillitem()
            item = 1
        End If
        If gridledger.RowCount > 0 Then tempname = gridledger.Rows(gridledger.CurrentRow.Index).Cells(0).Value.ToString
        'fillbal()
        If chkname.Checked = True Then
            If tempname <> "" Then
                tempcmd = New OleDbCommand("select ledger_id,ledger_code ,ledgermaster.ledger_opbalrs, IIF(ISNULL(ledgermaster.ledger_drcrrs ) = TRUE , 'Cr.' , ledgermaster.ledger_drcrrs), ledgermaster.ledger_opbalwt, IIF( ISNULL(ledgermaster.ledger_drcrwt) = TRUE, 'Cr.', LEDGERMASTER.LEDGER_DRCRWT) from ledgermaster where ledger_code = '" & tempname & "'", tempconn)
                If tempconn.State = ConnectionState.Open Then
                    tempconn.Close()
                End If
                tempconn.Open()
                tempdr = tempcmd.ExecuteReader()
                If tempdr.HasRows Then
                    tempdr.Read()

                    tempnameid = tempdr(0)
                    cmbcode.Text = tempdr(1).ToString
                    tempname = tempdr(1).ToString
                    If tempdr(3) = "Cr." Then

                        lblbalbfamtjama.Text = Format(Val(tempdr(2)), "0.00")
                    Else

                        lblbalbfamtissue.Text = Format(Val(tempdr(2)), "0.00")
                    End If
                    If tempdr(5) = "Cr." Then

                        lblbalbfnettwtjama.Text = Format(Val(tempdr(4)), "0.000")
                    Else

                        lblbalbfnettwtissue.Text = Format(Val(tempdr(4)), "0.000")
                    End If
                Else

                End If
                tempconn.Close()

            End If
        End If
        openingbal()
        fillissue()
        filljama()

        totalofgrid()
        closingbalance()
        GRIDDESCRIPTION.RowCount = 1
        If chkdate.Checked = True Then
            dtpfrom.Enabled = True
            dtpto.Enabled = True
        Else
            dtpfrom.Enabled = False
            dtpto.Enabled = False
        End If
    End Sub

    Private Sub dtpto_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpto.TextChanged
        'dailykhata_Shown(sender, e)

        clear()
        lblbalcfamtissue.Text = "0.00"
        lblbalcfgrosswtissue.Text = "0.000"
        lblbalcfamtjama.Text = "0.00"
        lblbalcfgrosswtjama.Text = "0.000"
        lblbalbfamtissue.Text = "0.00"
        lblbalbfgrosswtissue.Text = "0.000"
        lblbalbfamtjama.Text = "0.00"
        lblbalbfgrosswtjama.Text = "0.000"
        lblbalbfnettwtissue.Text = "0.000"
        lblbalbfnettwtjama.Text = "0.000"
        lblbalcfnettwtissue.Text = "0.000"
        lblbalcfnettwtjama.Text = "0.000"
        dtpickerkhata.Value = Now.Date
        If item <> 1 Then
            fillitem()
            item = 1
        End If
        tempname = gridledger.Rows(gridledger.CurrentRow.Index).Cells(0).Value.ToString
        'fillbal()
        If Format(dtpfrom.Value, "dd/MM/yyyy") <= Format(dtpto.Value, "dd/MM/yyyy") Then
            If chkname.Checked = True Then
                If tempname <> "" Then
                    tempcmd = New OleDbCommand("select ledger_id,ledger_code ,ledgermaster.ledger_opbalrs, ledgermaster.ledger_drcrrs, ledgermaster.ledger_opbalwt, ledgermaster.ledger_drcrwt from ledgermaster where ledger_code = '" & tempname & "'", tempconn)
                    If tempconn.State = ConnectionState.Open Then
                        tempconn.Close()
                    End If
                    tempconn.Open()
                    tempdr = tempcmd.ExecuteReader()
                    If tempdr.HasRows Then
                        tempdr.Read()

                        tempnameid = tempdr(0)
                        cmbcode.Text = tempdr(1).ToString
                        tempname = tempdr(1).ToString
                        If tempdr(3) = "Cr." Then

                            lblbalbfamtjama.Text = Format(Val(tempdr(2)), "0.00")
                        Else

                            lblbalbfamtissue.Text = Format(Val(tempdr(2)), "0.00")
                        End If
                        If tempdr(5) = "Cr." Then

                            lblbalbfnettwtjama.Text = Format(Val(tempdr(4)), "0.000")
                        Else

                            lblbalbfnettwtissue.Text = Format(Val(tempdr(4)), "0.000")
                        End If
                    Else

                    End If
                    tempconn.Close()

                End If
            End If
            openingbal()
            fillissue()
            filljama()

            totalofgrid()
            closingbalance()
            GRIDDESCRIPTION.RowCount = 1
        End If
    End Sub

    Private Sub dtpfrom_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpfrom.TextChanged
        'dailykhata_Shown(sender, e)

        clear()
        lblbalcfamtissue.Text = "0.00"
        lblbalcfgrosswtissue.Text = "0.000"
        lblbalcfamtjama.Text = "0.00"
        lblbalcfgrosswtjama.Text = "0.000"
        lblbalbfamtissue.Text = "0.00"
        lblbalbfgrosswtissue.Text = "0.000"
        lblbalbfamtjama.Text = "0.00"
        lblbalbfgrosswtjama.Text = "0.000"
        lblbalbfnettwtissue.Text = "0.000"
        lblbalbfnettwtjama.Text = "0.000"
        lblbalcfnettwtissue.Text = "0.000"
        lblbalcfnettwtjama.Text = "0.000"
        dtpickerkhata.Value = Now.Date
        If item <> 1 Then
            fillitem()
            item = 1
        End If
        tempname = gridledger.Rows(gridledger.CurrentRow.Index).Cells(0).Value.ToString
        'fillbal()
        If Format(dtpfrom.Value, "dd/MM/yyyy") <= Format(dtpto.Value, "dd/MM/yyyy") Then
            If chkname.Checked = True Then
                If tempname <> "" Then
                    tempcmd = New OleDbCommand("select ledger_id,ledger_code ,ledgermaster.ledger_opbalrs, ledgermaster.ledger_drcrrs, ledgermaster.ledger_opbalwt, ledgermaster.ledger_drcrwt from ledgermaster where ledger_code = '" & tempname & "'", tempconn)
                    If tempconn.State = ConnectionState.Open Then
                        tempconn.Close()
                    End If
                    tempconn.Open()
                    tempdr = tempcmd.ExecuteReader()
                    If tempdr.HasRows Then
                        tempdr.Read()

                        tempnameid = tempdr(0)
                        cmbcode.Text = tempdr(1).ToString
                        tempname = tempdr(1).ToString
                        If tempdr(3) = "Cr." Then

                            lblbalbfamtjama.Text = Format(Val(tempdr(2)), "0.00")
                        Else

                            lblbalbfamtissue.Text = Format(Val(tempdr(2)), "0.00")
                        End If
                        If tempdr(5) = "Cr." Then

                            lblbalbfnettwtjama.Text = Format(Val(tempdr(4)), "0.000")
                        Else

                            lblbalbfnettwtissue.Text = Format(Val(tempdr(4)), "0.000")
                        End If
                    Else

                    End If
                    tempconn.Close()

                End If
            End If
            openingbal()
            fillissue()
            filljama()

            totalofgrid()
            closingbalance()
            GRIDDESCRIPTION.RowCount = 1
        End If
    End Sub

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub toolprevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolprevious.Click
        If chkname.Checked = True Then
            If gridledger.RowCount > 0 And gridledger.CurrentRow.Index > 0 Then gridledger.CurrentCell = gridledger.Rows(gridledger.CurrentRow.Index - 1).Cells(0)
        Else
            dtpickerkhata.Value = DateAdd(DateInterval.Day, -1, dtpickerkhata.Value)
            dtpickerkhata_Validated(sender, e)
        End If
    End Sub

    Private Sub toolnext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolnext.Click
        If chkname.Checked = True Then
            If gridledger.RowCount > 0 Then
                If gridledger.CurrentRow.Index < gridledger.RowCount - 1 Then
                    gridledger.CurrentCell = gridledger.Rows(gridledger.CurrentRow.Index + 1).Cells(0)
                End If
            End If
        Else
            dtpickerkhata.Value = DateAdd(DateInterval.Day, 1, dtpickerkhata.Value)
            dtpickerkhata_Validated(sender, e)
        End If
    End Sub

    Private Sub SaveToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLSAVE.Click
        cmdok_Click(sender, e)
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLFIRST.Click
        tempcmd = New OleDbCommand("select account_date from accountmaster order by account_date", tempconn)
        If tempconn.State = ConnectionState.Open Then
            tempconn.Close()
        End If
        tempconn.Open()
        tempdr = tempcmd.ExecuteReader
        If tempdr.HasRows Then
            tempdr.Read()
            dtpickerkhata.Value = tempdr("account_date")
        End If
        tempdr.Close()
        tempconn.Close()
        clear()
        lblbalcfamtissue.Text = "0.00"
        lblbalcfgrosswtissue.Text = "0.000"
        lblbalcfamtjama.Text = "0.00"
        lblbalcfgrosswtjama.Text = "0.000"
        lblbalbfamtissue.Text = "0.00"
        lblbalbfgrosswtissue.Text = "0.000"
        lblbalbfamtjama.Text = "0.00"
        lblbalbfgrosswtjama.Text = "0.000"
        lblbalbfnettwtissue.Text = "0.000"
        lblbalbfnettwtjama.Text = "0.000"
        lblbalcfnettwtissue.Text = "0.000"
        lblbalcfnettwtjama.Text = "0.000"
        'dtpickerkhata.Value = NOW.DATE
        If item <> 1 Then
            fillitem()
            item = 1
        End If
        If gridledger.RowCount > 0 Then tempname = gridledger.Rows(gridledger.CurrentRow.Index).Cells(0).Value.ToString
        'fillbal()
        If chkname.Checked = True Then
            If tempname <> "" Then
                tempcmd = New OleDbCommand("select ledger_id,ledger_code ,ledgermaster.ledger_opbalrs, ledgermaster.ledger_drcrrs, ledgermaster.ledger_opbalwt, ledgermaster.ledger_drcrwt from ledgermaster where ledger_code = '" & tempname & "'", tempconn)
                If tempconn.State = ConnectionState.Open Then
                    tempconn.Close()
                End If
                tempconn.Open()
                tempdr = tempcmd.ExecuteReader()
                If tempdr.HasRows Then
                    tempdr.Read()

                    tempnameid = tempdr(0)
                    cmbcode.Text = tempdr(1).ToString
                    tempname = tempdr(1).ToString
                    If tempdr(3) = "Cr." Then

                        lblbalbfamtjama.Text = Format(Val(tempdr(2)), "0.00")
                    Else

                        lblbalbfamtissue.Text = Format(Val(tempdr(2)), "0.00")
                    End If
                    If tempdr(5) = "Cr." Then

                        lblbalbfnettwtjama.Text = Format(Val(tempdr(4)), "0.000")
                    Else

                        lblbalbfnettwtissue.Text = Format(Val(tempdr(4)), "0.000")
                    End If
                Else

                End If
                tempconn.Close()

            End If
        End If
        openingbal()
        fillissue()
        filljama()

        totalofgrid()
        closingbalance()
        GRIDDESCRIPTION.RowCount = 1
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLLAST.Click
        tempcmd = New OleDbCommand("select account_date from accountmaster order by account_date desc", tempconn)
        If tempconn.State = ConnectionState.Open Then
            tempconn.Close()
        End If
        tempconn.Open()
        tempdr = tempcmd.ExecuteReader
        If tempdr.HasRows Then
            tempdr.Read()
            dtpickerkhata.Value = tempdr("account_date")
        End If
        tempdr.Close()
        tempconn.Close()
        clear()
        lblbalcfamtissue.Text = "0.00"
        lblbalcfgrosswtissue.Text = "0.000"
        lblbalcfamtjama.Text = "0.00"
        lblbalcfgrosswtjama.Text = "0.000"
        lblbalbfamtissue.Text = "0.00"
        lblbalbfgrosswtissue.Text = "0.000"
        lblbalbfamtjama.Text = "0.00"
        lblbalbfgrosswtjama.Text = "0.000"
        lblbalbfnettwtissue.Text = "0.000"
        lblbalbfnettwtjama.Text = "0.000"
        lblbalcfnettwtissue.Text = "0.000"
        lblbalcfnettwtjama.Text = "0.000"
        'dtpickerkhata.Value = NOW.DATE
        If item <> 1 Then
            fillitem()
            item = 1
        End If
        If gridledger.RowCount > 0 Then tempname = gridledger.Rows(gridledger.CurrentRow.Index).Cells(0).Value.ToString
        'fillbal()
        If chkname.Checked = True Then
            If tempname <> "" Then
                tempcmd = New OleDbCommand("select ledger_id,ledger_code ,ledgermaster.ledger_opbalrs, ledgermaster.ledger_drcrrs, ledgermaster.ledger_opbalwt, ledgermaster.ledger_drcrwt from ledgermaster where ledger_code = '" & tempname & "'", tempconn)
                If tempconn.State = ConnectionState.Open Then
                    tempconn.Close()
                End If
                tempconn.Open()
                tempdr = tempcmd.ExecuteReader()
                If tempdr.HasRows Then
                    tempdr.Read()

                    tempnameid = tempdr(0)
                    cmbcode.Text = tempdr(1).ToString
                    tempname = tempdr(1).ToString
                    If tempdr(3) = "Cr." Then

                        lblbalbfamtjama.Text = Format(Val(tempdr(2)), "0.00")
                    Else

                        lblbalbfamtissue.Text = Format(Val(tempdr(2)), "0.00")
                    End If
                    If tempdr(5) = "Cr." Then

                        lblbalbfnettwtjama.Text = Format(Val(tempdr(4)), "0.000")
                    Else

                        lblbalbfnettwtissue.Text = Format(Val(tempdr(4)), "0.000")
                    End If
                Else

                End If
                tempconn.Close()

            End If
        End If
        openingbal()
        fillissue()
        filljama()

        totalofgrid()
        closingbalance()
        GRIDDESCRIPTION.RowCount = 1
    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLSETTLEMENT.Click
        Try

            'IF SETTLEMENT ISTO BE DONE THEN WENEEDTO ENTER ENTRYPASSWRD AS PER MEHUL BHAI
            If ClientName = "SHASHAWAT" Or ClientName = "SANGAM" Then
                Dim OBJPASS As New PasswordEntry
                OBJPASS.ShowDialog()
                If ENTRYPASSWORD <> OBJPASS.TXTDATERETYPE.Text.Trim Then
                    MsgBox("Invaid Password", MsgBoxStyle.Critical)
                    Exit Sub
                End If
            End If

            Dim OBJSETTLEMENT As New settlementdate
            OBJSETTLEMENT.MdiParent = MDIMain
            OBJSETTLEMENT.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub chkname_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkname.CheckedChanged
        If chkname.Checked = True Then
            account = True
            clk = True
            ''If gridledger.RowCount > 0 Then
            ''    On Error Resume Next
            ''    tempname = gridledger.Rows(gridledger.CurrentRow.Index).Cells(0).Value
            ''End If
        Else
            account = False
        End If
    End Sub

    Private Sub dtpto_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dtpto.Validating
        If dtpfrom.Value.Date > dtpto.Value.Date Then
            MsgBox("Date Is Not Valid")
            dtpto.Focus()
        End If
    End Sub

    Private Sub txtname_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtname.TextChanged
        nchng = 0
        lblbalcfamtissue.Text = "0.00"
        lblbalcfgrosswtissue.Text = "0.000"
        lblbalcfamtjama.Text = "0.00"
        lblbalcfgrosswtjama.Text = "0.000"
        lblbalbfamtissue.Text = "0.00"
        lblbalbfgrosswtissue.Text = "0.000"
        lblbalbfamtjama.Text = "0.00"
        lblbalbfgrosswtjama.Text = "0.000"

        lblbalbfnettwtissue.Text = "0.000"
        lblbalbfnettwtjama.Text = "0.000"
        lblbalcfnettwtissue.Text = "0.000"
        lblbalcfnettwtjama.Text = "0.000"

        If Trim(txtname.Text) <> "" Then
            For i = 0 To gridledger.RowCount - 1

                txttempname.Text = gridledger.Rows(i).Cells(0).Value.ToString
                txtname.Text = (txtname.Text.Trim)
                txttempname.SelectionStart = 0
                txttempname.SelectionLength = Len(txtname.Text)

                If LCase(txttempname.SelectedText) = LCase(Trim(txtname.Text)) Then
                    tempname = txttempname.Text.Trim
                    clk = False
                    gridledger.CurrentCell = gridledger.Rows(i).Cells(0)
                    gridledger.FirstDisplayedScrollingRowIndex = (i)
                    GoTo line1
                End If
            Next
        End If
line1:
        'DONE BY GULKIT.... DO NOT OPEN THIS CODE... THIS CODE TAKES TIME... SO FOR PERFOMANCE OPTIMIZATION WE HAVE COMMENTED THE CODE
        'If chkname.Checked = True Then
        '    If tempname <> "" Then
        '        tempcmd = New OleDbCommand("select ledger_id,ledger_code ,ledgermaster.ledger_opbalrs, IIF(ISNULL(ledgermaster.ledger_drcrrs) = TRUE ,'Cr.', ledgermaster.ledger_drcrrs), ledgermaster.ledger_opbalwt,IIF(ISNULL(ledgermaster.ledger_drcrwt) = TRUE ,'Cr.', ledgermaster.ledger_drcrwt) from ledgermaster where ledger_code = '" & tempname & "'", tempconn)
        '        If tempconn.State = ConnectionState.Open Then
        '            tempconn.Close()
        '        End If
        '        tempconn.Open()
        '        tempdr = tempcmd.ExecuteReader()
        '        If tempdr.HasRows Then
        '            tempdr.Read()

        '            tempnameid = tempdr(0)
        '            cmbcode.Text = tempdr(1).ToString
        '            tempname = tempdr(1).ToString
        '            If tempdr(3) = "Cr." Then
        '                lblbalbfamtjama.Text = Format(Val(tempdr(2)), "0.00")
        '            Else
        '                lblbalbfamtissue.Text = Format(Val(tempdr(2)), "0.00")
        '            End If
        '            If tempdr(5) = "Cr." Then
        '                lblbalbfnettwtjama.Text = Format(Val(tempdr(4)), "0.000")
        '            Else
        '                lblbalbfnettwtissue.Text = Format(Val(tempdr(4)), "0.000")
        '            End If
        '        End If
        '        tempconn.Close()
        '    End If
        'End If
        'clear()
        'If tempnameid <> 0 Then
        '    openingbal()
        '    fillissue()
        '    filljama()
        '    totalofgrid()
        '    closingbalance()
        'End If

    End Sub

    Private Sub ToolStripdelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLDELETE.Click
        Try
            DELETEENTRY(sender, e)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub DELETEENTRY(ByVal SENDER As Object, ByVal E As EventArgs)
        Try
            Dim rowno, b As Integer
            For Each row As DataGridViewRow In gridissue.SelectedRows
                tempbillno = row.Cells(6).Value.ToString
            Next
            For Each row As DataGridViewRow In gridjama.SelectedRows
                tempbillno = row.Cells(6).Value.ToString
            Next
            tempmsg = MsgBox("Wish To Delete Voucher?", MsgBoxStyle.YesNo)
            If tempmsg = vbYes Then

                'IF BACK DATED ENTRY IS TO BE SAVED THEN CHECK ENTRYPASSWORD
                If APPLYBLOCKDATE = True And dtpickerkhata.Value.Date <= BLOCKEDDATE.Date Then
                    Dim OBJPASS As New PasswordEntry
                    OBJPASS.ShowDialog()
                    If ENTRYPASSWORD <> OBJPASS.TXTDATERETYPE.Text.Trim Then
                        MsgBox("Invaid Password", MsgBoxStyle.Critical)
                        Exit Sub
                    End If
                End If

                'deleteing from Vouchers
                If cmbtype.Text.Trim = "Chitti Invoice" Then
                    cmd = New OleDbCommand("delete from vouchers where voucher_id = " & tempbillno & " and voucher_type ='I'", conn)
                ElseIf cmbtype.Text.Trim = "Chitti Reciept" Then
                    cmd = New OleDbCommand("delete from vouchers where voucher_id = " & tempbillno & " and voucher_type ='R'", conn)
                End If
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
                conn.Open()
                cmd.ExecuteNonQuery()


                cmd = New OleDbCommand("delete from accountmaster where account_voucherid = " & tempbillno & " and account_type ='" & types & "'", conn)

                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If

                conn.Open()
                cmd.ExecuteNonQuery()
                conn.Close()

                If cmbtype.Text = "Bhavcut On Rec Wt." Or cmbtype.Text = "Bhavcut On Rec Amt." Or cmbtype.Text = "Bhavcut On Inv Wt." Or cmbtype.Text = "Bhavcut On Inv Amt." Then

                    tempcmd = New OleDbCommand("delete from bhavcutmaster where bhavcut_id = " & tempbillno, tempconn)
                    If tempconn.State = ConnectionState.Open Then
                        tempconn.Close()
                    End If

                    tempconn.Open()
                    tempcmd.ExecuteNonQuery()
                    tempconn.Close()
                End If

            End If
            If chkname.Checked = False Then
                Call dailykhata_Shown(sender, e)

            Else
                clear()

                dtpickerkhata.Value = Now.Date
                enabilityfalse()
                If item <> 1 Then
                    fillitem()
                    item = 1
                End If
                fillbal()
                openingbal()
                fillissue()
                filljama()

                totalofgrid()
                closingbalance()
                GRIDDESCRIPTION.RowCount = 1
                If tempname <> "" Then

                    rowno = 0
                    For b = 1 To gridledger.RowCount - 1


                        ' txttempname.Text = tempname
                        ' gridledger.Item(0, rowno).Value.ToString()

                        txttempname.SelectionStart = 0
                        txttempname.SelectionLength = txtname.TextLength
                        If LCase(tempname) <> LCase(txttempname.SelectedText.Trim) Then
                            'gridledger.Rows.RemoveAt(rowno)
                        Else
                            rowno = rowno + 1
                        End If
                    Next
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtbhavcut_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtbhavcut.KeyPress
        numdotkeypress(e, txtbhavcut, Me)
    End Sub

    Private Sub txtrate_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtrate.KeyPress
        numdotkeypress(e, txtrate, Me)
    End Sub

    Private Sub txtperwt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtperwt.KeyPress
        numdotkeypress(e, txtperwt, Me)
    End Sub

    Private Sub txtamount_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        numdotkeypress(e, txtamount, Me)
    End Sub

    Private Sub txtcashrec_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcashrec.KeyPress
        numdotkeypress(e, txtcashrec, Me)
    End Sub

    Private Sub txtbalwt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtbalwt.KeyPress
        numdotkeypress(e, txtbalwt, Me)
    End Sub

    Private Sub txtbalamt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtbalamt.KeyPress
        numdotkeypress(e, txtbalamt, Me)
    End Sub

    Private Sub gridledger_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridledger.KeyDown
        If e.KeyCode = Keys.Delete Then
            tempcmd = New OleDbCommand("select ledger_id from ledgermaster where ledger_code = '" & tempname & "'", tempconn)
            If tempconn.State = ConnectionState.Open Then
                tempconn.Close()
            End If
            tempconn.Open()
            tempdr = tempcmd.ExecuteReader()
            If tempdr.HasRows Then
                tempdr.Read()
                tempnameid = tempdr(0)
            End If
            tempmsg = MsgBox("Wish To Delete Ledger?", MsgBoxStyle.YesNo)
            If tempmsg = vbYes Then
                If gridledger.Rows(gridledger.CurrentRow.Index).Cells(1).Value <> 0 Then
                    tempmsg = MsgBox("Ledger Contain transactions Wish to Continue?", MsgBoxStyle.YesNo)
                End If
                If tempmsg = vbYes Then
                    cmd = New OleDbCommand("delete from accountmaster where account_ledgerid = " & tempnameid, conn)
                    If conn.State = ConnectionState.Open Then
                        conn.Close()
                    End If
                    conn.Open()
                    cmd.ExecuteNonQuery()

                    cmd = New OleDbCommand("delete from vouchers where voucher_ledgerid = " & tempnameid, conn)
                    If conn.State = ConnectionState.Open Then
                        conn.Close()
                    End If
                    conn.Open()
                    cmd.ExecuteNonQuery()

                    cmd = New OleDbCommand("delete from ledgermaster where ledger_id = " & tempnameid, conn)
                    If conn.State = ConnectionState.Open Then
                        conn.Close()
                    End If
                    conn.Open()
                    cmd.ExecuteNonQuery()
                    MsgBox("Ledger Deleted")
                End If
            End If
            fillbal()
            gridledger.Refresh()
            clear()

        End If
    End Sub

    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLDELETELEDGER.Click

        tempcmd = New OleDbCommand("select ledger_id from ledgermaster where ledger_code = '" & tempname & "'", tempconn)
        If tempconn.State = ConnectionState.Open Then
            tempconn.Close()
        End If
        tempconn.Open()
        tempdr = tempcmd.ExecuteReader()
        If tempdr.HasRows Then
            tempdr.Read()
            tempnameid = tempdr(0)
        End If

        tempmsg = MsgBox("Wish To Delete Ledger?", MsgBoxStyle.YesNo)
        If tempmsg = vbYes Then
            cmd = New OleDbCommand("delete from accountmaster where account_ledgerid = " & tempnameid, conn)
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
            conn.Open()
            cmd.ExecuteNonQuery()

            cmd = New OleDbCommand("delete from vouchers where voucher_ledgerid = " & tempnameid, conn)
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
            conn.Open()
            cmd.ExecuteNonQuery()

            cmd = New OleDbCommand("delete from BHAVCUTMaster where bhavcut_ledgerid = " & tempnameid, conn)
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
            conn.Open()
            cmd.ExecuteNonQuery()

            tempcol(0) = "ledger_opbalrs"

            tempcol(1) = "ledger_opbalwt"

            tempval(0) = Val(0)

            tempval(1) = Val(0)
            tempcondition = " where ledger_name = '" & tempname & "'"
            modify("ledgermaster", tempcol, tempval, tempcondition)
            MessageBox.Show("Account Updated")
            fillbal()
            gridledger.Refresh()
            clear()
        End If







        lblbalcfamtissue.Text = "0.00"
        lblbalcfgrosswtissue.Text = "0.000"
        lblbalcfamtjama.Text = "0.00"
        lblbalcfgrosswtjama.Text = "0.000"
        lblbalbfamtissue.Text = "0.00"
        lblbalbfgrosswtissue.Text = "0.000"
        lblbalbfamtjama.Text = "0.00"
        lblbalbfgrosswtjama.Text = "0.000"
        lblbalbfnettwtissue.Text = "0.000"
        lblbalbfnettwtjama.Text = "0.000"
        lblbalcfnettwtissue.Text = "0.000"
        lblbalcfnettwtjama.Text = "0.000"
        dtpickerkhata.Value = Now.Date
        If item <> 1 Then
            fillitem()
            item = 1
        End If
        If gridledger.RowCount > 0 Then tempname = gridledger.Rows(gridledger.CurrentRow.Index).Cells(0).Value.ToString
        'fillbal()
        If chkname.Checked = True Then
            If tempname <> "" Then
                tempcmd = New OleDbCommand("select ledger_id,ledger_code ,ledgermaster.ledger_opbalrs, ledgermaster.ledger_drcrrs, ledgermaster.ledger_opbalwt, ledgermaster.ledger_drcrwt from ledgermaster where ledger_code = '" & tempname & "'", tempconn)
                If tempconn.State = ConnectionState.Open Then
                    tempconn.Close()
                End If
                tempconn.Open()
                tempdr = tempcmd.ExecuteReader()
                If tempdr.HasRows Then
                    tempdr.Read()

                    tempnameid = tempdr(0)
                    cmbcode.Text = tempdr(1).ToString
                    tempname = tempdr(1).ToString
                    If tempdr(3) = "Cr." Then

                        lblbalbfamtjama.Text = Format(Val(tempdr(2)), "0.00")
                    Else

                        lblbalbfamtissue.Text = Format(Val(tempdr(2)), "0.00")
                    End If
                    If tempdr(5) = "Cr." Then

                        lblbalbfnettwtjama.Text = Format(Val(tempdr(4)), "0.000")
                    Else

                        lblbalbfnettwtissue.Text = Format(Val(tempdr(4)), "0.000")
                    End If
                Else

                End If
                tempconn.Close()

            End If
        End If
        openingbal()
        fillissue()
        filljama()

        totalofgrid()
        closingbalance()
        GRIDDESCRIPTION.RowCount = 1
        If chkdate.Checked = True Then
            dtpfrom.Enabled = True
            dtpto.Enabled = True
        Else
            dtpfrom.Enabled = False
            dtpto.Enabled = False
        End If
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLPRINT.Click
        Try
            If chkname.CheckState = CheckState.Checked Then
                Dim OBJFILTER As New dailykhatafilter
                OBJFILTER.MdiParent = MDIMain
                OBJFILTER.cmbname.Text = gridledger.SelectedRows(0).Cells(0).Value
                If chkdate.CheckState = CheckState.Checked Then
                    OBJFILTER.chkdate.CheckState = CheckState.Checked
                    OBJFILTER.dtpfrom.Value = dtpfrom.Value
                    OBJFILTER.dtpto.Value = dtpto.Value
                End If
                OBJFILTER.Show()
            Else
                If gridissue.SelectedRows.Count = 0 And gridjama.SelectedRows.Count = 0 Then Exit Sub
                If gridissue.SelectedRows.Count > 0 Then
                    If ClientName <> "JAINAM" Then tempmsg = vbYes Else tempmsg = MsgBox("Print Single Entry Only?", MsgBoxStyle.YesNoCancel)
                    If tempmsg = vbYes Then
                        Dim OBJVOUCHER As New VoucherDesign
                        For Each ROW As DataGridViewRow In gridissue.SelectedRows
                            If ROW.Cells(5).Value = "A" Then
                                OBJVOUCHER.WHERECLAUSE = " {ACCOUNTMAST.ACCOUNT_VOUCHERID} = " & Val(ROW.Cells(6).Value) & " and {ACCOUNTMAST.ACCOUNT_TYPE} = 'A'"
                                OBJVOUCHER.FRMSTRING = "CHITTI"
                            ElseIf ROW.Cells(5).Value = "I" Or ROW.Cells(5).Value = "R" Then
                                OBJVOUCHER.WHERECLAUSE = " {VOUCHERS.VOUCHER_ID} = " & Val(ROW.Cells(6).Value) & " and {VOUCHERS.VOUCHER_TYPE} = '" & ROW.Cells(5).Value & "'"
                                If Val(txtcashrec.Text.Trim) > 0 Then OBJVOUCHER.FRMSTRING = "ISSUEBHAVCUTCHITTI" Else OBJVOUCHER.FRMSTRING = "ISSUECHITTI"
                            ElseIf ROW.Cells(5).Value = "B" Then
                                OBJVOUCHER.WHERECLAUSE = " {ACCOUNTMASTER.ACCOUNT_VOUCHERID} = " & Val(ROW.Cells(6).Value) & " and {ACCOUNTMASTER.ACCOUNT_TYPE} = 'B'"
                                If cmbtype.Text = "Bhavcut On Rec Wt." Then
                                    OBJVOUCHER.WHERECLAUSE = OBJVOUCHER.WHERECLAUSE & " AND {ACCOUNTMASTER.ACCOUNT_LEDGERCODE} <> 'Purchase' AND {ACCOUNTMASTER.ACCOUNT_LEDGERCODE} <> 'CASH' AND {ACCOUNTMASTER.ACCOUNT_BALORJAMAORPAID} = 'Jama'"
                                ElseIf cmbtype.Text = "Bhavcut On Inv Wt." Then
                                    OBJVOUCHER.WHERECLAUSE = OBJVOUCHER.WHERECLAUSE & " AND {ACCOUNTMASTER.ACCOUNT_LEDGERCODE} <> 'Sale' AND {ACCOUNTMASTER.ACCOUNT_LEDGERCODE} <> 'CASH' AND {ACCOUNTMASTER.ACCOUNT_BALORJAMAORPAID} = 'Balance'"
                                End If
                                OBJVOUCHER.FRMSTRING = "BHAVCUTISSREC"
                            End If
                            OBJVOUCHER.PARTYCODE = ROW.Cells(1).Value
                        Next
                        OBJVOUCHER.MdiParent = MDIMain
                        OBJVOUCHER.Show()
                    Else
                        'OPEN LEDGER FILTER WITH NAME AND TODAYS DATE
                        'Dim OBJLEDGER As New dailykhatafilter
                        'For Each ROW As DataGridViewRow In gridissue.SelectedRows
                        '    OBJLEDGER.cmbname.Text = ROW.Cells(1).Value
                        '    OBJLEDGER.chkdate.CheckState = CheckState.Checked
                        '    OBJLEDGER.dtpfrom.Value = dtpickerkhata.Value
                        '    OBJLEDGER.dtpto.Value = dtpickerkhata.Value
                        'Next
                        Dim OBJPRINT As New SelectEntryforPrint
                        For Each ROW As DataGridViewRow In gridissue.SelectedRows
                            OBJPRINT.cmbcode.Text = ROW.Cells(1).Value
                            OBJPRINT.dtpfrom.Value = dtpickerkhata.Value
                            OBJPRINT.dtpto.Value = dtpickerkhata.Value
                        Next
                        OBJPRINT.WHERECLAUSE = " and accountmaster.account_balorjamaorpaid='Balance' "
                        OBJPRINT.MdiParent = MDIMain
                        OBJPRINT.Show()

                    End If
                ElseIf gridjama.SelectedRows.Count > 0 Then
                    If ClientName <> "JAINAM" Then tempmsg = vbYes Else tempmsg = MsgBox("Print Single Entry Only?", MsgBoxStyle.YesNoCancel)
                    tempmsg = MsgBox("Print Single Entry Only?", MsgBoxStyle.YesNoCancel)
                    If tempmsg = vbYes Then
                        Dim OBJVOUCHER As New VoucherDesign
                        For Each ROW As DataGridViewRow In gridjama.SelectedRows
                            If ROW.Cells(5).Value = "A" Then
                                OBJVOUCHER.WHERECLAUSE = " {ACCOUNTMAST.ACCOUNT_VOUCHERID} = " & Val(ROW.Cells(6).Value) & " and {ACCOUNTMAST.ACCOUNT_TYPE} = 'A'"
                                OBJVOUCHER.FRMSTRING = "CHITTI"
                            ElseIf ROW.Cells(5).Value = "I" Or ROW.Cells(5).Value = "R" Then
                                OBJVOUCHER.WHERECLAUSE = " {VOUCHERS.VOUCHER_ID} = " & Val(ROW.Cells(6).Value) & " and {VOUCHERS.VOUCHER_TYPE} = '" & ROW.Cells(5).Value & "'"
                                If Val(txtcashrec.Text.Trim) > 0 Then OBJVOUCHER.FRMSTRING = "ISSUEBHAVCUTCHITTI" Else OBJVOUCHER.FRMSTRING = "ISSUECHITTI"
                            ElseIf ROW.Cells(5).Value = "B" Then
                                OBJVOUCHER.WHERECLAUSE = " {ACCOUNTMASTER.ACCOUNT_VOUCHERID} = " & Val(ROW.Cells(6).Value) & " and {ACCOUNTMASTER.ACCOUNT_TYPE} = 'B'"
                                If cmbtype.Text = "Bhavcut On Rec Wt." Then
                                    OBJVOUCHER.WHERECLAUSE = OBJVOUCHER.WHERECLAUSE & " AND {ACCOUNTMASTER.ACCOUNT_LEDGERCODE} <> 'Purchase' AND {ACCOUNTMASTER.ACCOUNT_LEDGERCODE} <> 'CASH' AND {ACCOUNTMASTER.ACCOUNT_BALORJAMAORPAID} = 'Jama'"
                                ElseIf cmbtype.Text = "Bhavcut On Inv Wt." Then
                                    OBJVOUCHER.WHERECLAUSE = OBJVOUCHER.WHERECLAUSE & " AND {ACCOUNTMASTER.ACCOUNT_LEDGERCODE} <> 'Sale' AND {ACCOUNTMASTER.ACCOUNT_LEDGERCODE} <> 'CASH' AND {ACCOUNTMASTER.ACCOUNT_BALORJAMAORPAID} = 'Balance'"
                                End If
                                OBJVOUCHER.FRMSTRING = "BHAVCUTISSREC"
                            End If
                            OBJVOUCHER.PARTYCODE = ROW.Cells(1).Value
                        Next

                        OBJVOUCHER.MdiParent = MDIMain
                        OBJVOUCHER.Show()
                    Else
                        'OPEN LEDGER FILTER WITH NAME AND TODAYS DATE
                        'Dim OBJLEDGER As New dailykhatafilter
                        'For Each ROW As DataGridViewRow In gridjama.SelectedRows
                        '    OBJLEDGER.cmbname.Text = ROW.Cells(1).Value
                        '    OBJLEDGER.chkdate.CheckState = CheckState.Checked
                        '    OBJLEDGER.dtpfrom.Value = dtpickerkhata.Value
                        '    OBJLEDGER.dtpto.Value = dtpickerkhata.Value
                        'Next
                        Dim OBJPRINT As New SelectEntryforPrint
                        For Each ROW As DataGridViewRow In gridjama.SelectedRows
                            OBJPRINT.cmbcode.Text = ROW.Cells(1).Value
                            OBJPRINT.dtpfrom.Value = dtpickerkhata.Value
                            OBJPRINT.dtpto.Value = dtpickerkhata.Value
                        Next
                        OBJPRINT.WHERECLAUSE = " and accountmaster.account_balorjamaorpaid='Jama' "
                        OBJPRINT.MdiParent = MDIMain
                        OBJPRINT.Show()
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtpurity_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtpurity.KeyPress
        numdotkeypress(e, txtpurity, Me)
    End Sub

    Private Sub cmbcode_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbcode.KeyPress
        enterkeypress(e, Me)
    End Sub

    Private Sub ToolStripButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLCHANGEDATE.Click
        Try
            Dim objDATE As New ChangeDate
            objDATE.predate = dtpickerkhata.Value.Date
            objDATE.ShowDialog()

            If CHANGED = True Then
                For Each ROW As DataGridViewRow In gridjama.Rows

                    enabilityfalse()
                    If gridissue.RowCount > 0 Then
                        gridissue.Rows(gridissue.CurrentRow.Index).Selected = False
                    End If
                    txtbhavcut.Text = "0.000"
                    TXTAMOUNT.Text = "0.00"
                    txtperwt.Text = "0.00"
                    txtrate.Text = "0.00"
                    txtbalamt.Text = "0.00"
                    txtbalwt.Text = "0.000"
                    txtcashrec.Text = "0.00"

                    GRIDDESCRIPTION.CurrentCell = GRIDDESCRIPTION.Rows(0).Cells(dggrosswt.Index)
                    GRIDDESCRIPTION.RowCount = 1
                    txtbillno.Text = Val(gridjama.Item(6, ROW.Index).Value)
                    types = gridjama.Item(5, ROW.Index).Value.ToString
                    If gridjama.Item(5, ROW.Index).Value.ToString = "A" Then
                        cmbtype.SelectedIndex = (0)
                    End If
                    filldetails(gridjama)

                    EDIT = True
                    cmbcode.Enabled = True
                    If cmbtype.Text = "Chitti Invoice" Or cmbtype.Text = "Chitti Reciept" Then

                        'JUST MODIFY THE DATE
                        'clearing array
                        For i = 1 To 100
                            tempcol(i) = ""
                            tempval(i) = ""
                        Next

                        tempcol(0) = "voucher_date"
                        tempval(0) = "'" & Format(CHANGEDDATE.Date, "dd/MM/yyyy") & "'"
                        modify("VOUCHERS", tempcol, tempval, " WHERE VOUCHERS.VOUCHER_ID = " & Val(txtbillno.Text.Trim))


                        tempcol(0) = "ACCOUNT_date"
                        tempval(0) = "'" & Format(CHANGEDDATE.Date, "dd/MM/yyyy") & "'"
                        modify("ACCOUNTMASTER", tempcol, tempval, " WHERE ACCOUNTMASTER.ACCOUNT_VOUCHERID = " & Val(txtbillno.Text.Trim) & " AND ACCOUNTMASTER.ACCOUNT_TYPE = 'R'")


                    Else
                        adding(CHANGEDDATE.Date)
                    End If
                Next

                For Each ROW As DataGridViewRow In gridissue.Rows

                    enabilityfalse()
                    If gridjama.RowCount > 0 Then
                        gridjama.Rows(gridjama.CurrentRow.Index).Selected = False
                    End If
                    txtbhavcut.Text = "0.000"
                    TXTAMOUNT.Text = "0.00"
                    txtperwt.Text = "0.00"
                    txtrate.Text = "0.00"
                    txtbalamt.Text = "0.00"
                    txtbalwt.Text = "0.000"
                    txtcashrec.Text = "0.00"

                    GRIDDESCRIPTION.CurrentCell = GRIDDESCRIPTION.Rows(0).Cells(dggrosswt.Index)
                    GRIDDESCRIPTION.RowCount = 1
                    txtbillno.Text = Val(gridissue.Item(6, ROW.Index).Value)
                    types = gridissue.Item(5, ROW.Index).Value.ToString
                    If gridissue.Item(5, ROW.Index).Value.ToString = "A" Then
                        cmbtype.SelectedIndex = (1)
                    End If

                    filldetails(gridissue)
                    EDIT = True
                    cmbcode.Enabled = True
                    If cmbtype.Text = "Chitti Invoice" Or cmbtype.Text = "Chitti Reciept" Then

                        'JUST MODIFY THE DATE
                        'clearing array
                        For i = 1 To 100
                            tempcol(i) = ""
                            tempval(i) = ""
                        Next

                        tempcol(0) = "voucher_date"
                        tempval(0) = "'" & Format(CHANGEDDATE.Date, "dd/MM/yyyy") & "'"
                        modify("VOUCHERS", tempcol, tempval, " WHERE VOUCHERS.VOUCHER_ID = " & Val(txtbillno.Text.Trim))

                        tempcol(0) = "ACCOUNT_date"
                        tempval(0) = "'" & Format(CHANGEDDATE.Date, "dd/MM/yyyy") & "'"
                        modify("ACCOUNTMASTER", tempcol, tempval, " WHERE ACCOUNTMASTER.ACCOUNT_VOUCHERID = " & Val(txtbillno.Text.Trim) & " AND ACCOUNTMASTER.ACCOUNT_TYPE = 'I'")


                    Else
                        adding(CHANGEDDATE.Date)
                    End If
                Next
                dtpickerkhata.Value = CHANGEDDATE.Date
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbcode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbcode.KeyDown
        Try
            If e.KeyCode = Keys.F2 Then
                Dim OBJLEDGER As New SelectLedger
                OBJLEDGER.ShowDialog()
                cmbcode.Text = OBJLEDGER.TEMPCODE
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridledger_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridledger.CellDoubleClick
        If e.RowIndex = -1 Then Exit Sub
    End Sub

    Private Sub TOOLPRINTDAILYKHATA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLPRINTDAILYKHATA.Click
        Try
            If chkname.CheckState = CheckState.Unchecked Then
                Dim TEMPMSG As Integer = MsgBox("Print Daily Khata?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbYes Then
                    Dim OBJVOUCHER As New VoucherDesign

                    OBJVOUCHER.OPGROSSJAMA = Val(lblbalbfgrosswtjama.Text)
                    OBJVOUCHER.OPGROSSISS = Val(lblbalbfgrosswtissue.Text)
                    OBJVOUCHER.OPNETTJAMA = Val(lblbalbfnettwtjama.Text)
                    OBJVOUCHER.OPNETTISS = Val(lblbalbfnettwtissue.Text)
                    OBJVOUCHER.OPAMTJAMA = Val(lblbalbfamtjama.Text)
                    OBJVOUCHER.OPAMTISS = Val(lblbalbfamtissue.Text)

                    OBJVOUCHER.TGROSSJAMA = Val(lbltotalgrossjama.Text)
                    OBJVOUCHER.TGROSSISS = Val(lbltotalgrossissue.Text)
                    OBJVOUCHER.TNETTJAMA = Val(lbltotalnettjama.Text)
                    OBJVOUCHER.TNETTISS = Val(lbltotalnettissue.Text)
                    OBJVOUCHER.TAMTJAMA = Val(lbltotalamtjama.Text)
                    OBJVOUCHER.TAMTISS = Val(lbltotalamtissue.Text)


                    OBJVOUCHER.CLGROSSJAMA = Val(lblbalcfgrosswtjama.Text)
                    OBJVOUCHER.CLGROSSISS = Val(lblbalcfgrosswtissue.Text)
                    OBJVOUCHER.CLNETTJAMA = Val(lblbalcfnettwtjama.Text)
                    OBJVOUCHER.CLNETTISS = Val(lblbalcfnettwtissue.Text)
                    OBJVOUCHER.CLAMTJAMA = Val(lblbalcfamtjama.Text)
                    OBJVOUCHER.CLAMTISS = Val(lblbalcfgrosswtissue.Text)


                    OBJVOUCHER.FRMSTRING = "DAILYKHATA"
                    If chkdate.CheckState = CheckState.Unchecked Then
                        getFromToDate(dtpickerkhata.Value, dtpickerkhata.Value)
                        OBJVOUCHER.WHERECLAUSE = " {COMMAND.ACCOUNT_DATE} in date " & fromD & " to date " & fromD
                        OBJVOUCHER.PERIOD = Format(dtpickerkhata.Value.Date, "dd/MM/yyyy").ToString
                    Else
                        getFromToDate(dtpfrom.Value, dtpto.Value)
                        OBJVOUCHER.WHERECLAUSE = " {COMMAND.ACCOUNT_DATE} in date " & fromD & " to date " & toD
                        OBJVOUCHER.PERIOD = Format(dtpfrom.Value.Date, "dd/MM/yyyy").ToString & " - " & Format(dtpto.Value.Date, "dd/MM/yyyy").ToString
                    End If
                    OBJVOUCHER.MdiParent = MDIMain
                    OBJVOUCHER.Show()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub getFromToDate(ByVal FDATE As Date, ByVal TDATE As Date)
        a1 = DatePart(DateInterval.Day, FDATE)
        a2 = DatePart(DateInterval.Month, FDATE)
        a3 = DatePart(DateInterval.Year, FDATE)
        fromD = "(" & a3 & "," & a2 & "," & a1 & ")"

        a11 = DatePart(DateInterval.Day, TDATE)
        a12 = DatePart(DateInterval.Month, TDATE)
        a13 = DatePart(DateInterval.Year, TDATE)
        toD = "(" & a13 & "," & a12 & "," & a11 & ")"
    End Sub

    Private Sub dtpickerkhata_Validated(sender As Object, e As EventArgs) Handles dtpickerkhata.Validated
        If chkname.Checked = False And chkdate.Checked = False Then
            dailykhata_Shown(sender, e)
        End If
    End Sub

    Private Sub TOOLCHANGEENTRYDATE_Click(sender As Object, e As EventArgs) Handles TOOLCHANGEENTRYDATE.Click
        Try
            Dim objDATE As New ChangeDate
            objDATE.predate = dtpickerkhata.Value.Date
            objDATE.ShowDialog()

            If CHANGED = True Then
                For Each ROW As DataGridViewRow In gridjama.SelectedRows

                    enabilityfalse()
                    If gridissue.RowCount > 0 Then
                        gridissue.Rows(gridissue.CurrentRow.Index).Selected = False
                    End If
                    txtbhavcut.Text = "0.000"
                    TXTAMOUNT.Text = "0.00"
                    txtperwt.Text = "0.00"
                    txtrate.Text = "0.00"
                    txtbalamt.Text = "0.00"
                    txtbalwt.Text = "0.000"
                    txtcashrec.Text = "0.00"

                    GRIDDESCRIPTION.CurrentCell = GRIDDESCRIPTION.Rows(0).Cells(dggrosswt.Index)
                    GRIDDESCRIPTION.RowCount = 1
                    txtbillno.Text = Val(gridjama.Item(6, ROW.Index).Value)
                    types = gridjama.Item(5, ROW.Index).Value.ToString
                    If gridjama.Item(5, ROW.Index).Value.ToString = "A" Then
                        cmbtype.SelectedIndex = (0)
                    End If
                    filldetails(gridjama)

                    EDIT = True
                    cmbcode.Enabled = True
                    If cmbtype.Text = "Chitti Invoice" Or cmbtype.Text = "Chitti Reciept" Then

                        'JUST MODIFY THE DATE
                        'clearing array
                        For i = 1 To 100
                            tempcol(i) = ""
                            tempval(i) = ""
                        Next

                        tempcol(0) = "voucher_date"
                        tempval(0) = "'" & Format(CHANGEDDATE.Date, "dd/MM/yyyy") & "'"
                        modify("VOUCHERS", tempcol, tempval, " WHERE VOUCHERS.VOUCHER_ID = " & Val(txtbillno.Text.Trim))


                        tempcol(0) = "ACCOUNT_date"
                        tempval(0) = "'" & Format(CHANGEDDATE.Date, "dd/MM/yyyy") & "'"
                        modify("ACCOUNTMASTER", tempcol, tempval, " WHERE ACCOUNTMASTER.ACCOUNT_VOUCHERID = " & Val(txtbillno.Text.Trim) & " AND ACCOUNTMASTER.ACCOUNT_TYPE = 'R'")


                    Else
                        adding(CHANGEDDATE.Date)
                    End If
                Next

                For Each ROW As DataGridViewRow In gridissue.SelectedRows

                    enabilityfalse()
                    If gridjama.RowCount > 0 Then
                        gridjama.Rows(gridjama.CurrentRow.Index).Selected = False
                    End If
                    txtbhavcut.Text = "0.000"
                    TXTAMOUNT.Text = "0.00"
                    txtperwt.Text = "0.00"
                    txtrate.Text = "0.00"
                    txtbalamt.Text = "0.00"
                    txtbalwt.Text = "0.000"
                    txtcashrec.Text = "0.00"

                    GRIDDESCRIPTION.CurrentCell = GRIDDESCRIPTION.Rows(0).Cells(dggrosswt.Index)
                    GRIDDESCRIPTION.RowCount = 1
                    txtbillno.Text = Val(gridissue.Item(6, ROW.Index).Value)
                    types = gridissue.Item(5, ROW.Index).Value.ToString
                    If gridissue.Item(5, ROW.Index).Value.ToString = "A" Then
                        cmbtype.SelectedIndex = (1)
                    End If

                    filldetails(gridissue)
                    EDIT = True
                    cmbcode.Enabled = True
                    If cmbtype.Text = "Chitti Invoice" Or cmbtype.Text = "Chitti Reciept" Then

                        'JUST MODIFY THE DATE
                        'clearing array
                        For i = 1 To 100
                            tempcol(i) = ""
                            tempval(i) = ""
                        Next

                        tempcol(0) = "voucher_date"
                        tempval(0) = "'" & Format(CHANGEDDATE.Date, "dd/MM/yyyy") & "'"
                        modify("VOUCHERS", tempcol, tempval, " WHERE VOUCHERS.VOUCHER_ID = " & Val(txtbillno.Text.Trim))

                        tempcol(0) = "ACCOUNT_date"
                        tempval(0) = "'" & Format(CHANGEDDATE.Date, "dd/MM/yyyy") & "'"
                        modify("ACCOUNTMASTER", tempcol, tempval, " WHERE ACCOUNTMASTER.ACCOUNT_VOUCHERID = " & Val(txtbillno.Text.Trim) & " AND ACCOUNTMASTER.ACCOUNT_TYPE = 'I'")


                    Else
                        adding(CHANGEDDATE.Date)
                    End If
                Next
                dtpickerkhata.Value = CHANGEDDATE.Date
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class