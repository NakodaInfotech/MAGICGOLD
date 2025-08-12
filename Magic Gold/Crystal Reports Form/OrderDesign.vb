
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlClient
Imports CrystalDecisions.Shared

Public Class OrderDesign

    Public WHERECLAUSE As String = ""
    Public PERIOD As String = ""
    Public FRMSTRING As String = ""
    Public NEWPAGE As Boolean
    Public INDEX As Boolean

    Private Sub CRPO_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles CRPO.Load
        Dim RPTORDER As New PendingOrder
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

            crTables = RPTORDER.Database.Tables
            For Each crTable In crTables
                crtableLogonInfo = crTable.LogOnInfo
                crtableLogonInfo.ConnectionInfo = crConnecttionInfo
                crTable.ApplyLogOnInfo(crtableLogonInfo)
            Next

            CRPO.SelectionFormula = WHERECLAUSE
            CRPO.ReportSource = RPTORDER
            RPTORDER.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            RPTORDER.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperEnvelopeMonarch
            CRPO.Zoom(100)
        Catch Exp As LoadSaveReportException
            MsgBox("Incorrect path for loading report.", _
                    MsgBoxStyle.Critical, "Load Report Error")
        Catch Exp As Exception
            MsgBox(Exp.Message, MsgBoxStyle.Critical, "General Error")
        End Try
    End Sub

    Private Sub OrderDesign_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Keys.Delete Then
                Me.Close()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class