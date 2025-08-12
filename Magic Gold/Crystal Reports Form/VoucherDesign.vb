
Imports System.Data.OleDb
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class VoucherDesign

    Dim RPTVOUCHER_JAINAM As New VoucherPrint_JAINAM
    Dim RPTVOUCHER As New VoucherPrintA6
    Dim RPTVOUCHERA6DIRECT As New VoucherPrintA6Direct
    Dim RPTISSVOUCHER_JAINAM As New IssueVoucher_JAINAM
    Dim RPTISSVOUCHER As New IssueVoucherA6
    Dim RPTISSVOUCHERA6DIRECT As New IssueVoucherA6Direct
    Dim RPTISSVOUCHERA5 As New IssueVoucherA5
    Dim RPTISSBHAVCUTVOUCHER As New BhavcutIssueVoucher
    Dim RPTBHAVCUTISSREC As New BhavcutIssRecPrint
    Dim RPTDAILYKHATA As New DailyKhataReport
    Dim RPTJV As New JVPrint
    Dim RPTCASH As New CashVoucherPrint
    Dim RPTSALARY As New SalaryVoucherPrint
    Dim RPTMFGCHITTI As New MfgChitti


    Public SRNO As Integer = 0
    Public ISSREC As String = "ISSUE"
    Public PARTYCODE As String = ""
    Public DEPT As String = ""
    Public PCS As Integer = 0
    Public LOTNO As Integer = 0
    Public PARTNO As String = ""
    Public WT As Double = 0.0
    Public LESSWT As Double = 0.0
    Public NETTWT As Double = 0.0
    Public MELTING As Double = 0.0
    Public ITEMNARR As String = 0
    Public PARTYGROSSBAL As Double = 0.0
    Public PARTYFINEBAL As Double = 0.0

    Public WHERECLAUSE As String = ""
    Public PERIOD As String = ""
    Public FRMSTRING As String = ""
    Public TGROSSJAMA, TNETTJAMA, TAMTJAMA, TGROSSISS, TNETTISS, TAMTISS, OPGROSSJAMA, OPNETTJAMA, OPAMTJAMA, OPGROSSISS, OPNETTISS, OPAMTISS, CLGROSSJAMA, CLNETTJAMA, CLAMTJAMA, CLGROSSISS, CLNETTISS, CLAMTISS As Double

    Public PRINTSETTING As Object = Nothing
    Public DIRECTPRINT As Boolean = False

    Private Sub CRPO_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles CRPO.Load
        Try

            If DIRECTPRINT = True Then
                PRINTDIRECTLYTOPRINTER()
                Exit Sub
            End If


            Dim crParameterFieldDefinitions As ParameterFieldDefinitions
            Dim crParameterFieldDefinition As ParameterFieldDefinition
            Dim crParameterValues As New ParameterValues
            Dim crParameterDiscreteValue As New ParameterDiscreteValue

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


            If FRMSTRING = "CHITTI" Then
                If ClientName = "JAINAM" Then
                    crTables = RPTVOUCHER_JAINAM.Database.Tables
                ElseIf ClientName = "PREM" Then
                    crTables = RPTVOUCHERA6DIRECT.Database.Tables
                Else
                    crTables = RPTVOUCHER.Database.Tables
                End If
            ElseIf FRMSTRING = "ISSUECHITTI" Then
                If ClientName = "CNC" Then
                    crTables = RPTISSVOUCHERA5.Database.Tables
                ElseIf ClientName = "PREM" Then
                    crTables = RPTISSVOUCHERA6DIRECT.Database.Tables
                Else
                    crTables = RPTISSVOUCHER.Database.Tables
                End If
            ElseIf FRMSTRING = "ISSUEBHAVCUTCHITTI" Then
                crTables = RPTISSBHAVCUTVOUCHER.Database.Tables
            ElseIf FRMSTRING = "BHAVCUTISSREC" Then
                crTables = RPTBHAVCUTISSREC.Database.Tables
            ElseIf FRMSTRING = "DAILYKHATA" Then
                crTables = RPTDAILYKHATA.Database.Tables
            ElseIf FRMSTRING = "JOURNAL" Then
                crTables = RPTJV.Database.Tables
            ElseIf FRMSTRING = "CASH" Then
                crTables = RPTCASH.Database.Tables
            ElseIf FRMSTRING = "SALARY" Then
                crTables = RPTSALARY.Database.Tables
            ElseIf FRMSTRING = "MFGCHITTI" Then
                crTables = RPTMFGCHITTI.Database.Tables
            End If


            For Each crTable In crTables
                crtableLogonInfo = crTable.LogOnInfo
                crtableLogonInfo.ConnectionInfo = crConnecttionInfo
                crTable.ApplyLogOnInfo(crtableLogonInfo)
            Next


            'GETPARTYBALANCE
            tempcmd = New OleDbCommand("SELECT CODE, ROUND(SUM(GROSSDR) - SUM(GROSSCR),3) AS GROSSWT, ROUND(SUM(DR) - SUM(CR),3) AS BALWT, ROUND(SUM(AMTDR) - SUM(AMTCR),2) AS BALAMT, ROUND(SUM(PCSDR) - SUM(PCSCR),0) AS BALPCS FROM (SELECT ACCOUNT_LEDGERCODE AS CODE, SUM(ACCOUNT_GROSSWT) AS GROSSDR, 0 AS GROSSCR, SUM(ACCOUNT_NETTWT) AS DR, 0 AS CR, SUM(ACCOUNT_AMOUNT) AS AMTDR, 0 AS AMTCR, SUM(ACCOUNT_PIECES) AS PCSDR, 0 AS PCSCR FROM ACCOUNTMAST WHERE ACCOUNT_BALORJAMAORPAID= 'Jama' AND ACCOUNT_LEDGERCODE = '" & PARTYCODE & "' GROUP BY ACCOUNT_LEDGERCODE UNION ALL SELECT LEDGER_CODE AS CODE, ROUND(LEDGER_OPBALGROSSWT,3) AS GROSSDR, 0 AS GROSSCR, 0 AS DR, 0 AS CR, 0 AS AMTDR, 0 AS AMTCR, 0 AS PCSDR, 0 AS PCSCR FROM LEDGERMASTER WHERE LEDGER_DRCRGROSSWT= 'Cr.' AND LEDGER_CODE = '" & PARTYCODE & "' UNION ALL SELECT LEDGER_CODE AS CODE, 0 AS GROSSDR, 0 AS GROSSCR, ROUND(LEDGER_OPBALWT,3) AS DR, 0 AS CR, 0 AS AMTDR, 0 AS AMTCR, 0 AS PCSDR, 0 AS PCSCR FROM LEDGERMASTER WHERE LEDGER_DRCRWT= 'Cr.'  AND LEDGER_CODE = '" & PARTYCODE & "' UNION ALL SELECT LEDGER_CODE AS CODE, 0 AS GROSSDR, 0 AS GROSSCR, 0 AS DR, 0 AS CR, ROUND(LEDGER_OPBALRS,2) AS AMTDR, 0 AS AMTCR, 0 AS PCSDR, 0 AS PCSCR FROM LEDGERMASTER WHERE LEDGER_DRCRRS= 'Cr.'  AND LEDGER_CODE = '" & PARTYCODE & "' UNION ALL SELECT LEDGER_CODE AS CODE, 0 AS GROSSDR, ROUND(LEDGER_OPBALGROSSWT,3) AS GROSSCR, 0 AS DR, 0 AS CR, 0 AS AMTDR, 0 AS AMTCR, 0 AS PCSDR, 0 AS PCSCR FROM LEDGERMASTER WHERE LEDGER_DRCRGROSSWT= 'Dr.'  AND LEDGER_CODE = '" & PARTYCODE & "' UNION ALL SELECT LEDGER_CODE AS CODE, 0 AS GROSSDR, 0 AS GROSSCR, 0 AS DR, ROUND(LEDGER_OPBALWT,3) AS CR, 0 AS AMTDR, 0 AS AMTCR, 0 AS PCSDR, 0 AS PCSCR FROM LEDGERMASTER WHERE LEDGER_DRCRWT= 'Dr.'  AND LEDGER_CODE = '" & PARTYCODE & "' UNION ALL SELECT LEDGER_CODE AS CODE, 0 AS GROSSDR, 0 AS GROSSCR, 0 AS DR, 0 AS CR, 0 AS AMTDR, ROUND(LEDGER_OPBALRS,2) AS AMTCR, 0 AS PCSDR, 0 AS PCSCR FROM LEDGERMASTER WHERE LEDGER_DRCRRS= 'Dr.'  AND LEDGER_CODE = '" & PARTYCODE & "' UNION ALL SELECT ACCOUNT_LEDGERCODE AS CODE, 0 AS GROSSDR, SUM(ACCOUNT_GROSSWT) AS GROSSCR, 0 AS DR, SUM(ACCOUNT_NETTWT) AS CR, 0 AS AMTDR, SUM(ACCOUNT_AMOUNT) AS AMTCR, 0 AS PCSDR, SUM(ACCOUNT_PIECES)  AS PCSCR FROM ACCOUNTMAST WHERE ACCOUNT_BALORJAMAORPAID = 'Balance'  AND ACCOUNT_LEDGERCODE  = '" & PARTYCODE & "' GROUP BY ACCOUNT_LEDGERCODE ) AS T GROUP BY CODE", tempconn)
            da = New OleDbDataAdapter(tempcmd)
            Dim TEMPDT As New DataTable
            da.Fill(TEMPDT)


            If FRMSTRING = "CHITTI" Then
                CRPO.SelectionFormula = WHERECLAUSE
                If ClientName = "JAINAM" Then
                    CRPO.ReportSource = RPTVOUCHER_JAINAM
                    RPTVOUCHER_JAINAM.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperEnvelopeMonarch
                ElseIf ClientName = "JAINAM" Then
                    CRPO.ReportSource = RPTVOUCHERA6DIRECT
                Else
                    CRPO.ReportSource = RPTVOUCHER
                    RPTVOUCHER.DataDefinition.FormulaFields("CLIENTNAME").Text = "'" & ClientName & "'"
                    RPTVOUCHER.DataDefinition.FormulaFields("PARTYGROSSBAL").Text = Val(TEMPDT.Rows(0).Item("GROSSWT"))
                    RPTVOUCHER.DataDefinition.FormulaFields("PARTYFINEBAL").Text = Val(TEMPDT.Rows(0).Item("BALWT"))
                End If
            ElseIf FRMSTRING = "ISSUECHITTI" Then
                CRPO.SelectionFormula = WHERECLAUSE

                If ClientName = "CNC" Then
                    CRPO.ReportSource = RPTISSVOUCHERA5
                ElseIf ClientName = "PREM" Then
                    CRPO.ReportSource = RPTISSVOUCHERA6DIRECT
                Else
                    CRPO.ReportSource = RPTISSVOUCHER

                    RPTISSVOUCHER.DataDefinition.FormulaFields("CLIENTNAME").Text = "'" & ClientName & "'"
                    RPTISSVOUCHER.DataDefinition.FormulaFields("PARTYGROSSBAL").Text = Val(TEMPDT.Rows(0).Item("GROSSWT"))
                    RPTISSVOUCHER.DataDefinition.FormulaFields("PARTYFINEBAL").Text = Val(TEMPDT.Rows(0).Item("BALWT"))
                End If

            ElseIf FRMSTRING = "ISSUEBHAVCUTCHITTI" Then
                CRPO.SelectionFormula = WHERECLAUSE
                CRPO.ReportSource = RPTISSBHAVCUTVOUCHER

            ElseIf FRMSTRING = "BHAVCUTISSREC" Then
                CRPO.SelectionFormula = WHERECLAUSE
                CRPO.ReportSource = RPTBHAVCUTISSREC

            ElseIf FRMSTRING = "JOURNAL" Then
                CRPO.SelectionFormula = WHERECLAUSE
                CRPO.ReportSource = RPTJV

            ElseIf FRMSTRING = "CASH" Then
                CRPO.SelectionFormula = WHERECLAUSE
                CRPO.ReportSource = RPTCASH

            ElseIf FRMSTRING = "SALARY" Then
                CRPO.SelectionFormula = WHERECLAUSE
                CRPO.ReportSource = RPTSALARY

            ElseIf FRMSTRING = "DAILYKHATA" Then
                'CRPO.SelectionFormula = WHERECLAUSE

                RPTDAILYKHATA.DataDefinition.FormulaFields("OPJAMAGROSS").Text = OPGROSSJAMA
                RPTDAILYKHATA.DataDefinition.FormulaFields("OPJAMANETT").Text = OPNETTJAMA
                RPTDAILYKHATA.DataDefinition.FormulaFields("OPJAMAAMT").Text = OPAMTJAMA
                RPTDAILYKHATA.DataDefinition.FormulaFields("OPISSGROSS").Text = OPGROSSISS
                RPTDAILYKHATA.DataDefinition.FormulaFields("OPISSNETT").Text = OPNETTISS
                RPTDAILYKHATA.DataDefinition.FormulaFields("OPISSAMT").Text = OPAMTISS

                RPTDAILYKHATA.DataDefinition.FormulaFields("TJAMAGROSS").Text = TGROSSJAMA
                RPTDAILYKHATA.DataDefinition.FormulaFields("TJAMANETT").Text = TNETTJAMA
                RPTDAILYKHATA.DataDefinition.FormulaFields("TJAMAAMT").Text = TAMTJAMA
                RPTDAILYKHATA.DataDefinition.FormulaFields("TISSGROSS").Text = TGROSSISS
                RPTDAILYKHATA.DataDefinition.FormulaFields("TISSNETT").Text = TNETTISS
                RPTDAILYKHATA.DataDefinition.FormulaFields("TISSAMT").Text = TAMTISS

                RPTDAILYKHATA.DataDefinition.FormulaFields("CLJAMAGROSS").Text = CLGROSSJAMA
                RPTDAILYKHATA.DataDefinition.FormulaFields("CLJAMANETT").Text = CLNETTJAMA
                RPTDAILYKHATA.DataDefinition.FormulaFields("CLJAMAAMT").Text = CLAMTJAMA
                RPTDAILYKHATA.DataDefinition.FormulaFields("CLISSGROSS").Text = CLGROSSISS
                RPTDAILYKHATA.DataDefinition.FormulaFields("CLISSNETT").Text = CLNETTISS
                RPTDAILYKHATA.DataDefinition.FormulaFields("CLISSAMT").Text = CLAMTISS

                RPTDAILYKHATA.DataDefinition.FormulaFields("DATE").Text = "'" & PERIOD & "'"

                RPTDAILYKHATA.Subreports.Item(0).RecordSelectionFormula = WHERECLAUSE
                RPTDAILYKHATA.Subreports.Item(1).RecordSelectionFormula = WHERECLAUSE
                CRPO.ReportSource = RPTDAILYKHATA

            ElseIf FRMSTRING = "MFGCHITTI" Then

                RPTMFGCHITTI.DataDefinition.FormulaFields("LOTNO").Text = Val(LOTNO)
                RPTMFGCHITTI.DataDefinition.FormulaFields("PARTNO").Text = "'" & PARTNO & "'"
                RPTMFGCHITTI.DataDefinition.FormulaFields("WT").Text = Val(WT)
                RPTMFGCHITTI.DataDefinition.FormulaFields("MELTING").Text = Val(MELTING)
                RPTMFGCHITTI.DataDefinition.FormulaFields("ITEMNARR").Text = "'" & ITEMNARR & "'"
                CRPO.ReportSource = RPTMFGCHITTI

            End If
            CRPO.Zoom(100)
        Catch Exp As LoadSaveReportException
            MsgBox("Incorrect path for loading report.", _
                    MsgBoxStyle.Critical, "Load Report Error")
        Catch Exp As Exception
            MsgBox(Exp.Message, MsgBoxStyle.Critical, "General Error")
        End Try
    End Sub


    Sub PRINTDIRECTLYTOPRINTER()
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


            Dim OBJ As New Object
            If FRMSTRING = "WTCHITTI" Then
                OBJ = New WtChitti

                OBJ.DataDefinition.FormulaFields("SRNO").Text = Val(SRNO)
                OBJ.DataDefinition.FormulaFields("ISSREC").Text = "'" & ISSREC & "'"
                OBJ.DataDefinition.FormulaFields("DEPT").Text = "'" & DEPT & "'"
                OBJ.DataDefinition.FormulaFields("MELTING").Text = Val(MELTING)
                OBJ.DataDefinition.FormulaFields("PCS").Text = Val(PCS)
                OBJ.DataDefinition.FormulaFields("WT").Text = Val(WT)
                OBJ.DataDefinition.FormulaFields("LESSWT").Text = Val(LESSWT)
                OBJ.DataDefinition.FormulaFields("NETTWT").Text = Val(NETTWT)
                OBJ.DataDefinition.FormulaFields("ITEMNARR").Text = "'" & ITEMNARR & "'"
                CRPO.ReportSource = OBJ
            End If

SKIPINVOICE:
            crTables = OBJ.Database.Tables

            For Each crTable In crTables
                crtableLogonInfo = crTable.LogOnInfo
                crtableLogonInfo.ConnectionInfo = crConnecttionInfo
                crTable.ApplyLogOnInfo(crtableLogonInfo)
            Next


            OBJ.PrintOptions.PrinterName = PRINTSETTING.PrinterSettings.PrinterName
            OBJ.PrintToPrinter(1, True, 0, 0)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub VoucherDesign_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Keys.Escape Then Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class