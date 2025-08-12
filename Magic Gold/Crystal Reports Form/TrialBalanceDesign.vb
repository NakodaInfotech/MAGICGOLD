
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlClient
Imports CrystalDecisions.Shared

Public Class TrialBalanceDesign

    Public FRMSTRING As String = ""
    Public PERIOD As String = ""

    Private Sub TrialBalanceDesign_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Keys.Delete Then
                Me.Close()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TrialBalanceDesign_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim RPTTB As New TrialBalance
        Dim RPTTBWTAMT As New TrialBalanceWtAmt

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

            If FRMSTRING = "TBWTAMT" Then
                crTables = RPTTBWTAMT.Database.Tables
            Else
                crTables = RPTTB.Database.Tables
            End If

            For Each crTable In crTables
                crtableLogonInfo = crTable.LogOnInfo
                crtableLogonInfo.ConnectionInfo = crConnecttionInfo
                crTable.ApplyLogOnInfo(crtableLogonInfo)
            Next

            If FRMSTRING = "TBWTAMT" Then
                CRPO.ReportSource = RPTTBWTAMT
                RPTTBWTAMT.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            Else
                CRPO.ReportSource = RPTTB
                RPTTB.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
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