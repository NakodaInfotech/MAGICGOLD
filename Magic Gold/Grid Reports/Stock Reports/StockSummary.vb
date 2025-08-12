
Imports System.Data.OleDb
Imports System.Diagnostics
Imports System.IO

Public Class StockSummary

    Public TITEM As String = ""
    Public TPURITY As Double = 0

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub chkdate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkdate.CheckedChanged
        Try
            dtfrom.Enabled = chkdate.CheckState
            dtto.Enabled = chkdate.CheckState
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub StockSummary_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.Alt = True And e.KeyCode = Windows.Forms.Keys.S Then       'for SHOWDETAILS
                Call CMDSHOWDETAILS_Click(sender, e)
            ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                Me.Close()
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLCMB()
        Try
            If cmbname.Text.Trim = "" Then fillname(Me, cmbname, "")
            If cmbitemname.Text.Trim = "" Then If cmbitemname.Text.Trim = "" Then FILLITEMCODE(Me, cmbitemname, "")
            cmbname.Text = ""
            cmbitemname.Text = ""
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub CLEAR()
        Try
            cmbname.Text = ""
            cmbitemname.Text = ""
            tempname = ""
            tempitemname = ""
            txtpurity.Clear()
            gridStock.DataSource = Nothing
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub StockSummary_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            FILLCMB()
            CLEAR()
            dtfrom.Value = Now.Date
            dtto.Value = Now.Date
            If TITEM <> "" Then FILLGRID()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDSHOWDETAILS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDSHOWDETAILS.Click
        Try
            FILLGRID()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLGRID()
        Try

            Dim WHERECLAUSE As String = ""
            Dim GROUPBYCLAUSE As String = ""
            If USERDEPARTMENT <> "" Then WHERECLAUSE = WHERECLAUSE & " AND STOCKSUMMARY.DEPARTMENT = '" & USERDEPARTMENT & "'"
            If USERDEPARTMENT <> "" Then GROUPBYCLAUSE = GROUPBYCLAUSE & ", STOCKSUMMARY.DEPARTMENT "


            Dim CONDITION As String = " WHERE 1 = 1 "
            If cmbname.Text <> "" And TITEM = "" Then CONDITION = CONDITION & " AND NAME = '" & cmbname.Text.Trim & "'"

            If TITEM <> "" Then cmbitemname.Text = TITEM
            If cmbitemname.Text.Trim <> "" Then CONDITION = CONDITION & " AND ITEMNAME = '" & cmbitemname.Text.Trim & "'"
            If chkdate.CheckState = CheckState.Checked Then CONDITION = CONDITION & " AND DATE BETWEEN #" & Format(dtfrom.Value, "MM/dd/yyyy") & "# AND #" & Format(dtto.Value, "MM/dd/yyyy") & "#"

            If Val(TPURITY) > 0 Then txtpurity.Text = TPURITY
            If Val(txtpurity.Text) > 0 Then CONDITION = CONDITION & " AND PURITY = '" & Format(Val(txtpurity.Text), "0.00") & "'"

            'getting DETAILS
            Dim dt As New DataTable()
            If tempconn.State = ConnectionState.Open Then tempconn.Close()
            tempconn.Open()
            tempcmd = New OleDbCommand("select DATE,ITEMNAME, NAME, LOTNO, STONEWT, PURITY, RECGROSS, RECNETT, ISSGROSS, ISSNETT  from STOCKSUMMARY " & CONDITION & WHERECLAUSE & " order by DATE, ID", tempconn)
            'If cmbitemname.Text.Trim = "" Then
            '    tempcmd = New OleDbCommand("select DATE,ITEMNAME AS NAME, LOTNO, PURITY, RECGROSS, RECNETT, ISSGROSS, ISSNETT  from STOCKSUMMARY " & CONDITION & " order by DATE, ID", tempconn)
            'Else
            '    tempcmd = New OleDbCommand("select DATE,NAME, LOTNO, PURITY, RECGROSS, RECNETT, ISSGROSS, ISSNETT  from STOCKSUMMARY " & CONDITION & " order by DATE, ID", tempconn)
            'End If
            da = New OleDbDataAdapter(tempcmd)
            da.Fill(dt)
            gridStock.DataSource = dt

            total()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub total()
        Try
            'get OPENING 
            Dim dt As New DataTable()
            If tempconn.State = ConnectionState.Open Then tempconn.Close()
            tempconn.Open()
            tempcmd = New OleDbCommand("select  (SUM( IIF(STOCKSUMMARY.RECGROSS = '' , 0 , STOCKSUMMARY.RECGROSS) ) - SUM( IIF(STOCKSUMMARY.ISSGROSS = '' , 0 , STOCKSUMMARY.ISSGROSS ))) AS OPGROSS, (SUM( IIF(STOCKSUMMARY.RECNETT = '' , 0 , STOCKSUMMARY.RECNETT) ) - SUM( IIF(STOCKSUMMARY.ISSNETT = '' , 0 , STOCKSUMMARY.ISSNETT ))) AS OPNETT  from STOCKSUMMARY WHERE DATE < #" & Format(dtfrom.Value, "MM/dd/yyyy") & "#", tempconn)
            da = New OleDbDataAdapter(tempcmd)
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt.Rows(0).Item("OPGROSS")) Then TXTOPGROSS.Text = 0.0 Else TXTOPGROSS.Text = Format(Val(dt.Rows(0).Item("OPGROSS")), "0.000")
                If IsDBNull(dt.Rows(0).Item("OPNETT")) Then TXTOPNETT.Text = 0.0 Else TXTOPNETT.Text = Format(Val(dt.Rows(0).Item("OPNETT")), "0.000")
            Else
                TXTOPGROSS.Text = 0.0
                TXTOPNETT.Text = 0.0
            End If

            txtbalgross.Text = Format(Val(grecgrosswt.SummaryText) - Val(gissuegrosswt.SummaryText), "0.000")
            txtbalnett.Text = Format(Val(grecnettwt.SummaryText) - Val(gissuenettwt.SummaryText), "0.000")

            TXTCLGROSS.Text = Format(Val(TXTOPGROSS.Text) + Val(txtbalgross.Text), "0.000")
            TXTCLNETT.Text = Format(Val(TXTOPNETT.Text) + Val(txtbalnett.Text), "0.000")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridbandstock_ColumnFilterChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridbandstock.ColumnFilterChanged
        Try
            total()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try

            Dim CONDITION As String = ""

            Dim objrep As New clsReportDesigner("Stock Summary", System.AppDomain.CurrentDomain.BaseDirectory & "Stock Summary.xlsx", 2)
            objrep.STOCK_SUMMARY_EXCEL(gridStock.DataSource, CONDITION)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbname.Enter
        Try
            If cmbname.Text.Trim = "" Then fillname(Me, cmbname, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbitemname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbitemname.Enter
        Try
            If cmbitemname.Text.Trim = "" Then If cmbitemname.Text.Trim = "" Then FILLITEMCODE(Me, cmbitemname, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbname.KeyDown
        Try
            If e.KeyCode = Keys.F2 Then
                Dim OBJLEDGER As New SelectLedger
                OBJLEDGER.ShowDialog()
                cmbname.Text = OBJLEDGER.TEMPCODE
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbname.Validating
        Try
            If cmbname.Text.Trim <> "" Then

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EXCEL_ICON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EXCEL_ICON.Click
        Try
            Dim PATH As String = Application.StartupPath & "\Stock Summary.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True

            Dim proc As New System.Diagnostics.Process
            For Each proc In System.Diagnostics.Process.GetProcessesByName("Excel")
                proc.Kill()
            Next
            opti.SheetName = "Stock Summary"
            gridbandstock.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Stock Summary", gridbandstock.VisibleColumns.Count + gridbandstock.GroupCount)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbitemname_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbitemname.KeyDown
        Try
            If e.KeyCode = Keys.F2 Then
                Dim OBJITEM As New SelectItem
                OBJITEM.ShowDialog()
                cmbitemname.Text = OBJITEM.TEMPCODE
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtpurity_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtpurity.KeyPress
        numdotkeypress(e, txtpurity, Me)
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLREFRESH.Click
        Try
            FILLGRID()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class