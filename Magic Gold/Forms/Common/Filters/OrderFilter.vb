
Imports System.Data.OleDb

Public Class OrderFilter

    Sub fillac()
        'filling all groups and subgroups
        cmd = New OleDbCommand("select distinct account_ledgercode from accountmaster", conn)
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If
        conn.Open()
        dr = cmd.ExecuteReader()
        If dr.HasRows Then
            While (dr.Read())
                cmbname.Items.Add(dr(0).ToString)
            End While
        End If
    End Sub

    Sub getFromToDate()
        a1 = DatePart(DateInterval.Day, dtpfrom.Value)
        a2 = DatePart(DateInterval.Month, dtpfrom.Value)
        a3 = DatePart(DateInterval.Year, dtpfrom.Value)
        fromD = "(" & a3 & "," & a2 & "," & a1 & ")"

        a11 = DatePart(DateInterval.Day, dtpto.Value)
        a12 = DatePart(DateInterval.Month, dtpto.Value)
        a13 = DatePart(DateInterval.Year, dtpto.Value)
        toD = "(" & a13 & "," & a12 & "," & a11 & ")"
    End Sub

    Private Sub OrderFilter_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        fillac()
        If cmbitemcode.Text.Trim = "" Then FILLITEMCODE(Me, cmbitemcode, "")
        fillcmb(CMBCATEGORY, "category_name", "categorymaster", tempcondition)
    End Sub

    Private Sub cmbitemcode_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbitemcode.Enter
        Try
            If cmbitemcode.Text.Trim = "" Then FILLITEMCODE(Me, cmbitemcode, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbitemcode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbitemcode.KeyDown
        Try
            If e.KeyCode = Keys.F1 And e.Alt = True Then
                Dim OBJITEM As New SelectItem
                OBJITEM.ShowDialog()
                cmbitemcode.Text = OBJITEM.TEMPCODE
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbitemcode_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbitemcode.Validating
        Try
            If cmbitemcode.Text.Trim <> "" Then ITEMVALIDATE(cmbitemcode, e, Me, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancel.Click
        Me.Close()
    End Sub

    Private Sub CMDOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDOK.Click
        Try
            Dim OBJORDER As New OrderDesign
            OBJORDER.WHERECLAUSE = " 1 = 1 "

            If cmbname.Text.Trim <> "" Then OBJORDER.WHERECLAUSE = OBJORDER.WHERECLAUSE & " AND {LEDGERMASTER.LEDGER_CODE} = '" & cmbname.Text.Trim & "'"
            If cmbitemcode.Text.Trim <> "" Then OBJORDER.WHERECLAUSE = OBJORDER.WHERECLAUSE & " AND {ITEMMASTER.ITEM_CODE} = '" & cmbitemcode.Text.Trim & "'"
            If CMBCATEGORY.Text.Trim <> "" Then OBJORDER.WHERECLAUSE = OBJORDER.WHERECLAUSE & " AND {CATEGORYMASTER.CATEGORY_NAME} = '" & CMBCATEGORY.Text.Trim & "'"
            If Val(txtpurity.Text.Trim) > 0 Then OBJORDER.WHERECLAUSE = OBJORDER.WHERECLAUSE & " and {ORDERMASTER.ORDER_MELTING} =" & Val(txtpurity.Text.Trim)

            If chkdate.CheckState = CheckState.Checked Then
                getFromToDate()
                OBJORDER.WHERECLAUSE = OBJORDER.WHERECLAUSE & " and {ORDERMASTER.ORDER_DATE} in date" & fromD & " to date" & toD
                OBJORDER.PERIOD = "(" & Format(dtpfrom.Value, "dd/MM/yyyy") & " - " & Format(dtpto.Value, "dd/MM/yyyy") & ")"
            End If

            If RBALL.Checked = True Then
                OBJORDER.FRMSTRING = "ALL"
                OBJORDER.PERIOD = "ORDER DETAILS  " & OBJORDER.PERIOD
            ElseIf RBPENDING.Checked = True Then
                OBJORDER.FRMSTRING = "PENDING"
                OBJORDER.PERIOD = "PENDING ORDERS  " & OBJORDER.PERIOD
                OBJORDER.WHERECLAUSE = OBJORDER.WHERECLAUSE & " and ({ORDERMASTER.ORDER_GOLDWT}-{ORDERMASTER.ORDER_MFGWT}) > 0  and {ORDERMASTER.ORDER_CLOSE} = FALSE"
            ElseIf RBCOMPLETE.Checked = True Then
                OBJORDER.FRMSTRING = "COMPLETED"
                OBJORDER.PERIOD = "COMPLETED ORDERS  " & OBJORDER.PERIOD
                OBJORDER.WHERECLAUSE = OBJORDER.WHERECLAUSE & " and ({ORDERMASTER.ORDER_DONE} = TRUE OR {ORDERMASTER.ORDER_CLOSE} = TRUE)"
            ElseIf RBISSUED.Checked = True Then
                OBJORDER.FRMSTRING = "ISSUED"
                OBJORDER.PERIOD = "ISSUED ORDERS  " & OBJORDER.PERIOD
                OBJORDER.WHERECLAUSE = OBJORDER.WHERECLAUSE & " and {ORDERMASTER.ORDER_MFGWT} > 0 "
            ElseIf RBCLOSED.Checked = True Then
                OBJORDER.FRMSTRING = "CLOSED"
                OBJORDER.PERIOD = "CLOSED ORDERS  " & OBJORDER.PERIOD
                OBJORDER.WHERECLAUSE = OBJORDER.WHERECLAUSE & " and {ORDERMASTER.ORDER_CLOSE} = TRUE "
            End If

            If CHKINDEX.Checked = True Then OBJORDER.INDEX = CHKINDEX.Checked
            If CHKNEWPAGE.Checked = True Then OBJORDER.NEWPAGE = CHKNEWPAGE.Checked
            OBJORDER.MdiParent = MDIMain
            OBJORDER.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCATEGORY_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBCATEGORY.Enter
        fillcmb(CMBCATEGORY, "category_name", "categorymaster", tempcondition)
    End Sub

    Private Sub cmbname_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbname.KeyDown
        Try
            If e.KeyCode = Keys.F1 And e.Alt = True Then
                Dim OBJSELECT As New SelectLedger
                OBJSELECT.STRSEARCH = " AND (GROUPMASTER.GROUP_NAME = 'Sundry Debtor' or GROUPMASTER.GROUP_NAME = 'Sundry Creditors')"
                OBJSELECT.ShowDialog()
                cmbname.Text = OBJSELECT.TEMPCODE
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class