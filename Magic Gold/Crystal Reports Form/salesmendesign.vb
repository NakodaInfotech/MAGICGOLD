Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class salesmendesign

    Private Sub CRPO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CRPO.Load
        Dim rpt As New salesmenwise

        Try
            CRPO.ReportSource = rpt
            CRPO.SelectionFormula = strsearch
            ' Zoom viewer to fit to the whole page so the user can see the report
            CRPO.Zoom(100)

        Catch Exp As LoadSaveReportException
            MsgBox("Incorrect path for loading report.", _
                    MsgBoxStyle.Critical, "Load Report Error")

        Catch Exp As Exception
            MsgBox(Exp.Message, MsgBoxStyle.Critical, "General Error")
        End Try

    End Sub

    Private Sub salesmendesign_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Keys.Delete Then
                Me.Close()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class