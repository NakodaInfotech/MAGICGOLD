Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlClient
Imports CrystalDecisions.Shared

Public Class wastagedesign

    Private Sub wastagedesign_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Keys.Delete Then
                Me.Close()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AvgSalePurDesign_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim rptmw As New mfgwastage
        Dim rptml As New mfgloss
        Try
            'rptmw.Section1.ReportObjects.Item("Text5").Left = 100

            Dim crParameterFieldDefinitions As ParameterFieldDefinitions
            Dim crParameterFieldDefinition As ParameterFieldDefinition
            Dim crParameterValues As New ParameterValues
            Dim crParameterDiscreteValue As New ParameterDiscreteValue

            '**************** SET SERVER ************************
            Dim crtableLogonInfo As New TableLogOnInfo
            Dim crConnecttionInfo As New ConnectionInfo
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

            If frmmfgloss = True Then
                crTables = rptml.Database.Tables
            Else
                crTables = rptmw.Database.Tables
            End If
            For Each crTable In crTables
                crtableLogonInfo = crTable.LogOnInfo
                crtableLogonInfo.ConnectionInfo = crConnecttionInfo
                crTable.ApplyLogOnInfo(crtableLogonInfo)
            Next

            If frmmfgloss = True Then
                rptml.DataDefinition.FormulaFields("tempcmpname").Text = "'" & tempcmpname & "'"
                CRPO.ReportSource = rptml
            Else
                rptmw.DataDefinition.FormulaFields("tempcmpname").Text = "'" & tempcmpname & "'"
                CRPO.ReportSource = rptmw
            End If
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