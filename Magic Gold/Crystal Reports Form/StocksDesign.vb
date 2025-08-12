Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlClient
Imports CrystalDecisions.Shared

Public Class StocksDesign

    Dim RPTSTOCK As New StockWithKarigarWastagePrint
    Dim rptpo As New Stocks

    Public FRMSTRING As String = ""
    Public PERIOD As String = ""

    Private Sub StocksDesign_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Keys.Delete Then
                Me.Close()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub StocksDesign_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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

            If FRMSTRING = "STOCK" Then
                crTables = RPTSTOCK.Database.Tables
            Else
                crTables = rptpo.Database.Tables
            End If

            For Each crTable In crTables
                crtableLogonInfo = crTable.LogOnInfo
                crtableLogonInfo.ConnectionInfo = crConnecttionInfo
                crTable.ApplyLogOnInfo(crtableLogonInfo)
            Next

            CRPO.SelectionFormula = strsearch
            If FRMSTRING = "STOCK" Then
                RPTSTOCK.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                CRPO.ReportSource = RPTSTOCK
            Else
                rptpo.DataDefinition.FormulaFields("tempcmpname").Text = "'" & tempcmpname & "'"
                CRPO.ReportSource = rptpo
            End If
            CRPO.Zoom(100)

        Catch Exp As LoadSaveReportException
            MsgBox("Incorrect path for loading report.",
                    MsgBoxStyle.Critical, "Load Report Error")

        Catch Exp As Exception
            MsgBox(Exp.Message, MsgBoxStyle.Critical, "General Error")

        End Try
    End Sub
End Class