
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlClient
Imports CrystalDecisions.Shared

Public Class ProcessReportDesign

    Private Sub ProcessReportDesign_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Keys.Delete Then
                Me.Close()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ProcessReportDesign_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim rptpo As New Processreport
        Try

            '**************** SET SERVER ************************
            Dim crConnecttionInfo As New ConnectionInfo
            Dim crtableLogonInfo As New TableLogOnInfo
            Dim crTables As Tables
            Dim crTable As Table

            Main()
            With crConnecttionInfo
                .ServerName = "MagicGold"
                .DatabaseName = tempcmpname & ".mdb"
                .UserID = "Admin"
                .Password = "1902"
                .IntegratedSecurity = "True"
            End With

            crTables = rptpo.Database.Tables
            For Each crTable In crTables
                crtableLogonInfo = crTable.LogOnInfo
                crtableLogonInfo.ConnectionInfo = crConnecttionInfo
                crTable.ApplyLogOnInfo(crtableLogonInfo)
            Next

            CRPO.ReportSource = rptpo
            CRPO.SelectionFormula = strsearch
            CRPO.Zoom(100)
        Catch Exp As LoadSaveReportException
            MsgBox("Incorrect path for loading report.", _
                    MsgBoxStyle.Critical, "Load Report Error")
        Catch Exp As Exception
            MsgBox(Exp.Message, MsgBoxStyle.Critical, "General Error")
        End Try
    End Sub
End Class