
Imports System.Data.OleDb

Public Class StockWithKarigarWastageFine

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub StockWithKarigarWastageFine_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                Me.Close()
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub StockWithKarigarWastageFine_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            FILLGRID()
            FILLLOSS()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLLOSS()
        Try
            Dim LOSSDT As New DataTable
            If tempconn.State = ConnectionState.Open Then tempconn.Close()
            tempconn.Open()
            tempcmd = New OleDbCommand(" SELECT ROUND(SUM(ACCOUNTMASTER.ACCOUNT_NETTWT),3) AS LOSSWT FROM ACCOUNTMASTER WHERE (((ACCOUNTMASTER.ACCOUNT_TYPE)='A') AND ((ACCOUNTMASTER.ACCOUNT_BALORJAMAORPAID)='Balance') AND ((ACCOUNTMASTER.ACCOUNT_LEDGERCODE)='LOSS AC')) UNION ALL SELECT ROUND(SUM(ACCOUNTMASTER.ACCOUNT_NETTWT)*(-1),3) AS LOSSWT FROM ACCOUNTMASTER WHERE (((ACCOUNTMASTER.ACCOUNT_TYPE)='A') AND ((ACCOUNTMASTER.ACCOUNT_BALORJAMAORPAID)='Jama') AND ((ACCOUNTMASTER.ACCOUNT_LEDGERCODE)='LOSS AC')) UNION ALL SELECT ROUND(SUM((mfgWastage.mfg_loss * mfg_melting)/100),3) AS LOSS FROM mfgWastage WHERE (((mfgWastage.mfg_loss)<>0))", tempconn)
            da = New OleDbDataAdapter(tempcmd)
            da.Fill(LOSSDT)
            If LOSSDT.Rows.Count > 0 Then TXTLOSS.Text = Val(LOSSDT.Compute("SUM(LOSSWT)", ""))
            da.Dispose()
            tempcmd.Dispose()

            If ClientName = "SHASHAWAT" Or ClientName = "SANGAM" Then
                TXTTOTALGROSS.Text = Format(Val(GNETTWT.SummaryText) + Val(GWASTAGEFINE.SummaryText) + Val(GKARIGARFINE.SummaryText), "0.000")
            Else
                TXTTOTALGROSS.Text = Format(Val(GNETTWT.SummaryText) + Val(GWASTAGEFINE.SummaryText) + Val(GKARIGARFINE.SummaryText) + Val(TXTLOSS.Text.Trim), "0.000")
            End If


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLGRID()


        Dim WHERECLAUSE As String = " AND STOCKS.ITEM_DATE <= #" & Format(TILLDATE.Value.Date, "MM/dd/yyyy") & "#"
        Dim GROUPBYCLAUSE As String = ""
        If USERDEPARTMENT <> "" Then WHERECLAUSE = WHERECLAUSE & " AND STOCKS.DEPARTMENT = '" & USERDEPARTMENT & "'"
        If USERDEPARTMENT <> "" Then GROUPBYCLAUSE = GROUPBYCLAUSE & ", STOCKS.DEPARTMENT "

        'getting DETAILS
        Dim dt As New DataTable()
        If tempconn.State = ConnectionState.Open Then tempconn.Close()
        tempconn.Open()
        If ClientName = "SKYLINE" Then
            tempcmd = New OleDbCommand("SELECT STOCKS.ITEM_CODE AS ITEMCODE, '' AS NARRATION, STOCKS.ITEM_PURITY AS PURITY, ROUND(Sum(STOCKS.ITEM_GROSSWT),3) AS GROSSWT, ROUND(Sum(STOCKS.ITEM_NETTWT),3) AS NETTWT  FROM Stocks WHERE 1=1 " & WHERECLAUSE & " GROUP BY STOCKS.ITEM_CODE, STOCKS.ITEM_PURITY " & GROUPBYCLAUSE & " HAVING ROUND(Sum(STOCKS.ITEM_NETTWT),2) <> 0 ORDER BY STOCKS.ITEM_CODE", tempconn)
        Else
            tempcmd = New OleDbCommand("SELECT STOCKS.ITEM_CODE AS ITEMCODE, STOCKS.NARRATION, STOCKS.ITEM_PURITY AS PURITY, ROUND(Sum(STOCKS.ITEM_GROSSWT),3) AS GROSSWT, ROUND(Sum(STOCKS.ITEM_NETTWT),3) AS NETTWT  FROM Stocks WHERE 1=1 " & WHERECLAUSE & " GROUP BY STOCKS.ITEM_CODE, STOCKS.NARRATION, STOCKS.ITEM_PURITY " & GROUPBYCLAUSE & " HAVING ROUND(Sum(STOCKS.ITEM_NETTWT),2) <> 0 ORDER BY STOCKS.ITEM_CODE", tempconn)
        End If
        da = New OleDbDataAdapter(tempcmd)
        da.Fill(dt)
        gridStock.DataSource = dt


        'GET DISINTCT WASTAGELEDGERS AND FILL IN WASTGEGRID
        Dim WASTAGEDT As New DataTable
        Dim LEDGERDT As New DataTable
        If tempconn.State = ConnectionState.Open Then tempconn.Close()
        tempconn.Open()
        tempcmd = New OleDbCommand("SELECT DISTINCT LEDGER_NAME AS LEDGERNAME FROM MFGWASTAGE", tempconn)
        da = New OleDbDataAdapter(tempcmd)
        da.Fill(LEDGERDT)
        WHERECLAUSE = ""
        If LEDGERDT.Rows.Count > 0 Then
            For Each DTROW As DataRow In LEDGERDT.Rows
                If WHERECLAUSE = "" Then
                    WHERECLAUSE = " AND LEDGERNAME IN ('" & DTROW("LEDGERNAME") & "'"
                Else
                    WHERECLAUSE += ",'" & DTROW("LEDGERNAME") & "'"
                End If
            Next
            If WHERECLAUSE <> "" Then WHERECLAUSE += ")"

            WHERECLAUSE = WHERECLAUSE & " AND WASTAGEREPORT.DATE <= #" & Format(TILLDATE.Value.Date, "MM/dd/yyyy") & "#"

            GROUPBYCLAUSE = ""
            If USERDEPARTMENT <> "" Then WHERECLAUSE = WHERECLAUSE & " And WASTAGEREPORT.DEPARTMENT = '" & USERDEPARTMENT & "'"
            If USERDEPARTMENT <> "" Then GROUPBYCLAUSE = GROUPBYCLAUSE & ", WASTAGEREPORT.DEPARTMENT "

            If tempconn.State = ConnectionState.Open Then tempconn.Close()
            tempconn.Open()
            tempcmd = New OleDbCommand(" SELECT ROUND(SUM(CDBL(VAL(NETTWT))) - SUM(CDBL(VAL(JAMANETTWT))),3) AS FINEWT, LEDGERNAME AS WASTAGE FROM WASTAGEREPORT WHERE 1 = 1 " & WHERECLAUSE & " GROUP BY LEDGERNAME " & GROUPBYCLAUSE, tempconn)
            da = New OleDbDataAdapter(tempcmd)
            da.Fill(WASTAGEDT)
            GRIDWASTAGE.DataSource = WASTAGEDT
            da.Dispose()
            tempcmd.Dispose()
        End If


        Dim VACCUMDT As New DataTable
        Dim VACCUMWT As Double = 0.00
        If tempconn.State = ConnectionState.Open Then tempconn.Close()
        tempconn.Open()
        tempcmd = New OleDbCommand(" SELECT ROUND(SUM(CDBL(VAL(NETTWT))) - SUM(CDBL(VAL(JAMANETTWT))),3) AS VACCUMWT, 'VACCUM AC' AS NAME FROM VACCUMREPORT ", tempconn)
        'tempcmd = New OleDbCommand(" SELECT ROUND(SUM(ACCOUNTMASTER.ACCOUNT_NETTWT),3) AS VACCUMWT, 'VACCUM AC' AS NAME FROM (ACCOUNTMASTER INNER JOIN ledgermaster ON ACCOUNTMASTER.account_ledgercode = ledgermaster.ledger_code) INNER JOIN mfgWastage ON ledgermaster.ledger_name = mfgWastage.ledger_name WHERE (((mfgWastage.mfg_vaccum)=True) AND ((ACCOUNTMASTER.ACCOUNT_TYPE)='A') AND ((ACCOUNTMASTER.ACCOUNT_BALORJAMAORPAID)='Balance')) AND (LEDGERMASTER.LEDGER_CODE = 'VACCUM AC') UNION ALL SELECT ROUND(SUM(ACCOUNTMASTER.account_NETTWT)*(-1),3) AS VACCUMWT, 'VACCUM AC' AS NAME FROM ACCOUNTMASTER INNER JOIN ledgermaster ON ACCOUNTMASTER.account_ledgercode = ledgermaster.ledger_code WHERE (((ACCOUNTMASTER.ACCOUNT_TYPE)='A') AND ((ACCOUNTMASTER.ACCOUNT_BALORJAMAORPAID)='Jama') AND ((ACCOUNTMASTER.account_ledgercode) = 'VACCUM AC')) UNION ALL SELECT ROUND(SUM(ACCOUNTMASTER.ACCOUNT_NETTWT),3) AS VACCUMWT, 'VACCUM AC' AS NAME FROM (ACCOUNTMASTER INNER JOIN ledgermaster ON ACCOUNTMASTER.account_ledgercode = ledgermaster.ledger_code) WHERE (((ACCOUNTMASTER.ACCOUNT_TYPE)='A') AND ((ACCOUNTMASTER.ACCOUNT_BALORJAMAORPAID)='Balance')) AND (LEDGERMASTER.LEDGER_CODE = 'VACCUM AC') UNION ALL SELECT ROUND(SUM((mfg_vaccum * mfg_melting)/100),3), 'VACCUM AC' AS NAME FROM mfgWastage where mfg_vaccum = True ", tempconn)
        da = New OleDbDataAdapter(tempcmd)
        On Error Resume Next
        da.Fill(VACCUMDT)
        If VACCUMDT.Rows.Count > 0 Then
            For Each VACDR As DataRow In VACCUMDT.Rows
                If Not IsDBNull(VACDR("VACCUMWT")) Then VACCUMWT += Val(VACDR("VACCUMWT"))
            Next
            WASTAGEDT.Rows.Add(Val(VACCUMWT), "VACCUM AC")
            GRIDWASTAGE.DataSource = WASTAGEDT
        End If
        da.Dispose()
        tempcmd.Dispose()


        Dim SAMPLEDT As New DataTable
        Dim SAMPLEWT As Double = 0.00
        If tempconn.State = ConnectionState.Open Then tempconn.Close()
        tempconn.Open()
        'tempcmd = New OleDbCommand(" SELECT ROUND(SUM(CDBL(VAL(NETTWT))) - SUM(CDBL(VAL(JAMANETTWT))),3) AS SAMPLEWT, 'SAMPLE AC' AS NAME FROM SAMPLEREPORT ", tempconn)
        tempcmd = New OleDbCommand(" SELECT ROUND(SUM(ACCOUNTMASTER.ACCOUNT_NETTWT),3) AS SAMPLEWT, 'SAMPLE AC' AS NAME FROM ACCOUNTMASTER WHERE (((ACCOUNTMASTER.ACCOUNT_TYPE)='A') AND ((ACCOUNTMASTER.ACCOUNT_BALORJAMAORPAID)='Balance') AND ((ACCOUNTMASTER.ACCOUNT_LEDGERCODE)='SAMPLE AC')) UNION ALL SELECT ROUND(SUM(ACCOUNTMASTER.ACCOUNT_NETTWT)*(-1),3) AS LOSSWT, 'SAMPLE AC' AS NAME FROM ACCOUNTMASTER WHERE (((ACCOUNTMASTER.ACCOUNT_TYPE)='A') AND ((ACCOUNTMASTER.ACCOUNT_BALORJAMAORPAID)='Jama') AND ((ACCOUNTMASTER.ACCOUNT_LEDGERCODE)='SAMPLE AC')) UNION ALL SELECT ROUND(SUM((mfgWastage.SAMPLE * mfg_melting)/100),3) AS LOSS, 'SAMPLE AC' AS NAME FROM mfgWastage WHERE (((mfgWastage.SAMPLE)<>0))", tempconn)
        da = New OleDbDataAdapter(tempcmd)
        da.Fill(SAMPLEDT)
        If SAMPLEDT.Rows.Count > 0 Then
            For Each SMPDR As DataRow In SAMPLEDT.Rows
                If Not IsDBNull(SMPDR("SAMPLEWT")) Then SAMPLEWT += Val(SMPDR("SAMPLEWT"))
            Next
            WASTAGEDT.Rows.Add(Val(SAMPLEWT), "SAMPLE AC")
            GRIDWASTAGE.DataSource = WASTAGEDT
        End If
        da.Dispose()
        tempcmd.Dispose()




        Dim KARIGARDT As New DataTable
        If tempconn.State = ConnectionState.Open Then tempconn.Close()
        tempconn.Open()
        'OLD CODE
        'CHANGED BY GULKIT, DO NOT CHANGE
        'tempcmd = New OleDbCommand(" SELECT T.NAME, ROUND(SUM(CR) - SUM(DR),3) AS GROSSWT FROM (SELECT ACCOUNT_LEDGERCODE AS NAME, SUM(ACCOUNT_GROSSWT) AS DR, 0 AS CR FROM ACCOUNTMAST INNER JOIN LEDGERMASTER ON ACCOUNTMAST.ACCOUNT_LEDGERCODE = LEDGERMASTER.LEDGER_CODE WHERE LEDGERMASTER.LEDGER_KARIGAR = TRUE AND ACCOUNT_BALORJAMAORPAID= 'Jama' GROUP BY ACCOUNT_LEDGERCODE UNION ALL SELECT ACCOUNT_LEDGERCODE AS NAME, 0 AS DR, SUM(ACCOUNT_GROSSWT) AS CR FROM ACCOUNTMAST INNER JOIN LEDGERMASTER ON ACCOUNTMAST.ACCOUNT_LEDGERCODE = LEDGERMASTER.LEDGER_CODE WHERE LEDGERMASTER.LEDGER_KARIGAR = TRUE AND ACCOUNT_BALORJAMAORPAID = 'Balance' GROUP BY ACCOUNT_LEDGERCODE) AS T  WHERE NAME <> '' GROUP BY T.NAME", tempconn)
        tempcmd = New OleDbCommand(" SELECT T.NAME, ROUND(SUM(CR) - SUM(DR),3) AS FINEWT FROM (SELECT ACCOUNT_LEDGERCODE AS NAME, SUM(ACCOUNT_NETTWT) AS DR, 0 AS CR FROM ACCOUNTMAST INNER JOIN LEDGERMASTER ON ACCOUNTMAST.ACCOUNT_LEDGERCODE = LEDGERMASTER.LEDGER_CODE WHERE LEDGERMASTER.LEDGER_KARIGAR = TRUE AND ACCOUNT_BALORJAMAORPAID= 'Jama' AND ACCOUNT_DATE <= #" & Format(TILLDATE.Value.Date, "MM/dd/yyyy") & "# GROUP BY ACCOUNT_LEDGERCODE UNION ALL SELECT LEDGER_CODE AS NAME, ROUND(LEDGER_OPBALWT,3) AS DR, 0 AS CR FROM LEDGERMASTER WHERE LEDGER_DRCRWT= 'Cr.' AND LEDGERMASTER.LEDGER_KARIGAR = TRUE UNION ALL SELECT LEDGER_CODE AS NAME, 0 AS DR, ROUND(LEDGER_OPBALWT,3) AS CR FROM LEDGERMASTER WHERE LEDGER_DRCRWT= 'Dr.' AND LEDGERMASTER.LEDGER_KARIGAR = TRUE UNION ALL SELECT ACCOUNT_LEDGERCODE AS NAME, 0 AS DR, SUM(ACCOUNT_NETTWT) AS CR FROM ACCOUNTMAST INNER JOIN LEDGERMASTER ON ACCOUNTMAST.ACCOUNT_LEDGERCODE = LEDGERMASTER.LEDGER_CODE WHERE LEDGERMASTER.LEDGER_KARIGAR = TRUE AND ACCOUNT_BALORJAMAORPAID = 'Balance'  AND ACCOUNT_DATE <= #" & Format(TILLDATE.Value.Date, "MM/dd/yyyy") & "# GROUP BY ACCOUNT_LEDGERCODE) AS T  WHERE NAME <> '' GROUP BY T.NAME", tempconn)
        'tempcmd = New OleDbCommand("SELECT CODE AS NAME, ROUND(SUM(GROSSWT),3)*-1 AS GROSSWT FROM TRIALBALANCE INNER JOIN LEDGERMASTER ON TRIALBALANCE.CODE = LEDGERMASTER.LEDGER_CODE WHERE LEDGERMASTER.LEDGER_KARIGAR = TRUE GROUP BY CODE", tempconn)
        da = New OleDbDataAdapter(tempcmd)
        da.Fill(KARIGARDT)
        GRIDKARIGAR.DataSource = KARIGARDT
        da.Dispose()
        tempcmd.Dispose()

        If ClientName = "SHASHAWAT" Or ClientName = "SANGAM" Then
            TXTTOTALGROSS.Text = Format(Val(GNETTWT.SummaryText) + Val(GWASTAGEFINE.SummaryText) + Val(GKARIGARFINE.SummaryText), "0.000")
        Else
            TXTTOTALGROSS.Text = Format(Val(GNETTWT.SummaryText) + Val(GWASTAGEFINE.SummaryText) + Val(GKARIGARFINE.SummaryText) + Val(TXTLOSS.Text.Trim), "0.000")
        End If


    End Sub

    Private Sub CMDOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDOK.Click
        Try
            SHOWFORM()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub SHOWFORM()
        Try
            Dim OBJSTSUMM As New StockSummary
            OBJSTSUMM.MdiParent = MDIMain
            OBJSTSUMM.TITEM = GRIDDETAILS.GetFocusedRowCellValue("ITEMCODE")
            OBJSTSUMM.TPURITY = GRIDDETAILS.GetFocusedRowCellValue("PURITY")
            OBJSTSUMM.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDDETAILS_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GRIDDETAILS.DoubleClick
        Try
            SHOWFORM()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TOOLREFRESH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLREFRESH.Click
        Try
            FILLGRID()
            FILLLOSS()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TOOLPRINT_Click(sender As Object, e As EventArgs) Handles TOOLPRINT.Click
        Try
            If GRIDDETAILS.RowCount = 0 Then GoTo LINE1
            For i = 0 To 100
                tempcol(i) = ""
                tempval(i) = ""
            Next


            Dim NEWDT As New DataTable
            tempcmd = New OleDbCommand("DELETE FROM TEMPSTOCK", tempconn)
            da = New OleDbDataAdapter(tempcmd)
            da.Fill(NEWDT)

            tempcol(0) = "ITEMNAME"
            tempcol(1) = "NARRATION"
            tempcol(2) = "PURITY"
            tempcol(3) = "GROSSWT"
            tempcol(4) = "FINEWT"
            tempcol(5) = "TYPE"

            If MsgBox("Wish to Print?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub


            For I As Integer = 0 To GRIDDETAILS.RowCount - 1
                Dim ROW As DataRow = GRIDDETAILS.GetDataRow(I)

                tempval(0) = "'" & ROW("ITEMCODE") & "'"
                tempval(1) = "'" & ROW("NARRATION") & "'"
                tempval(2) = Val(ROW("PURITY"))
                tempval(3) = Val(ROW("GROSSWT"))
                tempval(4) = Val(ROW("NETTWT"))
                tempval(5) = "'STOCK'"

                insert("TEMPSTOCK", tempcol, tempval)
            Next
LINE1:


            If GRIDWASTAGEDETAILS.RowCount = 0 Then GoTo LINE2
            For I As Integer = 0 To GRIDWASTAGEDETAILS.RowCount - 1
                Dim ROW As DataRow = GRIDWASTAGEDETAILS.GetDataRow(I)

                tempval(0) = "'" & ROW("WASTAGE") & "'"
                tempval(1) = "''"
                tempval(2) = "0"
                tempval(3) = Val(ROW("FINEWT"))
                tempval(4) = "0"
                tempval(5) = "'STOCK-WASTAGE'"

                insert("TEMPSTOCK", tempcol, tempval)
            Next

LINE2:

            For I As Integer = 0 To GRIDKARIGARDETAILS.RowCount - 1
                Dim ROW As DataRow = GRIDKARIGARDETAILS.GetDataRow(I)

                tempval(0) = "'" & ROW("NAME") & "'"
                tempval(1) = "''"
                tempval(2) = "0"
                tempval(3) = Val(ROW("FINEWT"))
                tempval(4) = "0"
                tempval(5) = "'STOCK-KARIGAR'"

                insert("TEMPSTOCK", tempcol, tempval)
            Next

            Dim OBJSTOCK As New StocksDesign
            OBJSTOCK.MdiParent = MDIMain
            OBJSTOCK.FRMSTRING = "STOCK"
            OBJSTOCK.PERIOD = "Till Date - " & Format(Now.Date, "dd/MM/yyyy")
            OBJSTOCK.Show()


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class