
Imports System.Data.OleDb

Public Class YearTansfer

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDEXIT.Click
        Me.Close()
    End Sub

    Sub GETDATA()
        Try
            GRIDCMP.RowCount = 0
            dt = New DataTable()
            If OGCONN.State = ConnectionState.Open Then
                OGCONN.Close()
            End If
            OGCONN.Open()
            cmd = New OleDbCommand("SELECT cmpmaster.cmp_name AS CMPNAME FROM cmpmaster WHERE CMP_NO <> " & tempcmpid, OGCONN)
            da = New OleDbDataAdapter(cmd)
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For Each DTROW As DataRow In dt.Rows
                    GRIDCMP.Rows.Add(DTROW("CMPNAME"), Application.StartupPath & "\Database\" & DTROW("CMPNAME") & "\" & DTROW("CMPNAME") & ".mdb")
                Next
            End If
            OGCONN.Close()
            da.Dispose()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub YearTansfer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GETDATA()
    End Sub

    Private Sub CMDOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDOK.Click
        Try
            'transfering data from selected cmp
            If GRIDCMP.SelectedRows.Count = 0 Then
                MsgBox("Select Company", MsgBoxStyle.Critical)
                Exit Sub
            End If

            Dim SELECTEDCONN As New OleDbConnection
            If SELECTEDCONN.State = ConnectionState.Open Then
                SELECTEDCONN.Close()
            End If
            SELECTEDCONN.ConnectionString = ("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & GRIDCMP.Rows(GRIDCMP.CurrentRow.Index).Cells(GCMPPATH.Index).Value & ";Jet OLEDB:Database Password= 1902")
            SELECTEDCONN.Open()

            Dim SELECTEDCMPID As Integer = 0
            Dim TEMPMSG As Integer = MsgBox("Transfer Data from Selected Company?", MsgBoxStyle.YesNo)
            If TEMPMSG = vbYes Then
                TEMPMSG = MsgBox("Are you sure, wish to Proceed?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbYes Then

                    '********* TRANSFERRING DATA ***********
                    Dim dt As New DataTable()
                    Dim dt1 As New DataTable()


                    'AREAMASTER
                    If SELECTEDCONN.State = ConnectionState.Open Then SELECTEDCONN.Close()
                    SELECTEDCONN.Open()
                    cmd = New OleDbCommand("SELECT AREAMASTER.AREA_NAME AS AREA FROM AREAMASTER", SELECTEDCONN)
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
                    SELECTEDCONN.Close()
                    cmd.Dispose()


                    dt.Clear()
                    'CATEGORY
                    If SELECTEDCONN.State = ConnectionState.Open Then SELECTEDCONN.Close()
                    SELECTEDCONN.Open()
                    cmd = New OleDbCommand("SELECT CATEGORYMASTER.CATEGORY_NAME AS CATEGORY FROM CATEGORYMASTER", SELECTEDCONN)
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
                    SELECTEDCONN.Close()
                    cmd.Dispose()


                    dt.Clear()
                    'CITY
                    If SELECTEDCONN.State = ConnectionState.Open Then SELECTEDCONN.Close()
                    SELECTEDCONN.Open()
                    cmd = New OleDbCommand("SELECT CITYMASTER.CITY_NAME AS CITY FROM CITYMASTER", SELECTEDCONN)
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
                    SELECTEDCONN.Close()
                    cmd.Dispose()




                    dt.Clear()
                    'COUNTRY
                    If SELECTEDCONN.State = ConnectionState.Open Then SELECTEDCONN.Close()
                    SELECTEDCONN.Open()
                    cmd = New OleDbCommand("SELECT COUNTRYMASTER.COUNTRY_NAME AS COUNTRY FROM COUNTRYMASTER", SELECTEDCONN)
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
                    SELECTEDCONN.Close()
                    cmd.Dispose()




                    dt.Clear()
                    'STATE
                    If SELECTEDCONN.State = ConnectionState.Open Then SELECTEDCONN.Close()
                    SELECTEDCONN.Open()
                    cmd = New OleDbCommand("SELECT STATEMASTER.STATE_NAME AS STATE FROM STATEMASTER", SELECTEDCONN)
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
                    SELECTEDCONN.Close()
                    cmd.Dispose()




                    dt.Clear()
                    'TYPE
                    If SELECTEDCONN.State = ConnectionState.Open Then SELECTEDCONN.Close()
                    SELECTEDCONN.Open()
                    cmd = New OleDbCommand("SELECT TYPEMASTER.TYPE_NAME AS TYPE FROM TYPEMASTER", SELECTEDCONN)
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
                    SELECTEDCONN.Close()
                    cmd.Dispose()




                    dt.Clear()
                    'GROUP
                    If SELECTEDCONN.State = ConnectionState.Open Then SELECTEDCONN.Close()
                    SELECTEDCONN.Open()
                    cmd = New OleDbCommand("SELECT GROUPMASTER.GROUP_TYPE AS GROUPTYPE, GROUPMASTER.GROUP_NAME AS GROUPNAME, GROUPMASTER.GROUP_UNDER AS GROUPUNDER FROM GROUPMASTER", SELECTEDCONN)
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
                    SELECTEDCONN.Close()
                    cmd.Dispose()



                    dt.Clear()
                    'SHAPE
                    If SELECTEDCONN.State = ConnectionState.Open Then SELECTEDCONN.Close()
                    SELECTEDCONN.Open()
                    cmd = New OleDbCommand("SELECT SHAPEMASTER.SHAPE_NAME AS SHAPE FROM SHAPEMASTER", SELECTEDCONN)
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
                    SELECTEDCONN.Close()
                    cmd.Dispose()



                    dt.Clear()
                    'SIZE
                    If SELECTEDCONN.State = ConnectionState.Open Then SELECTEDCONN.Close()
                    SELECTEDCONN.Open()
                    cmd = New OleDbCommand("SELECT SIZEMASTER.SIZE_NAME AS [SIZE] FROM SIZEMASTER", SELECTEDCONN)
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
                    SELECTEDCONN.Close()
                    cmd.Dispose()



                    dt.Clear()
                    'COLOR
                    If SELECTEDCONN.State = ConnectionState.Open Then SELECTEDCONN.Close()
                    SELECTEDCONN.Open()
                    cmd = New OleDbCommand("SELECT COLORMASTER.COLOR_NAME AS [COLOR] FROM COLORMASTER", SELECTEDCONN)
                    da = New OleDbDataAdapter(cmd)
                    da.Fill(dt)
                    If dt.Rows.Count > 0 Then
                        For Each DTROW As DataRow In dt.Rows

                            dt1.Clear()
                            'CHECKING WHETHER COLOR IS PRESENT IN CURRENT COMPANY OR NOT
                            If conn.State = ConnectionState.Open Then conn.Close()
                            conn.Open()
                            tempcmd = New OleDbCommand("SELECT COLORMASTER.COLOR_NAME AS [COLOR] FROM COLORMASTER WHERE COLORMASTER.COLOR_NAME = '" & DTROW("COLOR") & "'", conn)
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
                    SELECTEDCONN.Close()
                    cmd.Dispose()



                    dt.Clear()
                    'ITEMMASTER
                    If SELECTEDCONN.State = ConnectionState.Open Then SELECTEDCONN.Close()
                    SELECTEDCONN.Open()
                    cmd = New OleDbCommand("SELECT ITEMMASTER.ITEM_NAME AS ITEMNAME, ITEMMASTER.ITEM_CODE AS ITEMCODE, typemaster.type_name AS ITEMTYPE, CategoryMaster.category_name AS CATEGORY FROM (ItemMaster INNER JOIN CategoryMaster ON ItemMaster.item_categoryid = CategoryMaster.category_id) INNER JOIN typemaster ON ItemMaster.item_typeid = typemaster.type_id ORDER BY ITEM_NAME", SELECTEDCONN)
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
                                tempcol(6) = "item_userid"

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
                                tempval(6) = tempuserid
                                insert("ITEMMASTER", tempcol, tempval)





                                'INSERT DATA IN ITEMMASTER_DESC
                                Dim TEMPDA As OleDbDataAdapter
                                Dim TEMPDT, TEMPDT1 As New DataTable
                                If tempconn.State = ConnectionState.Open Then tempconn.Close()
                                tempconn.Open()
                                tempcmd = New OleDbCommand("SELECT ITEMMASTER_DESC.ITEM_SRNO AS [SRNO], ItemMaster.item_NAME AS [GRIDITEMNAME], ShapeMaster.shape_name AS [SHAPE], SizeMaster.size_name AS [SIZE], ColorMaster.color_name AS [COLOR], ITEMMASTER_DESC.ITEM_PCS AS [PCS], ITEMMASTER_DESC.ITEM_CTWT AS [CTWT] FROM ((((ITEMMASTER_DESC INNER JOIN ItemMaster ON ITEMMASTER_DESC.ITEM_GRIDITEMID = ItemMaster.item_id) LEFT JOIN ShapeMaster ON ITEMMASTER_DESC.ITEM_SHAPEID = ShapeMaster.shape_id) LEFT JOIN SizeMaster ON ITEMMASTER_DESC.ITEM_SIZEID = SizeMaster.size_id) LEFT JOIN ColorMaster ON ITEMMASTER_DESC.ITEM_COLORID = ColorMaster.color_id) INNER JOIN ItemMaster AS MainItemMaster ON ITEMMASTER_DESC.ITEM_ID = MainItemMaster.item_id where MAINITEMMASTER.ITEM_NAME = '" & DTROW("ITEMNAME") & "' ORDER BY ITEMMASTER.ITEM_NAME, ITEM_SRNO ", SELECTEDCONN)
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
                    SELECTEDCONN.Close()
                    cmd.Dispose()









                    dt.Clear()
                    'LEDGERMASTER
                    If SELECTEDCONN.State = ConnectionState.Open Then SELECTEDCONN.Close()
                    SELECTEDCONN.Open()
                    cmd = New OleDbCommand("SELECT ledgermaster.ledger_name AS LEDGERNAME, ledgermaster.ledger_code AS LEDGERCODE, groupmaster.group_name AS GROUPNAME, ledgermaster.ledger_add1 AS ADD1, ledgermaster.ledger_add2 AS ADD2, areamaster.area_name AS AREANAME, citymaster.city_name AS CITYNAME, ledgermaster.ledger_zipcode AS ZIPCODE, statemaster.state_name AS STATENAME, countrymaster.country_name AS COUNTRYNAME, ledgermaster.ledger_std AS STD, ledgermaster.ledger_resi AS RESI, ledgermaster.ledger_altno AS ALTNO, ledgermaster.ledger_tel1 AS TEL1, ledgermaster.ledger_mobile AS MOBILE, ledgermaster.ledger_fax AS FAX, ledgermaster.ledger_website AS WEBSITE, ledgermaster.ledger_email AS EMAIL, ledgermaster.ledger_crdays AS CRDAYS, ledgermaster.ledger_crlimit AS CRLIMIT, ledgermaster.ledger_panno AS PANNO, IIF(ISNULL(ledgermaster.ledger_SALARY) = TRUE, 0, ledgermaster.ledger_SALARY) AS SALARY, ledgermaster.ledger_cstno AS CSTNO, ledgermaster.ledger_tinno AS TINNO, ledgermaster.ledger_stno AS STNO, ledgermaster.ledger_vatno AS VATNO, ledgermaster.ledger_kstno AS KSTNO, ledgermaster.ledger_add AS LEDGERADDRESS, ledgermaster.ledger_shipadd AS SHIPADD, ledgermaster.ledger_notes AS NOTES, ledgermaster.ledger_settlement AS SETTLEMENT, LEDGERMASTER.LEDGER_LOSSAC AS LOSSAC, LEDGERMASTER.LEDGER_KARIGAR AS KARIGAR FROM ((((ledgermaster LEFT JOIN groupmaster ON ledgermaster.ledger_groupid = groupmaster.group_id) LEFT JOIN areamaster ON ledgermaster.ledger_areaid = areamaster.area_id) LEFT JOIN citymaster ON ledgermaster.ledger_cityid = citymaster.city_id) LEFT JOIN statemaster ON ledgermaster.ledger_stateid = statemaster.state_id) LEFT JOIN countrymaster ON ledgermaster.ledger_countryid = countrymaster.country_id ORDER BY ledgermaster.ledger_name", SELECTEDCONN)
                    da = New OleDbDataAdapter(cmd)
                    da.Fill(dt)
                    If dt.Rows.Count > 0 Then
                        For Each DTROW As DataRow In dt.Rows

                            dt1.Clear()
                            'CHECKING WHETHER ITEM IS PRESENT IN CURRENT COMPANY OR NOT
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


                                'transfer BALANCE
                                tempcmd = New OleDbCommand("SELECT IIF(ISNULL(Sum(trialbalance.nettwt)) = True, 0, Sum(trialbalance.nettwt)) AS BalWt, IIF(ISNULL(Sum(trialbalance.amount)) = TRUE, 0, Sum(trialbalance.amount)) AS BalAmt, IIF(ISNULL(Sum(trialbalance.GROSSWT)) = True, 0, Sum(trialbalance.GROSSWT)) AS BALGROSSWT FROM(TrialBalance) where trialbalance.CODE = '" & DTROW("LEDGERCODE") & "'", SELECTEDCONN)
                                If tempconn.State = ConnectionState.Open Then
                                    tempconn.Close()
                                End If
                                tempconn.Open()
                                tempdr = tempcmd.ExecuteReader
                                If tempdr.HasRows Then
                                    tempdr.Read()
                                    If Val(tempdr("BALAMT")) < 0 Then tempval(3) = Val(tempdr("BALAMT")) * (-1) Else tempval(3) = Val(tempdr("BALAMT"))
                                    If Val(tempdr("BALAMT")) < 0 Then tempval(4) = "'Dr.'" Else tempval(4) = "'Cr.'"
                                    If Val(tempdr("BALWT")) < 0 Then tempval(5) = Val(tempdr("BALWT")) * (-1) Else tempval(5) = Val(tempdr("BALWT"))
                                    If Val(tempdr("BALWT")) < 0 Then tempval(6) = "'Dr.'" Else tempval(6) = "'Cr.'"
                                    If Val(tempdr("BALGROSSWT")) < 0 Then tempval(38) = Val(tempdr("BALGROSSWT")) * (-1) Else tempval(38) = Val(tempdr("BALGROSSWT"))
                                    If Val(tempdr("BALGROSSWT")) < 0 Then tempval(39) = "'Dr.'" Else tempval(39) = "'Cr.'"
                                Else
                                    tempval(3) = 0
                                    tempval(4) = "Dr."
                                    tempval(5) = 0
                                    tempval(6) = "Dr."
                                    tempval(38) = 0
                                    tempval(39) = "Dr."
                                End If
                                tempconn.Close()
                                tempdr.Close()


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

                            Else



                                'UPDATE LEDGERS 
                                'transfer BALANCE
                                For i As Integer = 0 To 50
                                    tempcol(i) = ""
                                    tempval(i) = ""
                                Next
                                tempcol(0) = "ledger_opbalrs"
                                tempcol(1) = "ledger_drcrrs"
                                tempcol(2) = "ledger_opbalwt"
                                tempcol(3) = "ledger_drcrwt"
                                tempcol(4) = "LEDGER_OPBALGROSSWT"
                                tempcol(5) = "LEDGER_DRCRGROSSWT"

                                tempcmd = New OleDbCommand("SELECT IIF(ISNULL(Sum(trialbalance.nettwt)) = True, 0, ROUND(Sum(trialbalance.nettwt),3)) AS BalWt, IIF(ISNULL(Sum(trialbalance.amount)) = TRUE, 0, ROUND(Sum(trialbalance.amount),2)) AS BalAmt, IIF(ISNULL(Sum(trialbalance.GROSSWT)) = True, 0, ROUND(Sum(trialbalance.GROSSWT),3)) AS BALGROSSWT  FROM(TrialBalance) where trialbalance.CODE = '" & DTROW("LEDGERCODE") & "'", SELECTEDCONN)
                                If tempconn.State = ConnectionState.Open Then
                                    tempconn.Close()
                                End If
                                tempconn.Open()
                                tempdr = tempcmd.ExecuteReader
                                If tempdr.HasRows Then
                                    tempdr.Read()
                                    If Val(tempdr("BALAMT")) < 0 Then tempval(0) = Val(tempdr("BALAMT")) * (-1) Else tempval(0) = Val(tempdr("BALAMT"))
                                    If Val(tempdr("BALAMT")) < 0 Then tempval(1) = "'Dr.'" Else tempval(1) = "'Cr.'"
                                    If Val(tempdr("BALWT")) < 0 Then tempval(2) = Val(tempdr("BALWT")) * (-1) Else tempval(2) = Val(tempdr("BALWT"))
                                    If Val(tempdr("BALWT")) < 0 Then tempval(3) = "'Dr.'" Else tempval(3) = "'Cr.'"
                                    If Val(tempdr("BALGROSSWT")) < 0 Then tempval(4) = Val(tempdr("BALGROSSWT")) * (-1) Else tempval(4) = Val(tempdr("BALGROSSWT"))
                                    If Val(tempdr("BALGROSSWT")) < 0 Then tempval(5) = "'Dr.'" Else tempval(5) = "'Cr.'"
                                Else
                                    tempval(0) = 0
                                    tempval(1) = "Dr."
                                    tempval(2) = 0
                                    tempval(3) = "Dr."
                                    tempval(4) = 0
                                    tempval(5) = "Dr."
                                End If
                                tempconn.Close()
                                tempdr.Close()



                                modify("ledgermaster", tempcol, tempval, " where LEDGER_CODE = '" & DTROW("LEDGERCODE") & "'")


                            End If
                            conn.Close()
                            tempcmd.Dispose()
                        Next
                    End If
                    SELECTEDCONN.Close()
                    cmd.Dispose()




                    dt.Clear()
                    'CUSTOMERWASTAGE
                    If SELECTEDCONN.State = ConnectionState.Open Then SELECTEDCONN.Close()
                    SELECTEDCONN.Open()
                    cmd = New OleDbCommand("SELECT ledgermaster.ledger_name AS LEDGERNAME, ItemMaster.item_name AS ITEMNAME, CustomerWastage.wastage AS WASTAGE, CustomerWastage.labour AS LABOUR, CustomerWastage.cus_default AS CUSDEFAULT FROM (CustomerWastage INNER JOIN ledgermaster ON CustomerWastage.ledgerid = ledgermaster.ledger_id) LEFT JOIN ItemMaster ON CustomerWastage.itemid = ItemMaster.item_id ", SELECTEDCONN)
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
                    SELECTEDCONN.Close()
                    cmd.Dispose()

                    '******* TRANSFERRING DATA DONE ********

                    MsgBox("Transfer Completed Successfully")
                    MsgBox("Software will be Closed, Please Restart")
                    End

                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class