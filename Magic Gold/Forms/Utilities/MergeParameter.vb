
Imports System.Data.OleDb

Public Class MergeParameter

    Private Sub cmdsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsave.Click
        Try

            EP.Clear()
            If Not ERRORVALID() Then
                Exit Sub
            End If

            If MsgBox("Please take Backup Before Proceeding to Merge, Wish to Continue?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            If MsgBox("All Data from " & CMBOLDNAME.Text.Trim & " will be transferred to " & CMBMERGENAME.Text.Trim & ", wish to Proceed?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub


            'clearing array
            For i = 1 To 100
                tempcol(i) = ""
                tempval(i) = ""
            Next


            Dim OLDNAMEID, MERGENAMEID As Integer


            If CMBPARAMETER.Text = "LEDGER" Then

                'getting OLDNAMEID
                tempcmd = New OleDbCommand("select LEDGER_id from LEDGERMASTER where LEDGER_code = '" & CMBOLDNAME.Text.Trim & "'", tempconn)
                If tempconn.State = ConnectionState.Open Then tempconn.Close()
                tempconn.Open()
                tempdr = tempcmd.ExecuteReader
                If tempdr.HasRows Then
                    tempdr.Read()
                    OLDNAMEID = Val(tempdr(0))
                End If
                tempconn.Close()
                tempdr.Close()

                'GETTING MERGENAMEID
                tempcmd = New OleDbCommand("select LEDGER_id from LEDGERMASTER where LEDGER_code = '" & CMBMERGENAME.Text.Trim & "'", tempconn)
                If tempconn.State = ConnectionState.Open Then tempconn.Close()
                tempconn.Open()
                tempdr = tempcmd.ExecuteReader
                If tempdr.HasRows Then
                    tempdr.Read()
                    MERGENAMEID = Val(tempdr(0))
                End If
                tempconn.Close()
                tempdr.Close()



                'we need to MERGE ITEM IN EVERY TABLE
                'ACCOUNTMASTER
                tempcol(0) = "account_ledgerid"
                tempcol(1) = "account_ledgercode"
                tempval(0) = MERGENAMEID
                tempval(1) = "'" & CMBMERGENAME.Text.Trim & "'"
                modify("ACCOUNTMASTER", tempcol, tempval, " WHERE ACCOUNT_LEDGERID = " & OLDNAMEID)

                tempcol(1) = ""
                tempval(1) = ""


                'BHAVCUTMASTER
                tempcol(0) = "bhavcut_ledgerid"
                tempval(0) = MERGENAMEID
                modify("BHAVCUTMASTER", tempcol, tempval, " WHERE bhavcut_ledgerid = " & OLDNAMEID)


                'CASHENTRY
                tempcol(0) = "CASH_LEDGERID"
                tempval(0) = MERGENAMEID
                modify("CASHENTRY", tempcol, tempval, " WHERE CASH_LEDGERID = " & OLDNAMEID)


                'CASHENTRY
                tempcol(0) = "CASH_TOLEDGERID"
                tempval(0) = MERGENAMEID
                modify("CASHENTRY", tempcol, tempval, " WHERE CASH_TOLEDGERID = " & OLDNAMEID)


                'CASTING
                tempcol(0) = "CASTING_ITEMID"
                tempval(0) = MERGENAMEID
                modify("CASTING", tempcol, tempval, " WHERE CASTING_ITEMID = " & OLDNAMEID)


                'CUSTOMERWASTAGE
                tempcol(0) = "ledgerid"
                tempval(0) = MERGENAMEID
                modify("CUSTOMERWASTAGE", tempcol, tempval, " WHERE ledgerid = " & OLDNAMEID)


                'FILLING
                tempcol(0) = "FILLING_LEDGERID"
                tempval(0) = MERGENAMEID
                modify("FILLING", tempcol, tempval, " WHERE FILLING_LEDGERID = " & OLDNAMEID)


                'JOURNALNMASTER
                tempcol(0) = "JV_LEDGERID"
                tempval(0) = MERGENAMEID
                modify("JOURNALMASTER", tempcol, tempval, " WHERE JV_LEDGERID = " & OLDNAMEID)


                'JOURNALNMASTER
                tempcol(0) = "JV_TOLEDGERID"
                tempval(0) = MERGENAMEID
                modify("JOURNALMASTER", tempcol, tempval, " WHERE JV_TOLEDGERID = " & OLDNAMEID)


                'KARIGARISSUE
                tempcol(0) = "mfg_ledgerid"
                tempval(0) = MERGENAMEID
                modify("KARIGARISSUE", tempcol, tempval, " WHERE mfg_ledgerid = " & OLDNAMEID)


                'KARIGARLOSSDETAILS
                tempcol(0) = "LEDGERID"
                tempval(0) = MERGENAMEID
                modify("KARIGARLOSSDETAILS", tempcol, tempval, " WHERE LEDGERID = " & OLDNAMEID)


                'LABOURDETAILS
                tempcol(0) = "LEDGERID"
                tempval(0) = MERGENAMEID
                modify("LABOURDETAILS", tempcol, tempval, " WHERE LEDGERID = " & OLDNAMEID)


                'LABREPORT
                tempcol(0) = "LAB_LEDGERID"
                tempval(0) = MERGENAMEID
                modify("LABREPORT", tempcol, tempval, " WHERE LAB_LEDGERID = " & OLDNAMEID)


                'LEDGERSUMM
                tempcol(0) = "ledgersum_ledgerid"
                tempval(0) = MERGENAMEID
                modify("LEDGERSUMM", tempcol, tempval, " WHERE ledgersum_ledgerid = " & OLDNAMEID)


                'ORDERMASTER
                tempcol(0) = "ORDER_LEDGERID"
                tempval(0) = MERGENAMEID
                modify("ORDERMASTER", tempcol, tempval, " WHERE ORDER_LEDGERID = " & OLDNAMEID)


                'ORDERREC
                tempcol(0) = "REC_LEDGERID"
                tempval(0) = MERGENAMEID
                modify("ORDERREC", tempcol, tempval, " WHERE REC_LEDGERID = " & OLDNAMEID)


                'ORDERRETURN
                tempcol(0) = "RETURN_LEDGERID"
                tempval(0) = MERGENAMEID
                modify("ORDERRETURN", tempcol, tempval, " WHERE RETURN_LEDGERID = " & OLDNAMEID)


                'PROCESSMASTER
                tempcol(0) = "process_ledgerid"
                tempval(0) = MERGENAMEID
                modify("PROCESSMASTER", tempcol, tempval, " WHERE process_ledgerid = " & OLDNAMEID)


                'SALARYENTRY
                tempcol(0) = "SAL_TOLEDGERID"
                tempval(0) = MERGENAMEID
                modify("SALARYENTRY", tempcol, tempval, " WHERE SAL_TOLEDGERID = " & OLDNAMEID)


                'SETTING
                tempcol(0) = "SETTING_LEDGERID"
                tempval(0) = MERGENAMEID
                modify("SETTING", tempcol, tempval, " WHERE SETTING_LEDGERID = " & OLDNAMEID)



                'VOUCHERS
                tempcol(0) = "VOUCHER_LEDGERID"
                tempval(0) = MERGENAMEID
                modify("VOUCHERS", tempcol, tempval, " WHERE VOUCHER_LEDGERID = " & OLDNAMEID)


                'AFTER THIS DELETE THE LEDGER FROM LEDGERMASTER
                cmd = New OleDbCommand("delete from LEDGERMASTER where LEDGER_ID = " & OLDNAMEID, conn)
                If conn.State = ConnectionState.Open Then conn.Close()
                conn.Open()
                cmd.ExecuteNonQuery()

            ElseIf CMBPARAMETER.Text = "ITEMNAME" Then


                'getting OLDNAMEID
                tempcmd = New OleDbCommand("select item_id from itemmaster where item_code = '" & CMBOLDNAME.Text.Trim & "'", tempconn)
                If tempconn.State = ConnectionState.Open Then tempconn.Close()
                tempconn.Open()
                tempdr = tempcmd.ExecuteReader
                If tempdr.HasRows Then
                    tempdr.Read()
                    OLDNAMEID = Val(tempdr(0))
                End If
                tempconn.Close()
                tempdr.Close()

                'GETTING MERGENAMEID
                tempcmd = New OleDbCommand("select item_id from itemmaster where item_code = '" & CMBMERGENAME.Text.Trim & "'", tempconn)
                If tempconn.State = ConnectionState.Open Then tempconn.Close()
                tempconn.Open()
                tempdr = tempcmd.ExecuteReader
                If tempdr.HasRows Then
                    tempdr.Read()
                    MERGENAMEID = Val(tempdr(0))
                End If
                tempconn.Close()
                tempdr.Close()



                'we need to MERGE ITEM IN EVERY TABLE
                'ACCOUNTMASTER
                tempcol(0) = "ACCOUNT_ITEMID"
                tempval(0) = MERGENAMEID
                modify("ACCOUNTMASTER", tempcol, tempval, " WHERE ACCOUNT_ITEMID = " & OLDNAMEID)


                'BHAVCUTMASTER
                tempcol(0) = "BHAVCUT_ITEMID"
                tempval(0) = MERGENAMEID
                modify("BHAVCUTMASTER", tempcol, tempval, " WHERE BHAVCUT_ITEMID = " & OLDNAMEID)


                'CASTING
                tempcol(0) = "CASTING_ITEMID"
                tempval(0) = MERGENAMEID
                modify("CASTING", tempcol, tempval, " WHERE CASTING_ITEMID = " & OLDNAMEID)


                'CUSTOMERWASTAGE
                tempcol(0) = "OLDNAMEID"
                tempval(0) = MERGENAMEID
                modify("CUSTOMERWASTAGE", tempcol, tempval, " WHERE OLDNAMEID = " & OLDNAMEID)


                'FILLING
                tempcol(0) = "FILLING_ITEMID"
                tempval(0) = MERGENAMEID
                modify("FILLING", tempcol, tempval, " WHERE FILLING_ITEMID = " & OLDNAMEID)


                'INVOICEDESCRIPTION
                tempcol(0) = "INVOICE_ITEMID"
                tempval(0) = MERGENAMEID
                modify("INVOICEDESCRIPTION", tempcol, tempval, " WHERE INVOICE_ITEMID = " & OLDNAMEID)


                'ITEMSTOCK
                tempcol(0) = "ITEM_ID"
                tempval(0) = MERGENAMEID
                modify("ITEMSTOCK", tempcol, tempval, " WHERE ITEM_ID = " & OLDNAMEID)


                'JOURNALNMASTER
                tempcol(0) = "JV_ITEMID"
                tempval(0) = MERGENAMEID
                modify("JOURNALMASTER", tempcol, tempval, " WHERE JV_ITEMID = " & OLDNAMEID)


                'KARIGARISSUE
                tempcol(0) = "MFG_ITEMID"
                tempval(0) = MERGENAMEID
                modify("KARIGARISSUE", tempcol, tempval, " WHERE MFG_ITEMID = " & OLDNAMEID)


                'KARIGARLOSSDETAILS
                tempcol(0) = "ITEMID"
                tempval(0) = MERGENAMEID
                modify("KARIGARLOSSDETAILS", tempcol, tempval, " WHERE ITEMID = " & OLDNAMEID)


                'LABELLING
                tempcol(0) = "LABEL_ITEMID"
                tempval(0) = MERGENAMEID
                modify("LABELLING", tempcol, tempval, " WHERE LABEL_ITEMID = " & OLDNAMEID)


                'LOTFAIL
                tempcol(0) = "MFG_ITEMID"
                tempval(0) = MERGENAMEID
                modify("LOTFAIL", tempcol, tempval, " WHERE MFG_ITEMID = " & OLDNAMEID)


                'MELTINGMASTER
                tempcol(0) = "MELTING_ITEMID"
                tempval(0) = MERGENAMEID
                modify("MELTINGMASTER", tempcol, tempval, " WHERE MELTING_ITEMID = " & OLDNAMEID)


                'ORDERMASTER
                tempcol(0) = "ORDER_ITEMID"
                tempval(0) = MERGENAMEID
                modify("ORDERMASTER", tempcol, tempval, " WHERE ORDER_ITEMID = " & OLDNAMEID)


                'ORDERREC
                tempcol(0) = "REC_ITEMID"
                tempval(0) = MERGENAMEID
                modify("ORDERREC", tempcol, tempval, " WHERE REC_ITEMID = " & OLDNAMEID)


                'ORDERRETURN
                tempcol(0) = "RETURN_ITEMID"
                tempval(0) = MERGENAMEID
                modify("ORDERRETURN", tempcol, tempval, " WHERE RETURN_ITEMID = " & OLDNAMEID)


                'PREPOLISH
                tempcol(0) = "PREPOLISH_ITEMID"
                tempval(0) = MERGENAMEID
                modify("PREPOLISH", tempcol, tempval, " WHERE PREPOLISH_ITEMID = " & OLDNAMEID)


                'RECIEPTDESCRIPTION
                tempcol(0) = "RECIEPT_ITEMID"
                tempval(0) = MERGENAMEID
                modify("RECIEPTDESCRIPTION", tempcol, tempval, " WHERE RECIEPT_ITEMID = " & OLDNAMEID)


                'SETTING
                tempcol(0) = "SETTING_ITEMID"
                tempval(0) = MERGENAMEID
                modify("SETTING", tempcol, tempval, " WHERE SETTING_ITEMID = " & OLDNAMEID)


                'STOCKTRANSFER
                tempcol(0) = "ST_ITEMID"
                tempval(0) = MERGENAMEID
                modify("STOCKTRANSFER", tempcol, tempval, " WHERE ST_ITEMID = " & OLDNAMEID)


                'VOUCHERS
                tempcol(0) = "VOUCHER_ITEMID"
                tempval(0) = MERGENAMEID
                modify("VOUCHERS", tempcol, tempval, " WHERE VOUCHER_ITEMID = " & OLDNAMEID)


                'AFTER THIS DELETE THE ITEM FROM ITEMMASTER
                cmd = New OleDbCommand("delete from ITEMMASTER where ITEM_ID = " & OLDNAMEID, conn)
                If conn.State = ConnectionState.Open Then conn.Close()
                conn.Open()
                cmd.ExecuteNonQuery()


            End If

            MsgBox("Data Merged Successfully")

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Function ERRORVALID() As Boolean
        Try
            Dim BLN As Boolean = True

            If CMBPARAMETER.Text.Trim = "" Then
                EP.SetError(CMBPARAMETER, "Select Parameter")
                BLN = False
            End If

            If CMBOLDNAME.Text.Trim = "" Then
                EP.SetError(CMBOLDNAME, "Enter Name to Merge")
                BLN = False
            End If

            If CMBMERGENAME.Text.Trim = "" Then
                EP.SetError(CMBMERGENAME, "Enter Name to Merge")
                BLN = False
            End If

            If LCase(CMBOLDNAME.Text.Trim) = LCase(CMBMERGENAME.Text.Trim) Then
                EP.SetError(CMBOLDNAME, "Invalid Selection")
                BLN = False
            End If

            Return BLN
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Sub clear()
        CMBPARAMETER.SelectedIndex = -1
        CMBOLDNAME.Text = ""
        CMBMERGENAME.Text = ""
        EP.Clear()
    End Sub

    Private Sub cmdclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        clear()
        CMBPARAMETER.Focus()
    End Sub

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub MergeItem_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                Me.Close()
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub MergeItem_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            CMBPARAMETER.SelectedIndex = -1
            CMBOLDNAME.Text = ""
            CMBMERGENAME.Text = ""
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPARAMETER_Validated(sender As Object, e As EventArgs) Handles CMBPARAMETER.Validated
        Try
            If CMBPARAMETER.Text = "LEDGER" Then
                fillname(Me, CMBOLDNAME, "")
                fillname(Me, CMBMERGENAME, "")
            ElseIf CMBPARAMETER.Text = "ITEMNAME" Then
                FILLITEMCODE(Me, CMBOLDNAME, "")
                FILLITEMCODE(Me, CMBMERGENAME, "")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class