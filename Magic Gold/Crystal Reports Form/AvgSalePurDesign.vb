Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.OleDb

Public Class AvgSalePurDesign

    Private Sub AvgSalePurDesign_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Keys.Delete Then
                Me.Close()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AvgSalePurDesign_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim rptpo As New avgsalepurchase
        Dim rptpwr As New wastagepartyitem
        Dim rptmv As New vaccum
        Try


            If frmavgsalepur = True Then
                CRPO.ReportSource = rptpo
            ElseIf frmpartyitemwast = True Then
                CRPO.ReportSource = rptpwr
            ElseIf frmmfgvaccum = True Then
                If strsearch = "" Then
                    strsearch = " {mfgWastage.process_vaccum}= " & True
                Else
                    strsearch = strsearch & " AND {mfgWastage.process_vaccum}=" & True
                End If
                CRPO.ReportSource = rptmv
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