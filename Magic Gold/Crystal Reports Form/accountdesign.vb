
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.CrystalReports.Engine.Subreports
Imports CrystalDecisions.CrystalReports.Engine.CrossTabObject
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Shared
Imports System
Imports System.ComponentModel

Public Class accountdesign

    Private Sub accountdesign_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Keys.Delete Then
                Me.Close()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub accountdesign_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim rptio As New ItemPurityReport
        Dim rptirs As New itemrunningstock
        Try

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

            If frmstring = "IPreport" Then
                crTables = rptirs.Database.Tables
            Else
                crTables = rptio.Database.Tables
            End If

            For Each crTable In crTables
                crtableLogonInfo = crTable.LogOnInfo
                crtableLogonInfo.ConnectionInfo = crConnecttionInfo
                crTable.ApplyLogOnInfo(crtableLogonInfo)
            Next


            If frmstring = "IPreport" Then
                rptirs.RecordSelectionFormula = strsearch
                CRPO.ReportSource = rptirs
            Else
                rptio.RecordSelectionFormula = strsearch
                rptio.DataDefinition.FormulaFields("tempcmpname").Text = "'" & tempcmpname & "'"
                CRPO.ReportSource = rptio
            End If

            CRPO.Zoom(100)
        Catch Exp As LoadSaveReportException
            MsgBox("Incorrect path for loading report.", _
                    MsgBoxStyle.Critical, "Load Report Error")
        Catch Exp As Exception
            MsgBox(Exp.Message, MsgBoxStyle.Critical, "General Error")

        End Try
        'Me.ReportViewer1.RefreshReport()
    End Sub
End Class