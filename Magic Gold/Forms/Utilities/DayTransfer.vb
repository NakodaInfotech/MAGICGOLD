
Imports System.Data.OleDb

Public Class DayTransfer

    Private Sub CMDEXIT_Click(sender As Object, e As EventArgs) Handles CMDEXIT.Click
        Me.Close()
    End Sub

    Private Sub CMDB2BUPLOAD_Click(sender As Object, e As EventArgs) Handles CMDB2BUPLOAD.Click
        Try
            OpenFileDialog1.Filter = "Access (*.accdb;*.mdb)|*.accdb;*.mdb"
            OpenFileDialog1.ShowDialog()

            OpenFileDialog1.AddExtension = True
            TXTFILENAME.Text = OpenFileDialog1.SafeFileName
            TXTPATH.Text = OpenFileDialog1.FileName
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDTRANSFER_Click(sender As Object, e As EventArgs) Handles CMDTRANSFER.Click
        Try
            If MsgBox("Wish To Transfer Data to Master Pen?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

            Dim OBJPASS As New EnterPassword
            OBJPASS.ShowDialog()
            If OBJPASS.BLN = False Then
                MsgBox("Invalid Password", MsgBoxStyle.Critical)
                Exit Sub
            End If


            'THIS IS MASTER PEN CONNECTION
            Dim MASTERCONN As New OleDbConnection
            If MASTERCONN.State = ConnectionState.Open Then
                MASTERCONN.Close()
            End If
            MASTERCONN.ConnectionString = ("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & TXTPATH.Text.Trim & ";Jet OLEDB:Database Password= 1902")
            MASTERCONN.Open()


            'WE WILL FETCH ALL THE MASTERS FROM MASTERPEN AND INSERT IN CURRENT DAYPEN
            '********* TRANSFERRING DATA ***********
            Dim dt As New DataTable()
            Dim dt1 As New DataTable()


            'AREAMASTER
            'FIRST CHECK THE LAST AREAID IN DAY PEN 
            Dim TEMPID As Integer = 0
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Open()
            tempcmd = New OleDbCommand("SELECT MAX(AREAMASTER.AREA_ID) AS AREAID FROM AREAMASTER ", conn)
            da = New OleDbDataAdapter(tempcmd)
            da.Fill(dt1)
            If dt1.Rows.Count = 0 Then TEMPID = Val(dt1.Rows(0).Item("AREAID"))



            If MASTERCONN.State = ConnectionState.Open Then MASTERCONN.Close()
            MASTERCONN.Open()
            cmd = New OleDbCommand("SELECT AREAMASTER.AREA_NAME AS AREA FROM AREAMASTER WHERE AREA_ID > " & TEMPID, MASTERCONN)
            da = New OleDbDataAdapter(cmd)
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For Each DTROW As DataRow In dt.Rows

                    dt1.Clear()
                    'CHECKING WHETHER AREA IS PRESENT IN CURRENT COMPANY OR NOT
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Open()
                    tempcmd = New OleDbCommand("SELECT AREAMASTER.AREA_NAME AS AREA FROM AREAMASTER WHERE AREAMASTER.AREA_NAME = '" & DTROW("AREA") & "'", conn)
                    da = New OleDbDataAdapter(tempcmd)
                    da.Fill(dt1)
                    If dt1.Rows.Count = 0 Then

                        For i = 1 To 50
                            tempcol(i) = ""
                            tempval(i) = ""
                        Next

                        'ADD NEW 
                        tempcol(0) = "area_name"
                        tempcol(1) = "area_userid"

                        tempval(0) = "'" & DTROW("AREA") & "'"
                        tempval(1) = tempuserid
                        insert("areamaster", tempcol, tempval)
                    End If
                    conn.Close()
                    tempcmd.Dispose()
                Next
            End If
            MASTERCONN.Close()
            cmd.Dispose()






            'CATEGORYMASTER
            'FIRST CHECK THE LAST CATEGORYID IN DAY PEN 
            dt.Clear()
            dt1.Clear()
            TEMPID = 0
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Open()
            tempcmd = New OleDbCommand("SELECT MAX(CATEGORYMASTER.CATEGORY_ID) AS CATEGORYID FROM CATEGORYMASTER ", conn)
            da = New OleDbDataAdapter(tempcmd)
            da.Fill(dt1)
            If dt1.Rows.Count = 0 Then TEMPID = Val(dt1.Rows(0).Item("CATEGORYID"))



            If MASTERCONN.State = ConnectionState.Open Then MASTERCONN.Close()
            MASTERCONN.Open()
            cmd = New OleDbCommand("SELECT CATEGORYMASTER.CATEGORY_NAME AS CATEGORY FROM CATEGORYMASTER WHERE CATEGORY_ID > " & TEMPID, MASTERCONN)
            da = New OleDbDataAdapter(cmd)
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For Each DTROW As DataRow In dt.Rows

                    dt1.Clear()
                    'CHECKING WHETHER CATEGORY IS PRESENT IN CURRENT COMPANY OR NOT
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Open()
                    tempcmd = New OleDbCommand("SELECT CATEGORYMASTER.CATEGORY_NAME AS CATEGORY FROM CATEGORYMASTER WHERE CATEGORYMASTER.CATEGORY_NAME = '" & DTROW("CATEGORY") & "'", conn)
                    da = New OleDbDataAdapter(tempcmd)
                    da.Fill(dt1)
                    If dt1.Rows.Count = 0 Then

                        For i = 1 To 50
                            tempcol(i) = ""
                            tempval(i) = ""
                        Next

                        'ADD NEW 
                        tempcol(0) = "CATEGORY_name"
                        tempcol(1) = "CATEGORY_userid"

                        tempval(0) = "'" & DTROW("CATEGORY") & "'"
                        tempval(1) = tempuserid
                        insert("CATEGORYMASTER", tempcol, tempval)
                    End If
                    conn.Close()
                    tempcmd.Dispose()
                Next
            End If
            MASTERCONN.Close()
            cmd.Dispose()





            'CITYMASTER
            'FIRST CHECK THE LAST CITYID IN DAY PEN 
            dt.Clear()
            dt1.Clear()
            TEMPID = 0
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Open()
            tempcmd = New OleDbCommand("SELECT MAX(CITYMASTER.CITY_ID) AS CITYID FROM CITYMASTER ", conn)
            da = New OleDbDataAdapter(tempcmd)
            da.Fill(dt1)
            If dt1.Rows.Count = 0 Then TEMPID = Val(dt1.Rows(0).Item("CATEGORYID"))


            If MASTERCONN.State = ConnectionState.Open Then MASTERCONN.Close()
            MASTERCONN.Open()
            cmd = New OleDbCommand("SELECT CITYMASTER.CITY_NAME AS CITY FROM CITYMASTER WHERE CITY_ID > " & TEMPID, MASTERCONN)
            da = New OleDbDataAdapter(cmd)
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For Each DTROW As DataRow In dt.Rows

                    dt1.Clear()
                    'CHECKING WHETHER CITY IS PRESENT IN CURRENT COMPANY OR NOT
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Open()
                    tempcmd = New OleDbCommand("SELECT CITYMASTER.CITY_NAME AS CITY FROM CITYMASTER WHERE CITYMASTER.CITY_NAME = '" & DTROW("CITY") & "'", conn)
                    da = New OleDbDataAdapter(tempcmd)
                    da.Fill(dt1)
                    If dt1.Rows.Count = 0 Then

                        For i = 1 To 50
                            tempcol(i) = ""
                            tempval(i) = ""
                        Next

                        'ADD NEW 
                        tempcol(0) = "CITY_name"
                        tempcol(1) = "CITY_userid"

                        tempval(0) = "'" & DTROW("CITY") & "'"
                        tempval(1) = tempuserid
                        insert("CITYMASTER", tempcol, tempval)
                    End If
                    conn.Close()
                    tempcmd.Dispose()
                Next
            End If
            MASTERCONN.Close()
            cmd.Dispose()






            'COUNTRYMASTER
            'FIRST CHECK THE LAST CUONTRYID IN DAY PEN 
            dt.Clear()
            dt1.Clear()
            TEMPID = 0
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Open()
            tempcmd = New OleDbCommand("SELECT MAX(COUNTRYMASTER.COUNTRY_ID) AS COUNTRYID FROM COUNTRYMASTER ", conn)
            da = New OleDbDataAdapter(tempcmd)
            da.Fill(dt1)
            If dt1.Rows.Count = 0 Then TEMPID = Val(dt1.Rows(0).Item("COUNTRYID"))


            If MASTERCONN.State = ConnectionState.Open Then MASTERCONN.Close()
            MASTERCONN.Open()
            cmd = New OleDbCommand("SELECT COUNTRYMASTER.COUNTRY_NAME AS COUNTRY FROM COUNTRYMASTER WHERE COUNTRY_ID > " & TEMPID, MASTERCONN)
            da = New OleDbDataAdapter(cmd)
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For Each DTROW As DataRow In dt.Rows

                    dt1.Clear()
                    'CHECKING WHETHER COUNTRY IS PRESENT IN CURRENT COMPANY OR NOT
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Open()
                    tempcmd = New OleDbCommand("SELECT COUNTRYMASTER.COUNTRY_NAME AS COUNTRY FROM COUNTRYMASTER WHERE COUNTRYMASTER.COUNTRY_NAME = '" & DTROW("COUNTRY") & "'", conn)
                    da = New OleDbDataAdapter(tempcmd)
                    da.Fill(dt1)
                    If dt1.Rows.Count = 0 Then

                        For i = 1 To 50
                            tempcol(i) = ""
                            tempval(i) = ""
                        Next

                        'ADD NEW 
                        tempcol(0) = "COUNTRY_name"
                        tempcol(1) = "COUNTRY_userid"

                        tempval(0) = "'" & DTROW("COUNTRY") & "'"
                        tempval(1) = tempuserid
                        insert("COUNTRYMASTER", tempcol, tempval)
                    End If
                    conn.Close()
                    tempcmd.Dispose()
                Next
            End If
            MASTERCONN.Close()
            cmd.Dispose()






            'STATEMASTER
            'FIRST CHECK THE LAST STATEID IN DAY PEN 
            dt.Clear()
            dt1.Clear()
            TEMPID = 0
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Open()
            tempcmd = New OleDbCommand("SELECT MAX(STATEMASTER.STATE_ID) AS STATEID FROM STATEMASTER ", conn)
            da = New OleDbDataAdapter(tempcmd)
            da.Fill(dt1)
            If dt1.Rows.Count = 0 Then TEMPID = Val(dt1.Rows(0).Item("STATEID"))


            If MASTERCONN.State = ConnectionState.Open Then MASTERCONN.Close()
            MASTERCONN.Open()
            cmd = New OleDbCommand("SELECT STATEMASTER.STATE_NAME AS STATE FROM STATEMASTER WHERE STATE_ID > " & TEMPID, MASTERCONN)
            da = New OleDbDataAdapter(cmd)
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For Each DTROW As DataRow In dt.Rows

                    dt1.Clear()
                    'CHECKING WHETHER STATE IS PRESENT IN CURRENT COMPANY OR NOT
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Open()
                    tempcmd = New OleDbCommand("SELECT STATEMASTER.STATE_NAME AS STATE FROM STATEMASTER WHERE STATEMASTER.STATE_NAME = '" & DTROW("STATE") & "'", conn)
                    da = New OleDbDataAdapter(tempcmd)
                    da.Fill(dt1)
                    If dt1.Rows.Count = 0 Then

                        For i = 1 To 50
                            tempcol(i) = ""
                            tempval(i) = ""
                        Next

                        'ADD NEW 
                        tempcol(0) = "STATE_name"
                        tempcol(1) = "STATE_userid"

                        tempval(0) = "'" & DTROW("STATE") & "'"
                        tempval(1) = tempuserid
                        insert("STATEMASTER", tempcol, tempval)
                    End If
                    conn.Close()
                    tempcmd.Dispose()
                Next
            End If
            MASTERCONN.Close()
            cmd.Dispose()




            'TYPEMASTER
            'FIRST CHECK THE LAST TYPEID IN DAY PEN 
            dt.Clear()
            dt1.Clear()
            TEMPID = 0
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Open()
            tempcmd = New OleDbCommand("SELECT MAX(TYPEMASTER.TYPE_ID) AS TYPEID FROM TYPEMASTER ", conn)
            da = New OleDbDataAdapter(tempcmd)
            da.Fill(dt1)
            If dt1.Rows.Count = 0 Then TEMPID = Val(dt1.Rows(0).Item("TYPEID"))


            If MASTERCONN.State = ConnectionState.Open Then MASTERCONN.Close()
            MASTERCONN.Open()
            cmd = New OleDbCommand("SELECT TYPEMASTER.TYPE_NAME AS TYPE FROM TYPEMASTER WHERE TYPE_ID > " & TEMPID, MASTERCONN)
            da = New OleDbDataAdapter(cmd)
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For Each DTROW As DataRow In dt.Rows

                    dt1.Clear()
                    'CHECKING WHETHER TYPE IS PRESENT IN CURRENT COMPANY OR NOT
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Open()
                    tempcmd = New OleDbCommand("SELECT TYPEMASTER.TYPE_NAME AS TYPE FROM TYPEMASTER WHERE TYPEMASTER.TYPE_NAME = '" & DTROW("TYPE") & "'", conn)
                    da = New OleDbDataAdapter(tempcmd)
                    da.Fill(dt1)
                    If dt1.Rows.Count = 0 Then

                        For i = 1 To 50
                            tempcol(i) = ""
                            tempval(i) = ""
                        Next

                        'ADD NEW 
                        tempcol(0) = "TYPE_name"
                        tempcol(1) = "TYPE_userid"

                        tempval(0) = "'" & DTROW("TYPE") & "'"
                        tempval(1) = tempuserid
                        insert("TYPEMASTER", tempcol, tempval)
                    End If
                    conn.Close()
                    tempcmd.Dispose()
                Next
            End If
            MASTERCONN.Close()
            cmd.Dispose()





            'GROUPMASTER
            'FIRST CHECK THE LAST GROUPID IN DAY PEN 
            dt.Clear()
            dt1.Clear()
            TEMPID = 0
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Open()
            tempcmd = New OleDbCommand("SELECT MAX(GROUPMASTER.GROUP_ID) AS GROUPID FROM GROUPMASTER ", conn)
            da = New OleDbDataAdapter(tempcmd)
            da.Fill(dt1)
            If dt1.Rows.Count = 0 Then TEMPID = Val(dt1.Rows(0).Item("GROUPID"))


            If MASTERCONN.State = ConnectionState.Open Then MASTERCONN.Close()
            MASTERCONN.Open()
            cmd = New OleDbCommand("SELECT GROUPMASTER.GROUP_TYPE AS GROUPTYPE, GROUPMASTER.GROUP_NAME AS GROUPNAME, GROUPMASTER.GROUP_UNDER AS GROUPUNDER FROM GROUPMASTER WHERE GROUP_ID > " & TEMPID, MASTERCONN)
            da = New OleDbDataAdapter(cmd)
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For Each DTROW As DataRow In dt.Rows

                    dt1.Clear()
                    'CHECKING WHETHER GROUP IS PRESENT IN CURRENT COMPANY OR NOT
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Open()
                    tempcmd = New OleDbCommand("SELECT GROUPMASTER.GROUP_NAME AS GROUPNAME FROM GROUPMASTER WHERE GROUPMASTER.GROUP_NAME = '" & DTROW("GROUPNAME") & "'", conn)
                    da = New OleDbDataAdapter(tempcmd)
                    da.Fill(dt1)
                    If dt1.Rows.Count = 0 Then

                        For i = 1 To 50
                            tempcol(i) = ""
                            tempval(i) = ""
                        Next

                        'ADD NEW 
                        tempcol(0) = "GROUP_TYPE"
                        tempcol(1) = "GROUP_name"
                        tempcol(2) = "GROUP_UNDER"
                        tempcol(3) = "GROUP_userid"

                        tempval(0) = "'" & DTROW("GROUPTYPE") & "'"
                        tempval(1) = "'" & DTROW("GROUPNAME") & "'"
                        tempval(2) = "'" & DTROW("GROUPUNDER") & "'"
                        tempval(3) = tempuserid
                        insert("GROUPMASTER", tempcol, tempval)
                    End If
                    conn.Close()
                    tempcmd.Dispose()
                Next
            End If
            MASTERCONN.Close()
            cmd.Dispose()



            'SHAPEMASTER
            'FIRST CHECK THE LAST SHAPEID IN DAY PEN 
            dt.Clear()
            dt1.Clear()
            TEMPID = 0
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Open()
            tempcmd = New OleDbCommand("SELECT MAX(SHAPEMASTER.SHAPE_ID) AS SHAPEID FROM SHAPEMASTER ", conn)
            da = New OleDbDataAdapter(tempcmd)
            da.Fill(dt1)
            If dt1.Rows.Count = 0 Then TEMPID = Val(dt1.Rows(0).Item("SHAPEID"))


            If MASTERCONN.State = ConnectionState.Open Then MASTERCONN.Close()
            MASTERCONN.Open()
            cmd = New OleDbCommand("SELECT SHAPEMASTER.SHAPE_NAME AS SHAPE FROM SHAPEMASTER WHERE SHAPE_ID > " & TEMPID, MASTERCONN)
            da = New OleDbDataAdapter(cmd)
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For Each DTROW As DataRow In dt.Rows

                    dt1.Clear()
                    'CHECKING WHETHER SHAPE IS PRESENT IN CURRENT COMPANY OR NOT
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Open()
                    tempcmd = New OleDbCommand("SELECT SHAPEMASTER.SHAPE_NAME AS SHAPE FROM SHAPEMASTER WHERE SHAPEMASTER.SHAPE_NAME = '" & DTROW("SHAPE") & "'", conn)
                    da = New OleDbDataAdapter(tempcmd)
                    da.Fill(dt1)
                    If dt1.Rows.Count = 0 Then

                        For i = 1 To 50
                            tempcol(i) = ""
                            tempval(i) = ""
                        Next

                        'ADD NEW 
                        tempcol(0) = "SHAPE_name"
                        tempcol(1) = "SHAPE_userid"

                        tempval(0) = "'" & DTROW("SHAPE") & "'"
                        tempval(1) = tempuserid
                        insert("SHAPEMASTER", tempcol, tempval)
                    End If
                    conn.Close()
                    tempcmd.Dispose()
                Next
            End If
            MASTERCONN.Close()
            cmd.Dispose()



            'SIZEMASTER
            'FIRST CHECK THE LAST SIZEID IN DAY PEN 
            dt.Clear()
            dt1.Clear()
            TEMPID = 0
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Open()
            tempcmd = New OleDbCommand("SELECT MAX(SIZEMASTER.SIZE_ID) AS SIZEID FROM SIZEMASTER ", conn)
            da = New OleDbDataAdapter(tempcmd)
            da.Fill(dt1)
            If dt1.Rows.Count = 0 Then TEMPID = Val(dt1.Rows(0).Item("SIZEID"))


            If MASTERCONN.State = ConnectionState.Open Then MASTERCONN.Close()
            MASTERCONN.Open()
            cmd = New OleDbCommand("SELECT SIZEMASTER.SIZE_NAME AS [SIZE] FROM SIZEMASTER WHERE SIZE_ID > " & TEMPID, MASTERCONN)
            da = New OleDbDataAdapter(cmd)
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For Each DTROW As DataRow In dt.Rows

                    dt1.Clear()
                    'CHECKING WHETHER SIZE IS PRESENT IN CURRENT COMPANY OR NOT
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Open()
                    tempcmd = New OleDbCommand("SELECT SIZEMASTER.SIZE_NAME AS [SIZE] FROM SIZEMASTER WHERE SIZEMASTER.SIZE_NAME = '" & DTROW("SIZE") & "'", conn)
                    da = New OleDbDataAdapter(tempcmd)
                    da.Fill(dt1)
                    If dt1.Rows.Count = 0 Then

                        For i = 1 To 50
                            tempcol(i) = ""
                            tempval(i) = ""
                        Next

                        'ADD NEW 
                        tempcol(0) = "SIZE_name"
                        tempcol(1) = "SIZE_userid"

                        tempval(0) = "'" & DTROW("SIZE") & "'"
                        tempval(1) = tempuserid
                        insert("SIZEMASTER", tempcol, tempval)
                    End If
                    conn.Close()
                    tempcmd.Dispose()
                Next
            End If
            MASTERCONN.Close()
            cmd.Dispose()





            'COLORMASTER
            'FIRST CHECK THE LAST COLORID IN DAY PEN 
            dt.Clear()
            dt1.Clear()
            TEMPID = 0
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Open()
            tempcmd = New OleDbCommand("SELECT MAX(COLORMASTER.COLOR_ID) AS COLORID FROM COLORMASTER ", conn)
            da = New OleDbDataAdapter(tempcmd)
            da.Fill(dt1)
            If dt1.Rows.Count = 0 Then TEMPID = Val(dt1.Rows(0).Item("COLORID"))


            If MASTERCONN.State = ConnectionState.Open Then MASTERCONN.Close()
            MASTERCONN.Open()
            cmd = New OleDbCommand("SELECT COLORMASTER.COLOR_NAME AS COLOR FROM COLORMASTER WHERE COLOR_ID > " & TEMPID, MASTERCONN)
            da = New OleDbDataAdapter(cmd)
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For Each DTROW As DataRow In dt.Rows

                    dt1.Clear()
                    'CHECKING WHETHER COLOR IS PRESENT IN CURRENT COMPANY OR NOT
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Open()
                    tempcmd = New OleDbCommand("SELECT COLORMASTER.COLOR_NAME AS COLOR FROM COLORMASTER WHERE COLORMASTER.COLOR_NAME = '" & DTROW("COLOR") & "'", conn)
                    da = New OleDbDataAdapter(tempcmd)
                    da.Fill(dt1)
                    If dt1.Rows.Count = 0 Then

                        For i = 1 To 50
                            tempcol(i) = ""
                            tempval(i) = ""
                        Next

                        'ADD NEW 
                        tempcol(0) = "COLOR_name"
                        tempcol(1) = "COLOR_userid"

                        tempval(0) = "'" & DTROW("COLOR") & "'"
                        tempval(1) = tempuserid
                        insert("COLORMASTER", tempcol, tempval)
                    End If
                    conn.Close()
                    tempcmd.Dispose()
                Next
            End If
            MASTERCONN.Close()
            cmd.Dispose()






            'ITEMMASTER
            'FIRST CHECK THE LAST ITEMID IN DAY PEN 
            dt.Clear()
            dt1.Clear()
            TEMPID = 0
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Open()
            tempcmd = New OleDbCommand("SELECT MAX(ITEMMASTER.ITEM_ID) AS ITEMID FROM ITEMMASTER ", conn)
            da = New OleDbDataAdapter(tempcmd)
            da.Fill(dt1)
            If dt1.Rows.Count > 0 Then TEMPID = Val(dt1.Rows(0).Item("ITEMID"))


            If MASTERCONN.State = ConnectionState.Open Then MASTERCONN.Close()
            MASTERCONN.Open()
            cmd = New OleDbCommand("SELECT ITEMMASTER.ITEM_NAME AS ITEMNAME, ITEMMASTER.ITEM_CODE AS ITEMCODE, typemaster.type_name AS ITEMTYPE, CategoryMaster.category_name AS CATEGORY, ITEMMASTER.ITEM_TOTALPCS AS TOTALPCS, ITEMMASTER.ITEM_TOTALCTWT AS TOTALCTWT FROM (ItemMaster INNER JOIN CategoryMaster ON ItemMaster.item_categoryid = CategoryMaster.category_id) INNER JOIN typemaster ON ItemMaster.item_typeid = typemaster.type_id  WHERE ITEMMASTER.ITEM_ID > " & TEMPID & " ORDER BY ITEM_NAME", MASTERCONN)
            da = New OleDbDataAdapter(cmd)
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For Each DTROW As DataRow In dt.Rows

                    dt1.Clear()
                    'CHECKING WHETHER ITEM IS PRESENT IN CURRENT COMPANY OR NOT
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Open()
                    tempcmd = New OleDbCommand("SELECT ITEMMASTER.ITEM_NAME AS ITEMNAME FROM ITEMMASTER WHERE ITEMMASTER.ITEM_NAME = '" & DTROW("ITEMNAME") & "'", conn)
                    da = New OleDbDataAdapter(tempcmd)
                    da.Fill(dt1)
                    If dt1.Rows.Count = 0 Then

                        For i = 1 To 50
                            tempcol(i) = ""
                            tempval(i) = ""
                        Next

                        'ADD NEW 
                        tempcol(0) = "item_name"
                        tempcol(1) = "item_code"
                        tempcol(2) = "item_typeid"
                        tempcol(3) = "item_categoryid"
                        tempcol(4) = "item_rate"
                        tempcol(5) = "item_imagepath"
                        tempcol(6) = "item_totalpcs"
                        tempcol(7) = "item_totalctwt"
                        tempcol(8) = "item_userid"

                        tempval(0) = "'" & UCase(DTROW("ITEMNAME")) & "'"
                        tempval(1) = "'" & UCase(DTROW("ITEMCODE")) & "'"

                        'getting typeid
                        tempcmd = New OleDbCommand("select type_id from typemaster where type_name = '" & DTROW("ITEMTYPE") & "'", tempconn)
                        If tempconn.State = ConnectionState.Open Then
                            tempconn.Close()
                        End If
                        tempconn.Open()
                        tempdr = tempcmd.ExecuteReader
                        If tempdr.HasRows Then
                            tempdr.Read()
                            tempval(2) = tempdr(0)
                        Else
                            tempval(2) = "0"
                        End If
                        tempconn.Close()
                        tempdr.Close()


                        'getting categoryid
                        tempcmd = New OleDbCommand("select category_id from categorymaster where category_name = '" & DTROW("CATEGORY") & "'", tempconn)
                        If tempconn.State = ConnectionState.Open Then
                            tempconn.Close()
                        End If
                        tempconn.Open()
                        tempdr = tempcmd.ExecuteReader
                        If tempdr.HasRows Then
                            tempdr.Read()
                            tempval(3) = tempdr(0)
                        Else
                            tempval(3) = "0"
                        End If
                        tempconn.Close()
                        tempdr.Close()

                        tempval(4) = 0
                        tempval(5) = "''"
                        tempval(6) = Val(DTROW("TOTALPCS"))
                        tempval(7) = Val(DTROW("TOTALCTWT"))
                        tempval(8) = tempuserid
                        insert("ITEMMASTER", tempcol, tempval)





                        'INSERT DATA IN ITEMMASTER_DESC
                        Dim TEMPDA As OleDbDataAdapter
                        Dim TEMPDT, TEMPDT1 As New DataTable
                        If tempconn.State = ConnectionState.Open Then tempconn.Close()
                        tempconn.Open()
                        tempcmd = New OleDbCommand("SELECT ITEMMASTER_DESC.ITEM_SRNO AS [SRNO], ItemMaster.item_NAME AS [GRIDITEMNAME], ShapeMaster.shape_name AS [SHAPE], SizeMaster.size_name AS [SIZE], ColorMaster.color_name AS [COLOR], ITEMMASTER_DESC.ITEM_PCS AS [PCS], ITEMMASTER_DESC.ITEM_CTWT AS [CTWT] FROM ((((ITEMMASTER_DESC INNER JOIN ItemMaster ON ITEMMASTER_DESC.ITEM_GRIDITEMID = ItemMaster.item_id) LEFT JOIN ShapeMaster ON ITEMMASTER_DESC.ITEM_SHAPEID = ShapeMaster.shape_id) LEFT JOIN SizeMaster ON ITEMMASTER_DESC.ITEM_SIZEID = SizeMaster.size_id) LEFT JOIN ColorMaster ON ITEMMASTER_DESC.ITEM_COLORID = ColorMaster.color_id) INNER JOIN ItemMaster AS MainItemMaster ON ITEMMASTER_DESC.ITEM_ID = MainItemMaster.item_id where MAINITEMMASTER.ITEM_NAME = '" & DTROW("ITEMNAME") & "' ORDER BY ITEMMASTER.ITEM_NAME, ITEM_SRNO ", MASTERCONN)
                        TEMPDA = New OleDbDataAdapter(tempcmd)
                        TEMPDA.Fill(TEMPDT)
                        If TEMPDT.Rows.Count > 0 Then
                            For Each TEMPDTROW As DataRow In TEMPDT.Rows

                                For i = 1 To 50
                                    tempcol(i) = ""
                                    tempval(i) = ""
                                Next


                                'ADD NEW 
                                tempcol(0) = "item_ID"
                                tempcol(1) = "item_SRNO"
                                tempcol(2) = "item_GRIDITEMID"
                                tempcol(3) = "item_SHAPEID"
                                tempcol(4) = "item_SIZEID"
                                tempcol(5) = "item_COLORID"
                                tempcol(6) = "item_PCS"
                                tempcol(7) = "item_CTWT"



                                'getting ITEMID FETCH ITEMNAME FROM ABOVE LOOP DTROW
                                tempcmd = New OleDbCommand("select ITEM_ID from ITEMMASTER where ITEM_name = '" & DTROW("ITEMNAME") & "'", tempconn)
                                If tempconn.State = ConnectionState.Open Then tempconn.Close()
                                tempconn.Open()
                                tempdr = tempcmd.ExecuteReader
                                If tempdr.HasRows Then
                                    tempdr.Read()
                                    tempval(0) = tempdr(0)
                                Else
                                    tempval(0) = 0
                                End If
                                tempconn.Close()
                                tempdr.Close()


                                tempval(1) = Val(TEMPDTROW("SRNO"))


                                tempcmd = New OleDbCommand("select ITEM_ID from ITEMMASTER where ITEM_name = '" & TEMPDTROW("GRIDITEMNAME") & "'", tempconn)
                                If tempconn.State = ConnectionState.Open Then tempconn.Close()
                                tempconn.Open()
                                tempdr = tempcmd.ExecuteReader
                                If tempdr.HasRows Then
                                    tempdr.Read()
                                    tempval(2) = tempdr(0)
                                Else
                                    tempval(2) = 0
                                End If
                                tempconn.Close()
                                tempdr.Close()


                                tempcmd = New OleDbCommand("select SHAPE_ID from SHAPEMASTER where SHAPE_name = '" & TEMPDTROW("SHAPE") & "'", tempconn)
                                If tempconn.State = ConnectionState.Open Then tempconn.Close()
                                tempconn.Open()
                                tempdr = tempcmd.ExecuteReader
                                If tempdr.HasRows Then
                                    tempdr.Read()
                                    tempval(3) = tempdr(0)
                                Else
                                    tempval(3) = 0
                                End If
                                tempconn.Close()
                                tempdr.Close()



                                tempcmd = New OleDbCommand("select SIZE_ID from SIZEMASTER where SIZE_name = '" & TEMPDTROW("SIZE") & "'", tempconn)
                                If tempconn.State = ConnectionState.Open Then tempconn.Close()
                                tempconn.Open()
                                tempdr = tempcmd.ExecuteReader
                                If tempdr.HasRows Then
                                    tempdr.Read()
                                    tempval(4) = tempdr(0)
                                Else
                                    tempval(4) = 0
                                End If
                                tempconn.Close()
                                tempdr.Close()


                                tempcmd = New OleDbCommand("select COLOR_ID from COLORMASTER where COLOR_name = '" & TEMPDTROW("COLOR") & "'", tempconn)
                                If tempconn.State = ConnectionState.Open Then tempconn.Close()
                                tempconn.Open()
                                tempdr = tempcmd.ExecuteReader
                                If tempdr.HasRows Then
                                    tempdr.Read()
                                    tempval(5) = tempdr(0)
                                Else
                                    tempval(5) = 0
                                End If
                                tempconn.Close()
                                tempdr.Close()


                                tempval(6) = Val(TEMPDTROW("PCS"))
                                tempval(7) = Val(TEMPDTROW("CTWT"))

                                insert("ITEMMASTER_DESC", tempcol, tempval)
                            Next
                        End If

                        tempconn.Close()
                        tempcmd.Dispose()



                    End If
                    conn.Close()
                    tempcmd.Dispose()
                Next
            End If
            MASTERCONN.Close()
            cmd.Dispose()









            'LEDGERMASTER
            'FIRST CHECK THE LAST LEDGERID IN DAY PEN 
            dt.Clear()
            dt1.Clear()
            TEMPID = 0
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Open()
            tempcmd = New OleDbCommand("SELECT MAX(LEDGERMASTER.LEDGER_ID) AS LEDGERID FROM LEDGERMASTER ", conn)
            da = New OleDbDataAdapter(tempcmd)
            da.Fill(dt1)
            If dt1.Rows.Count > 0 Then TEMPID = Val(dt1.Rows(0).Item("LEDGERID"))


            If MASTERCONN.State = ConnectionState.Open Then MASTERCONN.Close()
            MASTERCONN.Open()
            cmd = New OleDbCommand("SELECT ledgermaster.ledger_name AS LEDGERNAME, ledgermaster.ledger_code AS LEDGERCODE, groupmaster.group_name AS GROUPNAME, ledgermaster.ledger_add1 AS ADD1, ledgermaster.ledger_add2 AS ADD2, areamaster.area_name AS AREANAME, citymaster.city_name AS CITYNAME, ledgermaster.ledger_zipcode AS ZIPCODE, statemaster.state_name AS STATENAME, countrymaster.country_name AS COUNTRYNAME, ledgermaster.ledger_std AS STD, ledgermaster.ledger_resi AS RESI, ledgermaster.ledger_altno AS ALTNO, ledgermaster.ledger_tel1 AS TEL1, ledgermaster.ledger_mobile AS MOBILE, ledgermaster.ledger_fax AS FAX, ledgermaster.ledger_website AS WEBSITE, ledgermaster.ledger_email AS EMAIL, ledgermaster.ledger_crdays AS CRDAYS, ledgermaster.ledger_crlimit AS CRLIMIT, ledgermaster.ledger_panno AS PANNO, IIF(ISNULL(ledgermaster.ledger_SALARY) = TRUE, 0, ledgermaster.ledger_SALARY) AS SALARY, ledgermaster.ledger_cstno AS CSTNO, ledgermaster.ledger_tinno AS TINNO, ledgermaster.ledger_stno AS STNO, ledgermaster.ledger_vatno AS VATNO, ledgermaster.ledger_kstno AS KSTNO, ledgermaster.ledger_add AS LEDGERADDRESS, ledgermaster.ledger_shipadd AS SHIPADD, ledgermaster.ledger_notes AS NOTES, ledgermaster.ledger_settlement AS SETTLEMENT, LEDGERMASTER.LEDGER_LOSSAC AS LOSSAC, LEDGERMASTER.LEDGER_KARIGAR AS KARIGAR FROM ((((ledgermaster LEFT JOIN groupmaster ON ledgermaster.ledger_groupid = groupmaster.group_id) LEFT JOIN areamaster ON ledgermaster.ledger_areaid = areamaster.area_id) LEFT JOIN citymaster ON ledgermaster.ledger_cityid = citymaster.city_id) LEFT JOIN statemaster ON ledgermaster.ledger_stateid = statemaster.state_id) LEFT JOIN countrymaster ON ledgermaster.ledger_countryid = countrymaster.country_id WHERE LEDGERMASTER.LEDGER_ID > " & TEMPID & " ORDER BY ledgermaster.ledger_name", MASTERCONN)
            da = New OleDbDataAdapter(cmd)
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For Each DTROW As DataRow In dt.Rows

                    dt1.Clear()
                    'CHECKING WHETHER LEDGER IS PRESENT IN DAY PEN OR NOT
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Open()
                    tempcmd = New OleDbCommand("SELECT LEDGERMASTER.LEDGER_NAME AS LEDGERNAME FROM LEDGERMASTER WHERE LEDGERMASTER.LEDGER_NAME = '" & DTROW("LEDGERNAME") & "'", conn)
                    da = New OleDbDataAdapter(tempcmd)
                    da.Fill(dt1)
                    If dt1.Rows.Count = 0 Then

                        For i = 1 To 50
                            tempcol(i) = ""
                            tempval(i) = ""
                        Next

                        'ADD NEW 
                        tempcol(0) = "ledger_name"
                        tempcol(1) = "ledger_code"
                        tempcol(2) = "ledger_groupid"
                        tempcol(3) = "ledger_opbalrs"
                        tempcol(4) = "ledger_drcrrs"
                        tempcol(5) = "ledger_opbalwt"
                        tempcol(6) = "ledger_drcrwt"
                        tempcol(7) = "ledger_add1"
                        tempcol(8) = "ledger_add2"
                        tempcol(9) = "ledger_areaid"
                        tempcol(10) = "ledger_cityid"
                        tempcol(11) = "ledger_zipcode"
                        tempcol(12) = "ledger_stateid"
                        tempcol(13) = "ledger_countryid"
                        tempcol(14) = "ledger_std"
                        tempcol(15) = "ledger_resi"
                        tempcol(16) = "ledger_altno"
                        tempcol(17) = "ledger_tel1"
                        tempcol(18) = "ledger_mobile"
                        tempcol(19) = "ledger_fax"
                        tempcol(20) = "ledger_website"
                        tempcol(21) = "ledger_email"
                        tempcol(22) = "ledger_crdays"
                        tempcol(23) = "ledger_crlimit"
                        tempcol(24) = "ledger_panno"
                        tempcol(25) = "ledger_SALARY"
                        tempcol(26) = "ledger_cstno"
                        tempcol(27) = "ledger_tinno"
                        tempcol(28) = "ledger_stno"
                        tempcol(29) = "ledger_vatno"
                        tempcol(30) = "ledger_kstno"
                        tempcol(31) = "ledger_add"
                        tempcol(32) = "ledger_shipadd"
                        tempcol(33) = "ledger_notes"
                        tempcol(34) = "ledger_userid"
                        tempcol(35) = "ledger_SETTLEMENT"
                        tempcol(36) = "ledger_LOSSAC"
                        tempcol(37) = "ledger_KARIGAR"
                        tempcol(38) = "LEDGER_OPBALGROSSWT"
                        tempcol(39) = "LEDGER_DRCRGROSSWT"


                        tempval(0) = "'" & DTROW("LEDGERNAME") & "'"
                        tempval(1) = "'" & DTROW("LEDGERCODE") & "'"

                        'getting groupid
                        tempcmd = New OleDbCommand("select group_id from groupmaster where group_name = '" & DTROW("GROUPNAME") & "'", tempconn)
                        If tempconn.State = ConnectionState.Open Then
                            tempconn.Close()
                        End If
                        tempconn.Open()
                        tempdr = tempcmd.ExecuteReader
                        If tempdr.HasRows Then
                            tempdr.Read()
                            tempval(2) = tempdr(0)
                        Else
                            tempval(2) = "0"
                        End If
                        tempconn.Close()
                        tempdr.Close()

                        'NO NEED TO TFRANSFER BALANCE
                        tempval(3) = 0
                        tempval(4) = "'Dr.'"
                        tempval(5) = 0
                        tempval(6) = "'Dr.'"
                        tempval(38) = 0
                        tempval(39) = "'Dr.'"


                        tempval(7) = "'" & DTROW("ADD1") & "'"
                        tempval(8) = "'" & DTROW("ADD2") & "'"

                        'getting area
                        tempcmd = New OleDbCommand("select area_id from areamaster where area_name = '" & DTROW("AREANAME") & "'", tempconn)
                        If tempconn.State = ConnectionState.Open Then
                            tempconn.Close()
                        End If
                        tempconn.Open()
                        tempdr = tempcmd.ExecuteReader
                        If tempdr.HasRows Then
                            tempdr.Read()
                            tempval(9) = tempdr(0)
                        Else
                            tempval(9) = "0"
                        End If
                        tempconn.Close()
                        tempdr.Close()


                        'getting city
                        tempcmd = New OleDbCommand("select city_id from citymaster where city_name = '" & DTROW("CITYNAME") & "'", tempconn)
                        If tempconn.State = ConnectionState.Open Then
                            tempconn.Close()
                        End If
                        tempconn.Open()
                        tempdr = tempcmd.ExecuteReader
                        If tempdr.HasRows Then
                            tempdr.Read()
                            tempval(10) = tempdr(0)
                        Else
                            tempval(10) = "0"
                        End If
                        tempconn.Close()
                        tempdr.Close()


                        tempval(11) = "'" & DTROW("ZIPCODE") & "'"

                        'getting state
                        tempcmd = New OleDbCommand("select state_id from statemaster where state_name = '" & DTROW("STATENAME") & "'", tempconn)
                        If tempconn.State = ConnectionState.Open Then
                            tempconn.Close()
                        End If
                        tempconn.Open()
                        tempdr = tempcmd.ExecuteReader
                        If tempdr.HasRows Then
                            tempdr.Read()
                            tempval(12) = tempdr(0)
                        Else
                            tempval(12) = "0"
                        End If
                        tempconn.Close()
                        tempdr.Close()


                        'getting country
                        tempcmd = New OleDbCommand("select country_id from countrymaster where country_name  = '" & DTROW("COUNTRYNAME") & "'", tempconn)
                        If tempconn.State = ConnectionState.Open Then
                            tempconn.Close()
                        End If
                        tempconn.Open()
                        tempdr = tempcmd.ExecuteReader
                        If tempdr.HasRows Then
                            tempdr.Read()
                            tempval(13) = tempdr(0)
                        Else
                            tempval(13) = "0"
                        End If
                        tempconn.Close()
                        tempdr.Close()


                        tempval(14) = DTROW("STD")
                        tempval(15) = DTROW("RESI")
                        tempval(16) = DTROW("ALTNO")
                        tempval(17) = DTROW("TEL1")
                        tempval(18) = DTROW("MOBILE")
                        tempval(19) = DTROW("FAX")
                        tempval(20) = "'" & DTROW("WEBSITE") & "'"
                        tempval(21) = "'" & DTROW("EMAIL") & "'"
                        tempval(22) = DTROW("CRDAYS")
                        tempval(23) = DTROW("CRLIMIT")
                        tempval(24) = "'" & DTROW("PANNO") & "'"
                        tempval(25) = DTROW("SALARY")
                        tempval(26) = "'" & DTROW("CSTNO") & "'"
                        tempval(27) = "'" & DTROW("TINNO") & "'"
                        tempval(28) = "'" & DTROW("STNO") & "'"
                        tempval(29) = "'" & DTROW("VATNO") & "'"
                        tempval(30) = "'" & DTROW("KSTNO") & "'"
                        tempval(31) = "'" & DTROW("LEDGERADDRESS") & "'"
                        tempval(32) = "'" & DTROW("SHIPADD") & "'"
                        tempval(33) = "'" & DTROW("NOTES") & "'"
                        tempval(34) = Val(tempuserid)
                        tempval(35) = "'" & DTROW("SETTLEMENT") & "'"
                        tempval(36) = DTROW("LOSSAC")
                        tempval(37) = DTROW("KARIGAR")
                        insert("LEDGERMASTER", tempcol, tempval)

                    End If
                    conn.Close()
                    tempcmd.Dispose()
                Next
            End If
            MASTERCONN.Close()
            cmd.Dispose()




            dt.Clear()
            'CUSTOMERWASTAGE
            If MASTERCONN.State = ConnectionState.Open Then MASTERCONN.Close()
            MASTERCONN.Open()
            cmd = New OleDbCommand("SELECT ledgermaster.ledger_name AS LEDGERNAME, ItemMaster.item_name AS ITEMNAME, CustomerWastage.wastage AS WASTAGE, CustomerWastage.labour AS LABOUR, CustomerWastage.cus_default AS CUSDEFAULT FROM (CustomerWastage INNER JOIN ledgermaster ON CustomerWastage.ledgerid = ledgermaster.ledger_id) LEFT JOIN ItemMaster ON CustomerWastage.itemid = ItemMaster.item_id ", MASTERCONN)
            da = New OleDbDataAdapter(cmd)
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For Each DTROW As DataRow In dt.Rows

                    dt1.Clear()
                    'CHECKING WHETHER LEDGER AND ITEM IS PRESENT IN CURRENT COMPANY OR NOT
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Open()
                    tempcmd = New OleDbCommand(" SELECT ledgermaster.ledger_name AS LEDGERNAME, ItemMaster.item_name AS ITEMNAME, CustomerWastage.wastage AS WASTAGE, CustomerWastage.labour AS LABOUR, CustomerWastage.cus_default AS CUSDEFAULT FROM (CustomerWastage INNER JOIN ledgermaster ON CustomerWastage.ledgerid = ledgermaster.ledger_id) LEFT JOIN ItemMaster ON CustomerWastage.itemid = ItemMaster.item_id WHERE LEDGERMASTER.LEDGER_NAME = '" & DTROW("LEDGERNAME") & "' AND ITEMMASTER.ITEM_NAME = '" & DTROW("ITEMNAME") & "'", conn)
                    da = New OleDbDataAdapter(tempcmd)
                    da.Fill(dt1)
                    If dt1.Rows.Count = 0 Then

                        For i = 1 To 50
                            tempcol(i) = ""
                            tempval(i) = ""
                        Next

                        'ADD NEW 
                        tempcol(0) = "ledgerid"
                        tempcol(1) = "itemid"
                        tempcol(2) = "wastage"
                        tempcol(3) = "labour"
                        tempcol(4) = "cus_default"


                        'getting nameid
                        cmd = New OleDbCommand("select ledger_id from ledgermaster where ledger_NAME = '" & DTROW("LEDGERNAME") & "'", conn)
                        If conn.State = ConnectionState.Open Then
                            conn.Close()
                        End If
                        conn.Open()
                        dr = cmd.ExecuteReader()
                        If dr.HasRows Then
                            dr.Read()
                            tempval(0) = Val(dr(0))
                        Else
                            tempval(0) = Val(0)
                        End If
                        conn.Close()


                        'getting itemid
                        cmd = New OleDbCommand("select item_id from itemmaster where item_NAME =  '" & DTROW("ITEMNAME") & "'", conn)
                        If conn.State = ConnectionState.Open Then
                            conn.Close()
                        End If
                        conn.Open()
                        dr = cmd.ExecuteReader()
                        If dr.HasRows Then
                            dr.Read()
                            tempval(1) = Val(dr(0))
                        Else
                            tempval(1) = Val(0)
                        End If
                        conn.Close()

                        tempval(2) = DTROW("WASTAGE")
                        tempval(3) = DTROW("LABOUR")
                        tempval(4) = 1

                        insert("CustomerWastage", tempcol, tempval)
                    End If
                    conn.Close()
                    tempcmd.Dispose()
                Next
            End If
            MASTERCONN.Close()
            cmd.Dispose()
            '********************** END OF TRANSFER OF MASTERS FROM MAIN PEN TO DAY PEN COMPLETED ******************************




            '*************** TRANSFER OF TRANSACTIONS FROM DAY PEN TO MAIN PEN ****************************
            dt.Clear()
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Open()


            For i = 1 To 50
                tempcol(i) = ""
                tempval(i) = ""
            Next


            tempcol(0) = "account_id"
            tempcol(1) = "account_date"
            tempcol(2) = "account_ledgerid"
            tempcol(3) = "account_itemid"
            tempcol(4) = "account_purity"
            tempcol(5) = "account_wastage"
            tempcol(6) = "account_grosswt"
            tempcol(7) = "account_nettwt"
            tempcol(8) = "account_amount"
            tempcol(9) = "account_balorjamaorpaid"
            tempcol(10) = "account_narration"
            tempcol(11) = "account_type"
            tempcol(12) = "account_voucherid"
            tempcol(13) = "account_SUBTYPE"
            tempcol(14) = "account_ledgercode"
            tempcol(15) = "account_LABOUR"
            tempcol(16) = "account_PIECES"
            tempcol(17) = "account_BULLION"
            tempcol(18) = "account_ITEMDESC"
            tempcol(19) = "account_USERID"
            tempcol(20) = "account_DEPARTMENTID"
            tempcol(21) = "account_PROCESS"


            'ACCOUNTSMASTER
            cmd = New OleDbCommand(" SELECT accountmaster.account_id, accountmaster.account_date, ledgermaster.ledger_name, ItemMaster.item_name, accountmaster.account_purity, accountmaster.account_wastage, accountmaster.account_grosswt, accountmaster.account_nettwt, accountmaster.account_amount, accountmaster.account_balorjamaorpaid, accountmaster.account_narration, accountmaster.account_type, accountmaster.account_voucherid, accountmaster.account_subtype, accountmaster.account_ledgercode, accountmaster.account_labour, accountmaster.account_pieces, accountmaster.account_bullion, accountmaster.ACCOUNT_DELETE, accountmaster.ACCOUNT_ITEMDESC, USERMASTER.USER_NAME, DEPARTMENTMASTER.DEPARTMENT_NAME, accountmaster.ACCOUNT_PROCESS, accountmaster.ACCOUNT_PROCESS FROM (((accountmaster LEFT JOIN ledgermaster ON accountmaster.account_ledgerid = ledgermaster.ledger_id) LEFT JOIN ItemMaster ON accountmaster.account_itemid = ItemMaster.item_id) LEFT JOIN USERMASTER ON accountmaster.ACCOUNT_USERID = USERMASTER.USER_ID) LEFT JOIN DEPARTMENTMASTER ON accountmaster.ACCOUNT_DEPARTMENTID = DEPARTMENTMASTER.DEPARTMENT_ID where accountmaster.account_date >= #" & Format(DTFROM.Value.Date, "MM/dd/yyyy") & "# AND accountmaster.account_date <= #" & Format(DTTO.Value.Date, "MM/dd/yyyy") & "#", conn)
            da = New OleDbDataAdapter(cmd)
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For Each DTROW As DataRow In dt.Rows

                    tempval(0) = Val(DTROW("account_id"))
                    tempval(1) = "'" & Format(DTROW("account_date"), "dd/MM/yyyy") & "'"

                    'getting ledgerid
                    tempcmd = New OleDbCommand("select ledger_id from ledgermaster where ledger_NAME = '" & DTROW("ledger_name") & "'", MASTERCONN)
                    If MASTERCONN.State = ConnectionState.Open Then MASTERCONN.Close()
                    MASTERCONN.Open()
                    dr = tempcmd.ExecuteReader()
                    If dr.HasRows Then
                        dr.Read()
                        tempval(2) = Val(dr("ledger_id"))
                    Else
                        tempval(2) = Val(0)
                    End If
                    MASTERCONN.Close()
                    tempcmd.Dispose()


                    'getting itemid
                    tempcmd = New OleDbCommand("select item_id from itemmaster where item_NAME =  '" & DTROW("item_name") & "'", MASTERCONN)
                    If MASTERCONN.State = ConnectionState.Open Then MASTERCONN.Close()
                    MASTERCONN.Open()
                    dr = tempcmd.ExecuteReader()
                    If dr.HasRows Then
                        dr.Read()
                        tempval(3) = Val(dr("ITEM_ID"))
                    Else
                        tempval(3) = Val(0)
                    End If
                    MASTERCONN.Close()
                    tempcmd.Dispose()



                    tempval(4) = Val(DTROW("account_purity"))
                    tempval(5) = Val(DTROW("account_wastage"))
                    tempval(6) = Val(DTROW("account_grosswt"))
                    tempval(7) = Val(DTROW("account_nettwt"))
                    tempval(8) = Val(DTROW("account_amount"))
                    tempval(9) = "'" & DTROW("account_balorjamaorpaid") & "'"
                    If IsDBNull(DTROW("account_narration")) = False Then tempval(10) = "'" & DTROW("account_narration") & "'" Else tempval(10) = "''"
                    tempval(11) = "'" & DTROW("account_type") & "'"
                    tempval(12) = Val(DTROW("account_voucherid"))
                    If IsDBNull(DTROW("account_subtype")) = False Then tempval(13) = "'" & DTROW("account_subtype") & "'" Else tempval(13) = "''"
                    If IsDBNull(DTROW("account_ledgercode")) = False Then tempval(14) = "'" & DTROW("account_ledgercode") & "'" Else tempval(14) = "''"
                    tempval(15) = Val(DTROW("account_labour"))
                    tempval(16) = Val(DTROW("account_pieces"))
                    tempval(17) = Val(DTROW("account_bullion"))
                    tempval(18) = "'" & DTROW("ACCOUNT_ITEMDESC") & "'"


                    'getting userid
                    tempcmd = New OleDbCommand("select user_id from usermaster where user_name =  '" & DTROW("USER_NAME") & "'", MASTERCONN)
                    If MASTERCONN.State = ConnectionState.Open Then MASTERCONN.Close()
                    MASTERCONN.Open()
                    dr = tempcmd.ExecuteReader()
                    If dr.HasRows Then
                        dr.Read()
                        tempval(19) = Val(dr("user_ID"))
                    Else
                        tempval(19) = Val(0)
                    End If
                    MASTERCONN.Close()
                    tempcmd.Dispose()


                    'getting departmentid
                    tempcmd = New OleDbCommand("select department_id from departmentmaster where department_name =  '" & DTROW("department_NAME") & "'", MASTERCONN)
                    If MASTERCONN.State = ConnectionState.Open Then MASTERCONN.Close()
                    MASTERCONN.Open()
                    dr = tempcmd.ExecuteReader()
                    If dr.HasRows Then
                        dr.Read()
                        tempval(20) = Val(dr("department_ID"))
                    Else
                        tempval(20) = Val(0)
                    End If
                    MASTERCONN.Close()
                    tempcmd.Dispose()

                    tempval(21) = "'" & DTROW("ACCOUNT_PROCESS") & "'"


                    INSERTMASTERCONN("accountmaster", tempcol, tempval, MASTERCONN)

                Next
            End If
            conn.Close()
            cmd.Dispose()
            da.Dispose()
            dt.Clear()

            'deleteing from ACCOUNTSMASTER
            cmd = New OleDbCommand("delete from accountmaster where accountmaster.account_date >= #" & Format(DTFROM.Value.Date, "MM/dd/yyyy") & "# AND accountmaster.account_date <= #" & Format(DTTO.Value.Date, "MM/dd/yyyy") & "#", conn)
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Open()
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            conn.Close()
            '********************** END OF ACCOUNTSMASTER ******************************





            '********************** START OF BHAVCUTMASTER ******************************
            For i = 1 To 50
                tempcol(i) = ""
                tempval(i) = ""
            Next


            tempcol(0) = "bhavcut_id"
            tempcol(1) = "bhavcut_date"
            tempcol(2) = "bhavcut_type"
            tempcol(3) = "bhavcut_ledgerid"
            tempcol(4) = "bhavcut_itemid"
            tempcol(5) = "bhavcut_grosswt"
            tempcol(6) = "bhavcut_purity"
            tempcol(7) = "bhavcut_wastage"
            tempcol(8) = "bhavcut_nettwt"
            tempcol(9) = "bhavcut_amount"
            tempcol(10) = "bhavcut_bhavcut"
            tempcol(11) = "bhavcut_goldrate"
            tempcol(12) = "bhavcut_perwt"
            tempcol(13) = "bhavcut_totalamt"
            tempcol(14) = "bhavcut_cashreceived"
            tempcol(15) = "BHAVCUT_USERID"
            tempcol(16) = "BHAVCUT_DEPARTMENTID"

            cmd = New OleDbCommand(" SELECT bhavcutmaster.bhavcut_id, bhavcutmaster.bhavcut_date, bhavcutmaster.bhavcut_type, ledgermaster.ledger_name, ItemMaster.item_name, bhavcutmaster.bhavcut_grosswt, bhavcutmaster.bhavcut_purity, bhavcutmaster.bhavcut_wastage, bhavcutmaster.bhavcut_nettwt, bhavcutmaster.bhavcut_amount, bhavcutmaster.bhavcut_bhavcut, bhavcutmaster.bhavcut_goldrate, bhavcutmaster.bhavcut_perwt, bhavcutmaster.bhavcut_totalamt, bhavcutmaster.bhavcut_cashreceived, USERMASTER.USER_NAME, DEPARTMENTMASTER.DEPARTMENT_NAME FROM (((bhavcutmaster LEFT JOIN ledgermaster ON bhavcutmaster.bhavcut_ledgerid = ledgermaster.ledger_id) LEFT JOIN ItemMaster ON bhavcutmaster.bhavcut_itemid = ItemMaster.item_id) LEFT JOIN USERMASTER ON bhavcutmaster.BHAVCUT_USERID = USERMASTER.USER_ID) LEFT JOIN DEPARTMENTMASTER ON bhavcutmaster.BHAVCUT_DEPARTMENTID = DEPARTMENTMASTER.DEPARTMENT_ID where bhavcutmaster.bhavcut_date >= #" & Format(DTFROM.Value.Date, "MM/dd/yyyy") & "# AND bhavcutmaster.bhavcut_date <= #" & Format(DTTO.Value.Date, "MM/dd/yyyy") & "#", conn)
            da = New OleDbDataAdapter(cmd)
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For Each DTROW As DataRow In dt.Rows

                    tempval(0) = Val(DTROW("bhavcut_id"))
                    tempval(1) = "'" & Format(DTROW("bhavcut_date"), "dd/MM/yyyy") & "'"
                    tempval(2) = "'" & DTROW("bhavcut_type") & "'"

                    'getting ledgerid
                    tempcmd = New OleDbCommand("select ledger_id from ledgermaster where ledger_NAME = '" & DTROW("ledger_name") & "'", MASTERCONN)
                    If MASTERCONN.State = ConnectionState.Open Then MASTERCONN.Close()
                    MASTERCONN.Open()
                    dr = tempcmd.ExecuteReader()
                    If dr.HasRows Then
                        dr.Read()
                        tempval(3) = Val(dr("ledger_id"))
                    Else
                        tempval(3) = Val(0)
                    End If
                    MASTERCONN.Close()
                    tempcmd.Dispose()


                    'getting itemid
                    tempcmd = New OleDbCommand("select item_id from itemmaster where item_NAME =  '" & DTROW("item_name") & "'", MASTERCONN)
                    If MASTERCONN.State = ConnectionState.Open Then MASTERCONN.Close()
                    MASTERCONN.Open()
                    dr = tempcmd.ExecuteReader()
                    If dr.HasRows Then
                        dr.Read()
                        tempval(4) = Val(dr("ITEM_ID"))
                    Else
                        tempval(4) = Val(0)
                    End If
                    MASTERCONN.Close()
                    tempcmd.Dispose()



                    tempval(5) = Val(DTROW("bhavcut_grosswt"))
                    tempval(6) = Val(DTROW("bhavcut_purity"))
                    tempval(7) = Val(DTROW("bhavcut_wastage"))
                    tempval(8) = Val(DTROW("bhavcut_nettwt"))
                    If IsDBNull(DTROW("account_amount")) = False Then tempval(9) = Val(DTROW("account_amount")) Else tempval(9) = 0
                    tempval(10) = Val(DTROW("bhavcut_bhavcut"))
                    tempval(11) = Val(DTROW("bhavcut_goldrate"))
                    tempval(12) = Val(DTROW("bhavcut_perwt"))
                    tempval(13) = Val(DTROW("bhavcut_totalamt"))
                    tempval(14) = Val(DTROW("bhavcut_cashreceived"))

                    'getting userid
                    tempcmd = New OleDbCommand("select user_id from usermaster where user_name =  '" & DTROW("USER_NAME") & "'", MASTERCONN)
                    If MASTERCONN.State = ConnectionState.Open Then MASTERCONN.Close()
                    MASTERCONN.Open()
                    dr = tempcmd.ExecuteReader()
                    If dr.HasRows Then
                        dr.Read()
                        tempval(15) = Val(dr("user_ID"))
                    Else
                        tempval(15) = Val(0)
                    End If
                    MASTERCONN.Close()
                    tempcmd.Dispose()


                    'getting departmentid
                    tempcmd = New OleDbCommand("select department_id from departmentmaster where department_name =  '" & DTROW("department_NAME") & "'", MASTERCONN)
                    If MASTERCONN.State = ConnectionState.Open Then MASTERCONN.Close()
                    MASTERCONN.Open()
                    dr = tempcmd.ExecuteReader()
                    If dr.HasRows Then
                        dr.Read()
                        tempval(16) = Val(dr("department_ID"))
                    Else
                        tempval(16) = Val(0)
                    End If
                    MASTERCONN.Close()
                    tempcmd.Dispose()


                    INSERTMASTERCONN("BHAVCUTMASTER", tempcol, tempval, MASTERCONN)

                Next
            End If
            conn.Close()
            cmd.Dispose()
            da.Dispose()
            dt.Clear()


            'deleteing from bhavcutmaster
            cmd = New OleDbCommand("delete from bhavcutmaster where bhavcutmaster.bhavcut_date >= #" & Format(DTFROM.Value.Date, "MM/dd/yyyy") & "# AND bhavcutmaster.bhavcut_date <= #" & Format(DTTO.Value.Date, "MM/dd/yyyy") & "#", conn)
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Open()
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            conn.Close()
            '********************** END OF BHAVCUTMASTER ******************************






            '********************** START OF BHAVCUTMASTER ******************************
            For i = 1 To 50
                tempcol(i) = ""
                tempval(i) = ""
            Next


            tempcol(0) = "CASH_NO"
            tempcol(1) = "CASH_DATE"
            tempcol(2) = "CASH_LEDGERID"
            tempcol(3) = "CASH_TOTALAMT"
            tempcol(4) = "CASH_SRNO"
            tempcol(5) = "CASH_TOLEDGERID"
            tempcol(6) = "CASH_NARR"
            tempcol(7) = "CASH_AMOUNT"
            tempcol(8) = "CASH_TYPE"
            tempcol(9) = "CASH_USERID"
            tempcol(10) = "CASH_DEPARTMENTID"

            cmd = New OleDbCommand(" SELECT CASHENTRY.CASH_NO, CASHENTRY.CASH_DATE, ledgermaster.ledger_name, CASHENTRY.CASH_TOTALAMT, CASHENTRY.CASH_SRNO, TOLEDGERMASTER.ledger_name as TOLEDGERNAME, CASHENTRY.CASH_NARR, CASHENTRY.CASH_AMOUNT, CASHENTRY.CASH_TYPE, USERMASTER.USER_NAME, DEPARTMENTMASTER.DEPARTMENT_NAME FROM (((CASHENTRY LEFT JOIN ledgermaster ON CASHENTRY.CASH_LEDGERID = ledgermaster.ledger_id) LEFT JOIN ledgermaster AS TOLEDGERMASTER ON CASHENTRY.CASH_TOLEDGERID = TOLEDGERMASTER.ledger_id) LEFT JOIN USERMASTER ON CASHENTRY.CASH_USERID = USERMASTER.USER_ID) LEFT JOIN DEPARTMENTMASTER ON CASHENTRY.CASH_DEPARTMENTID = DEPARTMENTMASTER.DEPARTMENT_ID where CASHENTRY.CASH_DATE >= #" & Format(DTFROM.Value.Date, "MM/dd/yyyy") & "# AND CASHENTRY.CASH_DATE <= #" & Format(DTTO.Value.Date, "MM/dd/yyyy") & "#", conn)
            da = New OleDbDataAdapter(cmd)
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For Each DTROW As DataRow In dt.Rows

                    tempval(0) = Val(DTROW("CASH_NO"))
                    tempval(1) = "'" & Format(DTROW("CASH_DATE"), "dd/MM/yyyy") & "'"

                    'getting ledgerid
                    tempcmd = New OleDbCommand("select ledger_id from ledgermaster where ledger_NAME = '" & DTROW("ledger_name") & "'", MASTERCONN)
                    If MASTERCONN.State = ConnectionState.Open Then MASTERCONN.Close()
                    MASTERCONN.Open()
                    dr = tempcmd.ExecuteReader()
                    If dr.HasRows Then
                        dr.Read()
                        tempval(2) = Val(dr("ledger_id"))
                    Else
                        tempval(2) = Val(0)
                    End If
                    MASTERCONN.Close()
                    tempcmd.Dispose()

                    tempval(3) = Val(DTROW("CASH_TOTALAMT"))
                    tempval(4) = Val(DTROW("CASH_SRNO"))


                    'getting TOledgerid
                    tempcmd = New OleDbCommand("select ledger_id from ledgermaster where ledger_NAME = '" & DTROW("TOLEDGERNAME") & "'", MASTERCONN)
                    If MASTERCONN.State = ConnectionState.Open Then MASTERCONN.Close()
                    MASTERCONN.Open()
                    dr = tempcmd.ExecuteReader()
                    If dr.HasRows Then
                        dr.Read()
                        tempval(5) = Val(dr("ledger_id"))
                    Else
                        tempval(5) = Val(0)
                    End If
                    MASTERCONN.Close()
                    tempcmd.Dispose()

                    tempval(6) = "'" & DTROW("CASH_NARR") & "'"
                    tempval(7) = Val(DTROW("CASH_AMOUNT"))
                    tempval(8) = "'" & DTROW("CASH_TYPE") & "'"

                    'getting userid
                    tempcmd = New OleDbCommand("select user_id from usermaster where user_name =  '" & DTROW("USER_NAME") & "'", MASTERCONN)
                    If MASTERCONN.State = ConnectionState.Open Then MASTERCONN.Close()
                    MASTERCONN.Open()
                    dr = tempcmd.ExecuteReader()
                    If dr.HasRows Then
                        dr.Read()
                        tempval(9) = Val(dr("user_ID"))
                    Else
                        tempval(9) = Val(0)
                    End If
                    MASTERCONN.Close()
                    tempcmd.Dispose()


                    'getting departmentid
                    tempcmd = New OleDbCommand("select department_id from departmentmaster where department_name =  '" & DTROW("department_NAME") & "'", MASTERCONN)
                    If MASTERCONN.State = ConnectionState.Open Then MASTERCONN.Close()
                    MASTERCONN.Open()
                    dr = tempcmd.ExecuteReader()
                    If dr.HasRows Then
                        dr.Read()
                        tempval(10) = Val(dr("department_ID"))
                    Else
                        tempval(10) = Val(0)
                    End If
                    MASTERCONN.Close()
                    tempcmd.Dispose()


                    INSERTMASTERCONN("CASHENTRY", tempcol, tempval, MASTERCONN)

                Next
            End If
            conn.Close()
            cmd.Dispose()
            da.Dispose()
            dt.Clear()

            'deleteing from CASHENTRY
            cmd = New OleDbCommand("delete from CASHENTRY where CASHENTRY.CASH_DATE >= #" & Format(DTFROM.Value.Date, "MM/dd/yyyy") & "# AND CASHENTRY.CASH_DATE <= #" & Format(DTTO.Value.Date, "MM/dd/yyyy") & "#", conn)
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Open()
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            conn.Close()
            '********************** END OF CASHENTRY ******************************





            '********************** START OF JOURNALMASTER ******************************
            For i = 1 To 50
                tempcol(i) = ""
                tempval(i) = ""
            Next


            tempcol(0) = "JV_NO"
            tempcol(1) = "JV_DATE"
            tempcol(2) = "JV_LEDGERID"
            tempcol(3) = "JV_TOTALPCS"
            tempcol(4) = "JV_TOTALGROSSWT"
            tempcol(5) = "JV_TOTALFINEWT"
            tempcol(6) = "JV_TOTALAMT"
            tempcol(7) = "JV_REMARKS"
            tempcol(8) = "JV_SRNO"
            tempcol(9) = "JV_ITEMID"
            tempcol(10) = "JV_ITEMDESC"
            tempcol(11) = "JV_PCS"
            tempcol(12) = "JV_GROSSWT"
            tempcol(13) = "JV_PURITY"
            tempcol(14) = "JV_WASTAGE"
            tempcol(15) = "JV_FINEWT"
            tempcol(16) = "JV_AMOUNT"
            tempcol(17) = "JV_TOLEDGERID"
            tempcol(18) = "JV_USERID"
            tempcol(19) = "JV_DEPARTMENTID"

            cmd = New OleDbCommand(" SELECT JOURNALMASTER.JV_NO, JOURNALMASTER.JV_DATE, ledgermaster.ledger_name, JOURNALMASTER.JV_TOTALPCS, JOURNALMASTER.JV_TOTALGROSSWT, JOURNALMASTER.JV_TOTALFINEWT, JOURNALMASTER.JV_TOTALAMT, JOURNALMASTER.JV_REMARKS, JOURNALMASTER.JV_SRNO, ItemMaster.item_name, JOURNALMASTER.JV_ITEMDESC, JOURNALMASTER.JV_PCS, JOURNALMASTER.JV_GROSSWT, JOURNALMASTER.JV_GROSSWT, JOURNALMASTER.JV_PURITY, JOURNALMASTER.JV_WASTAGE, JOURNALMASTER.JV_FINEWT, JOURNALMASTER.JV_AMOUNT, TOLEDGERMASTER.ledger_name AS TOLEDGERNAME, USERMASTER.USER_NAME, DEPARTMENTMASTER.DEPARTMENT_NAME FROM ((((JOURNALMASTER LEFT JOIN ledgermaster ON JOURNALMASTER.JV_LEDGERID = ledgermaster.ledger_id) LEFT JOIN ItemMaster ON JOURNALMASTER.JV_ITEMID = ItemMaster.item_id) LEFT JOIN ledgermaster AS TOLEDGERMASTER ON JOURNALMASTER.JV_TOLEDGERID = TOLEDGERMASTER.ledger_id) LEFT JOIN USERMASTER ON JOURNALMASTER.JV_USERID = USERMASTER.USER_ID) LEFT JOIN DEPARTMENTMASTER ON JOURNALMASTER.JV_DEPARTMENTID = DEPARTMENTMASTER.DEPARTMENT_ID where JOURNALMASTER.JV_DATE >= #" & Format(DTFROM.Value.Date, "MM/dd/yyyy") & "# AND JOURNALMASTER.JV_DATE <= #" & Format(DTTO.Value.Date, "MM/dd/yyyy") & "#", conn)
            da = New OleDbDataAdapter(cmd)
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For Each DTROW As DataRow In dt.Rows

                    tempval(0) = Val(DTROW("JV_NO"))
                    tempval(1) = "'" & Format(DTROW("JV_DATE"), "dd/MM/yyyy") & "'"

                    'getting ledgerid
                    tempcmd = New OleDbCommand("select ledger_id from ledgermaster where ledger_NAME = '" & DTROW("ledger_name") & "'", MASTERCONN)
                    If MASTERCONN.State = ConnectionState.Open Then MASTERCONN.Close()
                    MASTERCONN.Open()
                    dr = tempcmd.ExecuteReader()
                    If dr.HasRows Then
                        dr.Read()
                        tempval(2) = Val(dr("ledger_id"))
                    Else
                        tempval(2) = Val(0)
                    End If
                    MASTERCONN.Close()
                    tempcmd.Dispose()

                    tempval(3) = Val(DTROW("JV_TOTALPCS"))
                    tempval(4) = Val(DTROW("JV_TOTALGROSSWT"))
                    tempval(5) = Val(DTROW("JV_TOTALFINEWT"))
                    tempval(6) = Val(DTROW("JV_TOTALAMT"))
                    If IsDBNull(DTROW("JV_REMARKS")) = False Then tempval(7) = "'" & DTROW("JV_REMARKS") & "'" Else tempval(7) = "''"
                    tempval(8) = Val(DTROW("JV_SRNO"))


                    'getting itemid
                    tempcmd = New OleDbCommand("select item_id from itemmaster where item_NAME =  '" & DTROW("item_name") & "'", MASTERCONN)
                    If MASTERCONN.State = ConnectionState.Open Then MASTERCONN.Close()
                    MASTERCONN.Open()
                    dr = tempcmd.ExecuteReader()
                    If dr.HasRows Then
                        dr.Read()
                        tempval(9) = Val(dr("ITEM_ID"))
                    Else
                        tempval(9) = Val(0)
                    End If
                    MASTERCONN.Close()
                    tempcmd.Dispose()


                    If IsDBNull(DTROW("JV_ITEMDESC")) = False Then tempval(10) = "'" & DTROW("JV_ITEMDESC") & "'" Else tempval(10) = "''"
                    tempval(11) = Val(DTROW("JV_PCS"))
                    tempval(12) = Val(DTROW("JV_GROSSWT"))
                    tempval(13) = Val(DTROW("JV_PURITY"))
                    tempval(14) = Val(DTROW("JV_WASTAGE"))
                    tempval(15) = Val(DTROW("JV_FINEWT"))
                    tempval(16) = Val(DTROW("JV_AMOUNT"))



                    'getting TOledgerid
                    tempcmd = New OleDbCommand("select ledger_id from ledgermaster where ledger_NAME = '" & DTROW("TOLEDGERNAME") & "'", MASTERCONN)
                    If MASTERCONN.State = ConnectionState.Open Then MASTERCONN.Close()
                    MASTERCONN.Open()
                    dr = tempcmd.ExecuteReader()
                    If dr.HasRows Then
                        dr.Read()
                        tempval(17) = Val(dr("ledger_id"))
                    Else
                        tempval(17) = Val(0)
                    End If
                    MASTERCONN.Close()
                    tempcmd.Dispose()


                    'getting userid
                    tempcmd = New OleDbCommand("select user_id from usermaster where user_name =  '" & DTROW("USER_NAME") & "'", MASTERCONN)
                    If MASTERCONN.State = ConnectionState.Open Then MASTERCONN.Close()
                    MASTERCONN.Open()
                    dr = tempcmd.ExecuteReader()
                    If dr.HasRows Then
                        dr.Read()
                        tempval(18) = Val(dr("user_ID"))
                    Else
                        tempval(18) = Val(0)
                    End If
                    MASTERCONN.Close()
                    tempcmd.Dispose()


                    'getting departmentid
                    tempcmd = New OleDbCommand("select department_id from departmentmaster where department_name =  '" & DTROW("department_NAME") & "'", MASTERCONN)
                    If MASTERCONN.State = ConnectionState.Open Then MASTERCONN.Close()
                    MASTERCONN.Open()
                    dr = tempcmd.ExecuteReader()
                    If dr.HasRows Then
                        dr.Read()
                        tempval(19) = Val(dr("department_ID"))
                    Else
                        tempval(19) = Val(0)
                    End If
                    MASTERCONN.Close()
                    tempcmd.Dispose()


                    INSERTMASTERCONN("JOURNALMASTER", tempcol, tempval, MASTERCONN)

                Next
            End If
            conn.Close()
            cmd.Dispose()
            da.Dispose()
            dt.Clear()


            'deleteing from JOURNALMASTER
            cmd = New OleDbCommand("delete from JOURNALMASTER where JOURNALMASTER.JV_DATE >= #" & Format(DTFROM.Value.Date, "MM/dd/yyyy") & "# AND JOURNALMASTER.JV_DATE <= #" & Format(DTTO.Value.Date, "MM/dd/yyyy") & "#", conn)
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Open()
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            conn.Close()
            '********************** END OF JOURNALMASTER ******************************





            '********************** START OF SALARYENTRY ******************************
            For i = 1 To 50
                tempcol(i) = ""
                tempval(i) = ""
            Next


            tempcol(0) = "SAL_NO"
            tempcol(1) = "SAL_DATE"
            tempcol(2) = "SAL_TOTALGROSSAMT"
            tempcol(3) = "SAL_TOTALDEDUCTION"
            tempcol(4) = "SAL_TOTALAMT"
            tempcol(5) = "SAL_TOTALCASH"
            tempcol(6) = "SAL_SRNO"
            tempcol(7) = "SAL_TOLEDGERID"
            tempcol(8) = "SAL_SALARY"
            tempcol(9) = "SAL_FROMDATE"
            tempcol(10) = "SAL_TODATE"
            tempcol(11) = "SAL_DAYS"
            tempcol(12) = "SAL_ABSENT"
            tempcol(13) = "SAL_NIGHTS"
            tempcol(14) = "SAL_OT"
            tempcol(15) = "SAL_HOURRATE"
            tempcol(16) = "SAL_HOURS"
            tempcol(17) = "SAL_GROSSAMT"
            tempcol(18) = "SAL_DEDUCTION"
            tempcol(19) = "SAL_AMOUNT"
            tempcol(20) = "SAL_CASH"
            tempcol(21) = "SAL_NARR"
            tempcol(22) = "SAL_USERID"
            tempcol(23) = "SAL_DEPARTMENTID"

            cmd = New OleDbCommand(" SELECT SALARYENTRY.SAL_NO, SALARYENTRY.SAL_DATE, SALARYENTRY.SAL_TOTALGROSSAMT, SALARYENTRY.SAL_TOTALDEDUCTION, SALARYENTRY.SAL_TOTALAMT, SALARYENTRY.SAL_TOTALCASH, SALARYENTRY.SAL_SRNO, ledgermaster.ledger_name, SALARYENTRY.SAL_SALARY, SALARYENTRY.SAL_FROMDATE, SALARYENTRY.SAL_TODATE, SALARYENTRY.SAL_DAYS, SALARYENTRY.SAL_ABSENT, SALARYENTRY.SAL_NIGHTS, SALARYENTRY.SAL_OT, SALARYENTRY.SAL_HOURRATE, SALARYENTRY.SAL_HOURS, SALARYENTRY.SAL_GROSSAMT, SALARYENTRY.SAL_DEDUCTION, SALARYENTRY.SAL_AMOUNT, SALARYENTRY.SAL_CASH, SALARYENTRY.SAL_NARR, USERMASTER.USER_NAME, DEPARTMENTMASTER.DEPARTMENT_NAME FROM ((SALARYENTRY LEFT JOIN ledgermaster ON SALARYENTRY.SAL_TOLEDGERID = ledgermaster.ledger_id) LEFT JOIN USERMASTER ON SALARYENTRY.SAL_USERID = USERMASTER.USER_ID) LEFT JOIN DEPARTMENTMASTER ON SALARYENTRY.SAL_DEPARTMENTID = DEPARTMENTMASTER.DEPARTMENT_ID  where SALARYENTRY.SAL_DATE >= #" & Format(DTFROM.Value.Date, "MM/dd/yyyy") & "# AND SALARYENTRY.SAL_DATE <= #" & Format(DTTO.Value.Date, "MM/dd/yyyy") & "#", conn)
            da = New OleDbDataAdapter(cmd)
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For Each DTROW As DataRow In dt.Rows

                    tempval(0) = Val(DTROW("SAL_NO"))
                    tempval(1) = "'" & Format(DTROW("SAL_DATE"), "dd/MM/yyyy") & "'"
                    tempval(2) = Val(DTROW("SAL_TOTALGROSSAMT"))
                    tempval(3) = Val(DTROW("SAL_TOTALDEDUCTION"))
                    tempval(4) = Val(DTROW("SAL_TOTALAMT"))
                    tempval(5) = Val(DTROW("SAL_TOTALCASH"))
                    tempval(6) = Val(DTROW("SAL_SRNO"))

                    'getting ledgerid
                    tempcmd = New OleDbCommand("select ledger_id from ledgermaster where ledger_NAME = '" & DTROW("ledger_name") & "'", MASTERCONN)
                    If MASTERCONN.State = ConnectionState.Open Then MASTERCONN.Close()
                    MASTERCONN.Open()
                    dr = tempcmd.ExecuteReader()
                    If dr.HasRows Then
                        dr.Read()
                        tempval(7) = Val(dr("ledger_id"))
                    Else
                        tempval(7) = Val(0)
                    End If
                    MASTERCONN.Close()
                    tempcmd.Dispose()

                    tempval(8) = Val(DTROW("SAL_SALARY"))
                    tempval(9) = "'" & Format(DTROW("SAL_FROMDATE"), "dd/MM/yyyy") & "'"
                    tempval(10) = "'" & Format(DTROW("SAL_TODATE"), "dd/MM/yyyy") & "'"
                    tempval(11) = Val(DTROW("SAL_DAYS"))
                    tempval(12) = Val(DTROW("SAL_ABSENT"))
                    tempval(13) = Val(DTROW("SAL_NIGHTS"))
                    tempval(14) = Val(DTROW("SAL_OT"))
                    tempval(15) = Val(DTROW("SAL_HOURRATE"))
                    tempval(16) = Val(DTROW("SAL_HOURS"))
                    tempval(17) = Val(DTROW("SAL_GROSSAMT"))
                    tempval(18) = Val(DTROW("SAL_DEDUCTION"))
                    tempval(19) = Val(DTROW("SAL_AMOUNT"))
                    tempval(20) = Val(DTROW("SAL_CASH"))
                    If IsDBNull(DTROW("SAL_NARR")) = False Then tempval(21) = "'" & DTROW("SAL_NARR") & "'" Else tempval(21) = "''"


                    'getting userid
                    tempcmd = New OleDbCommand("select user_id from usermaster where user_name =  '" & DTROW("USER_NAME") & "'", MASTERCONN)
                    If MASTERCONN.State = ConnectionState.Open Then MASTERCONN.Close()
                    MASTERCONN.Open()
                    dr = tempcmd.ExecuteReader()
                    If dr.HasRows Then
                        dr.Read()
                        tempval(22) = Val(dr("user_ID"))
                    Else
                        tempval(22) = Val(0)
                    End If
                    MASTERCONN.Close()
                    tempcmd.Dispose()


                    'getting departmentid
                    tempcmd = New OleDbCommand("select department_id from departmentmaster where department_name =  '" & DTROW("department_NAME") & "'", MASTERCONN)
                    If MASTERCONN.State = ConnectionState.Open Then MASTERCONN.Close()
                    MASTERCONN.Open()
                    dr = tempcmd.ExecuteReader()
                    If dr.HasRows Then
                        dr.Read()
                        tempval(23) = Val(dr("department_ID"))
                    Else
                        tempval(23) = Val(0)
                    End If
                    MASTERCONN.Close()
                    tempcmd.Dispose()


                    INSERTMASTERCONN("SALARYENTRY", tempcol, tempval, MASTERCONN)

                Next
            End If
            conn.Close()
            cmd.Dispose()
            da.Dispose()
            dt.Clear()

            'deleteing from SALARYENTRY
            cmd = New OleDbCommand("delete from SALARYENTRY where SALARYENTRY.SAL_DATE >= #" & Format(DTFROM.Value.Date, "MM/dd/yyyy") & "# AND SALARYENTRY.SAL_DATE <= #" & Format(DTTO.Value.Date, "MM/dd/yyyy") & "#", conn)
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Open()
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            conn.Close()
            '********************** END OF SALARYENTRY ******************************






            '********************** START OF VOUCHERS ******************************
            For i = 1 To 50
                tempcol(i) = ""
                tempval(i) = ""
            Next


            tempcol(0) = "voucher_id"
            tempcol(1) = "voucher_date"
            tempcol(2) = "voucher_ledgerid"
            tempcol(3) = "voucher_itemid"
            tempcol(4) = "voucher_grosswt"
            tempcol(5) = "voucher_purity"
            tempcol(6) = "voucher_wastage"
            tempcol(7) = "voucher_nettwt"
            tempcol(8) = "voucher_labour"
            tempcol(9) = "voucher_pieces"
            tempcol(10) = "voucher_bullion"
            tempcol(11) = "voucher_amount"
            tempcol(12) = "voucher_bhavcut"
            tempcol(13) = "voucher_goldrate"
            tempcol(14) = "voucher_perwt"
            tempcol(15) = "voucher_othercharge"
            tempcol(16) = "voucher_balancewt"
            tempcol(17) = "voucher_amt"
            tempcol(18) = "voucher_totalamt"
            tempcol(19) = "voucher_cashrecieved"
            tempcol(20) = "voucher_balance"
            tempcol(21) = "voucher_balorjamaorpaid"
            tempcol(22) = "voucher_totalgrosswt"
            tempcol(23) = "voucher_totalnettwt"
            tempcol(24) = "voucher_narration"
            tempcol(25) = "voucher_type"
            tempcol(26) = "voucher_addtotal"
            tempcol(27) = "voucher_lesstotal"
            tempcol(28) = "voucher_inwords"
            tempcol(29) = "voucher_crdays"
            tempcol(30) = "voucher_expenseid"
            tempcol(31) = "voucher_expmemo"
            tempcol(32) = "voucher_expamt"
            tempcol(33) = "voucher_lessid"
            tempcol(34) = "voucher_lessmemo"
            tempcol(35) = "voucher_lessamt"
            tempcol(36) = "voucher_salesmenid"
            tempcol(37) = "VOUCHER_PRINT"
            tempcol(38) = "VOUCHER_CHK"
            tempcol(39) = "VOUCHER_ITEMDESC"
            tempcol(40) = "VOUCHER_LESSWT"
            tempcol(41) = "VOUCHER_DIFF"
            tempcol(42) = "VOUCHER_USERID"
            tempcol(43) = "VOUCHER_DEPARTMENTID"
            tempcol(44) = "VOUCHER_GRIDSRNO"
            tempcol(45) = "VOUCHER_STONERATE"
            tempcol(46) = "VOUCHER_TOTALLABAMT"
            tempcol(47) = "VOUCHER_TOTALSTONEAMT"



            cmd = New OleDbCommand(" SELECT vouchers.voucher_id, vouchers.voucher_date, ledgermaster.ledger_name, ItemMaster.item_name, vouchers.voucher_grosswt, vouchers.voucher_purity, vouchers.voucher_wastage, vouchers.voucher_nettwt, vouchers.voucher_labour, vouchers.voucher_pieces, vouchers.voucher_bullion, vouchers.voucher_amount, vouchers.voucher_bhavcut, vouchers.voucher_goldrate, vouchers.voucher_perwt, vouchers.voucher_othercharge, vouchers.voucher_balancewt, vouchers.voucher_amt, vouchers.voucher_totalamt, vouchers.voucher_cashrecieved, vouchers.voucher_balance, vouchers.voucher_balorjamaorpaid, vouchers.voucher_totalgrosswt, vouchers.voucher_totalnettwt, vouchers.voucher_narration, vouchers.voucher_type, vouchers.voucher_addtotal, vouchers.voucher_lesstotal, vouchers.voucher_inwords, vouchers.voucher_crdays, EXPENSELEDGERMASTER.ledger_name AS EXPLEDGERNAME, vouchers.voucher_expmemo, vouchers.voucher_expamt, LESSLEDGERMASTER.ledger_name AS LESSLEDGERNAME, vouchers.voucher_lessmemo, vouchers.voucher_lessamt, salesmenmaster.salesmen_name, vouchers.VOUCHER_PRINT, vouchers.VOUCHER_CHK, vouchers.VOUCHER_ITEMDESC, vouchers.VOUCHER_LESSWT, vouchers.VOUCHER_DIFF, USERMASTER.USER_NAME, DEPARTMENTMASTER.DEPARTMENT_NAME, vouchers.VOUCHER_GRIDSRNO, vouchers.VOUCHER_STONERATE, vouchers.VOUCHER_TOTALLABAMT, vouchers.VOUCHER_TOTALSTONEAMT FROM ((((((vouchers LEFT JOIN ledgermaster ON vouchers.voucher_ledgerid = ledgermaster.ledger_id) LEFT JOIN ItemMaster ON vouchers.voucher_itemid = ItemMaster.item_id) LEFT JOIN ledgermaster AS EXPENSELEDGERMASTER ON vouchers.voucher_expenseid = EXPENSELEDGERMASTER.ledger_id) LEFT JOIN ledgermaster AS LESSLEDGERMASTER ON vouchers.voucher_lessid = LESSLEDGERMASTER.ledger_id) LEFT JOIN salesmenmaster ON vouchers.voucher_salesmenid = salesmenmaster.Salesmen_id) LEFT JOIN USERMASTER ON vouchers.VOUCHER_USERID = USERMASTER.USER_ID) LEFT JOIN DEPARTMENTMASTER ON vouchers.VOUCHER_DEPARTMENTID = DEPARTMENTMASTER.DEPARTMENT_ID  where vouchers.voucher_date >= #" & Format(DTFROM.Value.Date, "MM/dd/yyyy") & "# AND vouchers.voucher_date <= #" & Format(DTTO.Value.Date, "MM/dd/yyyy") & "#", conn)
            da = New OleDbDataAdapter(cmd)
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For Each DTROW As DataRow In dt.Rows

                    tempval(0) = Val(DTROW("voucher_id"))
                    tempval(1) = "'" & Format(DTROW("voucher_date"), "dd/MM/yyyy") & "'"


                    'getting ledgerid
                    tempcmd = New OleDbCommand("select ledger_id from ledgermaster where ledger_NAME = '" & DTROW("ledger_name") & "'", MASTERCONN)
                    If MASTERCONN.State = ConnectionState.Open Then MASTERCONN.Close()
                    MASTERCONN.Open()
                    dr = tempcmd.ExecuteReader()
                    If dr.HasRows Then
                        dr.Read()
                        tempval(2) = Val(dr("ledger_id"))
                    Else
                        tempval(2) = Val(0)
                    End If
                    MASTERCONN.Close()
                    tempcmd.Dispose()


                    'getting itemid
                    tempcmd = New OleDbCommand("select item_id from itemmaster where item_NAME =  '" & DTROW("item_name") & "'", MASTERCONN)
                    If MASTERCONN.State = ConnectionState.Open Then MASTERCONN.Close()
                    MASTERCONN.Open()
                    dr = tempcmd.ExecuteReader()
                    If dr.HasRows Then
                        dr.Read()
                        tempval(3) = Val(dr("ITEM_ID"))
                    Else
                        tempval(3) = Val(0)
                    End If
                    MASTERCONN.Close()
                    tempcmd.Dispose()



                    tempval(4) = Val(DTROW("voucher_grosswt"))
                    tempval(5) = Val(DTROW("voucher_purity"))
                    tempval(6) = Val(DTROW("voucher_wastage"))
                    tempval(7) = Val(DTROW("voucher_nettwt"))
                    tempval(8) = Val(DTROW("voucher_labour"))
                    tempval(9) = Val(DTROW("voucher_pieces"))
                    tempval(10) = Val(DTROW("voucher_bullion"))
                    tempval(11) = Val(DTROW("voucher_amount"))
                    tempval(12) = Val(DTROW("voucher_bhavcut"))
                    tempval(13) = Val(DTROW("voucher_goldrate"))
                    tempval(14) = Val(DTROW("voucher_perwt"))
                    tempval(15) = Val(DTROW("voucher_othercharge"))
                    tempval(16) = Val(DTROW("voucher_balancewt"))
                    tempval(17) = Val(DTROW("voucher_amt"))
                    tempval(18) = Val(DTROW("voucher_totalamt"))
                    tempval(19) = Val(DTROW("voucher_cashrecieved"))
                    tempval(20) = Val(DTROW("voucher_balance"))

                    tempval(21) = "'" & DTROW("voucher_balorjamaorpaid") & "'"
                    tempval(22) = Val(DTROW("voucher_totalgrosswt"))
                    tempval(23) = Val(DTROW("voucher_totalnettwt"))

                    If IsDBNull(DTROW("voucher_narration")) = False Then tempval(24) = "'" & DTROW("voucher_narration") & "'" Else tempval(24) = "''"
                    tempval(25) = "'" & DTROW("voucher_type") & "'"
                    tempval(26) = Val(DTROW("voucher_addtotal"))
                    tempval(27) = Val(DTROW("voucher_lesstotal"))
                    tempval(28) = "'" & DTROW("voucher_inwords") & "'"
                    tempval(29) = Val(DTROW("voucher_crdays"))


                    'getting EXPLEDGERNAME
                    tempcmd = New OleDbCommand("select ledger_id from ledgermaster where ledger_NAME = '" & DTROW("EXPLEDGERNAME") & "'", MASTERCONN)
                    If MASTERCONN.State = ConnectionState.Open Then MASTERCONN.Close()
                    MASTERCONN.Open()
                    dr = tempcmd.ExecuteReader()
                    If dr.HasRows Then
                        dr.Read()
                        tempval(30) = Val(dr("ledger_id"))
                    Else
                        tempval(30) = Val(0)
                    End If
                    MASTERCONN.Close()
                    tempcmd.Dispose()

                    If IsDBNull(DTROW("voucher_expmemo")) = False Then tempval(31) = "'" & DTROW("voucher_expmemo") & "'" Else tempval(31) = "''"
                    tempval(32) = Val(DTROW("voucher_expamt"))






                    'getting ledgerid
                    tempcmd = New OleDbCommand("select ledger_id from ledgermaster where ledger_NAME = '" & DTROW("LESSLEDGERNAME") & "'", MASTERCONN)
                    If MASTERCONN.State = ConnectionState.Open Then MASTERCONN.Close()
                    MASTERCONN.Open()
                    dr = tempcmd.ExecuteReader()
                    If dr.HasRows Then
                        dr.Read()
                        tempval(33) = Val(dr("ledger_id"))
                    Else
                        tempval(33) = Val(0)
                    End If
                    MASTERCONN.Close()
                    tempcmd.Dispose()

                    If IsDBNull(DTROW("voucher_lessmemo")) = False Then tempval(34) = "'" & DTROW("voucher_lessmemo") & "'" Else tempval(34) = "''"
                    tempval(35) = Val(DTROW("voucher_lessamt"))



                    'getting SALESMANID
                    tempcmd = New OleDbCommand("select SALESMEN_id from SALESMENMASTER where SALESMEN_name =  '" & DTROW("salesmen_name") & "'", MASTERCONN)
                    If MASTERCONN.State = ConnectionState.Open Then MASTERCONN.Close()
                    MASTERCONN.Open()
                    dr = tempcmd.ExecuteReader()
                    If dr.HasRows Then
                        dr.Read()
                        tempval(36) = Val(dr("SALESMEN_id"))
                    Else
                        tempval(36) = Val(0)
                    End If
                    MASTERCONN.Close()
                    tempcmd.Dispose()

                    tempval(37) = Val(DTROW("VOUCHER_PRINT"))
                    tempval(38) = Val(DTROW("VOUCHER_CHK"))
                    If IsDBNull(DTROW("VOUCHER_ITEMDESC")) = False Then tempval(39) = "'" & DTROW("VOUCHER_ITEMDESC") & "'" Else tempval(39) = "''"
                    tempval(40) = Val(DTROW("VOUCHER_LESSWT"))
                    tempval(41) = Val(DTROW("VOUCHER_DIFF"))


                    'getting userid
                    tempcmd = New OleDbCommand("select user_id from usermaster where user_name =  '" & DTROW("USER_NAME") & "'", MASTERCONN)
                    If MASTERCONN.State = ConnectionState.Open Then MASTERCONN.Close()
                    MASTERCONN.Open()
                    dr = tempcmd.ExecuteReader()
                    If dr.HasRows Then
                        dr.Read()
                        tempval(42) = Val(dr("user_ID"))
                    Else
                        tempval(42) = Val(0)
                    End If
                    MASTERCONN.Close()
                    tempcmd.Dispose()


                    'getting departmentid
                    tempcmd = New OleDbCommand("select department_id from departmentmaster where department_name =  '" & DTROW("department_NAME") & "'", MASTERCONN)
                    If MASTERCONN.State = ConnectionState.Open Then MASTERCONN.Close()
                    MASTERCONN.Open()
                    dr = tempcmd.ExecuteReader()
                    If dr.HasRows Then
                        dr.Read()
                        tempval(43) = Val(dr("department_ID"))
                    Else
                        tempval(43) = Val(0)
                    End If
                    MASTERCONN.Close()
                    tempcmd.Dispose()

                    tempval(44) = Val(DTROW("VOUCHER_GRIDSRNO"))
                    tempval(45) = Val(DTROW("VOUCHER_STONERATE"))
                    tempval(46) = Val(DTROW("VOUCHER_TOTALLABAMT"))
                    tempval(47) = Val(DTROW("VOUCHER_TOTALSTONEAMT"))


                    INSERTMASTERCONN("VOUCHERS", tempcol, tempval, MASTERCONN)

                Next
            End If
            conn.Close()
            cmd.Dispose()
            da.Dispose()
            dt.Clear()


            'deleteing from VOUCHERS
            cmd = New OleDbCommand("delete from VOUCHERS where vouchers.voucher_date >= #" & Format(DTFROM.Value.Date, "MM/dd/yyyy") & "# AND vouchers.voucher_date <= #" & Format(DTTO.Value.Date, "MM/dd/yyyy") & "#", conn)
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Open()
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            conn.Close()
            '********************** END OF VOUCHERS ******************************




            MsgBox("Transfer Completed")
            Me.Close()
            '********************** END OF TRANSFER OF DATA FROM DAY PEN TO MAIN PEN COMPLETED ******************************


        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class