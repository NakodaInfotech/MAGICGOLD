
Imports System.Data.OleDb

Public Class MergeItem

    Private Sub cmdsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsave.Click
        Try

            If MsgBox("All Data from " & CMBITEMCODE.Text.Trim & " will be transferred to " & CMBMERGEITEMCODE.Text.Trim & ", wish to Proceed?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

            EP.Clear()
            If Not ERRORVALID() Then
                Exit Sub
            End If

            'clearing array
            For i = 1 To 100
                tempcol(i) = ""
                tempval(i) = ""
            Next


            Dim ITEMID, MERGEITEMID As Integer

            'getting itemid
            tempcmd = New OleDbCommand("select item_id from itemmaster where item_code = '" & CMBITEMCODE.Text.Trim & "'", tempconn)
            If tempconn.State = ConnectionState.Open Then tempconn.Close()
            tempconn.Open()
            tempdr = tempcmd.ExecuteReader
            If tempdr.HasRows Then
                tempdr.Read()
                ITEMID = Val(tempdr(0))
            End If
            tempconn.Close()
            tempdr.Close()

            'GETTING MERGERITEMID
            tempcmd = New OleDbCommand("select item_id from itemmaster where item_code = '" & CMBMERGEITEMCODE.Text.Trim & "'", tempconn)
            If tempconn.State = ConnectionState.Open Then tempconn.Close()
            tempconn.Open()
            tempdr = tempcmd.ExecuteReader
            If tempdr.HasRows Then
                tempdr.Read()
                MERGEITEMID = Val(tempdr(0))
            End If
            tempconn.Close()
            tempdr.Close()



            'we need to MERGE ITEM IN EVERY TABLE
            'ACCOUNTMASTER
            tempcol(0) = "ACCOUNT_ITEMID"
            tempval(0) = MERGEITEMID
            modify("ACCOUNTMASTER", tempcol, tempval, " WHERE ACCOUNT_ITEMID = " & ITEMID)


            'BHAVCUTMASTER
            tempcol(0) = "BHAVCUT_ITEMID"
            tempval(0) = MERGEITEMID
            modify("BHAVCUTMASTER", tempcol, tempval, " WHERE BHAVCUT_ITEMID = " & ITEMID)


            'CASTING
            tempcol(0) = "CASTING_ITEMID"
            tempval(0) = MERGEITEMID
            modify("CASTING", tempcol, tempval, " WHERE CASTING_ITEMID = " & ITEMID)


            'CUSTOMERWASTAGE
            tempcol(0) = "ITEMID"
            tempval(0) = MERGEITEMID
            modify("CUSTOMERWASTAGE", tempcol, tempval, " WHERE ITEMID = " & ITEMID)


            'FILLING
            tempcol(0) = "FILLING_ITEMID"
            tempval(0) = MERGEITEMID
            modify("FILLING", tempcol, tempval, " WHERE FILLING_ITEMID = " & ITEMID)


            'INVOICEDESCRIPTION
            tempcol(0) = "INVOICE_ITEMID"
            tempval(0) = MERGEITEMID
            modify("INVOICEDESCRIPTION", tempcol, tempval, " WHERE INVOICE_ITEMID = " & ITEMID)


            'ITEMSTOCK
            tempcol(0) = "ITEM_ID"
            tempval(0) = MERGEITEMID
            modify("ITEMSTOCK", tempcol, tempval, " WHERE ITEM_ID = " & ITEMID)


            'KARIGARISSUE
            tempcol(0) = "MFG_ITEMID"
            tempval(0) = MERGEITEMID
            modify("KARIGARISSUE", tempcol, tempval, " WHERE MFG_ITEMID = " & ITEMID)


            'LOTFAIL
            tempcol(0) = "MFG_ITEMID"
            tempval(0) = MERGEITEMID
            modify("LOTFAIL", tempcol, tempval, " WHERE MFG_ITEMID = " & ITEMID)


            'MELTINGMASTER
            tempcol(0) = "MELTING_ITEMID"
            tempval(0) = MERGEITEMID
            modify("MELTINGMASTER", tempcol, tempval, " WHERE MELTING_ITEMID = " & ITEMID)


            'ORDERMASTER
            tempcol(0) = "ORDER_ITEMID"
            tempval(0) = MERGEITEMID
            modify("ORDERMASTER", tempcol, tempval, " WHERE ORDER_ITEMID = " & ITEMID)


            'ORDERREC
            tempcol(0) = "REC_ITEMID"
            tempval(0) = MERGEITEMID
            modify("ORDERREC", tempcol, tempval, " WHERE REC_ITEMID = " & ITEMID)


            'ORDERRETURN
            tempcol(0) = "RETURN_ITEMID"
            tempval(0) = MERGEITEMID
            modify("ORDERRETURN", tempcol, tempval, " WHERE RETURN_ITEMID = " & ITEMID)


            'RECIEPTDESCRIPTION
            tempcol(0) = "RECIEPT_ITEMID"
            tempval(0) = MERGEITEMID
            modify("RECIEPTDESCRIPTION", tempcol, tempval, " WHERE RECIEPT_ITEMID = " & ITEMID)


            'VOUCHERS
            tempcol(0) = "VOUCHER_ITEMID"
            tempval(0) = MERGEITEMID
            modify("VOUCHERS", tempcol, tempval, " WHERE VOUCHER_ITEMID = " & ITEMID)


            'AFTER THIS DELETE THE ITEM FROM ITEMMASTER
            cmd = New OleDbCommand("delete from ITEMMASTER where ITEM_ID = " & ITEMID, conn)
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Open()
            cmd.ExecuteNonQuery()
            MsgBox("Item Merged Successfully")
            Me.Close()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Function ERRORVALID() As Boolean
        Try
            Dim BLN As Boolean = True

            If CMBITEMCODE.Text.Trim = "" Then
                EP.SetError(CMBITEMCODE, "Enter Item Name to Merge")
                BLN = False
            End If

            If CMBMERGEITEMCODE.Text.Trim = "" Then
                EP.SetError(CMBMERGEITEMCODE, "Enter Item Name to Merge")
                BLN = False
            End If

            If LCase(CMBITEMCODE.Text.Trim) = LCase(CMBMERGEITEMCODE.Text.Trim) Then
                EP.SetError(CMBITEMCODE, "Invalid Selection")
                BLN = False
            End If
            
            Return BLN
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Sub clear()
        CMBITEMCODE.Text = ""
        CMBMERGEITEMCODE.Text = ""
        EP.Clear()
    End Sub

    Private Sub cmdclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        clear()
        CMBITEMCODE.Focus()
    End Sub

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub MergeItem_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                If ERRORVALID() = True Then
                    Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                    If tempmsg = vbYes Then cmdsave_Click(sender, e)
                End If
                Me.Close()
            ElseIf e.KeyCode = Keys.Oemcomma Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub MergeItem_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If CMBITEMCODE.Text.Trim = "" Then If CMBITEMCODE.Text.Trim = "" Then FILLITEMCODE(Me, CMBITEMCODE, "")
        If CMBMERGEITEMCODE.Text.Trim = "" Then If CMBMERGEITEMCODE.Text.Trim = "" Then FILLITEMCODE(Me, CMBMERGEITEMCODE, "")
    End Sub

    Private Sub CMBMERGEITEMCODE_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBMERGEITEMCODE.Enter
        Try
            If CMBMERGEITEMCODE.Text.Trim = "" Then If CMBMERGEITEMCODE.Text.Trim = "" Then FILLITEMCODE(Me, CMBMERGEITEMCODE, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBMERGEITEMCODE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBMERGEITEMCODE.KeyDown
        Try
            If e.KeyCode = Keys.F1 And e.Alt = True Then
                Dim OBJITEM As New SelectItem
                OBJITEM.ShowDialog()
                CMBMERGEITEMCODE.Text = OBJITEM.TEMPCODE
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBMERGEITEMCODE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBMERGEITEMCODE.Validating
        Try
            If CMBMERGEITEMCODE.Text.Trim <> "" Then ITEMVALIDATE(CMBMERGEITEMCODE, e, Me, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBITEMCODE_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBITEMCODE.Enter
        Try
            If CMBITEMCODE.Text.Trim = "" Then If CMBITEMCODE.Text.Trim = "" Then FILLITEMCODE(Me, CMBITEMCODE, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBITEMCODE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBITEMCODE.KeyDown
        Try
            If e.KeyCode = Keys.F1 And e.Alt = True Then
                Dim OBJITEM As New SelectItem
                OBJITEM.ShowDialog()
                CMBITEMCODE.Text = OBJITEM.TEMPCODE
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBITEMCODE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBITEMCODE.Validating
        Try
            If CMBITEMCODE.Text.Trim <> "" Then ITEMVALIDATE(CMBITEMCODE, e, Me, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class