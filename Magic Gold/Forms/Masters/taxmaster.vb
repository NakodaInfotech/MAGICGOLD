Imports System.Data.OleDb

Public Class taxmaster

    Public EDIT As Boolean = False
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub cmdcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
        If cmdedit.Enabled = False Then
            If (chldtaxdetails.IsMdiChild = False) Then
                If chldtaxdetails.IsDisposed = True Then
                    chldtaxdetails = New Taxdetails
                End If
                chldtaxdetails.MdiParent = MDIMain
                chldtaxdetails.Show()
            Else
                chldtaxdetails.BringToFront()
            End If
        End If
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        If ISMASTER = False Then Exit Sub
        If txttax.Text.Trim <> "" And txtname.Text.Trim <> "" Then

            duplicate = False
            If (EDIT = False) Or (EDIT = True And LCase(temptaxname) <> LCase(txtname.Text.Trim)) Then
                tempcondition = ""
                duplication("taxmaster", "tax_name", txtname.Text.Trim, tempcondition)
            End If
            If duplicate = False Then
                tempcol(0) = "tax_name"
                tempcol(1) = "tax_desc"
                tempcol(2) = "tax_tax"
                tempcol(3) = "tax_userid"

                tempval(0) = "'" & txtname.Text.Trim & "'"
                tempval(1) = "'" & txtdescription.Text.Trim & "'"
                tempval(2) = Val(txttax.Text)
                tempval(3) = tempuserid


                If cmdedit.Enabled = True Then EDIT = False
                If cmdedit.Enabled = False Then EDIT = True

                If EDIT = False Then

                    If USERADD = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If

                    insert("taxmaster", tempcol, tempval)
                    MessageBox.Show("Tax Added")
                ElseIf EDIT = True Then
                    If USEREDIT = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If

                    tempcondition = " where tax_name = '" + temptaxname + "'"
                    modify("taxmaster", tempcol, tempval, tempcondition)
                    MessageBox.Show("Tax Updated")
                End If

                'adding in ledgermaster under duties and taxes
                For i = 0 To 100
                    tempcol(i) = ""
                    tempval(i) = ""
                Next

                tempcol(0) = "ledger_name"
                tempcol(1) = "ledger_code"
                tempcol(2) = "ledger_groupid"
                tempcol(3) = "ledger_userid"


                tempval(0) = "'" & txtname.Text.Trim & "'"
                tempval(1) = "'" & txtname.Text.Trim & "'"
                tempval(3) = tempuserid


                'getting grouid
                cmd = New OleDbCommand("select group_id from groupmaster where group_name = 'Duties & Taxes' ", conn)
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
                conn.Open()
                dr = cmd.ExecuteReader
                If dr.HasRows = True Then
                    dr.Read()
                    tempval(2) = dr(0).ToString
                End If

                If EDIT = False Then
                    insert("ledgermaster", tempcol, tempval)
                ElseIf EDIT = True Then
                    tempcondition = " where ledger_name = '" + temptaxname + "'"
                    modify("ledgermaster", tempcol, tempval, tempcondition)
                End If

                Me.Close()
                If cmdedit.Enabled = False Then
                    If (chldtaxdetails.IsMdiChild = False) Then
                        If chldtaxdetails.IsDisposed = True Then
                            chldtaxdetails = New Taxdetails
                        End If
                        chldtaxdetails.MdiParent = MDIMain
                        chldtaxdetails.Show()
                    Else
                        chldtaxdetails.BringToFront()
                    End If
                End If
            Else
                MsgBox("Tax Name Already Exists")
                txtname.Focus()
            End If


        Else
            MsgBox("Enter Valid Details")
            txtname.Focus()
        End If
    End Sub

    Private Sub txttax_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txttax.GotFocus
        If txttax.Text = "" Then txttax.Text = ".00"
    End Sub

    Private Sub txttax_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txttax.KeyPress
        numdot(e, txttax, Me)
    End Sub

    Sub clear()

        'clearing array
        For i = 0 To 100
            tempcol(i) = ""
            tempval(i) = ""
        Next
        txtname.Clear()
        txtdescription.Clear()
        txttax.Clear()

    End Sub

    Private Sub txtname_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtname.GotFocus
        txtname.SelectAll()
    End Sub

    Private Sub txtname_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtname.KeyPress
        enterkeypress(e, Me)
    End Sub

    Private Sub txtdescription_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtdescription.GotFocus
        txtdescription.SelectAll()
    End Sub

    Private Sub txtdescription_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdescription.KeyPress
        enterkeypress(e, Me)
    End Sub

    Private Sub txtname_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtname.LostFocus
        txtname.Text = caps(txtname.Text.Trim)
    End Sub

    Private Sub txtname_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtname.Validated
        If txtname.Text.Trim <> "" Then
            duplicate = False
            If (edit = False) Or (edit = True And LCase(temptaxname) <> LCase(txtname.Text.Trim)) Then
                tempcondition = ""
                duplication("taxmaster", "tax_name", txtname.Text.Trim, tempcondition)
            End If
            If duplicate = True Then
                MessageBox.Show("Tax Name Already Exists.")
                txtname.Clear()
                txtname.Focus()
            End If
        End If
    End Sub

    Private Sub taxmaster_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub taxmaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'TAX MASTER'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            Me.Text = "New Tax"
            lbltax.Text = "Tax"
            lbl.Text = "Used to Calculate Tax at a specific rate that You pay to a Tax agency"

            'getting data from database
            If edit = True Then

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Me.Text = "Edit Tax"
                cmd = New OleDbCommand("select * from taxmaster where tax_name = '" & temptaxname & "'", conn)
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If

                conn.Open()
                dr = cmd.ExecuteReader()
                While (dr.Read())

                    txtname.Text = dr(1).ToString
                    txtdescription.Text = dr(2).ToString
                    txttax.Text = dr(3).ToString

                End While
                conn.Close()
                dr.Close()

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub taxmaster_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Try
            If ISMASTER = False Then
                cmdok.Enabled = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class