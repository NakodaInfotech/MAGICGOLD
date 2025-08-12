
Imports System.Data.OleDb

Public Class ProcessSummGridReport

    Sub FILLGRID()
        Try
            Dim DT As New DataTable
            Dim CONDITION As String = ""
            If chkdate.CheckState = CheckState.Checked Then CONDITION = " WHERE mfgdescription.mfg_processdate >= #" & Format(dtfrom.Value.Date, "MM/dd/yyyy") & "# AND mfgdescription.mfg_processdate <=# " & Format(dtto.Value.Date, "MM/dd/yyyy") & "#"
            cmd = New OleDbCommand("SELECT mfgdescription.mfg_processname AS PROCESS, sum(mfgdescription.mfg_inputwt) AS INWT, sum(mfgdescription.mfg_outputwt) AS OUTWT, sum(mfgdescription.mfg_wastage) AS WASTAGE, sum(((mfgdescription.mfg_wastage*mfgmaster.mfg_melting)/100)) AS WASTAGEFINE, sum(mfgdescription.mfg_sample) AS SAMPLE, sum(((mfgdescription.mfg_SAMPLE*mfgmaster.mfg_melting)/100)) AS SAMPLEFINE, sum(mfgdescription.mfg_loss) AS LOSS, sum(((mfgdescription.mfg_LOSS*mfgmaster.mfg_melting)/100)) AS LOSSFINE, sum(mfgdescription.mfg_vaccum) AS VACCUM, sum(((mfgdescription.mfg_VACCUM*mfgmaster.mfg_melting)/100)) AS VACCUMFINE, sum(mfgdescription.mfg_excess) AS EXCESS, sum(((mfgdescription.mfg_EXCESS*mfgmaster.mfg_melting)/100)) AS EXCESSFINE FROM mfgmaster INNER JOIN mfgdescription ON mfgmaster.mfg_no = mfgdescription.mfg_no " & CONDITION & " group by mfgdescription.mfg_processname ", conn)
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Open()
            da = New OleDbDataAdapter(cmd)
            da.Fill(DT)
            gridStock.DataSource = DT
            da.Dispose()
            DT.Dispose()
            tempconn.Close()
            tempcmd.Dispose()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub CMDSHOW_Click(sender As Object, e As EventArgs) Handles CMDSHOW.Click
        Try
            FILLGRID()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDEXPORT_Click(sender As Object, e As EventArgs) Handles CMDEXPORT.Click
        Try
            Dim PATH As String = Application.StartupPath & "\Process Report.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True

            Dim proc As New System.Diagnostics.Process
            For Each proc In System.Diagnostics.Process.GetProcessesByName("Excel")
                proc.Kill()
            Next
            opti.SheetName = "Process Report"
            GRIDDETAILS.ExportToXls(PATH, opti)

            EXCELCMPHEADER(PATH, "Process Report", GRIDDETAILS.VisibleColumns.Count + GRIDDETAILS.GroupCount, "", "REPORT AS ON " & Now)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class