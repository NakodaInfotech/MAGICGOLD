
Imports System.Data.OleDb

Public Class LedgerDetailsReport

    Private Sub LedgerDetailsReport_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Or (e.KeyCode = Keys.X And e.Alt = True) Then
                Me.Close()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid(ByVal WHERECLAUSE As String)
        Try
            dt = New DataTable()
            If tempconn.State = ConnectionState.Open Then tempconn.Close()
            tempconn.Open()
            tempcmd = New OleDbCommand("SELECT ledgermaster.ledger_name AS LEDGERNAME, ledgermaster.ledger_code AS CODE, groupmaster.group_name AS GROUPNAME, areamaster.area_name AS AREA, citymaster.city_name AS CITY, statemaster.state_name AS STATE, countrymaster.country_name AS COUNTRY, ledgermaster.ledger_resi AS RESINO, ledgermaster.ledger_altno AS ALTNO, ledgermaster.ledger_tel1 AS PHONENO, ledgermaster.ledger_mobile AS MOBILE, ledgermaster.ledger_panno AS PANNO, ledgermaster.LEDGER_SALARY AS SALARY, ledgermaster.ledger_opbalrs AS OPBAL, ledgermaster.ledger_drcrrs AS DRCR, ledgermaster.ledger_add AS LEDGERADD FROM ((((ledgermaster INNER JOIN groupmaster ON ledgermaster.ledger_groupid = groupmaster.group_id) LEFT JOIN areamaster ON ledgermaster.ledger_areaid = areamaster.area_id) LEFT JOIN citymaster ON ledgermaster.ledger_cityid = citymaster.city_id) LEFT JOIN statemaster ON ledgermaster.ledger_stateid = statemaster.state_id) LEFT JOIN countrymaster ON ledgermaster.ledger_countryid = countrymaster.country_id ORDER BY LEDGERMASTER.LEDGER_CODE ", tempconn)
            da = New OleDbDataAdapter(tempcmd)
            da.Fill(dt)
            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then gridbill.FocusedRowHandle = gridbill.RowCount - 1
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancel.Click
        Me.Close()
    End Sub

    Private Sub CMDPRINT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDPRINT.Click
        Try
            Dim PATH As String = "" = ""
            If FileIO.FileSystem.FileExists(PATH) = True Then FileIO.FileSystem.DeleteFile(PATH)
            PATH = Application.StartupPath & "\Ledger Details.XLS"

            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True

            Dim workbook As String = PATH
            If FileIO.FileSystem.FileExists(PATH) = True Then Interaction.GetObject(workbook).close(False)
            GC.Collect()
            'For Each proc In System.Diagnostics.Process.GetProcessesByName("Excel")
            '    proc.Kill()
            'Next

            opti.SheetName = "Ledger Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Ledger Details", gridbill.VisibleColumns.Count + gridbill.GroupCount, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub LedgerDetailsReport_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            fillgrid("")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDSAVE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDSAVE.Click
        Try
            fillgrid("")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class