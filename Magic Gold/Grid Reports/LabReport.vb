
Imports System.Data.OleDb
Imports DevExpress.XtraGrid.Views.Grid

Public Class LabReport

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub LabReport_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Alt = True And e.KeyCode = Windows.Forms.Keys.O Then       'for oPEN
            Call CMDOK_Click(sender, e)
        ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            Me.Close()
        End If
    End Sub

    Private Sub LabReport_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        FILLPARTYNAME()
        fillgrid()
    End Sub

    Sub FILLPARTYNAME()
        Try
            cmd = New OleDbCommand("select LEDGER_CODE AS NAME from LEDGERMASTER INNER JOIN GROUPMASTER ON LEDGERMASTER.LEDGER_GROUPID = GROUPMASTER.GROUP_ID WHERE GROUPMASTER.GROUP_NAME = 'Sundry Creditors'", conn)
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Open()
            dr = cmd.ExecuteReader
            While dr.Read()
                CMBTOUCHNAME.Items.Add(uppercase(dr("NAME")))
            End While
            conn.Close()
            dr.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub LabReport_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If ClientName = "MIMARAGEMS" Then Me.Close()
    End Sub

    Sub fillgrid()
        Try
            'getting data from LABREPORT

            dt = New DataTable()
            If tempconn.State = ConnectionState.Open Then
                tempconn.Close()
            End If
            tempconn.Open()

            Dim CONDITION As String = ""
            Dim MFGCONDITION As String = ""
            'tempcmd = New OleDbCommand("SELECT A.ACCNO AS LOTNO,  A.NARRATION AS REFNO, A.SAMPLE AS WT, A.NETTWT, VAL(A.OUTWT) AS PARTYWT, A.LEDGERNAME, A.DATE AS ISSDATE, A.DATE AS RECDATE, A.SAMPLEPURITY AS MELTING, VAL(0.00) AS LABREP, VAL(0.00) AS PARTYREP, VAL(0.00) AS FACLAB, VAL(0.00) AS FACPARTY, VAL(0.00) AS LABPARTY, VAL(0.00) AS FACLABWTDIFF,VAL(0.00) AS FACPARTYWTDIFF,VAL(0.00) AS LABPARTYWTDIFF, A.TYPE  FROM LABSMPREPORT A WHERE NOT EXISTS (SELECT B.LAB_LOTNO FROM LABREPORT B WHERE A.ACCNO = B.LAB_LOTNO AND A.TYPE = B.LAB_TYPE ) order by A.ACCNO", tempconn)
            'da = New OleDbDataAdapter(tempcmd)
            'da.Fill(dt)

            tempcmd = New OleDbCommand("SELECT A.ACCNO AS LOTNO, A.PARTNO, A.NARRATION AS REFNO, '' AS NARRATION, A.SAMPLE AS WT, A.NETTWT, VAL(A.OUTWT) AS PARTYWT, A.LEDGERNAME, A.DATE AS ISSDATE, A.DATE AS RECDATE, A.SAMPLEPURITY AS MELTING, VAL(0.00) AS LABREP, VAL(0.00) AS PARTYREP, VAL(0.00) AS FACLAB, VAL(0.00) AS FACPARTY, VAL(0.00) AS LABPARTY, VAL(0.00) AS FACLABWTDIFF,VAL(0.00) AS FACPARTYWTDIFF,VAL(0.00) AS LABPARTYWTDIFF, A.TYPE  FROM LABSMPREPORT A order by A.ACCNO, A.PROCESSNO", tempconn)
            da = New OleDbDataAdapter(tempcmd)
            da.Fill(dt)

            tempcmd = New OleDbCommand("SELECT B.LAB_LOTNO AS LOTNO, B.LAB_PARTNO AS PARTNO, B.LAB_TYPE AS TYPE, B.LAB_REFNO AS REFNO FROM LABREPORT B order by B.LAB_LOTNO", tempconn)
            Dim DA1 As New OleDbDataAdapter(tempcmd)
            Dim DT1 As New DataTable
            DA1.Fill(DT1)


            Dim rows_to_remove As New List(Of DataRow)()
            For Each row1 As DataRow In dt.Rows
                For Each row2 As DataRow In DT1.Rows
                    If IsDBNull(row2("PARTNO")) = True Then row2("PARTNO") = ""
                    If row1("LOTNO") = row2("LOTNO") And row1("TYPE").ToString = row2("TYPE").ToString And row1("REFNO") = row2("REFNO") And row1("PARTNO") = row2("PARTNO") Then
                        rows_to_remove.Add(row1)
                    End If
                Next
            Next

            For Each row As DataRow In rows_to_remove
                dt.Rows.Remove(row)
                dt.AcceptChanges()
            Next



            For Each DTROW As DataRow In dt.Rows
                'DTROW("ISSDATE") = DBNull.Value
                DTROW("RECDATE") = DBNull.Value
                If ClientName = "JAINAM" Then DTROW("LEDGERNAME") = "OUR TUNCH" Else DTROW("LEDGERNAME") = DBNull.Value
            Next
            If RBALL.Checked = True Then
                'OLD CODE
                'tempcmd = New OleDbCommand("SELECT mfgmaster.mfg_lotno AS LOTNO, mfgmaster.MFG_REFNO AS REFNO,itemstock.item_grosswt AS WT, itemstock.item_NETTWT AS NETTWT, VAL(0.00) AS PARTYWT, itemstock.item_purity AS MELTING, VAL(0.00) AS LABREP, VAL(0.00) AS PARTYREP, VAL(0.00) AS FACLAB, VAL(0.00) AS FACPARTY, VAL(0.00) AS LABPARTY, VAL(0.00) AS WTDIFF FROM itemstock INNER JOIN mfgmaster ON itemstock.item_no = mfgmaster.mfg_no where MFG_LOTNO NOT IN (SELECT LAB_LOTNO FROM LABREPORT ) order by MFG_LOTNO UNION ALL SELECT LAB_LOTNO AS LOTNO, LAB_REFNO AS REFNO, LAB_WT AS WT, LAB_NETTWT AS NETTWT, LAB_PARTYWT AS PARTYWT, LAB_MELTING AS MELTING, LAB_LABREP AS LABREP, LAB_PARTYREP AS PARTYREP, LAB_FACLAB AS FACLAB, LAB_FACPARTY AS FACPARTY, LAB_LABPARTY AS LABPARTY, LAB_WTDIFF AS WTDIFF  FROM LABREPORT ORDER BY LOTNO", tempconn)
                Dim NEWTEMPCMD = New OleDbCommand("SELECT LABREPORT.LAB_LOTNO AS LOTNO, LABREPORT.LAB_PARTNO AS PARTNO, LABREPORT.LAB_REFNO AS REFNO, LABREPORT.LAB_NARRATION AS NARRATION, LABREPORT.LAB_WT AS WT, LABREPORT.LAB_NETTWT AS NETTWT, LABREPORT.LAB_PARTYWT AS PARTYWT, ledgermaster.ledger_code AS LEDGERNAME, LABREPORT.LAB_ISSDATE AS ISSDATE, LABREPORT.LAB_RECDATE AS RECDATE, LABREPORT.LAB_MELTING AS MELTING, LABREPORT.LAB_LABREP AS LABREP, LABREPORT.LAB_PARTYREP AS PARTYREP, LABREPORT.LAB_FACLAB AS FACLAB, LABREPORT.LAB_FACPARTY AS FACPARTY, LABREPORT.LAB_LABPARTY AS LABPARTY, LABREPORT.LAB_FACLABWTDIFF AS FACLABWTDIFF, LABREPORT.LAB_FACPARTYWTDIFF AS FACPARTYWTDIFF, LABREPORT.LAB_LABPARTYWTDIFF AS LABPARTYWTDIFF, LABREPORT.LAB_TYPE AS TYPE FROM LABREPORT INNER JOIN ledgermaster ON LABREPORT.LAB_LEDGERID = ledgermaster.ledger_id ", tempconn)
                If tempconn.State = ConnectionState.Open Then tempconn.Close()
                tempconn.Open()
                Dim DANEW As OleDbDataAdapter = New OleDbDataAdapter(NEWTEMPCMD)
                Dim NEWDT As New DataTable
                DANEW.Fill(NEWDT)
                For Each NEWDTROW As DataRow In NEWDT.Rows
                    dt.ImportRow(NEWDTROW)
                Next
            End If



            Dim DV As New DataView(dt)
            DV.Sort = "LOTNO ASC, TYPE ASC"

            gridStock.DataSource = dt

            da.Dispose()
            dt.Dispose()
            tempconn.Close()
            tempcmd.Dispose()

            TXTPURITY.Text = Format(Val((Val(GNETTWT.SummaryText) / Val(GWT.SummaryText)) * 100), "0.00")

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub RBALL_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBALL.CheckedChanged
        fillgrid()
    End Sub

    Private Sub RBPENDING_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBPENDING.CheckedChanged
        fillgrid()
    End Sub

    Private Sub CMDOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDOK.Click
        Try

            For i = 1 To 50
                tempcol(i) = ""
                tempval(i) = ""
            Next

            For i = 0 To GRIDDETAILS.RowCount - 1

                Dim DTROW As DataRow = GRIDDETAILS.GetDataRow(i)

                If RBALL.Checked = True Then
                    tempcmd = New OleDbCommand("delete from LABREPORT where LAB_LOTNO = " & DTROW("LOTNO") & " AND LAB_REFNO = '" & DTROW("REFNO") & "' AND LAB_TYPE = '" & DTROW("TYPE") & "' and LAB_PARTNO = '" & DTROW("PARTNO") & "'", tempconn)
                    If tempconn.State = ConnectionState.Open Then tempconn.Close()
                    tempconn.Open()
                    tempcmd.ExecuteNonQuery()
                    tempconn.Close()
                End If

                If Val(DTROW("LABREP")) > 0 And IsDBNull(DTROW("LEDGERNAME")) = False And IsDBNull(DTROW("ISSDATE")) = False Then
                    cmd = New OleDbCommand("select * from labreport where LAB_LOTNO = " & DTROW("LOTNO") & " AND LAB_REFNO = '" & DTROW("REFNO") & "' AND LAB_TYPE = '" & DTROW("TYPE") & "' and LAB_PARTNO = '" & DTROW("PARTNO") & "'", conn)
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Open()
                    dr = cmd.ExecuteReader
                    If dr.HasRows = True Then
                        tempcmd = New OleDbCommand("delete from LABREPORT where LAB_LOTNO = " & DTROW("LOTNO") & " AND LAB_REFNO = '" & DTROW("REFNO") & "' AND LAB_TYPE = '" & DTROW("TYPE") & "' and LAB_PARTNO = '" & DTROW("PARTNO") & "'", tempconn)
                        If tempconn.State = ConnectionState.Open Then tempconn.Close()
                        tempconn.Open()
                        tempcmd.ExecuteNonQuery()
                        tempconn.Close()
                    End If
                    dr.Close()
                    conn.Close()

                    tempcol(0) = "LAB_LOTNO"
                    tempcol(1) = "LAB_REFNO"
                    tempcol(2) = "LAB_WT"
                    tempcol(3) = "LAB_NETTWT"
                    tempcol(4) = "LAB_PARTYWT"
                    tempcol(5) = "LAB_LEDGERID"
                    tempcol(6) = "LAB_ISSDATE"
                    tempcol(7) = "LAB_RECDATE"
                    tempcol(8) = "LAB_MELTING"
                    tempcol(9) = "LAB_LABREP"
                    tempcol(10) = "LAB_PARTYREP"
                    tempcol(11) = "LAB_FACLAB"
                    tempcol(12) = "LAB_FACPARTY"
                    tempcol(13) = "LAB_LABPARTY"
                    tempcol(14) = "LAB_FACLABWTDIFF"
                    tempcol(15) = "LAB_FACPARTYWTDIFF"
                    tempcol(16) = "LAB_LABPARTYWTDIFF"
                    tempcol(17) = "LAB_TYPE"
                    tempcol(18) = "LAB_DATE"
                    tempcol(19) = "LAB_PARTNO"
                    tempcol(20) = "LAB_NARRATION"

                    tempval(0) = DTROW("LOTNO")
                    tempval(1) = "'" & DTROW("REFNO") & "'"
                    tempval(2) = Format(Val(DTROW("WT")), "0.000")
                    tempval(3) = Format(Val(DTROW("NETTWT")), "0.000")
                    tempval(4) = Format(Val(DTROW("PARTYWT")), "0.000")

                    tempcmd = New OleDbCommand("select LEDGER_id from LEDGERmaster where LEDGER_code = '" & DTROW("LEDGERNAME") & "'", tempconn)
                    If tempconn.State = ConnectionState.Open Then
                        tempconn.Close()
                    End If
                    tempconn.Open()
                    tempdr = tempcmd.ExecuteReader
                    If tempdr.HasRows Then
                        tempdr.Read()
                        tempval(5) = Val(tempdr(0))
                    End If
                    tempconn.Close()
                    tempdr.Close()


                    tempval(6) = "'" & Format(DTROW("ISSDATE"), "dd/MM/yyyy") & "'"
                    If IsDBNull(DTROW("RECDATE")) = True Then
                        tempval(7) = "NULL"
                    Else
                        tempval(7) = "'" & Format(DTROW("RECDATE"), "dd/MM/yyyy") & "'"
                    End If

                    tempval(8) = Format(Val(DTROW("MELTING")), "0.00")
                    tempval(9) = Format(Val(DTROW("LABREP")), "0.00")
                    tempval(10) = Format(Val(DTROW("PARTYREP")), "0.00")
                    tempval(11) = Format(Val(DTROW("FACLAB")), "0.00")
                    tempval(12) = Format(Val(DTROW("FACPARTY")), "0.00")
                    tempval(13) = Format(Val(DTROW("LABPARTY")), "0.00")
                    tempval(14) = Format(Val(DTROW("FACLABWTDIFF")), "0.000")
                    tempval(15) = Format(Val(DTROW("FACPARTYWTDIFF")), "0.000")
                    tempval(16) = Format(Val(DTROW("LABPARTYWTDIFF")), "0.000")
                    tempval(17) = "'" & DTROW("TYPE") & "'"
                    tempval(18) = "'" & Format(DTROW("ISSDATE"), "dd/MM/yyyy") & "'"
                    tempval(19) = "'" & DTROW("PARTNO") & "'"
                    tempval(20) = "'" & DTROW("NARRATION") & "'"
                    insert("LABREPORT", tempcol, tempval)
                End If
            Next
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDDETAILS_ColumnFilterChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GRIDDETAILS.ColumnFilterChanged
        TXTPURITY.Text = Format(Val((Val(GNETTWT.SummaryText) / Val(GWT.SummaryText)) * 100), "0.00")
    End Sub

    Private Sub GRIDDETAILS_InvalidRowException(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) Handles GRIDDETAILS.InvalidRowException
        Try
            e.ErrorText = "Rec Date should be after Issue Date"
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub griddetails_ValidateRow(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles GRIDDETAILS.ValidateRow
        Try

            Dim ISSDATE, RECDATE As Date
            If IsDBNull(GRIDDETAILS.GetFocusedRowCellValue("ISSDATE")) = False Then ISSDATE = GRIDDETAILS.GetFocusedRowCellValue("ISSDATE")
            If IsDBNull(GRIDDETAILS.GetFocusedRowCellValue("RECDATE")) = True Then RECDATE = ISSDATE Else RECDATE = GRIDDETAILS.GetFocusedRowCellValue("RECDATE")

            If RECDATE < ISSDATE Then e.Valid = False
            GRIDDETAILS.SetColumnError(GRIDDETAILS.Columns("GRECDATE"), "Rec Date should be after Issue Date", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDDETAILS_CellValueChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GRIDDETAILS.CellValueChanged
        Try
            If IsDBNull(e.Value) = True Then Exit Sub
            If Val(e.Value) > 0 Then
                Dim ROW As DataRow = GRIDDETAILS.GetFocusedDataRow
                ROW("FACLAB") = Format(Val(ROW("MELTING")) - Val(ROW("LABREP")), "0.00")
                ROW("FACPARTY") = Format(Val(ROW("MELTING")) - Val(ROW("PARTYREP")), "0.00")
                ROW("LABPARTY") = Format(Val(ROW("LABREP")) - Val(ROW("PARTYREP")), "0.00")
                ROW("FACLABWTDIFF") = Format(((Val(ROW("PARTYWT")) * Val(ROW("MELTING"))) - (Val(ROW("PARTYWT")) * Val(ROW("LABREP")))) / 100, "0.000")
                ROW("FACPARTYWTDIFF") = Format(((Val(ROW("PARTYWT")) * Val(ROW("MELTING"))) - (Val(ROW("PARTYWT")) * Val(ROW("PARTYREP")))) / 100, "0.000")
                ROW("LABPARTYWTDIFF") = Format(((Val(ROW("PARTYWT")) * Val(ROW("LABREP"))) - (Val(ROW("PARTYWT")) * Val(ROW("PARTYREP")))) / 100, "0.000")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PBEXCEL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PBEXCEL.Click
        Try
            Dim PATH As String = Application.StartupPath & "\Lab Report.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True

            Dim proc As New System.Diagnostics.Process
            For Each proc In System.Diagnostics.Process.GetProcessesByName("Excel")
                proc.Kill()
            Next
            opti.SheetName = "Lab Report"
            GRIDDETAILS.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Lab Report", GRIDDETAILS.VisibleColumns.Count + GRIDDETAILS.GroupCount)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDDETAILS_RowCellStyle(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GRIDDETAILS.RowCellStyle
        Try
            If e.RowHandle >= 0 Then
                Dim View As GridView = sender
                If View.GetRowCellDisplayText(e.RowHandle, View.Columns("FACLAB")) > 0 Then
                    If e.Column.FieldName = "FACLAB" Then
                        e.Appearance.Font = New System.Drawing.Font("CALIBRI", 9.0F, System.Drawing.FontStyle.Bold)
                        e.Appearance.ForeColor = Color.Red
                    End If
                ElseIf View.GetRowCellDisplayText(e.RowHandle, View.Columns("FACLAB")) < 0 Then
                    If e.Column.FieldName = "FACLAB" Then
                        e.Appearance.Font = New System.Drawing.Font("CALIBRI", 9.0F, System.Drawing.FontStyle.Bold)
                        e.Appearance.ForeColor = Color.Green
                    End If
                End If
                If View.GetRowCellDisplayText(e.RowHandle, View.Columns("FACLABWTDIFF")) > 0 Then
                    If e.Column.FieldName = "FACLABWTDIFF" Then
                        e.Appearance.Font = New System.Drawing.Font("CALIBRI", 9.0F, System.Drawing.FontStyle.Bold)
                        e.Appearance.ForeColor = Color.Red
                    End If
                ElseIf View.GetRowCellDisplayText(e.RowHandle, View.Columns("FACLABWTDIFF")) < 0 Then
                    If e.Column.FieldName = "FACLABWTDIFF" Then
                        e.Appearance.Font = New System.Drawing.Font("CALIBRI", 9.0F, System.Drawing.FontStyle.Bold)
                        e.Appearance.ForeColor = Color.Green
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class