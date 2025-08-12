
Imports System.Data.OleDb

Public Class ProcessGridReport

    Sub FILLGRID()
        Try
            Dim DT As New DataTable
            Dim CONDITION As String = ""
            If chkdate.CheckState = CheckState.Checked Then CONDITION = " WHERE mfgdescription.mfg_processdate >= #" & Format(dtfrom.Value.Date, "MM/dd/yyyy") & "# AND mfgdescription.mfg_processdate <=# " & Format(dtto.Value.Date, "MM/dd/yyyy") & "#"
            If ClientName = "CNJ" Then
                cmd = New OleDbCommand("SELECT mfgmaster.mfg_lotno AS LOTNO, mfgdescription.mfg_part AS PART, mfgdescription.mfg_processname AS PROCESS, mfgdescription.mfg_name AS NAME, mfgdescription.mfg_processdate AS PDATE, mfgdescription.mfg_inputwt AS INWT,  mfgdescription.mfg_outputwt AS OUTWT, mfgdescription.mfg_wastage AS WASTAGE, ((mfgdescription.mfg_wastage*mfgmaster.mfg_percentfinal)/100) AS WASTAGEFINE, mfgdescription.mfg_sample AS SAMPLE, ((mfgdescription.mfg_SAMPLE*mfgmaster.mfg_percentfinal)/100) AS SAMPLEFINE, mfgdescription.mfg_loss AS LOSS, ((mfgdescription.mfg_LOSS*mfgmaster.mfg_percentfinal)/100) AS LOSSFINE, mfgdescription.mfg_vaccum AS VACCUM, ((mfgdescription.mfg_VACCUM*mfgmaster.mfg_percentfinal)/100) AS VACCUMFINE, mfgdescription.mfg_excess AS EXCESS, ((mfgdescription.mfg_EXCESS*mfgmaster.mfg_percentfinal)/100) AS EXCESSFINE, mfgdescription.mfg_percentinput AS PERCENTIN, mfgdescription.mfg_percentoutput AS PERCENTOUT, mfgdescription.mfg_percentfinal AS PERCENTFINAL, mfgdescription.mfg_lab AS LAB FROM mfgmaster INNER JOIN mfgdescription ON mfgmaster.mfg_no = mfgdescription.mfg_no " & CONDITION, conn)
            Else
                cmd = New OleDbCommand("SELECT mfgmaster.mfg_lotno AS LOTNO, mfgdescription.mfg_part AS PART, mfgdescription.mfg_processname AS PROCESS, mfgdescription.mfg_name AS NAME, mfgdescription.mfg_processdate AS PDATE, mfgdescription.mfg_inputwt AS INWT,  mfgdescription.mfg_outputwt AS OUTWT, mfgdescription.mfg_wastage AS WASTAGE, ((mfgdescription.mfg_wastage*mfgmaster.mfg_melting)/100) AS WASTAGEFINE, mfgdescription.mfg_sample AS SAMPLE, ((mfgdescription.mfg_SAMPLE*mfgmaster.mfg_melting)/100) AS SAMPLEFINE, mfgdescription.mfg_loss AS LOSS, ((mfgdescription.mfg_LOSS*mfgmaster.mfg_melting)/100) AS LOSSFINE, mfgdescription.mfg_vaccum AS VACCUM, ((mfgdescription.mfg_VACCUM*mfgmaster.mfg_melting)/100) AS VACCUMFINE, mfgdescription.mfg_excess AS EXCESS, ((mfgdescription.mfg_EXCESS*mfgmaster.mfg_melting)/100) AS EXCESSFINE, mfgdescription.mfg_percentinput AS PERCENTIN, mfgdescription.mfg_percentoutput AS PERCENTOUT, mfgdescription.mfg_percentfinal AS PERCENTFINAL, mfgdescription.mfg_lab AS LAB FROM mfgmaster INNER JOIN mfgdescription ON mfgmaster.mfg_no = mfgdescription.mfg_no " & CONDITION, conn)
            End If
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