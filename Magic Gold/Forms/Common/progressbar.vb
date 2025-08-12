Imports System.Data.oledb

Public Class progressbar

    Dim tempcmd, cmd As oledbcommand
    Dim tempdr, dr As oledbDataReader
    Dim i As Integer 'for loop

    Private Sub progressbar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        openconn(tempcmpname)
        'openconn("MagicGold")
        bar.Step = 1

        'getting cmpid
        tempcmd = New oledbcommand("select cmp_no from cmpmaster where cmp_name ='" & tempcmpname & "'", tempconn)
        If tempconn.State = ConnectionState.Open Then
            tempconn.Close()
        End If
        tempconn.Open()
        tempdr = tempcmd.ExecuteReader
        If tempdr.HasRows = True Then
            tempdr.Read()
            tempcmpid = tempdr(0).ToString
        End If

        'getting yearid
        tempcmd = New OleDbCommand("select year_id from yearmaster where year_cmpno = " & tempcmpid, tempconn)
        If tempconn.State = ConnectionState.Open Then
            tempconn.Close()
        End If
        tempconn.Open()
        tempdr = tempcmd.ExecuteReader
        If tempdr.HasRows = True Then
            tempdr.Read()
            tempyearid = tempdr(0).ToString
        End If

        createaccounts()

    End Sub

    Sub createaccounts()

        For i = 0 To 100
            tempcol(i) = ""
            tempval(i) = ""
        Next

        'creating fixed groups in groupmaster with cmpid and yearid
        tempcol(0) = "group_type"
        tempcol(1) = "group_name"
        tempcol(2) = "group_under"
        tempcol(3) = "group_userid"


        '****** BANK A/C ******
        tempval(0) = "'Assets'"
        tempval(1) = "'Bank A/C'"
        tempval(2) = "'Current Assets'"
        tempval(3) = "'" & tempuserid & "'"

        insert("groupmaster", tempcol, tempval)


        '****** BANK OD A/C ******
        tempval(0) = "'Liability'"
        tempval(1) = "'Bank OD A/C'"
        tempval(2) = "'Loans'"

        insert("groupmaster", tempcol, tempval)


        '****** Capital A/C ******
        tempval(0) = "'Liability'"
        tempval(1) = "'Capital A/C'"
        tempval(2) = "'Liability'"

        insert("groupmaster", tempcol, tempval)


        '****** Cash In Hand ******
        tempval(0) = "'Assets'"
        tempval(1) = "'Cash In Hand'"
        tempval(2) = "'Current Assets'"

        insert("groupmaster", tempcol, tempval)


        '****** Current Assets ******
        tempval(0) = "'Assets'"
        tempval(1) = "'Current Assets'"
        tempval(2) = "'Assets'"

        insert("groupmaster", tempcol, tempval)


        '****** Current Liabilities ******
        tempval(0) = "'liability'"
        tempval(1) = "'Current Liabilities'"
        tempval(2) = "'Liability'"

        insert("groupmaster", tempcol, tempval)


        '****** Direct Expenses ******
        tempval(0) = "'Expenses'"
        tempval(1) = "'Direct Expenses'"
        tempval(2) = "'Expenses'"

        insert("groupmaster", tempcol, tempval)


        '****** Direct Income ******
        tempval(0) = "'Income'"
        tempval(1) = "'Direct Income'"
        tempval(2) = "'Income'"

        insert("groupmaster", tempcol, tempval)



        '****** Duties & Taxes ******
        tempval(0) = "'Liability'"
        tempval(1) = "'Duties & Taxes'"
        tempval(2) = "'Current Liabilities'"

        insert("groupmaster", tempcol, tempval)


        '****** Indirect Expenses ******
        tempval(0) = "'Expenses'"
        tempval(1) = "'Indirect Expenses'"
        tempval(2) = "'Expenses'"

        insert("groupmaster", tempcol, tempval)



        '****** Loan & Advances ******
        tempval(0) = "'Assets'"
        tempval(1) = "'Loan & Advances'"
        tempval(2) = "'Current Assets'"

        insert("groupmaster", tempcol, tempval)


        '****** Loans ******
        tempval(0) = "'Liability'"
        tempval(1) = "'Loans'"
        tempval(2) = "'Liability'"

        insert("groupmaster", tempcol, tempval)


        '****** Purchase A/C ******
        tempval(0) = "'Expenses'"
        tempval(1) = "'Purchase A/C'"
        tempval(2) = "'Expenses'"

        insert("groupmaster", tempcol, tempval)


        '****** Sales A/C ******
        tempval(0) = "'Income'"
        tempval(1) = "'Sales A/C'"
        tempval(2) = "'Income'"

        insert("groupmaster", tempcol, tempval)


        '****** Stock In Hand ******
        tempval(0) = "'Assets'"
        tempval(1) = "'Stock In Hand'"
        tempval(2) = "'Current Assets'"

        insert("groupmaster", tempcol, tempval)


        '****** Sundry Creditors ******
        tempval(0) = "'Liability'"
        tempval(1) = "'Sundry Creditors'"
        tempval(2) = "'Current Liabilities'"

        insert("groupmaster", tempcol, tempval)


        '****** Sundry Debtors ******
        tempval(0) = "'Assets'"
        tempval(1) = "'Sundry Debtors'"
        tempval(2) = "'Current Assets'"

        insert("groupmaster", tempcol, tempval)


        '****** Indirect Income ******
        tempval(0) = "'Income'"
        tempval(1) = "'Indirect Income'"
        tempval(2) = "'Income'"

        insert("groupmaster", tempcol, tempval)



        For i = 0 To 100
            tempcol(i) = ""
            tempval(i) = ""
        Next

        'creating  1 fixed itemtype as GOLD
        tempcol(0) = "type_name"
        tempcol(1) = "type_userid"

        tempval(0) = "'GOLD'"
        tempval(1) = tempuserid

        insert("typemaster", tempcol, tempval)




        For i = 0 To 100
            tempcol(i) = ""
            tempval(i) = ""
        Next

        'creating  1 fixed category as METAL
        tempcol(0) = "category_name"
        tempcol(1) = "category_userid"

        tempval(0) = "'METAL'"
        tempval(1) = tempuserid

        insert("categorymaster", tempcol, tempval)





        For i = 0 To 100
            tempcol(i) = ""
            tempval(i) = ""
        Next

        'creating  1 fixed item as BAR
        tempcol(0) = "item_name"
        tempcol(1) = "item_code"
        tempcol(2) = "item_typeid"
        tempcol(3) = "item_categoryid"
        tempcol(4) = "item_rate"
        tempcol(5) = "item_imagepath"
        tempcol(6) = "item_userid"


        tempval(0) = "'BAR'"
        tempval(1) = "'BAR'"

        'getting typeid as GOLD
        tempcmd = New OleDbCommand("select type_id from typemaster where type_name = 'GOLD'", tempconn)
        If tempconn.State = ConnectionState.Open Then
            tempconn.Close()
        End If
        tempconn.Open()
        tempdr = tempcmd.ExecuteReader
        If tempdr.HasRows = True Then
            tempdr.Read()
            tempval(2) = tempdr(0)
        End If

        'getting categoryid as METAL
        tempcmd = New OleDbCommand("select category_id from categorymaster where category_name = 'METAL'", tempconn)
        If tempconn.State = ConnectionState.Open Then
            tempconn.Close()
        End If
        tempconn.Open()
        tempdr = tempcmd.ExecuteReader
        If tempdr.HasRows = True Then
            tempdr.Read()
            tempval(3) = tempdr(0)
        End If

        tempval(4) = 0
        tempval(5) = "''"
        tempval(6) = tempuserid

        insert("itemmaster", tempcol, tempval)






        For i = 0 To 100
            tempcol(i) = ""
            tempval(i) = ""
        Next

        'creating 9 fixed ledgers in ledgermaster with cmpid and yearid
        tempcol(0) = "ledger_name"
        tempcol(1) = "ledger_code"
        tempcol(2) = "ledger_groupid"
        tempcol(3) = "ledger_userid"
        tempcol(4) = "ledger_settlement"
        


        '****** Other Charges ******
        tempval(0) = "'Other Charges'"
        tempval(1) = "'Other Charges'"

        'getting groupid as Direct Expenses
        tempcmd = New OleDbCommand("select group_id from groupmaster where group_name = 'Direct Expenses'", tempconn)
        If tempconn.State = ConnectionState.Open Then
            tempconn.Close()
        End If
        tempconn.Open()
        tempdr = tempcmd.ExecuteReader
        If tempdr.HasRows = True Then
            tempdr.Read()
            tempval(2) = "'" & tempdr(0).ToString & "'"
        End If

        tempval(3) = "'" & tempuserid & "'"
        tempval(4) = "'01/01/2016'"
        insert("ledgermaster", tempcol, tempval)



        '****** SALARY ******
        tempval(0) = "'SALARY'"
        tempval(1) = "'SALARY'"

        'getting groupid as Indirect Expenses
        tempcmd = New OleDbCommand("select group_id from groupmaster where group_name = 'Indirect Expenses' ", tempconn)
        If tempconn.State = ConnectionState.Open Then
            tempconn.Close()
        End If
        tempconn.Open()
        tempdr = tempcmd.ExecuteReader
        If tempdr.HasRows = True Then
            tempdr.Read()
            tempval(2) = "'" & tempdr(0).ToString & "'"
        End If

        insert("ledgermaster", tempcol, tempval)


        '****** SALE ******
        tempval(0) = "'SALE'"
        tempval(1) = "'SALE'"

        'getting groupid as sale a/c
        tempcmd = New OleDbCommand("select group_id from groupmaster where group_name = 'Sales A/C' ", tempconn)
        If tempconn.State = ConnectionState.Open Then
            tempconn.Close()
        End If
        tempconn.Open()
        tempdr = tempcmd.ExecuteReader
        If tempdr.HasRows = True Then
            tempdr.Read()
            tempval(2) = "'" & tempdr(0).ToString & "'"
        End If

        insert("ledgermaster", tempcol, tempval)


        '****** PURCHASE ******
        tempval(0) = "'PURCHASE'"
        tempval(1) = "'PURCHASE'"

        'getting groupid as Purchase A/c
        tempcmd = New OleDbCommand("select group_id from groupmaster where group_name = 'Purchase A/C' ", tempconn)
        If tempconn.State = ConnectionState.Open Then
            tempconn.Close()
        End If
        tempconn.Open()
        tempdr = tempcmd.ExecuteReader
        If tempdr.HasRows = True Then
            tempdr.Read()
            tempval(2) = "'" & tempdr(0).ToString & "'"
        End If

        insert("ledgermaster", tempcol, tempval)



        '****** Labour Charges Paid ******
        tempval(0) = "'Labour Charges Paid'"
        tempval(1) = "'Labour Charges Paid'"

        'getting groupid as Direct Expenses
        tempcmd = New OleDbCommand("select group_id from groupmaster where group_name = 'Indirect Expenses' ", tempconn)
        If tempconn.State = ConnectionState.Open Then
            tempconn.Close()
        End If
        tempconn.Open()
        tempdr = tempcmd.ExecuteReader
        If tempdr.HasRows = True Then
            tempdr.Read()
            tempval(2) = "'" & tempdr(0).ToString & "'"
        End If

        tempval(3) = "'" & tempuserid & "'"

        insert("ledgermaster", tempcol, tempval)



        '****** Labour Charges Received ******
        tempval(0) = "'Labour Charges Received'"
        tempval(1) = "'Labour Charges Received'"

        'getting groupid as Direct Expenses
        tempcmd = New OleDbCommand("select group_id from groupmaster where group_name = 'Indirect Income' ", tempconn)
        If tempconn.State = ConnectionState.Open Then
            tempconn.Close()
        End If
        tempconn.Open()
        tempdr = tempcmd.ExecuteReader
        If tempdr.HasRows = True Then
            tempdr.Read()
            tempval(2) = "'" & tempdr(0).ToString & "'"
        End If

        tempval(3) = "'" & tempuserid & "'"

        insert("ledgermaster", tempcol, tempval)



        '****** LOSS AC ******
        tempval(0) = "'LOSS AC'"
        tempval(1) = "'LOSS AC'"

        'getting groupid as Direct Expenses
        tempcmd = New OleDbCommand("select group_id from groupmaster where group_name = 'Sundry Creditors' ", tempconn)
        If tempconn.State = ConnectionState.Open Then
            tempconn.Close()
        End If
        tempconn.Open()
        tempdr = tempcmd.ExecuteReader
        If tempdr.HasRows = True Then
            tempdr.Read()
            tempval(2) = "'" & tempdr(0).ToString & "'"
        End If

        tempval(3) = "'" & tempuserid & "'"

        insert("ledgermaster", tempcol, tempval)


        '****** SAMPLE AC ******
        tempval(0) = "'SAMPLE AC'"
        tempval(1) = "'SAMPLE AC'"

        'getting groupid as Direct Expenses
        tempcmd = New OleDbCommand("select group_id from groupmaster where group_name = 'Sundry Creditors' ", tempconn)
        If tempconn.State = ConnectionState.Open Then
            tempconn.Close()
        End If
        tempconn.Open()
        tempdr = tempcmd.ExecuteReader
        If tempdr.HasRows = True Then
            tempdr.Read()
            tempval(2) = "'" & tempdr(0).ToString & "'"
        End If

        tempval(3) = "'" & tempuserid & "'"

        insert("ledgermaster", tempcol, tempval)



        '****** VACCUM AC ******
        tempval(0) = "'VACCUM AC'"
        tempval(1) = "'VACCUM AC'"

        'getting groupid as Direct Expenses
        tempcmd = New OleDbCommand("select group_id from groupmaster where group_name = 'Sundry Creditors' ", tempconn)
        If tempconn.State = ConnectionState.Open Then
            tempconn.Close()
        End If
        tempconn.Open()
        tempdr = tempcmd.ExecuteReader
        If tempdr.HasRows = True Then
            tempdr.Read()
            tempval(2) = "'" & tempdr(0).ToString & "'"
        End If

        tempval(3) = "'" & tempuserid & "'"

        insert("ledgermaster", tempcol, tempval)



        '****** CASH ******
        tempval(0) = "'CASH'"
        tempval(1) = "'CASH'"

        'getting groupid as sale a/c
        tempcmd = New OleDbCommand("select group_id from groupmaster where group_name = 'Cash In Hand' ", tempconn)
        If tempconn.State = ConnectionState.Open Then
            tempconn.Close()
        End If
        tempconn.Open()
        tempdr = tempcmd.ExecuteReader
        If tempdr.HasRows = True Then
            tempdr.Read()
            tempval(2) = "'" & tempdr(0).ToString & "'"
        End If

        insert("ledgermaster", tempcol, tempval)



        '****** STONE ******
        tempval(0) = "'STONE'"
        tempval(1) = "'STONE'"

        'getting groupid as sale a/c
        tempcmd = New OleDbCommand("select group_id from groupmaster where group_name = 'Sundry Creditors' ", tempconn)
        If tempconn.State = ConnectionState.Open Then
            tempconn.Close()
        End If
        tempconn.Open()
        tempdr = tempcmd.ExecuteReader
        If tempdr.HasRows = True Then
            tempdr.Read()
            tempval(2) = "'" & tempdr(0).ToString & "'"
        End If

        insert("ledgermaster", tempcol, tempval)

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If bar.Value <= 20 Then
            Timer1.Interval = 100
            lbl.Text = "Creating Database....."
        ElseIf bar.Value <= 50 Then
            Timer1.Interval = 50
            lbl.Text = "Importing Books....."
        ElseIf bar.Value <= 80 Then
            Timer1.Interval = 100
            lbl.Text = "Importing Masters....."
        Else
            lbl.Text = "Please Wait....."
        End If

        If bar.Value = 100 Then
            Me.Close()
        End If
        bar.PerformStep()
    End Sub
End Class