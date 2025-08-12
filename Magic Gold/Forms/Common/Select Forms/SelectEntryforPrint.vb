
Imports System.Windows.Forms
Imports System.Data.OleDb
Imports System.ComponentModel.Component
Imports System.Diagnostics

Public Class SelectEntryforPrint

    Dim ADDCOL As Boolean = False
    Dim col As New DataGridViewCheckBoxColumn
    Public WHERECLAUSE As String = ""

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub SelectEntryforPrint_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Keys.Escape Then Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SelectEntryforPrint_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If cmbcode.Text.Trim = "" Then fillname(Me, cmbcode, tempcondition)
            FILLGRID()
            CHKALL.CheckState = CheckState.Checked
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLGRID()
        Try
            If cmbcode.Text.Trim <> "" Then
                dt = New DataTable()
                If tempconn.State = ConnectionState.Open Then tempconn.Close()
                tempconn.Open()
                tempcmd = New OleDbCommand("SELECT ItemMaster.item_code AS ITEMCODE, accountmaster.account_grosswt AS GROSSWT, accountmaster.account_purity AS PURITY, accountmaster.account_nettwt AS NETTWT, accountmaster.account_type AS TYPE, accountmaster.account_voucherid AS VOUCHERID FROM  (accountmaster LEFT JOIN ItemMaster ON accountmaster.account_itemid = ItemMaster.item_id) LEFT JOIN vouchers ON accountmaster.account_voucherid = vouchers.voucher_id  where ACCOUNTMASTER.ACCOUNT_LEDGERCODE = '" & cmbcode.Text.Trim & "' and accountmaster.account_date>=#" & Format(dtpfrom.Value, "MM/dd/yyyy") & "# and accountmaster.account_date<=#" & Format(dtpto.Value, "MM/dd/yyyy") & "# " & WHERECLAUSE & " AND ((vouchers.VOUCHER_PRINT  = 0 ) OR ( vouchers.VOUCHER_PRINT IS NULL)) order by accountmaster.account_date, accountmaster.account_type desc ,accountmaster.account_voucherid", tempconn)
                da = New OleDbDataAdapter(tempcmd)
                da.Fill(dt)
                GRIDENTRY.DataSource = dt
                If ADDCOL = False Then
                    GRIDENTRY.Columns.Insert(0, col)
                    ADDCOL = True
                End If
                Dim i As Integer = 0
                GRIDENTRY.Columns(i).Width = 40 'CHECK BOK
                GRIDENTRY.Columns(i).Name = "CHK" 'CHECK BOK
                i += 1
                GRIDENTRY.Columns(i).Width = 130 'ITEMCODE
                GRIDENTRY.Columns(i).HeaderText = "Item Code" 'ITEMCODE
                i += 1
                GRIDENTRY.Columns(i).Width = 90 'GROSSWT
                GRIDENTRY.Columns(i).HeaderText = "Gross Wt" 'ITEMCODE
                GRIDENTRY.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                GRIDENTRY.Columns(i).DefaultCellStyle.Format = "N3"
                i += 1
                GRIDENTRY.Columns(i).Width = 50 'PURITY
                GRIDENTRY.Columns(i).HeaderText = "Purity" 'PURITY
                GRIDENTRY.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                GRIDENTRY.Columns(i).DefaultCellStyle.Format = "N2"
                i += 1
                GRIDENTRY.Columns(i).Width = 90 'NETTWT
                GRIDENTRY.Columns(i).HeaderText = "Nett Wt" 'NETTWT
                GRIDENTRY.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                GRIDENTRY.Columns(i).DefaultCellStyle.Format = "N3"
                i += 1
                GRIDENTRY.Columns(i).Visible = False    'TYPE
                i += 1
                GRIDENTRY.Columns(i).Width = 80     'VOUCERID
                GRIDENTRY.Columns(i).HeaderText = "Bill No" 'NETTWT
                GRIDENTRY.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                i += 1

                If dt.Rows.Count > 0 Then GRIDENTRY.FirstDisplayedScrollingRowIndex = GRIDENTRY.RowCount - 1
                tempconn.Close()
            Else
            MsgBox("Select Party", MsgBoxStyle.Critical)
            cmbcode.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbcode_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbcode.Enter
        If cmbcode.Text.Trim = "" Then fillname(Me, cmbcode, tempcondition)
        cmbcode.SelectAll()
    End Sub

    Private Sub cmbcode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbcode.KeyDown
        Try
            If e.KeyCode = Keys.F2 Then
                Dim OBJLEDGER As New SelectLedger
                OBJLEDGER.ShowDialog()
                cmbcode.Text = OBJLEDGER.TEMPCODE
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbcode_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbcode.KeyPress
        enterkeypress(e, Me)
    End Sub

    Private Sub cmbcode_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbcode.Validating
        If cmbcode.Text.Trim <> "" Then

            cmbcode.Text = uppercase(cmbcode.Text)
            cmd = New OleDbCommand("SELECT ledgermaster.ledger_code,ledgermaster.ledger_id,ledgermaster.ledger_name AS NAME from ledgermaster where ledgermaster.ledger_code = '" & cmbcode.Text.Trim & "'", conn)
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
            conn.Open()
            dr = cmd.ExecuteReader
            If dr.HasRows Then
                dr.Read()
                tempnameid = dr(1)
                LBLNAME.Text = dr("NAME")
                FILLGRID()
            Else
                tempmsg = MsgBox("Ledger Not Present, Add New?", MsgBoxStyle.YesNo)
                If tempmsg = vbYes Then

                    If (chldvendormaster.IsMdiChild = False) Then
                        If chldvendormaster.IsDisposed = True Then
                            chldvendormaster = New ACCOUNTMASTER
                        End If
                        chldvendormaster.txtcode.Text = cmbcode.Text
                        chldvendormaster.cmdedit.Enabled = True
                        chldvendormaster.EDIT = False
                        e.Cancel = True
                        chldvendormaster.Show(Me)
                        chldvendormaster.ActiveControl = (chldvendormaster.txtcode)
                        chldvendormaster.txtcode.Focus()
                    Else
                        chldvendormaster.BringToFront()
                    End If
                Else
                    cmbcode.Focus()
                End If
            End If
        End If
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            Dim OBJVOUCHER As New VoucherDesign
            For Each ROW As DataGridViewRow In GRIDENTRY.Rows
                If Convert.ToBoolean(ROW.Cells("CHK").Value) = True Then
                    If ROW.Cells("TYPE").Value = "A" Then
                        If OBJVOUCHER.WHERECLAUSE = "" Then
                            OBJVOUCHER.WHERECLAUSE = " ({ACCOUNTMAST.ACCOUNT_VOUCHERID} = " & Val(ROW.Cells("VOUCHERID").Value)
                        ElseIf OBJVOUCHER.WHERECLAUSE <> "" Then
                            OBJVOUCHER.WHERECLAUSE = OBJVOUCHER.WHERECLAUSE & " OR {ACCOUNTMAST.ACCOUNT_VOUCHERID} = " & Val(ROW.Cells("VOUCHERID").Value)
                        End If
                        OBJVOUCHER.FRMSTRING = "CHITTI"
                    ElseIf ROW.Cells("TYPE").Value = "I" Then
                        If OBJVOUCHER.WHERECLAUSE = "" Then
                            OBJVOUCHER.WHERECLAUSE = " ({VOUCHERS.VOUCHER_ID}  = " & Val(ROW.Cells("VOUCHERID").Value)
                        ElseIf OBJVOUCHER.WHERECLAUSE <> "" Then
                            OBJVOUCHER.WHERECLAUSE = OBJVOUCHER.WHERECLAUSE & " OR {VOUCHERS.VOUCHER_ID}  = " & Val(ROW.Cells("VOUCHERID").Value)
                        End If

                        cmd = New OleDbCommand("UPDATE vouchers SET VOUCHER_PRINT = 1 where voucher_id = " & Val(ROW.Cells("VOUCHERID").Value) & " and voucher_type ='i'", conn)
                        If conn.State = ConnectionState.Open Then conn.Close()
                        conn.Open()
                        cmd.ExecuteNonQuery()

                        OBJVOUCHER.FRMSTRING = "ISSUECHITTI"
                    End If
                End If
            Next
            OBJVOUCHER.WHERECLAUSE = OBJVOUCHER.WHERECLAUSE & ")"
            If OBJVOUCHER.FRMSTRING = "ISSUECHITTI" Then OBJVOUCHER.WHERECLAUSE = OBJVOUCHER.WHERECLAUSE & " and {VOUCHERS.VOUCHER_TYPE} = 'I'"
            OBJVOUCHER.MdiParent = MDIMain
            OBJVOUCHER.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDENTRY_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDENTRY.CellClick
        If e.RowIndex >= 0 Then
            With GRIDENTRY.Rows(e.RowIndex).Cells(0)
                If .Value = True Then
                    .Value = False
                Else
                    .Value = True
                End If
            End With
        End If
    End Sub

    Private Sub CHKALL_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKALL.CheckedChanged
        Try
            For Each ROW As DataGridViewRow In GRIDENTRY.Rows
                ROW.Cells(0).Value = CHKALL.CheckState
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class